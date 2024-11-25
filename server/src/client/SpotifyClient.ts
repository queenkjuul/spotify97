import fs from "fs"
const resizeImg = require("resize-image-buffer")

export default class SpotifyClient {
  // environment - asserting non-null, will crash without proper env
  public readonly clientId: string = process.env.SPOTIFY_CLIENT_ID!
  public readonly clientSecret: string = process.env.SPOTIFY_CLIENT_SECRET!
  public readonly redirect: string = process.env.REDIRECT!

  // state
  private authToken: Optional<string> // used to authenticate requests
  private tokenExpiration: Date // when current token expires
  private refreshToken: Optional<string> // used to get a new token without user interaction

  constructor(
    authToken = undefined,
    tokenExpiration = new Date(),
    refreshToken = undefined
  ) {
    this.authToken = authToken
    this.tokenExpiration = tokenExpiration
    this.refreshToken = refreshToken
  }

  // fixed data
  scope =
    "user-read-private user-read-email user-read-playback-state user-modify-playback-state user-read-currently-playing user-read-recently-played playlist-read-private playlist-read-collaborative user-library-read"
  loginHeaders = {
    "Content-Type": "application/x-www-form-urlencoded",
    Authorization:
      "Basic " +
      Buffer.from(this.clientId + ":" + this.clientSecret).toString("base64"),
  }

  // status
  get readyForLogin() {
    return this.clientId && this.redirect
  }

  get readyForCalls() {
    return this.readyForLogin && this.isAuthenticated
  }

  get tokenExpired() {
    return this.tokenExpiration < new Date()
  }

  get isAuthenticated() {
    return this.authToken && !this.tokenExpired
  }

  get hasRefreshToken() {
    return !!this.refreshToken
  }

  // helper
  private err(e) {
    if (e) throw e
  }

  // auth
  async acquireToken(code: string) {
    const response = await fetch(`https://accounts.spotify.com/api/token`, {
      method: "POST",
      headers: this.loginHeaders,
      body: `grant_type=authorization_code&code=${code}&redirect_uri=${this.redirect}`,
    })

    const body = await response.json()

    if (!response.ok || !body.access_token || !body.expires_in) {
      throw new Error(
        "Invalid response when fetching token: " + body.error_description
      )
    }

    this.authToken = body.access_token
    this.refreshToken = body.refresh_token
    this.tokenExpiration = new Date(
      new Date().getTime() + body.expires_in * 1000
    )

    this.saveState()
  }

  async getRefreshToken() {
    if (!this.hasRefreshToken) {
      throw new Error("Cannot refresh token: no refresh token defined!")
    }

    const url = "https://accounts.spotify.com/api/token"
    const params = new URLSearchParams()
    Object.entries({
      grant_type: "refresh_token",
      refresh_token: this.refreshToken,
      client_id: this.clientId,
    }).forEach(([k, v]) => params.append(k, v as string))

    const payload = {
      method: "POST",
      headers: this.loginHeaders,
      body: params,
    }
    const body = await fetch(url, payload)
    const response = await body.json()

    // we don't throw for no new token, just update token to undefined
    this.authToken = response?.access_token
    // refresh tokens can be reused if a new one is not provided
    this.refreshToken = response?.refresh_token
      ? response.refresh_token
      : this.refreshToken
    // if no new expiration, keep existing
    this.tokenExpiration = response?.expires_in
      ? new Date(new Date().getTime() + response.expires_in * 1000)
      : this.tokenExpiration

    this.saveState()
  }

  private async saveState() {
    if (!this.readyForCalls) {
      // no point saving non-functional state
      return
    }
    const data = new Uint8Array(
      Buffer.from(
        JSON.stringify({
          authToken: this.authToken,
          tokenExpiration: this.tokenExpiration,
          refreshToken: this.refreshToken,
        })
      )
    )
    fs.writeFile("state.json", data, (e) => {
      if (e) throw e
      fs.chmod("state.json", 0o600, (e) => {
        if (e) throw e
      })
      console.log("Login information has been saved.")
    })
  }

  // client
  async spotifyRequest(
    path: string,
    method: string = "GET",
    retry = true,
    body: BodyInit | undefined | null = undefined
  ): Promise<Response> {
    if (!this.readyForCalls) {
      throw new Error("Tried to call Spotify without all requisite auth data.")
    }
    const response = await fetch("https://api.spotify.com/v1" + path, {
      headers: {
        Authorization: `Bearer ${this.authToken}`,
      },
      method,
      ...(body ? { body } : {}),
    })
    if (response.status === 401 && retry) {
      await this.getRefreshToken()
      return this.spotifyRequest(path, method, false, body)
    } else if (response && response.status > 399) {
      const body = await response.json()
      throw new Error("Spotify API Error: " + JSON.stringify(body?.error))
    }
    return response
  }

  // endpoints
  async getDeviceList() {
    try {
      const response = await this.spotifyRequest("/me/player/devices")
      const body = await response.json()
      return body.devices
    } catch (e) {
      this.err(e)
    }
  }

  async getPlaybackState() {
    try {
      const response = await this.spotifyRequest("/me/player")
      if (response?.status === 204) {
        // all players are inactive, no active state
        return { active: false }
      } else {
        const data = await response.json()
        return { active: true, ...data }
      }
    } catch (e) {
      this.err(e)
    }
  }

  async getAlbumArt(url) {
    try {
      if (!url) return
      const response = await fetch(url)
      const body = await response.blob()
      const data = await body
        .stream()
        .getReader()
        .read()
        .then((v) => {
          return Buffer.from(v?.value ?? []).toString("base64")
        })
      return data
    } catch (e) {
      this.err(e)
    }
  }

  // 175x175 is size of Mac client album art control
  async getAlbumArtFile(
    url,
    width: string | number = 175,
    height: string | number = 175
  ) {
    try {
      if (!url) return
      if (typeof width === "string") {
        width = parseInt(width)
      }
      if (typeof height === "string") {
        height = parseInt(height)
      }
      const response = await fetch(url)
      const imageData = await response.arrayBuffer()
      const imageBuffer = Buffer.from(imageData)
      const image = await resizeImg(imageBuffer, { width, height })
      return image
    } catch (e) {
      this.err(e)
    }
  }

  async getQueue() {
    try {
      const response = await this.spotifyRequest("/me/player/queue")
      const body = await response.json()
      return body.queue
    } catch (e) {
      this.err(e)
    }
  }

  async getRecents() {
    try {
      const response = await this.spotifyRequest("/me/player/recently-played")
      const body = await response.json()
      return body.items
    } catch (e) {
      this.err(e)
    }
  }

  async getPlaylists() {
    try {
      const response = await this.spotifyRequest("/me/playlists")
      const body = await response.json()
      return body.items
    } catch (e) {
      this.err(e)
    }
  }

  async getSavedTracks() {
    try {
      const response = await this.spotifyRequest("/me/tracks")
      const body = await response.json()
      return body.items
    } catch (e) {
      this.err(e)
    }
  }

  async playbackChange(
    path: string,
    method: string,
    body: BodyInit | undefined | null = undefined
  ): Promise<Optional<number>> {
    let status: Optional<number>
    try {
      const response = await this.spotifyRequest(path, method, true, body)
      status = response?.status
    } catch (e) {
      this.err(e)
    }
    return status
  }

  play = async (
    id: string,
    body: BodyInit | undefined | null = undefined
  ): Promise<Optional<number>> => {
    return await this.playbackChange(
      `/me/player/play?device_id=${id}`,
      "PUT",
      body
    )
  }
  pause = async (id: string) => {
    return await this.playbackChange("/me/player/pause?device_id=" + id, "PUT")
  }
  next = async (id: string) => {
    return await this.playbackChange("/me/player/next?device_id=" + id, "POST")
  }
  prev = async (id: string) => {
    return await this.playbackChange(
      "/me/player/previous?device_id=" + id,
      "POST"
    )
  }
  seek = async (id: string, position: number) => {
    return await this.playbackChange(
      "/me/player/seek?device_id=" + id + "&position_ms=" + position,
      "PUT"
    )
  }
  shuffle = async (_id, state) => {
    return await this.playbackChange("/me/player/shuffle?state=" + state, "PUT")
  }
  repeat = async (id: string, mode: string) => {
    return await this.playbackChange(
      "/me/player/repeat?device_id=" + id + "&state=" + mode,
      "PUT"
    )
  }

  search = async (
    q: string,
    type: string[] = ["album", "track", "playlist"]
  ) => {
    return await this.spotifyRequest(`/search?q=${q}&type=${type}`)
  }

  transfer = async (id: string) => {
    return await this.playbackChange(
      "/me/player",
      "PUT",
      JSON.stringify({ device_ids: [id] })
    )
  }
}

import { Device } from "../models/Device"
import { PlaybackState } from "../models/PlaybackState"
import { Track } from "../models/Track"
import errorResponse from "../util/errorResponse"
import response from "../util/response"

export default function statusRoutes(app, client) {
  app.get("/connect", async (req, res) => {
    if (client.readyForCalls) {
      res.send(response("Connected."))
    } else {
      if (client.hasRefreshToken) {
        try {
          await client.getRefreshToken()
        } catch (e) {
          console.error(e)
        }
      }
      res.send(
        client.isAuthenticated
          ? response("Connected.")
          : response(
              "Unauthenticated. Server requires login",
              null,
              "Server is missing a token or it has expired. Please log in again on the server"
            )
      )
    }
  })

  app.get("/deviceList", async (req, res) => {
    try {
      const deviceList = await client.getDeviceList()
      console.log("200 - /deviceList    - Retrieved device list")
      res.send(
        response(
          undefined,
          deviceList?.map(
            (device) => ({ name: device.name, id: device.id } as Device)
          )
        )
      )
    } catch (e) {
      console.error(e)
      res.status(500).send(errorResponse(e))
    }
  })

  app.get("/playbackState", async (req, res) => {
    try {
      const playbackState = await client.getPlaybackState()
      const {
        active,
        device,
        repeat_state,
        shuffle_state,
        progress_ms,
        is_playing,
        item,
        context,
      } = playbackState
      let clientState: Partial<PlaybackState> = {
        active,
        currentDevice: device
          ? new Device(device?.id, device?.name)
          : undefined,
        repeatState: repeat_state,
        shuffleState: shuffle_state,
        progress: progress_ms ? progress_ms / 1000 : undefined,
        playing: is_playing,
        context: context?.uri ?? undefined,
        nowPlaying: item
          ? new Track(
              item?.name,
              item?.artists[0].name,
              item?.album?.name,
              item?.duration_ms ? item.duration_ms / 1000 : 0,
              item?.album?.images[0]?.url,
              item?.album?.id,
              item?.id
            )
          : undefined,
      }
      console.log("200 - /playbackState - Retrieved playback state")
      res.send(response(undefined, clientState))
    } catch (e) {
      console.error(e)
      res.send(errorResponse(e))
    }
  })

  app.get("/albumArt", async (req, res) => {
    const url = req.query.url
    try {
      const data = await client.getAlbumArt(url?.toString())
      console.log("200 - /albumArt      - Retrieved album art")
      res.send(response(undefined, data))
    } catch (e) {
      console.error(e)
      res.send(errorResponse(e))
    }
  })

  app.get("/queue", async (req, res) => {
    try {
      const data = await client.getQueue()
      console.log("200 - /queue         - Retrieved playback queue")
      const queue = data.map((item) => {
        return item
          ? new Track(
              item?.name,
              item?.artists[0].name,
              item?.album?.name,
              item?.duration_ms ? item.duration_ms / 1000 : 0,
              item?.album?.images[0]?.url,
              item?.album?.id,
              item?.id
            )
          : {}
      })
      res.send(response(undefined, queue))
    } catch (e) {
      console.error(e)
      res.send(errorResponse(e))
    }
  })
}

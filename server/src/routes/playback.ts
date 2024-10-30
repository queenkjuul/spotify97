import { Express } from "express"
import SpotifyClient from "../client/SpotifyClient"
import errorResponse from "../util/errorResponse"
import response from "../util/response"

async function playbackResponse(
  res,
  func: (id: string, args?) => Promise<Optional<number>>,
  id: string,
  args: Array<string | number> = [],
  body?: BodyInit | undefined | null
) {
  try {
    const status = await func(id, ...args, body)
    if (!status || status > 399) {
      throw new Error("Bad response when changing playback state")
    }
    console.log("200 - Playback state change successful")
  } catch (e) {
    console.error(e)
    // errors are common with playback buttons, don't pass back to client
  }
  res.status(200).send(response())
}

// playback controls
export function playbackRoutes(app: Express, client: SpotifyClient) {
  app.get("/play", async (req, res) => {
    const id = req.query.device!
    const track = req.query.track
    const context = req.query.context
    const offsetUri = req.query.offsetUri
    const position = req.query.position
    const tracks = req.query.tracks

    if (tracks && track) {
      playbackResponse(
        res,
        client.play,
        id?.toString(),
        [],
        JSON.stringify({
          uris: [...tracks.toString().split(",")],
          offset: {
            uri: track.toString(),
          },
          position_ms: Number.parseInt(position?.toString() ?? "") * 1000,
        })
      )
    } else if (track && !context) {
      // we have a song to play all on its own
      playbackResponse(
        res,
        client.play,
        id?.toString(),
        [],
        JSON.stringify({
          uris: [track],
          ...(position
            ? { position_ms: Number.parseInt(position.toString()) * 1000 }
            : {}),
        })
      )
    } else if (context && !track) {
      // we have an album and/or playlist to play
      playbackResponse(
        res,
        client.play,
        id?.toString(),
        [],
        JSON.stringify({
          context_uri: context,
          offset: {
            ...(offsetUri ? { uri: offsetUri } : {}),
            ...(position ? { position: position } : 0),
          },
        })
      )
    } else if (context && track) {
      // we an album/playlist and a track,
      // we want to play the album starting at the position of the track
      playbackResponse(
        res,
        client.play,
        id?.toString(),
        [],
        JSON.stringify({
          context_uri: context,
          offset: {
            uri: track,
          },
          position_ms: Number.parseInt(position?.toString() ?? "") * 1000,
        })
      )
    } else {
      playbackResponse(res, client.play, id?.toString())
    }
  })
  app.get("/pause", (req, res) => {
    const id = req.query.device!
    playbackResponse(res, client.pause, id?.toString())
  })
  app.get("/next", (req, res) => {
    const id = req.query.device!
    playbackResponse(res, client.next, id?.toString())
  })
  app.get("/prev", (req, res) => {
    const id = req.query.device!
    playbackResponse(res, client.prev, id?.toString())
  })
  app.get("/seek", (req, res) => {
    const id = req.query.device
    const position = req.query.position
    if (!id || !position) {
      res
        .status(400)
        .send(
          errorResponse(new Error("Missing device and/or position parameters"))
        )
      return
    }
    const seconds = Number.parseInt(position?.toString())
    const millis = seconds * 1000
    playbackResponse(res, client.seek, id?.toString(), [millis])
  })
  app.get("/shuffle", (req, res) => {
    // mysteriously we get BAD URI from Spotify no matter what device we specify
    // they're not the best at updating their API docs, see the /transfer red herring I haven't cleaned up yet
    const id = ""
    const state = req.query.state!
    playbackResponse(res, client.shuffle, id, [state?.toString()])
  })
  app.get("/repeat", (req, res) => {
    const id = req.query.device!
    const mode = req.query.mode!
    playbackResponse(res, client.repeat, id?.toString(), [mode?.toString()])
  })
  app.get("/transfer", (req, res) => {
    const id = req.query.device!
    playbackResponse(res, client.transfer, id?.toString())
  })
}

import dotenv from "dotenv"
import express, { Express } from "express"
import { readFileSync } from "fs"
import SpotifyClient from "./client/SpotifyClient"
import loginRoutes from "./routes/login"
import { playbackRoutes } from "./routes/playback"
import searchRoutes from "./routes/search"
import statusRoutes from "./routes/status"
import errorResponse from "./util/errorResponse"

dotenv.config()

let savedState = {
  authToken: undefined,
  tokenExpiration: undefined,
  refreshToken: undefined,
}

try {
  const stateFile = readFileSync("state.json")
  savedState = JSON.parse(stateFile.toString())
  console.log("Loaded saved state from file")
} catch (e) {
  console.error("Error restoring state, will need to log in")
}

const app: Express = express()
const port = process.env.PORT ?? 3000
const client: SpotifyClient = new SpotifyClient(
  savedState.authToken,
  savedState.tokenExpiration,
  savedState.refreshToken
)

// login, redirect - only for initial browser OAuth
loginRoutes(app, client)

searchRoutes(app, client)

statusRoutes(app, client)

playbackRoutes(app, client)

app.use((req, res, next) => {
  res.status(404).send(errorResponse("Route not found - invalid endpoint"))
})

// hit it
app.listen(port, () => {
  console.log(`Spotify(R) Client 97 Relay Server listening on port ${port}`)
  if (!client.readyForLogin) {
    console.log(
      "Configuration error! Client ID or Redirect URI missing. Check .env or environment variables"
    )
    process.exit()
  } else if (!client.readyForCalls) {
    console.log(
      `Please log in: ${client.redirect.replace("redirect", "login")}`
    )
  }
})

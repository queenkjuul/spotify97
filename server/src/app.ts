import dotenv from "dotenv"
import express, { Express } from "express"
import { readFileSync } from "fs"
import SpotifyClient from "./client/SpotifyClient"
import loginRoutes from "./routes/login"
import { playbackRoutes } from "./routes/playback"
import searchRoutes from "./routes/search"
import statusRoutes from "./routes/status"
import errorResponse from "./util/errorResponse"
import ipAddresses, { getIpText } from "./util/ipAddress"
import { version } from "./util/version"

dotenv.config()

let savedState = {
  authToken: undefined,
  tokenExpiration: undefined,
  refreshToken: undefined,
}

console.log("Spotify(R) 97 Relay Server")
console.log("Version " + version + " Initializing...")

try {
  const stateFile = readFileSync("state.json")
  savedState = JSON.parse(stateFile.toString())
  console.log("Saved login found.")
} catch (e) {
  console.error("Not logged in. Please follow instructions to log in.")
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
  console.log(`Relay Server listening on port ${port}`)
  if (!client.readyForLogin) {
    console.log(
      "Configuration error! Client ID or Redirect URI missing. Check .env file or set your environment variables"
    )
    process.exit()
  } else if (!client.readyForCalls) {
    console.log(
      `Please log in with this link: ${client.redirect.replace(
        "redirect",
        "login"
      )}`
    )
  } else {
    console.log()
    console.log(getIpText(ipAddresses()))
  }
})

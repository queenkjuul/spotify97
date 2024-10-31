import ipAddresses from "../util/ipAddress"

export default function loginRoutes(app, client) {
  // LOGIN ENDPOINTS - Accessed via browser, not via client
  let state: Optional<string> // must be returned in auth server response for login only
  app.get("/login", (req, res) => {
    if (!client.readyForLogin) {
      res.status(500).send("Error: Server not properly configured!")
      return
    }

    state = crypto.randomUUID()
    const params = new URLSearchParams()
    params.append("response_type", "code")
    params.append("client_id", client.clientId)
    params.append("scope", client.scope)
    params.append("redirect_uri", client.redirect)
    params.append("state", state)

    res.redirect("https://accounts.spotify.com/authorize?" + params.toString())
  })

  app.get("/redirect", async (req, res) => {
    const code = req.query?.code
    const reqstate = req.query?.state
    const error = req.query?.error
    const addresses = ipAddresses()

    // state mismatch - probably called without hitting /login first
    if (reqstate !== state || !reqstate || !state) {
      console.error("state mismatch!")
      res
        .status(400)
        .send(
          "ERROR: Magic number mismatch. Check your connection and restart the login process."
        )
    }
    // error in response from spotify
    else if (error) {
      console.error(error)
      res.status(400).send("Upstream error: " + JSON.stringify(error))
    }
    // looks good, proceed to acquire token
    else if (code) {
      try {
        await client.acquireToken(code.toString())

        const text = `${
          addresses
            ? `Enter the server URL and port in your client. If you are unsure, it is probably:\n ${addresses.map(
                (addr, i) =>
                  `${i !== 0 ? " or " : ""}http://${addr}:${
                    process.env.PORT
                  } \n`
              )}`
            : ""
        }`

        if (addresses) {
          console.log()
          console.log(text)
        }

        res.send(`<html><h1>Auth Success!</h1><br /> 
        Double check your terminal to confirm it says logged in.<br /> 
        ${text}<br />
        You can close this window.</html>`)
        console.log("Login success!")
      } catch (e) {
        console.error(e)
        res.send("Error acquiring token: " + e)
      }
    }
    state = undefined
  })
}

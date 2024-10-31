# Spotify 97 Relay Server

## Setup

{:.tree-view}
- [Spotify 97 Relay Server](#spotify-97-relay-server)
  - [Setup](#setup)
    - [Windows](#windows)
    - [Linux + Mac](#linux--mac)
    - [Docker](#docker)
  - [Development](#development)
    - [Dev Environment Setup](#dev-environment-setup)
      - [Building the server for Windows](#building-the-server-for-windows)
        - [Prerequisites](#prerequisites)
        - [Process](#process)
    - [Further Development](#further-development)
  - [API](#api)

### Windows

*Only tested on Windows 10/11 x64.*

1. Download the `SpotifyClient97Server-win-x64.zip` from [Github](https://github.com/queenkjuul/spotify97/releases/latest)
2. Extract the ZIP
3. Edit `.env` with your application information
4. Run `SpotifyClient97Server.exe`
5. Allow connections in the Windows Firewall prompt.
6. Follow the login link and log in to Spotify.
7. [Set up the client](#set-up-the-client)

If you do not complete Step 3, the app will launch and instantly close

### Linux + Mac

*Linux builds are provided as x64 and arm64 only. arm64 is untested. For other platforms, use Docker or follow the Development instructions.*

1. Download the appropriate Server ZIP from [Github](https://github.com/queenkjuul/spotify97/releases/latest)
2. Extract the ZIP
3. Edit `.env` with your application information
4. Open a terminal in the unzipped directory
5. run `./spotifyclient97server`
6. Follow the login link and log in to Spotify.
7. [Set up the client](#set-up-the-client)

*Mac builds are as-yet-untested. My understanding is that macOS will not run unsigned code under any circumstances. I have attempted to self-sign my binaries, but I have no way to test if this works. Please open an [Issue](https://github.com/queenkjuul/spotify97/issues), use [Docker](#docker), or run Node natively using the [Development](#development) instructions, running `npm run serve` instead of `npm run dev`. You can install NVM using [`homembrew`](https://brew.sh/).*

### Docker

Clone the repo and open a terminal in the `/server` directory (you need to have Node and NPM installed first, see dev setup below)

```bash
npm ci
npm run build:docker
docker run -it --rm \
  -e SPOTIFY_CLIENT_ID=yourspotifyclientid \
  -e SPOTIFY_CLIENT_SECRET=yourspotifyclientsecret \
  -e REDIRECT=yourspotifyredirecturi \
  # port is optional
  -e PORT=3000 \
  spotifyclient97
```

## Development

### Dev Environment Setup

To run the server locally in dev mode:

1. [Install Node](https://nodejs.org/en/download/prebuilt-installer/current). Check this repo's `.nvmrc` for my exact version, but latest is probably fine
2. Clone this repo, or download and extract the .zip file
3. Open a terminal in the `spotifyclient97/server` directory
4. run `cp .env.example .env`
5. Edit `.env` to suit
6. run `npm i`
7. run `npm run dev`
8. You should see `Spotify(R) Client 97 Relay Server is listening on port 3000` in the terminal.

You'll need to log in like normal. Then, Nodemon will auto-reload the app when you make changes in your editor.

#### Building the server for Windows

Can not be done on Linux or Mac. Process fails if reading the source from a network share. Clone the repo to a local disk on the Windows machine.

##### Prerequisites

Recommended to use [`nvm-windows`](https://github.com/coreybutler/nvm-windows?tab=readme-ov-file#installation--upgrades) which requires you to use PowerShell.

##### Process

In PowerShell from the /server directory of the repo:

```powershell
nvm install $(cat .nvmrc)
nvm use $(cat .nvmrc)
npm ci
npm run build:windows
cd dist/win
# edit .env with your spotify keys
.\SpotifyClient97Server.exe
```

### Further Development

While this server was built specifically to suit this particular frontend, there's no reason it couldn't be used as a proxy for other retro-compatible Spotify frontends. Windows Mobile 6 is an easy candidate as it can reuse the frontend models, but any device that can make HTTP GET requests and parse JSON is theoretically compatible. Ancient systems with less than a few MB of RAM will probably be ruled out, though, because deserializing a multi-KB JSON payload is probably out of their reach.

Fundamentally, this server exists to solve one insurmountable problem: retro computers cannot make HTTPS requests. But this server does slightly more than just proxy requests between the client and Spotify.

1. Make HTTPS requests on behalf of retro clients
2. Convert all requests to `GET` - So far, vintage HTTP libraries are much simpler to use with just `GET`. Data passed forward can be encoded in URL query params, rather than serializing data on the vintage machine which can be cumbersome. Spotify API requires `PATCH`, `PUT`, and `POST` for various functions, but the UI is almost never providing much more than a couple parameters, usually just device ID. So it's quite simple to send them as URL params instead of serialized request bodies.
3. Filter, reduce, and flatten data retrieved from Spotify:
   1. Filtering is drastically easier in JS/TS than VB
   2. Reduce total data transmitted rather than retransmit entire Spotify data objects. For example, a Spotify `Track` object contains lots data that is not for display, such as URLs to external sites or images, UPC and catalog numbers, what countries the track is available in, etc. We strip all this out and only transmit the properties we strictly require for the UI.
   3. VB has nice provisions for data binding, but it chokes on multi-layer data. Nested objects in the incoming data make UI binding way more difficult. So instead of JSON like this:

   ```json
   {
    "track": {
      "name": "track",
      "duration": 1234,
      "id": "lwwlkejlkjflkjs",
      "album": {
        "name": "album",
        "id": "asadlfkjalsdkfjlskd",
        "art": [
          "https://artwork1.png",
          "https://artwork2.png",
        ],
        "year": 2002,
      },
      "artist": {
        "name": "artist",
        "id": "sldksfjlskdjf",
        "about": "Wesley Willis is from Chicago, IL..."
      }
    }
   }
   ```

    we flatten it down to something like this:

   ```js
   {
    track: {
      name,
      id,
      duration,
      artistName,
      artistId,
      artistAbout,
      albumName,
      albumId,
      albumArtHref
    }
   }
   ```

     We keep most of the data, we just put everything we want at the top level

## API

It should be very easy to use this to build a similar frontend for any other platform. All you need to do is be able to make HTTP GET requests, and parse JSON. The [Charcoal Design's JSON Dictionary](http://www.charcoaldesign.co.uk/source/realbasic) used in the [Mac client](../client/Spotify97MacEdition/README.md) provides a great template for building a simple JSON parser.

All client side data is sent via URL query parameters.

All data is returned in JSON format, wrapped in a [`ClientResponse`](./src/models/ClientResponse.ts) object. Typically, upstream HTTP errors are returned to the client in a "good" `200 - OK` response, but containing an `error` message within the response. There are common errors we typically want to ignore (like hitting Next when at the end of a playlist, or sending a `play` request to a device which is already playing). Responding with an actual HTTP error code may trigger automatic error handling in client libraries which we want to avoid.

A `ClientResponse` has three properties:

```json
{
  "message": "string",  // Arbitrary. Typically OK or Error but may include more info
  "data": "json",       // can be just JSON of an empty object {}
  "error": "string | undefined"     // Error message reported from the server. If string is present, an error has occurred
}
```

- `/login`
  - Access via browser to initiate the Spotify login process
- `/redirect`
  - Provide full URL to Spotify dev page as redirect URL
- `/search`
  - Supports Tracks, Albums, and Playlists
  - Params:
    - `q`: search query
    - `type`: array of types (defaults to `track,album,playlist`)
  - Returns:

    ```json
    {
      tracks?: Array<Track>,
      albums?: Array<Album>,
      playlists?: Array<Playlist>
    }
    ```

    *see: [Track](./src/models/Track.ts), [Album](./src/models/Album.ts), [Playlist](./src/models/Playlist.ts)*

- `/connect`
  - Verifies server is ready to operate, triggers token refresh if necessary.
- `/deviceList`
  - Returns list of available devices
  
    ```json
    [
      {
        name,
        id
      }
    ]
    ```

    *see [Device](./src/models/Device.ts)*

- `/playbackState`
  - Provides the full now-playing playback state. This includes currently playing track, currently playing "context" (ID of the active queue/playlist/album), shuffle and repeat status, etc.
  - Returns a [PlaybackState](./src/models/PlaybackState.ts) object
  *see [Device](./src/models/Device.ts), [Track](./src/models/Track.ts)*
- `/albumArt`
  - Returns album art within a standard ClientResponse as a base64-encoded string
  - Params:
    - `url`: Must be URL-encoded. Full URL to an image file (usually the AlbumArt property of a Track)
- `/albumArtFile`
  - **Does NOT return a `ClientResponse`!**
  - Provides a direct `download` response to a JPEG file of the provided image URL
  - File is always named `albumart.jpg`
  - Params:
    - `url`: Must be URL-encoded. Full URL to an image file (usually the AlbumArt property of a Track)
    - `width`: optional. JPEG can be resized before download. Defaults to 175px
    - `height`: optional. JPEG can be resized before download. Defaults to 175px
- `/queue`
  - Get the currently playing queue
  - Returns an array of [Track](./src/models/Track.ts) objects
- `/recent`
  - Get recently played tracks
  - Returns an array of `RecentlyPlayed` objects, which contain a `Track` and a `context` URI
    *see [RecentlyPlayed](./src/models/RecentlyPlayed.ts), [Track](./src/models/Track.ts)*
- `/playlists`
  - Get current user's playlists
  - Returns an array of [`Playlist`](./src/models/Playlist.ts) objects
- `/play`
  - Start playback on the specified device.
  - If device is active, continues playing current queue from previous position.
  - If Track is specified alone, replaces device queue with current track.
    - If `position` is provided, Track will begin playing the specified number of seconds from the beginning of the track.
  - If Track and Context are provided, sets device queue to provided Context and starts playing the Context from the specified track (if Track is the third track in a playlist, and the playlist is provided as context, the playlist will start playing from track 3).
  - If a Context is provided alone, the device queue is replaced with the provided context, and playback starts from the first track.
  - Params:
    - `device`: Required. Spotify device ID code for target device
    - `track`: Optional. Full Spotify Track URI for the track you want to play
    - `position`: Optional. Depends on `track`. Number of seconds from the start of the track from which to start playback. Defaults to 0
    - `context`: Optional. Full Spotify URI to a "context" which can be a Playlist or an Album
    - `offsetUri`: Optional. Depends on `context`. Full Spotify URI to a Track within the provided Context. Playback of the context will begin at the specified Track. Defaults to the provided `track` or the first track in the context.
- `/pause`
  - Pause playback on the specified device
  - Params:
    - `device`: Required. Spotify device ID code for target device
- `/next`
  - Advance playback to next track in the queue on the specified device
  - Params:
    - `device`: Required. Spotify device ID code for target device
- `/prev`
  - Go back to the previous track in the queue on the specicied device.
  - Params:
    - `device`: Required. Spotify device ID code for target device
- `/seek`
  - Seek playback of the current track to the specified position
  - Params:
    - `device`: Required. Spotify device ID code for target device
    - `position`: Required. Position to seek to, provided as seconds from start of the track
- `/shuffle`
  - Toggle shuffle state on or off
  - Params:
    - `device`: Required. Spotify device ID code for target device
    - `state`: Required. Must be either `true` or `false`
- `/repeat`
  - Change repeat setting to the specified mode.
  - Params:
    - `device`: Required. Spotify device ID code for target device
    - `mode`: Required. Must be one of `off`, `track`, or `context`
- `/transfer`
  - Corresponds to the Spotify API Transfer Playback endpoint, which is poorly documented and does not seem to work. Instead, use the `/play` endpoint and provide `device`, `track`, `context`, and `position` which will provide near-seamless transfer of playback to the new device.
  
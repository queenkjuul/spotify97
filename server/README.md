# SpotifyClient97Server

While this server was built specifically to suit this particular frontend, there's no reason it couldn't be used as a proxy for other retro-compatible Spotify frontends. Windows Mobile 6 is an easy candidate as it can reuse the frontend models, but any device that can make HTTP GET requests and parse JSON is theoretically compatible. Ancient systems with less than a few MB of RAM will probably be ruled out, though, because deserializing a multi-KB JSON payload is probably out of their reach.

Fundamentally, this server exists to solve one insurmountable problem: retro computers cannot make HTTPS requests. But this server does slightly more than just proxy requests between the client and Spotify.

1. Make HTTPS requests on behalf of retro clients
2. Convert all requests to `GET` - In VB.net, we use the `WebClient` class, which while capable of both `GET` and `POST`, is drastically simpler to use with just `GET`. Data passed forward can be encoded in URL query params, rather than serializing data on the vintage machine which can be cumbersome. Spotify API requires `PATCH`, `PUT`, and `POST` for various functions, but the UI is almost never providing much more than a handful of parameters, usually just device ID. So it's quite simple to send them as URL params instead of serialized request bodies.
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

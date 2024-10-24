# Spotify(R) Client 97

A Spotify Connect remote-control frontend for Windows 95 and up. Requires Spotify Premium. Does not stream audio, only remote-controls other spotify devices.

![Spotify Connect logo](client/SpotifyClient97/Images/SpotifySplash.png)

![Screenshot of Spotify Client 97 running on Windows 98](./screenshot98.png)

![Screenshot of Spotify Client 97 running on Windows XP](/screenshotXP.png)

We've all been there: you're hard at work on your 98SE rig, your phone is in the other room, and Spotify sMaRt sHuFfLe plays a track that makes you want to pull your hair out. So you have to get up, find your phone, and tell it to play something else.

Well, the gentle laborer shall no longer suffer. With only some mildly complicated custom client-server infrastructure, Spotify(R) Client 97 allows you to control your Spotify Connect playback endpoints from the comfort of Windows 98. In theory, with [MattKC's .NET 2.0 port](https://github.com/itsmattkc/dotnet9x) the client will even run on Windows 95, though this has not been tested.

- [Spotify(R) Client 97](#spotifyr-client-97)
  - [Why](#why)
  - [What](#what)
  - [How](#how)
  - [How (to)](#how-to)
    - [Step 1 - Get Spotify app credentials](#step-1---get-spotify-app-credentials)
    - [Step 2 - Set up the Relay Server](#step-2---set-up-the-relay-server)
      - [Windows](#windows)
      - [Linux + Mac](#linux--mac)
      - [Docker](#docker)
    - [Set up the client](#set-up-the-client)
      - [Step 1: Install .NET](#step-1-install-net)
      - [Step 2: Install Client Application](#step-2-install-client-application)
        - [Option 1: Fully Automatic Online Installation](#option-1-fully-automatic-online-installation)
        - [Option 2: Portable Standalone Binary](#option-2-portable-standalone-binary)
      - [Step 3: Configure the client](#step-3-configure-the-client)
  - [Stretch goals](#stretch-goals)
  - [Development](#development)
    - [Server](#server)
      - [Building the server for Windows](#building-the-server-for-windows)
        - [Prerequisites](#prerequisites)
        - [Process](#process)
    - [Client](#client)


## Why

Someone had to do it, obviously.

## What

This app DOES NOT stream any audio! This is only a UI you can use to remote control your other Spotify instances and Spotify Connect devices.

## How

Spotify(R) Client 97 consists of two components:

1. Relay Server
   - The Relay Server is a node.js app written in TypeScript which must be run on a 'modern' computer; that is to say, one new enough to be able to run a recent version of Node and make HTTPS requests to the Spotify API. Typically this is just the computer running Spotify that you want to remote control.
2. Client Application
   - The Client Application is a native Windows Forms application written in VB.NET and utilizing .NET Framework 2.0. The client is a frontend for the Relay Server: you click Play in the Client, it sends a Play message to the Relay Server, the Relay Server calls the Spotify Connect API and tells it to start playing on the specified device.

## How (to)

### Step 1 - Get Spotify app credentials

[Follow the Spotify developer instructions to create an app](https://developer.spotify.com/documentation/web-api/tutorials/getting-started#create-an-app). You will need to copy the "Client ID" and "Client Secret" values into your `.env` file, see server setup instructions.

**IMPORTANT:** The `redirect_uri` setting is very important. It must match *exactly* the URL you will use to access the server.

The default for this app is:

`http://localhost:3000/redirect`

If you change the port in the `.env` file, map ports using Docker, or are running the server remotely (e.g. over SSH) then you will need to replace the address and port as necessary to match your settings.

**Because this application is entirely unsecured, you should **NOT** run it in the cloud, and should not expose the port to the internet. Do not use a public IP with this server, only run this on your LAN**

### Step 2 - Set up the Relay Server

#### Windows

*Only tested on Windows 10/11 x64.*

1. Download the `SpotifyClient97Server-win-x64.zip` from [Github](https://github.com/queenkjuul/spotifyclient97/releases/latest)
2. Extract the ZIP
3. Edit `.env` with your application information
4. Run `SpotifyClient97Server.exe`
5. Allow connections in the Windows Firewall prompt.
6. Follow the login link and log in to Spotify.
7. [Set up the client](#set-up-the-client)

If you do not complete Step 3, the app will launch and instantly close

#### Linux + Mac

*Linux builds are provided as x64 and arm64 only. arm64 is untested. For other platforms, use Docker or follow the Development instructions.*

1. Download the appropriate Server ZIP from [Github](https://github.com/queenkjuul/spotifyclient97/releases/latest)
2. Extract the ZIP
3. Edit `.env` with your application information
4. Open a terminal in the unzipped directory
5. run `./spotifyclient97server`
6. Follow the login link and log in to Spotify.
7. [Set up the client](#set-up-the-client)

*Mac builds are as-yet-untested. My understanding is that macOS will not run unsigned code under any circumstances. I have attempted to self-sign my binaries, but I have no way to test if this works. Please open an [Issue](https://github.com/queenkjuul/spotifyclient97/issues), use [Docker](#docker), or run Node natively using the [Development](#development) instructions, running `npm run serve` instead of `npm run dev`. You can install NVM using [`homembrew`](https://brew.sh/).*

#### Docker

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

### Set up the client

The client is whatever computer you want to use to control your Spotify stream. This can be any Windows PC running at least Windows 95, and which has an active network connection on the same network / LAN / WiFi as the Relay Server

#### Step 1: Install .NET

Install .NET Framework 2.0 (or for Windows 95/98, use [MattKC's dotnet9x](https://github.com/itsmattkc/dotnet9x))

#### Step 2: Install Client Application

##### Option 1: Fully Automatic Online Installation

If your retro PC is connected to the internet, and is running Internet Explorer 5.5+, and has .NET 2.0 installed, you can install the app in "one click" here:

[http://retro.queenkjuul.xyz/spotifyclient97/publish.htm](http://retro.queenkjuul.xyz/spotifyclient97/publish.htm)

This method enables automatic updates, and installs a shortcut in your start menu to access the app

##### Option 2: Portable Standalone Binary

Download `SpotifyClient97Client-win32.zip` from the [Github Releases](https://github.com/queenkjuul/spotifyclient97/releases/latest) page and unzip it
3. Run `Spotify Client 97.exe`

#### Step 3: Configure the client

On initial run, the app will prompt you to set the Relay Server URL. Once this is defined, the app will restart. You may get a Windows security warning here, just proceed.

Double click a device in the Available Devices list to select it. Select an item to play via the Search box, or hit Play to load that device's existing queue (if it exists).

## Stretch goals

1. Keyboard Shortcuts
2. replace queue with tabbed layout to access recently played, maybe also playlists and saved tracks
3. Localization and accessibility
4. Modularize and clean up MainForm code
5. Grab and show recommended tracks and playlists
6. additional API features - track saving, artist info, lyrics
7. Extract SpotifyController and dependencies into a class library, build a Windows Mobile 6 frontend
8. ~~ClickOnce automatic updates (will need to set up HTTP retro access to a subdomain of queenkjuul.com first)~~ Done!
9. Marquee scrolling overflow on now playing texts
10. Additional preferences: add items to queue instead of immediately play, minimize to tray
11. ~~System tray icon~~ done :P
12. Rewrite in C#

## Development

### Server

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

### Client

The client is built in Visual Basic 2005 Express Edition. Downloads can be found online, but it is not supported in later versions of Windows. I use XP for development. Later editions of Visual Studio no longer support building installers for Windows 98, but you may be able to target .NET 2.0 in later versions and run it with MattKC's .NET 2.0 for Windows 9x.

Newtonsoft.Json is required to parse messages from the server. The DLL is provided with the client source code.

# Spotify 97 Clients

Front end applications for use with the Spotify 97 Relay Server

Currently:

1. [Spotify Client 97](./SpotifyClient97): Windows client written in .NET 2.0 using Visual Basic 2005 Express Edition. Runs on 9x/Me/2k/XP, but needs [MattKC's .NET 2.0 port for Windows 95](https://github.com/mattkc/dotnet9x) (or Microsoft .NET 2.0 for the newer platforms). Uses [Newtonsoft JSON.NET](https://newtonsoft.com/json) for deserialization. Works quite well, with enough features to be useful.
2. [Spotify 97 Mac Edition](./Spotify97MacEdition): Mac client written in REALbasic 5.5. Tested on Mac OS 9.2 and OS X 10.4, but should work on 8.6-10.5. Requires QuickTime to display album art and may require OpenTransport on OS 8. Overall it is slower and buggier than the Windows client but for the moment it actually has more features. Uses [Charcoal Design's JSON Dictionary](http://www.charcoaldesign.co.uk/source/realbasic) package, backported to RB 5.5.

Planned:

1. Spotify 97 for Windows Mobile: Windows Mobile 6 client written in .NET 2.0 using Visual Studio 2005 (or maybe 2008). Would like to rewrite the model and client classes in C#. VS2005 should be able to host the frontends in VB.NET and the library in C# within one solution. I've read VS2008 cannot target .NET 2.0 compatibly, though, and I'm also not sure about ClickOnce publishing from 2008. However, I've done WM6 work in VS2008 before, so I know it works, and I'm not certain the WM6 SDKs will work in 2005. So we'll see.

Considered:

2. Spotify for Macintosh: [there is already MacPlayer](https://github.com/antscode/MacPlayer) [also, gonna be real, RB is too painful for me to be excited about this, and I don't know how easy it will be to do HTTP/JSON in vintage kits like Turbo Pascal or whatnot, and idk how much I want to learn C++ UI programming.] Would love to get a build working on my LC II with its PDS Ethernet card, and MacPlay doesn't do color so there is a functionality gap here. REALbasic 3.5 can build 68k binaries, but it doesn't have a built-in HTTP client, and idk if a 68020 can deserialize 2KB of JSON in under 5 seconds, which is probably the minimum threshold for the current architecture. I've found an example of an HTTP client for RB 3.5 though. The JSON parser also seems to import into 3.5.2 ok, so I should be able to export my model+controller classes as well (well, except for the HTTPsocket part...). The hardest part is going to be finding a comfy OS 9 dev setup. Though given the app crashes unless I allocate it at least 4MB of RAM, we're gonna be pushing it on a 10MB LC II. Maybe a stripped-down version that only shows now playing info and provides play/pause/next/prev/seek is in order.

Dreamt:

1. Spotify for MS-DOS: MTCP probably makes it very easy to interact with the Relay Server. Everything else probably sucks, though. Actually, this might be pretty practical using [DOjs](https://github.com/SuperIlu/DOjS). I'm interested. A play/pause/next/prev TSR would be awesome but probably requires serious programming that I can't do (like B or D+ or one of those such languages).

Fever Dreamedt:

4. Tandy CoCo over serial, Commodore 64 over WIC64

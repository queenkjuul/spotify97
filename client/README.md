# SpotifyClient97Client

Front end applications for use with the SpotifyClient97 Relay Server

Currently:

1. [SpotifyClient97](./SpotifyClient97/README.md): Windows client written in .NET 2.0 using Visual Basic 2005 Express Edition. Runs on 9x/Me/2k/XP, but needs [MattKC's .NET 2.0 port for Windows 95](https://github.com/mattkc/dotnet9x) (or Microsoft .NET 2.0 for the newer platforms). Uses [Newtonsoft JSON.NET](https://newtonsoft.com/json) for deserialization. Works quite well, with enough features to be useful.
2. [WIP] [SpotifyForMac](./SpotifyForMac/README.md): Mac client written in REALbasic 5.5. Tested on Mac OS 9.2 and OS X 10.4, but should work on 8.5-10.5. Uses [Charcoal Design's JSON Dictionary](http://www.charcoaldesign.co.uk/source/realbasic) package, but backported to RB 5.5. Developed primarily on Windows XP using REALbasic 5.5.3, but most UI work done in REALbasic 5.5.5 for OS 9/10.4.

Planned:

1. SpotifyClient97Mobile: Windows Mobile 6 client written in .NET 2.0 using Visual Studio 2005 (or maybe 2008). Would like to rewrite the base model and client classes in C#. VS2005 should be able to host a the frontends in VB.NET and the library in C# within one solution. I've read VS2008 cannot target .NET 2.0 compatibly, though, and I'm also not sure about ClickOnce publishing from 2008. However, I've done WM6 work in VS2008 before, so I know it works, and I'm not certain the WM6 SDKs will work in 2005. So we'll see.
2. Spotify for 68k Macs: Would love to get a build working on my LC II with its PDS Ethernet card. I think REALbasic 3.5 can build 68k binaries, but I don't know if it has an HTTP client, or if a 68020 can deserialize 2KB of JSON in under 5 seconds, which is probably the minimum threshold for the current architecture.

## But queenkjuul, if REALbasic can build for Mac OS, OS X, GTK2, and  Windows 9x, why not just use that for everything?

1. It honestly kinda sucks. VB.NET has its problems, but REALbasic is a bit painful to use. Using the GUI is even less optional than it is in VB.NET. There's some archaic and strange syntax rules, like you can't declare a variable within a for loop expression, and even worse, you can't even define a local variable within a conditional or recursive block. Basically, all your variables have to be defined at the top level of your class or function. This is a big pain. Also you can't declare and initialize a variable on the same line. You do a lot of this:

   ```vb
   dim i as integer
   i = 0
   ```

2. .NET honestly kinda rocks. I can define reactive data bindings, and the UI just updates whenever I reassign values in the backing state object. The app has a single source of truth, and the UI updates itself to match it automatically. This means writing a lot less code, with much less chance of states getting out of sync, that's really really easy to extend with more functionality.

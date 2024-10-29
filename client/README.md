# Spotify 97 Clients

Front end applications for use with the Spotify 97 Relay Server

Currently:

1. [SpotifyClient97](./SpotifyClient97/README.md): Windows client written in .NET 2.0 using Visual Basic 2005 Express Edition. Runs on 9x/Me/2k/XP, but needs [MattKC's .NET 2.0 port for Windows 95](https://github.com/mattkc/dotnet9x) (or Microsoft .NET 2.0 for the newer platforms). Uses [Newtonsoft JSON.NET](https://newtonsoft.com/json) for deserialization. Works quite well, with enough features to be useful.
2. [WIP] [Spotify97MacEdition](./Spotify97MacEdition/README.md): Mac client written in REALbasic 5.5. Tested on Mac OS 9.2 and OS X 10.4, but should work on 8.6-10.5. Uses [Charcoal Design's JSON Dictionary](http://www.charcoaldesign.co.uk/source/realbasic) package, but backported to RB 5.5. Developed primarily on Windows XP using REALbasic 5.5.3, but most UI work done in REALbasic 5.5.5 on OS 10.4. Requires QuickTime to display album art.

Planned:

1. Spotify 97 for Windows Mobile: Windows Mobile 6 client written in .NET 2.0 using Visual Studio 2005 (or maybe 2008). Would like to rewrite the model and client classes in C#. VS2005 should be able to host the frontends in VB.NET and the library in C# within one solution. I've read VS2008 cannot target .NET 2.0 compatibly, though, and I'm also not sure about ClickOnce publishing from 2008. However, I've done WM6 work in VS2008 before, so I know it works, and I'm not certain the WM6 SDKs will work in 2005. So we'll see.

Considered:

2. Spotify for Macintosh: Would love to get a build working on my LC II with its PDS Ethernet card. I think REALbasic 3.5 can build 68k binaries, but I don't know if it has an HTTP client, or if a 68020 can deserialize 2KB of JSON in under 5 seconds, which is probably the minimum threshold for the current architecture. REALbasic 3.5.2 does not have HTTPSocket, but it does have TCPSocket, and I've fonud an example of an HTTP client. The JSON parser also seems to import into 3.5.2 ok, so I should be able to export my model+controller classes as well (well, except for the HTTPsocket part...). The hardest part is going to be finding a comfy OS 9 dev setup.

Dreamt:

3. Spotify for MS-DOS: MTCP probably makes it very easy to interact with the Relay Server. Everything else probably sucks, though.

Fever Dreamedt:

4. Tandy CoCo over serial, Commodore 64 over WIC64

## But queenkjuul, if REALbasic can build for Mac OS, OS X, GTK, and  Windows 9x, why not just use that for everything?

1. It honestly kinda sucks. VB.NET has its problems, but REALbasic is a bit painful to use. Using the GUI is even less optional than it is in VB.NET. There's some archaic and strange syntax rules, like you can't declare a variable within a for loop expression, and even worse, you can't even define a local variable within a conditional or recursive block. Basically, all your variables have to be defined at the top level of your class or function. This is a big pain. Also you can't declare and initialize a variable on the same line. You do a lot of this:

   ```vb
   dim i as integer
   i = 0
   ```

2. .NET honestly kinda rocks. I can define reactive data bindings, and the UI just updates whenever I reassign values in the backing state object. The app has a single source of truth, and the UI updates itself to match it automatically. This means writing a lot less code, with much less chance of states getting out of sync, that's really really easy to extend with more functionality. Plus the .NET Application framework gives me persistent settings and automatic updates with basically zero effort.
3. Jack of all, master of none - REALbasic results in a pretty great looking Classic Mac UI, a pretty ok looking OS X UI, and a pretty bad Windows UI. Change it to look better on Windows, and it will look worse on Mac. So, separate codebases.
4. Open Source-iness - REALbasic stores projects and their files in a proprietary binary format. I'm exporting my modules as XML for the sake of being able to diff things and kinda sorta review PRs, but it's really not great for making the code easy to read.

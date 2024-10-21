Module UiStrings
    'FIXME: Localization?
    Public play = "Play"
    Public pause = "Pause"
    Public serverUndefinedError = "No Server URL defined, please specify one in Settings"
    Public missingServerError = "Missing Relay Server"
    Public lastServerResponse = "Last Server Response: "
    Public helpText1 = "Due to limitations in the Spotify API, the queue for a device cannot be retrieved when that device is not playing. This means when the app starts up, there will be nothing showing in the queue. You will need to play something from the search results or your library. Once something is playing the app state will fill in. The app prefers to hang on to outdated display info, so an extended pause (long enough for the Spotify API to stop listing a device as active) the app should retain the queue. The queue is always lost when the Spotify client is closed."
    Public helpText2 = "The currently selected device in the top left corner determines which device receives playback commands. Make sure you have the correct device selected before playing a track. You can change the active device by double-clicking its name in the AvailableDevices list."
    Public helpText3 = "While playing, the 'Switch' button in the Devices section will transfer playback to the device that is highlighted in the Available Devices list. It tries to do so seamlessly, but is usually off by a couple seconds."
    Public helpText4 = "Double-clicking items in the Search Results will send them to the currently selected device as shown in the top left corner. Albums will start from the beginning, whereas tracks will play immediately, followed by the subsequent tracks on its album"
    Public helpText5 = "Double-clicking items in the Queue will play them immediately."

    Public Function getConnStatusDict() As Dictionary(Of ConnStatus, String)
        Dim connStatusDict As New Dictionary(Of ConnStatus, String)
        connStatusDict.Add(ConnStatus.unknown, "Unknown State")
        connStatusDict.Add(ConnStatus.ready, "Ready.")
        connStatusDict.Add(ConnStatus.connecting, "Connecting...")
        connStatusDict.Add(ConnStatus.connected, "Connected.")
        connStatusDict.Add(ConnStatus.failed, "Failed!")
        Return connStatusDict
    End Function

    Public Function getPlayStatusDict() As Dictionary(Of Boolean, String)
        Dim playStatusDict As New Dictionary(Of Boolean, String)
        playStatusDict.Add(False, "Stopped.")
        playStatusDict.Add(True, "Playing...")
        'we may be able to deduce pause vs stop from other state values later
        'playStatusDict.Add(PlayStatus.paused, "Paused.")
        Return playStatusDict
    End Function
End Module

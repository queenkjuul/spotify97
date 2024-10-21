Imports System
Imports System.ComponentModel
Imports System.Net
Imports System.Text.Encoding
Imports Newtonsoft.Json

Public Class SpotifyController
    Public appState As New ApplicationState
    Public playbackState As New PlaybackState
    Private webClient As WebClient = New WebClient

    Public Sub connect()
        Dim response As ClientResponse(Of String)
        response = callRelayServer("/connect")
        If response.isError Then
            appState.connStatus = ConnStatus.failed
        Else
            appState.connStatus = ConnStatus.connected
        End If
    End Sub

    Public Sub getPlaybackState()
        Dim response As ClientResponse(Of PlaybackState)
        response = callRelayServer(Of PlaybackState)("/playbackState")
        Dim state As PlaybackState = response.data

        'When no active players, there is no further data in the repsonse object, so nothing to updatee
        If Not state IsNot Nothing AndAlso Not state.active Then
            Return
        End If

        'we save the previous device to try and catch it while it's still active, but it doesn't always work
        If state.currentDevice IsNot Nothing Then
            playbackState.currentDevice = state.currentDevice
            My.Settings.PrevDeviceId = state.currentDevice.id
            My.Settings.PrevDeviceName = state.currentDevice.name
            My.Settings.Save()
        End If

        If state.nowPlaying IsNot Nothing Then
            playbackState.nowPlaying = state.nowPlaying
        End If

        If state.progress.Equals(Nothing) Then
        Else
            playbackState.progress = state.progress
        End If

        If state.repeatState.Equals(Nothing) Then
        Else
            playbackState.repeatState = state.repeatState
        End If

        'always overwrite context
        playbackState.context = state.context
        'primitive boolean will not map to Nothing, null becomes False, this is safe for these particular properties
        playbackState.playing = state.playing
        playbackState.shuffleState = state.shuffleState
    End Sub

    Public Sub getDeviceList()
        Dim response As ClientResponse(Of BindingList(Of Device))
        response = callRelayServer(Of BindingList(Of Device))("/deviceList")
        Dim deviceList As BindingList(Of Device)
        deviceList = response.data
        appState.deviceList = deviceList
    End Sub

    Public Sub getAlbumArt()
        If playbackState Is Nothing Or playbackState.nowPlaying Is Nothing Then
            Return
        End If

        'naming is not great here - Track.albumArt is an href, ApplicationState.albumArt is an Image object
        Dim response As ClientResponse(Of String)
        response = callRelayServer("/albumArt?url=" + Me.playbackState.nowPlaying.albumArt)

        If response Is Nothing Or response.data Is Nothing Then
            Return
        End If

        Dim data As Byte() = System.Convert.FromBase64String(response.data)
        Dim stream As New System.IO.MemoryStream(data)
        Dim image As Image = System.Drawing.Image.FromStream(stream)
        appState.albumArt = image
    End Sub

    Public Sub getQueue()
        Dim response As ClientResponse(Of BindingList(Of Track))
        response = callRelayServer(Of BindingList(Of Track))("/queue")

        Dim currentQueue(appState.queue.Count) As Track
        If appState.queue IsNot Nothing Then
            appState.queue.CopyTo(currentQueue, 0)
        End If

        Dim incomingQueue(response.data.Count) As Track
        If response.data IsNot Nothing Then
            response.data.CopyTo(incomingQueue, 0)
        End If

        'updating queue resets queue scroll state, so avoid it if it's not necessary
        If Helpers.areQueuesEqual(currentQueue, incomingQueue) Then
        Else
            appState.queue = response.data
        End If
    End Sub

    Public Sub search(ByVal query As String)
        Dim response As ClientResponse(Of SearchResults)
        response = callRelayServer(Of SearchResults)("/search?q=" + query)
        appState.trackResults = response.data.tracks
        appState.albumResults = response.data.albums
    End Sub

    Public Sub playItem(ByVal track As String, ByVal context As String, Optional ByRef device As String = "", Optional ByVal position As Int16 = 0)
        device = IIf(device = "", Me.playbackState.currentDevice.id, device)
        Dim response As ClientResponse(Of String)
        response = callRelayServer("/play?device=" + device + "&track=" + track + "&context=" + context + "&position=" + position.ToString())
    End Sub

    Public Sub playPause()
        If Me.playbackState Is Nothing Or Me.playbackState.currentDevice Is Nothing Then
            Return
        End If
        Dim response As ClientResponse(Of String)
        If Me.playbackState.playing Then
            response = callRelayServer("/pause?device=" + Me.playbackState.currentDevice.id)
        Else
            response = callRelayServer("/play?device=" + Me.playbackState.currentDevice.id)
        End If
    End Sub

    Public Sub nextTrack()
        Dim response As ClientResponse(Of String)
        response = callRelayServer("/next?device=" + Me.playbackState.currentDevice.id)
    End Sub

    Public Sub prevTrack()
        Dim response As ClientResponse(Of String)
        response = callRelayServer("/prev?device=" + Me.playbackState.currentDevice.id)
    End Sub

    Public Sub seek(ByVal position)
        Dim response As ClientResponse(Of String)
        response = callRelayServer("/seek?device=" + Me.playbackState.currentDevice.id + "&position=" + position.ToString())
        playbackState.progress = position
    End Sub

    Public Sub setRepeat(ByVal state As RepeatState)
        If Me.playbackState.currentDevice IsNot Nothing Then
            Dim response As ClientResponse(Of String)
            response = callRelayServer("/repeat?device=" + Me.playbackState.currentDevice.id + "&mode=" + getRepeatMode(state))
        End If
        playbackState.repeatState = state
    End Sub

    Public Sub setShuffle(ByVal state As Boolean)
        If Me.playbackState.currentDevice IsNot Nothing Then
            Dim response As ClientResponse(Of String)
            response = callRelayServer("/shuffle?device=" + Me.playbackState.currentDevice.id + "&state=" + IIf(state, "true", "false"))
        End If
        playbackState.shuffleState = state
    End Sub

    Public Sub transfer(ByVal device As String)
        Dim response As ClientResponse(Of String)
        response = callRelayServer("/transfer?device=" + device)
    End Sub

    'in order, we expect response data to be Nothing, String, T
    'this covers all but case T
    Private Function callRelayServer(ByVal path)
        Return callRelayServer(Of String)(path)
    End Function
    'T is type of object to be deserialized from the response
    Private Function callRelayServer(Of T)(ByVal path As String) As ClientResponse(Of T)
        Dim response As New ClientResponse(Of T)
        If My.Settings.ServerURL.Equals("") Then
            response.errorInfo = UiStrings.serverUndefinedError
            Return response
        Else
            Try
                Dim data As [Byte]() = webClient.DownloadData(My.Settings.ServerURL + path)
                Dim json = ASCII.GetString(data)
                response = JsonConvert.DeserializeObject(Of ClientResponse(Of T))(json)
            Catch ex As Exception
                response = New ClientResponse(Of T)
                response.message = "ERROR"
                response.errorInfo = ex.Message.ToString()
            End Try
        End If
        If response.isError Then
            MessageBox.Show(response.errorInfo.ToString(), response.message.ToString(), MessageBoxButtons.OK)
        End If
        appState.lastServerMessage = response.message
        Return response
    End Function
End Class

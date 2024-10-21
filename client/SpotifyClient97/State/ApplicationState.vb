Imports System.ComponentModel

Public Class ApplicationState
    Implements INotifyPropertyChanged
    Public Event PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Private _lastServerMessage As String = "No Messages"
    Private _connStatus As ConnStatus = SpotifyClient97.ConnStatus.unknown
    Private _playStatus As PlayStatus = SpotifyClient97.PlayStatus.stopped
    Private _queue As New BindingList(Of Track)
    Private _deviceList As New BindingList(Of Device)
    Private _nowPlaying As Track
    Private _albumArt As Image
    Private _trackResults As New BindingList(Of Track)
    Private _albumResults As New BindingList(Of Album)
    Private _searchResults As New TreeNode("SearchResults")

    Property lastServerMessage() As String
        Get
            Return _lastServerMessage
        End Get
        Set(ByVal value As String)
            _lastServerMessage = value
            notify("lastServerMessage")
        End Set
    End Property

    Property connStatus() As ConnStatus
        Get
            Return _connStatus
        End Get
        Set(ByVal value As ConnStatus)
            _connStatus = value
            notify("connStatus")
        End Set
    End Property

    Property playStatus() As PlayStatus
        Get
            Return _playStatus
        End Get
        Set(ByVal value As PlayStatus)
            _playStatus = value
            notify("playStatus")
        End Set
    End Property

    Property queue() As BindingList(Of Track)
        Get
            Return _queue
        End Get
        Set(ByVal value As BindingList(Of Track))
            _queue = value
            notify("queue")
        End Set
    End Property

    Property deviceList() As BindingList(Of Device)
        Get
            Return _deviceList
        End Get
        Set(ByVal value As BindingList(Of Device))
            _deviceList = value
            notify("deviceList")
        End Set
    End Property

    Property nowPlaying() As Track
        Get
            Return _nowPlaying
        End Get
        Set(ByVal value As Track)
            _nowPlaying = value
            notify("nowPlaying")
        End Set
    End Property

    Property albumArt() As Image
        Get
            Return _albumArt
        End Get
        Set(ByVal value As Image)
            _albumArt = value
            notify("albumArt")
        End Set
    End Property

    Property trackResults() As BindingList(Of Track)
        Get
            Return _trackResults
        End Get
        Set(ByVal value As BindingList(Of Track))
            _trackResults = value
            notify("trackResults")
        End Set
    End Property

    Property albumResults() As BindingList(Of Album)
        Get
            Return _albumResults
        End Get
        Set(ByVal value As BindingList(Of Album))
            _albumResults = value
            notify("albumResults")
        End Set
    End Property

    Private Sub notify(ByVal prop As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(prop))
    End Sub
End Class

Public Enum ConnStatus
    ready
    connecting
    connected
    failed
    unknown
End Enum

Public Enum PlayStatus
    stopped
    playing
    paused
End Enum
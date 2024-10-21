Imports System.ComponentModel

Public Class PlaybackState
    Implements INotifyPropertyChanged

    Private _active As Boolean
    Private _currentDevice As Device
    Private _repeatState As RepeatState
    Private _shuffleState As Boolean
    Private _progress As Int64
    Private _playing As Boolean
    Private _nowPlaying As Track
    Private _context As String

    Property active() As Boolean
        Get
            Return _active
        End Get
        Set(ByVal value As Boolean)
            Me._active = value
            notify("active")
        End Set
    End Property

    Property currentDevice() As Device
        Get
            Return _currentDevice
        End Get
        Set(ByVal value As Device)
            Me._currentDevice = value
            My.Settings.PrevDeviceId = Me._currentDevice.id
            notify("currentDevice")
        End Set
    End Property

    Property repeatState() As RepeatState
        Get
            Return _repeatState
        End Get
        Set(ByVal value As RepeatState)
            Me._repeatState = value
            notify("repeatState")
        End Set
    End Property

    Property shuffleState() As Boolean
        Get
            Return _shuffleState
        End Get
        Set(ByVal value As Boolean)
            Me._shuffleState = value
            notify("shuffleState")
        End Set
    End Property

    Property progress() As Int64
        Get
            Return _progress
        End Get
        Set(ByVal value As Int64)
            Me._progress = value
            notify("progress")
        End Set
    End Property

    Property playing() As Boolean
        Get
            Return _playing
        End Get
        Set(ByVal value As Boolean)
            Me._playing = value
            notify("playing")
        End Set
    End Property

    Property nowPlaying() As Track
        Get
            Return _nowPlaying
        End Get
        Set(ByVal value As Track)
            Me._nowPlaying = value
            notify("nowPlaying")
        End Set
    End Property

    Property context() As String
        Get
            Return _context
        End Get
        Set(ByVal value As String)
            _context = value
            notify("context")
        End Set
    End Property

    Private Sub notify(ByVal prop As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(prop))
    End Sub

    Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
End Class

Public Enum RepeatState
    off
    track
    context
End Enum

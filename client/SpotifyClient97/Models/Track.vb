Public Class Track
    Public _title As String
    Public _artist As String
    Public _album As String
    Public _duration As Int16
    Public _albumArt As String
    Public _albumId As String
    Public _id As String

    Public Sub New(ByVal title, ByVal artist, ByVal album, ByVal albumArt, ByVal duration, ByVal albumId, ByVal id)
        Me._title = title
        Me._artist = artist
        Me._album = album
        Me._albumArt = albumArt
        Me._duration = duration
        Me._albumId = albumId
        Me._id = id
    End Sub

    ReadOnly Property Title()
        Get
            Return _title
        End Get
    End Property

    ReadOnly Property Artist()
        Get
            Return _artist
        End Get
    End Property

    ReadOnly Property Album()
        Get
            Return _album
        End Get
    End Property

    ReadOnly Property Duration()
        Get
            Return _duration
        End Get
    End Property

    ReadOnly Property AlbumArt()
        Get
            Return _albumArt
        End Get
    End Property

    ReadOnly Property Id()
        Get
            Return _id
        End Get
    End Property

    ReadOnly Property AlbumId()
        Get
            Return _albumId
        End Get
    End Property

    ReadOnly Property albumUri() As String
        Get
            Return "spotify:album:" + Me._albumId
        End Get
    End Property

    ReadOnly Property uri() As String
        Get
            Return "spotify:track:" + Me._id
        End Get
    End Property

End Class

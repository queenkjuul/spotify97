Public Class Album
    Private _title As String
    Private _artist As String
    Private _albumArt As String
    Private _id As String

    Public Property title()
        Get
            Return _title
        End Get
        Set(ByVal value)
            Me._title = value
        End Set
    End Property

    Public Property artist()
        Get
            Return _artist
        End Get
        Set(ByVal value)
            Me._artist = value
        End Set
    End Property

    Public Property albumArt()
        Get
            Return _albumArt
        End Get
        Set(ByVal value)
            Me._albumArt = value
        End Set
    End Property

    Public Property id()
        Get
            Return Me._id
        End Get
        Set(ByVal value)
            Me._id = value
        End Set
    End Property

    Public ReadOnly Property uri() As String
        Get
            Return "spotify:album:" + Me._id
        End Get
    End Property
End Class

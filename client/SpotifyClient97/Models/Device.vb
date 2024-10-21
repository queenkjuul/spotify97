Public Class Device
    Public name As String
    Public id As String

    Public Sub New(ByVal name, ByVal id)
        Me.name = name
        Me.id = id
    End Sub

    ReadOnly Property nameProperty()
        Get
            Return name
        End Get
    End Property

    ReadOnly Property idProperty()
        Get
            Return id
        End Get
    End Property
End Class

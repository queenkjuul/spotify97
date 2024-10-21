Public Class ClientResponse(Of T)
    Public message As String
    Public data As T
    Public errorInfo = Nothing
    Public ReadOnly Property isError()
        Get
            Return errorInfo IsNot Nothing
        End Get
    End Property
End Class

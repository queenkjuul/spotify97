Module Helpers
    Public Sub wait(Optional ByVal seconds As Double = 0.5)
        For i As Integer = 0 To Math.Floor(seconds * 100)
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
        Next
    End Sub

    Public Function getRepeatMode(ByVal state As RepeatState)
        If state.Equals(RepeatState.context) Then
            Return "context"
        ElseIf state.Equals(RepeatState.track) Then
            Return "track"
        Else
            Return "off"
        End If
    End Function

    Public Function getRepeatState(ByVal mode As String)
        If mode.Equals("context") Then
            Return RepeatState.context
        ElseIf mode.Equals("track") Then
            Return RepeatState.track
        Else
            Return RepeatState.off
        End If
    End Function

    Public Function areQueuesEqual(ByVal a() As Track, ByVal b() As Track) As Boolean

        'IF 2 NULL REFERENCES WERE PASSED IN, THEN RETURN TRUE, YOU MAY WANT TO RETURN FALSE
        If a Is Nothing AndAlso b Is Nothing Then Return True

        'CHECK THAT THERE IS NOT 1 NULL REFERENCE ARRAY
        If a Is Nothing Or b Is Nothing Then Return False

        'AT THIS POINT NEITHER ARRAY IS NULL
        'IF LENGTHS DON'T MATCH, THEY ARE NOT EQUAL
        If a.Length <> b.Length Then Return False

        'LOOP ARRAYS TO COMPARE CONTENTS
        For i As Integer = 0 To a.GetUpperBound(0)
            'RETURN FALSE AS SOON AS THERE IS NO MATCH
            If a(i) IsNot Nothing AndAlso b(i) IsNot Nothing AndAlso Not a(i).Title.Equals(b(i).Title) Then Return False
        Next

        'IF WE GOT HERE, THE ARRAYS ARE EQUAL
        Return True

    End Function
End Module

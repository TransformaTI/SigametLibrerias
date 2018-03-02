Module [Global]
    Private Structure POINTAPI
        Dim x As Short
        Dim y As Short
    End Structure

    Private Declare Sub GetCursorPos Lib "User32" (ByRef lpPoint As POINTAPI)
    Private Declare Function GetAsyncKeyState Lib "User32" (ByVal vKey As Integer) As Short

    Private posOld As POINTAPI
    Private posNew As POINTAPI

    Public Function InputCheck() As Boolean
        Dim i As Short
        Call GetCursorPos(posNew)
        If ((posNew.x <> posOld.x) Or (posNew.y <> posOld.y)) Then
            posOld = posNew
            InputCheck = True
            Exit Function
        End If
        For i = 0 To 255
            If (GetAsyncKeyState(i) And &H8001S) <> 0 Then
                InputCheck = True
                Exit Function
            End If
        Next i
        InputCheck = False
    End Function

    'Public Sub ConfiguraConexion()
    '    Dim line As String
    '    Try
    '        FileOpen(1, "\Login.inf", OpenMode.Input, OpenAccess.Read)
    '        Input(1, line)
    '    Catch ex As Exception

    '    Finally
    '        FileClose(1)
    '    End Try
    'End Sub

    Public Function UnEncript(ByVal Text As String) As String
        Dim i As Integer
        Dim Explore(Text.Length - 1) As Char
        Dim Result As String = Nothing
        Explore = Text.ToCharArray
        For i = 0 To Text.Length - 1
            Result &= Chr(Asc(Explore(i)) + 8)
        Next
        Return Result
    End Function

End Module

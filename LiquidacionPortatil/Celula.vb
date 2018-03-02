Public Class Celula

    Sub New()
    End Sub
    Sub New(ByVal id As Integer, ByVal descripcion As String)
        Me.id = id
        Me.descripcion = descripcion
    End Sub
    Private id As Integer
    Public Property IdCelula() As Integer
        Get
            Return id
        End Get
        Set(ByVal Value As Integer)
            id = Value
        End Set
    End Property

    Private descripcion As String
    Public Property DescripcionCelula() As String
        Get
            Return descripcion
        End Get
        Set(ByVal Value As String)
            descripcion = Value
        End Set
    End Property


End Class

Public Class Reporte
    Inherits ListViewItem
    Private _Path As String
    Private _Tema As String
    Private _Comentario As String
    Private _FActualizacion As Date
    Private _Servidor As String
    Private _BaseDatos As String


    Public Property Path() As String
        Get
            Return _Path
        End Get
        Set(ByVal Value As String)
            _Path = Value
        End Set
    End Property

    Public Property Tema() As String
        Get
            Return _Tema
        End Get
        Set(ByVal Value As String)
            _Tema = Value
        End Set
    End Property

    Public Property Comentario() As String
        Get
            Return _Comentario
        End Get
        Set(ByVal Value As String)
            _Comentario = Value
        End Set
    End Property

    Public Property FActualizacion() As Date
        Get
            Return _FActualizacion
        End Get
        Set(ByVal Value As Date)
            _FActualizacion = Value
        End Set
    End Property

    Public Property Servidor() As String
        Get
            Return _Servidor
        End Get
        Set(ByVal Value As String)
            _Servidor = Value
        End Set
    End Property

    Public Property BaseDatos() As String
        Get
            Return _BaseDatos
        End Get
        Set(ByVal Value As String)
            _BaseDatos = Value
        End Set
    End Property
End Class



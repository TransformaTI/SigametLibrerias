Imports System.Data.SqlClient

Public Class GuiaEmbarque

    Protected _IdGuia As Integer
    Public Property IdGuia() As Integer
        Get
            Return _IdGuia
        End Get
        Set(ByVal value As Integer)
            _IdGuia = value
        End Set
    End Property

    Protected _Extension As String

    Public Property Extension() As String
        Get
            Return _Extension
        End Get
        Set(ByVal value As String)
            _Extension = value
        End Set
    End Property

    Protected _Archivo As Byte()
    Public Property Archivo() As Byte()
        Get
            Return _Archivo
        End Get
        Set(ByVal value As Byte())
            _Archivo = value
        End Set
    End Property

    Protected _Embarque As Integer
    Public Property Embarque() As Integer
        Get
            Return _Embarque
        End Get
        Set(ByVal value As Integer)
            _Embarque = value
        End Set
    End Property

    Protected _Usuario As String
    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property

    Protected _Falta As DateTime
    Public Property FAlta() As DateTime
        Get
            Return _Falta
        End Get
        Set(ByVal value As DateTime)
            _Falta = value
        End Set
    End Property

    Protected _NombreArchivo As String
    Public Property NombreArchivo() As String
        Get
            Return _NombreArchivo
        End Get
        Set(ByVal value As String)
            _NombreArchivo = value
        End Set
    End Property

    Protected _Conexion As SqlConnection
    Public Property Conexion() As SqlConnection
        Get
            Return _Conexion
        End Get
        Set(ByVal value As SqlConnection)
            _Conexion = value
        End Set
    End Property

    Protected _RutaArchivo As String
    Public Property RutaArchivo() As String
        Get
            Return _RutaArchivo
        End Get
        Set(ByVal value As String)
            _RutaArchivo = value
        End Set
    End Property

    Private _borrarEnBD As Boolean
    Public Property BorrarEnBD() As Boolean
        Get
            Return _borrarEnBD
        End Get
        Set(ByVal value As Boolean)
            _borrarEnBD = value
        End Set
    End Property    
End Class

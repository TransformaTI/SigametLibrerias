Imports System.Data.SqlClient

Public Class Globals

#Region "Variables globales"
    'Variables globales para toda la aplicacion
    Public GLOBAL_Servidor As String
    Public GLOBAL_BaseDatos As String
    Public GLOBAL_Usuario As String
    Public GLOBAL_Password As String

    Public GLOBAL_Conexion As SqlConnection
    Public GLOBAL_CadenaConexion As String
#End Region

    Private Shared _singleton As Globals

    Private Sub New()

    End Sub

    Shared ReadOnly Property GetInstance() As Globals
        Get
            If _singleton Is Nothing Then
                _singleton = New Globals()
            End If
            Return _singleton
        End Get
    End Property

    Public Sub ConfiguraModulo(ByVal Usuario As String, ByVal Password As String, ByVal ConString As String, _
    ByVal Servidor As String, ByVal BaseDatos As String, ByVal Conexion As SqlConnection)
        GLOBAL_Usuario = Usuario
        GLOBAL_Password = Password
        GLOBAL_CadenaConexion = ConString
        GLOBAL_Servidor = Servidor
        GLOBAL_BaseDatos = BaseDatos
        GLOBAL_Conexion = Conexion

    End Sub

End Class

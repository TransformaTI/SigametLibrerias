Imports System.Windows.Forms
Imports System.IO

Public Class Globals
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

#Region "Variables globales"
    'Información del usuario
    Public _Usuario As String
    Public _Password As String
    Public _Corporativo As Short
    Public _Sucursal As Short
    Public _CadenaConexion As String

    'Información de la conexión
    Public _Servidor As String
	Public _Database As String
	Public _Modulo As Byte

	'Conexión
	Public cnSigamet As New SqlClient.SqlConnection()
#End Region

	Public Sub ConfiguraModulo(ByVal Usuario As String, ByVal Password As String, ByVal ConString As String, ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal Modulo As Byte)
		_Usuario = Usuario
		_Password = Password
		_Corporativo = Corporativo
		_Sucursal = Sucursal
		_CadenaConexion = ConString
		_Modulo = Modulo
	End Sub

	Public Sub ConfiguraModulo(ByVal Usuario As String, ByVal Password As String, ByVal ConString As String, ByVal Corporativo As Short, ByVal Sucursal As Short)
		_Usuario = Usuario
		_Password = Password
		_Corporativo = Corporativo
		_Sucursal = Sucursal
		_CadenaConexion = ConString
		_Modulo = 3
	End Sub

End Class

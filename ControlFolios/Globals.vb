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


    Public Sub ConfiguraModulo(ByVal Servidor As String, ByVal BaseDatos As String, ByVal Usuario As String, ByVal Password As String, ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal RutaReportes As String, ByVal CadenaConexion As String)
        Global_Servidor = Servidor
        Global_BaseDatos = BaseDatos
        GLOBAL_Usuario = Usuario
        GLOBAL_Password = Password

        GLOBAL_RutaReportes = RutaReportes

        PortatilClasses.Globals.GetInstance.ConfiguraModulo(GLOBAL_Usuario, GLOBAL_Password, CadenaConexion, Corporativo, Sucursal)
    End Sub

End Class
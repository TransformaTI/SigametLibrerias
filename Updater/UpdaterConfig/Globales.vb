Module Globales


#Region "Variables globales"
    'Información del usuario
    Public _Celula As Integer
    Public _Usuario As String
    Public _Nombre As String
    Public _DesCelula As String
    Public _Password As String
    Public _Corporativo As Short
    Public _Sucursal As Short

    'Información de la conexión
    Public _Servidor As String
    Public _Database As String

    'Conexión
    Public cnSigamet As New SqlClient.SqlConnection()
#End Region

#Region "Funciones y subrutinas globales"
    Public Sub ExMessage(ByVal ex As Exception)
        MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
    Public Sub ErrMessage(ByVal ErrorMessage As String)
        MessageBox.Show(ErrorMessage, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
#End Region

    Public Sub Main()
        Dim img As New Bitmap(Application.StartupPath + "\UpdaterConfig.ico")
        Dim frmLogin As New SigametSeguridad.UI.Acceso(Application.StartupPath + "\Default.Seguridad y Administracion.exe.config", True, 0, img)
        Dim frmPrincipal As frmPrincipal
        Dim Acceso As Boolean = Nothing
        'Validación de acceso
        frmLogin.ShowDialog()
        If frmLogin.DialogResult = DialogResult.OK Then
            With frmLogin
                cnSigamet.ConnectionString = frmLogin.CadenaConexion
                _Corporativo = frmLogin.Usuario.Corporativo
                _Sucursal = frmLogin.Usuario.Sucursal
            End With
        Else
            Application.Exit()
            Exit Sub
        End If
        frmLogin.Dispose()
        frmPrincipal = New frmPrincipal()
        frmPrincipal.Show()
        Application.Run(frmPrincipal)
    End Sub


End Module

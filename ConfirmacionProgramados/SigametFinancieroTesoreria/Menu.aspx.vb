
Partial Class Menu
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Trim(Session("IdSession")) <> "" Then
            'Introducir aquí el código de usuario para inicializar la página        
            If Not IsPostBack Then
                'asigno el valor de la varible Usuario al textbox Usuario
                txbUsuario.Value = Trim(Session("Usuario"))
                'asigno el valor de la varible TipoUsuario al textbox TipoUsuario
                txbTipoUsuario.Value = Trim(Session("TipoUsuario"))
            End If
        Else
            'manda llamar la página principal del login.aspx
            Server.Transfer("./Login.aspx")
        End If

    End Sub

End Class

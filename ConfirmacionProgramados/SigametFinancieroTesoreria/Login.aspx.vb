
Partial Class Login
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
        'Put user code to initialize the page here

    End Sub

    'Procedimiento cuyo prop�sito es asignar el valor del par�metro recibido al texbox del mensaje
    Private Sub Message(ByVal Texto As String)
        'Asigna texto a la etiqueta
        lblMessage.InnerText = Texto
    End Sub

    'procedimiento cuyo prop�sito es validar el usuario, contrase�a
    Private Sub btnAceptar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.ServerClick
        'si el usuario est� en blanco manda mensaje al usuario
        If txbUsuario.Value = "" Then
            'manda mensaje al usuario
            Message("El Usuario no puede quedar en blanco")
        Else
            'si el password est� en blanco manda mensaje al usuario
            If txbPassword.Value = "" Then
                'manda mensaje al usuario
                Message("La contrase�a no puede quedar en blanco")
            Else
                'valida el usuario y contrase�a en la base de datos
                ValidaUsuarioPassword()
            End If
        End If
    End Sub

    'funci�n cuyo prop�sito es validar que exista el usuario
    Private Sub ValidaUsuarioPassword()
        Try
            'validar que exista el usuario y contrase�a
            Dim TipoUsuario As String = fnValidaUsuario(txbUsuario.Value, txbPassword.Value)
            'si se existe la clave presupuestal y est� con estatus de activo entonces abre la p�gina del men� principal
            If TipoUsuario = "NoExiste" Then
                'manda mensaje al usuario
                Message("Usuario incorrecto, verifique")
            Else
                If fnCajaActiva(Trim(txbUsuario.Value)) Then
                    'coloca el tiempo de duraci�n de la session
                    Session.Timeout = 120
                    'agrega variable de session de TipoUsuario
                    Session.Add("TipoUsuario", TipoUsuario.ToUpper)
                    'agrega variable de session de usuario
                    Session.Add("Usuario", txbUsuario.Value.ToUpper)
                    'crea la variable de session id 
                    Session.Add("IdSession", Session.SessionID)
                    'manda llamar la p�gina del men�
                    Server.Transfer("./menu.aspx")
                Else
                    Message("No tiene asignada ninguna Caja Activa, Verificar con el administrador del sistema")
                End If
            End If
        Catch e As Exception
            Message(Err.Number & " " & Err.Description)
        End Try
    End Sub

End Class

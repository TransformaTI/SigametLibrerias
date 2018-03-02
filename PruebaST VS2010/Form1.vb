Imports System.Data.SqlClient
Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents gedEquipo As System.Windows.Forms.DataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.gedEquipo = New System.Windows.Forms.DataGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        CType(Me.gedEquipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn1
        '
        Me.btn1.Location = New System.Drawing.Point(176, 32)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(104, 23)
        Me.btn1.TabIndex = 4
        Me.btn1.Text = "Servicios"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(32, 32)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(112, 20)
        Me.txtCliente.TabIndex = 1
        '
        'btn2
        '
        Me.btn2.Location = New System.Drawing.Point(176, 64)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(104, 23)
        Me.btn2.TabIndex = 0
        Me.btn2.Text = "Programación"
        '
        'txtUsuario
        '
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.Location = New System.Drawing.Point(32, 88)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(112, 20)
        Me.txtUsuario.TabIndex = 2
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(32, 144)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(112, 20)
        Me.txtClave.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(176, 96)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 24)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "CatalogoMaterial"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(176, 128)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 24)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Catalogo Créditos"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(309, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Cuentas"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(176, 192)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(112, 23)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "Comodato Agrega"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(176, 160)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(112, 23)
        Me.Button5.TabIndex = 9
        Me.Button5.Text = "Comodato Modifica"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(293, 52)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(88, 32)
        Me.Button6.TabIndex = 10
        Me.Button6.Text = "Pantalla Comodatos"
        '
        'gedEquipo
        '
        Me.gedEquipo.DataMember = ""
        Me.gedEquipo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.gedEquipo.Location = New System.Drawing.Point(8, 224)
        Me.gedEquipo.Name = "gedEquipo"
        Me.gedEquipo.ReadOnly = True
        Me.gedEquipo.Size = New System.Drawing.Size(400, 72)
        Me.gedEquipo.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(32, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Cliente:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(32, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Usuario:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(32, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 23)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Clave:"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(293, 105)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(104, 23)
        Me.Button7.TabIndex = 15
        Me.Button7.Text = "Ciclos Atms"
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(309, 192)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 16
        Me.Button8.Text = "Button8"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(35, 192)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(109, 23)
        Me.Button9.TabIndex = 17
        Me.Button9.Text = "PantallaConsulatr"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(426, 318)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gedEquipo)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtClave)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.btn1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.gedEquipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        Dim Conexion As New SqlConnection("Data Source=192.168.1.25;Initial Catalog=sigametOAXACACAPACITACION;uid = CAPACI;pwd = GENERICO01;Integrated Security=No;")
        SigaMetClasses.DataLayer.InicializaConexion(Conexion)


        Dim oServicio As New SigametST.frmServicios(txtCliente.Text, Now.Date, txtUsuario.Text, 1, 2)
        oServicio.ShowDialog()

    End Sub

    Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click
        Dim Conexion As New SqlConnection("Data Source=192.168.1.28;Initial Catalog=sigametReportes;uid = JEBANA;pwd = MICHOACAN;Integrated Security=No;")
        SigaMetClasses.DataLayer.InicializaConexion(Conexion)

        Dim oProgramacion As New SigametST.frmServProgramacion("JEBANA", "MICHOACAN", Conexion.ConnectionString, 1, 2)
        oProgramacion.ShowDialog()

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim CatalogoMaterial As New SigametST.frmMaterial(txtUsuario.Text)
        CatalogoMaterial.ShowDialog()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Credito As New SigametST.frmCreditoServicioTecnico(txtUsuario.Text)
        Credito.ShowDialog()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Cuentas As New SigametST.frmCuenta(txtUsuario.Text, txtClave.Text)
        Cuentas.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim Conexion As New SqlConnection("Data Source=192.168.1.28;Initial Catalog=SigametReportes;uid = " & txtUsuario.Text & ";Integrated Security=Yes;")
        SigaMetClasses.DataLayer.InicializaConexion(Conexion)

        Dim Comodato As New LiquidacionSTN.frmEquipoST(Integer.Parse(txtCliente.Text), txtUsuario.Text, True)
        Comodato.ShowDialog()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim Conexion As New SqlConnection("Data Source=192.168.1.26;Initial Catalog=Sigamet;uid = " & txtUsuario.Text & ";pwd = " & txtClave.Text & ";Integrated Security=Yes;")
        SigaMetClasses.DataLayer.InicializaConexion(Conexion)

        'Dim Comodato As New LiquidacionSTN.frmEquipoST(txtCliente.Text, txtUsuario.Text, 1, 1, 0)
        'Comodato.ShowDialog()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim Conexion As New SqlConnection("Data Source=192.168.1.26;Initial Catalog=Sigamet;uid = " & txtUsuario.Text & ";pwd = " & txtClave.Text & ";Integrated Security=Yes;")
        SigaMetClasses.DataLayer.InicializaConexion(Conexion)

        Dim PantallaComodato As New SigametST.frmPantallaComodato(txtUsuario.Text)
        PantallaComodato.ShowDialog()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim Conexion As New SqlConnection("Data Source=192.168.1.30;Initial Catalog=SigametGasGalgoWSiete;uid = " & txtUsuario.Text & ";pwd = " & txtClave.Text & ";Integrated Security=Yes;")
        SigaMetClasses.DataLayer.InicializaConexion(Conexion)

        Dim PantallaGenCiclosAtm As New GeneraCiclosAutomaticos.frmGeneraCiclos(txtUsuario.Text)
        PantallaGenCiclosAtm.ShowDialog()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim Conexion As New SqlConnection("Data Source=192.168.1.28;Initial Catalog=SigametReportes;uid = " & txtUsuario.Text & ";Integrated Security=Yes;")
        SigaMetClasses.DataLayer.InicializaConexion(Conexion)

        Dim Comodato As New SigametST.frmCatalogoEquipo()
        Comodato.ShowDialog()
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        Dim Conexion As New SqlConnection("Data Source=192.168.1.25;Initial Catalog=SigametOaxacaDDS;uid = " & txtUsuario.Text & ";Integrated Security=Yes;")
        SigaMetClasses.DataLayer.InicializaConexion(Conexion)
        Dim frmConsulta As New LiquidacionSTN.frmConsultar("SOPORTE", True)
        frmConsulta.ShowDialog()
    End Sub
End Class

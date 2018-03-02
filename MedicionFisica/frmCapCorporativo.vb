'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 26/08/2007
'Motivo: Se aumento el campo status en las pantallas de Corporativo
'Identificador de cambios: 20070426CAGP$001

Imports System.Windows.Forms
Imports System.Drawing

Public Class frmCapCorporativo
    Inherits System.Windows.Forms.Form

    Public _TipoOperacion As SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo

    Private _Corporativo As Integer
    Private _Nombre As String
    Private _Inicial As String
    Private _Status As String           '20070426CAGP$001

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal Consulta As Boolean)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'pnlConsulta.Enabled = False

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents gpbDatosPrincipales As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblInicial As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents txtInicial As System.Windows.Forms.TextBox
    Friend WithEvents tltCorporativo As System.Windows.Forms.ToolTip
    Friend WithEvents ielImagenes As System.Windows.Forms.ImageList
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCapCorporativo))
        Me.gpbDatosPrincipales = New System.Windows.Forms.GroupBox()
        Me.txtInicial = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblInicial = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.ielImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.tltCorporativo = New System.Windows.Forms.ToolTip(Me.components)
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gpbDatosPrincipales.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpbDatosPrincipales
        '
        Me.gpbDatosPrincipales.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.cboStatus, Me.txtInicial, Me.txtNombre, Me.lblInicial, Me.lblNombre})
        Me.gpbDatosPrincipales.Location = New System.Drawing.Point(10, 8)
        Me.gpbDatosPrincipales.Name = "gpbDatosPrincipales"
        Me.gpbDatosPrincipales.Size = New System.Drawing.Size(360, 115)
        Me.gpbDatosPrincipales.TabIndex = 36
        Me.gpbDatosPrincipales.TabStop = False
        '
        'txtInicial
        '
        Me.txtInicial.AutoSize = False
        Me.txtInicial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInicial.Location = New System.Drawing.Point(168, 48)
        Me.txtInicial.MaxLength = 5
        Me.txtInicial.Name = "txtInicial"
        Me.txtInicial.Size = New System.Drawing.Size(150, 21)
        Me.txtInicial.TabIndex = 2
        Me.txtInicial.Text = ""
        Me.tltCorporativo.SetToolTip(Me.txtInicial, "Abreviación del corporativo")
        '
        'txtNombre
        '
        Me.txtNombre.AutoSize = False
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(167, 20)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(150, 21)
        Me.txtNombre.TabIndex = 1
        Me.txtNombre.Text = ""
        Me.tltCorporativo.SetToolTip(Me.txtNombre, "Descipción del nombre del corporativo")
        '
        'lblInicial
        '
        Me.lblInicial.AutoSize = True
        Me.lblInicial.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblInicial.Location = New System.Drawing.Point(19, 52)
        Me.lblInicial.Name = "lblInicial"
        Me.lblInicial.Size = New System.Drawing.Size(73, 13)
        Me.lblInicial.TabIndex = 24
        Me.lblInicial.Text = "Abreviación:"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblNombre.Location = New System.Drawing.Point(19, 24)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(135, 13)
        Me.lblNombre.TabIndex = 22
        Me.lblNombre.Text = "Nombre de corporativo:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 2
        Me.btnCancelar.ImageList = Me.ielImagenes
        Me.btnCancelar.Location = New System.Drawing.Point(400, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltCorporativo.SetToolTip(Me.btnCancelar, "Presione cancelar para cerrar la ventana")
        '
        'ielImagenes
        '
        Me.ielImagenes.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ielImagenes.ImageSize = New System.Drawing.Size(16, 16)
        Me.ielImagenes.ImageStream = CType(resources.GetObject("ielImagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ielImagenes.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 3
        Me.btnAceptar.ImageList = Me.ielImagenes
        Me.btnAceptar.Location = New System.Drawing.Point(400, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltCorporativo.SetToolTip(Me.btnAceptar, "Presione aceptar para almacenar los datos")
        '
        'cboStatus
        '
        Me.cboStatus.Items.AddRange(New Object() {"ACTIVO", "INACTIVO"})
        Me.cboStatus.Location = New System.Drawing.Point(167, 76)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(150, 21)
        Me.cboStatus.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(19, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Status:"
        '
        'frmCapCorporativo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(498, 136)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnAceptar, Me.gpbDatosPrincipales})
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmCapCorporativo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Corporativo"
        Me.gpbDatosPrincipales.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Metodos y Funciones"

    'Funcion que es llamada antes de almacenar una alta o modificación para verificar
    'que se cumpla con la información mínima para la alta de un corporativo
    Private Function ValidarCaptura() As Boolean
        Dim Mensajes As PortatilClasses.Mensaje

        If txtNombre.TextLength = 0 Then
            Mensajes = New PortatilClasses.Mensaje(34)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ActiveControl = txtNombre
            Return False
        ElseIf txtInicial.TextLength = 0 Then
            Mensajes = New PortatilClasses.Mensaje(35)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ActiveControl = txtInicial
            Return False
        Else
            Return True
        End If
    End Function

    'Funcion para registrar y modificar la informacion del corporativo
    Function AlmacenarModificarCorporativo(ByVal Accion As Short) As Boolean
        Dim Resultado As Boolean
        Dim i As Integer = Nothing

        Cursor = Cursors.WaitCursor
        Select Case Accion
            Case Is = 1
                Dim oCorporativo As New PortatilClasses.CatalogosPortatil.cCorporativo(2, 0, txtNombre.Text, txtInicial.Text, cboStatus.Text)
                oCorporativo.RegistrarModificarEliminar()
                If oCorporativo.Corporativo > 0 Then
                    Resultado = True
                Else
                    Resultado = False
                End If
            Case Is = 2
                Dim oCorporativo As New PortatilClasses.CatalogosPortatil.cCorporativo(3, _Corporativo, txtNombre.Text, txtInicial.Text, cboStatus.Text)
                oCorporativo.RegistrarModificarEliminar()
                If oCorporativo.Corporativo > 0 Then
                    Resultado = True
                Else
                    Resultado = False
                End If
        End Select
        Cursor = Cursors.Default
        Return Resultado
    End Function

    'Metodo que carga las variables de la forma con los datos del corporativo
    'va a modificar o se esta consultando
    Public Sub CargarDatosCorporativo(ByVal Corporativo As Integer)
        Dim oCorporativo As New PortatilClasses.CatalogosPortatil.cCorporativo(1, Corporativo, "", "", "")
        oCorporativo.CargarCorporativo()
        _Corporativo = oCorporativo.Corporativo
        _Nombre = oCorporativo.Nombre
        _Inicial = oCorporativo.Inicial
        _Status = oCorporativo.Status           '20070426CAGP$001
        oCorporativo = Nothing
    End Sub

    'Metodo que es llamadado para inicializar la forma al momento de realizar una modificación
    'e inicializa la pantalla con la informacion que se modificara
    Private Sub CargarDatosModificar()
        txtNombre.Text = _Nombre
        txtInicial.Text = _Inicial
        If _Status = "ACTIVO" Then              '20070426CAGP$001
            cboStatus.SelectedIndex = 0
        Else
            cboStatus.SelectedIndex = 1
        End If
    End Sub

#End Region

    'Evento de la forma para registrar, modificar y consultar la informacion del corporativo
    'es disparado al momento de accesar a ella
    Private Sub frmCapCorporativo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ActiveControl = txtNombre
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar Then
            CargarDatosModificar()
        End If
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Consultar Then
            CargarDatosModificar()
            txtNombre.SelectionStart = 0
            txtNombre.ReadOnly = True
            txtInicial.ReadOnly = True
        End If
    End Sub

    'Evento del boton Aceptar, este evento se dispara al momento de hacer click en el boton
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar Then
            If ValidarCaptura() Then
                If AlmacenarModificarCorporativo(1) Then
                    Me.DialogResult() = DialogResult.OK
                    Me.Close()
                End If
            End If
        End If

        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar Then
            If ValidarCaptura() Then
                If AlmacenarModificarCorporativo(2) Then
                    Me.DialogResult() = DialogResult.OK
                    Me.Close()
                End If
            End If
        End If

        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Consultar Then
            Me.DialogResult() = DialogResult.OK
            Me.Close()
        End If
    End Sub

    'Evento para el componente txtNombre y txtInicial, es dispado al momento de
    'presionar cualquier tecla cuando el cursor esta activado en dicho componente
    Private Sub txtNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown, txtInicial.KeyDown
        If (e.KeyData = Keys.Enter) Or (e.KeyData = Keys.Down) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    'Evento para el componente txtNombre y txtInicial, es dispado al momento de
    'presionar cualquier tecla cuando el cursor esta activado en dicho componente
    Private Sub cboStatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboStatus.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub
End Class
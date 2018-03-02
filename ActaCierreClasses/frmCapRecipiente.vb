'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 26/08/2007
'Motivo: Se aumento el campo status en las pantallas de Corporativo
'Identificador de cambios: 20070426CAGP$001

Imports System.Windows.Forms
Imports System.Drawing

Public Class frmCapRecipiente
    Inherits System.Windows.Forms.Form

    Public _TipoOperacion As SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo

    Private _Recipiente As Integer
    Private _Descripcion As String
    Private _Abreviatura As String
    Private _Capacidad As Decimal
    Private _TipoRecipiente As Integer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCapacidad As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private _Status As String        '20070426CAGP$001

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
    Friend WithEvents cboTipoRecipiente As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapRecipiente))
        Me.gpbDatosPrincipales = New System.Windows.Forms.GroupBox()
        Me.cboTipoRecipiente = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.txtCapacidad = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.txtInicial = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblInicial = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.ielImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.tltCorporativo = New System.Windows.Forms.ToolTip(Me.components)
        Me.gpbDatosPrincipales.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpbDatosPrincipales
        '
        Me.gpbDatosPrincipales.Controls.Add(Me.cboTipoRecipiente)
        Me.gpbDatosPrincipales.Controls.Add(Me.txtCapacidad)
        Me.gpbDatosPrincipales.Controls.Add(Me.Label3)
        Me.gpbDatosPrincipales.Controls.Add(Me.Label2)
        Me.gpbDatosPrincipales.Controls.Add(Me.Label1)
        Me.gpbDatosPrincipales.Controls.Add(Me.cboStatus)
        Me.gpbDatosPrincipales.Controls.Add(Me.txtInicial)
        Me.gpbDatosPrincipales.Controls.Add(Me.txtNombre)
        Me.gpbDatosPrincipales.Controls.Add(Me.lblInicial)
        Me.gpbDatosPrincipales.Controls.Add(Me.lblNombre)
        Me.gpbDatosPrincipales.Location = New System.Drawing.Point(10, 8)
        Me.gpbDatosPrincipales.Name = "gpbDatosPrincipales"
        Me.gpbDatosPrincipales.Size = New System.Drawing.Size(360, 164)
        Me.gpbDatosPrincipales.TabIndex = 36
        Me.gpbDatosPrincipales.TabStop = False
        '
        'cboTipoRecipiente
        '
        Me.cboTipoRecipiente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoRecipiente.Items.AddRange(New Object() {"ACTIVO", "INACTIVO"})
        Me.cboTipoRecipiente.Location = New System.Drawing.Point(167, 127)
        Me.cboTipoRecipiente.Name = "cboTipoRecipiente"
        Me.cboTipoRecipiente.Size = New System.Drawing.Size(150, 21)
        Me.cboTipoRecipiente.TabIndex = 5
        '
        'txtCapacidad
        '
        Me.txtCapacidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCapacidad.Location = New System.Drawing.Point(167, 101)
        Me.txtCapacidad.MaxLength = 8
        Me.txtCapacidad.Name = "txtCapacidad"
        Me.txtCapacidad.Size = New System.Drawing.Size(150, 20)
        Me.txtCapacidad.TabIndex = 4
        Me.tltCorporativo.SetToolTip(Me.txtCapacidad, "Abreviación del recipiente")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(19, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Tipo recipiente:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(19, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Capacidad:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(19, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Status:"
        '
        'cboStatus
        '
        Me.cboStatus.Items.AddRange(New Object() {"ACTIVO", "INACTIVO"})
        Me.cboStatus.Location = New System.Drawing.Point(167, 74)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(150, 21)
        Me.cboStatus.Sorted = True
        Me.cboStatus.TabIndex = 3
        '
        'txtInicial
        '
        Me.txtInicial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInicial.Location = New System.Drawing.Point(168, 48)
        Me.txtInicial.MaxLength = 5
        Me.txtInicial.Name = "txtInicial"
        Me.txtInicial.Size = New System.Drawing.Size(150, 20)
        Me.txtInicial.TabIndex = 2
        Me.tltCorporativo.SetToolTip(Me.txtInicial, "Abreviación del recipiente")
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(167, 20)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(150, 20)
        Me.txtNombre.TabIndex = 1
        Me.tltCorporativo.SetToolTip(Me.txtNombre, "Descipción del nombre del recipiente")
        '
        'lblInicial
        '
        Me.lblInicial.AutoSize = True
        Me.lblInicial.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblInicial.Location = New System.Drawing.Point(19, 52)
        Me.lblInicial.Name = "lblInicial"
        Me.lblInicial.Size = New System.Drawing.Size(77, 13)
        Me.lblInicial.TabIndex = 24
        Me.lblInicial.Text = "Abreviación:"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblNombre.Location = New System.Drawing.Point(19, 24)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(54, 13)
        Me.lblNombre.TabIndex = 22
        Me.lblNombre.Text = "Nombre:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 2
        Me.btnCancelar.ImageList = Me.ielImagenes
        Me.btnCancelar.Location = New System.Drawing.Point(400, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltCorporativo.SetToolTip(Me.btnCancelar, "Presione cancelar para cerrar la ventana")
        '
        'ielImagenes
        '
        Me.ielImagenes.ImageStream = CType(resources.GetObject("ielImagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ielImagenes.TransparentColor = System.Drawing.Color.Transparent
        Me.ielImagenes.Images.SetKeyName(0, "")
        Me.ielImagenes.Images.SetKeyName(1, "")
        Me.ielImagenes.Images.SetKeyName(2, "")
        Me.ielImagenes.Images.SetKeyName(3, "")
        Me.ielImagenes.Images.SetKeyName(4, "")
        Me.ielImagenes.Images.SetKeyName(5, "")
        Me.ielImagenes.Images.SetKeyName(6, "")
        Me.ielImagenes.Images.SetKeyName(7, "")
        Me.ielImagenes.Images.SetKeyName(8, "")
        Me.ielImagenes.Images.SetKeyName(9, "")
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 3
        Me.btnAceptar.ImageList = Me.ielImagenes
        Me.btnAceptar.Location = New System.Drawing.Point(400, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tltCorporativo.SetToolTip(Me.btnAceptar, "Presione aceptar para almacenar los datos")
        '
        'frmCapRecipiente
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(498, 181)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.gpbDatosPrincipales)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmCapRecipiente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recipiente"
        Me.gpbDatosPrincipales.ResumeLayout(False)
        Me.gpbDatosPrincipales.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Metodos y Funciones"
    'Funcion que es llamada antes de almacenar una alta o modificación para verificar
    'que se cumpla con la información mínima para la alta de un corporativo
    Private Function ValidarCaptura() As Boolean
        If txtNombre.TextLength = 0 Then
            MessageBox.Show("Por favor escriba el nombre del registro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ActiveControl = txtNombre
            Return False
        ElseIf txtInicial.TextLength = 0 Then
            MessageBox.Show("Por favor escriba la abreviación con la cual se identificara el registro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ActiveControl = txtInicial
            Return False
        ElseIf txtCapacidad.TextLength < 0 Then
            MessageBox.Show("Por favor escriba la capacidad del registro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ActiveControl = txtCapacidad
            Return False
            ElseIf cboTipoRecipiente.Identificador = -1 Then
                MessageBox.Show("Por favor proporcione el tipo de recipiente del registro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.ActiveControl = cboTipoRecipiente
                Return False
            Else
                Return True
            End If
    End Function

    'Funcion para registrar y modificar la informacion del corporativo
    Function AlmacenarModificar(ByVal Accion As Short) As Boolean
        Dim Resultado As Boolean
        Dim i As Integer = Nothing

        Cursor = Cursors.WaitCursor
        Select Case Accion
            Case Is = 1
                Dim oRecipiente As New Catalogo.cRecipiente(1, 0, txtNombre.Text, txtCapacidad.Text, txtInicial.Text, cboTipoRecipiente.Identificador, cboStatus.Text)
                oRecipiente.RegistrarModificarEliminar()
                If oRecipiente.Recipiente > 0 Then
                    Resultado = True
                Else
                    Resultado = False
                End If
            Case Is = 2
                Dim oRecipiente As New Catalogo.cRecipiente(2, _Recipiente, txtNombre.Text, txtCapacidad.Text, txtInicial.Text, cboTipoRecipiente.Identificador, cboStatus.Text)
                oRecipiente.RegistrarModificarEliminar()
                If oRecipiente.Recipiente > 0 Then
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
    Public Sub CargarDatosRecipiente(Optional Recipiente As Integer = -1)
        Dim oRecipiente As New Catalogo.cRecipiente(0, Recipiente, txtNombre.Text, 0, txtInicial.Text, cboTipoRecipiente.Identificador, cboStatus.Text)
        oRecipiente.CargarRecipiente()
        _Recipiente = oRecipiente.Recipiente
        _Descripcion = oRecipiente.Descripcion
        _Capacidad = oRecipiente.Capacidad
        _Abreviatura = oRecipiente.Abreviatura
        _TipoRecipiente = oRecipiente.TipoRecipiente
        _Status = oRecipiente.Status
        oRecipiente = Nothing
    End Sub

    'Metodo que es llamadado para inicializar la forma al momento de realizar una modificación
    'e inicializa la pantalla con la informacion que se modificara
    Private Sub CargarDatosModificar()
        txtNombre.Text = _Descripcion
        txtInicial.Text = _Abreviatura
        If _Status = "ACTIVO" Then              '20070426CAGP$001
            cboStatus.SelectedIndex = 0
        Else
            cboStatus.SelectedIndex = 1
        End If
        txtCapacidad.Text = _Capacidad
        cboTipoRecipiente.SelectedIndex = _TipoRecipiente - 1

    End Sub

#End Region

    'Evento de la forma para registrar, modificar y consultar la informacion del corporativo
    'es disparado al momento de accesar a ella
    Private Sub frmCapRecipiente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ActiveControl = txtNombre
        cboStatus.SelectedIndex = 0
        cboStatus.Enabled = False
        cboTipoRecipiente.CargaDatosBase("spPTLCargaComboTipoRecipiente", 0, PortatilClasses.Globals.GetInstance._Usuario)
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar Then
            CargarDatosModificar()
            cboTipoRecipiente.Enabled = False
        End If
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Consultar Then
            CargarDatosModificar()
            txtNombre.SelectionStart = 0
            txtNombre.ReadOnly = True
            txtInicial.ReadOnly = True
            txtCapacidad.ReadOnly = True
            cboTipoRecipiente.Enabled = False
        End If
    End Sub

    'Evento del boton Aceptar, este evento se dispara al momento de hacer click en el boton
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar Then
            If ValidarCaptura() Then
                If AlmacenarModificar(1) Then
                    Me.DialogResult() = DialogResult.OK
                    Me.Close()
                End If
            End If
        End If

        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar Then
            If ValidarCaptura() Then
                If AlmacenarModificar(2) Then
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
    Private Sub txtNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown, txtInicial.KeyDown, txtCapacidad.KeyDown
        If (e.KeyData = Keys.Enter) Or (e.KeyData = Keys.Down) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    'Evento para el componente txtNombre y txtInicial, es dispado al momento de
    'presionar cualquier tecla cuando el cursor esta activado en dicho componente
    Private Sub cboStatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboStatus.KeyDown, cboTipoRecipiente.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub
End Class
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmCapTanque
    Inherits System.Windows.Forms.Form

    Public _TipoOperacion As SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo

    Private _Tanque As Integer
    Private _Descripcion As String
    Private _Capacidad As Long
    Private _AlmacenGas As Integer
    Private _TipoAlmacenGas As Short
    'Private GLOBAL_Usuario As String



#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Usuario As String, ByVal TipoAlmacenGas As Short)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        GLOBAL_Usuario = Usuario
        _TipoAlmacenGas = TipoAlmacenGas
    End Sub

    Public Sub New(ByVal TipoAlmacen As Short)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()


        'Add any initialization after the InitializeComponent() call
        _TipoAlmacenGas = TipoAlmacen
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
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents lblCapacidad As System.Windows.Forms.Label
    Friend WithEvents txtCapacidad As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents cboAlmacen As PortatilClasses.Combo.ComboAlmacen
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents tltTanque As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroTanque As System.Windows.Forms.TextBox
    Friend WithEvents ielImagenes As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCapTanque))
        Me.gpbDatosPrincipales = New System.Windows.Forms.GroupBox()
        Me.txtNumeroTanque = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCapacidad = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.cboAlmacen = New PortatilClasses.Combo.ComboAlmacen()
        Me.lblCapacidad = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.ielImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.tltTanque = New System.Windows.Forms.ToolTip(Me.components)
        Me.gpbDatosPrincipales.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpbDatosPrincipales
        '
        Me.gpbDatosPrincipales.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtNumeroTanque, Me.Label1, Me.txtCapacidad, Me.cboAlmacen, Me.lblCapacidad, Me.txtDescripcion, Me.lblAlmacen, Me.lblDescripcion})
        Me.gpbDatosPrincipales.Location = New System.Drawing.Point(10, 8)
        Me.gpbDatosPrincipales.Name = "gpbDatosPrincipales"
        Me.gpbDatosPrincipales.Size = New System.Drawing.Size(470, 144)
        Me.gpbDatosPrincipales.TabIndex = 36
        Me.gpbDatosPrincipales.TabStop = False
        '
        'txtNumeroTanque
        '
        Me.txtNumeroTanque.AutoSize = False
        Me.txtNumeroTanque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroTanque.Location = New System.Drawing.Point(134, 22)
        Me.txtNumeroTanque.MaxLength = 30
        Me.txtNumeroTanque.Name = "txtNumeroTanque"
        Me.txtNumeroTanque.Size = New System.Drawing.Size(314, 21)
        Me.txtNumeroTanque.TabIndex = 1
        Me.txtNumeroTanque.Text = ""
        Me.tltTanque.SetToolTip(Me.txtNumeroTanque, "Descripción del tanque de almacenamiento")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(14, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Número de tanque:"
        '
        'txtCapacidad
        '
        Me.txtCapacidad.AutoSize = False
        Me.txtCapacidad.Location = New System.Drawing.Point(134, 106)
        Me.txtCapacidad.MaxLength = 8
        Me.txtCapacidad.Name = "txtCapacidad"
        Me.txtCapacidad.Size = New System.Drawing.Size(314, 21)
        Me.txtCapacidad.TabIndex = 4
        Me.txtCapacidad.Text = ""
        Me.tltTanque.SetToolTip(Me.txtCapacidad, "Capacidad de almacenamiento del tanque")
        '
        'cboAlmacen
        '
        Me.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen.Location = New System.Drawing.Point(134, 78)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(314, 21)
        Me.cboAlmacen.TabIndex = 3
        Me.tltTanque.SetToolTip(Me.cboAlmacen, "Descripción del almacén de gas")
        '
        'lblCapacidad
        '
        Me.lblCapacidad.AutoSize = True
        Me.lblCapacidad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCapacidad.Location = New System.Drawing.Point(14, 110)
        Me.lblCapacidad.Name = "lblCapacidad"
        Me.lblCapacidad.Size = New System.Drawing.Size(65, 13)
        Me.lblCapacidad.TabIndex = 25
        Me.lblCapacidad.Text = "Capacidad:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.AutoSize = False
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(134, 50)
        Me.txtDescripcion.MaxLength = 30
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(314, 21)
        Me.txtDescripcion.TabIndex = 2
        Me.txtDescripcion.Text = ""
        Me.tltTanque.SetToolTip(Me.txtDescripcion, "Descripción del tanque de almacenamiento")
        '
        'lblAlmacen
        '
        Me.lblAlmacen.AutoSize = True
        Me.lblAlmacen.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblAlmacen.Location = New System.Drawing.Point(14, 82)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(94, 13)
        Me.lblAlmacen.TabIndex = 24
        Me.lblAlmacen.Text = "Almacén de gas:"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescripcion.Location = New System.Drawing.Point(14, 54)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(72, 13)
        Me.lblDescripcion.TabIndex = 22
        Me.lblDescripcion.Text = "Descripción:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 2
        Me.btnCancelar.ImageList = Me.ielImagenes
        Me.btnCancelar.Location = New System.Drawing.Point(496, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.btnAceptar.Location = New System.Drawing.Point(496, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCapTanque
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(594, 168)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnAceptar, Me.gpbDatosPrincipales})
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmCapTanque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tanque de almacenamiento de gas"
        Me.gpbDatosPrincipales.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Metodos y Funciones"

    'Funcion que es llamada antes de almacenar una alta o modificación para verificar
    'que se cumpla con la información mínima para la alta de un tanque
    Private Function ValidarCaptura() As Boolean
        Dim Mensajes As PortatilClasses.Mensaje
        If txtNumeroTanque.TextLength = 0 Then
            Mensajes = New PortatilClasses.Mensaje(52)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ActiveControl = txtNumeroTanque
            Return False
        ElseIf txtDescripcion.TextLength = 0 Then
            Mensajes = New PortatilClasses.Mensaje(38)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ActiveControl = txtDescripcion
            Return False
        ElseIf CType(cboAlmacen.SelectedIndex, Integer) < 0 Then
            Mensajes = New PortatilClasses.Mensaje(39)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ActiveControl = cboAlmacen
            Return False
        ElseIf txtCapacidad.TextLength = 0 Then
            Mensajes = New PortatilClasses.Mensaje(40)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.ActiveControl = txtCapacidad
            Return False
        Else
            Return True
        End If
    End Function

    'Función que para verificar que la capacidad del tanque del almacenamiento no exceda 
    'la capacidad permitda por el almacen de gas
    Function VerificarCapacidadAlmacen(ByVal AlmacenGas As Integer, ByVal Capacidad As Long, ByVal NumeroTanque As String) As Boolean
        Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(1, 0, NumeroTanque, "", 0, AlmacenGas, 0)
        oTanque.VerificarCapacidad()
        If _TipoAlmacenGas = 0 Then
            Dim CapacidadDisponible As Decimal
            If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar Then
                CapacidadDisponible = (oTanque.CapacidadAlmacenGas - oTanque.Capacidad)
            End If
            If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar Then
                If AlmacenGas = _AlmacenGas Then
                    CapacidadDisponible = (oTanque.CapacidadAlmacenGas - (oTanque.Capacidad - _Capacidad))
                Else
                    CapacidadDisponible = (oTanque.CapacidadAlmacenGas - oTanque.Capacidad)
                End If
            End If
            If oTanque.NumeroTanque <> "" Then
                Dim Mensajes As PortatilClasses.Mensaje
                Mensajes = New PortatilClasses.Mensaje(53)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.ActiveControl = txtCapacidad
                Return False
            ElseIf Capacidad > CapacidadDisponible Then
                Dim Mensajes As PortatilClasses.Mensaje
                Mensajes = New PortatilClasses.Mensaje(41)
                MessageBox.Show(Mensajes.Mensaje & CType(CapacidadDisponible, String), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.ActiveControl = txtCapacidad
                Return False
            Else
                Return True
            End If
        ElseIf _TipoAlmacenGas = 1 Then
            If oTanque.Capacidad = 0 Then
                Return True
            Else
                Dim Mensajes As PortatilClasses.Mensaje
                Mensajes = New PortatilClasses.Mensaje(55)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.ActiveControl = cboAlmacen
                Return False
            End If
        End If
    End Function

    'Funcion para registrar y modificar la informacion del tanque
    Function AlmacenarModificarTanque(ByVal Accion As Short) As Boolean
        Dim Resultado As Boolean
        Cursor = Cursors.WaitCursor
        Select Case Accion
            Case Is = 1
                'If VerificarCapacidadAlmacen(cboAlmacen.Identificador, CType(txtCapacidad.Text, Long), txtNumeroTanque.Text) Then
                Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(2, 0, txtNumeroTanque.Text, txtDescripcion.Text, CType(txtCapacidad.Text, Long), cboAlmacen.Identificador, 0)
                oTanque.RegistrarModificarEliminar()
                If oTanque.Tanque > 0 Then
                    Resultado = True
                Else
                    Resultado = False
                End If
                'Else
                'Resultado = False
                'End If
            Case Is = 2
                'If VerificarCapacidadAlmacen(cboAlmacen.Identificador, CType(txtCapacidad.Text, Long)) Then
                '    Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanque(4, _Tanque, txtDescripcion.Text, CType(txtCapacidad.Text, Long), cboAlmacen.Identificador)
                '    oTanque.RegistrarModificarEliminar()
                '    If oTanque.Tanque > 0 Then
                '        Resultado = True
                '    Else
                '        Resultado = False
                '    End If
                'Else
                '    Resultado = False
                'End If
        End Select
        Cursor = Cursors.Default
        Return Resultado
    End Function

    'Metodo que carga las variables de la forma con los datos del tanque de gas
    'va a modificar o se esta consultando
    Public Sub CargarDatosTanque(ByVal Tanque As Integer)
        Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanque(3, Tanque, "", 0, 0)
        oTanque.CargarTanque()
        _Tanque = oTanque.Tanque
        _Descripcion = oTanque.Descripcion
        _Capacidad = oTanque.Capacidad
        _AlmacenGas = oTanque.AlmacenGas
        oTanque = Nothing
    End Sub

    'Metodo que es llamadado para inicializar la forma al momento de realizar una modificación
    'e inicializa la pantalla con la informacion que se modificara
    Private Sub CargarDatosModificar()
        txtDescripcion.Text = _Descripcion
        cboAlmacen.PosicionaCombo(_AlmacenGas)
        txtCapacidad.Text = CType(_Capacidad, String)
    End Sub

#End Region

    'Evento de la forma para registrar, modificar y consultar la informacion del tanque
    'es disparado al momento de accesar a ella 
    Private Sub frmCapCorporativo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ActiveControl = txtNumeroTanque
        If _TipoAlmacenGas = 0 Then
            cboAlmacen.CargaDatos(8, GLOBAL_Usuario)
        ElseIf _TipoAlmacenGas = 1 Then
            cboAlmacen.CargaDatos(10, GLOBAL_Usuario)
        End If

        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar Then
            CargarDatosModificar()
        End If
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Consultar Then
            CargarDatosModificar()
            txtDescripcion.SelectionStart = 0
            txtDescripcion.ReadOnly = True
            cboAlmacen.Enabled = False
            txtCapacidad.ReadOnly = True
        End If
    End Sub

    'Evento del boton Aceptar, este evento se dispara al momento de hacer click en el boton
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar Then
            If ValidarCaptura() Then
                If AlmacenarModificarTanque(1) Then
                    Me.DialogResult() = DialogResult.OK
                    Me.Close()
                End If
            End If
        End If

        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar Then
            If ValidarCaptura() Then
                If AlmacenarModificarTanque(2) Then
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

    'Evento para el componente txtDescripcion y txtCapacidad, es dispado al momento de
    'presionar cualquier tecla cuando el cursor esta activado en dicho componente
    Private Sub txtDescripcion_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumeroTanque.KeyDown, txtDescripcion.KeyDown, txtCapacidad.KeyDown
        If (e.KeyData = Keys.Enter) Or (e.KeyData = Keys.Down) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    'Evento del componenente cboAlmacenGas que es disparado al momento de presionar una tecla
    Private Sub cboAlmacenGas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAlmacen.KeyDown
        Select Case e.KeyData
            Case Is = Keys.Enter
                Me.SelectNextControl(CType(sender, Control), True, True, True, True)
            Case Is = Keys.Delete
                cboAlmacen.PosicionarInicio()
        End Select
    End Sub


End Class
Imports System.Windows.Forms

Public Class frmCambioTripulacion
    Inherits System.Windows.Forms.Form

    Private _AlmacenGas As Integer
    Private _Tripulacion As Integer
    Private _AnoAtt As Short
    Private _Folio As Integer
    Private _Usuario As String
    Private _FVenta As Date
    Private _Ruta As Integer

#Region " Windows Form Designer generated code "


    Public Sub New(ByVal Usuario As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        _Usuario = Usuario
    End Sub



    Public Sub New(ByVal AnoAtt As Short, ByVal Folio As Integer, ByVal AlmacenGas As Integer, ByVal Tripulacion As Integer, ByVal DescripcionAlmacen As String, ByVal Usuario As String, ByVal FVenta As Date, ByVal Ruta As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        _AnoAtt = AnoAtt
        _Folio = Folio
        _AlmacenGas = AlmacenGas
        _Tripulacion = Tripulacion
        _Usuario = Usuario
        lblAlmacenGas.Text = DescripcionAlmacen
        _FVenta = FVenta
        _Ruta = Ruta
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
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTripulacion As System.Windows.Forms.Label
    Friend WithEvents grdTripulacion As System.Windows.Forms.DataGrid
    Friend WithEvents lblAlmacenGas As System.Windows.Forms.Label
    Friend WithEvents lblAlmacenGastck As System.Windows.Forms.Label
    Friend WithEvents dgsTripulacion As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents col01 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col02 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col03 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col04 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col05 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents cboTripulacion As PortatilClasses.Combo.ComboBase
    Friend WithEvents col06 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCambioTripulacion))
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblAlmacenGas = New System.Windows.Forms.Label()
        Me.lblAlmacenGastck = New System.Windows.Forms.Label()
        Me.grdTripulacion = New System.Windows.Forms.DataGrid()
        Me.dgsTripulacion = New System.Windows.Forms.DataGridTableStyle()
        Me.col01 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col02 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col03 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col04 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col05 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col06 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.cboTripulacion = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.lblTripulacion = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdTripulacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(704, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(704, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblAlmacenGas, Me.lblAlmacenGastck, Me.grdTripulacion, Me.cboTripulacion, Me.lblTripulacion})
        Me.GroupBox2.Location = New System.Drawing.Point(9, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(680, 245)
        Me.GroupBox2.TabIndex = 54
        Me.GroupBox2.TabStop = False
        '
        'lblAlmacenGas
        '
        Me.lblAlmacenGas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAlmacenGas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlmacenGas.Location = New System.Drawing.Point(263, 20)
        Me.lblAlmacenGas.Name = "lblAlmacenGas"
        Me.lblAlmacenGas.Size = New System.Drawing.Size(250, 21)
        Me.lblAlmacenGas.TabIndex = 54
        Me.lblAlmacenGas.Text = "AlmacenGas"
        Me.lblAlmacenGas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAlmacenGastck
        '
        Me.lblAlmacenGastck.AutoSize = True
        Me.lblAlmacenGastck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlmacenGastck.Location = New System.Drawing.Point(167, 24)
        Me.lblAlmacenGastck.Name = "lblAlmacenGastck"
        Me.lblAlmacenGastck.Size = New System.Drawing.Size(87, 14)
        Me.lblAlmacenGastck.TabIndex = 53
        Me.lblAlmacenGastck.Text = "Almacén de gas:"
        '
        'grdTripulacion
        '
        Me.grdTripulacion.AccessibleName = ""
        Me.grdTripulacion.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdTripulacion.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdTripulacion.CaptionFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTripulacion.CaptionText = "Detalle de la tripulación"
        Me.grdTripulacion.DataMember = ""
        Me.grdTripulacion.FlatMode = True
        Me.grdTripulacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTripulacion.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTripulacion.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdTripulacion.Location = New System.Drawing.Point(7, 84)
        Me.grdTripulacion.Name = "grdTripulacion"
        Me.grdTripulacion.ReadOnly = True
        Me.grdTripulacion.Size = New System.Drawing.Size(666, 152)
        Me.grdTripulacion.TabIndex = 52
        Me.grdTripulacion.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dgsTripulacion})
        '
        'dgsTripulacion
        '
        Me.dgsTripulacion.DataGrid = Me.grdTripulacion
        Me.dgsTripulacion.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col01, Me.col02, Me.col03, Me.col04, Me.col05, Me.col06})
        Me.dgsTripulacion.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgsTripulacion.MappingName = ""
        '
        'col01
        '
        Me.col01.Format = ""
        Me.col01.FormatInfo = Nothing
        Me.col01.HeaderText = "Categoria"
        Me.col01.MappingName = "DescripcionCategoriaOperador"
        Me.col01.Width = 80
        '
        'col02
        '
        Me.col02.Format = ""
        Me.col02.FormatInfo = Nothing
        Me.col02.HeaderText = "Nómina"
        Me.col02.MappingName = "Operador"
        Me.col02.Width = 55
        '
        'col03
        '
        Me.col03.Format = ""
        Me.col03.FormatInfo = Nothing
        Me.col03.HeaderText = "Nombre del operador"
        Me.col03.MappingName = "Nombre"
        Me.col03.Width = 220
        '
        'col04
        '
        Me.col04.Format = ""
        Me.col04.FormatInfo = Nothing
        Me.col04.HeaderText = "Tipo"
        Me.col04.MappingName = "DescripcionTipoOperador"
        Me.col04.Width = 70
        '
        'col05
        '
        Me.col05.Format = ""
        Me.col05.FormatInfo = Nothing
        Me.col05.HeaderText = "Tipo de asignación"
        Me.col05.MappingName = "DescripcionTipoAsignacionOperador"
        Me.col05.Width = 130
        '
        'col06
        '
        Me.col06.Format = ""
        Me.col06.FormatInfo = Nothing
        Me.col06.HeaderText = "Puesto"
        Me.col06.MappingName = "NombrePuesto"
        Me.col06.Width = 130
        '
        'cboTripulacion
        '
        Me.cboTripulacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTripulacion.Location = New System.Drawing.Point(263, 48)
        Me.cboTripulacion.Name = "cboTripulacion"
        Me.cboTripulacion.Size = New System.Drawing.Size(250, 21)
        Me.cboTripulacion.TabIndex = 1
        '
        'lblTripulacion
        '
        Me.lblTripulacion.AutoSize = True
        Me.lblTripulacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTripulacion.Location = New System.Drawing.Point(190, 52)
        Me.lblTripulacion.Name = "lblTripulacion"
        Me.lblTripulacion.Size = New System.Drawing.Size(63, 14)
        Me.lblTripulacion.TabIndex = 51
        Me.lblTripulacion.Text = "Tripulación:"
        '
        'frmCambioTripulacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 262)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2, Me.btnCancelar, Me.btnAceptar})
        Me.Name = "frmCambioTripulacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio de tripulación"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grdTripulacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Function VerificaTripulacion() As Boolean
        Dim Cargar As Boolean = True
        Dim i As Integer = 0
        Dim Operador As Integer

        Dim oTripulacion As New PortatilClasses.CatalogosPortatil.cTripulacion(1, cboTripulacion.Identificador, False, 0)
        oTripulacion.ConsultarTripulacion()

        While i < oTripulacion.dtTable.Rows.Count
            Operador = CType(oTripulacion.dtTable.Rows(i).Item(2), Integer)

            Dim oExiste As New PortatilClasses.cComisionPortatil(7, _FVenta, Now, _AlmacenGas, _AnoAtt, _Folio, _Ruta, 0, 0, "", Operador)
            oExiste.Consultar()
            If oExiste.Tripulacion > 0 Then
                Cargar = False
                MessageBox.Show("El operador " & Operador & " ya esta asigado al folio " & oExiste.Tripulacion & " no se puede volver a asignar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            i = i + 1
        End While

        Return Cargar
    End Function

    Private Sub CargarDatos()

        Dim oTripulacion As New PortatilClasses.CatalogosPortatil.cTripulacion(1, cboTripulacion.Identificador, False, 0)
        oTripulacion.ConsultarTripulacion()

        grdTripulacion.DataSource = oTripulacion.dtTable

        oTripulacion = Nothing
    End Sub

    Private Sub frmCambioTripulacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboTripulacion.CargaDatosBase("spPTLCargaComboTripulacion", _AlmacenGas, _Usuario)
        cboTripulacion.PosicionaCombo(_Tripulacion)
        CargarDatos()
        Me.ActiveControl = cboTripulacion
    End Sub

    Private Sub cboTripulacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTripulacion.SelectedIndexChanged
        If cboTripulacion.Focused Then
            CargarDatos()
        End If
    End Sub

    Private Sub cboTripulacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTripulacion.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If cboTripulacion.Identificador <> _Tripulacion Then
            If VerificaTripulacion() Then
                Dim oTripulacionCambio As New PortatilClasses.cComisionPortatil(1, Now, Now, _AlmacenGas, _AnoAtt, _Folio, cboTripulacion.Identificador, 0, 0)
                oTripulacionCambio.RegistrarModificarEliminar()
                _Tripulacion = cboTripulacion.Identificador
                Me.DialogResult() = DialogResult.OK
                Me.Close()
            End If

        Else
            Me.DialogResult() = DialogResult.OK
            Me.Close()
        End If


    End Sub
End Class

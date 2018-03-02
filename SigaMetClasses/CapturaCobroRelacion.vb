Option Strict On
Imports System.Data.SqlClient, System.Windows.Forms
Public Class CapturaCobroRelacion
    Inherits System.Windows.Forms.Form
    Private _TablaCobro As DataTable
    Private Titulo As String = "Captura de cobro"

    Public ReadOnly Property TablaCobro() As DataTable
        Get
            Return _TablaCobro
        End Get
    End Property


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
    Friend WithEvents grdCobro As System.Windows.Forms.DataGrid
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFDocumento As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTotal As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtNumeroCuenta As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtDocumento As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtCliente As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents cboTipoCobro As SigaMetClasses.Combos.ComboTipoCobro
    Friend WithEvents cboBanco As SigaMetClasses.Combos.ComboBanco
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents styCobroRelacion As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colCobro As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFDocumento As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colBanco As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTipoCobro As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colNumeroDocumento As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colNumeroCuenta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ttMensaje As System.Windows.Forms.ToolTip
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CapturaCobroRelacion))
        Me.grdCobro = New System.Windows.Forms.DataGrid()
        Me.styCobroRelacion = New System.Windows.Forms.DataGridTableStyle()
        Me.colCobro = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTipoCobro = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFDocumento = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colNumeroDocumento = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colNumeroCuenta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colBanco = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.dtpFDocumento = New System.Windows.Forms.DateTimePicker()
        Me.txtTotal = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtNumeroCuenta = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtDocumento = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboTipoCobro = New SigaMetClasses.Combos.ComboTipoCobro()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboBanco = New SigaMetClasses.Combos.ComboBanco()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.ttMensaje = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.grdCobro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdCobro
        '
        Me.grdCobro.AlternatingBackColor = System.Drawing.Color.White
        Me.grdCobro.BackColor = System.Drawing.Color.White
        Me.grdCobro.BackgroundColor = System.Drawing.Color.Ivory
        Me.grdCobro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.grdCobro.CaptionBackColor = System.Drawing.Color.DarkSlateBlue
        Me.grdCobro.CaptionForeColor = System.Drawing.Color.Lavender
        Me.grdCobro.CaptionText = "Lista de cobros capturados"
        Me.grdCobro.DataMember = ""
        Me.grdCobro.FlatMode = True
        Me.grdCobro.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.grdCobro.ForeColor = System.Drawing.Color.Black
        Me.grdCobro.GridLineColor = System.Drawing.Color.Wheat
        Me.grdCobro.HeaderBackColor = System.Drawing.Color.CadetBlue
        Me.grdCobro.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.grdCobro.HeaderForeColor = System.Drawing.Color.Black
        Me.grdCobro.LinkColor = System.Drawing.Color.DarkSlateBlue
        Me.grdCobro.Location = New System.Drawing.Point(5, 232)
        Me.grdCobro.Name = "grdCobro"
        Me.grdCobro.ParentRowsBackColor = System.Drawing.Color.Ivory
        Me.grdCobro.ParentRowsForeColor = System.Drawing.Color.Black
        Me.grdCobro.ReadOnly = True
        Me.grdCobro.SelectionBackColor = System.Drawing.Color.Wheat
        Me.grdCobro.SelectionForeColor = System.Drawing.Color.DarkSlateBlue
        Me.grdCobro.Size = New System.Drawing.Size(528, 160)
        Me.grdCobro.TabIndex = 11
        Me.grdCobro.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.styCobroRelacion})
        Me.grdCobro.TabStop = False
        '
        'styCobroRelacion
        '
        Me.styCobroRelacion.DataGrid = Me.grdCobro
        Me.styCobroRelacion.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colCobro, Me.colTipoCobro, Me.colFDocumento, Me.colNumeroDocumento, Me.colNumeroCuenta, Me.colBanco, Me.colTotal, Me.colCliente})
        Me.styCobroRelacion.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.styCobroRelacion.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.styCobroRelacion.MappingName = "Cobro"
        Me.styCobroRelacion.ReadOnly = True
        Me.styCobroRelacion.RowHeadersVisible = False
        '
        'colCobro
        '
        Me.colCobro.Format = ""
        Me.colCobro.FormatInfo = Nothing
        Me.colCobro.HeaderText = "Cobro"
        Me.colCobro.MappingName = "Cobro"
        Me.colCobro.Width = 75
        '
        'colTipoCobro
        '
        Me.colTipoCobro.Format = ""
        Me.colTipoCobro.FormatInfo = Nothing
        Me.colTipoCobro.HeaderText = "TipoCobro"
        Me.colTipoCobro.MappingName = "TipoCobro"
        Me.colTipoCobro.Width = 0
        '
        'colFDocumento
        '
        Me.colFDocumento.Format = ""
        Me.colFDocumento.FormatInfo = Nothing
        Me.colFDocumento.HeaderText = "F.Documento"
        Me.colFDocumento.MappingName = "FDocumento"
        Me.colFDocumento.Width = 75
        '
        'colNumeroDocumento
        '
        Me.colNumeroDocumento.Format = ""
        Me.colNumeroDocumento.FormatInfo = Nothing
        Me.colNumeroDocumento.HeaderText = "Documento"
        Me.colNumeroDocumento.MappingName = "NumeroDocumento"
        Me.colNumeroDocumento.Width = 75
        '
        'colNumeroCuenta
        '
        Me.colNumeroCuenta.Format = ""
        Me.colNumeroCuenta.FormatInfo = Nothing
        Me.colNumeroCuenta.HeaderText = "No.Cuenta"
        Me.colNumeroCuenta.MappingName = "NumeroCuenta"
        Me.colNumeroCuenta.Width = 75
        '
        'colBanco
        '
        Me.colBanco.Format = ""
        Me.colBanco.FormatInfo = Nothing
        Me.colBanco.HeaderText = "Banco"
        Me.colBanco.MappingName = "Banco"
        Me.colBanco.Width = 50
        '
        'colTotal
        '
        Me.colTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colTotal.Format = "#,##.00"
        Me.colTotal.FormatInfo = Nothing
        Me.colTotal.HeaderText = "Total"
        Me.colTotal.MappingName = "Total"
        Me.colTotal.Width = 75
        '
        'colCliente
        '
        Me.colCliente.Format = ""
        Me.colCliente.FormatInfo = Nothing
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.MappingName = "Cliente"
        Me.colCliente.Width = 75
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(456, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(456, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFDocumento
        '
        Me.dtpFDocumento.Location = New System.Drawing.Point(136, 56)
        Me.dtpFDocumento.Name = "dtpFDocumento"
        Me.dtpFDocumento.TabIndex = 0
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(136, 152)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(200, 21)
        Me.txtTotal.TabIndex = 4
        Me.txtTotal.Text = ""
        '
        'txtNumeroCuenta
        '
        Me.txtNumeroCuenta.Location = New System.Drawing.Point(136, 128)
        Me.txtNumeroCuenta.Name = "txtNumeroCuenta"
        Me.txtNumeroCuenta.Size = New System.Drawing.Size(200, 21)
        Me.txtNumeroCuenta.TabIndex = 3
        Me.txtNumeroCuenta.Text = ""
        '
        'txtDocumento
        '
        Me.txtDocumento.Location = New System.Drawing.Point(136, 104)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(200, 21)
        Me.txtDocumento.TabIndex = 2
        Me.txtDocumento.Text = ""
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(136, 176)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(200, 21)
        Me.txtCliente.TabIndex = 5
        Me.txtCliente.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 14)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Fecha del documento:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "No. de documento:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 14)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Total:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 14)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "No. de cuenta:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 179)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 14)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Cliente:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTipoCobro
        '
        Me.cboTipoCobro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCobro.Location = New System.Drawing.Point(136, 200)
        Me.cboTipoCobro.Name = "cboTipoCobro"
        Me.cboTipoCobro.Size = New System.Drawing.Size(200, 21)
        Me.cboTipoCobro.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 203)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 14)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Tipo de cobro:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBanco
        '
        Me.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBanco.Location = New System.Drawing.Point(136, 80)
        Me.cboBanco.Name = "cboBanco"
        Me.cboBanco.Size = New System.Drawing.Size(200, 21)
        Me.cboBanco.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 14)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Banco:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Bitmap)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(424, 200)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.TabIndex = 7
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttMensaje.SetToolTip(Me.btnAgregar, "Agregar cobro a la lista")
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label8.Location = New System.Drawing.Point(16, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(432, 40)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Teclee los datos para los cobros que necesite dar de alta.  Un cobro es un docume" & _
        "nto que sirve de pago a uno o más documentos de crédito."
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Bitmap)
        Me.btnEliminar.Location = New System.Drawing.Point(504, 200)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(24, 23)
        Me.btnEliminar.TabIndex = 8
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttMensaje.SetToolTip(Me.btnEliminar, "Eliminar cobro de la lista")
        '
        'CapturaCobroRelacion
        '
        Me.AcceptButton = Me.btnAgregar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(538, 399)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnEliminar, Me.Label8, Me.btnAgregar, Me.Label7, Me.cboBanco, Me.Label6, Me.cboTipoCobro, Me.Label5, Me.Label3, Me.Label4, Me.Label2, Me.Label1, Me.txtCliente, Me.txtDocumento, Me.txtNumeroCuenta, Me.txtTotal, Me.dtpFDocumento, Me.btnCancelar, Me.btnAceptar, Me.grdCobro})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CapturaCobroRelacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de cobro"
        CType(Me.grdCobro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Tabla de Cobro"
    Public Function CreaTablaCobroRelacion() As DataTable
        Cursor = Cursors.WaitCursor
        Dim dtTablaCobro As New DataTable("Cobro")
        Dim ColumnaTabla As DataColumn

        ColumnaTabla = New DataColumn("Cobro")
        ColumnaTabla.Unique = True
        ColumnaTabla.DataType = Type.GetType("System.Int16")
        ColumnaTabla.ReadOnly = True
        ColumnaTabla.AllowDBNull = False
        ColumnaTabla.AutoIncrement = True
        ColumnaTabla.AutoIncrementSeed = 1
        ColumnaTabla.AutoIncrementStep = 1
        dtTablaCobro.Columns.Add(ColumnaTabla)

        ColumnaTabla = New DataColumn("FDocumento")
        ColumnaTabla.DataType = Type.GetType("System.DateTime")
        ColumnaTabla.AllowDBNull = False
        ColumnaTabla.DefaultValue = Now.Date
        dtTablaCobro.Columns.Add(ColumnaTabla)

        ColumnaTabla = New DataColumn("Banco")
        ColumnaTabla.DataType = Type.GetType("System.Int16")
        ColumnaTabla.AllowDBNull = False
        dtTablaCobro.Columns.Add(ColumnaTabla)

        ColumnaTabla = New DataColumn("TipoCobro")
        ColumnaTabla.DataType = Type.GetType("System.Byte")
        ColumnaTabla.AllowDBNull = False
        ColumnaTabla.ReadOnly = True
        dtTablaCobro.Columns.Add(ColumnaTabla)

        ColumnaTabla = New DataColumn("NumeroDocumento")
        ColumnaTabla.DataType = Type.GetType("System.String")
        dtTablaCobro.Columns.Add(ColumnaTabla)

        ColumnaTabla = New DataColumn("NumeroCuenta")
        ColumnaTabla.DataType = Type.GetType("System.String")
        dtTablaCobro.Columns.Add(ColumnaTabla)

        ColumnaTabla = New DataColumn("Cliente")
        ColumnaTabla.DataType = Type.GetType("System.Int32")
        ColumnaTabla.AllowDBNull = False
        dtTablaCobro.Columns.Add(ColumnaTabla)

        ColumnaTabla = New DataColumn("Total")
        ColumnaTabla.DataType = Type.GetType("System.Decimal")
        ColumnaTabla.AllowDBNull = False
        ColumnaTabla.DefaultValue = 0
        dtTablaCobro.Columns.Add(ColumnaTabla)

        ColumnaTabla = New DataColumn("Saldo")
        ColumnaTabla.DataType = Type.GetType("System.Decimal")
        ColumnaTabla.AllowDBNull = False
        ColumnaTabla.DefaultValue = 0
        dtTablaCobro.Columns.Add(ColumnaTabla)

        Dim ColumnaPK(0) As DataColumn
        ColumnaPK(0) = dtTablaCobro.Columns("Cobro")
        dtTablaCobro.PrimaryKey = ColumnaPK

        Dim LlaveUnica As New UniqueConstraint("UN_Cobro", New DataColumn() _
                                    {dtTablaCobro.Columns("Banco"), _
                                    dtTablaCobro.Columns("Cliente"), _
                                    dtTablaCobro.Columns("NumeroDocumento")})

        dtTablaCobro.Constraints.Add(LlaveUnica)

        Cursor = Cursors.Default

        Return dtTablaCobro
    End Function
#End Region

#Region "Validación de captura"
    Private Function ValidaCaptura() As Boolean
        If Trim(txtDocumento.Text) = String.Empty Then
            MessageBox.Show("Debe teclear el número de documento.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocumento.SelectAll()
            txtDocumento.Focus()
            Return False
        End If
        If CType(Me.cboTipoCobro.SelectedValue, Byte) = 3 And Len(Trim(txtDocumento.Text)) <> 4 Then
            MessageBox.Show("El número de cheque debe ser de 4 dígitos.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocumento.SelectAll()
            txtDocumento.Focus()
            Return False
        End If
        If txtNumeroCuenta.Text = String.Empty Then
            MessageBox.Show("Debe teclear el número de cuenta.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNumeroCuenta.SelectAll()
            txtNumeroCuenta.Focus()
            Return False
        End If
        If txtTotal.Text = String.Empty Then
            MessageBox.Show("Debe teclear el importe del documento.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTotal.SelectAll()
            txtTotal.Focus()
            Return False
        End If
        If txtCliente.Text = String.Empty Then
            MessageBox.Show("Debe teclear el número de cliente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCliente.SelectAll()
            txtCliente.Focus()
            Return False
        End If

        Return True
    End Function
#End Region

    Private Sub CapturaCobroRelacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboTipoCobro.CargaDatos(True, False)
        cboTipoCobro.SelectedValue = 3
        cboBanco.CargaDatos(True, True, True)
        _TablaCobro = CreaTablaCobroRelacion()
        grdCobro.DataSource = _TablaCobro
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub Agrega()
        Dim dr As DataRow = _TablaCobro.NewRow
        dr("Banco") = CType(cboBanco.SelectedValue, Short)
        dr("NumeroDocumento") = Trim(txtDocumento.Text)
        dr("NumeroCuenta") = Trim(txtNumeroCuenta.Text)
        dr("Total") = CType(txtTotal.Text, Decimal)
        dr("Saldo") = CType(txtTotal.Text, Decimal)
        dr("Cliente") = CType(txtCliente.Text, Integer)
        dr("TipoCobro") = CType(cboTipoCobro.SelectedValue, Byte)

        Try
            _TablaCobro.Rows.Add(dr)
            grdCobro.CaptionText = "Lista de cobros (" & _TablaCobro.Rows.Count.ToString & " en total)"
        Catch ex As ConstraintException
            MessageBox.Show("Existe un cobro duplicado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub Limpia()
        txtDocumento.Text = String.Empty
        txtNumeroCuenta.Text = String.Empty
        txtTotal.Text = String.Empty
        txtCliente.Text = String.Empty
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub grdCobro_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCobro.CurrentCellChanged
        Limpia()
        grdCobro.Select(grdCobro.CurrentRowIndex)

        cboTipoCobro.SelectedValue = CType(grdCobro.Item(grdCobro.CurrentRowIndex, 1), Byte)
        dtpFDocumento.Value = CType(grdCobro.Item(grdCobro.CurrentRowIndex, 2), Date)
        txtDocumento.Text = CType(grdCobro.Item(grdCobro.CurrentRowIndex, 3), String)
        txtNumeroCuenta.Text = CType(grdCobro.Item(grdCobro.CurrentRowIndex, 4), String)
        cboBanco.SelectedValue = CType(grdCobro.Item(grdCobro.CurrentRowIndex, 5), String)
        txtTotal.Text = CType(grdCobro.Item(grdCobro.CurrentRowIndex, 6), String)
        txtCliente.Text = CType(grdCobro.Item(grdCobro.CurrentRowIndex, 7), String)
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If ValidaCaptura() Then
            Agrega()
            Limpia()
        End If
    End Sub
End Class

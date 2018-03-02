Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections.Generic

Public Class frmLiquidacionConsulta
    Inherits System.Windows.Forms.Form
    Private _AnoAtt As Short
    Private _Folio As Integer
    Private _AlmacenGas As Integer
    Private _Corporativo As Integer
    Private _MovimientoAlmacen As Integer
    Private _NDocumento As Integer
    Private _dtLiquidacion As DataTable
    Private _drLiquidacionCarga As DataRow()
    Private _StatusLogistica As String

    Private _Usuario As String
    Private _Empleado As Integer
    Private _CorporativoUsuario As Short
    Private _SucursalUsuario As Short
    Private _CajaUsuario As Byte
    Private _FactorDensidad As Decimal


    Private _Servidor As String
    Private _Database As String
    Private _Password As String

    Private _EmpresaComisionista As String
    Private _ReglaHoraLiquidar As String = "0"
    Private _MaxHoraLiquidar As String = "00:00"
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCelula As System.Windows.Forms.ComboBox

    Public Shadows Validated As Boolean

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
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents grdPreLiq As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colFolio As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCelula As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colRuta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFCarga As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFAlta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCorporativo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colAlmacenGas As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCamion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colOrden As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colAnoAtt As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFVenta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnIngresos As System.Windows.Forms.Button
    Friend WithEvents btnValidar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLiquidacionConsulta))
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.chkTodas = New System.Windows.Forms.CheckBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.grdPreLiq = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colCorporativo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCelula = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colAlmacenGas = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRuta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCamion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colOrden = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colAnoAtt = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFolio = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFCarga = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFVenta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFAlta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnIngresos = New System.Windows.Forms.Button()
        Me.btnValidar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCelula = New System.Windows.Forms.ComboBox()
        CType(Me.grdPreLiq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(584, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 4
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(496, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkTodas
        '
        Me.chkTodas.Location = New System.Drawing.Point(18, 42)
        Me.chkTodas.Name = "chkTodas"
        Me.chkTodas.Size = New System.Drawing.Size(336, 21)
        Me.chkTodas.TabIndex = 14
        Me.chkTodas.Text = "Consultar todas las liquidaciones pendientes"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(402, 7)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 13
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Del día:"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(80, 9)
        Me.dtpFecha.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(111, 21)
        Me.dtpFecha.TabIndex = 11
        Me.dtpFecha.Value = New Date(2011, 1, 20, 0, 0, 0, 0)
        '
        'grdPreLiq
        '
        Me.grdPreLiq.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdPreLiq.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdPreLiq.CaptionText = "Liquidaciones a realizar"
        Me.grdPreLiq.DataMember = ""
        Me.grdPreLiq.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdPreLiq.Location = New System.Drawing.Point(8, 68)
        Me.grdPreLiq.Name = "grdPreLiq"
        Me.grdPreLiq.ReadOnly = True
        Me.grdPreLiq.Size = New System.Drawing.Size(648, 368)
        Me.grdPreLiq.TabIndex = 10
        Me.grdPreLiq.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.grdPreLiq
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colCorporativo, Me.colCelula, Me.colAlmacenGas, Me.colRuta, Me.colCamion, Me.colOrden, Me.colAnoAtt, Me.colFolio, Me.colFCarga, Me.colFVenta, Me.colFAlta})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        '
        'colCorporativo
        '
        Me.colCorporativo.Format = ""
        Me.colCorporativo.FormatInfo = Nothing
        Me.colCorporativo.HeaderText = "Corporativo"
        Me.colCorporativo.MappingName = "NombreCorporativo"
        Me.colCorporativo.Width = 125
        '
        'colCelula
        '
        Me.colCelula.Format = ""
        Me.colCelula.FormatInfo = Nothing
        Me.colCelula.HeaderText = "Célula"
        Me.colCelula.MappingName = "DescripcionCelula"
        Me.colCelula.Width = 125
        '
        'colAlmacenGas
        '
        Me.colAlmacenGas.Format = ""
        Me.colAlmacenGas.FormatInfo = Nothing
        Me.colAlmacenGas.HeaderText = "Almacén de gas"
        Me.colAlmacenGas.MappingName = "DescripcionAlmacenGas"
        Me.colAlmacenGas.Width = 150
        '
        'colRuta
        '
        Me.colRuta.Format = ""
        Me.colRuta.FormatInfo = Nothing
        Me.colRuta.HeaderText = "Ruta"
        Me.colRuta.MappingName = "DescripcionRuta"
        Me.colRuta.Width = 60
        '
        'colCamion
        '
        Me.colCamion.Format = ""
        Me.colCamion.FormatInfo = Nothing
        Me.colCamion.HeaderText = "Camión"
        Me.colCamion.MappingName = "Autotanque"
        Me.colCamion.Width = 45
        '
        'colOrden
        '
        Me.colOrden.Format = ""
        Me.colOrden.FormatInfo = Nothing
        Me.colOrden.HeaderText = "Orden"
        Me.colOrden.MappingName = "Orden"
        Me.colOrden.Width = 75
        '
        'colAnoAtt
        '
        Me.colAnoAtt.Format = ""
        Me.colAnoAtt.FormatInfo = Nothing
        Me.colAnoAtt.HeaderText = "Año carga"
        Me.colAnoAtt.MappingName = "AñoAtt"
        Me.colAnoAtt.Width = 65
        '
        'colFolio
        '
        Me.colFolio.Format = ""
        Me.colFolio.FormatInfo = Nothing
        Me.colFolio.HeaderText = "Folio"
        Me.colFolio.MappingName = "Folio"
        Me.colFolio.Width = 55
        '
        'colFCarga
        '
        Me.colFCarga.Format = ""
        Me.colFCarga.FormatInfo = Nothing
        Me.colFCarga.HeaderText = "Fecha de carga"
        Me.colFCarga.MappingName = "FMovimiento"
        Me.colFCarga.Width = 120
        '
        'colFVenta
        '
        Me.colFVenta.Format = ""
        Me.colFVenta.FormatInfo = Nothing
        Me.colFVenta.HeaderText = "Fecha de Venta"
        Me.colFVenta.MappingName = "FInicioRuta"
        Me.colFVenta.Width = 105
        '
        'colFAlta
        '
        Me.colFAlta.Format = ""
        Me.colFAlta.FormatInfo = Nothing
        Me.colFAlta.HeaderText = "Fecha de alta"
        Me.colFAlta.MappingName = "FAlta"
        Me.colFAlta.Width = 120
        '
        'btnIngresos
        '
        Me.btnIngresos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIngresos.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.btnIngresos.Image = CType(resources.GetObject("btnIngresos.Image"), System.Drawing.Image)
        Me.btnIngresos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIngresos.Location = New System.Drawing.Point(584, 40)
        Me.btnIngresos.Name = "btnIngresos"
        Me.btnIngresos.Size = New System.Drawing.Size(75, 23)
        Me.btnIngresos.TabIndex = 15
        Me.btnIngresos.TabStop = False
        Me.btnIngresos.Text = "NI Captura"
        Me.btnIngresos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnValidar
        '
        Me.btnValidar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnValidar.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.btnValidar.Image = CType(resources.GetObject("btnValidar.Image"), System.Drawing.Image)
        Me.btnValidar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnValidar.Location = New System.Drawing.Point(496, 40)
        Me.btnValidar.Name = "btnValidar"
        Me.btnValidar.Size = New System.Drawing.Size(75, 23)
        Me.btnValidar.TabIndex = 16
        Me.btnValidar.TabStop = False
        Me.btnValidar.Text = "NI Valida"
        Me.btnValidar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 5000
        Me.ToolTip1.InitialDelay = 100
        Me.ToolTip1.ReshowDelay = 100
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(204, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Celula: "
        '
        'cmbCelula
        '
        Me.cmbCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCelula.FormattingEnabled = True
        Me.cmbCelula.Location = New System.Drawing.Point(257, 7)
        Me.cmbCelula.Name = "cmbCelula"
        Me.cmbCelula.Size = New System.Drawing.Size(121, 21)
        Me.cmbCelula.TabIndex = 18
        '
        'frmLiquidacionConsulta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(664, 445)
        Me.Controls.Add(Me.cmbCelula)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnValidar)
        Me.Controls.Add(Me.btnIngresos)
        Me.Controls.Add(Me.chkTodas)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.grdPreLiq)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmLiquidacionConsulta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de liquidaciones pendientes - Portátil"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdPreLiq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Public Sub New(ByVal Usuario As String, ByVal Empleado As Integer, ByVal CajaUsuario As Byte, ByVal FactorDensidad As Decimal, ByVal Servidor As String, ByVal DBase As String, ByVal Password As String, ByVal CorporativoUsuario As Short, ByVal SucursalUsuario As Short)
        MyBase.New()
        InitializeComponent()
        _Usuario = Usuario
        _Empleado = Empleado
        _CajaUsuario = CajaUsuario
        _FactorDensidad = FactorDensidad
        _Servidor = Servidor
        _Database = DBase
        _Password = Password
        _CorporativoUsuario = CorporativoUsuario
        _SucursalUsuario = SucursalUsuario

        Dim oConfig As New SigaMetClasses.cConfig(16, _CorporativoUsuario, _SucursalUsuario)
        _EmpresaComisionista = CType(oConfig.Parametros("EmpresaComisionista"), String).Trim

        If _CajaUsuario = 0 Then
            Dim Mensajes As New PortatilClasses.Mensaje(117)
            MessageBox.Show(Mensajes.Mensaje, "Liquidación portátil", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Validated = False
        ElseIf _Empleado = 0 Then
            Dim Mensajes As New PortatilClasses.Mensaje(118)
            MessageBox.Show(Mensajes.Mensaje, "Liquidación portátil", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Validated = False
        Else
            Me.Validated = True
        End If

        If _EmpresaComisionista = "1" Then
            btnIngresos.Visible = True
            btnValidar.Visible = True

        Else
            btnIngresos.Visible = False
            btnValidar.Visible = False

        End If

        Dim oParametro As New SigaMetClasses.cConfig(3, _CorporativoUsuario, _SucursalUsuario)
        _ReglaHoraLiquidar = CType(oParametro.Parametros("ReglaHoraLiquidacionPort"), String).Trim
        _MaxHoraLiquidar = CType(oParametro.Parametros("MaxHoraLiquidacionPort"), String).Trim



        Dim CelulasUsuario As Boolean
        Dim m_metodos As New MetodoDatos
        CelulasUsuario = m_metodos.ValidarParametroCelulasUsuario(SigaMetClasses.DataLayer.Conexion)

        Dim celulas As New List(Of Celula)

        If (CelulasUsuario) Then
            celulas = m_metodos.ConsultaCelulasPorUsusario(SigaMetClasses.DataLayer.Conexion, Usuario)            
        Else
            celulas = m_metodos.ConsultaTodasLasCelulas(SigaMetClasses.DataLayer.Conexion, Usuario)
        End If

        cmbCelula.DataSource = celulas
        cmbCelula.DisplayMember = "DescripcionCelula"
        cmbCelula.ValueMember = "IdCelula"
    End Sub

    Private Sub RealizarBusqueda()
        Dim celulaConsulta As Integer = 0
        If cmbCelula.SelectedIndex <> -1 Then
            celulaConsulta = CInt(cmbCelula.SelectedValue)
        End If

        If _EmpresaComisionista = "0" Then
            If chkTodas.Checked Then
                Dim oLiquidacion As New PortatilClasses.cLiquidacion(1, dtpFecha.Value.Date, 0, 0, celulaConsulta)
                oLiquidacion.ConsultaLiquidacion()
                _dtLiquidacion = oLiquidacion.dtTable
                grdPreLiq.DataSource = _dtLiquidacion
            Else
                Dim oLiquidacion As New PortatilClasses.cLiquidacion(0, dtpFecha.Value.Date, 0, 0, celulaConsulta)
                oLiquidacion.ConsultaLiquidacion()
                _dtLiquidacion = oLiquidacion.dtTable
                grdPreLiq.DataSource = _dtLiquidacion
            End If
        End If
        If _EmpresaComisionista = "1" Then
            If chkTodas.Checked Then
                Dim oLiquidacion As New PortatilClasses.cLiquidacion(3, dtpFecha.Value.Date, 0, 0)
                oLiquidacion.ConsultaLiquidacion()
                _dtLiquidacion = oLiquidacion.dtTable
                grdPreLiq.DataSource = _dtLiquidacion
            Else
                Dim oLiquidacion As New PortatilClasses.cLiquidacion(2, dtpFecha.Value.Date, 0, 0)
                oLiquidacion.ConsultaLiquidacion()
                _dtLiquidacion = oLiquidacion.dtTable
                grdPreLiq.DataSource = _dtLiquidacion
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        RealizarBusqueda()
        grdPreLiq_CurrentCellChanged(grdPreLiq, e)
    End Sub

    Private Sub chkTodas_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkTodas.CheckedChanged
        dtpFecha.Enabled = Not chkTodas.Checked
    End Sub

    Private Sub grdPreLiq_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPreLiq.CurrentCellChanged
        If _dtLiquidacion.Rows.Count > 0 Then
            'LUSATE 01/12/2015 Se comentan líneas por modificaciones para ordenamiento de registros
            '_drLiquidacionCarga = _dtLiquidacion.Select("Folio = " & CType(_dtLiquidacion.Rows(grdPreLiq.CurrentRowIndex).Item(2), String), "")
            _drLiquidacionCarga = _dtLiquidacion.Select("Folio = " & CType(grdPreLiq.Item(grdPreLiq.CurrentRowIndex, 7), String), "")
            grdPreLiq.Select(grdPreLiq.CurrentRowIndex)
            '_AnoAtt = CType(_dtLiquidacion.Rows(grdPreLiq.CurrentRowIndex).Item(0), Short)
            '_Folio = CType(_dtLiquidacion.Rows(grdPreLiq.CurrentRowIndex).Item(2), Integer)
            '_AlmacenGas = CType(_dtLiquidacion.Rows(grdPreLiq.CurrentRowIndex).Item(12), Integer)
            '_Corporativo = CType(_dtLiquidacion.Rows(grdPreLiq.CurrentRowIndex).Item(23), Integer)
            '_MovimientoAlmacen = CType(_dtLiquidacion.Rows(grdPreLiq.CurrentRowIndex).Item(10), Integer)
            '_NDocumento = CType(_dtLiquidacion.Rows(grdPreLiq.CurrentRowIndex).Item(24), Integer)
            '_StatusLogistica = CType(_dtLiquidacion.Rows(grdPreLiq.CurrentRowIndex).Item(6), String)

            _AnoAtt = CType(_drLiquidacionCarga(0).Item(0), Short)
            _Folio = CType(_drLiquidacionCarga(0).Item(2), Integer)
            _AlmacenGas = CType(_drLiquidacionCarga(0).Item(12), Integer)
            _Corporativo = CType(_drLiquidacionCarga(0).Item(23), Integer)
            _MovimientoAlmacen = CType(_drLiquidacionCarga(0).Item(10), Integer)
            _NDocumento = CType(_drLiquidacionCarga(0).Item(24), Integer)
            _StatusLogistica = CType(_drLiquidacionCarga(0).Item(6), String)            

            If (_AnoAtt <> 0 And _Folio <> 0) Then
                btnAceptar.Enabled = True
            Else
                btnAceptar.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim _Copias As String = "1"
        Dim _FormaImprimir As String = "1"
        If _EmpresaComisionista = "0" Then
            Dim oConfig As New SigaMetClasses.cConfig(16, _CorporativoUsuario, _SucursalUsuario)
            _Copias = CType(oConfig.Parametros("NumeroImpresion"), String).Trim
            _FormaImprimir = CType(oConfig.Parametros("FormaImprimir"), String).Trim
            Dim FechaMin, FechaMax, FechaLiq As DateTime
            FechaLiq = CType(_drLiquidacionCarga(0).Item(3), DateTime)
            If FechaLiq > Now Then
                FechaMax = FechaLiq.AddHours(Now.Hour).AddMinutes(Now.Minute)
                FechaMin = FechaLiq.AddHours(Now.Hour).AddMinutes(Now.Minute).AddDays(-CType(CType(oConfig.Parametros("NumDiasLiquidacion"), String).Trim, Double))
            Else
                FechaMax = Now
                FechaMin = Now.AddDays(-CType(CType(oConfig.Parametros("NumDiasLiquidacion"), String).Trim, Double))
            End If
            'If FechaLiq >= FechaMin And FechaLiq <= FechaMax Then
            If FechaLiq >= CDate("01/02/2015") And FechaLiq <= FechaMax Then
                Dim frmLiquidacionPortatil As New frmLiquidacionPortatil(_AnoAtt, _Folio, _AlmacenGas, _Corporativo, _MovimientoAlmacen, _NDocumento, _drLiquidacionCarga, _Usuario, _Empleado, _CajaUsuario, _FactorDensidad, _Servidor, _Database, _Password, _CorporativoUsuario, _SucursalUsuario, _ReglaHoraLiquidar, _MaxHoraLiquidar)
                frmLiquidacionPortatil._Copias = CType(_Copias, Integer)
                frmLiquidacionPortatil._FormaImprimir = _FormaImprimir
                If frmLiquidacionPortatil.ShowDialog() = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    btnBuscar_Click(btnBuscar, e)
                    Cursor = Cursors.Default
                End If
            Else
                Dim Mensajes As New PortatilClasses.Mensaje(125)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        If _EmpresaComisionista = "1" Then
            If _StatusLogistica = "INICIO" Then
                Dim frmLiquidacionPortatilComisionista As New frmLiquidacionPortatilComisionista(_AnoAtt, _Folio, _AlmacenGas, _Corporativo, _MovimientoAlmacen, _NDocumento, _drLiquidacionCarga, _Usuario, _Empleado, _CajaUsuario, _FactorDensidad, _Servidor, _Database, _Password, _CorporativoUsuario, _SucursalUsuario)
                If frmLiquidacionPortatilComisionista.ShowDialog() = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    btnBuscar_Click(btnBuscar, e)
                    Cursor = Cursors.Default
                End If
            Else
                Dim frmLiquidacionPortatilComisionista As New frmLiquidacionCyC(_AnoAtt, _Folio, _AlmacenGas, _Corporativo, _MovimientoAlmacen, _NDocumento, _drLiquidacionCarga, _Usuario, _Empleado, _CajaUsuario, _FactorDensidad, _Servidor, _Database, _Password, _CorporativoUsuario, _SucursalUsuario)
                If frmLiquidacionPortatilComisionista.ShowDialog() = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    btnBuscar_Click(btnBuscar, e)
                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub frmLiquidacionConsulta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFecha.Value = Now
        Dim ToolTip1 As New ToolTip()
        ToolTip1.SetToolTip(btnValidar, "Validar nota de ingreso de abonos de préstamos a comisionistas")
        Dim ToolTip2 As New ToolTip()
        ToolTip2.SetToolTip(btnIngresos, "Capturar nota de ingreso de abonos de préstamos a comisionistas")
    End Sub


    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oIngresos As New frmAbonosExtraordinarios(_Usuario, _CajaUsuario, _Servidor, _Database, _Password, _CorporativoUsuario, _SucursalUsuario)
        oIngresos.ShowDialog()
    End Sub

    Private Sub btnIngresos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresos.Click
        Dim oIngresos As New frmAbonosExtraordinarios(_Usuario, _CajaUsuario, _Servidor, _Database, _Password, _CorporativoUsuario, _SucursalUsuario)
        oIngresos.ShowDialog()
    End Sub

    Private Sub btnValidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidar.Click
        Dim oConsulta As New frmConsultarAbonos(_Usuario, _Empleado, CType(_CajaUsuario, Byte), _FactorDensidad, _Servidor, _Database, _Password, CType(_EmpresaComisionista, Short), _SucursalUsuario)
        oConsulta.ShowDialog()
    End Sub


    Private Sub cmbCelula_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCelula.SelectedIndexChanged
        'If Not cmbCelula.SelectedIndex = Nothing Then
        '    'FiltrarFoliosPorCelula()
        'End If
    End Sub
End Class

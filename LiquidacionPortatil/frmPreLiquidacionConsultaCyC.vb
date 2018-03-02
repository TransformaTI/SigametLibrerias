Imports System.Windows.Forms
Imports System.Drawing

Public Class frmPreLiquidacionConsultaCyC
    Inherits System.Windows.Forms.Form
    Private _AnoAtt As Short
    Private _Folio As Integer
    Private _AlmacenGas As Integer
    Private _Corporativo As Integer
    Private _MovimientoAlmacen As Integer
    Private _NDocumento As Integer
    Private _dtLiquidacion As DataTable
    Private _drLiquidacionCarga As DataRow()

    Private _Usuario As String
    Private _Empleado As Integer
    Private _CorporativoUsuario As Short
    Private _SucursalUsuario As Short
    Private _CajaUsuario As Byte
    Private _FactorDensidad As Decimal


    Private _Servidor As String
    Private _Database As String
    Private _Password As String

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
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents grdPreLiq As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colCorporativo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colAlmacenGas As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colRuta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colAnoAtt As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFolio As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFCarga As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFAlta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPreLiquidacionConsultaCyC))
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.grdPreLiq = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colCorporativo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colAlmacenGas = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRuta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colAnoAtt = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFolio = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFCarga = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFAlta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.chkTodas = New System.Windows.Forms.CheckBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        CType(Me.grdPreLiq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpFecha
        '
        Me.dtpFecha.Location = New System.Drawing.Point(80, 10)
        Me.dtpFecha.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(248, 21)
        Me.dtpFecha.TabIndex = 18
        Me.dtpFecha.Value = New Date(2011, 1, 20, 0, 0, 0, 0)
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Célula"
        Me.DataGridTextBoxColumn1.MappingName = "DescripcionCelula"
        Me.DataGridTextBoxColumn1.Width = 125
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Camión"
        Me.DataGridTextBoxColumn2.MappingName = "Autotanque"
        Me.DataGridTextBoxColumn2.Width = 45
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Orden"
        Me.DataGridTextBoxColumn3.MappingName = "Orden"
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Fecha de Venta"
        Me.DataGridTextBoxColumn4.MappingName = "FInicioRuta"
        Me.DataGridTextBoxColumn4.Width = 105
        '
        'grdPreLiq
        '
        Me.grdPreLiq.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdPreLiq.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdPreLiq.CaptionText = "Liquidaciones a realizar"
        Me.grdPreLiq.DataMember = ""
        Me.grdPreLiq.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdPreLiq.Location = New System.Drawing.Point(8, 69)
        Me.grdPreLiq.Name = "grdPreLiq"
        Me.grdPreLiq.ReadOnly = True
        Me.grdPreLiq.Size = New System.Drawing.Size(648, 368)
        Me.grdPreLiq.TabIndex = 17
        Me.grdPreLiq.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AllowSorting = False
        Me.DataGridTableStyle1.DataGrid = Me.grdPreLiq
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colCorporativo, Me.DataGridTextBoxColumn1, Me.colAlmacenGas, Me.colRuta, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.colAnoAtt, Me.colFolio, Me.colFCarga, Me.DataGridTextBoxColumn4, Me.colFAlta})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = ""
        '
        'colCorporativo
        '
        Me.colCorporativo.Format = ""
        Me.colCorporativo.FormatInfo = Nothing
        Me.colCorporativo.HeaderText = "Corporativo"
        Me.colCorporativo.MappingName = "NombreCorporativo"
        Me.colCorporativo.Width = 125
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
        'colFAlta
        '
        Me.colFAlta.Format = ""
        Me.colFAlta.FormatInfo = Nothing
        Me.colFAlta.HeaderText = "Fecha de alta"
        Me.colFAlta.MappingName = "FAlta"
        Me.colFAlta.Width = 120
        '
        'chkTodas
        '
        Me.chkTodas.Location = New System.Drawing.Point(80, 37)
        Me.chkTodas.Name = "chkTodas"
        Me.chkTodas.Size = New System.Drawing.Size(336, 21)
        Me.chkTodas.TabIndex = 21
        Me.chkTodas.Text = "Consultar todas las liquidaciones pendientes"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(344, 9)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.TabIndex = 20
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 14)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Del día:"
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(584, 9)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.TabIndex = 16
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(496, 9)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 15
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmPreLiquidacionConsultaCyC
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(666, 447)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpFecha, Me.grdPreLiq, Me.chkTodas, Me.btnBuscar, Me.Label1, Me.btnCerrar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmPreLiquidacionConsultaCyC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Preliquidación de cargas portátil de crédito"
        CType(Me.grdPreLiq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

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

        If _Empleado = 0 Then
            Dim Mensajes As New PortatilClasses.Mensaje(118)
            MessageBox.Show(Mensajes.Mensaje, "Liquidación portátil", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Validated = False
        Else
            Me.Validated = True
        End If
    End Sub

    Private Sub RealizarBusqueda()
        If chkTodas.Checked Then
            Dim oLiquidacion As New PortatilClasses.cLiquidacion(1, dtpFecha.Value.Date, 0, 0)
            oLiquidacion.ConsultaLiquidacion()
            _dtLiquidacion = oLiquidacion.dtTable
            grdPreLiq.DataSource = _dtLiquidacion
        Else
            Dim oLiquidacion As New PortatilClasses.cLiquidacion(0, dtpFecha.Value.Date, 0, 0)
            oLiquidacion.ConsultaLiquidacion()
            _dtLiquidacion = oLiquidacion.dtTable
            grdPreLiq.DataSource = _dtLiquidacion
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
            _drLiquidacionCarga = _dtLiquidacion.Select("Folio = " & CType(_dtLiquidacion.Rows(grdPreLiq.CurrentRowIndex).Item(2), String), "")
            grdPreLiq.Select(grdPreLiq.CurrentRowIndex)
            _AnoAtt = CType(_dtLiquidacion.Rows(grdPreLiq.CurrentRowIndex).Item(0), Short)
            _Folio = CType(_dtLiquidacion.Rows(grdPreLiq.CurrentRowIndex).Item(2), Integer)
            _AlmacenGas = CType(_dtLiquidacion.Rows(grdPreLiq.CurrentRowIndex).Item(12), Integer)
            _Corporativo = CType(_dtLiquidacion.Rows(grdPreLiq.CurrentRowIndex).Item(23), Integer)
            _MovimientoAlmacen = CType(_dtLiquidacion.Rows(grdPreLiq.CurrentRowIndex).Item(10), Integer)
            _NDocumento = CType(_dtLiquidacion.Rows(grdPreLiq.CurrentRowIndex).Item(24), Integer)
            If (_AnoAtt <> 0 And _Folio <> 0) Then
                btnAceptar.Enabled = True
            Else
                btnAceptar.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim frmLiquidacionPortatil As New frmPreliquidacionCredito(_AnoAtt, _Folio, _AlmacenGas, _Corporativo, _MovimientoAlmacen, _NDocumento, _drLiquidacionCarga, _Usuario, _Empleado, _CajaUsuario, _FactorDensidad, _Servidor, _Database, _Password, _CorporativoUsuario, _SucursalUsuario)
        If frmLiquidacionPortatil.ShowDialog() = DialogResult.OK Then
            Cursor = Cursors.WaitCursor
            btnBuscar_Click(btnBuscar, e)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmPreLiquidacionConsultaCyC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFecha.Value = Now
    End Sub
End Class

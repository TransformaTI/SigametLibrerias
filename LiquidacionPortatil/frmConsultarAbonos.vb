Imports System.Windows.Forms
Imports System.Drawing


Public Class frmConsultarAbonos
    Inherits System.Windows.Forms.Form
    Private _dtAbonos As DataTable
    Private _drValidarAbono As DataRow()
    Private _Anocobro As Integer
    Private _FolioCobro As Integer
    Private _FolioNota As Integer
    Private _Cliente As Integer
    Private _Nombre As String
    Private _Ruta As String
    Private _Importe As Decimal
    Private _FCobro As DateTime

    Private _Usuario As String
    Private _Empleado As Integer
    Private _CorporativoUsuario As Short
    Private _SucursalUsuario As Short
    Private _CajaUsuario As Byte
    Private _FactorDensidad As Decimal
    Private _Servidor As String
    Private _Database As String
    Private _Password As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub
    '(_Usuario, _Empleado, CType(_CajaUsuario, Byte), _FactorDensidad, _Servidor, _Database, _Password, EmpresaComisionista, SucursalUsuario)
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
    Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents grdPreLiq As System.Windows.Forms.DataGrid
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConsultarAbonos))
        Me.chkTodas = New System.Windows.Forms.CheckBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.grdPreLiq = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.grdPreLiq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkTodas
        '
        Me.chkTodas.Location = New System.Drawing.Point(80, 36)
        Me.chkTodas.Name = "chkTodas"
        Me.chkTodas.Size = New System.Drawing.Size(336, 21)
        Me.chkTodas.TabIndex = 21
        Me.chkTodas.Text = "Consultar todos los abonos pendientes"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(344, 8)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.TabIndex = 20
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 14)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Del día:"
        '
        'dtpFecha
        '
        Me.dtpFecha.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown
        Me.dtpFecha.Location = New System.Drawing.Point(80, 9)
        Me.dtpFecha.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(248, 21)
        Me.dtpFecha.TabIndex = 18
        Me.dtpFecha.Value = New Date(2011, 1, 20, 0, 0, 0, 0)
        '
        'grdPreLiq
        '
        Me.grdPreLiq.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdPreLiq.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdPreLiq.CaptionText = "Abonos a validar"
        Me.grdPreLiq.DataMember = ""
        Me.grdPreLiq.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdPreLiq.Location = New System.Drawing.Point(8, 68)
        Me.grdPreLiq.Name = "grdPreLiq"
        Me.grdPreLiq.ReadOnly = True
        Me.grdPreLiq.Size = New System.Drawing.Size(648, 368)
        Me.grdPreLiq.TabIndex = 17
        Me.grdPreLiq.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.grdPreLiq
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = ""
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.MappingName = "FolioCobro"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 0
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.MappingName = "AñoCobro"
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 0
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Folio Nota"
        Me.DataGridTextBoxColumn3.MappingName = "FolioNota"
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 73
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Cliente"
        Me.DataGridTextBoxColumn4.MappingName = "Cliente"
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Nombre"
        Me.DataGridTextBoxColumn5.MappingName = "Nombre"
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 220
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Ruta"
        Me.DataGridTextBoxColumn6.MappingName = "Ruta"
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 70
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = "n2"
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "Importe"
        Me.DataGridTextBoxColumn7.MappingName = "Importe"
        Me.DataGridTextBoxColumn7.ReadOnly = True
        Me.DataGridTextBoxColumn7.Width = 65
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "Fecha de Cobro"
        Me.DataGridTextBoxColumn8.MappingName = "FCobro"
        Me.DataGridTextBoxColumn8.ReadOnly = True
        Me.DataGridTextBoxColumn8.Width = 110
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(584, 8)
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
        Me.btnAceptar.Location = New System.Drawing.Point(496, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 15
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(496, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 22
        Me.btnCancelar.Text = "Ca&ncelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmConsultarAbonos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(664, 445)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.chkTodas, Me.btnBuscar, Me.Label1, Me.dtpFecha, Me.grdPreLiq, Me.btnCerrar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmConsultarAbonos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de abonos extraordinarios pendientes"
        CType(Me.grdPreLiq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmConsultarAbonos_Show(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtpFecha.Value = Now
        ActiveControl = dtpFecha
        btnAceptar.Enabled = False
        btnCancelar.Enabled = False
        chkTodas.Checked = False

    End Sub

    Private Sub frmConsultarAbonos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFecha.Value = Now
        ActiveControl = dtpFecha
        btnAceptar.Enabled = False
        btnCancelar.Enabled = False
        chkTodas.Checked = False

    End Sub

    Public Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        RealizarBusqueda()
        grdPreLiq_CurrentCellChanged(grdPreLiq, e)
    End Sub

    Public Sub RealizarBusqueda()
        Dim oAbono As New PortatilClasses.Consulta.cCobroComisionista()

        If chkTodas.Checked Then
            oAbono.Consulta(6, dtpFecha.Value) 'Consulta todos los abonos pendientes
        Else
            oAbono.Consulta(5, dtpFecha.Value)
        End If
        _dtAbonos = oAbono.dtTable
        grdPreLiq.DataSource = oAbono.dtTable
    End Sub


    Private Sub grdPreLiq_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPreLiq.CurrentCellChanged
        If _dtAbonos.Rows.Count > 0 Then
            _drValidarAbono = _dtAbonos.Select("FolioCobro = " & CType(_dtAbonos.Rows(grdPreLiq.CurrentRowIndex).Item(0), String), "")
            grdPreLiq.Select(grdPreLiq.CurrentRowIndex)
            _FolioCobro = CType(_dtAbonos.Rows(grdPreLiq.CurrentRowIndex).Item(0), Integer)
            _Anocobro = CType(_dtAbonos.Rows(grdPreLiq.CurrentRowIndex).Item(1), Integer)
            _FolioNota = CType(_dtAbonos.Rows(grdPreLiq.CurrentRowIndex).Item(2), Integer)
            _Cliente = CType(_dtAbonos.Rows(grdPreLiq.CurrentRowIndex).Item(3), Integer)
            _Nombre = CType(_dtAbonos.Rows(grdPreLiq.CurrentRowIndex).Item(4), String)
            _Ruta = CType(_dtAbonos.Rows(grdPreLiq.CurrentRowIndex).Item(5), String)
            _Importe = CType(_dtAbonos.Rows(grdPreLiq.CurrentRowIndex).Item(6), Decimal)
            _FCobro = CType(_dtAbonos.Rows(grdPreLiq.CurrentRowIndex).Item(7), DateTime)

            If (_FolioCobro <> 0 And _Anocobro <> 0) Then
                btnAceptar.Enabled = True
                btnCancelar.Enabled = True
            Else
                btnAceptar.Enabled = False
                btnCancelar.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim oValidar As New frmValidarAbonos(_FolioCobro, _Anocobro, _FolioNota, _Cliente, _Importe, _FCobro, _Usuario, _CajaUsuario, _Servidor, _Database, _Password, _CorporativoUsuario, _SucursalUsuario)
        oValidar.ShowDialog()
        Cursor = Cursors.WaitCursor
        btnBuscar_Click(btnBuscar, e)
        Cursor = Cursors.Default
    End Sub

    Public Sub Actualiza(ByVal e As System.EventArgs)
        btnBuscar_Click(btnBuscar, e)
    End Sub

    Private Sub dtpFecha_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown, btnBuscar.KeyDown, btnAceptar.KeyDown, btnCerrar.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub


    Private Sub chkTodas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodas.CheckedChanged
        dtpFecha.Enabled = Not chkTodas.Checked
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(128)
        Result = MessageBox.Show(Mensajes.Mensaje, "Cancelar Nota de Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Dim oAbono As New PortatilClasses.Consulta.cCobroComisionista()
            oAbono.Actualizar(7, _FolioCobro, _Anocobro, 0, 0, 0, 0, Now, _Usuario, 0, "", 0, 0, CType(_CajaUsuario, Byte), _FCobro)
        End If
        Cursor = Cursors.WaitCursor
        btnBuscar_Click(btnBuscar, e)
        Cursor = Cursors.Default
    End Sub
End Class

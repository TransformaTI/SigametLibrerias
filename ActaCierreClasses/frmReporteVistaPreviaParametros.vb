Imports System.Drawing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Windows.Forms

Public Class frmReporteVistaPreviaParametros
    Inherits System.Windows.Forms.Form

    Private ListaParametros As ArrayList

    'Private _CadenaConexion As String
    Private _RutaReporte As String
    Private _Servidor As String
    Private _BaseDeDatos As String
    Private _Usuario As String
    Private _Password As String
    Private _NombreReporte As String
    Private _Corporativo, _Sucursal As Short

    Private rptReporte As New ReportDocument()
    Private Valores As ParameterValues
    Private Valor As ParameterDiscreteValue
    Private ParametrosDelReporte As ParameterFieldDefinitions
    Private ParametroDelReporte As ParameterFieldDefinition
    Private _TablaReporte As Table
    Friend WithEvents cboSucursal As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblEtiqFfinal As System.Windows.Forms.Label
    Friend WithEvents dtpFFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEtiqFinicial As System.Windows.Forms.Label
    Friend WithEvents dtpFInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboTipoRecipiente As PortatilClasses.Combo.ComboBase
    Friend WithEvents lblEtiqTipoRecipiente As System.Windows.Forms.Label
    Friend WithEvents cboTipoMovimiento As System.Windows.Forms.ComboBox
    Friend WithEvents lblEtiqTipoMovimiento As System.Windows.Forms.Label
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCorporativo As System.Windows.Forms.Label
    Friend WithEvents cboCorporativo As PortatilClasses.Combo.ComboBase
    Friend WithEvents cboAño As PortatilClasses.Combo.ComboBase
    Friend WithEvents lblAño As System.Windows.Forms.Label
    Friend WithEvents cboMes As PortatilClasses.Combo.ComboBase
    Friend WithEvents lblMes As System.Windows.Forms.Label
    Private _LogonInfo As TableLogOnInfo

#Region " Windows Form Designer generated code "


    Public Sub New(ByVal RutaReporte As String, ByVal NombreReporte As String, Optional ByVal Exportar As Boolean = True)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        '_CadenaConexion = CadenaConexion
        _RutaReporte = RutaReporte

        _NombreReporte = NombreReporte
        crvReporte.ShowExportButton = Exportar

        'Variables estaticas
        _Usuario = PortatilClasses.Globals.GetInstance._Usuario
        _Password = PortatilClasses.Globals.GetInstance._Password

        Me.Text = NombreReporte

        ObtenerDatosConexion()
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
    Friend WithEvents PanelControl As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteVistaPreviaParametros))
        Me.PanelControl = New System.Windows.Forms.Panel()
        Me.cboCorporativo = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.lblCorporativo = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.cboTipoMovimiento = New System.Windows.Forms.ComboBox()
        Me.lblEtiqTipoMovimiento = New System.Windows.Forms.Label()
        Me.cboTipoRecipiente = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.lblEtiqTipoRecipiente = New System.Windows.Forms.Label()
        Me.lblEtiqFfinal = New System.Windows.Forms.Label()
        Me.dtpFFinal = New System.Windows.Forms.DateTimePicker()
        Me.lblEtiqFinicial = New System.Windows.Forms.Label()
        Me.dtpFInicio = New System.Windows.Forms.DateTimePicker()
        Me.cboSucursal = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.cboAño = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.lblAño = New System.Windows.Forms.Label()
        Me.cboMes = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.lblMes = New System.Windows.Forms.Label()
        Me.PanelControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl
        '
        Me.PanelControl.BackColor = System.Drawing.Color.Gainsboro
        Me.PanelControl.Controls.Add(Me.cboMes)
        Me.PanelControl.Controls.Add(Me.lblMes)
        Me.PanelControl.Controls.Add(Me.cboAño)
        Me.PanelControl.Controls.Add(Me.lblAño)
        Me.PanelControl.Controls.Add(Me.cboCorporativo)
        Me.PanelControl.Controls.Add(Me.lblCorporativo)
        Me.PanelControl.Controls.Add(Me.btnConsultar)
        Me.PanelControl.Controls.Add(Me.btnCerrar)
        Me.PanelControl.Controls.Add(Me.cboTipoMovimiento)
        Me.PanelControl.Controls.Add(Me.lblEtiqTipoMovimiento)
        Me.PanelControl.Controls.Add(Me.cboTipoRecipiente)
        Me.PanelControl.Controls.Add(Me.lblEtiqTipoRecipiente)
        Me.PanelControl.Controls.Add(Me.lblEtiqFfinal)
        Me.PanelControl.Controls.Add(Me.dtpFFinal)
        Me.PanelControl.Controls.Add(Me.lblEtiqFinicial)
        Me.PanelControl.Controls.Add(Me.dtpFInicio)
        Me.PanelControl.Controls.Add(Me.cboSucursal)
        Me.PanelControl.Controls.Add(Me.Label5)
        Me.PanelControl.Controls.Add(Me.Splitter1)
        Me.PanelControl.Controls.Add(Me.crvReporte)
        Me.PanelControl.Controls.Add(Me.lblReporte)
        Me.PanelControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl.Name = "PanelControl"
        Me.PanelControl.Size = New System.Drawing.Size(984, 561)
        Me.PanelControl.TabIndex = 504
        '
        'cboCorporativo
        '
        Me.cboCorporativo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCorporativo.Location = New System.Drawing.Point(123, 171)
        Me.cboCorporativo.Name = "cboCorporativo"
        Me.cboCorporativo.Size = New System.Drawing.Size(135, 21)
        Me.cboCorporativo.TabIndex = 523
        '
        'lblCorporativo
        '
        Me.lblCorporativo.AutoSize = True
        Me.lblCorporativo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCorporativo.Location = New System.Drawing.Point(12, 177)
        Me.lblCorporativo.Name = "lblCorporativo"
        Me.lblCorporativo.Size = New System.Drawing.Size(77, 13)
        Me.lblCorporativo.TabIndex = 522
        Me.lblCorporativo.Text = "Corporativo:"
        Me.lblCorporativo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(16, 503)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 24)
        Me.btnConsultar.TabIndex = 520
        Me.btnConsultar.Text = "C&onsultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = False
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(104, 503)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 24)
        Me.btnCerrar.TabIndex = 521
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'cboTipoMovimiento
        '
        Me.cboTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoMovimiento.Items.AddRange(New Object() {"ENTRADA", "SALIDA"})
        Me.cboTipoMovimiento.Location = New System.Drawing.Point(123, 92)
        Me.cboTipoMovimiento.Name = "cboTipoMovimiento"
        Me.cboTipoMovimiento.Size = New System.Drawing.Size(135, 21)
        Me.cboTipoMovimiento.TabIndex = 519
        '
        'lblEtiqTipoMovimiento
        '
        Me.lblEtiqTipoMovimiento.AutoSize = True
        Me.lblEtiqTipoMovimiento.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblEtiqTipoMovimiento.Location = New System.Drawing.Point(12, 97)
        Me.lblEtiqTipoMovimiento.Name = "lblEtiqTipoMovimiento"
        Me.lblEtiqTipoMovimiento.Size = New System.Drawing.Size(105, 13)
        Me.lblEtiqTipoMovimiento.TabIndex = 518
        Me.lblEtiqTipoMovimiento.Text = "Tipo movimiento:"
        Me.lblEtiqTipoMovimiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTipoRecipiente
        '
        Me.cboTipoRecipiente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoRecipiente.Items.AddRange(New Object() {"ACTIVO", "INACTIVO"})
        Me.cboTipoRecipiente.Location = New System.Drawing.Point(123, 65)
        Me.cboTipoRecipiente.Name = "cboTipoRecipiente"
        Me.cboTipoRecipiente.Size = New System.Drawing.Size(135, 21)
        Me.cboTipoRecipiente.TabIndex = 516
        '
        'lblEtiqTipoRecipiente
        '
        Me.lblEtiqTipoRecipiente.AutoSize = True
        Me.lblEtiqTipoRecipiente.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblEtiqTipoRecipiente.Location = New System.Drawing.Point(12, 68)
        Me.lblEtiqTipoRecipiente.Name = "lblEtiqTipoRecipiente"
        Me.lblEtiqTipoRecipiente.Size = New System.Drawing.Size(94, 13)
        Me.lblEtiqTipoRecipiente.TabIndex = 517
        Me.lblEtiqTipoRecipiente.Text = "Tipo recipiente:"
        '
        'lblEtiqFfinal
        '
        Me.lblEtiqFfinal.AutoSize = True
        Me.lblEtiqFfinal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblEtiqFfinal.Location = New System.Drawing.Point(12, 151)
        Me.lblEtiqFfinal.Name = "lblEtiqFfinal"
        Me.lblEtiqFfinal.Size = New System.Drawing.Size(70, 13)
        Me.lblEtiqFfinal.TabIndex = 514
        Me.lblEtiqFfinal.Text = "Fecha final:"
        Me.lblEtiqFfinal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFFinal
        '
        Me.dtpFFinal.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFFinal.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpFFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFFinal.Location = New System.Drawing.Point(123, 145)
        Me.dtpFFinal.Name = "dtpFFinal"
        Me.dtpFFinal.Size = New System.Drawing.Size(135, 20)
        Me.dtpFFinal.TabIndex = 515
        Me.dtpFFinal.Value = New Date(2004, 7, 1, 20, 34, 7, 497)
        '
        'lblEtiqFinicial
        '
        Me.lblEtiqFinicial.AutoSize = True
        Me.lblEtiqFinicial.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblEtiqFinicial.Location = New System.Drawing.Point(12, 125)
        Me.lblEtiqFinicial.Name = "lblEtiqFinicial"
        Me.lblEtiqFinicial.Size = New System.Drawing.Size(78, 13)
        Me.lblEtiqFinicial.TabIndex = 512
        Me.lblEtiqFinicial.Text = "Fecha inicial:"
        Me.lblEtiqFinicial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFInicio
        '
        Me.dtpFInicio.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFInicio.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpFInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFInicio.Location = New System.Drawing.Point(123, 119)
        Me.dtpFInicio.Name = "dtpFInicio"
        Me.dtpFInicio.Size = New System.Drawing.Size(135, 20)
        Me.dtpFInicio.TabIndex = 513
        Me.dtpFInicio.Value = New Date(2004, 7, 1, 20, 34, 7, 497)
        '
        'cboSucursal
        '
        Me.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursal.Location = New System.Drawing.Point(123, 38)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(135, 21)
        Me.cboSucursal.TabIndex = 511
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(12, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 510
        Me.Label5.Text = "Sucursal:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter1.Location = New System.Drawing.Point(981, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 561)
        Me.Splitter1.TabIndex = 509
        Me.Splitter1.TabStop = False
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvReporte.BackColor = System.Drawing.SystemColors.Control
        Me.crvReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvReporte.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvReporte.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crvReporte.Location = New System.Drawing.Point(264, 0)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.ShowRefreshButton = False
        Me.crvReporte.Size = New System.Drawing.Size(720, 561)
        Me.crvReporte.TabIndex = 508
        Me.crvReporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'lblReporte
        '
        Me.lblReporte.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblReporte.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporte.Location = New System.Drawing.Point(0, 540)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(980, 20)
        Me.lblReporte.TabIndex = 6
        Me.lblReporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAño
        '
        Me.cboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAño.Location = New System.Drawing.Point(123, 198)
        Me.cboAño.Name = "cboAño"
        Me.cboAño.Size = New System.Drawing.Size(135, 21)
        Me.cboAño.TabIndex = 525
        '
        'lblAño
        '
        Me.lblAño.AutoSize = True
        Me.lblAño.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblAño.Location = New System.Drawing.Point(12, 204)
        Me.lblAño.Name = "lblAño"
        Me.lblAño.Size = New System.Drawing.Size(32, 13)
        Me.lblAño.TabIndex = 524
        Me.lblAño.Text = "Año:"
        Me.lblAño.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboMes
        '
        Me.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMes.Location = New System.Drawing.Point(123, 225)
        Me.cboMes.Name = "cboMes"
        Me.cboMes.Size = New System.Drawing.Size(135, 21)
        Me.cboMes.TabIndex = 527
        '
        'lblMes
        '
        Me.lblMes.AutoSize = True
        Me.lblMes.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblMes.Location = New System.Drawing.Point(12, 231)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(33, 13)
        Me.lblMes.TabIndex = 526
        Me.lblMes.Text = "Mes:"
        Me.lblMes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmReporteVistaPreviaParametros
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.PanelControl)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmReporteVistaPreviaParametros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte por Parametros"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PanelControl.ResumeLayout(False)
        Me.PanelControl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Manejo de datos"
    Private Sub AplicaInfoConexion()
        For Each _TablaReporte In rptReporte.Database.Tables

            _LogonInfo = _TablaReporte.LogOnInfo
            With _LogonInfo.ConnectionInfo
                .ServerName = _Servidor
                .DatabaseName = _BaseDeDatos
                .UserID = _Usuario
                .Password = _Password
            End With
            Try
                _TablaReporte.ApplyLogOnInfo(_LogonInfo)
            Catch exArgumentos As ArgumentNullException
                MessageBox.Show("La información de seguridad para este reporte está incompleta.  Por favor intente de nuevo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Next
    End Sub

    Private Sub OpenSubreport()
        Dim subreportName As String
        Dim subreportObject As SubreportObject
        Dim subreport As New ReportDocument()
        Dim i As Integer

        For i = 0 To rptReporte.ReportDefinition.ReportObjects.Count - 1
            ' Obtener ReportObject por nombre y proyectarlo como SubreportObject.
            If TypeOf (rptReporte.ReportDefinition.ReportObjects.Item(i)) Is SubreportObject Then
                subreportObject = CType(rptReporte.ReportDefinition.ReportObjects.Item(i), CrystalDecisions.CrystalReports.Engine.SubreportObject)
                ' Obtener el nombre de subinforme.
                subreportName = subreportObject.SubreportName
                ' Abrir el subinforme como ReportDocument.
                subreport = rptReporte.OpenSubreport(subreportName)

                For Each _TablaReporte In subreport.Database.Tables
                    _LogonInfo = _TablaReporte.LogOnInfo
                    With _LogonInfo.ConnectionInfo
                        .ServerName = _Servidor
                        .DatabaseName = _BaseDeDatos
                        .UserID = _Usuario
                        .Password = _Password
                    End With
                    Try
                        _TablaReporte.ApplyLogOnInfo(_LogonInfo)
                    Catch exArgumentos As ArgumentNullException
                        MessageBox.Show("La información de seguridad para este reporte está incompleta.  Por favor intente de nuevo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Next
            End If
        Next
    End Sub

    Private Sub CargaReporte()
        Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim TotalParametros As Integer
        Dim RutaReporteCompleta As String

        Try

            'Reiniciamos la informacion que se mostrara
            crvReporte.ReportSource = Nothing

            RutaReporteCompleta = _RutaReporte & "\" & _NombreReporte

            rptReporte.Load(RutaReporteCompleta)
            AplicaInfoConexion()
            OpenSubreport()

            ParametrosDelReporte = rptReporte.DataDefinition.ParameterFields
            TotalParametros = ParametrosDelReporte.Count

            If TotalParametros > 0 And TotalParametros <= ListaParametros.Count Then
                i = 0
                For Each ParametroDelReporte In ParametrosDelReporte
                    Valores = ParametroDelReporte.CurrentValues
                    Valor = New ParameterDiscreteValue()
                    Valor.Value = ListaParametros(i)
                    Valores.Add(Valor)
                    ParametroDelReporte.ApplyCurrentValues(Valores)
                    i = i + 1
                Next
            End If
            Try
                Dim frmMensaje As New frmEspere()
                frmMensaje.Show()
                crvReporte.ReportSource = rptReporte
                crvReporte.Refresh()
                frmMensaje.Dispose()
            Catch ex As Exception
                Dim Mensajes As New PortatilClasses.Mensaje(17, Me.Text)
                MessageBox.Show(Mensajes.Mensaje, _NombreReporte, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch exc As Exception
            Dim Mensajes As New PortatilClasses.Mensaje(19)
            MessageBox.Show(Mensajes.Mensaje, _NombreReporte, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Cursor = Cursors.Default
    End Sub


    Private Sub ObtenerDatosConexion()
        Dim arrCadenaConexion As String() = PortatilClasses.Globals.GetInstance._CadenaConexion.Split(";")

        Dim i As Integer = 0
        For i = 0 To arrCadenaConexion.Count() - 1
            Dim arrCaracteresConexion As String()
            If (arrCadenaConexion(i).Contains("Data Source")) Then
                arrCaracteresConexion = arrCadenaConexion(i).Split("=")
                _Servidor = arrCaracteresConexion(1).Trim()
            ElseIf (arrCadenaConexion(i).Contains("Initial Catalog")) Then
                arrCaracteresConexion = arrCadenaConexion(i).Split("=")
                _BaseDeDatos = arrCaracteresConexion(1).Trim()
            End If
        Next
    End Sub

    Private Sub CargarCboSucursal()
        Try
            cboSucursal.CargaDatosBase("spPTLCargaComboSucursal", 5, PortatilClasses.Globals.GetInstance._Usuario, _
                                               PortatilClasses.Globals.GetInstance._Corporativo, 0, 0)

            If cboSucursal.Items.Count > 0 Then
                cboSucursal.SelectedIndex = 0
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarTipoRecipiente()
        cboTipoRecipiente.CargaDatosBase("spPTLCargaComboTipoRecipiente", 0, PortatilClasses.Globals.GetInstance._Usuario)
        If cboTipoRecipiente.Items.Count > 0 Then
            cboTipoRecipiente.SelectedIndex = 0
        End If
    End Sub

    Private Sub CargarCboCorporativo()
        cboCorporativo.CargaDatosBase("spPTLCargaComboCorporativo", 0, PortatilClasses.Globals.GetInstance._Usuario)
        If cboCorporativo.Items.Count > 0 Then
            cboCorporativo.SelectedIndex = 0
        End If
    End Sub

    Private Sub CargarCboMes()
        cboMes.CargaDatosBase("spPTLCargaComboMesesAño", 0, PortatilClasses.Globals.GetInstance._Usuario)
        If cboMes.Items.Count > 0 Then
            cboMes.SelectedIndex = 0
        End If
    End Sub

    Private Sub CargarCboAño()
        cboAño.CargaDatosBase("spPTLCargaComboMesesAño", 1, PortatilClasses.Globals.GetInstance._Usuario)
        If cboAño.Items.Count > 0 Then
            cboAño.SelectedIndex = 0
        End If
    End Sub


    Private Sub AplicarParametros()
        Try

            ListaParametros = New ArrayList()

            Select Case _NombreReporte
                Case "rptResumenEntradaSalida.rpt"
                    Dim TipoMovimiento As Integer

                    If cboTipoMovimiento.SelectedIndex = 0 Then
                        TipoMovimiento = 39
                    Else
                        TipoMovimiento = 40
                    End If
                    ListaParametros.Add(cboSucursal.Identificador)
                    ListaParametros.Add(TipoMovimiento)
                    ListaParametros.Add(cboTipoRecipiente.Identificador)
                    ListaParametros.Add(dtpFInicio.Value)
                    ListaParametros.Add(dtpFFinal.Value)
                Case "ReporteActaManual.rpt"
                    ListaParametros.Add(cboSucursal.Identificador)
                    ListaParametros.Add(cboSucursal.Identificador)
                    ListaParametros.Add(cboSucursal.Identificador)
                    ListaParametros.Add(cboSucursal.Identificador)
                Case "ReporteGeneralEmpresa.rpt"
                    ListaParametros.Add(cboAño.Identificador)
                    ListaParametros.Add(cboMes.Identificador)
                    ListaParametros.Add(cboCorporativo.Identificador)

                    ListaParametros.Add(cboAño.Identificador)
                    ListaParametros.Add(cboMes.Identificador)
                    ListaParametros.Add(cboCorporativo.Identificador)
            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub



#End Region

#Region "Manejo de la forma"

    Private Sub InterfazInicial()

        Select Case _NombreReporte

            Case "rptResumenEntradaSalida.rpt"
                CargarTipoRecipiente()
                cboTipoMovimiento.SelectedIndex = 0
                dtpFInicio.Value = Now
                dtpFFinal.MinDate = dtpFInicio.Value

                lblCorporativo.Visible = False
                lblMes.Visible = False
                lblAño.Visible = False
                cboCorporativo.Visible = False
                cboAño.Visible = False
                cboMes.Visible = False


            Case "ReporteActaManual.rpt"

                lblEtiqTipoRecipiente.Visible = False
                lblEtiqTipoMovimiento.Visible = False
                lblEtiqFinicial.Visible = False
                lblEtiqFfinal.Visible = False

                cboTipoRecipiente.Visible = False
                cboTipoMovimiento.Visible = False
                dtpFInicio.Visible = False
                dtpFFinal.Visible = False

                lblCorporativo.Visible = False
                lblMes.Visible = False
                lblAño.Visible = False
                cboCorporativo.Visible = False
                cboAño.Visible = False
                cboMes.Visible = False

            Case "ReporteGeneralEmpresa.rpt"
                Me.cboCorporativo.Location = New System.Drawing.Point(123, 38)
                Me.lblCorporativo.Location = New System.Drawing.Point(12, 41)

                Me.cboAño.Location = New System.Drawing.Point(123, 65)
                Me.lblAño.Location = New System.Drawing.Point(12, 68)

                Me.cboMes.Location = New System.Drawing.Point(123, 92)
                Me.lblMes.Location = New System.Drawing.Point(12, 97)


                Label5.Visible = False
                cboSucursal.Visible = False
                lblEtiqTipoRecipiente.Visible = False
                lblEtiqTipoMovimiento.Visible = False
                lblEtiqFinicial.Visible = False
                lblEtiqFfinal.Visible = False

                cboTipoRecipiente.Visible = False
                cboTipoMovimiento.Visible = False
                dtpFInicio.Visible = False
                dtpFFinal.Visible = False
        End Select

        lblReporte.Text = _RutaReporte
    End Sub

    Private Sub HabilitarConsultar()
        If (_NombreReporte = "rptResumenEntradaSalida.rpt" And cboSucursal.Text <> "" And cboTipoRecipiente.Text <> "") Or (_NombreReporte = "ReporteActaManual.rpt" And cboSucursal.Text <> "") Then
            btnConsultar.Enabled = True
        ElseIf (_NombreReporte = "ReporteGeneralEmpresa.rpt" And cboCorporativo.Text <> "" And cboAño.Text <> "") Then
            btnConsultar.Enabled = True
        Else
            btnConsultar.Enabled = False
        End If
    End Sub

#End Region

#Region "Manejo de Controles"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        AplicarParametros()
        CargaReporte()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

#End Region

    Private Sub frmReporteVistaPreviaParametros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Try

            CargarCboSucursal()
            CargarCboCorporativo()
            CargarCboMes()
            CargarCboAño()

            InterfazInicial()
            HabilitarConsultar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dtpFInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFInicio.ValueChanged
        dtpFFinal.MinDate = dtpFInicio.Value
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblCorporativo.Click

    End Sub

    Private Sub PanelControl_Paint(sender As Object, e As PaintEventArgs) Handles PanelControl.Paint

    End Sub

    Private Sub Label1_Click_1(sender As Object, e As EventArgs) Handles lblAño.Click

    End Sub
End Class

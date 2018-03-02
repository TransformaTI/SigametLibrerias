'Motivo: Se agrgeo la opcion de exportar directamente a excel
'Variable de cambio: 20051217CAGP$002

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmReporteFechas
    Inherits System.Windows.Forms.Form

    Public Operacion As Short
    Public intcboBase1 As Integer
    Public intcboBase2 As Integer
    Public intcboBase3 As Integer
    Public intcboBase4 As Integer

    'Enum Reportes
    '    ReporteKardex
    '    ReporteControlFolio
    '    ReporteFolioCancelado
    'End Enum

    'Public ListaParametros As New ArrayList()
    Private Parametros As New ArrayList()
    Private FInicialAsignada As Boolean

#Region "Variables locales"
    Private rptReporte As New ReportDocument()
    Private _RutaReporte As String
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo
    Private _Servidor As String
    Private _BaseDeDatos As String
    Private _UserID As String
    Private _Password As String
    Private _NombreReporte As String
    Private _CadenaConexion As String

    Dim Valores As ParameterValues
    Dim Valor As ParameterDiscreteValue
    Private ParametrosDelReporte As ParameterFieldDefinitions
    Dim ParametroDelReporte As ParameterFieldDefinition
#End Region

    Public Sub New(ByVal strRutaReporte As String, _
           ByVal strNombreServidor As String, _
           ByVal strNombreBaseDeDatos As String, _
           ByVal strUserID As String, _
           ByVal strPassword As String, ByVal Reporte As String, _
           Optional ByVal Exportar As Boolean = True, Optional ByVal CadenaConexion As String = "")

        MyBase.New()
        InitializeComponent()
        _RutaReporte = strRutaReporte
        _Servidor = strNombreServidor
        _BaseDeDatos = strNombreBaseDeDatos
        _UserID = strUserID
        _Password = strPassword
        '_UserID = "SIGAREP"
        '_Password = "SIGAREP"
        'CargaReporte(strRutaReporte)
        lblReporte.Text = strRutaReporte
        _NombreReporte = Reporte
        Me.Text = Reporte.ToString
        crvReporte.ShowExportButton = Exportar
        _CadenaConexion = CadenaConexion
    End Sub

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
    Friend WithEvents PanelControl As System.Windows.Forms.Panel
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuReporte As System.Windows.Forms.MainMenu
    Public WithEvents mnuMovimientos As System.Windows.Forms.MenuItem
    Public WithEvents mnuVerificar As System.Windows.Forms.MenuItem
    Public WithEvents mnuAprobar As System.Windows.Forms.MenuItem
    Public WithEvents mnuCancelar As System.Windows.Forms.MenuItem
    Public WithEvents dtpFFinal As System.Windows.Forms.DateTimePicker
    Public WithEvents dtpFInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboBase1 As PortatilClasses.Combo.ComboBase
    Friend WithEvents cboBase2 As PortatilClasses.Combo.ComboBase
    Friend WithEvents cboBase3 As PortatilClasses.Combo.ComboBase
    Friend WithEvents cboBase4 As PortatilClasses.Combo.ComboBase
    Friend WithEvents lblcboBase1 As System.Windows.Forms.Label
    Friend WithEvents lblcboBase2 As System.Windows.Forms.Label
    Friend WithEvents lblcboBase3 As System.Windows.Forms.Label
    Friend WithEvents lblcboBase4 As System.Windows.Forms.Label
    Public WithEvents mnuExportar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmReporteFechas))
        Me.PanelControl = New System.Windows.Forms.Panel()
        Me.lblcboBase4 = New System.Windows.Forms.Label()
        Me.lblcboBase3 = New System.Windows.Forms.Label()
        Me.lblcboBase2 = New System.Windows.Forms.Label()
        Me.lblcboBase1 = New System.Windows.Forms.Label()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.dtpFFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpFInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.cboBase1 = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.cboBase2 = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.cboBase3 = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.cboBase4 = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.mnuReporte = New System.Windows.Forms.MainMenu()
        Me.mnuMovimientos = New System.Windows.Forms.MenuItem()
        Me.mnuVerificar = New System.Windows.Forms.MenuItem()
        Me.mnuAprobar = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.mnuCancelar = New System.Windows.Forms.MenuItem()
        Me.mnuExportar = New System.Windows.Forms.MenuItem()
        Me.PanelControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl
        '
        Me.PanelControl.BackColor = System.Drawing.Color.Gainsboro
        Me.PanelControl.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblcboBase4, Me.lblcboBase3, Me.lblcboBase2, Me.lblcboBase1, Me.Splitter1, Me.crvReporte, Me.dtpFFinal, Me.dtpFInicial, Me.Label1, Me.Label3, Me.btnConsultar, Me.btnCerrar, Me.lblReporte, Me.cboBase1, Me.cboBase2, Me.cboBase3, Me.cboBase4})
        Me.PanelControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl.Name = "PanelControl"
        Me.PanelControl.Size = New System.Drawing.Size(984, 621)
        Me.PanelControl.TabIndex = 503
        '
        'lblcboBase4
        '
        Me.lblcboBase4.AutoSize = True
        Me.lblcboBase4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblcboBase4.Location = New System.Drawing.Point(8, 196)
        Me.lblcboBase4.Name = "lblcboBase4"
        Me.lblcboBase4.Size = New System.Drawing.Size(63, 13)
        Me.lblcboBase4.TabIndex = 517
        Me.lblcboBase4.Text = "Fecha final:"
        Me.lblcboBase4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblcboBase4.Visible = False
        '
        'lblcboBase3
        '
        Me.lblcboBase3.AutoSize = True
        Me.lblcboBase3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblcboBase3.Location = New System.Drawing.Point(8, 167)
        Me.lblcboBase3.Name = "lblcboBase3"
        Me.lblcboBase3.Size = New System.Drawing.Size(63, 13)
        Me.lblcboBase3.TabIndex = 516
        Me.lblcboBase3.Text = "Fecha final:"
        Me.lblcboBase3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblcboBase3.Visible = False
        '
        'lblcboBase2
        '
        Me.lblcboBase2.AutoSize = True
        Me.lblcboBase2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblcboBase2.Location = New System.Drawing.Point(8, 137)
        Me.lblcboBase2.Name = "lblcboBase2"
        Me.lblcboBase2.Size = New System.Drawing.Size(63, 13)
        Me.lblcboBase2.TabIndex = 515
        Me.lblcboBase2.Text = "Fecha final:"
        Me.lblcboBase2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblcboBase2.Visible = False
        '
        'lblcboBase1
        '
        Me.lblcboBase1.AutoSize = True
        Me.lblcboBase1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblcboBase1.Location = New System.Drawing.Point(8, 108)
        Me.lblcboBase1.Name = "lblcboBase1"
        Me.lblcboBase1.Size = New System.Drawing.Size(63, 13)
        Me.lblcboBase1.TabIndex = 514
        Me.lblcboBase1.Text = "Fecha final:"
        Me.lblcboBase1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblcboBase1.Visible = False
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter1.Location = New System.Drawing.Point(261, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 621)
        Me.Splitter1.TabIndex = 509
        Me.Splitter1.TabStop = False
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.BackColor = System.Drawing.SystemColors.Control
        'Me.crvReporte.DisplayGroupTree = False
        Me.crvReporte.Dock = System.Windows.Forms.DockStyle.Right
        Me.crvReporte.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crvReporte.Location = New System.Drawing.Point(264, 0)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.ReportSource = Nothing
        Me.crvReporte.ShowRefreshButton = False
        Me.crvReporte.Size = New System.Drawing.Size(720, 621)
        Me.crvReporte.TabIndex = 508
        '
        'dtpFFinal
        '
        Me.dtpFFinal.CustomFormat = "dd  MMMM yyyy"
        Me.dtpFFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFFinal.Location = New System.Drawing.Point(84, 76)
        Me.dtpFFinal.Name = "dtpFFinal"
        Me.dtpFFinal.Size = New System.Drawing.Size(136, 20)
        Me.dtpFFinal.TabIndex = 1
        '
        'dtpFInicial
        '
        Me.dtpFInicial.CustomFormat = "dd  MMMM yyyy"
        Me.dtpFInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFInicial.Location = New System.Drawing.Point(84, 48)
        Me.dtpFInicial.Name = "dtpFInicial"
        Me.dtpFInicial.Size = New System.Drawing.Size(136, 20)
        Me.dtpFInicial.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 504
        Me.Label1.Text = "Fecha final:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 503
        Me.Label3.Text = "Fecha inicial:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.btnConsultar.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Bitmap)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(49, 552)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 24)
        Me.btnConsultar.TabIndex = 6
        Me.btnConsultar.Text = "C&onsultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(137, 552)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 24)
        Me.btnCerrar.TabIndex = 7
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblReporte
        '
        Me.lblReporte.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblReporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblReporte.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporte.Location = New System.Drawing.Point(0, 600)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(980, 20)
        Me.lblReporte.TabIndex = 6
        Me.lblReporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBase1
        '
        Me.cboBase1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBase1.Location = New System.Drawing.Point(84, 104)
        Me.cboBase1.Name = "cboBase1"
        Me.cboBase1.Size = New System.Drawing.Size(136, 21)
        Me.cboBase1.TabIndex = 2
        Me.cboBase1.Visible = False
        '
        'cboBase2
        '
        Me.cboBase2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBase2.Location = New System.Drawing.Point(84, 134)
        Me.cboBase2.Name = "cboBase2"
        Me.cboBase2.Size = New System.Drawing.Size(136, 21)
        Me.cboBase2.TabIndex = 3
        Me.cboBase2.Visible = False
        '
        'cboBase3
        '
        Me.cboBase3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBase3.Location = New System.Drawing.Point(84, 163)
        Me.cboBase3.Name = "cboBase3"
        Me.cboBase3.Size = New System.Drawing.Size(136, 21)
        Me.cboBase3.TabIndex = 4
        Me.cboBase3.Visible = False
        '
        'cboBase4
        '
        Me.cboBase4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBase4.Location = New System.Drawing.Point(84, 192)
        Me.cboBase4.Name = "cboBase4"
        Me.cboBase4.Size = New System.Drawing.Size(136, 21)
        Me.cboBase4.TabIndex = 5
        Me.cboBase4.Visible = False
        '
        'mnuReporte
        '
        Me.mnuReporte.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuMovimientos})
        '
        'mnuMovimientos
        '
        Me.mnuMovimientos.Index = 0
        Me.mnuMovimientos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuVerificar, Me.mnuAprobar, Me.MenuItem4, Me.mnuCancelar, Me.mnuExportar})
        Me.mnuMovimientos.Text = "Movimientos"
        Me.mnuMovimientos.Visible = False
        '
        'mnuVerificar
        '
        Me.mnuVerificar.Index = 0
        Me.mnuVerificar.Text = "&Verificar"
        Me.mnuVerificar.Visible = False
        '
        'mnuAprobar
        '
        Me.mnuAprobar.Index = 1
        Me.mnuAprobar.Text = "&Aprobar"
        Me.mnuAprobar.Visible = False
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.Text = "-"
        '
        'mnuCancelar
        '
        Me.mnuCancelar.Index = 3
        Me.mnuCancelar.Text = "&Cancelar"
        Me.mnuCancelar.Visible = False
        '
        'mnuExportar
        '
        Me.mnuExportar.Index = 4
        Me.mnuExportar.Text = "&Exportar"
        Me.mnuExportar.Visible = False
        '
        'frmReporteFechas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(984, 621)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PanelControl})
        Me.Menu = Me.mnuReporte
        Me.Name = "frmReporteFechas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmReporteFechas"
        Me.PanelControl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub AplicaInfoConexion()
        For Each _TablaReporte In rptReporte.Database.Tables

            _LogonInfo = _TablaReporte.LogOnInfo
            With _LogonInfo.ConnectionInfo
                .ServerName = _Servidor
                .DatabaseName = _BaseDeDatos
                .UserID = _UserID
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
                        .UserID = _UserID
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

    Private Sub Audita()
        'Graba en el event log la ejecución del reporte por el usuario
        Dim strMensaje As String = _
        "El reporte: " & Me.Text & " ha sido ejecutado por el usuario: " & _UserID & " en el servidor: " & _Servidor & " base de datos: " & _BaseDeDatos
        'EventLog.WriteEntry(Main.GLOBAL_NombreModulo & " Reportes Dinámicos", strMensaje, EventLogEntryType.Information)        
    End Sub

    Public Sub AddParametros(ByVal Valor As String, ByVal EsFechaAMostrar As Boolean, _
    Optional ByVal cboTipo As Short = 0, Optional ByVal Visible As Boolean = False, Optional ByVal ValorDefault As Integer = 0)
        Dim oParametro As New cParametro(Valor, EsFechaAMostrar, cboTipo, Visible, ValorDefault)
        Parametros.Add(oParametro)
    End Sub


    Private Sub ChecarPosicionHoja()
        If rptReporte.PrintOptions.PaperOrientation = PaperOrientation.Landscape Then
            PrintDocument1.DefaultPageSettings.Landscape = True

        End If
    End Sub

#Region "CargaReporte"

    Private Sub CargaReporte(ByVal strReporte As String)
        Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim TotalParametros As Integer
        FInicialAsignada = False

        Try
            rptReporte.Load(strReporte)
            AplicaInfoConexion()
            OpenSubreport()

            ParametrosDelReporte = rptReporte.DataDefinition.ParameterFields
            TotalParametros = ParametrosDelReporte.Count

            If TotalParametros > 0 And TotalParametros <= Parametros.Count Then
                i = 0
                Dim IndexCbo As Integer = 1
                For Each ParametroDelReporte In ParametrosDelReporte
                    Valores = ParametroDelReporte.CurrentValues
                    Valor = New ParameterDiscreteValue()

                    Dim oParametro As cParametro
                    oParametro = CType(Parametros(i), cParametro)
                    If oParametro.EsFechaAMostrar = False Then
                        Valor.Value = oParametro.Valor
                    Else
                        If oParametro.ComboTipo = 0 Then
                            IndexCbo = 1
                            If FInicialAsignada = False Then
                                FInicialAsignada = True
                                Valor.Value = dtpFInicial.Value.Date
                            Else
                                FInicialAsignada = False
                                Valor.Value = dtpFFinal.Value.Date
                            End If
                        Else
                            Select Case IndexCbo
                                Case 1
                                    Valor.Value = cboBase1.Identificador
                                    intcboBase1 = cboBase1.Identificador
                                Case 2
                                    Valor.Value = cboBase2.Identificador
                                    intcboBase2 = cboBase2.Identificador
                                Case 3
                                    Valor.Value = cboBase3.Identificador
                                    intcboBase3 = cboBase3.Identificador
                                Case 4
                                    Valor.Value = cboBase4.Identificador
                                    intcboBase4 = cboBase4.Identificador
                                    IndexCbo = 1
                            End Select
                            IndexCbo = IndexCbo + 1
                        End If
                    End If
                    Valores.Add(Valor)
                    ParametroDelReporte.ApplyCurrentValues(Valores)
                    i = i + 1
                Next
            End If
            Try
                Dim frmMensaje As New frmEspere()
                frmMensaje.Show()
                ChecarPosicionHoja()
                crvReporte.ReportSource = rptReporte
                Audita()
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
#End Region

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        CargaReporte(_RutaReporte & "\" & _NombreReporte)
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub frmReporteFechas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActiveControl = dtpFInicial

        Dim i As Integer = 0
        Dim Orden As Integer = 0

        rptReporte.Load(_RutaReporte & "\" & _NombreReporte)
        AplicaInfoConexion()
        OpenSubreport()

        ParametrosDelReporte = rptReporte.DataDefinition.ParameterFields

        For Each ParametroDelReporte In ParametrosDelReporte
            Dim oParametro As cParametro
            oParametro = CType(Parametros(i), cParametro)
            If oParametro.ComboTipo > 0 And oParametro.Visible Then
                Orden = Orden + 1
                Dim cboBase As PortatilClasses.Combo.ComboBase = Nothing
                Dim lblBase As Label = Nothing
                Select Case Orden
                    Case 1
                        cboBase = cboBase1
                        lblBase = lblcboBase1
                    Case 2
                        cboBase = cboBase2
                        lblBase = lblcboBase2
                    Case 3
                        cboBase = cboBase3
                        lblBase = lblcboBase3
                    Case 4
                        cboBase = cboBase4
                        lblBase = lblcboBase4
                End Select
                cboBase.Visible = True
                cboBase.RealizarConsulta("spPTLCargaComboCorporativo", oParametro.ComboTipo - 1, _UserID)
                If oParametro.ValorDefault > 0 Then
                    cboBase.PosicionaCombo(oParametro.ValorDefault)
                End If
                lblBase.Visible = True
                Select Case oParametro.ComboTipo
                    Case 1
                        lblBase.Text = "Empresa:"
                    Case 2
                        lblBase.Text = "Célula:"
                    Case 3
                        lblBase.Text = "Almacén:"
                    Case 4
                        lblBase.Text = "Surcursal:"
                End Select
            End If
            i = i + 1
        Next
    End Sub

    Private Sub dtpFInicial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles dtpFFinal.KeyDown, dtpFInicial.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub dtpFInicial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFFinal.TextChanged, dtpFInicial.TextChanged
        dtpFFinal.MinDate = dtpFInicial.Value.Date
    End Sub

    Private Sub frmReporteFechas_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        crvReporte.Width = Me.Width - 272
    End Sub

    Private Sub mnuVerificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerificar.Click
        Operacion = 1
        Close()
    End Sub

    Private Sub mnuAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAprobar.Click
        Operacion = 2
        Close()
    End Sub

    Private Sub mnuCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCancelar.Click
        Operacion = 3
        Close()
    End Sub

    Private Sub cboBase4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles cboBase4.KeyDown, cboBase1.KeyDown, cboBase2.KeyDown, cboBase3.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Delete Then
            CType(sender, PortatilClasses.Combo.ComboBase).PosicionarInicio()
        End If
    End Sub

    Private Sub mnuExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExportar.Click
        '20051217CAGP$002 /I
        Cursor = Cursors.WaitCursor
        Dim oReporte As New ExportarAExcel.ReporteInventarioMensual(_UserID, _Password, dtpFInicial.Value.Date, dtpFFinal.Value.Date, CType(cboBase1.Identificador, Short), CType(cboBase2.Identificador, Short), _CadenaConexion)
        oReporte.GeneraArchivo()
        Cursor = Cursors.Default
        '20051217CAGP$002 /F
    End Sub

End Class

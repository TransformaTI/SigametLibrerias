' Muestra los folios asignados y devueltos, la información mas importante de la asignación de ellos
' en esta forma podemos Conusltar un folio especifico y modificar la información
Public Class frmConsultaFoliosAsignados
    Inherits Catalogo.frmCatalogo

    Private Titulo As String

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dtpFAsignacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFAlta As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTipoFolio As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTipoFolioMov As System.Windows.Forms.TextBox
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConsultaFoliosAsignados))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFAsignacion = New System.Windows.Forms.DateTimePicker()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFAlta = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTipoFolio = New System.Windows.Forms.TextBox()
        Me.txtEmpleado = New System.Windows.Forms.TextBox()
        Me.txtTipoFolioMov = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDatos.SuspendLayout()
        Me.tabDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbbImprimir
        '
        'Me.tbbImprimir.Rectangle = New System.Drawing.Rectangle(224, 0, 54, 36)
        '
        'tbbSep3
        '
        'Me.tbbSep3.Rectangle = New System.Drawing.Rectangle(340, 0, 8, 36)
        '
        'tbbCerrar
        '
        'Me.tbbCerrar.Rectangle = New System.Drawing.Rectangle(348, 0, 54, 36)
        '
        'tbbSep2
        '
        'Me.tbbSep2.Rectangle = New System.Drawing.Rectangle(278, 0, 8, 36)
        '
        'tbbEliminar
        '
        'Me.tbbEliminar.Rectangle = New System.Drawing.Rectangle(108, 0, 54, 36)
        '
        'tbbRefrescar
        '
        'Me.tbbRefrescar.Rectangle = New System.Drawing.Rectangle(286, 0, 54, 36)
        '
        'tbbSep1
        '
        'Me.tbbSep1.Rectangle = New System.Drawing.Rectangle(216, 0, 8, 36)
        '
        'Toolbar
        '
        Me.Toolbar.ImageStream = CType(resources.GetObject("Toolbar.ImageStream"), System.Windows.Forms.ImageListStreamer)
        '
        'tbbAgregar
        '
        'Me.tbbAgregar.Rectangle = New System.Drawing.Rectangle(0, 0, 54, 36)
        '
        'tbbConsultar
        '
        'Me.tbbConsultar.Rectangle = New System.Drawing.Rectangle(162, 0, 54, 36)
        '
        'BarraBotones
        '
        Me.BarraBotones.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.BarraBotones.Visible = True
        '
        'grdDatos
        '
        Me.grdDatos.AccessibleName = "DataGrid"
        Me.grdDatos.AccessibleRole = System.Windows.Forms.AccessibleRole.Table
        Me.grdDatos.CaptionFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.grdDatos.CaptionText = "Folios asignados"
        Me.grdDatos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.grdDatos.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.grdDatos.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.grdDatos.Visible = True
        '
        'tpDatos
        '
        Me.tpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtTipoFolioMov, Me.Label1, Me.Label6, Me.Label3, Me.Label4, Me.txtTipoFolio, Me.dtpFAlta, Me.txtEmpleado})
        Me.tpDatos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        '
        'tabDatos
        '
        Me.tabDatos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.tabDatos.ItemSize = New System.Drawing.Size(42, 18)
        Me.tabDatos.Visible = True
        '
        'tbbModificar
        '
        'Me.tbbModificar.Rectangle = New System.Drawing.Rectangle(54, 0, 54, 36)
        '
        'Label2
        '
        Me.Label2.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label2.Location = New System.Drawing.Point(483, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Fecha asignación:"
        '
        'dtpFAsignacion
        '
        Me.dtpFAsignacion.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.dtpFAsignacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFAsignacion.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFAsignacion.Location = New System.Drawing.Point(597, 8)
        Me.dtpFAsignacion.Name = "dtpFAsignacion"
        Me.dtpFAsignacion.Size = New System.Drawing.Size(100, 21)
        Me.dtpFAsignacion.TabIndex = 40
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(703, 8)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.TabIndex = 41
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.grdDatos
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = ""
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Consecutivo"
        Me.DataGridTextBoxColumn1.MappingName = "ControlFolio"
        Me.DataGridTextBoxColumn1.Width = 75
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Serie"
        Me.DataGridTextBoxColumn2.MappingName = "Serie"
        Me.DataGridTextBoxColumn2.Width = 40
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Folio inicial"
        Me.DataGridTextBoxColumn3.MappingName = "Folioinicial"
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Folio final"
        Me.DataGridTextBoxColumn4.MappingName = "FolioFinal"
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Tipo folio"
        Me.DataGridTextBoxColumn5.MappingName = "TipoFolio"
        Me.DataGridTextBoxColumn5.Width = 140
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Cantidad"
        Me.DataGridTextBoxColumn6.MappingName = "Cantidad"
        Me.DataGridTextBoxColumn6.Width = 75
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = "dd/MM/yyyy"
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "Fecha asignación"
        Me.DataGridTextBoxColumn7.MappingName = "FAsignacion"
        Me.DataGridTextBoxColumn7.Width = 110
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "Empleado"
        Me.DataGridTextBoxColumn8.MappingName = "Empleado"
        Me.DataGridTextBoxColumn8.Width = 250
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "Usuario alta"
        Me.DataGridTextBoxColumn9.MappingName = "UsuarioAlta"
        Me.DataGridTextBoxColumn9.Width = 75
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = "dd/MM/yyyy hh:mm"
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "Fecha alta"
        Me.DataGridTextBoxColumn10.MappingName = "FAlta"
        Me.DataGridTextBoxColumn10.Width = 110
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "Tipo Movimiento"
        Me.DataGridTextBoxColumn11.MappingName = "TipoFolioMovimiento"
        Me.DataGridTextBoxColumn11.Width = 75
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "Producto"
        Me.DataGridTextBoxColumn12.MappingName = "Producto"
        Me.DataGridTextBoxColumn12.Width = 110
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(32, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Tipo folio:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFAlta
        '
        Me.dtpFAlta.CustomFormat = "dd MMMM yyyy    hh:mm"
        Me.dtpFAlta.Enabled = False
        Me.dtpFAlta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFAlta.Location = New System.Drawing.Point(162, 51)
        Me.dtpFAlta.Name = "dtpFAlta"
        Me.dtpFAlta.Size = New System.Drawing.Size(228, 20)
        Me.dtpFAlta.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(32, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Fecha alta:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(32, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Empleado:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTipoFolio
        '
        Me.txtTipoFolio.Location = New System.Drawing.Point(162, 79)
        Me.txtTipoFolio.MaxLength = 10
        Me.txtTipoFolio.Name = "txtTipoFolio"
        Me.txtTipoFolio.ReadOnly = True
        Me.txtTipoFolio.Size = New System.Drawing.Size(500, 20)
        Me.txtTipoFolio.TabIndex = 24
        Me.txtTipoFolio.Text = ""
        '
        'txtEmpleado
        '
        Me.txtEmpleado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtEmpleado.Location = New System.Drawing.Point(162, 23)
        Me.txtEmpleado.MaxLength = 10
        Me.txtEmpleado.Name = "txtEmpleado"
        Me.txtEmpleado.ReadOnly = True
        Me.txtEmpleado.Size = New System.Drawing.Size(500, 20)
        Me.txtEmpleado.TabIndex = 20
        Me.txtEmpleado.Text = ""
        '
        'txtTipoFolioMov
        '
        Me.txtTipoFolioMov.Location = New System.Drawing.Point(162, 107)
        Me.txtTipoFolioMov.MaxLength = 10
        Me.txtTipoFolioMov.Name = "txtTipoFolioMov"
        Me.txtTipoFolioMov.ReadOnly = True
        Me.txtTipoFolioMov.Size = New System.Drawing.Size(500, 20)
        Me.txtTipoFolioMov.TabIndex = 26
        Me.txtTipoFolioMov.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(34, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Tipo movimiento:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmConsultaFoliosAsignados
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(784, 533)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBuscar, Me.dtpFAsignacion, Me.Label2, Me.grdDatos, Me.BarraBotones, Me.tabDatos})
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Name = "frmConsultaFoliosAsignados"
        Me.Text = "Folios asignados"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDatos.ResumeLayout(False)
        Me.tabDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Limpia los controles de la forma
    Private Sub Limpiar()
        Titulo = "Folios asignados"
        txtEmpleado.Clear()
        txtTipoFolio.Clear()
        txtTipoFolioMov.Clear()
    End Sub

    ' Carga los datos al Grid de datos dependiendo del numero de folio proporcionado
    Private Sub CargarConsulta()
        Limpiar()
        Dim oFolioBusqueda As New frmFolioBusqueda("Búsqueda de folios asignados")
        oFolioBusqueda.ShowDialog()
        If oFolioBusqueda.RealizarConsulta Then
            Cursor = Cursors.WaitCursor

            Dim oControlFolio As New PortatilClasses.Consulta.cControlFolio()
            oControlFolio.Consultar(5, 0, oFolioBusqueda.TipoFolio, 0, "0", oFolioBusqueda.FolioInicial, oFolioBusqueda.FolioFinal, 0, Now, 0, 0, GLOBAL_Usuario)
            grdDatos.DataSource = Nothing
            grdDatos.DataSource = oControlFolio.dtTable

            If oControlFolio.dtTable.Rows.Count = 0 Then
                Dim Mensajes As New PortatilClasses.Mensaje(16)
                MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            oControlFolio = Nothing
            CargarVistaRapida()
            Cursor = Cursors.Default
        End If
    End Sub

    ' Carga los datos al grid
    Private Sub CargarDatos()
        Cursor = Cursors.WaitCursor
        Limpiar()
        Dim oControlFolio As New PortatilClasses.Consulta.cControlFolio()
        oControlFolio.Consultar(4, 0, 0, 0, "0", 0, 0, 0, dtpFAsignacion.Value.Date, 0, 0, GLOBAL_Usuario)
        grdDatos.DataSource = Nothing
        grdDatos.DataSource = oControlFolio.dtTable
        oControlFolio = Nothing
        CargarVistaRapida()
        Cursor = Cursors.Default
    End Sub

    ' Carga los datos del grid al area de vista rapida de los datos
    Private Sub CargarVistaRapida()
        If grdDatos.VisibleRowCount > 0 Then
            txtEmpleado.Text = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 7), String)
            dtpFAlta.Value = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 9), DateTime)
            txtTipoFolio.Text = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 4), String)
            txtTipoFolioMov.Text = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 10), String)
        End If
    End Sub

    ' Actualiza la información mostrada en el grid y en la vista rapida de pediento si el registro
    ' fue modificado
    Private Sub Actualizar(ByVal Posicion As Short, ByVal DatosSalvados As Boolean)
        If DatosSalvados = True Then
            CargarDatos()
            grdDatos.CurrentRowIndex = Posicion
        End If
    End Sub

    ' Actualiza la información mostrada en el grid y en la vista rapida de pediento si el registro
    ' fue dado de alta
    Private Sub Actualizar(ByVal DatosSalvados As Boolean)
        If DatosSalvados = True Then
            CargarDatos()
            grdDatos.CurrentRowIndex = grdDatos.VisibleRowCount - 1
        End If
    End Sub

    ' Muestra el reporte de los folios asignados, se carga los datos importantes y se mandan como parametros, 
    ' el reporteador solo carga las fechas para que el usuario pueda seleccionar el rango de fecha y 
    ' enseguida consulte el reporte de los folios asignados y devueltos
    Private Sub MostrarReporte(ByVal Configuracion As Integer)
        Dim oReporte As New ReporteDinamicoOaxaca.frmReporteFechas(GLOBAL_RutaReportes, Global_Servidor, _
                            Global_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, "ReporteControlFolio.rpt")
        oReporte.AddParametros("0", False)
        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros(GLOBAL_Usuario, False)
        oReporte.ShowDialog()
    End Sub

    ' Carga los datos necesarios para poder modificar los folios
    Private Sub ModificarFolios()
        If grdDatos.VisibleRowCount > 0 Then
            Dim oControlFolios As New frmAsignarFolios(frmAsignarFolios.Operaciones.Modificar, _
                                  CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer))
            oControlFolios.ShowDialog()
            Actualizar(CType(grdDatos.CurrentRowIndex, Short), oControlFolios.DatosSalvados)
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(11)
            MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' Inicialización de la forma y de algunos controles
    Private Sub frmConsultaFoliosAsignados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BarraBotones.Buttons.Item(2).Visible = False
        dtpFAsignacion.Value = Now
        Refresh()
        CargarDatos()
    End Sub

    ' Evento que carga los datos al grid dependiendo de la fecha seleccionada
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargarDatos()
    End Sub

    ' Carga la función de cada botón ubicado en la barra de botones
    Public Overrides Sub BarraBotones_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) 'Handles BarraBotones.ButtonClick
        Select Case BarraBotones.Buttons.IndexOf(e.Button)
            Case 0
                Dim oControlFolios As New frmAsignarFolios(frmAsignarFolios.Operaciones.Registrar, 0)
                oControlFolios.ShowDialog()
                Actualizar(oControlFolios.DatosSalvados)
            Case 1
                ModificarFolios()
            Case 3
                CargarConsulta()
            Case 5
                MostrarReporte(0)
            Case 7
                CargarDatos()
            Case 9
                Close()
        End Select
    End Sub

    ' Evento que carga los datos al Grid de datos dependiendo del numero de folio proporcionado
    Public Overrides Sub grdDatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        CargarVistaRapida()
    End Sub

    Private Sub frmConsultaFoliosAsignados_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(28)
        Result = MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub
End Class

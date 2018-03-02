' Muestra los folios cancelados y la información mas importante de la cancelación de ellos
' en esta forma podemos Conusltar un folio especifico y modificar la información
Public Class frmConsultaFoliosCancelados
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
    Friend WithEvents dtpFCancelacion As System.Windows.Forms.DateTimePicker
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
    Friend WithEvents txtEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMCancelacion As System.Windows.Forms.TextBox
    Friend WithEvents dtpFAlta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaFoliosCancelados))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFCancelacion = New System.Windows.Forms.DateTimePicker()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.dtpFAlta = New System.Windows.Forms.DateTimePicker()
        Me.txtEmpleado = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMCancelacion = New System.Windows.Forms.TextBox()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDatos.SuspendLayout()
        Me.tabDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'Toolbar
        '
        Me.Toolbar.ImageStream = CType(resources.GetObject("Toolbar.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Toolbar.Images.SetKeyName(0, "")
        Me.Toolbar.Images.SetKeyName(1, "")
        Me.Toolbar.Images.SetKeyName(2, "")
        Me.Toolbar.Images.SetKeyName(3, "")
        Me.Toolbar.Images.SetKeyName(4, "")
        Me.Toolbar.Images.SetKeyName(5, "")
        Me.Toolbar.Images.SetKeyName(6, "")
        '
        'BarraBotones
        '
        Me.BarraBotones.Font = New System.Drawing.Font("Tahoma", 8.0!)
        '
        'grdDatos
        '
        Me.grdDatos.AccessibleName = "DataGrid"
        Me.grdDatos.AccessibleRole = System.Windows.Forms.AccessibleRole.Table
        Me.grdDatos.CaptionText = "Folios cancelados"
        Me.grdDatos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.grdDatos.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.grdDatos.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'tpDatos
        '
        Me.tpDatos.Controls.Add(Me.txtMCancelacion)
        Me.tpDatos.Controls.Add(Me.dtpFAlta)
        Me.tpDatos.Controls.Add(Me.txtEmpleado)
        Me.tpDatos.Controls.Add(Me.Label6)
        Me.tpDatos.Controls.Add(Me.Label3)
        Me.tpDatos.Controls.Add(Me.Label5)
        Me.tpDatos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        '
        'tabDatos
        '
        Me.tabDatos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.tabDatos.ItemSize = New System.Drawing.Size(42, 18)
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label2.Location = New System.Drawing.Point(480, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Fecha cancelación:"
        '
        'dtpFCancelacion
        '
        Me.dtpFCancelacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFCancelacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFCancelacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFCancelacion.Location = New System.Drawing.Point(597, 8)
        Me.dtpFCancelacion.Name = "dtpFCancelacion"
        Me.dtpFCancelacion.Size = New System.Drawing.Size(100, 21)
        Me.dtpFCancelacion.TabIndex = 37
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(703, 8)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 38
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.grdDatos
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn11})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Consecutivo"
        Me.DataGridTextBoxColumn1.MappingName = "FolioCancelado"
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
        Me.DataGridTextBoxColumn3.MappingName = "FolioInicial"
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "Folio final"
        Me.DataGridTextBoxColumn10.MappingName = "FolioFinal"
        Me.DataGridTextBoxColumn10.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Tipo Folio"
        Me.DataGridTextBoxColumn4.MappingName = "TipoFolio"
        Me.DataGridTextBoxColumn4.Width = 140
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Motivo cancelación"
        Me.DataGridTextBoxColumn5.MappingName = "MotivoCancelacion"
        Me.DataGridTextBoxColumn5.Width = 270
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = "dd/MM/yyyy"
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Fecha cancelación"
        Me.DataGridTextBoxColumn6.MappingName = "FCancelacion"
        Me.DataGridTextBoxColumn6.Width = 110
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "Empleado cancelo"
        Me.DataGridTextBoxColumn7.MappingName = "Empleado"
        Me.DataGridTextBoxColumn7.Width = 250
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "Usuario alta"
        Me.DataGridTextBoxColumn8.MappingName = "Usuario"
        Me.DataGridTextBoxColumn8.Width = 75
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = "dd/MM/yyyy hh:mm"
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "Fecha alta"
        Me.DataGridTextBoxColumn9.MappingName = "FAlta"
        Me.DataGridTextBoxColumn9.Width = 110
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "Producto"
        Me.DataGridTextBoxColumn11.MappingName = "Producto"
        Me.DataGridTextBoxColumn11.Width = 110
        '
        'dtpFAlta
        '
        Me.dtpFAlta.CustomFormat = "dd MMMM yyyy    hh:mm"
        Me.dtpFAlta.Enabled = False
        Me.dtpFAlta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFAlta.Location = New System.Drawing.Point(162, 51)
        Me.dtpFAlta.Name = "dtpFAlta"
        Me.dtpFAlta.Size = New System.Drawing.Size(228, 20)
        Me.dtpFAlta.TabIndex = 20
        '
        'txtEmpleado
        '
        Me.txtEmpleado.Location = New System.Drawing.Point(162, 23)
        Me.txtEmpleado.MaxLength = 10
        Me.txtEmpleado.Name = "txtEmpleado"
        Me.txtEmpleado.ReadOnly = True
        Me.txtEmpleado.Size = New System.Drawing.Size(500, 20)
        Me.txtEmpleado.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(32, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Fecha alta:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(32, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Empleado:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(32, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Causa de cancelación:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMCancelacion
        '
        Me.txtMCancelacion.Location = New System.Drawing.Point(162, 79)
        Me.txtMCancelacion.MaxLength = 10
        Me.txtMCancelacion.Name = "txtMCancelacion"
        Me.txtMCancelacion.ReadOnly = True
        Me.txtMCancelacion.Size = New System.Drawing.Size(500, 20)
        Me.txtMCancelacion.TabIndex = 25
        '
        'frmConsultaFoliosCancelados
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(784, 533)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpFCancelacion)
        Me.Controls.Add(Me.btnBuscar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Name = "frmConsultaFoliosCancelados"
        Me.Text = "Folios cancelados"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.BarraBotones, 0)
        Me.Controls.SetChildIndex(Me.tabDatos, 0)
        Me.Controls.SetChildIndex(Me.grdDatos, 0)
        Me.Controls.SetChildIndex(Me.btnBuscar, 0)
        Me.Controls.SetChildIndex(Me.dtpFCancelacion, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDatos.ResumeLayout(False)
        Me.tpDatos.PerformLayout()
        Me.tabDatos.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    ' Limpia los controles de la forma
    Private Sub Limpiar()
        Titulo = "Folios cancelados"
        txtEmpleado.Clear()
        txtMCancelacion.Clear()
    End Sub

    ' Carga os datos al Grid de datos dependiendo del numero de folio proporcionado
    Private Sub CargarConsulta()
        Limpiar()
        Dim oFolioBusqueda As New frmFolioBusqueda("Búsqueda de folios cancelados")
        oFolioBusqueda.ShowDialog()
        If oFolioBusqueda.RealizarConsulta Then
            Cursor = Cursors.WaitCursor

            Dim oFolioCancelado As New PortatilClasses.Consulta.cFolioCancelado()
            oFolioCancelado.Consultar(4, 0, "0", Now, 0, oFolioBusqueda.TipoFolio, CType(oFolioBusqueda.FolioInicial, String), _
                                      CType(oFolioBusqueda.FolioFinal, String), 0, 0, GLOBAL_Usuario)
            grdDatos.DataSource = Nothing
            grdDatos.DataSource = oFolioCancelado.dtTable

            If oFolioCancelado.dtTable.Rows.Count = 0 Then
                Dim Mensajes As New PortatilClasses.Mensaje(16)
                MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            oFolioCancelado = Nothing
            CargarVistaRapida()
            Cursor = Cursors.Default
        End If
    End Sub

    ' Carga los datos al grid
    Private Sub CargarDatos()
        Cursor = Cursors.WaitCursor
        Limpiar()
        Dim oFolioCancelado As New PortatilClasses.Consulta.cFolioCancelado()
        oFolioCancelado.Consultar(3, 0, "0", dtpFCancelacion.Value.Date, 0, 0, "0", "0", 0, 0, GLOBAL_Usuario)
        grdDatos.DataSource = Nothing
        grdDatos.DataSource = oFolioCancelado.dtTable
        oFolioCancelado = Nothing
        CargarVistaRapida()
        Cursor = Cursors.Default
    End Sub

    ' Carga los datos del grid al area de vista rapida de los datos
    Private Sub CargarVistaRapida()
        If grdDatos.VisibleRowCount > 0 Then
            txtEmpleado.Text = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 7), String)
            dtpFAlta.Value = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 9), DateTime)
            txtMCancelacion.Text = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 4), String)
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

    ' Muestra el reporte de los folios cancelados, se carga los datos importantes y se mandan como parametros, 
    ' el reporteador solo carga las fechas para que el usuario pueda seleccionar el rango de fecha y 
    ' enseguida consulte el reporte de los folios cancelados
    Private Sub MostrarReporte(ByVal Configuracion As Integer)
        Dim oReporte As New ReporteDinamicoOaxaca.frmReporteFechas(GLOBAL_RutaReportes, Global_Servidor, _
                            Global_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, "ReporteFolioCancelado.rpt")
        oReporte.AddParametros("0", False)
        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros(GLOBAL_Usuario, False)
        oReporte.ShowDialog()
    End Sub

    ' Inicialización de la forma y de algunos controles
    Private Sub frmConsultaFoliosCancelados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BarraBotones.Buttons.Item(2).Visible = False
        dtpFCancelacion.Value = Now
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
                Dim oRegistrarCancelados As New frmCancelarFolios(frmCancelarFolios.Operaciones.Registrar, 0)
                oRegistrarCancelados.ShowDialog()
                Actualizar(oRegistrarCancelados.DatosSalvados)
            Case 1
                If grdDatos.VisibleRowCount > 0 Then
                    Dim oModificarCancelados As New frmCancelarFolios(frmCancelarFolios.Operaciones.Modificar, _
                                                CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer))
                    oModificarCancelados.ShowDialog()
                    Actualizar(CType(grdDatos.CurrentRowIndex, Short), oModificarCancelados.DatosSalvados)
                Else
                    Dim Mensajes As New PortatilClasses.Mensaje(11)
                    MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
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

    Private Sub frmConsultaFoliosCancelados_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(28)
        Result = MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub
End Class

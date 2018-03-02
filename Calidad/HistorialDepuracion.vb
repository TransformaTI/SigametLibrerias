Public Class frmHistorialDepuracion
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        btnDeshacer.Enabled = Globales.GetInstance.DeshacerDepuracion
        CargaDepuraciones()
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
    Friend WithEvents imgHistorialDepuracion As System.Windows.Forms.ImageList
    Friend WithEvents tbDepuracionCalle As System.Windows.Forms.ToolBar
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDeshacer As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblDepuraciones As System.Windows.Forms.Label
    Friend WithEvents tabDetalleDepuracion As System.Windows.Forms.TabControl
    Friend WithEvents spltDepuracion As System.Windows.Forms.Splitter
    Friend WithEvents vgDepuracion As CallesColonias.ViewGrid
    Friend WithEvents tabDatosCambiados As System.Windows.Forms.TabPage
    Friend WithEvents tabColoniasBorradas As System.Windows.Forms.TabPage
    Friend WithEvents tabCallesBorradas As System.Windows.Forms.TabPage
    Friend WithEvents vgDatosCambiados As CallesColonias.ViewGrid
    Friend WithEvents vgColoniasBorradas As CallesColonias.ViewGrid
    Friend WithEvents vgCallesBorradas As CallesColonias.ViewGrid
    Friend WithEvents lblFDepuracion As System.Windows.Forms.Label
    Friend WithEvents dtpFDepuracion As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHistorialDepuracion))
        Me.imgHistorialDepuracion = New System.Windows.Forms.ImageList(Me.components)
        Me.tbDepuracionCalle = New System.Windows.Forms.ToolBar()
        Me.btnDeshacer = New System.Windows.Forms.ToolBarButton()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.lblDepuraciones = New System.Windows.Forms.Label()
        Me.tabDetalleDepuracion = New System.Windows.Forms.TabControl()
        Me.tabDatosCambiados = New System.Windows.Forms.TabPage()
        Me.vgDatosCambiados = New CallesColonias.ViewGrid()
        Me.tabColoniasBorradas = New System.Windows.Forms.TabPage()
        Me.vgColoniasBorradas = New CallesColonias.ViewGrid()
        Me.tabCallesBorradas = New System.Windows.Forms.TabPage()
        Me.vgCallesBorradas = New CallesColonias.ViewGrid()
        Me.spltDepuracion = New System.Windows.Forms.Splitter()
        Me.vgDepuracion = New CallesColonias.ViewGrid()
        Me.lblFDepuracion = New System.Windows.Forms.Label()
        Me.dtpFDepuracion = New System.Windows.Forms.DateTimePicker()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.tabDetalleDepuracion.SuspendLayout()
        Me.tabDatosCambiados.SuspendLayout()
        Me.tabColoniasBorradas.SuspendLayout()
        Me.tabCallesBorradas.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgHistorialDepuracion
        '
        Me.imgHistorialDepuracion.ImageStream = CType(resources.GetObject("imgHistorialDepuracion.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgHistorialDepuracion.TransparentColor = System.Drawing.Color.Transparent
        Me.imgHistorialDepuracion.Images.SetKeyName(0, "")
        Me.imgHistorialDepuracion.Images.SetKeyName(1, "")
        Me.imgHistorialDepuracion.Images.SetKeyName(2, "")
        Me.imgHistorialDepuracion.Images.SetKeyName(3, "")
        '
        'tbDepuracionCalle
        '
        Me.tbDepuracionCalle.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbDepuracionCalle.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnDeshacer, Me.btnBuscar, Me.btnActualizar, Me.btnCerrar})
        Me.tbDepuracionCalle.DropDownArrows = True
        Me.tbDepuracionCalle.ImageList = Me.imgHistorialDepuracion
        Me.tbDepuracionCalle.Location = New System.Drawing.Point(0, 0)
        Me.tbDepuracionCalle.Name = "tbDepuracionCalle"
        Me.tbDepuracionCalle.ShowToolTips = True
        Me.tbDepuracionCalle.Size = New System.Drawing.Size(800, 42)
        Me.tbDepuracionCalle.TabIndex = 2
        '
        'btnDeshacer
        '
        Me.btnDeshacer.Enabled = False
        Me.btnDeshacer.ImageIndex = 0
        Me.btnDeshacer.Name = "btnDeshacer"
        Me.btnDeshacer.Text = "Deshacer"
        Me.btnDeshacer.ToolTipText = "Deshacer los cambios hechos en una depuracion"
        '
        'btnBuscar
        '
        Me.btnBuscar.ImageIndex = 3
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.ToolTipText = "Busqueda de colonias"
        '
        'btnActualizar
        '
        Me.btnActualizar.ImageIndex = 1
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.ToolTipText = "Cargar los datos más recientes"
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 2
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar la pantalla de depuracion"
        '
        'lblDepuraciones
        '
        Me.lblDepuraciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDepuraciones.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepuraciones.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblDepuraciones.Location = New System.Drawing.Point(0, 42)
        Me.lblDepuraciones.Name = "lblDepuraciones"
        Me.lblDepuraciones.Size = New System.Drawing.Size(800, 23)
        Me.lblDepuraciones.TabIndex = 3
        Me.lblDepuraciones.Text = " Depuraciones"
        Me.lblDepuraciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabDetalleDepuracion
        '
        Me.tabDetalleDepuracion.Controls.Add(Me.tabDatosCambiados)
        Me.tabDetalleDepuracion.Controls.Add(Me.tabColoniasBorradas)
        Me.tabDetalleDepuracion.Controls.Add(Me.tabCallesBorradas)
        Me.tabDetalleDepuracion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tabDetalleDepuracion.Location = New System.Drawing.Point(0, 357)
        Me.tabDetalleDepuracion.Name = "tabDetalleDepuracion"
        Me.tabDetalleDepuracion.SelectedIndex = 0
        Me.tabDetalleDepuracion.Size = New System.Drawing.Size(800, 232)
        Me.tabDetalleDepuracion.TabIndex = 4
        '
        'tabDatosCambiados
        '
        Me.tabDatosCambiados.BackColor = System.Drawing.Color.Gainsboro
        Me.tabDatosCambiados.Controls.Add(Me.vgDatosCambiados)
        Me.tabDatosCambiados.Location = New System.Drawing.Point(4, 22)
        Me.tabDatosCambiados.Name = "tabDatosCambiados"
        Me.tabDatosCambiados.Size = New System.Drawing.Size(792, 206)
        Me.tabDatosCambiados.TabIndex = 0
        Me.tabDatosCambiados.Text = "Datos cambiados"
        '
        'vgDatosCambiados
        '
        Me.vgDatosCambiados.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgDatosCambiados.CheckCondition = CType(resources.GetObject("vgDatosCambiados.CheckCondition"), System.Collections.ArrayList)
        Me.vgDatosCambiados.DataSource = Nothing
        Me.vgDatosCambiados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgDatosCambiados.FormatColumnNames = New String(-1) {}
        Me.vgDatosCambiados.FullRowSelect = True
        Me.vgDatosCambiados.GridLines = True
        Me.vgDatosCambiados.HidedColumnNames = New String() {"Depuracion", "Consecutivo"}
        Me.vgDatosCambiados.HideSelection = False
        Me.vgDatosCambiados.Location = New System.Drawing.Point(0, 0)
        Me.vgDatosCambiados.MultiSelect = False
        Me.vgDatosCambiados.Name = "vgDatosCambiados"
        Me.vgDatosCambiados.PKColumnNames = Nothing
        Me.vgDatosCambiados.Size = New System.Drawing.Size(792, 206)
        Me.vgDatosCambiados.TabIndex = 0
        Me.vgDatosCambiados.UseCompatibleStateImageBehavior = False
        Me.vgDatosCambiados.View = System.Windows.Forms.View.Details
        '
        'tabColoniasBorradas
        '
        Me.tabColoniasBorradas.BackColor = System.Drawing.Color.Gainsboro
        Me.tabColoniasBorradas.Controls.Add(Me.vgColoniasBorradas)
        Me.tabColoniasBorradas.Location = New System.Drawing.Point(4, 22)
        Me.tabColoniasBorradas.Name = "tabColoniasBorradas"
        Me.tabColoniasBorradas.Size = New System.Drawing.Size(792, 206)
        Me.tabColoniasBorradas.TabIndex = 1
        Me.tabColoniasBorradas.Text = "Colonias borradas"
        '
        'vgColoniasBorradas
        '
        Me.vgColoniasBorradas.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgColoniasBorradas.CheckCondition = CType(resources.GetObject("vgColoniasBorradas.CheckCondition"), System.Collections.ArrayList)
        Me.vgColoniasBorradas.DataSource = Nothing
        Me.vgColoniasBorradas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgColoniasBorradas.FormatColumnNames = New String(-1) {}
        Me.vgColoniasBorradas.FullRowSelect = True
        Me.vgColoniasBorradas.GridLines = True
        Me.vgColoniasBorradas.HidedColumnNames = New String() {"Depuracion"}
        Me.vgColoniasBorradas.HideSelection = False
        Me.vgColoniasBorradas.Location = New System.Drawing.Point(0, 0)
        Me.vgColoniasBorradas.MultiSelect = False
        Me.vgColoniasBorradas.Name = "vgColoniasBorradas"
        Me.vgColoniasBorradas.PKColumnNames = Nothing
        Me.vgColoniasBorradas.Size = New System.Drawing.Size(792, 206)
        Me.vgColoniasBorradas.TabIndex = 0
        Me.vgColoniasBorradas.UseCompatibleStateImageBehavior = False
        Me.vgColoniasBorradas.View = System.Windows.Forms.View.Details
        '
        'tabCallesBorradas
        '
        Me.tabCallesBorradas.BackColor = System.Drawing.Color.Gainsboro
        Me.tabCallesBorradas.Controls.Add(Me.vgCallesBorradas)
        Me.tabCallesBorradas.Location = New System.Drawing.Point(4, 22)
        Me.tabCallesBorradas.Name = "tabCallesBorradas"
        Me.tabCallesBorradas.Size = New System.Drawing.Size(792, 206)
        Me.tabCallesBorradas.TabIndex = 2
        Me.tabCallesBorradas.Text = "Calles borradas"
        '
        'vgCallesBorradas
        '
        Me.vgCallesBorradas.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgCallesBorradas.CheckCondition = CType(resources.GetObject("vgCallesBorradas.CheckCondition"), System.Collections.ArrayList)
        Me.vgCallesBorradas.DataSource = Nothing
        Me.vgCallesBorradas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgCallesBorradas.FormatColumnNames = New String(-1) {}
        Me.vgCallesBorradas.FullRowSelect = True
        Me.vgCallesBorradas.GridLines = True
        Me.vgCallesBorradas.HidedColumnNames = New String() {"Depuracion"}
        Me.vgCallesBorradas.HideSelection = False
        Me.vgCallesBorradas.Location = New System.Drawing.Point(0, 0)
        Me.vgCallesBorradas.MultiSelect = False
        Me.vgCallesBorradas.Name = "vgCallesBorradas"
        Me.vgCallesBorradas.PKColumnNames = Nothing
        Me.vgCallesBorradas.Size = New System.Drawing.Size(792, 206)
        Me.vgCallesBorradas.TabIndex = 0
        Me.vgCallesBorradas.UseCompatibleStateImageBehavior = False
        Me.vgCallesBorradas.View = System.Windows.Forms.View.Details
        '
        'spltDepuracion
        '
        Me.spltDepuracion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.spltDepuracion.Location = New System.Drawing.Point(0, 354)
        Me.spltDepuracion.Name = "spltDepuracion"
        Me.spltDepuracion.Size = New System.Drawing.Size(800, 3)
        Me.spltDepuracion.TabIndex = 5
        Me.spltDepuracion.TabStop = False
        '
        'vgDepuracion
        '
        Me.vgDepuracion.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgDepuracion.CheckCondition = CType(resources.GetObject("vgDepuracion.CheckCondition"), System.Collections.ArrayList)
        Me.vgDepuracion.DataSource = Nothing
        Me.vgDepuracion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgDepuracion.FormatColumnNames = New String(-1) {}
        Me.vgDepuracion.FullRowSelect = True
        Me.vgDepuracion.GridLines = True
        Me.vgDepuracion.HidedColumnNames = New String() {"Depuracion"}
        Me.vgDepuracion.HideSelection = False
        Me.vgDepuracion.Location = New System.Drawing.Point(0, 65)
        Me.vgDepuracion.MultiSelect = False
        Me.vgDepuracion.Name = "vgDepuracion"
        Me.vgDepuracion.PKColumnNames = Nothing
        Me.vgDepuracion.Size = New System.Drawing.Size(800, 289)
        Me.vgDepuracion.TabIndex = 6
        Me.vgDepuracion.UseCompatibleStateImageBehavior = False
        Me.vgDepuracion.View = System.Windows.Forms.View.Details
        '
        'lblFDepuracion
        '
        Me.lblFDepuracion.AutoSize = True
        Me.lblFDepuracion.Location = New System.Drawing.Point(232, 12)
        Me.lblFDepuracion.Name = "lblFDepuracion"
        Me.lblFDepuracion.Size = New System.Drawing.Size(111, 13)
        Me.lblFDepuracion.TabIndex = 7
        Me.lblFDepuracion.Text = "&Fecha de depuración:"
        '
        'dtpFDepuracion
        '
        Me.dtpFDepuracion.Checked = False
        Me.dtpFDepuracion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFDepuracion.Location = New System.Drawing.Point(349, 9)
        Me.dtpFDepuracion.Name = "dtpFDepuracion"
        Me.dtpFDepuracion.ShowCheckBox = True
        Me.dtpFDepuracion.Size = New System.Drawing.Size(96, 21)
        Me.dtpFDepuracion.TabIndex = 8
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Location = New System.Drawing.Point(464, 12)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(47, 13)
        Me.lblUsuario.TabIndex = 9
        Me.lblUsuario.Text = "&Usuario:"
        '
        'txtUsuario
        '
        Me.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsuario.Location = New System.Drawing.Point(512, 9)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(120, 21)
        Me.txtUsuario.TabIndex = 10
        '
        'frmHistorialDepuracion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(800, 589)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.dtpFDepuracion)
        Me.Controls.Add(Me.lblFDepuracion)
        Me.Controls.Add(Me.vgDepuracion)
        Me.Controls.Add(Me.spltDepuracion)
        Me.Controls.Add(Me.tabDetalleDepuracion)
        Me.Controls.Add(Me.lblDepuraciones)
        Me.Controls.Add(Me.tbDepuracionCalle)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmHistorialDepuracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Historial de depuraciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tabDetalleDepuracion.ResumeLayout(False)
        Me.tabDatosCambiados.ResumeLayout(False)
        Me.tabColoniasBorradas.ResumeLayout(False)
        Me.tabCallesBorradas.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Variables globales"
    Private _Depuracion As Integer
#End Region
#Region "Rutinas de Actualizacion"
#Region "Carga general de datos"
    Private Sub Actualizar()
        CargaDepuraciones()
        vgDepuracion.FindFirst("Depuracion", _Depuracion.ToString)
    End Sub
    Private Sub CargaDepuraciones()
        Dim daCC As New SqlDataAdapter("Select * from vwDEPDepuraciones where 1 = 1", Globales.GetInstance.cnSigamet)
        Dim dtDepuracion As New DataTable()
        Me.Cursor = Cursors.WaitCursor
        If dtpFDepuracion.Checked Then
            daCC.SelectCommand.CommandText &= " and dbo.GetFecha(FDepuracion) = @FDepuracion "
            daCC.SelectCommand.Parameters.Add("@FDepuracion", SqlDbType.DateTime).Value = dtpFDepuracion.Value.Date
        End If
        If txtUsuario.Text.Trim <> String.Empty Then
            daCC.SelectCommand.CommandText &= " and Usuario = @Usuario "
            daCC.SelectCommand.Parameters.Add("@Usuario", SqlDbType.Char).Value = txtUsuario.Text.Trim
        End If
        Try
            daCC.Fill(dtDepuracion)
            vgDepuracion.DataSource = dtDepuracion
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub CargaDetalleDepuracion()
        Dim daCC As New SqlDataAdapter("spDEPDetalleDepuracion", Globales.GetInstance.cnSigamet)
        Dim dsDetalleDepuracion As New DataSet()
        daCC.SelectCommand.CommandType = CommandType.StoredProcedure
        daCC.SelectCommand.Parameters.Add("@Depuracion", SqlDbType.Int).Value = _Depuracion
        Me.Cursor = Cursors.WaitCursor
        Try
            daCC.Fill(dsDetalleDepuracion)
            vgDatosCambiados.DataSource = dsDetalleDepuracion.Tables(0)
            vgColoniasBorradas.DataSource = dsDetalleDepuracion.Tables(1)
            vgCallesBorradas.DataSource = dsDetalleDepuracion.Tables(2)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
#End Region
#Region "Carga de datos por acciones de controles"
    Private Sub LimpiaDetalle()
        vgDatosCambiados.DataSource = Nothing
        vgColoniasBorradas.DataSource = Nothing
        vgCallesBorradas.DataSource = Nothing
    End Sub
    Private Sub vgDepuracion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vgDepuracion.SelectedIndexChanged
        Dim dr As DataRow = vgDepuracion.CurrentRow
        If Not dr Is Nothing Then
            _Depuracion = CInt(dr("Depuracion"))
            btnDeshacer.Enabled = CStr(dr("Status")) = "HECHO"
            CargaDetalleDepuracion()
        Else
            _Depuracion = -1
            LimpiaDetalle()
        End If
    End Sub
#End Region
#End Region
#Region "Eventos de la barra de herramientas"
    Private Sub tbDepuracionCalle_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbDepuracionCalle.ButtonClick
        Select Case e.Button.Text
            Case "Deshacer"
                DeshacerDepuracion()
            Case "Buscar"
                BuscaDepuracion()
            Case "Actualizar"
                Actualizar()
            Case "Cerrar"
                Me.Close()
                Me.Dispose()
        End Select
    End Sub
#End Region
#Region "Procesado de datos"
    Private Sub BuscaDepuracion()
        Dim Nombre As String = InputBox("Nombre:", "Busqueda de depuraciones.").Trim
        If Nombre <> String.Empty Then
            If vgDepuracion.FindFirst("Nombre", Nombre, True) < 0 Then
                MessageBox.Show("No se encontro la depuración de la calle/colonia """ & Nombre & """", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
    Private Sub DeshacerDepuracion()
        Dim dr As DataRow = vgDepuracion.CurrentRow
        If Not dr Is Nothing AndAlso MessageBox.Show("¿Desea deshacer la depuracion de la " & CStr(dr("Catalogo")).Trim.ToLower & " """ & CStr(dr("Nombre")).Trim & """?", _
                                        Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                                        MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Dim cmdCC As New SqlCommand("spDEPDeshacerDepuracion", Globales.GetInstance.cnSigamet)
            Dim frmProcesando As New frmProcesando()
            Dim DepTransac As SqlTransaction = Nothing
            cmdCC.CommandType = CommandType.StoredProcedure
            cmdCC.CommandTimeout = 360
            cmdCC.Parameters.Add("@Depuracion", SqlDbType.Int).Value = _Depuracion
            Try
                Globales.GetInstance.AbreConexion()
                DepTransac = Globales.GetInstance.cnSigamet.BeginTransaction
                cmdCC.Transaction = DepTransac
                Me.Cursor = Cursors.WaitCursor
                frmProcesando.Show()
                frmProcesando.Refresh()
                Application.DoEvents()
                cmdCC.ExecuteNonQuery()
                frmProcesando.Dispose()
                MessageBox.Show("Se ha cancelado correctamente la depuracion.", Application.ProductName & " v." & Application.ProductVersion, _
                     MessageBoxButtons.OK, MessageBoxIcon.Information)
                DepTransac.Commit()
                Actualizar()
            Catch ex As Exception
                Globales.GetInstance.ExMessage(ex)
                DepTransac.Rollback()
            Finally
                Globales.GetInstance.CierraConexion()
                If Not frmProcesando Is Nothing Then
                    frmProcesando.Dispose()
                End If
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub
#End Region
End Class

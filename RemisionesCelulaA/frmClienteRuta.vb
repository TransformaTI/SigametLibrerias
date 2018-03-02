
Imports System.Data.SqlClient

Public Class frmClienteRuta
    Inherits System.Windows.Forms.Form
    Private _Cliente As Integer
    Private _DatosCargados As Boolean

    'Para modificar el status de calidad
    Private _StatusCalidad As String

    Private connection As SqlConnection


    Private CelulaA As CelulaA

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
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colDireccionCompleta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatusCalidad As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colRamoCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colGiroCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents GrdCelulaA1 As RemisionesCelulaA.GrdCelulaA
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAceptar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolBarButton
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboRuta As System.Windows.Forms.ComboBox
    Friend WithEvents btnCargarDatos As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents div2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents div1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmClienteRuta))
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDireccionCompleta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatusCalidad = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRamoCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colGiroCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.GrdCelulaA1 = New RemisionesCelulaA.GrdCelulaA()
        Me.ToolBar1 = New System.Windows.Forms.ToolBar()
        Me.btnConsultar = New System.Windows.Forms.ToolBarButton()
        Me.btnRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.div1 = New System.Windows.Forms.ToolBarButton()
        Me.btnAceptar = New System.Windows.Forms.ToolBarButton()
        Me.btnCancelar = New System.Windows.Forms.ToolBarButton()
        Me.div2 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.btnCargarDatos = New System.Windows.Forms.Button()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboRuta = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.GroupBox1.SuspendLayout()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imgLista
        '
        Me.imgLista.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista.ImageStream = CType(resources.GetObject("imgLista.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.MappingName = ""
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.MappingName = ""
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.MappingName = ""
        Me.DataGridTextBoxColumn5.Width = 75
        '
        'colCliente
        '
        Me.colCliente.Format = ""
        Me.colCliente.FormatInfo = Nothing
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.MappingName = "Cliente"
        Me.colCliente.Width = 90
        '
        'colNombre
        '
        Me.colNombre.Format = ""
        Me.colNombre.FormatInfo = Nothing
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.MappingName = "Nombre"
        Me.colNombre.Width = 250
        '
        'colDireccionCompleta
        '
        Me.colDireccionCompleta.Format = ""
        Me.colDireccionCompleta.FormatInfo = Nothing
        Me.colDireccionCompleta.HeaderText = "Dirección"
        Me.colDireccionCompleta.MappingName = "DireccionCompleta"
        Me.colDireccionCompleta.Width = 200
        '
        'colStatus
        '
        Me.colStatus.Format = ""
        Me.colStatus.FormatInfo = Nothing
        Me.colStatus.HeaderText = "Estatus"
        Me.colStatus.MappingName = "Status"
        Me.colStatus.Width = 75
        '
        'colStatusCalidad
        '
        Me.colStatusCalidad.Format = ""
        Me.colStatusCalidad.FormatInfo = Nothing
        Me.colStatusCalidad.HeaderText = "E.Calidad"
        Me.colStatusCalidad.MappingName = "StatusCalidad"
        Me.colStatusCalidad.Width = 75
        '
        'colRamoCliente
        '
        Me.colRamoCliente.Format = ""
        Me.colRamoCliente.FormatInfo = Nothing
        Me.colRamoCliente.HeaderText = "Ramo del cliente"
        Me.colRamoCliente.MappingName = "RamoClienteDescripcion"
        Me.colRamoCliente.Width = 75
        '
        'colGiroCliente
        '
        Me.colGiroCliente.Format = ""
        Me.colGiroCliente.FormatInfo = Nothing
        Me.colGiroCliente.HeaderText = "Giro del cliente"
        Me.colGiroCliente.MappingName = "GiroClienteDescripcion"
        Me.colGiroCliente.Width = 75
        '
        'GrdCelulaA1
        '
        Me.GrdCelulaA1.AutoScroll = True
        Me.GrdCelulaA1.Location = New System.Drawing.Point(8, 88)
        Me.GrdCelulaA1.Name = "GrdCelulaA1"
        Me.GrdCelulaA1.Size = New System.Drawing.Size(961, 503)
        Me.GrdCelulaA1.TabIndex = 66
        '
        'ToolBar1
        '
        Me.ToolBar1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnConsultar, Me.btnRefrescar, Me.div1, Me.btnAceptar, Me.btnCancelar, Me.div2, Me.btnCerrar})
        Me.ToolBar1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.imgLista
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(986, 39)
        Me.ToolBar1.TabIndex = 70
        '
        'btnConsultar
        '
        Me.btnConsultar.ImageIndex = 1
        Me.btnConsultar.Tag = "Consultar"
        Me.btnConsultar.Text = "C&onsultar"
        '
        'btnRefrescar
        '
        Me.btnRefrescar.ImageIndex = 2
        Me.btnRefrescar.Tag = "Refrescar"
        Me.btnRefrescar.Text = "&Refrescar"
        '
        'div1
        '
        Me.div1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnAceptar
        '
        Me.btnAceptar.ImageIndex = 4
        Me.btnAceptar.Tag = "Aceptar"
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.ImageIndex = 5
        Me.btnCancelar.Tag = "Cancelar"
        Me.btnCancelar.Text = "&Cancelar"
        '
        'div2
        '
        Me.div2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 3
        Me.btnCerrar.Tag = "Cerrar"
        Me.btnCerrar.Text = "&Salir"
        '
        'btnCargarDatos
        '
        Me.btnCargarDatos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCargarDatos.Image = CType(resources.GetObject("btnCargarDatos.Image"), System.Drawing.Bitmap)
        Me.btnCargarDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCargarDatos.Location = New System.Drawing.Point(280, 12)
        Me.btnCargarDatos.Name = "btnCargarDatos"
        Me.btnCargarDatos.Size = New System.Drawing.Size(100, 23)
        Me.btnCargarDatos.TabIndex = 75
        Me.btnCargarDatos.Text = "    Cargar &Datos"
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(56, 13)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(80, 21)
        Me.cboCelula.TabIndex = 73
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 14)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Célula:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(146, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 14)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Ruta:"
        '
        'cboRuta
        '
        Me.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRuta.Location = New System.Drawing.Point(184, 13)
        Me.cboRuta.Name = "cboRuta"
        Me.cboRuta.Size = New System.Drawing.Size(80, 21)
        Me.cboRuta.TabIndex = 74
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCargarDatos, Me.Label2, Me.Label1, Me.cboCelula, Me.cboRuta})
        Me.GroupBox1.Location = New System.Drawing.Point(-2, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(998, 41)
        Me.GroupBox1.TabIndex = 76
        Me.GroupBox1.TabStop = False
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 601)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(986, 22)
        Me.StatusBar1.TabIndex = 77
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Width = 950
        '
        'frmClienteRuta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(986, 623)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.StatusBar1, Me.ToolBar1, Me.GrdCelulaA1, Me.GroupBox1})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmClienteRuta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes por ruta"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal conexion As SqlConnection)

        MyBase.New()
        InitializeComponent()

        connection = SigaMetClasses.DataLayer.Conexion

        cargaCelula()

    End Sub

    Private Sub frmClienteRuta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If cboCelula.Items.Count > 0 Then
            cboCelula.SelectedIndex = 0
        End If
        Dim _shrCelula As Short = CType(cboCelula.SelectedValue, Short)

        _DatosCargados = True
    End Sub

    Private Sub Modificar()
        'If _Cliente <> 0 Then
        '    If _StatusCalidad <> "VERIFICADO" Or oSeguridad.TieneAcceso("Calidad") Then
        '        Cursor = Cursors.WaitCursor
        '        Dim oModifica As New SigaMetClasses.ModificaCliente(_Cliente, GLOBAL_Usuario, PermiteModificarStatus:=oSeguridad.TieneAcceso("Calidad"), _
        '            PermiteModificarStatusCalidad:=oSeguridad.TieneAcceso("ModificarStatusCalidad"))
        '        If oModifica.ShowDialog() = DialogResult.OK Then
        '            CargaDatos()
        '        End If
        '        Cursor = Cursors.Default
        '    Else
        '        MessageBox.Show("El cliente no puede ser modificado porque tiene estatus VERIFICADO.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'End If
    End Sub

    Private Sub Consultar()
        If _Cliente <> 0 Then
            Cursor = Cursors.WaitCursor
            Dim oConsultaCliente As New SigaMetClasses.frmConsultaCliente(_Cliente, PermiteCapturarNotas:=False)
            oConsultaCliente.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Refrescar()
        cargaClientes()
    End Sub

    Private Sub grdCliente_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '_Cliente = CType(GrdCelulaA1.
            '_StatusCalidad = CType(grdCliente.Item(grdCliente.CurrentRowIndex, 4), String).Trim
            'lnkModificar.Enabled = True
            'btnModificar.Enabled = True
            'lnkConsultar.Enabled = True
            'btnConsultar.Enabled = True
        Catch
            '_Cliente = 0
            '_StatusCalidad = ""
            'lnkModificar.Enabled = False
            'btnModificar.Enabled = False
            'lnkConsultar.Enabled = False
            'btnConsultar.Enabled = False
        End Try

    End Sub

    Private Sub lnkCerrar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub cboCelula_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedIndexChanged
        cargaRuta(CInt(cboCelula.SelectedValue))
        If cboRuta.Items.Count > 0 Then
            cboRuta.SelectedIndex = 0
        End If
    End Sub

    Private Sub lnkCargarDatos_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        cargaClientes()
    End Sub

    Private Sub cargaCelula()
        CelulaA = New CelulaA(connection)
        CelulaA.cargaCelulas()
        cboCelula.ValueMember = CelulaA.celulasA.Columns(0).ColumnName
        cboCelula.DisplayMember = CelulaA.celulasA.Columns(1).ColumnName
        cboCelula.DataSource = CelulaA.celulasA
    End Sub

    Private Sub cargaRuta(ByVal celula As Integer)
        cboRuta.DataSource = Nothing
        cboRuta.ValueMember = Nothing
        cboRuta.DisplayMember = Nothing
        CelulaA.cargaRutas(celula)
        cboRuta.ValueMember = CelulaA.Rutas.Columns(0).ColumnName
        cboRuta.DisplayMember = CelulaA.Rutas.Columns(1).ColumnName
        cboRuta.DataSource = CelulaA.Rutas
    End Sub

    Private Sub cargaClientes()
        CelulaA.cargaClientes(CType(cboRuta.SelectedValue, Integer))
        GrdCelulaA1.CargaDatos(CelulaA.Clientes)
        StatusBarPanel1.Text = CelulaA.Clientes.Rows.Count.ToString & " clientes"
    End Sub

    Private Sub GuardarDatos()
        Try
            If CelulaA.GuardarDatos() Then
                MessageBox.Show("Datos guardados correctamente", "Célula A", MessageBoxButtons.OK, MessageBoxIcon.Information)
                GrdCelulaA1.CargaDatos(CelulaA.Clientes)
            End If
        Catch ex As SqlException
            MessageBox.Show("Ha ocurrido el siguiente error " & ex.Number.ToString & " " & ex.Message, "Célula A", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GrdCelulaA1.CargaDatos(CelulaA.Clientes)
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error " & " " & ex.Message, "Célula A", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GrdCelulaA1.CargaDatos(CelulaA.Clientes)
        End Try
    End Sub

    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case "Modificar"
                Modificar()
            Case "Consultar"
                Consultar()
            Case "Refrescar"
                Refrescar()
            Case "Cerrar"
                Me.Close()
            Case "Aceptar"
                Me.GuardarDatos()
            Case "Cancelar"
                Refrescar()
        End Select
    End Sub

    Private Sub btnCargarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarDatos.Click
        cargaClientes()
    End Sub

    Private Sub GrdCelulaA1_grdRowSelectChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdCelulaA1.grdRowSelectChanged
        _Cliente = DirectCast(sender, GrdCelulaA).Cliente
    End Sub

    Private Sub GrdCelulaA1_AutoResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdCelulaA1.AutoResize
        GrdCelulaA1.Width = 978
        GrdCelulaA1.AutoScroll = True
    End Sub

    Private Sub GrdCelulaA1_AutoResize1(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdCelulaA1.AutoResize1
        GrdCelulaA1.Width = 961
        GrdCelulaA1.AutoScroll = False
    End Sub
End Class

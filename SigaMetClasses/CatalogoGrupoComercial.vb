Imports System.Data.SqlClient, System.Windows.Forms
Imports System.Collections.Generic

Public Class CatalogoGrupoComercial

    Inherits System.Windows.Forms.Form
    Public Usuario As String

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
    Friend WithEvents grdEmpresa As System.Windows.Forms.DataGrid
    Friend WithEvents tbBarra As System.Windows.Forms.ToolBar
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgLista1 As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents EstiloTabla As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents cCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents cEmpresa As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents cGrupoComercial As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents cStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents cNotas As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents cFAlta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents cNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents cUsuarioAlta As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CatalogoGrupoComercial))
        Me.grdEmpresa = New System.Windows.Forms.DataGrid()
        Me.EstiloTabla = New System.Windows.Forms.DataGridTableStyle()
        Me.cCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.cEmpresa = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.cGrupoComercial = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.cStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.cNotas = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.cFAlta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.cUsuarioAlta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.tbBarra = New System.Windows.Forms.ToolBar()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.btnConsultar = New System.Windows.Forms.ToolBarButton()
        Me.btnRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.imgLista1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu()
        Me.cNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        CType(Me.grdEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdEmpresa
        '
        Me.grdEmpresa.AlternatingBackColor = System.Drawing.Color.LightGray
        Me.grdEmpresa.BackColor = System.Drawing.Color.DarkGray
        Me.grdEmpresa.CaptionBackColor = System.Drawing.Color.White
        Me.grdEmpresa.CaptionFont = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdEmpresa.CaptionForeColor = System.Drawing.Color.Navy
        Me.grdEmpresa.DataMember = ""
        Me.grdEmpresa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdEmpresa.ForeColor = System.Drawing.Color.Black
        Me.grdEmpresa.GridLineColor = System.Drawing.Color.Black
        Me.grdEmpresa.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.grdEmpresa.HeaderBackColor = System.Drawing.Color.Silver
        Me.grdEmpresa.HeaderForeColor = System.Drawing.Color.Black
        Me.grdEmpresa.LinkColor = System.Drawing.Color.Navy
        Me.grdEmpresa.Location = New System.Drawing.Point(0, 42)
        Me.grdEmpresa.Name = "grdEmpresa"
        Me.grdEmpresa.ParentRowsBackColor = System.Drawing.Color.White
        Me.grdEmpresa.ParentRowsForeColor = System.Drawing.Color.Black
        Me.grdEmpresa.ReadOnly = True
        Me.grdEmpresa.SelectionBackColor = System.Drawing.Color.Navy
        Me.grdEmpresa.SelectionForeColor = System.Drawing.Color.White
        Me.grdEmpresa.Size = New System.Drawing.Size(744, 380)
        Me.grdEmpresa.TabIndex = 4
        Me.grdEmpresa.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.EstiloTabla})
        '
        'EstiloTabla
        '
        Me.EstiloTabla.DataGrid = Me.grdEmpresa
        Me.EstiloTabla.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.cCliente, Me.cNombre, Me.cEmpresa, Me.cGrupoComercial, Me.cStatus, Me.cNotas, Me.cFAlta, Me.cUsuarioAlta})
        Me.EstiloTabla.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.EstiloTabla.MappingName = "CatalogoGC"
        Me.EstiloTabla.ReadOnly = True
        '
        'cCliente
        '
        Me.cCliente.Format = ""
        Me.cCliente.FormatInfo = Nothing
        Me.cCliente.HeaderText = "Cliente"
        Me.cCliente.MappingName = "Cliente"
        Me.cCliente.ReadOnly = True
        Me.cCliente.Width = 75
        '
        'cEmpresa
        '
        Me.cEmpresa.Format = ""
        Me.cEmpresa.FormatInfo = Nothing
        Me.cEmpresa.HeaderText = "Empresa"
        Me.cEmpresa.MappingName = "Empresa"
        Me.cEmpresa.ReadOnly = True
        Me.cEmpresa.Width = 75
        '
        'cGrupoComercial
        '
        Me.cGrupoComercial.Format = ""
        Me.cGrupoComercial.FormatInfo = Nothing
        Me.cGrupoComercial.HeaderText = "Grupo Comercial"
        Me.cGrupoComercial.MappingName = "GrupoComercial"
        Me.cGrupoComercial.ReadOnly = True
        Me.cGrupoComercial.Width = 75
        '
        'cStatus
        '
        Me.cStatus.Format = ""
        Me.cStatus.FormatInfo = Nothing
        Me.cStatus.HeaderText = "Status"
        Me.cStatus.MappingName = "Status"
        Me.cStatus.ReadOnly = True
        Me.cStatus.Width = 80
        '
        'cNotas
        '
        Me.cNotas.Format = ""
        Me.cNotas.FormatInfo = Nothing
        Me.cNotas.HeaderText = "Notas"
        Me.cNotas.MappingName = "Notas"
        Me.cNotas.ReadOnly = True
        Me.cNotas.Width = 300
        '
        'cFAlta
        '
        Me.cFAlta.Format = ""
        Me.cFAlta.FormatInfo = Nothing
        Me.cFAlta.HeaderText = "Fecha Alta"
        Me.cFAlta.MappingName = "FAlta"
        Me.cFAlta.ReadOnly = True
        Me.cFAlta.Width = 200
        '
        'cUsuarioAlta
        '
        Me.cUsuarioAlta.Format = ""
        Me.cUsuarioAlta.FormatInfo = Nothing
        Me.cUsuarioAlta.HeaderText = "Usuario Alta"
        Me.cUsuarioAlta.MappingName = "UsuarioAlta"
        Me.cUsuarioAlta.ReadOnly = True
        Me.cUsuarioAlta.Width = 75
        '
        'tbBarra
        '
        Me.tbBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAgregar, Me.btnConsultar, Me.btnRefrescar, Me.btnBuscar, Me.btnCerrar})
        Me.tbBarra.DropDownArrows = True
        Me.tbBarra.ImageList = Me.imgLista1
        Me.tbBarra.Location = New System.Drawing.Point(0, 0)
        Me.tbBarra.Name = "tbBarra"
        Me.tbBarra.ShowToolTips = True
        Me.tbBarra.Size = New System.Drawing.Size(744, 42)
        Me.tbBarra.TabIndex = 3
        '
        'btnAgregar
        '
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Tag = "Agregar"
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.ToolTipText = "Agregar una nueva empresa"
        '
        'btnConsultar
        '
        Me.btnConsultar.ImageIndex = 4
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Tag = "Consultar"
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.ToolTipText = "Consultar la empresa seleccionada"
        '
        'btnRefrescar
        '
        Me.btnRefrescar.ImageIndex = 2
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Tag = "Refrescar"
        Me.btnRefrescar.Text = "Refrescar"
        Me.btnRefrescar.ToolTipText = "Refrescar la información"
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 3
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Tag = "Cerrar"
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar"
        '
        'imgLista1
        '
        Me.imgLista1.ImageStream = CType(resources.GetObject("imgLista1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista1.TransparentColor = System.Drawing.Color.Tan
        Me.imgLista1.Images.SetKeyName(0, "")
        Me.imgLista1.Images.SetKeyName(1, "")
        Me.imgLista1.Images.SetKeyName(2, "")
        Me.imgLista1.Images.SetKeyName(3, "")
        Me.imgLista1.Images.SetKeyName(4, "")
        Me.imgLista1.Images.SetKeyName(5, "search.ico")
        '
        'cNombre
        '
        Me.cNombre.Format = ""
        Me.cNombre.FormatInfo = Nothing
        Me.cNombre.HeaderText = "Nombre"
        Me.cNombre.MappingName = "Nombre"
        Me.cNombre.ReadOnly = True
        Me.cNombre.Width = 250
        '
        'btnBuscar
        '
        Me.btnBuscar.ImageIndex = 5
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Tag = "Buscar"
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.ToolTipText = "Buscar por No. Contrato o Nombre"
        '
        'CatalogoGrupoComercial
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(744, 422)
        Me.Controls.Add(Me.grdEmpresa)
        Me.Controls.Add(Me.tbBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CatalogoGrupoComercial"
        Me.Text = "Grupos Comerciales"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Sub Inicio(ByVal usuario As String)
        Me.Usuario = usuario
    End Sub

    Private Sub CatalogoGrupoComercial_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaDatos(0, "")
    End Sub

    Private Sub CargaDatos(ByVal cliente As Integer, ByVal nombre As String)
        Cursor = Cursors.WaitCursor

        Dim conn As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand("spCCConsultaGrupoComercial", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = IIf(cliente = 0, DBNull.Value, cliente)
        cmd.Parameters.Add("@Nombre", SqlDbType.Char).Value = IIf(nombre = "", DBNull.Value, nombre)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable("CatalogoGC")

        Try
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                grdEmpresa.DataSource = dt
                grdEmpresa.CaptionText = "Catálogo Grupo Comercial"

            Else
                grdEmpresa.CaptionText = "No existen datos en el Catálogo Grupo Comercial"
                grdEmpresa.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            dt.Dispose()
            If Not conn Is Nothing Then
                If conn.State = ConnectionState.Open Then conn.Close()
            End If
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Agregar()
        Dim formAltaGrupoComercial As New AltaGrupoComercial()
        formAltaGrupoComercial.LoadOrders(Me.Usuario)
        formAltaGrupoComercial.ShowDialog()
        CargaDatos(0, "")
    End Sub

    Private Sub Consultar()
        If grdEmpresa.IsSelected(grdEmpresa.CurrentRowIndex) <> Nothing Then
            Dim tipo As Int32
            Dim referencia As Int32
            Dim grupoComercial As Int32 = CType(grdEmpresa.Item(grdEmpresa.CurrentRowIndex, 3), Int32)
            If Not grdEmpresa.Item(grdEmpresa.CurrentRowIndex, 0) Is DBNull.Value Then
                tipo = 1
                referencia = CType(grdEmpresa.Item(grdEmpresa.CurrentRowIndex, 0), Int32)
            Else
                tipo = 0
                referencia = CType(grdEmpresa.Item(grdEmpresa.CurrentRowIndex, 2), Int32)
            End If

            Dim frmPantallaAsignacion As New PantallaAsignacion()
            frmPantallaAsignacion.LoadOrders(grupoComercial, referencia, tipo)
            frmPantallaAsignacion.ShowDialog()

        Else
            MessageBox.Show("Debé seleccionar una fila del grid", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub tbBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case "Agregar"
                Agregar()
            Case "Consultar"
                Consultar()
            Case "Refrescar"
                Cursor = Cursors.WaitCursor
                CargaDatos(0, "")
                Cursor = Cursors.Default
            Case "Buscar"

                Dim cliente As Integer
                Dim nombre As String

                Dim frmBuscar As New frmGrupoComercialBusquedaPorCliente()
                frmBuscar.ShowDialog()

                If frmBuscar.DialogResult = Windows.Forms.DialogResult.OK Then
                    Dim datos As New Dictionary(Of String, String)
                    datos = frmBuscar.Tag
                    cliente = datos.Item("cliente")
                    nombre = datos.Item("nombre")
                    CargaDatos(cliente, nombre)
                End If
            Case "Cerrar"
                Me.Close()
        End Select
    End Sub


End Class

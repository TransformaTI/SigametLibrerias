Imports System.Data.SqlClient, System.Windows.Forms
Public Class PantallaAsignacion
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents grdClientes As System.Windows.Forms.DataGrid
    Friend WithEvents pnlDatos As System.Windows.Forms.Panel
    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents EstiloTabla As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents CCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents CNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbtCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rbtEmpresa As System.Windows.Forms.RadioButton
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblReferencia As System.Windows.Forms.Label
    Friend WithEvents btnQuitar As System.Windows.Forms.Button
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblIdGrupoComercial As System.Windows.Forms.Label
    Friend WithEvents lblDomicilio As System.Windows.Forms.Label
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents txtGrupoComercial As System.Windows.Forms.TextBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PantallaAsignacion))
        Me.grdClientes = New System.Windows.Forms.DataGrid()
        Me.EstiloTabla = New System.Windows.Forms.DataGridTableStyle()
        Me.CCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.CNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbtCliente = New System.Windows.Forms.RadioButton()
        Me.rbtEmpresa = New System.Windows.Forms.RadioButton()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblReferencia = New System.Windows.Forms.Label()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblIdGrupoComercial = New System.Windows.Forms.Label()
        Me.lblDomicilio = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.txtGrupoComercial = New System.Windows.Forms.TextBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.pnlGrid = New System.Windows.Forms.Panel()
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatos.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdClientes
        '
        Me.grdClientes.AlternatingBackColor = System.Drawing.Color.LightGray
        Me.grdClientes.BackColor = System.Drawing.Color.DarkGray
        Me.grdClientes.CaptionBackColor = System.Drawing.Color.White
        Me.grdClientes.CaptionFont = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdClientes.CaptionForeColor = System.Drawing.Color.Navy
        Me.grdClientes.DataMember = ""
        Me.grdClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClientes.ForeColor = System.Drawing.Color.Black
        Me.grdClientes.GridLineColor = System.Drawing.Color.Black
        Me.grdClientes.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.grdClientes.HeaderBackColor = System.Drawing.Color.Silver
        Me.grdClientes.HeaderForeColor = System.Drawing.Color.Black
        Me.grdClientes.LinkColor = System.Drawing.Color.Navy
        Me.grdClientes.Name = "grdClientes"
        Me.grdClientes.ParentRowsBackColor = System.Drawing.Color.White
        Me.grdClientes.ParentRowsForeColor = System.Drawing.Color.Black
        Me.grdClientes.PreferredColumnWidth = 50
        Me.grdClientes.ReadOnly = True
        Me.grdClientes.RowHeaderWidth = 30
        Me.grdClientes.SelectionBackColor = System.Drawing.Color.Navy
        Me.grdClientes.SelectionForeColor = System.Drawing.Color.White
        Me.grdClientes.Size = New System.Drawing.Size(536, 213)
        Me.grdClientes.TabIndex = 11
        Me.grdClientes.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.EstiloTabla})
        '
        'EstiloTabla
        '
        Me.EstiloTabla.DataGrid = Me.grdClientes
        Me.EstiloTabla.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.CCliente, Me.CNombre})
        Me.EstiloTabla.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.EstiloTabla.MappingName = "LstCliPorGpoComercial"
        Me.EstiloTabla.PreferredColumnWidth = 25
        Me.EstiloTabla.ReadOnly = True
        Me.EstiloTabla.RowHeaderWidth = 100
        '
        'CCliente
        '
        Me.CCliente.Format = ""
        Me.CCliente.FormatInfo = Nothing
        Me.CCliente.HeaderText = "Cliente"
        Me.CCliente.MappingName = "Cliente"
        Me.CCliente.ReadOnly = True
        Me.CCliente.Width = 70
        '
        'CNombre
        '
        Me.CNombre.Format = ""
        Me.CNombre.FormatInfo = Nothing
        Me.CNombre.HeaderText = "Nombre"
        Me.CNombre.MappingName = "Nombre"
        Me.CNombre.ReadOnly = True
        Me.CNombre.Width = 420
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.btnCancelar, Me.lblReferencia, Me.btnQuitar, Me.txtNombre, Me.lblNombre, Me.lblIdGrupoComercial, Me.lblDomicilio, Me.txtReferencia, Me.txtDomicilio, Me.txtGrupoComercial, Me.btnAgregar})
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDatos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(536, 160)
        Me.pnlDatos.TabIndex = 12
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtCliente, Me.rbtEmpresa})
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(270, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(140, 20)
        Me.Panel1.TabIndex = 48
        '
        'rbtCliente
        '
        Me.rbtCliente.Location = New System.Drawing.Point(80, 4)
        Me.rbtCliente.Name = "rbtCliente"
        Me.rbtCliente.Size = New System.Drawing.Size(60, 16)
        Me.rbtCliente.TabIndex = 0
        Me.rbtCliente.Text = "Cliente"
        '
        'rbtEmpresa
        '
        Me.rbtEmpresa.Location = New System.Drawing.Point(0, 4)
        Me.rbtEmpresa.Name = "rbtEmpresa"
        Me.rbtEmpresa.Size = New System.Drawing.Size(68, 16)
        Me.rbtEmpresa.TabIndex = 1
        Me.rbtEmpresa.Text = "Empresa"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(418, 129)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(108, 23)
        Me.btnCancelar.TabIndex = 47
        Me.btnCancelar.Text = "Cancelar"
        '
        'lblReferencia
        '
        Me.lblReferencia.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblReferencia.AutoSize = True
        Me.lblReferencia.Location = New System.Drawing.Point(10, 41)
        Me.lblReferencia.Name = "lblReferencia"
        Me.lblReferencia.Size = New System.Drawing.Size(61, 14)
        Me.lblReferencia.TabIndex = 39
        Me.lblReferencia.Text = "Referencia:"
        '
        'btnQuitar
        '
        Me.btnQuitar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnQuitar.Enabled = False
        Me.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnQuitar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitar.Image = CType(resources.GetObject("btnQuitar.Image"), System.Drawing.Bitmap)
        Me.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnQuitar.Location = New System.Drawing.Point(306, 129)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(108, 23)
        Me.btnQuitar.TabIndex = 46
        Me.btnQuitar.Text = "Quitar"
        '
        'txtNombre
        '
        Me.txtNombre.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtNombre.Location = New System.Drawing.Point(102, 61)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(424, 21)
        Me.txtNombre.TabIndex = 42
        Me.txtNombre.Text = ""
        '
        'lblNombre
        '
        Me.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(10, 65)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(48, 14)
        Me.lblNombre.TabIndex = 41
        Me.lblNombre.Text = "Nombre:"
        '
        'lblIdGrupoComercial
        '
        Me.lblIdGrupoComercial.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblIdGrupoComercial.AutoSize = True
        Me.lblIdGrupoComercial.Location = New System.Drawing.Point(10, 12)
        Me.lblIdGrupoComercial.Name = "lblIdGrupoComercial"
        Me.lblIdGrupoComercial.Size = New System.Drawing.Size(91, 14)
        Me.lblIdGrupoComercial.TabIndex = 37
        Me.lblIdGrupoComercial.Text = "Grupo Comercial:"
        '
        'lblDomicilio
        '
        Me.lblDomicilio.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblDomicilio.AutoSize = True
        Me.lblDomicilio.Location = New System.Drawing.Point(10, 89)
        Me.lblDomicilio.Name = "lblDomicilio"
        Me.lblDomicilio.Size = New System.Drawing.Size(53, 14)
        Me.lblDomicilio.TabIndex = 43
        Me.lblDomicilio.Text = "Domicilio:"
        '
        'txtReferencia
        '
        Me.txtReferencia.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtReferencia.Location = New System.Drawing.Point(102, 37)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.ReadOnly = True
        Me.txtReferencia.Size = New System.Drawing.Size(152, 21)
        Me.txtReferencia.TabIndex = 40
        Me.txtReferencia.Text = ""
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtDomicilio.Location = New System.Drawing.Point(102, 85)
        Me.txtDomicilio.Multiline = True
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.ReadOnly = True
        Me.txtDomicilio.Size = New System.Drawing.Size(424, 36)
        Me.txtDomicilio.TabIndex = 44
        Me.txtDomicilio.Text = ""
        '
        'txtGrupoComercial
        '
        Me.txtGrupoComercial.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtGrupoComercial.Location = New System.Drawing.Point(102, 8)
        Me.txtGrupoComercial.Name = "txtGrupoComercial"
        Me.txtGrupoComercial.ReadOnly = True
        Me.txtGrupoComercial.Size = New System.Drawing.Size(152, 21)
        Me.txtGrupoComercial.TabIndex = 38
        Me.txtGrupoComercial.Text = ""
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAgregar.Enabled = False
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAgregar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Bitmap)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(194, 129)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(108, 23)
        Me.btnAgregar.TabIndex = 45
        Me.btnAgregar.Text = "Agregar"
        '
        'pnlGrid
        '
        Me.pnlGrid.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdClientes})
        Me.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGrid.Location = New System.Drawing.Point(0, 160)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(536, 213)
        Me.pnlGrid.TabIndex = 13
        '
        'PantallaAsignacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(536, 373)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlGrid, Me.pnlDatos})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "PantallaAsignacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignacion de grupo comercial"
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatos.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnlGrid.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim IdGrupoComercial As Int32
    Dim Referencia As Int32
    Dim Tipo As Int32
    Dim idCliente As Int32 = -1

    Friend Sub LoadOrders(ByVal idGrupoComercial As Int32, ByVal referencia As Int32, ByVal tipo As Int32)
        Me.IdGrupoComercial = idGrupoComercial
        Me.Referencia = referencia
        Me.Tipo = tipo
    End Sub

    Private Sub PantallaAsignacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Cursor = Cursors.WaitCursor
        CargaDatos()
        LlenarListaClientes()
        Cursor = Cursors.Default
    End Sub

    Private Sub LlenarListaClientes()
        Dim conn As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand("spCCObtieneListaClientesPorGpoComercial", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IdGrupoComercial", SqlDbType.Int).Value = Me.IdGrupoComercial
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable("LstCliPorGpoComercial")

        Try
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                grdClientes.DataSource = dt
                grdClientes.CaptionText = "Clientes"
            Else
                grdClientes.CaptionText = "No existen datos en el Catálogo de Clientes"
                grdClientes.DataSource = Nothing
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


    Private Sub CargaDatos()
        Dim conn As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand("spCCObtenerInfoGpoComercialPorTipo", conn)
        Try

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IdGrupoComercial", SqlDbType.Int).Value = Me.IdGrupoComercial
            cmd.Parameters.Add("@Referencia", SqlDbType.Int).Value = Me.Referencia
            cmd.Parameters.Add("@EsCliente", SqlDbType.Int).Value = Me.Tipo
            conn.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                txtGrupoComercial.Text = CType(reader("GrupoComercial"), String)
                txtReferencia.Text = CType(reader("Referencia"), String)
                txtNombre.Text = CType(reader("Nombre"), String)
                txtDomicilio.Text = CType(reader("DireccionCompleta"), String)
                If Me.Tipo = 1 Then
                    rbtCliente.Checked = True
                Else
                    rbtEmpresa.Checked = True
                End If
                btnAgregar.Enabled = True
                btnQuitar.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not conn Is Nothing Then
                If conn.State = ConnectionState.Open Then conn.Close()
            End If
        End Try

    End Sub

    'Private Function BuscarCliente() As oCliente
        'Dim frmBusquedaCliente As New BusquedaCliente()
        'frmBusquedaCliente.ShowDialog()
        'If frmBusquedaCliente.DialogResult = DialogResult.OK Then
        '    idCliente = frmBusquedaCliente.Cliente()
        '    Dim dsDatos As System.Data.DataSet
        '    Dim dtCliente As DataTable, dr As DataRow
        '    Try
        '        Cursor = Cursors.WaitCursor
        '        dsDatos = oCliente.ConsultaDatos(idCliente, , , , True, True)
        '        dtCliente = dsDatos.Tables("Cliente")
        '        For Each dr In dtCliente.Rows
        '            txtReferencia.Text = CType(dr("Cliente"), String)
        '            txtNombre.Text = CType(dr("Nombre"), String)
        '            txtDomicilio.Text = CType(dr("DireccionCompleta"), String)
        '        Next
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "Consulta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Finally
        '        Cursor = Cursors.Default
        '        dtCliente = Nothing
        '        dsDatos = Nothing
        '    End Try
        'End If
    'End Function

    Private Sub Agregar(ByVal cliente As Int32)
        Cursor = Cursors.WaitCursor
        Dim conn As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand("spCCAsignaClienteGpoComercial", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IdGrupoComercial", SqlDbType.VarChar).Value = Me.IdGrupoComercial
        cmd.Parameters.Add("@Cliente", SqlDbType.VarChar).Value = cliente
        Try
            conn.Open()
            Dim res As Int32 = cmd.ExecuteNonQuery()
            If res <> 0 Then
                MessageBox.Show("La asignación fue realizada correctamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LlenarListaClientes()
            Else
                MessageBox.Show("Hubo un error y no se pudo realizar la asignación", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not conn Is Nothing Then
                If conn.State = ConnectionState.Open Then conn.Close()
            End If
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Quitar(ByVal cliente As Int32)
        Cursor = Cursors.WaitCursor
        Dim conn As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand("spCCQuitaClienteGpoComercial", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Cliente", SqlDbType.VarChar).Value = cliente
        Try
            conn.Open()
            Dim res As Int32 = cmd.ExecuteNonQuery()
            If res <> 0 Then
                MessageBox.Show("El registro ha sido eliminado correctamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LlenarListaClientes()
            Else
                MessageBox.Show("Hubo un error y no se pudo realizar la asignación", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not conn Is Nothing Then
                If conn.State = ConnectionState.Open Then conn.Close()
            End If
            Cursor = Cursors.Default
        End Try

    End Sub

    Function ConsultarReferenciaCliente(ByVal cliente As Integer) As String

        Dim resultado As String = Nothing
        Dim conn As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand("spCCConsultarReferenciaCliente", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IdCliente", SqlDbType.VarChar).Value = cliente

        Try
            conn.Open()
            Dim res As Int32 = Nothing
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                If reader("GrupoComercial") Is DBNull.Value Then
                    resultado = "NULL"
                Else
                    resultado += reader("GrupoComercial")
                    resultado += ","
                    resultado += reader("Nombre")
                    resultado = resultado.TrimEnd(New Char() {" "})
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not conn Is Nothing Then
                If conn.State = ConnectionState.Open Then conn.Close()
            End If
            Cursor = Cursors.Default
        End Try
        Return resultado
    End Function

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim frmBusquedaCliente As New BusquedaCliente()
        frmBusquedaCliente.ShowDialog()

        If frmBusquedaCliente.DialogResult = DialogResult.OK Then
            idCliente = frmBusquedaCliente.Cliente()
            Dim resultado As String = ConsultarReferenciaCliente(idCliente)
            If resultado <> "NULL" Then
                Dim miArray() As String = resultado.Split(New Char() {","})
                Dim grupo As String = miArray(0)
                Dim nombre As String = miArray(1)
                MessageBox.Show("No es posible asignar este cliente ," + Chr(13) + "Ya que tiene asignado el grupo comercial " + grupo + "." + Chr(13) + "Con nombre : " + nombre, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                If MessageBox.Show("¿Está seguro que desea asignar este cliente?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                    Agregar(idCliente)
                End If
            End If
        End If
    End Sub

    Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
        If grdClientes.DataSource Is Nothing Then
            MessageBox.Show("No hay datos que quitar", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If grdClientes.IsSelected(grdClientes.CurrentRowIndex) <> Nothing Then
                If MessageBox.Show("¿Está seguro que desea eliminar este registro?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                    Dim cliente As Int32 = CType(grdClientes.Item(grdClientes.CurrentRowIndex, 0), Int32)
                    Quitar(cliente)
                End If
            Else
                MessageBox.Show("Debé seleccionar una fila del grid", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class

Imports System.Data.SqlClient, System.Windows.Forms
Public Class AltaGrupoComercial
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
    Friend WithEvents rbtCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rbtEmpresa As System.Windows.Forms.RadioButton
    Friend WithEvents lblReferencia As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblDomicilio As System.Windows.Forms.Label
    Friend WithEvents lblNotas As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents txtNotas As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AltaGrupoComercial))
        Me.rbtCliente = New System.Windows.Forms.RadioButton()
        Me.rbtEmpresa = New System.Windows.Forms.RadioButton()
        Me.lblReferencia = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblDomicilio = New System.Windows.Forms.Label()
        Me.lblNotas = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.txtNotas = New System.Windows.Forms.TextBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'rbtCliente
        '
        Me.rbtCliente.Checked = True
        Me.rbtCliente.Location = New System.Drawing.Point(84, 4)
        Me.rbtCliente.Name = "rbtCliente"
        Me.rbtCliente.Size = New System.Drawing.Size(68, 16)
        Me.rbtCliente.TabIndex = 0
        Me.rbtCliente.TabStop = True
        Me.rbtCliente.Text = "Cliente"
        '
        'rbtEmpresa
        '
        Me.rbtEmpresa.Location = New System.Drawing.Point(4, 4)
        Me.rbtEmpresa.Name = "rbtEmpresa"
        Me.rbtEmpresa.Size = New System.Drawing.Size(68, 16)
        Me.rbtEmpresa.TabIndex = 1
        Me.rbtEmpresa.Text = "Empresa"
        '
        'lblReferencia
        '
        Me.lblReferencia.AutoSize = True
        Me.lblReferencia.Location = New System.Drawing.Point(8, 8)
        Me.lblReferencia.Name = "lblReferencia"
        Me.lblReferencia.Size = New System.Drawing.Size(61, 14)
        Me.lblReferencia.TabIndex = 3
        Me.lblReferencia.Text = "Referencia:"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(8, 40)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(48, 14)
        Me.lblNombre.TabIndex = 4
        Me.lblNombre.Text = "Nombre:"
        '
        'lblDomicilio
        '
        Me.lblDomicilio.AutoSize = True
        Me.lblDomicilio.Location = New System.Drawing.Point(8, 64)
        Me.lblDomicilio.Name = "lblDomicilio"
        Me.lblDomicilio.Size = New System.Drawing.Size(53, 14)
        Me.lblDomicilio.TabIndex = 5
        Me.lblDomicilio.Text = "Domicilio:"
        '
        'lblNotas
        '
        Me.lblNotas.AutoSize = True
        Me.lblNotas.Location = New System.Drawing.Point(8, 140)
        Me.lblNotas.Name = "lblNotas"
        Me.lblNotas.Size = New System.Drawing.Size(37, 14)
        Me.lblNotas.TabIndex = 6
        Me.lblNotas.Text = "Notas:"
        '
        'txtReferencia
        '
        Me.txtReferencia.Location = New System.Drawing.Point(72, 4)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.ReadOnly = True
        Me.txtReferencia.Size = New System.Drawing.Size(124, 21)
        Me.txtReferencia.TabIndex = 7
        Me.txtReferencia.Text = ""
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(72, 36)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(416, 21)
        Me.txtNombre.TabIndex = 8
        Me.txtNombre.Text = ""
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Location = New System.Drawing.Point(72, 60)
        Me.txtDomicilio.Multiline = True
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.ReadOnly = True
        Me.txtDomicilio.Size = New System.Drawing.Size(416, 72)
        Me.txtDomicilio.TabIndex = 9
        Me.txtDomicilio.Text = ""
        '
        'txtNotas
        '
        Me.txtNotas.Location = New System.Drawing.Point(72, 136)
        Me.txtNotas.Multiline = True
        Me.txtNotas.Name = "txtNotas"
        Me.txtNotas.Size = New System.Drawing.Size(416, 72)
        Me.txtNotas.TabIndex = 10
        Me.txtNotas.Text = ""
        '
        'btnAgregar
        '
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAgregar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Bitmap)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(268, 216)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(108, 23)
        Me.btnAgregar.TabIndex = 11
        Me.btnAgregar.Text = "Agregar"
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtEmpresa, Me.rbtCliente})
        Me.Panel1.Location = New System.Drawing.Point(204, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(152, 20)
        Me.Panel1.TabIndex = 14
        '
        'btnCancelar
        '
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(380, 216)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(108, 23)
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnBuscar
        '
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(380, 4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(108, 23)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.Text = "Buscar"
        '
        'AltaGrupoComercial
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(492, 248)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.btnCancelar, Me.btnAgregar, Me.txtNotas, Me.txtDomicilio, Me.txtNombre, Me.txtReferencia, Me.lblNotas, Me.lblDomicilio, Me.lblNombre, Me.lblReferencia, Me.btnBuscar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "AltaGrupoComercial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de grupo comercial"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim idCliente As Int32 = -1
    Dim idEmpresa As Int32 = -1
    Dim oCliente As New SigaMetClasses.cCliente()
    Dim Usuario As String

    Friend Sub LoadOrders(ByVal usuario As String)
        Me.Usuario = usuario
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

        Agregar()

    End Sub

    Private Sub Agregar()

        Cursor = Cursors.WaitCursor
        Dim conn As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand("spCCAsignaGrupoComercial", conn)
        cmd.CommandType = CommandType.StoredProcedure
        conn.Open()
        cmd.Parameters.Add("@Notas", SqlDbType.VarChar).Value = txtNotas.Text
        cmd.Parameters.Add("@UsuarioAlta", SqlDbType.VarChar).Value = Me.Usuario

        If idCliente <> -1 Or idEmpresa <> -1 Then
            Try
                If idCliente <> -1 Then
                    cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = idCliente
                    cmd.Parameters.Add("@Empresa", SqlDbType.Int).Value = DBNull.Value
                End If
                If idEmpresa <> -1 Then
                    cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = DBNull.Value
                    cmd.Parameters.Add("@Empresa", SqlDbType.Int).Value = idEmpresa
                End If
                Dim res As Int32 = cmd.ExecuteNonQuery()
                If res <> 0 Then
                    MessageBox.Show("La asignación fue realizada correctamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()

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
        Else
            MessageBox.Show("Debé efectuar una busqueda", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        If rbtCliente.Checked = True Then
            Dim frmBusquedaCliente As New BusquedaCliente()
            frmBusquedaCliente.ShowDialog()
            If frmBusquedaCliente.DialogResult = DialogResult.OK Then
                idCliente = frmBusquedaCliente.Cliente()
                Dim dsDatos As System.Data.DataSet
                Dim dtCliente As DataTable, dr As DataRow
                Try
                    Cursor = Cursors.WaitCursor
                    dsDatos = oCliente.ConsultaDatos(idCliente, , , , True, True)
                    dtCliente = dsDatos.Tables("Cliente")
                    For Each dr In dtCliente.Rows
                        txtReferencia.Text = CType(dr("Cliente"), String)
                        txtNombre.Text = CType(dr("Nombre"), String)
                        txtDomicilio.Text = CType(dr("DireccionCompleta"), String)
                    Next
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Consulta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    Cursor = Cursors.Default
                    dtCliente = Nothing
                    dsDatos = Nothing
                End Try
            Else
                idCliente = -1
                txtReferencia.Text = ""
                txtNombre.Text = ""
                txtDomicilio.Text = ""
                txtNotas.Text = ""
            End If
        Else
            Dim frmBusquedaEmpresa As New CatalogoEmpresa()
            frmBusquedaEmpresa.Show()
            If frmBusquedaEmpresa.DialogResult = DialogResult.Yes Then
                idEmpresa = frmBusquedaEmpresa.Empresa()
            Else
                idEmpresa = -1
            End If
        End If
    End Sub

    Private Sub txtNotas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNotas.TextChanged

    End Sub
End Class

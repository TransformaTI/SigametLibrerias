Option Strict On
Imports System.Windows.Forms, System.Data.SqlClient

Public Class frmCancelacionPedido
    Inherits System.Windows.Forms.Form
    Private _AñoPed As Short
    Private _Celula As Byte
    Private _Pedido As Integer
    Private _Titulo As String = "Cancelación de pedidos"
    Private _UserInfo As SigaMetClasses.cUserInfo
    Private _Portatil As Boolean
    Private _connString As String

    Private _TipoPedido As Byte

#Region " Windows Form Designer generated code "

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
    Friend WithEvents cboMotivoCancelacion As SigaMetClasses.Combos.ComboMotivoCancelacion
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtObservacionesMotivoCancelacion As System.Windows.Forms.TextBox
    Friend WithEvents lblPedidoReferencia As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCancelacionPedido))
        Me.cboMotivoCancelacion = New SigaMetClasses.Combos.ComboMotivoCancelacion()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtObservacionesMotivoCancelacion = New System.Windows.Forms.TextBox()
        Me.lblPedidoReferencia = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cboMotivoCancelacion
        '
        Me.cboMotivoCancelacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMotivoCancelacion.Location = New System.Drawing.Point(144, 64)
        Me.cboMotivoCancelacion.Name = "cboMotivoCancelacion"
        Me.cboMotivoCancelacion.Size = New System.Drawing.Size(264, 21)
        Me.cboMotivoCancelacion.TabIndex = 1
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(124, 160)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(220, 160)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtObservacionesMotivoCancelacion
        '
        Me.txtObservacionesMotivoCancelacion.AutoSize = False
        Me.txtObservacionesMotivoCancelacion.Location = New System.Drawing.Point(144, 88)
        Me.txtObservacionesMotivoCancelacion.MaxLength = 150
        Me.txtObservacionesMotivoCancelacion.Multiline = True
        Me.txtObservacionesMotivoCancelacion.Name = "txtObservacionesMotivoCancelacion"
        Me.txtObservacionesMotivoCancelacion.Size = New System.Drawing.Size(264, 56)
        Me.txtObservacionesMotivoCancelacion.TabIndex = 2
        Me.txtObservacionesMotivoCancelacion.Text = ""
        '
        'lblPedidoReferencia
        '
        Me.lblPedidoReferencia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidoReferencia.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblPedidoReferencia.Location = New System.Drawing.Point(144, 16)
        Me.lblPedidoReferencia.Name = "lblPedidoReferencia"
        Me.lblPedidoReferencia.Size = New System.Drawing.Size(264, 20)
        Me.lblPedidoReferencia.TabIndex = 0
        Me.lblPedidoReferencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Pedido:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 14)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Motivo de la cancelación:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 32)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Observaciones de la cancelación:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNombre
        '
        Me.lblNombre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblNombre.Location = New System.Drawing.Point(144, 40)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(264, 20)
        Me.lblNombre.TabIndex = 8
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 14)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Cliente:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmCancelacionPedido
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(418, 207)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label5, Me.lblNombre, Me.Label4, Me.Label3, Me.Label2, Me.lblPedidoReferencia, Me.txtObservacionesMotivoCancelacion, Me.btnCancelar, Me.btnAceptar, Me.cboMotivoCancelacion})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCancelacionPedido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelación de pedidos"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal AñoPed As Short, _
                   ByVal Celula As Byte, _
                   ByVal Pedido As Integer, _
          Optional ByVal UserInfo As SigaMetClasses.cUserInfo = Nothing, _
          Optional ByVal connString As String = Nothing)

        MyBase.New()
        InitializeComponent()

        Cursor = Cursors.WaitCursor

        _AñoPed = AñoPed
        _Celula = Celula
        _Pedido = Pedido
        _UserInfo = UserInfo
        _connString = connString

        Dim oPedido As SigaMetClasses.cPedido, oCliente As SigaMetClasses.cCliente
        Try
            oPedido = New SigaMetClasses.cPedido(_AñoPed, _Celula, _Pedido)
            lblPedidoReferencia.Text = oPedido.PedidoReferencia
            'validar aplicacion por medio del parametro FiltrarMotivosCancelacion
            '_TipoPedido = tipoPedido(_AñoPed, _Celula, _Pedido) Pendiente hasta confirmar los tipos de pedido / producto a cancelar
            Try
                oCliente = New SigaMetClasses.cCliente(oPedido.Cliente)
                lblNombre.Text = oCliente.Nombre
            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Cursor = Cursors.Default
                Exit Sub
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cursor = Cursors.Default
            Exit Sub
        End Try
        'Filtrar solo motivos de cancelación para pedidos de gas LP en esta pantalla
        Me.cboMotivoCancelacion.CargaDatos(False, "WHERE TipoCancelacion = 1")
        If Me.cboMotivoCancelacion.Items.Count <= 0 Then
            Me.btnAceptar.Enabled = False
        End If

        Cursor = Cursors.Default


    End Sub

    Public Sub New(ByVal NombreCliente As String, ByVal Pedido As Integer, Optional ByVal connString As String = Nothing)

        MyBase.New()
        InitializeComponent()
        _connString = connString
        Dim conn As New SqlConnection(connString)
        Dim cmd As New SqlCommand("Select isnull(MotivoCancelacion,0) from PedidoPortatil where PedidoPortatil = @Pedido", conn)

        Cursor = Cursors.WaitCursor

        lblPedidoReferencia.Text = Pedido.ToString
        lblNombre.Text = NombreCliente
        _Pedido = Pedido
        _Portatil = True
        RemoveHandler btnAceptar.Click, AddressOf btnAceptar_Click
        AddHandler btnAceptar.Click, AddressOf btnAceptarPorta_Click

        Me.cboMotivoCancelacion.CargaDatos(False, "where TipoCancelacion = 2")
        If Me.cboMotivoCancelacion.Items.Count <= 0 Then
            Me.btnAceptar.Enabled = False
        End If
        cmd.Parameters.Add("@Pedido", SqlDbType.Int).Value = _Pedido
        Try
            conn.Open()
            cboMotivoCancelacion.SelectedValue = cmd.ExecuteScalar
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            cmd.Dispose()
            'conn.Dispose()
        End Try
        Cursor = Cursors.Default

    End Sub


    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If CType(Me.cboMotivoCancelacion.SelectedValue, Short) <= 0 Then
            MessageBox.Show("Debe seleccionar el motivo de la cancelación del pedido.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If MessageBox.Show(SigaMetClasses.M_ESTAN_CORRECTOS, "Cancelación de pedidos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

            Cursor = Cursors.WaitCursor
            Dim conn As SqlConnection
            If _UserInfo Is Nothing Then
                conn = New SqlConnection(_connString)
                'conn = New SqlConnection(SigaMetClasses.LeeInfoConexion(False, True))
            Else
                conn = New SqlConnection(_UserInfo.ConnectionString)
            End If

            Dim cmd As New SqlCommand("spCCPedidoCancela", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@AñoPed", SqlDbType.SmallInt).Value = _AñoPed
                .Parameters.Add("@Celula", SqlDbType.TinyInt).Value = _Celula
                .Parameters.Add("@Pedido", SqlDbType.Int).Value = _Pedido
                .Parameters.Add("@MotivoCancelacion", SqlDbType.TinyInt).Value = CType(Me.cboMotivoCancelacion.SelectedValue, Short)
                .Parameters.Add("@ObservacionesMotivoCancelacion", SqlDbType.VarChar, 150).Value = txtObservacionesMotivoCancelacion.Text.Trim
            End With

            Try
                conn.Open()

                Try
                    cmd.ExecuteNonQuery()
                    Me.DialogResult = DialogResult.OK
                Catch ex As Exception
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    Cursor = Cursors.Default
                    If Not conn Is Nothing Then
                        If conn.State = ConnectionState.Open Then conn.Close()
                    End If
                    cmd.Dispose()
                End Try

            Catch ex As Exception
                MessageBox.Show(SigaMetClasses.M_NO_CONEXION, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Cursor = Cursors.Default
                Exit Sub
            End Try

        End If

    End Sub

    Private Sub btnAceptarPorta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CType(Me.cboMotivoCancelacion.SelectedValue, Short) <= 0 Then
            MessageBox.Show("Debe seleccionar el motivo de la cancelación del pedido.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If MessageBox.Show(SigaMetClasses.M_ESTAN_CORRECTOS, "Cancelación de pedidos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
            MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

            Cursor = Cursors.WaitCursor
            Dim conn As SqlConnection
            If _UserInfo Is Nothing Then
                conn = New SqlConnection(_connString)
                'conn = New SqlConnection(SigaMetClasses.LeeInfoConexion(False, True))
            Else
                conn = New SqlConnection(_UserInfo.ConnectionString)
            End If

            Dim cmd As New SqlCommand("spCCPedidoPortatilCancela", conn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@Pedido", SqlDbType.Int).Value = _Pedido
                .Parameters.Add("@MotivoCancelacion", SqlDbType.TinyInt).Value = CType(Me.cboMotivoCancelacion.SelectedValue, Short)
                .Parameters.Add("@Observaciones", SqlDbType.VarChar, 150).Value = txtObservacionesMotivoCancelacion.Text.Trim
            End With

            Try
                conn.Open()

                Try
                    cmd.ExecuteNonQuery()
                    Me.DialogResult = DialogResult.OK
                Catch ex As Exception
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    Cursor = Cursors.Default
                    If Not conn Is Nothing Then
                        If conn.State = ConnectionState.Open Then conn.Close()
                    End If
                    cmd.Dispose()
                End Try

            Catch ex As Exception
                MessageBox.Show(SigaMetClasses.M_NO_CONEXION, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Cursor = Cursors.Default
                Exit Sub
            End Try
        End If
    End Sub

    Private Function tipoPedido(ByVal añoped As Integer, ByVal celula As Integer, ByVal pedido As Integer) As Byte
        Dim conn As New SqlConnection(_connString)
        Dim cmdSelect As New SqlCommand("SELECT TipoPedido FROM Pedido WHERE AñoPed = @AñoPed AND Celula = @Celula AND Pedido = @Pedido", conn)
        cmdSelect.Parameters.Add("@AñoPed", SqlDbType.SmallInt).Value = añoped
        cmdSelect.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = celula
        cmdSelect.Parameters.Add("@Pedido", SqlDbType.Int).Value = pedido
        Dim dataReader As SqlDataReader = Nothing
        Try
            conn.Open()
            tipoPedido = CType(cmdSelect.ExecuteScalar, Byte)
        Catch ex As SqlException
            Throw ex
            tipoPedido = 0
        Catch ex As Exception
            Throw ex
            tipoPedido = 0
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Function

End Class
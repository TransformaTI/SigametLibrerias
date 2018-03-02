Option Strict On
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class ReasignaCargoCliente
    Inherits System.Windows.Forms.Form
    Private _Usuario As String
    Private Titulo As String = "Reasignación de cliente a cargo"

    Public Sub New(ByVal strUsuario As String)
        MyBase.New()
        InitializeComponent()
        _Usuario = strUsuario
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
    Friend WithEvents txtPedidoReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblFCargo As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtClienteNuevo As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ReasignaCargoCliente))
        Me.txtPedidoReferencia = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblFCargo = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtClienteNuevo = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPedidoReferencia
        '
        Me.txtPedidoReferencia.Location = New System.Drawing.Point(112, 16)
        Me.txtPedidoReferencia.Name = "txtPedidoReferencia"
        Me.txtPedidoReferencia.Size = New System.Drawing.Size(136, 21)
        Me.txtPedidoReferencia.TabIndex = 0
        Me.txtPedidoReferencia.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Documento:"
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(392, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(392, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 211)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Pasar al cliente:"
        '
        'lblCliente
        '
        Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCliente.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCliente.Location = New System.Drawing.Point(112, 32)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(88, 21)
        Me.lblCliente.TabIndex = 6
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNombre
        '
        Me.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombre.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblNombre.Location = New System.Drawing.Point(112, 56)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(232, 21)
        Me.lblNombre.TabIndex = 7
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFCargo
        '
        Me.lblFCargo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFCargo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblFCargo.Location = New System.Drawing.Point(112, 80)
        Me.lblFCargo.Name = "lblFCargo"
        Me.lblFCargo.Size = New System.Drawing.Size(88, 21)
        Me.lblFCargo.TabIndex = 8
        Me.lblFCargo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal
        '
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblTotal.Location = New System.Drawing.Point(112, 104)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(88, 21)
        Me.lblTotal.TabIndex = 9
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Cliente:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 14)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Nombre:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 14)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "F.Cargo:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 14)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Total:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblNombre, Me.lblTotal, Me.Label4, Me.Label3, Me.Label5, Me.lblCliente, Me.lblFCargo, Me.Label6})
        Me.GroupBox1.Location = New System.Drawing.Point(8, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(360, 144)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del documento"
        '
        'txtClienteNuevo
        '
        Me.txtClienteNuevo.Location = New System.Drawing.Point(112, 208)
        Me.txtClienteNuevo.Name = "txtClienteNuevo"
        Me.txtClienteNuevo.Size = New System.Drawing.Size(136, 21)
        Me.txtClienteNuevo.TabIndex = 1
        Me.txtClienteNuevo.Text = ""
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.Location = New System.Drawing.Point(256, 15)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 23)
        Me.btnBuscar.TabIndex = 15
        '
        'ReasignaCargoCliente
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(472, 253)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBuscar, Me.txtClienteNuevo, Me.GroupBox1, Me.Label2, Me.Label1, Me.btnCancelar, Me.btnAceptar, Me.txtPedidoReferencia})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReasignaCargoCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reasignación de cliente a cargo"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        ConsultaDocumento(UCase(Trim(txtPedidoReferencia.Text)))
    End Sub

    Private Sub ConsultaDocumento(ByVal strPedidoReferencia As String)
        Dim strQuery As String = "Select p.PedidoReferencia, p.Cliente, c.Nombre, p.FCargo, p.Total From vwConsultaPedidosPorClienteCaja p Join Cliente c on p.Cliente = c.Cliente Where p.PedidoReferencia = '" & strPedidoReferencia & "'"
        Dim da As New SqlDataAdapter(strQuery, DataLayer.Conexion)
        Dim dt As New DataTable("Pedido")

        Try
            da.Fill(dt)
            If dt.Rows.Count = 1 Then
                lblCliente.Text = CType(dt.Rows(0).Item("Cliente"), String)
                lblNombre.Text = CType(dt.Rows(0).Item("Nombre"), String)
                If Not IsDBNull(dt.Rows(0).Item("FCargo")) Then
                    lblFCargo.Text = CType(dt.Rows(0).Item("FCargo"), Date).ToShortDateString
                End If
                If Not IsDBNull(dt.Rows(0).Item("Total")) Then
                    lblTotal.Text = CType(dt.Rows(0).Item("Total"), Decimal).ToString("C")
                End If
                txtClienteNuevo.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ReasignaCargoCliente(ByVal strPedidoReferencia As String, _
                                     ByVal intClienteNuevo As Integer, _
                                     ByVal strUsuario As String)
        Dim cmd As New SqlCommand("spCargoModificaCliente")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@PedidoReferencia", SqlDbType.VarChar, 20).Value = strPedidoReferencia
            .Parameters.Add("@ClienteNuevo", SqlDbType.Int).Value = intClienteNuevo
            .Parameters.Add("@Usuario", SqlDbType.Char, 15).Value = strUsuario
        End With

        Try
            AbreConexion()
            cmd.Connection = DataLayer.Conexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LimpiaDatos()
        txtPedidoReferencia.Text = ""
        lblCliente.Text = ""
        lblNombre.Text = ""
        lblFCargo.Text = ""
        lblTotal.Text = ""
        txtClienteNuevo.Text = ""
        txtPedidoReferencia.Focus()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim strMensaje As String = "Se reasignará el documento: " & UCase(Trim(txtPedidoReferencia.Text)) & " al cliente: " & Trim(txtClienteNuevo.Text) & Chr(13)
        If MessageBox.Show(strMensaje & M_ESTAN_CORRECTOS, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Try
                ReasignaCargoCliente(UCase(Trim(txtPedidoReferencia.Text)), CType(txtClienteNuevo.Text, Integer), _Usuario)
                MessageBox.Show(M_DATOS_OK, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                LimpiaDatos()
            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

End Class
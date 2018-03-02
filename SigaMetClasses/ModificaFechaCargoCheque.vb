Option Strict On
Imports System.Data.SqlClient, System.Windows.Forms
Public Class ModificaFechaCargoCheque
    Inherits System.Windows.Forms.Form
    Private _PedidoReferencia As String
    Private Titulo As String = "Modificación de fecha de cargo"

    Public ReadOnly Property PedidoReferencia() As String
        Get
            Return _PedidoReferencia
        End Get
    End Property

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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtPedidoReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents dtpNuevaFCargo As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFCargo As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnDocumento As System.Windows.Forms.Button
    Friend WithEvents lblTipoDocumento As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ModificaFechaCargoCheque))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtPedidoReferencia = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.dtpNuevaFCargo = New System.Windows.Forms.DateTimePicker()
        Me.lblFCargo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnDocumento = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblTipoDocumento = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(368, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(368, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 7
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPedidoReferencia
        '
        Me.txtPedidoReferencia.Location = New System.Drawing.Point(104, 17)
        Me.txtPedidoReferencia.Name = "txtPedidoReferencia"
        Me.txtPedidoReferencia.Size = New System.Drawing.Size(136, 21)
        Me.txtPedidoReferencia.TabIndex = 0
        Me.txtPedidoReferencia.Text = ""
        '
        'lblTotal
        '
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblTotal.Location = New System.Drawing.Point(104, 72)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(248, 21)
        Me.lblTotal.TabIndex = 2
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpNuevaFCargo
        '
        Me.dtpNuevaFCargo.Location = New System.Drawing.Point(104, 120)
        Me.dtpNuevaFCargo.MaxDate = New Date(2010, 12, 31, 0, 0, 0, 0)
        Me.dtpNuevaFCargo.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.dtpNuevaFCargo.Name = "dtpNuevaFCargo"
        Me.dtpNuevaFCargo.Size = New System.Drawing.Size(248, 21)
        Me.dtpNuevaFCargo.TabIndex = 4
        '
        'lblFCargo
        '
        Me.lblFCargo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFCargo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFCargo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblFCargo.Location = New System.Drawing.Point(104, 96)
        Me.lblFCargo.Name = "lblFCargo"
        Me.lblFCargo.Size = New System.Drawing.Size(248, 21)
        Me.lblFCargo.TabIndex = 3
        Me.lblFCargo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 14)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Documento:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 14)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Total:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 14)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "F.Cargo:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 123)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 14)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Nueva F.Cargo:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnDocumento
        '
        Me.btnDocumento.BackColor = System.Drawing.SystemColors.Control
        Me.btnDocumento.Image = CType(resources.GetObject("btnDocumento.Image"), System.Drawing.Bitmap)
        Me.btnDocumento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDocumento.Location = New System.Drawing.Point(280, 15)
        Me.btnDocumento.Name = "btnDocumento"
        Me.btnDocumento.Size = New System.Drawing.Size(72, 24)
        Me.btnDocumento.TabIndex = 6
        Me.btnDocumento.Text = "Datos"
        Me.btnDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.Location = New System.Drawing.Point(248, 16)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(24, 23)
        Me.btnBuscar.TabIndex = 5
        '
        'lblTipoDocumento
        '
        Me.lblTipoDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoDocumento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoDocumento.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblTipoDocumento.Location = New System.Drawing.Point(104, 48)
        Me.lblTipoDocumento.Name = "lblTipoDocumento"
        Me.lblTipoDocumento.Size = New System.Drawing.Size(248, 21)
        Me.lblTipoDocumento.TabIndex = 1
        Me.lblTipoDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 14)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Tipo:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ModificaFechaCargoCheque
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(450, 159)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.lblTipoDocumento, Me.btnBuscar, Me.btnDocumento, Me.Label6, Me.Label5, Me.Label4, Me.Label3, Me.lblFCargo, Me.dtpNuevaFCargo, Me.lblTotal, Me.txtPedidoReferencia, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ModificaFechaCargoCheque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificación de fecha de cargo"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MessageBox.Show("¿Desea reasignar el documento " & _PedidoReferencia & _
         " con fecha " & lblFCargo.Text & Chr(13) & "al día " & dtpNuevaFCargo.Value.ToShortDateString & "?" _
         , Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Try
                ModificaFCargo(_PedidoReferencia, Me.dtpNuevaFCargo.Value.Date)
                MessageBox.Show(SigaMetClasses.M_DATOS_OK, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try



        End If

    End Sub

    Private Sub ModificaFCargo(ByVal PedidoReferencia As String, _
                               ByVal NuevaFecha As Date)
        Dim cmd As New SqlCommand("spCYCModificaFechaDevolucionCargoCheque")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@PedidoReferencia", SqlDbType.Char, 20).Value = PedidoReferencia
            .Parameters.Add("@NuevaFecha", SqlDbType.DateTime).Value = NuevaFecha
        End With

        Try
            cmd.Connection = DataLayer.Conexion
            AbreConexion()
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex

        Finally
            CierraConexion()
            cmd.Dispose()
        End Try

    End Sub

    Private Sub ModificaFechaCargoCheque_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpNuevaFCargo.Value = Now.Date
    End Sub

    Private Sub Limpia()
        lblTotal.Text = String.Empty
        lblFCargo.Text = String.Empty
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Cursor = Cursors.WaitCursor
        Limpia()

        Dim da As New SqlDataAdapter("SELECT PedidoReferencia, StatusPedido, TipoCargo, TipoCargoTipoPedido, Cliente, Total, FCargo FROM vwConsultaPedidosPorClienteCaja WHERE PedidoReferencia = '" & _PedidoReferencia & "'", DataLayer.Conexion)
        Dim dt As New DataTable("Pedido")
        Try
            da.Fill(dt)
            If dt.Rows.Count = 1 Then
                Dim _Estatus As String = Trim(CType(dt.Rows(0).Item("StatusPedido"), String))
                If _Estatus = "CANCELADO" Then
                    If MessageBox.Show("El documento " & _PedidoReferencia & " está cancelado y no puede ser modificado." & _
                    "¿Desea ver más datos del documento?", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation) = DialogResult.Yes Then
                        Dim oConsultaDocumento As New SigaMetClasses.ConsultaCargo(_PedidoReferencia)
                        oConsultaDocumento.ShowDialog()
                    End If

                End If
                lblTipoDocumento.Text = CType(dt.Rows(0).Item("TipoCargoTipoPedido"), String)
                lblTotal.Text = CType(dt.Rows(0).Item("Total"), Decimal).ToString("N")
                lblFCargo.Text = CType(dt.Rows(0).Item("FCargo"), Date).ToShortDateString
            Else
                MessageBox.Show("El documento " & _PedidoReferencia & " no existe en la base de datos.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            dt.Dispose()
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub txtPedidoReferencia_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPedidoReferencia.TextChanged
        _PedidoReferencia = Replace(UCase(Trim(txtPedidoReferencia.Text)), "'", "")
    End Sub

    Private Sub btnDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDocumento.Click
        Cursor = Cursors.WaitCursor
        Dim oConsultaPedido As New ConsultaCargo(_PedidoReferencia)
        oConsultaPedido.ShowDialog()
        Cursor = Cursors.Default
    End Sub

End Class

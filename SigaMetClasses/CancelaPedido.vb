Option Strict On
Imports System.Windows.Forms

Public Class CancelaPedido
    Inherits System.Windows.Forms.Form
    Private _AñoPed As Short
    Private _Celula As Byte
    Private _Pedido As Integer
    Private _PedidoReferencia As String

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
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cboMotivoCancelacion As SigaMetClasses.Combos.ComboMotivoCancelacion
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtObservacionesMotivoCancelacion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPedidoReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CancelaPedido))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.cboMotivoCancelacion = New SigaMetClasses.Combos.ComboMotivoCancelacion()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtObservacionesMotivoCancelacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPedidoReferencia = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(432, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(432, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboMotivoCancelacion
        '
        Me.cboMotivoCancelacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMotivoCancelacion.Location = New System.Drawing.Point(152, 128)
        Me.cboMotivoCancelacion.Name = "cboMotivoCancelacion"
        Me.cboMotivoCancelacion.Size = New System.Drawing.Size(352, 21)
        Me.cboMotivoCancelacion.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Motivo de cancelación:"
        '
        'txtObservacionesMotivoCancelacion
        '
        Me.txtObservacionesMotivoCancelacion.AutoSize = False
        Me.txtObservacionesMotivoCancelacion.Location = New System.Drawing.Point(152, 152)
        Me.txtObservacionesMotivoCancelacion.Multiline = True
        Me.txtObservacionesMotivoCancelacion.Name = "txtObservacionesMotivoCancelacion"
        Me.txtObservacionesMotivoCancelacion.Size = New System.Drawing.Size(352, 48)
        Me.txtObservacionesMotivoCancelacion.TabIndex = 4
        Me.txtObservacionesMotivoCancelacion.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Observaciones:"
        '
        'lblCliente
        '
        Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCliente.Location = New System.Drawing.Point(152, 64)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(152, 21)
        Me.lblCliente.TabIndex = 6
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 14)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Cliente:"
        '
        'lblNombre
        '
        Me.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombre.Location = New System.Drawing.Point(152, 88)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(352, 21)
        Me.lblNombre.TabIndex = 8
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 14)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Nombre:"
        '
        'txtPedidoReferencia
        '
        Me.txtPedidoReferencia.Location = New System.Drawing.Point(152, 16)
        Me.txtPedidoReferencia.Name = "txtPedidoReferencia"
        Me.txtPedidoReferencia.Size = New System.Drawing.Size(152, 21)
        Me.txtPedidoReferencia.TabIndex = 10
        Me.txtPedidoReferencia.Text = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 14)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Documento:"
        '
        'lblTotal
        '
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.Location = New System.Drawing.Point(152, 40)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(152, 21)
        Me.lblTotal.TabIndex = 12
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 14)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Total:"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.Location = New System.Drawing.Point(312, 16)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(24, 21)
        Me.btnBuscar.TabIndex = 14
        '
        'CancelaPedido
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(520, 223)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBuscar, Me.Label5, Me.lblTotal, Me.Label7, Me.txtPedidoReferencia, Me.Label6, Me.lblNombre, Me.Label4, Me.lblCliente, Me.Label2, Me.txtObservacionesMotivoCancelacion, Me.Label1, Me.cboMotivoCancelacion, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CancelaPedido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelación de pedido"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal PedidoReferencia As String)
        MyBase.New()
        InitializeComponent()

        _PedidoReferencia = PedidoReferencia

        Dim oPedido As cPedido = Nothing
        Dim oCliente As cCliente = Nothing

        Try
            Cursor = Cursors.WaitCursor
            oPedido = New SigaMetClasses.cPedido(_PedidoReferencia)
            oCliente = New cCliente(oPedido.Cliente)

            lblTotal.Text = oPedido.Total.ToString("N")
            lblCliente.Text = oPedido.Cliente.ToString
            lblNombre.Text = oCliente.Nombre

            If oPedido.Status = "CANCELADO" Then btnAceptar.Enabled = False

        Catch ex As Exception
            lblTotal.Text = ""
            lblCliente.Text = ""
            lblNombre.Text = ""
            btnAceptar.Enabled = False

        Finally
            Cursor = Cursors.Default
            oPedido.Dispose()
            oCliente.Dispose()
        End Try

    End Sub

    Public Sub New(ByVal AñoPed As Short, _
                   ByVal Celula As Byte, _
                   ByVal Pedido As Integer)
        MyBase.New()
        InitializeComponent()

        _AñoPed = AñoPed
        _Celula = Celula
        _Pedido = Pedido

        Dim oPedido As cPedido = Nothing
        Dim oCliente As cCliente = Nothing

        Try
            Cursor = Cursors.WaitCursor
            oPedido = New SigaMetClasses.cPedido(_AñoPed, _Celula, _Pedido)
            oCliente = New cCliente(oPedido.Cliente)

            lblTotal.Text = oPedido.Total.ToString("N")
            lblCliente.Text = oPedido.Cliente.ToString
            lblNombre.Text = oCliente.Nombre

            If oPedido.Status = "CANCELADO" Then btnAceptar.Enabled = False

        Catch ex As Exception
            lblTotal.Text = ""
            lblCliente.Text = ""
            lblNombre.Text = ""
            btnAceptar.Enabled = False

        Finally
            Cursor = Cursors.Default
            oPedido.Dispose()
            oCliente.Dispose()
        End Try

    End Sub

    Private Sub CancelaPedido_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboMotivoCancelacion.CargaDatos(True)
    End Sub

    
    
End Class

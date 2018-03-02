Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.ControlChars

Public Class frmDiscount
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _Connection = Connection
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents txtLitros As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents txtImporteDescuento As System.Windows.Forms.TextBox
    Friend WithEvents txtImporteConDescuento As System.Windows.Forms.TextBox
    Friend WithEvents lblPedidoReferencia As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDiscount))
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.txtLitros = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.lblPedidoReferencia = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtImporteDescuento = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtImporteConDescuento = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtDocumento
        '
        Me.txtDocumento.BackColor = System.Drawing.Color.White
        Me.txtDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocumento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDocumento.Location = New System.Drawing.Point(164, 8)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.ReadOnly = True
        Me.txtDocumento.Size = New System.Drawing.Size(116, 21)
        Me.txtDocumento.TabIndex = 1
        Me.txtDocumento.TabStop = False
        Me.txtDocumento.Text = ""
        Me.txtDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLitros
        '
        Me.txtLitros.BackColor = System.Drawing.Color.White
        Me.txtLitros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLitros.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLitros.Location = New System.Drawing.Point(164, 32)
        Me.txtLitros.Name = "txtLitros"
        Me.txtLitros.ReadOnly = True
        Me.txtLitros.Size = New System.Drawing.Size(116, 21)
        Me.txtLitros.TabIndex = 3
        Me.txtLitros.TabStop = False
        Me.txtLitros.Text = ""
        Me.txtLitros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.White
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(164, 56)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(116, 21)
        Me.txtTotal.TabIndex = 4
        Me.txtTotal.TabStop = False
        Me.txtTotal.Text = ""
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescuento
        '
        Me.txtDescuento.BackColor = System.Drawing.Color.White
        Me.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescuento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescuento.Location = New System.Drawing.Point(164, 80)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.ReadOnly = True
        Me.txtDescuento.Size = New System.Drawing.Size(116, 21)
        Me.txtDescuento.TabIndex = 5
        Me.txtDescuento.TabStop = False
        Me.txtDescuento.Text = ""
        Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPedidoReferencia
        '
        Me.lblPedidoReferencia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidoReferencia.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblPedidoReferencia.Location = New System.Drawing.Point(16, 12)
        Me.lblPedidoReferencia.Name = "lblPedidoReferencia"
        Me.lblPedidoReferencia.Size = New System.Drawing.Size(264, 40)
        Me.lblPedidoReferencia.TabIndex = 4
        Me.lblPedidoReferencia.Text = "Documento:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label2.Location = New System.Drawing.Point(16, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Litros:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label3.Location = New System.Drawing.Point(16, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 14)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Total:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(16, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 14)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Descuento por litro:"
        '
        'txtImporteDescuento
        '
        Me.txtImporteDescuento.BackColor = System.Drawing.Color.White
        Me.txtImporteDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteDescuento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteDescuento.Location = New System.Drawing.Point(164, 104)
        Me.txtImporteDescuento.Name = "txtImporteDescuento"
        Me.txtImporteDescuento.ReadOnly = True
        Me.txtImporteDescuento.Size = New System.Drawing.Size(116, 21)
        Me.txtImporteDescuento.TabIndex = 0
        Me.txtImporteDescuento.TabStop = False
        Me.txtImporteDescuento.Text = ""
        Me.txtImporteDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DarkRed
        Me.Label5.Location = New System.Drawing.Point(16, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 14)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Importe descuento:"
        '
        'txtImporteConDescuento
        '
        Me.txtImporteConDescuento.BackColor = System.Drawing.Color.White
        Me.txtImporteConDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteConDescuento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteConDescuento.Location = New System.Drawing.Point(164, 128)
        Me.txtImporteConDescuento.Name = "txtImporteConDescuento"
        Me.txtImporteConDescuento.ReadOnly = True
        Me.txtImporteConDescuento.Size = New System.Drawing.Size(116, 21)
        Me.txtImporteConDescuento.TabIndex = 6
        Me.txtImporteConDescuento.TabStop = False
        Me.txtImporteConDescuento.Text = ""
        Me.txtImporteConDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(140, 14)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Total menos descuento:"
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(64, Byte), CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(48, 184)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(84, 23)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "    &Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.DarkRed
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(160, 184)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(84, 23)
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "    &Cancelar"
        '
        'frmDiscount
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(296, 226)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAceptar, Me.btnCancelar, Me.Label6, Me.txtImporteConDescuento, Me.Label5, Me.txtImporteDescuento, Me.Label4, Me.Label3, Me.Label2, Me.txtDescuento, Me.txtTotal, Me.txtLitros, Me.txtDocumento, Me.lblPedidoReferencia})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmDiscount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importe con descuento"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Declaraciones"

    Private _Connection As SqlConnection, _
            _PedidoReferencia, _
            _Documento As String, _
            _Cliente As Integer, _
            _Litros, _
            _Total, _
            _DescuentoLitro, _
            _ImporteDescuento, _
            _ImporteMenosDescuento, _
            _TotalMenosDescuento As Double, _
            _DescuentoValido As Boolean

#End Region

#Region "Propiedades"

    Public ReadOnly Property ImporteMenosDescuento() As Double
        Get
            Return _ImporteMenosDescuento
        End Get
    End Property

    Public ReadOnly Property DescuentoValido() As Boolean
        Get
            Return _DescuentoValido
        End Get
    End Property

#End Region

#Region "Constructores"

    'Para CyC
    Public Sub New(ByVal Cliente As Integer, ByVal PedidoReferencia As String, ByVal Connection As SqlConnection)
        InitializeComponent()
        _Cliente = Cliente
        _Connection = Connection
        _PedidoReferencia = PedidoReferencia

        carga()
    End Sub

    'Para liquidación
    Public Sub New(ByVal Cliente As Integer, ByVal Litros As Double, _
                   ByVal Total As Double, ByVal Connection As SqlConnection, _
                   ByVal Fecha As Date, _
                   Optional ByVal DescuentoVariable As Boolean = False)

        InitializeComponent()

        'Ocultar los controles de pedido, no se usan en esta instancia

        Dim control As Control
        For Each control In Me.Controls
            If TypeOf (control) Is TextBox Or TypeOf (control) Is Label Then
                control.Top += 20
            End If
        Next

        txtDocumento.Visible = False
        _Cliente = Cliente
        _Connection = Connection
        _Litros = Litros
        _Total = Total
        carga(_Litros, Fecha)
        If DescuentoVariable Then
            txtImporteDescuento.ReadOnly = Not (DescuentoVariable)
            txtImporteDescuento.TabStop = DescuentoVariable
            txtImporteDescuento.Enabled = DescuentoVariable
            AddHandler txtImporteDescuento.TextChanged, AddressOf CalcularImporteDescuento
            txtImporteDescuento.Focus()
        End If
        btnCancelar.Visible = False

        btnAceptar.Left = CInt(Me.Width / 2) - CInt(btnAceptar.Width / 2)

        lblPedidoReferencia.AutoSize = False
        lblPedidoReferencia.Width = Me.Width - (lblPedidoReferencia.Left * 2)
        lblPedidoReferencia.Height *= 2
        lblPedidoReferencia.Text = "El cliente no. " & Cliente.ToString & " cuenta con el siguiente " & _
                                   "descuento autorizado:"
        lblPedidoReferencia.Top -= 20

        Me.CancelButton = Nothing
        Me.Text = "Descuento autorizado"

    End Sub

    'Para liquidación
    Public Sub New(ByVal Cliente As Integer, ByVal FechaCorte As Date, _
                   ByVal Celula As Integer, ByVal AñoPed As Integer, _
                   ByVal Pedido As Integer, ByVal Connection As SqlConnection)

        InitializeComponent()

        'Ocultar los controles de pedido, no se usan en esta instancia

        txtDocumento.Visible = False
        txtLitros.Visible = False
        txtTotal.Visible = False
        txtDescuento.Visible = False
        txtImporteConDescuento.Visible = False

        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label6.Visible = False

        Me.Height = 160

        lblPedidoReferencia.Top = 30
        lblPedidoReferencia.Left = 16

        txtImporteDescuento.Top = 60
        txtImporteDescuento.Left = 164

        Label5.Text = "Importe bonificación"
        Label5.Top = 62
        Label5.Left = 16

        btnAceptar.Top = 95

        _Cliente = Cliente
        _Connection = Connection
        carga(_Cliente, FechaCorte, Celula, AñoPed, Pedido)
        btnCancelar.Visible = False

        btnAceptar.Left = CInt(Me.Width / 2) - CInt(btnAceptar.Width / 2)

        lblPedidoReferencia.AutoSize = False
        lblPedidoReferencia.Width = Me.Width - (lblPedidoReferencia.Left * 2)
        lblPedidoReferencia.Height *= 2
        lblPedidoReferencia.Text = "El cliente no. " & Cliente.ToString & " cuenta con la" & CrLf & _
                                   "siguiente bonificación:"
        lblPedidoReferencia.Top -= 20

        Me.CancelButton = Nothing
        Me.Text = "Ventas multinivel"

    End Sub

#End Region

#Region "Aceptar/Cancelar Featuring"

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = DialogResult.OK
    End Sub

#End Region

#Region "Eventos de forma"

    Private Sub frmDiscount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDocumento.Text = _PedidoReferencia
        txtLitros.Text = _Litros.ToString
        txtDescuento.Text = FormatCurrency(_DescuentoLitro.ToString)
        txtImporteDescuento.Text = FormatCurrency(_ImporteDescuento.ToString)
        txtTotal.Text = FormatCurrency(_Total.ToString)
        txtImporteConDescuento.Text = FormatCurrency(_ImporteMenosDescuento.ToString)
        btnAceptar.Select()
    End Sub

#End Region

#Region "Carga de datos y cálculos"

    Private Sub carga()
        Dim Descuento As Descuento = Nothing
        Try
            Descuento = New Descuento(_Cliente, _PedidoReferencia, _Connection)
            _PedidoReferencia = Descuento.PedidoReferencia
            _Litros = Descuento.Litros
            _DescuentoLitro = Descuento.DescuentoLt
            _ImporteDescuento = Descuento.ImporteDescuento
            _Total = Descuento.ImporteTotal
            _ImporteMenosDescuento = Descuento.ImporteMenosDescuento
            _DescuentoValido = Descuento.DescuentoValido
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error" & Chr(13) & ex.Message, _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Descuento.Dispose()
        End Try
    End Sub

    'Para liquidación
    Private Sub carga(ByVal litros As Double, ByVal Fecha As Date)
        Dim Descuento As Descuento = Nothing
        Try
            Descuento = New Descuento(_Cliente, _Connection, Fecha)
            _DescuentoLitro = Descuento.DescuentoLt
            If Descuento.ImporteDescuento > 0 Then
                _ImporteDescuento = Descuento.ImporteDescuento
            Else
                _ImporteDescuento = litros * _DescuentoLitro
            End If
            _ImporteMenosDescuento = _Total - _ImporteDescuento
            _DescuentoValido = Descuento.DescuentoValido
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error" & Chr(13) & ex.Message, _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Descuento.Dispose()
        End Try
    End Sub

    'Para liquidación
    Private Sub carga(ByVal Cliente As Integer, ByVal FechaCorte As Date, _
                      ByVal Celula As Integer, ByVal AñoPed As Integer, _
                      ByVal Pedido As Integer)
        Dim Descuento As Descuento = Nothing
        Try
            Descuento = New Descuento(Cliente, FechaCorte, Celula, AñoPed, Pedido, _Connection)
            _DescuentoLitro = Descuento.DescuentoLt
            If Descuento.ImporteDescuento > 0 Then
                _ImporteDescuento = Descuento.ImporteDescuento
            Else
                '_ImporteDescuento = litros * _DescuentoLitro
            End If
            _ImporteMenosDescuento = _Total - _ImporteDescuento
            _DescuentoValido = Descuento.DescuentoValido
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error" & Chr(13) & ex.Message, _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Descuento.Dispose()
        End Try
    End Sub

    Private Sub CalcularImporteDescuento(ByVal sender As Object, ByVal e As System.EventArgs)
        If IsNumeric(DirectCast(sender, TextBox).Text) Then
            _ImporteDescuento = CType(txtImporteDescuento.Text, Double)
            _ImporteMenosDescuento = _Total - _ImporteDescuento
            If _ImporteMenosDescuento <= 0 Then
                MessageBox.Show("Este descuento dejaría el saldo del pedido" & CrLf & _
                                "en cero ($0.00)", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                _ImporteMenosDescuento = 0
            End If
            txtImporteDescuento.Text = FormatCurrency(txtImporteDescuento.Text, 2)
            txtImporteConDescuento.Text = FormatCurrency(_ImporteMenosDescuento.ToString, 2)
        End If
    End Sub

#End Region

End Class

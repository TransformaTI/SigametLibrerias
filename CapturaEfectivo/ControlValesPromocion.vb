Public Class ControlValesPromocion
    Inherits System.Windows.Forms.UserControl
    Private _TotalVales As Decimal
    Public Event TotalActualizado()
    Public Event FlechaIzquierda()
    Public Event FlechaDerecha()
    Private Denominaciones(0, 1) As Double

    'Variable para parametrizar el valor de las cantidades capturadas en 
    Private _valor As Decimal = 50

    Public Property Valor() As Decimal
        Get
            Return _valor
        End Get
        Set(ByVal Value As Decimal)
            _valor = Value
            lblValor.Text = _valor.ToString("C")
        End Set
    End Property


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        AddHandler txt50.KeyDown, AddressOf ControlaFlechas
        AddHandler txt50.KeyPress, AddressOf ControlaEnter
        AddHandler txt50.Leave, AddressOf ControlaLeave

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents txt50 As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTotalVales As System.Windows.Forms.Label
    Friend WithEvents lblValor As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblValor = New System.Windows.Forms.Label()
        Me.txt50 = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtTotalVales = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblValor
        '
        Me.lblValor.Location = New System.Drawing.Point(20, 24)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(48, 13)
        Me.lblValor.TabIndex = 55
        Me.lblValor.Text = "50.00"
        Me.lblValor.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txt50
        '
        Me.txt50.Location = New System.Drawing.Point(84, 20)
        Me.txt50.Name = "txt50"
        Me.txt50.Size = New System.Drawing.Size(48, 20)
        Me.txt50.TabIndex = 54
        Me.txt50.Text = ""
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(4, 50)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(33, 13)
        Me.Label29.TabIndex = 75
        Me.Label29.Text = "Total:"
        '
        'txtTotalVales
        '
        Me.txtTotalVales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtTotalVales.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalVales.Location = New System.Drawing.Point(44, 44)
        Me.txtTotalVales.Name = "txtTotalVales"
        Me.txtTotalVales.Size = New System.Drawing.Size(88, 24)
        Me.txtTotalVales.TabIndex = 74
        Me.txtTotalVales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Vales promoción:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(68, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(7, 13)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = ":"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ControlValesPromocion
        '
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.Label1, Me.Label29, Me.txtTotalVales, Me.lblValor, Me.txt50})
        Me.Name = "ControlValesPromocion"
        Me.Size = New System.Drawing.Size(136, 68)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Propiedades"
    Public Property V50() As Short
        Get
            If txt50.Text <> "" And IsNumeric(txt50.Text) Then
                Return CType(txt50.Text, Short)
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Short)
            If Value = 0 Then
                txt50.Text = ""
            Else
                txt50.Text = Value.ToString
            End If
        End Set
    End Property

    Public ReadOnly Property TotalVales() As Decimal
        Get
            Return _TotalVales
        End Get
    End Property
#End Region

#Region "Funciones"
    Public Function CalculaTotalVales() As Decimal
        Dim decTotalVales As Decimal = 0
        decTotalVales += (V50 * _valor)

        _TotalVales = decTotalVales
        txtTotalVales.Text = decTotalVales.ToString("N")
        Return decTotalVales
    End Function

    Public Sub ComienzaCaptura()
        txt50.Focus()
    End Sub

    Public Sub BorraCaptura()
        txt50.Text = ""
        txt50.Focus()
    End Sub

    Private Sub ControlaFlechas(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Left Then RaiseEvent FlechaIzquierda()
        If e.KeyCode = Keys.Right Then RaiseEvent FlechaDerecha()
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            Select Case ActiveControl.Name
                Case Is = "txt50"
                    If e.KeyCode = Keys.Down Then SendKeys.Send("{TAB}")
                    Exit Select
            End Select
            CalculaTotalVales()
            RaiseEvent TotalActualizado()
        End If

    End Sub

    Private Sub ControlaEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{TAB}")
            CalculaTotalVales()
            RaiseEvent TotalActualizado()
        End If
    End Sub

    Private Sub ControlaLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        CalculaTotalVales()
        RaiseEvent TotalActualizado()
    End Sub

    Public Function CalculaDenominaciones() As Array
        Denominaciones(0, 0) = _valor : Denominaciones(0, 1) = V50
        Return Denominaciones
    End Function

#End Region

    Private Sub Vales_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        CalculaTotalVales()
        RaiseEvent TotalActualizado()
    End Sub

    'Indicar el valor 
    Private Sub ControlValesPromocion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblValor.Text = _valor.ToString("C")
    End Sub
End Class

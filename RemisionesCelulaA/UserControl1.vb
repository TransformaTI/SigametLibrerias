Public Class UserControl1
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkSeImprime As System.Windows.Forms.CheckBox
    Friend WithEvents txtCantidad As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents btnRow As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.chkSeImprime = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtCantidad = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.btnRow = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCliente
        '
        Me.txtCliente.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtCliente.BackColor = System.Drawing.Color.White
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCliente.Location = New System.Drawing.Point(19, 0)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(103, 21)
        Me.txtCliente.TabIndex = 2
        Me.txtCliente.TabStop = False
        Me.txtCliente.Text = "Cliente"
        Me.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.White
        Me.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombre.Location = New System.Drawing.Point(121, 0)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(248, 21)
        Me.txtNombre.TabIndex = 3
        Me.txtNombre.TabStop = False
        Me.txtNombre.Text = "Nombre"
        '
        'txtDireccion
        '
        Me.txtDireccion.BackColor = System.Drawing.Color.White
        Me.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDireccion.Location = New System.Drawing.Point(368, 0)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(448, 21)
        Me.txtDireccion.TabIndex = 4
        Me.txtDireccion.TabStop = False
        Me.txtDireccion.Text = "Direccion"
        '
        'chkSeImprime
        '
        Me.chkSeImprime.Location = New System.Drawing.Point(32, 2)
        Me.chkSeImprime.Name = "chkSeImprime"
        Me.chkSeImprime.Size = New System.Drawing.Size(16, 16)
        Me.chkSeImprime.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkSeImprime})
        Me.Panel1.Location = New System.Drawing.Point(878, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(80, 21)
        Me.Panel1.TabIndex = 1
        '
        'txtCantidad
        '
        Me.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidad.Location = New System.Drawing.Point(815, 0)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(64, 21)
        Me.txtCantidad.TabIndex = 0
        Me.txtCantidad.Text = "Cantidad"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnRow
        '
        Me.btnRow.Location = New System.Drawing.Point(0, 2)
        Me.btnRow.Name = "btnRow"
        Me.btnRow.Size = New System.Drawing.Size(20, 19)
        Me.btnRow.TabIndex = 7
        '
        'UserControl1
        '
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRow, Me.txtCantidad, Me.Panel1, Me.txtDireccion, Me.txtNombre, Me.txtCliente})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "UserControl1"
        Me.Size = New System.Drawing.Size(958, 21)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _cliente As Integer
    Private _nombre As String
    Private _direccion As String
    Private _cantidad As Integer
    Private _seImprime As Boolean
    Private _yaRegistrado As Boolean

    Private _selected As Boolean

    Public Event ContentChanged(ByVal sender As Object, ByVal e As EventArgs)
    Public Event RowSelected(ByVal sender As Object, ByVal e As EventArgs)
    'Public Shadows Event KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    Public Sub New(ByVal Cliente As Integer, ByVal Nombre As String, ByVal Direccion As String, ByVal Cantidad As Integer, _
        ByVal SeImprime As Boolean, ByVal YaRegistrado As Boolean)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        _cliente = Cliente
        _nombre = Nombre
        _direccion = Direccion
        _cantidad = Cantidad
        _seImprime = SeImprime
        _yaRegistrado = YaRegistrado

        txtCliente.Text = CType(_cliente, String) & " "
        txtNombre.Text = " " & CType(_nombre, String)
        txtDireccion.Text = " " & CType(_direccion, String)
        txtCantidad.Text = CType(_cantidad, String)
        chkSeImprime.Checked = CType(_seImprime, Boolean)

    End Sub

    Public ReadOnly Property Cliente() As Integer
        Get
            Return _cliente
        End Get
    End Property

    Public ReadOnly Property Nombre() As String
        Get
            Return _nombre
        End Get
    End Property

    Public ReadOnly Property Direccion() As String
        Get
            Return _direccion
        End Get
    End Property

    Public Property Cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal Value As Integer)
            _cantidad = Value
        End Set
    End Property

    Public Property SeImprime() As Boolean
        Get
            Return _seImprime
        End Get
        Set(ByVal Value As Boolean)
            _seImprime = Value
        End Set
    End Property

    Public ReadOnly Property YaRegistrado() As Boolean
        Get
            Return _yaRegistrado
        End Get
    End Property

    Public Property Selected() As Boolean
        Get
            Return _selected
        End Get
        Set(ByVal Value As Boolean)
            _selected = Value
            SelectedRow(_selected)
        End Set
    End Property

    Private Sub txtCantidad_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged
        _cantidad = CType(Val(txtCantidad.Text), Integer)
        RaiseEvent ContentChanged(Me, e)
    End Sub

    Private Sub chkSeImprime_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSeImprime.CheckedChanged
        _seImprime = chkSeImprime.Checked
        RaiseEvent ContentChanged(Me, e)
    End Sub

    Private Sub SelectedRow(ByVal IsSelected As Boolean)
        Dim bckColor As Color
        Dim fntcolor As Color
        If IsSelected Then
            fntcolor = Color.White
            bckColor = System.Drawing.SystemColors.Highlight
            btnRow.Text = "»"
        Else
            fntcolor = Color.Black
            bckColor = Color.White
            btnRow.Text = ""
        End If
        txtCliente.BackColor = bckColor
        txtCliente.ForeColor = fntcolor
        txtNombre.BackColor = bckColor
        txtNombre.ForeColor = fntcolor
        txtDireccion.BackColor = bckColor
        txtDireccion.ForeColor = fntcolor
    End Sub

    'Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown, _
    '    txtNombre.KeyDown, txtDireccion.KeyDown, txtCantidad.KeyDown, chkSeImprime.KeyDown
    '    Select Case e.KeyCode
    '        Case Keys.Up, Keys.Down
    '            RaiseEvent KeyDown(Me, e)
    '    End Select
    'End Sub

End Class


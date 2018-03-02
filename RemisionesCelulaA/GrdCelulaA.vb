Public Class GrdCelulaA
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(0, 22)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(959, 425)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cliente"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(122, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(248, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nombre"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(369, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(448, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Dirección"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(816, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 23)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Cantidad"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Gainsboro
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(879, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 23)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Se Imprime"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GrdCelulaA
        '
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.Label1, Me.Panel1})
        Me.Name = "GrdCelulaA"
        Me.Size = New System.Drawing.Size(961, 447)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private dtSource As DataTable
    Private _Cliente As Integer

    Public ReadOnly Property Cliente() As Integer
        Get
            Return _Cliente
        End Get
    End Property

    Public Overrides Property AutoScroll() As Boolean
        Get
            Return Panel1.AutoScroll
        End Get
        Set(ByVal Value As Boolean)
            Panel1.AutoScroll = Value
        End Set
    End Property

    Public Event grdRowSelectChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event AutoResize(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event AutoResize1(ByVal sender As Object, ByVal e As System.EventArgs)

    Public Sub CargaDatos(ByRef Source As DataTable)
        Me.Panel1.Controls.Clear()
        dtSource = Source
        Dim left As Integer
        Dim top As Integer
        Dim i As Integer
        Dim dr As DataRow
        For Each dr In dtSource.Rows
            Dim fila As New UserControl1(CInt(dr.Item("Cliente")), CStr(dr.Item("Nombre")), CStr(dr.Item("Direccion")), CInt(dr.Item("Cantidad")), _
                                                                    CType(dr.Item("SeImprime"), Boolean), CType(dr.Item("YaRegistrado"), Boolean))
            fila.Name = "Fila" & i.ToString
            fila.Left = left
            fila.Top = top - 1

            AddHandler fila.ContentChanged, AddressOf RowLeave
            AddHandler fila.Enter, AddressOf rowEnter
            AddHandler fila.Leave, AddressOf RowLeave
            'AddHandler fila.KeyDown, AddressOf KeyPressed

            Panel1.Controls.Add(fila)
            top += fila.Height - 1
        Next
        If top > Panel1.Height Then
            Dim e As System.EventArgs
            RaiseEvent AutoResize(Me, e)
        Else
            Dim e As System.EventArgs
            RaiseEvent AutoResize1(Me, e)
        End If
    End Sub

    Private Sub RowLeave(ByVal sender As Object, ByVal e As System.EventArgs)
        dtSource.Rows.Find(DirectCast(sender, UserControl1).Cliente).BeginEdit()
        dtSource.Rows.Find(DirectCast(sender, UserControl1).Cliente).Item("Cantidad") = DirectCast(sender, UserControl1).Cantidad
        dtSource.Rows.Find(DirectCast(sender, UserControl1).Cliente).Item("SeImprime") = DirectCast(sender, UserControl1).SeImprime
        dtSource.Rows.Find(DirectCast(sender, UserControl1).Cliente).EndEdit()
        dtSource.AcceptChanges()

        DirectCast(sender, UserControl1).Selected = False
    End Sub

    Private Sub rowEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        DirectCast(sender, UserControl1).Selected = True
        _Cliente = DirectCast(sender, UserControl1).Cliente
        RaiseEvent grdRowSelectChanged(Me, e)
    End Sub

    Private Sub KeyPressed(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Up
                If TypeOf DirectCast(sender, Control) Is UserControl1 Then
                    DirectCast(sender, Control).SelectNextControl(DirectCast(sender, Control), True, True, False, True)
                End If
            Case Keys.Down
                If TypeOf DirectCast(sender, Control) Is UserControl1 Then
                    'DirectCast(sender, Control).SelectNextControl(DirectCast(sender, Control), False, True, False, True)
                    Me.Controls.Item(Me.Controls.IndexOf(DirectCast(sender, Control)) + 1).Focus()
                End If
        End Select
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class

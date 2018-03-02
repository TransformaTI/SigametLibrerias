Option Strict On

Imports System.Windows.Forms
Public Class IndiceAgenda
    Inherits System.Windows.Forms.UserControl

    Private _Rango As String
    Public Event CambioIndiceAlfabetico(ByVal Letra As String)

    Public ReadOnly Property Rango() As String
        Get
            Return _Rango
        End Get
    End Property

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim btnAlfabeto As Windows.Forms.Button
        For Each btnAlfabeto In Me.Controls
            AddHandler btnAlfabeto.Click, AddressOf Me.AlfabetoClick
        Next

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button18 As System.Windows.Forms.Button
    Friend WithEvents Button19 As System.Windows.Forms.Button
    Friend WithEvents Button20 As System.Windows.Forms.Button
    Friend WithEvents Button21 As System.Windows.Forms.Button
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents Button23 As System.Windows.Forms.Button
    Friend WithEvents Button24 As System.Windows.Forms.Button
    Friend WithEvents Button25 As System.Windows.Forms.Button
    Friend WithEvents Button26 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.Button20 = New System.Windows.Forms.Button()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.Button25 = New System.Windows.Forms.Button()
        Me.Button26 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(16, 24)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "A"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(16, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(16, 24)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "B"
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(32, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(16, 24)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "C"
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(48, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(16, 24)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "D"
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(64, 0)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(16, 24)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "E"
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(80, 0)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(16, 24)
        Me.Button6.TabIndex = 5
        Me.Button6.Text = "F"
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(96, 0)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(16, 24)
        Me.Button7.TabIndex = 6
        Me.Button7.Text = "G"
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(112, 0)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(16, 24)
        Me.Button8.TabIndex = 7
        Me.Button8.Text = "H"
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(128, 0)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(16, 24)
        Me.Button9.TabIndex = 8
        Me.Button9.Text = "I"
        '
        'Button10
        '
        Me.Button10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Location = New System.Drawing.Point(144, 0)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(16, 24)
        Me.Button10.TabIndex = 9
        Me.Button10.Text = "J"
        '
        'Button11
        '
        Me.Button11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.Location = New System.Drawing.Point(160, 0)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(16, 24)
        Me.Button11.TabIndex = 10
        Me.Button11.Text = "K"
        '
        'Button12
        '
        Me.Button12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.Location = New System.Drawing.Point(192, 0)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(16, 24)
        Me.Button12.TabIndex = 12
        Me.Button12.Text = "M"
        '
        'Button13
        '
        Me.Button13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button13.Location = New System.Drawing.Point(176, 0)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(16, 24)
        Me.Button13.TabIndex = 11
        Me.Button13.Text = "L"
        '
        'Button15
        '
        Me.Button15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button15.Location = New System.Drawing.Point(240, 0)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(16, 24)
        Me.Button15.TabIndex = 15
        Me.Button15.Text = "P"
        '
        'Button16
        '
        Me.Button16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button16.Location = New System.Drawing.Point(224, 0)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(16, 24)
        Me.Button16.TabIndex = 14
        Me.Button16.Text = "O"
        '
        'Button17
        '
        Me.Button17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button17.Location = New System.Drawing.Point(208, 0)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(16, 24)
        Me.Button17.TabIndex = 13
        Me.Button17.Text = "N"
        '
        'Button14
        '
        Me.Button14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.Location = New System.Drawing.Point(256, 0)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(16, 24)
        Me.Button14.TabIndex = 16
        Me.Button14.Text = "Q"
        '
        'Button18
        '
        Me.Button18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button18.Location = New System.Drawing.Point(272, 0)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(16, 24)
        Me.Button18.TabIndex = 17
        Me.Button18.Text = "R"
        '
        'Button19
        '
        Me.Button19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button19.Location = New System.Drawing.Point(288, 0)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(16, 24)
        Me.Button19.TabIndex = 18
        Me.Button19.Text = "S"
        '
        'Button20
        '
        Me.Button20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button20.Location = New System.Drawing.Point(304, 0)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(16, 24)
        Me.Button20.TabIndex = 19
        Me.Button20.Text = "T"
        '
        'Button21
        '
        Me.Button21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button21.Location = New System.Drawing.Point(320, 0)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(16, 24)
        Me.Button21.TabIndex = 20
        Me.Button21.Text = "U"
        '
        'Button22
        '
        Me.Button22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button22.Location = New System.Drawing.Point(336, 0)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(16, 24)
        Me.Button22.TabIndex = 21
        Me.Button22.Text = "V"
        '
        'Button23
        '
        Me.Button23.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button23.Location = New System.Drawing.Point(352, 0)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(16, 24)
        Me.Button23.TabIndex = 22
        Me.Button23.Text = "W"
        '
        'Button24
        '
        Me.Button24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button24.Location = New System.Drawing.Point(368, 0)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(16, 24)
        Me.Button24.TabIndex = 23
        Me.Button24.Text = "X"
        '
        'Button25
        '
        Me.Button25.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button25.Location = New System.Drawing.Point(384, 0)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New System.Drawing.Size(16, 24)
        Me.Button25.TabIndex = 24
        Me.Button25.Text = "Y"
        '
        'Button26
        '
        Me.Button26.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button26.Location = New System.Drawing.Point(400, 0)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(16, 24)
        Me.Button26.TabIndex = 25
        Me.Button26.Text = "Z"
        '
        'IndiceAgenda
        '
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button26, Me.Button25, Me.Button24, Me.Button23, Me.Button22, Me.Button21, Me.Button20, Me.Button19, Me.Button18, Me.Button14, Me.Button15, Me.Button16, Me.Button17, Me.Button12, Me.Button13, Me.Button11, Me.Button10, Me.Button9, Me.Button8, Me.Button7, Me.Button6, Me.Button5, Me.Button4, Me.Button3, Me.Button2, Me.Button1})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "IndiceAgenda"
        Me.Size = New System.Drawing.Size(416, 24)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub AlfabetoClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        _Rango = CType(sender, Button).Text

        RaiseEvent CambioIndiceAlfabetico(_Rango)
    End Sub

End Class

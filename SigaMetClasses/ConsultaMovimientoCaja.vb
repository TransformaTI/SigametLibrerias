Public Class ConsultaMovimientoCaja
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ConsultaMovimientoCaja))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(128, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(576, 16)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Clave:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Location = New System.Drawing.Point(128, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 21)
        Me.Label3.TabIndex = 3
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Location = New System.Drawing.Point(128, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 21)
        Me.Label4.TabIndex = 4
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Location = New System.Drawing.Point(128, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(520, 21)
        Me.Label5.TabIndex = 5
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 14)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "F.Operación:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 14)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "F.Movimiento:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 14)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Tipo de movimiento:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 139)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 14)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Capturó:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Location = New System.Drawing.Point(128, 136)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(520, 21)
        Me.Label10.TabIndex = 10
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 163)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 14)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Validó:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Location = New System.Drawing.Point(128, 160)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(136, 21)
        Me.Label12.TabIndex = 12
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Location = New System.Drawing.Point(128, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(136, 21)
        Me.Label13.TabIndex = 13
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 43)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 14)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Estatus:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(16, 187)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 14)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "F.Alta:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Location = New System.Drawing.Point(128, 184)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(136, 21)
        Me.Label16.TabIndex = 15
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(360, 187)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(82, 14)
        Me.Label17.TabIndex = 18
        Me.Label17.Text = "F.Actualización:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.Location = New System.Drawing.Point(448, 184)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(200, 21)
        Me.Label18.TabIndex = 17
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(272, 67)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(30, 14)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "Caja:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Location = New System.Drawing.Point(312, 64)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 21)
        Me.Label20.TabIndex = 19
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.Location = New System.Drawing.Point(464, 64)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(72, 21)
        Me.Label21.TabIndex = 21
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(392, 67)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 14)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "Consecutivo:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.Location = New System.Drawing.Point(576, 64)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(72, 21)
        Me.Label23.TabIndex = 23
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(544, 67)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(32, 14)
        Me.Label24.TabIndex = 24
        Me.Label24.Text = "Folio:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(16, 211)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(33, 14)
        Me.Label25.TabIndex = 26
        Me.Label25.Text = "Total:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label26.Location = New System.Drawing.Point(128, 208)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(136, 21)
        Me.Label26.TabIndex = 25
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(16, 235)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(96, 14)
        Me.Label27.TabIndex = 28
        Me.Label27.Text = "CobroPedidoTotal:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label28.Location = New System.Drawing.Point(128, 232)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(136, 21)
        Me.Label28.TabIndex = 27
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ConsultaMovimientoCaja
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(658, 279)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label27, Me.Label28, Me.Label25, Me.Label26, Me.Label24, Me.Label23, Me.Label22, Me.Label21, Me.Label19, Me.Label20, Me.Label17, Me.Label18, Me.Label15, Me.Label16, Me.Label14, Me.Label13, Me.Label12, Me.Label11, Me.Label10, Me.Label9, Me.Label8, Me.Label7, Me.Label6, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.btnCerrar, Me.Label1})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ConsultaMovimientoCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de movimiento"
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class

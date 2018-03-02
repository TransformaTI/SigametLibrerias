Public Class AcercaDe
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
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents lblSistema As System.Windows.Forms.Label
    Public WithEvents lblDescripcion As System.Windows.Forms.Label
    Public WithEvents lblVersion As System.Windows.Forms.Label
    Public WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AcercaDe))
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblSistema = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.SuspendLayout()
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(16, 96)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(61, 14)
        Me.lblDescripcion.TabIndex = 9
        Me.lblDescripcion.Text = "Descripción"
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnAceptar.Location = New System.Drawing.Point(224, 88)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 8
        Me.btnAceptar.Text = "Aceptar"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.Navy
        Me.lblVersion.Location = New System.Drawing.Point(16, 72)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(84, 14)
        Me.lblVersion.TabIndex = 7
        Me.lblVersion.Text = "Versión: 1.0.1.0"
        '
        'lblSistema
        '
        Me.lblSistema.AutoSize = True
        Me.lblSistema.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSistema.Location = New System.Drawing.Point(24, 16)
        Me.lblSistema.Name = "lblSistema"
        Me.lblSistema.Size = New System.Drawing.Size(63, 15)
        Me.lblSistema.TabIndex = 6
        Me.lblSistema.Text = "SigaMET"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto.Location = New System.Drawing.Point(16, 40)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(134, 30)
        Me.lblProducto.TabIndex = 5
        Me.lblProducto.Text = "Producto"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Bitmap)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(72, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'AcercaDe
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(306, 119)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAceptar, Me.lblDescripcion, Me.lblVersion, Me.lblProducto, Me.PictureBox1, Me.lblSistema})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "AcercaDe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acerca de..."
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal Producto As String, _
                   ByVal Version As String, _
                   ByVal Descripcion As String)
        MyBase.New()
        InitializeComponent()

        lblProducto.Text = Producto
        lblVersion.Text = "Versión: " & Version
        lblDescripcion.Text = Descripcion

    End Sub


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub

    Private Sub AcercaDe_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblSistema.Text = "SigaMET" & Chr(178)
    End Sub
End Class
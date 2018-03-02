Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Public Class frmFoto
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Imagen As Image)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.picFoto.Image = Imagen
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
    Friend WithEvents picFoto As System.Windows.Forms.PictureBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents grpLeft As System.Windows.Forms.GroupBox
    Friend WithEvents grpImagen As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.grpLeft = New System.Windows.Forms.GroupBox()
        Me.grpImagen = New System.Windows.Forms.GroupBox()
        Me.grpLeft.SuspendLayout()
        Me.grpImagen.SuspendLayout()
        Me.SuspendLayout()
        '
        'picFoto
        '
        Me.picFoto.Location = New System.Drawing.Point(6, 13)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(352, 224)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picFoto.TabIndex = 0
        Me.picFoto.TabStop = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(6, 24)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "Guardar"
        '
        'grpLeft
        '
        Me.grpLeft.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnGuardar})
        Me.grpLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpLeft.Name = "grpLeft"
        Me.grpLeft.Size = New System.Drawing.Size(88, 342)
        Me.grpLeft.TabIndex = 2
        Me.grpLeft.TabStop = False
        '
        'grpImagen
        '
        Me.grpImagen.Controls.AddRange(New System.Windows.Forms.Control() {Me.picFoto})
        Me.grpImagen.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpImagen.Location = New System.Drawing.Point(88, 0)
        Me.grpImagen.Name = "grpImagen"
        Me.grpImagen.Size = New System.Drawing.Size(368, 342)
        Me.grpImagen.TabIndex = 3
        Me.grpImagen.TabStop = False
        '
        'frmFoto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(464, 342)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpImagen, Me.grpLeft})
        Me.MinimizeBox = False
        Me.Name = "frmFoto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Mostrar Imagen"
        Me.grpLeft.ResumeLayout(False)
        Me.grpImagen.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmFoto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Height = Me.picFoto.Height + 40
        'Me.Width = Me.picFoto.Width + 12
        Me.picFoto.Left = 0
        Me.picFoto.Top = 0
        Me.Height = Me.picFoto.Height + 51
        Me.Width = Me.grpLeft.Width + Me.picFoto.Width + 19
        Me.grpImagen.Height = Me.picFoto.Height + 6
        Me.grpImagen.Width = Me.picFoto.Width + 6
        
        Me.picFoto.SizeMode = Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.grpImagen.Anchor = Windows.Forms.AnchorStyles.Top + Windows.Forms.AnchorStyles.Left + Windows.Forms.AnchorStyles.Right + Windows.Forms.AnchorStyles.Bottom
        Me.picFoto.Dock = DockStyle.Fill
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim Guardar As New SaveFileDialog()
        Guardar.DefaultExt = ".jpg"
        Guardar.Filter = "Archivos de Imagen (*.jpg)|*.jpg|All files (*.*)|*.*"
        Guardar.FileName = "LecturaMedidor"
        If (Guardar.ShowDialog(Me) = DialogResult.OK) Then
            Me.picFoto.Image.Save(Guardar.FileName)
        End If
    End Sub
End Class

Public Class frmProcesando
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
    Friend WithEvents picProceso As System.Windows.Forms.PictureBox
    Friend WithEvents txtMensaje As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmProcesando))
        Me.picProceso = New System.Windows.Forms.PictureBox()
        Me.txtMensaje = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'picProceso
        '
        Me.picProceso.Image = CType(resources.GetObject("picProceso.Image"), System.Drawing.Bitmap)
        Me.picProceso.Location = New System.Drawing.Point(13, 5)
        Me.picProceso.Name = "picProceso"
        Me.picProceso.Size = New System.Drawing.Size(64, 88)
        Me.picProceso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picProceso.TabIndex = 0
        Me.picProceso.TabStop = False
        '
        'txtMensaje
        '
        Me.txtMensaje.AutoSize = False
        Me.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMensaje.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtMensaje.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMensaje.ForeColor = System.Drawing.Color.Navy
        Me.txtMensaje.Location = New System.Drawing.Point(90, 0)
        Me.txtMensaje.Multiline = True
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(216, 98)
        Me.txtMensaje.TabIndex = 1
        Me.txtMensaje.Text = "Espere." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Procesando informacion..." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "Esta operacion puede durar algunos minuto" & _
        "s dependiendo de la cantidad de informacion a procesar"
        '
        'frmProcesando
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(306, 98)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtMensaje, Me.picProceso})
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmProcesando"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Procesando"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class

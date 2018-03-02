Public Class frmReporteCatalogoProgramacionRuta
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "


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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents cboRuta As SigaMetClasses.Combos.ComboRuta2
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmReporteCatalogoProgramacionRuta))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.cboRuta = New SigaMetClasses.Combos.ComboRuta2()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(172, 80)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 22
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(84, 80)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 21
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboRuta
        '
        Me.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRuta.Location = New System.Drawing.Point(125, 32)
        Me.cboRuta.Name = "cboRuta"
        Me.cboRuta.Size = New System.Drawing.Size(120, 21)
        Me.cboRuta.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(85, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 14)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Ruta:"
        '
        'frmReporteCatalogoProgramacionRuta
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(330, 130)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.btnCancelar, Me.btnAceptar, Me.cboRuta})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmReporteCatalogoProgramacionRuta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo de programaciones"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal Celula As Byte)
        MyBase.New()
        InitializeComponent()

    End Sub

    Private Sub frmReporteCatalogoProgramacionRuta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cboRuta.CargaDatos(Main.ReporteRemoto_Celula)
        If cboRuta.Items.Count > 0 Then
            cboRuta.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Cursor = Cursors.WaitCursor
        Dim oConsultaReporte As New frmReporteRemoto(0, CType(Me.cboRuta.SelectedValue, Short), Now.Date, Now.Date, 0, "", frmReporteRemoto.enumTipoReporte.ReporteCatalogoProgramacionRuta)
        oConsultaReporte.ShowDialog()
        Cursor = Cursors.Default

    End Sub
End Class

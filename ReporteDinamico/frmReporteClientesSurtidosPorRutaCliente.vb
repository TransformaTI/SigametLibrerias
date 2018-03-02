Public Class frmReporteClientesSurtidosPorRutaCliente
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboCelula As SigaMetClasses.Combos.ComboCelula
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents cboRuta As SigaMetClasses.Combos.ComboRuta2
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmReporteClientesSurtidosPorRutaCliente))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFecha2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpFecha1 = New System.Windows.Forms.DateTimePicker()
        Me.cboCelula = New SigaMetClasses.Combos.ComboCelula()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.cboRuta = New SigaMetClasses.Combos.ComboRuta2()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 14)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Célula:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 14)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Hasta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 14)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Desde:"
        '
        'dtpFecha2
        '
        Me.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFecha2.Location = New System.Drawing.Point(72, 40)
        Me.dtpFecha2.Name = "dtpFecha2"
        Me.dtpFecha2.Size = New System.Drawing.Size(120, 21)
        Me.dtpFecha2.TabIndex = 32
        '
        'dtpFecha1
        '
        Me.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFecha1.Location = New System.Drawing.Point(72, 16)
        Me.dtpFecha1.Name = "dtpFecha1"
        Me.dtpFecha1.Size = New System.Drawing.Size(120, 21)
        Me.dtpFecha1.TabIndex = 31
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.ForeColor = System.Drawing.Color.MediumBlue
        Me.cboCelula.Location = New System.Drawing.Point(72, 64)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(120, 21)
        Me.cboCelula.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 14)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Ruta:"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(224, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 36
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(224, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 35
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboRuta
        '
        Me.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRuta.Location = New System.Drawing.Point(72, 88)
        Me.cboRuta.Name = "cboRuta"
        Me.cboRuta.Size = New System.Drawing.Size(120, 21)
        Me.cboRuta.TabIndex = 34
        '
        'frmReporteClientesSurtidosPorRutaCliente
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(312, 130)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.Label3, Me.Label2, Me.dtpFecha2, Me.dtpFecha1, Me.cboCelula, Me.Label1, Me.btnCancelar, Me.btnAceptar, Me.cboRuta})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmReporteClientesSurtidosPorRutaCliente"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes Surtidos por Ruta"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Cursor = Cursors.WaitCursor
        Dim oConsultaReporte As New frmReporteRemoto(Main.ReporteRemoto_Celula, CType(Me.cboRuta.SelectedValue, Short), dtpFecha1.Value.Date, dtpFecha2.Value.Date, 0, "", frmReporteRemoto.enumTipoReporte.ReporteClientesSurtidosPorRutaCliente)
        oConsultaReporte.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub frmReporteClientesSurtidosPorRutaCliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpFecha1.Value = SigaMetClasses.FechaServidor.Date
        Me.dtpFecha2.Value = SigaMetClasses.FechaServidor.Date
        Me.cboCelula.CargaDatos(Main.ReporteRemoto_Celula)
        If cboCelula.Items.Count > 0 Then
            cboCelula.SelectedIndex = 0
        End If
        Me.cboRuta.CargaDatos(Main.ReporteRemoto_Celula)
    End Sub
End Class

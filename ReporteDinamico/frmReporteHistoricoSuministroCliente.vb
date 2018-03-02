Public Class frmReporteHistoricoSuministroCliente
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtCliente As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmReporteHistoricoSuministroCliente))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFecha2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpFecha1 = New System.Windows.Forms.DateTimePicker()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 14)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Hasta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 14)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Desde:"
        '
        'dtpFecha2
        '
        Me.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFecha2.Location = New System.Drawing.Point(80, 40)
        Me.dtpFecha2.Name = "dtpFecha2"
        Me.dtpFecha2.Size = New System.Drawing.Size(120, 21)
        Me.dtpFecha2.TabIndex = 32
        '
        'dtpFecha1
        '
        Me.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFecha1.Location = New System.Drawing.Point(80, 16)
        Me.dtpFecha1.Name = "dtpFecha1"
        Me.dtpFecha1.Size = New System.Drawing.Size(120, 21)
        Me.dtpFecha1.TabIndex = 31
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(232, 48)
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
        Me.btnAceptar.Location = New System.Drawing.Point(232, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 35
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(80, 64)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(120, 21)
        Me.txtCliente.TabIndex = 40
        Me.txtCliente.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 14)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Cliente:"
        '
        'frmReporteHistoricoSuministroCliente
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(314, 114)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.txtCliente, Me.Label3, Me.Label2, Me.dtpFecha2, Me.dtpFecha1, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmReporteHistoricoSuministroCliente"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Histórico de Suministros Por Cliente"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim oCliente As SigaMetClasses.cCliente
        If txtCliente.Text.Trim = "" Then
            MessageBox.Show("Debe teclear el número de cliente.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCliente.Focus()
            Exit Sub
        End If

        Try
            oCliente = New SigaMetClasses.cCliente(CType(txtCliente.Text, Integer))
            If oCliente.Nombre.Trim = "" Then
                MessageBox.Show("El número de cliente es inválido.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCliente.Focus()
                Exit Sub
            End If
            If oCliente.Celula <> Main.ReporteRemoto_Celula Then
                MessageBox.Show("El cliente [" & txtCliente.Text.Trim & "] no pertenece a su célula.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCliente.Focus()
                Exit Sub
            End If
        Catch
            MessageBox.Show("El número de cliente es inválido.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCliente.Focus()
            Exit Sub
        End Try


        Cursor = Cursors.WaitCursor
        Dim oConsultaReporte As New frmReporteRemoto(0, 0, dtpFecha1.Value.Date, dtpFecha2.Value.Date, CType(txtCliente.Text, Integer), "", frmReporteRemoto.enumTipoReporte.HistoricoDeSuministrosPorCliente)
        oConsultaReporte.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub frmReporteHistoricoSuministroCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpFecha1.Value = SigaMetClasses.FechaServidor.Date
        Me.dtpFecha2.Value = SigaMetClasses.FechaServidor.Date
    End Sub
End Class

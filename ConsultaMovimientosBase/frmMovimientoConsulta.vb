Public Class frmMovimientoConsulta
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
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents btnCerrar As ControlesBase.BotonBase
    Friend WithEvents dtpFechaMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaMovimiento As ControlesBase.LabelBase
    Protected WithEvents grdMovimiento As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMovimientoConsulta))
        Me.grdMovimiento = New System.Windows.Forms.DataGrid()
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.btnCerrar = New ControlesBase.BotonBase()
        Me.dtpFechaMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaMovimiento = New ControlesBase.LabelBase()
        CType(Me.grdMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdMovimiento
        '
        Me.grdMovimiento.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdMovimiento.CaptionText = "Lista de movimientos"
        Me.grdMovimiento.DataMember = ""
        Me.grdMovimiento.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdMovimiento.Location = New System.Drawing.Point(0, 80)
        Me.grdMovimiento.Name = "grdMovimiento"
        Me.grdMovimiento.Size = New System.Drawing.Size(576, 253)
        Me.grdMovimiento.TabIndex = 0
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(472, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(472, 48)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(80, 24)
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFechaMovimiento
        '
        Me.dtpFechaMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFechaMovimiento.Location = New System.Drawing.Point(136, 40)
        Me.dtpFechaMovimiento.Name = "dtpFechaMovimiento"
        Me.dtpFechaMovimiento.Size = New System.Drawing.Size(176, 21)
        Me.dtpFechaMovimiento.TabIndex = 1
        '
        'lblFechaMovimiento
        '
        Me.lblFechaMovimiento.AutoSize = True
        Me.lblFechaMovimiento.Location = New System.Drawing.Point(16, 43)
        Me.lblFechaMovimiento.Name = "lblFechaMovimiento"
        Me.lblFechaMovimiento.Size = New System.Drawing.Size(118, 14)
        Me.lblFechaMovimiento.TabIndex = 6
        Me.lblFechaMovimiento.Text = "Fecha del movimiento:"
        '
        'frmMovimientoConsulta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(560, 333)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFechaMovimiento, Me.dtpFechaMovimiento, Me.btnCerrar, Me.btnAceptar, Me.grdMovimiento})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMovimientoConsulta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de movimientos"
        CType(Me.grdMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class
Imports System.Windows.Forms

Public Class frmTipoUnidadTomaInventarioFisico
    Inherits System.Windows.Forms.Form

    Private _Año, _Mes, _Folio As Integer
    Private _Corporativo, _Sucursal As Short, _stlPermisosActaCierre As SortedList
    Private _FInventario As DateTime


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal Año As Integer, ByVal Mes As Integer, ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal Folio As Integer, ByVal FInventario As DateTime, ByVal stlPermisosActaCierre As SortedList)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        _Año = Año
        _Mes = Mes
        _Corporativo = Corporativo
        _Sucursal = Sucursal
        _Folio = Folio
        _FInventario = FInventario
        _stlPermisosActaCierre = stlPermisosActaCierre
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
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents rdbtnServicio As System.Windows.Forms.RadioButton
    Friend WithEvents rdbtnNegocio As System.Windows.Forms.RadioButton
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTipoUnidadTomaInventarioFisico))
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.rdbtnServicio = New System.Windows.Forms.RadioButton()
        Me.rdbtnNegocio = New System.Windows.Forms.RadioButton()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.grpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(32, 72)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(0, 13)
        Me.Label25.TabIndex = 90
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(32, 48)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(0, 13)
        Me.Label24.TabIndex = 89
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(32, 24)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(0, 13)
        Me.Label23.TabIndex = 88
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.DateTimePicker1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(178, 150)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(291, 21)
        Me.DateTimePicker1.TabIndex = 14
        Me.DateTimePicker1.Value = New Date(2004, 7, 1, 20, 34, 7, 497)
        '
        'grpDatos
        '
        Me.grpDatos.Controls.Add(Me.rdbtnServicio)
        Me.grpDatos.Controls.Add(Me.rdbtnNegocio)
        Me.grpDatos.Location = New System.Drawing.Point(12, 12)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(241, 79)
        Me.grpDatos.TabIndex = 5
        Me.grpDatos.TabStop = False
        '
        'rdbtnServicio
        '
        Me.rdbtnServicio.AutoSize = True
        Me.rdbtnServicio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.rdbtnServicio.Location = New System.Drawing.Point(16, 42)
        Me.rdbtnServicio.Name = "rdbtnServicio"
        Me.rdbtnServicio.Size = New System.Drawing.Size(128, 17)
        Me.rdbtnServicio.TabIndex = 2
        Me.rdbtnServicio.TabStop = True
        Me.rdbtnServicio.Text = "Unidad de servicio"
        Me.rdbtnServicio.UseVisualStyleBackColor = True
        '
        'rdbtnNegocio
        '
        Me.rdbtnNegocio.AutoSize = True
        Me.rdbtnNegocio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.rdbtnNegocio.Location = New System.Drawing.Point(16, 19)
        Me.rdbtnNegocio.Name = "rdbtnNegocio"
        Me.rdbtnNegocio.Size = New System.Drawing.Size(128, 17)
        Me.rdbtnNegocio.TabIndex = 1
        Me.rdbtnNegocio.TabStop = True
        Me.rdbtnNegocio.Text = "Unidad de negocio"
        Me.rdbtnNegocio.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(282, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(282, 19)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmTipoUnidadTomaInventarioFisico
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(369, 103)
        Me.Controls.Add(Me.grpDatos)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmTipoUnidadTomaInventarioFisico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tipo de unidad por toma inventario físico "
        Me.grpDatos.ResumeLayout(False)
        Me.grpDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Manejo de Controles"
    'Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
    '   Try
    '       Hide()
    '    Dim ofrmTomaInventarioFisico As New frmTomaInventarioInventarioFisico(_Año, _Mes, _Corporativo, _Sucursal, _Folio, _FInventario, rdbtnNegocio.Checked, _stlPermisosActaCierre)

    '        ofrmTomaInventarioFisico.Text = " Toma inventario fisico - [" & IIf(rdbtnNegocio.Checked, "Unidad de Negocio", "Unidad de Servicio") & "]"
    '       ofrmTomaInventarioFisico.ShowDialog()

    '        Close()
    '   Catch ex As Exception
    '      MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    ' Finally
    '    Cursor = Cursors.Default
    'End Try
    'End Sub
#End Region

    Private Sub frmTipoUnidadTomaInventarioFisico_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

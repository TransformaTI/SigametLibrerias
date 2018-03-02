Public Class frmFHCierre
    Inherits System.Windows.Forms.Form

    Private Secuencia As Integer = 0

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cboSucursal As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboAño As System.Windows.Forms.ComboBox
    Friend WithEvents cboMes As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFFinal As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFHCierre))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpFFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpFInicial = New System.Windows.Forms.DateTimePicker()
        Me.cboMes = New System.Windows.Forms.ComboBox()
        Me.cboAño = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSucursal = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpFFinal, Me.dtpFInicial, Me.cboMes, Me.cboAño, Me.Label5, Me.Label4, Me.Label2, Me.Label1, Me.cboSucursal, Me.Label3})
        Me.GroupBox1.Location = New System.Drawing.Point(11, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(461, 179)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'dtpFFinal
        '
        Me.dtpFFinal.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFFinal.Location = New System.Drawing.Point(131, 136)
        Me.dtpFFinal.Name = "dtpFFinal"
        Me.dtpFFinal.Size = New System.Drawing.Size(216, 21)
        Me.dtpFFinal.TabIndex = 4
        '
        'dtpFInicial
        '
        Me.dtpFInicial.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFInicial.Location = New System.Drawing.Point(131, 108)
        Me.dtpFInicial.Name = "dtpFInicial"
        Me.dtpFInicial.Size = New System.Drawing.Size(216, 21)
        Me.dtpFInicial.TabIndex = 3
        '
        'cboMes
        '
        Me.cboMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cboMes.Location = New System.Drawing.Point(131, 80)
        Me.cboMes.Name = "cboMes"
        Me.cboMes.Size = New System.Drawing.Size(216, 21)
        Me.cboMes.TabIndex = 2
        '
        'cboAño
        '
        Me.cboAño.Location = New System.Drawing.Point(131, 52)
        Me.cboAño.Name = "cboAño"
        Me.cboAño.Size = New System.Drawing.Size(216, 21)
        Me.cboAño.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(16, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Fecha final:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(16, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Fecha inicial:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(16, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Año:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(16, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Mes:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSucursal
        '
        Me.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursal.Location = New System.Drawing.Point(131, 24)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(216, 21)
        Me.cboSucursal.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(16, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Sucursal:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(491, 21)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(491, 53)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmFHCierre
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(578, 208)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAceptar, Me.btnCancelar, Me.GroupBox1})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFHCierre"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fecha y hora de cierre de inventaríos"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub HabilitarAceptar()
        If cboSucursal.Text <> "" And cboMes.Text <> "" And cboAño.Text <> "" Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    Private Sub Registrar()
        If Secuencia = 0 Then
            Dim oRegistra As New PortatilClasses.Consulta.cCierreFechaHora(0)
            oRegistra.Registrar(CType(cboSucursal.Identificador, Short), Secuencia, CType(cboAño.Text, Short), CType(cboMes.SelectedIndex + 1, Short), dtpFInicial.Value, dtpFFinal.Value, GLOBAL_Usuario)
        Else
            Dim oRegistra As New PortatilClasses.Consulta.cCierreFechaHora(1)
            oRegistra.Registrar(CType(cboSucursal.Identificador, Short), Secuencia, CType(cboAño.Text, Short), CType(cboMes.SelectedIndex + 1, Short), dtpFInicial.Value, dtpFFinal.Value, GLOBAL_Usuario)
        End If
    End Sub

    Private Sub ConsultarFecha()
        Secuencia = 0
        Dim oCierre As New PortatilClasses.Catalogo.cConsultaCierreFechaHora(1, CType(cboSucursal.Identificador, Short), CType(cboAño.Text, Integer), CType(cboMes.SelectedIndex + 1, Integer))
        If oCierre.drReader.Read Then
            Secuencia = CType(oCierre.drReader(1), Integer)
            dtpFInicial.Value = CType(oCierre.drReader(4), DateTime)
            dtpFFinal.Value = CType(oCierre.drReader(5), DateTime)
            cboSucursal.Enabled = False
            cboMes.Enabled = False
            cboAño.Enabled = False
        Else
            cboSucursal.Enabled = True
            cboMes.Enabled = True
            cboAño.Enabled = True
        End If
    End Sub

    Private Sub frmFHCierre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnAceptar.Enabled = False
        cboMes.SelectedIndex = Now.Month - 1
        cboAño.Items.Insert(0, Now.Year - 1)
        cboAño.Items.Insert(0, Now.Year)
        cboAño.SelectedIndex = 0

        cboSucursal.CargaDatosBase("spPTLCargaComboSucursal", 2, GLOBAL_Usuario, 0, 0, 0)
        ActiveControl = cboSucursal
    End Sub

    Private Sub cboSucursal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles cboSucursal.KeyDown, cboAño.KeyDown, cboMes.KeyDown, dtpFFinal.KeyDown, dtpFInicial.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub cboSucursal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cboSucursal.SelectedIndexChanged, cboAño.SelectedIndexChanged, cboMes.SelectedIndexChanged
        If CType(sender, Control).Focused Then
            If cboSucursal.Text <> "" And cboAño.Text <> "" And cboMes.Text <> "" Then
                ConsultarFecha()
            End If
            HabilitarAceptar()
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, "Inventario manual", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Registrar()
            Close()
        End If
    End Sub

    Private Sub dtpFInicial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles dtpFInicial.TextChanged, dtpFFinal.TextChanged
        If dtpFFinal.Value <= dtpFInicial.Value Then
            Dim Mensajes As New PortatilClasses.Mensaje(129)
            MessageBox.Show(Mensajes.Mensaje, "Inventario manual", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            ActiveControl = CType(sender, Control)
        End If
    End Sub
End Class

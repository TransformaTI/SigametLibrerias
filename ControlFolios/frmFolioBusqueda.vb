' Filtro para realizar la búsqueda de folios, ya sean cancelados, asignados o devueltos
Public Class frmFolioBusqueda
    Inherits System.Windows.Forms.Form

    Public RealizarConsulta As Boolean
    Public FolioInicial As Integer
    Public FolioFinal As Integer
    Public TipoFolio As Integer

    Private Titulo As String

    Public Sub New(ByVal _Titulo As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        Titulo = _Titulo
    End Sub

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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTipoFolio As PortatilClasses.Combo.ComboTipoFolio
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFolioFinal As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtFolioInicial As SigaMetClasses.Controles.txtNumeroEntero
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFolioBusqueda))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboTipoFolio = New PortatilClasses.Combo.ComboTipoFolio()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFolioFinal = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFolioInicial = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(359, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 20
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(359, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 19
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboTipoFolio, Me.Label4, Me.Label2, Me.txtFolioFinal, Me.Label1, Me.txtFolioInicial})
        Me.GroupBox1.Location = New System.Drawing.Point(16, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 128)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        '
        'cboTipoFolio
        '
        Me.cboTipoFolio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoFolio.Location = New System.Drawing.Point(82, 88)
        Me.cboTipoFolio.Name = "cboTipoFolio"
        Me.cboTipoFolio.Size = New System.Drawing.Size(228, 21)
        Me.cboTipoFolio.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label4.Location = New System.Drawing.Point(18, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Tipo folio:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label2.Location = New System.Drawing.Point(18, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Folio final:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFolioFinal
        '
        Me.txtFolioFinal.AutoSize = False
        Me.txtFolioFinal.Location = New System.Drawing.Point(82, 60)
        Me.txtFolioFinal.Name = "txtFolioFinal"
        Me.txtFolioFinal.Size = New System.Drawing.Size(120, 21)
        Me.txtFolioFinal.TabIndex = 27
        Me.txtFolioFinal.Text = "txtFolioFinal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label1.Location = New System.Drawing.Point(18, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Folio inicial:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFolioInicial
        '
        Me.txtFolioInicial.AutoSize = False
        Me.txtFolioInicial.Location = New System.Drawing.Point(82, 32)
        Me.txtFolioInicial.Name = "txtFolioInicial"
        Me.txtFolioInicial.Size = New System.Drawing.Size(120, 21)
        Me.txtFolioInicial.TabIndex = 25
        Me.txtFolioInicial.Text = "TxtNumeroEntero1"
        '
        'frmFolioBusqueda
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(450, 152)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmFolioBusqueda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Búsqueda de folios"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Limpia los controles de la forma
    Private Sub Limpiar()
        txtFolioInicial.Clear()
        txtFolioFinal.Clear()
        RealizarConsulta = False
        btnAceptar.Enabled = False
        cboTipoFolio.PosicionarInicio()
        FolioInicial = -1
        FolioFinal = -1
        TipoFolio = -1
    End Sub

    ' Inicialización de la forma y de algunos controles
    Private Sub frmFolioBusqueda_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Limpiar()
        cboTipoFolio.CargaDatos(0)
        ActiveControl = txtFolioInicial
    End Sub

    ' Evento de los controles para pasar de un control a otro por medio del Enter 
    Private Sub txtFolio_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles txtFolioFinal.KeyDown, txtFolioInicial.KeyDown
        If e.KeyData = Keys.Enter Or (e.KeyData = Keys.Down) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            MyBase.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    ' Evento que cierra la forma
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles btnCancelar.Click
        Close()
    End Sub

    ' Evento que se activa al dar clic al botón de Aceptar, indica que se va arealizar la busqueda y guarda en una
    ' variable publica el numero de folio a consultar
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        RealizarConsulta = True
        If txtFolioInicial.Text <> "" And txtFolioFinal.Text <> "" Then
            FolioInicial = CType(txtFolioInicial.Text, Integer)
            FolioFinal = CType(txtFolioFinal.Text, Integer)
        End If
        If cboTipoFolio.Text <> "" Then
            TipoFolio = cboTipoFolio.Identificador
        End If
        Close()
    End Sub

    ' habilita el botón de Aceptar si el folio fue tecleado
    Private Sub txtFolio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFolioFinal.TextChanged, cboTipoFolio.SelectedIndexChanged, txtFolioInicial.TextChanged
        If (txtFolioInicial.Text <> "" And txtFolioFinal.Text <> "") Or (cboTipoFolio.Text <> "") Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    ' Evento de los controles para pasar de un control a otro por medio del Enter y con la tecla DELETE o SUPR podemos
    ' borrar los datos seleccionados
    Private Sub cboTipoFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTipoFolio.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Delete Then
            cboTipoFolio.PosicionarInicio()
        End If
    End Sub

    ' Valida si la información es correcta
    Private Sub txtFolioInicial_Leave(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtFolioInicial.Leave, txtFolioFinal.Leave
        If CType(sender, TextBox).Name = "txtFolioInicial" And txtFolioFinal.Text = "" Then
            txtFolioFinal.Text = txtFolioInicial.Text
        Else
            If CType(sender, TextBox).Name = "txtFolioFinal" And txtFolioInicial.Text = "" Then
                txtFolioInicial.Text = txtFolioFinal.Text
            End If
        End If
        If txtFolioInicial.Text <> "" And txtFolioFinal.Text <> "" Then
            If CType(txtFolioInicial.Text, Integer) > CType(txtFolioFinal.Text, Integer) Then
                CType(sender, TextBox).Clear()
                ActiveControl = CType(sender, Control)
                Dim Mensajes As New PortatilClasses.Mensaje(23)
                MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub frmFolioBusqueda_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If RealizarConsulta = False Then
            Dim Result As DialogResult
            Dim Mensajes As New PortatilClasses.Mensaje(28)
            Result = MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
End Class

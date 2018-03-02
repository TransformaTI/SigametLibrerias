Imports System.Windows.Forms
Imports System.Drawing

Public Class frmMedicionFisicaCopiar
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
    Friend WithEvents ielImagenes As System.Windows.Forms.ImageList
    Friend WithEvents btnBorrar As System.Windows.Forms.Button
    Friend WithEvents gpbDatosBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents grdMedicionFisica As System.Windows.Forms.DataGrid
    Friend WithEvents btnCopiar As System.Windows.Forms.Button
    Friend WithEvents cboCelula As PortatilClasses.Combo.ComboBase
    Friend WithEvents dtpFInicio As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMedicionFisicaCopiar))
        Me.grdMedicionFisica = New System.Windows.Forms.DataGrid()
        Me.btnCopiar = New System.Windows.Forms.Button()
        Me.ielImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.gpbDatosBusqueda = New System.Windows.Forms.GroupBox()
        Me.cboCelula = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFInicio = New System.Windows.Forms.DateTimePicker()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.grdMedicionFisica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbDatosBusqueda.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdMedicionFisica
        '
        Me.grdMedicionFisica.AccessibleName = ""
        Me.grdMedicionFisica.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdMedicionFisica.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdMedicionFisica.CaptionBackColor = System.Drawing.Color.MidnightBlue
        Me.grdMedicionFisica.CaptionText = "Inventario inicial físico"
        Me.grdMedicionFisica.DataMember = ""
        Me.grdMedicionFisica.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdMedicionFisica.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdMedicionFisica.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdMedicionFisica.Location = New System.Drawing.Point(6, 93)
        Me.grdMedicionFisica.Name = "grdMedicionFisica"
        Me.grdMedicionFisica.ReadOnly = True
        Me.grdMedicionFisica.Size = New System.Drawing.Size(514, 395)
        Me.grdMedicionFisica.TabIndex = 129
        Me.grdMedicionFisica.TabStop = False
        '
        'btnCopiar
        '
        Me.btnCopiar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopiar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCopiar.Image = CType(resources.GetObject("btnCopiar.Image"), System.Drawing.Bitmap)
        Me.btnCopiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCopiar.Location = New System.Drawing.Point(541, 43)
        Me.btnCopiar.Name = "btnCopiar"
        Me.btnCopiar.Size = New System.Drawing.Size(80, 24)
        Me.btnCopiar.TabIndex = 1
        Me.btnCopiar.Text = "&Copiar"
        Me.btnCopiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ielImagenes
        '
        Me.ielImagenes.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ielImagenes.ImageSize = New System.Drawing.Size(16, 16)
        Me.ielImagenes.ImageStream = CType(resources.GetObject("ielImagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ielImagenes.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnBorrar
        '
        Me.btnBorrar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = CType(resources.GetObject("btnBorrar.Image"), System.Drawing.Bitmap)
        Me.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrar.ImageIndex = 1
        Me.btnBorrar.ImageList = Me.ielImagenes
        Me.btnBorrar.Location = New System.Drawing.Point(659, 523)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(80, 24)
        Me.btnBorrar.TabIndex = 130
        Me.btnBorrar.Text = "&Borrar"
        Me.btnBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gpbDatosBusqueda
        '
        Me.gpbDatosBusqueda.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCelula, Me.Label8, Me.Label2, Me.dtpFInicio})
        Me.gpbDatosBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbDatosBusqueda.ForeColor = System.Drawing.Color.DarkBlue
        Me.gpbDatosBusqueda.Location = New System.Drawing.Point(5, 5)
        Me.gpbDatosBusqueda.Name = "gpbDatosBusqueda"
        Me.gpbDatosBusqueda.Size = New System.Drawing.Size(515, 81)
        Me.gpbDatosBusqueda.TabIndex = 132
        Me.gpbDatosBusqueda.TabStop = False
        '
        'cboCelula
        '
        Me.cboCelula.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(83, 48)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(216, 21)
        Me.cboCelula.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(14, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 135
        Me.Label8.Text = "Sucursal:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(14, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "Fecha inicial:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFInicio
        '
        Me.dtpFInicio.CustomFormat = "dd/MM/yyyy"
        Me.dtpFInicio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFInicio.Location = New System.Drawing.Point(83, 22)
        Me.dtpFInicio.Name = "dtpFInicio"
        Me.dtpFInicio.Size = New System.Drawing.Size(216, 21)
        Me.dtpFInicio.TabIndex = 1
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.ImageIndex = 5
        Me.btnBuscar.ImageList = Me.ielImagenes
        Me.btnBuscar.Location = New System.Drawing.Point(541, 11)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(80, 24)
        Me.btnBuscar.TabIndex = 0
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 2
        Me.btnCancelar.ImageList = Me.ielImagenes
        Me.btnCancelar.Location = New System.Drawing.Point(541, 75)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmMedicionFisicaCopiar
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(640, 486)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBorrar, Me.gpbDatosBusqueda, Me.btnCancelar, Me.grdMedicionFisica, Me.btnBuscar, Me.btnCopiar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMedicionFisicaCopiar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario inicial físico"
        CType(Me.grdMedicionFisica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbDatosBusqueda.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Funciones y procedimientos"

    Private Sub BuscarMediciones()

    End Sub

#End Region

    Private Sub frmMedicionFisicaCopiar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If GLOBAL_VerTodosAlmacenes Then
            cboCelula.CargaDatosBase("spPTLCargaComboCelula", 1, GLOBAL_Usuario, GLOBAL_Empresa, 0, 0)
        Else
            cboCelula.CargaDatosBase("spPTLCargaComboCelula", 2, GLOBAL_Usuario, GLOBAL_Empresa, 0, 0)
        End If
        cboCelula.PosicionaCombo(GLOBAL_Celula)
    End Sub

    Private Sub dtpFInicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles dtpFInicio.KeyDown, cboCelula.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub
End Class

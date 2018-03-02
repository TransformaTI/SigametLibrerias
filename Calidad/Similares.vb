Public Class frmSimilares
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
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    Friend WithEvents btnContinuar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents vgDatos As CallesColonias.ViewGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSimilares))
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.vgDatos = New CallesColonias.ViewGrid()
        Me.btnContinuar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblMensaje
        '
        Me.lblMensaje.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblMensaje.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblMensaje.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(410, 80)
        Me.lblMensaje.TabIndex = 0
        Me.lblMensaje.Text = "Existen calles / colonias similares en el municipio / colonia seleccionado. ¿Qúe " & _
        "desea hacer?"
        Me.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'vgDatos
        '
        Me.vgDatos.AlternativeBackColor = System.Drawing.Color.Gainsboro
        Me.vgDatos.DataSource = Nothing
        Me.vgDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.vgDatos.FormatColumnNames = New String(-1) {}
        Me.vgDatos.FullRowSelect = True
        Me.vgDatos.GridLines = True
        Me.vgDatos.HidedColumnNames = New String() {"Colonia", "Alias", "Fuente"}
        Me.vgDatos.HideSelection = False
        Me.vgDatos.Location = New System.Drawing.Point(0, 80)
        Me.vgDatos.MultiSelect = False
        Me.vgDatos.Name = "vgDatos"
        Me.vgDatos.PKColumnNames = Nothing
        Me.vgDatos.Size = New System.Drawing.Size(410, 392)
        Me.vgDatos.TabIndex = 1
        Me.vgDatos.View = System.Windows.Forms.View.Details
        '
        'btnContinuar
        '
        Me.btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnContinuar.Image = CType(resources.GetObject("btnContinuar.Image"), System.Drawing.Bitmap)
        Me.btnContinuar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnContinuar.Location = New System.Drawing.Point(100, 488)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.TabIndex = 3
        Me.btnContinuar.Text = "C&ontinuar"
        Me.btnContinuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(236, 488)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmSimilares
        '
        Me.AcceptButton = Me.btnContinuar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(410, 530)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnContinuar, Me.btnCancelar, Me.vgDatos, Me.lblMensaje})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSimilares"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constructores"
    'Para las colonias
    Public Sub New(ByVal Municipio As Integer, ByVal Colonia As Integer, ByVal Nombre As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim daCC As New SqlDataAdapter("spDEPColoniasSimilares", Globales.GetInstance.cnSigamet)
        Dim dtColonias As New DataTable()
        Me.Text = "Colonias similares"
        daCC.SelectCommand.CommandType = CommandType.StoredProcedure
        daCC.SelectCommand.Parameters.Add("@Municipio", SqlDbType.Int).Value = Municipio
        daCC.SelectCommand.Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia
        daCC.SelectCommand.Parameters.Add("@NombreColonia", SqlDbType.Char).Value = Nombre
        lblMensaje.Text = "Existen colonias con nombre similar a """ & Nombre.Trim & """ en el municipio seleccionado." & _
                            Chr(13) & "¿Qué desea hacer?"

        Try
            daCC.Fill(dtColonias)
            vgDatos.DataSource = dtColonias
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            AutoClose = dtColonias.Rows.Count = 0
        End Try

    End Sub
    'Para las calles
    Public Sub New(ByVal Calle As Integer, ByVal Nombre As String, ByVal Colonia As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim daCC As New SqlDataAdapter("spDEPCallesSimilares", Globales.GetInstance.cnSigamet)
        Dim dtColonias As New DataTable()
        Me.Text = "Calles similares"
        daCC.SelectCommand.CommandType = CommandType.StoredProcedure
        daCC.SelectCommand.Parameters.Add("@Calle", SqlDbType.Int).Value = Calle
        daCC.SelectCommand.Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia
        daCC.SelectCommand.Parameters.Add("@NombreCalle", SqlDbType.Char).Value = Nombre
        lblMensaje.Text = "Existen calles con nombre similar a """ & Nombre.Trim & """ en la colonia seleccionada." & _
                            Chr(13) & "¿Qué desea hacer?"
        Try
            daCC.Fill(dtColonias)
            vgDatos.DataSource = dtColonias
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            AutoClose = dtColonias.Rows.Count = 0
        End Try

    End Sub
#End Region
#Region "Variables globales"
    Private AutoClose As Boolean
#End Region
#Region "Propiedades"
    ReadOnly Property HaySimilares() As Boolean
        Get
            Return Not AutoClose
        End Get
    End Property
#End Region
#Region "Manejo de botones"
    Private Sub btnContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinuar.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
#End Region


End Class

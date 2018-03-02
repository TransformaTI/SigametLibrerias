Public Class frmCapturaColonia
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
    Friend WithEvents rgrpDatos As CallesColonias.RoundedGroupBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblAlias As System.Windows.Forms.Label
    Friend WithEvents lblCP As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtAlias As System.Windows.Forms.TextBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents scboCP As CallesColonias.SelfCompletitionComboBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCapturaColonia))
        Me.rgrpDatos = New CallesColonias.RoundedGroupBox()
        Me.scboCP = New CallesColonias.SelfCompletitionComboBox()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblAlias = New System.Windows.Forms.Label()
        Me.lblCP = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtAlias = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.Sienna
        Me.rgrpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.scboCP, Me.cboStatus, Me.txtNombre, Me.lblNombre, Me.lblAlias, Me.lblCP, Me.lblStatus, Me.txtAlias})
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpDatos.FlatStyle = CallesColonias.RoundedGroupBox.Style.Pipe
        Me.rgrpDatos.Location = New System.Drawing.Point(3, 3)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(373, 161)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'scboCP
        '
        Me.scboCP.CorrectOnWriting = True
        Me.scboCP.ForceCompleteOnLeave = True
        Me.scboCP.Location = New System.Drawing.Point(72, 93)
        Me.scboCP.Name = "scboCP"
        Me.scboCP.Size = New System.Drawing.Size(280, 21)
        Me.scboCP.TabIndex = 5
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Items.AddRange(New Object() {"MODIFICADO", "VERIFICADO", "NUEVA"})
        Me.cboStatus.Location = New System.Drawing.Point(72, 125)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(280, 21)
        Me.cboStatus.TabIndex = 11
        '
        'txtNombre
        '
        Me.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(72, 29)
        Me.txtNombre.MaxLength = 80
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(280, 21)
        Me.txtNombre.TabIndex = 1
        Me.txtNombre.Text = ""
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(16, 32)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(54, 14)
        Me.lblNombre.TabIndex = 0
        Me.lblNombre.Text = "&Nombre:"
        '
        'lblAlias
        '
        Me.lblAlias.AutoSize = True
        Me.lblAlias.Location = New System.Drawing.Point(16, 64)
        Me.lblAlias.Name = "lblAlias"
        Me.lblAlias.Size = New System.Drawing.Size(31, 14)
        Me.lblAlias.TabIndex = 2
        Me.lblAlias.Text = "A&lias:"
        '
        'lblCP
        '
        Me.lblCP.AutoSize = True
        Me.lblCP.Location = New System.Drawing.Point(16, 96)
        Me.lblCP.Name = "lblCP"
        Me.lblCP.Size = New System.Drawing.Size(21, 14)
        Me.lblCP.TabIndex = 4
        Me.lblCP.Text = "C&P:"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(16, 128)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 14)
        Me.lblStatus.TabIndex = 10
        Me.lblStatus.Text = "S&tatus:"
        '
        'txtAlias
        '
        Me.txtAlias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAlias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAlias.Location = New System.Drawing.Point(72, 61)
        Me.txtAlias.MaxLength = 80
        Me.txtAlias.Name = "txtAlias"
        Me.txtAlias.Size = New System.Drawing.Size(280, 21)
        Me.txtAlias.TabIndex = 3
        Me.txtAlias.Text = ""
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(384, 11)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(384, 43)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCapturaColonia
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(466, 167)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAceptar, Me.rgrpDatos, Me.btnCancelar})
        Me.DockPadding.All = 3
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapturaColonia"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.rgrpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constructores"
    'Nueva
    Public Sub New(ByVal Municipio As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = "Nueva colonia."
        Me.Municipio = Municipio
        CargaCP()
        cboStatus.Text = "NUEVA"
        cboStatus.Enabled = False
        Nuevo = True
    End Sub
    'Modificación
    Public Sub New(ByVal Municipio As Integer, ByVal Colonia As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = "Modificación de colonia."
        Me.Municipio = Municipio
        Me.Colonia = Colonia
        CargaCP()
        CargaColonia()
        cboStatus.Text = "MODIFICADO"
        cboStatus.Enabled = Globales.GetInstance.ModificarStatus
        Nuevo = False
    End Sub
#End Region

#Region "Variables globales"
    Private Municipio As Integer
    Private Colonia As Integer
    Private Nuevo As Boolean
#End Region
#Region "Carga de datos"
    Private Sub CargaCP()
        Dim cmdCC As New SqlCommand("Select ltrim(rtrim(CP)) as CP from CP", Globales.GetInstance.cnSigamet)
        Dim daCC As New SqlDataAdapter(cmdCC)
        Dim dtCP As New DataTable()
        Try
            daCC.Fill(dtCP)
            scboCP.DisplayMember = "CP"
            scboCP.ValueMember = "CP"
            scboCP.DataSource = dtCP
            scboCP.SelectedIndex = 0
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
    Private Sub CargaColonia()
        Dim cmdCC As New SqlCommand("Select CP, Municipio, Nombre, isnull(Alias,'') as Alias " & _
                                     " from Colonia where Colonia  = @Colonia", Globales.GetInstance.cnSigamet)
        Dim rdColonia As SqlDataReader
        cmdCC.Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia
        Try
            If Globales.GetInstance.cnSigamet.State <> ConnectionState.Open Then
                Globales.GetInstance.cnSigamet.Open()
            End If
            rdColonia = cmdCC.ExecuteReader
            If rdColonia.Read Then
                scboCP.SelectedValue = rdColonia("CP")
                Municipio = CInt(rdColonia("Municipio"))
                txtNombre.Text = CStr(rdColonia("Nombre"))
                txtAlias.Text = CStr(rdColonia("Alias"))
            End If
            rdColonia.Close()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            If Globales.GetInstance.cnSigamet.State <> ConnectionState.Closed Then
                Globales.GetInstance.cnSigamet.Close()
            End If
        End Try
    End Sub
#End Region
#Region "Manejo de cajas de texto"
    Private Sub TextBox_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAlias.Enter, txtNombre.Enter
        CType(sender, TextBox).BackColor = Color.LemonChiffon
        CType(sender, TextBox).SelectAll()
    End Sub
    Private Sub TextBox_leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAlias.Leave, txtNombre.Leave
        CType(sender, TextBox).BackColor = Color.White
    End Sub
#End Region
#Region "Manejo de botones"
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If txtNombre.Text.Trim = "" Then
            MessageBox.Show("No ha escrito el nombre de la colonia.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNombre.Focus()
        Else
            Dim frmSimilares As New frmSimilares(Municipio, Colonia, txtNombre.Text.Trim)
            Dim cmdCC As New SqlCommand("spCCColonia", Globales.GetInstance.cnSigamet)
            If Not frmSimilares.HaySimilares OrElse frmSimilares.ShowDialog = DialogResult.OK Then
                cmdCC.Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia
                cmdCC.Parameters.Add("@CP", SqlDbType.Char).Value = scboCP.SelectedValue
                cmdCC.Parameters.Add("@Municipio", SqlDbType.Int).Value = Municipio
                cmdCC.Parameters.Add("@Nombre", SqlDbType.Char).Value = txtNombre.Text.Trim
                cmdCC.Parameters.Add("@Alias", SqlDbType.Char).Value = txtAlias.Text.Trim
                cmdCC.Parameters.Add("@Status", SqlDbType.Char).Value = cboStatus.Text
                cmdCC.Parameters.Add("@Nuevo", SqlDbType.Bit).Value = Nuevo
                cmdCC.CommandType = CommandType.StoredProcedure
                Try
                    If Globales.GetInstance.cnSigamet.State <> ConnectionState.Open Then
                        Globales.GetInstance.cnSigamet.Open()
                    End If
                    cmdCC.ExecuteNonQuery()
                    Globales.GetInstance.cnSigamet.Close()
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Catch ex As Exception
                    Globales.GetInstance.ExMessage(ex)
                Finally
                    frmSimilares.Dispose()
                    If Globales.GetInstance.cnSigamet.State <> ConnectionState.Closed Then
                        Globales.GetInstance.cnSigamet.Close()
                    End If
                End Try
            End If
        End If
    End Sub
#End Region

    Private Sub frmCapturaColonia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

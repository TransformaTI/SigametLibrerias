Public Class frmCapturaCalle
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
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtAlias As System.Windows.Forms.TextBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCapturaCalle))
        Me.rgrpDatos = New CallesColonias.RoundedGroupBox()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.txtAlias = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblAlias = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.DarkOliveGreen
        Me.rgrpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboStatus, Me.txtAlias, Me.lblNombre, Me.lblAlias, Me.lblStatus, Me.txtNombre})
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpDatos.FlatStyle = CallesColonias.RoundedGroupBox.Style.Pipe
        Me.rgrpDatos.Location = New System.Drawing.Point(3, 3)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(373, 121)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Items.AddRange(New Object() {"MODIFICADO", "NUEVA", "NUEVO", "SIGAES", "VERIFICADO"})
        Me.cboStatus.Location = New System.Drawing.Point(72, 86)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(288, 21)
        Me.cboStatus.TabIndex = 9
        '
        'txtAlias
        '
        Me.txtAlias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAlias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAlias.Location = New System.Drawing.Point(72, 55)
        Me.txtAlias.MaxLength = 60
        Me.txtAlias.Name = "txtAlias"
        Me.txtAlias.Size = New System.Drawing.Size(288, 21)
        Me.txtAlias.TabIndex = 3
        Me.txtAlias.Text = ""
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(16, 28)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(54, 14)
        Me.lblNombre.TabIndex = 0
        Me.lblNombre.Text = "&Nombre:"
        '
        'lblAlias
        '
        Me.lblAlias.AutoSize = True
        Me.lblAlias.Location = New System.Drawing.Point(16, 58)
        Me.lblAlias.Name = "lblAlias"
        Me.lblAlias.Size = New System.Drawing.Size(31, 14)
        Me.lblAlias.TabIndex = 2
        Me.lblAlias.Text = "A&lias:"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(16, 89)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 14)
        Me.lblStatus.TabIndex = 8
        Me.lblStatus.Text = "S&tatus:"
        '
        'txtNombre
        '
        Me.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(72, 25)
        Me.txtNombre.MaxLength = 60
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(288, 21)
        Me.txtNombre.TabIndex = 1
        Me.txtNombre.Text = ""
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(384, 13)
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
        Me.btnCancelar.Location = New System.Drawing.Point(384, 45)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCapturaCalle
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(466, 127)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAceptar, Me.btnCancelar, Me.rgrpDatos})
        Me.DockPadding.All = 3
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapturaCalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.rgrpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constructores"
    'Nueva
    Public Sub New(ByVal NombreColonia As String, ByVal Colonia As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = "Nueva calle para la colonia " & NombreColonia.Trim
        Me.Colonia = Colonia
        cboStatus.Text = "NUEVA"
        cboStatus.Enabled = False
        Me.Calle = -1
    End Sub
    'Modificar
    Public Sub New(ByVal Colonia As Integer, ByVal Calle As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = "Modificación de calle"
        Me.Colonia = Colonia
        Me.Calle = Calle
        CargaDatosCalle(Calle)
        cboStatus.Text = "MODIFICADO"
        cboStatus.Enabled = Globales.GetInstance.ModificarStatus
    End Sub
#End Region
#Region "Variables globales"
    Private Colonia, Calle As Integer
#End Region
#Region "Carga de datos"
    Private Sub CargaDatosCalle(ByVal Calle As Integer)
        Dim cmdCC As New SqlCommand("Select Nombre, isnull(Alias,'') as Alias, StatusCalidad " & _
                                    " from Calle where Calle = @Calle", Globales.GetInstance.cnSigamet)
        Dim rdCalle As SqlDataReader
        cmdCC.Parameters.Add("@Calle", SqlDbType.Int).Value = Calle
        Try
            Me.Cursor = Cursors.WaitCursor
            If Globales.GetInstance.cnSigamet.State <> ConnectionState.Open Then
                Globales.GetInstance.cnSigamet.Open()
            End If
            rdCalle = cmdCC.ExecuteReader
            If rdCalle.Read Then
                txtNombre.Text = CStr(rdCalle("Nombre"))
                txtAlias.Text = CStr(rdCalle("Alias"))
                cboStatus.Text = CStr(rdCalle("StatusCalidad"))
            End If
            rdCalle.Close()
            Globales.GetInstance.cnSigamet.Close()
            Me.Cursor = Cursors.Default
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
    Private Sub txtNombre_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre.Leave
        If txtNombre.Text <> "" Then
            Dim cmdCC As New SqlCommand("Select Calle from Calle where Nombre = @Nombre", Globales.GetInstance.cnSigamet)
            Dim Calle As Integer
            cmdCC.Parameters.Add("@Nombre", SqlDbType.Char).Value = txtNombre.Text.Trim
            Try
                If Globales.GetInstance.cnSigamet.State <> ConnectionState.Open Then
                    Globales.GetInstance.cnSigamet.Open()
                End If
                If Not Microsoft.VisualBasic.IsDBNull(cmdCC.ExecuteScalar) AndAlso Not cmdCC.ExecuteScalar Is Nothing Then
                    Calle = CInt(cmdCC.ExecuteScalar)
                    Globales.GetInstance.cnSigamet.Close()
                    CargaDatosCalle(Calle)
                End If
            Catch ex As Exception
                Globales.GetInstance.ExMessage(ex)
            Finally
                If Globales.GetInstance.cnSigamet.State <> ConnectionState.Closed Then
                    Globales.GetInstance.cnSigamet.Close()
                End If
            End Try
        End If
    End Sub
    Private Sub TextBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAlias.Leave, txtNombre.Leave
        CType(sender, TextBox).BackColor = Color.White
    End Sub
    Private Sub TextBox_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAlias.Enter, txtNombre.Enter
        CType(sender, TextBox).BackColor = Color.LemonChiffon
        CType(sender, TextBox).SelectAll()
    End Sub
#End Region
#Region "Manejo de botones"
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If txtNombre.Text.Trim <> "" Then
            Dim frmSimilares As New frmSimilares(Calle, txtNombre.Text.Trim, Colonia)
            Dim cmdCC As New SqlCommand("spCCCalle", Globales.GetInstance.cnSigamet)
            If Not frmSimilares.HaySimilares OrElse frmSimilares.ShowDialog = DialogResult.OK Then
                cmdCC.CommandType = CommandType.StoredProcedure
                cmdCC.Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia
                cmdCC.Parameters.Add("@Nombre", SqlDbType.Char).Value = txtNombre.Text.Trim
                cmdCC.Parameters.Add("@Status", SqlDbType.Char).Value = cboStatus.Text
                cmdCC.Parameters.Add("@Alias", SqlDbType.Char).Value = txtAlias.Text.Trim
                cmdCC.Parameters.Add("@Calle", SqlDbType.Int).Value = Calle
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
        Else
            MessageBox.Show("No ha escrito el nombre de la calle.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNombre.Focus()
        End If
    End Sub
#End Region
End Class

Imports System.IO

Public Class frmPrincipal
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim daConfig As New SqlClient.SqlDataAdapter("Select Modulo, Nombre from Modulo", cnSigamet)
        Dim dtModulo As New DataTable()
        Try
            daConfig.Fill(dtModulo)
        Catch ex As Exception
            ExMessage(ex)
        End Try
        cboModulo.DisplayMember = "Nombre"
        cboModulo.ValueMember = "Modulo"
        cboModulo.DataSource = dtModulo
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
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents grpTipoActualizacion As System.Windows.Forms.GroupBox
    Friend WithEvents rdoNuevos As System.Windows.Forms.RadioButton
    Friend WithEvents rdoReemplazo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPersonalizada As System.Windows.Forms.RadioButton
    Friend WithEvents onlOpciones As System.Windows.Forms.Panel
    Friend WithEvents chkExe As System.Windows.Forms.CheckBox
    Friend WithEvents chkBibliotecas As System.Windows.Forms.CheckBox
    Friend WithEvents chkSubdirectorios As System.Windows.Forms.CheckBox
    Friend WithEvents lblArchivos As System.Windows.Forms.Label
    Friend WithEvents pnlModulo As System.Windows.Forms.Panel
    Friend WithEvents lblModulo As System.Windows.Forms.Label
    Friend WithEvents cboModulo As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents chklArchivos As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblEjecutable As System.Windows.Forms.Label
    Friend WithEvents cboEjecutable As System.Windows.Forms.ComboBox
    Friend WithEvents lblEjecutableAnterior As System.Windows.Forms.Label
    Friend WithEvents txtEjecutableAnterior As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPrincipal))
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.onlOpciones = New System.Windows.Forms.Panel()
        Me.lblArchivos = New System.Windows.Forms.Label()
        Me.chklArchivos = New System.Windows.Forms.CheckedListBox()
        Me.chkExe = New System.Windows.Forms.CheckBox()
        Me.chkBibliotecas = New System.Windows.Forms.CheckBox()
        Me.chkSubdirectorios = New System.Windows.Forms.CheckBox()
        Me.grpTipoActualizacion = New System.Windows.Forms.GroupBox()
        Me.rdoNuevos = New System.Windows.Forms.RadioButton()
        Me.rdoReemplazo = New System.Windows.Forms.RadioButton()
        Me.rdoPersonalizada = New System.Windows.Forms.RadioButton()
        Me.pnlModulo = New System.Windows.Forms.Panel()
        Me.cboEjecutable = New System.Windows.Forms.ComboBox()
        Me.lblEjecutable = New System.Windows.Forms.Label()
        Me.cboModulo = New System.Windows.Forms.ComboBox()
        Me.lblModulo = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblEjecutableAnterior = New System.Windows.Forms.Label()
        Me.txtEjecutableAnterior = New System.Windows.Forms.TextBox()
        Me.grpDatos.SuspendLayout()
        Me.onlOpciones.SuspendLayout()
        Me.grpTipoActualizacion.SuspendLayout()
        Me.pnlModulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDatos
        '
        Me.grpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.onlOpciones, Me.grpTipoActualizacion, Me.pnlModulo})
        Me.grpDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(400, 527)
        Me.grpDatos.TabIndex = 0
        Me.grpDatos.TabStop = False
        '
        'onlOpciones
        '
        Me.onlOpciones.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblArchivos, Me.chklArchivos, Me.chkExe, Me.chkBibliotecas, Me.chkSubdirectorios})
        Me.onlOpciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.onlOpciones.DockPadding.Bottom = 6
        Me.onlOpciones.DockPadding.Left = 5
        Me.onlOpciones.DockPadding.Right = 6
        Me.onlOpciones.DockPadding.Top = 5
        Me.onlOpciones.Location = New System.Drawing.Point(3, 176)
        Me.onlOpciones.Name = "onlOpciones"
        Me.onlOpciones.Size = New System.Drawing.Size(394, 348)
        Me.onlOpciones.TabIndex = 2
        '
        'lblArchivos
        '
        Me.lblArchivos.AutoSize = True
        Me.lblArchivos.Location = New System.Drawing.Point(9, 123)
        Me.lblArchivos.Name = "lblArchivos"
        Me.lblArchivos.Size = New System.Drawing.Size(105, 14)
        Me.lblArchivos.TabIndex = 3
        Me.lblArchivos.Text = "Archivos &del módulo"
        '
        'chklArchivos
        '
        Me.chklArchivos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.chklArchivos.Enabled = False
        Me.chklArchivos.Location = New System.Drawing.Point(5, 146)
        Me.chklArchivos.Name = "chklArchivos"
        Me.chklArchivos.Size = New System.Drawing.Size(383, 196)
        Me.chklArchivos.TabIndex = 1
        '
        'chkExe
        '
        Me.chkExe.Checked = True
        Me.chkExe.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkExe.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkExe.Location = New System.Drawing.Point(16, 11)
        Me.chkExe.Name = "chkExe"
        Me.chkExe.Size = New System.Drawing.Size(224, 24)
        Me.chkExe.TabIndex = 0
        Me.chkExe.Text = "Forzar la copia de &ejecutables (*.exe)"
        '
        'chkBibliotecas
        '
        Me.chkBibliotecas.Checked = True
        Me.chkBibliotecas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBibliotecas.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkBibliotecas.Location = New System.Drawing.Point(16, 43)
        Me.chkBibliotecas.Name = "chkBibliotecas"
        Me.chkBibliotecas.Size = New System.Drawing.Size(224, 24)
        Me.chkBibliotecas.TabIndex = 1
        Me.chkBibliotecas.Text = "Forzar la copia de las &bibliotecas (*.dll)"
        '
        'chkSubdirectorios
        '
        Me.chkSubdirectorios.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkSubdirectorios.Location = New System.Drawing.Point(16, 80)
        Me.chkSubdirectorios.Name = "chkSubdirectorios"
        Me.chkSubdirectorios.Size = New System.Drawing.Size(136, 24)
        Me.chkSubdirectorios.TabIndex = 2
        Me.chkSubdirectorios.Text = "Incluir &subdirectorios"
        '
        'grpTipoActualizacion
        '
        Me.grpTipoActualizacion.Controls.AddRange(New System.Windows.Forms.Control() {Me.rdoNuevos, Me.rdoReemplazo, Me.rdoPersonalizada})
        Me.grpTipoActualizacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpTipoActualizacion.Location = New System.Drawing.Point(3, 128)
        Me.grpTipoActualizacion.Name = "grpTipoActualizacion"
        Me.grpTipoActualizacion.Size = New System.Drawing.Size(394, 48)
        Me.grpTipoActualizacion.TabIndex = 1
        Me.grpTipoActualizacion.TabStop = False
        Me.grpTipoActualizacion.Text = "Tipo de actualización"
        '
        'rdoNuevos
        '
        Me.rdoNuevos.Checked = True
        Me.rdoNuevos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rdoNuevos.Location = New System.Drawing.Point(8, 16)
        Me.rdoNuevos.Name = "rdoNuevos"
        Me.rdoNuevos.Size = New System.Drawing.Size(168, 24)
        Me.rdoNuevos.TabIndex = 0
        Me.rdoNuevos.TabStop = True
        Me.rdoNuevos.Text = "Copiar sólo archivos &nuevos"
        '
        'rdoReemplazo
        '
        Me.rdoReemplazo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rdoReemplazo.Location = New System.Drawing.Point(176, 16)
        Me.rdoReemplazo.Name = "rdoReemplazo"
        Me.rdoReemplazo.Size = New System.Drawing.Size(112, 24)
        Me.rdoReemplazo.TabIndex = 1
        Me.rdoReemplazo.Text = "&Reemplazo total"
        '
        'rdoPersonalizada
        '
        Me.rdoPersonalizada.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rdoPersonalizada.Location = New System.Drawing.Point(296, 16)
        Me.rdoPersonalizada.Name = "rdoPersonalizada"
        Me.rdoPersonalizada.Size = New System.Drawing.Size(96, 24)
        Me.rdoPersonalizada.TabIndex = 2
        Me.rdoPersonalizada.Text = "&Personalizada"
        '
        'pnlModulo
        '
        Me.pnlModulo.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtEjecutableAnterior, Me.lblEjecutableAnterior, Me.cboEjecutable, Me.lblEjecutable, Me.cboModulo, Me.lblModulo})
        Me.pnlModulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlModulo.Location = New System.Drawing.Point(3, 17)
        Me.pnlModulo.Name = "pnlModulo"
        Me.pnlModulo.Size = New System.Drawing.Size(394, 111)
        Me.pnlModulo.TabIndex = 0
        '
        'cboEjecutable
        '
        Me.cboEjecutable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEjecutable.Location = New System.Drawing.Point(78, 40)
        Me.cboEjecutable.Name = "cboEjecutable"
        Me.cboEjecutable.Size = New System.Drawing.Size(310, 21)
        Me.cboEjecutable.TabIndex = 3
        '
        'lblEjecutable
        '
        Me.lblEjecutable.AutoSize = True
        Me.lblEjecutable.Location = New System.Drawing.Point(10, 43)
        Me.lblEjecutable.Name = "lblEjecutable"
        Me.lblEjecutable.Size = New System.Drawing.Size(60, 14)
        Me.lblEjecutable.TabIndex = 2
        Me.lblEjecutable.Text = "&Ejecutable:"
        '
        'cboModulo
        '
        Me.cboModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModulo.Location = New System.Drawing.Point(78, 5)
        Me.cboModulo.Name = "cboModulo"
        Me.cboModulo.Size = New System.Drawing.Size(310, 21)
        Me.cboModulo.TabIndex = 1
        '
        'lblModulo
        '
        Me.lblModulo.AutoSize = True
        Me.lblModulo.Location = New System.Drawing.Point(10, 8)
        Me.lblModulo.Name = "lblModulo"
        Me.lblModulo.Size = New System.Drawing.Size(44, 14)
        Me.lblModulo.TabIndex = 0
        Me.lblModulo.Text = "&Módulo:"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(416, 72)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnGuardar
        '
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Bitmap)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(416, 32)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 23)
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEjecutableAnterior
        '
        Me.lblEjecutableAnterior.AutoSize = True
        Me.lblEjecutableAnterior.Location = New System.Drawing.Point(11, 78)
        Me.lblEjecutableAnterior.Name = "lblEjecutableAnterior"
        Me.lblEjecutableAnterior.Size = New System.Drawing.Size(102, 14)
        Me.lblEjecutableAnterior.TabIndex = 4
        Me.lblEjecutableAnterior.Text = "&Ejecutable anterior:"
        '
        'txtEjecutableAnterior
        '
        Me.txtEjecutableAnterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEjecutableAnterior.Location = New System.Drawing.Point(120, 75)
        Me.txtEjecutableAnterior.Name = "txtEjecutableAnterior"
        Me.txtEjecutableAnterior.Size = New System.Drawing.Size(264, 21)
        Me.txtEjecutableAnterior.TabIndex = 5
        Me.txtEjecutableAnterior.Text = ""
        '
        'frmPrincipal
        '
        Me.AcceptButton = Me.btnGuardar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(514, 527)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.grpDatos, Me.btnGuardar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configurador de actualizaciones"
        Me.grpDatos.ResumeLayout(False)
        Me.onlOpciones.ResumeLayout(False)
        Me.grpTipoActualizacion.ResumeLayout(False)
        Me.pnlModulo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Ruta As String

    Private Sub cboModulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModulo.SelectedIndexChanged
        If Not cboModulo.SelectedItem Is Nothing Then
            Dim oConfig As SigametSeguridad.Public.Parametros
            oConfig = SigametSeguridad.Seguridad.Parametros(CShort(cboModulo.SelectedValue), CByte(_Corporativo), CByte(_Sucursal))

            Dim Archivo As String
            Dim chk As CheckBox = Nothing
            btnGuardar.Enabled = True
            chklArchivos.Items.Clear()
            cboEjecutable.Items.Clear()
            Try
                Ruta = oConfig.ValorParametro("RutaActualizacion")
                For Each Archivo In Directory.GetFiles(Ruta)
                    chklArchivos.Items.Add(Archivo.Substring(Ruta.Length))
                    If Archivo.EndsWith(".exe") Then
                        cboEjecutable.Items.Add(Archivo.Substring(Ruta.Length))
                    End If
                Next
                cboEjecutable.SelectedIndex = 0
            Catch
                ErrMessage("El módulo seleccionado no es actualizable automáticamente.")
                btnGuardar.Enabled = False
            End Try
        End If
    End Sub
    Private Sub rdoPersonalizada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoPersonalizada.CheckedChanged
        chklArchivos.Enabled = rdoPersonalizada.Checked
        chkExe.Enabled = Not rdoPersonalizada.Checked
        chkBibliotecas.Enabled = Not rdoPersonalizada.Checked
        chkSubdirectorios.Enabled = Not rdoPersonalizada.Checked
        If rdoPersonalizada.Checked Then
            chkExe.Checked = False
            chkBibliotecas.Checked = False
            chkSubdirectorios.Checked = False
        End If
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim Config As AppSettings
        Dim Archivo As String, Indice As Integer
        If IO.File.Exists(Ruta & "Update.config") Then
            File.Delete(Ruta & "Update.config")
        End If
        Config = New AppSettings(Ruta & "Update.config")
        With Config
            If rdoNuevos.Checked Then
                .SaveSetting("Configuracion", "TipoActualizacion", "Nuevos")
            ElseIf rdoReemplazo.Checked Then
                .SaveSetting("Configuracion", "TipoActualizacion", "Reemplazo")
            Else
                .SaveSetting("Configuracion", "TipoActualizacion", "Personalizada")
            End If
            .SaveSetting("Configuracion", "Ejecutable", cboEjecutable.Text)
            .SaveSetting("Configuracion", "EjecutableAnterior", txtEjecutableAnterior.Text)
            .SaveSetting("Configuracion", "ForzarEjecutables", chkExe.Checked.ToString)
            .SaveSetting("Configuracion", "ForzarBibliotecas", chkBibliotecas.Checked.ToString)
            .SaveSetting("Configuracion", "IncluirSubdirectorios", chkSubdirectorios.Checked.ToString)
            If rdoPersonalizada.Checked Then
                .SaveSetting("ActualizacionPersonalizada", "ArchivosACopiar", chklArchivos.CheckedItems.Count.ToString)
                For Each Archivo In chklArchivos.CheckedItems
                    Indice += 1
                    .SaveSetting("ActualizacionPersonalizada", "Archivo" & Indice.ToString, Archivo)
                Next
            End If
        End With
        MessageBox.Show("Se ha guardado la configuración.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close() : Me.Dispose()
    End Sub

    Private Sub rdoNuevos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoNuevos.CheckedChanged
        chkExe.Enabled = rdoNuevos.Checked
        chkBibliotecas.Enabled = rdoNuevos.Checked
        chkSubdirectorios.Enabled = rdoNuevos.Checked
        If rdoNuevos.Checked Then
            chkExe.Checked = True
            chkBibliotecas.Checked = True
            chkSubdirectorios.Checked = False
        End If
    End Sub

    Private Sub rdoReemplazo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoReemplazo.CheckedChanged
        chkExe.Enabled = Not rdoReemplazo.Checked
        chkBibliotecas.Enabled = Not rdoReemplazo.Checked
        chkSubdirectorios.Enabled = Not rdoReemplazo.Checked
        If rdoReemplazo.Checked Then
            chkExe.Checked = True
            chkBibliotecas.Checked = True
            chkSubdirectorios.Checked = True
        End If
    End Sub


    Private Sub cboEjecutable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEjecutable.SelectedIndexChanged
        txtEjecutableAnterior.Text = cboEjecutable.Text
    End Sub
End Class

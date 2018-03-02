Imports System.Data.SqlClient
Public Class frmSeleccionActualizacion
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'ConfiguraConexion(cnSigamet)
        CargaModulos()
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
    Friend WithEvents lblActualizacion As System.Windows.Forms.Label
    Friend WithEvents pnlActualizacion As System.Windows.Forms.Panel
    Friend WithEvents cboModulo As System.Windows.Forms.ComboBox
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSeleccionActualizacion))
        Me.lblActualizacion = New System.Windows.Forms.Label()
        Me.pnlActualizacion = New System.Windows.Forms.Panel()
        Me.cboModulo = New System.Windows.Forms.ComboBox()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.pnlActualizacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblActualizacion
        '
        Me.lblActualizacion.AutoSize = True
        Me.lblActualizacion.Location = New System.Drawing.Point(8, 16)
        Me.lblActualizacion.Name = "lblActualizacion"
        Me.lblActualizacion.Size = New System.Drawing.Size(105, 14)
        Me.lblActualizacion.TabIndex = 0
        Me.lblActualizacion.Text = "&Módulo a actualizar:"
        '
        'pnlActualizacion
        '
        Me.pnlActualizacion.BackColor = System.Drawing.Color.White
        Me.pnlActualizacion.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboModulo, Me.lblActualizacion})
        Me.pnlActualizacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlActualizacion.Name = "pnlActualizacion"
        Me.pnlActualizacion.Size = New System.Drawing.Size(346, 48)
        Me.pnlActualizacion.TabIndex = 1
        '
        'cboModulo
        '
        Me.cboModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModulo.Location = New System.Drawing.Point(120, 13)
        Me.cboModulo.Name = "cboModulo"
        Me.cboModulo.Size = New System.Drawing.Size(216, 21)
        Me.cboModulo.TabIndex = 1
        '
        'btnActualizar
        '
        Me.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnActualizar.Image = CType(resources.GetObject("btnActualizar.Image"), System.Drawing.Bitmap)
        Me.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActualizar.Location = New System.Drawing.Point(256, 56)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(80, 23)
        Me.btnActualizar.TabIndex = 2
        Me.btnActualizar.Text = "&Actualizar"
        Me.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(160, 56)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 23)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmSeleccionActualizacion
        '
        Me.AcceptButton = Me.btnActualizar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(346, 87)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnActualizar, Me.pnlActualizacion})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSeleccionActualizacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selección de actualizacion"
        Me.pnlActualizacion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CargaModulos()
        Dim da As New SqlDataAdapter("select M.Modulo, M.Nombre from Modulo M " & _
                                    "inner join Parametro P	on M.Modulo = P.Modulo " & _
                                    "where P.Parametro = 'RutaActualizacion' order by M.Nombre", cnSigamet)
        Dim dtModulos As New DataTable()
        Try
            da.Fill(dtModulos)
            cboModulo.ValueMember = "Modulo"
            cboModulo.DisplayMember = "Nombre"
            cboModulo.DataSource = dtModulos
        Catch ex As Exception
            ErrMessage(ex)
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Dim cmdSigamet As New SqlCommand("Select Valor from Parametro where Modulo = @Modulo and Parametro = 'RutaActualizacion'", cnSigamet)
        Dim frmActualizacion As New frmActualizacion(False)
        cmdSigamet.Parameters.Add("@Modulo", SqlDbType.Int).Value = CInt(cboModulo.SelectedValue)
        Try
            cnSigamet.Open()
            RutaOrigen = CStr(cmdSigamet.ExecuteScalar)
            RutaDestino = Application.StartupPath & "\..\" & cboModulo.Text & "\"
            If Not IO.Directory.Exists(RutaDestino) Then
                IO.Directory.CreateDirectory(RutaDestino)
            End If
            KillApp(cboModulo.Text)
            Me.Visible = False
            frmActualizacion.ShowDialog()
        Catch ex As Exception
            ErrMessage(ex)
        Finally
            cnSigamet.Close()
        End Try
    End Sub
End Class

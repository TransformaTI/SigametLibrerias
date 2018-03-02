Imports System.Data.SqlClient
Public Class frmConexionReporte
    Inherits System.Windows.Forms.Form
    Private _Modulo As Short
    Private _UsuarioGrupo As String
    Private _Reporte As String
    Private _TipoSeguridad As SigaMetClasses.Enumeradores.enumTipoSeguridadReporte
    Private _connection As SqlConnection
    Private _catalogoServidores As DataTable

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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblModulo As System.Windows.Forms.Label
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents lblUsuarioGrupo As System.Windows.Forms.Label
    Friend WithEvents lblUsuarioGrupo1 As System.Windows.Forms.Label
    Friend WithEvents grpDatosConexion As System.Windows.Forms.GroupBox
    Friend WithEvents cboServidor As System.Windows.Forms.ComboBox
    Friend WithEvents cboBaseDatos As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConexionReporte))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lblModulo = New System.Windows.Forms.Label()
        Me.lblUsuarioGrupo = New System.Windows.Forms.Label()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblUsuarioGrupo1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.grpDatosConexion = New System.Windows.Forms.GroupBox()
        Me.cboServidor = New System.Windows.Forms.ComboBox()
        Me.cboBaseDatos = New System.Windows.Forms.ComboBox()
        Me.grpDatosConexion.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(456, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(456, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblModulo
        '
        Me.lblModulo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModulo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblModulo.Location = New System.Drawing.Point(72, 16)
        Me.lblModulo.Name = "lblModulo"
        Me.lblModulo.Size = New System.Drawing.Size(168, 21)
        Me.lblModulo.TabIndex = 8
        Me.lblModulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUsuarioGrupo
        '
        Me.lblUsuarioGrupo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuarioGrupo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblUsuarioGrupo.Location = New System.Drawing.Point(72, 40)
        Me.lblUsuarioGrupo.Name = "lblUsuarioGrupo"
        Me.lblUsuarioGrupo.Size = New System.Drawing.Size(168, 21)
        Me.lblUsuarioGrupo.TabIndex = 9
        Me.lblUsuarioGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReporte
        '
        Me.lblReporte.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporte.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblReporte.Location = New System.Drawing.Point(72, 64)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(376, 48)
        Me.lblReporte.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label4.Location = New System.Drawing.Point(16, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 14)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Módulo:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUsuarioGrupo1
        '
        Me.lblUsuarioGrupo1.AutoSize = True
        Me.lblUsuarioGrupo1.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblUsuarioGrupo1.Location = New System.Drawing.Point(16, 43)
        Me.lblUsuarioGrupo1.Name = "lblUsuarioGrupo1"
        Me.lblUsuarioGrupo1.Size = New System.Drawing.Size(46, 14)
        Me.lblUsuarioGrupo1.TabIndex = 12
        Me.lblUsuarioGrupo1.Text = "Usuario:"
        Me.lblUsuarioGrupo1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label6.Location = New System.Drawing.Point(16, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 14)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Reporte:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 14)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Servidor:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(268, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 14)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Base de datos:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpDatosConexion
        '
        Me.grpDatosConexion.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboBaseDatos, Me.cboServidor, Me.Label8, Me.Label7})
        Me.grpDatosConexion.Location = New System.Drawing.Point(9, 120)
        Me.grpDatosConexion.Name = "grpDatosConexion"
        Me.grpDatosConexion.Size = New System.Drawing.Size(520, 64)
        Me.grpDatosConexion.TabIndex = 16
        Me.grpDatosConexion.TabStop = False
        Me.grpDatosConexion.Text = "Deseo que el reporte se ejecute con los siguientes parámetros:"
        '
        'cboServidor
        '
        Me.cboServidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServidor.Location = New System.Drawing.Point(88, 24)
        Me.cboServidor.Name = "cboServidor"
        Me.cboServidor.Size = New System.Drawing.Size(140, 21)
        Me.cboServidor.TabIndex = 16
        '
        'cboBaseDatos
        '
        Me.cboBaseDatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBaseDatos.Location = New System.Drawing.Point(368, 24)
        Me.cboBaseDatos.Name = "cboBaseDatos"
        Me.cboBaseDatos.Size = New System.Drawing.Size(140, 21)
        Me.cboBaseDatos.TabIndex = 17
        '
        'frmConexionReporte
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(538, 191)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpDatosConexion, Me.Label6, Me.lblUsuarioGrupo1, Me.Label4, Me.lblReporte, Me.lblUsuarioGrupo, Me.lblModulo, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConexionReporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datos para la conexión del reporte"
        Me.grpDatosConexion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal Modulo As Short, _
                   ByVal UsuarioGrupo As String, _
                   ByVal Reporte As String, _
                   ByVal TipoSeguridad As SigaMetClasses.Enumeradores.enumTipoSeguridadReporte, _
                   ByVal CatalogoServidores As DataTable, _
                   ByVal Connection As SqlConnection)
        MyBase.New()
        InitializeComponent()

        _Modulo = Modulo
        _UsuarioGrupo = UsuarioGrupo
        _Reporte = Reporte
        _TipoSeguridad = TipoSeguridad

        _connection = Connection

        _catalogoServidores = CatalogoServidores

        lblModulo.Text = _Modulo.ToString
        lblUsuarioGrupo.Text = _UsuarioGrupo
        lblReporte.Text = _Reporte

        If TipoSeguridad = SigaMetClasses.Enumeradores.enumTipoSeguridadReporte.Grupo Then
            lblUsuarioGrupo1.Text = "Grupo:"
        Else
            lblUsuarioGrupo1.Text = "Usuario:"
        End If

        CargaDatos()

    End Sub


    Private Sub CargaDatos()
        Dim strQuery As String
        If _TipoSeguridad = SigaMetClasses.Enumeradores.enumTipoSeguridadReporte.Usuario Then
            strQuery = "SELECT Modulo, Usuario as UsuarioGrupo, Reporte, Servidor, BaseDatos " & _
                       "FROM UsuarioReporte " & _
                       "WHERE Modulo = " & _Modulo & _
                       " AND Usuario = '" & _UsuarioGrupo & "'" & _
                       " AND Reporte = '" & _Reporte & "'"
        Else
            strQuery = "SELECT Modulo, Grupo as UsuarioGrupo, Reporte, Servidor, BaseDatos " & _
                       "FROM GrupoReporte " & _
                       "WHERE Modulo = " & _Modulo & _
                       " AND Grupo = '" & _UsuarioGrupo & "'" & _
                       " AND Reporte = '" & _Reporte & "'"
        End If
        Dim da As New SqlDataAdapter(strQuery, _connection)
        Dim dt As New DataTable("Reporte")

        Try
            cboServidor.DataSource = _catalogoServidores
            cboServidor.ValueMember = "Servidor"

            cboBaseDatos.DataSource = _catalogoServidores
            cboBaseDatos.ValueMember = "BaseDatos"
            da.Fill(dt)
            If dt.Rows.Count = 1 Then
                lblModulo.Text = CType(dt.Rows(0).Item("Modulo"), String)
                lblUsuarioGrupo.Text = CType(dt.Rows(0).Item("UsuarioGrupo"), String)
                lblReporte.Text = CType(dt.Rows(0).Item("Reporte"), String)
                cboServidor.SelectedValue = CType(dt.Rows(0).Item("Servidor"), String)
                cboBaseDatos.SelectedValue = CType(dt.Rows(0).Item("BaseDatos"), String)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            dt.Dispose()
        End Try
    End Sub


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If Trim(cboServidor.Text) = "" Then
            MessageBox.Show("Debe teclear el nombre del servidor.", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboServidor.Focus()
            Exit Sub
        End If

        If Trim(cboBaseDatos.Text) = "" Then
            MessageBox.Show("Debe teclear el nombre de la base de datos.", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboBaseDatos.Focus()
            Exit Sub
        End If

        If MessageBox.Show(SigaMetClasses.M_ESTAN_CORRECTOS, "Conexión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim cmd As New SqlCommand("spSEGReporteCambiaConexion")
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@Modulo", SqlDbType.SmallInt).Value = _Modulo
                .Parameters.Add("@UsuarioGrupo", SqlDbType.Char, 15).Value = _UsuarioGrupo
                .Parameters.Add("@Reporte", SqlDbType.VarChar, 100).Value = _Reporte
                .Parameters.Add("@Servidor", SqlDbType.VarChar, 20).Value = Trim(cboServidor.Text)
                .Parameters.Add("@BaseDatos", SqlDbType.VarChar, 20).Value = Trim(cboBaseDatos.Text)
                If _TipoSeguridad = SigaMetClasses.Enumeradores.enumTipoSeguridadReporte.Usuario Then
                    .Parameters.Add("@Grupo", SqlDbType.Bit).Value = 0
                End If
            End With
            Dim cn As SqlConnection = _connection
            cmd.Connection = cn

            Try
                Try
                    cn.Open()
                Catch ex As Exception
                    MessageBox.Show("No se pudo realizar la conexión a la base de datos." & Chr(13) & _
                    "Por favor intente de nuevo más tarde.", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try

                If cn.State = ConnectionState.Open Then
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Actualización exitosa.", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DialogResult = DialogResult.OK
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default
                cmd.Dispose()
                If Not cn Is Nothing Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()
                    End If
                    cn.Dispose()
                End If
            End Try
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

End Class

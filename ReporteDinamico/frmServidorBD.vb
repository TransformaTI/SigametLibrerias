Public Class frmServidorBD
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cboServidor As System.Windows.Forms.ComboBox
    Friend WithEvents cboBaseDatos As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmServidorBD))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.cboServidor = New System.Windows.Forms.ComboBox()
        Me.cboBaseDatos = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Servidor:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(8, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Base de datos:"
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Location = New System.Drawing.Point(8, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(244, 32)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "El reporte debería correr en este servidor y base de datos:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.Silver
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.Location = New System.Drawing.Point(228, 44)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(24, 20)
        Me.btnAceptar.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Silver
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.Location = New System.Drawing.Point(228, 68)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(24, 20)
        Me.btnCancelar.TabIndex = 6
        '
        'cboServidor
        '
        Me.cboServidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServidor.Location = New System.Drawing.Point(100, 44)
        Me.cboServidor.Name = "cboServidor"
        Me.cboServidor.TabIndex = 7
        '
        'cboBaseDatos
        '
        Me.cboBaseDatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBaseDatos.Location = New System.Drawing.Point(100, 68)
        Me.cboBaseDatos.Name = "cboBaseDatos"
        Me.cboBaseDatos.TabIndex = 8
        '
        'frmServidorBD
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(260, 99)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboBaseDatos, Me.cboServidor, Me.btnCancelar, Me.Label3, Me.btnAceptar, Me.Label2, Me.Label1})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServidorBD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Servidor-BD"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _servidor As String
    Private _baseDatos As String
    Private _reporte As String
    Private _connection As SqlClient.SqlConnection
    Private _data As SGDAC.DAC
    Private _dtCatalogoServidores As DataTable

    Public ReadOnly Property Servidor() As String
        Get
            Return _servidor
        End Get
    End Property

    Public ReadOnly Property BaseDAtos() As String
        Get
            Return _baseDatos
        End Get
    End Property

    Public Sub New(ByVal Reporte As String, ByVal CatalogoServidores As DataTable, ByVal Connection As SqlClient.SqlConnection)
        MyBase.New()
        InitializeComponent()
        _reporte = Reporte
        _connection = Connection
        _data = New SGDAC.DAC(_connection)
        _dtCatalogoServidores = CatalogoServidores

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If cboServidor.Text.Trim.Length > 0 AndAlso cboBaseDatos.Text.Trim.Length > 0 Then
            _servidor = cboServidor.Text.Trim()
            _baseDatos = cboBaseDatos.Text.Trim()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub txtServidor_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cboServidor.SelectAll()
    End Sub

    Private Sub txtBaseDatos_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cboBaseDatos.SelectAll()
    End Sub

    Private Sub ServidorDefault()
        Dim param(0) As SqlClient.SqlParameter
        param(0) = New SqlClient.SqlParameter("@Reporte", SqlDbType.VarChar, 100)
        param(0).Value = _reporte

        Dim reader As SqlClient.SqlDataReader
        reader = _data.LoadData("spSEGConsultaCatalogoReporte", CommandType.StoredProcedure, param)

        While reader.Read()
            cboServidor.SelectedValue = CType(reader("Servidor"), String)
            cboBaseDatos.SelectedValue = CType(reader("BaseDatos"), String)
        End While
        reader.Close()
        _data.CloseConnection()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmServidorBD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboServidor.DataSource = _dtCatalogoServidores
        cboServidor.ValueMember = "Servidor"

        cboBaseDatos.DataSource = _dtCatalogoServidores
        cboBaseDatos.ValueMember = "BaseDatos"

        ServidorDefault()
    End Sub
End Class

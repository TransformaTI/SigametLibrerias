Option Explicit On 
Option Strict On
Public Class frmBuscaCliente
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
    Friend WithEvents Contrato As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtEstaVista As System.Windows.Forms.RadioButton
    Friend WithEvents btnBaseDatos As System.Windows.Forms.RadioButton
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBuscaCliente))
        Me.Contrato = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBaseDatos = New System.Windows.Forms.RadioButton()
        Me.rbtEstaVista = New System.Windows.Forms.RadioButton()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Contrato
        '
        Me.Contrato.AutoSize = True
        Me.Contrato.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contrato.Location = New System.Drawing.Point(8, 88)
        Me.Contrato.Name = "Contrato"
        Me.Contrato.Size = New System.Drawing.Size(58, 14)
        Me.Contrato.TabIndex = 6
        Me.Contrato.Text = "Contrato:"
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(232, 15)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(88, 23)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "    &Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(232, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(88, 23)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "    &Cancelar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBaseDatos, Me.rbtEstaVista})
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(216, 64)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscar"
        '
        'btnBaseDatos
        '
        Me.btnBaseDatos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBaseDatos.Location = New System.Drawing.Point(8, 40)
        Me.btnBaseDatos.Name = "btnBaseDatos"
        Me.btnBaseDatos.Size = New System.Drawing.Size(120, 16)
        Me.btnBaseDatos.TabIndex = 1
        Me.btnBaseDatos.Text = "en la base de datos"
        '
        'rbtEstaVista
        '
        Me.rbtEstaVista.Checked = True
        Me.rbtEstaVista.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtEstaVista.Location = New System.Drawing.Point(8, 20)
        Me.rbtEstaVista.Name = "rbtEstaVista"
        Me.rbtEstaVista.Size = New System.Drawing.Size(104, 16)
        Me.rbtEstaVista.TabIndex = 0
        Me.rbtEstaVista.TabStop = True
        Me.rbtEstaVista.Text = "en esta vista"
        '
        'txtCliente
        '
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(80, 85)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(144, 21)
        Me.txtCliente.TabIndex = 0
        Me.txtCliente.TabStop = False
        Me.txtCliente.Text = ""
        '
        'frmBuscaCliente
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(330, 119)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.btnCancelar, Me.btnAceptar, Me.Contrato, Me.txtCliente})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscaCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _cliente As Integer, _
            _buscarBd As Boolean = False, _
            _connection As SqlClient.SqlConnection

    Public Property Cliente() As Integer
        Get
            Return _cliente
        End Get
        Set(ByVal Value As Integer)
            _cliente = Value
        End Set
    End Property

    Public ReadOnly Property BuscarBD() As Boolean
        Get
            Return _buscarBd
        End Get
    End Property

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        _cliente = CInt(Val(txtCliente.Text))
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub rbtEstaVista_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtEstaVista.CheckedChanged
        If rbtEstaVista.Checked Then
            txtCliente.ReadOnly = False
        Else
            txtCliente.ReadOnly = True
        End If
    End Sub

    Private Sub btnBaseDatos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBaseDatos.CheckedChanged
        If btnBaseDatos.Checked Then
            _buscarBd = True
        Else
            _buscarBd = False
        End If
    End Sub
End Class

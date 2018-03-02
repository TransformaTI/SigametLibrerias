Option Explicit On 
Option Strict On
Public Class AltaAlmacen
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Cliente As Integer, ByVal conexion As SqlClient.SqlConnection)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        _cliente = Cliente
        _connection = conexion

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
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtCapacidad As System.Windows.Forms.TextBox
    Friend WithEvents txtPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents txtLitros As System.Windows.Forms.TextBox
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Contrato As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFAlta As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AltaAlmacen))
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtCapacidad = New System.Windows.Forms.TextBox()
        Me.txtPorcentaje = New System.Windows.Forms.TextBox()
        Me.txtLitros = New System.Windows.Forms.TextBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Contrato = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFAlta = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(136, 8)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(96, 21)
        Me.txtCliente.TabIndex = 0
        Me.txtCliente.TabStop = False
        Me.txtCliente.Text = "12345678900"
        '
        'txtCapacidad
        '
        Me.txtCapacidad.Location = New System.Drawing.Point(136, 32)
        Me.txtCapacidad.Name = "txtCapacidad"
        Me.txtCapacidad.Size = New System.Drawing.Size(64, 21)
        Me.txtCapacidad.TabIndex = 1
        Me.txtCapacidad.Text = "TextBox2"
        Me.txtCapacidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.Location = New System.Drawing.Point(136, 80)
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(64, 21)
        Me.txtPorcentaje.TabIndex = 3
        Me.txtPorcentaje.Text = "TextBox1"
        Me.txtPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLitros
        '
        Me.txtLitros.Location = New System.Drawing.Point(136, 104)
        Me.txtLitros.Name = "txtLitros"
        Me.txtLitros.ReadOnly = True
        Me.txtLitros.Size = New System.Drawing.Size(64, 21)
        Me.txtLitros.TabIndex = 4
        Me.txtLitros.TabStop = False
        Me.txtLitros.Text = "TextBox1"
        Me.txtLitros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(136, 128)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(144, 56)
        Me.txtObservaciones.TabIndex = 5
        Me.txtObservaciones.Text = "TextBox1"
        '
        'Contrato
        '
        Me.Contrato.AutoSize = True
        Me.Contrato.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contrato.Location = New System.Drawing.Point(16, 11)
        Me.Contrato.Name = "Contrato"
        Me.Contrato.Size = New System.Drawing.Size(58, 14)
        Me.Contrato.TabIndex = 6
        Me.Contrato.Text = "Contrato:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 14)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Capacidad:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 14)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Porcentaje Inicial:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 14)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Litros iniciales:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 131)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 14)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Observaciones:"
        '
        'txtFAlta
        '
        Me.txtFAlta.Location = New System.Drawing.Point(136, 56)
        Me.txtFAlta.Name = "txtFAlta"
        Me.txtFAlta.ReadOnly = True
        Me.txtFAlta.Size = New System.Drawing.Size(144, 21)
        Me.txtFAlta.TabIndex = 2
        Me.txtFAlta.TabStop = False
        Me.txtFAlta.Text = "TextBox1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 14)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Fecha Alta:"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(296, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 23)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "    &Aceptar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(208, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 14)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "lts"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(208, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 14)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "%"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(208, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 14)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "lts"
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(296, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 23)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "    &Cancelar"
        '
        'AltaAlmacen
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(384, 197)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label8, Me.Label7, Me.Label1, Me.btnCancelar, Me.btnAceptar, Me.Label6, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.Contrato, Me.txtObservaciones, Me.txtLitros, Me.txtPorcentaje, Me.txtFAlta, Me.txtCapacidad, Me.txtCliente})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AltaAlmacen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta de Almacen"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim _cliente As Integer
    Dim _connection As SqlClient.SqlConnection

    Dim Almacen As CAltaAlmacen



    Private Sub AltaAlmacen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Almacen = New CAltaAlmacen(_connection, _cliente)
        Almacen.Cliente = _cliente
        txtCapacidad.Text = CStr(Almacen.Capacidad)
        txtCliente.Text = CStr(Almacen.Cliente)
        txtFAlta.Text = CStr(Almacen.FAlta)
        txtObservaciones.Text = CStr(Almacen.Observaciones)
        txtLitros.Text = CStr(Almacen.LitrosInicial)
        txtPorcentaje.Text = CStr(Almacen.PorcentajeInicial)
        If Almacen.SoloLectura Then
            Dim ctrl As Windows.Forms.Control
            For Each ctrl In Me.Controls
                If TypeOf ctrl Is Windows.Forms.TextBox Then
                    DirectCast(ctrl, Windows.Forms.TextBox).ReadOnly = True
                    DirectCast(ctrl, Windows.Forms.TextBox).TabStop = False
                End If
            Next
            RemoveHandler btnAceptar.Click, AddressOf btnAceptar_Click
            AddHandler btnAceptar.Click, AddressOf btnCancelar_Click
        Else
            AddHandler txtPorcentaje.Validated, AddressOf CalculaLitrosInicial
            txtFAlta.Text = Now.ToString
        End If

    End Sub

    Private Sub CalculaLitrosInicial(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Almacen.LitrosInicial = CInt(Almacen.Capacidad * CDbl(Almacen.PorcentajeInicial / 100))
        txtLitros.Text = CStr(Almacen.LitrosInicial)
    End Sub

    Private Sub txtCapacidad_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCapacidad.Validated
        Almacen.Capacidad = CInt(txtCapacidad.Text)
    End Sub

    Private Sub txtPorcentaje_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPorcentaje.Validated
        Almacen.PorcentajeInicial = CType(txtPorcentaje.Text, Short)
    End Sub

    Private Sub txtObservaciones_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtObservaciones.Validated
        Almacen.Observaciones = txtObservaciones.Text
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            Almacen.AltaAlmacen()
            MsgBox("Alta de almacén concluida", MsgBoxStyle.Information, "Alta de almacén")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class

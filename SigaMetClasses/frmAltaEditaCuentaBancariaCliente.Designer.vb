<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAltaEditaCuentaBancariaCliente
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAltaEditaCuentaBancariaCliente))
        Me.Gb_DatosCliente = New System.Windows.Forms.GroupBox()
        Me.Txtb_Municipio = New System.Windows.Forms.TextBox()
        Me.Txtb_Colonia = New System.Windows.Forms.TextBox()
        Me.Txtb_calle = New System.Windows.Forms.TextBox()
        Me.Txtb_Nombre = New System.Windows.Forms.TextBox()
        Me.TxtBox_Ruta = New System.Windows.Forms.TextBox()
        Me.lb_Ruta = New System.Windows.Forms.Label()
        Me.TxtBox_Cliente = New System.Windows.Forms.TextBox()
        Me.lb_Municipio = New System.Windows.Forms.Label()
        Me.Lb_colonia = New System.Windows.Forms.Label()
        Me.lb_Calle = New System.Windows.Forms.Label()
        Me.lb_Nombre = New System.Windows.Forms.Label()
        Me.lb_cliente = New System.Windows.Forms.Label()
        Me.GB_CuentaBancaria = New System.Windows.Forms.GroupBox()
        Me.Cbb_Estatus = New System.Windows.Forms.ComboBox()
        Me.Lb_Estatus = New System.Windows.Forms.Label()
        Me.Txtb_Referencia = New System.Windows.Forms.TextBox()
        Me.Txtb_Sucursal = New System.Windows.Forms.TextBox()
        Me.Txtb_Clave = New System.Windows.Forms.TextBox()
        Me.Txtb_Ceunta = New System.Windows.Forms.TextBox()
        Me.Cbb_Banco = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.Gb_DatosCliente.SuspendLayout()
        Me.GB_CuentaBancaria.SuspendLayout()
        Me.SuspendLayout()
        '
        'Gb_DatosCliente
        '
        Me.Gb_DatosCliente.Controls.Add(Me.Txtb_Municipio)
        Me.Gb_DatosCliente.Controls.Add(Me.Txtb_Colonia)
        Me.Gb_DatosCliente.Controls.Add(Me.Txtb_calle)
        Me.Gb_DatosCliente.Controls.Add(Me.Txtb_Nombre)
        Me.Gb_DatosCliente.Controls.Add(Me.TxtBox_Ruta)
        Me.Gb_DatosCliente.Controls.Add(Me.lb_Ruta)
        Me.Gb_DatosCliente.Controls.Add(Me.TxtBox_Cliente)
        Me.Gb_DatosCliente.Controls.Add(Me.lb_Municipio)
        Me.Gb_DatosCliente.Controls.Add(Me.Lb_colonia)
        Me.Gb_DatosCliente.Controls.Add(Me.lb_Calle)
        Me.Gb_DatosCliente.Controls.Add(Me.lb_Nombre)
        Me.Gb_DatosCliente.Controls.Add(Me.lb_cliente)
        Me.Gb_DatosCliente.Location = New System.Drawing.Point(12, 12)
        Me.Gb_DatosCliente.Name = "Gb_DatosCliente"
        Me.Gb_DatosCliente.Size = New System.Drawing.Size(454, 164)
        Me.Gb_DatosCliente.TabIndex = 1
        Me.Gb_DatosCliente.TabStop = False
        Me.Gb_DatosCliente.Text = "Datos del cliente"
        '
        'Txtb_Municipio
        '
        Me.Txtb_Municipio.Location = New System.Drawing.Point(70, 132)
        Me.Txtb_Municipio.Name = "Txtb_Municipio"
        Me.Txtb_Municipio.Size = New System.Drawing.Size(367, 20)
        Me.Txtb_Municipio.TabIndex = 11
        '
        'Txtb_Colonia
        '
        Me.Txtb_Colonia.Location = New System.Drawing.Point(70, 106)
        Me.Txtb_Colonia.Name = "Txtb_Colonia"
        Me.Txtb_Colonia.Size = New System.Drawing.Size(367, 20)
        Me.Txtb_Colonia.TabIndex = 10
        '
        'Txtb_calle
        '
        Me.Txtb_calle.Location = New System.Drawing.Point(70, 77)
        Me.Txtb_calle.Name = "Txtb_calle"
        Me.Txtb_calle.Size = New System.Drawing.Size(367, 20)
        Me.Txtb_calle.TabIndex = 9
        '
        'Txtb_Nombre
        '
        Me.Txtb_Nombre.Location = New System.Drawing.Point(70, 51)
        Me.Txtb_Nombre.Name = "Txtb_Nombre"
        Me.Txtb_Nombre.Size = New System.Drawing.Size(367, 20)
        Me.Txtb_Nombre.TabIndex = 8
        '
        'TxtBox_Ruta
        '
        Me.TxtBox_Ruta.Location = New System.Drawing.Point(337, 17)
        Me.TxtBox_Ruta.Name = "TxtBox_Ruta"
        Me.TxtBox_Ruta.Size = New System.Drawing.Size(100, 20)
        Me.TxtBox_Ruta.TabIndex = 7
        '
        'lb_Ruta
        '
        Me.lb_Ruta.AutoSize = True
        Me.lb_Ruta.Location = New System.Drawing.Point(288, 24)
        Me.lb_Ruta.Name = "lb_Ruta"
        Me.lb_Ruta.Size = New System.Drawing.Size(30, 13)
        Me.lb_Ruta.TabIndex = 6
        Me.lb_Ruta.Text = "Ruta"
        '
        'TxtBox_Cliente
        '
        Me.TxtBox_Cliente.Location = New System.Drawing.Point(70, 17)
        Me.TxtBox_Cliente.Name = "TxtBox_Cliente"
        Me.TxtBox_Cliente.Size = New System.Drawing.Size(100, 20)
        Me.TxtBox_Cliente.TabIndex = 5
        '
        'lb_Municipio
        '
        Me.lb_Municipio.AutoSize = True
        Me.lb_Municipio.Location = New System.Drawing.Point(7, 139)
        Me.lb_Municipio.Name = "lb_Municipio"
        Me.lb_Municipio.Size = New System.Drawing.Size(52, 13)
        Me.lb_Municipio.TabIndex = 4
        Me.lb_Municipio.Text = "Municipio"
        '
        'Lb_colonia
        '
        Me.Lb_colonia.AutoSize = True
        Me.Lb_colonia.Location = New System.Drawing.Point(7, 111)
        Me.Lb_colonia.Name = "Lb_colonia"
        Me.Lb_colonia.Size = New System.Drawing.Size(42, 13)
        Me.Lb_colonia.TabIndex = 3
        Me.Lb_colonia.Text = "Colonia"
        '
        'lb_Calle
        '
        Me.lb_Calle.AutoSize = True
        Me.lb_Calle.Location = New System.Drawing.Point(7, 84)
        Me.lb_Calle.Name = "lb_Calle"
        Me.lb_Calle.Size = New System.Drawing.Size(30, 13)
        Me.lb_Calle.TabIndex = 2
        Me.lb_Calle.Text = "Calle"
        '
        'lb_Nombre
        '
        Me.lb_Nombre.AutoSize = True
        Me.lb_Nombre.Location = New System.Drawing.Point(6, 54)
        Me.lb_Nombre.Name = "lb_Nombre"
        Me.lb_Nombre.Size = New System.Drawing.Size(44, 13)
        Me.lb_Nombre.TabIndex = 1
        Me.lb_Nombre.Text = "Nombre"
        '
        'lb_cliente
        '
        Me.lb_cliente.AutoSize = True
        Me.lb_cliente.Location = New System.Drawing.Point(7, 24)
        Me.lb_cliente.Name = "lb_cliente"
        Me.lb_cliente.Size = New System.Drawing.Size(39, 13)
        Me.lb_cliente.TabIndex = 0
        Me.lb_cliente.Text = "Cliente"
        '
        'GB_CuentaBancaria
        '
        Me.GB_CuentaBancaria.Controls.Add(Me.Cbb_Estatus)
        Me.GB_CuentaBancaria.Controls.Add(Me.Lb_Estatus)
        Me.GB_CuentaBancaria.Controls.Add(Me.Txtb_Referencia)
        Me.GB_CuentaBancaria.Controls.Add(Me.Txtb_Sucursal)
        Me.GB_CuentaBancaria.Controls.Add(Me.Txtb_Clave)
        Me.GB_CuentaBancaria.Controls.Add(Me.Txtb_Ceunta)
        Me.GB_CuentaBancaria.Controls.Add(Me.Cbb_Banco)
        Me.GB_CuentaBancaria.Controls.Add(Me.Label2)
        Me.GB_CuentaBancaria.Controls.Add(Me.Label3)
        Me.GB_CuentaBancaria.Controls.Add(Me.Label4)
        Me.GB_CuentaBancaria.Controls.Add(Me.Label5)
        Me.GB_CuentaBancaria.Controls.Add(Me.Label6)
        Me.GB_CuentaBancaria.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GB_CuentaBancaria.Location = New System.Drawing.Point(12, 199)
        Me.GB_CuentaBancaria.Name = "GB_CuentaBancaria"
        Me.GB_CuentaBancaria.Size = New System.Drawing.Size(454, 198)
        Me.GB_CuentaBancaria.TabIndex = 2
        Me.GB_CuentaBancaria.TabStop = False
        Me.GB_CuentaBancaria.Text = "Cuenta Bancaria"
        '
        'Cbb_Estatus
        '
        Me.Cbb_Estatus.FormattingEnabled = True
        Me.Cbb_Estatus.Location = New System.Drawing.Point(70, 164)
        Me.Cbb_Estatus.Name = "Cbb_Estatus"
        Me.Cbb_Estatus.Size = New System.Drawing.Size(121, 21)
        Me.Cbb_Estatus.TabIndex = 15
        '
        'Lb_Estatus
        '
        Me.Lb_Estatus.AutoSize = True
        Me.Lb_Estatus.Location = New System.Drawing.Point(13, 164)
        Me.Lb_Estatus.Name = "Lb_Estatus"
        Me.Lb_Estatus.Size = New System.Drawing.Size(42, 13)
        Me.Lb_Estatus.TabIndex = 14
        Me.Lb_Estatus.Text = "Estatus"
        '
        'Txtb_Referencia
        '
        Me.Txtb_Referencia.Location = New System.Drawing.Point(70, 133)
        Me.Txtb_Referencia.Name = "Txtb_Referencia"
        Me.Txtb_Referencia.Size = New System.Drawing.Size(367, 20)
        Me.Txtb_Referencia.TabIndex = 13
        '
        'Txtb_Sucursal
        '
        Me.Txtb_Sucursal.Location = New System.Drawing.Point(70, 107)
        Me.Txtb_Sucursal.Name = "Txtb_Sucursal"
        Me.Txtb_Sucursal.Size = New System.Drawing.Size(367, 20)
        Me.Txtb_Sucursal.TabIndex = 12
        '
        'Txtb_Clave
        '
        Me.Txtb_Clave.Location = New System.Drawing.Point(70, 81)
        Me.Txtb_Clave.Name = "Txtb_Clave"
        Me.Txtb_Clave.Size = New System.Drawing.Size(367, 20)
        Me.Txtb_Clave.TabIndex = 11
        '
        'Txtb_Ceunta
        '
        Me.Txtb_Ceunta.Location = New System.Drawing.Point(70, 55)
        Me.Txtb_Ceunta.Name = "Txtb_Ceunta"
        Me.Txtb_Ceunta.Size = New System.Drawing.Size(367, 20)
        Me.Txtb_Ceunta.TabIndex = 10
        '
        'Cbb_Banco
        '
        Me.Cbb_Banco.FormattingEnabled = True
        Me.Cbb_Banco.Location = New System.Drawing.Point(70, 28)
        Me.Cbb_Banco.Name = "Cbb_Banco"
        Me.Cbb_Banco.Size = New System.Drawing.Size(121, 21)
        Me.Cbb_Banco.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Referencia"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Sucursal"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Clave"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Cuenta"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Banco"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarCliente.Location = New System.Drawing.Point(488, 21)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(74, 28)
        Me.btnBuscarCliente.TabIndex = 55
        Me.btnBuscarCliente.Text = "Buscar"
        Me.btnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarCliente.UseVisualStyleBackColor = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Image = Global.SigaMetClasses.My.Resources.Resources.boton_guardar
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.Location = New System.Drawing.Point(488, 58)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(74, 28)
        Me.BtnGuardar.TabIndex = 56
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'frmAltaEditaCuentaBancariaCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 417)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.btnBuscarCliente)
        Me.Controls.Add(Me.GB_CuentaBancaria)
        Me.Controls.Add(Me.Gb_DatosCliente)
        Me.Name = "frmAltaEditaCuentaBancariaCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAltaEditaCuentaBancariaCliente"
        Me.Gb_DatosCliente.ResumeLayout(False)
        Me.Gb_DatosCliente.PerformLayout()
        Me.GB_CuentaBancaria.ResumeLayout(False)
        Me.GB_CuentaBancaria.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Gb_DatosCliente As Windows.Forms.GroupBox
    Friend WithEvents Txtb_Municipio As Windows.Forms.TextBox
    Friend WithEvents Txtb_Colonia As Windows.Forms.TextBox
    Friend WithEvents Txtb_calle As Windows.Forms.TextBox
    Friend WithEvents Txtb_Nombre As Windows.Forms.TextBox
    Friend WithEvents TxtBox_Ruta As Windows.Forms.TextBox
    Friend WithEvents lb_Ruta As Windows.Forms.Label
    Friend WithEvents TxtBox_Cliente As Windows.Forms.TextBox
    Friend WithEvents lb_Municipio As Windows.Forms.Label
    Friend WithEvents Lb_colonia As Windows.Forms.Label
    Friend WithEvents lb_Calle As Windows.Forms.Label
    Friend WithEvents lb_Nombre As Windows.Forms.Label
    Friend WithEvents lb_cliente As Windows.Forms.Label
    Friend WithEvents GB_CuentaBancaria As Windows.Forms.GroupBox
    Friend WithEvents Cbb_Estatus As Windows.Forms.ComboBox
    Friend WithEvents Lb_Estatus As Windows.Forms.Label
    Friend WithEvents Txtb_Referencia As Windows.Forms.TextBox
    Friend WithEvents Txtb_Sucursal As Windows.Forms.TextBox
    Friend WithEvents Txtb_Clave As Windows.Forms.TextBox
    Friend WithEvents Txtb_Ceunta As Windows.Forms.TextBox
    Friend WithEvents Cbb_Banco As Windows.Forms.ComboBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents btnBuscarCliente As Windows.Forms.Button
    Friend WithEvents BtnGuardar As Windows.Forms.Button
End Class

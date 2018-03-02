Imports System.Windows.Forms
Imports PortatilClasses


Public Class frmActaCierre
    Inherits System.Windows.Forms.Form

    Private _Operacion As Operaciones
    Private _Año, _Mes, _Folio As Integer
    Private _Corporativo, _Sucursal As Short
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSNomina As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboSEmpleado As PortatilClasses.Combo.ComboEmpleado
    Friend WithEvents txtSugerencia As System.Windows.Forms.TextBox

#Region "Operaciones"
    Public Enum Operaciones
        Alta = 1
        Cierre = 2
    End Enum
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Operacion As Operaciones)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _Operacion = Operacion
    End Sub

    Public Sub New(ByVal Año As Integer, ByVal Mes As Integer, ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal Folio As Integer, ByVal Operacion As Operaciones)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _Año = Año
        _Mes = Mes
        _Corporativo = Corporativo
        _Sucursal = Sucursal
        _Folio = Folio
        _Operacion = Operacion
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
    Friend WithEvents txtUNNomina As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents lblHDEmpleado As System.Windows.Forms.Label

    Friend WithEvents cboUNEmpleado As PortatilClasses.Combo.ComboEmpleado
    Friend WithEvents cboUSEmpleado As PortatilClasses.Combo.ComboEmpleado

    Friend WithEvents txtUSNomina As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents dtpFInventario As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtObservacionRC As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtObservacionRE As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtObservacionRP As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtObservacionGas As System.Windows.Forms.TextBox
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents cboSucursal As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmActaCierre))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.txtSNomina = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboSEmpleado = New PortatilClasses.Combo.ComboEmpleado()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSugerencia = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtObservacionRC = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtObservacionRE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtObservacionRP = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtObservacionGas = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.dtpFInventario = New System.Windows.Forms.DateTimePicker()
        Me.txtUSNomina = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboUSEmpleado = New PortatilClasses.Combo.ComboEmpleado()
        Me.txtUNNomina = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lblHDEmpleado = New System.Windows.Forms.Label()
        Me.cboUNEmpleado = New PortatilClasses.Combo.ComboEmpleado()
        Me.cboSucursal = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.grpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(544, 55)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 29
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(544, 23)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 28
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(32, 72)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(0, 13)
        Me.Label25.TabIndex = 90
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(32, 48)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(0, 13)
        Me.Label24.TabIndex = 89
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(32, 24)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(0, 13)
        Me.Label23.TabIndex = 88
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpDatos
        '
        Me.grpDatos.Controls.Add(Me.txtSNomina)
        Me.grpDatos.Controls.Add(Me.Label9)
        Me.grpDatos.Controls.Add(Me.cboSEmpleado)
        Me.grpDatos.Controls.Add(Me.Label10)
        Me.grpDatos.Controls.Add(Me.txtSugerencia)
        Me.grpDatos.Controls.Add(Me.Label8)
        Me.grpDatos.Controls.Add(Me.txtObservacionRC)
        Me.grpDatos.Controls.Add(Me.Label7)
        Me.grpDatos.Controls.Add(Me.txtObservacionRE)
        Me.grpDatos.Controls.Add(Me.Label6)
        Me.grpDatos.Controls.Add(Me.txtObservacionRP)
        Me.grpDatos.Controls.Add(Me.Label4)
        Me.grpDatos.Controls.Add(Me.txtObservacionGas)
        Me.grpDatos.Controls.Add(Me.Label3)
        Me.grpDatos.Controls.Add(Me.dtpFFinal)
        Me.grpDatos.Controls.Add(Me.Label2)
        Me.grpDatos.Controls.Add(Me.dtpFInicio)
        Me.grpDatos.Controls.Add(Me.Label44)
        Me.grpDatos.Controls.Add(Me.dtpFInventario)
        Me.grpDatos.Controls.Add(Me.txtUSNomina)
        Me.grpDatos.Controls.Add(Me.Label1)
        Me.grpDatos.Controls.Add(Me.cboUSEmpleado)
        Me.grpDatos.Controls.Add(Me.txtUNNomina)
        Me.grpDatos.Controls.Add(Me.lblHDEmpleado)
        Me.grpDatos.Controls.Add(Me.cboUNEmpleado)
        Me.grpDatos.Controls.Add(Me.cboSucursal)
        Me.grpDatos.Controls.Add(Me.Label5)
        Me.grpDatos.Location = New System.Drawing.Point(12, 12)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(526, 518)
        Me.grpDatos.TabIndex = 0
        Me.grpDatos.TabStop = False
        '
        'txtSNomina
        '
        Me.txtSNomina.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtSNomina.Location = New System.Drawing.Point(197, 110)
        Me.txtSNomina.MaxLength = 6
        Me.txtSNomina.Name = "txtSNomina"
        Me.txtSNomina.Size = New System.Drawing.Size(53, 20)
        Me.txtSNomina.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(9, 113)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(164, 26)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Empleado responsable sucursal:"
        '
        'cboSEmpleado
        '
        Me.cboSEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSEmpleado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboSEmpleado.ItemHeight = 13
        Me.cboSEmpleado.Location = New System.Drawing.Point(256, 110)
        Me.cboSEmpleado.Name = "cboSEmpleado"
        Me.cboSEmpleado.Size = New System.Drawing.Size(232, 21)
        Me.cboSEmpleado.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label10.Location = New System.Drawing.Point(9, 452)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Sugerencias:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSugerencia
        '
        Me.txtSugerencia.Location = New System.Drawing.Point(197, 449)
        Me.txtSugerencia.MaxLength = 500
        Me.txtSugerencia.Multiline = True
        Me.txtSugerencia.Name = "txtSugerencia"
        Me.txtSugerencia.Size = New System.Drawing.Size(291, 51)
        Me.txtSugerencia.TabIndex = 27
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label8.Location = New System.Drawing.Point(8, 395)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(180, 13)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Observación recipiente carburación:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtObservacionRC
        '
        Me.txtObservacionRC.Location = New System.Drawing.Point(197, 392)
        Me.txtObservacionRC.MaxLength = 500
        Me.txtObservacionRC.Multiline = True
        Me.txtObservacionRC.Name = "txtObservacionRC"
        Me.txtObservacionRC.Size = New System.Drawing.Size(291, 51)
        Me.txtObservacionRC.TabIndex = 25
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label7.Location = New System.Drawing.Point(9, 338)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(182, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Observación recipiente estacionario:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtObservacionRE
        '
        Me.txtObservacionRE.Location = New System.Drawing.Point(197, 335)
        Me.txtObservacionRE.MaxLength = 500
        Me.txtObservacionRE.Multiline = True
        Me.txtObservacionRE.Name = "txtObservacionRE"
        Me.txtObservacionRE.Size = New System.Drawing.Size(291, 51)
        Me.txtObservacionRE.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label6.Location = New System.Drawing.Point(9, 281)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(158, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Observación recipiente portátil:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtObservacionRP
        '
        Me.txtObservacionRP.Location = New System.Drawing.Point(197, 278)
        Me.txtObservacionRP.MaxLength = 500
        Me.txtObservacionRP.Multiline = True
        Me.txtObservacionRP.Name = "txtObservacionRP"
        Me.txtObservacionRP.Size = New System.Drawing.Size(291, 51)
        Me.txtObservacionRP.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label4.Location = New System.Drawing.Point(8, 224)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Observación gas:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtObservacionGas
        '
        Me.txtObservacionGas.Location = New System.Drawing.Point(197, 221)
        Me.txtObservacionGas.MaxLength = 500
        Me.txtObservacionGas.Multiline = True
        Me.txtObservacionGas.Name = "txtObservacionGas"
        Me.txtObservacionGas.Size = New System.Drawing.Size(291, 51)
        Me.txtObservacionGas.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(9, 199)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Fecha final:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFFinal
        '
        Me.dtpFFinal.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFFinal.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpFFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFFinal.Location = New System.Drawing.Point(197, 193)
        Me.dtpFFinal.Name = "dtpFFinal"
        Me.dtpFFinal.Size = New System.Drawing.Size(291, 20)
        Me.dtpFFinal.TabIndex = 17
        Me.dtpFFinal.Value = New Date(2004, 7, 1, 20, 34, 7, 497)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(9, 172)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Fecha inicial:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFInicio
        '
        Me.dtpFInicio.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFInicio.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpFInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFInicio.Location = New System.Drawing.Point(197, 166)
        Me.dtpFInicio.Name = "dtpFInicio"
        Me.dtpFInicio.Size = New System.Drawing.Size(291, 20)
        Me.dtpFInicio.TabIndex = 15
        Me.dtpFInicio.Value = New Date(2004, 7, 1, 20, 34, 7, 497)
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label44.Location = New System.Drawing.Point(9, 145)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(104, 13)
        Me.Label44.TabIndex = 12
        Me.Label44.Text = "Fecha inventario:"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFInventario
        '
        Me.dtpFInventario.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFInventario.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpFInventario.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFInventario.Location = New System.Drawing.Point(197, 139)
        Me.dtpFInventario.Name = "dtpFInventario"
        Me.dtpFInventario.Size = New System.Drawing.Size(291, 20)
        Me.dtpFInventario.TabIndex = 13
        Me.dtpFInventario.Value = New Date(2004, 7, 1, 20, 34, 7, 497)
        '
        'txtUSNomina
        '
        Me.txtUSNomina.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtUSNomina.Location = New System.Drawing.Point(197, 83)
        Me.txtUSNomina.MaxLength = 6
        Me.txtUSNomina.Name = "txtUSNomina"
        Me.txtUSNomina.Size = New System.Drawing.Size(53, 20)
        Me.txtUSNomina.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(9, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 26)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Empleado responsable unidad de servicio:"
        '
        'cboUSEmpleado
        '
        Me.cboUSEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUSEmpleado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboUSEmpleado.ItemHeight = 13
        Me.cboUSEmpleado.Location = New System.Drawing.Point(256, 83)
        Me.cboUSEmpleado.Name = "cboUSEmpleado"
        Me.cboUSEmpleado.Size = New System.Drawing.Size(232, 21)
        Me.cboUSEmpleado.TabIndex = 8
        '
        'txtUNNomina
        '
        Me.txtUNNomina.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtUNNomina.Location = New System.Drawing.Point(197, 49)
        Me.txtUNNomina.MaxLength = 6
        Me.txtUNNomina.Name = "txtUNNomina"
        Me.txtUNNomina.Size = New System.Drawing.Size(53, 20)
        Me.txtUNNomina.TabIndex = 4
        '
        'lblHDEmpleado
        '
        Me.lblHDEmpleado.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblHDEmpleado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHDEmpleado.Location = New System.Drawing.Point(9, 47)
        Me.lblHDEmpleado.Name = "lblHDEmpleado"
        Me.lblHDEmpleado.Size = New System.Drawing.Size(164, 34)
        Me.lblHDEmpleado.TabIndex = 3
        Me.lblHDEmpleado.Text = "Empleado responsable unidad de negocio:"
        '
        'cboUNEmpleado
        '
        Me.cboUNEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUNEmpleado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboUNEmpleado.ItemHeight = 13
        Me.cboUNEmpleado.Location = New System.Drawing.Point(256, 49)
        Me.cboUNEmpleado.Name = "cboUNEmpleado"
        Me.cboUNEmpleado.Size = New System.Drawing.Size(232, 21)
        Me.cboUNEmpleado.TabIndex = 5
        '
        'cboSucursal
        '
        Me.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursal.Location = New System.Drawing.Point(197, 16)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(291, 21)
        Me.cboSucursal.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(9, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Sucursal:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.DateTimePicker1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(178, 150)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(291, 21)
        Me.DateTimePicker1.TabIndex = 14
        Me.DateTimePicker1.Value = New Date(2004, 7, 1, 20, 34, 7, 497)
        '
        'frmActaCierre
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(631, 542)
        Me.Controls.Add(Me.grpDatos)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmActaCierre"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta de acta cierre"
        Me.grpDatos.ResumeLayout(False)
        Me.grpDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Manejo de la forma"

    Private Sub HabilitarAceptar()
        If cboSucursal.Text <> "" And txtUNNomina.Text <> "" And txtUSNomina.Text <> "" Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    Private Sub InterfazInicial()

        btnAceptar.Enabled = False

        If _Operacion = Operaciones.Alta Then

            dtpFInventario.Value = Now
            dtpFInicio.Value = Now

            ActiveControl = cboSucursal

            dtpFFinal.MinDate = dtpFInicio.Value
        Else
            cboSucursal.Enabled = False
            'cboUNEmpleado.Enabled = False
            'txtUNNomina.Enabled = False
            'cboUSEmpleado.Enabled = False
            'txtUSNomina.Enabled = False
            'cboSEmpleado.Enabled = False
            'txtSNomina.Enabled = False
            'dtpFInventario.Enabled = False
            'dtpFInicio.Enabled = False

            CargarDatosActaCierre()

            ActiveControl = dtpFFinal

        End If


    End Sub

#End Region

#Region "Manejo de datos"

    Private Sub CargarDatosActaCierre()
        Dim oConsultaActaCierre As New Consulta.cConsultaActaCierre(3, _Año, _Mes, _Corporativo, _Sucursal, _Folio, Now)
        If oConsultaActaCierre.dtTable.Rows.Count > 0 Then
            cboSucursal.PosicionaCombo(_Sucursal)
            txtUNNomina.Text = CType(oConsultaActaCierre.dtTable.Rows(0).Item(0), String)
            txtUNNomina_Leave(txtUNNomina, Nothing)
            txtUSNomina.Text = CType(oConsultaActaCierre.dtTable.Rows(0).Item(1), String)
            txtUSNomina_Leave(txtUSNomina, Nothing)
            If Not IsDBNull(oConsultaActaCierre.dtTable.Rows(0).Item(2)) Then
                txtSNomina.Text = CType(oConsultaActaCierre.dtTable.Rows(0).Item(2), String)
                txtSNomina_Leave(txtUSNomina, Nothing)
            End If
            dtpFInventario.Value = CType(oConsultaActaCierre.dtTable.Rows(0).Item(3), DateTime)
            dtpFInicio.Value = CType(oConsultaActaCierre.dtTable.Rows(0).Item(4), DateTime)
            dtpFFinal.Value = CType(oConsultaActaCierre.dtTable.Rows(0).Item(5), DateTime)
            txtObservacionGas.Text = CType(oConsultaActaCierre.dtTable.Rows(0).Item(6), String)
            txtObservacionRP.Text = CType(oConsultaActaCierre.dtTable.Rows(0).Item(7), String)
            txtObservacionRE.Text = CType(oConsultaActaCierre.dtTable.Rows(0).Item(8), String)
            txtObservacionRC.Text = CType(oConsultaActaCierre.dtTable.Rows(0).Item(9), String)
            txtSugerencia.Text = CType(oConsultaActaCierre.dtTable.Rows(0).Item(9), String)
        End If
    End Sub

    Private Sub CargarCboSucursal()
        Try
            cboSucursal.CargaDatosBase("spPTLCargaComboSucursal", 5, PortatilClasses.Globals.GetInstance._Usuario, _
                                               PortatilClasses.Globals.GetInstance._Corporativo, 0, 0)
            If cboSucursal.Items.Count > 0 Then
                cboSucursal.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarCboEmpleadoUN()
        Try
            cboUNEmpleado.CargaDatos(0)
            cboUNEmpleado.SelectedIndex = -1
            cboUNEmpleado.SelectedIndex = -1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarCboEmpleadoUS()
        Try
            cboUSEmpleado.CargaDatos(0)
            cboUSEmpleado.SelectedIndex = -1
            cboUSEmpleado.SelectedIndex = -1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CargarCboEmpleadoS()
        Try
            cboSEmpleado.CargaDatos(0)
            cboSEmpleado.SelectedIndex = -1
            cboSEmpleado.SelectedIndex = -1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Guardar()
        Try
            Dim oActaCierre As Registra.cActaCierre

            If _Operacion = Operaciones.Alta Then
                oActaCierre = New Registra.cActaCierre(0, dtpFInventario.Value.Year, dtpFInventario.Value.Month, PortatilClasses.Globals.GetInstance._Corporativo, _
                                  CType(cboSucursal.Identificador, Short), 0, CType(cboUNEmpleado.SelectedValue, Integer), _
                                  CType(cboUSEmpleado.SelectedValue, Integer), dtpFInventario.Value, dtpFInicio.Value, _
                                  dtpFFinal.Value, txtObservacionGas.Text, txtObservacionRP.Text, txtObservacionRE.Text, _
                                  txtObservacionRC.Text, txtSugerencia.Text, IIf(txtSNomina.Text <> "", CType(cboSEmpleado.SelectedValue, Integer), -1))
            Else
                oActaCierre = New Registra.cActaCierre(3, dtpFInventario.Value.Year, dtpFInventario.Value.Month, PortatilClasses.Globals.GetInstance._Corporativo, _
                                  CType(cboSucursal.Identificador, Short), _Folio, CType(cboUNEmpleado.SelectedValue, Integer), _
                                  CType(cboUSEmpleado.SelectedValue, Integer), dtpFInventario.Value, dtpFInicio.Value, _
                                  dtpFFinal.Value, txtObservacionGas.Text, txtObservacionRP.Text, txtObservacionRE.Text, _
                                  txtObservacionRC.Text, txtSugerencia.Text, IIf(txtSNomina.Text <> "", CType(cboSEmpleado.SelectedValue, Integer), -1))

                oActaCierre = New Registra.cActaCierre(4, dtpFInventario.Value.Year, dtpFInventario.Value.Month, PortatilClasses.Globals.GetInstance._Corporativo, _
                  CType(cboSucursal.Identificador, Short), _Folio, CType(cboUNEmpleado.SelectedValue, Integer), _
                  CType(cboUSEmpleado.SelectedValue, Integer), dtpFInventario.Value, dtpFInicio.Value, _
                  dtpFFinal.Value, txtObservacionGas.Text, txtObservacionRP.Text, txtObservacionRE.Text, _
                  txtObservacionRC.Text, txtSugerencia.Text, IIf(txtSNomina.Text <> "", CType(cboSEmpleado.SelectedValue, Integer), -1))

                oActaCierre = New Registra.cActaCierre(5, dtpFInventario.Value.Year, dtpFInventario.Value.Month, PortatilClasses.Globals.GetInstance._Corporativo, _
                  CType(cboSucursal.Identificador, Short), _Folio, CType(cboUNEmpleado.SelectedValue, Integer), _
                  CType(cboUSEmpleado.SelectedValue, Integer), dtpFInventario.Value, dtpFInicio.Value, _
                  dtpFFinal.Value, txtObservacionGas.Text, txtObservacionRP.Text, txtObservacionRE.Text, _
                  txtObservacionRC.Text, txtSugerencia.Text, IIf(txtSNomina.Text <> "", CType(cboSEmpleado.SelectedValue, Integer), -1))
            End If

            oActaCierre = Nothing

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Manejo de Controles"

    Private Sub frmControlDeRecipientes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Try
            CargarCboSucursal()
            CargarCboEmpleadoUN()
            CargarCboEmpleadoUS()
            CargarCboEmpleadoS()
            InterfazInicial()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboSucursal_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cboSucursal.KeyDown, cboUNEmpleado.KeyDown, cboUSEmpleado.KeyDown, cboSEmpleado.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub txtUNNomina_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtUNNomina.KeyDown, txtUSNomina.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub cboSucursal_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSucursal.SelectedIndexChanged, cboUNEmpleado.SelectedIndexChanged
        If cboSucursal.Focused Or cboUNEmpleado.Focused Or cboUSEmpleado.Focused Then
            HabilitarAceptar()
        End If
    End Sub

    Private Sub txtUNNomina_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtUNNomina.TextChanged, txtUSNomina.TextChanged, txtSNomina.TextChanged
        HabilitarAceptar()
    End Sub

    Private Sub txtUNNomina_Leave(sender As System.Object, e As System.EventArgs) Handles txtUNNomina.Leave
        If txtUNNomina.Text <> "" Then
            Dim Nomina As Integer
            Nomina = CType(txtUNNomina.Text, Integer)
            cboUNEmpleado.SelectedValue = Nomina
            If cboUNEmpleado.SelectedValue Is Nothing Then
                cboUNEmpleado.SelectedIndex = -1
                cboUNEmpleado.SelectedIndex = -1
                txtUNNomina.Text = ""
            End If
        Else
            cboUNEmpleado.SelectedIndex = -1
            cboUNEmpleado.SelectedIndex = -1
        End If
    End Sub

    Private Sub txtUSNomina_Leave(sender As System.Object, e As System.EventArgs) Handles txtUSNomina.Leave
        If txtUSNomina.Text <> "" Then
            Dim Nomina As Integer
            Nomina = CType(txtUSNomina.Text, Integer)
            cboUSEmpleado.SelectedValue = Nomina
            If cboUSEmpleado.SelectedValue Is Nothing Then
                cboUSEmpleado.SelectedIndex = -1
                cboUSEmpleado.SelectedIndex = -1
                txtUSNomina.Text = ""
            End If
        Else
            cboUSEmpleado.SelectedIndex = -1
            cboUSEmpleado.SelectedIndex = -1
        End If
    End Sub

    Private Sub cboUNEmpleado_Leave(sender As System.Object, e As System.EventArgs) Handles cboUNEmpleado.Leave
        If Not (cboUNEmpleado.SelectedValue Is Nothing) Then
            txtUNNomina.Text = CType(cboUNEmpleado.SelectedValue, String)
        Else
            txtUNNomina.Text = ""
        End If
    End Sub

    Private Sub cboUSEmpleado_Leave(sender As System.Object, e As System.EventArgs) Handles cboUSEmpleado.Leave
        If Not (cboUSEmpleado.SelectedValue Is Nothing) Then
            txtUSNomina.Text = CType(cboUSEmpleado.SelectedValue, String)
        Else
            txtUSNomina.Text = ""
        End If
    End Sub

    Private Sub dtpFMovimiento_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFInventario.KeyDown, dtpFInicio.KeyDown, dtpFFinal.KeyDown, txtObservacionGas.KeyDown, txtObservacionRP.KeyDown, txtObservacionRE.KeyDown, txtObservacionRC.KeyDown, txtSugerencia.KeyDown, DateTimePicker1.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    'Private Sub dtpFInicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFInicio.ValueChanged
    'dtpFFinal.MinDate = _dtpFInicio.Value
    'End Sub
    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Cursor = Cursors.WaitCursor
        Try
            'Variable para identificar si el resultado del proceso se realizo de manera satisfactoria
            Dim Resultado As Boolean = False
            Dim Result As DialogResult
            Dim Mensajes As Mensaje

            Mensajes = New Mensaje(4)
            Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (Result = DialogResult.Yes) Then
                If _Operacion = Operaciones.Alta Then
                    Dim oValidaFechaACierre As New Consulta.cConsultaActaCierre(4, PortatilClasses.Globals.GetInstance._Corporativo, cboSucursal.Identificador, dtpFInicio.Value)
                    If oValidaFechaACierre.dtTable.Rows.Count < 1 Then
                        Resultado = True
                    Else
                        Mensajes = New Mensaje(147)
                        MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        ActiveControl = dtpFFinal
                    End If
                Else
                    Resultado = True
                End If
            End If

            If (Resultado) Then
                Refresh()
                Guardar()
                btnAceptar.DialogResult() = DialogResult.OK
                Me.DialogResult() = DialogResult.OK
                Me.Close()
            End If

            'Dim oValidaFechaACierre As New Consulta.cConsultaActaCierre(4, PortatilClasses.Globals.GetInstance._Corporativo, cboSucursal.Identificador, dtpFInicio.Value)
            'If oValidaFechaACierre.dtTable.Rows.Count < 1 Then
            '    Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            '    If Result = DialogResult.Yes Then
            '        Refresh()
            '        Guardar()
            '        btnAceptar.DialogResult() = DialogResult.OK
            '        Me.DialogResult() = DialogResult.OK
            '        Me.Close()
            '    Else
            '        ActiveControl = IIf(_Operacion = Operaciones.Alta, cboSucursal, dtpFFinal)
            '    End If
            'Else
            '    MessageBox.Show("Ya existe un acta dentro de la fecha especificada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            'End If



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub frmActaCierre_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnAceptar.DialogResult() <> DialogResult.OK Then
            Dim Result As DialogResult
            Dim Mensajes As New Mensaje(28)
            Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

#End Region


    Private Sub dtpFInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFInicio.ValueChanged
        dtpFFinal.MinDate = dtpFInicio.Value
    End Sub

    Private Sub cboSEmpleado_Leave(sender As Object, e As EventArgs) Handles cboSEmpleado.Leave
        If Not (cboSEmpleado.SelectedValue Is Nothing) Then
            txtSNomina.Text = CType(cboSEmpleado.SelectedValue, String)
        Else
            txtSNomina.Text = ""
        End If
    End Sub

    Private Sub txtSNomina_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSNomina.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub txtSNomina_Leave(sender As Object, e As EventArgs) Handles txtSNomina.Leave
        If txtSNomina.Text <> "" Then
            Dim Nomina As Integer
            Nomina = CType(txtSNomina.Text, Integer)
            cboSEmpleado.SelectedValue = Nomina
            If cboSEmpleado.SelectedValue Is Nothing Then
                cboSEmpleado.SelectedIndex = -1
                cboSEmpleado.SelectedIndex = -1
                txtSNomina.Text = ""
            End If
        Else
            cboSEmpleado.SelectedIndex = -1
            cboSEmpleado.SelectedIndex = -1
        End If
    End Sub
End Class

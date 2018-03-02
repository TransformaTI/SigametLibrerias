Public Class frmInventarioFisicoManual
    Inherits System.Windows.Forms.Form

    Dim _InventarioFisico As Integer

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
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFInventario As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboSucursal As PortatilClasses.Combo.ComboBase
    Friend WithEvents lblDiferencia As System.Windows.Forms.Label
    Friend WithEvents lblKilos8 As System.Windows.Forms.Label
    Friend WithEvents txtFugas As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtObsequios As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtCarburacion As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtAutoCarburacion As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtPortatil As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtTraslado As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtInvInicial As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents lblKilos7 As System.Windows.Forms.Label
    Friend WithEvents lblKilos6 As System.Windows.Forms.Label
    Friend WithEvents lblKilos5 As System.Windows.Forms.Label
    Friend WithEvents lblKilos4 As System.Windows.Forms.Label
    Friend WithEvents lblKilos3 As System.Windows.Forms.Label
    Friend WithEvents lblKilos2 As System.Windows.Forms.Label
    Friend WithEvents lblKilos1 As System.Windows.Forms.Label
    Friend WithEvents label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblFAnterior As System.Windows.Forms.Label
    Friend WithEvents lblInvInicial As System.Windows.Forms.Label
    Friend WithEvents txtPlanta As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtEstacionario As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmInventarioFisicoManual))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.txtEstacionario = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPlanta = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblFAnterior = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblInvInicial = New System.Windows.Forms.Label()
        Me.cboSucursal = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblDiferencia = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblKilos8 = New System.Windows.Forms.Label()
        Me.label9 = New System.Windows.Forms.Label()
        Me.txtFugas = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtObsequios = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtCarburacion = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtAutoCarburacion = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtPortatil = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtTraslado = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtInvInicial = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.lblKilos7 = New System.Windows.Forms.Label()
        Me.lblKilos6 = New System.Windows.Forms.Label()
        Me.lblKilos5 = New System.Windows.Forms.Label()
        Me.lblKilos4 = New System.Windows.Forms.Label()
        Me.lblKilos3 = New System.Windows.Forms.Label()
        Me.lblKilos2 = New System.Windows.Forms.Label()
        Me.lblKilos1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFInventario = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(515, 21)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 11
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(515, 53)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpDatos
        '
        Me.grpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtEstacionario, Me.Label14, Me.Label15, Me.txtPlanta, Me.Label10, Me.Label11, Me.lblFAnterior, Me.Label8, Me.GroupBox1, Me.lblInvInicial, Me.cboSucursal, Me.Label21, Me.lblDiferencia, Me.Label19, Me.lblKilos8, Me.label9, Me.txtFugas, Me.txtObsequios, Me.txtCarburacion, Me.txtAutoCarburacion, Me.txtPortatil, Me.txtTraslado, Me.txtInvInicial, Me.lblKilos7, Me.lblKilos6, Me.lblKilos5, Me.lblKilos4, Me.lblKilos3, Me.lblKilos2, Me.lblKilos1, Me.Label5, Me.Label7, Me.Label4, Me.Label3, Me.Label2, Me.Label12, Me.Label13, Me.Label6, Me.dtpFInventario, Me.Label1})
        Me.grpDatos.Location = New System.Drawing.Point(11, 13)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(488, 467)
        Me.grpDatos.TabIndex = 15
        Me.grpDatos.TabStop = False
        '
        'txtEstacionario
        '
        Me.txtEstacionario.AutoSize = False
        Me.txtEstacionario.Location = New System.Drawing.Point(131, 272)
        Me.txtEstacionario.MaxLength = 12
        Me.txtEstacionario.Name = "txtEstacionario"
        Me.txtEstacionario.Size = New System.Drawing.Size(216, 21)
        Me.txtEstacionario.TabIndex = 6
        Me.txtEstacionario.Text = ""
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label14.Location = New System.Drawing.Point(372, 278)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 13)
        Me.Label14.TabIndex = 72
        Me.Label14.Text = "Kilos"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(16, 278)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(111, 13)
        Me.Label15.TabIndex = 71
        Me.Label15.Text = "Venta estacionario:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPlanta
        '
        Me.txtPlanta.AutoSize = False
        Me.txtPlanta.Location = New System.Drawing.Point(131, 244)
        Me.txtPlanta.MaxLength = 12
        Me.txtPlanta.Name = "txtPlanta"
        Me.txtPlanta.Size = New System.Drawing.Size(216, 21)
        Me.txtPlanta.TabIndex = 5
        Me.txtPlanta.Text = ""
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label10.Location = New System.Drawing.Point(372, 250)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 13)
        Me.Label10.TabIndex = 69
        Me.Label10.Text = "Kilos"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(16, 250)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 68
        Me.Label11.Text = "Venta planta:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFAnterior
        '
        Me.lblFAnterior.AutoSize = True
        Me.lblFAnterior.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblFAnterior.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblFAnterior.Location = New System.Drawing.Point(185, 128)
        Me.lblFAnterior.Name = "lblFAnterior"
        Me.lblFAnterior.Size = New System.Drawing.Size(36, 13)
        Me.lblFAnterior.TabIndex = 66
        Me.lblFAnterior.Text = "Fecha"
        Me.lblFAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label8.Location = New System.Drawing.Point(16, 128)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(162, 13)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "Movimientos del día anterior"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(1, 106)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(485, 8)
        Me.GroupBox1.TabIndex = 64
        Me.GroupBox1.TabStop = False
        '
        'lblInvInicial
        '
        Me.lblInvInicial.AutoSize = True
        Me.lblInvInicial.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblInvInicial.Location = New System.Drawing.Point(131, 162)
        Me.lblInvInicial.Name = "lblInvInicial"
        Me.lblInvInicial.Size = New System.Drawing.Size(28, 13)
        Me.lblInvInicial.TabIndex = 63
        Me.lblInvInicial.Text = "0.00"
        Me.lblInvInicial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSucursal
        '
        Me.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursal.Location = New System.Drawing.Point(131, 50)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(216, 21)
        Me.cboSucursal.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label21.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label21.Location = New System.Drawing.Point(372, 425)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(31, 13)
        Me.Label21.TabIndex = 62
        Me.Label21.Text = "Kilos"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDiferencia
        '
        Me.lblDiferencia.AutoSize = True
        Me.lblDiferencia.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblDiferencia.Location = New System.Drawing.Point(131, 425)
        Me.lblDiferencia.Name = "lblDiferencia"
        Me.lblDiferencia.Size = New System.Drawing.Size(28, 13)
        Me.lblDiferencia.TabIndex = 61
        Me.lblDiferencia.Text = "0.00"
        Me.lblDiferencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(19, 425)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 13)
        Me.Label19.TabIndex = 60
        Me.Label19.Text = "Diferencia:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKilos8
        '
        Me.lblKilos8.AutoSize = True
        Me.lblKilos8.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblKilos8.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblKilos8.Location = New System.Drawing.Point(372, 162)
        Me.lblKilos8.Name = "lblKilos8"
        Me.lblKilos8.Size = New System.Drawing.Size(31, 13)
        Me.lblKilos8.TabIndex = 58
        Me.lblKilos8.Text = "Kilos"
        Me.lblKilos8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.label9.Location = New System.Drawing.Point(16, 162)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(101, 13)
        Me.label9.TabIndex = 57
        Me.label9.Text = "Inv. inicial diario:"
        Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFugas
        '
        Me.txtFugas.AutoSize = False
        Me.txtFugas.Location = New System.Drawing.Point(131, 385)
        Me.txtFugas.MaxLength = 12
        Me.txtFugas.Name = "txtFugas"
        Me.txtFugas.Size = New System.Drawing.Size(216, 21)
        Me.txtFugas.TabIndex = 10
        Me.txtFugas.Text = ""
        '
        'txtObsequios
        '
        Me.txtObsequios.AutoSize = False
        Me.txtObsequios.Location = New System.Drawing.Point(131, 357)
        Me.txtObsequios.MaxLength = 12
        Me.txtObsequios.Name = "txtObsequios"
        Me.txtObsequios.Size = New System.Drawing.Size(216, 21)
        Me.txtObsequios.TabIndex = 9
        Me.txtObsequios.Text = ""
        '
        'txtCarburacion
        '
        Me.txtCarburacion.AutoSize = False
        Me.txtCarburacion.Location = New System.Drawing.Point(131, 329)
        Me.txtCarburacion.MaxLength = 12
        Me.txtCarburacion.Name = "txtCarburacion"
        Me.txtCarburacion.Size = New System.Drawing.Size(216, 21)
        Me.txtCarburacion.TabIndex = 8
        Me.txtCarburacion.Text = ""
        '
        'txtAutoCarburacion
        '
        Me.txtAutoCarburacion.AutoSize = False
        Me.txtAutoCarburacion.Location = New System.Drawing.Point(131, 301)
        Me.txtAutoCarburacion.MaxLength = 12
        Me.txtAutoCarburacion.Name = "txtAutoCarburacion"
        Me.txtAutoCarburacion.Size = New System.Drawing.Size(216, 21)
        Me.txtAutoCarburacion.TabIndex = 7
        Me.txtAutoCarburacion.Text = ""
        '
        'txtPortatil
        '
        Me.txtPortatil.AutoSize = False
        Me.txtPortatil.Location = New System.Drawing.Point(131, 216)
        Me.txtPortatil.MaxLength = 12
        Me.txtPortatil.Name = "txtPortatil"
        Me.txtPortatil.Size = New System.Drawing.Size(216, 21)
        Me.txtPortatil.TabIndex = 4
        Me.txtPortatil.Text = ""
        '
        'txtTraslado
        '
        Me.txtTraslado.AutoSize = False
        Me.txtTraslado.Location = New System.Drawing.Point(131, 188)
        Me.txtTraslado.MaxLength = 12
        Me.txtTraslado.Name = "txtTraslado"
        Me.txtTraslado.Size = New System.Drawing.Size(216, 21)
        Me.txtTraslado.TabIndex = 3
        Me.txtTraslado.Text = ""
        '
        'txtInvInicial
        '
        Me.txtInvInicial.AutoSize = False
        Me.txtInvInicial.Location = New System.Drawing.Point(131, 77)
        Me.txtInvInicial.MaxLength = 12
        Me.txtInvInicial.Name = "txtInvInicial"
        Me.txtInvInicial.Size = New System.Drawing.Size(216, 21)
        Me.txtInvInicial.TabIndex = 2
        Me.txtInvInicial.Text = ""
        '
        'lblKilos7
        '
        Me.lblKilos7.AutoSize = True
        Me.lblKilos7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblKilos7.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblKilos7.Location = New System.Drawing.Point(372, 393)
        Me.lblKilos7.Name = "lblKilos7"
        Me.lblKilos7.Size = New System.Drawing.Size(31, 13)
        Me.lblKilos7.TabIndex = 49
        Me.lblKilos7.Text = "Kilos"
        Me.lblKilos7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKilos6
        '
        Me.lblKilos6.AutoSize = True
        Me.lblKilos6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblKilos6.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblKilos6.Location = New System.Drawing.Point(372, 365)
        Me.lblKilos6.Name = "lblKilos6"
        Me.lblKilos6.Size = New System.Drawing.Size(31, 13)
        Me.lblKilos6.TabIndex = 48
        Me.lblKilos6.Text = "Kilos"
        Me.lblKilos6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKilos5
        '
        Me.lblKilos5.AutoSize = True
        Me.lblKilos5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblKilos5.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblKilos5.Location = New System.Drawing.Point(372, 337)
        Me.lblKilos5.Name = "lblKilos5"
        Me.lblKilos5.Size = New System.Drawing.Size(31, 13)
        Me.lblKilos5.TabIndex = 47
        Me.lblKilos5.Text = "Kilos"
        Me.lblKilos5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKilos4
        '
        Me.lblKilos4.AutoSize = True
        Me.lblKilos4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblKilos4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblKilos4.Location = New System.Drawing.Point(372, 309)
        Me.lblKilos4.Name = "lblKilos4"
        Me.lblKilos4.Size = New System.Drawing.Size(31, 13)
        Me.lblKilos4.TabIndex = 46
        Me.lblKilos4.Text = "Kilos"
        Me.lblKilos4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKilos3
        '
        Me.lblKilos3.AutoSize = True
        Me.lblKilos3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblKilos3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblKilos3.Location = New System.Drawing.Point(372, 224)
        Me.lblKilos3.Name = "lblKilos3"
        Me.lblKilos3.Size = New System.Drawing.Size(31, 13)
        Me.lblKilos3.TabIndex = 45
        Me.lblKilos3.Text = "Kilos"
        Me.lblKilos3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKilos2
        '
        Me.lblKilos2.AutoSize = True
        Me.lblKilos2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblKilos2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblKilos2.Location = New System.Drawing.Point(372, 194)
        Me.lblKilos2.Name = "lblKilos2"
        Me.lblKilos2.Size = New System.Drawing.Size(31, 13)
        Me.lblKilos2.TabIndex = 44
        Me.lblKilos2.Text = "Kilos"
        Me.lblKilos2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKilos1
        '
        Me.lblKilos1.AutoSize = True
        Me.lblKilos1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblKilos1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblKilos1.Location = New System.Drawing.Point(372, 83)
        Me.lblKilos1.Name = "lblKilos1"
        Me.lblKilos1.Size = New System.Drawing.Size(31, 13)
        Me.lblKilos1.TabIndex = 43
        Me.lblKilos1.Text = "Kilos"
        Me.lblKilos1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(18, 363)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Obsequios:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(19, 391)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 13)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Fugas:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(16, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Entrada traslado:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(16, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Sucursal:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(16, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Fecha inventario:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(16, 222)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Venta portátil:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(16, 83)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 13)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Inv. inicial diario:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(16, 307)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Autocarburación:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFInventario
        '
        Me.dtpFInventario.CustomFormat = ""
        Me.dtpFInventario.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFInventario.Location = New System.Drawing.Point(131, 24)
        Me.dtpFInventario.Name = "dtpFInventario"
        Me.dtpFInventario.Size = New System.Drawing.Size(216, 21)
        Me.dtpFInventario.TabIndex = 0
        Me.dtpFInventario.Value = New Date(2009, 3, 10, 10, 4, 5, 720)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(17, 335)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Venta carburación:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmInventarioFisicoManual
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(600, 496)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAceptar, Me.btnCancelar, Me.grpDatos})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInventarioFisicoManual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario físico manual"
        Me.grpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Limpiar()
        _InventarioFisico = 0
        txtInvInicial.Clear()
        txtAutoCarburacion.Clear()
        txtCarburacion.Clear()
        txtFugas.Clear()
        txtObsequios.Clear()
        txtPortatil.Clear()
        txtTraslado.Clear()
        txtPlanta.Clear()
        txtEstacionario.Clear()
        lblInvInicial.Text = "0.00"
        lblDiferencia.Text = "0.00"
    End Sub

    Private Sub HabilitarAceptar()
        If cboSucursal.Text <> "" And txtInvInicial.Text <> "" And txtAutoCarburacion.Text <> "" _
        And txtCarburacion.Text <> "" And txtFugas.Text <> "" And txtObsequios.Text <> "" _
        And txtPortatil.Text <> "" And txtTraslado.Text <> "" And txtPlanta.Text <> "" _
        And txtEstacionario.Text <> "" Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    Private Sub RegistrarInventario()
        Dim Configuracion As Short = 0
        If _InventarioFisico > 0 Then
            Configuracion = 1
        End If
        Dim oInventario As New PortatilClasses.Consulta.cInventarioFisicoManual(Configuracion)
        oInventario.Registrar(_InventarioFisico, dtpFInventario.Value, CType(cboSucursal.Identificador, Short), _
                              CType(txtInvInicial.Text, Decimal), CType(txtTraslado.Text, Decimal), _
                              CType(txtPortatil.Text, Decimal), CType(txtAutoCarburacion.Text, Decimal), _
                              CType(txtCarburacion.Text, Decimal), CType(txtObsequios.Text, Decimal), _
                              CType(txtFugas.Text, Decimal), GLOBAL_Usuario, CType(txtPlanta.Text, Decimal), CType(txtEstacionario.Text, Decimal))
        cboSucursal.SelectedIndex = -1
    End Sub

    Private Sub frmInventarioFisicoManual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFInventario.Value = Now
        dtpFInventario.MaxDate = Now.Date
        lblFAnterior.Text = CType(dtpFInventario.Value.Date.AddDays(-1), String)
        btnAceptar.Enabled = False
        cboSucursal.CargaDatosBase("spPTLCargaComboSucursal", 3, GLOBAL_Usuario, 0, 0, 0)
        ActiveControl = dtpFInventario
    End Sub

    Private Sub txtInvInicial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInvInicial.KeyDown, txtAutoCarburacion.KeyDown, txtCarburacion.KeyDown, txtFugas.KeyDown, txtObsequios.KeyDown, txtPortatil.KeyDown, txtTraslado.KeyDown, txtPlanta.KeyDown, txtEstacionario.KeyDown
        If e.KeyData = Keys.Enter Or e.KeyData = Keys.Down Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    Private Sub dtpFInventario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles dtpFInventario.KeyDown, cboSucursal.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub txtInvInicial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvInicial.TextChanged, txtAutoCarburacion.TextChanged, txtCarburacion.TextChanged, txtFugas.TextChanged, txtObsequios.TextChanged, txtPortatil.TextChanged, txtTraslado.TextChanged
        HabilitarAceptar()
    End Sub

    Private Sub cboSucursal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSucursal.SelectedIndexChanged
        If cboSucursal.Focused Then
            If cboSucursal.Text <> "" Then
                Limpiar()
                Dim oExisteInventario As New PortatilClasses.Consulta.cExisteInventarioFisico()
                oExisteInventario.Existe(dtpFInventario.Value, CType(cboSucursal.Identificador, Short))
                If oExisteInventario.drAlmacen.Read() Then
                    'Dim Mensajes As New PortatilClasses.Mensaje(98, CType(dtpFInventario.Value.Date, String))
                    'MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ''ActiveControl = dtpFInventario
                    _InventarioFisico = CType(oExisteInventario.drAlmacen(0), Integer)
                    lblInvInicial.Text = CType(oExisteInventario.drAlmacen(2), String)
                    If Not IsDBNull(oExisteInventario.drAlmacen(1)) Then
                        txtInvInicial.Text = CType(oExisteInventario.drAlmacen(1), String)
                    End If
                    If Not IsDBNull(oExisteInventario.drAlmacen(3)) Then
                        lblDiferencia.Text = CType(oExisteInventario.drAlmacen(3), String)
                    End If
                    If Not IsDBNull(oExisteInventario.drAlmacen(4)) Then
                        txtTraslado.Text = CType(oExisteInventario.drAlmacen(4), String)
                    End If
                    If Not IsDBNull(oExisteInventario.drAlmacen(5)) Then
                        txtPortatil.Text = CType(oExisteInventario.drAlmacen(5), String)
                    End If
                    If Not IsDBNull(oExisteInventario.drAlmacen(6)) Then
                        txtAutoCarburacion.Text = CType(oExisteInventario.drAlmacen(6), String)
                    End If
                    If Not IsDBNull(oExisteInventario.drAlmacen(7)) Then
                        txtCarburacion.Text = CType(oExisteInventario.drAlmacen(7), String)
                    End If
                    If Not IsDBNull(oExisteInventario.drAlmacen(8)) Then
                        txtObsequios.Text = CType(oExisteInventario.drAlmacen(8), String)
                    End If
                    If Not IsDBNull(oExisteInventario.drAlmacen(9)) Then
                        txtFugas.Text = CType(oExisteInventario.drAlmacen(9), String)
                    End If
                    If Not IsDBNull(oExisteInventario.drAlmacen(10)) Then
                        txtEstacionario.Text = CType(oExisteInventario.drAlmacen(10), String)
                    End If
                    If Not IsDBNull(oExisteInventario.drAlmacen(11)) Then
                        txtPlanta.Text = CType(oExisteInventario.drAlmacen(11), String)
                    End If
                    lblFAnterior.Text = CType(dtpFInventario.Value.Date, String)
                    lblFAnterior.Text = CType(CType(lblFAnterior.Text, Date).AddDays(-1), String)
                Else
                    Limpiar()
                End If
                oExisteInventario.CerrarConexion()
            End If

        End If
    End Sub

    Private Sub dtpFInventario_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFInventario.TextChanged
        If cboSucursal.Text <> "" Then
            Limpiar()
            Dim oExisteInventario As New PortatilClasses.Consulta.cExisteInventarioFisico()
            oExisteInventario.Existe(dtpFInventario.Value, CType(cboSucursal.Identificador, Short))
            If oExisteInventario.drAlmacen.Read() Then
                'Dim Mensajes As New PortatilClasses.Mensaje(98, CType(dtpFInventario.Value.Date, String))
                'MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'ActiveControl = dtpFInventario
                _InventarioFisico = CType(oExisteInventario.drAlmacen(0), Integer)
                lblInvInicial.Text = CType(oExisteInventario.drAlmacen(2), String)
                If Not IsDBNull(oExisteInventario.drAlmacen(1)) Then
                    txtInvInicial.Text = CType(oExisteInventario.drAlmacen(1), String)
                End If
                If Not IsDBNull(oExisteInventario.drAlmacen(3)) Then
                    lblDiferencia.Text = CType(oExisteInventario.drAlmacen(3), String)
                End If
                If Not IsDBNull(oExisteInventario.drAlmacen(4)) Then
                    txtTraslado.Text = CType(oExisteInventario.drAlmacen(4), String)
                End If
                If Not IsDBNull(oExisteInventario.drAlmacen(5)) Then
                    txtPortatil.Text = CType(oExisteInventario.drAlmacen(5), String)
                End If
                If Not IsDBNull(oExisteInventario.drAlmacen(6)) Then
                    txtAutoCarburacion.Text = CType(oExisteInventario.drAlmacen(6), String)
                End If
                If Not IsDBNull(oExisteInventario.drAlmacen(7)) Then
                    txtCarburacion.Text = CType(oExisteInventario.drAlmacen(7), String)
                End If
                If Not IsDBNull(oExisteInventario.drAlmacen(8)) Then
                    txtObsequios.Text = CType(oExisteInventario.drAlmacen(8), String)
                End If
                If Not IsDBNull(oExisteInventario.drAlmacen(9)) Then
                    txtFugas.Text = CType(oExisteInventario.drAlmacen(9), String)
                End If
                If Not IsDBNull(oExisteInventario.drAlmacen(10)) Then
                    txtEstacionario.Text = CType(oExisteInventario.drAlmacen(10), String)
                End If
                If Not IsDBNull(oExisteInventario.drAlmacen(11)) Then
                    txtPlanta.Text = CType(oExisteInventario.drAlmacen(11), String)
                End If
                lblFAnterior.Text = CType(dtpFInventario.Value.Date, String)
                lblFAnterior.Text = CType(CType(lblFAnterior.Text, Date).AddDays(-1), String)
            Else
                Limpiar()
            End If
            oExisteInventario.CerrarConexion()
        End If

    End Sub

    Private Sub lblDiferencia_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblDiferencia.TextChanged
        If CType(lblDiferencia.Text, Decimal) < 0 Then
            lblDiferencia.ForeColor = Drawing.Color.Red            
        Else
            lblDiferencia.ForeColor = Drawing.Color.Blue
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, "Inventario manual", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            RegistrarInventario()
            Limpiar()
        End If
    End Sub

End Class

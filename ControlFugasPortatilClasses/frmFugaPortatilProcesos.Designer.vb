<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFugaPortatilProcesos
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFugaPortatilProcesos))
        Me.grbInformacion = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblTotalClientes = New System.Windows.Forms.Label()
        Me.dgProducto = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.lblNuevos = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblAtendidos = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblComprobante = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtComentarioAtencion = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblSeguimiento = New System.Windows.Forms.Label()
        Me.txtCantidadKilos = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.dtpFInicioSupresion = New System.Windows.Forms.DateTimePicker()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtpFFinSupresion = New System.Windows.Forms.DateTimePicker()
        Me.CboArea = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label24 = New System.Windows.Forms.Label()
        Me.CboTipoAtencionFuga = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.CboRuta = New PortatilClasses.Combo.ComboRutaPtl()
        Me.CboAreaEmpleado = New PortatilClasses.Combo.ComboRutaPtl()
        Me.dtpFAtencion = New System.Windows.Forms.DateTimePicker()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.lblFRegistrado = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.CboTipoFuga = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblComentario = New System.Windows.Forms.Label()
        Me.CboSucursalPermiso = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnHistorico = New System.Windows.Forms.Button()
        Me.lblFVenta = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblReferencia2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblReferencia1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTelefono2 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblTelefono1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblCiudad = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblColonia = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblCalle = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblEtqColorBlack = New System.Windows.Forms.Label()
        Me.lblEtqColorGreen = New System.Windows.Forms.Label()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.cboSucursalFiltrado = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFFinal = New System.Windows.Forms.DateTimePicker()
        Me.cboRutaFiltrado = New PortatilClasses.Combo.ComboRutaPtl()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnRadiado = New System.Windows.Forms.Button()
        Me.btnSeguimiento = New System.Windows.Forms.Button()
        Me.btnAtendido = New System.Windows.Forms.Button()
        Me.cboAreaFiltrado = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label25 = New System.Windows.Forms.Label()
        Me.grbInformacion.SuspendLayout()
        CType(Me.dgProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbInformacion
        '
        Me.grbInformacion.Controls.Add(Me.Label18)
        Me.grbInformacion.Controls.Add(Me.lblTotalClientes)
        Me.grbInformacion.Controls.Add(Me.dgProducto)
        Me.grbInformacion.Controls.Add(Me.lblNuevos)
        Me.grbInformacion.Controls.Add(Me.Label16)
        Me.grbInformacion.Controls.Add(Me.lblAtendidos)
        Me.grbInformacion.Controls.Add(Me.Label20)
        Me.grbInformacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbInformacion.Location = New System.Drawing.Point(12, 75)
        Me.grbInformacion.Name = "grbInformacion"
        Me.grbInformacion.Size = New System.Drawing.Size(354, 428)
        Me.grbInformacion.TabIndex = 0
        Me.grbInformacion.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(9, 369)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(99, 16)
        Me.Label18.TabIndex = 12
        Me.Label18.Text = "Total clientes:"
        '
        'lblTotalClientes
        '
        Me.lblTotalClientes.AutoSize = True
        Me.lblTotalClientes.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalClientes.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalClientes.Location = New System.Drawing.Point(109, 369)
        Me.lblTotalClientes.Name = "lblTotalClientes"
        Me.lblTotalClientes.Size = New System.Drawing.Size(110, 16)
        Me.lblTotalClientes.TabIndex = 13
        Me.lblTotalClientes.Text = "lblTotalClientes:"
        '
        'dgProducto
        '
        Me.dgProducto.AccessibleName = ""
        Me.dgProducto.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgProducto.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.dgProducto.CaptionText = "Fugas portatiles"
        Me.dgProducto.DataMember = ""
        Me.dgProducto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgProducto.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgProducto.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgProducto.Location = New System.Drawing.Point(0, 20)
        Me.dgProducto.Name = "dgProducto"
        Me.dgProducto.ReadOnly = True
        Me.dgProducto.Size = New System.Drawing.Size(354, 346)
        Me.dgProducto.TabIndex = 11
        Me.dgProducto.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.dgProducto.TabStop = False
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.dgProducto
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.MappingName = "Año"
        Me.DataGridTextBoxColumn1.Width = 0
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Folio"
        Me.DataGridTextBoxColumn2.MappingName = "Folio"
        Me.DataGridTextBoxColumn2.Width = 85
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.MappingName = "ClientePortatil"
        Me.DataGridTextBoxColumn3.Width = 0
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Cliente"
        Me.DataGridTextBoxColumn4.MappingName = "Nombre"
        Me.DataGridTextBoxColumn4.Width = 250
        '
        'lblNuevos
        '
        Me.lblNuevos.AutoSize = True
        Me.lblNuevos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNuevos.ForeColor = System.Drawing.Color.Blue
        Me.lblNuevos.Location = New System.Drawing.Point(109, 389)
        Me.lblNuevos.Name = "lblNuevos"
        Me.lblNuevos.Size = New System.Drawing.Size(64, 13)
        Me.lblNuevos.TabIndex = 15
        Me.lblNuevos.Text = "lblNuevos:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(9, 389)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 13)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Nuevos:"
        '
        'lblAtendidos
        '
        Me.lblAtendidos.AutoSize = True
        Me.lblAtendidos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAtendidos.ForeColor = System.Drawing.Color.Blue
        Me.lblAtendidos.Location = New System.Drawing.Point(109, 409)
        Me.lblAtendidos.Name = "lblAtendidos"
        Me.lblAtendidos.Size = New System.Drawing.Size(80, 13)
        Me.lblAtendidos.TabIndex = 17
        Me.lblAtendidos.Text = "lblAtendidos:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(9, 409)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(67, 13)
        Me.Label20.TabIndex = 16
        Me.Label20.Text = "Atendidos:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblComprobante)
        Me.GroupBox1.Controls.Add(Me.Label36)
        Me.GroupBox1.Controls.Add(Me.txtComentario)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.txtComentarioAtencion)
        Me.GroupBox1.Controls.Add(Me.Label35)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.lblSeguimiento)
        Me.GroupBox1.Controls.Add(Me.txtCantidadKilos)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.dtpFInicioSupresion)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.dtpFFinSupresion)
        Me.GroupBox1.Controls.Add(Me.CboArea)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.CboTipoAtencionFuga)
        Me.GroupBox1.Controls.Add(Me.CboRuta)
        Me.GroupBox1.Controls.Add(Me.CboAreaEmpleado)
        Me.GroupBox1.Controls.Add(Me.dtpFAtencion)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.lblFRegistrado)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.CboTipoFuga)
        Me.GroupBox1.Controls.Add(Me.lblEstatus)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.lblComentario)
        Me.GroupBox1.Controls.Add(Me.CboSucursalPermiso)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.btnHistorico)
        Me.GroupBox1.Controls.Add(Me.lblFVenta)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.lblReferencia2)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.lblReferencia1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lblTelefono2)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.lblTelefono1)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblCiudad)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblColonia)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblCalle)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(366, 75)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(580, 428)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lblComprobante
        '
        Me.lblComprobante.AutoSize = True
        Me.lblComprobante.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComprobante.ForeColor = System.Drawing.Color.Blue
        Me.lblComprobante.Location = New System.Drawing.Point(121, 135)
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Size = New System.Drawing.Size(100, 13)
        Me.lblComprobante.TabIndex = 67
        Me.lblComprobante.Text = "lblComprobante:"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(9, 135)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(76, 13)
        Me.Label36.TabIndex = 66
        Me.Label36.Text = "Comprobante:"
        '
        'txtComentario
        '
        Me.txtComentario.Location = New System.Drawing.Point(121, 393)
        Me.txtComentario.MaxLength = 250
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(443, 21)
        Me.txtComentario.TabIndex = 65
        Me.txtComentario.Text = "TxtString1"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(9, 397)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(76, 13)
        Me.Label23.TabIndex = 64
        Me.Label23.Text = "Comentario:"
        '
        'txtComentarioAtencion
        '
        Me.txtComentarioAtencion.Location = New System.Drawing.Point(121, 339)
        Me.txtComentarioAtencion.MaxLength = 250
        Me.txtComentarioAtencion.Name = "txtComentarioAtencion"
        Me.txtComentarioAtencion.Size = New System.Drawing.Size(444, 21)
        Me.txtComentarioAtencion.TabIndex = 59
        Me.txtComentarioAtencion.Text = "TxtString1"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label35.Location = New System.Drawing.Point(9, 343)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(109, 13)
        Me.Label35.TabIndex = 58
        Me.Label35.Text = "Coment. atención:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(0, 215)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(580, 8)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'lblSeguimiento
        '
        Me.lblSeguimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeguimiento.ForeColor = System.Drawing.Color.Blue
        Me.lblSeguimiento.Location = New System.Drawing.Point(393, 195)
        Me.lblSeguimiento.Name = "lblSeguimiento"
        Me.lblSeguimiento.Size = New System.Drawing.Size(87, 13)
        Me.lblSeguimiento.TabIndex = 40
        Me.lblSeguimiento.Text = "lblSeguimiento:"
        '
        'txtCantidadKilos
        '
        Me.txtCantidadKilos.Location = New System.Drawing.Point(393, 312)
        Me.txtCantidadKilos.MaxLength = 5
        Me.txtCantidadKilos.Name = "txtCantidadKilos"
        Me.txtCantidadKilos.Size = New System.Drawing.Size(171, 21)
        Me.txtCantidadKilos.TabIndex = 57
        Me.txtCantidadKilos.Text = "txtCantidad1"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label30.Location = New System.Drawing.Point(302, 316)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(83, 13)
        Me.Label30.TabIndex = 56
        Me.Label30.Text = "Kilos reposición:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label31.Location = New System.Drawing.Point(302, 289)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(72, 13)
        Me.Label31.TabIndex = 52
        Me.Label31.Text = "Fin atendió:"
        '
        'dtpFInicioSupresion
        '
        Me.dtpFInicioSupresion.AllowDrop = True
        Me.dtpFInicioSupresion.CustomFormat = "dd-MM-yyyy hh:mm:ss"
        Me.dtpFInicioSupresion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFInicioSupresion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFInicioSupresion.Location = New System.Drawing.Point(121, 285)
        Me.dtpFInicioSupresion.Name = "dtpFInicioSupresion"
        Me.dtpFInicioSupresion.Size = New System.Drawing.Size(171, 21)
        Me.dtpFInicioSupresion.TabIndex = 51
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label21.Location = New System.Drawing.Point(302, 235)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(79, 13)
        Me.Label21.TabIndex = 44
        Me.Label21.Text = "Emp. atend. :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label12.Location = New System.Drawing.Point(302, 370)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 13)
        Me.Label12.TabIndex = 62
        Me.Label12.Text = "Ruta:"
        '
        'dtpFFinSupresion
        '
        Me.dtpFFinSupresion.AllowDrop = True
        Me.dtpFFinSupresion.CustomFormat = "dd-MM-yyyy hh:mm:ss"
        Me.dtpFFinSupresion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFFinSupresion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFFinSupresion.Location = New System.Drawing.Point(393, 285)
        Me.dtpFFinSupresion.Name = "dtpFFinSupresion"
        Me.dtpFFinSupresion.Size = New System.Drawing.Size(171, 21)
        Me.dtpFFinSupresion.TabIndex = 53
        '
        'CboArea
        '
        Me.CboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboArea.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboArea.Location = New System.Drawing.Point(121, 366)
        Me.CboArea.Name = "CboArea"
        Me.CboArea.Size = New System.Drawing.Size(173, 21)
        Me.CboArea.TabIndex = 61
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label24.Location = New System.Drawing.Point(9, 289)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(91, 13)
        Me.Label24.TabIndex = 50
        Me.Label24.Text = "Incio atendido:"
        '
        'CboTipoAtencionFuga
        '
        Me.CboTipoAtencionFuga.AllowDrop = True
        Me.CboTipoAtencionFuga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoAtencionFuga.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoAtencionFuga.Location = New System.Drawing.Point(393, 258)
        Me.CboTipoAtencionFuga.Name = "CboTipoAtencionFuga"
        Me.CboTipoAtencionFuga.Size = New System.Drawing.Size(171, 21)
        Me.CboTipoAtencionFuga.TabIndex = 49
        '
        'CboRuta
        '
        Me.CboRuta.AllowDrop = True
        Me.CboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboRuta.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboRuta.Location = New System.Drawing.Point(393, 366)
        Me.CboRuta.Name = "CboRuta"
        Me.CboRuta.Size = New System.Drawing.Size(171, 21)
        Me.CboRuta.TabIndex = 63
        '
        'CboAreaEmpleado
        '
        Me.CboAreaEmpleado.AllowDrop = True
        Me.CboAreaEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAreaEmpleado.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboAreaEmpleado.Location = New System.Drawing.Point(393, 231)
        Me.CboAreaEmpleado.Name = "CboAreaEmpleado"
        Me.CboAreaEmpleado.Size = New System.Drawing.Size(171, 21)
        Me.CboAreaEmpleado.TabIndex = 45
        '
        'dtpFAtencion
        '
        Me.dtpFAtencion.AllowDrop = True
        Me.dtpFAtencion.CustomFormat = "dd-MM-yyyy hh:mm:ss"
        Me.dtpFAtencion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFAtencion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFAtencion.Location = New System.Drawing.Point(121, 312)
        Me.dtpFAtencion.Name = "dtpFAtencion"
        Me.dtpFAtencion.Size = New System.Drawing.Size(171, 21)
        Me.dtpFAtencion.TabIndex = 55
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label28.Location = New System.Drawing.Point(302, 262)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(86, 13)
        Me.Label28.TabIndex = 48
        Me.Label28.Text = "Tipo atención:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label22.Location = New System.Drawing.Point(9, 316)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(95, 13)
        Me.Label22.TabIndex = 54
        Me.Label22.Text = "Fecha atención:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label19.Location = New System.Drawing.Point(9, 370)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(37, 13)
        Me.Label19.TabIndex = 60
        Me.Label19.Text = "Área:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label29.Location = New System.Drawing.Point(9, 262)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(62, 13)
        Me.Label29.TabIndex = 46
        Me.Label29.Text = "Tipo fuga:"
        '
        'lblFRegistrado
        '
        Me.lblFRegistrado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFRegistrado.ForeColor = System.Drawing.Color.Blue
        Me.lblFRegistrado.Location = New System.Drawing.Point(121, 115)
        Me.lblFRegistrado.Name = "lblFRegistrado"
        Me.lblFRegistrado.Size = New System.Drawing.Size(172, 13)
        Me.lblFRegistrado.TabIndex = 33
        Me.lblFRegistrado.Text = "lblFRegistrado:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(9, 115)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(92, 13)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "Fecha registrado:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label27.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label27.Location = New System.Drawing.Point(9, 235)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(107, 13)
        Me.Label27.TabIndex = 42
        Me.Label27.Text = "Sucursal permiso:"
        '
        'CboTipoFuga
        '
        Me.CboTipoFuga.AllowDrop = True
        Me.CboTipoFuga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoFuga.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoFuga.Location = New System.Drawing.Point(121, 258)
        Me.CboTipoFuga.Name = "CboTipoFuga"
        Me.CboTipoFuga.Size = New System.Drawing.Size(171, 21)
        Me.CboTipoFuga.TabIndex = 47
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatus.ForeColor = System.Drawing.Color.Blue
        Me.lblEstatus.Location = New System.Drawing.Point(121, 195)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(65, 13)
        Me.lblEstatus.TabIndex = 39
        Me.lblEstatus.Text = "lblEstatus:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(9, 195)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(47, 13)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "Estatus:"
        '
        'lblComentario
        '
        Me.lblComentario.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComentario.ForeColor = System.Drawing.Color.Blue
        Me.lblComentario.Location = New System.Drawing.Point(121, 155)
        Me.lblComentario.Name = "lblComentario"
        Me.lblComentario.Size = New System.Drawing.Size(441, 36)
        Me.lblComentario.TabIndex = 37
        Me.lblComentario.Text = "lblComentario:"
        '
        'CboSucursalPermiso
        '
        Me.CboSucursalPermiso.AllowDrop = True
        Me.CboSucursalPermiso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSucursalPermiso.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboSucursalPermiso.Location = New System.Drawing.Point(121, 231)
        Me.CboSucursalPermiso.Name = "CboSucursalPermiso"
        Me.CboSucursalPermiso.Size = New System.Drawing.Size(171, 21)
        Me.CboSucursalPermiso.TabIndex = 43
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(9, 155)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(94, 13)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "Comentario inicial:"
        '
        'btnHistorico
        '
        Me.btnHistorico.BackColor = System.Drawing.SystemColors.Control
        Me.btnHistorico.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHistorico.Image = CType(resources.GetObject("btnHistorico.Image"), System.Drawing.Image)
        Me.btnHistorico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHistorico.Location = New System.Drawing.Point(491, 191)
        Me.btnHistorico.Name = "btnHistorico"
        Me.btnHistorico.Size = New System.Drawing.Size(75, 23)
        Me.btnHistorico.TabIndex = 41
        Me.btnHistorico.TabStop = False
        Me.btnHistorico.Text = "&Historico"
        Me.btnHistorico.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHistorico.UseVisualStyleBackColor = False
        '
        'lblFVenta
        '
        Me.lblFVenta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFVenta.ForeColor = System.Drawing.Color.Blue
        Me.lblFVenta.Location = New System.Drawing.Point(393, 115)
        Me.lblFVenta.Name = "lblFVenta"
        Me.lblFVenta.Size = New System.Drawing.Size(169, 13)
        Me.lblFVenta.TabIndex = 35
        Me.lblFVenta.Text = "lblFVenta:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(302, 115)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 13)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Fecha venta:"
        '
        'lblReferencia2
        '
        Me.lblReferencia2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReferencia2.ForeColor = System.Drawing.Color.Blue
        Me.lblReferencia2.Location = New System.Drawing.Point(393, 75)
        Me.lblReferencia2.Name = "lblReferencia2"
        Me.lblReferencia2.Size = New System.Drawing.Size(171, 13)
        Me.lblReferencia2.TabIndex = 31
        Me.lblReferencia2.Text = "lblReferencia2:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(302, 75)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 13)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Referencia 2:"
        '
        'lblReferencia1
        '
        Me.lblReferencia1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReferencia1.ForeColor = System.Drawing.Color.Blue
        Me.lblReferencia1.Location = New System.Drawing.Point(121, 75)
        Me.lblReferencia1.Name = "lblReferencia1"
        Me.lblReferencia1.Size = New System.Drawing.Size(175, 13)
        Me.lblReferencia1.TabIndex = 29
        Me.lblReferencia1.Text = "lblReferencia1:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Referencia 1:"
        '
        'lblTelefono2
        '
        Me.lblTelefono2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefono2.ForeColor = System.Drawing.Color.Blue
        Me.lblTelefono2.Location = New System.Drawing.Point(393, 55)
        Me.lblTelefono2.Name = "lblTelefono2"
        Me.lblTelefono2.Size = New System.Drawing.Size(171, 13)
        Me.lblTelefono2.TabIndex = 27
        Me.lblTelefono2.Text = "lblTelefono2:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(302, 55)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 13)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Teléfono 2:"
        '
        'lblTelefono1
        '
        Me.lblTelefono1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefono1.ForeColor = System.Drawing.Color.Blue
        Me.lblTelefono1.Location = New System.Drawing.Point(121, 55)
        Me.lblTelefono1.Name = "lblTelefono1"
        Me.lblTelefono1.Size = New System.Drawing.Size(175, 13)
        Me.lblTelefono1.TabIndex = 25
        Me.lblTelefono1.Text = "lblTelefono1:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Teléfono 1:"
        '
        'lblCiudad
        '
        Me.lblCiudad.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCiudad.ForeColor = System.Drawing.Color.Blue
        Me.lblCiudad.Location = New System.Drawing.Point(393, 35)
        Me.lblCiudad.Name = "lblCiudad"
        Me.lblCiudad.Size = New System.Drawing.Size(171, 13)
        Me.lblCiudad.TabIndex = 23
        Me.lblCiudad.Text = "lblCiudad:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(302, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Ciudad:"
        '
        'lblColonia
        '
        Me.lblColonia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColonia.ForeColor = System.Drawing.Color.Blue
        Me.lblColonia.Location = New System.Drawing.Point(121, 35)
        Me.lblColonia.Name = "lblColonia"
        Me.lblColonia.Size = New System.Drawing.Size(175, 13)
        Me.lblColonia.TabIndex = 21
        Me.lblColonia.Text = "lblColonia:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Colonia:"
        '
        'lblCalle
        '
        Me.lblCalle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalle.ForeColor = System.Drawing.Color.Blue
        Me.lblCalle.Location = New System.Drawing.Point(121, 15)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(175, 13)
        Me.lblCalle.TabIndex = 19
        Me.lblCalle.Text = "lblCalle:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Calle:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Location = New System.Drawing.Point(0, 95)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(580, 8)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(826, 534)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(55, 13)
        Me.Label33.TabIndex = 74
        Me.Label33.Text = "Generales"
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(790, 534)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(30, 13)
        Me.Label34.TabIndex = 73
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(826, 520)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(49, 13)
        Me.Label32.TabIndex = 72
        Me.Label32.Text = "Atendido"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(826, 506)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(120, 13)
        Me.Label26.TabIndex = 70
        Me.Label26.Text = "Asignado \ Seguimiento"
        '
        'lblEtqColorBlack
        '
        Me.lblEtqColorBlack.BackColor = System.Drawing.Color.OrangeRed
        Me.lblEtqColorBlack.Location = New System.Drawing.Point(790, 506)
        Me.lblEtqColorBlack.Name = "lblEtqColorBlack"
        Me.lblEtqColorBlack.Size = New System.Drawing.Size(30, 13)
        Me.lblEtqColorBlack.TabIndex = 69
        '
        'lblEtqColorGreen
        '
        Me.lblEtqColorGreen.BackColor = System.Drawing.Color.ForestGreen
        Me.lblEtqColorGreen.Location = New System.Drawing.Point(790, 520)
        Me.lblEtqColorGreen.Name = "lblEtqColorGreen"
        Me.lblEtqColorGreen.Size = New System.Drawing.Size(30, 13)
        Me.lblEtqColorGreen.TabIndex = 71
        '
        'btnActualizar
        '
        Me.btnActualizar.Image = CType(resources.GetObject("btnActualizar.Image"), System.Drawing.Image)
        Me.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActualizar.Location = New System.Drawing.Point(12, 27)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(79, 43)
        Me.btnActualizar.TabIndex = 0
        Me.btnActualizar.Text = "&Actualizar"
        Me.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboSucursalFiltrado
        '
        Me.cboSucursalFiltrado.AllowDrop = True
        Me.cboSucursalFiltrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursalFiltrado.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSucursalFiltrado.Location = New System.Drawing.Point(163, 26)
        Me.cboSucursalFiltrado.Name = "cboSucursalFiltrado"
        Me.cboSucursalFiltrado.Size = New System.Drawing.Size(221, 21)
        Me.cboSucursalFiltrado.TabIndex = 2
        Me.cboSucursalFiltrado.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(106, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Sucursal:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(106, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Entre el:"
        '
        'dtpFInicio
        '
        Me.dtpFInicio.AllowDrop = True
        Me.dtpFInicio.CustomFormat = ""
        Me.dtpFInicio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFInicio.Location = New System.Drawing.Point(163, 53)
        Me.dtpFInicio.Name = "dtpFInicio"
        Me.dtpFInicio.Size = New System.Drawing.Size(221, 21)
        Me.dtpFInicio.TabIndex = 8
        Me.dtpFInicio.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(400, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "y el:"
        '
        'dtpFFinal
        '
        Me.dtpFFinal.AllowDrop = True
        Me.dtpFFinal.CustomFormat = ""
        Me.dtpFFinal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFFinal.Location = New System.Drawing.Point(440, 53)
        Me.dtpFFinal.Name = "dtpFFinal"
        Me.dtpFFinal.Size = New System.Drawing.Size(221, 21)
        Me.dtpFFinal.TabIndex = 10
        Me.dtpFFinal.TabStop = False
        '
        'cboRutaFiltrado
        '
        Me.cboRutaFiltrado.AllowDrop = True
        Me.cboRutaFiltrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRutaFiltrado.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRutaFiltrado.Location = New System.Drawing.Point(717, 26)
        Me.cboRutaFiltrado.Name = "cboRutaFiltrado"
        Me.cboRutaFiltrado.Size = New System.Drawing.Size(221, 21)
        Me.cboRutaFiltrado.TabIndex = 6
        Me.cboRutaFiltrado.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(677, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Ruta:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Location = New System.Drawing.Point(365, 496)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(3, 60)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        '
        'btnRadiado
        '
        Me.btnRadiado.Image = CType(resources.GetObject("btnRadiado.Image"), System.Drawing.Image)
        Me.btnRadiado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRadiado.Location = New System.Drawing.Point(381, 506)
        Me.btnRadiado.Name = "btnRadiado"
        Me.btnRadiado.Size = New System.Drawing.Size(79, 43)
        Me.btnRadiado.TabIndex = 66
        Me.btnRadiado.Text = "&Asignado"
        Me.btnRadiado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSeguimiento
        '
        Me.btnSeguimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSeguimiento.Image = CType(resources.GetObject("btnSeguimiento.Image"), System.Drawing.Image)
        Me.btnSeguimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSeguimiento.Location = New System.Drawing.Point(490, 506)
        Me.btnSeguimiento.Name = "btnSeguimiento"
        Me.btnSeguimiento.Size = New System.Drawing.Size(79, 43)
        Me.btnSeguimiento.TabIndex = 67
        Me.btnSeguimiento.Text = "&Seguimiento"
        Me.btnSeguimiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAtendido
        '
        Me.btnAtendido.Image = CType(resources.GetObject("btnAtendido.Image"), System.Drawing.Image)
        Me.btnAtendido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAtendido.Location = New System.Drawing.Point(603, 505)
        Me.btnAtendido.Name = "btnAtendido"
        Me.btnAtendido.Size = New System.Drawing.Size(79, 43)
        Me.btnAtendido.TabIndex = 68
        Me.btnAtendido.Text = "Atendido"
        Me.btnAtendido.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboAreaFiltrado
        '
        Me.cboAreaFiltrado.AllowDrop = True
        Me.cboAreaFiltrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAreaFiltrado.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAreaFiltrado.Location = New System.Drawing.Point(440, 26)
        Me.cboAreaFiltrado.Name = "cboAreaFiltrado"
        Me.cboAreaFiltrado.Size = New System.Drawing.Size(221, 21)
        Me.cboAreaFiltrado.TabIndex = 4
        Me.cboAreaFiltrado.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(400, 30)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(34, 13)
        Me.Label25.TabIndex = 3
        Me.Label25.Text = "Área:"
        '
        'frmFugaPortatilProcesos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 551)
        Me.Controls.Add(Me.cboAreaFiltrado)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.btnAtendido)
        Me.Controls.Add(Me.lblEtqColorBlack)
        Me.Controls.Add(Me.btnSeguimiento)
        Me.Controls.Add(Me.lblEtqColorGreen)
        Me.Controls.Add(Me.btnRadiado)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.cboRutaFiltrado)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpFFinal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpFInicio)
        Me.Controls.Add(Me.cboSucursalFiltrado)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grbInformacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmFugaPortatilProcesos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seguimiento de fugas portátiles"
        Me.grbInformacion.ResumeLayout(False)
        Me.grbInformacion.PerformLayout()
        CType(Me.dgProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents dgProducto As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents cboSucursalFiltrado As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboRutaFiltrado As PortatilClasses.Combo.ComboRutaPtl
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotalClientes As System.Windows.Forms.Label
    Friend WithEvents lblCiudad As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblReferencia2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblReferencia1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblTelefono2 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblTelefono1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnHistorico As System.Windows.Forms.Button
    Friend WithEvents lblFVenta As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblComentario As System.Windows.Forms.Label
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblNuevos As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblFRegistrado As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblAtendidos As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents CboAreaEmpleado As PortatilClasses.Combo.ComboRutaPtl
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents dtpFAtencion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRadiado As System.Windows.Forms.Button
    Friend WithEvents btnSeguimiento As System.Windows.Forms.Button
    Friend WithEvents btnAtendido As System.Windows.Forms.Button
    Friend WithEvents cboAreaFiltrado As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblSeguimiento As System.Windows.Forms.Label
    Friend WithEvents CboRuta As PortatilClasses.Combo.ComboRutaPtl
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CboArea As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents CboSucursalPermiso As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents CboTipoAtencionFuga As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents CboTipoFuga As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtCantidadKilos As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents dtpFFinSupresion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents dtpFInicioSupresion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblEtqColorBlack As System.Windows.Forms.Label
    Friend WithEvents lblEtqColorGreen As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtComentarioAtencion As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblColonia As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblCalle As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents lblComprobante As System.Windows.Forms.Label
End Class

Imports System.Data.SqlClient


Public Class frmAnexarClientes
    Inherits System.Windows.Forms.Form

    Private _TipoOperacion As Operacion
    Private _Ruta As Integer
    Private _Cliente As Integer
    Private _TipoProg As Short
    Private _FechaActual As DateTime
    Private _Fecha As DateTime
    Public ContratoAnexado As Boolean = False

    Private _dtTable As DataTable
    Private NumEnter As Short

    Public Enum Operacion
        TODOS
        REZAGADOS
    End Enum

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal TipoOperacion As Operacion, ByVal Ruta As Integer, ByVal FechaActual As DateTime)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _TipoOperacion = TipoOperacion
        _Ruta = Ruta
        _FechaActual = FechaActual
        If _TipoOperacion = Operacion.REZAGADOS Then
            Me.Text = Me.Text & Operacion.REZAGADOS.ToString
        End If
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
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRutaPedido As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents dtpFCarga As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRutaCliente As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtObservacionCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblGiro As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblUCarga As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblColonia As System.Windows.Forms.Label
    Friend WithEvents lblCalle As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblNombrePersonal As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblNombreFiscal As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSeparador1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtObservacionProg As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnCNS As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnTanque As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRepartos As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarraBotones As System.Windows.Forms.ToolBar
    Friend WithEvents btnTodos As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAnexar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents dgContratos As System.Windows.Forms.DataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarFecha As System.Windows.Forms.Button
    Friend WithEvents btnCerrar2 As System.Windows.Forms.Button
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtContrato As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents lblFrecuencia As System.Windows.Forms.Label
    Friend WithEvents lblTotalProg As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Tiempo As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAnexarClientes))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblFrecuencia = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblRutaPedido = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dtpFCarga = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblRutaCliente = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtObservacionCliente = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblGiro = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblUCarga = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.lblColonia = New System.Windows.Forms.Label()
        Me.lblCalle = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblNombrePersonal = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblNombreFiscal = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSeparador1 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtObservacionProg = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgContratos = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.lblTotalProg = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnBuscarFecha = New System.Windows.Forms.Button()
        Me.btnCNS = New System.Windows.Forms.ToolBarButton()
        Me.btnTanque = New System.Windows.Forms.ToolBarButton()
        Me.btnAnexar = New System.Windows.Forms.Button()
        Me.btnRepartos = New System.Windows.Forms.ToolBarButton()
        Me.BarraBotones = New System.Windows.Forms.ToolBar()
        Me.btnTodos = New System.Windows.Forms.ToolBarButton()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtContrato = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.btnCerrar2 = New System.Windows.Forms.Button()
        Me.Tiempo = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgContratos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label9, Me.lblStatus, Me.lblFrecuencia, Me.Label8, Me.lblRutaPedido, Me.Label22, Me.lblEstado, Me.Label20, Me.dtpFCarga, Me.Label19, Me.GroupBox4, Me.lblRutaCliente, Me.Label4, Me.txtObservacionCliente, Me.Label17, Me.lblGiro, Me.Label15, Me.lblUCarga, Me.Label13, Me.lblMunicipio, Me.lblColonia, Me.lblCalle, Me.Label7, Me.lblNombrePersonal, Me.Label5, Me.lblNombreFiscal, Me.Label3})
        Me.GroupBox3.Location = New System.Drawing.Point(332, 89)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(401, 422)
        Me.GroupBox3.TabIndex = 168
        Me.GroupBox3.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(220, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 14)
        Me.Label9.TabIndex = 166
        Me.Label9.Text = "Status:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblStatus.Location = New System.Drawing.Point(264, 16)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(55, 14)
        Me.lblStatus.TabIndex = 167
        Me.lblStatus.Text = "lblStatus"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFrecuencia
        '
        Me.lblFrecuencia.AutoSize = True
        Me.lblFrecuencia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrecuencia.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblFrecuencia.Location = New System.Drawing.Point(25, 236)
        Me.lblFrecuencia.Name = "lblFrecuencia"
        Me.lblFrecuencia.Size = New System.Drawing.Size(56, 14)
        Me.lblFrecuencia.TabIndex = 165
        Me.lblFrecuencia.Text = "lblUCarga."
        Me.lblFrecuencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 216)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 14)
        Me.Label8.TabIndex = 164
        Me.Label8.Text = "Frecuencia"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRutaPedido
        '
        Me.lblRutaPedido.AutoSize = True
        Me.lblRutaPedido.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutaPedido.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblRutaPedido.Location = New System.Drawing.Point(288, 310)
        Me.lblRutaPedido.Name = "lblRutaPedido"
        Me.lblRutaPedido.Size = New System.Drawing.Size(84, 14)
        Me.lblRutaPedido.TabIndex = 163
        Me.lblRutaPedido.Text = "lblRutaPedido"
        Me.lblRutaPedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(248, 310)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(31, 14)
        Me.Label22.TabIndex = 162
        Me.Label22.Text = "Ruta:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.Red
        Me.lblEstado.Location = New System.Drawing.Point(96, 310)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(57, 14)
        Me.lblEstado.TabIndex = 161
        Me.lblEstado.Text = "lblEstado"
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(13, 310)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 14)
        Me.Label20.TabIndex = 160
        Me.Label20.Text = "Estado:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFCarga
        '
        Me.dtpFCarga.Location = New System.Drawing.Point(96, 334)
        Me.dtpFCarga.Name = "dtpFCarga"
        Me.dtpFCarga.TabIndex = 3
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(13, 338)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 14)
        Me.Label19.TabIndex = 158
        Me.Label19.Text = "Fecha carga:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.GroupBox4.Location = New System.Drawing.Point(4, 297)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(394, 9)
        Me.GroupBox4.TabIndex = 157
        Me.GroupBox4.TabStop = False
        '
        'lblRutaCliente
        '
        Me.lblRutaCliente.AutoSize = True
        Me.lblRutaCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutaCliente.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblRutaCliente.Location = New System.Drawing.Point(286, 276)
        Me.lblRutaCliente.Name = "lblRutaCliente"
        Me.lblRutaCliente.Size = New System.Drawing.Size(85, 14)
        Me.lblRutaCliente.TabIndex = 156
        Me.lblRutaCliente.Text = "lblRutaCliente"
        Me.lblRutaCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(248, 276)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 14)
        Me.Label4.TabIndex = 155
        Me.Label4.Text = "Ruta:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtObservacionCliente
        '
        Me.txtObservacionCliente.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtObservacionCliente.AutoSize = False
        Me.txtObservacionCliente.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtObservacionCliente.Location = New System.Drawing.Point(16, 391)
        Me.txtObservacionCliente.Name = "txtObservacionCliente"
        Me.txtObservacionCliente.ReadOnly = True
        Me.txtObservacionCliente.Size = New System.Drawing.Size(368, 25)
        Me.txtObservacionCliente.TabIndex = 154
        Me.txtObservacionCliente.TabStop = False
        Me.txtObservacionCliente.Text = ""
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(13, 365)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 14)
        Me.Label17.TabIndex = 153
        Me.Label17.Text = "Observaciones"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGiro
        '
        Me.lblGiro.AutoSize = True
        Me.lblGiro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGiro.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblGiro.Location = New System.Drawing.Point(44, 276)
        Me.lblGiro.Name = "lblGiro"
        Me.lblGiro.Size = New System.Drawing.Size(36, 14)
        Me.lblGiro.TabIndex = 152
        Me.lblGiro.Text = "lblGiro"
        Me.lblGiro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 276)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 14)
        Me.Label15.TabIndex = 151
        Me.Label15.Text = "Giro:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUCarga
        '
        Me.lblUCarga.AutoSize = True
        Me.lblUCarga.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUCarga.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblUCarga.Location = New System.Drawing.Point(25, 196)
        Me.lblUCarga.Name = "lblUCarga"
        Me.lblUCarga.Size = New System.Drawing.Size(56, 14)
        Me.lblUCarga.TabIndex = 150
        Me.lblUCarga.Text = "lblUCarga."
        Me.lblUCarga.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(13, 176)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 14)
        Me.Label13.TabIndex = 149
        Me.Label13.Text = "Última carga"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMunicipio
        '
        Me.lblMunicipio.AutoSize = True
        Me.lblMunicipio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipio.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMunicipio.Location = New System.Drawing.Point(25, 156)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(62, 14)
        Me.lblMunicipio.TabIndex = 146
        Me.lblMunicipio.Text = "lblMunicipio"
        Me.lblMunicipio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblColonia
        '
        Me.lblColonia.AutoSize = True
        Me.lblColonia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColonia.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblColonia.Location = New System.Drawing.Point(25, 136)
        Me.lblColonia.Name = "lblColonia"
        Me.lblColonia.Size = New System.Drawing.Size(52, 14)
        Me.lblColonia.TabIndex = 145
        Me.lblColonia.Text = "lblColonia"
        Me.lblColonia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCalle
        '
        Me.lblCalle.AutoSize = True
        Me.lblCalle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalle.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCalle.Location = New System.Drawing.Point(25, 116)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(39, 14)
        Me.lblCalle.TabIndex = 144
        Me.lblCalle.Text = "lblCalle"
        Me.lblCalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 14)
        Me.Label7.TabIndex = 143
        Me.Label7.Text = "Dirección a surtir"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNombrePersonal
        '
        Me.lblNombrePersonal.AutoSize = True
        Me.lblNombrePersonal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombrePersonal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblNombrePersonal.Location = New System.Drawing.Point(25, 76)
        Me.lblNombrePersonal.Name = "lblNombrePersonal"
        Me.lblNombrePersonal.Size = New System.Drawing.Size(97, 14)
        Me.lblNombrePersonal.TabIndex = 142
        Me.lblNombrePersonal.Text = "lblNombrePersonal"
        Me.lblNombrePersonal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 14)
        Me.Label5.TabIndex = 141
        Me.Label5.Text = "Nombre personal"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNombreFiscal
        '
        Me.lblNombreFiscal.AutoSize = True
        Me.lblNombreFiscal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreFiscal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblNombreFiscal.Location = New System.Drawing.Point(25, 36)
        Me.lblNombreFiscal.Name = "lblNombreFiscal"
        Me.lblNombreFiscal.Size = New System.Drawing.Size(82, 14)
        Me.lblNombreFiscal.TabIndex = 140
        Me.lblNombreFiscal.Text = "lblNombreFiscal"
        Me.lblNombreFiscal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 14)
        Me.Label3.TabIndex = 139
        Me.Label3.Text = "Nombre fiscal"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSeparador1
        '
        Me.btnSeparador1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 3
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar la pantalla"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtObservacionProg, Me.Label2, Me.dgContratos, Me.lblTotalProg, Me.Label6})
        Me.GroupBox2.Location = New System.Drawing.Point(7, 89)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(320, 422)
        Me.GroupBox2.TabIndex = 166
        Me.GroupBox2.TabStop = False
        '
        'txtObservacionProg
        '
        Me.txtObservacionProg.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtObservacionProg.AutoSize = False
        Me.txtObservacionProg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacionProg.Location = New System.Drawing.Point(4, 384)
        Me.txtObservacionProg.MaxLength = 50
        Me.txtObservacionProg.Name = "txtObservacionProg"
        Me.txtObservacionProg.Size = New System.Drawing.Size(312, 32)
        Me.txtObservacionProg.TabIndex = 2
        Me.txtObservacionProg.Text = ""
        '
        'Label2
        '
        Me.Label2.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 365)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 14)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "Observaciones"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgContratos
        '
        Me.dgContratos.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.dgContratos.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.dgContratos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgContratos.CaptionText = "Contratos"
        Me.dgContratos.DataMember = ""
        Me.dgContratos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgContratos.Location = New System.Drawing.Point(3, 23)
        Me.dgContratos.Name = "dgContratos"
        Me.dgContratos.ReadOnly = True
        Me.dgContratos.Size = New System.Drawing.Size(316, 313)
        Me.dgContratos.TabIndex = 1
        Me.dgContratos.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle2})
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.DataGridTableStyle2.DataGrid = Me.dgContratos
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5})
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle2.MappingName = ""
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Contrato"
        Me.DataGridTextBoxColumn2.MappingName = "Cliente"
        Me.DataGridTextBoxColumn2.Width = 75
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Tel. Casa"
        Me.DataGridTextBoxColumn3.MappingName = "TelCasa"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Tel. 1"
        Me.DataGridTextBoxColumn4.MappingName = "TelAlterno1"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Tel. 2"
        Me.DataGridTextBoxColumn5.MappingName = "TelAlterno2"
        Me.DataGridTextBoxColumn5.NullText = ""
        Me.DataGridTextBoxColumn5.Width = 75
        '
        'lblTotalProg
        '
        Me.lblTotalProg.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.lblTotalProg.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalProg.Location = New System.Drawing.Point(240, 341)
        Me.lblTotalProg.Name = "lblTotalProg"
        Me.lblTotalProg.Size = New System.Drawing.Size(72, 13)
        Me.lblTotalProg.TabIndex = 167
        Me.lblTotalProg.Text = "0"
        Me.lblTotalProg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(48, 341)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 14)
        Me.Label6.TabIndex = 166
        Me.Label6.Text = "Total de contratos programados:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 514)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(752, 8)
        Me.GroupBox1.TabIndex = 165
        Me.GroupBox1.TabStop = False
        '
        'btnBuscarFecha
        '
        Me.btnBuscarFecha.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBuscarFecha.Image = CType(resources.GetObject("btnBuscarFecha.Image"), System.Drawing.Bitmap)
        Me.btnBuscarFecha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarFecha.Location = New System.Drawing.Point(662, 8)
        Me.btnBuscarFecha.Name = "btnBuscarFecha"
        Me.btnBuscarFecha.TabIndex = 174
        Me.btnBuscarFecha.TabStop = False
        Me.btnBuscarFecha.Text = "&Buscar"
        Me.btnBuscarFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscarFecha, "Consulta los movimientos de las fechas seleccionadas")
        '
        'btnCNS
        '
        Me.btnCNS.ImageIndex = 4
        Me.btnCNS.Text = "&C.N.S."
        Me.btnCNS.ToolTipText = "Muestra el historial de  causas de no surtido"
        '
        'btnTanque
        '
        Me.btnTanque.ImageIndex = 5
        Me.btnTanque.Text = "&Tanque"
        Me.btnTanque.ToolTipText = "Muestra la información de los equipos del cliente"
        '
        'btnAnexar
        '
        Me.btnAnexar.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.btnAnexar.Image = CType(resources.GetObject("btnAnexar.Image"), System.Drawing.Bitmap)
        Me.btnAnexar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnexar.Location = New System.Drawing.Point(320, 536)
        Me.btnAnexar.Name = "btnAnexar"
        Me.btnAnexar.Size = New System.Drawing.Size(96, 26)
        Me.btnAnexar.TabIndex = 4
        Me.btnAnexar.Text = "&Anexar"
        Me.btnAnexar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnRepartos
        '
        Me.btnRepartos.ImageIndex = 6
        Me.btnRepartos.Text = "R&epartos"
        Me.btnRepartos.ToolTipText = "Muestra el historial de servicios del cliente seleccionado"
        '
        'BarraBotones
        '
        Me.BarraBotones.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.BarraBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BarraBotones.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnRepartos, Me.btnTanque, Me.btnCNS, Me.btnTodos, Me.btnBuscar, Me.btnSeparador1, Me.btnCerrar})
        Me.BarraBotones.ButtonSize = New System.Drawing.Size(53, 35)
        Me.BarraBotones.DropDownArrows = True
        Me.BarraBotones.ImageList = Me.imgLista
        Me.BarraBotones.Name = "BarraBotones"
        Me.BarraBotones.ShowToolTips = True
        Me.BarraBotones.Size = New System.Drawing.Size(744, 39)
        Me.BarraBotones.TabIndex = 167
        '
        'btnTodos
        '
        Me.btnTodos.ImageIndex = 9
        Me.btnTodos.Text = "&Ver todos"
        Me.btnTodos.ToolTipText = "Muestra todos los contratos de la consulta"
        '
        'btnBuscar
        '
        Me.btnBuscar.ImageIndex = 0
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.ToolTipText = "Muestra la pantalla para la búsqueda de un contrato"
        '
        'imgLista
        '
        Me.imgLista.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista.ImageStream = CType(resources.GetObject("imgLista.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.GroupBox5.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtContrato, Me.Label1})
        Me.GroupBox5.Location = New System.Drawing.Point(8, 43)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(725, 48)
        Me.GroupBox5.TabIndex = 172
        Me.GroupBox5.TabStop = False
        '
        'txtContrato
        '
        Me.txtContrato.Location = New System.Drawing.Point(333, 18)
        Me.txtContrato.Name = "txtContrato"
        Me.txtContrato.Size = New System.Drawing.Size(120, 21)
        Me.txtContrato.TabIndex = 0
        Me.txtContrato.Text = "txtContrato"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(271, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 14)
        Me.Label1.TabIndex = 140
        Me.Label1.Text = "Contrato:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFecha
        '
        Me.lblFecha.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblFecha.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblFecha.Location = New System.Drawing.Point(497, 15)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(40, 13)
        Me.lblFecha.TabIndex = 175
        Me.lblFecha.Text = "Fecha:"
        '
        'dtpFecha
        '
        Me.dtpFecha.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.dtpFecha.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFecha.Location = New System.Drawing.Point(552, 10)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(100, 21)
        Me.dtpFecha.TabIndex = 173
        Me.dtpFecha.TabStop = False
        '
        'btnCerrar2
        '
        Me.btnCerrar2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar2.Location = New System.Drawing.Point(344, 8)
        Me.btnCerrar2.Name = "btnCerrar2"
        Me.btnCerrar2.Size = New System.Drawing.Size(8, 8)
        Me.btnCerrar2.TabIndex = 176
        Me.btnCerrar2.TabStop = False
        '
        'Tiempo
        '
        '
        'frmAnexarClientes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCerrar2
        Me.ClientSize = New System.Drawing.Size(744, 568)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFecha, Me.dtpFecha, Me.btnBuscarFecha, Me.GroupBox5, Me.GroupBox2, Me.GroupBox1, Me.btnAnexar, Me.BarraBotones, Me.GroupBox3, Me.btnCerrar2})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmAnexarClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anexar contratos "
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgContratos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Limpiar()
        lblStatus.Text = ""
        txtContrato.Text = ""
        lblNombreFiscal.Text = ""
        lblNombrePersonal.Text = ""
        lblCalle.Text = ""
        lblColonia.Text = ""
        lblMunicipio.Text = ""
        lblUCarga.Text = ""
        lblGiro.Text = ""
        lblRutaCliente.Text = ""
        lblEstado.Text = ""
        lblRutaPedido.Text = ""
        txtObservacionProg.Clear()
        txtObservacionCliente.Clear()
        lblFrecuencia.Text = ""
    End Sub

    Private Sub CargaProgramaCliente()
        Dim cmd As SqlCommand
        cmd = New SqlCommand("spCCProgramaClienteConsulta", ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Conexion)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Cliente", SqlDbType.Int).Value = _Cliente
        End With
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable("ProgramaCliente")
        Try
            da.Fill(dt)
            Dim i As Integer = 0
            lblFrecuencia.Text = ""
            Do While i < dt.Rows.Count
                lblFrecuencia.Text = lblFrecuencia.Text & CType(dt.Rows(i).Item(6), String).Trim() & "/"
                i = i + 1
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            cmd.Dispose()
        End Try
        ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Conexion.Close()
    End Sub

    Private Sub CargarEstado(ByVal Fecha As DateTime)
        Dim oEstados As New Consulta.cProgramacionBeta(4, _Cliente, Fecha, "", True, ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Usuario)
        If oEstados.drReader.Read Then
            If Not IsDBNull(oEstados.drReader(0)) Then
                lblEstado.Text = CType(oEstados.drReader(0), String)
                If Not IsDBNull(oEstados.drReader(2)) Then
                    Me.ToolTip1.SetToolTip(Me.lblEstado, CType(oEstados.drReader(2), String))
                Else
                    Me.ToolTip1.SetToolTip(Me.lblEstado, "")
                End If

                If Not IsDBNull(oEstados.drReader(1)) Then
                    lblRutaPedido.Text = CType(oEstados.drReader(1), String)
                End If
                If Not IsDBNull(oEstados.drReader(3)) Then
                    txtObservacionProg.Text = CType(oEstados.drReader(3), String)
                End If
                _TipoProg = CType(oEstados.drReader(4), Short)
            Else
                If Not IsDBNull(oEstados.drReader(5)) Then
                    lblEstado.Text = CType(oEstados.drReader(5), String)
                    If Not IsDBNull(oEstados.drReader(7)) Then
                        Me.ToolTip1.SetToolTip(Me.lblEstado, CType(oEstados.drReader(7), String))
                    Else
                        Me.ToolTip1.SetToolTip(Me.lblEstado, "")
                    End If

                    If Not IsDBNull(oEstados.drReader(6)) Then
                        lblRutaPedido.Text = CType(oEstados.drReader(6), String)
                    End If
                    If Not IsDBNull(oEstados.drReader(8)) Then
                        txtObservacionProg.Text = CType(oEstados.drReader(8), String)
                    End If
                    _TipoProg = CType(oEstados.drReader(9), Short)
                Else
                    lblEstado.Text = ""
                    Me.ToolTip1.SetToolTip(Me.lblEstado, "")
                    lblRutaPedido.Text = ""
                    txtObservacionProg.Text = ""
                    _TipoProg = 0
                End If
            End If
        End If
    End Sub

    Private Sub ConsultaProgramacion(ByVal Configuracion As Short, ByVal Fecha As DateTime)
        Dim oRegistrarProg As New Consulta.cProgramacionBeta(Configuracion, _Cliente, Fecha, txtObservacionProg.Text, True, ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Usuario)
        If oRegistrarProg.drReader.Read Then
            lblEstado.Text = CType(oRegistrarProg.drReader(1), String)
            If Not IsDBNull(oRegistrarProg.drReader(2)) Then
                Me.ToolTip1.SetToolTip(Me.lblEstado, CType(oRegistrarProg.drReader(2), String))
            Else
                Me.ToolTip1.SetToolTip(Me.lblEstado, "")
            End If
            txtObservacionProg.Text = CType(oRegistrarProg.drReader(3), String)
            _TipoProg = CType(oRegistrarProg.drReader(4), Short)
            HabilitarBotones()
        End If
        oRegistrarProg.CerrarConexion()
    End Sub

    Private Sub CargarCliente(ByVal Index As Integer)
        Limpiar()
        If dgContratos.VisibleRowCount > 0 Then
            Cursor = Cursors.WaitCursor

            Dim drClientes() As DataRow
            Dim drCliente As DataRow
            _Cliente = Convert.ToInt32(dgContratos(Index, 0))
            drClientes = _dtTable.Select("Cliente=" & _Cliente)
            If (Not drClientes Is Nothing AndAlso drClientes.Length > 0) Then
                drCliente = drClientes(0)
                lblStatus.Text = CType(drCliente.Item(16), String).TrimEnd
                txtContrato.Text = CType(_Cliente, String)
                NumEnter = 2

                If Not IsDBNull(drCliente.Item(12)) Then
                    lblNombreFiscal.Text = CType(drCliente.Item(12), String)
                Else
                    lblNombreFiscal.Text = ""
                End If
                lblGiro.Text = CType(drCliente.Item(13), String)
                'CerrarNotas()

                lblNombrePersonal.Text = CType(drCliente.Item(1), String).Trim
                lblCalle.Text = CType(drCliente.Item(6), String)
                lblColonia.Text = CType(drCliente.Item(7), String)
                lblMunicipio.Text = CType(drCliente.Item(8), String) & CType(drCliente.Item(9), String)

                If Not IsDBNull(drCliente.Item(14)) Then
                    Dim Fecha As DateTime
                    Fecha = CType(drCliente.Item(14), Date)
                    lblUCarga.Text = Fecha.ToLongDateString
                Else
                    lblUCarga.Text = "Sin carga"
                End If
                lblRutaCliente.Text = CType(drCliente.Item(11), String)

                If Not IsDBNull(drCliente.Item(10)) Then
                    txtObservacionCliente.Text = CType(drCliente.Item(10), String)
                Else
                    txtObservacionCliente.Clear()
                End If
                If Not IsDBNull(drCliente.Item(15)) Then
                    dtpFCarga.Value = CType(drCliente.Item(15), DateTime)
                    _Fecha = dtpFCarga.Value.Date
                End If


                CargarEstado(dtpFCarga.Value.Date)
                If _TipoProg = 2 Then
                    ConsultaProgramacion(2, dtpFCarga.Value.Date)
                End If

                HabilitarBotones()

                ''If Main.CONFIG_AbreNotasClienteAuto Then
                'SigaMetClasses.AbrePostitCliente(_Cliente, Me)
                'Me.Refresh()
                ''End If
                CargaProgramaCliente()
                Cursor = Cursors.Default
            Else
                Dim strContrato As String = txtContrato.Text
                Limpiar()
                Dim Mensaje As New PortatilClasses.Mensaje(3, strContrato)
                MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtContrato.Text = ""
                ActiveControl = txtContrato
            End If
            btnAnexar.Enabled = False
        End If


        '    _Cliente = CType(_dtTable.DefaultView.Item(Index).Item(0), Integer)
        '    txtContrato.Text = CType(_Cliente, String)
        '    NumEnter = 2

        '    If Not IsDBNull(_dtTable.DefaultView.Item(Index).Item(12)) Then
        '        lblNombreFiscal.Text = CType(_dtTable.DefaultView.Item(Index).Item(12), String)
        '    Else
        '        lblNombreFiscal.Text = ""
        '    End If
        '    'CerrarNotas()

        '    lblNombrePersonal.Text = CType(_dtTable.DefaultView.Item(Index).Item(1), String).Trim
        '    lblCalle.Text = CType(_dtTable.DefaultView.Item(Index).Item(6), String)
        '    lblColonia.Text = CType(_dtTable.DefaultView.Item(Index).Item(7), String)
        '    lblMunicipio.Text = CType(_dtTable.DefaultView.Item(Index).Item(8), String) & CType(_dtTable.DefaultView.Item(Index).Item(9), String)

        '    If Not IsDBNull(_dtTable.DefaultView.Item(Index).Item(14)) Then
        '        Dim Fecha As DateTime
        '        Fecha = CType(_dtTable.DefaultView.Item(Index).Item(14), Date)
        '        lblUCarga.Text = Fecha.ToLongDateString
        '    Else
        '        lblUCarga.Text = "Sin carga"
        '    End If
        '    lblRutaCliente.Text = CType(_dtTable.DefaultView.Item(Index).Item(11), String)

        '    If Not IsDBNull(_dtTable.DefaultView.Item(Index).Item(10)) Then
        '        txtObservacionCliente.Text = CType(_dtTable.DefaultView.Item(Index).Item(10), String)
        '    Else
        '        txtObservacionCliente.Clear()
        '    End If
        '    If Not IsDBNull(_dtTable.DefaultView.Item(Index).Item(15)) Then
        '        dtpFCarga.Value = CType(_dtTable.DefaultView.Item(Index).Item(15), DateTime)
        '        _Fecha = dtpFCarga.Value.Date
        '    End If


        '    CargarEstado(dtpFCarga.Value.Date)
        '    If _TipoProg = 2 Then
        '        ConsultaProgramacion(2, dtpFCarga.Value.Date)
        '    End If

        '    HabilitarBotones()

        '    ''If Main.CONFIG_AbreNotasClienteAuto Then
        '    'SigaMetClasses.AbrePostitCliente(_Cliente, Me)
        '    'Me.Refresh()
        '    ''End If
        '    CargaProgramaCliente()
        '    Cursor = Cursors.Default
        'Else
        '    Dim strContrato As String = txtContrato.Text
        '    Limpiar()
        '    Dim Mensaje As New PortatilClasses.Mensaje(3, strContrato)
        '    MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    txtContrato.Text = ""
        '    ActiveControl = txtContrato
        'End If
        'btnAnexar.Enabled = False
    End Sub

    Private Sub CargardgClientes()
        dgContratos.DataSource = Nothing
        Dim oClientes As Consulta.cClientesProgramados
        If _TipoOperacion = Operacion.TODOS Then
            oClientes = New Consulta.cClientesProgramados(1, _Ruta, Now)
        Else
            oClientes = New Consulta.cClientesProgramados(2, _Ruta, dtpFecha.Value.Date)
        End If
        _dtTable = oClientes.dtTable
        dgContratos.DataSource = _dtTable
        lblTotalProg.Text = CType(_dtTable.Rows.Count, String)
        If dgContratos.VisibleRowCount > 0 Then
            CargarCliente(dgContratos.CurrentRowIndex)
        Else
            Limpiar()
        End If
    End Sub

    Private Sub HabilitarBotones()
        If _TipoOperacion = Operacion.TODOS Then
            lblFecha.Visible = False
            dtpFecha.Visible = False
            btnBuscarFecha.Visible = False
        Else
            lblFecha.Visible = True
            dtpFecha.Visible = True
            btnBuscar.Visible = True
        End If
    End Sub

    Private Sub CargarRepartos()
        If _Cliente > 0 Then
            Dim oRepartos As New frmConsultaRepartos(_Cliente, lblNombrePersonal.Text)
            oRepartos.ShowDialog()
            oRepartos = Nothing
        End If
    End Sub

    Private Sub CargarTanques()
        If _Cliente > 0 Then
            Dim oTanque As New frmConsultaTanque(_Cliente, lblNombrePersonal.Text)
            If oTanque.CargarSecuencia Then
                oTanque.ShowDialog()
            Else
                MessageBox.Show("No existe datos del tanque.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub CargarCNS()
        If _Cliente > 0 Then
            Dim oCNS As New frmConsultaCNS(_Cliente, lblNombrePersonal.Text)
            oCNS.ShowDialog()
            oCNS = Nothing
        End If
    End Sub

    Private Sub BuscarCliente()
        Dim oBusquedaCliente As New SigaMetClasses.BusquedaCliente(True)
        If oBusquedaCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If oBusquedaCliente.Cliente <> 0 Then
                txtContrato.Text = CType(oBusquedaCliente.Cliente, String)
                _dtTable.DefaultView.RowFilter = "Cliente = '" & txtContrato.Text & "'"
                dgContratos.DataSource = _dtTable
                CargarCliente(dgContratos.CurrentRowIndex)
            End If
        End If
    End Sub

    Private Sub AnexarContrato()
        Cursor = Cursors.WaitCursor
        If _Fecha > _FechaActual Then
            Dim oProgBorrar As New Consulta.cProgramacionBeta(3, _Cliente, _Fecha, "", True, ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Usuario)
            oProgBorrar = Nothing
        End If

        Dim oProgRegistrar As New Consulta.cProgramacionBeta(0, _Cliente, dtpFCarga.Value.Date, txtObservacionProg.Text, False, ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Usuario)
        ContratoAnexado = True
        Dim Filtro As String = _dtTable.DefaultView.RowFilter
        Dim Posicion As Integer = dgContratos.CurrentRowIndex
        CargardgClientes()
        _dtTable.DefaultView.RowFilter = Filtro
        If Posicion <= _dtTable.Rows.Count - 1 Then
            dgContratos.CurrentRowIndex = Posicion
        Else
            dgContratos.CurrentRowIndex = _dtTable.Rows.Count - 1
        End If
        Cursor = Cursors.Default
        CargarCliente(dgContratos.CurrentRowIndex)
    End Sub

    Private Sub frmAnexarClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Limpiar()
        HabilitarBotones()
        CargardgClientes()
        btnAnexar.Enabled = False
    End Sub

    Private Sub dgContratos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles dgContratos.KeyDown, dtpFCarga.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub txtObservacionProg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles txtObservacionProg.KeyDown, txtContrato.KeyDown
        If e.KeyData = Keys.Enter Or e.KeyData = Keys.Down Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            MyBase.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    Private Sub BarraBotones_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles BarraBotones.ButtonClick
        Select Case BarraBotones.Buttons.IndexOf(e.Button)
            Case 0
                CargarRepartos()
            Case 1
                CargarTanques()
            Case 2
                CargarCNS()
            Case 3
                _dtTable.DefaultView.RowFilter = ""
                dgContratos.DataSource = _dtTable
                CargarCliente(dgContratos.CurrentRowIndex)
            Case 4
                BuscarCliente()
            Case 6
                Close()
        End Select
    End Sub

    Private Sub dgContratos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgContratos.CurrentCellChanged
        If dgContratos.VisibleRowCount > 0 Then
            CargarCliente(dgContratos.CurrentRowIndex)
        Else
            Limpiar()
        End If
    End Sub

    Private Sub txtContrato_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContrato.TextChanged
        NumEnter = 1
    End Sub

    Private Sub txtContrato_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContrato.Leave
        If NumEnter = 1 And txtContrato.Text <> "" Then
            _dtTable.DefaultView.RowFilter = "Cliente = '" & txtContrato.Text & "'"
            dgContratos.DataSource = _dtTable
            CargarCliente(dgContratos.CurrentRowIndex)
            NumEnter = 2
        End If
    End Sub

    Private Sub btnBuscarFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarFecha.Click
        'Limpiar()
        '_dtTable.DefaultView.RowFilter = "FechaCarga = '" & dtpFecha.Value.Date & "'"
        'dgContratos_CurrentCellChanged(sender, e)
        CargardgClientes()
    End Sub

    Private Sub dtpFCarga_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFCarga.TextChanged
        If dtpFCarga.Value.Date >= _FechaActual.Date And dtpFCarga.Value.Date <> _Fecha And _Cliente > 0 Then
            btnAnexar.Enabled = True
        Else
            btnAnexar.Enabled = False
        End If
    End Sub

    Private Sub btnAnexar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnexar.Click
        AnexarContrato()
    End Sub

    Private Sub dtpFCarga_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFCarga.Leave
        If btnAnexar.Enabled Then
            ActiveControl = btnAnexar
        End If
    End Sub

    Private Sub dgContratos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgContratos.Click
        Tiempo.Start()
    End Sub

    Private Sub Tiempo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tiempo.Tick
        Dim inti As Integer = 0

        Try
            Tiempo.Stop()

            For inti = 0 To _dtTable.Rows.Count
                If (Convert.ToInt32(dgContratos.Item(inti, 0)) = _Cliente) Then
                    dgContratos.CurrentRowIndex = inti
                    dgContratos.Select(inti)
                    Call CargarCliente(inti)
                    Exit Sub
                End If
            Next
        Catch
            '
        End Try
    End Sub
End Class

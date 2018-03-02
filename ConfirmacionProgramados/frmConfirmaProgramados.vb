Imports System.Data.SqlClient

Public Class frmConfirmaProgramados
    Inherits System.Windows.Forms.Form

    Private _Ruta As Integer
    Private _RutaNombre As String
    Private _Fecha As DateTime
    Private _FechaContrato As DateTime
    Private _Cliente As Integer
    Private _TipoProg As Short
    Private _FechaActual As DateTime
    Friend WithEvents lblNoSuministrar As System.Windows.Forms.Label

    Private _dtTable As DataTable

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Ruta As Integer, ByVal Fecha As DateTime, ByVal RutaNombre As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _Ruta = Ruta
        _Fecha = Fecha
        _RutaNombre = RutaNombre
        Me.Text = "[" & RutaNombre & " - " & Fecha.ToShortDateString() & "] - Confirmación de pedidos programados"
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Friend WithEvents BarraBotones As System.Windows.Forms.ToolBar
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTotalProg As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblNombreFiscal As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblNombrePersonal As System.Windows.Forms.Label
    Friend WithEvents lblCalle As System.Windows.Forms.Label
    Friend WithEvents lblColonia As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblUCarga As System.Windows.Forms.Label
    Friend WithEvents lblGiro As System.Windows.Forms.Label
    Friend WithEvents cboMotivoLlamada As PortatilClasses.Combo.ComboBase
    Friend WithEvents txtObservacionProg As System.Windows.Forms.TextBox
    Friend WithEvents txtObservacionCliente As System.Windows.Forms.TextBox
    Friend WithEvents dtpFCarga As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnRepartos As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSeparador1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnTanque As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCNS As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAnexar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSeparador2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSeparador3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents dgProgramados As System.Windows.Forms.DataGrid
    Friend WithEvents lblRutaCliente As System.Windows.Forms.Label
    Friend WithEvents btnLlamadas As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnConfirmar As System.Windows.Forms.Button
    Friend WithEvents btnNoConfirmar As System.Windows.Forms.Button
    Friend WithEvents btnPosponer As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnNotaTablero As System.Windows.Forms.Button
    Friend WithEvents btnNotaAgregar As System.Windows.Forms.Button
    Friend WithEvents btnNotaCerrar As System.Windows.Forms.Button
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lblRutaPedido As System.Windows.Forms.Label
    Friend WithEvents lblObservacionesProgramacion As System.Windows.Forms.Label
    Friend WithEvents grdProgramaCliente As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colProgTexto As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnRezagados As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar2 As System.Windows.Forms.Button
    Friend WithEvents btnHistorico As System.Windows.Forms.ToolBarButton
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Tiempo As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfirmaProgramados))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.BarraBotones = New System.Windows.Forms.ToolBar()
        Me.btnRepartos = New System.Windows.Forms.ToolBarButton()
        Me.btnTanque = New System.Windows.Forms.ToolBarButton()
        Me.btnCNS = New System.Windows.Forms.ToolBarButton()
        Me.btnLlamadas = New System.Windows.Forms.ToolBarButton()
        Me.btnHistorico = New System.Windows.Forms.ToolBarButton()
        Me.btnAnexar = New System.Windows.Forms.ToolBarButton()
        Me.btnRezagados = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.btnSeparador3 = New System.Windows.Forms.ToolBarButton()
        Me.btnNuevo = New System.Windows.Forms.ToolBarButton()
        Me.btnSeparador2 = New System.Windows.Forms.ToolBarButton()
        Me.btnRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.btnSeparador1 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblNoSuministrar = New System.Windows.Forms.Label()
        Me.lblObservacionesProgramacion = New System.Windows.Forms.Label()
        Me.grdProgramaCliente = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle()
        Me.colProgTexto = New System.Windows.Forms.DataGridTextBoxColumn()
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtObservacionProg = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTotalProg = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgProgramados = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.btnNoConfirmar = New System.Windows.Forms.Button()
        Me.btnPosponer = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cboMotivoLlamada = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnNotaTablero = New System.Windows.Forms.Button()
        Me.btnNotaAgregar = New System.Windows.Forms.Button()
        Me.btnNotaCerrar = New System.Windows.Forms.Button()
        Me.btnCerrar2 = New System.Windows.Forms.Button()
        Me.Tiempo = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdProgramaCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgProgramados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 514)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(752, 8)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'imgLista
        '
        Me.imgLista.ImageStream = CType(resources.GetObject("imgLista.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
        Me.imgLista.Images.SetKeyName(0, "")
        Me.imgLista.Images.SetKeyName(1, "")
        Me.imgLista.Images.SetKeyName(2, "")
        Me.imgLista.Images.SetKeyName(3, "")
        Me.imgLista.Images.SetKeyName(4, "")
        Me.imgLista.Images.SetKeyName(5, "")
        Me.imgLista.Images.SetKeyName(6, "")
        Me.imgLista.Images.SetKeyName(7, "")
        Me.imgLista.Images.SetKeyName(8, "")
        Me.imgLista.Images.SetKeyName(9, "")
        Me.imgLista.Images.SetKeyName(10, "")
        Me.imgLista.Images.SetKeyName(11, "")
        Me.imgLista.Images.SetKeyName(12, "")
        Me.imgLista.Images.SetKeyName(13, "")
        '
        'BarraBotones
        '
        Me.BarraBotones.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.BarraBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BarraBotones.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnRepartos, Me.btnTanque, Me.btnCNS, Me.btnLlamadas, Me.btnHistorico, Me.btnAnexar, Me.btnRezagados, Me.btnModificar, Me.btnSeparador3, Me.btnNuevo, Me.btnSeparador2, Me.btnRefrescar, Me.btnSeparador1, Me.btnCerrar})
        Me.BarraBotones.ButtonSize = New System.Drawing.Size(53, 35)
        Me.BarraBotones.DropDownArrows = True
        Me.BarraBotones.ImageList = Me.imgLista
        Me.BarraBotones.Location = New System.Drawing.Point(0, 0)
        Me.BarraBotones.Name = "BarraBotones"
        Me.BarraBotones.ShowToolTips = True
        Me.BarraBotones.Size = New System.Drawing.Size(744, 43)
        Me.BarraBotones.TabIndex = 1
        '
        'btnRepartos
        '
        Me.btnRepartos.ImageIndex = 10
        Me.btnRepartos.Name = "btnRepartos"
        Me.btnRepartos.Text = "R&epartos"
        Me.btnRepartos.ToolTipText = "Muestra el historial de servicios del cliente seleccionado"
        '
        'btnTanque
        '
        Me.btnTanque.ImageIndex = 9
        Me.btnTanque.Name = "btnTanque"
        Me.btnTanque.Text = "&Tanque"
        Me.btnTanque.ToolTipText = "Muestra la información de los equipos del cliente"
        '
        'btnCNS
        '
        Me.btnCNS.ImageIndex = 7
        Me.btnCNS.Name = "btnCNS"
        Me.btnCNS.Text = "C.N.&S."
        Me.btnCNS.ToolTipText = "Muestra el historial de  causas de no surtido"
        '
        'btnLlamadas
        '
        Me.btnLlamadas.ImageIndex = 11
        Me.btnLlamadas.Name = "btnLlamadas"
        Me.btnLlamadas.Text = "&Llamadas"
        Me.btnLlamadas.ToolTipText = "Muestra el historial de llamadas realizadas y recibidas"
        '
        'btnHistorico
        '
        Me.btnHistorico.ImageIndex = 13
        Me.btnHistorico.Name = "btnHistorico"
        Me.btnHistorico.Text = "&Histórico"
        Me.btnHistorico.ToolTipText = "Muestra el historial de cambios en su programación"
        '
        'btnAnexar
        '
        Me.btnAnexar.ImageIndex = 12
        Me.btnAnexar.Name = "btnAnexar"
        Me.btnAnexar.Text = "&Anexar"
        Me.btnAnexar.ToolTipText = "Muestra los contratos de las rutas"
        '
        'btnRezagados
        '
        Me.btnRezagados.ImageIndex = 6
        Me.btnRezagados.Name = "btnRezagados"
        Me.btnRezagados.Text = "&Rezagados"
        Me.btnRezagados.ToolTipText = "Muestra los contratos rezagados"
        '
        'btnModificar
        '
        Me.btnModificar.ImageIndex = 1
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Text = "&Modifcar"
        Me.btnModificar.ToolTipText = "Modifica la información del contrato"
        '
        'btnSeparador3
        '
        Me.btnSeparador3.Name = "btnSeparador3"
        Me.btnSeparador3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnNuevo
        '
        Me.btnNuevo.ImageIndex = 8
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Text = "N&uevo"
        Me.btnNuevo.ToolTipText = "Nueva consulta de pedidos programados"
        '
        'btnSeparador2
        '
        Me.btnSeparador2.Name = "btnSeparador2"
        Me.btnSeparador2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnRefrescar
        '
        Me.btnRefrescar.ImageIndex = 3
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Text = "R&efrescar"
        Me.btnRefrescar.ToolTipText = "Recarga la información mostrada"
        '
        'btnSeparador1
        '
        Me.btnSeparador1.Name = "btnSeparador1"
        Me.btnSeparador1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 5
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar la pantalla"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lblNoSuministrar)
        Me.GroupBox3.Controls.Add(Me.lblObservacionesProgramacion)
        Me.GroupBox3.Controls.Add(Me.grdProgramaCliente)
        Me.GroupBox3.Controls.Add(Me.lblRutaPedido)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.lblEstado)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.dtpFCarga)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.lblRutaCliente)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtObservacionCliente)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.lblGiro)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.lblUCarga)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.lblMunicipio)
        Me.GroupBox3.Controls.Add(Me.lblColonia)
        Me.GroupBox3.Controls.Add(Me.lblCalle)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.lblNombrePersonal)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.lblNombreFiscal)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.lblStatus)
        Me.GroupBox3.Location = New System.Drawing.Point(333, 43)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(401, 447)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'lblNoSuministrar
        '
        Me.lblNoSuministrar.AutoSize = True
        Me.lblNoSuministrar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoSuministrar.ForeColor = System.Drawing.Color.Red
        Me.lblNoSuministrar.Location = New System.Drawing.Point(264, 56)
        Me.lblNoSuministrar.Name = "lblNoSuministrar"
        Me.lblNoSuministrar.Size = New System.Drawing.Size(90, 13)
        Me.lblNoSuministrar.TabIndex = 166
        Me.lblNoSuministrar.Text = "No Suministrar"
        Me.lblNoSuministrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblNoSuministrar.Visible = False
        '
        'lblObservacionesProgramacion
        '
        Me.lblObservacionesProgramacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblObservacionesProgramacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblObservacionesProgramacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservacionesProgramacion.Location = New System.Drawing.Point(13, 307)
        Me.lblObservacionesProgramacion.Name = "lblObservacionesProgramacion"
        Me.lblObservacionesProgramacion.Size = New System.Drawing.Size(379, 16)
        Me.lblObservacionesProgramacion.TabIndex = 165
        '
        'grdProgramaCliente
        '
        Me.grdProgramaCliente.AlternatingBackColor = System.Drawing.Color.Lavender
        Me.grdProgramaCliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdProgramaCliente.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdProgramaCliente.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grdProgramaCliente.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdProgramaCliente.CaptionBackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProgramaCliente.CaptionForeColor = System.Drawing.Color.MidnightBlue
        Me.grdProgramaCliente.CaptionText = "Frecuencia"
        Me.grdProgramaCliente.DataMember = ""
        Me.grdProgramaCliente.FlatMode = True
        Me.grdProgramaCliente.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.grdProgramaCliente.ForeColor = System.Drawing.Color.MidnightBlue
        Me.grdProgramaCliente.GridLineColor = System.Drawing.Color.Gainsboro
        Me.grdProgramaCliente.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.grdProgramaCliente.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.grdProgramaCliente.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.grdProgramaCliente.HeaderForeColor = System.Drawing.Color.WhiteSmoke
        Me.grdProgramaCliente.LinkColor = System.Drawing.Color.Teal
        Me.grdProgramaCliente.Location = New System.Drawing.Point(13, 240)
        Me.grdProgramaCliente.Name = "grdProgramaCliente"
        Me.grdProgramaCliente.ParentRowsBackColor = System.Drawing.Color.Gainsboro
        Me.grdProgramaCliente.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.grdProgramaCliente.ParentRowsVisible = False
        Me.grdProgramaCliente.PreferredColumnWidth = 0
        Me.grdProgramaCliente.PreferredRowHeight = 0
        Me.grdProgramaCliente.ReadOnly = True
        Me.grdProgramaCliente.RowHeadersVisible = False
        Me.grdProgramaCliente.SelectionBackColor = System.Drawing.Color.CadetBlue
        Me.grdProgramaCliente.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.grdProgramaCliente.Size = New System.Drawing.Size(379, 67)
        Me.grdProgramaCliente.TabIndex = 164
        Me.grdProgramaCliente.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle2})
        Me.grdProgramaCliente.TabStop = False
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.ColumnHeadersVisible = False
        Me.DataGridTableStyle2.DataGrid = Me.grdProgramaCliente
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colProgTexto})
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle2.MappingName = "ProgramaCliente"
        Me.DataGridTableStyle2.PreferredColumnWidth = 0
        Me.DataGridTableStyle2.PreferredRowHeight = 0
        Me.DataGridTableStyle2.ReadOnly = True
        Me.DataGridTableStyle2.RowHeadersVisible = False
        Me.DataGridTableStyle2.RowHeaderWidth = 0
        '
        'colProgTexto
        '
        Me.colProgTexto.Format = ""
        Me.colProgTexto.FormatInfo = Nothing
        Me.colProgTexto.MappingName = "Texto"
        Me.colProgTexto.ReadOnly = True
        Me.colProgTexto.Width = 379
        '
        'lblRutaPedido
        '
        Me.lblRutaPedido.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRutaPedido.AutoSize = True
        Me.lblRutaPedido.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutaPedido.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblRutaPedido.Location = New System.Drawing.Point(288, 336)
        Me.lblRutaPedido.Name = "lblRutaPedido"
        Me.lblRutaPedido.Size = New System.Drawing.Size(85, 13)
        Me.lblRutaPedido.TabIndex = 163
        Me.lblRutaPedido.Text = "lblRutaPedido"
        Me.lblRutaPedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(248, 336)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(34, 13)
        Me.Label22.TabIndex = 162
        Me.Label22.Text = "Ruta:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEstado
        '
        Me.lblEstado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.Red
        Me.lblEstado.Location = New System.Drawing.Point(96, 336)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(58, 13)
        Me.lblEstado.TabIndex = 161
        Me.lblEstado.Text = "lblEstado"
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(13, 336)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(44, 13)
        Me.Label20.TabIndex = 160
        Me.Label20.Text = "Estado:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFCarga
        '
        Me.dtpFCarga.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFCarga.Location = New System.Drawing.Point(96, 360)
        Me.dtpFCarga.Name = "dtpFCarga"
        Me.dtpFCarga.Size = New System.Drawing.Size(200, 21)
        Me.dtpFCarga.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(13, 364)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 13)
        Me.Label19.TabIndex = 158
        Me.Label19.Text = "Fecha carga:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Location = New System.Drawing.Point(4, 321)
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
        Me.lblRutaCliente.Location = New System.Drawing.Point(286, 216)
        Me.lblRutaCliente.Name = "lblRutaCliente"
        Me.lblRutaCliente.Size = New System.Drawing.Size(86, 13)
        Me.lblRutaCliente.TabIndex = 156
        Me.lblRutaCliente.Text = "lblRutaCliente"
        Me.lblRutaCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(248, 216)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 155
        Me.Label4.Text = "Ruta:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtObservacionCliente
        '
        Me.txtObservacionCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservacionCliente.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtObservacionCliente.Location = New System.Drawing.Point(16, 410)
        Me.txtObservacionCliente.Name = "txtObservacionCliente"
        Me.txtObservacionCliente.ReadOnly = True
        Me.txtObservacionCliente.Size = New System.Drawing.Size(368, 21)
        Me.txtObservacionCliente.TabIndex = 154
        Me.txtObservacionCliente.TabStop = False
        '
        'Label17
        '
        Me.Label17.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(13, 391)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(78, 13)
        Me.Label17.TabIndex = 153
        Me.Label17.Text = "Observaciones"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGiro
        '
        Me.lblGiro.AutoSize = True
        Me.lblGiro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGiro.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblGiro.Location = New System.Drawing.Point(44, 216)
        Me.lblGiro.Name = "lblGiro"
        Me.lblGiro.Size = New System.Drawing.Size(36, 13)
        Me.lblGiro.TabIndex = 152
        Me.lblGiro.Text = "lblGiro"
        Me.lblGiro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 216)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 13)
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
        Me.lblUCarga.Size = New System.Drawing.Size(57, 13)
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
        Me.Label13.Size = New System.Drawing.Size(66, 13)
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
        Me.lblMunicipio.Size = New System.Drawing.Size(60, 13)
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
        Me.lblColonia.Size = New System.Drawing.Size(52, 13)
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
        Me.lblCalle.Size = New System.Drawing.Size(40, 13)
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
        Me.Label7.Size = New System.Drawing.Size(87, 13)
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
        Me.lblNombrePersonal.Size = New System.Drawing.Size(95, 13)
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
        Me.Label5.Size = New System.Drawing.Size(88, 13)
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
        Me.lblNombreFiscal.Size = New System.Drawing.Size(80, 13)
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
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 139
        Me.Label3.Text = "Nombre fiscal"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(220, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 149
        Me.Label6.Text = "Status:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblStatus.Location = New System.Drawing.Point(264, 16)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(57, 13)
        Me.lblStatus.TabIndex = 152
        Me.lblStatus.Text = "lblStatus"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.txtObservacionProg)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lblTotalProg)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dgProgramados)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 43)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(320, 447)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'txtObservacionProg
        '
        Me.txtObservacionProg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservacionProg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacionProg.Location = New System.Drawing.Point(4, 384)
        Me.txtObservacionProg.MaxLength = 250
        Me.txtObservacionProg.Multiline = True
        Me.txtObservacionProg.Name = "txtObservacionProg"
        Me.txtObservacionProg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservacionProg.Size = New System.Drawing.Size(312, 56)
        Me.txtObservacionProg.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 367)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "Observaciones"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalProg
        '
        Me.lblTotalProg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalProg.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalProg.Location = New System.Drawing.Point(240, 349)
        Me.lblTotalProg.Name = "lblTotalProg"
        Me.lblTotalProg.Size = New System.Drawing.Size(72, 13)
        Me.lblTotalProg.TabIndex = 139
        Me.lblTotalProg.Text = "0"
        Me.lblTotalProg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(52, 349)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 13)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "Total de contratos programados:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgProgramados
        '
        Me.dgProgramados.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.dgProgramados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgProgramados.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgProgramados.CaptionText = "Pedidos programados"
        Me.dgProgramados.DataMember = ""
        Me.dgProgramados.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgProgramados.Location = New System.Drawing.Point(3, 20)
        Me.dgProgramados.Name = "dgProgramados"
        Me.dgProgramados.ReadOnly = True
        Me.dgProgramados.Size = New System.Drawing.Size(316, 324)
        Me.dgProgramados.TabIndex = 0
        Me.dgProgramados.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.DataGridTableStyle1.DataGrid = Me.dgProgramados
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Contrato"
        Me.DataGridTextBoxColumn1.MappingName = "Cliente"
        Me.DataGridTextBoxColumn1.Width = 75
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Tel. Casa"
        Me.DataGridTextBoxColumn2.MappingName = "TelCasa"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.Width = 75
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Tel. 1"
        Me.DataGridTextBoxColumn3.MappingName = "TelAlterno1"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Tel. 2"
        Me.DataGridTextBoxColumn4.MappingName = "TelAlterno2"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnConfirmar.Image = CType(resources.GetObject("btnConfirmar.Image"), System.Drawing.Image)
        Me.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConfirmar.Location = New System.Drawing.Point(160, 536)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(96, 26)
        Me.btnConfirmar.TabIndex = 4
        Me.btnConfirmar.Text = "C&onfirmado"
        Me.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnNoConfirmar
        '
        Me.btnNoConfirmar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNoConfirmar.Image = CType(resources.GetObject("btnNoConfirmar.Image"), System.Drawing.Image)
        Me.btnNoConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNoConfirmar.Location = New System.Drawing.Point(320, 536)
        Me.btnNoConfirmar.Name = "btnNoConfirmar"
        Me.btnNoConfirmar.Size = New System.Drawing.Size(96, 26)
        Me.btnNoConfirmar.TabIndex = 5
        Me.btnNoConfirmar.Text = "&No confirmado"
        Me.btnNoConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnPosponer
        '
        Me.btnPosponer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPosponer.Image = CType(resources.GetObject("btnPosponer.Image"), System.Drawing.Image)
        Me.btnPosponer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPosponer.Location = New System.Drawing.Point(480, 536)
        Me.btnPosponer.Name = "btnPosponer"
        Me.btnPosponer.Size = New System.Drawing.Size(96, 26)
        Me.btnPosponer.TabIndex = 6
        Me.btnPosponer.Text = "&Posponer"
        Me.btnPosponer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(181, 498)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(82, 13)
        Me.Label21.TabIndex = 161
        Me.Label21.Text = "Motivo llamada:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboMotivoLlamada
        '
        Me.cboMotivoLlamada.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboMotivoLlamada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMotivoLlamada.Location = New System.Drawing.Point(272, 494)
        Me.cboMotivoLlamada.Name = "cboMotivoLlamada"
        Me.cboMotivoLlamada.Size = New System.Drawing.Size(288, 21)
        Me.cboMotivoLlamada.TabIndex = 3
        '
        'btnNotaTablero
        '
        Me.btnNotaTablero.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNotaTablero.BackColor = System.Drawing.SystemColors.Control
        Me.btnNotaTablero.Image = CType(resources.GetObject("btnNotaTablero.Image"), System.Drawing.Image)
        Me.btnNotaTablero.Location = New System.Drawing.Point(693, 491)
        Me.btnNotaTablero.Name = "btnNotaTablero"
        Me.btnNotaTablero.Size = New System.Drawing.Size(40, 24)
        Me.btnNotaTablero.TabIndex = 164
        Me.btnNotaTablero.TabStop = False
        Me.btnNotaTablero.UseVisualStyleBackColor = False
        '
        'btnNotaAgregar
        '
        Me.btnNotaAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNotaAgregar.BackColor = System.Drawing.SystemColors.Control
        Me.btnNotaAgregar.Image = CType(resources.GetObject("btnNotaAgregar.Image"), System.Drawing.Image)
        Me.btnNotaAgregar.Location = New System.Drawing.Point(613, 491)
        Me.btnNotaAgregar.Name = "btnNotaAgregar"
        Me.btnNotaAgregar.Size = New System.Drawing.Size(40, 24)
        Me.btnNotaAgregar.TabIndex = 162
        Me.btnNotaAgregar.TabStop = False
        Me.btnNotaAgregar.UseVisualStyleBackColor = False
        '
        'btnNotaCerrar
        '
        Me.btnNotaCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNotaCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnNotaCerrar.Image = CType(resources.GetObject("btnNotaCerrar.Image"), System.Drawing.Image)
        Me.btnNotaCerrar.Location = New System.Drawing.Point(653, 491)
        Me.btnNotaCerrar.Name = "btnNotaCerrar"
        Me.btnNotaCerrar.Size = New System.Drawing.Size(40, 24)
        Me.btnNotaCerrar.TabIndex = 163
        Me.btnNotaCerrar.TabStop = False
        Me.btnNotaCerrar.UseVisualStyleBackColor = False
        '
        'btnCerrar2
        '
        Me.btnCerrar2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar2.Location = New System.Drawing.Point(576, 16)
        Me.btnCerrar2.Name = "btnCerrar2"
        Me.btnCerrar2.Size = New System.Drawing.Size(8, 8)
        Me.btnCerrar2.TabIndex = 165
        '
        'Tiempo
        '
        '
        'frmConfirmaProgramados
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCerrar2
        Me.ClientSize = New System.Drawing.Size(744, 568)
        Me.Controls.Add(Me.btnNotaTablero)
        Me.Controls.Add(Me.btnNotaAgregar)
        Me.Controls.Add(Me.btnNotaCerrar)
        Me.Controls.Add(Me.cboMotivoLlamada)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.btnPosponer)
        Me.Controls.Add(Me.btnNoConfirmar)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BarraBotones)
        Me.Controls.Add(Me.btnCerrar2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConfirmaProgramados"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Confirmación de pedidos programados"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.grdProgramaCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgProgramados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Limpiar()
        lblStatus.Text = ""
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
        ActiveControl = dgProgramados
        btnPosponer.Enabled = False
        _Cliente = 0
        _TipoProg = 0
    End Sub

    'Valida que las fecha mostradas esten validas dependiendo de los privilegios del usuario
    Private Sub FechaActual()
        Dim oConsultaFechas As New PortatilClasses.Catalogo.ConsultaFechas(1, 0)
        If oConsultaFechas.drReader.Read() Then
            _FechaActual = CType(oConsultaFechas.drReader(0), DateTime)
        End If
        oConsultaFechas.CerrarConexion()
        oConsultaFechas = Nothing

    End Sub

#Region "Notas"
    Private Sub btnNotaAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles btnNotaAgregar.Click
        If _Cliente > 0 Then
            AgregarNota()
        End If
    End Sub

    Private Sub btnNotaCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles btnNotaCerrar.Click
        If _Cliente > 0 Then
            CerrarNotas()
        End If
    End Sub

    Private Sub btnNotaTablero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles btnNotaTablero.Click
        If _Cliente > 0 Then
            Notas()
        End If
    End Sub

    Private Sub AgregarNota()
        Dim oPostit As New SigaMetClasses.Postit(SigaMetClasses.Postit.enumTipoPostit.Cliente, _
                                        ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Usuario, Cliente:=_Cliente, Contenedor:=Me, Clave:=ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Password, Usuario:=ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Usuario)
        'Dim oPostit As New SigaMetClasses.Postit(SigaMetClasses.Postit.enumTipoPostit.Cliente, _
        '                                        GLOBAL_Usuario, Cliente:=_Cliente, Contenedor:=Me)
        oPostit.Show()
    End Sub

    Private Sub CerrarNotas()
        Cursor = Cursors.WaitCursor
        Dim p As SigaMetClasses.Postit
        For Each p In Me.OwnedForms
            p.Close()
        Next
        If Not IsNothing(p) Then
            p.Dispose()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Notas()
        Cursor = Cursors.WaitCursor
        Dim oTablero As New SigaMetClasses.PostitLista(SigaMetClasses.Postit.enumTipoPostit.Cliente, ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Usuario, True, True, cliente:=_Cliente)
        oTablero.ShowDialog()
        Cursor = Cursors.Default
    End Sub
#End Region

    Private Sub Llamada()
        If cboMotivoLlamada.SelectedIndex > 0 Then
            Dim cmdComando As New SqlCommand()
            Dim drReader As SqlDataReader
            Try
                cmdComando = New SqlCommand("sp_InsertaLlamada", ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Conexion)
                cmdComando.Parameters.Clear()
                cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = _Cliente
                cmdComando.Parameters.Add("@Observaciones", SqlDbType.Text).Value = txtObservacionProg.Text
                cmdComando.Parameters.Add("@TelefonoOrigen", SqlDbType.Char).Value = DBNull.Value
                cmdComando.Parameters.Add("@MotivoLlamada", SqlDbType.Int).Value = cboMotivoLlamada.Identificador
                cmdComando.Parameters.Add("@Celula", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@AñoPed", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@Pedido", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@Operador", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@Autotanque", SqlDbType.Int).Value = 0
                cmdComando.Parameters.Add("@Demandante", SqlDbType.Char).Value = DBNull.Value

                cmdComando.CommandType = CommandType.StoredProcedure
                ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Conexion.Open()
                drReader = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Conexion.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Consultas" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            cboMotivoLlamada.SelectedIndex = 0
        End If
    End Sub

    Private Sub ConsultaProgramacion(ByVal Configuracion As Short, ByVal Estado As Boolean)
        Dim oRegistrarProg As Consulta.cProgramacionBeta
        If Configuracion = 2 Then
            oRegistrarProg = New Consulta.cProgramacionBeta(2, _Cliente, _FechaContrato, txtObservacionProg.Text, True, ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Usuario)
        End If
        If Configuracion = 0 Then
            oRegistrarProg = New Consulta.cProgramacionBeta(0, _Cliente, _Fecha, txtObservacionProg.Text, Estado, ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Usuario)
            _FechaContrato = _Fecha
            dtpFCarga.Value = _Fecha
        End If
        If oRegistrarProg.drReader.Read Then
            lblEstado.Text = CType(oRegistrarProg.drReader(1), String)
            If Not IsDBNull(oRegistrarProg.drReader(2)) Then
                Me.ToolTip1.SetToolTip(Me.lblEstado, CType(oRegistrarProg.drReader(2), String))
            Else
                Me.ToolTip1.SetToolTip(Me.lblEstado, "")
            End If
            txtObservacionProg.Text = CType(oRegistrarProg.drReader(3), String)
            _TipoProg = CType(oRegistrarProg.drReader(4), Short)
        Else
            lblEstado.Text = ""
            Me.ToolTip1.SetToolTip(Me.lblEstado, "")
            txtObservacionProg.Text = ""
        End If
        HabilitarBotones()
        oRegistrarProg.CerrarConexion()
    End Sub

    Private Sub ConfirmarCliente(ByVal Index As Integer)
        Cursor = Cursors.WaitCursor
        If _Cliente > 0 Then
            Dim oProgramacion As New Consulta.cProgramacionBeta(1, _Cliente, _Fecha, txtObservacionProg.Text, True, ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Usuario)
            If oProgramacion.drReader.Read Then
                Dim Borrado As String
                Borrado = CType(oProgramacion.drReader(0), String)
                If Borrado = "DELETED" Then
                    ConsultaProgramacion(0, True)
                Else
                    ConsultaProgramacion(2, False)
                End If
            End If
            Llamada()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub NoConfirmarCliente(ByVal Index As Integer)
        Cursor = Cursors.WaitCursor
        If _Cliente > 0 Then
            Dim oProgramacion As New Consulta.cProgramacionBeta(1, _Cliente, _Fecha, txtObservacionProg.Text, False, ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Usuario)
            If oProgramacion.drReader.Read Then
                Dim Borrado As String
                Borrado = CType(oProgramacion.drReader(0), String)
                If Borrado = "DELETED" Then
                    ConsultaProgramacion(0, False)
                Else
                    ConsultaProgramacion(2, False)
                End If
            End If
            Llamada()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Posponer(ByVal Index As Integer)
        Cursor = Cursors.WaitCursor
        If _Cliente > 0 Then
            Dim oProgramacion As New Consulta.cProgramacionBeta(3, _Cliente, _Fecha, txtObservacionProg.Text, True, ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Usuario)
            Dim oProgramacionBorrar As New Consulta.cProgramacionBeta(1, _Cliente, dtpFCarga.Value.Date, txtObservacionProg.Text, False, ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Usuario)
            If oProgramacionBorrar.drReader.Read Then
                Dim Borrado As String
                Borrado = CType(oProgramacionBorrar.drReader(0), String)
                If Borrado = "DELETED" Then
                    Dim oRegistrarProg As New Consulta.cProgramacionBeta(0, _Cliente, dtpFCarga.Value.Date, txtObservacionProg.Text, False, ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Usuario)
                    oRegistrarProg = Nothing
                End If
            End If

            oProgramacion = Nothing

            CargardgProgramados()
            If dgProgramados.VisibleRowCount > Index Then
                dgProgramados.CurrentRowIndex = Index
            Else
                dgProgramados.CurrentRowIndex = dgProgramados.VisibleRowCount - 1
            End If
            Llamada()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub HabilitarBotones()
        If _TipoProg = 1 Then
            btnConfirmar.Enabled = False
            btnNoConfirmar.Enabled = False
        Else
            btnConfirmar.Enabled = True
            btnNoConfirmar.Enabled = True
        End If
        btnPosponer.Enabled = False
        If _Fecha < _FechaActual.Date Then
            btnConfirmar.Enabled = False
            btnNoConfirmar.Enabled = False
        End If
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
            If dt.Rows.Count > 0 Then
                grdProgramaCliente.DataSource = dt
            Else
                grdProgramaCliente.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            cmd.Dispose()
        End Try
        ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Conexion.Close()
    End Sub

    Private Sub CargarCliente(ByVal Index As Integer)        
        If (Index >= 0 AndAlso Not dgProgramados.DataSource Is Nothing) Then
            Cursor = Cursors.WaitCursor
            Limpiar()
            cboMotivoLlamada.SelectedIndex = 0

            Dim drClientes() As DataRow
            Dim drCliente As DataRow
            _Cliente = Convert.ToInt32(dgProgramados(Index, 0))
            drClientes = _dtTable.Select("Cliente=" & _Cliente)
            If (Not drClientes Is Nothing AndAlso drClientes.Length > 0) Then
                drCliente = drClientes(0)
                lblStatus.Text = CType(drCliente.Item(21), String).TrimEnd
                If Not IsDBNull(drCliente.Item(12)) Then
                    lblNombreFiscal.Text = CType(drCliente.Item(12), String).TrimEnd
                Else
                    lblNombreFiscal.Text = ""
                End If
                lblGiro.Text = CType(drCliente.Item(13), String).TrimEnd
                lblNoSuministrar.Visible = CType(drCliente.Item("NoSuministrar"), Boolean)

                CerrarNotas()

                lblNombrePersonal.Text = CType(drCliente.Item(1), String).Trim
                lblCalle.Text = CType(drCliente.Item(6), String) & " " & CType(drCliente.Item(2), String)
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
                dtpFCarga.Value = CType(drCliente.Item(15), DateTime)
                _FechaContrato = dtpFCarga.Value.Date
                If Not IsDBNull(drCliente.Item(17)) Then
                    lblRutaPedido.Text = CType(drCliente.Item(17), String)
                Else
                    lblRutaPedido.Text = ""
                End If
                _TipoProg = CType(drCliente.Item(20), Short)
                If _TipoProg = 1 Then
                    lblEstado.Text = CType(drCliente.Item(16), String)
                    txtObservacionProg.Text = CType(drCliente.Item(19), String)
                    If Not IsDBNull(drCliente.Item(18)) Then
                        Me.ToolTip1.SetToolTip(Me.lblEstado, CType(drCliente.Item(18), String))
                    Else
                        Me.ToolTip1.SetToolTip(Me.lblEstado, "")
                    End If
                Else
                    ConsultaProgramacion(2, True)
                End If

                HabilitarBotones()
                btnConfirmar.Enabled = True
                btnNoConfirmar.Enabled = True


                'If Main.CONFIG_AbreNotasClienteAuto Then
                SigaMetClasses.AbrePostitCliente(_Cliente, Me)
                Me.Refresh()
                'End If
                CargaProgramaCliente()
                Cursor = Cursors.Default
            End If
        End If

        'Cursor = Cursors.WaitCursor
        'Limpiar()
        'cboMotivoLlamada.SelectedIndex = 0

        '_Cliente = CType(_dtTable.Rows(Index).Item(0), Integer)
        'If Not IsDBNull(_dtTable.Rows(Index).Item(12)) Then
        '    lblNombreFiscal.Text = CType(_dtTable.Rows(Index).Item(12), String).TrimEnd
        'Else
        '    lblNombreFiscal.Text = ""
        'End If
        'CerrarNotas()

        'lblNombrePersonal.Text = CType(_dtTable.Rows(Index).Item(1), String).Trim
        'lblCalle.Text = CType(_dtTable.Rows(Index).Item(6), String) & " " & CType(_dtTable.Rows(Index).Item(2), String)
        'lblColonia.Text = CType(_dtTable.Rows(Index).Item(7), String)
        'lblMunicipio.Text = CType(_dtTable.Rows(Index).Item(8), String) & CType(_dtTable.Rows(Index).Item(9), String)

        'If Not IsDBNull(_dtTable.Rows(Index).Item(14)) Then
        '    Dim Fecha As DateTime
        '    Fecha = CType(_dtTable.Rows(Index).Item(14), Date)
        '    lblUCarga.Text = Fecha.ToLongDateString
        'Else
        '    lblUCarga.Text = "Sin carga"
        'End If
        'lblRutaCliente.Text = CType(_dtTable.Rows(Index).Item(11), String)

        'If Not IsDBNull(_dtTable.Rows(Index).Item(10)) Then
        '    txtObservacionCliente.Text = CType(_dtTable.Rows(Index).Item(10), String)
        'Else
        '    txtObservacionCliente.Clear()
        'End If
        'dtpFCarga.Value = CType(_dtTable.Rows(Index).Item(15), DateTime)
        '_FechaContrato = dtpFCarga.Value.Date
        'If Not IsDBNull(_dtTable.Rows(Index).Item(17)) Then
        '    lblRutaPedido.Text = CType(_dtTable.Rows(Index).Item(17), String)
        'Else
        '    lblRutaPedido.Text = ""
        'End If
        '_TipoProg = CType(_dtTable.Rows(Index).Item(20), Short)
        'If _TipoProg = 1 Then
        '    lblEstado.Text = CType(_dtTable.Rows(Index).Item(16), String)
        '    txtObservacionProg.Text = CType(_dtTable.Rows(Index).Item(19), String)
        '    If Not IsDBNull(_dtTable.Rows(Index).Item(18)) Then
        '        Me.ToolTip1.SetToolTip(Me.lblEstado, CType(_dtTable.Rows(Index).Item(18), String))
        '    Else
        '        Me.ToolTip1.SetToolTip(Me.lblEstado, "")
        '    End If
        'Else
        '    ConsultaProgramacion(2, True)
        'End If

        'HabilitarBotones()

        ''If Main.CONFIG_AbreNotasClienteAuto Then
        'SigaMetClasses.AbrePostitCliente(_Cliente, Me)
        'Me.Refresh()
        ''End If
        'CargaProgramaCliente()
        'Cursor = Cursors.Default
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

    Private Sub CargarLlamadas()
        If _Cliente > 0 Then
            Dim oLlamadas As New frmConsultaLlamada(_Cliente, lblNombrePersonal.Text)
            oLlamadas.ShowDialog()
            oLlamadas = Nothing
        End If
    End Sub

    Private Sub CargarBitacora()
        If _Cliente > 0 Then
            Dim oBitacora As New frmConsultaBitacora(_Cliente, lblNombrePersonal.Text)
            oBitacora.ShowDialog()
            oBitacora = Nothing
        End If
    End Sub

    Private Sub AnexarClientes()
        Dim oAnexar As New frmAnexarClientes(frmAnexarClientes.Operacion.TODOS, _Ruta, _FechaActual)
        oAnexar.ShowDialog()
        If oAnexar.ContratoAnexado Then
            CargardgProgramados()
        End If
        oAnexar = Nothing
    End Sub

    Private Sub AnexarRezagados()
        Dim oAnexar As New frmAnexarClientes(frmAnexarClientes.Operacion.REZAGADOS, _Ruta, _FechaActual)
        oAnexar.ShowDialog()
        If oAnexar.ContratoAnexado Then
            CargardgProgramados()
        End If
        oAnexar = Nothing
    End Sub

    Private Sub Modificar()
        If _Cliente > 0 Then
            Dim oCliente As New SigaMetClasses.ModificaCliente(_Cliente, ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Usuario, True, False, False, False, False, False, Nothing, False, False, "", True, False, ConfirmacionProgramados.Globals.GetInstance.GLOBAL_CadenaConexion)
            oCliente.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CargardgProgramados()
        dgProgramados.DataSource = Nothing
        Dim oClientes As New Consulta.cClientesProgramados(0, _Ruta, _Fecha)
        _dtTable = oClientes.dtTable
        dgProgramados.DataSource = _dtTable
        lblTotalProg.Text = CType(_dtTable.Rows.Count, String)
        If dgProgramados.VisibleRowCount > 0 Then
            CargarCliente(dgProgramados.CurrentRowIndex)
        Else
            Limpiar()
        End If
    End Sub

    Private Sub NuevaConsulta()
        Dim oRuta As New ConfirmacionProgramados.frmSeleccionaRuta()
        If oRuta.ShowDialog = DialogResult.OK Then
            _Fecha = oRuta.Fecha
            _Ruta = oRuta.Ruta
            Me.Text = "[" & oRuta.RutaNombre & " - " & _Fecha.ToShortDateString & "] - Confirmación de pedidos programados"
            CargardgProgramados()
        End If

    End Sub

    Private Sub frmConfirmaProgramados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Limpiar()
        FechaActual()
        cboMotivoLlamada.CargaDatosBase("spPTLCargaComboMotivoLLamada", 0, ConfirmacionProgramados.Globals.GetInstance.GLOBAL_Usuario)
        CargardgProgramados()
        cboMotivoLlamada.SelectedIndex = 0
        btnPosponer.Enabled = False
    End Sub

    Private Sub dgProgramados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles dgProgramados.KeyDown, dtpFCarga.KeyDown, cboMotivoLlamada.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub txtObservacionProg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles txtObservacionProg.KeyDown
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
                CargarLlamadas()
            Case 4
                CargarBitacora()
            Case 5
                AnexarClientes()
            Case 6
                AnexarRezagados()
            Case 7
                Modificar()
            Case 9
                NuevaConsulta()
            Case 11
                CargardgProgramados()
            Case 13
                Close()
        End Select
    End Sub



    Private Sub btnConfirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmar.Click
        ConfirmarCliente(dgProgramados.CurrentRowIndex)
    End Sub

    Private Sub btnNoConfirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNoConfirmar.Click
        NoConfirmarCliente(dgProgramados.CurrentRowIndex)
    End Sub

    Private Sub btnPosponer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPosponer.Click
        Posponer(dgProgramados.CurrentRowIndex)
    End Sub

    Private Sub dtpFCarga_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFCarga.TextChanged
        If dtpFCarga.Value.Date >= _FechaActual.Date And dtpFCarga.Value.Date <> _Fecha And _TipoProg <> 1 _
        And _Fecha.Date >= _FechaActual.Date Then
            btnPosponer.Enabled = True
        Else
            btnPosponer.Enabled = False
        End If
    End Sub

    Private Sub dgProgramados_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgProgramados.CurrentCellChanged
        If dgProgramados.VisibleRowCount > 0 Then
            CargarCliente(dgProgramados.CurrentRowIndex)
        Else
            Limpiar()
        End If
    End Sub

    Private Sub dgProgramados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgProgramados.Click
        Tiempo.Start()
    End Sub

    Private Sub Tiempo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tiempo.Tick
        Dim inti As Integer = 0

        Try
            Tiempo.Stop()

            For inti = 0 To _dtTable.Rows.Count
                If (Convert.ToInt32(dgProgramados.Item(inti, 0)) = _Cliente) Then
                    dgProgramados.CurrentRowIndex = inti
                    dgProgramados.Select(inti)
                    Call CargarCliente(inti)
                    Exit Sub
                End If
            Next
        Catch
            '
        End Try
    End Sub

End Class

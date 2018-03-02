Imports System.Data.SqlClient
Imports System.Xml

Public Class frmRelacionNotas
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal cnSigamet As SqlConnection)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.cnSigamet = cnSigamet

        cargaParametros()
        cargaParametros2()

        CargaRutasLiquidadas()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
            'cnSigamet.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents grpDatosRuta As System.Windows.Forms.GroupBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboRuta As System.Windows.Forms.ComboBox
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents lblOperador As System.Windows.Forms.Label
    Friend WithEvents txtOperador As System.Windows.Forms.TextBox
    Friend WithEvents txtCelula As System.Windows.Forms.TextBox
    Friend WithEvents spltPedidos As System.Windows.Forms.Splitter
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents cboFolio As System.Windows.Forms.ComboBox
    Friend WithEvents txtAutotanque As System.Windows.Forms.TextBox
    Friend WithEvents lblAutotanque As System.Windows.Forms.Label
    Friend WithEvents lsnNotasEscaneadas As RelacionNotas.ListadoNotas
    Friend WithEvents lblTituloPedidos As System.Windows.Forms.Label
    Friend WithEvents spltNotas As System.Windows.Forms.Splitter
    Friend WithEvents pnlToatlNotas As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents pnlConfirmacionNotas As System.Windows.Forms.Panel
    Friend WithEvents vgPedidos As RelacionNotas.ViewGrid
    Friend WithEvents txtNota As System.Windows.Forms.TextBox
    Friend WithEvents lsnNota As RelacionNotas.ListadoNotas
    Friend WithEvents btnEliminarNota As System.Windows.Forms.Button
    Friend WithEvents ttRelacionNotas As System.Windows.Forms.ToolTip
    Friend WithEvents pnlNotasRelacionadas As System.Windows.Forms.Panel
    Friend WithEvents lblNotasRelacionadas As System.Windows.Forms.Label
    Friend WithEvents lblNotas As System.Windows.Forms.Label
    Friend WithEvents lblNotasAutomaticas As System.Windows.Forms.Label
    Friend WithEvents lblNotasEscaneadas As System.Windows.Forms.Label
    Friend WithEvents chkMostrarTodos As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroNotasPL As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRelacionNotas))
        Me.grpDatosRuta = New System.Windows.Forms.GroupBox()
        Me.txtNumeroNotasPL = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkMostrarTodos = New System.Windows.Forms.CheckBox()
        Me.txtAutotanque = New System.Windows.Forms.TextBox()
        Me.lblAutotanque = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.txtCelula = New System.Windows.Forms.TextBox()
        Me.txtOperador = New System.Windows.Forms.TextBox()
        Me.lblOperador = New System.Windows.Forms.Label()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.cboFolio = New System.Windows.Forms.ComboBox()
        Me.cboRuta = New System.Windows.Forms.ComboBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.spltPedidos = New System.Windows.Forms.Splitter()
        Me.pnlToatlNotas = New System.Windows.Forms.Panel()
        Me.lsnNotasEscaneadas = New RelacionNotas.ListadoNotas()
        Me.lblNotasEscaneadas = New System.Windows.Forms.Label()
        Me.lblNotasAutomaticas = New System.Windows.Forms.Label()
        Me.pnlConfirmacionNotas = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblNotas = New System.Windows.Forms.Label()
        Me.vgPedidos = New RelacionNotas.ViewGrid()
        Me.lblTituloPedidos = New System.Windows.Forms.Label()
        Me.spltNotas = New System.Windows.Forms.Splitter()
        Me.pnlNotasRelacionadas = New System.Windows.Forms.Panel()
        Me.btnEliminarNota = New System.Windows.Forms.Button()
        Me.lsnNota = New RelacionNotas.ListadoNotas()
        Me.txtNota = New System.Windows.Forms.TextBox()
        Me.lblNotasRelacionadas = New System.Windows.Forms.Label()
        Me.ttRelacionNotas = New System.Windows.Forms.ToolTip(Me.components)
        Me.grpDatosRuta.SuspendLayout()
        Me.pnlToatlNotas.SuspendLayout()
        Me.pnlConfirmacionNotas.SuspendLayout()
        Me.pnlNotasRelacionadas.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDatosRuta
        '
        Me.grpDatosRuta.BackColor = System.Drawing.Color.White
        Me.grpDatosRuta.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtNumeroNotasPL, Me.Label1, Me.chkMostrarTodos, Me.txtAutotanque, Me.lblAutotanque, Me.btnCerrar, Me.btnCargar, Me.txtCelula, Me.txtOperador, Me.lblOperador, Me.lblCelula, Me.cboFolio, Me.cboRuta, Me.dtpFecha, Me.lblFolio, Me.lblRuta, Me.lblFecha})
        Me.grpDatosRuta.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpDatosRuta.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDatosRuta.ForeColor = System.Drawing.Color.MediumBlue
        Me.grpDatosRuta.Name = "grpDatosRuta"
        Me.grpDatosRuta.Size = New System.Drawing.Size(920, 123)
        Me.grpDatosRuta.TabIndex = 0
        Me.grpDatosRuta.TabStop = False
        Me.grpDatosRuta.Text = "Datos de la ruta"
        '
        'txtNumeroNotasPL
        '
        Me.txtNumeroNotasPL.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtNumeroNotasPL.BackColor = System.Drawing.Color.White
        Me.txtNumeroNotasPL.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNumeroNotasPL.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroNotasPL.ForeColor = System.Drawing.Color.DarkGreen
        Me.txtNumeroNotasPL.Location = New System.Drawing.Point(836, 96)
        Me.txtNumeroNotasPL.Name = "txtNumeroNotasPL"
        Me.txtNumeroNotasPL.ReadOnly = True
        Me.txtNumeroNotasPL.Size = New System.Drawing.Size(76, 20)
        Me.txtNumeroNotasPL.TabIndex = 16
        Me.txtNumeroNotasPL.TabStop = False
        Me.txtNumeroNotasPL.Text = ""
        '
        'Label1
        '
        Me.Label1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(752, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "#Notas:"
        '
        'chkMostrarTodos
        '
        Me.chkMostrarTodos.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMostrarTodos.Location = New System.Drawing.Point(448, 62)
        Me.chkMostrarTodos.Name = "chkMostrarTodos"
        Me.chkMostrarTodos.Size = New System.Drawing.Size(120, 24)
        Me.chkMostrarTodos.TabIndex = 14
        Me.chkMostrarTodos.Text = "Mostrar todos"
        '
        'txtAutotanque
        '
        Me.txtAutotanque.BackColor = System.Drawing.Color.White
        Me.txtAutotanque.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAutotanque.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAutotanque.ForeColor = System.Drawing.Color.DarkGreen
        Me.txtAutotanque.Location = New System.Drawing.Point(356, 64)
        Me.txtAutotanque.Name = "txtAutotanque"
        Me.txtAutotanque.ReadOnly = True
        Me.txtAutotanque.Size = New System.Drawing.Size(72, 20)
        Me.txtAutotanque.TabIndex = 11
        Me.txtAutotanque.TabStop = False
        Me.txtAutotanque.Text = "000"
        '
        'lblAutotanque
        '
        Me.lblAutotanque.AutoSize = True
        Me.lblAutotanque.Location = New System.Drawing.Point(236, 64)
        Me.lblAutotanque.Name = "lblAutotanque"
        Me.lblAutotanque.Size = New System.Drawing.Size(109, 20)
        Me.lblAutotanque.TabIndex = 10
        Me.lblAutotanque.Text = "Autotanque:"
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCerrar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.ForeColor = System.Drawing.Color.Black
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(832, 56)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(80, 24)
        Me.btnCerrar.TabIndex = 7
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttRelacionNotas.SetToolTip(Me.btnCerrar, "Salir")
        '
        'btnCargar
        '
        Me.btnCargar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCargar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargar.ForeColor = System.Drawing.Color.Black
        Me.btnCargar.Image = CType(resources.GetObject("btnCargar.Image"), System.Drawing.Bitmap)
        Me.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCargar.Location = New System.Drawing.Point(832, 28)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(80, 24)
        Me.btnCargar.TabIndex = 6
        Me.btnCargar.Text = "C&argar"
        Me.btnCargar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttRelacionNotas.SetToolTip(Me.btnCargar, "Cargar los pedidos del folio seleccionado.")
        '
        'txtCelula
        '
        Me.txtCelula.BackColor = System.Drawing.Color.White
        Me.txtCelula.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCelula.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCelula.ForeColor = System.Drawing.Color.DarkGreen
        Me.txtCelula.Location = New System.Drawing.Point(112, 64)
        Me.txtCelula.Name = "txtCelula"
        Me.txtCelula.ReadOnly = True
        Me.txtCelula.Size = New System.Drawing.Size(40, 20)
        Me.txtCelula.TabIndex = 9
        Me.txtCelula.TabStop = False
        Me.txtCelula.Text = "000"
        '
        'txtOperador
        '
        Me.txtOperador.BackColor = System.Drawing.Color.White
        Me.txtOperador.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOperador.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOperador.ForeColor = System.Drawing.Color.DarkGreen
        Me.txtOperador.Location = New System.Drawing.Point(112, 96)
        Me.txtOperador.Name = "txtOperador"
        Me.txtOperador.ReadOnly = True
        Me.txtOperador.Size = New System.Drawing.Size(455, 20)
        Me.txtOperador.TabIndex = 13
        Me.txtOperador.TabStop = False
        Me.txtOperador.Text = "-1111- Nombre del operador"
        '
        'lblOperador
        '
        Me.lblOperador.AutoSize = True
        Me.lblOperador.Location = New System.Drawing.Point(12, 96)
        Me.lblOperador.Name = "lblOperador"
        Me.lblOperador.Size = New System.Drawing.Size(89, 20)
        Me.lblOperador.TabIndex = 12
        Me.lblOperador.Text = "Operador:"
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Location = New System.Drawing.Point(12, 64)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(63, 20)
        Me.lblCelula.TabIndex = 8
        Me.lblCelula.Text = "Celula:"
        '
        'cboFolio
        '
        Me.cboFolio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFolio.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFolio.Location = New System.Drawing.Point(508, 29)
        Me.cboFolio.Name = "cboFolio"
        Me.cboFolio.Size = New System.Drawing.Size(118, 27)
        Me.cboFolio.TabIndex = 5
        '
        'cboRuta
        '
        Me.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRuta.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRuta.Location = New System.Drawing.Point(348, 29)
        Me.cboRuta.Name = "cboRuta"
        Me.cboRuta.Size = New System.Drawing.Size(88, 27)
        Me.cboRuta.TabIndex = 3
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFecha.Location = New System.Drawing.Point(112, 29)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(112, 27)
        Me.dtpFecha.TabIndex = 1
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Location = New System.Drawing.Point(448, 32)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(52, 20)
        Me.lblFolio.TabIndex = 4
        Me.lblFolio.Text = "F&olio:"
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.Location = New System.Drawing.Point(236, 32)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(51, 20)
        Me.lblRuta.TabIndex = 2
        Me.lblRuta.Text = "&Ruta:"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(12, 32)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(60, 20)
        Me.lblFecha.TabIndex = 0
        Me.lblFecha.Text = "&Fecha:"
        '
        'btnProcesar
        '
        Me.btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnProcesar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesar.ForeColor = System.Drawing.Color.Black
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Bitmap)
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcesar.Location = New System.Drawing.Point(70, 6)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(101, 27)
        Me.btnProcesar.TabIndex = 0
        Me.btnProcesar.Text = "&Procesar"
        Me.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttRelacionNotas.SetToolTip(Me.btnProcesar, "Procesar las notas capturadas.")
        '
        'spltPedidos
        '
        Me.spltPedidos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.spltPedidos.Location = New System.Drawing.Point(0, 682)
        Me.spltPedidos.Name = "spltPedidos"
        Me.spltPedidos.Size = New System.Drawing.Size(920, 3)
        Me.spltPedidos.TabIndex = 4
        Me.spltPedidos.TabStop = False
        '
        'pnlToatlNotas
        '
        Me.pnlToatlNotas.Controls.AddRange(New System.Windows.Forms.Control() {Me.lsnNotasEscaneadas, Me.lblNotasEscaneadas, Me.lblNotasAutomaticas, Me.pnlConfirmacionNotas, Me.lblNotas})
        Me.pnlToatlNotas.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlToatlNotas.Location = New System.Drawing.Point(680, 123)
        Me.pnlToatlNotas.Name = "pnlToatlNotas"
        Me.pnlToatlNotas.Size = New System.Drawing.Size(240, 559)
        Me.pnlToatlNotas.TabIndex = 3
        '
        'lsnNotasEscaneadas
        '
        Me.lsnNotasEscaneadas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsnNotasEscaneadas.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.lsnNotasEscaneadas.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsnNotasEscaneadas.ItemHeight = 19
        Me.lsnNotasEscaneadas.Location = New System.Drawing.Point(0, 72)
        Me.lsnNotasEscaneadas.Name = "lsnNotasEscaneadas"
        Me.lsnNotasEscaneadas.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lsnNotasEscaneadas.Size = New System.Drawing.Size(240, 407)
        Me.lsnNotasEscaneadas.TabIndex = 0
        '
        'lblNotasEscaneadas
        '
        Me.lblNotasEscaneadas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNotasEscaneadas.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblNotasEscaneadas.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotasEscaneadas.Location = New System.Drawing.Point(0, 48)
        Me.lblNotasEscaneadas.Name = "lblNotasEscaneadas"
        Me.lblNotasEscaneadas.Size = New System.Drawing.Size(240, 24)
        Me.lblNotasEscaneadas.TabIndex = 3
        Me.lblNotasEscaneadas.Text = "Escaneadas: 0"
        Me.lblNotasEscaneadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNotasAutomaticas
        '
        Me.lblNotasAutomaticas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNotasAutomaticas.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblNotasAutomaticas.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotasAutomaticas.Location = New System.Drawing.Point(0, 24)
        Me.lblNotasAutomaticas.Name = "lblNotasAutomaticas"
        Me.lblNotasAutomaticas.Size = New System.Drawing.Size(240, 24)
        Me.lblNotasAutomaticas.TabIndex = 2
        Me.lblNotasAutomaticas.Text = "Automáticas: 0"
        Me.lblNotasAutomaticas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlConfirmacionNotas
        '
        Me.pnlConfirmacionNotas.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnProcesar, Me.btnCancelar})
        Me.pnlConfirmacionNotas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlConfirmacionNotas.Enabled = False
        Me.pnlConfirmacionNotas.Location = New System.Drawing.Point(0, 479)
        Me.pnlConfirmacionNotas.Name = "pnlConfirmacionNotas"
        Me.pnlConfirmacionNotas.Size = New System.Drawing.Size(240, 80)
        Me.pnlConfirmacionNotas.TabIndex = 0
        '
        'btnCancelar
        '
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.Black
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(70, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(101, 27)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Ca&ncelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttRelacionNotas.SetToolTip(Me.btnCancelar, "Cancelar esta captura.")
        '
        'lblNotas
        '
        Me.lblNotas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNotas.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblNotas.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotas.Name = "lblNotas"
        Me.lblNotas.Size = New System.Drawing.Size(240, 24)
        Me.lblNotas.TabIndex = 1
        Me.lblNotas.Text = "Total de notas: 0"
        Me.lblNotas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'vgPedidos
        '
        Me.vgPedidos.AlternativeBackColor = System.Drawing.Color.AntiqueWhite
        Me.vgPedidos.BackColor = System.Drawing.Color.FloralWhite
        Me.vgPedidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vgPedidos.CheckCondition = CType(resources.GetObject("vgPedidos.CheckCondition"), System.Collections.ArrayList)
        Me.vgPedidos.DataSource = Nothing
        Me.vgPedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgPedidos.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vgPedidos.ForeColor = System.Drawing.Color.Black
        Me.vgPedidos.FormatColumnNames = New String(-1) {}
        Me.vgPedidos.FullRowSelect = True
        Me.vgPedidos.GridLines = True
        Me.vgPedidos.HidedColumnNames = New String() {"IDTipoPedido", "Repetido", "Codigo", "ClasificacionNota"}
        Me.vgPedidos.Location = New System.Drawing.Point(0, 147)
        Me.vgPedidos.MultiSelect = False
        Me.vgPedidos.Name = "vgPedidos"
        Me.vgPedidos.NullText = "--"
        Me.vgPedidos.PKColumnNames = Nothing
        Me.vgPedidos.SelectionBackColor = System.Drawing.Color.Orange
        Me.vgPedidos.SelectionForeColor = System.Drawing.Color.White
        Me.vgPedidos.Size = New System.Drawing.Size(677, 335)
        Me.vgPedidos.TabIndex = 1
        Me.vgPedidos.View = System.Windows.Forms.View.Details
        '
        'lblTituloPedidos
        '
        Me.lblTituloPedidos.BackColor = System.Drawing.Color.SteelBlue
        Me.lblTituloPedidos.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloPedidos.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloPedidos.ForeColor = System.Drawing.Color.White
        Me.lblTituloPedidos.Location = New System.Drawing.Point(0, 123)
        Me.lblTituloPedidos.Name = "lblTituloPedidos"
        Me.lblTituloPedidos.Size = New System.Drawing.Size(677, 24)
        Me.lblTituloPedidos.TabIndex = 10
        Me.lblTituloPedidos.Text = "    Pedidos liquidados"
        Me.lblTituloPedidos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'spltNotas
        '
        Me.spltNotas.Dock = System.Windows.Forms.DockStyle.Right
        Me.spltNotas.Location = New System.Drawing.Point(677, 123)
        Me.spltNotas.Name = "spltNotas"
        Me.spltNotas.Size = New System.Drawing.Size(3, 559)
        Me.spltNotas.TabIndex = 11
        Me.spltNotas.TabStop = False
        '
        'pnlNotasRelacionadas
        '
        Me.pnlNotasRelacionadas.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnEliminarNota, Me.lsnNota, Me.txtNota, Me.lblNotasRelacionadas})
        Me.pnlNotasRelacionadas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlNotasRelacionadas.Enabled = False
        Me.pnlNotasRelacionadas.Location = New System.Drawing.Point(0, 482)
        Me.pnlNotasRelacionadas.Name = "pnlNotasRelacionadas"
        Me.pnlNotasRelacionadas.Size = New System.Drawing.Size(677, 200)
        Me.pnlNotasRelacionadas.TabIndex = 2
        '
        'btnEliminarNota
        '
        Me.btnEliminarNota.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEliminarNota.Image = CType(resources.GetObject("btnEliminarNota.Image"), System.Drawing.Bitmap)
        Me.btnEliminarNota.Location = New System.Drawing.Point(424, 64)
        Me.btnEliminarNota.Name = "btnEliminarNota"
        Me.btnEliminarNota.Size = New System.Drawing.Size(24, 23)
        Me.btnEliminarNota.TabIndex = 2
        Me.btnEliminarNota.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ttRelacionNotas.SetToolTip(Me.btnEliminarNota, "Eliminar esta nota.")
        '
        'lsnNota
        '
        Me.lsnNota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lsnNota.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.lsnNota.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsnNota.ItemHeight = 19
        Me.lsnNota.Location = New System.Drawing.Point(214, 64)
        Me.lsnNota.Name = "lsnNota"
        Me.lsnNota.Size = New System.Drawing.Size(200, 116)
        Me.lsnNota.TabIndex = 1
        '
        'txtNota
        '
        Me.txtNota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNota.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNota.Location = New System.Drawing.Point(214, 32)
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(200, 30)
        Me.txtNota.TabIndex = 0
        Me.txtNota.Text = ""
        '
        'lblNotasRelacionadas
        '
        Me.lblNotasRelacionadas.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lblNotasRelacionadas.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblNotasRelacionadas.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotasRelacionadas.ForeColor = System.Drawing.Color.Navy
        Me.lblNotasRelacionadas.Name = "lblNotasRelacionadas"
        Me.lblNotasRelacionadas.Size = New System.Drawing.Size(677, 24)
        Me.lblNotasRelacionadas.TabIndex = 11
        Me.lblNotasRelacionadas.Text = "    Notas relacionadas"
        Me.lblNotasRelacionadas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmRelacionNotas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 20)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(920, 685)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.vgPedidos, Me.pnlNotasRelacionadas, Me.lblTituloPedidos, Me.spltNotas, Me.pnlToatlNotas, Me.spltPedidos, Me.grpDatosRuta})
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRelacionNotas"
        Me.Text = "Relación de notas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpDatosRuta.ResumeLayout(False)
        Me.pnlToatlNotas.ResumeLayout(False)
        Me.pnlConfirmacionNotas.ResumeLayout(False)
        Me.pnlNotasRelacionadas.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region "Estructuras y enumeradores"
    Private Enum Estado As Byte
        Esperando = 0
        Capturando = 1
        Procesado = 2
    End Enum

    Public Enum TipoNota As Byte
        Automatica = 0
        Escaneada = 1
    End Enum

    Public Enum ClasificacionNota As Byte
        Remision = 1
        NotaBlanca = 2
        Edificio = 3
        Especial = 4
    End Enum

    Public Structure NotaPedido
        Dim CodigoNota As String
        Dim PedidoReferencia As String
        Dim Tipo As TipoNota
        Public ClasificacionNota As ClasificacionNota
        Public Sub New(ByVal CodigoNota As String, ByVal PedidoReferencia As String, ByVal Tipo As TipoNota, _
            Byval ClasificacionNota as ClasificacionNota)
            Me.CodigoNota = CodigoNota
            Me.PedidoReferencia = PedidoReferencia
            Me.Tipo = Tipo
            Me.ClasificacionNota = ClasificacionNota
        End Sub
        Public Overrides Function ToString() As String
            Return Me.CodigoNota
        End Function
    End Structure

    Public Structure Nota
        Public Status As String
        Public NotaActiva As Boolean
        Public Operador As Integer
        Public PedidoActivo As Boolean
        Public ExisteNota As Boolean
        Public MotivoNotaInvalida As String
        Public ClasificacionNota As ClasificacionNota
    End Structure

    Public Structure ValidacionNota
        Public Resultado As Boolean
        Public Nota As Nota
    End Structure
#End Region
#Region "Variables globales"
    Private EstadoActual As Estado = Estado.Esperando
    Private dtFolios As New DataTable()
    Private RelacionNotaPedido As New ArrayList()
    Private cnSigamet As SqlConnection
    Private PedidoReferencia As String

    Private dtParametros As New DataTable()

    Private _escaneoSerie As Boolean

    Private _operador As Integer
#End Region
#Region "Rutinas de manejo de la conexión"
    Private Sub AbreConexion()
        If cnSigamet.State <> ConnectionState.Open Then
            cnSigamet.Open()
        End If
    End Sub
    Private Sub CierraConexion()
        If cnSigamet.State <> ConnectionState.Closed Then
            cnSigamet.Close()
        End If
    End Sub
#End Region
#Region "Rutinas de mensajes de error"
    Private Sub ErrorMessage(ByVal Mensaje As String)
        MessageBox.Show(Mensaje, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
    Private Sub ErrorMessage(ByVal ex As Exception)
        MessageBox.Show("Ha ocurrido el siguiente error:" & Chr(13) & ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
#End Region
#Region "Rutinas de actualización y carga de datos"
    Private Sub cargaParametros()
        Dim daParam As New SqlDataAdapter("spRNConsultaParametros", cnSigamet)
        daParam.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim PK(0) As DataColumn
        Try
            Me.Cursor = Cursors.WaitCursor
            dtParametros.Clear()
            daParam.Fill(dtParametros)

            PK(0) = dtParametros.Columns("Parametro")
            dtParametros.PrimaryKey = PK

        Catch ex As SqlException
            ErrorMessage(ex)
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
        End Try
    End Sub

    Private Sub cargaParametros2()
        Try
            _escaneoSerie = CType(dtParametros.Rows.Find("EscaneoSerieRemision").Item("Valor"), Boolean)
        Catch ex As SqlException
            ErrorMessage(ex)
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
        End Try
    End Sub

    Private Sub CargaRutasLiquidadas()
        Dim daRN As New SqlDataAdapter("spRNRutasLiquidadas", cnSigamet)
        Dim dtRutas As New DataTable()
        Dim PK(0) As DataColumn
        daRN.SelectCommand.CommandType = CommandType.StoredProcedure
        daRN.SelectCommand.Parameters.Add("@FPreliquidacion", SqlDbType.DateTime).Value = dtpFecha.Value.Date
        daRN.SelectCommand.Parameters.Add("@Todas", SqlDbType.Bit).Value = chkMostrarTodos.Checked
        Try
            Me.Cursor = Cursors.WaitCursor
            dtFolios.Clear()
            daRN.Fill(dtFolios)
            PK(0) = dtFolios.Columns("Folio")
            dtFolios.PrimaryKey = PK

            dtRutas = FiltrarTabla(dtFolios)

            cboRuta.ValueMember = "Ruta"
            cboRuta.DisplayMember = "Ruta"
            cboRuta.DataSource = dtRutas
        Catch ex As SqlException
            ErrorMessage(ex)
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub CargaFoliosRuta()
        If Not cboRuta.SelectedItem Is Nothing Then
            Dim vwFolios As New DataView()
            vwFolios = dtFolios.Copy.DefaultView
            vwFolios.RowFilter = "Ruta = " & CStr(cboRuta.SelectedValue)
            cboFolio.ValueMember = "Folio"
            cboFolio.DisplayMember = "Folio"
            cboFolio.DataSource = vwFolios
        Else
            cboFolio.DataSource = Nothing
        End If
    End Sub
    Private Sub CargaDatosFolio()
        Dim rw As DataRow = dtFolios.Rows.Find(cboFolio.SelectedValue)
        If Not rw Is Nothing Then
            txtCelula.Text = CStr(rw("Celula"))
            txtOperador.Text = CStr(rw("Operador"))
            txtAutotanque.Text = CStr(rw("Autotanque"))
            _operador = Convert.ToInt32(rw("CveOperador")) '130709 Validar que la nota pertenezca al operador
        End If
    End Sub
    Private Sub CargaPedidosFolio()
        Dim daRN As New SqlDataAdapter("spRNPedidosPorRelacionar", cnSigamet)
        Dim rw As DataRow = dtFolios.Rows.Find(cboFolio.SelectedValue)
        Dim dtNotaPedido As New DataTable()
        Dim vwPedidos As New DataView()
        Dim AnioAtt As Short
        Dim Folio As Integer
        If Not rw Is Nothing Then
            If (chkMostrarTodos.Checked) Then
                daRN.SelectCommand.CommandText = "spRNPedidosPorRelacionarCompleto"
            End If

            daRN.SelectCommand.CommandType = CommandType.StoredProcedure
            daRN.SelectCommand.Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = CInt(rw("AñoAtt"))
            daRN.SelectCommand.Parameters.Add("@Folio", SqlDbType.Int).Value = CInt(rw("Folio"))
            daRN.SelectCommand.CommandTimeout = 360

            Try
                Me.Cursor = Cursors.WaitCursor
                daRN.Fill(dtNotaPedido)
                vwPedidos = dtNotaPedido.Copy.DefaultView
                vwPedidos.RowFilter = "Repetido = 0"
                vgPedidos.DataSource = vwPedidos
                CargaListadoNotas(dtNotaPedido)

                EstadoActual = Estado.Capturando
                grpDatosRuta.Enabled = False
                pnlConfirmacionNotas.Enabled = True
                pnlNotasRelacionadas.Enabled = True
                txtNota.Clear()

                If vgPedidos.Items.Count > 0 Then
                    vgPedidos.Items(0).Selected = True
                    vgPedidos.Focus()
                    CapturaNotaPedido()
                Else
                    MessageBox.Show("Todos los pedidos de esta liquidación han sido relacionados.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    AnioAtt = Convert.ToInt16(rw("AñoAtt"))
                    Folio = Convert.ToInt16(rw("Folio"))
                    Limpiar()
                End If
            Catch ex As SqlException
                ErrorMessage(ex)
            Catch ex As Exception
                ErrorMessage(ex)
            Finally
                Me.Cursor = Cursors.Default
            End Try

            'ConsultarNumeroNotasPreliquidacion(Convert.ToInt16(rw("AñoAtt")), Convert.ToInt32(rw("Folio")))
            ConsultarNumeroNotasPreliquidacion(AnioAtt, Folio)

        End If
    End Sub
    Private Sub CargaListadoNotas(ByVal TablaPedidos As DataTable)
        Dim rw As DataRow
        RelacionNotaPedido.Clear()
        For Each rw In TablaPedidos.Rows
            If CStr(rw("Codigo")) <> String.Empty Then
                RelacionNotaPedido.Add(New NotaPedido(CStr(rw("Codigo")), CStr(rw("PedidoReferencia")), TipoNota.Automatica, _
                    CType(rw("ClasificacionNota"), ClasificacionNota)))
            End If
        Next
        MuestraListadoNotas()
    End Sub
    Private Sub MuestraListadoNotas()
        Dim NP As NotaPedido
        Dim NAuto, NEsc As Integer
        lblNotas.Text = "Total de notas: " & RelacionNotaPedido.Count.ToString
        lsnNotasEscaneadas.Items.Clear()
        For Each NP In RelacionNotaPedido
            lsnNotasEscaneadas.Items.Add(NP)
            If NP.Tipo = TipoNota.Automatica Then
                NAuto += 1
            Else
                NEsc += 1
            End If
        Next
        lblNotasAutomaticas.Text = "Automáticas: " & NAuto.ToString
        lblNotasEscaneadas.Text = "Escaneadas: " & NEsc.ToString
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        CargaRutasLiquidadas()
    End Sub
    Private Sub cboRuta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRuta.SelectedIndexChanged
        CargaFoliosRuta()
    End Sub
    Private Sub cboFolio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFolio.SelectedIndexChanged
        CargaDatosFolio()
    End Sub
#End Region

    Private Sub CapturaNotaPedido()
        Dim vwNotas As New DataView()
        Dim index As Integer = Nothing
        Dim NP As NotaPedido
        lsnNota.Items.Clear()
        lblNotasRelacionadas.Text = "Notas relacionadas"
        If PedidoReferencia <> String.Empty Then
            lblNotasRelacionadas.Text &= " al pedido " & PedidoReferencia
            For Each NP In RelacionNotaPedido
                If NP.CodigoNota <> String.Empty AndAlso NP.PedidoReferencia = PedidoReferencia Then
                    lsnNota.Items.Add(NP)
                End If
            Next
        End If
        lblNotasRelacionadas.Text &= ": " & lsnNota.Items.Count.ToString
        txtNota.Focus()
        txtNota.Clear()
        txtNota.SelectAll()
    End Sub


    'Private Function ValidaNotaCapturada(ByVal CodigoNota As String) As Boolean
    Private Function ValidaNotaCapturada(ByVal CodigoNota As String) As ValidacionNota
        Dim Validacion As ValidacionNota = Nothing
        Dim NP As NotaPedido
        Dim Motivo As String
        Dim _nota As Nota

        If ((CodigoNota.Substring(0, 1) > "A" AndAlso CodigoNota.Substring(0, 1) < "Z") _
            OrElse Not _escaneoSerie) _
           AndAlso Char.IsNumber(CodigoNota.Substring(1), 0) Then
            Try
                _nota = ConsultaDatosNota(CodigoNota)

                If _nota.Operador <> 0 AndAlso _nota.Operador <> _operador Then
                    If MessageBox.Show("Esta nota pertenece al operador " & _nota.Operador & "," & vbCrLf & _
                        "¿Desea relacionarla al operador de esta ruta?", _
                        "Pertenece a otro operador", MessageBoxButtons.YesNo, _
                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.No Then

                        '
                        Validacion.Resultado = False
                        Return Validacion
                        '
                    End If
                End If

                If Not _nota.ExisteNota Then
                    'ErrorMessage("La nota no existe o ya ha sido escaneada en otra liquidación." & Chr(13) & "Verifique")
                    Motivo = _nota.MotivoNotaInvalida
                    If Motivo.Trim = "fue cancelada" Then
                        Validacion.Resultado = MessageBox.Show("La nota está cancelada." & Chr(13) & "¿Desea asociarle el pedido y modificar su status?", _
                                            Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes
                        Return Validacion
                    Else
                        ErrorMessage("La nota " & Motivo & Chr(13) & "Verifique")

                        '
                        Validacion.Resultado = False
                        Return Validacion
                        '
                    End If
                End If
                For Each NP In RelacionNotaPedido
                    If NP.CodigoNota = CodigoNota Then
                        ErrorMessage("La nota ya ha sido relacionada al pedido " & NP.PedidoReferencia.Trim & ".")

                        '
                        Validacion.Resultado = False
                        Return Validacion
                        '
                    End If
                Next
                '
                Validacion.Resultado = True
                Validacion.Nota = _nota
                Return Validacion
                '
            Catch ex As SqlException
                ErrorMessage(ex.Message)

                '
                Validacion.Resultado = False
                Return Validacion
                '
            Catch ex As Exception
                ErrorMessage(ex.Message)

                '
                Validacion.Resultado = False
                Return Validacion
                '
            Finally
                CierraConexion()
            End Try
        Else
            ErrorMessage("El código capturado no pertenece a una nota.")
            '
            Validacion.Resultado = False
            Return Validacion
            '
        End If
    End Function

    Private Sub AgregaNota(ByVal PedidoReferencia As String, ByVal CodigoNota As String, ByVal ClasificacionNota as ClasificacionNota)
        Dim NP As New NotaPedido(CodigoNota, PedidoReferencia, TipoNota.Escaneada, ClasificacionNota)
        RelacionNotaPedido.Add(NP)
        lsnNota.Items.Add(NP)
        EscribeNotaEnGrid()
        txtNota.Clear()
        lblNotasRelacionadas.Text = "Notas relacionadas al pedido " & PedidoReferencia & ": " & lsnNota.Items.Count.ToString
        MuestraListadoNotas()
    End Sub
    Private Sub EliminaNota(ByVal PedidoReferencia As String, ByVal CodigoNota As String)
        RelacionNotaPedido.Remove(lsnNota.SelectedItem)
        lsnNota.Items.RemoveAt(lsnNota.SelectedIndex)
        EscribeNotaEnGrid()
        MuestraListadoNotas()
    End Sub

    Private Sub EscribeNotaEnGrid()
        Dim itm As ListViewItem.ListViewSubItem = vgPedidos.SelectedItems(0).SubItems(8)
        Dim NP As NotaPedido
        itm.Text = String.Empty
        For Each NP In lsnNota.Items
            itm.Text &= NP.CodigoNota & ", "
        Next
        If itm.Text <> String.Empty Then
            itm.Text = itm.Text.Substring(0, itm.Text.Length - 2)
        End If
        vgPedidos.CurrentRow("Nota") = itm.Text
    End Sub

    Private Function BuscaCodigoNota(ByVal PedidoReferencia As String) As String
        Dim NP As NotaPedido
        For Each NP In lsnNota.Items
            If NP.PedidoReferencia = PedidoReferencia Then
                Return NP.CodigoNota
            End If
        Next
        Return String.Empty
    End Function

    Private Function ExistePedidoSinNota() As Boolean
        Dim rw As DataRow
        Dim NP As NotaPedido
        Dim Relacion As Boolean
        For Each rw In CType(vgPedidos.DataSource, DataTable).Rows
            Relacion = False
            For Each NP In RelacionNotaPedido
                If NP.PedidoReferencia = CStr(rw("PedidoReferencia")) Then
                    Relacion = True
                    Exit For
                End If
            Next
            If Not Relacion Then
                Return Not MessageBox.Show("Existen pedidos sin nota relacionada." & Chr(13) & "¿Desea continuar?", Application.StartupPath & " v." & Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes
            End If
        Next
        Return False
    End Function

    Private Function CadenaRelacionNotaPedido() As String
        Dim NP As NotaPedido
        Dim Cadena As String = Nothing
        For Each NP In RelacionNotaPedido
            Cadena &= NP.PedidoReferencia & ", " & NP.CodigoNota & ", "
        Next
        Return Cadena
    End Function

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        CargaPedidosFolio()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MessageBox.Show("¿Desea cancelar la captura actual?", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Limpiar()
        End If
    End Sub

    Private Sub Limpiar()
        grpDatosRuta.Enabled = True
        pnlConfirmacionNotas.Enabled = False
        pnlNotasRelacionadas.Enabled = False
        txtNota.Clear()

        txtNumeroNotasPL.Text = String.Empty

        RelacionNotaPedido.Clear()
        vgPedidos.DataSource = Nothing
        PedidoReferencia = String.Empty
        MuestraListadoNotas()
        CapturaNotaPedido()
        CargaRutasLiquidadas()
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub vgPedidos_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles vgPedidos.MouseUp
        CapturaNotaPedido()
    End Sub

    Private Sub frmRelacionNotas_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        lsnNota.Left = CInt((pnlNotasRelacionadas.Width - lsnNota.Width) / 2)
        txtNota.Left = lsnNota.Left
        btnEliminarNota.Left = lsnNota.Left + lsnNota.Width + 25
    End Sub

    Private Sub txtNota_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNota.KeyUp
        Select Case e.KeyCode
            'Case Keys.Enter
            '    If txtNota.Text = String.Empty AndAlso vgPedidos.SelectedIndices(0) < vgPedidos.Items.Count - 1 Then
            '        vgPedidos.Items(vgPedidos.SelectedIndices(0) + 1).Selected = True
            '    ElseIf Not txtNota.Text = String.Empty Then
            '        If ValidaNotaCapturada(txtNota.Text) AndAlso PedidoReferencia <> String.Empty Then
            '            AgregaNota(PedidoReferencia, txtNota.Text)
            '            If Not e.Shift AndAlso vgPedidos.SelectedIndices(0) < vgPedidos.Items.Count - 1 Then
            '                vgPedidos.Items(vgPedidos.SelectedIndices(0) + 1).Selected = True
            '            End If
            '        Else
            '            txtNota.Focus()
            '            txtNota.SelectAll()
            '        End If
            '    End If
        Case Keys.Up
                If vgPedidos.SelectedIndices(0) > 0 Then
                    vgPedidos.Items(vgPedidos.SelectedIndices(0) - 1).Selected = True
                    vgPedidos.SelectedItems(0).EnsureVisible()
                End If
            Case Keys.Down
                If vgPedidos.SelectedIndices(0) < vgPedidos.Items.Count - 1 Then
                    vgPedidos.Items(vgPedidos.SelectedIndices(0) + 1).Selected = True
                    vgPedidos.SelectedItems(0).EnsureVisible()
                End If
        End Select
    End Sub

    Private Sub vgPedidos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vgPedidos.SelectedIndexChanged
        Dim rw As DataRow = vgPedidos.CurrentRow
        If Not rw Is Nothing Then
            PedidoReferencia = CStr(rw("PedidoReferencia"))
            CapturaNotaPedido()
        Else
            PedidoReferencia = String.Empty
        End If
    End Sub

    Private Sub btnEliminarNota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarNota.Click
        If lsnNota.SelectedIndex > -1 AndAlso PedidoReferencia <> String.Empty Then
            EliminaNota(PedidoReferencia, lsnNota.SelectedItem.ToString)
        End If
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        'Notificar al usuario que está capturando menos notas de las requeridas.
        If (ContarNotaBlanca() <> Convert.ToInt32(IIf(txtNumeroNotasPL.Text.Length > 0, txtNumeroNotasPL.Text, "0"))) Then
            If MessageBox.Show("El número de notas capturadas por preliquidación (" & txtNumeroNotasPL.Text & ")" & vbCrLf & _
                "es diferente del número de notas escaneadas (" & ContarNotaBlanca().ToString() & ")." & vbCrLf & _
                "¿Desea continuar la captura?", "Reposición", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Return
            End If
        End If
        '
        If Not ExistePedidoSinNota() Then
            Dim Relaciones As String = CadenaRelacionNotaPedido()
            Dim cmdNR As New SqlCommand("spRNRelacionaNotaPedido", cnSigamet)
            Dim trNR As SqlTransaction = Nothing
            cmdNR.CommandTimeout = 360
            cmdNR.CommandType = CommandType.StoredProcedure
            cmdNR.Parameters.Add("@Relaciones", SqlDbType.Char).Value = CadenaRelacionNotaPedido()
            Try
                AbreConexion()
                trNR = cnSigamet.BeginTransaction(IsolationLevel.ReadCommitted)
                cmdNR.Transaction = trNR
                cmdNR.ExecuteNonQuery()
                trNR.Commit()
                Limpiar()
            Catch ex As SqlException
                If Not trNR Is Nothing Then
                    trNR.Rollback()
                End If
                ErrorMessage(ex)
            Catch ex As Exception
                If Not trNR Is Nothing Then
                    trNR.Rollback()
                End If
                ErrorMessage(ex)
            Finally
                CierraConexion()
            End Try
        End If

    End Sub

    Private Function FiltrarTabla(ByVal Datos As DataTable) As DataTable
        Dim dtSource As New DataTable()
        Dim rw, frw As DataRow
        Dim cl(0) As DataColumn
        Dim IArray(0) As Object
        dtSource.Columns.Add("Ruta")
        cl(0) = dtSource.Columns("Ruta")
        dtSource.PrimaryKey = cl
        For Each rw In Datos.Rows
            frw = dtSource.Rows.Find(rw("Ruta"))
            If frw Is Nothing Then
                IArray(0) = rw("Ruta")
                dtSource.Rows.Add(IArray)
            End If
        Next
        Return dtSource
    End Function

    Private Sub txtNota_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNota.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If txtNota.Text = String.Empty AndAlso vgPedidos.SelectedIndices(0) < vgPedidos.Items.Count - 1 Then
                vgPedidos.Items(vgPedidos.SelectedIndices(0) + 1).Selected = True
            ElseIf Not txtNota.Text = String.Empty Then
                'Validación del resultado de la nota
                Dim VN As ValidacionNota = ValidaNotaCapturada(txtNota.Text)
                If VN.Resultado AndAlso PedidoReferencia <> String.Empty Then
                    AgregaNota(PedidoReferencia, txtNota.Text, VN.Nota.ClasificacionNota)
                    If vgPedidos.SelectedIndices(0) < vgPedidos.Items.Count - 1 Then
                        vgPedidos.Items(vgPedidos.SelectedIndices(0) + 1).Selected = True
                    End If
                Else
                    txtNota.Focus()
                    txtNota.SelectAll()
                End If
            End If
        End If
    End Sub

    Private Sub chkMostrarTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMostrarTodos.CheckedChanged
        Limpiar()
    End Sub

    Private Sub grpDatosRuta_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpDatosRuta.Enter

    End Sub

    Private Function ConsultaDatosNota(ByVal CodigoNota As String) As Nota
        Dim _nota As Nota = Nothing

        Dim cmdRN As SqlCommand = New SqlCommand("spRNConsultaNota1", cnSigamet)
        cmdRN.CommandType = CommandType.StoredProcedure
        Dim cmdRDR As SqlDataReader = Nothing

        If _escaneoSerie Then
            cmdRN.Parameters.Add("@Serie", SqlDbType.Char).Value = CodigoNota.Substring(0, 1)
            cmdRN.Parameters.Add("@FolioNota", SqlDbType.Int).Value = CInt(CodigoNota.Substring(1))
        Else
            cmdRN.Parameters.Add("@Serie", SqlDbType.Char).Value = String.Empty
            cmdRN.Parameters.Add("@FolioNota", SqlDbType.Int).Value = CInt(CodigoNota)
        End If

        Try
            AbreConexion()
            cmdRDR = cmdRN.ExecuteReader()

            While (cmdRDR.Read())
                _nota.Status = Convert.ToString(cmdRDR("Status"))
                _nota.Operador = Convert.ToInt32(cmdRDR("Operador"))
                _nota.NotaActiva = Convert.ToBoolean(cmdRDR("NotaActiva"))
                _nota.PedidoActivo = Convert.ToBoolean(cmdRDR("PedidoActivo"))
                _nota.ExisteNota = Convert.ToBoolean(cmdRDR("ExisteNota"))
                _nota.MotivoNotaInvalida = Convert.ToString(cmdRDR("MotivoNotaInvalida"))
                'Clasificación de la nota para saber cuantas notas blancas se relacionaron.
                _nota.ClasificacionNota = DirectCast(cmdRDR("TipoNota"), ClasificacionNota)
            End While
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cmdRDR.Close()
            CierraConexion()
        End Try

        Return _nota
    End Function

    Private Sub ConsultarNumeroNotasPreliquidacion(ByVal AñoAtt As Short, ByVal Folio As Integer)
        Dim cmdRN As SqlCommand = New SqlCommand("spRNNotasCapturadasPreliquidacion", cnSigamet)
        Dim cmdRDR As SqlDataReader = Nothing
        cmdRN.CommandType = CommandType.StoredProcedure
        cmdRN.Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = AñoAtt
        cmdRN.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
        Try
            AbreConexion()
            cmdRDR = cmdRN.ExecuteReader()
            While (cmdRDR.Read())
                txtNumeroNotasPL.Text = Convert.ToString(cmdRDR("NumeroNotas"))
            End While
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cmdRDR.Close()
            CierraConexion()
        End Try
    End Sub

    'Contar las notas blancas para asegurar que todas fueron capturadas, se compara contra lo capturado en el área anterior
    Public Function ContarNotaBlanca() As Integer
        Dim notasBlancas As Integer = 0
        Dim NP As NotaPedido
        For Each NP In RelacionNotaPedido
            If NP.ClasificacionNota = ClasificacionNota.NotaBlanca Then
                notasBlancas += 1
            End If
        Next
        Return notasBlancas
    End Function

#Region "Unused 13072009"
    'Private Function ValidaNotaCapturada(ByVal CodigoNota As String) As Boolean
    '    Dim cmdRN As SqlCommand
    '    Dim NP As NotaPedido
    '    Dim Motivo As String
    '    If ((CodigoNota.Substring(0, 1) > "A" AndAlso CodigoNota.Substring(0, 1) < "Z") _
    '        OrElse Not _escaneoSerie) _
    '       AndAlso Char.IsNumber(CodigoNota.Substring(1), 0) Then
    '        cmdRN = New SqlCommand("Select dbo.ExisteNota(@Serie, @FolioNota)", cnSigamet)

    '        If _escaneoSerie Then
    '            cmdRN.Parameters.Add("@Serie", SqlDbType.Char).Value = CodigoNota.Substring(0, 1)
    '            cmdRN.Parameters.Add("@FolioNota", SqlDbType.Int).Value = CInt(CodigoNota.Substring(1))
    '        Else
    '            cmdRN.Parameters.Add("@Serie", SqlDbType.Char).Value = String.Empty
    '            cmdRN.Parameters.Add("@FolioNota", SqlDbType.Int).Value = CInt(CodigoNota)
    '        End If
    '        Try
    '            AbreConexion()
    '            If Not CBool(cmdRN.ExecuteScalar) Then
    '                'ErrorMessage("La nota no existe o ya ha sido escaneada en otra liquidación." & Chr(13) & "Verifique")
    '                cmdRN.CommandText = "Select dbo.MotivoNotaInvalida(@Serie, @FolioNota)"
    '                Motivo = cmdRN.ExecuteScalar().ToString()
    '                If Motivo.Trim = "fue cancelada" Then
    '                    Return MessageBox.Show("La nota está cancelada." & Chr(13) & "¿Desea asociarle el pedido y modificar su status?", _
    '                                        Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes
    '                Else
    '                    ErrorMessage("La nota " & Motivo & Chr(13) & "Verifique")
    '                    Return False
    '                End If
    '            End If
    '            For Each NP In RelacionNotaPedido
    '                If NP.CodigoNota = CodigoNota Then
    '                    ErrorMessage("La nota ya ha sido relacionada al pedido " & NP.PedidoReferencia.Trim & ".")
    '                    Return False
    '                End If
    '            Next
    '            Return True
    '        Catch ex As SqlException
    '            ErrorMessage(ex.Message)
    '            Return False
    '        Catch ex As Exception
    '            ErrorMessage(ex.Message)
    '            Return False
    '        Finally
    '            CierraConexion()
    '        End Try
    '    Else
    '        ErrorMessage("El código capturado no pertenece a una nota.")
    '        Return False
    '    End If
    'End Function
#End Region
End Class

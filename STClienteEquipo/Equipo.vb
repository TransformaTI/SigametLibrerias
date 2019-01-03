Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class Equipo
    Inherits System.Windows.Forms.Form
    Private _Equipo As Short
    Private _EquipoDescripcion As String
    Private _Precio As Decimal
    Private _Titulo As String = "Equipo"

    'seagregaron las variables
    Private _FFabricacion As DateTime
    Private _Serie As String
    Private _FInicioComodato As DateTime
    Private _FFinComodato As DateTime
    Private _Status As String
    Private _Consumo As Integer

    Public ReadOnly Property Equipo() As Short
        Get
            Return _Equipo
        End Get
    End Property

    Public ReadOnly Property EquipoDescripcion() As String
        Get
            Return _EquipoDescripcion
        End Get
    End Property

    Public ReadOnly Property Precio() As Decimal
        Get
            Return _Precio
        End Get
    End Property

    'se agregaron las propiedades
    Public ReadOnly Property FFabricacion() As DateTime
        Get
            Return _FFabricacion
        End Get
    End Property

    Public ReadOnly Property Serie() As String
        Get
            Return _Serie
        End Get
    End Property

    Public ReadOnly Property FInicioComoddato() As DateTime
        Get
            Return _FInicioComodato
        End Get
    End Property

    Public ReadOnly Property FFinComodato() As DateTime
        Get
            Return _FFinComodato
        End Get
    End Property

    Public ReadOnly Property Status() As String
        Get
            Return _Status
        End Get
    End Property

    Public ReadOnly Property Consumo() As Integer
        Get
            Return _Consumo
        End Get
    End Property

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
    Friend WithEvents img16 As System.Windows.Forms.ImageList
    Friend WithEvents ttEquipo As System.Windows.Forms.ToolTip
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lvwEquipo As System.Windows.Forms.ListView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblMarcaEquipo As System.Windows.Forms.Label
    Friend WithEvents lblTipoEquipo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCapacidad As System.Windows.Forms.Label
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents lblCosto As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbBarra As System.Windows.Forms.ToolBar
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolBarButton
    Friend WithEvents dtpFFabricacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtserie As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtConsumo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpFFinComodato As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpFInicioComodato As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Equipo))
        Me.img16 = New System.Windows.Forms.ImageList(Me.components)
        Me.ttEquipo = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lvwEquipo = New System.Windows.Forms.ListView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblMarcaEquipo = New System.Windows.Forms.Label()
        Me.lblTipoEquipo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCapacidad = New System.Windows.Forms.Label()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.lblCosto = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbBarra = New System.Windows.Forms.ToolBar()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.btnEliminar = New System.Windows.Forms.ToolBarButton()
        Me.btnSep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.dtpFFabricacion = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtserie = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.txtConsumo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpFFinComodato = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpFInicioComodato = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'img16
        '
        Me.img16.ImageStream = CType(resources.GetObject("img16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.img16.TransparentColor = System.Drawing.Color.Transparent
        Me.img16.Images.SetKeyName(0, "")
        Me.img16.Images.SetKeyName(1, "")
        Me.img16.Images.SetKeyName(2, "")
        Me.img16.Images.SetKeyName(3, "")
        Me.img16.Images.SetKeyName(4, "")
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(494, 32)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(494, 64)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'lvwEquipo
        '
        Me.lvwEquipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwEquipo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvwEquipo.Location = New System.Drawing.Point(8, 48)
        Me.lvwEquipo.Name = "lvwEquipo"
        Me.lvwEquipo.Size = New System.Drawing.Size(216, 155)
        Me.lvwEquipo.SmallImageList = Me.img16
        Me.lvwEquipo.TabIndex = 0
        Me.lvwEquipo.UseCompatibleStateImageBehavior = False
        Me.lvwEquipo.View = System.Windows.Forms.View.List
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(240, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(224, 21)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Información del equipo"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.lblMarcaEquipo)
        Me.Panel1.Controls.Add(Me.lblTipoEquipo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblCapacidad)
        Me.Panel1.Controls.Add(Me.lblPrecio)
        Me.Panel1.Controls.Add(Me.lblCosto)
        Me.Panel1.Location = New System.Drawing.Point(240, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(224, 155)
        Me.Panel1.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 123)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Marca:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Tipo:"
        '
        'lblMarcaEquipo
        '
        Me.lblMarcaEquipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblMarcaEquipo.Location = New System.Drawing.Point(80, 120)
        Me.lblMarcaEquipo.Name = "lblMarcaEquipo"
        Me.lblMarcaEquipo.Size = New System.Drawing.Size(104, 21)
        Me.lblMarcaEquipo.TabIndex = 16
        Me.lblMarcaEquipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTipoEquipo
        '
        Me.lblTipoEquipo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblTipoEquipo.Location = New System.Drawing.Point(80, 96)
        Me.lblTipoEquipo.Name = "lblTipoEquipo"
        Me.lblTipoEquipo.Size = New System.Drawing.Size(104, 21)
        Me.lblTipoEquipo.TabIndex = 15
        Me.lblTipoEquipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Capacidad:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Precio:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Costo:"
        '
        'lblCapacidad
        '
        Me.lblCapacidad.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCapacidad.Location = New System.Drawing.Point(80, 70)
        Me.lblCapacidad.Name = "lblCapacidad"
        Me.lblCapacidad.Size = New System.Drawing.Size(104, 21)
        Me.lblCapacidad.TabIndex = 11
        Me.lblCapacidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPrecio
        '
        Me.lblPrecio.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblPrecio.Location = New System.Drawing.Point(80, 46)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(104, 21)
        Me.lblPrecio.TabIndex = 10
        Me.lblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCosto
        '
        Me.lblCosto.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCosto.Location = New System.Drawing.Point(80, 22)
        Me.lblCosto.Name = "lblCosto"
        Me.lblCosto.Size = New System.Drawing.Size(104, 21)
        Me.lblCosto.TabIndex = 9
        Me.lblCosto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(8, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(216, 21)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Lista de equipos"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbBarra
        '
        Me.tbBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAgregar, Me.btnModificar, Me.btnEliminar, Me.btnSep1, Me.btnRefrescar})
        Me.tbBarra.ButtonSize = New System.Drawing.Size(18, 18)
        Me.tbBarra.DropDownArrows = True
        Me.tbBarra.ImageList = Me.img16
        Me.tbBarra.Location = New System.Drawing.Point(0, 0)
        Me.tbBarra.Name = "tbBarra"
        Me.tbBarra.ShowToolTips = True
        Me.tbBarra.Size = New System.Drawing.Size(576, 28)
        Me.tbBarra.TabIndex = 18
        '
        'btnAgregar
        '
        Me.btnAgregar.ImageIndex = 1
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Tag = "Agregar"
        Me.btnAgregar.ToolTipText = "Agregar equipo"
        '
        'btnModificar
        '
        Me.btnModificar.Enabled = False
        Me.btnModificar.ImageIndex = 3
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Tag = "Modificar"
        Me.btnModificar.ToolTipText = "Modificar equipo"
        '
        'btnEliminar
        '
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.ImageIndex = 2
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Tag = "Eliminar"
        Me.btnEliminar.ToolTipText = "Eliminar equipo"
        '
        'btnSep1
        '
        Me.btnSep1.Name = "btnSep1"
        Me.btnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnRefrescar
        '
        Me.btnRefrescar.ImageIndex = 4
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Tag = "Refrescar"
        Me.btnRefrescar.ToolTipText = "Refrescar información"
        '
        'dtpFFabricacion
        '
        Me.dtpFFabricacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFFabricacion.Location = New System.Drawing.Point(120, 224)
        Me.dtpFFabricacion.Name = "dtpFFabricacion"
        Me.dtpFFabricacion.Size = New System.Drawing.Size(104, 21)
        Me.dtpFFabricacion.TabIndex = 298
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 224)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 13)
        Me.Label13.TabIndex = 297
        Me.Label13.Text = "FFabricación:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtserie
        '
        Me.txtserie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtserie.Location = New System.Drawing.Point(352, 224)
        Me.txtserie.Name = "txtserie"
        Me.txtserie.Size = New System.Drawing.Size(112, 21)
        Me.txtserie.TabIndex = 296
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(248, 224)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 13)
        Me.Label14.TabIndex = 295
        Me.Label14.Text = "Serie:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(248, 288)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 13)
        Me.Label9.TabIndex = 308
        Me.Label9.Text = "Consumo Lts:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboStatus
        '
        Me.cboStatus.Items.AddRange(New Object() {"PENDIENTE", "CANCELADO"})
        Me.cboStatus.Location = New System.Drawing.Point(120, 288)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(104, 21)
        Me.cboStatus.TabIndex = 307
        Me.cboStatus.Text = "PENDIENTE"
        '
        'txtConsumo
        '
        Me.txtConsumo.Location = New System.Drawing.Point(352, 288)
        Me.txtConsumo.Name = "txtConsumo"
        Me.txtConsumo.Size = New System.Drawing.Size(112, 21)
        Me.txtConsumo.TabIndex = 306
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 288)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 305
        Me.Label10.Text = "Status:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dtpFFinComodato
        '
        Me.dtpFFinComodato.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFFinComodato.Location = New System.Drawing.Point(352, 256)
        Me.dtpFFinComodato.Name = "dtpFFinComodato"
        Me.dtpFFinComodato.Size = New System.Drawing.Size(112, 21)
        Me.dtpFFinComodato.TabIndex = 304
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(248, 256)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 13)
        Me.Label11.TabIndex = 303
        Me.Label11.Text = "FFinComodato:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dtpFInicioComodato
        '
        Me.dtpFInicioComodato.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFInicioComodato.Location = New System.Drawing.Point(120, 256)
        Me.dtpFInicioComodato.Name = "dtpFInicioComodato"
        Me.dtpFInicioComodato.Size = New System.Drawing.Size(104, 21)
        Me.dtpFInicioComodato.TabIndex = 302
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 256)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(105, 13)
        Me.Label12.TabIndex = 301
        Me.Label12.Text = "FInicioComodato:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Equipo
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(576, 318)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.txtConsumo)
        Me.Controls.Add(Me.dtpFFinComodato)
        Me.Controls.Add(Me.dtpFInicioComodato)
        Me.Controls.Add(Me.dtpFFabricacion)
        Me.Controls.Add(Me.txtserie)
        Me.Controls.Add(Me.tbBarra)
        Me.Controls.Add(Me.lvwEquipo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(482, 290)
        Me.Name = "Equipo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Equipo"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Sub New(ByVal SoloSeleccion As Boolean)
        MyBase.New()
        InitializeComponent()
        If SoloSeleccion = True Then
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.tbBarra.Visible = False
            Me.MinimizeBox = False
            Me.MaximizeBox = False
        End If
    End Sub

    Private Sub CargaDatos()
        Cursor = Cursors.WaitCursor
        lvwEquipo.Items.Clear()
        LimpiaDatos()
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        Dim strQuery As String = "Select * from vwEquipo"
        Dim da As New SqlDataAdapter(strQuery, cnSigamet)
        Dim dt As New DataTable("Equipo")
        Try
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow
                For Each dr In dt.Rows
                    Dim oEquipo As New cEquipo()
                    With oEquipo
                        .Equipo = CType(dr("Equipo"), Short)
                        .Descripcion = CType(dr("Descripcion"), String)
                        If Not IsDBNull(dr("Costo")) Then .Costo = CType(dr("Costo"), Decimal)
                        If Not IsDBNull(dr("Precio")) Then .Precio = CType(dr("Precio"), Decimal)
                        If Not IsDBNull(dr("Capacidad")) Then .Capacidad = CType(dr("Capacidad"), Integer)
                        If Not IsDBNull(dr("TipoEquipo")) Then .TipoEquipo = CType(dr("TipoEquipo"), Byte)
                        If Not IsDBNull(dr("TipoEquipoDescripcion")) Then .TipoEquipoDescripcion = CType(dr("TipoEquipoDescripcion"), String)
                        If Not IsDBNull(dr("MarcaEquipo")) Then .MarcaEquipo = CType(dr("MarcaEquipo"), Byte)
                        If Not IsDBNull(dr("MarcaEquipoDescripcion")) Then .MarcaEquipoDescripcion = CType(dr("MarcaEquipoDescripcion"), String)
                        .ImageIndex = 0
                        .Text = oEquipo.Descripcion
                    End With

                    lvwEquipo.Items.Add(oEquipo)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LimpiaDatos()
        lblCosto.Text = String.Empty
        lblPrecio.Text = String.Empty
        lblCapacidad.Text = String.Empty
        lblTipoEquipo.Text = String.Empty
        lblMarcaEquipo.Text = String.Empty
    End Sub

    Private Sub Equipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFInicioComodato.MinDate = Now.Date
        CargaDatos()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        'MessageBox.Show(Me.Equipo.ToString)
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
		'SE AGREGO PARA COMPLETAR INFORMACION DEL COMODATO

		_FFabricacion = dtpFFabricacion.Value
		_Serie = txtserie.Text
        _FInicioComodato = dtpFInicioComodato.Value
        _FFinComodato = dtpFFinComodato.Value
		_Status = CType(cboStatus.SelectedItem, String)
		Try
			_Consumo = CType(txtConsumo.Text, Integer)
		Catch ex As Exception
			MessageBox.Show("Consumo no tiene un valor válido")
			Return
		End Try

		Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub lvwEquipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwEquipo.SelectedIndexChanged
        On Error Resume Next
        _Equipo = CType(lvwEquipo.FocusedItem, cEquipo).Equipo
        '_EquipoDescripcion = lvwEquipo.FocusedItem.Text
        lblCosto.Text = CType(lvwEquipo.FocusedItem, cEquipo).Costo.ToString("N")
        lblPrecio.Text = CType(lvwEquipo.FocusedItem, cEquipo).Precio.ToString("N")
        lblCapacidad.Text = CType(lvwEquipo.FocusedItem, cEquipo).Capacidad.ToString
        lblTipoEquipo.Text = CType(lvwEquipo.FocusedItem, cEquipo).TipoEquipoDescripcion
        lblMarcaEquipo.Text = CType(lvwEquipo.FocusedItem, cEquipo).MarcaEquipoDescripcion
        _Precio = CType(CType(lvwEquipo.FocusedItem, cEquipo).Precio.ToString, Decimal)
        '_Precio = CType(txtPrecio.Text, Decimal)
        _EquipoDescripcion = lvwEquipo.FocusedItem.Text & " Importe: " & _Precio.ToString("N")


        btnEliminar.Enabled = True
        btnModificar.Enabled = True
    End Sub

    Private Sub lvwEquipo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwEquipo.DoubleClick
        If Not lvwEquipo.FocusedItem Is Nothing Then
            Me.DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub tbBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case "Agregar"
                Dim frmCaptura As New EquipoCaptura()
                If frmCaptura.ShowDialog() = DialogResult.OK Then
                    CargaDatos()
                End If
            Case "Modificar"
                Dim frmCaptura As New EquipoCaptura(CType(lvwEquipo.FocusedItem, cEquipo).Equipo)
                If frmCaptura.ShowDialog() = DialogResult.OK Then
                    CargaDatos()
                End If
            Case "Eliminar"
                If MessageBox.Show("¿Esta seguro que desea eliminar el equipo " & Chr(13) & CType(lvwEquipo.FocusedItem, cEquipo).Descripcion & "?", _Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Dim oEquipo As cEquipo
                    Try
                        oEquipo = New cEquipo()
                        oEquipo.Eliminar(CType(lvwEquipo.FocusedItem, cEquipo).Equipo)
                        CargaDatos()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        oEquipo = Nothing
                    End Try
                End If
            Case "Refrescar"
                CargaDatos()
        End Select
    End Sub

    Private Sub txtPrecio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Trim(txtPrecio.Text) <> "" Then
        '    _Precio = CType(txtPrecio.Text, Decimal)
        'Else
        '    _Precio = 0
        'End If
        _EquipoDescripcion = lvwEquipo.FocusedItem.Text & " Importe: " & _Precio.ToString("N")
    End Sub

    Private Sub txtConsumo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConsumo.KeyPress
        If Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Then e.Handled = False Else e.Handled = True
    End Sub
End Class

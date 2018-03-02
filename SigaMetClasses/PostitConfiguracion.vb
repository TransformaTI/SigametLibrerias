Option Strict On

Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing


Public Class PostitConfiguracion
    Inherits System.Windows.Forms.Form

    Private _FInicio As Date
    Private _FTermino As Date
    Private _Permanente As Boolean
    Private _Alarma As Boolean
    Private _NotaColor As String
    Private _FontName As String
    Private _FontSize As Single
    Private _FontColor As String

    Private _HaCambiado As Boolean = False
    Private _DatosCargados As Boolean = False


#Region "Propiedades"
    Public ReadOnly Property FInicio() As Date
        Get
            Return _FInicio
        End Get
    End Property

    Public ReadOnly Property FTermino() As Date
        Get
            Return _FTermino
        End Get
    End Property

    Public ReadOnly Property Permanente() As Boolean
        Get
            Return _Permanente
        End Get
    End Property

    Public ReadOnly Property Alarma() As Boolean
        Get
            Return _Alarma
        End Get
    End Property

    Public ReadOnly Property NotaColor() As String
        Get
            Return _NotaColor
        End Get
    End Property

    Public ReadOnly Property FontName() As String
        Get
            Return _FontName
        End Get
    End Property

    Public ReadOnly Property FontSize() As Single
        Get
            Return _FontSize
        End Get
    End Property

    Public ReadOnly Property FontColor() As String
        Get
            Return _FontColor
        End Get
    End Property

    Public ReadOnly Property HaCambiado() As Boolean
        Get
            Return _HaCambiado
        End Get
    End Property
#End Region
    

    Public Sub New(ByVal FInicio As Date, _
                   ByVal FTermino As Date, _
                   ByVal Permanente As Boolean, _
                   ByVal Alarma As Boolean, _
                   ByVal Color As String, _
                   ByVal FontName As String, _
                   ByVal FontSize As Single, _
                   ByVal FontColor As String)

        'Modificación

        MyBase.New()
        InitializeComponent()

        _FInicio = FInicio
        _FTermino = FTermino
        _Permanente = Permanente
        _Alarma = Alarma
        _NotaColor = Color

        _FontName = FontName
        _FontSize = FontSize
        _FontColor = FontColor

        dtpFInicio.Value = _FInicio
        dtpFTermino.Value = _FTermino

        dtpFInicio.MinDate = _FInicio
        dtpFTermino.MinDate = _FInicio

        chkPermanente.Checked = _Permanente
        chkAlarma.Checked = _Alarma

        Eventos()

        MuestraFont()

        CargaSeleccionColor(Color)

        _DatosCargados = True

    End Sub

    Private Sub CargaSeleccionColor(ByVal strColor As String)
        Dim p As Panel
        For Each p In pnlColor.Controls
            If Replace(Replace(p.BackColor.ToString, "Color [", ""), "]", "") = strColor Then
                Limpia()
                p.BorderStyle = BorderStyle.FixedSingle
            End If
        Next
    End Sub


#Region " Windows Form Designer generated code "


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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents dtpFInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFTermino As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkPermanente As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents dlgFont As System.Windows.Forms.FontDialog
    Friend WithEvents lblFont As System.Windows.Forms.Label
    Friend WithEvents chkAlarma As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TaskPane1 As VbPowerPack.TaskPane
    Friend WithEvents TaskFrame1 As VbPowerPack.TaskFrame
    Friend WithEvents TaskFrame2 As VbPowerPack.TaskFrame
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lnkSeleccionaFuente As System.Windows.Forms.LinkLabel
    Friend WithEvents pnlColor As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PostitConfiguracion))
        Me.dtpFInicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpFTermino = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.chkPermanente = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.dlgFont = New System.Windows.Forms.FontDialog()
        Me.lblFont = New System.Windows.Forms.Label()
        Me.chkAlarma = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TaskPane1 = New VbPowerPack.TaskPane()
        Me.TaskFrame1 = New VbPowerPack.TaskFrame()
        Me.TaskFrame2 = New VbPowerPack.TaskFrame()
        Me.pnlColor = New System.Windows.Forms.Panel()
        Me.lnkSeleccionaFuente = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TaskPane1.SuspendLayout()
        Me.TaskFrame1.SuspendLayout()
        Me.TaskFrame2.SuspendLayout()
        Me.pnlColor.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpFInicio
        '
        Me.dtpFInicio.Location = New System.Drawing.Point(16, 32)
        Me.dtpFInicio.Name = "dtpFInicio"
        Me.dtpFInicio.Size = New System.Drawing.Size(216, 21)
        Me.dtpFInicio.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.dtpFInicio, "Fecha de inicio de la nota")
        '
        'dtpFTermino
        '
        Me.dtpFTermino.Location = New System.Drawing.Point(16, 80)
        Me.dtpFTermino.Name = "dtpFTermino"
        Me.dtpFTermino.Size = New System.Drawing.Size(216, 21)
        Me.dtpFTermino.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.dtpFTermino, "Fecha de término de la nota")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha de inicio:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha de término:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(72, 416)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(160, 416)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkPermanente
        '
        Me.chkPermanente.Checked = True
        Me.chkPermanente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPermanente.Location = New System.Drawing.Point(16, 120)
        Me.chkPermanente.Name = "chkPermanente"
        Me.chkPermanente.Size = New System.Drawing.Size(208, 16)
        Me.chkPermanente.TabIndex = 6
        Me.chkPermanente.Text = "La nota es permanente"
        Me.ToolTip1.SetToolTip(Me.chkPermanente, "Indica si la nota es permanente")
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LemonChiffon
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(24, 24)
        Me.Panel1.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Panel2.Location = New System.Drawing.Point(24, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(24, 24)
        Me.Panel2.TabIndex = 8
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Thistle
        Me.Panel3.Location = New System.Drawing.Point(48, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(24, 24)
        Me.Panel3.TabIndex = 9
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.PeachPuff
        Me.Panel4.Location = New System.Drawing.Point(72, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(24, 24)
        Me.Panel4.TabIndex = 10
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.LightCyan
        Me.Panel5.Location = New System.Drawing.Point(96, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(24, 24)
        Me.Panel5.TabIndex = 11
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel6.Location = New System.Drawing.Point(120, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(24, 24)
        Me.Panel6.TabIndex = 12
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.LightCoral
        Me.Panel7.Location = New System.Drawing.Point(144, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(24, 24)
        Me.Panel7.TabIndex = 13
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.LightPink
        Me.Panel8.Location = New System.Drawing.Point(168, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(24, 24)
        Me.Panel8.TabIndex = 14
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.White
        Me.Panel9.Location = New System.Drawing.Point(192, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(24, 24)
        Me.Panel9.TabIndex = 15
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.LavenderBlush
        Me.Panel10.Location = New System.Drawing.Point(216, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(24, 24)
        Me.Panel10.TabIndex = 16
        '
        'dlgFont
        '
        Me.dlgFont.AllowScriptChange = False
        Me.dlgFont.AllowVectorFonts = False
        Me.dlgFont.AllowVerticalFonts = False
        Me.dlgFont.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dlgFont.FontMustExist = True
        Me.dlgFont.MaxSize = 26
        Me.dlgFont.MinSize = 7
        Me.dlgFont.ShowColor = True
        Me.dlgFont.ShowEffects = False
        '
        'lblFont
        '
        Me.lblFont.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFont.Location = New System.Drawing.Point(16, 88)
        Me.lblFont.Name = "lblFont"
        Me.lblFont.Size = New System.Drawing.Size(256, 40)
        Me.lblFont.TabIndex = 0
        Me.lblFont.Text = "Tahoma 8"
        '
        'chkAlarma
        '
        Me.chkAlarma.Location = New System.Drawing.Point(16, 152)
        Me.chkAlarma.Name = "chkAlarma"
        Me.chkAlarma.Size = New System.Drawing.Size(208, 16)
        Me.chkAlarma.TabIndex = 19
        Me.chkAlarma.Text = "Alarma"
        Me.ToolTip1.SetToolTip(Me.chkAlarma, "Indica si la nota es una alarma")
        '
        'TaskPane1
        '
        Me.TaskPane1.AutoScroll = True
        Me.TaskPane1.BackColor = System.Drawing.Color.DarkGray
        Me.TaskPane1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TaskFrame1, Me.TaskFrame2})
        Me.TaskPane1.CornerStyle = VbPowerPack.TaskFrameCornerStyle.SystemDefault
        Me.TaskPane1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TaskPane1.Name = "TaskPane1"
        Me.TaskPane1.Size = New System.Drawing.Size(306, 463)
        Me.TaskPane1.TabIndex = 20
        '
        'TaskFrame1
        '
        Me.TaskFrame1.AllowDrop = True
        Me.TaskFrame1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.TaskFrame1.CaptionBlend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Horizontal, System.Drawing.SystemColors.Window, System.Drawing.Color.FromArgb(CType(160, Byte), CType(160, Byte), CType(160, Byte)))
        Me.TaskFrame1.CaptionHighlightColor = System.Drawing.SystemColors.ActiveCaption
        Me.TaskFrame1.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpFInicio, Me.dtpFTermino, Me.Label1, Me.Label2, Me.chkPermanente, Me.chkAlarma})
        Me.TaskFrame1.Location = New System.Drawing.Point(12, 33)
        Me.TaskFrame1.Name = "TaskFrame1"
        Me.TaskFrame1.Size = New System.Drawing.Size(282, 200)
        Me.TaskFrame1.TabIndex = 1
        Me.TaskFrame1.Text = "Configuración de duración y tipo"
        '
        'TaskFrame2
        '
        Me.TaskFrame2.AllowDrop = True
        Me.TaskFrame2.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.TaskFrame2.CaptionBlend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Horizontal, System.Drawing.SystemColors.Window, System.Drawing.Color.FromArgb(CType(160, Byte), CType(160, Byte), CType(160, Byte)))
        Me.TaskFrame2.CaptionHighlightColor = System.Drawing.SystemColors.ActiveCaption
        Me.TaskFrame2.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlColor, Me.lnkSeleccionaFuente, Me.lblFont, Me.Label3})
        Me.TaskFrame2.Location = New System.Drawing.Point(12, 266)
        Me.TaskFrame2.Name = "TaskFrame2"
        Me.TaskFrame2.Size = New System.Drawing.Size(282, 130)
        Me.TaskFrame2.TabIndex = 3
        Me.TaskFrame2.Text = "Configuración de color y fuente"
        '
        'pnlColor
        '
        Me.pnlColor.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel2, Me.Panel10, Me.Panel3, Me.Panel4, Me.Panel5, Me.Panel6, Me.Panel7, Me.Panel9, Me.Panel1, Me.Panel8})
        Me.pnlColor.Location = New System.Drawing.Point(16, 24)
        Me.pnlColor.Name = "pnlColor"
        Me.pnlColor.Size = New System.Drawing.Size(240, 24)
        Me.pnlColor.TabIndex = 22
        '
        'lnkSeleccionaFuente
        '
        Me.lnkSeleccionaFuente.AutoSize = True
        Me.lnkSeleccionaFuente.Location = New System.Drawing.Point(16, 64)
        Me.lnkSeleccionaFuente.Name = "lnkSeleccionaFuente"
        Me.lnkSeleccionaFuente.Size = New System.Drawing.Size(106, 14)
        Me.lnkSeleccionaFuente.TabIndex = 21
        Me.lnkSeleccionaFuente.TabStop = True
        Me.lnkSeleccionaFuente.Text = "Seleccionar fuente..."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 14)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Color de la nota:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PostitConfiguracion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.LightGray
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(306, 463)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnAceptar, Me.TaskPane1})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PostitConfiguracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración de la nota"
        Me.TopMost = True
        Me.TaskPane1.ResumeLayout(False)
        Me.TaskFrame1.ResumeLayout(False)
        Me.TaskFrame2.ResumeLayout(False)
        Me.pnlColor.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Eventos()
        AddHandler Panel1.Click, AddressOf PanelClick
        AddHandler Panel2.Click, AddressOf PanelClick
        AddHandler Panel3.Click, AddressOf PanelClick
        AddHandler Panel4.Click, AddressOf PanelClick
        AddHandler Panel5.Click, AddressOf PanelClick
        AddHandler Panel6.Click, AddressOf PanelClick
        AddHandler Panel7.Click, AddressOf PanelClick
        AddHandler Panel8.Click, AddressOf PanelClick
        AddHandler Panel9.Click, AddressOf PanelClick
        AddHandler Panel10.Click, AddressOf PanelClick
    End Sub

    Private Sub Limpia()
        Dim p As Panel
        For Each p In pnlColor.Controls
            p.BorderStyle = BorderStyle.None
        Next
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub dtpFInicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFInicio.ValueChanged
        _FInicio = dtpFInicio.Value.Date
        If _DatosCargados Then
            _HaCambiado = True
        End If
    End Sub

    Private Sub dtpFTermino_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFTermino.ValueChanged
        _FTermino = dtpFTermino.Value.Date
        If _DatosCargados Then
            _HaCambiado = True
        End If
    End Sub


    Private Sub PanelClick(ByVal sender As Object, ByVal e As System.EventArgs)
        _NotaColor = CType(sender, Panel).BackColor.ToString
        Limpia()
        CType(sender, Panel).BorderStyle = BorderStyle.FixedSingle
        If _DatosCargados Then
            _HaCambiado = True
        End If
    End Sub

    Private Sub MuestraFont()
        lblFont.Text = _FontName & " " & _FontSize.ToString
        Try
            lblFont.Font = New Font(_FontName, _FontSize)
        Catch
            lblFont.Font = New Font("Tahoma", 8)
        End Try

        Try
            lblFont.ForeColor = Color.FromName(_FontColor)
        Catch
            lblFont.ForeColor = Color.Black
        End Try

    End Sub

    Private Sub PostitConfiguracion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFInicio.MinDate = Now.Date
        dtpFTermino.MinDate = Now.Date
    End Sub

    Private Sub SeleccionaFuente()
        dlgFont.Font = New Font(_FontName, _FontSize)
        dlgFont.Color = Color.FromName(_FontColor)

        If dlgFont.ShowDialog = DialogResult.OK Then
            _FontName = dlgFont.Font.Name
            _FontSize = dlgFont.Font.SizeInPoints
            _FontColor = Replace(Replace(dlgFont.Color.ToString, "Color [", ""), "]", "")

            MuestraFont()

            _HaCambiado = True

        End If
    End Sub

    Private Sub lnkSeleccionaFuente_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSeleccionaFuente.LinkClicked
        SeleccionaFuente()
    End Sub

    Private Sub chkPermanente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPermanente.CheckedChanged
        _Permanente = chkPermanente.Checked
        Me.dtpFInicio.Enabled = Not _Permanente
        Me.dtpFTermino.Enabled = Not _Permanente
        If _DatosCargados Then
            _HaCambiado = True
        End If
    End Sub

    Private Sub chkAlarma_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAlarma.CheckedChanged
        _Alarma = chkAlarma.Checked
        If _DatosCargados Then
            _HaCambiado = True
        End If
    End Sub
End Class

Imports System.Windows.Forms


Public Class frmCambioCamion
    Inherits System.Windows.Forms.Form
    Private _Usuario As String
    Private _Camion As Integer
    Private _AnoAtt As Short
    Private _Folio As Integer

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()


        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal AnoAtt As Short, ByVal Folio As Integer, ByVal Camion As Integer, ByVal Usuario As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        _AnoAtt = AnoAtt
        _Folio = Folio
        _Usuario = Usuario
        _Usuario = Usuario
        _Camion = Camion

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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTripulacion As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents lblCamion As System.Windows.Forms.Label
    Friend WithEvents lblCamiontck As System.Windows.Forms.Label
    Friend WithEvents cboCamion As PortatilClasses.Combo.ComboCamion
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCambioCamion))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboCamion = New PortatilClasses.Combo.ComboCamion()
        Me.lblCamion = New System.Windows.Forms.Label()
        Me.lblCamiontck = New System.Windows.Forms.Label()
        Me.lblTripulacion = New System.Windows.Forms.Label()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCamion, Me.lblCamion, Me.lblCamiontck, Me.lblTripulacion})
        Me.GroupBox2.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(384, 80)
        Me.GroupBox2.TabIndex = 57
        Me.GroupBox2.TabStop = False
        '
        'cboCamion
        '
        Me.cboCamion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCamion.Location = New System.Drawing.Point(112, 46)
        Me.cboCamion.Name = "cboCamion"
        Me.cboCamion.Size = New System.Drawing.Size(250, 21)
        Me.cboCamion.TabIndex = 1
        '
        'lblCamion
        '
        Me.lblCamion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCamion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCamion.Location = New System.Drawing.Point(112, 18)
        Me.lblCamion.Name = "lblCamion"
        Me.lblCamion.Size = New System.Drawing.Size(250, 21)
        Me.lblCamion.TabIndex = 0
        Me.lblCamion.Text = "Camion"
        Me.lblCamion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCamiontck
        '
        Me.lblCamiontck.AutoSize = True
        Me.lblCamiontck.Enabled = False
        Me.lblCamiontck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCamiontck.Location = New System.Drawing.Point(16, 22)
        Me.lblCamiontck.Name = "lblCamiontck"
        Me.lblCamiontck.Size = New System.Drawing.Size(94, 14)
        Me.lblCamiontck.TabIndex = 53
        Me.lblCamiontck.Text = "Camión asignado:"
        '
        'lblTripulacion
        '
        Me.lblTripulacion.AutoSize = True
        Me.lblTripulacion.Enabled = False
        Me.lblTripulacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTripulacion.Location = New System.Drawing.Point(64, 50)
        Me.lblTripulacion.Name = "lblTripulacion"
        Me.lblTripulacion.Size = New System.Drawing.Size(45, 14)
        Me.lblTripulacion.TabIndex = 51
        Me.lblTripulacion.Text = "Camión:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(403, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(403, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCambioCamion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(496, 102)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2, Me.btnCancelar, Me.btnAceptar})
        Me.Name = "frmCambioCamion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificación de camión asignado"
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmCambioCamion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboCamion.CargaDatos(2, _Usuario)
        lblCamion.Text = CType(_Camion, String)
    End Sub


    Private Sub cboCamion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCamion.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If cboCamion.Identificador <> _Camion Then
            Dim oCamionCambio As New PortatilClasses.cComisionPortatil(4, Now, Now, 0, _AnoAtt, _Folio, cboCamion.Identificador, 0, 0)
            oCamionCambio.RegistrarModificarEliminar()
            _Camion = cboCamion.Identificador
            Me.DialogResult() = DialogResult.OK
            Me.Close()
        Else
            Me.DialogResult() = DialogResult.OK
            Me.Close()
        End If
    End Sub
End Class

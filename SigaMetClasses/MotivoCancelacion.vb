Option Strict On
Imports System.Windows.Forms

Public Class MotivoCancelacion
    Inherits System.Windows.Forms.Form
    Private _Clave As String
    Private _MotivoCancelacion As Byte
    Private _DestinoCancelacion As Enumeradores.enumDestinoCancelacion

    Public ReadOnly Property MotivoCancelacion() As Byte
        Get
            Return _MotivoCancelacion
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents lblClave As System.Windows.Forms.Label
    Friend WithEvents cboMotivoCancelacion As SigaMetClasses.Combos.ComboMotivoCancelacionDocumento
    Friend WithEvents lblDestino As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MotivoCancelacion))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.lblDestino = New System.Windows.Forms.Label()
        Me.cboMotivoCancelacion = New SigaMetClasses.Combos.ComboMotivoCancelacionDocumento()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Motivo:"
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(352, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(352, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblClave
        '
        Me.lblClave.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClave.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblClave.Location = New System.Drawing.Point(88, 8)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(160, 21)
        Me.lblClave.TabIndex = 7
        Me.lblClave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDestino
        '
        Me.lblDestino.AutoSize = True
        Me.lblDestino.Location = New System.Drawing.Point(16, 11)
        Me.lblDestino.Name = "lblDestino"
        Me.lblDestino.Size = New System.Drawing.Size(66, 14)
        Me.lblDestino.TabIndex = 8
        Me.lblDestino.Text = "Movimiento:"
        '
        'cboMotivoCancelacion
        '
        Me.cboMotivoCancelacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMotivoCancelacion.Location = New System.Drawing.Point(88, 40)
        Me.cboMotivoCancelacion.Name = "cboMotivoCancelacion"
        Me.cboMotivoCancelacion.Size = New System.Drawing.Size(248, 21)
        Me.cboMotivoCancelacion.TabIndex = 9
        '
        'MotivoCancelacion
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(432, 77)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboMotivoCancelacion, Me.lblDestino, Me.Label1, Me.lblClave, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "MotivoCancelacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione el motivo de cancelación"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal Clave As String, _
                   ByVal DestinoCancelacion As Enumeradores.enumDestinoCancelacion)
        MyBase.New()
        InitializeComponent()
        _Clave = Clave
        _DestinoCancelacion = DestinoCancelacion
        If _DestinoCancelacion = Enumeradores.enumDestinoCancelacion.MovimientoCaja Then
            lblDestino.Text = "Movimiento:"
        Else
            lblDestino.Text = "Cobranza:"
        End If
        lblClave.Text = _Clave
    End Sub

    Private Sub MotivoCancelacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboMotivoCancelacion.CargaDatos(_DestinoCancelacion, True)
        cboMotivoCancelacion.SelectedValue = 1
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If CType(cboMotivoCancelacion.SelectedValue, String) <> "" Then
            _MotivoCancelacion = CType(cboMotivoCancelacion.SelectedValue, Byte)
        Else
            MessageBox.Show("Debe seleccionar el motivo de cancelación.", "Cancelación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class
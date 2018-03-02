Imports System.Drawing
Imports System.Windows.Forms

Public Class frmCapPromediosPorcentaje
    Inherits System.Windows.Forms.Form
    Private _Operacion As Short

    Public Promedio As Decimal
    Public PorcentajeI As Decimal
    Public PorcentajeD As Decimal


#Region "Operaciones"
    Public Enum Opereaciones
        Agregar = 1
        Consultar = 2
    End Enum
#End Region


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Operacion As Opereaciones)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _Operacion = Operacion

    End Sub


    Public Sub New(ByVal Operacion As Opereaciones, ByVal MedicionDerecha As Decimal, ByVal MedicionIzquierda As Decimal)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _Operacion = Operacion
        txtPorcentajeDer.Text = CType(MedicionDerecha, String)
        txtPorcentajeIzq.Text = CType(MedicionIzquierda, String)
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
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents gpbDatosPrincipales As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPromedio As System.Windows.Forms.Label
    Friend WithEvents txtPorcentajeDer As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPorcentajeIzq As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapPromediosPorcentaje))
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.gpbDatosPrincipales = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPromedio = New System.Windows.Forms.Label()
        Me.txtPorcentajeDer = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPorcentajeIzq = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.gpbDatosPrincipales.SuspendLayout()
        Me.SuspendLayout()
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
        'gpbDatosPrincipales
        '
        Me.gpbDatosPrincipales.Controls.Add(Me.Label3)
        Me.gpbDatosPrincipales.Controls.Add(Me.txtPromedio)
        Me.gpbDatosPrincipales.Controls.Add(Me.txtPorcentajeDer)
        Me.gpbDatosPrincipales.Controls.Add(Me.Label1)
        Me.gpbDatosPrincipales.Controls.Add(Me.txtPorcentajeIzq)
        Me.gpbDatosPrincipales.Controls.Add(Me.Label2)
        Me.gpbDatosPrincipales.Location = New System.Drawing.Point(12, 12)
        Me.gpbDatosPrincipales.Name = "gpbDatosPrincipales"
        Me.gpbDatosPrincipales.Size = New System.Drawing.Size(325, 107)
        Me.gpbDatosPrincipales.TabIndex = 0
        Me.gpbDatosPrincipales.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Promedio:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPromedio
        '
        Me.txtPromedio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtPromedio.Location = New System.Drawing.Point(175, 75)
        Me.txtPromedio.Name = "txtPromedio"
        Me.txtPromedio.Size = New System.Drawing.Size(120, 21)
        Me.txtPromedio.TabIndex = 6
        Me.txtPromedio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPorcentajeDer
        '
        Me.txtPorcentajeDer.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtPorcentajeDer.Location = New System.Drawing.Point(175, 44)
        Me.txtPorcentajeDer.MaxLength = 5
        Me.txtPorcentajeDer.Name = "txtPorcentajeDer"
        Me.txtPorcentajeDer.Size = New System.Drawing.Size(120, 20)
        Me.txtPorcentajeDer.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(14, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Porcentaje derecha (%):"
        '
        'txtPorcentajeIzq
        '
        Me.txtPorcentajeIzq.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtPorcentajeIzq.Location = New System.Drawing.Point(175, 13)
        Me.txtPorcentajeIzq.MaxLength = 5
        Me.txtPorcentajeIzq.Name = "txtPorcentajeIzq"
        Me.txtPorcentajeIzq.Size = New System.Drawing.Size(120, 20)
        Me.txtPorcentajeIzq.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(14, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Porcentaje izquierda (%):"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(343, 50)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(343, 18)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 7
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCapPromediosPorcentaje
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(427, 136)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.gpbDatosPrincipales)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmCapPromediosPorcentaje"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cálculo de porcentaje (%)"
        Me.gpbDatosPrincipales.ResumeLayout(False)
        Me.gpbDatosPrincipales.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Manejo de la forma"

    Private Sub HabilitarAceptar()
        If txtPorcentajeIzq.Text <> "" And txtPorcentajeDer.Text <> "" And txtPromedio.Text <> "" Then
            btnAceptar.Enabled = True
            ActiveControl = btnAceptar
        Else
            btnAceptar.Enabled = False
        End If
    End Sub


    Private Function CalcularProcentaje(sender As System.Object) As Decimal
        Dim Promedio As Decimal

        Try
            Promedio = (CType(IIf(txtPorcentajeIzq.Text <> "", txtPorcentajeIzq.Text, 0), Decimal) + CType(IIf(txtPorcentajeDer.Text <> "", txtPorcentajeDer.Text, 0), Decimal)) / 2
            PorcentajeI = CType(IIf(txtPorcentajeIzq.Text <> "", txtPorcentajeIzq.Text, 0), Decimal)
            PorcentajeD = CType(IIf(txtPorcentajeDer.Text <> "", txtPorcentajeDer.Text, 0), Decimal)
        Catch ex As Exception
            Dim Mensaje As PortatilClasses.Mensaje
            Mensaje = New PortatilClasses.Mensaje(56)
            MessageBox.Show(Mensaje.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ActiveControl = sender
        End Try

        Return Promedio

    End Function

#End Region


    Private Sub InterfazInicial()
        If _Operacion = Opereaciones.Agregar Then
            btnAceptar.Enabled = False
        Else
            txtPorcentajeIzq.Enabled = False
            txtPorcentajeDer.Enabled = False
            btnAceptar.Visible = False
            btnCancelar.Location = New Point(343, 18)
            txtPromedio.Text = Format(CalcularProcentaje(Nothing), "n")
        End If
    End Sub


#Region "Manejo de Controles"

    Private Sub txtPorcentajeIzq_Leave(sender As Object, e As EventArgs) Handles txtPorcentajeDer.Leave
        txtPromedio.Text = Format(CalcularProcentaje(sender), "n")
        HabilitarAceptar()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Promedio = CType(txtPromedio.Text, Decimal)
        Close()
    End Sub

    Private Sub frmCapPromediosPorcentaje_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InterfazInicial()
    End Sub

    Private Sub txtPorcentajeIzq_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPorcentajeDer.KeyDown
        If (e.KeyData = Keys.Enter) Or (e.KeyData = Keys.Down) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    Private Sub frmActaCierre_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnCancelar.DialogResult() = DialogResult.Cancel Then
            Dim Result As DialogResult
            Dim Mensajes As New PortatilClasses.Mensaje(28)
            Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

End Class

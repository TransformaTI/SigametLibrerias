Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.ControlChars

Public Class DocumentosErroneos
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents txtCargos As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DocumentosErroneos))
        Me.txtCargos = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtCargos
        '
        Me.txtCargos.BackColor = System.Drawing.SystemColors.Control
        Me.txtCargos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCargos.Location = New System.Drawing.Point(8, 52)
        Me.txtCargos.Multiline = True
        Me.txtCargos.Name = "txtCargos"
        Me.txtCargos.ReadOnly = True
        Me.txtCargos.Size = New System.Drawing.Size(336, 200)
        Me.txtCargos.TabIndex = 0
        Me.txtCargos.Text = "TextBox1"
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(269, 260)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "     &Aceptar"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Brown
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(332, 32)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "El saldo de los siguientes documentos es menor al abono que se pretende aplicar"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Brown
        Me.Label2.Location = New System.Drawing.Point(8, 256)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(254, 32)
        Me.Label2.TabIndex = 4
        '
        'DocumentosErroneos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(352, 291)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.Label1, Me.btnAceptar, Me.txtCargos})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DocumentosErroneos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DocumentosErroneos"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private objDAC As DAC

    Private _cobranza As Boolean = False

    Public ReadOnly Property CapturaCorrecta() As Boolean
        Get
            Return objDAC.CapturaCorrecta
        End Get
    End Property

    Public Sub New(ByVal Caja As Short, ByVal FOperacion As Date, _
                                ByVal Consecutivo As Short, ByVal Folio As Integer, _
                                ByVal Connection As SqlConnection)
        InitializeComponent()
        objDAC = New DAC(Caja, FOperacion, Consecutivo, Folio, Connection)
    End Sub

    'Para cobranza
    Public Sub New(ByVal PedidoReferencia As String, _
                   ByVal Abono As Double, _
                   ByVal Connection As String)
        InitializeComponent()
        objDAC = New DAC(PedidoReferencia, Abono, Connection)
        _cobranza = True
    End Sub

    Private Sub DocumentosErroneos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If _cobranza Then
            cargaDatosCobranza()
        Else
            cargaDatosCaja()
        End If
    End Sub

    Private Sub cargaDatosCaja()
        Dim dr As DataRow
        txtCargos.Text = ("Cliente").PadRight(21) & ("    Documento").PadRight(21) & ("      Saldo").PadRight(21) & "  AbonoTotal"
        For Each dr In objDAC.CargosDuplicados.Rows
            Me.Text = CStr(dr.Item("PedidoReferencia"))
            Me.txtCargos.Text = txtCargos.Text & CrLf & _
                                                CStr(dr.Item("Cliente")).PadRight(21) & _
                                                CStr(dr.Item("PedidoReferencia")).PadRight(21) & _
                                                CStr(dr.Item("Saldo")).PadRight(21) & _
                                                CStr(dr.Item("Total"))
        Next
        Me.txtCargos.Select(0, 0)

    End Sub

    Private Sub cargaDatosCobranza()
        Me.Label1.Text = "El documento se encuentra capturado en los siguientes movimientos:"
        Me.Label2.Text = "La suma de los abonos capturados sobrepasa el saldo actual del documento"
        Dim dr As DataRow
        txtCargos.Text = ("Clave movimiento") & Tab & ("Status") & Tab & Tab & ("Importe Abono")
        For Each dr In objDAC.CargosDuplicados.Rows
            Me.Text = CStr(dr.Item("PedidoReferencia"))
            Me.txtCargos.Text = txtCargos.Text & CrLf & _
                                CStr(dr.Item("Clave")) & Tab & _
                                CStr(dr.Item("Status")) & Tab & _
                                FormatCurrency(CStr(dr.Item("Abono")).PadLeft(13))
        Next
        Me.txtCargos.Select(0, 0)
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = DialogResult.OK
    End Sub
End Class

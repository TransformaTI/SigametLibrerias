Option Strict On
Imports System.Windows.Forms

Public Class CapturaCheque
    Inherits System.Windows.Forms.Form
    Private Titulo As String = "Captura de cheques"
    Private _TipoAccion As enumTipoAccion
    Private _NumeroCheque As String
    Private _Cliente As Integer
    Private _Banco As Short
    Private _Usuario As String

    Public Enum enumTipoAccion
        Agregar = 1
        Modificar = 2
    End Enum

    Public Sub New(ByVal Usuario As String)
        'Alta
        MyBase.New()
        InitializeComponent()
        _Usuario = Usuario
        _TipoAccion = enumTipoAccion.Agregar
        dtpFCheque.Value = Now.Date
    End Sub

    Public Sub New(ByVal Cliente As Integer, _
                   ByVal NumeroCheque As String, _
                   ByVal NumeroCuenta As String, _
                   ByVal Banco As Short, _
                   ByVal FCheque As Date, _
                   ByVal Importe As Decimal, _
                   ByVal Observaciones As String, _
                   ByVal Usuario As String)
        MyBase.New()
        InitializeComponent()

        _NumeroCheque = Trim(NumeroCheque)
        _Cliente = Cliente
        _Banco = Banco
        _Usuario = Usuario
        _TipoAccion = enumTipoAccion.Modificar

        txtCliente.Text = _Cliente.ToString
        txtNumeroCheque.Text = _NumeroCheque
        txtNumeroCuenta.Text = Trim(NumeroCuenta)
        dtpFCheque.Value = FCheque
        txtTotal.Text = Importe.ToString
        txtObservaciones.Text = Trim(Observaciones)
    End Sub


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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents cboBanco As SigaMetClasses.Combos.ComboBanco
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents stbEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents txtNumeroCheque As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtNumeroCuenta As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents dtpFCheque As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTotal As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CapturaCheque))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.cboBanco = New SigaMetClasses.Combos.ComboBanco()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumeroCheque = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtNumeroCuenta = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFCheque = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTotal = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.stbEstatus = New System.Windows.Forms.StatusBar()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(368, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(368, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 7
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboBanco
        '
        Me.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBanco.Location = New System.Drawing.Point(136, 152)
        Me.cboBanco.Name = "cboBanco"
        Me.cboBanco.Size = New System.Drawing.Size(216, 21)
        Me.cboBanco.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 155)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 14)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Banco:"
        '
        'txtNumeroCheque
        '
        Me.txtNumeroCheque.Location = New System.Drawing.Point(136, 104)
        Me.txtNumeroCheque.MaxLength = 20
        Me.txtNumeroCheque.Name = "txtNumeroCheque"
        Me.txtNumeroCheque.Size = New System.Drawing.Size(216, 21)
        Me.txtNumeroCheque.TabIndex = 1
        Me.txtNumeroCheque.Text = ""
        '
        'txtNumeroCuenta
        '
        Me.txtNumeroCuenta.Location = New System.Drawing.Point(136, 128)
        Me.txtNumeroCuenta.MaxLength = 20
        Me.txtNumeroCuenta.Name = "txtNumeroCuenta"
        Me.txtNumeroCuenta.Size = New System.Drawing.Size(216, 21)
        Me.txtNumeroCuenta.TabIndex = 2
        Me.txtNumeroCuenta.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 14)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "No. Cheque:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 14)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "No. Cuenta:"
        '
        'dtpFCheque
        '
        Me.dtpFCheque.Location = New System.Drawing.Point(136, 176)
        Me.dtpFCheque.Name = "dtpFCheque"
        Me.dtpFCheque.Size = New System.Drawing.Size(216, 21)
        Me.dtpFCheque.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 14)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Fecha del cheque:"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(136, 200)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(216, 21)
        Me.txtTotal.TabIndex = 5
        Me.txtTotal.Text = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 203)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 14)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Importe:"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(136, 224)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(216, 40)
        Me.txtObservaciones.TabIndex = 6
        Me.txtObservaciones.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 224)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 14)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Observaciones:"
        '
        'stbEstatus
        '
        Me.stbEstatus.Location = New System.Drawing.Point(0, 281)
        Me.stbEstatus.Name = "stbEstatus"
        Me.stbEstatus.Size = New System.Drawing.Size(450, 22)
        Me.stbEstatus.TabIndex = 22
        Me.stbEstatus.Text = "Por favor teclee los datos correspondientes al cheque que desea dar de alta."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 14)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Cliente:"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(136, 80)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(216, 21)
        Me.txtCliente.TabIndex = 0
        Me.txtCliente.Text = ""
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.Location = New System.Drawing.Point(8, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(328, 40)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Asegurese de que el cheque no exista actualmente en la base de datos.  Por favor " & _
        "verifiquelo en la ventana principal de la lista de cheques."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label8})
        Me.GroupBox1.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(344, 64)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        '
        'frmCapturaCheque
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(450, 303)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.Label7, Me.txtCliente, Me.stbEstatus, Me.Label6, Me.txtObservaciones, Me.Label5, Me.txtTotal, Me.dtpFCheque, Me.Label3, Me.Label2, Me.txtNumeroCuenta, Me.txtNumeroCheque, Me.Label1, Me.cboBanco, Me.btnCancelar, Me.btnAceptar, Me.Label4})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapturaCheque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta de nuevo cheque"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmCaptura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboBanco.CargaDatos(True)
        cboBanco.SelectedValue = _Banco
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ValidaCaptura() = True Then
            If MessageBox.Show(SigaMetClasses.M_ESTAN_CORRECTOS, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim objCheque As New SigaMetClasses.Cobro()
                Try
                    Cursor = Cursors.WaitCursor

                    If _TipoAccion = enumTipoAccion.Agregar Then
                        objCheque.ChequeTarjetaAlta(Trim(txtNumeroCheque.Text),
                        CType(Trim(txtTotal.Text), Decimal),
                        Trim(txtNumeroCuenta.Text),
                        CType(dtpFCheque.Value.ToShortDateString, Date),
                        CType(Trim(txtCliente.Text), Integer),
                        CType(cboBanco.SelectedValue, Short),
                        txtObservaciones.Text, , _Usuario, dtmFCobro:=CType(dtpFCheque.Value.ToShortDateString, Date))
                    End If

                    If _TipoAccion = enumTipoAccion.Modificar Then
                        objCheque.ChequeTarjetaModifica(_NumeroCheque, _
                         CType(txtTotal.Text, Decimal), _
                         Trim(txtNumeroCuenta.Text), _
                         CType(dtpFCheque.Value.ToShortDateString, Date), _
                         _Cliente, _
                         _Banco, _
                         _Usuario, _
                         Trim(txtNumeroCheque.Text), _
                        CType(cboBanco.SelectedValue, Short), _
                        CType(txtCliente.Text, Integer), _
                        txtObservaciones.Text)
                    End If

                    MessageBox.Show(SigaMetClasses.M_DATOS_OK, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    DialogResult = DialogResult.OK

                Catch ex As Exception
                    MessageBox.Show("Ha ocurrido el siguiente error al dar de alta el cheque: " & Chr(13) & _
                    ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Finally
                    Cursor = Cursors.Default
                    objCheque = Nothing
                End Try
            End If
        End If
    End Sub

    Private Function ValidaCaptura() As Boolean
        If txtCliente.Text <> "" Then
            If txtNumeroCheque.Text <> "" Then
                If txtNumeroCuenta.Text <> "" Then
                    If txtTotal.Text <> "" Then
                        If CType(txtTotal.Text, Decimal) > 0 Then
                            If CType(cboBanco.SelectedValue, Short) <> 0 Then
                                ValidaCaptura = True
                            Else
                                ValidaCaptura = False
                                MessageBox.Show("Debe seleccionar el banco correspondiente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        Else
                            ValidaCaptura = False
                            MessageBox.Show("Debe teclear el importe del cheque.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    Else
                        ValidaCaptura = False
                        MessageBox.Show("Debe teclear el importe del cheque.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    ValidaCaptura = False
                    MessageBox.Show("Debe teclear el número de cuenta.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                ValidaCaptura = False
                MessageBox.Show("Debe teclear el número de cheque.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            ValidaCaptura = False
            MessageBox.Show("Debe teclear el número de cliente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Function
End Class

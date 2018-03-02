Imports System.Windows.Forms

Public Class AltaCheque
    Inherits System.Windows.Forms.Form
    Private _Contrato As Integer
    Public _Banco As Integer
    Public _FCheque As DateTime
    Public _Cheque As String
    Public _Cuenta As String
    Public _Monto As Decimal
    Public _Nombre As String
    Public _Cliente As Integer
    Public _NombreCliente As String
    Public _PosFechado As String
    Private _Titulo As String = "Captura de cheque"

    Private _ClienteLista As ArrayList
    Private _TipoCobroLista As ArrayList

    Public Sub Entrada(ByVal Contrato As Integer, ByVal ClienteLista As ArrayList, ByVal TipoCobroLista As ArrayList)
        cboBanco.CargaDatos(CargaBancoCero:=False, MostrarClaves:=True, SoloActivos:=True)
        _PosFechado = ""
        txtFCheque.Value = Now.Date
        _Contrato = Contrato
        _ClienteLista = ClienteLista
        _TipoCobroLista = TipoCobroLista
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
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFCheque As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnLeer As System.Windows.Forms.Button
    Friend WithEvents lbPosfechado As System.Windows.Forms.Label
    Friend WithEvents txtMonto As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtCliente As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtCheque As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtCuenta As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents cboBanco As SigaMetClasses.Combos.ComboBanco
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AltaCheque))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFCheque = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnLeer = New System.Windows.Forms.Button()
        Me.lbPosfechado = New System.Windows.Forms.Label()
        Me.txtMonto = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtCheque = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtCuenta = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.cboBanco = New SigaMetClasses.Combos.ComboBanco()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.ImageList1
        Me.btnAceptar.Location = New System.Drawing.Point(432, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 7
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 1
        Me.btnCancelar.ImageList = Me.ImageList1
        Me.btnCancelar.Location = New System.Drawing.Point(432, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Banco:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "No. cheque:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 14)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Fecha cheque:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "No. Cuenta:"
        '
        'txtFCheque
        '
        Me.txtFCheque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFCheque.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.txtFCheque.Location = New System.Drawing.Point(104, 128)
        Me.txtFCheque.Name = "txtFCheque"
        Me.txtFCheque.Size = New System.Drawing.Size(288, 21)
        Me.txtFCheque.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 188)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 14)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Monto:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 14)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Cliente:"
        '
        'txtCodigo
        '
        Me.txtCodigo.AutoSize = False
        Me.txtCodigo.BackColor = System.Drawing.Color.Black
        Me.txtCodigo.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.ForeColor = System.Drawing.Color.Gold
        Me.txtCodigo.Location = New System.Drawing.Point(104, 16)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(288, 21)
        Me.txtCodigo.TabIndex = 0
        Me.txtCodigo.Text = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 14)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Usar lector:"
        '
        'btnLeer
        '
        Me.btnLeer.Location = New System.Drawing.Point(264, 16)
        Me.btnLeer.Name = "btnLeer"
        Me.btnLeer.Size = New System.Drawing.Size(48, 18)
        Me.btnLeer.TabIndex = 12
        '
        'lbPosfechado
        '
        Me.lbPosfechado.AutoSize = True
        Me.lbPosfechado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPosfechado.ForeColor = System.Drawing.Color.Red
        Me.lbPosfechado.Location = New System.Drawing.Point(402, 132)
        Me.lbPosfechado.Name = "lbPosfechado"
        Me.lbPosfechado.Size = New System.Drawing.Size(93, 14)
        Me.lbPosfechado.TabIndex = 13
        Me.lbPosfechado.Text = "POST FECHADO"
        Me.lbPosfechado.Visible = False
        '
        'txtMonto
        '
        Me.txtMonto.AutoSize = False
        Me.txtMonto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.ForeColor = System.Drawing.Color.Red
        Me.txtMonto.Location = New System.Drawing.Point(104, 184)
        Me.txtMonto.MaxLength = 9
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(288, 21)
        Me.txtMonto.TabIndex = 6
        Me.txtMonto.Text = ""
        '
        'txtCliente
        '
        Me.txtCliente.AutoSize = False
        Me.txtCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(104, 44)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(288, 21)
        Me.txtCliente.TabIndex = 1
        Me.txtCliente.Text = ""
        '
        'txtCheque
        '
        Me.txtCheque.AutoSize = False
        Me.txtCheque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheque.Location = New System.Drawing.Point(104, 100)
        Me.txtCheque.MaxLength = 30
        Me.txtCheque.Name = "txtCheque"
        Me.txtCheque.Size = New System.Drawing.Size(288, 21)
        Me.txtCheque.TabIndex = 3
        Me.txtCheque.Text = ""
        '
        'txtCuenta
        '
        Me.txtCuenta.AutoSize = False
        Me.txtCuenta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta.Location = New System.Drawing.Point(104, 156)
        Me.txtCuenta.MaxLength = 30
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(288, 21)
        Me.txtCuenta.TabIndex = 5
        Me.txtCuenta.Text = ""
        '
        'cboBanco
        '
        Me.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBanco.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBanco.Location = New System.Drawing.Point(104, 72)
        Me.cboBanco.Name = "cboBanco"
        Me.cboBanco.Size = New System.Drawing.Size(288, 21)
        Me.cboBanco.TabIndex = 14
        '
        'AltaCheque
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(514, 222)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboBanco, Me.txtCuenta, Me.txtCheque, Me.txtCliente, Me.txtMonto, Me.lbPosfechado, Me.Label7, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.Label1, Me.Label6, Me.txtCodigo, Me.txtFCheque, Me.btnCancelar, Me.btnAceptar, Me.btnLeer})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AltaCheque"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta Cheque"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Function ExisteClienteLista(ByVal Cliente As Integer) As Boolean
        Dim j As Integer = 0
        While j < _ClienteLista.Count
            If CType(_ClienteLista(j), Integer) = Cliente Then
                Return True
            End If
            j = j + 1
        End While
        Return False
    End Function


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If txtCliente.Text.Trim = "" Then
            MessageBox.Show("Debe teclear el número de cliente.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCliente.Focus()
            Exit Sub
        End If

        If txtCheque.Text.Trim = "" Then
            MessageBox.Show("Debe teclear el número de cheque.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCheque.Focus()
            Exit Sub
        End If

        If txtCheque.Text.Trim.Length < 7 Then
            MessageBox.Show("El número de cheque debe ser de 7 dígitos.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCheque.Focus()
            Exit Sub
        End If

        If txtCuenta.Text.Trim = "" Then
            MessageBox.Show("Debe teclear el número de cuenta.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCuenta.Focus()
            Exit Sub
        End If

        If txtMonto.Text.Trim = "" Then
            MessageBox.Show("Debe teclear el importe del cheque.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMonto.SelectAll()
            txtMonto.Focus()
            Exit Sub
        End If


        _Banco = CType(cboBanco.SelectedValue, Integer)
        _FCheque = txtFCheque.Value.Date
        _Cheque = txtCheque.Text.Trim
        _Cuenta = txtCuenta.Text.Trim
        _Monto = CType(txtMonto.Text.Trim, Decimal)
        _Nombre = cboBanco.Text.Trim
        _Cliente = CType(txtCliente.Text, Integer)

        DialogResult = DialogResult.OK

    End Sub


    Private Sub txtCliente_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCliente.Validated
        If txtCliente.Text.Trim <> "" Then
            Try
                If CType(txtCliente.Text.Trim, Integer) <> 0 Then
                    Dim oCliente As SigaMetClasses.cCliente = Nothing
                    Try
                        oCliente = New SigaMetClasses.cCliente(CType(txtCliente.Text.Trim, Integer))
                        If oCliente.Nombre.Trim <> "" Then
                            If ExisteClienteLista(CType(txtCliente.Text.Trim, Integer)) Then
                                If MessageBox.Show("El cliente es: " & oCliente.Nombre.Trim & Chr(13) & SigaMetClasses.M_ESTAN_CORRECTOS, _Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                    _NombreCliente = oCliente.Nombre
                                Else
                                    _NombreCliente = ""
                                    txtCliente.SelectAll()
                                    txtCliente.Focus()
                                End If
                            Else
                                MessageBox.Show("El cliente no esta agregado a la liquidación para anexarle un pago de cheque o el tipo de cobro no puede ser pagado con cheque.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                txtCliente.SelectAll()
                                txtCliente.Focus()
                            End If
                        Else
                            MessageBox.Show("El cliente no existe en la base de datos.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            txtCliente.SelectAll()
                            txtCliente.Focus()
                            Exit Sub
                        End If
                    Catch
                        MessageBox.Show("El cliente no existe en la base de datos.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        txtCliente.SelectAll()
                        txtCliente.Focus()
                        Exit Sub
                    Finally
                        oCliente.Dispose()
                    End Try
                End If
            Catch
                txtCliente.SelectAll()
                txtCliente.Focus()
            End Try
        End If
        'Else
        'MessageBox.Show("El cliente no esta agregado a la liquidación para anexarle un pago de cheque o el tipo de cobro no puede ser pagado con cheque.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'txtCliente.SelectAll()
        'txtCliente.Focus()
        'End If
    End Sub

    'Private Sub txtCodigo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.Enter
    '    Me.AcceptButton = btnLeer
    'End Sub

    'Private Sub txtCodigo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.Leave
    '    Me.AcceptButton = btnAceptar
    'End Sub

    'Private Sub btnLeer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLeer.Click
    '    Dim strCodigo As String = txtCodigo.Text.Trim
    '    Dim NumeroCuenta As String
    '    Dim NumeroCheque As String
    '    NumeroCuenta = Mid(strCodigo, 16, 11)
    '    NumeroCheque = Mid(strCodigo, 28, 7)

    '    txtCuenta.Text = NumeroCuenta
    '    txtCheque.Text = NumeroCheque
    '    txtCodigo.Text = ""
    'End Sub

    Private Sub txtFCheque_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFCheque.ValueChanged
        If txtFCheque.Value.Date > Now.Date Then
            lbPosfechado.Visible = True
            _PosFechado = "P"
        Else
            lbPosfechado.Visible = False
            _PosFechado = ""
        End If
    End Sub


    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown, txtCheque.KeyDown, txtCuenta.KeyDown, txtMonto.KeyDown
        If (e.KeyData = Keys.Enter) Or (e.KeyData = Keys.Down) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    Private Sub cboBanco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBanco.KeyDown, txtFCheque.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        If (e.KeyData = Keys.Enter) Or (e.KeyData = Keys.Down) Then
            Dim strCodigo As String = txtCodigo.Text.Trim
            Dim NumeroCuenta As String
            Dim NumeroCheque As String
            NumeroCuenta = Mid(strCodigo, 16, 11)
            NumeroCheque = Mid(strCodigo, 28, 7)

            txtCuenta.Text = NumeroCuenta
            txtCheque.Text = NumeroCheque
            txtCodigo.Text = ""
            ActiveControl = txtCliente
        End If
    End Sub
End Class

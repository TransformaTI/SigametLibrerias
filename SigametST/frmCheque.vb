Imports System.Data.SqlClient
Public Class frmCheque
    Inherits System.Windows.Forms.Form

    Dim _PedidoReferencia As String
    'Public _Fecha As DateTime
    'Public _Autotanque As Integer
    'Public _Pedido As Integer
    'Public _Celula As Integer
    'Public _AñoPed As Integer
    Dim _TotalPedido As Decimal
    'Public _Usuario As String
    Dim Monto As Decimal
	Friend WithEvents Label8 As Label
	Friend WithEvents dtpFCobro As DateTimePicker
	Dim Saldo As Decimal
	'Public NumCobro As Integer
	'Public _AñoCobro As Integer
	'Public TipoCobro As Integer
	'Public disponible As Integer
	'Public CobroContado As Integer
	'Public AñoCobroContado As Integer
	'Public SaldoCheque As Integer
	'Public Cobrocomplemento As Integer
	'Public AñoCobroComplemento As Integer
	'Public TotalComplemento As Decimal
#Region " Windows Form Designer generated code "

	Public Sub New(ByVal PedidoReferencia As String)
        MyBase.New()
        _PedidoReferencia = PedidoReferencia
        '_Pedido = Pedido
        '_Celula = Celula
        '_AñoPed = AñoPed
        '_Total = Total
        '_Usuario = Usuario
        '_Fecha = Fecha
        '_Autotanque = Autotanque
        'NumCobro = Cobro
        '_AñoCobro = AñoCobro
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
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents dtpFCheque As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents txtCheque As System.Windows.Forms.TextBox
    Friend WithEvents cboBanco As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancelarCheque As System.Windows.Forms.ToolBarButton
    Friend WithEvents txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents btnleer As System.Windows.Forms.Button
    Friend WithEvents btnAcepta As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCheque))
		Me.txtCliente = New System.Windows.Forms.TextBox()
		Me.txtMonto = New System.Windows.Forms.TextBox()
		Me.dtpFCheque = New System.Windows.Forms.DateTimePicker()
		Me.txtCuenta = New System.Windows.Forms.TextBox()
		Me.txtCheque = New System.Windows.Forms.TextBox()
		Me.cboBanco = New System.Windows.Forms.ComboBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.txtSaldo = New System.Windows.Forms.TextBox()
		Me.ToolBar1 = New System.Windows.Forms.ToolBar()
		Me.btnAceptar = New System.Windows.Forms.ToolBarButton()
		Me.btnCancelarCheque = New System.Windows.Forms.ToolBarButton()
		Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
		Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
		Me.lblCliente = New System.Windows.Forms.Label()
		Me.txtcodigo = New System.Windows.Forms.TextBox()
		Me.btnleer = New System.Windows.Forms.Button()
		Me.btnAcepta = New System.Windows.Forms.Button()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.dtpFCobro = New System.Windows.Forms.DateTimePicker()
		Me.SuspendLayout()
		'
		'txtCliente
		'
		Me.txtCliente.BackColor = System.Drawing.SystemColors.Control
		Me.txtCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtCliente.Location = New System.Drawing.Point(112, 56)
		Me.txtCliente.MaxLength = 20
		Me.txtCliente.Name = "txtCliente"
		Me.txtCliente.Size = New System.Drawing.Size(104, 21)
		Me.txtCliente.TabIndex = 12
		Me.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'txtMonto
		'
		Me.txtMonto.BackColor = System.Drawing.SystemColors.Control
		Me.txtMonto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMonto.Location = New System.Drawing.Point(112, 238)
		Me.txtMonto.MaxLength = 20
		Me.txtMonto.Name = "txtMonto"
		Me.txtMonto.Size = New System.Drawing.Size(104, 21)
		Me.txtMonto.TabIndex = 4
		Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'dtpFCheque
		'
		Me.dtpFCheque.Location = New System.Drawing.Point(112, 144)
		Me.dtpFCheque.Name = "dtpFCheque"
		Me.dtpFCheque.Size = New System.Drawing.Size(213, 20)
		Me.dtpFCheque.TabIndex = 2
		'
		'txtCuenta
		'
		Me.txtCuenta.BackColor = System.Drawing.SystemColors.Control
		Me.txtCuenta.Location = New System.Drawing.Point(112, 206)
		Me.txtCuenta.MaxLength = 20
		Me.txtCuenta.Name = "txtCuenta"
		Me.txtCuenta.Size = New System.Drawing.Size(213, 20)
		Me.txtCuenta.TabIndex = 3
		'
		'txtCheque
		'
		Me.txtCheque.BackColor = System.Drawing.SystemColors.Control
		Me.txtCheque.Location = New System.Drawing.Point(112, 112)
		Me.txtCheque.MaxLength = 20
		Me.txtCheque.Name = "txtCheque"
		Me.txtCheque.Size = New System.Drawing.Size(213, 20)
		Me.txtCheque.TabIndex = 1
		'
		'cboBanco
		'
		Me.cboBanco.BackColor = System.Drawing.SystemColors.Control
		Me.cboBanco.DisplayMember = "Nombre"
		Me.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboBanco.Location = New System.Drawing.Point(112, 80)
		Me.cboBanco.Name = "cboBanco"
		Me.cboBanco.Size = New System.Drawing.Size(216, 21)
		Me.cboBanco.TabIndex = 6
		Me.cboBanco.ValueMember = "Banco"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(16, 238)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(43, 13)
		Me.Label5.TabIndex = 22
		Me.Label5.Text = "Monto :"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(16, 206)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(86, 13)
		Me.Label4.TabIndex = 19
		Me.Label4.Text = "Numero cuenta :"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(16, 144)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(82, 13)
		Me.Label3.TabIndex = 18
		Me.Label3.Text = "Fecha cheque :"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(16, 112)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(89, 13)
		Me.Label2.TabIndex = 15
		Me.Label2.Text = "Numero cheque :"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(16, 88)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(44, 13)
		Me.Label1.TabIndex = 13
		Me.Label1.Text = "Banco :"
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(16, 56)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(45, 13)
		Me.Label6.TabIndex = 23
		Me.Label6.Text = "Cliente :"
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(16, 270)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(40, 13)
		Me.Label7.TabIndex = 24
		Me.Label7.Text = "Saldo :"
		'
		'txtSaldo
		'
		Me.txtSaldo.BackColor = System.Drawing.SystemColors.Control
		Me.txtSaldo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSaldo.Location = New System.Drawing.Point(112, 270)
		Me.txtSaldo.MaxLength = 20
		Me.txtSaldo.Name = "txtSaldo"
		Me.txtSaldo.ReadOnly = True
		Me.txtSaldo.Size = New System.Drawing.Size(104, 21)
		Me.txtSaldo.TabIndex = 5
		Me.txtSaldo.Text = "0"
		Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'ToolBar1
		'
		Me.ToolBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAceptar, Me.btnCancelarCheque, Me.btnCerrar})
		Me.ToolBar1.ButtonSize = New System.Drawing.Size(67, 36)
		Me.ToolBar1.DropDownArrows = True
		Me.ToolBar1.ImageList = Me.ImageList1
		Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
		Me.ToolBar1.Name = "ToolBar1"
		Me.ToolBar1.ShowToolTips = True
		Me.ToolBar1.Size = New System.Drawing.Size(464, 43)
		Me.ToolBar1.TabIndex = 26
		'
		'btnAceptar
		'
		Me.btnAceptar.Enabled = False
		Me.btnAceptar.ImageIndex = 0
		Me.btnAceptar.Name = "btnAceptar"
		Me.btnAceptar.Text = "Aceptar"
		'
		'btnCancelarCheque
		'
		Me.btnCancelarCheque.ImageIndex = 2
		Me.btnCancelarCheque.Name = "btnCancelarCheque"
		Me.btnCancelarCheque.Text = "Cancelar"
		'
		'btnCerrar
		'
		Me.btnCerrar.ImageIndex = 3
		Me.btnCerrar.Name = "btnCerrar"
		Me.btnCerrar.Text = "Salir"
		'
		'ImageList1
		'
		Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
		Me.ImageList1.Images.SetKeyName(0, "")
		Me.ImageList1.Images.SetKeyName(1, "")
		Me.ImageList1.Images.SetKeyName(2, "")
		Me.ImageList1.Images.SetKeyName(3, "")
		'
		'lblCliente
		'
		Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCliente.Location = New System.Drawing.Point(232, 56)
		Me.lblCliente.Name = "lblCliente"
		Me.lblCliente.Size = New System.Drawing.Size(224, 16)
		Me.lblCliente.TabIndex = 27
		Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'txtcodigo
		'
		Me.txtcodigo.BackColor = System.Drawing.SystemColors.Control
		Me.txtcodigo.Location = New System.Drawing.Point(232, 270)
		Me.txtcodigo.Name = "txtcodigo"
		Me.txtcodigo.Size = New System.Drawing.Size(224, 20)
		Me.txtcodigo.TabIndex = 0
		'
		'btnleer
		'
		Me.btnleer.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.btnleer.Location = New System.Drawing.Point(432, 254)
		Me.btnleer.Name = "btnleer"
		Me.btnleer.Size = New System.Drawing.Size(24, 16)
		Me.btnleer.TabIndex = 29
		'
		'btnAcepta
		'
		Me.btnAcepta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.btnAcepta.Location = New System.Drawing.Point(400, 254)
		Me.btnAcepta.Name = "btnAcepta"
		Me.btnAcepta.Size = New System.Drawing.Size(24, 16)
		Me.btnAcepta.TabIndex = 30
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(16, 176)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(73, 13)
		Me.Label8.TabIndex = 32
		Me.Label8.Text = "Fecha cobro :"
		'
		'dtpFCobro
		'
		Me.dtpFCobro.Location = New System.Drawing.Point(112, 176)
		Me.dtpFCobro.Name = "dtpFCobro"
		Me.dtpFCobro.Size = New System.Drawing.Size(213, 20)
		Me.dtpFCobro.TabIndex = 31
		'
		'frmCheque
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(464, 332)
		Me.Controls.Add(Me.Label8)
		Me.Controls.Add(Me.dtpFCobro)
		Me.Controls.Add(Me.btnAcepta)
		Me.Controls.Add(Me.btnleer)
		Me.Controls.Add(Me.txtcodigo)
		Me.Controls.Add(Me.lblCliente)
		Me.Controls.Add(Me.ToolBar1)
		Me.Controls.Add(Me.txtSaldo)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.txtCliente)
		Me.Controls.Add(Me.txtMonto)
		Me.Controls.Add(Me.dtpFCheque)
		Me.Controls.Add(Me.txtCuenta)
		Me.Controls.Add(Me.txtCheque)
		Me.Controls.Add(Me.cboBanco)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "frmCheque"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Cheque"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

#End Region

	Private Sub LlenaCombo()
        Dim da As New SqlDataAdapter("Select Banco,Nombre from Banco Where Status = 'Activo'", cnnSigamet)
        Dim dt As New DataTable("FormaPago")
        da.Fill(dt)
        With cboBanco
            .DataSource = dt
            .DisplayMember = "Nombre"
            .ValueMember = "Banco"
        End With
    End Sub

    Private Sub LlenaCheque()
        Dim Consulta As DataRow() = dtLiquidacion.Select("PedidoReferencia ='" & _PedidoReferencia & "'")
        Dim dr As DataRow
        For Each dr In Consulta
            txtCliente.Text = CType(dr.Item("Cliente"), String)
            cboBanco.SelectedValue = dr.Item("BancoCheque")
            txtCheque.Text = CType(dr.Item("NumeroCheque"), String)
            txtCuenta.Text = CType(dr.Item("NumCuentaCheque"), String)
            txtMonto.Text = CType(dr.Item("TotalCheque"), String)
            txtSaldo.Text = CType(dr.Item("SaldoCheque"), String)
            _TotalPedido = CType(dr.Item("tOTAL"), Decimal)
        Next

    End Sub

    'Private Sub llenaCheque()
    '    Dim daCheque As New SqlDataAdapter("select Cobro,AñoCobro,Banco,NumeroCheque,NumeroCuenta,FCheque,Saldo,TOTAL from cobro where status <> 'CANCELADO' and cobro = " & NumCobro & " and añocobro = " & _AñoCobro, cnnSigamet)
    '    Try

    '        Dim dtCheque As New DataTable("Cheque")
    '        daCheque.Fill(dtCheque)

    '        If dtCheque.Rows.Count <> 0 Then
    '            disponible = CType(dtCheque.Rows(0).Item("saldo"), Integer)
    '            If disponible <> 0 Then
    '                MessageBox.Show("El cheque tiene disponible: $ " + CType(disponible, String), "Servicio Técnico", MessageBoxButtons.OK)
    '                If MessageBox.Show("¿Desea Modificar el queque?", "Servicio Técnico", MessageBoxButtons.YesNo) = DialogResult.Yes Then
    '                    txtCheque.Text = CType(dtCheque.Rows(0).Item("Numerocheque"), String)
    '                    txtCuenta.Text = CType(dtCheque.Rows(0).Item("NumeroCuenta"), String)
    '                    cboBanco.SelectedValue = CType(dtCheque.Rows(0).Item("banco"), String)
    '                    dtpFCheque.Value = CType(dtCheque.Rows(0).Item("fcheque"), Date)
    '                    btnAceptar.Enabled = False
    '                    btnCancelarCheque.Enabled = False
    '                Else
    '                    If MessageBox.Show("¿Desea cancelar el cheque seleccionado?", "Servicios Técnicos", MessageBoxButtons.YesNo) = DialogResult.Yes Then
    '                        txtCheque.Text = CType(dtCheque.Rows(0).Item("Numerocheque"), String)
    '                        txtCuenta.Text = CType(dtCheque.Rows(0).Item("NumeroCuenta"), String)
    '                        cboBanco.SelectedValue = CType(dtCheque.Rows(0).Item("banco"), String)
    '                        dtpFCheque.Value = CType(dtCheque.Rows(0).Item("fcheque"), Date)
    '                        txtMonto.Text = CType(dtCheque.Rows(0).Item("total"), String)
    '                        btnAceptar.Enabled = False
    '                        btnModificar.Enabled = False
    '                    Else
    '                        txtCheque.Text = CType(dtCheque.Rows(0).Item("Numerocheque"), String)
    '                        txtCuenta.Text = CType(dtCheque.Rows(0).Item("NumeroCuenta"), String)
    '                        cboBanco.SelectedValue = CType(dtCheque.Rows(0).Item("banco"), String)
    '                        dtpFCheque.Value = CType(dtCheque.Rows(0).Item("fcheque"), Date)
    '                        btnModificar.Enabled = False
    '                        btnCancelarCheque.Enabled = False
    '                    End If
    '                End If

    '            Else

    '                'MessageBox.Show("El cheque no tiene saldo disponible", "Servicio Técnico", MessageBoxButtons.OK)
    '                If MessageBox.Show("¿Desea Modificar el chueque?", "Servicio Técnico", MessageBoxButtons.YesNo) = DialogResult.Yes Then
    '                    txtCheque.Text = CType(dtCheque.Rows(0).Item("Numerocheque"), String)
    '                    txtCuenta.Text = CType(dtCheque.Rows(0).Item("NumeroCuenta"), String)
    '                    cboBanco.SelectedValue = CType(dtCheque.Rows(0).Item("banco"), String)
    '                    dtpFCheque.Value = CType(dtCheque.Rows(0).Item("fcheque"), Date)
    '                    txtMonto.Text = CType(dtCheque.Rows(0).Item("total"), String)
    '                    btnAceptar.Enabled = False
    '                    btnCancelarCheque.Enabled = False
    '                Else
    '                    ''If MessageBox.Show("¿Desea cancelar el cheque seleccionado?", "Servicios Técnicos", MessageBoxButtons.YesNo) = DialogResult.Yes Then
    '                    'txtCheque.Text = CType(dtCheque.Rows(0).Item("Numerocheque"), String)
    '                    'txtCuenta.Text = CType(dtCheque.Rows(0).Item("NumeroCuenta"), String)
    '                    'cboBanco.SelectedValue = CType(dtCheque.Rows(0).Item("banco"), String)
    '                    'dtpFCheque.Value = CType(dtCheque.Rows(0).Item("fcheque"), Date)
    '                    'btnAceptar.Enabled = False
    '                    'btnModificar.Enabled = False
    '                    '' Else
    '                    ''End If
    '                End If

    '            End If
    '        Else
    '            Dim daCliente As New SqlDataAdapter("select Cliente,Nombre from cliente where cliente = " & txtCliente.Text, cnnSigamet)
    '            Dim dtCliente As New DataTable("Cliente")
    '            daCliente.Fill(dtCliente)
    '            lblCliente.Text = CType(dtCliente.Rows(0).Item("Nombre"), String)
    '        End If
    '    Catch e As Exception
    '        MessageBox.Show(e.Message)
    '    End Try

    'End Sub


    'Private Sub ExisteCheque()
    '    Dim daExisteCheque As New SqlDataAdapter("select Cliente,NumeroCheque,Total,Cobro From vwSTConsultaChequeServicioTecnico " _
    '                                             & "where status <> 'CANCELADO' and pedido = " & _Pedido & " and celula =" & _Celula & "and añoped = '" & _AñoPed & "'", ConString)
    '    Dim dtExisteCheque As New DataTable("ExisteCheque")
    '    daExisteCheque.Fill(dtExisteCheque)
    '    Dim NumCheque As String
    '    If dtExisteCheque.Rows.Count > 0 Then
    '        NumCheque = RTrim(CType(dtExisteCheque.Rows(0).Item("numerocheque"), String))
    '        If dtExisteCheque.Rows.Count > 0 Then
    '            If MessageBox.Show("¿Desea modificar el cheque?", "Servico Técnico", MessageBoxButtons.YesNo) = DialogResult.Yes Then
    '            Else
    '                MessageBox.Show("El pedido " + CType(_Pedido, String) + ". Tiene asignado el cheque " + NumCheque + ". No puede asignarle otro cheque", "Servicios Técnicos", MessageBoxButtons.OK)
    '                Me.Close()
    '            End If
    '        Else
    '        End If
    '    Else
    '    End If

    'End Sub

    'Private Sub NoRepetirCobro()
    '    Dim daNoRepetir As New SqlDataAdapter("select Cobro,AñoCobro from vwSTVerificaCobro where pedido = " & _Pedido & "and celula = " & _Celula & "and añoped = " & _AñoPed, cnnSigamet)
    '    Dim dtNoRepetir As New DataTable("NoRepetirCobro")
    '    daNoRepetir.Fill(dtNoRepetir)
    '    If dtNoRepetir.Rows.Count > 0 Then
    '        'MessageBox.Show("Ya capturo este pedido, seleccione otro.", "Servicios Técnicos", MessageBoxButtons.OK)
    '        CobroContado = CType(dtNoRepetir.Rows(0).Item("cobro"), Integer)
    '        AñoCobroContado = CType(dtNoRepetir.Rows(0).Item("añocobro"), Integer)
    '    Else
    '        CobroContado = 0
    '        AñoCobroContado = 0
    '    End If
    'End Sub

    'Private Sub LlenaChequeCancelado()
    '    Dim daChequeCancelado As New SqlDataAdapter("select Cliente,NumeroCheque,fcheque,Total,Cobro,Banco,NumeroCuenta From Cobro where cobro = " & NumCobro & "and añocobro = " & _AñoCobro, ConString)
    '    Dim dtChequeCancelado As New DataTable("ExisteCheque")
    '    daChequeCancelado.Fill(dtChequeCancelado)
    '    If dtChequeCancelado.Rows.Count <> 0 Then
    '        txtCheque.Text = CType(dtChequeCancelado.Rows(0).Item("Numerocheque"), String)
    '        txtCuenta.Text = CType(dtChequeCancelado.Rows(0).Item("NumeroCuenta"), String)
    '        cboBanco.SelectedValue = CType(dtChequeCancelado.Rows(0).Item("banco"), String)
    '        dtpFCheque.Value = CType(dtChequeCancelado.Rows(0).Item("fcheque"), Date)
    '        _Total = CType(dtChequeCancelado.Rows(0).Item("total"), Integer)

    '    Else
    '    End If

    'End Sub
    'Private Sub ChecaPedidoCancelado()
    '    Dim daPedidoCancelado As New SqlDataAdapter("select Pedido,Celula,AñoPed,Cobro,AñoCobro,total From CobroPedido where cobro = " & NumCobro & "and añocobro = " & _AñoCobro, ConString)
    '    Dim dtPedidoCancelado As New DataTable("PedidoCancelado")
    '    daPedidoCancelado.Fill(dtPedidoCancelado)
    '    If dtPedidoCancelado.Rows.Count <> 0 Then
    '        _Pedido = CType(dtPedidoCancelado.Rows(0).Item("pedido"), Integer)
    '        _Celula = CType(dtPedidoCancelado.Rows(0).Item("celula"), Integer)
    '        _AñoPed = CType(dtPedidoCancelado.Rows(0).Item("añoped"), Integer)


    '    Else

    '    End If

    'End Sub

    'Private Sub Llenacomplemento()
    '    Dim daComplemento As New SqlDataAdapter("select Pedido,Celula,AñoPed,Cobro,AñoCobro,total From CobroPedido where pedido = " & _Pedido & "and celula = " & _Celula & "and AñoPed = " & _AñoPed, ConString)
    '    Dim dtComplemento As New DataTable("Complemento")
    '    daComplemento.Fill(dtComplemento)
    '    If dtComplemento.Rows.Count <> 1 Then
    '        Dim i As Integer
    '        i = 0
    '        While i <= dtComplemento.Rows.Count
    '            TotalComplemento = CType(dtComplemento.Rows(i).Item("total"), Integer)
    '            If TotalComplemento <> _Total Then
    '                Cobrocomplemento = CType(dtComplemento.Rows(i).Item("cobro"), Integer)
    '                AñoCobroComplemento = CType(dtComplemento.Rows(i).Item("añocobro"), Integer)
    '                Exit While
    '            Else
    '                i = i + 1
    '            End If
    '        End While
    '    Else
    '    End If
    'End Sub


    Private Sub Suma()
        Monto = CType(Format(CType(txtMonto.Text, Decimal), "###,###.##"), Decimal)
        If Monto = _TotalPedido Then
            Saldo = Monto - _TotalPedido
            txtSaldo.Text = CType(Saldo, String)
        Else
            If Monto > _TotalPedido Then
                Saldo = Monto - _TotalPedido
                txtSaldo.Text = Format(Saldo, "###,###.##")
            Else
                Saldo = _TotalPedido - Monto
                txtSaldo.Text = CType(0, String)
            End If
        End If
        'Saldo = Monto - _Total
        'txtSaldo.Text = Format(Saldo, "###,###.##")
    End Sub


    Private Sub frmCheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LlenaCombo()
        llenaCheque()


    End Sub


    Private Sub txtCliente_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.Validated

        'ExisteCheque()


    End Sub


    Private Sub txtSaldo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSaldo.Enter
        Suma()
    End Sub

    Private Sub txtCodigo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodigo.Enter
        Me.AcceptButton = btnleer
    End Sub

    Private Sub txtCodigo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcodigo.Leave
        Me.AcceptButton = btnAcepta
    End Sub

    Private Sub btnLeer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnleer.Click
        Dim strCodigo As String = txtcodigo.Text.Trim
        Dim NumeroCuenta As String
        Dim NumeroCheque As String
        NumeroCuenta = Mid(strCodigo, 16, 11)
        NumeroCheque = Mid(strCodigo, 28, 7)

        txtCuenta.Text = NumeroCuenta
        txtCheque.Text = NumeroCheque
        txtcodigo.Text = ""
    End Sub

    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        Select Case e.Button.Text
            Case "Aceptar"

                If txtCliente.Text = "" Then
                    MsgBox("Teclee un numero de cliente.", MsgBoxStyle.Exclamation, "Mensaje del sistema")
                    Exit Sub
                End If

                If txtCheque.Text = "" Then
                    MsgBox("Teclee un numero de cheque.", MsgBoxStyle.Exclamation, "Mensaje del sistema")
                    Exit Sub
                End If

                If txtCuenta.Text = "" Then
                    MsgBox("Teclee un numero de cuenta.", MsgBoxStyle.Exclamation, "Mensaje del sistema")
                    Exit Sub
                End If

                If txtMonto.Text = "" Then
                    MsgBox("Teclee un monto para el cheque.", MsgBoxStyle.Exclamation, "Mensaje del sistema")
                    Exit Sub
                End If

                Dim Consulta As DataRow() = dtLiquidacion.Select("PedidoReferencia = '" & _PedidoReferencia & "'")
                Dim dr As DataRow
                For Each dr In Consulta
                    dr.BeginEdit()
                    dr("BancoCheque") = cboBanco.SelectedValue
                    dr("NumeroCheque") = txtCheque.Text
					dr("FCheque") = dtpFCheque.Value
					dr("FCobro") = dtpFCobro.Value
					dr("NumCuentaCheque") = txtCuenta.Text
                    dr("TotalCheque") = txtMonto.Text
                    dr("SaldoCheque") = txtSaldo.Text
                    dr("TipoCobroCheque") = 3
                    dr.EndEdit()
                Next
                Me.Close()
                'Dim Conexion As New SqlConnection(ConString)
                'Conexion.Open()
                'Dim sqlcomando As New SqlCommand()
                'Dim Transaccion As SqlTransaction
                'sqlcomando.Parameters.Add("@Cliente", SqlDbType.Int).Value = txtCliente.Text
                'sqlcomando.Parameters.Add("@Banco", SqlDbType.Char).Value = cboBanco.SelectedValue
                'sqlcomando.Parameters.Add("@NumCheque", SqlDbType.Char).Value = txtCheque.Text
                'sqlcomando.Parameters.Add("@FCheque", SqlDbType.DateTime).Value = dtpFCheque.Value
                'sqlcomando.Parameters.Add("@Cuenta", SqlDbType.Char).Value = txtCuenta.Text
                'sqlcomando.Parameters.Add("@Monto", SqlDbType.Money).Value = txtMonto.Text
                'sqlcomando.Parameters.Add("@Usuario", SqlDbType.Char).Value = _Usuario
                'sqlcomando.Parameters.Add("@Pedido", SqlDbType.Int).Value = _Pedido
                'sqlcomando.Parameters.Add("@Celula", SqlDbType.Int).Value = _Celula
                'sqlcomando.Parameters.Add("@Añoped", SqlDbType.Int).Value = _AñoPed
                'sqlcomando.Parameters.Add("@CobroContado", SqlDbType.Int).Value = CobroContado
                'sqlcomando.Parameters.Add("@AñoCobroContado", SqlDbType.Int).Value = AñoCobroContado
                'If txtSaldo.Text = "" Then
                'Else
                '    sqlcomando.Parameters.Add("@Saldo", SqlDbType.Money).Value = txtSaldo.Text
                'End If

                'If NumCobro = 0 Then
                'Else
                '    sqlcomando.Parameters.Add("@Cobro", SqlDbType.Int).Value = NumCobro
                '    sqlcomando.Parameters.Add("@AñoCobro", SqlDbType.Int).Value = _AñoCobro
                'End If



                'Transaccion = Conexion.BeginTransaction
                'sqlcomando.Connection = Conexion
                'sqlcomando.Transaction = Transaccion
                'Try
                '    sqlcomando.CommandType = CommandType.StoredProcedure
                '    sqlcomando.CommandText = "spSTInsertaChequeServicioTecnico"
                '    sqlcomando.CommandTimeout = 300
                '    sqlcomando.ExecuteNonQuery()
                '    Transaccion.Commit()
                'Catch eExc As Exception
                '    Transaccion.Rollback()
                '    MessageBox.Show(eExc.Message)
                'Finally
                '    Conexion.Close()
                '    Conexion.Dispose()
                '    Me.Close()
                'End Try
            Case "Cancelar"

                Dim Consulta As DataRow() = dtLiquidacion.Select("PedidoReferencia = '" & _PedidoReferencia & "'")
                Dim dr As DataRow
                For Each dr In Consulta
                    dr.BeginEdit()
                    dr("BancoCheque") = 0
                    dr("NumeroCheque") = ""
                    dr("NumCuentaCheque") = ""
                    dr("TotalCheque") = 0
                    dr("SaldoCheque") = 0
                    dr("TipoCobroCheque") = 0
                    dr.EndEdit()
                Next
                Me.Close()

                'If MessageBox.Show("¿Desea cancelar el cheque?", "Servicio Técnico", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                '    Dim conexion As New SqlConnection(ConString)
                '    conexion.Open()
                '    Dim sqlcomando As New SqlCommand()
                '    Dim Transaccion As SqlTransaction
                '    sqlcomando.Parameters.Add("@Cobro", SqlDbType.Int).Value = NumCobro
                '    sqlcomando.Parameters.Add("@AñoCobro", SqlDbType.SmallInt).Value = _AñoCobro
                '    sqlcomando.Parameters.Add("@Pedido", SqlDbType.Int).Value = _Pedido
                '    sqlcomando.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = _Celula
                '    sqlcomando.Parameters.Add("@AñoPed", SqlDbType.SmallInt).Value = _AñoPed
                '    sqlcomando.Parameters.Add("@CobroComplemento", SqlDbType.Int).Value = Cobrocomplemento
                '    sqlcomando.Parameters.Add("@AñoCobroComplemento", SqlDbType.Int).Value = AñoCobroComplemento
                '    transaccion = conexion.BeginTransaction
                '    sqlcomando.Connection = conexion
                '    sqlcomando.Transaction = transaccion
                '    Try
                '        sqlcomando.CommandType = CommandType.StoredProcedure
                '        sqlcomando.CommandText = "spSTCancelaCheque"
                '        sqlcomando.CommandTimeout = 300
                '        sqlcomando.ExecuteNonQuery()
                '        transaccion.Commit()
                '    Catch ex As Exception
                '        transaccion.Rollback()
                '        MessageBox.Show(ex.Message)
                '    Finally
                '        conexion.Close()
                '        conexion.Dispose()
                '        Me.Close()
                '    End Try
                'Else
                'End If

            Case "Salir"
                If MessageBox.Show("¿Desea salir de la captura de Cheque?", "Servicios Técnicos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Else
                    Me.Close()
                End If
        End Select
    End Sub

    Private Sub txtCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCliente.TextChanged

    End Sub

    Private Sub txtCheque_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCheque.Validated
        If Len(txtCheque.Text) < 7 Then
            MessageBox.Show("Debe capturar 7 digitos", "Servicios Técnicos", MessageBoxButtons.OK)
        Else
        End If
    End Sub

End Class

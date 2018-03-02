Option Strict On
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class CapturaCobro
    Inherits System.Windows.Forms.Form
    Private _AnoCobro As Short
    Private _Cobro As Integer
    Private _TipoCobro As Byte
    Private _Estatus As String

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
    Friend WithEvents lblAnoCobro As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCobro As System.Windows.Forms.Label
    Friend WithEvents ComboBanco As SigaMetClasses.Combos.ComboBanco
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFCheque As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroCheque As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtNumeroCuenta As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtCliente As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents cboTipoCobro As SigaMetClasses.Combos.ComboTipoCobro
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtNumeroCtaDestino As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ComboBancoOrigen As SigaMetClasses.Combos.ComboBanco
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CapturaCobro))
        Me.lblAnoCobro = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCobro = New System.Windows.Forms.Label()
        Me.ComboBanco = New SigaMetClasses.Combos.ComboBanco()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFCheque = New System.Windows.Forms.DateTimePicker()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNumeroCheque = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtNumeroCuenta = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.cboTipoCobro = New SigaMetClasses.Combos.ComboTipoCobro()
        Me.TxtNumeroCtaDestino = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ComboBancoOrigen = New SigaMetClasses.Combos.ComboBanco()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblAnoCobro
        '
        Me.lblAnoCobro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAnoCobro.Location = New System.Drawing.Point(152, 16)
        Me.lblAnoCobro.Name = "lblAnoCobro"
        Me.lblAnoCobro.Size = New System.Drawing.Size(88, 21)
        Me.lblAnoCobro.TabIndex = 0
        Me.lblAnoCobro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Año:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Cobro:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCobro
        '
        Me.lblCobro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCobro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCobro.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblCobro.Location = New System.Drawing.Point(152, 40)
        Me.lblCobro.Name = "lblCobro"
        Me.lblCobro.Size = New System.Drawing.Size(88, 21)
        Me.lblCobro.TabIndex = 1
        Me.lblCobro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBanco
        '
        Me.ComboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBanco.Location = New System.Drawing.Point(152, 136)
        Me.ComboBanco.Name = "ComboBanco"
        Me.ComboBanco.Size = New System.Drawing.Size(272, 21)
        Me.ComboBanco.TabIndex = 3
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(440, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(440, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 163)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 14)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "No. documento / cheque:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 14)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "No. cuenta:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFCheque
        '
        Me.dtpFCheque.Location = New System.Drawing.Point(152, 256)
        Me.dtpFCheque.Name = "dtpFCheque"
        Me.dtpFCheque.Size = New System.Drawing.Size(272, 21)
        Me.dtpFCheque.TabIndex = 7
        '
        'txtObservaciones
        '
        Me.txtObservaciones.AutoSize = False
        Me.txtObservaciones.Location = New System.Drawing.Point(152, 280)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(272, 40)
        Me.txtObservaciones.TabIndex = 8
        Me.txtObservaciones.Text = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 14)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Banco:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 259)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 14)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "F. documento / cheque:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 280)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 14)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Observaciones:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumeroCheque
        '
        Me.txtNumeroCheque.Location = New System.Drawing.Point(152, 160)
        Me.txtNumeroCheque.Name = "txtNumeroCheque"
        Me.txtNumeroCheque.Size = New System.Drawing.Size(272, 21)
        Me.txtNumeroCheque.TabIndex = 4
        Me.txtNumeroCheque.Text = ""
        '
        'txtNumeroCuenta
        '
        Me.txtNumeroCuenta.Location = New System.Drawing.Point(152, 184)
        Me.txtNumeroCuenta.Name = "txtNumeroCuenta"
        Me.txtNumeroCuenta.Size = New System.Drawing.Size(272, 21)
        Me.txtNumeroCuenta.TabIndex = 5
        Me.txtNumeroCuenta.Text = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 91)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 14)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Tipo de cobro:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal
        '
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.Location = New System.Drawing.Point(152, 64)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(88, 21)
        Me.lblTotal.TabIndex = 20
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 67)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 14)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Total:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblStatus.Location = New System.Drawing.Point(336, 64)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(88, 21)
        Me.lblStatus.TabIndex = 22
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(288, 67)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 14)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Estatus:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(152, 112)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(272, 21)
        Me.txtCliente.TabIndex = 24
        Me.txtCliente.Text = ""
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 14)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Cliente:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Bitmap)
        Me.btnBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarCliente.Location = New System.Drawing.Point(440, 112)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.TabIndex = 26
        Me.btnBuscarCliente.Text = "Cliente..."
        Me.btnBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboTipoCobro
        '
        Me.cboTipoCobro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCobro.Location = New System.Drawing.Point(152, 88)
        Me.cboTipoCobro.Name = "cboTipoCobro"
        Me.cboTipoCobro.Size = New System.Drawing.Size(272, 21)
        Me.cboTipoCobro.TabIndex = 27
        '
        'TxtNumeroCtaDestino
        '
        Me.TxtNumeroCtaDestino.Enabled = False
        Me.TxtNumeroCtaDestino.Location = New System.Drawing.Point(152, 232)
        Me.TxtNumeroCtaDestino.Name = "TxtNumeroCtaDestino"
        Me.TxtNumeroCtaDestino.Size = New System.Drawing.Size(272, 21)
        Me.TxtNumeroCtaDestino.TabIndex = 6
        Me.TxtNumeroCtaDestino.Text = ""
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 235)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 14)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "No. cuenta destino:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBancoOrigen
        '
        Me.ComboBancoOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBancoOrigen.Enabled = False
        Me.ComboBancoOrigen.Location = New System.Drawing.Point(152, 208)
        Me.ComboBancoOrigen.Name = "ComboBancoOrigen"
        Me.ComboBancoOrigen.Size = New System.Drawing.Size(272, 21)
        Me.ComboBancoOrigen.TabIndex = 30
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 212)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 14)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Banco origen:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CapturaCobro
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(522, 337)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label13, Me.ComboBancoOrigen, Me.Label12, Me.TxtNumeroCtaDestino, Me.cboTipoCobro, Me.btnBuscarCliente, Me.Label8, Me.txtCliente, Me.Label11, Me.Label10, Me.Label9, Me.Label7, Me.Label6, Me.Label5, Me.Label4, Me.Label1, Me.Label3, Me.Label2, Me.lblStatus, Me.lblTotal, Me.txtNumeroCuenta, Me.txtNumeroCheque, Me.txtObservaciones, Me.dtpFCheque, Me.btnCancelar, Me.btnAceptar, Me.ComboBanco, Me.lblCobro, Me.lblAnoCobro})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CapturaCobro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificación de cobro"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal AnoCobro As Short, _
                   ByVal Cobro As Integer, _
                   ByVal Usuario As String)

        MyBase.New()
        InitializeComponent()
        _AnoCobro = AnoCobro
        _Cobro = Cobro
        ComboBanco.CargaDatos(True, True)
        cboTipoCobro.CargaDatosCaptura()
        CargaDatos(_AnoCobro, _Cobro)

        AddHandler cboTipoCobro.SelectedValueChanged, AddressOf cboTipoCobro_SelectedValueChanged
    End Sub

    Private Sub VerificaCaptura()
        If _Estatus <> "EMITIDO" Then
            txtCliente.Enabled = False
            ComboBanco.Enabled = False
            txtNumeroCheque.Enabled = False
            txtNumeroCuenta.Enabled = False
            dtpFCheque.Enabled = False
            txtObservaciones.Enabled = False
            btnAceptar.Enabled = False
            lblStatus.ForeColor = System.Drawing.Color.Red
        End If
    End Sub

    Private Sub CargaDatos(ByVal AnoCobro As Short, ByVal Cobro As Integer)
        Cursor = Cursors.WaitCursor
        Dim strQuery As String = "Select c.AñoCobro, c.Cobro, c.Total, c.Status, c.Cliente, c.Banco, " & _
        "Isnull(c.NumeroCheque,'') as NumeroCheque, " & _
        "Isnull(c.NumeroCuenta,'') as NumeroCuenta, " & _
        "c.FCheque, Isnull(c.Observaciones,'') as Observaciones, c.TipoCobro, " & _
        "ISNULL(c.NumeroCuentaDestino, '') as NumeroCuentaDestino, " & _
        "c.BancoOrigen " & _
        "From Cobro c " & _
        "Where c.AñoCobro = " & _AnoCobro.ToString & _
        " And c.Cobro = " & _Cobro.ToString
        Dim da As New SqlDataAdapter(strQuery, DataLayer.Conexion)
        Dim dt As New DataTable("Cobro")
        Try
            da.Fill(dt)
            If dt.Rows.Count = 1 Then
                lblAnoCobro.Text = CType(dt.Rows(0).Item("AñoCobro"), Short).ToString
                lblCobro.Text = CType(dt.Rows(0).Item("Cobro"), Integer).ToString
                lblTotal.Text = CType(dt.Rows(0).Item("Total"), Decimal).ToString("N")
                If Not IsDBNull(dt.Rows(0).Item("Cliente")) Then
                    txtCliente.Text = CType(dt.Rows(0).Item("Cliente"), String)
                End If
                _TipoCobro = CType(dt.Rows(0).Item("TipoCobro"), Byte)
                cboTipoCobro.SelectedValue = _TipoCobro
                _Estatus = Trim(CType(dt.Rows(0).Item("Status"), String))
                lblStatus.Text = _Estatus
                VerificaCaptura()
                If _TipoCobro <> 5 Then
                    If Not IsDBNull(dt.Rows(0).Item("Banco")) Then
                        ComboBanco.SelectedValue = CType(dt.Rows(0).Item("Banco"), Short)
                    End If
                    txtNumeroCheque.Text = Trim(CType(dt.Rows(0).Item("NumeroCheque"), String))
                    txtNumeroCuenta.Text = Trim(CType(dt.Rows(0).Item("NumeroCuenta"), String))

                    'Modificación para captura de transferencias bancarias
                    '23-03-2005 Jorge A. Guerrero Domínguez
                    TxtNumeroCtaDestino.Text = Trim(CType(dt.Rows(0).Item("NumeroCuentaDestino"), String))
                    If Not IsDBNull(dt.Rows(0).Item("BancoOrigen")) Then
                        ComboBancoOrigen.CargaDatos(True, True)
                        ComboBancoOrigen.SelectedValue = CType(dt.Rows(0).Item("BancoOrigen"), Short)
                    End If

                    If Not IsDBNull(dt.Rows(0).Item("FCheque")) Then
                        dtpFCheque.Value = CType(dt.Rows(0).Item("FCheque"), Date).Date
                    Else
                        dtpFCheque.Value = FechaServidor.Date
                        dtpFCheque.Enabled = False
                    End If
                Else
                    txtCliente.Enabled = False
                    ComboBanco.Enabled = False
                    txtNumeroCheque.Enabled = False
                    txtNumeroCuenta.Enabled = False
                    dtpFCheque.Enabled = False
                    txtObservaciones.Enabled = False
                    btnAceptar.Enabled = False
                    btnBuscarCliente.Enabled = False
                End If
                txtObservaciones.Text = Trim(CType(dt.Rows(0).Item("Observaciones"), String))
            Else
                MessageBox.Show("El cobro no se encontró en la base de datos.", Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
                btnAceptar.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MessageBox.Show(SigaMetClasses.M_ESTAN_CORRECTOS, Me.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Dim oCobro As New SigaMetClasses.Cobro()
            Try
                Cursor = Cursors.WaitCursor

                'Modificación para captura de transferencias bancarias
                '23-03-2005 Jorge A. Guerrero Domínguez
                Dim _BancoOrigen As Short
                If CType(cboTipoCobro.SelectedValue, Byte) = 10 Then
                    _BancoOrigen = CType(ComboBancoOrigen.SelectedValue, Short)
                Else
                    _BancoOrigen = Nothing
                End If

                oCobro.Modifica(_AnoCobro, _Cobro, CType(ComboBanco.SelectedValue, Short), txtNumeroCheque.Text, txtNumeroCuenta.Text, _
                    CType(cboTipoCobro.SelectedValue, Byte), dtpFCheque.Value.Date, txtObservaciones.Text, TxtNumeroCtaDestino.Text, _BancoOrigen)

                Me.DialogResult = DialogResult.OK
            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default
                oCobro = Nothing
            End Try

        End If
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim oCliente As New BuscaCliente(1000, True)
        If oCliente.ShowDialog() = DialogResult.OK Then
            txtCliente.Text = oCliente.ClienteSeleccionado.ToString
            txtCliente.SelectAll()
        End If
    End Sub

    Private Sub cboTipoCobro_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If CType(cboTipoCobro.SelectedValue, Byte) = 10 Then
            TxtNumeroCtaDestino.Enabled = True
            ComboBancoOrigen.Enabled = True
            Label5.Text = "Banco destino:"
        Else
            TxtNumeroCtaDestino.Enabled = False
            ComboBancoOrigen.Enabled = False
            Label5.Text = "Banco:"
        End If
    End Sub

End Class

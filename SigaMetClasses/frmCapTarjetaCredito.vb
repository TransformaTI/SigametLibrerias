Option Strict On

Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class frmCapTarjetaCredito

    Inherits System.Windows.Forms.Form

#Region "Variables"
    Private Titulo As String = "Tarjeta de crédito"
    Private _Cliente As Integer
    Private _TarjetaCredito As String
    Private _Titular As String
    Private _Banco As Short
    Private _AnoVigencia As Short
    Private _MesVigencia As Byte
    Private _Domicilio As String
    Private _TipoTarjetaCredito As Byte
    Private _Identificacion As String
    Private _Firma As String
    Private _Status As String
    Private _Recurrente As Boolean
    Private _Operacion As SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo
    Private _DigitosTarjeta As Integer
    Private _URLGateway As String

    'strTarjetaCredito = txtTarjetaCredito.Text.Trim
    'Ocultar el número de tarjeta de crédito JAGD 11-01-2007
    Private _NumeroOcultoTarjetaCredito As String
    Private _OcultarTarjetaCredito As Boolean
#End Region

#Region "Constructores"
    Public Sub New(ByVal Cliente As Integer, Optional ByVal URLGateway As String = Nothing)
        MyBase.New()
        InitializeComponent()
        ComboTipoTarjetaCredito.CargaDatos() 'Carga los datos del combo de tipo de tarjeta, a él se agrega la cantidad de dígitos
        ComboBanco.CargaDatos()
        _Cliente = Cliente
        _Operacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar

        Me.Text = "Captura de tarjeta de crédito"
    End Sub

    Public Sub New(ByVal Cliente As Integer, _
                   ByVal TarjetaCredito As String, _
                   ByVal Titular As String, _
                   ByVal Banco As Short, _
                   ByVal AnoVigencia As Short, _
                   ByVal MesVigencia As Byte, _
                   ByVal Domicilio As String, _
                   ByVal TipoTarjetaCredito As Byte, _
                   ByVal Identificacion As String, _
                   ByVal Firma As String, _
                   ByVal Status As String, _
                   ByVal Recurrente As Boolean, _
                   ByVal OcultarNumeroTarjeta As Boolean, _
                   ByVal NumeroOcultoTarjetaCredito As String)

        MyBase.New()
        InitializeComponent()
        ComboTipoTarjetaCredito.CargaDatos()
        ComboBanco.CargaDatos()


        _Cliente = Cliente
        _TarjetaCredito = TarjetaCredito
        _Titular = Titular
        _Banco = Banco
        _AnoVigencia = AnoVigencia
        _MesVigencia = MesVigencia
        _Domicilio = Domicilio
        _TipoTarjetaCredito = TipoTarjetaCredito
        _Identificacion = Identificacion
        _Firma = Firma
        _Status = Status
        _Recurrente = Recurrente
        _Operacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar

        'strTarjetaCredito = txtTarjetaCredito.Text.Trim
        'Ocultar el número de tarjeta de crédito JAGD 11-01-2007
        _OcultarTarjetaCredito = OcultarNumeroTarjeta
        _NumeroOcultoTarjetaCredito = NumeroOcultoTarjetaCredito

        CargaDatosTarjetaCredito()
        txtTarjetaCredito.Enabled = False
        Me.Text = "Modificar y activar tarjeta de crédito"

    End Sub

#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        InitializeComponent()

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTitular As System.Windows.Forms.TextBox
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents txtIdentificacion As System.Windows.Forms.TextBox
    Friend WithEvents lblFirma As System.Windows.Forms.Label
    Friend WithEvents btnSeleccionarFirma As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ComboTipoTarjetaCredito As SigaMetClasses.Combos.ComboTipoTarjetaCredito
    Friend WithEvents ComboBanco As SigaMetClasses.Combos.ComboBanco
    Friend WithEvents txtTarjetaCredito As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtAnoVigencia As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtMesVigencia As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents chkRecurrente As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCapTarjetaCredito))
        Me.txtTitular = New System.Windows.Forms.TextBox()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.txtIdentificacion = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSeleccionarFirma = New System.Windows.Forms.Button()
        Me.lblFirma = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ComboTipoTarjetaCredito = New SigaMetClasses.Combos.ComboTipoTarjetaCredito()
        Me.ComboBanco = New SigaMetClasses.Combos.ComboBanco()
        Me.txtTarjetaCredito = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtAnoVigencia = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtMesVigencia = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.chkRecurrente = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'txtTitular
        '
        Me.txtTitular.Location = New System.Drawing.Point(152, 40)
        Me.txtTitular.Name = "txtTitular"
        Me.txtTitular.Size = New System.Drawing.Size(296, 21)
        Me.txtTitular.TabIndex = 1
        Me.txtTitular.Text = ""
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Location = New System.Drawing.Point(152, 112)
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(296, 21)
        Me.txtDomicilio.TabIndex = 5
        Me.txtDomicilio.Text = ""
        '
        'txtIdentificacion
        '
        Me.txtIdentificacion.Location = New System.Drawing.Point(152, 160)
        Me.txtIdentificacion.Name = "txtIdentificacion"
        Me.txtIdentificacion.Size = New System.Drawing.Size(296, 21)
        Me.txtIdentificacion.TabIndex = 7
        Me.txtIdentificacion.Text = ""
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(472, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(472, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 14)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "No. de tarjeta de crédito:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 14)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Nombre del titular:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 14)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Banco:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 14)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Año de vigencia:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(296, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 14)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Mes de vigencia:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 14)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Domicilio:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 14)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Tipo de tarjeta:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 163)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 14)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Identificación:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 187)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 14)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Imágen de la firma:"
        '
        'btnSeleccionarFirma
        '
        Me.btnSeleccionarFirma.Enabled = False
        Me.btnSeleccionarFirma.Location = New System.Drawing.Point(456, 184)
        Me.btnSeleccionarFirma.Name = "btnSeleccionarFirma"
        Me.btnSeleccionarFirma.Size = New System.Drawing.Size(24, 21)
        Me.btnSeleccionarFirma.TabIndex = 20
        Me.btnSeleccionarFirma.Text = "..."
        '
        'lblFirma
        '
        Me.lblFirma.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFirma.Location = New System.Drawing.Point(152, 184)
        Me.lblFirma.Name = "lblFirma"
        Me.lblFirma.Size = New System.Drawing.Size(296, 21)
        Me.lblFirma.TabIndex = 21
        Me.lblFirma.Text = "SIN FIRMA"
        Me.lblFirma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(152, 208)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(296, 21)
        Me.lblStatus.TabIndex = 27
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 211)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 14)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "Imágen de la firma:"
        '
        'ComboTipoTarjetaCredito
        '
        Me.ComboTipoTarjetaCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTipoTarjetaCredito.Location = New System.Drawing.Point(152, 136)
        Me.ComboTipoTarjetaCredito.Name = "ComboTipoTarjetaCredito"
        Me.ComboTipoTarjetaCredito.Size = New System.Drawing.Size(296, 21)
        Me.ComboTipoTarjetaCredito.TabIndex = 6
        '
        'ComboBanco
        '
        Me.ComboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBanco.Location = New System.Drawing.Point(152, 64)
        Me.ComboBanco.Name = "ComboBanco"
        Me.ComboBanco.Size = New System.Drawing.Size(296, 21)
        Me.ComboBanco.TabIndex = 2
        '
        'txtTarjetaCredito
        '
        Me.txtTarjetaCredito.Location = New System.Drawing.Point(152, 16)
        Me.txtTarjetaCredito.MaxLength = 16
        Me.txtTarjetaCredito.Name = "txtTarjetaCredito"
        Me.txtTarjetaCredito.Size = New System.Drawing.Size(152, 21)
        Me.txtTarjetaCredito.TabIndex = 0
        Me.txtTarjetaCredito.Text = ""
        '
        'txtAnoVigencia
        '
        Me.txtAnoVigencia.Location = New System.Drawing.Point(152, 88)
        Me.txtAnoVigencia.MaxLength = 4
        Me.txtAnoVigencia.Name = "txtAnoVigencia"
        Me.txtAnoVigencia.Size = New System.Drawing.Size(112, 21)
        Me.txtAnoVigencia.TabIndex = 3
        Me.txtAnoVigencia.Text = ""
        '
        'txtMesVigencia
        '
        Me.txtMesVigencia.Location = New System.Drawing.Point(384, 88)
        Me.txtMesVigencia.MaxLength = 2
        Me.txtMesVigencia.Name = "txtMesVigencia"
        Me.txtMesVigencia.Size = New System.Drawing.Size(64, 21)
        Me.txtMesVigencia.TabIndex = 4
        Me.txtMesVigencia.Text = ""
        '
        'chkRecurrente
        '
        Me.chkRecurrente.Location = New System.Drawing.Point(152, 240)
        Me.chkRecurrente.Name = "chkRecurrente"
        Me.chkRecurrente.Size = New System.Drawing.Size(296, 16)
        Me.chkRecurrente.TabIndex = 8
        Me.chkRecurrente.Text = "Tarjeta de crédito recurrente"
        '
        'frmCapTarjetaCredito
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(552, 271)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkRecurrente, Me.txtMesVigencia, Me.txtAnoVigencia, Me.txtTarjetaCredito, Me.ComboBanco, Me.ComboTipoTarjetaCredito, Me.Label11, Me.lblStatus, Me.lblFirma, Me.btnSeleccionarFirma, Me.Label9, Me.Label8, Me.Label7, Me.Label6, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.Label1, Me.btnCancelar, Me.btnAceptar, Me.txtIdentificacion, Me.txtDomicilio, Me.txtTitular})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapTarjetaCredito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tarjeta de crédito"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ValidaCaptura() = True Then
            If MessageBox.Show(M_ESTAN_CORRECTOS, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim oTarjeta As New SigaMetClasses.cTarjetaCredito()
                Dim strTarjetaCredito As String

                'strTarjetaCredito = txtTarjetaCredito.Text.Trim
                'Ocultar el número de tarjeta de crédito JAGD 11-01-2007
                If _Operacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar Then
                    strTarjetaCredito = txtTarjetaCredito.Text.Trim
                Else
                    If Not _OcultarTarjetaCredito Then
                        strTarjetaCredito = txtTarjetaCredito.Text.Trim
                    Else
                        strTarjetaCredito = _TarjetaCredito
                    End If
                End If

                Dim i As Integer = oTarjeta.Valida(strTarjetaCredito)
                If i <> 0 Then
                    If MessageBox.Show("El número de tarjeta de crédito parece ser inválido. ¿Desea continuar?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        oTarjeta = Nothing
                        Exit Sub
                    End If
                End If
                Try
                    If _Operacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar Then
                        oTarjeta.AltaModifica(_Cliente, strTarjetaCredito, _
                        txtTitular.Text, CType(ComboBanco.SelectedValue, Short), CType(txtAnoVigencia.Text, Short), _
                        CType(txtMesVigencia.Text, Byte), txtDomicilio.Text, _
                        CType(ComboTipoTarjetaCredito.SelectedValue, Byte), _
                        txtIdentificacion.Text, lblFirma.Text, chkRecurrente.Checked)
                    End If
                    If _Operacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar Then
                        oTarjeta.AltaModifica(_Cliente, strTarjetaCredito, _
                        txtTitular.Text, CType(ComboBanco.SelectedValue, Short), CType(txtAnoVigencia.Text, Short), _
                        CType(txtMesVigencia.Text, Byte), txtDomicilio.Text, _
                        CType(ComboTipoTarjetaCredito.SelectedValue, Byte), _
                        txtIdentificacion.Text, lblFirma.Text, chkRecurrente.Checked, Alta:=False)
                    End If

                    'Ocultar el número de tarjeta de crédito JAGD 11-01-2007
                    'MessageBox.Show("La tarjeta de crédito: " & Trim(_TarjetaCredito) & " ha quedado activada.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    MessageBox.Show("La tarjeta de crédito: " & Trim(txtTarjetaCredito.Text.Trim) & " ha quedado activada.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DialogResult = DialogResult.OK

                Catch ex As Exception
                    MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)

                Finally
                    oTarjeta = Nothing
                End Try

            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Function ValidaCaptura() As Boolean
        ValidaCaptura = False
        _DigitosTarjeta = DigitosTarjeta(Convert.ToInt16(ComboTipoTarjetaCredito.SelectedValue))
        If (Convert.ToInt32(ComboTipoTarjetaCredito.SelectedValue) <> 3 And txtTarjetaCredito.Text.Trim.Length > 0) Or (Convert.ToInt32(ComboTipoTarjetaCredito.SelectedValue) = 3 And txtTarjetaCredito.Text.Trim.Length = _DigitosTarjeta) Then
            If txtTitular.Text.Trim <> "" Then
                If CType(ComboBanco.SelectedValue, Short) > 0 Then
                    If txtAnoVigencia.Text <> "" And IsNumeric(txtAnoVigencia.Text) Then
                        If txtMesVigencia.Text <> "" And IsNumeric(txtMesVigencia.Text) Then
                            If txtDomicilio.Text <> "" Then
                                If ComboTipoTarjetaCredito.Text <> "" Then
                                    If txtIdentificacion.Text <> "" Then
                                        ValidaCaptura = True
                                    Else
                                        MessageBox.Show("Debe teclear la identificación.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    End If
                                Else
                                    MessageBox.Show("Debe seleccionar el tipo de tarjeta de crédito.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                End If
                            Else
                                MessageBox.Show("Debe teclear el domicilio.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        Else
                            MessageBox.Show("Debe teclear el mes de vigencia de la tarjeta de crédito.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    Else
                        MessageBox.Show("Debe teclear el año de vigencia de la tarjeta de crédito.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Else
                    MessageBox.Show("Debe seleccionar el banco.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("Debe teclear el nombre del titular de la tarjeta de crédito.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            If Convert.ToInt32(ComboTipoTarjetaCredito.SelectedValue) = 3 Then
                MessageBox.Show("Una tarjeta de crédito American Express debe tener 15 dígitos.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ValidaCaptura = False
            Else
                MessageBox.Show("Debe teclear el número de la tarjeta de crédito.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ValidaCaptura = False
            End If
        End If
    End Function

    Private Sub CargaDatosTarjetaCredito()
        'Para ocultar el número de tarjeta de crédito JAGD 11-01-07
        If Not _OcultarTarjetaCredito Then
            txtTarjetaCredito.Text = _TarjetaCredito
        Else
            txtTarjetaCredito.Text = _NumeroOcultoTarjetaCredito
        End If
        '
        txtTitular.Text = _Titular
        ComboBanco.SelectedValue = _Banco
        txtAnoVigencia.Text = _AnoVigencia.ToString
        txtMesVigencia.Text = _MesVigencia.ToString
        txtDomicilio.Text = _Domicilio
        ComboTipoTarjetaCredito.SelectedValue = _TipoTarjetaCredito
        txtIdentificacion.Text = _Identificacion
        lblFirma.Text = _Firma
        lblStatus.Text = _Status
        chkRecurrente.Checked = _Recurrente
    End Sub

    Private Sub ComboTipoTarjetaCredito_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTipoTarjetaCredito.SelectedIndexChanged

    End Sub

    Private Function DigitosTarjeta(ByVal TipoTarjeta As Integer) As Integer
        Dim digitos As Integer
        Dim cnn As New SqlConnection()
        cnn = DataLayer.Conexion
        Dim cmd As New SqlCommand("Select Digitos from tipotarjetacredito where tipotarjetacredito = " & TipoTarjeta, cnn)
        Try
            cnn.Open()
            Dim rdr As SqlDataReader
            rdr = cmd.ExecuteReader()
            rdr.Read()
            digitos = rdr.GetInt32(0)
            rdr.Close()
        Catch Ex As Exception
            MessageBox.Show("Excepción " + Ex.Message)
        Finally
            cnn.Close()
        End Try
        Return digitos
    End Function

    Private Sub frmCapTarjetaCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

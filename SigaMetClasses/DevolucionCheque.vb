Option Strict On
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class DevolucionCheque
    Inherits System.Windows.Forms.Form
#Region "Variables"
    Private _AñoCobro As Short
    Private _Cobro As Integer
    Private _NumeroCheque As String
    Private _Cliente As Integer
    Private _Banco As Short
    Private _Observaciones As String
    Private Titulo As String = "Devolución de cheque"
    Private _PedidoReferencia As String
    Private _PermiteDevolucionFechaAtras As Boolean

    Private _DevolucionMultipleSeleccionada As Boolean

    'Carga de parámetros con nombres duplicados 3/4/2008 JAGD
    Private _Corporativo As Short
    Private _Sucursal As Short
    Private _Modulo As Short
    Private _CadenaConexion As String

#End Region

    Public ReadOnly Property PedidoReferencia() As String
        Get
            Return _PedidoReferencia
        End Get
    End Property

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal AñoCobro As Short,
                   ByVal Cobro As Integer,
                   ByVal NumeroCheque As String,
                   ByVal Banco As Short,
                   ByVal BancoNombre As String,
                   ByVal Cliente As Integer,
                   ByVal ClienteNombre As String,
                   ByVal Observaciones As String,
          Optional ByVal PermiteDevolucionFechaAtras As Boolean = False,
          Optional ByVal DevolucionMultipleSeleccionada As Boolean = False)


        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        _AñoCobro = AñoCobro
        _Cobro = Cobro
        _NumeroCheque = NumeroCheque
        _Banco = Banco
        _Cliente = Cliente
        _Observaciones = Observaciones
        lblNumeroCheque.Text = _NumeroCheque
        lblBanco.Text = _Banco.ToString & " " & BancoNombre
        lblCliente.Text = _Cliente.ToString & " " & ClienteNombre
        txtObservaciones.Text = _Observaciones
        _PermiteDevolucionFechaAtras = PermiteDevolucionFechaAtras

        'Controlará la devolución de cheques más de una vez
        _DevolucionMultipleSeleccionada = DevolucionMultipleSeleccionada
    End Sub

    'Carga de parámetros con nombres duplicados 3/4/2008 JAGD
    Public Sub New(ByVal AñoCobro As Short,
               ByVal Cobro As Integer,
               ByVal NumeroCheque As String,
               ByVal Banco As Short,
               ByVal BancoNombre As String,
               ByVal Cliente As Integer,
               ByVal ClienteNombre As String,
               ByVal Observaciones As String,
               ByVal Corporativo As Short,
               ByVal Sucursal As Short,
      Optional ByVal PermiteDevolucionFechaAtras As Boolean = False,
      Optional ByVal DevolucionMultipleSeleccionada As Boolean = False,
      Optional ByVal Modulo As Short = 0, Optional ByVal CadenaConexion As String = "")


        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        _AñoCobro = AñoCobro
        _Cobro = Cobro
        _NumeroCheque = NumeroCheque
        _Banco = Banco
        _Cliente = Cliente
        _Observaciones = Observaciones
        lblNumeroCheque.Text = _NumeroCheque
        lblBanco.Text = _Banco.ToString & " " & BancoNombre
        lblCliente.Text = _Cliente.ToString & " " & ClienteNombre
        txtObservaciones.Text = _Observaciones
        _PermiteDevolucionFechaAtras = PermiteDevolucionFechaAtras

        'Controlará la devolución de cheques más de una vez
        _DevolucionMultipleSeleccionada = DevolucionMultipleSeleccionada

        'Carga de parámetros duplicados
        _Corporativo = Corporativo
        _Sucursal = Sucursal
        _Modulo = Modulo
        _CadenaConexion = CadenaConexion
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
    Friend WithEvents lblFDevolucion As System.Windows.Forms.Label
    Friend WithEvents dtpFDevolucion As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents lblRazonDevCheque As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblNumeroCheque As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblNumeroCheque2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblBanco As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents ComboRazonDevCheque As SigaMetClasses.Combos.ComboRazonDevCheque
    Friend WithEvents chkComisionCheqDev As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DevolucionCheque))
        Me.dtpFDevolucion = New System.Windows.Forms.DateTimePicker()
        Me.lblFDevolucion = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.lblRazonDevCheque = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblBanco = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblNumeroCheque2 = New System.Windows.Forms.Label()
        Me.lblNumeroCheque = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.chkComisionCheqDev = New System.Windows.Forms.CheckBox()
        Me.ComboRazonDevCheque = New SigaMetClasses.Combos.ComboRazonDevCheque()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpFDevolucion
        '
        Me.dtpFDevolucion.Enabled = False
        Me.dtpFDevolucion.Location = New System.Drawing.Point(184, 136)
        Me.dtpFDevolucion.Name = "dtpFDevolucion"
        Me.dtpFDevolucion.Size = New System.Drawing.Size(320, 21)
        Me.dtpFDevolucion.TabIndex = 1
        '
        'lblFDevolucion
        '
        Me.lblFDevolucion.AutoSize = True
        Me.lblFDevolucion.Location = New System.Drawing.Point(16, 139)
        Me.lblFDevolucion.Name = "lblFDevolucion"
        Me.lblFDevolucion.Size = New System.Drawing.Size(157, 13)
        Me.lblFDevolucion.TabIndex = 2
        Me.lblFDevolucion.Text = "Fecha de la devolución / cargo:"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(184, 200)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(320, 48)
        Me.txtObservaciones.TabIndex = 3
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Location = New System.Drawing.Point(16, 200)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(82, 13)
        Me.lblObservaciones.TabIndex = 4
        Me.lblObservaciones.Text = "Observaciones:"
        '
        'lblRazonDevCheque
        '
        Me.lblRazonDevCheque.AutoSize = True
        Me.lblRazonDevCheque.Location = New System.Drawing.Point(16, 171)
        Me.lblRazonDevCheque.Name = "lblRazonDevCheque"
        Me.lblRazonDevCheque.Size = New System.Drawing.Size(121, 13)
        Me.lblRazonDevCheque.TabIndex = 5
        Me.lblRazonDevCheque.Text = "Razón de la devolución:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblBanco)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblCliente)
        Me.GroupBox1.Controls.Add(Me.lblNumeroCheque2)
        Me.GroupBox1.Controls.Add(Me.lblNumeroCheque)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(512, 112)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del cheque"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Banco:"
        '
        'lblBanco
        '
        Me.lblBanco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBanco.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBanco.Location = New System.Drawing.Point(144, 48)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(352, 21)
        Me.lblBanco.TabIndex = 18
        Me.lblBanco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Cliente:"
        '
        'lblCliente
        '
        Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(144, 72)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(352, 21)
        Me.lblCliente.TabIndex = 14
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNumeroCheque2
        '
        Me.lblNumeroCheque2.AutoSize = True
        Me.lblNumeroCheque2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroCheque2.Location = New System.Drawing.Point(16, 27)
        Me.lblNumeroCheque2.Name = "lblNumeroCheque2"
        Me.lblNumeroCheque2.Size = New System.Drawing.Size(68, 13)
        Me.lblNumeroCheque2.TabIndex = 13
        Me.lblNumeroCheque2.Text = "No. Cheque:"
        '
        'lblNumeroCheque
        '
        Me.lblNumeroCheque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumeroCheque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroCheque.Location = New System.Drawing.Point(144, 24)
        Me.lblNumeroCheque.Name = "lblNumeroCheque"
        Me.lblNumeroCheque.Size = New System.Drawing.Size(104, 21)
        Me.lblNumeroCheque.TabIndex = 12
        Me.lblNumeroCheque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(536, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 7
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(536, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'chkComisionCheqDev
        '
        Me.chkComisionCheqDev.Checked = True
        Me.chkComisionCheqDev.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkComisionCheqDev.Location = New System.Drawing.Point(540, 134)
        Me.chkComisionCheqDev.Name = "chkComisionCheqDev"
        Me.chkComisionCheqDev.Size = New System.Drawing.Size(68, 24)
        Me.chkComisionCheqDev.TabIndex = 10
        Me.chkComisionCheqDev.Text = "Comisión"
        Me.chkComisionCheqDev.Visible = False
        '
        'ComboRazonDevCheque
        '
        Me.ComboRazonDevCheque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboRazonDevCheque.Location = New System.Drawing.Point(184, 168)
        Me.ComboRazonDevCheque.Name = "ComboRazonDevCheque"
        Me.ComboRazonDevCheque.Size = New System.Drawing.Size(320, 21)
        Me.ComboRazonDevCheque.TabIndex = 9
        '
        'DevolucionCheque
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(618, 287)
        Me.Controls.Add(Me.chkComisionCheqDev)
        Me.Controls.Add(Me.ComboRazonDevCheque)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblRazonDevCheque)
        Me.Controls.Add(Me.lblObservaciones)
        Me.Controls.Add(Me.lblFDevolucion)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.dtpFDevolucion)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DevolucionCheque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Devolución de cheques"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub frmDevCheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboRazonDevCheque.CargaDatos(True)
        Dim strFechaMinima As String
        Dim dtmFechaMinima As Date
        If _PermiteDevolucionFechaAtras Then
            strFechaMinima = "01/" & (Now.Date.AddMonths(-1)).Month & "/" & (Now.Date.AddMonths(-1)).Year
            dtmFechaMinima = CType(strFechaMinima, Date)
        Else
            strFechaMinima = "01/" & Now.Date.Month & "/" & Now.Date.Year
            dtmFechaMinima = CType(strFechaMinima, Date)
        End If

        dtpFDevolucion.MinDate = dtmFechaMinima
        dtpFDevolucion.MaxDate = Now.Date

        chkComisionCheqDev.Visible = HabilitaComision()

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If ValidaCaptura() = True Then
            If MessageBox.Show("¿Están correctos los datos?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim oCobro As New SigaMetClasses.Cobro()
                'Dim oConfig As New cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
                Dim oConfig As New cConfig(_Modulo, _Corporativo, _Sucursal)
                Dim referenciaCRm As String
                Dim dt As DataTable

                Dim total As Decimal
                Try

					Dim url As String
					Dim fuenteCRM As String

					Try
						url = CType(oConfig.Parametros("URLGateway"), String).Trim()
					Catch ex As Exception
						url = ""
					End Try

					Try
						fuenteCRM = CType(oConfig.Parametros("FuenteCRM"), String).Trim()
					Catch ex As Exception
						fuenteCRM = ""
					End Try


					AbreConexion()




                    IniciaTransaccion()

                    _PedidoReferencia = oCobro.ChequeDevolucion(_AñoCobro, _Cobro, CType(ComboRazonDevCheque.SelectedValue, String), Trim(txtObservaciones.Text), dtpFDevolucion.Value.Date, chkComisionCheqDev.Checked,
                        _DevolucionMultipleSeleccionada, total)

                    dt = oCobro.DatosPedidoCheque(_AñoCobro, _Cobro)

					If (Not url.Equals("")) And (fuenteCRM.Equals("CRM")) Then

						'Dim pedido As New RTGMCore.PedidoCRMSaldo
						'pedido.Abono = total

						Dim pedido As New RTGMCore.PedidoCRMDatos
						Dim DetallePedido As New RTGMCore.DetallePedido
						Dim ListaDetallePedidos As New List(Of RTGMCore.DetallePedido)
						Dim listaPedidos As New List(Of RTGMCore.Pedido)

						pedido.IDTipoPedido = 3
						'pedido.IDTipoServicio = pendiente
						pedido.RutaSuministro = New RTGMCore.RutaCRMDatos With {.IDRuta = CInt(dt.Rows(0).Item("RUTA"))}



						'detalle pedido
						DetallePedido.Producto = New RTGMCore.Producto With {.IDProducto = CInt(dt.Rows(0).Item("producto"))}
						DetallePedido.DescuentoAplicado = CInt(dt.Rows(0).Item("Descuento"))
						DetallePedido.Importe = CDec(dt.Rows(0).Item("importe"))
						DetallePedido.Impuesto = CDec(dt.Rows(0).Item("Impuesto"))

						ListaDetallePedidos.Add(DetallePedido)
						pedido.DetallePedido = ListaDetallePedidos
						listaPedidos.Add(pedido)


						Dim ListaRespuesta As List(Of RTGMCore.Pedido)
						Dim objGateway As New RTGMGateway.RTGMActualizarPedido(CByte(_Modulo), _CadenaConexion)
						objGateway.URLServicio = url

						Dim SolicitudActualizarPedido As New RTGMGateway.SolicitudActualizarPedido()

						SolicitudActualizarPedido.Pedidos = listaPedidos

						SolicitudActualizarPedido.Portatil = False

						'SolicitudActualizarPedido.TipoActualizacion = RTGMCore.TipoActualizacion.Saldo

						SolicitudActualizarPedido.TipoActualizacion = RTGMCore.TipoActualizacion.Liquidacion

						SolicitudActualizarPedido.Usuario = GLOBAL_Usuario


						ListaRespuesta = objGateway.ActualizarPedido(SolicitudActualizarPedido)

						referenciaCRm = ListaRespuesta(0).PedidoReferencia

						If referenciaCRm = Nothing Then
							referenciaCRm = ""
						End If



						oCobro.actualizarPedido(_PedidoReferencia, referenciaCRm)

					End If

					Transaccion.Commit()


                    DialogResult = DialogResult.OK
                    Me.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Transaccion.Rollback()
                Finally
                    Cursor = Cursors.Default
                    oCobro = Nothing
                End Try
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Function ValidaCaptura() As Boolean
        If CType(ComboRazonDevCheque.SelectedValue, String) <> "" And ComboRazonDevCheque.SelectedIndex >= 0 Then
            ValidaCaptura = True
        Else
            ValidaCaptura = False
            MessageBox.Show("Debe seleccionar la razón de la devolución.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Function

    Private Function HabilitaComision() As Boolean
        Dim retValue As Boolean
        'Carga de parámetros con nombres duplicados 3/4/2008 JAGD
        Dim oLogin As New SigaMetClasses.cConfig(4, _Corporativo, _Sucursal)
        retValue = CType(oLogin.Parametros("ComisionCheqDevAplica"), Boolean)
        Return retValue
    End Function

End Class

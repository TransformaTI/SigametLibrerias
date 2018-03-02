Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports PortatilClasses
Imports ReporteDinamicoOaxaca
Imports SigaMetClasses
Imports SigaMetClasses.Controles
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace LiquidacionPortatil
    Public Class frmAbonosExtraordinariosHidro
        Inherits Form
        ' Methods
        Public Sub New()
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmAbonosExtraordinarios_Load)
            Me.InitializeComponent()
        End Sub

        Public Sub New(ByVal Tipo As Short)
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmAbonosExtraordinarios_Load)
            Me.InitializeComponent()
            Me._Tipo = Tipo
            If (Me._Tipo = 0) Then
                Me.dgDatos.ReadOnly = True
                Me.txtAbono.Enabled = False
                Me.lblTotal.Visible = False
                Me.btnAceptar.Enabled = True
                Me.ActiveControl = Me.btnAceptar
            End If
            Me.txtCliente.Text = StringType.FromInteger(Me._Cliente)
            Me.txtCliente.Enabled = False
            Me.btnBuscar.Enabled = False
            Me.dtpFMovimiento.Value = Now
            Me.dtpFMovimiento.Enabled = False
            Me.txtComentario.Text = ""
            Me.txtComentario.Enabled = False
            Me.btnCancelar.Visible = False
            Me.Text = "Abono del Comisionista"
        End Sub

        Public Sub New(ByVal Tipo As Short, ByVal MovimientoAlmacen As Integer, ByVal Almacengas As Integer)
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmAbonosExtraordinarios_Load)
            Me.InitializeComponent()
            Me._Tipo = Tipo
            Me._MovimientoAlmacen = MovimientoAlmacen
            Me._Almacengas = Almacengas
            Me.txtCliente.Text = StringType.FromInteger(Me._Cliente)
            Me.txtCliente.Enabled = False
            Me.btnBuscar.Enabled = False
            Me.dtpFMovimiento.Value = Now
            Me.dtpFMovimiento.Enabled = False
            Me.txtComentario.Text = ""
            Me.txtComentario.Enabled = False
            Me.btnAceptar.Enabled = True
            Me.ActiveControl = Me.btnAceptar
            Me.btnCancelar.Visible = False
            Me.txtAbono.Enabled = False
            Me.lblTotal.Visible = False
            Me.Text = "Abono del Comisionista"
            Me.dgDatos.ReadOnly = True
        End Sub

        Public Sub New(ByVal Usuario As String, ByVal CajaUsuario As Byte, ByVal Servidor As String, ByVal DBase As String, ByVal Password As String, ByVal CorporativoUsuario As Short, ByVal SucursalUsuario As Short)
            AddHandler MyBase.Load, New EventHandler(AddressOf Me.frmAbonosExtraordinarios_Load)
            Me.InitializeComponent()
            Me._Usuario = Usuario
            Me._CajaUsuario = CajaUsuario
            Me._Servidor = Servidor
            Me._Database = DBase
            Me._Password = Password
            Me._CorporativoUsuario = CorporativoUsuario
            Me._SucursalUsuario = SucursalUsuario
            Dim config As New cConfig(3, Me._CorporativoUsuario, Me._SucursalUsuario)
            Dim oParametroCaja As New SigaMetClasses.cConfig(3, _CorporativoUsuario, _SucursalUsuario)
            _RutaReportes = CType(oParametroCaja.Parametros("RutaReportesW7"), String).Trim
            Me._Tipo = 2
        End Sub

        Public Function AbonoTotal() As Decimal
            Dim zero As Decimal = Decimal.Zero
            Dim num4 As Integer = (Me._Registros - 1)
            Dim i As Integer = 0
            Do While (i <= num4)
                zero = Decimal.Add(zero, DecimalType.FromObject(Me.dgDatos.Item(i, 3)))
                i += 1
            Loop
            Return zero
        End Function

        Public Function AbonoTotalConsulta() As Decimal
            Dim zero As Decimal = Decimal.Zero
            Dim num4 As Integer = (Me._Registros - 1)
            Dim i As Integer = 0
            Do While (i <= num4)
                zero = Decimal.Add(zero, DecimalType.FromObject(Me.dgDatos.Item(i, 3)))
                i += 1
            Loop
            Return zero
        End Function

        Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me._Tipo = 2) Then
                Dim Mensajes As New PortatilClasses.Mensaje(4)
                If (MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                    Me.RegistrarAbonos()
                    Me.Close()
                End If
            End If
            If (Me._Tipo <> 2) Then
                Me.Close()
            End If
        End Sub

        Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs)
            If (Me._Tipo = 2) Then
                Dim oBusquedaCliente As New SigaMetClasses.BusquedaCliente()
                If oBusquedaCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    If oBusquedaCliente.Cliente <> 0 Then
                        txtCliente.Text = CType(oBusquedaCliente.Cliente, String)
                        Me.BuscarCliente()
                        Me.ActiveControl = Me.dtpFMovimiento
                    Else
                        Me.ActiveControl = Me.txtCliente
                    End If
                End If
            End If
        End Sub

        Private Sub BuscarCliente()
            Dim oCliente As New PortatilClasses.Consulta.cCliente(0, CType(txtCliente.Text, Integer))
            oCliente.CargaDatos()

            Cursor = Cursors.WaitCursor

            If oCliente.Cliente <> "" Then
                lblCliente.Text = oCliente.Cliente
                lblRuta.Text = oCliente.Ruta
                lblRuta.Tag = oCliente.IdRuta
                lblEmpresa.Text = oCliente.Corporativo
                lblEmpresa.Tag = oCliente.IdCorporativo
                _Cliente = CType(txtCliente.Text, Integer)
                CargarDatos(CType(txtCliente.Text, Integer))
            Else
                _Cliente = 0
                LimpiarCliente()
                Dim Mensajes As New PortatilClasses.Mensaje(3)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                MyBase.ActiveControl = txtCliente
                txtCliente.Clear()
            End If
            oCliente = Nothing
            Cursor = Cursors.Default
        End Sub

        Private Sub CargarComoDatos(ByVal Folio As Integer, ByVal Año As Integer)
            Me.dgComodatos.DataSource = Nothing
            Dim comisionista As New PortatilClasses.Consulta.cCobroComisionista()
            comisionista.Consulta(10, Folio, Año)
            Me.dgComodatos.DataSource = comisionista.dtTable
            comisionista = Nothing
        End Sub

        Public Sub CargarDatos(ByVal Cliente As Integer)
            Me.dgDatos.DataSource = Nothing
            Dim comisionista As New PortatilClasses.Consulta.cCobroComisionista()
            comisionista.Consulta(Cliente, 4)
            Me.dgDatos.DataSource = comisionista.dtTable
            Me._Registros = comisionista.dtTable.Rows.Count
            comisionista = Nothing
            Me._Saldo = Me.SaldoTotal
            DirectCast(Me.dgDatos.DataSource, DataTable).DefaultView.AllowNew = False
            If (Me.dgDatos.VisibleRowCount > 0) Then
                Me.CargarDetalle(IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 0)), IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 1)))
                Me.CargarIntereses(IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 0)), IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 1)))
                Me.CargarComoDatos(IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 0)), IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 1)))
            End If
        End Sub

        Public Sub CargarDatos(ByVal Tipo As Integer, ByVal Cliente As Integer)
            Me._Cliente = Cliente
            Me.txtCliente.Text = StringType.FromInteger(Me._Cliente)
            Dim oCliente As New PortatilClasses.Consulta.cCliente(0, IntegerType.FromString(Me.txtCliente.Text))
            oCliente.CargaDatos()
            If (StringType.StrCmp(oCliente.Cliente, "", False) <> 0) Then
                Me.lblCliente.Text = oCliente.Cliente
                Me.lblRuta.Text = oCliente.Ruta
                Me.lblRuta.Tag = oCliente.IdRuta
                Me.lblEmpresa.Text = oCliente.Corporativo
                Me.lblEmpresa.Tag = oCliente.IdCorporativo
                Me.dgDatos.DataSource = Nothing
                Dim comisionista As New PortatilClasses.Consulta.cCobroComisionista()
                comisionista.Consulta(11, Me._Cliente, Me._MovimientoAlmacen, Me._Almacengas)
                Me.dgDatos.DataSource = comisionista.dtTable
                Me._Registros = comisionista.dtTable.Rows.Count
                comisionista = Nothing
                DirectCast(Me.dgDatos.DataSource, DataTable).DefaultView.AllowNew = False
                If (Me.dgDatos.VisibleRowCount > 0) Then
                    Me.CargarDetalle(IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 0)), IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 1)))
                    Me.CargarIntereses(IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 0)), IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 1)))
                    Me.CargarComoDatos(IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 0)), IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 1)))
                End If
            End If
        End Sub

        Public Sub CargarDatos(ByVal Tipo As Short, ByVal Cliente As Integer, ByVal FolioNota As Integer)
            Me._Cliente = Cliente
            Me.txtCliente.Text = StringType.FromInteger(Me._Cliente)
            Dim oCliente As New PortatilClasses.Consulta.cCliente(0, CType(txtCliente.Text, Integer))
            oCliente.CargaDatos()
            If (StringType.StrCmp(oCliente.Cliente, "", False) <> 0) Then
                Me.lblCliente.Text = oCliente.Cliente
                Me.lblRuta.Text = oCliente.Ruta
                Me.lblRuta.Tag = oCliente.IdRuta
                Me.lblEmpresa.Text = oCliente.Corporativo
                Me.lblEmpresa.Tag = oCliente.IdCorporativo
                Me.dgDatos.DataSource = Nothing
                Dim comisionista As New PortatilClasses.Consulta.cCobroComisionista
                comisionista.Consulta(Cliente, FolioNota, 12)
                Me.dgDatos.DataSource = comisionista.dtTable
                Me._Registros = comisionista.dtTable.Rows.Count
                comisionista = Nothing
                DirectCast(Me.dgDatos.DataSource, DataTable).DefaultView.AllowNew = False
                If (Me.dgDatos.VisibleRowCount > 0) Then
                    Me.CargarDetalle(IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 0)), IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 1)))
                    Me.CargarIntereses(IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 0)), IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 1)))
                    Me.CargarComoDatos(IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 0)), IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 1)))
                End If
            End If
        End Sub

        Public Sub CargarDatos(ByVal Cliente As Integer, ByVal Registros As Integer, ByVal NombreCliente As String)
            Me._Cliente = Cliente
            Me.txtCliente.Text = StringType.FromInteger(Me._Cliente)
            Me.BuscarCliente()
        End Sub

        Private Sub CargarDetalle(ByVal Folio As Integer, ByVal Año As Integer)
            Me.dgDetalle.DataSource = Nothing
            Dim comisionista As New PortatilClasses.Consulta.cCobroComisionista
            comisionista.Consulta(8, Folio, Año)
            Me.dgDetalle.DataSource = comisionista.dtTable
            comisionista = Nothing
        End Sub

        Private Sub CargarIntereses(ByVal Folio As Integer, ByVal Año As Integer)
            Me.dgIntereses.DataSource = Nothing
            Dim comisionista As New PortatilClasses.Consulta.cCobroComisionista
            comisionista.Consulta(9, Folio, Año)
            Me.dgIntereses.DataSource = comisionista.dtTable
            comisionista = Nothing
        End Sub

        Private Sub cboAlmacenOrigen_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
            If (e.KeyData = Keys.Enter) Then
                Me.SelectNextControl(DirectCast(sender, Control), True, True, True, True)
            End If
        End Sub

        Private Sub dgdatos_CurrentCellChanged(ByVal sender As Object, ByVal e As EventArgs)
            If (Me.dgDatos.VisibleRowCount > 0) Then
                Me.CargarDetalle(IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 0)), IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 1)))
                Me.CargarIntereses(IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 0)), IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 1)))
                Me.CargarComoDatos(IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 0)), IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 1)))
            End If
        End Sub

        Private Sub dgDatos_Leave(ByVal sender As Object, ByVal e As EventArgs)
            Me.HabilitarAceptar()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing AndAlso (Not Me.components Is Nothing)) Then
                Me.components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function FechaActual() As DateTime
            Dim time As DateTime
            Dim fechas As New PortatilClasses.Catalogo.ConsultaFechas(1, 0)
            If fechas.drReader.Read Then
                time = DateType.FromObject(fechas.drReader.Item(0))
            End If
            fechas.CerrarConexion()
            fechas = Nothing
            Return time
        End Function

        Private Sub frmAbonosExtraordinarios_Load(ByVal sender As Object, ByVal e As EventArgs)
            If (Me._Tipo = 0) Then
                Me.txtAbono.Text = StringType.FromDecimal(Me.AbonoTotalConsulta)
            End If
            If (Me._Tipo = 2) Then
                Me.txtComentario.Text = "Ingreso extraordinario"
                Me.ActiveControl = Me.txtCliente
                Me.Limpiar()
            ElseIf (Me.dgDatos.VisibleRowCount > 0) Then
                Me.CargarDetalle(IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 0)), IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 1)))
                Me.CargarIntereses(IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 0)), IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 1)))
                Me.CargarComoDatos(IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 0)), IntegerType.FromObject(Me.dgDatos.Item(Me.dgDatos.CurrentRowIndex, 1)))
            End If
        End Sub

        Private Sub HabilitarAceptar()
            If (Me._Tipo = 0) Then
                Me.btnAceptar.Enabled = True
            ElseIf ((StringType.StrCmp(Me.txtCliente.Text, "", False) <> 0) And (StringType.StrCmp(Me.txtAbono.Text, "", False) <> 0)) Then
                If (Decimal.Compare(DecimalType.FromString(Me.txtAbono.Text), Me.AbonoTotal) = 0) Then
                    Me.btnAceptar.Enabled = True
                Else
                    Me.btnAceptar.Enabled = False
                End If
            Else
                Me.btnAceptar.Enabled = False
            End If
        End Sub

        <DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim manager As New ResourceManager(GetType(frmAbonosExtraordinarios))
            Me.btnBuscar = New Button
            Me.txtCliente = New txtNumeroEntero
            Me.lblRuta = New Label
            Me.Label12 = New Label
            Me.Label6 = New Label
            Me.Label5 = New Label
            Me.lblEmpresa = New Label
            Me.Label1 = New Label
            Me.dtpFMovimiento = New DateTimePicker
            Me.lblCliente = New Label
            Me.Label3 = New Label
            Me.dgDatos = New DataGrid
            Me.DataGridTableStyle1 = New DataGridTableStyle
            Me.DataGridTextBoxColumn1 = New DataGridTextBoxColumn
            Me.DataGridTextBoxColumn2 = New DataGridTextBoxColumn
            Me.DataGridTextBoxColumn5 = New DataGridTextBoxColumn
            Me.DataGridTextBoxColumn3 = New DataGridTextBoxColumn
            Me.DataGridTextBoxColumn4 = New DataGridTextBoxColumn
            Me.grpDatos = New GroupBox
            Me.lblTotal = New Label
            Me.Label2 = New Label
            Me.txtComentario = New TextBox
            Me.txtAbono = New txtNumeroDecimal
            Me.Label15 = New Label
            Me.btnCancelar = New Button
            Me.btnAceptar = New Button
            Me.TabControl1 = New TabControl
            Me.TabPage1 = New TabPage
            Me.dgDetalle = New DataGrid
            Me.TabPage2 = New TabPage
            Me.dgIntereses = New DataGrid
            Me.TabPage3 = New TabPage
            Me.dgComodatos = New DataGrid
            Me.dgDatos.BeginInit()
            Me.grpDatos.SuspendLayout()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.dgDetalle.BeginInit()
            Me.TabPage2.SuspendLayout()
            Me.dgIntereses.BeginInit()
            Me.TabPage3.SuspendLayout()
            Me.dgComodatos.BeginInit()
            Me.SuspendLayout()
            Me.btnBuscar.Anchor = (AnchorStyles.Right Or AnchorStyles.Top)
            Me.btnBuscar.BackColor = SystemColors.Control
            Me.btnBuscar.Image = DirectCast(manager.GetObject("btnBuscar.Image"), Bitmap)
            Me.btnBuscar.ImageAlign = ContentAlignment.MiddleLeft
            Dim point As New Point(&H196, &H18)
            Me.btnBuscar.Location = point
            Me.btnBuscar.Name = "btnBuscar"
            Me.btnBuscar.TabIndex = &H3E
            Me.btnBuscar.TabStop = False
            Me.btnBuscar.Text = "&Buscar"
            Me.btnBuscar.TextAlign = ContentAlignment.MiddleRight
            point = New Point(&H80, &H18)
            Me.txtCliente.Location = point
            Me.txtCliente.Name = "txtCliente"
            Dim size As New Size(&HD8, 20)
            Me.txtCliente.Size = size
            Me.txtCliente.TabIndex = 1
            Me.txtCliente.Text = ""
            Me.lblRuta.BorderStyle = BorderStyle.Fixed3D
            point = New Point(&H80, 80)
            Me.lblRuta.Location = point
            Me.lblRuta.Name = "lblRuta"
            size = New Size(&H160, &H15)
            Me.lblRuta.Size = size
            Me.lblRuta.TabIndex = &H1C
            Me.lblRuta.TextAlign = ContentAlignment.MiddleLeft
            Me.Label12.AutoSize = True
            Me.Label12.Font = New Font("Tahoma", 8.0!, FontStyle.Bold)
            point = New Point(&H10, &H1C)
            Me.Label12.Location = point
            Me.Label12.Name = "Label12"
            size = New Size(&H6D, 13)
            Me.Label12.Size = size
            Me.Label12.TabIndex = &H18
            Me.Label12.Text = "Número de cliente:"
            Me.Label12.TextAlign = ContentAlignment.MiddleLeft
            Me.Label6.AutoSize = True
            Me.Label6.Font = New Font("Tahoma", 8.0!, FontStyle.Bold)
            point = New Point(&H10, &H8E)
            Me.Label6.Location = point
            Me.Label6.Name = "Label6"
            size = New Size(&H6D, 13)
            Me.Label6.Size = size
            Me.Label6.TabIndex = 12
            Me.Label6.Text = "Fecha movimiento:"
            Me.Label6.TextAlign = ContentAlignment.MiddleLeft
            Me.Label5.AutoSize = True
            point = New Point(&H10, &H70)
            Me.Label5.Location = point
            Me.Label5.Name = "Label5"
            size = New Size(&H35, 13)
            Me.Label5.Size = size
            Me.Label5.TabIndex = 8
            Me.Label5.Text = "Empresa:"
            Me.Label5.TextAlign = ContentAlignment.MiddleLeft
            Me.lblEmpresa.BorderStyle = BorderStyle.Fixed3D
            point = New Point(&H80, &H6C)
            Me.lblEmpresa.Location = point
            Me.lblEmpresa.Name = "lblEmpresa"
            size = New Size(&H160, &H15)
            Me.lblEmpresa.Size = size
            Me.lblEmpresa.TabIndex = 4
            Me.lblEmpresa.TextAlign = ContentAlignment.MiddleLeft
            Me.Label1.AutoSize = True
            point = New Point(&H10, &H54)
            Me.Label1.Location = point
            Me.Label1.Name = "Label1"
            size = New Size(&H1F, 13)
            Me.Label1.Size = size
            Me.Label1.TabIndex = 3
            Me.Label1.Text = "Ruta:"
            Me.Label1.TextAlign = ContentAlignment.MiddleLeft
            Me.dtpFMovimiento.CalendarFont = New Font("Tahoma", 8.0!)
            Me.dtpFMovimiento.CustomFormat = "dd/MM/yyyy HH:mm tt"
            Me.dtpFMovimiento.Format = DateTimePickerFormat.Custom
            point = New Point(&H80, &H8A)
            Me.dtpFMovimiento.Location = point
            Me.dtpFMovimiento.Name = "dtpFMovimiento"
            size = New Size(&HD8, 20)
            Me.dtpFMovimiento.Size = size
            Me.dtpFMovimiento.TabIndex = 3
            Dim time As New DateTime(&H7DC, 2, 11, 13, 15, 15, &H2AF)
            Me.dtpFMovimiento.Value = time
            Me.lblCliente.BorderStyle = BorderStyle.Fixed3D
            point = New Point(&H80, &H34)
            Me.lblCliente.Location = point
            Me.lblCliente.Name = "lblCliente"
            size = New Size(&H160, &H15)
            Me.lblCliente.Size = size
            Me.lblCliente.TabIndex = &H20
            Me.lblCliente.TextAlign = ContentAlignment.MiddleLeft
            Me.Label3.AutoSize = True
            point = New Point(&H10, &H38)
            Me.Label3.Location = point
            Me.Label3.Name = "Label3"
            size = New Size(&H2B, 13)
            Me.Label3.Size = size
            Me.Label3.TabIndex = &H1F
            Me.Label3.Text = "Cliente:"
            Me.Label3.TextAlign = ContentAlignment.MiddleLeft
            Me.dgDatos.CaptionText = "Préstamos"
            Me.dgDatos.DataMember = ""
            Me.dgDatos.HeaderForeColor = SystemColors.ControlText
            point = New Point(8, &HA9)
            Me.dgDatos.Location = point
            Me.dgDatos.Name = "dgDatos"
            size = New Size(&H1D8, 120)
            Me.dgDatos.Size = size
            Me.dgDatos.TabIndex = &H26
            Me.dgDatos.TableStyles.AddRange(New DataGridTableStyle() {Me.DataGridTableStyle1})
            Me.DataGridTableStyle1.DataGrid = Me.dgDatos
            Me.DataGridTableStyle1.GridColumnStyles.AddRange(New DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4})
            Me.DataGridTableStyle1.HeaderForeColor = SystemColors.ControlText
            Me.DataGridTableStyle1.MappingName = ""
            Me.DataGridTextBoxColumn1.Format = ""
            Me.DataGridTextBoxColumn1.FormatInfo = Nothing
            Me.DataGridTextBoxColumn1.HeaderText = "Folio"
            Me.DataGridTextBoxColumn1.MappingName = "Folio"
            Me.DataGridTextBoxColumn1.ReadOnly = True
            Me.DataGridTextBoxColumn1.Width = &H4B
            Me.DataGridTextBoxColumn2.Format = ""
            Me.DataGridTextBoxColumn2.FormatInfo = Nothing
            Me.DataGridTextBoxColumn2.HeaderText = "Año"
            Me.DataGridTextBoxColumn2.MappingName = "AñoPrestamo"
            Me.DataGridTextBoxColumn2.ReadOnly = True
            Me.DataGridTextBoxColumn2.Width = &H4B
            Me.DataGridTextBoxColumn5.Format = ""
            Me.DataGridTextBoxColumn5.FormatInfo = Nothing
            Me.DataGridTextBoxColumn5.HeaderText = "Saldo"
            Me.DataGridTextBoxColumn5.MappingName = "Saldo"
            Me.DataGridTextBoxColumn5.ReadOnly = True
            Me.DataGridTextBoxColumn5.Width = &H4B
            Me.DataGridTextBoxColumn3.Format = ""
            Me.DataGridTextBoxColumn3.FormatInfo = Nothing
            Me.DataGridTextBoxColumn3.HeaderText = "Abono"
            Me.DataGridTextBoxColumn3.MappingName = "Pagos"
            Me.DataGridTextBoxColumn3.Width = &H4B
            Me.DataGridTextBoxColumn4.Format = ""
            Me.DataGridTextBoxColumn4.FormatInfo = Nothing
            Me.DataGridTextBoxColumn4.HeaderText = "UsuarioAlta"
            Me.DataGridTextBoxColumn4.MappingName = "UsuarioAlta"
            Me.DataGridTextBoxColumn4.ReadOnly = True
            Me.DataGridTextBoxColumn4.Width = &H4B
            Me.grpDatos.Controls.AddRange(New Control() {Me.lblTotal, Me.Label2, Me.txtComentario, Me.txtAbono, Me.Label15, Me.btnBuscar, Me.txtCliente, Me.lblRuta, Me.Label12, Me.Label6, Me.Label5, Me.lblEmpresa, Me.Label1, Me.dtpFMovimiento, Me.lblCliente, Me.Label3, Me.dgDatos})
            point = New Point(&H10, &H10)
            Me.grpDatos.Location = point
            Me.grpDatos.Name = "grpDatos"
            size = New Size(&H1E8, 360)
            Me.grpDatos.Size = size
            Me.grpDatos.TabIndex = 8
            Me.grpDatos.TabStop = False
            Me.lblTotal.Font = New Font("Tahoma", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            point = New Point(&H126, &H12F)
            Me.lblTotal.Location = point
            Me.lblTotal.Name = "lblTotal"
            Me.lblTotal.TabIndex = &H43
            Me.lblTotal.Text = "Label4"
            Me.Label2.AutoSize = True
            point = New Point(9, &H14D)
            Me.Label2.Location = point
            Me.Label2.Name = "Label2"
            size = New Size(&H42, 13)
            Me.Label2.Size = size
            Me.Label2.TabIndex = &H42
            Me.Label2.Text = "Comentario:"
            Me.Label2.TextAlign = ContentAlignment.MiddleLeft
            Me.txtComentario.CharacterCasing = CharacterCasing.Upper
            point = New Point(&H80, &H148)
            Me.txtComentario.Location = point
            Me.txtComentario.Name = "txtComentario"
            size = New Size(&H158, 20)
            Me.txtComentario.Size = size
            Me.txtComentario.TabIndex = &H41
            Me.txtComentario.Text = ""
            point = New Point(&H80, &H12B)
            Me.txtAbono.Location = point
            Me.txtAbono.Name = "txtAbono"
            size = New Size(&H90, 20)
            Me.txtAbono.Size = size
            Me.txtAbono.TabIndex = &H40
            Me.txtAbono.TabStop = False
            Me.txtAbono.Text = ""
            Me.Label15.AutoSize = True
            Me.Label15.Font = New Font("Tahoma", 8.0!, FontStyle.Bold)
            point = New Point(9, &H12F)
            Me.Label15.Location = point
            Me.Label15.Name = "Label15"
            size = New Size(&H6D, 13)
            Me.Label15.Size = size
            Me.Label15.TabIndex = &H3F
            Me.Label15.Text = "Abono préstamo $:"
            Me.Label15.TextAlign = ContentAlignment.MiddleLeft
            Me.btnCancelar.DialogResult = DialogResult.Cancel
            Me.btnCancelar.Image = DirectCast(manager.GetObject("btnCancelar.Image"), Bitmap)
            Me.btnCancelar.ImageAlign = ContentAlignment.MiddleLeft
            point = New Point(520, &H38)
            Me.btnCancelar.Location = point
            Me.btnCancelar.Name = "btnCancelar"
            Me.btnCancelar.TabIndex = 10
            Me.btnCancelar.Text = "&Cancelar"
            Me.btnCancelar.TextAlign = ContentAlignment.MiddleRight
            Me.btnAceptar.Image = DirectCast(manager.GetObject("btnAceptar.Image"), Bitmap)
            Me.btnAceptar.ImageAlign = ContentAlignment.MiddleLeft
            point = New Point(520, &H18)
            Me.btnAceptar.Location = point
            Me.btnAceptar.Name = "btnAceptar"
            Me.btnAceptar.TabIndex = 9
            Me.btnAceptar.Text = "&Aceptar"
            Me.btnAceptar.TextAlign = ContentAlignment.MiddleRight
            Me.TabControl1.Controls.AddRange(New Control() {Me.TabPage1, Me.TabPage2, Me.TabPage3})
            point = New Point(&H10, &H180)
            Me.TabControl1.Location = point
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            size = New Size(&H240, &H80)
            Me.TabControl1.Size = size
            Me.TabControl1.TabIndex = 11
            Me.TabPage1.Controls.AddRange(New Control() {Me.dgDetalle})
            point = New Point(4, &H16)
            Me.TabPage1.Location = point
            Me.TabPage1.Name = "TabPage1"
            size = New Size(&H238, &H66)
            Me.TabPage1.Size = size
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Préstamo"
            Me.dgDetalle.CaptionText = "Detalle Préstamo"
            Me.dgDetalle.DataMember = ""
            Me.dgDetalle.HeaderForeColor = SystemColors.ControlText
            Me.dgDetalle.Name = "dgDetalle"
            Me.dgDetalle.ReadOnly = True
            size = New Size(&H240, &H68)
            Me.dgDetalle.Size = size
            Me.dgDetalle.TabIndex = 0
            Me.TabPage2.Controls.AddRange(New Control() {Me.dgIntereses})
            point = New Point(4, &H16)
            Me.TabPage2.Location = point
            Me.TabPage2.Name = "TabPage2"
            size = New Size(&H238, &H66)
            Me.TabPage2.Size = size
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Intereses"
            Me.dgIntereses.CaptionText = "Préstamo con Intereses"
            Me.dgIntereses.DataMember = ""
            Me.dgIntereses.HeaderForeColor = SystemColors.ControlText
            Me.dgIntereses.Name = "dgIntereses"
            Me.dgIntereses.ReadOnly = True
            size = New Size(&H240, &H68)
            Me.dgIntereses.Size = size
            Me.dgIntereses.TabIndex = 1
            Me.TabPage3.Controls.AddRange(New Control() {Me.dgComodatos})
            point = New Point(4, &H16)
            Me.TabPage3.Location = point
            Me.TabPage3.Name = "TabPage3"
            size = New Size(&H238, &H66)
            Me.TabPage3.Size = size
            Me.TabPage3.TabIndex = 2
            Me.TabPage3.Text = "Comodatos"
            Me.dgComodatos.CaptionText = "Préstamo de Comodatos"
            Me.dgComodatos.DataMember = ""
            Me.dgComodatos.HeaderForeColor = SystemColors.ControlText
            Me.dgComodatos.Name = "dgComodatos"
            Me.dgComodatos.ReadOnly = True
            size = New Size(&H240, &H68)
            Me.dgComodatos.Size = size
            Me.dgComodatos.TabIndex = 1
            size = New Size(5, 13)
            Me.AutoScaleBaseSize = size
            size = New Size(610, 520)
            Me.ClientSize = size
            Me.Controls.AddRange(New Control() {Me.TabControl1, Me.btnCancelar, Me.btnAceptar, Me.grpDatos})
            Me.FormBorderStyle = FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmAbonosExtraordinarios"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "Abono extraordinario"
            Me.dgDatos.EndInit()
            Me.grpDatos.ResumeLayout(False)
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.dgDetalle.EndInit()
            Me.TabPage2.ResumeLayout(False)
            Me.dgIntereses.EndInit()
            Me.TabPage3.ResumeLayout(False)
            Me.dgComodatos.EndInit()
            Me.ResumeLayout(False)
        End Sub

        Private Sub Limpiar()
            Me.btnAceptar.Enabled = False
            Me.txtAbono.Text = ""
            Me.lblTotal.Text = "0"
            Me.LimpiarCliente()
        End Sub

        Private Sub LimpiarCliente()
            Me.lblRuta.Text = ""
            Me.lblEmpresa.Text = ""
            Me.txtCliente.Clear()
            Me.lblCliente.Text = ""
            Me.dtpFMovimiento.Value = Me.FechaActual
            Me._Saldo = Decimal.Zero
        End Sub

        Private Sub MostrarEnPantalla(ByVal Año As Integer, ByVal FolioNota As Integer)
            Dim reporte As New frmReporte(Me._RutaReportes, "spFormatoNotaIngresoAbonoPrestamo.rpt", Me._Servidor, Me._Database, Me._Usuario, Me._Password, False)
            reporte.ListaParametros.Add(Año)
            reporte.ListaParametros.Add(FolioNota)
            reporte.ShowDialog()
        End Sub

        Public Sub RegistrarAbonos()
            Dim num5 As Integer = (Me._Registros - 1)
            Dim i As Integer = 0
            Do While (i <= num5)
                Dim num As Decimal = DecimalType.FromObject(Me.dgDatos.Item(i, 3))
                Dim num3 As Integer = IntegerType.FromObject(Me.dgDatos.Item(i, 0))
                Dim num2 As Integer = IntegerType.FromObject(Me.dgDatos.Item(i, 1))
                If (Decimal.Compare(num, Decimal.Zero) > 0) Then
                    Dim comisionista As New PortatilClasses.Consulta.cCobroComisionista
                    comisionista.Actualizar(2, 0, Me.dtpFMovimiento.Value.Year, Me._Cliente, num, 0, 0, Me.dtpFMovimiento.Value.Date, Me._Usuario, 0, String.Concat(New String() {Me.txtComentario.Text, " Folio Préstamo ", StringType.FromInteger(num3), "/", StringType.FromInteger(num2)}), num3, num2, Me._CajaUsuario, Me.dtpFMovimiento.Value.Date)
                    MessageBox.Show(("El abono se ha capturado, folio del abono extraordinario: " & StringType.FromInteger(comisionista.Identificador)), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Me.MostrarEnPantalla(Me.dtpFMovimiento.Value.Year, comisionista.Identificador)
                End If
                i += 1
            Loop
        End Sub

        Public Sub RegistrarAbonos(ByVal Año As Integer, ByVal AlmacenGas As Integer, ByVal MovimientoAlmacen As Integer, ByVal FVenta As DateTime, ByVal Usuario As String)
            Dim num5 As Integer = (Me._Registros - 1)
            Dim i As Integer = 0
            Do While (i <= num5)
                Dim num As Decimal = DecimalType.FromObject(Me.dgDatos.Item(i, 3))
                Dim num3 As Integer = IntegerType.FromObject(Me.dgDatos.Item(i, 0))
                Dim num2 As Integer = IntegerType.FromObject(Me.dgDatos.Item(i, 1))
                Dim comisionista As New PortatilClasses.Consulta.cCobroComisionista
                comisionista.Actualizar(2, 0, Me.dtpFMovimiento.Value.Year, Me._Cliente, num, 0, 0, Me.dtpFMovimiento.Value.Date, Me._Usuario, 0, String.Concat(New String() {Me.txtComentario.Text, " Folio Préstamo ", StringType.FromInteger(num3), "/", StringType.FromInteger(num2)}), num3, num2, Me._CajaUsuario, Me.dtpFMovimiento.Value.Date)
                i += 1
            Loop
        End Sub

        Public Function SaldoTotal() As Decimal
            Dim zero As Decimal = Decimal.Zero
            Dim num4 As Integer = (Me._Registros - 1)
            Dim i As Integer = 0
            Do While (i <= num4)
                zero = Decimal.Add(zero, DecimalType.FromObject(Me.dgDatos.Item(i, 2)))
                i += 1
            Loop
            Return zero
        End Function

        Private Sub txtAbono_Enter(ByVal sender As Object, ByVal e As EventArgs)
            If (StringType.StrCmp(Me.txtAbono.Text, "", False) = 0) Then
                Me.txtAbono.Text = StringType.FromDecimal(Me.AbonoTotal)
                If (Decimal.Compare(DecimalType.FromString(Me.txtAbono.Text), Me._Saldo) > 0) Then
                    Me.txtAbono.Text = ""
                    MessageBox.Show("El abono supera el saldo de la deuda: Monto de la deuda ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                End If
            End If
        End Sub

        Private Sub txtAbono_Leave(ByVal sender As Object, ByVal e As EventArgs)
            If ((StringType.StrCmp(Me.txtAbono.Text, "", False) <> 0) AndAlso (Decimal.Compare(DecimalType.FromString(Me.txtAbono.Text), Me._Saldo) > 0)) Then
                Me.txtAbono.Text = ""
                Me.ActiveControl = Me.txtAbono
                MessageBox.Show("El abono supera el saldo de la deuda: Monto de la deuda ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        End Sub

        Private Sub txtAbono_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            If ((Me._Registros = 1) And (StringType.StrCmp(Me.txtAbono.Text, "", False) <> 0)) Then
                Me.dgDatos.Item(0, 3) = Me.txtAbono.Text
            End If
            If (StringType.StrCmp(Me.txtAbono.Text, "", False) <> 0) Then
                Me.lblTotal.Text = Strings.Format(DecimalType.FromString(Me.txtAbono.Text), "n")
            End If
            Me.HabilitarAceptar()
        End Sub

        Private Sub txtCliente_Leave(ByVal sender As Object, ByVal e As EventArgs)
            If ((StringType.StrCmp(Me.txtCliente.Text, "", False) <> 0) And (Me.NumEnter = 1)) Then
                Me.BuscarCliente()
                Me.NumEnter = 2
            End If
        End Sub

        Private Sub txtCliente_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.HabilitarAceptar()
            Me.NumEnter = 1
        End Sub

        Private Sub txtComentario_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        End Sub


        ' Properties
        Friend Overridable Property btnAceptar As Button
            Get
                Return Me._btnAceptar
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                If (Not Me._btnAceptar Is Nothing) Then
                    RemoveHandler Me._btnAceptar.Click, New EventHandler(AddressOf Me.btnAceptar_Click)
                End If
                Me._btnAceptar = WithEventsValue
                If (Not Me._btnAceptar Is Nothing) Then
                    AddHandler Me._btnAceptar.Click, New EventHandler(AddressOf Me.btnAceptar_Click)
                End If
            End Set
        End Property

        Friend Overridable Property btnBuscar As Button
            Get
                Return Me._btnBuscar
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                If (Not Me._btnBuscar Is Nothing) Then
                    RemoveHandler Me._btnBuscar.Click, New EventHandler(AddressOf Me.btnBuscar_Click)
                End If
                Me._btnBuscar = WithEventsValue
                If (Not Me._btnBuscar Is Nothing) Then
                    AddHandler Me._btnBuscar.Click, New EventHandler(AddressOf Me.btnBuscar_Click)
                End If
            End Set
        End Property

        Friend Overridable Property btnCancelar As Button
            Get
                Return Me._btnCancelar
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Button)
                If (Not Me._btnCancelar Is Nothing) Then
                End If
                Me._btnCancelar = WithEventsValue
                If (Not Me._btnCancelar Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property DataGridTableStyle1 As DataGridTableStyle
            Get
                Return Me._DataGridTableStyle1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As DataGridTableStyle)
                If (Not Me._DataGridTableStyle1 Is Nothing) Then
                End If
                Me._DataGridTableStyle1 = WithEventsValue
                If (Not Me._DataGridTableStyle1 Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property DataGridTextBoxColumn1 As DataGridTextBoxColumn
            Get
                Return Me._DataGridTextBoxColumn1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As DataGridTextBoxColumn)
                If (Not Me._DataGridTextBoxColumn1 Is Nothing) Then
                End If
                Me._DataGridTextBoxColumn1 = WithEventsValue
                If (Not Me._DataGridTextBoxColumn1 Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property DataGridTextBoxColumn2 As DataGridTextBoxColumn
            Get
                Return Me._DataGridTextBoxColumn2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As DataGridTextBoxColumn)
                If (Not Me._DataGridTextBoxColumn2 Is Nothing) Then
                End If
                Me._DataGridTextBoxColumn2 = WithEventsValue
                If (Not Me._DataGridTextBoxColumn2 Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property DataGridTextBoxColumn3 As DataGridTextBoxColumn
            Get
                Return Me._DataGridTextBoxColumn3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As DataGridTextBoxColumn)
                If (Not Me._DataGridTextBoxColumn3 Is Nothing) Then
                End If
                Me._DataGridTextBoxColumn3 = WithEventsValue
                If (Not Me._DataGridTextBoxColumn3 Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property DataGridTextBoxColumn4 As DataGridTextBoxColumn
            Get
                Return Me._DataGridTextBoxColumn4
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As DataGridTextBoxColumn)
                If (Not Me._DataGridTextBoxColumn4 Is Nothing) Then
                End If
                Me._DataGridTextBoxColumn4 = WithEventsValue
                If (Not Me._DataGridTextBoxColumn4 Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property DataGridTextBoxColumn5 As DataGridTextBoxColumn
            Get
                Return Me._DataGridTextBoxColumn5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As DataGridTextBoxColumn)
                If (Not Me._DataGridTextBoxColumn5 Is Nothing) Then
                End If
                Me._DataGridTextBoxColumn5 = WithEventsValue
                If (Not Me._DataGridTextBoxColumn5 Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property dgComodatos As DataGrid
            Get
                Return Me._dgComodatos
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As DataGrid)
                If (Not Me._dgComodatos Is Nothing) Then
                End If
                Me._dgComodatos = WithEventsValue
                If (Not Me._dgComodatos Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property dgDatos As DataGrid
            Get
                Return Me._dgDatos
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As DataGrid)
                If (Not Me._dgDatos Is Nothing) Then
                    RemoveHandler Me._dgDatos.CurrentCellChanged, New EventHandler(AddressOf Me.dgdatos_CurrentCellChanged)
                    RemoveHandler Me._dgDatos.Leave, New EventHandler(AddressOf Me.dgDatos_Leave)
                End If
                Me._dgDatos = WithEventsValue
                If (Not Me._dgDatos Is Nothing) Then
                    AddHandler Me._dgDatos.CurrentCellChanged, New EventHandler(AddressOf Me.dgdatos_CurrentCellChanged)
                    AddHandler Me._dgDatos.Leave, New EventHandler(AddressOf Me.dgDatos_Leave)
                End If
            End Set
        End Property

        Friend Overridable Property dgDetalle As DataGrid
            Get
                Return Me._dgDetalle
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As DataGrid)
                If (Not Me._dgDetalle Is Nothing) Then
                End If
                Me._dgDetalle = WithEventsValue
                If (Not Me._dgDetalle Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property dgIntereses As DataGrid
            Get
                Return Me._dgIntereses
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As DataGrid)
                If (Not Me._dgIntereses Is Nothing) Then
                End If
                Me._dgIntereses = WithEventsValue
                If (Not Me._dgIntereses Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property dtpFMovimiento As DateTimePicker
            Get
                Return Me._dtpFMovimiento
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As DateTimePicker)
                If (Not Me._dtpFMovimiento Is Nothing) Then
                    RemoveHandler Me._dtpFMovimiento.KeyDown, New KeyEventHandler(AddressOf Me.cboAlmacenOrigen_KeyDown)
                End If
                Me._dtpFMovimiento = WithEventsValue
                If (Not Me._dtpFMovimiento Is Nothing) Then
                    AddHandler Me._dtpFMovimiento.KeyDown, New KeyEventHandler(AddressOf Me.cboAlmacenOrigen_KeyDown)
                End If
            End Set
        End Property

        Friend Overridable Property grpDatos As GroupBox
            Get
                Return Me._grpDatos
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As GroupBox)
                If (Not Me._grpDatos Is Nothing) Then
                End If
                Me._grpDatos = WithEventsValue
                If (Not Me._grpDatos Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property Label1 As Label
            Get
                Return Me._Label1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                If (Not Me._Label1 Is Nothing) Then
                End If
                Me._Label1 = WithEventsValue
                If (Not Me._Label1 Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property Label12 As Label
            Get
                Return Me._Label12
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                If (Not Me._Label12 Is Nothing) Then
                End If
                Me._Label12 = WithEventsValue
                If (Not Me._Label12 Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property Label15 As Label
            Get
                Return Me._Label15
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                If (Not Me._Label15 Is Nothing) Then
                End If
                Me._Label15 = WithEventsValue
                If (Not Me._Label15 Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property Label2 As Label
            Get
                Return Me._Label2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                If (Not Me._Label2 Is Nothing) Then
                End If
                Me._Label2 = WithEventsValue
                If (Not Me._Label2 Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property Label3 As Label
            Get
                Return Me._Label3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                If (Not Me._Label3 Is Nothing) Then
                End If
                Me._Label3 = WithEventsValue
                If (Not Me._Label3 Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property Label5 As Label
            Get
                Return Me._Label5
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                If (Not Me._Label5 Is Nothing) Then
                End If
                Me._Label5 = WithEventsValue
                If (Not Me._Label5 Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property Label6 As Label
            Get
                Return Me._Label6
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                If (Not Me._Label6 Is Nothing) Then
                End If
                Me._Label6 = WithEventsValue
                If (Not Me._Label6 Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property lblCliente As Label
            Get
                Return Me._lblCliente
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                If (Not Me._lblCliente Is Nothing) Then
                End If
                Me._lblCliente = WithEventsValue
                If (Not Me._lblCliente Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property lblEmpresa As Label
            Get
                Return Me._lblEmpresa
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                If (Not Me._lblEmpresa Is Nothing) Then
                End If
                Me._lblEmpresa = WithEventsValue
                If (Not Me._lblEmpresa Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property lblRuta As Label
            Get
                Return Me._lblRuta
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                If (Not Me._lblRuta Is Nothing) Then
                End If
                Me._lblRuta = WithEventsValue
                If (Not Me._lblRuta Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property lblTotal As Label
            Get
                Return Me._lblTotal
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As Label)
                If (Not Me._lblTotal Is Nothing) Then
                End If
                Me._lblTotal = WithEventsValue
                If (Not Me._lblTotal Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property TabControl1 As TabControl
            Get
                Return Me._TabControl1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TabControl)
                If (Not Me._TabControl1 Is Nothing) Then
                End If
                Me._TabControl1 = WithEventsValue
                If (Not Me._TabControl1 Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property TabPage1 As TabPage
            Get
                Return Me._TabPage1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TabPage)
                If (Not Me._TabPage1 Is Nothing) Then
                End If
                Me._TabPage1 = WithEventsValue
                If (Not Me._TabPage1 Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property TabPage2 As TabPage
            Get
                Return Me._TabPage2
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TabPage)
                If (Not Me._TabPage2 Is Nothing) Then
                End If
                Me._TabPage2 = WithEventsValue
                If (Not Me._TabPage2 Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property TabPage3 As TabPage
            Get
                Return Me._TabPage3
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TabPage)
                If (Not Me._TabPage3 Is Nothing) Then
                End If
                Me._TabPage3 = WithEventsValue
                If (Not Me._TabPage3 Is Nothing) Then
                End If
            End Set
        End Property

        Friend Overridable Property txtAbono As txtNumeroDecimal
            Get
                Return Me._txtAbono
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As txtNumeroDecimal)
                If (Not Me._txtAbono Is Nothing) Then
                    RemoveHandler Me._txtAbono.Leave, New EventHandler(AddressOf Me.txtAbono_Leave)
                    RemoveHandler Me._txtAbono.Enter, New EventHandler(AddressOf Me.txtAbono_Enter)
                    RemoveHandler Me._txtAbono.TextChanged, New EventHandler(AddressOf Me.txtAbono_TextChanged)
                    RemoveHandler Me._txtAbono.KeyDown, New KeyEventHandler(AddressOf Me.cboAlmacenOrigen_KeyDown)
                End If
                Me._txtAbono = WithEventsValue
                If (Not Me._txtAbono Is Nothing) Then
                    AddHandler Me._txtAbono.Leave, New EventHandler(AddressOf Me.txtAbono_Leave)
                    AddHandler Me._txtAbono.Enter, New EventHandler(AddressOf Me.txtAbono_Enter)
                    AddHandler Me._txtAbono.TextChanged, New EventHandler(AddressOf Me.txtAbono_TextChanged)
                    AddHandler Me._txtAbono.KeyDown, New KeyEventHandler(AddressOf Me.cboAlmacenOrigen_KeyDown)
                End If
            End Set
        End Property

        Friend Overridable Property txtCliente As txtNumeroEntero
            Get
                Return Me._txtCliente
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As txtNumeroEntero)
                If (Not Me._txtCliente Is Nothing) Then
                    RemoveHandler Me._txtCliente.TextChanged, New EventHandler(AddressOf Me.txtCliente_TextChanged)
                    RemoveHandler Me._txtCliente.Leave, New EventHandler(AddressOf Me.txtCliente_Leave)
                    RemoveHandler Me._txtCliente.KeyDown, New KeyEventHandler(AddressOf Me.cboAlmacenOrigen_KeyDown)
                End If
                Me._txtCliente = WithEventsValue
                If (Not Me._txtCliente Is Nothing) Then
                    AddHandler Me._txtCliente.TextChanged, New EventHandler(AddressOf Me.txtCliente_TextChanged)
                    AddHandler Me._txtCliente.Leave, New EventHandler(AddressOf Me.txtCliente_Leave)
                    AddHandler Me._txtCliente.KeyDown, New KeyEventHandler(AddressOf Me.cboAlmacenOrigen_KeyDown)
                End If
            End Set
        End Property

        Friend Overridable Property txtComentario As TextBox
            Get
                Return Me._txtComentario
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)> _
            Set(ByVal WithEventsValue As TextBox)
                If (Not Me._txtComentario Is Nothing) Then
                    RemoveHandler Me._txtComentario.TextChanged, New EventHandler(AddressOf Me.txtComentario_TextChanged)
                    RemoveHandler Me._txtComentario.KeyDown, New KeyEventHandler(AddressOf Me.cboAlmacenOrigen_KeyDown)
                End If
                Me._txtComentario = WithEventsValue
                If (Not Me._txtComentario Is Nothing) Then
                    AddHandler Me._txtComentario.TextChanged, New EventHandler(AddressOf Me.txtComentario_TextChanged)
                    AddHandler Me._txtComentario.KeyDown, New KeyEventHandler(AddressOf Me.cboAlmacenOrigen_KeyDown)
                End If
            End Set
        End Property


        ' Fields
        Private _Almacengas As Integer
        <AccessedThroughProperty("btnAceptar")> _
        Private _btnAceptar As Button
        <AccessedThroughProperty("btnBuscar")> _
        Private _btnBuscar As Button
        <AccessedThroughProperty("btnCancelar")> _
        Private _btnCancelar As Button
        Private _CajaUsuario As Byte
        Private _Cliente As Integer
        Private _CorporativoUsuario As Short
        Private _Database As String
        <AccessedThroughProperty("DataGridTableStyle1")> _
        Private _DataGridTableStyle1 As DataGridTableStyle
        <AccessedThroughProperty("DataGridTextBoxColumn1")> _
        Private _DataGridTextBoxColumn1 As DataGridTextBoxColumn
        <AccessedThroughProperty("DataGridTextBoxColumn2")> _
        Private _DataGridTextBoxColumn2 As DataGridTextBoxColumn
        <AccessedThroughProperty("DataGridTextBoxColumn3")> _
        Private _DataGridTextBoxColumn3 As DataGridTextBoxColumn
        <AccessedThroughProperty("DataGridTextBoxColumn4")> _
        Private _DataGridTextBoxColumn4 As DataGridTextBoxColumn
        <AccessedThroughProperty("DataGridTextBoxColumn5")> _
        Private _DataGridTextBoxColumn5 As DataGridTextBoxColumn
        <AccessedThroughProperty("dgComodatos")> _
        Private _dgComodatos As DataGrid
        <AccessedThroughProperty("dgDatos")> _
        Private _dgDatos As DataGrid
        <AccessedThroughProperty("dgDetalle")> _
        Private _dgDetalle As DataGrid
        <AccessedThroughProperty("dgIntereses")> _
        Private _dgIntereses As DataGrid
        <AccessedThroughProperty("dtpFMovimiento")> _
        Private _dtpFMovimiento As DateTimePicker
        <AccessedThroughProperty("grpDatos")> _
        Private _grpDatos As GroupBox
        <AccessedThroughProperty("Label1")> _
        Private _Label1 As Label
        <AccessedThroughProperty("Label12")> _
        Private _Label12 As Label
        <AccessedThroughProperty("Label15")> _
        Private _Label15 As Label
        <AccessedThroughProperty("Label2")> _
        Private _Label2 As Label
        <AccessedThroughProperty("Label3")> _
        Private _Label3 As Label
        <AccessedThroughProperty("Label5")> _
        Private _Label5 As Label
        <AccessedThroughProperty("Label6")> _
        Private _Label6 As Label
        <AccessedThroughProperty("lblCliente")> _
        Private _lblCliente As Label
        <AccessedThroughProperty("lblEmpresa")> _
        Private _lblEmpresa As Label
        <AccessedThroughProperty("lblRuta")> _
        Private _lblRuta As Label
        <AccessedThroughProperty("lblTotal")> _
        Private _lblTotal As Label
        Private _MovimientoAlmacen As Integer
        Private _Password As String
        Private _Registros As Integer
        Private _RutaReportes As String
        Private _Saldo As Decimal
        Private _Servidor As String
        Private _SucursalUsuario As Short
        <AccessedThroughProperty("TabControl1")> _
        Private _TabControl1 As TabControl
        <AccessedThroughProperty("TabPage1")> _
        Private _TabPage1 As TabPage
        <AccessedThroughProperty("TabPage2")> _
        Private _TabPage2 As TabPage
        <AccessedThroughProperty("TabPage3")> _
        Private _TabPage3 As TabPage
        Private _Tipo As Short
        <AccessedThroughProperty("txtAbono")> _
        Private _txtAbono As txtNumeroDecimal
        <AccessedThroughProperty("txtCliente")> _
        Private _txtCliente As txtNumeroEntero
        <AccessedThroughProperty("txtComentario")> _
        Private _txtComentario As TextBox
        Private _Usuario As String
        Private components As IContainer
        Public NumEnter As Short
    End Class
End Namespace


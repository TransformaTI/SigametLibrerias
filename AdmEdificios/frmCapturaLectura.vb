Option Strict On
Imports System.Data.SqlClient
Imports PocketEdificios
Imports System.Windows.Forms

Public Class frmCapturaLectura
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboLecturista As SigaMetClasses.Combos.ComboEmpleado
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaLectura As System.Windows.Forms.DateTimePicker
    Friend WithEvents panelLecturas As System.Windows.Forms.Panel
    Friend WithEvents TxtPorcentaje As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents tTip As System.Windows.Forms.ToolTip
    Friend WithEvents dtpFechaMaxPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboPrecio As ComboPrecio
    Friend WithEvents GrdHeader1 As grdHeader
    Friend WithEvents GrdFooter1 As grdFooter
    Friend WithEvents DatosCliente1 As DatosCliente
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents lblRedondeoActivo As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCapturaLectura))
        Me.TxtPorcentaje = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFechaLectura = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboLecturista = New SigaMetClasses.Combos.ComboEmpleado()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.panelLecturas = New System.Windows.Forms.Panel()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblRedondeoActivo = New System.Windows.Forms.Label()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.cboPrecio = New AdmEdificios.ComboPrecio()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpFechaMaxPago = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.tTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GrdHeader1 = New AdmEdificios.grdHeader()
        Me.GrdFooter1 = New AdmEdificios.grdFooter()
        Me.DatosCliente1 = New AdmEdificios.DatosCliente()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtPorcentaje
        '
        Me.TxtPorcentaje.Location = New System.Drawing.Point(392, 40)
        Me.TxtPorcentaje.Name = "TxtPorcentaje"
        Me.TxtPorcentaje.Size = New System.Drawing.Size(56, 21)
        Me.TxtPorcentaje.TabIndex = 4
        Me.TxtPorcentaje.Text = ""
        Me.TxtPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 14)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "F. Lectura:"
        '
        'dtpFechaLectura
        '
        Me.dtpFechaLectura.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaLectura.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFechaLectura.Location = New System.Drawing.Point(128, 16)
        Me.dtpFechaLectura.Name = "dtpFechaLectura"
        Me.dtpFechaLectura.Size = New System.Drawing.Size(88, 21)
        Me.dtpFechaLectura.TabIndex = 0
        Me.tTip.SetToolTip(Me.dtpFechaLectura, "Fecha en que el empleado de GM tomó la lectura")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(304, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Empleado"
        '
        'cboLecturista
        '
        Me.cboLecturista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLecturista.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLecturista.Location = New System.Drawing.Point(392, 16)
        Me.cboLecturista.Name = "cboLecturista"
        Me.cboLecturista.Size = New System.Drawing.Size(168, 21)
        Me.cboLecturista.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(456, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "%"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(304, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Porcentaje"
        '
        'panelLecturas
        '
        Me.panelLecturas.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.panelLecturas.AutoScroll = True
        Me.panelLecturas.BackColor = System.Drawing.Color.WhiteSmoke
        Me.panelLecturas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelLecturas.Location = New System.Drawing.Point(15, 240)
        Me.panelLecturas.Name = "panelLecturas"
        Me.panelLecturas.Size = New System.Drawing.Size(942, 296)
        Me.panelLecturas.TabIndex = 2
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(876, 24)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 23)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(876, 56)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 23)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRedondeoActivo, Me.btnImportar, Me.cboPrecio, Me.Label9, Me.dtpFechaMaxPago, Me.Label26, Me.dtpFechaLectura, Me.cboLecturista, Me.TxtPorcentaje, Me.Label3, Me.Label2, Me.Label4, Me.Label5})
        Me.GroupBox2.Location = New System.Drawing.Point(16, 88)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(940, 96)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'lblRedondeoActivo
        '
        Me.lblRedondeoActivo.AutoSize = True
        Me.lblRedondeoActivo.Location = New System.Drawing.Point(720, 76)
        Me.lblRedondeoActivo.Name = "lblRedondeoActivo"
        Me.lblRedondeoActivo.Size = New System.Drawing.Size(0, 14)
        Me.lblRedondeoActivo.TabIndex = 15
        '
        'btnImportar
        '
        Me.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnImportar.Image = CType(resources.GetObject("btnImportar.Image"), System.Drawing.Bitmap)
        Me.btnImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportar.Location = New System.Drawing.Point(852, 24)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.TabIndex = 14
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboPrecio
        '
        Me.cboPrecio.Location = New System.Drawing.Point(128, 64)
        Me.cboPrecio.Name = "cboPrecio"
        Me.cboPrecio.Size = New System.Drawing.Size(88, 21)
        Me.cboPrecio.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 67)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 14)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Precio"
        '
        'dtpFechaMaxPago
        '
        Me.dtpFechaMaxPago.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaMaxPago.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFechaMaxPago.Location = New System.Drawing.Point(128, 40)
        Me.dtpFechaMaxPago.Name = "dtpFechaMaxPago"
        Me.dtpFechaMaxPago.Size = New System.Drawing.Size(88, 21)
        Me.dtpFechaMaxPago.TabIndex = 1
        Me.tTip.SetToolTip(Me.dtpFechaMaxPago, "Fecha máxima para el pago del suministro ")
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(16, 43)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(67, 14)
        Me.Label26.TabIndex = 12
        Me.Label26.Text = "F. de pago:"
        '
        'GrdHeader1
        '
        Me.GrdHeader1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.GrdHeader1.Location = New System.Drawing.Point(16, 192)
        Me.GrdHeader1.Name = "GrdHeader1"
        Me.GrdHeader1.Size = New System.Drawing.Size(940, 48)
        Me.GrdHeader1.TabIndex = 60
        '
        'GrdFooter1
        '
        Me.GrdFooter1.Location = New System.Drawing.Point(16, 544)
        Me.GrdFooter1.Name = "GrdFooter1"
        Me.GrdFooter1.Observaciones = ""
        Me.GrdFooter1.ReadOnlyObservaciones = False
        Me.GrdFooter1.Size = New System.Drawing.Size(941, 80)
        Me.GrdFooter1.TabIndex = 61
        Me.GrdFooter1.TotalConsumo = ""
        Me.GrdFooter1.TotalDiferencia = ""
        Me.GrdFooter1.TotalImporte = ""
        '
        'DatosCliente1
        '
        Me.DatosCliente1.AddressForeColor = System.Drawing.SystemColors.WindowText
        Me.DatosCliente1.AmountForeColor = System.Drawing.Color.Maroon
        Me.DatosCliente1.ContratoNombre = "Contrato:                    Contrato:                    Contrato:              " & _
        "      Contrato:                    Contrato:                    Contrato:       " & _
        "             Contrato:                    Contrato:                    Contrato:" & _
        "                    Contrato:                    Contrato:                    Co" & _
        "ntrato:                    Contrato:                    Contrato:               " & _
        "     Contrato:                    Contrato:                    Contrato:        " & _
        "             xxx"
        Me.DatosCliente1.Direccion = "XXXXXXXXXXXXXX, XXXXXXXXX, XXXXX"
        Me.DatosCliente1.FUltimoSurtido = "XX/XX/XXXX"
        Me.DatosCliente1.LastSForeColor = System.Drawing.Color.DarkBlue
        Me.DatosCliente1.Location = New System.Drawing.Point(16, 8)
        Me.DatosCliente1.Name = "DatosCliente1"
        Me.DatosCliente1.PhoneForeColor = System.Drawing.Color.DarkGreen
        Me.DatosCliente1.Saldo = "XXXX"
        Me.DatosCliente1.Size = New System.Drawing.Size(784, 80)
        Me.DatosCliente1.TabIndex = 62
        Me.DatosCliente1.Telefono = "XXXXXXXX"
        '
        'frmCapturaLectura
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(976, 631)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DatosCliente1, Me.GrdFooter1, Me.GrdHeader1, Me.GroupBox2, Me.btnAceptar, Me.btnCancelar, Me.panelLecturas})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCapturaLectura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de lecturas"
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Declaraciones"

    Dim dtLecturas As New DataTable()
    Dim connection As New SqlConnection()
    Dim _Cliente As Integer
    Dim factorDeConversion As Decimal
    Dim precioPorLitro As Decimal
    Dim fechaLectura As String
    Dim fechaMaxPago As String
    Dim fechaLecturaAnterior As String
    Dim porcentajeTanque As Decimal
    Dim usuario As String
    Dim lecturaIncial As Boolean
    Dim lecturaIncialEditada As Boolean
    Dim _Iva As Short

    Private _redondeoAplicado As Boolean = False

    Dim rutaReportes As String

    Dim _Data As cLectura

    'Carga de parámetros duplicados
    Dim _corporativo As Short
    Dim _sucursal As Short
    '*****

    Public ReadOnly Property FechaDeLectura() As Date
        Get
            Return CType(fechaLectura, Date)
        End Get
    End Property

#End Region

#Region "Constructor"

    Public Sub New(ByVal Cliente As Integer, ByVal UserName As String, ByVal conexión As SqlConnection, _
        ByVal Corporativo As Short, ByVal Sucursal As Short, _
        Optional ByVal RedondeoAplicado As Boolean = False)
        'Captura
        MyBase.New()
        InitializeComponent()
        _Cliente = Cliente
        connection = conexión
        usuario = UserName

        _corporativo = Corporativo
        _sucursal = Sucursal

        _redondeoAplicado = RedondeoAplicado

        _Data = New cLectura(_Cliente, connection)
        _Iva = _Data.IVA()
        cargaDatosCliente(Cliente)

        'Para indicar si está el redondeo activo
        Select Case RedondeoAplicado
            Case True : lblRedondeoActivo.Text = "Redondeo activo"
            Case Else : lblRedondeoActivo.Text = "Redondeo inactivo"
        End Select

        cboPrecio.CargaPrecios(connection, dtpFechaLectura.Value)
        cargaParametros()
        cargaHijosEnPantalla()
        'TODO: Ver cuales empleados deben aparecer en el combo
        AddHandler btnAceptar.Click, AddressOf btnAceptar_Click
        AddHandler dtpFechaLectura.Validating, AddressOf dtpFechaLectura_Validating
        AddHandler cboPrecio.Validating, AddressOf recalculoPorCambio
        cboLecturista.CargaDatos(False)
    End Sub

    Public Sub New(ByVal Cliente As Integer, ByVal FechaDeLectura As String, ByVal UserName As String, _
        ByVal conexión As SqlConnection, _
        ByVal Corporativo As Short, ByVal Sucursal As Short)
        'Consulta
        MyBase.New()
        InitializeComponent()
        _Cliente = Cliente
        fechaLectura = FechaDeLectura
        connection = conexión

        _corporativo = Corporativo
        _sucursal = Sucursal

        _Data = New cLectura(_Cliente, connection, CType(fechaLectura, Date))
        _Iva = _Data.IVA()
        cargaDatosCliente(Cliente)

        cargaHijosEnPantalla(_Cliente, fechaLectura)
        AddHandler btnAceptar.Click, AddressOf btnAceptar_Click2
        RemoveHandler btnCancelar.Click, AddressOf btnCancelar_Click
        AddHandler btnCancelar.Click, AddressOf btnCancelar2_Click
        btnCancelar.Text = "Imprimir"
        btnCancelar.Image = Nothing
    End Sub

#End Region

#Region "Incialización de objetos y variables"

    Private Sub cargaHijosEnPantalla()
        Dim pnlWidth As Integer = panelLecturas.Width + 18

        dtLecturas = _Data.LecturaDetalle
        Dim dc As DataColumn = Nothing
        Dim dr As DataRow
        Dim top As Integer = 0
        lecturaIncial = _Data.TipoLectura
        If lecturaIncial Then
            'Le pone por defecto al txtbx observaciones que es una lectura inicial
            GrdFooter1.Observaciones = "Captura de lectura inicial"
        End If
        For Each dr In dtLecturas.Rows
            Dim left As Integer = 0
            Dim i As Integer = 1
            'TODO: Cargar el iva de un parámetro
            Dim row As New rowClienteHijo(factorDeConversion, precioPorLitro, _Iva)
            'Agrega un row (usercontrol), que recibe el factor de conversión, y el precio por litro
            'y que recibe valores del datatable
            row.Name = "fila" & CStr(i)
            row.Left = left
            row.Top = top
            row.Cliente = CType(dr.Item("Cliente"), String)
            row.NumeroInterior = CType(dr.Item("Interior"), String)
            row.FechaLecturaInicial = CType(dr.Item("FLecturaIncial"), String)
            'If CType(dr.Item("FLecturaIncial"), String) = "-" And Not (lecturaIncial) Then
            '    'Si no hay lectura inicial para este hijo, hace el campo editable, para que se pueda capt. una lectura inicial
            '    row.LecturaInicialEditable = True
            'End If
            ''Else
            row.LecturaInicial = CType(dr.Item("LecturaIncial"), String)

            'parametrización del redondeo
            row.RedondeoActivo = _redondeoAplicado

            row.RedondeoPorAplicar = CType(dr.Item("Redondeo"), Decimal)

            If Len(row.FechaLecturaInicial.Trim) > 1 Then
                fechaLecturaAnterior = row.FechaLecturaInicial
            End If

            'End If
            If lecturaIncial Then
                'Si se va a capturar una lectura incial para todos los hijos del padre, hace el campo lectura final no editable
                row.ImporteTotalEditable = True
            Else
                row.ImporteTotalEditable = False
            End If
            AddHandler row.Validating, AddressOf calculaTotales
            panelLecturas.Controls.Add(row)
            top += 21
            i += 1
            If top > panelLecturas.Height Then
                panelLecturas.Width = pnlWidth
            End If
        Next
    End Sub

    Private Sub cargaHijosEnPantalla(ByVal cliente As Integer, ByVal fechaLectura As String)
        Dim pnlWidth As Integer = panelLecturas.Width + 18

        dtLecturas = _Data.LecturaDetalle
        Dim dc As DataColumn = Nothing
        Dim dr As DataRow
        Dim top As Integer = 0
        dtpFechaLectura.Value = CType(dtLecturas.Rows(0).Item("FLectura"), Date)
        dtpFechaLectura.Enabled = False
        If Not (dtLecturas.Rows(0).Item("FMaxPago") Is DBNull.Value) Then
            dtpFechaMaxPago.Value = CType(dtLecturas.Rows(0).Item("FMaxPago"), Date)
        Else
            dtpFechaMaxPago.Value = dtpFechaMaxPago.MinDate
        End If
        dtpFechaMaxPago.Enabled = False
        GrdFooter1.Observaciones = CType(dtLecturas.Rows(0).Item("Observaciones"), String)
        GrdFooter1.ReadOnlyObservaciones = True
        TxtPorcentaje.Text = CType(dtLecturas.Rows(0).Item("PorcentajeTanque"), String)
        TxtPorcentaje.ReadOnly = True
        cboLecturista.CargaDatos(False)
        cboLecturista.SelectedValue = CType(dtLecturas.Rows(0).Item("Empleado"), Integer)
        cboLecturista.Enabled = False
        cboPrecio.Enabled = False
        Dim totalDiferencia As Double
        Dim totalConsumo As Double
        Dim totalImporte As Double
        For Each dr In dtLecturas.Rows
            Dim left As Integer = 0
            Dim i As Integer = 1
            Dim row As New rowClienteHijo(factorDeConversion, precioPorLitro, 15)
            'Agrega un row (usercontrol), que recibe el factor de conversión, y el precio por litro
            'y que recibe valores del datatable
            row.Name = "fila" & CStr(i)
            row.Left = left
            row.Top = top
            row.LecturaFinalEditable = False
            row.LecturaInicialEditable = False
            row.Cliente = CType(dr.Item("Cliente"), String)
            row.NumeroInterior = CType(dr.Item("NumInterior"), String)
            row.FechaLecturaInicial = CDate(CType(dr.Item("FLecturaInicial"), String)).ToShortDateString
            row.LecturaInicial = CType(dr.Item("LecturaInicial"), String)
            row.FechaLecturaFinal = CDate(CType(dr.Item("FLecturaFinal"), String)).ToShortDateString
            row.LecturaFinal = CType(dr.Item("LecturaFinal"), String)
            row.Diferencia = CType(dr.Item("DiferenciaLectura"), String)
            row.ConsumoLitros = CType(dr.Item("ConsumoLitros"), String)
            row.ImporteConsumo = FormatCurrency(CType(dr.Item("Importe"), String))
            row.ImpuestoConsumo = FormatCurrency(CType(dr.Item("Impuesto"), String))
            row.TotalConsumo = FormatCurrency(CType(dr.Item("Total"), String))
            row.Redondeo = CType(dr.Item("RedondeoSiguientePeriodo"), Decimal)
            panelLecturas.Controls.Add(row)
            top += 21
            i += 1
            If top > panelLecturas.Height Then
                panelLecturas.Width = pnlWidth
            End If
            totalDiferencia = totalDiferencia + CType(row.Diferencia, Integer)
            totalConsumo = totalConsumo + CType(row.ConsumoLitros, Integer)
            totalImporte = totalImporte + CType(row.TotalConsumo, Double)
        Next
        muestraTotales(totalDiferencia, totalConsumo, totalImporte)
    End Sub

    Private Sub cargaParametros()
        SigaMetClasses.DataLayer.InicializaConexion(connection)
        Dim config As New SigaMetClasses.cConfig(1, _corporativo, _sucursal)

        factorDeConversion = _Data.FactorDeConversion
        Me.GrdHeader1.FactorConversion = "Factor conv: " & CStr(factorDeConversion)
        fechaLectura = dtpFechaLectura.Value.ToShortDateString
        fechaMaxPago = dtpFechaMaxPago.Value.ToShortDateString
        precioPorLitro = CDec(cboPrecio.SelectedValue)
        Me.GrdHeader1.PrecioLitro = "Precio lt: " & CStr(precioPorLitro)
        Me.GrdHeader1.IVA = "IVA " & CStr(_Iva) & "%"
    End Sub

    Private Sub cargaDatosCliente(ByVal cliente As Integer)
        DatosCliente1.ContratoNombre = CStr(_Data.Cliente) & " - " & _Data.Nombre
        DatosCliente1.Direccion = _Data.Direccion
        DatosCliente1.Telefono = _Data.Telefono
        DatosCliente1.FUltimoSurtido = CStr(_Data.FUltimoSuministro)
        DatosCliente1.Saldo = FormatCurrency(CStr(_Data.Saldo), 2, TriState.True)
    End Sub

#End Region

#Region "Inserción de registros"

    Private Sub guardarDatos()
        Try
            _Data.AbreConexion()
            Dim lectura As Integer = _Data.AltaLectura(fechaLectura, fechaLecturaAnterior, CInt(porcentajeTanque), _
                fechaMaxPago, usuario, CInt(cboLecturista.SelectedValue), GrdFooter1.Observaciones, precioPorLitro)
            Dim control As Windows.Forms.Control
            For Each control In panelLecturas.Controls
                If TypeOf control Is rowClienteHijo Then
                    _Data.AltaLecturaDetalle(lectura, CInt(DirectCast(control, rowClienteHijo).Cliente), _
                                        CDbl(DirectCast(control, rowClienteHijo).LecturaInicial), CDbl(DirectCast(control, rowClienteHijo).LecturaFinal), _
                                        CDbl(DirectCast(control, rowClienteHijo).Diferencia), CDbl(DirectCast(control, rowClienteHijo).ConsumoLitros), _
                                        CDbl(DirectCast(control, rowClienteHijo).ImporteConsumo), CDbl(DirectCast(control, rowClienteHijo).ImpuestoConsumo), _
                                        CDbl(DirectCast(control, rowClienteHijo).TotalConsumo), _
                                        CDbl(DirectCast(control, rowClienteHijo).Redondeo), CDbl(DirectCast(control, rowClienteHijo).RedondeoPorAplicar))
                    'TODO: redondeo de edificios se agregó esta para 
                End If
            Next
            _Data.CierraTransaccion()
            Windows.Forms.MessageBox.Show("Lectura guardada correctamente con el número: " & CType(lectura, String), _
            "Captura terminada", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
            imprimirReporte() 'Impresion de reporte de lectura
        Catch ex As SqlClient.SqlException
            Windows.Forms.MessageBox.Show("Error no: " & CStr(ex.Number) & Chr(13) & ex.Message, "Error", _
            Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, "Error", Windows.Forms.MessageBoxButtons.OK, _
            Windows.Forms.MessageBoxIcon.Error)
        Finally
            _Data.CierraConexion()
        End Try
    End Sub

#End Region

#Region "Validaciones"

    Private Sub TxtPorcentaje_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPorcentaje.TextChanged
        'Obtiene el valor del porcentaje del tanque
        If IsNumeric(TxtPorcentaje.Text) Then
            porcentajeTanque = CType(TxtPorcentaje.Text, Decimal)
        End If
    End Sub

    Private Sub panelLecturas_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles panelLecturas.Enter
        'Valida que cuando menos el usuario haya entrado al panel, principalmente para captura de lecuras iniciales
        lecturaIncialEditada = True
    End Sub

    Private Sub dtpFechaLectura_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        'Valida los cambios de fecha para obtener los precios correspondientes
        fechaLectura = dtpFechaLectura.Value.ToShortDateString
        dtpFechaMaxPago.Value = DateAdd(DateInterval.Day, 1, dtpFechaLectura.Value)
        cboPrecio.CargaPrecios(connection, dtpFechaLectura.Value)
        recalculoPorCambio(sender, e)
    End Sub

    Private Sub recalculoPorCambio(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        precioPorLitro = CDec(cboPrecio.SelectedValue)
        Me.GrdHeader1.PrecioLitro = "Precio lt: " & CStr(precioPorLitro)
        Dim control As Windows.Forms.Control
        For Each control In panelLecturas.Controls
            If TypeOf control Is rowClienteHijo Then
                CType(control, rowClienteHijo).FechaLecturaFinal = fechaLectura
                CType(control, rowClienteHijo).PrecioPorLitro = precioPorLitro
                If lecturaIncial Then
                    'si se está calulando una lectura inicial, se muestra la fecha que se selecciono en cada row
                    CType(control, rowClienteHijo).FechaLecturaInicial = fechaLectura
                    CType(control, rowClienteHijo).calcularProrrateo(precioPorLitro)
                Else
                    'si se está calulando una lectura final, se muestra la fecha que se selecciono en cada row
                    If lecturaIncialEditada And CType(DirectCast(control, rowClienteHijo).LecturaFinal, Double) > 0 Then
                        'si se capturó una lectura final en el row, se recalcula el importe
                        CType(control, rowClienteHijo).recalcular(precioPorLitro)
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub dtpFechaMaxPago_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpFechaMaxPago.Validating
        fechaMaxPago = dtpFechaMaxPago.Value.ToShortDateString
    End Sub

    Private Sub mensajeError(ByVal mensaje As String, ByVal control As Windows.Forms.Control)
        Windows.Forms.MessageBox.Show(mensaje, "Error", Windows.Forms.MessageBoxButtons.OK, _
            Windows.Forms.MessageBoxIcon.Error)
        control.Focus()
    End Sub

    Private Sub calculaTotales(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim totalDiferencia As Double
        Dim totalConsumo As Double
        Dim totalImporte As Double
        Dim control As Windows.Forms.Control
        For Each control In Me.panelLecturas.Controls()
            If IsNumeric(CType(control, rowClienteHijo).Diferencia) Then
                totalDiferencia = totalDiferencia + CType(CType(control, rowClienteHijo).Diferencia, Double)
            End If
            If IsNumeric(CType(control, rowClienteHijo).ConsumoLitros) Then
                totalConsumo = totalConsumo + CType(CType(control, rowClienteHijo).ConsumoLitros, Double)
            End If
            If IsNumeric(CType(control, rowClienteHijo).ImporteConsumo) Then
                totalImporte = totalImporte + CType(CType(control, rowClienteHijo).TotalConsumo, Double)
            End If
        Next
        muestraTotales(totalDiferencia, totalConsumo, totalImporte)
    End Sub

    Private Sub muestraTotales(ByVal diferencia As Double, ByVal consumo As Double, ByVal importe As Double)
        Me.GrdFooter1.TotalDiferencia = CType(diferencia, String)
        Me.GrdFooter1.TotalConsumo = CType(consumo, String) & " lts."
        Me.GrdFooter1.TotalImporte = FormatCurrency(CType(importe, String), 2)
    End Sub

#End Region

#Region "Aceptar/Cancelar"

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Windows.Forms.MessageBox.Show("¿Están correctos los datos?", "Captura de lecturas", _
            Windows.Forms.MessageBoxButtons.YesNo, _
            Windows.Forms.MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes _
        Then
            If CType(fechaLectura, Date) > Date.Today Then
                'No se pueden capturar lecturas con fecha posterior a la de hoy
                mensajeError("La fecha de lectura no puede ser mayor a la fecha actual", dtpFechaLectura)
                Exit Sub
            End If
            If precioPorLitro <= 0 Then
                'No se pueden capturar lecturas con fecha posterior a la de hoy
                mensajeError("El precio no es válido", dtpFechaLectura)
                Exit Sub
            End If
            If Len(fechaLecturaAnterior) > 0 Then 'Valida que no es lectura inicial
                If CType(fechaLecturaAnterior, Date) >= CType(fechaLectura, Date) Then
                    'Si hay lectura anterior, la fecha de la lectura actual no puede ser menor a la anterior
                    mensajeError("La fecha de lectura actual no puede" & Chr(13) & _
                        "ser menor o igual a la fecha de lectura anterior", dtpFechaLectura)
                    Exit Sub
                End If
            End If
            If Len(Trim(TxtPorcentaje.Text)) = 0 Then
                mensajeError("Debe capturar un procentaje" & Chr(13) & "de llaneado de tanque", TxtPorcentaje)
                Exit Sub
            End If
            Dim faltaCaptura As Boolean = True
            Dim control As Windows.Forms.Control
            For Each control In panelLecturas.Controls
                If TypeOf control Is rowClienteHijo Then
                    If Not (IsNumeric(DirectCast(control, rowClienteHijo).Diferencia)) OrElse _
                        CType(DirectCast(control, rowClienteHijo).Diferencia, Double) < 0 Then
                        'Verifica que se hayan capturado lecturas para todos los hijos, el valor del text de cada row 
                        'cambia de "Diferencia" a un valor numérico, que debe ser mayor a 0
                        faltaCaptura = False
                        Exit For
                    End If
                End If
            Next
            If Not (faltaCaptura) Or Not (lecturaIncialEditada) Then
                Windows.Forms.MessageBox.Show("Debe capturar datos para todas las lecturas", "Error", _
                Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                Exit Sub
            End If
            guardardatos()
        End If
    End Sub

    Private Sub btnAceptar_Click2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnCancelar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)        'Impresion de reporte de lectura
        imprimirReporte()
    End Sub

    Private Sub imprimirReporte()
        Dim config As New SigaMetClasses.cConfig(1, _corporativo, _sucursal)
        rutaReportes = CType(config.Parametros.Item("RutaReportes"), String)
        Dim frmReporte As New frmConsultaReporte(connection, _cliente, CDate(fechaLectura), rutaReportes)
        frmReporte.ShowDialog()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

#End Region

#Region "Funciones para el manejo de PocketPC"
    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim Archivo As String = CargaArchivoProcesar()
        If Archivo <> String.Empty Then
            ProcesaArchivo(Archivo)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Function CargaArchivoProcesar() As String
        Dim settings As New AppSettings(Application.StartupPath & "\PocketEdificios.exe.config")
        Dim FTrans As New FileComm()
        Dim InDir, SrcDir As String
        Dim sel As FileComm.ResultadoSeleccionArchivo
        Dim res As DialogResult
        Dim frmStatusConexion As New frmStatusConexion(FTrans)
        Dim i As Integer = 1

        If CBool(settings.GetSetting("PC", "AbsoluteOut")) Then
            InDir = settings.GetSetting("PC", "In")
        Else
            InDir = Application.StartupPath & settings.GetSetting("PC", "In")
        End If
        SrcDir = settings.GetSetting("PCC", "Out")
        res = frmStatusConexion.ShowDialog
        Select Case res
            Case DialogResult.Yes
                Try
                    While (Not FTrans.ExisteDirectorio(SrcDir) AndAlso settings.GetSetting("PCC", "In" & i.ToString()) <> "")
                        SrcDir = settings.GetSetting("PCC", "Out" & i.ToString())
                        i += 1
                    End While
                    If (Not FTrans.ExisteDirectorio(SrcDir)) Then
                        MessageBox.Show("No se ha logrado encontrar la ubicación de los archivos.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)                        
                        Exit Function
                    End If
                    sel = FTrans.SeleccionArchivo(SrcDir, "*.xml")

                    If sel.Archivo <> String.Empty AndAlso _
                                    FTrans.CopiarDelEquipo(sel.Archivo, InDir & sel.Archivo.Substring(sel.Archivo.LastIndexOf("\") + 1)) Then
                        If sel.Eliminar Then
                            FTrans.EliminarDelEquipo(sel.Archivo)
                        End If
                        Return InDir & sel.Archivo.Substring(sel.Archivo.LastIndexOf("\") + 1)
                    Else
                        Return String.Empty
                    End If
                Catch ex As Exception
                    MessageBox.Show("No se ha logrado copiar el archivo.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return String.Empty
                Finally
                    FTrans.Desconectar()
                End Try
            Case DialogResult.No
                MessageBox.Show("No se ha logrado establecer una conexión con el equipo.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return String.Empty
            Case DialogResult.Cancel
                MessageBox.Show("El usuario ha cancelado la conexión.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return String.Empty
        End Select
        frmStatusConexion.Dispose()
        Me.Cursor = Cursors.Default
    End Function
    Private Sub ProcesaArchivo(ByVal FileName As String)
        Dim ds As New DataSet()
        Dim rw As DataRow
        Dim rwCH As rowClienteHijo
        Try
            ds.ReadXml(FileName)
            For Each rw In ds.Tables(0).Rows
                For Each rwCH In panelLecturas.Controls
                    If rwCH.Cliente = CStr(rw("Cliente")) Then
                        If Not IsDBNull(rw("FLecturaFinal")) Then
                            rwCH.FechaLecturaFinal = CDate(rw("FLecturaFinal")).ToShortDateString
                        End If
                        If Not IsDBNull(rw("LecturaFinal")) Then
                            rwCH.LecturaFinal = CStr(rw("LecturaFinal"))
                        End If
                        rwCH.calculaImporte(CType(rwCH.LecturaFinal, Decimal), CType(rwCH.LecturaInicial, Decimal))
                    End If
                Next
                TxtPorcentaje.Text = Convert.ToString(rw("LecTanque"))
            Next
            MessageBox.Show("Se ha completado la carga de datos", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            lecturaIncialEditada = True
        Catch ex As Exception
            Windows.Forms.MessageBox.Show("El formato del archivo es invalido.", "Error de importación.", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

    Private Sub validarRedondeoActivo()

    End Sub

    Private Sub frmCapturaLectura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

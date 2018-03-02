Option Strict On
Imports System.Data.SqlClient
Public Class frmCambioMedidor
    Inherits System.Windows.Forms.Form

    Private _Cliente, _ClientePadre As Integer, _
                 _ConsumoSugerido As Double, _
                 connection As New SqlConnection(), _
                 _precioLt As Decimal, _
                 _FechaLectura As DateTime, _
                 datosCliente As cLecturaClienteHijo

    Private _redondeoActivo As Boolean = False

    Private _corporativo As Short
    Private _sucursal As Short

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Cliente As Integer, ByVal Conexion As SqlConnection, _
        ByVal Corporativo As Short, ByVal Sucursal As Short, _
        Optional ByVal RedondeoActivo As Boolean = False)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        connection = Conexion

        _Cliente = Cliente
        _redondeoActivo = RedondeoActivo

        _corporativo = Corporativo
        _sucursal = Sucursal
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
    Friend WithEvents LAnterior As rowClienteHijo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cDatosCliente As datosCliente
    Friend WithEvents lActual As AdmEdificios.captLecturaCambioMedidor
    Friend WithEvents txtNumLectura As System.Windows.Forms.Label
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents Panel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents GrdHeader1 As grdHeader
    Friend WithEvents lnkSugerirInicial As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCambioMedidor))
        Me.LAnterior = New AdmEdificios.rowClienteHijo()
        Me.cDatosCliente = New AdmEdificios.DatosCliente()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lActual = New AdmEdificios.captLecturaCambioMedidor()
        Me.txtNumLectura = New System.Windows.Forms.Label()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.Panel1 = New System.Windows.Forms.StatusBarPanel()
        Me.GrdHeader1 = New AdmEdificios.grdHeader()
        Me.lnkSugerirInicial = New System.Windows.Forms.LinkLabel()
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LAnterior
        '
        Me.LAnterior.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LAnterior.Cliente = "txtClienteNum"
        Me.LAnterior.ConsumoLitros = ".000"
        Me.LAnterior.custBackColor = System.Drawing.Color.Gainsboro
        Me.LAnterior.Diferencia = ".000"
        Me.LAnterior.Enabled = False
        Me.LAnterior.FechaLecturaFinal = "Lect. Final"
        Me.LAnterior.FechaLecturaInicial = "Lect. Inicial"
        Me.LAnterior.ImporteConsumo = "$0.00"
        Me.LAnterior.ImporteTotalEditable = True
        Me.LAnterior.ImpuestoConsumo = "$0.00"
        Me.LAnterior.LecturaFinal = "0"
        Me.LAnterior.LecturaFinalEditable = True
        Me.LAnterior.LecturaInicial = "0"
        Me.LAnterior.LecturaInicialEditable = True
        Me.LAnterior.Location = New System.Drawing.Point(8, 168)
        Me.LAnterior.Name = "LAnterior"
        Me.LAnterior.NumeroInterior = "txtNumInterior"
        Me.LAnterior.PrecioPorLitro = New Decimal(New Integer() {0, 0, 0, 0})
        Me.LAnterior.Redondeo = New Decimal(New Integer() {0, 0, 0, 0})
        Me.LAnterior.RedondeoActivo = False
        Me.LAnterior.RedondeoPorAplicar = New Decimal(New Integer() {0, 0, 0, 0})
        Me.LAnterior.Size = New System.Drawing.Size(940, 21)
        Me.LAnterior.TabIndex = 0
        Me.LAnterior.TotalConsumo = "Total $"
        '
        'cDatosCliente
        '
        Me.cDatosCliente.AddressForeColor = System.Drawing.SystemColors.WindowText
        Me.cDatosCliente.AmountForeColor = System.Drawing.Color.Crimson
        Me.cDatosCliente.ContratoNombre = "Contrato:                    Contrato:                    Contrato:              " & _
        "      Contrato:                    Contrato:                    Contrato:       " & _
        "             Contrato:                    Contrato:                    Contrato:" & _
        "                    Contrato:                    Contrato:                    Co" & _
        "ntrato:                    Contrato:                    Contrato:               " & _
        "      xxx"
        Me.cDatosCliente.Direccion = "XXXXXXXXXXXXXX, XXXXXXXXX, XXXXX"
        Me.cDatosCliente.FUltimoSurtido = "XX/XX/XXXX"
        Me.cDatosCliente.LastSForeColor = System.Drawing.Color.Blue
        Me.cDatosCliente.Location = New System.Drawing.Point(8, 8)
        Me.cDatosCliente.Name = "cDatosCliente"
        Me.cDatosCliente.PhoneForeColor = System.Drawing.Color.Maroon
        Me.cDatosCliente.Saldo = "XXXX"
        Me.cDatosCliente.Size = New System.Drawing.Size(784, 80)
        Me.cDatosCliente.TabIndex = 2
        Me.cDatosCliente.Telefono = "XXXXXXXX"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 148)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(214, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Lectura antes del cambio de medidor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 208)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(230, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Lectura despues del cambio de medidor"
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(808, 24)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 23)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(808, 56)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 23)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lActual
        '
        Me.lActual.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lActual.Cliente = "txtClienteNum"
        Me.lActual.ConsumoLitros = "Consumo Lts."
        Me.lActual.custBackColor = System.Drawing.Color.Gainsboro
        Me.lActual.Diferencia = "Diferencia"
        Me.lActual.FactorConversion = New Decimal(New Integer() {0, 0, 0, 0})
        Me.lActual.FechaLecturaFinal = "Lect. Final"
        Me.lActual.FechaLecturaInicial = "Lect. Inicial"
        Me.lActual.ImporteConsumo = "Consumo $"
        Me.lActual.ImpuestoConsumo = "Impuesto $"
        Me.lActual.IVA = New Decimal(New Integer() {0, 0, 0, 0})
        Me.lActual.LecturaFinal = "0"
        Me.lActual.LecturaInicial = "0"
        Me.lActual.Location = New System.Drawing.Point(8, 232)
        Me.lActual.Name = "lActual"
        Me.lActual.NumeroInterior = "txtNumInterior"
        Me.lActual.PrecioPorLitro = New Decimal(New Integer() {0, 0, 0, 0})
        Me.lActual.RedondeoPorAplicar = New Decimal(New Integer() {0, 0, 0, 0})
        Me.lActual.Size = New System.Drawing.Size(940, 21)
        Me.lActual.TabIndex = 1
        Me.lActual.TotalConsumo = "Total $"
        '
        'txtNumLectura
        '
        Me.txtNumLectura.AutoSize = True
        Me.txtNumLectura.Location = New System.Drawing.Point(848, 148)
        Me.txtNumLectura.Name = "txtNumLectura"
        Me.txtNumLectura.Size = New System.Drawing.Size(37, 14)
        Me.txtNumLectura.TabIndex = 8
        Me.txtNumLectura.Text = "Label3"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 265)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.Panel1})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(958, 22)
        Me.StatusBar1.TabIndex = 9
        Me.StatusBar1.Text = "stbCambioMedidor"
        '
        'Panel1
        '
        Me.Panel1.Width = 880
        '
        'GrdHeader1
        '
        Me.GrdHeader1.Location = New System.Drawing.Point(8, 96)
        Me.GrdHeader1.Name = "GrdHeader1"
        Me.GrdHeader1.Size = New System.Drawing.Size(940, 48)
        Me.GrdHeader1.TabIndex = 10
        '
        'lnkSugerirInicial
        '
        Me.lnkSugerirInicial.Location = New System.Drawing.Point(248, 207)
        Me.lnkSugerirInicial.Name = "lnkSugerirInicial"
        Me.lnkSugerirInicial.Size = New System.Drawing.Size(168, 16)
        Me.lnkSugerirInicial.TabIndex = 0
        Me.lnkSugerirInicial.TabStop = True
        Me.lnkSugerirInicial.Text = "Consultar lectura inicial sugerida"
        '
        'frmCambioMedidor
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(958, 287)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lnkSugerirInicial, Me.GrdHeader1, Me.StatusBar1, Me.txtNumLectura, Me.Label2, Me.Label1, Me.lActual, Me.btnAceptar, Me.btnCancelar, Me.cDatosCliente, Me.LAnterior})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCambioMedidor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de lectura por cambio de medidor"
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmCambioMedidor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim detalleLecturaAnterior As DataTable
        Dim statusLecturaAnterior As String

        datosCliente = New cLecturaClienteHijo(connection, _Cliente)
        detalleLecturaAnterior = datosCliente.DetalleUltimaLecturaClienteHijo

        cDatosCliente.ContratoNombre = CStr(datosCliente.Cliente) & " - " & datosCliente.Nombre
        cDatosCliente.Direccion = datosCliente.Direccion
        cDatosCliente.Telefono = datosCliente.Telefono
        cDatosCliente.Saldo = CStr(datosCliente.Saldo)
        cDatosCliente.FUltimoSurtido = CStr(datosCliente.FUltimoSuministro)

        'Lectura antes del cambio de medidor
        txtNumLectura.Text = CStr(detalleLecturaAnterior.Rows(0).Item("Lectura"))

        LAnterior.Cliente = CStr(detalleLecturaAnterior.Rows(0).Item("Cliente"))
        LAnterior.NumeroInterior = CStr(detalleLecturaAnterior.Rows(0).Item("NumInterior"))
        LAnterior.FechaLecturaInicial = CStr(detalleLecturaAnterior.Rows(0).Item("FLecturaAnterior"))
        LAnterior.FechaLecturaFinal = CStr(detalleLecturaAnterior.Rows(0).Item("FLectura"))
        LAnterior.LecturaInicial = CStr(detalleLecturaAnterior.Rows(0).Item("LecturaInicial"))
        LAnterior.LecturaFinal = CStr(detalleLecturaAnterior.Rows(0).Item("LecturaFinal"))
        LAnterior.Diferencia = CStr(detalleLecturaAnterior.Rows(0).Item("DiferenciaLectura"))
        LAnterior.ConsumoLitros = CStr(detalleLecturaAnterior.Rows(0).Item("ConsumoLitros"))
        LAnterior.ImporteConsumo = CStr(detalleLecturaAnterior.Rows(0).Item("Importe"))
        LAnterior.ImpuestoConsumo = CStr(detalleLecturaAnterior.Rows(0).Item("Impuesto"))
        LAnterior.TotalConsumo = CStr(detalleLecturaAnterior.Rows(0).Item("Total"))

        'Redondeo de lecturas
        LAnterior.Redondeo = CDec(detalleLecturaAnterior.Rows(0).Item("Redondeo"))

        statusLecturaAnterior = CStr(detalleLecturaAnterior.Rows(0).Item("Status"))
        _FechaLectura = CDate(detalleLecturaAnterior.Rows(0).Item("FLectura"))
        _ClientePadre = CInt(detalleLecturaAnterior.Rows(0).Item("ClientePadre"))

        'Lectura después del cambio de medidor
        'lActual.PrecioPorLitro = CDbl(LAnterior.TotalConsumo) / CDbl(LAnterior.ConsumoLitros)
        lActual.PrecioPorLitro = CDec(detalleLecturaAnterior.Rows(0).Item("Precio"))
        'lActual.FactorConversion = CDbl(LAnterior.ConsumoLitros) / CDbl(LAnterior.Diferencia)
        lActual.FactorConversion = CDec(detalleLecturaAnterior.Rows(0).Item("Factor"))
        'lActual.IVA = CDbl(LAnterior.ImpuestoConsumo) / CDbl(LAnterior.TotalConsumo)
        lActual.IVA = CDec(detalleLecturaAnterior.Rows(0).Item("%Impuesto"))

        GrdHeader1.PrecioLitro = "Precio: " & CStr(lActual.PrecioPorLitro)
        GrdHeader1.FactorConversion = "Factor: " & CStr(lActual.FactorConversion)
        GrdHeader1.IVA = "IVA: " & CStr(lActual.IVA)

        lActual.Cliente = CStr(detalleLecturaAnterior.Rows(0).Item("Cliente"))
        lActual.NumeroInterior = CStr(detalleLecturaAnterior.Rows(0).Item("NumInterior"))
        lActual.FechaLecturaInicial = CStr(detalleLecturaAnterior.Rows(0).Item("FLectura"))
        lActual.FechaLecturaFinal = CStr(detalleLecturaAnterior.Rows(0).Item("FLectura"))

        lActual.RedondeoPorAplicar = CDec(detalleLecturaAnterior.Rows(0).Item("Redondeo"))
        lActual.RedondeoActivo = _redondeoActivo

        If statusLecturaAnterior = "PROCESADO" Then
            Panel1.Text = "La lectura anterior ya fue procesada, solo puede capturar una lectura con diferencia en 0"
        End If

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            datosCliente.AltaLecturaDetalle(CInt(txtNumLectura.Text), CInt(lActual.Cliente), CDbl(lActual.LecturaInicial), CDbl(lActual.LecturaFinal), _
                CDbl(lActual.Diferencia), CDbl(lActual.ConsumoLitros), CDbl(lActual.ImporteConsumo), CDbl(lActual.ImpuestoConsumo), _
                CDbl(lActual.TotalConsumo), CDbl(lActual.Redondeo), CDbl(lActual.RedondeoPorAplicar), 2)
            Windows.Forms.MessageBox.Show("Se ha registrado la lectura por cambio de medidor", _
                "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Information)
            Me.Close()
            imprimirReporte()
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, _
                        "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub imprimirReporte()
        Dim config As New SigaMetClasses.cConfig(1, _corporativo, _sucursal)
        Dim rutaReportes As String
        rutaReportes = CType(config.Parametros.Item("RutaReportes"), String)
        Dim frmReporte As New frmConsultaReporte(connection, _ClientePadre, _FechaLectura, rutaReportes)
        frmReporte.ShowDialog()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    'Si la lectura ya está procesada solo permitir capturar lecturas con diferencia = 0
    '
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    'Private Sub lactual_click() Handles lActual.validating
    '    Dim frmAjuste As New frmConsumoPromedio(connection, _Cliente)
    '    If frmAjuste.ShowDialog = Windows.Forms.DialogResult.OK Then
    '        _ConsumoSugerido = frmAjuste.ConsumoAproximado
    '        lActual.LecturaInicial = CStr(CDbl(lActual.LecturaFinal) - _ConsumoSugerido)
    '        lActual.recalcular(lActual.PrecioPorLitro)
    '    End If
    'End Sub

    Private Sub btnConsultarSugerido_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkSugerirInicial.Click
        Dim cConsumoPromedio As New cLecturaClienteHijo(connection, _Cliente), _
            frmAjuste As frmConsumoPromedio

        If cConsumoPromedio.ConsumoPromedio.Rows.Count > 0 Then
            frmAjuste = New frmConsumoPromedio(cConsumoPromedio.ConsumoPromedio)
        Else
            Windows.Forms.MessageBox.Show("No hay periodos con consumo regular," & _
                                          "no se puede sugerir un valor inicial", "Consumo sugerido", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If frmAjuste.ShowDialog = Windows.Forms.DialogResult.OK Then
            _ConsumoSugerido = frmAjuste.ConsumoAproximado
            lActual.LecturaInicial = CStr(CDbl(lActual.LecturaFinal) - _ConsumoSugerido)
            lActual.recalcular(lActual.PrecioPorLitro)
        End If
    End Sub


End Class

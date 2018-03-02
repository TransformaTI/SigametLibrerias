Option Strict On
Imports System.Windows.Forms
Public Class rowClienteHijo
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
    End Sub

    Public Sub New(ByVal FactorDeConversion As Decimal, ByVal PrecioPorLitro As Decimal, ByVal Impuesto As Short)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _factorDeConversion = FactorDeConversion
        _precioPorLitro = PrecioPorLitro
        _impuesto = Impuesto
    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents txtFLecturaIni As System.Windows.Forms.TextBox
    Friend WithEvents txtNumInterior As System.Windows.Forms.TextBox
    Friend WithEvents txtDiferencia As System.Windows.Forms.TextBox
    Friend WithEvents txtImpConsumo As System.Windows.Forms.TextBox
    Friend WithEvents txtFLecturaFin As System.Windows.Forms.TextBox
    Friend WithEvents txtConsumoLts As System.Windows.Forms.TextBox
    Friend WithEvents txtClienteNum As System.Windows.Forms.TextBox
    Friend WithEvents txtLecturaIni As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtLecturaFin As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtIVA As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtRedondeo As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtFLecturaIni = New System.Windows.Forms.TextBox()
        Me.txtNumInterior = New System.Windows.Forms.TextBox()
        Me.txtDiferencia = New System.Windows.Forms.TextBox()
        Me.txtImpConsumo = New System.Windows.Forms.TextBox()
        Me.txtFLecturaFin = New System.Windows.Forms.TextBox()
        Me.txtConsumoLts = New System.Windows.Forms.TextBox()
        Me.txtClienteNum = New System.Windows.Forms.TextBox()
        Me.txtLecturaIni = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtLecturaFin = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtIVA = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtRedondeo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtFLecturaIni
        '
        Me.txtFLecturaIni.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFLecturaIni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFLecturaIni.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFLecturaIni.Location = New System.Drawing.Point(160, 0)
        Me.txtFLecturaIni.Name = "txtFLecturaIni"
        Me.txtFLecturaIni.ReadOnly = True
        Me.txtFLecturaIni.Size = New System.Drawing.Size(80, 21)
        Me.txtFLecturaIni.TabIndex = 2
        Me.txtFLecturaIni.TabStop = False
        Me.txtFLecturaIni.Text = "Lect. Inicial"
        Me.txtFLecturaIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNumInterior
        '
        Me.txtNumInterior.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtNumInterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumInterior.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumInterior.Location = New System.Drawing.Point(80, 0)
        Me.txtNumInterior.Name = "txtNumInterior"
        Me.txtNumInterior.ReadOnly = True
        Me.txtNumInterior.Size = New System.Drawing.Size(80, 21)
        Me.txtNumInterior.TabIndex = 9
        Me.txtNumInterior.TabStop = False
        Me.txtNumInterior.Text = "txtNumInterior"
        Me.txtNumInterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDiferencia
        '
        Me.txtDiferencia.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDiferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiferencia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiferencia.Location = New System.Drawing.Point(480, 0)
        Me.txtDiferencia.Name = "txtDiferencia"
        Me.txtDiferencia.ReadOnly = True
        Me.txtDiferencia.Size = New System.Drawing.Size(80, 21)
        Me.txtDiferencia.TabIndex = 12
        Me.txtDiferencia.TabStop = False
        Me.txtDiferencia.Text = "Diferencia"
        Me.txtDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtImpConsumo
        '
        Me.txtImpConsumo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtImpConsumo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImpConsumo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImpConsumo.Location = New System.Drawing.Point(640, 0)
        Me.txtImpConsumo.Name = "txtImpConsumo"
        Me.txtImpConsumo.ReadOnly = True
        Me.txtImpConsumo.Size = New System.Drawing.Size(80, 21)
        Me.txtImpConsumo.TabIndex = 7
        Me.txtImpConsumo.TabStop = False
        Me.txtImpConsumo.Text = "Consumo $"
        Me.txtImpConsumo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFLecturaFin
        '
        Me.txtFLecturaFin.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFLecturaFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFLecturaFin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFLecturaFin.Location = New System.Drawing.Point(320, 0)
        Me.txtFLecturaFin.Name = "txtFLecturaFin"
        Me.txtFLecturaFin.Size = New System.Drawing.Size(80, 21)
        Me.txtFLecturaFin.TabIndex = 3
        Me.txtFLecturaFin.TabStop = False
        Me.txtFLecturaFin.Text = "Lect. Final"
        Me.txtFLecturaFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtConsumoLts
        '
        Me.txtConsumoLts.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtConsumoLts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConsumoLts.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConsumoLts.Location = New System.Drawing.Point(560, 0)
        Me.txtConsumoLts.Name = "txtConsumoLts"
        Me.txtConsumoLts.ReadOnly = True
        Me.txtConsumoLts.Size = New System.Drawing.Size(80, 21)
        Me.txtConsumoLts.TabIndex = 6
        Me.txtConsumoLts.TabStop = False
        Me.txtConsumoLts.Text = "Consumo Lts."
        Me.txtConsumoLts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtClienteNum
        '
        Me.txtClienteNum.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtClienteNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClienteNum.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClienteNum.Name = "txtClienteNum"
        Me.txtClienteNum.ReadOnly = True
        Me.txtClienteNum.Size = New System.Drawing.Size(80, 21)
        Me.txtClienteNum.TabIndex = 0
        Me.txtClienteNum.TabStop = False
        Me.txtClienteNum.Text = "txtClienteNum"
        Me.txtClienteNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLecturaIni
        '
        Me.txtLecturaIni.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtLecturaIni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLecturaIni.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLecturaIni.Location = New System.Drawing.Point(240, 0)
        Me.txtLecturaIni.Name = "txtLecturaIni"
        Me.txtLecturaIni.ReadOnly = True
        Me.txtLecturaIni.Size = New System.Drawing.Size(80, 21)
        Me.txtLecturaIni.TabIndex = 0
        Me.txtLecturaIni.TabStop = False
        Me.txtLecturaIni.Text = "0"
        Me.txtLecturaIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLecturaFin
        '
        Me.txtLecturaFin.BackColor = System.Drawing.Color.Gainsboro
        Me.txtLecturaFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLecturaFin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLecturaFin.Location = New System.Drawing.Point(400, 0)
        Me.txtLecturaFin.Name = "txtLecturaFin"
        Me.txtLecturaFin.Size = New System.Drawing.Size(80, 21)
        Me.txtLecturaFin.TabIndex = 1
        Me.txtLecturaFin.Text = "0"
        Me.txtLecturaFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIVA
        '
        Me.txtIVA.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIVA.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIVA.Location = New System.Drawing.Point(720, 0)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.ReadOnly = True
        Me.txtIVA.Size = New System.Drawing.Size(80, 21)
        Me.txtIVA.TabIndex = 14
        Me.txtIVA.TabStop = False
        Me.txtIVA.Text = "Impuesto $"
        Me.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.Gainsboro
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(800, 0)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(80, 21)
        Me.txtTotal.TabIndex = 15
        Me.txtTotal.TabStop = False
        Me.txtTotal.Text = "Total $"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRedondeo
        '
        Me.txtRedondeo.BackColor = System.Drawing.Color.Gainsboro
        Me.txtRedondeo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRedondeo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRedondeo.Location = New System.Drawing.Point(880, 0)
        Me.txtRedondeo.Name = "txtRedondeo"
        Me.txtRedondeo.ReadOnly = True
        Me.txtRedondeo.Size = New System.Drawing.Size(60, 21)
        Me.txtRedondeo.TabIndex = 16
        Me.txtRedondeo.TabStop = False
        Me.txtRedondeo.Text = "Redondeo $"
        Me.txtRedondeo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'rowClienteHijo
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtRedondeo, Me.txtTotal, Me.txtIVA, Me.txtLecturaFin, Me.txtLecturaIni, Me.txtDiferencia, Me.txtNumInterior, Me.txtImpConsumo, Me.txtConsumoLts, Me.txtFLecturaFin, Me.txtFLecturaIni, Me.txtClienteNum})
        Me.Name = "rowClienteHijo"
        Me.Size = New System.Drawing.Size(940, 21)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _precioPorLitro As Decimal
    '01/02/2006 redondeo de lecturas
    Private _redondeoActivo As Boolean = False
    Private _redondeoPorAplicar As Decimal
    Private _redondeo As Decimal
    '***
    Dim _factorDeConversion As Decimal
    Dim _impuesto As Short
    Dim _backColor As System.Drawing.Color = System.Drawing.Color.Gainsboro

    Public Property Cliente() As String
        Get
            Return txtClienteNum.Text
        End Get
        Set(ByVal Value As String)
            txtClienteNum.Text = Value
        End Set
    End Property

    Public Property NumeroInterior() As String
        Get
            Return txtNumInterior.Text
        End Get
        Set(ByVal Value As String)
            txtNumInterior.Text = Value
        End Set
    End Property

    Public Property FechaLecturaInicial() As String
        Get
            Return txtFLecturaIni.Text
        End Get
        Set(ByVal Value As String)
            txtFLecturaIni.Text = Value
        End Set
    End Property

    Public Property LecturaInicial() As String
        Get
            Return txtLecturaIni.Text
        End Get
        Set(ByVal Value As String)
            txtLecturaIni.Text = Value
        End Set
    End Property

    Public Property LecturaFinal() As String
        Get
            Return txtLecturaFin.Text
        End Get
        Set(ByVal Value As String)
            txtLecturaFin.Text = Value
        End Set
    End Property

    Public Property FechaLecturaFinal() As String
        Get
            Return txtFLecturaFin.Text
        End Get
        Set(ByVal Value As String)
            txtFLecturaFin.Text = Value
        End Set
    End Property

    Public Property Diferencia() As String
        Get
            Return txtDiferencia.Text
        End Get
        Set(ByVal Value As String)
            txtDiferencia.Text = Value
        End Set
    End Property

    Public Property ConsumoLitros() As String
        Get
            Return txtConsumoLts.Text
        End Get
        Set(ByVal Value As String)
            txtConsumoLts.Text = Value
        End Set
    End Property

    Public Property PrecioPorLitro() As Decimal
        Get
            Return _precioPorLitro
        End Get
        Set(ByVal Value As Decimal)
            _precioPorLitro = Value
        End Set
    End Property

    Public Property ImporteConsumo() As String
        Get
            Return txtImpConsumo.Text
        End Get
        Set(ByVal Value As String)
            txtImpConsumo.Text = Value
        End Set
    End Property

    Public Property ImpuestoConsumo() As String
        Get
            Return txtIVA.Text
        End Get
        Set(ByVal Value As String)
            txtIVA.Text = Value
        End Set
    End Property

    Public Property TotalConsumo() As String
        Get
            Return txtTotal.Text
        End Get
        Set(ByVal Value As String)
            txtTotal.Text = Value
        End Set
    End Property

    'TODO: Redondeo de lecturas
    Public Property RedondeoPorAplicar() As Decimal
        Get
            Return _redondeoPorAplicar
        End Get
        Set(ByVal Value As Decimal)
            _redondeoPorAplicar = Value
        End Set
    End Property

    Public Property Redondeo() As Decimal
        Get
            Return _redondeo
        End Get
        Set(ByVal Value As Decimal)
            txtRedondeo.Text = FormatCurrency(CType(Value, String), 2, TriState.True)
        End Set
    End Property

    Public Property RedondeoActivo() As Boolean
        Get
            Return _redondeoActivo
        End Get
        Set(ByVal Value As Boolean)
            _redondeoActivo = Value
        End Set
    End Property
    '*******
    Public Property LecturaInicialEditable() As Boolean
        Get
            Return txtLecturaIni.ReadOnly
        End Get
        Set(ByVal Value As Boolean)
            txtLecturaIni.ReadOnly = Not (Value)
            If Not (txtLecturaIni.ReadOnly) Then
                txtLecturaIni.TabStop = True
            End If
        End Set
    End Property

    Public Property LecturaFinalEditable() As Boolean
        Get
            Return txtLecturaFin.ReadOnly
        End Get
        Set(ByVal Value As Boolean)
            txtLecturaFin.ReadOnly = Not (Value)
            If Not (txtLecturaFin.ReadOnly) Then
                txtLecturaFin.TabStop = True
                AddHandler txtLecturaFin.Validating, AddressOf txtLecturaFin_Validating
            Else
                txtLecturaFin.TabStop = False
                calculaImporte(0, 0)
            End If
        End Set
    End Property

    Public Property ImporteTotalEditable() As Boolean
        Get
            Return txtTotal.ReadOnly
        End Get
        Set(ByVal Value As Boolean)
            txtTotal.ReadOnly = Not (Value)
            If Not (txtTotal.ReadOnly) Then
                txtTotal.TabStop = True
                AddHandler txtTotal.Validating, AddressOf txtTotal_Validating
                AddHandler txtLecturaFin.Validating, AddressOf txtLecturaFin_Validating2
                txtTotal.Text = "0"
            Else
                txtTotal.TabStop = False
                AddHandler txtLecturaFin.Validating, AddressOf txtLecturaFin_Validating
            End If
        End Set
    End Property

    Public Property custBackColor() As System.Drawing.Color
        Get
            Return (_backColor)
        End Get
        Set(ByVal Value As System.Drawing.Color)
            _backColor = Value
        End Set
    End Property

    Private Sub txtLecturaFin_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Len(Trim(txtLecturaFin.Text)) > 0 Then
            If CType(txtLecturaFin.Text, Double) < CType(txtLecturaIni.Text, Double) Then
                txtLecturaFin.BackColor = System.Drawing.Color.LightYellow
                MessageBox.Show("La lectura final debe ser mayor a la inicial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtLecturaFin.Focus()
            Else
                txtLecturaFin.BackColor = System.Drawing.Color.Gainsboro
                calculaImporte(CType(txtLecturaFin.Text, Decimal), CType(txtLecturaIni.Text, Decimal))
            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Public Sub calculaImporte(ByVal LecturaFinal As Decimal, ByVal LecturaInicial As Decimal)
        Dim diferencia, consumoLts, total, importe, impuesto As Decimal
        diferencia = LecturaFinal - LecturaInicial
        consumoLts = diferencia * _factorDeConversion
        total = consumoLts * _precioPorLitro
        'TODO: Redondeo de lecturas, ¿Se parametriza?
        If total > 0 Then
            total += _redondeoPorAplicar
        End If

        If _redondeoActivo Then
            _redondeo = total - Decimal.Floor(total)
            total = total - _redondeo
        End If
        '****
        importe = CDec(total / ((_impuesto / 100) + 1))
        impuesto = total - importe

        txtDiferencia.Text = Format(diferencia, "#.000")
        txtConsumoLts.Text = Format(consumoLts, "#.000")
        txtImpConsumo.Text = FormatCurrency(CType(importe, String), 2, TriState.True)
        txtIVA.Text = FormatCurrency(CType(impuesto, String), 2, TriState.True)
        txtTotal.Text = FormatCurrency(CType(total, String), 2, TriState.True)
        txtRedondeo.Text = FormatCurrency(CType(Redondeo, String), 2, TriState.True)
    End Sub

    Private Sub txtLecturaIni_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLecturaIni.Enter
        txtLecturaIni.BackColor = System.Drawing.Color.AliceBlue
    End Sub

    Private Sub txtLecturaFin_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLecturaFin.Enter
        txtLecturaFin.BackColor = System.Drawing.Color.AliceBlue
    End Sub

    Public Sub recalcular(ByVal precioPorLitro As Decimal)
        _precioPorLitro = precioPorLitro
        calculaImporte(CType(txtLecturaFin.Text, Decimal), CType(txtLecturaIni.Text, Decimal))
    End Sub

    Public Sub calcularProrrateo(ByVal precioPorLitro As Double)
        If Len(Trim(txtTotal.Text)) = 0 OrElse Not (IsNumeric(txtTotal.Text)) Then
            txtTotal.Text = "0"
        End If
        Dim lectFinal, lectInicial, diferencia, consumoLts, total, importe, impuesto As Decimal
        diferencia = Nothing
        consumoLts = Nothing
        importe = Nothing
        impuesto = Nothing

        total = CDec(txtTotal.Text)
        lectFinal = CDec(txtLecturaFin.Text)
        lectInicial = lectFinal - (total / (_precioPorLitro * _factorDeConversion))
        calculaImporte(lectFinal, lectInicial)
        txtLecturaIni.Text = Format(lectInicial, "#.000")
        txtTotal.BackColor = System.Drawing.Color.Gainsboro
    End Sub

    Private Sub txtTotal_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        calcularProrrateo(_precioPorLitro)
    End Sub

    Private Sub txtTotal_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotal.Enter
        txtTotal.BackColor = System.Drawing.Color.AliceBlue
    End Sub

    Private Sub txtLecturaFin_Validating2(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        txtLecturaFin.BackColor = System.Drawing.Color.Gainsboro
    End Sub
End Class


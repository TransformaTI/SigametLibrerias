Public Class DocumentoCliente

    Public Sub New()
    End Sub

    Dim _tipoCobro As String
    Dim _tipoCargoTipoPedido As String
    Dim _statusPedido As String
    Dim _pedidoReferencia As String
    Dim _factura As String
    Dim _fCompromisoFecha As DateTime
    Dim _fCargoFecha As DateTime
    Dim _litros As Integer
    Dim _total As Decimal
    Dim _saldo As Decimal
    Dim _importeAbono As Decimal
    Dim _statusCobranza As String

    Dim _sePermiteAbonar As Boolean

    Dim _valeCredito As String
    Dim _cartera As Byte
    Dim _pedidoEdifico As Boolean

    Dim _observaciones As String

    Public Property TipoCobro() As String
        Get
            Return _tipoCobro
        End Get
        Set(ByVal Value As String)
            _tipoCobro = Value
        End Set
    End Property

    Public Property TipoCargoTipoPedido() As String
        Get
            Return _tipoCargoTipoPedido
        End Get
        Set(ByVal Value As String)
            _tipoCargoTipoPedido = Value
        End Set
    End Property

    Public Property StatusPedido() As String
        Get
            Return _statusPedido
        End Get
        Set(ByVal Value As String)
            _statusPedido = Value
        End Set
    End Property

    Public Property PedidoReferencia() As String
        Get
            Return _pedidoReferencia
        End Get
        Set(ByVal Value As String)
            _pedidoReferencia = Value
        End Set
    End Property

    Public Property Factura() As String
        Get
            Return _factura
        End Get
        Set(ByVal Value As String)
            _factura = Value
        End Set
    End Property

    Public Property FCompromisoFecha() As DateTime
        Get
            Return _fCompromisoFecha
        End Get
        Set(ByVal Value As DateTime)
            _fCompromisoFecha = Value
        End Set
    End Property

    Public Property FCargoFecha() As DateTime
        Get
            Return _fCargoFecha
        End Get
        Set(ByVal Value As DateTime)
            _fCargoFecha = Value
        End Set
    End Property

    Public Property Litros() As Integer
        Get
            Return _litros
        End Get
        Set(ByVal Value As Integer)
            _litros = Value
        End Set
    End Property

    Public Property Total() As Decimal
        Get
            Return _total
        End Get
        Set(ByVal Value As Decimal)
            _total = Value
        End Set
    End Property

    Public Property Saldo() As Decimal
        Get
            Return _saldo
        End Get
        Set(ByVal Value As Decimal)
            _saldo = Value
        End Set
    End Property

    Public Property ImporteAbono() As Decimal
        Get
            Return _importeAbono
        End Get
        Set(ByVal Value As Decimal)

        End Set
    End Property

    Public Property StatusCobranza() As String
        Get
            Return _statusCobranza
        End Get
        Set(ByVal Value As String)
            _statusCobranza = Value
        End Set
    End Property

    Public Property SePermiteAbonar() As Boolean
        Get
            Return _sePermiteAbonar
        End Get
        Set(ByVal Value As Boolean)
            _sePermiteAbonar = Value
        End Set
    End Property

    Public Property ValeCredito() As String
        Get
            Return _valeCredito
        End Get
        Set(ByVal Value As String)
            _valeCredito = Value
        End Set
    End Property

    Public Property Cartera() As Byte
        Get
            Return _cartera
        End Get
        Set(ByVal Value As Byte)
            _cartera = Value
        End Set
    End Property

    Public Property PedidoEdificio() As Boolean
        Get
            Return _pedidoEdifico
        End Get
        Set(ByVal Value As Boolean)
            _pedidoEdifico = Value
        End Set
    End Property

    'Public Property Observaciones() As String
    '    Get
    '        Return _observaciones
    '    End Get
    '    Set(ByVal Value As String)
    '        _observaciones = Value
    '    End Set
    'End Property
End Class



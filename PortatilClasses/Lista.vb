Option Strict On
Option Explicit On 

Public MustInherit Class Lista

#Region "Class ListaProductoDetalle"
    Public Class ListaProductoDetalle
        Private _Producto As Integer
        Private _Descripcion As String
        Private _Cantidad As Integer
        Private _Kilos As Decimal
        Private _Precio As Decimal
        Private _Total As Decimal
        Private _Secuencia As Integer
        Private _Remision As String
        Private _FRemision As Date
        Private _DescuentoPdto As Decimal
        Private _litros As Decimal

        Property Producto() As Integer
            Get
                Return _Producto
            End Get
            Set(ByVal Value As Integer)
                _Producto = Value
            End Set
        End Property

        Property Descripcion() As String
            Get
                Return _Descripcion
            End Get
            Set(ByVal Value As String)
                _Descripcion = Value
            End Set
        End Property

        Property Cantidad() As Integer
            Get
                Return _Cantidad
            End Get
            Set(ByVal Value As Integer)
                _Cantidad = Value
            End Set
        End Property

        Property Kilos() As Decimal
            Get
                Return _Kilos
            End Get
            Set(ByVal Value As Decimal)
                _Kilos = Value
            End Set
        End Property

        Property Litros() As Decimal
            Get
                Return _litros
            End Get
            Set(ByVal Value As Decimal)
                _litros = Value
            End Set
        End Property

        Property Precio() As Decimal
            Get
                Return _Precio
            End Get
            Set(ByVal Value As Decimal)
                _Precio = Value
            End Set
        End Property

        Property Total() As Decimal
            Get
                Return _Total
            End Get
            Set(ByVal Value As Decimal)
                _Total = Value
            End Set
        End Property

        Property Secuencia() As Integer
            Get
                Return _Secuencia
            End Get
            Set(ByVal Value As Integer)
                _Secuencia = Value
            End Set
        End Property

        Property Remision() As String
            Get
                Return _Remision
            End Get
            Set(ByVal Value As String)
                _Remision = Value
            End Set
        End Property

        Property FRemision() As Date
            Get
                Return _FRemision
            End Get
            Set(ByVal Value As Date)
                _FRemision = Value
            End Set
        End Property

        Property DescuentoPdto() As Decimal
            Get
                Return _DescuentoPdto
            End Get
            Set(ByVal Value As Decimal)
                _DescuentoPdto = Value
            End Set
        End Property

        Sub New(ByVal Pto As Integer, ByVal Can As Integer, ByVal Kg As Decimal, ByVal Lt As Decimal)
            Producto = Pto
            Cantidad = Can
            Kilos = Kg
            Litros = Lt
        End Sub

        Sub New(ByVal Pto As Integer, ByVal Des As String, ByVal Can As Integer, ByVal Kg As Decimal)
            Producto = Pto
            Descripcion = Des
            Cantidad = Can
            Kilos = Kg
        End Sub

        Sub New(ByVal _Producto As Integer, ByVal _Descripcion As String, ByVal _Cantidad As Integer, _
        ByVal _Kilos As Decimal, ByVal _Precio As Decimal, ByVal _Total As Decimal, ByVal _Secuencia As Integer, _
        ByVal _Remision As String, ByVal _FRemision As Date)
            Producto = _Producto
            Descripcion = _Descripcion
            Cantidad = _Cantidad
            Kilos = _Kilos
            Precio = _Precio
            Total = _Total
            Secuencia = _Secuencia
            Remision = _Remision
            FRemision = _FRemision
        End Sub

        Sub New(ByVal _Producto As Integer, ByVal _Descripcion As String, ByVal _Cantidad As Integer, _
        ByVal _Kilos As Decimal, ByVal _Precio As Decimal, ByVal _Total As Decimal, ByVal _Secuencia As Integer, _
        ByVal _Remision As String, ByVal _FRemision As Date, ByVal _DescuentoPdto As Decimal)
            Producto = _Producto
            Descripcion = _Descripcion
            Cantidad = _Cantidad
            Kilos = _Kilos
            Precio = _Precio
            Total = _Total
            Secuencia = _Secuencia
            Remision = _Remision
            FRemision = _FRemision
            DescuentoPdto = _DescuentoPdto
        End Sub
    End Class
#End Region

#Region "Class ListaEmbarque"
    Public Class ListaEmbarque
        Private _Embarque As Integer
        Private _FEmbarque As Date
        Private _FRecepcion As Date
        Private _NEmbarque As String
        Private _CorporativoF As String
        Private _CorporativoD As String
        Private _Procedencia As String
        Private _Kgs As Decimal
        Private _Tanque As String

        Public Property Embarque() As Integer
            Get
                Return _Embarque
            End Get
            Set(ByVal Value As Integer)
                _Embarque = Value
            End Set
        End Property

        Public Property FEmbarque() As Date
            Get
                Return _FEmbarque
            End Get
            Set(ByVal Value As Date)
                _FEmbarque = Value
            End Set
        End Property

        Public Property FRecepcion() As Date
            Get
                Return _FRecepcion
            End Get
            Set(ByVal Value As Date)
                _FRecepcion = Value
            End Set
        End Property

        Public Property NEmbarque() As String
            Get
                Return _NEmbarque
            End Get
            Set(ByVal Value As String)
                _NEmbarque = Value
            End Set
        End Property

        Public Property CorporativoF() As String
            Get
                Return _CorporativoF
            End Get
            Set(ByVal Value As String)
                _CorporativoF = Value
            End Set
        End Property

        Public Property CorporativoD() As String
            Get
                Return _CorporativoD
            End Get
            Set(ByVal Value As String)
                _CorporativoD = Value
            End Set
        End Property

        Public Property Procedencia() As String
            Get
                Return _Procedencia
            End Get
            Set(ByVal Value As String)
                _Procedencia = Value
            End Set
        End Property

        Public Property Kgs() As Decimal
            Get
                Return _Kgs
            End Get
            Set(ByVal Value As Decimal)
                _Kgs = Value
            End Set
        End Property

        Public Property Tanque() As String
            Get
                Return _Tanque
            End Get
            Set(ByVal Value As String)
                _Tanque = Value
            End Set
        End Property

        Public Sub New(ByVal IdEmbarque As Integer, ByVal FechaEmbarque As Date, ByVal FechaRecepcion As Date, _
        ByVal NumeroEmbarque As String, ByVal EmpresaFacturar As String, ByVal EmpresaDestino As String, _
        ByVal LugarProcedencia As String, ByVal Peso As Decimal, ByVal TanqueDestino As String)
            Embarque = IdEmbarque
            FEmbarque = FechaEmbarque
            FRecepcion = FechaRecepcion
            NEmbarque = NumeroEmbarque
            CorporativoF = EmpresaFacturar
            CorporativoD = EmpresaDestino
            Procedencia = LugarProcedencia
            Kgs = Peso
            Tanque = TanqueDestino
        End Sub

    End Class
#End Region

#Region "Class ListaPrecios"
    Public Class ListaPrecios
        Private _Producto As Integer
        Private _Secuencia As Integer
        Private _Precio As Decimal
        Private _Descuento As Decimal

        Property Producto() As Integer
            Get
                Return _Producto
            End Get
            Set(ByVal Value As Integer)
                _Producto = Value
            End Set
        End Property

        Property Secuencia() As Integer
            Get
                Return _Secuencia
            End Get
            Set(ByVal Value As Integer)
                _Secuencia = Value
            End Set
        End Property

        Property Precio() As Decimal
            Get
                Return _Precio
            End Get
            Set(ByVal Value As Decimal)
                _Precio = Value
            End Set
        End Property

        Property Descuento() As Decimal
            Get
                Return _Descuento
            End Get
            Set(ByVal Value As Decimal)
                _Descuento = Value
            End Set
        End Property

        Sub New(ByVal _Producto As Integer, ByVal _Secuencia As Integer, ByVal _Precio As Decimal)
            Producto = _Producto
            Secuencia = _Secuencia
            Precio = _Precio
            Descuento = 0
        End Sub

        Sub New(ByVal _Producto As Integer, ByVal _Secuencia As Integer, ByVal _Precio As Decimal, ByVal _Descuento As Decimal)
            Producto = _Producto
            Secuencia = _Secuencia
            Precio = _Precio
            Descuento = _Descuento
        End Sub
    End Class
#End Region

#Region "Class cMedicionPCFlujo"
    Public Class cMedicionPCFlujo
        Private _FHMedicion As DateTime
        Private _Volumen As Decimal
        Private _Masa As Decimal
        Private _Densidad As Decimal
        Private _Presion As Decimal
        Private _Temperatura As Decimal
        Private _TasaVol As Decimal
        Private _TasaMasa As Decimal

        Public Property FHMedicion() As DateTime
            Get
                Return _FHMedicion
            End Get
            Set(ByVal Value As DateTime)
                _FHMedicion = Value
            End Set
        End Property

        Public Property Volumen() As Decimal
            Get
                Return _Volumen
            End Get
            Set(ByVal Value As Decimal)
                _Volumen = Value
            End Set
        End Property

        Public Property Masa() As Decimal
            Get
                Return _Masa
            End Get
            Set(ByVal Value As Decimal)
                _Masa = Value
            End Set
        End Property

        Public Property Densidad() As Decimal
            Get
                Return _Densidad
            End Get
            Set(ByVal Value As Decimal)
                _Densidad = Value
            End Set
        End Property

        Public Property Presion() As Decimal
            Get
                Return _Presion
            End Get
            Set(ByVal Value As Decimal)
                _Presion = Value
            End Set
        End Property

        Public Property Temperatura() As Decimal
            Get
                Return _Temperatura
            End Get
            Set(ByVal Value As Decimal)
                _Temperatura = Value
            End Set
        End Property

        Public Property TasaVol() As Decimal
            Get
                Return _TasaVol
            End Get
            Set(ByVal Value As Decimal)
                _TasaVol = Value
            End Set
        End Property

        Public Property TasaMasa() As Decimal
            Get
                Return _TasaMasa
            End Get
            Set(ByVal Value As Decimal)
                _TasaMasa = Value
            End Set
        End Property

        Public Sub New(ByVal pFHMedicion As DateTime, ByVal pVolumen As Decimal, ByVal pMasa As Decimal, _
        ByVal pDensidad As Decimal, ByVal pPresion As Decimal, ByVal pTemperatura As Decimal, ByVal pTasaVol As Decimal, _
        ByVal pTasaMasa As Decimal)
            _FHMedicion = pFHMedicion
            _Volumen = pVolumen
            _Masa = pMasa
            _Densidad = pDensidad
            _Presion = pPresion
            _Temperatura = pTemperatura
            _TasaVol = pTasaVol
            _TasaMasa = pTasaMasa
        End Sub

    End Class
#End Region

#Region "Class ListaComisionista"
    Public Class ListaComisionista
        Private _Cantidad As String
        Private _Producto As String
        Private _Descripcion As String
        Private _Precio As String
        Private _Costo As String
        Private _Descuento1 As String
        Private _Descuento1Total As String
        Private _Descuento2 As String
        Private _Descuento2Total As String
        Private _TotalDescuentos As String
        Private _IVA As String
        Private _Total As String
        Private _Kilos As String
        Private _Incentivo As String

        Property Cantidad() As String
            Get
                Return CType(_Cantidad, String)
            End Get
            Set(ByVal Value As String)
                _Cantidad = Value
            End Set
        End Property

        Property Producto() As String
            Get
                Return CType(_Producto, String)
            End Get
            Set(ByVal Value As String)
                _Producto = Value
            End Set
        End Property

        Property Descripcion() As String
            Get
                Return _Descripcion
            End Get
            Set(ByVal Value As String)
                _Descripcion = Value
            End Set
        End Property

        Property Precio() As String
            Get
                Return CType(_Precio, String)
            End Get
            Set(ByVal Value As String)
                _Precio = Value
            End Set
        End Property

        Property Costo() As String
            Get
                Return CType(_Costo, String)
            End Get
            Set(ByVal Value As String)
                _Costo = Value
            End Set
        End Property

        Property Descuento1() As String
            Get
                Return CType(_Descuento1, String)
            End Get
            Set(ByVal Value As String)
                _Descuento1 = Value
            End Set
        End Property

        Property Descuento1Total() As String
            Get
                Return CType(_Descuento1Total, String)
            End Get
            Set(ByVal Value As String)
                _Descuento1Total = Value
            End Set
        End Property

        Property Descuento2() As String
            Get
                Return CType(_Descuento2, String)
            End Get
            Set(ByVal Value As String)
                _Descuento2 = Value
            End Set
        End Property

        Property Descuento2Total() As String
            Get
                Return CType(_Descuento2Total, String)
            End Get
            Set(ByVal Value As String)
                _Descuento2Total = Value
            End Set
        End Property

        Property TotalDescuentos() As String
            Get
                Return CType(_TotalDescuentos, String)
            End Get
            Set(ByVal Value As String)
                _TotalDescuentos = Value
            End Set
        End Property

        Property Iva() As String
            Get
                Return CType(_IVA, String)
            End Get
            Set(ByVal Value As String)
                _IVA = Value
            End Set
        End Property

        Property Total() As String
            Get
                Return CType(_Total, String)
            End Get
            Set(ByVal Value As String)
                _Total = Value
            End Set
        End Property

        Property Kilos() As String
            Get
                Return CType(_Kilos, String)
            End Get
            Set(ByVal Value As String)
                _Kilos = Value
            End Set
        End Property

        Property Incentivos() As String
            Get
                Return CType(_Incentivo, String)
            End Get
            Set(ByVal Value As String)
                _Incentivo = Value
            End Set
        End Property

        Sub New(ByVal _CantidadP As Integer, ByVal _ProductoP As Integer, ByVal _DescripcionP As String, ByVal _PrecioP As Decimal, ByVal _CostoP As Decimal, ByVal _Descuento1P As Decimal, _
        ByVal _Descuento1TotalP As Decimal, ByVal _Descuento2P As Decimal, ByVal _Descuento2TotalP As Decimal, ByVal _TotalDescuentosP As Decimal, ByVal _IVAP As Decimal, ByVal _TotalP As Decimal, _
        ByVal _KilosP As Decimal, ByVal _Incentivos As Decimal)
            _Cantidad = CType(_CantidadP, String)
            _Producto = CType(_ProductoP, String)
            _Descripcion = _DescripcionP
            _Precio = CType(_PrecioP, String)
            _Costo = CType(_CostoP, String)
            _Descuento1 = CType(_Descuento1P, String)
            _Descuento1Total = CType(_Descuento1TotalP, String)
            _Descuento2 = CType(_Descuento2P, String)
            _Descuento2Total = CType(_Descuento2TotalP, String)
            _TotalDescuentos = CType(_TotalDescuentosP, String)
            _IVA = CType(_IVAP, String)
            _Total = CType(_TotalP, String)
            _Kilos = CType(_KilosP, String)
            _Incentivo = CType(_Incentivos, String)
        End Sub

    End Class
#End Region

End Class

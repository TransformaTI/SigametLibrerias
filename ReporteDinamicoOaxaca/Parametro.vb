Public Class cParametro

    Private _Valor As String
    Private _EsFechaAMotrar As Boolean
    Private _ComboTipo As Short  '1 corporativo, 2 celula, 3 almacen, 4 sucursal
    Private _Visible As Boolean
    Private _ValorDefault As Integer

    Public Property Valor() As String
        Get
            Return _Valor
        End Get
        Set(ByVal Value As String)
            _Valor = Value
        End Set
    End Property

    Public Property EsFechaAMostrar() As Boolean
        Get
            Return _EsFechaAMotrar
        End Get
        Set(ByVal Value As Boolean)
            _EsFechaAMotrar = Value
        End Set
    End Property

    Public Property ComboTipo() As Short
        Get
            Return _ComboTipo
        End Get
        Set(ByVal Value As Short)
            _ComboTipo = Value
        End Set
    End Property

    Public Property Visible() As Boolean
        Get
            Return _Visible
        End Get
        Set(ByVal Value As Boolean)
            _Visible = Value
        End Set
    End Property

    Public Property ValorDefault() As Integer
        Get
            Return _ValorDefault
        End Get
        Set(ByVal Value As Integer)
            _ValorDefault = Value
        End Set
    End Property

    Sub New(ByVal ValorParametro As String, ByVal ParametroEsFechaAMostrar As Boolean, _
    Optional ByVal ParametroComboTipo As Short = 0, Optional ByVal ParametroVisible As Boolean = False, _
    Optional ByVal ValDefault As Integer = 0)
        Valor = ValorParametro
        EsFechaAMostrar = ParametroEsFechaAMostrar
        ComboTipo = ParametroComboTipo
        Visible = ParametroVisible
        ValorDefault = ValDefault
        If ParametroComboTipo > 0 Then
            EsFechaAMostrar = True
        End If
    End Sub

End Class

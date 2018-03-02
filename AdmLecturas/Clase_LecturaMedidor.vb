Imports System.Collections
Imports System.Drawing
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms


Public Class Clase_LecturaMedidor
    Public Enum Tipo_Accion As Integer
        Ninguna = 0
        Registrada = 1
        Nuevo = 2
        Modificada = 3
        Eliminada = 4
    End Enum
#Region "Variables de la clase"
    Private _intLectura As Integer = 0
    Private _intCliente As Integer = 0
    Private _strEtiquetaId As String = ""
    Private _strNombre As String = ""
    Private _strTelCasa As String = ""
    Private _intCalle As Integer = 0
    Private _strCalle As String = ""
    Private _intColonia As Integer = 0
    Private _strColonia As String = ""
    Private _intMunicipio As Integer = 0
    Private _strMunicipio As String = ""
    Private _intNumExterior As Integer = 0
    Private _strNumInterior As String = ""
    Private _intConsecutivo As Integer = 0
    Private _dteFechaInicial As DateTime = DateTime.Now
    Private _dteFechaFinal As DateTime = DateTime.Now
    Private _decLecturaInicial As Decimal = 0
    Private _decLecturaFinal As Decimal = 0
    Private _decDiferenciaLectura As Decimal = 0
    Private _decConsumoLitros As Decimal = 0
    Private _decConsumoPromedio As Decimal = 0
    Private _sinImporte As Single = 0
    Private _sinImpuesto As Single = 0
    Private _sinTotal As Single = 0
    Private _sinRedondeo As Single = 0
    Private _sinRedondeoAplicado As Single = 0
    Private _sinSaldo As Single = 0
    Private _intMotivoNoLectura As Integer = 0
    Private _strMotivoNoLectura As String = ""
    Private _strImagen As String = ""
    Private _imgImagen As Image = Nothing
    Private _strStatus As String = 0
    Private _intNumeroImpresion As Integer = 0
    Private _Accion As Tipo_Accion = Tipo_Accion.Ninguna
#End Region
#Region "Constructor de la clase"
    Public Sub New(ByVal RutaPlantilla As String, ByVal LecturaMedidor As DataRow)
        Try
            Me._intLectura = Convert.ToInt32(LecturaMedidor("Lectura"))
            Me._intCliente = Convert.ToInt32(LecturaMedidor("Cliente"))
            Me._strEtiquetaId = Convert.ToString(LecturaMedidor("EtiquetaId"))
            Me._strNombre = Convert.ToString(LecturaMedidor("Nombre")).Trim()
            If (Convert.IsDBNull(LecturaMedidor("TelCasa"))) Then
                Me._strTelCasa = ""
            Else
                Me._strTelCasa = Convert.ToString(LecturaMedidor("TelCasa")).Trim()
            End If
            Me._intCalle = Convert.ToInt32(LecturaMedidor("Calle"))
            Me._strCalle = Convert.ToString(LecturaMedidor("CalleNombre")).Trim()
            Me._intColonia = Convert.ToInt32(LecturaMedidor("Colonia"))
            Me._strColonia = Convert.ToString(LecturaMedidor("ColoniaNombre")).Trim()
            Me._intMunicipio = Convert.ToInt32(LecturaMedidor("Municipio"))
            Me._strMunicipio = Convert.ToString(LecturaMedidor("MunicipioNombre")).Trim()
            Me._intNumExterior = Convert.ToInt32(LecturaMedidor("NumExterior"))
            Me._strNumInterior = Convert.ToString(LecturaMedidor("NumInterior")).Trim()
            Me._intConsecutivo = Convert.ToInt32(LecturaMedidor("Consecutivo"))
            If (Not Convert.IsDBNull(LecturaMedidor("FechaInicial"))) Then
                Me._dteFechaInicial = Convert.ToDateTime(LecturaMedidor("FechaInicial"))
            Else
                Me._dteFechaInicial = Convert.ToDateTime(LecturaMedidor("FechaFinal"))
            End If
            Me._dteFechaFinal = Convert.ToDateTime(LecturaMedidor("FechaFinal"))
            If (Not Convert.IsDBNull(LecturaMedidor("LecturaInicial"))) Then
                Me._decLecturaInicial = Convert.ToDecimal(LecturaMedidor("LecturaInicial"))
            Else
                Me._decLecturaInicial = 0
            End If

            If (Not Convert.IsDBNull(LecturaMedidor("LecturaFinal"))) Then
                Me._decLecturaFinal = Convert.ToDecimal(LecturaMedidor("LecturaFinal"))
            Else
                Me._decLecturaFinal = 0
            End If
            Me._decDiferenciaLectura = Convert.ToDecimal(LecturaMedidor("DiferenciaLectura"))
            Me._decConsumoLitros = Convert.ToDecimal(LecturaMedidor("ConsumoLitros"))
            If (Not Convert.IsDBNull(LecturaMedidor("ConsumoPromedio"))) Then
                Me._decConsumoPromedio = Convert.ToDecimal(LecturaMedidor("ConsumoPromedio"))
            Else
                Me._decConsumoPromedio = 0
            End If
            Me._sinImporte = Convert.ToSingle(LecturaMedidor("Importe"))
            Me._sinImpuesto = Convert.ToSingle(LecturaMedidor("Impuesto"))
            Me._sinTotal = Convert.ToSingle(LecturaMedidor("Total"))
            Me._sinRedondeo = Convert.ToSingle(LecturaMedidor("Redondeo"))
            Me._sinRedondeoAplicado = Convert.ToSingle(LecturaMedidor("RedondeoAplicado"))
            Me._sinSaldo = Convert.ToSingle(LecturaMedidor("Saldo"))
            If (Not Convert.IsDBNull(LecturaMedidor("MotivoNoLectura"))) Then
                Me._intMotivoNoLectura = Convert.ToInt32(LecturaMedidor("MotivoNoLectura"))
                Me._strMotivoNoLectura = Convert.ToString(LecturaMedidor("NombreMotivoNoLectura")).Trim()
            Else
                Me._intMotivoNoLectura = 0
                Me._strMotivoNoLectura = ""
            End If
            Me._strImagen = Convert.ToString(LecturaMedidor("Imagen")).Trim()
            If (Me._strImagen.Length > 0) Then
                Me._imgImagen = New ImagerDecoder.Clase_Imager_Decoder().String2Image(RutaPlantilla, Me._strImagen)
            Else
                Me._imgImagen = Nothing
            End If
            Me._strStatus = Convert.ToString(LecturaMedidor("Status"))
            If (Convert.IsDBNull(LecturaMedidor("NumeroImpresion"))) Then
                Me._intNumeroImpresion = 0
            Else
                Me._intNumeroImpresion = Convert.ToInt32(LecturaMedidor("NumeroImpresion"))
            End If
            Me._Accion = Tipo_Accion.Registrada
        Catch ex As Exception
            MessageBox.Show(ex.TargetSite.Name & vbCrLf & vbCrLf, "Clase Lectura Medidor...", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Throw ex
        End Try
    End Sub
#End Region
#Region "Propiedades de la clase"
    Public ReadOnly Property Lectura() As Integer
        Get
            Return Me._intLectura
        End Get
    End Property
    Public ReadOnly Property Cliente() As Integer
        Get
            Return Me._intCliente
        End Get
    End Property
    Public ReadOnly Property EtiquetaId() As String
        Get
            Return Me._strEtiquetaId
        End Get
    End Property
    Public ReadOnly Property Nombre() As String
        Get
            Return Me._strNombre
        End Get
    End Property
    Public ReadOnly Property TelCasa() As String
        Get
            Return Me._strTelCasa
        End Get
    End Property
    Public ReadOnly Property Calle() As Integer
        Get
            Return Me._intCalle
        End Get
    End Property
    Public ReadOnly Property CalleNombre() As String
        Get
            Return Me._strCalle
        End Get
    End Property
    Public ReadOnly Property Colonia() As Integer
        Get
            Return Me._intColonia
        End Get
    End Property
    Public ReadOnly Property ColoniaNombre() As String
        Get
            Return Me._strColonia
        End Get
    End Property
    Public ReadOnly Property Municipio() As Integer
        Get
            Return Me._intMunicipio
        End Get
    End Property
    Public ReadOnly Property MunicipioNombre() As String
        Get
            Return Me._strMunicipio
        End Get
    End Property
    Public ReadOnly Property NumExterior() As Integer
        Get
            Return Me._intNumExterior
        End Get
    End Property
    Public ReadOnly Property NumInterior() As String
        Get
            Return Me._strNumInterior
        End Get
    End Property
    Public ReadOnly Property Consecutivo() As Integer
        Get
            Return Me._intConsecutivo
        End Get
    End Property
    Public ReadOnly Property FechaInicial() As DateTime
        Get
            Return Me._dteFechaInicial
        End Get
    End Property
    Public ReadOnly Property FechaFinal() As DateTime
        Get
            Return Me._dteFechaFinal
        End Get
    End Property
    Public ReadOnly Property LecturaInicial() As Decimal
        Get
            Return Me._decLecturaInicial
        End Get
    End Property
    Public ReadOnly Property LecturaFinal() As Decimal
        Get
            Return Me._decLecturaFinal
        End Get
    End Property
    Public ReadOnly Property DiferenciaLectura() As Decimal
        Get
            Return Me._decDiferenciaLectura
        End Get
    End Property
    Public ReadOnly Property ConsumoLitros() As Decimal
        Get
            Return Me._decConsumoLitros
        End Get
    End Property
    Public ReadOnly Property ConsumoPromedio() As Decimal
        Get
            Return Me._decConsumoPromedio
        End Get
    End Property
    Public ReadOnly Property Importe() As Single
        Get
            Return Me._sinImporte
        End Get
    End Property
    Public ReadOnly Property Impuesto() As Single
        Get
            Return Me._sinImpuesto
        End Get
    End Property
    Public ReadOnly Property Total() As Single
        Get
            Return Me._sinTotal
        End Get
    End Property
    Public ReadOnly Property Redondeo() As Single
        Get
            Return Me._sinRedondeo
        End Get
    End Property
    Public ReadOnly Property RedondeoAplicado() As Single
        Get
            Return Me._sinRedondeoAplicado
        End Get
    End Property
    Public ReadOnly Property Saldo() As Single
        Get
            Return Me._sinSaldo
        End Get
    End Property
    Public ReadOnly Property MotivoNoLectura() As Integer
        Get
            Return Me._intMotivoNoLectura
        End Get
    End Property
    Public ReadOnly Property MotivoNoLecturaNombre() As String
        Get
            Return Me._strMotivoNoLectura
        End Get
    End Property
    Public ReadOnly Property Imagen() As String
        Get
            Return Me._strImagen
        End Get
    End Property
    Public ReadOnly Property Image() As Image
        Get
            Return Me._imgImagen
        End Get
    End Property
    Public ReadOnly Property Status() As String
        Get
            Return Me._strStatus
        End Get
    End Property
    Public ReadOnly Property NumeroImpresion() As Integer
        Get
            Return Me._intNumeroImpresion
        End Get
    End Property
    Public Property Accion() As Tipo_Accion
        Get
            Return Me._Accion
        End Get
        Set(ByVal Value As Tipo_Accion)
            Me._Accion = Value
        End Set
    End Property
#End Region
End Class
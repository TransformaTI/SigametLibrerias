Public Class Globales

#Region "Variables globales"
    Private Shared _singleton As Globales
    Private cn As SqlConnection
    Private _ModificarStatus As Boolean = True
    Private _DeshacerDepuracion As Boolean = False
#End Region

    'La sub New es pribada para poder implementar el singleton
    Private Sub New()

    End Sub

#Region "Funciones públicas"
    Public Shared Function GetInstance() As Globales
        If _singleton Is Nothing Then
            _singleton = New Globales()
        End If
        Return _singleton
    End Function
    Public Sub AbreConexion()
        If cn.State <> ConnectionState.Open Then
            cn.Open()
        End If
    End Sub
    Public Sub CierraConexion()
        If cn.State <> ConnectionState.Closed Then
            cn.Close()
        End If
    End Sub
    Public Sub ExMessage(ByVal ex As Exception)
        MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
#End Region
#Region "Propiedades"
    Property cnSigamet() As SqlConnection
        Get
            Return cn
        End Get
        Set(ByVal Value As SqlConnection)
            cn = Value
        End Set
    End Property
    Property ModificarStatus() As Boolean
        Get
            Return _ModificarStatus
        End Get
        Set(ByVal Value As Boolean)
            _ModificarStatus = Value
        End Set
    End Property
    Property DeshacerDepuracion() As Boolean
        Get
            Return _DeshacerDepuracion
        End Get
        Set(ByVal Value As Boolean)
            _DeshacerDepuracion = Value
        End Set
    End Property
#End Region
End Class





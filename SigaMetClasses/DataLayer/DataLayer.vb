Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections

Public Class DataLayer

    Private Shared inst As DataLayer

    Private connCollection As SortedList = New SortedList()

    Private Sub New()

    End Sub

    Shared ReadOnly Property Instancia() As DataLayer
        Get
            If inst Is Nothing Then
                inst = New DataLayer()
            End If
            Return inst
        End Get
    End Property

    Public Shared Sub InicializaConexion(ByVal Conexion As SqlConnection)
        Dim id As Integer = Process.GetCurrentProcess.Id
        If DataLayer.Instancia.connCollection.Contains(id) Then
            DataLayer.Instancia.connCollection(id) = Conexion
        Else
            DataLayer.Instancia.connCollection.Add(id, Conexion)
        End If
    End Sub
    Public Shared Sub InicializaConexion(ByVal CadenaConexion As String)
        Dim id As Integer = Process.GetCurrentProcess.Id
        If DataLayer.Instancia.connCollection.Contains(id) Then
            CType(DataLayer.Instancia.connCollection(id), SqlConnection).ConnectionString = CadenaConexion
        Else
            Dim sqlConn As New SqlConnection(CadenaConexion)
            DataLayer.Instancia.connCollection.Add(id, sqlConn)
        End If
    End Sub

    Shared ReadOnly Property Conexion() As SqlConnection
        Get
            Return CType(DataLayer.Instancia.connCollection(Process.GetCurrentProcess.Id), SqlConnection)
        End Get
    End Property

End Class

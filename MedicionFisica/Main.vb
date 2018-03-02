' Modifico: Claudia Aurora García Patiño
' Fecha: 31 de Julio del 2007
' Motivo: Se agregaron las operaciones 47 y 48
' Identificador de cambios: 20070731CAGP$002

Option Strict On
Option Explicit On 

Imports System.Windows.Forms
Imports System.IO
Imports System.Data.SqlClient

Module Main
    
    Public GLOBAL_Conexion As SqlConnection
    Public GLOBAL_Usuario As String
    Public GLOBAL_Password As String

    Public GLOBAL_RutaReportes As String
    Public GLOBAL_Celula As Byte
    Public GLOBAL_Empresa As Byte
    Public GLOBAL_Sucursal As Byte

    Public GLOBALOP_Titulo As String
    Public GLOBALOP_InventarioFisico As Boolean = False
    Public GLOBALOP_VerificarReporte As Boolean = False
    Public GLOBALOP_AprobarReporte As Boolean = False
    Public GLOBALOP_ReporteFisicoDiario As Boolean = False
    Public GLOBALOP_CapturarInvFisico As Boolean = False
    Public GLOBALOP_AgregarMedVerificadas As Boolean = False
    Public GLOBALOP_ConsultarInvFisico As Boolean = False
    Public GLOBALOP_CencelarMedInvFisico As Boolean = False
    Public GLOBALOP_ReporteFisicoMensual As Boolean = False


    Public GLOBAL_Cancelacion26 As Boolean = False
    Public GLOBAL_Cancelacion27 As Boolean = False
    Public GLOBAL_Cancelacion28 As Boolean = False
    Public GLOBAL_Cancelacion29 As Boolean = False
    Public GLOBAL_Cancelacion30 As Boolean = False
    Public GLOBAL_Cancelacion31 As Boolean = False
    Public GLOBAL_VerTodosAlmacenes As Boolean = False  'Operacion 32
    Public GLOBAL_CerrarMes As Boolean = False          'Operacion 47 '20070731CAGP$002
    Public GLOBAL_CancelarMes As Boolean = False        'Operacion 48 '20070731CAGP$002
    Public GLOBAL_RegistraCierre As Boolean = False     'Operacion 53

    Public Function CargarPrivilegios() As Boolean
        Dim sqlQuery As New SqlClient.SqlCommand()
        Dim daAcceso As New SqlClient.SqlDataAdapter()
        Dim dtOperaciones As New DataTable()
        Dim Rw As DataRow
        daAcceso.SelectCommand = sqlQuery
        sqlQuery.CommandText = "exec spSEGOperacionesUsuarioModulo " & GLOBAL_Usuario & "," & CType(16, String)
        sqlQuery.Connection = GLOBAL_Conexion
        Try
            daAcceso.Fill(dtOperaciones)
            If dtOperaciones.Rows.Count = 0 Then
                MessageBox.Show("El usuario no tiene privilegios para usar este módulo", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                sqlQuery.Connection.Close()
                Return False
            End If
            For Each Rw In dtOperaciones.Rows
                GLOBALOP_Titulo = CType(Rw(3), String)
                Select Case CInt(Rw(0).ToString())
                    Case 21
                        GLOBALOP_InventarioFisico = True
                    Case 22
                        GLOBALOP_VerificarReporte = True
                    Case 23
                        GLOBALOP_AprobarReporte = True
                    Case 24
                        GLOBALOP_ReporteFisicoDiario = True

                    Case 26
                        GLOBAL_Cancelacion26 = True
                    Case 27
                        GLOBAL_Cancelacion27 = True
                    Case 28
                        GLOBAL_Cancelacion28 = True
                    Case 29
                        GLOBAL_Cancelacion29 = True
                    Case 30
                        GLOBAL_Cancelacion30 = True
                    Case 31
                        GLOBAL_Cancelacion31 = True
                    Case 32
                        GLOBAL_VerTodosAlmacenes = True
                    Case 40
                        GLOBALOP_CapturarInvFisico = True
                    Case 41
                        GLOBALOP_AgregarMedVerificadas = True
                    Case 42
                        GLOBALOP_ConsultarInvFisico = True
                    Case 43
                        GLOBALOP_CencelarMedInvFisico = True
                    Case 44
                        GLOBALOP_ReporteFisicoMensual = True
                    Case 47
                        GLOBAL_CerrarMes = True
                    Case 48
                        GLOBAL_CancelarMes = True
                    Case 53
                        GLOBAL_RegistraCierre = True
                End Select
            Next
        Catch err As Exception
            MessageBox.Show("Ocurrió el siguiente error:" & Chr(13) & err.ToString, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        sqlQuery.Connection.Close()
        Return True
    End Function


End Module



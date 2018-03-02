Imports System.Data.SqlClient
Imports System.IO

Public Class GuiaEmbarqueMetodos : Inherits GuiaEmbarque

    Private Function ConvertirBytes() As Boolean
        Try
            Dim str As Stream
            str = File.OpenRead(Me._RutaArchivo)

            Dim bytesArchivos(CInt(str.Length)) As Byte
            str.Read(bytesArchivos, 0, bytesArchivos.Length)
            str.Flush()
            str.Close()

            _Archivo = bytesArchivos

            Return True
        Catch ex As Exception
            MessageBox.Show("El archivo PDF contiene el siguiente error: " + ex.Message, "Creando Archivo PDF", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function Guardar() As Boolean
        Dim altaExitosa As Boolean = False

        If ConvertirBytes() = False Then
            Return False
            Exit Function
        End If

        Try            
            If _Conexion.State = ConnectionState.Closed Then
                _Conexion.Open()
            End If

            Dim cmdGuia As SqlCommand = _Conexion.CreateCommand()

            cmdGuia.CommandText = "spAltaGuiaEmbarque"
            cmdGuia.CommandType = CommandType.StoredProcedure

            cmdGuia.Parameters.Clear()
            cmdGuia.Parameters.Add("@Embarque", SqlDbType.Int).Value = Me._Embarque
            cmdGuia.Parameters.Add("@Extension", SqlDbType.VarChar).Value = Me._Extension
            cmdGuia.Parameters.Add("@Archivo", SqlDbType.Image).Value = Me._Archivo
            cmdGuia.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Me._Usuario
            cmdGuia.Parameters.Add("@NombreArchivo", SqlDbType.VarChar).Value = Me._NombreArchivo

            cmdGuia.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            _Conexion.Close()
        End Try

        Return altaExitosa
    End Function

    Public Function Borrar() As Boolean
        Dim borradoExitosa As Boolean = False

        Try
            If _Conexion.State = ConnectionState.Closed Then
                _Conexion.Open()
            End If

            Dim cmdGuia As SqlCommand = _Conexion.CreateCommand()

            cmdGuia.CommandText = "spBorrarGuiaEmbarque"
            cmdGuia.CommandType = CommandType.StoredProcedure

            cmdGuia.Parameters.Clear()
            cmdGuia.Parameters.Add("@IdGuia", SqlDbType.Int).Value = Me._IdGuia
            cmdGuia.Parameters.Add("@Embarque", SqlDbType.Int).Value = Me._Embarque
            cmdGuia.Parameters.Add("@Extension", SqlDbType.VarChar).Value = Me._Extension

            cmdGuia.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        Finally
            _Conexion.Close()
        End Try

        Return borradoExitosa
    End Function

    Public Function Lectura() As List(Of GuiaEmbarqueMetodos)
        Dim lstGuiasEmbarque As New List(Of GuiaEmbarqueMetodos)

        Try
            If _Conexion.State = ConnectionState.Closed Then
                _Conexion.Open()
            End If

            Dim cmdGuia As SqlCommand = _Conexion.CreateCommand()
            Dim drGuias As SqlDataReader

            cmdGuia.CommandText = "spLecturaGuiaEmbarque"
            cmdGuia.CommandType = CommandType.StoredProcedure

            cmdGuia.Parameters.Clear()
            ''cmdGuia.Parameters.Add("@IdGuia", SqlDbType.Int).Value = Me._IdGuia
            cmdGuia.Parameters.Add("@Embarque", SqlDbType.Int).Value = Me._Embarque
            ''cmdGuia.Parameters.Add("@Extension", SqlDbType.VarChar).Value = Me._Extension

            drGuias = cmdGuia.ExecuteReader

            If (drGuias.HasRows) Then
                While drGuias.Read
                    Dim guiaEmbarque As New GuiaEmbarqueMetodos

                    guiaEmbarque.IdGuia = Convert.ToInt32(drGuias("IdGuia"))
                    guiaEmbarque.Embarque = Convert.ToInt32(drGuias("Embarque"))
                    guiaEmbarque.Extension = drGuias("Extension").ToString()
                    guiaEmbarque.Archivo = CType(drGuias("Archivo"), Byte())
                    guiaEmbarque.FAlta = Convert.ToDateTime(drGuias("FAlta"))
                    guiaEmbarque.Usuario = drGuias("Usuario").ToString()
                    guiaEmbarque.RutaArchivo = ""
                    guiaEmbarque.NombreArchivo = drGuias("NombreArchivo").ToString()

                    lstGuiasEmbarque.Add(guiaEmbarque)
                End While
            End If

        Catch ex As Exception
            Throw ex
        Finally
            _Conexion.Close()
        End Try

        Return lstGuiasEmbarque
    End Function


    Public Function ConvertirAImagen(ByVal imgBytes As Byte()) As Image
        Dim imgConvervita As Image = Nothing

        Try
            Dim Ms As New MemoryStream(imgBytes)

            imgConvervita = Image.FromStream(Ms)

        Catch ex As Exception
            MessageBox.Show("Se genero el siguiente error: " + ex.Message, "Generar imagen",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return imgConvervita
    End Function

    Public Function ConvertirAPdf(ByVal pdfBytes As Byte()) As String
        Dim nombreArchivo As String = Application.StartupPath() & "\PDFGuardado.pdf"
        Dim bw As BinaryWriter

        Try
            Dim fs As System.IO.FileStream = New System.IO.FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.Write)

            bw = New System.IO.BinaryWriter(fs)
            bw.Write(pdfBytes)
            bw.Flush()
            bw.Close()
            fs.Close()
        Catch ex As Exception
            MessageBox.Show("Se genero el siguiente error: " + ex.Message, "Generar pdf", _
                             MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return nombreArchivo
    End Function
End Class

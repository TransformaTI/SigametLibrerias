Public Class Lecturas

    Public _cliente As Integer
    Public _usuario As String
    Dim connection As SqlClient.SqlConnection
    Dim clientePadre As Integer
    Dim ramoCliente As String

    'Carga de parametros duplicados
    Dim _corporativo As Short
    Dim _sucursal As Short

    Public Sub New(ByVal conexión As SqlClient.SqlConnection, ByVal usuario As String, _
        ByVal Corporativo As Short, ByVal Sucursal As Short)
        _usuario = usuario
        connection = conexión


        _corporativo = Corporativo
        _sucursal = Sucursal

        Dim frmBuscar As New SigaMetClasses.BusquedaCliente()
        If frmBuscar.ShowDialog = Windows.Forms.DialogResult.OK Then
            _cliente = frmBuscar.Cliente
            If _cliente <> 0 Then
                cargaDatosCliente(_cliente)
                If Trim(ramoCliente) = "EDIFICIO ADMINISTRADO" AndAlso clientePadre = 0 Then
                    Dim frmcliente As New frmViewLecturas(_cliente, connection, _usuario, False, _corporativo, _sucursal)
                    frmcliente.Show()
                Else
                    Windows.Forms.MessageBox.Show("Solo es posible capturar lecturas para" & Chr(13) & _
                        "los clientes padre del ramo 'Edificio Administrado'", "Error", Windows.Forms.MessageBoxButtons.OK, _
                                    Windows.Forms.MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub cargaDatosCliente(ByVal cliente As Integer)
        Dim cmdUpdate As New SqlClient.SqlCommand()
        cmdUpdate.CommandText = "spCCConsultaDatosClientesEdificioAdministrado"
        cmdUpdate.CommandType = CommandType.StoredProcedure
        cmdUpdate.Parameters.Add("@Cliente", SqlDbType.Int).Value = cliente
        cmdUpdate.Connection = connection
        Try
            connection.Open()
            Dim rdCliente As SqlClient.SqlDataReader = cmdUpdate.ExecuteReader()
            While rdCliente.Read
                clientePadre = CInt(rdCliente.Item("clientePadreEdificio"))
                ramoCliente = CStr(rdCliente.Item("RamoClienteDescripcion"))
            End While
        Catch ex As SqlClient.SqlException
            Windows.Forms.MessageBox.Show("Error No. " & CStr(ex.number) & Chr(13) & ex.Message, "Error", _
                Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message, "Error", Windows.Forms.MessageBoxButtons.OK, _
                Windows.Forms.MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

End Class

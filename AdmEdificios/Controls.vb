Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class Controls
    Inherits System.ComponentModel.Component


#Region " Component Designer generated code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    Public Function obtienePrecioGLP(ByVal connection As SqlConnection, ByVal fecha As String) As Double
        Dim cmdSelect As New SqlCommand("spCRBObtenerPrecioGLPActual", connection)
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Parameters.Add("@fecha", SqlDbType.VarChar).Value = fecha
        cmdSelect.CommandTimeout = 120
        Try
            connection.Open()
            obtienePrecioGLP = CType(cmdSelect.ExecuteScalar, Double)
        Catch ex As SqlClient.SqlException
            Windows.Forms.MessageBox.Show("Error no. " & CStr(ex.Number) & Chr(13) & ex.Message, _
            "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        Catch ex As Exception
            Windows.Forms.MessageBox.Show("Error no. " & ex.Message, "Error", Windows.Forms.MessageBoxButtons.OK, _
            Windows.Forms.MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Function

End Class



Public Class ComboPrecio
    Inherits ComboBox

    Private dtPrecio As DataTable

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub CargaPrecios(ByVal Connection As SqlConnection, ByVal Fecha As Date, _
            Optional ByVal ZonaEconomica As Byte = Nothing, Optional ByVal RegistrosAMostrar As Byte = Nothing)
        Dim cmdSelect As New SqlCommand()
        Dim da As New SqlDataAdapter()
        Dim ds As New DataSet("Precio")
        cmdSelect.CommandText = "spCCAEConsultaUltimosPrecios"
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha
        If Not ZonaEconomica = Nothing Then
            cmdSelect.Parameters.Add("@ZonaEconomica", SqlDbType.DateTime).Value = ZonaEconomica
        End If
        If Not RegistrosAMostrar = Nothing Then
            cmdSelect.Parameters.Add("@RegistrosAMostrar", SqlDbType.DateTime).Value = RegistrosAMostrar
        End If
        cmdSelect.Connection = Connection
        da.SelectCommand = cmdSelect
        Try
            da.Fill(ds)
            dtPrecio = ds.Tables(0)
            Me.DataSource = dtPrecio
            Me.ValueMember = dtPrecio.Columns(0).ColumnName
        Catch ex As Exception
            Me.Enabled = False
            MessageBox.Show(ex.Message, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If
            da.Dispose()
            ds.Dispose()
        End Try
    End Sub
End Class


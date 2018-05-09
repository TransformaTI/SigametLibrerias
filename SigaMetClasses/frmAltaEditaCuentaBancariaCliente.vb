Imports System.Windows.Forms

Public Class frmAltaEditaCuentaBancariaCliente

    Private TipoMovimiento As String
    Dim idCliente As Int32 = -1
    Dim oCliente As New SigaMetClasses.cCliente()

    Public Sub New(Movimiento As String)

        ' This call is required by the designer.
        InitializeComponent()
        TipoMovimiento = Movimiento
        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click

        Dim frmBusquedaCliente As New BusquedaCliente()
        frmBusquedaCliente.ShowDialog()
        If frmBusquedaCliente.DialogResult = DialogResult.OK Then
            idCliente = frmBusquedaCliente.Cliente()
            Dim dsDatos As System.Data.DataSet
            Dim dtCliente As DataTable, dr As DataRow
            Try
                Cursor = Cursors.WaitCursor
                dsDatos = oCliente.ConsultaDatos(idCliente, , , , True, True)
                dtCliente = dsDatos.Tables("Cliente")
                For Each dr In dtCliente.Rows
                    TxtBox_Cliente.Text = CType(dr("Cliente"), String)
                    Txtb_Nombre.Text = CType(dr("Nombre"), String)
                    Txtb_calle.Text = CType(dr("CalleNombre"), String)
                    Txtb_Colonia.Text = CType(dr("ColoniaNombre"), String)
                    Txtb_Municipio.Text = CType(dr("Municipio"), String)
                    TxtBox_Ruta.Text = CType(dr("RutaDescripcion"), String)


                Next

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Consulta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default
                dtCliente = Nothing
                dsDatos = Nothing
            End Try
        Else
            idCliente = -1


        End If
    End Sub

    Public Sub CargarBan()
        Dim Estatus As New Dictionary(Of String, Integer)

        Estatus.Add("one", 1)
        Estatus.Add("two", 2)
        'Inicializar displaymember y valuemember
        Cbb_Estatus.DisplayMember = "Key"
        Cbb_Estatus.ValueMember = "Value"
        'Ligar el combo al diccionario
        Cbb_Estatus.DataSource = New BindingSource(Estatus, Nothing)
    End Sub


End Class
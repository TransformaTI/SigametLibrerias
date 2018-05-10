Imports System.Collections.Generic
Imports System.Windows.Forms

Public Class frmAltaEditaCuentaBancariaCliente

    Private TipoMovimiento As String
    Private Secuenciaa As Integer
    Dim idCliente As Int32 = -1
    Dim oCliente As New SigaMetClasses.cCliente()

    Public Sub New(Movimiento As String, Secuencia As Integer, clienteActualziar As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        TipoMovimiento = Movimiento
        Secuenciaa = Secuencia
        CargarEstatus()
        CargarBancos()
        If (TipoMovimiento = "Alta") Then
            Cbb_Estatus.Visible = False
            Lb_Estatus.Visible = False
        End If
        If (TipoMovimiento = "Actualizar") Then
            CargaDatosCliente(clienteActualziar)
            CargaDatosCuentaBancaria(clienteActualziar, Secuencia)
        End If
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

    Public Sub CargarEstatus()
        Dim Estatus As New Dictionary(Of String, Integer)
        Estatus.Add("Activo", 1)
        Estatus.Add("Inactivo", 2)
        ' Inicializar displaymember y valuemember
        Cbb_Estatus.DisplayMember = "Key"
        Cbb_Estatus.ValueMember = "Value"
        'Ligar el combo al diccionario
        Cbb_Estatus.DataSource = New BindingSource(Estatus, Nothing)

    End Sub

    Public Sub CargarBancos()
        Dim CargarNombreBancos As New ClienteCuentaBancaria()
        Dim dtBancos As DataTable
        dtBancos = CargarNombreBancos.ConsultaNombresBancos()
        Cbb_Banco.DataSource = dtBancos
        ' Inicializar displaymember y valuemember
        Cbb_Banco.DisplayMember = "Nombre"
        Cbb_Banco.ValueMember = "Banco"
        'Ligar el combo al diccionario
        Cbb_Banco.DataSource = dtBancos

    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        If (TipoMovimiento = "Alta") Then
            AltaCuentaBancaria()
            If MessageBox.Show("           Cuenta bancaria ¡Agragada!." + vbLf + "    ¿Desea agregar otra cuenta bancaria?", "Cuenta bancaria cliente",
         MessageBoxButtons.YesNo, MessageBoxIcon.None
         ) _
         = DialogResult.No Then
                Close()
            End If
            BorrarDatos()

        End If

        If (TipoMovimiento = "Actualizar") Then
            ActualizarCuentaBancaria()
            MessageBox.Show("Cuenta bancaria ¡ACTUALIZADA!")
            Close()
        End If
    End Sub
    Public Sub AltaCuentaBancaria()
        Dim InsertCuentaBancaria As New ClienteCuentaBancaria()
        Dim Cliente As Integer
        Dim Banco As Short
        Dim CuentaBancaria, Clabe, Sucursal, ReferenciaPago, UsuarioAlta As String
        Cliente = TxtBox_Cliente.Text
        Banco = Cbb_Banco.SelectedValue
        CuentaBancaria = Txtb_Ceunta.Text
        Clabe = Txtb_Clave.Text
        Sucursal = Txtb_Sucursal.Text
        ReferenciaPago = Txtb_Referencia.Text
        UsuarioAlta = "Usuario"
        InsertCuentaBancaria.insertarClienteCuentaBancaria(Cliente, Banco, CuentaBancaria, Clabe, Sucursal, ReferenciaPago, UsuarioAlta)
    End Sub

    Public Sub ActualizarCuentaBancaria()
        Dim ActualizarCuentaBancaria As New ClienteCuentaBancaria()
        Dim Cliente As Integer
        Dim Banco As Short
        Dim CuentaBancaria, Clabe, Sucursal, ReferenciaPago, Estatus As String
        Cliente = TxtBox_Cliente.Text
        Banco = Cbb_Banco.SelectedValue
        CuentaBancaria = Txtb_Ceunta.Text
        Clabe = Txtb_Clave.Text
        Sucursal = Txtb_Sucursal.Text
        ReferenciaPago = Txtb_Referencia.Text
        Estatus = Cbb_Estatus.SelectedText
        MessageBox.Show(Cbb_Estatus.SelectedText)
        ActualizarCuentaBancaria.ActualizaClienteCuentaBancaria(Cliente, Secuenciaa, Banco, CuentaBancaria, Clabe, Sucursal, ReferenciaPago, Estatus)
    End Sub

    Public Sub CargaDatosCliente(ClienteActualizar As Integer)
        Dim dsDatos As System.Data.DataSet
        Dim dtCliente As DataTable, dr As DataRow
        Try
            Cursor = Cursors.WaitCursor
            dsDatos = oCliente.ConsultaDatos(ClienteActualizar, , , , True, True)
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
        idCliente = -1
    End Sub

    Public Sub CargaDatosCuentaBancaria(Cliente As Integer, Secuencia As Integer)
        Dim dsDatos As System.Data.DataSet
        Dim dtCliente As DataTable, dr As DataRow
        Try
            Dim ConsultaCuentaBancaria As New ClienteCuentaBancaria()
            dtCliente = ConsultaCuentaBancaria.ConsultaCuentaBancaria(Cliente, Secuencia)
            For Each dr In dtCliente.Rows
                Cbb_Banco.SelectedValue = CType(dr("Banco"), String)
                Txtb_Ceunta.Text = CType(dr("CuentaBancaria"), String)
                Txtb_Clave.Text = CType(dr("clabe"), String)
                Txtb_Sucursal.Text = CType(dr("Sucursal"), String)
                Txtb_Referencia.Text = CType(dr("ReferenciaPago"), String)
                Cbb_Estatus.Text = CType(dr("Status"), String)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Consulta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
            dtCliente = Nothing
            dsDatos = Nothing
        End Try
        idCliente = -1

    End Sub

    Public Sub BorrarDatos()
        Cbb_Banco.Text = ""
        Txtb_Ceunta.Text = ""
        Txtb_Clave.Text = ""
        Txtb_Sucursal.Text = ""
        Txtb_Referencia.Text = ""
        Cbb_Estatus.Text = ""
    End Sub
End Class
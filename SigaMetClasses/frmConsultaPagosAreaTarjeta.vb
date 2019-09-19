Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms

Public Class frmConsultaPagosAreaTarjeta
#Region "Variables"


    Private _Usuario As String
    Private _ConnectionString As String
    Private _Anio As Integer
    Private _Folio As Integer
    Private _Modulo As Short
    Private listaDireccionesEntrega As List(Of RTGMCore.DireccionEntrega)
    Private _Empresa As Integer
    Private _Sucursal As Byte
    Dim oConfig As SigaMetClasses.cConfig

#End Region
#Region "Constructor"


    Public Sub New(ByVal Usuario As String, ByVal ConnectionString As String, ByVal modulo As Short, ByVal sucursal As Byte, ByVal Corporativo As Short)
        InitializeComponent()
        _Usuario = Usuario
        _ConnectionString = ConnectionString
        _CadenaConexion = ConnectionString
        _Modulo = modulo
        _Sucursal = sucursal
        listaDireccionesEntrega = New List(Of RTGMCore.DireccionEntrega)
        oConfig = New SigaMetClasses.cConfig(_Modulo, CShort(_Empresa), _Sucursal)
        _Modulo = modulo
        _Sucursal = sucursal

    End Sub

#Region "Propiedades"

    Private _CadenaConexion As String
    Public Property CadenaConexion() As String
        Get
            Return _CadenaConexion
        End Get
        Set(ByVal value As String)
            _CadenaConexion = value
        End Set
    End Property

    Private _URLGateway As String
    Public Property URLGateway() As String
        Get
            Return _URLGateway
        End Get
        Set(ByVal value As String)
            _URLGateway = value
        End Set
    End Property
    Public Property Sucursal() As Byte
        Get
            Return _Sucursal
        End Get
        Set(ByVal value As Byte)
            _Sucursal = value
        End Set
    End Property

#End Region



#End Region


#Region "Metodos"
    Private Sub MuestraAltaPagoTarjeta(ByVal sTipoLlamado As Byte)
        Dim frmAlta As frmAltaPagoTarjeta


        If _Anio = 0 And sTipoLlamado = 1 Then
            MessageBox.Show("Seleccione un pago con tarjeta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        If _Anio > 0 And sTipoLlamado = 1 Then
            If grdPagosTarjeta.CurrentRow.Cells(9).Value.ToString().Trim = "EMITIDO" Or grdPagosTarjeta.CurrentRow.Cells(9).Value.ToString().Trim = "VALIDADO" Then
                MessageBox.Show("No se puede modificar el cargo porque ya ha sido utilizado en Liquidación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If


        CierraConexion()
        Cursor = Cursors.WaitCursor
        frmAlta = New frmAltaPagoTarjeta(_Usuario, listaDireccionesEntrega, _ConnectionString, _Modulo, _Empresa, _Sucursal)
        frmAlta.modoOperacion = sTipoLlamado
        frmAlta.Folio = _Folio
        frmAlta.Anio = _Anio
        frmAlta.ShowDialog()
        BuscarCargosTarjetaPorFechaAlta()
        Cursor = Cursors.Default

    End Sub
    Private Sub SoloNumeros(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BuscarCargosTarjetaPorFechaAlta()
        Dim oPagoTarjeta As New AltaPagoTarjeta
        Dim NumCliente As Int64 = 0
        Dim dtCargoTarjeta As DataTable
        Dim dtCargoTarjetaTmp As DataTable
        Dim direccionEntregaTemp As New RTGMCore.DireccionEntrega

        Cursor = Cursors.WaitCursor


        If TxtNumCliente.Text <> String.Empty Then
            NumCliente = Convert.ToUInt64(TxtNumCliente.Text)
        End If
        CierraConexion()

        dtCargoTarjeta = oPagoTarjeta.ConsultaCargoTarjeta(dtpFInicio.Value, dtpFfinal.Value, NumCliente)


        Try
            _URLGateway = CType(oConfig.Parametros("URLGateway"), String).Trim()
        Catch ex As Exception
            If Not ex.Message.Contains("Index") Then
                MessageBox.Show("Error al consultar Parametro URLGateway: " + ex.Message)
            End If
        End Try


        If _URLGateway <> "" Then
            consultarDatosClienteCRM_Parallel(dtCargoTarjeta)
            dtCargoTarjetaTmp = dtCargoTarjeta
            For Each row As DataRow In dtCargoTarjetaTmp.Rows
                direccionEntregaTemp = listaDireccionesEntrega.Find(Function(p) p.IDDireccionEntrega = CInt(row("Cliente")))
                If Not IsNothing(direccionEntregaTemp) Then
                    If Not IsNothing(direccionEntregaTemp.Nombre) Then
                        If Not direccionEntregaTemp.Nombre.Contains("error") Then
                            dtCargoTarjetaTmp.Columns("nombre").ReadOnly = False
                            dtCargoTarjetaTmp.Columns("nombre").MaxLength = 200
                            row("Nombre") = direccionEntregaTemp.Nombre.Trim()
                            dtCargoTarjetaTmp.Columns("nombre").ReadOnly = True
                        End If
                    End If
                End If
            Next

            grdPagosTarjeta.DataSource = dtCargoTarjetaTmp
        Else
            grdPagosTarjeta.DataSource = dtCargoTarjeta
        End If


        If grdPagosTarjeta.Rows.Count > 0 Then
            grdPagosTarjeta.Rows(0).Selected = True
            SeleccionaPagoTarjeta()
        End If

        Cursor = Cursors.Default
        oPagoTarjeta = Nothing
    End Sub

    Private Function consultarDatosClienteCRM_Parallel(ByVal dtPagosTarjeta As DataTable) As DataTable
        Dim dtPagosTarjetasModificados As New DataTable()
        Dim Mensaje As String = "Los siguientes clientes no fueron encontrados en CRM." + vbCrLf
        Dim CtesNoEncontrados As String = ""
        Dim direccionEntregaTemp As RTGMCore.DireccionEntrega


        Try


            dtPagosTarjetasModificados = dtPagosTarjeta
            Dim clientes As New List(Of Integer)



            For Each dr As DataRow In dtPagosTarjetasModificados.Rows
                direccionEntregaTemp = listaDireccionesEntrega.Find(Function(p) p.IDDireccionEntrega = CInt(dr("Cliente")))
                If IsNothing(direccionEntregaTemp) Then
                    clientes.Add(CType(dr("Cliente"), Int32))
                End If
            Next
            Dim clientesDistintos As New List(Of Integer)
            If (clientes.Count > 0) Then
                clientesDistintos = clientes.Select(Function(v) v).Distinct.ToList()
            End If
            If clientesDistintos.Count > 0 Then
                System.Threading.Tasks.Parallel.ForEach(clientesDistintos, Sub(x) consultarDirecciones(x))

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtPagosTarjetasModificados.Clear()
        Finally
            Cursor = Cursors.Default
        End Try

        Return dtPagosTarjeta
    End Function


    Private Sub consultarDirecciones(ByVal idCliente As Integer)
        Dim oGateway As RTGMGateway.RTGMGateway
        Dim oSolicitud As RTGMGateway.SolicitudGateway
        Dim oDireccionEntrega As RTGMCore.DireccionEntrega
        Try

            oGateway = New RTGMGateway.RTGMGateway(CType(_Modulo, Byte), _CadenaConexion)
            oSolicitud = New RTGMGateway.SolicitudGateway()
            oGateway.URLServicio = _URLGateway

            oSolicitud.IDCliente = idCliente
            oDireccionEntrega = oGateway.buscarDireccionEntrega(oSolicitud)

            If Not IsNothing(oDireccionEntrega) Then
                If Not IsNothing(oDireccionEntrega.Message) Then
                    oDireccionEntrega = New RTGMCore.DireccionEntrega()
                    oDireccionEntrega.IDDireccionEntrega = idCliente
                    oDireccionEntrega.Nombre = oDireccionEntrega.Message
                    listaDireccionesEntrega.Add(oDireccionEntrega)
                Else
                    listaDireccionesEntrega.Add(oDireccionEntrega)
                End If

            Else
                oDireccionEntrega = New RTGMCore.DireccionEntrega()
                oDireccionEntrega.IDDireccionEntrega = idCliente
                oDireccionEntrega.Nombre = "No se encontró cliente"
                listaDireccionesEntrega.Add(oDireccionEntrega)
            End If

        Catch ex As Exception
            oDireccionEntrega = New RTGMCore.DireccionEntrega()
            oDireccionEntrega.IDDireccionEntrega = idCliente
            oDireccionEntrega.Nombre = ex.Message
            listaDireccionesEntrega.Add(oDireccionEntrega)

        End Try
    End Sub


    Private Sub CancelaCargoTarjeta()
        Dim oPagoTarjeta As New AltaPagoTarjeta
        Dim Cancelacion As Boolean

        Dim Respuesta = MessageBox.Show("¿Esta Seguro de eliminar el cargo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If Respuesta = DialogResult.No Then
            Exit Sub
        End If

        If _Anio = 0 Then
            MessageBox.Show("Seleccione un pago con tarjeta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If grdPagosTarjeta.CurrentRow.Cells(9).Value.ToString().Trim = "EMITIDO" Or grdPagosTarjeta.CurrentRow.Cells(9).Value.ToString().Trim = "VALIDADO" Then
            MessageBox.Show("No se puede eliminar el cargo porque ya ha sido utilizado en Liquidación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Cancelacion = oPagoTarjeta.CancelaCargoTarjeta(grdPagosTarjeta.CurrentRow.Cells(6).Value.ToString(), grdPagosTarjeta.CurrentRow.Cells(7).Value.ToString(), _Usuario)

        If Cancelacion = True Then
            MessageBox.Show("La información se actualizó correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BuscarCargosTarjetaPorFechaAlta()
        End If

        oPagoTarjeta = Nothing
    End Sub
    Private Sub SeleccionaPagoTarjeta()
        If grdPagosTarjeta.CurrentRow.Index >= 0 Then
            _Folio = CInt(grdPagosTarjeta.CurrentRow.Cells(7).Value.ToString())
            _Anio = CInt(grdPagosTarjeta.CurrentRow.Cells(6).Value.ToString())

        End If
    End Sub
#End Region
#Region "Eventos"


    Private Sub tbrPrincipal_ButtonClick(sender As Object, e As Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrPrincipal.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case Is = "Alta"
                MuestraAltaPagoTarjeta(0)
            Case Is = "Modificar"
                MuestraAltaPagoTarjeta(1)
            Case Is = "Cancelar"
                CancelaCargoTarjeta()
            Case Is = "Salir"
                Me.Close()
        End Select
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click
        BuscarCargosTarjetaPorFechaAlta()
    End Sub
    Private Sub TxtNumCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumCliente.KeyPress
        SoloNumeros(sender, e)
    End Sub


    Private Sub grdPagosTarjeta_DoubleClick(sender As Object, e As EventArgs) Handles grdPagosTarjeta.DoubleClick
        SeleccionaPagoTarjeta()
    End Sub

    Private Sub TxtNumCliente_TextChanged(sender As Object, e As EventArgs) Handles TxtNumCliente.TextChanged

    End Sub

    Private Sub TxtNumCliente_MouseDown(sender As Object, e As MouseEventArgs) Handles TxtNumCliente.MouseDown
        If (e.Button = MouseButtons.Right) Then
            Exit Sub
        End If
    End Sub


    Private Sub grdPagosTarjeta_RowDividerDoubleClick(sender As Object, e As DataGridViewRowDividerDoubleClickEventArgs) Handles grdPagosTarjeta.RowDividerDoubleClick

    End Sub

    Private Sub grdPagosTarjeta_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPagosTarjeta.CellContentClick
        SeleccionaPagoTarjeta()
    End Sub

    Private Sub grdPagosTarjeta_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPagosTarjeta.CellClick
        SeleccionaPagoTarjeta()
    End Sub

    Private Sub grdPagosTarjeta_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPagosTarjeta.CellContentDoubleClick
        SeleccionaPagoTarjeta()
    End Sub

    Private Sub frmConsultaPagosAreaTarjeta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuscarCargosTarjetaPorFechaAlta()
    End Sub

    Private Sub grdPagosTarjeta_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPagosTarjeta.CellDoubleClick
        SeleccionaPagoTarjeta()
    End Sub
End Class
#End Region
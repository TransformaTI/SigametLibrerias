Imports System.Collections.Generic
Imports System.Windows.Forms
Imports SigaMetClasses

Public Class frmConsultaCargoTarjetaCliente
    Private _Cliente As String
    Private _CargoTarjeta As CargoTarjeta
    Private _listaCargos As List(Of CargoTarjeta)

    Public Property Cliente As String
        Get
            Return _Cliente
        End Get
        Set(value As String)
            _Cliente = value
        End Set
    End Property

    Public Property CargoTarjeta As CargoTarjeta
        Get
            Return _CargoTarjeta
        End Get
        Set(value As CargoTarjeta)
            _CargoTarjeta = value
        End Set
    End Property

    Private Sub frmConsultaCargoTarjetaCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objCargos As New CargoTarjetaDatos

        _listaCargos = objCargos.consultarCargoTarjeta(_Cliente)


        If _listaCargos.Count = 0 Then
            btnInsertar.Enabled = False
            MessageBox.Show("No se encontraron pagos de TPV para el cliente, por favor verifique con el área de tarjetas de crédito", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            For Each cargo As SigaMetClasses.CargoTarjeta In _listaCargos
                dgvCargos.Rows.Add(cargo.TipoCobroDescripcion, cargo.NumeroTarjeta, cargo.NombreBanco, cargo.Autorizacion, cargo.Importe, cargo.Observacion)

            Next
        End If




    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

    End Sub

    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        CargoTarjeta = _listaCargos.Item(dgvCargos.CurrentCell.RowIndex)

        Try
            Dim Actualizar As New CargoTarjetaDatos
            Actualizar.actualizaStatusCargoTarjeta(_Cliente, CargoTarjeta.Autorizacion, "ALTA", "EMITIDO")
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class
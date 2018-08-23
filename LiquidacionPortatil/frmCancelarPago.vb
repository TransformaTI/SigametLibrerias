Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class frmCancelarPago
    Private _Cobros As New List(Of SigaMetClasses.CobroDetalladoDatos)

    Private _ListaCobroRemisiones As List(Of SigaMetClasses.CobroRemisiones)
    Private oCobroRemi As List(Of SigaMetClasses.CobroRemisiones)


    Private _Remisiones As DataTable

    Public Property Remisiones As DataTable
        Get
            Return _Remisiones
        End Get
        Set(ByVal value As DataTable)
            _Remisiones = value
        End Set
    End Property

    Public Property CobroRemisiones() As List(Of SigaMetClasses.CobroRemisiones)
        Get
            Return _ListaCobroRemisiones
        End Get
        Set(ByVal value As List(Of SigaMetClasses.CobroRemisiones))
            _ListaCobroRemisiones = value
            ' oCobroRemi = _ListaCobroRemisiones
        End Set
    End Property

    Public Property Cobros() As List(Of SigaMetClasses.CobroDetalladoDatos)
        Get
            Return _Cobros
        End Get
        Set(ByVal value As List(Of SigaMetClasses.CobroDetalladoDatos))
            _Cobros = value
        End Set
    End Property

    Private Sub frmCancelarPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvCobros.AutoGenerateColumns = False
        dgvCobros.DataSource = _Cobros
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub dgvCobros_CellContentClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dgvCobros.CellContentClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        Dim grid As DataGridView = DirectCast(sender, DataGridView)

        If TypeOf grid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
            If grid.Columns(e.ColumnIndex).Name = "btnEliminar" Then
                If MessageBox.Show("Está a punto de eliminar un cobro de forma irreversible ¿desea continuar o cancelar?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK Then
                    Try
                        dgvCobros.DataSource = Nothing

                        Dim oCobroEliminado As SigaMetClasses.CobroDetalladoDatos = _Cobros(e.RowIndex)

                        If Not CobroRemisiones Is Nothing Then
                            ActualizaSaldoRemisiones(oCobroEliminado, Remisiones, CobroRemisiones)
                        End If

                        _Cobros.RemoveAt(e.RowIndex)
                    Catch ex As IndexOutOfRangeException
                        MessageBox.Show("Error: " & ex.Message & " el intentar eliminar la fila " & e.RowIndex.ToString & " de " & _Cobros.Count.ToString & " filas ")
                    End Try
                    dgvCobros.DataSource = _Cobros
                End If
            End If
        End If

    End Sub

    Private Sub ActualizaSaldoRemisiones(CobroEliminado As SigaMetClasses.CobroDetalladoDatos, Remisiones As DataTable, oCobroRemisiones As List(Of SigaMetClasses.CobroRemisiones))
        Dim saldoDevuelto As Boolean = False

        For Each Remision As DataRow In Remisiones.Rows
            For Each CobroRemision As SigaMetClasses.CobroRemisiones In CobroRemisiones
				If (CobroRemision.Remision.Trim() = Remision("Remision").ToString().Trim() And CobroRemision.Serie = Remision("Serie").ToString().Trim() And CType(CobroEliminado.Remision, String) = CobroRemision.Remision.Trim() And CobroEliminado.Serie = CobroRemision.Serie) Then

					'CobroEliminado.Pago = CobroRemision.Pago And
					'Remisiones.BeginInit()

					Remision("Saldo") = Convert.ToDecimal(Remision("Saldo")) + CobroRemision.MontoAbonado
					CobroRemisiones.Remove(CobroRemision)
					saldoDevuelto = True
					Exit For
					'Remisiones.EndInit()
					'oCobroRemi.Remove(CobroRemision)
					'_ListaCobroRemisiones.Remove(CobroRemision)
				End If
			Next CobroRemision
            If saldoDevuelto Then
                Exit For
            End If
        Next Remision


    End Sub
End Class
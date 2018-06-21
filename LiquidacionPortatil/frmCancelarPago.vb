Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class frmCancelarPago
    Private _Cobros As New List(Of SigaMetClasses.CobroDetalladoDatos)

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
                    MessageBox.Show(e.RowIndex.ToString & " filas " & _Cobros.Count.ToString)
                    Try
                        dgvCobros.DataSource = Nothing
                        _Cobros.RemoveAt(e.RowIndex)
                    Catch ex As IndexOutOfRangeException
                        MessageBox.Show(e.RowIndex.ToString & " filas " & _Cobros.Count.ToString)
                    End Try
                    dgvCobros.DataSource = _Cobros
                End If
            End If
        End If
    End Sub
End Class
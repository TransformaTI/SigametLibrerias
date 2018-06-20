
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



    End Sub
End Class
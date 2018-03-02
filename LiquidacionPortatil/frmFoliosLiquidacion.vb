Public Class frmFoliosLiquidacion

    Public Datos As DataTable

    Private Sub frmFoliosLiquidacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dgFolios.DataSource = Datos
    End Sub

    Private Sub frmFoliosLiquidacion_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Datos = Nothing
    End Sub
End Class
Imports System.Windows.Forms

Public Class frmConsultaPagosAreaTarjeta
    Private _Usuario As String
    Private _ConnectionString As String
    Public Sub New(Usuario As String, ConnectionString As String)

        ' This call is required by the designer.
        InitializeComponent()
        _Usuario = Usuario
        _ConnectionString = ConnectionString

    End Sub


    Private Sub tbrPrincipal_ButtonClick(sender As Object, e As Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrPrincipal.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case Is = "Alta"
                MuestraAltaPagoTarjeta(0)
            Case Is = "Modificar"
                MuestraAltaPagoTarjeta(1)

        End Select
    End Sub


    Private Sub MuestraAltaPagoTarjeta(ByVal sTipoLlamado As Byte)

        Cursor = Cursors.WaitCursor
        Dim frmAlta As New frmAltaPagoTarjeta(_Usuario)
        frmAlta.modoOperacion = sTipoLlamado
        frmAlta.Show()
        frmAlta = Nothing
        Cursor = Cursors.Default

    End Sub

    Private Sub frmConsultaPagosAreaTarjeta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
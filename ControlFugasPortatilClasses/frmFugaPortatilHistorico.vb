Public Class frmFugaPortatilHistorico

    Private _Anio, _Folio As Integer

#Region "Datos Constructor"
    Public Sub New(ByVal Anio As Integer, ByVal Folio As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _Anio = Anio
        _Folio = Folio

    End Sub
#End Region

#Region "Manejo de datos"

    Private Sub ConsultarFugaPortatilBitacora()
        Try
            Dim oConsultaFugaPortatil = New ControlFugasPortatilClasses.Consulta.cConsultaFugaPortatilBitacora(0, _Anio, _Folio)
            If oConsultaFugaPortatil.dtTable.Rows.Count > 0 Then
                txtAño.Text = oConsultaFugaPortatil.dtTable.Rows(0).Item(0)
                txtFolio.Text = oConsultaFugaPortatil.dtTable.Rows(0).Item(1)
                txtCliente.Text = oConsultaFugaPortatil.dtTable.Rows(0).Item(2)
            End If
            dgProducto.DataSource = oConsultaFugaPortatil.dtTable
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Manejo de Controles"

    Private Sub frmFugaPortatilHistorico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Try
            InterfazInicial()
            Limpiar()
            ConsultarFugaPortatilBitacora()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub txtFolio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFolio.KeyDown, txtCliente.KeyDown, txtAño.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

#End Region

#Region "Manejo de la forma"

    Private Sub Limpiar()
        txtFolio.Clear()
        txtAño.Clear()
        txtCliente.Clear()
        ActiveControl = txtFolio
    End Sub

    Private Sub InterfazInicial()
        txtFolio.ReadOnly = True
        txtAño.ReadOnly = True
        txtCliente.ReadOnly = True
    End Sub

#End Region
  
End Class
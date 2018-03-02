Imports System.Windows.Forms

Public Class frmCambioRuta

    Private _Usuario As String
    Private _Ruta As Integer
    Private _RutaDes As String
    Private _AnoAtt As Short
    Private _Folio As Integer

    Public Sub New(ByVal AnoAtt As Short, ByVal Folio As Integer, ByVal Ruta As Integer, ByVal RutaDes As String, ByVal Usuario As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        _AnoAtt = AnoAtt
        _Folio = Folio
        _Usuario = Usuario
        _Ruta = Ruta
        _RutaDes = RutaDes

        'Add any initialization after the InitializeComponent() call

    End Sub

    Private Sub frmCambioRuta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboRuta.CargaDatos(1, _Usuario)
        lblRuta.Text = _RutaDes
    End Sub

    Private Sub cboRuta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRuta.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If cboRuta.Identificador <> _Ruta Then
            Dim oRutaCambio As New PortatilClasses.cComisionPortatil(6, Now, Now, 0, _AnoAtt, _Folio, cboRuta.Identificador, 0, 0)
            oRutaCambio.RegistrarModificarEliminar()
            _Ruta = cboRuta.Identificador
            Me.DialogResult() = DialogResult.OK
            Me.Close()
        Else
            Me.DialogResult() = DialogResult.OK
            Me.Close()
        End If
    End Sub
End Class
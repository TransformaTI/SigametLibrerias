Public Class frmVisorImagen

    Private _imgVisualizar As Image
    Public Property ImgVisualizar() As Image
        Get
            Return _imgVisualizar
        End Get
        Set(ByVal value As Image)
            _imgVisualizar = value
        End Set
    End Property


    Private Sub frmVisorImagen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        pbxImagen.Image = _imgVisualizar
    End Sub
End Class
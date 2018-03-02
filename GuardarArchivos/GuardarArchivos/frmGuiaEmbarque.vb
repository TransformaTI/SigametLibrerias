Imports System.IO

Public Class frmGuiaEmbarque

#Region "Variables"
    Private _GEmbarque As GuiaEmbarqueMetodos

    Public Property GuiaEmbarque() As GuiaEmbarqueMetodos
        Get
            Return _GEmbarque
        End Get
        Set(ByVal value As GuiaEmbarqueMetodos)
            _GEmbarque = value
        End Set
    End Property
#End Region

    Private Sub frmGuiaEmbarque_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Guardar guia embarque"

        Me.lblExtension.Text = "Extension:"
        Me.lblRuta.Text = "Ruta:"

        Me.txtExtension.ReadOnly = True

        Me.btnGuardar.Text = "Guardar"

        _GEmbarque = New GuiaEmbarqueMetodos()
    End Sub

    Private Sub btnRuta_Click(sender As System.Object, e As System.EventArgs) Handles btnRuta.Click
        ObtenerRuta()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        If LlenarInformacion() Then

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

#Region "Métodos propios"
    Private Sub ObtenerRuta()
        Try
            Dim OpenFD As New OpenFileDialog

            OpenFD.Filter = "Imagenes|*.png;*.jpg;*.jpge;*.bmp|Archivos PDF|*.pdf"

            If OpenFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.txtRuta.Text = OpenFD.FileName
                Me.txtExtension.Text = Path.GetExtension(Me.txtRuta.Text)
                Me._GEmbarque.NombreArchivo = OpenFD.SafeFileName.Replace(Me.txtExtension.Text, "")
            End If

        Catch ex As Exception
            MessageBox.Show("Se genero el siguiente error: " + ex.Message, "Carga archivo", _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Function LlenarInformacion() As Boolean
        If String.IsNullOrEmpty(txtRuta.Text) Then
            MessageBox.Show("Favor de seleccionar un archivo.", "Falta información", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return False
            Exit Function
        End If

        _GEmbarque.Extension = txtExtension.Text.Replace(".", "")
        _GEmbarque.RutaArchivo = txtRuta.Text

        Return True
    End Function

#End Region
End Class

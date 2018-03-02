Imports System.Collections.Generic
Imports System.Windows.Forms

Public Class frmBusquedaPorRFCyRazonSocial
    Dim datos As New Dictionary(Of String, String)



    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click

        If txtRFC.Text.Length > 0 Then
            datos.Add("rfc", txtRFC.Text)
        Else
            datos.Add("rfc", "")
        End If

        If txtRazonSocial.Text.Length > 0 Then
            datos.Add("razonSocial", txtRazonSocial.Text)
        Else
            datos.Add("razonSocial", "")
        End If


        Me.Tag = datos
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCaancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCaancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmBusquedaPorRFCyRazonSocial_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtRFC.Focus()
    End Sub

    Private Sub txtRFC_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRFC.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            btnAceptar_Click(sender, e)
        End If
    End Sub

    Private Sub txtRazonSocial_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRazonSocial.KeyPress
       If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            btnAceptar_Click(sender, e)
        End If
    End Sub
End Class
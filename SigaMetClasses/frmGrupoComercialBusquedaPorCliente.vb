Imports System.Collections.Generic
Imports System.Windows.Forms

Public Class frmGrupoComercialBusquedaPorCliente
    Dim datos As New Dictionary(Of String, String)



    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If txtCliente.Text.Length > 0 Then
            datos.Add("cliente", txtCliente.Text)
        Else
            datos.Add("cliente", 0)
        End If

        If txtNombre.Text.Length > 0 Then
            datos.Add("nombre", txtNombre.Text)
        Else
            datos.Add("nombre", "")
        End If
        Me.Tag = datos
        Me.DialogResult = Windows.Forms.DialogResult.OK

        Me.Close()
    End Sub

    Private Sub btnCaancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCaancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmBusquedaPorRFCyRazonSocial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCliente.Focus()
    End Sub

    Private Sub txtCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            btnAceptar_Click(sender, e)
        End If
    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            btnAceptar_Click(sender, e)
        End If
    End Sub
End Class
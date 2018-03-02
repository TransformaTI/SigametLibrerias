Public Class ListadoNotas
    Inherits System.Windows.Forms.ListBox

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'ListadoNotas
        '
        Me.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable

    End Sub

#End Region

    Private _ColorNotaAutomatica As Color = Color.AliceBlue
    Private _ColorNotaEscaneada As Color = Color.PapayaWhip

    Private Sub ListadoNotas_MeasureItem(ByVal sender As Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles MyBase.MeasureItem
        Dim itmSize As SizeF
        Dim S As New SizeF(Me.Width, 200)
        If e.Index > -1 AndAlso Me.Items.Count > 0 Then
            itmSize = e.Graphics.MeasureString(Items(e.Index).ToString, Me.Font, S)
            e.ItemHeight = CInt(itmSize.Height)
            e.ItemWidth = CInt(itmSize.Width)
        End If
    End Sub

    Private Sub ListadoNotas_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles MyBase.DrawItem
        If e.Index > -1 AndAlso Me.Items.Count > 0 Then
            Dim txtBrush As SolidBrush = New SolidBrush(Me.ForeColor)
            Dim bgBrush As SolidBrush

            Dim R As New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
            If e.State.ToString().IndexOf("Focus") > -1 AndAlso e.State.ToString().IndexOf("NoFocus") = -1 AndAlso e.State.ToString().IndexOf("NonFocus") = -1 Then
                bgBrush = New SolidBrush(Color.RosyBrown)
            Else
                If CType(Me.Items(e.Index), RelacionNotas.frmRelacionNotas.NotaPedido).Tipo = frmRelacionNotas.TipoNota.Automatica Then
                    bgBrush = New SolidBrush(_ColorNotaAutomatica)
                Else
                    bgBrush = New SolidBrush(_ColorNotaEscaneada)
                End If
            End If
            e.Graphics.FillRectangle(bgBrush, e.Bounds)
            e.Graphics.DrawString(Items(e.Index).ToString, Me.Font, txtBrush, R)
            e.DrawFocusRectangle()
        End If
    End Sub
End Class

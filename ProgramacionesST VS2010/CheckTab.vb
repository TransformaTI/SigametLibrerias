Public Class CheckTab
    Inherits System.Windows.Forms.TabControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.DrawMode = TabDrawMode.OwnerDrawFixed
        Me.SizeMode = TabSizeMode.FillToRight
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
        components = New System.ComponentModel.Container()
    End Sub

#End Region


    Private _prevIndex As Integer = 0
    Private _readOnly As Boolean

    Public Property [ReadOnly]() As Boolean
        Get
            Return Me._readOnly
        End Get
        Set(ByVal Value As Boolean)
            Me._readOnly = Value
        End Set
    End Property

    Private Sub CheckTab_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles MyBase.DrawItem
        Dim g As Graphics = e.Graphics
        g.FillRectangle(New SolidBrush(Me.TabPages(e.Index).BackColor), New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
        Me.TabPages(e.Index).Width += 15

        If e.Index = Me.SelectedIndex Then
            g.FillRectangle(New SolidBrush(Color.White), New Rectangle(e.Bounds.X + 5, e.Bounds.Y + 5, 12, 12))
            g.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(e.Bounds.X + 5, e.Bounds.Y + 5, 12, 12))
            g.DrawLine(New Pen(Color.Black, 2), e.Bounds.X + 7, e.Bounds.Y + 10, e.Bounds.X + 10, e.Bounds.Y + 14)
            g.DrawLine(New Pen(Color.Black, 2), e.Bounds.X + 10, e.Bounds.Y + 14, e.Bounds.X + 14, e.Bounds.Y + 7)
        Else
            g.FillRectangle(New SolidBrush(Color.White), New Rectangle(e.Bounds.X + 3, e.Bounds.Y + 3, 12, 12))
            g.DrawRectangle(New Pen(Color.Black, 1), New Rectangle(e.Bounds.X + 3, e.Bounds.Y + 3, 12, 12))
        End If
        g.DrawString(Me.TabPages(e.Index).Text, e.Font, New SolidBrush(Color.Black), e.Bounds.X + 20, 5)
    End Sub

    Private Sub CheckTab_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SelectedIndexChanged
        If Me._readOnly Then
            Me.SelectedIndex = Me._prevIndex
        Else
            Me._prevIndex = Me.SelectedIndex
        End If
    End Sub
End Class

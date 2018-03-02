Imports Microsoft.VisualBasic.ControlChars
Public Class cboTipoGestion
    Inherits System.Windows.Forms.ComboBox

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub DataBinding(ByVal DataTable As DataTable)
        Me.DataSource = DataTable
        Me.ValueMember = "TipoGestionCobranza"
        Me.DisplayMember = "Descripcion"
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub
End Class

Public Class cboDiaSemana
    Inherits System.Windows.Forms.ComboBox

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub DataBinding(ByVal DataTable As DataTable)
        Me.DataSource = DataTable
        Me.ValueMember = "DiaSemana"
        Me.DisplayMember = "Descripcion"
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub
End Class

Public Class lstProgramacion
    Inherits System.Windows.Forms.ListBox

    Public Sub New()
        MyBase.New()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    Public Sub DataBinding(ByVal DataTable As DataTable)
        Me.Items.Clear()
        Me.DataSource = Nothing
        Me.DataSource = DataTable
        Me.ValueMember = "Consecutivo"
        Me.DisplayMember = "DescripcionPrograma"
    End Sub

End Class

Public Class lblNombra
    Inherits System.Windows.Forms.Label

    Public Sub New()
        MyBase.New()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    Public Sub DataBinding(ByVal DataTable As DataTable)
        Me.Text = DataTable.Rows(0).Item("Cliente").ToString & CrLf & _
                  DataTable.Rows(0).Item("Nombre").ToString()
    End Sub

End Class

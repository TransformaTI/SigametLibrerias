Public Class FullControlTreeView
    Inherits System.Windows.Forms.TreeView

    Dim BlinkingNode As TreeNode
    Dim BlinkColor As Color
    Dim BlinkingTimes As Integer
    Dim _PrevVisitedNode As TreeNode
    Dim _ChangeSelectedNodeColor As Boolean = True
    Dim _ChangeSelectedNodePathColor As Boolean = False
    Dim _SelectedNodeColor As Color = Color.Red
    Dim _SelectedNodePathColor As Color = Color.Orange
    Dim Navigating As Boolean = False
    Dim NavigatedNodes() As TreeNode
    Dim CurrentNavIndex As Integer = -1



#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl1 overrides dispose to clean up the component list.
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
    Friend WithEvents txtEdit As System.Windows.Forms.TextBox
    Friend WithEvents lblDrag As System.Windows.Forms.Label
    Friend WithEvents tmrBlink As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tmrBlink = New System.Windows.Forms.Timer(Me.components)
        Me.txtEdit = New System.Windows.Forms.TextBox()
        Me.lblDrag = New System.Windows.Forms.Label()
        '
        'tmrBlink
        '
        Me.tmrBlink.Interval = 500
        '
        'txtEdit
        '
        Me.txtEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEdit.Location = New System.Drawing.Point(133, 17)
        Me.txtEdit.Name = "txtEdit"
        Me.txtEdit.TabIndex = 0
        Me.txtEdit.Text = ""
        Me.txtEdit.Visible = False
        '
        'lblDrag
        '
        Me.lblDrag.BackColor = System.Drawing.Color.Transparent
        Me.lblDrag.Location = New System.Drawing.Point(216, 17)
        Me.lblDrag.Name = "lblDrag"
        Me.lblDrag.TabIndex = 0
        Me.lblDrag.Visible = False
        '
        'FullControlTreeView
        '

    End Sub

#End Region

#Region "Funciones públicas"
    Public Function Exist(ByVal NodeText As String, Optional ByVal IncludeSubNodes As Boolean = False, Optional ByVal SearchNode As TreeNode = Nothing) As Boolean
        Dim Node As TreeNode
        Dim SubNode As TreeNode
        If Not SearchNode Is Nothing Then
            For Each Node In SearchNode.Nodes
                If Node.Text = NodeText Then
                    Return True
                End If
                If IncludeSubNodes Then
                    For Each SubNode In Node.Nodes
                        If SubNode.Text = NodeText Then
                            Return True
                        End If
                    Next
                End If
            Next
        Else
            For Each Node In Me.Nodes
                If Node.Text = NodeText Then
                    Return True
                End If
                If IncludeSubNodes Then
                    For Each SubNode In Node.Nodes
                        If SubNode.Text = NodeText Then
                            Return True
                        End If
                    Next
                End If
            Next
        End If
        Return False
    End Function
    Public Function FindNode(ByVal NodeText As String, Optional ByVal IncludeSubNodes As Boolean = False, Optional ByVal SearchNode As TreeNode = Nothing) As TreeNode
        Dim Node As TreeNode
        Dim SubNode As TreeNode
        If Not SearchNode Is Nothing Then
            For Each Node In SearchNode.Nodes
                If Node.Text = NodeText Then
                    Return Node
                End If
                If IncludeSubNodes Then
                    For Each SubNode In Node.Nodes
                        If SubNode.Text = NodeText Then
                            Return SubNode
                        End If
                    Next
                End If
            Next
        Else
            For Each Node In Me.Nodes
                If Node.Text = NodeText Then
                    Return Node
                End If
                If IncludeSubNodes Then
                    For Each SubNode In Node.Nodes
                        If SubNode.Text = NodeText Then
                            Return SubNode
                        End If
                    Next
                End If
            Next
        End If
        Return Nothing
    End Function
    Public Sub ExpandPath(ByVal FullPath As String)
        Dim Node As TreeNode = Nothing
        Dim TempPath As String
        Dim index As Integer
        Try
            index = FullPath.IndexOf(Me.PathSeparator)
            While index >= 0
                TempPath = FullPath.Substring(0, index)
                Node = FindNode(TempPath, False, Node)
                Node.Expand()
                FullPath = FullPath.Substring(index + 1)
                index = FullPath.IndexOf(Me.PathSeparator)
            End While
            If FullPath.Length > 0 Then
                Node = FindNode(FullPath, False, Node)
            End If
            Navigating = True
            Me.SelectedNode = Node
            Navigating = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Blink(ByVal Node As TreeNode, ByVal Color As Color, Optional ByVal Expand As Boolean = False, Optional ByVal Times As Integer = 5)
        BlinkingNode = Node
        BlinkColor = Color
        BlinkingTimes = Times
        If Expand Then
            ExpandPath(Node.FullPath)
        End If
        tmrBlink.Enabled = True
    End Sub
    Public Sub NavigateBack()
        If CurrentNavIndex > 0 Then
            Navigating = True
            CurrentNavIndex -= 1
            Me.SelectedNode = NavigatedNodes(CurrentNavIndex)
            Navigating = False
            RaiseEvent NavigatingBack()
        End If
    End Sub
    Public Sub NavigateForward()
        If NavigatedNodes Is Nothing Then
            Exit Sub
        End If
        If CurrentNavIndex < NavigatedNodes.Length - 2 Then
            CurrentNavIndex += 1
            Navigating = True
            Me.SelectedNode = NavigatedNodes(CurrentNavIndex)
            Navigating = False
            RaiseEvent NavigatingForward()
        End If
    End Sub
    Public Sub ChangeNodePathColor(ByVal Node As TreeNode, ByVal Color As Color)
        On Error GoTo Leave
        While Not Node Is Nothing
            Node = Node.Parent
            Node.ForeColor = Color
        End While
Leave:
    End Sub
    Public Sub Edit()
        txtEdit.Size = Me.SelectedNode.Bounds.Size
        txtEdit.Width *= 2
        txtEdit.Left = Me.SelectedNode.Bounds.Left + Me.Left
        txtEdit.Top = Me.SelectedNode.Bounds.Top + Me.Top
        txtEdit.Text = Me.SelectedNode.Text
        Me.FindForm.Controls.Add(txtEdit)
        txtEdit.Show()
        txtEdit.BringToFront()
        txtEdit.Focus()
        RaiseEvent BeginNodeEdit()
    End Sub
#End Region

#Region "Funciones privadas"
    Private Sub tmrBlink_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrBlink.Tick
        Static NColor As Color = BlinkingNode.ForeColor
        Static Times As Integer
        If BlinkingNode.ForeColor.ToArgb = NColor.ToArgb Then
            BlinkingNode.ForeColor = BlinkColor
        Else
            BlinkingNode.ForeColor = NColor
            Times += 1
        End If
        If Times = BlinkingTimes Then
            tmrBlink.Enabled = False
            Times = 0
        End If
    End Sub
    Private Sub FullControlTreeView_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles MyBase.BeforeSelect
        If Me.SelectedNode Is Nothing Then
            Exit Sub
        End If
        _PrevVisitedNode = Me.SelectedNode
        If Not Navigating Then
            ReDim Preserve NavigatedNodes(CurrentNavIndex + 1)
        End If
    End Sub
    Private Sub FullControlTreeView_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles MyBase.AfterSelect
        If Not _PrevVisitedNode Is Nothing Then
            _PrevVisitedNode.ForeColor = Me.ForeColor
            ChangeNodePathColor(_PrevVisitedNode, Me.ForeColor)
        End If
        If _ChangeSelectedNodeColor Then
            Me.SelectedNode.ForeColor = _SelectedNodeColor
        End If
        If _ChangeSelectedNodePathColor Then
            ChangeNodePathColor(Me.SelectedNode, _SelectedNodePathColor)
        End If
        If Not Navigating Then
            If Not _PrevVisitedNode Is Nothing Then
                NavigatedNodes(CurrentNavIndex) = _PrevVisitedNode
            End If
            CurrentNavIndex += 1
        End If
    End Sub
    Private Sub txtEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEdit.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtEdit.Visible = False
            Me.SelectedNode.Text = Trim(txtEdit.Text)
            RaiseEvent EndNodeEdit()
        ElseIf Asc(e.KeyChar) = 27 Then
            txtEdit.Visible = False
            RaiseEvent EndNodeEdit()
        End If
    End Sub
    Private Sub txtEdit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEdit.Leave
        txtEdit.Visible = False
        RaiseEvent CancelNodeEdit()
    End Sub
#End Region

#Region "Propiedades"
    Property ChangeSelectedNodeColor() As Boolean
        Get
            Return _ChangeSelectedNodeColor
        End Get
        Set(ByVal Value As Boolean)
            _ChangeSelectedNodeColor = Value
            If Not Me.SelectedNode Is Nothing Then
                If Value = True Then
                    Me.SelectedNode.ForeColor = _SelectedNodeColor
                Else
                    Me.ForeColor = Me.ForeColor
                End If
            End If
        End Set
    End Property
    Property ChangeSelectedNodePathColor() As Boolean
        Get
            Return _ChangeSelectedNodePathColor
        End Get
        Set(ByVal Value As Boolean)
            _ChangeSelectedNodePathColor = Value
            If Not Me.SelectedNode Is Nothing Then
                If Value = True Then
                    ChangeNodePathColor(Me.SelectedNode, _SelectedNodePathColor)
                Else
                    ChangeNodePathColor(Me.SelectedNode, Me.ForeColor)
                End If
            End If
        End Set
    End Property
    Property SelectedNodeColor() As Color
        Get
            Return _SelectedNodeColor
        End Get
        Set(ByVal Value As Color)
            _SelectedNodeColor = Value
            If _ChangeSelectedNodeColor And Not Me.SelectedNode Is Nothing Then
                Me.SelectedNode.ForeColor = _SelectedNodeColor
            End If
        End Set
    End Property
    Property SelectedNodePathColor() As Color
        Get
            Return _SelectedNodePathColor
        End Get
        Set(ByVal Value As Color)
            _SelectedNodePathColor = Value
            If _ChangeSelectedNodePathColor And Not Me.SelectedNode Is Nothing Then
                ChangeNodePathColor(Me.SelectedNode, _SelectedNodePathColor)
            End If
        End Set
    End Property
    ReadOnly Property SelectedNodePath() As String
        Get
            Dim Node As TreeNode = Me.SelectedNode
            Dim Resultado As String
            If Not Node Is Nothing Then
                Resultado = Node.Text
                While Not Node.Parent Is Nothing
                    Node = Node.Parent
                    Resultado = Node.Text & "\" & Resultado
                End While
                Return Resultado
            Else
                Return ""
            End If
        End Get
    End Property
#End Region

#Region "Eventos"
    Public Event NavigatingBack()
    Public Event NavigatingForward()
    Public Event BeginNodeEdit()
    Public Event EndNodeEdit()
    Public Event CancelNodeEdit()
#End Region



End Class

Imports System.Windows.Forms
Public Class Observaciones
    Inherits System.Windows.Forms.Form
    Private _Observaciones As String

    Public Property Observaciones() As String
        Get
            Return _Observaciones
        End Get
        Set(ByVal Value As String)
            _Observaciones = Value
        End Set
    End Property

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents imgLista16 As System.Windows.Forms.ImageList
    Friend WithEvents tbbAceptar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbCancelar As System.Windows.Forms.ToolBarButton
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents tbBarra As System.Windows.Forms.ToolBar
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Observaciones))
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.tbBarra = New System.Windows.Forms.ToolBar()
        Me.tbbAceptar = New System.Windows.Forms.ToolBarButton()
        Me.tbbCancelar = New System.Windows.Forms.ToolBarButton()
        Me.imgLista16 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtObservaciones.AutoSize = False
        Me.txtObservaciones.BackColor = System.Drawing.Color.Azure
        Me.txtObservaciones.Location = New System.Drawing.Point(0, 24)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(336, 216)
        Me.txtObservaciones.TabIndex = 0
        Me.txtObservaciones.Text = ""
        '
        'tbBarra
        '
        Me.tbBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbBarra.AutoSize = False
        Me.tbBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbbAceptar, Me.tbbCancelar})
        Me.tbBarra.ButtonSize = New System.Drawing.Size(16, 16)
        Me.tbBarra.DropDownArrows = True
        Me.tbBarra.ImageList = Me.imgLista16
        Me.tbBarra.Name = "tbBarra"
        Me.tbBarra.ShowToolTips = True
        Me.tbBarra.Size = New System.Drawing.Size(336, 22)
        Me.tbBarra.TabIndex = 1
        '
        'tbbAceptar
        '
        Me.tbbAceptar.ImageIndex = 0
        Me.tbbAceptar.Tag = "Aceptar"
        Me.tbbAceptar.ToolTipText = "Aceptar"
        '
        'tbbCancelar
        '
        Me.tbbCancelar.ImageIndex = 1
        Me.tbbCancelar.Tag = "Cancelar"
        Me.tbbCancelar.ToolTipText = "Cancelar"
        '
        'imgLista16
        '
        Me.imgLista16.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista16.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista16.ImageStream = CType(resources.GetObject("imgLista16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista16.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(304, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(8, 8)
        Me.btnCancelar.TabIndex = 2
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(296, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(8, 8)
        Me.btnAceptar.TabIndex = 3
        '
        'Observaciones
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(336, 237)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbBarra, Me.txtObservaciones, Me.btnAceptar, Me.btnCancelar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "Observaciones"
        Me.Text = "Observaciones"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal Observaciones As String)
        MyBase.New()
        InitializeComponent()
        _Observaciones = Observaciones
        txtObservaciones.Text = _Observaciones
    End Sub

    Private Sub tbBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case Is = "Aceptar"
                Aceptar()
            Case Is = "Cancelar"
                Me.DialogResult = DialogResult.Cancel
        End Select
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Aceptar()
    End Sub

    Private Sub Aceptar()
        _Observaciones = Trim(txtObservaciones.Text)
        Me.DialogResult = DialogResult.OK
    End Sub
End Class

Public Class Iconos
    Inherits System.ComponentModel.Component

#Region " Component Designer generated code "

    Public Sub New(Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(me)
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    Friend WithEvents imgListaBase As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Iconos))
        Me.imgListaBase = New System.Windows.Forms.ImageList(Me.components)
        '
        'imgListaBase
        '
        Me.imgListaBase.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgListaBase.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgListaBase.ImageStream = CType(resources.GetObject("imgListaBase.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgListaBase.TransparentColor = System.Drawing.Color.Transparent

    End Sub

#End Region

End Class

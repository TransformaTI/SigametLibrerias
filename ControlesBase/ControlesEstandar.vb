Option Strict On
Option Explicit On 
Imports System.ComponentModel
<Description("Textbox base para el sistema")> _
Public Class TextBoxBase
    Inherits System.Windows.Forms.TextBox

#Region " Component Designer generated code "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        '
        'TextBoxBase
        '

    End Sub

#End Region

    Private Sub TextBoxBase_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter
        Me.SelectAll()
    End Sub
End Class

<Description("Botón base para el sistema")> _
Public Class BotonBase
    Inherits Windows.Forms.Button

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Width = 80
        Me.Height = 24

    End Sub
End Class

<Description("Label base para el sistema")> _
Public Class LabelBase
    Inherits Windows.Forms.Label

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.AutoSize = True
    End Sub
End Class

<Description("Toolbar base para los catálogos del sistema.")> _
Public Class ToolBarBase
    Inherits Windows.Forms.ToolBar

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal TipoToolBar As String)
        MyBase.New()
        InicializaToolBar(TipoToolBar)
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim objIconos As New ControlesBase.Iconos()
        Me.ImageList = objIconos.imgListaBase
        Me.Appearance = Windows.Forms.ToolBarAppearance.Flat
        Me.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
        Me.Wrappable = False

        Dim btnAgregar As New Windows.Forms.ToolBarButton()
        With btnAgregar
            .Text = "Agregar"
            .Tag = "Agregar"
            .ToolTipText = "Agregar registro"
            .ImageIndex = 0
        End With
        Me.Buttons.Add(btnAgregar)
        btnAgregar = Nothing

        Dim btnEliminar As New Windows.Forms.ToolBarButton()
        With btnEliminar
            .Text = "Eliminar"
            .Tag = "Eliminar"
            .ToolTipText = "Eliminar registro"
            .ImageIndex = 1
        End With
        Me.Buttons.Add(btnEliminar)
        btnEliminar = Nothing

        Dim btnModificar As New Windows.Forms.ToolBarButton()
        With btnModificar
            .Text = "Modificar"
            .Tag = "Modificar"
            .ToolTipText = "Modificar registro"
            .ImageIndex = 2
        End With
        Me.Buttons.Add(btnModificar)
        btnModificar = Nothing

        Dim btnConsultar As New Windows.Forms.ToolBarButton()
        With btnConsultar
            .Text = "Consultar"
            .Tag = "Consultar"
            .ToolTipText = "Consultar registro"
            .ImageIndex = 3
        End With
        Me.Buttons.Add(btnConsultar)
        btnConsultar = Nothing

        Dim btnSep As New Windows.Forms.ToolBarButton()
        btnSep.Style = Windows.Forms.ToolBarButtonStyle.Separator
        Me.Buttons.Add(btnSep)

        Dim btnBuscar As New Windows.Forms.ToolBarButton()
        With btnBuscar
            .Text = "Buscar"
            .Tag = "Buscar"
            .ToolTipText = "Buscar registro"
            .ImageIndex = 4
        End With
        Me.Buttons.Add(btnBuscar)
        btnBuscar = Nothing
        Me.Buttons.Add(btnSep)

        Dim btnImprimir As New Windows.Forms.ToolBarButton()
        With btnImprimir
            .Text = "Imprimir"
            .Tag = "Imprimir"
            .ToolTipText = "Imprimir"
            .ImageIndex = 5
        End With
        Me.Buttons.Add(btnImprimir)
        btnImprimir = Nothing
        Me.Buttons.Add(btnSep)

        Dim btnRefrescar As New Windows.Forms.ToolBarButton()
        With btnRefrescar
            .Text = "Refrescar"
            .Tag = "Refrescar"
            .ToolTipText = "Refrescar información"
            .ImageIndex = 6
        End With
        Me.Buttons.Add(btnRefrescar)
        btnRefrescar = Nothing
        Me.Buttons.Add(btnSep)

        Dim btnCerrar As New Windows.Forms.ToolBarButton()
        With btnCerrar
            .Text = "Cerrar"
            .Tag = "Cerrar"
            .ToolTipText = "Cerrar"
            .ImageIndex = 7
        End With
        Me.Buttons.Add(btnCerrar)
        btnCerrar = Nothing
        btnSep = Nothing
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InicializaToolBar(ByVal TipoToolbar As String)
        If TipoToolbar = "CHEQUE" Then
            Dim objIconos As New ControlesBase.Iconos()
            Me.ImageList = objIconos.imgListaBase
            Me.Appearance = Windows.Forms.ToolBarAppearance.Flat
            Me.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            Me.Wrappable = False

            Dim btnModificar As New Windows.Forms.ToolBarButton()
            With btnModificar
                .Text = "Modificar"
                .Tag = "Modificar"
                .ToolTipText = "Modificar cheque"
                .ImageIndex = 2
            End With
            Me.Buttons.Add(btnModificar)
            btnModificar = Nothing

            Dim btnConsultar As New Windows.Forms.ToolBarButton()
            With btnConsultar
                .Text = "Consultar"
                .Tag = "Consultar"
                .ToolTipText = "Consultar cheques"
                .ImageIndex = 3
            End With
            Me.Buttons.Add(btnConsultar)
            btnConsultar = Nothing

            Dim btnSep As New Windows.Forms.ToolBarButton()
            btnSep.Style = Windows.Forms.ToolBarButtonStyle.Separator
            Me.Buttons.Add(btnSep)

            Dim btnDevCheque As New Windows.Forms.ToolBarButton()
            With btnDevCheque
                .Text = "Devolver"
                .Tag = "Devolver"
                .ToolTipText = "Devolver cheque"
                .ImageIndex = 8
            End With
            Me.Buttons.Add(btnDevCheque)
            btnDevCheque = Nothing
            Me.Buttons.Add(btnSep)

            Dim btnBuscar As New Windows.Forms.ToolBarButton()
            With btnBuscar
                .Text = "Buscar"
                .Tag = "Buscar"
                .ToolTipText = "Buscar cheque"
                .ImageIndex = 4
            End With
            Me.Buttons.Add(btnBuscar)
            btnBuscar = Nothing
            Me.Buttons.Add(btnSep)

            Dim btnImprimir As New Windows.Forms.ToolBarButton()
            With btnImprimir
                .Text = "Imprimir"
                .Tag = "Imprimir"
                .ToolTipText = "Imprimir"
                .ImageIndex = 5
            End With
            Me.Buttons.Add(btnImprimir)
            btnImprimir = Nothing
            Me.Buttons.Add(btnSep)

            Dim btnRefrescar As New Windows.Forms.ToolBarButton()
            With btnRefrescar
                .Text = "Refrescar"
                .Tag = "Refrescar"
                .ToolTipText = "Refrescar información"
                .ImageIndex = 6
            End With
            Me.Buttons.Add(btnRefrescar)
            btnRefrescar = Nothing
            Me.Buttons.Add(btnSep)

            Dim btnCerrar As New Windows.Forms.ToolBarButton()
            With btnCerrar
                .Text = "Cerrar"
                .Tag = "Cerrar"
                .ToolTipText = "Cerrar"
                .ImageIndex = 7
            End With
            Me.Buttons.Add(btnCerrar)
            btnCerrar = Nothing
            btnSep = Nothing
        End If
        If TipoToolbar = "CONTROLFACTURAS" Then
            Dim objIconos As New ControlesBase.Iconos()
            Me.ImageList = objIconos.imgListaBase
            Me.Appearance = Windows.Forms.ToolBarAppearance.Flat
            Me.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            Me.Wrappable = False

            Dim btnAgregar As New Windows.Forms.ToolBarButton()
            With btnAgregar
                .Text = "Agregar"
                .Tag = "Agregar"
                .ToolTipText = "Agregar registro"
                .ImageIndex = 0
            End With
            Me.Buttons.Add(btnAgregar)
            btnAgregar = Nothing

            Dim btnConsultar As New Windows.Forms.ToolBarButton()
            With btnConsultar
                .Text = "Consultar"
                .Tag = "Consultar"
                .ToolTipText = "Consultar registro"
                .ImageIndex = 3
            End With
            Me.Buttons.Add(btnConsultar)
            btnConsultar = Nothing

            Dim btnSep As New Windows.Forms.ToolBarButton()
            btnSep.Style = Windows.Forms.ToolBarButtonStyle.Separator
            Me.Buttons.Add(btnSep)

            Dim btnRefrescar As New Windows.Forms.ToolBarButton()
            With btnRefrescar
                .Text = "Refrescar"
                .Tag = "Refrescar"
                .ToolTipText = "Refrescar información"
                .ImageIndex = 6
            End With
            Me.Buttons.Add(btnRefrescar)
            btnRefrescar = Nothing
            Me.Buttons.Add(btnSep)

            Dim btnCerrar As New Windows.Forms.ToolBarButton()
            With btnCerrar
                .Text = "Cerrar"
                .Tag = "Cerrar"
                .ToolTipText = "Cerrar"
                .ImageIndex = 7
            End With
            Me.Buttons.Add(btnCerrar)
            btnCerrar = Nothing
            btnSep = Nothing
        End If
    End Sub
End Class
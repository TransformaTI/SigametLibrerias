Imports System.Data.SqlClient
Imports System.Xml



Public Class ComboCalle
    Inherits System.Windows.Forms.ComboBox

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Height = 21
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        Catch
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'ComboCalle
        '
        Me.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.ItemHeight = 13
        Me.Size = New System.Drawing.Size(121, 21)

    End Sub



#End Region

    Private _Iniciales As String
    Private _CargaDatos As Boolean = True


    Property CargaDatos() As Boolean
        Get
            Return _CargaDatos
        End Get
        Set(ByVal Value As Boolean)
            _CargaDatos = Value
        End Set
    End Property


    Private Sub cboCalle_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter
        Me.Height = 100
        Me.BringToFront()
    End Sub
    Private Sub cboCalle_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        Me.Height = 21
        If Me.SelectedIndex < 0 AndAlso Me.FindString(Me.Text) > -1 Then
            Me.SelectedIndex = Me.FindString(Me.Text)
        ElseIf Me.SelectedIndex = -1 Then
            _CargaDatos = False
            Me.Text = "SIN CALLE"
            _CargaDatos = True
        End If
    End Sub
    Private Sub ComboCalle_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
        If _CargaDatos AndAlso ((Me.Text.Length = 3 AndAlso Me.Text <> _Iniciales) OrElse (Me.Text.Length > 3 AndAlso Me.Items.Count = 0)) Then
            CargaCalles()
            _Iniciales = Me.Text.Substring(0, 3)
        End If
    End Sub

    Private Sub CargaCalles()
        Dim XDoc As New XmlDocument()
        Dim XNodes As XmlNodeList
        Dim xnode As XmlNode
        Dim Inicio As String = Me.Text
        Dim sr As New IO.StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\ListadoCalles.xml")

        XDoc.Load(sr)

        XNodes = XDoc.DocumentElement.SelectNodes("/Calles/Calle[starts-with(@Nombre,'" & Inicio.Substring(0, 3).ToUpper & "')]/.")
        Me.Items.Clear()
        Me.BeginUpdate()
        For Each xnode In XNodes
            Me.Items.Add(xnode.Attributes.GetNamedItem("Nombre").Value)
        Next
        Me.EndUpdate()
        Me.SelectionStart = Me.Text.Length
        XDoc = Nothing
        System.GC.Collect()
    End Sub

    Public Sub CargaCallesFromDoc(ByVal XMLDoc As XmlDocument)
        Dim XNodes As XmlNodeList
        Dim xnode As XmlNode
        Dim Inicio As String = Me.Text
        If Inicio.Length > 3 Then
            Inicio = Inicio.Substring(0, 3)
        End If
        XNodes = XMLDoc.DocumentElement.SelectNodes("/Calles/Calle[starts-with(@Nombre,'" & Inicio.ToUpper & "')]/.")
        Me.Items.Clear()
        Me.BeginUpdate()
        For Each xnode In XNodes
            Me.Items.Add(xnode.Attributes.GetNamedItem("Nombre").Value)
        Next
        Me.EndUpdate()
        Me.SelectionStart = Me.Text.Length
    End Sub

End Class

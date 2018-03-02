Option Strict On
Imports System.Data.SqlClient, System.Windows.Forms

Public Class Catalogo
    Inherits System.Windows.Forms.Form
    Private _NombreTabla As String
    Private _Campos() As String
    Private dt As DataTable

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
    Friend WithEvents grdCatalogo As System.Windows.Forms.DataGrid
    Friend WithEvents tbBarra As System.Windows.Forms.ToolBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grdCatalogo = New System.Windows.Forms.DataGrid()
        Me.tbBarra = New System.Windows.Forms.ToolBar()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.grdCatalogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdCatalogo
        '
        Me.grdCatalogo.DataMember = ""
        Me.grdCatalogo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdCatalogo.Location = New System.Drawing.Point(8, 56)
        Me.grdCatalogo.Name = "grdCatalogo"
        Me.grdCatalogo.Size = New System.Drawing.Size(408, 288)
        Me.grdCatalogo.TabIndex = 0
        '
        'tbBarra
        '
        Me.tbBarra.DropDownArrows = True
        Me.tbBarra.Name = "tbBarra"
        Me.tbBarra.ShowToolTips = True
        Me.tbBarra.Size = New System.Drawing.Size(528, 39)
        Me.tbBarra.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(432, 64)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        '
        'Catalogo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(528, 365)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.tbBarra, Me.grdCatalogo})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Catalogo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catalogo"
        CType(Me.grdCatalogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal NombreTabla As String, _
                   ByVal CampoLlave As String, _
                   ByVal Campos() As String)

        MyBase.New()
        InitializeComponent()
        _NombreTabla = NombreTabla
        _Campos = Campos
        CargaDatos()
    End Sub

    Private Sub CargaDatos()
        Dim strQuery As String = "Select "
        Dim _Field As String = ""
        For Each _Field In _Campos
            strQuery &= _Field & ","
        Next

        strQuery = strQuery.Substring(0, strQuery.Length - 1)

        strQuery &= " From " & _NombreTabla

        Dim da As New SqlDataAdapter(strQuery, DataLayer.Conexion)
        dt = New DataTable(_NombreTabla)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            grdCatalogo.DataSource = dt
        End If

    End Sub

    Private Sub grdCatalogo_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCatalogo.CurrentCellChanged
        grdCatalogo.Select(grdCatalogo.CurrentRowIndex)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frmCaptura As New CatalogoCaptura(CatalogoCaptura.enumTipoAccion.Agregar, dt)
        frmCaptura.ShowDialog()

    End Sub
End Class

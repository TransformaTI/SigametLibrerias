Option Strict On
Imports System.Data.SqlClient, System.Windows.Forms

Public Class InfoTripulacionTurno
    Inherits System.Windows.Forms.UserControl
    Private _AñoAtt As Short
    Private _Folio As Integer
    Private _Titulo As String = "Información de Tripulación"

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
    Friend WithEvents colOperador As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFALta As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCategoria As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents colNombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Public WithEvents lvwTripulacion As System.Windows.Forms.ListView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(InfoTripulacionTurno))
        Me.lvwTripulacion = New System.Windows.Forms.ListView()
        Me.colOperador = New System.Windows.Forms.ColumnHeader()
        Me.colCategoria = New System.Windows.Forms.ColumnHeader()
        Me.colNombre = New System.Windows.Forms.ColumnHeader()
        Me.colFALta = New System.Windows.Forms.ColumnHeader()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lvwTripulacion
        '
        Me.lvwTripulacion.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lvwTripulacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvwTripulacion.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colOperador, Me.colCategoria, Me.colNombre, Me.colFALta})
        Me.lvwTripulacion.FullRowSelect = True
        Me.lvwTripulacion.Name = "lvwTripulacion"
        Me.lvwTripulacion.Size = New System.Drawing.Size(488, 144)
        Me.lvwTripulacion.SmallImageList = Me.ImageList1
        Me.lvwTripulacion.TabIndex = 0
        Me.lvwTripulacion.View = System.Windows.Forms.View.Details
        '
        'colOperador
        '
        Me.colOperador.Text = "Operador"
        '
        'colCategoria
        '
        Me.colCategoria.Text = "Categoría"
        Me.colCategoria.Width = 80
        '
        'colNombre
        '
        Me.colNombre.Text = "Nombre"
        Me.colNombre.Width = 150
        '
        'colFALta
        '
        Me.colFALta.Text = "F.Alta"
        Me.colFALta.Width = 160
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'lblEstatus
        '
        Me.lblEstatus.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblEstatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstatus.Location = New System.Drawing.Point(0, 144)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(488, 16)
        Me.lblEstatus.TabIndex = 1
        '
        'InfoTripulacionTurno
        '
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEstatus, Me.lvwTripulacion})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "InfoTripulacionTurno"
        Me.Size = New System.Drawing.Size(488, 160)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Propiedades"
    Public Property AñoAtt() As Short
        Get
            Return _AñoAtt
        End Get
        Set(ByVal Value As Short)
            _AñoAtt = Value
        End Set
    End Property

    Public Property Folio() As Integer
        Get
            Return _Folio
        End Get
        Set(ByVal Value As Integer)
            _Folio = Value
        End Set
    End Property

    Public ReadOnly Property TotalTripulacion() As Byte
        Get
            Return CType(lvwTripulacion.Items.Count, Byte)
        End Get
    End Property
#End Region


    Public Sub New(ByVal AñoAtt As Short, ByVal Folio As Integer)
        MyBase.New()
        InitializeComponent()

        CargaDatos(AñoAtt, Folio)

    End Sub

    Public Sub CargaDatos(ByVal AñoAtt As Short, ByVal Folio As Integer)

        _AñoAtt = AñoAtt
        _Folio = Folio

        Cursor = Cursors.WaitCursor

        'TODO: Se deshabilitó porque falla con seguridad SQL
        'Dim conn As New SqlConnection(LeeInfoConexion(False, True))

        Dim conn As SqlConnection = DataLayer.Conexion

        Dim cmd As New SqlCommand("spCCConsultaTripulacionTurno", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = _AñoAtt
            .Parameters.Add("@Folio", SqlDbType.Int).Value = _Folio
        End With

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch
            MessageBox.Show(SigaMetClasses.M_NO_CONEXION, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cursor = Cursors.Default
            conn.Close()
            Exit Sub

        End Try

        Dim dr As SqlDataReader
        Dim item As ListViewItem

        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            lvwTripulacion.Items.Clear()
            ToolTip1.SetToolTip(lvwTripulacion, "")

            While dr.Read

                item = New ListViewItem(CType(dr("Operador"), String).Trim, 0)
                item.SubItems.Add(CType(dr("CategoriaOperadorDescripcion"), String).Trim)
                item.SubItems.Add(CType(dr("Nombre"), String).Trim)
                If Not IsDBNull(dr("FAlta")) Then
                    item.SubItems.Add(CType(dr("FAlta"), Date).ToString)
                End If

                lvwTripulacion.Items.Add(item)

            End While

            If lvwTripulacion.Items.Count > 0 Then
                lblEstatus.Text = "Lista de tripulantes del folio " & FormatoFolio() & " (" & lvwTripulacion.Items.Count.ToString & " en total)"
            Else
                lblEstatus.Text = "No existe tripulación para el folio " & FormatoFolio()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default

            If Not IsNothing(conn) Then
                If conn.State = ConnectionState.Open Then conn.Close()
            End If
        End Try

    End Sub

    Private Function FormatoFolio() As String
        Return "[" & _AñoAtt.ToString & "|" & _Folio.ToString & "]"
    End Function

    Private Sub lvwTripulacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwTripulacion.SelectedIndexChanged
        Me.ToolTip1.SetToolTip(lvwTripulacion, lvwTripulacion.FocusedItem.SubItems(2).Text.Trim)
    End Sub


    Public Overridable Sub lvwTripulacion_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwTripulacion.DoubleClick

    End Sub
End Class

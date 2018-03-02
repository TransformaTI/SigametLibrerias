Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class frmConsultaTripulacion
    Inherits System.Windows.Forms.Form
    

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
    Friend WithEvents gpbTripulacion As System.Windows.Forms.GroupBox
    Friend WithEvents grdTripulacion As System.Windows.Forms.DataGrid
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents col01 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col02 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col03 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConsultaTripulacion))
        Me.gpbTripulacion = New System.Windows.Forms.GroupBox()
        Me.grdTripulacion = New System.Windows.Forms.DataGrid()
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.col01 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col02 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col03 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.gpbTripulacion.SuspendLayout()
        CType(Me.grdTripulacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpbTripulacion
        '
        Me.gpbTripulacion.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdTripulacion})
        Me.gpbTripulacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbTripulacion.Location = New System.Drawing.Point(10, 10)
        Me.gpbTripulacion.Name = "gpbTripulacion"
        Me.gpbTripulacion.Size = New System.Drawing.Size(494, 199)
        Me.gpbTripulacion.TabIndex = 51
        Me.gpbTripulacion.TabStop = False
        Me.gpbTripulacion.Text = "Tripulación"
        '
        'grdTripulacion
        '
        Me.grdTripulacion.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdTripulacion.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdTripulacion.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdTripulacion.CaptionText = "Detalle de la tripulación"
        Me.grdTripulacion.DataMember = ""
        Me.grdTripulacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTripulacion.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTripulacion.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdTripulacion.Location = New System.Drawing.Point(11, 16)
        Me.grdTripulacion.Name = "grdTripulacion"
        Me.grdTripulacion.ReadOnly = True
        Me.grdTripulacion.Size = New System.Drawing.Size(471, 176)
        Me.grdTripulacion.TabIndex = 49
        Me.grdTripulacion.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.ImageList1
        Me.btnAceptar.Location = New System.Drawing.Point(521, 15)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 52
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.grdTripulacion
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col01, Me.col02, Me.col03})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = ""
        '
        'col01
        '
        Me.col01.Format = ""
        Me.col01.FormatInfo = Nothing
        Me.col01.HeaderText = "Nómina"
        Me.col01.MappingName = "Operador"
        Me.col01.Width = 75
        '
        'col02
        '
        Me.col02.Format = ""
        Me.col02.FormatInfo = Nothing
        Me.col02.HeaderText = "Nombre"
        Me.col02.MappingName = "Nombre"
        Me.col02.Width = 250
        '
        'col03
        '
        Me.col03.Format = ""
        Me.col03.FormatInfo = Nothing
        Me.col03.HeaderText = "Puesto"
        Me.col03.MappingName = "NombrePuesto"
        Me.col03.Width = 85
        '
        'frmConsultaTripulacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(610, 221)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAceptar, Me.gpbTripulacion})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmConsultaTripulacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta tripulación de la ruta"
        Me.gpbTripulacion.ResumeLayout(False)
        CType(Me.grdTripulacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Sub InicializaForma(ByVal Tripulacion As Integer)
        Dim oTripulacion As New PortatilClasses.CatalogosPortatil.cTripulacion(1, Tripulacion, False, 0)
        oTripulacion.ConsultarTripulacion()
        grdTripulacion.DataSource = oTripulacion.dtTable
        grdTripulacion.CaptionText = "Detalle de la tripulación (" & Tripulacion & " )"
        oTripulacion = Nothing
    End Sub
    Public Sub InicializaForma(ByVal dataViewTripulacion As DataView)
        Me.col03.MappingName = "CategoriaAsignada"
        grdTripulacion.DataSource = dataViewTripulacion
        grdTripulacion.CaptionText = "Detalle de la tripulación:"
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub
End Class

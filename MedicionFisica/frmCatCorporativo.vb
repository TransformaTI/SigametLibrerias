'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 26/08/2007
'Motivo: Se aumento el campo status en las pantallas de Corporativo
'Identificador de cambios: 20070426CAGP$002

Imports System.Windows.Forms
Imports System.Drawing

Public Class frmCatCorporativo
    Inherits Catalogo.frmCatalogo


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
    Friend WithEvents grdTableStyle As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents Col01 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col02 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Col03 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents txtInicial As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblInicial As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents Col04 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCatCorporativo))
        Me.grdTableStyle = New System.Windows.Forms.DataGridTableStyle()
        Me.Col01 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Col02 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Col03 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.txtInicial = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblInicial = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.Col04 = New System.Windows.Forms.DataGridTextBoxColumn()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDatos.SuspendLayout()
        Me.tabDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'Toolbar
        '
        Me.Toolbar.ImageStream = CType(resources.GetObject("Toolbar.ImageStream"), System.Windows.Forms.ImageListStreamer)
        '
        'BarraBotones
        '
        Me.BarraBotones.Size = New System.Drawing.Size(608, 38)
        Me.BarraBotones.Visible = True
        '
        'grdDatos
        '
        Me.grdDatos.AccessibleName = "DataGrid"
        Me.grdDatos.AccessibleRole = System.Windows.Forms.AccessibleRole.Table
        Me.grdDatos.CaptionText = "Catálogo de corporativo"
        Me.grdDatos.Size = New System.Drawing.Size(608, 248)
        Me.grdDatos.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.grdTableStyle})
        Me.grdDatos.Visible = True
        '
        'tpDatos
        '
        Me.tpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtInicial, Me.txtNombre, Me.lblInicial, Me.lblNombre})
        Me.tpDatos.Size = New System.Drawing.Size(776, 214)
        '
        'tabDatos
        '
        Me.tabDatos.ItemSize = New System.Drawing.Size(42, 18)
        Me.tabDatos.Location = New System.Drawing.Point(0, 288)
        Me.tabDatos.Size = New System.Drawing.Size(784, 240)
        Me.tabDatos.Visible = True
        '
        'grdTableStyle
        '
        Me.grdTableStyle.DataGrid = Me.grdDatos
        Me.grdTableStyle.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.Col01, Me.Col02, Me.Col03, Me.Col04})
        Me.grdTableStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdTableStyle.MappingName = ""
        '
        'Col01
        '
        Me.Col01.Format = ""
        Me.Col01.FormatInfo = Nothing
        Me.Col01.HeaderText = "Corporativo"
        Me.Col01.MappingName = "Corporativo"
        Me.Col01.Width = 80
        '
        'Col02
        '
        Me.Col02.Format = ""
        Me.Col02.FormatInfo = Nothing
        Me.Col02.HeaderText = "Nombre"
        Me.Col02.MappingName = "Nombre"
        Me.Col02.Width = 250
        '
        'Col03
        '
        Me.Col03.Format = ""
        Me.Col03.FormatInfo = Nothing
        Me.Col03.HeaderText = "Abreviación"
        Me.Col03.MappingName = "Inicial"
        Me.Col03.Width = 75
        '
        'txtInicial
        '
        Me.txtInicial.AutoSize = False
        Me.txtInicial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInicial.Enabled = False
        Me.txtInicial.Location = New System.Drawing.Point(169, 50)
        Me.txtInicial.MaxLength = 5
        Me.txtInicial.Name = "txtInicial"
        Me.txtInicial.Size = New System.Drawing.Size(240, 21)
        Me.txtInicial.TabIndex = 26
        Me.txtInicial.Text = ""
        '
        'txtNombre
        '
        Me.txtNombre.AutoSize = False
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Enabled = False
        Me.txtNombre.Location = New System.Drawing.Point(169, 22)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(240, 21)
        Me.txtNombre.TabIndex = 25
        Me.txtNombre.Text = ""
        '
        'lblInicial
        '
        Me.lblInicial.AutoSize = True
        Me.lblInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblInicial.Location = New System.Drawing.Point(25, 54)
        Me.lblInicial.Name = "lblInicial"
        Me.lblInicial.Size = New System.Drawing.Size(64, 13)
        Me.lblInicial.TabIndex = 28
        Me.lblInicial.Text = "Abreviación:"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblNombre.Location = New System.Drawing.Point(25, 26)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(119, 13)
        Me.lblNombre.TabIndex = 27
        Me.lblNombre.Text = "Nombre de corporativo:"
        '
        'Col04
        '
        Me.Col04.Format = ""
        Me.Col04.FormatInfo = Nothing
        Me.Col04.HeaderText = "Status"
        Me.Col04.MappingName = "Status"
        Me.Col04.NullText = ""
        Me.Col04.Width = 75
        '
        'frmCatCorporativo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(608, 406)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabDatos, Me.grdDatos, Me.BarraBotones})
        Me.Name = "frmCatCorporativo"
        Me.Text = "Catálogo de corporativo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDatos.ResumeLayout(False)
        Me.tabDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Crea una instancia de la clase cCorporativo para hacer la consulta del catálogo de corporativo
    'y así poder visualizarlo dentro del grid grdDatos del catálogo de corporativo
    Private Sub CargarDatos()
        Dim oCorporativo As New PortatilClasses.CatalogosPortatil.cCorporativo(0, 0, "", "", "")
        oCorporativo.ConsultarAlmacenGas()
        grdDatos.DataSource = oCorporativo.dtTable
        oCorporativo = Nothing
    End Sub

    'Evento de la forma del Catálogo de corporativo, este evento es disparado al momento de accesar a dicho catálogo
    'e inicializa la forma haciendo una consulta de todos los registros existentes y son mostrados en pantalla
    Private Sub frmCatAlmacenGas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        CargarDatos()
        'PermiteImprimir = False
        grdDatos_CurrentCellChanged(sender, e)
        Cursor = Cursors.Default
    End Sub

    'Evento que identifica cada uno de los botones que son presionados para acceder a cada una de las funciones
    'que se realizaran en cada uno de ellos (Agregar un almacen, modificar informacion, consultar, Imprimir, etc)
    Public Overrides Sub BarraBotones_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs)
        Select Case e.Button.Tag.ToString()
            Case Is = "Agregar"
                Dim frmCaptura As New frmCapCorporativo()
                frmCaptura._TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar
                frmCaptura.Text = "Corporativo - [Agregar]"
                If frmCaptura.ShowDialog() = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    CargarDatos()
                    Cursor = Cursors.Default
                End If
            Case Is = "Modificar"
                If CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), String) <> "" Then
                    Dim frmCaptura As New frmCapCorporativo()
                    frmCaptura._TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar
                    frmCaptura.Text = "Corporativo - [Modificar]"
                    frmCaptura.CargarDatosCorporativo(CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer))
                    If frmCaptura.ShowDialog() = DialogResult.OK Then
                        Cursor = Cursors.WaitCursor
                        CargarDatos()
                        Cursor = Cursors.Default
                    End If
                End If
            Case Is = "Eliminar"
                If CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), String) <> "" Then
                    Dim Mensajes As New PortatilClasses.Mensaje(68)
                    If MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        Dim oCorporativo As New PortatilClasses.CatalogosPortatil.cCorporativo(4, CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer), "", "", "")
                        oCorporativo.RegistrarModificarEliminar()
                        Cursor = Cursors.WaitCursor
                        CargarDatos()
                        Cursor = Cursors.Default
                    End If
                End If
            Case Is = "Consultar"
                If CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), String) <> "" Then
                    Dim frmCaptura As New frmCapCorporativo()
                    frmCaptura._TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Consultar
                    frmCaptura.Text = "Corporativo - [Consultar]"
                    frmCaptura.CargarDatosCorporativo(CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer))
                    If frmCaptura.ShowDialog() = DialogResult.OK Then
                        Cursor = Cursors.WaitCursor
                        CargarDatos()
                        Cursor = Cursors.Default
                    End If
                End If
            Case Is = "Refrescar"
                Cursor = Cursors.WaitCursor
                CargarDatos()
                Cursor = Cursors.Default
            Case Is = "Cerrar"
                Me.Close()
        End Select
    End Sub

    'Evento en el grid grdDatos que al posicionarse en un registro nos permite actualizar
    'la informacion que se encuientra en el area de Datos de la forma, mostrados el nombre
    'y la abreviacion del registro actual
    Public Overrides Sub grdDatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If grdDatos.CurrentRowIndex > -1 Then
            txtNombre.Text = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 1), String)
            txtInicial.Text = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 2), String)
        Else
            txtNombre.Text = ""
            txtInicial.Text = ""
        End If
    End Sub
End Class


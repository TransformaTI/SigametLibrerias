'Clase de la forma principal del catálogo de tripulaciones, por medio de esta
'forma se pueden dar de alta, modificar, consultar, eliminar e imprimir información
'de cada una de las tripulacion que iran a bordo en la unidades de gas portátil


Imports System.Windows.Forms

Public Class frmCatTripulacion
    Inherits Catalogo.frmCatalogo

    Private dtTripulacion As DataTable

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Usuario As String, ByVal RutaReportes As String, ByVal Servidor As String, _
    ByVal BaseDeDatos As String, ByVal Password As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        GLOBAL_Usuario = Usuario
        GLOBAL_Usuario = Usuario
        GLOBAL_Servidor = Servidor
        GLOBAL_BaseDatos = BaseDeDatos
        GLOBAL_Password = Password
        GLOBAL_RutaReportes = RutaReportes
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
    Friend WithEvents cboAlmacenGas As PortatilClasses.Combo.ComboAlmacen
    'Friend WithEvents cboAlmacenGas As PortatilClasses.Combo.ComboAlmacen

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Public WithEvents grdTripulacion As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents col04 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col02 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col03 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lblAlmacen As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatTripulacion))
        Me.cboAlmacenGas = New PortatilClasses.Combo.ComboAlmacen()
        Me.grdTripulacion = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle()
        Me.col = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col02 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col03 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col04 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDatos.SuspendLayout()
        Me.tabDatos.SuspendLayout()
        CType(Me.grdTripulacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdDatos
        '
        Me.grdDatos.AccessibleName = "DataGrid"
        Me.grdDatos.AccessibleRole = System.Windows.Forms.AccessibleRole.Table
        Me.grdDatos.CaptionText = "Catálogo de tripulación de ruta"
        Me.grdDatos.Location = New System.Drawing.Point(0, 38)
        Me.grdDatos.Size = New System.Drawing.Size(672, 184)
        Me.grdDatos.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle2})
        '
        'tpDatos
        '
        Me.tpDatos.Controls.Add(Me.grdTripulacion)
        Me.tpDatos.Size = New System.Drawing.Size(840, 278)
        '
        'BarraBotones
        '
        Me.BarraBotones.Size = New System.Drawing.Size(672, 42)
        '
        'Toolbar
        '
        Me.Toolbar.ImageStream = CType(resources.GetObject("Toolbar.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Toolbar.Images.SetKeyName(0, "")
        Me.Toolbar.Images.SetKeyName(1, "")
        Me.Toolbar.Images.SetKeyName(2, "")
        Me.Toolbar.Images.SetKeyName(3, "")
        Me.Toolbar.Images.SetKeyName(4, "")
        Me.Toolbar.Images.SetKeyName(5, "")
        Me.Toolbar.Images.SetKeyName(6, "")
        '
        'tabDatos
        '
        Me.tabDatos.ItemSize = New System.Drawing.Size(42, 18)
        Me.tabDatos.Location = New System.Drawing.Point(-4, 223)
        Me.tabDatos.Size = New System.Drawing.Size(848, 304)
        '
        'cboAlmacenGas
        '
        Me.cboAlmacenGas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAlmacenGas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacenGas.Location = New System.Drawing.Point(488, 9)
        Me.cboAlmacenGas.Name = "cboAlmacenGas"
        Me.cboAlmacenGas.Size = New System.Drawing.Size(176, 21)
        Me.cboAlmacenGas.TabIndex = 4
        '
        'grdTripulacion
        '
        Me.grdTripulacion.AccessibleRole = System.Windows.Forms.AccessibleRole.Table
        Me.grdTripulacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdTripulacion.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdTripulacion.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdTripulacion.CaptionText = "Detalle de la tripulación"
        Me.grdTripulacion.DataMember = ""
        Me.grdTripulacion.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdTripulacion.Location = New System.Drawing.Point(-2, 0)
        Me.grdTripulacion.Name = "grdTripulacion"
        Me.grdTripulacion.ReadOnly = True
        Me.grdTripulacion.Size = New System.Drawing.Size(737, 264)
        Me.grdTripulacion.TabIndex = 0
        Me.grdTripulacion.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.grdTripulacion
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Nómina"
        Me.DataGridTextBoxColumn1.MappingName = "Operador"
        Me.DataGridTextBoxColumn1.Width = 60
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Nombre"
        Me.DataGridTextBoxColumn2.MappingName = "Nombre"
        Me.DataGridTextBoxColumn2.Width = 250
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Categoria"
        Me.DataGridTextBoxColumn4.MappingName = "DescripcionCategoriaOperador"
        Me.DataGridTextBoxColumn4.Width = 125
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Tipo"
        Me.DataGridTextBoxColumn3.MappingName = "DescripcionTipoOperador"
        Me.DataGridTextBoxColumn3.Width = 65
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Tipo de asignación"
        Me.DataGridTextBoxColumn5.MappingName = "DescripcionTipoAsignacionOperador"
        Me.DataGridTextBoxColumn5.Width = 170
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Puesto"
        Me.DataGridTextBoxColumn6.MappingName = "NombrePuesto"
        Me.DataGridTextBoxColumn6.Width = 200
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.DataGrid = Me.grdDatos
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col, Me.col02, Me.col03, Me.col04})
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        '
        'col
        '
        Me.col.Format = ""
        Me.col.FormatInfo = Nothing
        Me.col.HeaderText = "Tripulación"
        Me.col.MappingName = "Tripulacion"
        Me.col.Width = 75
        '
        'col02
        '
        Me.col02.Format = ""
        Me.col02.FormatInfo = Nothing
        Me.col02.HeaderText = "Tipo"
        Me.col02.MappingName = "Titular"
        Me.col02.Width = 75
        '
        'col03
        '
        Me.col03.Format = ""
        Me.col03.FormatInfo = Nothing
        Me.col03.HeaderText = "Almacén de gas"
        Me.col03.MappingName = "AlmacenGas"
        Me.col03.Width = 220
        '
        'col04
        '
        Me.col04.Format = ""
        Me.col04.FormatInfo = Nothing
        Me.col04.HeaderText = "Alta"
        Me.col04.MappingName = "FAlta"
        Me.col04.Width = 70
        '
        'lblAlmacen
        '
        Me.lblAlmacen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAlmacen.BackColor = System.Drawing.SystemColors.Control
        Me.lblAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblAlmacen.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlmacen.Location = New System.Drawing.Point(385, 12)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(96, 16)
        Me.lblAlmacen.TabIndex = 6
        Me.lblAlmacen.Text = "Almacén de gas:"
        '
        'frmCatTripulacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(672, 413)
        Me.Controls.Add(Me.lblAlmacen)
        Me.Controls.Add(Me.cboAlmacenGas)
        Me.Name = "frmCatTripulacion"
        Me.Text = "Catálogo de tripulación de ruta"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.BarraBotones, 0)
        Me.Controls.SetChildIndex(Me.grdDatos, 0)
        Me.Controls.SetChildIndex(Me.tabDatos, 0)
        Me.Controls.SetChildIndex(Me.cboAlmacenGas, 0)
        Me.Controls.SetChildIndex(Me.lblAlmacen, 0)
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDatos.ResumeLayout(False)
        Me.tabDatos.ResumeLayout(False)
        CType(Me.grdTripulacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    'Crea una instancia de la clase cTripulacion para hacer la consulta del catálogo de tripulación
    'y así poder visualizarlo dentro del grid grdDatos del catálogo de Tripulacion
    Private Sub CargarLista()
        Dim oTripulacion As New PortatilClasses.CatalogosPortatil.cTripulacion(0, 0, False, 0)
        oTripulacion.ConsultarTripulacion()
        dtTripulacion = oTripulacion.dtTable
        grdDatos.DataSource = dtTripulacion
        oTripulacion = Nothing
        cboAlmacenGas.PosicionarInicio()
    End Sub

    'Evento que es disparado al momento de inicializar la forma principal del catalogo
    'de tripulacion
    Private Sub FrmCatTripulacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        cboAlmacenGas.CargaDatos(1, GLOBAL_Usuario)
        CargarLista()
        grdDatos_CurrentCellChanged(sender, e)
        PermiteImprimir = False
        'PermiteEliminar = False
        'PermiteConsultar = False
        Cursor = Cursors.Default
    End Sub

    'Evento que es disparado al momento de seleccionar un item diferente al actual en el combo
    'cboAlmacenGas para realizar una nueva consulta de las tripulaciones
    'pertenecientes al almacen seleccionado
    Private Sub cboAlmacenGas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAlmacenGas.SelectedIndexChanged 'Handles cboAlmacenGas.SelectedIndexChanged
        If cboAlmacenGas.Focused And cboAlmacenGas.SelectedIndex > -1 Then
            If CType(cboAlmacenGas.Identificador, Short) > 0 Then
                dtTripulacion.DefaultView.RowFilter = "Almacen = " & CType(cboAlmacenGas.Identificador, Short)
                grdDatos_CurrentCellChanged(sender, e)
            Else
                dtTripulacion.DefaultView.RowFilter = ""
                grdDatos_CurrentCellChanged(sender, e)
            End If
        End If
        If cboAlmacenGas.Focused And cboAlmacenGas.SelectedIndex = -1 Then
            dtTripulacion.DefaultView.RowFilter = ""
        End If
    End Sub

    'Evento que es dispardo al momento de presionar alguna tecla teniendo el control
    'dentro del componente cboAlmacenGas
    Private Sub cboAlmacenGas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAlmacenGas.KeyDown
        If Keys.Delete = Keys.Delete Then
            cboAlmacenGas.PosicionarInicio()
        End If
    End Sub

    'Evento que es disparado al momento de seleccionar un registro en el grid donde
    'se encuentra la informacion general de cada tripulacion
    Public Overrides Sub grdDatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If dtTripulacion.Rows.Count > 0 And grdDatos.CurrentRowIndex > -1 Then
            Dim oTripulacion As New PortatilClasses.CatalogosPortatil.cTripulacion(1, CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer), False, 0)
            oTripulacion.ConsultarTripulacion()
            grdTripulacion.DataSource = oTripulacion.dtTable
            grdTripulacion.CaptionText = "Detalle de la tripulación (" & CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), String) & " )"
            oTripulacion = Nothing
        Else
            grdTripulacion.DataSource = Nothing
            grdTripulacion.CaptionText = "Detalle de la tripulación"
        End If
    End Sub

    'Evento que identifica cada uno de los botones que son presionados para acceder a cada una de las funciones
    'que se realizaran en cada uno de ellos (Agregar un almacen, modificar informacion, consultar, Imprimir, etc)
    Public Overrides Sub BarraBotones_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs)
        Select Case e.Button.Tag.ToString()
            Case Is = "Agregar"
                Dim frmCaptura As New frmCapTripulacion(GLOBAL_Usuario)
                frmCaptura._TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar
                frmCaptura.Text = "Tripúlación de ruta de venta - [Agregar]"

                Try
                    If frmCaptura.ShowDialog() = DialogResult.OK Then
                        Cursor = Cursors.WaitCursor
                        CargarLista()
                        Cursor = Cursors.Default
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            Case Is = "Modificar"
                If CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), String) <> "" Then
                    Dim oTripulacion As New PortatilClasses.CatalogosPortatil.cTripulacion(7, CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer), False, 0)
                    oTripulacion.RegistrarModificaEliminar()

                    If oTripulacion.Tripulacion > 0 Then
                        Dim frmCaptura As New frmCapTripulacion(GLOBAL_Usuario)
                        frmCaptura._TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar
                        frmCaptura.Text = "Tripúlación de ruta de venta - [Modificar]"
                        frmCaptura.FillData(CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer))
                        If frmCaptura.ShowDialog() = DialogResult.OK Then
                            Cursor = Cursors.WaitCursor
                            CargarLista()
                            Cursor = Cursors.Default
                        End If
                    Else
                        If CType(grdDatos.Item(grdDatos.CurrentRowIndex, 1), String) = "TITULAR" Then
                            Dim Mensajes As PortatilClasses.Mensaje
                            Mensajes = New PortatilClasses.Mensaje(33)
                            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            Dim Mensajes As PortatilClasses.Mensaje
                            Mensajes = New PortatilClasses.Mensaje(42)
                            If MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                                Cursor = Cursors.WaitCursor
                                Dim oModificaTripulacion As New PortatilClasses.CatalogosPortatil.cTripulacion(9, CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer), True, 0)
                                oModificaTripulacion.RegistrarModificaEliminar()
                                CargarLista()
                                Cursor = Cursors.Default
                            End If
                        End If
                    End If
                End If

            Case Is = "Eliminar"
                If CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), String) <> "" Then
                    Dim Mensajes As New PortatilClasses.Mensaje(68)
                    If MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        Dim oTripulacion As New PortatilClasses.CatalogosPortatil.cTripulacion(7, CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Integer), False, 0)
                        oTripulacion.RegistrarModificaEliminar()
                        If oTripulacion.Tripulacion > 0 Then
                            oTripulacion.Configuracion = 6
                            oTripulacion.RegistrarModificaEliminar()
                            Cursor = Cursors.WaitCursor
                            CargarLista()
                            Cursor = Cursors.Default
                        Else
                            Dim Mensajes2 As PortatilClasses.Mensaje = Nothing
                            Mensajes = New PortatilClasses.Mensaje(33)
                            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                End If

            Case Is = "Consultar"
                If CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), String) <> "" Then
                    Dim frmCaptura As New frmCapTripulacion(GLOBAL_Usuario)
                    frmCaptura._TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Consultar
                    frmCaptura.Text = "Tripúlación de ruta de venta - [Consultar]"
                    frmCaptura.FillData(CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), Short))
                    If frmCaptura.ShowDialog() = DialogResult.OK Then
                        Cursor = Cursors.WaitCursor
                        CargarLista()
                        Cursor = Cursors.Default
                    End If
                End If
            Case Is = "Refrescar"
                Cursor = Cursors.WaitCursor
                cboAlmacenGas.CargaDatos(1, GLOBAL_Usuario)
                CargarLista()
                grdDatos_CurrentCellChanged(sender, e)
                Cursor = Cursors.Default
            Case Is = "Cerrar"
                Me.Close()
        End Select
    End Sub

    Private Sub BarraBotones_ButtonClick_1(sender As System.Object, e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles BarraBotones.ButtonClick

    End Sub
End Class

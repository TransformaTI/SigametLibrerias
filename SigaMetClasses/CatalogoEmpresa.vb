Imports System.Data.SqlClient, System.Windows.Forms
Imports System.Collections.Generic

Public Class CatalogoEmpresa
    Inherits System.Windows.Forms.Form
    Private _Empresa As Integer
    Private _Letra As String = "A"
    Private _PermiteSeleccionar As Boolean
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton3 As System.Windows.Forms.ToolBarButton

    Public ReadOnly Property Empresa() As Integer
        Get
            Return _Empresa
        End Get
    End Property

    Private _copiasCFD As Integer

    Public ReadOnly Property CopiasCFD() As Integer
        Get
            Return _copiasCFD
        End Get
    End Property

#Region " Windows Form Designer generated code "

    Public Sub New(Optional ByVal PermiteAgregar As Boolean = True, _
                   Optional ByVal PermiteModificar As Boolean = True, _
                   Optional ByVal PermiteConsultar As Boolean = True, _
                   Optional ByVal PermiteSeleccionar As Boolean = False)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        btnAgregar.Visible = PermiteAgregar
        btnModificar.Visible = PermiteModificar
        btnConsultar.Visible = PermiteConsultar

        _PermiteSeleccionar = PermiteSeleccionar

        If _PermiteSeleccionar Then
            styEmpresa.RowHeadersVisible = True
        End If

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
    Friend WithEvents tbBarra As System.Windows.Forms.ToolBar
    Friend WithEvents IndiceAgenda As SigaMetClasses.IndiceAgenda
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents grdEmpresa As System.Windows.Forms.DataGrid
    Friend WithEvents imgLista16 As System.Windows.Forms.ImageList
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents styEmpresa As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colEmpresa As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colRazonSocial As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colRFC As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCURP As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCalle As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colColonia As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colMunicipio As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colEstado As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTelefono1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnCerrarForm As System.Windows.Forms.Button
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CatalogoEmpresa))
        Me.tbBarra = New System.Windows.Forms.ToolBar()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.btnConsultar = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
        Me.btnRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton2 = New System.Windows.Forms.ToolBarButton()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton3 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.imgLista16 = New System.Windows.Forms.ImageList(Me.components)
        Me.grdEmpresa = New System.Windows.Forms.DataGrid()
        Me.styEmpresa = New System.Windows.Forms.DataGridTableStyle()
        Me.colEmpresa = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRazonSocial = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRFC = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCURP = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCalle = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colColonia = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colMunicipio = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colEstado = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTelefono1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnCerrarForm = New System.Windows.Forms.Button()
        Me.IndiceAgenda = New SigaMetClasses.IndiceAgenda()
        CType(Me.grdEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbBarra
        '
        Me.tbBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAgregar, Me.btnModificar, Me.btnConsultar, Me.ToolBarButton1, Me.btnRefrescar, Me.ToolBarButton2, Me.btnBuscar, Me.ToolBarButton3, Me.btnCerrar})
        Me.tbBarra.DropDownArrows = True
        Me.tbBarra.ImageList = Me.imgLista16
        Me.tbBarra.Location = New System.Drawing.Point(0, 0)
        Me.tbBarra.Name = "tbBarra"
        Me.tbBarra.ShowToolTips = True
        Me.tbBarra.Size = New System.Drawing.Size(744, 42)
        Me.tbBarra.TabIndex = 0
        '
        'btnAgregar
        '
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Tag = "Agregar"
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.ToolTipText = "Agregar una nueva empresa"
        '
        'btnModificar
        '
        Me.btnModificar.Enabled = False
        Me.btnModificar.ImageIndex = 1
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Tag = "Modificar"
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.ToolTipText = "Modificar la empresa seleccionada"
        '
        'btnConsultar
        '
        Me.btnConsultar.Enabled = False
        Me.btnConsultar.ImageIndex = 4
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Tag = "Consultar"
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.ToolTipText = "Consultar la empresa seleccionada"
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.Name = "ToolBarButton1"
        Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnRefrescar
        '
        Me.btnRefrescar.ImageIndex = 2
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Tag = "Refrescar"
        Me.btnRefrescar.Text = "Refrescar"
        Me.btnRefrescar.ToolTipText = "Refrescar la información"
        '
        'ToolBarButton2
        '
        Me.ToolBarButton2.Name = "ToolBarButton2"
        Me.ToolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnBuscar
        '
        Me.btnBuscar.ImageIndex = 5
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Tag = "Buscar"
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.ToolTipText = "Busqueda por Razón social y RFC"
        '
        'ToolBarButton3
        '
        Me.ToolBarButton3.Name = "ToolBarButton3"
        Me.ToolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 3
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Tag = "Cerrar"
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar"
        '
        'imgLista16
        '
        Me.imgLista16.ImageStream = CType(resources.GetObject("imgLista16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista16.TransparentColor = System.Drawing.Color.Transparent
        Me.imgLista16.Images.SetKeyName(0, "")
        Me.imgLista16.Images.SetKeyName(1, "")
        Me.imgLista16.Images.SetKeyName(2, "")
        Me.imgLista16.Images.SetKeyName(3, "")
        Me.imgLista16.Images.SetKeyName(4, "")
        Me.imgLista16.Images.SetKeyName(5, "BINOCULR.ICO")
        '
        'grdEmpresa
        '
        Me.grdEmpresa.AlternatingBackColor = System.Drawing.Color.LightGray
        Me.grdEmpresa.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdEmpresa.BackColor = System.Drawing.Color.DarkGray
        Me.grdEmpresa.CaptionBackColor = System.Drawing.Color.White
        Me.grdEmpresa.CaptionFont = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdEmpresa.CaptionForeColor = System.Drawing.Color.Navy
        Me.grdEmpresa.DataMember = ""
        Me.grdEmpresa.ForeColor = System.Drawing.Color.Black
        Me.grdEmpresa.GridLineColor = System.Drawing.Color.Black
        Me.grdEmpresa.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.grdEmpresa.HeaderBackColor = System.Drawing.Color.Silver
        Me.grdEmpresa.HeaderForeColor = System.Drawing.Color.Black
        Me.grdEmpresa.LinkColor = System.Drawing.Color.Navy
        Me.grdEmpresa.Location = New System.Drawing.Point(0, 40)
        Me.grdEmpresa.Name = "grdEmpresa"
        Me.grdEmpresa.ParentRowsBackColor = System.Drawing.Color.White
        Me.grdEmpresa.ParentRowsForeColor = System.Drawing.Color.Black
        Me.grdEmpresa.ReadOnly = True
        Me.grdEmpresa.SelectionBackColor = System.Drawing.Color.Navy
        Me.grdEmpresa.SelectionForeColor = System.Drawing.Color.White
        Me.grdEmpresa.Size = New System.Drawing.Size(744, 384)
        Me.grdEmpresa.TabIndex = 2
        Me.grdEmpresa.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.styEmpresa})
        '
        'styEmpresa
        '
        Me.styEmpresa.AlternatingBackColor = System.Drawing.Color.LavenderBlush
        Me.styEmpresa.DataGrid = Me.grdEmpresa
        Me.styEmpresa.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colEmpresa, Me.colRazonSocial, Me.colRFC, Me.colCURP, Me.colCalle, Me.colColonia, Me.colMunicipio, Me.colEstado, Me.colTelefono1})
        Me.styEmpresa.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.styEmpresa.MappingName = "Empresa"
        Me.styEmpresa.RowHeadersVisible = False
        '
        'colEmpresa
        '
        Me.colEmpresa.Format = ""
        Me.colEmpresa.FormatInfo = Nothing
        Me.colEmpresa.HeaderText = "Clave"
        Me.colEmpresa.MappingName = "Empresa"
        Me.colEmpresa.Width = 75
        '
        'colRazonSocial
        '
        Me.colRazonSocial.Format = ""
        Me.colRazonSocial.FormatInfo = Nothing
        Me.colRazonSocial.HeaderText = "Razón social"
        Me.colRazonSocial.MappingName = "RazonSocial"
        Me.colRazonSocial.Width = 260
        '
        'colRFC
        '
        Me.colRFC.Format = ""
        Me.colRFC.FormatInfo = Nothing
        Me.colRFC.HeaderText = "R.F.C."
        Me.colRFC.MappingName = "RFC"
        Me.colRFC.Width = 130
        '
        'colCURP
        '
        Me.colCURP.Format = ""
        Me.colCURP.FormatInfo = Nothing
        Me.colCURP.HeaderText = "C.U.R.P."
        Me.colCURP.MappingName = "CURP"
        Me.colCURP.NullText = ""
        Me.colCURP.Width = 75
        '
        'colCalle
        '
        Me.colCalle.Format = ""
        Me.colCalle.FormatInfo = Nothing
        Me.colCalle.HeaderText = "Calle"
        Me.colCalle.MappingName = "Calle"
        Me.colCalle.Width = 120
        '
        'colColonia
        '
        Me.colColonia.Format = ""
        Me.colColonia.FormatInfo = Nothing
        Me.colColonia.HeaderText = "Colonia"
        Me.colColonia.MappingName = "Colonia"
        Me.colColonia.Width = 120
        '
        'colMunicipio
        '
        Me.colMunicipio.Format = ""
        Me.colMunicipio.FormatInfo = Nothing
        Me.colMunicipio.HeaderText = "Municipio"
        Me.colMunicipio.MappingName = "Municipio"
        Me.colMunicipio.Width = 75
        '
        'colEstado
        '
        Me.colEstado.Format = ""
        Me.colEstado.FormatInfo = Nothing
        Me.colEstado.HeaderText = "Estado"
        Me.colEstado.MappingName = "Estado"
        Me.colEstado.Width = 75
        '
        'colTelefono1
        '
        Me.colTelefono1.Format = ""
        Me.colTelefono1.FormatInfo = Nothing
        Me.colTelefono1.HeaderText = "Teléfono"
        Me.colTelefono1.MappingName = "Telefono1"
        Me.colTelefono1.NullText = ""
        Me.colTelefono1.Width = 75
        '
        'btnCerrarForm
        '
        Me.btnCerrarForm.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrarForm.Location = New System.Drawing.Point(216, 8)
        Me.btnCerrarForm.Name = "btnCerrarForm"
        Me.btnCerrarForm.Size = New System.Drawing.Size(8, 8)
        Me.btnCerrarForm.TabIndex = 3
        '
        'IndiceAgenda
        '
        Me.IndiceAgenda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IndiceAgenda.BackColor = System.Drawing.Color.LightGray
        Me.IndiceAgenda.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IndiceAgenda.Location = New System.Drawing.Point(320, 8)
        Me.IndiceAgenda.Name = "IndiceAgenda"
        Me.IndiceAgenda.Size = New System.Drawing.Size(416, 24)
        Me.IndiceAgenda.TabIndex = 1
        '
        'CatalogoEmpresa
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCerrarForm
        Me.ClientSize = New System.Drawing.Size(744, 429)
        Me.Controls.Add(Me.grdEmpresa)
        Me.Controls.Add(Me.IndiceAgenda)
        Me.Controls.Add(Me.tbBarra)
        Me.Controls.Add(Me.btnCerrarForm)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(752, 456)
        Me.Name = "CatalogoEmpresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo de Empresas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub IndiceAgenda_CambioIndiceAlfabetico(ByVal Letra As String) Handles IndiceAgenda.CambioIndiceAlfabetico
        _Letra = Letra
        CargaDatos()
    End Sub

    Private Sub CargaDatos()
        Cursor = Cursors.WaitCursor
        _Empresa = 0
        btnModificar.Enabled = False
        btnConsultar.Enabled = False

        Dim conn As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand("spCCEmpresaConsulta", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Letra", SqlDbType.Char).Value = _Letra
        End With
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable("Empresa")

        Try
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                grdEmpresa.DataSource = dt
                grdEmpresa.CaptionText = "Catálogo de Empresas [" & _Letra & "] (" & dt.Rows.Count.ToString & " en total)"

            Else
                grdEmpresa.CaptionText = "No existen empresas con la letra '" & _Letra & "'"
                grdEmpresa.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            dt.Dispose()
            If Not conn Is Nothing Then
                If conn.State = ConnectionState.Open Then conn.Close()
            End If
            Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub CatalogoEmpresa_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaDatos()
    End Sub

    Private Sub Modifica()
        Cursor = Cursors.WaitCursor
        Dim oCapEmpresa As New CapturaEmpresa(_Empresa)
        If oCapEmpresa.ShowDialog() = DialogResult.OK Then
            CargaDatos()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Agregar()
        Cursor = Cursors.WaitCursor
        Dim oCapEmpresa As New CapturaEmpresa()
        Try
            If oCapEmpresa.ShowDialog() = DialogResult.OK Then
                If Not _PermiteSeleccionar Then
                    CargaDatos()
                Else
                    _Empresa = oCapEmpresa.Empresa
                    DialogResult = DialogResult.OK
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Cursor = Cursors.Default
            oCapEmpresa.Dispose()
        End Try

    End Sub

    Private Sub Consultar()
        Cursor = Cursors.WaitCursor
        Dim oConsultaEmpresa As New ConsultaEmpresa(_Empresa)
        oConsultaEmpresa.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub tbBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case "Agregar"
                Agregar()
            Case "Modificar"
                If _Empresa <> 0 Then
                    Modifica()
                End If
            Case "Consultar"
                If _Empresa <> 0 Then
                    Consultar()
                End If
            Case "Refrescar"
                CargaDatos()
            Case "Buscar"
                Dim RFC As String
                Dim Razonsocial As String

                Dim frmBuscar As New frmBusquedaPorRFCyRazonSocial()
                frmBuscar.ShowDialog()

                If frmBuscar.DialogResult = Windows.Forms.DialogResult.OK Then
                    Dim datos As New Dictionary(Of String, String)
                    datos = frmBuscar.Tag
                    RFC = datos.Item("rfc")
                    Razonsocial = datos.Item("razonSocial")
                    BuscarPor(RFC, Razonsocial)
                End If
            Case "Cerrar"
                    Me.Close()
        End Select
    End Sub

    Private Sub BuscarPor(ByVal RFC As String, ByVal RazonSocial As String)

        Cursor = Cursors.WaitCursor
        _Empresa = 0
        btnModificar.Enabled = False
        btnConsultar.Enabled = False

        Dim conn As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand("spCCEmpresaConsultaPorRazonSyRFC", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure

            .Parameters.Add("@RFC", SqlDbType.Char).Value = IIf(RFC = "", DBNull.Value, RFC)
            .Parameters.Add("@RazonSocial", SqlDbType.Char).Value = IIf(RazonSocial = "", DBNull.Value, RazonSocial)
        End With
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable("Empresa")

        Try
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                grdEmpresa.DataSource = Nothing
                grdEmpresa.DataSource = dt
                grdEmpresa.CaptionText = "Catálogo de Empresas (" & dt.Rows.Count.ToString & " en total)"

            Else
                grdEmpresa.CaptionText = "No existen empresas con los datos considerados"
                grdEmpresa.DataSource = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            dt.Dispose()
            If Not conn Is Nothing Then
                If conn.State = ConnectionState.Open Then conn.Close()
            End If
            Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub grdEmpresa_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdEmpresa.CurrentCellChanged
        grdEmpresa.Select(grdEmpresa.CurrentRowIndex)

        Try
            _Empresa = grdEmpresa.Item(grdEmpresa.CurrentRowIndex, 0)
        Catch
            _Empresa = 0
        End Try

        If _Empresa <> 0 Then
            btnModificar.Enabled = True
            btnConsultar.Enabled = True
        Else
            btnModificar.Enabled = False
            btnConsultar.Enabled = False
        End If

    End Sub

    Private Sub btnCerrarForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarForm.Click
        Me.Close()
    End Sub

    Private Sub grdEmpresa_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdEmpresa.DoubleClick
        If _PermiteSeleccionar Then
            If _Empresa <> 0 Then
                DialogResult = DialogResult.OK
            End If
        End If
    End Sub

End Class

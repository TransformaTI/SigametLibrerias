Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class frmClienteBitacora
    Inherits System.Windows.Forms.Form
    Private _Cliente As Integer

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
    Friend WithEvents grdClienteBitacora As System.Windows.Forms.DataGrid
    Friend WithEvents pnlDatos As System.Windows.Forms.Panel
    Friend WithEvents styClienteBitacora As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colLastUpdate As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colRuta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCelula As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatusCalidad As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents colUserID As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colHostName As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents grpTelefono As System.Windows.Forms.GroupBox
    Friend WithEvents lblCalle As System.Windows.Forms.Label
    Friend WithEvents lblNumExterior As System.Windows.Forms.Label
    Friend WithEvents lblNumInterior As System.Windows.Forms.Label
    Friend WithEvents lblEntreCalle1 As System.Windows.Forms.Label
    Friend WithEvents lblEntreCalle2 As System.Windows.Forms.Label
    Friend WithEvents lblColonia As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents lblTelCasa As System.Windows.Forms.Label
    Friend WithEvents lblTelAlterno1 As System.Windows.Forms.Label
    Friend WithEvents lblTelAlterno2 As System.Windows.Forms.Label
    Friend WithEvents colCalle As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colNumExterior As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colNumInterior As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colEntreCalle1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colEntreCalle2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colColonia As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colEmpresa As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTelCasa As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTelAlterno1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTelAlterno2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lblRamoCliente As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents colRamoCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmClienteBitacora))
        Me.grdClienteBitacora = New System.Windows.Forms.DataGrid()
        Me.styClienteBitacora = New System.Windows.Forms.DataGridTableStyle()
        Me.colLastUpdate = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRuta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCelula = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatusCalidad = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colUserID = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colHostName = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCalle = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colNumExterior = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colNumInterior = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colEntreCalle1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colEntreCalle2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colColonia = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colEmpresa = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTelCasa = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTelAlterno1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTelAlterno2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRamoCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblRamoCliente = New System.Windows.Forms.Label()
        Me.grpTelefono = New System.Windows.Forms.GroupBox()
        Me.lblTelAlterno2 = New System.Windows.Forms.Label()
        Me.lblTelCasa = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblTelAlterno1 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.lblColonia = New System.Windows.Forms.Label()
        Me.lblEntreCalle2 = New System.Windows.Forms.Label()
        Me.lblEntreCalle1 = New System.Windows.Forms.Label()
        Me.lblNumInterior = New System.Windows.Forms.Label()
        Me.lblNumExterior = New System.Windows.Forms.Label()
        Me.lblCalle = New System.Windows.Forms.Label()
        CType(Me.grdClienteBitacora, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatos.SuspendLayout()
        Me.grpTelefono.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdClienteBitacora
        '
        Me.grdClienteBitacora.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdClienteBitacora.DataMember = ""
        Me.grdClienteBitacora.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdClienteBitacora.Name = "grdClienteBitacora"
        Me.grdClienteBitacora.ReadOnly = True
        Me.grdClienteBitacora.Size = New System.Drawing.Size(834, 328)
        Me.grdClienteBitacora.TabIndex = 0
        Me.grdClienteBitacora.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.styClienteBitacora})
        '
        'styClienteBitacora
        '
        Me.styClienteBitacora.AlternatingBackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.styClienteBitacora.DataGrid = Me.grdClienteBitacora
        Me.styClienteBitacora.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colLastUpdate, Me.colNombre, Me.colRuta, Me.colCelula, Me.colStatus, Me.colStatusCalidad, Me.colUserID, Me.colHostName, Me.colCalle, Me.colNumExterior, Me.colNumInterior, Me.colEntreCalle1, Me.colEntreCalle2, Me.colColonia, Me.colEmpresa, Me.colTelCasa, Me.colTelAlterno1, Me.colTelAlterno2, Me.colRamoCliente})
        Me.styClienteBitacora.HeaderBackColor = System.Drawing.Color.LightGray
        Me.styClienteBitacora.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.styClienteBitacora.MappingName = "ClienteBitacora"
        Me.styClienteBitacora.ReadOnly = True
        Me.styClienteBitacora.RowHeadersVisible = False
        Me.styClienteBitacora.SelectionBackColor = System.Drawing.Color.Gold
        Me.styClienteBitacora.SelectionForeColor = System.Drawing.Color.Black
        '
        'colLastUpdate
        '
        Me.colLastUpdate.Format = ""
        Me.colLastUpdate.FormatInfo = Nothing
        Me.colLastUpdate.HeaderText = "Fecha"
        Me.colLastUpdate.MappingName = "LastUpdate"
        Me.colLastUpdate.Width = 130
        '
        'colNombre
        '
        Me.colNombre.Format = ""
        Me.colNombre.FormatInfo = Nothing
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.MappingName = "Nombre"
        Me.colNombre.Width = 200
        '
        'colRuta
        '
        Me.colRuta.Format = ""
        Me.colRuta.FormatInfo = Nothing
        Me.colRuta.HeaderText = "Ruta"
        Me.colRuta.MappingName = "RutaDescripcion"
        Me.colRuta.NullText = ""
        Me.colRuta.Width = 65
        '
        'colCelula
        '
        Me.colCelula.Format = ""
        Me.colCelula.FormatInfo = Nothing
        Me.colCelula.HeaderText = "Célula"
        Me.colCelula.MappingName = "CelulaDescripcion"
        Me.colCelula.NullText = ""
        Me.colCelula.Width = 75
        '
        'colStatus
        '
        Me.colStatus.Format = ""
        Me.colStatus.FormatInfo = Nothing
        Me.colStatus.HeaderText = "Estatus"
        Me.colStatus.MappingName = "Status"
        Me.colStatus.NullText = ""
        Me.colStatus.Width = 75
        '
        'colStatusCalidad
        '
        Me.colStatusCalidad.Format = ""
        Me.colStatusCalidad.FormatInfo = Nothing
        Me.colStatusCalidad.HeaderText = "E. Calidad"
        Me.colStatusCalidad.MappingName = "StatusCalidad"
        Me.colStatusCalidad.NullText = ""
        Me.colStatusCalidad.Width = 75
        '
        'colUserID
        '
        Me.colUserID.Format = ""
        Me.colUserID.FormatInfo = Nothing
        Me.colUserID.HeaderText = "Usuario"
        Me.colUserID.MappingName = "UserID"
        Me.colUserID.Width = 75
        '
        'colHostName
        '
        Me.colHostName.Format = ""
        Me.colHostName.FormatInfo = Nothing
        Me.colHostName.HeaderText = "Host"
        Me.colHostName.MappingName = "HostName"
        Me.colHostName.Width = 110
        '
        'colCalle
        '
        Me.colCalle.Format = ""
        Me.colCalle.FormatInfo = Nothing
        Me.colCalle.MappingName = "CalleNombre"
        Me.colCalle.Width = 0
        '
        'colNumExterior
        '
        Me.colNumExterior.Format = ""
        Me.colNumExterior.FormatInfo = Nothing
        Me.colNumExterior.MappingName = "NumExterior"
        Me.colNumExterior.Width = 0
        '
        'colNumInterior
        '
        Me.colNumInterior.Format = ""
        Me.colNumInterior.FormatInfo = Nothing
        Me.colNumInterior.MappingName = "NumInterior"
        Me.colNumInterior.Width = 0
        '
        'colEntreCalle1
        '
        Me.colEntreCalle1.Format = ""
        Me.colEntreCalle1.FormatInfo = Nothing
        Me.colEntreCalle1.MappingName = "EntreCalle1Nombre"
        Me.colEntreCalle1.Width = 0
        '
        'colEntreCalle2
        '
        Me.colEntreCalle2.Format = ""
        Me.colEntreCalle2.FormatInfo = Nothing
        Me.colEntreCalle2.MappingName = "EntreCalle2Nombre"
        Me.colEntreCalle2.Width = 0
        '
        'colColonia
        '
        Me.colColonia.Format = ""
        Me.colColonia.FormatInfo = Nothing
        Me.colColonia.MappingName = "ColoniaNombre"
        Me.colColonia.Width = 0
        '
        'colEmpresa
        '
        Me.colEmpresa.Format = ""
        Me.colEmpresa.FormatInfo = Nothing
        Me.colEmpresa.MappingName = "RazonSocial"
        Me.colEmpresa.Width = 0
        '
        'colTelCasa
        '
        Me.colTelCasa.Format = ""
        Me.colTelCasa.FormatInfo = Nothing
        Me.colTelCasa.MappingName = "TelCasa"
        Me.colTelCasa.Width = 0
        '
        'colTelAlterno1
        '
        Me.colTelAlterno1.Format = ""
        Me.colTelAlterno1.FormatInfo = Nothing
        Me.colTelAlterno1.MappingName = "TelAlterno1"
        Me.colTelAlterno1.Width = 0
        '
        'colTelAlterno2
        '
        Me.colTelAlterno2.Format = ""
        Me.colTelAlterno2.FormatInfo = Nothing
        Me.colTelAlterno2.MappingName = "TelAlterno2"
        Me.colTelAlterno2.Width = 0
        '
        'colRamoCliente
        '
        Me.colRamoCliente.Format = ""
        Me.colRamoCliente.FormatInfo = Nothing
        Me.colRamoCliente.MappingName = "RamoClienteDescripcion"
        Me.colRamoCliente.Width = 0
        '
        'pnlDatos
        '
        Me.pnlDatos.BackColor = System.Drawing.Color.Gainsboro
        Me.pnlDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCerrar, Me.Label2, Me.lblRamoCliente, Me.grpTelefono, Me.Label17, Me.Label16, Me.Label15, Me.Label14, Me.Label13, Me.Label12, Me.Label11, Me.lblEmpresa, Me.lblColonia, Me.lblEntreCalle2, Me.lblEntreCalle1, Me.lblNumInterior, Me.lblNumExterior, Me.lblCalle})
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDatos.Location = New System.Drawing.Point(0, 327)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(834, 184)
        Me.pnlDatos.TabIndex = 1
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(752, 152)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.TabIndex = 23
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 14)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Ramo:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRamoCliente
        '
        Me.lblRamoCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRamoCliente.Location = New System.Drawing.Point(88, 144)
        Me.lblRamoCliente.Name = "lblRamoCliente"
        Me.lblRamoCliente.Size = New System.Drawing.Size(400, 21)
        Me.lblRamoCliente.TabIndex = 21
        Me.lblRamoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpTelefono
        '
        Me.grpTelefono.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTelAlterno2, Me.lblTelCasa, Me.Label19, Me.Label20, Me.Label18, Me.lblTelAlterno1})
        Me.grpTelefono.Location = New System.Drawing.Point(528, 24)
        Me.grpTelefono.Name = "grpTelefono"
        Me.grpTelefono.Size = New System.Drawing.Size(224, 104)
        Me.grpTelefono.TabIndex = 20
        Me.grpTelefono.TabStop = False
        Me.grpTelefono.Text = "Teléfonos"
        '
        'lblTelAlterno2
        '
        Me.lblTelAlterno2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTelAlterno2.Location = New System.Drawing.Point(72, 72)
        Me.lblTelAlterno2.Name = "lblTelAlterno2"
        Me.lblTelAlterno2.Size = New System.Drawing.Size(136, 21)
        Me.lblTelAlterno2.TabIndex = 9
        Me.lblTelAlterno2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTelCasa
        '
        Me.lblTelCasa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTelCasa.Location = New System.Drawing.Point(72, 24)
        Me.lblTelCasa.Name = "lblTelCasa"
        Me.lblTelCasa.Size = New System.Drawing.Size(136, 21)
        Me.lblTelCasa.TabIndex = 7
        Me.lblTelCasa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(16, 51)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(54, 14)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "Alterno 1:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 75)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(54, 14)
        Me.Label20.TabIndex = 19
        Me.Label20.Text = "Alterno 2:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(16, 27)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(32, 14)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Casa:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTelAlterno1
        '
        Me.lblTelAlterno1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTelAlterno1.Location = New System.Drawing.Point(72, 48)
        Me.lblTelAlterno1.Name = "lblTelAlterno1"
        Me.lblTelAlterno1.Size = New System.Drawing.Size(136, 21)
        Me.lblTelAlterno1.TabIndex = 8
        Me.lblTelAlterno1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(280, 75)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(14, 14)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "y:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(256, 51)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 14)
        Me.Label16.TabIndex = 15
        Me.Label16.Text = "No.Interior:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(16, 123)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 14)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Empresa:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 99)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 14)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Colonia:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 75)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 14)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Entre:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 14)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "No.Exterior:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 14)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Calle:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmpresa
        '
        Me.lblEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEmpresa.Location = New System.Drawing.Point(88, 120)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(400, 21)
        Me.lblEmpresa.TabIndex = 6
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblColonia
        '
        Me.lblColonia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblColonia.Location = New System.Drawing.Point(88, 96)
        Me.lblColonia.Name = "lblColonia"
        Me.lblColonia.Size = New System.Drawing.Size(400, 21)
        Me.lblColonia.TabIndex = 5
        Me.lblColonia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEntreCalle2
        '
        Me.lblEntreCalle2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEntreCalle2.Location = New System.Drawing.Point(328, 72)
        Me.lblEntreCalle2.Name = "lblEntreCalle2"
        Me.lblEntreCalle2.Size = New System.Drawing.Size(160, 21)
        Me.lblEntreCalle2.TabIndex = 4
        Me.lblEntreCalle2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEntreCalle1
        '
        Me.lblEntreCalle1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEntreCalle1.Location = New System.Drawing.Point(88, 72)
        Me.lblEntreCalle1.Name = "lblEntreCalle1"
        Me.lblEntreCalle1.Size = New System.Drawing.Size(160, 21)
        Me.lblEntreCalle1.TabIndex = 3
        Me.lblEntreCalle1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNumInterior
        '
        Me.lblNumInterior.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumInterior.Location = New System.Drawing.Point(328, 48)
        Me.lblNumInterior.Name = "lblNumInterior"
        Me.lblNumInterior.Size = New System.Drawing.Size(160, 21)
        Me.lblNumInterior.TabIndex = 2
        Me.lblNumInterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNumExterior
        '
        Me.lblNumExterior.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumExterior.Location = New System.Drawing.Point(88, 48)
        Me.lblNumExterior.Name = "lblNumExterior"
        Me.lblNumExterior.Size = New System.Drawing.Size(160, 21)
        Me.lblNumExterior.TabIndex = 1
        Me.lblNumExterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCalle
        '
        Me.lblCalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCalle.Location = New System.Drawing.Point(88, 24)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(400, 21)
        Me.lblCalle.TabIndex = 0
        Me.lblCalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ClienteBitacora
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(834, 511)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlDatos, Me.grdClienteBitacora})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ClienteBitacora"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bitácora de actualizaciones"
        Me.TopMost = True
        CType(Me.grdClienteBitacora, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatos.ResumeLayout(False)
        Me.grpTelefono.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal Cliente As Integer)
        MyBase.New()
        InitializeComponent()

        _Cliente = Cliente

        CargaDatos()

    End Sub

    Private Sub CargaDatos()
        Dim cmd As New SqlCommand("spCCClienteBitacoraConsulta")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 120
            .Parameters.Add("@Cliente", SqlDbType.Int).Value = _Cliente
            .Connection = DataLayer.Conexion
        End With
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable("ClienteBitacora")

        Try

            AbreConexion()
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                grdClienteBitacora.DataSource = dt
                grdClienteBitacora.CaptionText = "Bitácora de actualizaciones del cliente " & _Cliente.ToString & " (" & dt.Rows.Count.ToString & " registros en total)"
            Else
                grdClienteBitacora.DataSource = Nothing
                grdClienteBitacora.CaptionText = "El cliente no tiene registros"
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            CierraConexion()
            da.Dispose()
            cmd.Dispose()
        End Try
    End Sub

    Private Sub grdClienteBitacora_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdClienteBitacora.CurrentCellChanged
        Try
            grdClienteBitacora.Select(grdClienteBitacora.CurrentRowIndex)

            lblCalle.Text = CType(grdClienteBitacora.Item(grdClienteBitacora.CurrentRowIndex, 8), String).Trim
            lblNumExterior.Text = CType(grdClienteBitacora.Item(grdClienteBitacora.CurrentRowIndex, 9), String).Trim
            lblNumInterior.Text = CType(grdClienteBitacora.Item(grdClienteBitacora.CurrentRowIndex, 10), String).Trim
            lblEntreCalle1.Text = CType(grdClienteBitacora.Item(grdClienteBitacora.CurrentRowIndex, 11), String).Trim
            lblEntreCalle2.Text = CType(grdClienteBitacora.Item(grdClienteBitacora.CurrentRowIndex, 12), String).Trim
            lblColonia.Text = CType(grdClienteBitacora.Item(grdClienteBitacora.CurrentRowIndex, 13), String).Trim
            lblEmpresa.Text = CType(grdClienteBitacora.Item(grdClienteBitacora.CurrentRowIndex, 14), String).Trim
            lblTelCasa.Text = CType(grdClienteBitacora.Item(grdClienteBitacora.CurrentRowIndex, 15), String).Trim
            lblTelAlterno1.Text = CType(grdClienteBitacora.Item(grdClienteBitacora.CurrentRowIndex, 16), String).Trim
            lblTelAlterno2.Text = CType(grdClienteBitacora.Item(grdClienteBitacora.CurrentRowIndex, 17), String).Trim
            lblRamoCliente.Text = CType(grdClienteBitacora.Item(grdClienteBitacora.CurrentRowIndex, 18), String).Trim
        Catch


        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class
Imports System.Windows.Forms

Public Class frmValidacionDireccion
    Inherits System.Windows.Forms.Form

    Private _cliente As Integer
    Private _nombre As String
    Private _telCasa As String

    Private _direcciones As New DataTable("Direcciones")


    Public Sub New(ByVal Cliente As Integer, ByVal Nombre As String, ByVal TelCasa As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        _cliente = Cliente
        _nombre = Nombre
        _telCasa = TelCasa

        lblCliente.Text = _cliente
        txtNombre.Text = _nombre
        txtTelCasa.Text = SigaMetClasses.FormatoTelefono(_telCasa)

        SeleccionCalleColonia1.CargaDatosCliente(_cliente)

        If ConsultaDuplicados() Then
            Me.ShowDialog()
        End If
    End Sub

#Region " Windows Form Designer generated code "



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
    Friend WithEvents SeleccionCalleColonia1 As SigaMetClasses.SeleccionCalleColonia
    Friend WithEvents lvwCliente As System.Windows.Forms.ListView
    Friend WithEvents colCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblListaCliente As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents txtTelCasa As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lnkConsultar As System.Windows.Forms.LinkLabel
    Friend WithEvents imgLst As System.Windows.Forms.ImageList
    Friend WithEvents lnkQueja As SVCC.BlinkingClickLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmValidacionDireccion))
		Me.SeleccionCalleColonia1 = New SigaMetClasses.SeleccionCalleColonia()
		Me.lvwCliente = New System.Windows.Forms.ListView()
		Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.colNombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.imgLst = New System.Windows.Forms.ImageList(Me.components)
		Me.lblListaCliente = New System.Windows.Forms.Label()
		Me.btnCerrar = New System.Windows.Forms.Button()
		Me.txtTelCasa = New SigaMetClasses.Controles.txtNumeroEntero()
		Me.Label16 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.lblCliente = New System.Windows.Forms.Label()
		Me.txtNombre = New System.Windows.Forms.TextBox()
		Me.lnkConsultar = New System.Windows.Forms.LinkLabel()
		Me.lnkQueja = New SVCC.BlinkingClickLabel()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'SeleccionCalleColonia1
		'
		Me.SeleccionCalleColonia1.AltaCalleColonia = True
		Me.SeleccionCalleColonia1.CadenaConexion = Nothing
		Me.SeleccionCalleColonia1.Calle = 0
		Me.SeleccionCalleColonia1.Colonia = 0
		Me.SeleccionCalleColonia1.Enabled = False
		Me.SeleccionCalleColonia1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.SeleccionCalleColonia1.Location = New System.Drawing.Point(8, 108)
		Me.SeleccionCalleColonia1.Modulo = CType(0, Byte)
		Me.SeleccionCalleColonia1.Name = "SeleccionCalleColonia1"
		Me.SeleccionCalleColonia1.Size = New System.Drawing.Size(536, 144)
		Me.SeleccionCalleColonia1.TabIndex = 0
		Me.SeleccionCalleColonia1.URLGateway = Nothing
		'
		'lvwCliente
		'
		Me.lvwCliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lvwCliente.BackColor = System.Drawing.SystemColors.Window
		Me.lvwCliente.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colCliente, Me.colNombre})
		Me.lvwCliente.FullRowSelect = True
		Me.lvwCliente.Location = New System.Drawing.Point(8, 284)
		Me.lvwCliente.MultiSelect = False
		Me.lvwCliente.Name = "lvwCliente"
		Me.lvwCliente.Size = New System.Drawing.Size(618, 220)
		Me.lvwCliente.SmallImageList = Me.imgLst
		Me.lvwCliente.TabIndex = 24
		Me.lvwCliente.UseCompatibleStateImageBehavior = False
		Me.lvwCliente.View = System.Windows.Forms.View.Details
		'
		'colCliente
		'
		Me.colCliente.Text = "Cliente"
		Me.colCliente.Width = 120
		'
		'colNombre
		'
		Me.colNombre.Text = "Nombre"
		Me.colNombre.Width = 480
		'
		'imgLst
		'
		Me.imgLst.ImageStream = CType(resources.GetObject("imgLst.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.imgLst.TransparentColor = System.Drawing.Color.Transparent
		Me.imgLst.Images.SetKeyName(0, "")
		Me.imgLst.Images.SetKeyName(1, "")
		'
		'lblListaCliente
		'
		Me.lblListaCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblListaCliente.BackColor = System.Drawing.Color.LightSlateGray
		Me.lblListaCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblListaCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblListaCliente.ForeColor = System.Drawing.Color.White
		Me.lblListaCliente.Location = New System.Drawing.Point(8, 260)
		Me.lblListaCliente.Name = "lblListaCliente"
		Me.lblListaCliente.Size = New System.Drawing.Size(618, 21)
		Me.lblListaCliente.TabIndex = 25
		Me.lblListaCliente.Text = "Clientes con direcciones/teléfonos duplicados"
		Me.lblListaCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'btnCerrar
		'
		Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
		Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
		Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnCerrar.Location = New System.Drawing.Point(551, 8)
		Me.btnCerrar.Name = "btnCerrar"
		Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
		Me.btnCerrar.TabIndex = 22
		Me.btnCerrar.Text = "&Cerrar"
		Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnCerrar.UseVisualStyleBackColor = False
		'
		'txtTelCasa
		'
		Me.txtTelCasa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtTelCasa.Location = New System.Drawing.Point(428, 228)
		Me.txtTelCasa.Name = "txtTelCasa"
		Me.txtTelCasa.ReadOnly = True
		Me.txtTelCasa.Size = New System.Drawing.Size(116, 21)
		Me.txtTelCasa.TabIndex = 33
		'
		'Label16
		'
		Me.Label16.AutoSize = True
		Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label16.Location = New System.Drawing.Point(364, 231)
		Me.Label16.Name = "Label16"
		Me.Label16.Size = New System.Drawing.Size(60, 13)
		Me.Label16.TabIndex = 34
		Me.Label16.Text = "Tel. Casa:"
		Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(16, 63)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(49, 13)
		Me.Label2.TabIndex = 107
		Me.Label2.Text = "Cliente:"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblCliente
		'
		Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblCliente.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCliente.ForeColor = System.Drawing.Color.Navy
		Me.lblCliente.Location = New System.Drawing.Point(96, 60)
		Me.lblCliente.Name = "lblCliente"
		Me.lblCliente.Size = New System.Drawing.Size(192, 21)
		Me.lblCliente.TabIndex = 105
		Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'txtNombre
		'
		Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
		Me.txtNombre.Location = New System.Drawing.Point(96, 84)
		Me.txtNombre.Name = "txtNombre"
		Me.txtNombre.ReadOnly = True
		Me.txtNombre.Size = New System.Drawing.Size(448, 21)
		Me.txtNombre.TabIndex = 106
		'
		'lnkConsultar
		'
		Me.lnkConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lnkConsultar.AutoSize = True
		Me.lnkConsultar.BackColor = System.Drawing.Color.LightSlateGray
		Me.lnkConsultar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lnkConsultar.ForeColor = System.Drawing.Color.White
		Me.lnkConsultar.LinkColor = System.Drawing.Color.White
		Me.lnkConsultar.Location = New System.Drawing.Point(562, 264)
		Me.lnkConsultar.Name = "lnkConsultar"
		Me.lnkConsultar.Size = New System.Drawing.Size(61, 13)
		Me.lnkConsultar.TabIndex = 108
		Me.lnkConsultar.TabStop = True
		Me.lnkConsultar.Text = "Consultar"
		'
		'lnkQueja
		'
		Me.lnkQueja.AlternatingColor2 = System.Drawing.Color.Red
		Me.lnkQueja.BackColor = System.Drawing.SystemColors.ActiveBorder
		Me.lnkQueja.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lnkQueja.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
		Me.lnkQueja.Location = New System.Drawing.Point(96, 8)
		Me.lnkQueja.Name = "lnkQueja"
		Me.lnkQueja.Size = New System.Drawing.Size(448, 36)
		Me.lnkQueja.TabIndex = 109
		Me.lnkQueja.TabStop = True
		Me.lnkQueja.Text = "Existen clientes con dirección/teléfono igual al cliente que está buscando, a con" &
	"tinuación se muestra el detalle de estos."
		Me.lnkQueja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.lnkQueja.TimerInterval = 500
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.Location = New System.Drawing.Point(16, 87)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(54, 13)
		Me.Label6.TabIndex = 110
		Me.Label6.Text = "Nombre:"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'PictureBox1
		'
		Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
		Me.PictureBox1.Location = New System.Drawing.Point(16, 10)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(36, 32)
		Me.PictureBox1.TabIndex = 111
		Me.PictureBox1.TabStop = False
		'
		'frmValidacionDireccion
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
		Me.ClientSize = New System.Drawing.Size(632, 511)
		Me.Controls.Add(Me.PictureBox1)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.lnkQueja)
		Me.Controls.Add(Me.lnkConsultar)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.lblCliente)
		Me.Controls.Add(Me.txtNombre)
		Me.Controls.Add(Me.txtTelCasa)
		Me.Controls.Add(Me.Label16)
		Me.Controls.Add(Me.lvwCliente)
		Me.Controls.Add(Me.lblListaCliente)
		Me.Controls.Add(Me.btnCerrar)
		Me.Controls.Add(Me.SeleccionCalleColonia1)
		Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "frmValidacionDireccion"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Dirección duplicada"
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

#End Region

	Public Function ConsultaDuplicados() As Boolean
        Try
            _direcciones = SigaMetClasses.cCliente.ConsultaDireccionDuplicada(_cliente, _
                SeleccionCalleColonia1.Calle, _
                SeleccionCalleColonia1.NumExterior, _
                SeleccionCalleColonia1.Colonia, _
                SeleccionCalleColonia1.NumInterior, _
                _telCasa)
        Catch ex As Exception
            MessageBox.Show("Error validando direcciones duplicadas" & vbCrLf & _
                ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If _direcciones.Rows.Count > 0 Then
            Dim dr As DataRow
            For Each dr In _direcciones.Rows
                'Verificar que el cliente a agregar no es el mismo cliente que se recuperó del callcenter
                If Convert.ToInt32(dr("Cliente")) <> _cliente Then
                    Dim item As New Windows.Forms.ListViewItem(Convert.ToInt32(dr("Cliente")))
                    item.SubItems.Add(Convert.ToString(dr("Nombre")))
                    item.Tag = dr
                    Select Case Convert.ToString(dr("Tipo")).Trim.ToUpper
                        Case "DIRECCION"
                            item.ImageIndex = 0
                        Case "TELEFONO"
                            item.ImageIndex = 1
                    End Select
                    item.ForeColor = System.Drawing.Color.FromName(CType(dr("ForeColor"), String).Trim)
                    lvwCliente.Items.Add(item)
                End If
            Next
            Return True
        End If
        Return False
    End Function

    Private Sub lnkConsultar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkConsultar.LinkClicked
        Dim selectedItem As ListViewItem
        For Each selectedItem In lvwCliente.SelectedItems
            Cursor = Cursors.WaitCursor
            Dim oConsultaCliente As New SigaMetClasses.frmConsultaCliente(Convert.ToInt32(DirectCast(selectedItem.Tag, DataRow)("Cliente")), Nuevo:=0)
            oConsultaCliente.ShowDialog()
            Cursor = Cursors.Default
        Next
    End Sub
End Class

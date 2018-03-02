<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFugaPortatil
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFugaPortatil))
        Me.grbInformacion = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFVenta = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkComprobante = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboProducto = New PortatilClasses.Combo.ComboProductoPtl()
        Me.txtCantidad = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCausa = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.cboRuta = New PortatilClasses.Combo.ComboRutaPtl()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFAtender = New System.Windows.Forms.DateTimePicker()
        Me.dgProducto = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.grbInformacion.SuspendLayout()
        CType(Me.dgProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbInformacion
        '
        Me.grbInformacion.Controls.Add(Me.Label7)
        Me.grbInformacion.Controls.Add(Me.dtpFVenta)
        Me.grbInformacion.Controls.Add(Me.GroupBox2)
        Me.grbInformacion.Controls.Add(Me.chkComprobante)
        Me.grbInformacion.Controls.Add(Me.Label5)
        Me.grbInformacion.Controls.Add(Me.cboProducto)
        Me.grbInformacion.Controls.Add(Me.txtCantidad)
        Me.grbInformacion.Controls.Add(Me.Label6)
        Me.grbInformacion.Controls.Add(Me.Label4)
        Me.grbInformacion.Controls.Add(Me.cboCausa)
        Me.grbInformacion.Controls.Add(Me.cboRuta)
        Me.grbInformacion.Controls.Add(Me.Label3)
        Me.grbInformacion.Controls.Add(Me.Label2)
        Me.grbInformacion.Controls.Add(Me.dtpFAtender)
        Me.grbInformacion.Controls.Add(Me.dgProducto)
        Me.grbInformacion.Controls.Add(Me.Label1)
        Me.grbInformacion.Controls.Add(Me.txtComentario)
        Me.grbInformacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbInformacion.Location = New System.Drawing.Point(12, 12)
        Me.grbInformacion.Name = "grbInformacion"
        Me.grbInformacion.Size = New System.Drawing.Size(542, 379)
        Me.grbInformacion.TabIndex = 0
        Me.grbInformacion.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 111)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Fecha venta:"
        '
        'dtpFVenta
        '
        Me.dtpFVenta.CustomFormat = ""
        Me.dtpFVenta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFVenta.Location = New System.Drawing.Point(102, 107)
        Me.dtpFVenta.Name = "dtpFVenta"
        Me.dtpFVenta.Size = New System.Drawing.Size(221, 21)
        Me.dtpFVenta.TabIndex = 10
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(2, 131)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(539, 8)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'chkComprobante
        '
        Me.chkComprobante.AutoSize = True
        Me.chkComprobante.Location = New System.Drawing.Point(401, 107)
        Me.chkComprobante.Name = "chkComprobante"
        Me.chkComprobante.Size = New System.Drawing.Size(103, 17)
        Me.chkComprobante.TabIndex = 11
        Me.chkComprobante.TabStop = False
        Me.chkComprobante.Text = "Comprobante"
        Me.chkComprobante.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(6, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Producto:"
        '
        'cboProducto
        '
        Me.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProducto.Location = New System.Drawing.Point(102, 154)
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(221, 21)
        Me.cboProducto.TabIndex = 13
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(401, 154)
        Me.txtCantidad.MaxLength = 5
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(128, 21)
        Me.txtCantidad.TabIndex = 15
        Me.txtCantidad.Text = "txtCantidad1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(335, 158)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Cantidad:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(6, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Causa:"
        '
        'cboCausa
        '
        Me.cboCausa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCausa.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCausa.Location = New System.Drawing.Point(102, 80)
        Me.cboCausa.Name = "cboCausa"
        Me.cboCausa.Size = New System.Drawing.Size(427, 21)
        Me.cboCausa.TabIndex = 8
        '
        'cboRuta
        '
        Me.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRuta.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRuta.Location = New System.Drawing.Point(401, 53)
        Me.cboRuta.Name = "cboRuta"
        Me.cboRuta.Size = New System.Drawing.Size(128, 21)
        Me.cboRuta.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(335, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Ruta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha atender:"
        '
        'dtpFAtender
        '
        Me.dtpFAtender.Checked = False
        Me.dtpFAtender.Cursor = System.Windows.Forms.Cursors.Default
        Me.dtpFAtender.CustomFormat = ""
        Me.dtpFAtender.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFAtender.Location = New System.Drawing.Point(102, 53)
        Me.dtpFAtender.Name = "dtpFAtender"
        Me.dtpFAtender.Size = New System.Drawing.Size(221, 21)
        Me.dtpFAtender.TabIndex = 4
        '
        'dgProducto
        '
        Me.dgProducto.AccessibleName = ""
        Me.dgProducto.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgProducto.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.dgProducto.CaptionText = "Detalle de productos liquidados"
        Me.dgProducto.DataMember = ""
        Me.dgProducto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgProducto.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgProducto.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgProducto.Location = New System.Drawing.Point(0, 182)
        Me.dgProducto.Name = "dgProducto"
        Me.dgProducto.ReadOnly = True
        Me.dgProducto.Size = New System.Drawing.Size(541, 189)
        Me.dgProducto.TabIndex = 16
        Me.dgProducto.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.dgProducto.TabStop = False
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.dgProducto
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.ReadOnly = True
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.MappingName = "Producto"
        Me.DataGridTextBoxColumn1.Width = 0
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Cantidad"
        Me.DataGridTextBoxColumn2.MappingName = "Cantidad"
        Me.DataGridTextBoxColumn2.Width = 85
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Producto"
        Me.DataGridTextBoxColumn3.MappingName = "Descripcion"
        Me.DataGridTextBoxColumn3.Width = 250
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Comentario:"
        '
        'txtComentario
        '
        Me.txtComentario.Location = New System.Drawing.Point(102, 26)
        Me.txtComentario.MaxLength = 250
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(427, 21)
        Me.txtComentario.TabIndex = 2
        Me.txtComentario.Text = "TxtString1"
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(560, 203)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 17
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnQuitar
        '
        Me.btnQuitar.Image = CType(resources.GetObject("btnQuitar.Image"), System.Drawing.Image)
        Me.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnQuitar.Location = New System.Drawing.Point(560, 232)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(75, 23)
        Me.btnQuitar.TabIndex = 18
        Me.btnQuitar.Text = "&Quitar"
        Me.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(560, 27)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 19
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(560, 56)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 20
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmFugaPortatil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(642, 395)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.grbInformacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmFugaPortatil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta de fugas portátiles"
        Me.grbInformacion.ResumeLayout(False)
        Me.grbInformacion.PerformLayout()
        CType(Me.dgProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCausa As PortatilClasses.Combo.ComboBase
    Friend WithEvents cboRuta As PortatilClasses.Combo.ComboRutaPtl
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFAtender As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgProducto As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboProducto As PortatilClasses.Combo.ComboProductoPtl
    Friend WithEvents txtCantidad As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkComprobante As System.Windows.Forms.CheckBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnQuitar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFVenta As System.Windows.Forms.DateTimePicker
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaPagosAreaTarjeta
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaPagosAreaTarjeta))
        Me.tbrPrincipal = New System.Windows.Forms.ToolBar()
        Me.BtnAlta = New System.Windows.Forms.ToolBarButton()
        Me.BtnModificar = New System.Windows.Forms.ToolBarButton()
        Me.BtnCancelar = New System.Windows.Forms.ToolBarButton()
        Me.BtnSalir = New System.Windows.Forms.ToolBarButton()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grdPagosTarjeta = New System.Windows.Forms.DataGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtpFfinal = New System.Windows.Forms.DateTimePicker()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.TxtNumCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFInicio = New System.Windows.Forms.DateTimePicker()
        Me.LblFechaAlta = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdPagosTarjeta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbrPrincipal
        '
        Me.tbrPrincipal.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrPrincipal.AutoSize = False
        Me.tbrPrincipal.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.BtnAlta, Me.BtnModificar, Me.BtnCancelar, Me.BtnSalir})
        Me.tbrPrincipal.ButtonSize = New System.Drawing.Size(85, 33)
        Me.tbrPrincipal.DropDownArrows = True
        Me.tbrPrincipal.ImageList = Me.imgLista
        Me.tbrPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tbrPrincipal.Name = "tbrPrincipal"
        Me.tbrPrincipal.ShowToolTips = True
        Me.tbrPrincipal.Size = New System.Drawing.Size(741, 36)
        Me.tbrPrincipal.TabIndex = 4
        '
        'BtnAlta
        '
        Me.BtnAlta.ImageIndex = 7
        Me.BtnAlta.Name = "BtnAlta"
        Me.BtnAlta.Tag = "Alta"
        Me.BtnAlta.Text = "Alta"
        '
        'BtnModificar
        '
        Me.BtnModificar.ImageIndex = 8
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Tag = "Modificar"
        Me.BtnModificar.Text = "Modificar"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.ImageIndex = 9
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Tag = "Cancelar"
        Me.BtnCancelar.Text = "Cancelar"
        '
        'BtnSalir
        '
        Me.BtnSalir.ImageIndex = 0
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Tag = "Salir"
        Me.BtnSalir.Text = "Salir"
        '
        'imgLista
        '
        Me.imgLista.ImageStream = CType(resources.GetObject("imgLista.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
        Me.imgLista.Images.SetKeyName(0, "")
        Me.imgLista.Images.SetKeyName(1, "")
        Me.imgLista.Images.SetKeyName(2, "")
        Me.imgLista.Images.SetKeyName(3, "")
        Me.imgLista.Images.SetKeyName(4, "")
        Me.imgLista.Images.SetKeyName(5, "")
        Me.imgLista.Images.SetKeyName(6, "")
        Me.imgLista.Images.SetKeyName(7, "")
        Me.imgLista.Images.SetKeyName(8, "")
        Me.imgLista.Images.SetKeyName(9, "delete-sign.png")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grdPagosTarjeta)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 132)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(682, 179)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'grdPagosTarjeta
        '
        Me.grdPagosTarjeta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdPagosTarjeta.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grdPagosTarjeta.CaptionText = "Pagos Area  Tarjetas de Crédito"
        Me.grdPagosTarjeta.DataMember = ""
        Me.grdPagosTarjeta.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdPagosTarjeta.Location = New System.Drawing.Point(0, 19)
        Me.grdPagosTarjeta.Name = "grdPagosTarjeta"
        Me.grdPagosTarjeta.ReadOnly = True
        Me.grdPagosTarjeta.Size = New System.Drawing.Size(676, 144)
        Me.grdPagosTarjeta.TabIndex = 6
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtpFfinal)
        Me.GroupBox2.Controls.Add(Me.BtnBuscar)
        Me.GroupBox2.Controls.Add(Me.TxtNumCliente)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtpFInicio)
        Me.GroupBox2.Controls.Add(Me.LblFechaAlta)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 42)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(676, 84)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'dtpFfinal
        '
        Me.dtpFfinal.CustomFormat = ""
        Me.dtpFfinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFfinal.Location = New System.Drawing.Point(188, 26)
        Me.dtpFfinal.Name = "dtpFfinal"
        Me.dtpFfinal.Size = New System.Drawing.Size(85, 20)
        Me.dtpFfinal.TabIndex = 7
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Location = New System.Drawing.Point(521, 23)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(89, 23)
        Me.BtnBuscar.TabIndex = 6
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'TxtNumCliente
        '
        Me.TxtNumCliente.Location = New System.Drawing.Point(360, 22)
        Me.TxtNumCliente.Name = "TxtNumCliente"
        Me.TxtNumCliente.Size = New System.Drawing.Size(131, 20)
        Me.TxtNumCliente.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(307, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Cliente"
        '
        'dtpFInicio
        '
        Me.dtpFInicio.CustomFormat = ""
        Me.dtpFInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFInicio.Location = New System.Drawing.Point(80, 26)
        Me.dtpFInicio.Name = "dtpFInicio"
        Me.dtpFInicio.Size = New System.Drawing.Size(85, 20)
        Me.dtpFInicio.TabIndex = 3
        '
        'LblFechaAlta
        '
        Me.LblFechaAlta.AutoSize = True
        Me.LblFechaAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFechaAlta.Location = New System.Drawing.Point(6, 26)
        Me.LblFechaAlta.Name = "LblFechaAlta"
        Me.LblFechaAlta.Size = New System.Drawing.Size(68, 13)
        Me.LblFechaAlta.TabIndex = 0
        Me.LblFechaAlta.Text = "Fecha Alta"
        '
        'frmConsultaPagosAreaTarjeta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(741, 321)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tbrPrincipal)
        Me.Name = "frmConsultaPagosAreaTarjeta"
        Me.Text = "Tarjeta de Crédito"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdPagosTarjeta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tbrPrincipal As Windows.Forms.ToolBar
    Friend WithEvents BtnAlta As Windows.Forms.ToolBarButton
    Friend WithEvents imgLista As Windows.Forms.ImageList
    Friend WithEvents BtnModificar As Windows.Forms.ToolBarButton
    Friend WithEvents BtnCancelar As Windows.Forms.ToolBarButton
    Friend WithEvents BtnSalir As Windows.Forms.ToolBarButton
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Public WithEvents grdPagosTarjeta As Windows.Forms.DataGrid
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents BtnBuscar As Windows.Forms.Button
    Friend WithEvents TxtNumCliente As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents dtpFInicio As Windows.Forms.DateTimePicker
    Friend WithEvents LblFechaAlta As Windows.Forms.Label
    Friend WithEvents dtpFfinal As Windows.Forms.DateTimePicker
End Class

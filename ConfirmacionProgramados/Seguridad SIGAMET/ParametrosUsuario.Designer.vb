<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParametrosUsuario
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cboModulos = New System.Windows.Forms.ComboBox()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboUsuarios = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboParametros = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvParametros = New System.Windows.Forms.DataGridView()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BorrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlParametro = New System.Windows.Forms.Panel()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Modulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Parametro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Activo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.dgvParametros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.pnlParametro.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboModulos
        '
        Me.cboModulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModulos.FormattingEnabled = True
        Me.cboModulos.Location = New System.Drawing.Point(147, 10)
        Me.cboModulos.Name = "cboModulos"
        Me.cboModulos.Size = New System.Drawing.Size(398, 21)
        Me.cboModulos.TabIndex = 0
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(147, 64)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(398, 20)
        Me.txtValor.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(73, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Módulo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(73, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Usuario:"
        '
        'cboUsuarios
        '
        Me.cboUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUsuarios.FormattingEnabled = True
        Me.cboUsuarios.Location = New System.Drawing.Point(147, 90)
        Me.cboUsuarios.Name = "cboUsuarios"
        Me.cboUsuarios.Size = New System.Drawing.Size(398, 21)
        Me.cboUsuarios.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(73, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Parámetro:"
        '
        'cboParametros
        '
        Me.cboParametros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboParametros.FormattingEnabled = True
        Me.cboParametros.Location = New System.Drawing.Point(147, 37)
        Me.cboParametros.Name = "cboParametros"
        Me.cboParametros.Size = New System.Drawing.Size(398, 21)
        Me.cboParametros.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(73, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Valor:"
        '
        'dgvParametros
        '
        Me.dgvParametros.AllowUserToAddRows = False
        Me.dgvParametros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvParametros.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvParametros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvParametros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Modulo, Me.Usuario, Me.Parametro, Me.Valor, Me.Activo})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvParametros.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvParametros.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvParametros.Location = New System.Drawing.Point(54, 171)
        Me.dgvParametros.Name = "dgvParametros"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvParametros.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvParametros.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvParametros.Size = New System.Drawing.Size(610, 256)
        Me.dgvParametros.TabIndex = 8
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(389, 118)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(470, 118)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BorrarToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(107, 26)
        '
        'BorrarToolStripMenuItem
        '
        Me.BorrarToolStripMenuItem.Name = "BorrarToolStripMenuItem"
        Me.BorrarToolStripMenuItem.Size = New System.Drawing.Size(106, 22)
        Me.BorrarToolStripMenuItem.Text = "&Borrar"
        '
        'pnlParametro
        '
        Me.pnlParametro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlParametro.Controls.Add(Me.cboModulos)
        Me.pnlParametro.Controls.Add(Me.txtValor)
        Me.pnlParametro.Controls.Add(Me.btnCancelar)
        Me.pnlParametro.Controls.Add(Me.Label1)
        Me.pnlParametro.Controls.Add(Me.btnAceptar)
        Me.pnlParametro.Controls.Add(Me.cboUsuarios)
        Me.pnlParametro.Controls.Add(Me.Label2)
        Me.pnlParametro.Controls.Add(Me.Label4)
        Me.pnlParametro.Controls.Add(Me.cboParametros)
        Me.pnlParametro.Controls.Add(Me.Label3)
        Me.pnlParametro.Location = New System.Drawing.Point(54, 12)
        Me.pnlParametro.Name = "pnlParametro"
        Me.pnlParametro.Size = New System.Drawing.Size(610, 152)
        Me.pnlParametro.TabIndex = 11
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(12, 12)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(36, 23)
        Me.btnAgregar.TabIndex = 11
        Me.btnAgregar.Text = "+"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Modulo
        '
        Me.Modulo.DataPropertyName = "ModuloNombre"
        Me.Modulo.HeaderText = "Modulo"
        Me.Modulo.Name = "Modulo"
        Me.Modulo.ReadOnly = True
        '
        'Usuario
        '
        Me.Usuario.DataPropertyName = "Usuario"
        Me.Usuario.HeaderText = "Usuario"
        Me.Usuario.Name = "Usuario"
        Me.Usuario.ReadOnly = True
        Me.Usuario.Width = 70
        '
        'Parametro
        '
        Me.Parametro.DataPropertyName = "Parametro"
        Me.Parametro.HeaderText = "Parámetro"
        Me.Parametro.Name = "Parametro"
        Me.Parametro.ReadOnly = True
        Me.Parametro.Width = 180
        '
        'Valor
        '
        Me.Valor.DataPropertyName = "Valor"
        Me.Valor.HeaderText = "Valor"
        Me.Valor.Name = "Valor"
        Me.Valor.Width = 150
        '
        'Activo
        '
        Me.Activo.DataPropertyName = "Activo"
        Me.Activo.HeaderText = "Activo"
        Me.Activo.Name = "Activo"
        Me.Activo.Width = 66
        '
        'frmParametrosUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 437)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.pnlParametro)
        Me.Controls.Add(Me.dgvParametros)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmParametrosUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parametros por Usuario"
        CType(Me.dgvParametros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.pnlParametro.ResumeLayout(False)
        Me.pnlParametro.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboModulos As System.Windows.Forms.ComboBox
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboParametros As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvParametros As System.Windows.Forms.DataGridView
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BorrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlParametro As System.Windows.Forms.Panel
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Modulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Parametro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Activo As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class

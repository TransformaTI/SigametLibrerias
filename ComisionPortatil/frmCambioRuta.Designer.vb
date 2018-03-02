<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambioRuta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCambioRuta))
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboRuta = New PortatilClasses.Combo.ComboRutaPtl()
        Me.lblCamiontck = New System.Windows.Forms.Label()
        Me.lblTripulacion = New System.Windows.Forms.Label()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(406, 19)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 58
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRuta
        '
        Me.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRuta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.Location = New System.Drawing.Point(102, 18)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(254, 21)
        Me.lblRuta.TabIndex = 0
        Me.lblRuta.Text = "Camion"
        Me.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboRuta)
        Me.GroupBox2.Controls.Add(Me.lblRuta)
        Me.GroupBox2.Controls.Add(Me.lblCamiontck)
        Me.GroupBox2.Controls.Add(Me.lblTripulacion)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 11)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(384, 80)
        Me.GroupBox2.TabIndex = 60
        Me.GroupBox2.TabStop = False
        '
        'cboRuta
        '
        Me.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRuta.FormattingEnabled = True
        Me.cboRuta.Location = New System.Drawing.Point(102, 47)
        Me.cboRuta.Name = "cboRuta"
        Me.cboRuta.Size = New System.Drawing.Size(254, 21)
        Me.cboRuta.TabIndex = 54
        '
        'lblCamiontck
        '
        Me.lblCamiontck.AutoSize = True
        Me.lblCamiontck.Enabled = False
        Me.lblCamiontck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCamiontck.Location = New System.Drawing.Point(16, 22)
        Me.lblCamiontck.Name = "lblCamiontck"
        Me.lblCamiontck.Size = New System.Drawing.Size(80, 13)
        Me.lblCamiontck.TabIndex = 53
        Me.lblCamiontck.Text = "Ruta asignada:"
        '
        'lblTripulacion
        '
        Me.lblTripulacion.AutoSize = True
        Me.lblTripulacion.Enabled = False
        Me.lblTripulacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTripulacion.Location = New System.Drawing.Point(62, 50)
        Me.lblTripulacion.Name = "lblTripulacion"
        Me.lblTripulacion.Size = New System.Drawing.Size(34, 13)
        Me.lblTripulacion.TabIndex = 51
        Me.lblTripulacion.Text = "Ruta:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(406, 51)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 59
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCambioRuta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 102)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnCancelar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCambioRuta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificación de ruta asignada"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCamiontck As System.Windows.Forms.Label
    Friend WithEvents lblTripulacion As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents cboRuta As PortatilClasses.Combo.ComboRutaPtl
End Class

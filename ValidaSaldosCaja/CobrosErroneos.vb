Public Class CobrosErroneos
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
    Friend WithEvents dgCobros As CustGrd.vwGrd
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CobrosErroneos))
        Me.dgCobros = New CustGrd.vwGrd()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblMensaje = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'dgCobros
        '
        Me.dgCobros.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dgCobros.ColumnMargin = 20
        Me.dgCobros.Location = New System.Drawing.Point(0, 32)
        Me.dgCobros.Name = "dgCobros"
        Me.dgCobros.Size = New System.Drawing.Size(688, 188)
        Me.dgCobros.TabIndex = 0
        Me.dgCobros.View = System.Windows.Forms.View.Details
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(524, 228)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "   &Sí"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(604, 228)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "     &No"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(4, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(497, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "¿Desea eliminar los cobros siguientes para proceder con la validación del movimie" & _
        "nto?"
        '
        'lblMensaje
        '
        Me.lblMensaje.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.ForeColor = System.Drawing.Color.Maroon
        Me.lblMensaje.Location = New System.Drawing.Point(4, 232)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(497, 14)
        Me.lblMensaje.TabIndex = 4
        '
        'CobrosErroneos
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(688, 257)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblMensaje, Me.Label1, Me.btnCancelar, Me.btnAceptar, Me.dgCobros})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CobrosErroneos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cobros Erroneos"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _caja As Short
    Private _fOperacion As DateTime
    Private _consecutivo As Short
    Private _folio As Integer

    Private _totalMovimiento As Decimal

    Private _cobroErroneo As CobroErroneo

    Public Sub New(ByVal Caja As Integer, ByVal FOperacion As DateTime, _
        ByVal Consecutivo As Short, ByVal Folio As Integer, _
        ByVal Usuario As String, _
        ByVal TotalMovimientoCaja As Decimal, _
        ByVal Connection As SqlClient.SqlConnection)
        InitializeComponent()
        _totalMovimiento = TotalMovimientoCaja
        _cobroErroneo = New CobroErroneo(Caja, FOperacion, Consecutivo, Folio, Usuario, Connection)
    End Sub

    Private Sub CobrosErroneos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgCobros.DataSource = _cobroErroneo.CobroErroneo
        dgCobros.AutoColumnHeader()
        dgCobros.DataAdd()

        ValidaSaldoCaja()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MessageBox.Show("Se eliminarán los cobros listados" & vbCrLf & "¿Desea continuar?", Me.Text, _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                _cobroErroneo.EliminaCobros()
                MessageBox.Show("Se ha modificaco exitosamente el movimiento" & vbCrLf & _
                    "para validarlo carguelo nuevamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.Yes
            Catch ex As Exception
                MessageBox.Show("Ha ocurrido un error " & vbCrLf & _
                    ex.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.No
    End Sub

    Private Sub ValidaSaldoCaja()
        If _totalMovimiento = _cobroErroneo.CobroErroneo.Compute("SUM(Total)", "1=1") Then
            btnAceptar.Enabled = False
            lblMensaje.Text = "Este movimiento no podrá ser modificado"
        End If
    End Sub
End Class

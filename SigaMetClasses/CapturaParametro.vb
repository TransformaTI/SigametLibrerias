Option Strict On
Imports System.Data.SqlClient, System.Windows.Forms
Public Class CapturaParametro
    Inherits System.Windows.Forms.Form
    Private _Modulo As Short
    Private _Parametro As String
    Private _Corporativo As Short
    Private _Sucursal As Short
    Private _TipoAccion As SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo = Enumeradores.enumTipoOperacionCatalogo.Agregar
    Private dtCorporativo As New DataTable()
    Private dtSucursal As New DataTable()

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
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblParametro As System.Windows.Forms.Label
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
    Friend WithEvents txtParametro As System.Windows.Forms.TextBox
    Friend WithEvents lblCorporativo As System.Windows.Forms.Label
    Friend WithEvents lblSucursal As System.Windows.Forms.Label
    Friend WithEvents cboCorporativo As System.Windows.Forms.ComboBox
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CapturaParametro))
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblParametro = New System.Windows.Forms.Label()
        Me.txtParametro = New System.Windows.Forms.TextBox()
        Me.lblCorporativo = New System.Windows.Forms.Label()
        Me.lblSucursal = New System.Windows.Forms.Label()
        Me.cboCorporativo = New System.Windows.Forms.ComboBox()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txtValor
        '
        Me.txtValor.Location = New System.Drawing.Point(96, 40)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(376, 21)
        Me.txtValor.TabIndex = 1
        Me.txtValor.Text = ""
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(163, 151)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(251, 151)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(96, 112)
        Me.txtObservaciones.MaxLength = 250
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(376, 21)
        Me.txtObservaciones.TabIndex = 4
        Me.txtObservaciones.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Parámetro:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Valor:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 14)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Observaciones:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblParametro
        '
        Me.lblParametro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblParametro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParametro.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblParametro.Location = New System.Drawing.Point(96, 16)
        Me.lblParametro.Name = "lblParametro"
        Me.lblParametro.Size = New System.Drawing.Size(376, 21)
        Me.lblParametro.TabIndex = 0
        Me.lblParametro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtParametro
        '
        Me.txtParametro.Location = New System.Drawing.Point(96, 16)
        Me.txtParametro.Name = "txtParametro"
        Me.txtParametro.Size = New System.Drawing.Size(376, 21)
        Me.txtParametro.TabIndex = 0
        Me.txtParametro.Text = ""
        '
        'lblCorporativo
        '
        Me.lblCorporativo.AutoSize = True
        Me.lblCorporativo.Location = New System.Drawing.Point(8, 67)
        Me.lblCorporativo.Name = "lblCorporativo"
        Me.lblCorporativo.Size = New System.Drawing.Size(66, 14)
        Me.lblCorporativo.TabIndex = 7
        Me.lblCorporativo.Text = "Corporativo:"
        Me.lblCorporativo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.Location = New System.Drawing.Point(8, 91)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(50, 14)
        Me.lblSucursal.TabIndex = 8
        Me.lblSucursal.Text = "Sucursal:"
        Me.lblSucursal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCorporativo
        '
        Me.cboCorporativo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCorporativo.Location = New System.Drawing.Point(96, 64)
        Me.cboCorporativo.Name = "cboCorporativo"
        Me.cboCorporativo.Size = New System.Drawing.Size(376, 21)
        Me.cboCorporativo.TabIndex = 2
        '
        'cboSucursal
        '
        Me.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursal.Location = New System.Drawing.Point(96, 88)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(376, 21)
        Me.cboSucursal.TabIndex = 3
        '
        'CapturaParametro
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(488, 192)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboSucursal, Me.cboCorporativo, Me.lblSucursal, Me.lblCorporativo, Me.txtParametro, Me.lblParametro, Me.Label3, Me.Label2, Me.Label1, Me.txtObservaciones, Me.btnCancelar, Me.btnAceptar, Me.txtValor})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CapturaParametro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar nuevo parámetro"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal Modulo As Short)
        MyBase.New()
        InitializeComponent()
        _Modulo = Modulo
        _TipoAccion = Enumeradores.enumTipoOperacionCatalogo.Agregar
        lblParametro.Visible = False
        txtParametro.Visible = True
        CargarCombos()
    End Sub

    Public Sub New(ByVal Modulo As Short, ByVal Parametro As String, ByVal Valor As String, ByVal Observaciones As String, ByVal Corporativo As Short, ByVal Sucursal As Short)
        MyBase.New()
        InitializeComponent()
        _Modulo = Modulo
        _Parametro = Parametro
        _Corporativo = Corporativo
        _Sucursal = Sucursal
        _TipoAccion = Enumeradores.enumTipoOperacionCatalogo.Modificar
        Me.Text = "Modificar parámetro"
        lblParametro.Visible = True
        txtParametro.Visible = False
        CargarCombos()
        lblParametro.Text = Parametro.Trim
        txtValor.Text = Valor.Trim
        txtObservaciones.Text = Observaciones.Trim
        cboCorporativo.SelectedValue = _Corporativo
        If _TipoAccion = Enumeradores.enumTipoOperacionCatalogo.Modificar Then
            cboCorporativo.Enabled = False
            cboSucursal.Enabled = False
        End If
    End Sub

    Private Sub CargarCombos()
        Dim cmdParametro As New SqlCommand("SELECT Corporativo, Nombre FROM Corporativo", DataLayer.Conexion)
        Dim daParametro As New SqlDataAdapter(cmdParametro)
        Try
            daParametro.Fill(dtCorporativo)
            cmdParametro.CommandText = "SELECT S.Sucursal, S.Descripcion, C.Corporativo FROM Sucursal S INNER JOIN Celula C On S.Sucursal = C.Sucursal GROUP BY S.Sucursal, S.Descripcion, C.Corporativo"
            daParametro.Fill(dtSucursal)
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        cboCorporativo.Tag = 1
        cboCorporativo.ValueMember = "Corporativo"
        cboCorporativo.DisplayMember = "Nombre"
        cboCorporativo.DataSource = dtCorporativo
        cboCorporativo.Tag = 0
    End Sub

    Private Sub CargaParametro(ByVal Modulo As Short, ByVal Parametro As String)
        Dim strQuery As String = _
        "SELECT Parametro, Valor, Observaciones FROM Parametro WHERE Modulo = " & Modulo.ToString & _
        " AND Parametro = '" & _Parametro & "'"
        Dim da As New SqlDataAdapter(strQuery, DataLayer.Conexion)
        Dim dt As New DataTable("Parametro")
        Try
            da.Fill(dt)
            If dt.Rows.Count = 1 Then
                lblParametro.Text = CType(dt.Rows(0).Item("Parametro"), String)
                txtValor.Text = CType(dt.Rows(0).Item("Valor"), String)
                txtObservaciones.Text = CType(dt.Rows(0).Item("Observaciones"), String)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            dt.Dispose()
        End Try
    End Sub


    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        AltaModifica()
    End Sub

    Private Function ValidaDatos() As Boolean
        If Trim(lblParametro.Text).Length = 0 Then
            MessageBox.Show("Por favor escriba el nombre del parámetro.", "Parámetros", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtParametro
            Return False
        ElseIf txtValor.Text.Trim.Length = 0 Then
            MessageBox.Show("Por favor escriba el valor del parámetro.", "Parámetros", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtValor
            Return False
        ElseIf cboCorporativo.Text.Trim.Length = 0 Then
            MessageBox.Show("Por favor seleccione el corporativo al que pertenece el parámetro.", "Parámetros", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = cboCorporativo
            Return False
        ElseIf cboSucursal.Text.Trim.Length = 0 Then
            MessageBox.Show("Por favor seleccione la sucursal a la que pertenece el parámetro.", "Parámetros", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = cboSucursal
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub AltaModifica()
        If ValidaDatos() Then
            If MessageBox.Show(SigaMetClasses.M_ESTAN_CORRECTOS, "Captura de parámetro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim cmd As New SqlCommand("spParametroAltaModifica")
                With cmd
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add("@Modulo", SqlDbType.SmallInt).Value = _Modulo
                    .Parameters.Add("@Parametro", SqlDbType.Char, 25).Value = Trim(lblParametro.Text)
                    .Parameters.Add("@Valor", SqlDbType.VarChar, 250).Value = txtValor.Text
                    .Parameters.Add("@Observaciones", SqlDbType.VarChar, 250).Value = txtObservaciones.Text
                    .Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = cboCorporativo.SelectedValue
                    .Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = cboSucursal.SelectedValue
                    If _TipoAccion = Enumeradores.enumTipoOperacionCatalogo.Modificar Then
                        .Parameters.Add("@Alta", SqlDbType.Bit).Value = 0
                    End If
                End With
                Try
                    AbreConexion()
                    cmd.Connection = DataLayer.Conexion
                    cmd.ExecuteNonQuery()
                    Me.DialogResult = DialogResult.OK

                Catch ex As Exception
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    cmd.Dispose()
                    CierraConexion()
                    Cursor = Cursors.Default
                End Try
            End If
        End If
    End Sub

    Private Sub txtParametro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtParametro.TextChanged
        lblParametro.Text = txtParametro.Text
    End Sub

    Private Sub cboCorporativo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCorporativo.SelectedIndexChanged
        If CInt(cboCorporativo.Tag) = 0 Then
            Try
                cboSucursal.DataSource = Nothing
                cboSucursal.ValueMember = "Sucursal"
                cboSucursal.DisplayMember = "Descripcion"
                dtSucursal.DefaultView.RowFilter = "Corporativo = " & CStr(cboCorporativo.SelectedValue)
                cboSucursal.DataSource = dtSucursal.DefaultView
            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class

Imports System.Windows.Forms
Public Class EquipoCaptura
    Inherits System.Windows.Forms.Form
    Private _Titulo As String
    Private _Equipo As Short
    Private _TipoOperacion As SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar
        _Titulo = "Alta de equipo"

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
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtCosto As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtPrecio As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtCapacidad As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cboTipoEquipo As STClienteEquipo.ComboTipoEquipo
    Friend WithEvents cboMarcaEquipo As STClienteEquipo.ComboMarcaEquipo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(EquipoCaptura))
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtCosto = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtPrecio = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtCapacidad = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.cboTipoEquipo = New STClienteEquipo.ComboTipoEquipo()
        Me.cboMarcaEquipo = New STClienteEquipo.ComboMarcaEquipo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(104, 16)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(240, 21)
        Me.txtDescripcion.TabIndex = 0
        Me.txtDescripcion.Text = ""
        '
        'txtCosto
        '
        Me.txtCosto.Location = New System.Drawing.Point(104, 40)
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.TabIndex = 1
        Me.txtCosto.Text = ""
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(104, 64)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.TabIndex = 2
        Me.txtPrecio.Text = ""
        '
        'txtCapacidad
        '
        Me.txtCapacidad.Location = New System.Drawing.Point(104, 88)
        Me.txtCapacidad.Name = "txtCapacidad"
        Me.txtCapacidad.TabIndex = 3
        Me.txtCapacidad.Text = ""
        '
        'cboTipoEquipo
        '
        Me.cboTipoEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoEquipo.Location = New System.Drawing.Point(104, 112)
        Me.cboTipoEquipo.Name = "cboTipoEquipo"
        Me.cboTipoEquipo.Size = New System.Drawing.Size(184, 21)
        Me.cboTipoEquipo.TabIndex = 4
        '
        'cboMarcaEquipo
        '
        Me.cboMarcaEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMarcaEquipo.Location = New System.Drawing.Point(104, 136)
        Me.cboMarcaEquipo.Name = "cboMarcaEquipo"
        Me.cboMarcaEquipo.Size = New System.Drawing.Size(184, 21)
        Me.cboMarcaEquipo.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 14)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Descripción:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 14)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Costo:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 14)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Precio:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 14)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Capacidad:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 14)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Tipo:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 14)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Marca:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(368, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 12
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(368, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EquipoCaptura
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(448, 181)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnAceptar, Me.Label6, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.Label1, Me.cboMarcaEquipo, Me.cboTipoEquipo, Me.txtCapacidad, Me.txtPrecio, Me.txtCosto, Me.txtDescripcion})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EquipoCaptura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EquipoCaptura"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal Equipo As Short)
        MyBase.New()
        InitializeComponent()
        _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar
        _Equipo = Equipo
        _Titulo = "Modificación de equipo"
    End Sub

    Private Sub EquipoCaptura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboTipoEquipo.CargaDatos()
        cboMarcaEquipo.CargaDatos()
        Me.Text = _Titulo
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar Then
            CargaDatos(_Equipo)
        End If
    End Sub

    Private Sub CargaDatos(ByVal Equipo As Short)
        Cursor = Cursors.WaitCursor
        Dim oEquipo As New cEquipo()
        Dim dt As DataTable = oEquipo.Consulta(Equipo)
        If dt.Rows.Count = 1 Then
            If Not IsDBNull(dt.Rows(0).Item("Descripcion")) Then txtDescripcion.Text = CType(dt.Rows(0).Item("Descripcion"), String)
            If Not IsDBNull(dt.Rows(0).Item("Costo")) Then txtCosto.Text = CType(dt.Rows(0).Item("Costo"), Decimal).ToString("N")
            If Not IsDBNull(dt.Rows(0).Item("Precio")) Then txtPrecio.Text = CType(dt.Rows(0).Item("Precio"), Decimal).ToString("N")
            If Not IsDBNull(dt.Rows(0).Item("Capacidad")) Then txtCapacidad.Text = CType(dt.Rows(0).Item("Capacidad"), Integer).ToString
            If Not IsDBNull(dt.Rows(0).Item("TipoEquipo")) Then cboTipoEquipo.SelectedValue = dt.Rows(0).Item("TipoEquipo")
            If Not IsDBNull(dt.Rows(0).Item("MarcaEquipo")) Then cboMarcaEquipo.SelectedValue = dt.Rows(0).Item("MarcaEquipo")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub AltaModifica()
        Dim oEquipo As New cEquipo()
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Agregar Then
            oEquipo.AltaModifica(txtDescripcion.Text, CType(txtCosto.Text, Decimal), CType(txtPrecio.Text, Decimal), CType(txtCapacidad.Text, Integer), CType(cboTipoEquipo.SelectedValue, Byte), CType(cboMarcaEquipo.SelectedValue, Byte))
        End If
        If _TipoOperacion = SigaMetClasses.Enumeradores.enumTipoOperacionCatalogo.Modificar Then
            oEquipo.AltaModifica(txtDescripcion.Text, CType(txtCosto.Text, Decimal), CType(txtPrecio.Text, Decimal), CType(txtCapacidad.Text, Integer), CType(cboTipoEquipo.SelectedValue, Byte), CType(cboMarcaEquipo.SelectedValue, Byte), _Equipo, False)
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MessageBox.Show(SigaMetClasses.M_ESTAN_CORRECTOS, _Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Try
                Cursor = Cursors.WaitCursor
                AltaModifica()
                Cursor = Cursors.Default
                DialogResult = DialogResult.OK
            Catch ex As Exception
                DialogResult = DialogResult.Cancel
            End Try
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class
Imports System.Data.SqlClient

Public Class frmConsultaTanque
    Inherits System.Windows.Forms.Form

    Private _Cliente As Integer

    Private _dtTable As DataTable

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Cliente As Integer, ByVal Nombre As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _Cliente = Cliente
        Me.Text = "Equipos - [" + Nombre + "]"
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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboSecuencia As System.Windows.Forms.ComboBox
    Friend WithEvents lblEquipo As System.Windows.Forms.Label
    Friend WithEvents lblFValvulas As System.Windows.Forms.Label
    Friend WithEvents lblFCaducidad As System.Windows.Forms.Label
    Friend WithEvents lblFUltrasonido As System.Windows.Forms.Label
    Friend WithEvents lblFFabricacion As System.Windows.Forms.Label
    Friend WithEvents lblPropiedad As System.Windows.Forms.Label
    Friend WithEvents lblSerie As System.Windows.Forms.Label
    Friend WithEvents lblCapacidad As System.Windows.Forms.Label
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConsultaTanque))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboSecuencia = New System.Windows.Forms.ComboBox()
        Me.lblEquipo = New System.Windows.Forms.Label()
        Me.lblFValvulas = New System.Windows.Forms.Label()
        Me.lblFCaducidad = New System.Windows.Forms.Label()
        Me.lblFUltrasonido = New System.Windows.Forms.Label()
        Me.lblFFabricacion = New System.Windows.Forms.Label()
        Me.lblPropiedad = New System.Windows.Forms.Label()
        Me.lblSerie = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblCapacidad = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(472, 16)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cerrar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboSecuencia, Me.lblEquipo, Me.lblFValvulas, Me.lblFCaducidad, Me.lblFUltrasonido, Me.lblFFabricacion, Me.lblPropiedad, Me.lblSerie, Me.Label10, Me.Label4, Me.Label3, Me.Label1, Me.Label2, Me.Label11, Me.Label9, Me.Label8, Me.Label7, Me.Label6, Me.Label5, Me.Label14, Me.lblCapacidad, Me.lblTipo, Me.lblMarca})
        Me.GroupBox1.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(448, 312)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        '
        'cboSecuencia
        '
        Me.cboSecuencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSecuencia.Location = New System.Drawing.Point(131, 20)
        Me.cboSecuencia.Name = "cboSecuencia"
        Me.cboSecuencia.Size = New System.Drawing.Size(101, 21)
        Me.cboSecuencia.TabIndex = 73
        '
        'lblEquipo
        '
        Me.lblEquipo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEquipo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEquipo.Location = New System.Drawing.Point(131, 61)
        Me.lblEquipo.Name = "lblEquipo"
        Me.lblEquipo.Size = New System.Drawing.Size(302, 23)
        Me.lblEquipo.TabIndex = 72
        Me.lblEquipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFValvulas
        '
        Me.lblFValvulas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFValvulas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFValvulas.Location = New System.Drawing.Point(131, 277)
        Me.lblFValvulas.Name = "lblFValvulas"
        Me.lblFValvulas.Size = New System.Drawing.Size(302, 23)
        Me.lblFValvulas.TabIndex = 71
        Me.lblFValvulas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFCaducidad
        '
        Me.lblFCaducidad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFCaducidad.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFCaducidad.Location = New System.Drawing.Point(131, 253)
        Me.lblFCaducidad.Name = "lblFCaducidad"
        Me.lblFCaducidad.Size = New System.Drawing.Size(302, 23)
        Me.lblFCaducidad.TabIndex = 70
        Me.lblFCaducidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFUltrasonido
        '
        Me.lblFUltrasonido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFUltrasonido.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFUltrasonido.Location = New System.Drawing.Point(131, 229)
        Me.lblFUltrasonido.Name = "lblFUltrasonido"
        Me.lblFUltrasonido.Size = New System.Drawing.Size(302, 23)
        Me.lblFUltrasonido.TabIndex = 69
        Me.lblFUltrasonido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFFabricacion
        '
        Me.lblFFabricacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFFabricacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFFabricacion.Location = New System.Drawing.Point(131, 205)
        Me.lblFFabricacion.Name = "lblFFabricacion"
        Me.lblFFabricacion.Size = New System.Drawing.Size(302, 23)
        Me.lblFFabricacion.TabIndex = 68
        Me.lblFFabricacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPropiedad
        '
        Me.lblPropiedad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPropiedad.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropiedad.Location = New System.Drawing.Point(131, 181)
        Me.lblPropiedad.Name = "lblPropiedad"
        Me.lblPropiedad.Size = New System.Drawing.Size(302, 23)
        Me.lblPropiedad.TabIndex = 67
        Me.lblPropiedad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSerie
        '
        Me.lblSerie.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSerie.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerie.Location = New System.Drawing.Point(131, 157)
        Me.lblSerie.Name = "lblSerie"
        Me.lblSerie.Size = New System.Drawing.Size(302, 23)
        Me.lblSerie.TabIndex = 66
        Me.lblSerie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label10.Location = New System.Drawing.Point(15, 113)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 14)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "Tipo de equipo :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 233)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 14)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "Fecha de ultrasonido :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 209)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 14)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Fecha de fabricación :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 14)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Número de equipo :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 14)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Serie :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label11.Location = New System.Drawing.Point(15, 185)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 14)
        Me.Label11.TabIndex = 64
        Me.Label11.Text = "Tipo propiedad :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 63)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 14)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "Equipo :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label8.Location = New System.Drawing.Point(15, 137)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 14)
        Me.Label8.TabIndex = 61
        Me.Label8.Text = "Capacidad :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 14)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "Marca del equipo :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 257)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 14)
        Me.Label6.TabIndex = 59
        Me.Label6.Text = "Fecha de caducidad :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 281)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 14)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "Cambio de valvulas :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(243, 137)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 14)
        Me.Label14.TabIndex = 65
        Me.Label14.Text = "Litros"
        '
        'lblCapacidad
        '
        Me.lblCapacidad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCapacidad.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacidad.Location = New System.Drawing.Point(131, 133)
        Me.lblCapacidad.Name = "lblCapacidad"
        Me.lblCapacidad.Size = New System.Drawing.Size(104, 23)
        Me.lblCapacidad.TabIndex = 57
        Me.lblCapacidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTipo
        '
        Me.lblTipo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.Location = New System.Drawing.Point(131, 109)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(302, 23)
        Me.lblTipo.TabIndex = 55
        Me.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMarca
        '
        Me.lblMarca.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMarca.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarca.Location = New System.Drawing.Point(131, 85)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(302, 23)
        Me.lblMarca.TabIndex = 54
        Me.lblMarca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmConsultaTanque
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(552, 318)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.btnCancelar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmConsultaTanque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmConsultaTanque"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Function CargarSecuencia() As Boolean
        Cursor = Cursors.WaitCursor
        Dim oSecuencia As New Consulta.cClienteEquipo(0, _Cliente)
        Dim i As Integer = 0
        Do While i < oSecuencia.dtTable.Rows.Count
            cboSecuencia.Items.Add(CType(oSecuencia.dtTable.Rows(i).Item(0), String))
            i = i + 1
        Loop
        If cboSecuencia.Items.Count = 0 Then
            Return False
        Else
            cboSecuencia.SelectedIndex = 0
            Return True
        End If
        Cursor = Cursors.Default
    End Function

    Public Sub CargarTanque(ByVal Index As Integer)
        Cursor = Cursors.WaitCursor
        lblFFabricacion.Text = ""
        lblFUltrasonido.Text = ""
        lblFCaducidad.Text = ""
        lblFValvulas.Text = ""

        lblEquipo.Text = CType(_dtTable.Rows(Index).Item(1), String)
        lblMarca.Text = CType(_dtTable.Rows(Index).Item(2), String)
        lblTipo.Text = CType(_dtTable.Rows(Index).Item(3), String)
        lblCapacidad.Text = CType(_dtTable.Rows(Index).Item(4), String)
        lblSerie.Text = CType(_dtTable.Rows(Index).Item(5), String)
        lblPropiedad.Text = CType(_dtTable.Rows(Index).Item(6), String)
        If Not IsDBNull(_dtTable.Rows(Index).Item(7)) Then
            lblFFabricacion.Text = CType(_dtTable.Rows(Index).Item(7), String)
        End If
        If Not IsDBNull(_dtTable.Rows(Index).Item(8)) Then
            lblFUltrasonido.Text = CType(_dtTable.Rows(Index).Item(8), String)
        End If
        If Not IsDBNull(_dtTable.Rows(Index).Item(9)) Then
            lblFCaducidad.Text = CType(_dtTable.Rows(Index).Item(9), String)
        End If
        If Not IsDBNull(_dtTable.Rows(Index).Item(10)) Then
            lblFValvulas.Text = CType(_dtTable.Rows(Index).Item(10), String)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub cboTanque_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub frmTanque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActiveControl = cboSecuencia
        Dim oTanque As New Consulta.cClienteEquipo(1, _Cliente)
        _dtTable = oTanque.dtTable
        oTanque = Nothing
        CargarTanque(cboSecuencia.SelectedIndex)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub cboSecuencia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSecuencia.SelectedIndexChanged
        If cboSecuencia.Focused Then
            CargarTanque(cboSecuencia.SelectedIndex)
        End If
    End Sub
End Class

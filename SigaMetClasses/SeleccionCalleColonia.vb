Imports System.Data.SqlClient, System.Windows.Forms, System.Drawing
Imports System.Xml
Imports System.IO

Public Class SeleccionCalleColonia
    Inherits System.Windows.Forms.UserControl
    Private _Titulo As String = "Calles y colonias"
    Private cnServidor As SqlConnection
    Private _Calle As Integer
    Private _EntreCalle1 As Integer
    Private _EntreCalle2 As Integer
    Private _Colonia As Integer
    Private _NumExterior As Integer
    Private _NumInterior As String = ""
    Private _CP As String
    Private _Municipio As Integer

    Private _ExisteCalle As Boolean
    Private _ExisteEntreCalle1 As Boolean
    Private _ExisteEntreCalle2 As Boolean
    Private _ExisteColonia As Boolean
    Private _ExisteCP As Boolean
    Private _SoloLectura As Boolean

    Private _OtraColoniaSeleccionada As Boolean
    Private _EdicionDatos As Boolean
    Private _EdicionColonia As Boolean
    Private _CargaCliente As Boolean
    Private _CargaClienteSoloLectura As Boolean = False
    Private _DatosCargados As Boolean

    'Datos originales de la carga
    Private _CalleOriginal As Integer
    Private _ColoniaOriginal As Integer
    Private _EntreCalle1Original As Integer
    Private _EntreCalle2Original As Integer
    Private _NumInteriorOriginal As String
    Private _NumExteriorOriginal As String
    Private _CalleNombreOriginal As String
    Private _ColoniaNombreOriginal As String
    Public _URLGateway As String
    Private _Modulo As Byte
    Private _Corporativo As Short

    Dim dtCalle As DataTable

    'Control de alta de calles y colonias
    Private _AltaCalleColonia As Boolean = True
    Private _Limpiado As Boolean = False


#Region "Propiedades"
    Public Property Calle() As Integer
        Get
            Return _Calle
        End Get
        Set(ByVal Value As Integer)
            _Calle = Value
        End Set
    End Property

    Public Property AltaCalleColonia() As Boolean
        Get
            Return _AltaCalleColonia
        End Get
        Set(ByVal Value As Boolean)
            _AltaCalleColonia = Value
            txtCalle.Visible = _AltaCalleColonia
            txtCalle.Enabled = _AltaCalleColonia
            txtEntreCalle1.Visible = _AltaCalleColonia
            txtEntreCalle1.Enabled = _AltaCalleColonia
            txtEntreCalle2.Visible = _AltaCalleColonia
            txtEntreCalle2.Enabled = _AltaCalleColonia
            cboCalle.Visible = Not _AltaCalleColonia
            cboEntreCalle1.Visible = Not _AltaCalleColonia
            cboEntreCalle2.Visible = Not _AltaCalleColonia
            If _AltaCalleColonia Then
                cboColonia.DropDownStyle = ComboBoxStyle.DropDown
            Else
                cboColonia.DropDownStyle = ComboBoxStyle.DropDownList
                CargaCalles()
            End If
        End Set
    End Property

    Public ReadOnly Property CalleNombre() As String
        Get
            If _SoloLectura Then
                Return lblCalle.Text.Trim
            Else
                Return Me.txtCalle.Text.Trim
            End If
        End Get
    End Property

    Public ReadOnly Property EntreCalle1() As Integer
        Get
            Return _EntreCalle1
        End Get
    End Property

    Public ReadOnly Property EntreCalle2() As Integer
        Get
            Return _EntreCalle2
        End Get
    End Property

    Public Property Colonia() As Integer
        Get
            If Not _ExisteColonia Then
                Return _Colonia
            Else
                If Not IsNothing(cboColonia.DataSource) Then
                    Return CType(cboColonia.SelectedValue, Integer)
                Else
                    Return _Colonia
                End If

            End If

        End Get
        Set(ByVal Value As Integer)
            _Colonia = Value
        End Set
    End Property

    Public ReadOnly Property ColoniaNombre() As String
        Get
            Return cboColonia.Text.Trim
        End Get
    End Property

    Public ReadOnly Property NumExterior() As Integer
        Get
            Return _NumExterior
        End Get
    End Property

    Public ReadOnly Property NumInterior() As String
        Get
            Return _NumInterior
        End Get
    End Property

    Public ReadOnly Property CP() As String
        Get
            Return _CP
        End Get
    End Property

    Public ReadOnly Property Municipio() As Integer
        Get
            Return _Municipio
        End Get
    End Property

    Public ReadOnly Property ExisteCalle() As Boolean
        Get
            Return _ExisteCalle
        End Get
    End Property

    Public ReadOnly Property ExisteEntreCalle1() As Boolean
        Get
            Return _ExisteEntreCalle1
        End Get
    End Property

    Public ReadOnly Property ExisteEntreCalle2() As Boolean
        Get
            Return _ExisteEntreCalle2
        End Get
    End Property

    Public ReadOnly Property ExisteColonia() As Boolean
        Get
            Return _ExisteColonia
        End Get
    End Property

    Public ReadOnly Property CargaCliente() As Boolean
        Get
            Return _CargaCliente
        End Get
    End Property

    Public ReadOnly Property EdicionDatos() As Boolean
        Get
            Return _EdicionDatos
        End Get
    End Property

    Public Property Modulo As Byte
        Get
            Return _Modulo
        End Get
        Set(value As Byte)
            _Modulo = value
        End Set
    End Property

    Public Property Corporativo As Short
        Get
            Return _Corporativo
        End Get
        Set(value As Short)
            _Corporativo = value
        End Set
    End Property

#End Region

#Region " Windows Form Designer generated code "

    Public Sub New(Optional ByVal URLGateway As String = Nothing)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        _URLGateway = URLGateway

        'Add any initialization after the InitializeComponent() call
    End Sub

    'UserControl1 overrides dispose to clean up the component list.
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
    Friend WithEvents txtCalle As System.Windows.Forms.TextBox
    Friend WithEvents cboColonia As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNumExterior As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNumInterior As System.Windows.Forms.TextBox
    Friend WithEvents txtEntreCalle1 As System.Windows.Forms.TextBox
    Friend WithEvents txtEntreCalle2 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lstResults As System.Windows.Forms.ListBox
    Friend WithEvents cboMunicipio As System.Windows.Forms.ComboBox
    Friend WithEvents txtCP As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents lblCalle As System.Windows.Forms.Label
    Friend WithEvents lblNumExterior As System.Windows.Forms.Label
    Friend WithEvents lblNumInterior As System.Windows.Forms.Label
    Friend WithEvents lblEntreCalle1 As System.Windows.Forms.Label
    Friend WithEvents lblEntreCalle2 As System.Windows.Forms.Label
    Friend WithEvents lblColonia As System.Windows.Forms.Label
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblCP As System.Windows.Forms.Label
    Friend WithEvents cboCalle As SigaMetClasses.ComboCalle
    Friend WithEvents cboEntreCalle1 As SigaMetClasses.ComboCalle
    Friend WithEvents cboEntreCalle2 As SigaMetClasses.ComboCalle
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SeleccionCalleColonia))
        Me.txtCalle = New System.Windows.Forms.TextBox()
        Me.cboColonia = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNumExterior = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtNumInterior = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEntreCalle1 = New System.Windows.Forms.TextBox()
        Me.txtEntreCalle2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lstResults = New System.Windows.Forms.ListBox()
        Me.cboMunicipio = New System.Windows.Forms.ComboBox()
        Me.txtCP = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lblCalle = New System.Windows.Forms.Label()
        Me.lblNumExterior = New System.Windows.Forms.Label()
        Me.lblNumInterior = New System.Windows.Forms.Label()
        Me.lblEntreCalle1 = New System.Windows.Forms.Label()
        Me.lblEntreCalle2 = New System.Windows.Forms.Label()
        Me.lblColonia = New System.Windows.Forms.Label()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.lblCP = New System.Windows.Forms.Label()
        Me.cboCalle = New SigaMetClasses.ComboCalle()
        Me.cboEntreCalle1 = New SigaMetClasses.ComboCalle()
        Me.cboEntreCalle2 = New SigaMetClasses.ComboCalle()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtCalle
        '
        Me.txtCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCalle.Location = New System.Drawing.Point(88, 0)
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(448, 21)
        Me.txtCalle.TabIndex = 0
        '
        'cboColonia
        '
        Me.cboColonia.Location = New System.Drawing.Point(88, 72)
        Me.cboColonia.Name = "cboColonia"
        Me.cboColonia.Size = New System.Drawing.Size(448, 21)
        Me.cboColonia.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Calle:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Colonia:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Municipio:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Código postal:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumExterior
        '
        Me.txtNumExterior.Location = New System.Drawing.Point(88, 24)
        Me.txtNumExterior.Name = "txtNumExterior"
        Me.txtNumExterior.Size = New System.Drawing.Size(184, 21)
        Me.txtNumExterior.TabIndex = 1
        '
        'txtNumInterior
        '
        Me.txtNumInterior.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumInterior.Location = New System.Drawing.Point(352, 24)
        Me.txtNumInterior.Name = "txtNumInterior"
        Me.txtNumInterior.Size = New System.Drawing.Size(184, 21)
        Me.txtNumInterior.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "No. Exterior:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(280, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "No. Interior:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEntreCalle1
        '
        Me.txtEntreCalle1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEntreCalle1.Location = New System.Drawing.Point(88, 48)
        Me.txtEntreCalle1.Name = "txtEntreCalle1"
        Me.txtEntreCalle1.ReadOnly = True
        Me.txtEntreCalle1.Size = New System.Drawing.Size(216, 21)
        Me.txtEntreCalle1.TabIndex = 3
        '
        'txtEntreCalle2
        '
        Me.txtEntreCalle2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEntreCalle2.Location = New System.Drawing.Point(328, 48)
        Me.txtEntreCalle2.Name = "txtEntreCalle2"
        Me.txtEntreCalle2.ReadOnly = True
        Me.txtEntreCalle2.Size = New System.Drawing.Size(208, 21)
        Me.txtEntreCalle2.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Entre calle:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(312, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "y:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(296, 122)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 16)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Button1"
        Me.Button1.Visible = False
        '
        'lstResults
        '
        Me.lstResults.Location = New System.Drawing.Point(384, 128)
        Me.lstResults.Name = "lstResults"
        Me.lstResults.Size = New System.Drawing.Size(136, 4)
        Me.lstResults.TabIndex = 17
        Me.lstResults.Visible = False
        '
        'cboMunicipio
        '
        Me.cboMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMunicipio.Enabled = False
        Me.cboMunicipio.Location = New System.Drawing.Point(88, 96)
        Me.cboMunicipio.Name = "cboMunicipio"
        Me.cboMunicipio.Size = New System.Drawing.Size(448, 21)
        Me.cboMunicipio.TabIndex = 6
        '
        'txtCP
        '
        Me.txtCP.Location = New System.Drawing.Point(88, 120)
        Me.txtCP.MaxLength = 5
        Me.txtCP.Name = "txtCP"
        Me.txtCP.ReadOnly = True
        Me.txtCP.Size = New System.Drawing.Size(80, 21)
        Me.txtCP.TabIndex = 7
        '
        'lblCalle
        '
        Me.lblCalle.BackColor = System.Drawing.Color.White
        Me.lblCalle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCalle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalle.ForeColor = System.Drawing.Color.Navy
        Me.lblCalle.Location = New System.Drawing.Point(88, 0)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(448, 21)
        Me.lblCalle.TabIndex = 8
        Me.lblCalle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNumExterior
        '
        Me.lblNumExterior.BackColor = System.Drawing.Color.White
        Me.lblNumExterior.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumExterior.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumExterior.ForeColor = System.Drawing.Color.Navy
        Me.lblNumExterior.Location = New System.Drawing.Point(88, 24)
        Me.lblNumExterior.Name = "lblNumExterior"
        Me.lblNumExterior.Size = New System.Drawing.Size(184, 21)
        Me.lblNumExterior.TabIndex = 9
        Me.lblNumExterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNumInterior
        '
        Me.lblNumInterior.BackColor = System.Drawing.Color.White
        Me.lblNumInterior.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNumInterior.ForeColor = System.Drawing.Color.Black
        Me.lblNumInterior.Location = New System.Drawing.Point(352, 24)
        Me.lblNumInterior.Name = "lblNumInterior"
        Me.lblNumInterior.Size = New System.Drawing.Size(184, 21)
        Me.lblNumInterior.TabIndex = 14
        Me.lblNumInterior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEntreCalle1
        '
        Me.lblEntreCalle1.BackColor = System.Drawing.Color.White
        Me.lblEntreCalle1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEntreCalle1.ForeColor = System.Drawing.Color.Black
        Me.lblEntreCalle1.Location = New System.Drawing.Point(88, 48)
        Me.lblEntreCalle1.Name = "lblEntreCalle1"
        Me.lblEntreCalle1.Size = New System.Drawing.Size(216, 21)
        Me.lblEntreCalle1.TabIndex = 10
        Me.lblEntreCalle1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEntreCalle2
        '
        Me.lblEntreCalle2.BackColor = System.Drawing.Color.White
        Me.lblEntreCalle2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEntreCalle2.ForeColor = System.Drawing.Color.Black
        Me.lblEntreCalle2.Location = New System.Drawing.Point(328, 48)
        Me.lblEntreCalle2.Name = "lblEntreCalle2"
        Me.lblEntreCalle2.Size = New System.Drawing.Size(208, 21)
        Me.lblEntreCalle2.TabIndex = 26
        Me.lblEntreCalle2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblColonia
        '
        Me.lblColonia.BackColor = System.Drawing.Color.White
        Me.lblColonia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblColonia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColonia.ForeColor = System.Drawing.Color.Black
        Me.lblColonia.Location = New System.Drawing.Point(88, 72)
        Me.lblColonia.Name = "lblColonia"
        Me.lblColonia.Size = New System.Drawing.Size(448, 21)
        Me.lblColonia.TabIndex = 11
        Me.lblColonia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMunicipio
        '
        Me.lblMunicipio.BackColor = System.Drawing.Color.White
        Me.lblMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMunicipio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipio.ForeColor = System.Drawing.Color.Black
        Me.lblMunicipio.Location = New System.Drawing.Point(88, 96)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(448, 21)
        Me.lblMunicipio.TabIndex = 12
        Me.lblMunicipio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCP
        '
        Me.lblCP.BackColor = System.Drawing.Color.White
        Me.lblCP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCP.ForeColor = System.Drawing.Color.Black
        Me.lblCP.Location = New System.Drawing.Point(88, 120)
        Me.lblCP.Name = "lblCP"
        Me.lblCP.Size = New System.Drawing.Size(80, 21)
        Me.lblCP.TabIndex = 13
        Me.lblCP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCalle
        '
        Me.cboCalle.CargaDatos = True
        Me.cboCalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboCalle.ItemHeight = 13
        Me.cboCalle.Location = New System.Drawing.Point(88, 0)
        Me.cboCalle.Name = "cboCalle"
        Me.cboCalle.Size = New System.Drawing.Size(448, 21)
        Me.cboCalle.TabIndex = 0
        Me.cboCalle.Visible = False
        '
        'cboEntreCalle1
        '
        Me.cboEntreCalle1.CargaDatos = True
        Me.cboEntreCalle1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboEntreCalle1.ItemHeight = 13
        Me.cboEntreCalle1.Location = New System.Drawing.Point(88, 48)
        Me.cboEntreCalle1.Name = "cboEntreCalle1"
        Me.cboEntreCalle1.Size = New System.Drawing.Size(216, 21)
        Me.cboEntreCalle1.TabIndex = 3
        Me.cboEntreCalle1.Visible = False
        '
        'cboEntreCalle2
        '
        Me.cboEntreCalle2.CargaDatos = True
        Me.cboEntreCalle2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboEntreCalle2.ItemHeight = 13
        Me.cboEntreCalle2.Location = New System.Drawing.Point(328, 48)
        Me.cboEntreCalle2.Name = "cboEntreCalle2"
        Me.cboEntreCalle2.Size = New System.Drawing.Size(206, 21)
        Me.cboEntreCalle2.TabIndex = 4
        Me.cboEntreCalle2.Visible = False
        '
        'btnActualizar
        '
        Me.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualizar.Image = CType(resources.GetObject("btnActualizar.Image"), System.Drawing.Image)
        Me.btnActualizar.Location = New System.Drawing.Point(8, 0)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(24, 24)
        Me.btnActualizar.TabIndex = 27
        Me.btnActualizar.TabStop = False
        '
        'SeleccionCalleColonia
        '
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.cboEntreCalle2)
        Me.Controls.Add(Me.cboEntreCalle1)
        Me.Controls.Add(Me.cboCalle)
        Me.Controls.Add(Me.txtCP)
        Me.Controls.Add(Me.lstResults)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtEntreCalle2)
        Me.Controls.Add(Me.txtEntreCalle1)
        Me.Controls.Add(Me.txtNumInterior)
        Me.Controls.Add(Me.cboColonia)
        Me.Controls.Add(Me.txtCalle)
        Me.Controls.Add(Me.txtNumExterior)
        Me.Controls.Add(Me.lblCalle)
        Me.Controls.Add(Me.lblNumExterior)
        Me.Controls.Add(Me.lblNumInterior)
        Me.Controls.Add(Me.lblEntreCalle1)
        Me.Controls.Add(Me.lblEntreCalle2)
        Me.Controls.Add(Me.lblColonia)
        Me.Controls.Add(Me.cboMunicipio)
        Me.Controls.Add(Me.lblCP)
        Me.Controls.Add(Me.lblMunicipio)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "SeleccionCalleColonia"
        Me.Size = New System.Drawing.Size(536, 144)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub BloqueaControles(ByVal Bloquear As Boolean)

        txtCalle.ReadOnly = Bloquear
        txtCalle.CausesValidation = Not Bloquear
        txtNumExterior.ReadOnly = Bloquear
        txtNumInterior.ReadOnly = Bloquear
        txtEntreCalle1.ReadOnly = Bloquear
        txtEntreCalle2.ReadOnly = Bloquear
        cboColonia.Enabled = Not Bloquear
        'cboMunicipio.Enabled = Not Bloquear
        'txtCP.ReadOnly = Bloquear

        lblCalle.Text = txtCalle.Text
        lblNumExterior.Text = txtNumExterior.Text
        lblNumInterior.Text = txtNumInterior.Text
        lblEntreCalle1.Text = txtEntreCalle1.Text
        lblEntreCalle2.Text = txtEntreCalle2.Text
        lblColonia.Text = cboColonia.Text
        lblMunicipio.Text = cboMunicipio.Text

        txtCalle.Visible = Not Bloquear
        txtNumExterior.Visible = Not Bloquear
        txtNumInterior.Visible = Not Bloquear
        txtEntreCalle1.Visible = Not Bloquear
        txtEntreCalle2.Visible = Not Bloquear
        cboColonia.Visible = Not Bloquear
        cboMunicipio.Visible = Not Bloquear
        txtCP.Visible = Not Bloquear



    End Sub
    Public Sub CargaDatosClienteSoloLectura(ByVal Cliente As Integer)
        _SoloLectura = True
        Dim cmd As New SqlCommand("spCCConsultaDireccionCliente")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 15
            .Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        End With


        If (_URLGateway Is String.Empty Or _URLGateway Is Nothing) Then

            Dim dr As SqlDataReader

            Try

                CargaDatos()
                cmd.Connection = cnServidor
                AbreConexion()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

                If dr.Read() Then
                    _CargaClienteSoloLectura = True
                    Me.lblCalle.Text = CType(dr("CalleNombre"), String).Trim
                    Me.lblColonia.Text = CType(dr("ColoniaNombre"), String).Trim
                    Me.lblCP.Text = CType(dr("CP"), String).Trim
                    Me.lblEntreCalle1.Text = CType(dr("EntreCalle1Nombre"), String).Trim
                    Me.lblEntreCalle2.Text = CType(dr("EntreCalle2Nombre"), String).Trim
                    Me.lblMunicipio.Text = CType(dr("MunicipioNombre"), String).Trim
                    Me.lblNumExterior.Text = CType(dr("NumExterior"), String)
                    Me.lblNumInterior.Text = CType(dr("NumInterior"), String).Trim
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                CierraConexion()
                cmd.Dispose()

            End Try
        Else
            'Se agrega funcionalidad para ir a consultar al WS 
            Dim oDireccionEntrega As New RTGMCore.DireccionEntrega
            oDireccionEntrega = ConsultarDatosClienteCRM(Cliente)

            Me.lblCalle.Text = oDireccionEntrega.CalleNombre
            Me.lblColonia.Text = oDireccionEntrega.ColoniaNombre
            Me.lblCP.Text = oDireccionEntrega.CP
            Me.lblEntreCalle1.Text = oDireccionEntrega.EntreCalle1Nombre
            Me.lblEntreCalle2.Text = oDireccionEntrega.EntreCalle2Nombre
            Me.lblMunicipio.Text = oDireccionEntrega.MunicipioNombre
            Me.lblNumExterior.Text = oDireccionEntrega.NumExterior
            Me.lblNumInterior.Text = oDireccionEntrega.NumInterior

        End If

        Me._CP = Me.lblCP.Text
        txtCalle.Visible = False
        cboColonia.Visible = False
        txtCP.Visible = False
        txtEntreCalle1.Visible = False
        txtEntreCalle2.Visible = False
        cboMunicipio.Visible = False
        txtNumExterior.Visible = False
        txtNumInterior.Visible = False
        txtCalle.Focus()
        'Para la seleccion de calles y colonias
        cboCalle.Visible = False
        cboEntreCalle1.Visible = False
        cboEntreCalle2.Visible = False

    End Sub

    Public Function ConsultarDatosClienteCRM(ByVal Cliente As Integer) As RTGMCore.DireccionEntrega

        Dim oGateway = New RTGMGateway.RTGMGateway(_Modulo, SigaMetClasses.DataLayer.Conexion.ConnectionString)
        Dim oSolicitud As RTGMGateway.SolicitudGateway
        Dim oDireccionEntrega As RTGMCore.DireccionEntrega

        oSolicitud.IDCliente = Cliente
        oSolicitud.IDEmpresa = _Corporativo
        oGateway.URLServicio = _URLGateway
        oDireccionEntrega = oGateway.buscarDireccionEntrega(oSolicitud)

        Return oDireccionEntrega

    End Function

    Public Sub CargaDatosCliente(ByVal Cliente As Integer)
        'Dim strQuery As String = _
        '"SELECT Cliente, Calle, CalleNombre, NumExterior, NumInterior, " & _
        '    "EntreCalle1, Isnull(EntreCalle1Nombre,'') as EntreCalle1Nombre, " & _
        '    "EntreCalle2, Isnull(EntreCalle2Nombre,'') as EntreCalle2Nombre, " & _
        '    "Colonia, ColoniaNombre, CP, Municipio " & _
        '    "FROM vwDatosCliente WHERE Cliente = @Cliente"
        Dim strQuery As String = "EXECUTE spCCSelCalleColoniaConsultaDatosCliente @Cliente"
        Dim cmd As New SqlCommand(strQuery)

        cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente

        Dim dr As SqlDataReader

        Try
            CargaDatos()

            cmd.Connection = cnServidor
            AbreConexion()

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            If dr.Read() Then

                _Calle = CType(dr("Calle"), Integer)
                _ExisteCalle = CType(_Calle, Boolean)
                _CalleOriginal = _Calle
                If Not IsDBNull(dr("EntreCalle1")) Then
                    _EntreCalle1 = CType(dr("EntreCalle1"), Integer)
                    _ExisteEntreCalle1 = True
                    txtEntreCalle1.Text = CType(dr("EntreCalle1Nombre"), String).Trim
                Else
                    _EntreCalle1 = 0
                    _ExisteEntreCalle1 = False
                    txtEntreCalle1.Text = ""
                End If

                _EntreCalle1Original = _EntreCalle1

                If Not IsDBNull(dr("EntreCalle2")) Then
                    _EntreCalle2 = CType(dr("EntreCalle2"), Integer)
                    _ExisteEntreCalle2 = True
                    txtEntreCalle2.Text = CType(dr("EntreCalle2Nombre"), String).Trim
                Else
                    _EntreCalle2 = 0
                    _ExisteEntreCalle2 = False
                    txtEntreCalle2.Text = ""
                End If

                _EntreCalle2Original = _EntreCalle2


                If Not IsDBNull(dr("Colonia")) Then
                    _Colonia = CType(dr("Colonia"), Integer)
                    _ExisteColonia = True
                Else
                    _Colonia = 0
                    _ExisteColonia = False
                End If

                _ColoniaOriginal = _Colonia

                If Not IsDBNull(dr("CP")) Then
                    _CP = CType(dr("CP"), String)
                    txtCP.Text = CType(dr("CP"), String).Trim
                Else
                    _CP = ""
                    txtCP.Text = ""
                End If

                lblCP.Text = txtCP.Text

                'If Not IsDBNull(dr("Municipio")) Then
                '    _Municipio = CType(dr("Municipio"), Integer)
                'Else
                '    _Municipio = 0
                'End If

                If Not IsDBNull(dr("CalleNombre")) Then
                    txtCalle.Text = CType(dr("CalleNombre"), String).Trim
                Else
                    txtCalle.Text = ""
                End If

                If Not _AltaCalleColonia Then
                    'Dim XDoc As New XmlDocument()
                    'XDoc.Load(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\ListadoCalles.xml")

                    cboEntreCalle1.CargaDatos = False
                    cboEntreCalle2.CargaDatos = False
                    cboCalle.CargaDatos = False

                    cboCalle.Text = txtCalle.Text
                    cboEntreCalle1.Text = txtEntreCalle1.Text
                    cboEntreCalle2.Text = txtEntreCalle2.Text

                    'cboEntreCalle1.CargaCallesFromDoc(XDoc)
                    'cboEntreCalle2.CargaCallesFromDoc(XDoc)
                    'cboCalle.CargaCallesFromDoc(XDoc)

                    cboEntreCalle1.CargaDatos = True
                    cboEntreCalle2.CargaDatos = True
                    cboCalle.CargaDatos = True
                End If

                _CalleNombreOriginal = txtCalle.Text.Trim

                If Not IsDBNull(dr("NumExterior")) Then
                    txtNumExterior.Text = CType(dr("NumExterior"), Integer).ToString
                Else
                    txtNumExterior.Text = ""
                End If

                _NumExteriorOriginal = txtNumExterior.Text

                If Not IsDBNull(dr("NumInterior")) Then
                    txtNumInterior.Text = CType(dr("NumInterior"), String).Trim
                Else
                    txtNumInterior.Text = ""
                End If

                _NumInteriorOriginal = txtNumInterior.Text

                If Not IsDBNull(dr("ColoniaNombre")) Then
                    cboColonia.Text = CType(dr("ColoniaNombre"), String).Trim
                Else
                    cboColonia.Text = ""
                End If

                _ColoniaNombreOriginal = cboColonia.Text

                If Not IsDBNull(dr("Municipio")) Then
                    _Municipio = CType(dr("Municipio"), Integer)
                    cboMunicipio.SelectedValue = _Municipio
                Else
                    _Municipio = 0
                    cboMunicipio.SelectedIndex = -1
                End If

                'BloqueaControles(True)


                txtCalle.Visible = True
                cboColonia.Visible = True
                txtCP.Visible = True
                txtEntreCalle1.Visible = True
                txtEntreCalle2.Visible = True
                cboMunicipio.Visible = True
                txtNumExterior.Visible = True
                txtNumInterior.Visible = True

                Me.txtEntreCalle1.ReadOnly = False
                Me.txtEntreCalle2.ReadOnly = False

                _CargaCliente = True

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            CierraConexion()
            cmd.Dispose()

        End Try
        ValidaNombreCalle(_CalleNombreOriginal)
    End Sub

    Public Function AltaCalle(ByVal Nombre As String) As Integer
        Dim oCalle As New SigaMetClasses.cCalle()
        Dim _NuevaCalle As Integer

        Try

            _NuevaCalle = oCalle.Alta(Nombre)

            Return _NuevaCalle

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oCalle.Dispose()

        End Try

    End Function

    Public Function AltaColonia(ByVal Nombre As String,
                                ByVal CP As String,
                                ByVal Municipio As Integer) As Integer
        Dim oColonia As New SigaMetClasses.cColonia()
        Dim _NuevaColonia As Integer

        Try
            _NuevaColonia = oColonia.Alta(Nombre, CP, Municipio)
            Return _NuevaColonia

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oColonia.Dispose()

        End Try
    End Function

    Public Sub LimpiaTodo()
        _Limpiado = True
        BloqueaControles(False)

        txtCalle.Text = ""
        txtNumExterior.Text = ""
        txtNumInterior.Text = ""
        txtEntreCalle1.Text = ""
        txtEntreCalle2.Text = ""
        txtCP.Text = ""



        txtCalle.Visible = _AltaCalleColonia
        cboCalle.Visible = Not _AltaCalleColonia
        cboEntreCalle1.Visible = Not _AltaCalleColonia
        cboEntreCalle2.Visible = Not _AltaCalleColonia
        cboCalle.Text = String.Empty
        cboEntreCalle1.Text = String.Empty
        cboEntreCalle2.Text = String.Empty

        lblCalle.Text = ""
        lblNumExterior.Text = ""
        lblNumInterior.Text = ""
        lblEntreCalle1.Text = ""
        lblEntreCalle2.Text = ""
        lblColonia.Text = ""
        lblMunicipio.Text = ""
        lblCP.Text = ""

        With cboColonia
            .DataSource = Nothing
            .Items.Clear()
            .ValueMember = ""
            .DisplayMember = ""
            .Text = ""
        End With


        _Calle = 0
        _Colonia = 0
        _EntreCalle1 = 0
        _EntreCalle2 = 0
        _CP = ""
        _CargaClienteSoloLectura = False

        _ExisteCalle = False
        _ExisteColonia = False
        _ExisteEntreCalle1 = False
        _ExisteEntreCalle2 = False
        _ExisteCP = False

        cboMunicipio.SelectedIndex = -1
        _Limpiado = False
    End Sub

    Private Sub txtCalle_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCalle.Validated
        If (txtCalle.Text.Trim <> _CalleNombreOriginal) Or
                    (txtCalle.Text.Trim = _CalleNombreOriginal) Or
                    _EdicionDatos = True Then '10AGO2004
            _EdicionDatos = True
            If txtCalle.Text.Trim <> "" Then
                ValidaNombreCalle(txtCalle.Text.Trim.ToUpper)
                txtEntreCalle1.ReadOnly = False
                txtEntreCalle2.ReadOnly = False

                '10 de agosto del 2004
                'Aunque no se cambie el nombre de la calle, carga de todos 
                'modos el combo de colonias, pero automáticamente se
                'selecciona la colonia original en el combo para evitar
                'que se cambie cuando le den con el tabulador

                If _ColoniaOriginal <> 0 Then
                    Me.cboColonia.SelectedValue = _ColoniaOriginal
                End If

            Else
                _EntreCalle1 = 0
                _EntreCalle2 = 0
                _ExisteEntreCalle1 = False
                _ExisteEntreCalle2 = False

                txtEntreCalle1.Text = ""
                txtEntreCalle2.Text = ""

                txtEntreCalle1.ReadOnly = True
                txtEntreCalle2.ReadOnly = True
            End If
        End If

    End Sub

#Region "Conexion"

    Private Sub AbreConexion()
        If Not IsNothing(cnServidor) Then
            If cnServidor.State = ConnectionState.Closed Then
                cnServidor.Open()
            End If
        End If
    End Sub

    Private Sub CierraConexion()
        If Not IsNothing(cnServidor) Then
            If cnServidor.State = ConnectionState.Open Then
                cnServidor.Close()
            End If
        End If
    End Sub

#End Region

    Private Function ValidaNombreCalle(ByVal CalleNombre As String) As Integer
        'Dim cmd As New SqlCommand("SELECT * FROM vwCalleColonia WHERE CalleNombre = @CalleNombre ORDER BY ColoniaNombre", cnServidor)
        Dim cmd As New SqlCommand("EXECUTE spCCConsultaVwCalleColonia @CalleNombre", cnServidor)
        Dim da As New SqlDataAdapter(cmd)
        dtCalle = New DataTable("CalleColonia")

        Try
            cmd.Parameters.Add("@CalleNombre", SqlDbType.VarChar).Value = CalleNombre
            da.Fill(dtCalle)


            If dtCalle.Rows.Count > 0 Then
                _ExisteCalle = True
                _ExisteColonia = True

                txtCalle.ForeColor = Color.Black

                '_CargaDeColoniasParaCalleExistente = True

                cboColonia.DataSource = dtCalle
                cboColonia.ValueMember = "Colonia"
                cboColonia.DisplayMember = "ColoniaNombre"
                cboColonia.SelectedValue = _Colonia
                Me.DataBindings.Clear()
                Me.cboMunicipio.DataBindings.Clear()
                Me.txtCP.DataBindings.Clear()

                Me.DataBindings.Add("Calle", dtCalle, "Calle")

                'Esto lo agrege por que quien sabe por que diablos no seleccionaba un valor automáticamente el combo de colonia
                If dtCalle.Rows.Count > 0 AndAlso cboColonia.SelectedValue Is Nothing Then
                    cboColonia.SelectedIndex = 0
                End If

                'Esta línea estaba antes
                '27 de marzo del 2004
                'Me.DataBindings.Add("Colonia", dtCalle, "Colonia")
                'y fue cambiada por la siguiente
                Me.DataBindings.Add("Colonia", cboColonia.SelectedValue, "")

                Me.cboMunicipio.DataBindings.Add("SelectedValue", dtCalle, "Municipio")
                Me.txtCP.DataBindings.Add("Text", dtCalle, "CP")


            Else
                _ExisteCalle = False
                _ExisteColonia = False

                _Calle = 0
                _Colonia = 0
                txtCalle.ForeColor = Color.Red

                '_CargaDeColoniasParaCalleExistente = False

                cboColonia.DataSource = Nothing
                cboColonia.Items.Clear()
                cboColonia.ValueMember = ""
                cboColonia.DisplayMember = ""
                cboColonia.Text = "" '01JUL2004
                If Not _EdicionColonia Then
                    cboColonia.Text = ""
                End If
            End If

            '27 de marzo 
            'cboColonia.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            cmd.Dispose()
        End Try

    End Function

    Private Sub ValidaNombreEntreCalle(ByVal CalleNombre As String,
                                       ByVal Origen As Object)

        Dim cmd As New SqlCommand("SELECT TOP 1 Calle FROM Calle WHERE Rtrim(Ltrim(Nombre)) = @CalleNombre ORDER by Calle", cnServidor)
        Dim da As New SqlDataAdapter(cmd)

        Try
            AbreConexion()
            cmd.Parameters.Add("@CalleNombre", SqlDbType.VarChar).Value = CalleNombre
            Dim _EntreCalle As TextBox
            Dim _IDCalle As Integer
            _IDCalle = CType(cmd.ExecuteScalar, Integer)

            _EntreCalle = CType(Origen, TextBox)

            If _IDCalle > 0 Then
                If _EntreCalle.Name = "txtEntreCalle1" Then
                    _ExisteEntreCalle1 = True
                    _EntreCalle1 = _IDCalle
                End If
                If _EntreCalle.Name = "txtEntreCalle2" Then
                    _ExisteEntreCalle2 = True
                    _EntreCalle2 = _IDCalle
                End If

                CType(Origen, TextBox).ForeColor = Color.Black

            Else
                If _EntreCalle.Name = "txtEntreCalle1" Then
                    _ExisteEntreCalle1 = False
                    _EntreCalle1 = 0
                End If

                If _EntreCalle.Name = "txtEntreCalle2" Then
                    _ExisteEntreCalle2 = False
                    _EntreCalle2 = 0
                End If

                CType(Origen, TextBox).ForeColor = Color.Red
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CierraConexion()
            da.Dispose()
            cmd.Dispose()
        End Try

    End Sub

    Private Function ValidaCP(ByVal CP As String) As Boolean
        Dim cmd As New SqlCommand("SELECT Count(*) FROM CP WHERE CP = @CP", cnServidor)
        Dim da As New SqlDataAdapter(cmd)

        Try
            AbreConexion()
            cmd.Parameters.Add("@CP", SqlDbType.Char).Value = CP

            Dim _Total As Integer
            _Total = CType(cmd.ExecuteScalar, Integer)

            Return CType(_Total, Boolean)

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CierraConexion()
            da.Dispose()
            cmd.Dispose()
        End Try

    End Function

    Private Sub ValidaNombreColonia(ByVal ColoniaNombre As String)
        Dim cmd As New SqlCommand("SELECT DISTINCT Colonia, ColoniaNombre, CP, Municipio FROM vwCalleColonia WHERE ColoniaNombre = @ColoniaNombre ORDER BY CP", cnServidor)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable("ColoniaCP")

        Try
            cmd.Parameters.Add("@ColoniaNombre", SqlDbType.VarChar).Value = ColoniaNombre
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                _ExisteColonia = True
                cboColonia.ForeColor = Color.Black

                cboColonia.DataSource = dt
                cboColonia.ValueMember = "Colonia"
                cboColonia.DisplayMember = "ColoniaNombre"

                'DataGrid1.DataSource = dt

                'Me.DataBindings.Clear()
                Me.cboMunicipio.DataBindings.Clear()
                Me.txtCP.DataBindings.Clear()

                'Me.DataBindings.Add("Calle", dt, "Calle")
                Me.cboMunicipio.DataBindings.Add("SelectedValue", dt, "Municipio")
                Me.txtCP.DataBindings.Add("Text", dt, "CP")

                txtCP.ReadOnly = True
                cboMunicipio.Enabled = False

                _OtraColoniaSeleccionada = True

            Else
                _ExisteColonia = False
                _Colonia = 0
                cboColonia.ForeColor = Color.Red

                cboColonia.DataSource = Nothing
                cboColonia.Items.Clear()
                cboColonia.ValueMember = ""
                cboColonia.DisplayMember = ""
                If Not _EdicionColonia Then
                    cboColonia.Text = ""
                End If

                txtCP.ReadOnly = False
                cboMunicipio.Enabled = True

                _OtraColoniaSeleccionada = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            cmd.Dispose()
        End Try


    End Sub

    Public Sub CargaDatos()
        If Not _DatosCargados Then
            cnServidor = DataLayer.Conexion
            If Not _SoloLectura Then
                CargaDatosComboMunicipio()
            End If
            _DatosCargados = True
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        lstResults.Items.Clear()

        lstResults.Items.Add("Calle: " & Me.Calle.ToString)
        lstResults.Items.Add("Colonia: " & CType(cboColonia.SelectedValue, Integer).ToString)
        lstResults.Items.Add("NumExterior: " & Me.NumExterior.ToString)
        lstResults.Items.Add("NumInterior: " & Me.NumInterior)
        lstResults.Items.Add("EntreCalle1: " & Me._EntreCalle1.ToString)
        lstResults.Items.Add("EntreCalle2: " & Me._EntreCalle2.ToString)
        lstResults.Items.Add("CP: " & Me.txtCP.Text)
        lstResults.Items.Add("Municipio: " & CType(cboMunicipio.SelectedValue, String))

        lstResults.Items.Add("ExisteCalle: " & _ExisteCalle.ToString)
        lstResults.Items.Add("ExisteColonia: " & _ExisteColonia.ToString)
        lstResults.Items.Add("ExisteEntreCalle1: " & _ExisteEntreCalle1.ToString)
        lstResults.Items.Add("ExisteEntreCalle2: " & _ExisteEntreCalle2.ToString)
        lstResults.Items.Add("ExisteCP: " & _ExisteCP.ToString)

    End Sub

    Private Sub txtNumExterior_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumExterior.TextChanged
        If txtNumExterior.Text.Trim = "" Then
            _NumExterior = 0
        Else
            _NumExterior = CType(txtNumExterior.Text.Trim, Integer)
        End If
    End Sub

    Private Sub txtNumInterior_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumInterior.TextChanged
        _NumInterior = txtNumInterior.Text.Trim
    End Sub

    Private Sub CargaDatosComboMunicipio()
        Dim strQuery As String =
        "SELECT Municipio, NombreCompuesto FROM vwMunicipio"
        Dim da As New SqlDataAdapter(strQuery, cnServidor)
        Dim dt As New DataTable("Municipio")

        Try
            AbreConexion()
            da.Fill(dt)
            cboMunicipio.DataSource = Nothing
            If dt.Rows.Count > 0 Then
                With cboMunicipio
                    .ValueMember = "Municipio"
                    .DataSource = dt
                    .DisplayMember = "NombreCompuesto"
                End With

            Else
                'cboMunicipio.DataSource = Nothing
                With cboMunicipio
                    .ValueMember = ""
                    .DisplayMember = ""
                    .Items.Clear()
                    .Text = ""
                    .Enabled = False
                End With

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CierraConexion()
            da.Dispose()
        End Try

    End Sub

    Public Function GuardaDatos() As String
        Dim strMensaje As String = ""
        'Se permite nuevamente el alta de calles y colonias
        'If _ExisteCalle = False AndAlso Not _AltaCalleColonia Then
        If _ExisteCalle = False AndAlso _AltaCalleColonia Then
            _Calle = AltaCalle(txtCalle.Text.Trim)
            strMensaje &= "La calle fue dada de alta." & Chr(13)
        End If

        'If _ExisteEntreCalle1 = False And txtEntreCalle1.Text.Trim <> "" AndAlso Not _AltaCalleColonia Then
        If _ExisteEntreCalle1 = False And txtEntreCalle1.Text.Trim <> "" AndAlso _AltaCalleColonia Then
            _EntreCalle1 = AltaCalle(txtEntreCalle1.Text.Trim)
            strMensaje &= "La entrecalle 1 fue dada de alta." & Chr(13)
        End If

        'If _ExisteEntreCalle2 = False And txtEntreCalle2.Text.Trim <> "" AndAlso Not _AltaCalleColonia Then
        If _ExisteEntreCalle2 = False And txtEntreCalle2.Text.Trim <> "" AndAlso _AltaCalleColonia Then
            _EntreCalle2 = AltaCalle(txtEntreCalle2.Text.Trim)
            strMensaje &= "La entrecalle 2 fue dada de alta." & Chr(13)
        End If

        'If _ExisteColonia = False AndAlso _AltaCalleColonia Then
        If _ExisteColonia = False AndAlso _AltaCalleColonia Then
            _Colonia = AltaColonia(cboColonia.Text.ToUpper.Trim, txtCP.Text.Trim, CType(cboMunicipio.SelectedValue, Integer))
            strMensaje &= "La colonia fue dada de alta." & Chr(13)
        End If

        Dim oCalleColonia As New SigaMetClasses.cCalleColonia()
        Try
            If Not oCalleColonia.ExisteCalleColonia(_Calle, Colonia) Then
                oCalleColonia.Alta(_Calle, Colonia)
                strMensaje &= "La relación calle-colonia fue dada de alta."
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oCalleColonia.Dispose()
        End Try

        If strMensaje.Trim <> "" Then
            Return strMensaje
        Else
            Return ""
        End If

    End Function

    'Private Sub cboMunicipio_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMunicipio.SelectedValueChanged
    '    '_Municipio = CType(cboMunicipio.SelectedValue, Integer)
    '    'lblMunicipio.Text = cboMunicipio.Text
    'End Sub

    Private Sub SeleccionCalleColonia_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Validated
        If _CalleNombreOriginal <> txtCalle.Text Or
                    _ColoniaNombreOriginal <> cboColonia.Text Or
                    _NumExteriorOriginal <> txtNumExterior.Text Or
                     _NumInteriorOriginal <> txtNumInterior.Text Or
                    _CalleOriginal <> _Calle Or
                    _ColoniaOriginal <> _Colonia Or
                    _EntreCalle1Original <> _EntreCalle1 Or
                    _EntreCalle2Original <> _EntreCalle2 Or
                            (txtEntreCalle1.Text.Trim <> "" _
                                And _EntreCalle1 = 0 _
                                And _ExisteEntreCalle1 = False) Or
                            (txtEntreCalle2.Text.Trim <> "" _
                                And _EntreCalle2 = 0 _
                                And _ExisteEntreCalle2 = False) Then
            _EdicionDatos = True
        End If

    End Sub

    Private Sub txtEntreCalle1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEntreCalle1.Validated
        If txtEntreCalle1.Text.Trim <> "" Then
            ValidaNombreEntreCalle(txtEntreCalle1.Text.Trim.ToUpper, sender)
        Else
            _ExisteEntreCalle1 = False
            _EntreCalle1 = 0
        End If
    End Sub

    Private Sub txtEntreCalle2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEntreCalle2.Validated
        If txtEntreCalle2.Text.Trim <> "" Then
            ValidaNombreEntreCalle(txtEntreCalle2.Text.Trim.ToUpper, sender)
        Else
            _ExisteEntreCalle2 = False
            _EntreCalle2 = 0
        End If
    End Sub

    Private Sub txtCP_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCP.Validated
        If Not txtCP.ReadOnly Then
            If txtCP.Text.Trim <> "" Then
                If txtCP.Text.Length = 5 Then
                    If ValidaCP(txtCP.Text.Trim) Then
                        txtCP.ForeColor = Color.Black
                        _ExisteCP = True
                    Else
                        txtCP.ForeColor = Color.Red
                        _ExisteCP = False
                        MessageBox.Show("El código postal es inválido.  Por favor verifique.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        txtCP.Focus()
                    End If
                Else
                    txtCP.ForeColor = Color.Red
                    _ExisteCP = False
                    MessageBox.Show("El código postal es inválido.  Por favor verifique.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtCP.Focus()

                End If
            Else
                _ExisteCP = False
                MessageBox.Show("El código postal es inválido.  Por favor verifique.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCP.Focus()
            End If
        End If

    End Sub


    Private Sub cboMunicipio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMunicipio.SelectedIndexChanged
        _Municipio = CType(cboMunicipio.SelectedValue, Integer)
        lblMunicipio.Text = cboMunicipio.Text
    End Sub

    Private Sub cboColonia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboColonia.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            _EdicionColonia = True
            _OtraColoniaSeleccionada = False
        End If
    End Sub

    Private Sub cboColonia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboColonia.SelectedIndexChanged
        'If Not IsNothing(cboColonia.DataSource) Then
        '    _EdicionColonia = True
        '    _OtraColoniaSeleccionada = True
        'End If


        'Me.BindingContext(dt).
    End Sub

    Private Sub cboColonia_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboColonia.Leave
        If _EdicionColonia Then
            If Not _OtraColoniaSeleccionada Then
                ValidaNombreColonia(cboColonia.Text.Trim)
            Else
                '27 de marzo
                _Colonia = CType(cboColonia.SelectedValue, Integer)
                _ExisteColonia = True
            End If
        End If
    End Sub

#Region "Clientes portatil"
    Public Sub CargaDatosClientePortatilSoloLectura(ByVal Cliente As Integer)
        _SoloLectura = True
        Dim cmd As New SqlCommand("spCCConsultaDireccionClientePortatil")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 15
            .Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        End With

        If (_URLGateway Is String.Empty Or _URLGateway Is Nothing) Then
            Dim dr As SqlDataReader

            Try

                CargaDatos()

                cmd.Connection = cnServidor
                AbreConexion()

                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

                If dr.Read() Then

                    Me.lblCalle.Text = CType(dr("CalleNombre"), String).Trim
                    Me.lblColonia.Text = CType(dr("ColoniaNombre"), String).Trim
                    Me.lblCP.Text = CType(dr("CP"), String).Trim
                    Me.lblEntreCalle1.Text = CType(dr("EntreCalle1Nombre"), String).Trim
                    Me.lblEntreCalle2.Text = CType(dr("EntreCalle2Nombre"), String).Trim
                    Me.lblMunicipio.Text = CType(dr("MunicipioNombre"), String).Trim
                    Me.lblNumExterior.Text = CType(dr("NumeroExterior"), String)
                    Me.lblNumInterior.Text = CType(dr("NumeroInterior"), String).Trim

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                CierraConexion()
                cmd.Dispose()

            End Try

        Else

            Dim oDireccionEntrega As New RTGMCore.DireccionEntrega
            oDireccionEntrega = ConsultarDatosClienteCRM(Cliente)

            Me.lblCalle.Text = oDireccionEntrega.CalleNombre
            Me.lblColonia.Text = oDireccionEntrega.ColoniaNombre
            Me.lblCP.Text = oDireccionEntrega.CP
            Me.lblEntreCalle1.Text = oDireccionEntrega.EntreCalle1Nombre
            Me.lblEntreCalle2.Text = oDireccionEntrega.EntreCalle2Nombre
            Me.lblMunicipio.Text = oDireccionEntrega.MunicipioNombre
            Me.lblNumExterior.Text = oDireccionEntrega.NumExterior
            Me.lblNumInterior.Text = oDireccionEntrega.NumInterior


        End If

        Me._CP = Me.lblCP.Text
        txtCalle.Visible = False
        cboColonia.Visible = False
        txtCP.Visible = False
        txtEntreCalle1.Visible = False
        txtEntreCalle2.Visible = False
        cboMunicipio.Visible = False
        txtNumExterior.Visible = False
        txtNumInterior.Visible = False


        _CargaCliente = True


    End Sub
    Public Sub CargaDatosClientePortatil(ByVal Cliente As Integer)
        Dim strQuery As String =
        "SELECT Cliente, Calle, CalleNombre, NumeroExterior as NumExterior, NumeroInterior as NumInterior, " &
            "EntreCalle1, Isnull(EntreCalle1Nombre,'') as EntreCalle1Nombre, " &
            "EntreCalle2, Isnull(EntreCalle2Nombre,'') as EntreCalle2Nombre, " &
            "Colonia, ColoniaNombre, CP, Municipio " &
            "FROM vwDatosClientePortatil WHERE Cliente = @Cliente"
        Dim cmd As New SqlCommand(strQuery)

        cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente

        Dim dr As SqlDataReader

        Try
            CargaDatos()

            cmd.Connection = cnServidor
            AbreConexion()

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            If dr.Read() Then

                _Calle = CType(dr("Calle"), Integer)
                _ExisteCalle = CType(_Calle, Boolean)
                _CalleOriginal = _Calle
                If Not IsDBNull(dr("EntreCalle1")) Then
                    _EntreCalle1 = CType(dr("EntreCalle1"), Integer)
                    _ExisteEntreCalle1 = True
                    txtEntreCalle1.Text = CType(dr("EntreCalle1Nombre"), String).Trim

                Else
                    _EntreCalle1 = 0
                    _ExisteEntreCalle1 = False
                    txtEntreCalle1.Text = ""
                End If

                _EntreCalle1Original = _EntreCalle1

                If Not IsDBNull(dr("EntreCalle2")) Then
                    _EntreCalle2 = CType(dr("EntreCalle2"), Integer)
                    _ExisteEntreCalle2 = True
                    txtEntreCalle2.Text = CType(dr("EntreCalle2Nombre"), String).Trim
                Else
                    _EntreCalle2 = 0
                    _ExisteEntreCalle2 = False
                    txtEntreCalle2.Text = ""
                End If

                _EntreCalle2Original = _EntreCalle2


                If Not IsDBNull(dr("Colonia")) Then
                    _Colonia = CType(dr("Colonia"), Integer)
                    _ExisteColonia = True
                Else
                    _Colonia = 0
                    _ExisteColonia = False
                End If

                _ColoniaOriginal = _Colonia

                If Not IsDBNull(dr("CP")) Then
                    _CP = CType(dr("CP"), String)
                    txtCP.Text = CType(dr("CP"), String).Trim
                Else
                    _CP = ""
                    txtCP.Text = ""
                End If

                lblCP.Text = txtCP.Text

                'If Not IsDBNull(dr("Municipio")) Then
                '    _Municipio = CType(dr("Municipio"), Integer)
                'Else
                '    _Municipio = 0
                'End If

                If Not IsDBNull(dr("CalleNombre")) Then
                    txtCalle.Text = CType(dr("CalleNombre"), String).Trim
                Else
                    txtCalle.Text = ""
                End If

                _CalleNombreOriginal = txtCalle.Text.Trim

                If Not IsDBNull(dr("NumExterior")) Then
                    txtNumExterior.Text = CType(dr("NumExterior"), Integer).ToString
                Else
                    txtNumExterior.Text = ""
                End If

                _NumExteriorOriginal = txtNumExterior.Text

                If Not IsDBNull(dr("NumInterior")) Then
                    txtNumInterior.Text = CType(dr("NumInterior"), String).Trim
                Else
                    txtNumInterior.Text = ""
                End If

                _NumInteriorOriginal = txtNumInterior.Text

                If Not IsDBNull(dr("ColoniaNombre")) Then
                    cboColonia.Text = CType(dr("ColoniaNombre"), String).Trim
                Else
                    cboColonia.Text = ""
                End If

                _ColoniaNombreOriginal = cboColonia.Text

                If Not IsDBNull(dr("Municipio")) Then
                    _Municipio = CType(dr("Municipio"), Integer)
                    cboMunicipio.SelectedValue = _Municipio
                Else
                    _Municipio = 0
                    cboMunicipio.SelectedIndex = -1
                End If

                'BloqueaControles(True)


                txtCalle.Visible = True
                cboColonia.Visible = True
                txtCP.Visible = True
                txtEntreCalle1.Visible = True
                txtEntreCalle2.Visible = True
                cboMunicipio.Visible = True
                txtNumExterior.Visible = True
                txtNumInterior.Visible = True

                Me.txtEntreCalle1.ReadOnly = False
                Me.txtEntreCalle2.ReadOnly = False

                _CargaCliente = True

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            CierraConexion()
            cmd.Dispose()

        End Try
    End Sub

#End Region

#Region "Seleccion de calles y colonias"
    Private Sub CargaCalles(Optional ByVal Forzar As Boolean = False)
        If Forzar OrElse ValidaXML() Then
            If cnServidor Is Nothing Then
                cnServidor = DataLayer.Conexion
            End If
            Dim da As New SqlDataAdapter("Select distinct Nombre from Calle order by Nombre", cnServidor)
            Dim dtListaCalles As New DataTable()
            Try
                da.Fill(dtListaCalles)
                GuardaXML(dtListaCalles)
            Catch ex As Exception
                Throw ex
            Finally
                dtListaCalles.Dispose()
                System.GC.Collect()
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub GuardaXML(ByVal Datos As DataTable)
        Dim DocCC As XmlDocument
        Dim Att As XmlAttribute
        Dim Node As XmlNode = Nothing
        'Creacion del encabezado del documento
        Dim Dec As XmlDeclaration
        'Creacion del nodo padre
        Dim Root As XmlElement
        Dim rw As DataRow
        Dim NCalle As XmlNode

        DocCC = New XmlDataDocument()
        Dec = DocCC.CreateXmlDeclaration("1.0", Nothing, Nothing)

        Root = DocCC.CreateElement("Calles")
        DocCC.AppendChild(Root)

        For Each rw In Datos.Rows
            'Creacion del nodo de calle
            NCalle = DocCC.CreateElement("Calle")
            'Agregando el ID de la calle
            'Agregando el Nombre de la calle
            Att = DocCC.CreateAttribute("Nombre")
            Att.Value = CStr(rw("Nombre"))
            NCalle.Attributes.Append(Att)
            'Agregando la calle
            Root.AppendChild(NCalle)
        Next

        DocCC.Save(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\ListadoCalles.xml")
        DocCC = Nothing
        System.GC.Collect()
    End Sub
    Private Function ValidaXML() As Boolean
        Dim fileName As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\ListadoCalles.xml"
        Return Not File.Exists(fileName) OrElse File.GetLastWriteTime(fileName).Date < Now.Date
    End Function

    Private Sub cboCalle_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCalle.TextChanged
        If cboCalle.Text = "" AndAlso Not _CargaClienteSoloLectura Then
            CargaCalles(Forzar:=Not _Limpiado)
        End If
    End Sub
    Private Sub cboCalle_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCalle.Enter
        Dim Calle As String = cboCalle.Text
        cboCalle.SelectedIndex = cboCalle.FindString(Calle)
    End Sub
    Private Sub cboCalle_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCalle.Leave
        If Not _CargaClienteSoloLectura Then
            txtCalle.Text = cboCalle.Text
            ValidaNombreCalle(cboCalle.Text)
        End If
    End Sub

    Private Sub cboEntreCalle1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEntreCalle1.Enter
        Dim Calle As String = cboEntreCalle1.Text
        cboEntreCalle1.SelectedIndex = cboEntreCalle1.FindString(Calle)
    End Sub
    Private Sub cboEntreCalle1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEntreCalle1.Leave
        If Not _CargaClienteSoloLectura Then
            txtEntreCalle1.Text = cboEntreCalle1.Text
            ValidaNombreEntreCalle(cboEntreCalle1.Text, txtEntreCalle1)
        End If
    End Sub

    Private Sub cboEntreCalle2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEntreCalle2.Enter
        Dim Calle As String = cboEntreCalle2.Text
        cboEntreCalle2.SelectedIndex = cboEntreCalle2.FindString(Calle)
    End Sub
    Private Sub cboEntreCalle2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEntreCalle2.Leave
        If Not _CargaClienteSoloLectura Then
            txtEntreCalle2.Text = cboEntreCalle2.Text
            ValidaNombreEntreCalle(cboEntreCalle2.Text, txtEntreCalle2)
        End If
    End Sub
#End Region

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Me.Cursor = Cursors.WaitCursor
        CargaCalles(True)
    End Sub
End Class
' Registra y modifica los folios asignados o devueltos, podemos asigar diferentes tipo de folios, 
' podemos Registrar o Modificar folios, los folios devueltos deben de estar asignados, no se 
' permite registrar folios no asignados como devueltos
Public Class frmAsignarFolios
    Inherits System.Windows.Forms.Form

    Private Titulo As String
    Private RealizarBusqueda As Boolean

    Private Operacion As Operaciones
    Private ControlFolio As Integer
    Private FechaMaxima As Date
    Public DatosSalvados As Boolean

    ' Operaciones que se pueden realizar en esta forma
    Public Enum Operaciones
        Registrar
        Modificar
    End Enum

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal _Operacion As Operaciones, ByVal _ControlFolio As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Operacion = _Operacion
        ControlFolio = _ControlFolio
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipoFolio As PortatilClasses.Combo.ComboTipoFolio
    Friend WithEvents txtEmpleado As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboEmpleado As PortatilClasses.Combo.ComboOperadorPtl
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtFolioFinal As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents dtpFAsignacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFolioInicial As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboTipoFolioMov As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboProducto As PortatilClasses.Combo.ComboProductoPtl
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAsignarFolios))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboProducto = New PortatilClasses.Combo.ComboProductoPtl()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboTipoFolioMov = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCantidad = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFolioFinal = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboTipoFolio = New PortatilClasses.Combo.ComboTipoFolio()
        Me.dtpFAsignacion = New System.Windows.Forms.DateTimePicker()
        Me.txtEmpleado = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboEmpleado = New PortatilClasses.Combo.ComboOperadorPtl()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFolioInicial = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCelula, Me.cboCelula, Me.cboProducto, Me.Label9, Me.cboTipoFolioMov, Me.Label8, Me.txtCantidad, Me.Label7, Me.txtFolioFinal, Me.Label5, Me.cboTipoFolio, Me.dtpFAsignacion, Me.txtEmpleado, Me.Label6, Me.Label4, Me.Label3, Me.cboEmpleado, Me.txtSerie, Me.Label2, Me.txtFolioInicial, Me.Label1})
        Me.GroupBox1.Location = New System.Drawing.Point(16, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(376, 376)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'cboProducto
        '
        Me.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto.Location = New System.Drawing.Point(126, 88)
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(228, 21)
        Me.cboProducto.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(20, 92)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 14)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Producto:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTipoFolioMov
        '
        Me.cboTipoFolioMov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoFolioMov.Location = New System.Drawing.Point(126, 32)
        Me.cboTipoFolioMov.Name = "cboTipoFolioMov"
        Me.cboTipoFolioMov.Size = New System.Drawing.Size(228, 21)
        Me.cboTipoFolioMov.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(20, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Tipo movimiento:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCantidad
        '
        Me.txtCantidad.AutoSize = False
        Me.txtCantidad.Location = New System.Drawing.Point(126, 141)
        Me.txtCantidad.MaxLength = 10
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(100, 21)
        Me.txtCantidad.TabIndex = 4
        Me.txtCantidad.Text = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(20, 145)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Cantidad:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFolioFinal
        '
        Me.txtFolioFinal.AutoSize = False
        Me.txtFolioFinal.Location = New System.Drawing.Point(126, 197)
        Me.txtFolioFinal.MaxLength = 15
        Me.txtFolioFinal.Name = "txtFolioFinal"
        Me.txtFolioFinal.Size = New System.Drawing.Size(100, 21)
        Me.txtFolioFinal.TabIndex = 6
        Me.txtFolioFinal.Text = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(20, 201)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Folio final:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTipoFolio
        '
        Me.cboTipoFolio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoFolio.Location = New System.Drawing.Point(126, 60)
        Me.cboTipoFolio.Name = "cboTipoFolio"
        Me.cboTipoFolio.Size = New System.Drawing.Size(228, 21)
        Me.cboTipoFolio.TabIndex = 1
        '
        'dtpFAsignacion
        '
        Me.dtpFAsignacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFAsignacion.Location = New System.Drawing.Point(123, 326)
        Me.dtpFAsignacion.Name = "dtpFAsignacion"
        Me.dtpFAsignacion.Size = New System.Drawing.Size(228, 21)
        Me.dtpFAsignacion.TabIndex = 10
        '
        'txtEmpleado
        '
        Me.txtEmpleado.AutoSize = False
        Me.txtEmpleado.Location = New System.Drawing.Point(124, 294)
        Me.txtEmpleado.MaxLength = 10
        Me.txtEmpleado.Name = "txtEmpleado"
        Me.txtEmpleado.Size = New System.Drawing.Size(100, 21)
        Me.txtEmpleado.TabIndex = 9
        Me.txtEmpleado.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(19, 326)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Fecha asignación:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(20, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Tipo folio:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(19, 268)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Empleado:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboEmpleado
        '
        Me.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpleado.Location = New System.Drawing.Point(123, 262)
        Me.cboEmpleado.Name = "cboEmpleado"
        Me.cboEmpleado.Size = New System.Drawing.Size(228, 21)
        Me.cboEmpleado.TabIndex = 8
        '
        'txtSerie
        '
        Me.txtSerie.AutoSize = False
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.Location = New System.Drawing.Point(126, 113)
        Me.txtSerie.MaxLength = 1
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(100, 21)
        Me.txtSerie.TabIndex = 3
        Me.txtSerie.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(20, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Serie:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFolioInicial
        '
        Me.txtFolioInicial.AutoSize = False
        Me.txtFolioInicial.Location = New System.Drawing.Point(126, 169)
        Me.txtFolioInicial.MaxLength = 15
        Me.txtFolioInicial.Name = "txtFolioInicial"
        Me.txtFolioInicial.Size = New System.Drawing.Size(100, 21)
        Me.txtFolioInicial.TabIndex = 5
        Me.txtFolioInicial.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(20, 173)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Folio inicial:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(415, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(415, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(125, 229)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboCelula.Size = New System.Drawing.Size(224, 21)
        Me.cboCelula.TabIndex = 7
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCelula.Location = New System.Drawing.Point(19, 234)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(42, 13)
        Me.lblCelula.TabIndex = 26
        Me.lblCelula.Text = "Celula:"
        Me.lblCelula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmAsignarFolios
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(496, 400)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmAsignarFolios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignación de folios"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Limpia los controles de la forma
    Private Sub Limpiar()
        txtSerie.Clear()
        txtCantidad.Clear()
        txtFolioInicial.Clear()
        txtFolioFinal.Clear()
        txtEmpleado.Clear()
        If cboCelula.Items.Count > 1 Then
            cboCelula.SelectedIndex = -1
            cboCelula.SelectedIndex = -1
        End If
        If cboEmpleado.Items.Count > 1 Then
            cboEmpleado.PosicionarInicio()
        End If
        If cboTipoFolio.Items.Count > 1 Then
            cboTipoFolio.PosicionarInicio()
        End If
        If cboTipoFolioMov.Items.Count > 1 Then
            cboTipoFolioMov.PosicionarInicio()
        End If
        If cboProducto.Items.Count > 1 Then
            cboProducto.PosicionarInicio()
        End If
        Me.Text = Me.Text & " [" & Operacion.ToString & "]"
        Titulo = "Folios asignados"
    End Sub

    ' Habilita o deshabilita los controles de la forma
    Private Sub HabilitarControles(ByVal Habilitar As Boolean)
        cboTipoFolioMov.Enabled = Habilitar
        cboTipoFolio.Enabled = Habilitar
        txtSerie.Enabled = Habilitar
        txtCantidad.Enabled = Habilitar
        txtFolioInicial.Enabled = Habilitar
        txtFolioFinal.Enabled = Habilitar
        txtEmpleado.Enabled = Habilitar
        cboEmpleado.Enabled = Habilitar
        dtpFAsignacion.Enabled = Habilitar
        cboProducto.Enabled = Habilitar
    End Sub

    ' Habilita el boton aceptar si los controles necesarios son llenados
    Private Sub HabilitarAceptar()
        If txtCantidad.Text <> "" And txtSerie.Text <> "" And txtEmpleado.Text <> "" And txtFolioInicial.Text <> "" _
        And txtFolioFinal.Text <> "" And cboEmpleado.Text <> "" And cboTipoFolio.Text <> "" _
        And cboTipoFolioMov.Text <> "" Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    ' Carga los datos a los controles dependiendo del Folio asignado seleccionado
    Private Sub CargarDatos()
        Cursor = Cursors.WaitCursor
        Dim oControlFolio As New PortatilClasses.Consulta.cControlFolio()
        oControlFolio.Consultar(3, ControlFolio, 0, 0, "0", 0, 0, 0, Now, 0, 0, GLOBAL_Usuario)
        Dim Fila As DataRow
        For Each Fila In oControlFolio.dtTable.Rows
            cboTipoFolio.PosicionaCombo(CType(Fila(1), Integer))
            txtCantidad.Text = CType(Fila(2), String)
            txtSerie.Text = CType(Fila(3), String)
            txtFolioInicial.Text = CType(Fila(4), String)
            txtFolioFinal.Text = CType(Fila(5), String)
            txtEmpleado.Text = CType(Fila(6), String)
            cboEmpleado.PosicionaCombo(CType(Fila(6), Integer))
            dtpFAsignacion.Value = CType(Fila(7), Date)
            cboTipoFolioMov.PosicionaCombo(CType(Fila(8), Integer))
            If Not IsDBNull(Fila(11)) Then
                cboProducto.PosicionaCombo(CType(Fila(11), Integer))
            End If
            btnAceptar.Enabled = True
            If FolioAsignadoDevuelto(cboTipoFolio.Identificador, txtSerie.Text, CType(txtFolioInicial.Text, Integer), _
            CType(txtFolioFinal.Text, Integer), cboTipoFolioMov.Identificador) Then
                HabilitarControles(False)
                btnAceptar.Enabled = False
                ActiveControl = btnCancelar
                Dim Mensajes As New PortatilClasses.Mensaje(27)
                MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Next
        oControlFolio = Nothing
        Cursor = Cursors.Default
    End Sub

    ' Consulta si los folios devueltos han sido asignados, regresa TRUE si el folio ha sido asignado y regresa
    ' FALSE si los folios devueltos no han sido asignados
    Private Function FolioAsignado() As Boolean
        If cboTipoFolioMov.Identificador > 1 Then
            Dim FolioInicial As Integer
            Dim FolioFinal As Integer
            Dim oControlFolio As New PortatilClasses.Consulta.cControlFolio()
            Dim Producto As Integer = 0
            If cboProducto.Text <> "" Then
                Producto = cboProducto.Identificador
            End If
            oControlFolio.Consultar(7, 0, cboTipoFolio.Identificador, 0, txtSerie.Text, CType(txtFolioInicial.Text, Integer), _
                                            CType(txtFolioFinal.Text, Integer), 0, Now, 1, Producto, GLOBAL_Usuario)
            Dim FilaAsignados As DataRow
            For Each FilaAsignados In oControlFolio.dtTable.Rows
                FolioInicial = CType(FilaAsignados(0), Integer)
                FolioFinal = CType(FilaAsignados(1), Integer)
                Try
                    FechaMaxima = CType(FilaAsignados(2), Date)
                Catch
                    FechaMaxima = Now
                End Try
            Next
            If CType(txtFolioInicial.Text, Integer) >= FolioInicial And _
            CType(txtFolioFinal.Text, Integer) <= FolioFinal Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function

    ' Consulta si los folios asignados han sido devueltos, regresa TRUE si el folio ha sido devuelto y regresa
    ' FALSE si los folios asignados no han sido devueltos
    Private Function FolioAsignadoDevuelto(ByVal TipoFolio As Integer, ByVal Serie As String, ByVal FolioI As Integer, _
    ByVal FolioF As Integer, ByVal TipoFolioMov As Integer) As Boolean
        If TipoFolioMov = 1 Then
            Dim FolioInicial As Integer
            Dim FolioFinal As Integer
            Dim oControlFolio As New PortatilClasses.Consulta.cControlFolio()
            Dim Producto As Integer = 0
            If cboProducto.Text <> "" Then
                Producto = cboProducto.Identificador
            End If
            oControlFolio.Consultar(7, 0, TipoFolio, 0, Serie, FolioI, FolioF, 0, Now, 2, Producto, GLOBAL_Usuario)
            Dim FilaAsignados As DataRow
            For Each FilaAsignados In oControlFolio.dtTable.Rows
                FolioInicial = CType(FilaAsignados(0), Integer)
                FolioFinal = CType(FilaAsignados(1), Integer)
                Try
                    FechaMaxima = CType(FilaAsignados(2), Date)
                Catch
                    FechaMaxima = Now
                End Try
            Next
            If FolioI >= FolioInicial And FolioF <= FolioFinal Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    ' Consulta si el folio a asignar esta duplicado, regersa un FALSE si no esta duplicado y TRUE si el folio
    ' esta duplicado
    Private Function FolioDuplicado() As Boolean
        Dim Producto As Integer = 0
        If cboProducto.Text <> "" Then
            Producto = cboProducto.Identificador
        End If
        Dim oControlFolio As New PortatilClasses.Consulta.cControlFolio()
        oControlFolio.Consultar(6, ControlFolio, cboTipoFolio.Identificador, 0, txtSerie.Text, CType(txtFolioInicial.Text, Integer), _
                                CType(txtFolioFinal.Text, Integer), 0, Now, cboTipoFolioMov.Identificador, Producto, GLOBAL_Usuario)
        Dim FilaDuplicados As DataRow
        For Each FilaDuplicados In oControlFolio.dtTable.Rows
            If CType(FilaDuplicados(0), Integer) = 0 Then
                Return False
            Else
                Return True
            End If
        Next
    End Function

    Private Sub Imprimir(ByVal Identificador As Integer)
        btnAceptar.Enabled = False
        Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteTicketControlFolios.rpt", Global_Servidor, _
                    Global_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
        oReporte.ListaParametros.Add(0)
        oReporte.ListaParametros.Add(Identificador)
        oReporte.ShowDialog()
    End Sub

    ' Registra la información de los controles del Folio asignado
    Private Sub RegistrarFolios()
        Cursor = Cursors.WaitCursor
        Dim oControlFolio As New PortatilClasses.Consulta.cControlFolio()

        If FolioAsignado() Then
            If (dtpFAsignacion.Value.Date >= FechaMaxima) Or (cboTipoFolioMov.Identificador = 1) Then
                If FolioDuplicado() = False Then
                    Dim Producto As Integer = 0
                    If cboProducto.Text <> "" Then
                        Producto = cboProducto.Identificador
                    End If
                    oControlFolio.Registrar(0, 0, cboTipoFolio.Identificador, CType(txtCantidad.Text, Integer), txtSerie.Text, _
                                    CType(txtFolioInicial.Text, Integer), CType(txtFolioFinal.Text, Integer), _
                                    CType(txtEmpleado.Text, Integer), dtpFAsignacion.Value.Date, cboTipoFolioMov.Identificador, 0, "", Producto, GLOBAL_Usuario)

                    DatosSalvados = True
                    If cboTipoFolioMov.Identificador = 1 Then
                        Imprimir(oControlFolio.ControlFolio)
                    End If
                    Close()
                Else
                    Dim Texto As String
                    If cboTipoFolioMov.Identificador = 1 Then
                        Texto = "asignados"
                    Else
                        Texto = "devueltos"
                    End If
                    Dim Mensajes As New PortatilClasses.Mensaje(22, Texto)
                    MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                Dim Mensajes As New PortatilClasses.Mensaje(26, "devolución")
                MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(25)
            MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        oControlFolio = Nothing
        Cursor = Cursors.Default
    End Sub

    ' Modifica la información de los controles del Folio asignado seleccionado
    Private Sub ModificarFolios()
        Cursor = Cursors.WaitCursor
        Dim oControlFolio As New PortatilClasses.Consulta.cControlFolio()

        If FolioAsignado() Then
            If (dtpFAsignacion.Value.Date >= FechaMaxima) Or (cboTipoFolioMov.Identificador = 1) Then
                If FolioDuplicado() = False Then
                    Dim Producto As Integer = 0
                    If cboProducto.Text <> "" Then
                        Producto = cboProducto.Identificador
                    End If
                    oControlFolio.Registrar(1, ControlFolio, cboTipoFolio.Identificador, CType(txtCantidad.Text, Integer), _
                                            txtSerie.Text, CType(txtFolioInicial.Text, Integer), CType(txtFolioFinal.Text, Integer), _
                                            CType(txtEmpleado.Text, Integer), dtpFAsignacion.Value.Date, cboTipoFolioMov.Identificador, 0, "", Producto, GLOBAL_Usuario)
                    DatosSalvados = True
                    If cboTipoFolioMov.Identificador = 1 Then
                        Imprimir(oControlFolio.ControlFolio)
                    End If
                    Close()
                Else
                    Dim Texto As String
                    If cboTipoFolioMov.Identificador = 1 Then
                        Texto = "asignados"
                    Else
                        Texto = "devueltos"
                    End If
                    Dim Mensajes As New PortatilClasses.Mensaje(22, Texto)
                    MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                Dim Mensajes As New PortatilClasses.Mensaje(26, "devolución")
                MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(25)
            MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        oControlFolio = Nothing
        Cursor = Cursors.Default
    End Sub

    ' Actualiza los folios y la cantidad de acuerdo al folio inicial, esta función e sllamada cuando el usuario
    ' modifica la serie o el tipo de folio
    Private Sub Actualizar()
        If txtFolioInicial.Text <> "" Then
            If txtCantidad.Text <> "" Then
                txtFolioFinal.Text = CType((CType(txtFolioInicial.Text, Integer) + CType(txtCantidad.Text, Integer) - 1), String)
            Else
                If txtFolioFinal.Text <> "" Then
                    txtCantidad.Text = CType((CType(txtFolioFinal.Text, Integer) - CType(txtFolioInicial.Text, Integer) + 1), String)
                End If
            End If
        End If
    End Sub

    ' Inicialización de la forma, inicializa las variables y controles necesarios
    Private Sub frmControlFolios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        LlenarComboCelula()
        Limpiar()
        If Operacion = Operaciones.Modificar Then
            cboEmpleado.CargaDatos(4, GLOBAL_Usuario)
        End If
        cboTipoFolio.CargaDatos(0)
        cboTipoFolioMov.CargaDatosBase("spPTLCargaComboTipoFolioMov", 0, GLOBAL_Usuario)
        cboProducto.CargaDatos(4, GLOBAL_Usuario)
        Cursor = Cursors.Default
        ActiveControl = cboTipoFolioMov
        If Operacion = Operaciones.Modificar Then
            CargarDatos()
        Else
            ControlFolio = 0
            btnAceptar.Enabled = False
        End If
        DatosSalvados = False

    End Sub

    Public Sub LlenarComboCelula()
        Me.cboCelula.DataSource = PortatilClasses.Consulta.ObtieneCelulasPorUsuario(PortatilClasses.Globals.GetInstance._Usuario)
        Me.cboCelula.DisplayMember = "Descripcion"
        Me.cboCelula.ValueMember = "IdCelula"

    End Sub


    ' Evento de los controles para pasar de un control a otro por medio del Enter o las teclas de arriba o abajo
    Private Sub txtSerie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles txtSerie.KeyDown, txtFolioInicial.KeyDown, txtFolioFinal.KeyDown, txtCantidad.KeyDown
        If e.KeyData = Keys.Enter Or (e.KeyData = Keys.Down) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            MyBase.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    ' Evento que cierra la forma
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    ' Evento que se activa al hacer clic en el control aceptar, registra o modifica la informacion dependiendo
    ' de la operación que se vaya a realizar
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Refresh()
            If Operacion = Operaciones.Registrar Then
                RegistrarFolios()
            End If
            If Operacion = Operaciones.Modificar Then
                ModificarFolios()
            End If
        End If
    End Sub

    ' Evento que llama al procedimeinto HabilitarAceptar, se ejecuta cuando hay un cambio en el control
    Private Sub dtpFAsignacion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles dtpFAsignacion.TextChanged, txtFolioInicial.TextChanged, txtFolioFinal.TextChanged, _
    txtCantidad.TextChanged
        HabilitarAceptar()
    End Sub

    ' Evento que llama al procedimeinto HabilitarAceptar, se ejecuta cuando hay un cambio en el control, carga
    ' el folio inicial si el tipo de folio y la serie están llenados
    Private Sub cboTipoFolio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cboTipoFolio.SelectedIndexChanged, txtSerie.TextChanged, cboTipoFolioMov.SelectedIndexChanged, cboProducto.SelectedIndexChanged
        If CType(sender, Control).Focus Then
            If cboTipoFolio.Text <> "" And txtSerie.Text <> "" Then
                Cursor = Cursors.WaitCursor
                Dim Producto As Integer = 0
                If cboProducto.Text <> "" Then
                    Producto = cboProducto.Identificador
                End If
                Dim oControlFolio As New PortatilClasses.Consulta.cControlFolio()
                oControlFolio.Consultar(2, 0, cboTipoFolio.Identificador, 0, txtSerie.Text, 0, 0, 0, Now, cboTipoFolioMov.Identificador, Producto, GLOBAL_Usuario)
                Dim Fila As DataRow
                For Each Fila In oControlFolio.dtTable.Rows
                    If Fila.IsNull(0) = False Then
                        txtFolioInicial.Text = CType(Fila(0), String)
                    End If
                Next
                Cursor = Cursors.Default
                Actualizar()
            End If
            HabilitarAceptar()
        End If
    End Sub

    ' Evento que llama al procedimeinto HabilitarAceptar, se ejecuta cuando hay un cambio en el control, carga
    ' el numero de nomida al selecionar del combo el nombre del empleado
    Private Sub cboEmpleado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cboEmpleado.SelectedIndexChanged
        'If cboEmpleado.Focused Then
        '    If cboEmpleado.Text <> "" Then
        '        txtEmpleado.Text = CType(cboEmpleado.Identificador, String)
        '    End If
        'End If
        If Not TypeOf Me.cboEmpleado.SelectedValue Is DataRowView Then
            Me.txtEmpleado.Text = Convert.ToString(Me.cboEmpleado.SelectedValue)
        End If
        HabilitarAceptar()
    End Sub

    ' Evento que llama al procedimeinto HabilitarAceptar, se ejecuta cuando hay un cambio en el control
    Private Sub txtEmpleado_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtEmpleado.TextChanged
        RealizarBusqueda = True
        HabilitarAceptar()
    End Sub

    ' Carga el folio final dependiendo de la cantidad introducida de folios asignados
    Private Sub txtCantidad_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad.Leave
        If txtFolioInicial.Text <> "" And txtCantidad.Text <> "" Then
            txtFolioFinal.Text = CType((CType(txtFolioInicial.Text, Integer) + CType(txtCantidad.Text, Integer) - 1), String)
        End If
    End Sub

    ' Carga el nombre del empelado al teclear el número de nomina y dar enter
    Private Sub txtEmpleado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles txtEmpleado.KeyDown
        If e.KeyData = Keys.Enter And RealizarBusqueda = False Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If

        If e.KeyData = Keys.Enter And RealizarBusqueda And txtEmpleado.Text <> "" Then
            Cursor = Cursors.WaitCursor
            cboEmpleado.PosicionaCombo(CType(txtEmpleado.Text, Integer))
            If cboEmpleado.SelectedIndex < 0 Then
                Dim Mensajes As New PortatilClasses.Mensaje(15, txtEmpleado.Text)
                MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtEmpleado.Clear()
                ActiveControl = txtEmpleado
            Else
                RealizarBusqueda = False
            End If
            Cursor = Cursors.Default
        End If
        If e.KeyData = Keys.Enter And RealizarBusqueda And txtEmpleado.Text = "" Then
            cboEmpleado.PosicionarInicio()
        End If
        If e.KeyData = Keys.Up Then
            MyBase.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
        If e.KeyData = Keys.Down Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    ' Inicializa la variable
    Private Sub txtEmpleado_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpleado.Enter
        RealizarBusqueda = False
    End Sub

    ' Valida si la información es correcta
    Private Sub txtFolioInicial_Leave(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtFolioInicial.Leave, txtFolioFinal.Leave
        If txtFolioInicial.Text <> "" And txtFolioFinal.Text <> "" Then
            If CType(txtFolioInicial.Text, Integer) > CType(txtFolioFinal.Text, Integer) Then
                CType(sender, TextBox).Clear()
                ActiveControl = CType(sender, Control)
                Dim Mensajes As New PortatilClasses.Mensaje(23)
                MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                txtCantidad.Text = CType((CType(txtFolioFinal.Text, Integer) - CType(txtFolioInicial.Text, Integer) + 1), String)
            End If
        End If
        If txtFolioInicial.Text <> "" And txtCantidad.Text <> "" Then
            txtFolioFinal.Text = CType((CType(txtFolioInicial.Text, Integer) + CType(txtCantidad.Text, Integer) - 1), String)
        End If
    End Sub

    ' Evento de los controles para pasar de un control a otro por medio del Enter
    Private Sub cboTipoFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles cboTipoFolio.KeyDown, cboEmpleado.KeyDown, dtpFAsignacion.KeyDown, cboTipoFolioMov.KeyDown, cboProducto.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub frmAsignarFolios_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If DatosSalvados = False Then
            Dim Result As DialogResult
            Dim Mensajes As New PortatilClasses.Mensaje(28)
            Result = MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub cboProducto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboProducto.KeyUp
        If e.KeyData = Keys.Delete Then
            cboProducto.PosicionarInicio()
        End If
    End Sub


    Private Sub cboCelula_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedIndexChanged
        If Not TypeOf cboCelula.SelectedValue Is System.Data.DataRowView Then
            If Not Me.cboCelula.SelectedValue Is Nothing Then
                Me.cboEmpleado.DataSource = PortatilClasses.Consulta.ObtieneEmpleadosPorCelula(Convert.ToString(Me.cboCelula.SelectedValue))
                Me.cboEmpleado.DisplayMember = "Nombre"
                Me.cboEmpleado.ValueMember = "Empleado"
            End If
        End If
        Me.txtEmpleado.Text = ""
    End Sub
End Class

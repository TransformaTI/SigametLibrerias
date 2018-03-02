' Registra y modifica folios cancelados, podemos cancelar diferentes tipo de folio
' los folios a cancelar tienen quee estar asignados de los contrario no se permitira
' caneclar folios no asignados
Public Class frmCancelarFolios
    Inherits System.Windows.Forms.Form

    Private Titulo As String
    Private RealizarBusqueda As Boolean

    Private Operacion As Operaciones
    Private FolioCancelado As Integer
    Private FAsignacion As Date
    Public DatosSalvados As Boolean

    ' Operaciones que se pueden realizar en esta forma
    Public Enum Operaciones
        Registrar
        Modificar
    End Enum


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal _Operacion As Operaciones, ByVal _FolioCancelado As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Operacion = _Operacion
        FolioCancelado = _FolioCancelado
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
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents cboMCancelacion As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboEmpleado As PortatilClasses.Combo.ComboOperadorPtl
    Friend WithEvents txtEmpleado As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents dtpFCancelacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboTipoFolio As PortatilClasses.Combo.ComboTipoFolio
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFolioInicial As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtFolioFinal As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents cboProducto As PortatilClasses.Combo.ComboProductoPtl
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancelarFolios))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.cboProducto = New PortatilClasses.Combo.ComboProductoPtl()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFolioFinal = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboTipoFolio = New PortatilClasses.Combo.ComboTipoFolio()
        Me.dtpFCancelacion = New System.Windows.Forms.DateTimePicker()
        Me.txtEmpleado = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboEmpleado = New PortatilClasses.Combo.ComboOperadorPtl()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFolioInicial = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.cboMCancelacion = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(429, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCelula)
        Me.GroupBox1.Controls.Add(Me.cboCelula)
        Me.GroupBox1.Controls.Add(Me.cboProducto)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtFolioFinal)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cboTipoFolio)
        Me.GroupBox1.Controls.Add(Me.dtpFCancelacion)
        Me.GroupBox1.Controls.Add(Me.txtEmpleado)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboEmpleado)
        Me.GroupBox1.Controls.Add(Me.txtSerie)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtFolioInicial)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblDescripcion)
        Me.GroupBox1.Controls.Add(Me.cboMCancelacion)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(392, 392)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCelula.Location = New System.Drawing.Point(21, 177)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(44, 13)
        Me.lblCelula.TabIndex = 28
        Me.lblCelula.Text = "Celula:"
        Me.lblCelula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(138, 172)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboCelula.Size = New System.Drawing.Size(224, 21)
        Me.cboCelula.TabIndex = 5
        '
        'cboProducto
        '
        Me.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto.Location = New System.Drawing.Point(140, 60)
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(228, 21)
        Me.cboProducto.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(20, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Producto:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFolioFinal
        '
        Me.txtFolioFinal.Location = New System.Drawing.Point(140, 144)
        Me.txtFolioFinal.MaxLength = 15
        Me.txtFolioFinal.Name = "txtFolioFinal"
        Me.txtFolioFinal.Size = New System.Drawing.Size(100, 21)
        Me.txtFolioFinal.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(20, 148)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Folio final:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTipoFolio
        '
        Me.cboTipoFolio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoFolio.Location = New System.Drawing.Point(140, 32)
        Me.cboTipoFolio.Name = "cboTipoFolio"
        Me.cboTipoFolio.Size = New System.Drawing.Size(228, 21)
        Me.cboTipoFolio.TabIndex = 0
        '
        'dtpFCancelacion
        '
        Me.dtpFCancelacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFCancelacion.Location = New System.Drawing.Point(140, 259)
        Me.dtpFCancelacion.Name = "dtpFCancelacion"
        Me.dtpFCancelacion.Size = New System.Drawing.Size(228, 21)
        Me.dtpFCancelacion.TabIndex = 8
        '
        'txtEmpleado
        '
        Me.txtEmpleado.Location = New System.Drawing.Point(139, 231)
        Me.txtEmpleado.MaxLength = 10
        Me.txtEmpleado.Name = "txtEmpleado"
        Me.txtEmpleado.Size = New System.Drawing.Size(100, 21)
        Me.txtEmpleado.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(20, 259)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Fecha cancelación:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(20, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Tipo folio:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(20, 203)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Empleado:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboEmpleado
        '
        Me.cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpleado.Location = New System.Drawing.Point(139, 203)
        Me.cboEmpleado.Name = "cboEmpleado"
        Me.cboEmpleado.Size = New System.Drawing.Size(228, 21)
        Me.cboEmpleado.TabIndex = 6
        '
        'txtSerie
        '
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.Location = New System.Drawing.Point(140, 88)
        Me.txtSerie.MaxLength = 10
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(100, 21)
        Me.txtSerie.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(20, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Serie:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFolioInicial
        '
        Me.txtFolioInicial.Location = New System.Drawing.Point(140, 116)
        Me.txtFolioInicial.MaxLength = 15
        Me.txtFolioInicial.Name = "txtFolioInicial"
        Me.txtFolioInicial.Size = New System.Drawing.Size(100, 21)
        Me.txtFolioInicial.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(20, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Folio inicial:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Location = New System.Drawing.Point(20, 339)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(348, 40)
        Me.lblDescripcion.TabIndex = 10
        Me.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboMCancelacion
        '
        Me.cboMCancelacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMCancelacion.Location = New System.Drawing.Point(19, 315)
        Me.cboMCancelacion.Name = "cboMCancelacion"
        Me.cboMCancelacion.Size = New System.Drawing.Size(349, 21)
        Me.cboMCancelacion.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(20, 291)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Causa de cancelación"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(429, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCancelarFolios
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(510, 432)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnAceptar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmCancelarFolios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelar folios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Limpia los controles de la forma
    Private Sub Limpiar()
        txtFolioInicial.Clear()
        txtFolioFinal.Clear()
        txtSerie.Clear()
        txtEmpleado.Clear()
        lblDescripcion.Text = ""
        If cboCelula.Items.Count > 1 Then
            cboCelula.SelectedIndex = -1
            cboCelula.SelectedIndex = -1
        End If
        If cboEmpleado.Items.Count > 1 Then
            cboEmpleado.SelectedIndex = -1
            cboEmpleado.SelectedIndex = -1
        End If
        If cboTipoFolio.Items.Count > 1 Then
            cboTipoFolio.SelectedIndex = -1
            cboTipoFolio.SelectedIndex = -1
        End If
        If cboMCancelacion.Items.Count > 1 Then
            cboMCancelacion.SelectedIndex = -1
            cboMCancelacion.SelectedIndex = -1
        End If
        If cboProducto.Items.Count > 1 Then
            cboProducto.PosicionarInicio()
        End If
        Me.Text = Me.Text & " [" & Operacion.ToString & "]"
        Titulo = "Folios cancelados"
    End Sub

    ' Habilita el boton aceptar si los controles necesarios son llenados
    Private Sub HabilitarAceptar()
        If txtFolioInicial.Text <> "" And txtSerie.Text <> "" And txtEmpleado.Text <> "" And cboEmpleado.Text <> "" And _
        cboTipoFolio.Text <> "" And cboMCancelacion.Text <> "" And txtFolioFinal.Text <> "" Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    ' Carga los datos a los controles dependiendo del Folio Cancelado seleccionado
    Private Sub CargarDatos()
        Cursor = Cursors.WaitCursor
        Dim oFolioCancelado As New PortatilClasses.Consulta.cFolioCancelado()
        oFolioCancelado.Consultar(2, FolioCancelado, "0", Now, 0, 0, "0", "0", 0, 0, GLOBAL_Usuario)
        Dim Fila As DataRow
        For Each Fila In oFolioCancelado.dtTable.Rows
            txtSerie.Text = CType(Fila(1), String)
            dtpFCancelacion.Value = CType(Fila(2), Date)
            txtEmpleado.Text = CType(Fila(3), String)
            cboEmpleado.PosicionaCombo(CType(Fila(3), Integer))
            cboTipoFolio.PosicionaCombo(CType(Fila(4), Integer))
            txtFolioInicial.Text = CType(Fila(5), String)
            txtFolioFinal.Text = CType(Fila(6), String)
            cboMCancelacion.PosicionaCombo(CType(Fila(7), Integer))
            If Not IsDBNull(Fila(8)) Then
                cboProducto.PosicionaCombo(CType(Fila(8), Integer))
            End If
        Next
        oFolioCancelado = Nothing
        Cursor = Cursors.Default
    End Sub

    ' Consulta si los folios a cancelar han sido asignados, regresa TRUE si el folio ha sido asignado y regresa
    ' FALSE si los folios a cancelar no han sido asignados
    Private Function FolioAsignado() As Boolean
        Dim FolioInicial As Integer
        Dim FolioFinal As Integer
        Dim Producto As Integer = 0
        If cboProducto.Text <> "" Then
            Producto = cboProducto.Identificador
        End If

        Dim oFolioCancelado As New PortatilClasses.Consulta.cFolioCancelado()

        oFolioCancelado.Consultar(5, 0, txtSerie.Text, Now, 0, cboTipoFolio.Identificador, txtFolioInicial.Text, _
                                  txtFolioFinal.Text, 0, Producto, GLOBAL_Usuario)
        Dim FilaAsignados As DataRow
        For Each FilaAsignados In oFolioCancelado.dtTable.Rows
            FolioInicial = CType(FilaAsignados(0), Integer)
            FolioFinal = CType(FilaAsignados(1), Integer)
            Try
                FAsignacion = CType(FilaAsignados(2), Date)
            Catch
                FAsignacion = Now
            End Try
        Next
        If CType(txtFolioInicial.Text, Integer) >= FolioInicial And _
        CType(txtFolioFinal.Text, Integer) <= FolioFinal Then
            Return True
        Else
            Return False
        End If
    End Function

    ' Consulta si los folios a cancelar estan duplicado, regresa un FALSE si no esta duplicado y TRUE si el folio
    ' esta duplicado
    Private Function FolioDuplicado() As Boolean
        Dim Producto As Integer = 0
        If cboProducto.Text <> "" Then
            Producto = cboProducto.Identificador
        End If
        Dim oFolioCancelado As New PortatilClasses.Consulta.cFolioCancelado()
        oFolioCancelado.Consultar(6, FolioCancelado, txtSerie.Text, Now, 0, cboTipoFolio.Identificador, txtFolioInicial.Text, _
                                              txtFolioFinal.Text, 0, Producto, GLOBAL_Usuario)
        Dim FilaDuplicados As DataRow
        For Each FilaDuplicados In oFolioCancelado.dtTable.Rows
            If CType(FilaDuplicados(0), Integer) = 0 Then
                Return False
            Else
                Return True
            End If
        Next
    End Function

    ' Registra la información de los controles del Folio cancelado
    Private Sub RegistrarFolioCancelado()
        Cursor = Cursors.WaitCursor
        Dim Producto As Integer = 0
        If cboProducto.Text <> "" Then
            Producto = cboProducto.Identificador
        End If

        Dim oFolioCancelado As New PortatilClasses.Consulta.cFolioCancelado()

        If FolioAsignado() Then

            'If dtpFCancelacion.Value.Date >= FAsignacion Then
            If FolioDuplicado() = False Then
                oFolioCancelado.Registrar(0, 0, txtSerie.Text, dtpFCancelacion.Value.Date, CType(txtEmpleado.Text, Integer), _
                                          cboTipoFolio.Identificador, txtFolioInicial.Text, txtFolioFinal.Text, _
                                          cboMCancelacion.Identificador, Producto, GLOBAL_Usuario)
                DatosSalvados = True
                Close()
            Else
                Dim Mensajes As New PortatilClasses.Mensaje(20)
                MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'Else
            '    Dim Mensajes As New PortatilClasses.Mensaje(26, "cancelación")
            '    MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(21)
            MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        oFolioCancelado = Nothing
        Cursor = Cursors.Default
    End Sub

    ' Modifica la información de los controles del Folio Cancelado seleccionado
    Private Sub ModificarFolioCancelado()
        Cursor = Cursors.WaitCursor
        Dim oFolioCancelado As New PortatilClasses.Consulta.cFolioCancelado()

        If FolioAsignado() Then
            'If dtpFCancelacion.Value.Date >= FAsignacion Then
            If FolioDuplicado() = False Then
                Dim Producto As Integer = 0
                If cboProducto.Text <> "" Then
                    Producto = cboProducto.Identificador
                End If

                oFolioCancelado.Registrar(1, FolioCancelado, txtSerie.Text, dtpFCancelacion.Value.Date, CType(txtEmpleado.Text, Integer), _
                                         cboTipoFolio.Identificador, txtFolioInicial.Text, txtFolioFinal.Text, _
                                         cboMCancelacion.Identificador, Producto, GLOBAL_Usuario)
                DatosSalvados = True
                Close()
            Else
                Dim Mensajes As New PortatilClasses.Mensaje(20)
                MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            'Else
            '    Dim Mensajes As New PortatilClasses.Mensaje(26, "cancelación")
            '    MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(21)
            MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        oFolioCancelado = Nothing
        Cursor = Cursors.Default
    End Sub

    ' Evento de los controles para pasar de un control a otro por medio del Enter 
    Private Sub txtFolioInicial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles txtFolioInicial.KeyDown, txtFolioFinal.KeyDown, txtSerie.KeyDown
        If e.KeyData = Keys.Enter Or (e.KeyData = Keys.Down) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            MyBase.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    ' Inicialización de la forma, inicializa las variables y controles necesarios
    Private Sub frmCancelarFolios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        LlenarComboCelula()
        Limpiar()
        If Operacion = Operaciones.Modificar Then
            cboEmpleado.CargaDatos(4, GLOBAL_Usuario)
        End If
        cboTipoFolio.CargaDatos(0)
        cboMCancelacion.CargaDatosBase("spPTLCargaComboMCancelacion", 3, GLOBAL_Usuario)
        cboProducto.CargaDatos(4, GLOBAL_Usuario)
        Cursor = Cursors.Default
        If Operacion = Operaciones.Modificar Then
            CargarDatos()
            btnAceptar.Enabled = True
        Else
            FolioCancelado = 0
            btnAceptar.Enabled = False
        End If
        ActiveControl = cboTipoFolio
        DatosSalvados = False

    End Sub


    Public Sub LlenarComboCelula()
        Me.cboCelula.DataSource = PortatilClasses.Consulta.ObtieneCelulasPorUsuario(PortatilClasses.Globals.GetInstance._Usuario)
        Me.cboCelula.DisplayMember = "Descripcion"
        Me.cboCelula.ValueMember = "IdCelula"

    End Sub

    ' Evento que llama al procedimeinto HabilitarAceptar, se ejecuta cuando hay un cambio en el control
    Private Sub txtFolioInicial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles cboTipoFolio.SelectedIndexChanged, txtFolioInicial.TextChanged, txtFolioFinal.TextChanged, _
    txtSerie.TextChanged
        HabilitarAceptar()
    End Sub

    ' Evento que llama al procedimeinto HabilitarAceptar, se ejecuta cuando hay un cambio en el control
    Private Sub txtEmpleado_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtEmpleado.TextChanged
        RealizarBusqueda = True
        HabilitarAceptar()
    End Sub

    ' Evento que llama al procedimeinto HabilitarAceptar, se ejecuta cuando hay un cambio en el control, carga
    ' el numero de nomida al selecionar del combo el nombre del empleado
    Private Sub cboEmpleado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEmpleado.SelectedIndexChanged
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

    ' Evento que se activa al hacer clic en el control aceptar, registra o modifica la informacion dependiendo
    ' de la operación que se vaya a realizar
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Refresh()
            If Operacion = Operaciones.Registrar Then
                RegistrarFolioCancelado()
            End If
            If Operacion = Operaciones.Modificar Then
                ModificarFolioCancelado()
            End If
        End If
    End Sub

    ' Evento que llama al procedimeinto HabilitarAceptar, se ejecuta cuando hay un cambio en el control, carga
    ' el motivo de cancelación en una etiqueta debido al que el tamaño del motivo de cancelación puede ser mayor
    ' al tamaño del combo
    Private Sub cboMCancelacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cboMCancelacion.SelectedIndexChanged
        If cboMCancelacion.Text <> "" Then
            HabilitarAceptar()
            If cboMCancelacion.Focused Then
                lblDescripcion.Text = cboMCancelacion.Text
            End If
        End If
    End Sub

    ' Evento que cierra la forma
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    ' Carga el nombre del empelado al teclear el número de nomina y dar enter
    Private Sub txtEmpleado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmpleado.KeyDown
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
            End If
        End If
    End Sub

    ' Evento de los controles para pasar de un control a otro por medio del Enter
    Private Sub cboTipoFolio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles cboTipoFolio.KeyDown, cboEmpleado.KeyDown, dtpFCancelacion.KeyDown, cboMCancelacion.KeyDown, cboProducto.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub frmCancelarFolios_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If DatosSalvados = False Then
            Dim Result As DialogResult
            Dim Mensajes As New PortatilClasses.Mensaje(28)
            Result = MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.No Then
                e.Cancel = True
            End If
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
        'cboCelula.SelectedIndex = -1
    End Sub
End Class

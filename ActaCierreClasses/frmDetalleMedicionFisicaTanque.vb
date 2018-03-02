Imports System.Windows.Forms
Imports PortatilClasses

' Forma en donde se selecciona la causa de cancelación, no realiza ni un registro a la base de datos
' solo muestra las causas de cancelación para que el usuario seleccione la causa
Public Class frmDetalleMedicionFisicaTanque
    Inherits System.Windows.Forms.Form

    'Public MCancelacion As Integer
    'Public DCancelacion As String
    'Public TCancelacion As Integer
    
    Private _NumEmpleado, _Año, _Mes, _Folio As Integer
    Private _Corporativo, _Sucursal As Short
    Private _FInicialActa, _UsuarioAlta As String
    Private _TipoServicio As Boolean
    Private _FInicial, _FFinal As Date
    Private dtMedicionFisica As DataTable
    Private dvMedicionFisica As DataView
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button


    Dim RepeticionActivo As Boolean = False

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Año As Integer, ByVal Mes As Integer, ByVal Corporativo As Short,
                  ByVal Sucursal As Short, ByVal Folio As Integer, ByVal FInicial As DateTime,
                  ByVal FFinal As DateTime, FInicialActa As String, ByVal UsuarioAlta As String,
                  ByVal TipoServicio As Boolean, ByVal NumEmpleado As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _Año = Año
        _Mes = Mes
        _Corporativo = Corporativo
        _Sucursal = Sucursal
        _Folio = Folio
        _FInicial = FInicial
        _FFinal = FFinal
        _FInicialActa = FInicialActa
        _UsuarioAlta = UsuarioAlta
        _TipoServicio = TipoServicio
        _NumEmpleado = NumEmpleado
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
    Friend WithEvents txtNominaInicial As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents lblEmpleadoInicial As System.Windows.Forms.Label
    Friend WithEvents cboEmpleadoInicial As PortatilClasses.Combo.ComboEmpleado
    Friend WithEvents dtpFHoraInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFHoraInicial As System.Windows.Forms.Label
    Friend WithEvents chkSeleccion As System.Windows.Forms.CheckBox
    Friend WithEvents dgvMedicionFisica As System.Windows.Forms.DataGridView
    Friend WithEvents lblEtiqMedicionFisica As System.Windows.Forms.Label
    Friend WithEvents grpMedicionFisica As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetalleMedicionFisicaTanque))
        Me.grpMedicionFisica = New System.Windows.Forms.GroupBox()
        Me.txtNominaInicial = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lblEmpleadoInicial = New System.Windows.Forms.Label()
        Me.cboEmpleadoInicial = New PortatilClasses.Combo.ComboEmpleado()
        Me.dtpFHoraInicial = New System.Windows.Forms.DateTimePicker()
        Me.lblFHoraInicial = New System.Windows.Forms.Label()
        Me.chkSeleccion = New System.Windows.Forms.CheckBox()
        Me.dgvMedicionFisica = New System.Windows.Forms.DataGridView()
        Me.lblEtiqMedicionFisica = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.grpMedicionFisica.SuspendLayout()
        CType(Me.dgvMedicionFisica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpMedicionFisica
        '
        Me.grpMedicionFisica.Controls.Add(Me.txtNominaInicial)
        Me.grpMedicionFisica.Controls.Add(Me.lblEmpleadoInicial)
        Me.grpMedicionFisica.Controls.Add(Me.cboEmpleadoInicial)
        Me.grpMedicionFisica.Controls.Add(Me.dtpFHoraInicial)
        Me.grpMedicionFisica.Controls.Add(Me.lblFHoraInicial)
        Me.grpMedicionFisica.Controls.Add(Me.chkSeleccion)
        Me.grpMedicionFisica.Controls.Add(Me.dgvMedicionFisica)
        Me.grpMedicionFisica.Controls.Add(Me.lblEtiqMedicionFisica)
        Me.grpMedicionFisica.Location = New System.Drawing.Point(16, 8)
        Me.grpMedicionFisica.Name = "grpMedicionFisica"
        Me.grpMedicionFisica.Size = New System.Drawing.Size(679, 402)
        Me.grpMedicionFisica.TabIndex = 4
        Me.grpMedicionFisica.TabStop = False
        '
        'txtNominaInicial
        '
        Me.txtNominaInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtNominaInicial.Location = New System.Drawing.Point(167, 44)
        Me.txtNominaInicial.MaxLength = 6
        Me.txtNominaInicial.Name = "txtNominaInicial"
        Me.txtNominaInicial.Size = New System.Drawing.Size(53, 20)
        Me.txtNominaInicial.TabIndex = 75
        '
        'lblEmpleadoInicial
        '
        Me.lblEmpleadoInicial.AutoSize = True
        Me.lblEmpleadoInicial.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmpleadoInicial.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmpleadoInicial.Location = New System.Drawing.Point(7, 46)
        Me.lblEmpleadoInicial.Name = "lblEmpleadoInicial"
        Me.lblEmpleadoInicial.Size = New System.Drawing.Size(141, 13)
        Me.lblEmpleadoInicial.TabIndex = 78
        Me.lblEmpleadoInicial.Text = "Empleado tomo lectura:"
        '
        'cboEmpleadoInicial
        '
        Me.cboEmpleadoInicial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpleadoInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboEmpleadoInicial.Location = New System.Drawing.Point(226, 44)
        Me.cboEmpleadoInicial.Name = "cboEmpleadoInicial"
        Me.cboEmpleadoInicial.Size = New System.Drawing.Size(232, 21)
        Me.cboEmpleadoInicial.TabIndex = 76
        '
        'dtpFHoraInicial
        '
        Me.dtpFHoraInicial.CustomFormat = "dd/MM/yyyy "
        Me.dtpFHoraInicial.Enabled = False
        Me.dtpFHoraInicial.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpFHoraInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFHoraInicial.Location = New System.Drawing.Point(167, 16)
        Me.dtpFHoraInicial.Name = "dtpFHoraInicial"
        Me.dtpFHoraInicial.Size = New System.Drawing.Size(291, 20)
        Me.dtpFHoraInicial.TabIndex = 74
        '
        'lblFHoraInicial
        '
        Me.lblFHoraInicial.AutoSize = True
        Me.lblFHoraInicial.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblFHoraInicial.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFHoraInicial.Location = New System.Drawing.Point(7, 20)
        Me.lblFHoraInicial.Name = "lblFHoraInicial"
        Me.lblFHoraInicial.Size = New System.Drawing.Size(153, 13)
        Me.lblFHoraInicial.TabIndex = 77
        Me.lblFHoraInicial.Text = "Fecha y hora de medición:"
        '
        'chkSeleccion
        '
        Me.chkSeleccion.AutoSize = True
        Me.chkSeleccion.Location = New System.Drawing.Point(55, 97)
        Me.chkSeleccion.Name = "chkSeleccion"
        Me.chkSeleccion.Size = New System.Drawing.Size(15, 14)
        Me.chkSeleccion.TabIndex = 15
        Me.chkSeleccion.UseVisualStyleBackColor = True
        '
        'dgvMedicionFisica
        '
        Me.dgvMedicionFisica.AllowUserToAddRows = False
        Me.dgvMedicionFisica.AllowUserToDeleteRows = False
        Me.dgvMedicionFisica.AllowUserToResizeColumns = False
        Me.dgvMedicionFisica.AllowUserToResizeRows = False
        Me.dgvMedicionFisica.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgvMedicionFisica.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvMedicionFisica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMedicionFisica.Location = New System.Drawing.Point(0, 92)
        Me.dgvMedicionFisica.Name = "dgvMedicionFisica"
        Me.dgvMedicionFisica.ReadOnly = True
        Me.dgvMedicionFisica.Size = New System.Drawing.Size(679, 304)
        Me.dgvMedicionFisica.TabIndex = 16
        Me.dgvMedicionFisica.TabStop = False
        '
        'lblEtiqMedicionFisica
        '
        Me.lblEtiqMedicionFisica.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblEtiqMedicionFisica.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEtiqMedicionFisica.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblEtiqMedicionFisica.Location = New System.Drawing.Point(0, 71)
        Me.lblEtiqMedicionFisica.Name = "lblEtiqMedicionFisica"
        Me.lblEtiqMedicionFisica.Size = New System.Drawing.Size(679, 22)
        Me.lblEtiqMedicionFisica.TabIndex = 14
        Me.lblEtiqMedicionFisica.Text = "Meidición fisica realizada"
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(701, 21)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 30
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(701, 50)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 31
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmDetalleMedicionFisicaTanque
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(784, 422)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.grpMedicionFisica)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmDetalleMedicionFisicaTanque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de medicion realizadas"
        Me.grpMedicionFisica.ResumeLayout(False)
        Me.grpMedicionFisica.PerformLayout()
        CType(Me.dgvMedicionFisica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CargarDatosIniciales()
        cboEmpleadoInicial.CargaDatos(0)
        If _NumEmpleado <> 0 Then
            cboEmpleadoInicial.SelectedValue = _NumEmpleado
            txtNominaInicial.Text = CType(_NumEmpleado, String)
        Else
            cboEmpleadoInicial.SelectedIndex = -1
            cboEmpleadoInicial.SelectedIndex = -1
        End If

        'If _FInicialActa = "" Then
        '    dtpFHoraInicial.Value = Now
        'Else
        '    dtpFHoraInicial.Value = CType(_FInicialActa, DateTime)
        'End If

        dtpFHoraInicial.Value = CType(_FInicialActa, Date).AddDays(1)

    End Sub

    Private Sub CargarDatos()
        Cursor = Cursors.WaitCursor
        Try

            Dim oConsultaMedicionFisicaTanque As New Consulta.cConsultaMedicionFisicaTanque(0, _Mes, _Año, _Corporativo, _Sucursal, _Folio, _FInicial, _FFinal, _TipoServicio, dtpFHoraInicial.Value)

            oConsultaMedicionFisicaTanque.dtTable.Columns.Add("Seleccion", GetType(Boolean)).DefaultValue = False


            If oConsultaMedicionFisicaTanque.dtTable.Rows.Count > 0 Then
                For Each dr As DataRow In oConsultaMedicionFisicaTanque.dtTable.Rows
                    dr("Seleccion") = Convert.ToBoolean(0)
                Next
            End If

            dtMedicionFisica = oConsultaMedicionFisicaTanque.dtTable
            dvMedicionFisica = New DataView(dtMedicionFisica)
            dgvMedicionFisica.DataSource = dvMedicionFisica

            oConsultaMedicionFisicaTanque = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormatoDataGridViewMedicionFisica()

        Dim Inicio As Integer
        Dim Final As Integer
        Dim SubtCaracter As String

        'Asignacion propiedades del gridview
        Dim Mapa() As String = {"Seleccion", "MedicionFisica", "Tanque", "TanqueDescripcion", "AlmacenGas", "AlmacenGasDescripcion", _
                                      "CelulaDescripcion", "PorcentajeTanque", "TemperaturaTanque", "PresionTanque"}

        Dim Anchura() As Integer = {35, 65, 0, 180, 0, 180, 90, 70, 70, 70}

        Dim Texto() As String = {"Seleccion= ", "MedicionFisica=Medición fisica", "TanqueDescripcion=Tanque", "AlmacenGasDescripcion=Almacén", _
                                 "Medida=Unidad medida", "SucursalDescripcion=Sucursal", "CelulaDescripcion=Celula", "PorcentajeTanque=Tanque(%)", "TemperaturaTanque=Temperatura", "PresionTanque=Presion"}

        Dim Visible() As String = {"MedicionFisica", "Tanque", "AlmacenGas"}

        Dim Inmovilizar() As String = {"Seleccion"}

        'Que columnas estarán visibles
        For i As Integer = 0 To Mapa.Length - 1

            'Cual sera el orden de las columnas
            dgvMedicionFisica.Columns(Mapa(i)).DisplayIndex = i

            'Ajustamiento del tamaño de las columnas
            dgvMedicionFisica.Columns(Mapa(i)).Width = Anchura(i)

            'Encabezado de las columnas
            For j As Integer = 0 To Texto.Length - 1
                Inicio = 0
                Final = Texto(j).LastIndexOf("=")
                SubtCaracter = Texto(j).Substring(Inicio, Final)

                If Mapa(i) = SubtCaracter Then
                    Inicio = Texto(j).LastIndexOf("=") + 1
                    Final = Texto(j).Length
                    SubtCaracter = Texto(j).Substring(Inicio, Final - Inicio)
                    dgvMedicionFisica.Columns(Mapa(i)).HeaderText = SubtCaracter
                    'Exit For
                End If

                'Determina que columnas estaran visibles
                For l As Integer = 0 To Visible.Length - 1
                    If Mapa(i) = Visible(l) Then
                        dgvMedicionFisica.Columns(Mapa(i)).Visible = False
                        'Exit For
                    End If
                Next

                'Determina que columnas estaran visibles
                For k As Integer = 0 To Inmovilizar.Length - 1
                    If Mapa(i) = Inmovilizar(k) Then
                        dgvMedicionFisica.Columns(Mapa(i)).Frozen = True
                        'Exit For
                    End If
                Next
            Next
        Next
    End Sub

    Private Sub SeleccionarTodos()
        If RepeticionActivo = False Then
            If chkSeleccion.Checked Then
                chkSeleccion.Checked = True
                For Each rowSeleccion As DataRow In dtMedicionFisica.Rows
                    rowSeleccion("Seleccion") = True
                Next
            Else
                chkSeleccion.Checked = False
                For Each rowSeleccion As DataRow In dtMedicionFisica.Rows
                    rowSeleccion("Seleccion") = False
                Next
            End If
        End If
        RepeticionActivo = False
    End Sub

    Private Function ExisteSeleccion() As Boolean
        Dim Resultado As Boolean = False
        For Each row As DataRow In dtMedicionFisica.Rows
            If CType(row("Seleccion"), Boolean) Then
                Resultado = True
                Exit For
            End If
        Next
        Return Resultado
    End Function

    Private Sub ModificarSeleccion(ByVal Index As Integer)
        If CType(dgvMedicionFisica.Item("Seleccion", Index).Value, Boolean) Then
            dgvMedicionFisica.Item("Seleccion", Index).Value = False
        Else
            dgvMedicionFisica.Item("Seleccion", Index).Value = True
        End If

        ValidarTotalSeleccion()
    End Sub

    Private Sub ValidarTotalSeleccion()

        Dim NumVerdadero As Integer = 0

        Dim NumColumnas As Integer = dtMedicionFisica.Rows.Count

        For Each row As DataRow In dtMedicionFisica.Rows

            If CType(row("Seleccion"), Boolean) = True Then
                NumVerdadero = NumVerdadero + 1
            End If
        Next

        If (NumVerdadero = NumColumnas) Then
            chkSeleccion.Checked = True
        Else
            chkSeleccion.Checked = False
        End If

    End Sub

    Private Sub HabilitarAceptar()
        If ExisteSeleccion() And txtNominaInicial.Text <> "" Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    Private Sub Limpiar()
        'txtNominaInicial.Clear()
        'If cboEmpleadoInicial.Items.Count > 0 Then
        '    cboEmpleadoInicial.SelectedIndex = 0
        'End If
        btnAceptar.Enabled = False
        chkSeleccion.Checked = False
        ActiveControl = cboEmpleadoInicial
    End Sub


    ' Inicializa las variables a utilizar
    Private Sub frmCancelacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarDatosIniciales()
        Limpiar()
        CargarDatos()
        FormatoDataGridViewMedicionFisica()
    End Sub
    
    Private Sub cboEmpleadoInicial_Leave(sender As Object, e As EventArgs) Handles cboEmpleadoInicial.Leave
        If Not (cboEmpleadoInicial.SelectedValue Is Nothing) Then
            txtNominaInicial.Text = CType(cboEmpleadoInicial.SelectedValue, String)
        Else
            txtNominaInicial.Text = ""
        End If
        HabilitarAceptar()
    End Sub

    Private Sub cboEmpleadoInicial_KeyDown(sender As Object, e As KeyEventArgs) Handles cboEmpleadoInicial.KeyDown, dtpFHoraInicial.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub txtNominaInicial_Leave(sender As Object, e As EventArgs) Handles txtNominaInicial.Leave
        If txtNominaInicial.Text <> "" Then
            Dim Nomina As Integer
            Nomina = CType(txtNominaInicial.Text, Integer)
            cboEmpleadoInicial.SelectedValue = Nomina
            cboEmpleadoInicial.SelectedValue = Nomina
            If cboEmpleadoInicial.SelectedValue Is Nothing Then
                cboEmpleadoInicial.SelectedIndex = -1
                cboEmpleadoInicial.SelectedIndex = -1
                txtNominaInicial.Text = ""
            End If
        End If
        HabilitarAceptar()
    End Sub

    Private Sub txtNominaInicial_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNominaInicial.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub chkSeleccion_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccion.CheckedChanged
        If chkSeleccion.Focused And dgvMedicionFisica.RowCount > 0 Then
            SeleccionarTodos()
            HabilitarAceptar()
        ElseIf chkSeleccion.Focused And dgvMedicionFisica.RowCount = 0 Then
            chkSeleccion.Checked = False
            HabilitarAceptar()
        End If
    End Sub

    Private Sub dgvMedicionFisica_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMedicionFisica.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)

        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewCheckBoxColumn AndAlso
           e.RowIndex >= 0 Then
            ModificarSeleccion(e.RowIndex)
            HabilitarAceptar()
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Cursor = Cursors.WaitCursor
        Try

            Dim Result As DialogResult
            Dim Mensajes As Mensaje

            Mensajes = New Mensaje(4)
            Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (Result = DialogResult.Yes) Then
                For Each row As DataRow In dtMedicionFisica.Rows

                    If CType(row("Seleccion"), Boolean) Then

                        'Crea un registro en medicion fisica
                        Dim oMedicionFisica As New PortatilClasses.CatalogosPortatil.cMedicionFisica(1, 0, "", _UsuarioAlta, CType(row("AlmacenGas"), Integer), 0, 0, 0, 0, CType(cboEmpleadoInicial.SelectedValue, Integer), _FInicialActa, "ACTIVO", "VERIFICADA")
                        oMedicionFisica.RegistrarModificarEliminar()

                        'No se hace medicion izquierda y derecha
                        Dim oActaCierre As New Registra.cActaCierreMedicion(0, _Año, _Mes, _Corporativo, _Sucursal, _Folio, oMedicionFisica.MedicionFisica, _TipoServicio, 0, 0)
                        oActaCierre = Nothing

                        'Almacena las mediciones del tanque
                        Dim oMedicionFisicaTanque As PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque
                        oMedicionFisicaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaTanque(1, oMedicionFisica.MedicionFisica, "UNICA", CType(row("TemperaturaTanque"), Decimal), CType(row("PresionTanque"), Decimal), CType(row("PorcentajeTanque"), Decimal), 0, 0, 0, CType(cboEmpleadoInicial.SelectedValue, Integer), CType(dtpFHoraInicial.Value, String), CType(row("Tanque"), Integer), 0, 0, "")
                        oMedicionFisicaTanque.RegistrarModificarEliminar()

                        'Actualiza el litraje en el registro de medicionfisica
                        Dim oMedicionFisicaAutomaticaTanque As PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto
                        oMedicionFisicaAutomaticaTanque = New PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto(2, 0, 0, oMedicionFisica.MedicionFisica, 0)
                        oMedicionFisicaAutomaticaTanque.ActualizarMedicionFisica()

                        Dim oMedicionFisicaCorte As New PortatilClasses.Consulta.cMedicionFisicaCorte(5, oMedicionFisica.MedicionFisica)
                        oMedicionFisicaCorte.RealizarMedicionFisicaCorte()

                    End If
                Next
                Limpiar()
                CargarDatos()
                FormatoDataGridViewMedicionFisica()
            End If

        Catch ex As Exception
            Throw ex
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(28)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub


End Class

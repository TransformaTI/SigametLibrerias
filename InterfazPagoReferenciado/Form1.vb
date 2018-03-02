Public Class frmInterface
    Inherits System.Windows.Forms.Form
#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lblOperacion As System.Windows.Forms.Label
    Friend WithEvents imgIconos As System.Windows.Forms.ImageList
    Friend WithEvents TBInterprete As System.Windows.Forms.ToolBar
    Friend WithEvents TBBInterpretar As System.Windows.Forms.ToolBarButton
    Friend WithEvents TBBSalir As System.Windows.Forms.ToolBarButton
    Friend WithEvents tabDetalle As System.Windows.Forms.TabControl
    Friend WithEvents tbpDetalle As System.Windows.Forms.TabPage
    Friend WithEvents grdDetalle As System.Windows.Forms.DataGrid
    Friend WithEvents dtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFInicial As System.Windows.Forms.Label
    Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFFin As System.Windows.Forms.Label
    Friend WithEvents lstArchivos As System.Windows.Forms.ListBox
    Friend WithEvents TBBActualizar As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmInterface))
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.lblOperacion = New System.Windows.Forms.Label()
        Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
        Me.TBInterprete = New System.Windows.Forms.ToolBar()
        Me.TBBInterpretar = New System.Windows.Forms.ToolBarButton()
        Me.TBBSalir = New System.Windows.Forms.ToolBarButton()
        Me.TBBActualizar = New System.Windows.Forms.ToolBarButton()
        Me.tabDetalle = New System.Windows.Forms.TabControl()
        Me.tbpDetalle = New System.Windows.Forms.TabPage()
        Me.grdDetalle = New System.Windows.Forms.DataGrid()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblFInicial = New System.Windows.Forms.Label()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.lblFFin = New System.Windows.Forms.Label()
        Me.lstArchivos = New System.Windows.Forms.ListBox()
        Me.tabDetalle.SuspendLayout()
        Me.tbpDetalle.SuspendLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboTipo
        '
        Me.cboTipo.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.Location = New System.Drawing.Point(584, 16)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(104, 21)
        Me.cboTipo.TabIndex = 8
        '
        'lblOperacion
        '
        Me.lblOperacion.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblOperacion.Location = New System.Drawing.Point(488, 16)
        Me.lblOperacion.Name = "lblOperacion"
        Me.lblOperacion.Size = New System.Drawing.Size(88, 17)
        Me.lblOperacion.TabIndex = 9
        Me.lblOperacion.Text = "Tipo de archivo:"
        Me.lblOperacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imgIconos
        '
        Me.imgIconos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgIconos.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
        '
        'TBInterprete
        '
        Me.TBInterprete.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TBBInterpretar, Me.TBBSalir, Me.TBBActualizar})
        Me.TBInterprete.ButtonSize = New System.Drawing.Size(70, 40)
        Me.TBInterprete.DropDownArrows = True
        Me.TBInterprete.ImageList = Me.imgIconos
        Me.TBInterprete.Name = "TBInterprete"
        Me.TBInterprete.ShowToolTips = True
        Me.TBInterprete.Size = New System.Drawing.Size(728, 43)
        Me.TBInterprete.TabIndex = 5
        '
        'TBBInterpretar
        '
        Me.TBBInterpretar.ImageIndex = 0
        Me.TBBInterpretar.Text = "Procesar"
        Me.TBBInterpretar.ToolTipText = "Procesar Archivo"
        '
        'TBBSalir
        '
        Me.TBBSalir.ImageIndex = 2
        Me.TBBSalir.Text = "Actualizar"
        Me.TBBSalir.ToolTipText = "Actualizar"
        '
        'TBBActualizar
        '
        Me.TBBActualizar.ImageIndex = 1
        Me.TBBActualizar.Text = "Cerrar"
        Me.TBBActualizar.ToolTipText = "Cerrar"
        '
        'tabDetalle
        '
        Me.tabDetalle.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.tabDetalle.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbpDetalle})
        Me.tabDetalle.Location = New System.Drawing.Point(176, 56)
        Me.tabDetalle.Name = "tabDetalle"
        Me.tabDetalle.SelectedIndex = 0
        Me.tabDetalle.Size = New System.Drawing.Size(552, 352)
        Me.tabDetalle.TabIndex = 7
        '
        'tbpDetalle
        '
        Me.tbpDetalle.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdDetalle, Me.dtpInicio, Me.lblFInicial, Me.dtpFin, Me.lblFFin})
        Me.tbpDetalle.Location = New System.Drawing.Point(4, 22)
        Me.tbpDetalle.Name = "tbpDetalle"
        Me.tbpDetalle.Size = New System.Drawing.Size(544, 326)
        Me.tbpDetalle.TabIndex = 0
        Me.tbpDetalle.Text = "Detalle"
        '
        'grdDetalle
        '
        Me.grdDetalle.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdDetalle.CaptionBackColor = System.Drawing.SystemColors.Highlight
        Me.grdDetalle.CaptionText = "Detalle de pagos"
        Me.grdDetalle.DataMember = ""
        Me.grdDetalle.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdDetalle.Location = New System.Drawing.Point(8, 48)
        Me.grdDetalle.Name = "grdDetalle"
        Me.grdDetalle.ReadOnly = True
        Me.grdDetalle.Size = New System.Drawing.Size(536, 272)
        Me.grdDetalle.TabIndex = 0
        '
        'dtpInicio
        '
        Me.dtpInicio.CalendarMonthBackground = System.Drawing.SystemColors.HighlightText
        Me.dtpInicio.Location = New System.Drawing.Point(8, 24)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.Size = New System.Drawing.Size(160, 20)
        Me.dtpInicio.TabIndex = 5
        '
        'lblFInicial
        '
        Me.lblFInicial.Location = New System.Drawing.Point(8, 8)
        Me.lblFInicial.Name = "lblFInicial"
        Me.lblFInicial.Size = New System.Drawing.Size(100, 16)
        Me.lblFInicial.TabIndex = 7
        Me.lblFInicial.Text = "Fecha inicial"
        '
        'dtpFin
        '
        Me.dtpFin.Location = New System.Drawing.Point(184, 24)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(160, 20)
        Me.dtpFin.TabIndex = 6
        '
        'lblFFin
        '
        Me.lblFFin.Location = New System.Drawing.Point(184, 8)
        Me.lblFFin.Name = "lblFFin"
        Me.lblFFin.Size = New System.Drawing.Size(100, 16)
        Me.lblFFin.TabIndex = 8
        Me.lblFFin.Text = "Fecha final"
        '
        'lstArchivos
        '
        Me.lstArchivos.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.lstArchivos.BackColor = System.Drawing.SystemColors.Info
        Me.lstArchivos.Location = New System.Drawing.Point(8, 56)
        Me.lstArchivos.Name = "lstArchivos"
        Me.lstArchivos.Size = New System.Drawing.Size(160, 355)
        Me.lstArchivos.TabIndex = 6
        '
        'frmInterface
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(728, 453)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblOperacion, Me.tabDetalle, Me.lstArchivos, Me.cboTipo, Me.TBInterprete})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInterface"
        Me.Text = "Procesar depósitos bancarios"
        Me.tabDetalle.ResumeLayout(False)
        Me.tbpDetalle.ResumeLayout(False)
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Structure Registro
        Public Numero As String
        Public Fecha As String
        Public Tipo As String
        Public Codigo As String
        Public CodigoA As String
        Public Sucursal As String
        Public Referencia As String
        Public Descripcion As String
        Public Importe As String
        Public Cuenta As String
        Public ArchivoOrigen As String
    End Structure

    Dim Reg As Registro
    Public Conexion As SqlClient.SqlConnection '= New System.Data.SqlClient.SqlConnection("Data Source = (Local); Integrated Security = SSPI; Initial Catalog = Master; Connect TimeOut = 300")
    Public CnnValidar As SqlClient.SqlConnection '= New System.Data.SqlClient.SqlConnection("Data Source = (Local); Integrated Security = SSPI; Initial Catalog = Master; Connect TimeOut = 300")

    Private Sub TBInterprete_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TBInterprete.ButtonClick
        Dim Archivo As String
        Dim Cuenta As String
        Dim Banco As Integer

        If TBInterprete.Buttons.IndexOf(e.Button) = 0 Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            If lstArchivos.SelectedItems.Count <> 0 Then
                If cboTipo.Text = "Sin procesar" Then
                    Archivo = NombreArchivo(lstArchivos.SelectedItem, "*.txt")
                    Cuenta = ObtenerCuenta(Archivo)
                    Banco = ObtenerBanco(Cuenta)
                    If Banco = 0 Then
                        Banco = ObtenerBanco(Microsoft.VisualBasic.Right(Cuenta, 5))
                    End If
                    If Banco = 1 Then
                        EsBanamex()
                    ElseIf Banco = 31 Then
                        EsBancomer(Archivo, Cuenta)
                        ListarArchivos("*.txt")
                    ElseIf Banco = 28 Then
                        EsHSBC(Archivo, Cuenta)
                        ListarArchivos("*.txt")
                    ElseIf Banco = 0 Then
                        MsgBox("El nombre de archivo que pretende importar no hace relación a ni una cuenta bancaria de Banamex, BBVA o HSBC por favor verifique", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Cuenta bancaria sin vínculo")
                        Me.Cursor = System.Windows.Forms.Cursors.Default
                    Else
                        MsgBox("El nombre de archivo que pretende importar no hace relación a ni una cuenta bancaria de Banamex, BBVA o HSBC por favor verifique", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Cuenta bancaria sin vínculo")
                        Me.Cursor = System.Windows.Forms.Cursors.Default
                    End If
                End If

                If cboTipo.Text = "Procesados" Then
                    procesados()
                End If

            Else
                MsgBox("Seleccione un archivo de la lista por favor.", MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, "No hay archivo seleccionado")
            End If
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If


        If TBInterprete.Buttons.IndexOf(e.Button) = 1 Then
            If cboTipo.Text = "Sin procesar" Then
                ListarArchivos("*.Txt")
                lstArchivos.Enabled = True
                dtpInicio.Enabled = False
                dtpFin.Enabled = False
            End If
            If cboTipo.Text = "Procesados" Then
                TBInterprete.Buttons(0).Enabled = False
                dtpInicio.Enabled = True
                dtpFin.Enabled = True
                grdDetalle.DataSource = Nothing
                grdDetalle.DataMember = Nothing
                If dtpInicio.Value <= dtpFin.Value Then
                    Consultar(dtpInicio.Text, dtpFin.Text)
                Else
                    MsgBox("La fecha inicial debe ser menor o igual que la final", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Rango erroneo")
                    Consultar(dtpFin.Text, dtpInicio.Text)
                End If
            Else
                TBInterprete.Buttons(0).Enabled = True
                grdDetalle.DataSource = Nothing
                grdDetalle.DataMember = Nothing
            End If
        End If

        If TBInterprete.Buttons.IndexOf(e.Button) = 2 Then
            Me.Close()
        End If

    End Sub

    Public Function ListarArchivos(ByVal Extencion As String)
        'Autor ITL 22-12-2005
        Dim Ruta As String
        Dim Nombre As String
        'Obtener la ruta a partir de la cual se obtendrán las interfaces bancarias
        Dim Cny As SqlClient.SqlConnection = Conexion
        If Cny.State = ConnectionState.Closed Then
            Cny.Open()
        End If
        Dim Cmd As SqlClient.SqlCommand = Cny.CreateCommand()
        Cmd.CommandText = "Select Valor From Parametro Where Modulo=4 And Parametro='RutaInterfaces'"
        Cmd.CommandTimeout = 300
        Dim Drd As SqlClient.SqlDataReader = Cmd.ExecuteReader
        Drd.Read()
        Ruta = Drd.GetString(0)
        If Cny.State = ConnectionState.Open Then
            Cny.Close()
            Drd.Close()
        End If

        'Comienza el rellenado del ListBox
        Nombre = Dir(Ruta & Extencion, vbNormal)
        lstArchivos.Items.Clear()
        Do While Nombre <> ""
            If (GetAttr(Ruta & Nombre) And vbNormal) = vbNormal Then
                lstArchivos.Items.Add(System.IO.Path.GetFileNameWithoutExtension(Nombre))
            End If
            Nombre = Dir()
        Loop
    End Function

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        If cboTipo.Text = "Sin procesar" Then
            ListarArchivos("*.Txt")
            lstArchivos.Enabled = True
            dtpInicio.Enabled = False
            dtpFin.Enabled = False
        End If
        If cboTipo.Text = "Procesados" Then
            TBInterprete.Buttons(0).Enabled = False
            TBInterprete.Buttons(1).Enabled = False
            dtpInicio.Enabled = True
            dtpFin.Enabled = True
            grdDetalle.DataSource = Nothing
            grdDetalle.DataMember = Nothing
            If dtpInicio.Value <= dtpFin.Value Then
                Consultar(dtpInicio.Text, dtpFin.Text)
            Else
                MsgBox("La fecha inicial debe ser menor o igual que la final", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Rango erroneo")
                Consultar(dtpFin.Text, dtpInicio.Text)
            End If
        Else
            TBInterprete.Buttons(0).Enabled = True
            TBInterprete.Buttons(1).Enabled = True
            grdDetalle.DataSource = Nothing
            grdDetalle.DataMember = Nothing
        End If
    End Sub

    Function NombreArchivo(ByVal Archivo As String, ByVal Extension As String) As String
        Dim Ruta As String
        'Obtener la ruta a partir de la cual se obtendrán las interfaces bancaria
        Dim Cnn As SqlClient.SqlConnection = Conexion
        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If
        Dim Cmd As SqlClient.SqlCommand = Cnn.CreateCommand()
        Cmd.CommandText = "Select Valor From Parametro Where Modulo=4 And Parametro='RutaInterfaces'"
        Cmd.CommandTimeout = 300
        Dim Drd As SqlClient.SqlDataReader = Cmd.ExecuteReader
        Drd.Read()
        Ruta = Drd.GetString(0)
        If Cnn.State = ConnectionState.Open Then
            Cnn.Close()
            Drd.Close()
        End If
        If Microsoft.VisualBasic.Left(Extension, 1) <> "*" Then
            NombreArchivo = Ruta & Archivo & Extension
        Else
            NombreArchivo = Ruta & Archivo & Microsoft.VisualBasic.Right(Extension, 4)
        End If
    End Function

    Function SepararColumnas(ByVal Linea As String, ByVal Indice As Integer, ByVal Separador As Integer) As Registro
        'Autor ITL 21-12-2005 Separa las columnas correspondientes de las interfaces
        Dim RegVacio As Registro = Nothing
        Dim i As Integer
        Dim Max As Integer = Len(Linea)
        Dim Comas As Integer = 0
        Reg = RegVacio
        If Indice > 6 Then
            For i = 0 To Max - 1
                If Linea.Chars(i) <> Chr(Separador) Then
                    If Comas = 0 Then
                        Reg.Numero = Reg.Numero & Linea.Chars(i)
                    End If
                    If Comas = 1 Then
                        Reg.Fecha = Reg.Fecha & Linea.Chars(i)
                    End If
                    If Comas = 2 Then
                        Reg.Tipo = Reg.Tipo & Linea.Chars(i)
                    End If
                    If Comas = 3 Then
                        Reg.Codigo = Reg.Codigo & Linea.Chars(i)
                    End If
                    If Comas = 4 Then
                        Reg.CodigoA = Reg.CodigoA & Linea.Chars(i)
                    End If
                    If Comas = 5 Then
                        Reg.Sucursal = Reg.Sucursal & Linea.Chars(i)
                    End If
                    If Comas = 6 Then
                        Reg.Referencia = Reg.Referencia & Linea.Chars(i)
                    End If
                    If Comas = 7 Then
                        Reg.Descripcion = Reg.Descripcion & Linea.Chars(i)
                    End If
                    If Comas = 8 Then
                        Reg.Importe = Reg.Importe & Linea.Chars(i)
                    End If
                    If Comas = 9 Then
                        Reg.Cuenta = Reg.Cuenta & Linea.Chars(i)
                    End If
                    If Comas = 10 Then
                        Reg.ArchivoOrigen = Reg.ArchivoOrigen & Linea.Chars(i)
                    End If
                Else
                    Comas += 1
                End If

            Next
        End If
        If Len(Reg.Referencia) = 0 Then
            Reg.Referencia = 0
        End If
        If Len(Reg.Descripcion) = 0 Then
            Reg.Descripcion = ""
        End If
        If Len(Reg.Importe) = 0 Then
            Reg.Importe = "0"
        End If
        If Len(Reg.Cuenta) = 0 Then
            Reg.Cuenta = ""
        End If
        SepararColumnas = Reg
    End Function

    Function ObtenerCuenta(ByVal Path As String) As String
        'Autor ITL 21-12-2005 Extrae el número de cuenta a partir del nombre de archivo
        Dim i As Integer
        Dim Agregar As Boolean = False
        Dim Canonica As String
        Dim Cuenta As String
        Cuenta = ""
        Canonica = System.IO.Path.GetFileNameWithoutExtension(Path)
        For i = 0 To Len(Canonica) - 1
            If Canonica.Chars(i) = "-" Then
                Agregar = True
            End If
            If Agregar = True And Canonica.Chars(i) <> "-" Then
                Cuenta = Cuenta & Canonica.Chars(i)
            End If
        Next
        ObtenerCuenta = Cuenta
    End Function

    Function ValidarArchivo(ByVal Nombre As String) As Integer
        'Autor ITL 22-12-2005
        Dim Total As Integer
        'Obtener la ruta a partir de la cual se obtendrán las interfaces bancarias
        Dim Cnn As SqlClient.SqlConnection = Conexion
        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If
        Dim Cmd As SqlClient.SqlCommand = Cnn.CreateCommand()
        Cmd.CommandTimeout = 300
        Cmd.CommandText = "Select IsNULL(Count(*),0) From PagoReferenciado Where ArchivoOrigen = '" & Nombre & "'"
        Dim Drd As SqlClient.SqlDataReader = Cmd.ExecuteReader
        Drd.Read()
        Total = Drd.GetInt32(0)
        If Cnn.State = ConnectionState.Open Then
            Cnn.Close()
            Drd.Close()
        End If
        ValidarArchivo = Total
    End Function

    Function ValidarDatos(ByVal Fecha As Date, ByVal Referenencia As String, ByVal Importe As Double) As Integer
        Dim Registros As Integer
        Dim Cnx As SqlClient.SqlConnection = CnnValidar
        If Cnx.State = ConnectionState.Closed Then
            Cnx.Open()
        End If
        Try
            Dim Cmd As SqlClient.SqlCommand = Cnx.CreateCommand()
            Cmd.CommandText = "Select IsNULL(Count(*),0) From PagoReferenciado Where Fecha = '" & Fecha.Date & "' And Referencia = '" & Referenencia & "' And Importe =" & Importe
            Cmd.CommandTimeout = 300
            Dim Drd As SqlClient.SqlDataReader = Cmd.ExecuteReader()
            Drd.Read()
            Registros = Drd.GetInt32(0)
            If Cnx.State = ConnectionState.Open Then
                Drd.Close()
                Cnx.Close()
            End If
            ValidarDatos = Registros
        Catch ex As System.FormatException When Not IsNumeric(Importe)
            MsgBox("Se encontró inconsistencia en la información favor de reportarlo.", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Error de integridad de datos")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Function ValidarCuenta(ByVal Cuenta As String) As Integer
        Dim Registros As Integer
        Dim Cnn As SqlClient.SqlConnection = Conexion
        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If
        Dim Cmd As SqlClient.SqlCommand = Cnn.CreateCommand()
        Cmd.CommandTimeout = 300
        Cmd.CommandText = "Select IsNULL(Count(*),0) From CuentaBanco Where CuentaBanco = '" & Cuenta & "'"
        Dim Drd As SqlClient.SqlDataReader = Cmd.ExecuteReader()
        Drd.Read()
        Registros = Drd.GetInt32(0)
        If Cnn.State = ConnectionState.Open Then
            Drd.Close()
            Cnn.Close()
        End If
        ValidarCuenta = Registros
    End Function

    Function Deshacer(ByVal NombreArchivo As String)
        Dim Cnn As SqlClient.SqlConnection = Conexion
        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If
        Dim Cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("SP_CyCDeshacerDepositos", Cnn)
        Cmd.CommandTimeout = 300
        Cmd.CommandType = CommandType.StoredProcedure
        Dim prm1 As SqlClient.SqlParameter = Cmd.Parameters.Add("@Archivo", SqlDbType.VarChar, 20)
        Dim drd As SqlClient.SqlDataReader
        prm1.Value = NombreArchivo
        drd = Cmd.ExecuteReader
        If Cnn.State = ConnectionState.Open Then
            drd.Close()
            Cnn.Close()
        End If
    End Function

    Private Sub lstArchivos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstArchivos.DoubleClick
        Dim Archivo As String
        Dim Cuenta As String
        Dim Banco As Integer

        If lstArchivos.SelectedItems.Count <> 0 Then
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            If cboTipo.Text = "Sin procesar" Then
                Archivo = NombreArchivo(lstArchivos.SelectedItem, "*.txt")
                Cuenta = ObtenerCuenta(Archivo)
                Banco = ObtenerBanco(Cuenta)
                If Banco = 0 Then
                    Banco = ObtenerBanco(Microsoft.VisualBasic.Right(Cuenta, 5))
                End If
                If Banco = 1 Then
                    EsBanamex()
                ElseIf Banco = 31 Then
                    EsBancomer(Archivo, Cuenta)
                    ListarArchivos("*.txt")
                ElseIf Banco = 28 Then
                    EsHSBC(Archivo, Cuenta)
                    ListarArchivos("*.txt")
                ElseIf Banco = 0 Then
                    MsgBox("El nombre de archivo que pretende importar no hace relación a ni una cuenta bancaria de Banamex, BBVA o HSBC por favor verifique", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Cuenta bancaria sin vínculo")
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                Else
                    MsgBox("El nombre de archivo que pretende importar no hace relación a ni una cuenta bancaria de Banamex, BBVA o HSBC por favor verifique", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Cuenta bancaria sin vínculo")
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                End If
            End If

            If cboTipo.Text = "Procesados" Then
                procesados()
            End If

        Else
            MsgBox("Seleccione un archivo de la lista por favor.", MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, "No hay archivo seleccionado")
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Sub EsBanamex()
        Dim Columnas As Registro
        Dim Linea As String
        Dim NumLinea As Integer
        Dim Archivo As String
        Dim NombreCompleto As String
        Dim ErrorImporte As Boolean = False

        If cboTipo.Text = "Sin procesar" And lstArchivos.Items.Count > 0 Then
            Archivo = lstArchivos.Items.Item(lstArchivos.SelectedIndex)
            If ValidarArchivo(lstArchivos.SelectedItem) = 0 Then
                NombreCompleto = NombreArchivo(Archivo, "*.txt")
                NumLinea = 1

                If ValidarCuenta(ObtenerCuenta(NombreCompleto)) = 0 Then
                    If ValidarCuenta(Microsoft.VisualBasic.Right(ObtenerCuenta(NombreCompleto), 5)) = 0 Then
                        MsgBox("El nombre de archivo que pretende importar no hace relación a ni una cuenta bancaria por favor verifique", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Cuenta bancaria sin vínculo")
                        GoTo Salir
                    End If
                End If

                Dim Cnn1 As SqlClient.SqlConnection = Conexion
                If Cnn1.State = ConnectionState.Closed Then
                    Cnn1.Open()
                End If
                Dim Cmd1 As SqlClient.SqlCommand = New SqlClient.SqlCommand("SP_InterpretarInterfaz", Cnn1)
                Cmd1.CommandTimeout = 300
                Cmd1.CommandType = CommandType.StoredProcedure
                Dim prm1 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@Numero", SqlDbType.SmallInt, 2)
                Dim prm2 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@Fecha", SqlDbType.DateTime, 8)
                Dim prm3 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@Tipo", SqlDbType.Char, 1)
                Dim prm4 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@Codigo", SqlDbType.Char, 5)
                Dim prm5 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@Sucursal", SqlDbType.SmallInt, 2)
                Dim prm6 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@Referencia", SqlDbType.BigInt, 8)
                Dim prm7 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@Descripcion", SqlDbType.VarChar, 40)
                Dim prm8 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@Importe", SqlDbType.Money, 8)
                Dim prm9 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@Cuenta", SqlDbType.VarChar, 20)
                Dim prm10 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@ArchivoOrigen", SqlDbType.VarChar, 20)
                Dim drd1 As SqlClient.SqlDataReader = Nothing
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                Linea = ""
                FileOpen(1, NombreCompleto, OpenMode.Input)
                Do While Not EOF(1)
                    Linea = LineInput(1)
                    Columnas = SepararColumnas(Linea, NumLinea, 124)
                    If NumLinea > 6 Then
                        Try
                            prm1.Value = Columnas.Numero
                            prm2.Value = Columnas.Fecha
                            prm3.Value = Columnas.Tipo
                            prm4.Value = Columnas.Codigo & " " & Columnas.CodigoA
                            prm5.Value = Columnas.Sucursal
                            prm6.Value = Columnas.Referencia
                            prm7.Value = Columnas.Descripcion
                            prm8.Value = Columnas.Importe
                            prm9.Value = ObtenerCuenta(NombreCompleto)
                            prm10.Value = lstArchivos.SelectedItem
                            Try
                                If ValidarDatos(Columnas.Fecha, Columnas.Referencia, Columnas.Importe) = 0 Then
                                    drd1 = Cmd1.ExecuteReader
                                Else
                                    ErrorImporte = True
                                    MsgBox("El archivo no puede ser procesado ya que generaría duplicidad", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Archivo duplicado")
                                    Exit Do
                                End If
                            Catch ex As System.InvalidCastException When Not IsNumeric(Columnas.Importe)
                                Deshacer(lstArchivos.SelectedItem)
                                ErrorImporte = True
                                MsgBox("Se encontró inconsistencia en la información favor de reportarlo.", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Error de integridad de datos")
                                Exit Do
                            Catch ex As Exception
                                MessageBox.Show(ex.Message)
                            End Try
                        Catch ex As System.FormatException When Not IsNumeric(Columnas.Importe)
                            Deshacer(lstArchivos.SelectedItem)
                            ErrorImporte = True
                            MsgBox("Se encontró inconsistencia en la información favor de reportarlo.", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Error de integridad de datos")
                            Exit Do
                        End Try
                        drd1.Close()
                    End If
                    NumLinea += 1
                Loop
                FileClose(1)
                If Cnn1.State = ConnectionState.Open Then
                    Cnn1.Close()
                End If
                Me.Cursor = System.Windows.Forms.Cursors.Default
                If ErrorImporte = False Then
                    'ModificarStatus(lstArchivos.SelectedItem)
                    System.IO.File.Move(NombreCompleto, System.IO.Path.GetDirectoryName(NombreCompleto) & "\" & System.IO.Path.GetFileNameWithoutExtension(NombreCompleto) & ".pro")
                    MsgBox("Archivo procesado exitosamente", MsgBoxStyle.OKOnly Or MsgBoxStyle.Information, "Depósitos bancarios")
                End If
                If ErrorImporte = True Then
                    System.IO.File.Move(NombreCompleto, System.IO.Path.GetDirectoryName(NombreCompleto) & "\" & System.IO.Path.GetFileNameWithoutExtension(NombreCompleto) & ".error")
                End If
                ListarArchivos("*.txt")
            Else
                MsgBox("El archivo no puede ser procesado ya que generaría duplicidad", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Archivo duplicado")
            End If
        End If

        'Aqui debería estar el código del combo en procesado

Salir:
        If cboTipo.Text <> "Procesados" Then
            ListarArchivos("*.txt")
        End If

    End Sub

    Sub procesados()
        '        If cboTipo.Text = "Procesados" Then
        Dim NombreArchivo As String = lstArchivos.SelectedItem
        Dim Cnn As SqlClient.SqlConnection = Conexion
        Dim Cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("Select Consecutivo,Numero,Fecha,Tipo,Codigo,Sucursal,Referencia,Descripcion,Importe,Cuenta,Status,Observaciones,ClaveMovimientoCaja,AñoCobro,Cobro from PagoReferenciado where ArchivoOrigen='" & NombreArchivo & "'", Cnn)
        Cmd.CommandTimeout = 300
        Dim Dap As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter()
        Dap.SelectCommand = Cmd
        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If
        Dim Das As New DataSet()
        Dap.Fill(Das, "Detalles")
        If Cnn.State = ConnectionState.Open Then
            Cnn.Close()
        End If
        grdDetalle.DataSource = Das
        grdDetalle.DataMember = "Detalles"
        '       End If

    End Sub


    Private Sub dtpInicio_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpInicio.ValueChanged
        If dtpInicio.Value <= dtpFin.Value Then
            Consultar(dtpInicio.Text, dtpFin.Text)
        Else
            MsgBox("La fecha inicial debe ser menor o igual que la final", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Rango erroneo")
            Consultar(dtpFin.Text, dtpInicio.Text)
        End If

    End Sub

    Private Sub dtpFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFin.ValueChanged
        If dtpInicio.Value <= dtpFin.Value Then
            Consultar(dtpInicio.Text, dtpFin.Text)
        Else
            MsgBox("La fecha inicial debe ser menor o igual que la final", MsgBoxStyle.OKOnly Or MsgBoxStyle.Critical, "Rango erroneo")
            Consultar(dtpFin.Text, dtpInicio.Text)
        End If
    End Sub

    Function Consultar(ByVal FInicial As Date, ByVal FFinal As Date)
        Dim Cnn As SqlClient.SqlConnection = Conexion
        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If
        Dim Cmd As SqlClient.SqlCommand = Cnn.CreateCommand()
        Cmd.CommandTimeout = 300
        Cmd.CommandText = "Select Distinct(ArchivoOrigen) From PagoReferenciado Where Fecha Between '" & FInicial.Date & "' And '" & FFinal.Date & "'"
        Dim Drd As SqlClient.SqlDataReader = Cmd.ExecuteReader()
        lstArchivos.Items.Clear()
        Do While Drd.Read()
            lstArchivos.Items.Add(Drd.GetString(0))
        Loop
        If Cnn.State = ConnectionState.Open Then
            Drd.Close()
            Cnn.Close()
        End If
    End Function

    Function ModificarStatus(ByVal NombreArchivo As String)
        Dim Cnn1 As SqlClient.SqlConnection = Conexion
        If Cnn1.State = ConnectionState.Closed Then
            Cnn1.Open()
        End If
        Dim Cmd1 As SqlClient.SqlCommand = New SqlClient.SqlCommand("SP_ModificarStatus", Cnn1)
        Cmd1.CommandTimeout = 300
        Cmd1.CommandType = CommandType.StoredProcedure
        Dim prm1 As SqlClient.SqlParameter = Cmd1.Parameters.Add("@NombreArchivo", SqlDbType.VarChar, 20)
        Dim drd1 As SqlClient.SqlDataReader
        prm1.Value = NombreArchivo
        drd1 = Cmd1.ExecuteReader
        If Cnn1.State = ConnectionState.Open Then
            drd1.Close()
            Cnn1.Close()
        End If
    End Function


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboTipo.Items.Add("Sin procesar")
        cboTipo.Items.Add("Procesados")
        cboTipo.Text = "Sin procesar"
        conexionBBVA = Conexion
        conexionHSBC = Conexion
    End Sub

End Class

Imports System.Windows.Forms

Namespace CrearControl

    Public Class ProductoPanel
        Inherits System.Windows.Forms.Panel

#Region " Component Designer generated code "

        Public Sub New(ByVal Container As System.ComponentModel.IContainer)
            MyClass.New()

            'Required for Windows.Forms Class Composition Designer support
            Container.Add(Me)
        End Sub

        Public Sub New()
            MyBase.New()

            'This call is required by the Component Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me.Width = 463
            Me.MaxLength = 10
            'UbicarProducto()
        End Sub

        'Component overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Component Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Component Designer
        'It can be modified using the Component Designer.
        'Do not modify it using the code editor.        
        Private lblProducto1 As System.Windows.Forms.Label
        Public WithEvents txtCantidad1 As SigaMetClasses.Controles.txtNumeroDecimal
        Private lblExistencia As System.Windows.Forms.Label
        Private lblExistenciaTitulo As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

#End Region

        Private _NumProductos As Integer
        Public txtLista As New ArrayList()
        Public pdtoLista As New ArrayList()
        Public lblLista As New ArrayList()
        Public ListaDescripcion As New ArrayList()
        Private _StockCarga As String
        Private _TipoProducto As Integer
        Private _MaxLength As Integer
        Public Indice As Integer
        Public CantidadProductos As Decimal
        Public KilosProductos As Decimal

        Public Event CarmbioTexto()
        Public Event SiguienteControl(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

        Public Property NumProductos() As Integer
            Get
                Return _NumProductos
            End Get
            Set(ByVal Value As Integer)
                _NumProductos = Value
            End Set
        End Property

        Private Property StockCarga() As String
            Get
                Return _StockCarga
            End Get
            Set(ByVal Value As String)
                _StockCarga = Value
            End Set
        End Property

        Private Property TipoProducto() As Integer
            Get
                Return _TipoProducto
            End Get
            Set(ByVal Value As Integer)
                _TipoProducto = Value
            End Set
        End Property

        Public ReadOnly Property IdenProducto(ByVal i As Integer) As Integer
            Get
                Dim Iden As Integer
                If pdtoLista.Count > 0 Then
                    Iden = CType(pdtoLista.Item(i), Integer)
                End If
                Return Iden
            End Get
        End Property

        Public ReadOnly Property DescripcionProducto(ByVal i As Integer) As String
            Get
                Dim Des As String = ""
                If lblLista.Count > 0 Then
                    Des = CType(ListaDescripcion.Item(i), String)
                End If
                Return Des
            End Get
        End Property

        Public Property MaxLength() As Integer
            Get
                Return _MaxLength
            End Get
            Set(ByVal Value As Integer)
                _MaxLength = Value
            End Set
        End Property

        ' Ubica los dos primeros controles dentro del panel
        Public Sub UbicarProducto()
            If Controls.Count < 6 Then
                Me.lblProducto1 = New System.Windows.Forms.Label()
                Me.txtCantidad1 = New SigaMetClasses.Controles.txtNumeroDecimal()
                Me.lblExistencia = New System.Windows.Forms.Label()

                Me.lblProducto1.Location = New System.Drawing.Point(12, 35)
                Me.lblProducto1.Name = "lblProducto1"
                Me.lblProducto1.Size = New System.Drawing.Size(244, 29)
                Me.lblProducto1.TabIndex = 0
                Me.lblProducto1.Text = "label1"
                Me.txtCantidad1.ImeMode = System.Windows.Forms.ImeMode.NoControl
                Me.txtCantidad1.Location = New System.Drawing.Point(261, 35)
                Me.txtCantidad1.Name = "txtCantidad1"
                Me.txtCantidad1.Size = New System.Drawing.Size(61, 20)
                Me.txtCantidad1.TabIndex = 1
                Me.txtCantidad1.Text = "TxtNumeroEntero1"
                Me.txtCantidad1.MaxLength = Me.MaxLength

                Me.lblExistencia.Location = New System.Drawing.Point(320, 35)
                Me.lblExistencia.Name = ""
                Me.lblExistencia.Size = New System.Drawing.Size(61, 29)
                Me.lblExistencia.TabIndex = 0
                Me.lblExistencia.Text = ""
                Me.lblExistencia.AutoSize = False
                Me.lblExistencia.TextAlign = Drawing.ContentAlignment.TopRight

                Controls.Add(txtCantidad1)
                Controls.Add(lblProducto1)
                Controls.Add(lblExistencia)

                Dim lblProducto As Label
                lblProducto = New System.Windows.Forms.Label()
                lblProducto.Location = New System.Drawing.Point(99, 4)
                lblProducto.Name = "lblProducto"
                lblProducto.Size = New System.Drawing.Size(55, 23)
                lblProducto.TabIndex = 0
                lblProducto.Text = "Producto"
                Controls.Add(lblProducto)

                Dim lblProducto2 As Label
                lblProducto2 = New System.Windows.Forms.Label()
                lblProducto2.Location = New System.Drawing.Point(265, 4)
                lblProducto2.Name = "lblProducto1"
                lblProducto2.Size = New System.Drawing.Size(56, 23)
                lblProducto2.TabIndex = 0
                lblProducto2.Text = "Cantidad"
                Controls.Add(lblProducto2)

                'Dim lblProducto3 As Label
                lblExistenciaTitulo = New System.Windows.Forms.Label()
                lblExistenciaTitulo.Location = New System.Drawing.Point(340, 4)
                lblExistenciaTitulo.Name = "lblExistenciaTitulo"
                lblExistenciaTitulo.Size = New System.Drawing.Size(60, 23)
                lblExistenciaTitulo.TabIndex = 0
                lblExistenciaTitulo.Text = ""
                Controls.Add(lblExistenciaTitulo)

                Me.AutoScroll = True
            End If
        End Sub

        ' 
        Public Sub StockMinimo(ByVal AlmacenGas As Integer)
            Dim i As Integer
            Dim oAlmacenGasStock As New PortatilClasses.Catalogo.cAlmacenGasStock(0, AlmacenGas)
            While oAlmacenGasStock.drReader.Read()
                i = 0
                While CType(pdtoLista(i), Integer) <> CType(oAlmacenGasStock.drReader(0), Integer)
                    i = i + 1
                End While
                Dim textBox1 As New SigaMetClasses.Controles.txtNumeroDecimal()
                textBox1 = CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroDecimal)
                Try
                    If CType(oAlmacenGasStock.drReader(1), Integer) > 0 Then
                        textBox1.Text = CType(oAlmacenGasStock.drReader(1), String)
                    Else
                        textBox1.Text = "0"
                    End If
                Catch
                    textBox1.Text = "0"
                End Try
            End While
            oAlmacenGasStock.drReader.Close()
            oAlmacenGasStock.CerrarConexion()
            oAlmacenGasStock = Nothing
        End Sub

        Public Sub CargarExistencias(ByVal AlmacenGas As Integer)
            Dim i As Integer
            Dim Configuracion As Integer
            If TipoProducto = 5 Then  ' Producto PORTATIL
                Configuracion = 0
            End If
            If TipoProducto = 1 Then  ' Producto GAS L.P.
                Configuracion = 3
            End If
            lblExistenciaTitulo.Text = "Existencia"
            Dim oAlmacenGasStock As New PortatilClasses.Catalogo.cAlmacenGasStock(Configuracion, AlmacenGas)
            While oAlmacenGasStock.drReader.Read()
                i = 0
                While CType(pdtoLista(i), Integer) <> CType(oAlmacenGasStock.drReader(0), Integer)
                    i = i + 1
                End While
                Dim label As New System.Windows.Forms.Label()
                label = CType(lblLista.Item(i), System.Windows.Forms.Label)
                label.Text = CType(oAlmacenGasStock.drReader(2), String)
            End While
            oAlmacenGasStock.drReader.Close()
            oAlmacenGasStock.CerrarConexion()
            oAlmacenGasStock = Nothing
        End Sub

        Public Function StockMinimo(ByVal AlmacenGas As Integer, ByVal TipoPdto As Integer) As Boolean
            If StockCarga = "1" Then
                If TipoPdto = 5 Then
                    Dim oAlmacenGasStock As New PortatilClasses.Catalogo.cAlmacenGasStock(0, AlmacenGas)
                    Dim i As Integer
                    While oAlmacenGasStock.drReader.Read()
                        i = 0
                        While (CType(pdtoLista(i), Integer) <> CType(oAlmacenGasStock.drReader(0), Integer)) Or (pdtoLista(i) Is Nothing)
                            i = i + 1
                        End While
                        If (CType(pdtoLista(i), Integer) = CType(oAlmacenGasStock.drReader(0), Integer)) Then
                            Dim textBox1 As New SigaMetClasses.Controles.txtNumeroDecimal()
                            textBox1 = CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroDecimal)
                            If textBox1.Text <> "" Then
                                If CType(textBox1.Text, Integer) > CType(oAlmacenGasStock.drReader(1), Integer) Then
                                    Return False
                                End If
                            End If
                        End If
                    End While
                    oAlmacenGasStock.drReader.Close()
                    oAlmacenGasStock.CerrarConexion()
                    oAlmacenGasStock = Nothing
                Else
                    Dim oAlmacenGasStock As New PortatilClasses.Catalogo.cAlmacenGasStock(1, AlmacenGas)
                    If txtCantidad1.Text <> "" And oAlmacenGasStock.drReader.Read() Then
                        If CType(txtCantidad1.Text, Integer) > CType(oAlmacenGasStock.drReader(1), Integer) Then
                            Return False
                        End If
                    End If
                    oAlmacenGasStock.drReader.Close()
                    oAlmacenGasStock.CerrarConexion()
                    oAlmacenGasStock = Nothing
                End If
            End If
            Return True
        End Function

        Private Sub AddControls(ByVal Descripcion As String, ByVal Valor As Decimal, ByVal ylbl As Integer, _
        ByVal ytxt As Integer, ByVal StockCarga As String)
            Dim textBox1 As New SigaMetClasses.Controles.txtNumeroDecimal()
            Dim label1 As New Label()
            Dim label2 As New Label()
            label1.Text = Descripcion
            label1.Location = New System.Drawing.Point(lblProducto1.Location.X, ylbl)
            label1.Size = lblProducto1.Size

            label2.Text = ""
            label2.Location = New System.Drawing.Point(lblExistencia.Location.X, ylbl)
            label2.AutoSize = False
            label2.Size = lblExistencia.Size
            label2.TextAlign = Drawing.ContentAlignment.TopRight
            textBox1.Text = ""
            textBox1.Tag = Valor
            textBox1.Location = New System.Drawing.Point(txtCantidad1.Location.X, ytxt)
            textBox1.Size = txtCantidad1.Size
            textBox1.TabIndex = NumProductos + 1
            textBox1.AcceptsReturn = txtCantidad1.AcceptsReturn
            If StockCarga = "1" Then   'Respecta la carga asignada por el sotock
                textBox1.ReadOnly = True
            Else
                textBox1.ReadOnly = False
            End If
            AddHandler textBox1.KeyDown, AddressOf txtCantidad1_KeyDown
            AddHandler textBox1.TextChanged, AddressOf txtCantidad1_TextChanged
            AddHandler textBox1.KeyPress, AddressOf txtCantidad1_KeyPress
            textBox1.MaxLength = Me.MaxLength
            txtLista.Add(textBox1)
            lblLista.Add(label2)
            Controls.Add(textBox1)
            Controls.Add(label1)
            Controls.Add(label2)
        End Sub

        Private Sub InicializarComponentes(ByVal Producto As Integer, ByVal Descripcion As String, _
        ByVal Valor As Decimal)
            If NumProductos = 0 Then
                lblProducto1.Text = Descripcion
                txtCantidad1.Text = ""
                txtCantidad1.Tag = Valor
                If StockCarga = "1" Then  'Respecta la carga asignada por el sotock
                    txtCantidad1.ReadOnly = True
                Else
                    txtCantidad1.ReadOnly = False
                End If
                txtLista.Add(txtCantidad1)
                lblLista.Add(lblExistencia)
            Else
                Dim y As Integer
                y = (NumProductos - 1) * lblProducto1.Size.Height + 28
                AddControls(Descripcion, Valor, lblProducto1.Location.Y + y, txtCantidad1.Location.Y + y, StockCarga)
            End If
            pdtoLista.Add(Producto)
            ListaDescripcion.Add(Descripcion)
            NumProductos = NumProductos + 1
        End Sub

        Public Sub SoloLectura(ByVal AlmacenGas As Integer)
            Dim oAlmacenGasStock As New PortatilClasses.Catalogo.cAlmacenGasStock(0, AlmacenGas)
            Dim textBox1 As New SigaMetClasses.Controles.txtNumeroDecimal()
            Dim i As Integer
            For i = 0 To txtLista.Count() - 1
                textBox1 = CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroDecimal)
                textBox1.ReadOnly = True
            Next
            While oAlmacenGasStock.drReader.Read()
                i = 0
                While (CType(pdtoLista(i), Integer) <> CType(oAlmacenGasStock.drReader(0), Integer)) Or (pdtoLista(i) Is Nothing)
                    i = i + 1
                End While
                Dim Cantidad As Decimal = 1
                If oAlmacenGasStock.drReader.FieldCount >= 4 Then
                    If Not IsDBNull(oAlmacenGasStock.drReader(3)) Then
                        Cantidad = CType(oAlmacenGasStock.drReader(3), Decimal)
                    End If
                End If
                If (CType(pdtoLista(i), Integer) = CType(oAlmacenGasStock.drReader(0), Integer)) And Cantidad > 0 Then
                    textBox1 = CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroDecimal)
                    textBox1.ReadOnly = False
                End If
            End While
            oAlmacenGasStock.drReader.Close()
            oAlmacenGasStock.CerrarConexion()
        End Sub

        Public Sub CargarProductoVarios()
            Dim oProducto As New PortatilClasses.Catalogo.cProductoPtl(4)

            Dim oConfig As New SigaMetClasses.cConfig(16, PortatilClasses.Globals.GetInstance._Corporativo, PortatilClasses.Globals.GetInstance._Sucursal)
            StockCarga = CType(oConfig.Parametros("StockCarga"), String).Trim

            NumProductos = 0
            Do While oProducto.drReader.Read()
                InicializarComponentes(CType(oProducto.drReader(0), Integer), _
                                       CType(oProducto.drReader(1), String), CType(oProducto.drReader(2), Decimal))
            Loop
            oProducto.drReader.Close()
            oProducto.CerrarConexion()
            oProducto = Nothing
        End Sub

        Public Sub CargarProductoUnico(ByVal AlmacenGas As Integer)
            Dim oProducto As New PortatilClasses.Consulta.cProductoContenedor(0, AlmacenGas)

            Dim oConfig As New SigaMetClasses.cConfig(16, PortatilClasses.Globals.GetInstance._Corporativo, PortatilClasses.Globals.GetInstance._Sucursal)
            StockCarga = CType(oConfig.Parametros("StockCarga"), String).Trim

            oProducto.CargaDatos()
            InicializarComponentes(oProducto.Identificador, oProducto.Descripcion, 1)
            txtCantidad1.ReadOnly = False
            txtCantidad1.Clear()
            oProducto = Nothing
        End Sub

        Public Sub CargarProducto(ByVal AlmacenGas As Integer, ByVal TipoPdto As Integer)
            UbicarProducto()
            LimpiarControles()
            TipoProducto = TipoPdto
            If TipoPdto = 5 Then
                CargarProductoVarios()
                SoloLectura(AlmacenGas)
            Else
                CargarProductoUnico(AlmacenGas)
            End If
        End Sub

        Public Sub CargarProducto(ByVal TipoPdto As Integer)
            UbicarProducto()
            LimpiarControles()
            TipoProducto = TipoPdto
            CargarProductoVarios()
        End Sub

        Private Sub LimpiarControles()
            BorrarDatos()
            Dim i As Integer
            For i = Controls.Count - 1 To 6 Step -1
                Controls.RemoveAt(i)
            Next
            txtLista.Clear()
            pdtoLista.Clear()
            lblLista.Clear()
            ListaDescripcion.Clear()
            NumProductos = 0
        End Sub

        Public Sub BorrarDatos()
            Dim textBox1 As New SigaMetClasses.Controles.txtNumeroDecimal()
            Dim label As New System.Windows.Forms.Label()
            Dim i As Integer
            For i = 0 To txtLista.Count() - 1
                textBox1 = CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroDecimal)
                textBox1.Clear()
            Next
            For i = 0 To lblLista.Count() - 1
                label = CType(lblLista.Item(i), System.Windows.Forms.Label)
                label.Text = ""
            Next
        End Sub

        Public Function SumarKilos() As Decimal
            Dim textBox1 As New SigaMetClasses.Controles.txtNumeroDecimal()
            Dim i As Integer
            Dim Kilos As Decimal
            For i = 0 To txtLista.Count() - 1
                textBox1 = CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroDecimal)
                If textBox1.Text <> "" Then
                    Kilos = Kilos + CType(textBox1.Tag, Decimal) * CType(textBox1.Text, Decimal)
                End If
            Next
            Return Kilos
        End Function

        Private Sub txtCantidad1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad1.KeyDown
            If (e.KeyData = Keys.Enter) Or (e.KeyData = Keys.Down) Then
                If CType(sender, Control).TabIndex = NumProductos Then
                    RaiseEvent SiguienteControl(sender, e)
                Else
                    MyBase.SelectNextControl(CType(sender, Control), True, True, True, True)
                End If
            End If
            If e.KeyData = Keys.Up Then
                MyBase.SelectNextControl(CType(sender, Control), False, True, True, True)
            End If
        End Sub

        ' Validar existencias de portatil
        Public Function VerificarExistencias(ByVal AlmacenOrigen As Integer) As Boolean
            Dim textBox1 As New SigaMetClasses.Controles.txtNumeroDecimal()
            Dim i As Integer

            For i = 0 To txtLista.Count() - 1
                textBox1 = CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroDecimal)
                If textBox1.Text <> "" Then
                    If CType(textBox1.Text, Integer) > 0 Then
                        Dim VerificaExistencia As New PortatilClasses.Consulta.cExistencia(0, AlmacenOrigen, CType(pdtoLista(i), Integer), _
                                                                                           CType(textBox1.Text, Integer))
                        VerificaExistencia.CargaDatos()
                        If VerificaExistencia.Existencia = 0 Then
                            Return False
                        End If
                    End If
                End If
            Next
            Return True
        End Function

        ' Validar existencia de un producto especifico si el tipo de producto es <> 5 en litros, o tipo producto = 5
        ' en kilos
        Public Function VerificarExistencias(ByVal AlmacenOrigen As Integer, ByVal Cantidad As Decimal, _
        ByVal Producto As Integer) As Boolean
            If TipoProducto = 5 Then
                Return VerificarExistencias(AlmacenOrigen)
            Else
                Dim VerificaExistencia As New PortatilClasses.Consulta.cExistencia(1, AlmacenOrigen, Producto, _
                                              Cantidad)
                VerificaExistencia.CargaDatos()
                If VerificaExistencia.Existencia = 0 Then
                    Return False
                End If
            End If
            Return True
        End Function

        ' Validar existencia de un producto especifico si el tipo de producto es <> 5 en kilos, o tipo producto = 5
        ' en kilos
        Public Function VerificarExistenciasKilos(ByVal AlmacenOrigen As Integer, ByVal Cantidad As Decimal, _
        ByVal Producto As Integer) As Boolean
            Dim VerificaExistencia As New PortatilClasses.Consulta.cExistencia(2, AlmacenOrigen, Producto, _
                                          Cantidad)
            VerificaExistencia.CargaDatos()
            If VerificaExistencia.Existencia = 0 Then
                Return False
            End If
            Return True
        End Function

        Public Function CargaEnCeros() As Boolean
            Dim textBox1 As New SigaMetClasses.Controles.txtNumeroDecimal()
            Dim i As Integer

            For i = 0 To txtLista.Count() - 1
                textBox1 = CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroDecimal)
                If textBox1.Text <> "" Then
                    If CType(textBox1.Text, Integer) <> 0 Then
                        Return False
                    End If
                End If
            Next
            Return True
        End Function

        ' Registra los productos que se han almacenado en los controles de la clase, mandamos KIlos
        Public Sub RegistraMovimientoProducto(ByVal Almacen As Integer, ByVal MovimientoAlmacen As Integer)
            Dim textBox1 As New SigaMetClasses.Controles.txtNumeroDecimal()
            Dim i As Integer
            For i = 0 To txtLista.Count() - 1
                Dim Kilos As Decimal
                Dim Cantidad As Integer
                textBox1 = CType(txtLista.Item(i), SigaMetClasses.Controles.txtNumeroDecimal)
                If textBox1.Text <> "" Then
                    Cantidad = CType(textBox1.Text, Integer)
                    If Cantidad > 0 Then
                        Kilos = Cantidad * CType(textBox1.Tag, Decimal)
                        Dim oMovimientoAProducto As PortatilClasses.Consulta.cMovimientoAProducto
                        oMovimientoAProducto = New PortatilClasses.Consulta.cMovimientoAProducto(0, Almacen, CType(pdtoLista(i), Integer), _
                                                        MovimientoAlmacen, Kilos, Kilos, Cantidad)
                        oMovimientoAProducto.CargaDatos()
                    End If
                End If
            Next
        End Sub

        ' Registra los productos que se han almacenado en los controles de la clase, mandamos Litros
        Public Sub RegistraMovimientoProducto(ByVal Almacen As Integer, ByVal MovimientoAlmacen As Integer, _
        ByVal Litros As Decimal)
            Dim textBox1 As New SigaMetClasses.Controles.txtNumeroDecimal()
            textBox1 = CType(txtLista.Item(0), SigaMetClasses.Controles.txtNumeroDecimal)
            Dim oMovimientoAProducto As PortatilClasses.Consulta.cMovimientoAProducto
            oMovimientoAProducto = New PortatilClasses.Consulta.cMovimientoAProducto(1, Almacen, CType(pdtoLista(0), Integer), _
                                            MovimientoAlmacen, Litros, Litros, 1)
            oMovimientoAProducto.CargaDatos()
        End Sub

        ' Registramos el producto y mandamos Kilos
        Public Sub RegistraMovimientoProducto(ByVal Almacen As Integer, ByVal MovimientoAlmacen As Integer, _
        ByVal Producto As Integer, ByVal Kilos As Decimal)
            Dim oMovimientoAProducto As PortatilClasses.Consulta.cMovimientoAProducto
            oMovimientoAProducto = New PortatilClasses.Consulta.cMovimientoAProducto(3, Almacen, Producto, _
                                            MovimientoAlmacen, Kilos, Kilos, 1)
            oMovimientoAProducto.CargaDatos()
        End Sub

        ' registramos el producto y mandamos Litros
        Public Sub RegistraMovimientoProducto(ByVal Almacen As Integer, ByVal MovimientoAlmacen As Integer, _
        ByVal Litros As Decimal, ByVal Producto As Integer)
            Dim oMovimientoAProducto As PortatilClasses.Consulta.cMovimientoAProducto
            oMovimientoAProducto = New PortatilClasses.Consulta.cMovimientoAProducto(1, Almacen, Producto, _
                                            MovimientoAlmacen, Litros, Litros, 1)
            oMovimientoAProducto.CargaDatos()
        End Sub

        Private Sub txtCantidad1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad1.TextChanged
            If CType(sender, Control).TabIndex = 0 Then
                Indice = 0
            Else
                Indice = CType(sender, Control).TabIndex - 1
            End If
            CantidadProductos = 0
            KilosProductos = 0
            If CType(sender, Control).Text <> "" And CType(sender, Control).Focused Then
                CantidadProductos = CType(CType(sender, Control).Text, Decimal)
                KilosProductos = CType(CType(sender, Control).Text, Decimal) * CType(CType(sender, Control).Tag, Decimal)
            End If

            RaiseEvent CarmbioTexto()
        End Sub

        Private Sub txtCantidad1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad1.KeyPress
            If _TipoProducto = 5 Then
                If Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Then e.Handled = False Else e.Handled = True
            End If
        End Sub
    End Class

#Region "Class TipoAlmacenExistencias"
    Public Class TipoAlmacenExistencias
        Inherits System.Windows.Forms.Panel

#Region " Component Designer generated code "

        Public Sub New(ByVal Container As System.ComponentModel.IContainer)
            MyClass.New()

            'Required for Windows.Forms Class Composition Designer support
            Container.Add(Me)
        End Sub

        Public Sub New()
            MyBase.New()

            'This call is required by the Component Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me.Width = 400
            Me.Height = 70
            UbicarControl()
        End Sub

        'Component overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Component Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Component Designer
        'It can be modified using the Component Designer.
        'Do not modify it using the code editor.        
        Private lblCantidad As System.Windows.Forms.Label
        Private lblTAlmacen As System.Windows.Forms.Label
        Private lblLitros As System.Windows.Forms.Label
        Private lblKilos As System.Windows.Forms.Label
        Private lblPorcentaje As System.Windows.Forms.Label

        Public WithEvents txtCantidad1 As SigaMetClasses.Controles.txtNumeroEntero
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

#End Region

        ' Ubica los dos primeros controles dentro del panel
        Private Sub UbicarControl()
            Me.lblTAlmacen = New System.Windows.Forms.Label()
            Me.lblTAlmacen.Location = New System.Drawing.Point(16, 5)
            Me.lblTAlmacen.Name = "lblCantidad"
            Me.lblTAlmacen.Size = New System.Drawing.Size(100, 14)
            Me.lblTAlmacen.Text = "Tipo almacén:"
            Controls.Add(lblTAlmacen)

            Me.lblCantidad = New System.Windows.Forms.Label()
            Me.lblCantidad.Location = New System.Drawing.Point(16, 25)
            Me.lblCantidad.Name = "lblTAlmacen"
            Me.lblCantidad.Size = New System.Drawing.Size(100, 14)
            Me.lblCantidad.Text = "Cantidad:"
            Controls.Add(lblCantidad)

            Me.lblLitros = New System.Windows.Forms.Label()
            Me.lblLitros.Location = New System.Drawing.Point(16, 45)
            Me.lblLitros.Name = "lblCantidad"
            Me.lblLitros.Size = New System.Drawing.Size(100, 14)
            Me.lblLitros.Text = "Total kilos:"
            Controls.Add(lblLitros)

            Me.lblKilos = New System.Windows.Forms.Label()
            Me.lblKilos.Location = New System.Drawing.Point(16, 65)
            Me.lblKilos.Name = "lblKilos"
            Me.lblKilos.Size = New System.Drawing.Size(100, 14)
            Me.lblKilos.Text = "Total litros:"
            Controls.Add(lblKilos)

            Me.lblPorcentaje = New System.Windows.Forms.Label()
            Me.lblPorcentaje.Location = New System.Drawing.Point(16, 85)
            Me.lblPorcentaje.Name = "lblPorcentaje"
            Me.lblPorcentaje.Size = New System.Drawing.Size(100, 14)
            Me.lblPorcentaje.Text = "Porcentaje de llenado:"
            Controls.Add(lblPorcentaje)

            Me.AutoScroll = True
        End Sub

        Private Sub AddControls(ByVal Descripcion As String, ByVal X As Integer, ByVal Y As Integer)
            Dim label1 As New Label()
            label1.Text = Descripcion
            label1.Location = New System.Drawing.Point(X, Y)
            label1.Size = lblCantidad.Size
            label1.TextAlign = Drawing.ContentAlignment.MiddleRight
            Controls.Add(label1)
        End Sub

        Private Sub LimpiarControles()
            Dim i As Integer
            For i = Controls.Count - 1 To 5 Step -1
                Controls.RemoveAt(i)
            Next
        End Sub

        Public Sub CargarResumen(ByVal Configuracion As Integer, ByVal Celula As Integer)
            LimpiarControles()
            'UbicarControl()
            Dim x As Integer
            Dim oExistencias As New Catalogo.ConsultaExistenciasTAlmacen(Configuracion, Celula)
            x = 116
            While oExistencias.drReader.Read()
                AddControls(CType(oExistencias.drReader(0), String), x, 5)
                AddControls(Format(oExistencias.drReader(3), "n0"), x, 25)
                AddControls(Format(oExistencias.drReader(1), "n2"), x, 45)
                AddControls(Format(oExistencias.drReader(2), "n2"), x, 65)
                AddControls(Format(oExistencias.drReader(4), "n2") & " %", x, 85)
                x = x + 170
            End While
            oExistencias.CerrarConexion()
            oExistencias = Nothing
        End Sub

    End Class
#End Region

End Namespace

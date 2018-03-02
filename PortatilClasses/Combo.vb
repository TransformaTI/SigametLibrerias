'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 18/01/2006
'Motivo: Se modifico un procedimeinto a public
'Identificador de cambios: 20060118CAGP$001

Imports System.ComponentModel.Component
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO

Namespace Combo


#Region "Class ComboBase"

    Public Class ComboBase
        Inherits System.Windows.Forms.ComboBox

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
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            components = New System.ComponentModel.Container()
            MyBase.Text = ""
            MyBase.Items.Clear()
            MyBase.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList
        End Sub

#End Region

        Protected Lista As New ArrayList()

        Protected Structure Tabla
            Private _Descripcion As String
            Private _Identificador As Integer
            Private _Iniciales As String
            Private _Campo1 As String

            Public Sub New(ByVal name As String, ByVal id As Integer)
                _Descripcion = name
                _Identificador = id
            End Sub

            Public Sub New(ByVal name As String, ByVal id As Integer, ByVal Inicial As String)
                _Descripcion = name
                _Identificador = id
                _Iniciales = Inicial
            End Sub

            Public Sub New(ByVal name As String, ByVal id As Integer, ByVal Inicial As String, ByVal Campo1 As String)
                _Descripcion = name
                _Identificador = id
                _Iniciales = Inicial
                _Campo1 = Campo1
            End Sub

            Public ReadOnly Property Descripcion() As String
                Get
                    Return _Descripcion
                End Get
            End Property

            Public ReadOnly Property Identificador() As Integer
                Get
                    Return _Identificador
                End Get
            End Property

            Public ReadOnly Property Iniciales() As String
                Get
                    Return _Iniciales
                End Get
            End Property


            Public ReadOnly Property Campo1() As String
                Get
                    Return _Campo1
                End Get
            End Property

        End Structure

        ReadOnly Property Inicial() As String
            Get
                Dim Datos As Tabla
                Datos = CType(Lista.Item(MyBase.SelectedIndex), Tabla)
                Return (Datos.Iniciales)
            End Get
        End Property

        ReadOnly Property Campo1() As String
            Get
                Dim Datos As Tabla
                Datos = CType(Lista.Item(MyBase.SelectedIndex), Tabla)
                Return (Datos.Campo1)
            End Get
        End Property

        ReadOnly Property Identificador() As Integer
            Get
                Return CType(MyBase.SelectedValue, Integer)
            End Get
        End Property

        Protected Sub AsignaDataSource()
            Me.Limpiar()
            If Lista.Count > 0 Then
                MyBase.DataSource = Lista
                MyBase.DisplayMember = "Descripcion"
                MyBase.ValueMember = "Identificador"
                If Lista.Count = 1 Then
                    MyBase.SelectedIndex = 0
                Else
                    Me.PosicionarInicio()
                End If
            End If
        End Sub

        Protected Sub RealizarConsulta(ByVal Procedimiento As String, ByVal Configuracion As Integer, ByVal Usuario As String, ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal Celula As Short, ByVal Campo1 As String)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand(Procedimiento, cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = Corporativo
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Lista.Clear()
                Me.PosicionarInicio()
                Do While drAlmacen.Read()
                    Lista.Add(New Tabla(CType(drAlmacen(1), String), CType(drAlmacen(0), Integer), CType(drAlmacen(2), String), CType(drAlmacen(3), String)))
                Loop
                cnSigamet.Close()
                AsignaDataSource()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Combo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Protected Sub RealizarConsulta(ByVal Procedimiento As String, ByVal Configuracion As Integer, ByVal Usuario As String, ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal Celula As Short)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand(Procedimiento, cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = Corporativo
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
                cmdComando.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Lista.Clear()
                Me.PosicionarInicio()
                Do While drAlmacen.Read()
                    Lista.Add(New Tabla(CType(drAlmacen(1), String), CType(drAlmacen(0), Integer)))
                Loop
                cnSigamet.Close()
                AsignaDataSource()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Combo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Protected Sub RealizarConsulta(ByVal Procedimiento As String, ByVal Configuracion As Integer, ByVal Usuario As String, ByVal Celula As Short)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand(Procedimiento, cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
                cmdComando.Parameters.Add("@Celula", SqlDbType.VarChar).Value = Celula
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Lista.Clear()
                Me.PosicionarInicio()
                Do While drAlmacen.Read()
                    Lista.Add(New Tabla(CType(drAlmacen(1), String), CType(drAlmacen(0), Integer)))
                Loop
                cnSigamet.Close()
                AsignaDataSource()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Combo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        ' 20060118CAGP$001
        Public Sub RealizarConsulta(ByVal Procedimiento As String, ByVal Configuracion As Integer, ByVal Usuario As String)
            'Protected Sub RealizarConsulta(ByVal Procedimiento As String, ByVal Configuracion As Integer, ByVal Usuario As String)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader
            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand(Procedimiento, cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Lista.Clear()
                Me.PosicionarInicio()
                Do While drAlmacen.Read()
                    Lista.Add(New Tabla(CType(drAlmacen(1), String), CType(drAlmacen(0), Integer)))
                Loop
                cnSigamet.Close()
                AsignaDataSource()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Combo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Protected Sub RealizarConsulta(ByVal Procedimiento As String, ByVal Configuracion As Integer)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader


            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand(Procedimiento, cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Lista.Clear()

                Do While drAlmacen.Read()
                    Lista.Add(New Tabla(CType(drAlmacen(1), String), CType(drAlmacen(0), Integer)))
                Loop
                cnSigamet.Close()
                AsignaDataSource()
            Catch exc As Exception
                'EventLog.WriteEntry("Clase Combo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        'Protected Sub RealizarConsulta3Parametros(ByVal Procedimiento As String, ByVal Configuracion As Integer)
        '    Dim cnSigamet As SqlConnection
        '    Dim cmdComando As SqlCommand
        '    Dim drAlmacen As SqlDataReader


        '    Try
        '        cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
        '        cmdComando = New SqlCommand(Procedimiento, cnSigamet)
        '        cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
        '        cmdComando.CommandType = CommandType.StoredProcedure
        '        cnSigamet.Open()
        '        drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

        '        Lista.Clear()

        '        Do While drAlmacen.Read()
        '            Lista.Add(New Tabla(CType(drAlmacen(1), String), CType(drAlmacen(0), Integer), CType(drAlmacen(2), String)))
        '        Loop
        '        cnSigamet.Close()
        '        AsignaDataSource()
        '    Catch exc As Exception
        '        EventLog.WriteEntry("Clase Combo" & exc.Source, exc.Message, EventLogEntryType.Error)
        '        MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End Sub

        '20160615#LUSATE Acta Cierre
        Protected Sub RealizarConsulta(ByVal Procedimiento As String, ByVal Configuracion As Integer, ByVal Sucursal As Short)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand(Procedimiento, cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Sucursal", SqlDbType.SmallInt).Value = Sucursal
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Lista.Clear()

                Do While drAlmacen.Read()
                    'Se agrego un campo vacio ya que la descripcion de la variable no se condisidero correcta para guardar el campo consultado
                    Lista.Add(New Tabla(CType(drAlmacen(1), String), CType(drAlmacen(0), Integer), _
                                        "", CType(drAlmacen(2), Integer)))
                Loop
                cnSigamet.Close()
                AsignaDataSource()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Combo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        '20161116#LUSATE Acta Cierre
        Protected Sub RealizarConsulta3Parametros(ByVal Procedimiento As String, ByVal Configuracion As Integer)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader


            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand(Procedimiento, cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Lista.Clear()

                Do While drAlmacen.Read()
                    Lista.Add(New Tabla(CType(drAlmacen(1), String), CType(drAlmacen(0), Integer), CType(drAlmacen(2), String)))
                Loop
                cnSigamet.Close()
                AsignaDataSource()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Combo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub




        Public Sub CargaDatosBase(ByVal Procedimiento As String, ByVal Configuracion As Integer, ByVal Usuario As String)
            RealizarConsulta(Procedimiento, Configuracion)
        End Sub

        Public Sub CargaDatosBase3(ByVal Procedimiento As String, ByVal Configuracion As Integer, ByVal Usuario As String)
            RealizarConsulta3Parametros(Procedimiento, Configuracion)
        End Sub

        Public Sub CargaDatosBase(ByVal Procedimiento As String, ByVal Configuracion As Integer, ByVal Usuario As String, ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal Celula As Short)
            RealizarConsulta(Procedimiento, Configuracion, Usuario, Corporativo, Sucursal, Celula)
        End Sub

        Public Sub CargaDatosBase(ByVal Procedimiento As String, ByVal Configuracion As Integer, ByVal Usuario As String, ByVal Corporativo As Short, ByVal Sucursal As Short, ByVal Celula As Short, ByVal Campo1 As String)
            RealizarConsulta(Procedimiento, Configuracion, Usuario, Corporativo, Sucursal, Celula, Campo1)
        End Sub

        Public Sub PosicionaCombo(ByVal Posicion As Integer)
            If Posicion >= 0 Then
                Dim i As Integer = 0
                Me.SelectedIndex = i
                Do
                    Me.SelectedIndex = i
                    i = i + 1
                Loop Until Posicion = Me.Identificador Or i = Me.Items.Count
                If Posicion = Me.Identificador Then
                    Me.SelectedIndex = i - 1
                Else
                    Me.PosicionarInicio()
                End If
            End If
        End Sub

        Public Sub PosicionarInicio()
            MyBase.SelectedIndex = -1
            MyBase.SelectedIndex = -1
        End Sub

        Protected Sub Limpiar()
            MyBase.DataSource = Nothing
            MyBase.Items.Clear()
        End Sub

    End Class
#End Region

#Region "Class ComboBase2"
    Public Class ComboBase2
        Inherits System.Windows.Forms.ComboBox

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
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            components = New System.ComponentModel.Container()
            MyBase.Text = ""
            MyBase.Items.Clear()
            MyBase.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList
        End Sub

#End Region

        Private _FileConfiguracion As String
        Protected Lista As New ArrayList()

        Protected Property FileConfiguracion() As String
            Get
                Return _FileConfiguracion
            End Get
            Set(ByVal Value As String)
                _FileConfiguracion = Value
            End Set
        End Property

        Protected Structure Tabla
            Private _Descripcion As String
            Private _Identificador As Integer
            Private _Unidad As Decimal
            Private _Descuento As Decimal

            Public Sub New(ByVal name As String, ByVal id As Integer, ByVal Un As Decimal, ByVal Des As Decimal)
                _Descripcion = name
                _Identificador = id
                _Unidad = Un
                _Descuento = Des
            End Sub
            '20160615#LUSATE Acta Cierre
            Public Sub New(ByVal name As String, ByVal id As Integer, ByVal Un As Decimal)
                _Descripcion = name
                _Identificador = id
                _Unidad = Un
            End Sub

            Public ReadOnly Property Descripcion() As String
                Get
                    Return _Descripcion
                End Get
            End Property

            Public ReadOnly Property Identificador() As Integer
                Get
                    Return _Identificador
                End Get
            End Property

            Public ReadOnly Property Unidad() As Decimal
                Get
                    Return _Unidad
                End Get
            End Property

            Public ReadOnly Property Descuento() As Decimal
                Get
                    Return _Descuento
                End Get
            End Property
        End Structure

        ReadOnly Property Identificador() As Integer
            Get
                Return CType(MyBase.SelectedValue, Integer)
            End Get
        End Property

        ReadOnly Property Unidad() As Decimal
            Get
                Dim Datos As Tabla
                Datos = CType(Lista.Item(MyBase.SelectedIndex), Tabla)
                Return (Datos.Unidad)
            End Get
        End Property

        ReadOnly Property Descuento() As Decimal
            Get
                Dim Datos As Tabla
                Datos = CType(Lista.Item(MyBase.SelectedIndex), Tabla)
                Return (Datos.Descuento)
            End Get
        End Property

        Protected Sub AsignaDataSource()
            Me.Limpiar()
            If Lista.Count > 0 Then
                MyBase.DataSource = Lista
                MyBase.DisplayMember = "Descripcion"
                MyBase.ValueMember = "Identificador"
                If Lista.Count = 1 Then
                    MyBase.SelectedIndex = 0
                Else
                    Me.PosicionarInicio()
                End If
            End If
        End Sub

        Protected Sub RealizarConsulta(ByVal Procedimiento As String, ByVal Configuracion As Integer)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand(Procedimiento, cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Lista.Clear()
                Me.PosicionarInicio()
                Do While drAlmacen.Read()
                    If drAlmacen.FieldCount = 4 Then
                        If Not IsDBNull(drAlmacen(3)) Then
                            Lista.Add(New Tabla(CType(drAlmacen(1), String), CType(drAlmacen(0), Integer), _
                            CType(drAlmacen(2), Decimal), CType(drAlmacen(3), Decimal)))
                        Else
                            Lista.Add(New Tabla(CType(drAlmacen(1), String), CType(drAlmacen(0), Integer), _
                            CType(drAlmacen(2), Decimal), 0))
                        End If
                    Else
                        Lista.Add(New Tabla(CType(drAlmacen(1), String), CType(drAlmacen(0), Integer), _
                        CType(drAlmacen(2), Decimal), 0))
                    End If

                Loop
                cnSigamet.Close()
                AsignaDataSource()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Combo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        '20160615#LUSATE Acta Cierre
        Protected Sub RealizarConsulta(ByVal Procedimiento As String, ByVal Configuracion As Integer, TipoRecipiente As Short)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand(Procedimiento, cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@TipoRecipiente", SqlDbType.SmallInt).Value = TipoRecipiente
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Lista.Clear()
                Me.PosicionarInicio()
                Do While drAlmacen.Read()
                    Lista.Add(New Tabla(CType(drAlmacen(1), String), CType(drAlmacen(0), Integer), CType(drAlmacen(2), Decimal)))
                Loop
                cnSigamet.Close()
                AsignaDataSource()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Combo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


        Public Sub CargaDatosBase(ByVal Procedimiento As String, ByVal Configuracion As Integer, ByVal Usuario As String)
            RealizarConsulta(Procedimiento, Configuracion)
        End Sub

        Public Sub PosicionaCombo(ByVal Posicion As Integer)
            If Posicion > 0 Then
                Dim i As Integer = 0
                Me.SelectedIndex = i
                Do
                    Me.SelectedIndex = i
                    i = i + 1
                Loop Until Posicion = Me.Identificador Or i = Me.Items.Count
                If Posicion = Me.Identificador Then
                    Me.SelectedIndex = i - 1
                Else
                    Me.PosicionarInicio()
                End If
            End If
        End Sub

        Public Sub PosicionarInicio()
            MyBase.SelectedIndex = -1
            MyBase.SelectedIndex = -1
        End Sub

        Public Sub Limpiar()
            MyBase.DataSource = Nothing
            MyBase.Items.Clear()
        End Sub

    End Class
#End Region

#Region "Class ComboBase3"
    Public Class ComboBase3
        Inherits System.Windows.Forms.ComboBox

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
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            components = New System.ComponentModel.Container()
            MyBase.Text = ""
            MyBase.Items.Clear()
            MyBase.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList
        End Sub

#End Region

        Private _FileConfiguracion As String
        Protected Lista As New ArrayList()

        Protected Property FileConfiguracion() As String
            Get
                Return _FileConfiguracion
            End Get
            Set(ByVal Value As String)
                _FileConfiguracion = Value
            End Set
        End Property

        Protected Structure Tabla
            Private _Descripcion As String
            Private _Identificador As Integer
            Private _Celula As Integer
            Private _TipoProducto As Integer
            Private _Movil As Boolean

            Public Sub New(ByVal name As String, ByVal id As Integer, ByVal Cel As Integer, ByVal TipoPdto As Integer, ByVal Mov As Boolean)
                _Descripcion = name
                _Identificador = id
                _Celula = Cel
                _TipoProducto = TipoPdto
                _Movil = Mov
            End Sub

            Public ReadOnly Property Descripcion() As String
                Get
                    Return _Descripcion
                End Get
            End Property

            Public ReadOnly Property Identificador() As Integer
                Get
                    Return _Identificador
                End Get
            End Property

            Public ReadOnly Property Celula() As Integer
                Get
                    Return _Celula
                End Get
            End Property

            Public ReadOnly Property TipoProducto() As Integer
                Get
                    Return _TipoProducto
                End Get
            End Property

            Public ReadOnly Property Movil() As Boolean
                Get
                    Return _Movil
                End Get
            End Property
        End Structure

        ReadOnly Property Identificador() As Integer
            Get
                Return CType(MyBase.SelectedValue, Integer)
            End Get
        End Property

        ReadOnly Property TipoProducto() As Integer
            Get
                Dim Datos As Tabla
                Datos = CType(Lista.Item(MyBase.SelectedIndex), Tabla)
                Return (Datos.TipoProducto)
            End Get
        End Property

        ReadOnly Property Movil() As Boolean
            Get
                Dim Datos As Tabla
                Datos = CType(Lista.Item(MyBase.SelectedIndex), Tabla)
                Return (Datos.Movil)
            End Get
        End Property

        ReadOnly Property Celula() As Integer
            Get
                Dim Datos As Tabla
                Datos = CType(Lista.Item(MyBase.SelectedIndex), Tabla)
                Return (Datos.Celula)
            End Get
        End Property

        Protected Sub AsignaDataSource()
            Me.Limpiar()
            If Lista.Count > 0 Then
                MyBase.DataSource = Lista
                MyBase.DisplayMember = "Descripcion"
                MyBase.ValueMember = "Identificador"
                If Lista.Count = 1 Then
                    MyBase.SelectedIndex = 0
                Else
                    Me.PosicionarInicio()
                End If
            End If
        End Sub

        Protected Sub RealizarConsulta(ByVal Procedimiento As String, ByVal Configuracion As Integer, _
                                       ByVal Usuario As String, ByVal Corporativo As Integer)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand(Procedimiento, cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
                cmdComando.Parameters.Add("@Corporativo", SqlDbType.SmallInt).Value = Corporativo
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Lista.Clear()
                Me.PosicionarInicio()
                Do While drAlmacen.Read()
                    Lista.Add(New Tabla(CType(drAlmacen(1), String), CType(drAlmacen(0), Integer), CType(drAlmacen(2), Integer), _
                                        CType(drAlmacen(3), Integer), CType(drAlmacen(4), Boolean)))
                Loop
                cnSigamet.Close()
                AsignaDataSource()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Combo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub CargaDatosBase(ByVal Procedimiento As String, ByVal Configuracion As Integer, ByVal Usuario As String, _
                                  ByVal Corporativo As Integer)
            RealizarConsulta(Procedimiento, Configuracion, Usuario, Corporativo)
        End Sub

        Public Sub PosicionaCombo(ByVal Posicion As Integer)
            If Posicion > 0 Then
                Dim i As Integer = 0
                Me.SelectedIndex = i
                Do While Me.Identificador <> Posicion And i < Me.Items.Count
                    i = i + 1
                    Me.SelectedIndex = i
                Loop
                If i >= Me.Items.Count Then
                    Me.PosicionarInicio()
                End If
            End If
        End Sub

        Public Sub PosicionarInicio()
            MyBase.SelectedIndex = -1
            MyBase.SelectedIndex = -1
        End Sub

        Public Sub Limpiar()
            MyBase.DataSource = Nothing
            MyBase.Items.Clear()
        End Sub

    End Class
#End Region

    Public Class ComboAlmacen
        Inherits ComboBase3

        Public Sub CargaDatos(ByVal Configuracion As Integer, ByVal Usuario As String, ByVal Corporativo As Integer)
            RealizarConsulta("spPTLCargaComboAlmacen ", Configuracion, Usuario, Corporativo)
        End Sub

        Public Sub CargaDatos(ByVal Configuracion As Integer, ByVal Usuario As String)
            RealizarConsulta("spPTLCargaComboAlmacen ", Configuracion, Usuario, 0)
        End Sub

    End Class

    Public Class ComboCamion
        Inherits ComboBase

        Public Sub CargaDatos(ByVal Configuracion As Integer, ByVal Usuario As String)
            RealizarConsulta("spPTLCargaComboAutotanque ", Configuracion)
        End Sub

    End Class

    Public Class ComboImpuesto
        Inherits ComboBase

        Public Sub CargaDatos(ByVal Configuracion As Integer, ByVal Usuario As String)
            RealizarConsulta("spPTLCargaComboImpuesto ", Configuracion)
        End Sub

    End Class

    Public Class ComboOperadorPtl
        Inherits ComboBase

        Public Sub CargaDatos(ByVal Configuracion As Integer, ByVal Usuario As String)
            RealizarConsulta("spPTLCargaComboOperador ", Configuracion)
        End Sub

    End Class

    Public Class ComboProductoPtl
        Inherits ComboBase2

        Public Sub CargaDatos(ByVal Configuracion As Integer, ByVal Usuario As String)
            RealizarConsulta("spPTLCargaComboProducto ", Configuracion)
        End Sub

    End Class

    Public Class ComboRutaPtl
        Inherits ComboBase

        Public Sub CargaDatos(ByVal Configuracion As Integer, ByVal Usuario As String, Optional ByVal Celula As Short = 0)
            RealizarConsulta("spPTLCargaComboRuta ", Configuracion, Usuario, Celula)
        End Sub

    End Class

    Public Class ComboZEconomicaPtl
        Inherits ComboBase

        Public Sub CargaDatos(ByVal Configuracion As Integer, ByVal Usuario As String)
            RealizarConsulta("spPTLCargaComboZEconomica ", Configuracion)
        End Sub

    End Class

    Public Class ComboTipoMAlmacen
        Inherits ComboBase

        Public Sub CargaDatos(ByVal Configuracion As Integer, ByVal Usuario As String)
            RealizarConsulta("spPTLCargaComboTipoMAlmacen ", Configuracion)
        End Sub

    End Class

    Public Class ComboCorporativo
        Inherits ComboBase

        Public Sub CargaDatos(ByVal Configuracion As Integer)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader

            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLCargaComboCorporativo", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Lista.Add(New Tabla(CType(drAlmacen(1), String), CType(drAlmacen(0), Integer), CType(drAlmacen(2), String)))
                Loop
                cnSigamet.Close()
                AsignaDataSource()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Combo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class

    Public Class ComboTipoFolio
        Inherits ComboBase

        Public Sub CargaDatos(ByVal Configuracion As Integer)
            Dim cnSigamet As SqlConnection
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader



            Try
                cnSigamet = New SqlConnection(Globals.GetInstance._CadenaConexion)
                cmdComando = New SqlCommand("spPTLCargaComboTipoFolio", cnSigamet)
                cmdComando.Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = Configuracion
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)

                Do While drAlmacen.Read()
                    Lista.Add(New Tabla(CType(drAlmacen(1), String), CType(drAlmacen(0), Integer), CType(drAlmacen(2), String)))
                Loop
                cnSigamet.Close()
                AsignaDataSource()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Combo" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class

    '20160615#LUSATE Acta Cierre
    Public Class ComboRecipiente
        Inherits ComboBase2

        Public Sub CargaDatos(ByVal Configuracion As Integer, ByVal TipoRecipeinte As Short)
            RealizarConsulta("spPTLCargaComboRecipientoPorTipo ", Configuracion, TipoRecipeinte)
        End Sub

    End Class
    '20160615#LUSATE Acta Cierre
    Public Class ComboAlmacenRecipiente
        Inherits ComboBase

        Public Sub CargaDatos(ByVal Configuracion As Integer, ByVal Sucursal As Short)
            RealizarConsulta("spPTLCargaComboAlmacenRecipiente ", Configuracion, Sucursal)
        End Sub

    End Class
    '20161116#LUSATE Acta Cierre
    Public Class ComboEmpleado
        Inherits ComboBase

        Public Sub CargaDatos(ByVal Configuracion As Integer)
            RealizarConsulta3Parametros("spPTLConsultaEmpleadoPorOrden ", Configuracion)
        End Sub

    End Class


End Namespace

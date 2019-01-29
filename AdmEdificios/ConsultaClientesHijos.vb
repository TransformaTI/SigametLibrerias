Option Strict On
Imports System.Data.SqlClient, System.Windows.Forms
Imports SigaMetClasses


Public Class ConsultaClientesHijos
    Inherits System.Windows.Forms.Form
    Private _ClientePadre As Integer
    Private _Titulo As String = "Clientes hijos"
    Private _Usuario As String
    Private conn As New SqlConnection()
    Private parametros As SigaMetClasses.cConfig

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
    Friend WithEvents ToolBarButton2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents lvwCliente As System.Windows.Forms.ListView
    Friend WithEvents colCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents tbBarra As System.Windows.Forms.ToolBar
    Friend WithEvents stbEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDesasignar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAceptar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents colNumInterior As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnCargoAlta As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ConsultaClientesHijos))
        Me.lvwCliente = New System.Windows.Forms.ListView()
        Me.colCliente = New System.Windows.Forms.ColumnHeader()
        Me.colNombre = New System.Windows.Forms.ColumnHeader()
        Me.colNumInterior = New System.Windows.Forms.ColumnHeader()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.tbBarra = New System.Windows.Forms.ToolBar()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.btnSep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.btnDesasignar = New System.Windows.Forms.ToolBarButton()
        Me.btnConsultar = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton2 = New System.Windows.Forms.ToolBarButton()
        Me.btnAceptar = New System.Windows.Forms.ToolBarButton()
        Me.btnCancelar = New System.Windows.Forms.ToolBarButton()
        Me.stbEstatus = New System.Windows.Forms.StatusBar()
        Me.btnCargoAlta = New System.Windows.Forms.ToolBarButton()
        Me.SuspendLayout()
        '
        'lvwCliente
        '
        Me.lvwCliente.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvwCliente.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colCliente, Me.colNombre, Me.colNumInterior})
        Me.lvwCliente.FullRowSelect = True
        Me.lvwCliente.Location = New System.Drawing.Point(0, 25)
        Me.lvwCliente.Name = "lvwCliente"
        Me.lvwCliente.Size = New System.Drawing.Size(458, 215)
        Me.lvwCliente.SmallImageList = Me.ImageList1
        Me.lvwCliente.TabIndex = 0
        Me.lvwCliente.View = System.Windows.Forms.View.Details
        '
        'colCliente
        '
        Me.colCliente.Text = "Cliente"
        Me.colCliente.Width = 100
        '
        'colNombre
        '
        Me.colNombre.Text = "Nombre"
        Me.colNombre.Width = 250
        '
        'colNumInterior
        '
        Me.colNumInterior.Text = "Numero Interior"
        Me.colNumInterior.Width = 100
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'tbBarra
        '
        Me.tbBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnBuscar, Me.btnSep1, Me.btnAgregar, Me.btnDesasignar, Me.btnConsultar, Me.btnCargoAlta, Me.ToolBarButton2, Me.btnAceptar, Me.btnCancelar})
        Me.tbBarra.DropDownArrows = True
        Me.tbBarra.ImageList = Me.ImageList1
        Me.tbBarra.Name = "tbBarra"
        Me.tbBarra.ShowToolTips = True
        Me.tbBarra.Size = New System.Drawing.Size(458, 25)
        Me.tbBarra.TabIndex = 1
        '
        'btnBuscar
        '
        Me.btnBuscar.ImageIndex = 8
        Me.btnBuscar.Tag = "Buscar"
        Me.btnBuscar.ToolTipText = "Busca un cliente en la base de datos"
        '
        'btnSep1
        '
        Me.btnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnAgregar
        '
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.Tag = "Agregar"
        Me.btnAgregar.ToolTipText = "Agrega un nuevo cliente"
        '
        'btnDesasignar
        '
        Me.btnDesasignar.Enabled = False
        Me.btnDesasignar.ImageIndex = 6
        Me.btnDesasignar.Tag = "Desasignar"
        Me.btnDesasignar.ToolTipText = "Desasigna el cliente hijo seleccionado"
        '
        'btnConsultar
        '
        Me.btnConsultar.Enabled = False
        Me.btnConsultar.ImageIndex = 2
        Me.btnConsultar.Tag = "Consultar"
        Me.btnConsultar.ToolTipText = "Consultar cliente seleccionado"
        '
        'ToolBarButton2
        '
        Me.ToolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnAceptar
        '
        Me.btnAceptar.ImageIndex = 4
        Me.btnAceptar.Tag = "Aceptar"
        Me.btnAceptar.ToolTipText = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.ImageIndex = 5
        Me.btnCancelar.Tag = "Cancelar"
        Me.btnCancelar.ToolTipText = "Cancelar"
        '
        'stbEstatus
        '
        Me.stbEstatus.Location = New System.Drawing.Point(0, 241)
        Me.stbEstatus.Name = "stbEstatus"
        Me.stbEstatus.Size = New System.Drawing.Size(458, 22)
        Me.stbEstatus.TabIndex = 2
        '
        'btnCargoAlta
        '
        Me.btnCargoAlta.Enabled = False
        Me.btnCargoAlta.ImageIndex = 9
        Me.btnCargoAlta.Tag = "CargoAlta"
        Me.btnCargoAlta.ToolTipText = "Alta de cargo de administración"
        '
        'ConsultaClientesHijos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(458, 263)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.stbEstatus, Me.lvwCliente, Me.tbBarra})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConsultaClientesHijos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes relacionados (hijos)"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal ClientePadre As Integer, ByVal ConnString As String, _
        ByVal Corporativo As Short, ByVal Sucursal As Short, _
        Optional ByVal Usuario As String = Nothing)
        MyBase.New()
        InitializeComponent()
        _ClientePadre = ClientePadre
        _Usuario = Usuario
        conn.ConnectionString = ConnString
        Me.Text = "Clientes hijos relacionados con el cliente [" & _ClientePadre.ToString & "]"

        'Carga de parámetros múltiples
        parametros = New SigaMetClasses.cConfig(1, Corporativo, Sucursal)

        CargaDatos()

        activaBotonCargoAlta()
    End Sub

#Region "Toolbar"

    Private Sub Agregar()
        Dim frmCapturaDatosHijo As New frmCapturaDatosClienteHijo(_ClientePadre)
        If frmCapturaDatosHijo.ShowDialog() = DialogResult.OK Then
            CargaDatos()
        End If

    End Sub

    Private Sub Buscar()
        Cursor = Cursors.WaitCursor
        Dim oBusqueda As SigaMetClasses.BusquedaCliente
        oBusqueda = New SigaMetClasses.BusquedaCliente(PermiteSeleccionar:=True, AutoSeleccionarRegistroUnico:=True)
        If oBusqueda.ShowDialog = DialogResult.OK Then

            Dim _ClienteSeleccionado As Integer = oBusqueda.Cliente
            Dim oCliente As SigaMetClasses.cCliente = Nothing

            Try
                If ExisteClienteEnLaLista(_ClienteSeleccionado) Then
                    MessageBox.Show("El cliente seleccionado ya está asignado como cliente hijo.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else

                    oCliente = New SigaMetClasses.cCliente(_ClienteSeleccionado)
                    Dim item As ListViewItem = Nothing

                    If oCliente.AplicaClientePadre Then

                        If oCliente.Hijos = 0 Then

                            If oCliente.ClientePadre <> 0 Then

                                Dim oClientePadre As SigaMetClasses.cCliente = Nothing
                                Try
                                    oClientePadre = New SigaMetClasses.cCliente(oCliente.ClientePadre)

                                    If MessageBox.Show("Este cliente ya está asignado como hijo del cliente [" & oCliente.ClientePadre.ToString & "] " & oClientePadre.Nombre.Trim & Chr(13) & "¿Desea asignarlo como cliente hijo de todos modos?", _Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                        'Agregado el 15/09/2004 por JAGD
                                        Dim frmCapturaDatosHijo As New frmCapturaDatosClienteHijo(_ClientePadre, _ClienteSeleccionado)
                                        If frmCapturaDatosHijo.ShowDialog() = DialogResult.OK Then
                                            CargaDatos()
                                        End If

                                        'item = New ListViewItem(oCliente.Cliente.ToString, 7)
                                        'item.SubItems.Add(oCliente.Nombre.Trim)
                                        'lvwCliente.Items.Add(item)

                                        btnConsultar.Enabled = False
                                        btnDesasignar.Enabled = False

                                    End If
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Finally
                                    oClientePadre.Dispose()
                                End Try


                            Else
                                'Agregado el 15/09/2004 por JAGD
                                Dim frmCapturaDatosHijo As New frmCapturaDatosClienteHijo(_ClientePadre, _ClienteSeleccionado)
                                If frmCapturaDatosHijo.ShowDialog() = DialogResult.OK Then
                                    CargaDatos()
                                End If

                                'item = New ListViewItem(oCliente.Cliente.ToString, 7)
                                'item.SubItems.Add(oCliente.Nombre.Trim)
                                'lvwCliente.Items.Add(item)

                                btnConsultar.Enabled = False
                                btnDesasignar.Enabled = False
                            End If

                        Else

                            MessageBox.Show("El cliente que se está asignando como hijo ya es Padre de otro(s) cliente(s)." & Chr(13) & _
                            "Por favor verifique.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                        End If

                    Else
                        MessageBox.Show("El ramo del cliente seleccionado no soporta el esquema de 'Cliente Padre-Hijo'.", _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    End If


                End If

            Catch
                MessageBox.Show("No se pudo cargar la información del cliente " & _ClienteSeleccionado.ToString, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If Not IsNothing(oCliente) Then oCliente.Dispose()
            End Try

        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Desasignar()
        Dim _item As ListViewItem
        For Each _item In lvwCliente.Items
            If _item.Selected Then
                lvwCliente.Items(_item.Index).Remove()
            End If
        Next

        btnConsultar.Enabled = False
        btnDesasignar.Enabled = False

    End Sub

    Private Sub Aceptar()
        If MessageBox.Show(SigaMetClasses.M_ESTAN_CORRECTOS, _Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim _item As ListViewItem
            'Dim conn As New SqlConnection(LeeInfoConexion(False, True))

            Try
                conn.Open()
            Catch ex As Exception
                MessageBox.Show(SigaMetClasses.M_NO_CONEXION, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Cursor = Cursors.Default
                Exit Sub
            End Try

            Dim tran As SqlTransaction = conn.BeginTransaction
            'TODO sugerir implementar en un stored procedure
            Dim cmd As New SqlCommand("UPDATE Cliente Set ClientePadreEdificio = NULL, RamoCliente = 32 Where ClientePadreEdificio = @ClientePadreEdificio", conn)
            cmd.Transaction = tran

            Try
                With cmd
                    .CommandType = CommandType.Text
                    .Parameters.Clear()
                    'Se cambió el parámetro de @ClientePadre a @ClientePadreEdificio
                    '11/09/2004 Jorge A. Guerrero
                    .Parameters.Add("@ClientePadreEdificio", SqlDbType.Int).Value = _ClientePadre
                End With

                cmd.ExecuteNonQuery()

                For Each _item In lvwCliente.Items
                    With cmd
                        'TODO sugerir implementar en un stored procedure
                        .CommandText = "UPDATE Cliente SET ClientePadreEdificio = @ClientePadreEdificio, RamoCliente = 53 WHERE Cliente = @Cliente"
                        .Parameters.Clear()
                        'Se cambió el parámetro de @ClientePadre a @ClientePadreEdificio
                        '11/09/2004 Jorge A. Guerrero
                        .Parameters.Add("@ClientePadreEdificio", SqlDbType.Int).Value = _ClientePadre
                        .Parameters.Add("@Cliente", SqlDbType.Int).Value = CType(_item.Text.Trim, Integer)
                        .ExecuteNonQuery()
                    End With

                Next

                tran.Commit()

                MessageBox.Show(SigaMetClasses.M_DATOS_OK, _Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)

                DialogResult = DialogResult.OK

            Catch ex As Exception
                tran.Rollback()
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default
                If Not IsNothing(conn) Then
                    If conn.State = ConnectionState.Open Then conn.Close()
                End If
                cmd.Dispose()
            End Try
        End If

    End Sub

    Private Sub CargaDatos()
        Cursor = Cursors.WaitCursor
        'Dim conn As New SqlConnection(LeeInfoConexion(False, True))
        'Dim conn As New SqlConnection(cnStr)
        Dim cmd As New SqlCommand("spCCConsultaClientesHijos", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            'Se cambió el parámetro de @ClientePadre a @ClientePadreEdificio
            '11/09/2004 Jorge A. Guerrero
            .Parameters.Add("@ClientePadreEdificio", SqlDbType.Int).Value = _ClientePadre
        End With

        Try
            conn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        Dim dr As SqlDataReader
        Dim item As ListViewItem

        Try
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            lvwCliente.Items.Clear()

            While dr.Read
                item = New ListViewItem(CType(dr("Cliente"), String), 7)
                item.SubItems.Add(CType(dr("Nombre"), String).Trim)
                item.SubItems.Add(CType(dr("NumInterior"), String).Trim)
                lvwCliente.Items.Add(item)
            End While

            stbEstatus.Text = "Lista de clientes hijos relacionados (" & lvwCliente.Items.Count.ToString & " en total)"
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default

            If Not IsNothing(conn) Then
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End If
        End Try

        'PARA QUE SE CAPTURE PRIMERO EL CARGO ADMINISTRATIVO
        If lvwCliente.Items.Count <= 0 And _
            CType(parametros.Parametros("CargoAdministracionEdf"), Boolean) Then
            Dim cargoGenerado As New admEdificiosComisionAdm.ComisionCliente(_ClientePadre, conn)

            If cargoGenerado.ClienteCapturado = Nothing Then
                btnAgregar.Enabled = False
                stbEstatus.Text = "Antes de agregar clientes hijos, configure primero el cargo administrativo"
            Else
                btnAgregar.Enabled = True
            End If
        End If

    End Sub

    Private Sub Consultar()
        Cursor = Cursors.WaitCursor
        Dim _Cliente As Integer
        Dim oConsulta As SigaMetClasses.frmConsultaCliente

        Try
            _Cliente = CType(lvwCliente.FocusedItem.Text.Trim, Integer)
        Catch
            _Cliente = 0
        End Try

        If _Cliente <> 0 Then
			oConsulta = New SigaMetClasses.frmConsultaCliente(_Cliente, Nuevo:=0)
			oConsulta.ShowDialog()
        End If

        Cursor = Cursors.Default

    End Sub

    Private Function ExisteClienteEnLaLista(ByVal _Cliente As Integer) As Boolean
        Dim _item As ListViewItem
        For Each _item In lvwCliente.Items
            If _item.Text.Trim = _Cliente.ToString Then
                _item.Focused = True

                Return True
            End If
        Next
        Return False
    End Function

    Private Sub CloseForm()
        DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub tbBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case "Agregar"
                Agregar()
            Case "Buscar"
                Buscar()
            Case "Desasignar"
                Desasignar()
            Case "Consultar"
                Consultar()
            Case "Aceptar"
                Aceptar()
            Case "Cancelar"
                CloseForm()
            Case "CargoAlta"
                CargoAlta()
        End Select
    End Sub


#End Region

    Private Sub lvwCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwCliente.SelectedIndexChanged
        Dim _item As ListViewItem
        For Each _item In lvwCliente.Items
            If _item.Selected Then
                btnDesasignar.Enabled = True
                btnConsultar.Enabled = True
                Exit Sub
            Else
                btnDesasignar.Enabled = False
                btnConsultar.Enabled = False
            End If
        Next
    End Sub

    Private Sub activaBotonCargoAlta()
        If CType(parametros.Parametros("CargoAdministracionEdf"), Boolean) Then
            Dim cargoAlta As New admEdificiosComisionAdm.ComisionCliente(_ClientePadre, conn)
            btnCargoAlta.Enabled = Not cargoAlta.ClienteCapturado
        End If
    End Sub

    Private Sub CargoAlta()
        Dim cargoAlta As New admEdificiosComisionAdm.Captura(_ClientePadre, conn)
        If cargoAlta.ShowDialog() = DialogResult.OK Then
            CargaDatos()
            btnCargoAlta.Enabled = Not (New admEdificiosComisionAdm.ComisionCliente(_ClientePadre, conn)).ClienteCapturado
        End If
    End Sub

    Public Function verificaSiEsPadre(ByVal cliente As Integer) As Boolean
        'Verifica que el cliente con el que se trata de abrir la forma no está asignado como hijo de otro cliente
        '12/09/2004 Jorge A. Guerrero
        Dim cmd As New SqlCommand("spCCVerificaSiEsHijo", conn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = _ClientePadre
        Try
            conn.Open()
            verificaSiEsPadre = Not (CType(cmd.ExecuteScalar, Boolean)) 'And CType(dreader("Padre"), Boolean) Then
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Function

End Class

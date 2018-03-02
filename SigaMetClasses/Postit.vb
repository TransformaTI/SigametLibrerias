Option Strict On
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing

Public Class Postit
    Inherits System.Windows.Forms.Form
    Private _Postit As Integer
    Private _UsuarioCaptura As String
    Private _TipoPostit As enumTipoPostit
    Private _PedidoReferencia As String
    Private _Cliente As Integer
    Private _Empresa As Integer
    Private _Clave As String
    Private _Usuario As String

    Private _Alta As Boolean
    Private _X As Integer
    Private _Y As Integer
    Private _FInicio As Date = Now.Date
    Private _FTermino As Date = Now.Date
    Private _FActualizacion As Date
    Private _FAlta As Date
    Private _Color As String
    Private _FontName As String = "Tahoma"
    Private _FontSize As Single = 8
    Private _FontColor As String = "Black"
    Private _Permanente As Boolean = True
    Private _Alarma As Boolean = False

    Private _TextoOriginal As String
    Private _HaCambiado As Boolean = False
    Private _DatosCargados As Boolean = False

    Private _TelCasa As String = ""
    Private _Contenedor As System.Windows.Forms.Form

    Public ReadOnly Property Postit() As Integer
        Get
            Return _Postit
        End Get
    End Property


    Public Sub New(ByVal Postit As Integer, _
          Optional ByVal Contenedor As Form = Nothing)

        'Modificación
        MyBase.New()
        InitializeComponent()
        _Postit = Postit

        _Alta = False
        CargaPostit(_Postit)


        If Not IsNothing(Contenedor) Then

            Contenedor.AddOwnedForm(Me)
            _Contenedor = Contenedor

        End If
        Me.txtTexto.Focus()

    End Sub

    Public Sub New(ByVal TipoPostit As enumTipoPostit, _
                   ByVal UsuarioCaptura As String, _
          Optional ByVal PedidoReferencia As String = "", _
          Optional ByVal Cliente As Integer = 0, _
          Optional ByVal Empresa As Integer = 0, _
          Optional ByVal Clave As String = "", _
          Optional ByVal Usuario As String = "", _
          Optional ByVal Contenedor As Form = Nothing)

        'Alta
        MyBase.New()
        InitializeComponent()
        _Alta = True
        _UsuarioCaptura = UsuarioCaptura
        _TipoPostit = TipoPostit

        _PedidoReferencia = PedidoReferencia
        _Cliente = Cliente
        _Empresa = Empresa
        _Clave = Clave
        _Usuario = Usuario

        _TextoOriginal = txtTexto.Text
        Me.Text = "Nueva nota"
        Me.lblAlarma.Image = Nothing
        Me.lblAlarma.Text = SigaMetClasses.FechaServidor.ToString
        txtTexto.Focus()

        If Not IsNothing(Contenedor) Then
            Contenedor.AddOwnedForm(Me)
        End If

    End Sub

#Region " Windows Form Designer generated code "


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
    Friend WithEvents txtTexto As System.Windows.Forms.TextBox
    Friend WithEvents imgLista16 As System.Windows.Forms.ImageList
    Friend WithEvents mnuPostit As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuGuardarCerrar As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConfiguracion As System.Windows.Forms.MenuItem
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents mnuBorrar As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblAlarma As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Postit))
        Me.txtTexto = New System.Windows.Forms.TextBox()
        Me.mnuPostit = New System.Windows.Forms.ContextMenu()
        Me.mnuConfiguracion = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.mnuGuardarCerrar = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.mnuBorrar = New System.Windows.Forms.MenuItem()
        Me.imgLista16 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblAlarma = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTexto
        '
        Me.txtTexto.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtTexto.AutoSize = False
        Me.txtTexto.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtTexto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTexto.ContextMenu = Me.mnuPostit
        Me.txtTexto.MaxLength = 200
        Me.txtTexto.Multiline = True
        Me.txtTexto.Name = "txtTexto"
        Me.txtTexto.Size = New System.Drawing.Size(184, 96)
        Me.txtTexto.TabIndex = 0
        Me.txtTexto.Text = "Escriba aquí su nota"
        '
        'mnuPostit
        '
        Me.mnuPostit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuConfiguracion, Me.MenuItem1, Me.mnuGuardarCerrar, Me.MenuItem3, Me.mnuBorrar})
        '
        'mnuConfiguracion
        '
        Me.mnuConfiguracion.Index = 0
        Me.mnuConfiguracion.Text = "Configuración..."
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 1
        Me.MenuItem1.Text = "-"
        '
        'mnuGuardarCerrar
        '
        Me.mnuGuardarCerrar.Index = 2
        Me.mnuGuardarCerrar.Text = "&Guardar y cerrar"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 3
        Me.MenuItem3.Text = "-"
        '
        'mnuBorrar
        '
        Me.mnuBorrar.Index = 4
        Me.mnuBorrar.Text = "Eliminar"
        '
        'imgLista16
        '
        Me.imgLista16.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista16.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista16.ImageStream = CType(resources.GetObject("imgLista16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista16.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(72, 56)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(8, 8)
        Me.btnCerrar.TabIndex = 1
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'lblAlarma
        '
        Me.lblAlarma.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblAlarma.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlarma.Image = CType(resources.GetObject("lblAlarma.Image"), System.Drawing.Bitmap)
        Me.lblAlarma.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblAlarma.Location = New System.Drawing.Point(0, 104)
        Me.lblAlarma.Name = "lblAlarma"
        Me.lblAlarma.Size = New System.Drawing.Size(184, 32)
        Me.lblAlarma.TabIndex = 4
        Me.lblAlarma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtTexto, Me.btnCerrar, Me.lblAlarma})
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(184, 144)
        Me.Panel1.TabIndex = 5
        '
        'Postit
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.LemonChiffon
        Me.ClientSize = New System.Drawing.Size(184, 144)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(280, 200)
        Me.MinimumSize = New System.Drawing.Size(176, 168)
        Me.Name = "Postit"
        Me.ShowInTaskbar = False
        Me.Text = "Nota"
        Me.TransparencyKey = System.Drawing.Color.DarkOrchid
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CargaPostit(ByVal Postit As Integer)
        Dim strQuery As String = _
        "SELECT p.Postit, p.Cliente, p.PedidoReferencia, " & _
        "p.Empresa, p.Clave, p.Usuario, p.Texto, p.Usuario, " & _
        "p.UsuarioCaptura, p.Ancho, p.Alto, p.X, p.Y, p.FInicio, p.FTermino, p.FActualizacion, p.FAlta, " & _
        "p.Permanente, p.Alarma, p.Color, p.FontName, p.FontSize, p.FontColor, Isnull(c.TelCasa,'') as TelCasa " & _
        "FROM Postit p LEFT JOIN Cliente c On p.Cliente = c.Cliente WHERE p.Postit = " & Postit.ToString
        Dim cmd As New SqlCommand(strQuery, DataLayer.Conexion)
        Dim dr As SqlDataReader = Nothing
        Cursor = Cursors.WaitCursor

        Try
            AbreConexion()
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dr.Read()

            If Not IsDBNull(dr("PedidoReferencia")) Then
                _TipoPostit = enumTipoPostit.Pedido
                _PedidoReferencia = Trim(CType(dr("PedidoReferencia"), String))
            End If

            If Not IsDBNull(dr("Cliente")) Then
                _TipoPostit = enumTipoPostit.Cliente
                _Cliente = CType(dr("Cliente"), Integer)
                Me.Text = "Cliente [" & _Cliente.ToString & "]"
            End If

            If Not IsDBNull(dr("Empresa")) Then
                _TipoPostit = enumTipoPostit.Empresa
                _Empresa = CType(dr("Empresa"), Integer)
            End If

            If Not IsDBNull(dr("Clave")) Then
                _TipoPostit = enumTipoPostit.MovimientoCaja
                _Clave = CType(dr("Clave"), String)
            End If

            If Not IsDBNull(dr("Usuario")) Then
                _TipoPostit = enumTipoPostit.Usuario
                _Usuario = CType(dr("Usuario"), String).Trim
            End If

            If Not IsDBNull(dr("FInicio")) Then _FInicio = CType(dr("FInicio"), Date)
            If Not IsDBNull(dr("FTermino")) Then _FTermino = CType(dr("FTermino"), Date)
            If Not IsDBNull(dr("FActualizacion")) Then _FActualizacion = CType(dr("FActualizacion"), Date)
            If Not IsDBNull(dr("FAlta")) Then _FAlta = CType(dr("FAlta"), Date)
            If Not IsDBNull(dr("Permanente")) Then _Permanente = CType(dr("Permanente"), Boolean)
            If Not IsDBNull(dr("Alarma")) Then _Alarma = CType(dr("Alarma"), Boolean)
            If Not IsDBNull(dr("Color")) Then _Color = CType(dr("Color"), String).Trim
            If Not IsDBNull(dr("FontName")) Then _FontName = CType(dr("FontName"), String).Trim
            If Not IsDBNull(dr("FontSize")) Then _FontSize = CType(dr("FontSize"), Single)
            If Not IsDBNull(dr("FontColor")) Then _FontColor = CType(dr("FontColor"), String).Trim
            If Not IsDBNull(dr("TelCasa")) Then _TelCasa = CType(dr("TelCasa"), String).Trim


            'Propiedades del texto de la nota
            _TextoOriginal = CType(dr("Texto"), String)

            txtTexto.Text = CType(dr("Texto"), String)
            txtTexto.BackColor = System.Drawing.Color.FromName(_Color)
            txtTexto.Font = New Font(_FontName, _FontSize)
            txtTexto.ForeColor = Color.FromName(_FontColor)

            _UsuarioCaptura = Trim(CType(dr("UsuarioCaptura"), String))

            lblAlarma.Text = Space(5) & "[" & _UsuarioCaptura & "] " & _FAlta.ToString

            If Not IsDBNull(_TelCasa) Then
                If Not IsNothing(_TelCasa) Then
                    If _TelCasa <> "" Then
                        lblAlarma.Text &= " Teléfono: " & FormatoTelefono(_TelCasa)
                    End If
                End If
            End If


            Try
                If Not IsDBNull(dr("Ancho")) Then Me.Width = CType(dr("Ancho"), Integer)
                If Not IsDBNull(dr("Alto")) Then Me.Height = CType(dr("Alto"), Integer)
                If Not IsDBNull(dr("X")) Then _X = CType(dr("X"), Integer)
                If Not IsDBNull(dr("Y")) Then _Y = CType(dr("Y"), Integer)

            Catch ex As Exception
                Me.Width = Me.Width
                Me.Height = Me.Height
            End Try

            'Es una alarma
            If _Alarma Then
                lblAlarma.Visible = True
                Timer1.Enabled = True
                Timer1.Start()
            Else
                lblAlarma.Image = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dr.Close()
            CierraConexion()
            cmd.Dispose()
            Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub Borrar()
        Dim cmd As New SqlCommand("DELETE Postit Where Postit = @Postit", DataLayer.Conexion)
        With cmd
            .CommandType = CommandType.Text
            .Parameters.Add("@Postit", SqlDbType.Int).Value = _Postit
        End With
        Try
            AbreConexion()
            cmd.ExecuteNonQuery()
            Me._HaCambiado = False
            Me.Close()

            If Not _Contenedor Is Nothing Then
                If _Contenedor.Name = "PostitLista" Then
                    CType(_Contenedor, PostitLista).Refrescar()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            CierraConexion()

        End Try
    End Sub

    Private Function AltaModifica(ByVal Tipo As enumTipoPostit, _
                                  ByVal Texto As String, _
                                  ByVal Alta As Boolean, _
                                  ByVal FInicio As Date, _
                                  ByVal FTermino As Date, _
                                  ByVal Color As String, _
                                  ByVal FontName As String, _
                                  ByVal FontSize As Single, _
                                  ByVal FontColor As String, _
                         Optional ByVal UsuarioCaptura As String = "", _
                         Optional ByVal PedidoReferencia As String = "", _
                         Optional ByVal Cliente As Integer = 0, _
                         Optional ByVal Empresa As Integer = 0, _
                         Optional ByVal Clave As String = "", _
                         Optional ByVal Usuario As String = "", _
                         Optional ByVal Ancho As Integer = 0, _
                         Optional ByVal Alto As Integer = 0, _
                         Optional ByVal X As Integer = 0, _
                         Optional ByVal Y As Integer = 0, _
                         Optional ByVal Permanente As Boolean = True, _
                         Optional ByVal Alarma As Boolean = False) As Integer

        Cursor = Cursors.WaitCursor
        Dim cmd As New SqlCommand("spPostitAltaModifica")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 60
            .Parameters.Clear()
            .Parameters.Add("@Texto", SqlDbType.VarChar, 500).Value = Texto
            .Parameters.Add("@Ancho", SqlDbType.SmallInt).Value = Ancho
            .Parameters.Add("@Alto", SqlDbType.SmallInt).Value = Alto
            .Parameters.Add("@FInicio", SqlDbType.DateTime).Value = FInicio
            .Parameters.Add("@FTermino", SqlDbType.DateTime).Value = FTermino
            .Parameters.Add("@Color", SqlDbType.VarChar, 50).Value = Color
            .Parameters.Add("@FontName", SqlDbType.VarChar, 20).Value = FontName
            .Parameters.Add("@FontSize", SqlDbType.Int).Value = FontSize
            .Parameters.Add("@FontColor", SqlDbType.VarChar, 50).Value = FontColor
            .Parameters.Add("@X", SqlDbType.Int).Value = X
            .Parameters.Add("@Y", SqlDbType.Int).Value = Y
            .Parameters.Add("@Permanente", SqlDbType.Bit).Value = Permanente
            .Parameters.Add("@Alarma", SqlDbType.Bit).Value = Alarma
            If UsuarioCaptura <> "" Then
                .Parameters.Add("@UsuarioCaptura", SqlDbType.VarChar, 50).Value = UsuarioCaptura
            End If
            If Alta = False Then
                .Parameters.Add("@Postit", SqlDbType.Int).Value = Postit
                .Parameters.Add("@Alta", SqlDbType.Bit).Value = Alta
            Else
                .Parameters.Add("@NuevoPostit", SqlDbType.Int).Direction = ParameterDirection.Output
            End If

        End With


        Select Case Tipo
            Case enumTipoPostit.Pedido
                cmd.Parameters.Add("@PedidoReferencia", SqlDbType.Char, 15).Value = PedidoReferencia
            Case enumTipoPostit.Cliente
                cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
            Case enumTipoPostit.Empresa
                cmd.Parameters.Add("@Empresa", SqlDbType.Int).Value = Empresa
            Case enumTipoPostit.MovimientoCaja
                cmd.Parameters.Add("@Clave", SqlDbType.VarChar, 20).Value = Clave
            Case enumTipoPostit.Usuario
                cmd.Parameters.Add("@Usuario", SqlDbType.Char, 15).Value = Usuario
        End Select

        Try
            cmd.Connection = DataLayer.Conexion
            AbreConexion()
            cmd.ExecuteNonQuery()

            If Alta = True Then
                Dim _NuevoPostit As Integer = CType(cmd.Parameters("@NuevoPostit").Value, Integer)
                Return _NuevoPostit
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CierraConexion()
            'cmd.Dispose()
            Cursor = Cursors.Default
        End Try
    End Function

    Public Enum enumTipoPostit
        Pedido = 1
        Cliente = 2
        Empresa = 3
        MovimientoCaja = 4
        Usuario = 5
    End Enum

    Private Sub Postit_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If _HaCambiado Then
            Me.Timer1.Stop()

            AltaModifica(Tipo:=_TipoPostit, _
                                Texto:=txtTexto.Text, _
                                Alta:=_Alta, _
                                FInicio:=_FInicio, _
                                FTermino:=_FTermino, _
                                Color:=_Color, _
                                FontName:=_FontName, _
                                FontSize:=_FontSize, _
                                FontColor:=_FontColor, _
                                UsuarioCaptura:=_UsuarioCaptura, _
                                PedidoReferencia:=_PedidoReferencia, _
                                Cliente:=_Cliente, _
                                Empresa:=_Empresa, _
                                Clave:=_Clave, _
                                Usuario:=_Usuario, _
                                Ancho:=Me.Width, _
                                Alto:=Me.Height, _
                                X:=Me.Top, _
                                Y:=Me.Left, _
                                Permanente:=_Permanente, _
                                Alarma:=_Alarma)

            Me.Owner.Focus()
        End If
    End Sub

    Private Sub mnuGuardarCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGuardarCerrar.Click
        Me.Close()
    End Sub

    Private Sub Postit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = _X
        Me.Left = _Y
        _Color = Replace(Replace(txtTexto.BackColor.ToString, "Color [", ""), "]", "")
        _DatosCargados = True
    End Sub

    Private Sub CambiaFont()
        txtTexto.ForeColor = Color.FromName(_FontColor)
        txtTexto.Font = New Font(_FontName, _FontSize)
    End Sub

    Private Sub mnuConfiguracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConfiguracion.Click
        Dim oConfig As PostitConfiguracion
        oConfig = New PostitConfiguracion(_FInicio, _FTermino, _Permanente, _Alarma, _Color, _FontName, _FontSize, _FontColor)

        If oConfig.ShowDialog() = DialogResult.OK Then
            _FInicio = oConfig.FInicio
            _FTermino = oConfig.FTermino
            _Permanente = oConfig.Permanente
            _Alarma = oConfig.Alarma

            _Color = Replace(Replace(oConfig.NotaColor, "Color [", ""), "]", "")

            _FontName = oConfig.FontName
            _FontSize = oConfig.FontSize
            _FontColor = oConfig.FontColor

            _HaCambiado = oConfig.HaCambiado

            txtTexto.BackColor = System.Drawing.Color.FromName(_Color)

            CambiaFont()

        End If

    End Sub

    Private Sub txtTexto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTexto.TextChanged
        If _DatosCargados Then
            If _TextoOriginal <> txtTexto.Text Then
                _HaCambiado = True
            End If
        End If

    End Sub

    Private Sub Postit_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Move
        If _DatosCargados Then
            _HaCambiado = True
        End If
    End Sub

    Private Sub Postit_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If _DatosCargados Then
            _HaCambiado = True
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub Postit_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.Panel1.BorderStyle = BorderStyle.None
        Me.FormBorderStyle = FormBorderStyle.SizableToolWindow
        Me.Refresh()
        Me.Owner.Refresh()
    End Sub

    Private Sub Postit_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Try
            Me.Panel1.BorderStyle = BorderStyle.FixedSingle
            Me.FormBorderStyle = FormBorderStyle.None
            Me.Owner.Refresh()
        Catch
            Me.Refresh()
        End Try

    End Sub

    Private Sub txtTexto_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTexto.MouseEnter
        Me.Panel1.BorderStyle = BorderStyle.None
        Me.FormBorderStyle = FormBorderStyle.SizableToolWindow
        Me.Refresh()
        Me.Owner.Refresh()
    End Sub

    Private Sub mnuBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBorrar.Click
        Me.Borrar()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If lblAlarma.Visible = True Then
            lblAlarma.Visible = False
        Else
            lblAlarma.Visible = True
        End If

    End Sub

    Private Sub txtTexto_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTexto.BackColorChanged
        Me.BackColor = txtTexto.BackColor
        lblAlarma.BackColor = txtTexto.BackColor
    End Sub

End Class
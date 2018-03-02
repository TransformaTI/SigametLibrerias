'Modificó: Carlos Lavariega
'Descripción: Se modifico el constructor para consultar el usuario parametrizado que servira para la consulta
'               de reportes y se elimine el usuario "SIGAREP"
'Id. de cambios: 20060228CFSL$001

'Modificó: Julio Morales
'Fecha 25/06/2015
'Descripción: Se Modificaron los Constructores para que Verifiquen si el Usuario a Utilizar para la Visualización
'             de Reportes sea SIGAREP o el Usuario que está Logueado
'             Se Agregaron Validaciones para ocultar o mostrar el Botón de Imprimir Reporte y de Exportar Reporte
'Id. de cambios: 20150625JMV$001


Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class frmListaReporte
    Inherits System.Windows.Forms.Form

#Region "Variables locales"
    Private rptReporte As New ReportDocument()
    Private ParametrosDelReporte As ParameterFieldDefinitions
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo
    Private _Servidor As String
    Private _BaseDeDatos As String
    Private _UsuarioModulo As String
    Private _UserID As String
    Private _Password As String
    Private _Modulo As Short
    Private _Corporativo As Short
    Private _Sucursal As Short
    Private _UsaSeguridad As Boolean
    Private RutaReportes As String
    Private _connection As SqlConnection
    Private UsuarioReportes As String
    'Id. de cambios: 20150625JMV$001-----------------
    Private _list As New List(Of Integer)
    Private _privilegio As Boolean
    'Id. de cambios: 20150625JMV$001-----------------

#End Region


    Public Sub New(ByVal Modulo As Short, _
                   ByVal strRutaReportes As String, _
                   ByVal NombreServidor As String, _
                   ByVal NombreBaseDeDatos As String, _
                   ByVal UsuarioModulo As String, _
                   ByVal Conexion As SqlConnection, _
          Optional ByVal UsaSeguridad As Boolean = False)

        MyBase.New()
        InitializeComponent()
        'NombreServidor y NombreBaseDeDatos se usan siempre y cuando el registro en la tabla UsuarioReporte
        'o GrupoReporte tenga null
        _Modulo = Modulo
        Dim oConfig As SigaMetClasses.cConfig
        Try
            oConfig = New SigaMetClasses.cConfig(_Modulo)
            Main.GLOBAL_NombreModulo = oConfig.ModuloNombre
        Catch ex As Exception
            Main.GLOBAL_NombreModulo = ""
        Finally
            oConfig.Dispose()
        End Try
        '20060228CFSL$001-----------------
        oConfig = New SigaMetClasses.cConfig(9)
        UsuarioReportes = CStr(oConfig.Parametros("UsuarioReportes")).Trim
        Dim oUsuarioReportes As New SigaMetClasses.cUserInfo()
        oUsuarioReportes.ConsultaDatosUsuarioReportes(UsuarioReportes)
        '20060228CFSL$001-----------------

        ' Consulta del usuario parametrizado

        RutaReportes = strRutaReportes
        _Servidor = NombreServidor
        _BaseDeDatos = NombreBaseDeDatos
        _UsuarioModulo = UsuarioModulo
        '20060228CFSL$001-----------------
        _UserID = oUsuarioReportes.User
        _Password = oUsuarioReportes.Password
        '_UserID = "sigarep"
        '_Password = "sigarep"
        '20060228CFSL$001-----------------
        _connection = Conexion
        _UsaSeguridad = UsaSeguridad
        Me.Text = "Reportes dinámicos"

        'Id. de cambios: 20150625JMV$001-----------------
        Dim TipoConexion As String
        TipoConexion = CStr(oConfig.Parametros("InicioActualSesion"))

        If CInt(TipoConexion) = 0 Then
            _UserID = oUsuarioReportes.User
            _Password = oUsuarioReportes.Password
        Else
            Dim oUsuarioModulo As New SigaMetClasses.cUserInfo()
            oUsuarioModulo.ConsultaDatosUsuarioReportes(UsuarioModulo)
            _UserID = oUsuarioModulo.User
            _Password = oUsuarioModulo.Password
        End If
        _privilegio = CargarPrivilegios()
        'Id. de cambios: 20150625JMV$001-----------------
    End Sub


    Public Sub New(ByVal Modulo As Short, _
               ByVal strRutaReportes As String, _
               ByVal NombreServidor As String, _
               ByVal NombreBaseDeDatos As String, _
               ByVal UsuarioModulo As String, _
               ByVal Conexion As SqlConnection, _
               ByVal Corporativo As Short, _
               ByVal Sucursal As Short, _
               Optional ByVal UsaSeguridad As Boolean = False)

        MyBase.New()
        InitializeComponent()
        'NombreServidor y NombreBaseDeDatos se usan siempre y cuando el registro en la tabla UsuarioReporte
        'o GrupoReporte tenga null
        _Modulo = Modulo
        _Corporativo = Corporativo
        _Sucursal = Sucursal
        Dim oConfig As SigaMetClasses.cConfig
        Try
            oConfig = New SigaMetClasses.cConfig(_Modulo, _Corporativo, _Sucursal)
            Main.GLOBAL_NombreModulo = oConfig.ModuloNombre
        Catch ex As Exception
            Main.GLOBAL_NombreModulo = ""
        Finally
            oConfig.Dispose()
        End Try
        '20060228CFSL$001-----------------
        oConfig = New SigaMetClasses.cConfig(9, _Corporativo, _Sucursal)
        UsuarioReportes = CStr(oConfig.Parametros("UsuarioReportes")).Trim
        Dim oUsuarioReportes As New SigaMetClasses.cUserInfo()
        oUsuarioReportes.ConsultaDatosUsuarioReportes(UsuarioReportes)
        '20060228CFSL$001-----------------

        ' Consulta del usuario parametrizado

        RutaReportes = strRutaReportes
        _Servidor = NombreServidor
        _BaseDeDatos = NombreBaseDeDatos
        _UsuarioModulo = UsuarioModulo
        '20060228CFSL$001-----------------
        _UserID = oUsuarioReportes.User
        _Password = oUsuarioReportes.Password
        '_UserID = "sigarep"
        '_Password = "sigarep"
        '20060228CFSL$001-----------------
        _connection = Conexion
        _UsaSeguridad = UsaSeguridad
        Me.Text = "Reportes dinámicos"

        'Id. de cambios: 20150625JMV$001-----------------
        Dim TipoConexion As String
        TipoConexion = CStr(oConfig.Parametros("InicioActualSesion"))

        If CInt(TipoConexion) = 0 Then
            _UserID = oUsuarioReportes.User
            _Password = oUsuarioReportes.Password
        Else
            Dim oUsuarioModulo As New SigaMetClasses.cUserInfo()
            oUsuarioModulo.ConsultaDatosUsuarioReportes(UsuarioModulo)
            _UserID = oUsuarioModulo.User
            _Password = oUsuarioModulo.Password
        End If
        _privilegio = CargarPrivilegios()
        'Id. de cambios: 20150625JMV$001-----------------
    End Sub


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
    Friend WithEvents lvwReporte As System.Windows.Forms.ListView
    Friend WithEvents imgLista32 As System.Windows.Forms.ImageList
    Friend WithEvents imgLista16 As System.Windows.Forms.ImageList
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTema As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblRutaReportes As System.Windows.Forms.Label
    Friend WithEvents lblFActualizacion As System.Windows.Forms.Label
    Friend WithEvents btnRefrescar As System.Windows.Forms.Button
    Friend WithEvents ttMensaje As System.Windows.Forms.ToolTip
    Friend WithEvents PanelAcercade As System.Windows.Forms.Panel
    Friend WithEvents lblServidor As System.Windows.Forms.Label
    Friend WithEvents lblBaseDatos As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grpInfoConexion As System.Windows.Forms.GroupBox
    Friend WithEvents btnCambiarVista As System.Windows.Forms.Button
    Friend WithEvents colReporte As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDescripcion As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFActualizacion As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmListaReporte))
        Me.lvwReporte = New System.Windows.Forms.ListView()
        Me.imgLista32 = New System.Windows.Forms.ImageList(Me.components)
        Me.imgLista16 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.lblFActualizacion = New System.Windows.Forms.Label()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTema = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblRutaReportes = New System.Windows.Forms.Label()
        Me.btnRefrescar = New System.Windows.Forms.Button()
        Me.ttMensaje = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblServidor = New System.Windows.Forms.Label()
        Me.lblBaseDatos = New System.Windows.Forms.Label()
        Me.PanelAcercade = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grpInfoConexion = New System.Windows.Forms.GroupBox()
        Me.btnCambiarVista = New System.Windows.Forms.Button()
        Me.colReporte = New System.Windows.Forms.ColumnHeader()
        Me.colDescripcion = New System.Windows.Forms.ColumnHeader()
        Me.colFActualizacion = New System.Windows.Forms.ColumnHeader()
        Me.grpInfoConexion.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvwReporte
        '
        Me.lvwReporte.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lvwReporte.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colReporte, Me.colDescripcion, Me.colFActualizacion})
        Me.lvwReporte.FullRowSelect = True
        Me.lvwReporte.LargeImageList = Me.imgLista32
        Me.lvwReporte.Location = New System.Drawing.Point(8, 32)
        Me.lvwReporte.MultiSelect = False
        Me.lvwReporte.Name = "lvwReporte"
        Me.lvwReporte.Size = New System.Drawing.Size(432, 504)
        Me.lvwReporte.SmallImageList = Me.imgLista16
        Me.lvwReporte.TabIndex = 0
        Me.lvwReporte.View = System.Windows.Forms.View.Details
        '
        'imgLista32
        '
        Me.imgLista32.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista32.ImageSize = New System.Drawing.Size(32, 32)
        Me.imgLista32.ImageStream = CType(resources.GetObject("imgLista32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista32.TransparentColor = System.Drawing.Color.Transparent
        '
        'imgLista16
        '
        Me.imgLista16.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista16.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista16.ImageStream = CType(resources.GetObject("imgLista16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista16.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnCargar
        '
        Me.btnCargar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCargar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCargar.Enabled = False
        Me.btnCargar.Image = CType(resources.GetObject("btnCargar.Image"), System.Drawing.Bitmap)
        Me.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCargar.Location = New System.Drawing.Point(560, 272)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.TabIndex = 1
        Me.btnCargar.Text = "Car&gar"
        Me.btnCargar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttMensaje.SetToolTip(Me.btnCargar, "Carga el reporte seleccionado")
        '
        'lblFActualizacion
        '
        Me.lblFActualizacion.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblFActualizacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFActualizacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFActualizacion.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblFActualizacion.Location = New System.Drawing.Point(560, 224)
        Me.lblFActualizacion.Name = "lblFActualizacion"
        Me.lblFActualizacion.Size = New System.Drawing.Size(256, 21)
        Me.lblFActualizacion.TabIndex = 3
        Me.lblFActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ttMensaje.SetToolTip(Me.lblFActualizacion, "Fecha de última actualización del reporte")
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescripcion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblDescripcion.Location = New System.Drawing.Point(560, 112)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(256, 80)
        Me.lblDescripcion.TabIndex = 2
        Me.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ttMensaje.SetToolTip(Me.lblDescripcion, "Descripción del reporte")
        '
        'lblReporte
        '
        Me.lblReporte.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblReporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblReporte.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporte.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblReporte.Location = New System.Drawing.Point(560, 88)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(256, 21)
        Me.lblReporte.TabIndex = 5
        Me.lblReporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ttMensaje.SetToolTip(Me.lblReporte, "Título del reporte")
        '
        'Label4
        '
        Me.Label4.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(480, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Descripción:"
        '
        'Label5
        '
        Me.Label5.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(480, 227)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 14)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Actualizado el:"
        '
        'Label6
        '
        Me.Label6.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(480, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 14)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Reporte:"
        '
        'lblTema
        '
        Me.lblTema.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblTema.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTema.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTema.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblTema.Location = New System.Drawing.Point(560, 200)
        Me.lblTema.Name = "lblTema"
        Me.lblTema.Size = New System.Drawing.Size(256, 21)
        Me.lblTema.TabIndex = 9
        Me.lblTema.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ttMensaje.SetToolTip(Me.lblTema, "Tema(s) del reporte")
        '
        'Label2
        '
        Me.Label2.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(480, 203)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 14)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Tema:"
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(648, 272)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.TabIndex = 11
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttMensaje.SetToolTip(Me.btnCerrar, "Cierra esta ventana")
        '
        'lblRutaReportes
        '
        Me.lblRutaReportes.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblRutaReportes.BackColor = System.Drawing.Color.Cornsilk
        Me.lblRutaReportes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRutaReportes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutaReportes.ForeColor = System.Drawing.Color.Purple
        Me.lblRutaReportes.Location = New System.Drawing.Point(8, 8)
        Me.lblRutaReportes.Name = "lblRutaReportes"
        Me.lblRutaReportes.Size = New System.Drawing.Size(432, 21)
        Me.lblRutaReportes.TabIndex = 12
        Me.lblRutaReportes.Text = "Lista de reportes"
        Me.lblRutaReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ttMensaje.SetToolTip(Me.lblRutaReportes, "Total de reportes encontrados en la ruta")
        '
        'btnRefrescar
        '
        Me.btnRefrescar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnRefrescar.BackColor = System.Drawing.SystemColors.Control
        Me.btnRefrescar.Image = CType(resources.GetObject("btnRefrescar.Image"), System.Drawing.Bitmap)
        Me.btnRefrescar.Location = New System.Drawing.Point(448, 8)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(24, 21)
        Me.btnRefrescar.TabIndex = 13
        Me.ttMensaje.SetToolTip(Me.btnRefrescar, "Refrescar la lista de reportes")
        '
        'lblServidor
        '
        Me.lblServidor.BackColor = System.Drawing.Color.Gainsboro
        Me.lblServidor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServidor.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblServidor.Location = New System.Drawing.Point(104, 18)
        Me.lblServidor.Name = "lblServidor"
        Me.lblServidor.Size = New System.Drawing.Size(136, 21)
        Me.lblServidor.TabIndex = 14
        Me.lblServidor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ttMensaje.SetToolTip(Me.lblServidor, "Información de la conexión en donde se ejecutarán los reportes")
        '
        'lblBaseDatos
        '
        Me.lblBaseDatos.BackColor = System.Drawing.Color.Gainsboro
        Me.lblBaseDatos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaseDatos.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblBaseDatos.Location = New System.Drawing.Point(104, 40)
        Me.lblBaseDatos.Name = "lblBaseDatos"
        Me.lblBaseDatos.Size = New System.Drawing.Size(136, 21)
        Me.lblBaseDatos.TabIndex = 16
        Me.lblBaseDatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ttMensaje.SetToolTip(Me.lblBaseDatos, "Información de la conexión en donde se ejecutarán los reportes")
        '
        'PanelAcercade
        '
        Me.PanelAcercade.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.PanelAcercade.Location = New System.Drawing.Point(440, 528)
        Me.PanelAcercade.Name = "PanelAcercade"
        Me.PanelAcercade.Size = New System.Drawing.Size(8, 8)
        Me.PanelAcercade.TabIndex = 15
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Bitmap)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Bitmap)
        Me.PictureBox2.Location = New System.Drawing.Point(8, 42)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 18
        Me.PictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 14)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Servidor:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(24, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 14)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Base de datos:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpInfoConexion
        '
        Me.grpInfoConexion.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.grpInfoConexion.Controls.AddRange(New System.Windows.Forms.Control() {Me.PictureBox1, Me.PictureBox2, Me.lblServidor, Me.Label3, Me.Label1, Me.lblBaseDatos})
        Me.grpInfoConexion.Location = New System.Drawing.Point(560, 8)
        Me.grpInfoConexion.Name = "grpInfoConexion"
        Me.grpInfoConexion.Size = New System.Drawing.Size(256, 72)
        Me.grpInfoConexion.TabIndex = 21
        Me.grpInfoConexion.TabStop = False
        Me.grpInfoConexion.Text = "Información para la conexión"
        '
        'btnCambiarVista
        '
        Me.btnCambiarVista.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCambiarVista.BackColor = System.Drawing.SystemColors.Control
        Me.btnCambiarVista.Image = CType(resources.GetObject("btnCambiarVista.Image"), System.Drawing.Bitmap)
        Me.btnCambiarVista.Location = New System.Drawing.Point(448, 32)
        Me.btnCambiarVista.Name = "btnCambiarVista"
        Me.btnCambiarVista.Size = New System.Drawing.Size(24, 23)
        Me.btnCambiarVista.TabIndex = 22
        Me.ttMensaje.SetToolTip(Me.btnCambiarVista, "Cambiar el tipo de vista")
        '
        'colReporte
        '
        Me.colReporte.Text = "Reporte"
        Me.colReporte.Width = 280
        '
        'colDescripcion
        '
        Me.colDescripcion.Text = "Descripción"
        Me.colDescripcion.Width = 180
        '
        'colFActualizacion
        '
        Me.colFActualizacion.Text = "F.Actualización"
        Me.colFActualizacion.Width = 140
        '
        'frmListaReporte
        '
        Me.AcceptButton = Me.btnCargar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(824, 549)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCambiarVista, Me.grpInfoConexion, Me.PanelAcercade, Me.btnRefrescar, Me.lblRutaReportes, Me.btnCerrar, Me.lblTema, Me.Label2, Me.lblReporte, Me.lblFActualizacion, Me.lblDescripcion, Me.btnCargar, Me.lvwReporte, Me.Label6, Me.Label5, Me.Label4})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(832, 576)
        Me.Name = "frmListaReporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reportes"
        Me.grpInfoConexion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub CargaListaReportes()

        lblServidor.Text = ""
        lblBaseDatos.Text = ""
        lblReporte.Text = ""
        lblDescripcion.Text = ""
        lblTema.Text = ""
        lblFActualizacion.Text = ""
        btnCargar.Enabled = False

        Me.Refresh()
        lvwReporte.Items.Clear()
        Dim strReporte As String, strDescripcion As String

        If Not Directory.Exists(RutaReportes) Then
            MessageBox.Show("La ruta " & RutaReportes & " no existe o es inválida.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        lblRutaReportes.Text = "Cargando..."

        'Valida si se usa el mecanismo de seguridad        
        If _UsaSeguridad Then
            Dim strQuery As String = _
                    "exec spSEGUsuarioReportes " & _Modulo & ",'" & _UsuarioModulo & "'"
            Dim da As New SqlDataAdapter(strQuery, _connection)
            Dim dt As New DataTable("UsuarioReporte")

            Try
                da.Fill(dt)
            
                For Each strReporte In Directory.GetFiles(RutaReportes, "*.rpt")
                    'UsuarioReporte
                    'Valido si el usuario tiene el reporte asignado en la tabla
                    dt.DefaultView.RowFilter = "Reporte = '" & strReporte & "'"
                    If dt.DefaultView.Count > 0 Then
                        rptReporte.Load(strReporte)

                        Dim oRep As New Reporte()
                        If rptReporte.SummaryInfo.ReportTitle = "" Then
                            oRep.Text = Replace(strReporte, RutaReportes & "\", "")
                        Else
                            oRep.Text = rptReporte.SummaryInfo.ReportTitle
                        End If

                        oRep.Path = strReporte
                        oRep.Tema = rptReporte.SummaryInfo.ReportSubject
                        oRep.Comentario = rptReporte.SummaryInfo.ReportComments
                        oRep.FActualizacion = File.GetLastWriteTime(strReporte)

                        'Aquí se valida si se usa el dato de la tabla o uso el dato
                        'del parámetro que se pasó
                        '19 de enero del 2004

                        If Not IsDBNull(dt.DefaultView(0).Item("Servidor")) Then
                            oRep.Servidor = CType(dt.DefaultView(0).Item("Servidor"), String).Trim
                        Else
                            oRep.Servidor = _Servidor
                        End If

                        If Not IsDBNull(dt.DefaultView(0).Item("BaseDatos")) Then
                            oRep.BaseDatos = CType(dt.DefaultView(0).Item("BaseDatos"), String).Trim
                        Else
                            oRep.BaseDatos = _BaseDeDatos
                        End If

                        oRep.ImageIndex = 0
                        oRep.SubItems.Add(oRep.Comentario)
                        oRep.SubItems.Add(CType(oRep.FActualizacion, String))

                        lvwReporte.Items.Add(oRep)
                    End If
                Next

            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            'No usa el mecanismo de seguridad
            Try
                For Each strReporte In Directory.GetFiles(RutaReportes, "*.rpt")
                    rptReporte.Load(strReporte)

                    Dim oRep As New Reporte()
                    If rptReporte.SummaryInfo.ReportTitle = "" Then
                        oRep.Text = Replace(strReporte, RutaReportes & "\", "")
                    Else
                        oRep.Text = rptReporte.SummaryInfo.ReportTitle
                    End If


                    'Se asigna el nombre del servidor y base de datos predeterminada
                    'ya que no se usa la seguridad.
                    oRep.Servidor = _Servidor
                    oRep.BaseDatos = _BaseDeDatos
                    oRep.Path = strReporte
                    oRep.Tema = rptReporte.SummaryInfo.ReportSubject
                    oRep.Comentario = rptReporte.SummaryInfo.ReportComments
                    oRep.FActualizacion = File.GetLastWriteTime(strReporte)

                    oRep.SubItems.Add(oRep.Comentario)
                    oRep.SubItems.Add(CType(oRep.FActualizacion, String))
                    oRep.ImageIndex = 0
                    lvwReporte.Items.Add(oRep)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try                    
        End If

        lvwReporte.Sorting = CType(SortOrder.Ascending, Windows.Forms.SortOrder) '.NET 2.0
        lblRutaReportes.Text = "Lista de reportes (" & Me.lvwReporte.Items.Count.ToString & ") de: " & RutaReportes


        Cursor = Cursors.Default
    End Sub

    Private Sub frmListaReporte_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaListaReportes()
    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        'Id. de cambios: 20150625JMV$001-----------------
        If _privilegio Then
            CargaReporte()
        Else
            MessageBox.Show("El usuario no tiene privilegios para usar este módulo", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        'Id. de cambios: 20150625JMV$001-----------------
    End Sub

    Private Sub CargaReporte()        
        If Not lvwReporte.FocusedItem Is Nothing Then
            Cursor = Cursors.WaitCursor
            Dim NuevoReporte As New frmReporte(CType(lvwReporte.FocusedItem, Reporte).Path, _
                                    lvwReporte.FocusedItem.Text, _
                                    CType(lvwReporte.FocusedItem, Reporte).Servidor, _
                                    CType(lvwReporte.FocusedItem, Reporte).BaseDatos, _
                                    _UserID, _
                                    _Password, _
                                    _connection, _
                                    _list)
            NuevoReporte.WindowState = FormWindowState.Maximized
            NuevoReporte.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub lvwReporte_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwReporte.SelectedIndexChanged
        Try
            Cursor = Cursors.WaitCursor
            If lvwReporte.FocusedItem Is Nothing = False Then
                If btnCargar.Enabled = False Then btnCargar.Enabled = True
                lblServidor.Text = CType(lvwReporte.FocusedItem, Reporte).Servidor
                lblBaseDatos.Text = CType(lvwReporte.FocusedItem, Reporte).BaseDatos
                lblReporte.Text = lvwReporte.FocusedItem.Text
                lblDescripcion.Text = CType(lvwReporte.FocusedItem, Reporte).Comentario
                lblTema.Text = CType(lvwReporte.FocusedItem, Reporte).Tema
                lblFActualizacion.Text = CType(lvwReporte.FocusedItem, Reporte).FActualizacion.ToString
            End If
        Catch ex As Exception
            btnCargar.Enabled = False
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefrescar.Click
        CargaListaReportes()
    End Sub

    Private Sub lvwReporte_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwReporte.DoubleClick
        CargaReporte()
    End Sub

    Private Sub PanelAcercade_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelAcercade.Click
        Dim frmAbout As New frmAcercade()
        frmAbout.ShowDialog()
    End Sub

    Private Sub btnCambiarVista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambiarVista.Click
        Select Case lvwReporte.View
            Case View.List
                lvwReporte.View = View.Details

            Case View.Details
                lvwReporte.View = View.SmallIcon

            Case View.SmallIcon
                lvwReporte.View = View.LargeIcon
                lvwReporte.Font = New Font("Tahoma", 7)

            Case View.LargeIcon
                lvwReporte.View = View.List
                lvwReporte.Font = New Font("Tahoma", 8)
        End Select
    End Sub

    'Id. de cambios: 20150625JMV$001-----------------
    Private Function CargarPrivilegios() As Boolean
        Dim sqlQuery As New SqlClient.SqlCommand()
        Dim daAcceso As New SqlClient.SqlDataAdapter()
        Dim dtOperaciones As New DataTable()
        Dim Rw As DataRow
        daAcceso.SelectCommand = sqlQuery
        sqlQuery.CommandText = "exec spSEGOperacionesUsuarioModulo " & _UserID & "," & 9 '
        sqlQuery.Connection = _connection

        Try
            daAcceso.Fill(dtOperaciones)
            If dtOperaciones.Rows.Count = 0 Then
                'MessageBox.Show("El usuario no tiene privilegios para usar este módulo", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                sqlQuery.Connection.Close()
                Return False
            End If
            For Each Rw In dtOperaciones.Rows
                _list.Add(CInt(Rw(0)))
            Next
        Catch err As Exception
            MessageBox.Show("Ocurrió el siguiente error:" & Chr(13) & err.ToString, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        sqlQuery.Connection.Close()
        Return True
    End Function
    'Id. de cambios: 20150625JMV$001-----------------

End Class

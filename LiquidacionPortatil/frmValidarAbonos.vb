Imports System.Windows.Forms
Imports System.Drawing

Public Class frmValidarAbonos
    Inherits System.Windows.Forms.Form
    Private _FolioCobro As Integer
    Private _AnoCobro As Integer
    Private _FolioNota As Integer
    Private _Cliente As Integer
    Private _Nombre As String
    Private _Ruta As String
    Private _Importe As Decimal
    Private _FCobro As DateTime
    Private _Abono As Decimal

    Private _CajaUsuario As Byte
    Private _Usuario As String
    Private _Servidor As String
    Private _Database As String
    Private _Password As String
    Private _CorporativoUsuario As Short
    Private _SucursalUsuario As Short
    Private _RutaReportes As String


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal FolioCobro As Integer, ByVal AñoCobro As Integer, ByVal FolioNota As Integer, ByVal Cliente As Integer, ByVal Importe As Decimal, ByVal FCobro As DateTime, ByVal Usuario As String, ByVal Caja As Byte, ByVal Servidor As String, ByVal DBase As String, ByVal Password As String, ByVal CorporativoUsuario As Short, ByVal SucursalUsuario As Short)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        _FolioCobro = FolioCobro
        _AnoCobro = AñoCobro
        _FolioNota = FolioNota
        _Cliente = Cliente
        _Importe = Importe
        _FCobro = FCobro
        _Usuario = Usuario
        _CajaUsuario = Caja

        _Servidor = Servidor
        _Database = DBase
        _Password = Password
        _CorporativoUsuario = CorporativoUsuario
        _SucursalUsuario = SucursalUsuario

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
    Friend WithEvents grbInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents lblRutatck As System.Windows.Forms.Label
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblNombretck As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblImportetck As System.Windows.Forms.Label
    Friend WithEvents lblImporte As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtAbono As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblFCobrotck As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents dtpFCobro As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEmpresatck As System.Windows.Forms.Label
    Friend WithEvents lblFolioNotatck As System.Windows.Forms.Label
    Friend WithEvents lblFolioNota As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmValidarAbonos))
        Me.grbInformacion = New System.Windows.Forms.GroupBox()
        Me.lblFolioNota = New System.Windows.Forms.Label()
        Me.lblFolioNotatck = New System.Windows.Forms.Label()
        Me.dtpFCobro = New System.Windows.Forms.DateTimePicker()
        Me.lblEmpresatck = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblImporte = New System.Windows.Forms.Label()
        Me.lblImportetck = New System.Windows.Forms.Label()
        Me.lblFCobrotck = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblNombretck = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.lblRutatck = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtAbono = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.grbInformacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbInformacion
        '
        Me.grbInformacion.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFolioNota, Me.lblFolioNotatck, Me.dtpFCobro, Me.lblEmpresatck, Me.lblEmpresa, Me.Label12, Me.lblImporte, Me.lblImportetck, Me.lblFCobrotck, Me.lblNombre, Me.lblNombretck, Me.lblCliente, Me.lblRuta, Me.lblRutatck})
        Me.grbInformacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbInformacion.Location = New System.Drawing.Point(16, 16)
        Me.grbInformacion.Name = "grbInformacion"
        Me.grbInformacion.Size = New System.Drawing.Size(488, 240)
        Me.grbInformacion.TabIndex = 27
        Me.grbInformacion.TabStop = False
        '
        'lblFolioNota
        '
        Me.lblFolioNota.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFolioNota.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioNota.Location = New System.Drawing.Point(128, 138)
        Me.lblFolioNota.Name = "lblFolioNota"
        Me.lblFolioNota.Size = New System.Drawing.Size(240, 21)
        Me.lblFolioNota.TabIndex = 78
        Me.lblFolioNota.Text = "FolioNota"
        Me.lblFolioNota.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFolioNotatck
        '
        Me.lblFolioNotatck.Location = New System.Drawing.Point(16, 142)
        Me.lblFolioNotatck.Name = "lblFolioNotatck"
        Me.lblFolioNotatck.Size = New System.Drawing.Size(112, 21)
        Me.lblFolioNotatck.TabIndex = 77
        Me.lblFolioNotatck.Text = "Folio Nota: "
        '
        'dtpFCobro
        '
        Me.dtpFCobro.Enabled = False
        Me.dtpFCobro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFCobro.Location = New System.Drawing.Point(128, 169)
        Me.dtpFCobro.Name = "dtpFCobro"
        Me.dtpFCobro.Size = New System.Drawing.Size(240, 21)
        Me.dtpFCobro.TabIndex = 76
        '
        'lblEmpresatck
        '
        Me.lblEmpresatck.AutoSize = True
        Me.lblEmpresatck.Location = New System.Drawing.Point(16, 112)
        Me.lblEmpresatck.Name = "lblEmpresatck"
        Me.lblEmpresatck.Size = New System.Drawing.Size(57, 14)
        Me.lblEmpresatck.TabIndex = 75
        Me.lblEmpresatck.Text = "Empresa:"
        Me.lblEmpresatck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmpresa
        '
        Me.lblEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEmpresa.Location = New System.Drawing.Point(128, 108)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(352, 21)
        Me.lblEmpresa.TabIndex = 74
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(16, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 13)
        Me.Label12.TabIndex = 73
        Me.Label12.Text = "Número de cliente:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporte
        '
        Me.lblImporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblImporte.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporte.Location = New System.Drawing.Point(128, 200)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(240, 21)
        Me.lblImporte.TabIndex = 72
        Me.lblImporte.Text = "Importe"
        Me.lblImporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImportetck
        '
        Me.lblImportetck.AutoSize = True
        Me.lblImportetck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImportetck.Location = New System.Drawing.Point(16, 203)
        Me.lblImportetck.Name = "lblImportetck"
        Me.lblImportetck.Size = New System.Drawing.Size(107, 14)
        Me.lblImportetck.TabIndex = 71
        Me.lblImportetck.Text = "Abono capturado  $:"
        Me.lblImportetck.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblFCobrotck
        '
        Me.lblFCobrotck.AutoSize = True
        Me.lblFCobrotck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFCobrotck.Location = New System.Drawing.Point(16, 175)
        Me.lblFCobrotck.Name = "lblFCobrotck"
        Me.lblFCobrotck.Size = New System.Drawing.Size(90, 14)
        Me.lblFCobrotck.TabIndex = 69
        Me.lblFCobrotck.Text = "Fecha de Cobro: "
        Me.lblFCobrotck.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblNombre
        '
        Me.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(128, 52)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(352, 21)
        Me.lblNombre.TabIndex = 68
        Me.lblNombre.Text = "Nombre"
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNombretck
        '
        Me.lblNombretck.AutoSize = True
        Me.lblNombretck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombretck.Location = New System.Drawing.Point(16, 56)
        Me.lblNombretck.Name = "lblNombretck"
        Me.lblNombretck.Size = New System.Drawing.Size(42, 14)
        Me.lblNombretck.TabIndex = 67
        Me.lblNombretck.Text = "Cliente:"
        '
        'lblCliente
        '
        Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(128, 24)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(216, 21)
        Me.lblCliente.TabIndex = 66
        Me.lblCliente.Text = "Cliente"
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRuta
        '
        Me.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRuta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.Location = New System.Drawing.Point(128, 80)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(352, 21)
        Me.lblRuta.TabIndex = 33
        Me.lblRuta.Text = "Ruta"
        Me.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRutatck
        '
        Me.lblRutatck.AutoSize = True
        Me.lblRutatck.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutatck.Location = New System.Drawing.Point(16, 84)
        Me.lblRutatck.Name = "lblRutatck"
        Me.lblRutatck.Size = New System.Drawing.Size(31, 14)
        Me.lblRutatck.TabIndex = 29
        Me.lblRutatck.Text = "Ruta:"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(520, 56)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(520, 24)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAbono
        '
        Me.txtAbono.Location = New System.Drawing.Point(144, 280)
        Me.txtAbono.Name = "txtAbono"
        Me.txtAbono.Size = New System.Drawing.Size(120, 21)
        Me.txtAbono.TabIndex = 1
        Me.txtAbono.TabStop = False
        Me.txtAbono.Text = ""
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(24, 280)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 13)
        Me.Label15.TabIndex = 65
        Me.Label15.Text = "Abono préstamo $:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(280, 280)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(96, 23)
        Me.lblTotal.TabIndex = 68
        '
        'frmValidarAbonos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(610, 334)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTotal, Me.txtAbono, Me.Label15, Me.btnCancelar, Me.btnAceptar, Me.grbInformacion})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmValidarAbonos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Validar nota de ingreso de abonos de préstamos a comisionistas"
        Me.grbInformacion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ValidarAbonos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim oConfig As New SigaMetClasses.cConfig(16, _CorporativoUsuario, _SucursalUsuario)
        _RutaReportes = CType(oConfig.Parametros("RutaReportesW7"), String).Trim

        ActiveControl = txtAbono
        btnAceptar.Enabled = False
        lblCliente.Text = CType(_Cliente, String)
        Dim oCliente As New PortatilClasses.Consulta.cCliente(0, CType(lblCliente.Text, Integer))
        oCliente.CargaDatos()

        lblRuta.Text = oCliente.Ruta
        lblRuta.Tag = oCliente.IdRuta
        lblEmpresa.Text = oCliente.Corporativo
        lblEmpresa.Tag = oCliente.IdCorporativo
        lblNombre.Text = oCliente.Cliente

        dtpFCobro.Value = _FCobro
        lblImporte.Text = CType(_Importe, String)
        lblFolioNota.Text = CType(_FolioNota, String)

    End Sub

    Private Sub txtAbono_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAbono.TextChanged
        If txtAbono.Text <> "" Then
            lblTotal.Text = Format(CType(txtAbono.Text, Decimal), "n")
            HabilitarAceptar()
        Else
            btnAceptar.Enabled = False
        End If
    End Sub



    ' Evento para pasarse de un control a otro por medio del enter

    Private Sub txtAbono_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAbono.KeyDown, btnAceptar.KeyDown, btnCancelar.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub


    ' Checa si los controles necesarios son llenados para habilitar el botón de Aceptar
    Private Sub HabilitarAceptar()
        If txtAbono.Text <> "" Then
            If CType(txtAbono.Text, Decimal) = _Importe Then
                btnAceptar.Enabled = True
                _Abono = _Importe
            ElseIf CType(txtAbono.Text, Decimal) > _Importe Then
                btnAceptar.Enabled = False
                'txtAbono.Text = ""
                ActiveControl = txtAbono
                MessageBox.Show("El abono no coincide con el importe capturado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                btnAceptar.Enabled = False
            End If
        End If
    End Sub


    Private Sub txtAbono_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAbono.Leave
        HabilitarAceptar()
    End Sub

    Private Sub MostrarEnPantalla(ByVal Año As Integer, ByVal FolioNota As Integer)
        Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(_RutaReportes, "spFormatoNotaIngresoAbonoPrestamo.rpt", _Servidor, _
                              _Database, _Usuario, _Password, False)
        oReporte.ListaParametros.Add(Año)
        oReporte.ListaParametros.Add(FolioNota)
        oReporte.ShowDialog()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Dim oAbono As New PortatilClasses.Consulta.cCobroComisionista()
            oAbono.Actualizar(3, _FolioCobro, _AnoCobro, 0, _Abono, 0, 0, Now, _Usuario, 0, "", 0, 0, CType(_CajaUsuario, Byte), _FCobro)
            oAbono.CerrarConexion()
            Close()
        End If
    End Sub
End Class

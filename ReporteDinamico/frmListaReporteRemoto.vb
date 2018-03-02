Public Class frmListaReporteRemoto
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents lnkReporte1 As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkReporte2 As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkReporte3 As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkReporte4 As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkReporte5 As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lnkReporte1 = New System.Windows.Forms.LinkLabel()
        Me.lnkReporte2 = New System.Windows.Forms.LinkLabel()
        Me.lnkReporte3 = New System.Windows.Forms.LinkLabel()
        Me.lnkReporte4 = New System.Windows.Forms.LinkLabel()
        Me.lnkReporte5 = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'lnkReporte1
        '
        Me.lnkReporte1.AutoSize = True
        Me.lnkReporte1.Location = New System.Drawing.Point(23, 24)
        Me.lnkReporte1.Name = "lnkReporte1"
        Me.lnkReporte1.Size = New System.Drawing.Size(190, 14)
        Me.lnkReporte1.TabIndex = 0
        Me.lnkReporte1.TabStop = True
        Me.lnkReporte1.Text = "Catálogo de programaciones por ruta"
        '
        'lnkReporte2
        '
        Me.lnkReporte2.AutoSize = True
        Me.lnkReporte2.Location = New System.Drawing.Point(23, 48)
        Me.lnkReporte2.Name = "lnkReporte2"
        Me.lnkReporte2.Size = New System.Drawing.Size(245, 14)
        Me.lnkReporte2.TabIndex = 1
        Me.lnkReporte2.TabStop = True
        Me.lnkReporte2.Text = "Pedidos programados para la fecha compromiso"
        '
        'lnkReporte3
        '
        Me.lnkReporte3.AutoSize = True
        Me.lnkReporte3.Location = New System.Drawing.Point(23, 72)
        Me.lnkReporte3.Name = "lnkReporte3"
        Me.lnkReporte3.Size = New System.Drawing.Size(182, 14)
        Me.lnkReporte3.TabIndex = 2
        Me.lnkReporte3.TabStop = True
        Me.lnkReporte3.Text = "Histórico de Suministros por Cliente"
        '
        'lnkReporte4
        '
        Me.lnkReporte4.AutoSize = True
        Me.lnkReporte4.Location = New System.Drawing.Point(23, 96)
        Me.lnkReporte4.Name = "lnkReporte4"
        Me.lnkReporte4.Size = New System.Drawing.Size(172, 14)
        Me.lnkReporte4.TabIndex = 3
        Me.lnkReporte4.TabStop = True
        Me.lnkReporte4.Text = "Clientes Surtidos por Ruta Cliente"
        '
        'lnkReporte5
        '
        Me.lnkReporte5.AutoSize = True
        Me.lnkReporte5.Location = New System.Drawing.Point(24, 120)
        Me.lnkReporte5.Name = "lnkReporte5"
        Me.lnkReporte5.Size = New System.Drawing.Size(147, 14)
        Me.lnkReporte5.TabIndex = 4
        Me.lnkReporte5.TabStop = True
        Me.lnkReporte5.Text = "Clientes Surtidos por Colonia"
        '
        'frmListaReporteRemoto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(290, 162)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lnkReporte5, Me.lnkReporte4, Me.lnkReporte3, Me.lnkReporte2, Me.lnkReporte1})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmListaReporteRemoto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reportes para acceso remoto"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal Celula As Byte, _
                   ByVal Servidor As String, _
                   ByVal BaseDeDatos As String, _
                   ByVal RutaReportes As String)
        MyBase.New()
        InitializeComponent()

        Main.ReporteRemoto_Celula = Celula
        Main.ReporteRemoto_Servidor = Servidor
        Main.ReporteRemoto_BaseDeDatos = BaseDeDatos
        Main.ReporteRemoto_RutaReportes = RutaReportes


    End Sub

    Private Sub lnkReporte1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkReporte1.LinkClicked
        Cursor = Cursors.WaitCursor
        Dim oReporte As New frmReporteCatalogoProgramacionRuta(Main.ReporteRemoto_Celula)
        oReporte.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub lnkReporte2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkReporte2.LinkClicked
        Cursor = Cursors.WaitCursor
        Dim oReporte As New frmReportePedidosProgramadosParaLaFechaCompromiso()
        oReporte.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub lnkReporte3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkReporte3.LinkClicked
        Cursor = Cursors.WaitCursor
        Dim oReporte As New frmReporteHistoricoSuministroCliente()
        oReporte.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub lnkReporte4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkReporte4.LinkClicked
        Cursor = Cursors.WaitCursor
        Dim oReporte As New frmReporteClientesSurtidosPorRutaCliente()
        oReporte.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub lnkReporte5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkReporte5.LinkClicked
        Cursor = Cursors.WaitCursor
        Dim oReporte As New frmReporteClientesSurtidosPorColonia()
        oReporte.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class

Option Strict On
Imports System.Data.SqlClient, System.Windows.Forms

Public Class ConsultaPedidoBitacora
    Inherits System.Windows.Forms.Form
    Private _PedidoReferencia As String

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
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents tvwPedidoBitacora As System.Windows.Forms.TreeView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ConsultaPedidoBitacora))
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.tvwPedidoBitacora = New System.Windows.Forms.TreeView()
        
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(100, 280)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tvwPedidoBitacora
        '
        Me.tvwPedidoBitacora.HotTracking = True
        Me.tvwPedidoBitacora.ImageIndex = -1
        Me.tvwPedidoBitacora.Location = New System.Drawing.Point(2, 0)
        Me.tvwPedidoBitacora.Name = "tvwPedidoBitacora"
        Me.tvwPedidoBitacora.SelectedImageIndex = -1
        Me.tvwPedidoBitacora.Size = New System.Drawing.Size(271, 264)
        Me.tvwPedidoBitacora.TabIndex = 2
        '
        'colCliente
        '

        '
        'colFCompromiso
        '

        '
        'colFCancelacion

        '
        'colMotivoCancelacion
        '
        'ConsultaPedidoBitacora
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(274, 319)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tvwPedidoBitacora, Me.btnCerrar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConsultaPedidoBitacora"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Histórico de datos del pedido"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal PedidoReferencia As String)
        MyBase.New()
        InitializeComponent()
        _PedidoReferencia = PedidoReferencia

        Me.Text = "Histórico de datos - [" & _PedidoReferencia & "]"

        CargaDatos()

    End Sub

    Private Sub CargaDatos()
        Cursor = Cursors.WaitCursor
        Dim conn As SqlConnection = DataLayer.Conexion
        Dim cmd As New SqlCommand("spCCPedidoBitacoraConsulta", conn)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@PedidoReferencia", SqlDbType.VarChar, 20).Value = _PedidoReferencia
        End With
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable("PedidoBitacora")

        Try
            da.Fill(dt)

            If dt.Rows.Count > 0 Then

                Dim dr As DataRow
                Dim node As TreeNode
                For Each dr In dt.Rows
                    node = tvwPedidoBitacora.Nodes.Add(CType(dr("FModificacion"), Date).ToString)
                    node.Nodes.Add("Cliente: " & CType(dr("Cliente"), String))
                    node.Nodes.Add("F.Compromiso: " & CType(dr("FCompromiso"), Date).ToShortDateString)
                    If Not IsDBNull(dr("MotivoCancelacion")) Then
                        node.Nodes.Add("Motivo cancelación: " & CType(dr("MotivoCancelacion"), Short).ToString)
                    Else
                        node.Nodes.Add("Motivo cancelación")
                    End If

                    If Not IsDBNull(dr("FCancelacion")) Then
                        node.Nodes.Add("F.Cancelación: " & CType(dr("FCancelacion"), Date).ToString)
                    Else
                        node.Nodes.Add("F.Cancelación")
                    End If
                    node.Nodes.Add("Usuario: " & CType(dr("Usuario"), String).Trim)
                    node.Nodes.Add("PC: " & CType(dr("HostName"), String).Trim)
                    node.Nodes.Add("Modificación realizada: " & CType(dr("Modificacion"), String).Trim)
                Next

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
            da.Dispose()
        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

End Class
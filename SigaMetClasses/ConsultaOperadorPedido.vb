Option Strict On
Imports System.Data.SqlClient, System.Windows.Forms

Public Class ConsultaOperadorPedido
    Inherits System.Windows.Forms.Form
    Private _Operador As Integer
    Private _Documento As String
    Private _Cliente As Integer


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
    Friend WithEvents grdOperadorPedido As System.Windows.Forms.DataGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents styOperadorPedido As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colPedidoReferencia As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFCargo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colLitros As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lblOperador As System.Windows.Forms.Label
    Friend WithEvents colSaldo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents colAñoAtt As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFolio As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents imgLista16 As System.Windows.Forms.ImageList
    Friend WithEvents tbrBarra As System.Windows.Forms.ToolBar
    Friend WithEvents btnConsultarDocumento As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnConsultarCliente As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrarForm As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ConsultaOperadorPedido))
        Me.grdOperadorPedido = New System.Windows.Forms.DataGrid()
        Me.styOperadorPedido = New System.Windows.Forms.DataGridTableStyle()
        Me.colPedidoReferencia = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFCargo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colLitros = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colSaldo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colAñoAtt = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFolio = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblOperador = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.imgLista16 = New System.Windows.Forms.ImageList(Me.components)
        Me.tbrBarra = New System.Windows.Forms.ToolBar()
        Me.btnConsultarDocumento = New System.Windows.Forms.ToolBarButton()
        Me.btnConsultarCliente = New System.Windows.Forms.ToolBarButton()
        Me.btnSep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.btnSep2 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrarForm = New System.Windows.Forms.Button()
        CType(Me.grdOperadorPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdOperadorPedido
        '
        Me.grdOperadorPedido.AlternatingBackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.grdOperadorPedido.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdOperadorPedido.BackColor = System.Drawing.Color.White
        Me.grdOperadorPedido.BackgroundColor = System.Drawing.Color.LightGoldenrodYellow
        Me.grdOperadorPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.grdOperadorPedido.CaptionBackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.grdOperadorPedido.CaptionFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grdOperadorPedido.CaptionForeColor = System.Drawing.Color.DarkSlateBlue
        Me.grdOperadorPedido.DataMember = ""
        Me.grdOperadorPedido.FlatMode = True
        Me.grdOperadorPedido.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.grdOperadorPedido.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.grdOperadorPedido.GridLineColor = System.Drawing.Color.Peru
        Me.grdOperadorPedido.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.grdOperadorPedido.HeaderBackColor = System.Drawing.Color.Maroon
        Me.grdOperadorPedido.HeaderFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grdOperadorPedido.HeaderForeColor = System.Drawing.Color.LightGoldenrodYellow
        Me.grdOperadorPedido.LinkColor = System.Drawing.Color.Maroon
        Me.grdOperadorPedido.Location = New System.Drawing.Point(8, 80)
        Me.grdOperadorPedido.Name = "grdOperadorPedido"
        Me.grdOperadorPedido.ParentRowsBackColor = System.Drawing.Color.BurlyWood
        Me.grdOperadorPedido.ParentRowsForeColor = System.Drawing.Color.DarkSlateBlue
        Me.grdOperadorPedido.ReadOnly = True
        Me.grdOperadorPedido.SelectionBackColor = System.Drawing.Color.DarkSlateBlue
        Me.grdOperadorPedido.SelectionForeColor = System.Drawing.Color.GhostWhite
        Me.grdOperadorPedido.Size = New System.Drawing.Size(658, 312)
        Me.grdOperadorPedido.TabIndex = 0
        Me.grdOperadorPedido.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.styOperadorPedido})
        '
        'styOperadorPedido
        '
        Me.styOperadorPedido.DataGrid = Me.grdOperadorPedido
        Me.styOperadorPedido.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colPedidoReferencia, Me.colFCargo, Me.colCliente, Me.colLitros, Me.colTotal, Me.colSaldo, Me.colStatus, Me.colAñoAtt, Me.colFolio})
        Me.styOperadorPedido.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.styOperadorPedido.MappingName = "OperadorPedido"
        Me.styOperadorPedido.ReadOnly = True
        Me.styOperadorPedido.RowHeadersVisible = False
        '
        'colPedidoReferencia
        '
        Me.colPedidoReferencia.Format = ""
        Me.colPedidoReferencia.FormatInfo = Nothing
        Me.colPedidoReferencia.HeaderText = "Documento"
        Me.colPedidoReferencia.MappingName = "PedidoReferencia"
        Me.colPedidoReferencia.Width = 90
        '
        'colFCargo
        '
        Me.colFCargo.Format = ""
        Me.colFCargo.FormatInfo = Nothing
        Me.colFCargo.HeaderText = "F.Cargo"
        Me.colFCargo.MappingName = "FCargo"
        Me.colFCargo.Width = 75
        '
        'colCliente
        '
        Me.colCliente.Format = ""
        Me.colCliente.FormatInfo = Nothing
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.MappingName = "Cliente"
        Me.colCliente.Width = 75
        '
        'colLitros
        '
        Me.colLitros.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colLitros.Format = "#,##.00"
        Me.colLitros.FormatInfo = Nothing
        Me.colLitros.HeaderText = "Litros"
        Me.colLitros.MappingName = "Litros"
        Me.colLitros.Width = 75
        '
        'colTotal
        '
        Me.colTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colTotal.Format = "#,##.00"
        Me.colTotal.FormatInfo = Nothing
        Me.colTotal.HeaderText = "Total"
        Me.colTotal.MappingName = "Total"
        Me.colTotal.Width = 75
        '
        'colSaldo
        '
        Me.colSaldo.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colSaldo.Format = "#,##.00"
        Me.colSaldo.FormatInfo = Nothing
        Me.colSaldo.HeaderText = "Saldo"
        Me.colSaldo.MappingName = "Saldo"
        Me.colSaldo.Width = 75
        '
        'colStatus
        '
        Me.colStatus.Format = ""
        Me.colStatus.FormatInfo = Nothing
        Me.colStatus.HeaderText = "Estatus"
        Me.colStatus.MappingName = "Status"
        Me.colStatus.Width = 75
        '
        'colAñoAtt
        '
        Me.colAñoAtt.Format = ""
        Me.colAñoAtt.FormatInfo = Nothing
        Me.colAñoAtt.HeaderText = "Año Att."
        Me.colAñoAtt.MappingName = "AñoAtt"
        Me.colAñoAtt.Width = 50
        '
        'colFolio
        '
        Me.colFolio.Format = ""
        Me.colFolio.FormatInfo = Nothing
        Me.colFolio.HeaderText = "Folio"
        Me.colFolio.MappingName = "Folio"
        Me.colFolio.Width = 50
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Operador:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOperador
        '
        Me.lblOperador.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblOperador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblOperador.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperador.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblOperador.Location = New System.Drawing.Point(80, 40)
        Me.lblOperador.Name = "lblOperador"
        Me.lblOperador.Size = New System.Drawing.Size(584, 21)
        Me.lblOperador.TabIndex = 6
        Me.lblOperador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblTotal.Location = New System.Drawing.Point(530, 410)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(136, 21)
        Me.lblTotal.TabIndex = 9
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label6.Location = New System.Drawing.Point(490, 413)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 14)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Total:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSaldo
        '
        Me.lblSaldo.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSaldo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.ForeColor = System.Drawing.Color.Firebrick
        Me.lblSaldo.Location = New System.Drawing.Point(530, 434)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(136, 21)
        Me.lblSaldo.TabIndex = 12
        Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Firebrick
        Me.Label4.Location = New System.Drawing.Point(490, 437)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 14)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Saldo:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'imgLista16
        '
        Me.imgLista16.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista16.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista16.ImageStream = CType(resources.GetObject("imgLista16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista16.TransparentColor = System.Drawing.Color.Transparent
        '
        'tbrBarra
        '
        Me.tbrBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnConsultarDocumento, Me.btnConsultarCliente, Me.btnSep1, Me.btnRefrescar, Me.btnSep2, Me.btnCerrar})
        Me.tbrBarra.DropDownArrows = True
        Me.tbrBarra.ImageList = Me.imgLista16
        Me.tbrBarra.Name = "tbrBarra"
        Me.tbrBarra.ShowToolTips = True
        Me.tbrBarra.Size = New System.Drawing.Size(674, 25)
        Me.tbrBarra.TabIndex = 14
        '
        'btnConsultarDocumento
        '
        Me.btnConsultarDocumento.Enabled = False
        Me.btnConsultarDocumento.ImageIndex = 0
        Me.btnConsultarDocumento.Tag = "ConsultarDocumento"
        Me.btnConsultarDocumento.ToolTipText = "Consulta el documento seleccionado"
        '
        'btnConsultarCliente
        '
        Me.btnConsultarCliente.Enabled = False
        Me.btnConsultarCliente.ImageIndex = 3
        Me.btnConsultarCliente.Tag = "ConsultarCliente"
        Me.btnConsultarCliente.ToolTipText = "Consulta el cliente seleccionado"
        '
        'btnSep1
        '
        Me.btnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnRefrescar
        '
        Me.btnRefrescar.ImageIndex = 1
        Me.btnRefrescar.Tag = "Refrescar"
        Me.btnRefrescar.ToolTipText = "Refrescar la información"
        '
        'btnSep2
        '
        Me.btnSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 2
        Me.btnCerrar.Tag = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar"
        '
        'btnCerrarForm
        '
        Me.btnCerrarForm.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrarForm.Location = New System.Drawing.Point(360, 8)
        Me.btnCerrarForm.Name = "btnCerrarForm"
        Me.btnCerrarForm.Size = New System.Drawing.Size(16, 16)
        Me.btnCerrarForm.TabIndex = 15
        '
        'ConsultaOperadorPedido
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCerrarForm
        Me.ClientSize = New System.Drawing.Size(674, 471)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbrBarra, Me.Label4, Me.lblSaldo, Me.Label6, Me.lblTotal, Me.lblOperador, Me.Label2, Me.grdOperadorPedido, Me.btnCerrarForm})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(600, 448)
        Me.Name = "ConsultaOperadorPedido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Documentos de crédito cargados al operador"
        CType(Me.grdOperadorPedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal Operador As Integer)
        MyBase.New()
        InitializeComponent()

        _Operador = Operador

        Dim oOperador As cOperador = Nothing
        Try
            oOperador = New cOperador(_Operador)
            lblOperador.Text = _Operador.ToString & " " & oOperador.Nombre

            CargaDatos(_Operador)

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblOperador.Text = "Error al cargar los datos del operador"
        Finally
            oOperador.Dispose()
        End Try

    End Sub

    Private Sub CargaDatos(ByVal Operador As Integer)
        Cursor = Cursors.WaitCursor
        btnConsultarDocumento.Enabled = False
        btnConsultarCliente.Enabled = False
        Dim strQuery As String = _
        "SELECT * FROM vwOperadorPedido WHERE Operador = " & Operador.ToString
        Dim da As SqlDataAdapter = Nothing
        Dim dt As DataTable = Nothing

        Try
            da = New SqlDataAdapter(strQuery, DataLayer.Conexion)
            dt = New DataTable("OperadorPedido")
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                grdOperadorPedido.DataSource = dt
                grdOperadorPedido.CaptionText = "Lista de pedidos cargados al operador (" & dt.Rows.Count.ToString & " en total)"
                lblTotal.Text = SumaColumna(dt, "Total").ToString("N")
                lblSaldo.Text = SumaColumna(dt, "Saldo").ToString("N")
            Else

                grdOperadorPedido.DataSource = Nothing
                grdOperadorPedido.CaptionText = "El operador no tiene pedidos cargados"
                lblTotal.Text = ""
                lblSaldo.Text = ""

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            dt.Dispose()
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub grdOperadorPedido_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdOperadorPedido.CurrentCellChanged
        grdOperadorPedido.Select(grdOperadorPedido.CurrentRowIndex)

        Try
            _Documento = CType(grdOperadorPedido.Item(grdOperadorPedido.CurrentRowIndex, 0), String).Trim
        Catch
            _Documento = ""
        End Try
        Try
            _Cliente = CType(grdOperadorPedido.Item(grdOperadorPedido.CurrentRowIndex, 2), Integer)
        Catch
            _Cliente = 0
        End Try
        If _Documento <> "" Then
            btnConsultarDocumento.Enabled = True
        Else
            btnConsultarDocumento.Enabled = False
        End If
        If _Cliente <> 0 Then
            btnConsultarCliente.Enabled = True
        Else
            btnConsultarCliente.Enabled = False
        End If
    End Sub

    Private Sub ConsultaDocumento()
        Cursor = Cursors.WaitCursor
        Dim oConsulta As New ConsultaCargo(_Documento)
        oConsulta.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub ConsultaCliente()
        Cursor = Cursors.WaitCursor
        Dim oConsulta As New frmConsultaCliente(_Cliente, Nuevo:=0)
        oConsulta.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub tbrBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case "ConsultarDocumento"
                If _Documento <> "" Then
                    ConsultaDocumento()
                End If
            Case "ConsultarCliente"
                If _Cliente <> 0 Then
                    ConsultaCliente()
                End If
            Case "Refrescar"
                CargaDatos(_Operador)
            Case "Cerrar"
                Me.Close()
        End Select
    End Sub

    Private Sub btnCerrarForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarForm.Click
        Me.Close()
    End Sub
End Class

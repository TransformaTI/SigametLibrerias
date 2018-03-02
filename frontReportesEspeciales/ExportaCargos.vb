Imports System.Data.SqlClient
Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ControlChars

Public Class frmExportaCargos
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        _connection = Connection

        'Add any initialization after the InitializeComponent() call
        dlgSave.Title = Application.ProductName & " v." & Application.ProductVersion & " -Exportación de cargos-"
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
    Friend WithEvents pnlParametrso As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblFInicial As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dtpFInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFFinal As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents pnlExportar As System.Windows.Forms.Panel
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents grdCargos As System.Windows.Forms.DataGrid
    Friend WithEvents dtpFFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dlgSave As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmExportaCargos))
        Me.pnlParametrso = New System.Windows.Forms.Panel()
        Me.dtpFInicial = New System.Windows.Forms.DateTimePicker()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblFInicial = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblFFinal = New System.Windows.Forms.Label()
        Me.dtpFFinal = New System.Windows.Forms.DateTimePicker()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.grdCargos = New System.Windows.Forms.DataGrid()
        Me.dlgSave = New System.Windows.Forms.SaveFileDialog()
        Me.pnlParametrso.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        CType(Me.grdCargos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlParametrso
        '
        Me.pnlParametrso.BackColor = System.Drawing.Color.White
        Me.pnlParametrso.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpFInicial, Me.btnBuscar, Me.lblFInicial, Me.lblTitulo, Me.lblFFinal, Me.dtpFFinal, Me.btnCerrar})
        Me.pnlParametrso.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametrso.Name = "pnlParametrso"
        Me.pnlParametrso.Size = New System.Drawing.Size(440, 96)
        Me.pnlParametrso.TabIndex = 0
        '
        'dtpFInicial
        '
        Me.dtpFInicial.Location = New System.Drawing.Point(120, 37)
        Me.dtpFInicial.Name = "dtpFInicial"
        Me.dtpFInicial.TabIndex = 1
        '
        'btnBuscar
        '
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(344, 36)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFInicial
        '
        Me.lblFInicial.AutoSize = True
        Me.lblFInicial.Location = New System.Drawing.Point(48, 40)
        Me.lblFInicial.Name = "lblFInicial"
        Me.lblFInicial.Size = New System.Drawing.Size(66, 14)
        Me.lblFInicial.TabIndex = 0
        Me.lblFInicial.Text = "Fecha &incial:"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblTitulo.Location = New System.Drawing.Point(9, 13)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(171, 14)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Seleccione el intervalo de fechas:"
        '
        'lblFFinal
        '
        Me.lblFFinal.AutoSize = True
        Me.lblFFinal.Location = New System.Drawing.Point(48, 67)
        Me.lblFFinal.Name = "lblFFinal"
        Me.lblFFinal.Size = New System.Drawing.Size(62, 14)
        Me.lblFFinal.TabIndex = 2
        Me.lblFFinal.Text = "Fecha &final:"
        '
        'dtpFFinal
        '
        Me.dtpFFinal.Location = New System.Drawing.Point(120, 64)
        Me.dtpFFinal.Name = "dtpFFinal"
        Me.dtpFFinal.TabIndex = 3
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(344, 63)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.TabIndex = 5
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnExportar})
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlExportar.Location = New System.Drawing.Point(0, 469)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(440, 48)
        Me.pnlExportar.TabIndex = 1
        '
        'btnExportar
        '
        Me.btnExportar.Enabled = False
        Me.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Bitmap)
        Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportar.Location = New System.Drawing.Point(183, 13)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.TabIndex = 6
        Me.btnExportar.Text = "&Exportar"
        Me.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdCargos
        '
        Me.grdCargos.AlternatingBackColor = System.Drawing.Color.White
        Me.grdCargos.BackColor = System.Drawing.Color.White
        Me.grdCargos.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdCargos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.grdCargos.CaptionBackColor = System.Drawing.Color.Silver
        Me.grdCargos.CaptionFont = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grdCargos.CaptionForeColor = System.Drawing.Color.Black
        Me.grdCargos.DataMember = ""
        Me.grdCargos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCargos.FlatMode = True
        Me.grdCargos.Font = New System.Drawing.Font("Courier New", 9.0!)
        Me.grdCargos.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.grdCargos.GridLineColor = System.Drawing.Color.DarkGray
        Me.grdCargos.HeaderBackColor = System.Drawing.Color.DarkGreen
        Me.grdCargos.HeaderFont = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grdCargos.HeaderForeColor = System.Drawing.Color.White
        Me.grdCargos.LinkColor = System.Drawing.Color.DarkGreen
        Me.grdCargos.Location = New System.Drawing.Point(0, 96)
        Me.grdCargos.Name = "grdCargos"
        Me.grdCargos.ParentRowsBackColor = System.Drawing.Color.Gainsboro
        Me.grdCargos.ParentRowsForeColor = System.Drawing.Color.Black
        Me.grdCargos.ReadOnly = True
        Me.grdCargos.SelectionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdCargos.SelectionForeColor = System.Drawing.Color.Black
        Me.grdCargos.Size = New System.Drawing.Size(440, 373)
        Me.grdCargos.TabIndex = 2
        '
        'dlgSave
        '
        Me.dlgSave.DefaultExt = "tm3"
        Me.dlgSave.Filter = "Archivos tm3|*.tm3"
        '
        'frmExportaCargos
        '
        Me.AcceptButton = Me.btnBuscar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(440, 517)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdCargos, Me.pnlExportar, Me.pnlParametrso})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExportaCargos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportar cargos"
        Me.pnlParametrso.ResumeLayout(False)
        Me.pnlExportar.ResumeLayout(False)
        CType(Me.grdCargos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim dtCargos As New DataTable()

    Private _connection As SqlConnection

    Dim WithEvents CargaDatos As CargaDatos

    Private thrCarga As Thread

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.Cursor = Cursors.WaitCursor
        CargaDatos = New CargaDatos(_connection, dtpFInicial.Value, dtpFFinal.Value, dtCargos)
        CargaDatos.CargaDatos()
        'thrCarga = New Thread(AddressOf CargaDatos.CargaDatos)
        'btnBuscar.Enabled = False
        'dtpFFinal.Enabled = False
        'dtpFInicial.Enabled = False
        'thrCarga.Start()
    End Sub


    Public Sub GridData(ByRef Grid As DataGrid, ByVal Table As DataTable, Optional ByVal TableStyleIndex As Integer = -1, Optional ByVal Columns As Integer = 0)
        If CInt(Grid.Width / Table.Columns.Count) - 10 > 0 Then
            If TableStyleIndex = -1 Then
                Grid.PreferredColumnWidth = CInt(Grid.Width / Table.Columns.Count) - 20 + Table.Columns.Count
            Else
                Grid.TableStyles(TableStyleIndex).MappingName = Table.TableName
                Dim Index As Byte
                If Columns = 0 Then
                    Columns = Table.Columns.Count - 1
                End If
                For Index = 0 To CByte(Columns - 1)
                    Grid.TableStyles(TableStyleIndex).GridColumnStyles(Index).Width = CInt(Grid.Width / Columns) - 20 + Columns
                Next Index
            End If
        End If
        Grid.DataSource = Table
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        If dlgSave.ShowDialog = DialogResult.OK Then
            Dim Row As DataRow
            Dim Column As DataColumn
            Me.Cursor = Cursors.WaitCursor
            Dim _string As String = Nothing
            Try
                If IO.File.Exists(dlgSave.FileName) Then
                    IO.File.Delete(dlgSave.FileName)
                End If
                'Recuperar encabezado del archivo TM3
                Dim reader As New IO.StreamReader(Application.StartupPath & "\Exportacion.tm3", System.Text.Encoding.ASCII)
                Try
                    _string = reader.ReadToEnd
                Catch ex As Exception
                    MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    reader.Close()
                End Try

                'Recuperar contenido del archivo
                For Each Row In dtCargos.Rows
                    For Each Column In dtCargos.Columns
                        _string += CType(Row(Column), String) + ControlChars.Tab
                    Next
                    _string += ControlChars.CrLf
                Next

                'Escribir el archivo completo
                Dim writer As New IO.StreamWriter(dlgSave.FileName, False, System.Text.Encoding.ASCII)
                Try
                    writer.Write(_string)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    writer.Close()
                End Try

                MessageBox.Show("La exportación ha finalizado exitosamente.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                Debug.WriteLine(ex.Message)
                MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally

            End Try
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        If Not thrCarga Is Nothing AndAlso thrCarga.IsAlive AndAlso thrCarga.ThreadState = ThreadState.Running Then            
            thrCarga.Abort()
        End If
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub dtpFInicial_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFInicial.ValueChanged
        dtpFFinal.MinDate = dtpFInicial.Value.Date
    End Sub

    Private Sub CargaDatos_TerminaCarga() Handles CargaDatos.TerminaCarga
        'dtCargos = CargaDatos.dtCargos.Copy
        GridData(grdCargos, dtCargos)
        Me.Cursor = Cursors.Default
        Me.btnExportar.Enabled = True
    End Sub
End Class

Public Class CargaDatos


    Public Sub New(ByVal Connection As SqlConnection, ByVal fecha1 As Date, ByVal fecha2 As Date, ByRef Table As DataTable)
        MyBase.new()
        _fecha1 = fecha1
        _fecha2 = fecha2
        dtCargos = Table
        _connection = Connection
    End Sub

    Dim _connection As SqlConnection
    Dim _fecha1, _fecha2 As Date
    Public dtCargos As DataTable

    Public Event TerminaCarga()

    Public Sub CargaDatos()
        Dim cmdCyC As New SqlCommand("spCYCExportaCargos", _connection)
        Dim daCyC As New SqlDataAdapter(cmdCyC)
        cmdCyC.CommandType = CommandType.StoredProcedure
        cmdCyC.CommandTimeout = 1200
        cmdCyC.Parameters.Add("@Fecha1", SqlDbType.DateTime).Value = _fecha1
        cmdCyC.Parameters.Add("@Fecha2", SqlDbType.DateTime).Value = _fecha2
        dtCargos.Clear()
        Try
            daCyC.Fill(dtCargos)
        Catch ex As SqlException
            MessageBox.Show("Error no.:" & ex.number & " " & ex.Message, Application.ProductName & " v." & Application.ProductVersion, _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            _connection.Dispose()
            daCyC.Dispose()
            cmdCyC.Dispose()
        End Try
        RaiseEvent TerminaCarga()
    End Sub

End Class

#Region "garbage"
'Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
'    If dlgSave.ShowDialog = DialogResult.OK Then
'        Dim Archivo As New Excel.Application()
'        Dim Row As DataRow
'        Dim Column As DataColumn
'        Dim Col, Reng As Integer
'        Me.Cursor = Cursors.WaitCursor
'        Try
'            If IO.File.Exists(dlgSave.FileName) Then
'                IO.File.Delete(dlgSave.FileName)
'            End If
'            Archivo.Workbooks.Open(Application.StartupPath & "\Exportacion.tm3")
'            With Archivo
'                Reng = 2
'                For Each Row In dtCargos.Rows
'                    Reng += 1
'                    Col = 1
'                    For Each Column In dtCargos.Columns
'                        .Cells(Reng, Col) = Row(Column.ColumnName)
'                        Col += 1
'                    Next
'                Next
'                .Workbooks.Item(1).SaveAs(dlgSave.FileName)
'                .Workbooks.Item(1).Close(False)
'                MessageBox.Show("La exportación ha finalizado exitosamente.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
'            End With
'        Catch ex As Exception
'            Debug.WriteLine(ex.Message)
'            MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
'        Finally
'            Archivo.Quit()
'        End Try
'        Me.Cursor = Cursors.Default
'    End If
'End Sub
#End Region
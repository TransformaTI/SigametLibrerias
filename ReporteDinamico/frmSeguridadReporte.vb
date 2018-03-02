Imports System.Windows.Forms, System.IO, System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmSeguridadReporte
    Inherits System.Windows.Forms.Form
    Private _rptReporte As New ReportDocument()
    Private _RutaReportes As String
    Private _UsuarioGrupo As String
    Private _Modulo As Short
    Private _TipoSeguridad As SigaMetClasses.Enumeradores.enumTipoSeguridadReporte
    Private _connection As SqlClient.SqlConnection
    Private _dtCatalogoServidores As DataTable
    Private _data As SGDAC.DAC

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
    Friend WithEvents lstReporte As System.Windows.Forms.ListBox
    Friend WithEvents lstUsuarioReporte As System.Windows.Forms.ListBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents lblUsuarioReporte As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblRutaReportes As System.Windows.Forms.Label
    Friend WithEvents btnAsignar As System.Windows.Forms.Button
    Friend WithEvents btnDesasignar As System.Windows.Forms.Button
    Friend WithEvents ttMensaje As System.Windows.Forms.ToolTip
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblModulo As System.Windows.Forms.Label
    Friend WithEvents lblUsuarioGrupo As System.Windows.Forms.Label
    Friend WithEvents lblTipoSeguridad As System.Windows.Forms.Label
    Friend WithEvents mnuContextual As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuConexionReporte As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSeguridadReporte))
        Me.lstReporte = New System.Windows.Forms.ListBox()
        Me.lstUsuarioReporte = New System.Windows.Forms.ListBox()
        Me.mnuContextual = New System.Windows.Forms.ContextMenu()
        Me.mnuConexionReporte = New System.Windows.Forms.MenuItem()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAsignar = New System.Windows.Forms.Button()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.lblUsuarioReporte = New System.Windows.Forms.Label()
        Me.lblUsuarioGrupo = New System.Windows.Forms.Label()
        Me.lblTipoSeguridad = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblRutaReportes = New System.Windows.Forms.Label()
        Me.btnDesasignar = New System.Windows.Forms.Button()
        Me.ttMensaje = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblModulo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lstReporte
        '
        Me.lstReporte.Location = New System.Drawing.Point(8, 64)
        Me.lstReporte.Name = "lstReporte"
        Me.lstReporte.Size = New System.Drawing.Size(312, 329)
        Me.lstReporte.Sorted = True
        Me.lstReporte.TabIndex = 0
        '
        'lstUsuarioReporte
        '
        Me.lstUsuarioReporte.BackColor = System.Drawing.Color.LemonChiffon
        Me.lstUsuarioReporte.ContextMenu = Me.mnuContextual
        Me.lstUsuarioReporte.Location = New System.Drawing.Point(368, 64)
        Me.lstUsuarioReporte.Name = "lstUsuarioReporte"
        Me.lstUsuarioReporte.Size = New System.Drawing.Size(312, 329)
        Me.lstUsuarioReporte.Sorted = True
        Me.lstUsuarioReporte.TabIndex = 1
        '
        'mnuContextual
        '
        Me.mnuContextual.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuConexionReporte})
        '
        'mnuConexionReporte
        '
        Me.mnuConexionReporte.Index = 0
        Me.mnuConexionReporte.Text = "Cambiar conexión del reporte..."
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(259, 408)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(355, 408)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAsignar
        '
        Me.btnAsignar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAsignar.Image = CType(resources.GetObject("btnAsignar.Image"), System.Drawing.Bitmap)
        Me.btnAsignar.Location = New System.Drawing.Point(328, 176)
        Me.btnAsignar.Name = "btnAsignar"
        Me.btnAsignar.Size = New System.Drawing.Size(32, 23)
        Me.btnAsignar.TabIndex = 5
        Me.ttMensaje.SetToolTip(Me.btnAsignar, "Asignar el reporte seleccionado")
        '
        'lblReporte
        '
        Me.lblReporte.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblReporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblReporte.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporte.Location = New System.Drawing.Point(8, 40)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(312, 21)
        Me.lblReporte.TabIndex = 6
        Me.lblReporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUsuarioReporte
        '
        Me.lblUsuarioReporte.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblUsuarioReporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUsuarioReporte.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuarioReporte.Location = New System.Drawing.Point(368, 40)
        Me.lblUsuarioReporte.Name = "lblUsuarioReporte"
        Me.lblUsuarioReporte.Size = New System.Drawing.Size(312, 21)
        Me.lblUsuarioReporte.TabIndex = 7
        Me.lblUsuarioReporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUsuarioGrupo
        '
        Me.lblUsuarioGrupo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuarioGrupo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblUsuarioGrupo.Location = New System.Drawing.Point(64, 8)
        Me.lblUsuarioGrupo.Name = "lblUsuarioGrupo"
        Me.lblUsuarioGrupo.Size = New System.Drawing.Size(168, 21)
        Me.lblUsuarioGrupo.TabIndex = 8
        Me.lblUsuarioGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTipoSeguridad
        '
        Me.lblTipoSeguridad.AutoSize = True
        Me.lblTipoSeguridad.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoSeguridad.Location = New System.Drawing.Point(8, 11)
        Me.lblTipoSeguridad.Name = "lblTipoSeguridad"
        Me.lblTipoSeguridad.Size = New System.Drawing.Size(33, 14)
        Me.lblTipoSeguridad.TabIndex = 9
        Me.lblTipoSeguridad.Text = "Tipo:"
        Me.lblTipoSeguridad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(320, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 14)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Ruta de los reportes:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRutaReportes
        '
        Me.lblRutaReportes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutaReportes.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblRutaReportes.Location = New System.Drawing.Point(432, 8)
        Me.lblRutaReportes.Name = "lblRutaReportes"
        Me.lblRutaReportes.Size = New System.Drawing.Size(248, 21)
        Me.lblRutaReportes.TabIndex = 11
        Me.lblRutaReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnDesasignar
        '
        Me.btnDesasignar.BackColor = System.Drawing.SystemColors.Control
        Me.btnDesasignar.Image = CType(resources.GetObject("btnDesasignar.Image"), System.Drawing.Bitmap)
        Me.btnDesasignar.Location = New System.Drawing.Point(328, 208)
        Me.btnDesasignar.Name = "btnDesasignar"
        Me.btnDesasignar.Size = New System.Drawing.Size(32, 23)
        Me.btnDesasignar.TabIndex = 12
        Me.ttMensaje.SetToolTip(Me.btnDesasignar, "Desasignar el reporte seleccionado")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(232, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 14)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Módulo:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblModulo
        '
        Me.lblModulo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModulo.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblModulo.Location = New System.Drawing.Point(280, 8)
        Me.lblModulo.Name = "lblModulo"
        Me.lblModulo.Size = New System.Drawing.Size(32, 21)
        Me.lblModulo.TabIndex = 14
        Me.lblModulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmSeguridadReporte
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(688, 445)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblModulo, Me.Label3, Me.btnDesasignar, Me.lblRutaReportes, Me.Label1, Me.lblTipoSeguridad, Me.lblUsuarioGrupo, Me.lblUsuarioReporte, Me.lblReporte, Me.btnAsignar, Me.btnCancelar, Me.btnAceptar, Me.lstUsuarioReporte, Me.lstReporte})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSeguridadReporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seguridad de los reportes"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal RutaReportes As String, _
                   ByVal Modulo As Short, _
                   ByVal UsuarioGrupo As String, _
                   ByVal TipoSeguridad As SigaMetClasses.Enumeradores.enumTipoSeguridadReporte, _
                   ByVal Conexion As SqlClient.SqlConnection)

        MyBase.New()
        InitializeComponent()
        _RutaReportes = RutaReportes
        _UsuarioGrupo = UsuarioGrupo
        _Modulo = Modulo
        _TipoSeguridad = TipoSeguridad

        _connection = Conexion

        _dtCatalogoServidores = New DataTable("CatalogoServidor")
        _data = New SGDAC.DAC(_connection)

        cargaCatalogoServidores()

        lblModulo.Text = _Modulo.ToString
        If _TipoSeguridad = SigaMetClasses.Enumeradores.enumTipoSeguridadReporte.Usuario Then
            Me.Text = "Seguridad de los reportes por Usuario"
            lblTipoSeguridad.Text = "Usuario:"
        Else
            Me.Text = "Seguridad de los reportes por Grupo"
            lblTipoSeguridad.Text = "Grupo:"
        End If
        lblUsuarioGrupo.Text = _UsuarioGrupo
        lblRutaReportes.Text = _RutaReportes

        lstReporte.DisplayMember = "Text"
        lstUsuarioReporte.DisplayMember = "Text"
        Cursor = Cursors.WaitCursor
        CargaListaReportesDisponibles(_TipoSeguridad)

        TituloListaReporte()
        TituloListaUsuarioReporte()
        Cursor = Cursors.Default
    End Sub


    Private Sub CargaListaReportesDisponibles(ByVal TipoSeguridad As SigaMetClasses.Enumeradores.enumTipoSeguridadReporte)
        Cursor = Cursors.WaitCursor
        Try
            Dim strQuery As String
            If TipoSeguridad = SigaMetClasses.Enumeradores.enumTipoSeguridadReporte.Usuario Then
                strQuery = "SELECT Modulo, Usuario, Reporte, Servidor, BaseDatos " & _
                           "FROM UsuarioReporte " & _
                           "WHERE Modulo = " & _Modulo & _
                           " AND Usuario = '" & _UsuarioGrupo & "'"
            End If
            If TipoSeguridad = SigaMetClasses.Enumeradores.enumTipoSeguridadReporte.Grupo Then
                strQuery = "SELECT Modulo, Grupo, Reporte, Servidor, BaseDatos " & _
                           "FROM GrupoReporte " & _
                           "WHERE Modulo = " & _Modulo & _
                           " AND Grupo = '" & _UsuarioGrupo & "'"
            End If

            Dim da As New SqlDataAdapter(strQuery, _connection)

            Dim dt As New DataTable("PermisoReporte")

            Try
                da.Fill(dt)

            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                da.Dispose()
                dt.Dispose()
            End Try

            lstReporte.Items.Clear()
            Dim strReporte As String, strDescripcion As String, strArchivo As String
            Dim oRep As Reporte

            If Not Directory.Exists(_RutaReportes) Then
                MessageBox.Show("La ruta " & _RutaReportes & " no existe o es inválida.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor

            For Each strReporte In Directory.GetFiles(_RutaReportes, "*.rpt")
                strArchivo = Replace(strReporte, _RutaReportes & "\", "")
                _rptReporte.Load(strReporte)

                oRep = New Reporte()
                If _rptReporte.SummaryInfo.ReportTitle = "" Then
                    oRep.Text = Replace(strReporte, _RutaReportes & "\", "")
                Else
                    oRep.Text = _rptReporte.SummaryInfo.ReportTitle
                End If

                oRep.Path = strReporte
                oRep.Tema = _rptReporte.SummaryInfo.ReportSubject
                oRep.Comentario = _rptReporte.SummaryInfo.ReportComments
                oRep.FActualizacion = File.GetLastWriteTime(strReporte)
                oRep.ImageIndex = 1

                dt.DefaultView.RowFilter = "Reporte = '" & strReporte & "'"
                If dt.DefaultView.Count = 0 Then
                    lstReporte.Items.Add(oRep)
                    ttMensaje.SetToolTip(lstReporte, oRep.Comentario)
                Else
                    lstUsuarioReporte.Items.Add(oRep)
                    ttMensaje.SetToolTip(lstUsuarioReporte, oRep.Comentario)
                End If
                dt.DefaultView.RowFilter = ""
            Next
            'lstReporte.Sorted = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub TituloListaReporte()
        lblReporte.Text = "Reportes disponibles (" & Me.lstReporte.Items.Count.ToString & " en total)"
    End Sub

    Private Sub TituloListaUsuarioReporte()
        lblUsuarioReporte.Text = "Reportes asignados (" & Me.lstUsuarioReporte.Items.Count.ToString & " en total)"
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignar.Click
        Asignar()
    End Sub

    Private Sub btnDesasignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesasignar.Click
        Desasignar()
    End Sub

    Private Sub Asignar()
        Try
            If Not IsNothing(lstReporte.SelectedItem) Then

                Dim objReporteParaAsignar As Reporte
                objReporteParaAsignar = CType(lstReporte.SelectedItem, Reporte)

                'Selección de servidor y base de datos
                Dim frmServidorBD As New frmServidorBD(objReporteParaAsignar.Path, _dtCatalogoServidores, _connection)
                If frmServidorBD.ShowDialog() = DialogResult.Cancel Then
                    Exit Sub
                End If

                lstUsuarioReporte.Items.Add(objReporteParaAsignar)
                lstReporte.Items.Remove(lstReporte.SelectedItem)

                objReporteParaAsignar.Servidor = frmServidorBD.Servidor
                objReporteParaAsignar.BaseDatos = frmServidorBD.BaseDAtos

                frmServidorBD.Dispose()

                TituloListaReporte()
                TituloListaUsuarioReporte()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Desasignar()
        Try
            If Not IsNothing(lstUsuarioReporte.SelectedItem) Then
                Dim objReporte As Reporte
                objReporte = CType(lstUsuarioReporte.SelectedItem, Reporte)
                lstReporte.Items.Add(objReporte)
                lstUsuarioReporte.Items.Remove(lstUsuarioReporte.SelectedItem)

                TituloListaReporte()
                TituloListaUsuarioReporte()
                If _TipoSeguridad = SigaMetClasses.Enumeradores.enumTipoSeguridadReporte.Usuario Then
                    borraReporte("spSEGUsuarioReporteBaja", _Modulo, _UsuarioGrupo, objReporte.Path)
                Else
                    If _TipoSeguridad = SigaMetClasses.Enumeradores.enumTipoSeguridadReporte.Grupo Then
                        borraReporte("spSEGGrupoReporteBaja", _Modulo, _UsuarioGrupo, objReporte.Path)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub lstReporte_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstReporte.DoubleClick
        Asignar()
    End Sub

    Private Sub lstUsuarioReporte_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstUsuarioReporte.DoubleClick
        Desasignar()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MessageBox.Show(SigaMetClasses.M_ESTAN_CORRECTOS, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor

            Dim oRep As Reporte
            Dim arrListaReportes As New ArrayList()
            Dim oUsuarioReporte As New SigaMetClasses.cUsuarioReporte()

            For Each oRep In Me.lstUsuarioReporte.Items
                'arrListaReportes.Add(oRep.Path)
                arrListaReportes.Add(oRep)
            Next

            Try
                If _TipoSeguridad = SigaMetClasses.Enumeradores.enumTipoSeguridadReporte.Usuario Then
                    UsuarioReporteAlta(_Modulo, _UsuarioGrupo, arrListaReportes)
                End If
                If _TipoSeguridad = SigaMetClasses.Enumeradores.enumTipoSeguridadReporte.Grupo Then
                    GrupoReporteAlta(_Modulo, _UsuarioGrupo, arrListaReportes)
                End If

                MessageBox.Show(SigaMetClasses.M_DATOS_OK, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                DialogResult = DialogResult.OK

            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default
                oUsuarioReporte.Dispose()
            End Try

        End If
    End Sub

    Private Sub mnuConexionReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConexionReporte.Click
        Cursor = Cursors.WaitCursor
        Dim strNombreArchivo As String
        strNombreArchivo = Trim(CType(Me.lstUsuarioReporte.SelectedItem, Reporte).Path)
        Dim oConexionReporte As New frmConexionReporte(_Modulo, _UsuarioGrupo, strNombreArchivo, _TipoSeguridad, _dtCatalogoServidores, _connection)
        oConexionReporte.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuContextual_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuContextual.Popup
        If lstUsuarioReporte.SelectedIndex >= 0 Then
            mnuConexionReporte.Enabled = True
        Else
            mnuConexionReporte.Enabled = False
        End If
    End Sub

    Private Sub borraReporte(ByVal SP As String, ByVal Modulo As Short, ByVal Usuario As String, ByVal StrReporte As String)
        'Dim conn As New SqlConnection(SigaMetClasses.LeeInfoConexion(False))
        Dim cmdDelete As New SqlCommand()
        With cmdDelete
            .CommandText = SP
            .CommandType = CommandType.StoredProcedure
            .Connection = _connection
            .Parameters.Clear()
            .Parameters.Add("@Modulo", SqlDbType.SmallInt).Value = Modulo
            .Parameters.Add("@Usuario", SqlDbType.Char, 15).Value = Usuario
            .Parameters.Add("@Reporte", SqlDbType.VarChar, 100).Value = StrReporte
        End With
        Try
            _connection.Open()
            cmdDelete.ExecuteNonQuery()
        Catch ex As SqlException
            Throw ex
        Catch ex As Exception
            Throw ex
        Finally
            If _connection.State = ConnectionState.Open Then
                _connection.Close()
            End If
            cmdDelete.Dispose()
        End Try
    End Sub



    Public Sub UsuarioReporteAlta(ByVal Modulo As Short, _
                                      ByVal Usuario As String, _
                                      ByVal ListaReportes As ArrayList)
        Dim cmd As New SqlCommand()
        'Dim cn As New SqlConnection(SigaMetClasses.LeeInfoConexion(False))
        Dim Transaccion As SqlClient.SqlTransaction

        Try
            _connection.Open()
            Transaccion = _connection.BeginTransaction

            'cmd.CommandText = "DELETE UsuarioReporte WHERE Usuario = '" & Usuario & "'" & _
            '" AND Modulo = " & Modulo
            'cmd.CommandType = CommandType.Text
            cmd.Connection = _connection
            cmd.Transaction = Transaccion

            'cmd.ExecuteNonQuery()


            cmd.CommandText = "spCYCUsuarioReporteAlta"
            cmd.CommandType = CommandType.StoredProcedure
            Dim strReporte As Reporte
            For Each strReporte In ListaReportes
                With cmd
                    Debug.WriteLine(strReporte)
                    .Parameters.Clear()
                    .Parameters.Add("@Modulo", SqlDbType.SmallInt).Value = Modulo
                    .Parameters.Add("@Usuario", SqlDbType.Char, 15).Value = Usuario
                    .Parameters.Add("@Reporte", SqlDbType.VarChar, 100).Value = strReporte.Path
                    .Parameters.Add("@Servidor", SqlDbType.VarChar, 20).Value = strReporte.Servidor
                    .Parameters.Add("@BaseDatos", SqlDbType.VarChar, 20).Value = strReporte.BaseDatos
                    .ExecuteNonQuery()
                End With
            Next
            Transaccion.Commit()
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            Transaccion.Rollback()
        Finally
            cmd.Dispose()
        End Try
    End Sub

    Public Sub GrupoReporteAlta(ByVal Modulo As Short, _
                                ByVal Grupo As String, _
                                ByVal ListaReportes As ArrayList)
        Dim cmd As New SqlCommand()
        'Dim cn As New SqlConnection(SigaMetClasses.LeeInfoConexion(False))
        Dim Transaccion As SqlClient.SqlTransaction

        'Dim cmd As New SqlCommand()
        'Dim cn As New SqlConnection(SigaMetClasses.LeeInfoConexion(False))
        'Dim Transaccion As SqlClient.SqlTransaction

        Try
            _connection.Open()
            Transaccion = _connection.BeginTransaction

            'cn.Open()
            'Transaccion = cn.BeginTransaction

            'cmd.CommandText = "DELETE GrupoReporte WHERE Grupo = '" & Grupo & "'" & _
            '" AND Modulo = " & Modulo
            'cmd.CommandType = CommandType.Text
            cmd.Connection = _connection
            cmd.Transaction = Transaccion

            'cmd.ExecuteNonQuery()

            cmd.CommandText = "spCYCGrupoReporteAlta"
            cmd.CommandType = CommandType.StoredProcedure
            Dim strReporte As Reporte
            For Each strReporte In ListaReportes
                With cmd
                    Debug.WriteLine(strReporte)
                    .Parameters.Clear()
                    .Parameters.Add("@Modulo", SqlDbType.SmallInt).Value = Modulo
                    .Parameters.Add("@Grupo", SqlDbType.Char, 15).Value = Grupo
                    .Parameters.Add("@Reporte", SqlDbType.VarChar, 100).Value = strReporte.Path
                    .Parameters.Add("@Servidor", SqlDbType.VarChar, 20).Value = strReporte.Servidor
                    .Parameters.Add("@BaseDatos", SqlDbType.VarChar, 20).Value = strReporte.BaseDatos
                    .ExecuteNonQuery()
                End With
            Next
            Transaccion.Commit()
        Catch ex As Exception
            Transaccion.Rollback()
        Finally
            cmd.Dispose()
        End Try

    End Sub

    Private Sub cargaCatalogoServidores()
        Try
            _data.LoadData(_dtCatalogoServidores, "spSEGConsultaServidorReportes", CommandType.StoredProcedure, True)
        Catch ex As Exception
            MessageBox.Show("Error" & Chr(13) & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class
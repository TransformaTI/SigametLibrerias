'Modificó: Julio Morales
'Fecha 25/06/2015
'Descripción: Se Agregaron Validaciones para ocultar o mostrar el Botón de Imprimir Reporte y de Exportar Reporte
'Id. de cambios: 20150625JMV$002

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Xml
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class frmReporte
    Inherits System.Windows.Forms.Form
#Region "Variables locales"
    Private rptReporte As New ReportDocument()
    Private _RutaReporte As String
    Private ParametrosDelReporte As ParameterFieldDefinitions
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo
    Private _Servidor As String
    Private _BaseDeDatos As String
    Private _UserID As String
    Private _Password As String
    'Id. de cambios: 20150625JMV$002-----------------
    Private _Lista As New List(Of Integer)
    'Id. de cambios: 20150625JMV$002-----------------
    Private _connection As SqlConnection
#End Region

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
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnConsultar As System.Windows.Forms.Button
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents PanelControl As System.Windows.Forms.Panel
    Friend WithEvents lnkAyuda As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporte))
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.PanelControl = New System.Windows.Forms.Panel()
        Me.lnkAyuda = New System.Windows.Forms.LinkLabel()
        Me.PanelControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvReporte.BackColor = System.Drawing.SystemColors.Control
        Me.crvReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvReporte.DisplayGroupTree = False
        Me.crvReporte.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crvReporte.Location = New System.Drawing.Point(323, 0)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.SelectionFormula = ""
        Me.crvReporte.ShowRefreshButton = False
        Me.crvReporte.Size = New System.Drawing.Size(661, 621)
        Me.crvReporte.TabIndex = 500
        Me.crvReporte.ViewTimeSelectionFormula = ""
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(19, 552)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(75, 24)
        Me.btnConsultar.TabIndex = 0
        Me.btnConsultar.Text = "C&onsultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = False
        '
        'lblReporte
        '
        Me.lblReporte.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblReporte.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporte.Location = New System.Drawing.Point(0, 600)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(97, 20)
        Me.lblReporte.TabIndex = 6
        Me.lblReporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(107, 552)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 24)
        Me.btnCerrar.TabIndex = 501
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter1.Location = New System.Drawing.Point(981, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 621)
        Me.Splitter1.TabIndex = 502
        Me.Splitter1.TabStop = False
        '
        'PanelControl
        '
        Me.PanelControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelControl.BackColor = System.Drawing.Color.Gainsboro
        Me.PanelControl.Controls.Add(Me.lnkAyuda)
        Me.PanelControl.Controls.Add(Me.btnConsultar)
        Me.PanelControl.Controls.Add(Me.btnCerrar)
        Me.PanelControl.Controls.Add(Me.lblReporte)
        Me.PanelControl.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl.Name = "PanelControl"
        Me.PanelControl.Size = New System.Drawing.Size(317, 621)
        Me.PanelControl.TabIndex = 503
        '
        'lnkAyuda
        '
        Me.lnkAyuda.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkAyuda.AutoSize = True
        Me.lnkAyuda.Location = New System.Drawing.Point(-440, 584)
        Me.lnkAyuda.Name = "lnkAyuda"
        Me.lnkAyuda.Size = New System.Drawing.Size(38, 13)
        Me.lnkAyuda.TabIndex = 502
        Me.lnkAyuda.TabStop = True
        Me.lnkAyuda.Text = "Ayuda"
        '
        'frmReporte
        '
        Me.AcceptButton = Me.btnConsultar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(984, 621)
        Me.Controls.Add(Me.crvReporte)
        Me.Controls.Add(Me.PanelControl)
        Me.Controls.Add(Me.Splitter1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte"
        Me.PanelControl.ResumeLayout(False)
        Me.PanelControl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Id. de cambios: 20150625JMV$002-----------------
    Public Sub New(ByVal strRutaReporte As String, _
                   ByVal strNombreReporte As String, _
                   ByVal strNombreServidor As String, _
                   ByVal strNombreBaseDeDatos As String, _
                   ByVal strUserID As String, _
                   ByVal strPassword As String, _
                   ByVal Conexion As SqlConnection, _
                   ByVal Privilegios As List(Of Integer))
        'Id. de cambios: 20150625JMV$002-----------------

        MyBase.New()
        InitializeComponent()

        Dim ArchivoConfiguracion As String = strRutaReporte.Substring(0, strRutaReporte.LastIndexOf(".")) + ".xml"        
        _RutaReporte = strRutaReporte
        _Servidor = strNombreServidor
        _BaseDeDatos = strNombreBaseDeDatos
        _UserID = strUserID
        _Password = strPassword
        'Id. de cambios: 20150625JMV$002-----------------
        _Lista = Privilegios
        'Id. de cambios: 20150625JMV$002-----------------

        _connection = Conexion
        CargaParametrosCatalogo(ArchivoConfiguracion)
        CargaReporte(strRutaReporte)
        lblReporte.Text = strRutaReporte
        Me.Text = strNombreReporte
    End Sub

#Region "CargaReporte"

    Private ParametrosCatalogo As New ArrayList()

    Private Sub CargaReporte(ByVal strReporte As String)
        Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim TotalParametros As Integer
        Dim NombreParametro As String
        Dim TipoDatoParametro As FieldValueType


        rptReporte.Load(strReporte)

        AplicaInfoConexion()

        ParametrosDelReporte = rptReporte.DataDefinition.ParameterFields
        TotalParametros = ParametrosDelReporte.Count

        'Label1.Text = TotalParametros.ToString & " parámetros"

        If TotalParametros > 0 Then
            For i = 0 To TotalParametros - 1
                'TextBox1.Text &= ParametrosDelReporte(i).Name
                NombreParametro = ParametrosDelReporte(i).Name
                TipoDatoParametro = ParametrosDelReporte(i).ValueType

                'Agregar el título del parámetro
                Dim l As New Label()
                With l
                    .AutoSize = True
                    .Left = 3
                    .Top = 50 + (i * 22)
                    .Visible = True
                    .Text = NombreParametro & ":"
                    .TextAlign = ContentAlignment.MiddleLeft
                End With
                Me.PanelControl.Controls.Add(l)

                Select Case TipoDatoParametro
                    Case FieldValueType.NumberField, FieldValueType.StringField, FieldValueType.CurrencyField
                        Dim cbo As ComboBox = CreaParametroCatalogo(NombreParametro)
                        If cbo Is Nothing Then

                            Dim oTextoNumero As TextBox
                            oTextoNumero = New TextBox()


                            Me.PanelControl.Controls.Add(oTextoNumero)
                            With oTextoNumero
                                .Tag = i
                                .Name = NombreParametro
                                .Top = 50 + (i * 22)
                                .Left = 110
                                .Width = 200
                                .Visible = True
                                .TabIndex = i
                                '.Text = NombreParametro & " " & TipoDatoParametro.ToString
                            End With
                        Else
                            Me.PanelControl.Controls.Add(cbo)
                            With cbo
                                .Tag = i
                                .Name = NombreParametro
                                .Top = 50 + (i * 22)
                                .Left = 110
                                .Width = 200
                                .Visible = True
                                .TabIndex = i
                                '.Text = NombreParametro & " " & TipoDatoParametro.ToString
                            End With
                        End If
                    Case FieldValueType.DateTimeField, FieldValueType.DateField
                        Dim oDTPicker As New DateTimePicker()

                        Me.PanelControl.Controls.Add(oDTPicker)

                        With oDTPicker
                            .Tag = i
                            .Name = NombreParametro
                            .Top = 50 + (i * 22)
                            .Left = 110
                            .Width = 200
                            .Visible = True
                            .TabIndex = i
                        End With
                    Case FieldValueType.BooleanField
                        Dim oCheckBox As New CheckBox()

                        Me.PanelControl.Controls.Add(oCheckBox)

                        With oCheckBox
                            .Tag = i
                            .Name = NombreParametro
                            .Top = 50 + (i * 22)
                            .Left = 110
                            .Width = 200
                            .Checked = True 'Siempre será verdadero
                            .Visible = True
                            .TabIndex = i
                        End With


                End Select
            Next
            Me.PanelControl.Controls(0).Focus()
        Else
            Dim l As New Label()
            With l
                .Text = "El reporte no requiere parámetros.  Puede consultarlo directamente dando clic en el botón 'Consultar'"
                .Width = 200
                .Height = 200
                .Left = 50
                .Top = 50
                .ForeColor = Color.MediumBlue
                .Visible = True
            End With

            Me.PanelControl.Controls.Add(l)
        End If

        Me.Refresh()
        Cursor = Cursors.Default

    End Sub

    Private Sub CargaParametrosCatalogo(ByVal ArchivoConfiguracion As String)
        If IO.File.Exists(ArchivoConfiguracion) Then
            Try
                Dim xml As New XmlDocument()
                Dim node, subnode As XmlNode
                Dim par As ParametroCatalogo
                Dim _Parametro, _Catalogo, _DisplayMember, _ValueMember, _Filtro As String
                xml.Load(ArchivoConfiguracion)
                For Each node In xml.ChildNodes(1).ChildNodes
                    For Each subnode In node.ChildNodes
                        _Parametro = node.Name
                        _Filtro = " where 1 = 1 "
                        Select Case subnode.Attributes.GetNamedItem("key").Value
                            Case "Catalogo"
                                _Catalogo = subnode.Attributes.GetNamedItem("value").Value
                            Case "ValueMember"
                                _ValueMember = subnode.Attributes.GetNamedItem("value").Value
                            Case "DisplayMember"
                                _DisplayMember = subnode.Attributes.GetNamedItem("value").Value
                            Case "Filtro"
                                _Filtro &= " and " & subnode.Attributes.GetNamedItem("value").Value
                        End Select
                    Next
                    ParametrosCatalogo.Add(New ParametroCatalogo(_Parametro, _Catalogo, _Filtro, _DisplayMember, _ValueMember))
                Next
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try

        End If
    End Sub
    Private Function CreaParametroCatalogo(ByVal Parametro As String) As ComboBox
        Dim pc As ParametroCatalogo
        Dim cb As ComboBox
        Dim dt As New DataTable()
        For Each pc In ParametrosCatalogo
            If "@" & pc.Parametro = Parametro Then
                cb = New ComboBox()
                dt = CargaTablaCatalogo(pc.Catalgo, pc.Filtro)
                cb.ValueMember = pc.ValueMember
                cb.DisplayMember = pc.DisplayMember
                cb.DataSource = dt
                cb.SelectedItem = Nothing
                cb.Text = String.Empty
                Return cb
            End If
        Next
        Return Nothing
    End Function
    Private Function CargaTablaCatalogo(ByVal Tabla As String, ByVal Filtro As String) As DataTable
        Dim strQuery As String = "select * from " & Tabla & Filtro
        Dim da As New SqlDataAdapter(strQuery, _connection)
        Dim dt As New DataTable()
        Try
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function
#End Region

#Region "AsignaValores"
    Private Sub AsignaValores()
        Cursor = Cursors.WaitCursor
        Dim Parametro As ParameterFieldDefinition
        Dim Valores As ParameterValues
        Dim Valor As ParameterDiscreteValue
        Dim Nombre As String
        Dim oControl As Control
        Dim strMensaje As String

        Try
            For Each Parametro In ParametrosDelReporte
                Nombre = Parametro.Name
                Valores = Parametro.CurrentValues
                For Each oControl In Me.PanelControl.Controls
                    If oControl.Name = Nombre Then
                        Valor = New ParameterDiscreteValue()

                        '20 de junio del 2003
                        Select Case Parametro.ValueType
                            Case FieldValueType.NumberField, FieldValueType.StringField
                                If Not CreaParametroCatalogo(Nombre) Is Nothing AndAlso CType(oControl, ComboBox).SelectedIndex >= 0 Then
                                    Valor.Value = CType(oControl, ComboBox).SelectedValue
                                ElseIf oControl.Text <> "" Then
                                    Valor.Value = oControl.Text
                                End If

                            Case FieldValueType.DateTimeField, FieldValueType.DateField
                                Valor.Value = CType(oControl, DateTimePicker).Value.Date
                            Case FieldValueType.BooleanField
                                Valor.Value = CType(oControl, CheckBox).Checked
                            Case Else
                                If oControl.Text <> "" Then
                                    Valor.Value = oControl.Text
                                End If
                        End Select


                        Valores.Add(Valor)
                        Parametro.ApplyCurrentValues(Valores)
                    End If
                Next
            Next


            Try
                Dim frmMensaje As New frmEspere()
                frmMensaje.Show()
                crvReporte.ReportSource = rptReporte
                Audita()
                frmMensaje.Dispose()
            Catch ex As Exception
                'Intenta ejecutar nuevamente
                strMensaje = "El reporte " & Me.Text & " no puede ser ejecutado en este momento." & _
                "¿Desea intentar nuevamente?"

                If MessageBox.Show(strMensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    AsignaValores()
                End If
            End Try

        Catch exFormatoParametro As System.FormatException
            strMensaje = "Los parámetros asignados son incoherentes.  Favor de corregirlos e intentar de nuevo."
            MessageBox.Show(strMensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            crvReporte.ReportSource = Nothing

        Catch exParametroCrystal As CrystalDecisions.CrystalReports.Engine.ParameterFieldException
            strMensaje = "Los parámetros asignados son incoherentes.  Favor de corregirlos e intentar de nuevo."
            MessageBox.Show(strMensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            crvReporte.ReportSource = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            crvReporte.ReportSource = Nothing

        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
#End Region


    Private Sub AplicaInfoConexion()
        'Dim sect As Section, repObj As ReportObject
        'For Each sect In rptReporte.ReportDefinition.Sections
        '    For Each repObj In sect.ReportObjects(
        '        If repObj.Kind = ReportObjectKind.SubreportObject Then
        '        End If
        '    Next

        'Next
        For Each _TablaReporte In rptReporte.Database.Tables

            _LogonInfo = _TablaReporte.LogOnInfo

            With _LogonInfo.ConnectionInfo
                .ServerName = _Servidor
                .DatabaseName = _BaseDeDatos
                .UserID = _UserID
                .Password = _Password
            End With

            Try
                _TablaReporte.ApplyLogOnInfo(_LogonInfo)

            Catch exArgumentos As ArgumentNullException
                MessageBox.Show("La información de seguridad para este reporte está incompleta.  Por favor intente de nuevo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Next

    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click        
        Me.Close()
    End Sub

    Private Sub Audita()
        'Graba en el event log la ejecución del reporte por el usuario
        Dim strMensaje As String = _
        "El reporte: " & Me.Text & " ha sido ejecutado por el usuario: " & _UserID & " en el servidor: " & _Servidor & " base de datos: " & _BaseDeDatos
        'EventLog.WriteEntry(Main.GLOBAL_NombreModulo & " Reportes Dinámicos", strMensaje, EventLogEntryType.Information)
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
            AsignaValores()
        Catch exArgumentos As ArgumentNullException
            MessageBox.Show("La información de seguridad para este reporte está incompleta.  Por favor intente de nuevo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lnkAyuda_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAyuda.LinkClicked
        Ayuda()
    End Sub

    Private Sub Ayuda()
        Cursor = Cursors.WaitCursor
        Dim oHelp As New frmAyuda()
        Me.AddOwnedForm(oHelp)
        oHelp.Show()
        Cursor = Cursors.Default
    End Sub

    'Id. de cambios: 20150625JMV$002-----------------
    Private Sub frmReporte_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try
            crvReporte.ShowPrintButton = False
            crvReporte.ShowExportButton = False

            Dim li As Integer

            For Each li In _Lista
                Select Case li
                    Case 6
                        crvReporte.ShowPrintButton = True
                    Case 7
                        crvReporte.ShowExportButton = True
                End Select
            Next
        Catch err As Exception
            MessageBox.Show("Ocurrió el siguiente error:" & Chr(13) & err.ToString, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    'Id. de cambios: 20150625JMV$002-----------------

    Private Sub crvReporte_Load(sender As System.Object, e As System.EventArgs) Handles crvReporte.Load

    End Sub
End Class

Public Class ParametroCatalogo
    Private _Parametro, _Catalogo, _DisplayMember, _ValueMember, _Filtro As String

    Public Sub New(ByVal Parametro As String, ByVal Catalogo As String, ByVal Filtro As String, ByVal DisplayMember As String, ByVal ValueMember As String)
        Me._Parametro = Parametro
        Me._Catalogo = Catalogo
        Me._Filtro = Filtro
        Me._DisplayMember = DisplayMember
        Me._ValueMember = ValueMember
    End Sub

    ReadOnly Property Parametro() As String
        Get
            Return _Parametro
        End Get
    End Property

    ReadOnly Property Catalgo() As String
        Get
            Return _Catalogo
        End Get
    End Property

    ReadOnly Property DisplayMember() As String
        Get
            Return _DisplayMember
        End Get
    End Property

    ReadOnly Property ValueMember() As String
        Get
            Return _ValueMember
        End Get
    End Property

    ReadOnly Property Filtro() As String
        Get
            Return _Filtro
        End Get
    End Property

End Class
Imports System.Windows.Forms
Public Class FiltroConsulta
    Inherits System.Windows.Forms.Form

    Private dtEstructura As DataTable
    Private _FiltroConsulta As String
    Dim WithEvents o As SigaMetClasses.Combos.ComboCondicionFiltro

#Region "Propiedades"
    Public ReadOnly Property FiltroConsulta() As String
        Get
            Return _FiltroConsulta
        End Get
    End Property

    Public ReadOnly Property FiltroConsultaDescripcion() As String
        Get
            Dim _Desc As String
            _Desc = _FiltroConsulta
            _Desc = Replace(_Desc, "AND", "y")
            _Desc = Replace(_Desc, "LIKE", "Contiene")
            _Desc = Replace(_Desc, "NOT", "No")
            _Desc = Replace(_Desc, "No Contiene", "No contiene")
            _Desc = Replace(_Desc, "BETWEEN", "Está entre")

            Return _Desc
        End Get
    End Property
#End Region


    Public Sub New(ByVal dtDataTable As DataTable, _
          Optional ByVal CargaOperadorBETWEEN As Boolean = True)
        'Con este constructor se consideran todas las columnas del DataTable
        'CargaOperadorBETWEEN -> Indica si el filtro de resultado se va a usar en un
        'dataView.  Si es False provoca que no se cargue el operador BETWEEN, ya que
        'no es soportado como expresión en el RowFilter de un DataView.
        MyBase.New()
        InitializeComponent()

        dtEstructura = dtDataTable
        GeneraControles(_CargaOperadorBETWEEN:=CargaOperadorBETWEEN)
    End Sub

    Public Sub New(ByVal dtDataTable As DataTable, _
                   ByVal CamposAIncluir() As String)
        MyBase.New()
        InitializeComponent()

        dtEstructura = dtDataTable
        GeneraControles(CamposAIncluir)

    End Sub

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
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
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents stbEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents pnlControl As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FiltroConsulta))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.stbEstatus = New System.Windows.Forms.StatusBar()
        Me.pnlControl = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(578, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(578, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'stbEstatus
        '
        Me.stbEstatus.Location = New System.Drawing.Point(0, 129)
        Me.stbEstatus.Name = "stbEstatus"
        Me.stbEstatus.Size = New System.Drawing.Size(658, 22)
        Me.stbEstatus.TabIndex = 2
        Me.stbEstatus.Text = "Seleccione el filtro que desee para la consulta de registros."
        '
        'pnlControl
        '
        Me.pnlControl.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.pnlControl.AutoScroll = True
        Me.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlControl.Location = New System.Drawing.Point(8, 8)
        Me.pnlControl.Name = "pnlControl"
        Me.pnlControl.Size = New System.Drawing.Size(560, 120)
        Me.pnlControl.TabIndex = 3
        '
        'FiltroConsulta
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(658, 151)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlControl, Me.stbEstatus, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FiltroConsulta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filtro de consulta v2"
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Función para generar al vuelo los controles que se relacionan con los campos
    'del DataTable.
    'Nota: Los campos bit (Boolean) no se consideran en el filtro.
    'La variable SeOmiteElCampo indica si se omite el control para agregarse al form.

    Private Sub GeneraControles(Optional ByVal Campos() As String = Nothing, _
                                Optional ByVal _CargaOperadorBETWEEN As Boolean = True)

        Cursor = Cursors.WaitCursor

        If dtEstructura Is Nothing Then
            _FiltroConsulta = ""
            btnAceptar.Enabled = False
            Exit Sub
        End If

        'Se agregó c2 para el control de los BETWEEN
        '03 de octubre del 2003
        Dim i As Integer, c As Control = Nothing, c2 As Control = Nothing
        Dim CampoAgregado As Boolean
        Dim CamposAgregados As Integer
        Dim SeOmiteElCampo As Boolean = False
        Dim x As System.Drawing.Point
        Dim y As System.Drawing.Point = Nothing

        x.Y = 16

        For i = 0 To dtEstructura.Columns.Count - 1
            CampoAgregado = False
            SeOmiteElCampo = False

            If Campos Is Nothing Then

                Dim l As New Label()

                'Valido el tipo de dato de la columna y selecciono el control 
                'adecuado.
                If dtEstructura.Columns(i).DataType.Name = "String" Then
                    c = New TextBox()
                    c2 = New TextBox()
                    o = New SigaMetClasses.Combos.ComboCondicionFiltro(False, _CargaOperadorBETWEEN)
                    c.Tag = i
                    c2.Tag = i
                    o.Tag = i
                    AddHandler o.SelectedIndexChanged, AddressOf Me.ManejaCambioFiltro
                End If

                If dtEstructura.Columns(i).DataType.Name = "Int16" Or _
                dtEstructura.Columns(i).DataType.Name = "Int32" Or _
                dtEstructura.Columns(i).DataType.Name = "Int64" Or _
                dtEstructura.Columns(i).DataType.Name = "Byte" Then
                    c = New SigaMetClasses.Controles.txtNumeroEntero()
                    c2 = New SigaMetClasses.Controles.txtNumeroEntero()
                    o = New SigaMetClasses.Combos.ComboCondicionFiltro(True, _CargaOperadorBETWEEN)
                    c.Tag = i
                    c2.Tag = i
                    o.Tag = i
                    AddHandler o.SelectedIndexChanged, AddressOf Me.ManejaCambioFiltro
                End If

                If dtEstructura.Columns(i).DataType.Name = "Decimal" Then
                    c = New SigaMetClasses.Controles.txtNumeroDecimal()
                    c2 = New SigaMetClasses.Controles.txtNumeroDecimal()
                    o = New SigaMetClasses.Combos.ComboCondicionFiltro(True, _CargaOperadorBETWEEN)
                    c.Tag = i
                    c2.Tag = i
                    o.Tag = i
                    AddHandler o.SelectedIndexChanged, AddressOf Me.ManejaCambioFiltro
                End If

                If dtEstructura.Columns(i).DataType.Name = "DateTime" Then
                    c = New DateTimePicker()
                    c2 = New DateTimePicker()
                    CType(c, DateTimePicker).Value = Now.Date
                    CType(c, DateTimePicker).MinDate = "01/01/1999"
                    CType(c, DateTimePicker).MaxDate = "31/12/2010"
                    CType(c, DateTimePicker).Format = DateTimePickerFormat.Short
                    CType(c2, DateTimePicker).Value = Now.Date
                    CType(c2, DateTimePicker).MinDate = "01/01/1999"
                    CType(c2, DateTimePicker).MaxDate = "31/12/2010"
                    CType(c2, DateTimePicker).Format = DateTimePickerFormat.Short
                    o = New SigaMetClasses.Combos.ComboCondicionFiltro(True, _CargaOperadorBETWEEN)
                    c.Tag = i
                    c2.Tag = i
                    o.Tag = i
                    AddHandler o.SelectedIndexChanged, AddressOf Me.ManejaCambioFiltro

                End If

                '19 de noviembre del 2002
                If dtEstructura.Columns(i).DataType.Name = "Boolean" Then
                    SeOmiteElCampo = True
                End If

                If SeOmiteElCampo = False Then

                    x.X = 16

                    l.Location = x

                    x.X = 200
                    o.Location = x

                    x.X = 330
                    c.Location = x

                    '"y"
                    x.X = 435
                    Dim lblY As New Label()
                    lblY.Location = x
                    lblY.AutoSize = True
                    lblY.Name = "@lbl" & dtEstructura.Columns(i).ColumnName
                    lblY.TextAlign = Drawing.ContentAlignment.MiddleLeft
                    lblY.Text = "y"
                    lblY.Visible = False
                    lblY.Tag = i

                    'Segundo control
                    x.X = 450
                    c2.Location = x

                    l.AutoSize = True
                    l.Name = "lbl" & dtEstructura.Columns(i).ColumnName
                    l.Text = dtEstructura.Columns(i).ColumnName & ":"
                    l.TextAlign = Drawing.ContentAlignment.MiddleLeft

                    o.Name = "Op" & dtEstructura.Columns(i).ColumnName

                    c.Name = "_" & dtEstructura.Columns(i).ColumnName
                    c.Text = ""
                    c.Width = 100

                    c2.Name = "@" & dtEstructura.Columns(i).ColumnName
                    c2.Text = ""
                    c2.Width = 100
                    c2.Visible = False

                    AddHandler c.Click, AddressOf ManejaClick

                    Me.pnlControl.Controls.Add(l)
                    Me.pnlControl.Controls.Add(o)
                    Me.pnlControl.Controls.Add(c)
                    Me.pnlControl.Controls.Add(lblY)
                    Me.pnlControl.Controls.Add(c2)

                    CampoAgregado = True
                    CamposAgregados += 1

                    x.Y = x.Y + (22)
                End If
            Else
                Dim strNombreColumna As String = dtEstructura.Columns(i).ColumnName
                Dim a As Integer
                For a = 0 To Campos.Length - 1
                    If Campos(a) = strNombreColumna Then

                        Dim l As New Label()
                        Dim o As SigaMetClasses.Combos.ComboCondicionFiltro = Nothing

                        'Valido el tipo de dato de la columna y selecciono el control 
                        'adecuado.
                        If dtEstructura.Columns(i).DataType.Name = "String" Then
                            c = New TextBox()
                            o = New SigaMetClasses.Combos.ComboCondicionFiltro(False, _CargaOperadorBETWEEN)
                        End If

                        If dtEstructura.Columns(i).DataType.Name = "Int16" Or _
                        dtEstructura.Columns(i).DataType.Name = "Int32" Or _
                        dtEstructura.Columns(i).DataType.Name = "Int64" Or _
                        dtEstructura.Columns(i).DataType.Name = "Byte" Then
                            c = New SigaMetClasses.Controles.txtNumeroEntero()
                            o = New SigaMetClasses.Combos.ComboCondicionFiltro(True, _CargaOperadorBETWEEN)
                        End If

                        If dtEstructura.Columns(i).DataType.Name = "Decimal" Then
                            c = New SigaMetClasses.Controles.txtNumeroDecimal()
                            o = New SigaMetClasses.Combos.ComboCondicionFiltro(True, _CargaOperadorBETWEEN)
                        End If

                        If dtEstructura.Columns(i).DataType.Name = "DateTime" Then
                            c = New DateTimePicker()
                            CType(c, DateTimePicker).Value = Now.Date
                            CType(c, DateTimePicker).MinDate = "01/01/1999"
                            CType(c, DateTimePicker).MaxDate = "31/12/2010"
                            CType(c, DateTimePicker).Format = DateTimePickerFormat.Short
                            o = New SigaMetClasses.Combos.ComboCondicionFiltro(True, _CargaOperadorBETWEEN)
                        End If

                        '19 de noviembre del 2002
                        If dtEstructura.Columns(i).DataType.Name = "Boolean" Then
                            SeOmiteElCampo = True
                        End If

                        If SeOmiteElCampo = False Then

                            x.X = 16

                            l.Location = x

                            x.X = 200
                            o.Location = x

                            x.X = 330
                            c.Location = x

                            l.AutoSize = True
                            l.Name = "lbl" & dtEstructura.Columns(i).ColumnName
                            l.Text = dtEstructura.Columns(i).ColumnName & ":"
                            l.TextAlign = Drawing.ContentAlignment.MiddleLeft

                            o.Name = "Op" & dtEstructura.Columns(i).ColumnName

                            c.Name = "_" & dtEstructura.Columns(i).ColumnName
                            c.Text = ""
                            c.Width = 130

                            AddHandler c.Click, AddressOf ManejaClick


                            Me.pnlControl.Controls.Add(l)
                            Me.pnlControl.Controls.Add(o)
                            Me.pnlControl.Controls.Add(c)

                            CampoAgregado = True
                            CamposAgregados += 1

                            x.Y = x.Y + (22)
                        End If

                    End If
                Next a
            End If

            If CampoAgregado = True Then
                'Se agranda el form a partir del 5to control
                If Me.pnlControl.Controls.Count > 9 Then
                    Me.Height = (100 + (CamposAgregados * 21))
                End If
            End If

        Next i

        Cursor = Cursors.Default

    End Sub

    Public Overridable Sub ManejaClick(ByVal sender As Object, ByVal e As System.EventArgs)
        'MessageBox.Show("Soy el click del combo " & CType(sender, ComboBox).Name)
    End Sub

    Private Function GeneraCadenaFiltroConsulta() As String
        Dim strCadena As String = "", c As Control, iFiltro As Integer = 0
        Dim strNombreCampo As String = "", strValor As String = ""
        For Each c In Me.pnlControl.Controls
            If TypeOf c Is SigaMetClasses.Combos.ComboCondicionFiltro Then 'ComboBox And Mid(c.Name, 1, 2) = "Op" Then
                Dim opControl As SigaMetClasses.Combos.ComboCondicionFiltro = CType(c, SigaMetClasses.Combos.ComboCondicionFiltro)
                If opControl.Condicion > 0 Then
                    iFiltro += 1
                    strNombreCampo = Replace(opControl.Name, "Op", "")
                    Dim v As Control
                    For Each v In Me.pnlControl.Controls
                        If Mid(v.Name, 1, 1) = "_" Then
                            If v.Name = "_" & strNombreCampo Then
                                If v.GetType.Name = "TextBox" Then
                                    strValor = "'" & v.Text & "'"
                                End If
                                If v.GetType.Name = "DateTimePicker" Then
                                    strValor = "'" & CType(v, DateTimePicker).Value.ToShortDateString & "'"
                                End If
                                If v.GetType.Name = "txtNumeroEntero" Then
                                    If v.Text <> "" Then
                                        strValor = v.Text
                                    Else
                                        strValor = "0"
                                    End If
                                End If
                                If v.GetType.Name = "txtNumeroDecimal" Then
                                    If v.Text <> "" Then
                                        strValor = v.Text
                                    Else
                                        strValor = "0"
                                    End If

                                End If
                            End If
                        End If
                    Next
                    'Nuevo
                    If opControl.Condicion = 9 Then
                        strValor &= " AND "
                        For Each v In Me.pnlControl.Controls
                            If v.Name = "@" & strNombreCampo Then
                                If v.GetType.Name = "TextBox" Then
                                    strValor &= "'" & v.Text & "'"
                                End If
                                If v.GetType.Name = "DateTimePicker" Then
                                    strValor &= "'" & CType(v, DateTimePicker).Value.ToShortDateString & " 23:59:59'"
                                End If
                                If v.GetType.Name = "txtNumeroEntero" Then
                                    If v.Text <> "" Then
                                        strValor &= v.Text
                                    Else
                                        strValor &= "0"
                                    End If
                                End If
                                If v.GetType.Name = "txtNumeroDecimal" Then
                                    If v.Text <> "" Then
                                        strValor &= v.Text
                                    Else
                                        strValor &= "0"
                                    End If

                                End If
                            End If
                        Next
                    End If

                    If iFiltro > 1 Then
                        strCadena &= " AND "
                    End If
                    strCadena &= strNombreCampo & " " & opControl.Operador & " "
                    If opControl.Operador = "LIKE" Or opControl.Operador = "NOT LIKE" Then
                        strValor = Replace(strValor, "%", "")
                        strCadena &= "'%" & Replace(strValor, "'", "") & "%'"
                    Else
                        strCadena &= strValor
                    End If
                End If
            End If
        Next

        Return strCadena
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        _FiltroConsulta = GeneraCadenaFiltroConsulta()
        DialogResult = DialogResult.OK
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub ManejaCambioFiltro(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oControl As Control, iTag As Integer = CType(sender, SigaMetClasses.Combos.ComboCondicionFiltro).Tag
        If CType(sender, SigaMetClasses.Combos.ComboCondicionFiltro).Condicion = 9 Then
            For Each oControl In Me.pnlControl.Controls
                If Not TypeOf oControl Is SigaMetClasses.Combos.ComboCondicionFiltro Then
                    If oControl.Tag = iTag Then
                        If oControl.Name.Substring(0, 1) = "@" Then
                            oControl.Visible = True
                        End If
                    End If
                End If
            Next
        Else
            For Each oControl In Me.pnlControl.Controls
                If Not TypeOf oControl Is SigaMetClasses.Combos.ComboCondicionFiltro Then
                    If oControl.Tag = iTag Then
                        If oControl.Name.Substring(0, 1) = "@" Then
                            oControl.Visible = False
                        End If
                    End If
                End If
            Next
        End If
    End Sub

End Class

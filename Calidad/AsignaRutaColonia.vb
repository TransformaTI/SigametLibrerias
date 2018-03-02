Imports SigaMetClasses.Enumeradores
Public Class frmAsignaRutaColonia
    Inherits System.Windows.Forms.Form


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
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboRuta As SigaMetClasses.Combos.ComboRuta2Filtro
    Friend WithEvents mnuEliminaHorario As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboDiaSemana As SigaMetClasses.Combos.ComboDiasSemana
    Friend WithEvents dtpHorarioIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpHorarioFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnAgregarHorario As System.Windows.Forms.Button
    Friend WithEvents vgHorarios As CallesColonias.ViewGrid
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents rgrpDatos As CallesColonias.RoundedGroupBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsignaRutaColonia))
        Me.mnuEliminaHorario = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.cboRuta = New SigaMetClasses.Combos.ComboRuta2Filtro()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboDiaSemana = New SigaMetClasses.Combos.ComboDiasSemana()
        Me.dtpHorarioIni = New System.Windows.Forms.DateTimePicker()
        Me.dtpHorarioFin = New System.Windows.Forms.DateTimePicker()
        Me.btnAgregarHorario = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.vgHorarios = New CallesColonias.ViewGrid()
        Me.rgrpDatos = New CallesColonias.RoundedGroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuEliminaHorario
        '
        Me.mnuEliminaHorario.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        resources.ApplyResources(Me.MenuItem1, "MenuItem1")
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Window
        Me.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtNombre, "txtNombre")
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.Window
        Me.txtNombre.Name = "txtNombre"
        '
        'lblNombre
        '
        resources.ApplyResources(Me.lblNombre, "lblNombre")
        Me.lblNombre.Name = "lblNombre"
        '
        'cboRuta
        '
        resources.ApplyResources(Me.cboRuta, "cboRuta")
        Me.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRuta.Name = "cboRuta"
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.BackColor = System.Drawing.Color.Gainsboro
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboDiaSemana)
        Me.GroupBox1.Controls.Add(Me.dtpHorarioIni)
        Me.GroupBox1.Controls.Add(Me.dtpHorarioFin)
        Me.GroupBox1.Controls.Add(Me.btnAgregarHorario)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.vgHorarios)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'cboDiaSemana
        '
        resources.ApplyResources(Me.cboDiaSemana, "cboDiaSemana")
        Me.cboDiaSemana.Dia = CType(0, Byte)
        Me.cboDiaSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDiaSemana.DropDownWidth = 88
        Me.cboDiaSemana.Name = "cboDiaSemana"
        '
        'dtpHorarioIni
        '
        resources.ApplyResources(Me.dtpHorarioIni, "dtpHorarioIni")
        Me.dtpHorarioIni.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHorarioIni.MaxDate = New Date(2000, 1, 2, 0, 0, 0, 0)
        Me.dtpHorarioIni.Name = "dtpHorarioIni"
        Me.dtpHorarioIni.Value = New Date(2000, 1, 1, 0, 0, 0, 0)
        '
        'dtpHorarioFin
        '
        resources.ApplyResources(Me.dtpHorarioFin, "dtpHorarioFin")
        Me.dtpHorarioFin.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHorarioFin.MaxDate = New Date(2000, 1, 2, 0, 0, 0, 0)
        Me.dtpHorarioFin.Name = "dtpHorarioFin"
        Me.dtpHorarioFin.Value = New Date(2000, 1, 1, 0, 0, 0, 0)
        '
        'btnAgregarHorario
        '
        Me.btnAgregarHorario.BackColor = System.Drawing.Color.Gainsboro
        resources.ApplyResources(Me.btnAgregarHorario, "btnAgregarHorario")
        Me.btnAgregarHorario.Name = "btnAgregarHorario"
        Me.btnAgregarHorario.UseVisualStyleBackColor = False
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Name = "Label4"
        '
        'vgHorarios
        '
        Me.vgHorarios.AlternativeBackColor = System.Drawing.Color.Gainsboro       
        Me.vgHorarios.CheckCondition = Nothing
        Me.vgHorarios.ContextMenu = Me.mnuEliminaHorario
        Me.vgHorarios.DataSource = Nothing
        resources.ApplyResources(Me.vgHorarios, "vgHorarios")
        Me.vgHorarios.FormatColumnNames = New String(-1) {}
        Me.vgHorarios.FullRowSelect = True
        Me.vgHorarios.GridLines = True
        Me.vgHorarios.HidedColumnNames = New String() {"Día,HoraInicio,HoraTermino"}
        Me.vgHorarios.HideSelection = False
        Me.vgHorarios.MultiSelect = False
        Me.vgHorarios.Name = "vgHorarios"
        Me.vgHorarios.NullText = "--"
        Me.vgHorarios.PKColumnNames = Nothing
        Me.vgHorarios.TabStop = False
        Me.vgHorarios.UseCompatibleStateImageBehavior = False
        Me.vgHorarios.View = System.Windows.Forms.View.Details
        '
        'rgrpDatos
        '
        resources.ApplyResources(Me.rgrpDatos, "rgrpDatos")
        Me.rgrpDatos.BackColor = System.Drawing.Color.Gainsboro
        Me.rgrpDatos.BorderColor = System.Drawing.Color.Sienna
        Me.rgrpDatos.Controls.Add(Me.GroupBox1)
        Me.rgrpDatos.Controls.Add(Me.cboRuta)
        Me.rgrpDatos.Controls.Add(Me.Label1)
        Me.rgrpDatos.Controls.Add(Me.lblNombre)
        Me.rgrpDatos.Controls.Add(Me.txtNombre)
        Me.rgrpDatos.FlatStyle = CallesColonias.RoundedGroupBox.Style.Pipe
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'frmAsignaRutaColonia
        '
        resources.ApplyResources(Me, "$this")
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.Controls.Add(Me.rgrpDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Name = "frmAsignaRutaColonia"
        Me.ShowInTaskbar = False
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.rgrpDatos.ResumeLayout(False)
        Me.rgrpDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constructores"    
    'Modificación
    Public Sub New(ByVal Colonia As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = "Asignación de ruta y horarios por colonia."        
        Me.Colonia = Colonia
        CargaDatos()
        CargaHorarios()
    End Sub
#End Region

#Region "Variables globales"
    Private Municipio As Integer
    Private Colonia As Integer    
    Dim Ruta As Integer
    Dim semaforo As Integer = 0
    Dim dtHorarios As New DataTable()
#End Region
#Region "Carga de datos"
    Private Sub CargaDatos()
        cboRuta.CargaDatos()
        cboDiaSemana.CargaDiasSemana()        
        Dim cmdCC As New SqlCommand("spObtieneRutaColonia", Globales.GetInstance.cnSigamet)
        Dim drColonia As SqlDataReader
        cmdCC.Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia
        cmdCC.CommandType = CommandType.StoredProcedure
        Try
            If Globales.GetInstance.cnSigamet.State <> ConnectionState.Open Then
                Globales.GetInstance.cnSigamet.Open()
            End If
            drColonia = cmdCC.ExecuteReader
            If drColonia.Read Then
                txtNombre.Text = CStr(drColonia("Nombre"))
                Ruta = CInt(drColonia("Ruta"))
                cboRuta.SelectedValue = drColonia("Ruta")
            End If
            drColonia.Close()
            cboRuta.Focus()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            If Globales.GetInstance.cnSigamet.State <> ConnectionState.Closed Then
                Globales.GetInstance.cnSigamet.Close()
            End If
        End Try
    End Sub
    Private Sub CargaHorarios()        
        Dim cmdCC As New SqlCommand("spObtieneRutaColoniaHorarios", Globales.GetInstance.cnSigamet)
        Dim daCC As New SqlDataAdapter(cmdCC)
        cmdCC.Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia
        cmdCC.Parameters.Add("@Ruta", SqlDbType.Int).Value = cboRuta.SelectedValue
        cmdCC.CommandType = CommandType.StoredProcedure
        Try
            daCC.Fill(dtHorarios)
            vgHorarios.DataSource = dtHorarios            
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
#End Region
#Region "Manejo de cajas de texto"
    Private Sub TextBox_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.Enter
        CType(sender, TextBox).BackColor = Color.LemonChiffon
        CType(sender, TextBox).SelectAll()
    End Sub
    Private Sub TextBox_leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.Leave
        CType(sender, TextBox).BackColor = Color.White
    End Sub
#End Region
#Region "Manejo de botones"
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim cmdCC As New SqlCommand("spActualizaRutaColonia", Globales.GetInstance.cnSigamet)
        'cmdCC.Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia
        'cmdCC.Parameters.Add("@Ruta", SqlDbType.Int).Value = cboRuta.SelectedValue
        'cmdCC.CommandType = CommandType.StoredProcedure
        'Try
        '    If Globales.GetInstance.cnSigamet.State <> ConnectionState.Open Then
        '        Globales.GetInstance.cnSigamet.Open()
        '    End If
        '    cmdCC.ExecuteNonQuery()
        '    Globales.GetInstance.cnSigamet.Close()
        '    ActualizaRutaColoniaHorarios()
        '    Me.DialogResult = DialogResult.OK
        '    Me.Close()

        'Catch ex As Exception
        '    Globales.GetInstance.ExMessage(ex)
        'Finally
        '    If Globales.GetInstance.cnSigamet.State <> ConnectionState.Closed Then
        '        Globales.GetInstance.cnSigamet.Close()
        '    End If
        'End Try

    End Sub
#End Region
    Private Sub btnAgregarHorario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarHorario.Click
        If cboDiaSemana.Text <> "" Then
            If (dtpHorarioFin.Value.Hour > dtpHorarioIni.Value.Hour) Or (dtpHorarioFin.Value.Hour = dtpHorarioIni.Value.Hour And dtpHorarioFin.Value.Minute > dtpHorarioIni.Value.Minute) Then
                Dim cmdCC As New SqlCommand("spActualizaRutaColonia", Globales.GetInstance.cnSigamet)
                cmdCC.Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia
                cmdCC.Parameters.Add("@Ruta", SqlDbType.Int).Value = cboRuta.SelectedValue
                cmdCC.CommandType = CommandType.StoredProcedure
                Try
                    If Globales.GetInstance.cnSigamet.State <> ConnectionState.Open Then
                        Globales.GetInstance.cnSigamet.Open()
                    End If
                    cmdCC.ExecuteNonQuery()
                    Globales.GetInstance.cnSigamet.Close()
                    ActualizaRutaColoniaHorarios()
                Catch ex As Exception
                    Globales.GetInstance.ExMessage(ex)
                Finally
                    If Globales.GetInstance.cnSigamet.State <> ConnectionState.Closed Then
                        Globales.GetInstance.cnSigamet.Close()
                    End If
                End Try
                ActualizaGridHorarios()
            Else
                MessageBox.Show("La hora inicial debe ser menor a la hora final", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("No se ha seleccionado día de la semana", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub ActualizaRutaColoniaHorarios()
        Dim cmdCC As New SqlCommand("spActualizaRutaColoniaHorario", Globales.GetInstance.cnSigamet)
        cmdCC.Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia
        cmdCC.Parameters.Add("@Ruta", SqlDbType.Int).Value = cboRuta.SelectedValue
        cmdCC.Parameters.Add("@DiaSemana", SqlDbType.Int).Value = cboDiaSemana.Dia
        cmdCC.Parameters.Add("@HoraInicio", SqlDbType.VarChar).Value = dtpHorarioIni.Value.TimeOfDay.ToString()
        cmdCC.Parameters.Add("@HoraTermino", SqlDbType.VarChar).Value = dtpHorarioFin.Value.TimeOfDay.ToString()
        cmdCC.Parameters.Add("@Inserta", SqlDbType.Bit).Value = 1
        cmdCC.CommandType = CommandType.StoredProcedure
        Try
            If Globales.GetInstance.cnSigamet.State <> ConnectionState.Open Then
                Globales.GetInstance.cnSigamet.Open()
            End If
            cmdCC.ExecuteNonQuery()
            Globales.GetInstance.cnSigamet.Close()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            If Globales.GetInstance.cnSigamet.State <> ConnectionState.Closed Then
                Globales.GetInstance.cnSigamet.Close()
            End If
        End Try
    End Sub

    Private Sub cboRuta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRuta.SelectedIndexChanged
        If semaforo = 1 Then
            dtHorarios.Clear()
            vgHorarios.Clear()
            CargaHorarios()
        End If
    End Sub

    Private Sub frmAsignaRutaColonia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        semaforo = 1        
    End Sub

    Private Sub frmAsignaRutaColonia_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Dim cmdCC As New SqlCommand("spActualizaRutaColoniaHorario", Globales.GetInstance.cnSigamet)
        cmdCC.Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia
        cmdCC.Parameters.Add("@Ruta", SqlDbType.Int).Value = cboRuta.SelectedValue
        cmdCC.Parameters.Add("@DiaSemana", SqlDbType.Int).Value = Me.vgHorarios.CurrentRow("Dia")
        cmdCC.Parameters.Add("@HoraInicio", SqlDbType.VarChar).Value = Me.vgHorarios.CurrentRow("HoraInicio")
        cmdCC.Parameters.Add("@HoraTermino", SqlDbType.VarChar).Value = Me.vgHorarios.CurrentRow("HoraTermino")
        cmdCC.Parameters.Add("@Inserta", SqlDbType.Bit).Value = 0

        cmdCC.CommandType = CommandType.StoredProcedure
        Try
            If Globales.GetInstance.cnSigamet.State <> ConnectionState.Open Then
                Globales.GetInstance.cnSigamet.Open()
            End If
            cmdCC.ExecuteNonQuery()
            Globales.GetInstance.cnSigamet.Close()
            ActualizaGridHorarios()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            If Globales.GetInstance.cnSigamet.State <> ConnectionState.Closed Then
                Globales.GetInstance.cnSigamet.Close()
            End If
        End Try
    End Sub

    Private Sub ActualizaGridHorarios()
        Dim cmdCC2 As New SqlCommand("spObtieneRutaColoniaHorarios", Globales.GetInstance.cnSigamet)
        Dim daCC As New SqlDataAdapter(cmdCC2)
        cmdCC2.Parameters.Add("@Colonia", SqlDbType.Int).Value = Colonia
        cmdCC2.Parameters.Add("@Ruta", SqlDbType.Int).Value = cboRuta.SelectedValue
        cmdCC2.CommandType = CommandType.StoredProcedure
        vgHorarios.Clear()
        dtHorarios.Clear()
        Try
            daCC.Fill(dtHorarios)
            vgHorarios.DataSource = dtHorarios           
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub

    Private Sub mnuEliminaHorario_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEliminaHorario.Popup

    End Sub
End Class


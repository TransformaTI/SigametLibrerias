Imports System.Data.SqlClient


Public Class frmParametrosUsuario
    Private rowIndex As Integer = 0

#Region "Datos"
    Public dtListaModulos As New DataTable("Modulos")
    Public dtListaParametros As New DataTable("Parametros")
    Public dtListaUsuarios As New DataTable("Usuarios")
    Public dtListaParametrosPersonalizados As New DataTable("ParametrosUsuario")

    Public Sub ConsultaModulos()
        dtListaModulos.Clear()

        Dim daModulos As New SqlDataAdapter("spSEGConsultaModulos", cnSIGAMET)
        daModulos.SelectCommand.CommandType = CommandType.StoredProcedure
        daModulos.Fill(dtListaModulos)
        cboModulos.DataSource = dtListaModulos
        cboModulos.ValueMember = "Modulo"
        cboModulos.DisplayMember = "Nombre"
    End Sub

    Public Sub ConsultaParametros(ByVal Modulo As Short)
        dtListaParametros.Clear()

        Dim daParametros As New SqlDataAdapter("spSEGConsultaParametro", cnSIGAMET)
        daParametros.SelectCommand.CommandType = CommandType.StoredProcedure
        daParametros.SelectCommand.Parameters.AddWithValue("@Modulo", Modulo)
        daParametros.Fill(dtListaParametros)
        cboParametros.DataSource = dtListaParametros
        cboParametros.ValueMember = "Parametro"
        cboParametros.DisplayMember = "Parametro"
    End Sub

    Public Sub ConsultaUsuarios()
        dtListaUsuarios.Clear()

        Dim daUsuarios As New SqlDataAdapter("spSEGConsultaUsuarios", cnSIGAMET)
        daUsuarios.SelectCommand.CommandType = CommandType.StoredProcedure
        daUsuarios.Fill(dtListaUsuarios)
        cboUsuarios.DataSource = dtListaUsuarios
        cboUsuarios.ValueMember = "Usuario"
        cboUsuarios.DisplayMember = "NombreCompuesto"
    End Sub

    Public Sub ConsultaParametrosPersonalizados()
        If Not dtListaParametrosPersonalizados.Columns.Contains("ModuloNombre") Then
            dtListaParametrosPersonalizados.Columns.Add("ModuloNombre")
        End If

        RemoveHandler dtListaParametrosPersonalizados.RowChanged, AddressOf RowChanged
        RemoveHandler dtListaParametrosPersonalizados.RowDeleted, AddressOf RowDeleted

        dtListaParametrosPersonalizados.Clear()

        dgvParametros.AutoGenerateColumns = False

        Dim daParametrosPersonalizados As New SqlDataAdapter("spSEGConsultaParametrosPersonalizados", cnSIGAMET)
        daParametrosPersonalizados.SelectCommand.CommandType = CommandType.StoredProcedure
        daParametrosPersonalizados.Fill(dtListaParametrosPersonalizados)

        Dim dr As DataRow
        For Each dr In dtListaParametrosPersonalizados.Rows
            dr.BeginEdit()
            dr("ModuloNombre") = dtListaModulos.Select("Modulo = " & dr("Modulo").ToString())(0)("Nombre").ToString()
            dr.EndEdit()
        Next

        AddHandler dtListaParametrosPersonalizados.RowChanged, AddressOf RowChanged
        AddHandler dtListaParametrosPersonalizados.RowDeleting, AddressOf RowDeleted

        dgvParametros.DataSource = dtListaParametrosPersonalizados.DefaultView

        dtListaParametrosPersonalizados.DefaultView.AllowEdit = True
    End Sub

    Public Sub CargarDatos()
        ConsultaModulos()
        ConsultaParametros(Convert.ToInt16(cboModulos.SelectedValue))
        ConsultaUsuarios()
        ConsultaParametrosPersonalizados()
    End Sub

    Public Sub InsertarParametros(ByVal Modulo As Short, ByVal Parametro As String, ByVal Usuario As String, ByVal Valor As String, _
                                    Optional ByVal Activo As Boolean = True)
        Dim daParametrosPersonalizados As New SqlDataAdapter()
        daParametrosPersonalizados.InsertCommand = New SqlCommand()
        daParametrosPersonalizados.InsertCommand.CommandText = "spSEGParametroUsuarioAltaModifica"
        daParametrosPersonalizados.InsertCommand.Connection = cnSIGAMET
        daParametrosPersonalizados.InsertCommand.CommandType = CommandType.StoredProcedure

        daParametrosPersonalizados.InsertCommand.Parameters.Add("@Modulo", SqlDbType.SmallInt)
        daParametrosPersonalizados.InsertCommand.Parameters("@Modulo").Value = Modulo

        daParametrosPersonalizados.InsertCommand.Parameters.Add("@Parametro", SqlDbType.VarChar)
        daParametrosPersonalizados.InsertCommand.Parameters("@Parametro").Value = Parametro

        daParametrosPersonalizados.InsertCommand.Parameters.Add("@Usuario", SqlDbType.VarChar)
        daParametrosPersonalizados.InsertCommand.Parameters("@Usuario").Value = Usuario

        daParametrosPersonalizados.InsertCommand.Parameters.Add("@Valor", SqlDbType.VarChar)
        daParametrosPersonalizados.InsertCommand.Parameters("@Valor").Value = Valor

        daParametrosPersonalizados.InsertCommand.Parameters.Add("@Activo", SqlDbType.Bit)
        daParametrosPersonalizados.InsertCommand.Parameters("@Activo").Value = Activo

        If cnSIGAMET.State = ConnectionState.Closed Then
            cnSIGAMET.Open()
        End If

        daParametrosPersonalizados.InsertCommand.ExecuteNonQuery()

        cnSIGAMET.Close()
    End Sub

    Public Sub EliminarParametros(ByVal Modulo As Short, ByVal Parametro As String, ByVal Usuario As String, ByVal Valor As String, _
                                    Optional ByVal Activo As Boolean = True)
        Dim daParametrosPersonalizados As New SqlDataAdapter()
        daParametrosPersonalizados.DeleteCommand = New SqlCommand()
        daParametrosPersonalizados.DeleteCommand.CommandText = "spSEGEliminaParametroUsuario"
        daParametrosPersonalizados.DeleteCommand.Connection = cnSIGAMET
        daParametrosPersonalizados.DeleteCommand.CommandType = CommandType.StoredProcedure

        daParametrosPersonalizados.DeleteCommand.Parameters.Add("@Modulo", SqlDbType.SmallInt)
        daParametrosPersonalizados.DeleteCommand.Parameters("@Modulo").Value = Modulo

        daParametrosPersonalizados.DeleteCommand.Parameters.Add("@Parametro", SqlDbType.VarChar)
        daParametrosPersonalizados.DeleteCommand.Parameters("@Parametro").Value = Parametro

        daParametrosPersonalizados.DeleteCommand.Parameters.Add("@Usuario", SqlDbType.VarChar)
        daParametrosPersonalizados.DeleteCommand.Parameters("@Usuario").Value = Usuario

        If cnSIGAMET.State = ConnectionState.Closed Then
            cnSIGAMET.Open()
        End If

        daParametrosPersonalizados.DeleteCommand.ExecuteNonQuery()

        cnSIGAMET.Close()
    End Sub
#End Region

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CargarDatos()

        AddHandler cboModulos.SelectedValueChanged, AddressOf cboModulos_SelectedIndexChanged
    End Sub


    Private Sub ParametrosUsuario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        OcultarCapturaParametro()
    End Sub

    Private Sub cboModulos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        ConsultaParametros(Convert.ToInt16(cboModulos.SelectedValue))

        'dtListaParametros.DefaultView.RowFilter = "Modulo = " & cboModulos.SelectedValue.ToString()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        CargarDatos()
        OcultarCapturaParametro()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        InsertarParametros(Convert.ToInt16(cboModulos.SelectedValue), cboParametros.SelectedValue.ToString(), _
                           cboUsuarios.SelectedValue.ToString(), txtValor.Text)
        ConsultaParametrosPersonalizados()
        OcultarCapturaParametro()
    End Sub

    Private Sub RowChanged(sender As Object, e As DataRowChangeEventArgs)
        InsertarParametros(Convert.ToInt16(e.Row("Modulo")), Convert.ToString(e.Row("Parametro")), Convert.ToString(e.Row("Usuario")), _
            Convert.ToString(e.Row("Valor")), Convert.ToBoolean(e.Row("Activo")))
    End Sub

    Private Sub dgvParametros_CellMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvParametros.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.dgvParametros.Rows(e.RowIndex).Selected = True
            'this.rowIndex = e.RowIndex;
            Me.dgvParametros.CurrentCell = Me.dgvParametros.Rows(e.RowIndex).Cells(1)
            Me.ContextMenuStrip1.Show(Me.dgvParametros, e.Location)
            ContextMenuStrip1.Show(Cursor.Position)
        End If
    End Sub

    Private Sub BorrarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BorrarToolStripMenuItem.Click
        If Not Me.dgvParametros.Rows(Me.rowIndex).IsNewRow Then
            Me.dgvParametros.Rows.RemoveAt(Me.rowIndex)
        End If            
    End Sub

    Private Sub RowDeleted(sender As Object, e As DataRowChangeEventArgs)
        EliminarParametros(Convert.ToInt16(e.Row("Modulo")), Convert.ToString(e.Row("Parametro")), Convert.ToString(e.Row("Usuario")), _
            Convert.ToString(e.Row("Valor")), Convert.ToBoolean(e.Row("Activo")))
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Me.Height += pnlParametro.Height
        Me.pnlParametro.Visible = True
        Me.btnAgregar.Enabled = False

        Dim XY As Point = Me.pnlParametro.Location

        XY.Y += pnlParametro.Height + 10

        Me.dgvParametros.Location = XY
    End Sub

    Private Sub OcultarCapturaParametro()
        Me.Height -= pnlParametro.Height
        Me.pnlParametro.Visible = False
        Me.btnAgregar.Enabled = True

        Dim XY As Point = Me.pnlParametro.Location
        Me.dgvParametros.Location = XY
    End Sub
End Class
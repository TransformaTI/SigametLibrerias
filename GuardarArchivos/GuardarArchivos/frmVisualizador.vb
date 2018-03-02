Public Class frmVisualizador

#Region "Propiedades y variables locales"
    Private _Embarque As Integer = 0

    Public Property Embarque() As Integer
        Get
            Return _Embarque
        End Get
        Set(ByVal value As Integer)
            _Embarque = value
        End Set
    End Property

    Private _SoloConsulta As Boolean
    Public Property SoloConsulta() As Boolean
        Get
            Return _SoloConsulta
        End Get
        Set(ByVal value As Boolean)
            _SoloConsulta = value
        End Set
    End Property

    Dim ArchivoGuardado As GuiaEmbarqueMetodos

    Private _lstGuiaEmbarques As New List(Of GuiaEmbarqueMetodos)    
    Public Property lstGuiaEmbarques() As List(Of GuiaEmbarqueMetodos)
        Get
            Return _lstGuiaEmbarques
        End Get
        Set(ByVal value As List(Of GuiaEmbarqueMetodos))
            _lstGuiaEmbarques = value
        End Set
    End Property

#End Region

#Region "Métodos propios"
    Private Sub InicioFormulario()
        Me.Text = "Archivos adjuntos al embarque"
        Me.MaximizeBox = False
        Me.MinimizeBox = False

        Me.btnAgregar.Text = "Agregar"
        Me.btnBorrar.Text = "Borrar"
        Me.btnAceptar.Text = "Aceptar"
        Me.btnCancelar.Text = "Cancelar"

        ArchivoGuardado = New GuiaEmbarqueMetodos

        Me.grdArchivos.ReadOnly = True
        Me.grdArchivos.AllowUserToAddRows = False
        Me.grdArchivos.AllowUserToDeleteRows = False
        Me.grdArchivos.MultiSelect = False
        Me.grdArchivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect

        Dim colIdGuia As New DataGridViewTextBoxColumn
        Dim colEmbarque As New DataGridViewTextBoxColumn
        Dim colNombreArchivo As New DataGridViewTextBoxColumn
        Dim colExtension As New DataGridViewTextBoxColumn
        Dim colRutaArchivo As New DataGridViewTextBoxColumn        

        colIdGuia.Name = "colIdGuia"
        colIdGuia.HeaderText = "Id guia"
        colIdGuia.Visible = False

        colEmbarque.Name = "colEmbarque"
        colEmbarque.HeaderText = "Embarque"
        colEmbarque.Width = 70

        colNombreArchivo.Name = "colNombreArchivo"
        colNombreArchivo.HeaderText = "Nombre del archivo"
        colNombreArchivo.Width = 240

        colExtension.Name = "colExtension"
        colExtension.HeaderText = "Tipo de archivo"
        colExtension.Width = 110

        colRutaArchivo.Name = "colRuta"
        colRutaArchivo.HeaderText = "Ruta archivo"
        colRutaArchivo.Visible = False

        Me.grdArchivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {colIdGuia, colEmbarque, colNombreArchivo, colExtension, colRutaArchivo})

        Me.grdArchivos.TabIndex = 0
        Me.btnAgregar.TabIndex = 1
        Me.btnBorrar.TabIndex = 2
        Me.btnAceptar.TabIndex = 3
        Me.btnCancelar.TabIndex = 4

        If _SoloConsulta Then
            btnAceptar.Text = "Cerrar"
            btnCancelar.Visible = False
            btnAgregar.Visible = False
            btnBorrar.Visible = False
        End If
    End Sub

    Private Sub BorrarRegistroGrid()
        If grdArchivos.Rows.Count > 0 Then
            If grdArchivos.SelectedRows.Count > 0 Then

                If Convert.ToInt32(grdArchivos.Item(0, grdArchivos.SelectedRows(0).Index).Value) <> 0 Then                    

                    Dim _guiaEmbarqueBorrarBD As New GuiaEmbarqueMetodos

                    For Each _guiaEmbarqueBorrarBD In _lstGuiaEmbarques
                        If _guiaEmbarqueBorrarBD.IdGuia = Convert.ToInt32(grdArchivos.Item(0, grdArchivos.SelectedRows(0).Index).Value) Then
                            _guiaEmbarqueBorrarBD.BorrarEnBD = True
                            Exit For
                        End If
                    Next
                Else
                    For Each _guiaEmbarqueBorrarBD In _lstGuiaEmbarques                        
                        If _guiaEmbarqueBorrarBD.IdGuia = Convert.ToInt32(grdArchivos.Item(0, grdArchivos.SelectedRows(0).Index).Value) Then
                            _lstGuiaEmbarques.Remove(_guiaEmbarqueBorrarBD)
                            Exit For
                        End If
                    Next
                End If

                grdArchivos.Rows.RemoveAt(grdArchivos.SelectedRows(0).Index)

            End If
        End If
    End Sub

    Private Sub AgregarRegistoGrid()
        Dim frmAgregar As New frmGuiaEmbarque

        If frmAgregar.ShowDialog() = Windows.Forms.DialogResult.OK Then

            If BuscarArchivoEnGrid(frmAgregar.GuiaEmbarque.NombreArchivo) Then
                ArchivoGuardado = frmAgregar.GuiaEmbarque
                ArchivoGuardado.Embarque = _Embarque

                Me.grdArchivos.Rows.Add(ArchivoGuardado.IdGuia, ArchivoGuardado.Embarque, ArchivoGuardado.NombreArchivo, _
                                        ArchivoGuardado.Extension, ArchivoGuardado.RutaArchivo, ArchivoGuardado.BorrarEnBD)
            Else
                MessageBox.Show("El archivo ya esta en la lista.", "Archivo ya agregado", _
                                 MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub CargarArchivo()
        If grdArchivos.Rows.Count > 0 Then
            Me.Cursor = Cursors.WaitCursor
            Dim Archivo As Byte() = Nothing

            If Convert.ToInt32(grdArchivos.Item(0, grdArchivos.SelectedRows(0).Index).Value) <> 0 Then
                For Each guia In _lstGuiaEmbarques
                    If Convert.ToInt32(grdArchivos.Item(0, grdArchivos.SelectedRows(0).Index).Value) = guia.IdGuia Then
                        Archivo = guia.Archivo
                    End If
                Next
            End If

            Try
                Dim oGuiaEmbarqueMetodos As New GuiaEmbarqueMetodos

                If grdArchivos.Item(3, grdArchivos.SelectedRows(0).Index).Value.ToString() = "pdf" Then
                    If String.IsNullOrEmpty(grdArchivos.Item(4, grdArchivos.SelectedRows(0).Index).Value.ToString()) = False Then
                        Process.Start(grdArchivos.Item(4, grdArchivos.SelectedRows(0).Index).Value.ToString())
                    Else
                        Process.Start(oGuiaEmbarqueMetodos.ConvertirAPdf(Archivo))
                    End If
                Else
                    Dim frmVisor As New frmVisorImagen

                    If String.IsNullOrEmpty(grdArchivos.Item(4, grdArchivos.SelectedRows(0).Index).Value.ToString()) = False Then
                        frmVisor.ImgVisualizar = Image.FromFile(grdArchivos.Item(4, grdArchivos.SelectedRows(0).Index).Value.ToString())
                    Else
                        frmVisor.ImgVisualizar = oGuiaEmbarqueMetodos.ConvertirAImagen(Archivo)
                    End If

                    frmVisor.ShowDialog()

                End If
            Catch ex As Exception
                MessageBox.Show("Se genero el siguiente error: " + ex.Message)
            End Try

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub LlenarLista()       
        For i As Integer = 0 To grdArchivos.Rows.Count - 1
            If Convert.ToInt32(grdArchivos.Item(0, i).Value) = 0 And BuscarArchivoEnLista(grdArchivos.Item(4, i).Value.ToString) = False Then

                Dim _guiaEmbarque As New GuiaEmbarqueMetodos

                _guiaEmbarque.IdGuia = Convert.ToInt32(grdArchivos.Item(0, i).Value)
                _guiaEmbarque.Embarque = Convert.ToInt32(grdArchivos.Item(1, i).Value)
                _guiaEmbarque.NombreArchivo = grdArchivos.Item(2, i).Value.ToString
                _guiaEmbarque.Extension = grdArchivos.Item(3, i).Value.ToString
                _guiaEmbarque.RutaArchivo = grdArchivos.Item(4, i).Value.ToString

                _lstGuiaEmbarques.Add(_guiaEmbarque)
            End If
        Next
    End Sub

    Public Sub CargarListaExistente()

        Me.grdArchivos.Rows.Clear()

        For Each GuiaEmbarquesito As GuiaEmbarqueMetodos In _lstGuiaEmbarques
            If GuiaEmbarquesito.BorrarEnBD = False Then
                Me.grdArchivos.Rows.Add(GuiaEmbarquesito.IdGuia, GuiaEmbarquesito.Embarque, GuiaEmbarquesito.NombreArchivo, GuiaEmbarquesito.Extension, GuiaEmbarquesito.RutaArchivo)
            End If
        Next
    End Sub

    Private Function BuscarArchivoEnGrid(ByVal ruta As String) As Boolean
        Dim Resultado As Boolean

        Resultado = True

        For Each Fila As DataGridViewRow In grdArchivos.Rows
            If Fila.Cells("colNombreArchivo").Value.ToString = ruta Then
                Resultado = False
            End If
        Next

        Return Resultado
    End Function

    Private Function BuscarArchivoEnLista(ByVal ruta As String) As Boolean
        Dim Resultado As Boolean

        Resultado = False

        For Each Archivo In _lstGuiaEmbarques
            If Archivo.RutaArchivo = ruta Then
                Resultado = True
                Exit For
            End If
        Next

        Return Resultado
    End Function


#End Region

    Private Sub frmVisualizador_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InicioFormulario()

        If Not _lstGuiaEmbarques Is Nothing Then
            CargarListaExistente()
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        AgregarRegistoGrid()
    End Sub

    Private Sub btnBorrar_Click(sender As System.Object, e As System.EventArgs) Handles btnBorrar.Click
        BorrarRegistroGrid()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        BorrarBDFalso()
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        LlenarLista()

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub grdArchivos_DoubleClick(sender As System.Object, e As System.EventArgs) Handles grdArchivos.DoubleClick
        CargarArchivo()
    End Sub

    Private Sub btnVisualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnVisualizar.Click
        CargarArchivo()
    End Sub

    Private Sub BorrarBDFalso()
        For Each _guiaEmbarqueBorrarBD In _lstGuiaEmbarques
            If _guiaEmbarqueBorrarBD.BorrarEnBD Then
                _guiaEmbarqueBorrarBD.BorrarEnBD = False
            End If
        Next
    End Sub
End Class
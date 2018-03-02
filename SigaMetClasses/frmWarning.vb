Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.ControlChars
Public Class frmWarning
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
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWarning))
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.DarkRed
        Me.lblHeader.Location = New System.Drawing.Point(84, 4)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(208, 20)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Label1"
        '
        'lblWarning
        '
        Me.lblWarning.ForeColor = System.Drawing.Color.Navy
        Me.lblWarning.Location = New System.Drawing.Point(84, 28)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(208, 32)
        Me.lblWarning.TabIndex = 1
        Me.lblWarning.Text = "Label1"
        '
        'lblMessage
        '
        Me.lblMessage.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblMessage.Location = New System.Drawing.Point(84, 68)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(208, 44)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.Text = "Label1"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Bitmap)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(104, 120)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "     &Aceptar"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Bitmap)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(60, 60)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'frmWarning
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(298, 155)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PictureBox1, Me.Button1, Me.lblMessage, Me.lblWarning, Me.lblHeader})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWarning"
        Me.Text = "frmWarning"
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Aviso de rutas inactivas
    Public Sub New(ByVal Ruta As Integer)

        MyBase.New()
        Me.InitializeComponent()


        Dim _celula, _ruta As Integer, _
                 _descripcion, _status As String, _
                 datosRuta As DataTable

        _ruta = Ruta
        datosRuta = ConsultaRutaInactiva(_ruta)

        If Not (datosRuta Is Nothing) Then

            _celula = datosRuta.Rows(0).Item("Celula")
            _ruta = datosRuta.Rows(0).Item("Ruta")
            _descripcion = datosRuta.Rows(0).Item("Descripcion")
            _status = datosRuta.Rows(0).Item("Status")
            Me.Text = "Ruta Inactiva"

            Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen

            If UCase(Trim(_status)) = "INACTIVA" Then

                'Mensaje de advertencia de ruta inactiva
                lblHeader.Text = "Ruta Inactiva"
                lblWarning.Text = "La ruta '" & Trim(_descripcion.ToString) & "', de la célula " & _celula.ToString & " está inactiva"
                lblMessage.Text = "Solicite el cambio de los clientes que" & CrLf & "aún pertenecen a esta ruta, a la ruta" & CrLf & "correspondiente"
                Me.ShowDialog()

            End If
        End If
    End Sub

    'Clientes con descuento en pronto pago
    Public Sub New(ByVal ClienteDescuento As Integer, ByVal TipoAviso As Boolean, Optional ByVal Litros As Double = 0)
        MyBase.New()
        Me.InitializeComponent()

        Dim _cliente As Integer, _
            _valorDescuento As Double, _
            _nombre As String, _
            datosDescuento As DataTable

        _cliente = ClienteDescuento
        datosDescuento = ConsultaDescuento(_cliente)

        If Not (datosDescuento Is Nothing) AndAlso (datosDescuento.Rows.Count > 0) Then
            _cliente = datosDescuento.Rows(0).Item("Cliente")
            _valorDescuento = datosDescuento.Rows(0).Item("ValorDescuento")
            _nombre = datosDescuento.Rows(0).Item("Nombre")
            Me.Text = "Descuento"
            Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen

            If Not TipoAviso Then

                'Mensaje de advertencia de descuento
                lblHeader.Text = "Descuento no válido"
                lblWarning.Text = "Cliente : " & Trim(_cliente.ToString) & " " & _nombre.ToString
                lblMessage.Text = "Este cliente tiene un descuento autorizado de  " & _
                                  _valorDescuento.ToString.Trim & " $/Lt, el cuál no es" & CrLf & _
                                  "válido en esta forma de pago"
            Else

                lblHeader.Text = "Descuento :" & FormatCurrency(CStr(Litros * _valorDescuento).Trim)
                lblWarning.Text = "Cliente : " & Trim(_cliente.ToString) & " " & _nombre.ToString
                lblMessage.Text = "Descuento autorizado: " & _valorDescuento.ToString.Trim & " $/Lt"

            End If

            Me.ShowDialog()
        End If
    End Sub


#Region "Consulta de datos"

    Private Function ConsultaRutaInactiva(ByVal Ruta As Integer) As DataTable
        Dim retTable As New DataTable("DatosRuta"), _
                cmdSelect As New SqlCommand(), _
                da As New SqlDataAdapter()
        cmdSelect.CommandText = "spSGCConsultaRutas"
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Connection = DataLayer.Conexion
        cmdSelect.Parameters.Add("@Ruta", SqlDbType.Int).Value = Ruta
        da.SelectCommand = cmdSelect
        Try
            da.Fill(retTable)
        Catch ex As SqlException
            retTable = Nothing
        Catch ex As Exception
            retTable = Nothing
        Finally
            If cmdSelect.Connection.State = ConnectionState.Open Then
                cmdSelect.Connection.Close()
            End If
            cmdSelect.Dispose()
            da.Dispose()
        End Try
        Return retTable
    End Function

    Private Function ConsultaDescuento(ByVal Cliente As Integer) As DataTable
        Dim retTable As New DataTable("DatosRuta"), _
                cmdSelect As New SqlCommand(), _
                da As New SqlDataAdapter()
        cmdSelect.CommandText = "spSGCConsultaDescuentos"
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Connection = DataLayer.Conexion
        cmdSelect.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        da.SelectCommand = cmdSelect
        Try
            da.Fill(retTable)
        Catch ex As SqlException
            retTable = Nothing
        Catch ex As Exception
            retTable = Nothing
        Finally
            If cmdSelect.Connection.State = ConnectionState.Open Then
                cmdSelect.Connection.Close()
            End If
            cmdSelect.Dispose()
            da.Dispose()
        End Try
        Return retTable
    End Function

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class

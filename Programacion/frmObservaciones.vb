Imports System.Data.SqlClient

Public Class frmObservaciones
    Inherits System.Windows.Forms.Form
    Private _Cliente As Integer
    Private _FProgramacion As Date
    Private _Observaciones As String
    Private cn As SqlConnection

#Region " Windows Form Designer generated code "

    Private Sub New()
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
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lblFProgramacion As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmObservaciones))
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lblFProgramacion = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtObservaciones
        '
        Me.txtObservaciones.AutoSize = False
        Me.txtObservaciones.Location = New System.Drawing.Point(8, 72)
        Me.txtObservaciones.MaxLength = 50
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(240, 48)
        Me.txtObservaciones.TabIndex = 0
        Me.txtObservaciones.Text = ""
        '
        'lblFProgramacion
        '
        Me.lblFProgramacion.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblFProgramacion.Location = New System.Drawing.Point(8, 24)
        Me.lblFProgramacion.Name = "lblFProgramacion"
        Me.lblFProgramacion.Size = New System.Drawing.Size(240, 21)
        Me.lblFProgramacion.TabIndex = 1
        Me.lblFProgramacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(264, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(264, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 14)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Fecha del pedido programado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 14)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Observaciones"
        '
        'frmObservaciones
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(346, 135)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.Label1, Me.btnCancelar, Me.btnAceptar, Me.lblFProgramacion, Me.txtObservaciones})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmObservaciones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio de observaciones"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal Cliente As Integer)
        MyBase.New()
        InitializeComponent()

        _Cliente = Cliente

        Me.Text = "Cliente: " & _Cliente.ToString

        CargaDatos()

    End Sub

    Private Sub CargaDatos()
        Dim dr As SqlDataReader
        'cn = New SqlConnection(SigaMetClasses.LeeInfoConexion(False))
        cn = SigaMetClasses.DataLayer.Conexion
        Dim cmd As New SqlCommand("spPROGSiguientePedidoConsulta")

        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Cliente", SqlDbType.Int).Value = _Cliente
            .Connection = cn
        End With

        Try
            cn.Open()
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            dr.Read()

            _FProgramacion = CType(dr("FProgramacion"), Date)
            _Observaciones = CType(dr("Observaciones"), String).Trim
            Me.lblFProgramacion.Text = _FProgramacion.ToLongDateString
            Me.txtObservaciones.Text = _Observaciones

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then cn.Close()
            End If

        End Try

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MessageBox.Show(SigaMetClasses.M_ESTAN_CORRECTOS, "Cambio de observaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            'cn = New SqlConnection(SigaMetClasses.LeeInfoConexion(False))
            cn = SigaMetClasses.DataLayer.Conexion
            Dim cmd As New SqlCommand("spPROGSiguientePedidoActualiza", cn)
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@Cliente", SqlDbType.Int).Value = _Cliente
                .Parameters.Add("@FProgramacion", SqlDbType.DateTime).Value = _FProgramacion
                .Parameters.Add("@Observaciones", SqlDbType.VarChar, 50).Value = txtObservaciones.Text.Trim
            End With

            Try
                cn.Open()
                cmd.ExecuteNonQuery()
                DialogResult = DialogResult.OK

            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If Not cn Is Nothing Then
                    If cn.State = ConnectionState.Open Then cn.Close()
                End If
                Cursor = Cursors.Default

            End Try

        End If
    End Sub
End Class

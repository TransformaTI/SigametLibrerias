Imports System.Data.SqlClient

Public Class PanelControlCyC
    Inherits System.Windows.Forms.UserControl
    Private _Empleado As Integer
    Private _MovimientosPendientes As Integer
    Private _RelacionesPendientes As Integer
    Private _TotalAbonoDia As Decimal
    Private _TotalAbonoMes As Decimal

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        lblFecha.Text = Now.Date.ToLongDateString
        Timer.Start()

    End Sub

    'UserControl1 overrides dispose to clean up the component list.
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblReloj As System.Windows.Forms.Label
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents lblMovimientosPendientes As System.Windows.Forms.Label
    Friend WithEvents lblRelacionesPendientes As System.Windows.Forms.Label
    Friend WithEvents lblTotalAbonoDia As System.Windows.Forms.Label
    Friend WithEvents lblTotalAbonoMes As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblEmpleadoNombre As System.Windows.Forms.Label
    Friend WithEvents lnkMovimientosPendientes As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkRelacionesPendientes As System.Windows.Forms.LinkLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblReloj = New System.Windows.Forms.Label()
        Me.lblMovimientosPendientes = New System.Windows.Forms.Label()
        Me.lblRelacionesPendientes = New System.Windows.Forms.Label()
        Me.lblTotalAbonoDia = New System.Windows.Forms.Label()
        Me.lblTotalAbonoMes = New System.Windows.Forms.Label()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.lnkMovimientosPendientes = New System.Windows.Forms.LinkLabel()
        Me.lnkRelacionesPendientes = New System.Windows.Forms.LinkLabel()
        Me.lblEmpleadoNombre = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bienvenido(a)"
        '
        'lblReloj
        '
        Me.lblReloj.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReloj.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReloj.Location = New System.Drawing.Point(176, 24)
        Me.lblReloj.Name = "lblReloj"
        Me.lblReloj.Size = New System.Drawing.Size(232, 13)
        Me.lblReloj.TabIndex = 1
        Me.lblReloj.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMovimientosPendientes
        '
        Me.lblMovimientosPendientes.AutoSize = True
        Me.lblMovimientosPendientes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMovimientosPendientes.Location = New System.Drawing.Point(8, 112)
        Me.lblMovimientosPendientes.Name = "lblMovimientosPendientes"
        Me.lblMovimientosPendientes.Size = New System.Drawing.Size(219, 13)
        Me.lblMovimientosPendientes.TabIndex = 2
        Me.lblMovimientosPendientes.Text = "Tienes X movimientos pendientes por validar"
        '
        'lblRelacionesPendientes
        '
        Me.lblRelacionesPendientes.AutoSize = True
        Me.lblRelacionesPendientes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRelacionesPendientes.Location = New System.Drawing.Point(8, 144)
        Me.lblRelacionesPendientes.Name = "lblRelacionesPendientes"
        Me.lblRelacionesPendientes.Size = New System.Drawing.Size(267, 13)
        Me.lblRelacionesPendientes.TabIndex = 3
        Me.lblRelacionesPendientes.Text = "Tienes X relaciones de cobranza pendientes por cerrar"
        '
        'lblTotalAbonoDia
        '
        Me.lblTotalAbonoDia.AutoSize = True
        Me.lblTotalAbonoDia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAbonoDia.Location = New System.Drawing.Point(8, 176)
        Me.lblTotalAbonoDia.Name = "lblTotalAbonoDia"
        Me.lblTotalAbonoDia.Size = New System.Drawing.Size(220, 13)
        Me.lblTotalAbonoDia.TabIndex = 4
        Me.lblTotalAbonoDia.Text = "Has abonado un total de $0.00 el día de hoy"
        '
        'lblTotalAbonoMes
        '
        Me.lblTotalAbonoMes.AutoSize = True
        Me.lblTotalAbonoMes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAbonoMes.Location = New System.Drawing.Point(8, 208)
        Me.lblTotalAbonoMes.Name = "lblTotalAbonoMes"
        Me.lblTotalAbonoMes.Size = New System.Drawing.Size(203, 13)
        Me.lblTotalAbonoMes.TabIndex = 5
        Me.lblTotalAbonoMes.Text = "En el mes has abonado un total de $0.00"
        '
        'Timer
        '
        Me.Timer.Interval = 1000
        '
        'lnkMovimientosPendientes
        '
        Me.lnkMovimientosPendientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkMovimientosPendientes.AutoSize = True
        Me.lnkMovimientosPendientes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkMovimientosPendientes.Location = New System.Drawing.Point(352, 112)
        Me.lnkMovimientosPendientes.Name = "lnkMovimientosPendientes"
        Me.lnkMovimientosPendientes.Size = New System.Drawing.Size(57, 13)
        Me.lnkMovimientosPendientes.TabIndex = 6
        Me.lnkMovimientosPendientes.TabStop = True
        Me.lnkMovimientosPendientes.Text = "Ver más..."
        '
        'lnkRelacionesPendientes
        '
        Me.lnkRelacionesPendientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkRelacionesPendientes.AutoSize = True
        Me.lnkRelacionesPendientes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnkRelacionesPendientes.Location = New System.Drawing.Point(352, 144)
        Me.lnkRelacionesPendientes.Name = "lnkRelacionesPendientes"
        Me.lnkRelacionesPendientes.Size = New System.Drawing.Size(57, 13)
        Me.lnkRelacionesPendientes.TabIndex = 7
        Me.lnkRelacionesPendientes.TabStop = True
        Me.lnkRelacionesPendientes.Text = "Ver más..."
        '
        'lblEmpleadoNombre
        '
        Me.lblEmpleadoNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEmpleadoNombre.Font = New System.Drawing.Font("Verdana", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpleadoNombre.ForeColor = System.Drawing.Color.OliveDrab
        Me.lblEmpleadoNombre.Location = New System.Drawing.Point(8, 48)
        Me.lblEmpleadoNombre.Name = "lblEmpleadoNombre"
        Me.lblEmpleadoNombre.Size = New System.Drawing.Size(400, 48)
        Me.lblEmpleadoNombre.TabIndex = 8
        Me.lblEmpleadoNombre.Text = "Usuario Sigamet"
        '
        'lblFecha
        '
        Me.lblFecha.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFecha.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(176, 8)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(232, 13)
        Me.lblFecha.TabIndex = 9
        Me.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(8, 96)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(400, 2)
        Me.Panel1.TabIndex = 10
        '
        'PanelControlCyC
        '
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.lblEmpleadoNombre)
        Me.Controls.Add(Me.lnkRelacionesPendientes)
        Me.Controls.Add(Me.lnkMovimientosPendientes)
        Me.Controls.Add(Me.lblTotalAbonoMes)
        Me.Controls.Add(Me.lblTotalAbonoDia)
        Me.Controls.Add(Me.lblRelacionesPendientes)
        Me.Controls.Add(Me.lblMovimientosPendientes)
        Me.Controls.Add(Me.lblReloj)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "PanelControlCyC"
        Me.Size = New System.Drawing.Size(416, 240)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Sub New(ByVal Empleado As Integer)
        MyBase.New()
        InitializeComponent()
        _Empleado = Empleado
        CargaMetricas(_Empleado)
        lblFecha.Text = Now.Date.ToLongDateString
        Timer.Start()
    End Sub

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        lblReloj.Text = Now.ToLongTimeString
    End Sub

    Private Sub ConsultaEmpleado(ByVal Empleado As Integer)
        Dim strQuery As String = _
        "SELECT Nombre FROM Empleado WHERE Empleado = " & Empleado
        Dim da As New SqlDataAdapter(strQuery, SigaMetClasses.LeeInfoConexion(False))
        Dim dt As New DataTable("Empleado")

        Try
            da.Fill(dt)
            If dt.Rows.Count = 1 Then
                lblEmpleadoNombre.Text = Trim(CType(dt.Rows(0).Item("Nombre"), String))
            Else
                lblEmpleadoNombre.Text = "Empleado inexistente?"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            da.Dispose()
            dt.Dispose()

        End Try
    End Sub

    Public Sub CargaMetricas(ByVal Empleado As Integer)

        _Empleado = Empleado

        ConsultaEmpleado(_Empleado)

        Dim cmd As New SqlCommand()
        Dim cn As New SqlConnection(SigaMetClasses.LeeInfoConexion(False))
        cmd.Connection = cn
        cmd.CommandType = CommandType.Text

        Try
            cn.Open()
            cmd.CommandText = "SELECT dbo.CyCTotalAbonoEmpleadoDia (" & Empleado & ",'" & Now.Date & "')"
            _TotalAbonoDia = CType(cmd.ExecuteScalar, Decimal)

            cmd.CommandText = "SELECT dbo.CyCTotalAbonoEmpleadoMes (" & Empleado & "," & Now.Date.Year & "," & Now.Date.Month & ")"
            _TotalAbonoMes = CType(cmd.ExecuteScalar, Decimal)

            cmd.CommandText = "SELECT dbo.CyCTotalMovimientosPendientes (" & Empleado & ")"
            _MovimientosPendientes = CType(cmd.ExecuteScalar, Integer)

            cmd.CommandText = "SELECT dbo.CyCTotalRelacionesPendientes (" & Empleado & ")"
            _RelacionesPendientes = CType(cmd.ExecuteScalar, Integer)

            If _MovimientosPendientes = 0 Then
                lnkMovimientosPendientes.Visible = False
            End If
            If _RelacionesPendientes = 0 Then
                lnkRelacionesPendientes.Visible = False
            End If

            lblMovimientosPendientes.Text = _
            "Tienes " & _MovimientosPendientes.ToString & " movimientos pendientes por validar"

            lblRelacionesPendientes.Text = _
            "Tienes " & _RelacionesPendientes.ToString & " relaciones de cobranza pendientes por cerrar"

            lblTotalAbonoDia.Text = _
            "El día de hoy has abonado un total de " & _TotalAbonoDia.ToString("C")

            lblTotalAbonoMes.Text = _
            "En lo que va del mes has abonado un total de " & _TotalAbonoMes.ToString("C")

        Catch ex As Exception
            If Not cn Is Nothing Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Dispose()
            End If
            cmd.Dispose()

        End Try

    End Sub

    Private Sub PanelControlCyC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
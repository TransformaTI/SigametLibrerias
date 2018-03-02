Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class ConsultaProgramaOperador
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
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents dtpFechaCargo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaCobranza As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ConsultaProgramaOperador))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.dtpFechaCargo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaCobranza = New System.Windows.Forms.DateTimePicker()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(152, 64)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(84, 23)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "   &Aceptar"
        '
        'dtpFechaCargo
        '
        Me.dtpFechaCargo.Location = New System.Drawing.Point(128, 8)
        Me.dtpFechaCargo.Name = "dtpFechaCargo"
        Me.dtpFechaCargo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label1.Location = New System.Drawing.Point(8, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha de cargo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha de cobranza:"
        '
        'dtpFechaCobranza
        '
        Me.dtpFechaCobranza.Location = New System.Drawing.Point(128, 32)
        Me.dtpFechaCobranza.Name = "dtpFechaCobranza"
        Me.dtpFechaCobranza.TabIndex = 4
        '
        'btnCancelar
        '
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.DarkRed
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(244, 64)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(84, 23)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "   &Cancelar"
        '
        'ConsultaProgramaOperador
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(336, 93)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.dtpFechaCobranza, Me.Label2, Me.Label1, Me.dtpFechaCargo, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConsultaProgramaOperador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generación de cobranza para operador"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _cobranzaOperador As CobranzaOperador

    Public Sub New(ByVal Connection As SqlClient.SqlConnection, ByVal Usuario As String)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        _cobranzaOperador = New CobranzaOperador(Connection, Usuario)
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Not MessageBox.Show("Se generarán las listas de cobranza de operador" & vbCrLf & _
            "con fecha: " & dtpFechaCobranza.Value.Date.ToShortDateString & vbCrLf & _
            "(Documentos con fecha de cargo del " & dtpFechaCargo.Value.Date.ToShortDateString & ")" & vbCrLf & _
            "¿Desea continuar?", _
            Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Exit Sub
        End If

        Dim successful As Boolean = False
        Try
            Me.Cursor = Cursors.WaitCursor
            successful = _cobranzaOperador.ProcesaDatos(dtpFechaCargo.Value, dtpFechaCobranza.Value)
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido un error:" & vbCrLf & _
                            ex.ToString, _
                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

        If successful Then
            Dim strCob As String = Nothing
            Dim o As Object
            Dim i As Integer = 0
            For Each o In _cobranzaOperador.Cobranzas
                i += 1
                strCob &= ", " & CType(o, String)
                If i = 5 Then
                    strCob &= vbCrLf
                    i = 0
                End If
            Next
            MessageBox.Show("Se generaron automáticamente las siguientes cobranzas de operador:" & vbCrLf & _
                strCob, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class


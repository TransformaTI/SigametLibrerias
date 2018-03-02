Option Strict On

Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.ControlChars
Imports System.Math

Public Class frmCambioFactorConversion
    Inherits System.Windows.Forms.Form

    Private _Cliente As Integer
    Private _Usuario As String
    Private _Connection As SqlConnection
    Private _Factor As Double

    Private confSettings As SigaMetClasses.cConfig

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Cliente As Integer, ByVal Usuario As String, ByVal Connection As SqlConnection, _
    ByVal Corporativo As Short, ByVal Sucursal As Short)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        _Cliente = Cliente
        _Connection = Connection
        _Usuario = Usuario

        'Carga de parámetros múltiples JAGD 04/04/2008
        confSettings = New SigaMetClasses.cConfig(1, Corporativo, Sucursal)
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
    Friend WithEvents txtFactor As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCambioFactorConversion))
        Me.txtFactor = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtFactor
        '
        Me.txtFactor.Location = New System.Drawing.Point(136, 16)
        Me.txtFactor.Name = "txtFactor"
        Me.txtFactor.Size = New System.Drawing.Size(75, 21)
        Me.txtFactor.TabIndex = 0
        Me.txtFactor.Text = ""
        Me.txtFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Bitmap)
        Me.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAceptar.Location = New System.Drawing.Point(16, 48)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.TabIndex = 1
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BtnCancelar
        '
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Bitmap)
        Me.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancelar.Location = New System.Drawing.Point(136, 48)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Text = "&Cancelar"
        Me.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Factor de conversión:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmCambioFactorConversion
        '
        Me.AcceptButton = Me.BtnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.BtnCancelar
        Me.ClientSize = New System.Drawing.Size(224, 85)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.BtnCancelar, Me.BtnAceptar, Me.txtFactor})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCambioFactorConversion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Factor M³ -> Lt"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Function ConsultaFactorConversion(ByVal cliente As Integer, ByVal connection As SqlConnection) As Double
        Dim factor As Double
        Dim cmdSelect As New SqlCommand()
        cmdSelect.CommandText = "SELECT dbo.CCAEFactorDeConversionPorCliente(" & CStr(_Cliente) & ")"
        cmdSelect.CommandType = CommandType.Text
        cmdSelect.Connection = connection
        Try
            connection.Open()
            factor = CType(cmdSelect.ExecuteScalar, Decimal)
        Catch ex As SqlException
            MessageBox.Show("Ha ocurrido el siguiente error:" & CrLf & ex.Number & ex.Message, _
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            factor = 0
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error:" & CrLf & ex.Message, _
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            factor = 0
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
            cmdSelect.Dispose()
        End Try
        Return factor
    End Function

    Private Sub EstablecerFactorDeConversion(ByVal Cliente As Integer, ByVal Factor As Double, _
            ByVal Usuario As String, ByVal Connection As SqlConnection)
        Dim cmdSelect As New SqlCommand()
        cmdSelect.CommandText = "spCCAEGuardarFactorDeConversionPorCliente"
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        cmdSelect.Parameters.Add("@Factor", SqlDbType.Decimal).Value = Factor
        cmdSelect.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
        cmdSelect.Connection = Connection
        Try
            Connection.Open()
            cmdSelect.ExecuteNonQuery()
            MessageBox.Show("Factor de conversión modificado con exito", "Cambio de factor de conversión", _
                                                 MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As SqlException
            MessageBox.Show("Ha ocurrido el siguiente error:" & CrLf & ex.Number & ex.Message, _
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error:" & CrLf & ex.Message, _
                                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If
            cmdSelect.Dispose()
        End Try
    End Sub

    Private Sub frmCambioFactorConversion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _Factor = CDbl(ConsultaFactorConversion(_Cliente, _Connection))
        txtFactor.Text = CStr(_Factor)
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If Not (validaFactorConversion(CDbl(txtFactor.Text))) Then
            Exit Sub
        End If
        If _Factor <> CDbl(txtFactor.Text) Then
            If MessageBox.Show("Está a punto de establecer el nuevo valor de conversión" & CrLf & _
                "¿Desea continuar?", "Factor de conversión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                EstablecerFactorDeConversion(_Cliente, CDbl(txtFactor.Text), _Usuario, _Connection)
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Function validaFactorConversion(ByVal NuevoFactor As Double) As Boolean
        Dim retValue As Boolean
        Dim tolerancia As Double = CType(confSettings.Parametros("ToleranciaFactorConvEdifi"), Double)
        Dim factorGeneral As Double = CType(confSettings.Parametros("FactorConversion"), Double)
        retValue = (Abs(factorGeneral - NuevoFactor) <= tolerancia)
        If Not (retValue) Then
            MessageBox.Show("El factor de conversión no debe diferir" & CrLf & "en más de " & tolerancia.ToString & _
                                                " del valor por defecto (" & factorGeneral.ToString & ")", "Factor de conversión", MessageBoxButtons.OK, MessageBoxIcon.Question)
        End If
        Return retValue
    End Function
End Class

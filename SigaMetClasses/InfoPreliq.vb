Option Strict On

Imports System.Data.SqlClient, System.Windows.Forms

#Region "Estructura"
Friend Structure sRutaInfoPreliq
    Private _Ruta As Short
    Private _Descripcion As String
    Private _Autotanque As Short
    Private _FTerminoRuta As Object
    Private _LitrosVendidos As Decimal
    Private _PedidosSurtidos As Short
    Private _PedidosCancelados As Short
    Private _PedidosContado As Short
    Private _PedidosCredito As Short
    Private _ImporteContado As Decimal
    Private _ImporteCredito As Decimal
    Private _EstatusRuta As String

    Public Property Ruta() As Short
        Get
            Return _Ruta
        End Get
        Set(ByVal Value As Short)
            _Ruta = Value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal Value As String)
            _Descripcion = Value
        End Set
    End Property

    Public Property Autotanque() As Short
        Get
            Return _Autotanque
        End Get
        Set(ByVal Value As Short)
            _Autotanque = Value
        End Set
    End Property

    Public Property FTerminoRuta() As Object
        Get
            Return _FTerminoRuta
        End Get
        Set(ByVal Value As Object)
            _FTerminoRuta = Value
        End Set
    End Property

    Public Property LitrosVendidos() As Decimal
        Get
            Return _LitrosVendidos
        End Get
        Set(ByVal Value As Decimal)
            _LitrosVendidos = Value
        End Set
    End Property

    Public Property PedidosSurtidos() As Short
        Get
            Return _PedidosSurtidos
        End Get
        Set(ByVal Value As Short)
            _PedidosSurtidos = Value
        End Set
    End Property

    Public Property PedidosCancelados() As Short
        Get
            Return _PedidosCancelados
        End Get
        Set(ByVal Value As Short)
            _PedidosCancelados = Value
        End Set
    End Property

    Public Property PedidosContado() As Short
        Get
            Return _PedidosContado
        End Get
        Set(ByVal Value As Short)
            _PedidosContado = Value
        End Set
    End Property

    Public Property PedidosCredito() As Short
        Get
            Return _PedidosCredito
        End Get
        Set(ByVal Value As Short)
            _PedidosCredito = Value
        End Set
    End Property

    Public Property ImporteContado() As Decimal
        Get
            Return _ImporteContado
        End Get
        Set(ByVal Value As Decimal)
            _ImporteContado = Value
        End Set
    End Property

    Public Property ImporteCredito() As Decimal
        Get
            Return _ImporteCredito
        End Get
        Set(ByVal Value As Decimal)
            _ImporteCredito = Value
        End Set
    End Property

    Public Property EstatusRuta() As String
        Get
            Return _EstatusRuta
        End Get
        Set(ByVal Value As String)
            _EstatusRuta = Value
        End Set
    End Property

End Structure
#End Region

Public Class InfoPreliq
    Inherits System.Windows.Forms.UserControl
    Event RutaSeleccionada()

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents lstInfo As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lstInfo = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'lstInfo
        '
        Me.lstInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstInfo.Name = "lstInfo"
        Me.lstInfo.Size = New System.Drawing.Size(120, 95)
        Me.lstInfo.TabIndex = 0
        '
        'InfoPreliq
        '
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstInfo})
        Me.Name = "InfoPreliq"
        Me.Size = New System.Drawing.Size(120, 96)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _Ruta As Short
    Private _Autotanque As Short
    Private _FTerminoRuta As Object
    Private _LitrosVendidos As Decimal
    Private _ImporteContado As Decimal
    Private _ImporteCredito As Decimal

#Region "Propiedades"
    Public ReadOnly Property Ruta() As Short
        Get
            Return _Ruta
        End Get
    End Property

    Public ReadOnly Property Autotanque() As Short
        Get
            Return _Autotanque
        End Get
    End Property

    Public ReadOnly Property FTerminoRuta() As Object
        Get
            Return _FTerminoRuta
        End Get
    End Property

    Public ReadOnly Property LitrosVendidos() As Decimal
        Get
            Return _LitrosVendidos
        End Get
    End Property

    Public ReadOnly Property ImporteContado() As Decimal
        Get
            Return _ImporteContado
        End Get
    End Property

    Public ReadOnly Property ImporteCredito() As Decimal
        Get
            Return _ImporteCredito
        End Get
    End Property

#End Region

#Region "Funciones"

    Public Sub ConsultaPreLiq(ByVal Celula As Short, _
                              ByVal FechaDesde As Date, _
                              ByVal FechaHasta As Date)

        'Me.ParentForm.Cursor = Cursors.WaitCursor
        Me.Cursor = Cursors.WaitCursor
        Dim oRuta As New SigaMetClasses.cRuta()
        Dim dr As SqlDataReader = oRuta.ConsultaAsignacionRutas(Celula, FechaDesde, FechaHasta)

        Try
            lstInfo.Items.Clear()
            lstInfo.DisplayMember = "Descripcion"

            Dim s As sRutaInfoPreliq = Nothing
            Do While dr.Read
                s.Ruta = CType(dr("Ruta"), Short)
                s.Autotanque = CType(dr("Autotanque"), Short)
                If Trim(CType(dr("StatusLogistica"), String)) = "LIQCAJA" Then
                    s.Descripcion = CType(dr("Descripcion"), String)
                    s.FTerminoRuta = CType(dr("FTerminoRuta"), DateTime)
                Else
                    s.Descripcion = CType(dr("Descripcion"), String) & " *"
                    s.FTerminoRuta = "---"
                End If
                s.LitrosVendidos = CType(dr("LitrosVendidos"), Decimal)
                s.ImporteContado = CType(dr("ImporteContado"), Decimal)
                s.ImporteCredito = CType(dr("ImporteCredito"), Decimal)
                lstInfo.Items.Add(s)
                s = Nothing
            Loop

            dr.Close()
            dr = Nothing

            If lstInfo.Items.Count <= 0 Then
                'MessageBox.Show("No existen registros.", "Pre-liquidación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            dr.Close()
            dr = Nothing
            Throw ex
        Finally
            'Me.ParentForm.Cursor = Cursors.Default
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub InfoPreliq_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        lstInfo.Size = Me.Size
    End Sub
#End Region

    Private Sub lstInfo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstInfo.SelectedIndexChanged
        _Ruta = CType(lstInfo.Items(lstInfo.SelectedIndex), sRutaInfoPreliq).Ruta
        _Autotanque = CType(lstInfo.Items(lstInfo.SelectedIndex), sRutaInfoPreliq).Autotanque
        _FTerminoRuta = CType(lstInfo.Items(lstInfo.SelectedIndex), sRutaInfoPreliq).FTerminoRuta
        _LitrosVendidos = CType(lstInfo.Items(lstInfo.SelectedIndex), sRutaInfoPreliq).LitrosVendidos
        _ImporteContado = CType(lstInfo.Items(lstInfo.SelectedIndex), sRutaInfoPreliq).ImporteContado
        _ImporteCredito = CType(lstInfo.Items(lstInfo.SelectedIndex), sRutaInfoPreliq).ImporteCredito
        RaiseEvent RutaSeleccionada()
    End Sub

End Class
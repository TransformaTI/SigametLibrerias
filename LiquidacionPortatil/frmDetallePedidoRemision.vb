'Diseño: Carlos Nirari Santiago Mendoza
'Fecha: 10/07/2015
'Descripción: Vista que permite ver detalle de un pedido portatil que esta ligado a una ruta y camion.

Imports System.Windows.Forms
Imports System.Drawing

Public Class frmDetallePedidoRemision
    Inherits System.Windows.Forms.Form

    Private _Ruta As Integer
    Private _MovimientoAlmacen As Integer
    Private _Autotanque As Integer
    Private _AlmacenGas As Integer
    Private _FCarga As DateTime
    Private _FSuministroMg As DateTime

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Ruta As Integer, _
                   ByVal MovimientoAlmacen As Integer, _
                   ByVal Autotanque As Integer, _
                   ByVal AlmacenGas As Integer,
                   ByVal Fcarga As DateTime,
                   ByVal FSuministroMg As DateTime)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        _Ruta = Ruta
        _MovimientoAlmacen = MovimientoAlmacen
        _Autotanque = Autotanque
        _AlmacenGas = AlmacenGas
        _FCarga = Fcarga
        _FSuministroMg = FSuministroMg

        'Add any initialization after the InitializeComponent() call
        CargarDatos()
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
    Friend WithEvents grdDetalle As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn



    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetallePedidoRemision))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.grdDetalle = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(725, 12)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdDetalle
        '
        Me.grdDetalle.AccessibleName = ""
        Me.grdDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdDetalle.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdDetalle.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdDetalle.CaptionText = "Detalle de remision por pedido portatil"
        Me.grdDetalle.DataMember = ""
        Me.grdDetalle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDetalle.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDetalle.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdDetalle.Location = New System.Drawing.Point(12, 12)
        Me.grdDetalle.Name = "grdDetalle"
        Me.grdDetalle.ReadOnly = True
        Me.grdDetalle.Size = New System.Drawing.Size(696, 259)
        Me.grdDetalle.TabIndex = 44
        Me.grdDetalle.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.grdDetalle.TabStop = False
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.grdDetalle
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Ruta"
        Me.DataGridTextBoxColumn1.MappingName = "RutaDesc"
        Me.DataGridTextBoxColumn1.NullText = ""
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 85
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Serie"
        Me.DataGridTextBoxColumn2.MappingName = "SerieRemision"
        Me.DataGridTextBoxColumn2.NullText = ""
        Me.DataGridTextBoxColumn2.ReadOnly = True
        Me.DataGridTextBoxColumn2.Width = 85
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Remisión"
        Me.DataGridTextBoxColumn3.MappingName = "Remision"
        Me.DataGridTextBoxColumn3.NullText = ""
        Me.DataGridTextBoxColumn3.ReadOnly = True
        Me.DataGridTextBoxColumn3.Width = 65
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Fecha simunistro"
        Me.DataGridTextBoxColumn4.MappingName = "FCarga"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.ReadOnly = True
        Me.DataGridTextBoxColumn4.Width = 140
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Producto"
        Me.DataGridTextBoxColumn5.MappingName = "ProductoDesc"
        Me.DataGridTextBoxColumn5.NullText = ""
        Me.DataGridTextBoxColumn5.ReadOnly = True
        Me.DataGridTextBoxColumn5.Width = 220
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = "N2"
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Cantidad"
        Me.DataGridTextBoxColumn6.MappingName = "Cantidad"
        Me.DataGridTextBoxColumn6.NullText = ""
        Me.DataGridTextBoxColumn6.ReadOnly = True
        Me.DataGridTextBoxColumn6.Width = 65
        '
        'frmDetallePedidoRemision
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(812, 283)
        Me.Controls.Add(Me.grdDetalle)
        Me.Controls.Add(Me.btnAceptar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDetallePedidoRemision"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle pedido portátil"
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CargarDatos()
        Dim oLiquidacion As New PortatilClasses.cLiquidacion()
        oLiquidacion.ConsultaPedidoPortatil(0, _Ruta, _MovimientoAlmacen, _Autotanque, _AlmacenGas, _FCarga, _FSuministroMg)
        grdDetalle.DataSource = oLiquidacion.dtTable
    End Sub

End Class

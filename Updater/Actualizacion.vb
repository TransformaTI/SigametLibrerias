Imports System.IO
Public Class frmActualizacion
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(Optional ByVal LeeConfig As Boolean = True)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.LeeConfig = LeeConfig
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
    Friend WithEvents imgTask As System.Windows.Forms.ImageList
    Friend WithEvents pnlTareas As System.Windows.Forms.Panel
    Friend WithEvents lblTareas As System.Windows.Forms.Label
    Friend WithEvents lblAccesos As System.Windows.Forms.Label
    Friend WithEvents lblCopiaArchivos As System.Windows.Forms.Label
    Friend WithEvents btnAccesos As System.Windows.Forms.Button
    Friend WithEvents btnCopiaArchivos As System.Windows.Forms.Button
    Friend WithEvents lblDetalles As System.Windows.Forms.Label
    Friend WithEvents pnlProgreso As System.Windows.Forms.Panel
    Friend WithEvents lblProgreso As System.Windows.Forms.Label
    Friend WithEvents pbActualizacion As System.Windows.Forms.ProgressBar
    Friend WithEvents lstDetalles As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmActualizacion))
        Me.imgTask = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlTareas = New System.Windows.Forms.Panel()
        Me.lstDetalles = New System.Windows.Forms.ListBox()
        Me.lblDetalles = New System.Windows.Forms.Label()
        Me.lblTareas = New System.Windows.Forms.Label()
        Me.lblAccesos = New System.Windows.Forms.Label()
        Me.lblCopiaArchivos = New System.Windows.Forms.Label()
        Me.btnAccesos = New System.Windows.Forms.Button()
        Me.btnCopiaArchivos = New System.Windows.Forms.Button()
        Me.pnlProgreso = New System.Windows.Forms.Panel()
        Me.lblProgreso = New System.Windows.Forms.Label()
        Me.pbActualizacion = New System.Windows.Forms.ProgressBar()
        Me.pnlTareas.SuspendLayout()
        Me.pnlProgreso.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgTask
        '
        Me.imgTask.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgTask.ImageSize = New System.Drawing.Size(24, 24)
        Me.imgTask.ImageStream = CType(resources.GetObject("imgTask.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgTask.TransparentColor = System.Drawing.Color.Empty
        '
        'pnlTareas
        '
        Me.pnlTareas.BackColor = System.Drawing.Color.Silver
        Me.pnlTareas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTareas.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstDetalles, Me.lblDetalles})
        Me.pnlTareas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlTareas.Location = New System.Drawing.Point(0, 119)
        Me.pnlTareas.Name = "pnlTareas"
        Me.pnlTareas.Size = New System.Drawing.Size(386, 176)
        Me.pnlTareas.TabIndex = 0
        '
        'lstDetalles
        '
        Me.lstDetalles.BackColor = System.Drawing.Color.LightGray
        Me.lstDetalles.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstDetalles.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lstDetalles.Location = New System.Drawing.Point(0, 31)
        Me.lstDetalles.Name = "lstDetalles"
        Me.lstDetalles.Size = New System.Drawing.Size(384, 143)
        Me.lstDetalles.TabIndex = 16
        '
        'lblDetalles
        '
        Me.lblDetalles.AutoSize = True
        Me.lblDetalles.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblDetalles.Location = New System.Drawing.Point(7, 7)
        Me.lblDetalles.Name = "lblDetalles"
        Me.lblDetalles.Size = New System.Drawing.Size(48, 14)
        Me.lblDetalles.TabIndex = 15
        Me.lblDetalles.Text = "Detalles:"
        '
        'lblTareas
        '
        Me.lblTareas.AutoSize = True
        Me.lblTareas.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTareas.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTareas.Location = New System.Drawing.Point(8, 16)
        Me.lblTareas.Name = "lblTareas"
        Me.lblTareas.Size = New System.Drawing.Size(204, 16)
        Me.lblTareas.TabIndex = 14
        Me.lblTareas.Text = "Espere mientras el programa:"
        '
        'lblAccesos
        '
        Me.lblAccesos.AutoSize = True
        Me.lblAccesos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccesos.Location = New System.Drawing.Point(127, 82)
        Me.lblAccesos.Name = "lblAccesos"
        Me.lblAccesos.Size = New System.Drawing.Size(164, 14)
        Me.lblAccesos.TabIndex = 13
        Me.lblAccesos.Text = "Crea los accesos en el escritorio"
        '
        'lblCopiaArchivos
        '
        Me.lblCopiaArchivos.AutoSize = True
        Me.lblCopiaArchivos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopiaArchivos.Location = New System.Drawing.Point(127, 47)
        Me.lblCopiaArchivos.Name = "lblCopiaArchivos"
        Me.lblCopiaArchivos.Size = New System.Drawing.Size(133, 14)
        Me.lblCopiaArchivos.TabIndex = 12
        Me.lblCopiaArchivos.Text = "Copia los nuevos archivos"
        '
        'btnAccesos
        '
        Me.btnAccesos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAccesos.Image = CType(resources.GetObject("btnAccesos.Image"), System.Drawing.Bitmap)
        Me.btnAccesos.ImageIndex = 3
        Me.btnAccesos.ImageList = Me.imgTask
        Me.btnAccesos.Location = New System.Drawing.Point(95, 77)
        Me.btnAccesos.Name = "btnAccesos"
        Me.btnAccesos.Size = New System.Drawing.Size(24, 24)
        Me.btnAccesos.TabIndex = 11
        '
        'btnCopiaArchivos
        '
        Me.btnCopiaArchivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCopiaArchivos.Image = CType(resources.GetObject("btnCopiaArchivos.Image"), System.Drawing.Bitmap)
        Me.btnCopiaArchivos.ImageIndex = 0
        Me.btnCopiaArchivos.ImageList = Me.imgTask
        Me.btnCopiaArchivos.Location = New System.Drawing.Point(95, 42)
        Me.btnCopiaArchivos.Name = "btnCopiaArchivos"
        Me.btnCopiaArchivos.Size = New System.Drawing.Size(24, 24)
        Me.btnCopiaArchivos.TabIndex = 10
        '
        'pnlProgreso
        '
        Me.pnlProgreso.BackColor = System.Drawing.Color.Gainsboro
        Me.pnlProgreso.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblProgreso, Me.pbActualizacion})
        Me.pnlProgreso.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlProgreso.Location = New System.Drawing.Point(0, 295)
        Me.pnlProgreso.Name = "pnlProgreso"
        Me.pnlProgreso.Size = New System.Drawing.Size(386, 48)
        Me.pnlProgreso.TabIndex = 16
        '
        'lblProgreso
        '
        Me.lblProgreso.AutoSize = True
        Me.lblProgreso.Location = New System.Drawing.Point(17, 17)
        Me.lblProgreso.Name = "lblProgreso"
        Me.lblProgreso.Size = New System.Drawing.Size(52, 14)
        Me.lblProgreso.TabIndex = 0
        Me.lblProgreso.Text = "Progreso:"
        '
        'pbActualizacion
        '
        Me.pbActualizacion.Location = New System.Drawing.Point(89, 13)
        Me.pbActualizacion.Name = "pbActualizacion"
        Me.pbActualizacion.Size = New System.Drawing.Size(280, 23)
        Me.pbActualizacion.TabIndex = 17
        '
        'frmActualizacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(386, 343)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTareas, Me.lblAccesos, Me.lblCopiaArchivos, Me.btnAccesos, Me.btnCopiaArchivos, Me.pnlTareas, Me.pnlProgreso})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmActualizacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tareas"
        Me.TopMost = True
        Me.pnlTareas.ResumeLayout(False)
        Me.pnlProgreso.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private ForzarExe, ForzarDll, Subdirectorios, LeeConfig As Boolean
    Private Settings As AppSettings
    Private TipoActualizacion As String = "Nuevos"
    Private Ejecutable, EjecutableAnterior As String



    Private Sub frmTareas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        CargaConfiguracion()
        Actualiza()
        End
    End Sub

    Private Sub CargaConfiguracion()
        Try
            If Not Directory.Exists(RutaOrigen) Then
                MessageBox.Show("La ruta de actualización es incorrecta." & Chr(13) & "Reportelo al administrador del sistema.", Application.ProductName & " versión " & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Me.Dispose()
                End
            End If
            If Not Directory.Exists(RutaDestino) Then
                MessageBox.Show("La ruta destino es incorrecta." & Chr(13) & "Reportelo al administrador del sistema.", Application.ProductName & " versión " & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Me.Dispose()
                End
            End If
            If LeeConfig AndAlso File.Exists(RutaOrigen & "Update.config") Then
                Settings = New AppSettings(RutaOrigen & "Update.config")
                With Settings
                    TipoActualizacion = .GetSetting("Configuracion", "TipoActualizacion")
                    Ejecutable = .GetSetting("Configuracion", "Ejecutable")
                    EjecutableAnterior = .GetSetting("Configuracion", "EjecutableAnterior")
                    ForzarExe = CBool(.GetSetting("Configuracion", "ForzarEjecutables"))
                    ForzarDll = CBool(.GetSetting("Configuracion", "ForzarBibliotecas"))
                    Subdirectorios = CBool(.GetSetting("Configuracion", "IncluirSubdirectorios"))
                End With
            End If

        Catch ex As Exception
            ErrMessage(ex)
        End Try
    End Sub

    Private Sub Actualiza()
        'System.Threading.Thread.CurrentThread.Sleep(1000)
        Threading.Thread.Sleep(1000)
        lblCopiaArchivos.ForeColor = Color.Blue
        btnCopiaArchivos.ImageIndex += 1
        btnCopiaArchivos.Focus()
        Application.DoEvents()
        Me.Refresh()
        Select Case TipoActualizacion
            Case "Nuevos"
                CopiaArchivosNuevos()
            Case "Reemplazo"
                BorrarTodo()
                CopiaArchivosNuevos()
            Case Else
                CopiaPersonalizada()
        End Select
        'System.Threading.Thread.CurrentThread.Sleep(1000)
        Threading.Thread.Sleep(1000)
        If Not EjecutableAnterior Is Nothing Then
            BorraAccesos(EjecutableAnterior)
        End If
        BorraAccesos(Ejecutable)
        CreaAcceso(Ejecutable)
        'System.Threading.Thread.CurrentThread.Sleep(1000)
        'System.Threading.Thread.CurrentThread.Sleep(1000)
        Threading.Thread.Sleep(1000)
        Threading.Thread.Sleep(1000)
        MessageBox.Show("La actualización ha finalizado exitosamente." & Chr(13) & Chr(13) & "Se intentará acceder nuevamente al módulo.", Application.ProductName & " versión " & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Shell(RutaDestino & Ejecutable, AppWinStyle.NormalFocus, False)
        Me.Close()
        Me.Dispose()
    End Sub


    Private Sub CopiaArchivosNuevos()
        Dim Archivos As New ArrayList()
        Dim Archivo, ArchivoDestino, Directorios, Directorio As String
        Directorios = Nothing
        Dim Version As System.Diagnostics.FileVersionInfo = Nothing
        Dim size As Integer = Nothing
        For Each Archivo In Directory.GetFiles(RutaOrigen)
            Archivos.Add(Archivo)
        Next
        If Subdirectorios Then
            For Each Directorio In Directory.GetDirectories(RutaOrigen)
                If Not Directory.Exists(RutaDestino & Directorio.Substring(RutaOrigen.Length)) Then
                    Directory.CreateDirectory(RutaDestino & Directorio.Substring(RutaOrigen.Length))
                End If
                For Each Archivo In Directory.GetFiles(Directorio)
                    Archivos.Add(Archivo)
                Next
            Next
        End If
        pbActualizacion.Maximum = Archivos.Count + 2
        Try
            For Each Archivo In Archivos
                ArchivoDestino = RutaDestino & Archivo.Substring(RutaOrigen.Length)
                If ((Not Archivo.EndsWith(".ini") AndAlso Not Archivo.EndsWith(".inf")) OrElse TipoActualizacion = "Reemplazo" OrElse Not File.Exists(ArchivoDestino)) AndAlso Not Archivo.EndsWith("Update.config") Then
                    lstDetalles.Items.Add("Verificando archivo: " & Archivo.Substring(RutaOrigen.Length))
                    lstDetalles.Refresh()
                    If File.Exists(ArchivoDestino) Then
                        lstDetalles.Items.Add("Comparando versiones del archivo a copiar")
                        lstDetalles.SelectedIndex = lstDetalles.Items.Count - 1
                        lstDetalles.Refresh()
                        'If (Version.GetVersionInfo(Archivo).FileVersion <> Version.GetVersionInfo(ArchivoDestino).FileVersion) OrElse _
                        If (FileVersionInfo.GetVersionInfo(Archivo).FileVersion <> FileVersionInfo.GetVersionInfo(ArchivoDestino).FileVersion) OrElse _
                                    (File.GetLastWriteTime(Archivo) <> File.GetLastWriteTime(ArchivoDestino)) OrElse (Archivo.EndsWith(".exe") AndAlso ForzarExe) OrElse _
                                    (Archivo.EndsWith(".dll") AndAlso ForzarDll) Then
                            lstDetalles.Items.Add("Copiando el archivo " & Archivo.Substring(RutaOrigen.Length))
                            lstDetalles.SelectedIndex = lstDetalles.Items.Count - 1
                            lstDetalles.Refresh()
                            File.Copy(Archivo, RutaDestino & Archivo.Substring(RutaOrigen.Length), True)
                            lstDetalles.Items.Add("Se ha copiado el archivo " & Archivo.Substring(RutaOrigen.Length))
                            lstDetalles.SelectedIndex = lstDetalles.Items.Count - 1
                            lstDetalles.Refresh()
                        End If
                    Else
                        lstDetalles.Items.Add("Copiando el archivo " & Archivo.Substring(RutaOrigen.Length))
                        lstDetalles.SelectedIndex = lstDetalles.Items.Count - 1
                        lstDetalles.Refresh()
                        File.Copy(Archivo, RutaDestino & Archivo.Substring(RutaOrigen.Length), True)
                        lstDetalles.Items.Add("Se ha copiado el archivo " & Archivo.Substring(RutaOrigen.Length))
                        lstDetalles.SelectedIndex = lstDetalles.Items.Count - 1
                        lstDetalles.Refresh()
                    End If
                    'System.Threading.Thread.CurrentThread.Sleep(200)
                    Threading.Thread.Sleep(200)
                    pbActualizacion.Increment(1)
                End If
                If ArchivoDestino.EndsWith(".exe") AndAlso Ejecutable Is Nothing Then
                    Ejecutable = Archivo.Substring(RutaOrigen.Length)
                End If
            Next
        Catch ex As Exception
            ErrMessage(ex)
            Me.Close()
            Me.Dispose()
            End
        End Try
        btnCopiaArchivos.ImageIndex += 1
        lblCopiaArchivos.ForeColor = Color.Gray
        Me.Refresh()
    End Sub
    Private Sub BorrarTodo()
        Dim Archivo, ArchivoDestino, Directorios, Directorio As String
        ArchivoDestino = Nothing
        Directorios = Nothing
        Dim Version As System.Diagnostics.FileVersionInfo = Nothing

        For Each Archivo In Directory.GetFiles(RutaDestino)
            File.Delete(Archivo)
        Next
        If Subdirectorios Then
            For Each Directorio In Directory.GetDirectories(RutaDestino)
                For Each Archivo In Directory.GetFiles(Directorio)
                    File.Delete(Archivo)
                Next
                Directory.Delete(Directorio)
            Next
        End If
    End Sub
    Private Sub CopiaPersonalizada()
        Dim Archivo, ArchivoDestino As String
        Dim Archivos As New ArrayList()
        Dim i As Integer
        For i = 1 To CInt(Settings.GetSetting("ActualizacionPersonalizada", "ArchivosACopiar"))
            Archivos.Add(RutaOrigen & Settings.GetSetting("ActualizacionPersonalizada", "Archivo" & i.ToString))
        Next
        pbActualizacion.Maximum = Archivos.Count + 2
        Try
            For Each Archivo In Archivos
                If Not Archivo.EndsWith("Update.config") Then
                    ArchivoDestino = RutaDestino & Archivo.Substring(RutaOrigen.Length)
                    lstDetalles.Items.Add("Verificando archivo: " & Archivo.Substring(RutaOrigen.Length))
                    lstDetalles.Refresh()
                    lstDetalles.Items.Add("Comparando versiones del archivo a copiar")
                    lstDetalles.SelectedIndex = lstDetalles.Items.Count - 1
                    lstDetalles.Refresh()
                    lstDetalles.Items.Add("Copiando el archivo " & Archivo.Substring(RutaOrigen.Length))
                    lstDetalles.SelectedIndex = lstDetalles.Items.Count - 1
                    lstDetalles.Refresh()
                    File.Copy(Archivo, RutaDestino & Archivo.Substring(RutaOrigen.Length), True)
                    lstDetalles.Items.Add("Se ha copiado el archivo " & Archivo.Substring(RutaOrigen.Length))
                    lstDetalles.SelectedIndex = lstDetalles.Items.Count - 1
                    lstDetalles.Refresh()
                    'System.Threading.Thread.CurrentThread.Sleep(200)
                    Threading.Thread.Sleep(200)
                    pbActualizacion.Increment(1)
                End If
            Next
        Catch ex As Exception
            ErrMessage(ex)
            Me.Close()
            Me.Dispose()
            End
        End Try
        btnCopiaArchivos.ImageIndex += 1
        lblCopiaArchivos.ForeColor = Color.Gray
        Me.Refresh()
    End Sub

    Private Sub CreaAcceso(ByVal Ejecutable As String)
        lblAccesos.ForeColor = Color.Blue
        btnAccesos.ImageIndex += 1
        btnAccesos.Focus()
        Application.DoEvents()
        Me.Refresh()
        Dim wShortcut As IWshRuntimeLibrary.IWshShortcut_Class
        Dim wShell As New IWshRuntimeLibrary.IWshShell_Class()
        Try
            If File.Exists(RutaDestino & Ejecutable) Then
                lstDetalles.Items.Add("Creando acceso en el escritorio.")
                lstDetalles.SelectedIndex = lstDetalles.Items.Count - 1
                lstDetalles.Refresh()
                pbActualizacion.Increment(1)
                Try
                    wShortcut = CType(wShell.CreateShortcut(CStr(wShell.SpecialFolders.Item(0)) & "\" & Ejecutable.Substring(0, Ejecutable.Length - 4) & ".lnk"), IWshRuntimeLibrary.IWshShortcut_Class)
                    wShortcut.TargetPath = RutaDestino & Ejecutable
                    wShortcut.RelativePath = RutaDestino
                    wShortcut.WorkingDirectory = RutaDestino
                    wShortcut.Save()
                Catch
                    wShortcut = CType(wShell.CreateShortcut(CStr(wShell.SpecialFolders.Item(4)) & "\" & Ejecutable.Substring(0, Ejecutable.Length - 4) & ".lnk"), IWshRuntimeLibrary.IWshShortcut_Class)
                    wShortcut.TargetPath = RutaDestino & Ejecutable
                    wShortcut.RelativePath = RutaDestino
                    wShortcut.WorkingDirectory = RutaDestino
                    wShortcut.Save()
                End Try
                lstDetalles.Items.Add("Se ha creado el acceso directo.")
                lstDetalles.SelectedIndex = lstDetalles.Items.Count - 1
                lstDetalles.Refresh()
                pbActualizacion.Increment(1)
                btnAccesos.ImageIndex += 1
                lblAccesos.ForeColor = Color.Gray
            End If
        Catch ex As Exception
            ErrMessage(ex)
        End Try
    End Sub


    Private Sub BorraAccesos(ByVal Ejecutable As String)
        Dim wShortcut As IWshRuntimeLibrary.IWshShortcut_Class
        Dim wShell As New IWshRuntimeLibrary.IWshShell_Class()
        Dim str As String
        lblAccesos.ForeColor = Color.Blue
        btnAccesos.ImageIndex += 1
        btnAccesos.Focus()
        Application.DoEvents()
        Me.Refresh()
        Try
            lstDetalles.Items.Add("Verificando existencia de accesos directos.")
            lstDetalles.SelectedIndex = lstDetalles.Items.Count - 1
            lstDetalles.Refresh()
            lstDetalles.Items.Add("Eliminanado accesos redundantes para todos los usuarios.")
            lstDetalles.SelectedIndex = lstDetalles.Items.Count - 1
            lstDetalles.Refresh()
            For Each str In Directory.GetFiles(CStr(wShell.SpecialFolders.Item(0)), "*.lnk")
                wShortcut = CType(wShell.CreateShortcut(str), IWshRuntimeLibrary.IWshShortcut_Class)
                If wShortcut.TargetPath.EndsWith(Ejecutable) Then
                    File.Delete(str)
                End If
            Next
            lstDetalles.Items.Add("Eliminanado accesos redundantes para el usuario actual.")
            lstDetalles.SelectedIndex = lstDetalles.Items.Count - 1
            lstDetalles.Refresh()
            For Each str In Directory.GetFiles(CStr(wShell.SpecialFolders.Item(4)), "*.lnk")
                wShortcut = CType(wShell.CreateShortcut(str), IWshRuntimeLibrary.IWshShortcut_Class)
                If wShortcut.TargetPath.EndsWith(Ejecutable) Then
                    File.Delete(str)
                End If
            Next
        Catch ex As Exception
            ErrMessage(ex)
        End Try
    End Sub


End Class

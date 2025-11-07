
#Region " K-WAYD (Server) "

#Region " FMenu "

Public Class FMenu

#Region " Variables "

    Public Version As String = "1.0"
    Public RegName As String = "K-WAYD 1.0"

    Public Loaded As Boolean

    Public WithEvents Servidor As New Servidor
    Public IPAddress As Net.IPAddress = FSettings.GetLocalIP()
    Public Puerto As Integer

    Public Serial As New IO.Ports.SerialPort With {.BaudRate = 9600}
    Public Arduino, LogActivity, IniciarWindows As Boolean
    Dim Serial_Data As String
    Dim Notify As New NotifyIcon With {.Text = "K-WAYD " + Version, .Visible = True, .Icon = My.Resources.Icono}
    Dim Cliente_Seleccionado As Integer
    Dim GeneralTimer As New Timer With {.Enabled = True, .Interval = 100}
    Dim Youtube As New YouTube
    Dim Modo As String = "Mixto"

    Dim Cerrando As Boolean

#End Region

#Region " Eventos del Formulario "

#Region " Load "

    Private Sub FMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Width = CInt(Registro.GetRegKey(RegName, "Width", MinimumSize.Width))
        Height = CInt(Registro.GetRegKey(RegName, "Height", MinimumSize.Height))
        Left = CInt(Registro.GetRegKey(RegName, "Left", (Screen.PrimaryScreen.Bounds.Width - Width) / 2))
        Top = CInt(Registro.GetRegKey(RegName, "Top", (Screen.PrimaryScreen.Bounds.Height - Height) / 2))

        Opciones_Cargar()

        AddHandler Serial.DataReceived, AddressOf Serial_DataReceived
        AddHandler Serial.ErrorReceived, AddressOf Serial_ErrorReceived
        AddHandler Notify.Click, AddressOf Notify_Click
        AddHandler Notify.DoubleClick, AddressOf Notify_DoubleClick
        AddHandler GeneralTimer.Tick, AddressOf GeneralTimer_Tick
        AddHandler MensajeTimer.Tick, AddressOf MensajeTimer_Tick
        Notify.ContextMenuStrip = CMenu

        Servidor.Escuchar(IPAddress, Puerto)
        If Arduino = True Then Serial_Open()
    End Sub

    Private Sub FMenu_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Loaded = True
    End Sub

    Private Sub FMenu_Move(sender As Object, e As EventArgs) Handles Me.Move
        If Loaded = True Then Registro.SetRegKey(RegName, "Left", Left.ToString) : Registro.SetRegKey(RegName, "Top", Top.ToString)
    End Sub

    Private Sub FMenu_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        If Loaded = True Then Registro.SetRegKey(RegName, "Width", Width.ToString) : Registro.SetRegKey(RegName, "Height", Height.ToString)
    End Sub

#End Region

    Private Sub GeneralTimer_Tick(sender As Object, e As EventArgs)
        If Serial.IsOpen = True Then
            LArduino.ForeColor = Color.LightGreen
        Else
            LArduino.ForeColor = Color.IndianRed
            If Arduino = True Then Serial_Open()
        End If
    End Sub

#Region " Closing "

    Private Sub FMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then e.Cancel = True : Opacity = 0 : Exit Sub
        Cerrando = True : Servidor.Cerrar()
        'If Serial.IsOpen Then Serial_Enviar("   K-WAYD " + Version + "   ") : Serial.Close()
        Dim NMensaje(1) As String
        If Serial.IsOpen Then NMensaje(0) = "   K-WAYD " + Version + "   " : NMensaje(1) = "" : Reset_MensajeTimer(NMensaje) : Serial.Close()
    End Sub

#End Region

#Region " Controls "

    Private Sub THidden_KeyPress(sender As Object, e As KeyPressEventArgs) Handles THidden.KeyPress
        If Asc(e.KeyChar) = 13 Then e.Handled = True
    End Sub

#End Region

#End Region

#Region " Funciones "

#Region " Cargar "

    Public Sub Opciones_Cargar()
        Dim IP As String = Registro.GetRegKey(RegName, "DireccionIP", "")
        If IP = "" Then IPAddress = FSettings.GetLocalIP() Else IPAddress = Net.IPAddress.Parse(IP)
        Puerto = CInt(Registro.GetRegKey(RegName, "Puerto", "12345"))

        Arduino = CBool(Registro.GetRegKey(RegName, "Arduino", "False"))
        Serial.PortName = Registro.GetRegKey(RegName, "Arduino_COM", "COM1")
        Serial.BaudRate = CInt(Registro.GetRegKey(RegName, "Arduino_BaudRate", "9600"))

        IniciarWindows = CBool(Registro.GetRegKey(RegName, "IniciarWindows", "False"))
        If IniciarWindows = True Then Registro.Registrar() Else Registro.DesRegistrar()
        LogActivity = CBool(Registro.GetRegKey(RegName, "LogActivity", "False"))
    End Sub

#End Region

#Region " Guardar "

    Public Sub Opciones_Guardar()
        Registro.SetRegKey(RegName, "DireccionIP", IPAddress.ToString)
        Registro.SetRegKey(RegName, "Puerto", Puerto.ToString)

        Registro.SetRegKey(RegName, "Arduino", Arduino.ToString)
        Registro.SetRegKey(RegName, "Arduino_COM", Serial.PortName)
        Registro.SetRegKey(RegName, "Arduino_BaudRate", Serial.BaudRate.ToString)

        Registro.SetRegKey(RegName, "IniciarWindows", IniciarWindows.ToString)
        Registro.SetRegKey(RegName, "LogActivity", LogActivity.ToString)
    End Sub

#End Region

#Region " Play Sound "

    Public Sub Play_Sound(Sonido As String)
        Select Case Sonido
            Case "Alarma 1" : My.Computer.Audio.Play(My.Resources.Alarma1, AudioPlayMode.Background)
            Case "Alarma 2" : My.Computer.Audio.Play(My.Resources.Alarma2, AudioPlayMode.Background)
            Case "Background" : My.Computer.Audio.Play(My.Resources.Background, AudioPlayMode.Background)
            Case "Balloon" : My.Computer.Audio.Play(My.Resources.Balloon, AudioPlayMode.Background)
            Case "Battery Critical" : My.Computer.Audio.Play(My.Resources.BatteryCritical, AudioPlayMode.Background)
            Case "Battery Low" : My.Computer.Audio.Play(My.Resources.BatteryLow, AudioPlayMode.Background)
            Case "Calendar" : My.Computer.Audio.Play(My.Resources.Calendar, AudioPlayMode.Background)
            Case "Camera" : My.Computer.Audio.Play(My.Resources.Camera, AudioPlayMode.Background)
            Case "Chimes" : My.Computer.Audio.Play(My.Resources.Chimes, AudioPlayMode.Background)
            Case "Chord" : My.Computer.Audio.Play(My.Resources.Chord, AudioPlayMode.Background)
            Case "Connection" : My.Computer.Audio.Play(My.Resources.Connection, AudioPlayMode.Background)
            Case "Control" : My.Computer.Audio.Play(My.Resources.Control, AudioPlayMode.Background)
            Case "Default" : My.Computer.Audio.Play(My.Resources._Default, AudioPlayMode.Background)
            Case "Ding" : My.Computer.Audio.Play(My.Resources.Ding, AudioPlayMode.Background)
            Case "Email" : My.Computer.Audio.Play(My.Resources.Email, AudioPlayMode.Background)
            Case "Error" : My.Computer.Audio.Play(My.Resources._Error, AudioPlayMode.Background)
            Case "Exclamation" : My.Computer.Audio.Play(My.Resources.Exclamation, AudioPlayMode.Background)
            Case "Foreground" : My.Computer.Audio.Play(My.Resources.Foreground, AudioPlayMode.Background)
            Case "Generic" : My.Computer.Audio.Play(My.Resources.Generic, AudioPlayMode.Background)
            Case "Hardware Fail" : My.Computer.Audio.Play(My.Resources.Fail, AudioPlayMode.Background)
            Case "Harware Insert" : My.Computer.Audio.Play(My.Resources.Insert, AudioPlayMode.Background)
            Case "Hardware Remove" : My.Computer.Audio.Play(My.Resources.Remove, AudioPlayMode.Background)
            Case "LogOff" : My.Computer.Audio.Play(My.Resources.Logoff, AudioPlayMode.Background)
            Case "LogOn" : My.Computer.Audio.Play(My.Resources.Logon, AudioPlayMode.Background)
            Case "Message" : My.Computer.Audio.Play(My.Resources.Message, AudioPlayMode.Background)
            Case "Messaging" : My.Computer.Audio.Play(My.Resources.Messaging, AudioPlayMode.Background)
            Case "Notification 1" : My.Computer.Audio.Play(My.Resources.Notification, AudioPlayMode.Background)
            Case "Notification 2" : My.Computer.Audio.Play(My.Resources.Notify1, AudioPlayMode.Background)
            Case "Notification 3" : My.Computer.Audio.Play(My.Resources.Notify2, AudioPlayMode.Background)
            Case "Print" : My.Computer.Audio.Play(My.Resources.Print, AudioPlayMode.Background)
            Case "Recycle" : My.Computer.Audio.Play(My.Resources.Recycle, AudioPlayMode.Background)
            Case "Ring 1" : My.Computer.Audio.Play(My.Resources.Ring1, AudioPlayMode.Background)
            Case "Ring 2" : My.Computer.Audio.Play(My.Resources.Ring2, AudioPlayMode.Background)
            Case "Ring 3" : My.Computer.Audio.Play(My.Resources.Ring3, AudioPlayMode.Background)
            Case "Shutdown" : My.Computer.Audio.Play(My.Resources.Shutdown, AudioPlayMode.Background)
            Case "Stop" : My.Computer.Audio.Play(My.Resources._Stop, AudioPlayMode.Background)
            Case "Tada" : My.Computer.Audio.Play(My.Resources.Tada, AudioPlayMode.Background)
            Case "Unlock" : My.Computer.Audio.Play(My.Resources.Unlock, AudioPlayMode.Background)
        End Select
    End Sub

#End Region

#End Region

#Region " Controles "

#Region " TClientes "

    Private Sub TClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TClientes.SelectedIndexChanged
        Dim NMensaje(1) As String : NMensaje(0) = "" : NMensaje(1) = ""
        For Cuenta = 0 To Servidor.Clientes.Count - 1
            If Servidor.Clientes.Count = 0 Then Exit Sub
            If Servidor.Clientes(Cuenta).Nombre = TClientes.SelectedTab.Text Then
                Cliente_Seleccionado = Cuenta
                Dim NuevoMensaje As String = Servidor.Clientes(Cuenta).LastMensaje
                If NuevoMensaje = "" Then NMensaje(0) = "   K-WAYD " + Version + "   " : NMensaje(1) = "" : Reset_MensajeTimer(NMensaje) : Exit Sub

                NuevoMensaje = RemoveDiacritics(NuevoMensaje)

                Dim Proceso As String = NuevoMensaje.Split("|")(0)
                Dim WindowTitle As String = NuevoMensaje.Split("|")(1).Replace("@-@", "|")
                NuevoMensaje = Procesar_Mensaje(Proceso)

                If NuevoMensaje = "explorer" Then
                    If WindowTitle.ToLower.Trim = "" Or WindowTitle.ToLower.Trim = "program data" Then
                        NuevoMensaje = "Escritorio"
                        NMensaje(0) = "Escritorio"
                    Else
                        NuevoMensaje = "Explorando...           " + WindowTitle
                        NMensaje(0) = "Explorando..." : NMensaje(1) = WindowTitle
                    End If
                End If
                If NuevoMensaje = "Chateando en Telegram" Then
                    NuevoMensaje += "  (" + WindowTitle + ")"
                    NuevoMensaje = NuevoMensaje.Replace("  (Telegram)", "")
                    NMensaje(0) = "Telegram"
                    If WindowTitle.ToLower <> "telegram" Then NMensaje(1) = "Chateando con " + WindowTitle
                End If
                If NuevoMensaje = "chrome" Or NuevoMensaje = "brave" Then
                    Dim Found As Boolean
                    If WindowTitle.Replace(" - Google Chrome", "").Replace(" - Brave", "") = ("YouTube") Then
                        NuevoMensaje = "Viendo Youtube"
                        NMensaje(0) = "Viendo Youtube"
                        Found = True
                    End If
                    If WindowTitle.ToLower.Contains(" - youtube") Then
                        WindowTitle = EliminarParentesis(WindowTitle.Replace(" - YouTube", "").Replace(" - Google Chrome", "").Replace(" - Brave", ""))
                        NuevoMensaje = "Viendo Youtube      " + WindowTitle + GetURL(WindowTitle) : Found = True
                        NMensaje(0) = "Viendo Youtube" : NMensaje(1) = WindowTitle : Found = True
                    End If
                    If WindowTitle.ToLower.Contains("pluto tv") Then NuevoMensaje = "Viendo Pluto TV" : NMensaje(0) = "Viendo Pluto TV" : Found = True
                    If WindowTitle.ToLower.Contains("facebook") Then NuevoMensaje = "En Facebook" : NMensaje(0) = "En Facebook" : Found = True
                    If WindowTitle.ToLower.Contains("prime video") Then NuevoMensaje = "Viendo una peli en Prime" : NMensaje(0) = "Viendo una peli en Prime" : Found = True
                    If WindowTitle.ToLower.Contains("cuarto milenio") Then NuevoMensaje = "Viendo Cuarto Milenio" : NMensaje(0) = "Viendo Cuarto Milenio" : Found = True
                    If WindowTitle.ToLower.Contains("amazon") Then NuevoMensaje = "Comprando en Amazon" : NMensaje(0) = "Comprando en Amazon" : Found = True
                    If WindowTitle.ToLower.Contains("atresplayer") Then NuevoMensaje = "Viendo la TV" : NMensaje(0) = "Viendo la TV" : Found = True
                    If WindowTitle.ToLower.Contains("pornhub") Then NuevoMensaje = "Viendo porno" : NMensaje(0) = "Viendo porno" : Found = True
                    If WindowTitle.ToLower.Contains("youporn") Then NuevoMensaje = "Viendo porno" : NMensaje(0) = "Viendo porno" : Found = True
                    If WindowTitle.ToLower.Contains("xvideos") Then NuevoMensaje = "Viendo porno" : NMensaje(0) = "Viendo porno" : Found = True
                    If WindowTitle.ToLower.Contains("xhamster") Then NuevoMensaje = "Viendo porno" : NMensaje(0) = "Viendo porno" : Found = True
                    If Found = False Then
                        NuevoMensaje = "En Internet              " + WindowTitle.Replace(" - Google Chrome", "").Replace(" - Brave", "")
                        NMensaje(0) = "En Internet" : NMensaje(1) = WindowTitle.Replace(" - Google Chrome", "").Replace(" - Brave", "")
                    End If
                End If
                If NuevoMensaje = "Default" Then NuevoMensaje = Proceso : NMensaje(0) = Proceso
                If NuevoMensaje.EndsWith("https://www.youtube.com/watch?v=") Then
                    NuevoMensaje = "Viendo Youtube"
                    NMensaje(0) = "Viendo Youtube" : NMensaje(1) = ""
                End If

                'Serial_Enviar(NuevoMensaje.Replace("Viendo Youtube      ", "Viendo Youtube   ").Replace("En Internet              ", "En Internet   ").Replace("Explorando...           ", "Explorando...   "))
                Reset_MensajeTimer(NMensaje)
                End If
                Next
    End Sub

#End Region

#Region " TCliente "

#Region " Texto "

    Private Sub Texto_TextChanged(sender As Object, e As EventArgs)
        If sender.Focused = False Then sender.SelectionStart = Math.Max(sender.Text.Length - 1, 0) : sender.SelectionLength = 0 : sender.ScrollToCaret()
    End Sub

    Private Sub Texto_LinkClicked(sender As Object, e As LinkClickedEventArgs)
        Process.Start(e.LinkText)
    End Sub

    Private Function GetURL(Titulo As String) As String
        Dim Result As JsVideo = Youtube.Search(Titulo)
        If Result Is Nothing Then Return ""
        For Each Video As JsItems In Result.Items
            If EliminarAcentos(Titulo) = EliminarAcentos(Net.WebUtility.HtmlDecode(Video.Snippet.Title)) Then Return " - " + ("https://www.youtube.com/v/" + Video.ID.VideoID).Replace("v/", "watch?v=")
        Next : Return ""
        'If Result IsNot Nothing Then Return " - " + ("https://www.youtube.com/v/" + Result.Items(0).ID.VideoID).Replace("v/", "watch?v=") Else Return ""
    End Function

    Function EliminarAcentos(Titulo As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(System.Text.RegularExpressions.Regex.Replace(Titulo.Normalize(System.Text.NormalizationForm.FormD), "[^a-zA-Z0-9\s]", ""), "\s+", " ").Trim()
    End Function

#End Region

#Region " Imagen "

    Private Sub Imagen_DoubleClick(sender As Object, e As MouseEventArgs)
        If e.Button <> MouseButtons.Left Then Exit Sub
        If WindowState = FormWindowState.Maximized Then WindowState = FormWindowState.Normal Else WindowState = FormWindowState.Maximized
    End Sub

#End Region

#Region " TMenu "

#Region " Opening "

    Private Sub TMenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TMenu.Opening
        Dim Nombre As String = "" : Dim Indice As Integer = -1
        For Each Cliente As ClienteInfo In Servidor.Clientes
            If Cliente.Nombre = TryCast(sender.SourceControl.Parent, TabPage).Text Then
                Nombre = Cliente.Nombre
                TMCapturaAuto.Checked = Cliente.AutoCaptura
                TMIntervalo.Text = Cliente.Interval.ToString
                Exit For
            End If
        Next : If Nombre.Trim = "" Then Exit Sub
        For Each TCliente As TabPage In TClientes.TabPages
            If TCliente.Text = Nombre Then Indice = TClientes.TabPages.IndexOf(TCliente) : Exit For
        Next : If Indice = -1 Then Exit Sub

        If TryCast(TClientes.TabPages(Indice).Controls(0), PictureBox).Image Is Nothing Then TMGuardarCaptura.Visible = False Else TMGuardarCaptura.Visible = True
        If TryCast(TClientes.TabPages(Indice).Controls(1), RichTextBox).Text = "" Then TMGuardarLog.Visible = False : TMVaciarLog.Visible = False : TMSeparador0.Visible = False Else TMGuardarLog.Visible = True : TMVaciarLog.Visible = True : TMSeparador0.Visible = True

        TMenu.Tag = TClientes.TabPages.IndexOf(TryCast(sender.SourceControl.Parent, TabPage))
    End Sub

#End Region

#Region " Log "

#Region " Guardar Log "

    Private Sub TMGuardarLog_Click(sender As Object, e As EventArgs) Handles TMGuardarLog.Click
        Dim Nombre As String = "" : Dim Indice As Integer = -1
        For Each Cliente As ClienteInfo In Servidor.Clientes
            If Cliente.Nombre = TClientes.TabPages(TMenu.Tag).Text Then Nombre = Cliente.Nombre : Exit For
        Next : If Nombre.Trim = "" Then Exit Sub
        For Each TCliente As TabPage In TClientes.TabPages
            If TCliente.Text = Nombre Then Indice = TClientes.TabPages.IndexOf(TCliente) : Exit For
        Next : If Indice = -1 Then Exit Sub

        Dim GuardarLog As New SaveFileDialog With {.AddExtension = True, .CheckPathExists = True, .DefaultExt = ".txt", .Filter = "Archivo de Texto (*.txt)|*.txt", .Title = "Guardar log de '" + Nombre + "'", .FileName = Nombre + " - (" + Now.ToString("yyyy-MM-dd HH-mm-ss") + ").txt"}
        If GuardarLog.ShowDialog = DialogResult.Cancel Then Exit Sub

        Try : IO.File.WriteAllText(GuardarLog.FileName, TClientes.TabPages(Indice).Controls(1).Text)
        Catch : End Try
    End Sub

#End Region

#Region " Vaciar Log "

    Private Sub TMVaciarLog_Click(sender As Object, e As EventArgs) Handles TMVaciarLog.Click
        Dim Nombre As String = "" : Dim Indice As Integer = -1
        For Each Cliente As ClienteInfo In Servidor.Clientes
            If Cliente.Nombre = TClientes.TabPages(TMenu.Tag).Text Then Nombre = Cliente.Nombre : Exit For
        Next : If Nombre.Trim = "" Then Exit Sub
        For Each TCliente As TabPage In TClientes.TabPages
            If TCliente.Text = Nombre Then Indice = TClientes.TabPages.IndexOf(TCliente) : Exit For
        Next : If Indice = -1 Then Exit Sub

        TClientes.TabPages(Indice).Controls(1).Text = ""
        If IO.File.Exists("Activity\" + TClientes.TabPages(Indice).Text + "\" + TClientes.TabPages(Indice).Text + ".txt") Then IO.File.Delete("Activity\" + TClientes.TabPages(Indice).Text + "\" + TClientes.TabPages(Indice).Text + ".txt")
    End Sub

#End Region

#Region " Log Mensaje "

    Private Sub LogMensaje(Nombre As String, Mensaje As String)
        If LogActivity = True Then
            If IO.Directory.Exists("Activity\" + Nombre) = False Then IO.Directory.CreateDirectory("Activity\" + Nombre)
            IO.File.AppendAllText("Activity\" + Nombre + "\" + Nombre + ".txt", Mensaje)
        End If
    End Sub

#End Region

#End Region

#Region " Capturas "

#Region " Capturar Pantalla "

    Private Sub TMCapturarPantalla_Click(sender As Object, e As EventArgs) Handles TMCapturarPantalla.Click
        For Each Cliente As ClienteInfo In Servidor.Clientes
            If Cliente.Nombre = TryCast(DirectCast(sender.Owner, ContextMenuStrip).SourceControl.Parent, TabPage).Text Then Servidor.Enviar(Cliente, "CAPTURA") : Exit For
        Next
        TMenu.Close()
    End Sub

#End Region

#Region " Guardar Captura "

    Private Sub TMGuardarCaptura_Click(sender As Object, e As EventArgs)
        Dim Nombre As String = "" : Dim Indice As Integer = -1
        For Each Cliente As ClienteInfo In Servidor.Clientes
            If Cliente.Nombre = TClientes.TabPages(TMenu.Tag).Text Then Nombre = Cliente.Nombre : Exit For
        Next : If Nombre.Trim = "" Then Exit Sub
        For Each TCliente As TabPage In TClientes.TabPages
            If TCliente.Text = Nombre Then Indice = TClientes.TabPages.IndexOf(TCliente) : Exit For
        Next : If Indice = -1 Then Exit Sub

        Dim GuardarCaptura As New SaveFileDialog With {.AddExtension = True, .CheckPathExists = True, .DefaultExt = ".jpg", .Filter = "Archivo de Imagen (*.jpg)|*.jpg", .Title = "Guardar captura de '" + Nombre + "'", .FileName = Nombre + " - (" + Now.ToString("yyyy-MM-dd HH-mm-ss") + ").jpg"}
        If GuardarCaptura.ShowDialog = DialogResult.Cancel Then Exit Sub

        Try
            Dim Imagen As New Bitmap(TryCast(TClientes.TabPages(Indice).Controls(0), PictureBox).Image)
            Imagen.Save(GuardarCaptura.FileName, Imaging.ImageFormat.Jpeg)
        Catch : End Try
    End Sub

#End Region

#Region " Auto Capturas "

    Private Sub TMCapturaAuto_Click(sender As Object, e As EventArgs) Handles TMCapturaAuto.Click
        For Each Cliente As ClienteInfo In Servidor.Clientes
            If Cliente.Nombre = TClientes.TabPages(TMenu.Tag).Text Then
                Cliente.AutoCaptura = TMCapturaAuto.Checked
                Servidor.Enviar(Cliente, "AUTOCAPTURA|" + TMCapturaAuto.Checked.ToString)
                Exit For
            End If
        Next
    End Sub

#End Region

    Private Sub TMIntervalo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TMIntervalo.KeyPress
        If Asc(e.KeyChar) = 13 Then e.Handled = True : THidden.Focus()
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(8) AndAlso e.KeyChar <> ChrW(46) Then e.Handled = True
    End Sub

    Private Sub TMIntervalo_LostFocus(sender As Object, e As EventArgs) Handles TMIntervalo.LostFocus
        For Each Cliente As ClienteInfo In Servidor.Clientes
            If Cliente.Nombre = TClientes.TabPages(TMenu.Tag).Text Then
                If TMIntervalo.Text.Trim = "" Then TMIntervalo.Text = Cliente.Interval.ToString : Exit Sub
                If CInt(TMIntervalo.Text) < 1 Then TMIntervalo.Text = "1"
                If CInt(TMIntervalo.Text) > 900 Then TMIntervalo.Text = "900"
                Cliente.Interval = TMIntervalo.Text
                Servidor.Enviar(Cliente, "AUTOCAPTURAINTERVAL|" + (CInt(TMIntervalo.Text) * 1000).ToString)
                Exit For
            End If
        Next
    End Sub

#End Region

#Region " Cerrar Cliente "

    Private Sub TMCerrarCliente_Click(sender As Object, e As EventArgs) Handles TMCerrarCliente.Click
        For Each Cliente As ClienteInfo In Servidor.Clientes
            If Cliente.Nombre = TClientes.TabPages(TMenu.Tag).Text Then Servidor.Enviar(Cliente, "CERRAR") : Exit For
        Next
    End Sub

#End Region

#Region " Salir "

    Private Sub TMSalir_Click(sender As Object, e As EventArgs) Handles TMSalir.Click
        End
    End Sub

#End Region

#End Region

#End Region

#Region " Botones "

#Region " Switch "

    Private Sub BSwitch_Click(sender As Object, e As EventArgs) Handles BSwitch.Click
        If Servidor.Clientes.Count = 0 Then Exit Sub
        Select Case Modo
            Case "Mixto" : Modo = "Captura"
            Case "Captura" : Modo = "Texto"
            Case "Texto" : Modo = "Mixto"
        End Select
        Select Case Modo
            Case "Mixto"
                TClientes.SelectedTab.Controls(0).Size = New Size(TClientes.SelectedTab.Width - 4, TClientes.SelectedTab.Height - 307)
                TClientes.SelectedTab.Controls(0).Location = New Point(2, 2)

                TClientes.SelectedTab.Controls(1).Size = New Size(TClientes.SelectedTab.Width - 4, 300)
                TClientes.SelectedTab.Controls(1).Location = New Point(2, TClientes.SelectedTab.Height - 303)

                TClientes.SelectedTab.Controls(0).Visible = True
                TClientes.SelectedTab.Controls(1).Visible = True
            Case "Captura"
                TClientes.SelectedTab.Controls(0).Size = New Size(TClientes.SelectedTab.Width - 4, TClientes.SelectedTab.Height - 5)
                TClientes.SelectedTab.Controls(0).Location = New Point(2, 2)

                TClientes.SelectedTab.Controls(0).Visible = True
                TClientes.SelectedTab.Controls(1).Visible = False
            Case "Texto"
                TClientes.SelectedTab.Controls(1).Size = New Size(TClientes.SelectedTab.Width - 4, TClientes.SelectedTab.Height - 5)
                TClientes.SelectedTab.Controls(1).Location = New Point(2, 2)

                TClientes.SelectedTab.Controls(0).Visible = False
                TClientes.SelectedTab.Controls(1).Visible = True
        End Select
    End Sub

#End Region

#Region " Capturar Pantalla "

    Private Sub BCapturarPantalla_Click(sender As Object, e As EventArgs) Handles BCapturarPantalla.Click
        Dim cCliente As ClienteInfo = Nothing
        For Each Cliente As ClienteInfo In Servidor.Clientes
            If Cliente.Nombre = TClientes.SelectedTab.Text Then cCliente = Cliente : Exit For
        Next
        If cCliente IsNot Nothing Then
            TClientes.SelectedTab.Controls(1).Text += Now.ToString("dd/MM/yyyy HH:mm:ss   -   ") + "[Capturar Pantalla]" + vbCrLf
            LogMensaje(cCliente.Nombre, Now.ToString("dd/MM/yyyy HH:mm:ss   -   ") + "[Capturar Pantalla]" + vbCrLf)
            Servidor.Enviar(cCliente, "CAPTURA")
        End If
    End Sub

#End Region

#Region " Enviar Mensaje "

    Private Sub BEnviarMensaje_Click(sender As Object, e As EventArgs) Handles BEnviarMensaje.Click
        Dim cCliente As ClienteInfo = Nothing
        For Each Cliente As ClienteInfo In Servidor.Clientes
            If Cliente.Nombre = TClientes.SelectedTab.Text Then cCliente = Cliente : Exit For
        Next
        If cCliente IsNot Nothing Then
            FMensaje.TNombre.Text = cCliente.Nombre
            FMensaje.Reset()
            FMensaje.ShowDialog()
            If FMensaje.Cancelado = False Then
                TClientes.SelectedTab.Controls(1).Text += Now.ToString("dd/MM/yyyy HH:mm:ss   -   ") + "[Enviar Mensaje]   " + AddLines(FMensaje.Texto.Text) + vbCrLf
                LogMensaje(cCliente.Nombre, Now.ToString("dd/MM/yyyy HH:mm:ss   -   ") + "[Enviar Mensaje]   " + AddLines(FMensaje.Texto.Text) + vbCrLf)
                Servidor.Enviar(cCliente, "MENSAJE|" + FMensaje.Icono + "|" + FMensaje.Respuesta + "|" + FMensaje.TTitulo.Text + "|" + FMensaje.Texto.Text)
            End If
        End If
    End Sub

    Private Function AddLines(Texto As String) As String
        Dim Lineas() As String = Texto.Split(New String() {vbCrLf, vbLf}, StringSplitOptions.None)

        For Cuenta As Integer = 1 To Lineas.Length - 1
            Lineas(Cuenta) = "                                                                       " + Lineas(Cuenta)
        Next : Return String.Join(vbCrLf, Lineas)
    End Function

#End Region

#Region " Reproducir Sonido "

    Private Sub BReproducirSonido_Click(sender As Object, e As EventArgs) Handles BPlaySound.Click
        Dim cCliente As ClienteInfo = Nothing
        For Each Cliente As ClienteInfo In Servidor.Clientes
            If Cliente.Nombre = TClientes.SelectedTab.Text Then cCliente = Cliente : Exit For
        Next
        If cCliente IsNot Nothing Then
            FPlaySound.TNombre.Text = cCliente.Nombre
            FPlaySound.Cancelado = True
            FPlaySound.ShowDialog()
            If FPlaySound.Cancelado = False Then
                TClientes.SelectedTab.Controls(1).Text += Now.ToString("dd/MM/yyyy HH:mm:ss   -   ") + "[Reproducir Sonido]   " + FPlaySound.CSonido.SelectedItem + vbCrLf
                LogMensaje(cCliente.Nombre, Now.ToString("dd/MM/yyyy HH:mm:ss   -   ") + "[Reproducir Sonido]   " + FPlaySound.CSonido.SelectedItem + vbCrLf)
                Servidor.Enviar(cCliente, "PLAYSOUND|" + FPlaySound.CSonido.SelectedItem)
            End If
        End If
    End Sub

#End Region

#Region " Buzz "

    Private Sub BBuzz_Click(sender As Object, e As EventArgs) Handles BBuzz.Click
        Dim cCliente As ClienteInfo = Nothing
        For Each Cliente As ClienteInfo In Servidor.Clientes
            If Cliente.Nombre = TClientes.SelectedTab.Text Then cCliente = Cliente : Exit For
        Next
        If cCliente IsNot Nothing Then

            TClientes.SelectedTab.Controls(1).Text += Now.ToString("dd/MM/yyyy HH:mm:ss   -   ") + "[Enviar Buzz]" + vbCrLf
            LogMensaje(cCliente.Nombre, Now.ToString("dd/MM/yyyy HH:mm:ss   -   ") + "[Enviar Buzz]" + vbCrLf)
            Servidor.Enviar(cCliente, "BUZZ")
        End If
    End Sub

#End Region

#Region " Ajustes "

    Private Sub BSettings_Click(sender As Object, e As EventArgs) Handles BSettings.Click
        FSettings.ShowDialog()
    End Sub

#End Region

#End Region

#Region " Notify Icon "

    Private Sub Notify_Click(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left AndAlso Opacity = 1 Then Activate() : Focus()
    End Sub

    Private Sub Notify_DoubleClick(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then MMostrar_Click(sender, Nothing)
    End Sub

#Region " CMenu "

    Private Sub CMenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CMenu.Opening
        If Opacity = 1 Then MMostrar.Text = "Oculta&r" Else MMostrar.Text = "Mostra&r"
    End Sub

    Private Sub MMostrar_Click(sender As Object, e As EventArgs) Handles MMostrar.Click
        If Opacity = 1 Then Opacity = 0 Else Opacity = 1 : Activate() : Focus()
    End Sub

    Private Sub MSalir_Click(sender As Object, e As EventArgs) Handles MSalir.Click
        End
    End Sub

#End Region

#End Region

#End Region

#Region " Servidor "

#Region " Conectado "

    Private Sub Servidor_Conectado(Cliente As ClienteInfo) Handles Servidor.Conectado
        If InvokeRequired Then : Invoke(Sub() Servidor_Conectado(Cliente)) : Else
            My.Computer.Audio.Play(My.Resources.Connected, AudioPlayMode.Background)
        End If
    End Sub

#End Region

#Region " Desconectado "

    Private Sub Servidor_Desconectado(Cliente As ClienteInfo) Handles Servidor.Desconectado
        If Cerrando = True Then Exit Sub
        If InvokeRequired Then : Invoke(Sub() Servidor_Desconectado(Cliente)) : Else
            My.Computer.Audio.Play(My.Resources.Disconnected, AudioPlayMode.Background)
            For Each TCliente As TabPage In TClientes.TabPages
                If TCliente.Text = Cliente.Nombre Then TClientes.TabPages.Remove(TCliente) : Exit For
            Next
            LClientes.Text = "Clientes: " + TClientes.TabPages.Count.ToString
            If TClientes.TabPages.Count = 0 Then Fondo.Visible = True : TClientes.Visible = False

            If Servidor.Clientes.Count = 0 Then Cliente_Seleccionado = -1
            If Servidor.Clientes.Count = 1 Then Cliente_Seleccionado = 0
            If Cliente_Seleccionado > Servidor.Clientes.Count - 1 Then Cliente_Seleccionado = 0

            If Servidor.Clientes.IndexOf(Cliente) = Cliente_Seleccionado Then
                If TClientes.TabPages.Count = 0 Then
                    Dim NMensaje(1) As String
                    NMensaje(0) = "   K-WAYD " + Version + "   " : NMensaje(1) = "" : Reset_MensajeTimer(NMensaje)
                    'Serial_Enviar("   K-WAYD " + Version + "   ")
                Else
                    TClientes_SelectedIndexChanged(Nothing, Nothing)
                End If
            End If
        End If
    End Sub

#End Region

#Region " Recibido "

    Private Sub Servidor_Recibido(Cliente As ClienteInfo, Mensaje As String) Handles Servidor.Recibido
        If InvokeRequired Then : Invoke(Sub() Servidor_Recibido(Cliente, Mensaje)) : Else
            If Mensaje = "Update Cliente" Then
                TClientes.TabPages.Add(Cliente.Nombre)
                TClientes.TabPages(TClientes.TabPages.Count - 1).BackColor = Color.FromArgb(50, 50, 50)
                Fondo.Visible = False

                Dim NewTexto As New RichTextBox() With {
    .Name = "Texto" + (TClientes.TabPages.Count - 1).ToString,
    .Size = New Size(TClientes.TabPages(TClientes.TabPages.Count - 1).Width - 4, 300),
    .Location = New Point(2, TClientes.TabPages(TClientes.TabPages.Count - 1).Height - 303),
    .ForeColor = Color.LightGray,
    .BackColor = Color.FromArgb(50, 50, 50),
    .HideSelection = True,
    .WordWrap = False,
    .[ReadOnly] = True,
    .ScrollBars = ScrollBars.Vertical,
    .ShortcutsEnabled = True,
    .Multiline = True,
    .ContextMenuStrip = TMenu,
    .Text = Now.ToString("dd/MM/yyyy HH:mm:ss   -   ") + "Conectado" + vbCrLf,
    .Anchor = AnchorStyles.Bottom + AnchorStyles.Left + AnchorStyles.Right
}
                LogMensaje(Cliente.Nombre, Now.ToString("dd/MM/yyyy HH:mm:ss   -   ") + "Conectado" + vbCrLf)
                AddHandler NewTexto.TextChanged, AddressOf Texto_TextChanged
                AddHandler NewTexto.LinkClicked, AddressOf Texto_LinkClicked
                TClientes.TabPages(TClientes.TabPages.Count - 1).Controls.Add(NewTexto)

                Dim Imagen As New PictureBox() With {
    .Name = "Imagen" + (TClientes.TabPages.Count - 1).ToString,
    .Size = New Size(TClientes.TabPages(TClientes.TabPages.Count - 1).Width - 4, TClientes.TabPages(TClientes.TabPages.Count - 1).Height - 307),
    .Location = New Point(2, 2),
    .SizeMode = PictureBoxSizeMode.StretchImage,
    .ContextMenuStrip = TMenu,
    .BorderStyle = BorderStyle.FixedSingle,
    .Anchor = AnchorStyles.Bottom + AnchorStyles.Top + AnchorStyles.Left + AnchorStyles.Right
}
                AddHandler Imagen.DoubleClick, AddressOf Imagen_DoubleClick
                TClientes.TabPages(TClientes.TabPages.Count - 1).Controls.Add(Imagen)
                TClientes.TabPages(TClientes.TabPages.Count - 1).Controls(1).BringToFront()

                'TClientes.SelectedTab = TClientes.TabPages(TClientes.TabPages.Count - 1)
                TClientes.Visible = True : LClientes.Text = "Clientes: " + TClientes.TabPages.Count.ToString
            Else
                Select Case Mensaje.Split("|")(0)
                    Case "RESPUESTA"
                        Dim Icono As MsgBoxStyle
                        Select Case Mensaje.Split("|")(1)
                            Case "Information" : Icono = MsgBoxStyle.Information
                            Case "Question" : Icono = MsgBoxStyle.Question
                            Case "Exclamation" : Icono = MsgBoxStyle.Exclamation
                            Case "Error" : Icono = MsgBoxStyle.Critical
                        End Select

                        Dim Respuesta As MsgBoxStyle
                        Select Case Mensaje.Split("|")(2)
                            Case "Aceptar" : Respuesta = MsgBoxStyle.OkOnly
                            Case "Aceptar/Cancelar" : Respuesta = MsgBoxStyle.OkCancel
                            Case "Reintentar/Cancelar" : Respuesta = MsgBoxStyle.RetryCancel
                            Case "Si/No" : Respuesta = MsgBoxStyle.YesNo
                            Case "Si/No/Cancelar" : Respuesta = MsgBoxStyle.YesNoCancel
                        End Select
                        Dim Titulo As String = Mensaje.Split("|")(3)
                        Dim MensajeEnviado As String = Mensaje.Split("|")(4)
                        Dim ResultadoFinal As MsgBoxResult : [Enum].TryParse(Mensaje.Split("|")(5), ResultadoFinal)

                        For Each TCliente As TabPage In TClientes.TabPages
                            If TCliente.Text = Cliente.Nombre Then
                                Dim Texto As RichTextBox = DirectCast(TCliente.Controls(1), RichTextBox)

                                Texto.Text += Now.ToString("dd/MM/yyyy HH:mm:ss   -   [") + Cliente.Nombre + "] ha respondido:   """ + ResultadoFinal.ToString + """ al mensaje enviado" + vbCrLf
                                LogMensaje(Cliente.Nombre, Now.ToString("dd/MM/yyyy HH:mm:ss   -   [") + Cliente.Nombre + "] ha respondido:   """ + ResultadoFinal.ToString + """ al mensaje enviado" + vbCrLf)
                                Exit For
                            End If
                        Next

                        TopMost = True : Activate() : Focus()
                        MsgBox(MensajeEnviado + vbCrLf + vbCrLf + vbCrLf + Cliente.Nombre + " ha respondido:   """ + ResultadoFinal.ToString + """", Icono + MsgBoxStyle.OkOnly, Titulo)
                        TopMost = False
                    Case Else
                        Mensaje = RemoveDiacritics(Mensaje)
                        Dim NMensaje(1) As String : NMensaje(0) = "" : NMensaje(1) = ""
                        Dim NuevoMensaje As String = Mensaje
                        For Each TCliente As TabPage In TClientes.TabPages
                            If TCliente.Text = Cliente.Nombre Then
                                Dim Texto As RichTextBox = DirectCast(TCliente.Controls(1), RichTextBox)

                                Dim Proceso As String = Mensaje.Split("|")(0)
                                Dim WindowTitle As String = Mensaje.Split("|")(1).Replace("@-@", "|")
                                NuevoMensaje = Procesar_Mensaje(Proceso)

                                If NuevoMensaje = "explorer" Then
                                    If WindowTitle.ToLower.Trim = "" Or WindowTitle.ToLower.Trim = "program data" Then
                                        NuevoMensaje = "Escritorio"
                                        NMensaje(0) = "Escritorio"
                                    Else
                                        NuevoMensaje = "Explorando...           " + WindowTitle
                                        NMensaje(0) = "Explorando..." : NMensaje(1) = WindowTitle
                                    End If
                                End If
                                If NuevoMensaje = "Chateando en Telegram" Then
                                    NuevoMensaje += "  (" + WindowTitle + ")"
                                    NuevoMensaje = NuevoMensaje.Replace("  (Telegram)", "")
                                    NMensaje(0) = "Telegram"
                                    If WindowTitle.ToLower <> "telegram" Then NMensaje(1) = "Chateando con " + WindowTitle
                                End If
                                If NuevoMensaje = "chrome" Or NuevoMensaje = "brave" Then
                                    Dim Found As Boolean
                                    If WindowTitle.Replace(" - Google Chrome", "").Replace(" - Brave", "") = ("YouTube") Then
                                        NuevoMensaje = "Viendo Youtube"
                                        NMensaje(0) = "Viendo Youtube"
                                        Found = True
                                    End If
                                    If WindowTitle.ToLower.Contains(" - youtube") Then
                                        WindowTitle = EliminarParentesis(WindowTitle.Replace(" - YouTube", "").Replace(" - Google Chrome", "").Replace(" - Brave", ""))
                                        NuevoMensaje = "Viendo Youtube      " + WindowTitle + GetURL(WindowTitle) : Found = True
                                        NMensaje(0) = "Viendo Youtube" : NMensaje(1) = WindowTitle : Found = True
                                    End If
                                    If WindowTitle.ToLower.Contains("pluto tv") Then NuevoMensaje = "Viendo Pluto TV" : NMensaje(0) = "Viendo Pluto TV" : Found = True
                                    If WindowTitle.ToLower.Contains("facebook") Then NuevoMensaje = "En Facebook" : NMensaje(0) = "En Facebook" : Found = True
                                    If WindowTitle.ToLower.Contains("prime video") Then NuevoMensaje = "Viendo una peli en Prime" : NMensaje(0) = "Viendo una peli en Prime" : Found = True
                                    If WindowTitle.ToLower.Contains("cuarto milenio") Then NuevoMensaje = "Viendo Cuarto Milenio" : NMensaje(0) = "Viendo Cuarto Milenio" : Found = True
                                    If WindowTitle.ToLower.Contains("amazon") Then NuevoMensaje = "Comprando en Amazon" : NMensaje(0) = "Comprando en Amazon" : Found = True
                                    If WindowTitle.ToLower.Contains("atresplayer") Then NuevoMensaje = "Viendo la TV" : NMensaje(0) = "Viendo la TV" : Found = True
                                    If WindowTitle.ToLower.Contains("pornhub") Then NuevoMensaje = "Viendo porno" : NMensaje(0) = "Viendo porno" : Found = True
                                    If WindowTitle.ToLower.Contains("youporn") Then NuevoMensaje = "Viendo porno" : NMensaje(0) = "Viendo porno" : Found = True
                                    If WindowTitle.ToLower.Contains("xvideos") Then NuevoMensaje = "Viendo porno" : NMensaje(0) = "Viendo porno" : Found = True
                                    If WindowTitle.ToLower.Contains("xhamster") Then NuevoMensaje = "Viendo porno" : NMensaje(0) = "Viendo porno" : Found = True
                                    If Found = False Then
                                        NuevoMensaje = "En Internet              " + WindowTitle.Replace(" - Google Chrome", "").Replace(" - Brave", "")
                                        NMensaje(0) = "En Internet" : NMensaje(1) = WindowTitle.Replace(" - Google Chrome", "").Replace(" - Brave", "")
                                    End If
                                End If
                                If NuevoMensaje = "Default" Then NuevoMensaje = Proceso : NMensaje(0) = Proceso
                                If NuevoMensaje.EndsWith("https://www.youtube.com/watch?v=") Then
                                    NuevoMensaje = "Viendo Youtube"
                                    NMensaje(0) = "Viendo Youtube" : NMensaje(1) = ""
                                End If

                                Texto.Text += Now.ToString("dd/MM/yyyy HH:mm:ss   -   ") + NuevoMensaje.Trim + vbCrLf
                                LogMensaje(Cliente.Nombre, Now.ToString("dd/MM/yyyy HH:mm:ss   -   ") + NuevoMensaje.Trim + vbCrLf)
                                Exit For
                            End If
                        Next

                        If Servidor.Clientes.Count = 0 Then Cliente_Seleccionado = -1
                        If Servidor.Clientes.Count = 1 Then Cliente_Seleccionado = 0
                        If Cliente_Seleccionado > Servidor.Clientes.Count - 1 Then Cliente_Seleccionado = 0

                        'If Servidor.Clientes.IndexOf(Cliente) = Cliente_Seleccionado Then Serial_Enviar(NuevoMensaje.Replace("Viendo Youtube      ", "Viendo Youtube   ").Replace("En Internet              ", "En Internet   ").Replace("Explorando...           ", "Explorando...   "))
                        If Servidor.Clientes.IndexOf(Cliente) = Cliente_Seleccionado Then Reset_MensajeTimer(NMensaje)
                End Select
            End If
        End If
    End Sub

    Private Function EliminarParentesis(Mensaje As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(Mensaje, "^\(\d+\)\s", "")
    End Function

#Region " Procesar Mensaje "

    Private Function Procesar_Mensaje(Proceso As String) As String
        Dim Mensaje As String

        Select Case Proceso.ToLower()
            Case "picasaphotoviewer"
                Mensaje = "Viendo imagenes"
            Case "explorer"
                Mensaje = "explorer"
            Case "winword"
                Mensaje = "Escribiendo en Word"
            Case "chrome"
                Mensaje = "chrome"
            Case "brave"
                Mensaje = "brave"
            Case "calc"
                Mensaje = "Calculando operaciones"
            Case "notepad"
                Mensaje = "Editando en Bloc de notas"
            Case "excel"
                Mensaje = "Trabajando en Excel"
            Case "powerpnt"
                Mensaje = "Creando presentación en PowerPoint"
            Case "access"
                Mensaje = "Trabajando en Access"
            Case "mspub"
                Mensaje = "Diseñando en Publisher"
            Case "mspaint"
                Mensaje = "Dibujando en Paint"
            Case "outlook"
                Mensaje = "Revisando correos en Outlook"
            Case "onenote"
                Mensaje = "Tomando notas en OneNote"
            Case "firefox"
                Mensaje = "Navegando con Firefox"
            Case "edge"
                Mensaje = "Usando Microsoft Edge"
            Case "skype"
                Mensaje = "Hablando por Skype"
            Case "discord"
                Mensaje = "Chateando en Discord"
            Case "spotify"
                Mensaje = "Escuchando música en Spotify"
            Case "vlc"
                Mensaje = "Viendo una pelicula"
            Case "photoshop"
                Mensaje = "Editando en Photoshop"
            Case "acrobat"
                Mensaje = "Leyendo PDF en Acrobat"
            Case "zoom"
                Mensaje = "En una reunión en Zoom"
            Case "slack"
                Mensaje = "Chateando en Slack"
            Case "visualstudio"
                Mensaje = "Programando en Visual Studio"
            Case "notion"
                Mensaje = "Trabajando en Notion"
            Case "wordpad"
                Mensaje = "Editando en WordPad"
            Case "winamp"
                Mensaje = "Reproduciendo música en Winamp"
            Case "telegram"
                Mensaje = "Chateando en Telegram"
            Case "whatsapp"
                Mensaje = "Mensajes en WhatsApp"
            Case "zoomexe"
                Mensaje = "En una reunión en Zoom"
            Case "audacity"
                Mensaje = "Editando audio en Audacity"
            Case "gimp"
                Mensaje = "Editando imágenes en GIMP"
            Case "vscode"
                Mensaje = "Programando en Visual Studio Code"
            Case "firefoxexe"
                Mensaje = "Navegando con Firefox"
            Case "opera"
                Mensaje = "Navegando con Opera"
            Case "sketchup"
                Mensaje = "Modelando en SketchUp"
            Case "autoCAD"
                Mensaje = "Diseñando en AutoCAD"
            Case "spotifyexe"
                Mensaje = "Escuchando música en Spotify"
            Case "viber"
                Mensaje = "Chateando en Viber"
            Case "slackexe"
                Mensaje = "Chateando en Slack"
            Case "eclipse"
                Mensaje = "Programando en Eclipse"
            Case "pycharm"
                Mensaje = "Programando en PyCharm"
            Case "atom"
                Mensaje = "Programando en Atom"
            Case "sublime_text"
                Mensaje = "Programando en Sublime Text"
            Case "adobe_reader"
                Mensaje = "Leyendo PDF en Adobe Reader"
            Case "audacityexe"
                Mensaje = "Editando audio en Audacity"
            Case "sketch"
                Mensaje = "Diseñando en Sketch"
            Case "maya"
                Mensaje = "Modelando en Maya"
            Case "slackdesktop"
                Mensaje = "Chateando en Slack"
            Case "telegramdesktop"
                Mensaje = "Chateando en Telegram"
            Case "messenger"
                Mensaje = "Mensajes en Messenger"
            Case "zoommeetings"
                Mensaje = "En una reunión en Zoom"
            Case "obsstudio"
                Mensaje = "Transmitiendo en OBS Studio"
            Case "devenv"
                Mensaje = "Programando"
            Case Else
                Mensaje = "Default"
        End Select

        Return Mensaje
    End Function

    Private Function RemoveDiacritics(Input As String) As String
        Dim NormalizedString As String = Input.Normalize(System.Text.NormalizationForm.FormD)
        Dim StringBuilder As New Text.StringBuilder()

        For Each c As Char In NormalizedString
            If Globalization.CharUnicodeInfo.GetUnicodeCategory(c) <> Globalization.UnicodeCategory.NonSpacingMark Then StringBuilder.Append(c)
        Next

        Return StringBuilder.ToString()
    End Function

#End Region

#End Region

#Region " Captura "

    Private Sub Servidor_Captura(Cliente As ClienteInfo, Imagen As Image) Handles Servidor.Captura
        If InvokeRequired Then : Invoke(Sub() Servidor_Captura(Cliente, Imagen)) : Else

            For Each TCliente As TabPage In TClientes.TabPages
                If TCliente.Text = Cliente.Nombre Then
                    Dim PImagen As PictureBox = DirectCast(TCliente.Controls(0), PictureBox)
                    PImagen.Image = Imagen ': PImagen.Visible = True
                    If LogActivity = True Then
                        If IO.Directory.Exists("Activity\" + TCliente.Text + "\Capturas") = False Then IO.Directory.CreateDirectory("Activity\" + TCliente.Text + "\Capturas")
                        Dim Imagen2 As New Bitmap(PImagen.Image)
                        Imagen2.Save("Activity\" + TCliente.Text + "\Capturas\" + Now.ToString("yyyy-MM-dd HH.mm.ss - ") + TCliente.Text + ".jpg", Imaging.ImageFormat.Jpeg)
                    End If
                    Exit For
                End If
            Next
        End If
    End Sub

#End Region

#End Region

#Region " Serial "

#Region " Abrir "

    Public Sub Serial_Open()
        Try : Serial.Open()
            Threading.Thread.Sleep(200)
            If TClientes.TabPages.Count = 0 Then
                Dim NMensaje(1) As String
                NMensaje(0) = "   K-WAYD " + Version + "   " : NMensaje(1) = "" : Reset_MensajeTimer(NMensaje)
                'Serial_Enviar("   K-WAYD " + Version + "   ")
            Else
                TClientes_SelectedIndexChanged(Nothing, Nothing)
            End If
        Catch : End Try
    End Sub


    Private Sub Serial_ErrorReceived(sender As Object, e As IO.Ports.SerialErrorReceivedEventArgs)
        If e.EventType = IO.Ports.SerialError.Frame OrElse e.EventType = IO.Ports.SerialError.Overrun Then

        End If
    End Sub

#End Region

#Region " Enviar "

    Public Sub Serial_Enviar(Mensaje As String)
        If Arduino = False And Mensaje <> "   K-WAYD " + Version + "   " Then Exit Sub
        If Serial.IsOpen = False Then Serial_Open()
        If Serial.IsOpen = False Then Exit Sub
        If Serial.IsOpen = True Then Serial.Write(Mensaje + vbCrLf)
    End Sub

    Private Sub LArduino_Click(sender As Object, e As EventArgs) Handles LArduino.Click
        Arduino = Not Arduino
        If Arduino = True Then
            If Serial.IsOpen = False Then Serial_Open()
        Else
            Dim NMensaje(1) As String
            If Serial.IsOpen = True Then NMensaje(0) = "   K-WAYD " + Version + "   " : NMensaje(1) = "" : Reset_MensajeTimer(NMensaje) : Serial.Close()
        End If
        Opciones_Guardar()
    End Sub

#End Region

#Region " Recibir "

    Dim Contador As Integer = 0
    Private Sub Serial_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs)
        If InvokeRequired Then : Invoke(Sub() Serial_DataReceived(sender, e)) : Else
            Serial_Data += Serial.ReadExisting()
            If Serial_Data.Contains("Next") Then
                Contador = 10
                If Servidor.Clientes.Count = 0 Then Cliente_Seleccionado = -1
                If Servidor.Clientes.Count = 1 Then Cliente_Seleccionado = 0
                If Servidor.Clientes.Count > 1 Then Cliente_Seleccionado += 1
                If Cliente_Seleccionado > Servidor.Clientes.Count - 1 Then Cliente_Seleccionado = 0

                Dim NMensaje(1) As String
                NMensaje(0) = Servidor.Clientes(Cliente_Seleccionado).Nombre : NMensaje(1) = "" : Reset_MensajeTimer(NMensaje)
                'Serial_Enviar(Servidor.Clientes(Cliente_Seleccionado).Nombre)
                Serial_Data = ""
                Contador = 0
                Do Until Contador >= 10 : Threading.Thread.Sleep(100) : Contador += 1 : Loop
                If Servidor.Clientes.Count = 0 Then
                    NMensaje(0) = "   K-WAYD " + Version + "   " : NMensaje(1) = "" : Reset_MensajeTimer(NMensaje)
                    'Serial_Enviar("   K-WAYD " + Version + "   ")
                Else
                    LastMensaje(Servidor.Clientes(Cliente_Seleccionado).Nombre)
                End If
            End If
        End If
    End Sub

    Private Sub LastMensaje(Nombre As String)
        Dim NMensaje(1) As String : NMensaje(0) = "" : NMensaje(1) = ""
        For Cuenta = 0 To Servidor.Clientes.Count - 1
            If Servidor.Clientes(Cuenta).Nombre = Nombre Then
                Dim NuevoMensaje As String = Servidor.Clientes(Cuenta).LastMensaje

                If NuevoMensaje = "" Then
                    NMensaje(0) = "   K-WAYD " + Version + "   " : NMensaje(1) = "" : Reset_MensajeTimer(NMensaje)
                    'Serial_Enviar("   K-WAYD " + Version + "   ")
                    Exit Sub
                End If

                NuevoMensaje = RemoveDiacritics(NuevoMensaje)

                Dim Proceso As String = NuevoMensaje.Split("|")(0)
                Dim WindowTitle As String = NuevoMensaje.Split("|")(1).Replace("@-@", "|")
                NuevoMensaje = Procesar_Mensaje(Proceso)

                If NuevoMensaje = "explorer" Then
                    If WindowTitle.ToLower.Trim = "" Or WindowTitle.ToLower.Trim = "program data" Then
                        NuevoMensaje = "Escritorio"
                        NMensaje(0) = "Escritorio"
                    Else
                        NuevoMensaje = "Explorando...           " + WindowTitle
                        NMensaje(0) = "Explorando..." : NMensaje(1) = WindowTitle
                    End If
                End If
                If NuevoMensaje = "Chateando en Telegram" Then
                    NuevoMensaje += "  (" + WindowTitle + ")"
                    NuevoMensaje = NuevoMensaje.Replace("  (Telegram)", "")
                    NMensaje(0) = "Telegram"
                    If WindowTitle.ToLower <> "telegram" Then NMensaje(1) = "Chateando con " + WindowTitle
                End If
                If NuevoMensaje = "chrome" Or NuevoMensaje = "brave" Then
                    Dim Found As Boolean
                    If WindowTitle.Replace(" - Google Chrome", "").Replace(" - Brave", "") = ("YouTube") Then
                        NuevoMensaje = "Viendo Youtube"
                        NMensaje(0) = "Viendo Youtube"
                        Found = True
                    End If
                    If WindowTitle.ToLower.Contains(" - youtube") Then
                        WindowTitle = EliminarParentesis(WindowTitle.Replace(" - YouTube", "").Replace(" - Google Chrome", "").Replace(" - Brave", ""))
                        NuevoMensaje = "Viendo Youtube      " + WindowTitle + GetURL(WindowTitle) : Found = True
                        NMensaje(0) = "Viendo Youtube" : NMensaje(1) = WindowTitle : Found = True
                    End If
                    If WindowTitle.ToLower.Contains("pluto tv") Then NuevoMensaje = "Viendo Pluto TV" : NMensaje(0) = "Viendo Pluto TV" : Found = True
                    If WindowTitle.ToLower.Contains("facebook") Then NuevoMensaje = "En Facebook" : NMensaje(0) = "En Facebook" : Found = True
                    If WindowTitle.ToLower.Contains("prime video") Then NuevoMensaje = "Viendo una peli en Prime" : NMensaje(0) = "Viendo una peli en Prime" : Found = True
                    If WindowTitle.ToLower.Contains("cuarto milenio") Then NuevoMensaje = "Viendo Cuarto Milenio" : NMensaje(0) = "Viendo Cuarto Milenio" : Found = True
                    If WindowTitle.ToLower.Contains("amazon") Then NuevoMensaje = "Comprando en Amazon" : NMensaje(0) = "Comprando en Amazon" : Found = True
                    If WindowTitle.ToLower.Contains("atresplayer") Then NuevoMensaje = "Viendo la TV" : NMensaje(0) = "Viendo la TV" : Found = True
                    If WindowTitle.ToLower.Contains("pornhub") Then NuevoMensaje = "Viendo porno" : NMensaje(0) = "Viendo porno" : Found = True
                    If WindowTitle.ToLower.Contains("youporn") Then NuevoMensaje = "Viendo porno" : NMensaje(0) = "Viendo porno" : Found = True
                    If WindowTitle.ToLower.Contains("xvideos") Then NuevoMensaje = "Viendo porno" : NMensaje(0) = "Viendo porno" : Found = True
                    If WindowTitle.ToLower.Contains("xhamster") Then NuevoMensaje = "Viendo porno" : NMensaje(0) = "Viendo porno" : Found = True
                    If Found = False Then
                        NuevoMensaje = "En Internet              " + WindowTitle.Replace(" - Google Chrome", "").Replace(" - Brave", "")
                        NMensaje(0) = "En Internet" : NMensaje(1) = WindowTitle.Replace(" - Google Chrome", "").Replace(" - Brave", "")
                    End If
                End If
                If NuevoMensaje = "Default" Then NuevoMensaje = Proceso : NMensaje(0) = Proceso
                If NuevoMensaje.EndsWith("https://www.youtube.com/watch?v=") Then
                    NuevoMensaje = "Viendo Youtube"
                    NMensaje(0) = "Viendo Youtube" : NMensaje(1) = ""
                End If

                'Serial_Enviar(NuevoMensaje.Replace("Viendo Youtube      ", "Viendo Youtube   ").Replace("En Internet              ", "En Internet   ").Replace("Explorando...           ", "Explorando...   "))
                Reset_MensajeTimer(NMensaje)
            End If
        Next
    End Sub

#End Region

#End Region

    Dim MensajeTimer As New Timer With {.Enabled = True, .Interval = 400}
    Dim EnviarMensaje(1) As String
    Dim IndiceDesplazamiento(1), DireccionDesplazamiento(1) As Integer
    Dim EnviarMensajeLast(1) As String
    Dim Esperar As Boolean
    Dim Espera As Integer
    Dim TiempoEspera = 4

    Public Sub Reset_MensajeTimer(Mensaje() As String)
        MensajeTimer.Stop()
        IndiceDesplazamiento(0) = 0 : DireccionDesplazamiento(0) = 0
        IndiceDesplazamiento(1) = 0 : DireccionDesplazamiento(1) = 0
        EnviarMensaje = Mensaje
        Esperar = True : Esperar = 0
        MensajeTimer.Start()
    End Sub

    Private Sub MensajeTimer_Tick(sender As Object, e As EventArgs)
        If EnviarMensaje Is Nothing Then Exit Sub
        If Esperar = False AndAlso Espera < TiempoEspera Then Espera += 1 : Exit Sub

        Dim AnchoLinea As Integer = 16
        Dim Mensaje(1) As String

        If EnviarMensaje(0) IsNot Nothing Then
            If EnviarMensaje(0).Length <= AnchoLinea Then
                Mensaje(0) = New String(" "c, Math.Max((AnchoLinea - EnviarMensaje(0).Length) \ 2, 0)) & EnviarMensaje(0)
            Else
                If DireccionDesplazamiento(0) = 0 Then
                    Try
                        Mensaje(0) = EnviarMensaje(0).Substring(IndiceDesplazamiento(0), AnchoLinea)
                    Catch : End Try
                    IndiceDesplazamiento(0) += 1
                    If Esperar = True Then Esperar = False
                    If EnviarMensaje(0).Substring(IndiceDesplazamiento(0)).Length < AnchoLinea Then IndiceDesplazamiento(0) -= 1 : DireccionDesplazamiento(0) = 1 : Espera = 0
                ElseIf DireccionDesplazamiento(0) = 1 Then
                    Try
                        Mensaje(0) = EnviarMensaje(0).Substring(IndiceDesplazamiento(0), AnchoLinea)
                    Catch : End Try
                    IndiceDesplazamiento(0) -= 1
                    If IndiceDesplazamiento(0) = 0 Then DireccionDesplazamiento(0) = 0 : Espera = 0 : Esperar = True
                End If
            End If
        End If

        If EnviarMensaje(1) IsNot Nothing Then
            If EnviarMensaje(1).Length <= AnchoLinea Then
                Mensaje(1) = New String(" "c, Math.Max((AnchoLinea - EnviarMensaje(1).Length) \ 2, 0)) & EnviarMensaje(1)
            Else
                If DireccionDesplazamiento(1) = 0 Then
                    Try
                        Mensaje(1) = EnviarMensaje(1).Substring(IndiceDesplazamiento(1), AnchoLinea)
                    Catch : End Try
                    IndiceDesplazamiento(1) += 1
                    If Esperar = True Then Esperar = False
                    If EnviarMensaje(1).Substring(IndiceDesplazamiento(1)).Length < AnchoLinea Then IndiceDesplazamiento(1) -= 1 : DireccionDesplazamiento(1) = 1 : Espera = 0
                ElseIf DireccionDesplazamiento(1) = 1 Then
                    Try
                        Mensaje(1) = EnviarMensaje(1).Substring(IndiceDesplazamiento(1), AnchoLinea)
                    Catch : End Try
                    IndiceDesplazamiento(1) -= 1
                    If IndiceDesplazamiento(1) = 0 Then DireccionDesplazamiento(1) = 0 : Espera = -0 : Esperar = True
                End If
            End If
        End If

        Serial_Enviar(Mensaje(0) + "||" + Mensaje(1))
        'Text = Mensaje(0) + "||" + Mensaje(1)
        End Sub

        End Class

#End Region

#Region " Registro "

    Public Class Registro

#Region " SubKeys (carpetas) "

    ' Devuelve un array con los SubKeys (carpetas) de la ruta del registro indicada
    Public Shared Function GetRegKeyNames(SubKey As String) As String()
        Try : My.Computer.Registry.CurrentUser.CreateSubKey("Software\" + SubKey) : Using Reg = My.Computer.Registry.CurrentUser.OpenSubKey("Software\" + SubKey, True)
                Return Reg.GetSubKeyNames : End Using
        Catch : Return New String(0) {} : End Try
    End Function

    ' Elimina el SubKey (carpeta) de la ruta del registro indicada
    Public Shared Sub DelReg(SubKey As String)
        Try : My.Computer.Registry.CurrentUser.DeleteSubKeyTree("Software\" + SubKey, False)
        Catch : End Try
    End Sub

#End Region

#Region " ValueNames (archivos) "

    ' Devuelve un array con los ValueNames (archivos) de la ruta del registro indicada
    Public Shared Function GetRegValueNames(SubKey As String) As String()
        Try : My.Computer.Registry.CurrentUser.CreateSubKey("Software\" + SubKey) : Using Reg = My.Computer.Registry.CurrentUser.OpenSubKey("Software\" + SubKey, True)
                Return Reg.GetValueNames : End Using
        Catch : Return New String(0) {} : End Try
    End Function

    ' Devuelve el valor del ValueName (archivo) de la ruta del registro indicada
    Public Shared Function GetRegKey(SubKey As String, Name As String, Optional DefaultValue As String = "") As String
        Try : My.Computer.Registry.CurrentUser.CreateSubKey("Software\" + SubKey) : Using Reg = My.Computer.Registry.CurrentUser.OpenSubKey("Software\" + SubKey, True)
                If Reg.GetValue(Name) = "" Then Reg.SetValue(Name, DefaultValue)
                Return Reg.GetValue(Name) : End Using
        Catch : Return "" : End Try
    End Function

    ' Establece el valor del ValueName (archivo) de la ruta del registro indicada
    Public Shared Sub SetRegKey(SubKey As String, Name As String, Value As String)
        Try : My.Computer.Registry.CurrentUser.CreateSubKey("Software\" + SubKey) : Using Reg = My.Computer.Registry.CurrentUser.OpenSubKey("Software\" + SubKey, True)
                Reg.SetValue(Name, Value) : End Using
        Catch : End Try
    End Sub

    ' Elimina el ValueName (archivo) de la ruta del registro indicada
    Public Shared Sub DelRegKey(SubKey As String, Name As String)
        Try : My.Computer.Registry.CurrentUser.CreateSubKey("Software\" + SubKey) : Using Reg = My.Computer.Registry.CurrentUser.OpenSubKey("Software\" + SubKey, True)
                Reg.DeleteValue(Name, False) : End Using
        Catch : End Try
    End Sub

#End Region

#Region " Iniciar con Windows "

    ' Registra la aplicacion para que se inicie con Windows
    Public Shared Sub Registrar(Optional Nombre As String = "", Optional Ruta As String = "")
        If Nombre = "" Then Nombre = Application.ProductName
        If Ruta = "" Then Ruta = Application.ExecutablePath
        Try : Using Reg = My.Computer.Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True) : Reg.SetValue(Nombre, Ruta) : End Using
        Catch : End Try
    End Sub

    'Elimina del registro la aplicacion para que no se inicie con Windows
    Public Shared Sub DesRegistrar(Optional Nombre As String = "")
        If Nombre = "" Then Nombre = Application.ProductName
        If My.Computer.Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True).GetValue(Nombre) Is Nothing Then Exit Sub
        Try : Using Reg = My.Computer.Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True) : Reg.DeleteValue(Nombre) : End Using
        Catch : End Try
    End Sub

#End Region

End Class

#End Region

#Region " Servidor "

Public Class Servidor

#Region " Variables "

#Region " Eventos "

    Public Event Conectado(Cliente As ClienteInfo)
    Public Event Desconectado(Cliente As ClienteInfo)
    Public Event Recibido(Cliente As ClienteInfo, Mensaje As String)
    Public Event Captura(Cliente As ClienteInfo, Imagen As Image)

#End Region

    Private Listener As Net.Sockets.TcpListener

    Public Clientes As New List(Of ClienteInfo)()
    Public IPAddress As Net.IPAddress
    Public Port As Integer

#End Region

#Region " Metodos "

#Region " Escuchar "

    Public Sub Escuchar(DireccionIP As Net.IPAddress, Puerto As Integer)
        Try
            IPAddress = DireccionIP : Port = Puerto
            Listener = New Net.Sockets.TcpListener(DireccionIP, Puerto) : Listener.Start()
            Dim AcceptThread As New Threading.Thread(AddressOf Aceptar_Clientes) : AcceptThread.Start()
        Catch : End Try
    End Sub

#End Region

#Region " Enviar "

    Public Sub Enviar(Cliente As ClienteInfo, Mensaje As String)
        Try
            Dim Stream As Net.Sockets.NetworkStream = Cliente.Cliente.GetStream()
            Dim Data As Byte() = Text.Encoding.ASCII.GetBytes(Mensaje)
            Stream.Write(Data, 0, Data.Length) : Stream.Flush()
        Catch : End Try
    End Sub

    Public Sub Enviar_Todos(Mensaje As String)
        For Each Cliente As ClienteInfo In Clientes : Enviar(Cliente, Mensaje) : Next
    End Sub

#End Region

#Region " Desconectar "

    Public Sub Desconectar(Cliente As ClienteInfo)
        Try
            Cliente.Cliente.Close()
            Clientes.Remove(Cliente)

            RaiseEvent Desconectado(Cliente)
        Catch : End Try
    End Sub

    Public Sub Desconectar_Todos()
        For Each Cliente As ClienteInfo In Clientes.ToList() : Desconectar(Cliente) : Next
    End Sub

#End Region

#Region " Cerrar "

    Public Sub Cerrar()
        Try
            Desconectar_Todos()
            Listener.Stop()
        Catch : End Try
    End Sub

#End Region

#End Region

#Region " Funciones "

#Region " Aceptar "

    Private Sub Aceptar_Clientes()
        While True
            Try
                Dim ClienteTcp As Net.Sockets.TcpClient = Listener.AcceptTcpClient()
                Dim ClienteInfo As New ClienteInfo() With {.Cliente = ClienteTcp, .Cliente_Data = ClienteTcp.Client.RemoteEndPoint}
                Clientes.Add(ClienteInfo)

                RaiseEvent Conectado(ClienteInfo)

                Dim ClientThread As New Threading.Thread(AddressOf Handle_Client) : ClientThread.Start(ClienteInfo)
            Catch : Exit While : End Try
        End While
    End Sub

#End Region

#Region " Recibir "

    Private Sub Handle_Client(ClienteInfo As Object)
        Dim Cliente As ClienteInfo = DirectCast(ClienteInfo, ClienteInfo)
        Dim Stream As Net.Sockets.NetworkStream = Cliente.Cliente.GetStream()
        Dim Buffer As Byte() = New Byte(1023) {}

        Try
            While True
                Dim LongitudTipoDatoBytes(3) As Byte
                Dim BytesRead As Integer = Stream.Read(LongitudTipoDatoBytes, 0, 4)
                If BytesRead = 0 Then Exit While

                Dim LongitudTipoDato As Integer = BitConverter.ToInt32(LongitudTipoDatoBytes, 0)

                Dim TipoDatoBytes(LongitudTipoDato - 1) As Byte
                Stream.Read(TipoDatoBytes, 0, LongitudTipoDato)
                Dim TipoDato As String = Text.Encoding.UTF8.GetString(TipoDatoBytes)

                Dim LongitudBytes(3) As Byte
                Stream.Read(LongitudBytes, 0, 4)
                Dim Longitud As Integer = BitConverter.ToInt32(LongitudBytes, 0)

                If TipoDato = "Texto" Then
                    Dim ContenidoBytes(Longitud - 1) As Byte
                    Stream.Read(ContenidoBytes, 0, Longitud)
                    Dim Mensaje As String = Text.Encoding.UTF8.GetString(ContenidoBytes)
                    If Mensaje.Contains("NOMBREEQUIPO|") Then
                        Dim Contador As Integer = 0
                        For Each NCliente As ClienteInfo In Clientes
                            If NCliente.Nombre.ToLower = Mensaje.Split("|")(1).ToLower Then Contador += 1
                        Next

                        If Contador > 0 Then Cliente.Nombre = Mensaje.Split("|")(1) + " (" + Contador.ToString + ")" Else Cliente.Nombre = Mensaje.Split("|")(1)
                        Cliente.AutoCaptura = CBool(Mensaje.Split("|")(2))
                        Cliente.Interval = CInt(Mensaje.Split("|")(3))
                        RaiseEvent Recibido(Cliente, "Update Cliente")
                    Else
                        Cliente.LastMensaje = Mensaje
                        RaiseEvent Recibido(Cliente, Mensaje)
                    End If
                ElseIf TipoDato = "Imagen" Then
                    Dim ImagenBytes(Longitud - 1) As Byte
                    Dim totalBytesRead As Integer = 0

                    ' Lee la imagen de manera incremental en bloques
                    While totalBytesRead < Longitud
                        BytesRead = Stream.Read(ImagenBytes, totalBytesRead, Longitud - totalBytesRead)
                        If BytesRead = 0 Then Exit While
                        totalBytesRead += BytesRead
                    End While

                    ' Crea la imagen a partir de los bytes
                    Using StreamImage As New IO.MemoryStream(ImagenBytes)
                        RaiseEvent Captura(Cliente, Image.FromStream(StreamImage))
                    End Using
                End If
            End While
        Catch : Finally
            Cliente.Cliente.Close()
            Clientes.Remove(Cliente)
            RaiseEvent Desconectado(Cliente)
        End Try
    End Sub

#End Region

#End Region

End Class

#Region " Cliente Info "

Public Class ClienteInfo

    Public Nombre As String = "Cliente"
    Public Cliente As Net.Sockets.TcpClient
    Public Cliente_Data As Net.IPEndPoint
    Public LastMensaje As String = ""
    Public AutoCaptura As Boolean = False
    Public Interval As Integer = 5000

End Class

#End Region

#End Region

#Region " Youtube "

#Region " Search "

Public Class YouTube


    Private APIKey As String = "AIzaSyAdTL7Yi1N_fYEOTvm1swQLVkJkN6K_Qb0"

    Public Function Search(ResultList As String) As JsVideo
        Try : Dim Results As JsVideo = New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of JsVideo)(New Net.WebClient() With {.Encoding = Text.Encoding.UTF8}.DownloadString("https://www.googleapis.com/youtube/v3/search?part=snippet&maxResults=5&q=" + Net.WebUtility.UrlEncode(ResultList) + "&fields=items(id%2FvideoId%2Csnippet(channelId%2CchannelTitle%2Cdescription%2Cthumbnails%2Fdefault%2Furl%2Ctitle))%2CnextPageToken%2CpageInfo%2CprevPageToken&key=" + APIKey))
            'For Each Result In Results.Items
            '    Result.ID.VideoID = "https://www.youtube.com/v/" + Result.ID.VideoID
            'Next : Return Results
            Return Results
        Catch : End Try : Return Nothing
    End Function

End Class

#End Region

#Region " Clases "

Public Class JsVideo
    Public Property Items As New List(Of JsItems)
End Class

Public Class JsItems
    Public Property ID As JsID
    Public Property Snippet As JsSnippet
End Class

Public Class JsID
    Public Property VideoID As String
End Class

Public Class JsSnippet
    Public Property ChannelID As String
    Public Property Title As String
    Public Property Description As String
    Public Property ChannelTitle As String
End Class

#End Region

#End Region

#End Region
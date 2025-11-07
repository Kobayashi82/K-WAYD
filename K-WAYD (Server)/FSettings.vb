
#Region " FSettings "

Public Class FSettings

#Region " Eventos del Formulario "

    Private Sub FSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TDireccionIP.Text = FMenu.IPAddress.ToString
        TPuerto.Text = FMenu.Puerto.ToString
        CArduino.Checked = FMenu.Arduino
        TPuertoCOM.Text = FMenu.Serial.PortName.Replace("COM", "")
        TBaudRate.Text = FMenu.Serial.BaudRate.ToString
        CGuardarRegistro.Checked = FMenu.LogActivity
        CIniciarWindow.Checked = FMenu.IniciarWindows
    End Sub

#Region " Controls "

    Private Sub THidden_KeyPress(sender As Object, e As KeyPressEventArgs) Handles THidden.KeyPress
        If Asc(e.KeyChar) = 13 Then e.Handled = True
    End Sub

#End Region

#Region " GetLocalIP "

    Public Function GetLocalIP() As Net.IPAddress
        Dim LocalIPv4 As Net.IPAddress = Nothing
        For Each IP As Net.IPAddress In Net.Dns.GetHostAddresses(Net.Dns.GetHostName())
            If IP.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then LocalIPv4 = IP : Exit For
        Next
        If LocalIPv4 IsNot Nothing Then Return LocalIPv4 Else Return Nothing
    End Function

#End Region

#End Region

#Region " Servidor "

    Private Sub TDireccionIP_Keypress(sender As Object, e As KeyPressEventArgs) Handles TDireccionIP.KeyPress
        If Asc(e.KeyChar) = 13 Then e.Handled = True : THidden.Focus()
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(8) AndAlso e.KeyChar <> ChrW(46) AndAlso e.KeyChar <> "."c Then e.Handled = True
    End Sub

    Private Sub TDireccionIP_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TDireccionIP.Validating
        If TDireccionIP.Text = "" Then TDireccionIP.Text = GetLocalIP.ToString
        Try
            If IsValidIPAddress(TDireccionIP.Text.Trim) = False Then TDireccionIP.Text = GetLocalIP.ToString
            FMenu.IPAddress = Net.IPAddress.Parse(TDireccionIP.Text)
            FMenu.Opciones_Guardar()
            FMenu.Servidor.Cerrar()
            FMenu.Servidor.Escuchar(FMenu.IPAddress, FMenu.Puerto)
        Catch ex As Exception
            MsgBox(ex.Message)
            TDireccionIP.Text = GetLocalIP.ToString
            FMenu.IPAddress = Net.IPAddress.Parse(TDireccionIP.Text)
            FMenu.Opciones_Guardar()
            FMenu.Servidor.Cerrar()
            FMenu.Servidor.Escuchar(FMenu.IPAddress, FMenu.Puerto)
        End Try
    End Sub

    Private Function IsValidIPAddress(IPAddress As String) As Boolean
        Dim Parts() As String = IPAddress.Split("."c)
        If Parts.Length <> 4 Then Return False
        For Each Part As String In Parts
            If Not Integer.TryParse(Part, Nothing) OrElse Not (Integer.Parse(Part) >= 0 AndAlso Integer.Parse(Part) <= 255) Then Return False
        Next : Return True
    End Function

    Private Sub TPuerto_Keypress(sender As Object, e As KeyPressEventArgs) Handles TPuerto.KeyPress
        If Asc(e.KeyChar) = 13 Then e.Handled = True : THidden.Focus()
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(8) AndAlso e.KeyChar <> ChrW(46) Then e.Handled = True
    End Sub

    Private Sub TPuerto_LostFocus(sender As Object, e As EventArgs) Handles TPuerto.LostFocus
        If TPuerto.Text.Trim = "" Then TPuerto.Text = FMenu.Puerto.ToString
        If CInt(TPuerto.Text) < 1000 Then TPuerto.Text = "1000"
        If CInt(TPuerto.Text) > 99999 Then TPuerto.Text = "99999"
        If FMenu.Puerto <> CInt(TPuerto.Text.Trim) Then FMenu.Puerto = CInt(TPuerto.Text.Trim) : FMenu.Servidor.Escuchar(FMenu.IPAddress, FMenu.Puerto)
        FMenu.Opciones_Guardar()
    End Sub

#End Region

#Region " Arduino "

    Private Sub CArduino_CheckedChanged(sender As Object, e As EventArgs) Handles CArduino.CheckedChanged
        FMenu.Arduino = CArduino.Checked
        If FMenu.Arduino = True Then
            If FMenu.Serial.IsOpen = False Then FMenu.Serial_Open()
        Else
            Dim NMensaje(1) As String
            If FMenu.Serial.IsOpen = True Then NMensaje(0) = "   K-WAYD " + FMenu.Version + "   " : NMensaje(1) = "" : FMenu.Reset_MensajeTimer(NMensaje) : FMenu.Serial.Close()
            'FMenu.Serial_Enviar("   K-WAYD " + FMenu.Version + "   ")
        End If
        FMenu.Opciones_Guardar()
    End Sub

    Private Sub TPuertoCOM_Keypress(sender As Object, e As KeyPressEventArgs) Handles TPuertoCOM.KeyPress
        If Asc(e.KeyChar) = 13 Then e.Handled = True : THidden.Focus()
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(8) AndAlso e.KeyChar <> ChrW(46) Then e.Handled = True
    End Sub

    Private Sub TPuertoCOM_LostFocus(sender As Object, e As EventArgs) Handles TPuertoCOM.LostFocus
        If TPuertoCOM.Text.Trim = "" Then TPuertoCOM.Text = FMenu.Serial.PortName.Replace("COM", "")
        If CInt(TBaudRate.Text) < 1 Then TBaudRate.Text = "1"
        If CInt(TBaudRate.Text) > 99 Then TBaudRate.Text = "99"
        If FMenu.Serial.IsOpen = True Then FMenu.Serial.Close()
        FMenu.Serial.PortName = "COM" + TPuertoCOM.Text
        If FMenu.Arduino = True Then FMenu.Serial_Open()
        FMenu.Opciones_Guardar()
    End Sub

    Private Sub TBaudRate_Keypress(sender As Object, e As KeyPressEventArgs) Handles TBaudRate.KeyPress
        If Asc(e.KeyChar) = 13 Then e.Handled = True : THidden.Focus()
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(8) AndAlso e.KeyChar <> ChrW(46) Then e.Handled = True
    End Sub

    Private Sub TBaudRate_LostFocus(sender As Object, e As EventArgs) Handles TBaudRate.LostFocus
        If TBaudRate.Text.Trim = "" Then TBaudRate.Text = FMenu.Serial.BaudRate
        If CInt(TBaudRate.Text) < 150 Then TBaudRate.Text = "150"
        If CInt(TBaudRate.Text) > 500000 Then TBaudRate.Text = "500000"
        FMenu.Serial.BaudRate = TBaudRate.Text
        FMenu.Opciones_Guardar()
    End Sub

#End Region

#Region " Varios "

    Private Sub CGuardarRegistro_CheckedChanged(sender As Object, e As EventArgs) Handles CGuardarRegistro.CheckedChanged
        FMenu.LogActivity = CGuardarRegistro.Checked
        FMenu.Opciones_Guardar()
    End Sub

    Private Sub CIniciarWindow_CheckedChanged(sender As Object, e As EventArgs) Handles CIniciarWindow.CheckedChanged
        If CIniciarWindow.Checked = True Then Registro.Registrar() Else Registro.DesRegistrar()
        FMenu.IniciarWindows = CIniciarWindow.Checked
        FMenu.Opciones_Guardar()
    End Sub

#End Region

End Class

#End Region

#Region " FSettings "

Public Class FSettings

#Region " Eventos del Formulario "

    Private Sub FSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TDireccionIP.Text = FMenu.DireccionIP
        TPuerto.Text = FMenu.Puerto.ToString
        CIniciarWindow.Checked = FMenu.IniciarWindows
    End Sub

#End Region

#Region " Cliente "

    Private Sub TDireccionIP_Keypress(sender As Object, e As KeyPressEventArgs) Handles TDireccionIP.KeyPress
        If Asc(e.KeyChar) = 13 Then e.Handled = True : THidden.Focus()
    End Sub

    Private Sub TDireccionIP_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TDireccionIP.Validating
        Dim OriginalIP As String = FMenu.DireccionIP
        If TDireccionIP.Text = "" Then TDireccionIP.Text = FMenu.DireccionIP
        Try
            If IsValidIPAddress(TDireccionIP.Text.Trim) = True Then
                FMenu.DireccionIP = TDireccionIP.Text.Trim
                FMenu.IPAddress = Net.IPAddress.Parse(TDireccionIP.Text)
                FMenu.Opciones_Guardar()
            Else
                Dim HostAddresses() As Net.IPAddress = Net.Dns.GetHostAddresses(TDireccionIP.Text.Trim)

                If HostAddresses.Length > 0 Then
                    FMenu.DireccionIP = TDireccionIP.Text.Trim
                    FMenu.IPAddress = HostAddresses(0)
                    FMenu.Opciones_Guardar()
                Else
                    TDireccionIP.Text = FMenu.DireccionIP
                    FMenu.DireccionIP = TDireccionIP.Text.Trim
                    FMenu.IPAddress = Net.IPAddress.Parse(TDireccionIP.Text)
                    FMenu.Opciones_Guardar()
                End If

            End If
        Catch
            TDireccionIP.Text = FMenu.DireccionIP
            FMenu.DireccionIP = TDireccionIP.Text.Trim
            FMenu.IPAddress = Net.IPAddress.Parse(TDireccionIP.Text)
            FMenu.Opciones_Guardar()
        End Try
        If TDireccionIP.Text.ToLower <> OriginalIP.ToLower Then FMenu.Cliente.Desconectar() : FMenu.CTimer.Interval = 1   'FMenu.Cliente.Conectar(FMenu.IPAddress, FMenu.Puerto)
    End Sub

    Public Function IsValidIPAddress(IPAddress As String) As Boolean
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
        If FMenu.Puerto <> CInt(TPuerto.Text.Trim) Then
            FMenu.Puerto = CInt(TPuerto.Text.Trim) : FMenu.Opciones_Guardar()
            FMenu.Cliente.Desconectar() : FMenu.CTimer.Interval = 1 'FMenu.Cliente.Conectar(FMenu.IPAddress, FMenu.Puerto)
        End If
    End Sub

#End Region

#Region " Varios "

    Private Sub CIniciarWindow_CheckedChanged(sender As Object, e As EventArgs) Handles CIniciarWindow.CheckedChanged
        If CIniciarWindow.Checked = True Then Registro.Registrar() Else Registro.DesRegistrar()
        FMenu.IniciarWindows = CIniciarWindow.Checked : FMenu.Opciones_Guardar()
    End Sub

#End Region

End Class

#End Region
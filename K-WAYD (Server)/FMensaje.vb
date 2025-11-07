
#Region " FMensaje "

Public Class FMensaje

#Region " Variables "

    Public Icono As String = ""
    Public Respuesta As String = ""

    Public Cancelado As Boolean = True

#End Region

#Region " Eventos del Formulario "

    Private Sub FMensaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PIcono1.Image = SystemIcons.Information.ToBitmap()
        PIcono2.Image = SystemIcons.Question.ToBitmap()
        PIcono3.Image = SystemIcons.Exclamation.ToBitmap()
        PIcono4.Image = SystemIcons.Error.ToBitmap()

        PIcono1.Tag = "Information"
        PIcono2.Tag = "Question"
        PIcono3.Tag = "Exclamation"
        PIcono4.Tag = "Error"

        R1.Tag = "Aceptar"
        R2.Tag = "Aceptar/Cancelar"
        R3.Tag = "Reintentar/Cancelar"
        R4.Tag = "Si/No"
        R5.Tag = "Si/No/Cancelar"
    End Sub

    Private Sub FMensaje_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TTitulo.Focus()
    End Sub

#Region " Controls "

    Private Sub THidden_KeyPress(sender As Object, e As KeyPressEventArgs) Handles THidden.KeyPress
        If Asc(e.KeyChar) = 13 Then e.Handled = True
    End Sub

    Private Sub Gtitulo_Enter(sender As Object, e As EventArgs) Handles Gtitulo.Click
        TTitulo.Focus()
    End Sub

    Private Sub GMensaje_Enter(sender As Object, e As EventArgs) Handles GMensaje.Click
        Texto.Focus()
    End Sub

#Region " PIconos "

    Private Sub PIconos_Click(sender As Object, e As EventArgs) Handles PIcono1.Click, PIcono2.Click, PIcono3.Click, PIcono4.Click
        PIcono1.BorderStyle = BorderStyle.None
        PIcono2.BorderStyle = BorderStyle.None
        PIcono3.BorderStyle = BorderStyle.None
        PIcono4.BorderStyle = BorderStyle.None
        PIcono1.Size = New Size(20, 20) : PIcono1.Location = New Point(20, 24)
        PIcono2.Size = New Size(20, 20) : PIcono2.Location = New Point(66, 24)
        PIcono3.Size = New Size(20, 20) : PIcono3.Location = New Point(20, 56)
        PIcono4.Size = New Size(20, 20) : PIcono4.Location = New Point(66, 56)
        sender.BorderStyle = BorderStyle.FixedSingle
        sender.Size = New Size(28, 28) : sender.Location = New Point(sender.Left - 4, sender.Top - 4)
        Icono = sender.Tag
    End Sub

#End Region

#Region " Respuestas "

    Private Sub Respuestas_CheckedChanged(sender As Object, e As EventArgs) Handles R1.CheckedChanged, R2.CheckedChanged, R3.CheckedChanged, R4.CheckedChanged, R5.CheckedChanged
        If sender.Checked = True Then Respuesta = sender.Tag
    End Sub

#End Region

#Region " Reset "

    Public Sub Reset()
        Cancelado = True
        TTitulo.Text = ""
        Texto.Text = ""
        Icono = "Information"
        Respuesta = "Aceptar"
        PIcono1.BorderStyle = BorderStyle.FixedSingle
        PIcono2.BorderStyle = BorderStyle.None
        PIcono3.BorderStyle = BorderStyle.None
        PIcono4.BorderStyle = BorderStyle.None
        PIcono1.Size = New Size(28, 28) : PIcono1.Location = New Point(16, 20)
        PIcono2.Size = New Size(20, 20) : PIcono2.Location = New Point(66, 24)
        PIcono3.Size = New Size(20, 20) : PIcono3.Location = New Point(20, 56)
        PIcono4.Size = New Size(20, 20) : PIcono4.Location = New Point(66, 56)
        R1.Checked = True
    End Sub

#End Region

#End Region

#End Region

#Region " Enviar "

    Private Sub BEnviar_Click(sender As Object, e As EventArgs) Handles BEnviar.Click
        If Texto.Text.Trim = "" Then Cancelado = True : Close() : Exit Sub
        TTitulo.Text = TTitulo.Text.Replace("|", "-")
        Texto.Text = Texto.Text.Replace("|", "-")
        Cancelado = False : Close()
    End Sub

#End Region

#Region " Cancelar "

    Private Sub BCancelar_Click(sender As Object, e As EventArgs) Handles BCancelar.Click
        Close()
    End Sub

#End Region

End Class

#End Region

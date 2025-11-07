
#Region " FPlaySound "

Public Class FPlaySound

#Region " Variables "

    Dim Sonido_PlayTimer As New Timer With {.Interval = 100, .Enabled = False}

    Public Cancelado As Boolean = True

#End Region

#Region " Eventos del Formulario "

    Private Sub FPlaySound_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler Sonido_PlayTimer.Tick, AddressOf Sonido_PlayTimer_Tick
        CSonido.Items.Clear() : CSonido.Items.AddRange(New List(Of String) From {"Alarma 1", "Alarma 2", "Background", "Balloon", "Battery Critical", "Battery Low", "Calendar", "Camera", "Chimes", "Chord", "Connection", "Control", "Default", "Ding", "Email", "Error", "Exclamation", "Foreground", "Generic", "Hardware Fail", "Harware Insert", "Hardware Remove", "LogOff", "LogOn", "Message", "Messaging", "Notification 1", "Notification 2", "Notification 3", "Print", "Recycle", "Ring 1", "Ring 2", "Ring 3", "Shutdown", "Stop", "Tada", "Unlock"}.ToArray)
        CSonido.SelectedIndex = 0
    End Sub

#Region " Controls "

    Private Sub THidden_KeyPress(sender As Object, e As KeyPressEventArgs) Handles THidden.KeyPress
        If Asc(e.KeyChar) = 13 Then e.Handled = True
    End Sub

#End Region

#End Region

#Region " Enviar "

    Private Sub BEnviar_Click(sender As Object, e As EventArgs) Handles BEnviar.Click
        Cancelado = False : Close()
    End Sub

#End Region

#Region " Cancelar "

    Private Sub BCancelar_Click(sender As Object, e As EventArgs) Handles BCancelar.Click
        Close()
    End Sub

#End Region

#Region " Sonido "

    Private Sub Sonido_PlayTimer_Tick()
        If CSonido.DroppedDown = True Then FMenu.Play_Sound(CSonido.SelectedItem.Trim) : Sonido_PlayTimer.Stop()
    End Sub

    Private Sub CSonido_DropDown(sender As Object, e As EventArgs) Handles CSonido.DropDown
        CSonido.MaxDropDownItems = CSonido.Items.Count
    End Sub

    Private Sub SelectedIndexChanged(sender As Object, e As EventArgs) Handles CSonido.SelectedIndexChanged
        THidden.Focus()
    End Sub

    Private Sub CSonido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CSonido.KeyPress
        If Asc(e.KeyChar) = 13 Then THidden.Focus() : e.Handled = True
    End Sub

    Private Sub CSonido_ItemHover(Index As Integer) Handles CSonido.ItemHover
        Sonido_PlayTimer.Stop() : Sonido_PlayTimer.Start()
    End Sub

#End Region

End Class

#End Region

#Region " ComboBox "

Class NSComboBox : Inherits ComboBox

#Region " Variables "

#Region " Declarations "

    <Runtime.InteropServices.DllImport("user32.dll")> Public Shared Function GetWindowRect(hWnd As IntPtr, <Runtime.InteropServices.Out> ByRef lpRect As RECT) As Boolean
    End Function
    <Runtime.InteropServices.DllImport("user32.dll")> Public Shared Function GetWindowDC(hWnd As IntPtr) As IntPtr
    End Function
    <Runtime.InteropServices.DllImport("user32.dll")> Public Shared Function ReleaseDC(hWnd As IntPtr, hDC As IntPtr) As Integer
    End Function
    <Runtime.InteropServices.DllImport("user32.dll")> Public Shared Function SetFocus(hWnd As IntPtr) As IntPtr
    End Function
    <Runtime.InteropServices.DllImport("user32.dll")> Public Shared Function GetComboBoxInfo(hWnd As IntPtr, ByRef pcbi As COMBOBOXINFO) As Boolean
    End Function
    <Runtime.InteropServices.DllImport("gdi32.dll")> Public Shared Function ExcludeClipRect(hdc As IntPtr, nLeftRect As Integer, nTopRect As Integer, nRightRect As Integer, nBottomRect As Integer) As Integer
    End Function
    <Runtime.InteropServices.DllImport("gdi32.dll")> Public Shared Function CreatePen(enPenStyle As PenStyles, nWidth As Integer, crColor As Integer) As IntPtr
    End Function
    <Runtime.InteropServices.DllImport("gdi32.dll")> Public Shared Function SelectObject(hdc As IntPtr, hObject As IntPtr) As IntPtr
    End Function
    <Runtime.InteropServices.DllImport("gdi32.dll")> Public Shared Function DeleteObject(hObject As IntPtr) As Boolean
    End Function
    <Runtime.InteropServices.DllImport("gdi32.dll")> Public Shared Sub Rectangle(hdc As IntPtr, X1 As Integer, Y1 As Integer, X2 As Integer, Y2 As Integer)
    End Sub

#End Region

#Region " Structures "

    <Serializable, Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential)> Public Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    <Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential)> Public Structure COMBOBOXINFO
        Public cbSize As Int32
        Public rcItem As RECT
        Public rcButton As RECT
        Public buttonState As ComboBoxButtonState
        Public hwndCombo As IntPtr
        Public hwndEdit As IntPtr
        Public hwndList As IntPtr
    End Structure

    Public Enum PenStyles
        PS_SOLID = 0
        PS_DASH = 1
        PS_DOT = 2
        PS_DASHDOT = 3
        PS_DASHDOTDOT = 4
    End Enum

    Public Enum ComboBoxButtonState
        STATE_SYSTEM_NONE = 0
        STATE_SYSTEM_INVISIBLE = &H8000
        STATE_SYSTEM_PRESSED = &H8
    End Enum

#End Region

#Region " Mouse States "

    Public Enum STImageMode
        Normal = 0
        Fill = 1
    End Enum

    Public Enum MouseState As Byte
        None = 0
        Hover = 1
        Down = 2
        Block = 3
    End Enum

    Public State As MouseState = MouseState.None

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        If e.Button = Windows.Forms.MouseButtons.Left Then State = MouseState.Hover : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If e.Button = Windows.Forms.MouseButtons.Left Then State = MouseState.Down : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        'If e.X > Width - 23 Then State = MouseState.Hover Else State = MouseState.None : Invalidate()
        State = MouseState.Hover : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        State = NSComboBox.MouseState.None : Invalidate() : MyBase.OnMouseLeave(e)
    End Sub

    Protected Overrides Sub OnDropDown(e As EventArgs)
        _dropDownCheck.Start()
        MyBase.OnDropDown(e)
    End Sub

    Protected Overrides Sub OnDropDownClosed(e As EventArgs)
        MyBase.OnDropDownClosed(e)
        _dropDownCheck.Stop()
        State = MouseState.None : Invalidate()
    End Sub

    Public Event ItemHover(index As Integer)
    Private _dropDownCheck As New Timer

#End Region

#Region " Properties "

#Region " Colors "

#Region " BaseColor "

    Private _BackColor As Color = Color.Empty
    <ComponentModel.Browsable(False)> Overrides Property BackColor As Color
        Get
            Return _BackColor
        End Get
        Set(value As Color)
            _BackColor = value
            Invalidate()
        End Set
    End Property

    Private _BaseColor1 As Color = Color.FromArgb(35, 35, 35)
    Property BaseColor1 As Color
        Get
            Return _BaseColor1
        End Get
        Set(value As Color)
            _BaseColor1 = value
            Invalidate()
        End Set
    End Property

    Private _BaseColor2 As Color = Color.FromArgb(50, 50, 50)
    Property BaseColor2 As Color
        Get
            Return _BaseColor2
        End Get
        Set(value As Color)
            _BaseColor2 = value
            Invalidate()
        End Set
    End Property

#End Region

#Region " ForeColor "

    Private _ForeColor As Color = Color.Empty
    <ComponentModel.Browsable(False)> Overrides Property ForeColor As Color
        Get
            Return _ForeColor
        End Get
        Set(value As Color)
            _ForeColor = value
            Invalidate()
        End Set
    End Property

    Private _ForeColor1 As Color = Color.White
    Property ForeColor1 As Color
        Get
            Return _ForeColor1
        End Get
        Set(value As Color)
            _ForeColor1 = value
            Invalidate()
        End Set
    End Property

    Private _ForeColor2 As Color = Color.Black
    Property ForeColor2 As Color
        Get
            Return _ForeColor2
        End Get
        Set(value As Color)
            _ForeColor2 = value
            Invalidate()
        End Set
    End Property

    Private _HoverColor1 As Color = Color.White
    Property HoverColor1 As Color
        Get
            Return _HoverColor1
        End Get
        Set(value As Color)
            _HoverColor1 = value
            Invalidate()
        End Set
    End Property

    Private _HoverColor2 As Color = Color.Black
    Property HoverColor2 As Color
        Get
            Return _HoverColor2
        End Get
        Set(value As Color)
            _HoverColor2 = value
            Invalidate()
        End Set
    End Property
#End Region

#Region " ItemColor "

    Private _ItemColor As Color = Color.FromArgb(102, 102, 102)
    Property ItemColor As Color
        Get
            Return _ItemColor
        End Get
        Set(value As Color)
            _ItemColor = value
            Invalidate()
        End Set
    End Property

    Private _ItemBackColor As Color = Color.FromArgb(55, 55, 55)
    Property ItemBackColor As Color
        Get
            Return _ItemBackColor
        End Get
        Set(value As Color)
            _ItemBackColor = value
            Invalidate()
        End Set
    End Property

    Private _ItemFont As Font = Font
    Property ItemFont As Font
        Get
            Return _ItemFont
        End Get
        Set(value As Font)
            _ItemFont = value
            Invalidate()
        End Set
    End Property

    Private _ItemHoverColor As Color = Color.FromArgb(102, 102, 102)
    Property ItemHoverColor As Color
        Get
            Return _ItemHoverColor
        End Get
        Set(value As Color)
            _ItemHoverColor = value
            Invalidate()
        End Set
    End Property

    Private _ItemHoverBackColor As Color = Color.FromArgb(65, 65, 65)
    Property ItemHoverBackColor As Color
        Get
            Return _ItemHoverBackColor
        End Get
        Set(value As Color)
            _ItemHoverBackColor = value
            Invalidate()
        End Set
    End Property

    Private _ItemHoverFont As Font = Font
    Property ItemHoverFont As Font
        Get
            Return _ItemHoverFont
        End Get
        Set(value As Font)
            _ItemHoverFont = value
            Invalidate()
        End Set
    End Property

    Private _ItemSelectedColor As Color = Color.FromArgb(102, 102, 102)
    Property ItemSelectedColor As Color
        Get
            Return _ItemSelectedColor
        End Get
        Set(value As Color)
            _ItemSelectedColor = value
            Invalidate()
        End Set
    End Property

    Private _ItemSelectedBackColor As Color = Color.Blue
    Property ItemSelectedBackColor As Color
        Get
            Return _ItemSelectedBackColor
        End Get
        Set(value As Color)
            _ItemSelectedBackColor = value
            Invalidate()
        End Set
    End Property

    Private _ItemSelectedFont As Font = Font
    Property ItemSelectedFont As Font
        Get
            Return _ItemSelectedFont
        End Get
        Set(value As Font)
            _ItemSelectedFont = value
            Invalidate()
        End Set
    End Property

#End Region

#Region " BorderColor "

    Private _BorderColor1 As Color = Color.FromArgb(35, 35, 35)
    Property BorderColor1 As Color
        Get
            Return _BorderColor1
        End Get
        Set(value As Color)
            _BorderColor1 = value
            Invalidate()
        End Set
    End Property

    Private _BorderColor2 As Color = Color.FromArgb(65, 65, 65)
    Property BorderColor2 As Color
        Get
            Return _BorderColor2
        End Get
        Set(value As Color)
            _BorderColor2 = value
            Invalidate()
        End Set
    End Property

    Private _BorderColor3 As Color = Color.Empty
    Property BorderColor3 As Color
        Get
            Return _BorderColor3
        End Get
        Set(value As Color)
            _BorderColor3 = value
            Invalidate()
        End Set
    End Property

    Private _DropdownBorderColor As Color = Color.Gray
    Property DropdownBorderColor As Color
        Get
            Return _DropdownBorderColor
        End Get
        Set(value As Color)
            _DropdownBorderColor = value
            Invalidate()
        End Set
    End Property

#End Region

#Region " Gradient "

    Private _GradientColor1 As Color = Color.FromArgb(60, 60, 60)
    Property GradientColor1 As Color
        Get
            Return _GradientColor1
        End Get
        Set(value As Color)
            _GradientColor1 = value
            Invalidate()
        End Set
    End Property

    Private _GradientColor2 As Color = Color.FromArgb(55, 55, 55)
    Property GradientColor2 As Color
        Get
            Return _GradientColor2
        End Get
        Set(value As Color)
            _GradientColor2 = value
            Invalidate()
        End Set
    End Property

    Private _GradientAngle As Integer = 90
    Property GradientAngle As Integer
        Get
            Return _GradientAngle
        End Get
        Set(value As Integer)
            If value > 360 Then value = 360
            If value < 1 Then value = 1
            _GradientAngle = value
            Invalidate()
        End Set
    End Property

    Private _GradientTransparency As Integer = 0
    Property GradientTransparency As Integer
        Get
            Return _GradientTransparency
        End Get
        Set(value As Integer)
            If value > 255 Then value = 255
            If value < 0 Then value = 0
            _GradientTransparency = value
            Invalidate()
        End Set
    End Property

#End Region

#End Region

#Region " Images "

    Private _BackgroundImageLayout As ImageLayout
    <ComponentModel.Browsable(False)> Overrides Property BackgroundImageLayout As ImageLayout
        Get
            Return _BackgroundImageLayout
        End Get
        Set(value As ImageLayout)
            _BackgroundImageLayout = value
        End Set
    End Property

    Private _BackgroundImage As Image
    <ComponentModel.Browsable(False)> Overrides Property BackgroundImage As Image
        Get
            Return _BackgroundImage
        End Get
        Set(value As Image)
            _BackgroundImage = value
        End Set
    End Property

    Private _Image As Image = Nothing
    Property Image As Image
        Get
            Return _Image
        End Get
        Set(value As Image)
            _Image = value
            Invalidate()
        End Set
    End Property

    Private _ImageSize As New Size(19, 17)
    Property ImageSize As Size
        Get
            Return _ImageSize
        End Get
        Set(value As Size)
            _ImageSize = value
            Invalidate()
        End Set
    End Property

    Private _ImageAlign As HorizontalAlignment = HorizontalAlignment.Center
    Property ImageAlign() As HorizontalAlignment
        Get
            Return _ImageAlign
        End Get
        Set(value As HorizontalAlignment)
            _ImageAlign = value
            Invalidate()
        End Set
    End Property

    Private _ImageMode As STImageMode = STImageMode.Normal
    Property ImageMode() As STImageMode
        Get
            Return _ImageMode
        End Get
        Set(value As STImageMode)
            _ImageMode = value
            Invalidate()
        End Set
    End Property

#End Region

#Region " Others "

    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Center
    Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(value As HorizontalAlignment)
            _TextAlign = value
            Invalidate()
        End Set
    End Property

    Private _ItemTextAlign As HorizontalAlignment = HorizontalAlignment.Left
    Property ItemTextAlign() As HorizontalAlignment
        Get
            Return _ItemTextAlign
        End Get
        Set(value As HorizontalAlignment)
            _ItemTextAlign = value
            Invalidate()
        End Set
    End Property

    Private _DoubleText As Boolean = False
    Property DoubleText As Boolean
        Get
            Return _DoubleText
        End Get
        Set(value As Boolean)
            _DoubleText = value
            Invalidate()
        End Set
    End Property

    Private _Rounded As Integer = 7
    Property Rounded As Integer
        Get
            Return _Rounded
        End Get
        Set(value As Integer)
            If value > 20 Then value = 20
            If value < 1 Then value = 1
            _Rounded = value
            Invalidate()
        End Set
    End Property

    Private _JustButton As Boolean = False
    Property JustButton As Boolean
        Get
            Return _JustButton
        End Get
        Set(value As Boolean)
            _JustButton = value
            Invalidate()
        End Set
    End Property

#End Region

#End Region

#End Region

#Region " Constructor "

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.SupportsTransparentBackColor, True) : SetStyle(DirectCast(139286, ControlStyles), True) : SetStyle(ControlStyles.Selectable, False)
        DoubleBuffered = True : DrawMode = DrawMode.OwnerDrawFixed : DropDownStyle = ComboBoxStyle.DropDownList
        AddHandler _dropDownCheck.Tick, AddressOf DropDownCheck_Tick
        Font = New Font("Segoe UI", 7)
        TextBitmap = New Bitmap(1, 1)
        TextGraphics = Graphics.FromImage(TextBitmap)
    End Sub

#End Region

#Region " Paint "

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim G As Graphics = e.Graphics : G.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit : G.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias : G.Clear(Parent.BackColor)

        'Dim GP1 As Drawing2D.GraphicsPath = CreateRound(0, 0, Width - 1, Height - 1, Rounded)
        'Dim GP2 As Drawing2D.GraphicsPath = CreateRound(1, 1, Width - 3, Height - 3, Rounded)
        Dim GP1 As New Drawing2D.GraphicsPath : GP1.AddRectangle(New RectangleF(0, 0, Width - 1, Height - 1))
        Dim GP2 As New Drawing2D.GraphicsPath : GP2.AddRectangle(New RectangleF(1, 1, Width - 3, Height - 3))
        Dim GB1 As New Drawing2D.LinearGradientBrush(ClientRectangle, GradientColor1, GradientColor2, GradientAngle)
        G.SetClip(GP1) : G.FillRectangle(GB1, ClientRectangle) : G.ResetClip()

        Select Case State
            Case MouseState.None
                G.DrawPath(New Pen(BorderColor1), GP1)
                G.DrawPath(New Pen(BorderColor2), GP2)

                G.DrawLine(New Pen(BorderColor1), Width - 22, 0, Width - 22, Height)
                G.DrawLine(New Pen(BorderColor2), Width - 23, 1, Width - 23, Height - 2)
                G.DrawLine(New Pen(BorderColor2), Width - 21, 1, Width - 21, Height - 2)

                If DoubleText = True Then
                    G.DrawLine(New Pen(ForeColor2, 2.0F), Width - 15, 10, Width - 11, 13)
                    G.DrawLine(New Pen(ForeColor2, 2.0F), Width - 7, 10, Width - 11, 13)
                    G.DrawLine(New Pen(ForeColor2), Width - 11, 13, Width - 11, 14)
                    If JustButton = False Then DrawText(G, Text, Font, ForeColor2, 1, 1, , , -23)
                End If

                G.DrawLine(New Pen(ForeColor1, 2.0F), Width - 16, 9, Width - 12, 12)
                G.DrawLine(New Pen(ForeColor1, 2.0F), Width - 8, 9, Width - 12, 12)
                G.DrawLine(New Pen(ForeColor1), Width - 12, 12, Width - 12, 13)

                If JustButton = False Then DrawText(G, Text, Font, ForeColor1, , , , , -23)
            Case MouseState.Hover
                G.DrawPath(New Pen(BorderColor3), GP1)
                G.DrawPath(New Pen(BorderColor2), GP2)

                G.DrawLine(New Pen(BorderColor3), Width - 22, 0, Width - 22, Height)
                G.DrawLine(New Pen(BorderColor2), Width - 23, 1, Width - 23, Height - 2)
                G.DrawLine(New Pen(BorderColor2), Width - 21, 1, Width - 21, Height - 2)

                If DoubleText = True Then
                    G.DrawLine(New Pen(HoverColor2, 2.0F), Width - 15, 10, Width - 11, 13)
                    G.DrawLine(New Pen(HoverColor2, 2.0F), Width - 7, 10, Width - 11, 13)
                    G.DrawLine(New Pen(HoverColor2), Width - 11, 13, Width - 11, 14)
                    If JustButton = False Then DrawText(G, Text, Font, ForeColor2, 1, 1, , , -23)
                End If

                G.DrawLine(New Pen(HoverColor1, 2.0F), Width - 16, 9, Width - 12, 12)
                G.DrawLine(New Pen(HoverColor1, 2.0F), Width - 8, 9, Width - 12, 12)
                G.DrawLine(New Pen(HoverColor1), Width - 12, 12, Width - 12, 13)
                If JustButton = False Then DrawText(G, Text, Font, ForeColor1, , , , , -23)
            Case MouseState.Down
                G.DrawPath(New Pen(BorderColor3), GP1)
                G.DrawPath(New Pen(BorderColor2), GP2)

                G.DrawLine(New Pen(BorderColor3), Width - 22, 0, Width - 22, Height)
                G.DrawLine(New Pen(BorderColor2), Width - 23, 1, Width - 23, Height - 2)
                G.DrawLine(New Pen(BorderColor2), Width - 21, 1, Width - 21, Height - 2)

                If DoubleText = True Then
                    G.DrawLine(New Pen(HoverColor2, 2.0F), Width - 15, 10, Width - 11, 13)
                    G.DrawLine(New Pen(HoverColor2, 2.0F), Width - 7, 10, Width - 11, 13)
                    G.DrawLine(New Pen(HoverColor2), Width - 11, 13, Width - 11, 14)
                    If JustButton = False Then DrawText(G, Text, Font, ForeColor2, 1, 1, , , -23)
                End If

                G.DrawLine(New Pen(HoverColor1, 2.0F), Width - 16, 9, Width - 12, 12)
                G.DrawLine(New Pen(HoverColor1, 2.0F), Width - 8, 9, Width - 12, 12)
                G.DrawLine(New Pen(HoverColor1), Width - 12, 12, Width - 12, 13)
                If JustButton = False Then DrawText(G, Text, Font, ForeColor1, , , , , -23)
        End Select

    End Sub

    Private Function SetFontSize(ByRef Control As Object, Fuente As Font, MaxFontSize As Single, Optional MinFontSize As Single = 6) As Font
        Dim TextSize As Integer = MaxFontSize
        Do Until TextRenderer.MeasureText(Control, New Font(Fuente.Name, TextSize, FontStyle.Regular)).Width < Width Or TextSize <= MinFontSize : TextSize -= 1 : Loop
        If TextSize < MinFontSize Then TextSize = MinFontSize
        Return New Font(Fuente.Name, TextSize, FontStyle.Regular)
    End Function

    Private Function SetTextItem(TempText As String, Fuente As Font) As String
        Dim SZ2 = TextRenderer.MeasureText(TempText, ItemSelectedFont)
        If SZ2.Width > Width + 41 Then
Repite:     SZ2 = TextRenderer.MeasureText(TempText + "...", Fuente)
            If SZ2.Width > Width + 41 Then
                TempText = TempText.Substring(0, TempText.Length - 1)
                GoTo Repite
            End If
            Return TempText + "..."
        Else
            Return TempText
        End If
    End Function

#Region " DrawItem "

    Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Dim NormalItemHeight As Integer = MeasureString("@", Font).Height
        If e.Index <> -1 Then
            Dim TItem As String = Items(e.Index)
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                ItemHoverFont = SetFontSize(TItem, ItemHoverFont, 8)
                TItem = SetTextItem(TItem, ItemSelectedFont)

                e.Graphics.FillRectangle(New SolidBrush(ItemHoverBackColor), e.Bounds.X + 1, e.Bounds.Y, e.Bounds.Width - 2, e.Bounds.Height - 1)
                Select Case ItemTextAlign
                    Case HorizontalAlignment.Left
                        e.Graphics.DrawString(TItem, ItemHoverFont, New SolidBrush(ItemHoverColor), 5, e.Bounds.Y + ((NormalItemHeight / 2) - (MeasureString(TItem, ItemHoverFont).Height / 2)))
                    Case HorizontalAlignment.Center
                        e.Graphics.DrawString(TItem, ItemHoverFont, New SolidBrush(ItemHoverColor), e.Bounds.Width / 2 - (MeasureString(TItem, ItemHoverFont).Width / 2), e.Bounds.Y + ((NormalItemHeight / 2) - (MeasureString(TItem, ItemHoverFont).Height / 2)))
                    Case HorizontalAlignment.Right
                        e.Graphics.DrawString(TItem, ItemHoverFont, New SolidBrush(ItemHoverColor), e.Bounds.Width - (MeasureString(TItem, ItemHoverFont).Width), e.Bounds.Y + ((NormalItemHeight / 2) - (MeasureString(TItem, ItemHoverFont).Height / 2)))
                End Select
            Else
                ItemFont = SetFontSize(TItem, ItemFont, 8)
                TItem = SetTextItem(TItem, ItemSelectedFont)

                e.Graphics.FillRectangle(New SolidBrush(ItemBackColor), e.Bounds.X + 1, e.Bounds.Y, e.Bounds.Width - 2, e.Bounds.Height - 1)
                Select Case ItemTextAlign
                    Case HorizontalAlignment.Left
                        e.Graphics.DrawString(TItem, ItemFont, New SolidBrush(ItemColor), 5, e.Bounds.Y + ((NormalItemHeight / 2) - (MeasureString(TItem, ItemFont).Height / 2)))
                    Case HorizontalAlignment.Center
                        e.Graphics.DrawString(TItem, ItemFont, New SolidBrush(ItemColor), e.Bounds.Width / 2 - (MeasureString(TItem, ItemFont).Width / 2), e.Bounds.Y + ((NormalItemHeight / 2) - (MeasureString(TItem, ItemFont).Height / 2)))
                    Case HorizontalAlignment.Right
                        e.Graphics.DrawString(TItem, ItemFont, New SolidBrush(ItemColor), e.Bounds.Width - (MeasureString(TItem, ItemFont).Width), e.Bounds.Y + ((NormalItemHeight / 2) - (MeasureString(TItem, ItemFont).Height / 2)))
                End Select
            End If
            RaiseEvent ItemHover(e.Index)
        End If
    End Sub

#End Region

#Region " DrawText "

    Private Sub DrawText(ByRef G As Graphics, DText As String, DFont As Font, DColor As Color, Optional XOffset As Integer = 0, Optional YOffset As Integer = 0, Optional DrawImage As Boolean = True, Optional CalcImage As Boolean = False, Optional WOffset As Integer = 0, Optional HOffset As Integer = 0)
        Dim TextLocation As PointF
        Dim TextSize As New Size(G.MeasureString(DText, DFont).Width, G.MeasureString(DText, DFont).Height)
        If TextAlign = HorizontalAlignment.Left Then TextLocation = New PointF(5 + XOffset, ((Height + HOffset) \ 2 - G.MeasureString(DText, DFont).Height / 2) + YOffset)
        If TextAlign = HorizontalAlignment.Center Then TextLocation = New PointF(((((Width + WOffset) \ 2) - G.MeasureString(DText, DFont).Width / 2) + XOffset), ((Height + HOffset) \ 2 - G.MeasureString(DText, DFont).Height / 2) + YOffset)
        If TextAlign = HorizontalAlignment.Right Then TextLocation = New PointF((Width + WOffset - (G.MeasureString(DText, DFont).Width + 5)) + XOffset, ((Height + HOffset) \ 2 - G.MeasureString(DText, DFont).Height / 2) + YOffset)

        If ImageSize.Width > Width - 23 Then ImageSize = New Size(Width - 23, ImageSize.Height)
        If ImageSize.Height > Height - 4 Then ImageSize = New Size(ImageSize.Width, Height - 4)
        Dim ImageLocation As PointF
        If ImageAlign = HorizontalAlignment.Left Then ImageLocation = New PointF(3, ((Height - 1) / 2) - (ImageSize.Height / 2))
        If ImageAlign = HorizontalAlignment.Center Then ImageLocation = New PointF((((Width - WOffset) / 2) - (ImageSize.Width / 2) + WOffset), ((Height - 1) / 2) - (ImageSize.Height / 2))
        If ImageAlign = HorizontalAlignment.Right Then ImageLocation = New PointF(Width + WOffset - ImageSize.Width, ((Height - 1) / 2) - (ImageSize.Height / 2))

        If Image Is Nothing Or DrawImage = False And CalcImage = False Then
            G.DrawString(DText, DFont, New SolidBrush(DColor), TextLocation)
        ElseIf ImageMode = STImageMode.Fill Then
            G.DrawImage(Image, 1, 1 + HOffset, Width + WOffset, Height - 2 + HOffset)
            G.DrawString(DText, DFont, New SolidBrush(DColor), TextLocation)
        Else
            G.DrawImage(Image, ImageLocation.X, ImageLocation.Y, ImageSize.Width, ImageSize.Height)
            Select Case TextAlign
                Case HorizontalAlignment.Left
                    If ImageAlign = HorizontalAlignment.Left Then G.DrawString(DText, DFont, New SolidBrush(DColor), ImageLocation.X + ImageSize.Width + 4 + XOffset, TextLocation.Y) Else G.DrawString(DText, DFont, New SolidBrush(DColor), TextLocation)
                Case HorizontalAlignment.Center
                    G.DrawString(DText, DFont, New SolidBrush(DColor), TextLocation)
                Case HorizontalAlignment.Right
                    If ImageAlign = HorizontalAlignment.Right Then G.DrawString(DText, DFont, New SolidBrush(DColor), ImageLocation.X - TextSize.Width - 4 + XOffset, TextLocation.Y) Else G.DrawString(DText, DFont, New SolidBrush(DColor), TextLocation)
            End Select
        End If
    End Sub

#End Region

#End Region

#Region " DropDown Border "

    Private Sub DropDownCheck_Tick(sender As Object, e As EventArgs)
        Dim m As Message = GetControlListBoxMessage(Handle)
        WndProc(m)
    End Sub

    'Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
    '    Get
    '        Dim cp As CreateParams = MyBase.CreateParams
    '        cp.Style = cp.Style And Not &H200000   ' Turn off WS_VSCROLL style
    '        Return cp
    '    End Get
    'End Property

    Protected Overrides Sub WndProc(ByRef m As Message)
        Select Case m.Msg
            Case &H134
                MyBase.WndProc(m)
                DrawNativeBorder(m.LParam)
            Case Else
                MyBase.WndProc(m)
        End Select
    End Sub

    Public Function GetControlListBoxMessage(handle As IntPtr) As Message
        Dim m As New Message()
        Dim info As New COMBOBOXINFO()
        info.cbSize = Runtime.InteropServices.Marshal.SizeOf(info)
        m.LParam = If(GetComboBoxInfo(handle, info), info.hwndList, IntPtr.Zero)
        m.WParam = IntPtr.Zero
        m.HWnd = handle
        m.Msg = &H134
        m.Result = IntPtr.Zero
        Return m
    End Function

    Public Sub DrawNativeBorder(handle As IntPtr)
        Dim controlRect As RECT
        GetWindowRect(handle, controlRect)
        controlRect.Right -= controlRect.Left
        controlRect.Bottom -= controlRect.Top
        controlRect.Top = Assign(controlRect.Left, 0)
        Dim dc As IntPtr = GetWindowDC(handle)
        Dim clientRect As RECT = controlRect
        clientRect.Left += 1
        clientRect.Top += 1
        clientRect.Right -= 1
        clientRect.Bottom -= 1
        ExcludeClipRect(dc, clientRect.Left, clientRect.Top, clientRect.Right, clientRect.Bottom)
        Dim border As IntPtr = CreatePen(PenStyles.PS_SOLID, 1, RGB(DropdownBorderColor.R, DropdownBorderColor.G, DropdownBorderColor.B))
        Dim borderPen As IntPtr = SelectObject(dc, border)
        Rectangle(dc, controlRect.Left, controlRect.Top, controlRect.Right, controlRect.Bottom)
        SelectObject(dc, borderPen)
        DeleteObject(border)
        ReleaseDC(handle, dc)
        SetFocus(handle)
    End Sub

    Function Assign(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function

    Private TextGraphics As Graphics
    Private TextBitmap As Bitmap

    Friend Function MeasureString(text As String, font As Font) As SizeF
        Return TextGraphics.MeasureString(text, font)
    End Function

#End Region

End Class

#End Region
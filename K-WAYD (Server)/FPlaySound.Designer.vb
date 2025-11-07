<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FPlaySound
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FPlaySound))
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.BEnviar = New System.Windows.Forms.Button()
        Me.TNombre = New System.Windows.Forms.Label()
        Me.LNombre = New System.Windows.Forms.Label()
        Me.THidden = New System.Windows.Forms.TextBox()
        Me.CSonido = New K_WAYD__Server_.NSComboBox()
        Me.SuspendLayout()
        '
        'BCancelar
        '
        Me.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BCancelar.ForeColor = System.Drawing.Color.LightGray
        Me.BCancelar.Location = New System.Drawing.Point(157, 74)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(125, 31)
        Me.BCancelar.TabIndex = 14
        Me.BCancelar.Text = "Cancelar"
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'BEnviar
        '
        Me.BEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BEnviar.ForeColor = System.Drawing.Color.LightGray
        Me.BEnviar.Location = New System.Drawing.Point(16, 74)
        Me.BEnviar.Name = "BEnviar"
        Me.BEnviar.Size = New System.Drawing.Size(125, 31)
        Me.BEnviar.TabIndex = 15
        Me.BEnviar.Text = "Enviar"
        Me.BEnviar.UseVisualStyleBackColor = True
        '
        'TNombre
        '
        Me.TNombre.ForeColor = System.Drawing.Color.DarkOrange
        Me.TNombre.Location = New System.Drawing.Point(137, 12)
        Me.TNombre.Name = "TNombre"
        Me.TNombre.Size = New System.Drawing.Size(145, 13)
        Me.TNombre.TabIndex = 11
        Me.TNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LNombre
        '
        Me.LNombre.AutoSize = True
        Me.LNombre.ForeColor = System.Drawing.Color.LightGray
        Me.LNombre.Location = New System.Drawing.Point(48, 12)
        Me.LNombre.Name = "LNombre"
        Me.LNombre.Size = New System.Drawing.Size(83, 13)
        Me.LNombre.TabIndex = 12
        Me.LNombre.Text = "Enviar sonido a:"
        Me.LNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'THidden
        '
        Me.THidden.Location = New System.Drawing.Point(-10000, -10000)
        Me.THidden.Name = "THidden"
        Me.THidden.ReadOnly = True
        Me.THidden.ShortcutsEnabled = False
        Me.THidden.Size = New System.Drawing.Size(10, 20)
        Me.THidden.TabIndex = 20
        '
        'CSonido
        '
        Me.CSonido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CSonido.BaseColor1 = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.CSonido.BaseColor2 = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.CSonido.BorderColor1 = System.Drawing.Color.White
        Me.CSonido.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.CSonido.BorderColor3 = System.Drawing.Color.White
        Me.CSonido.DoubleText = False
        Me.CSonido.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CSonido.DropdownBorderColor = System.Drawing.Color.Gray
        Me.CSonido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CSonido.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.CSonido.ForeColor1 = System.Drawing.Color.LightGray
        Me.CSonido.ForeColor2 = System.Drawing.Color.Black
        Me.CSonido.FormattingEnabled = True
        Me.CSonido.GradientAngle = 90
        Me.CSonido.GradientColor1 = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.CSonido.GradientColor2 = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.CSonido.GradientTransparency = 0
        Me.CSonido.HoverColor1 = System.Drawing.Color.Orange
        Me.CSonido.HoverColor2 = System.Drawing.Color.Black
        Me.CSonido.Image = Nothing
        Me.CSonido.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CSonido.ImageMode = K_WAYD__Server_.NSComboBox.STImageMode.Normal
        Me.CSonido.ImageSize = New System.Drawing.Size(19, 17)
        Me.CSonido.ItemBackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.CSonido.ItemColor = System.Drawing.Color.LightGray
        Me.CSonido.ItemFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CSonido.ItemHoverBackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.CSonido.ItemHoverColor = System.Drawing.Color.Orange
        Me.CSonido.ItemHoverFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CSonido.ItemSelectedBackColor = System.Drawing.Color.Blue
        Me.CSonido.ItemSelectedColor = System.Drawing.Color.Orange
        Me.CSonido.ItemSelectedFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CSonido.ItemTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CSonido.JustButton = False
        Me.CSonido.Location = New System.Drawing.Point(22, 38)
        Me.CSonido.Name = "CSonido"
        Me.CSonido.Rounded = 7
        Me.CSonido.Size = New System.Drawing.Size(254, 21)
        Me.CSonido.TabIndex = 21
        Me.CSonido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FPlaySound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(297, 119)
        Me.Controls.Add(Me.CSonido)
        Me.Controls.Add(Me.THidden)
        Me.Controls.Add(Me.BCancelar)
        Me.Controls.Add(Me.BEnviar)
        Me.Controls.Add(Me.TNombre)
        Me.Controls.Add(Me.LNombre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FPlaySound"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reproducir Sonido"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BCancelar As Button
    Friend WithEvents BEnviar As Button
    Friend WithEvents TNombre As Label
    Friend WithEvents LNombre As Label
    Friend WithEvents THidden As TextBox
    Friend WithEvents CSonido As NSComboBox
End Class

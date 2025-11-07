<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FSettings))
        Me.CIniciarWindow = New System.Windows.Forms.CheckBox()
        Me.LDireccionIP = New System.Windows.Forms.Label()
        Me.TDireccionIP = New System.Windows.Forms.TextBox()
        Me.LPuerto = New System.Windows.Forms.Label()
        Me.TPuerto = New System.Windows.Forms.TextBox()
        Me.GServidor = New System.Windows.Forms.GroupBox()
        Me.THidden = New System.Windows.Forms.TextBox()
        Me.GServidor.SuspendLayout()
        Me.SuspendLayout()
        '
        'CIniciarWindow
        '
        Me.CIniciarWindow.AutoSize = True
        Me.CIniciarWindow.ForeColor = System.Drawing.Color.LightGray
        Me.CIniciarWindow.Location = New System.Drawing.Point(26, 98)
        Me.CIniciarWindow.Name = "CIniciarWindow"
        Me.CIniciarWindow.Size = New System.Drawing.Size(122, 17)
        Me.CIniciarWindow.TabIndex = 0
        Me.CIniciarWindow.Text = "Iniciar con Windows"
        Me.CIniciarWindow.UseVisualStyleBackColor = True
        '
        'LDireccionIP
        '
        Me.LDireccionIP.ForeColor = System.Drawing.Color.LightGray
        Me.LDireccionIP.Location = New System.Drawing.Point(9, 21)
        Me.LDireccionIP.Name = "LDireccionIP"
        Me.LDireccionIP.Size = New System.Drawing.Size(72, 19)
        Me.LDireccionIP.TabIndex = 1
        Me.LDireccionIP.Text = "Direccion IP:"
        Me.LDireccionIP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TDireccionIP
        '
        Me.TDireccionIP.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TDireccionIP.ForeColor = System.Drawing.Color.LightGray
        Me.TDireccionIP.Location = New System.Drawing.Point(87, 21)
        Me.TDireccionIP.MaxLength = 200
        Me.TDireccionIP.Name = "TDireccionIP"
        Me.TDireccionIP.ShortcutsEnabled = False
        Me.TDireccionIP.Size = New System.Drawing.Size(93, 20)
        Me.TDireccionIP.TabIndex = 2
        Me.TDireccionIP.Text = "182.168.0.1"
        Me.TDireccionIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LPuerto
        '
        Me.LPuerto.ForeColor = System.Drawing.Color.LightGray
        Me.LPuerto.Location = New System.Drawing.Point(12, 47)
        Me.LPuerto.Name = "LPuerto"
        Me.LPuerto.Size = New System.Drawing.Size(69, 13)
        Me.LPuerto.TabIndex = 1
        Me.LPuerto.Text = "Puerto:"
        Me.LPuerto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TPuerto
        '
        Me.TPuerto.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TPuerto.ForeColor = System.Drawing.Color.LightGray
        Me.TPuerto.Location = New System.Drawing.Point(87, 45)
        Me.TPuerto.MaxLength = 5
        Me.TPuerto.Name = "TPuerto"
        Me.TPuerto.ShortcutsEnabled = False
        Me.TPuerto.Size = New System.Drawing.Size(93, 20)
        Me.TPuerto.TabIndex = 2
        Me.TPuerto.Text = "12345"
        Me.TPuerto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GServidor
        '
        Me.GServidor.Controls.Add(Me.TDireccionIP)
        Me.GServidor.Controls.Add(Me.TPuerto)
        Me.GServidor.Controls.Add(Me.LDireccionIP)
        Me.GServidor.Controls.Add(Me.LPuerto)
        Me.GServidor.ForeColor = System.Drawing.Color.LightGray
        Me.GServidor.Location = New System.Drawing.Point(12, 9)
        Me.GServidor.Name = "GServidor"
        Me.GServidor.Size = New System.Drawing.Size(200, 80)
        Me.GServidor.TabIndex = 3
        Me.GServidor.TabStop = False
        Me.GServidor.Text = "Cliente"
        '
        'THidden
        '
        Me.THidden.Location = New System.Drawing.Point(-10000, -10000)
        Me.THidden.Name = "THidden"
        Me.THidden.ReadOnly = True
        Me.THidden.ShortcutsEnabled = False
        Me.THidden.Size = New System.Drawing.Size(10, 20)
        Me.THidden.TabIndex = 3
        '
        'FSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(224, 126)
        Me.Controls.Add(Me.THidden)
        Me.Controls.Add(Me.GServidor)
        Me.Controls.Add(Me.CIniciarWindow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajustes"
        Me.GServidor.ResumeLayout(False)
        Me.GServidor.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CIniciarWindow As CheckBox
    Friend WithEvents LDireccionIP As Label
    Friend WithEvents TDireccionIP As TextBox
    Friend WithEvents LPuerto As Label
    Friend WithEvents TPuerto As TextBox
    Friend WithEvents GServidor As GroupBox
    Friend WithEvents THidden As TextBox
End Class

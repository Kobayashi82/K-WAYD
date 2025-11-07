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
        Me.CGuardarRegistro = New System.Windows.Forms.CheckBox()
        Me.LDireccionIP = New System.Windows.Forms.Label()
        Me.TDireccionIP = New System.Windows.Forms.TextBox()
        Me.LPuerto = New System.Windows.Forms.Label()
        Me.TPuerto = New System.Windows.Forms.TextBox()
        Me.GServidor = New System.Windows.Forms.GroupBox()
        Me.GArduino = New System.Windows.Forms.GroupBox()
        Me.TPuertoCOM = New System.Windows.Forms.TextBox()
        Me.TBaudRate = New System.Windows.Forms.TextBox()
        Me.CArduino = New System.Windows.Forms.CheckBox()
        Me.LPuertoCOM = New System.Windows.Forms.Label()
        Me.LBaudRate = New System.Windows.Forms.Label()
        Me.CIniciarWindow = New System.Windows.Forms.CheckBox()
        Me.THidden = New System.Windows.Forms.TextBox()
        Me.GServidor.SuspendLayout()
        Me.GArduino.SuspendLayout()
        Me.SuspendLayout()
        '
        'CGuardarRegistro
        '
        Me.CGuardarRegistro.AutoSize = True
        Me.CGuardarRegistro.ForeColor = System.Drawing.Color.LightGray
        Me.CGuardarRegistro.Location = New System.Drawing.Point(22, 183)
        Me.CGuardarRegistro.Name = "CGuardarRegistro"
        Me.CGuardarRegistro.Size = New System.Drawing.Size(186, 17)
        Me.CGuardarRegistro.TabIndex = 0
        Me.CGuardarRegistro.Text = "Guardar un registro de los clientes"
        Me.CGuardarRegistro.UseVisualStyleBackColor = True
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
        Me.GServidor.Text = "Servidor"
        '
        'GArduino
        '
        Me.GArduino.Controls.Add(Me.TPuertoCOM)
        Me.GArduino.Controls.Add(Me.TBaudRate)
        Me.GArduino.Controls.Add(Me.CArduino)
        Me.GArduino.Controls.Add(Me.LPuertoCOM)
        Me.GArduino.Controls.Add(Me.LBaudRate)
        Me.GArduino.ForeColor = System.Drawing.Color.LightGray
        Me.GArduino.Location = New System.Drawing.Point(12, 95)
        Me.GArduino.Name = "GArduino"
        Me.GArduino.Size = New System.Drawing.Size(200, 80)
        Me.GArduino.TabIndex = 4
        Me.GArduino.TabStop = False
        '
        'TPuertoCOM
        '
        Me.TPuertoCOM.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TPuertoCOM.ForeColor = System.Drawing.Color.LightGray
        Me.TPuertoCOM.Location = New System.Drawing.Point(87, 21)
        Me.TPuertoCOM.MaxLength = 2
        Me.TPuertoCOM.Name = "TPuertoCOM"
        Me.TPuertoCOM.ShortcutsEnabled = False
        Me.TPuertoCOM.Size = New System.Drawing.Size(93, 20)
        Me.TPuertoCOM.TabIndex = 2
        Me.TPuertoCOM.Text = "12"
        Me.TPuertoCOM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TBaudRate
        '
        Me.TBaudRate.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TBaudRate.ForeColor = System.Drawing.Color.LightGray
        Me.TBaudRate.Location = New System.Drawing.Point(87, 45)
        Me.TBaudRate.MaxLength = 6
        Me.TBaudRate.Name = "TBaudRate"
        Me.TBaudRate.ShortcutsEnabled = False
        Me.TBaudRate.Size = New System.Drawing.Size(93, 20)
        Me.TBaudRate.TabIndex = 2
        Me.TBaudRate.Text = "9600"
        Me.TBaudRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CArduino
        '
        Me.CArduino.AutoSize = True
        Me.CArduino.ForeColor = System.Drawing.Color.LightGray
        Me.CArduino.Location = New System.Drawing.Point(9, -1)
        Me.CArduino.Name = "CArduino"
        Me.CArduino.Size = New System.Drawing.Size(62, 17)
        Me.CArduino.TabIndex = 0
        Me.CArduino.Text = "Arduino"
        Me.CArduino.UseVisualStyleBackColor = True
        '
        'LPuertoCOM
        '
        Me.LPuertoCOM.ForeColor = System.Drawing.Color.LightGray
        Me.LPuertoCOM.Location = New System.Drawing.Point(9, 21)
        Me.LPuertoCOM.Name = "LPuertoCOM"
        Me.LPuertoCOM.Size = New System.Drawing.Size(72, 19)
        Me.LPuertoCOM.TabIndex = 1
        Me.LPuertoCOM.Text = "Puerto COM:"
        Me.LPuertoCOM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBaudRate
        '
        Me.LBaudRate.ForeColor = System.Drawing.Color.LightGray
        Me.LBaudRate.Location = New System.Drawing.Point(12, 47)
        Me.LBaudRate.Name = "LBaudRate"
        Me.LBaudRate.Size = New System.Drawing.Size(69, 13)
        Me.LBaudRate.TabIndex = 1
        Me.LBaudRate.Text = "Baud Rate:"
        Me.LBaudRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CIniciarWindow
        '
        Me.CIniciarWindow.AutoSize = True
        Me.CIniciarWindow.ForeColor = System.Drawing.Color.LightGray
        Me.CIniciarWindow.Location = New System.Drawing.Point(22, 206)
        Me.CIniciarWindow.Name = "CIniciarWindow"
        Me.CIniciarWindow.Size = New System.Drawing.Size(122, 17)
        Me.CIniciarWindow.TabIndex = 0
        Me.CIniciarWindow.Text = "Iniciar con Windows"
        Me.CIniciarWindow.UseVisualStyleBackColor = True
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
        Me.ClientSize = New System.Drawing.Size(224, 232)
        Me.Controls.Add(Me.THidden)
        Me.Controls.Add(Me.GArduino)
        Me.Controls.Add(Me.GServidor)
        Me.Controls.Add(Me.CIniciarWindow)
        Me.Controls.Add(Me.CGuardarRegistro)
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
        Me.GArduino.ResumeLayout(False)
        Me.GArduino.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CGuardarRegistro As CheckBox
    Friend WithEvents LDireccionIP As Label
    Friend WithEvents TDireccionIP As TextBox
    Friend WithEvents LPuerto As Label
    Friend WithEvents TPuerto As TextBox
    Friend WithEvents GServidor As GroupBox
    Friend WithEvents GArduino As GroupBox
    Friend WithEvents TPuertoCOM As TextBox
    Friend WithEvents TBaudRate As TextBox
    Friend WithEvents LPuertoCOM As Label
    Friend WithEvents LBaudRate As Label
    Friend WithEvents CIniciarWindow As CheckBox
    Friend WithEvents CArduino As CheckBox
    Friend WithEvents THidden As TextBox
End Class

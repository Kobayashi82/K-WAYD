<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FMenu
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FMenu))
        Me.THidden = New System.Windows.Forms.TextBox()
        Me.CMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MMostrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MSeparador = New System.Windows.Forms.ToolStripSeparator()
        Me.MSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelStatus = New System.Windows.Forms.StatusStrip()
        Me.LArduino = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LClientes = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LTitulo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PanelBotones = New System.Windows.Forms.ToolStrip()
        Me.LBSeparador0 = New System.Windows.Forms.ToolStripSeparator()
        Me.BSwitch = New System.Windows.Forms.ToolStripButton()
        Me.LBSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BCapturarPantalla = New System.Windows.Forms.ToolStripButton()
        Me.LBSeparador2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BEnviarMensaje = New System.Windows.Forms.ToolStripButton()
        Me.LBSeparador3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BPlaySound = New System.Windows.Forms.ToolStripButton()
        Me.LBSeparador4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BBuzz = New System.Windows.Forms.ToolStripButton()
        Me.LBSeparador5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BSettings = New System.Windows.Forms.ToolStripButton()
        Me.LStatusBar1 = New System.Windows.Forms.Label()
        Me.TClientes = New System.Windows.Forms.TabControl()
        Me.Fondo = New System.Windows.Forms.Panel()
        Me.PFondo = New System.Windows.Forms.PictureBox()
        Me.TMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TMGuardarLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.TMVaciarLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.TMSeparador0 = New System.Windows.Forms.ToolStripSeparator()
        Me.TMCapturarPantalla = New System.Windows.Forms.ToolStripMenuItem()
        Me.TMGuardarCaptura = New System.Windows.Forms.ToolStripMenuItem()
        Me.TMSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TMCapturaAuto = New System.Windows.Forms.ToolStripMenuItem()
        Me.TMIntervalo = New System.Windows.Forms.ToolStripTextBox()
        Me.TMSeparador2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TMCerrarCliente = New System.Windows.Forms.ToolStripMenuItem()
        Me.TMSeparador3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TMSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.LStatusBar2 = New System.Windows.Forms.Label()
        Me.CMenu.SuspendLayout()
        Me.PanelStatus.SuspendLayout()
        Me.PanelBotones.SuspendLayout()
        Me.Fondo.SuspendLayout()
        CType(Me.PFondo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'THidden
        '
        Me.THidden.Location = New System.Drawing.Point(-26, 12)
        Me.THidden.Name = "THidden"
        Me.THidden.ReadOnly = True
        Me.THidden.ShortcutsEnabled = False
        Me.THidden.Size = New System.Drawing.Size(10, 20)
        Me.THidden.TabIndex = 0
        '
        'CMenu
        '
        Me.CMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MMostrar, Me.MSeparador, Me.MSalir})
        Me.CMenu.Name = "Menu"
        Me.CMenu.Size = New System.Drawing.Size(116, 54)
        '
        'MMostrar
        '
        Me.MMostrar.Name = "MMostrar"
        Me.MMostrar.Size = New System.Drawing.Size(115, 22)
        Me.MMostrar.Text = "Mostra&r"
        '
        'MSeparador
        '
        Me.MSeparador.Name = "MSeparador"
        Me.MSeparador.Size = New System.Drawing.Size(112, 6)
        '
        'MSalir
        '
        Me.MSalir.Name = "MSalir"
        Me.MSalir.Size = New System.Drawing.Size(115, 22)
        Me.MSalir.Text = "&Salir"
        '
        'PanelStatus
        '
        Me.PanelStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelStatus.AutoSize = False
        Me.PanelStatus.Dock = System.Windows.Forms.DockStyle.None
        Me.PanelStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LArduino, Me.LClientes, Me.LTitulo, Me.ToolStripStatusLabel1})
        Me.PanelStatus.Location = New System.Drawing.Point(0, 768)
        Me.PanelStatus.Name = "PanelStatus"
        Me.PanelStatus.Size = New System.Drawing.Size(785, 24)
        Me.PanelStatus.TabIndex = 4
        '
        'LArduino
        '
        Me.LArduino.AutoSize = False
        Me.LArduino.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.LArduino.ForeColor = System.Drawing.Color.IndianRed
        Me.LArduino.Name = "LArduino"
        Me.LArduino.Size = New System.Drawing.Size(70, 19)
        Me.LArduino.Text = "Arduino"
        '
        'LClientes
        '
        Me.LClientes.AutoSize = False
        Me.LClientes.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.LClientes.ForeColor = System.Drawing.Color.LightGray
        Me.LClientes.Name = "LClientes"
        Me.LClientes.Size = New System.Drawing.Size(110, 19)
        Me.LClientes.Text = "Clientes: 0"
        '
        'LTitulo
        '
        Me.LTitulo.ForeColor = System.Drawing.Color.LightGray
        Me.LTitulo.Name = "LTitulo"
        Me.LTitulo.Size = New System.Drawing.Size(470, 19)
        Me.LTitulo.Spring = True
        Me.LTitulo.Text = "K-WAYD 1.0"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AutoSize = False
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(120, 19)
        '
        'PanelBotones
        '
        Me.PanelBotones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelBotones.AutoSize = False
        Me.PanelBotones.CanOverflow = False
        Me.PanelBotones.Dock = System.Windows.Forms.DockStyle.None
        Me.PanelBotones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LBSeparador0, Me.BSwitch, Me.LBSeparador1, Me.BCapturarPantalla, Me.LBSeparador2, Me.BEnviarMensaje, Me.LBSeparador3, Me.BPlaySound, Me.LBSeparador4, Me.BBuzz, Me.LBSeparador5, Me.BSettings})
        Me.PanelBotones.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.PanelBotones.Location = New System.Drawing.Point(590, 768)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(177, 22)
        Me.PanelBotones.TabIndex = 5
        '
        'LBSeparador0
        '
        Me.LBSeparador0.Name = "LBSeparador0"
        Me.LBSeparador0.Size = New System.Drawing.Size(6, 23)
        '
        'BSwitch
        '
        Me.BSwitch.AutoSize = False
        Me.BSwitch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BSwitch.Image = CType(resources.GetObject("BSwitch.Image"), System.Drawing.Image)
        Me.BSwitch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BSwitch.Margin = New System.Windows.Forms.Padding(0, 3, 0, 2)
        Me.BSwitch.Name = "BSwitch"
        Me.BSwitch.Size = New System.Drawing.Size(23, 18)
        Me.BSwitch.Text = "Switch Mode"
        '
        'LBSeparador1
        '
        Me.LBSeparador1.Name = "LBSeparador1"
        Me.LBSeparador1.Size = New System.Drawing.Size(6, 23)
        '
        'BCapturarPantalla
        '
        Me.BCapturarPantalla.AutoSize = False
        Me.BCapturarPantalla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BCapturarPantalla.Image = CType(resources.GetObject("BCapturarPantalla.Image"), System.Drawing.Image)
        Me.BCapturarPantalla.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BCapturarPantalla.Margin = New System.Windows.Forms.Padding(0, 3, 0, 2)
        Me.BCapturarPantalla.Name = "BCapturarPantalla"
        Me.BCapturarPantalla.Size = New System.Drawing.Size(23, 18)
        Me.BCapturarPantalla.Text = "Capturar Pantalla"
        '
        'LBSeparador2
        '
        Me.LBSeparador2.Name = "LBSeparador2"
        Me.LBSeparador2.Size = New System.Drawing.Size(6, 23)
        '
        'BEnviarMensaje
        '
        Me.BEnviarMensaje.AutoSize = False
        Me.BEnviarMensaje.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BEnviarMensaje.Image = CType(resources.GetObject("BEnviarMensaje.Image"), System.Drawing.Image)
        Me.BEnviarMensaje.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BEnviarMensaje.Margin = New System.Windows.Forms.Padding(0, 3, 0, 2)
        Me.BEnviarMensaje.Name = "BEnviarMensaje"
        Me.BEnviarMensaje.Size = New System.Drawing.Size(23, 18)
        Me.BEnviarMensaje.Text = "Enviar Mensaje"
        '
        'LBSeparador3
        '
        Me.LBSeparador3.Name = "LBSeparador3"
        Me.LBSeparador3.Size = New System.Drawing.Size(6, 23)
        '
        'BPlaySound
        '
        Me.BPlaySound.AutoSize = False
        Me.BPlaySound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BPlaySound.Image = CType(resources.GetObject("BPlaySound.Image"), System.Drawing.Image)
        Me.BPlaySound.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BPlaySound.Margin = New System.Windows.Forms.Padding(0, 3, 0, 2)
        Me.BPlaySound.Name = "BPlaySound"
        Me.BPlaySound.Size = New System.Drawing.Size(23, 18)
        Me.BPlaySound.Text = "Reproducir Sonido"
        '
        'LBSeparador4
        '
        Me.LBSeparador4.Name = "LBSeparador4"
        Me.LBSeparador4.Size = New System.Drawing.Size(6, 23)
        '
        'BBuzz
        '
        Me.BBuzz.AutoSize = False
        Me.BBuzz.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BBuzz.Image = CType(resources.GetObject("BBuzz.Image"), System.Drawing.Image)
        Me.BBuzz.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BBuzz.Margin = New System.Windows.Forms.Padding(0, 3, 0, 2)
        Me.BBuzz.Name = "BBuzz"
        Me.BBuzz.Size = New System.Drawing.Size(23, 18)
        Me.BBuzz.Text = "Buzz"
        '
        'LBSeparador5
        '
        Me.LBSeparador5.Name = "LBSeparador5"
        Me.LBSeparador5.Size = New System.Drawing.Size(6, 23)
        '
        'BSettings
        '
        Me.BSettings.AutoSize = False
        Me.BSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BSettings.Image = CType(resources.GetObject("BSettings.Image"), System.Drawing.Image)
        Me.BSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BSettings.Margin = New System.Windows.Forms.Padding(0, 3, 0, 2)
        Me.BSettings.Name = "BSettings"
        Me.BSettings.Size = New System.Drawing.Size(23, 18)
        Me.BSettings.Text = "Ajustes"
        '
        'LStatusBar1
        '
        Me.LStatusBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LStatusBar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.LStatusBar1.Location = New System.Drawing.Point(590, 768)
        Me.LStatusBar1.Name = "LStatusBar1"
        Me.LStatusBar1.Size = New System.Drawing.Size(2, 22)
        Me.LStatusBar1.TabIndex = 6
        '
        'TClientes
        '
        Me.TClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TClientes.Location = New System.Drawing.Point(-2, 3)
        Me.TClientes.Name = "TClientes"
        Me.TClientes.SelectedIndex = 0
        Me.TClientes.Size = New System.Drawing.Size(788, 770)
        Me.TClientes.TabIndex = 7
        '
        'Fondo
        '
        Me.Fondo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Fondo.Controls.Add(Me.PFondo)
        Me.Fondo.Location = New System.Drawing.Point(0, 0)
        Me.Fondo.Name = "Fondo"
        Me.Fondo.Size = New System.Drawing.Size(784, 769)
        Me.Fondo.TabIndex = 8
        '
        'PFondo
        '
        Me.PFondo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PFondo.Image = CType(resources.GetObject("PFondo.Image"), System.Drawing.Image)
        Me.PFondo.Location = New System.Drawing.Point(0, 0)
        Me.PFondo.Name = "PFondo"
        Me.PFondo.Size = New System.Drawing.Size(784, 769)
        Me.PFondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PFondo.TabIndex = 0
        Me.PFondo.TabStop = False
        '
        'TMenu
        '
        Me.TMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TMGuardarLog, Me.TMVaciarLog, Me.TMSeparador0, Me.TMCapturarPantalla, Me.TMSeparador2, Me.TMCerrarCliente, Me.TMSeparador3, Me.TMSalir})
        Me.TMenu.Name = "TMenu"
        Me.TMenu.Size = New System.Drawing.Size(166, 132)
        '
        'TMGuardarLog
        '
        Me.TMGuardarLog.Name = "TMGuardarLog"
        Me.TMGuardarLog.Size = New System.Drawing.Size(165, 22)
        Me.TMGuardarLog.Text = "&Guardar Log"
        '
        'TMVaciarLog
        '
        Me.TMVaciarLog.Name = "TMVaciarLog"
        Me.TMVaciarLog.Size = New System.Drawing.Size(165, 22)
        Me.TMVaciarLog.Text = "&Vaciar Log"
        '
        'TMSeparador0
        '
        Me.TMSeparador0.Name = "TMSeparador0"
        Me.TMSeparador0.Size = New System.Drawing.Size(162, 6)
        '
        'TMCapturarPantalla
        '
        Me.TMCapturarPantalla.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TMGuardarCaptura, Me.TMSeparador1, Me.TMCapturaAuto, Me.TMIntervalo})
        Me.TMCapturarPantalla.Name = "TMCapturarPantalla"
        Me.TMCapturarPantalla.Size = New System.Drawing.Size(165, 22)
        Me.TMCapturarPantalla.Text = "Capturar &Pantalla"
        '
        'TMGuardarCaptura
        '
        Me.TMGuardarCaptura.Name = "TMGuardarCaptura"
        Me.TMGuardarCaptura.Size = New System.Drawing.Size(180, 22)
        Me.TMGuardarCaptura.Text = "G&uardar Captura"
        '
        'TMSeparador1
        '
        Me.TMSeparador1.Name = "TMSeparador1"
        Me.TMSeparador1.Size = New System.Drawing.Size(177, 6)
        '
        'TMCapturaAuto
        '
        Me.TMCapturaAuto.CheckOnClick = True
        Me.TMCapturaAuto.Name = "TMCapturaAuto"
        Me.TMCapturaAuto.Size = New System.Drawing.Size(180, 22)
        Me.TMCapturaAuto.Text = "Auto Capturar cada:"
        '
        'TMIntervalo
        '
        Me.TMIntervalo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TMIntervalo.Name = "TMIntervalo"
        Me.TMIntervalo.ShortcutsEnabled = False
        Me.TMIntervalo.Size = New System.Drawing.Size(100, 23)
        Me.TMIntervalo.Text = "5000"
        Me.TMIntervalo.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TMSeparador2
        '
        Me.TMSeparador2.Name = "TMSeparador2"
        Me.TMSeparador2.Size = New System.Drawing.Size(162, 6)
        '
        'TMCerrarCliente
        '
        Me.TMCerrarCliente.Name = "TMCerrarCliente"
        Me.TMCerrarCliente.Size = New System.Drawing.Size(165, 22)
        Me.TMCerrarCliente.Text = "&Cerrar Cliente"
        '
        'TMSeparador3
        '
        Me.TMSeparador3.Name = "TMSeparador3"
        Me.TMSeparador3.Size = New System.Drawing.Size(162, 6)
        '
        'TMSalir
        '
        Me.TMSalir.Name = "TMSalir"
        Me.TMSalir.Size = New System.Drawing.Size(165, 22)
        Me.TMSalir.Text = "&Salir"
        '
        'LStatusBar2
        '
        Me.LStatusBar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LStatusBar2.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.LStatusBar2.Location = New System.Drawing.Point(764, 768)
        Me.LStatusBar2.Name = "LStatusBar2"
        Me.LStatusBar2.Size = New System.Drawing.Size(8, 22)
        Me.LStatusBar2.TabIndex = 9
        '
        'FMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(784, 791)
        Me.Controls.Add(Me.Fondo)
        Me.Controls.Add(Me.LStatusBar1)
        Me.Controls.Add(Me.LStatusBar2)
        Me.Controls.Add(Me.PanelBotones)
        Me.Controls.Add(Me.PanelStatus)
        Me.Controls.Add(Me.THidden)
        Me.Controls.Add(Me.TClientes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(800, 830)
        Me.Name = "FMenu"
        Me.Opacity = 0R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "K-WAYD 1.0"
        Me.CMenu.ResumeLayout(False)
        Me.PanelStatus.ResumeLayout(False)
        Me.PanelStatus.PerformLayout()
        Me.PanelBotones.ResumeLayout(False)
        Me.PanelBotones.PerformLayout()
        Me.Fondo.ResumeLayout(False)
        CType(Me.PFondo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents THidden As TextBox
    Friend WithEvents CMenu As ContextMenuStrip
    Friend WithEvents MMostrar As ToolStripMenuItem
    Friend WithEvents MSeparador As ToolStripSeparator
    Friend WithEvents MSalir As ToolStripMenuItem
    Friend WithEvents PanelStatus As StatusStrip
    Friend WithEvents LArduino As ToolStripStatusLabel
    Friend WithEvents LClientes As ToolStripStatusLabel
    Friend WithEvents PanelBotones As ToolStrip
    Friend WithEvents BEnviarMensaje As ToolStripButton
    Friend WithEvents LBSeparador2 As ToolStripSeparator
    Friend WithEvents BCapturarPantalla As ToolStripButton
    Friend WithEvents LBSeparador3 As ToolStripSeparator
    Friend WithEvents LBSeparador5 As ToolStripSeparator
    Friend WithEvents BSettings As ToolStripButton
    Friend WithEvents LStatusBar1 As Label
    Friend WithEvents LTitulo As ToolStripStatusLabel
    Friend WithEvents TClientes As TabControl
    Friend WithEvents Fondo As Panel
    Friend WithEvents PFondo As PictureBox
    Friend WithEvents TMenu As ContextMenuStrip
    Friend WithEvents TMCerrarCliente As ToolStripMenuItem
    Friend WithEvents TMSeparador2 As ToolStripSeparator
    Friend WithEvents TMSalir As ToolStripMenuItem
    Friend WithEvents LStatusBar2 As Label
    Friend WithEvents TMCapturarPantalla As ToolStripMenuItem
    Friend WithEvents TMGuardarLog As ToolStripMenuItem
    Friend WithEvents TMSeparador0 As ToolStripSeparator
    Friend WithEvents TMVaciarLog As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents LBSeparador1 As ToolStripSeparator
    Friend WithEvents BPlaySound As ToolStripButton
    Friend WithEvents LBSeparador4 As ToolStripSeparator
    Friend WithEvents BBuzz As ToolStripButton
    Friend WithEvents LBSeparador0 As ToolStripSeparator
    Friend WithEvents BSwitch As ToolStripButton
    Friend WithEvents TMSeparador3 As ToolStripSeparator
    Friend WithEvents TMGuardarCaptura As ToolStripMenuItem
    Friend WithEvents TMSeparador1 As ToolStripSeparator
    Friend WithEvents TMCapturaAuto As ToolStripMenuItem
    Friend WithEvents TMIntervalo As ToolStripTextBox
End Class

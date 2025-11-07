<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FMensaje
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FMensaje))
        Me.Texto = New System.Windows.Forms.TextBox()
        Me.LNombre = New System.Windows.Forms.Label()
        Me.TNombre = New System.Windows.Forms.Label()
        Me.GMensaje = New System.Windows.Forms.GroupBox()
        Me.BEnviar = New System.Windows.Forms.Button()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.THidden = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.R3 = New System.Windows.Forms.RadioButton()
        Me.R5 = New System.Windows.Forms.RadioButton()
        Me.R2 = New System.Windows.Forms.RadioButton()
        Me.R4 = New System.Windows.Forms.RadioButton()
        Me.R1 = New System.Windows.Forms.RadioButton()
        Me.GTipo = New System.Windows.Forms.GroupBox()
        Me.PIcono4 = New System.Windows.Forms.PictureBox()
        Me.PIcono2 = New System.Windows.Forms.PictureBox()
        Me.PIcono3 = New System.Windows.Forms.PictureBox()
        Me.PIcono1 = New System.Windows.Forms.PictureBox()
        Me.Gtitulo = New System.Windows.Forms.GroupBox()
        Me.TTitulo = New System.Windows.Forms.TextBox()
        Me.GMensaje.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GTipo.SuspendLayout()
        CType(Me.PIcono4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PIcono2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PIcono3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PIcono1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Gtitulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Texto
        '
        Me.Texto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Texto.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Texto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Texto.ForeColor = System.Drawing.Color.LightGray
        Me.Texto.Location = New System.Drawing.Point(6, 15)
        Me.Texto.Multiline = True
        Me.Texto.Name = "Texto"
        Me.Texto.Size = New System.Drawing.Size(378, 123)
        Me.Texto.TabIndex = 4
        '
        'LNombre
        '
        Me.LNombre.AutoSize = True
        Me.LNombre.ForeColor = System.Drawing.Color.LightGray
        Me.LNombre.Location = New System.Drawing.Point(74, 12)
        Me.LNombre.Name = "LNombre"
        Me.LNombre.Size = New System.Drawing.Size(91, 13)
        Me.LNombre.TabIndex = 3
        Me.LNombre.Text = "Enviar mensaje a:"
        Me.LNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TNombre
        '
        Me.TNombre.ForeColor = System.Drawing.Color.DarkOrange
        Me.TNombre.Location = New System.Drawing.Point(165, 12)
        Me.TNombre.Name = "TNombre"
        Me.TNombre.Size = New System.Drawing.Size(241, 13)
        Me.TNombre.TabIndex = 3
        Me.TNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GMensaje
        '
        Me.GMensaje.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GMensaje.Controls.Add(Me.Texto)
        Me.GMensaje.ForeColor = System.Drawing.Color.LightGray
        Me.GMensaje.Location = New System.Drawing.Point(16, 72)
        Me.GMensaje.Name = "GMensaje"
        Me.GMensaje.Size = New System.Drawing.Size(390, 145)
        Me.GMensaje.TabIndex = 5
        Me.GMensaje.TabStop = False
        Me.GMensaje.Text = "Mensaje"
        '
        'BEnviar
        '
        Me.BEnviar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BEnviar.ForeColor = System.Drawing.Color.LightGray
        Me.BEnviar.Location = New System.Drawing.Point(16, 329)
        Me.BEnviar.Name = "BEnviar"
        Me.BEnviar.Size = New System.Drawing.Size(181, 42)
        Me.BEnviar.TabIndex = 6
        Me.BEnviar.Text = "Enviar"
        Me.BEnviar.UseVisualStyleBackColor = True
        '
        'BCancelar
        '
        Me.BCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BCancelar.ForeColor = System.Drawing.Color.LightGray
        Me.BCancelar.Location = New System.Drawing.Point(225, 329)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(181, 42)
        Me.BCancelar.TabIndex = 6
        Me.BCancelar.Text = "Cancelar"
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'THidden
        '
        Me.THidden.Location = New System.Drawing.Point(-10000, -10000)
        Me.THidden.Name = "THidden"
        Me.THidden.ReadOnly = True
        Me.THidden.ShortcutsEnabled = False
        Me.THidden.Size = New System.Drawing.Size(10, 20)
        Me.THidden.TabIndex = 7
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.R3)
        Me.GroupBox2.Controls.Add(Me.R5)
        Me.GroupBox2.Controls.Add(Me.R2)
        Me.GroupBox2.Controls.Add(Me.R4)
        Me.GroupBox2.Controls.Add(Me.R1)
        Me.GroupBox2.ForeColor = System.Drawing.Color.LightGray
        Me.GroupBox2.Location = New System.Drawing.Point(130, 224)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(276, 90)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Respuesta"
        '
        'R3
        '
        Me.R3.AutoSize = True
        Me.R3.Location = New System.Drawing.Point(16, 65)
        Me.R3.Name = "R3"
        Me.R3.Size = New System.Drawing.Size(127, 17)
        Me.R3.TabIndex = 0
        Me.R3.TabStop = True
        Me.R3.Text = "Reintentar / Cancelar"
        Me.R3.UseVisualStyleBackColor = True
        '
        'R5
        '
        Me.R5.AutoSize = True
        Me.R5.Location = New System.Drawing.Point(152, 42)
        Me.R5.Name = "R5"
        Me.R5.Size = New System.Drawing.Size(112, 17)
        Me.R5.TabIndex = 0
        Me.R5.TabStop = True
        Me.R5.Text = "Si / No / Cancelar"
        Me.R5.UseVisualStyleBackColor = True
        '
        'R2
        '
        Me.R2.AutoSize = True
        Me.R2.Location = New System.Drawing.Point(16, 42)
        Me.R2.Name = "R2"
        Me.R2.Size = New System.Drawing.Size(115, 17)
        Me.R2.TabIndex = 0
        Me.R2.TabStop = True
        Me.R2.Text = "Aceptar / Cancelar"
        Me.R2.UseVisualStyleBackColor = True
        '
        'R4
        '
        Me.R4.AutoSize = True
        Me.R4.Location = New System.Drawing.Point(152, 19)
        Me.R4.Name = "R4"
        Me.R4.Size = New System.Drawing.Size(59, 17)
        Me.R4.TabIndex = 0
        Me.R4.TabStop = True
        Me.R4.Text = "Si / No"
        Me.R4.UseVisualStyleBackColor = True
        '
        'R1
        '
        Me.R1.AutoSize = True
        Me.R1.Checked = True
        Me.R1.Location = New System.Drawing.Point(16, 19)
        Me.R1.Name = "R1"
        Me.R1.Size = New System.Drawing.Size(62, 17)
        Me.R1.TabIndex = 0
        Me.R1.TabStop = True
        Me.R1.Text = "Aceptar"
        Me.R1.UseVisualStyleBackColor = True
        '
        'GTipo
        '
        Me.GTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GTipo.Controls.Add(Me.PIcono4)
        Me.GTipo.Controls.Add(Me.PIcono2)
        Me.GTipo.Controls.Add(Me.PIcono3)
        Me.GTipo.Controls.Add(Me.PIcono1)
        Me.GTipo.ForeColor = System.Drawing.Color.LightGray
        Me.GTipo.Location = New System.Drawing.Point(16, 224)
        Me.GTipo.Name = "GTipo"
        Me.GTipo.Size = New System.Drawing.Size(107, 90)
        Me.GTipo.TabIndex = 9
        Me.GTipo.TabStop = False
        Me.GTipo.Text = "Tipo"
        '
        'PIcono4
        '
        Me.PIcono4.Location = New System.Drawing.Point(70, 56)
        Me.PIcono4.Name = "PIcono4"
        Me.PIcono4.Size = New System.Drawing.Size(20, 20)
        Me.PIcono4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PIcono4.TabIndex = 0
        Me.PIcono4.TabStop = False
        '
        'PIcono2
        '
        Me.PIcono2.Location = New System.Drawing.Point(70, 24)
        Me.PIcono2.Name = "PIcono2"
        Me.PIcono2.Size = New System.Drawing.Size(20, 20)
        Me.PIcono2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PIcono2.TabIndex = 0
        Me.PIcono2.TabStop = False
        '
        'PIcono3
        '
        Me.PIcono3.Location = New System.Drawing.Point(20, 56)
        Me.PIcono3.Name = "PIcono3"
        Me.PIcono3.Size = New System.Drawing.Size(20, 20)
        Me.PIcono3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PIcono3.TabIndex = 0
        Me.PIcono3.TabStop = False
        '
        'PIcono1
        '
        Me.PIcono1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PIcono1.Location = New System.Drawing.Point(16, 20)
        Me.PIcono1.Name = "PIcono1"
        Me.PIcono1.Size = New System.Drawing.Size(28, 28)
        Me.PIcono1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PIcono1.TabIndex = 0
        Me.PIcono1.TabStop = False
        '
        'Gtitulo
        '
        Me.Gtitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Gtitulo.Controls.Add(Me.TTitulo)
        Me.Gtitulo.ForeColor = System.Drawing.Color.LightGray
        Me.Gtitulo.Location = New System.Drawing.Point(16, 31)
        Me.Gtitulo.Name = "Gtitulo"
        Me.Gtitulo.Size = New System.Drawing.Size(390, 35)
        Me.Gtitulo.TabIndex = 10
        Me.Gtitulo.TabStop = False
        Me.Gtitulo.Text = "Título"
        '
        'TTitulo
        '
        Me.TTitulo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.TTitulo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TTitulo.ForeColor = System.Drawing.Color.LightGray
        Me.TTitulo.Location = New System.Drawing.Point(6, 15)
        Me.TTitulo.Name = "TTitulo"
        Me.TTitulo.Size = New System.Drawing.Size(378, 13)
        Me.TTitulo.TabIndex = 0
        Me.TTitulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FMensaje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(422, 386)
        Me.Controls.Add(Me.Gtitulo)
        Me.Controls.Add(Me.GTipo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.THidden)
        Me.Controls.Add(Me.BCancelar)
        Me.Controls.Add(Me.BEnviar)
        Me.Controls.Add(Me.GMensaje)
        Me.Controls.Add(Me.TNombre)
        Me.Controls.Add(Me.LNombre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FMensaje"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enviar Mensaje"
        Me.GMensaje.ResumeLayout(False)
        Me.GMensaje.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GTipo.ResumeLayout(False)
        CType(Me.PIcono4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PIcono2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PIcono3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PIcono1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Gtitulo.ResumeLayout(False)
        Me.Gtitulo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Texto As TextBox
    Friend WithEvents LNombre As Label
    Friend WithEvents TNombre As Label
    Friend WithEvents GMensaje As GroupBox
    Friend WithEvents BEnviar As Button
    Friend WithEvents BCancelar As Button
    Friend WithEvents THidden As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents R3 As RadioButton
    Friend WithEvents R5 As RadioButton
    Friend WithEvents R2 As RadioButton
    Friend WithEvents R4 As RadioButton
    Friend WithEvents R1 As RadioButton
    Friend WithEvents GTipo As GroupBox
    Friend WithEvents PIcono4 As PictureBox
    Friend WithEvents PIcono2 As PictureBox
    Friend WithEvents PIcono1 As PictureBox
    Friend WithEvents PIcono3 As PictureBox
    Friend WithEvents Gtitulo As GroupBox
    Friend WithEvents TTitulo As TextBox
End Class

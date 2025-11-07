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
        Me.CMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MAjustes = New System.Windows.Forms.ToolStripMenuItem()
        Me.MSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'CMenu
        '
        Me.CMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MAjustes, Me.MSeparador1, Me.MSalir})
        Me.CMenu.Name = "Menu"
        Me.CMenu.Size = New System.Drawing.Size(113, 54)
        '
        'MAjustes
        '
        Me.MAjustes.Name = "MAjustes"
        Me.MAjustes.Size = New System.Drawing.Size(112, 22)
        Me.MAjustes.Text = "&Ajustes"
        '
        'MSeparador1
        '
        Me.MSeparador1.Name = "MSeparador1"
        Me.MSeparador1.Size = New System.Drawing.Size(109, 6)
        '
        'MSalir
        '
        Me.MSalir.Name = "MSalir"
        Me.MSalir.Size = New System.Drawing.Size(112, 22)
        Me.MSalir.Text = "&Salir"
        '
        'FMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Cyan
        Me.ClientSize = New System.Drawing.Size(8, 8)
        Me.ControlBox = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(-10000, -10000)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FMenu"
        Me.Opacity = 0R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.TransparencyKey = System.Drawing.Color.Cyan
        Me.CMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CMenu As ContextMenuStrip
    Friend WithEvents MSalir As ToolStripMenuItem
    Friend WithEvents MAjustes As ToolStripMenuItem
    Friend WithEvents MSeparador1 As ToolStripSeparator
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class INICIO
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(INICIO))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CERRARSISTEMAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.INICIARBUSQUEDAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DETENERBUSQUEDAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(229, 151)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(247, 40)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "NUEVO INICIO"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "SCIMIC"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CERRARSISTEMAToolStripMenuItem, Me.INICIARBUSQUEDAToolStripMenuItem, Me.DETENERBUSQUEDAToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(187, 70)
        '
        'CERRARSISTEMAToolStripMenuItem
        '
        Me.CERRARSISTEMAToolStripMenuItem.Image = Global.FacElectronicaVBNet.My.Resources.Resources.close
        Me.CERRARSISTEMAToolStripMenuItem.Name = "CERRARSISTEMAToolStripMenuItem"
        Me.CERRARSISTEMAToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.CERRARSISTEMAToolStripMenuItem.Text = "CERRAR SISTEMA"
        '
        'INICIARBUSQUEDAToolStripMenuItem
        '
        Me.INICIARBUSQUEDAToolStripMenuItem.Image = Global.FacElectronicaVBNet.My.Resources.Resources.power
        Me.INICIARBUSQUEDAToolStripMenuItem.Name = "INICIARBUSQUEDAToolStripMenuItem"
        Me.INICIARBUSQUEDAToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.INICIARBUSQUEDAToolStripMenuItem.Text = "INICIAR BUSQUEDA"
        '
        'DETENERBUSQUEDAToolStripMenuItem
        '
        Me.DETENERBUSQUEDAToolStripMenuItem.Image = Global.FacElectronicaVBNet.My.Resources.Resources._stop
        Me.DETENERBUSQUEDAToolStripMenuItem.Name = "DETENERBUSQUEDAToolStripMenuItem"
        Me.DETENERBUSQUEDAToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.DETENERBUSQUEDAToolStripMenuItem.Text = "DETENER BUSQUEDA"
        '
        'Timer1
        '
        '
        'INICIO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 358)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "INICIO"
        Me.ShowInTaskbar = False
        Me.Text = "SCIMIC"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CERRARSISTEMAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents INICIARBUSQUEDAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DETENERBUSQUEDAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepMaestro
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolStripMaestro = New System.Windows.Forms.ToolStrip()
        Me.TOOLSTRIPITEMIMPRIMIR = New System.Windows.Forms.ToolStripButton()
        Me.CrvMaestro = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.MenuStripMaestro = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMaestro.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMaestro
        '
        Me.ToolStripMaestro.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStripMaestro.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TOOLSTRIPITEMIMPRIMIR})
        Me.ToolStripMaestro.Location = New System.Drawing.Point(0, 467)
        Me.ToolStripMaestro.Name = "ToolStripMaestro"
        Me.ToolStripMaestro.Size = New System.Drawing.Size(580, 25)
        Me.ToolStripMaestro.TabIndex = 0
        Me.ToolStripMaestro.Text = "ToolStrip1"
        '
        'TOOLSTRIPITEMIMPRIMIR
        '
        Me.TOOLSTRIPITEMIMPRIMIR.AutoSize = False
        Me.TOOLSTRIPITEMIMPRIMIR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TOOLSTRIPITEMIMPRIMIR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLSTRIPITEMIMPRIMIR.Name = "TOOLSTRIPITEMIMPRIMIR"
        Me.TOOLSTRIPITEMIMPRIMIR.Size = New System.Drawing.Size(75, 20)
        Me.TOOLSTRIPITEMIMPRIMIR.Text = "Imprimir"
        Me.TOOLSTRIPITEMIMPRIMIR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CrvMaestro
        '
        Me.CrvMaestro.ActiveViewIndex = -1
        Me.CrvMaestro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrvMaestro.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrvMaestro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrvMaestro.Location = New System.Drawing.Point(0, 0)
        Me.CrvMaestro.Name = "CrvMaestro"
        Me.CrvMaestro.ShowCloseButton = False
        Me.CrvMaestro.ShowExportButton = False
        Me.CrvMaestro.ShowGotoPageButton = False
        Me.CrvMaestro.ShowGroupTreeButton = False
        Me.CrvMaestro.ShowParameterPanelButton = False
        Me.CrvMaestro.ShowPrintButton = False
        Me.CrvMaestro.ShowRefreshButton = False
        Me.CrvMaestro.ShowTextSearchButton = False
        Me.CrvMaestro.Size = New System.Drawing.Size(580, 467)
        Me.CrvMaestro.TabIndex = 1
        Me.CrvMaestro.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'MenuStripMaestro
        '
        Me.MenuStripMaestro.Name = "MenuStripMaestro"
        Me.MenuStripMaestro.Size = New System.Drawing.Size(61, 4)
        '
        'FrmRepMaestro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 492)
        Me.Controls.Add(Me.CrvMaestro)
        Me.Controls.Add(Me.ToolStripMaestro)
        Me.KeyPreview = True
        Me.Name = "FrmRepMaestro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStripMaestro.ResumeLayout(False)
        Me.ToolStripMaestro.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMaestro As System.Windows.Forms.ToolStrip
    Friend WithEvents TOOLSTRIPITEMIMPRIMIR As System.Windows.Forms.ToolStripButton
    Friend WithEvents CrvMaestro As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents MenuStripMaestro As System.Windows.Forms.ContextMenuStrip
End Class

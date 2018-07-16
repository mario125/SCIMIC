<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTestResumen
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TXTHASHCDR = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TXTHASHCPE = New System.Windows.Forms.TextBox()
        Me.TXT_MSJ_SUNAT = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXTCOD_SUNAT = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtticket = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(77, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(121, 58)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Test Resumen Boletas"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.TXTHASHCDR)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.TXTHASHCPE)
        Me.GroupBox2.Controls.Add(Me.TXT_MSJ_SUNAT)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.TXTCOD_SUNAT)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 215)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(392, 88)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Respuesta Sunat"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(4, 65)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 13)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "Hash Cdr"
        '
        'TXTHASHCDR
        '
        Me.TXTHASHCDR.Location = New System.Drawing.Point(64, 61)
        Me.TXTHASHCDR.Name = "TXTHASHCDR"
        Me.TXTHASHCDR.Size = New System.Drawing.Size(321, 20)
        Me.TXTHASHCDR.TabIndex = 34
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(4, 44)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 13)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Hash Cpe"
        '
        'TXTHASHCPE
        '
        Me.TXTHASHCPE.Location = New System.Drawing.Point(64, 40)
        Me.TXTHASHCPE.Name = "TXTHASHCPE"
        Me.TXTHASHCPE.Size = New System.Drawing.Size(321, 20)
        Me.TXTHASHCPE.TabIndex = 32
        '
        'TXT_MSJ_SUNAT
        '
        Me.TXT_MSJ_SUNAT.Location = New System.Drawing.Point(103, 19)
        Me.TXT_MSJ_SUNAT.Name = "TXT_MSJ_SUNAT"
        Me.TXT_MSJ_SUNAT.Size = New System.Drawing.Size(282, 20)
        Me.TXT_MSJ_SUNAT.TabIndex = 30
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 13)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "Msj.Sunat"
        '
        'TXTCOD_SUNAT
        '
        Me.TXTCOD_SUNAT.Location = New System.Drawing.Point(64, 19)
        Me.TXTCOD_SUNAT.Name = "TXTCOD_SUNAT"
        Me.TXTCOD_SUNAT.Size = New System.Drawing.Size(37, 20)
        Me.TXTCOD_SUNAT.TabIndex = 29
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(92, 181)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Nro Ticket"
        '
        'txtticket
        '
        Me.txtticket.Location = New System.Drawing.Point(152, 177)
        Me.txtticket.Name = "txtticket"
        Me.txtticket.Size = New System.Drawing.Size(180, 20)
        Me.txtticket.TabIndex = 36
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(152, 95)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(121, 58)
        Me.Button2.TabIndex = 37
        Me.Button2.Text = "Consulta Ticket"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(221, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(121, 58)
        Me.Button3.TabIndex = 38
        Me.Button3.Text = "Test Baja"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'FrmTestResumen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 339)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtticket)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "FrmTestResumen"
        Me.Text = "FrmTestResumen"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TXTHASHCDR As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TXTHASHCPE As TextBox
    Friend WithEvents TXT_MSJ_SUNAT As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TXTCOD_SUNAT As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtticket As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
End Class

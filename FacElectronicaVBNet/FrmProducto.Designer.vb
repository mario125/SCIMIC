<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProducto
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTCODIGO = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CBOUNDMEDIDA = New System.Windows.Forms.ComboBox()
        Me.TXTDESCRIPCION = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTPRECIO = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTCANTIDAD = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTSUBTOTAL = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTIGV = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTTOTAL = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BTNCANCELAR = New System.Windows.Forms.Button()
        Me.BTNACEPTAR = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo"
        '
        'TXTCODIGO
        '
        Me.TXTCODIGO.Location = New System.Drawing.Point(80, 15)
        Me.TXTCODIGO.Name = "TXTCODIGO"
        Me.TXTCODIGO.Size = New System.Drawing.Size(98, 20)
        Me.TXTCODIGO.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(186, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Und/Medida"
        '
        'CBOUNDMEDIDA
        '
        Me.CBOUNDMEDIDA.FormattingEnabled = True
        Me.CBOUNDMEDIDA.Location = New System.Drawing.Point(256, 15)
        Me.CBOUNDMEDIDA.Name = "CBOUNDMEDIDA"
        Me.CBOUNDMEDIDA.Size = New System.Drawing.Size(121, 21)
        Me.CBOUNDMEDIDA.TabIndex = 3
        '
        'TXTDESCRIPCION
        '
        Me.TXTDESCRIPCION.Location = New System.Drawing.Point(80, 38)
        Me.TXTDESCRIPCION.Name = "TXTDESCRIPCION"
        Me.TXTDESCRIPCION.Size = New System.Drawing.Size(297, 20)
        Me.TXTDESCRIPCION.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Descripcion"
        '
        'TXTPRECIO
        '
        Me.TXTPRECIO.Location = New System.Drawing.Point(80, 61)
        Me.TXTPRECIO.Name = "TXTPRECIO"
        Me.TXTPRECIO.Size = New System.Drawing.Size(56, 20)
        Me.TXTPRECIO.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Precio"
        '
        'TXTCANTIDAD
        '
        Me.TXTCANTIDAD.Location = New System.Drawing.Point(201, 61)
        Me.TXTCANTIDAD.Name = "TXTCANTIDAD"
        Me.TXTCANTIDAD.Size = New System.Drawing.Size(56, 20)
        Me.TXTCANTIDAD.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(149, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Cantidad"
        '
        'TXTSUBTOTAL
        '
        Me.TXTSUBTOTAL.Enabled = False
        Me.TXTSUBTOTAL.Location = New System.Drawing.Point(321, 61)
        Me.TXTSUBTOTAL.Name = "TXTSUBTOTAL"
        Me.TXTSUBTOTAL.Size = New System.Drawing.Size(56, 20)
        Me.TXTSUBTOTAL.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(265, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Sub.Total"
        '
        'TXTIGV
        '
        Me.TXTIGV.Enabled = False
        Me.TXTIGV.Location = New System.Drawing.Point(80, 84)
        Me.TXTIGV.Name = "TXTIGV"
        Me.TXTIGV.Size = New System.Drawing.Size(56, 20)
        Me.TXTIGV.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "IGV(18%)"
        '
        'TXTTOTAL
        '
        Me.TXTTOTAL.Enabled = False
        Me.TXTTOTAL.Location = New System.Drawing.Point(201, 84)
        Me.TXTTOTAL.Name = "TXTTOTAL"
        Me.TXTTOTAL.Size = New System.Drawing.Size(56, 20)
        Me.TXTTOTAL.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(149, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Total"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BTNCANCELAR)
        Me.GroupBox1.Controls.Add(Me.BTNACEPTAR)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 119)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(366, 54)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'BTNCANCELAR
        '
        Me.BTNCANCELAR.Location = New System.Drawing.Point(81, 18)
        Me.BTNCANCELAR.Name = "BTNCANCELAR"
        Me.BTNCANCELAR.Size = New System.Drawing.Size(72, 25)
        Me.BTNCANCELAR.TabIndex = 1
        Me.BTNCANCELAR.Text = "Cancelar"
        Me.BTNCANCELAR.UseVisualStyleBackColor = True
        '
        'BTNACEPTAR
        '
        Me.BTNACEPTAR.Location = New System.Drawing.Point(9, 18)
        Me.BTNACEPTAR.Name = "BTNACEPTAR"
        Me.BTNACEPTAR.Size = New System.Drawing.Size(72, 25)
        Me.BTNACEPTAR.TabIndex = 0
        Me.BTNACEPTAR.Text = "Aceptar"
        Me.BTNACEPTAR.UseVisualStyleBackColor = True
        '
        'FrmProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 185)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TXTTOTAL)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TXTIGV)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TXTSUBTOTAL)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TXTCANTIDAD)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TXTPRECIO)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXTDESCRIPCION)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CBOUNDMEDIDA)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TXTCODIGO)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmProducto"
        Me.Text = "Producto"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TXTCODIGO As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CBOUNDMEDIDA As ComboBox
    Friend WithEvents TXTDESCRIPCION As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXTPRECIO As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTCANTIDAD As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TXTSUBTOTAL As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TXTIGV As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TXTTOTAL As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BTNCANCELAR As Button
    Friend WithEvents BTNACEPTAR As Button
End Class

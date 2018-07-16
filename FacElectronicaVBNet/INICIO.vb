Public Class INICIO

    Private Sub INICIO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'notifi(100, " SISTEMA SCIMIC", ".", ToolTipIcon.Info, Color.White, Color.White, Color.White)



    End Sub
    Public Sub notifi(tiempo, mensaje, mensaje2, tipo, color1, color2, color3)
        NotifyIcon1.ShowBalloonTip(tiempo, mensaje, mensaje2, tipo)
        CERRARSISTEMAToolStripMenuItem.BackColor = color1
        DETENERBUSQUEDAToolStripMenuItem.BackColor = color2
        INICIARBUSQUEDAToolStripMenuItem.BackColor = color3

    End Sub


    Private Sub CERRARSISTEMAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CERRARSISTEMAToolStripMenuItem.Click
        'notifi(100, " SISTEMA SCIMIC", "Cerrando  sistema", ToolTipIcon.Info, Color.Tomato, Color.White, Color.White)
        'Application.Exit()
    End Sub

    Private Sub INICIARBUSQUEDAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INICIARBUSQUEDAToolStripMenuItem.Click
        'notifi(100, " SISTEMA SCIMIC", "INICIANDO BUSQUEDA", ToolTipIcon.Info, Color.White, Color.White, Color.Tomato)
        'Timer1.Start()
        'Timer1.Interval = 6000

    End Sub


    Private Sub DETENERBUSQUEDAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DETENERBUSQUEDAToolStripMenuItem.Click
        'notifi(100, " SISTEMA SCIMIC", "DETENER BUSQUEDA", ToolTipIcon.Info, Color.White, Color.Tomato, Color.White)
        'Timer1.Stop()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'enviarsci()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        enviarsci()



    End Sub
End Class
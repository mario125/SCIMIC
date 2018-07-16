Public Class FrmProducto
    Private dictionary As New Dictionary(Of String, String)

    Sub cargarComboUnidadMedia()
        Dim dt As DataTable
        dt = New DataTable("Tabla")

        dt.Columns.Add("Codigo")
        dt.Columns.Add("Descripcion")
        Dim dr As DataRow

        dr = dt.NewRow()
        dr("Codigo") = "NIU"
        dr("Descripcion") = "UNIDADES"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "NIU"
        dr("Descripcion") = "KILOGRAMOS"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "NIU"
        dr("Descripcion") = "LIBRAS"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "NIU"
        dr("Descripcion") = "TONELADAS LARGAS"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "NIU"
        dr("Descripcion") = "TONELADAS METRICAS"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "NIU"
        dr("Descripcion") = "TONELADAS CORTAS"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "NIU"
        dr("Descripcion") = "GRAMOS"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "NIU"
        dr("Descripcion") = "LITROS"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "NIU"
        dr("Descripcion") = "GALONES"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "NIU"
        dr("Descripcion") = "BARRILES"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "NIU"
        dr("Descripcion") = "LATAS"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "NIU"
        dr("Descripcion") = "MILLARES"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "NIU"
        dr("Descripcion") = "METROS CUBICOS"
        dt.Rows.Add(dr)

        CBOUNDMEDIDA.DataSource = dt
        CBOUNDMEDIDA.ValueMember = "Codigo"
        CBOUNDMEDIDA.DisplayMember = "Descripcion"
    End Sub

    Sub calcular()
        Try
            Dim precio, cantidad, igv, sub_total, total As Double
            precio = TXTPRECIO.Text
            cantidad = TXTCANTIDAD.Text
            sub_total = precio * cantidad
            igv = (sub_total * 18) / 100
            total = sub_total + igv
            TXTSUBTOTAL.Text = Format(sub_total, "#0.00")
            TXTIGV.Text = Format(igv, "#0.00")
            TXTTOTAL.Text = Format(total, "#0.00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BotonAgregar()
        Try
            dictionary.Add("CODIGO", TXTCODIGO.Text)
            dictionary.Add("UNIDAD_MEDIDA", CBOUNDMEDIDA.SelectedValue)
            dictionary.Add("DESCRIPCION", TXTDESCRIPCION.Text)
            dictionary.Add("PRECIO", TXTPRECIO.Text)
            dictionary.Add("CANTIDAD", TXTCANTIDAD.Text)
            dictionary.Add("SUB_TOTAL", TXTSUBTOTAL.Text)
            dictionary.Add("IGV", TXTIGV.Text)
            dictionary.Add("IMPORTE", TXTTOTAL.Text)
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Function TraerDatos() As Dictionary(Of String, String)
        Me.ShowDialog()
        Return dictionary
    End Function

    Private Sub FrmProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarComboUnidadMedia()
    End Sub

    Private Sub TXTPRECIO_TextChanged(sender As Object, e As EventArgs) Handles TXTPRECIO.TextChanged
        calcular()
    End Sub

    Private Sub TXTCANTIDAD_TextChanged(sender As Object, e As EventArgs) Handles TXTCANTIDAD.TextChanged
        calcular()
    End Sub

    Private Sub BTNACEPTAR_Click(sender As Object, e As EventArgs) Handles BTNACEPTAR.Click
        BotonAgregar()
    End Sub

    Private Sub CBOUNDMEDIDA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBOUNDMEDIDA.SelectedIndexChanged

    End Sub
End Class
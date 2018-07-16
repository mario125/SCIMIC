

Partial Public Class DTS_COMPROBANTE
    Partial Class COMPROBANTEDataTable
        Private Sub COMPROBANTEDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.PAGINA_COMPROBANTEColumn.ColumnName) Then
                'Agregar código de usuario aquí
            End If

        End Sub

    End Class

End Class

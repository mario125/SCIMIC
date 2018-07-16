Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Windows.Forms
Imports BE = businessEntities
Public Class FrmRepMaestro
    Private vAppGlobalesMetodos As New Metodos
    'Private vObjEntidadComprobante As BusinessEntities.CPE
    'Private vObjEntidadSesion As BusinessEntities.ADM_SESSION
    'Private vObjTipo As Integer = 0
    'Private ws_cpe As ws_cliente.ws_cpe
#Region "Metodos"

    Public Sub TraerReporteComprobante(objCPE As BE.CPE)
        Try
            Dim DtsComprobante As New DTS_COMPROBANTE
            Dim DtrComprobante As DataRow = Nothing
            Dim DtrComprobanteDetalle As DataRow = Nothing
            Dim TIPO_COMPROBANTE_ELE As String

            Dim carpeta As String
            Dim url As String
            If objCPE.TIPO_PROCESO = 1 Then
                carpeta = "PRODUCCION"
            ElseIf objCPE.TIPO_PROCESO = 2 Then
                carpeta = "HOMOLOGACION"
            ElseIf objCPE.TIPO_PROCESO = 3 Then
                carpeta = "BETA"
            End If

            Dim dictionary As New Dictionary(Of String, String)
            dictionary.Add("tipo_comprobante", objCPE.COD_TIPO_DOCUMENTO)
            dictionary.Add("total_comprobante", objCPE.TOTAL.ToString)
            dictionary.Add("cliente", objCPE.RAZON_SOCIAL_CLIENTE)
            dictionary.Add("nro_comprobante", objCPE.NRO_COMPROBANTE)
            dictionary.Add("nombre_cod_barra", objCPE.NRO_DOCUMENTO_EMPRESA & "-" & objCPE.COD_TIPO_DOCUMENTO & "-" & objCPE.NRO_COMPROBANTE)
            dictionary.Add("ruta", objCPE.RUTA_CODIGO_BARRA)
            'vAppGlobalesMetodos.generarPDF147(dictionary)
            vAppGlobalesMetodos.GenerarQR(dictionary)

            'If objCPE..Count > 0 Then
            Dim nom_codigo_barra As String
            nom_codigo_barra = objCPE.NRO_DOCUMENTO_EMPRESA.ToString & "-" & objCPE.COD_TIPO_DOCUMENTO & "-" & objCPE.NRO_COMPROBANTE.ToString


            If objCPE.COD_TIPO_DOCUMENTO = "01" Then
                TIPO_COMPROBANTE_ELE = "FACTURA ELECTRONICA"
            ElseIf objCPE.COD_TIPO_DOCUMENTO = "03" Then
                TIPO_COMPROBANTE_ELE = "BOLETA DE VENTA ELECTRONICA"
            ElseIf objCPE.COD_TIPO_DOCUMENTO = "07" Then
                TIPO_COMPROBANTE_ELE = "NOTA CREDITO ELECTRONICA"
            ElseIf objCPE.COD_TIPO_DOCUMENTO = "08" Then
                TIPO_COMPROBANTE_ELE = "NOTA DEBITO ELECTRONICA"
            End If

            Dim TIPO_COMPROBANTE_ELE_MODIFICA As String
            If objCPE.TIPO_COMPROBANTE_MODIFICA = "01" Then
                TIPO_COMPROBANTE_ELE_MODIFICA = "FACTURA ELECTRONICA"
            ElseIf objCPE.TIPO_COMPROBANTE_MODIFICA = "03" Then
                TIPO_COMPROBANTE_ELE_MODIFICA = "BOLETA DE VENTA ELECTRONICA"
            End If

            DtrComprobante = DtsComprobante.Tables("COMPROBANTE").NewRow
            DtrComprobante("ADM_EMPRESA.DESCRIPCION") = objCPE.RAZON_SOCIAL_EMPRESA  'vObjEntidadSesion.DESCRIPCION_EMPRESA
            DtrComprobante("ADM_DIVISION.DESCRIPCION") = ""
            'DtrComprobante("ADM_SUCURSAL.DESCRIPCION") = objCPE.COD_SUCURSAL.ToString
            DtrComprobante("VEN_TIPO_DOCUMENTO.DESCRIPCION") = TIPO_COMPROBANTE_ELE
            'DtrComprobante("VEN_COMPROBANTE.SERIE") = objCPE.SERIE
            'DtrComprobante("VEN_COMPROBANTE.NUMERO") = objCPE.NUMERO
            DtrComprobante("VEN_COMPROBANTE.NRO_COMPROBANTE") = objCPE.NRO_COMPROBANTE
            DtrComprobante("VEN_COMPROBANTE.FECHA_EMISION") = objCPE.FECHA_DOCUMENTO
            DtrComprobante("VEN_COMPROBANTE.FECHA_VENCIMIENTO") = objCPE.FECHA_DOCUMENTO
            DtrComprobante("VEN_CLIENTE.DOCUMENTO_IDENTIDAD_NUMERO") = objCPE.NRO_DOCUMENTO_CLIENTE
            DtrComprobante("VEN_CLIENTE.RAZON_SOCIAL") = objCPE.RAZON_SOCIAL_CLIENTE
            DtrComprobante("ADM_UBIGEO.DESCRIPCION") = objCPE.DEPARTAMENTO_EMPRESA.ToString & "-" & objCPE.PROVINCIA_EMPRESA.ToString & "-" & objCPE.DISTRITO_EMPRESA.ToString
            DtrComprobante("VEN_CLIENTE.DIRECCION_FISCAL") = objCPE.DIRECCION_CLIENTE.ToString
            DtrComprobante("VEN_COMPROBANTE.ORDEN_COMPRA") = ""
            DtrComprobante("VEN_COMPROBANTE.GUIA_REMISION") = objCPE.NRO_GUIA_REMISION
            DtrComprobante("VEN_COMPROBANTE.PEDIDO") = ""
            DtrComprobante("VEN_COMPROBANTE.SUBTOTAL") = objCPE.SUB_TOTAL
            DtrComprobante("VEN_COMPROBANTE.TOTAL_GRAVADAS") = objCPE.TOTAL_GRAVADAS
            DtrComprobante("VEN_COMPROBANTE.TOTAL_INAFECTA") = objCPE.TOTAL_INAFECTA
            DtrComprobante("VEN_COMPROBANTE.TOTAL_EXONERADAS") = objCPE.TOTAL_EXONERADAS
            DtrComprobante("VEN_COMPROBANTE.TOTAL_GRATUITAS") = objCPE.TOTAL_GRATUITAS
            DtrComprobante("VEN_COMPROBANTE.TOTAL_PERCEPCIONES") = objCPE.TOTAL_PERCEPCIONES
            DtrComprobante("VEN_COMPROBANTE.TOTAL_RETENCIONES") = objCPE.TOTAL_RETENCIONES
            DtrComprobante("VEN_COMPROBANTE.TOTAL_DETRACCIONES") = objCPE.TOTAL_DETRACCIONES
            DtrComprobante("VEN_COMPROBANTE.TOTAL_BONIFICACIONES") = objCPE.TOTAL_BONIFICACIONES



            DtrComprobante("VEN_COMPROBANTE.PORCENTAJE_IGV") = 18
            DtrComprobante("VEN_COMPROBANTE.IGV") = objCPE.TOTAL_IGV
            DtrComprobante("TOTAL_ISC") = objCPE.TOTAL_ISC
            DtrComprobante("VEN_COMPROBANTE.PORCENTAJE_RETENCION") = 0
            DtrComprobante("VEN_COMPROBANTE.RETENCION") = objCPE.TOTAL_RETENCIONES
            DtrComprobante("VEN_COMPROBANTE.PORCENTAJE_PERCEPCION") = "0"
            DtrComprobante("VEN_COMPROBANTE.PERCEPCION") = objCPE.TOTAL_PERCEPCIONES
            DtrComprobante("VEN_COMPROBANTE.PORCENTAJE_DESCUENTO") = 0
            DtrComprobante("VEN_COMPROBANTE.TOTAL_DESCUENTO") = objCPE.TOTAL_DESCUENTO
            DtrComprobante("VEN_COMPROBANTE.TOTAL") = objCPE.TOTAL
            DtrComprobante("VEN_COMPROBANTE.GLOSA") = objCPE.GLOSA
            DtrComprobante("TOTAL_LETRAS") = objCPE.TOTAL_LETRAS
            DtrComprobante("HASH_CPE") = objCPE.HASH_CPE
            '=======================DATOS COMPROBANTE MODIFICA======================
            If objCPE.COD_TIPO_DOCUMENTO = "07" Or objCPE.COD_TIPO_DOCUMENTO = "08" Then
                DtrComprobante("TIPO_DOCU_MODIFICA") = objCPE.TIPO_COMPROBANTE_MODIFICA & "-" & TIPO_COMPROBANTE_ELE_MODIFICA
                DtrComprobante("NUMERO_DOCU_MODIFICA") = objCPE.NRO_DOCUMENTO_MODIFICA.ToString
                DtrComprobante("COD_MOTIVO_MODIFICA") = objCPE.COD_TIPO_MOTIVO.ToString
                DtrComprobante("MOTIVO_MODIFICA") = objCPE.DESCRIPCION_MOTIVO.ToString
            End If
            DtrComprobante("CODIGO_BARRA") = vAppGlobalesMetodos.ConversionImagen(objCPE.RUTA_CODIGO_BARRA) 'vAppGlobalesMetodos.ConversionImagen("D:\CPE\CODIGOBARRA\" & nom_codigo_barra & ".BMP")
            DtrComprobante("LOGO") = vAppGlobalesMetodos.ConversionImagen("D:\\CPE\\CODIGOBARRA\\logo.BMP") 'vAppGlobalesMetodos.ConversionImagen("D:\CPE\CODIGOBARRA\" & nom_codigo_barra & ".BMP")
            DtrComprobante("TELEFONO") = objCPE.TELEFONO_PRINCIPAL.ToString
            DtrComprobante("DIRECCION_EMPRESA") = objCPE.DIRECCION_EMPRESA.ToString
            DtrComprobante("EMP_RUC") = objCPE.NRO_DOCUMENTO_EMPRESA.ToString

            DtrComprobante("TOTAL") = objCPE.TOTAL.ToString

            If objCPE.COD_MONEDA = "PEN" Then
                DtrComprobante("MI_MONEY") = "SOLES"
            Else
                DtrComprobante("MI_MONEY") = "DOLARES"
            End If



            DtrComprobante("PAGINA_COMPROBANTE") = "www.scimic.net"
            DtsComprobante.Tables("COMPROBANTE").Rows.Add(DtrComprobante)

            '============================DETALLE=======================
            For X As Integer = 0 To objCPE.detalle.Count - 1 'tbl.Rows.Count - 1
                DtrComprobanteDetalle = DtsComprobante.Tables("COMPROBANTE_DETALLE").NewRow
                DtrComprobanteDetalle("VEN_COMPROBANTE_DETALLE.ITEM") = objCPE.detalle(X).ITEM.ToString
                DtrComprobanteDetalle("INV_ARTICULO.CODIGO") = objCPE.detalle(X).CODIGO.ToString
                DtrComprobanteDetalle("INV_ARTICULO.REFERENCIA") = ""
                DtrComprobanteDetalle("VEN_COMPROBANTE_DETALLE.DESCRIPCION") = objCPE.detalle(X).DESCRIPCION.ToString
                DtrComprobanteDetalle("ADM_MONEDA.ABREVIATURA") = objCPE.COD_MONEDA.ToString
                DtrComprobanteDetalle("VEN_COMPROBANTE_DETALLE.PRECIO_VENTA") = objCPE.detalle(X).PRECIO.ToString
                DtrComprobanteDetalle("INV_UNIDAD_MEDIDA.ABREVIATURA") = objCPE.detalle(X).UNIDAD_MEDIDA.ToString
                DtrComprobanteDetalle("VEN_COMPROBANTE_DETALLE.CANTIDAD") = objCPE.detalle(X).CANTIDAD.ToString
                DtrComprobanteDetalle("VEN_COMPROBANTE_DETALLE.IMPORTE") = objCPE.detalle(X).IMPORTE.ToString
                DtrComprobanteDetalle("VEN_COMPROBANTE_DETALLE.GLOSA") = ""
                DtsComprobante.Tables("COMPROBANTE_DETALLE").Rows.Add(DtrComprobanteDetalle)
            Next
            'End If

            Dim nom_pdf As String
            nom_pdf = objCPE.NRO_DOCUMENTO_EMPRESA.ToString & "-" & objCPE.COD_TIPO_DOCUMENTO.ToString & "-" & objCPE.NRO_COMPROBANTE.ToString

            'Mostrar el Reporte de Comprobante
            Dim ObjReporteComprobante As Object 'New RPT_COMPROBANTE
            If objCPE.COD_TIPO_DOCUMENTO.ToString = "01" Or objCPE.COD_TIPO_DOCUMENTO.ToString = "03" Then

                For i As Integer = 1 To 2
                    If i = 1 Then
                        ObjReporteComprobante = New RPT_COMPROBANTE
                        ObjReporteComprobante.SetDataSource(DtsComprobante)
                        CrvMaestro.ReportSource = ObjReporteComprobante
                        CrvMaestro.Zoom(75)

                        Dim CrExportOptions As ExportOptions
                        Dim CrDiskFileDestinationOptions As New _
                    DiskFileDestinationOptions()
                        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
                        CrDiskFileDestinationOptions.DiskFileName = objCPE.RUTA_PDF
                        CrExportOptions = ObjReporteComprobante.ExportOptions
                        With CrExportOptions
                            .ExportDestinationType = ExportDestinationType.DiskFile
                            .ExportFormatType = ExportFormatType.PortableDocFormat
                            .DestinationOptions = CrDiskFileDestinationOptions
                            .FormatOptions = CrFormatTypeOptions
                        End With
                        ObjReporteComprobante.Export()

                    ElseIf i = 2 Then
                        ObjReporteComprobante = New RPT_COMPROBANTE
                        ObjReporteComprobante.SetDataSource(DtsComprobante)
                        CrvMaestro.ReportSource = ObjReporteComprobante
                        CrvMaestro.Zoom(75)

                        Dim CrExportOptions As ExportOptions
                        Dim CrDiskFileDestinationOptions As New _
                    DiskFileDestinationOptions()
                        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
                        CrDiskFileDestinationOptions.DiskFileName = objCPE.RUTA_PDF_2_NUVE
                        CrExportOptions = ObjReporteComprobante.ExportOptions
                        With CrExportOptions
                            .ExportDestinationType = ExportDestinationType.DiskFile
                            .ExportFormatType = ExportFormatType.PortableDocFormat
                            .DestinationOptions = CrDiskFileDestinationOptions
                            .FormatOptions = CrFormatTypeOptions
                        End With
                        ObjReporteComprobante.Export()
                    End If
                Next

            ElseIf objCPE.COD_TIPO_DOCUMENTO.ToString = "07" Or objCPE.COD_TIPO_DOCUMENTO.ToString = "08" Then
                '___________________________________________
            End If
            ' Me.ShowDialog()
        Catch ex As Exception
            'GrabarArchivoLog(ex)
        End Try
    End Sub

    Private Sub TraerBotonesToolBar(ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
        Select Case e.ClickedItem.Name
            Case "TOOLSTRIPITEMIMPRIMIR"
                Call BotonImprimir()
        End Select
    End Sub
#End Region
#Region "Mantenimiento"
    Private Sub BotonConfirmar()
        Try
            CrvMaestro.PrintReport()
            Me.Close()
        Catch ex As Exception
            'GrabarArchivoLog(ex)
        End Try
    End Sub

    Private Sub BotonImprimir()
        CrvMaestro.PrintReport()
    End Sub
#End Region

    Private Sub ToolStripMaestro_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStripMaestro.ItemClicked
        Call TraerBotonesToolBar(e)
    End Sub
    Private Sub MenuStripMaestro_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStripMaestro.ItemClicked
        Call TraerBotonesToolBar(e)
    End Sub

    Private Sub FrmRepMaestro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
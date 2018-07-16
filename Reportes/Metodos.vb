Imports BE = businessEntities
Imports System.Drawing
Imports System.IO
Imports iTextSharp.text.pdf
Imports ThoughtWorks.QRCode
Imports ThoughtWorks.QRCode.Codec
Imports CrystalDecisions.Shared

Public Class Metodos

    Public Sub generarPDF147(obj As Dictionary(Of String, String))
        Dim contenido As String
        Dim pdf147 As New BarcodePDF417
        Dim myBitmap As System.Drawing.Bitmap

        Dim tipo_comprobante As String
        Dim total_comprobante As String
        Dim razon_cliente As String
        Dim nro_comprobante As String
        Dim ruta As String

        tipo_comprobante = obj.Item("tipo_comprobante")
        total_comprobante = obj.Item("total_comprobante")
        razon_cliente = obj.Item("cliente")
        nro_comprobante = obj.Item("nro_comprobante")
        ruta = obj.Item("ruta")

        pdf147.Options = BarcodePDF417.PDF417_USE_ASPECT_RATIO
        pdf147.ErrorLevel = 8
        contenido = "Numero Comprobante: " & nro_comprobante & "|Tipo Comprobante: " & tipo_comprobante & "|Total Documento: " & total_comprobante & "|RUC Cliente: " & razon_cliente
        pdf147.SetText(contenido)
        myBitmap = New System.Drawing.Bitmap(pdf147.CreateDrawingImage(Color.Black, Color.White))
        'myBitmap.Save(Application.StartupPath & "\archivos\" & obj.Item("nombre_cod_barra") & ".BMP")
        myBitmap.Save(ruta)
    End Sub

    Public Sub GenerarQR(obj As Dictionary(Of String, String))
        Dim generarCodigoQR As QRCodeEncoder = New QRCodeEncoder
        generarCodigoQR.QRCodeEncodeMode = Codec.QRCodeEncoder.ENCODE_MODE.BYTE
        generarCodigoQR.QRCodeScale = Int32.Parse(4)

        'Select Case lsNivelCorreccion.Text
        '    Case "Bajo (7%)"
        '        generarCodigoQR.QRCodeErrorCorrect =
        '                Codec.QRCodeEncoder.ERROR_CORRECTION.L
        '    Case "Medio (15%)"
        generarCodigoQR.QRCodeErrorCorrect = Codec.QRCodeEncoder.ERROR_CORRECTION.M
        '    Case "Alto (25%)"
        '        generarCodigoQR.QRCodeErrorCorrect =
        '                Codec.QRCodeEncoder.ERROR_CORRECTION.Q
        '    Case "Muy alto (30%)"
        'generarCodigoQR.QRCodeErrorCorrect = Codec.QRCodeEncoder.ERROR_CORRECTION.H
        'End Select

        'La versión "0" calcula automáticamente el tamaño
        generarCodigoQR.QRCodeVersion = 0

        '' -----------------------------------------------------
        Dim contenido As String
        Dim tipo_comprobante As String
        Dim total_comprobante As String
        Dim razon_cliente As String
        Dim nro_comprobante As String
        Dim ruta As String

        tipo_comprobante = obj.Item("tipo_comprobante")
        total_comprobante = obj.Item("total_comprobante")
        razon_cliente = obj.Item("cliente")
        nro_comprobante = obj.Item("nro_comprobante")
        ruta = obj.Item("ruta")
        contenido = "Numero Comprobante: " & nro_comprobante & "|Tipo Comprobante: " & tipo_comprobante & "|Total Documento: " & total_comprobante & "|RUC Cliente: " & razon_cliente

        Dim imgQR As System.Drawing.Bitmap
        Try
            ' If opForzarUTF.Checked Then
            'Con UTF-8 podremos añadir caracteres como ñ, tildes, etc.

            imgQR = New System.Drawing.Bitmap(generarCodigoQR.Encode(contenido, System.Text.Encoding.UTF8))
            imgQR.Save(ruta)
            'Else
            '    imgQR.Image = generarCodigoQR.Encode(txtTextoQR.Text)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
        End Try


    End Sub

    Public Function ConversionImagen(nombrearchivo As String) As Byte()
        'Declaramos fs para poder abrir la imagen.
        Dim fs As New FileStream(nombrearchivo, FileMode.Open)
        Dim imgLength As Integer = CInt(fs.Length)
        Dim bytes(0 To imgLength - 1) As Byte
        fs.Read(bytes, 0, imgLength)
        fs.Close()
        Return bytes
    End Function

    Public Function ValidarCaracteresInv(texto As String) As String
        Dim cadena As String = texto
        cadena = cadena.Replace("!", "")
        '//cadena = cadena.replace("'"""'","");
        cadena = cadena.Replace("#", "")
        cadena = cadena.Replace("$", "")
        cadena = cadena.Replace("%", "")
        cadena = cadena.Replace("&", "")
        cadena = cadena.Replace("'", "")
        cadena = cadena.Replace("(", "")
        cadena = cadena.Replace(")", "")
        cadena = cadena.Replace("*", "")
        cadena = cadena.Replace("+", "")
        '//cadena = cadena.replace(",", "")
        cadena = cadena.Replace("-", "")
        cadena = cadena.Replace(".", "")
        cadena = cadena.Replace("/", "")
        cadena = cadena.Replace("<", "")
        cadena = cadena.Replace("=", "")
        cadena = cadena.Replace(">", "")
        cadena = cadena.Replace("?", "")
        cadena = cadena.Replace("@", "")
        cadena = cadena.Replace("[", "")
        cadena = cadena.Replace("\\", "")
        cadena = cadena.Replace("]", "")
        cadena = cadena.Replace("^", "")
        cadena = cadena.Replace("_", "")
        cadena = cadena.Replace("`", "")
        cadena = cadena.Replace("{", "")
        cadena = cadena.Replace("|", "")
        cadena = cadena.Replace("}", "")
        cadena = cadena.Replace("~", "")
        cadena = cadena.Replace("¡", "")
        cadena = cadena.Replace("¢", "")
        cadena = cadena.Replace("£", "")
        cadena = cadena.Replace("¤", "")
        cadena = cadena.Replace("¥", "")
        cadena = cadena.Replace("¦", "")
        cadena = cadena.Replace("§", "")
        cadena = cadena.Replace("¨", "")
        cadena = cadena.Replace("©", "")
        cadena = cadena.Replace("ª", "")
        cadena = cadena.Replace("«", "")
        cadena = cadena.Replace("¬", "")
        cadena = cadena.Replace("®", "")
        cadena = cadena.Replace("°", "")
        cadena = cadena.Replace("±", "")
        cadena = cadena.Replace("²", "")
        cadena = cadena.Replace("³", "")
        cadena = cadena.Replace("´", "")
        cadena = cadena.Replace("µ", "")
        cadena = cadena.Replace("¶", "")
        cadena = cadena.Replace("·", "")
        cadena = cadena.Replace("¸", "")
        cadena = cadena.Replace("¹", "")
        cadena = cadena.Replace("º", "")
        cadena = cadena.Replace("»", "")
        cadena = cadena.Replace("¼", "")
        cadena = cadena.Replace("½", "")
        cadena = cadena.Replace("¾", "")
        cadena = cadena.Replace("¿", "")
        cadena = cadena.Replace("À", "A")
        cadena = cadena.Replace("Á", "A")
        cadena = cadena.Replace("Â", "A")
        cadena = cadena.Replace("Ã", "A")
        cadena = cadena.Replace("Ä", "A")
        cadena = cadena.Replace("Å", "A")
        cadena = cadena.Replace("Æ", "")
        cadena = cadena.Replace("Ç", "")
        cadena = cadena.Replace("È", "E")
        cadena = cadena.Replace("É", "E")
        cadena = cadena.Replace("Ê", "E")
        cadena = cadena.Replace("Ë", "E")
        cadena = cadena.Replace("Ì", "I")
        cadena = cadena.Replace("Í", "I")
        cadena = cadena.Replace("Î", "I")
        cadena = cadena.Replace("Ï", "I")
        cadena = cadena.Replace("Ð", "")
        cadena = cadena.Replace("Ñ", "N")
        cadena = cadena.Replace("Ò", "O")
        cadena = cadena.Replace("Ó", "O")
        cadena = cadena.Replace("Ô", "O")
        cadena = cadena.Replace("Õ", "O")
        cadena = cadena.Replace("Ö", "O")
        cadena = cadena.Replace("×", "")
        cadena = cadena.Replace("Ø", "")
        cadena = cadena.Replace("Ù", "U")
        cadena = cadena.Replace("Ú", "U")
        cadena = cadena.Replace("Û", "U")
        cadena = cadena.Replace("Ü", "U")
        cadena = cadena.Replace("Ý", "Y")
        cadena = cadena.Replace("Þ", "")
        cadena = cadena.Replace("ß", "")
        cadena = cadena.Replace("à", "a")
        cadena = cadena.Replace("á", "a")
        cadena = cadena.Replace("â", "a")
        cadena = cadena.Replace("ã", "a")
        cadena = cadena.Replace("ä", "a")
        cadena = cadena.Replace("å", "a")
        cadena = cadena.Replace("æ", "")
        cadena = cadena.Replace("ç", "")
        cadena = cadena.Replace("è", "e")
        cadena = cadena.Replace("é", "e")
        cadena = cadena.Replace("ê", "e")
        cadena = cadena.Replace("ë", "e")
        cadena = cadena.Replace("ì", "i")
        cadena = cadena.Replace("í", "i")
        cadena = cadena.Replace("î", "i")
        cadena = cadena.Replace("ï", "i")
        cadena = cadena.Replace("ð", "o")
        cadena = cadena.Replace("ñ", "n")
        cadena = cadena.Replace("ò", "o")
        cadena = cadena.Replace("ó", "o")
        cadena = cadena.Replace("ô", "o")
        cadena = cadena.Replace("õ", "o")
        cadena = cadena.Replace("ö", "o")
        cadena = cadena.Replace("÷", "")
        cadena = cadena.Replace("ø", "")
        cadena = cadena.Replace("ù", "u")
        cadena = cadena.Replace("ú", "u")
        cadena = cadena.Replace("û", "u")
        cadena = cadena.Replace("ü", "u")
        cadena = cadena.Replace("ý", "y")
        cadena = cadena.Replace("þ", "")
        cadena = cadena.Replace("ÿ", "")
        cadena = cadena.Replace("Œ", "")
        cadena = cadena.Replace("œ", "")
        cadena = cadena.Replace("Š", "")
        cadena = cadena.Replace("š", "")
        cadena = cadena.Replace("Ÿ", "")
        cadena = cadena.Replace("ƒ", "")
        cadena = cadena.Replace("–", "")
        cadena = cadena.Replace("—", "")
        cadena = cadena.Replace("‘", "")
        cadena = cadena.Replace("’", "")
        cadena = cadena.Replace("‚", "")
        cadena = cadena.Replace("“", "")
        cadena = cadena.replace("”", "")
        cadena = cadena.Replace("„", "")
        cadena = cadena.Replace("†", "")
        cadena = cadena.Replace("‡", "")
        cadena = cadena.Replace("•", "")
        cadena = cadena.Replace("…", "")
        cadena = cadena.Replace("‰", "")
        cadena = cadena.Replace("€", "")
        cadena = cadena.Replace("™", "")
        Return cadena
    End Function


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
            'dictionary.Add("nombre_cod_barra", objCPE.NRO_DOCUMENTO_EMPRESA & "-" & objCPE.COD_TIPO_DOCUMENTO & "-" & objCPE.NRO_COMPROBANTE)
            dictionary.Add("ruta", objCPE.RUTA_CODIGO_BARRA)
            'generarPDF147(dictionary)
            GenerarQR(dictionary)

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
            DtrComprobante("VEN_COMPROBANTE.SUBTOTAL") = objCPE.TOTAL_GRAVADAS
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
            DtrComprobante("CODIGO_BARRA") = ConversionImagen(objCPE.RUTA_CODIGO_BARRA) 'vAppGlobalesMetodos.ConversionImagen("D:\CPE\CODIGOBARRA\" & nom_codigo_barra & ".BMP")
            DtrComprobante("PAGINA_COMPROBANTE") = "www.facturacionelectronica.us"
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

                ObjReporteComprobante = New RPT_COMPROBANTE
                ObjReporteComprobante.SetDataSource(DtsComprobante)



                For index As Integer = 1 To 2




                Next



                ' _____________________________________________________
            End If
        Catch ex As Exception
            'GrabarArchivoLog(ex)
        End Try
    End Sub

End Class

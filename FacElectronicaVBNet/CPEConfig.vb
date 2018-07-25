Imports BE = BusinessEntities
Imports EV = CPEEnvio
Imports XM = CrearXML
Imports SG = Signature
Imports RT = Reportes
Public Class CPEConfig

    Dim objXML As New XM.CrearXML
    Dim objPregunta As New SG.FirmadoRequest
    Dim objRespuesta As New SG.FirmadoResponse
    Dim objSignature As New SG.Signature
    Dim objENV As New EV.ServiceSunat

    Public Function envio(CPE As BE.CPE) As Dictionary(Of String, String)
        Dim dictionary As Dictionary(Of String, String)
        Dim nomARCHIVO As String
        Dim nomBRE_AR_NUVE As String
        Dim ruta As String
        Dim rutaFirma As String
        Dim url As String
        '======================validamos algunos valores xml====================
        CPE.TOTAL_GRAVADAS = NZ(CPE.TOTAL_GRAVADAS)
        CPE.TOTAL_INAFECTA = NZ(CPE.TOTAL_INAFECTA)
        CPE.TOTAL_EXONERADAS = NZ(CPE.TOTAL_EXONERADAS)
        CPE.TOTAL_GRATUITAS = NZ(CPE.TOTAL_GRATUITAS)
        CPE.TOTAL_PERCEPCIONES = NZ(CPE.TOTAL_PERCEPCIONES)
        CPE.TOTAL_RETENCIONES = NZ(CPE.TOTAL_RETENCIONES)
        CPE.TOTAL_DETRACCIONES = NZ(CPE.TOTAL_DETRACCIONES)
        CPE.TOTAL_BONIFICACIONES = NZ(CPE.TOTAL_BONIFICACIONES)
        CPE.TOTAL_DESCUENTO = NZ(CPE.TOTAL_DESCUENTO)

        nomARCHIVO = CPE.NRO_DOCUMENTO_EMPRESA & "-" & CPE.COD_TIPO_DOCUMENTO & "-" & CPE.NRO_COMPROBANTE

        nomBRE_AR_NUVE = CPE.NRO_DOCUMENTO_CLIENTE & "-" & CPE.COD_TIPO_DOCUMENTO & "-" & CPE.NRO_COMPROBANTE

        If (CPE.TIPO_PROCESO = 3) Then
            '===================configuracion de rutas===================
            ruta = "D:\\CPE\\BETA\\"
            rutaFirma = "D:\\CPE\\FIRMABETA\\FIRMABETA.pfx"
            url = "https://e-beta.sunat.gob.pe:443/ol-ti-itcpfegem-beta/billService"
            '===================creamos xml(comprobante)====================
            If CPE.COD_TIPO_DOCUMENTO = "01" Or CPE.COD_TIPO_DOCUMENTO = "03" Then
                objXML.CPE(CPE, nomARCHIVO, ruta)
            ElseIf CPE.COD_TIPO_DOCUMENTO = "07" Then
                objXML.CPE_NC(CPE, nomARCHIVO, ruta)
            ElseIf CPE.COD_TIPO_DOCUMENTO = "08" Then
                objXML.CPE_ND(CPE, nomARCHIVO, ruta)
            End If
            '=================datos para la firma====================
            objPregunta.ruta_Firma = rutaFirma
            objPregunta.contra_Firma = CPE.CONTRA_FIRMA
            objPregunta.ruta_xml = ruta & nomARCHIVO & ".XML"
            objPregunta.flg_firma = 1
            objRespuesta = objSignature.FirmaXMl(objPregunta)
            '====================creamos pdf====================
            Dim RptPDF As New RT.FrmRepMaestro
            'Dim RptPDF As New RT.Metodos
            CPE.HASH_CPE = objRespuesta.DigestValue
            CPE.RUTA_CODIGO_BARRA = "D:\\CPE\\CODIGOBARRA\\" & nomARCHIVO & ".BMP"
            CPE.RUTA_PDF = "D:\\CPE\\PRODUCCION\\" & nomARCHIVO & ".PDF"
            CPE.RUTA_PDF_2_NUVE = "D:\\CPE\\NUVE\\" & nomBRE_AR_NUVE & ".PDF"
            RptPDF.TraerReporteComprobante(CPE)
            '====================enviamos documento a la sunat=========================
            'dictionary = objENV.Envio(CPE.NRO_DOCUMENTO_EMPRESA, CPE.USUARIO_SOL_EMPRESA, CPE.PASS_SOL_EMPRESA, nomARCHIVO, ruta, url, objRespuesta.DigestValue)
        End If
        If (CPE.TIPO_PROCESO = 2) Then
            '===================configuracion de rutas===================
            ruta = "D:\\CPE\\HOMOLOGACION\\"
            rutaFirma = "D:\\CPE\\FIRMA\\" & CPE.NRO_DOCUMENTO_EMPRESA & ".pfx"
            url = "https://www.sunat.gob.pe/ol-ti-itcpgem-sqa/billService"
            '===================creamos xml(comprobante)====================
            If CPE.COD_TIPO_DOCUMENTO = "01" Or CPE.COD_TIPO_DOCUMENTO = "03" Then
                objXML.CPE(CPE, nomARCHIVO, ruta)
            ElseIf CPE.COD_TIPO_DOCUMENTO = "07" Then
                objXML.CPE_NC(CPE, nomARCHIVO, ruta)
            ElseIf CPE.COD_TIPO_DOCUMENTO = "08" Then
                objXML.CPE_ND(CPE, nomARCHIVO, ruta)
            End If
            '=================datos para la firma====================
            objPregunta.ruta_Firma = rutaFirma
            objPregunta.contra_Firma = CPE.CONTRA_FIRMA
            objPregunta.ruta_xml = ruta & nomARCHIVO & ".XML"
            objPregunta.flg_firma = 1
            objRespuesta = objSignature.FirmaXMl(objPregunta)
            '====================creamos pdf====================
            'Dim RptPDF As New RT.FrmRepMaestro
            Dim RptPDF As New RT.Metodos
            CPE.HASH_CPE = objRespuesta.DigestValue
            CPE.RUTA_CODIGO_BARRA = "D:\\CPE\\CODIGOBARRA\\" & nomARCHIVO & ".BMP"
            CPE.RUTA_PDF = "D:\\CPE\\BETA\\" & nomARCHIVO & ".PDF"
            RptPDF.TraerReporteComprobante(CPE)
            '====================enviamos documento a la sunat=========================
            dictionary = objENV.Envio(CPE.NRO_DOCUMENTO_EMPRESA, CPE.USUARIO_SOL_EMPRESA, CPE.PASS_SOL_EMPRESA, nomARCHIVO, ruta, url, objRespuesta.DigestValue)
        End If
        If (CPE.TIPO_PROCESO = 1) Then


            '_________________________________________________________________
            ruta = "D:\\CPE\\PRODUCCION\\"
            rutaFirma = "D:\\CPE\\FIRMA\\YXBnNWdiNmhDenlOUXBVTA==.pfx"
            'rutaFirma = "D:\\CPE\\FIRMABETA\\FIRMABETA.pfx"
            url = "https://e-factura.sunat.gob.pe/ol-ti-itcpfegem/billService"
            '===================creamos xml(comprobante)===================
            If CPE.COD_TIPO_DOCUMENTO = "01" Or CPE.COD_TIPO_DOCUMENTO = "03" Then
                objXML.CPE(CPE, nomARCHIVO, ruta)
            ElseIf CPE.COD_TIPO_DOCUMENTO = "07" Then
                objXML.CPE_NC(CPE, nomARCHIVO, ruta)
            ElseIf CPE.COD_TIPO_DOCUMENTO = "08" Then
                objXML.CPE_ND(CPE, nomARCHIVO, ruta)
            End If
            '=================datos para la firma====================
            objPregunta.ruta_Firma = rutaFirma
            objPregunta.contra_Firma = CPE.CONTRA_FIRMA
            objPregunta.ruta_xml = ruta & nomARCHIVO & ".XML"
            objPregunta.flg_firma = 1
            objRespuesta = objSignature.FirmaXMl(objPregunta)
            '====================creamos pdf====================
            'Dim RptPDF As New RT.FrmRepMaestro
            Dim RptPDF As New RT.FrmRepMaestro
            CPE.HASH_CPE = objRespuesta.DigestValue
            CPE.RUTA_CODIGO_BARRA = "D:\\CPE\\CODIGOBARRA\\" & nomARCHIVO & ".BMP"
            CPE.RUTA_PDF = "D:\\CPE\\BETA\\" & nomARCHIVO & ".PDF"
            CPE.RUTA_PDF_2_NUVE = "D:\\CPE\\NUVE\\" & nomBRE_AR_NUVE & ".PDF"
            RptPDF.TraerReporteComprobante(CPE)
            '====================enviamos documento a la sunat=========================
            dictionary = objENV.Envio(CPE.NRO_DOCUMENTO_EMPRESA, CPE.USUARIO_SOL_EMPRESA, CPE.PASS_SOL_EMPRESA, nomARCHIVO, ruta, url, objRespuesta.DigestValue)
        End If

        Return dictionary
    End Function

    Public Function envioResumen(CPEResumen As BE.CPE_RESUMEN_BOLETA) As Dictionary(Of String, String)
        Dim dictionary As Dictionary(Of String, String)
        Dim nomARCHIVO As String
        Dim ruta As String
        Dim rutaFirma As String
        Dim url As String

        nomARCHIVO = CPEResumen.NRO_DOCUMENTO_EMPRESA & "-" & CPEResumen.CODIGO & "-" & CPEResumen.SERIE & "-" & CPEResumen.SECUENCIA

        If (CPEResumen.TIPO_PROCESO = 3) Then
            '===================configuracion de rutas===================
            ruta = "D:\\CPE\\BETA\\"
            rutaFirma = "D:\\CPE\\FIRMABETA\\FIRMABETA.pfx"
            url = "https://e-beta.sunat.gob.pe:443/ol-ti-itcpfegem-beta/billService"
            '===================creamos xml(comprobante)====================
            objXML.ResumenBoleta(CPEResumen, nomARCHIVO, ruta)
            '=================datos para la firma====================
            objPregunta.ruta_Firma = rutaFirma
            objPregunta.contra_Firma = CPEResumen.CONTRA_FIRMA
            objPregunta.ruta_xml = ruta & nomARCHIVO & ".XML"
            objPregunta.flg_firma = 0
            objRespuesta = objSignature.FirmaXMl(objPregunta)
            '====================enviamos documento a la sunat=========================
            dictionary = objENV.EnvioResumen(CPEResumen.NRO_DOCUMENTO_EMPRESA, CPEResumen.USUARIO_SOL_EMPRESA, CPEResumen.PASS_SOL_EMPRESA, nomARCHIVO, ruta, url, objRespuesta.DigestValue)
        End If
        If (CPEResumen.TIPO_PROCESO = 2) Then
            '===================configuracion de rutas===================
            ruta = "D:\\CPE\\HOMOLOGACION\\"
            rutaFirma = "D:\\CPE\\FIRMA\\" & CPEResumen.NRO_DOCUMENTO_EMPRESA & ".pfx"
            url = "https://www.sunat.gob.pe/ol-ti-itcpgem-sqa/billService"
            '===================creamos xml(comprobante)====================
            objXML.ResumenBoleta(CPEResumen, nomARCHIVO, ruta)
            '=================datos para la firma====================
            objPregunta.ruta_Firma = rutaFirma
            objPregunta.contra_Firma = CPEResumen.CONTRA_FIRMA
            objPregunta.ruta_xml = ruta & nomARCHIVO & ".XML"
            objPregunta.flg_firma = 0
            objRespuesta = objSignature.FirmaXMl(objPregunta)
            '====================enviamos documento a la sunat=========================
            dictionary = objENV.EnvioResumen(CPEResumen.NRO_DOCUMENTO_EMPRESA, CPEResumen.USUARIO_SOL_EMPRESA, CPEResumen.PASS_SOL_EMPRESA, nomARCHIVO, ruta, url, objRespuesta.DigestValue)
        End If
        If (CPEResumen.TIPO_PROCESO = 1) Then
            ruta = "D:\\CPE\\PRODUCCION\\"
            rutaFirma = "D:\\CPE\\FIRMA\\" & CPEResumen.NRO_DOCUMENTO_EMPRESA & ".pfx"
            url = "https://e-factura.sunat.gob.pe/ol-ti-itcpfegem/billService"
            '===================creamos xml(comprobante)===================
            objXML.ResumenBoleta(CPEResumen, nomARCHIVO, ruta)
            '=================datos para la firma====================
            objPregunta.ruta_Firma = rutaFirma
            objPregunta.contra_Firma = CPEResumen.CONTRA_FIRMA
            objPregunta.ruta_xml = ruta & nomARCHIVO & ".XML"
            objPregunta.flg_firma = 0
            objRespuesta = objSignature.FirmaXMl(objPregunta)
            '====================enviamos documento a la sunat=========================
            dictionary = objENV.EnvioResumen(CPEResumen.NRO_DOCUMENTO_EMPRESA, CPEResumen.USUARIO_SOL_EMPRESA, CPEResumen.PASS_SOL_EMPRESA, nomARCHIVO, ruta, url, objRespuesta.DigestValue)
        End If

        Return dictionary
    End Function

    Public Function envioBaja(CPEBaja As BE.CPE_BAJA) As Dictionary(Of String, String)
        Dim dictionary As Dictionary(Of String, String)
        Dim nomARCHIVO As String
        Dim ruta As String
        Dim rutaFirma As String
        Dim url As String

        nomARCHIVO = CPEBaja.NRO_DOCUMENTO_EMPRESA & "-" & CPEBaja.CODIGO & "-" & CPEBaja.SERIE & "-" & CPEBaja.SECUENCIA

        If (CPEBaja.TIPO_PROCESO = 3) Then
            '===================configuracion de rutas===================
            ruta = "D:\\CPE\\BETA\\"
            rutaFirma = "D:\\CPE\\FIRMABETA\\FIRMABETA.pfx"
            url = "https://e-beta.sunat.gob.pe:443/ol-ti-itcpfegem-beta/billService"
            '===================creamos xml(comprobante)====================
            objXML.ResumenBaja(CPEBaja, nomARCHIVO, ruta)
            '=================datos para la firma====================
            objPregunta.ruta_Firma = rutaFirma
            objPregunta.contra_Firma = CPEBaja.CONTRA_FIRMA
            objPregunta.ruta_xml = ruta & nomARCHIVO & ".XML"
            objPregunta.flg_firma = 0
            objRespuesta = objSignature.FirmaXMl(objPregunta)
            '====================enviamos documento a la sunat=========================
            dictionary = objENV.EnvioResumen(CPEBaja.NRO_DOCUMENTO_EMPRESA, CPEBaja.USUARIO_SOL_EMPRESA, CPEBaja.PASS_SOL_EMPRESA, nomARCHIVO, ruta, url, objRespuesta.DigestValue)
        End If
        If (CPEBaja.TIPO_PROCESO = 2) Then
            '===================configuracion de rutas===================
            ruta = "D:\\CPE\\HOMOLOGACION\\"
            rutaFirma = "D:\\CPE\\FIRMA\\" & CPEBaja.NRO_DOCUMENTO_EMPRESA & ".pfx"
            url = "https://www.sunat.gob.pe/ol-ti-itcpgem-sqa/billService"
            '===================creamos xml(comprobante)====================
            objXML.ResumenBaja(CPEBaja, nomARCHIVO, ruta)
            '=================datos para la firma====================
            objPregunta.ruta_Firma = rutaFirma
            objPregunta.contra_Firma = CPEBaja.CONTRA_FIRMA
            objPregunta.ruta_xml = ruta & nomARCHIVO & ".XML"
            objPregunta.flg_firma = 0
            objRespuesta = objSignature.FirmaXMl(objPregunta)
            '====================enviamos documento a la sunat=========================
            dictionary = objENV.EnvioResumen(CPEBaja.NRO_DOCUMENTO_EMPRESA, CPEBaja.USUARIO_SOL_EMPRESA, CPEBaja.PASS_SOL_EMPRESA, nomARCHIVO, ruta, url, objRespuesta.DigestValue)
        End If
        If (CPEBaja.TIPO_PROCESO = 1) Then
            ruta = "D:\\CPE\\PRODUCCION\\"
            rutaFirma = "D:\\CPE\\FIRMA\\" & CPEBaja.NRO_DOCUMENTO_EMPRESA & ".pfx"
            url = "https://e-factura.sunat.gob.pe/ol-ti-itcpfegem/billService"
            '===================creamos xml(comprobante)===================
            objXML.ResumenBaja(CPEBaja, nomARCHIVO, ruta)
            '=================datos para la firma====================
            objPregunta.ruta_Firma = rutaFirma
            objPregunta.contra_Firma = CPEBaja.CONTRA_FIRMA
            objPregunta.ruta_xml = ruta & nomARCHIVO & ".XML"
            objPregunta.flg_firma = 0
            objRespuesta = objSignature.FirmaXMl(objPregunta)
            '====================enviamos documento a la sunat=========================
            dictionary = objENV.EnvioResumen(CPEBaja.NRO_DOCUMENTO_EMPRESA, CPEBaja.USUARIO_SOL_EMPRESA, CPEBaja.PASS_SOL_EMPRESA, nomARCHIVO, ruta, url, objRespuesta.DigestValue)
        End If

        Return dictionary
    End Function

    Public Function consultaTicket(CPETicket As BE.CONSULTA_TICKET) As Dictionary(Of String, String)
        Dim dictionary As Dictionary(Of String, String)
        Dim nomARCHIVO As String
        Dim ruta As String
        Dim url As String

        nomARCHIVO = CPETicket.NRO_DOCUMENTO_EMPRESA & "-" & CPETicket.TIPO_DOCUMENTO & "-" & CPETicket.NRO_DOCUMENTO

        If (CPETicket.TIPO_PROCESO = 3) Then
            '===================configuracion de rutas===================
            ruta = "D:\\CPE\\BETA\\"
            url = "https://e-beta.sunat.gob.pe:443/ol-ti-itcpfegem-beta/billService"
            '====================enviamos documento a la sunat=========================
            dictionary = objENV.ConsultaTicket(CPETicket.NRO_DOCUMENTO_EMPRESA, CPETicket.USUARIO_SOL_EMPRESA, CPETicket.PASS_SOL_EMPRESA, nomARCHIVO, ruta, url, objRespuesta.DigestValue, CPETicket.TICKET)
        End If
        If (CPETicket.TIPO_PROCESO = 2) Then
            '===================configuracion de rutas===================
            ruta = "D:\\CPE\\HOMOLOGACION\\"
            url = "https://www.sunat.gob.pe/ol-ti-itcpgem-sqa/billService"
            '====================enviamos documento a la sunat=========================
            dictionary = objENV.ConsultaTicket(CPETicket.NRO_DOCUMENTO_EMPRESA, CPETicket.USUARIO_SOL_EMPRESA, CPETicket.PASS_SOL_EMPRESA, nomARCHIVO, ruta, url, objRespuesta.DigestValue, CPETicket.TICKET)
        End If
        If (CPETicket.TIPO_PROCESO = 1) Then
            ruta = "D:\\CPE\\PRODUCCION\\"
            url = "https://e-factura.sunat.gob.pe/ol-ti-itcpfegem/billService"
            '====================enviamos documento a la sunat=========================
            dictionary = objENV.ConsultaTicket(CPETicket.NRO_DOCUMENTO_EMPRESA, CPETicket.USUARIO_SOL_EMPRESA, CPETicket.PASS_SOL_EMPRESA, nomARCHIVO, ruta, url, objRespuesta.DigestValue, CPETicket.TICKET)
        End If

        Return dictionary
    End Function

    Public Function NSV(ByVal Valor As Object, Optional ByVal Retorno As Object = "") As String
        ' Retorna "" si el valor que se le manda es nulo
        NSV = IIf(IsDBNull(Valor), Retorno, Valor)
    End Function
    Public Function NZ(ByVal Valor As Object, Optional ByVal Retorno As Object = 0) As Double
        ' Retorna cero si el parámetro que se le manda es nulo
        If IsNumeric(Valor) Then
            NZ = IIf(IsDBNull(Valor), Retorno, CDbl(Valor))
        Else
            NZ = Retorno
        End If
    End Function

End Class

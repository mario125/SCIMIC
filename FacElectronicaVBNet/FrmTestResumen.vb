Imports BE = businessEntities
Public Class FrmTestResumen
    '=====================resumen de boleta=============================
    Dim objCPE As New BE.CPE_RESUMEN_BOLETA
    Dim objCPE_DETALLE As BE.CPE_RESUMEN_BOLETA_DETALLE
    '=====================resumen de boleta=============================
    Dim objCPE_BAJA As New BE.CPE_BAJA
    Dim objCPE_BAJA_DETALLE As BE.CPE_BAJA_DETALLE
    '=====================consulta ticket=============================
    Dim objCPETICKET As New BE.CONSULTA_TICKET
    Dim obj As New CPEConfig
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        objCPE.NRO_DOCUMENTO_EMPRESA = "10447915125"
        objCPE.RAZON_SOCIAL = "CREVPERU S.A."
        objCPE.TIPO_DOCUMENTO = "6"
        objCPE.CODIGO = "RC"
        objCPE.SERIE = "20161029"
        objCPE.SECUENCIA = "1"
        objCPE.FECHA_REFERENCIA = "2016-10-28"
        objCPE.FECHA_DOCUMENTO = "2016-10-29"
        objCPE.TIPO_PROCESO = "3"
        objCPE.CONTRA_FIRMA = "123456"
        objCPE.USUARIO_SOL_EMPRESA = "MODDATOS"
        objCPE.PASS_SOL_EMPRESA = "moddatos"

        Dim OBJCPE_DETALLE_LIST As New List(Of businessEntities.CPE_RESUMEN_BOLETA_DETALLE)

        'Agregando datos a la lista Comprobante detalle
        objCPE_DETALLE = New businessEntities.CPE_RESUMEN_BOLETA_DETALLE
        objCPE_DETALLE.ITEM = 1
        objCPE_DETALLE.TIPO_COMPROBANTE = "03"
        objCPE_DETALLE.NRO_COMPROBANTE = "B001-12"
        objCPE_DETALLE.TIPO_DOCUMENTO = "1"
        objCPE_DETALLE.NRO_DOCUMENTO = "44791512"
        objCPE_DETALLE.TIPO_COMPROBANTE_REF = ""
        objCPE_DETALLE.NRO_COMPROBANTE_REF = ""
        objCPE_DETALLE.STATU = 1
        objCPE_DETALLE.COD_MONEDA = "PEN"
        objCPE_DETALLE.TOTAL = 1693.39
        objCPE_DETALLE.GRAVADA = 1435.08
        objCPE_DETALLE.ISC = 0
        objCPE_DETALLE.IGV = 258.31
        objCPE_DETALLE.OTROS = 0
        objCPE_DETALLE.CARGO_X_ASIGNACION = 1
        objCPE_DETALLE.MONTO_CARGO_X_ASIG = 0
        objCPE_DETALLE.EXONERADO = 0
        objCPE_DETALLE.INAFECTO = 0
        objCPE_DETALLE.EXPORTACION = 0
        objCPE_DETALLE.GRATUITAS = 0
        OBJCPE_DETALLE_LIST.Add(objCPE_DETALLE)

        objCPE.detalle = OBJCPE_DETALLE_LIST
        '======================================RESPUESTA====================================
        Dim dictionaryEnv As New Dictionary(Of String, String)
        dictionaryEnv = obj.envioResumen(objCPE)
        TXTCOD_SUNAT.Text = dictionaryEnv.Item("cod_sunat")
        TXT_MSJ_SUNAT.Text = dictionaryEnv.Item("msj_sunat")
        TXTHASHCPE.Text = dictionaryEnv.Item("hash_cpe")
        TXTHASHCDR.Text = dictionaryEnv.Item("hash_cdr")
        '==============================
        txtticket.Text = dictionaryEnv.Item("msj_sunat")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '===================CONSULTA RESUMEN DE BOLTA=======================
        objCPETICKET.TIPO_PROCESO = 3
        objCPETICKET.NRO_DOCUMENTO_EMPRESA = "10447915125"
        objCPETICKET.USUARIO_SOL_EMPRESA = "MODDATOS"
        objCPETICKET.PASS_SOL_EMPRESA = "moddatos"
        objCPETICKET.TICKET = txtticket.Text
        objCPETICKET.TIPO_DOCUMENTO = "RC"
        objCPETICKET.NRO_DOCUMENTO = "20161029-1"

        '===================CONSULTA RESUMEN DE BAJA=======================
        'objCPETICKET.TIPO_PROCESO = 3
        'objCPETICKET.NRO_DOCUMENTO_EMPRESA = "10447915125"
        'objCPETICKET.USUARIO_SOL_EMPRESA = "MODDATOS"
        'objCPETICKET.PASS_SOL_EMPRESA = "moddatos"
        'objCPETICKET.TICKET = txtticket.Text
        'objCPETICKET.TIPO_DOCUMENTO = "RA"
        'objCPETICKET.NRO_DOCUMENTO = "20161029-1"

        '======================================RESPUESTA====================================
        Dim dictionaryEnv As New Dictionary(Of String, String)
        dictionaryEnv = obj.consultaTicket(objCPETICKET)
        TXTCOD_SUNAT.Text = dictionaryEnv.Item("cod_sunat")
        TXT_MSJ_SUNAT.Text = dictionaryEnv.Item("msj_sunat")
        TXTHASHCPE.Text = dictionaryEnv.Item("hash_cpe")
        TXTHASHCDR.Text = dictionaryEnv.Item("hash_cdr")
        txtticket.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        objCPE_BAJA.NRO_DOCUMENTO_EMPRESA = "10447915125"
        objCPE_BAJA.RAZON_SOCIAL = "CREVPERU S.A."
        objCPE_BAJA.TIPO_DOCUMENTO = "6"
        objCPE_BAJA.CODIGO = "RA"
        objCPE_BAJA.SERIE = "20161029"
        objCPE_BAJA.SECUENCIA = "1"
        objCPE_BAJA.FECHA_REFERENCIA = "2016-10-28"
        objCPE_BAJA.FECHA_BAJA = "2016-10-29"
        objCPE_BAJA.TIPO_PROCESO = 3
        objCPE_BAJA.USUARIO_SOL_EMPRESA = "MODDATOS"
        objCPE_BAJA.PASS_SOL_EMPRESA = "moddatos"
        objCPE_BAJA.CONTRA_FIRMA = "123456"

        Dim OBJCPE_DETALLE_LIST As New List(Of businessEntities.CPE_BAJA_DETALLE)
        'Agregando datos a la lista Comprobante detalle
        objCPE_BAJA_DETALLE = New businessEntities.CPE_BAJA_DETALLE

        objCPE_BAJA_DETALLE.ITEM = 1
        objCPE_BAJA_DETALLE.TIPO_COMPROBANTE = "01"
        objCPE_BAJA_DETALLE.SERIE = "FF11"
        objCPE_BAJA_DETALLE.NUMERO = "750"
        objCPE_BAJA_DETALLE.DESCRIPCION = "ERROR DE DIGITACION"

        OBJCPE_DETALLE_LIST.Add(objCPE_BAJA_DETALLE)

        objCPE_BAJA.detalle = OBJCPE_DETALLE_LIST
        '======================================RESPUESTA====================================
        Dim dictionaryEnv As New Dictionary(Of String, String)
        dictionaryEnv = obj.envioBaja(objCPE_BAJA)
        TXTCOD_SUNAT.Text = dictionaryEnv.Item("cod_sunat")
        TXT_MSJ_SUNAT.Text = dictionaryEnv.Item("msj_sunat")
        TXTHASHCPE.Text = dictionaryEnv.Item("hash_cpe")
        TXTHASHCDR.Text = dictionaryEnv.Item("hash_cdr")
        '==============================
        txtticket.Text = dictionaryEnv.Item("msj_sunat")
    End Sub

End Class
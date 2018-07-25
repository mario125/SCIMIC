Imports System.Data.Odbc
Imports BE = BusinessEntities
Imports MSJ = FacElectronicaVBNet.INICIO




Module Module1
    Public Connection As OdbcConnection
    Dim objCPE As New BE.CPE
    Dim objCPE_DETALLE As BE.CPE_DETALLE
    Dim obj As New CPEConfig

    Public Sub conn()
        Try
            Connection = New OdbcConnection("dsn=scimicPRU;uid=postgres;pwd=Scimic?Developer?479;")
            If Connection.State = ConnectionState.Closed Then
                Connection.Open()
            End If
        Catch ex As Exception
            MsgBox("Error en la conexión")
        End Try
    End Sub

    'funcion de ejecutar comando
    Public Sub RunSQL(ByVal Sql As String)
        Dim cmd As New OdbcCommand
        conn()
        Try
            cmd.Connection = Connection
            cmd.CommandType = CommandType.Text
            cmd.CommandText = Sql
            cmd.ExecuteNonQuery()
            'cmd.Dispose()
            'Connection.Close()
        Catch ex As Exception
            MsgBox("Hubo un error" & ex.Message)
        End Try
    End Sub
    Public Sub ConsRec(ByVal Sql As String, ByVal SqlDR As OdbcDataReader)
        Dim cmd As New OdbcCommand
        conn()
        Try
            cmd.Connection = Connection
            cmd.CommandType = CommandType.Text
            cmd.CommandText = Sql '"Select * from emp_empresa where id=1"
            SqlDR = cmd.ExecuteReader()
            While SqlDR.Read()
                MsgBox(SqlDR("empresa").ToString & " - " & SqlDR("ruc").ToString)
            End While
            cmd.Dispose()
            ' Connection.Close()
        Catch ex As Exception
            MsgBox("Hubo un error")
        End Try
    End Sub
    Public Function Letras(ByVal numero As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras, entero, dec, flag As String

        '********Declara variables de tipo entero***********
        Dim num, x, y As Integer

        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "cien "
                                Else
                                    palabras = palabras & "ciento "
                                End If
                            Case "2"
                                palabras = palabras & "doscientos "
                            Case "3"
                                palabras = palabras & "trescientos "
                            Case "4"
                                palabras = palabras & "cuatrocientos "
                            Case "5"
                                palabras = palabras & "quinientos "
                            Case "6"
                                palabras = palabras & "seiscientos "
                            Case "7"
                                palabras = palabras & "setecientos "
                            Case "8"
                                palabras = palabras & "ochocientos "
                            Case "9"
                                palabras = palabras & "novecientos "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "diez "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "once "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "doce "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "trece "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "catorce "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "quince "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "dieci"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "treinta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cuarenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cincuenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "sesenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "setenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "ochenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "noventa "
                                    flag = "S"
                                Else
                                    palabras = palabras & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "uno "
                                    Else
                                        palabras = palabras & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "dos "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "tres "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "cuatro "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "cinco "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "seis "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "siete "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "ocho "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "nueve "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or
                    (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And
                    Len(entero) <= 6) Then palabras = palabras & "mil "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "millón "
                    Else
                        palabras = palabras & "millones "
                    End If
                End If
            Next y

            '**********Une la parte entera y la parte decimal*************
            If dec <> "" Then
                Letras = palabras & "con " & dec & "/100"
            Else
                Letras = palabras
            End If
        Else
            Letras = ""
        End If
    End Function
    Public Sub enviarsci()



        Dim cmd As New OdbcCommand, SqlDR As OdbcDataReader, Sql As String, Z As Integer
        Dim cmd2 As New OdbcCommand, SqlDR2 As OdbcDataReader, Sql2 As String
        Dim cmd3 As New OdbcCommand, SqlDR3 As OdbcDataReader, Sql3 As String
        conn()
        '       Try
        cmd.Connection = Connection
        cmd.CommandType = CommandType.Text



        'MessageBox.Show("holas")
        Sql = "SELECT emp_empresa.ruc, emp_empresa.telefono,emp_empresa.empresa, emp_empresa.ubigeo, emp_empresa.direccion, emp_empresa.departamento, emp_empresa.provincia, emp_empresa.distrito, emp_empresa.nombrec, emp_empresa.usuario_sol, emp_empresa.pass_sol, emp_empresa.contra_firma FROM emp_empresa where  emp_ppal=true"
        cmd.CommandText = Sql '"Select * from emp_empresa where id=1"
        SqlDR = cmd.ExecuteReader()
        While SqlDR.Read()
            objCPE.NRO_DOCUMENTO_EMPRESA = SqlDR("ruc").ToString '"10447915125"
            objCPE.TIPO_DOCUMENTO_EMPRESA = "6" '1=DNI,6=RUC
            objCPE.NOMBRE_COMERCIAL_EMPRESA = SqlDR("nombrec").ToString '"JOSE LUIS ZAMBRANO YACHA"  ----------------------nombrec
            objCPE.CODIGO_UBIGEO_EMPRESA = SqlDR("ubigeo").ToString '"150101" 'TABLA UBIGEO
            objCPE.DIRECCION_EMPRESA = SqlDR("direccion").ToString '"DIRECCION DE PRUEBA"DIRECCION_CLIENTE
            objCPE.TELEFONO_PRINCIPAL = SqlDR("telefono").ToString
            objCPE.DEPARTAMENTO_EMPRESA = SqlDR("departamento").ToString '"LIMA"
            objCPE.PROVINCIA_EMPRESA = SqlDR("provincia").ToString '"LIMA"
            objCPE.DISTRITO_EMPRESA = SqlDR("distrito").ToString '"LIMA"
            objCPE.CODIGO_PAIS_EMPRESA = "PE"
            objCPE.RAZON_SOCIAL_EMPRESA = SqlDR("empresa").ToString        '"JOSE LUIS ZAMBRANO YACHA"
            '/_____________________________________ DATOS DE LA RUC__________________/'
            objCPE.USUARIO_SOL_EMPRESA = SqlDR("usuario_sol")              'objCPE.USUARIO_SOL_EMPRESA = "ANDREA01"
            objCPE.PASS_SOL_EMPRESA = SqlDR("pass_sol")                    'objCPE.PASS_SOL_EMPRESA = "SCIMIC2016"
            objCPE.CONTRA_FIRMA = SqlDR("contra_firma")                    'objCPE.CONTRA_FIRMA = "4jtHwXupPzHAutKD"
            objCPE.TIPO_PROCESO = 1 '1=PRODUCCION, 2=HOMOLOGACION, 3=BETA  ______________________________CAMBIAR  AQUI_____
        End While

        cmd2.Connection = Connection
        cmd2.CommandType = CommandType.Text
        Sql = "SELECT cja_documento.id, fe_serie.serie, cja_documento.de_num, cja_documento.fecha, emp_empresa.ruc, emp_empresa.empresa, emp_empresa.direccion, emp_empresa.provincia, cja_documento.cod_hash, cja_documento.cod_sunat, cja_documento.msg_sunat, cja_documento.monto_me, cja_documento.igv, cja_documento.prod_id, fe_tipo_doc.codigo AS tipo_comp, cja_moneda.abrev AS moneda, emp_tipo_doc.codigo as tipo_doc FROM cja_documento LEFT OUTER JOIN fe_serie ON (cja_documento.de_serie = fe_serie.id) LEFT OUTER JOIN emp_empresa ON (cja_documento.empresa = emp_empresa.id) INNER JOIN fe_tipo_doc ON (fe_serie.tipo_doc = fe_tipo_doc.id) LEFT OUTER JOIN cja_moneda ON (cja_documento.moneda = cja_moneda.id) LEFT OUTER JOIN emp_tipo_doc ON (emp_empresa.tipo_doc = emp_tipo_doc.id) WHERE cja_documento.de_num > 0 AND cja_documento.cod_hash IS NULL "
        cmd2.CommandText = Sql '"Select * from emp_empresa where id=1"
        SqlDR2 = cmd2.ExecuteReader()
        While SqlDR2.Read()

            objCPE.TIPO_OPERACION = ""
            objCPE.TOTAL_GRAVADAS = SqlDR2("monto_me").ToString  'SUB TOTAL
            objCPE.SUB_TOTAL = Math.Round(SqlDR2("monto_me").ToString - SqlDR2("igv").ToString, 2)  'SUB TOTAL
            objCPE.TOTAL_IGV = SqlDR2("igv").ToString   'TOTAL IGV
            objCPE.TOTAL_ISC = 0
            objCPE.TOTAL_OTR_IMP = 0
            objCPE.TOTAL = SqlDR2("monto_me").ToString  'TOTAL COMPROBANTE_____________________________________________________________________________MODIFICANDO  SUMAR CADA ITEM 
            objCPE.TOTAL_LETRAS = Letras(SqlDR2("monto_me").ToString)
            objCPE.NRO_GUIA_REMISION = ""
            objCPE.COD_GUIA_REMISION = ""
            objCPE.NRO_OTR_COMPROBANTE = ""
            objCPE.COD_OTR_COMPROBANTE = ""
            objCPE.NRO_COMPROBANTE = SqlDR2("serie").ToString & "-" & SqlDR2("de_num").ToString
            objCPE.FECHA_DOCUMENTO = Format(CDate(SqlDR2("fecha").ToString), "yyy-MM-dd") '"2018-01-18"
            objCPE.COD_TIPO_DOCUMENTO = SqlDR2("tipo_comp").ToString '01=FACTURA, 03=BOLETA, 07=NOTA CREDITO, 08=NOTA DEBITO
            objCPE.COD_MONEDA = SqlDR2("moneda").ToString
            objCPE.PLACA_VEHICULO = "" 'txtplaca_vehiculo.Text
            '========================DATOS DEL CIENTE==========================
            objCPE.NRO_DOCUMENTO_CLIENTE = SqlDR2("ruc").ToString 'TXTNUMERODOCUMENTO.Text
            objCPE.RAZON_SOCIAL_CLIENTE = SqlDR2("empresa").ToString 'TXTRAZON_SOCIAL.Text
            objCPE.TIPO_DOCUMENTO_CLIENTE = SqlDR2("tipo_doc").ToString 'CBOTIPODOCUMENTO.SelectedValue   '1=DNI,6=RUC
            objCPE.DIRECCION_CLIENTE = SqlDR2("direccion").ToString 'TXTDIRECCION.Text
            If SqlDR2("provincia").ToString <> "" Then
                objCPE.CIUDAD_CLIENTE = SqlDR2("provincia").ToString '"LIMA"
            Else
                objCPE.CIUDAD_CLIENTE = "LIMA"
            End If
            objCPE.COD_PAIS_CLIENTE = "PE"
            ''=============================DATOS EMPRESA===========================

            Dim OBJCPE_DETALLE_LIST As New List(Of businessEntities.CPE_DETALLE)
            cmd3.Connection = Connection
            cmd3.CommandType = CommandType.Text

            Sql = "SELECT stk_traslado_itm.cantidad, stk_traslado_itm.precio, stk_traslado_itm.total, stk_unidad.codigo as unidad, stk_producto.codigo, stk_producto.producto FROM stk_traslado_itm LEFT OUTER JOIN stk_unidad ON (stk_traslado_itm.medida = stk_unidad.id) LEFT OUTER JOIN stk_producto ON (stk_traslado_itm.producto = stk_producto.id) WHERE stk_traslado_itm.cantidad>0 and stk_traslado_itm.traslado =" & SqlDR2("prod_id").ToString
            cmd3.CommandText = Sql '"Select * from emp_empresa where id=1"
            SqlDR3 = cmd3.ExecuteReader()
            Z = 1
            While SqlDR3.Read()
                objCPE_DETALLE = New businessEntities.CPE_DETALLE
                objCPE_DETALLE.ITEM = Z
                objCPE_DETALLE.UNIDAD_MEDIDA = SqlDR3("unidad").ToString ' vObjTempComprobante.Rows(Z)("UND.MED").ToString 'UNIDAD MEDIDA SEGUN CATALOGO 8
                objCPE_DETALLE.CANTIDAD = SqlDR3("cantidad").ToString 'CDec(vObjTempComprobante.Rows(Z)("CANTIDAD"))
                objCPE_DETALLE.PRECIO = SqlDR3("precio").ToString 'CDec(vObjTempComprobante.Rows(Z)("PRECIO"))
                objCPE_DETALLE.IMPORTE = Format(SqlDR3("cantidad").ToString * SqlDR3("precio").ToString, "#0.00") 'SqlDR3("total").ToString 'CDec(vObjTempComprobante.Rows(Z)("IMPORTE"))
                objCPE_DETALLE.PRECIO_TIPO_CODIGO = "01"
                objCPE_DETALLE.IGV = Format(objCPE_DETALLE.IMPORTE - (objCPE_DETALLE.IMPORTE * 0.18), "#0.00") 'CDec(vObjTempComprobante.Rows(Z)("IGV"))
                objCPE_DETALLE.ISC = 0
                objCPE_DETALLE.COD_TIPO_OPERACION = "10"
                objCPE_DETALLE.CODIGO = SqlDR3("codigo").ToString 'vObjTempComprobante.Rows(Z)("CODIGO").ToString
                objCPE_DETALLE.DESCRIPCION = SqlDR3("producto").ToString 'vObjTempComprobante.Rows(Z)("DESCRIPCION").ToString
                objCPE_DETALLE.SUB_TOTAL = Format(objCPE_DETALLE.IMPORTE / 1.18, "#0.00") 'CDec(vObjTempComprobante.Rows(Z)("SUB.TOTAL"))
                objCPE_DETALLE.PRECIO_SIN_IMPUESTO = Format(SqlDR3("precio").ToString / 1.18, "#0.00") 'CDec(vObjTempComprobante.Rows(Z)("PRECIO"))
                OBJCPE_DETALLE_LIST.Add(objCPE_DETALLE)
                Z = Z + 1
            End While

            objCPE.detalle = OBJCPE_DETALLE_LIST
            '======================================RESPUESTA====================================
            Dim dictionaryEnv As New Dictionary(Of String, String)
            dictionaryEnv = obj.envio(objCPE)



            'INICIO.notifi(100, SqlDR2("id"), dictionaryEnv.Item("msj_sunat"), ToolTipIcon.Info, Color.White, Color.White, Color.Tomato)
            MessageBox.Show(dictionaryEnv.Item("cod_sunat") + "_______" + dictionaryEnv.Item("msj_sunat"))
            If dictionaryEnv.Item("cod_sunat") = "0" Then
                Dim mesajito_sunat = "COD:" & dictionaryEnv.Item("cod_sunat") & "-MENSAJE:" & dictionaryEnv.Item("msj_sunat")
                'Sql = "UPDATE cja_documento SET(cod_hash,cod_sunat,msg_sunat) = ('" & dictionaryEnv.Item("hash_cpe") & "','" & dictionaryEnv.Item("hash_cdr") & "','" & dictionaryEnv.Item("msj_sunat") & "') WHERE id=" & SqlDR2("id")
                Sql = "UPDATE cja_documento SET(cod_hash,cod_sunat,msg_sunat) = ('" & dictionaryEnv.Item("hash_cdr") & "','" & dictionaryEnv.Item("hash_cpe") & "','" & mesajito_sunat & "') WHERE id=" & SqlDR2("id")
                'hola esto es  una prueva para  git hub  desde  mi sistema de facturacion
                RunSQL(Sql)
            Else
                INICIO.notifi(100, SqlDR2("id"), dictionaryEnv.Item("msj_sunat"), ToolTipIcon.Error, Color.White, Color.White, Color.Tomato)
                Dim mesajito_sunat = "COD:" & dictionaryEnv.Item("cod_sunat") & "-MENSAJE:" & dictionaryEnv.Item("msj_sunat")

                Sql = "UPDATE cja_documento SET(cod_hash,msg_sunat) = ('DOCUMENTO CON ERROR...!!!','" & mesajito_sunat & "') WHERE id=" & SqlDR2("id")

                RunSQL(Sql)

            End If

        End While
        'SqlDR.Close()
        'SqlDR2.Close()
        cmd.Dispose()
        Connection.Close()
    End Sub


End Module



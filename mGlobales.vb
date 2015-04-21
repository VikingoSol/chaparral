Imports System.Text.RegularExpressions
Imports BaseDatos
Imports System.IO
Imports FacturaNETLib
Imports FacturaNETLib.Document
Module mGlobales
    Public gPathData As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Tedesi\FacturaNet\"
    Public gConfigFile As String = gPathData & "Config.dat"
    Public gConfig As New cConfigLocal
    Public gConfigGlobal As New dConfigGlobal
    Public gPathDataSoft As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Tedesi\FacturaNet\"
    Public gPathFactuacion As String = gPathDataSoft & "facturacion\"
    Public gPathBarCodes As String = gPathDataSoft & "facturacion\BarCodes\"
    Public gRFCPublicGeneral As String = "XAXX010101000"
    Public RfcActual As String = ""

    Public Function RFC_Check(ByVal pRFC As String) As Boolean
        If Regex.IsMatch(pRFC, "^([a-zA-Z\s]{3,4})\d{6}([0-9a-zA-Z\w]{3})$") Then
            Return True
        Else : Return False
        End If
    End Function


    Public Function EmailAddressCheck(ByVal emailAddress As String) As Boolean
        Dim pattern As String = "^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,3})$"
        Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern, RegexOptions.IgnoreCase)
        If emailAddressMatch.Success Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function File_To_Bytes(ByVal Path As String) As Byte()
        Dim sPath As String
        sPath = Path
        Dim Ruta As New FileStream(sPath, FileMode.Open, FileAccess.Read)
        Dim Binario(CInt(Ruta.Length) - 1) As Byte
        Ruta.Read(Binario, 0, CInt(Ruta.Length))
        Ruta.Close()
        Return Binario
    End Function


    Public Sub Bytes_To_File(ByVal Bin As Byte(), ByVal pFile As String)
        Dim oFileStream As FileStream
        Dim pathTemporal As String = pFile 'Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\Dato.pdf"

        If Not IO.Directory.Exists(IO.Path.GetDirectoryName(pFile)) Then
            IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(pFile))
        End If

        If File.Exists(pathTemporal) Then File.Delete(pathTemporal)
        oFileStream = New FileStream(pathTemporal, FileMode.CreateNew)
        oFileStream.Write(Bin, 0, Bin.Length)
        oFileStream.Close()
        oFileStream = Nothing
        '        AR1.LoadFile(pathTemporal)
        'If File.Exists(pathTemporal) Then File.Delete(pathTemporal)
    End Sub

    Public Function Letras(ByVal numero As String, ByVal pMoneda As String) As String
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
        If Len(dec) = 0 Then dec = "00"

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
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                    (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
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
            ' If dec <> "" Then
            If pMoneda = "PESOS" Then
                Letras = "(SON: " & palabras.ToUpper & pMoneda & " " & dec & "/100 M.N.)"
            ElseIf pMoneda = "USD" Then
                Letras = "(SON: " & palabras.ToUpper & "DOLARES " & dec & "/100 " & pMoneda & " )"
            Else
                Letras = "(SON: " & palabras.ToUpper & " " & dec & "/100 " & pMoneda & " )"
            End If
            'Else
            '    Letras = palabras
            ' End If
        Else
            Letras = ""
        End If
    End Function

    Public Function Generar_CodigoBarrasBi(ByVal pCDR As ElectronicDocument, ByVal pTotal As String, ByVal pSize As Integer, ByVal pPath As String) As String  'ByVal pRFC As String, ByVal pRFCReceptor As String, ByVal pTotal As Double, ByVal pUUID As String, ByVal pSize As Integer, ByVal pFile As String) 

        ' BarCode.SetConfiguration(pSize, ImageFormat.Jpg, True)
        Dim n As Integer
        Dim vUUID As String
        Dim vTimbre As Complementos.TimbreFiscalDigital
        Dim vFile As String
        For n = 0 To pCDR.Data.Complementos.Count - 1
            If pCDR.Data.Complementos(0).Type = Complementos.eComplementoTipo.TimbreFiscalDigital Then
                '     vUUID = pCDR.Data.Complementos.Data(0).
                vTimbre = CType(pCDR.Data.Complementos(0).Data, Complementos.TimbreFiscalDigital)
                vUUID = vTimbre.Uuid.Value
            End If
        Next
        If vUUID = "" Then
            Return ""
        End If
        vFile = pPath & vUUID & ".jpg"
        If Not Directory.Exists(pPath) Then
            Directory.CreateDirectory(pPath)
        Else
            If File.Exists(vFile) Then
                Try
                    File.Delete(vFile)
                Catch ex As Exception
                    vFile = pPath & Guid.NewGuid.ToString & ".jpg"
                End Try

            End If
        End If

        BarCode.GenerateFile(pCDR.Data.Emisor.Rfc.Value, pCDR.Data.Receptor.Rfc.Value, pTotal, vUUID.ToUpper, vFile)
        Return vFile
    End Function



    'Public Sub PruebaError()
    '    Dim vFactura As ElectronicDocument
    '    Dim vManager As ElectronicManage
    '    vManager = ElectronicManage.NewEntity
    '    vFactura = ElectronicDocument.NewEntity()
    '    vFactura.AssignManage(vManager)




    '    Dim sw As New IO.StreamReader("c:/error.txt")
    '    Dim n As Integer
    '    vFactura.Manage.Load.Options = vFactura.Manage.Load.Options - LoadOptions.ValidateCertificateWithCrl - LoadOptions.ValidateSignature - LoadOptions.ValidateStamp
    '    If Not vFactura.LoadFromStream(sw.BaseStream) Then
    '        For n = 0 To vFactura.Data.Complementos.Count - 1
    '            If vFactura.Data.Complementos.Type(n) = ComplementoType.TimbreFiscalDigital Then
    '                Dim vTimbreData As HyperSoft.ElectronicDocumentLibrary.Complemento.TimbreFiscalDigital.Data = CType(vFactura.Data.Complementos.Data(n), HyperSoft.ElectronicDocumentLibrary.Complemento.TimbreFiscalDigital.Data)

    '                ' vIdFac = vFacs.Agregar(vFacturaData.Serie, vFacturaData.Folio, vFacturaData.Fecha, vFacturaData.IdCliente, vFacturaData.Subtotal, vFacturaData.IVA, vFacturaData.Total, vXml, vTimbre, vAcuse, vTimbreData.Uuid.Value.ToUpper, DateTime.ParseExact(vTimbreData.FechaTimbrado.Value, "dd/MM/yyyy hh:mm:ss tt", Nothing), vFacturaData.MetodosPago, vFacturaData.CodigoSitio, vFacturaData.NombreSitio, vFacturaData.OrdenTrabajo)
    '                Dim vFecha As DateTime = DateTime.ParseExact(vTimbreData.FechaTimbrado.Value, "dd/MM/yyyy hh:mm:ss tt", Nothing)
    '            End If
    '        Next n
    '    End If
    'End Sub


    Public Sub BajarCertificadoKey()
        Dim cConfig As New cConfigGlobal

        If Not IsNothing(gConfigGlobal) AndAlso (gConfig.Cer_Version <> gConfigGlobal.Cer_Ver Or Not IO.File.Exists(gPathFactuacion & gConfigGlobal.Cer_Name)) Then
<<<<<<< HEAD
            Dim vFile As dArchivo = cConfig.DownloadCertificado(RfcActual)
=======
            Dim vFile As dArchivo = cConfig.DownloadCertificado()
>>>>>>> 89d4dc6b612e8ac9085c74dd16927a1343a08a8e
            If vFile.Nombre <> "" Then
                If Not IO.Directory.Exists(gPathFactuacion) Then
                    IO.Directory.CreateDirectory(gPathFactuacion)
                End If
                If IO.File.Exists(gPathFactuacion & vFile.Nombre) Then
                    IO.File.Delete(gPathFactuacion & vFile.Nombre)

                End If

                Bytes_To_File(vFile.File, gPathFactuacion & vFile.Nombre)
                gConfigGlobal.Cer_Ver = vFile.Version
            End If

        End If

        If Not IsNothing(gConfigGlobal) AndAlso (gConfig.Key_Version <> gConfigGlobal.Key_Ver Or Not IO.File.Exists(gPathFactuacion & gConfigGlobal.Key_Name)) Then
<<<<<<< HEAD
            Dim vFile As dArchivo = cConfig.DownloadKey(RfcActual)
=======
            Dim vFile As dArchivo = cConfig.DownloadKey()
>>>>>>> 89d4dc6b612e8ac9085c74dd16927a1343a08a8e
            If vFile.Nombre <> "" Then
                If Not IO.Directory.Exists(gPathFactuacion) Then
                    IO.Directory.CreateDirectory(gPathFactuacion)
                End If
                If IO.File.Exists(gPathFactuacion & vFile.Nombre) Then
                    IO.File.Delete(gPathFactuacion & vFile.Nombre)

                End If

                Bytes_To_File(vFile.File, gPathFactuacion & vFile.Nombre)
                gConfigGlobal.Key_Ver = vFile.Version
            End If

        End If
    End Sub

End Module

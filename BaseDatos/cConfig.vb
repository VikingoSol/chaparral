Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports MySql.Data.MySqlClient

<Serializable()> _
Public Class cConfigLocal
    Public Servidor As String = "localhost"
    Public Puerto As Integer = 3306
    Public Usuario As String
    Public Password As String
    Public BaseDatos As String
    Public Cer_Version As Integer
    Public Key_Version As Integer


    Public Sub Guardar(ByVal pFile As String)
        Dim vDir As New DirectoryInfo(Path.GetDirectoryName(pFile))
        If Not vDir.Exists Then
            vDir.Create()
        End If
        Dim fs As New FileStream(pFile, FileMode.OpenOrCreate)
        Dim bf As New BinaryFormatter()
        bf.Serialize(fs, Me)
        fs.Close()


    End Sub

    Public Shared Function Leer(ByVal pFile As String) As cConfigLocal
        If Not File.Exists(pFile) Then
            Return New cConfigLocal
        End If
        Dim vConfig As cConfigLocal
        Dim fs As New FileStream(pFile, FileMode.Open)
        Dim bf As New BinaryFormatter()
        vConfig = CType(bf.Deserialize(fs), cConfigLocal)
        fs.Close()
        Return vConfig
    End Function

End Class


Public Class cConfigGlobal

    Public Sub UploadCertificado(ByVal pName As String, ByVal pCertificado As Byte())
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("UPDATE config SET cer_file=?cer,cer_name=?file,cer_ver=cer_ver+1", gConn)
        vCmd.Parameters.AddWithValue("?cer", pCertificado)
        'vCmd.Parameters.AddWithValue("?id", pEmpresa)
        vCmd.Parameters.AddWithValue("?file", pName)
        vCmd.ExecuteNonQuery()
    End Sub

    Public Function DownloadCertificado(ByVal rfc As String) As dArchivo
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("SELECT cer_file,cer_name,cer_ver FROM config WHERE rfc=rfc", gConn)
        vCmd.Parameters.AddWithValue("?rfc", rfc)
        Dim vAdap As New MySqlDataAdapter(vCmd)
        Dim vTabla As New DataTable
        vAdap.Fill(vTabla)
        Dim vFile As dArchivo
        If vTabla.Rows.Count > 0 Then
            vFile = New dArchivo
            vFile.File = vTabla.Rows(0).Item("cer_file")
            vFile.Nombre = vTabla.Rows(0).Item("cer_name")
            vFile.Version = vTabla.Rows(0).Item("cer_ver")
        End If
        Return vFile
    End Function

    Public Function DownloadKey(ByVal rfc As String) As dArchivo
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("SELECT key_file,key_name,key_ver FROM config WHERE rfc=rfc", gConn)
        vCmd.Parameters.AddWithValue("?rfc", rfc)
        Dim vAdap As New MySqlDataAdapter(vCmd)
        Dim vTabla As New DataTable
        vAdap.Fill(vTabla)
        Dim vFile As dArchivo
        If vTabla.Rows.Count > 0 Then
            vFile = New dArchivo
            vFile.File = vTabla.Rows(0).Item("key_file")
            vFile.Nombre = vTabla.Rows(0).Item("key_name")
            vFile.Version = vTabla.Rows(0).Item("key_ver")
        End If
        Return vFile
    End Function

    Public Sub UploadKey(ByVal pName As String, ByVal pFile As Byte())
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("UPDATE config SET key_file=?keyfile,key_name=?file,key_ver=key_ver+1", gConn)
        vCmd.Parameters.AddWithValue("?keyfile", pFile)
        'vCmd.Parameters.AddWithValue("?id", pEmpresa)
        vCmd.Parameters.AddWithValue("?file", pName)
        vCmd.ExecuteNonQuery()
    End Sub

    'Public Function GetConfiguracionEmpresa(ByVal pId As Integer) As cConfigEmpresa
    '    If gConn.State <> ConnectionState.Open Then gConn.Open()
    '    Dim vCmd As New MySqlCommand("SELECT serie,ws_url,sat_user,sat_token,no_certificado,pass,cer_name,key_name,cer_ver,key_ver, rfc, razon_social, lugar_exp FROM empresas WHERE id=id", gConn)
    '    vCmd.Parameters.AddWithValue("?id", pId)
    '    Dim vAdap As New MySqlDataAdapter(vCmd)
    '    Dim vTabla As New DataTable
    '    vAdap.Fill(vTabla)
    '    Dim vConfig As cConfigEmpresa
    '    If vTabla.Rows.Count > 0 Then
    '        vConfig = New cConfigEmpresa
    '        With vTabla.Rows(0)
    '            vConfig.Serie = .Item("serie")
    '            vConfig.WebServiceURL = .Item("ws_url")
    '            vConfig.Sat_Usuario = .Item("sat_user")
    '            vConfig.Sat_Token = .Item("sat_token")
    '            vConfig.No_certificado = .Item("no_certificado")
    '            vConfig.PasswordCertificado = .Item("pass")
    '            vConfig.CerName = .Item("cer_name")
    '            vConfig.KeyName = .Item("key_name")
    '            vConfig.Cer_ver = .Item("cer_ver")
    '            vConfig.Key_ver = .Item("key_ver")
    '            vConfig.RFC = .Item("RFC")
    '            vConfig.RazonSocial = .Item("razon_social")
    '            vConfig.LugarExpedicion = .Item("lugar_exp")
    '        End With
    '    End If
    '    Return vConfig
    'End Function

    'Public Sub GuardarConfiguracionEmpresa(ByVal pId As Integer, ByVal pConfEmp As cConfigEmpresa)
    '    If gConn.State <> ConnectionState.Open Then gConn.Open()
    '    Dim vCmd As New MySqlCommand("UPDATE empresas SET serie=?serie,no_certificado=?cer,pass=?pass, rfc=?rfc,razon_social=?razon,lugar_exp=?lugar,ws_url=?ws,sat_user=?satu,sat_token=?satt  WHERE id=id", gConn)
    '    vCmd.Parameters.AddWithValue("?id", pId)
    '    vCmd.Parameters.AddWithValue("?serie", pConfEmp.Serie)
    '    vCmd.Parameters.AddWithValue("?cer", pConfEmp.No_certificado)
    '    vCmd.Parameters.AddWithValue("?pass", pConfEmp.PasswordCertificado)
    '    vCmd.Parameters.AddWithValue("?lugar", pConfEmp.LugarExpedicion)
    '    vCmd.Parameters.AddWithValue("?rfc", pConfEmp.RFC)
    '    vCmd.Parameters.AddWithValue("?razon", pConfEmp.RazonSocial)
    '    vCmd.Parameters.AddWithValue("?ws", pConfEmp.WebServiceURL)
    '    vCmd.Parameters.AddWithValue("?satu", pConfEmp.Sat_Usuario)
    '    vCmd.Parameters.AddWithValue("?satt", pConfEmp.Sat_Token)
    '    vCmd.ExecuteNonQuery()
    'End Sub

    Public Function GetConfiguracion(ByVal RfcEmisor As String)
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        'Dim vCmd As New MySqlCommand("SELECT * FROM config", gConn)
        Dim vCmd As New MySqlCommand("SELECT * FROM config WHERE rfc=?rfc", gConn)
        vCmd.Parameters.AddWithValue("?rfc", RfcEmisor)
        Dim vAdap As New MySqlDataAdapter(vCmd)
        Dim vTabla As New DataTable
        vAdap.Fill(vTabla)
        Dim vConfig As dConfigGlobal
        If vTabla.Rows.Count > 0 Then
            vConfig = New dConfigGlobal
            With vTabla.Rows(0)
                'MsgBox(.Item("id"))
                vConfig.NextFolio = .Item("nextfolio")
                vConfig.IVA = .Item("iva")
                vConfig.TipoCambio = .Item("tipo_cambio")
                vConfig.Serie = .Item("serie")
                vConfig.TipoCambio = .Item("tipo_cambio")
                vConfig.Registro_Federal = .Item("rfc")
                vConfig.Cer_Ver = .Item("cer_ver")
                vConfig.Key_Ver = .Item("key_ver")
                vConfig.PassCert = .Item("pass")
                vConfig.NoCertificado = .Item("no_cer")
                If Not IsDBNull(.Item("cer_name")) Then vConfig.Cer_Name = .Item("cer_name")
                If Not IsDBNull(.Item("key_name")) Then vConfig.Key_Name = .Item("key_name")
                vConfig.CFDI_Token = .Item("cfdi_token")
                vConfig.CFDI_Url = .Item("cfdi_url")
                vConfig.CFDI_Id = .Item("cfdi_id")
                vConfig.CFDI_CancelWs = .Item("cfdi_can_url")
                vConfig.CFDI_CancelId = .Item("cfdi_can_id")
                vConfig.RazonSocial = .Item("razon_social")
                vConfig.RegimenFiscal = .Item("regimen_fiscal")
                vConfig.Direccion_Fiscal.Calle = .Item("df_calle")
                vConfig.Direccion_Fiscal.CodigoPostal = .Item("df_cp")
                vConfig.Direccion_Fiscal.Colonia = .Item("df_colonia")
                vConfig.Direccion_Fiscal.Estado = .Item("df_estado")
                vConfig.Direccion_Fiscal.Localidad = .Item("df_localidad")
                vConfig.Direccion_Fiscal.Municipio = .Item("df_municipio")
                vConfig.Direccion_Fiscal.NoExterior = .Item("df_noext")
                vConfig.Direccion_Fiscal.NoInterior = .Item("df_noint")
                vConfig.Direccion_Fiscal.Referencia = .Item("df_ref")
                vConfig.Direccion_Fiscal.Pais = .Item("df_pais")
                If vTabla.Columns.Contains("prov_timbrado") Then
                    vConfig.ProveedorTimbres = .Item("prov_timbrado")
                Else
                    vConfig.ProveedorTimbres = eProveedorTimbres.Advans
                End If
            End With

        End If

        'Dim vDate As New Date(2000, 1, 1)
        'Dim vMaxDate As New Date(2100, 12, 31)
        'vCmd = New MySqlCommand("INSERT INTO fechas(fecha) VALUES(?fecha)", gConn)
        'While (vDate < vMaxDate)
        '    vCmd.Parameters.Clear()
        '    vCmd.Parameters.AddWithValue("?fecha", vDate.Date)
        '    vCmd.ExecuteNonQuery()
        '    vDate = vDate.AddDays(1)
        'End While
        Return vConfig
    End Function
    Public Function GetConfiguracionEmisor(ByVal RfcEmisor As String)
        If gConn.State <> ConnectionState.Open Then gConn.Open()

        Dim vCmd As New MySqlCommand("SELECT * FROM config WHERE rfc=?rfc", gConn)
        vCmd.Parameters.AddWithValue("?rfc", RfcEmisor)
        'Dim vCmd As New MySqlCommand("SELECT * FROM config", gConn)
        Dim vAdap As New MySqlDataAdapter(vCmd)
        Dim vTabla As New DataTable
        vAdap.Fill(vTabla)
        Dim vConfig As dConfigGlobal
        If vTabla.Rows.Count > 0 Then
            vConfig = New dConfigGlobal
            If RfcEmisor = "BAMG670420V91" Then
                With vTabla.Rows(1)
                    vConfig.NextFolio = .Item("nextfolio")
                    vConfig.IVA = .Item("iva")
                    vConfig.TipoCambio = .Item("tipo_cambio")
                    vConfig.Serie = .Item("serie")
                    vConfig.TipoCambio = .Item("tipo_cambio")
                    vConfig.Registro_Federal = .Item("rfc")
                    vConfig.Cer_Ver = .Item("cer_ver")
                    vConfig.Key_Ver = .Item("key_ver")
                    vConfig.PassCert = .Item("pass")
                    vConfig.NoCertificado = .Item("no_cer")
                    If Not IsDBNull(.Item("cer_name")) Then vConfig.Cer_Name = .Item("cer_name")
                    If Not IsDBNull(.Item("key_name")) Then vConfig.Key_Name = .Item("key_name")
                    vConfig.CFDI_Token = .Item("cfdi_token")
                    vConfig.CFDI_Url = .Item("cfdi_url")
                    vConfig.CFDI_Id = .Item("cfdi_id")
                    vConfig.CFDI_CancelWs = .Item("cfdi_can_url")
                    vConfig.CFDI_CancelId = .Item("cfdi_can_id")
                    vConfig.RazonSocial = .Item("razon_social")
                    vConfig.RegimenFiscal = .Item("regimen_fiscal")
                    vConfig.Direccion_Fiscal.Calle = .Item("df_calle")
                    vConfig.Direccion_Fiscal.CodigoPostal = .Item("df_cp")
                    vConfig.Direccion_Fiscal.Colonia = .Item("df_colonia")
                    vConfig.Direccion_Fiscal.Estado = .Item("df_estado")
                    vConfig.Direccion_Fiscal.Localidad = .Item("df_localidad")
                    vConfig.Direccion_Fiscal.Municipio = .Item("df_municipio")
                    vConfig.Direccion_Fiscal.NoExterior = .Item("df_noext")
                    vConfig.Direccion_Fiscal.NoInterior = .Item("df_noint")
                    vConfig.Direccion_Fiscal.Referencia = .Item("df_ref")
                    vConfig.Direccion_Fiscal.Pais = .Item("df_pais")
                    vConfig.ProveedorTimbres = .Item("prov_timbrado")
                End With
            End If
            If RfcEmisor = "BAMF650219E70" Then
                With vTabla.Rows(0)
                    vConfig.NextFolio = .Item("nextfolio")
                    vConfig.IVA = .Item("iva")
                    vConfig.TipoCambio = .Item("tipo_cambio")
                    vConfig.Serie = .Item("serie")
                    vConfig.TipoCambio = .Item("tipo_cambio")
                    vConfig.Registro_Federal = .Item("rfc")
                    vConfig.Cer_Ver = .Item("cer_ver")
                    vConfig.Key_Ver = .Item("key_ver")
                    vConfig.PassCert = .Item("pass")
                    vConfig.NoCertificado = .Item("no_cer")
                    If Not IsDBNull(.Item("cer_name")) Then vConfig.Cer_Name = .Item("cer_name")
                    If Not IsDBNull(.Item("key_name")) Then vConfig.Key_Name = .Item("key_name")
                    vConfig.CFDI_Token = .Item("cfdi_token")
                    vConfig.CFDI_Url = .Item("cfdi_url")
                    vConfig.CFDI_Id = .Item("cfdi_id")
                    vConfig.CFDI_CancelWs = .Item("cfdi_can_url")
                    vConfig.CFDI_CancelId = .Item("cfdi_can_id")
                    vConfig.RazonSocial = .Item("razon_social")
                    vConfig.RegimenFiscal = .Item("regimen_fiscal")
                    vConfig.Direccion_Fiscal.Calle = .Item("df_calle")
                    vConfig.Direccion_Fiscal.CodigoPostal = .Item("df_cp")
                    vConfig.Direccion_Fiscal.Colonia = .Item("df_colonia")
                    vConfig.Direccion_Fiscal.Estado = .Item("df_estado")
                    vConfig.Direccion_Fiscal.Localidad = .Item("df_localidad")
                    vConfig.Direccion_Fiscal.Municipio = .Item("df_municipio")
                    vConfig.Direccion_Fiscal.NoExterior = .Item("df_noext")
                    vConfig.Direccion_Fiscal.NoInterior = .Item("df_noint")
                    vConfig.Direccion_Fiscal.Referencia = .Item("df_ref")
                    vConfig.Direccion_Fiscal.Pais = .Item("df_pais")
                    vConfig.ProveedorTimbres = .Item("prov_timbrado")
                End With
            End If
        End If
        Return vConfig
    End Function

    Public Sub GuardarConfiguracion(ByVal pConfig As dConfigGlobal, ByVal rfc As String)
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("UPDATE config SET tipo_cambio=?tc, nextfolio=?folio,iva=?iva,rfc=?reg, tipo_cambio=?tcambio, pass=?pass, no_cer=?nocer, serie=?serie,cfdi_token=?token, cfdi_id=?cfdi_id, cfdi_url=?ws, razon_social=?razon, regimen_fiscal=?regimen, df_calle=?calle, df_noext=?noext, df_noint=?noint, df_colonia=?col, df_localidad=?loc, df_ref=?ref, df_municipio=?mun, df_estado=?estado, df_pais=?pais, df_cp=?cp, cfdi_can_url=?wscan, cfdi_can_id=?canid where rfc=?rfc", gConn)
        vCmd.Parameters.AddWithValue("?rfc", rfc)
        vCmd.Parameters.AddWithValue("?folio", pConfig.NextFolio)
        vCmd.Parameters.AddWithValue("?iva", pConfig.IVA)
        vCmd.Parameters.AddWithValue("?reg", pConfig.Registro_Federal)
        vCmd.Parameters.AddWithValue("?tcambio", pConfig.TipoCambio)
        vCmd.Parameters.AddWithValue("?pass", pConfig.PassCert)
        vCmd.Parameters.AddWithValue("?nocer", pConfig.NoCertificado)
        vCmd.Parameters.AddWithValue("?serie", pConfig.Serie)
        vCmd.Parameters.AddWithValue("?token", pConfig.CFDI_Token)
        vCmd.Parameters.AddWithValue("?cfdi_id", pConfig.CFDI_Id)
        vCmd.Parameters.AddWithValue("?ws", pConfig.CFDI_Url)
        vCmd.Parameters.AddWithValue("?razon", pConfig.RazonSocial)
        vCmd.Parameters.AddWithValue("?regimen", pConfig.RegimenFiscal)
        vCmd.Parameters.AddWithValue("?calle", pConfig.Direccion_Fiscal.Calle)
        vCmd.Parameters.AddWithValue("?noext", pConfig.Direccion_Fiscal.NoExterior)
        vCmd.Parameters.AddWithValue("?noint", pConfig.Direccion_Fiscal.NoInterior)
        vCmd.Parameters.AddWithValue("?col", pConfig.Direccion_Fiscal.Colonia)
        vCmd.Parameters.AddWithValue("?loc", pConfig.Direccion_Fiscal.Localidad)
        vCmd.Parameters.AddWithValue("?ref", pConfig.Direccion_Fiscal.Referencia)
        vCmd.Parameters.AddWithValue("?mun", pConfig.Direccion_Fiscal.Municipio)
        vCmd.Parameters.AddWithValue("?estado", pConfig.Direccion_Fiscal.Estado)
        vCmd.Parameters.AddWithValue("?pais", pConfig.Direccion_Fiscal.Pais)
        vCmd.Parameters.AddWithValue("?cp", pConfig.Direccion_Fiscal.CodigoPostal)
        vCmd.Parameters.AddWithValue("?wscan", pConfig.CFDI_CancelWs)
        vCmd.Parameters.AddWithValue("?canid", pConfig.CFDI_CancelId)
        vCmd.Parameters.AddWithValue("?tc", pConfig.TipoCambio)
        vCmd.ExecuteNonQuery()
    End Sub


    Public Function GetNextFolio(ByVal rfc As String) As Integer
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As MySqlCommand

        vCmd = New MySqlCommand("SELECT nextfolio FROM config where rfc=?rfc", gConn)
        vCmd.Parameters.AddWithValue("?rfc", rfc)
        Dim vFolio As Object = vCmd.ExecuteScalar
        If Not IsNumeric(vFolio) Then
            Return -1
        Else : Return vFolio
        End If
    End Function

    Public Sub UseNextFolio()
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As MySqlCommand
        vCmd = New MySqlCommand("UPDATE config SET nextfolio=nextfolio+1", gConn)
        vCmd.ExecuteNonQuery()
    End Sub


    'Public Function GetMinVersion() As cMinVersion
    '    If gConn.State <> ConnectionState.Open Then gConn.Open()
    '    Dim vCmd As New MySqlCommand("SELECT * FROM version_min LIMIT 1", gConn)
    '    Dim vAdap As New MySqlDataAdapter(vCmd)
    '    Dim vTabla As New DataTable
    '    vAdap.Fill(vTabla)
    '    Dim vVersion As cMinVersion
    '    If vTabla.Rows.Count > 0 Then
    '        vVersion = New cMinVersion
    '        vVersion.Major = vTabla.Rows(0).Item("major")
    '        vVersion.Minor = vTabla.Rows(0).Item("minor")
    '        vVersion.Build = vTabla.Rows(0).Item("build")
    '    End If
    '    Return vVersion
    'End Function

End Class



Public Class dConfigGlobal
    Public NextFolio As Integer
    Public Serie As String
    Public IVA As Double
    Public Registro_Federal As String
    Public RazonSocial As String
    Public RegimenFiscal As String
    Public TipoCambio As Double
    Public Cer_Ver As Integer
    Public Key_Ver As Integer
    Public Cer_Name As String
    Public Key_Name As String
    Public PassCert As String
    Public NoCertificado As String
    Public CFDI_Token As String
    Public CFDI_Id As String
    Public CFDI_Url As String
    Public CFDI_CancelWs As String
    Public CFDI_CancelId As String
    Public Direccion_Fiscal As New dDireccion
    Public ProveedorTimbres As eProveedorTimbres
    'Public TipoCambio As Double
End Class

Public Enum eProveedorTimbres
    ExpideTuFactura = 1
    Advans = 2
    FEL = 3
End Enum

Public Class dDireccion
    Public Calle As String
    Public NoExterior As String
    Public NoInterior As String
    Public Colonia As String
    Public Localidad As String
    Public Referencia As String
    Public Municipio As String
    Public Estado As String
    Public Pais As String
    Public CodigoPostal As String
End Class

Public Class dArchivo
    Public Nombre As String
    Public Version As Integer
    Public File As Byte()
End Class

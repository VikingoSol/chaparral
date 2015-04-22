Imports MySql.Data.MySqlClient
Public Class cFacturas

    Public Shared Function GetFacturaXML(ByVal pId As Integer)
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("SELECT xml_sat FROM facturas WHERE facturas.id=?id", gConn)
        vCmd.Parameters.AddWithValue("?id", pId)
        Dim vAdap As New MySqlDataAdapter(vCmd)
        Dim vTable As New DataTable
        Dim vXML As String = ""
        vAdap.Fill(vTable)
        If vTable.Rows.Count = 1 Then
            vXML = vTable.Rows(0).Item("xml_sat")
        End If
        Return vXML
    End Function

    Public Shared Sub Cancelar(ByVal pId As Integer, ByVal pIdAcuse As Integer)
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("UPDATE facturas SET estado=?estado, cancelacion=?idcan WHERE id=?id", gConn)
        vCmd.Parameters.AddWithValue("?idcan", pIdAcuse)
        vCmd.Parameters.AddWithValue("?estado", False)
        vCmd.Parameters.AddWithValue("?id", pId)
        vCmd.ExecuteNonQuery()
    End Sub

    Public Shared Function RequestCancelacion(ByVal pResponse As String, ByVal pAcuse As String) As Integer
        Try
            If gConn.State <> ConnectionState.Open Then gConn.Open()
            Dim vCmd As New MySqlCommand("INSERT INTO req_cancels(fecha,response,acuse) VALUES(now(),?res,?acuse)", gConn)
            vCmd.Parameters.AddWithValue("?res", pResponse)
            vCmd.Parameters.AddWithValue("?acuse", pAcuse)
            vCmd.ExecuteNonQuery()
            Return vCmd.LastInsertedId
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al registrar Request al SAT")
        End Try
        Return -1
    End Function

    Public Shared Function GetFacturasXML(ByVal pFechaIni As Date, ByVal pFechaFin As Date) As DataTable
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("SELECT xml_sat,folio,serie FROM facturas WHERE estado=1 AND fecha_emision BETWEEN ?f1 AND ?f2", gConn)
        vCmd.Parameters.AddWithValue("?f1", pFechaIni)
        vCmd.Parameters.AddWithValue("?f2", pFechaFin)
        Dim vAdap As New MySqlDataAdapter(vCmd)
        Dim vTable As New DataTable
        Dim vXML As String = ""
        vAdap.Fill(vTable)
        Return vTable
    End Function

    Public Shared Function GetNumFacturas(ByVal pFechaIni As Date, ByVal pFechaFin As Date) As Integer
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("SELECT COUNT(*) FROM facturas WHERE estado=1 AND fecha_emision BETWEEN ?fe1 AND ?fe2", gConn)
        vCmd.Parameters.AddWithValue("?fe1", pFechaIni)
        vCmd.Parameters.AddWithValue("?fe2", pFechaFin)
        Dim vObj As Object = vCmd.ExecuteScalar
        If Not IsNumeric(vObj) Then
            Return 0
        Else
            Return CInt(vObj)
        End If
    End Function

    Public Function GetFactura(ByVal pId As Integer)
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("SELECT  facturas.id,metodo_pago,digitos_cta,folio,serie,fecha_emision,idcliente,subtotal,iva,total,xml,xml_sat,acuse,folio_fiscal,fecha_cer,facturas.estado as festado,clientes.*,mp.metodo,facturas.descuento  FROM ( facturas INNER JOIN clientes ON facturas.idcliente=clientes.id) INNER JOIN metodos_pago mp ON metodo_pago=mp.id WHERE facturas.id=?id", gConn)
        vCmd.Parameters.AddWithValue("?id", pId)
        Dim vAdap As New MySqlDataAdapter(vCmd)
        Dim vTable As New DataTable
        vAdap.Fill(vTable)
        Dim vFac As dFacturaView
        If vTable.Rows.Count > 0 Then
            vFac = New dFacturaView
            With vTable.Rows(0)
                vFac.Id = pId
                vFac.Fecha_Certificacion = .Item("fecha_cer")
                vFac.Cliente_Direccion = .Item("calle")
                If .Item("no_ext") <> "" Then vFac.Cliente_Direccion &= " #" & .Item("no_ext")
                If .Item("no_int") <> "" Then vFac.Cliente_Direccion &= " No. Int. " & .Item("no_int")
                If .Item("colonia") <> "" Then vFac.Cliente_Direccion &= Environment.NewLine & "Col. " & .Item("Colonia")
                If .Item("localidad") <> "" Then vFac.Cliente_Direccion &= Environment.NewLine & .Item("localidad")
                If .Item("localidad") <> "" And .Item("estado") <> "" Then vFac.Cliente_Direccion &= ","
                If .Item("estado") <> "" Then vFac.Cliente_Direccion &= " " & .Item("estado")
                If .Item("pais") <> "" Then vFac.Cliente_Direccion &= Environment.NewLine & .Item("pais")
                vFac.Cliente_Nombre = .Item("nombre")
                vFac.Cliente_RFC = .Item("rfc")
                vFac.Estado = .Item("festado")
                vFac.Fecha_Certificacion = .Item("fecha_cer")
                vFac.Fecha_Emision = .Item("fecha_emision")
                vFac.Folio = .Item("folio")
                vFac.Folio_Fiscal = .Item("folio_fiscal")
                vFac.IVA = .Item("iva")
                vFac.Serie = .Item("serie")
                vFac.SubTotal = .Item("subtotal")
                vFac.Total = .Item("total")
                vFac.xml_acuse = .Item("acuse")
                vFac.xml_Timbrado = .Item("xml_sat")
                vFac.Metodo_Pago = .Item("metodo_pago")
                vFac.Metodo_PagoTxt = .Item("metodo")
                vFac.Cuenta = .Item("digitos_cta")                              
                If Not IsDBNull(.Item("digitos_cta")) Then vFac.Cuenta = .Item("digitos_cta")
                vFac.RetencionIVA = .Item("retiva")
                vFac.Descuento = .Item("Descuento")
            End With
        End If
        Return vFac
    End Function


    Public Function GetMetodosPago() As DataTable
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("SELECT * FROM metodos_pago", gConn)
        Dim vAdap As New MySqlDataAdapter(vCmd)
        Dim vTabla As New DataTable
        vAdap.Fill(vTabla)
        Return vTabla
    End Function

    Public Function GetProductosFacturados(ByVal pId As Integer) As DataTable
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("select pf.*,IF(pf.producto>0,p.nombre,pf.producto_nombre) as productonombre, unidades.unidad as nom_uni from (productos_facturados pf LEFT JOIN productos p ON pf.producto=p.id) INNER JOIN unidades ON pf.unidad=unidades.id WHERE pf.factura=?id", gConn)
        vCmd.Parameters.AddWithValue("?id", pId)
        Dim vAdap As New MySqlDataAdapter(vCmd)
        Dim vTabla As New DataTable
        vAdap.Fill(vTabla)
        Return vTabla
    End Function

    Public Function GetFacturas(ByVal pDesde As Date) As DataTable
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("SELECT facturas.*,clientes.nombre as cliente FROM facturas INNER JOIN clientes ON facturas.idcliente=clientes.id WHERE fecha_emision>=?fecha", gConn)
        vCmd.Parameters.AddWithValue("?fecha", pDesde)
        Dim vAdap As New MySqlDataAdapter(vCmd)
        Dim vTabla As New DataTable
        vAdap.Fill(vTabla)
        Return vTabla
    End Function

    Public Sub Request(ByVal pTimbre As String, ByVal pAcuse As String)
        Try
            If gConn.State <> ConnectionState.Open Then gConn.Open()
            Dim vCmd As New MySqlCommand("INSERT INTO request_sat(fecha,xml,acuse) VALUES(now(),?xml,?acuse)", gConn)
            vCmd.Parameters.AddWithValue("?xml", pTimbre)
            vCmd.Parameters.AddWithValue("?acuse", pAcuse)
            vCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al registrar Request al SAT")
        End Try
    End Sub

    Public Function Agregar(ByVal pSerie As String, ByVal pFolio As String, ByVal pFechaEm As Date, _
    ByVal pIdCliente As Integer, ByVal pSubTotal As Double, ByVal pIVA As Double, ByVal pTotal As Double, _
    ByVal pXml As String, ByVal pTimbre As String, ByVal pAcuse As String, ByVal pFolioFiscal As String, _
    ByVal pFechaTimbrado As DateTime, ByVal pMetodoPago As String, ByVal pCuenta As String, ByVal pRetIva As Double, ByVal pDescuento As Double, ByVal rfcEmisor As String)
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("INSERT INTO facturas(serie,folio,fecha_emision,idcliente,subtotal,iva,total,xml,xml_sat,acuse,folio_fiscal,fecha_cer,metodo_pago, digitos_cta, retiva,descuento,rfc_emisor) VALUES(?serie,?folio,?fecha,?cliente,?subtotal,?iva,?total,?xml,?xmlsat,?acuse,?foliof,?fechacer, ?mpago,?cta, ?riva, ?descuento, ?rfcemisor)", gConn)
        vCmd.Parameters.AddWithValue("?serie", pSerie)
        vCmd.Parameters.AddWithValue("?folio", pFolio)
        vCmd.Parameters.AddWithValue("?fecha", pFechaEm)
        vCmd.Parameters.AddWithValue("?cliente", pIdCliente)
        vCmd.Parameters.AddWithValue("?subtotal", pSubTotal)
        vCmd.Parameters.AddWithValue("?iva", pIVA)
        vCmd.Parameters.AddWithValue("?total", pTotal)
        vCmd.Parameters.AddWithValue("?xml", pXml)
        vCmd.Parameters.AddWithValue("?xmlsat", pTimbre)
        vCmd.Parameters.AddWithValue("?acuse", pAcuse)
        vCmd.Parameters.AddWithValue("?foliof", pFolioFiscal)
        vCmd.Parameters.AddWithValue("?fechacer", pFechaTimbrado)
        vCmd.Parameters.AddWithValue("?mpago", pMetodoPago)
        vCmd.Parameters.AddWithValue("?cta", pCuenta)
        vCmd.Parameters.AddWithValue("?riva", pRetIva)
        vCmd.Parameters.AddWithValue("?descuento", pDescuento)
        vCmd.Parameters.AddWithValue("?rfcEmisor", rfcEmisor)
        vCmd.ExecuteNonQuery()
        Dim vLastID As Long = vCmd.LastInsertedId
        vCmd = New MySqlCommand("UPDATE config SET nextfolio=nextfolio+1", gConn)
        vCmd.ExecuteNonQuery()
        Return vLastID
    End Function

    Public Sub AgregarProducto(ByVal pIdFactura As Integer, ByVal pCodigo As String, ByVal pIdProd As Integer, ByVal pCantidad As Double, ByVal pPrecio As Double, ByVal pUnidad As Integer, ByVal pIsProducto As Boolean, ByVal pProducto As String, ByVal pTasa As Double)
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("INSERT INTO productos_facturados(factura,producto,cantidad,precio,unidad,isproducto,producto_nombre, tasa,codigo) VALUES(?fac,?prod,?cant,?precio,?unidad,?isproducto,?producto, ?tasa, ?codigo)", gConn)
        vCmd.Parameters.AddWithValue("?fac", pIdFactura)
        vCmd.Parameters.AddWithValue("?codigo", pCodigo)
        vCmd.Parameters.AddWithValue("?prod", pIdProd)
        vCmd.Parameters.AddWithValue("?cant", pCantidad)
        vCmd.Parameters.AddWithValue("?precio", pPrecio)
        vCmd.Parameters.AddWithValue("?isproducto", pIsProducto)
        vCmd.Parameters.AddWithValue("?producto", pProducto)
        vCmd.Parameters.AddWithValue("?unidad", pUnidad)
        vCmd.Parameters.AddWithValue("?tasa", pTasa)
        vCmd.ExecuteNonQuery()
    End Sub

End Class

Public Class dFacturaView
    Public Id As Integer
    Public Folio As String
    Public Serie As String
    Public Fecha_Emision As Date
    Public Cuenta As String
    Public Cliente_Nombre As String
    Public Cliente_RFC As String
    Public Cliente_Direccion As String
    Public Cliente_Pais As String
    Public xml_Timbrado As String
    Public xml_acuse As String
    Public Estado As Integer
    Public SubTotal As Double
    Public IVA As Double
    Public Total As Double
    Public Folio_Fiscal As String
    Public Fecha_Certificacion As String
    Public Metodo_Pago As Integer
    Public Metodo_PagoTxt As String
    Public RetencionIVA As Double
    Public Descuento As Double
End Class

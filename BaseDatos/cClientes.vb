Imports MySql.Data.MySqlClient
Public Class cClientes

    Public Sub Eliminar(ByVal pId As Integer)
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("DELETE FROM clientes WHERE id=?id", gConn)
        vCmd.Parameters.AddWithValue("?id", pId)
        vCmd.ExecuteNonQuery()
    End Sub

    Public Function GetClientes() As DataTable
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("SELECT id,nombre,rfc FROM clientes", gConn)
        Dim vAdap As New MySqlDataAdapter(vCmd)
        Dim vTabla As New DataTable
        vAdap.Fill(vTabla)
        Return vTabla
    End Function

    Public Function Existe_Cliente(ByVal pCliente As String, ByVal pIdDiff As Integer) As Boolean
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("SELECT COUNT(*) FROM clientes WHERE nombre=?nom AND id<>?id", gConn)
        vCmd.Parameters.AddWithValue("?nom", pCliente)
        vCmd.Parameters.AddWithValue("?id", pIdDiff)
        Dim vRes As Object = vCmd.ExecuteScalar
        If IsNothing(vRes) OrElse IsDBNull(vRes) OrElse vRes <= 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function ExisteId(ByVal pIdCliente As Integer) As Boolean
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("SELECT COUNT(*) FROM clientes WHERE id=?id", gConn)
        vCmd.Parameters.AddWithValue("?id", pIdCliente)
        Dim vRes As Object = vCmd.ExecuteScalar
        If IsNothing(vRes) OrElse IsDBNull(vRes) OrElse vRes <= 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function Agregar(ByVal pNombre As String, ByVal pRFC As String, ByVal pCalle As String, ByVal pNoInt As String, ByVal pNoExt As String, ByVal pColonia As String, ByVal pLocalidad As String, ByVal pReferencia As String, ByVal pMunicipio As String, ByVal pEstado As String, ByVal pPais As String, ByVal pCP As String, ByVal pRetIVA As Boolean, ByVal pDescFactura As Double) As Integer
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("INSERT INTO clientes(rfc, nombre, calle, no_ext, no_int, colonia, localidad, referencia, municipio, estado, pais, cp, retiva, DescFactura) VALUE(?rfc, ?nombre, ?calle, ?no_ext, ?no_int, ?colonia, ?localidad, ?referencia, ?municipio, ?estado, ?pais, ?cp, ?riva,  ?DescFactura)", gConn)
        vCmd.Parameters.AddWithValue("?rfc", pRFC)
        vCmd.Parameters.AddWithValue("?nombre", Trim(pNombre))
        vCmd.Parameters.AddWithValue("?calle", Trim(pCalle))
        vCmd.Parameters.AddWithValue("?no_ext", Trim(pNoExt))
        vCmd.Parameters.AddWithValue("?no_int", Trim(pNoInt))
        vCmd.Parameters.AddWithValue("?colonia", Trim(pColonia))
        vCmd.Parameters.AddWithValue("?localidad", Trim(pLocalidad))
        vCmd.Parameters.AddWithValue("?referencia", Trim(pReferencia))
        vCmd.Parameters.AddWithValue("?municipio", Trim(pMunicipio))
        vCmd.Parameters.AddWithValue("?estado", Trim(pEstado))
        vCmd.Parameters.AddWithValue("?pais", Trim(pPais))
        vCmd.Parameters.AddWithValue("?cp", Trim(pCP))
        vCmd.Parameters.AddWithValue("?riva", Convert.ToInt32(pRetIVA))
        vCmd.Parameters.AddWithValue("?DescFactura", Convert.ToInt32(pDescFactura))
        vCmd.ExecuteNonQuery()
        Return vCmd.LastInsertedId
    End Function

    Public Function Modificar(ByVal pId As Integer, ByVal pNombre As String, ByVal pRFC As String, ByVal pCalle As String, _
    ByVal pNoInt As String, ByVal pNoExt As String, ByVal pColonia As String, ByVal pLocalidad As String, ByVal pReferencia As String, _
    ByVal pMunicipio As String, ByVal pEstado As String, ByVal pPais As String, ByVal pCP As String, ByVal pRetIva As Boolean, ByVal pDescFactura As Double) As Integer
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("UPDATE clientes SET rfc=?rfc, nombre=?nombre, calle= ?calle, no_ext=?no_ext, no_int=?no_int, colonia=?colonia, localidad=?localidad, referencia=?referencia, municipio=?municipio, estado=?estado, pais=?pais, cp=?cp, retiva=?riva, DescFactura=?DescFactura WHERE id=?id", gConn)
        vCmd.Parameters.AddWithValue("?rfc", pRFC)
        vCmd.Parameters.AddWithValue("?nombre", Trim(pNombre))
        vCmd.Parameters.AddWithValue("?calle", Trim(pCalle))
        vCmd.Parameters.AddWithValue("?no_ext", Trim(pNoExt))
        vCmd.Parameters.AddWithValue("?no_int", Trim(pNoInt))
        vCmd.Parameters.AddWithValue("?colonia", Trim(pColonia))
        vCmd.Parameters.AddWithValue("?localidad", Trim(pLocalidad))
        vCmd.Parameters.AddWithValue("?referencia", Trim(pReferencia))
        vCmd.Parameters.AddWithValue("?municipio", Trim(pMunicipio))
        vCmd.Parameters.AddWithValue("?estado", Trim(pEstado))
        vCmd.Parameters.AddWithValue("?pais", Trim(pPais))
        vCmd.Parameters.AddWithValue("?cp", Trim(pCP))
        vCmd.Parameters.AddWithValue("?id", pId)
        vCmd.Parameters.AddWithValue("?riva", Convert.ToInt32(pRetIva))
        vCmd.Parameters.AddWithValue("?DescFactura", Convert.ToInt32(pDescFactura))
        vCmd.ExecuteNonQuery()
        Return vCmd.LastInsertedId
    End Function


    Public Function GetCliente(ByVal pId As Integer) As dCliente
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("SELECT * FROM clientes WHERE id=?id", gConn)
        vCmd.Parameters.AddWithValue("?id", pId)
        Dim vAdap As New MySqlDataAdapter(vCmd)
        Dim vTabla As New DataTable
        vAdap.Fill(vTabla)
        Dim vCl As dCliente
        If vTabla.Rows.Count > 0 Then
            vCl = New dCliente
            vCl.Id = pId
            vCl.Nombre = vTabla.Rows(0).Item("nombre")
            vCl.RFC = vTabla.Rows(0).Item("rfc")
            vCl.Calle = vTabla.Rows(0).Item("calle")
            vCl.NoExterior = vTabla.Rows(0).Item("no_ext")
            vCl.NoInterior = vTabla.Rows(0).Item("no_int")
            vCl.Colonia = vTabla.Rows(0).Item("colonia")
            vCl.Localidad = vTabla.Rows(0).Item("localidad")
            vCl.Referencia = vTabla.Rows(0).Item("referencia")
            vCl.Municipio = vTabla.Rows(0).Item("municipio")
            vCl.Estado = vTabla.Rows(0).Item("estado")
            vCl.Pais = vTabla.Rows(0).Item("pais")
            vCl.CP = vTabla.Rows(0).Item("cp")
            vCl.Email = vTabla.Rows(0).Item("email")
            vCl.RetieneIva = vTabla.Rows(0).Item("retiva")
            vCl.DescFactura = vTabla.Rows(0).Item("DescFactura")
        End If
        Return vCl
    End Function

End Class


Public Class dCliente
    Public Id As Integer
    Public Nombre As String
    Public RFC As String
    Public Calle As String
    Public NoExterior As String
    Public NoInterior As String
    Public Colonia As String
    Public Localidad As String
    Public Referencia As String
    Public Municipio As String
    Public Estado As String
    Public Pais As String
    Public CP As String
    Public Email As String
    Public RetieneIva As Boolean
    Public DescFactura As Double
End Class

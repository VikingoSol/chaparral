Imports MySql.Data.MySqlClient
Public Class cProductos

    Public Function GetProducto(ByVal pId As Integer) As dProducto
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("SELECT productos. *, unidades.unidad as unidadnom FROM productos INNER JOIN unidades on productos.unidad=unidades.id WHERE productos.id=?id", gConn)
        vCmd.Parameters.AddWithValue("?id", pId)
        Dim vAdap As New MySqlDataAdapter(vCmd)
        Dim vTabla As New DataTable
        vAdap.Fill(vTabla)
        Dim vProd As dProducto
        If vTabla.Rows.Count = 1 Then
            vProd = New dProducto
            vProd.Id = pId
            vProd.Nombre = vTabla.Rows(0).Item("nombre")
            vProd.Precio = vTabla.Rows(0).Item("precio")
            vProd.Unidad = vTabla.Rows(0).Item("unidad")
            vProd.UnidadNom = vTabla.Rows(0).Item("unidadnom")
            vProd.TasaId = vTabla.Rows(0).Item("tasa")
            vProd.TasaPorc = GetTasaPorc(vTabla.Rows(0).Item("tasa"))
            vProd.codigo = vTabla.Rows(0).Item("codigo")
            vProd.idProdcte = vTabla.Rows(0).Item("idProdcte")
        End If
        Return vProd
    End Function

    Public Function GetProductos() As DataTable
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("SELECT * FROM productos", gConn)
        Dim vAdap As New MySqlDataAdapter(vCmd)
        Dim vTabla As New DataTable
        vAdap.Fill(vTabla)
        Return vTabla
    End Function
    Public Function GetProductosClientes(ByVal idcte As Integer) As DataTable
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("SELECT * FROM productos where idprodcte=?id", gConn)
        If hayProductos(idcte) Then
            vCmd.Parameters.AddWithValue("?id", idcte)
        Else
            vCmd.Parameters.AddWithValue("?id", 1)
        End If
        Dim vAdap As New MySqlDataAdapter(vCmd)
        Dim vTabla As New DataTable
        vAdap.Fill(vTabla)
        Return vTabla
    End Function
    Public Function GetUnidades() As DataTable
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("SELECT * FROM unidades ORDER BY unidad", gConn)
        Dim vAdap As New MySqlDataAdapter(vCmd)
        Dim vTabla As New DataTable
        vAdap.Fill(vTabla)
        Return vTabla
    End Function

    Public Function GetTasaPorc(ByVal pId As Integer) As Double
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("SELECT tasas.tasa FROM tasas WHERE tasas.id=?id", gConn)
        vCmd.Parameters.AddWithValue("?id", pId)
        Dim vAdap As New MySqlDataAdapter(vCmd)
        Dim vTabla As New DataTable
        vAdap.Fill(vTabla)
        Return vTabla.Rows(0).Item("tasa")
    End Function

    Public Function GetTasas() As DataTable
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("SELECT * FROM tasas ORDER BY id", gConn)
        Dim vAdap As New MySqlDataAdapter(vCmd)
        Dim vTabla As New DataTable
        vAdap.Fill(vTabla)
        Return vTabla
    End Function

    Public Function Agregar(ByVal pNombre As String, ByVal pPrecio As Double, ByVal pUnidad As Integer, ByVal pTasa As Integer, ByVal pCodigo As String, ByVal pidprodcte As Integer, ByVal pNombrecte As String) As Integer
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("INSERT INTO productos(nombre,precio,unidad, tasa,codigo,idprodcte,Nombrecte) VALUES(?nombre,?precio,?unidad, ?tasa, ?codigo, ?idprodcte, ?Nombrecte)", gConn)
        vCmd.Parameters.AddWithValue("?nombre", pNombre)
        vCmd.Parameters.AddWithValue("?precio", pPrecio)
        vCmd.Parameters.AddWithValue("?unidad", pUnidad)
        vCmd.Parameters.AddWithValue("?tasa", pTasa)
        vCmd.Parameters.AddWithValue("?codigo", pCodigo)
        vCmd.Parameters.AddWithValue("?idprodcte", pidprodcte)
        vCmd.Parameters.AddWithValue("?Nombrecte", pNombrecte)
        vCmd.ExecuteNonQuery()
        Return vCmd.LastInsertedId
    End Function

    Public Sub Eliminar(ByVal pId As Integer)
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("DELETE FROM productos WHERE id=?id", gConn)
        vCmd.Parameters.AddWithValue("?id", pId)
        vCmd.ExecuteNonQuery()
    End Sub

    Public Sub Modificar(ByVal pId As Integer, ByVal pNombre As String, ByVal pPrecio As Double, ByVal pUnidad As Integer, ByVal pTasa As Integer, ByVal pCodigo As String, ByVal pidprodcte As Integer, ByVal pNombrecte As String)
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("UPDATE productos SET nombre=?nombre,precio=?precio,unidad=?unidad, tasa=?tasa, codigo=?codigo, idprodcte=?idprodcte, Nombrecte=?Nombrecte WHERE id=?id", gConn)
        vCmd.Parameters.AddWithValue("?nombre", pNombre)
        vCmd.Parameters.AddWithValue("?precio", pPrecio)
        vCmd.Parameters.AddWithValue("?id", pId)
        vCmd.Parameters.AddWithValue("?unidad", pUnidad)
        vCmd.Parameters.AddWithValue("?tasa", pTasa)
        vCmd.Parameters.AddWithValue("?codigo", pCodigo)
        vCmd.Parameters.AddWithValue("?idprodcte", pidprodcte)
        vCmd.Parameters.AddWithValue("?Nombrecte", pNombrecte)
        vCmd.ExecuteNonQuery()
    End Sub

    Public Function Existe(ByVal pNombre As String, ByVal pIdDiff As Integer)
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("SELECT COUNT(*) FROM productos WHERE nombre=?nom AND id<>?id", gConn)
        vCmd.Parameters.AddWithValue("?id", pIdDiff)
        vCmd.Parameters.AddWithValue("?nom", pNombre)        
        Dim vRes As Object = vCmd.ExecuteScalar
        If IsNothing(vRes) OrElse IsDBNull(vRes) OrElse vRes <= 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function hayProductos(ByVal pid As Integer)
        If gConn.State <> ConnectionState.Open Then gConn.Open()
        Dim vCmd As New MySqlCommand("SELECT COUNT(*) FROM productos WHERE idprodcte=?id", gConn)
        vCmd.Parameters.AddWithValue("?id", pid)
        Dim vRes As Object = vCmd.ExecuteScalar
        If IsNothing(vRes) OrElse IsDBNull(vRes) OrElse vRes <= 0 Then
            Return False
        Else
            Return True
        End If
    End Function

End Class

Public Class dProducto
    Public Id As Integer
    Public Nombre As String
    Public Precio As Double
    Public Unidad As Integer
    Public UnidadNom As String
    Public TasaId As Integer
    Public TasaPorc As Double
    Public codigo As String
    Public idProdcte As Integer
    Public Nombrecte As String
End Class

Imports MySql.Data.MySqlClient
Public Class frmaddendas

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Close()
    End Sub
    'Public Function GettiendasSoriana() As DataTable
    '    If gConn.State <> ConnectionState.Open Then gConn.Open()
    '    Dim vCmd As New MySqlCommand("SELECT * FROM tiendas WHERE tienda=@soriana", gConn)
    '    vCmd.Parameters.AddWithValue("?soriana", "Soriana")
    '    Dim vAdap As New MySqlDataAdapter(vCmd)
    '    Dim vTabla As New DataTable
    '    vAdap.Fill(vTabla)
    '    Return vTabla
    'End Function

    'Private Sub frmaddendas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Me.cmbtienda.DisplayMember = "nombre"
    '    Me.cmbtienda.ValueMember = "id"
    '    Me.cmbtienda.DataSource = GettiendasSoriana()
    'End Sub
End Class
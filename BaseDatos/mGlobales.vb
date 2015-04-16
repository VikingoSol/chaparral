Imports MySql.Data.MySqlClient
Public Module mGlobales
    Public gConn As MySqlConnection

    Public Function Test_Server(ByVal pServer As String, ByVal pPort As Integer, ByVal pUsuario As String, ByVal pPassword As String, ByVal pBase As String) As Boolean
        Dim vConn As New MySqlConnection(CadenaConexion(pServer, pPort, pUsuario, pPassword, pBase))
        Try
            vConn.Open()
            vConn.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try
    End Function

    Friend Function CadenaConexion(ByVal pServer As String, ByVal pPuerto As Integer, ByVal pUsuario As String, ByVal pPass As String, ByVal pBase As String)
        Return "Server=" & pServer & ";Port=" & pPuerto & ";Database=" & pBase & ";Uid=" & pUsuario & ";Pwd=" & pPass & ";"
    End Function

    Public Sub Conectar_BaseDatos(ByVal pConfig As cConfigLocal)
        gConn = New MySqlConnection(CadenaConexion(pConfig.Servidor, pConfig.Puerto, pConfig.Usuario, pConfig.Password, pConfig.BaseDatos))
        gConn.Open()
    End Sub

End Module

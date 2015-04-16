Imports Ionic.Zip
Public Class frmExportarXMLProc
    Dim vFechaIni, vFechaFin As Date
    Dim vPath As String
    Dim vTipo As Integer


    Public Function Exportar(ByVal pFechaIni As Date, ByVal pFechaFin As Date, ByVal pPath As String, ByVal pTipoExp As Integer) As Boolean
        vFechaIni = pFechaIni
        vFechaFin = pFechaFin
        vPath = pPath
        vTipo = pTipoExp
        Me.txtEstatus.Text = "Iniciando Exportacion de Archivos XML"
        Me.BackgroundWorker1.RunWorkerAsync()
        If Me.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.BackgroundWorker1.CancelAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim vFacturas As Integer = BaseDatos.cFacturas.GetNumFacturas(Me.vFechaIni, vFechaFin)
        If vFacturas <= 0 Then
            Exit Sub
        End If
        Me.BackgroundWorker1.ReportProgress(0, "Exportando " & vFacturas & " Factura(s)")
        Dim vTabla As DataTable = BaseDatos.cFacturas.GetFacturasXML(Me.vFechaIni, vFechaFin)
        Dim n As Integer = 1
        Dim vRow As DataRow
        Dim vFile As IO.StreamWriter
        Dim vDirPath As String
        Dim vZipFile As ZipFile
        Dim vPorcFile As Double = 100
        Dim vPorcZip As Double = 50
        Dim vFiles As New List(Of String)
        Dim vFileXml As String
        If vTipo = 0 Then 'Exportar en carpeta
            vDirPath = vPath
        ElseIf vTipo = 1 Then
            vDirPath = System.IO.Path.GetTempPath
            vDirPath &= Guid.NewGuid.ToString
            IO.Directory.CreateDirectory(vDirPath)
            vZipFile = New ZipFile
            vPorcFile = 50
        End If
        For Each vRow In vTabla.Rows
            vFile = New IO.StreamWriter(vDirPath & "/" & vRow.Item("serie").ToString & "-" & vRow.Item("folio").ToString & ".xml")
            vFile.Write(vRow.Item("xml_sat").ToString)
            vFile.Flush()
            vFile.Close()
            vFiles.Add(vDirPath & "/" & vRow.Item("serie").ToString & "-" & vRow.Item("folio").ToString & ".xml")
            Me.BackgroundWorker1.ReportProgress(vPorcFile * n / vFacturas, "Exportando Factura " & n & " de " & vFacturas)
            n += 1
        Next
        If vTipo = 1 Then
            n = 1
            For Each vFileXml In vFiles
                vZipFile.AddFile(vFileXml, "")
                Me.BackgroundWorker1.ReportProgress(vPorcFile + (vPorcZip * n / vFacturas), "Comprimiendo Archivo " & n & " de " & vFacturas)
            Next
            vZipFile.Save(vPath)
        End If

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Me.txtEstatus.Text = e.UserState
        Me.ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Cancelled Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub
End Class
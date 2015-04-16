Public Class frmExportarXML

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.cmbExportarA.SelectedIndex = 0
        Me.dpFecha1.Value = Now.AddMonths(-1)
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Dim vPath As String
        If Me.cmbExportarA.SelectedIndex = 0 Then
            If Me.FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                vPath = Me.FolderBrowserDialog1.SelectedPath
            Else
                Exit Sub
            End If
        ElseIf Me.cmbExportarA.SelectedIndex = 1 Then
            If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                vPath = Me.SaveFileDialog1.FileName
            Else
                Exit Sub
            End If
        End If

        Dim vExp As New frmExportarXMLProc
        Dim vFechaIni, vFechaFin As Date
        If Me.dpFecha1.Value <= Me.dpFecha2.Value Then
            vFechaIni = dpFecha1.Value
            vFechaFin = dpFecha2.Value
        Else
            vFechaIni = dpFecha2.Value
            vFechaFin = dpFecha1.Value
        End If
        If vExp.Exportar(vFechaIni, vFechaFin, vPath, Me.cmbExportarA.SelectedIndex) Then
            MsgBox("Se han exportado los xml correctamente", MsgBoxStyle.Information, "Exportacion Correcta")
            Me.Close()
        End If

    End Sub
End Class
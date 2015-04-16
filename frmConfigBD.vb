Public Class frmConfigBD

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If Not BaseDatos.mGlobales.Test_Server(Me.txtServer.Text, Me.txtPort.Text, Me.txtUser.Text, Me.txtPass.Text, Me.txtBaseDatos.Text) Then
            Exit Sub
        End If
        gConfig.Servidor = Me.txtServer.Text
        gConfig.Puerto = Me.txtPort.Text
        gConfig.Usuario = Me.txtUser.Text
        gConfig.Password = Me.txtPass.Text
        gConfig.BaseDatos = Me.txtBaseDatos.Text

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If BaseDatos.mGlobales.Test_Server(Me.txtServer.Text, Me.txtPort.Text, Me.txtUser.Text, Me.txtPass.Text, Me.txtBaseDatos.Text) Then
            MsgBox("La conexion se ha realizado correctamente", MsgBoxStyle.Information, "Conexion Exitosa")
        End If
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.txtServer.Text = gConfig.Servidor
        Me.txtPort.Text = gConfig.Puerto
        Me.txtUser.Text = gConfig.Usuario
        Me.txtPass.Text = gConfig.Password
        Me.txtBaseDatos.Text = gConfig.BaseDatos
    End Sub
End Class
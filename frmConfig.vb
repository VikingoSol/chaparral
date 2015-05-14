Imports BaseDatos
Public Class frmConfig
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.txtServidor.Text = gConfig.Servidor
        Me.txtPuerto.Text = gConfig.Puerto
        Me.txtUsuario.Text = gConfig.Usuario
        Me.txtPass.Text = gConfig.Password
        Me.txtBase.Text = gConfig.BaseDatos


        Dim cConfig As New cConfigGlobal
        gConfigGlobal = cConfig.GetConfiguracion(RfcActual)

        Me.txtNextFolio.Text = gConfigGlobal.NextFolio
        Me.txtIVA.Text = gConfigGlobal.IVA * 100
        Me.txtRFC.Text = gConfigGlobal.Registro_Federal
        Me.txtSerie.Text = gConfigGlobal.Serie
        Me.txtCertificado.Text = gConfigGlobal.Cer_Name
        Me.txtKeyFile.Text = gConfigGlobal.Key_Name
        Me.txtPassSAT.Text = gConfigGlobal.PassCert
        Me.txtNoCertificado.Text = gConfigGlobal.NoCertificado
        Me.txtRazonSocial.Text = gConfigGlobal.RazonSocial
        Me.txtRegimen.Text = gConfigGlobal.RegimenFiscal

        'Direccion Fiscal
        Me.txtCalle.Text = gConfigGlobal.Direccion_Fiscal.Calle
        Me.txtNoExt.Text = gConfigGlobal.Direccion_Fiscal.NoExterior
        Me.txtNoInt.Text = gConfigGlobal.Direccion_Fiscal.NoInterior
        Me.txtCol.Text = gConfigGlobal.Direccion_Fiscal.Colonia
        Me.txtLoc.Text = gConfigGlobal.Direccion_Fiscal.Localidad
        Me.txtRef.Text = gConfigGlobal.Direccion_Fiscal.Referencia
        Me.txtMunicipio.Text = gConfigGlobal.Direccion_Fiscal.Municipio
        Me.txtEstado.Text = gConfigGlobal.Direccion_Fiscal.Estado
        Me.txtPais.Text = gConfigGlobal.Direccion_Fiscal.Pais
        Me.txtCP.Text = gConfigGlobal.Direccion_Fiscal.CodigoPostal
        Me.txtTC.Text = gConfigGlobal.TipoCambio

        Me.txtToken.Text = gConfigGlobal.CFDI_Token
        Me.txtId.Text = gConfigGlobal.CFDI_Id
        Me.txtWs.Text = gConfigGlobal.CFDI_Url
        Me.txtCancel.Text = gConfigGlobal.CFDI_CancelWs
        Me.txtCancelId.Text = gConfigGlobal.CFDI_CancelId
        'email
        Me.Txtservidoesmtp.Text = gConfigGlobal.servidorsmtp
        Me.Txtcuenta.Text = gConfigGlobal.smtpcuenta
        Me.Txtpassword.Text = gConfigGlobal.smtppassword
        Me.Txtsmptpuerto.Text = gConfigGlobal.smtppuerto


    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim vConfigBase As New cConfigGlobal

        gConfig.Servidor = Me.txtServidor.Text
        gConfig.Puerto = Me.txtPuerto.Text
        gConfig.Usuario = Me.txtUsuario.Text
        gConfig.Password = Me.txtPass.Text
        gConfig.BaseDatos = Me.txtBase.Text

        gConfig.Guardar(gConfigFile)

        If Me.txtCertificado.Text <> gConfigGlobal.Cer_Name Then
            If IO.File.Exists(Me.txtCertificado.Text) Then
                vConfigBase.UploadCertificado(IO.Path.GetFileName(Me.txtCertificado.Text), File_To_Bytes(Me.txtCertificado.Text), RfcActual)
                gConfigGlobal.Cer_Name = IO.Path.GetFileName(Me.txtCertificado.Text)
                Dim vFile As dArchivo = vConfigBase.DownloadCertificado(RfcActual)
                If IO.File.Exists(gPathFactuacion & gConfigGlobal.Cer_Name) Then
                    IO.File.Delete(gPathFactuacion & gConfigGlobal.Cer_Name)
                End If

                Bytes_To_File(vFile.File, gPathFactuacion & vFile.Nombre)
                gConfig.Cer_Version = vFile.Version
            Else
                MsgBox("El Archivo certificado no existe", MsgBoxStyle.Critical, "¿Certificado?")
                Me.txtCertificado.Focus()
                Exit Sub
            End If

        End If

        If Me.txtKeyFile.Text <> gConfigGlobal.Key_Name Then
            If IO.File.Exists(Me.txtKeyFile.Text) Then
                vConfigBase.UploadKey(IO.Path.GetFileName(Me.txtKeyFile.Text), File_To_Bytes(Me.txtKeyFile.Text), RfcActual)
                gConfigGlobal.Key_Name = IO.Path.GetFileName(Me.txtKeyFile.Text)
                Dim vFileKey As dArchivo = vConfigBase.DownloadKey(RfcActual)
                If IO.File.Exists(gPathFactuacion & gConfigGlobal.Key_Name) Then
                    IO.File.Delete(gPathFactuacion & gConfigGlobal.Key_Name)
                End If

                Bytes_To_File(vFileKey.File, gPathFactuacion & vFileKey.Nombre)
                gConfig.Key_Version = vFileKey.Version
            Else
                MsgBox("El Archivo KEY no existe", MsgBoxStyle.Critical, "¿Archivo Key?")
                Me.txtKeyFile.Focus()
                Exit Sub
            End If
        End If
        gConfigGlobal.NextFolio = Me.txtNextFolio.Text
        gConfigGlobal.IVA = Me.txtIVA.Text / 100
        gConfigGlobal.Registro_Federal = Me.txtRFC.Text
        gConfigGlobal.Serie = Me.txtSerie.Text
        gConfigGlobal.PassCert = Me.txtPassSAT.Text
        gConfigGlobal.NoCertificado = Me.txtNoCertificado.Text
        gConfigGlobal.CFDI_Token = Me.txtToken.Text
        gConfigGlobal.CFDI_Id = Me.txtId.Text
        gConfigGlobal.CFDI_Url = Me.txtWs.Text
        gConfigGlobal.CFDI_CancelWs = Me.txtCancel.Text
        gConfigGlobal.CFDI_CancelId = Me.txtCancelId.Text
        gConfigGlobal.RazonSocial = Me.txtRazonSocial.Text
        gConfigGlobal.RegimenFiscal = Me.txtRegimen.Text
        gConfigGlobal.TipoCambio = Me.txtTC.Text

        'Direccion Fiscal
        gConfigGlobal.Direccion_Fiscal.Calle = Me.txtCalle.Text
        gConfigGlobal.Direccion_Fiscal.NoExterior = Me.txtNoExt.Text
        gConfigGlobal.Direccion_Fiscal.NoInterior = Me.txtNoInt.Text
        gConfigGlobal.Direccion_Fiscal.Colonia = Me.txtCol.Text
        gConfigGlobal.Direccion_Fiscal.Localidad = Me.txtLoc.Text
        gConfigGlobal.Direccion_Fiscal.Referencia = Me.txtRef.Text
        gConfigGlobal.Direccion_Fiscal.Municipio = Me.txtMunicipio.Text
        gConfigGlobal.Direccion_Fiscal.Estado = Me.txtEstado.Text
        gConfigGlobal.Direccion_Fiscal.Pais = Me.txtPais.Text
        gConfigGlobal.Direccion_Fiscal.CodigoPostal = Me.txtCP.Text
        'email
        gConfigGlobal.servidorsmtp = Me.Txtservidoesmtp.Text
        gConfigGlobal.smtpcuenta = Me.Txtcuenta.Text
        gConfigGlobal.smtppassword = Me.Txtpassword.Text
        gConfigGlobal.smtppuerto = Me.Txtsmptpuerto.Text


        vConfigBase.GuardarConfiguracion(gConfigGlobal, Me.txtRFC.Text.Trim)

        Me.Close()

    End Sub

    Private Sub txtRFC_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRFC.LostFocus

    End Sub

    Private Sub txtRFC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRFC.TextChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.OpenFileDialog1.Filter = "Archivo Cer (*.cer)|*.cer"
        Me.OpenFileDialog1.FileName = Me.txtCertificado.Text
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtCertificado.Text = Me.OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.OpenFileDialog1.Filter = "Archivo Key (*.key)|*.key"
        Me.OpenFileDialog1.FileName = Me.txtKeyFile.Text
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtKeyFile.Text = Me.OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub frmConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtCancel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCancel.TextChanged

    End Sub

    Private Sub txtTC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTC.Click

    End Sub
End Class
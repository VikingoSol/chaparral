Imports System.Xml
Imports System.Text
Public Class frmFacturaCanProc
    Dim vFolioFiscal As String
    Dim vRFCEmisor As String
    Dim vFecha As Date
    Dim vClaveCliente As String
    Dim vToken As String
    Dim vId As String
    Dim vIdFactura As Integer
    Dim vWsURL As String
    Private FCanClose As Boolean = False

    Public Function Cancelar(ByVal pIdFactura As Integer, ByVal pFolio As String, ByVal pRFCEmisor As String, ByVal pFecha As Date, ByVal pClaveCliente As String, ByVal pToken As String, ByVal pId As String, ByVal pWsURL As String) As Boolean
        Me.txtEstatus.Text = "Generando XML de Cancelacion"
        vIdFactura = pIdFactura
        vFolioFiscal = pFolio
        vRFCEmisor = pRFCEmisor
        vFecha = pFecha
        vClaveCliente = pClaveCliente
        vToken = pToken
        vId = pId
        vWsURL = pWsURL
        Bw.RunWorkerAsync()
        If Me.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub frmFacturaCanProc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = Not FCanClose
    End Sub

    Private Sub frmFacturaCanProc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    'Public Function Cancelar(ByVal pFolio As String, ByVal pRFCEmisor As String, ByVal pFecha As Date, ByVal pClaveCliente As String, ByVal pToken As String, ByVal pId As String, ByVal pWsURL As String) As Boolean
    '    Dim vFolios As New List(Of String)
    '    vFolios.Add(vFolioFiscal)
    '    Dim settings As XmlWriterSettings = New XmlWriterSettings()
    '    Dim vXml As New IO.StringWriter
    '    Dim n As Integer
    '    'settings.Indent = True
    '    settings.Encoding = New UTF8Encoding
    '    settings.OmitXmlDeclaration = True
    '    Dim vXmlDoc As XmlWriter = XmlWriter.Create(vXml, settings)
    '    vXmlDoc.WriteStartDocument()
    '    vXmlDoc.WriteStartElement("Cancelacion", "http://cancelacfd.sat.gob.mx")
    '    vXmlDoc.WriteAttributeString("xmlns", "xsd", Nothing, "http://www.w3.org/2001/XMLSchema")
    '    vXmlDoc.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
    '    vXmlDoc.WriteAttributeString("RfcEmisor", Trim(vRFCEmisor))
    '    vXmlDoc.WriteAttributeString("Fecha", Format(vFecha, "yyyy-MM-ddTHH:mm:ss"))
    '    'vXmlDoc.WriteAttributeString("xmlns", )
    '    vXmlDoc.WriteAttributeString("ClaveCliente", vClaveCliente)
    '    For n = 0 To vFolios.Count - 1
    '        vXmlDoc.WriteStartElement("Folios")
    '        vXmlDoc.WriteElementString("UUID", vFolios(n))
    '        vXmlDoc.WriteEndElement()
    '    Next
    '    vXmlDoc.WriteEndElement()
    '    vXmlDoc.WriteEndDocument()
    '    vXmlDoc.Close()
    '    ' Bw.ReportProgress(50, "Enviando Solicitud de cancelacion")
    '    Dim vBytesEnc() As Byte = Encoding.UTF8.GetBytes(vXml.ToString)
    '    Dim vXml64 As String = Convert.ToBase64String(vBytesEnc)

    '    Dim Ws As New WsCancel.expidetufactura_cancelacion_wsdl
    '    Ws.Url = gConfigGlobal.CFDI_CancelWs
    '    Dim vAcuse As String = ""
    '    Dim vRes As String
    '    Try
    '        vRes = Ws.recibe(vBytesEnc, gConfigGlobal.CFDI_Id, gConfigGlobal.CFDI_Token, vAcuse)
    '        '  Bw.ReportProgress(90, "Respuesta Recibida")
    '        Dim vIdAcuse As Integer = BaseDatos.cFacturas.RequestCancelacion(vRes, vAcuse)
    '        If vIdAcuse > 0 AndAlso (vRes.StartsWith("201") Or vRes.StartsWith("202")) Then
    '            BaseDatos.cFacturas.Cancelar(vIdFactura, vIdAcuse)
    '            Exit Function
    '        Else
    '            MsgBox("Se recibio una respuesta no exitosa: " & Environment.NewLine & vRes, MsgBoxStyle.Critical)
    '            ' e.Cancel = True
    '            Exit Function
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        '  e.Cancel = True
    '        Exit Function

    '    End Try
    'End Function

    Private Sub Bw_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Bw.DoWork
        Dim vFolios As New List(Of String)
        vFolios.Add(vFolioFiscal)
        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        Dim vXml As New IO.StringWriter
        Dim n As Integer
        'settings.Indent = True
        settings.Encoding = New UTF8Encoding
        settings.OmitXmlDeclaration = True
        Dim vXmlDoc As XmlWriter = XmlWriter.Create(vXml, settings)
        vXmlDoc.WriteStartDocument()
        vXmlDoc.WriteStartElement("Cancelacion", "http://cancelacfd.sat.gob.mx")
        vXmlDoc.WriteAttributeString("xmlns", "xsd", Nothing, "http://www.w3.org/2001/XMLSchema")
        vXmlDoc.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
        vXmlDoc.WriteAttributeString("RfcEmisor", Trim(vRFCEmisor))
        vXmlDoc.WriteAttributeString("Fecha", Format(vFecha, "yyyy-MM-ddTHH:mm:ss"))
        'vXmlDoc.WriteAttributeString("xmlns", )
        vXmlDoc.WriteAttributeString("ClaveCliente", vClaveCliente)
        For n = 0 To vFolios.Count - 1
            vXmlDoc.WriteStartElement("Folios")
            vXmlDoc.WriteElementString("UUID", vFolios(n))
            vXmlDoc.WriteEndElement()
        Next
        vXmlDoc.WriteEndElement()
        vXmlDoc.WriteEndDocument()
        vXmlDoc.Close()
        Bw.ReportProgress(50, "Enviando Solicitud de cancelacion")
        Dim vBytesEnc() As Byte = Encoding.UTF8.GetBytes(vXml.ToString)
        Dim vXml64 As String = Convert.ToBase64String(vBytesEnc)

        Dim Ws As New WsCancel.expidetufactura_cancelacion_wsdl
        Ws.Url = gConfigGlobal.CFDI_CancelWs
        Dim vAcuse As String = ""
        Dim vRes As String
        Try
            vRes = FacturaNETLib.Cancelar(gConfigGlobal.CFDI_CancelWs, gConfigGlobal.CFDI_Id, vRFCEmisor, vFolios(0), vAcuse)
            'vRes = Ws.recibe(vBytesEnc, gConfigGlobal.CFDI_Id, gConfigGlobal.CFDI_Token, vAcuse)
            Bw.ReportProgress(90, "Respuesta Recibida")
            Dim vIdAcuse As Integer = BaseDatos.cFacturas.RequestCancelacion(vRes, vAcuse)
            If vIdAcuse > 0 AndAlso (vRes.StartsWith("201") Or vRes.StartsWith("202")) Then
                BaseDatos.cFacturas.Cancelar(vIdFactura, vIdAcuse)
                Exit Sub
            Else
                MsgBox("Se recibio una respuesta no exitosa: " & Environment.NewLine & vRes, MsgBoxStyle.Critical)
                e.Cancel = True
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            e.Cancel = True
            Exit Sub

        End Try

    End Sub

    Private Sub Bw_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Bw.ProgressChanged
        Me.txtEstatus.Text = e.UserState.ToString
    End Sub

    Private Sub Bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Bw.RunWorkerCompleted
        Me.FCanClose = True
        If e.Cancelled Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
        Me.Close()
    End Sub
End Class
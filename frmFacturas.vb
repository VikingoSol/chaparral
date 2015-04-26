Imports BaseDatos
Imports FacturaNETLib
Imports FacturaNETLib.Manager
Imports FacturaNETLib.Certificate
Imports FacturaNETLib.Document
Public Class frmFacturas
    Private Shared _ObjSingleton As frmFacturas = Nothing
    Dim vFechaFacs As Date

    Public Shared Function GetInstance() As frmFacturas
        If _ObjSingleton Is Nothing OrElse _
        _ObjSingleton.IsDisposed = True Then
            _ObjSingleton = New frmFacturas
        End If
        Return _ObjSingleton
    End Function

    Private Sub Mostrar_Facturas(ByVal pFecha As Date)
        Dim vFacs As New cFacturas
        Me.grdFacturas.DataSource = vFacs.GetFacturas(pFecha)
        vFechaFacs = pFecha
    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim vFac As New frmFactura
        Dim vId As Integer = vFac.Agregar
        If vId > 0 Then
            Me.Mostrar_Facturas(Me.vFechaFacs)
            Me.grdFacturas.Find(Me.grdFacturas.RootTable.Columns("id"), Janus.Windows.GridEX.ConditionOperator.Equal, vId, -1, 1)
            'Imprimir_Factura(vId) ' jc por error al imprimir
        End If
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Mostrar_Facturas(Me.vFechaFacs)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Mostrar_Facturas(Me.dpFecha.Value)
    End Sub

    Private Sub frmFacturas_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.dpFecha.Value = Now.AddMonths(-1)
        Mostrar_Facturas(Me.dpFecha.Value)
    End Sub

    Private Sub frmFacturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub grdFacturas_DeletingRecord(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionCancelEventArgs) Handles grdFacturas.DeletingRecord
        If MsgBox("¿Esta seguro de Cancelar la factura seleccionada?", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question, "¿Cancelar?") = MsgBoxResult.Yes Then
            Dim vFacCan As New frmFacturaCanProc
            If Not vFacCan.Cancelar(e.Row.Cells("ID").Value, e.Row.Cells("folio_fiscal").Value, gConfigGlobal.Registro_Federal, Now, gConfigGlobal.CFDI_CancelId, gConfigGlobal.CFDI_Token, gConfigGlobal.CFDI_Id, gConfigGlobal.CFDI_CancelId) Then
                e.Cancel = True
            Else
                Dim vID As Integer = e.Row.Cells("ID").Value
                Me.Mostrar_Facturas(vFechaFacs)
                Me.grdFacturas.Find(Me.grdFacturas.RootTable.Columns("id"), Janus.Windows.GridEX.ConditionOperator.Equal, vID, -1, 1)

            End If
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub grdFacturas_FormattingRow(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles grdFacturas.FormattingRow
        e.Row.Cells("estado").FormatStyle = New Janus.Windows.GridEX.GridEXFormatStyle
        If e.Row.Cells("estado").Value = 1 Then
            e.Row.Cells("estado").FormatStyle.ForeColor = Color.DarkGreen
            e.Row.Cells("estado").FormatStyle.FontBold = Janus.Windows.GridEX.TriState.True
        Else
            e.Row.Cells("estado").FormatStyle.ForeColor = Color.DarkRed
            e.Row.Cells("estado").FormatStyle.FontBold = Janus.Windows.GridEX.TriState.True
        End If
    End Sub

    Private Sub grdFacturas_RowCountChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFacturas.RowCountChanged
        If Me.grdFacturas.RecordCount = 0 Then
            Me.btnView.Enabled = False
            Me.btnDel.Enabled = False
            Me.btnImprimir.Enabled = False
            Me.btnToPDF.Enabled = False
            Me.btnExpXML.Enabled = False
        End If
    End Sub

    Private Sub grdFacturas_RowDoubleClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles grdFacturas.RowDoubleClick
        If e.Row.RowType = Janus.Windows.GridEX.RowType.Record Then
            Me.btnView.PerformClick()
        End If
    End Sub

    Private Sub grdFacturas_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFacturas.SelectionChanged
        If IsNothing(Me.grdFacturas.GetRow) OrElse Me.grdFacturas.GetRow.RowType <> Janus.Windows.GridEX.RowType.Record Then
            Me.btnView.Enabled = False
            Me.btnDel.Enabled = False
            Me.btnImprimir.Enabled = False
            Me.btnToPDF.Enabled = False
            Me.btnExpXML.Enabled = False
        Else
            Me.btnView.Enabled = True
            Me.btnDel.Enabled = True
            Me.btnImprimir.Enabled = True
            Me.btnToPDF.Enabled = True
            Me.btnExpXML.Enabled = True
        End If
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        Dim vFacs As New frmFacturaView
        vFacs.VerFactura(Me.grdFacturas.GetRow.Cells("id").Value)
    End Sub

    Private Function GetFacturaRep(Optional ByVal pId As Integer = -1) As FastReport.Report
        Dim vFactura As ElectronicDocument
        Dim vManager As ElectronicManage
        Dim vFacs As New cFacturas

        Dim vFac As dFacturaView
        If pId > 0 Then
            vFac = vFacs.GetFactura(pId)
        Else
            vFac = vFacs.GetFactura(Me.grdFacturas.GetRow.Cells("id").Value)
        End If

        If IsNothing(vFac) Then
            Return Nothing
        End If


        vManager = ElectronicManage.NewEntity
        vFactura = ElectronicDocument.NewEntity()
        vFactura.AssignManage(vManager)




        'Dim sw As IO.StreamWriter = New IO.StreamWriter(New IO.MemoryStream)
        ' sw.Write(vFac.xml_Timbrado)
        'sw.Flush()
        ' vFactura.Manage.Load.Options = vFactura.Manage.Load.Options - LoadOptions.ValidateCertificateWithCrl - LoadOptions.ValidateSignature - LoadOptions.ValidateStamp
        If Not vFactura.LoadFromString(vFac.xml_Timbrado) Then
            MsgBox("Error al leer la factura")
            Return Nothing
        End If

        Dim n As Integer

        Dim vTablaProds As DataTable = vFacs.GetProductosFacturados(Me.grdFacturas.GetRow.Cells("id").Value)
        'Dim vDs As New DataSet
        vTablaProds.TableName = "Productos"
        'vDs.Tables.Add(vTablaProds)
        'vDs.WriteXml("c:/dsFactura.xml")

        Dim vReport As New FastReport.Report

        If IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory() & vFac.RFC_Emisor & "/factura.frx") Then
            vReport.Load(System.AppDomain.CurrentDomain.BaseDirectory() & vFac.RFC_Emisor & "/factura.frx")
        Else
            vReport.Load(System.AppDomain.CurrentDomain.BaseDirectory() & "/Reportes/factura.frx")
        End If

        vReport.RegisterData(vTablaProds, "Productos")
        vReport.SetParameterValue("fecha_emi", FormatDateTime(vFactura.Data.Fecha.Value, "dd/MM/yyyy HH:mm:ss"))
        vReport.SetParameterValue("Serie", vFactura.Data.Serie.Value)
        vReport.SetParameterValue("folio", vFactura.Data.Folio.Value)
        vReport.SetParameterValue("cer_emi", vFactura.Data.NoCertificado.Value)
        vReport.SetParameterValue("Moneda", vFactura.Data.Moneda.Value)
        vReport.SetParameterValue("tipo_cambio", FormatNumber(vFactura.Data.TipoCambio.Value, 2))
        vReport.SetParameterValue("subtotal", "$ " & FormatNumber(vFactura.Data.SubTotal.Value, 2))
        vReport.SetParameterValue("Cliente", vFactura.Data.Receptor.Nombre.Value)
        vReport.SetParameterValue("RFC", vFactura.Data.Receptor.RFC.Value)
        vReport.SetParameterValue("metodo_pago", vFactura.Data.MetodoPago.Value)
        vReport.SetParameterValue("cuenta", vFactura.Data.NumeroCuentaPago.Value)
        vReport.SetParameterValue("descuento", vFactura.Data.Descuento)

        Dim vDir As String
        vDir = vFactura.Data.Receptor.Domicilio.Calle.Value
        If vFactura.Data.Receptor.Domicilio.NumeroExterior.Value <> "" Then
            If IsNumeric(vFactura.Data.Receptor.Domicilio.NumeroExterior) Then
                vDir &= " #" & vFactura.Data.Receptor.Domicilio.NumeroExterior.Value
            Else
                vDir &= " " & vFactura.Data.Receptor.Domicilio.NumeroExterior.Value
            End If
        End If
        If vFactura.Data.Receptor.Domicilio.NumeroInterior.Value <> "" Then vDir &= " No. Int. " & vFactura.Data.Receptor.Domicilio.NumeroInterior.Value
        If vFactura.Data.Receptor.Domicilio.Colonia.Value <> "" Then vDir &= ", Col. " & vFactura.Data.Receptor.Domicilio.Colonia.Value
        If vFactura.Data.Receptor.Domicilio.CodigoPostal.Value <> "" Then
            '  If IsNumeric(vFactura.Data.Receptor.Domicilio.NumeroExterior) Then
            vDir &= ", C.P. " & vFactura.Data.Receptor.Domicilio.CodigoPostal.Value
            'Else
            '   vDir &= " " & vFactura.Data.Receptor.Domicilio.NumeroExterior.Value
            ' End If
        End If
        If vFactura.Data.Receptor.Domicilio.Localidad.Value <> "" Then vDir &= Environment.NewLine & vFactura.Data.Receptor.Domicilio.Localidad.Value
        If vFactura.Data.Receptor.Domicilio.Localidad.Value <> "" And vFactura.Data.Receptor.Domicilio.Estado.Value <> "" Then vDir &= ","
        If vFactura.Data.Receptor.Domicilio.Estado.Value <> "" Then vDir &= " " & vFactura.Data.Receptor.Domicilio.Estado.Value
        If vFactura.Data.Receptor.Domicilio.Pais.Value <> "" Then vDir &= ", " & vFactura.Data.Receptor.Domicilio.Pais.Value

        vReport.SetParameterValue("cl_dir", vDir)

        Dim vIva As Double
        Dim vRetIva As Double

        For n = 0 To vFactura.Data.Impuestos.Traslados.Count - 1
            If vFactura.Data.Impuestos.Traslados(n).Tipo.Value = "IVA" Then
                vReport.SetParameterValue("iva", "$ " & FormatNumber(vFactura.Data.Impuestos.Traslados(n).Importe.Value, 2))
                vIva = vFactura.Data.Impuestos.Traslados(n).Importe.Value
                Exit For
            End If
        Next

        vReport.SetParameterValue("txtiva", "I.V.A.(" & FormatNumber((vIva / vFactura.Data.SubTotal.Value) * 100, 2) & "%):")

        If vFactura.Data.Moneda.Value = "MXN" Then
            vReport.SetParameterValue("txt_cantidad", Letras(vFactura.Data.Total.Value, "PESOS"))
        Else
            vReport.SetParameterValue("txt_cantidad", Letras(vFactura.Data.Total.Value, vFactura.Data.Moneda.Value))
        End If

        vReport.SetParameterValue("total", "$ " & FormatNumber(vFactura.Data.Total.Value, 2))


        Dim vTimbre As Complementos.TimbreFiscalDigital
        For n = 0 To vFactura.Data.Complementos.Count - 1
            If vFactura.Data.Complementos(n).Type = Complementos.eComplementoTipo.TimbreFiscalDigital Then
                vTimbre = CType(vFactura.Data.Complementos(n).Data, Complementos.TimbreFiscalDigital)
                vReport.SetParameterValue("cer_sat", vTimbre.NumeroCertificadoSat.Value)
                vReport.SetParameterValue("cadena_original", vTimbre.FingerPrintPac)
                vReport.SetParameterValue("sello_sat", vTimbre.SelloSat.Value)
                vReport.SetParameterValue("sello_emi", vTimbre.SelloCfd.Value)
                vReport.SetParameterValue("fecha_cer", FormatDateTime(vTimbre.FechaTimbrado.Value, "dd/MM/yyyy HH:mm:ss"))
                vReport.SetParameterValue("folio_fiscal", vTimbre.Uuid.Value.ToUpper)
                'Me.txtCertificadoSAT.Text = vTimbre.NumeroCertificadoSat.Value
                'Me.txtCadenaOrig.Text = vFactura.FingerPrintPac
                'Me.txtSelloSAT.Text = vTimbre.SelloSat.Value
                'Me.txtSelloEmisor.Text = vTimbre.SelloCfd.Value
                'Me.txtFecha_Cer.Text = vTimbre.FechaTimbrado.Value
            End If
        Next

        Dim vTotal As Double = vFactura.Data.Total.Value
        Dim vFileBarCode As String = Generar_CodigoBarrasBi(vFactura, FormatNumber(vTotal, 2, TriState.False, TriState.False, TriState.False), 4, gPathBarCodes)
        If vFileBarCode = "" Then
            Return Nothing
        End If
        Dim vImage As FastReport.PictureObject = vReport.FindObject("BarCodeImg")
        vImage.Image = System.Drawing.Bitmap.FromFile(vFileBarCode)
        Return vReport
    End Function

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Imprimir_Factura()
    End Sub

    Private Sub Imprimir_Factura(Optional ByVal pId As Integer = -1)

        Dim vReport As FastReport.Report = GetFacturaRep(pId)
        PrintDialog1.PrinterSettings.Copies = 2
        'vReport.PrintSettings.Printer = pImpresora
        If Me.PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            vReport.PrintSettings.Printer = PrintDialog1.PrinterSettings.PrinterName
            vReport.PrintSettings.Copies = PrintDialog1.PrinterSettings.Copies
            'vReport.PrintSettings.PrintToFileName = "Invoice_#" & pFolio
            If vReport.Prepare() Then
                vReport.PrintSettings.ShowDialog = False
                vReport.PrintPrepared()
            End If
        End If

    End Sub

    Private Sub btnToPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToPDF.Click
        Dim vReport As FastReport.Report = GetFacturaRep()
        If IsNothing(vReport) Then Exit Sub
        'vReport.PrintSettings.Printer = pImpresora
        Me.SaveFileDialog1.FileName = ""
        Me.SaveFileDialog1.Filter = "Archivos PDF (*.pdf)|*.pdf"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim export As New FastReport.Export.Pdf.PDFExport
            export.EmbeddingFonts = True
            vReport.Prepare()
            export.Export(vReport, SaveFileDialog1.FileName)
            ' free resources used by report
            vReport.Dispose()
        End If


    End Sub

    Private Sub btnExpXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpXML.Click
        Me.SaveFileDialog1.FileName = ""
        Me.SaveFileDialog1.Filter = "Archivos PDF (*.xml)|*.xml"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim vFile As New IO.StreamWriter(Me.SaveFileDialog1.FileName)
            Dim vXml As String = cFacturas.GetFacturaXML(Me.grdFacturas.GetRow.Cells("id").Value)
            vFile.Write(vXml)
            vFile.Flush()
            vFile.Close()
            MsgBox("Se ha exportado correctamente el archivo xml", MsgBoxStyle.Exclamation, "Exportacion XML")
        End If
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        Me.grdFacturas.Delete()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.SaveFileDialog1.FileName = ""
        Me.SaveFileDialog1.Filter = "Archivo de Excel(*.xls)|*.xls"
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim vExp As New Janus.Windows.GridEX.Export.GridEXExporter
            vExp.IncludeExcelProcessingInstruction = True
            vExp.IncludeFormatStyle = True
            vExp.IncludeHeaders = True
            vExp.ExportMode = Janus.Windows.GridEX.ExportMode.AllRows
            vExp.SheetName = "Facturas"
            vExp.GridEX = Me.grdFacturas
            Dim stream As IO.FileStream = New IO.FileStream(Me.SaveFileDialog1.FileName, System.IO.FileMode.Create)
            vExp.Export(stream)
            stream.Close()
            MsgBox("Se ha exportado correctamente el archivo", MsgBoxStyle.Information, "Exportacion a Excel")

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim F As New frmaddendas
        F.ShowDialog()
    End Sub
End Class
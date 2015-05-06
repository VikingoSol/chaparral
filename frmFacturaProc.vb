Imports FacturaNETLib
Imports FacturaNETLib.Document
Imports FacturaNETLib.Manager
Imports FacturaNETLib.Certificate
Imports FacturaNETLib.Addendas
Imports FacturaNETLib.AddendaSoriana
Imports BaseDatos
Imports System.IO
Public Class frmFacturaProc
    Private FCanClose As Boolean = False
    Private vFacturaData As dFactura
    Private vProdsFac As DataTable
    Private vIdFac As Integer = -1

    Public vAddendaSR As dAddendaSorianaremision
    Public vAddendaSP As dAddendaSorianapedidos

    Public Function Facturar(ByVal pFactura As dFactura, ByVal pProd As DataTable) As Integer
        Me.txtEstatus.Text = "Generando CFDi"
        If IsNothing(pFactura) OrElse IsNothing(pProd) OrElse pProd.Rows.Count = 0 Then Return -1
        vFacturaData = pFactura
        vProdsFac = pProd
        Bw.RunWorkerAsync()
        If Me.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return vIdFac
        End If
    End Function

    Private Sub frmFacturaProc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = Not FCanClose
    End Sub

    Private Sub frmFacturaProc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Bw_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Bw.DoWork
        Dim vManager As ElectronicManage
        Dim vCertificado As ElectronicCertificate
        Dim vFactura As ElectronicDocument
        ' MsgBox("hola")
        Try
            vManager = ElectronicManage.NewEntity
            'Con los certificados reales remover ValidateCertificateSubject
            'vManager.Save.Options = vManager.Save.Options - SaveOptions.ValidateWithFoliosAutorizados - SaveOptions.ValidateStamp _
            '- SaveOptions.ValidateCertificateSubject - SaveOptions.ValidateCertificateWithCrl
            vManager.Save.Options = vManager.Save.Options - SaveOptions.ValidateCertificateWithCrl
            ' vManager.CertificateAuthorityList.UseForTest()
            vCertificado = ElectronicCertificate.NewEntity(gPathFactuacion & gConfigGlobal.Cer_Name, gPathFactuacion & gConfigGlobal.Key_Name, gConfigGlobal.PassCert)
            vManager.Save.AssignCertificate(vCertificado)
            vFactura = ElectronicDocument.NewEntity()
            vFactura.AssignManage(vManager)
            vFactura.Data.Clear()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            e.Cancel = True
            Exit Sub
        End Try
        Bw.ReportProgress(10, "Generandos CFDi - Datos Facturación")
        With vFactura.Data
            .Version.Value = "3.2"
            If vFacturaData.Serie <> "" Then .Serie.Value = vFacturaData.Serie
            .Folio.Value = vFacturaData.Folio
            .Serie.Value = vFacturaData.Serie
            .Fecha.Value = vFacturaData.Fecha
            .FormaPago.Value = "PAGO EN UNA SOLA EXHIBICION"
            .SubTotal.Value = FormatNumber(vFacturaData.Subtotal, 2, TriState.False, TriState.False, TriState.False)
            If vFacturaData.Descuento > 0 Then .Descuento.Value = FormatNumber(vFacturaData.Descuento, 2, TriState.False, TriState.False, TriState.False)
            .Total.Value = FormatNumber(vFacturaData.Total, 2, TriState.False, TriState.False, TriState.False)
            .TipoCambio.Value = FormatNumber(vFacturaData.TipoCambio, 4, TriState.False, TriState.False, TriState.False)
            .Moneda.Value = vFacturaData.Moneda
            .TipoComprobante.Value = "ingreso"
            .MetodoPago.Value = vFacturaData.Metodo_Pago
            If vFacturaData.Cuenta <> "" Then .NumeroCuentaPago.Value = vFacturaData.Cuenta

            .Emisor.Rfc.Value = gConfigGlobal.Registro_Federal
            .LugarExpedicion.Value = gConfigGlobal.Direccion_Fiscal.Localidad & ", " & gConfigGlobal.Direccion_Fiscal.Estado
            'Dirección Fiscal

            .Emisor.Domicilio.Calle.Value = gConfigGlobal.Direccion_Fiscal.Calle
            If Trim(gConfigGlobal.Direccion_Fiscal.NoExterior) <> "" Then .Emisor.Domicilio.NumeroExterior.Value = gConfigGlobal.Direccion_Fiscal.NoExterior
            If Trim(gConfigGlobal.Direccion_Fiscal.NoInterior) <> "" Then .Emisor.Domicilio.NumeroInterior.Value = gConfigGlobal.Direccion_Fiscal.NoInterior
            If Trim(gConfigGlobal.Direccion_Fiscal.Colonia) <> "" Then .Emisor.Domicilio.Colonia.Value = gConfigGlobal.Direccion_Fiscal.Colonia
            If Trim(gConfigGlobal.Direccion_Fiscal.Localidad) <> "" Then .Emisor.Domicilio.Localidad.Value = gConfigGlobal.Direccion_Fiscal.Localidad
            If Trim(gConfigGlobal.Direccion_Fiscal.Referencia) <> "" Then .Emisor.Domicilio.Referencia.Value = gConfigGlobal.Direccion_Fiscal.Referencia
            .Emisor.Domicilio.Municipio.Value = gConfigGlobal.Direccion_Fiscal.Municipio
            .Emisor.Domicilio.Estado.Value = gConfigGlobal.Direccion_Fiscal.Estado
            .Emisor.Domicilio.Pais.Value = gConfigGlobal.Direccion_Fiscal.Pais
            .Emisor.Domicilio.CodigoPostal.Value = gConfigGlobal.Direccion_Fiscal.CodigoPostal

            If gConfigGlobal.RazonSocial <> "" Then .Emisor.Nombre.Value = gConfigGlobal.RazonSocial



            Dim vRegimen As New RegimenFiscal
            vRegimen.Regimen.Value = gConfigGlobal.RegimenFiscal
            .Emisor.Regimenes.Add(vRegimen)

            Bw.ReportProgress(10, "Generandos CFDi - Obtendiendo datos del cliente")
            Dim vCliente As dCliente
            Dim vCls As New cClientes
            vCliente = vCls.GetCliente(vFacturaData.IdCliente)
            If IsNothing(vCliente) Then
                e.Cancel = True
                Exit Sub
            End If

            .Receptor.Rfc.Value = vCliente.RFC
            .Receptor.Nombre.Value = vCliente.Nombre
            If .Receptor.RFC.Value <> "XAXX010101000" Then
                .Receptor.Domicilio.Calle.Value = vCliente.Calle
                .Receptor.Domicilio.CodigoPostal.Value = vCliente.CP
                If vCliente.Colonia <> "" Then .Receptor.Domicilio.Colonia.Value = vCliente.Colonia
                .Receptor.Domicilio.Estado.Value = vCliente.Estado
                .Receptor.Domicilio.Localidad.Value = vCliente.Localidad
                If vCliente.Municipio <> "" Then .Receptor.Domicilio.Municipio.Value = vCliente.Municipio
                .Receptor.Domicilio.NumeroExterior.Value = vCliente.NoExterior
                If Trim(vCliente.NoInterior) <> "" Then .Receptor.Domicilio.NumeroInterior.Value = vCliente.NoInterior
                .Receptor.Domicilio.Pais.Value = vCliente.Pais
                If vCliente.Referencia <> "" Then .Receptor.Domicilio.Referencia.Value = vCliente.Referencia
            End If
            Bw.ReportProgress(10, "Generandos CFDi - Agregando Conceptos")

            Dim vConcepto As Document.Concepto
            Dim vRow As DataRow
            Dim VvFacs As New cFacturas
            For Each vRow In Me.vProdsFac.Rows
                vConcepto = New Document.Concepto
                vConcepto.Cantidad.Value = vRow.Item("cantidad")
                vConcepto.Descripcion.Value = vRow.Item("producto")
                vConcepto.NumeroIdentificacion.Value = vRow.Item("codigo")
                vConcepto.ValorUnitario.Value = FormatNumber(vRow.Item("precio"), 2, TriState.False, TriState.False, TriState.False)
                vConcepto.Importe.Value = FormatNumber(vRow.Item("precio") * vRow.Item("cantidad"), 2, TriState.False, TriState.False, TriState.False)
                vConcepto.Unidad.Value = vRow.Item("unidadnom")
                .Conceptos.Add(vConcepto)
                'Id = vDrow.Item("id")
                '.Producto = vDrow.Item("prodnom")
                '.Cantidad = vDrow.Item("Cantidad")
                '.Orden = vDrow.Item("No")
                '.Lbs = vDrow.Item("lbs")
                '.Precio = vDrow.Item("Precio")
            Next

            Dim vImp As New Document.Traslado
            vImp.Importe.Value = FormatNumber(vFacturaData.IVA, 2, TriState.False, TriState.False, TriState.False)
            vImp.Tipo.Value = "IVA"
            vImp.Tasa.Value = FormatNumber(gConfigGlobal.IVA * 100, 2, TriState.False, TriState.False, TriState.False)
            .Impuestos.Traslados.Add(vImp)

            .Impuestos.TotalTraslados.Value = FormatNumber(vFacturaData.IVA, 2, TriState.False, TriState.False, TriState.False)

            If vFacturaData.RetencionIVA > 0 Then
                Dim vImpR As New Document.Impuesto
                vImpR.Tipo.Value = "IVA"
                vImpR.Importe.Value = vFacturaData.RetencionIVA
                .Impuestos.TotalRetenidos.Value = FormatNumber(vFacturaData.RetencionIVA, 2, TriState.False, TriState.False, TriState.False)
            End If
            '---------Adenda Soriana ----------------

            'Dim vAddendaSR As dAddendaSorianaremision

            'If frmFactura.CheckBox1.Checked Then
            Dim AddsorianaRemision As New Addendas.Soriana.SorianaRemision()
            AddsorianaRemision.Remision.Value = vAddendaSR.remision
            AddsorianaRemision.Proveedor.Value = vAddendaSR.Proveedor
            AddsorianaRemision.Consecutivo.Value = vAddendaSR.Consecutivo
            AddsorianaRemision.FechaRemision.Value = vAddendaSR.FechaRemision
            AddsorianaRemision.Tienda.Value = vAddendaSR.Tienda
            AddsorianaRemision.TipoMoneda.Value = vAddendaSR.TipoMoneda
            AddsorianaRemision.TipoBulto.Value = vAddendaSR.TipoBulto
            AddsorianaRemision.EntregaMercancia.Value = vAddendaSR.EntregaMercancia
            AddsorianaRemision.CumpleReqFiscales.Value = vAddendaSR.CumpleReqFiscales
            AddsorianaRemision.CantidadBultos.Value = vAddendaSR.CantidadBultos
            AddsorianaRemision.Subtotal.Value = vAddendaSR.Subtotal
            AddsorianaRemision.IEPS.Value = vAddendaSR.IEPS
            AddsorianaRemision.IVA.Value = vAddendaSR.IVA
            AddsorianaRemision.OtrosImpuestos.Value = vAddendaSR.OtrosImpuestos
            AddsorianaRemision.Total.Value = vAddendaSR.Total
            AddsorianaRemision.CantidadPedidos.Value = vAddendaSR.CantidadPedidos
            AddsorianaRemision.FechaEntregaMercancia.Value = vAddendaSR.FechaEntregaMercancia

            'pedidos ---------
            Dim AddsorianaPedidos As New Addendas.Soriana.SorianaPedidos
            AddsorianaPedidos.Proveedor.Value = frmFactura.addenP.Proveedor
            AddsorianaPedidos.Remision.Value = frmFactura.addenP.remision
            AddsorianaPedidos.FolioPedido.Value = frmFactura.addenP.FolioPedido
            AddsorianaPedidos.Tienda.Value = frmFactura.addenP.Tienda
            AddsorianaPedidos.CantidadArticulos.Value = frmFactura.addenP.CantidadArticulos
            'AddsorianaPedidos.PedidoEmitidoProveedor.value = "SI" falta este campo

            Dim AddsorianaArticulos As Addendas.Soriana.SorianaArticulos
            For Each vRow In Me.vProdsFac.Rows
                AddsorianaArticulos = New FacturaNETLib.Addendas.Soriana.SorianaArticulos
                AddsorianaArticulos.Proveedor.Value = vRow.Item("cantidad")
                AddsorianaArticulos.Remision.Value = vRow.Item("producto")
                AddsorianaArticulos.FolioPedido.Value = vRow.Item("codigo")
                AddsorianaArticulos.Tienda.Value = FormatNumber(vRow.Item("precio"), 2, TriState.False, TriState.False, TriState.False)
                AddsorianaArticulos.Codigo.Value = FormatNumber(vRow.Item("precio") * vRow.Item("cantidad"), 2, TriState.False, TriState.False, TriState.False)
                AddsorianaArticulos.CantidadUnidadCompra.Value = vRow.Item("unidadnom")
                AddsorianaArticulos.CostoNetoUnidadCompra.Value = vRow.Item("unidadnom")
                AddsorianaArticulos.PorcentajeIEPS.Value = vRow.Item("unidadnom")
                AddsorianaArticulos.PorcentajeIVA.Value = vRow.Item("unidadnom")
            Next

            'Else

            'End If
            '---------------------------------fin de addenda soriana
            Dim vXml As String
            Dim vRes As FacturaNETLib.RespuestaFacturacion
            '        Dim vMemory As New MemoryStream
            Bw.ReportProgress(10, "Generandos CFDi - Validando CFDi")
            If vFactura.SaveToString(vXml) Then
                Bw.ReportProgress(10, "Timbrando CFDi")
                'Dim Timbrado As New WsCFDI.TimbradoWSService

                'Dim Timbrado2 As New mx.advans.app.advanswsdl
                'Dim vTimbre As String = ""
                'Dim vAcuse As String = ""
                Try

                    'Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(vXml)
                    'Dim vStrBase64 As String = Convert.ToBase64String(byt)

                    'Timbrado2.Url = gConfigGlobal.CFDI_Url
                    If gConfigGlobal.ProveedorTimbres = eProveedorTimbres.Advans Then
                        vRes = FacturaNETLib.Facturacion.Facturar(gConfigGlobal.CFDI_Url, gConfigGlobal.CFDI_Id, vXml)
                    ElseIf gConfigGlobal.ProveedorTimbres = eProveedorTimbres.FEL Then
                        'MsgBox(vXml)
                        'vRes = FacturaNETLib.Facturacion.FacturarFEL(gConfigGlobal.CFDI_Url, gConfigGlobal.CFDI_Id, gConfigGlobal.CFDI_Token, vXml, gConfigGlobal.Registro_Federal & "-" & vCliente.RFC & "-" & vFacturaData.Serie & vFacturaData.Folio)
                        Dim refe As String = vCliente.RFC & "-" & vFacturaData.Serie & String.Format("{0:000000}", Convert.ToInt32(vFacturaData.Folio)) 'gConfigGlobal.Registro_Federal & vFacturaData.Folio
                        vRes = FacturaNETLib.Facturacion.FacturarFEL(gConfigGlobal.CFDI_Url, gConfigGlobal.CFDI_Id, gConfigGlobal.CFDI_Token, vXml, refe)
                    End If

                    'vRes = Timbrado2.timbrar2(gConfigGlobal.CFDI_Id, vXml)
                    Bw.ReportProgress(10, "Respuesta Recibida")
                    Dim vFacs As New cFacturas
                    If IsNothing(vRes) OrElse (vRes.Codigo <> "200" And vRes.Codigo <> "504") Then
                        MsgBox(vRes.Codigo & " " & vRes.Mensaje, MsgBoxStyle.Critical)
                        '  If Not IsNothing(vRes) AndAlso vRes.timbre <> "" Then
                        vFacs.Request(vXml, "")
                        'End If
                        e.Cancel = True
                        Exit Sub
                    End If

                    If Not IsNothing(vRes) AndAlso vRes.Timbre <> "" Then
                        vFacs.Request(vRes.Timbre, "")
                    End If
                    'Dim vMemory As New MemoryStream(System.Text.Encoding.UTF8.GetBytes(vTimbre))
                    'vFactura.Data.Clear()
                    ' vFactura.Manage.Load.Options = 0

                    If Not vFactura.LoadFromString(vRes.Timbre) Then
                        MsgBox("Error al leer la factura ", MsgBoxStyle.Critical, "Error leyendo timbre")
                        Dim vDatos As New frmFacturaTimbre
                        vDatos.txtTimbre.Text = vRes.Timbre
                        vDatos.txtAcuse.Text = ""
                        vDatos.ShowDialog()
                        e.Cancel = True
                        Exit Sub
                    Else
                        Dim n As Integer
                        Dim FolioFiscal As String
                        Dim vTimbreData As Complementos.TimbreFiscalDigital
                        For n = 0 To vFactura.Data.Complementos.Count - 1
                            If vFactura.Data.Complementos(n).Type = Complementos.eComplementoTipo.TimbreFiscalDigital Then
                                vTimbreData = CType(vFactura.Data.Complementos(n).Data, Complementos.TimbreFiscalDigital)
                                'Dim Descto As Double = frmFactura.gdescuento ' por mientras se añade la variable descuento en facturas
                                vIdFac = vFacs.Agregar(vFacturaData.Serie, vFacturaData.Folio, vFacturaData.Fecha, vFacturaData.IdCliente, vFacturaData.Subtotal, vFacturaData.IVA, vFacturaData.Total, vXml, vRes.Timbre, "", vTimbreData.Uuid.Value, vTimbreData.FechaTimbrado.Value, vFacturaData.MetodosPagoId, vFacturaData.Cuenta, vFacturaData.RetencionIVA, vFacturaData.Descuento, gConfigGlobal.Registro_Federal)
                                If vIdFac <= -1 Then
                                    MsgBox("Ocurrio un error al querer dar de alta la factura, por favor importe el xml del cfdi", MsgBoxStyle.Critical, "Error")
                                    e.Cancel = True
                                    Exit Sub
                                End If
                                For Each vRow In Me.vProdsFac.Rows
                                    If vRow.Item("isproducto") Then
                                        'MsgBox("vIdFac " & vIdFac & "vRow.id " & vRow.Item("id") & "codigo " & vRow.Item("codigo") & " cantidad " & vRow.Item("cantidad") & " precio" & vRow.Item("precio") & "unidad" & vRow.Item("unidad") & vRow.Item("isproducto") & "" & "  tasa " & vRow.Item("tasa"))
                                        vFacs.AgregarProducto(vIdFac, vRow.Item("id"), vRow.Item("cantidad"), vRow.Item("precio"), vRow.Item("unidad"), vRow.Item("isproducto"), "", vRow.Item("tasa"), vRow.Item("codigo"))
                                    Else
                                        vFacs.AgregarProducto(vIdFac, vRow.Item("id"), vRow.Item("cantidad"), vRow.Item("precio"), vRow.Item("unidad"), vRow.Item("isproducto"), vRow.Item("producto"), vRow.Item("tasa"), vRow.Item("codigo"))
                                    End If

                                Next

                            End If
                        Next


                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
                    If Not IsNothing(vRes) AndAlso vRes.Timbre <> "" Then
                        Dim vDatos As New frmFacturaTimbre
                        vDatos.txtTimbre.Text = vRes.Timbre
                        vDatos.txtAcuse.Text = ""
                        vDatos.ShowDialog()
                    End If
                End Try
            Else
                MsgBox("Errro al timbrar la factura")

            End If
        End With
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
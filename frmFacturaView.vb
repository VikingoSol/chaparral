Imports BaseDatos
Imports FacturaNETLib
Imports FacturaNETLib.Manager
Imports FacturaNETLib.Document
Imports FacturaNETLib.Certificate
Imports System.Xml
Imports System.Text
Public Class frmFacturaView
    'Dim vTablaProds As New DataTable
    Dim pathfilexml As String
    Dim vAddSorRemi As New dAddendaSorianaremision
    Dim vAddSorpedido As New dAddendaSorianapedidos
    Dim vAddSorArticulos As New dAddendaSorianaArticulos
    Dim xd As XmlDocument
    Dim facturasel As Integer
    Dim vTablaProds As DataTable

    '---------------------------------
    Dim ruta As String = ""
    Dim proceso As geCFD.cProccess = New geCFD.cProccess()

    Dim cfdi As geCFD.cCFDI = New geCFD.cCFDI()
    Dim nodos As NodosAddendaSorianaCFDI.Nodos = New NodosAddendaSorianaCFDI.Nodos()

    Dim addenda As geCFD.cMyElement = New geCFD.cMyElement() ' addenda

    Dim DSCarga As geCFD.cMyElement = New geCFD.cMyElement()   ' dsc

    Dim remision_Remision As geCFD.cMyElement = New geCFD.cMyElement()
    Dim proveedor As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elementoProveedor As geCFD.cMyElement = New geCFD.cMyElement()
    Dim folioRemision As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elementoFolioRemision As geCFD.cMyElement = New geCFD.cMyElement()
    Dim nodeConsecutivo As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elementConsecutivo As geCFD.cMyElement = New geCFD.cMyElement()
    Dim nodeFechaRem As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elementFechaRem As geCFD.cMyElement = New geCFD.cMyElement()
    Dim nodeTienda As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elementTienda As geCFD.cMyElement = New geCFD.cMyElement()
    Dim tipoMoneda As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntTipoMoneda As geCFD.cMyElement = New geCFD.cMyElement()
    Dim tipoBulto As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntTipoBulto As geCFD.cMyElement = New geCFD.cMyElement()
    Dim entregaMerc As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntEntregaMerc As geCFD.cMyElement = New geCFD.cMyElement()
    Dim cumpleReqFiscales As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntCumpleRF As geCFD.cMyElement = New geCFD.cMyElement()
    Dim cantBultos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntCantBultos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim subtotal As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntSubtotal As geCFD.cMyElement = New geCFD.cMyElement()
    Dim descuentos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntDescuentos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim ieps As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntIeps As geCFD.cMyElement = New geCFD.cMyElement()
    Dim iva As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntIva As geCFD.cMyElement = New geCFD.cMyElement()
    Dim otrosImp As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntOtrosImp As geCFD.cMyElement = New geCFD.cMyElement()
    Dim total As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntTotal As geCFD.cMyElement = New geCFD.cMyElement()
    Dim cantidadPedidos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntCantPedidos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim FechaEntregaM As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntFechaEntregaM As geCFD.cMyElement = New geCFD.cMyElement()
    Dim empaqueCajas As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntEmpaqueCajas As geCFD.cMyElement = New geCFD.cMyElement()
    Dim empaqueTarimas As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntEmpaqueTarimas As geCFD.cMyElement = New geCFD.cMyElement()
    Dim cantCajasTarimas As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntCantCajasTarimas As geCFD.cMyElement = New geCFD.cMyElement()
    Dim cita As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntCita As geCFD.cMyElement = New geCFD.cMyElement()
    Dim pedimento As geCFD.cMyElement = New geCFD.cMyElement()
    Dim provPedimento As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntProvPedimento As geCFD.cMyElement = New geCFD.cMyElement()
    Dim remisionPedimento As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntRemisionPedimento As geCFD.cMyElement = New geCFD.cMyElement()
    Dim numPedimento As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntNumPedimento As geCFD.cMyElement = New geCFD.cMyElement()
    Dim aduana As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntAduana As geCFD.cMyElement = New geCFD.cMyElement()
    Dim agenteAduanal As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntAgenteAduanal As geCFD.cMyElement = New geCFD.cMyElement()
    Dim tipoPedimento As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntTipoPedimento As geCFD.cMyElement = New geCFD.cMyElement()
    Dim fechaPedimento As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntFechaPedimento As geCFD.cMyElement = New geCFD.cMyElement()
    Dim fechaReciboL As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntFechaReciboL As geCFD.cMyElement = New geCFD.cMyElement()
    Dim fechaBillOL As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntFechaBill As geCFD.cMyElement = New geCFD.cMyElement()
    Dim nodoRaiz_Pedidos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim proveedorPedidos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntProvPedidos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim remisionPedidos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntRemisionPedidos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim folioPedido As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntFolioPedido As geCFD.cMyElement = New geCFD.cMyElement()
    Dim tiendaPedidos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntTiendaPedidos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim cantArticuloPedidos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntCantArtPedidos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim nodoRaiz_Articulos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim proveedorArticulos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntProvArticulos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim remisionArticulos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntRemisionArticulos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim folioArticulos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntFolioArticulos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim tiendaArticulos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntTiendaArticulos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim codigoArticulos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntCodigoArticulos As geCFD.cMyElement = New geCFD.cMyElement()
    Dim cantUCompraArt As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntCantUCArt As geCFD.cMyElement = New geCFD.cMyElement()
    Dim costoNetoUCompraArt As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmtnCostoNetoUCArt As geCFD.cMyElement = New geCFD.cMyElement()
    Dim porcenIEPSArt As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntPorcenIEPSArt As geCFD.cMyElement = New geCFD.cMyElement()
    Dim porcentajeIVAArt As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntPorcenIVAArt As geCFD.cMyElement = New geCFD.cMyElement()

    Dim nodoRaiz_Articulos1 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim proveedorArticulos1 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntProvArticulos1 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim remisionArticulos1 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntRemisionArticulos1 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim folioArticulos1 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntFolioArticulos1 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim tiendaArticulos1 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntTiendaArticulos1 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim codigoArticulos1 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntCodigoArticulos1 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim cantUCompraArt1 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntCantUCArt1 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim costoNetoUCompraArt1 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmtnCostoNetoUCArt1 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim porcenIEPSArt1 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntPorcenIEPSArt1 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim porcentajeIVAArt1 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntPorcenIVAArt1 As geCFD.cMyElement = New geCFD.cMyElement()

    Dim nodoRaiz_Articulos2 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim proveedorArticulos2 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntProvArticulos2 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim remisionArticulos2 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntRemisionArticulos2 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim folioArticulos2 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntFolioArticulos2 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim tiendaArticulos2 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntTiendaArticulos2 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim codigoArticulos2 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntCodigoArticulos2 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim cantUCompraArt2 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntCantUCArt2 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim costoNetoUCompraArt2 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmtnCostoNetoUCArt2 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim porcenIEPSArt2 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntPorcenIEPSArt2 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim porcentajeIVAArt2 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntPorcenIVAArt2 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim nodoRaiz_Articulos3 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim proveedorArticulos3 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntProvArticulos3 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim remisionArticulos3 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntRemisionArticulos3 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim folioArticulos3 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntFolioArticulos3 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim tiendaArticulos3 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntTiendaArticulos3 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim codigoArticulos3 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntCodigoArticulos3 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim cantUCompraArt3 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntCantUCArt3 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim costoNetoUCompraArt3 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmtnCostoNetoUCArt3 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim porcenIEPSArt3 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntPorcenIEPSArt3 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim porcentajeIVAArt3 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntPorcenIVAArt3 As geCFD.cMyElement = New geCFD.cMyElement()
    Dim nodoRaiz_CajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim proveedorCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntProvCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim remisionCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntRemisionCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim numCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntNumCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim codBarrasCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntCodBarrasCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim sucDistrCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntSucDistrCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim cantArtCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntCantArtCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim nodoRaiz_ArtPorCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim proveedorArtCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntProvArtCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim remisionArtCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntremisionArtCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim folioPedidoArtCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntFolioPedidoArtCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim NumCTArtCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntNumCTArtCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim sucDistrArtCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntSucDistArtCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim codigoArtCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntCodigoArtCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim cantUndCompraArtCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    Dim elmntCantUndCArtCajaTarima As geCFD.cMyElement = New geCFD.cMyElement()
    '---------------------------------

    Public Sub VerFactura(ByVal pId As Integer)
        Dim vFacs As New cFacturas
        Dim vFac As dFacturaView = vFacs.GetFactura(pId)
        facturasel = pId
        If IsNothing(vFac) Then
            Exit Sub
        End If
        Me.txtSerie.Text = vFac.Serie
        Me.txtFolio.Text = vFac.Folio
        Me.txtMetodosPago.Text = vFac.Metodo_PagoTxt
        Me.txtRFC.Text = vFac.Cliente_RFC
        Me.txtFecha.Text = Format(vFac.Fecha_Emision, "dd/ MMM /yyyy HH:mm:ss")
        Me.txtCliente.Text = vFac.Cliente_Nombre
        Me.txtDireccion.Text = vFac.Cliente_Direccion
        Me.txtSubTotal.Text = Format(vFac.SubTotal, "C2")
        Me.txtIVA.Text = Format(vFac.IVA, "C2")
        Me.txtTotal.Text = Format(vFac.Total, "C2")
        Me.txtFolioFiscal.Text = vFac.Folio_Fiscal
        Me.txtAcuse.Text = vFac.xml_acuse
        Me.txtCuenta.Text = vFac.Cuenta
        Me.Txtdescuento.Text = Format(vFac.Descuento, "C2")
        Me.txtRetIVA.Text = Format(vFac.RetencionIVA, "C2")
        If vFac.Estado = 1 Then
            Me.txtEstado.Text = "Activa"
        Else
            Me.txtEstado.Text = "Cancelada"
        End If

        ssubtotal.Text = vFac.SubTotal
        iiva.Text = vFac.IVA
        ttotal.Text = vFac.Total
        iieps.Text = 0.0
        descuento.Text = vFac.Descuento

        'Leer Datos del XML

        Dim vFactura As ElectronicDocument
        Dim vManager As ElectronicManage


        vManager = ElectronicManage.NewEntity
        vFactura = ElectronicDocument.NewEntity()
        vFactura.AssignManage(vManager)


        ' Dim sw As IO.StreamWriter = New IO.StreamWriter(New IO.MemoryStream)
        ' sw.Write(vFac.xml_Timbrado)
        ' sw.Flush()
        ' vFactura.Manage.Load.Options = vFactura.Manage.Load.Options - LoadOptions.ValidateCertificateWithCa - LoadOptions.ValidateCertificateWithCrl - -LoadOptions.ValidateStamp
        If Not vFactura.LoadFromString(vFac.xml_Timbrado) Then
            MsgBox("Error al leer la factura")
            Exit Sub
        End If



        Dim n As Integer
        Dim x As Integer
        Dim vTimbre As Complementos.TimbreFiscalDigital
        For n = 0 To vFactura.Data.Complementos.Count - 1
            If vFactura.Data.Complementos(n).Type = Complementos.eComplementoTipo.TimbreFiscalDigital Then
                vTimbre = CType(vFactura.Data.Complementos(n).Data, Complementos.TimbreFiscalDigital)
                Me.txtCertificadoSAT.Text = vTimbre.NumeroCertificadoSat.Value
                Me.txtCadenaOrig.Text = vTimbre.FingerPrintPac
                Me.txtSelloSAT.Text = vTimbre.SelloSat.Value
                Me.txtSelloEmisor.Text = vTimbre.SelloCfd.Value
                Me.txtFecha_Cer.Text = vTimbre.FechaTimbrado.Value
                Dim vXml As String = cFacturas.GetFacturaXML(pId)
                Me.TxtXml.Text = vXml
            End If
        Next

        Me.grdProductos.DataSource = vFacs.GetProductosFacturados(pId)
        vTablaProds = vFacs.GetProductosFacturados(pId)
        Dim sumart As Double
        Dim vRow As DataRow
        Dim VvFacs As New cFacturas
        For Each vRow In vTablaProds.Rows
            sumart += vRow.Item("cantidad")
        Next
        Me.TxtCantidadArticulos.Text = sumart
        Me.ShowDialog()
    End Sub

    Private Sub Clear_Datos_Cliente()
        Me.txtCliente.Text = ""
        Me.txtRFC.Text = ""
    End Sub

    Private Sub Datos_Cliente()
        'If Trim(Me.txtIdCliente.Text) = "" Then
        '    Clear_Datos_Cliente()
        '    Exit Sub
        'End If
        'Me.vLastIdCl = Trim(Me.txtIdCliente.Text)
        'Dim vClientes As New cClientes
        'vCliente = vClientes.GetCliente(Me.txtIdCliente.Text)
        'If IsNothing(vCliente) Then
        '    Clear_Datos_Cliente()
        'Else
        '    Me.txtCliente.Text = vCliente.Nombre
        '    Me.txtRFC.Text = vCliente.RFC
        'End If
    End Sub



    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim vProds As New cProductos
        Dim vUnis As DataTable = vProds.GetUnidades()
        If Not IsNothing(vUnis) Then
            Me.grdProductos.RootTable.Columns("unidad").ValueList.PopulateValueList(vUnis.DefaultView, "id", "unidad")
        End If

        Dim vFac As New BaseDatos.cFacturas
        Me.cmbtienda.DisplayMember = "nombre"
        Me.cmbtienda.ValueMember = "no"
        Me.cmbtienda.DataSource = vFac.GettiendasSoriana

        Me.CmbEntregaM.DisplayMember = "nombre"
        Me.CmbEntregaM.ValueMember = "no"
        Me.CmbEntregaM.DataSource = vFac.GettiendasSoriana

        Me.CmbtiendaP.DisplayMember = "nombre"
        Me.CmbtiendaP.ValueMember = "no"
        Me.CmbtiendaP.DataSource = vFac.GettiendasSoriana
    End Sub

    'Private Sub Crear_Tabla()
    '    Me.vTablaProds.Columns.Add("id", GetType(Integer))
    '    Me.vTablaProds.Columns.Add("cantidad", GetType(Double))
    '    Me.vTablaProds.Columns.Add("producto", GetType(String))
    '    Me.vTablaProds.Columns.Add("precio", GetType(Double))
    '    Me.vTablaProds.Columns.Add("isproducto", GetType(Boolean))
    '    Me.vTablaProds.Columns.Add("unidad", GetType(Integer))
    'End Sub


    Private Sub grdProductos_FormattingRow(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles grdProductos.FormattingRow

    End Sub

    Private Sub grdProductos_LoadingRow(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles grdProductos.LoadingRow
        If e.Row.RowType = Janus.Windows.GridEX.RowType.Record Then
            e.Row.Cells("importe").Value = e.Row.Cells("cantidad").Value * e.Row.Cells("precio").Value
        End If
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSelloSAT.TextChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.OpenFileDialog1.Filter = "Archivo Cer (*.cer)|*.cer"
        'Me.OpenFileDialog1.FileName = Me.txtCertificado.Text
        'If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    Me.txtCertificado.Text = Me.OpenFileDialog1.FileName
        'End If
    End Sub
    Private Function validarCampos() As Boolean

        If cmbMoneda.Text = "" OrElse cmbMoneda.Text = Nothing Then
            MessageBox.Show("Debe seleccionar un tipo de moneda.")
            cmbMoneda.Focus()
            cmbMoneda.DroppedDown = True 'Desplegar automatico el comboBox
            Return False

        End If

        If CmbEntregaM.Text = "" OrElse CmbEntregaM.Text = Nothing Then
            MessageBox.Show("Debe de indicar un número de entrega de mercancía")
            CmbEntregaM.Focus()
            Return False

        End If

        Return True

    End Function
    Public Function formatoFechaRemision() As String
        Dim fecha As String = ""
        dpFecha.Format = DateTimePickerFormat.Custom
        fecha = dpFecha.Text
        dpFecha.Format = DateTimePickerFormat.Short
        Return fecha

    End Function
 

    Public Function formatoFechaEntregaM() As String
        Dim fecha As String = ""
        Me.fFechaEntregaM.Format = DateTimePickerFormat.Long
        fecha = fFechaEntregaM.Text
        fFechaEntregaM.Format = DateTimePickerFormat.Long
        Return fecha

    End Function

    Public Function valorTipoMoneda() As String

        Dim numero As String = ""
        If cmbMoneda.Text = "Pesos" Then
            numero = "1"

        End If
        If cmbMoneda.Text = "Dolares" Then
            numero = "2"

        End If
        Return numero

    End Function

    Private Function insertarAddenda(ByVal archivoXML As String) As Boolean
        Dim vFac As dAddendaSorianaremision = vAddSorRemi
        Dim vpedi As dAddendaSorianapedidos = vAddSorpedido
        Dim vArt As dAddendaSorianaArticulos = vAddSorArticulos
        Try
            addenda = nodos.nodoAddenda()
            DSCarga = nodos.nodoDSCargaRemisionProv()
            If Not validarCampos() Then
                Return False
            End If
            remision_Remision = nodos.nodoRemision(campoIdRemision.Text, campoRowOrder.Text)
            elementoProveedor = nodos.datoProveedor(vFac.Proveedor)
            proveedor = nodos.nodoProveedor()
            elementoFolioRemision = nodos.elementoFolioRemision(vFac.remision.Trim)
            folioRemision = nodos.nodoFolioRemision()
            elementConsecutivo = nodos.elementoConsecutivo(vFac.Consecutivo.Trim)
            nodeConsecutivo = nodos.nodoConsecutivo()
            elementFechaRem = nodos.elementoFechaRemision(vFac.FechaRemision.Trim)
            nodeFechaRem = nodos.nodoFechaRemision()
            elementTienda = nodos.elementoTienda(vFac.Tienda.Trim)
            nodeTienda = nodos.nodoTienda()
            elmntTipoMoneda = nodos.elementoMoneda(vFac.TipoMoneda.Trim)
            tipoMoneda = nodos.nodoTipoMoneda()
            elmntTipoBulto = nodos.elementoBulto(vFac.TipoBulto.ToString.Trim)
            tipoBulto = nodos.nodoTipoBulto()
            elmntEntregaMerc = nodos.elementoEntregaMercancia(vFac.EntregaMercancia)
            entregaMerc = nodos.nodoEntregaMercancia()
            ' *** En Visual Basic 2008 se puede hacer así:
            'elmntCumpleRF = If( nodos.elementoCumpleRF(comboCumpleRqF.Text = "Si" , "true" , "false"))
            '*** Debes comprobar el tipo del valor devuelto

            elmntCumpleRF = nodos.elementoCumpleRF(vFac.CumpleReqFiscales.Trim) 'IIf(nodos.elementoCumpleRF(comboCumpleRqF.Text = "Si", "true", "false"))
            cumpleReqFiscales = nodos.nodoCumpleReqF()
            elmntCantBultos = nodos.elementoCantBultos(vFac.CantidadBultos.ToString.Trim)
            cantBultos = nodos.nodoCantidadBultos()
            elmntSubtotal = nodos.elementoSubtotal(vFac.Subtotal.ToString.Trim)
            subtotal = nodos.nodoSubtotal()
            elmntDescuentos = nodos.elementoDescuentos(vAddSorRemi.descuento.ToString.Trim)
            descuentos = nodos.nodoDescuentos()
            elmntIeps = nodos.elementoIEPS(vFac.IEPS.ToString.Trim)
            ieps = nodos.nodoIEPS()
            elmntIva = nodos.elementoIVA(vFac.IVA.ToString.Trim)
            iva = nodos.nodoIVA()
            elmntOtrosImp = nodos.elementoOtrosImp(vFac.OtrosImpuestos.ToString.Trim)
            otrosImp = nodos.nodoOtrosImp()
            elmntTotal = nodos.elementoTotal(vFac.Total)
            total = nodos.nodoTotal()

            elmntCantPedidos = nodos.elementoCantPedidos(Txtcantidadpedidos.Text.Trim)
            cantidadPedidos = nodos.nodoCantPedidos()
            elmntFechaEntregaM = nodos.elementoFechaEM(vFac.FechaEntregaMercancia)
            FechaEntregaM = nodos.nodoFechaEntregaMercancia()
            ' *** En Visual Basic 2008 se puede hacer así:
            'elmntEmpaqueCajas = If( nodos.elementoEmpaqueCajas(comboEmpaqueCajas.Text = "Si" , "true" , "false"))
            '*** Debes comprobar el tipo del valor devuelto

            elmntEmpaqueCajas = nodos.elementoEmpaqueCajas(comboEmpaqueCajas.Text.Trim) ' IIf(nodos.elementoEmpaqueCajas(comboEmpaqueCajas.Text = "Si", "true", "false"))
            empaqueCajas = nodos.nodoEmpaqueEnCajas()
            ' *** En Visual Basic 2008 se puede hacer así:
            'elmntEmpaqueTarimas = If( nodos.elementoEmpaqueTarima(comboEmpaqueTarimas.Text = "Si" , "true" , "false"))
            '*** Debes comprobar el tipo del valor devuelto


            'elmntEmpaqueTarimas = nodos.elementoEmpaqueTarima(comboEmpaqueTarimas.Text) 'IIf(nodos.elementoEmpaqueTarima(comboEmpaqueTarimas.Text = "Si", "true", "false"))
            'empaqueTarimas = nodos.nodoEmpaqueTarimas()
            'elmntCantCajasTarimas = nodos.elementoCajasTarimas(campoCantCajaTarima.Text)
            'cantCajasTarimas = nodos.nodoCantCajasTarimas()
            'elmntCita = nodos.elementoCita(campoCita.Text)
            'cita = nodos.nodoCita()

            'pedimento = nodos.nodoPedimento(campoIDPedimento.Text, campoRowOrderPedimento.Text)
            'elmntProvPedimento = nodos.elementoProvPedimento(campoProveedorPedimento.Text)
            'provPedimento = nodos.nodoProveedorPedimento()
            'elmntRemisionPedimento = nodos.elementoRemisionPedimento(campoRemisionPedimento.Text)
            'remisionPedimento = nodos.nodoRemisionPedimento()
            'elmntNumPedimento = nodos.elementoNumPedimento(campoPedimentoPedimento.Text)
            'numPedimento = nodos.nodoNumeroPedimento()
            'elmntAduana = nodos.elementoAduanaPedimento(campoAduanaPedimento.Text)
            'aduana = nodos.nodoAduanaPedimento()
            'elmntAgenteAduanal = nodos.elementoAgenteAduanal(CampoAgentePedimento.Text)
            'agenteAduanal = nodos.nodoAgenteAduanal()
            'elmntTipoPedimento = nodos.elementoTipoPedimento(CampoTipoPedimentoPedimento.Text)
            'tipoPedimento = nodos.nodoTipoPedimento()
            'elmntFechaPedimento = nodos.elementoFechaPedimento(formatoFechaPedimento())
            'fechaPedimento = nodos.nodoFechaPedimento()
            'elmntFechaReciboL = nodos.elementoFechaRL(formatoFechaReciboL())
            'fechaReciboL = nodos.nodoFechaReciboLaredo()
            'elmntFechaBill = nodos.elementoFechaBill(formatoFechaBillOL())
            'fechaBillOL = nodos.nodoFechaBillOL()

            nodoRaiz_Pedidos = nodos.nodoPedidos("Pedidos1", "1")
            elmntProvPedidos = nodos.elementoProvPedido(vpedi.Proveedor.ToString.Trim)
            proveedorPedidos = nodos.nodoProveedorPedidos()
            elmntRemisionPedidos = nodos.elementoRemisionPedidos(vpedi.remision.Trim)
            remisionPedidos = nodos.nodoRemisionPedidos()
            elmntFolioPedido = nodos.elementoFolioPedido(vpedi.FolioPedido.ToString.Trim)
            folioPedido = nodos.nodoFolioPedido()
            elmntTiendaPedidos = nodos.elementoTiendaPedidos(CmbtiendaP.SelectedValue.ToString.Trim)
            tiendaPedidos = nodos.nodoTiendaPedidos()
            elmntCantArtPedidos = nodos.elementoCantArt(vpedi.CantidadArticulos.ToString.Trim)
            cantArticuloPedidos = nodos.nodoCantArticulos()

            Dim vRow As DataRow
            'For Each vRow In vTablaProds.Rows
            '    MsgBox(vRow.Item("cantidad"))
            '    vAddSorArticulos.remision = Me.Txtremision.Text
            '    vAddSorArticulos.FolioPedido = Me.Txtfoliopedido.Text
            '    vAddSorArticulos.Tienda = Me.CmbtiendaP.SelectedValue
            '    vAddSorArticulos.CantidadArticulos = vRow.Item("cantidad")
            '    vAddSorArticulos.Codigo = vRow.Item("codigo")
            '    vAddSorArticulos.CantidadUnidadCompra = FormatNumber(vRow.Item("cantidad"), 2, TriState.False, TriState.False, TriState.False)
            '    vAddSorArticulos.CostoNetoUnidadCompra = FormatNumber(vRow.Item("precio") * vRow.Item("cantidad"), 2, TriState.False, TriState.False, TriState.False)
            '    vAddSorArticulos.PorcentajeIEPS = 0.0
            '    vAddSorArticulos.PorcentajeIVA = 0.0

            'Next

            Dim c As Integer = 0
            For Each vRow In vTablaProds.Rows
                If c = 0 Then
                    nodoRaiz_Articulos = nodos.nodoArticulos("Articulos" & c + 1, c + 1)
                    elmntProvArticulos = nodos.elementoProvArticulos(vArt.Proveedor.ToString.Trim)
                    proveedorArticulos = nodos.nodoProveedorArticulos()
                    elmntRemisionArticulos = nodos.elementoRemisionArticulos(vArt.remision.Trim)
                    remisionArticulos = nodos.nodoRemisionArticulos()
                    elmntFolioArticulos = nodos.elementoFolioPedidoArt(vArt.FolioPedido.ToString.Trim)
                    folioArticulos = nodos.nodoFolioPedidoArticulo()
                    elmntTiendaArticulos = nodos.elementoTiendaArticulo(CmbtiendaP.SelectedValue.ToString.Trim)
                    tiendaArticulos = nodos.nodoTiendaArticulos()

                    elmntCodigoArticulos = nodos.elementoCodigoArt(vRow.Item("codigo").ToString.Trim)
                    codigoArticulos = nodos.nodoCodigoArticulo()
                    elmntCantUCArt = nodos.elementoCantUC(FormatNumber(vRow.Item("cantidad"), 2, TriState.False, TriState.False, TriState.False))
                    cantUCompraArt = nodos.nodoCantidadUCompra()
                    elmtnCostoNetoUCArt = nodos.elementoCostoNUC(FormatNumber(vRow.Item("precio") * vRow.Item("cantidad"), 2, TriState.False, TriState.False, TriState.False))
                    costoNetoUCompraArt = nodos.nodoCostoNetoUC()

                    elmntPorcenIEPSArt = nodos.elementoPorcentajeIEPS(vArt.PorcentajeIEPS.ToString.Trim)
                    porcenIEPSArt = nodos.nodoPorcentajeIEPS()
                    elmntPorcenIVAArt = nodos.elementoPorcentajeIVA(vArt.PorcentajeIVA.Trim)
                    porcentajeIVAArt = nodos.nodoPorcentajeIVA()
                End If
                If c = 1 Then
                    nodoRaiz_Articulos1 = nodos.nodoArticulos("Articulos" & c + 1, c + 1)
                    elmntProvArticulos1 = nodos.elementoProvArticulos(vArt.Proveedor.ToString.Trim)
                    proveedorArticulos1 = nodos.nodoProveedorArticulos()
                    elmntRemisionArticulos1 = nodos.elementoRemisionArticulos(vArt.remision.Trim)
                    remisionArticulos1 = nodos.nodoRemisionArticulos()
                    elmntFolioArticulos1 = nodos.elementoFolioPedidoArt(vArt.FolioPedido.ToString.Trim)
                    folioArticulos1 = nodos.nodoFolioPedidoArticulo()
                    elmntTiendaArticulos1 = nodos.elementoTiendaArticulo(CmbtiendaP.SelectedValue.ToString.Trim)
                    tiendaArticulos1 = nodos.nodoTiendaArticulos()

                    elmntCodigoArticulos1 = nodos.elementoCodigoArt(vRow.Item("codigo").ToString.Trim)
                    codigoArticulos1 = nodos.nodoCodigoArticulo()
                    elmntCantUCArt1 = nodos.elementoCantUC(FormatNumber(vRow.Item("cantidad"), 2, TriState.False, TriState.False, TriState.False))
                    cantUCompraArt1 = nodos.nodoCantidadUCompra()
                    elmtnCostoNetoUCArt1 = nodos.elementoCostoNUC(FormatNumber(vRow.Item("precio") * vRow.Item("cantidad"), 2, TriState.False, TriState.False, TriState.False))
                    costoNetoUCompraArt1 = nodos.nodoCostoNetoUC()

                    elmntPorcenIEPSArt1 = nodos.elementoPorcentajeIEPS(vArt.PorcentajeIEPS.ToString.Trim)
                    porcenIEPSArt1 = nodos.nodoPorcentajeIEPS()
                    elmntPorcenIVAArt1 = nodos.elementoPorcentajeIVA(vArt.PorcentajeIVA.Trim)
                    porcentajeIVAArt1 = nodos.nodoPorcentajeIVA()
                End If
                If c = 2 Then
                    nodoRaiz_Articulos2 = nodos.nodoArticulos("Articulos" & c + 1, c + 1)
                    elmntProvArticulos2 = nodos.elementoProvArticulos(vArt.Proveedor.ToString.Trim)
                    proveedorArticulos2 = nodos.nodoProveedorArticulos()
                    elmntRemisionArticulos2 = nodos.elementoRemisionArticulos(vArt.remision.Trim)
                    remisionArticulos2 = nodos.nodoRemisionArticulos()
                    elmntFolioArticulos2 = nodos.elementoFolioPedidoArt(vArt.FolioPedido.ToString.Trim)
                    folioArticulos2 = nodos.nodoFolioPedidoArticulo()
                    elmntTiendaArticulos2 = nodos.elementoTiendaArticulo(CmbtiendaP.SelectedValue)
                    tiendaArticulos2 = nodos.nodoTiendaArticulos()

                    elmntCodigoArticulos2 = nodos.elementoCodigoArt(vRow.Item("codigo").ToString.Trim)
                    codigoArticulos2 = nodos.nodoCodigoArticulo()
                    elmntCantUCArt2 = nodos.elementoCantUC(FormatNumber(vRow.Item("cantidad"), 2, TriState.False, TriState.False, TriState.False))
                    cantUCompraArt2 = nodos.nodoCantidadUCompra()
                    elmtnCostoNetoUCArt2 = nodos.elementoCostoNUC(FormatNumber(vRow.Item("precio") * vRow.Item("cantidad"), 2, TriState.False, TriState.False, TriState.False))
                    costoNetoUCompraArt2 = nodos.nodoCostoNetoUC()

                    elmntPorcenIEPSArt2 = nodos.elementoPorcentajeIEPS(vArt.PorcentajeIEPS)
                    porcenIEPSArt2 = nodos.nodoPorcentajeIEPS()
                    elmntPorcenIVAArt2 = nodos.elementoPorcentajeIVA(vArt.PorcentajeIVA)
                    porcentajeIVAArt2 = nodos.nodoPorcentajeIVA()
                End If
                If c = 3 Then
                    nodoRaiz_Articulos3 = nodos.nodoArticulos("Articulos" & c + 1, c + 1)
                    elmntProvArticulos3 = nodos.elementoProvArticulos(vArt.Proveedor)
                    proveedorArticulos3 = nodos.nodoProveedorArticulos()
                    elmntRemisionArticulos3 = nodos.elementoRemisionArticulos(vArt.remision)
                    remisionArticulos3 = nodos.nodoRemisionArticulos()
                    elmntFolioArticulos3 = nodos.elementoFolioPedidoArt(vArt.FolioPedido)
                    folioArticulos3 = nodos.nodoFolioPedidoArticulo()
                    elmntTiendaArticulos3 = nodos.elementoTiendaArticulo(CmbtiendaP.SelectedValue)
                    tiendaArticulos3 = nodos.nodoTiendaArticulos()
                    elmntCodigoArticulos3 = nodos.elementoCodigoArt(vRow.Item("codigo").ToString.Trim)
                    codigoArticulos3 = nodos.nodoCodigoArticulo()
                    elmntCantUCArt3 = nodos.elementoCantUC(FormatNumber(vRow.Item("cantidad"), 2, TriState.False, TriState.False, TriState.False))
                    cantUCompraArt3 = nodos.nodoCantidadUCompra()
                    elmtnCostoNetoUCArt3 = nodos.elementoCostoNUC(FormatNumber(vRow.Item("precio") * vRow.Item("cantidad"), 2, TriState.False, TriState.False, TriState.False))
                    costoNetoUCompraArt3 = nodos.nodoCostoNetoUC()

                    elmntPorcenIEPSArt3 = nodos.elementoPorcentajeIEPS(vArt.PorcentajeIEPS)
                    porcenIEPSArt3 = nodos.nodoPorcentajeIEPS()
                    elmntPorcenIVAArt3 = nodos.elementoPorcentajeIVA(vArt.PorcentajeIVA)
                    porcentajeIVAArt3 = nodos.nodoPorcentajeIVA()
                End If
                c = c + 1
            Next

            folioRemision.Elements.Add(elementoFolioRemision)
            proveedor.Elements.Add(elementoProveedor)
            nodeConsecutivo.Elements.Add(elementConsecutivo)
            nodeFechaRem.Elements.Add(elementFechaRem)
            nodeTienda.Elements.Add(elementTienda)
            tipoMoneda.Elements.Add(elmntTipoMoneda)
            tipoBulto.Elements.Add(elmntTipoBulto)
            entregaMerc.Elements.Add(elmntEntregaMerc)
            cumpleReqFiscales.Elements.Add(elmntCumpleRF)
            cantBultos.Elements.Add(elmntCantBultos)
            subtotal.Elements.Add(elmntSubtotal)
            descuentos.Elements.Add(elmntDescuentos)
            ieps.Elements.Add(elmntIeps)
            iva.Elements.Add(elmntIva)
            otrosImp.Elements.Add(elmntOtrosImp)
            total.Elements.Add(elmntTotal)
            cantidadPedidos.Elements.Add(elmntCantPedidos)
            FechaEntregaM.Elements.Add(elmntFechaEntregaM)
            'empaqueCajas.Elements.Add(elmntEmpaqueCajas);
            'empaqueTarimas.Elements.Add(elmntEmpaqueTarimas);
            'cantCajasTarimas.Elements.Add(elmntCantCajasTarimas);
            'cita.Elements.Add(elmntCita);
            provPedimento.Elements.Add(elmntProvPedimento)
            remisionPedimento.Elements.Add(elmntRemisionPedimento)
            numPedimento.Elements.Add(elmntNumPedimento)
            aduana.Elements.Add(elmntAduana)
            agenteAduanal.Elements.Add(elmntAgenteAduanal)
            tipoPedimento.Elements.Add(elmntTipoPedimento)
            fechaPedimento.Elements.Add(elmntFechaPedimento)
            fechaReciboL.Elements.Add(elmntFechaReciboL)
            fechaBillOL.Elements.Add(elmntFechaBill)
            proveedorPedidos.Elements.Add(elmntProvPedidos)
            remisionPedidos.Elements.Add(elmntRemisionPedidos)
            folioPedido.Elements.Add(elmntFolioPedido)
            tiendaPedidos.Elements.Add(elmntTiendaPedidos)
            cantArticuloPedidos.Elements.Add(elmntCantArtPedidos)
            proveedorArticulos.Elements.Add(elmntProvArticulos)
            remisionArticulos.Elements.Add(elmntRemisionArticulos)
            folioArticulos.Elements.Add(elmntFolioArticulos)
            tiendaArticulos.Elements.Add(elmntTiendaArticulos)
            codigoArticulos.Elements.Add(elmntCodigoArticulos)
            cantUCompraArt.Elements.Add(elmntCantUCArt)
            costoNetoUCompraArt.Elements.Add(elmtnCostoNetoUCArt)
            porcenIEPSArt.Elements.Add(elmntPorcenIEPSArt)
            porcentajeIVAArt.Elements.Add(elmntPorcenIVAArt)

            proveedorArticulos1.Elements.Add(elmntProvArticulos1)
            remisionArticulos1.Elements.Add(elmntRemisionArticulos)
            folioArticulos1.Elements.Add(elmntFolioArticulos)
            tiendaArticulos1.Elements.Add(elmntTiendaArticulos)
            codigoArticulos1.Elements.Add(elmntCodigoArticulos1)
            cantUCompraArt1.Elements.Add(elmntCantUCArt1)
            costoNetoUCompraArt1.Elements.Add(elmtnCostoNetoUCArt1)
            porcenIEPSArt1.Elements.Add(elmntPorcenIEPSArt1)
            porcentajeIVAArt1.Elements.Add(elmntPorcenIVAArt1)
            proveedorArticulos2.Elements.Add(elmntProvArticulos2)
            remisionArticulos2.Elements.Add(elmntRemisionArticulos)
            folioArticulos2.Elements.Add(elmntFolioArticulos)
            tiendaArticulos2.Elements.Add(elmntTiendaArticulos)
            codigoArticulos2.Elements.Add(elmntCodigoArticulos2)
            cantUCompraArt2.Elements.Add(elmntCantUCArt2)
            costoNetoUCompraArt2.Elements.Add(elmtnCostoNetoUCArt2)
            porcenIEPSArt2.Elements.Add(elmntPorcenIEPSArt2)
            porcentajeIVAArt2.Elements.Add(elmntPorcenIVAArt2)
            proveedorArticulos3.Elements.Add(elmntProvArticulos3)
            remisionArticulos3.Elements.Add(elmntRemisionArticulos)
            folioArticulos3.Elements.Add(elmntFolioArticulos)
            tiendaArticulos3.Elements.Add(elmntTiendaArticulos)
            codigoArticulos3.Elements.Add(elmntCodigoArticulos3)
            cantUCompraArt3.Elements.Add(elmntCantUCArt3)
            costoNetoUCompraArt3.Elements.Add(elmtnCostoNetoUCArt3)
            porcenIEPSArt3.Elements.Add(elmntPorcenIEPSArt3)
            porcentajeIVAArt3.Elements.Add(elmntPorcenIVAArt3)
            proveedorCajaTarima.Elements.Add(elmntProvCajaTarima)
            remisionCajaTarima.Elements.Add(elmntRemisionCajaTarima)
            numCajaTarima.Elements.Add(elmntNumCajaTarima)
            codBarrasCajaTarima.Elements.Add(elmntCodBarrasCajaTarima)
            sucDistrCajaTarima.Elements.Add(elmntSucDistrCajaTarima)
            cantArtCajaTarima.Elements.Add(elmntCantArtCajaTarima)
            proveedorArtCajaTarima.Elements.Add(elmntProvArtCajaTarima)
            remisionArtCajaTarima.Elements.Add(elmntremisionArtCajaTarima)
            folioPedidoArtCajaTarima.Elements.Add(elmntFolioPedidoArtCajaTarima)
            NumCTArtCajaTarima.Elements.Add(elmntNumCTArtCajaTarima)
            sucDistrArtCajaTarima.Elements.Add(elmntSucDistArtCajaTarima)
            codigoArtCajaTarima.Elements.Add(elmntCodigoArtCajaTarima)
            cantUndCompraArtCajaTarima.Elements.Add(elmntCantUndCArtCajaTarima)
            remision_Remision.Elements.Add(proveedor) '<Proveedor>
            remision_Remision.Elements.Add(folioRemision) '<Remision> Folio remision
            remision_Remision.Elements.Add(nodeConsecutivo) '<Consecutivo>
            remision_Remision.Elements.Add(nodeFechaRem) '<FechaRemision>
            remision_Remision.Elements.Add(nodeTienda) '<Tienda>
            remision_Remision.Elements.Add(tipoMoneda)
            remision_Remision.Elements.Add(tipoBulto)
            remision_Remision.Elements.Add(entregaMerc)
            remision_Remision.Elements.Add(cumpleReqFiscales)
            remision_Remision.Elements.Add(cantBultos)
            remision_Remision.Elements.Add(subtotal)
            remision_Remision.Elements.Add(descuentos)
            remision_Remision.Elements.Add(ieps)
            remision_Remision.Elements.Add(iva)
            remision_Remision.Elements.Add(otrosImp)
            remision_Remision.Elements.Add(total)
            remision_Remision.Elements.Add(cantidadPedidos)
            remision_Remision.Elements.Add(FechaEntregaM)
            'remision_Remision.Elements.Add(empaqueCajas)
            'remision_Remision.Elements.Add(empaqueTarimas)
            'remision_Remision.Elements.Add(cantCajasTarimas)
            'remision_Remision.Elements.Add(cita)
            pedimento.Elements.Add(provPedimento)
            pedimento.Elements.Add(remisionPedimento)
            pedimento.Elements.Add(numPedimento)
            pedimento.Elements.Add(aduana)
            pedimento.Elements.Add(agenteAduanal)
            pedimento.Elements.Add(tipoPedimento)
            pedimento.Elements.Add(fechaPedimento)
            pedimento.Elements.Add(fechaReciboL)
            pedimento.Elements.Add(fechaBillOL)
            nodoRaiz_Pedidos.Elements.Add(proveedorPedidos)
            nodoRaiz_Pedidos.Elements.Add(remisionPedidos)
            nodoRaiz_Pedidos.Elements.Add(folioPedido)
            nodoRaiz_Pedidos.Elements.Add(tiendaPedidos)
            nodoRaiz_Pedidos.Elements.Add(cantArticuloPedidos)
            nodoRaiz_Articulos.Elements.Add(proveedorArticulos)
            nodoRaiz_Articulos.Elements.Add(remisionArticulos)
            nodoRaiz_Articulos.Elements.Add(folioArticulos)
            nodoRaiz_Articulos.Elements.Add(tiendaArticulos)
            nodoRaiz_Articulos.Elements.Add(codigoArticulos)
            nodoRaiz_Articulos.Elements.Add(cantUCompraArt)
            nodoRaiz_Articulos.Elements.Add(costoNetoUCompraArt)
            nodoRaiz_Articulos.Elements.Add(porcenIEPSArt)
            nodoRaiz_Articulos.Elements.Add(porcentajeIVAArt)

            nodoRaiz_Articulos1.Elements.Add(proveedorArticulos1)
            nodoRaiz_Articulos1.Elements.Add(remisionArticulos)
            nodoRaiz_Articulos1.Elements.Add(folioArticulos)
            nodoRaiz_Articulos1.Elements.Add(tiendaArticulos)
            nodoRaiz_Articulos1.Elements.Add(codigoArticulos1)
            nodoRaiz_Articulos1.Elements.Add(cantUCompraArt1)
            nodoRaiz_Articulos1.Elements.Add(costoNetoUCompraArt1)
            nodoRaiz_Articulos1.Elements.Add(porcenIEPSArt1)
            nodoRaiz_Articulos1.Elements.Add(porcentajeIVAArt1)
            nodoRaiz_Articulos2.Elements.Add(proveedorArticulos2)
            nodoRaiz_Articulos2.Elements.Add(remisionArticulos)
            nodoRaiz_Articulos2.Elements.Add(folioArticulos)
            nodoRaiz_Articulos2.Elements.Add(tiendaArticulos)
            nodoRaiz_Articulos2.Elements.Add(codigoArticulos2)
            nodoRaiz_Articulos2.Elements.Add(cantUCompraArt2)
            nodoRaiz_Articulos2.Elements.Add(costoNetoUCompraArt2)
            nodoRaiz_Articulos2.Elements.Add(porcenIEPSArt2)
            nodoRaiz_Articulos2.Elements.Add(porcentajeIVAArt2)
            nodoRaiz_Articulos3.Elements.Add(proveedorArticulos3)
            nodoRaiz_Articulos3.Elements.Add(remisionArticulos)
            nodoRaiz_Articulos3.Elements.Add(folioArticulos)
            nodoRaiz_Articulos3.Elements.Add(tiendaArticulos)
            nodoRaiz_Articulos3.Elements.Add(codigoArticulos3)
            nodoRaiz_Articulos3.Elements.Add(cantUCompraArt3)
            nodoRaiz_Articulos3.Elements.Add(costoNetoUCompraArt3)
            nodoRaiz_Articulos3.Elements.Add(porcenIEPSArt3)
            nodoRaiz_Articulos3.Elements.Add(porcentajeIVAArt3)
            'nodoRaiz_CajaTarima.Elements.Add(proveedorCajaTarima)
            'nodoRaiz_CajaTarima.Elements.Add(remisionCajaTarima)
            'nodoRaiz_CajaTarima.Elements.Add(numCajaTarima)
            'nodoRaiz_CajaTarima.Elements.Add(codBarrasCajaTarima)
            'nodoRaiz_CajaTarima.Elements.Add(sucDistrCajaTarima)
            'nodoRaiz_CajaTarima.Elements.Add(cantArtCajaTarima)
            'nodoRaiz_ArtPorCajaTarima.Elements.Add(proveedorArtCajaTarima)
            'nodoRaiz_ArtPorCajaTarima.Elements.Add(remisionArtCajaTarima)
            'nodoRaiz_ArtPorCajaTarima.Elements.Add(folioPedidoArtCajaTarima)
            'nodoRaiz_ArtPorCajaTarima.Elements.Add(NumCTArtCajaTarima)
            'nodoRaiz_ArtPorCajaTarima.Elements.Add(sucDistrArtCajaTarima)
            'nodoRaiz_ArtPorCajaTarima.Elements.Add(codigoArtCajaTarima)
            'nodoRaiz_ArtPorCajaTarima.Elements.Add(cantUndCompraArtCajaTarima)

            DSCarga.Elements.Add(remision_Remision)
            'DSCarga.Elements.Add(pedimento) ' no se necesita
            DSCarga.Elements.Add(nodoRaiz_Pedidos)

            For c = 0 To grdProductos.RecordCount - 1
                If c = 0 Then
                    DSCarga.Elements.Add(nodoRaiz_Articulos) '<Articulos> Bloque Articulos
                End If
                If c = 1 Then
                    DSCarga.Elements.Add(nodoRaiz_Articulos1) '<Articulos> Bloque Articulos
                End If
                If c = 2 Then
                    DSCarga.Elements.Add(nodoRaiz_Articulos2) '<Articulos> Bloque Articulos
                End If
                If c = 3 Then
                    DSCarga.Elements.Add(nodoRaiz_Articulos3) '<Articulos> Bloque Articulos
                End If
            Next


            'DSCarga.Elements.Add(nodoRaiz_CajaTarima)
            'DSCarga.Elements.Add(nodoRaiz_ArtPorCajaTarima)

            addenda.Elements.Add(DSCarga) '<DSCarga>

            If proceso.setAddendaInXMLCFDI(archivoXML, addenda) Then
                MessageBox.Show("Addenda generada correctamente.")
                Close()
                Return True

            Else
                MessageBox.Show("No se pudo generar la Addenda.")
                Return False

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False

        End Try

    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        pathfilexml = "c:\correo\" & Me.txtRFC.Text & "_" & Me.txtFolio.Text & ".xml"
        ' xml
        Dim mifecha As DateTime = Me.dpFecha.Value
        Dim fechaEM As DateTime = Me.fFechaEntregaM.Value

        Dim vFile As New IO.StreamWriter(pathfilexml)
        Dim vXml As String = cFacturas.GetFacturaXML(facturasel)
        vFile.Write(vXml)
        vFile.Flush()
        vFile.Close()
        vAddSorRemi.Proveedor = CInt(Me.TxtProveedor.Text)
        vAddSorRemi.remision = Me.Txtremision.Text
        vAddSorRemi.Consecutivo = Me.Txtconsecutivo.Text
        vAddSorRemi.FechaRemision = mifecha.ToString("s")

        vAddSorRemi.Tienda = Me.cmbtienda.SelectedValue
        vAddSorRemi.TipoMoneda = Me.cmbMoneda.Text
        vAddSorRemi.TipoBulto = Me.Txttipobulto.Text
        vAddSorRemi.EntregaMercancia = Me.CmbEntregaM.SelectedValue
        vAddSorRemi.CumpleReqFiscales = Me.Cmbcumple.Text
        vAddSorRemi.CantidadBultos = Me.Txtcantidadbultos.Text
        vAddSorRemi.Subtotal = Me.txtSubTotal.Text
        vAddSorRemi.IEPS = Me.iieps.Text
        vAddSorRemi.IVA = Me.txtIVA.Text
        vAddSorRemi.descuento = Me.Txtdescuento.Text
        vAddSorRemi.OtrosImpuestos = Me.otrosi.Text
        vAddSorRemi.Total = Me.txtTotal.Text
        vAddSorRemi.CantidadPedidos = Me.Txtcantidadpedidos.Text
        vAddSorRemi.FechaEntregaMercancia = fechaEM.ToString("s")
        vAddSorRemi.FolioNotaEntrada = Me.FolioNotaEntrada.Text

        '-------------pedidos
        vAddSorpedido.Proveedor = CInt(Me.TxtProveedor.Text)
        vAddSorpedido.remision = Me.Txtremision.Text
        vAddSorpedido.FolioPedido = Me.Txtfoliopedido.Text
        vAddSorpedido.Tienda = Me.CmbtiendaP.SelectedValue
        vAddSorpedido.CantidadArticulos = Me.TxtCantidadArticulos.Text
        vAddSorpedido.PedidoEmitidoProveedor = Me.CmbPedidoEmitidoProveedor.Text
        '****vAddSorArticulos*************
        vAddSorArticulos.Proveedor = CInt(Me.TxtProveedor.Text)

        Dim vRow As DataRow
        Dim VvFacs As New cFacturas
        For Each vRow In vTablaProds.Rows
            vAddSorArticulos.remision = Me.Txtremision.Text
            vAddSorArticulos.FolioPedido = Me.Txtfoliopedido.Text
            vAddSorArticulos.Tienda = Me.CmbtiendaP.SelectedValue
            vAddSorArticulos.CantidadArticulos = vRow.Item("cantidad")
            vAddSorArticulos.Codigo = vRow.Item("codigo")
            vAddSorArticulos.CantidadUnidadCompra = FormatNumber(vRow.Item("cantidad"), 2, TriState.False, TriState.False, TriState.False)
            vAddSorArticulos.CostoNetoUnidadCompra = FormatNumber(vRow.Item("precio") * vRow.Item("cantidad"), 2, TriState.False, TriState.False, TriState.False)
            vAddSorArticulos.PorcentajeIEPS = 0.0
            vAddSorArticulos.PorcentajeIVA = 0.0
        Next
        insertarAddenda(pathfilexml)
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        pathfilexml = "c:\correo\" & Me.txtRFC.Text & "_" & Me.txtFolio.Text & ".xml"
        ' xml
        Dim vFile As New IO.StreamWriter(pathfilexml)
        Dim vXml As String = cFacturas.GetFacturaXML(facturasel)
        vFile.Write(vXml)
        vFile.Flush()
        vFile.Close()

        Dim mifecha As DateTime = Me.dpFecha.Value
        Dim fechaEM As DateTime = Me.fFechaEntregaM.Value


        vAddSorRemi.Proveedor = CInt(Me.TxtProveedor.Text)
        vAddSorRemi.remision = Me.Txtremision.Text
        vAddSorRemi.Consecutivo = Me.Txtconsecutivo.Text
        vAddSorRemi.FechaRemision = mifecha.ToString("s")

        vAddSorRemi.Tienda = Me.cmbtienda.SelectedValue
        vAddSorRemi.TipoMoneda = Me.cmbMoneda.Text
        vAddSorRemi.TipoBulto = Me.Txttipobulto.Text
        vAddSorRemi.EntregaMercancia = Me.CmbEntregaM.SelectedValue
        vAddSorRemi.CumpleReqFiscales = Me.Cmbcumple.Text
        vAddSorRemi.CantidadBultos = Me.Txtcantidadbultos.Text
        vAddSorRemi.Subtotal = Me.txtSubTotal.Text
        vAddSorRemi.IEPS = Me.iieps.Text
        vAddSorRemi.IVA = Me.txtIVA.Text
        vAddSorRemi.OtrosImpuestos = Me.otrosi.Text
        vAddSorRemi.Total = Me.txtTotal.Text
        vAddSorRemi.CantidadPedidos = Me.Txtcantidadpedidos.Text
        vAddSorRemi.FechaEntregaMercancia = fechaEM.ToString("s")
        vAddSorRemi.FolioNotaEntrada = Me.FolioNotaEntrada.Text
        '-------------pedidos
        vAddSorpedido.Proveedor = CInt(Me.TxtProveedor.Text)
        vAddSorpedido.remision = Me.Txtremision.Text
        vAddSorpedido.FolioPedido = Me.Txtfoliopedido.Text
        vAddSorpedido.Tienda = Me.CmbtiendaP.SelectedValue
        vAddSorpedido.CantidadArticulos = Me.TxtCantidadArticulos.Text
        vAddSorpedido.PedidoEmitidoProveedor = Me.CmbPedidoEmitidoProveedor.Text
        '****vAddSorArticulos*************
        vAddSorArticulos.Proveedor = CInt(Me.TxtProveedor.Text)

        'Dim n As Integer
        'For n = 0 To Me.grdProductos.RecordCount - 1
        '    vAddSorArticulos.remision = Me.Txtremision.Text
        '    vAddSorArticulos.FolioPedido = Me.Txtfoliopedido.Text
        '    vAddSorArticulos.Tienda = Me.CmbtiendaP.SelectedValue
        '    vAddSorArticulos.CantidadArticulos = 10
        '    vAddSorArticulos.Codigo = "3200111"
        '    vAddSorArticulos.CantidadUnidadCompra = 10.0
        '    vAddSorArticulos.CostoNetoUnidadCompra = 600.0
        '    vAddSorArticulos.PorcentajeIEPS = 0.0
        '    vAddSorArticulos.PorcentajeIVA = 0.0
        'Next

        Dim vRow As DataRow
        Dim VvFacs As New cFacturas
        For Each vRow In vTablaProds.Rows
            vAddSorArticulos.remision = Me.Txtremision.Text
            vAddSorArticulos.FolioPedido = Me.Txtfoliopedido.Text
            vAddSorArticulos.Tienda = Me.CmbtiendaP.SelectedValue
            vAddSorArticulos.CantidadArticulos = vRow.Item("cantidad")
            vAddSorArticulos.Codigo = vRow.Item("codigo")
            vAddSorArticulos.CantidadUnidadCompra = FormatNumber(vRow.Item("cantidad"), 2, TriState.False, TriState.False, TriState.False)
            vAddSorArticulos.CostoNetoUnidadCompra = FormatNumber(vRow.Item("precio") * vRow.Item("cantidad"), 2, TriState.False, TriState.False, TriState.False)
            vAddSorArticulos.PorcentajeIEPS = 0.0
            vAddSorArticulos.PorcentajeIVA = 0.0
        Next

        leexml()
        MsgBox("Addenda Adicionada")
    End Sub
    Private Sub leexml()
        xd = New XmlDocument
        xd.Load(pathfilexml)

        Dim vFac As dAddendaSorianaremision = vAddSorRemi
        'vFac = New dAddendaSorianaremision

        Dim vpedi As dAddendaSorianapedidos = vAddSorpedido
        'vpedi = New dAddendaSorianapedidos

        Dim vArt As dAddendaSorianaArticulos = vAddSorArticulos
        'vArt = New dAddendaSorianaArticulos



        Dim newAuthor As XmlElement = xd.CreateElement("Addenda")
        'newAuthor.SetAttribute("code", "6")
        Dim DSCargaRemisionProv As XmlElement = xd.CreateElement("DSCargaRemisionProv")
        'fn.InnerText = "Bikram"
        newAuthor.AppendChild(DSCargaRemisionProv)

        Dim Remision As XmlElement = xd.CreateElement("Remision")
        Remision.SetAttribute("RowOrder", 1)
        Remision.SetAttribute("Id", "Remision1")
        'ln.InnerText = "Seth"

        DSCargaRemisionProv.AppendChild(Remision)

        Dim pedidos As XmlElement = xd.CreateElement("pedidos")
        'ln.InnerText = "Seth"
        pedidos.SetAttribute("RowOrder", 1)
        pedidos.SetAttribute("Id", "Pedidos1")
        DSCargaRemisionProv.AppendChild(pedidos)

        Dim Articulos As XmlElement = xd.CreateElement("Articulos")
        ''aln1.InnerText = "Seth"
        DSCargaRemisionProv.AppendChild(Articulos)

        '----------------------------------------------
        Dim proveedor As XmlElement = xd.CreateElement("proveedor")
        Remision.AppendChild(proveedor)
        proveedor.InnerText = vFac.Proveedor
        IndentarNodo(proveedor, 2)

        Dim Remi As XmlElement = xd.CreateElement("Remision")
        Remision.AppendChild(Remi)
        Remi.InnerText = vFac.remision
        IndentarNodo(Remi, 2)

        Dim Consecutivo As XmlElement = xd.CreateElement("Consecutivo")
        Remision.AppendChild(Consecutivo)
        Consecutivo.InnerText = vFac.Consecutivo
        IndentarNodo(Consecutivo, 2)

        Dim FechaRemision As XmlElement = xd.CreateElement("FechaRemision")
        Remision.AppendChild(FechaRemision)
        FechaRemision.InnerText = vFac.FechaRemision
        IndentarNodo(FechaRemision, 2)

        Dim Tienda As XmlElement = xd.CreateElement("Tienda")
        Remision.AppendChild(Tienda)
        Tienda.InnerText = vFac.Tienda
        IndentarNodo(Tienda, 2)

        Dim TipoMoneda As XmlElement = xd.CreateElement("TipoMoneda")
        Remision.AppendChild(TipoMoneda)
        If vFac.TipoMoneda = "PESOS" Then
            TipoMoneda.InnerText = 1
        Else
            TipoMoneda.InnerText = 2
        End If

        IndentarNodo(TipoMoneda, 2)

        Dim TipoBulto As XmlElement = xd.CreateElement("TipoBulto")
        Remision.AppendChild(TipoBulto)
        TipoBulto.InnerText = vFac.TipoBulto
        IndentarNodo(TipoBulto, 2)


        Dim EntregaMercancia As XmlElement = xd.CreateElement("EntregaMercancia")
        Remision.AppendChild(EntregaMercancia)
        EntregaMercancia.InnerText = vFac.EntregaMercancia
        IndentarNodo(EntregaMercancia, 2)

        Dim CumpleReqFiscales As XmlElement = xd.CreateElement("CumpleReqFiscales")
        Remision.AppendChild(CumpleReqFiscales)
        CumpleReqFiscales.InnerText = vFac.CumpleReqFiscales
        IndentarNodo(CumpleReqFiscales, 2)

        Dim CantidadBultos As XmlElement = xd.CreateElement("CantidadBultos")
        Remision.AppendChild(CantidadBultos)
        CantidadBultos.InnerText = vFac.CantidadBultos
        IndentarNodo(CantidadBultos, 2)

        Dim Subtotal As XmlElement = xd.CreateElement("Subtotal")
        Remision.AppendChild(Subtotal)
        Subtotal.InnerText = vFac.Subtotal
        IndentarNodo(Subtotal, 2)

        Dim IEPS As XmlElement = xd.CreateElement("IEPS")
        Remision.AppendChild(IEPS)
        IEPS.InnerText = vFac.IEPS
        IndentarNodo(IEPS, 2)


        Dim IVA As XmlElement = xd.CreateElement("IVA")
        Remision.AppendChild(IVA)
        IVA.InnerText = vFac.IVA
        IndentarNodo(IVA, 2)

        Dim OtrosImpuestos As XmlElement = xd.CreateElement("OtrosImpuestos")
        Remision.AppendChild(OtrosImpuestos)
        OtrosImpuestos.InnerText = vFac.OtrosImpuestos
        IndentarNodo(OtrosImpuestos, 2)

        Dim Total As XmlElement = xd.CreateElement("Total")
        Remision.AppendChild(Total)
        Total.InnerText = vFac.Total
        IndentarNodo(Total, 2)

        Dim CantidadPedidos As XmlElement = xd.CreateElement("CantidadPedidos")
        Remision.AppendChild(CantidadPedidos)
        CantidadPedidos.InnerText = vFac.CantidadPedidos
        IndentarNodo(CantidadPedidos, 2)

        Dim FechaEntregaMercancia As XmlElement = xd.CreateElement("FechaEntregaMercancia")
        Remision.AppendChild(FechaEntregaMercancia)
        FechaEntregaMercancia.InnerText = vFac.FechaEntregaMercancia
        IndentarNodo(FechaEntregaMercancia, 2)

        Dim FolioNotaEntrada As XmlElement = xd.CreateElement("FolioNotaEntrada")
        Remision.AppendChild(FolioNotaEntrada)
        FolioNotaEntrada.InnerText = vFac.FolioNotaEntrada
        IndentarNodo(FolioNotaEntrada, 2)


        '-----------------------------------------------------
        Dim provped As XmlElement = xd.CreateElement("Proveedor")
        provped.InnerText = vpedi.Proveedor
        pedidos.AppendChild(provped)
        IndentarNodo(provped, 2)

        Dim RemisionP As XmlElement = xd.CreateElement("Remision")
        RemisionP.InnerText = vpedi.remision
        pedidos.AppendChild(RemisionP)
        IndentarNodo(RemisionP, 2)

        Dim FolioPedido As XmlElement = xd.CreateElement("FolioPedido")
        FolioPedido.InnerText = vpedi.FolioPedido
        pedidos.AppendChild(FolioPedido)
        IndentarNodo(FolioPedido, 2)

        Dim PedidoEmitidoProveedor As XmlElement = xd.CreateElement("PedidoEmitidoProveedor")
        PedidoEmitidoProveedor.InnerText = vpedi.PedidoEmitidoProveedor
        pedidos.AppendChild(PedidoEmitidoProveedor)
        IndentarNodo(PedidoEmitidoProveedor, 2)

        Dim TiendaP As XmlElement = xd.CreateElement("tienda")
        TiendaP.InnerText = vpedi.Tienda
        pedidos.AppendChild(TiendaP)
        IndentarNodo(TiendaP, 2)
        '************************************************
        Dim c As Integer
        For c = 0 To grdProductos.RecordCount - 1
            Dim concepto As XmlElement = xd.CreateElement("Articulos")
            concepto.SetAttribute("RowOrder", c + 1)
            concepto.SetAttribute("Id", "Articulos" & c + 1)
            IndentarNodo(concepto, 2)

            Dim proveArt As XmlElement = xd.CreateElement("Proveedor")
            proveArt.InnerText = vArt.Proveedor
            concepto.AppendChild(proveArt)
            IndentarNodo(proveArt, 2)

            Dim RegimenFiscal As XmlElement = xd.CreateElement("Remision")
            RegimenFiscal.InnerText = vArt.remision
            concepto.AppendChild(RegimenFiscal)
            IndentarNodo(RegimenFiscal, 2)

            Dim FolioPedidoA As XmlElement = xd.CreateElement("FolioPedido")
            FolioPedidoA.InnerText = vArt.FolioPedido
            concepto.AppendChild(FolioPedidoA)
            IndentarNodo(FolioPedidoA, 2)

            Dim TiendaA As XmlElement = xd.CreateElement("tienda")
            TiendaA.InnerText = vArt.Tienda
            concepto.AppendChild(TiendaA)
            IndentarNodo(TiendaA, 2)

            Dim CantidadArticulos As XmlElement = xd.CreateElement("CantidadArticulos")
            CantidadArticulos.InnerText = vArt.CantidadArticulos
            concepto.AppendChild(CantidadArticulos)
            IndentarNodo(CantidadArticulos, 2)

            Dim Codigo = xd.CreateElement("Codigo")
            Codigo.InnerText = vArt.Codigo
            concepto.AppendChild(Codigo)
            IndentarNodo(Codigo, 2)

            Dim CantidadUnidadCompra As XmlElement = xd.CreateElement("CantidadUnidadCompra")
            CantidadUnidadCompra.InnerText = vArt.CantidadUnidadCompra
            concepto.AppendChild(CantidadUnidadCompra)
            IndentarNodo(CantidadUnidadCompra, 2)

            Dim CostoNetoUnidadCompra As XmlElement = xd.CreateElement("CostoNetoUnidadCompra")
            CostoNetoUnidadCompra.InnerText = vArt.CostoNetoUnidadCompra
            concepto.AppendChild(CostoNetoUnidadCompra)
            IndentarNodo(CostoNetoUnidadCompra, 2)

            Dim PorcentajeIEPS As XmlElement = xd.CreateElement("PorcentajeIEPS")
            PorcentajeIEPS.InnerText = vArt.PorcentajeIEPS
            concepto.AppendChild(PorcentajeIEPS)
            IndentarNodo(PorcentajeIEPS, 2)

            Dim PorcentajeIVA As XmlElement = xd.CreateElement("PorcentajeIVA")
            PorcentajeIVA.InnerText = vArt.PorcentajeIVA
            concepto.AppendChild(PorcentajeIVA)
            IndentarNodo(PorcentajeIVA, 2)

            Articulos.AppendChild(concepto)
        Next c
        '************************************************
        xd.DocumentElement.AppendChild(newAuthor)
        Dim fileXmlOut As String = "c:\correo\" & Me.txtRFC.Text & "_" & Me.txtFolio.Text & "AddSor.xml"
        Dim tr As XmlTextWriter = New XmlTextWriter(fileXmlOut, Nothing)
        tr.Formatting = Formatting.Indented
        xd.WriteContentTo(tr)
        tr.Close()

    End Sub
    Private Sub IndentarNodo(ByVal Nodo As XmlNode, ByVal Nivel As Long)
        Nodo.AppendChild(xd.CreateTextNode(vbNewLine & New String(ControlChars.Tab, Nivel)))
    End Sub
    Private Function CrearNodo(ByVal Nombre As String) As XmlNode
        CrearNodo = xd.CreateNode(XmlNodeType.Element, Nombre, Nothing)
        'CrearNodo = m_xmlDOM.CreateNode(XmlNodeType.Element, Nombre, Nothing)
    End Function
    Private Sub cmbtienda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtienda.SelectedIndexChanged
        CmbEntregaM.Text = cmbtienda.Text
        CmbtiendaP.Text = cmbtienda.Text
    End Sub


    Private Sub campoRowOrder_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles campoRowOrder.TextChanged

    End Sub
End Class

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
    Dim jcxmlelement As XmlElement
    '---------------------------------
    Dim ruta As String = ""
    
    
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

        'Dim rutapdf As String = Application.StartupPath & "\CFDI\"
        'Dim xml_timbrado As String = rutapdf & "AAA010101AAA" & "-" & vFac.Folio & ".xml"

        'Dim docXmlFile As XmlDocument = New XmlDocument()
        'docXmlFile.Load(xml_timbrado)
        'docXmlFile.Save(Console.Out)

        'vFac.xml_Timbrado = docXmlFile.InnerXml
        'Me.TxtXml.Text = docXmlFile.InnerXml
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
    Private Sub leerxml(ByVal vfolio As Integer)
        Dim rutapdf As String = Application.StartupPath & "\CFDI\"
        Dim xml_timbrado As String = rutapdf & "AAA010101AAA" & "-" & vfolio & ".xml"
        Dim reader As XmlTextReader = New XmlTextReader(xml_timbrado)
        Dim cabeza As String
        Try
            Do While (reader.Read())
                Select Case reader.NodeType
                    Case XmlNodeType.Element 'Mostrar comienzo del elemento.
                        cabeza = reader.Name
                        If reader.HasAttributes Then 'If attributes exist
                            While reader.MoveToNextAttribute()
                                If reader.Name = "rfc" And cabeza = "cfdi:Emisor" Then
                                    'Me.TextBox22.Text = reader.Value
                                End If
                                If reader.Name = "nombre" And cabeza = "cfdi:Emisor" Then
                                    'Me.nombre.Text = reader.Value
                                End If
                                If reader.Name = "folio" And cabeza = "cfdi:Comprobante" Then
                                    'Me.folio.Text = reader.Value
                                End If
                                If reader.Name = "total" And cabeza = "cfdi:Comprobante" Then
                                    'Me.total.Text = reader.Value
                                End If
                                If reader.Name = "metodoDePago" And cabeza = "cfdi:Comprobante" Then
                                    'Me.MetodoDePago.Text = reader.Value
                                End If
                                If reader.Name = "fecha" And cabeza = "cfdi:Comprobante" Then
                                    'Me.fecha.Text = reader.Value
                                End If
                                '-------------------------
                                If reader.Name = "rfc" And cabeza = "cfdi:Receptor" Then
                                    'Me.rfcR.Text = reader.Value
                                End If
                                If reader.Name = "nombre" And cabeza = "cfdi:Receptor" Then
                                    'Me.NombreR.Text = reader.Value
                                End If
                                If reader.Name = "UUID" And cabeza = "tfd:TimbreFiscalDigital" Then
                                    'Me.uuuid.Text = reader.Value
                                End If
                                If reader.Name = "noCertificadoSAT" And cabeza = "tfd:TimbreFiscalDigital" Then
                                    Me.txtCertificadoSAT.Text = reader.Value
                                End If
                                If reader.Name = "selloSAT" And cabeza = "tfd:TimbreFiscalDigital" Then
                                    Me.txtSelloSAT.Text = reader.Value
                                End If
                                If reader.Name = "selloCFD" And cabeza = "tfd:TimbreFiscalDigital" Then
                                    Me.txtSelloEmisor.Text = reader.Value
                                End If
                                If reader.Name = "FechaTimbrado" And cabeza = "tfd:TimbreFiscalDigital" Then
                                    Me.txtFecha_Cer.Text = reader.Value
                                End If
                                If reader.Name = "CertificadoSat" And cabeza = "tfd:TimbreFiscalDigital" Then
                                    Me.txtCertificadoSAT.Text = reader.Value
                                End If


                            End While
                        End If


                    Case XmlNodeType.Text 'Mostrar el texto de cada elemento.
                        ' TextBox1.Text += reader.Value + vbCrLf

                    Case XmlNodeType.EndElement 'Mostrar final del elemento.
                        '                    

                End Select
            Loop
            Console.ReadLine()
        Catch oe As Exception
            'MsgBox(oe.Message, MsgBoxStyle.Critical)
        End Try
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
        'insertarAddenda(pathfilexml)
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ' grabamos el archivo xml en disco 
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
        subAgregaR1()

        xd.DocumentElement.AppendChild(newAuthor)
        jcxmlelement = newAuthor
        'Dim fileXmlOut As String = "c:\correo\" & Me.txtRFC.Text & "_" & Me.txtFolio.Text & "Add1.xml"
        'xd.PreserveWhitespace = True
        'Dim tr As XmlTextWriter = New XmlTextWriter(fileXmlOut, System.Text.Encoding.UTF8)
        'tr.Formatting = Formatting.Indented
        'xd.WriteContentTo(tr)
        'tr.Close()
        'xd.Save(Console.Out)


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

    Public Sub subAgregaR1()
        Dim vRow As DataRow
        Try
            'Declaro variable array para el Array
            Dim objAddendas As New ArrayList
            Dim oAddenda As New stcAP1
            Dim oPedidos As New dAddendaSorianapedidos
            Dim oArticulos As New dAddendaSorianaArticulos

            'Dim oAddenda2 As New stcAddenda2

            'Variable para el Archivo Xlml
            Dim A As XmlTextWriter = New XmlTextWriter("C:\correo\Addenda.xml", System.Text.UTF8Encoding.UTF8)

            'PARA RECEPCION 1
            'PAR oAddenda.contrato = CInt(txtcontrato.Text)
            oAddenda.surtimiento = "4560000"
            oAddenda.gestor = 456456
            oAddenda.pocision = "59675708"
            oAddenda.entrada = "59675708"
            oAddenda.ejecutor = "59675708"
            oAddenda.receptor = "59675708"
            oAddenda.ejercicio = "59675708"
            oAddenda.Proveedor = 303008
            oAddenda.remision = "100"

            oPedidos.Proveedor = "3033008"
            oPedidos.remision = "100"



            'Agrego a la Colección
            objAddendas.Add(oAddenda)

            'Formatea indentado el archivo
            A.Formatting = System.Xml.Formatting.Indented

            'Si escribe la inicializacion del Archivo
            A.WriteStartDocument(True)
            'Crear el elemento principal del documento
            A.WriteStartElement("Addenda") '                                         1
            'A.WriteAttributeString("tipo", "version")
            'Ciclo para incluir los elementos de la colección
            For Each oNodoAddenda As stcAP1 In objAddendas
                'Escribe el Titulo
                A.WriteStartAttribute("xsi:schemaLocation")
                A.WriteValue("http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv32.xsd")
                A.WriteEndAttribute() 'TERMINA ATRIBUTO

                'Escribe el Titulo
                A.WriteStartAttribute("xmlns:cfdi")
                A.WriteValue("http://www.sat.gob.mx/cfd/3")
                A.WriteEndAttribute() 'TERMINA ATRIBUTO

                ''Escribe el Titulo
                A.WriteStartAttribute("xmlns:xsi")
                A.WriteValue("http://www.w3.org/2001/XMLSchema-instance")
                A.WriteEndAttribute() 'TERMINA ATRIBUTO

                ''Escribe el Titulo
                'A.WriteStartAttribute("version")
                'A.WriteValue("3.2")
                'A.WriteEndAttribute() 'TERMINA ATRIBUTO

                '************************************************
                '               INICIA ELEMENTO CFDI:ADDENDA SAT

                '*************************************************
                'Crear un elemento llamado 'Nodo Principal Addenda' con un nodo de texto
                A.WriteStartElement("cfdi:Addenda") '                                                2

                'Escribe el Titulo
                'A.WriteStartAttribute("xmlns:cfdi")
                'A.WriteValue("http://www.sat.gob.mx/cfd/3")
                'A.WriteEndAttribute() 'TERMINA ATRIBUTO

                '*************************************************
                'Crear un elemento llamado 'Nodo Principal Addenda' con un nodo de texto
                A.WriteStartElement("DSCargaRemisionProv") '                                            3

                A.WriteStartElement("Remision") '                                          4

                A.WriteStartAttribute("Id")
                A.WriteValue("Remision1")
                A.WriteEndAttribute() 'TERMINA ATRIBUTO Id

                A.WriteStartAttribute("RowOrder")
                A.WriteValue("1")
                A.WriteEndAttribute() 'TERMINA ATRIBUTO RowOrder
               
                A.WriteStartElement("Proveedor")
                A.WriteValue(vAddSorRemi.Proveedor)
                A.WriteEndElement()  'FIN DE NODO PROVEEDOR

                A.WriteStartElement("Remision")
                A.WriteValue(vAddSorRemi.remision)
                A.WriteEndElement()  'FIN DE NODO remision

                A.WriteStartElement("Consecutivo")
                A.WriteValue(vAddSorRemi.Consecutivo)
                A.WriteEndElement()  'FIN DE NODO ("Consecutivo")

                A.WriteStartElement("FechaRemision")
                A.WriteValue(vAddSorRemi.FechaRemision)
                A.WriteEndElement()  'FIN DE NODO FechaRemision

                A.WriteStartElement("Tienda")
                A.WriteValue(vAddSorRemi.Tienda)
                A.WriteEndElement()  'FIN DE NODO Tienda

                A.WriteStartElement("TipoMoneda")
                If vAddSorRemi.TipoMoneda = "PESOS" Then
                    A.WriteValue(1)
                Else
                    A.WriteValue(2)
                End If
                A.WriteEndElement()  'FIN DE NODO TipoMoneda

                A.WriteStartElement("TipoBulto")
                A.WriteValue(vAddSorRemi.TipoBulto)
                A.WriteEndElement()  'FIN DE NODO TipoBulto

                A.WriteStartElement("EntregaMercancia")
                A.WriteValue(vAddSorRemi.EntregaMercancia)
                A.WriteEndElement()  'FIN DE NODO EntregaMercancia

                A.WriteStartElement("CumpleReqFiscales")
                A.WriteValue(vAddSorRemi.CumpleReqFiscales)
                A.WriteEndElement()  'FIN DE NODO CumpleReqFiscales

                A.WriteStartElement("CantidadBultos")
                A.WriteValue(vAddSorRemi.CantidadBultos)
                A.WriteEndElement()  'FIN DE NODO CantidadBultos

                A.WriteStartElement("Subtotal")
                A.WriteValue(vAddSorRemi.Subtotal)
                A.WriteEndElement()  'FIN DE NODO Subtotal

                A.WriteStartElement("IEPS")
                A.WriteValue(vAddSorRemi.IEPS)
                A.WriteEndElement()  'FIN DE NODO IEPS
                A.WriteStartElement("IVA")
                A.WriteValue(vAddSorRemi.IVA)
                A.WriteEndElement()  'FIN DE NODO IVA
                A.WriteStartElement("OtrosImpuestos")
                A.WriteValue(vAddSorRemi.OtrosImpuestos)
                A.WriteEndElement()  'FIN DE NODO OtrosImpuestos


                A.WriteStartElement("Total")
                A.WriteValue(vAddSorRemi.Total)
                A.WriteEndElement()  'FIN DE NODO Total

                A.WriteStartElement("CantidadPedidos")
                A.WriteValue(vAddSorRemi.CantidadPedidos)
                A.WriteEndElement()  'FIN DE NODO CantidadPedidos

                A.WriteStartElement("FechaEntregaMercancia")
                A.WriteValue(vAddSorRemi.FechaEntregaMercancia)
                A.WriteEndElement()  'FIN DE NODO FechaEntregaMercancia

                A.WriteStartElement("FolioNotaEntrada")
                A.WriteValue(vAddSorRemi.FolioNotaEntrada)
                A.WriteEndElement()  'FIN DE NODO FolioNotaEntrada

                A.WriteEndElement()  'FIN DE NODO MASTER remision                         cierro 4   


                A.WriteStartElement("Pedidos") '                                       abro pedidos  5

                A.WriteStartAttribute("Id")
                A.WriteValue("Pedidos1")
                A.WriteEndAttribute() 'TERMINA ATRIBUTO Id

                A.WriteStartAttribute("RowOrder")
                A.WriteValue("1")
                A.WriteEndAttribute() 'TERMINA ATRIBUTO RowOrder
              
                A.WriteStartElement("Proveedor")
                A.WriteValue(vAddSorpedido.Proveedor)
                A.WriteEndElement()  'FIN DE NODO PROVEEDOR

                A.WriteStartElement("Remision")
                A.WriteValue(vAddSorpedido.remision)
                A.WriteEndElement()  'FIN DE NODO remision

                A.WriteStartElement("FolioPedido")
                A.WriteValue(vAddSorpedido.FolioPedido)
                A.WriteEndElement()  'FIN DE NODO FolioPedido

                A.WriteStartElement("PedidoEmitidoProveedor")
                A.WriteValue(vAddSorpedido.PedidoEmitidoProveedor)
                A.WriteEndElement()  'FIN DE NODO PedidoEmitidoProveedor

                A.WriteStartElement("Tienda")
                A.WriteValue(vAddSorpedido.Tienda)
                A.WriteEndElement()  'FIN DE NODO tienda

                A.WriteEndElement()  'FIN DE NODO pedidos                                cierro pedidos 5


                'A.WriteStartElement("Articulos") '                                        abro articulos  6

                ''Escribe el Titulo
                'A.WriteStartAttribute("Id")
                'A.WriteValue("Articulos1")
                'A.WriteEndAttribute() 'TERMINA ATRIBUTO Id

                'A.WriteStartAttribute("RowOrder")
                'A.WriteValue("1")
                'A.WriteEndAttribute() 'TERMINA ATRIBUTO RowOrder


                'A.WriteStartElement("Proveedor")
                'A.WriteValue(vAddSorArticulos.Proveedor)
                'A.WriteEndElement()  'FIN DE NODO PROVEEDOR

                'A.WriteStartElement("Remision")
                'A.WriteValue(vAddSorArticulos.remision)
                'A.WriteEndElement()  'FIN DE NODO remision

                'A.WriteStartElement("Foliopedido")
                'A.WriteValue(vAddSorArticulos.FolioPedido)
                'A.WriteEndElement()  'FIN DE NODO remision

                'A.WriteStartElement("Tienda")
                'A.WriteValue(vAddSorArticulos.Tienda)
                'A.WriteEndElement()  'FIN DE NODO tienda

                'A.WriteStartElement("CantidadArticulos")
                'A.WriteValue(vAddSorArticulos.CantidadArticulos)
                'A.WriteEndElement()  'FIN DE NODO CantidadArticulos

                'A.WriteStartElement("Codigo")
                'A.WriteValue(vAddSorArticulos.Codigo)
                'A.WriteEndElement()  'FIN DE NODO Codigo

                'A.WriteStartElement("CantidadUnidadCompra")
                'A.WriteValue(vAddSorArticulos.CantidadUnidadCompra)
                'A.WriteEndElement()  'FIN DE NODO CantidadUnidadCompra

                'A.WriteStartElement("CostoNetoUnidadCompra")
                'A.WriteValue(vAddSorArticulos.CostoNetoUnidadCompra)
                'A.WriteEndElement()  'FIN DE NODO CostoNetoUnidadCompra

                'A.WriteStartElement("PorcentajeIEPS")
                'A.WriteValue(vAddSorArticulos.PorcentajeIEPS)
                'A.WriteEndElement()  'FIN DE NODO PorcentajeIEPS

                'A.WriteStartElement("PorcentajeIVA")
                'A.WriteValue(vAddSorArticulos.PorcentajeIVA)
                'A.WriteEndElement()  'FIN DE NODO PorcentajeIVA

                'A.WriteEndElement()  'FIN DE NODO articulos                            cierro articulos 6

                Dim c As Integer = 0
                For Each vRow In vTablaProds.Rows

                    A.WriteStartElement("Articulos") '                                          6
                    'Escribe el Titulo
                    A.WriteStartAttribute("Id")
                    A.WriteValue("Articulos" & c + 1)
                    A.WriteEndAttribute() 'TERMINA ATRIBUTO Id
                    A.WriteStartAttribute("RowOrder")
                    A.WriteValue(c + 1)
                    A.WriteEndAttribute() 'TERMINA ATRIBUTO RowOrder


                    A.WriteStartElement("Proveedor")
                    A.WriteValue(vAddSorArticulos.Proveedor)
                    A.WriteEndElement()  'FIN DE NODO PROVEEDOR

                    A.WriteStartElement("Remision")
                    A.WriteValue(vAddSorArticulos.remision)
                    A.WriteEndElement()  'FIN DE NODO remision
                    A.WriteStartElement("Foliopedido")
                    A.WriteValue(vAddSorArticulos.FolioPedido)
                    A.WriteEndElement()  'FIN DE NODO remision

                    A.WriteStartElement("Tienda")
                    A.WriteValue(vAddSorArticulos.Tienda)
                    A.WriteEndElement()  'FIN DE NODO tienda

                    'A.WriteStartElement("CantidadArticulos")
                    'A.WriteValue(vAddSorArticulos.CantidadArticulos)
                    'A.WriteEndElement()  'FIN DE NODO CantidadArticulos
                    A.WriteStartElement("Codigo")
                    A.WriteValue(vAddSorArticulos.Codigo)
                    A.WriteEndElement()  'FIN DE NODO Codigo
                    A.WriteStartElement("CantidadUnidadCompra")
                    A.WriteValue(vAddSorArticulos.CantidadUnidadCompra)
                    A.WriteEndElement()  'FIN DE NODO CantidadUnidadCompra
                    A.WriteStartElement("CostoNetoUnidadCompra")
                    A.WriteValue(vAddSorArticulos.CostoNetoUnidadCompra)
                    A.WriteEndElement()  'FIN DE NODO CostoNetoUnidadCompra

                    A.WriteStartElement("PorcentajeIEPS")
                    A.WriteValue(vAddSorArticulos.PorcentajeIEPS)
                    A.WriteEndElement()  'FIN DE NODO PorcentajeIEPS
                    A.WriteStartElement("PorcentajeIVA")
                    A.WriteValue(vAddSorArticulos.PorcentajeIVA)
                    A.WriteEndElement()  'FIN DE NODO PorcentajeIVA
                    A.WriteEndElement()  'FIN DE NODO articulos


                    c = c + 1

                Next
                'A.WriteEndElement()  'FIN DE NODO articulos

                A.WriteEndElement() ''Cierra el elemento DSCargaRemisionProv.          cierro 3


                A.WriteEndElement() 'Para Elemento principal Inicial de URL SAT <cfdi:Addenda> cierro 2
                A.WriteEndElement() ''Cierra el elemento addenda         cierro 1
            Next
            'Forza grabación a Disco
            A.Flush()

            'Cierra el Archivo
            A.Close()

            MsgBox("Se genero Nodo Addenda", MsgBoxStyle.Information, "Notificacion - NET")
            'Else
            'MsgBox("Error en generar Addenda", MsgBoxStyle.Information, "Notificacion HORROR.Net")
            'End If
            subGrabaAddendaPM()

        Catch ex As Exception

        End Try

    End Sub
    Sub subGrabaAddendaPM()
        Dim archivoXMLaddendado As String = "c:\correo\" & Me.txtRFC.Text & "_" & Me.txtFolio.Text & "Add.xml"
        Try
            'Create the XmlDocument.

            '1. Cargo atravez de txtLoad la URL de la Factura Timbrada y sellada por SAT desde un directorio
            Dim docXmlF As XmlDocument = New XmlDocument()
            docXmlF.Load(pathfilexml)



            '2. Crear en otro XmlDocument el Nodo a Insertar Este lo cargo directamende del directorio, es el nodo Addenda capturado. 
            Dim docXmlA As New XmlDocument()
            docXmlA.Load("C:\correo\Addenda.xml")

            '3. Import el nodo Addenda dedocXmlA en el documento Original docXmlF. 
            Dim Addenda As XmlNode = docXmlF.ImportNode(docXmlA.DocumentElement.LastChild, True)
            docXmlF.DocumentElement.AppendChild(Addenda)


            ' 4. Save the modified fil XML a formato UTF8.
            docXmlF.PreserveWhitespace = True
            Dim wrtr As XmlTextWriter = New XmlTextWriter(archivoXMLaddendado, System.Text.Encoding.UTF8)
            'wrtr.Formatting = Formatting.Indented
            docXmlF.WriteTo(wrtr)
            wrtr.Close()
            '5. Guardo y Senalo la Direccion
            docXmlF.Save(Console.Out)
           

        Catch ex As Exception
            MsgBox("Error de Ruta, No Existe en 'C:\correo\' , verificar con el Administrador de Sistemas", MsgBoxStyle.Exclamation, "Notificacion del Sistema Addendas Soriana")
        End Try
    End Sub
End Class

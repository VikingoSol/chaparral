Imports BaseDatos
Imports FacturaNETLib
Imports FacturaNETLib.Manager
Imports FacturaNETLib.Document
Imports FacturaNETLib.Certificate
Imports System.Xml
Imports System.Text
Imports System.IO
Public Class frmFacturaView
    'Dim vTablaProds As New DataTable
    Dim pathfilexml As String
    Dim vAddSorRemi As New dAddendaSorianaremision
    Dim vAddSorpedido As New dAddendaSorianapedidos
    Dim vAddSorArticulos As New dAddendaSorianaArticulos
    Dim xd As XmlDocument
    Dim facturasel As Integer
    Dim vTablaProds As DataTable

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

        subtotal.Text = Format(vFac.SubTotal, "C2")
        iva.Text = Format(vFac.IVA, "C2")
        total.Text = Format(vFac.Total, "C2")
        ieps.Text = 0.0
        descuento.Text = Format(vFac.Descuento, "C2")


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



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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
        vAddSorRemi.IEPS = Me.ieps.Text
        vAddSorRemi.IVA = Me.txtIVA.Text
        vAddSorRemi.OtrosImpuestos = Me.otrosi.Text
        vAddSorRemi.Total = Me.txtTotal.Text
        vAddSorRemi.CantidadPedidos = Me.Txtcantidadpedidos.Text
        vAddSorRemi.FechaEntregaMercancia = Me.FechaEntregaM.Value.ToString
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
        leexml()

        'Declaro variable para leer archivo Xml
        Dim reader As XmlTextReader = New XmlTextReader(pathfilexml)
        Dim readder As XmlTextReader = New XmlTextReader("c:\correo\AddSoriana.xml")

        Dim objStreamReader As StreamReader
        Dim objStreamReadder As StreamReader
        Dim strLine As String
        Dim objStreamWriter As StreamWriter

        'Pass the file path and the file name to the StreamWriter constructor.
        objStreamWriter = New StreamWriter("C:\correo\Testfile.xml")


        'Pass the file path and the file name to the StreamReader constructor.
        objStreamReader = New StreamReader(pathfilexml)
        objStreamReadder = New StreamReader("c:\correo\AddSoriana.xml")

        Dim file As System.IO.StreamWriter = System.IO.File.CreateText("C:\correo\Testfile.txt")
        'Read the first line of text.
        strLine = objStreamReader.ReadLine

        'Continue to read until you reach the end of the file.
        Do While Not strLine Is Nothing

            'Write the line to the Console window.
            objStreamWriter.WriteLine(strLine)
            file.WriteLine(strLine)

            'Read the next line.
            strLine = objStreamReader.ReadLine
        Loop
        '--------------------------------------
        'Close the file.
        objStreamReader.Close()

        'Read the first line of text.
        strLine = objStreamReadder.ReadLine

        'Continue to read until you reach the end of the file.
        Do While Not strLine Is Nothing

            'Write the line to the Console window.
            objStreamWriter.WriteLine(strLine)
            If Mid(strLine, 1, 5) = "<?xml" Then
            Else
                file.WriteLine(strLine)
            End If
            'Read the next line.
            strLine = objStreamReadder.ReadLine
        Loop

        'Close the file.
        objStreamReadder.Close()

        file.Close()
        Console.ReadLine()


        'Ciclo de lectura
        Do While (reader.Read())
            objStreamWriter.WriteLine(reader.Read())
            Select Case reader.NodeType
                Case XmlNodeType.Element 'Mostrar comienzo del elemento.

                    If reader.HasAttributes Then 'If attributes exist
                        While reader.MoveToNextAttribute()
                            'Mostrar nombre y valor del atributo.

                        End While
                    End If

                Case XmlNodeType.Text 'Mostrar el texto de cada elemento.

                Case XmlNodeType.EndElement 'Mostrar final del elemento.
                    'Txtcontenido.Text += " txtContenido.Text += " > " + vbCrLf"

                    If reader.Name = "cfdi:Complemento" Then
                        Do While (readder.Read())
                            Select Case readder.NodeType
                                Case XmlNodeType.Element 'Mostrar comienzo del elemento.

                                    If reader.HasAttributes Then 'If attributes exist
                                        While reader.MoveToNextAttribute()
                                            'Mostrar nombre y valor del atributo.

                                        End While
                                    End If

                                Case XmlNodeType.Text 'Mostrar el texto de cada elemento.

                                Case XmlNodeType.EndElement 'Mostrar final del elemento.
                                    'Txtcontenido.Text += " txtContenido.Text += " > " + vbCrLf"

                            End Select
                        Loop

                        'Cierra el Archivo
                        readder.Close()

                    End If
            End Select
        Loop
        objStreamWriter.Close()
        'Cierra el Archivo
        reader.Close()

        MsgBox("Addenda Adicionada")

    End Sub
    Private Sub leexml()
        xd = New XmlDocument
        'xd.Load(pathfilexml)


        Dim vOpt As New XmlWriterSettings
        Dim vXml As XmlWriter = XmlWriter.Create("c:\correo\jc.xml", vOpt)
        Dim Prefijo As String = "cfdi", EspacioDeNombre As String = " "

        With vXml
            '1
            .WriteStartElement(prefix:=Prefijo, localName:="Addenda", ns:=EspacioDeNombre)
            .WriteEndElement()
        End With
        vXml.Flush()
        vXml.Close()

        xd.Load("c:\correo\jc.xml")
        Dim vFac As dAddendaSorianaremision = vAddSorRemi
        'vFac = New dAddendaSorianaremision

        Dim vpedi As dAddendaSorianapedidos = vAddSorpedido
        'vpedi = New dAddendaSorianapedidos

        Dim vArt As dAddendaSorianaArticulos = vAddSorArticulos
        'vArt = New dAddendaSorianaArticulos

        Dim newAuthor As XmlElement
        newAuthor = xd.CreateElement("cfdi:DSCargaRemisionProv", Nothing)
        'newAuthor.SetAttribute("code", "6")
        'Dim DSCargaRemisionProv As XmlElement = xd.CreateElement("DSCargaRemisionProv")

        ''fn.InnerText = "Bikram"
        'newAuthor.AppendChild(DSCargaRemisionProv)

        Dim Remision As XmlElement = xd.CreateElement("Remision")
        Remision.SetAttribute("RowOrder", 1)
        Remision.SetAttribute("Id", "Remision1")
        'ln.InnerText = "Seth"

        newAuthor.AppendChild(Remision)

        Dim pedidos As XmlElement = xd.CreateElement("Pedidos")
        'ln.InnerText = "Seth"
        pedidos.SetAttribute("RowOrder", 1)
        pedidos.SetAttribute("Id", "Pedidos1")
        newAuthor.AppendChild(pedidos)

        Dim Articulos As XmlElement = xd.CreateElement("Articulos")
        ''aln1.InnerText = "Seth"
        newAuthor.AppendChild(Articulos)

        '----------------------------------------------
        Dim proveedor As XmlElement = xd.CreateElement("Proveedor")
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

        Dim TiendaP As XmlElement = xd.CreateElement("Tienda")
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

            Dim TiendaA As XmlElement = xd.CreateElement("Tienda")
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
        Dim fileXmlOut As String = "c:\correo\AddSoriana.xml"
        xd.DocumentElement.AppendChild(newAuthor)
        Dim tr As XmlTextWriter = New XmlTextWriter(fileXmlOut, System.Text.Encoding.UTF8)
        tr.Formatting = Formatting.Indented
        xd.WriteContentTo(tr)
        Dim file2XmlOut As String = "c:\correo\" & Me.txtRFC.Text & "_" & Me.txtFolio.Text & "AddSor.xml"
        tr.Close()

        'Dim Vxd As XmlDocument = New XmlDocument
        'Vxd.Load(pathfilexml)
        'Dim Txd As XmlDocument = New XmlDocument
        'Txd.Load(fileXmlOut)
        'Dim nodoRaiz As XmlNode = Vxd.DocumentElement
        'nodoRaiz.InsertAfter(Txd.DocumentElement, nodoRaiz.LastChild)
        ''Vxd.DocumentElement.AppendChild(Txd)
        'Dim trt As XmlTextWriter = New XmlTextWriter(file2XmlOut, Nothing)
        'trt.Formatting = Formatting.Indented
        'Vxd.WriteContentTo(trt)
        'trt.Close()

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
End Class

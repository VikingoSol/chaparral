Imports BaseDatos
Imports FacturaNETLib
Imports FacturaNETLib.Manager
Imports FacturaNETLib.Document
Imports FacturaNETLib.Certificate
Public Class frmFacturaView
    'Dim vTablaProds As New DataTable

    Public Sub VerFactura(ByVal pId As Integer)
        Dim vFacs As New cFacturas
        Dim vFac As dFacturaView = vFacs.GetFactura(pId)
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
            End If
        Next

        Me.grdProductos.DataSource = vFacs.GetProductosFacturados(pId)

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

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtconsecutivo.TextChanged

    End Sub

    
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.OpenFileDialog1.Filter = "Archivo Cer (*.cer)|*.cer"
        'Me.OpenFileDialog1.FileName = Me.txtCertificado.Text
        'If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    Me.txtCertificado.Text = Me.OpenFileDialog1.FileName
        'End If
    End Sub
End Class

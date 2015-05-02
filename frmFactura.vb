Imports BaseDatos
Public Class frmFactura
    Dim vIdFactura As Integer = -1
    Dim vLastIdCl As Integer = -1
    Dim vCliente As New dCliente
    Dim vTablaProds As New DataTable
    Public gdescuento As Double
    Dim noarticulosventa As Double = 0
    Public Function Agregar() As Integer
        If Me.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return vIdFactura
        End If
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim vClBus As New frmClienteBus
        Dim vId As Integer = vClBus.Buscar_Cliente
        If vId > 0 Then
            Me.txtIdCliente.Text = vId
            Datos_Cliente()
        End If
    End Sub

    Private Sub Clear_Datos_Cliente()
        Me.txtCliente.Text = ""
        Me.txtRFC.Text = ""
        Me.TxtDesctocte.Text = ""
    End Sub

    Private Sub Datos_Cliente()
        If Trim(Me.txtIdCliente.Text) = "" Then
            Clear_Datos_Cliente()
            Exit Sub
        End If
        Me.vLastIdCl = Trim(Me.txtIdCliente.Text)
        Dim vClientes As New cClientes
        vCliente = vClientes.GetCliente(Me.txtIdCliente.Text)
        If IsNothing(vCliente) Then
            Clear_Datos_Cliente()
        Else
            Me.txtCliente.Text = vCliente.Nombre
            Me.txtRFC.Text = vCliente.RFC
            Me.TxtDesctocte.Text = vCliente.DescFactura
        End If
    End Sub

    Private Sub btnAddCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCliente.Click
        Dim vCl As New frmCliente
        Dim vID As Integer = vCl.Nuevo
        If vID > 0 Then
            Me.txtIdCliente.Text = vID
            Datos_Cliente()
        End If
    End Sub

    Private Sub txtIdCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIdCliente.KeyDown
        If e.KeyCode = Keys.Enter Then
            Datos_Cliente()
        End If
    End Sub

    Private Sub txtIdCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdCliente.LostFocus
        Me.Datos_Cliente()
    End Sub

    Private Sub txtIdCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIdCliente.TextChanged

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Crear_Tabla()
        Me.grdProductos.DataSource = vTablaProds

        Dim vConfig As New cConfigGlobal
        Me.txtFolio.Text = vConfig.GetNextFolio(RfcActual)
        Me.txtSerie.Text = gConfigGlobal.Serie

        lblIVA.Text = "IVA (" & FormatNumber((gConfigGlobal.IVA * 100), 2) & "%):"

        Dim vProds As New cProductos
        Dim vUnis As DataTable = vProds.GetUnidades()
        If Not IsNothing(vUnis) Then
            Me.grdProductos.RootTable.Columns("unidad").ValueList.PopulateValueList(vUnis.DefaultView, "id", "unidad")
        End If

        '  Me.cmbMetodoPago.SelectedIndex = 4
        Dim vFac As New BaseDatos.cFacturas
        Me.cmbMetodoPago.DataSource = vFac.GetMetodosPago

        Me.cmbMoneda.SelectedIndex = 0

        Me.CboRFCemisor.SelectedValue = gConfig
    End Sub

    Private Sub Crear_Tabla()
        Me.vTablaProds.Columns.Add("id", GetType(Integer))
        Me.vTablaProds.Columns.Add("cantidad", GetType(Double))
        Me.vTablaProds.Columns.Add("producto", GetType(String))
        Me.vTablaProds.Columns.Add("precio", GetType(Double))
        Me.vTablaProds.Columns.Add("isproducto", GetType(Boolean))
        Me.vTablaProds.Columns.Add("unidad", GetType(Integer))
        Me.vTablaProds.Columns.Add("unidadnom", GetType(String))
        Me.vTablaProds.Columns.Add("tasa", GetType(Double))
        Me.vTablaProds.Columns.Add("codigo", GetType(String))
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim vBus As New frmProductosBus
        Dim vId As Integer = vBus.Buscar_Producto()
        If vId > 0 Then
            Me.txtIdProd.Text = vId
            'Me.txtIdProd.Focus()
            AgregarProducto()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim vProd As New frmProducto
        Dim vId As Integer = vProd.Agregar
        If vId > 0 Then
            Me.txtIdProd.Text = vId
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim vProds As New frmProductoUnico
        Dim vProd As dProductoUnico = vProds.Agregar
        If Not IsNothing(vProd) Then
            Dim vRow As DataRow = Me.vTablaProds.NewRow
            vRow.Item("id") = vProd.Id
            vRow.Item("producto") = vProd.Nombre
            vRow.Item("precio") = vProd.Precio
            vRow.Item("cantidad") = vProd.Cantidad
            vRow.Item("unidad") = vProd.Unidad
            vRow.Item("isproducto") = False
            vRow.Item("unidadnom") = vProd.UnidadNom
            vRow.Item("tasa") = vProd.TasaPorc
            vRow.Item("codigo") = vProd.codigo
            vTablaProds.Rows.Add(vRow)
            Me.grdProductos.Refetch()
            Calcular_Totales()
        End If
    End Sub

    Private Sub txtIdProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIdProd.Click

    End Sub

    Private Sub txtIdProd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIdProd.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not IsDBNull(txtIdProd.Text) Or txtIdProd.Text <> "" Then
                AgregarProducto()
            Else
                Me.txtIdProd.Focus()
            End If

        End If
    End Sub

    Private Sub AgregarProducto()
        If Me.txtCantidad.Text <= 0 Then
            MsgBox("La cantidad del producto / servicio debe de ser mayor a cero", MsgBoxStyle.Critical, "¿Cantidad?")
            Me.txtCantidad.SelectAll()
            Me.txtCantidad.Focus()
            Exit Sub
        End If

        If IsDBNull(txtIdProd.Text) Or txtIdProd.Text = "" Then
            txtIdProd.Focus()
            Exit Sub
        Else

        End If


        Dim vProds As New cProductos
        Dim vProd As dProducto = vProds.GetProducto(Me.txtIdProd.Text)
        If IsNothing(vProd) Then
            MsgBox("El Id del producto / servicio especificado no existe", MsgBoxStyle.Critical, "¿Producto / Servicio?")
            Me.txtIdProd.SelectAll()
            Me.txtIdProd.Focus()
            Exit Sub
        End If
        Dim vRow As DataRow
        Dim vExisteProd As Boolean = False
        For Each vRow In vTablaProds.Rows
            If vRow.Item("isproducto") AndAlso vRow.Item("id") = vProd.Id Then
                vRow.Item("cantidad") += Me.txtCantidad.Text
                vExisteProd = True
                Exit For
            End If
        Next
        If Not vExisteProd Then
            vRow = Me.vTablaProds.NewRow()
            vRow.Item("id") = vProd.Id
            vRow.Item("producto") = vProd.Nombre
            vRow.Item("precio") = vProd.Precio
            vRow.Item("cantidad") = txtCantidad.Text
            vRow.Item("unidad") = vProd.Unidad
            vRow.Item("isproducto") = True
            vRow.Item("unidadnom") = vProd.UnidadNom
            vRow.Item("tasa") = vProd.TasaPorc
            vRow.Item("codigo") = vProd.codigo
            vTablaProds.Rows.Add(vRow)
        End If
        Me.grdProductos.Refetch()

        Calcular_Totales()

        Me.txtCantidad.Text = "1.00"
        Me.txtIdProd.Text = ""
        Me.txtCantidad.SelectAll()
        Me.txtCantidad.Focus()

    End Sub

    Private Sub Calcular_Totales()
        'If Not IsDBNull(Me.txtTotal.Text) Then Exit Sub
        Dim vSubTotal As Double = 0
        Dim vDescuento As Double = 0
        Dim vIva As Double = 0
        Try
            vSubTotal = Me.grdProductos.GetTotal(Me.grdProductos.RootTable.Columns("importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
            vDescuento = Me.grdProductos.GetTotal(Me.grdProductos.RootTable.Columns("importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
            vIva = Me.grdProductos.GetTotal(Me.grdProductos.RootTable.Columns("iva"), Janus.Windows.GridEX.AggregateFunction.Sum)
            noarticulosventa = Me.grdProductos.GetTotal(Me.grdProductos.RootTable.Columns("Cantidad"), Janus.Windows.GridEX.AggregateFunction.Sum)
            Me.Txttotalart.Text = noarticulosventa
        Catch ex As Exception
            vSubTotal = 0
            vDescuento = 0
            vIva = 0
            noarticulosventa = 0
        End Try
        'Dim vSubTotal As Double = Me.grdProductos.GetTotal(Me.grdProductos.RootTable.Columns("importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
        'Dim vDescuento As Double = Me.grdProductos.GetTotal(Me.grdProductos.RootTable.Columns("importe"), Janus.Windows.GridEX.AggregateFunction.Sum)
        'Dim vIva As Double = Me.grdProductos.GetTotal(Me.grdProductos.RootTable.Columns("iva"), Janus.Windows.GridEX.AggregateFunction.Sum)

        Dim vRetIVA As Double = vIva * (2 / 3)
        If CDbl(Me.TxtDesctocte.Text) > 0 Then
            Me.Txtdescuento.Text = FormatNumber(vDescuento * (CDbl(Me.TxtDesctocte.Text) / 100), 2)
            vDescuento = CDbl(Me.Txtdescuento.Text)
        Else
            Me.Txtdescuento.Text = FormatNumber(0.0, 2)
            vDescuento = 0
        End If
        Me.txtSubTotal.Text = FormatNumber(vSubTotal, 2)
        Me.txtIVA.Text = FormatNumber(vIva, 2)
        If vCliente.RetieneIva Then
            Me.txtRetIva.Text = FormatNumber(vRetIVA, 2)
        Else
            Me.txtRetIva.Text = "0.00"
            vRetIVA = 0
        End If
        Me.txtTotal.Text = FormatNumber(vSubTotal - vDescuento + vIva - vRetIVA, 2)
        gdescuento = vDescuento
    End Sub

    Private Sub txtCantidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidad.Click

    End Sub

    Private Sub txtCantidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not IsDBNull(txtIdProd.Text) Or txtIdProd.Text <> "" Then
                AgregarProducto()
            Else
                Me.txtIdProd.Focus()
            End If

        End If
    End Sub

    Private Sub grdClientes_FormattingRow(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles grdProductos.FormattingRow

    End Sub

    Private Sub grdClientes_LoadingRow(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles grdProductos.LoadingRow
        If e.Row.RowType = Janus.Windows.GridEX.RowType.Record Then
            e.Row.Cells("importe").Value = e.Row.Cells("cantidad").Value * e.Row.Cells("precio").Value
            e.Row.Cells("tasa").Text = (e.Row.Cells("tasa").Value * 100) & " %"
            e.Row.Cells("iva").Value = e.Row.Cells("tasa").Value * (e.Row.Cells("cantidad").Value * e.Row.Cells("precio").Value)
        End If
    End Sub

    Private Sub grdProductos_RecordsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProductos.RecordsDeleted
        Calcular_Totales()
    End Sub

    Private Sub grdProductos_RecordUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProductos.RecordUpdated
        Calcular_Totales()
    End Sub

    Private Sub grdClientes_RowCountChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProductos.RowCountChanged
        If Me.grdProductos.RowCount = 0 Then
            Me.btnDelete.Enabled = False
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Me.grdProductos.Delete()
    End Sub

    Private Sub grdClientes_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProductos.SelectionChanged
        If Not IsNothing(Me.grdProductos.GetRow) AndAlso Me.grdProductos.GetRow.RowType = Janus.Windows.GridEX.RowType.Record Then
            Me.btnDelete.Enabled = True
        Else
            Me.btnDelete.Enabled = False
        End If
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim vClientes As New cClientes
        Dim resp As Integer
        resp = MsgBox("Desea Timbrar su factura?", MsgBoxStyle.Question + MsgBoxStyle.YesNo)
        If resp = vbYes Then

        Else
            Exit Sub
        End If

        If Not IsNumeric(Me.txtIdCliente.Text) OrElse Not vClientes.ExisteId(Me.txtIdCliente.Text) Then
            MsgBox("El Id del cliente especificado no existe", MsgBoxStyle.Critical, "¿Id Cliente?")
            Me.txtIdCliente.SelectAll()
            Me.txtIdCliente.Focus()
            Exit Sub
        End If
        If Me.grdProductos.RowCount <= 0 Then
            MsgBox("Debe de especificar al menos un producto", MsgBoxStyle.Critical, "¿Productos?")
            Me.txtIdProd.SelectAll()
            Me.txtIdProd.Focus()
            Exit Sub
        End If
        'If Trim(Me.txtMetodosPago.Text) = "" Then
        '    MsgBox("Debe especificar los metodos de pago de la factura", MsgBoxStyle.Critical, "¿Metodos de pago?")
        '    Me.txtMetodosPago.SelectAll()
        '    Me.txtMetodosPago.Focus()
        '    Exit Sub
        'End If

        Dim vFac As New frmFacturaProc
        Dim vFactura As New dFactura
        vFactura.Serie = Me.txtSerie.Text
        vFactura.Folio = Me.txtFolio.Text
        vFactura.IdCliente = Me.txtIdCliente.Text
        vFactura.Descuento = Me.Txtdescuento.Text
        vFactura.Subtotal = Me.txtSubTotal.Text
        vFactura.IVA = Me.txtIVA.Text
        vFactura.RetencionIVA = Me.txtRetIva.Text
        vFactura.Total = Me.txtTotal.Text
        vFactura.Metodo_Pago = Trim(Me.cmbMetodoPago.Text)
        vFactura.MetodosPagoId = Me.cmbMetodoPago.SelectedValue
        vFactura.Cuenta = Trim(Me.txtCuenta.Text)
        vFactura.TipoCambio = Me.txtTipoCambio.Text
        vFactura.Moneda = Me.cmbMoneda.SelectedItem

        vFactura.Fecha = Me.dpFecha.Value
        Me.vIdFactura = vFac.Facturar(vFactura, Me.vTablaProds)
        If vIdFactura > 0 Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub txtMetodosPago_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmbMetodoPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMetodoPago.SelectedIndexChanged
        If Me.cmbMetodoPago.SelectedValue <= 2 Or Me.cmbMetodoPago.SelectedValue >= 6 Then
            Me.txtCuenta.Text = ""
            Me.txtCuenta.Enabled = False
        Else
            Me.txtCuenta.Enabled = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMoneda.SelectedIndexChanged
        If Me.cmbMoneda.Text = "MXN" Then
            Me.txtTipoCambio.Text = "1.0000"
        Else
            Me.txtTipoCambio.Text = FormatNumber(gConfigGlobal.TipoCambio, 4)
        End If
    End Sub

    Private Sub cmbMoneda_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMoneda.SelectedValueChanged

    End Sub

    Private Sub TxtDesctocte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDesctocte.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(Me.TxtDesctocte.Text) Then
                Calcular_Totales()
                Me.txtIdProd.Focus()
            End If
        End If
    End Sub

    Private Sub CboRFCemisor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboRFCemisor.SelectedIndexChanged


        RfcActual = CboRFCemisor.Text

        Dim cConfig As New cConfigGlobal
        gConfigGlobal = cConfig.GetConfiguracion(CboRFCemisor.Text)
        Me.emisor.Text = gConfigGlobal.RazonSocial

        gPathFactuacion = gPathDataSoft & gConfigGlobal.Registro_Federal & "\"
        gPathBarCodes = gPathDataSoft & gConfigGlobal.Registro_Federal & "\BarCodes\"
        BajarCertificadoKey()

        'Crear_Tabla()
        'Me.grdProductos.DataSource = vTablaProds

        Dim vConfig As New cConfigGlobal
        Me.txtFolio.Text = vConfig.GetNextFolio(RfcActual)
        Me.txtSerie.Text = gConfigGlobal.Serie

        lblIVA.Text = "IVA (" & FormatNumber((gConfigGlobal.IVA * 100), 2) & "%):"

        Dim vProds As New cProductos
        Dim vUnis As DataTable = vProds.GetUnidades()
        If Not IsNothing(vUnis) Then
            Me.grdProductos.RootTable.Columns("unidad").ValueList.PopulateValueList(vUnis.DefaultView, "id", "unidad")
        End If

        '  Me.cmbMetodoPago.SelectedIndex = 4
        Dim vFac As New BaseDatos.cFacturas
        Me.cmbMetodoPago.DataSource = vFac.GetMetodosPago

        Me.cmbMoneda.SelectedIndex = 0

    End Sub

    Private Sub frmFactura_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cConfig As New cConfigGlobal
        gConfigGlobal = cConfig.GetConfiguracion(RfcActual)
        Me.emisor.Text = gConfigGlobal.RazonSocial
        Me.CboRFCemisor.Text = RfcActual
    End Sub

    Private Sub TxtDesctocte_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDesctocte.LostFocus
        If IsNumeric(Me.TxtDesctocte.Text) Then
            Calcular_Totales()
        Else
            Me.TxtDesctocte.Text = 0
            Calcular_Totales()
        End If
    End Sub

    Private Sub TxtDesctocte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDesctocte.TextChanged
        If IsNumeric(Me.TxtDesctocte.Text) Then
            Calcular_Totales()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CDbl(Me.txtTotal.Text) > 0 Then
            If CheckBox1.Checked Then
                Dim f As New frmaddendas
                f.addendasoriana(Me.txtSubTotal.Text, Me.Txtdescuento.Text, 0, Me.txtIVA.Text, Me.txtTotal.Text, noarticulosventa)
                f.ShowDialog()
                CheckBox2.Checked = False
                CheckBox3.Checked = False
            End If
          
        Else
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CDbl(Me.txtTotal.Text) > 0 Then
            If CheckBox2.Checked Then

                CheckBox1.Checked = False
                CheckBox3.Checked = False
            End If
        Else
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CDbl(Me.txtTotal.Text) > 0 Then
            If CheckBox3.Checked Then

                CheckBox1.Checked = False
                CheckBox2.Checked = False
            End If
        Else
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
        End If
    End Sub
End Class

Public Class dFactura
    Public IdCliente As Integer
    Public Serie As String
    Public Folio As String
    Public Fecha As Date
    Public Subtotal As Double
    Public IVA As Double
    Public RetencionIVA As Double
    Public Total As Double
    Public MetodosPagoId As Integer
    Public Metodo_Pago As String
    Public Cuenta As String
    Public Moneda As String = "MXN"
    Public TipoCambio As Double
    Public Descuento As Double
End Class
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFactura
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim grdProductos_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFactura))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtSerie = New System.Windows.Forms.TextBox
        Me.txtFolio = New System.Windows.Forms.TextBox
        Me.txtIdCliente = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.TxtDesctocte = New System.Windows.Forms.TextBox
        Me.btnAddCliente = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.txtRFC = New System.Windows.Forms.TextBox
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.dpFecha = New System.Windows.Forms.DateTimePicker
        Me.grdProductos = New Janus.Windows.GridEX.GridEX
        Me.txtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtIdProd = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblIVA = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtSubTotal = New System.Windows.Forms.TextBox
        Me.txtIVA = New System.Windows.Forms.TextBox
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnDelete = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.txtCuenta = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmbMetodoPago = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmbMoneda = New System.Windows.Forms.ComboBox
        Me.txtTipoCambio = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtRetIva = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Txtdescuento = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.CboRFCemisor = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.emisor = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Serie:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(96, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Folio:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(218, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(37, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Id:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Cliente:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "R.F.C."
        '
        'txtSerie
        '
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.Location = New System.Drawing.Point(48, 54)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.ReadOnly = True
        Me.txtSerie.Size = New System.Drawing.Size(33, 20)
        Me.txtSerie.TabIndex = 6
        Me.txtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFolio
        '
        Me.txtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFolio.ForeColor = System.Drawing.Color.DarkRed
        Me.txtFolio.Location = New System.Drawing.Point(134, 51)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.ReadOnly = True
        Me.txtFolio.Size = New System.Drawing.Size(79, 24)
        Me.txtFolio.TabIndex = 7
        Me.txtFolio.Text = "0"
        Me.txtFolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIdCliente
        '
        Me.txtIdCliente.Location = New System.Drawing.Point(62, 16)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.Size = New System.Drawing.Size(32, 20)
        Me.txtIdCliente.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.TxtDesctocte)
        Me.GroupBox1.Controls.Add(Me.btnAddCliente)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.txtRFC)
        Me.GroupBox1.Controls.Add(Me.txtCliente)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtIdCliente)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 108)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(583, 100)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cliente"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(388, 77)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 13)
        Me.Label17.TabIndex = 47
        Me.Label17.Text = "Descuento %"
        '
        'TxtDesctocte
        '
        Me.TxtDesctocte.Location = New System.Drawing.Point(464, 74)
        Me.TxtDesctocte.Name = "TxtDesctocte"
        Me.TxtDesctocte.Size = New System.Drawing.Size(83, 20)
        Me.TxtDesctocte.TabIndex = 48
        Me.TxtDesctocte.Text = "0.00"
        Me.TxtDesctocte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAddCliente
        '
        Me.btnAddCliente.Image = Global.FacturaNET.My.Resources.Resources.add
        Me.btnAddCliente.Location = New System.Drawing.Point(142, 8)
        Me.btnAddCliente.Name = "btnAddCliente"
        Me.btnAddCliente.Size = New System.Drawing.Size(36, 36)
        Me.btnAddCliente.TabIndex = 3
        Me.btnAddCliente.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.FacturaNET.My.Resources.Resources.buscar
        Me.btnAdd.Location = New System.Drawing.Point(100, 8)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(36, 36)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtRFC
        '
        Me.txtRFC.Location = New System.Drawing.Point(62, 74)
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.ReadOnly = True
        Me.txtRFC.Size = New System.Drawing.Size(188, 20)
        Me.txtRFC.TabIndex = 5
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(62, 46)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(345, 20)
        Me.txtCliente.TabIndex = 4
        '
        'dpFecha
        '
        Me.dpFecha.CustomFormat = "dd / MMM / yyyy"
        Me.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFecha.Location = New System.Drawing.Point(264, 54)
        Me.dpFecha.Name = "dpFecha"
        Me.dpFecha.Size = New System.Drawing.Size(117, 20)
        Me.dpFecha.TabIndex = 1
        '
        'grdProductos
        '
        Me.grdProductos.AllowCardSizing = False
        Me.grdProductos.AllowColumnDrag = False
        Me.grdProductos.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdProductos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        grdProductos_DesignTimeLayout.LayoutString = resources.GetString("grdProductos_DesignTimeLayout.LayoutString")
        Me.grdProductos.DesignTimeLayout = grdProductos_DesignTimeLayout
        Me.grdProductos.GroupByBoxVisible = False
        Me.grdProductos.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grdProductos.Location = New System.Drawing.Point(6, 214)
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.Size = New System.Drawing.Size(640, 184)
        Me.grdProductos.TabIndex = 8
        '
        'txtCantidad
        '
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(6, 420)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(66, 22)
        Me.txtCantidad.TabIndex = 10
        Me.txtCantidad.Text = "1.00"
        Me.txtCantidad.Value = New Decimal(New Integer() {100, 0, 0, 131072})
        '
        'txtIdProd
        '
        Me.txtIdProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdProd.Location = New System.Drawing.Point(99, 420)
        Me.txtIdProd.Name = "txtIdProd"
        Me.txtIdProd.Numeric = True
        Me.txtIdProd.Size = New System.Drawing.Size(98, 22)
        Me.txtIdProd.TabIndex = 11
        Me.txtIdProd.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(402, 404)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "SubTotal:"
        '
        'lblIVA
        '
        Me.lblIVA.Location = New System.Drawing.Point(371, 452)
        Me.lblIVA.Name = "lblIVA"
        Me.lblIVA.Size = New System.Drawing.Size(84, 13)
        Me.lblIVA.TabIndex = 18
        Me.lblIVA.Text = "I.V.A.(0%):"
        Me.lblIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(421, 502)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Total:"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Location = New System.Drawing.Point(461, 401)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(113, 20)
        Me.txtSubTotal.TabIndex = 20
        Me.txtSubTotal.Text = "0.00"
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIVA
        '
        Me.txtIVA.Location = New System.Drawing.Point(461, 449)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.ReadOnly = True
        Me.txtIVA.Size = New System.Drawing.Size(113, 20)
        Me.txtIVA.TabIndex = 21
        Me.txtIVA.Text = "0.00"
        Me.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal
        '
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(461, 497)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(113, 22)
        Me.txtTotal.TabIndex = 22
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(264, 526)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 15
        Me.Button4.Text = "Crear CFDI"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(345, 526)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 24
        Me.Button5.Text = "Cancelar"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Metodos Pago:"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.Image = Global.FacturaNET.My.Resources.Resources.delete
        Me.btnDelete.Location = New System.Drawing.Point(656, 214)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(36, 36)
        Me.btnDelete.TabIndex = 9
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = Global.FacturaNET.My.Resources.Resources.add_prod5
        Me.Button3.Location = New System.Drawing.Point(294, 405)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(36, 36)
        Me.Button3.TabIndex = 14
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = Global.FacturaNET.My.Resources.Resources.add
        Me.Button1.Location = New System.Drawing.Point(252, 405)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(36, 36)
        Me.Button1.TabIndex = 13
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.FacturaNET.My.Resources.Resources.buscar
        Me.Button2.Location = New System.Drawing.Point(210, 405)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(36, 36)
        Me.Button2.TabIndex = 12
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtCuenta
        '
        Me.txtCuenta.Location = New System.Drawing.Point(298, 82)
        Me.txtCuenta.MaxLength = 4
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(63, 20)
        Me.txtCuenta.TabIndex = 34
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(248, 86)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 13)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Cuenta:"
        '
        'cmbMetodoPago
        '
        Me.cmbMetodoPago.DisplayMember = "metodo"
        Me.cmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMetodoPago.FormattingEnabled = True
        Me.cmbMetodoPago.Location = New System.Drawing.Point(83, 82)
        Me.cmbMetodoPago.Name = "cmbMetodoPago"
        Me.cmbMetodoPago.Size = New System.Drawing.Size(159, 21)
        Me.cmbMetodoPago.TabIndex = 36
        Me.cmbMetodoPago.ValueMember = "id"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(387, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Moneda:"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.Items.AddRange(New Object() {"MXN", "USD"})
        Me.cmbMoneda.Location = New System.Drawing.Point(442, 53)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(70, 21)
        Me.cmbMoneda.TabIndex = 38
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoCambio.Location = New System.Drawing.Point(595, 54)
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(51, 20)
        Me.txtTipoCambio.TabIndex = 40
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(520, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 13)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Tipo Cambio:"
        '
        'txtRetIva
        '
        Me.txtRetIva.Location = New System.Drawing.Point(461, 472)
        Me.txtRetIva.Name = "txtRetIva"
        Me.txtRetIva.ReadOnly = True
        Me.txtRetIva.Size = New System.Drawing.Size(113, 20)
        Me.txtRetIva.TabIndex = 42
        Me.txtRetIva.Text = "0.00"
        Me.txtRetIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(371, 475)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 13)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "Ret. I.V.A.:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 401)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "Cantidad"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(117, 401)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 13)
        Me.Label15.TabIndex = 44
        Me.Label15.Text = "Codigo Id"
        '
        'Txtdescuento
        '
        Me.Txtdescuento.Location = New System.Drawing.Point(461, 425)
        Me.Txtdescuento.Name = "Txtdescuento"
        Me.Txtdescuento.ReadOnly = True
        Me.Txtdescuento.Size = New System.Drawing.Size(113, 20)
        Me.Txtdescuento.TabIndex = 46
        Me.Txtdescuento.Text = "0.00"
        Me.Txtdescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(394, 428)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(62, 13)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "Descuento:"
        '
        'CboRFCemisor
        '
        Me.CboRFCemisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboRFCemisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboRFCemisor.FormattingEnabled = True
        Me.CboRFCemisor.Items.AddRange(New Object() {"BAMF650219E70", "BAMG670420V91"})
        Me.CboRFCemisor.Location = New System.Drawing.Point(78, 17)
        Me.CboRFCemisor.Name = "CboRFCemisor"
        Me.CboRFCemisor.Size = New System.Drawing.Size(223, 24)
        Me.CboRFCemisor.TabIndex = 48
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(7, 23)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 13)
        Me.Label18.TabIndex = 47
        Me.Label18.Text = "RFC Emisor:"
        '
        'emisor
        '
        Me.emisor.AutoSize = True
        Me.emisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emisor.ForeColor = System.Drawing.Color.Gray
        Me.emisor.Location = New System.Drawing.Point(329, 23)
        Me.emisor.Name = "emisor"
        Me.emisor.Size = New System.Drawing.Size(115, 16)
        Me.emisor.TabIndex = 49
        Me.emisor.Text = "Nombre Emisor"
        '
        'frmFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 556)
        Me.Controls.Add(Me.emisor)
        Me.Controls.Add(Me.CboRFCemisor)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Txtdescuento)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtRetIva)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtTipoCambio)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmbMoneda)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmbMetodoPago)
        Me.Controls.Add(Me.txtCuenta)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtIVA)
        Me.Controls.Add(Me.txtSubTotal)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblIVA)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtIdProd)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.grdProductos)
        Me.Controls.Add(Me.dpFecha)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtFolio)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFactura"
        Me.Text = "Factura"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents txtIdCliente As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRFC As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents grdProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents txtCantidad As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnAddCliente As System.Windows.Forms.Button
    Friend WithEvents txtIdProd As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblIVA As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtIVA As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbMetodoPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtRetIva As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Txtdescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtDesctocte As System.Windows.Forms.TextBox
    Friend WithEvents CboRFCemisor As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents emisor As System.Windows.Forms.Label
End Class

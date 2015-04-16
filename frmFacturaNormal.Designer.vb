<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturaNormal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturaNormal))
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
        Me.btnAddCliente = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.txtRFC = New System.Windows.Forms.TextBox
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.dpFecha = New System.Windows.Forms.DateTimePicker
        Me.grdProductos = New Janus.Windows.GridEX.GridEX
        Me.txtCantidad = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.txtIdProd = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblIVA = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtSubTotal = New System.Windows.Forms.TextBox
        Me.txtIVA = New System.Windows.Forms.TextBox
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtMetodosPago = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Serie:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(96, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Folio:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(218, 17)
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
        Me.txtSerie.Location = New System.Drawing.Point(60, 14)
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
        Me.txtFolio.Location = New System.Drawing.Point(134, 11)
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
        Me.txtIdCliente.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAddCliente)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.txtRFC)
        Me.GroupBox1.Controls.Add(Me.txtCliente)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtIdCliente)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(433, 100)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cliente"
        '
        'btnAddCliente
        '
        Me.btnAddCliente.Image = Global.FacturaNET.My.Resources.Resources.add
        Me.btnAddCliente.Location = New System.Drawing.Point(142, 8)
        Me.btnAddCliente.Name = "btnAddCliente"
        Me.btnAddCliente.Size = New System.Drawing.Size(36, 36)
        Me.btnAddCliente.TabIndex = 12
        Me.btnAddCliente.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.FacturaNET.My.Resources.Resources.buscar
        Me.btnAdd.Location = New System.Drawing.Point(100, 8)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(36, 36)
        Me.btnAdd.TabIndex = 11
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtRFC
        '
        Me.txtRFC.Location = New System.Drawing.Point(62, 74)
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.ReadOnly = True
        Me.txtRFC.Size = New System.Drawing.Size(188, 20)
        Me.txtRFC.TabIndex = 10
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(62, 46)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(311, 20)
        Me.txtCliente.TabIndex = 9
        '
        'dpFecha
        '
        Me.dpFecha.CustomFormat = "dd / MMM / yyyy"
        Me.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFecha.Location = New System.Drawing.Point(264, 14)
        Me.dpFecha.Name = "dpFecha"
        Me.dpFecha.Size = New System.Drawing.Size(117, 20)
        Me.dpFecha.TabIndex = 10
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
        Me.grdProductos.Location = New System.Drawing.Point(3, 147)
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.Size = New System.Drawing.Size(649, 214)
        Me.grdProductos.TabIndex = 11
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(3, 376)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(66, 20)
        Me.txtCantidad.TabIndex = 12
        Me.txtCantidad.Text = "0.00"
        Me.txtCantidad.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'txtIdProd
        '
        Me.txtIdProd.Location = New System.Drawing.Point(75, 376)
        Me.txtIdProd.Name = "txtIdProd"
        Me.txtIdProd.Numeric = True
        Me.txtIdProd.Size = New System.Drawing.Size(88, 20)
        Me.txtIdProd.TabIndex = 13
        Me.txtIdProd.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.Image = Global.FacturaNET.My.Resources.Resources.delete
        Me.btnDelete.Location = New System.Drawing.Point(654, 147)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(36, 36)
        Me.btnDelete.TabIndex = 16
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = Global.FacturaNET.My.Resources.Resources.add_prod5
        Me.Button3.Location = New System.Drawing.Point(252, 367)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(36, 36)
        Me.Button3.TabIndex = 15
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = Global.FacturaNET.My.Resources.Resources.add
        Me.Button1.Location = New System.Drawing.Point(210, 367)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(36, 36)
        Me.Button1.TabIndex = 14
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.FacturaNET.My.Resources.Resources.buscar
        Me.Button2.Location = New System.Drawing.Point(168, 367)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(36, 36)
        Me.Button2.TabIndex = 13
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(399, 367)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "SubTotal:"
        '
        'lblIVA
        '
        Me.lblIVA.Location = New System.Drawing.Point(368, 389)
        Me.lblIVA.Name = "lblIVA"
        Me.lblIVA.Size = New System.Drawing.Size(84, 13)
        Me.lblIVA.TabIndex = 18
        Me.lblIVA.Text = "I.V.A.(0%):"
        Me.lblIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(418, 411)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Total:"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Location = New System.Drawing.Point(458, 364)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(113, 20)
        Me.txtSubTotal.TabIndex = 20
        Me.txtSubTotal.Text = "0.00"
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIVA
        '
        Me.txtIVA.Location = New System.Drawing.Point(458, 386)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.ReadOnly = True
        Me.txtIVA.Size = New System.Drawing.Size(113, 20)
        Me.txtIVA.TabIndex = 21
        Me.txtIVA.Text = "0.00"
        Me.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(458, 408)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(113, 20)
        Me.txtTotal.TabIndex = 22
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(236, 443)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 23
        Me.Button4.Text = "Aceptar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(317, 443)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 24
        Me.Button5.Text = "Cancelar"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(387, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Metodos Pago:"
        '
        'txtMetodosPago
        '
        Me.txtMetodosPago.Location = New System.Drawing.Point(468, 14)
        Me.txtMetodosPago.Name = "txtMetodosPago"
        Me.txtMetodosPago.Size = New System.Drawing.Size(105, 20)
        Me.txtMetodosPago.TabIndex = 26
        Me.txtMetodosPago.Text = "Deposito En Cuenta"
        '
        'frmFactura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 476)
        Me.Controls.Add(Me.txtMetodosPago)
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
    Friend WithEvents txtMetodosPago As System.Windows.Forms.TextBox
End Class

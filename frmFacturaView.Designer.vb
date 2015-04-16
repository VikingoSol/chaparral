<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturaView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturaView))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtSerie = New System.Windows.Forms.TextBox
        Me.txtFolio = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtDireccion = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtRFC = New System.Windows.Forms.TextBox
        Me.txtCliente = New System.Windows.Forms.TextBox
        Me.grdProductos = New Janus.Windows.GridEX.GridEX
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblIVA = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtSubTotal = New System.Windows.Forms.TextBox
        Me.txtIVA = New System.Windows.Forms.TextBox
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtMetodosPago = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.txtRetIVA = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtCuenta = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtEstado = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtFecha = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.txtAcuse = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtSelloEmisor = New System.Windows.Forms.TextBox
        Me.txtSelloSAT = New System.Windows.Forms.TextBox
        Me.txtCadenaOrig = New System.Windows.Forms.TextBox
        Me.txtCertificadoSAT = New System.Windows.Forms.TextBox
        Me.txtFecha_Cer = New System.Windows.Forms.TextBox
        Me.txtFolioFiscal = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Serie:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(82, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Folio:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(204, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Cliente:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "R.F.C."
        '
        'txtSerie
        '
        Me.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerie.Location = New System.Drawing.Point(46, 19)
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
        Me.txtFolio.Location = New System.Drawing.Point(120, 16)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.ReadOnly = True
        Me.txtFolio.Size = New System.Drawing.Size(79, 24)
        Me.txtFolio.TabIndex = 7
        Me.txtFolio.Text = "0"
        Me.txtFolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDireccion)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtRFC)
        Me.GroupBox1.Controls.Add(Me.txtCliente)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(565, 125)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cliente"
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(71, 68)
        Me.txtDireccion.Multiline = True
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDireccion.Size = New System.Drawing.Size(481, 48)
        Me.txtDireccion.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Domicilio:"
        '
        'txtRFC
        '
        Me.txtRFC.Location = New System.Drawing.Point(70, 43)
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.ReadOnly = True
        Me.txtRFC.Size = New System.Drawing.Size(188, 20)
        Me.txtRFC.TabIndex = 10
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(70, 19)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(311, 20)
        Me.txtCliente.TabIndex = 9
        '
        'grdProductos
        '
        Me.grdProductos.AllowCardSizing = False
        Me.grdProductos.AllowColumnDrag = False
        Me.grdProductos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        grdProductos_DesignTimeLayout.LayoutString = resources.GetString("grdProductos_DesignTimeLayout.LayoutString")
        Me.grdProductos.DesignTimeLayout = grdProductos_DesignTimeLayout
        Me.grdProductos.GroupByBoxVisible = False
        Me.grdProductos.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grdProductos.Location = New System.Drawing.Point(5, 200)
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.Size = New System.Drawing.Size(585, 207)
        Me.grdProductos.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(396, 416)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "SubTotal:"
        '
        'lblIVA
        '
        Me.lblIVA.Location = New System.Drawing.Point(365, 438)
        Me.lblIVA.Name = "lblIVA"
        Me.lblIVA.Size = New System.Drawing.Size(84, 13)
        Me.lblIVA.TabIndex = 18
        Me.lblIVA.Text = "I.V.A.(0%):"
        Me.lblIVA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(415, 484)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Total:"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Location = New System.Drawing.Point(455, 413)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(113, 20)
        Me.txtSubTotal.TabIndex = 20
        Me.txtSubTotal.Text = "0.00"
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIVA
        '
        Me.txtIVA.Location = New System.Drawing.Point(455, 435)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.ReadOnly = True
        Me.txtIVA.Size = New System.Drawing.Size(113, 20)
        Me.txtIVA.TabIndex = 21
        Me.txtIVA.Text = "0.00"
        Me.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(455, 481)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(113, 20)
        Me.txtTotal.TabIndex = 22
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(267, 541)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 23
        Me.Button4.Text = "Aceptar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Metodos Pago:"
        '
        'txtMetodosPago
        '
        Me.txtMetodosPago.Location = New System.Drawing.Point(87, 45)
        Me.txtMetodosPago.Name = "txtMetodosPago"
        Me.txtMetodosPago.ReadOnly = True
        Me.txtMetodosPago.Size = New System.Drawing.Size(142, 20)
        Me.txtMetodosPago.TabIndex = 26
        Me.txtMetodosPago.Text = "Deposito En Cuenta"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(3, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(603, 533)
        Me.TabControl1.TabIndex = 27
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtRetIVA)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.txtCuenta)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.txtEstado)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.txtFecha)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtMetodosPago)
        Me.TabPage1.Controls.Add(Me.txtTotal)
        Me.TabPage1.Controls.Add(Me.txtIVA)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtSubTotal)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.lblIVA)
        Me.TabPage1.Controls.Add(Me.txtSerie)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtFolio)
        Me.TabPage1.Controls.Add(Me.grdProductos)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(595, 507)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Datos Generales"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtRetIVA
        '
        Me.txtRetIVA.Location = New System.Drawing.Point(455, 458)
        Me.txtRetIVA.Name = "txtRetIVA"
        Me.txtRetIVA.ReadOnly = True
        Me.txtRetIVA.Size = New System.Drawing.Size(113, 20)
        Me.txtRetIVA.TabIndex = 41
        Me.txtRetIVA.Text = "0.00"
        Me.txtRetIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(365, 461)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 13)
        Me.Label19.TabIndex = 40
        Me.Label19.Text = "Ret. I.V.A:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCuenta
        '
        Me.txtCuenta.Location = New System.Drawing.Point(285, 45)
        Me.txtCuenta.MaxLength = 4
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.ReadOnly = True
        Me.txtCuenta.Size = New System.Drawing.Size(63, 20)
        Me.txtCuenta.TabIndex = 38
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(235, 49)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 13)
        Me.Label18.TabIndex = 39
        Me.Label18.Text = "Cuenta:"
        '
        'txtEstado
        '
        Me.txtEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstado.Location = New System.Drawing.Point(455, 19)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(100, 20)
        Me.txtEstado.TabIndex = 29
        Me.txtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(406, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 13)
        Me.Label17.TabIndex = 28
        Me.Label17.Text = "Estado:"
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(250, 19)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(146, 20)
        Me.txtFecha.TabIndex = 27
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtAcuse)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.txtSelloEmisor)
        Me.TabPage2.Controls.Add(Me.txtSelloSAT)
        Me.TabPage2.Controls.Add(Me.txtCadenaOrig)
        Me.TabPage2.Controls.Add(Me.txtCertificadoSAT)
        Me.TabPage2.Controls.Add(Me.txtFecha_Cer)
        Me.TabPage2.Controls.Add(Me.txtFolioFiscal)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(595, 507)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Datos SAT"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtAcuse
        '
        Me.txtAcuse.Location = New System.Drawing.Point(11, 348)
        Me.txtAcuse.Multiline = True
        Me.txtAcuse.Name = "txtAcuse"
        Me.txtAcuse.ReadOnly = True
        Me.txtAcuse.Size = New System.Drawing.Size(572, 63)
        Me.txtAcuse.TabIndex = 13
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(15, 331)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 13)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Acuse XML:"
        '
        'txtSelloEmisor
        '
        Me.txtSelloEmisor.Location = New System.Drawing.Point(11, 267)
        Me.txtSelloEmisor.Multiline = True
        Me.txtSelloEmisor.Name = "txtSelloEmisor"
        Me.txtSelloEmisor.ReadOnly = True
        Me.txtSelloEmisor.Size = New System.Drawing.Size(572, 54)
        Me.txtSelloEmisor.TabIndex = 11
        '
        'txtSelloSAT
        '
        Me.txtSelloSAT.Location = New System.Drawing.Point(11, 187)
        Me.txtSelloSAT.Multiline = True
        Me.txtSelloSAT.Name = "txtSelloSAT"
        Me.txtSelloSAT.ReadOnly = True
        Me.txtSelloSAT.Size = New System.Drawing.Size(572, 54)
        Me.txtSelloSAT.TabIndex = 10
        '
        'txtCadenaOrig
        '
        Me.txtCadenaOrig.Location = New System.Drawing.Point(11, 98)
        Me.txtCadenaOrig.Multiline = True
        Me.txtCadenaOrig.Name = "txtCadenaOrig"
        Me.txtCadenaOrig.ReadOnly = True
        Me.txtCadenaOrig.Size = New System.Drawing.Size(572, 63)
        Me.txtCadenaOrig.TabIndex = 9
        '
        'txtCertificadoSAT
        '
        Me.txtCertificadoSAT.Location = New System.Drawing.Point(116, 50)
        Me.txtCertificadoSAT.Name = "txtCertificadoSAT"
        Me.txtCertificadoSAT.ReadOnly = True
        Me.txtCertificadoSAT.Size = New System.Drawing.Size(167, 20)
        Me.txtCertificadoSAT.TabIndex = 8
        '
        'txtFecha_Cer
        '
        Me.txtFecha_Cer.Location = New System.Drawing.Point(377, 19)
        Me.txtFecha_Cer.Name = "txtFecha_Cer"
        Me.txtFecha_Cer.ReadOnly = True
        Me.txtFecha_Cer.Size = New System.Drawing.Size(159, 20)
        Me.txtFecha_Cer.TabIndex = 7
        '
        'txtFolioFiscal
        '
        Me.txtFolioFiscal.Location = New System.Drawing.Point(116, 19)
        Me.txtFolioFiscal.Name = "txtFolioFiscal"
        Me.txtFolioFiscal.ReadOnly = True
        Me.txtFolioFiscal.Size = New System.Drawing.Size(150, 20)
        Me.txtFolioFiscal.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(15, 250)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 13)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Sello Digital Emisor:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 54)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(104, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "No. Certificado SAT:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(25, 170)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Sello Digital SAT:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 82)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(106, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Cadena Original SAT"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(273, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Fecha Certificacion:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(54, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Folio Fisca:"
        '
        'frmFacturaView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 570)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Button4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFacturaView"
        Me.Text = "Factura"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRFC As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents grdProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblIVA As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtIVA As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMetodosPago As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCertificadoSAT As System.Windows.Forms.TextBox
    Friend WithEvents txtFecha_Cer As System.Windows.Forms.TextBox
    Friend WithEvents txtFolioFiscal As System.Windows.Forms.TextBox
    Friend WithEvents txtSelloEmisor As System.Windows.Forms.TextBox
    Friend WithEvents txtSelloSAT As System.Windows.Forms.TextBox
    Friend WithEvents txtCadenaOrig As System.Windows.Forms.TextBox
    Friend WithEvents txtAcuse As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtRetIVA As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class

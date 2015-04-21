<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturas
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
        Dim grdFacturas_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturas))
        Me.grdFacturas = New Janus.Windows.GridEX.GridEX
        Me.Label1 = New System.Windows.Forms.Label
        Me.dpFecha = New System.Windows.Forms.DateTimePicker
        Me.btnClose = New System.Windows.Forms.Button
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnExpXML = New System.Windows.Forms.Button
        Me.btnToPDF = New System.Windows.Forms.Button
        Me.btnImprimir = New System.Windows.Forms.Button
        Me.btnDel = New System.Windows.Forms.Button
        Me.btnView = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnActualizar = New System.Windows.Forms.Button
        CType(Me.grdFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdFacturas
        '
        Me.grdFacturas.AllowCardSizing = False
        Me.grdFacturas.AllowColumnDrag = False
        Me.grdFacturas.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdFacturas.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdFacturas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        grdFacturas_DesignTimeLayout.LayoutString = resources.GetString("grdFacturas_DesignTimeLayout.LayoutString")
        Me.grdFacturas.DesignTimeLayout = grdFacturas_DesignTimeLayout
        Me.grdFacturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdFacturas.GroupByBoxVisible = False
        Me.grdFacturas.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grdFacturas.Location = New System.Drawing.Point(4, 47)
        Me.grdFacturas.Name = "grdFacturas"
        Me.grdFacturas.Size = New System.Drawing.Size(997, 372)
        Me.grdFacturas.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Facturas Desde:"
        '
        'dpFecha
        '
        Me.dpFecha.CustomFormat = "dd / MMM / yyyy"
        Me.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFecha.Location = New System.Drawing.Point(103, 13)
        Me.dpFecha.Name = "dpFecha"
        Me.dpFecha.Size = New System.Drawing.Size(132, 20)
        Me.dpFecha.TabIndex = 12
        '
        'btnClose
        '
        Me.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnClose.Location = New System.Drawing.Point(475, 428)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 14
        Me.btnClose.Text = "Cerrar"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'PrintDialog1
        '
        Me.PrintDialog1.AllowPrintToFile = False
        Me.PrintDialog1.UseEXDialog = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Archivo PDF (*.pdf) |*.pdf"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Image = Global.FacturaNET.My.Resources.Resources.excel_8
        Me.Button2.Location = New System.Drawing.Point(1007, 339)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(36, 36)
        Me.Button2.TabIndex = 15
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = Global.FacturaNET.My.Resources.Resources.filtro
        Me.Button1.Location = New System.Drawing.Point(241, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(36, 36)
        Me.Button1.TabIndex = 13
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnExpXML
        '
        Me.btnExpXML.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExpXML.Enabled = False
        Me.btnExpXML.Image = Global.FacturaNET.My.Resources.Resources.Xml
        Me.btnExpXML.Location = New System.Drawing.Point(1007, 297)
        Me.btnExpXML.Name = "btnExpXML"
        Me.btnExpXML.Size = New System.Drawing.Size(36, 36)
        Me.btnExpXML.TabIndex = 10
        Me.btnExpXML.UseVisualStyleBackColor = True
        '
        'btnToPDF
        '
        Me.btnToPDF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnToPDF.Enabled = False
        Me.btnToPDF.Image = Global.FacturaNET.My.Resources.Resources.pdf
        Me.btnToPDF.Location = New System.Drawing.Point(1007, 255)
        Me.btnToPDF.Name = "btnToPDF"
        Me.btnToPDF.Size = New System.Drawing.Size(36, 36)
        Me.btnToPDF.TabIndex = 10
        Me.btnToPDF.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.Enabled = False
        Me.btnImprimir.Image = Global.FacturaNET.My.Resources.Resources.imprimir1
        Me.btnImprimir.Location = New System.Drawing.Point(1007, 213)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(36, 36)
        Me.btnImprimir.TabIndex = 10
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDel.Enabled = False
        Me.btnDel.Image = Global.FacturaNET.My.Resources.Resources.delete
        Me.btnDel.Location = New System.Drawing.Point(1007, 171)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(36, 36)
        Me.btnDel.TabIndex = 10
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnView.Enabled = False
        Me.btnView.Image = Global.FacturaNET.My.Resources.Resources.buscar
        Me.btnView.Location = New System.Drawing.Point(1007, 129)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(36, 36)
        Me.btnView.TabIndex = 9
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Image = Global.FacturaNET.My.Resources.Resources.add
        Me.btnAdd.Location = New System.Drawing.Point(1007, 87)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(36, 36)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnActualizar
        '
        Me.btnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActualizar.Image = Global.FacturaNET.My.Resources.Resources.actualizar
        Me.btnActualizar.Location = New System.Drawing.Point(1007, 45)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(36, 36)
        Me.btnActualizar.TabIndex = 7
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'frmFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1048, 459)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dpFecha)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExpXML)
        Me.Controls.Add(Me.btnToPDF)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.grdFacturas)
        Me.Name = "frmFacturas"
        Me.Text = "Facturas"
        CType(Me.grdFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents grdFacturas As Janus.Windows.GridEX.GridEX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnToPDF As System.Windows.Forms.Button
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnExpXML As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class

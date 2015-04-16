<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductos))
        Me.grdProductos = New Janus.Windows.GridEX.GridEX
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnDel = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnActualizar = New System.Windows.Forms.Button
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.grdProductos.Location = New System.Drawing.Point(4, 4)
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.Size = New System.Drawing.Size(601, 222)
        Me.grdProductos.TabIndex = 6
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSalir.Location = New System.Drawing.Point(288, 235)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 11
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDel.Enabled = False
        Me.btnDel.Image = Global.FacturaNET.My.Resources.Resources.delete
        Me.btnDel.Location = New System.Drawing.Point(611, 129)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(36, 36)
        Me.btnDel.TabIndex = 10
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Enabled = False
        Me.btnEdit.Image = Global.FacturaNET.My.Resources.Resources.edit
        Me.btnEdit.Location = New System.Drawing.Point(611, 87)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(36, 36)
        Me.btnEdit.TabIndex = 9
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Image = Global.FacturaNET.My.Resources.Resources.add
        Me.btnAdd.Location = New System.Drawing.Point(611, 45)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(36, 36)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnActualizar
        '
        Me.btnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActualizar.Image = Global.FacturaNET.My.Resources.Resources.actualizar
        Me.btnActualizar.Location = New System.Drawing.Point(611, 3)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(36, 36)
        Me.btnActualizar.TabIndex = 7
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'frmProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 266)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.grdProductos)
        Me.Name = "frmProductos"
        Me.Text = "Productos y Servicios"
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents grdProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnSalir As System.Windows.Forms.Button
End Class

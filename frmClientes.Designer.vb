<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientes
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
        Dim grdClientes_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClientes))
        Me.grdClientes = New Janus.Windows.GridEX.GridEX
        Me.btnCerrar = New System.Windows.Forms.Button
        Me.btnDel = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnActualizar = New System.Windows.Forms.Button
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdClientes
        '
        Me.grdClientes.AllowCardSizing = False
        Me.grdClientes.AllowColumnDrag = False
        Me.grdClientes.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.grdClientes.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.grdClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        grdClientes_DesignTimeLayout.LayoutString = resources.GetString("grdClientes_DesignTimeLayout.LayoutString")
        Me.grdClientes.DesignTimeLayout = grdClientes_DesignTimeLayout
        Me.grdClientes.GroupByBoxVisible = False
        Me.grdClientes.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grdClientes.Location = New System.Drawing.Point(2, 4)
        Me.grdClientes.Name = "grdClientes"
        Me.grdClientes.Size = New System.Drawing.Size(458, 223)
        Me.grdClientes.TabIndex = 0
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCerrar.Location = New System.Drawing.Point(215, 236)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDel.Enabled = False
        Me.btnDel.Image = Global.FacturaNET.My.Resources.Resources.delete
        Me.btnDel.Location = New System.Drawing.Point(464, 130)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(36, 36)
        Me.btnDel.TabIndex = 5
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Enabled = False
        Me.btnEdit.Image = Global.FacturaNET.My.Resources.Resources.edit
        Me.btnEdit.Location = New System.Drawing.Point(464, 88)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(36, 36)
        Me.btnEdit.TabIndex = 4
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Image = Global.FacturaNET.My.Resources.Resources.add
        Me.btnAdd.Location = New System.Drawing.Point(464, 46)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(36, 36)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnActualizar
        '
        Me.btnActualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActualizar.Image = Global.FacturaNET.My.Resources.Resources.actualizar
        Me.btnActualizar.Location = New System.Drawing.Point(464, 4)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(36, 36)
        Me.btnActualizar.TabIndex = 2
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'frmClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 266)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.grdClientes)
        Me.Name = "frmClientes"
        Me.Text = "Clientes"
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdClientes As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
End Class

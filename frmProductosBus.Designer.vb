<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductosBus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductosBus))
        Me.grdProductos = New Janus.Windows.GridEX.GridEX
        Me.btnOk = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
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
        Me.grdProductos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.grdProductos.GroupByBoxVisible = False
        Me.grdProductos.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grdProductos.Location = New System.Drawing.Point(3, 3)
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.Size = New System.Drawing.Size(502, 222)
        Me.grdProductos.TabIndex = 7
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(180, 235)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 8
        Me.btnOk.Text = "Aceptar"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(261, 235)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmProductosBus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(517, 266)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.grdProductos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmProductosBus"
        Me.Text = "Buscar Productos"
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class

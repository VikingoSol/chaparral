<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClienteBus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClienteBus))
        Me.grdClientes = New Janus.Windows.GridEX.GridEX
        Me.btnOk = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
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
        Me.grdClientes.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.grdClientes.GroupByBoxVisible = False
        Me.grdClientes.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight
        Me.grdClientes.Location = New System.Drawing.Point(3, 2)
        Me.grdClientes.Name = "grdClientes"
        Me.grdClientes.Size = New System.Drawing.Size(516, 223)
        Me.grdClientes.TabIndex = 1
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(183, 234)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "Aceptar"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(264, 234)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Cancelar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmClienteBus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 266)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.grdClientes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmClienteBus"
        Me.Text = "Buscar Cliente"
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdClientes As Janus.Windows.GridEX.GridEX
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class

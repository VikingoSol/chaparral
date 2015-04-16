<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportarXML
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.dpFecha1 = New System.Windows.Forms.DateTimePicker
        Me.dpFecha2 = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbExportarA = New System.Windows.Forms.ComboBox
        Me.btnExportar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fechas:"
        '
        'dpFecha1
        '
        Me.dpFecha1.CustomFormat = "dd / MMM / yyyy"
        Me.dpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFecha1.Location = New System.Drawing.Point(83, 25)
        Me.dpFecha1.Name = "dpFecha1"
        Me.dpFecha1.Size = New System.Drawing.Size(114, 20)
        Me.dpFecha1.TabIndex = 1
        '
        'dpFecha2
        '
        Me.dpFecha2.CustomFormat = "dd / MMM / yyyy"
        Me.dpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFecha2.Location = New System.Drawing.Point(203, 25)
        Me.dpFecha2.Name = "dpFecha2"
        Me.dpFecha2.Size = New System.Drawing.Size(116, 20)
        Me.dpFecha2.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Exportar:"
        '
        'cmbExportarA
        '
        Me.cmbExportarA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbExportarA.FormattingEnabled = True
        Me.cmbExportarA.Items.AddRange(New Object() {"A Carpeta", "En Archivo ZIP"})
        Me.cmbExportarA.Location = New System.Drawing.Point(88, 53)
        Me.cmbExportarA.Name = "cmbExportarA"
        Me.cmbExportarA.Size = New System.Drawing.Size(166, 21)
        Me.cmbExportarA.TabIndex = 4
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(97, 86)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(75, 23)
        Me.btnExportar.TabIndex = 5
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(181, 86)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Archivo ZIP(*.zip)|*.zip"
        '
        'frmExportarXML
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 119)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.cmbExportarA)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dpFecha2)
        Me.Controls.Add(Me.dpFecha1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExportarXML"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportar XML de Facturas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dpFecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dpFecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbExportarA As System.Windows.Forms.ComboBox
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
End Class

Imports BaseDatos
Public Class frmProductosBus
    Public vidcliente As Integer

    Public Function Buscar_Producto() As Integer
        Dim vProds As New cProductos
        Me.grdProductos.DataSource = vProds.GetProductosClientes(vidcliente)
        If Me.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return Me.grdProductos.GetRow.Cells("id").Value
        Else
            Return 0
        End If
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim vProds As New cProductos
        'Me.grdProductos.DataSource = vProds.GetProductos
        Me.grdProductos.DataSource = vProds.GetProductosClientes(vidcliente)
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Seleccionar_Prod()
    End Sub

    Private Sub Seleccionar_Prod()
        If Not IsNothing(Me.grdProductos.GetRow) AndAlso Me.grdProductos.GetRow.RowType = Janus.Windows.GridEX.RowType.Record Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub grdProductos_RowDoubleClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles grdProductos.RowDoubleClick
        Seleccionar_Prod()
    End Sub

    Private Sub frmProductosBus_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.grdProductos.Row = Janus.Windows.GridEX.GridEX.filterRowPosition
        Me.grdProductos.Col = Me.grdProductos.RootTable.Columns("nombre").Position
    End Sub
End Class
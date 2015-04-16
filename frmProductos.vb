Imports BaseDatos
Public Class frmProductos
    Private Shared _ObjSingleton As frmProductos = Nothing

    Public Shared Function GetInstance() As frmProductos
        If _ObjSingleton Is Nothing OrElse _
        _ObjSingleton.IsDisposed = True Then
            _ObjSingleton = New frmProductos
        End If
        Return _ObjSingleton
    End Function

    Private Sub mostrar_prods()
        Dim vProds As New cProductos
        Me.grdProductos.DataSource = vProds.GetProductos
    End Sub


    Private Sub frmProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Me.mostrar_prods()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.mostrar_prods()
        Dim vProds As New cProductos
        Dim vUnis As DataTable = vProds.GetUnidades()
        If Not IsNothing(vUnis) Then
            Me.grdProductos.RootTable.Columns("unidad").ValueList.PopulateValueList(vUnis.DefaultView, "id", "unidad")
        End If

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim vId As Integer
        Dim vProd As New frmProducto
        vId = vProd.Agregar()
        If vId > 0 Then
            Me.mostrar_prods()
            Me.grdProductos.Find(Me.grdProductos.RootTable.Columns("id"), Janus.Windows.GridEX.ConditionOperator.Equal, vId, -1, 1)
        End If
    End Sub

    Private Sub grdProductos_DeletingRecord(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionCancelEventArgs) Handles grdProductos.DeletingRecord
        If MsgBox("¿Esta seguro de eliminar el producto / servicio?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "¿Eliminar?") = MsgBoxResult.Yes Then
            Dim vProds As New cProductos
            vProds.Eliminar(e.Row.Cells("id").Value)
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub grdProductos_FormattingRow(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles grdProductos.FormattingRow

    End Sub

    Private Sub grdProductos_RowCountChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProductos.RowCountChanged
        If Me.grdProductos.RowCount <= 0 Then
            Me.btnDel.Enabled = False
            Me.btnEdit.Enabled = False
        End If
    End Sub

    Private Sub grdProductos_RowDoubleClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles grdProductos.RowDoubleClick
        If e.Row.RowType = Janus.Windows.GridEX.RowType.Record Then
            Me.btnEdit.PerformClick()
        End If
    End Sub

    Private Sub grdProductos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProductos.SelectionChanged
        If IsNothing(Me.grdProductos.GetRow) Then
            Me.btnDel.Enabled = False
            Me.btnEdit.Enabled = False
        ElseIf Me.grdProductos.GetRow.RowType = Janus.Windows.GridEX.RowType.Record Then
            Me.btnDel.Enabled = True
            Me.btnEdit.Enabled = True
        Else
            Me.btnDel.Enabled = False
            Me.btnEdit.Enabled = False
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim vProds As New frmProducto
        Dim vId As Integer = Me.grdProductos.GetRow.Cells("id").Value
        If vProds.Modificar(vid) Then
            Me.mostrar_prods()
            Me.grdProductos.Find(Me.grdProductos.RootTable.Columns("id"), Janus.Windows.GridEX.ConditionOperator.Equal, vId, -1, 1)
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        Me.grdProductos.Delete()
    End Sub
End Class
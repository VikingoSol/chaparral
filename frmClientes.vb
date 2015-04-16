Imports BaseDatos
Public Class frmClientes
    Private Shared _ObjSingleton As frmClientes = Nothing

    Public Shared Function GetInstance() As frmClientes
        If _ObjSingleton Is Nothing OrElse _
        _ObjSingleton.IsDisposed = True Then
            _ObjSingleton = New frmClientes
        End If
        Return _ObjSingleton
    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Mostrar_Clientes()
    End Sub

    Private Sub Mostrar_Clientes()
        Dim vClientes As New cClientes
        Me.grdClientes.DataSource = vClientes.GetClientes()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Mostrar_Clientes()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim vCliente As New frmCliente
        Dim vIdNvo As Integer = vCliente.Nuevo
        If vIdNvo > 0 Then
            Me.Mostrar_Clientes()
            Me.grdClientes.Find(Me.grdClientes.RootTable.Columns("id"), Janus.Windows.GridEX.ConditionOperator.Equal, vIdNvo, -1, 1)
        End If
    End Sub

    Private Sub grdClientes_DeletingRecord(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionCancelEventArgs) Handles grdClientes.DeletingRecord
        If MsgBox("¿Esta seguro de eliminar el cliente?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "¿Eliminar?") <> MsgBoxResult.Yes Then
            e.Cancel = True
        Else
            Dim vCls As New cClientes
            vCls.Eliminar(e.Row.Cells("id").Value)
        End If
    End Sub

    Private Sub grdClientes_FormattingRow(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles grdClientes.FormattingRow

    End Sub

    Private Sub grdClientes_RowCountChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdClientes.RowCountChanged
        If Me.grdClientes.RowCount = 0 Then
            Me.btnDel.Enabled = False
            Me.btnEdit.Enabled = False
        End If
    End Sub

    Private Sub grdClientes_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdClientes.SelectionChanged
        If Not IsNothing(Me.grdClientes.GetRow) Then
            Me.btnDel.Enabled = True
            Me.btnEdit.Enabled = True
        Else
            Me.btnDel.Enabled = False
            Me.btnEdit.Enabled = False
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim vCl As New frmCliente
        Dim vId As Integer
        vId = Me.grdClientes.GetRow.Cells("id").Value
        If vCl.Modificar(vId) Then
            Me.Mostrar_Clientes()
            Me.grdClientes.Find(Me.grdClientes.RootTable.Columns("id"), Janus.Windows.GridEX.ConditionOperator.Equal, vId, -1, 1)
        End If
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        Me.grdClientes.Delete()
    End Sub
End Class
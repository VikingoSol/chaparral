
Imports BaseDatos
Public Class frmClienteBus

    Public Function Buscar_Cliente() As Integer
        If Me.ShowDialog = Windows.Forms.DialogResult.OK Then
            If Not IsNothing(Me.grdClientes.GetRow) Then
                Return Me.grdClientes.GetRow.Cells("id").Value
            Else
                Return 0
            End If
        Else
            Return 0
        End If
    End Function


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmClienteBus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim vClientes As New cClientes
        Me.grdClientes.DataSource = vClientes.GetClientes()


    End Sub

    Private Sub frmClienteBus_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.grdClientes.Row = Janus.Windows.GridEX.GridEX.filterRowPosition
        Me.grdClientes.Col = Me.grdClientes.RootTable.Columns("cliente").Position
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If Not IsNothing(Me.grdClientes.GetRow) AndAlso Me.grdClientes.GetRow.RowType = Janus.Windows.GridEX.RowType.Record Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            Me.DialogResult = Windows.Forms.DialogResult.None
        End If
    End Sub

    Private Sub grdClientes_FormattingRow(ByVal sender As System.Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles grdClientes.FormattingRow

    End Sub

    Private Sub grdClientes_RowDoubleClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles grdClientes.RowDoubleClick
        Me.btnOk.PerformClick()
    End Sub
End Class
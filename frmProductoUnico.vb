Imports BaseDatos
Public Class frmProductoUnico
    Dim vIdProd As Integer = 0

    Public Function Agregar() As dProductoUnico
        If Me.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim vProd As New dProductoUnico
            vProd.Id = vIdProd
            vProd.Nombre = Me.txtNombre.Text
            vProd.Cantidad = Me.txtCantidad.Text
            vProd.Precio = Me.txtPrecio.Text
            vProd.Unidad = Me.cmbUnidades.SelectedValue
            vProd.UnidadNom = Me.cmbUnidades.Text
            vProd.TasaID = Me.cmbTasa.SelectedValue
            vProd.TasaPorc = CType(Me.cmbTasa.SelectedItem, DataRowView).Item("tasa")
            Return vProd
        Else : Return Nothing
        End If
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Trim(Me.txtNombre.Text) = "" Then
            MsgBox("Especifique el nombre del producto y/o servicio", MsgBoxStyle.Critical, "¿Nombre?")
            Me.txtNombre.Focus()
            Exit Sub
        End If
        If Me.txtCantidad.Text <= 0 Then
            MsgBox("La cantidad del Producto / Servicio debe de ser mayor a cero", MsgBoxStyle.Critical, "¿Precio?")
            Me.txtCantidad.SelectAll()
            Me.txtCantidad.Focus()
            Exit Sub
        End If
        If Me.txtPrecio.Text <= 0 Then
            MsgBox("El precio debe de ser mayor a cero", MsgBoxStyle.Critical, "¿Precio?")
            Me.txtPrecio.SelectAll()
            Me.txtPrecio.Focus()
            Exit Sub
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim vProds As New cProductos
        Me.cmbUnidades.DisplayMember = "unidad"
        Me.cmbUnidades.ValueMember = "id"
        Me.cmbUnidades.DataSource = vProds.GetUnidades

        Me.cmbTasa.DisplayMember = "nombre"
        Me.cmbTasa.ValueMember = "id"
        Me.cmbTasa.DataSource = vProds.GetTasas

    End Sub
End Class

Public Class dProductoUnico
    Public Id As Integer
    Public Nombre As String
    Public Cantidad As Double
    Public Unidad As Integer
    Public UnidadNom As String
    Public Precio As Double
    Public TasaID As Integer
    Public TasaPorc As Double
End Class
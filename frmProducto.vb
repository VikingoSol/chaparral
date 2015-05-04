Imports BaseDatos
Public Class frmProducto
    Dim vIdProd As Integer = -1

    Public Function Modificar(ByVal pId As Integer) As Boolean
        Dim vProds As New cProductos
        Dim vProd As dProducto = vProds.GetProducto(pId)
        If IsNothing(vProd) Then Return False
        vIdProd = pId
        Me.txtId.Text = pId
        Me.txtNombre.Text = vProd.Nombre
        Me.txtPrecio.Text = vProd.Precio
        Me.cmbUnidades.SelectedValue = vProd.Unidad
        Me.cmbTasa.SelectedValue = vProd.TasaId
        Me.Txtcodigo.Text = vProd.codigo
        Me.Cmbidprodcte.SelectedValue = vProd.idProdcte
        If Me.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return True
        Else : Return False
        End If
    End Function

    Public Function Agregar() As Integer
        If Me.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return vIdProd
        Else : Return -1
        End If
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Trim(Me.Txtcodigo.Text) = "" Then
            MsgBox("Especifique el Codigo del producto y/o servicio", MsgBoxStyle.Critical, "¿Nombre?")
            Me.Txtcodigo.Focus()
            Exit Sub
        End If
        If Trim(Me.txtNombre.Text) = "" Then
            MsgBox("Especifique el nombre del producto y/o servicio", MsgBoxStyle.Critical, "¿Nombre?")
            Me.txtNombre.Focus()
            Exit Sub
        End If
        If Me.txtPrecio.Text <= 0 Then
            MsgBox("El precio debe de ser mayor a cero", MsgBoxStyle.Critical, "¿Precio?")
            Me.txtPrecio.SelectAll()
            Me.txtPrecio.Focus()
            Exit Sub
        End If
        Dim vProds As New cProductos
        If vProds.Existe(Me.txtNombre.Text, Me.vIdProd) Then
            MsgBox("Ya existe un Producto/Servicio con el mismo nombre", MsgBoxStyle.Critical, "Producto / Servicio Existente")
            Me.txtNombre.SelectAll()
            Me.txtNombre.Focus()
            'Exit Sub
        End If
        If vIdProd = -1 Then
            vIdProd = vProds.Agregar(Me.txtNombre.Text, Me.txtPrecio.Text, Me.cmbUnidades.SelectedValue, Me.cmbTasa.SelectedValue, Me.Txtcodigo.Text, Me.Cmbidprodcte.SelectedValue, Me.Cmbidprodcte.Text)
        Else
            vProds.Modificar(Me.vIdProd, Me.txtNombre.Text, Me.txtPrecio.Text, Me.cmbUnidades.SelectedValue, Me.cmbTasa.SelectedValue, Me.Txtcodigo.Text, Me.Cmbidprodcte.SelectedValue, Me.Cmbidprodcte.Text)
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

        Dim vClientes As New BaseDatos.cClientes
        Me.Cmbidprodcte.DisplayMember = "nombre"
        Me.Cmbidprodcte.ValueMember = "id"
        Me.Cmbidprodcte.DataSource = vClientes.GetClientes()
  
    End Sub
End Class
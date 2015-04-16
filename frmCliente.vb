Imports BaseDatos
Public Class frmCliente
    Dim vIdCliente As Integer = -1

    Public Function Modificar(ByVal pId As Integer) As Boolean
        vIdCliente = pId
        Dim vClientes As New cClientes
        Dim vcl As dCliente = vClientes.GetCliente(pId)
        If IsNothing(vcl) Then Return False
        Me.txtId.Text = pId
        Me.txtNombre.Text = vcl.Nombre
        Me.txtRFC.Text = vcl.RFC
        Me.txtCalle.Text = vcl.Calle
        Me.txtCol.Text = vcl.Colonia
        Me.txtCP.Text = vcl.CP
        Me.txtEstado.Text = vcl.Estado
        Me.txtLoc.Text = vcl.Localidad
        Me.txtMunicipio.Text = vcl.Municipio
        Me.txtNoExt.Text = vcl.NoExterior
        Me.txtNoInt.Text = vcl.NoInterior
        Me.txtPais.Text = vcl.Pais
        Me.txtRef.Text = vcl.Referencia
        Me.chkRetiene.Checked = vcl.RetieneIva
        If Me.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return True
        Else : Return False
        End If
    End Function

    Public Function Nuevo() As Integer
        If Me.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return vIdCliente
        Else
            Return -1
        End If
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Trim(Me.txtNombre.Text) = "" Then
            MsgBox("Especifique el nombre o Razon social del cliente", MsgBoxStyle.Critical, "¿Nombre?")
            Me.txtNombre.Focus()
            Exit Sub
        End If
        If Not RFC_Check(Trim(Me.txtRFC.Text)) Then
            MsgBox("Especifique el R.F.C. del cliente", MsgBoxStyle.Critical, "¿R.F.C.?")
            Me.txtRFC.SelectAll()
            Me.txtRFC.Focus()
            Exit Sub
        End If
        'If Trim(Me.txtCalle.Text) = "" Then
        '    MsgBox("Especifique la calle de la dirección del cliente", MsgBoxStyle.Critical, "¿Calle?")
        '    Me.txtCalle.Focus()
        '    Exit Sub
        'End If
        'If Trim(Me.txtNoExt.Text) = "" Then
        '    MsgBox("Especifique el No. Exterior de la dirección del cliente", MsgBoxStyle.Critical, "¿No Exterior?")
        '    Me.txtNoExt.Focus()
        '    Exit Sub
        'End If
        'If Trim(Me.txtCol.Text) = "" Then
        '    MsgBox("Especifique la colonia de la dirección del cliente", MsgBoxStyle.Critical, "¿Colonia?")
        '    Me.txtCol.Focus()
        '    Exit Sub
        'End If
        'If Trim(Me.txtLoc.Text) = "" Then
        '    MsgBox("Especifique la Localidad / Ciudad de la dirección del cliente", MsgBoxStyle.Critical, "¿Localidad o Ciudad")
        '    Me.txtLoc.Focus()
        '    Exit Sub
        'End If
        If Trim(Me.txtPais.Text) = "" Then
            MsgBox("Especifique el pais de la dirección del cliente", MsgBoxStyle.Critical, "¿Pais?")
            Me.txtPais.Focus()
            Exit Sub
        End If

        Dim vClients As New cClientes
        If vClients.Existe_Cliente(Trim(Me.txtNombre.Text), vIdCliente) Then
            MsgBox("Ya existe un cliente con la misma razon social o nombre", MsgBoxStyle.Critical, "Cliente Existente")
            Me.txtNombre.SelectAll()
            Me.txtNombre.Focus()
            Exit Sub
        End If
        If vIdCliente = -1 Then
            vIdCliente = vClients.Agregar(Me.txtNombre.Text, Me.txtRFC.Text, Me.txtCalle.Text, Me.txtNoInt.Text, Me.txtNoExt.Text, Me.txtCol.Text, Me.txtLoc.Text, Me.txtRef.Text, Me.txtMunicipio.Text, Me.txtEstado.Text, Me.txtPais.Text, Me.txtCP.Text, Me.chkRetiene.Checked)
        Else
            vClients.Modificar(vIdCliente, Me.txtNombre.Text, Me.txtRFC.Text, Me.txtCalle.Text, Me.txtNoInt.Text, Me.txtNoExt.Text, Me.txtCol.Text, Me.txtLoc.Text, Me.txtRef.Text, Me.txtMunicipio.Text, Me.txtEstado.Text, Me.txtPais.Text, Me.txtCP.Text, Me.chkRetiene.Checked)
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub txtRFC_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRFC.LostFocus
        Me.txtRFC.Text = Trim(Me.txtRFC.Text.ToUpper)
        Me.txtRFC.Text = Replace(Me.txtRFC.Text, "-", "")
        Me.txtRFC.Text = Replace(Me.txtRFC.Text, " ", "")
        Me.txtRFC.Text = Replace(Me.txtRFC.Text, "_", "")        
    End Sub

    Private Sub txtRFC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRFC.TextChanged

    End Sub
End Class
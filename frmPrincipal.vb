Imports BaseDatos
Public Class frmPrincipal

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        End
    End Sub

    Private Sub frmPrincipal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim f As New Dialog1
        f.ShowDialog()
    End Sub

    Private Sub frmPrincipal_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Not IO.File.Exists(gConfigFile) Then
            MsgBox("No se ha configurado el acceso a la base de datos, es necesario configurarlo para que el sistema funcione correctamente", MsgBoxStyle.Critical, "¿Base de datos?")
            Dim vBd As New frmConfigBD
            If vBd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                gConfig.Guardar(gConfigFile)
            Else
                End
            End If
        Else
            gConfig = cConfigLocal.Leer(gConfigFile)
        End If
        Dim vConnected As Boolean = False
        While Not vConnected
            Try
                BaseDatos.Conectar_BaseDatos(gConfig)
                vConnected = True
            Catch ex As Exception
                MsgBox("No se ha podido conectar la base de datos, verifique los datos", MsgBoxStyle.Critical)
                Dim vBd As New frmConfigBD
                If vBd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    gConfig.Guardar(gConfigFile)
                End If
            End Try
        End While


        Dim cConfig As New cConfigGlobal
        gConfigGlobal = cConfig.GetConfiguracion


        gPathFactuacion = gPathDataSoft & gConfigGlobal.Registro_Federal & "\"
        gPathBarCodes = gPathDataSoft & gConfigGlobal.Registro_Federal & "\BarCodes\"

        
        BajarCertificadoKey()
        'PruebaError()
    End Sub

    Private Sub ConToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConToolStripMenuItem.Click
        Dim vCnfg As New frmConfig
        vCnfg.ShowDialog()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientesToolStripMenuItem.Click

    End Sub

    Private Sub CatalogoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CatalogoToolStripMenuItem.Click
        Dim vClientes As frmClientes = frmClientes.GetInstance
        vClientes.MdiParent = Me
        vClientes.Show()
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        Dim vCl As New frmCliente
        frmCliente.Nuevo()
    End Sub

    Private Sub CatalogoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CatalogoToolStripMenuItem1.Click
        Dim vProds As frmProductos = frmProductos.GetInstance
        vProds.MdiParent = Me
        vProds.Show()
    End Sub

    Private Sub AgergarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgergarToolStripMenuItem.Click
        Dim vProds As New frmProducto
        vProds.Agregar()
    End Sub

    Private Sub FacturasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturasToolStripMenuItem.Click

    End Sub

    Private Sub FacturasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturasToolStripMenuItem1.Click
        Dim vFacs As frmFacturas = frmFacturas.GetInstance
        vFacs.MdiParent = Me
        vFacs.Show()
    End Sub

    Private Sub NuevaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevaToolStripMenuItem.Click
        Dim vFac As New frmFactura
        Dim vId As Integer = vFac.Agregar
        If vId > 0 Then

        End If
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        End
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        FacturasToolStripMenuItem1.PerformClick()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        CatalogoToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        CatalogoToolStripMenuItem1.PerformClick()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        ConToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ExportarXMLsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarXMLsToolStripMenuItem.Click
        Dim vExp As New frmExportarXML
        vExp.ShowDialog()
    End Sub
End Class

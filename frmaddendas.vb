Imports MySql.Data.MySqlClient
Imports BaseDatos
Public Class frmaddendas

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Close()
    End Sub
  
    Public Sub addendasoriana(ByVal stotal As Double, ByVal descuento As Double, ByVal ieps As Double, ByVal iva As Double, ByVal total As Double, ByVal noarticulos As Double)
        Me.cmbMoneda.Text = "Pesos"
        Me.Txtsubtotal.Text = FormatNumber(stotal, 2)
        Me.Txtdescuento.Text = FormatNumber(descuento, 2)
        Me.Txtieps.Text = FormatNumber(ieps, 2)
        Me.Txtiva.Text = FormatNumber(iva, 2)
        Me.Txttotal.Text = FormatNumber(total, 2)
        Me.Txtnoarticulos.Text = FormatNumber(noarticulos, 2)
    End Sub
    'Private Sub frmaddendas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Me.cmbtienda.DisplayMember = "nombre"
    '    Me.cmbtienda.ValueMember = "id"
    '    Me.cmbtienda.DataSource = GettiendasSoriana()
    'End Sub
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Dim vFac As New BaseDatos.cFacturas
        Me.cmbtienda.DisplayMember = "nombre"
        Me.cmbtienda.ValueMember = "id"
        Me.cmbtienda.DataSource = vFac.GettiendasSoriana

        Me.CmbEntregaM.DisplayMember = "nombre"
        Me.CmbEntregaM.ValueMember = "id"
        Me.CmbEntregaM.DataSource = vFac.GettiendasSoriana

        Me.CmbtiendaP.DisplayMember = "nombre"
        Me.CmbtiendaP.ValueMember = "id"
        Me.CmbtiendaP.DataSource = vFac.GettiendasSoriana

    End Sub

End Class
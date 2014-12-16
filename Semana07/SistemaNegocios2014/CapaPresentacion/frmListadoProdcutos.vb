Imports CapaNegocios
Public Class frmListadoProdcutos

    Private Sub frmListadoProdcutos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenaProductos()
    End Sub

    Private Sub llenaProductos()
        Dim capaNegocios As New ProductoCN
        dgProductos.DataSource = capaNegocios.listaProductos.Tables("PRODUCTOS")
        lblTotal.Text = capaNegocios.listaProductos.Tables("PRODUCTOS").Rows.Count
    End Sub


End Class
Imports System.IO
Imports CapaEntidad
Imports CapaNegocios

Public Class frmProducto
    Dim objProductoCN As New ProductoCN

    Private Sub frmProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenaTabla()
        limpiar()
    End Sub

    Private Sub generaCodigo()
        txtCodigo.Text = objProductoCN.autogeneraCodigo()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim objProducto As New CapaEntidad.ProductoCE
        objProducto.codigo = txtCodigo.Text
        objProducto.descripcion = txtDescripcion.Text
        objProducto.precio = CDbl(txtPrecio.Text)
        objProducto.stockA = CInt(txtStockA.Text)
        objProducto.stockM = CInt(txtStockM.Text)
        objProductoCN.grabar(objProducto)
        limpiar()
        MessageBox.Show("Producto grabó correctamente...!!", "")

    End Sub

    Private Sub limpiar()
        txtDescripcion.Clear()
        txtPrecio.Clear()
        txtPrecio.Clear()
        txtStockA.Clear()
        txtStockM.Clear()
        generaCodigo()
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellContentDoubleClick
        With dgvListado.CurrentRow
            txtCodigo.Text = .Cells(0).Value.ToString
            txtDescripcion.Text = .Cells(1).Value.ToString
            txtPrecio.Text = .Cells(2).Value.ToString
            txtStockA.Text = .Cells(3).Value.ToString
            txtStockM.Text = .Cells(4).Value.ToString
        End With
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiar()
    End Sub

    Private Sub llenaTabla()
        dgvListado.DataSource = objProductoCN.listadoProductos()
        lblTotal.Text = dgvListado.Rows.Count - 1
    End Sub

End Class
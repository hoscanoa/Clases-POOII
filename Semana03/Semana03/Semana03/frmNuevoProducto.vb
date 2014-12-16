Public Class frmNuevoProducto

    Dim objNeg As New ProductoCN

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim objPro As New Producto
        objPro.idProveedor = cboProveedor.SelectedValue
        objPro.idCategoria = cboCategoria.SelectedValue
        objPro.cantidadxUnidad = CInt(txtCantidaxUnidad.Text)
        objPro.precioUnidad = CInt(txtPrecioxUnidad.Text)
        objPro.unidadesEnExistencia = CInt(txtUnidadesEnExistencia.Text)
        objPro.unidadesEnPedido = CInt(txtUnidadesEnPedido.Text)

        objNeg.insertarProducto(objPro)
    End Sub

    Private Sub frmNuevoProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call llenaProveedor()
        Call llenaCategoria()
    End Sub

    Private Sub llenaProveedor()
        cboProveedor.DataSource = objNeg.listadoProveedor()
        cboProveedor.DisplayMember = "NomProveedor"
        cboProveedor.ValueMember = "IdProveedor"
    End Sub

    Private Sub llenaCategoria()
        cboCategoria.DataSource = objNeg.listadoCategoria()
        cboCategoria.DisplayMember = "NombreCategoria"
        cboCategoria.ValueMember = "IdCategoria"
    End Sub

End Class
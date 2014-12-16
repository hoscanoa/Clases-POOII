Public Class Form1
    Dim dNegocios As New dNegociosDataContext

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call muestraProductos()
        Call muestraProveedores()
        Call muestraCategoria()
        Call generaCodigo()
    End Sub

    Private Sub muestraProductos()
        dgProductos.DataSource = dNegocios.SP_LISTAPRODUCTOS
    End Sub

    Private Sub muestraProveedores()
        cboProveedor.DataSource = dNegocios.SP_LISTAPROVEEDORES
        cboProveedor.DisplayMember = "nomProveedor"
        cboProveedor.ValueMember = "idProveedor"
    End Sub

    Private Sub muestraCategoria()
        cboCategoria.DataSource = dNegocios.SP_LISTACATEGORIAS
        cboCategoria.DisplayMember = "nombreCategoria"
        cboCategoria.ValueMember = "idCategoria"
    End Sub

    Private Sub generaCodigo()
        lblCodigo.Text = dNegocios.SP_ULTIMOPRODUCTO.First.IdProducto + 1
    End Sub

    Sub limpiarControles()
    Dim misObjetos As Control
        For Each misObjetos In Me.Controls
            If TypeOf misObjetos Is System.Windows.Forms.TextBox Then
                misObjetos.Text = ""
            End If
        Next
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Call generaCodigo()
        Dim objPro As New productos
        objPro.IdProducto = lblCodigo.Text
        objPro.NomProducto = txtDescripcion.Text
        objPro.IdProveedor = cboProveedor.SelectedValue
        objPro.IdCategoria = cboCategoria.SelectedValue
        objPro.CantxUnidad = txtCantidad.Text
        objPro.PrecioUnidad = txtPrecio.Text
        objPro.UnidadesEnExistencia = txtExistencia.Text
        objPro.UnidadesEnPedido = txtPedido.Text
        dNegocios.productos.InsertOnSubmit(objPro)
        dNegocios.SubmitChanges()
        Call muestraProductos()
        Call generaCodigo()
        Call limpiarControles()
    End Sub


    Private Sub dgProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProductos.CellContentClick
        lblCodigo.Text = dgProductos.CurrentRow.Cells(0).Value
        txtDescripcion.Text = dgProductos.CurrentRow.Cells(1).Value
        cboProveedor.SelectedValue = dgProductos.CurrentRow.Cells(2).Value
        cboCategoria.SelectedValue = dgProductos.CurrentRow.Cells(3).Value
        txtCantidad.Text = dgProductos.CurrentRow.Cells(4).Value
        txtPrecio.Text = dgProductos.CurrentRow.Cells(5).Value
        txtExistencia.Text = dgProductos.CurrentRow.Cells(6).Value
        txtPedido.Text = dgProductos.CurrentRow.Cells(7).Value
    End Sub


    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim producto = From pro In dNegocios.productos Where pro.IdProducto = lblCodigo.Text
        Dim objPro As New productos
        objPro = producto.First
        objPro.IdProducto = lblCodigo.Text
        objPro.NomProducto = txtDescripcion.Text
        objPro.IdProveedor = cboProveedor.SelectedValue
        objPro.IdCategoria = cboCategoria.SelectedValue
        objPro.CantxUnidad = txtCantidad.Text
        objPro.PrecioUnidad = txtPrecio.Text
        objPro.UnidadesEnExistencia = txtExistencia.Text
        objPro.UnidadesEnPedido = txtPedido.Text
        dNegocios.SubmitChanges()
        Call muestraProductos()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim producto = From pro In dNegocios.productos Where pro.IdProducto = lblCodigo.Text
        dNegocios.productos.DeleteOnSubmit(producto.First)
        dNegocios.SubmitChanges()
        Call muestraProductos()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class

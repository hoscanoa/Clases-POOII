Public Class Form1
    Dim productoCN As New ProductoDAO
    Dim flag As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        codigoAutogenerado()
        llenaProducto()
        btnModificar.Enabled = False
    End Sub

    Private Sub codigoAutogenerado()
        If Not flag Then
            lblCodigo.Text = productoCN.generarCodigo()
        Else
            Dim cod As String = dgvListado.Rows(dgvListado.Rows.Count - 1).Cells(0).Value.ToString
            lblCodigo.Text = "P" & Strings.Right("" & (CInt(Strings.Right(cod, 3)) + 1001), 3)
        End If
    End Sub

    Private Sub llenaProducto()
        dgvListado.DataSource = productoCN.listadoProductos().Tables("Productos")
        lblTotal.Text = dgvListado.Rows.Count - 1
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim p As New Producto
        p.codigo = lblCodigo.Text
        p.descripcion = txtDescripcion.Text
        p.precio = CDbl(txtPrecio.Text)
        p.stockActual = CInt(txtStoActual.Text)
        p.stockMinimo = CInt(txtStoMin.Text)

        Dim afectadas As Integer = productoCN.insertarProducto(p)
        If (afectadas > 0) Then
            MessageBox.Show("Se inserto correctamente")
        Else
            MessageBox.Show("No se inserto")
        End If

        limpiar()

    End Sub



    Private Sub limpiar()
        codigoAutogenerado()
        txtDescripcion.Clear()
        txtPrecio.Clear()
        txtStoActual.Clear()
        txtStoMin.Clear()
        btnRegistrar.Enabled = True
        btnModificar.Enabled = False
    End Sub


    Private Sub dgvListado_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvListado.CellMouseDoubleClick
        With dgvListado.CurrentRow
            lblCodigo.Text = .Cells(0).Value.ToString
            txtDescripcion.Text = .Cells(1).Value.ToString
            txtPrecio.Text = .Cells(2).Value.ToString
            txtStoActual.Text = .Cells(3).Value.ToString
            txtStoMin.Text = .Cells(4).Value.ToString
            btnRegistrar.Enabled = False
            btnModificar.Enabled = True
        End With
    End Sub


    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim p As New Producto
        p.codigo = lblCodigo.Text
        p.descripcion = txtDescripcion.Text
        p.precio = CDbl(txtPrecio.Text)
        p.stockActual = CInt(txtStoActual.Text)
        p.stockMinimo = CInt(txtStoMin.Text)

        Dim afectadas As Integer = productoCN.modificaProducto(p)
        If (afectadas > 0) Then
            MessageBox.Show("Se Acualizó correctamente")
        Else
            MessageBox.Show("No se Actualizó")
        End If

        limpiar()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        productoCN.grabaProductos()
    End Sub
End Class

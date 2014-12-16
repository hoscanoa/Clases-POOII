Public Class Form1

    Dim ObjNegProductos As New NegProductos

#Region "Controles"
    Sub ListaProductos()
        dgProductos.DataSource = ObjNegProductos.ListaProductos
    End Sub
    Sub HabilitarTextBox()
        txtProducto.Enabled = True
        txtPrecio.Enabled = True
        txtCantidad.Enabled = True
        chkEstado.Enabled = True
    End Sub
    Sub DesHabilitarTextBox()
        txtProducto.Enabled = False
        txtPrecio.Enabled = False
        txtCantidad.Enabled = False
    End Sub
    Sub LimpiarTextBox()
        txtCodigo.Clear()
        txtCantidad.Clear()
        txtPrecio.Clear()
        txtProducto.Clear()
    End Sub
#End Region


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListaProductos()
    End Sub


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarTextBox()
        txtCodigo.Text = "Autogenerado"
        HabilitarTextBox()
        txtProducto.Focus()
        chkEstado.Enabled = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim ObjEntProd As New EntProductos
        ObjEntProd.Codigo = ObjNegProductos.Autogenera_Codigo
        ObjEntProd.Producto = txtProducto.Text
        ObjEntProd.Precio = txtPrecio.Text
        ObjEntProd.Cantidad = txtCantidad.Text
        If chkEstado.Checked = True Then
            ObjEntProd.Estado = 1
        Else
            ObjEntProd.Estado = 0
        End If
        ObjNegProductos.GrabarRegistro(ObjEntProd)
        ListaProductos()
        DesHabilitarTextBox()
        LimpiarTextBox()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim ObjEntProd As New EntProductos
        ObjEntProd.Codigo = txtCodigo.Text
        ObjNegProductos.EliminaRegistro(ObjEntProd)
        ListaProductos()
    End Sub

    Private Sub dgProductos_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProductos.CellContentDoubleClick
        Try
            txtCodigo.Text = dgProductos.CurrentRow.Cells(0).Value
            txtProducto.Text = dgProductos.CurrentRow.Cells(1).Value
            txtPrecio.Text = dgProductos.CurrentRow.Cells(2).Value
            txtCantidad.Text = dgProductos.CurrentRow.Cells(3).Value
            If dgProductos.CurrentRow.Cells(4).Value = 1 Then
                chkEstado.Checked = True
            Else
                chkEstado.Checked = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If btnActualizar.Text = "MODIFICAR" Then
            btnActualizar.Text = "ACTUALIZAR"
            HabilitarTextBox()
        Else
            Dim ObjEntProd As New EntProductos
            ObjEntProd.Codigo = txtCodigo.Text
            ObjEntProd.Producto = txtProducto.Text
            ObjEntProd.Precio = txtPrecio.Text
            ObjEntProd.Cantidad = txtCantidad.Text
            If chkEstado.Checked = True Then
                ObjEntProd.Estado = 1
            Else
                ObjEntProd.Estado = 0
            End If
            ObjNegProductos.ActualizaRegistro(ObjEntProd)
            ListaProductos()
            btnActualizar.Text = "MODIFICAR"
            DesHabilitarTextBox()
        End If
    End Sub
End Class

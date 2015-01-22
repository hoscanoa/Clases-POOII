Imports CapaNegocios
Public Class frmIngreso

    Private Sub frmIngreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call autogenera()
        Call llenaCombo()
        Call llenaclientes()

    End Sub

    Private Sub llenaclientes()
        Dim capaNegocios As New ClienteCN
        dgClientes.DataSource = capaNegocios.listaClientes.Tables("CLIENTES")
        lblTotal.Text = capaNegocios.listaClientes.Tables("CLIENTES").Rows.Count
    End Sub

    Private Sub llenaCombo()
        Dim capaNegocios As New DistritoCN
        cboDistrito.DataSource = capaNegocios.listaDistritos.Tables("DISTRITOS")
        cboDistrito.DisplayMember = "DESCRIP_DIST"
        cboDistrito.ValueMember = "COD_DIST"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub autogenera()
        Dim capaNegocios As New ClienteCN
        txtCodigo.Text = capaNegocios.autogenera
    End Sub

    
    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim c As New CapaEntidad.ClienteCE
        c.codigo = txtCodigo.Text
        c.nombre = txtNombre.Text
        c.apepaterno = txtApPaterno.Text
        c.apeMaterno = txtAPMaterno.Text
        c.direccion = txtDireccion.Text
        c.telefono = txtTelefono.Text
        c.distrito = cboDistrito.SelectedValue
        c.correo = txtCorreo.Text

        Dim capaNegocios As New ClienteCN

        If (capaNegocios.buscaCliente(txtCodigo.Text) Is Nothing) Then
            capaNegocios.nuevoCliente(c)
        Else
            capaNegocios.actualizaCliente(c)
        End If

        Call autogenera()
        Call llenaclientes()

    End Sub

    Private Sub dgClientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgClientes.CellContentClick
        Try
            txtCodigo.Text = dgClientes.CurrentRow.Cells(0).Value
            txtProducto.Text = dgClientes.CurrentRow.Cells(1).Value
            txtPrecio.Text = dgClientes.CurrentRow.Cells(2).Value
            txtCantidad.Text = dgClientes.CurrentRow.Cells(3).Value
            If dgProductos.CurrentRow.Cells(4).Value = 1 Then
                chkEstado.Checked = True
            Else
                chkEstado.Checked = False
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
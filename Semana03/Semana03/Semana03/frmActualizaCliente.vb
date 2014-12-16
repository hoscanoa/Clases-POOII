Public Class frmActualizaCliente
    Dim objNeg As New ClienteCN
    Dim objCli As New Cliente

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        objCli.Codigo = txtCodigo.Text
        txtCliente.Text = objNeg.buscaCliente(objCli).Rows(0).Item("nomcliente")
        txtDireccion.Text = objNeg.buscaCliente(objCli).Rows(0).Item("dirCliente")
        cboPais.SelectedValue = objNeg.buscaCliente(objCli).Rows(0).Item("idPais")
        txtTelefono.Text = objNeg.buscaCliente(objCli).Rows(0).Item("fonoCliente")
    End Sub

    Private Sub frmActualizaCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call llenaPais()
    End Sub

    Private Sub llenaPais()
        cboPais.DataSource = objNeg.listadoPais
        cboPais.DisplayMember = "nombrepais"
        cboPais.ValueMember = "idPais"
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        objCli.Codigo = txtCodigo.Text
        objCli.Cliente = txtCodigo.Text
        objCli.Direccion = txtDireccion.Text
        objCli.Pais = cboPais.SelectedValue
        objCli.Fono = txtTelefono.Text

        objNeg.actualizaCliente(objCli)
    End Sub
End Class

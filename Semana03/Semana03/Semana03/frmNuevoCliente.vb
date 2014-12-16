Public Class frmNuevoCliente
    Dim objNeg As New ClienteCN
   

    Private Sub frmNuevoCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call llenaPais()
    End Sub

    Private Sub llenaPais()
        cboPais.DataSource = objNeg.listadoPais
        cboPais.DisplayMember = "nombrePais"
        cboPais.ValueMember = "idpais"

    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim objCli As New Cliente
        objCli.Codigo = txtCodigo.Text
        objCli.Cliente = txtCliente.Text
        objCli.Direccion = txtDireccion.Text
        objCli.Pais = cboPais.SelectedValue
        objCli.Fono = txtTelefono.Text

        objNeg.insertaCliente(objCli)
    End Sub
End Class
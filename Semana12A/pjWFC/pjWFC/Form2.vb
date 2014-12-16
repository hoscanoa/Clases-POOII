Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim proxy As New ServiceReference1.Service1Client
        cboPais.DataSource = proxy.listadoPaises.Tables("Paises")
        cboPais.DisplayMember = "nombrepais"
        cboPais.ValueMember = "idpais"
        proxy = Nothing
    End Sub

    Private Sub cboPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPais.SelectedIndexChanged
        Dim proxy As New ServiceReference1.Service1Client
        dgClientes.DataSource = proxy.ClientesxPais(cboPais.SelectedValue.ToString).Tables("Clientes")
        proxy = Nothing
    End Sub
End Class
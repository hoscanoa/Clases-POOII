Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim client As ServiceReference1.Service1Client = New ServiceReference1.Service1Client()
        cboCliente.DataSource = client.listarNombres().Tables("clientes")
        cboCliente.DisplayMember = "NOMBRES"
        cboCliente.ValueMember = "COD_CLI"
        client.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim client As ServiceReference1.Service1Client = New ServiceReference1.Service1Client()
        dgBoletas.DataSource = client.listarBoletasXNombre(cboCliente.SelectedValue.ToString).Tables("boletas")
        client.Close()
    End Sub
End Class

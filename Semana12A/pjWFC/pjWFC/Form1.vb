Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim proxy As New ServiceReference1.Service1Client
        dgClientes.DataSource = proxy.listadoClientes.Tables("Clientes")
        proxy = Nothing
    End Sub
End Class

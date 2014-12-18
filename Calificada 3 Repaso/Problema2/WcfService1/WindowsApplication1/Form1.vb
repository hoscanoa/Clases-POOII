Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim client As ServiceReference1.Service1Client = New ServiceReference1.Service1Client()
        cboBarco.DataSource = client.listaBarcos.tables("faenas")
        cboBarco.DisplayMember = "NOM_BAR"
        cboBarco.ValueMember = "COD_BAR"
        client.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim client As ServiceReference1.Service1Client = New ServiceReference1.Service1Client()
        dgvListado.DataSource = client.listarFaenaxBarco(cboBarco.SelectedValue).Tables("barcos")
        client.Close()
    End Sub
End Class

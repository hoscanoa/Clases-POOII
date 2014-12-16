Public Class frmListadoClientes
    Dim objNeg As New ClienteCN
    Private Sub frmListadoClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgClientes.DataSource = objNeg.listadoClientes
        lblTotal.Text = objNeg.listadoClientes.Rows.Count
        dgClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub
End Class
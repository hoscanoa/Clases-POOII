Public Class frmListadoProductos
    Dim objNeg As New ProductoCN

    Private Sub frmListadoProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgProductos.DataSource = objNeg.listadoProductos
        lblTotal.Text = objNeg.listadoProductos.Rows.Count
        dgProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub
End Class
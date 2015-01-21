Public Class Form1

    Dim modelo As New Negocios2014Entities

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim lista = From c In modelo.productos Select c
        DataGridView1.DataSource = lista.ToList
        lblCantidad.Text = lista.Count
    End Sub
End Class

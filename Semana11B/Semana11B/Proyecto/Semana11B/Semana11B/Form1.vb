Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ds As New DataSet1
        Dim pedidos As New DataSet1TableAdapters.Sp_ListaPedidosTableAdapter
        pedidos.Fill(ds.Tables("Sp_ListaPedidos"))
        Dim rp As New CrystalReport1
        rp.SetDataSource(ds)
        Me.CrystalReportViewer1.ReportSource = rp
    End Sub
End Class

Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ds As New DataSet1
        Dim pedidos As New DataSet1TableAdapters.Sp_PedidosxRangoFechaTableAdapter
        pedidos.Fill(ds.Tables("Sp_PedidosxRangoFecha"), DateTimePicker1.Value, DateTimePicker2.Value)
        Dim rp As New CrystalReport2
        rp.SetDataSource(ds)
        Me.CrystalReportViewer1.ReportSource = rp
    End Sub
End Class
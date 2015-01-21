Imports System.Data.SqlClient
Imports CapaModelo
Public Class Form1
    Dim objCN As New BoletaCN
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CboFechaInicio.DataSource = objCN.listaFecha
        CboFechaInicio.DisplayMember = "FECHA_BOL"
        CboFechaInicio.ValueMember = "FECHA_BOL"

        CboFechaFin.DataSource = objCN.listaFecha
        CboFechaFin.DisplayMember = "FECHA_BOL"
        CboFechaFin.ValueMember = "FECHA_BOL"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ds As New DataSet1
        Dim boletas As New DataSet1TableAdapters.SP_LISTABOLETASXFECHATableAdapter
        boletas.Fill(ds.Tables("SP_LISTABOLETAXFECHA"), CboFechaInicio.SelectedValue, CboFechaFin.SelectedValue)

        Dim rp As New CrystalReport1
        rp.SetDataSource(ds)
        Me.CrystalReportViewer1.ReportSource = rp
    End Sub
End Class

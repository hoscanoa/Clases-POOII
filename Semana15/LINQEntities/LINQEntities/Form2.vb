Imports System.Data.EntityClient
Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call FormatoLista()
        Call LlenaLista()
    End Sub

    Private Sub FormatoLista()
        With ListView1
            .View = View.Details
            .GridLines = True
            .Columns.Add("IdProducto", 100)
            .Columns.Add("NomProducto", 100)
            .Columns.Add("IdProveedor", 100)
            .Columns.Add("IdCategoria", 100)
            .Columns.Add("CantxUnidad", 100)
        End With
    End Sub

    Private Sub LlenaLista()
        Using cn As New EntityConnection("Name=Negocios2014Entities")
            Dim cmd As New EntityCommand("Select VALUE Prod from Negocios2014Entities.productos as prod", cn)
            cn.Open()
            Dim dr As EntityDataReader = cmd.ExecuteReader(CommandBehavior.SequentialAccess)
            While dr.Read
                Dim it As New ListViewItem(dr("IdProducto").ToString)
                it.SubItems.Add(dr("NomProducto"))
                it.SubItems.Add(dr("IdProveedor"))
                it.SubItems.Add(dr("IdCategoria"))
                it.SubItems.Add(dr("CantxUnidad"))
                ListView1.Items.Add(it)
            End While
            lblCantidad.Text = ListView1.Items.Count
            dr.Close()
        End Using
    End Sub



End Class
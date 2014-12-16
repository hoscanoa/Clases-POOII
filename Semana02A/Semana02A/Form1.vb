Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager

Public Class Form1

    Dim cn As New SqlConnection(ConnectionStrings("cn").ConnectionString)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call llenaPedidos()
        Call llenaCombo()
    End Sub

    Private Sub llenaPedidos()
        Using cmd As New SqlCommand("SP_LISTAPEDIDOS")
            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.SelectCommand.Connection = cn
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                Using ds As New DataSet
                    da.Fill(ds, "Pedidos")
                    dgPedidos.DataSource = ds.Tables("Pedidos")
                    lblTotal.Text = ds.Tables("Pedidos").Rows.Count
                End Using
            End Using
        End Using
    End Sub

    Private Sub llenaCombo()
        Using cmd As New SqlCommand("SP_AÑOSPEDIDOS", cn)
            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Connection = cn
                Using ds As New DataSet
                    da.Fill(ds, "AÑOS")
                    cboAños.DataSource = ds.Tables("AÑOS")
                    cboAños.ValueMember = "AÑO"
                    cboAños.DisplayMember = "AÑO"
                End Using
            End Using
        End Using
    End Sub

    Private Sub cboAños_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboAños.SelectionChangeCommitted
        Using cmd As New SqlCommand("SP_PEDIDOSXAÑOS")
            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.SelectCommand.Connection = cn
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@año", SqlDbType.Int).Value = cboAños.SelectedValue
                Using ds As New DataSet
                    da.Fill(ds, "Pedidos")
                    dgPedidos.DataSource = ds.Tables("Pedidos")
                    lblTotal.Text = ds.Tables("Pedidos").Rows.Count
                End Using
            End Using
        End Using
    End Sub

    Private Sub dgPedidos_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPedidos.CellContentDoubleClick
        Using cmd As New SqlCommand("sp_detallexpedido")
            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.SelectCommand.Connection = cn
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@IDP", SqlDbType.Int).Value = dgPedidos.CurrentRow.Cells(0).Value
                Using ds As New DataSet
                    da.Fill(ds, "detalles")
                    dgDetalle.DataSource = ds.Tables("detalles")
                    lblTotalP.Text = ds.Tables("detalles").Rows.Count
                End Using
            End Using
        End Using
    End Sub
End Class

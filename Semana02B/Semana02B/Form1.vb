Imports System.Data.SqlClient
Imports System.Configuration.configurationManager


Public Class Form1

    Dim cn As New SqlConnection(ConnectionStrings("cn").ConnectionString)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call llenarCombo()
    End Sub

    Private Sub llenarCombo()
        Using cmd As New SqlCommand("SP_NOMBREEMPELADO", cn)
            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Connection = cn
                Using ds As New DataSet
                    da.Fill(ds, "NomEmpleado")
                    cboNombre.DataSource = ds.Tables("NomEmpleado")
                    cboNombre.ValueMember = "IdEmpleado"
                    cboNombre.DisplayMember = "NomEmpleado"
                End Using
            End Using
        End Using
    End Sub

    Private Sub cboNombre_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboNombre.SelectionChangeCommitted
        Using cmd As New SqlCommand("SP_PEDIDOSXID")
            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.SelectCommand.Connection = cn
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = cboNombre.SelectedValue
                Using ds As New DataSet
                    da.Fill(ds, "Pedidos")
                    dgPedidos.DataSource = ds.Tables("Pedidos")

                End Using
            End Using
        End Using

        Using cmd As New SqlCommand("SP_PEDIDOSTOTAL")
            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.SelectCommand.Connection = cn
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = cboNombre.SelectedValue
                Using ds As New DataSet
                    da.Fill(ds, "TOTAL")
                    lblTotal.Text = ds.Tables("Pedidos").Rows(0).ToString
                End Using
            End Using
        End Using

    End Sub
End Class

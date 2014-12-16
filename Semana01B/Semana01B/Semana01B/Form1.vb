Imports System.Data.SqlClient
Public Class Form1
    Dim cn As New SqlConnection _
        ("Server=.;DataBase=Negocios2014;uid=sa;Pwd=sql")
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using da As New SqlDataAdapter _
            ("Select * from Ventas.Clientes", cn)
            Using dst As New DataSet
                da.Fill(dst)
                cboIdCliente.DataSource = dst.Tables(0)
                cboIdCliente.DisplayMember = "IDCliente"
            End Using
        End Using
    End Sub
    Private Sub cboIdCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboIdCliente.SelectedIndexChanged
        Using da As New SqlDataAdapter _
        ("Select idPedido,IdCliente,Fechapedido,PaiDestinatario from Ventas.Pedidoscabe where IdCliente=@IdCliente", cn)
            With da.SelectCommand.Parameters
                .Add("@IdCliente", SqlDbType.VarChar).Value = cboIdCliente.Text
            End With
            Using dst As New DataSet
                da.Fill(dst)
                DataGridView1.DataSource = dst.Tables(0)
            End Using
        End Using
    End Sub
End Class

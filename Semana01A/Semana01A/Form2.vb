Imports System.Data.SqlClient

Public Class Form2
    Dim CN As New SqlConnection("Server=.;DataBase=Negocios2014;uid=sa;pwd=sql")

    Private Sub llenar(sql As String)
        Try
            Using da As New SqlDataAdapter(sql, CN)
                Using dst As New DataSet
                    'Poblar el DataSet
                    da.Fill(dst)
                    DataGridView1.DataSource = dst.Tables(0)
                    lblCanreg.Text = dst.Tables(0).Rows.Count
                End Using
            End Using
        Catch ex As Exception

        End Try
       
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        llenar("Select * from RRHH.empleados")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        llenar("Select * from RRHH.distritos")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        llenar("Select * from RRHH.Cargos")
    End Sub

End Class
Imports System.Data.SqlClient
Public Class Form3
    Dim CN As New SqlConnection("Server=.;DataBase=Negocios2014;uid=sa;pwd=sql")


    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using da As New SqlDataAdapter("Select * from Ventas.clientes", CN)
            Using dst As New DataSet
                'Poblar el DataSet
                da.Fill(dst)

                'Poblar el combobox
                ComboBox1.DataSource = dst.Tables(0)
                ComboBox1.DisplayMember = "NomCliente"


                ListBox1.DataSource = dst.Tables(0)
                ListBox1.DisplayMember = "NomCliente"
            End Using
        End Using
    End Sub
End Class
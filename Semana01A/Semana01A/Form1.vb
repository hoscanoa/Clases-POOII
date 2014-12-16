'Clase  - Librería

Imports System.Data.SqlClient

Public Class Form1

    'Cadena de conexión
    Dim cn As New SqlConnection("Server=.;DataBase=Negocios2014;uid=sa;pwd=sql")

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'El Adaptador
        Using da As New SqlDataAdapter("Select * from Ventas.clientes", cn)
            'El Dataset
            Using dst As New DataSet
                'Poblar el DataSet
                da.Fill(dst)
                DataGridView1.DataSource = dst.Tables(0)
                lblCanreg.Text = dst.Tables(0).Rows.Count
            End Using
        End Using
    End Sub

End Class

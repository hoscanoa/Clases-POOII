Imports System.Data.SqlClient

Public Class NegClientes
    Dim objConex As New Conexion
    Dim cn As New SqlConnection

    Public Function ListaClientes() As DataSet
        cn = objConex.getConecta
        Using da As New SqlDataAdapter("SP_LISTACLIENTES", cn)
            Using ds As New DataSet
                da.Fill(ds)
                Return ds
            End Using
        End Using
    End Function


End Class

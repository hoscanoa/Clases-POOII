Imports System.Data.SqlClient

Public Class BoletaDAO
    Dim c As New Conexion
    Dim cn As SqlConnection
    Public Function listaFecha() As DataTable
        cn = c.conexion
        cn.Open()
        Using da As New SqlDataAdapter("sp_fechaEmision", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            Using dt As New DataTable
                da.Fill(dt)
                Return dt
            End Using
        End Using
    End Function
End Class

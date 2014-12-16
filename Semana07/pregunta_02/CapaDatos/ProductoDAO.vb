Imports System.Data.SqlClient
Imports CapaEntidad

Public Class ProductoDAO
    Dim conexion As New Conexion
    Dim cn As SqlConnection

    Function autogeneraCodigo() As Object
        cn = conexion.getConexion
        cn.Open()
        Using cmd As New SqlCommand
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cn
            cmd.CommandText = "SP_AUTO"
            With cmd.Parameters
                .Add("@Cod", SqlDbType.Char, 4).Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            Dim NewCodigo As String
            NewCodigo = cmd.Parameters(0).Value.ToString
            Return NewCodigo
        End Using
    End Function

    Public Sub grabarProducto(objProducto As ProductoCE)
        cn = conexion.getConexion
        cn.Open()
        Using cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_MODIFICAPRODUCTO2"
            With cmd.Parameters
                .Add("@cod", SqlDbType.Char).Value = objProducto.codigo
                .Add("@des", SqlDbType.VarChar).Value = objProducto.descripcion
                .Add("@precio", SqlDbType.Money).Value = objProducto.precio
                .Add("@StockAc", SqlDbType.Int).Value = objProducto.stockA
                .Add("@StockMin", SqlDbType.Int).Value = objProducto.stockM
            End With
            cmd.ExecuteNonQuery()
        End Using
        cn.Close()
    End Sub

    Function listadoProductos() As DataTable
        cn = conexion.getConexion
        Using da As New SqlDataAdapter("SP_LISTAPRODUCTO", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            Using dt As New DataTable
                da.Fill(dt)
                Return dt
            End Using
        End Using
    End Function



End Class

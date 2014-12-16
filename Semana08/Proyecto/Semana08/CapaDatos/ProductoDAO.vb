Imports System.Data.SqlClient
Imports CE = CapaEntidad

Public Class ProductoDAO
    Dim conexion As New Conexion
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter

    Public Sub nuevoProductoF(ByVal objPro As CE.ProductoCE)
        cn = conexion.conectar
        cn.Open()
        Using cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_NUEVOPRODUCTOF"
            With cmd.Parameters
                .Add("@cod", SqlDbType.Char).Value = objPro.codigo
                .Add("@desc", SqlDbType.VarChar).Value = objPro.descripcion
                .Add("@pre", SqlDbType.Money).Value = objPro.precio
                .Add("@stockA", SqlDbType.Int).Value = objPro.stockA
                .Add("@stockM", SqlDbType.Int).Value = objPro.stockM
                .Add("@foto", SqlDbType.Binary).Value = objPro.foto
            End With
            cmd.ExecuteNonQuery()
            MsgBox("Producto registrado correctamente...!!")
        End Using
        cn.Close()
    End Sub

    Public Function Autogenera_Codigo() As String
        cn = conexion.conectar
        cn.Open()
        Using cmd As New SqlCommand
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cn
            cmd.CommandText = "Sp_genera"
            With cmd.Parameters
                .Add("@Cod", SqlDbType.Char, 5).Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            Dim NewCodigo As String
            NewCodigo = cmd.Parameters(0).Value.ToString
            Return NewCodigo
        End Using
    End Function

    Public Function buscaProductosF(ByVal objPro As CE.ProductoCE) As DataSet
        cn = conexion.conectar
        Using cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_BUSCAPRODUCTOF"
            cmd.Parameters.Add("@cod", SqlDbType.Char).Value = objPro.codigo
            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                Using ds As New DataSet
                    da.Fill(ds, "Productos")
                    Return ds
                End Using
            End Using
        End Using
    End Function

End Class

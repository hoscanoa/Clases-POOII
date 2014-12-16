Imports System.Data.SqlClient
Public Class NegProductos
    Dim ObjConex As New Conexion
    Dim cn As New SqlConnection
    Public Function ListaProductos() As DataTable
        cn = ObjConex.getConecta
        Using da As New SqlDataAdapter("sp_listaproductos", cn)
            Using dt As New DataTable
                da.Fill(dt)
                Return dt
            End Using
        End Using
    End Function

    Public Sub GrabarRegistro(ByVal ObjEntProd As EntProductos)
        cn = ObjConex.getConecta
        cn.Open()
        Using tr As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
            Using cmd As New SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = cn
                cmd.CommandText = "SP_InsertaRegistros"
                cmd.Transaction = tr
                With cmd.Parameters
                    .Add("@Codigo", SqlDbType.VarChar).Value = ObjEntProd.Codigo
                    .Add("@Producto", SqlDbType.VarChar).Value = ObjEntProd.Producto
                    .Add("@Precio", SqlDbType.Decimal).Value = ObjEntProd.Precio
                    .Add("@Cantidad", SqlDbType.Int).Value = ObjEntProd.Cantidad
                    .Add("@Estado", SqlDbType.Int).Value = ObjEntProd.Estado
                End With
                Try
                    cmd.ExecuteNonQuery()
                    tr.Commit()
                    MessageBox.Show("SE REGISTRO CORRECTAMENTE!!!", "MENSAJE",
                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    tr.Rollback()
                    MessageBox.Show(ex.Message, "MENSAJE",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    cn.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Sub EliminaRegistro(ByVal ObjEntProd As EntProductos)
        cn = ObjConex.getConecta
        cn.Open()
        Using tr As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
            Using cmd As New SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = cn
                cmd.CommandText = "usp_DardeBaja"
                cmd.Transaction = tr
                With cmd.Parameters
                    .Add("@Codigo", SqlDbType.VarChar).Value = ObjEntProd.Codigo
                End With
                Try
                    cmd.ExecuteNonQuery()
                    tr.Commit()
                    MessageBox.Show("SE ELIMINO CORRECTAMENTE!!!",
                    "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    tr.Rollback()
                    MessageBox.Show(ex.Message, "MENSAJE",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    cn.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Sub ActualizaRegistro(ByVal ObjEntProd As EntProductos)
        cn = ObjConex.getConecta
        cn.Open()
        Using tr As SqlTransaction = cn.BeginTransaction(IsolationLevel.Serializable)
            Using cmd As New SqlCommand
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = cn
                cmd.CommandText = "SP_ActualizaRegistro"
                cmd.Transaction = tr
                With cmd.Parameters
                    .Add("@Codigo", SqlDbType.VarChar).Value = ObjEntProd.Codigo
                    .Add("@Producto", SqlDbType.VarChar).Value = ObjEntProd.Producto
                    .Add("@Precio", SqlDbType.VarChar).Value = ObjEntProd.Precio
                    .Add("@Cantidad", SqlDbType.VarChar).Value = ObjEntProd.Cantidad
                    .Add("@Estado", SqlDbType.VarChar).Value = ObjEntProd.Estado
                End With
                Try
                    cmd.ExecuteNonQuery()
                    tr.Commit()
                    MessageBox.Show("SE ACTUALIZO CORRECTAMENTE!!!", "MENSAJE",
                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "MENSAJE",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                    tr.Rollback()
                Finally
                    cn.Close()
                End Try
            End Using
        End Using
    End Sub

    Public Function Autogenera_Codigo() As String
        cn = ObjConex.getConecta
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
            cn.Close()
            Return NewCodigo
        End Using
    End Function
End Class

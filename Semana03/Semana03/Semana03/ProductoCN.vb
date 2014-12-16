Imports System.Data.SqlClient

Public Class ProductoCN
    Dim objCon As New Conexion
    Dim cn As SqlConnection

    Public Function listadoProductos() As DataTable
        cn = objCon.getConecta
        Using da As New SqlDataAdapter("SP_LISTAPRODUCTOS", cn)
            Dim dt As New DataTable
            da.Fill(dt)
            Return dt
        End Using
    End Function

    Public Function listadoProveedor() As DataTable
        cn = objCon.getConecta
        Using da As New SqlDataAdapter("SP_LISTAPROVEEDOR", cn)
            Dim dt As New DataTable
            da.Fill(dt)
            Return dt
        End Using
    End Function

    Public Function listadoCategoria() As DataTable
        cn = objCon.getConecta
        Using da As New SqlDataAdapter("SP_LISTACATEGORIA", cn)
            Dim dt As New DataTable
            da.Fill(dt)
            Return dt
        End Using
    End Function

    Public Sub insertaProducto(objPro As Producto)
        cn = objCon.getConecta
        cn.Open()
        Using cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_INSERTAPRODUCTO"
            With cmd.Parameters
                .Add("@NOM", SqlDbType.VarChar).Value = objPro.nomProducto
                .Add("@IDPRO", SqlDbType.Int).Value = objPro.idProveedor
                .Add("@IDC", SqlDbType.Int).Value = objPro.idCategoria
                .Add("@CAN", SqlDbType.VarChar).Value = objPro.cantidadxUnidad
                .Add("@PRE", SqlDbType.Decimal).Value = objPro.precioUnidad
                .Add("@UEE", SqlDbType.SmallInt).Value = objPro.unidadesEnExistencia
                .Add("@UEP", SqlDbType.SmallInt).Value = objPro.unidadesEnPedido
            End With
            Try
                cmd.ExecuteNonQuery()
                MessageBox.Show("pRODUCTO Registrado correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                cn.Close()
            End Try
        End Using
    End Sub


End Class

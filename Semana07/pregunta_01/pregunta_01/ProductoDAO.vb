Imports System.Data.SqlClient
Public Class ProductoDAO
    Dim objCon As New conexion
    Dim cn As New SqlConnection
    Dim ds As New DataSet

    Function generarCodigo() As String
        Dim codPro As String
        cn = objCon.getConecta
        cn.Open()
        Using cmd As New SqlCommand("SP_AUTO", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@cod", SqlDbType.Char, 4).Direction = ParameterDirection.Output
            cmd.ExecuteNonQuery()
            codPro = cmd.Parameters(0).Value.ToString
        End Using
        cn.Close()
        Return codPro
    End Function

    Public Function listadoProductos() As DataSet
        cn = objCon.getConecta()
        Using da As New SqlDataAdapter("SP_LISTAPRODUCTO", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.Fill(ds, "Productos")
            ds.Tables("Productos").PrimaryKey = New DataColumn() {ds.Tables("Productos").Columns(0)}
            Return ds
        End Using
    End Function

    Public Function insertarProducto(p As Producto) As Integer
        Dim dr As DataRow = ds.Tables("Productos").Rows.Find(p.codigo)
        If dr Is Nothing Then
            dr = ds.Tables("Productos").NewRow
            dr("COD_PRO") = p.codigo
            dr("DESCRIP_PRO") = p.descripcion
            dr("PRECIO_PRO") = p.precio
            dr("STOCK_ACT_PRO") = p.stockActual
            dr("STOCK_MIN_PRO") = p.stockMinimo
            ds.Tables("Productos").Rows.Add(dr)
            Return 1
        Else
            Return 0
        End If
    End Function

    Public Function modificaProducto(p As Producto)
        Dim dr As DataRow = ds.Tables("Productos").Rows.Find(p.codigo)
        If Not dr Is Nothing Then
            dr("DESCRIP_PRO") = p.descripcion
            dr("PRECIO_PRO") = p.precio
            dr("STOCK_ACT_PRO") = p.stockActual
            dr("STOCK_MIN_PRO") = p.stockMinimo
            Return 1
        Else
            Return 0
        End If
    End Function


    Public Sub grabaProductos()
        cn = objCon.getConecta
        cn.Open()
        Using da As New SqlDataAdapter("SELECT * FROM PRODUCTO", cn)
            Dim sql As New SqlCommandBuilder(da)
            Try
                da.Update(ds, "Productos")
                ds.AcceptChanges()
            Catch ex As Exception
                ds.RejectChanges()
            End Try
        End Using
    End Sub
End Class

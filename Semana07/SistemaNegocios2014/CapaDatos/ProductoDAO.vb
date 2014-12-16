Imports System.Data.SqlClient
Imports CE = CapaEntidad

Public Class ProductoDAO
    Dim cn As New Conexion
    Dim conexion As SqlConnection
    Dim da As SqlDataAdapter
    Public Function listaProducto() As DataSet
        Dim ds As New DataSet
        conexion = cn.conectar
        da = New SqlDataAdapter("SP_LISTAPRODUCTOS", conexion)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.Fill(ds, "PRODUCTOS")
        da.Dispose()
        conexion.Dispose()
        Return ds
    End Function

    Public Function listaProveedores() As DataSet
        Dim ds As New DataSet
        conexion = cn.conectar
        da = New SqlDataAdapter("SP_LISTAPROVEEDORES", conexion)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.Fill(ds, "PROVEEDORES")
        da.Dispose()
        conexion.Dispose()
        Return ds
    End Function

    Public Function listaCategoria() As DataSet
        Dim ds As New DataSet
        conexion = cn.conectar
        da = New SqlDataAdapter("SP_LISTACATEGORIA", conexion)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.Fill(ds, "CATEGORIA")
        da.Dispose()
        conexion.Dispose()
        Return ds
    End Function

    Public Function ultimoCodigo() As Int32
        conexion = cn.conectar
        da = New SqlDataAdapter("ULTIMOPRODUCTO", conexion)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        conexion.Open()
        Dim uCodigo As Int32 = da.SelectCommand.ExecuteScalar
        Return uCodigo
    End Function

    Public Sub insertaProducto(ByVal objeto As CE.ProductoCE)
        conexion = cn.conectar
        Try
            da = New SqlDataAdapter("SP_INSERTAPRODUCTO", conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            With da.SelectCommand.Parameters
                .Add("@IDPROD", SqlDbType.Int).Value = objeto.idProducto
                .Add("@PRO", SqlDbType.VarChar).Value = objeto.nomProducto
                .Add("@IDPROV", SqlDbType.Int).Value = objeto.idProveedor
                .Add("@IDCAT", SqlDbType.Int).Value = objeto.idCategoria
                .Add("@CANT", SqlDbType.VarChar).Value = objeto.cantxUnidad
                .Add("@PRE", SqlDbType.Decimal).Value = objeto.precioUnidad
                .Add("@UEX", SqlDbType.Int).Value = objeto.unidadesEnExistencia
                .Add("@UPE", SqlDbType.Int).Value = objeto.unidadesEnPedido
            End With
            conexion.Open()
            da.SelectCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("ERROR AL INGRESAR UN NUEVO PRODUCTO")
        Finally
            da.Dispose()
            conexion.Dispose()
        End Try
    End Sub

    Public Sub actualizaProducto(ByVal objeto As CE.ProductoCE)
        conexion = cn.conectar
        Try
            da = New SqlDataAdapter("SP_ACTUALIZAPRODUCTO", conexion)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            With da.SelectCommand.Parameters
                .Add("@IDPROD", SqlDbType.Int).Value = objeto.idProducto
                .Add("@PRO", SqlDbType.VarChar).Value = objeto.nomProducto
                .Add("@IDPROV", SqlDbType.Int).Value = objeto.idProveedor
                .Add("@IDCAT", SqlDbType.Int).Value = objeto.idCategoria
                .Add("@CANT", SqlDbType.VarChar).Value = objeto.cantxUnidad
                .Add("@PRE", SqlDbType.Decimal).Value = objeto.precioUnidad
                .Add("@UEX", SqlDbType.Int).Value = objeto.unidadesEnExistencia
                .Add("@UPE", SqlDbType.Int).Value = objeto.unidadesEnPedido
            End With
            conexion.Open()
            da.SelectCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error al Actualizar un Producto " & ex.Message)
        Finally
            da.Dispose()
            conexion.Dispose()
        End Try
    End Sub
End Class

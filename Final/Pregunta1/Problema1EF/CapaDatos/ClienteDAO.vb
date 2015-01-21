Imports System.Data.SqlClient
Imports CE = CapaEntidad
Public Class ClienteDAO
    Dim cn As New Conexion
    Dim conexion As SqlConnection
    Dim da As SqlDataAdapter

    Public Function listaCliente() As DataSet
        Dim ds As New DataSet
        conexion = cn.conectar
        da = New SqlDataAdapter("SP_LISTACLIENTES", conexion)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.Fill(ds, "CLIENTES")
        ds.Dispose()
        conexion.Dispose()
        Return ds
    End Function

    Public Function autogenera() As String

    End Function


End Class

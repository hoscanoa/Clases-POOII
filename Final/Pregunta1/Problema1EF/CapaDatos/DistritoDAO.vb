Imports System.Data.SqlClient

Public Class DistritoDAO
    Dim cn As New Conexion
    Dim conexion As SqlConnection
    Dim da As SqlDataAdapter

    Public Function listaDistrito() As DataSet
        Dim ds As New DataSet
        conexion = cn.conectar
        da = New SqlDataAdapter("SP_LISTADISTRITOS", conexion)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.Fill(ds, "DISTRITOS")
        ds.Dispose()
        conexion.Dispose()
        Return ds
    End Function

End Class
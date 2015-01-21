Imports System.Data.SqlClient

Public Class InquilinoDAO
    Dim objCon As New Conexion
    Dim cn As SqlConnection
    Dim ds As New DataSet

    Public Function listarInquilinos() As DataSet
        cn = objCon.getConexion
        Using da As New SqlDataAdapter("SP_LISTAINQUILINOS", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.Fill(ds, "Inquilinos")
            ds.Tables("Inquilinos").PrimaryKey = New DataColumn() {ds.Tables("Inquilinos").Columns(0)}
            Return ds
        End Using
    End Function

    Public Function autogenera() As String
        Dim cod As String
        cn = objCon.getConexion
        cn.Open()
        Using da As New SqlDataAdapter("SP_AUTO", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@COD", SqlDbType.Char, 6).Direction = ParameterDirection.Output
            da.SelectCommand.ExecuteNonQuery()
            cod = da.SelectCommand.Parameters(0).Value.ToString
        End Using
        cn.Close()
        Return cod
    End Function

    Public Function agregarInqulino(obj As Inquilino) As Integer
        Dim dr As DataRow = ds.Tables("Inquilinos").Rows.Find(obj.codigo)
        If dr Is Nothing Then
            dr = ds.Tables("Inquilinos").NewRow
            dr(0) = obj.codigo
            dr(1) = obj.nombre
            dr(2) = obj.apellido
            dr(3) = obj.basico
            dr(4) = obj.civil
            dr(5) = obj.lugar
            ds.Tables("Inquilinos").Rows.Add(dr)
            Return 1
        Else
            Return 0
        End If
    End Function


    Public Function modificarInqulino(obj As Inquilino) As Integer
        Dim dr As DataRow = ds.Tables("Inquilinos").Rows.Find(obj.codigo)
        If Not dr Is Nothing Then
            dr(1) = obj.nombre
            dr(2) = obj.apellido
            dr(3) = obj.basico
            dr(4) = obj.civil
            dr(5) = obj.lugar
            Return 1
        Else
            Return 0
        End If
    End Function

    Public Function grabar() As Integer
        Dim r As Integer
        cn = objCon.getConexion
        Using da As New SqlDataAdapter("select * from inquilino", cn)
            Dim sql As New SqlCommandBuilder(da)
            Try
                r = da.Update(ds, "Inquilinos")
                ds.AcceptChanges()
            Catch ex As Exception
                r = 0
                ds.RejectChanges()
            End Try
        End Using
        Return r
    End Function

End Class

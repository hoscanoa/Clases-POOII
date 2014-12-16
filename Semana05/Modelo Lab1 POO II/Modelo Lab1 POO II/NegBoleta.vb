Imports System.Data.SqlClient

Public Class NegBoleta
    Dim objConex As New Conexion
    Dim cn As New SqlConnection

    Public Function ListaBoletas(cliente As EntCliente) As DataSet
        cn = objConex.getConecta
        cn.Open()
        Using cmd As New SqlCommand
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cn
            cmd.CommandText = "SP_LISTABOLETASXCLIENTE"
            With cmd.Parameters
                .Add("@CODCLI", SqlDbType.Char, 6).Value = cliente.codigo
            End With
            Using da As New SqlDataAdapter(cmd)
                Using ds As New DataSet
                    da.Fill(ds)
                    Return ds
                End Using
            End Using
        End Using

    End Function

    Public Function ListaDetalle(boleta As EntBoleta) As DataSet
        cn = objConex.getConecta
        cn.Open()
        Using cmd As New SqlCommand
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cn
            cmd.CommandText = "SP_LISTABOLETASDETALLE"
            With cmd.Parameters
                .Add("@CODBOL", SqlDbType.Char, 6).Value = boleta.codigo
            End With
            Using da As New SqlDataAdapter(cmd)
                Using ds As New DataSet
                    da.Fill(ds)
                    Return ds
                End Using
            End Using
        End Using

    End Function

End Class

Imports System.Data.SqlClient
Imports CE = CapaEntidad
Public Class ClienteDAO
    Dim conexion As New Conexion
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter

    Public Function listaCliente() As DataSet
        cn = conexion.conectar
        Using cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_LISTACLIENTES"
            'cmd.Parameters.Add("@cod", SqlDbType.Char).Value = obj.codigo
            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                Using ds As New DataSet
                    da.Fill(ds, "CLIENTES")
                    Return ds
                End Using
            End Using
        End Using
    End Function

    Public Function autogenera() As String
        cn = conexion.conectar
        cn.Open()
        Using cmd As New SqlCommand
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cn
            cmd.CommandText = "ULTIMOCLIENTE"
            With cmd.Parameters
                .Add("@COD_CLI", SqlDbType.Char, 6).Direction = ParameterDirection.Output
            End With
            cmd.ExecuteNonQuery()
            Dim NewCodigo As String
            NewCodigo = cmd.Parameters(0).Value.ToString
            Return NewCodigo
        End Using
    End Function

    Public Sub nuevoCliente(ByVal obj As CE.ClienteCE)
        cn = conexion.conectar
        cn.Open()
        Using cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_INSERTACLIENTE"
            With cmd.Parameters
                .Add("@COD_CLI", SqlDbType.Char, 6).Value = obj.codigo
                .Add("@NOMBRES", SqlDbType.VarChar, 50).Value = obj.nombre
                .Add("@APE_PATER_CLI", SqlDbType.VarChar, 50).Value = obj.apepaterno
                .Add("@APE_MATER_CLI", SqlDbType.VarChar, 50).Value = obj.apeMaterno
                .Add("@DIRECCION_CLI", SqlDbType.VarChar, 50).Value = obj.direccion
                .Add("@TELEFONO_CLI", SqlDbType.Char, 7).Value = obj.telefono
                .Add("@COD_DIST", SqlDbType.Char, 3).Value = obj.distrito
                .Add("@CORREO_E", SqlDbType.VarChar, 50).Value = obj.correo
            End With
            cmd.ExecuteNonQuery()
            MsgBox("Cliente registrado correctamente...!!")
        End Using
        cn.Close()
    End Sub


    Public Function buscaCliente(ByVal codigo As String) As CE.ClienteCE
        cn = conexion.conectar
        Using cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_BUSCACLIENTE"
            cmd.Parameters.Add("@COD_CLI", SqlDbType.Char, 6).Value = codigo
            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                Using ds As New DataSet
                    da.Fill(ds, "CLIENTES")
                    If (ds.Tables("CLIENTES").Rows.Count > 0) Then
                        Dim cliente As New CE.ClienteCE()
                    End If
                End Using
            End Using
        End Using
        Return Nothing
    End Function

    Public Sub actualizaCliente(ByVal obj As CE.ClienteCE)
        cn = conexion.conectar
        cn.Open()
        Using cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_ACTUALIZACLIENTE"
            With cmd.Parameters
                .Add("@COD_CLI", SqlDbType.Char, 6).Value = obj.codigo
                .Add("@NOMBRES", SqlDbType.VarChar, 50).Value = obj.nombre
                .Add("@APE_PATER_CLI", SqlDbType.VarChar, 50).Value = obj.apepaterno
                .Add("@APE_MATER_CLI", SqlDbType.VarChar, 50).Value = obj.apeMaterno
                .Add("@DIRECCION_CLI", SqlDbType.VarChar, 50).Value = obj.direccion
                .Add("@TELEFONO_CLI", SqlDbType.Char, 7).Value = obj.telefono
                .Add("@COD_DIST", SqlDbType.Char, 3).Value = obj.distrito
                .Add("@CORREO_E", SqlDbType.VarChar, 50).Value = obj.correo
            End With
            cmd.ExecuteNonQuery()
            MsgBox("Cliente actualizado correctamente...!!")
        End Using
        cn.Close()
    End Sub
End Class

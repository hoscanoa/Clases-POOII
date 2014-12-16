Imports System.Data.SqlClient

Public Class ClienteCN
    Dim objCon As New Conexion
    Dim cn As SqlConnection


    Public Function listadoClientes() As DataTable
        cn = objCon.getConecta
        Using da As New SqlDataAdapter("sp_listaclientes", cn)
            Dim dt As New DataTable
            da.Fill(dt)
            Return dt
        End Using
    End Function


    Public Function listadoPais() As DataTable
        cn = objCon.getConecta
        Using cmd As New SqlCommand
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = cn
            cmd.CommandText = "SP_LISTAPAIS"
            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                Dim dt As New DataTable
                da.Fill(dt)
                Return dt
            End Using
        End Using
    End Function

    Public Sub insertaCliente(objCli As Cliente)
        cn = objCon.getConecta
        cn.Open()
        Using cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_INSERTACLIENTE"
            With cmd.Parameters
                .Add("@idc", SqlDbType.Char).Value = objCli.Codigo
                .Add("@nom", SqlDbType.VarChar).Value = objCli.Cliente
                .Add("@dir", SqlDbType.VarChar).Value = objCli.Direccion
                .Add("@pai", SqlDbType.Char).Value = objCli.Pais
                .Add("@tel", SqlDbType.Char).Value = objCli.Fono
            End With
            Try
                cmd.ExecuteNonQuery()
                MessageBox.Show("Cliente Registrado correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                cn.Close()
            End Try
        End Using
    End Sub

    Public Function buscaCliente(objCli As Cliente) As DataTable
        cn = objCon.getConecta
        cn.Open()
        Using cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_BUSCACLIENTE"
            cmd.Parameters.Add("@IDC", SqlDbType.Char).Value = objCli.Codigo
            Using da As New SqlDataAdapter
                da.SelectCommand = cmd
                Using dt As New DataTable
                    da.Fill(dt)
                    Return dt
                End Using
            End Using
        End Using
    End Function

    Public Sub actualizaCliente(objCli As Cliente)
        cn = objCon.getConecta()
        cn.Open()
        Using cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_ACTUALIZACLIENTE"
            With cmd.Parameters
                .Add("@idc", SqlDbType.Char).Value = objCli.Codigo
                .Add("@nom", SqlDbType.VarChar).Value = objCli.Cliente
                .Add("@dir", SqlDbType.VarChar).Value = objCli.Direccion
                .Add("@pai", SqlDbType.Char).Value = objCli.Pais
                .Add("@tel", SqlDbType.Char).Value = objCli.Fono
            End With
            Try
                cmd.ExecuteNonQuery()
                MessageBox.Show("Cliente actualizado correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                cn.Close()
            End Try
        End Using
    End Sub

    Public Sub EliminaCliente(ByVal objCli As Cliente)
        cn = objCon.getConecta
        cn.Open()
        Using cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_ELIMINACLIENTE"
            cmd.Parameters.Add("@idc", SqlDbType.Char).Value = objCli.Codigo
            Try
                cmd.ExecuteNonQuery()
                MessageBox.Show("Cliente eliminado correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
                cn.Close()
            End Try
        End Using
    End Sub

End Class

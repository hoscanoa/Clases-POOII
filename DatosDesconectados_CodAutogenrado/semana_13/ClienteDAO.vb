Imports System.Data.SqlClient
Public Class ClienteDAO
    Dim objcon As New Conexion
    Dim cn As New SqlConnection
    Dim ds As New DataSet
    'listar los clientes
    Public Function listadoclientes() As DataSet
        cn = objcon.getconecta
        Using da As New SqlDataAdapter("sp_listacliente", cn)
            da.Fill(ds, "Clientes")
            ds.Tables("Clientes").PrimaryKey = New DataColumn() {ds.Tables("Clientes").Columns(0)}
            Return ds
        End Using
    End Function

    'agregar cliente
    Public Sub agregacliente(ByVal objcli As Cliente)
        Dim dr As DataRow = ds.Tables("Clientes").Rows.Find(objcli.codigo)
        If dr Is Nothing Then
            'definir una nueva fila
            dr = ds.Tables("Clientes").NewRow
            dr("Cli_Codigo") = objcli.codigo
            dr("Cli_nombre") = objcli.nombres
            dr("Cli_telefono") = objcli.direccion
            dr("Cli_ruc") = objcli.ruc
            dr("Cli_direccion") = objcli.telefono
            ds.Tables("Clientes").Rows.Add(dr)
            MessageBox.Show("Cliente registrado correctamente...!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show("El cleinte ya se encuentra registrado...!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    'Metodo que busca un determinado cliente
    Public Function buscacliente(ByVal objcli As Cliente) As DataRow
        Dim dr As DataRow = ds.Tables("Clientes").Rows.Find(objcli.codigo)
        If dr Is Nothing Then
            MessageBox.Show("El codigo de cliente NO existe", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return dr
        Else
            Return dr
        End If
    End Function


    'actualiza los datos de un cliente
    Public Sub modificacliente(ByVal objCli As Cliente)
        Dim dr As DataRow = ds.Tables("Clientes").Rows.Find(objCli.codigo)
        If Not dr Is Nothing Then
            dr("Cli_nombre") = objCli.nombres
            dr("Cli_direccion") = objCli.direccion
            dr("Cli_ruc") = objCli.ruc
            dr("Cli_telefono") = objCli.telefono
            MessageBox.Show("Cliente modificado correctamente...!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("El Cliente no existe...!!!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    'METODO QUE PERMITE ELIMINAR UN CLIENTE
    Public Sub eliminacliente(ByVal objCli As Cliente)
        Dim dr As DataRow = ds.Tables("Clientes").Rows.Find(objCli.codigo)
        If Not dr Is Nothing Then
            dr.Delete()
            MessageBox.Show("Cliente eliminado correctamente...!!!", "Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("El Cliente NO existe...!!!", "Sitema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    'Actualiza la informacion en la tabla clientes
    Public Sub actualizaclientes()
        cn = objcon.getconecta
        Using da As New SqlDataAdapter("select * from clientes", cn)
            Dim sql As New SqlCommandBuilder(da)
            Try
                da.Update(ds, "Clientes")
                MessageBox.Show("Se actualizo correctamente...!!!")
                ds.AcceptChanges()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                ds.RejectChanges()
            End Try
        End Using
    End Sub
    Public Function Autogenera_Codigo() As String
        cn = objcon.getconecta
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

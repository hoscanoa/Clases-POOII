' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
' NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.vb en el Explorador de soluciones e inicie la depuración.

Imports System.Data.SqlClient

Public Class Service1
    Implements IService1

    Public Sub New()
    End Sub

    Public Function GetData(ByVal value As Integer) As String Implements IService1.GetData
        Return String.Format("You entered: {0}", value)
    End Function

    Public Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType Implements IService1.GetDataUsingDataContract
        If composite Is Nothing Then
            Throw New ArgumentNullException("composite")
        End If
        If composite.BoolValue Then
            composite.StringValue &= "Suffix"
        End If
        Return composite
    End Function

    Public Function listadoClientes() As DataSet Implements IService1.listadoClientes
        Dim cn As New SqlConnection("server=.;database=Negocios2014;uid=sa;pwd=sql")
        Dim da As New SqlDataAdapter("sp_listaClientes", cn)
        Dim ds As New DataSet
        da.Fill(ds, "Clientes")
        Return ds
    End Function


    Public Function listadoPaises() As DataSet Implements IService1.listadoPaises
        Using cn As New SqlConnection("server=.;database=Negocios2014;uid=sa;pwd=sql")
            Using da As New SqlDataAdapter("sp_listapais", cn)
                Using ds As New DataSet
                    da.Fill(ds, "Paises")
                    Return ds
                End Using
            End Using
        End Using
    End Function

    Public Function ClientesxPais(ByVal pais As String) As DataSet Implements IService1.ClientesxPais
        Using cn As New SqlConnection("server=.;database=Negocios2014;uid=sa;pwd=sql")
            Using da As New SqlDataAdapter("sp_clientesxpais", cn)
                da.SelectCommand.CommandType = CommandType.StoredProcedure
                da.SelectCommand.Parameters.Add("@pais", SqlDbType.Char, 3).Value = pais
                Using ds As New DataSet
                    da.Fill(ds, "Clientes")
                    Return ds
                End Using
            End Using
        End Using
    End Function

End Class

Imports CapaDatos
Imports CE = CapaEntidad
Public Class ClienteCN
    Dim cliente As New ClienteDAO

    Public Function listaClientes() As DataSet
        Return cliente.listaCliente
    End Function


    Public Function autogenera() As String
        Return cliente.autogenera
    End Function

    Public Sub nuevoCliente(ByVal obj As CE.ClienteCE)
        cliente.nuevoCliente(obj)
    End Sub

    Public Sub actualizaCliente(ByVal obj As CE.ClienteCE)
        cliente.actualizaCliente(obj)
    End Sub

    Public Function buscaCliente(ByVal codigo As String) As CE.ClienteCE
        Return cliente.buscaCliente(codigo)
    End Function
End Class

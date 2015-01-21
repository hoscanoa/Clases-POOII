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
End Class

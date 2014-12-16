Imports System.Data.SqlClient
Imports CapaDatos
Imports CapaEntidad

Public Class ProductoCN
    Dim objProductoDAO As New ProductoDAO
  
    Public Function autogeneraCodigo()
        Return objProductoDAO.autogeneraCodigo
    End Function

    Sub grabar(objProducto As ProductoCE)
        objProductoDAO.grabarProducto(objProducto)
    End Sub

    Public Function listadoProductos() As DataTable
        Return objProductoDAO.listadoProductos()
    End Function

End Class

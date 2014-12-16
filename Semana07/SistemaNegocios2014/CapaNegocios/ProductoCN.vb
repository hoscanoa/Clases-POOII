Imports CapaDatos
Imports CE = CapaEntidad

Public Class ProductoCN
    Dim producto As New ProductoDAO
    Public Function listaProductos() As DataSet
        Return producto.listaProducto
    End Function

    Public Sub insertaProducto(ByVal objProducto As CE.ProductoCE)
        producto.insertaProducto(objProducto)
    End Sub

    Public Sub actualizaProducto(ByVal objProducto As CE.ProductoCE)
        producto.actualizaProducto(objProducto)
    End Sub

    Public Function listaProveedores() As DataSet
        Return producto.listaProveedores
    End Function

    Public Function listaCategoria() As DataSet
        Return producto.listaCategoria
    End Function

    Public Function ultimoCodigo() As Int32
        Return producto.ultimoCodigo
    End Function

End Class

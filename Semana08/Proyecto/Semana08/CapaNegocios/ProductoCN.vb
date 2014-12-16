Imports System.Data.SqlClient
Imports System.Configuration
Imports CapaEntidad
Imports CapaDatos

Public Class ProductoCN
    Dim objProductoDAO As New ProductoDAO
    Dim ObjPro As New ProductoCE
    Public Sub nuevoProductoF(ByVal objPro As ProductoCE)
        objProductoDAO.nuevoProductoF(objPro)
    End Sub

    Public Function Autogenera_Codigo()
        Return objProductoDAO.Autogenera_Codigo
    End Function

    Public Function buscaProductosF(ByVal objPro As ProductoCE) As DataSet
        Return objProductoDAO.buscaProductosF(objPro)
    End Function
End Class

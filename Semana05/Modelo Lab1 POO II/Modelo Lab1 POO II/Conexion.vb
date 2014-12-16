Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager



Public Class Conexion
    Public Function getConecta() As SqlConnection
        Dim cn As New SqlConnection(ConnectionStrings("Conex").ConnectionString)
        Return cn
    End Function
End Class

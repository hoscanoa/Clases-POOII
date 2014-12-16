Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager
Public Class Conexion
    Public Function getConexion() As SqlConnection
        Return New SqlConnection(ConnectionStrings("cn").ConnectionString())
    End Function
End Class

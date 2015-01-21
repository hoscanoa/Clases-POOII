Imports System.Data.SqlClient
Imports System.Configuration

Public Class Conexion
    Public Function conexion() As SqlConnection
        Return New SqlConnection(ConfigurationManager.ConnectionStrings("cn").ConnectionString())
    End Function
End Class

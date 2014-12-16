Imports System.Data.SqlClient
Imports System.Configuration

Public Class Conexion
    Dim conexion As SqlConnection
    Public Function conectar() As SqlConnection
        conexion = New SqlConnection(ConfigurationManager. _
        ConnectionStrings("cn").ConnectionString)
        Return conexion
    End Function

End Class

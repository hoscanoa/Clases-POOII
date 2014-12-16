Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager
Public Class Conexion

    Function conectar() As SqlConnection
        Return New SqlConnection(ConnectionStrings("cn").ConnectionString)
    End Function

End Class

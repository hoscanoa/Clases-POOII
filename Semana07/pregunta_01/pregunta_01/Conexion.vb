Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager
Public Class conexion

    Public Function getConecta() As SqlConnection
        Dim cn As New SqlConnection(ConnectionStrings("cn").ConnectionString)
        Return cn
    End Function
End Class

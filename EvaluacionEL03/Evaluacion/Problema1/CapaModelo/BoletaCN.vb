Imports System.Data.SqlClient
Imports CapaDatos

Public Class BoletaCN
    Dim objCD As New BoletaDAO

    Public Function listaFecha() As DataTable
        Return objCD.listaFecha()
    End Function
End Class

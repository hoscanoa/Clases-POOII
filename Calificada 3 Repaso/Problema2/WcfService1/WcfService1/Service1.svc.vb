﻿' NOTA: puede usar el comando "Cambiar nombre" del menú contextual para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
' NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.vb en el Explorador de soluciones e inicie la depuración.

Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager

Public Class Service1
    Implements IService1

    Public Sub New()
    End Sub

    Public Function GetData(ByVal value As Integer) As String Implements IService1.GetData
        Return String.Format("You entered: {0}", value)
    End Function

    Public Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType Implements IService1.GetDataUsingDataContract
        If composite Is Nothing Then
            Throw New ArgumentNullException("composite")
        End If
        If composite.BoolValue Then
            composite.StringValue &= "Suffix"
        End If
        Return composite
    End Function

    Public Function listaBarcos() As DataSet Implements IService1.listaBarcos
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("cn").ConnectionString())
        'Dim cn As New SqlConnection("server=.\SQLEXPRESS;database=PESCA;integrated security=SSPI")
        cn.Open()
        Using da As New SqlDataAdapter("SP_listarBarco", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            Using ds As New DataSet
                da.Fill(ds, "faenas")
                Return ds
            End Using
        End Using
    End Function

    Public Function listarFaenaxBarco(codBar As String) As DataSet Implements IService1.listarFaenaxBarco
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("cn").ConnectionString())
        cn.Open()
        Using da As New SqlDataAdapter("SP_listarFaenaxBarco", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.Add("@codBar", SqlDbType.Char, 5).Value = codBar
            Using ds As New DataSet
                da.Fill(ds, "barcos")
                Return ds
            End Using
        End Using
    End Function

End Class

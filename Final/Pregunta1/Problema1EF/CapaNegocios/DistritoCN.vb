Imports CapaDatos
Public Class DistritoCN
    Dim distrito As New DistritoDAO

    Public Function listaDistritos() As DataSet
        Return distrito.listaDistrito
    End Function
End Class

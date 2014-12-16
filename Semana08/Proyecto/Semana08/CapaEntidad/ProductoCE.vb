Public Class ProductoCE
    Private _codigo As String
    Private _descripcion As String
    Private _precio As Double
    Private _stockA As Integer
    Private _stockM As Integer
    Private _foto As Object
    Public Property codigo As String
        Get
            Return _codigo
        End Get
        Set(value As String)
            _codigo = value
        End Set
    End Property
    Public Property descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property
    Public Property precio As Double
        Get
            Return _precio
        End Get
        Set(value As Double)
            _precio = value
        End Set
    End Property
    Public Property stockA As Integer
        Get
            Return _stockA
        End Get
        Set(value As Integer)
            _stockA = value
        End Set
    End Property
    Public Property stockM As Integer
        Get
            Return _stockM
        End Get
        Set(value As Integer)
            _stockM = value
        End Set
    End Property
    Public Property foto As Object
        Get
            Return _foto
        End Get
        Set(value As Object)
            _foto = value
        End Set
    End Property
End Class

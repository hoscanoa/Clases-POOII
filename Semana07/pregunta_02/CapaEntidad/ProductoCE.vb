Public Class ProductoCE
    Private _codigo As String
    Public Property codigo() As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property

    Private _descripcion As String
    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _precio As Double
    Public Property precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
        End Set
    End Property

    Private _stockA As Integer
    Public Property stockA() As Integer
        Get
            Return _stockA
        End Get
        Set(ByVal value As Integer)
            _stockA = value
        End Set
    End Property

    Private _stockM As Integer
    Public Property stockM() As Integer
        Get
            Return _stockM
        End Get
        Set(ByVal value As Integer)
            _stockM = value
        End Set
    End Property

End Class

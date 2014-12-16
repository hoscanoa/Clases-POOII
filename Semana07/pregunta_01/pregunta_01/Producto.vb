Public Class Producto
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

    Private _stockActual As Integer
    Public Property stockActual() As Integer
        Get
            Return _stockActual
        End Get
        Set(ByVal value As Integer)
            _stockActual = value
        End Set
    End Property

    Private _stockMinimo As Integer
    Public Property stockMinimo() As Integer
        Get
            Return _stockMinimo
        End Get
        Set(ByVal value As Integer)
            _stockMinimo = value
        End Set
    End Property


End Class

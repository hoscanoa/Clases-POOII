Public Class Producto
    Private _idProducto As Integer
    Public Property idProducto() As Integer
        Get
            Return _idProducto
        End Get
        Set(ByVal value As Integer)
            _idProducto = value
        End Set
    End Property

    Private _nomProducto As String
    Public Property nomProducto() As String
        Get
            Return _nomProducto
        End Get
        Set(ByVal value As String)
            _nomProducto = value
        End Set
    End Property

    Private _idProveedor As Integer
    Public Property idProveedor() As String
        Get
            Return _idProveedor
        End Get
        Set(ByVal value As String)
            _idProveedor = value
        End Set
    End Property

    Private _idCategoria As Integer
    Public Property idCategoria() As Integer
        Get
            Return _idCategoria
        End Get
        Set(ByVal value As Integer)
            _idCategoria = value
        End Set
    End Property

    Private _cantidadxUnidad As String
    Public Property cantidadxUnidad() As String
        Get
            Return _cantidadxUnidad
        End Get
        Set(ByVal value As String)
            _cantidadxUnidad = value
        End Set
    End Property

    Private _precioUnidad As Double
    Public Property precioUnidad() As Double
        Get
            Return _precioUnidad
        End Get
        Set(ByVal value As Double)
            _precioUnidad = value
        End Set
    End Property

    Private _unidadesEnExistencia As Integer
    Public Property unidadesEnExistencia() As Integer
        Get
            Return _unidadesEnExistencia
        End Get
        Set(ByVal value As Integer)
            _unidadesEnExistencia = value
        End Set
    End Property

    Private _unidadesEnPedido As Integer
    Public Property unidadesEnPedido() As Integer
        Get
            Return _unidadesEnPedido
        End Get
        Set(ByVal value As Integer)
            _unidadesEnPedido = value
        End Set
    End Property

End Class

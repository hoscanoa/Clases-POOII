Public Class ProductoCE
    Private _idProducto As Integer
    Private _nomProducto As String
    Private _idProveedor As Integer
    Private _idCategoria As Integer
    Private _cantxUnidad As String
    Private _precioUnidad As Double
    Private _unidadesEnExistencia As Integer
    Private _unidadesEnPedido As Integer

    Public Property idProducto As Integer
        Get
            Return _idProducto
        End Get
        Set(ByVal value As Integer)
            _idProducto = value
        End Set
    End Property

    Public Property nomProducto As String
        Get
            Return _nomProducto
        End Get
        Set(ByVal value As String)
            _nomProducto = value
        End Set
    End Property
    Public Property idProveedor As Integer
        Get
            Return _idProveedor
        End Get
        Set(ByVal value As Integer)
            _idProveedor = value
        End Set
    End Property

    Public Property idCategoria As Integer
        Get
            Return _idCategoria
        End Get
        Set(ByVal value As Integer)
            _idCategoria = value
        End Set
    End Property

    Public Property cantxUnidad As String
        Get
            Return _cantxUnidad
        End Get
        Set(ByVal value As String)
            _cantxUnidad = value
        End Set
    End Property

    Public Property precioUnidad As Double
        Get
            Return _precioUnidad
        End Get
        Set(ByVal value As Double)
            _precioUnidad = value
        End Set
    End Property

    Public Property unidadesEnExistencia As Integer
        Get
            Return _unidadesEnExistencia
        End Get
        Set(ByVal value As Integer)
            _unidadesEnExistencia = value
        End Set
    End Property

    Public Property unidadesEnPedido As Integer
        Get
            Return _unidadesEnPedido
        End Get
        Set(ByVal value As Integer)
            _unidadesEnPedido = value
        End Set
    End Property

End Class

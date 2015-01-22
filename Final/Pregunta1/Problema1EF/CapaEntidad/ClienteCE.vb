Public Class ClienteCE

    Private _codigo As String
    Public Property codigo() As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property


    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _apePaterno As String
    Public Property apepaterno() As String
        Get
            Return _apePaterno
        End Get
        Set(ByVal value As String)
            _apePaterno = value
        End Set
    End Property

    Private _apeMaterno As String
    Public Property apeMaterno() As String
        Get
            Return _apeMaterno
        End Get
        Set(ByVal value As String)
            _apeMaterno = value
        End Set
    End Property

    Private _direccion As String
    Public Property direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property

    Private _telefono As String
    Public Property telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property

    Private _distrito As String
    Public Property distrito() As String
        Get
            Return _distrito
        End Get
        Set(ByVal value As String)
            _distrito = value
        End Set
    End Property

    Private _correo As String
    Public Property correo() As String
        Get
            Return _correo
        End Get
        Set(ByVal value As String)
            _correo = value
        End Set
    End Property

End Class

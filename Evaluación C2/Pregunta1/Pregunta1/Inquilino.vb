Public Class Inquilino
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

    Private _apellido As String
    Public Property apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property

    Private _basico As Double
    Public Property basico() As Double
        Get
            Return _basico
        End Get
        Set(ByVal value As Double)
            _basico = value
        End Set
    End Property

    Private _civil As String
    Public Property civil() As String
        Get
            Return _civil
        End Get
        Set(ByVal value As String)
            _civil = value
        End Set
    End Property

    Private _lugar As String
    Public Property lugar() As String
        Get
            Return _lugar
        End Get
        Set(ByVal value As String)
            _lugar = value
        End Set
    End Property

End Class

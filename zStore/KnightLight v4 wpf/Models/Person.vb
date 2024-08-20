Public Class Person
    Private _UserName As String
    Private _UserLastName As String
    Private _UserAge As Integer

    Public Property UserName As String
        Get
            Return _UserName
        End Get
        Set
            _UserName = Value
        End Set
    End Property

    Public Property UserLastName As String
        Get
            Return _UserLastName
        End Get
        Set
            _UserLastName = Value
        End Set
    End Property

    Public Property UserAge As Integer
        Get
            Return _UserAge
        End Get
        Set
            _UserAge = Value
        End Set
    End Property
End Class

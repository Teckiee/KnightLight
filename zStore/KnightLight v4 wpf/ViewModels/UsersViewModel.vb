Imports System.ComponentModel

Public Class UsersViewModel

    Implements INotifyPropertyChanged

    Private _UserList As List(Of Person)
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Property UserList As List(Of Person)
        Get
            Return _UserList
        End Get
        Set
            _UserList = Value
            NotifyPropertyChanged("UserList")
        End Set
    End Property
    Private Sub NotifyPropertyChanged(ByVal info As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    End Sub

    Public Sub AddPersons()
        Dim MyPersons As New List(Of Person)
        For i = 1 To 5
            Dim P As New Person With {.UserName = i.ToString & " Name",
                .UserLastName = i.ToString & " LastName",
                .UserAge = i}
            MyPersons.Add(P)
        Next

        ' Update Property
        UserList = MyPersons
    End Sub
    Public Sub New()
        AddPersons()

    End Sub

End Class

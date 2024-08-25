Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Module mBindings
    Public Bindings As New cBindings()




End Module
Public Class cBindings
    Implements INotifyPropertyChanged
    'Private Property _OSCconnections As ObservableCollection(Of cOSCconnections)
    'Public Property OSCconnections As ObservableCollection(Of cOSCconnections)
    '    Get
    '        Return _OSCconnections
    '    End Get
    '    Set(value As ObservableCollection(Of cOSCconnections))
    '        If _OSCconnections IsNot value Then
    '            _OSCconnections = value
    '            OnPropertyChanged()
    '        End If
    '    End Set
    'End Property



    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Protected Sub OnPropertyChanged(<CallerMemberName> Optional propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class


'Private Property _ChannelBulletColour As Brush = Brushes.Magenta
'Public Property ChannelBulletColour As Brush
'    Get
'        Return _ChannelBulletColour
'    End Get
'    Set(value As Brush)
'        If _ChannelBulletColour IsNot value Then
'            _ChannelBulletColour = value
'            OnPropertyChanged()
'        End If
'    End Set
'End Property
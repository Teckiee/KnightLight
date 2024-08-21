Imports Newtonsoft.Json
Imports System.IO
Imports System.Net
Imports Knightlight_v5_Library
Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Module mdlGlobalVars
    Public OSC As cOSCControls

    Public Settings As New cSettings()




    Sub SaveData(filePath As String)
        Dim json As String = JsonConvert.SerializeObject(Settings, Formatting.Indented)
        File.WriteAllText(filePath, json)
    End Sub

    Sub LoadData(filePath As String)
        If Not File.Exists(filePath) Then
            ' File doesn't exist, create it with default values
            SaveData(filePath)
        End If

        Dim json As String = File.ReadAllText(filePath)
        Settings = JsonConvert.DeserializeObject(Of cSettings)(json)
    End Sub
End Module
Public Class cSettings
    Implements INotifyPropertyChanged
    Public Property LastBank As String = "DefaultBank"
    Public Property LoadonChange As Boolean = True
    Public Property ChannelCount As Integer = 2048
    Public Property DimmerChannelRows As Integer = 0
    Private Property _ChannelBulletColour As Brush = Brushes.Magenta
    Public Property ChannelBulletColour As Brush
        Get
            Return _ChannelBulletColour
        End Get
        Set(value As Brush)
            If _ChannelBulletColour IsNot value Then
                _ChannelBulletColour = value
                OnPropertyChanged()
            End If
        End Set
    End Property
    Private Property _ChannelBackColour As Brush = Brushes.DimGray
    Public Property ChannelBackColour As Brush
        Get
            Return _ChannelBackColour
        End Get
        Set(value As Brush)
            If _ChannelBackColour IsNot value Then
                _ChannelBackColour = value
                OnPropertyChanged()
            End If
        End Set
    End Property
    Private Property _ChannelFillColour As Brush = Brushes.Black
    Public Property ChannelFillColour As Brush
        Get
            Return _ChannelFillColour
        End Get
        Set(value As Brush)
            If _ChannelFillColour IsNot value Then
                _ChannelFillColour = value
                OnPropertyChanged()
            End If
        End Set
    End Property
    Private Property _ChannelNumberColour As Brush = Brushes.Magenta
    Public Property ChannelNumberColour As Brush
        Get
            Return _ChannelNumberColour
        End Get
        Set(value As Brush)
            If _ChannelNumberColour IsNot value Then
                _ChannelNumberColour = value
                OnPropertyChanged()
            End If
        End Set
    End Property
    Private Property _SceneBulletColour As Brush = Brushes.Blue
    Public Property SceneBulletColour As Brush
        Get
            Return _SceneBulletColour
        End Get
        Set(value As Brush)
            If _SceneBulletColour IsNot value Then
                _SceneBulletColour = value
                OnPropertyChanged()
            End If
        End Set
    End Property
    Private Property _SceneBackColour As Brush = Brushes.Green
    Public Property SceneBackColour As Brush
        Get
            Return _SceneBackColour
        End Get
        Set(value As Brush)
            If _SceneBackColour IsNot value Then
                _SceneBackColour = value
                OnPropertyChanged()
            End If
        End Set
    End Property
    Private Property _SceneFillColour As Brush = Brushes.Black
    Public Property SceneFillColour As Brush
        Get
            Return _SceneFillColour
        End Get
        Set(value As Brush)
            If _SceneFillColour IsNot value Then
                _SceneFillColour = value
                OnPropertyChanged()
            End If
        End Set
    End Property
    Private Property _SceneLabelColour As Brush = Brushes.Magenta
    Public Property SceneLabelColour As Brush
        Get
            Return _SceneLabelColour
        End Get
        Set(value As Brush)
            If _SceneLabelColour IsNot value Then
                _SceneLabelColour = value
                OnPropertyChanged()
            End If
        End Set
    End Property
    Private Property _SceneBorderColour As Brush = Brushes.Gold
    Public Property SceneBorderColour As Brush
        Get
            Return _SceneBorderColour
        End Get
        Set(value As Brush)
            If _SceneBorderColour IsNot value Then
                _SceneBorderColour = value
                OnPropertyChanged()
            End If
        End Set
    End Property
    Private Property _SongChangeColour As Brush = Brushes.Magenta
    Public Property SongChangeColour As Brush
        Get
            Return _SongChangeColour
        End Get
        Set(value As Brush)
            If _SongChangeColour IsNot value Then
                _SongChangeColour = value
                OnPropertyChanged()
            End If
        End Set
    End Property
    Public Property MultipleThreadCount As Boolean = False
    Public Property ResaveOnSceneLoad As Boolean = False
    Public Property ScenesWithFader As Boolean = True
    Public Property ASIOMode As Boolean = False
    Public Property MusicNextFollows As Boolean = True
    Public Property AudioLatency As Integer = 0
    Public Property AudioDesiredSamplerate As Integer = 48000
    Public Property ServerIPaddress As String
    Public Property ServerPort As Integer = 50000
    Public Property ClientPorts As Integer = 50001
    Public Property ArduinoDevices As List(Of ArduinoDevices1)

    Structure ArduinoDevices1
        Dim PortName As String
        Dim Job As String
    End Structure
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub OnPropertyChanged(<CallerMemberName> Optional propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class

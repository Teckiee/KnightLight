Imports Newtonsoft.Json
Imports System.IO
Imports System.Net
Imports Knightlight_v5_Library
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Collections.ObjectModel
Imports Knightlight_v5_GUI.cSettings

Module mdlGlobalVars
    Public OSC As cOSCControls

    Public Settings As New cSettings()

    Public buttonWidth As Double = 100
    Public knightlightFolderPath As String

    Public vWindow(7) As MainWindow
    'Public vFixtures As New List(Of cFixtures)
    'Public vPresets As New List(Of cPresets)
    Public vFixtures As New ObservableCollection(Of cFixtures)
    Public vPresets As New ObservableCollection(Of cPresets)


    Sub SaveData()
        Dim settingsFilePath As String = Path.Combine(knightlightFolderPath, "GUISettings.json")

        Settings.Windows.Clear()
        For Each window As MainWindow In vWindow
            If window IsNot Nothing Then
                If window.ActualHeight <> 0 Then
                    Dim windowSettings As New WindowSettings() With {
                            .WindowI = window.IamWindow,
                            .Left = window.Left,
                            .Top = window.Top,
                            .Height = window.Height,
                            .Width = window.Width,
                            .WindowState = window.WindowState
                        }
                    Settings.Windows.Add(windowSettings)
                End If
            End If

        Next
        Dim json As String = JsonConvert.SerializeObject(Settings, Formatting.Indented)
        File.WriteAllText(settingsFilePath, json)
    End Sub

    Sub LoadData(filePath As String)
        ' Get the path to the user's Documents folder
        Dim documentsPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ' Construct the path to the Knightlight folder
        knightlightFolderPath = Path.Combine(documentsPath, "Knightlight")
        ' Create the Knightlight folder if it doesn't exist
        If Not Directory.Exists(knightlightFolderPath) Then
            Directory.CreateDirectory(knightlightFolderPath)
        End If
        ' Construct the full path to the Settings.json file
        Dim settingsFilePath As String = Path.Combine(knightlightFolderPath, "GUISettings.json")

        If Not File.Exists(settingsFilePath) Then
            ' File doesn't exist, create it with default values
            SaveData()
        End If

        Dim json As String = File.ReadAllText(settingsFilePath)
        Settings = JsonConvert.DeserializeObject(Of cSettings)(json)
        If Settings.Windows.Count > 2 Then
            Settings.Windows.RemoveAt(0)
        End If
    End Sub
End Module
Public Class cSettings
    Implements INotifyPropertyChanged
    Public Property LastBank As String = "DefaultBank"
    Public Property LoadonChange As Boolean = True
    Public Property ChannelCount As Integer = 2048
    Public Property DimmerChannelRows As Integer = 0

    Public Property Windows As New List(Of WindowSettings) From {
            New WindowSettings With {
                .WindowI = "9",
                .Left = 312,
                .Top = 312,
                .Height = 637,
                .Width = 1560,
                .WindowState = 0
            }}
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
    Public Class WindowSettings
        Public Property WindowI As Integer
        Public Property Left As Integer
        Public Property Top As Integer
        Public Property Height As Integer
        Public Property Width As Integer
        Public Property WindowState As WindowState
    End Class
End Class


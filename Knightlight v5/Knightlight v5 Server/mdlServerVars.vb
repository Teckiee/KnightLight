Imports System.Net
Imports System.Runtime
Imports Hardcodet.Wpf.TaskbarNotification
Imports Newtonsoft.Json
Imports System.IO
Imports Knightlight_v5_Library
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Collections.ObjectModel

Module mdlServerVars
    Public tbi As New TaskbarIcon
    Public serverWindow1 As ServerWindow
    Public OSC As cOSCControls
    Public Settings As New cSettings()
    Public DMXdata As cDMXdata
    Public vDBConnections As cDBconnections
    Public knightlightFolderPath As String
    ' sql file per show = Banks
    ' store fixtures program wide
    ' sql table 


    Sub SaveData()
        Dim json As String = JsonConvert.SerializeObject(Settings, Formatting.Indented)
        Dim settingsFilePath As String = Path.Combine(knightlightFolderPath, "ServerSettings.json")
        File.WriteAllText(settingsFilePath, json)
    End Sub

    Sub LoadData()
        ' Get the path to the user's Documents folder
        Dim documentsPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ' Construct the path to the Knightlight folder
        knightlightFolderPath = Path.Combine(documentsPath, "Knightlight")
        ' Create the Knightlight folder if it doesn't exist
        If Not Directory.Exists(knightlightFolderPath) Then
            Directory.CreateDirectory(knightlightFolderPath)
        End If
        ' Construct the full path to the Settings.json file
        Dim settingsFilePath As String = Path.Combine(knightlightFolderPath, "ServerSettings.json")

        If Not File.Exists(settingsFilePath) Then
            ' File doesn't exist, create it with default values
            SaveData()
        End If

        Dim json As String = File.ReadAllText(settingsFilePath)
        Settings = JsonConvert.DeserializeObject(Of cSettings)(json)


    End Sub
End Module

Public Class cSettings
    Implements INotifyPropertyChanged
    Public Property LastBank As String = "DefaultBank"
    Public Property UniverseCount As Integer = 1
    Public Property LoadonChange As Boolean = True
    Public Property ChannelCount As Integer = 2048
    Public Property DimmerChannelRows As Integer = 0
    Public Property ChannelBulletColour As Color = Colors.Magenta
    Public Property ChannelBackColour As Color = Colors.DimGray
    Public Property ChannelFillColour As Color = Colors.Black
    Public Property ChannelNumberColour As Color = Colors.Magenta
    Public Property SceneBulletColour As Color = Colors.Blue
    Public Property SceneBackColour As Color = Colors.Green
    Public Property SceneFillColour As Color = Colors.Black
    Private Property _SceneLabelColour As Color = Colors.Magenta
    Public Property SceneLabelColour As Color
        Get
            Return _SceneLabelColour
        End Get
        Set(value As Color)
            If _SceneLabelColour <> value Then
                _SceneLabelColour = value
                OnPropertyChanged()
            End If
        End Set
    End Property
    Public Property SceneBorderColour As Color = Colors.Gold
    Public Property SongChangeColour As Color = Colors.Magenta
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
    Public Property LastOpenedShow As String = "database.db"

    Structure ArduinoDevices1
        Dim PortName As String
        Dim Job As String
    End Structure
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub OnPropertyChanged(<CallerMemberName> Optional propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
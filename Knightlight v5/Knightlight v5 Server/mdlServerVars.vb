Imports System.Net
Imports System.Runtime
Imports Hardcodet.Wpf.TaskbarNotification
Imports Newtonsoft.Json
Imports System.IO
Imports Knightlight_v5_Library

Module mdlServerVars
    Public tbi As New TaskbarIcon
    Public serverWindow1 As ServerWindow
    Public OSC As cOSCControls
    Public Settings As New GlobalSettings()



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
        Settings = JsonConvert.DeserializeObject(Of GlobalSettings)(json)
    End Sub
End Module

Public Class GlobalSettings
    Public Property LastBank As String = "DefaultBank"
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
    Public Property SceneLabelColour As Color = Colors.Magenta
    Public Property SceneBorderColour As Color = Colors.Gold
    Public Property SongChangeColour As Color = Colors.Magenta
    Public Property MultipleThreadCount As Boolean = False
    Public Property ResaveOnSceneLoad As Boolean = False
    Public Property ScenesWithFader As Boolean = True
    Public Property ASIOMode As Boolean = False
    Public Property MusicNextFollows As Boolean = True
    Public Property AudioLatency As Integer = 0
    Public Property AudioDesiredSamplerate As Integer = 48000
    Public Property ServerIPaddress As IPAddress = IPAddress.Parse("127.0.0.1")
    Public Property ServerPort As Integer = 50000
    Public Property ClientPorts As Integer = 50001
End Class
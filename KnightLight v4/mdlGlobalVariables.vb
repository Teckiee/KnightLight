Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports NAudio.Wave
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module mdlGlobalVariables
    Public frmMain As FormMain
    'Public frmTouchPad As FormTouchPad
    Public frmDimmerAutomation(20) As FormDimmerAutomation
    Public controlcolour As Color
    Public frmGradientColour As FormColourGradient
    Public frmCustomColourPicker1 As FormColourPicker
    Public frmChannels As FormChannels

    'Public DMX As New Arduino_DMX_USB.Main
    Public ArduDMX As ArduinoDMX

    Public cMidi As cMidiController
    Public MidiEnabled As Boolean = False
    'Public sACNController As SACN_Sender

    'Public WithEvents Player(200) As New WMPLib.WindowsMediaPlayer
    'Public WithEvents Player2 As New WMPLib.WindowsMediaPlayer
    Public formopened As Boolean = False
    Public Testmode As Boolean = False
    Public ChannelControlSetsPerPage As Integer = 0
    Public PresetFadersTotal As Integer = 0
    Public ChannelFaderPageCurrentSceneDataIndex As Integer = 1
    Public PagingChanged As Boolean = False
    Public BankChanged As Boolean = False
    Public SoundActivationCurrentLevel As Integer = 0
    Public closethreads As Boolean = False
    Public enableUID As Boolean = False

    Public JoySensitivity As Integer = 20

    Public MarsConnected As Boolean = False

    Public SceneData(600) As Scenes1
    Public SceneDataLocations As New Dictionary(Of Integer, SCLocs)
    Public tChannelsMultipleThreads As Boolean = False
    Public tChannels(2048) As System.Threading.Thread
    'Public tTouchPadLoad As System.Threading.Thread
    'Public SentChannelValues(2048) As Integer
    Public FadersRenaming As Boolean = False
    Public TouchButtons(600) As Button
    Public otherChanged As Boolean = False
    Public bWithFader As Boolean = False
    Public OtherAutomationTriggered As Boolean = False

    Public SceneControlHeightWithFader1 As Integer = 68
    Public SceneControlHeightWithoutFader1 As Integer = 42
    Public SceneControlHeight As Integer = 42

    Public borderColor As Color = Color.Goldenrod 'Border Color
    Public borderWidth As Integer = 1


    'Public VLCmain As LibVLC
    'Public SongDict1 As New Dictionary(Of SongChangesStr, Double)
    'Public SongDict2 As New Dictionary(Of SongChangesStr, Double)
    Public MusicCues(200) As MusicCues1
    Public AudioLatency As Integer 'Settings File Default 50
    Public AudioDesiredSamplerate As Integer = 44100 'Settings File Default 44100
    Public ASIOMode As Boolean
    Public AudioRun As AudioThread
    'Public asioOutputs(10) As AsioOut

    Public mPositioning(10) As cPositioning




    Public MarsConsole As cMarsConsole
    Public DMXdata As cDMXdata
    Public OSCcontrol As cOSC

    Public ResaveOnSceneLoad As Boolean = False

    Public Arduinos(20) As Arduinos1
    Public SCSIPaddress As String
    Public SCSPort As Integer


    Structure ArduinoModes
        Public Const ctlMusic1 As String = "ctlMusic1"
        Public Const ctlMusic2 As String = "ctlMusic2"
        Public Const ctlDMX3Universe As String = "ctlDMX3Universe"
        Public Const ctlSoundActivation1 As String = "ctlSoundActivation1"
        Public Const ctlMarsConsole As String = "ctlMarsConsole"
        Public Const ctlJoystick As String = "ctlJoystick"
    End Structure

    Structure SCLocs
        Dim PresetIndex As Integer
        Dim PageNo As Integer
    End Structure
    Structure Arduinos1
        Dim PortNo As String
        Dim DeviceName As String
        Dim Job As String
        Dim UID As String
        Dim Serial As System.IO.Ports.SerialPort
        Dim HasDevice As Boolean
        Dim InUse As Boolean
    End Structure
    Structure MusicCues1
        Dim SongFileName As String
        Dim SongChanges() As SongChangesStr
        Dim IsMP3 As Boolean
        Dim IsSCS As Boolean
        Dim SCSinfo As SCSInfo1

        ' wave playback
        'Dim mp3Reader As Mp3FileReader
        'Dim waveOut As WaveOut

        'asio playback
        ' Dim AudioReader As AudioFileReader
        Dim AsioOutIndex As Integer
        'Dim asioOutput As AsioOut
        'Dim AsioInit As Boolean

        Dim SongChangesDict As Dictionary(Of SongChangesStr, Double)
    End Structure

    Structure SongChangesStr
        Dim TimeCode As Double
        Dim SceneName As String
        Dim SceneIndex As Integer
        Dim PresetFaderControlIndex As Integer
        Dim TimeToGoUp As Integer
        Dim TimeToGoDown As Integer
    End Structure
    Structure SCSInfo1
        Dim Qname As String
        Dim Length As Double
        'Dim SCStimer As Timer
        Dim swElapsed As Stopwatch
    End Structure

    'Public Delegate Sub ThreadloopVals(ChanNo)
    Structure Scenes1
        Dim SceneName As String
        Dim MasterValue As Double
        Dim ChannelValues() As SceneChannelValues
        Dim Automation As SceneAutomation1
        Dim PageNo As Integer
        Dim LocIndex As Integer

        Public Function Clone() As Scenes1
            Dim copy As Scenes1
            copy.SceneName = Me.SceneName
            copy.MasterValue = Me.MasterValue
            copy.PageNo = Me.PageNo
            copy.LocIndex = Me.LocIndex
            copy.Automation = Me.Automation ' Assuming SceneAutomation1 is a structure and doesn't need deep copying

            ' Deep copy the ChannelValues array
            If Me.ChannelValues IsNot Nothing Then
                copy.ChannelValues = New SceneChannelValues(Me.ChannelValues.Length - 1) {}
                For i As Integer = 0 To Me.ChannelValues.Length - 1
                    copy.ChannelValues(i) = Me.ChannelValues(i).Clone()
                Next
            End If

            Return copy
        End Function
    End Structure
    Structure SceneChannelValues
        Dim Value As Integer
        Dim Selected As Boolean
        Dim Automation As cChannelAutomation
        Public Function Clone() As SceneChannelValues
            Dim copy As SceneChannelValues
            copy.Value = Me.Value
            copy.Selected = Me.Selected
            If Me.Automation IsNot Nothing Then
                copy.Automation = CType(Me.Automation.Clone(), cChannelAutomation)
            Else
                copy.Automation = Nothing
            End If
            Return copy
        End Function
    End Structure
    Structure SceneAutomation1
        Dim Nickname As String
        Dim tTimer As NamedTimer
        'Dim tTimer As System.Windows.Forms.Timer
        Dim Max As Integer
        Dim Min As Integer
        Dim IntervalSteps As Double
        Dim randomstart As Boolean
        Dim tmrDirection As String
        Dim TimeBetweenMinAndMax As Integer
    End Structure

    Public Function CopySceneData(originalArray As Scenes1()) As Scenes1()
        Dim copiedArray(originalArray.Length - 1) As Scenes1

        For i As Integer = 0 To originalArray.Length - 1
            copiedArray(i) = originalArray(i).Clone()
        Next

        Return copiedArray
    End Function

    'Structure ChannelAutomation1
    '    'Dim tTimer As System.Windows.Forms.Timer
    '    Dim tTimer As NamedTimer
    '    'Dim RunTimer As Boolean
    '    Dim ProgressInOrder As Boolean
    '    Dim ProgressRandomTimed As Boolean
    '    Dim ProgressSoundActivated As Boolean
    '    Dim SoundActivationThreshold As Integer
    '    Dim ProgressLoop As Boolean
    '    Dim ProgressList As List(Of Integer)
    '    Dim CurrentIofList As Integer

    '    Dim oscAmplitude As Integer
    '    Dim oscCenter As Integer
    '    Dim oscFrequency As Integer
    '    Dim oscPhase As Integer
    '    Dim oscIndex As Integer
    '    Dim oscDirection As String

    '    Dim SoundLevel As Integer
    '    Dim SoundAttack As Integer
    '    Dim SoundRelease As Integer

    '    Dim AutomationMode As AutomationMode

    'End Structure

    '---------START CHANNEL and PRESET TABPAGE RELATED VARIABLES---------
    Public ChannelFaders(2048) As ctrlDimmerChannel
    Public PresetFaders(400) As PresetControls1
    Public FixtureControls(2048) As FixtureControls1
    Public tbpPresetsControls As New List(Of Control)
    Public frmChannelsControls As New List(Of Control)
    Public frmChannelAutomationControls As New List(Of Control)

    Structure ChannelControls1

        'Dim cChannelLabel As Label
        'Dim cFader As GScrollBar
        'Dim cSelected As Button
        'Dim cTxtVal As TextBox
        'Dim cFixtureDescr As Label
        Dim internalChannelFaderNumber As Integer

        'Dim cLongDescr As ToolTip

    End Structure

    Enum AutomationMode
        Off = 0
        Chase = 1
        Sine = 2
        Square = 3
        Triangle = 4
        Opposite = 5
    End Enum
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
        'Return CInt(Math.Ceiling(Rnd() * Max))
    End Function

    Structure PresetControls1
        'Dim cPresetName As Label
        'Dim cTxtVal As TextBox
        'Dim cAutoTime As NumericUpDown
        'Dim cBlackout As Button
        'Dim cFull As Button
        ''Dim cFader As GScrollBar
        'Dim border As Rectangle
        Dim cSceneControl As SceneControl1
        Dim OrigTop As Integer
        Dim OrigLeft As Integer
    End Structure

    Structure FixtureControls1
        Dim FixtureName As String
        Dim ForeColour As Color
        Dim BackColour As Color
        Dim IsDimmable As Boolean
        Dim ActionAndValues As String
        Dim IsFirst As Boolean
        Dim ChannelOfFixture As Integer
        Dim ParentChannelNo As Integer
        Dim LongDescr As String
        Dim Favourites() As String
        Dim fColPicker As FormColourPicker
        Dim ChannelCount As Integer
    End Structure

    '---------END CHANNEL TABPAGE RELATED VARIABLES---------

    Public Function Map(value As Double, fromSource As Double, toSource As Double, fromTarget As Double, toTarget As Double) As Double
        Return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget
    End Function

    Public Function IsUpdateAvailable() As Boolean
        Dim currentVersion As New Version(Application.ProductVersion)
        Dim latestVersion As New Version(GetLatestVersion())

        Return latestVersion > currentVersion
    End Function
    Public Function GetLatestVersion() As String
        Dim url As String = "https://api.github.com/repos/Teckiee/KnightLight/releases/latest"
        Dim webClient As New WebClient()
        webClient.Headers.Add("User-Agent", "request")

        Dim json As String = webClient.DownloadString(url)
        Dim release = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(json)

        Return release("tag_name").ToString()
    End Function
    Public Function GetLatestReleaseAssetUrl() As String
        Dim url As String = "https://api.github.com/repos/Teckiee/KnightLight/releases/latest"
        Dim webClient As New WebClient()
        webClient.Headers.Add("User-Agent", "request")

        Dim json As String = String.Empty
        Try
            json = webClient.DownloadString(url)
        Catch ex As Exception
            ' Handle exceptions or errors here
            Return String.Empty
        End Try

        Dim release = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(json)
        Dim assets As JArray = release("assets")
        Dim assetUrl As String = String.Empty

        For Each asset In assets
            ' Assuming you have only one asset or you know the name pattern of your asset
            ' Adjust the condition to match your asset name if necessary
            assetUrl = asset("browser_download_url").ToString()
            Exit For ' Remove this if you need to iterate through more assets
        Next

        Return assetUrl
    End Function

End Module
Public Class Vector3
    Public Property X As Double
    Public Property Y As Double
    Public Property Z As Double

    Public Sub New(x As Double, y As Double, z As Double)
        Me.X = x
        Me.Y = y
        Me.Z = z
    End Sub

    Public Shared Operator -(v1 As Vector3, v2 As Vector3) As Vector3
        Return New Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z)
    End Operator
End Class

Imports System.Net
Imports System.Net.Sockets
Imports NAudio.Wave

Module mdlGlobalVariables
    Public frmMain As FormMain
    'Public frmTouchPad As FormTouchPad
    'Public frmDimmerAutomation(20) As FormDimmerAutomation
    Public controlcolour As Color
    Public frmGradientColour As FormColourGradient
    Public frmCustomColourPicker1 As FormColourPicker
    Public frmChannels As FormChannels

    'Public DMX As New Arduino_DMX_USB.Main
    Public ArduDMX As ArduinoDMX
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




    Public MarsConsole As cMarsConsole
    Public DMXdata As cDMXdata

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
    End Structure
    Structure SceneChannelValues
        Dim Value As Integer
        Dim Selected As Boolean
        Dim Automation As cChannelAutomation
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
    End Structure

    '---------END CHANNEL TABPAGE RELATED VARIABLES---------


End Module

Imports System.IO
Imports NAudio.Wave
Imports System.Threading
Public Class AudioThread

    Dim MainThread As System.Threading.Thread
    Dim AsioDevices(20) As AsioDevices1
    Dim iVolume As Integer
    Dim AudioCues(MusicCues.Length) As AudioCues1

    Public Sub New() 'ByRef abData() As Byte, ByRef abKey() As Byte, ByVal n As Integer, ByRef abInitV() As Byte)
        LoadInfo()
        LoadSettingsFile()

        'MainThread = New System.Threading.Thread(AddressOf AudioLoop)
        'MainThread.Start()
    End Sub
    Private Sub LoadInfo()

        Dim asio() As String = AsioOut.GetDriverNames()
        Dim iAsio As Integer = 0
        Do Until iAsio >= asio.Length
            AsioDevices(iAsio).DeviceName = asio(iAsio)
            AsioDevices(iAsio).NumberAssigned = 0
            'Dim newrow As New ListViewItem
            'newrow.Text = 0
            'newrow.SubItems.Add(asio(iAsio))
            'lstASIOInterfaces.Items.Add(newrow)
            iAsio += 1
        Loop
        'Do Until iAsio >= AsioDevices.Length
        '    AsioDevices(iAsio).IsActive = False
        '    AsioDevices(iAsio).NumberAssigned = -1
        '    iAsio += 1
        'Loop

    End Sub
    Private Sub LoadSettingsFile()
        FileOpen(8, Application.StartupPath & "\AsioDriverSettings.ini", OpenMode.Input)

        Do Until EOF(8)
            Dim a() As String = Split(LineInput(8), "=")
            'a(0) = interface name
            'a(1) = #
            Dim I As Integer = 0
            Do Until I >= AsioDevices.Length
                If AsioDevices(I).DeviceName = a(0) Then
                    AsioDevices(I).NumberAssigned = Val(a(1))
                End If
                I += 1
            Loop

        Loop
        FileClose(8)
    End Sub
    Private Sub SaveSettingsFile()
        FileOpen(8, Application.StartupPath & "\AsioDriverSettings.ini", OpenMode.Output)
        Dim I As Integer = 0
        Do Until I >= AsioDevices.Length
            If Not AsioDevices(I).NumberAssigned <= 0 Then
                PrintLine(8, AsioDevices(I).DeviceName & "=" & AsioDevices(I).NumberAssigned)
            End If
            I += 1
        Loop

        FileClose(8)
    End Sub

    'Public Sub SetupAsioOutputs()
    '    Dim I As Integer = 0

    '    Do Until I >= AudioCues.Length
    '        If Not AudioCues(I).SongFileName Is Nothing Then

    '            AudioCues(I).asioOutput = New AsioOut(AsioDevices(AsioIndex(AudioCues(I).AsioOutIndex)).DeviceName)
    '            AudioCues(I).asioOutput.ChannelOffset = 0
    '            If AudioCues(I).AudioReader.WaveFormat.SampleRate = 44100 Then

    '            End If
    '            AudioCues(I).asioOutput.Init(AudioCues(I).AudioReader)


    '        End If

    '        I += 1
    '    Loop
    'End Sub
    Sub ClearTracks()
        Dim I As Integer = 0
        Do Until I >= AudioCues.Length
            AudioCues(I).SongFileName = ""
            If AudioCues(I).mp3Reader IsNot Nothing Then AudioCues(I).mp3Reader.Dispose()
            AudioCues(I).mp3Reader = Nothing
            If AudioCues(I).waveOut IsNot Nothing Then AudioCues(I).waveOut.Dispose()
            AudioCues(I).waveOut = Nothing
            AudioCues(I).AudioReader = Nothing
            If AudioCues(I).AudioReader IsNot Nothing Then AudioCues(I).AudioReader.Dispose()
            AudioCues(I).AsioOutIndex = 0
            If AudioCues(I).asioOutput IsNot Nothing Then AudioCues(I).asioOutput.Dispose()
            AudioCues(I).asioOutput = Nothing
            AudioCues(I).HasBeenInitd = False

            I += 1
        Loop


    End Sub

    Sub PrepareTrack(FullPath As String)
        Dim I As Integer = 0
        Do Until I >= AudioCues.Length
            If AudioCues(I).SongFileName = Path.GetFileNameWithoutExtension(FullPath) Then
                'exists
                'Setup WASAPI
                AudioCues(I).mp3Reader = New AudioFileReader(FullPath)
                AudioCues(I).waveOut = New WaveOut
                AudioCues(I).waveOut.DesiredLatency = AudioLatency
                AudioCues(I).waveOut.Init(AudioCues(I).mp3Reader)

                'Setup ASIO
                AudioCues(I).AudioReader = New AudioFileReader(FullPath)

                Exit Do
            ElseIf AudioCues(I).SongFileName = "" Then
                ' is new
                AudioCues(I).SongFileName = Path.GetFileNameWithoutExtension(FullPath)
                'Setup WASAPI
                AudioCues(I).mp3Reader = New AudioFileReader(FullPath)
                AudioCues(I).waveOut = New WaveOut
                AudioCues(I).waveOut.DesiredLatency = AudioLatency
                AudioCues(I).waveOut.Init(AudioCues(I).mp3Reader)

                'Setup ASIO
                AudioCues(I).AudioReader = New AudioFileReader(FullPath)
                AudioCues(I).AsioOutIndex = 1
                If ASIOMode = True Then
                    Dim indx As Integer = AsioIndex(AudioCues(I).AsioOutIndex)
                    AudioCues(I).asioOutput = New AsioOut(AsioDevices(indx).DeviceName)
                    AudioCues(I).asioOutput.ChannelOffset = 0

                    If AudioCues(I).AudioReader.WaveFormat.SampleRate = 44100 Then

                        If AudioCues(I).HasBeenInitd = False Then
                            AudioCues(I).asioOutput.Init(AudioCues(I).AudioReader)
                            AudioCues(I).HasBeenInitd = True
                        End If
                    Else
                        ResampleFile(FullPath, I)

                        AudioCues(I).AudioReader = New AudioFileReader(FullPath)
                        AudioCues(I).AsioOutIndex = 1
                        AudioCues(I).asioOutput = New AsioOut(AsioDevices(AsioIndex(AudioCues(I).AsioOutIndex)).DeviceName)
                        AudioCues(I).asioOutput.ChannelOffset = 0


                    End If

                End If
                Exit Do
            End If
            I += 1
        Loop

    End Sub
    Sub ResampleFile(FullPath As String, Qindex As Integer)
        Dim outRate As Integer = 44100
        'Dim inFile As String = FullPath
        Dim outFile As String = Path.GetDirectoryName(FullPath) & "\" & Path.GetFileNameWithoutExtension(FullPath) & " resampled.mp3"

        'Using reader As New Mp3FileReader(inFile)
        'Dim outFormat2 = New WaveFormat(outRate, AudioCues(I).AudioReader.WaveFormat.Channels)
        Dim outFormat = New WaveFormat(outRate, AudioCues(Qindex).AudioReader.WaveFormat.Channels) ', 32, 352800
        Using resampler As New MediaFoundationResampler(AudioCues(Qindex).AudioReader, outFormat)

            WaveFileWriter.CreateWaveFile(outFile, resampler)

        End Using

        AudioCues(Qindex).AudioReader.Dispose()
        AudioCues(Qindex).AudioReader = Nothing

        'File.Move(FullPath, Path.GetDirectoryName(FullPath) & "\" & Path.GetFileNameWithoutExtension(FullPath) & ".mp3.old")
        'File.Move(outFile, FullPath)



        ' resampler.ResamplerQuality = 60;
        'AudioCues(I).asioOutput.Init(AudioCues(I).resampler)
        'AudioCues(I).resampled = True

        '  End Using
        'End Using
    End Sub
    Sub DisposeAsio()
        If formopened = False Then Exit Sub
        Dim I As Integer = 0
        Do Until I >= AudioCues.Length
            If Not AudioCues(I).SongFileName Is Nothing Then
                If Not AudioCues(I).asioOutput Is Nothing Then
                    AudioCues(I).asioOutput.Dispose()
                End If
            End If

            I += 1
        Loop
    End Sub

    Private Function AsioIndex(ByVal DeviceNo As Integer) As Integer
        Dim I As Integer = 0
        If DeviceNo <= 0 Then
            Return -1
            Exit Function
        End If

        Do Until I >= AsioDevices.Length
            If AsioDevices(I).NumberAssigned = DeviceNo Then
                Return I
            End If

            I += 1
        Loop


    End Function

    'Public Sub start()
    '    MainThread.Start()
    'End Sub
    Public Sub join()
        MainThread.Join()
    End Sub
    Public Sub mPlay(TrackName As String)

        Dim Qindex As Integer = GetAudioCueIndex(TrackName)

        If ASIOMode = True Then

            'MusicCues(Qindex).asioOutput.Init(MusicCues(Qindex).AudioReader)

            AudioCues(Qindex).AudioReader.Volume = (iVolume / 100)
            AudioCues(Qindex).AudioReader.CurrentTime = TimeSpan.FromSeconds(0)
            AudioCues(Qindex).asioOutput.Play() ' start playing


        Else
            AudioCues(Qindex).mp3Reader.CurrentTime = TimeSpan.FromSeconds(0)
            AudioCues(Qindex).waveOut.Volume = (iVolume / 100)
            AudioCues(Qindex).waveOut.Play()
        End If
        frmMain.tmrMP3.Start()
        'frmMain.updatePlayer()
    End Sub
    Public Sub mStop(TrackName As String)
        Dim Qindex As Integer = GetAudioCueIndex(TrackName)
        If ASIOMode = True Then
            AudioCues(Qindex).asioOutput.Stop()
        Else
            AudioCues(Qindex).waveOut.Stop()
        End If
        frmMain.tmrMP3.Stop()
    End Sub
    Public Sub mPause(TrackName As String)
        Dim Qindex As Integer = GetAudioCueIndex(TrackName)
        If ASIOMode = True Then
            AudioCues(Qindex).asioOutput.Pause()
        Else
            AudioCues(Qindex).waveOut.Pause()
        End If
        frmMain.tmrMP3.Enabled = False
    End Sub
    Public Sub mResume(TrackName As String)
        Dim Qindex As Integer = GetAudioCueIndex(TrackName)
        If ASIOMode = True Then
            AudioCues(Qindex).asioOutput.Play()
        Else
            AudioCues(Qindex).waveOut.Resume()
        End If
        frmMain.tmrMP3.Start()
    End Sub
    Public Sub AudioLoop()

        Do While closethreads = False
            Thread.Sleep(1000)



        Loop

    End Sub
    Public Property DeviceNumber(sDeviceName As String) As Integer

        Get
            Dim I As Integer = 0
            Do Until AsioDevices(I).DeviceName = sDeviceName
                I += 1
                If I > AsioDevices.Length Then Return 0
            Loop
            Return AsioDevices(I).NumberAssigned
        End Get
        Set(ByVal iNum As Integer)
            Dim I As Integer = 0
            Do Until AsioDevices(I).DeviceName = sDeviceName
                I += 1
                If I >= AsioDevices.Length Then Exit Property
            Loop
            AsioDevices(I).NumberAssigned = iNum
            SaveSettingsFile()
        End Set

    End Property
    Public ReadOnly Property DeviceDetails(iDeviceIndex As Integer) As AsioDevices1

        Get
            Return AsioDevices(iDeviceIndex)
        End Get

    End Property

    Public ReadOnly Property AsioDeviceCount() As Integer

        Get

            Return AsioDevices.Length
        End Get

    End Property
    Public ReadOnly Property TotalTime(TrackName As String, Optional InMillis As Boolean = False) As String

        Get
            Dim Qindex As Integer = GetAudioCueIndex(TrackName)
            If ASIOMode = True Then
                If InMillis = True Then
                    Return AudioCues(Qindex).AudioReader.TotalTime.TotalSeconds.ToString
                Else
                    Return AudioCues(Qindex).AudioReader.TotalTime.ToString("mm\:ss")
                End If
            Else
                If InMillis = True Then
                    Return AudioCues(Qindex).mp3Reader.TotalTime.TotalSeconds.ToString
                Else
                    Return AudioCues(Qindex).mp3Reader.TotalTime.ToString("mm\:ss")
                End If
            End If

        End Get

    End Property
    Public Property CurrentPosition(TrackName As String, Optional InMillis As Boolean = False) As String

        Get
            Dim Qindex As Integer = GetAudioCueIndex(TrackName)
            If ASIOMode = True Then
                If InMillis = True Then
                    Return AudioCues(Qindex).AudioReader.CurrentTime.TotalSeconds.ToString
                Else
                    Return AudioCues(Qindex).AudioReader.CurrentTime.ToString("mm\:ss")
                End If

            Else
                If InMillis = True Then
                    Return AudioCues(Qindex).mp3Reader.CurrentTime.TotalSeconds.ToString
                Else
                    Return AudioCues(Qindex).mp3Reader.CurrentTime.ToString("mm\:ss")
                End If

            End If
        End Get
        Set(ByVal MilliPosition As String)
            MilliPosition = Convert.ToDouble(MilliPosition)
            Dim Qindex As Integer = GetAudioCueIndex(TrackName)
            If ASIOMode = True Then
                AudioCues(Qindex).AudioReader.CurrentTime = TimeSpan.FromSeconds(MilliPosition)
            Else
                AudioCues(Qindex).mp3Reader.CurrentTime = TimeSpan.FromSeconds(MilliPosition)
            End If
        End Set

    End Property
    Public Property Volume() As Integer

        Get
            Return iVolume
        End Get
        Set(ByVal iVol As Integer)
            iVolume = iVol
        End Set

    End Property
    Private Function GetMusicCueIndex(ByVal CueName As String) As Integer
        Dim I As Integer = 0
        Do Until I >= MusicCues.Length
            If MusicCues(I).SongFileName = CueName Then
                Return I
                Exit Function
            End If
            I += 1
        Loop
    End Function
    Private Function GetAudioCueIndex(ByVal CueName As String) As Integer
        Dim I As Integer = 0
        Do Until I >= MusicCues.Length
            If MusicCues(I).SongFileName = CueName Then
                Return I
                Exit Function
            End If
            I += 1
        Loop
    End Function

    Structure AsioDevices1
        Dim DeviceName As String
        Dim NumberAssigned As Integer
        'Dim IsActive As Boolean
    End Structure
    Structure AudioCues1
        Dim SongFileName As String

        ' wave playback
        Dim mp3Reader As AudioFileReader
        'Dim mp3Reader As Mp3FileReader
        Dim waveOut As WaveOut

        'asio playback
        Dim AudioReader As AudioFileReader
        Dim AsioOutIndex As Integer
        Dim asioOutput As AsioOut
        Dim HasBeenInitd As Boolean

        'Dim resampled As Boolean
        'Dim resampler As MediaFoundationResampler

    End Structure
End Class
Imports NAudio.Wave
Imports System.Diagnostics.Eventing
Imports System.IO
Imports System.Threading

Public Class AudioThread

    Dim MainThread As System.Threading.Thread
    Dim AsioDevices(20) As AsioDevices1
    Dim iVolume As Integer
    Dim AudioCues(MusicCues.Length) As AudioCues1

    Dim HasLoaded As Boolean = False

    Public Sub New() 'ByRef abData() As Byte, ByRef abKey() As Byte, ByVal n As Integer, ByRef abInitV() As Byte)

        MainThread = New System.Threading.Thread(AddressOf AudioLoop)
        MainThread.IsBackground = True
        MainThread.Start()
    End Sub
    Private Sub AudioLoop()
        Do
            If HasLoaded = False Then ' do once
                LoadInfo()
                LoadSettingsFile()


                HasLoaded = True
            End If

            If cmdAudioThread.Count > 0 Then
                Dim MPCommand() As String = Split(cmdAudioThread(0), " ", 2)


                Select Case MPCommand(0)
                    Case "Play"
                        'If ASIOMode = True Then

                        '    'MusicCues(Qindex).asioOutput.Init(MusicCues(Qindex).AudioReader)

                        '    AudioCues(MPCommand(1)).AudioReader.Volume = (iVolume / 100)
                        '    AudioCues(MPCommand(1)).AudioReader.CurrentTime = TimeSpan.FromSeconds(0)
                        '    AudioCues(MPCommand(1)).asioOutput.Play() ' start playing


                        'Else
                        AudioCues(MPCommand(1)).mp3Reader.CurrentTime = TimeSpan.FromSeconds(0)
                        If AudioCues(MPCommand(1)).IsResampled Then AudioCues(MPCommand(1)).resampler.Reposition()
                        AudioCues(MPCommand(1)).waveOut.Volume = (iVolume / 100)
                        AudioCues(MPCommand(1)).waveOut.Play()
                        'End If
                        cmdAudioThread.RemoveAt(0)
                    Case "Stop"
                        If Not AudioCues(MPCommand(1)).waveOut Is Nothing Then
                            'If ASIOMode = True Then
                            '    AudioCues(MPCommand(1)).asioOutput.Stop()
                            'Else
                            AudioCues(MPCommand(1)).waveOut.Stop()
                            'End If
                        End If
                        cmdAudioThread.RemoveAt(0)

                    Case "Pause"

                        'If ASIOMode = True Then
                        '    AudioCues(MPCommand(1)).asioOutput.Pause()
                        'Else

                        AudioCues(MPCommand(1)).waveOut.Pause()
                        'End If

                        cmdAudioThread.RemoveAt(0)

                    Case "Resume"
                        'If ASIOMode = True Then
                        '    AudioCues(MPCommand(1)).asioOutput.Play()
                        'Else
                        AudioCues(MPCommand(1)).waveOut.Play()
                        'End If
                        cmdAudioThread.RemoveAt(0)
                    Case "Prepare"
                        Dim I As Integer = 0
                        Dim Fullpath As String = MPCommand(1)
                        Do Until I >= AudioCues.Length
                            If AudioCues(I).SongFileName = Path.GetFileNameWithoutExtension(Fullpath) Or AudioCues(I).SongFileName = "" Then
                                ' is new
                                AudioCues(I).SongFileName = Path.GetFileNameWithoutExtension(Fullpath)
                                'Setup WASAPI
                                AudioCues(I).mp3Reader = New AudioFileReader(Fullpath)
                                AudioCues(I).waveOut = New WaveOut
                                AudioCues(I).waveOut.DesiredLatency = AudioLatency

                                If AudioCues(I).mp3Reader.WaveFormat.SampleRate <> 44100 Then
                                    ' Resample to 44100 Hz
                                    AudioCues(I).resampler = New MediaFoundationResampler(AudioCues(I).mp3Reader, New WaveFormat(AudioDesiredSamplerate, AudioCues(I).mp3Reader.WaveFormat.Channels))
                                    ' Set Resampler quality - 60 is high quality
                                    AudioCues(I).resampler.ResamplerQuality = 60
                                    AudioCues(I).IsResampled = True
                                    AudioCues(I).waveOut.Init(AudioCues(I).resampler)
                                Else
                                    ' No resampling needed, play as is
                                    AudioCues(I).waveOut.Init(AudioCues(I).mp3Reader)
                                End If

                                'AudioCues(I).waveOut.Init(AudioCues(I).mp3Reader)

                                Exit Do
                            End If
                            I += 1
                        Loop

                        cmdAudioThread.RemoveAt(0)
                        'If cmdAudioThread.Count = 0 Then
                        '    frmMain.UpdateFromAudioThread("PrepareDone")
                        'End If

                End Select

            End If



            Thread.Sleep(10)
        Loop
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
        'FileOpen(8, Application.StartupPath & "\AsioDriverSettings.ini", OpenMode.Input, OpenAccess.Read)

        'Do Until EOF(8)
        '    Dim a() As String = Split(LineInput(8), "=")
        '    'a(0) = interface name
        '    'a(1) = #
        '    Dim I As Integer = 0
        '    Do Until I >= AsioDevices.Length
        '        If AsioDevices(I).DeviceName = a(0) Then
        '            AsioDevices(I).NumberAssigned = Val(a(1))
        '        End If
        '        I += 1
        '    Loop

        'Loop
        'FileClose(8)

        Using r As StreamReader = New StreamReader(Application.StartupPath & "\AsioDriverSettings.ini")
            Dim line As String = r.ReadLine()
            Do While Not line = Nothing
                Dim a() As String = Split(line, "=")
                'a(0) = interface name
                'a(1) = #
                Dim I As Integer = 0
                Do Until I >= AsioDevices.Length
                    If AsioDevices(I).DeviceName = a(0) Then
                        AsioDevices(I).NumberAssigned = Val(a(1))
                    End If
                    I += 1
                Loop


                line = r.ReadLine
            Loop
        End Using

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
        cmdAudioThread.Add("Prepare " & FullPath)

    End Sub
    Sub ResampleFile(FullPath As String, Qindex As Integer)
        Dim outRate As Integer = 44100
        'Dim inFile As String = FullPath
        Dim outFile As String = Path.GetDirectoryName(FullPath) & "\" & Path.GetFileNameWithoutExtension(FullPath) & " resampled.wav"

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
    'Public Sub join()
    '    MainThread.Join()
    'End Sub
    Public Sub mPlay(TrackName As String, lstindex As Integer)
        Dim Qindex As Integer = GetAudioCueIndex(TrackName)
        cmdAudioThread.Add("Play " & Qindex)
        'Try
        '    OSCcontrol.SendPlay(lstindex + 1)
        'Catch ex As Exception

        'End Try

    End Sub
    Public Sub mStop(TrackName As String, lstindex As Integer)
        Dim Qindex As Integer = GetAudioCueIndex(TrackName)
        cmdAudioThread.Add("Stop " & Qindex)
        'Try
        '    OSCcontrol.SendStop(lstindex + 1)
        'Catch ex As Exception

        'End Try

    End Sub
    Public Sub mPause(TrackName As String, lstindex As Integer)
        Dim Qindex As Integer = GetAudioCueIndex(TrackName)
        cmdAudioThread.Add("Pause " & Qindex)
        'Try
        '    OSCcontrol.SendPause(lstindex + 1)
        'Catch ex As Exception

        'End Try

    End Sub
    Public Sub mResume(TrackName As String, lstindex As Integer)
        Dim Qindex As Integer = GetAudioCueIndex(TrackName)
        cmdAudioThread.Add("Resume " & Qindex)
        'Try
        '    OSCcontrol.SendResume(lstindex + 1)
        'Catch ex As Exception

        'End Try

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
            'If ASIOMode = True Then
            '    If InMillis = True Then
            '        Return AudioCues(Qindex).AudioReader.TotalTime.TotalSeconds.ToString
            '    Else
            '        Return AudioCues(Qindex).AudioReader.TotalTime.ToString("mm\:ss")
            '    End If
            'Else
            Try
                If InMillis = True Then
                    Return AudioCues(Qindex).mp3Reader.TotalTime.TotalSeconds.ToString
                Else
                    Return AudioCues(Qindex).mp3Reader.TotalTime.ToString("mm\:ss")
                End If
            Catch ex As Exception
                Return 0
            End Try

            'End If

        End Get

    End Property

    Public ReadOnly Property TrackStatus(TrackName As String) As String

        Get
            Dim Qindex As Integer = GetAudioCueIndex(TrackName)
            'If ASIOMode = True Then
            '    Return AudioCues(Qindex).asioOutput.PlaybackState
            'Else
            Try
                Return AudioCues(Qindex).waveOut.PlaybackState
            Catch ex As Exception

            End Try

            'End If

        End Get

    End Property
    Public Property CurrentPosition(TrackName As String, Optional InMillis As Boolean = False) As String

        Get
            Dim Qindex As Integer = GetAudioCueIndex(TrackName)
            If ASIOMode = True Then
                If InMillis = True Then
                    Return AudioCues(Qindex).AudioReader.CurrentTime.TotalSeconds
                Else
                    Return AudioCues(Qindex).AudioReader.CurrentTime.ToString("mm\:ss")
                End If

            Else
                Try
                    If InMillis = True Then
                        Return AudioCues(Qindex).mp3Reader.CurrentTime.TotalSeconds
                    Else
                        Return AudioCues(Qindex).mp3Reader.CurrentTime.ToString("mm\:ss")
                    End If
                Catch ex As Exception
                    Return 0
                End Try


            End If
        End Get
        Set(ByVal MilliPosition As String)
            MilliPosition = Convert.ToDouble(MilliPosition)
            Dim Qindex As Integer = GetAudioCueIndex(TrackName)
            If ASIOMode = True Then
                AudioCues(Qindex).AudioReader.CurrentTime = TimeSpan.FromSeconds(MilliPosition)
            Else

                AudioCues(Qindex).mp3Reader.CurrentTime = TimeSpan.FromSeconds(MilliPosition)
                If AudioCues(Qindex).IsResampled Then AudioCues(Qindex).resampler.Reposition()
            End If
        End Set

    End Property
    Public Property Volume() As Integer

        Get
            Return iVolume
        End Get
        Set(ByVal iVol As Integer)
            iVolume = iVol
            Dim I As Integer = 0
            Do Until I >= AudioCues.Length
                If AudioCues(I).AudioReader IsNot Nothing Then
                    AudioCues(I).AudioReader.Volume = (iVolume / 100)
                End If
                If AudioCues(I).waveOut IsNot Nothing Then
                    AudioCues(I).waveOut.Volume = (iVolume / 100)
                End If
                I += 1
            Loop
        End Set

    End Property
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
    Public Function GetMusicCueIndex(ByVal CueName As String) As Integer
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
        Dim resampler As MediaFoundationResampler
        Dim IsResampled As Boolean

        'asio playback
        Dim AudioReader As AudioFileReader
        Dim AsioOutIndex As Integer
        Dim asioOutput As AsioOut
        Dim HasBeenInitd As Boolean

        Dim wp As BufferedWaveProvider

    End Structure

    Public waveformat1 As New WaveFormat(48000, 2)
End Class
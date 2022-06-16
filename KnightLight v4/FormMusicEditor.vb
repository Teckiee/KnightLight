Option Strict Off
Option Explicit On
Imports System.IO
Imports EnttecOpenDMX.OpenDMX
Imports System.Threading
Imports Midi
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports NAudio.Wave
Imports System.Management
Public Class FormMusicEditor
    Private Sub FormMusicEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        frmMusicEditor.Hide()
    End Sub

    Private Sub lstSongEditPresets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSongEditPresets.SelectedIndexChanged
        'PresetControls(PresetIndex(lstPrsets.SelectedItem)).vtxtBox.Text = 100
        If lstSongEditPresets.SelectedIndex = -1 Then Exit Sub

        frmScenes.cmdPresetsBlackoutAllInstant_Click(sender, e)
        ' PresetControls(PresetIndex(lstPrsets.SelectedItem)).vtxtBox.Text = 100

        Dim I As Integer = 1
        Do Until I >= SceneData.Length
            ' If SceneData(I).MasterValue = 0 Then 'preset is above blackout
            Dim J As Integer = 0
            Do Until J >= lstSongEditPresets.SelectedItems.Count
                If lstSongEditPresets.SelectedItems(J) = SceneData(I).SceneName Then

                    With SceneData(I)
                        .Automation.tmrDirection = "Up"
                        .Automation.IntervalSteps = 255 / (.Automation.TimeBetweenMinAndMax / .Automation.tTimer.Interval)
                        .Automation.tTimer.Start()
                    End With

                End If
                J += 1
            Loop
            '  End If

            I += 1
        Loop
    End Sub

    Private Sub vSongEdit_ValueChanged(sender As Object) Handles vSongEdit.ValueChanged
        If formopened = False Then Exit Sub
        If tmrchangedmp3 = True Then Exit Sub

        Player.controls.currentPosition = vSongEdit.Value

        updatePlayer()

    End Sub

    Private Sub cmdCreatelink_Click(sender As Object, e As EventArgs) Handles cmdCreatelink.Click
        If lstSongEditPresets.SelectedIndex = -1 Then Exit Sub

        lstMusicSongChanges.Items.Add(Math.Round(Player.controls.currentPosition, 2) & "|" & lstSongEditPresets.SelectedItem & "|" & numFadeOut.Value & "|" & numFadeIn.Value)
        'lstPresetsSongChanges.Items.Add(Player.controls.currentPosition & "|" & lstSongEditPresets.SelectedItem & "|" & numFadeOut.Value & "|" & numFadeIn.Value)
        ' lstDramaViewSongChanges.Items.Add(Player.controls.currentPosition & "|" & lstSongEditPresets.SelectedItem & "|" & numFadeOut.Value & "|" & numFadeIn.Value)
    End Sub

    Private Sub cmdEditSongOverwrite_Click(sender As Object, e As EventArgs) Handles cmdEditSongCopyNew.Click
        If lstSongEditPresets.SelectedIndex = -1 Then Exit Sub
        'If lstMusicSongChanges.SelectedIndex = -1 Then Exit Sub

        Dim defaultnewname As String = lstSongEditPresets.SelectedItem
        Dim newname As String = InputBox("Enter name of new Scene preset", , defaultnewname & " copy")
        If File.Exists(Application.StartupPath & "\Save Files\" & frmBanks.lstBanks.SelectedItem & "\" & lstSongEditPresets.SelectedItem & ".dmr") = True Then
            If File.Exists(Application.StartupPath & "\Save Files\" & frmBanks.lstBanks.SelectedItem & "\" & newname & ".dmr") = False Then
                File.Copy(Application.StartupPath & "\Save Files\" & frmBanks.lstBanks.SelectedItem & "\" & lstSongEditPresets.SelectedItem & ".dmr", Application.StartupPath & "\Save Files\" & frmBanks.lstBanks.SelectedItem & "\" & newname & ".dmr")
                lstSongEditPresets.Items.Add(newname)
                frmQuickChanges.lstDramaPresets.Items.Add(newname)

                Dim I As Integer = 1
                Do Until I >= SceneData.Count
                    If SceneData(I).SceneName = "" Then
                        SceneData(I).SceneName = newname
                        SceneData(I).Automation = SceneData(frmScenes.GetSceneIndex(lstSongEditPresets.SelectedItem)).Automation
                        SceneData(I).ChannelValues = SceneData(frmScenes.GetSceneIndex(lstSongEditPresets.SelectedItem)).ChannelValues
                        'PresetFaders(I).cPresetName.Text = oldprefix & " | " & newname
                        Dim J As Integer = 1
                        Do Until Split(PresetFaders(J).cPresetName.Text, "| ")(1) = ""
                            J += 1
                            If J >= PresetFaders.Count Then Exit Do
                        Loop

                        If Val(PresetFaders(J).cTxtVal.Tag) = I Then
                            Dim oldprefix As String = PresetFaders(J).cPresetName.Text
                            frmChannels.cmbChannelPresetSelection.Items.Item(I - 1) = oldprefix & newname
                            PresetFaders(J).cPresetName.Text = oldprefix & newname

                            lstMusicSongChanges.Items.Add(Math.Round(Player.controls.currentPosition, 2) & "|" & newname & "|" & numFadeOut.Value & "|" & numFadeIn.Value)
                            frmScenes.lstPresetsSongChanges.Items.Add(Math.Round(Player.controls.currentPosition, 2) & "|" & newname & "|" & numFadeOut.Value & "|" & numFadeIn.Value)
                            frmQuickChanges.lstDramaViewSongChanges.Items.Add(Math.Round(Player.controls.currentPosition, 2) & "|" & newname & "|" & numFadeOut.Value & "|" & numFadeIn.Value)
                            Exit Do
                        End If



                    End If
                    I += 1
                Loop


            End If

        End If

        'lstMusicSongChanges.Items.Item(lstMusicSongChanges.SelectedIndex) = Math.Round(Player.controls.currentPosition, 2) & "|" & lstSongEditPresets.SelectedItem & "|" & numFadeOut.Value & "|" & numFadeIn.Value
    End Sub

    Private Sub cmdEditSongSave_Click(sender As Object, e As EventArgs) Handles cmdEditSongSave.Click

        SongChanges1.Clear()
        FileOpen(1, Application.StartupPath & "\Save Files\" & frmBanks.lstBanks.SelectedItem & "\" & lstMusicSongs.SelectedItem & ".chg", OpenMode.Output)
        For Each S As String In lstMusicSongChanges.Items
            PrintLine(1, S)
            Dim NewSongChange As New SongChangesStr
            Dim a() As String = Split(S, "|")
            NewSongChange.TimeCode = a(0)
            NewSongChange.SceneName = a(1)
            NewSongChange.SceneIndex = frmScenes.GetSceneIndex(a(1))
            NewSongChange.TimeToGoUp = a(2)
            NewSongChange.TimeToGoDown = a(3)

            SongChanges1.Add(NewSongChange)
        Next S
        FileClose(1)
        Thread.Sleep(10)
        'lstSongs_SelectedIndexChanged(lstMusicSongs, e)


        Exit Sub

        'FileOpen(1, Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & lstPresetsSongs.SelectedItem & ".chg", OpenMode.Input)

        'Do Until EOF(1)
        '    Dim newline As String = LineInput(1)
        '    lstPresetsSongChanges.Items.Add(newline)
        '    lstMusicSongChanges.Items.Add(newline)
        '    lstDramaViewSongChanges.Items.Add(newline)



        'Loop

        ''Do Until EOF(1)
        ''    Dim a() As String = Split(LineInput(1), "|") 'time|Preset
        ''    Mp3Changes(I).Time = a(0)
        ''    Mp3Changes(I).PresetName = a(1)
        ''    I += 1
        ''Loop
        'FileClose(1)
    End Sub

    Private Sub lstMusicSongChanges_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMusicSongChanges.SelectedIndexChanged
        If lstMusicSongChanges.SelectedIndex = -1 Then Exit Sub
        If chkEnableSongEdit.Checked = False Then Exit Sub
        If EditUpdate = True Then Exit Sub
        Dim a() As String = Split(lstMusicSongChanges.SelectedItem, "|")
        txtEditTime.Text = a(0)
        lstSongEditPresets.SelectedItem = a(1)
        numFadeOut.Value = a(2)
        numFadeIn.Value = a(3)

    End Sub
    Dim EditUpdate As Boolean = False
    Private Sub cmdEditUpdate_Click(sender As Object, e As EventArgs) Handles cmdEditUpdate.Click
        If chkEnableSongEdit.Checked = False Then Exit Sub
        If lstMusicSongChanges.SelectedIndex = -1 Then Exit Sub
        EditUpdate = True
        Dim a() As String = Split(lstMusicSongChanges.SelectedItem, "|")
        lstMusicSongChanges.Items(lstMusicSongChanges.SelectedIndex) = txtEditTime.Text & "|" & lstSongEditPresets.SelectedItem & "|" & numFadeIn.Value & "|" & numFadeOut.Value
        Application.DoEvents()
        EditUpdate = False
    End Sub

#Region "Music Players"
    Private Sub chkEnableSongEdit_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnableSongEdit.CheckedChanged
        If lstMusicSongs.SelectedIndex = -1 Then
            chkEnableSongEdit.Checked = False
            Exit Sub
        End If

        If chkEnableSongEdit.Checked = True Then
            vSongEdit.Visible = True
            lstSongEditPresets.Visible = True
            lblFadeIn.Visible = True
            lblFadeOut.Visible = True
            numFadeIn.Visible = True
            numFadeOut.Visible = True
            chkRecordspace.Visible = True

            lbleditposition.Visible = True
            lbleditPositionMilli.Visible = True
            cmdCreatelink.Visible = True
            cmdEditSongCopyNew.Visible = True
            cmdEditSongSave.Visible = True

            Label20.Visible = True
            lbleditRemaining.Visible = True
            cmdEditPlay.Visible = True
            cmdEditStop.Visible = True


            'lstMusicSongChanges.Location = New Point(461, 482)

            'lstMusicSongChanges.Size = New Point(lstSongEditPresets.Size)
            'lstMusicSongChanges.Anchor = 3

            'lstSongEditPresets.Items.Clear()
            Dim I As Integer = 1
            'Do Until I >= PresetControls.Length
            '    If PresetControls(I).PresetName = "" Then
            '        Exit Do
            '    Else
            '        lstPrsets.Items.Add(PresetControls(I).PresetName)
            '    End If
            '    I += 1
            'Loop
        Else
            vSongEdit.Visible = False
            lstSongEditPresets.Visible = False
            lblFadeIn.Visible = False
            lblFadeOut.Visible = False
            numFadeIn.Visible = False
            numFadeOut.Visible = False

            lbleditposition.Visible = False
            lbleditPositionMilli.Visible = False
            cmdCreatelink.Visible = False
            cmdEditSongCopyNew.Visible = False
            cmdEditSongSave.Visible = False
            chkRecordspace.Visible = False

            Label20.Visible = False
            lbleditRemaining.Visible = False
            cmdEditPlay.Visible = False
            cmdEditStop.Visible = False
            ' lstMusicSongChanges.Location = New Point(414, 47)
            'lstMusicSongChanges.Size = New Point(231, 160)
            'lstMusicSongChanges.Anchor = AnchorStyles.Top
        End If


        'Dim wavdata As ReadWav1 = ReadWav("C:\Tempfiles\03 - Save A Horse (Ride A Cowboy).wav")


        'Dim ms As System.IO.FileStream = System.IO.File.OpenRead("C:\Users\Markus\Dropbox\ESC VB.NET\Super Awesome Lighting DMX board v4\bin\Debug\Save Files\Bank1\03 - Save A Horse (Ride A Cowboy).mp3")

        'Dim rdr As Mp3FileReader = New Mp3FileReader(ms)
        ''Dim wavStream As Mp3FileReader = WaveFormatConversionStream.CreatePcmStream(rdr)
        ''Dim baStream As BlockAlignReductionStream = New BlockAlignReductionStream(wavStream)
        ''Dim wave As WaveChannel32 = New WaveChannel32(baStream)


        ''Dim retMs = New MemoryStream()
        ''Dim rs = New RawSourceWaveStream(rdr, New WaveFormat(16000, 2))
        'Dim rs = New RawSourceWaveStream(rdr, New WaveFormat(44100, 16, 2))
        'Dim pcmStream As WaveStream = WaveFormatConversionStream.CreatePcmStream(rs)

        'Dim wave As WaveChannel32 = New WaveChannel32(pcmStream)

        'CustomWaves1.BackColor = Color.White
        'CustomWaves1.WaveStream = New NAudio.Wave.WaveFileReader("C:\Tempfiles\03 - Save A Horse (Ride A Cowboy).wav")
        ''CustomWaves1.WaveStream = pcmStream
        'CustomWaves1.Visible = True
        'CustomWaves1.FitToScreen()
        ''WaveViewer1.BackColor = Color.White
        ''WaveViewer1.WaveStream = pcmStream
        ''WaveViewer1.Visible = True

    End Sub

    Dim waveOut As WaveOut = New WaveOut(WaveCallbackInfo.FunctionCallback())

    Structure ReadWav1
        Dim audio
        Dim sampleRate
    End Structure
    Function ReadWav(ByVal filename As String)

        Using afr = New NAudio.Wave.AudioFileReader(filename)
            Dim sampleRate As Integer = afr.WaveFormat.SampleRate
            Dim sampleCount As Integer = Val(afr.Length / afr.WaveFormat.BitsPerSample / 8)
            Dim channelCount As Integer = afr.WaveFormat.Channels
            Dim audio = New List(Of Double)(sampleCount)
            Dim buffer = New Single(sampleRate * channelCount - 1) {}
            Dim samplesRead As Integer = 0
            'while ((samplesRead = afr.Read(buffer, 0, buffer.Length)) > 0)
            While (afr.Read(buffer, 0, buffer.Length)) > 0
                samplesRead = afr.Read(buffer, 0, buffer.Length)
                'audio.AddRange(buffer.Take(samplesRead).Select(x => (double)x));
                'audio.AddRange(buffer.Take(samplesRead).Select(Function(x) New With {Key x}))

                'mcArr.Select(Function(m) Double.Parse(m.ToString())).ToArray()
                audio.AddRange(buffer.Take(samplesRead).Select(Function(x) Double.Parse(x)))


                'mcArr.Select(Function(m) Double.Parse(m.ToString())).ToArray()
                'Dim numarr() As Double = Array.ConvertAll(Of Single, Double)(buffer.Take(samplesRead), Function(s) CDbl(s))
                'audio.AddRange(numarr)
                'audio.AddRange(Array.ConvertAll(buffer.Take(samplesRead), Function(X) Double.Parse(X)))


                'audio.AddRange(buffer.Take(samplesRead).Select(Of x >= (Double)x))
            End While

            Dim return1 As ReadWav1
            return1.audio = audio.ToArray()
            return1.sampleRate = sampleRate
            Return return1
        End Using
    End Function
    Private Sub tmrMP3_Tick(sender As Object, e As EventArgs) Handles tmrMP3.Tick
        updatePlayer()
    End Sub

    Private Sub tmrMP32_Tick(sender As Object, e As EventArgs) Handles tmrMP32.Tick
        updatePlayer2()
    End Sub
    Private Sub updatePlayer()
        tmrchangedmp3 = True

        ' Update TrackPostion
        With vSongEdit
            .Minimum = 0
            .Maximum = CInt(Player.currentMedia.duration)
            .Value = CInt(Player.controls.currentPosition())
        End With
        ' Display Current Time Position and Duration
        'lblMP3PositionMilli.Text = Player.controls.currentPosition ## is lower down
        frmScenes.lblPresetsMP3Duration.Text = Player.currentMedia.durationString
        lblMusicMP3Duration.Text = frmScenes.lblPresetsMP3Duration.Text
        frmQuickChanges.lblDramaViewMP3Duration.Text = frmScenes.lblPresetsMP3Duration.Text

        frmScenes.lblPresetsMP3Position.Text = Player.controls.currentPositionString
        lblMusicMP3Position.Text = frmScenes.lblPresetsMP3Position.Text
        frmQuickChanges.lblDramaViewMP3Position.Text = frmScenes.lblPresetsMP3Position.Text

        frmScenes.trkPresetsVolume.Value = Player.settings.volume
        trkMusicVolume.Value = frmScenes.trkPresetsVolume.Value
        frmQuickChanges.trkDramaViewVolume.Value = frmScenes.trkPresetsVolume.Value

        Dim PositionMilli As Double = Math.Round(Player.controls.currentPosition, 2)
        frmScenes.lblPresetsMP3PositionMilli.Text = PositionMilli
        lblMusicMP3PositionMilli.Text = PositionMilli
        frmQuickChanges.lblDramaViewMP3PositionMilli.Text = PositionMilli
        lbleditPositionMilli.Text = PositionMilli

        vSongEdit.Value = Val(frmScenes.lblPresetsMP3PositionMilli.Text)

        'If Val(Player.currentMedia.durationString) <= 0 Then Exit Sub

        If SongChanges1.Count > 0 Then
            If SongChangeIndexUpTo1 > -2 Then
                If SongChanges1(SongChangeIndexUpTo1 + 1).TimeCode <= Player.controls.currentPosition Then '    If NextMP3Change <= Player.controls.currentPosition And NextMP3Change > -1 Then 'MS
                    'do change
                    SongChangeIndexUpTo1 += 1
                    frmScenes.lstPresetsSongChanges.SelectedIndex = SongChangeIndexUpTo1
                    lstMusicSongChanges.SelectedIndex = SongChangeIndexUpTo1
                    frmQuickChanges.lstDramaViewSongChanges.SelectedIndex = SongChangeIndexUpTo1

                    'Dim d() As String = Split(lstPresetsSongChanges.SelectedItem, "|")                          ' 0|Blue|0|0    TIMECONDE | SCENENAME | UP-TIME | DOWN-TIME

                    If SongChangeIndexUpTo1 = 0 Then ' FIRST CHANGE OF THE SONG
                        frmScenes.cmdPresetsBlackoutAllInstant_Click(Nothing, Nothing)

                        If SongChanges1(SongChangeIndexUpTo1).TimeToGoUp = 0 Then 'numPresetChangeMS.Value = 0 Then
                            SceneData(SongChanges1(SongChangeIndexUpTo1).SceneIndex).MasterValue = 100
                            frmScenes.UpdatePresetControls(100, SongChanges1(SongChangeIndexUpTo1).SceneIndex)
                        Else
                            SceneData(SongChanges1(SongChangeIndexUpTo1).SceneIndex).Automation.tmrDirection = "Up"
                            SceneData(SongChanges1(SongChangeIndexUpTo1).SceneIndex).Automation.IntervalSteps = SceneData(SongChanges1(SongChangeIndexUpTo1).SceneIndex).Automation.Max / (SongChanges1(SongChangeIndexUpTo1).TimeToGoUp / SceneData(SongChanges1(SongChangeIndexUpTo1).SceneIndex).Automation.tTimer.Interval)
                            SceneData(SongChanges1(SongChangeIndexUpTo1).SceneIndex).Automation.tTimer.Start()
                        End If
                    Else  ' IN THE MIDDLE OF A SONG
                        'Dim e1() As String = Split(lstPresetsSongChanges.Items.Item(lstPresetsSongChanges.SelectedIndex - 1), "|")
                        ' Dim PreviousSceneIndex As Integer = GetSceneIndex(e1(1))

                        If SongChanges1(SongChangeIndexUpTo1 - 1).TimeToGoDown = 0 Then 'numPresetChangeMS.Value = 0 Then
                            SceneData(SongChanges1(SongChangeIndexUpTo1 - 1).SceneIndex).MasterValue = 0
                            frmScenes.UpdatePresetControls(0, SongChanges1(SongChangeIndexUpTo1 - 1).SceneIndex)
                        Else
                            SceneData(SongChanges1(SongChangeIndexUpTo1 - 1).SceneIndex).Automation.tmrDirection = "Down"
                            SceneData(SongChanges1(SongChangeIndexUpTo1 - 1).SceneIndex).Automation.IntervalSteps = SceneData(SongChanges1(SongChangeIndexUpTo1).SceneIndex).Automation.Max / (SongChanges1(SongChangeIndexUpTo1).TimeToGoDown / SceneData(SongChanges1(SongChangeIndexUpTo1).SceneIndex).Automation.tTimer.Interval)
                            SceneData(SongChanges1(SongChangeIndexUpTo1 - 1).SceneIndex).Automation.tTimer.Start()
                        End If  'cmdPresetBlackout_Click(PresetControls(PreviousSceneIndex).cmdBlackout, Nothing)


                        If SongChanges1(SongChangeIndexUpTo1).TimeToGoUp = 0 Then 'numPresetChangeMS.Value = 0 Then
                            SceneData(SongChanges1(SongChangeIndexUpTo1).SceneIndex).MasterValue = 100
                            frmScenes.UpdatePresetControls(100, SongChanges1(SongChangeIndexUpTo1).SceneIndex)
                        Else
                            SceneData(SongChanges1(SongChangeIndexUpTo1).SceneIndex).Automation.tmrDirection = "Up"
                            SceneData(SongChanges1(SongChangeIndexUpTo1).SceneIndex).Automation.IntervalSteps = SceneData(SongChanges1(SongChangeIndexUpTo1).SceneIndex).Automation.Max / (SongChanges1(SongChangeIndexUpTo1).TimeToGoUp / SceneData(SongChanges1(SongChangeIndexUpTo1).SceneIndex).Automation.tTimer.Interval)
                            SceneData(SongChanges1(SongChangeIndexUpTo1).SceneIndex).Automation.tTimer.Start()
                        End If 'cmdPresetFull_Click(PresetControls(NextSceneIndex).cmdFull, Nothing)


                    End If


                    'prep next change
                    If SongChanges1.Count <= SongChangeIndexUpTo1 + 1 Then ' no more changes
                        SongChangeIndexUpTo1 = -2
                        'Else
                        'Dim c1() As String = Split(lstPresetsSongChanges.Items.Item(lstPresetsSongChanges.SelectedIndex + 1), "|")
                        'NextMP3Change = c1(0)
                    End If
                End If

            End If

        End If

        'tmrMP3.Interval = 10
        tmrchangedmp3 = False

    End Sub

    Private Sub updatePlayer2()
        tmrchangedmp32 = True

        ' Update TrackPostion
        'With vSongEdit
        '    .Minimum = 0
        '    .Maximum = CInt(Player.currentMedia.duration)
        '    .Value = CInt(Player.controls.currentPosition())
        'End With
        ' Display Current Time Position and Duration
        'lblMP3PositionMilli.Text = Player.controls.currentPosition ## is lower down
        frmScenes.lblPresetsMP3Duration2.Text = Player2.currentMedia.durationString
        lblMusicMP3Duration2.Text = frmScenes.lblPresetsMP3Duration2.Text
        frmQuickChanges.lblDramaViewMP3Duration2.Text = frmScenes.lblPresetsMP3Duration2.Text

        frmScenes.lblPresetsMP3Position2.Text = Player2.controls.currentPositionString
        lblMusicMP3Position2.Text = frmScenes.lblPresetsMP3Position2.Text
        frmQuickChanges.lblDramaViewMP3Position2.Text = frmScenes.lblPresetsMP3Position2.Text

        frmScenes.trkPresetsVolume2.Value = Player2.settings.volume
        trkMusicVolume2.Value = frmScenes.trkPresetsVolume2.Value
        frmQuickChanges.trkDramaViewVolume2.Value = frmScenes.trkPresetsVolume2.Value

        Dim PositionMilli As Double = Math.Round(Player2.controls.currentPosition, 2)
        frmScenes.lblPresetsMP3PositionMilli2.Text = PositionMilli
        lblMusicMP3PositionMilli2.Text = PositionMilli
        frmQuickChanges.lblDramaViewMP3PositionMilli2.Text = PositionMilli
        ' lbleditPositionMilli.Text = PositionMilli

        'vSongEdit.Value = Val(lblPresetsMP3PositionMilli2.Text)

        'If Val(Player.currentMedia.durationString) <= 0 Then Exit Sub

        If SongChanges2.Count > 0 Then
            If SongChangeIndexUpTo2 > -2 Then
                If SongChanges2(SongChangeIndexUpTo2 + 1).TimeCode <= Player2.controls.currentPosition Then '    If NextMP3Change <= Player.controls.currentPosition And NextMP3Change > -1 Then 'MS
                    'do change
                    SongChangeIndexUpTo2 += 1
                    frmScenes.lstPresetsSongChanges2.SelectedIndex = SongChangeIndexUpTo2
                    lstMusicSongChanges2.SelectedIndex = SongChangeIndexUpTo2
                    frmQuickChanges.lstDramaViewSongChanges2.SelectedIndex = SongChangeIndexUpTo2

                    'Dim d() As String = Split(lstPresetsSongChanges.SelectedItem, "|")                          ' 0|Blue|0|0    TIMECONDE | SCENENAME | UP-TIME | DOWN-TIME

                    If SongChangeIndexUpTo2 = 0 Then ' FIRST CHANGE OF THE SONG
                        frmScenes.cmdPresetsBlackoutAllInstant_Click(Nothing, Nothing)

                        If SongChanges2(SongChangeIndexUpTo2).TimeToGoUp = 0 Then 'numPresetChangeMS.Value = 0 Then
                            SceneData(SongChanges2(SongChangeIndexUpTo2).SceneIndex).MasterValue = 100
                            frmScenes.UpdatePresetControls(100, SongChanges2(SongChangeIndexUpTo2).SceneIndex)
                        Else
                            SceneData(SongChanges2(SongChangeIndexUpTo2).SceneIndex).Automation.tmrDirection = "Up"
                            SceneData(SongChanges2(SongChangeIndexUpTo2).SceneIndex).Automation.IntervalSteps = SceneData(SongChanges2(SongChangeIndexUpTo2).SceneIndex).Automation.Max / (SongChanges2(SongChangeIndexUpTo2).TimeToGoUp / SceneData(SongChanges2(SongChangeIndexUpTo2).SceneIndex).Automation.tTimer.Interval)
                            SceneData(SongChanges2(SongChangeIndexUpTo2).SceneIndex).Automation.tTimer.Start()
                        End If
                    Else  ' IN THE MIDDLE OF A SONG
                        'Dim e1() As String = Split(lstPresetsSongChanges.Items.Item(lstPresetsSongChanges.SelectedIndex - 1), "|")
                        ' Dim PreviousSceneIndex As Integer = GetSceneIndex(e1(1))

                        If SongChanges2(SongChangeIndexUpTo2 - 1).TimeToGoDown = 0 Then 'numPresetChangeMS.Value = 0 Then
                            SceneData(SongChanges2(SongChangeIndexUpTo2 - 1).SceneIndex).MasterValue = 0
                            frmScenes.UpdatePresetControls(0, SongChanges2(SongChangeIndexUpTo2 - 1).SceneIndex)
                        Else
                            SceneData(SongChanges2(SongChangeIndexUpTo2 - 1).SceneIndex).Automation.tmrDirection = "Down"
                            SceneData(SongChanges2(SongChangeIndexUpTo2 - 1).SceneIndex).Automation.IntervalSteps = SceneData(SongChanges2(SongChangeIndexUpTo2).SceneIndex).Automation.Max / (SongChanges2(SongChangeIndexUpTo2).TimeToGoDown / SceneData(SongChanges2(SongChangeIndexUpTo2).SceneIndex).Automation.tTimer.Interval)
                            SceneData(SongChanges2(SongChangeIndexUpTo2 - 1).SceneIndex).Automation.tTimer.Start()
                        End If  'cmdPresetBlackout_Click(PresetControls(PreviousSceneIndex).cmdBlackout, Nothing)


                        If SongChanges2(SongChangeIndexUpTo2).TimeToGoUp = 0 Then 'numPresetChangeMS.Value = 0 Then
                            SceneData(SongChanges2(SongChangeIndexUpTo2).SceneIndex).MasterValue = 100
                            frmScenes.UpdatePresetControls(100, SongChanges2(SongChangeIndexUpTo2).SceneIndex)
                        Else
                            SceneData(SongChanges2(SongChangeIndexUpTo2).SceneIndex).Automation.tmrDirection = "Up"
                            SceneData(SongChanges2(SongChangeIndexUpTo2).SceneIndex).Automation.IntervalSteps = SceneData(SongChanges2(SongChangeIndexUpTo2).SceneIndex).Automation.Max / (SongChanges2(SongChangeIndexUpTo2).TimeToGoUp / SceneData(SongChanges2(SongChangeIndexUpTo2).SceneIndex).Automation.tTimer.Interval)
                            SceneData(SongChanges2(SongChangeIndexUpTo2).SceneIndex).Automation.tTimer.Start()
                        End If 'cmdPresetFull_Click(PresetControls(NextSceneIndex).cmdFull, Nothing)


                    End If


                    'prep next change
                    If SongChanges2.Count <= SongChangeIndexUpTo2 + 1 Then ' no more changes
                        SongChangeIndexUpTo2 = -2
                        'Else
                        'Dim c1() As String = Split(lstPresetsSongChanges.Items.Item(lstPresetsSongChanges.SelectedIndex + 1), "|")
                        'NextMP3Change = c1(0)
                    End If
                End If

            End If

        End If

        'tmrMP3.Interval = 10
        tmrchangedmp32 = False

    End Sub



    Public Sub cmdPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditPlay.Click, cmdMusicPlay.Click
        'Dim iSelectIndex As String = sender.name
        If frmScenes.lstPresetsSongs.SelectedIndex = -1 Then Exit Sub
        'lstPresetsSongs.SelectedIndex = iSelectIndex
        'lstMusicSongs.SelectedIndex = iSelectIndex
        'lstDramaViewSongs.SelectedIndex = iSelectIndex


        If frmScenes.cmdPresetsPlay.Text = "Play" Then
            Player.settings.volume = frmScenes.trkPresetsVolume.Value


            Player.controls.play()

            If frmScenes.lstPresetsSongChanges.Items.Count > 0 Then
                Dim a() As String = Split(frmScenes.lstPresetsSongChanges.Items.Item(0), "|")
                SongChangeIndexUpTo1 = -1
                frmScenes.lstPresetsSongChanges.SelectedIndex = -1
                lstMusicSongChanges.SelectedIndex = -1
                frmQuickChanges.lstDramaViewSongChanges.SelectedIndex = -1
            End If

            frmScenes.cmdPresetsPlay.Text = "Pause"
            cmdMusicPlay.Text = "Pause"
            cmdEditPlay.Text = "Pause"
            frmQuickChanges.cmdDramaViewPlay.Text = "Pause"
            tmrMP3.Interval = 50
            tmrMP3.Start()
            tmrMP3_Tick(sender, e)
            frmScenes.lstPresetsSongs.Enabled = False
            lstMusicSongs.Enabled = False
            frmQuickChanges.lstDramaViewSongs.Enabled = False
            Exit Sub
        ElseIf frmScenes.cmdPresetsPlay.Text = "Pause" Then
            'MP3.MP3Pause()
            Player.controls.pause()
            frmScenes.cmdPresetsPlay.Text = "Resume"
            cmdMusicPlay.Text = "Resume"
            cmdEditPlay.Text = "Resume"
            frmQuickChanges.cmdDramaViewPlay.Text = "Resume"
            tmrMP3.Enabled = False
            Exit Sub
        ElseIf frmScenes.cmdPresetsPlay.Text = "Resume" Then
            Player.controls.play()
            frmScenes.cmdPresetsPlay.Text = "Pause"
            cmdMusicPlay.Text = "Pause"
            cmdEditPlay.Text = "Pause"
            frmQuickChanges.cmdDramaViewPlay.Text = "Pause"
            'MP3.MP3Resume()
            tmrMP3.Start()
            Exit Sub
        End If
    End Sub

    Public Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditStop.Click, cmdMusicStop.Click
        Player.controls.stop()
        tmrMP3.Stop()
        frmScenes.cmdPresetsPlay.Text = "Play"
        cmdEditPlay.Text = "Play"
        frmQuickChanges.cmdDramaViewPlay.Text = "Play"
        cmdMusicPlay.Text = "Play"
        frmScenes.lstPresetsSongs.Enabled = True
        lstMusicSongs.Enabled = True
        frmQuickChanges.lstDramaViewSongs.Enabled = True
    End Sub

    Public Sub cmdSkip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMusicSkip.Click
        If frmScenes.lstPresetsSongs.Items.Count >= (frmScenes.lstPresetsSongs.SelectedIndex + 1) Then
            Player.controls.stop()
            tmrMP3.Stop()
            frmScenes.cmdPresetsPlay.Text = "Play"
            cmdEditPlay.Text = "Play"
            cmdMusicPlay.Text = "Play"
            frmQuickChanges.cmdDramaViewPlay.Text = "Play"
            frmScenes.lstPresetsSongs.Enabled = True

            If frmScenes.lstPresetsSongs.Items.Count > frmScenes.lstPresetsSongs.SelectedIndex + 1 Then
                frmScenes.lstPresetsSongs.SelectedIndex += 1
                cmdPlay_Click(sender, e)
            Else
                cmdStop_Click(sender, e)
            End If

        End If
    End Sub

    Public Sub trkVolume_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trkMusicVolume.Scroll
        Player.settings.volume = sender.Value
        frmScenes.trkPresetsVolume.Value = Player.settings.volume
        frmQuickChanges.trkDramaViewVolume.Value = Player.settings.volume
        trkMusicVolume.Value = Player.settings.volume
    End Sub
    Public Sub cmdPlay2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMusicPlay2.Click
        'Dim iSelectIndex As String = sender.name
        If frmScenes.lstPresetsSongs2.SelectedIndex = -1 Then Exit Sub
        'lstPresetsSongs.SelectedIndex = iSelectIndex
        'lstMusicSongs.SelectedIndex = iSelectIndex
        'lstDramaViewSongs.SelectedIndex = iSelectIndex


        If frmScenes.cmdPresetsPlay2.Text = "Play" Then
            Player2.settings.volume = frmScenes.trkPresetsVolume2.Value


            Player2.controls.play()

            If frmScenes.lstPresetsSongChanges2.Items.Count > 0 Then
                Dim a() As String = Split(frmScenes.lstPresetsSongChanges2.Items.Item(0), "|")
                SongChangeIndexUpTo2 = -1
                frmScenes.lstPresetsSongChanges2.SelectedIndex = -1
                lstMusicSongChanges2.SelectedIndex = -1
                frmQuickChanges.lstDramaViewSongChanges2.SelectedIndex = -1
            End If

            frmScenes.cmdPresetsPlay2.Text = "Pause"
            cmdMusicPlay2.Text = "Pause"
            frmQuickChanges.cmdDramaViewPlay2.Text = "Pause"
            tmrMP32.Interval = 50
            tmrMP32.Start()
            tmrMP32_Tick(sender, e)
            frmScenes.lstPresetsSongs2.Enabled = False
            lstMusicSongs2.Enabled = False
            frmQuickChanges.lstDramaViewSongs2.Enabled = False
            Exit Sub
        ElseIf frmScenes.cmdPresetsPlay2.Text = "Pause" Then
            'MP3.MP3Pause()
            Player2.controls.pause()
            frmScenes.cmdPresetsPlay2.Text = "Resume"
            cmdMusicPlay2.Text = "Resume"
            frmQuickChanges.cmdDramaViewPlay2.Text = "Resume"
            tmrMP32.Enabled = False
            Exit Sub
        ElseIf frmScenes.cmdPresetsPlay2.Text = "Resume" Then
            Player2.controls.play()
            frmScenes.cmdPresetsPlay2.Text = "Pause"
            cmdMusicPlay2.Text = "Pause"
            frmQuickChanges.cmdDramaViewPlay2.Text = "Pause"
            'MP3.MP3Resume()
            tmrMP32.Start()
            Exit Sub
        End If
    End Sub

    Public Sub cmdStop2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMusicStop2.Click
        Player2.controls.stop()
        tmrMP32.Stop()
        frmScenes.cmdPresetsPlay2.Text = "Play"
        frmQuickChanges.cmdDramaViewPlay2.Text = "Play"
        cmdMusicPlay2.Text = "Play"
        frmScenes.lstPresetsSongs2.Enabled = True
        lstMusicSongs2.Enabled = True
        frmQuickChanges.lstDramaViewSongs2.Enabled = True
    End Sub

    Public Sub cmdSkip2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMusicSkip2.Click
        If frmScenes.lstPresetsSongs2.Items.Count >= (frmScenes.lstPresetsSongs2.SelectedIndex + 1) Then
            Player2.controls.stop()
            tmrMP32.Stop()
            frmScenes.cmdPresetsPlay2.Text = "Play"
            cmdMusicPlay2.Text = "Play"
            frmQuickChanges.cmdDramaViewPlay2.Text = "Play"
            frmScenes.lstPresetsSongs2.Enabled = True

            If frmScenes.lstPresetsSongs2.Items.Count > frmScenes.lstPresetsSongs2.SelectedIndex + 1 Then
                frmScenes.lstPresetsSongs2.SelectedIndex += 1
                cmdPlay2_Click(sender, e)
            Else
                cmdStop2_Click(sender, e)
            End If

        End If
    End Sub

    Public Sub trkVolume2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trkMusicVolume2.Scroll
        Player2.settings.volume = sender.Value
        frmScenes.trkPresetsVolume2.Value = Player2.settings.volume
        frmQuickChanges.trkDramaViewVolume2.Value = Player2.settings.volume
        trkMusicVolume2.Value = Player2.settings.volume
    End Sub



    Public Sub LoadMusicTracks()

        frmScenes.lstPresetsSongs.Items.Clear()
        frmScenes.lstPresetsSongs2.Items.Clear()
        lstMusicSongs.Items.Clear()
        lstMusicSongs2.Items.Clear()
        frmQuickChanges.lstDramaViewSongs.Items.Clear()
        frmQuickChanges.lstDramaViewSongs2.Items.Clear()



        'lstPresetsSongChanges.Items.Clear()
        'lstPresetsSongChanges2.Items.Clear()
        'lstMusicSongChanges.Items.Clear()
        'lstMusicSongChanges2.Items.Clear()
        'lstDramaViewSongChanges.Items.Clear()
        'lstDramaViewSongChanges.Items.Clear()

        Dim I As Integer = 0
        Dim MusicMP3InBank() As String = Directory.GetFiles(Application.StartupPath & "\Save Files\" & frmBanks.lstBanks.SelectedItem & "\", "*.mp3")
        Do Until I >= MusicMP3InBank.Length
            Dim a() As String = Split(MusicMP3InBank(I), "\")
            Dim songname As String = Mid(a(a.Length - 1), 1, Len(a(a.Length - 1)) - 4)

            frmScenes.lstPresetsSongs.Items.Add(songname)
            frmScenes.lstPresetsSongs2.Items.Add(songname)
            lstMusicSongs.Items.Add(songname)
            lstMusicSongs2.Items.Add(songname)
            frmQuickChanges.lstDramaViewSongs.Items.Add(songname)
            frmQuickChanges.lstDramaViewSongs2.Items.Add(songname)

            MusicCues(I).SongFileName = songname
            ReDim MusicCues(I).SongChanges(200)
            I += 1
        Loop


    End Sub
    Public Sub lstSongs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMusicSongs.SelectedIndexChanged
        If sender.SelectedIndex = -1 Then Exit Sub
        Dim iSelectIndex = sender.selectedindex
        frmScenes.lstPresetsSongs.SelectedIndex = iSelectIndex
        lstMusicSongs.SelectedIndex = iSelectIndex
        frmQuickChanges.lstDramaViewSongs.SelectedIndex = iSelectIndex

        Dim I As Integer = 0
        frmScenes.lstPresetsSongChanges.Items.Clear()
        lstMusicSongChanges.Items.Clear()
        frmQuickChanges.lstDramaViewSongChanges.Items.Clear()
        SongChanges1.Clear()

        If File.Exists(Application.StartupPath & "\Save Files\" & frmBanks.lstBanks.SelectedItem & "\" & frmScenes.lstPresetsSongs.SelectedItem & ".chg") = False Then GoTo AfterChgFile

        FileOpen(1, Application.StartupPath & "\Save Files\" & frmBanks.lstBanks.SelectedItem & "\" & frmScenes.lstPresetsSongs.SelectedItem & ".chg", OpenMode.Input)

        Do Until EOF(1)
            Dim newline As String = LineInput(1)
            frmScenes.lstPresetsSongChanges.Items.Add(newline)
            lstMusicSongChanges.Items.Add(newline)
            frmQuickChanges.lstDramaViewSongChanges.Items.Add(newline)

            Dim NewSongChange As New SongChangesStr
            Dim a() As String = Split(newline, "|")
            NewSongChange.TimeCode = a(0)
            NewSongChange.SceneName = a(1)
            NewSongChange.SceneIndex = frmScenes.GetSceneIndex(a(1))
            NewSongChange.TimeToGoUp = a(2)
            NewSongChange.TimeToGoDown = a(3)
            SongChanges1.Add(NewSongChange)

        Loop

        'Do Until EOF(1)
        '    Dim a() As String = Split(LineInput(1), "|") 'time|Preset
        '    Mp3Changes(I).Time = a(0)
        '    Mp3Changes(I).PresetName = a(1)
        '    I += 1
        'Loop
        FileClose(1)


AfterChgFile:

        'Make sure no mp3 is playing
        'MP3.MP3Stop()
        'Player.controls.stop()
        'load mp3 and play


        Player.URL = Application.StartupPath & "\Save Files\" & frmBanks.lstBanks.SelectedItem & "\" & frmScenes.lstPresetsSongs.SelectedItem & ".mp3"

        frmScenes.lblPresetsMP3Duration.Text = Player.currentMedia.durationString
        lblMusicMP3Duration.Text = Player.currentMedia.durationString
        frmQuickChanges.lblDramaViewMP3Duration.Text = Player.currentMedia.durationString

    End Sub

    Public Sub lstSongs2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMusicSongs2.SelectedIndexChanged
        If sender.SelectedIndex = -1 Then Exit Sub
        Dim iSelectIndex = sender.selectedindex
        frmScenes.lstPresetsSongs2.SelectedIndex = iSelectIndex
        lstMusicSongs2.SelectedIndex = iSelectIndex
        frmQuickChanges.lstDramaViewSongs2.SelectedIndex = iSelectIndex
        SongChanges2.Clear()

        Dim I As Integer = 0
        frmScenes.lstPresetsSongChanges2.Items.Clear()
        lstMusicSongChanges2.Items.Clear()
        frmQuickChanges.lstDramaViewSongChanges2.Items.Clear()
        SongChanges2.Clear()

        If File.Exists(Application.StartupPath & "\Save Files\" & frmBanks.lstBanks.SelectedItem & "\" & frmScenes.lstPresetsSongs2.SelectedItem & ".chg") = False Then GoTo AfterChgFile

        FileOpen(1, Application.StartupPath & "\Save Files\" & frmBanks.lstBanks.SelectedItem & "\" & frmScenes.lstPresetsSongs2.SelectedItem & ".chg", OpenMode.Input)
        Do Until EOF(1)
            Dim newline As String = LineInput(1)
            frmScenes.lstPresetsSongChanges2.Items.Add(newline)
            lstMusicSongChanges2.Items.Add(newline)
            frmQuickChanges.lstDramaViewSongChanges2.Items.Add(newline)

            Dim NewSongChange As New SongChangesStr
            Dim a() As String = Split(newline, "|")
            NewSongChange.TimeCode = a(0)
            NewSongChange.SceneName = a(1)
            NewSongChange.SceneIndex = frmScenes.GetSceneIndex(a(1))
            NewSongChange.TimeToGoUp = a(2)
            NewSongChange.TimeToGoDown = a(3)
            SongChanges2.Add(NewSongChange)

        Loop

        'Do Until EOF(1)
        '    Dim a() As String = Split(LineInput(1), "|") 'time|Preset
        '    Mp3Changes(I).Time = a(0)
        '    Mp3Changes(I).PresetName = a(1)
        '    I += 1
        'Loop
        FileClose(1)


AfterChgFile:

        'Make sure no mp3 is playing
        'MP3.MP3Stop()
        'Player.controls.stop()
        'load mp3 and play


        Player2.URL = Application.StartupPath & "\Save Files\" & frmBanks.lstBanks.SelectedItem & "\" & frmScenes.lstPresetsSongs2.SelectedItem & ".mp3"

        frmScenes.lblPresetsMP3Duration2.Text = Player2.currentMedia.durationString
        lblMusicMP3Duration2.Text = Player2.currentMedia.durationString
        frmQuickChanges.lblDramaViewMP3Duration2.Text = Player2.currentMedia.durationString
    End Sub
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
        'Return CInt(Math.Ceiling(Rnd() * Max))
    End Function


#End Region

End Class
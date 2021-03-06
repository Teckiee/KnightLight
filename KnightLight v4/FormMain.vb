Option Strict Off
Option Explicit On
Imports System.IO
Imports EnttecOpenDMX.OpenDMX
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Management
'Imports Arduino_DMX_USB.Main

Public Class FormMain
    Dim nat As New AudioThread()


    'Dim LastSelectedChannel As Integer = 1
    Dim shiftdown As Boolean
    Dim ctrldown As Boolean
    Dim PresetFaderControlModifier As Integer = 0
    Dim ClosingNow As Boolean

    'Dim NextMP3Change As Double
    Dim tmrchangedmp3 As Boolean = False
    'Dim NextMP3Change2 As Double
    Dim tmrchangedmp32 As Boolean = False
    'Dim SongChangeIndexUpTo1 As Integer = -1
    Dim CurrentSongChangeIndex As Integer = -1
    Dim SongChangeIndexUpTo2 As Integer = -1
    Dim Song1EditingOrig As SongChangesStr

    'Dim ChannelFaderPageCurrentSceneDataIndex As Integer = 0

    Dim tmrMasterUpto As Integer
    Dim tmrMasterWay As String
    Dim tmrMasterInterval As Integer

    ' Preset Controls values
    Dim StartX As Integer = 8
    Dim StartY As Integer = 8
    Dim tSC As New SceneControl1
    Dim IntervalX As Integer = tSC.Size.Width + 6
    Dim IntervalY As Integer = tSC.Size.Height + 4


    'Dim vscrDiffX As Integer = 119
    'Dim vscrDiffY As Integer = 0
    'Dim txtDiffX As Integer = 119 '364
    'Dim txtDiffY As Integer = 0
    'Dim numChangeMSDiffX As Integer = 119
    'Dim numChangeMSDiffY As Integer = 21
    'Dim cmdBlackoutDiffX As Integer = 231
    'Dim cmdBlackoutDiffY As Integer = 0
    'Dim cmdFullDiffX As Integer = 170
    'Dim cmdFullDiffY As Integer = 0

    Dim PresetsPerColumn As Integer = 0
    Dim PresetsPerRow As Integer = 0

    Dim PresetVisualUpdate As Boolean = False
    Dim RenamePresetFaderOk As Boolean = False

    'Dim txtDiffX As Integer = 119
    'Dim txtDiffY As Integer = 0
    'Dim numChangeMSDiffX As Integer = 119
    'Dim numChangeMSDiffY As Integer = 21
    'Dim cmdBlackoutDiffX As Integer = 231
    'Dim cmdBlackoutDiffY As Integer = 0
    'Dim cmdFullDiffX As Integer = 170
    'Dim cmdFullDiffY As Integer = 0

    Dim HoldLeft, HoldTop As Integer
    Dim TopSet, LeftSet As Boolean
    Dim OffTop, OffLeft As Integer
    'Dim OrigTop, OrigLeft As Integer


#Region "Arduino Connections"
    Sub SetupSerialConnections()
        ' Show all available COM ports.
        'For Each sp As String In My.Computer.Ports.SerialPortNames
        'ListBox1.Items.Add(sp)
        'Next
        lstCOMdevices.Items.Clear()
        'When the form loads
        'Enumerate available Com ports and add to ComboBox1
        Dim comPorts = Ports.SerialPort.GetPortNames

        Dim SerialCount As Integer = 0
        For i = 0 To UBound(comPorts)
            Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE Caption like '%(" & comPorts(i) & "%'")
            For Each queryObj As ManagementObject In searcher.Get()
                'If InStr((CStr(queryObj("Caption"))), "Arduino") > 0 Then 'is an arduino. Later proved inconsistent

                Arduinos(SerialCount).DeviceName = (CStr(queryObj("Caption")))
                Arduinos(SerialCount).PortNo = comPorts(i)
                Arduinos(SerialCount).HasDevice = True

                'Dim newrow As New ListViewItem
                'newrow.Text = Arduinos(SerialCount).PortNo
                'newrow.SubItems.Add(Arduinos(SerialCount).DeviceName)

                Try
                    Arduinos(SerialCount).Serial = New Ports.SerialPort
                    Arduinos(SerialCount).Serial.BaudRate = 115200
                    Arduinos(SerialCount).Serial.PortName = Arduinos(SerialCount).PortNo
                    Arduinos(SerialCount).Serial.DataBits = 8
                    Arduinos(SerialCount).Serial.StopBits = IO.Ports.StopBits.One
                    Arduinos(SerialCount).Serial.Handshake = IO.Ports.Handshake.None
                    Arduinos(SerialCount).Serial.Parity = IO.Ports.Parity.None
                    Arduinos(SerialCount).Serial.Open()
                    AddHandler Arduinos(SerialCount).Serial.DataReceived, AddressOf SerialPort_DataReceived
                    Arduinos(SerialCount).Serial.Write("UID," & Arduinos(SerialCount).PortNo & vbCrLf)
                    Arduinos(SerialCount).InUse = True
                    'newrow.SubItems.Add("True")
                Catch
                    'Dim thread1 As New Thread(Sub()
                    '                              Arduinos(SerialCount).Serial.Close()
                    '                          End Sub)
                    'thread1.Start()
                    'Arduinos(SerialCount).Serial.Close()

                    'newrow.SubItems.Add("False")
                End Try
                'newrow.SubItems.Add(" ")
                'newrow.SubItems.Add(" ")

                'lstCOMdevices.Items.Add(newrow)
                'End If
                SerialCount += 1
            Next

            'Arduinos(i).Serial = My.Computer.Ports.OpenSerialPort(comPorts(i))
            'Arduinos(i).Serial.BaudRate = 115200
            'SerialPort1.BaudRate = 115200
            'SerialPort1.Parity = Ports.Parity.None
            'SerialPort1.StopBits = IO.Ports.StopBits.One
            'SerialPort1.DataBits = 8
        Next

        LoadArduinoAssignments()


    End Sub


    Private Sub LoadArduinoAssignments()

        FileOpen(9, Application.StartupPath & "\ArduinoAssignments.ini", OpenMode.Input)
        Dim I As Integer = 0
        Do Until EOF(9)
            Dim a() As String = Split(LineInput(9), "=")
            I = 0
            Do Until I >= Arduinos.Length
                If Arduinos(I).UID = a(1) Then
                    GoTo found
                ElseIf Arduinos(I).HasDevice = False Then
                    GoTo found
                End If
                I += 1
            Loop
found:
            If Not I >= Arduinos.Length Then
                'found a match
                Arduinos(I).UID = a(1)
                Select Case a(0)
                    Case ArduinoModes.ctlMusic1
                        Arduinos(I).Job = ArduinoModes.ctlMusic1
                        Arduinos(I).HasDevice = True
                    Case ArduinoModes.ctlMusic2
                        Arduinos(I).Job = ArduinoModes.ctlMusic2
                        Arduinos(I).HasDevice = True
                    Case ArduinoModes.ctlDMX3Universe
                        Arduinos(I).Job = ArduinoModes.ctlDMX3Universe
                        ArdDMX.SetComPort = I
                        Arduinos(I).HasDevice = True
                    Case ArduinoModes.ctlSoundActivation1
                        Arduinos(I).Job = ArduinoModes.ctlSoundActivation1
                        Arduinos(I).HasDevice = True
                End Select
            End If

        Loop
        FileClose(9)


        lstCOMdevices.Items.Clear()
        I = 0
        Do Until I >= Arduinos.Length
            If Arduinos(I).HasDevice = True Then
                Dim newrow As New ListViewItem
                newrow.Text = Arduinos(I).PortNo
                newrow.SubItems.Add(Arduinos(I).DeviceName)
                newrow.SubItems.Add(Arduinos(I).InUse)
                newrow.SubItems.Add(Arduinos(I).Job)
                newrow.SubItems.Add(Arduinos(I).UID)
                lstCOMdevices.Items.Add(newrow)
            End If

            I += 1
        Loop
    End Sub
    Private Sub SaveArduinoAssignments()
        'tmrserial.Stop()
        File.Copy(Application.StartupPath & "\ArduinoAssignments.ini", Application.StartupPath & "\ArduinoAssignments.Backup.ini", True)
        FileOpen(8, Application.StartupPath & "\ArduinoAssignments.ini", OpenMode.Output)
        Dim I As Integer = 0
        Do Until I >= Arduinos.Length
            If Arduinos(I).HasDevice = True Then
                PrintLine(8, Arduinos(I).Job & "=" & Arduinos(I).UID)
            End If
            I += 1
        Loop


        FileClose(8)
        'tmrserial.Start()
    End Sub
    Function ArduinoFindPort(ByVal sPort As String) As Integer
        Dim I As Integer = 0
        Do Until I >= Arduinos.Length
            If Arduinos(I).PortNo = sPort Then
                Return I
            End If
            I += 1
        Loop
    End Function

    Structure msg1
        Dim msg As String
        Dim portname As String
        Dim arduinoindex As Integer
    End Structure

    Delegate Sub myMethodDelegate(ByVal [text] As msg1)
    Dim myD1 As New myMethodDelegate(AddressOf myShowStringMethod)

    Private Sub SerialPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) ' Handles SerialPort.DataReceived
        If ClosingNow = True Then Exit Sub

        Dim incmsg As msg1
        incmsg.msg = sender.ReadExisting
        incmsg.portname = sender.portname
        If Mid(incmsg.msg, 1, 3) = "UID" Then
            Dim a() As String = Split(incmsg.msg, ",")

            Dim I As Integer = 0
            If a.Length >= 2 Then
                Do Until I >= Arduinos.Length
                    If Arduinos(I).PortNo = incmsg.portname Then
                        Arduinos(I).UID = a(1)
                        Exit Do
                    End If
                    I += 1
                Loop
            End If

        End If

        If ClosingNow = True Then Exit Sub
        Invoke(myD1, incmsg)

    End Sub
    Sub myShowStringMethod(ByVal mymsg As msg1)


        If Mid(mymsg.msg, 1, 3) = "UID" Then
            Dim a() As String = Split(mymsg.msg, ",")

            If a.Length >= 2 Then ' not 3 = data garbled
                Dim I As Integer = 0
                Do Until I >= Arduinos.Length
                    If Arduinos(I).PortNo = mymsg.portname Then Exit Do
                    I += 1
                Loop
                'Arduinos(I).UID = a(1)
                'lblArduino1.Text = "Arduino1: " & Arduinos(I).UID
            End If

        ElseIf Mid(mymsg.msg, 1, 3) = "AVU" Then
            'Serial.println("AVU," + incomingAudio);
            Dim a() As String = Split(mymsg.msg, ",")
            If a.Length = 2 Then ' not 2 = data garbled
                lblAudioActive.Text = Val(a(1))
                tmrAVUCheck.Stop()
                SoundActivationCurrentLevel = Val(a(1))
                tmrAVUCheck.Start()
            End If
        ElseIf Mid(mymsg.msg, 1, 3) = "MUS" Then
            mymsg.arduinoindex = ArduinoFindPort(mymsg.portname)

            Dim a() As String = Split(mymsg.msg, ",")
            Dim songtitle As String = ""
            If Arduinos(mymsg.arduinoindex).Job = ArduinoModes.ctlMusic1 Then
                If lstPresetsSongs.SelectedIndex = -1 Then
                    lstPresetsSongs.SelectedIndex = 0
                End If
                songtitle = lstPresetsSongs.SelectedItem
            ElseIf Arduinos(mymsg.arduinoindex).Job = ArduinoModes.ctlMusic2 Then
                If lstPresetsSongs2.SelectedIndex = -1 Then
                    lstPresetsSongs2.SelectedIndex = 0
                End If
                songtitle = lstPresetsSongs2.SelectedItem
            End If
            Dim b As String = Split(a(1), vbCrLf)(0)
            Select Case b
                Case "Play"
                    'AudioRun.mPlay(songtitle)
                    If Arduinos(mymsg.arduinoindex).Job = ArduinoModes.ctlMusic1 Then
                        If lstPresetsSongs.SelectedIndex = -1 Then
                            lstPresetsSongs.SelectedIndex = 0
                        End If
                        cmdPlay_Click(Nothing, Nothing)
                    ElseIf Arduinos(mymsg.arduinoindex).Job = ArduinoModes.ctlMusic2 Then
                        If lstPresetsSongs2.SelectedIndex = -1 Then
                            lstPresetsSongs2.SelectedIndex = 0
                        End If
                        cmdPlay2_Click(Nothing, Nothing)
                    End If
                Case "Pause"
                    If Arduinos(mymsg.arduinoindex).Job = ArduinoModes.ctlMusic1 Then
                        cmdPlay_Click(Nothing, Nothing)
                    ElseIf Arduinos(mymsg.arduinoindex).Job = ArduinoModes.ctlMusic2 Then
                        cmdPlay2_Click(Nothing, Nothing)
                    End If
                    'AudioRun.mPause(songtitle)
                Case "Stop"
                    'AudioRun.mStop(songtitle)
                    cmdStop_Click(Nothing, Nothing)
                Case "Back"
                    If Arduinos(mymsg.arduinoindex).Job = ArduinoModes.ctlMusic1 Then
                        If lstPresetsSongs.SelectedIndex = 0 Then
                            'cmdPlay_Click(Nothing, Nothing)
                        Else
                            lstPresetsSongs.SelectedIndex -= 1
                            'cmdPlay_Click(Nothing, Nothing)
                        End If
                    ElseIf Arduinos(mymsg.arduinoindex).Job = ArduinoModes.ctlMusic2 Then
                        If lstPresetsSongs2.SelectedIndex = 0 Then
                            'cmdPlay2_Click(Nothing, Nothing)
                        Else
                            lstPresetsSongs2.SelectedIndex -= 1
                            'cmdPlay2_Click(Nothing, Nothing)
                        End If
                    End If
                Case "Next"
                    If Arduinos(mymsg.arduinoindex).Job = ArduinoModes.ctlMusic1 Then
                        'lstPresetsSongs.SelectedIndex += 1
                        If lstPresetsSongs.SelectedIndex = lstPresetsSongs.Items.Count Then
                            'cmdSkip_Click(Nothing, Nothing)
                        Else
                            lstPresetsSongs.SelectedIndex += 1
                            'cmdSkip_Click(Nothing, Nothing)
                        End If
                        'cmdSkip_Click(Nothing, Nothing)
                    ElseIf Arduinos(mymsg.arduinoindex).Job = ArduinoModes.ctlMusic2 Then
                        'lstPresetsSongs2.SelectedIndex += 1
                        If lstPresetsSongs2.SelectedIndex = lstPresetsSongs2.Items.Count Then
                            'cmdSkip2_Click(Nothing, Nothing)
                        Else
                            lstPresetsSongs2.SelectedIndex += 1
                            'cmdSkip2_Click(Nothing, Nothing)
                        End If
                        'cmdSkip2_Click(Nothing, Nothing)
                    End If
            End Select
            'txtSerialIn.AppendText(myString)
        End If
        If lstCOMdevices.SelectedItems.Count = 0 Then
            txtSerialIn.AppendText(mymsg.msg)
        Else
            If lstCOMdevices.SelectedItems(0).Text = mymsg.portname Then
                txtSerialIn.AppendText(mymsg.msg)
            End If
        End If

    End Sub

#End Region

#Region "Startup application"

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Environment.GetCommandLineArgs.Length > 1 Then
            If Environment.GetCommandLineArgs(1) = "-Testmode" Then Testmode = True
        End If
        If File.Exists(Application.StartupPath & "\Testmode.txt") = True Then Testmode = True


        AudioRun = New AudioThread
        'AudioRun.join()
        ArdDMX = New ArduinoDMX

        frmMain = Me
        frmTouchPad = New FormTouchPad
        Dim iDim As Integer = 0
        Do Until iDim >= frmDimmerAutomation.Length
            frmDimmerAutomation(iDim) = New FormDimmerAutomation
            frmDimmerAutomation(iDim).Icon = frmMain.Icon
            frmDimmerAutomation(iDim).BackColor = Color.Black
            iDim += 1
        Loop
        frmGradientColour = New FormColourGradient
        frmCustomColourPicker1 = New FormColourPicker
        frmChannels = New FormChannels
        frmChannels.Show()
        frmChannels.SendToBack()
        frmTouchPad.Icon = frmMain.Icon


        'Player.settings.autoStart = False
        'Player2.settings.autoStart = False
        With Me.tmrMP3
            .Interval = 50
            .Start()
            .Enabled = False
        End With
        'Player.controls.stop()
        'Player.settings.volume = 50

        'With Me.tmrMP32
        '    .Interval = 50
        '    .Start()
        '    .Enabled = False
        'End With
        'Player2.controls.stop()
        'Player2.settings.volume = 50


        controlcolour = Me.BackColor

        For Each c As Windows.Forms.Control In tbpPresets.Controls
            tbpPresetsControls.Add(c)
        Next
        For Each c As Windows.Forms.Control In frmChannels.Controls
            frmChannelsControls.Add(c)
        Next

        If Testmode = False Then
            Try
                EnttecOpenDMX.OpenDMX.start()
            Catch ex As Exception
                If Not InStr(ex.Message, "The specified module could not be found.") > 0 Then
                    MsgBox(ex.Message)
                Else
                    Testmode = True
                End If
                'Unable to load DLL 'FTD2XX.dll': The specified module could not be found. (Exception from HRESULT: 0x8007007E)
            End Try


        End If
        'tbpPresetsControls = tbpPresets.Controls
        ' frmChannelsControls = frmChannels.Controls

        LoadBanksFromFile()
        LoadSettingsFromFile()
        SetupSerialConnections() 'Arduino setup
        LoadAsioDriverList()

        LoadFixtureInformation()

        LoadScenesFromFile()
        RenamePresetFaderOk = True
        GeneratePresetFormControls()


        frmChannels.GenerateChannelFormControls()
        LoadMusicTracks()

        'If ASIOMode = True Then
        '    SetupAsioOutputs()
        'End If

        Application.DoEvents()
        SetupThreads()

        'For Each c As Windows.Forms.Control In tbpPresetsControls
        '    tbpPresets.Controls.Add(c)
        'Next



        For Each c As System.Windows.Forms.Control In Me.Controls
            AddHandler c.KeyDown, AddressOf Form1_KeyDown
            AddHandler c.KeyUp, AddressOf Form1_KeyUp
        Next c

        chkAsioMode.BackColor = Color.Black
        chkAsioMode.ForeColor = lblChannelNumberColour.BackColor
        lblAudioActive.BackColor = Color.Black
        lblAudioActive.ForeColor = lblChannelNumberColour.BackColor
        lblAudio2.BackColor = Color.Black
        lblAudio2.ForeColor = lblChannelNumberColour.BackColor
        cmdEditPlay.ForeColor = lblChannelNumberColour.BackColor
        Me.BackColor = Color.Black
        tbpBanks.BackColor = Color.Black
        tbpPresets.BackColor = Color.Black
        frmChannels.BackColor = Color.Black
        tbpMusic.BackColor = Color.Black
        tbpScriptChanges.BackColor = Color.Black
        tbpSettings.BackColor = Color.Black
        tbcControls1.SelectedIndex = 1

        lblMaster.ForeColor = lblChannelNumberColour.BackColor

        For Each c As Control In tbpMusic.Controls
            If c.GetType Is GetType(Label) Then
                c.ForeColor = lblChannelNumberColour.BackColor
            End If
        Next
        For Each c As Control In tbpScriptChanges.Controls
            If c.GetType Is GetType(Label) Then
                c.ForeColor = lblChannelNumberColour.BackColor
            End If
        Next
        For Each c As Control In tbpSettings.Controls
            If c.GetType Is GetType(Label) Or c.GetType Is GetType(CheckBox) Then
                If Not c.Text = "..." Then
                    c.BackColor = Color.Black
                    c.ForeColor = lblChannelNumberColour.BackColor
                End If

            End If
        Next

        'frmChannels.BackColor = Color.Black
        'tbpPresets.BackColor = Color.Black
        'tbpSettings.BackColor = Color.Black
        'tbpMusic.BackColor = Color.Black
        'tbpDramaChanges.BackColor = Color.Black
        ChannelFaderPageCurrentSceneDataIndex = 1
        formopened = True
    End Sub
    Private Sub LoadFixtureInformation()
        FileOpen(1, Application.StartupPath & "\Fixtures.ini", OpenMode.Input)

        Do Until EOF(1)
            Dim sline() As String = Split(LineInput(1), "|")
            Dim ParentChannelNo As Integer = Val(sline(0))
            FixtureControls(ParentChannelNo).BackColour = Color.FromName(sline(2))
            FixtureControls(ParentChannelNo).ForeColour = Color.FromName(sline(3))
            FixtureControls(ParentChannelNo).FixtureName = sline(1)
            FixtureControls(ParentChannelNo).IsFirst = True
            FixtureControls(ParentChannelNo).fColPicker = New FormColourPicker
            FixtureControls(ParentChannelNo).fColPicker.Visible = False
            FixtureControls(ParentChannelNo).ParentChannelNo = ParentChannelNo


            FileOpen(2, Application.StartupPath & "\Fixtures\" & FixtureControls(ParentChannelNo).FixtureName & ".fix", OpenMode.Input)
            Dim channelcount As Integer = 0
            Dim channelupto As Integer = 0
            Do Until EOF(2)
                Dim s As String = LineInput(2)
                Dim a() As String = Split(s, "=")
                If a(0) = "Channels" Then ' is channel count modifier
                    channelcount = Val(a(1))
                    s = LineInput(2)
                End If
                FixtureControls(ParentChannelNo + channelupto).BackColour = Color.FromName(sline(2))
                FixtureControls(ParentChannelNo + channelupto).ForeColour = Color.FromName(sline(3))
                FixtureControls(ParentChannelNo + channelupto).FixtureName = sline(1)

                Dim AnV() As String = Split(s, "|")
                If AnV.Length = 3 Then 'has a long description
                    FixtureControls(ParentChannelNo + channelupto).LongDescr = AnV(2).Replace("`e", vbCrLf)
                End If
                FixtureControls(ParentChannelNo + channelupto).ActionAndValues = AnV(1)
                If InStr(AnV(1), "Red") > 0 Then
                    FixtureControls(ParentChannelNo).fColPicker.iRChan = ParentChannelNo + channelupto
                End If
                If InStr(AnV(1), "Grn") > 0 Or InStr(AnV(1), "Green") > 0 Then
                    FixtureControls(ParentChannelNo).fColPicker.iGChan = ParentChannelNo + channelupto
                End If
                If InStr(AnV(1), "Blue") > 0 Or InStr(AnV(1), "Blu") > 0 Then
                    FixtureControls(ParentChannelNo).fColPicker.iBChan = ParentChannelNo + channelupto
                End If

                FixtureControls(ParentChannelNo + channelupto).ParentChannelNo = ParentChannelNo
                FixtureControls(ParentChannelNo + channelupto).ChannelOfFixture = channelupto + 1
                If Mid(s, 1, 2) = "D|" Then FixtureControls(ParentChannelNo + channelupto).IsDimmable = True
                channelupto += 1
            Loop
            FileClose(2)
            ReDim FixtureControls(ParentChannelNo).Favourites(100)
            If Directory.Exists(Application.StartupPath & "\Fixtures\" & FixtureControls(ParentChannelNo).FixtureName & "\") Then
                Dim FixFavs() As String = Directory.GetFiles(Application.StartupPath & "\Fixtures\" & FixtureControls(ParentChannelNo).FixtureName & "\")
                For FavsI = 0 To FixFavs.Length - 1
                    FixtureControls(ParentChannelNo).Favourites(FavsI) = System.IO.Path.GetFileNameWithoutExtension(FixFavs(FavsI))
                Next

            End If


        Loop
        FileClose(1)
    End Sub
    Private Sub LoadSettingsFromFile()
        If Directory.Exists(Application.StartupPath & "\Save Files") = False Then
            Directory.CreateDirectory(Application.StartupPath & "\Save Files")
            Directory.CreateDirectory(Application.StartupPath & "\Save Files\Bank1")
            File.Create(Application.StartupPath & "\Save Files\Bank1\All Off.dmr")

        End If

        FileOpen(1, Application.StartupPath & "\Settings.ini", OpenMode.Input)
        Do Until EOF(1)
            Dim a() As String = Split(LineInput(1), "=")
            Select Case a(0)
                Case "ChannelCount"
                    'SetChannelCount(a(1)) - Jaycar usb module
                    numEndChannel.Value = a(1)
                Case "DimmerChannelRows"
                    ChannelControlSetsPerPage = a(1)
                Case "LoadonChange"
                    'chkLoadonChange.Checked = a(1)
                    chkLoadonChange.Checked = Convert.ToBoolean(a(1))
                Case "LastBank"
                    lstBanks.SetSelected(lstBanks.FindString(a(1)), True)
                Case "ChannelBulletColour"
                    lblChannelBulletColour.BackColor = Color.FromArgb(a(1))
                Case "ChannelBackColour"
                    lblChannelBackColour.BackColor = Color.FromArgb(a(1))
                Case "ChannelFillColour"
                    lblChannelFillColour.BackColor = Color.FromArgb(a(1))
                Case "ChannelNumberColour"
                    lblChannelNumberColour.BackColor = Color.FromArgb(a(1))
                Case "SceneBulletColour"
                    'lblSceneBulletColour.BackColor = Color.FromName(a(1))
                    lblSceneBlackoutColour.BackColor = Color.FromArgb(a(1))
                Case "SceneBackColour"
                    lblSceneUpColour.BackColor = Color.FromArgb(a(1))
                Case "SceneFillColour"
                    lblSceneFillColour.BackColor = Color.FromArgb(a(1))
                Case "SceneLabelColour"
                    lblSceneLabelColour.BackColor = Color.FromArgb(a(1))
                Case "SceneBorderColour"
                    lblSceneBorderColour.BackColor = Color.FromArgb(a(1))
                    borderColor = lblSceneBorderColour.BackColor
                Case "SongChangeColour"
                    lblSongChangeColour.BackColor = Color.FromArgb(a(1))
                Case "MultipleThreadCount"
                    tChannelsMultipleThreads = Convert.ToBoolean(a(1))
                Case "ResaveOnSceneLoad"
                    ResaveOnSceneLoad = Convert.ToBoolean(a(1))
                Case "AudioLatency"
                    AudioLatency = Val(a(1))
                Case "SCSIPaddress"
                    SCSIPaddress = a(1)
                    txtSCSIPaddress.Text = SCSIPaddress
                Case "SCSPort"
                    SCSPort = Val(a(1))
                    txtSCSPort.Text = SCSPort
                Case "ScenesWithFader"
                    bWithFader = Convert.ToBoolean(a(1))
                    If bWithFader = True Then
                        SceneControlHeight = SceneControlHeightWithFader1
                        IntervalY = SceneControlHeight + 4
                    Else bWithFader = False
                        SceneControlHeight = SceneControlHeightWithoutFader1
                        IntervalY = SceneControlHeight + 4
                    End If
                Case "ASIOMode"
                    ASIOMode = Convert.ToBoolean(a(1))
                    chkAsioMode.Checked = ASIOMode
                    chkAsioMode.Enabled = True


            End Select
        Loop
        FileClose(1)

    End Sub
    Private Sub SaveSettingsToFile()

        File.Copy(Application.StartupPath & "\Settings.ini", Application.StartupPath & "\Settings.Backup.ini", True)
        FileOpen(1, Application.StartupPath & "\Settings.ini", OpenMode.Output)
        PrintLine(1, "ChannelCount=" & numEndChannel.Value)
        PrintLine(1, "DimmerChannelRows=" & ChannelControlSetsPerPage)
        PrintLine(1, "LoadonChange=" & chkLoadonChange.Checked)
        PrintLine(1, "LastBank=" & lstBanks.SelectedItem)
        PrintLine(1, "ChannelBulletColour=" & lblChannelBulletColour.BackColor.ToArgb)
        PrintLine(1, "ChannelBackColour=" & lblChannelBackColour.BackColor.ToArgb)
        PrintLine(1, "ChannelFillColour=" & lblChannelFillColour.BackColor.ToArgb)
        PrintLine(1, "ChannelNumberColour=" & lblChannelNumberColour.BackColor.ToArgb)
        PrintLine(1, "SceneBulletColour=" & lblSceneBlackoutColour.BackColor.ToArgb)
        PrintLine(1, "SceneBackColour=" & lblSceneUpColour.BackColor.ToArgb)
        PrintLine(1, "SceneFillColour=" & lblSceneFillColour.BackColor.ToArgb)
        PrintLine(1, "SceneLabelColour=" & lblSceneLabelColour.BackColor.ToArgb)
        PrintLine(1, "SceneBorderColour=" & borderColor.ToArgb)
        PrintLine(1, "SongChangeColour=" & lblSongChangeColour.BackColor.ToArgb)
        PrintLine(1, "MultipleThreadCount=" & tChannelsMultipleThreads)
        PrintLine(1, "ResaveOnSceneLoad=" & ResaveOnSceneLoad)
        PrintLine(1, "AudioLatency=" & AudioLatency)
        PrintLine(1, "SCSIPaddress=" & SCSIPaddress)
        PrintLine(1, "SCSPort=" & SCSPort)
        PrintLine(1, "ScenesWithFader=" & bWithFader)
        PrintLine(1, "ASIOMode=" & ASIOMode)

        FileClose(1)

    End Sub
    Private Sub Form1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles tbpPresets.Paint

        'Draws the border.
        Dim I As Integer = 0
        Do Until I >= PresetFaders.Count
            If Not PresetFaders(I).cSceneControl Is Nothing Then
                ControlPaint.DrawBorder(e.Graphics, PresetFaders(I).border, borderColor,
                borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth,
                ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid)
            End If

            I += 1
        Loop


    End Sub
    Private Sub LoadBanksFromFile()
        lstBanks.Items.Clear()

        For Each S As String In Directory.GetDirectories(Application.StartupPath & "\Save Files\")
            Dim a() As String = Split(S, "\")
            lstBanks.Items.Add(a(a.Length - 1))
        Next S
        Application.DoEvents()
    End Sub
    Private Sub LoadScenesFromFile()

        lstDramaPresets.Items.Clear()
        lstSongEditPresets.Items.Clear()
        frmChannels.cmbChannelPresetSelection.Items.Clear()
        SceneDataLocations.Clear()
        Array.Clear(SceneData, 0, SceneData.Length)
        Dim I As Integer = 1
        Dim PresetsInBank() As String = Directory.GetFiles(Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\", "*.dmr")
        Do Until I >= SceneData.Length
            ReDim SceneData(I).ChannelValues(2048)
            ' SET DEFAULTS
            SceneData(I).Automation.tTimer = New Windows.Forms.Timer
            SceneData(I).Automation.tTimer.Interval = 100
            SceneData(I).Automation.tTimer.Tag = I
            AddHandler SceneData(I).Automation.tTimer.Tick, AddressOf tmrPreset_Tick

            'lstDramaPresets.Items.Add(SceneData(I).SceneName)
            'cmbChannelPresetSelection.Items.Add(I & " | " & SceneData(I).SceneName)


            If I <= PresetsInBank.Length Then    '---------- IS A SAVE FILE ----------------
                Dim a1() As String = Split(PresetsInBank(I - 1), "\")
                SceneData(I).SceneName = Mid(a1(a1.Length - 1), 1, a1(a1.Length - 1).Length - 4)
                lstDramaPresets.Items.Add(SceneData(I).SceneName)
                lstSongEditPresets.Items.Add(SceneData(I).SceneName)

                frmChannels.cmbChannelPresetSelection.Items.Add(SceneData(I).SceneName)

                SceneData(I).Automation.Max = 100 ' Set Default
                SceneData(I).Automation.Min = 0 ' Set Default
                SceneData(I).Automation.TimeBetweenMinAndMax = 0 ' Set Default
                SceneData(I).MasterValue = 0 ' Set Default
                SceneData(I).LocIndex = -1 ' Set Default
                SceneData(I).PageNo = -1 ' Set Default

                FileOpen(1, Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & SceneData(I).SceneName & ".dmr", OpenMode.Input)
                Do Until EOF(1)
                    Dim a() As String = Split(LineInput(1), "|")
                    Select Case a(0)
                        Case "P"

                        Case "M"

                        Case "LocIndex"
                            SceneData(I).LocIndex = Val(a(1))
                        Case "PageNo"
                            SceneData(I).PageNo = Val(a(1))
                            Dim newLoc As SCLocs
                            newLoc.PageNo = SceneData(I).PageNo
                            newLoc.PresetIndex = SceneData(I).LocIndex
                            SceneDataLocations.Add(I, newLoc)
                        Case "ChangeMS"
                            SceneData(I).Automation.TimeBetweenMinAndMax = a(1)
                        Case Is > 0
                            With SceneData(I).ChannelValues(a(0))
                                .Automation.tTimer = New Windows.Forms.Timer
                                .Automation.tTimer.Interval = 100 ' Set Default
                                .Automation.tTimer.Tag = I & "|" & a(0)
                                .Automation.RunTimer = False
                                .Automation.ProgressInOrder = True
                                .Automation.ProgressLoop = True
                                .Automation.ProgressRandomTimed = False
                                .Automation.ProgressSoundActivated = False
                                .Automation.SoundActivationThreshold = 500
                                .Automation.ProgressList = New List(Of Integer)


                                For Each s As String In a
                                    Dim b() As String = Split(s, ",")
                                    Select Case b(0) 'SceneData(I).ChannelValues(a(0))
                                        Case "v"
                                            .Value = b(1)
                                        Case "TimerEnabled", "timerenabled"
                                            .Automation.RunTimer = Convert.ToBoolean(b(1))
                                        Case "AutoTimeBetween"
                                            If b(1) = 0 Then
                                                .Automation.tTimer.Interval = 100
                                            Else
                                                .Automation.tTimer.Interval = b(1)
                                            End If

                                        Case "RandomStart"
                                            .Automation.ProgressRandomTimed = Convert.ToBoolean(b(1))
                                        Case "InOrder"
                                            .Automation.ProgressInOrder = Convert.ToBoolean(b(1))
                                        Case "RandomSound"
                                            .Automation.ProgressSoundActivated = Convert.ToBoolean(b(1))
                                        Case "SoundThreshold"
                                            .Automation.SoundActivationThreshold = Val(b(1))
                                        Case "IsLooped"
                                            .Automation.ProgressLoop = Convert.ToBoolean(b(1))
                                        Case "ProgressList"
                                            If b.Length = 1 Then
                                                'nothing in progress list
                                            Else

                                                For Each iList As String In b
                                                    If Not iList = "ProgressList" Then
                                                        .Automation.ProgressList.Add(Val(iList))
                                                    End If
                                                Next
                                            End If


                                    End Select
                                Next s
                                '.Automation.tTimer.Enabled = .Automation.RunTimer
                                AddHandler .Automation.tTimer.Tick, AddressOf tmrTimer_Tick
                                '.Automation.IntervalSteps = (.Automation.Max - .Automation.Min) / (.Automation.TimeBetweenMinAndMax / 10)
                            End With

                    End Select


                Loop
                Dim I2 As Integer = 1
                Do Until I2 >= SceneData(I).ChannelValues.Length
                    If SceneData(I).ChannelValues(I2).Automation.tTimer Is Nothing Then
                        SceneData(I).ChannelValues(I2).Automation.tTimer = New Windows.Forms.Timer
                        SceneData(I).ChannelValues(I2).Automation.tTimer.Tag = I & "|" & I2
                        AddHandler SceneData(I).ChannelValues(I2).Automation.tTimer.Tick, AddressOf tmrTimer_Tick
                    End If
                    I2 += 1
                Loop
                FileClose(1)

            Else '---------- IS NO SAVE FILE ----------------

                'SceneData(I).SceneName = " "
                ''lstDramaPresets.Items.Add(SceneData(I).SceneName)
                'frmChannels.cmbChannelPresetSelection.Items.Add(SceneData(I).SceneName)

                'Dim I1 As Integer = 1

                'SceneData(I).MasterValue = 0 ' Set Default
                'SceneData(I).Automation.TimeBetweenMinAndMax = 1000 ' Set Default
                'SceneData(I).Automation.Max = 100 ' Set Default
                'SceneData(I).Automation.Min = 0 ' Set Default
                'SceneData(I).LocIndex = -1 ' Set Default
                'SceneData(I).PageNo = -1 ' Set Default

                'Do Until I1 >= ChannelFaders.Count

                '    With SceneData(I).ChannelValues(I1)
                '        .Automation.tTimer = New Windows.Forms.Timer
                '        .Value = 0
                '        .Automation.tTimer.Interval = 100
                '        .Automation.tTimer.Enabled = False
                '        .Automation.tTimer.Tag = I & "|" & I1
                '        .Automation.ProgressInOrder = False
                '        .Automation.ProgressLoop = False
                '        .Automation.ProgressRandomTimed = False
                '        .Automation.ProgressSoundActivated = False
                '    End With
                '    AddHandler SceneData(I).ChannelValues(I1).Automation.tTimer.Tick, AddressOf tmrTimer_Tick
                '    I1 += 1
                'Loop

            End If


















            I += 1
        Loop



        If frmChannels.cmbChannelPresetSelection.SelectedIndex = -1 Then frmChannels.cmbChannelPresetSelection.SelectedIndex = 0



        'Dim I As Integer = 1
        'Do Until I >= PresetControls.Length
        '    If PresetControls(I).PresetName = "" Then Exit Do

        '    FileOpen(1, Application.StartupPath & "\Save Files\" & cmbBank.SelectedItem & "\" & PresetControls(I).PresetName & ".dmr", OpenMode.Input)
        '    Do Until EOF(1)
        '        Dim a() As String = Split(LineInput(1), "|")
        '        Select Case a(0)
        '            Case "M"
        '                a(0) = "P"
        '            Case "P"
        '                a(1) = 0 'sets preset starting value to 0 because whats the point of something going up on bank change?
        '                PresetControls(I).vScroll.Value = a(1)
        '                PresetControls(I).vtxtBox.Text = a(1)
        '                If a(1) > 0 Then
        '                    PresetControls(I).cmdTouchbutton.BackColor = Color.Red
        '                End If
        '            Case "ChangeMS"
        '                PresetControls(I).Automation.numChangeMS.Value = a(1)
        '            Case Is > 0
        '                With PresetControls(I).Dmrs(a(0))
        '                    For Each s As String In a
        '                        Dim b() As String = Split(s, ",")
        '                        Select Case b(0)
        '                            Case "v"
        '                                '.vScroll.Value = b(1)
        '                                .vtxtBox.Text = b(1)
        '                            Case "tmr"
        '                                .Automation.tTimer.Interval = b(1)
        '                            Case "timerenabled"
        '                                .Automation.tTimer.Enabled = Convert.ToBoolean(b(1))
        '                            Case "AutoMax"
        '                                .Automation.Max = b(1)
        '                            Case "AutoMin"
        '                                .Automation.Min = b(1)
        '                            Case "AutoTimeBetween"
        '                                .Automation.Timebetween = b(1)
        '                            Case "RandomStart"
        '                                .Automation.randomstart = Convert.ToBoolean(b(1))
        '                        End Select
        '                    Next s
        '                End With

        '        End Select

        '    Loop

        '    FileClose(1)

        '    I += 1
        'Loop

        'Try
        '    FileClose(1)
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub cmdReloadPresetLocations_Click(sender As Object, e As EventArgs) Handles cmdReloadPresetLocations.Click
        GeneratePresetFormControls()
    End Sub
    Private Sub SetupThreads()

        If tChannelsMultipleThreads = False Then
            tChannels(1) = New Thread(AddressOf threadloop)
            tChannels(1).Name = "tChannel"
            tChannels(1).Start()
        Else
            Dim I As Integer = 0
            Do Until I >= numEndChannel.Value
                tChannels(I) = New Thread(Sub() Me.MultipleThreadLoops(I))
                tChannels(I).Name = "tChannel" & I
                tChannels(I).Start()
                I += 1
            Loop

        End If

    End Sub

    Sub GeneratePresetFormControls()
        tbpPresets.Controls.Clear()
        PresetsPerColumn = 0
        PresetsPerRow = 0

        For Each c As Windows.Forms.Control In tbpPresetsControls
            tbpPresets.Controls.Add(c)
        Next

        Dim XUpTo As Integer = 0
        Dim YUpTo As Integer = 0

        Dim RunningColumnNum As Integer = 1

        Dim I As Integer = 1

        Dim PresetModifier As Integer = 0
        If cmdPresetP1.BackColor = Color.Red Then PresetModifier = 0
        If cmdPresetP2.BackColor = Color.Red Then PresetModifier = PresetFadersTotal
        If cmdPresetP3.BackColor = Color.Red Then PresetModifier = PresetFadersTotal * 2
        If cmdPresetP4.BackColor = Color.Red Then PresetModifier = PresetFadersTotal * 3
        If cmdPresetP5.BackColor = Color.Red Then PresetModifier = PresetFadersTotal * 4
        If cmdPresetP6.BackColor = Color.Red Then PresetModifier = PresetFadersTotal * 5

        Do Until I > PresetFaders.Count - 1
            PresetFaders(I).cSceneControl = New SceneControl1
            PresetFaders(I).border = New Rectangle(StartX + XUpTo - 1, StartY + YUpTo - 1, 292 + 2, SceneControlHeight + 2)
            '(StartX + XUpTo, StartY + YUpTo)
            With PresetFaders(I).cSceneControl
                .SceneIndex = I + PresetModifier
                .PresetFixture = I
                .WithFader = bWithFader

                .Size = New Point(292, SceneControlHeight)
                .vScroll.Visible = .WithFader


                .vScroll.BackColor = frmMain.lblChannelBackColour.BackColor
                .vScroll.FillColor = frmMain.lblChannelFillColour.BackColor
                .vScroll.BulletColor = frmMain.lblChannelBulletColour.BackColor


                .cAutoTime.ForeColor = lblSceneLabelColour.BackColor
                '.cAutoTime.T1ag = I + PresetModifier
                .cAutoTime.Maximum = 100000
                .cAutoTime.Minimum = 0
                .cAutoTime.Value = 2000

                .cBlackout.BackColor = lblSceneBlackoutColour.BackColor
                .cBlackout.ForeColor = lblSceneLabelColour.BackColor
                '.cBlackout.T1ag = I + PresetModifier

                .cFull.BackColor = Color.Black
                .cFull.ForeColor = lblSceneLabelColour.BackColor
                '.cFull.T1ag = I + PresetModifier

                .cPresetName.Text = SceneData(I).SceneName
                .cPresetName.BackColor = Color.Black
                .cPresetName.ForeColor = lblSceneLabelColour.BackColor
                '.cPresetName.T1ag = I + PresetModifier
                .cPresetName.ContextMenuStrip = ctxPresetLabelActions

                .cTxtVal.BackColor = Color.Black
                .cTxtVal.ForeColor = lblSceneLabelColour.BackColor
                .cTxtVal.Text = "0"
                '.cTxtVal.T1ag = I + PresetModifier

            End With

            'PresetFaders(I).cAutoTime = New Windows.Forms.NumericUpDown
            'With PresetFaders(I).cAutoTime
            '    .Size = New Point(50, 23)
            '    .Name = "prsnumAutoTime" & (I + PresetModifier)
            '    .BackColor = Color.Black
            '    .ForeColor = lblSceneLabelColour.BackColor
            '    .T1ag = I + PresetModifier
            '    .Maximum = 100000
            '    .Minimum = 0
            '    .Value = 2000
            'End With

            'PresetFaders(I).cBlackout = New Button
            'With PresetFaders(I).cBlackout
            '    .Size = New Point(60, 42) '(60, 22)
            '    .Text = "Blackout"
            '    .Name = "prscmdBlackout" & (I + PresetModifier)
            '    '.BackColor = controlcolour
            '    .BackColor = lblSceneBlackoutColour.BackColor
            '    .ForeColor = lblSceneLabelColour.BackColor
            '    .FlatStyle = FlatStyle.Flat
            '    .T1ag = I + PresetModifier
            'End With

            'PresetFaders(I).cFull = New Button
            'With PresetFaders(I).cFull
            '    .Size = New Point(60, 42) '(60, 22)
            '    .Text = "Full"
            '    .Name = "prscmdFull" & (I + PresetModifier)
            '    '.BackColor = controlcolour
            '    .BackColor = Color.Black
            '    .ForeColor = lblSceneLabelColour.BackColor
            '    .FlatStyle = FlatStyle.Flat
            '    .T1ag = I + PresetModifier
            'End With

            'PresetFaders(I).cPresetName = New Label
            'With PresetFaders(I).cPresetName
            '    .Size = New Point(113, 42)
            '    .Text = SceneData(I).SceneName
            '    .Name = "prslbl" & (I + PresetModifier)
            '    .BackColor = Color.Black
            '    .ForeColor = lblSceneLabelColour.BackColor
            '    .BorderStyle = BorderStyle.FixedSingle
            '    .T1ag = I + PresetModifier
            '    .ContextMenuStrip = ctxPresetLabelActions
            'End With

            'PresetFaders(I).cFader = New GScrollBar
            'With PresetFaders(I).cFader
            '    '.LargeChange = 1
            '    .Orientation = GControlOrientation.Horizontal
            '    .BackColor = lblSceneBackColour.BackColor
            '    .FillColor = lblSceneFillColour.BackColor
            '    .BulletColor = lblSceneBulletColour.BackColor
            '    .Maximum = 100
            '    .Value = 0
            '    .Size = New System.Drawing.Size(239, 42)
            '    .Name = "prsvScroll" & (I + PresetModifier)
            '    .T1ag = I + PresetModifier
            'End With

            'PresetFaders(I).cTxtVal = New TextBox
            'With PresetFaders(I).cTxtVal
            '    .Size = New Point(50, 23)
            '    .BackColor = Color.Black
            '    .ForeColor = lblSceneLabelColour.BackColor
            '    .Text = "0"
            '    .Name = "prsvtxt" & (I + PresetModifier)
            '    .T1ag = I + PresetModifier
            'End With


            PresetFaders(I).cSceneControl.Location = New Point(StartX + XUpTo, StartY + YUpTo)
            PresetFaders(I).OrigLeft = StartX + XUpTo
            PresetFaders(I).OrigTop = StartY + YUpTo

            'PresetFaders(I).cPresetName.Location = New Point(StartX + XUpTo, StartY + YUpTo)
            'PresetFaders(I).cFader.Location = New Point(StartX + XUpTo + vscrDiffX, StartY + YUpTo + vscrDiffY)
            'PresetFaders(I).cTxtVal.Location = New Point(StartX + XUpTo + txtDiffX, StartY + YUpTo + txtDiffY)
            'PresetFaders(I).cAutoTime.Location = New Point(StartX + XUpTo + numChangeMSDiffX, StartY + YUpTo + numChangeMSDiffY)
            'PresetFaders(I).cBlackout.Location = New Point(StartX + XUpTo + cmdBlackoutDiffX, StartY + YUpTo + cmdBlackoutDiffY)
            'PresetFaders(I).cFull.Location = New Point(StartX + XUpTo + cmdFullDiffX, StartY + YUpTo + cmdFullDiffY)



            AddHandler PresetFaders(I).cSceneControl.vScroll.ValueChanged, AddressOf cPresetFader_Scroll
            AddHandler PresetFaders(I).cSceneControl.cTxtVal.TextChanged, AddressOf cPresetTxtVal_TextChanged
            AddHandler PresetFaders(I).cSceneControl.cAutoTime.ValueChanged, AddressOf cAutoTime_ValueChanged
            AddHandler PresetFaders(I).cSceneControl.cBlackout.Click, AddressOf cPresetBlackout_Click
            AddHandler PresetFaders(I).cSceneControl.cFull.Click, AddressOf cPresetFull_Click
            AddHandler PresetFaders(I).cSceneControl.cPresetName.MouseMove, AddressOf lblPresetName_MouseMove
            AddHandler PresetFaders(I).cSceneControl.cPresetName.MouseUp, AddressOf lblPresetName_MouseUp

            tbpPresets.Controls.Add(PresetFaders(I).cSceneControl)

            'tbpPresets.Controls.Add(PresetFaders(I).cPresetName)
            'tbpPresets.Controls.Add(PresetFaders(I).cFader)
            'tbpPresets.Controls.Add(PresetFaders(I).cTxtVal)
            'tbpPresets.Controls.Add(PresetFaders(I).cAutoTime)
            'tbpPresets.Controls.Add(PresetFaders(I).cBlackout)
            'tbpPresets.Controls.Add(PresetFaders(I).cFull)




            YUpTo += IntervalY

            If StartY + YUpTo + PresetFaders(I).cSceneControl.Size.Height >= lstPresetsSongs.Location.Y Then
                'change column
                YUpTo = 0
                XUpTo += IntervalX
                RunningColumnNum += 1
                If PresetsPerColumn = 0 Then PresetsPerColumn = I 'only need once
            End If
            If StartX + XUpTo + PresetFaders(I).cSceneControl.Size.Width >= cmdPresetP1.Location.X Then
                GoTo DoneGeneration
                Exit Do
            End If




            I += 1
        Loop




DoneGeneration:
        PresetsPerRow = I / PresetsPerColumn
        PresetFadersTotal = I
        RenamePresetFaderControls()

    End Sub

    Private Sub RenamePresetFaderControls()
        If RenamePresetFaderOk = False Then Exit Sub
        PagingChanged = True
        'Dim sw As New Stopwatch
        'sw.Start()
        Dim resetI As Integer = 1
        Dim CurrentPageNo As Integer = 1
        Do Until resetI > PresetFadersTotal 'clears presetfaders
            PresetFaders(resetI).cSceneControl.SceneIndex = -1
            'PresetFaders(resetI).cSceneControl.PresetFixture = -1
            PresetFaders(resetI).cSceneControl.cPresetName.Text = ""

            'PresetFaders(resetI).cSceneControl.cBlackout.BackColor = lblSceneBlackoutColour.BackColor
            'PresetFaders(resetI).cSceneControl.cFull.BackColor = Color.Black
            resetI += 1
        Loop

        If cmdPresetP1.BackColor = Color.Red Then
            CurrentPageNo = 1
            PresetFaderControlModifier = 0
        End If
        If cmdPresetP2.BackColor = Color.Red Then
            CurrentPageNo = 2
            PresetFaderControlModifier = PresetFadersTotal
        End If
        If cmdPresetP3.BackColor = Color.Red Then
            CurrentPageNo = 3
            PresetFaderControlModifier = PresetFadersTotal * 2
        End If
        If cmdPresetP4.BackColor = Color.Red Then
            CurrentPageNo = 4
            PresetFaderControlModifier = PresetFadersTotal * 3
        End If
        If cmdPresetP5.BackColor = Color.Red Then
            CurrentPageNo = 5
            PresetFaderControlModifier = PresetFadersTotal * 4
        End If
        If cmdPresetP6.BackColor = Color.Red Then
            CurrentPageNo = 6
            PresetFaderControlModifier = PresetFadersTotal * 5
        End If

        Dim SceneI As Integer = 1

        ' Loop where PageNo is set
        Do Until SceneI >= SceneData.Length
            If SceneData(SceneI).PageNo = CurrentPageNo Then
                If SceneData(SceneI).LocIndex > -1 Then
                    If SceneI > PresetFadersTotal Then
                        ' Has page set to this page, but would appear offscreen
                        ' reset location
                        SceneData(SceneI).LocIndex = -1
                        SceneData(SceneI).PageNo = -1
                    Else
                        With PresetFaders(SceneData(SceneI).LocIndex).cSceneControl
                            If .SceneIndex = -1 Then
                                'Preset is empty and available for a Scene
                                '.PresetFixture = SceneData(SceneI).LocIndex
                                .SceneIndex = SceneI

                                .cAutoTime.Value = SceneData(SceneI).Automation.TimeBetweenMinAndMax
                                .cPresetName.Text = SceneData(SceneI).SceneName
                                .cTxtVal.Text = SceneData(SceneI).MasterValue

                            Else
                                ' Preset Location was already taken. Set attempted Scene to Locationless -1
                                SceneData(SceneI).LocIndex = -1
                                If ResaveOnSceneLoad = True Then
                                    SaveScene(SceneData(SceneI).SceneName)
                                End If
                            End If

                        End With
                    End If

                End If
            End If
            UpdatePresetControls(SceneI)
            SceneI += 1
        Loop


        SceneI = 1
        'remaining undefined
        Do Until SceneI >= SceneData.Length
            Dim PresetI As Integer = 0
            If SceneData(SceneI).PageNo = -1 Or (SceneData(SceneI).PageNo = CurrentPageNo And SceneData(SceneI).LocIndex = -1) Then
                'If PresetFaders(PresetI).cSceneControl Is Nothing Then Exit Do

                PresetI = SetupNewSceneLocation(SceneI)

            End If

            SceneI += 1
            If PresetI > PresetFaders.Length Then
                SceneI = PresetFadersTotal + 5
            End If
        Loop
        resetI = 1
        Do Until resetI > PresetFadersTotal

            If PresetFaders(resetI).cSceneControl.SceneIndex = -1 And PresetFaders(resetI).cSceneControl.cPresetName.Text = "" Then

                PresetFaders(resetI).cSceneControl.cBlackout.BackColor = lblSceneBlackoutColour.BackColor
                PresetFaders(resetI).cSceneControl.cFull.BackColor = Color.Black
                PresetFaders(resetI).cSceneControl.cTxtVal.Text = 0
                PresetFaders(resetI).cSceneControl.vScroll.Value = 0
            End If

            resetI += 1
        Loop

        'MsgBox(sw.Elapsed.ToString)
        'sw.Stop()
        PagingChanged = False
    End Sub

    Function SetupNewSceneLocation(ByVal SceneI As Integer)
        Dim CurrentPageNo As Integer = 1
        If cmdPresetP1.BackColor = Color.Red Then
            CurrentPageNo = 1
        End If
        If cmdPresetP2.BackColor = Color.Red Then
            CurrentPageNo = 2
        End If
        If cmdPresetP3.BackColor = Color.Red Then
            CurrentPageNo = 3
        End If
        If cmdPresetP4.BackColor = Color.Red Then
            CurrentPageNo = 4
        End If
        If cmdPresetP5.BackColor = Color.Red Then
            CurrentPageNo = 5
        End If
        If cmdPresetP6.BackColor = Color.Red Then
            CurrentPageNo = 6
        End If

        Dim PresetI As Integer = 1
        Do Until PresetI > PresetFadersTotal 'PresetFaders(PresetI).cSceneControl.SceneIndex = -1

            If PresetFaders(PresetI).cSceneControl.SceneIndex = -1 Then

                ' PresetI now indexes an empty PresetFader

                SceneData(SceneI).PageNo = CurrentPageNo
                SceneData(SceneI).LocIndex = PresetI

                With PresetFaders(PresetI).cSceneControl
                    If Not PresetI + PresetFaderControlModifier >= PresetFaders.Length Then ' Double checks Scene and Preset are currently on active page

                        '.PresetFixture = PresetI
                        .SceneIndex = SceneI

                        ' Load SceneData into SceneControl1
                        .cAutoTime.Value = SceneData(SceneI + PresetFaderControlModifier).Automation.TimeBetweenMinAndMax
                        .cPresetName.Text = SceneData(SceneI).SceneName
                        .cTxtVal.Text = SceneData(SceneI).MasterValue

                    End If

                End With
                If ResaveOnSceneLoad = True Then
                    SaveScene(SceneData(SceneI).SceneName)
                End If

                UpdatePresetControls(SceneI)
                Exit Do
            End If
            PresetI += 1
            'If PresetI > PresetFadersTotal Then
            '    ' Empty PresetFader was not found
            '    CurrentPageNo += 1
            '    PresetI = 1
            'End If
        Loop
        Return PresetI
    End Function

#End Region

#Region "Start Channel Fader Controls"

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Shift = True Then
            shiftdown = True
            'Label2.Text = "Shift Down"
        ElseIf e.Control = True Then
            ctrldown = True
            'Label2.Text = "Ctrl Down"
        End If
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If shiftdown = True Then
            shiftdown = False
            lblUpDownTest.Text = "Shift Up"
        End If
        If ctrldown = True Then
            ctrldown = False
            lblUpDownTest.Text = "Ctrl Up"
        End If

    End Sub

    Private Sub tmrTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If formopened = False Then Exit Sub
        Dim SceneIndex As Integer = Split(sender.tag, "|")(0)
        Dim ChannelIndex As Integer = Split(sender.tag, "|")(1)


        With SceneData(SceneIndex).ChannelValues(ChannelIndex)

            ' List In Order
            If .Automation.ProgressInOrder = True Then
                If .Automation.CurrentIofList >= .Automation.ProgressList.Count - 1 Then
                    .Automation.CurrentIofList = 0
                    If .Automation.ProgressLoop = False Then
                        .Automation.tTimer.Stop()
                    End If
                Else
                    .Automation.CurrentIofList += 1
                    .Value = .Automation.ProgressList(.Automation.CurrentIofList)
                End If
            End If

            ' List Timed Random
            If .Automation.ProgressRandomTimed = True Then
                .Automation.CurrentIofList = GetRandom(0, .Automation.ProgressList.Count)
                .Value = .Automation.ProgressList(.Automation.CurrentIofList)
            End If

            ' List Sound Random
            If .Automation.ProgressSoundActivated = True And SoundActivationCurrentLevel >= .Automation.SoundActivationThreshold Then
                .Automation.CurrentIofList = GetRandom(0, .Automation.ProgressList.Count)
                .Value = .Automation.ProgressList(.Automation.CurrentIofList)
            End If


            ' After .Value is changed update controls
            If frmChannels.cmbChannelPresetSelection.SelectedIndex = SceneIndex - 1 Then ' And tbcControls1.SelectedTab Is frmChannels Then
                frmChannels.UpdateFixtureLabel(ChannelIndex)

                Dim I As Integer = 1
                Do Until I >= ChannelFaders.Count
                    If Not ChannelFaders(I).cFader Is Nothing Then
                        If ChannelFaders(I).cFader.Tag = ChannelIndex Then
                            ChannelFaders(I).cFader.Value = .Value
                            Exit Do
                        End If
                        If ChannelIndex < Val(ChannelFaders(I).cFader.Tag) Then Exit Do
                    End If

                    I += 1
                Loop

            End If



            'If .Automation.tmrDirection = "Down" Then
            '    If (.Value - .Automation.IntervalSteps) <= .Automation.Min Then
            '        .Value = .Automation.Min
            '        .Automation.tmrDirection = "Up"
            '        'ElseIf (.Value - .Automation.IntervalSteps) = .Automation.Min Then
            '        '    .Automation.tmrDirection = "Up"
            '        '    .Value += .Automation.IntervalSteps
            '    Else
            '        .Value -= .Automation.IntervalSteps
            '    End If
            'ElseIf .Automation.tmrDirection = "Up" Then
            '    If (.Value + .Automation.IntervalSteps) >= .Automation.Max Then
            '        .Value = .Automation.Max
            '        .Automation.tmrDirection = "Down"
            '        'ElseIf (.Value + .Automation.IntervalSteps) = .Automation.Max Then
            '        '    .Automation.tmrDirection = "Down"
            '        '    .Value -= .Automation.IntervalSteps
            '    Else
            '        .Value += .Automation.IntervalSteps
            '    End If
            'Else ' Doesn't have a direction
            '    Dim I As Integer = GetRandom(1, 2)
            '    If I = 1 Then
            '        .Automation.tmrDirection = "Down"
            '    Else
            '        .Automation.tmrDirection = "Up"
            '    End If
            'End If


            'If I > PresetFaderControlModifier And I <= (PresetFaderControlModifier + PresetFadersTotal) Then
            '    PresetFaders(I - PresetFaderControlModifier).cTxtVal.Text = SceneData(I).MasterValue
            'End If

        End With


    End Sub
#End Region

#Region "Scene Fader Controls"
    Private Sub cPresetFader_Scroll(ByVal Sender As System.Object) ' Handles GScrollBar1.ValueChanged 'ByVal sender As System.Object, ByVal e As System.EventArgs)
        If PagingChanged = True Then Exit Sub
        If Sender.visible = False Then Exit Sub
        'Dim chno As Integer = 1
        'SceneData(sender.Parent.SceneIndex).MasterValue = Val(sender.text)
        'Do Until PresetFaders(chno).cFader.Name = Sender.Name : chno += 1 : Loop

        If Not PresetFaders(Sender.Parent.PresetFixture).cSceneControl.cTxtVal.Text = Sender.value Then
            PresetFaders(Sender.Parent.PresetFixture).cSceneControl.cTxtVal.Text = Sender.value
            If Not Sender.Parent.SceneIndex = -1 Then
                SceneData(Sender.Parent.SceneIndex).MasterValue = Sender.value
            End If
            '  ListBox2.Items.Add(chno)
        End If
        'UpdatePresetControls(Sender.Parent.SceneIndex)
    End Sub
    Private Sub cAutoTime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) ' Handles TextBox1.TextChanged
        If formopened = False Then Exit Sub
        If PresetVisualUpdate = True Then Exit Sub
        If sender.Parent.SceneIndex = -1 Then Exit Sub
        'Dim chno As Integer = 1
        'Do Until PresetFaders(chno).cAutoTime.Name = sender.Name : chno += 1 : Loop

        'If Not PresetFaders(chno).cFader.Value = Val(sender.text) Then

        SceneData(sender.Parent.SceneIndex).Automation.TimeBetweenMinAndMax = Val(sender.value)

        SaveScene(SceneData(sender.Parent.SceneIndex).SceneName)

        'End If
    End Sub
    Private Sub cPresetTxtVal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) ' Handles TextBox1.TextChanged
        'If otherChanged = True Then otherChanged = False : Exit Sub
        If formopened = False Then Exit Sub
        If PresetVisualUpdate = True Then Exit Sub
        'Dim chno As Integer = 1
        'Do Until PresetFaders(chno).cTxtVal.Name = sender.Name : chno += 1 : Loop
        If Val(sender.text) > 100 Then sender.text = 100

        If Not PresetFaders(sender.Parent.PresetFixture).cSceneControl.vScroll.Value = Val(sender.text) Then
            PresetFaders(sender.Parent.PresetFixture).cSceneControl.vScroll.Value = Val(sender.text)
        End If
        If Not sender.Parent.SceneIndex = -1 Then
            SceneData(sender.Parent.SceneIndex).MasterValue = Val(sender.text)

            If Val(sender.text) > 0 Then
                StartChannelTimers(sender.Parent.SceneIndex, True)
            Else
                StartChannelTimers(sender.Parent.SceneIndex, False)
            End If
        End If

        'UpdatePresetControls(sender.Parent.SceneIndex)

    End Sub

    Private Sub lblPresetName_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)  'varocarbas
        ' Check if the mouse is down
        If MouseButtons.HasFlag(MouseButtons.Left) Then

            'sender.Parent.PresetIndex

            Dim PresetIndex As Integer = sender.Parent.PresetFixture

            ' Set the mouse position
            HoldLeft = (Control.MousePosition.X - Me.Left)
            HoldTop = (Control.MousePosition.Y - Me.Top)
            ' Find where the mouse was clicked ONE TIME
            If TopSet = False Then
                OffTop = HoldTop - PresetFaders(PresetIndex).cSceneControl.Top 'sender.Top

                ' Once the position is held, flip the switch
                ' so that it doesn't keep trying to find the position
                TopSet = True
            End If
            If LeftSet = False Then
                OffLeft = HoldLeft - PresetFaders(PresetIndex).cSceneControl.Left 'sender.Left

                ' Once the position is held, flip the switch
                ' so that it doesn't keep trying to find the position
                LeftSet = True
            End If
            ' Set the position of the object
            'sender.Left = HoldLeft - OffLeft
            'sender.Top = HoldTop - OffTop
            'PresetFaders(PresetIndex).cSceneControl.cPresetName.BringToFront()
            'PresetFaders(PresetIndex).cSceneControl.cAutoTime.BringToFront()
            'PresetFaders(PresetIndex).cSceneControl.cBlackout.BringToFront()
            'PresetFaders(PresetIndex).cSceneControl.cFull.BringToFront()
            'PresetFaders(PresetIndex).cSceneControl.cTxtVal.BringToFront()
            PresetFaders(PresetIndex).cSceneControl.BringToFront()

            PresetFaders(PresetIndex).cSceneControl.Left = HoldLeft - OffLeft
            PresetFaders(PresetIndex).cSceneControl.Top = HoldTop - OffTop
            'PresetFaders(PresetIndex).cSceneControl.cAutoTime.Left = PresetFaders(PresetIndex).cSceneControl.cPresetName.Left + numChangeMSDiffX
            'PresetFaders(PresetIndex).cSceneControl.cAutoTime.Top = PresetFaders(PresetIndex).cSceneControl.cPresetName.Top + numChangeMSDiffY
            'PresetFaders(PresetIndex).cSceneControl.cBlackout.Left = PresetFaders(PresetIndex).cSceneControl.cPresetName.Left + cmdBlackoutDiffX
            'PresetFaders(PresetIndex).cSceneControl.cBlackout.Top = PresetFaders(PresetIndex).cSceneControl.cPresetName.Top + cmdBlackoutDiffY
            'PresetFaders(PresetIndex).cSceneControl.cFull.Left = PresetFaders(PresetIndex).cSceneControl.cPresetName.Left + cmdFullDiffX
            'PresetFaders(PresetIndex).cSceneControl.cFull.Top = PresetFaders(PresetIndex).cSceneControl.cPresetName.Top + cmdFullDiffY
            'PresetFaders(PresetIndex).cSceneControl.cTxtVal.Left = PresetFaders(PresetIndex).cSceneControl.cPresetName.Left + txtDiffX
            'PresetFaders(PresetIndex).cSceneControl.cTxtVal.Top = PresetFaders(PresetIndex).cSceneControl.cPresetName.Top + txtDiffY

        End If

    End Sub
    Private Sub lblPresetName_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button <> MouseButtons.Left Then Exit Sub

        Dim MovingIndex As Integer = sender.Parent.sceneindex  'T1ag = Scene Index
        Dim PresetIndex As Integer = sender.Parent.PresetFixture 'prslbl4
        'MessageBox.Show("Name: " & sender.Name & vbCrLf & "T1ag: " & sender.T1ag)

        'Dim IntervalX As Integer = 301
        'Dim IntervalY As Integer = 48

        'PresetFaders(I).cSceneControl.Location = New Point(StartX + XUpTo, StartY + YUpTo)

        Dim DroppedOffAtLeft As Integer = PresetFaders(PresetIndex).cSceneControl.Left
        Dim DroppedOffAtTop As Integer = PresetFaders(PresetIndex).cSceneControl.Top
        PresetFaders(PresetIndex).cSceneControl.Left = PresetFaders(PresetIndex).OrigLeft
        PresetFaders(PresetIndex).cSceneControl.Top = PresetFaders(PresetIndex).OrigTop

        'PresetFaders(PresetIndex).cAutoTime.Left = PresetFaders(PresetIndex).cPresetName.Left + numChangeMSDiffX
        'PresetFaders(PresetIndex).cAutoTime.Top = PresetFaders(PresetIndex).cPresetName.Top + numChangeMSDiffY
        'PresetFaders(PresetIndex).cBlackout.Left = PresetFaders(PresetIndex).cPresetName.Left + cmdBlackoutDiffX
        'PresetFaders(PresetIndex).cBlackout.Top = PresetFaders(PresetIndex).cPresetName.Top + cmdBlackoutDiffY
        'PresetFaders(PresetIndex).cFull.Left = PresetFaders(PresetIndex).cPresetName.Left + cmdFullDiffX
        'PresetFaders(PresetIndex).cFull.Top = PresetFaders(PresetIndex).cPresetName.Top + cmdFullDiffY
        'PresetFaders(PresetIndex).cTxtVal.Left = PresetFaders(PresetIndex).cPresetName.Left + txtDiffX
        'PresetFaders(PresetIndex).cTxtVal.Top = PresetFaders(PresetIndex).cPresetName.Top + txtDiffY


        Dim I As Integer = 1
        Do Until I >= PresetFadersTotal
            If I >= PresetFaders.Length + 1 Then Exit Do

            Dim RightSideControl As Integer = 0
            If (I + PresetsPerColumn) > PresetFadersTotal Then
                RightSideControl = cmdPresetP1.Location.X
            Else
                RightSideControl = PresetFaders(I + PresetsPerColumn).cSceneControl.Left
            End If




            If DroppedOffAtLeft >= PresetFaders(I).cSceneControl.Left And DroppedOffAtLeft < RightSideControl Then

                Dim BottomControl As Integer = 0
                If PresetFaders(I).cSceneControl.Top > PresetFaders(I + 1).cSceneControl.Top Then ' if true, a new column is at I+1
                    BottomControl = lstPresetsSongs.Location.Y
                Else
                    BottomControl = PresetFaders(I + 1).cSceneControl.Top
                End If

                If DroppedOffAtTop >= PresetFaders(I).cSceneControl.Top And DroppedOffAtTop < BottomControl Then

                    ' I is the one before the new location.
                    ' I+1 is after the drop location. Need a gap between I and I+1

                    If PresetIndex < I Then ' Shuffle difference back 1
                        'PresetIndex = what got dragged
                        'I = where moving is going TO
                        Dim SceneIBeingMoved As Integer = PresetFaders(PresetIndex).cSceneControl.SceneIndex 'BeingMoved now has the scene index number from T1ag
                        Dim J As Integer = PresetIndex
                        Do Until J >= I
                            If Not PresetFaders(J + 1).cSceneControl.SceneIndex = -1 Then

                                SceneData(PresetFaders(J + 1).cSceneControl.SceneIndex).LocIndex -= 1
                                SaveScene(SceneData(PresetFaders(J + 1).cSceneControl.SceneIndex).SceneName)
                                'SceneData(PresetFaders(J + 1).cTxtVal.T1ag).LocIndex -= 1
                                'SceneData(PresetFaders(J + 1).cAutoTime.T1ag).LocIndex -= 1
                                'SceneData(PresetFaders(J + 1).cBlackout.T1ag).LocIndex -= 1
                                'SceneData(PresetFaders(J + 1).cFull.T1ag).LocIndex -= 1
                                'PresetFaders(J) = PresetFaders(J + 1)

                            End If
                            J += 1
                        Loop
                        SceneData(SceneIBeingMoved).LocIndex = J
                        SaveScene(SceneData(SceneIBeingMoved).SceneName)
                        Exit Do
                    ElseIf PresetIndex > I Then ' Shuffle difference forward 1
                        I += 1
                        Dim SceneIBeingMoved As Integer = PresetFaders(PresetIndex).cSceneControl.SceneIndex
                        Dim J As Integer = PresetIndex
                        Do Until J <= I
                            If Not PresetFaders(J - 1).cSceneControl.SceneIndex = -1 Then
                                SceneData(PresetFaders(J - 1).cSceneControl.SceneIndex).LocIndex += 1
                                SaveScene(SceneData(PresetFaders(J - 1).cSceneControl.SceneIndex).SceneName)
                                'SceneData(PresetFaders(J - 1).cTxtVal.T1ag).LocIndex += 1
                                'SceneData(PresetFaders(J - 1).cAutoTime.T1ag).LocIndex += 1
                                'SceneData(PresetFaders(J - 1).cBlackout.T1ag).LocIndex += 1
                                'SceneData(PresetFaders(J - 1).cFull.T1ag).LocIndex += 1
                                'PresetFaders(J) = PresetFaders(J - 1)
                            End If
                            J -= 1
                        Loop
                        SceneData(SceneIBeingMoved).LocIndex = J
                        SaveScene(SceneData(SceneIBeingMoved).SceneName)
                        Exit Do
                    ElseIf PresetIndex = I Then 'spot unchanged
                        Exit Do
                    End If

                End If
            End If
            I += 1
        Loop

        RenamePresetFaderControls()



        TopSet = False
        LeftSet = False
    End Sub
    Public Sub StartChannelTimers(ByVal Sceneindex As Integer, ByVal IsEnabled As Boolean)
        Dim I As Integer = 1
        If Sceneindex = -1 Then
            Exit Sub
        End If
        Do Until I >= SceneData(Sceneindex).ChannelValues.Length

            With SceneData(Sceneindex).ChannelValues(I).Automation
                If .tTimer Is Nothing Then Exit Sub
                If .RunTimer = True And IsEnabled = True Then
                    If .tTimer.Enabled = False Then
                        If .ProgressRandomTimed = True Or .ProgressRandomTimed = True Then
                            .CurrentIofList = GetRandom(0, .ProgressList.Count - 1)
                        Else
                            .CurrentIofList = 0
                        End If

                        .tTimer.Enabled = True
                    End If
                ElseIf IsEnabled = False Then
                    .tTimer.Enabled = False
                End If
            End With
            I += 1
        Loop
    End Sub

    Public Sub cPresetFull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If formopened = False Then Exit Sub
        Dim I As Integer = sender.Parent.SceneIndex
        If I <= -1 Then
            ' Is a blank/unsaved preset

            Exit Sub
        End If

        'start channel timers
        StartChannelTimers(I, True)

        If SceneData(I).Automation.TimeBetweenMinAndMax = 0 Then
            SceneData(I).MasterValue = 100
            UpdatePresetControls(I)
        Else
            With SceneData(I)
                .Automation.tmrDirection = "Up"
                .Automation.IntervalSteps = SceneData(I).Automation.Max / (.Automation.TimeBetweenMinAndMax / .Automation.tTimer.Interval)

                .Automation.tTimer.Start()
            End With

        End If
    End Sub

    Public Sub cPresetBlackout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If formopened = False Then Exit Sub
        Dim I As Integer = sender.Parent.SceneIndex
        If I = -1 Then Exit Sub
        'start channel timers

        If SceneData(I).Automation.TimeBetweenMinAndMax = 0 Then
            SceneData(I).MasterValue = 0
            UpdatePresetControls(I)
            StartChannelTimers(I, False)
        Else
            With SceneData(I)
                .Automation.tmrDirection = "Down"
                .Automation.IntervalSteps = SceneData(I).Automation.Max / (.Automation.TimeBetweenMinAndMax / .Automation.tTimer.Interval)
                .Automation.tTimer.Start()
            End With
        End If
    End Sub
    Private Sub tmrPreset_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If formopened = False Then Exit Sub
        Dim I As Integer = sender.Tag
        If SceneData(I).Automation.tmrDirection = "Down" Then
            If (SceneData(I).MasterValue - SceneData(I).Automation.IntervalSteps) <= 0 Then
                SceneData(I).Automation.tTimer.Stop()
                SceneData(I).Automation.tmrDirection = "lol"
                SceneData(I).MasterValue = 0
                StartChannelTimers(I, False)
                'PresetFaders(getpres
            Else
                SceneData(I).MasterValue -= SceneData(I).Automation.IntervalSteps
            End If
        ElseIf SceneData(I).Automation.tmrDirection = "Up" Then
            If (SceneData(I).MasterValue + SceneData(I).Automation.IntervalSteps) >= 100 Then
                SceneData(I).Automation.tTimer.Stop()
                SceneData(I).Automation.tmrDirection = "lol"
                SceneData(I).MasterValue = 100
            Else
                SceneData(I).MasterValue += SceneData(I).Automation.IntervalSteps
            End If
        End If
        If SceneData(I).MasterValue > 0 Then StartChannelTimers(I, True)

        'PresetVisualUpdate = True
        'If I > PresetFaderControlModifier And I <= (PresetFaderControlModifier + PresetFadersTotal) Then
        '    PresetFaders(I - PresetFaderControlModifier).cTxtVal.Text = SceneData(I).MasterValue
        'End If
        'PresetVisualUpdate = False
        UpdatePresetControls(I)
    End Sub
    Private Sub CreateNewScene(ByVal SceneName As String, Optional ByVal PresetFixtureIndex As Integer = -1)
        Dim CurrentPageNo As Integer = 0
        If cmdPresetP1.BackColor = Color.Red Then
            CurrentPageNo = 1
            PresetFaderControlModifier = 0
        End If
        If cmdPresetP2.BackColor = Color.Red Then
            CurrentPageNo = 2
            PresetFaderControlModifier = PresetFadersTotal
        End If
        If cmdPresetP3.BackColor = Color.Red Then
            CurrentPageNo = 3
            PresetFaderControlModifier = PresetFadersTotal * 2
        End If
        If cmdPresetP4.BackColor = Color.Red Then
            CurrentPageNo = 4
            PresetFaderControlModifier = PresetFadersTotal * 3
        End If
        If cmdPresetP5.BackColor = Color.Red Then
            CurrentPageNo = 5
            PresetFaderControlModifier = PresetFadersTotal * 4
        End If
        If cmdPresetP6.BackColor = Color.Red Then
            CurrentPageNo = 6
            PresetFaderControlModifier = PresetFadersTotal * 5
        End If

        Dim IemptyScene As Integer = 1
        Do Until IemptyScene >= SceneData.Length
            If SceneData(IemptyScene).SceneName = "" Then
                Exit Do
            End If
            IemptyScene += 1
        Loop

        SceneData(IemptyScene).SceneName = SceneName
        If PresetFaders(PresetFadersTotal).cSceneControl.cPresetName.Text = "" Then
            'If PresetFixtureIndex = -1 Then
            SceneData(IemptyScene).PageNo = CurrentPageNo
        Else
            SceneData(IemptyScene).PageNo = -1
        End If
        SceneData(IemptyScene).LocIndex = PresetFixtureIndex

        Dim I1 As Integer = 1

        SceneData(IemptyScene).MasterValue = 0 ' Set Default
        SceneData(IemptyScene).Automation.TimeBetweenMinAndMax = 1000 ' Set Default
        SceneData(IemptyScene).Automation.Max = 100 ' Set Default
        SceneData(IemptyScene).Automation.Min = 0 ' Set Default
        frmChannels.cmbChannelPresetSelection.Items.Add(SceneData(IemptyScene).SceneName)

        Do Until I1 >= ChannelFaders.Count

            With SceneData(IemptyScene).ChannelValues(I1)
                .Automation.tTimer = New Windows.Forms.Timer
                .Value = 0
                .Automation.tTimer.Interval = 100
                .Automation.tTimer.Enabled = False
                .Automation.tTimer.Tag = IemptyScene & "|" & I1
                .Automation.ProgressInOrder = False
                .Automation.ProgressLoop = False
                .Automation.ProgressRandomTimed = False
                .Automation.ProgressSoundActivated = False
            End With
            AddHandler SceneData(IemptyScene).ChannelValues(I1).Automation.tTimer.Tick, AddressOf tmrTimer_Tick
            I1 += 1
        Loop
        If Not PresetFixtureIndex = -1 Then
            ' exists
            PresetFaders(PresetFixtureIndex).cSceneControl.SceneIndex = IemptyScene
        End If

        SetupNewSceneLocation(IemptyScene)
    End Sub
    Private Sub cmdPresetP1_Click(sender As Object, e As EventArgs) Handles cmdPresetP1.Click, cmdPresetP2.Click, cmdPresetP3.Click, cmdPresetP4.Click, cmdPresetP5.Click, cmdPresetP6.Click
        cmdPresetP1.BackColor = controlcolour
        cmdPresetP2.BackColor = controlcolour
        cmdPresetP3.BackColor = controlcolour
        cmdPresetP4.BackColor = controlcolour
        cmdPresetP5.BackColor = controlcolour
        cmdPresetP6.BackColor = controlcolour

        cmdPresetP1.ForeColor = Color.Black
        cmdPresetP2.ForeColor = Color.Black
        cmdPresetP3.ForeColor = Color.Black
        cmdPresetP4.ForeColor = Color.Black
        cmdPresetP5.ForeColor = Color.Black
        cmdPresetP6.ForeColor = Color.Black

        sender.backcolor = Color.Red
        sender.forecolor = Color.White
        RenamePresetFaderControls()
    End Sub
    Private Sub ckxPresetLabelEditChannels_Click(sender As Object, e As EventArgs) Handles ctxPresetLabelEditChannels.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)
        Dim obj As SceneControl1 = cms.SourceControl.Parent

        frmChannels.cmbChannelPresetSelection.SelectedItem = obj.cPresetName.Text
        ChannelFaderPageCurrentSceneDataIndex = obj.SceneIndex 'GetSceneIndex(frmChannels.cmbChannelPresetSelection.Text)
        'frmChannels.RebuildTextOnChannelLabels()
        frmChannels.BringToFront()
    End Sub

    Private Sub ctxPresetLabelName_Click(sender As Object, e As EventArgs) Handles ctxPresetLabelName.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)
        Dim obj As SceneControl1 = cms.SourceControl.Parent
        'cms.SourceControl.Parent
        MessageBox.Show("SceneIndex: " & obj.SceneIndex & vbCrLf & "PresetFixture: " & obj.PresetFixture)
    End Sub
    Private Sub ctxPresetRenameScene_Click(sender As Object, e As EventArgs) Handles ctxPresetRenameScene.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)
        Dim obj As SceneControl1 = cms.SourceControl.Parent

        'Dim CurrentPageNo As Integer = 0
        'If cmdPresetP1.BackColor = Color.Red Then
        '    CurrentPageNo = 1
        '    PresetFaderControlModifier = 0
        'End If
        'If cmdPresetP2.BackColor = Color.Red Then
        '    CurrentPageNo = 2
        '    PresetFaderControlModifier = PresetFadersTotal
        'End If
        'If cmdPresetP3.BackColor = Color.Red Then
        '    CurrentPageNo = 3
        '    PresetFaderControlModifier = PresetFadersTotal * 2
        'End If
        'If cmdPresetP4.BackColor = Color.Red Then
        '    CurrentPageNo = 4
        '    PresetFaderControlModifier = PresetFadersTotal * 3
        'End If
        'If cmdPresetP5.BackColor = Color.Red Then
        '    CurrentPageNo = 5
        '    PresetFaderControlModifier = PresetFadersTotal * 4
        'End If
        'If cmdPresetP6.BackColor = Color.Red Then
        '    CurrentPageNo = 6
        '    PresetFaderControlModifier = PresetFadersTotal * 5
        'End If

        'Do Until I >= PresetFaders.Count
        '    If PresetFaders(I).cSceneControl.cPresetName.Text = obj.cPresetName.Text Then
        '        'oldprefix = Split(cms.SourceControl.Text, " |")(0)
        '        oldname = obj.cPresetName.Text
        '        Exit Do
        '    End If
        '    I += 1
        'Loop


        If obj.SceneIndex = -1 Then
            'is new scene
            Dim newname As String = InputBox("Please Enter New Scene Name:", "New Scene", "")
            If newname = "" Then Exit Sub


            PresetFaders(obj.PresetFixture).cSceneControl.cPresetName.Text = newname


            lstDramaPresets.Items.Add(newname)
            lstSongEditPresets.Items.Add(newname)
            CreateNewScene(newname, obj.PresetFixture)
            SaveScene(newname)
        Else
            'Scene exists
            Dim oldname As String = SceneData(obj.SceneIndex).SceneName
            Dim newname As String = InputBox("Please Enter New Scene Name:", "Editing Scene #" & obj.SceneIndex, SceneData(obj.SceneIndex).SceneName)
            If newname = "" Then Exit Sub

            SceneData(obj.SceneIndex).SceneName = newname
            PresetFaders(obj.PresetFixture).cSceneControl.cPresetName.Text = newname

            Dim cmbIndx As Integer = frmChannels.cmbChannelPresetSelection.Items.IndexOf(oldname)
            frmChannels.cmbChannelPresetSelection.Items.Item(cmbIndx) = newname

            cmbIndx = lstDramaPresets.Items.IndexOf(oldname)
            lstDramaPresets.Items.Item(cmbIndx) = newname

            File.Move(Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & oldname & ".dmr", Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & newname & ".dmr")
            SaveScene(newname)
        End If


    End Sub

    Private Sub cmdPresetsBlackoutAllTimer_Click(sender As Object, e As EventArgs) Handles cmdPresetsBlackoutAllTimer.Click, cmdDramaBlackoutAllTimer.Click
        If formopened = False Then Exit Sub
        Dim I As Integer = 1
        Do Until I >= SceneData.Length

            'SceneData(I).cmdTouchbutton.BackColor = controlcolour
            'SceneData(I).Automation.numChangeMS = PresetFaders(I).cAutoTime.Value

            If Not SceneData(I).MasterValue = 0 Then
                If SceneData(I).Automation.TimeBetweenMinAndMax = 0 Then
                    'PresetControls(I).vtxtBox.Text = "100"
                    SceneData(I).MasterValue = 0
                Else
                    With SceneData(I)
                        .Automation.tmrDirection = "Down"
                        '.Automation.tmrUpto = .vtxtBox.Text
                        .Automation.IntervalSteps = 100 / (.Automation.TimeBetweenMinAndMax / .Automation.tTimer.Interval)
                        .Automation.tTimer.Start()
                    End With
                End If
            End If
            I += 1
        Loop
        lstDramaPresets.ClearSelected()
    End Sub

    Private Sub cmdPresetsBlackoutAllInstant_Click(sender As Object, e As EventArgs) Handles cmdPresetsBlackoutAllInstant.Click, cmdDramaBlackoutAllInstant.Click
        If formopened = False Then Exit Sub
        Dim I As Integer = 1
        Do Until I >= SceneData.Length
            SceneData(I).Automation.tmrDirection = "lol"
            SceneData(I).MasterValue = 0
            StartChannelTimers(I, False)
            If I < PresetFaders.Length Then
                UpdatePresetControls(I)
            End If
            I += 1
        Loop
        lstDramaPresets.ClearSelected()

    End Sub


#End Region

#Region "ThreadLoop Stuff"
    Private Sub threadloop()
        Do While closethreads = False

            For Dmxno = 1 To numEndChannel.Value ' Looping through channels
                'Dim Univ As Integer = Math.Floor(DMXChannelNumber / 512) + 1



                Dim LargestNo As Integer = 0
                Dim I As Integer = 1
                Do Until I >= SceneData.Count ' Looping through Scenes
                    If BankChanged = True Then GoTo SkipLoops
                    If Not SceneData(I).ChannelValues Is Nothing Then
                        If (((SceneData(I).ChannelValues(Dmxno).Value / 100) * SceneData(I).MasterValue) / 100) * vsMaster.Value > LargestNo Then
                            LargestNo = (((SceneData(I).ChannelValues(Dmxno).Value / 100) * SceneData(I).MasterValue) / 100) * vsMaster.Value
                        End If
                    End If
                    I += 1
                Loop
                If Not SentChannelValues(Dmxno) = LargestNo Then

                    SetChannelData(Dmxno, LargestNo)
                    SentChannelValues(Dmxno) = LargestNo


                End If
            Next Dmxno
            GoTo LoopsDone
SkipLoops:

            Thread.Sleep(10)
LoopsDone:
            Thread.Sleep(1)
        Loop
    End Sub
    Private Sub MultipleThreadLoops(ByVal DMXno As Integer)
        Do While closethreads = False

            ' For DMXChannelNumber = 1 To numEndChannel.Value ' Looping through channels

            Dim LargestNo As Integer = 0
            Dim I As Integer = 1
            Do Until I >= SceneData.Count ' Looping through Scenes
                If BankChanged = True Then GoTo SkipLoops
                If Not SceneData(I).ChannelValues Is Nothing Then
                    If (((SceneData(I).ChannelValues(DMXno).Value / 100) * SceneData(I).MasterValue) / 100) * vsMaster.Value > LargestNo Then
                        LargestNo = (((SceneData(I).ChannelValues(DMXno).Value / 100) * SceneData(I).MasterValue) / 100) * vsMaster.Value
                    End If
                End If
                I += 1
            Loop
            If Not SentChannelValues(DMXno) = LargestNo Then

                SetChannelData(DMXno, LargestNo)
                SentChannelValues(DMXno) = LargestNo


            End If
            ' Next DMXChannelNumber
            GoTo LoopsDone
SkipLoops:

            Thread.Sleep(10)
LoopsDone:
            Thread.Sleep(5)
        Loop
    End Sub

    Private Sub SetChannelData(ByVal Channel As Integer, ByVal Value As Integer)

        If Testmode = True Then Exit Sub

        Dim Univ As Integer = 1
        Dim Dmxno As Integer = 1
        If Channel > 0 And Channel <= 512 Then
            Univ = 1
            Dmxno = Channel
        ElseIf Channel > 512 And Channel <= 1024 Then
            Univ = 2
            Dmxno = Channel - 512
        ElseIf Channel > 1024 And Channel <= 1536 Then
            Univ = 3
            Dmxno = Channel - 1024
        ElseIf Channel > 1536 And Channel <= 2048 Then
            Univ = 4
            Dmxno = Channel - 1536
        End If

        If Not Dmxno > 512 And Univ = 1 Then
            EnttecOpenDMX.OpenDMX.setDmxValue(Dmxno, Value)
        End If
        ArdDMX.SendData(Univ, Dmxno) = Value

    End Sub
#End Region

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

            Label20.Visible = False
            lbleditRemaining.Visible = False
            cmdEditPlay.Visible = False
            cmdEditStop.Visible = False
            ' lstMusicSongChanges.Location = New Point(414, 47)
            'lstMusicSongChanges.Size = New Point(231, 160)
            'lstMusicSongChanges.Anchor = AnchorStyles.Top
        End If


    End Sub

    'Dim waveOut As WaveOut = New WaveOut(WaveCallbackInfo.FunctionCallback())

    'Structure ReadWav1
    '    Dim audio
    '    Dim sampleRate
    'End Structure
    'Function ReadWav(ByVal filename As String)

    '    Using afr = New NAudio.Wave.AudioFileReader(filename)
    '        Dim sampleRate As Integer = afr.WaveFormat.SampleRate
    '        Dim sampleCount As Integer = Val(afr.Length / afr.WaveFormat.BitsPerSample / 8)
    '        Dim channelCount As Integer = afr.WaveFormat.Channels
    '        Dim audio = New List(Of Double)(sampleCount)
    '        Dim buffer = New Single(sampleRate * channelCount - 1) {}
    '        Dim samplesRead As Integer = 0
    '        'while ((samplesRead = afr.Read(buffer, 0, buffer.Length)) > 0)
    '        While (afr.Read(buffer, 0, buffer.Length)) > 0
    '            samplesRead = afr.Read(buffer, 0, buffer.Length)
    '            'audio.AddRange(buffer.Take(samplesRead).Select(x => (double)x));
    '            'audio.AddRange(buffer.Take(samplesRead).Select(Function(x) New With {Key x}))

    '            'mcArr.Select(Function(m) Double.Parse(m.ToString())).ToArray()
    '            audio.AddRange(buffer.Take(samplesRead).Select(Function(x) Double.Parse(x)))


    '            'mcArr.Select(Function(m) Double.Parse(m.ToString())).ToArray()
    '            'Dim numarr() As Double = Array.ConvertAll(Of Single, Double)(buffer.Take(samplesRead), Function(s) CDbl(s))
    '            'audio.AddRange(numarr)
    '            'audio.AddRange(Array.ConvertAll(buffer.Take(samplesRead), Function(X) Double.Parse(X)))


    '            'audio.AddRange(buffer.Take(samplesRead).Select(Of x >= (Double)x))
    '        End While

    '        Dim return1 As ReadWav1
    '        return1.audio = audio.ToArray()
    '        return1.sampleRate = sampleRate
    '        Return return1
    '    End Using
    'End Function
    Private Sub tmrMP3_Tick(sender As Object, e As EventArgs) Handles tmrMP3.Tick
        updatePlayer()
    End Sub

    Private Sub tmrMP32_Tick(sender As Object, e As EventArgs) Handles tmrMP32.Tick
        updatePlayer2()
    End Sub
    Private Sub updatePlayer()
        tmrchangedmp3 = True

        Dim Qindex As Integer = GetMusicCueIndex(lstPresetsSongs.SelectedItem)

        Dim PositionMilli As Double = 0 ' Math.Round(Player.controls.currentPosition, 2)
        If MusicCues(Qindex).IsMP3 = True Then
            'If ASIOMode = True Then
            lblPresetsMP3Duration.Text = AudioRun.TotalTime(MusicCues(Qindex).SongFileName) 'MusicCues(Qindex).AudioReader.TotalTime.ToString("mm\:ss")
            lblPresetsMP3Position.Text = AudioRun.CurrentPosition(MusicCues(Qindex).SongFileName) ' MusicCues(Qindex).AudioReader.CurrentTime.ToString("mm\:ss")
            PositionMilli = Val(AudioRun.CurrentPosition(MusicCues(Qindex).SongFileName, True)) 'MusicCues(Qindex).AudioReader.CurrentTime.ToString("ss\.ff")
            'Else
            'lblPresetsMP3Duration.Text = MusicCues(Qindex).mp3Reader.TotalTime.ToString("mm\:ss")
            'lblPresetsMP3Position.Text = MusicCues(Qindex).mp3Reader.CurrentTime.ToString("mm\:ss")
            'PositionMilli = MusicCues(Qindex).mp3Reader.CurrentTime.ToString("ss\.ff")
            'End If

            ' Display Current Time Position and Duration

            lblMusicMP3Duration.Text = lblPresetsMP3Duration.Text
            lblDramaViewMP3Duration.Text = lblPresetsMP3Duration.Text

            lblMusicMP3Position.Text = lblPresetsMP3Position.Text
            lblDramaViewMP3Position.Text = lblPresetsMP3Position.Text


            With vSongEdit
                .Minimum = 0
                .Maximum = CInt(Val(AudioRun.TotalTime(MusicCues(Qindex).SongFileName, True)))
                .Value = CInt(PositionMilli)

            End With
        ElseIf MusicCues(Qindex).IsSCS = True Then

            lblPresetsMP3Duration.Text = MusicCues(Qindex).SCSinfo.Length
            lblMusicMP3Duration.Text = lblPresetsMP3Duration.Text
            lblDramaViewMP3Duration.Text = lblPresetsMP3Duration.Text

            lblPresetsMP3Position.Text = MusicCues(Qindex).SCSinfo.swElapsed.Elapsed.ToString("mm\:ss")
            lblMusicMP3Position.Text = lblPresetsMP3Position.Text
            lblDramaViewMP3Position.Text = lblPresetsMP3Position.Text

            PositionMilli = MusicCues(Qindex).SCSinfo.swElapsed.Elapsed.TotalSeconds

            With vSongEdit
                .Minimum = 0
                .Maximum = CInt(MusicCues(Qindex).SCSinfo.Length)
                .Value = CInt(PositionMilli)

            End With
        End If


        lblPresetsMP3PositionMilli.Text = PositionMilli
        lblMusicMP3PositionMilli.Text = PositionMilli
        lblDramaViewMP3PositionMilli.Text = PositionMilli
        lbleditPositionMilli.Text = PositionMilli


        If MusicCues(Qindex).SongChangesDict.Count > 0 Then
            ' # testing
            Dim SongDictSorted1 = From entry In MusicCues(Qindex).SongChangesDict Order By entry.Value Select entry
            'Dim I As Integer = 0
            'Do Until I >= SongDictSorted1.Count
            '    Dim newrow As New ListViewItem
            '    newrow.Text = SongDictSorted1(I).Value
            '    newrow.SubItems.Add(SongDictSorted1(I).Key.SceneName)
            '    newrow.SubItems.Add(SongDictSorted1(I).Key.TimeToGoUp)
            '    newrow.SubItems.Add(SongDictSorted1(I).Key.TimeToGoDown)
            '    lstMusicSongChanges1.Items.Add(newrow)
            '    lstPresetsSongChanges1.Items.Add(newrow.Clone)
            '    lstDramaViewSongChanges1.Items.Add(newrow.Clone)
            '    I += 1
            'Loop
            '' / testing

            Dim IsongChange As Integer = 0
            Do Until IsongChange >= MusicCues(Qindex).SongChangesDict.Count
                'CurrentSongChangeIndex
                Dim dochange As Boolean = False
                If IsongChange = MusicCues(Qindex).SongChangesDict.Count - 1 Then
                    dochange = True
                ElseIf PositionMilli < SongDictSorted1(IsongChange + 1).Key.TimeCode Then
                    dochange = True
                End If
                If PositionMilli >= SongDictSorted1(IsongChange).Key.TimeCode Then
                    If dochange = True Then
                        If CurrentSongChangeIndex = IsongChange Then Exit Do 'Already on it
                        ' scene should be up to here
                        If CurrentSongChangeIndex = -1 Then 'first change of song
                            cmdPresetsBlackoutAllInstant_Click(Nothing, Nothing)
                        Else
                            If SongDictSorted1(CurrentSongChangeIndex).Key.TimeToGoDown = 0 Then
                                SceneData(SongDictSorted1(CurrentSongChangeIndex).Key.SceneIndex).MasterValue = 0
                                StartChannelTimers(SongDictSorted1(CurrentSongChangeIndex).Key.SceneIndex, False)
                                UpdatePresetControls(SongDictSorted1(CurrentSongChangeIndex).Key.SceneIndex)
                            Else
                                SceneData(SongDictSorted1(CurrentSongChangeIndex).Key.SceneIndex).Automation.tmrDirection = "Down"
                                SceneData(SongDictSorted1(CurrentSongChangeIndex).Key.SceneIndex).Automation.IntervalSteps = SceneData(SongDictSorted1(CurrentSongChangeIndex).Key.SceneIndex).Automation.Max / (SongDictSorted1(CurrentSongChangeIndex).Key.TimeToGoDown / SceneData(SongDictSorted1(CurrentSongChangeIndex).Key.SceneIndex).Automation.tTimer.Interval)
                                SceneData(SongDictSorted1(CurrentSongChangeIndex).Key.SceneIndex).Automation.tTimer.Start()
                            End If
                        End If
                        If SongDictSorted1(IsongChange).Key.TimeToGoUp = 0 Then
                            SceneData(SongDictSorted1(IsongChange).Key.SceneIndex).MasterValue = 100
                            If CurrentSongChangeIndex >= 0 Then StartChannelTimers(SongDictSorted1(CurrentSongChangeIndex).Key.SceneIndex, True)
                            UpdatePresetControls(SongDictSorted1(IsongChange).Key.SceneIndex)
                        Else
                            SceneData(SongDictSorted1(IsongChange).Key.SceneIndex).Automation.tmrDirection = "Up"
                            SceneData(SongDictSorted1(IsongChange).Key.SceneIndex).Automation.IntervalSteps = SceneData(SongDictSorted1(IsongChange).Key.SceneIndex).Automation.Max / (SongDictSorted1(IsongChange).Key.TimeToGoUp / SceneData(SongDictSorted1(IsongChange).Key.SceneIndex).Automation.tTimer.Interval)
                            SceneData(SongDictSorted1(IsongChange).Key.SceneIndex).Automation.tTimer.Start()
                        End If
                        CurrentSongChangeIndex = IsongChange
                        lstPresetsSongChanges1.Items(CurrentSongChangeIndex).BackColor = lblSongChangeColour.BackColor
                        lstMusicSongChanges1.Items(CurrentSongChangeIndex).BackColor = lblSongChangeColour.BackColor
                        lstDramaViewSongChanges1.Items(CurrentSongChangeIndex).BackColor = lblSongChangeColour.BackColor
                        Exit Do

                    End If
                End If
                IsongChange += 1
            Loop

        End If

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

        Dim Qindex As Integer = GetMusicCueIndex(lstPresetsSongs2.SelectedItem)

        Dim PositionMilli As Double = 0 ' Math.Round(Player.controls.currentPosition, 2)
        If MusicCues(Qindex).IsMP3 = True Then
            lblPresetsMP3Duration2.Text = AudioRun.TotalTime(MusicCues(Qindex).SongFileName) 'MusicCues(Qindex).AudioReader.TotalTime.ToString("mm\:ss")
            lblPresetsMP3Position2.Text = AudioRun.CurrentPosition(MusicCues(Qindex).SongFileName) ' MusicCues(Qindex).AudioReader.CurrentTime.ToString("mm\:ss")
            PositionMilli = AudioRun.CurrentPosition(MusicCues(Qindex).SongFileName, True) 'MusicCues(Qindex).AudioReader.CurrentTime.ToString("ss\.ff")


            'lblPresetsMP3Duration2.Text = MusicCues(Qindex).mp3Reader.TotalTime.ToString("mm\:ss")
            lblMusicMP3Duration2.Text = lblPresetsMP3Duration2.Text
            lblDramaViewMP3Duration2.Text = lblPresetsMP3Duration2.Text

            'lblPresetsMP3Position2.Text = MusicCues(Qindex).mp3Reader.CurrentTime.ToString("mm\:ss")
            lblMusicMP3Position2.Text = lblPresetsMP3Position2.Text
            lblDramaViewMP3Position2.Text = lblPresetsMP3Position2.Text

            'trkPresetsVolume2.Value = MusicCues(Qindex).waveOut.Volume
            'trkMusicVolume2.Value = trkPresetsVolume2.Value
            'trkDramaViewVolume2.Value = trkPresetsVolume2.Value

            'PositionMilli = MusicCues(Qindex).mp3Reader.CurrentTime.ToString("ss\.ff")
        ElseIf MusicCues(Qindex).IsSCS = True Then

            lblPresetsMP3Duration2.Text = MusicCues(Qindex).SCSinfo.Length
            lblMusicMP3Duration2.Text = lblPresetsMP3Duration2.Text
            lblDramaViewMP3Duration2.Text = lblPresetsMP3Duration2.Text

            lblPresetsMP3Position2.Text = MusicCues(Qindex).SCSinfo.swElapsed.Elapsed.ToString("mm\:ss")
            lblMusicMP3Position2.Text = lblPresetsMP3Position2.Text
            lblDramaViewMP3Position2.Text = lblPresetsMP3Position2.Text

            PositionMilli = MusicCues(Qindex).SCSinfo.swElapsed.Elapsed.TotalSeconds

        End If

        lblPresetsMP3PositionMilli2.Text = PositionMilli
        lblMusicMP3PositionMilli2.Text = PositionMilli
        lblDramaViewMP3PositionMilli2.Text = PositionMilli

        If MusicCues(Qindex).SongChangesDict.Count > 0 Then
            ' # testing
            Dim SongDictSorted2 = From entry In MusicCues(Qindex).SongChangesDict Order By entry.Value Select entry
            'Dim I As Integer = 0
            'Do Until I >= SongDictSorted1.Count
            '    Dim newrow As New ListViewItem
            '    newrow.Text = SongDictSorted1(I).Value
            '    newrow.SubItems.Add(SongDictSorted1(I).Key.SceneName)
            '    newrow.SubItems.Add(SongDictSorted1(I).Key.TimeToGoUp)
            '    newrow.SubItems.Add(SongDictSorted1(I).Key.TimeToGoDown)
            '    lstMusicSongChanges1.Items.Add(newrow)
            '    lstPresetsSongChanges1.Items.Add(newrow.Clone)
            '    lstDramaViewSongChanges1.Items.Add(newrow.Clone)
            '    I += 1
            'Loop
            '' / testing

            Dim IsongChange As Integer = 0
            Do Until IsongChange >= MusicCues(Qindex).SongChangesDict.Count
                'CurrentSongChangeIndex
                Dim dochange As Boolean = False
                If IsongChange = MusicCues(Qindex).SongChangesDict.Count - 1 Then
                    dochange = True
                ElseIf PositionMilli < SongDictSorted2(IsongChange + 1).Key.TimeCode Then
                    dochange = True
                End If
                If PositionMilli >= SongDictSorted2(IsongChange).Key.TimeCode Then
                    If dochange = True Then
                        If CurrentSongChangeIndex = IsongChange Then Exit Do 'Already on it
                        ' scene should be up to here
                        If CurrentSongChangeIndex = -1 Then 'first change of song
                            cmdPresetsBlackoutAllInstant_Click(Nothing, Nothing)
                        Else
                            If SongDictSorted2(CurrentSongChangeIndex).Key.TimeToGoDown = 0 Then
                                SceneData(SongDictSorted2(CurrentSongChangeIndex).Key.SceneIndex).MasterValue = 0
                                StartChannelTimers(SongDictSorted2(CurrentSongChangeIndex).Key.SceneIndex, False)
                                UpdatePresetControls(SongDictSorted2(CurrentSongChangeIndex).Key.SceneIndex)
                            Else
                                SceneData(SongDictSorted2(CurrentSongChangeIndex).Key.SceneIndex).Automation.tmrDirection = "Down"
                                SceneData(SongDictSorted2(CurrentSongChangeIndex).Key.SceneIndex).Automation.IntervalSteps = SceneData(SongDictSorted2(CurrentSongChangeIndex).Key.SceneIndex).Automation.Max / (SongDictSorted2(CurrentSongChangeIndex).Key.TimeToGoDown / SceneData(SongDictSorted2(CurrentSongChangeIndex).Key.SceneIndex).Automation.tTimer.Interval)
                                SceneData(SongDictSorted2(CurrentSongChangeIndex).Key.SceneIndex).Automation.tTimer.Start()
                            End If
                        End If
                        If SongDictSorted2(IsongChange).Key.TimeToGoUp = 0 Then
                            SceneData(SongDictSorted2(IsongChange).Key.SceneIndex).MasterValue = 100
                            If CurrentSongChangeIndex >= 0 Then StartChannelTimers(SongDictSorted2(CurrentSongChangeIndex).Key.SceneIndex, True)
                            UpdatePresetControls(SongDictSorted2(IsongChange).Key.SceneIndex)
                        Else
                            SceneData(SongDictSorted2(IsongChange).Key.SceneIndex).Automation.tmrDirection = "Up"
                            SceneData(SongDictSorted2(IsongChange).Key.SceneIndex).Automation.IntervalSteps = SceneData(SongDictSorted2(IsongChange).Key.SceneIndex).Automation.Max / (SongDictSorted2(IsongChange).Key.TimeToGoUp / SceneData(SongDictSorted2(IsongChange).Key.SceneIndex).Automation.tTimer.Interval)
                            SceneData(SongDictSorted2(IsongChange).Key.SceneIndex).Automation.tTimer.Start()
                        End If
                        CurrentSongChangeIndex = IsongChange
                        lstPresetsSongChanges1.Items(CurrentSongChangeIndex).BackColor = lblSongChangeColour.BackColor
                        lstMusicSongChanges1.Items(CurrentSongChangeIndex).BackColor = lblSongChangeColour.BackColor
                        lstDramaViewSongChanges1.Items(CurrentSongChangeIndex).BackColor = lblSongChangeColour.BackColor
                        Exit Do

                    End If
                End If
                IsongChange += 1
            Loop

        End If

        'tmrMP3.Interval = 10
        tmrchangedmp32 = False

    End Sub

    Public Sub UpdatePresetControls(ByVal SceneIndex As Integer) 'ByVal Value As Integer, 
        Dim I As Integer = 1
        PresetVisualUpdate = True
        Do Until I >= PresetFaders.Length
            'If SceneData(SceneIndex).SceneName = "" Then
            '    I = SceneIndex
            'End If
            If Not PresetFaders(I).cSceneControl Is Nothing Then
                If PresetFaders(I).cSceneControl.SceneIndex = SceneIndex Then

                    PresetFaders(I).cSceneControl.cTxtVal.Text = Math.Round(SceneData(SceneIndex).MasterValue, 0)
                    PresetFaders(I).cSceneControl.vScroll.Value = Val(PresetFaders(I).cSceneControl.cTxtVal.Text)

                    If SceneData(SceneIndex).MasterValue = 0 Then
                        PresetFaders(I).cSceneControl.cBlackout.BackColor = lblSceneBlackoutColour.BackColor
                        PresetFaders(I).cSceneControl.cFull.BackColor = Color.Black
                    ElseIf SceneData(SceneIndex).MasterValue = 100 Then
                        PresetFaders(I).cSceneControl.cBlackout.BackColor = Color.Black
                        PresetFaders(I).cSceneControl.cFull.BackColor = lblSceneUpColour.BackColor
                    Else

                        If SceneData(SceneIndex).Automation.tTimer.Enabled = True And SceneData(SceneIndex).Automation.tmrDirection = "Up" Then
                            PresetFaders(I).cSceneControl.cBlackout.BackColor = Color.Black
                            PresetFaders(I).cSceneControl.cFull.BackColor = ControlPaint.Light(lblSceneUpColour.BackColor)
                        ElseIf SceneData(SceneIndex).Automation.tTimer.Enabled = True And SceneData(SceneIndex).Automation.tmrDirection = "Down" Then
                            PresetFaders(I).cSceneControl.cBlackout.BackColor = ControlPaint.LightLight(lblSceneBlackoutColour.BackColor)
                            PresetFaders(I).cSceneControl.cFull.BackColor = lblSceneUpColour.BackColor

                        End If

                    End If
                    Exit Do
                    'End If
                    'End If
                End If
            End If
            I += 1
        Loop
        PresetVisualUpdate = False
    End Sub

    Private Sub cmdPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPresetsPlay.Click, cmdEditPlay.Click, cmdDramaViewPlay.Click, cmdMusicPlay.Click
        'Dim iSelectIndex As String = sender.name
        If lstPresetsSongs.SelectedIndex = -1 Then Exit Sub
        'lstPresetsSongs.SelectedIndex = iSelectIndex
        'lstMusicSongs.SelectedIndex = iSelectIndex
        'lstDramaViewSongs.SelectedIndex = iSelectIndex
        Dim Qindex As Integer = GetMusicCueIndex(lstPresetsSongs.SelectedItem)


        If cmdPresetsPlay.Text = "Play" Then


            If MusicCues(Qindex).IsMP3 = True Then
                AudioRun.Volume = trkMusicVolume.Value
                AudioRun.mPlay(MusicCues(Qindex).SongFileName)





            ElseIf MusicCues(Qindex).IsSCS = True Then
                Dim OSCmessage = New SharpOSC.OscMessage("/cue/go ,s " & MusicCues(Qindex).SCSinfo.Qname)
                Dim sendOSC = New SharpOSC.UDPSender(SCSIPaddress, SCSPort)
                sendOSC.Send(OSCmessage)

                MusicCues(Qindex).SCSinfo.swElapsed.Start()




            End If

            tmrMP3.Interval = 50
            'frmMain.tmrMP3.Start()
            'frmMain.updatePlayer()


            If lstPresetsSongChanges1.Items.Count > 0 Then
                'Dim a() As String = Split(lstPresetsSongChanges.Items.Item(0), "|")
                CurrentSongChangeIndex = -1
                lstPresetsSongChanges1.SelectedIndices.Clear()
                lstMusicSongChanges1.SelectedIndices.Clear()
                lstDramaViewSongChanges1.SelectedIndices.Clear()
            End If

            cmdPresetsPlay.Text = "Pause"
            cmdMusicPlay.Text = "Pause"
            cmdEditPlay.Text = "Pause"
            cmdDramaViewPlay.Text = "Pause"

            'lstPresetsSongs.Enabled = False
            'lstMusicSongs.Enabled = False
            'lstDramaViewSongs.Enabled = False
            Exit Sub
        ElseIf cmdPresetsPlay.Text = "Pause" Then

            If MusicCues(Qindex).IsMP3 = True Then
                AudioRun.mPause(MusicCues(Qindex).SongFileName)


            ElseIf MusicCues(Qindex).IsSCS = True Then

                Dim OSCmessage = New SharpOSC.OscMessage("/cue/pauseresume ,s " & MusicCues(Qindex).SCSinfo.Qname)
                Dim sendOSC = New SharpOSC.UDPSender(SCSIPaddress, SCSPort)
                sendOSC.Send(OSCmessage)

                MusicCues(Qindex).SCSinfo.swElapsed.Stop()

            End If
            '            tmrMP3.Enabled = False

            cmdPresetsPlay.Text = "Resume"
            cmdMusicPlay.Text = "Resume"
            cmdEditPlay.Text = "Resume"
            cmdDramaViewPlay.Text = "Resume"
            Exit Sub
        ElseIf cmdPresetsPlay.Text = "Resume" Then

            If MusicCues(Qindex).IsMP3 = True Then
                AudioRun.mResume(MusicCues(Qindex).SongFileName)

            ElseIf MusicCues(Qindex).IsSCS = True Then

                Dim OSCmessage = New SharpOSC.OscMessage("/cue/pauseresume ,s " & MusicCues(Qindex).SCSinfo.Qname)
                Dim sendOSC = New SharpOSC.UDPSender(SCSIPaddress, SCSPort)
                sendOSC.Send(OSCmessage)

                MusicCues(Qindex).SCSinfo.swElapsed.Start()


            End If

            '            tmrMP3.Start()

            cmdPresetsPlay.Text = "Pause"
            cmdMusicPlay.Text = "Pause"
            cmdEditPlay.Text = "Pause"
            cmdDramaViewPlay.Text = "Pause"

            Exit Sub
        End If
    End Sub

    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPresetsStop.Click, cmdEditStop.Click, cmdDramaViewStop.Click, cmdMusicStop.Click

        Dim Qindex As Integer = GetMusicCueIndex(lstPresetsSongs.SelectedItem)
        If MusicCues(Qindex).IsMP3 = True Then

            AudioRun.mStop(MusicCues(Qindex).SongFileName)

        ElseIf MusicCues(Qindex).IsSCS = True Then
            MusicCues(Qindex).SCSinfo.swElapsed.Reset()

            Dim OSCmessage = New SharpOSC.OscMessage("/cue/stop ,s " & MusicCues(Qindex).SCSinfo.Qname)
            Dim sendOSC = New SharpOSC.UDPSender(SCSIPaddress, SCSPort)
            sendOSC.Send(OSCmessage)

        End If

        'Player.controls.stop()
        'tmrMP3.Stop()
        CurrentSongChangeIndex = -1
        cmdPresetsPlay.Text = "Play"
        cmdEditPlay.Text = "Play"
        cmdDramaViewPlay.Text = "Play"
        cmdMusicPlay.Text = "Play"

        ResetSongChangeBackColours()

        lstPresetsSongs.Enabled = True
        lstMusicSongs.Enabled = True
        lstDramaViewSongs.Enabled = True
    End Sub

    Private Sub ResetSongChangeBackColours()
        For Each sitem As ListViewItem In lstPresetsSongChanges1.Items
            sitem.BackColor = Color.Transparent
        Next
        For Each sitem As ListViewItem In lstPresetsSongChanges2.Items
            sitem.BackColor = Color.Transparent
        Next

        For Each sitem As ListViewItem In lstMusicSongChanges1.Items
            sitem.BackColor = Color.Transparent
        Next
        For Each sitem As ListViewItem In lstMusicSongChanges2.Items
            sitem.BackColor = Color.Transparent
        Next

        For Each sitem As ListViewItem In lstDramaViewSongChanges1.Items
            sitem.BackColor = Color.Transparent
        Next
        For Each sitem As ListViewItem In lstDramaViewSongChanges2.Items
            sitem.BackColor = Color.Transparent
        Next
    End Sub

    Private Sub cmdSkip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPresetsSkip.Click, cmdDramaViewSkip.Click, cmdMusicSkip.Click
        If lstPresetsSongs.Items.Count >= (lstPresetsSongs.SelectedIndex + 1) Then
            Dim Qindex As Integer = GetMusicCueIndex(lstPresetsSongs.SelectedItem)
            If MusicCues(Qindex).IsMP3 = True Then
                AudioRun.mStop(MusicCues(Qindex).SongFileName)

            ElseIf MusicCues(Qindex).IsSCS = True Then

                Dim OSCmessage = New SharpOSC.OscMessage("/cue/stop ,s " & MusicCues(Qindex).SCSinfo.Qname)
                Dim sendOSC = New SharpOSC.UDPSender(SCSIPaddress, SCSPort)
                sendOSC.Send(OSCmessage)

                MusicCues(Qindex).SCSinfo.swElapsed.Stop()
            End If

            'Player.controls.stop()
            'tmrMP3.Stop()
            cmdPresetsPlay.Text = "Play"
            cmdEditPlay.Text = "Play"
            cmdMusicPlay.Text = "Play"
            cmdDramaViewPlay.Text = "Play"
            lstPresetsSongs.Enabled = True

            If lstPresetsSongs.Items.Count > lstPresetsSongs.SelectedIndex + 1 Then
                lstPresetsSongs.SelectedIndex += 1
                cmdPlay_Click(sender, e)
            Else
                cmdStop_Click(sender, e)
            End If

        End If
    End Sub

    Private Sub trkVolume_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trkPresetsVolume.Scroll, trkDramaViewVolume.Scroll, trkMusicVolume.Scroll
        Dim Qindex As Integer = GetMusicCueIndex(lstPresetsSongs.SelectedItem)
        Dim vol As Integer = sender.Value
        If MusicCues(Qindex).IsMP3 = True Then
            'MusicCues(Qindex).waveOut.Volume = (sender.Value / 100)
            'MusicCues(Qindex).AudioReader.Volume = (sender.Value / 100)
            AudioRun.Volume = trkMusicVolume.Value
        Else
        End If

        'Player.settings.volume = sender.Value
        trkPresetsVolume.Value = vol 'MusicCues(Qindex).waveOut.Volume * 100
        trkDramaViewVolume.Value = vol 'MusicCues(Qindex).waveOut.Volume * 100
        trkMusicVolume.Value = vol 'MusicCues(Qindex).waveOut.Volume * 100
    End Sub
    Private Sub cmdPlay2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPresetsPlay2.Click, cmdDramaViewPlay2.Click, cmdMusicPlay2.Click
        'Dim iSelectIndex As String = sender.name
        If lstPresetsSongs2.SelectedIndex = -1 Then Exit Sub
        'lstPresetsSongs.SelectedIndex = iSelectIndex
        'lstMusicSongs.SelectedIndex = iSelectIndex
        'lstDramaViewSongs.SelectedIndex = iSelectIndex
        Dim Qindex As Integer = GetMusicCueIndex(lstPresetsSongs2.SelectedItem)

        If cmdPresetsPlay2.Text = "Play" Then
            If MusicCues(Qindex).IsMP3 = True Then
                AudioRun.Volume = trkMusicVolume.Value
                AudioRun.mPlay(MusicCues(Qindex).SongFileName)

            ElseIf MusicCues(Qindex).IsSCS = True Then

                Dim OSCmessage = New SharpOSC.OscMessage("/cue/go ,s " & MusicCues(Qindex).SCSinfo.Qname)
                Dim sendOSC = New SharpOSC.UDPSender(SCSIPaddress, SCSPort)
                sendOSC.Send(OSCmessage)

                MusicCues(Qindex).SCSinfo.swElapsed.Start()

            End If
            'Player2.settings.volume = trkPresetsVolume2.Value


            'Player2.controls.play()

            If lstPresetsSongChanges2.Items.Count > 0 Then
                'Dim a() As String = Split(lstPresetsSongChanges2.Items(0).Text, "|")
                SongChangeIndexUpTo2 = -1
                lstPresetsSongChanges2.SelectedIndices.Clear()
                lstMusicSongChanges2.SelectedIndices.Clear()
                lstDramaViewSongChanges2.SelectedIndices.Clear()
            End If

            cmdPresetsPlay2.Text = "Pause"
            cmdMusicPlay2.Text = "Pause"
            cmdDramaViewPlay2.Text = "Pause"
            tmrMP32.Interval = 50
            tmrMP32.Start()
            tmrMP32_Tick(sender, e)
            lstPresetsSongs2.Enabled = False
            lstMusicSongs2.Enabled = False
            lstDramaViewSongs2.Enabled = False
            Exit Sub
        ElseIf cmdPresetsPlay2.Text = "Pause" Then
            'MP3.MP3Pause()
            If MusicCues(Qindex).IsMP3 = True Then
                AudioRun.mPause(MusicCues(Qindex).SongFileName)

            ElseIf MusicCues(Qindex).IsSCS = True Then

                Dim OSCmessage = New SharpOSC.OscMessage("/cue/pauseresume ,s " & MusicCues(Qindex).SCSinfo.Qname)
                Dim sendOSC = New SharpOSC.UDPSender(SCSIPaddress, SCSPort)
                sendOSC.Send(OSCmessage)

                MusicCues(Qindex).SCSinfo.swElapsed.Stop()

            End If
            'Player2.controls.pause()
            cmdPresetsPlay2.Text = "Resume"
            cmdMusicPlay2.Text = "Resume"
            cmdDramaViewPlay2.Text = "Resume"
            tmrMP32.Enabled = False
            Exit Sub
        ElseIf cmdPresetsPlay2.Text = "Resume" Then
            If MusicCues(Qindex).IsMP3 = True Then
                AudioRun.mResume(MusicCues(Qindex).SongFileName)
            ElseIf MusicCues(Qindex).IsSCS = True Then

                Dim OSCmessage = New SharpOSC.OscMessage("/cue/pauseresume ,s " & MusicCues(Qindex).SCSinfo.Qname)
                Dim sendOSC = New SharpOSC.UDPSender(SCSIPaddress, SCSPort)
                sendOSC.Send(OSCmessage)

                MusicCues(Qindex).SCSinfo.swElapsed.Start()
            End If
            'Player2.controls.play()
            cmdPresetsPlay2.Text = "Pause"
            cmdMusicPlay2.Text = "Pause"
            cmdDramaViewPlay2.Text = "Pause"
            'MP3.MP3Resume()
            tmrMP32.Start()
            Exit Sub
        End If
    End Sub

    Private Sub cmdStop2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPresetsStop2.Click, cmdDramaViewStop2.Click, cmdMusicStop2.Click
        'Player2.controls.stop()
        Dim Qindex As Integer = GetMusicCueIndex(lstPresetsSongs2.SelectedItem)
        If MusicCues(Qindex).IsMP3 = True Then
            AudioRun.mStop(MusicCues(Qindex).SongFileName)
        ElseIf MusicCues(Qindex).IsSCS = True Then
            MusicCues(Qindex).SCSinfo.swElapsed.Reset()

            Dim OSCmessage = New SharpOSC.OscMessage("/cue/stop ,s " & MusicCues(Qindex).SCSinfo.Qname)
            Dim sendOSC = New SharpOSC.UDPSender(SCSIPaddress, SCSPort)
            sendOSC.Send(OSCmessage)

        End If
        tmrMP32.Stop()
        cmdPresetsPlay2.Text = "Play"
        cmdDramaViewPlay2.Text = "Play"
        cmdMusicPlay2.Text = "Play"
        lstPresetsSongs2.Enabled = True
        lstMusicSongs2.Enabled = True
        lstDramaViewSongs2.Enabled = True
    End Sub

    Private Sub cmdSkip2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPresetsSkip2.Click, cmdDramaViewSkip2.Click, cmdMusicSkip2.Click
        If lstPresetsSongs2.Items.Count >= (lstPresetsSongs2.SelectedIndex + 1) Then
            Dim Qindex As Integer = GetMusicCueIndex(lstPresetsSongs2.SelectedItem)
            If MusicCues(Qindex).IsMP3 = True Then
                AudioRun.mStop(MusicCues(Qindex).SongFileName)
            ElseIf MusicCues(Qindex).IsSCS = True Then

                Dim OSCmessage = New SharpOSC.OscMessage("/cue/stop ,s " & MusicCues(Qindex).SCSinfo.Qname)
                Dim sendOSC = New SharpOSC.UDPSender(SCSIPaddress, SCSPort)
                sendOSC.Send(OSCmessage)

                MusicCues(Qindex).SCSinfo.swElapsed.Stop()
            End If
            'Player2.controls.stop()
            tmrMP32.Stop()
            cmdPresetsPlay2.Text = "Play"
            cmdMusicPlay2.Text = "Play"
            cmdDramaViewPlay2.Text = "Play"
            'lstPresetsSongs2.Enabled = True

            If lstPresetsSongs2.Items.Count > lstPresetsSongs2.SelectedIndex + 1 Then
                lstPresetsSongs2.SelectedIndex += 1
                cmdPlay2_Click(sender, e)
            Else
                cmdStop2_Click(sender, e)
            End If

        End If
    End Sub

    Private Sub trkVolume2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trkPresetsVolume2.Scroll, trkDramaViewVolume2.Scroll, trkMusicVolume2.Scroll
        Dim Qindex As Integer = GetMusicCueIndex(lstPresetsSongs2.SelectedItem)
        Dim vol As Integer = sender.Value
        If MusicCues(Qindex).IsMP3 = True Then
            'MusicCues(Qindex).waveOut.Volume = sender.Value
            AudioRun.Volume = trkMusicVolume.Value
        Else
        End If
        'Player2.settings.volume = sender.Value
        trkPresetsVolume2.Value = vol 'MusicCues(Qindex).waveOut.Volume
        trkDramaViewVolume2.Value = vol 'MusicCues(Qindex).waveOut.Volume
        trkMusicVolume2.Value = vol 'MusicCues(Qindex).waveOut.Volume
    End Sub

    Public Function GetSceneIndex(ByVal SceneName As String) As Integer
        Dim I As Integer = 1
        Do Until SceneData(I).SceneName = SceneName
            I += 1
            If I >= SceneData.Length Then
                I = -1
                Exit Do
            End If
        Loop
        Return I
    End Function

    Private Sub LoadMusicTracks()

        lstPresetsSongs.Items.Clear()
        lstPresetsSongs2.Items.Clear()
        lstMusicSongs.Items.Clear()
        lstMusicSongs2.Items.Clear()
        lstDramaViewSongs.Items.Clear()
        lstDramaViewSongs2.Items.Clear()

        Dim I1 As Integer = 0
        Do Until I1 >= MusicCues.Length
            MusicCues(I1).SongFileName = ""
            MusicCues(I1).IsMP3 = False
            MusicCues(I1).IsSCS = False
            MusicCues(I1).AsioOutIndex = 1
            MusicCues(I1).SongChangesDict = Nothing
            MusicCues(I1).SongChanges = Nothing
            I1 += 1
        Loop
        AudioRun.ClearTracks()

        'lstPresetsSongChanges.Items.Clear()
        'lstPresetsSongChanges2.Items.Clear()
        'lstMusicSongChanges.Items.Clear()
        'lstMusicSongChanges2.Items.Clear()
        'lstDramaViewSongChanges.Items.Clear()
        'lstDramaViewSongChanges.Items.Clear()

        Dim I As Integer = 0
        Dim MusicMP3InBank() As String = Directory.GetFiles(Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\", "*.mp3")
        Do Until I >= MusicMP3InBank.Length
            'Dim a() As String = Split(MusicMP3InBank(I), "\")
            Dim songname As String = Path.GetFileNameWithoutExtension(MusicMP3InBank(I))
            If File.Exists(Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & songname & " resampled.mp3") = True Then
                ' A resampled file exists
                songname = songname & " resampled"
            End If
            If Microsoft.VisualBasic.Right(MusicMP3InBank(I), 13) = "resampled.mp3" And File.Exists(Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & Mid(songname, 1, songname.Length - 9) & ".mp3") = True Then
                ' Is a resampled file and original still exists
                GoTo skipme
            End If

            lstPresetsSongs.Items.Add(songname)
            lstPresetsSongs2.Items.Add(songname)
            lstMusicSongs.Items.Add(songname)
            lstMusicSongs2.Items.Add(songname)
            lstDramaViewSongs.Items.Add(songname)
            lstDramaViewSongs2.Items.Add(songname)

            MusicCues(I).SongFileName = songname
            MusicCues(I).IsMP3 = True
            MusicCues(I).IsSCS = False
            MusicCues(I).AsioOutIndex = 1
            'MusicCues(I).vlcMedia = New Media(VLCmain, New Uri(MusicMP3InBank(I)))
            'MusicCues(I).vlcPlayer = New MediaPlayer(MusicCues(I).vlcMedia)
            'MusicCues(I).vlcPlayer.Stop()
            'MusicCues(I).mp3filestream = New MemoryStream(MusicMP3InBank(I))

            AudioRun.PrepareTrack(MusicMP3InBank(I))
            'MusicCues(I).mp3Reader = New Mp3FileReader(MusicMP3InBank(I))
            'MusicCues(I).waveOut = New WaveOut
            'MusicCues(I).waveOut.DesiredLatency = AudioLatency
            'MusicCues(I).waveOut.Init(MusicCues(I).mp3Reader)

            'MusicCues(I).AudioReader = New AudioFileReader(MusicMP3InBank(I))


            MusicCues(I).SongChangesDict = New Dictionary(Of SongChangesStr, Double)

            ReDim MusicCues(I).SongChanges(200)
            LoadTrackChanges(I)
skipme:
            I += 1
        Loop
        Dim J As Integer = 0
        Dim MusicWAVInBank() As String = Directory.GetFiles(Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\", "*.wav")
        Do Until J >= MusicWAVInBank.Length
            'Dim a() As String = Split(MusicMP3InBank(I), "\")
            Dim songname As String = Path.GetFileNameWithoutExtension(MusicWAVInBank(J))


            lstPresetsSongs.Items.Add(songname)
            lstPresetsSongs2.Items.Add(songname)
            lstMusicSongs.Items.Add(songname)
            lstMusicSongs2.Items.Add(songname)
            lstDramaViewSongs.Items.Add(songname)
            lstDramaViewSongs2.Items.Add(songname)

            MusicCues(I).SongFileName = songname
            MusicCues(I).IsMP3 = True
            MusicCues(I).IsSCS = False
            MusicCues(I).AsioOutIndex = 1

            AudioRun.PrepareTrack(MusicWAVInBank(J))
            MusicCues(I).SongChangesDict = New Dictionary(Of SongChangesStr, Double)

            ReDim MusicCues(I).SongChanges(200)
            LoadTrackChanges(I)
            I += 1
            J += 1
        Loop

        'If ASIOMode = True Then
        '    AudioRun.SetupAsioOutputs()
        'End If

        J = 0
        Dim SCSInBank() As String = Directory.GetFiles(Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\", "*.scs")
        Do Until J >= SCSInBank.Length
            'Dim a() As String = Split(MusicMP3InBank(I), "\")
            Dim songname As String = Path.GetFileNameWithoutExtension(SCSInBank(J))



            lstPresetsSongs.Items.Add(songname)
            lstPresetsSongs2.Items.Add(songname)
            lstMusicSongs.Items.Add(songname)
            lstMusicSongs2.Items.Add(songname)
            lstDramaViewSongs.Items.Add(songname)
            lstDramaViewSongs2.Items.Add(songname)

            MusicCues(I).SongFileName = songname
            MusicCues(I).IsMP3 = False
            MusicCues(I).IsSCS = True
            'MusicCues(I).SCSinfo.SCStimer = New Windows.Forms.Timer
            MusicCues(I).SCSinfo.swElapsed = New Stopwatch
            'MusicCues(I).SCSinfo.SCStimer.Interval = 50

            MusicCues(I).SongChangesDict = New Dictionary(Of SongChangesStr, Double)

            FileOpen(1, SCSInBank(J), OpenMode.Input)
            Do Until EOF(1)
                Dim info() As String = Split(LineInput(1), "=")
                Select Case info(0)
                    Case "q"
                        MusicCues(I).SCSinfo.Qname = info(1)
                    Case "length"
                        MusicCues(I).SCSinfo.Length = Convert.ToDouble(info(1))

                End Select
            Loop
            FileClose(1)

            ReDim MusicCues(I).SongChanges(200)
            LoadTrackChanges(I)

            I += 1
            J += 1
        Loop


    End Sub

    Private Sub LoadTrackChanges(ByVal MusicCuesIndex As Integer)

        If File.Exists(Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & MusicCues(MusicCuesIndex).SongFileName & ".chg") = False Then
            Exit Sub
        End If
        'Dim Qindex As Integer = GetMusicCueIndex(lstPresetsSongs.SelectedItem)

        FileOpen(2, Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & MusicCues(MusicCuesIndex).SongFileName & ".chg", OpenMode.Input)

        Do Until EOF(2)
            Dim newline As String = LineInput(2)
            'SongDict1
            Dim b() As String = Split(newline, "|", 2)

            Dim NewSongChange As New SongChangesStr
            Dim a() As String = Split(newline, "|")
            NewSongChange.TimeCode = a(0)
            NewSongChange.SceneName = a(1)
            NewSongChange.SceneIndex = GetSceneIndex(a(1))
            If a.Length > 2 Then
                NewSongChange.TimeToGoUp = a(2)
                NewSongChange.TimeToGoDown = a(3)
            Else
                NewSongChange.TimeToGoUp = 0
                NewSongChange.TimeToGoDown = 0
            End If
            MusicCues(MusicCuesIndex).SongChangesDict.Add(NewSongChange, NewSongChange.TimeCode)
            'SongChanges1.Add(NewSongChange)

        Loop
        FileClose(2)
    End Sub
    Private Sub lstSongs_Changed(ByVal songname As String)

        Dim Qindex As Integer = GetMusicCueIndex(songname)

        lstPresetsSongChanges1.Items.Clear()
        lstMusicSongChanges1.Items.Clear()
        lstDramaViewSongChanges1.Items.Clear()

        Dim SongDictSorted1 = From entry In MusicCues(Qindex).SongChangesDict Order By entry.Value Select entry

        Dim I As Integer = 0
        Do Until I >= SongDictSorted1.Count
            Dim newrow As New ListViewItem
            newrow.Text = SongDictSorted1(I).Value
            newrow.SubItems.Add(SongDictSorted1(I).Key.SceneName)
            newrow.SubItems.Add(SongDictSorted1(I).Key.TimeToGoUp)
            newrow.SubItems.Add(SongDictSorted1(I).Key.TimeToGoDown)
            lstMusicSongChanges1.Items.Add(newrow)
            lstPresetsSongChanges1.Items.Add(newrow.Clone)
            lstDramaViewSongChanges1.Items.Add(newrow.Clone)
            I += 1
        Loop


AfterChgFile:


        If MusicCues(Qindex).IsMP3 = True Then

            lblPresetsMP3Duration.Text = AudioRun.TotalTime(MusicCues(Qindex).SongFileName)
            lblMusicMP3Duration.Text = lblPresetsMP3Duration.Text
            lblDramaViewMP3Duration.Text = lblPresetsMP3Duration.Text
        Else
            lblPresetsMP3Duration.Text = MusicCues(Qindex).SCSinfo.Length
            lblMusicMP3Duration.Text = MusicCues(Qindex).SCSinfo.Length
            lblDramaViewMP3Duration.Text = MusicCues(Qindex).SCSinfo.Length
        End If
    End Sub
    Dim OtherIndexChanged As Boolean = False
    Private Sub lstPresetsSongs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstPresetsSongs.SelectedIndexChanged
        If sender.SelectedIndex = -1 Then Exit Sub
        If OtherIndexChanged = True Then Exit Sub
        OtherIndexChanged = True

        lstMusicSongs.SelectedIndex = lstPresetsSongs.SelectedIndex
        lstDramaViewSongs.SelectedIndex = lstPresetsSongs.SelectedIndex
        lstSongs_Changed(lstPresetsSongs.SelectedItem)
        OtherIndexChanged = False
    End Sub
    Private Sub lstMusicSongs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMusicSongs.SelectedIndexChanged
        If sender.SelectedIndex = -1 Then Exit Sub
        If OtherIndexChanged = True Then Exit Sub
        OtherIndexChanged = True

        lstPresetsSongs.SelectedIndex = lstMusicSongs.SelectedIndex
        lstDramaViewSongs.SelectedIndex = lstMusicSongs.SelectedIndex
        lstSongs_Changed(lstMusicSongs.SelectedItem)
        OtherIndexChanged = False
    End Sub
    Private Sub lstDramaViewSongs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstDramaViewSongs.SelectedIndexChanged
        If sender.SelectedIndex = -1 Then Exit Sub
        If OtherIndexChanged = True Then Exit Sub
        OtherIndexChanged = True

        lstPresetsSongs.SelectedIndex = lstDramaViewSongs.SelectedIndex
        lstMusicSongs.SelectedIndex = lstDramaViewSongs.SelectedIndex
        lstSongs_Changed(lstDramaViewSongs.SelectedItem)
        OtherIndexChanged = False
    End Sub

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

    Private Sub lstSongs2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstPresetsSongs2.SelectedIndexChanged, lstMusicSongs2.SelectedIndexChanged, lstDramaViewSongs2.SelectedIndexChanged
        If sender.SelectedIndex = -1 Then Exit Sub
        Dim iSelectIndex = sender.selectedindex
        lstPresetsSongs2.SelectedIndex = iSelectIndex
        lstMusicSongs2.SelectedIndex = iSelectIndex
        lstDramaViewSongs2.SelectedIndex = iSelectIndex

        lstPresetsSongChanges2.Items.Clear()
        lstMusicSongChanges2.Items.Clear()
        lstDramaViewSongChanges2.Items.Clear()

        Dim Qindex As Integer = GetMusicCueIndex(lstPresetsSongs2.SelectedItem)

        'If File.Exists(Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & lstPresetsSongs2.SelectedItem & ".chg") = False Then GoTo AfterChgFile

        'FileOpen(1, Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & lstPresetsSongs2.SelectedItem & ".chg", OpenMode.Input)
        'Do Until EOF(1)
        '    Dim newline As String = LineInput(1)

        '    Dim b() As String = Split(newline, "|", 2)

        '    'lstPresetsSongChanges2.Items.Add(newline)
        '    'lstMusicSongChanges2.Items.Add(newline)
        '    'lstDramaViewSongChanges2.Items.Add(newline)

        '    Dim NewSongChange As New SongChangesStr
        '    Dim a() As String = Split(newline, "|")
        '    NewSongChange.TimeCode = a(0)
        '    NewSongChange.SceneName = a(1)
        '    NewSongChange.SceneIndex = GetSceneIndex(a(1))
        '    If a.Length > 2 Then
        '        NewSongChange.TimeToGoUp = a(2)
        '        NewSongChange.TimeToGoDown = a(3)
        '    Else
        '        NewSongChange.TimeToGoUp = 0
        '        NewSongChange.TimeToGoDown = 0
        '    End If
        '    SongDict2.Add(NewSongChange, NewSongChange.TimeCode)

        'Loop

        ''Do Until EOF(1)
        ''    Dim a() As String = Split(LineInput(1), "|") 'time|Preset
        ''    Mp3Changes(I).Time = a(0)
        ''    Mp3Changes(I).PresetName = a(1)
        ''    I += 1
        ''Loop
        'FileClose(1)

        ' # testing
        Dim SongDictSorted2 = From entry In MusicCues(Qindex).SongChangesDict Order By entry.Value Select entry
        Dim I As Integer = 0
        Do Until I >= SongDictSorted2.Count
            Dim newrow As New ListViewItem
            newrow.Text = SongDictSorted2(I).Value
            newrow.SubItems.Add(SongDictSorted2(I).Key.SceneName)

            lstPresetsSongChanges2.Items.Add(newrow)
            lstMusicSongChanges2.Items.Add(newrow.Clone)
            lstDramaViewSongChanges2.Items.Add(newrow.Clone)
            I += 1
        Loop
        ' / testing

AfterChgFile:

        'Make sure no mp3 is playing
        'MP3.MP3Stop()
        'Player.controls.stop()
        'load mp3 and play


        'Player2.URL = Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & lstPresetsSongs2.SelectedItem & ".mp3"

        If MusicCues(Qindex).IsMP3 = True Then

            lblPresetsMP3Duration2.Text = AudioRun.TotalTime(MusicCues(Qindex).SongFileName)
            lblMusicMP3Duration2.Text = lblPresetsMP3Duration2.Text
            lblDramaViewMP3Duration2.Text = lblPresetsMP3Duration2.Text
        Else
            lblPresetsMP3Duration2.Text = MusicCues(Qindex).SCSinfo.Length
            lblMusicMP3Duration2.Text = MusicCues(Qindex).SCSinfo.Length
            lblDramaViewMP3Duration2.Text = MusicCues(Qindex).SCSinfo.Length
        End If
    End Sub
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
        'Return CInt(Math.Ceiling(Rnd() * Max))
    End Function

#End Region

#Region "Banks"
    Private Sub cmdBankNew_Click(sender As Object, e As EventArgs) Handles cmdBankNew.Click
        Dim s As String = InputBox("Name of new bank:")
        If s = "" Then Exit Sub
        Directory.CreateDirectory(Application.StartupPath & "\Save Files\" & s)
        File.Copy(Application.StartupPath & "\0 Blackout.dmr", Application.StartupPath & "\Save Files\" & s & "\0 Blackout.dmr")
        LoadBanksFromFile()
    End Sub

    Private Sub cmdBankRename_Click(sender As Object, e As EventArgs) Handles cmdBankRename.Click
        If lstBanks.SelectedIndex = -1 Then Exit Sub
        Dim s As String = InputBox("Name of new bank:")
        If s = "" Then Exit Sub
        Directory.Move(Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem, Application.StartupPath & "\Save Files\" & s)
        LoadBanksFromFile()
    End Sub

    Private Sub cmd4KSize_Click(sender As Object, e As EventArgs) Handles cmd4KSize.Click
        frmMain.Size = New Point(3840, 2160)
    End Sub

    Private Sub lstBanks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstBanks.SelectedIndexChanged
        If formopened = False Then Exit Sub

        'Dim I As Integer = 1
        'Do Until I >= SceneData.Length
        '    Dim I1 As Integer = 1

        '    SceneData(I).SceneName = ""
        '    SceneData(I).MasterValue = 0
        '    SceneData(I).Automation.TimeBetweenMinAndMax = 1000
        '    SceneData(I).Automation.Max = 100
        '    SceneData(I).Automation.Min = 0

        '    'SceneData(I).ChannelValues = Nothing

        '    'Do Until I1 >= 512
        '    '    SceneData(I).ChannelValues = Nothing
        '    '    With SceneData(I).ChannelValues(I1)
        '    '        .Automation.tTimer = New Windows.Forms.Timer
        '    '        .Value = 0
        '    '        .Automation.tTimer.Interval = 10
        '    '        .Automation.tTimer.Enabled = False
        '    '        .Automation.Max = 255
        '    '        .Automation.Min = 0
        '    '        .Automation.TimeBetweenMinAndMax = 1000
        '    '        .Automation.randomstart = False
        '    '    End With
        '    '    I1 += 1
        '    'Loop
        '    I += 1
        'Loop
        BankChanged = True

        LoadScenesFromFile()
        LoadMusicTracks()


        cmdPresetP1.BackColor = Color.Red
        cmdPresetP2.BackColor = controlcolour
        cmdPresetP3.BackColor = controlcolour
        cmdPresetP4.BackColor = controlcolour
        cmdPresetP5.BackColor = controlcolour
        cmdPresetP6.BackColor = controlcolour

        cmdPresetP1.ForeColor = Color.White
        cmdPresetP2.ForeColor = Color.Black
        cmdPresetP3.ForeColor = Color.Black
        cmdPresetP4.ForeColor = Color.Black
        cmdPresetP5.ForeColor = Color.Black
        cmdPresetP6.ForeColor = Color.Black

        RenamePresetFaderControls()

        BankChanged = False
        SaveSettingsToFile()
    End Sub






#End Region

    Private Sub FormMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing, Me.FormClosing
        ClosingNow = True
        AudioRun.DisposeAsio()
        ' Form is closing, so shutdown player
        'Player.close()
        'Player2.close()
        If Testmode = False Then
            EnttecOpenDMX.OpenDMX.done = True
        End If

        'If tChannelsMultipleThreads = False Then
        '    tChannels(1).Abort()
        'Else
        '    Dim I As Integer = 0
        '    Do Until I >= 512
        '        tChannels(I).Abort()
        '        I += 1
        '    Loop
        'End If
        closethreads = True
        If Not tTouchPadLoad Is Nothing Then tTouchPadLoad.Abort()
        Dim chanLocation As Point = frmChannels.Location
        Dim chanstate As FormWindowState = frmChannels.WindowState
        FileOpen(7, Application.StartupPath & "\WindowLocations.ini", OpenMode.Output)
        PrintLine(7, chanLocation.X.ToString)
        PrintLine(7, chanLocation.Y.ToString)
        PrintLine(7, chanstate.ToString)
        FileClose(7)

        Application.Exit()

    End Sub

    Private Sub cmdOpenTouchpad_Click(sender As Object, e As EventArgs) Handles cmdOpenTouchpad.Click
        frmTouchPad.Show()
    End Sub


    Public Sub SaveScene(ByVal filename As String)
        'If PagingChanged = True Then Exit Sub
        If BankChanged = True Then Exit Sub

        Dim I1 As Integer = 1
        Dim SaveFileName As String = ""
        Do Until I1 >= SceneData.Length
            Dim a() As String = Split(filename, "| ")
            If a.Length > 1 Then
                If SceneData(I1).SceneName = a(1) Then
                    SaveFileName = a(1)
                    Exit Do
                End If
            ElseIf a.Length = 1 Then
                If SceneData(I1).SceneName = a(0) Then
                    SaveFileName = a(0)
                    Exit Do
                End If
            End If

            I1 += 1
        Loop
        If SceneData(I1).SceneName = "" Then Exit Sub

        FileOpen(1, Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & SaveFileName & ".dmr", OpenMode.Output)
        'PrintLine(1, "P|" & "0")
        PrintLine(1, "ChangeMS|" & SceneData(I1).Automation.TimeBetweenMinAndMax)  '(PresetIndex(cmbPresets.SelectedItem)).Automation.numChangeMS.Value)
        PrintLine(1, "LocIndex|" & SceneData(I1).LocIndex)
        PrintLine(1, "PageNo|" & SceneData(I1).PageNo)
        Dim I As Integer = 1
        Do Until I > numEndChannel.Value '1|v,0|tmr,100|timerenabled,false
            Dim chanline As String = I & "|"
            With SceneData(I1).ChannelValues(I)
                chanline &= "v," & .Value & "|"
                'chanline &= "tmr," & .Automation.tTimer.Interval & "|"
                chanline &= "TimerEnabled," & .Automation.RunTimer & "|"
                chanline &= "AutoTimeBetween," & .Automation.tTimer.Interval & "|"
                chanline &= "RandomStart," & .Automation.ProgressRandomTimed & "|"

                chanline &= "InOrder," & .Automation.ProgressInOrder & "|"
                chanline &= "RandomSound," & .Automation.ProgressSoundActivated & "|"
                chanline &= "SoundThreshold" & .Automation.SoundActivationThreshold & "|"
                chanline &= "IsLooped," & .Automation.ProgressLoop & "|"
                chanline &= "ProgressList"

                Dim iList As Integer = 0
                If Not .Automation.ProgressList Is Nothing Then
                    Do Until iList >= .Automation.ProgressList.Count
                        chanline &= "," & .Automation.ProgressList(iList)
                        iList += 1
                    Loop
                End If
            End With
            PrintLine(1, chanline)
            I += 1
        Loop
        FileClose(1)

    End Sub

    Private Sub lstDramaPresets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDramaPresets.SelectedIndexChanged
        'PresetControls(PresetIndex(lstPrsets.SelectedItem)).vtxtBox.Text = 100
        If lstDramaPresets.SelectedIndex = -1 Then Exit Sub
        If tmrchangedmp3 = True Then Exit Sub

        Dim I As Integer = 1
        Do Until I >= SceneData.Length
            If SceneData(I).MasterValue > 0 Then 'preset is above blackout
                If isDramaPresetSelected(I) = False Then
                    With SceneData(I)
                        .Automation.tmrDirection = "Down"
                        .Automation.IntervalSteps = 255 / (.Automation.TimeBetweenMinAndMax / .Automation.tTimer.Interval)
                        .Automation.tTimer.Start()
                    End With
                End If
            ElseIf SceneData(I).MasterValue = 0 Then 'preset is at blackout
                If isDramaPresetSelected(I) = True Then
                    With SceneData(I)
                        .Automation.tmrDirection = "Up"
                        .Automation.IntervalSteps = 255 / (.Automation.TimeBetweenMinAndMax / .Automation.tTimer.Interval)
                        .Automation.tTimer.Start()
                    End With
                End If
            End If

            I += 1
        Loop

    End Sub
    Function isDramaPresetSelected(ByVal PresetControlsIndex As Integer) As Boolean
        Dim I As Integer = 0
        Do Until I >= lstDramaPresets.SelectedItems.Count
            If lstDramaPresets.SelectedItems(I) = SceneData(PresetControlsIndex).SceneName Then
                Return True
                Exit Function
            End If
            I += 1
        Loop
        Return False
    End Function


#Region " Master Controls "
    Private Sub vsMaster_ValueChanged(sender As Object) Handles vsMaster.ValueChanged
        If PagingChanged = True Then Exit Sub
        If Not Val(txtMaster.Text) = sender.value Then
            txtMaster.Text = sender.value
        End If
    End Sub

    Private Sub txtMaster_TextChanged(sender As Object, e As EventArgs) Handles txtMaster.TextChanged
        If PagingChanged = True Then Exit Sub
        If Not vsMaster.Value = Val(sender.text) Then
            vsMaster.Value = Val(sender.text)
        End If
    End Sub

    Private Sub cmdMasterFull_Click(sender As Object, e As EventArgs) Handles cmdMasterFull.Click
        frmTouchPad.cmdMasterUp.BackColor = Color.Red
        If numChangeMS.Value = 0 Then
            txtMaster.Text = 100
            vsMaster.Value = Val(txtMaster.Text)
        Else
            tmrMasterWay = "Up"
            tmrMasterUpto = txtMaster.Text
            tmrMasterInterval = vsMaster.Maximum / (numChangeMS.Value / tmrMaster.Interval)
            tmrMaster.Start()
        End If
    End Sub

    Private Sub tmrMaster_Tick(sender As Object, e As EventArgs) Handles tmrMaster.Tick
        If tmrMasterWay = "Down" Then

            If (vsMaster.Value - tmrMasterInterval) <= 0 Then
                tmrMaster.Stop()
                tmrMasterWay = "lol"
            End If
            vsMaster.Value -= tmrMasterInterval

        ElseIf tmrMasterWay = "Up" Then
            If (vsMaster.Value + tmrMasterInterval) >= 100 Then
                tmrMaster.Stop()
                tmrMasterWay = "lol"
            End If
            vsMaster.Value += tmrMasterInterval

        End If
    End Sub

    Private Sub cmdMasterBlackout_Click(sender As Object, e As EventArgs) Handles cmdMasterBlackout.Click
        frmTouchPad.cmdMasterUp.BackColor = controlcolour
        If numChangeMS.Value = 0 Then
            txtMaster.Text = 0
            vsMaster.Value = Val(txtMaster.Text)
        Else
            tmrMasterWay = "Down"
            tmrMasterUpto = txtMaster.Text
            'tmrMasterInterval = (numChangeMS.Value / 100) '20 times
            tmrMasterInterval = vsMaster.Value / (numChangeMS.Value / tmrMaster.Interval)
            tmrMaster.Start()
        End If
    End Sub
#End Region

#Region " Colour Pickers "
    Private Sub cmdChannelBulletColour_Click(sender As Object, e As EventArgs) Handles cmdChannelBulletColour.Click
        Dim coldialog As New ColorDialog
        coldialog.Color = lblChannelBulletColour.BackColor
        coldialog.ShowDialog()
        lblChannelBulletColour.BackColor = coldialog.Color

        Dim I As Integer = 1
        Do Until I >= ChannelFaders.Length
            If Not ChannelFaders(I).cFader Is Nothing Then
                ChannelFaders(I).cFader.BulletColor = coldialog.Color
            Else
                Exit Do
            End If
            I += 1
        Loop
    End Sub

    Private Sub cmdChannelBackColour_Click(sender As Object, e As EventArgs) Handles cmdChannelBackColour.Click
        Dim coldialog As New ColorDialog
        coldialog.Color = lblChannelBackColour.BackColor
        coldialog.ShowDialog()
        lblChannelBackColour.BackColor = coldialog.Color

        Dim I As Integer = 1
        Do Until I >= ChannelFaders.Length
            If Not ChannelFaders(I).cFader Is Nothing Then
                ChannelFaders(I).cFader.BackColor = coldialog.Color
            Else
                Exit Do
            End If
            I += 1
        Loop
    End Sub

    Private Sub cmdChannelFillColour_Click(sender As Object, e As EventArgs) Handles cmdChannelFillColour.Click
        Dim coldialog As New ColorDialog
        coldialog.Color = lblChannelFillColour.BackColor
        coldialog.ShowDialog()
        lblChannelFillColour.BackColor = coldialog.Color

        Dim I As Integer = 1
        Do Until I >= ChannelFaders.Length
            If Not ChannelFaders(I).cFader Is Nothing Then
                ChannelFaders(I).cFader.FillColor = coldialog.Color
            Else
                Exit Do
            End If

            I += 1
        Loop
    End Sub
    Private Sub cmdChannelNumberColour_Click(sender As Object, e As EventArgs) Handles cmdChannelNumberColour.Click
        Dim coldialog As New ColorDialog
        coldialog.Color = lblChannelNumberColour.BackColor
        coldialog.ShowDialog()
        lblChannelNumberColour.BackColor = coldialog.Color

        Dim I As Integer = 1
        Do Until I >= ChannelFaders.Length
            If Not ChannelFaders(I).cChannelLabel Is Nothing Then
                ChannelFaders(I).cChannelLabel.ForeColor = coldialog.Color
            Else
                Exit Do
            End If

            I += 1
        Loop
    End Sub

    Private Sub cmdSceneBlackoutColour_Click(sender As Object, e As EventArgs) Handles cmdSceneBlackoutColour.Click
        Dim coldialog As New ColorDialog
        coldialog.Color = lblSceneBlackoutColour.BackColor
        coldialog.ShowDialog()
        lblSceneBlackoutColour.BackColor = coldialog.Color

        Dim I As Integer = 1
        Do Until I >= PresetFaders.Length
            If Not PresetFaders(I).cSceneControl Is Nothing Then
                If Val(PresetFaders(I).cSceneControl.cTxtVal.Text) = 0 Then
                    PresetFaders(I).cSceneControl.cBlackout.BackColor = coldialog.Color
                End If
            Else
                Exit Do
            End If
            I += 1
        Loop
    End Sub

    Private Sub cmdSceneUpColour_Click(sender As Object, e As EventArgs) Handles cmdSceneUpColour.Click
        Dim coldialog As New ColorDialog
        coldialog.Color = lblSceneUpColour.BackColor
        coldialog.ShowDialog()
        lblSceneUpColour.BackColor = coldialog.Color

        Dim I As Integer = 1
        Do Until I >= PresetFaders.Length
            If Not PresetFaders(I).cSceneControl Is Nothing Then
                If Val(PresetFaders(I).cSceneControl.cTxtVal.Text) > 0 Then
                    PresetFaders(I).cSceneControl.cFull.BackColor = coldialog.Color
                End If
            Else
                Exit Do
            End If
            I += 1
        Loop
    End Sub

    Private Sub cmdSceneFillColour_Click(sender As Object, e As EventArgs) Handles cmdSceneFillColour.Click
        'Dim coldialog As New ColorDialog
        'coldialog.Color = lblSceneFillColour.BackColor
        'coldialog.ShowDialog()
        'lblSceneFillColour.BackColor = coldialog.Color

        'Dim I As Integer = 1
        'Do Until I >= PresetFaders.Length
        '    If Not PresetFaders(I).cFader Is Nothing Then
        '        PresetFaders(I).cFader.FillColor = coldialog.Color
        '    Else
        '        Exit Do
        '    End If
        '    I += 1
        'Loop
    End Sub

    Private Sub cmdSceneLabelColour_Click(sender As Object, e As EventArgs) Handles cmdSceneLabelColour.Click
        Dim coldialog As New ColorDialog
        coldialog.Color = lblSceneLabelColour.BackColor
        coldialog.ShowDialog()
        lblSceneLabelColour.BackColor = coldialog.Color

        Dim I As Integer = 1
        Do Until I >= PresetFaders.Length
            If Not PresetFaders(I).cSceneControl Is Nothing Then
                PresetFaders(I).cSceneControl.cPresetName.ForeColor = coldialog.Color
            Else
                Exit Do
            End If
            I += 1
        Loop
    End Sub
#End Region


    Private Sub cmdSaveSettings_Click(sender As Object, e As EventArgs) Handles cmdSaveSettings.Click
        SaveSettingsToFile()
    End Sub

    Private Sub lstSongEditPresets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSongEditPresets.SelectedIndexChanged
        'PresetControls(PresetIndex(lstPrsets.SelectedItem)).vtxtBox.Text = 100
        If lstSongEditPresets.SelectedIndex = -1 Then Exit Sub
        If tmrchangedmp3 = True Then Exit Sub

        cmdPresetsBlackoutAllInstant_Click(sender, e)
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

        Dim Qindex As Integer = GetMusicCueIndex(lstMusicSongs.SelectedItem)
        If MusicCues(Qindex).IsMP3 = True Then

            'AudioRun.CurrentPosition(MusicCues(Qindex).SongFileName) = vSongEdit.Value
            AudioRun.CurrentPosition(MusicCues(Qindex).SongFileName) = vSongEdit.Value
            'MusicCues(Qindex).vlcPlayer.Time = vSongEdit.Value


        Else

        End If



        updatePlayer()

    End Sub

    Private Sub cmdCreatelink_Click(sender As Object, e As EventArgs) Handles cmdCreatelink.Click
        If lstSongEditPresets.SelectedIndex = -1 Then Exit Sub
        Dim Qindex As Integer = GetMusicCueIndex(lstSongEditPresets.SelectedItem)
        If MusicCues(Qindex).IsMP3 = False Then
            Exit Sub
        End If

        Dim newrow As New ListViewItem
        newrow.Text = AudioRun.CurrentPosition(MusicCues(Qindex).SongFileName, True)
        newrow.SubItems.Add(lstSongEditPresets.SelectedItem)
        newrow.SubItems.Add(numFadeOut.Value)
        newrow.SubItems.Add(numFadeIn.Value)

        Dim NewSongChange As New SongChangesStr

        NewSongChange.TimeCode = newrow.Text
        NewSongChange.SceneName = newrow.SubItems(1).Text
        NewSongChange.SceneIndex = GetSceneIndex(newrow.SubItems(1).Text)
        NewSongChange.TimeToGoUp = newrow.SubItems(2).Text
        NewSongChange.TimeToGoDown = newrow.SubItems(3).Text

        MusicCues(Qindex).SongChangesDict.Add(NewSongChange, NewSongChange.TimeCode)

        ResortSongChange1FromDictionary(Qindex)

        'lstPresetsSongChanges.Items.Add(Player.controls.currentPosition & "|" & lstSongEditPresets.SelectedItem & "|" & numFadeOut.Value & "|" & numFadeIn.Value)
        ' lstDramaViewSongChanges.Items.Add(Player.controls.currentPosition & "|" & lstSongEditPresets.SelectedItem & "|" & numFadeOut.Value & "|" & numFadeIn.Value)
    End Sub
    Private Sub ResortSongChange1FromDictionary(ByVal MusicCueIndex As Integer)
        'Dim iSelectIndex As Double = lstMusicSongChanges1.SelectedItems(0).Text

        lstPresetsSongChanges1.Items.Clear()
        lstMusicSongChanges1.Items.Clear()
        lstDramaViewSongChanges1.Items.Clear()


        Dim SongDictSorted1 = From entry In MusicCues(MusicCueIndex).SongChangesDict Order By entry.Value Select entry
        Dim I As Integer = 0
        Do Until I >= SongDictSorted1.Count
            Dim newrow As New ListViewItem
            newrow.Text = SongDictSorted1(I).Value
            newrow.SubItems.Add(SongDictSorted1(I).Key.SceneName)
            newrow.SubItems.Add(SongDictSorted1(I).Key.TimeToGoUp)
            newrow.SubItems.Add(SongDictSorted1(I).Key.TimeToGoDown)
            lstMusicSongChanges1.Items.Add(newrow)
            lstPresetsSongChanges1.Items.Add(newrow.Clone)
            lstDramaViewSongChanges1.Items.Add(newrow.Clone)
            'If SongDictSorted1(I).Value = iSelectIndex Then
            '    lstMusicSongChanges1.Items(lstMusicSongChanges1.Items.Count - 1).Selected = True
            '    lstPresetsSongChanges1.Items(lstPresetsSongChanges1.Items.Count - 1).Selected = True
            '    lstDramaViewSongChanges1.Items(lstDramaViewSongChanges1.Items.Count - 1).Selected = True
            'End If
            I += 1
        Loop


    End Sub

    Private Sub cmdEditSongCopyNew_Click(sender As Object, e As EventArgs) Handles cmdEditSongCopyNew.Click
        If lstSongEditPresets.SelectedIndex = -1 Then Exit Sub
        Dim Qindex As Integer = GetMusicCueIndex(lstSongEditPresets.SelectedItem)
        If MusicCues(Qindex).IsMP3 = False Then
            Exit Sub
        End If

        Dim defaultnewname As String = lstSongEditPresets.SelectedItem
        Dim newname As String = InputBox("Enter name of new Scene preset", , defaultnewname & " copy")
        If File.Exists(Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & lstSongEditPresets.SelectedItem & ".dmr") = True Then
            If File.Exists(Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & newname & ".dmr") = False Then
                File.Copy(Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & lstSongEditPresets.SelectedItem & ".dmr", Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & newname & ".dmr")
                lstSongEditPresets.Items.Add(newname)
                lstDramaPresets.Items.Add(newname)
                frmChannels.cmbChannelPresetSelection.Items.Add(newname)
                Dim oldindex As Integer = GetSceneIndex(lstSongEditPresets.SelectedItem)
                Dim I As Integer = 1
                Do Until I >= SceneData.Count
                    If SceneData(I).SceneName = " " Then
                        SceneData(I).SceneName = newname
                        SceneData(I).Automation = SceneData(oldindex).Automation
                        SceneData(I).ChannelValues = SceneData(oldindex).ChannelValues
                        SceneData(I).PageNo = -1
                        SceneData(I).LocIndex = -1




                        CreateNewScene(newname, -1)
                        SaveScene(newname)



                        Dim NewSongChange As New SongChangesStr

                        NewSongChange.TimeCode = AudioRun.CurrentPosition(MusicCues(Qindex).SongFileName, True)
                        NewSongChange.SceneName = newname
                        NewSongChange.SceneIndex = GetSceneIndex(newname)
                        NewSongChange.TimeToGoUp = numFadeIn.Value
                        NewSongChange.TimeToGoDown = numFadeOut.Value

                        MusicCues(Qindex).SongChangesDict.Add(NewSongChange, NewSongChange.TimeCode)

                        ResortSongChange1FromDictionary(Qindex)

                        'lstMusicSongChanges1.Items.Add(newrow)
                        'lstPresetsSongChanges1.Items.Add(newrow)
                        'lstDramaViewSongChanges1.Items.Add(newrow)

                        Exit Do

                    End If
                    I += 1
                Loop


            End If

        End If
        RenamePresetFaderControls()

        'lstMusicSongChanges.Items.Item(lstMusicSongChanges.SelectedIndex) = Math.Round(Player.controls.currentPosition, 2) & "|" & lstSongEditPresets.SelectedItem & "|" & numFadeOut.Value & "|" & numFadeIn.Value
    End Sub

    Private Sub cmdEditSongSave_Click(sender As Object, e As EventArgs) Handles cmdEditSongSave.Click
        Dim Qindex As Integer = GetMusicCueIndex(lstSongEditPresets.SelectedItem)

        MusicCues(Qindex).SongChangesDict.Clear()
        FileOpen(1, Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & lstMusicSongs.SelectedItem & ".chg", OpenMode.Output)
        For Each thisrow As ListViewItem In lstMusicSongChanges1.Items
            PrintLine(1, thisrow.Text & "|" & thisrow.SubItems(1).Text & "|" & thisrow.SubItems(2).Text & "|" & thisrow.SubItems(3).Text)
            Dim NewSongChange As New SongChangesStr
            'Dim a() As String = Split(S, "|")

            NewSongChange.TimeCode = thisrow.Text
            NewSongChange.SceneName = thisrow.SubItems(1).Text
            NewSongChange.SceneIndex = GetSceneIndex(thisrow.SubItems(1).Text)
            NewSongChange.TimeToGoUp = thisrow.SubItems(2).Text
            NewSongChange.TimeToGoDown = thisrow.SubItems(3).Text

            MusicCues(Qindex).SongChangesDict.Add(NewSongChange, NewSongChange.TimeCode)
        Next
        FileClose(1)
        Thread.Sleep(10)
        'lstSongs_SelectedIndexChanged(lstMusicSongs, e)


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

    Private Sub lstMusicSongChanges_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMusicSongChanges1.SelectedIndexChanged
        'If lstMusicSongChanges1.SelectedIndex = -1 Then Exit Sub
        If lstMusicSongChanges1.SelectedItems.Count = 0 Then Exit Sub
        If chkEnableSongEdit.Visible = True And chkEnableSongEdit.Checked = False Then Exit Sub
        If EditUpdate = True Then Exit Sub
        Song1EditingOrig = New SongChangesStr

        Dim selrow As ListViewItem = lstMusicSongChanges1.SelectedItems(0)
        txtEditTime.Text = Math.Round(Val(selrow.Text), 2)
        lstSongEditPresets.SelectedItem = selrow.SubItems(1).Text
        Song1EditingOrig.SceneIndex = GetSceneIndex(selrow.SubItems(1).Text)
        Song1EditingOrig.SceneName = selrow.SubItems(1).Text
        Song1EditingOrig.TimeCode = Math.Round(Val(selrow.Text), 2)

        If selrow.SubItems.Count > 2 Then
            numFadeIn.Value = Val(selrow.SubItems(2).Text)
            numFadeOut.Value = Val(selrow.SubItems(3).Text)
            Song1EditingOrig.TimeToGoUp = Val(selrow.SubItems(2).Text)
            Song1EditingOrig.TimeToGoDown = Val(selrow.SubItems(3).Text)
        Else
            numFadeOut.Value = 0
            numFadeIn.Value = 0
            selrow.SubItems.Add(0)
            selrow.SubItems.Add(0)
            Song1EditingOrig.TimeToGoUp = 0
            Song1EditingOrig.TimeToGoDown = 0
        End If


    End Sub
    Dim EditUpdate As Boolean = False
    Private Sub cmdEditUpdate_Click(sender As Object, e As EventArgs) Handles cmdEditUpdate.Click
        If chkEnableSongEdit.Visible = True And chkEnableSongEdit.Checked = False Then Exit Sub
        'If lstMusicSongChanges1.SelectedIndex = -1 Then Exit Sub
        If lstMusicSongChanges1.SelectedItems.Count = 0 Then Exit Sub

        Dim Qindex As Integer = GetMusicCueIndex(lstSongEditPresets.SelectedItem)

        EditUpdate = True
        'Dim a() As String = Split(lstMusicSongChanges1.SelectedItem, "|")
        lstMusicSongChanges1.SelectedItems(0).Text = txtEditTime.Text
        lstMusicSongChanges1.SelectedItems(0).SubItems(1).Text = lstSongEditPresets.SelectedItem
        lstMusicSongChanges1.SelectedItems(0).SubItems(2).Text = numFadeIn.Value
        lstMusicSongChanges1.SelectedItems(0).SubItems(3).Text = numFadeOut.Value

        Dim newchange As New SongChangesStr

        'lstMusicSongChanges1.Items(lstMusicSongChanges1.SelectedIndex) = txtEditTime.Text & "|" & lstSongEditPresets.SelectedItem & "|" & numFadeIn.Value & "|" & numFadeOut.Value
        newchange.TimeCode = Math.Round(Val(txtEditTime.Text), 2)
        newchange.SceneName = lstSongEditPresets.SelectedItem
        newchange.SceneIndex = GetSceneIndex(lstSongEditPresets.SelectedItem)
        newchange.TimeToGoUp = numFadeIn.Value
        newchange.TimeToGoDown = numFadeOut.Value

        Dim SongDictSorted1 = From entry In MusicCues(Qindex).SongChangesDict Order By entry.Value Select entry


        For Each sitem In SongDictSorted1
            If sitem.Value = Song1EditingOrig.TimeCode And sitem.Key.SceneIndex = Song1EditingOrig.SceneIndex Then
                MusicCues(Qindex).SongChangesDict.Remove(sitem.Key)
            End If
        Next

        MusicCues(Qindex).SongChangesDict.Add(newchange, newchange.TimeCode)
        'SongChanges1.Item(lstMusicSongChanges1.SelectedItems(0).Index) = newchange

        Song1EditingOrig = newchange
        ResortSongChange1FromDictionary(Qindex)
        EditUpdate = False
    End Sub

    Private Sub cmdColourTest_Click(sender As Object, e As EventArgs) Handles cmdColourTest.Click
        frmGradientColour.Show()
    End Sub

    Private Sub cmdReloadSongLists_Click(sender As Object, e As EventArgs) Handles cmdReloadSongLists.Click
        LoadMusicTracks()
    End Sub

    Private Sub cmdSongChangeColour_Click(sender As Object, e As EventArgs) Handles cmdSongChangeColour.Click
        Dim coldialog As New ColorDialog
        coldialog.Color = lblSongChangeColour.BackColor
        coldialog.ShowDialog()
        lblSongChangeColour.BackColor = coldialog.Color

    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        frmCustomColourPicker1.ColorPicker2.Value = Color.Fuchsia
        frmCustomColourPicker1.ShowDialog()
        'frmCustomColourPicker.ColorPicker2.Value.Name
    End Sub

    Private Sub ctxSendNext_Click(sender As Object, e As EventArgs) Handles ctxSendNext.Click
        'If RenamePresetFaderOk = False Then Exit Sub
        Dim CurrentPageNo As Integer = 1

        If cmdPresetP1.BackColor = Color.Red Then
            CurrentPageNo = 1
        End If
        If cmdPresetP2.BackColor = Color.Red Then
            CurrentPageNo = 2
        End If
        If cmdPresetP3.BackColor = Color.Red Then
            CurrentPageNo = 3
        End If
        If cmdPresetP4.BackColor = Color.Red Then
            CurrentPageNo = 4
        End If
        If cmdPresetP5.BackColor = Color.Red Then
            CurrentPageNo = 5
        End If
        If cmdPresetP6.BackColor = Color.Red Then
            CurrentPageNo = 6
            Exit Sub ' Is already on last page
        End If

        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)
        Dim obj As SceneControl1 = cms.SourceControl.Parent

        If obj.SceneIndex = -1 Then
            'is new/blank scene
            Exit Sub
        Else
            'Scene exists
            Dim oldname As String = SceneData(obj.SceneIndex).SceneName
            Dim Somethingfound As Boolean = False
            Dim SceneI As Integer = 1
            Do Until SceneI >= SceneData.Length
                If SceneData(SceneI).PageNo = CurrentPageNo + 1 And SceneData(SceneI).LocIndex = SceneData(obj.SceneIndex).LocIndex Then
                    'something else already in new location
                    SceneData(obj.SceneIndex).PageNo = CurrentPageNo + 1
                    SceneData(obj.SceneIndex).LocIndex = -1
                    PresetFaders(obj.PresetFixture).cSceneControl.cPresetName.Text = ""
                    Somethingfound = True
                End If
                SceneI += 1
            Loop
            If Somethingfound = False Then
                'new location is empty
                SceneData(obj.SceneIndex).PageNo = CurrentPageNo + 1
                PresetFaders(obj.PresetFixture).cSceneControl.cPresetName.Text = ""

            End If

            SaveScene(oldname)
        End If


    End Sub

    Private Sub ctxSendPrevious_Click(sender As Object, e As EventArgs) Handles ctxSendPrevious.Click
        'If RenamePresetFaderOk = False Then Exit Sub
        Dim CurrentPageNo As Integer = 1

        If cmdPresetP1.BackColor = Color.Red Then
            CurrentPageNo = 1
            Exit Sub ' Is already on first page
        End If
        If cmdPresetP2.BackColor = Color.Red Then
            CurrentPageNo = 2
        End If
        If cmdPresetP3.BackColor = Color.Red Then
            CurrentPageNo = 3
        End If
        If cmdPresetP4.BackColor = Color.Red Then
            CurrentPageNo = 4
        End If
        If cmdPresetP5.BackColor = Color.Red Then
            CurrentPageNo = 5
        End If
        If cmdPresetP6.BackColor = Color.Red Then
            CurrentPageNo = 6
        End If

        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)
        Dim obj As SceneControl1 = cms.SourceControl.Parent

        If obj.SceneIndex = -1 Then
            'is new/blank scene
            Exit Sub
        Else
            'Scene exists
            Dim oldname As String = SceneData(obj.SceneIndex).SceneName
            Dim Somethingfound As Boolean = False
            Dim SceneI As Integer = 1
            Do Until SceneI >= SceneData.Length
                If SceneData(SceneI).PageNo = CurrentPageNo - 1 And SceneData(SceneI).LocIndex = SceneData(obj.SceneIndex).LocIndex Then
                    'something else already in new location
                    SceneData(obj.SceneIndex).PageNo = CurrentPageNo - 1
                    SceneData(obj.SceneIndex).LocIndex = -1
                    PresetFaders(obj.PresetFixture).cSceneControl.cPresetName.Text = ""
                    Somethingfound = True
                End If
                SceneI += 1
            Loop
            If Somethingfound = False Then
                'new location is empty
                SceneData(obj.SceneIndex).PageNo = CurrentPageNo - 1
                PresetFaders(obj.PresetFixture).cSceneControl.cPresetName.Text = ""

            End If

            SaveScene(oldname)
        End If



    End Sub

    Private Sub cmdRestartSerial_Click(sender As Object, e As EventArgs) Handles cmdRestartSerial.Click
        SetupSerialConnections()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Arduinos(0).Serial.Write("UID," & Arduinos(0).PortNo & vbCrLf)
    End Sub

    Private Sub cmdSetMusic1_Click(sender As Object, e As EventArgs) Handles cmdSetMusic1.Click
        If lstCOMdevices.SelectedItems.Count = 0 Then Exit Sub
        Dim I As Integer = 0
        Do Until I >= Arduinos.Length
            If Arduinos(I).PortNo = lstCOMdevices.SelectedItems(0).Text Then
                Arduinos(I).Job = ArduinoModes.ctlMusic1
                lstCOMdevices.SelectedItems(0).SubItems(3).Text = ArduinoModes.ctlMusic1
            End If
            I += 1
        Loop
        SaveArduinoAssignments()
    End Sub

    Private Sub cmdSetDMX1_Click(sender As Object, e As EventArgs) Handles cmdSetDMX1.Click
        If lstCOMdevices.SelectedItems.Count = 0 Then Exit Sub
        Dim I As Integer = 0
        Do Until I >= Arduinos.Length
            If Arduinos(I).PortNo = lstCOMdevices.SelectedItems(0).Text Then
                Arduinos(I).Job = ArduinoModes.ctlDMX3Universe
                lstCOMdevices.SelectedItems(0).SubItems(3).Text = ArduinoModes.ctlDMX3Universe
                ArdDMX.SetComPort = I
                'Arduinos(I).Serial.Close() ' Will get opened in DMX Class
                'mdlGlobalVariables.DMX.SetComPort(Arduinos(I).PortNo)
            End If
            I += 1
        Loop

        SaveArduinoAssignments()
    End Sub

    Private Sub cmdSetSoundActivation_Click(sender As Object, e As EventArgs) Handles cmdSetSoundActivation.Click
        If lstCOMdevices.SelectedItems.Count = 0 Then Exit Sub
        Dim I As Integer = 0
        Do Until I >= Arduinos.Length
            If Arduinos(I).PortNo = lstCOMdevices.SelectedItems(0).Text Then
                Arduinos(I).Job = ArduinoModes.ctlSoundActivation1
                lstCOMdevices.SelectedItems(0).SubItems(3).Text = ArduinoModes.ctlSoundActivation1
            End If
            I += 1
        Loop
        SaveArduinoAssignments()
    End Sub

    Private Sub cmdSetMusic2_Click(sender As Object, e As EventArgs) Handles cmdSetMusic2.Click
        If lstCOMdevices.SelectedItems.Count = 0 Then Exit Sub
        Dim I As Integer = 0
        Do Until I >= Arduinos.Length
            If Arduinos(I).PortNo = lstCOMdevices.SelectedItems(0).Text Then
                Arduinos(I).Job = ArduinoModes.ctlMusic2
                lstCOMdevices.SelectedItems(0).SubItems(3).Text = ArduinoModes.ctlMusic2
            End If
            I += 1
        Loop
        SaveArduinoAssignments()
    End Sub

    Private Sub cmdReloadArduinoAssignments_Click(sender As Object, e As EventArgs) Handles cmdReloadArduinoAssignments.Click
        LoadArduinoAssignments()
    End Sub

    Private Sub txtSCSIPaddress_TextChanged(sender As Object, e As EventArgs) Handles txtSCSIPaddress.TextChanged
        SCSIPaddress = txtSCSIPaddress.Text
    End Sub

    Private Sub txtSCSPort_TextChanged(sender As Object, e As EventArgs) Handles txtSCSPort.TextChanged
        SCSPort = Val(txtSCSPort.Text)
    End Sub


    Private Sub tmrserial_Tick(sender As Object, e As EventArgs) Handles tmrserial.Tick
        If formopened = False Then Exit Sub
        LoadArduinoAssignments()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles cmdRepeatAssignments.Click
        'If cmdRepeatAssignments.Text = "Stop Repeat Assignment Checks" Then
        '    tmrserial.Stop()
        '    cmdRepeatAssignments.Text = "Start Repeat Assignment Checks"
        'ElseIf cmdRepeatAssignments.Text = "Start Repeat Assignment Checks" Then
        '    tmrserial.Start()
        'End If
        If formopened = False Then Exit Sub
        LoadArduinoAssignments()
    End Sub

    Private Sub chkAsioMode_CheckedChanged(sender As Object, e As EventArgs) Handles chkAsioMode.CheckedChanged
        If formopened = False Then Exit Sub
        ASIOMode = chkAsioMode.Checked
        If ASIOMode = True Then LoadMusicTracks()
        If ASIOMode = False Then AudioRun.DisposeAsio()

    End Sub

    Private Sub cmdAsioUp_Click(sender As Object, e As EventArgs) Handles cmdAsioUp.Click
        If lstASIOInterfaces.SelectedItems.Count = 0 Then Exit Sub
        Dim I As Integer = Val(lstASIOInterfaces.SelectedItems(0).Text) + 1
        If I >= (lstASIOInterfaces.Items.Count) Then I = lstASIOInterfaces.Items.Count
        lstASIOInterfaces.SelectedItems(0).Text = I
        lstASIOInterfaces.Sort()
        AudioRun.DeviceNumber(lstASIOInterfaces.SelectedItems(0).SubItems(1).Text) = Val(lstASIOInterfaces.SelectedItems(0).Text)
        'lstASIOInterfaces_Changed()
    End Sub

    Private Sub cmdAsioDown_Click(sender As Object, e As EventArgs) Handles cmdAsioDown.Click
        If lstASIOInterfaces.SelectedItems.Count = 0 Then Exit Sub
        Dim I As Integer = Val(lstASIOInterfaces.SelectedItems(0).Text) - 1
        If I < 0 Then I = 0
        lstASIOInterfaces.SelectedItems(0).Text = I
        lstASIOInterfaces.Sort()
        AudioRun.DeviceNumber(lstASIOInterfaces.SelectedItems(0).SubItems(1).Text) = Val(lstASIOInterfaces.SelectedItems(0).Text)
        'lstASIOInterfaces_Changed()
    End Sub
    Sub LoadAsioDriverList()

        Dim I As Integer = 0
        Do Until I >= AudioRun.AsioDeviceCount
            Dim newrow As New ListViewItem
            newrow.Text = AudioRun.DeviceDetails(I).NumberAssigned
            newrow.SubItems.Add(AudioRun.DeviceDetails(I).DeviceName)
            If Not AudioRun.DeviceDetails(I).NumberAssigned = -1 And AudioRun.DeviceDetails(I).DeviceName IsNot Nothing Then
                lstASIOInterfaces.Items.Add(newrow)
            End If
            I += 1
        Loop

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdSceneBorderColor.Click
        Dim coldialog As New ColorDialog
        coldialog.Color = lblSceneBorderColour.BackColor
        coldialog.ShowDialog()
        lblSceneBorderColour.BackColor = coldialog.Color

        borderColor = lblSceneBorderColour.BackColor
    End Sub

    Private Sub tmrAVUCheck_Tick(sender As Object, e As EventArgs) Handles tmrAVUCheck.Tick
        If formopened = False Then Exit Sub
        'Set to 0 if nothing received in 4 seconds
        SoundActivationCurrentLevel = 0
        lblAudioActive.Text = SoundActivationCurrentLevel
    End Sub

    Private Sub SaveSceneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveSceneToolStripMenuItem.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)
        Dim obj As SceneControl1 = cms.SourceControl.Parent

        If obj.SceneIndex = -1 Then
            'is new scene
            Dim newname As String = InputBox("Please Enter New Scene Name:", "New Scene", "")
            If newname = "" Then Exit Sub


            PresetFaders(obj.PresetFixture).cSceneControl.cPresetName.Text = newname

            frmChannels.cmbChannelPresetSelection.Items.Add(newname)
            lstDramaPresets.Items.Add(newname)
            lstSongEditPresets.Items.Add(newname)
            CreateNewScene(newname, obj.PresetFixture)
            SaveScene(newname)
        Else
            'Scene exists
            Dim oldname As String = SceneData(obj.SceneIndex).SceneName

            SaveScene(oldname)
        End If

    End Sub

    Private Sub DuplicateSceneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateSceneToolStripMenuItem.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)
        Dim obj As SceneControl1 = cms.SourceControl.Parent

        If obj.SceneIndex = -1 Then Exit Sub


        Dim oldname As String = SceneData(obj.SceneIndex).SceneName
        Dim newname As String = InputBox("Please Enter New Scene Name:", "New Scene", "")
        If newname = "" Then Exit Sub
        CreateNewScene(newname)

        Dim newI As Integer = 0
        Do Until SceneData(newI).SceneName = newname
            If newI >= SceneData.Length Then Exit Sub 'shit broke
            newI += 1
        Loop

        SceneData(newI).ChannelValues = SceneData(obj.SceneIndex).ChannelValues
        SceneData(newI).Automation = SceneData(obj.SceneIndex).Automation

        SaveScene(newname)
        RenamePresetFaderControls()

    End Sub

    'Private Sub lstASIOInterfaces_Changed()
    '    ' If formopened = False Then Exit Sub
    '    Dim I As Integer = 0
    '    Dim isenabled As Boolean = False
    '    Do Until I >= lstASIOInterfaces.Items.Count
    '        If Val(lstASIOInterfaces.Items.Item(I).Text) > 0 Then
    '            isenabled = True
    '        End If
    '        I += 1
    '    Loop
    '    chkAsioMode.Enabled = isenabled
    'End Sub

    Private Sub cmdSerialClear_Click(sender As Object, e As EventArgs) Handles cmdSerialClear.Click
        txtSerialIn.Text = ""
    End Sub
    Private Sub lstCOMdevices_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCOMdevices.SelectedIndexChanged
        txtSerialIn.Text = ""
    End Sub

    Public Function GetIndexOfNumber(ByVal str As String) As Integer

        For n As Integer = 0 To str.Length - 1

            If IsNumeric(str.Substring(n, 1)) Then

                Return n

            End If

        Next

        Return -1

    End Function

End Class

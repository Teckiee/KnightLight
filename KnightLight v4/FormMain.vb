Option Strict Off
Option Explicit On
Imports System.IO
Imports EnttecOpenDMX.OpenDMX
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Management
Imports Super_Awesome_Lighting_DMX_board_v4.mdlGlobalVariables
Imports NAudio.SoundFont
Imports System.Net
Imports System.Net.Sockets
Imports NAudio
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json
'Imports Arduino_DMX_USB.Main

Public Class FormMain

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
    Dim CurrentSongChangeIndex2 As Integer = -1
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

    Dim Averaging(20) As Integer
    Dim AvgUpTo As Integer = 0

    Dim PresetsPerColumn As Integer = 0
    Dim PresetsPerRow As Integer = 0

    Dim PresetVisualUpdate As Boolean = False
    Dim RenamePresetFaderOk As Boolean = False

    Dim HoldLeft, HoldTop As Integer
    Dim TopSet, LeftSet As Boolean
    Dim OffTop, OffLeft As Integer
    'Dim OrigTop, OrigLeft As Integer

    Dim StartupTimer As Stopwatch

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
                    Arduinos(SerialCount).Serial.ReadTimeout = -1
                    Arduinos(SerialCount).Serial.WriteTimeout = -1
                    Arduinos(SerialCount).Serial.Open()
                    AddHandler Arduinos(SerialCount).Serial.DataReceived, AddressOf SerialPort_DataReceived
                    If enableUID Then Arduinos(SerialCount).Serial.Write("UID," & Arduinos(SerialCount).PortNo & vbCrLf)
                    Arduinos(SerialCount).InUse = True
                    'newrow.SubItems.Add("True")
                Catch
                    'Dim thread1 As New Thread(S ub()
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
                If Arduinos(I).HasDevice = False Then
                    GoTo found
                End If
                If enableUID Then
                    If Arduinos(I).UID = a(1) Then
                        GoTo found
                    End If
                Else
                    If Arduinos(I).PortNo = a(1) Then
                        GoTo found
                    End If
                End If

                I += 1
            Loop
found:
            If Not I >= Arduinos.Length Then
                'found a match
                If enableUID Then
                    Arduinos(I).UID = a(1)
                Else
                    Arduinos(I).PortNo = a(1)
                End If
                Try
                    Arduinos(I).Job = a(0)
                    Arduinos(I).HasDevice = True
                Catch ex As Exception

                End Try
                If Arduinos(I).Job = ArduinoModes.ctlMarsConsole And Arduinos(I).InUse = True Then
                    MarsConsole = New cMarsConsole(Arduinos(I).Serial)
                    RemoveHandler Arduinos(I).Serial.DataReceived, AddressOf SerialPort_DataReceived
                End If
                'Select Case a(0)
                '    Case ArduinoModes.ctlMusic1
                '        Arduinos(I).Job = ArduinoModes.ctlMusic1
                '        Arduinos(I).HasDevice = True
                '    Case ArduinoModes.ctlMusic2
                '        Arduinos(I).Job = ArduinoModes.ctlMusic2
                '        Arduinos(I).HasDevice = True
                '    Case ArduinoModes.ctlDMX3Universe
                '        Arduinos(I).Job = ArduinoModes.ctlDMX3Universe
                '        ArduDMX.SetComPort = I
                '        Arduinos(I).HasDevice = True
                '    Case ArduinoModes.ctlSoundActivation1
                '        Arduinos(I).Job = ArduinoModes.ctlSoundActivation1
                '        Arduinos(I).HasDevice = True
                '    Case ArduinoModes.ctlMarsConsole
                '        Arduinos(I).Job = ArduinoModes.ctlMarsConsole
                '        Arduinos(I).HasDevice = True
                'End Select
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
                If enableUID Then
                    PrintLine(8, Arduinos(I).Job & "=" & Arduinos(I).UID)
                Else
                    PrintLine(8, Arduinos(I).Job & "=" & Arduinos(I).PortNo)
                End If

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
    Structure IncomingMessages
        Dim msg As String
        Dim portname As String
        Dim arduinoindex As Integer
    End Structure
    Delegate Sub myMethodDelegate(ByVal [text] As IncomingMessages)
    Dim myD1 As New myMethodDelegate(AddressOf myShowStringMethod)

    Private Sub SerialPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) ' Handles SerialPort.DataReceived
        If ClosingNow = True Then Exit Sub

        Dim incmsg As IncomingMessages
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
    Sub myShowStringMethod(ByVal mymsg As IncomingMessages)


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
                Averaging(AvgUpTo) = Val(a(1))
                lblAudioActive.Text = Math.Round(Averaging.Average())
                tmrAVUCheck.Stop()
                SoundActivationCurrentLevel = Val(a(1))
                tmrAVUCheck.Start()
                AvgUpTo += 1
                If AvgUpTo >= Averaging.Length Then
                    AvgUpTo = 0
                End If
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
                    If Arduinos(mymsg.arduinoindex).Job = ArduinoModes.ctlMusic1 Then
                        cmdStop_Click(Nothing, Nothing)
                    ElseIf Arduinos(mymsg.arduinoindex).Job = ArduinoModes.ctlMusic2 Then
                        cmdStop2_Click(Nothing, Nothing)
                    End If
                    'AudioRun.mStop(songtitle)
                Case "Back"
                    If Arduinos(mymsg.arduinoindex).Job = ArduinoModes.ctlMusic1 Then
                        If lstPresetsSongs.SelectedIndex = 0 Then
                            'cmdPlay_Click(Nothing, Nothing)
                        Else
                            lstPresetsSongs.SelectedIndex -= 1
                            If chkMusicNextFollows.Checked Then
                                If lstPresetsSongs.SelectedIndex > 0 Then

                                    lstPresetsSongs2.SelectedIndex = lstPresetsSongs.SelectedIndex - 1
                                End If
                            End If
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
                            'If cmdPresetsPlay.Text = "Pause" Then
                            '    cmdSkip_Click(Nothing, Nothing)
                            'Else
                            '    lstPresetsSongs.SelectedIndex += 1
                            'End If
                            lstPresetsSongs.SelectedIndex += 1
                            If chkMusicNextFollows.Checked Then
                                If lstPresetsSongs.SelectedIndex < lstPresetsSongs2.Items.Count Then

                                    lstPresetsSongs2.SelectedIndex = lstPresetsSongs.SelectedIndex + 1
                                End If
                            End If

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
    Public Sub StartupProcess(ByVal sName As String)
        Dim newrow As New ListViewItem
        newrow.Text = sName
        newrow.SubItems.Add(StartupTimer.ElapsedMilliseconds)
        lstStartup.Items.Add(newrow)
    End Sub

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StartupTimer = New Stopwatch
        StartupTimer.Start()
        Me.SuspendLayout()
        tbpPresets.SuspendLayout()

        If Environment.GetCommandLineArgs.Length > 1 Then
            If Environment.GetCommandLineArgs(1) = "-Testmode" Then Testmode = True
        End If
        If File.Exists(Application.StartupPath & "\Testmode.txt") = True Then Testmode = True


        AudioRun = New AudioThread
        StartupProcess("AudioThread")

        ArduDMX = New ArduinoDMX
        StartupProcess("ArduinoDMX")

        DMXdata = New cDMXdata
        StartupProcess("DMXdata")



        frmMain = Me
        'frmTouchPad = New FormTouchPad
        'Dim iDim As Integer = 0
        'Do Until iDim >= frmDimmerAutomation.Length
        '    frmDimmerAutomation(iDim) = New FormDimmerAutomation With {
        '        .Icon = frmMain.Icon,
        '        .BackColor = Color.Black
        '    }
        '    iDim += 1
        'Loop
        'StartupProcess("frmDimmerAutomation")
        frmGradientColour = New FormColourGradient
        frmCustomColourPicker1 = New FormColourPicker
        frmChannels = New FormChannels
        frmChannels.Show()
        frmChannels.SendToBack()
        'frmTouchPad.Icon = frmMain.Icon
        StartupProcess("frmChannels")


        With Me.tmrMP3
            .Interval = 50
            .Enabled = False
        End With

        With Me.tmrMP32
            .Interval = 50
            .Enabled = False
        End With


        controlcolour = Me.BackColor

        For Each c As Windows.Forms.Control In tbpPresets.Controls
            tbpPresetsControls.Add(c)
        Next
        StartupProcess("Add Presets Controls to Memory")

        For Each c As Windows.Forms.Control In frmChannels.Controls
            frmChannelsControls.Add(c)
        Next
        StartupProcess("re-Add Channels.Controls")

        For Each c As Windows.Forms.Control In frmChannels.pnlAutomation.Controls
            frmChannelAutomationControls.Add(c)
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

            End Try


        End If
        'tbpPresetsControls = tbpPresets.Controls
        ' frmChannelsControls = frmChannels.Controls

        LoadBankTextToListBox()
        StartupProcess("LoadBanks")

        LoadSettingsFromFile()
        StartupProcess("LoadSettings")

        SetupSerialConnections() 'Arduino setup
        StartupProcess("LoadArduino")
        'Contains Mars Setup
        'If Arduinos(I).Job = ArduinoModes.ctlMarsConsole Then
        '    MarsConsole = New cMarsConsole(Arduinos(I).Serial)
        'End If

        LoadAsioDriverList()
        StartupProcess("LoadAsio")

        LoadFixtureInformation()
        StartupProcess("LoadFixtures")

        GeneratePresetFormControls() 'Run Only on Startup or Location Reset

        LoadScenesFromFile()
        StartupProcess("LoadScenes")

        RenamePresetFaderOk = True


        'RenamePresetFaderControls() ' Replacing With UpdatePresetControls
        ResetAllPresetControls()
        StartupProcess("GeneratePresetFormControls")


        frmChannels.GenerateChannelFormControls()

        LoadMusicTracks() 'Needs rewrite
        StartupProcess("LoadMusicTracks")

        'If ASIOMode = True Then
        '    SetupAsioOutputs()
        'End If

        SetupThreads()
        StartupProcess("SetupThreads")




        ' -------------------------------------------- Start Colouring
        Dim thread As New Thread(
            Sub()
                For Each c As System.Windows.Forms.Control In Me.Controls
                    AddHandler c.KeyDown, AddressOf Form1_KeyDown
                    AddHandler c.KeyUp, AddressOf Form1_KeyUp
                Next c
            End Sub
        )
        thread.Start()
        StartupProcess("Keypresses")

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
        tbpMarsSettings.BackColor = Color.Black
        tbcControls1.SelectedIndex = 1

        lblMaster.ForeColor = lblChannelNumberColour.BackColor

        For Each c As Control In tbpMusic.Controls
            If c.GetType Is GetType(Label) Then
                c.ForeColor = lblChannelNumberColour.BackColor
            End If
        Next
        For Each c As Control In tbpPresets.Controls
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
            If c.GetType Is GetType(TextBox) Or c.GetType Is GetType(ListView) Then
                c.BackColor = lblChannelBackColour.BackColor
                c.ForeColor = lblChannelNumberColour.BackColor
            End If
        Next
        For Each c As Control In tbpMarsSettings.Controls
            If c.GetType Is GetType(Label) Or c.GetType Is GetType(CheckBox) Then
                If Not c.Text = "..." Then
                    c.BackColor = Color.Black
                    c.ForeColor = lblChannelNumberColour.BackColor
                End If

            End If
            If c.GetType Is GetType(TextBox) Then
                c.BackColor = lblChannelBackColour.BackColor
                c.ForeColor = lblChannelNumberColour.BackColor
            End If

        Next
        frmChannels.SetColours()
        StartupProcess("Colouring")
        ' -------------------------------------------- End Colouring


        ChannelFaderPageCurrentSceneDataIndex = 1

        Dim iStart As Integer = 1
        Do Until iStart >= lstStartup.Items.Count
            lstStartup.Items.Item(iStart).SubItems.Add(lstStartup.Items.Item(iStart).SubItems(1).Text - lstStartup.Items.Item(iStart - 1).SubItems(1).Text)
            iStart += 1
        Loop
        Me.ResumeLayout(False)
        tbpPresets.ResumeLayout(False)
        Me.PerformLayout()
        tbpPresets.PerformLayout()

        If MarsConnected = True Then
            lblMarsConnected.Visible = True
            MarsConsole.SendAll()
        End If



        formopened = True
    End Sub

    Public Sub UpdateFromMars(text As String)
        ' Invoke the UI thread to update the label text
        If frmMain.lblMarsConnected.InvokeRequired Then
            frmMain.lblMarsConnected.Invoke(Sub() UpdateFromMars(text))
        Else
            txtMarsDebug.Text &= vbCrLf & text

            Dim inccmd() As String = Split(text, ",")
            Select Case inccmd(0)
                Case "UID"

                'UpdateMain(incmsg.msg)
                Case "ONLINE"
                    MarsConnected = True
                    'UpdateMain(incmsg.msg)

            End Select

            If InStr(text, "ONLINE") > -1 Then
                frmMain.lblMarsConnected.Visible = True
            End If

        End If
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
                If Not s = "" Then
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
                End If
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
                    Try
                        lstBanks.SetSelected(lstBanks.FindString(a(1)), True)
                    Catch ex As Exception
                        lstBanks.SetSelected(0, True)
                    End Try
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
                Case "MusicNextFollows"
                    chkMusicNextFollows.Checked = Convert.ToBoolean(a(1))
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
        PrintLine(1, "MusicNextFollows=" & chkMusicNextFollows.Checked)

        FileClose(1)

    End Sub

    Private Sub LoadBankTextToListBox(Optional ByVal selectitem As String = "")

        'Dim oldItem As String = lstBanks.SelectedItem

        lstBanks.Items.Clear()
        Dim I As Integer = 0

        For Each S As String In Directory.GetDirectories(Application.StartupPath & "\Save Files\")
            Dim a() As String = Split(S, "\")
            lstBanks.Items.Add(a(a.Length - 1))
            If Not selectitem = "" And a(a.Length - 1) = selectitem Then
                lstBanks.SelectedItem = selectitem
            End If
        Next S
        'Application.DoEvents()
    End Sub
    Private Sub LoadScenesFromFile(Optional ByVal LoadName As String = "", Optional ByVal LoadIndex As Integer = 0)

        ' Loads only on Bank change and new opening

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
            SceneData(I).Automation.tTimer = New NamedTimer(I, 100)
            'SceneData(I).Automation.tTimer = New Windows.Forms.Timer With {
            '    .Interval = 100,
            '    .Tag = I
            '}
            'AddHandler SceneData(I).Automation.tTimer.Tick, AddressOf tmrPreset_Tick
            SceneData(I).Automation.tmrDirection = ""


            If I <= PresetsInBank.Length Then    '---------- IS A SAVE FILE ----------------
                Dim a1() As String = Split(PresetsInBank(I - 1), "\")
                Dim NewSceneName As String = Mid(a1(a1.Length - 1), 1, a1(a1.Length - 1).Length - 4)

                Dim NewIndex As Integer = CreateNewScene(NewSceneName, False) '---------- New important bit ----------------


                'FileOpen(1, Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & NewSceneName & ".dmr", OpenMode.Input)
                'Do Until EOF(1)
                Dim fn As String = Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & NewSceneName & ".dmr"
                Using r As StreamReader = New StreamReader(fn)
                    Dim line As String = r.ReadLine()

                    Do While Not line = Nothing
                        Dim a() As String = Split(line, "|")
                        Select Case a(0)
                            Case "P"

                            Case "M"

                            Case "LocIndex"
                                SceneData(NewIndex).LocIndex = Val(a(1))
                            Case "PageNo"
                                SceneData(NewIndex).PageNo = Val(a(1))
                                Dim newLoc As SCLocs
                                newLoc.PageNo = SceneData(NewIndex).PageNo
                                newLoc.PresetIndex = SceneData(NewIndex).LocIndex
                                SceneDataLocations.Add(NewIndex, newLoc)
                            Case "ChangeMS"
                                SceneData(I).Automation.TimeBetweenMinAndMax = a(1)
                            Case Is > 0
                                With SceneData(NewIndex).ChannelValues(a(0))


                                    For Each s As String In a
                                        Dim b() As String = Split(s, ",")
                                        Select Case b(0) 'SceneData(I).ChannelValues(a(0))
                                            Case "v"
                                                .Value = b(1)
                                            Case "TimerEnabled", "timerenabled"
                                                If Convert.ToBoolean(b(1)) = False Then
                                                    .Automation.Mode = AutomationMode.Off
                                                ElseIf Convert.ToBoolean(b(1)) = True Then
                                                    .Automation.Mode = AutomationMode.Chase
                                                End If
                                            Case "AutoTimeBetween"
                                                If b(1) = 0 Then
                                                    .Automation.Interval = 100
                                                Else
                                                    .Automation.Interval = b(1)
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

                                End With

                        End Select
                        line = r.ReadLine

                    Loop

                    'Loop
                    'Dim I2 As Integer = 1
                    'Do Until I2 >= SceneData(I).ChannelValues.Length
                    '    If SceneData(I).ChannelValues(I2).Automation.tTimer Is Nothing Then
                    '        SceneData(I).ChannelValues(I2).Automation.tTimer = New Windows.Forms.Timer
                    '        SceneData(I).ChannelValues(I2).Automation.tTimer.Tag = I & "|" & I2
                    '        AddHandler SceneData(I).ChannelValues(I2).Automation.tTimer.Tick, AddressOf tmrTimer_Tick
                    '    End If
                    '    I2 += 1
                    'Loop
                    'FileClose(1)
                End Using

                UpdatePresetControls(NewIndex)
            End If

            StartupProcess("SC" & I)
            I += 1
        Loop



        If frmChannels.cmbChannelPresetSelection.SelectedIndex = -1 Then frmChannels.cmbChannelPresetSelection.SelectedIndex = 0

    End Sub

    Private Sub cmdReloadPresetLocations_Click(sender As Object, e As EventArgs) Handles cmdReloadPresetLocations.Click
        GeneratePresetFormControls()

        ResetAllPresetControls()

        'RenamePresetFaderControls()

    End Sub
    Private Sub SetupThreads()

        If tChannelsMultipleThreads = False Then
            tChannels(1) = New Thread(AddressOf threadloop)
            tChannels(1).Name = "tChannel"
            tChannels(1).IsBackground = True
            tChannels(1).Start()
        Else
            Dim I As Integer = 0
            Do Until I >= numEndChannel.Value
                tChannels(I) = New Thread(Sub() Me.MultipleThreadLoops(I))
                tChannels(I).Name = "tChannel" & I
                tChannels(I).IsBackground = True
                tChannels(I).Start()
                I += 1
            Loop

        End If

    End Sub

    Sub GeneratePresetFormControls()
        'Run Only on Startup or Location Reset


        tbpPresets.Controls.Clear()
        PresetsPerColumn = 0
        PresetsPerRow = 0

        ' Full graphical reset

        For Each c As Windows.Forms.Control In tbpPresetsControls
            tbpPresets.Controls.Add(c)
        Next

        Dim XUpTo As Integer = 0
        Dim YUpTo As Integer = 0

        Dim RunningColumnNum As Integer = 1


        Dim PresetModifier As Integer = 0
        If cmdPresetP1.BackColor = Color.Red Then PresetModifier = 0
        If cmdPresetP2.BackColor = Color.Red Then PresetModifier = PresetFadersTotal
        If cmdPresetP3.BackColor = Color.Red Then PresetModifier = PresetFadersTotal * 2
        If cmdPresetP4.BackColor = Color.Red Then PresetModifier = PresetFadersTotal * 3
        If cmdPresetP5.BackColor = Color.Red Then PresetModifier = PresetFadersTotal * 4
        If cmdPresetP6.BackColor = Color.Red Then PresetModifier = PresetFadersTotal * 5



        Dim I As Integer = 1
        Do Until I > PresetFaders.Count - 1
            PresetFaders(I).cSceneControl = New SceneControl1
            'If I <= 12 Then
            'PresetFaders(I).OrigLeft = StartX + XUpTo
            'PresetFaders(I).OrigTop = StartY + YUpTo
            'PresetFaders(I).border = New Rectangle(StartX + XUpTo - 1, StartY + YUpTo - 1, 292 + 2, SceneControlHeight + 2)

            'End If
            If I Mod 2 = 0 Then
                'Even
                PresetFaders(I).cSceneControl.BackColor = Color.FromArgb(64, 64, 64)
                PresetFaders(I).cSceneControl.cPresetName.BackColor = Color.FromArgb(32, 32, 32)
            Else
                'Odd
                PresetFaders(I).cSceneControl.BackColor = Color.Black
                PresetFaders(I).cSceneControl.cPresetName.BackColor = Color.Black
            End If


            '(StartX + XUpTo, StartY + YUpTo)
            With PresetFaders(I).cSceneControl
                .SceneIndex = -1
                .PresetFixture = I
                .WithFader = bWithFader

                .Size = New Point(292, SceneControlHeight)
                .vScroll.Visible = .WithFader


                .vScroll.BackColor = frmMain.lblChannelBackColour.BackColor
                .vScroll.FillColor = frmMain.lblChannelFillColour.BackColor
                .vScroll.BulletColor = frmMain.lblChannelBulletColour.BackColor


                .cAutoTime.ForeColor = lblSceneLabelColour.BackColor
                .cAutoTime.Maximum = 100000
                .cAutoTime.Minimum = 0
                .cAutoTime.Value = 800

                .cBlackout.BackColor = lblSceneBlackoutColour.BackColor
                .cBlackout.ForeColor = lblSceneLabelColour.BackColor

                .cFull.BackColor = Color.Black
                .cFull.ForeColor = lblSceneLabelColour.BackColor

                .cPresetName.Text = SceneData(I).SceneName
                .cPresetName.ForeColor = lblSceneLabelColour.BackColor
                .cPresetName.ContextMenuStrip = ctxPresetLabelActions

                .cTxtVal.BackColor = Color.Black
                .cTxtVal.ForeColor = lblSceneLabelColour.BackColor
                .cTxtVal.Text = "0"

            End With


            PresetFaders(I).cSceneControl.Location = New Point(StartX + XUpTo, StartY + YUpTo)
            PresetFaders(I).OrigLeft = StartX + XUpTo
            PresetFaders(I).OrigTop = StartY + YUpTo


            AddHandler PresetFaders(I).cSceneControl.vScroll.ValueChanged, AddressOf cPresetFader_Scroll
            AddHandler PresetFaders(I).cSceneControl.cTxtVal.TextChanged, AddressOf cPresetTxtVal_TextChanged
            AddHandler PresetFaders(I).cSceneControl.cAutoTime.ValueChanged, AddressOf cAutoTime_ValueChanged
            AddHandler PresetFaders(I).cSceneControl.cBlackout.Click, AddressOf cPresetBlackout_Click
            AddHandler PresetFaders(I).cSceneControl.cFull.Click, AddressOf cPresetFull_Click
            AddHandler PresetFaders(I).cSceneControl.cPresetName.MouseMove, AddressOf lblPresetName_MouseMove
            AddHandler PresetFaders(I).cSceneControl.cPresetName.MouseUp, AddressOf lblPresetName_MouseUp


            Try
                tbpPresets.Controls.Add(PresetFaders(I).cSceneControl)
            Catch ex As Exception

            End Try


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
        'PresetsPerRow = I / PresetsPerColumn
        PresetFadersTotal = I


    End Sub

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

    'Private Sub tmrTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If formopened = False Then Exit Sub
    '    Dim SceneIndex As Integer = Split(sender.tag, "|")(0)
    '    Dim ChannelIndex As Integer = Split(sender.tag, "|")(1)


    '    With SceneData(SceneIndex).ChannelValues(ChannelIndex)
    '        Dim newchanval As Integer = .Value

    '        If .Automation.Mode = AutomationMode.Chase Then

    '            ' List In Order
    '            If .Automation.ProgressInOrder = True Then
    '                If .Automation.CurrentIofList >= .Automation.ProgressList.Count - 1 Then
    '                    .Automation.CurrentIofList = 0
    '                    If .Automation.ProgressLoop = False Then
    '                        .Automation.StopTimer()
    '                    End If
    '                Else
    '                    .Automation.CurrentIofList += 1
    '                    newchanval = .Automation.ProgressList(.Automation.CurrentIofList)
    '                End If
    '            End If

    '            ' List Timed Random
    '            If .Automation.ProgressRandomTimed = True Then
    '                .Automation.CurrentIofList = GetRandom(0, .Automation.ProgressList.Count)
    '                newchanval = .Automation.ProgressList(.Automation.CurrentIofList)
    '            End If

    '            ' List Sound Random
    '            If .Automation.ProgressSoundActivated = True And SoundActivationCurrentLevel >= .Automation.SoundActivationThreshold Then
    '                .Automation.CurrentIofList = GetRandom(0, .Automation.ProgressList.Count)
    '                newchanval = .Automation.ProgressList(.Automation.CurrentIofList)
    '            End If



    '        ElseIf .Automation.Mode = AutomationMode.Sine Then

    '            Dim time As Double = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) / 1000.0 ' Convert ticks to seconds

    '            newchanval = CInt((.Automation.oscAmplitude / 2) * Math.Sin(2 * Math.PI * .Automation.oscFrequency * time + (.Automation.oscPhase * .Automation.oscIndex)) + .Automation.oscCenter)

    '            If newchanval < 0 Then newchanval = 0
    '            If newchanval > 255 Then newchanval = 255



    '        ElseIf .Automation.Mode = AutomationMode.Square Then

    '        ElseIf .Automation.Mode = AutomationMode.Triangle Then

    '            Dim variance As Integer = (.Automation.oscAmplitude / 2) + .Automation.oscCenter
    '            If newchanval >= variance Then
    '                .Automation.oscDirection = "Decreasing"
    '            ElseIf newchanval <= 255 - variance Then
    '                .Automation.oscDirection = "Increasing"
    '            End If

    '            ' Increment or decrement the channelValue accordingly
    '            If .Automation.oscDirection = "Increasing" Then
    '                newchanval += CInt(.Automation.oscAmplitude * .Automation.oscFrequency * .Automation.Interval / 1000)
    '            Else
    '                newchanval -= CInt(.Automation.oscAmplitude * .Automation.oscFrequency * .Automation.Interval / 1000)
    '            End If

    '        End If


    '        .Value = newchanval

    '        ' After .Value is changed update controls
    '        If frmChannels.cmbChannelPresetSelection.SelectedIndex = SceneIndex - 1 Then ' And tbcControls1.SelectedTab Is frmChannels Then
    '            frmChannels.UpdateFixtureLabel(ChannelIndex)

    '            Dim I As Integer = 1
    '            Do Until I >= ChannelFaders.Count
    '                If Not ChannelFaders(I) Is Nothing Then
    '                    If ChannelFaders(I).iChannel = ChannelIndex Then
    '                        ChannelFaders(I).dmrvs.Value = .Value
    '                        Exit Do
    '                    End If
    '                    If ChannelIndex < Val(ChannelFaders(I).iChannel) Then Exit Do
    '                End If

    '                I += 1
    '            Loop

    '        End If

    '    End With


    'End Sub
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

        'RenamePresetFaderControls()
        ResetAllPresetControls()



        TopSet = False
        LeftSet = False
    End Sub
    Public Sub StartChannelTimers(ByVal Sceneindex As Integer, ByVal IsEnabled As Boolean)
        Dim I As Integer = 1
        If Sceneindex = -1 Then
            Exit Sub
        End If
        Do Until I >= SceneData(Sceneindex).ChannelValues.Length
            If SceneData(Sceneindex).ChannelValues(I).Automation Is Nothing Then
                Exit Sub
            End If
            With SceneData(Sceneindex).ChannelValues(I).Automation

                'If .RunTimer = True And IsEnabled = True Then
                If Not .Mode = AutomationMode.Off And IsEnabled = True Then
                    If .IsEnabled = False Then
                        If .ProgressRandomTimed = True Or .ProgressRandomTimed = True Then
                            .CurrentIofList = GetRandom(0, .ProgressList.Count - 1)
                        Else
                            .CurrentIofList = 0
                        End If

                        .StartTimer()
                    End If
                ElseIf IsEnabled = False Then
                    .IsEnabled = False
                    .CurrentIofList = 0
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

                .Automation.tTimer.StartTimer()
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
                .Automation.tTimer.StartTimer()
            End With
        End If
    End Sub
    'Private Sub tmrPreset_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If formopened = False Then Exit Sub
    '    Dim I As Integer = sender.Tag
    '    If SceneData(I).Automation.tmrDirection = "Down" Then
    '        If (SceneData(I).MasterValue - SceneData(I).Automation.IntervalSteps) <= 0 Then
    '            SceneData(I).Automation.tTimer.StopTimer()
    '            SceneData(I).Automation.tmrDirection = "lol"
    '            SceneData(I).MasterValue = 0
    '            StartChannelTimers(I, False)
    '            'PresetFaders(getpres
    '        Else
    '            SceneData(I).MasterValue -= SceneData(I).Automation.IntervalSteps
    '        End If
    '    ElseIf SceneData(I).Automation.tmrDirection = "Up" Then
    '        If (SceneData(I).MasterValue + SceneData(I).Automation.IntervalSteps) >= 100 Then
    '            SceneData(I).Automation.tTimer.StopTimer()
    '            SceneData(I).Automation.tmrDirection = "lol"
    '            SceneData(I).MasterValue = 100
    '        Else
    '            SceneData(I).MasterValue += SceneData(I).Automation.IntervalSteps
    '        End If
    '    ElseIf SceneData(I).Automation.tmrDirection = "lol" Then
    '        SceneData(I).Automation.tTimer.StopTimer()
    '    ElseIf SceneData(I).Automation.tmrDirection = "" Then
    '        SceneData(I).Automation.tTimer.StopTimer()
    '    End If
    '    If SceneData(I).MasterValue > 0 Then StartChannelTimers(I, True)

    '    'PresetVisualUpdate = True
    '    'If I > PresetFaderControlModifier And I <= (PresetFaderControlModifier + PresetFadersTotal) Then
    '    '    PresetFaders(I - PresetFaderControlModifier).cTxtVal.Text = SceneData(I).MasterValue
    '    'End If
    '    'PresetVisualUpdate = False
    '    UpdatePresetControls(I)
    'End Sub
    Private Function CreateNewScene(ByVal SceneName As String, ByVal AutoUpdate As Boolean, Optional ByVal PresetFixtureIndex As Integer = -1) As Integer
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

        lstDramaPresets.Items.Add(SceneName)
        lstSongEditPresets.Items.Add(SceneName)

        If PresetFaders(PresetFadersTotal).cSceneControl Is Nothing Then
            SceneData(IemptyScene).PageNo = -1
        Else
            If PresetFaders(PresetFadersTotal).cSceneControl.cPresetName.Text = "" Then
                'If PresetFixtureIndex = -1 Then
                SceneData(IemptyScene).PageNo = CurrentPageNo
            Else
                SceneData(IemptyScene).PageNo = -1
            End If
        End If

        SceneData(IemptyScene).LocIndex = PresetFixtureIndex

        Dim I1 As Integer = 1

        SceneData(IemptyScene).MasterValue = 0 ' Set Default
        SceneData(IemptyScene).Automation.TimeBetweenMinAndMax = 1000 ' Set Default
        SceneData(IemptyScene).Automation.Max = 100 ' Set Default
        SceneData(IemptyScene).Automation.Min = 0 ' Set Default
        SceneData(IemptyScene).Automation.tmrDirection = ""
        frmChannels.cmbChannelPresetSelection.Items.Add(SceneData(IemptyScene).SceneName)

        Do Until I1 >= ChannelFaders.Count

            With SceneData(IemptyScene).ChannelValues(I1)

                If I1 = 36 Then
                    .Value = 42
                Else
                    .Value = 0
                End If
                .Automation = New cChannelAutomation(IemptyScene, I1, 10)
                '.Automation.Interval = 10
                '.Automation.IsEnabled = False
                '.Automation.ChannelIndex = I1
                '.Automation.SceneIndex = IemptyScene
                '.Automation.ProgressInOrder = True
                '.Automation.ProgressLoop = False
                '.Automation.ProgressRandomTimed = False
                '.Automation.ProgressSoundActivated = False
                '.Automation.SoundActivationThreshold = 500
                '.Automation.Mode = AutomationMode.Off
                '.Automation.ProgressList = New List(Of Integer)
                '.Automation.CurrentIofList = 0

                '.Automation.oscPhase = 0.1
                '.Automation.oscFrequency = 100
                '.Automation.oscCenter = 127
                '.Automation.oscAmplitude = 255

                '.Automation.SoundAttack = 0
                '.Automation.SoundLevel = 0
                '.Automation.SoundRelease = 0



            End With
            Try
                'Thread.Sleep(5)

                'AddHandler SceneData(IemptyScene).ChannelValues(I1).Automation.tTimer.Tick, AddressOf tmrTimer_Tick

            Catch ex As Exception

            End Try

            I1 += 1
        Loop
        If Not PresetFixtureIndex = -1 Then
            ' exists
            PresetFaders(PresetFixtureIndex).cSceneControl.SceneIndex = IemptyScene
        End If
        If AutoUpdate Then
            UpdatePresetControls(IemptyScene)
        End If

        Return IemptyScene
    End Function
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
        'RenamePresetFaderControls()
        ResetAllPresetControls()
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

        If obj.SceneIndex = -1 Then
            'is new scene
            Dim newname As String = InputBox("Please Enter New Scene Name:", "New Scene", "")
            If newname = "" Then Exit Sub

            PresetFaders(obj.PresetFixture).cSceneControl.cPresetName.Text = newname


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

        UpdatePresetControls(obj.SceneIndex)
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
                        .Automation.tTimer.StartTimer()
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
                If formopened = True Then
                    DMXdata.SendChannelData(Dmxno) = LargestNo
                End If
            Next Dmxno
            'Dim Iuniverse As Integer = 0
            'Do Until Iuniverse >= DMXdata.packet.Length
            '    Socket.SendTo(DMXdata.packet(Iuniverse).toBytes(), DMXdata.toAddrA)
            '    Socket.SendTo(DMXdata.packet(Iuniverse).toBytes(), DMXdata.toAddrB)
            '    'socket.SendTo(packet(univ).toBytes(), toAddrLocalhost)
            '    Iuniverse += 1
            'Loop


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

            DMXdata.SendChannelData(DMXno) = LargestNo

            ' Next DMXChannelNumber
            GoTo LoopsDone
SkipLoops:

            Thread.Sleep(10)
LoopsDone:
            Thread.Sleep(5)
        Loop
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

    Private Sub UpdateVuMeter(ByVal indx As Integer)

        'barVUmeter.Value = 100 - AudioRun.UpdateVuMeter(indx)
    End Sub
    Private Sub updatePlayer()
        tmrchangedmp3 = True
        'If lstPresetsSongs.SelectedItems.Count = 0 Then Exit Sub
        Dim Qindex As Integer = AudioRun.GetMusicCueIndex(lstPresetsSongs.SelectedItem)

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
        PositionMilli = Math.Round(PositionMilli, 2)

        lblPresetsMP3PositionMilli.Text = Math.Round(PositionMilli, 2)
        lblMusicMP3PositionMilli.Text = PositionMilli
        lblDramaViewMP3PositionMilli.Text = PositionMilli
        lbleditPositionMilli.Text = PositionMilli

        ' Start Vu meter

        UpdateVuMeter(Qindex)

        ' End Vu Meter

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

                            If Not SongDictSorted1(CurrentSongChangeIndex).Key.SceneIndex = -1 Then
                                If SongDictSorted1(CurrentSongChangeIndex).Key.TimeToGoDown = 0 Then
                                    SceneData(SongDictSorted1(CurrentSongChangeIndex).Key.SceneIndex).MasterValue = 0
                                    StartChannelTimers(SongDictSorted1(CurrentSongChangeIndex).Key.SceneIndex, False)
                                    UpdatePresetControls(SongDictSorted1(CurrentSongChangeIndex).Key.SceneIndex)
                                Else
                                    SceneData(SongDictSorted1(CurrentSongChangeIndex).Key.SceneIndex).Automation.tmrDirection = "Down"
                                    SceneData(SongDictSorted1(CurrentSongChangeIndex).Key.SceneIndex).Automation.IntervalSteps = SceneData(SongDictSorted1(CurrentSongChangeIndex).Key.SceneIndex).Automation.Max / (SongDictSorted1(CurrentSongChangeIndex).Key.TimeToGoDown / SceneData(SongDictSorted1(CurrentSongChangeIndex).Key.SceneIndex).Automation.tTimer.Interval)
                                    SceneData(SongDictSorted1(CurrentSongChangeIndex).Key.SceneIndex).Automation.tTimer.StartTimer()
                                End If
                            End If
                        End If
                        CurrentSongChangeIndex = IsongChange
                        If Not SongDictSorted1(IsongChange).Key.SceneIndex = -1 Then
                            If SongDictSorted1(IsongChange).Key.TimeToGoUp = 0 Then

                                SceneData(SongDictSorted1(IsongChange).Key.SceneIndex).MasterValue = 100
                                If CurrentSongChangeIndex >= 0 Then
                                    StartChannelTimers(SongDictSorted1(CurrentSongChangeIndex).Key.SceneIndex, True)
                                End If
                                UpdatePresetControls(SongDictSorted1(IsongChange).Key.SceneIndex)

                            Else
                                SceneData(SongDictSorted1(IsongChange).Key.SceneIndex).Automation.tmrDirection = "Up"
                                SceneData(SongDictSorted1(IsongChange).Key.SceneIndex).Automation.IntervalSteps = SceneData(SongDictSorted1(IsongChange).Key.SceneIndex).Automation.Max / (SongDictSorted1(IsongChange).Key.TimeToGoUp / SceneData(SongDictSorted1(IsongChange).Key.SceneIndex).Automation.tTimer.Interval)
                                SceneData(SongDictSorted1(IsongChange).Key.SceneIndex).Automation.tTimer.StartTimer()
                            End If
                            lstPresetsSongChanges1.Items(CurrentSongChangeIndex).BackColor = lblSongChangeColour.BackColor
                            lstMusicSongChanges1.Items(CurrentSongChangeIndex).BackColor = lblSongChangeColour.BackColor
                            lstDramaViewSongChanges1.Items(CurrentSongChangeIndex).BackColor = lblSongChangeColour.BackColor
                        End If
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
        'If lstPresetsSongs2.SelectedItems.Count = 0 Then Exit Sub

        Dim Qindex As Integer = AudioRun.GetMusicCueIndex(lstPresetsSongs2.SelectedItem)

        Dim PositionMilli As Double = 0 ' Math.Round(Player.controls.currentPosition, 2)
        If MusicCues(Qindex).IsMP3 = True Then
            'If ASIOMode = True Then
            lblPresetsMP3Duration2.Text = AudioRun.TotalTime(MusicCues(Qindex).SongFileName) 'MusicCues(Qindex).AudioReader.TotalTime.ToString("mm\:ss")
            lblPresetsMP3Position2.Text = AudioRun.CurrentPosition(MusicCues(Qindex).SongFileName) ' MusicCues(Qindex).AudioReader.CurrentTime.ToString("mm\:ss")
            PositionMilli = Val(AudioRun.CurrentPosition(MusicCues(Qindex).SongFileName, True)) 'MusicCues(Qindex).AudioReader.CurrentTime.ToString("ss\.ff")
            'Else
            'lblPresetsMP3Duration.Text = MusicCues(Qindex).mp3Reader.TotalTime.ToString("mm\:ss")
            'lblPresetsMP3Position.Text = MusicCues(Qindex).mp3Reader.CurrentTime.ToString("mm\:ss")
            'PositionMilli = MusicCues(Qindex).mp3Reader.CurrentTime.ToString("ss\.ff")
            'End If

            ' Display Current Time Position and Duration

            lblMusicMP3Duration2.Text = lblPresetsMP3Duration2.Text
            lblDramaViewMP3Duration2.Text = lblPresetsMP3Duration2.Text

            lblMusicMP3Position2.Text = lblPresetsMP3Position2.Text
            lblDramaViewMP3Position2.Text = lblPresetsMP3Position2.Text

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
                        If CurrentSongChangeIndex2 = IsongChange Then Exit Do 'Already on it
                        ' scene should be up to here
                        If CurrentSongChangeIndex2 = -1 Then 'first change of song
                            cmdPresetsBlackoutAllInstant_Click(Nothing, Nothing)
                        Else
                            If SongDictSorted1(CurrentSongChangeIndex2).Key.TimeToGoDown = 0 Then
                                SceneData(SongDictSorted1(CurrentSongChangeIndex2).Key.SceneIndex).MasterValue = 0
                                StartChannelTimers(SongDictSorted1(CurrentSongChangeIndex2).Key.SceneIndex, False)
                                UpdatePresetControls(SongDictSorted1(CurrentSongChangeIndex2).Key.SceneIndex)
                            Else
                                SceneData(SongDictSorted1(CurrentSongChangeIndex2).Key.SceneIndex).Automation.tmrDirection = "Down"
                                SceneData(SongDictSorted1(CurrentSongChangeIndex2).Key.SceneIndex).Automation.IntervalSteps = SceneData(SongDictSorted1(CurrentSongChangeIndex2).Key.SceneIndex).Automation.Max / (SongDictSorted1(CurrentSongChangeIndex2).Key.TimeToGoDown / SceneData(SongDictSorted1(CurrentSongChangeIndex2).Key.SceneIndex).Automation.tTimer.Interval)
                                SceneData(SongDictSorted1(CurrentSongChangeIndex2).Key.SceneIndex).Automation.tTimer.StartTimer()
                            End If
                        End If
                        CurrentSongChangeIndex2 = IsongChange
                        If SongDictSorted1(IsongChange).Key.TimeToGoUp = 0 Then
                            SceneData(SongDictSorted1(IsongChange).Key.SceneIndex).MasterValue = 100
                            If CurrentSongChangeIndex2 >= 0 Then StartChannelTimers(SongDictSorted1(CurrentSongChangeIndex2).Key.SceneIndex, True)
                            UpdatePresetControls(SongDictSorted1(IsongChange).Key.SceneIndex)
                        Else
                            SceneData(SongDictSorted1(IsongChange).Key.SceneIndex).Automation.tmrDirection = "Up"
                            SceneData(SongDictSorted1(IsongChange).Key.SceneIndex).Automation.IntervalSteps = SceneData(SongDictSorted1(IsongChange).Key.SceneIndex).Automation.Max / (SongDictSorted1(IsongChange).Key.TimeToGoUp / SceneData(SongDictSorted1(IsongChange).Key.SceneIndex).Automation.tTimer.Interval)
                            SceneData(SongDictSorted1(IsongChange).Key.SceneIndex).Automation.tTimer.StartTimer()
                        End If
                        lstPresetsSongChanges2.Items(CurrentSongChangeIndex2).BackColor = lblSongChangeColour.BackColor
                        lstMusicSongChanges2.Items(CurrentSongChangeIndex2).BackColor = lblSongChangeColour.BackColor
                        lstDramaViewSongChanges2.Items(CurrentSongChangeIndex2).BackColor = lblSongChangeColour.BackColor
                        Exit Do

                    End If
                End If
                IsongChange += 1
            Loop

        End If

        tmrchangedmp3 = False

    End Sub
    Public Sub ResetAllPresetControls()
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

        Dim resetI As Integer = 1
        Do Until resetI > PresetFadersTotal 'clears presetfaders
            PresetFaders(resetI).cSceneControl.SceneIndex = -1
            PresetFaders(resetI).cSceneControl.cPresetName.Text = ""
            PresetFaders(resetI).cSceneControl.cBlackout.BackColor = lblSceneBlackoutColour.BackColor
            PresetFaders(resetI).cSceneControl.cFull.BackColor = Color.Black
            PresetFaders(resetI).cSceneControl.cTxtVal.Text = 0
            PresetFaders(resetI).cSceneControl.vScroll.Value = 0

            resetI += 1
        Loop

        Dim I As Integer = 1
        Do Until I >= SceneData.Length
            If SceneData(I).PageNo = CurrentPageNo Then
                If SceneData(I).LocIndex <> -1 Then
                    ' Has full location data
                    UpdatePresetControls(I)
                End If
            End If
            I += 1
        Loop

        I = 1
        Do Until I >= SceneData.Length
            If SceneData(I).PageNo = -1 Or (SceneData(I).PageNo = CurrentPageNo And SceneData(I).LocIndex = -1) Then
                ' MISSING  location data
                Dim I2 As Integer = 1
                Do Until I2 >= PresetFaders.Length
                    If Not PresetFaders(I2).cSceneControl Is Nothing Then
                        If PresetFaders(I2).cSceneControl.SceneIndex = -1 Then
                            SceneData(I).PageNo = CurrentPageNo
                            SceneData(I).LocIndex = I2
                            UpdatePresetControls(I)
                            Exit Do
                        End If
                    End If

                    I2 += 1
                Loop

            End If
            I += 1
        Loop


    End Sub

    Public Sub UpdatePresetControls(ByVal SceneI As Integer) 'ByVal Value As Integer, 
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

        PresetVisualUpdate = True



        ' Needs Some PageNo and LocIndex Logic from old RenamePresetFaderControls



        ' Loop where PageNo is set
        If SceneData(SceneI).PageNo = CurrentPageNo Then
            If SceneData(SceneI).LocIndex > -1 Then
                If SceneData(SceneI).LocIndex > PresetFadersTotal Then
                    ' Has page set to this page, but would appear offscreen
                    ' reset location
                    SceneData(SceneI).LocIndex = -1
                    SceneData(SceneI).PageNo = -1
                Else

                    If PresetFaders(SceneData(SceneI).LocIndex).cSceneControl.SceneIndex = SceneI Then
                        'This scene is in this Preset Slot
                        UpdatePresetFromScene(SceneData(SceneI).LocIndex, SceneI)
                    ElseIf PresetFaders(SceneData(SceneI).LocIndex).cSceneControl.SceneIndex = -1 Then
                        'Preset is empty and available for a Scene

                        PresetFaders(SceneData(SceneI).LocIndex).cSceneControl.SceneIndex = SceneI
                        UpdatePresetFromScene(SceneData(SceneI).LocIndex, SceneI)
                    Else
                        ' Preset Location was already taken. Set attempted Scene to Locationless -1
                        SceneData(SceneI).LocIndex = -1
                        If ResaveOnSceneLoad = True Then
                            SaveScene(SceneData(SceneI).SceneName)
                        End If
                        'UpdatePresetFromScene(SceneData(SceneI).LocIndex, SceneI)
                    End If

                End If

            End If
        End If


        PresetVisualUpdate = False
    End Sub
    Private Sub UpdatePresetFromScene(ByVal PresetI As Integer, ByVal SceneI As Integer)

        With PresetFaders(PresetI).cSceneControl

            .SceneIndex = SceneI

            .cAutoTime.Value = SceneData(SceneI).Automation.TimeBetweenMinAndMax
            .cPresetName.Text = SceneData(SceneI).SceneName
            .cTxtVal.Text = Math.Round(SceneData(SceneI).MasterValue, 0)
            .vScroll.Value = Val(.cTxtVal.Text)

            If SceneData(SceneI).MasterValue = 0 Then
                .cBlackout.BackColor = lblSceneBlackoutColour.BackColor
                .cFull.BackColor = Color.Black
            ElseIf SceneData(SceneI).MasterValue = 100 Then
                .cBlackout.BackColor = Color.Black
                .cFull.BackColor = lblSceneUpColour.BackColor
            Else

                If SceneData(SceneI).Automation.tTimer.IsTimerRunning = True And SceneData(SceneI).Automation.tmrDirection = "Up" Then
                    .cBlackout.BackColor = Color.Black
                    .cFull.BackColor = ControlPaint.Light(lblSceneUpColour.BackColor)
                ElseIf SceneData(SceneI).Automation.tTimer.IsTimerRunning = True And SceneData(SceneI).Automation.tmrDirection = "Down" Then
                    .cBlackout.BackColor = ControlPaint.LightLight(lblSceneBlackoutColour.BackColor)
                    .cFull.BackColor = lblSceneUpColour.BackColor

                End If

            End If
        End With
    End Sub

    Private Sub cmdPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPresetsPlay.Click, cmdEditPlay.Click, cmdDramaViewPlay.Click, cmdMusicPlay.Click
        If lstPresetsSongs.SelectedIndex = -1 Then Exit Sub

        Dim Qindex As Integer = AudioRun.GetMusicCueIndex(lstPresetsSongs.SelectedItem)


        If cmdPresetsPlay.Text = "Play" Then


            If MusicCues(Qindex).IsMP3 = True Then
                AudioRun.Volume = trkMusicVolume.Value
                AudioRun.mPlay(MusicCues(Qindex).SongFileName)
                tmrMP3.Start()





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
                tmrMP3.Stop()

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
                tmrMP3.Start()

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

        Dim Qindex As Integer = AudioRun.GetMusicCueIndex(lstPresetsSongs.SelectedItem)
        If MusicCues(Qindex).IsMP3 = True Then

            AudioRun.mStop(MusicCues(Qindex).SongFileName)
            tmrMP3.Stop()

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
            Dim Qindex As Integer = AudioRun.GetMusicCueIndex(lstPresetsSongs.SelectedItem)
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
        Dim Qindex As Integer = AudioRun.GetMusicCueIndex(lstPresetsSongs.SelectedItem)
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
        'lstPresetsSongs2.SelectedIndex = iSelectIndex
        'lstMusicSongs2.SelectedIndex = iSelectIndex
        'lstDramaViewSongs2.SelectedIndex = iSelectIndex
        Dim Qindex As Integer = AudioRun.GetMusicCueIndex(lstPresetsSongs2.SelectedItem)


        If cmdPresetsPlay2.Text = "Play" Then


            If MusicCues(Qindex).IsMP3 = True Then
                AudioRun.Volume = trkMusicVolume2.Value
                AudioRun.mPlay(MusicCues(Qindex).SongFileName)
                tmrMP32.Start()




            ElseIf MusicCues(Qindex).IsSCS = True Then
                Dim OSCmessage = New SharpOSC.OscMessage("/cue/go ,s " & MusicCues(Qindex).SCSinfo.Qname)
                Dim sendOSC = New SharpOSC.UDPSender(SCSIPaddress, SCSPort)
                sendOSC.Send(OSCmessage)

                MusicCues(Qindex).SCSinfo.swElapsed.Start()




            End If

            tmrMP32.Interval = 50
            'frmMain.tmrMP3.Start()
            'frmMain.updatePlayer()


            If lstPresetsSongChanges2.Items.Count > 0 Then
                'Dim a() As String = Split(lstPresetsSongChanges.Items.Item(0), "|")
                CurrentSongChangeIndex = -1
                lstPresetsSongChanges2.SelectedIndices.Clear()
                lstMusicSongChanges2.SelectedIndices.Clear()
                lstDramaViewSongChanges2.SelectedIndices.Clear()
            End If

            cmdPresetsPlay2.Text = "Pause"
            cmdMusicPlay2.Text = "Pause"
            cmdDramaViewPlay2.Text = "Pause"

            Exit Sub
        ElseIf cmdPresetsPlay2.Text = "Pause" Then

            If MusicCues(Qindex).IsMP3 = True Then
                AudioRun.mPause(MusicCues(Qindex).SongFileName)


            ElseIf MusicCues(Qindex).IsSCS = True Then

                Dim OSCmessage = New SharpOSC.OscMessage("/cue/pauseresume ,s " & MusicCues(Qindex).SCSinfo.Qname)
                Dim sendOSC = New SharpOSC.UDPSender(SCSIPaddress, SCSPort)
                sendOSC.Send(OSCmessage)

                MusicCues(Qindex).SCSinfo.swElapsed.Stop()

            End If
            '            tmrMP3.Enabled = False

            cmdPresetsPlay2.Text = "Resume"
            cmdMusicPlay2.Text = "Resume"
            cmdDramaViewPlay2.Text = "Resume"
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

            '            tmrMP3.Start()

            cmdPresetsPlay2.Text = "Pause"
            cmdMusicPlay2.Text = "Pause"
            cmdDramaViewPlay2.Text = "Pause"

            Exit Sub
        End If
    End Sub

    Private Sub cmdStop2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPresetsStop2.Click, cmdDramaViewStop2.Click, cmdMusicStop2.Click

        Dim Qindex As Integer = AudioRun.GetMusicCueIndex(lstPresetsSongs2.SelectedItem)
        If MusicCues(Qindex).IsMP3 = True Then

            AudioRun.mStop(MusicCues(Qindex).SongFileName)
            tmrMP32.Stop()

        ElseIf MusicCues(Qindex).IsSCS = True Then
            MusicCues(Qindex).SCSinfo.swElapsed.Reset()

            Dim OSCmessage = New SharpOSC.OscMessage("/cue/stop ,s " & MusicCues(Qindex).SCSinfo.Qname)
            Dim sendOSC = New SharpOSC.UDPSender(SCSIPaddress, SCSPort)
            sendOSC.Send(OSCmessage)

        End If

        CurrentSongChangeIndex2 = -1
        cmdPresetsPlay2.Text = "Play"
        cmdDramaViewPlay2.Text = "Play"
        cmdMusicPlay2.Text = "Play"

        ResetSongChangeBackColours()

        lstPresetsSongs2.Enabled = True
        lstMusicSongs2.Enabled = True
        lstDramaViewSongs2.Enabled = True
    End Sub

    Private Sub cmdSkip2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPresetsSkip2.Click, cmdDramaViewSkip2.Click, cmdMusicSkip2.Click
        If lstPresetsSongs2.Items.Count >= (lstPresetsSongs2.SelectedIndex + 1) Then
            Dim Qindex As Integer = AudioRun.GetMusicCueIndex(lstPresetsSongs2.SelectedItem)
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
            cmdPresetsPlay2.Text = "Play"
            cmdMusicPlay2.Text = "Play"
            cmdDramaViewPlay2.Text = "Play"
            lstPresetsSongs2.Enabled = True

            If lstPresetsSongs2.Items.Count > lstPresetsSongs2.SelectedIndex + 1 Then
                lstPresetsSongs2.SelectedIndex += 1
                cmdPlay2_Click(sender, e)
            Else
                cmdStop2_Click(sender, e)
            End If

        End If
    End Sub

    Private Sub trkVolume2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trkPresetsVolume2.Scroll, trkDramaViewVolume2.Scroll, trkMusicVolume2.Scroll
        Dim Qindex As Integer = AudioRun.GetMusicCueIndex(lstPresetsSongs2.SelectedItem)
        Dim vol As Integer = sender.Value
        If MusicCues(Qindex).IsMP3 = True Then
            'MusicCues(Qindex).waveOut.Volume = (sender.Value / 100)
            'MusicCues(Qindex).AudioReader.Volume = (sender.Value / 100)
            AudioRun.Volume = trkMusicVolume2.Value
        Else
        End If

        'Player.settings.volume = sender.Value
        trkPresetsVolume2.Value = vol 'MusicCues(Qindex).waveOut.Volume * 100
        trkDramaViewVolume2.Value = vol 'MusicCues(Qindex).waveOut.Volume * 100
        trkMusicVolume2.Value = vol 'MusicCues(Qindex).waveOut.Volume * 100
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

    Private Sub LoadMusicTracks(Optional ByVal MusicCueIndex As Integer = -1)
        'MsgBox("Needs rewrite")
        'Exit Sub

        lstPresetsSongs.Items.Clear()
        lstPresetsSongs2.Items.Clear()
        lstMusicSongs.Items.Clear()
        lstMusicSongs2.Items.Clear()
        lstDramaViewSongs.Items.Clear()
        lstDramaViewSongs2.Items.Clear()

        Dim I1 As Integer = 0
        Do Until I1 >= MusicCues.Length
            If MusicCues(I1).SongFileName <> "" Then
                AudioRun.mStop(MusicCues(I1).SongFileName)
                tmrMP3.Stop()
            End If

            MusicCues(I1).SongFileName = ""
            MusicCues(I1).IsMP3 = False
            MusicCues(I1).IsSCS = False
            MusicCues(I1).AsioOutIndex = 1
            MusicCues(I1).SongChangesDict = Nothing
            MusicCues(I1).SongChanges = Nothing
            I1 += 1
        Loop
        AudioRun.ClearTracks()



        Dim I As Integer = 0
        Dim MusicMP3InBank() As String = Directory.GetFiles(Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\", "*.mp3")
        Do Until I >= MusicMP3InBank.Length
            'Dim a() As String = Split(MusicMP3InBank(I), "\")
            Dim songname As String = Path.GetFileNameWithoutExtension(MusicMP3InBank(I))
            If File.Exists(Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & songname & " resampled.mp3") = True Then
                ' A resampled file exists
                songname = songname & " resampled"
            End If
            'If Microsoft.VisualBasic.Right(MusicMP3InBank(I), 13) = "resampled.mp3" And File.Exists(Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & Mid(songname, 1, songname.Length - 9) & ".mp3") = True Then
            ' Is a resampled file and original still exists
            'GoTo skipme
            'End If

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

            AudioRun.PrepareTrack(MusicMP3InBank(I))

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
            If Not newline = "" Then
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
            End If

            'SongChanges1.Add(NewSongChange)

        Loop
        FileClose(2)
    End Sub
    Private Sub lstSongs_Changed(ByVal songname As String)

        Dim Qindex As Integer = AudioRun.GetMusicCueIndex(songname)

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

        'Stopped = 0
        'Playing = 1
        'Paused = 2

        If AudioRun.TrackStatus(songname) = 0 Then
            'Stopped
            cmdPresetsPlay.Text = "Play"
            cmdDramaViewPlay.Text = "Play"
            cmdEditPlay.Text = "Play"
            cmdMusicPlay.Text = "Play"
        ElseIf AudioRun.TrackStatus(songname) = 1 Then
            'Stopped
            cmdPresetsPlay.Text = "Pause"
            cmdDramaViewPlay.Text = "Pause"
            cmdEditPlay.Text = "Pause"
            cmdMusicPlay.Text = "Pause"
        ElseIf AudioRun.TrackStatus(songname) = 2 Then
            'Stopped
            cmdPresetsPlay.Text = "Resume"
            cmdDramaViewPlay.Text = "Resume"
            cmdEditPlay.Text = "Resume"
            cmdMusicPlay.Text = "Resume"
        End If

        'AfterChgFile:


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
    Dim OtherIndexChanged2 As Boolean = False
    Private Sub lstSongs2_Changed(ByVal songname As String)

        Dim Qindex As Integer = AudioRun.GetMusicCueIndex(songname)

        lstPresetsSongChanges2.Items.Clear()
        lstMusicSongChanges2.Items.Clear()
        lstDramaViewSongChanges2.Items.Clear()

        Dim SongDictSorted1 = From entry In MusicCues(Qindex).SongChangesDict Order By entry.Value Select entry

        Dim I As Integer = 0
        Do Until I >= SongDictSorted1.Count
            Dim newrow As New ListViewItem
            newrow.Text = SongDictSorted1(I).Value
            newrow.SubItems.Add(SongDictSorted1(I).Key.SceneName)
            newrow.SubItems.Add(SongDictSorted1(I).Key.TimeToGoUp)
            newrow.SubItems.Add(SongDictSorted1(I).Key.TimeToGoDown)
            lstMusicSongChanges2.Items.Add(newrow)
            lstPresetsSongChanges2.Items.Add(newrow.Clone)
            lstDramaViewSongChanges2.Items.Add(newrow.Clone)
            I += 1
        Loop

        'Stopped = 0
        'Playing = 1
        'Paused = 2

        If AudioRun.TrackStatus(songname) = 0 Then
            'Stopped
            cmdPresetsPlay2.Text = "Play"
            cmdDramaViewPlay2.Text = "Play"
            cmdMusicPlay2.Text = "Play"
        ElseIf AudioRun.TrackStatus(songname) = 1 Then
            'Stopped
            cmdPresetsPlay2.Text = "Pause"
            cmdDramaViewPlay2.Text = "Pause"
            cmdMusicPlay2.Text = "Pause"
        ElseIf AudioRun.TrackStatus(songname) = 2 Then
            'Stopped
            cmdPresetsPlay2.Text = "Resume"
            cmdDramaViewPlay2.Text = "Resume"
            cmdMusicPlay2.Text = "Resume"
        End If


        'AfterChgFile:


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



    Private Sub lstDramaViewSongs2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstDramaViewSongs2.SelectedIndexChanged
        If sender.SelectedIndex = -1 Then Exit Sub
        If OtherIndexChanged2 = True Then Exit Sub
        OtherIndexChanged2 = True

        lstMusicSongs2.SelectedIndex = lstDramaViewSongs2.SelectedIndex
        lstPresetsSongs2.SelectedIndex = lstDramaViewSongs2.SelectedIndex
        lstSongs2_Changed(lstDramaViewSongs2.SelectedItem)
        OtherIndexChanged2 = False
    End Sub
    Private Sub lstMusicSongs2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMusicSongs2.SelectedIndexChanged
        If sender.SelectedIndex = -1 Then Exit Sub
        If OtherIndexChanged2 = True Then Exit Sub
        OtherIndexChanged2 = True

        lstDramaViewSongs2.SelectedIndex = lstMusicSongs2.SelectedIndex
        lstPresetsSongs2.SelectedIndex = lstMusicSongs2.SelectedIndex
        lstSongs2_Changed(lstMusicSongs2.SelectedItem)
        OtherIndexChanged2 = False
    End Sub
    Private Sub lstPresetsSongs2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstPresetsSongs2.SelectedIndexChanged
        If sender.SelectedIndex = -1 Then Exit Sub
        If OtherIndexChanged2 = True Then Exit Sub
        OtherIndexChanged2 = True

        lstMusicSongs2.SelectedIndex = lstPresetsSongs2.SelectedIndex
        lstDramaViewSongs2.SelectedIndex = lstPresetsSongs2.SelectedIndex
        lstSongs2_Changed(lstPresetsSongs2.SelectedItem)
        OtherIndexChanged2 = False
    End Sub


#End Region

#Region "Banks"
    Private Sub cmdBankNew_Click(sender As Object, e As EventArgs) Handles cmdBankNew.Click
        Dim s As String = InputBox("Name of new bank:")
        If s = "" Then Exit Sub
        Directory.CreateDirectory(Application.StartupPath & "\Save Files\" & s)
        Try
            File.Copy(Application.StartupPath & "\0 Blackout.dmr", Application.StartupPath & "\Save Files\" & s & "\0 Blackout.dmr")
        Catch ex As Exception

        End Try

        LoadBankTextToListBox(s)
    End Sub

    Private Sub cmdBankRename_Click(sender As Object, e As EventArgs) Handles cmdBankRename.Click

        If lstBanks.SelectedIndex = -1 Then Exit Sub
        Dim s As String = InputBox("Name of new bank:")
        If s = "" Then Exit Sub
        Directory.Move(Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem, Application.StartupPath & "\Save Files\" & s)
        LoadBankTextToListBox(s)
    End Sub

    Private Sub cmd4KSize_Click(sender As Object, e As EventArgs) Handles cmd4KSize.Click
        frmMain.Size = New Point(3840, 2160)
    End Sub

    Private Sub lstBanks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstBanks.SelectedIndexChanged
        If formopened = False Then Exit Sub

        BankChanged = True
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

        LoadScenesFromFile()

        LoadMusicTracks()

        'RenamePresetFaderControls()
        ResetAllPresetControls()

        BankChanged = False
        SaveSettingsToFile()
        tbcControls1.SelectedTab = tbpPresets
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
        'If Not tTouchPadLoad Is Nothing Then tTouchPadLoad.Abort()
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
        'frmTouchPad.Show()
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
                chanline &= "AutomationMode," & .Automation.Mode & "|"
                'chanline &= "TimerEnabled," & .Automation.RunTimer & "|"
                chanline &= "AutoTimeBetween," & .Automation.Interval & "|"
                chanline &= "RandomStart," & .Automation.ProgressRandomTimed & "|"

                chanline &= "InOrder," & .Automation.ProgressInOrder & "|"
                chanline &= "RandomSound," & .Automation.ProgressSoundActivated & "|"
                chanline &= "SoundThreshold," & .Automation.SoundActivationThreshold & "|"
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
                        .Automation.tTimer.StartTimer()
                    End With
                End If
            ElseIf SceneData(I).MasterValue = 0 Then 'preset is at blackout
                If isDramaPresetSelected(I) = True Then
                    With SceneData(I)
                        .Automation.tmrDirection = "Up"
                        .Automation.IntervalSteps = 255 / (.Automation.TimeBetweenMinAndMax / .Automation.tTimer.Interval)
                        .Automation.tTimer.StartTimer()
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
        If formopened = False Then Exit Sub
        If PagingChanged = True Then Exit Sub
        If Not vsMaster.Value = Val(sender.text) Then
            vsMaster.Value = Val(sender.text)
        End If
    End Sub

    Private Sub cmdMasterFull_Click(sender As Object, e As EventArgs) Handles cmdMasterFull.Click
        'frmTouchPad.cmdMasterUp.BackColor = Color.Red
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
        'frmTouchPad.cmdMasterUp.BackColor = controlcolour
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

        frmChannels.SetColours()


    End Sub

    Private Sub cmdChannelBackColour_Click(sender As Object, e As EventArgs) Handles cmdChannelBackColour.Click
        Dim coldialog As New ColorDialog
        coldialog.Color = lblChannelBackColour.BackColor
        coldialog.ShowDialog()
        lblChannelBackColour.BackColor = coldialog.Color

        frmChannels.SetColours()

    End Sub

    Private Sub cmdChannelFillColour_Click(sender As Object, e As EventArgs) Handles cmdChannelFillColour.Click
        Dim coldialog As New ColorDialog
        coldialog.Color = lblChannelFillColour.BackColor
        coldialog.ShowDialog()
        lblChannelFillColour.BackColor = coldialog.Color

        frmChannels.SetColours()

    End Sub
    Private Sub cmdChannelNumberColour_Click(sender As Object, e As EventArgs) Handles cmdChannelNumberColour.Click
        Dim coldialog As New ColorDialog
        coldialog.Color = lblChannelNumberColour.BackColor
        coldialog.ShowDialog()
        lblChannelNumberColour.BackColor = coldialog.Color

        frmChannels.SetColours()

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
        numFadeIn.Value = 0
        numFadeOut.Value = 0
        'txtEditTime.Text = ""
        Dim I As Integer = 1
        Do Until I >= SceneData.Length
            ' If SceneData(I).MasterValue = 0 Then 'preset is above blackout
            Dim J As Integer = 0
            Do Until J >= lstSongEditPresets.SelectedItems.Count
                If lstSongEditPresets.SelectedItems(J) = SceneData(I).SceneName Then

                    With SceneData(I)
                        .Automation.tmrDirection = "Up"
                        .Automation.IntervalSteps = 255 / (.Automation.TimeBetweenMinAndMax / .Automation.tTimer.Interval)
                        .Automation.tTimer.StartTimer()
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

        Dim Qindex As Integer = AudioRun.GetMusicCueIndex(lstMusicSongs.SelectedItem)
        If MusicCues(Qindex).IsMP3 = True Then


            AudioRun.CurrentPosition(MusicCues(Qindex).SongFileName) = vSongEdit.Value

            'Dim I As Integer = 0
            'If lst Then
            '    Do Until I


            '        Else

        End If



        updatePlayer()

    End Sub

    Private Sub cmdCreatelink_Click(sender As Object, e As EventArgs) Handles cmdCreatelink.Click
        If lstSongEditPresets.SelectedIndex = -1 Then Exit Sub
        Dim Qindex As Integer = AudioRun.GetMusicCueIndex(lstMusicSongs.SelectedItem)
        If MusicCues(Qindex).IsMP3 = False Then
            Exit Sub
        End If

        Dim newrow As New ListViewItem
        newrow.Text = lbleditPositionMilli.Text 'AudioRun.CurrentPosition(MusicCues(Qindex).SongFileName, True)
        newrow.SubItems.Add(lstSongEditPresets.SelectedItem)
        newrow.SubItems.Add(numFadeIn.Value)
        newrow.SubItems.Add(numFadeOut.Value)

        Dim NewSongChange As New SongChangesStr

        NewSongChange.TimeCode = newrow.Text
        NewSongChange.SceneName = newrow.SubItems(1).Text
        NewSongChange.SceneIndex = GetSceneIndex(newrow.SubItems(1).Text)
        NewSongChange.TimeToGoUp = newrow.SubItems(2).Text
        NewSongChange.TimeToGoDown = newrow.SubItems(3).Text

        MusicCues(Qindex).SongChangesDict.Add(NewSongChange, lbleditPositionMilli.Text)

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
        Dim Qindex As Integer = AudioRun.GetMusicCueIndex(lstMusicSongs.SelectedItem)
        If MusicCues(Qindex).IsMP3 = False Then
            Exit Sub
        End If

        'Dim defaultnewname As String = lstSongEditPresets.SelectedItem
        'Dim newname As String = InputBox("Enter name of new Scene preset", , defaultnewname & " copy")

        'If newname = "" Then Exit Sub
        'Dim newI As Integer = CreateNewScene(newname)
        Dim oldindex As Integer = GetSceneIndex(lstSongEditPresets.SelectedItem)
        'SceneData(newI).ChannelValues = SceneData(oldindex).ChannelValues
        'Array.Copy(SceneData(oldindex).ChannelValues, SceneData(newI).ChannelValues, SceneData(oldindex).ChannelValues.Length)

        'SceneData(newI).LocIndex = -1
        'SceneData(newI).Automation = SceneData(oldindex).Automation
        Dim newI As Integer = DuplicateExistingScene(oldindex)




        ' Update the listboxes directly

        'Dim newrow As New ListViewItem
        'newrow.Text = lbleditPositionMilli.Text 'AudioRun.CurrentPosition(MusicCues(Qindex).SongFileName, True)
        'newrow.SubItems.Add(SceneData(newI).SceneName)
        'newrow.SubItems.Add(numFadeIn.Value)
        'newrow.SubItems.Add(numFadeOut.Value)

        Dim NewSongChange As New SongChangesStr

        NewSongChange.TimeCode = AudioRun.CurrentPosition(MusicCues(Qindex).SongFileName, True)
        NewSongChange.SceneName = SceneData(newI).SceneName
        NewSongChange.SceneIndex = newI
        NewSongChange.TimeToGoUp = numFadeIn.Value
        NewSongChange.TimeToGoDown = numFadeOut.Value

        MusicCues(Qindex).SongChangesDict.Add(NewSongChange, NewSongChange.TimeCode)

        ResortSongChange1FromDictionary(Qindex)

    End Sub

    Private Sub cmdEditSongSave_Click(sender As Object, e As EventArgs) Handles cmdEditSongSave.Click
        Dim Qindex As Integer = AudioRun.GetMusicCueIndex(lstSongEditPresets.SelectedItem)

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
        If lstMusicSongChanges1.SelectedItems.Count = 0 Then
            txtEditTime.Text = ""
            Exit Sub
        End If
        If chkEnableSongEdit.Visible = True And chkEnableSongEdit.Checked = False Then Exit Sub
        If EditUpdate = True Then Exit Sub
        Song1EditingOrig = New SongChangesStr

        Dim selrow As ListViewItem = lstMusicSongChanges1.SelectedItems(0)

        lstSongEditPresets.SelectedItem = selrow.SubItems(1).Text
        txtEditTime.Text = Math.Round(Val(selrow.Text), 2)
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
        If txtEditTime.Text = "" Then Exit Sub
        Dim Qindex As Integer = AudioRun.GetMusicCueIndex(lstMusicSongs.SelectedItem)

        EditUpdate = True

        Dim newchange As New SongChangesStr

        'lstMusicSongChanges1.Items(lstMusicSongChanges1.SelectedIndex) = txtEditTime.Text & "|" & lstSongEditPresets.SelectedItem & "|" & numFadeIn.Value & "|" & numFadeOut.Value
        newchange.TimeCode = Math.Round(Val(txtEditTime.Text), 2)
        newchange.SceneName = lstSongEditPresets.SelectedItem
        newchange.SceneIndex = GetSceneIndex(lstSongEditPresets.SelectedItem)
        newchange.TimeToGoUp = numFadeIn.Value
        newchange.TimeToGoDown = numFadeOut.Value



        If lstMusicSongChanges1.SelectedItems.Count = 0 Then
            'nothing Is new




            'Exit Sub
        Else

            'Dim oldSceneName As String = lstMusicSongChanges1.SelectedItems(0).SubItems(1).Text
            'Dim SongDictSorted1 = From entry In MusicCues(Qindex).SongChangesDict Order By entry.Value Select entry

            For Each sitem In MusicCues(Qindex).SongChangesDict
                If Math.Round(sitem.Value, 2) = Song1EditingOrig.TimeCode And sitem.Key.SceneIndex = Song1EditingOrig.SceneIndex Then
                    MusicCues(Qindex).SongChangesDict.Remove(sitem.Key)
                    Exit For
                End If
            Next

        End If

        MusicCues(Qindex).SongChangesDict.Add(newchange, newchange.TimeCode)
        'SongChanges1.Item(lstMusicSongChanges1.SelectedItems(0).Index) = newchange

        Song1EditingOrig = newchange
        ResortSongChange1FromDictionary(Qindex)
        Dim Idx As Integer = 0
        Do Until Idx >= lstMusicSongChanges1.Items.Count
            If lstMusicSongChanges1.Items(Idx).SubItems(0).Text = newchange.TimeCode Then
                lstMusicSongChanges1.Items(Idx).Selected = True
            End If
            Idx += 1
        Loop

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
                ArduDMX.SetComPort = I
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
    Private Function DuplicateExistingScene(ByVal iOld As Integer) As Integer

        Dim oldname As String = SceneData(iOld).SceneName

        Dim newname As String = InputBox("Please Enter New Scene Name:", "New Scene", oldname & " 2")
        If newname = "" Then
            Return -1
        End If
        Dim newI As Integer = CreateNewScene(newname, True)

        'SceneData(newI).ChannelValues = SceneData(obj.SceneIndex).ChannelValues
        Array.Copy(SceneData(iOld).ChannelValues, SceneData(newI).ChannelValues, SceneData(iOld).ChannelValues.Length)

        SceneData(newI).Automation = SceneData(iOld).Automation
        SceneData(newI).Automation.tTimer = New NamedTimer(newI, 100)
        SceneData(newI).Automation.tTimer.SceneIndex = newI
        'AddHandler SceneData(newI).Automation.tTimer.Tick, AddressOf tmrPreset_Tick


        SaveScene(newname)
        Return newI
        'UpdatePresetControls(newI)
        ResetAllPresetControls()
    End Function

    Private Sub DuplicateSceneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateSceneToolStripMenuItem.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)
        Dim obj As SceneControl1 = cms.SourceControl.Parent

        If obj.SceneIndex = -1 Then Exit Sub

        DuplicateExistingScene(obj.SceneIndex)


    End Sub

    Private Sub ctxDramaEditChannels_Click(sender As Object, e As EventArgs) Handles ctxDramaEditChannels.Click
        If tbcControls1.SelectedTab Is tbpScriptChanges Then
            If lstDramaPresets.SelectedIndex = -1 Then Exit Sub

            frmChannels.cmbChannelPresetSelection.SelectedItem = lstDramaPresets.SelectedItem
            ChannelFaderPageCurrentSceneDataIndex = GetSceneIndex(lstDramaPresets.SelectedItem)

        ElseIf tbcControls1.SelectedTab Is tbpMusic Then
            If lstSongEditPresets.SelectedIndex = -1 Then Exit Sub

            frmChannels.cmbChannelPresetSelection.SelectedItem = lstSongEditPresets.SelectedItem
            ChannelFaderPageCurrentSceneDataIndex = GetSceneIndex(lstSongEditPresets.SelectedItem)

        End If

        frmChannels.BringToFront()
    End Sub

    Private Sub ctxDramaSaveScene_Click(sender As Object, e As EventArgs) Handles ctxDramaSaveScene.Click
        If tbcControls1.SelectedTab Is tbpScriptChanges Then
            If lstDramaPresets.SelectedIndex = -1 Then Exit Sub

            SaveScene(lstDramaPresets.SelectedItem)

        ElseIf tbcControls1.SelectedTab Is tbpMusic Then
            If lstSongEditPresets.SelectedIndex = -1 Then Exit Sub

            SaveScene(lstSongEditPresets.SelectedItem)

        End If

    End Sub


    Private Sub ctxDramaRenameScene_Click(sender As Object, e As EventArgs) Handles ctxDramaRenameScene.Click
        Dim scindx As Integer = -1
        If tbcControls1.SelectedTab Is tbpScriptChanges Then
            If lstDramaPresets.SelectedIndex = -1 Then Exit Sub

            scindx = GetSceneIndex(lstDramaPresets.SelectedItem)

        ElseIf tbcControls1.SelectedTab Is tbpMusic Then
            If lstSongEditPresets.SelectedIndex = -1 Then Exit Sub

            scindx = GetSceneIndex(lstSongEditPresets.SelectedItem)

        End If



        'If scindx = -1 Then
        '    'is new scene
        '    Dim newname As String = InputBox("Please Enter New Scene Name:", "New Scene", "")
        '    If newname = "" Then Exit Sub


        '    PresetFaders(obj.PresetFixture).cSceneControl.cPresetName.Text = newname


        '    lstDramaPresets.Items.Add(newname)
        '    lstSongEditPresets.Items.Add(newname)
        '    CreateNewScene(newname, obj.PresetFixture)
        '    SaveScene(newname)
        'Else
        '    'Scene exists
        '    Dim oldname As String = SceneData(obj.SceneIndex).SceneName
        '    Dim newname As String = InputBox("Please Enter New Scene Name:", "Editing Scene #" & obj.SceneIndex, SceneData(obj.SceneIndex).SceneName)
        '    If newname = "" Then Exit Sub

        '    SceneData(obj.SceneIndex).SceneName = newname
        '    PresetFaders(obj.PresetFixture).cSceneControl.cPresetName.Text = newname

        '    Dim cmbIndx As Integer = frmChannels.cmbChannelPresetSelection.Items.IndexOf(oldname)
        '    frmChannels.cmbChannelPresetSelection.Items.Item(cmbIndx) = newname

        '    cmbIndx = lstDramaPresets.Items.IndexOf(oldname)
        '    lstDramaPresets.Items.Item(cmbIndx) = newname

        '    File.Move(Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & oldname & ".dmr", Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem & "\" & newname & ".dmr")
        '    SaveScene(newname)
        'End If

        'RenamePresetFaderControls()
    End Sub

    Private Sub ctxDramaDuplicateScene_Click(sender As Object, e As EventArgs) Handles ctxDramaDuplicateScene.Click
        Dim scindx As Integer = 0
        If tbcControls1.SelectedTab Is tbpScriptChanges Then
            If lstDramaPresets.SelectedIndex = -1 Then Exit Sub

            scindx = GetSceneIndex(lstDramaPresets.SelectedItem)

        ElseIf tbcControls1.SelectedTab Is tbpMusic Then
            If lstSongEditPresets.SelectedIndex = -1 Then Exit Sub

            scindx = GetSceneIndex(lstSongEditPresets.SelectedItem)

        End If

        If scindx = -1 Then Exit Sub

        DuplicateExistingScene(scindx)

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

    Private Sub cmdSetMarsConsole_Click(sender As Object, e As EventArgs) Handles cmdSetMarsConsole.Click
        If lstCOMdevices.SelectedItems.Count = 0 Then Exit Sub
        Dim I As Integer = 0
        Do Until I >= Arduinos.Length
            If Arduinos(I).PortNo = lstCOMdevices.SelectedItems(0).Text Then
                Arduinos(I).Job = ArduinoModes.ctlMarsConsole
                lstCOMdevices.SelectedItems(0).SubItems(3).Text = ArduinoModes.ctlMarsConsole
            End If
            I += 1
        Loop
        SaveArduinoAssignments()
    End Sub

    Private Sub cmdCOMDisconnect_Click(sender As Object, e As EventArgs) Handles cmdCOMDisconnect.Click
        Dim I As Integer = 0
        Do Until I >= Arduinos.Count
            Try
                If Arduinos(I).Serial.PortName = lstCOMdevices.SelectedItems(0).SubItems(0).Text Then
                    Arduinos(I).Serial.Close()
                    lstCOMdevices.SelectedItems(0).SubItems(2).Text = "Closed"
                    Exit Sub
                End If
            Catch ex As Exception

            End Try


            I += 1
        Loop

    End Sub

    Private Sub cmdSendAll_Click(sender As Object, e As EventArgs) Handles cmdSendAll.Click
        MarsConsole.SendAll()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        MarsConsole.SendHello()
    End Sub

    Private Sub cmdSubmitIssue_Click(sender As Object, e As EventArgs) Handles cmdSubmitIssue.Click
        If txtGithubIssue.Text = "" Then Exit Sub
        FileOpen(2, Application.StartupPath & "\accesstoken.txt", OpenMode.Input)
        Dim accessToken As String = LineInput(2)
        FileClose(2)
        Dim owner = "Teckiee"
        Dim repo = "KnightLight"
        Dim title = "Issue from App"
        Dim body = txtGithubIssue.Text

        SubmitGitHubIssue(accessToken, owner, repo, title, body)
        txtGithubIssue.Text = ""
    End Sub
    Sub SubmitGitHubIssue(accessToken As String, owner As String, repo As String, title As String, body As String)
        Dim GitHubApiUrl As String = $"https://api.github.com/repos/{owner}/{repo}/issues"

        Using client As New HttpClient()
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}")
            client.DefaultRequestHeaders.Add("User-Agent", "VB.NET GitHub Issue Creator")

            Dim issueData = New With {
                .title = title,
                .body = body
            }
            Dim jsonPayload = JsonConvert.SerializeObject(issueData)
            Dim content = New StringContent(jsonPayload, Encoding.UTF8, "application/json")

            Dim response = client.PostAsync(GitHubApiUrl, content).Result

            If response.IsSuccessStatusCode Then
                Console.WriteLine("Issue created successfully.")
            Else
                Console.WriteLine($"Failed to create issue: {response.StatusCode} - {response.ReasonPhrase}")
            End If
        End Using
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

    Private Sub lstDramaPresets_MouseDown(sender As Object, e As MouseEventArgs) Handles lstDramaPresets.MouseDown, lstSongEditPresets.MouseDown
        If e.Button = MouseButtons.Right Then
            sender.SelectedIndex = sender.IndexFromPoint(e.X, e.Y)
        End If
    End Sub

End Class

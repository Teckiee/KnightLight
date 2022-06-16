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
Public Class FormContainer
    Private Sub FormContainer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmContainer = Me

        'Dim cwv As New nsCustomWaveViewer.CustomWaveViewer

        'Me.Controls.Add(cwv)

        frmTouchPad = New FormTouchPad
        frmDimmerAutomation = New FormDimmerAutomation
        frmGradientColour = New FormColourGradient
        frmCustomColourPicker = New FormColourPicker
        frmBanks = New FormBanks
        frmScenes = New FormScenes
        frmChannels = New FormChannels
        frmMusicEditor = New FormMusicEditor
        frmQuickChanges = New FormQuickChanges
        frmSettings = New FormSettings

        frmBanks.MdiParent = frmContainer
        frmScenes.MdiParent = frmContainer
        frmChannels.MdiParent = frmContainer
        frmMusicEditor.MdiParent = frmContainer
        frmQuickChanges.MdiParent = frmContainer
        frmSettings.MdiParent = frmContainer


        SetupSerialConnections()

        Player.settings.autoStart = False
        Player2.settings.autoStart = False
        With frmMusicEditor.tmrMP3
            .Interval = 50
            .Start()
            .Enabled = False
        End With
        Player.controls.stop()
        Player.settings.volume = 50

        With frmMusicEditor.tmrMP32
            .Interval = 50
            .Start()
            .Enabled = False
        End With
        Player2.controls.stop()
        Player2.settings.volume = 50

        For Each c As Windows.Forms.Control In frmScenes.Controls
            FormPresetsControls.Add(c)
        Next

        For Each c As Windows.Forms.Control In frmChannels.Controls
            FormChannelsControls.Add(c)
        Next

        For Each c As System.Windows.Forms.Control In frmChannels.Controls
            AddHandler c.KeyDown, AddressOf frmChannels.Form1_KeyDown
            AddHandler c.KeyUp, AddressOf frmChannels.Form1_KeyUp
        Next c

        If Environment.GetCommandLineArgs.Length > 1 Then
            If Environment.GetCommandLineArgs(1) = "-Testmode" Then Testmode = True
        End If
        If File.Exists(Application.StartupPath & "\Testmode.txt") = True Then Testmode = True

        controlcolour = Me.BackColor


        'tbpPresetsControls = tbpPresets.Controls
        ' tbpChannelsControls = tbpChannels.Controls

        frmBanks.LoadBanksFromFile()
        LoadSettingsFromFile()
        LoadFixtureInformation()

        frmScenes.LoadScenesFromFile()
        frmScenes.GeneratePresetFormControls()
        frmScenes.RenamePresetFaderControls()

        frmChannels.GenerateChannelFormControls()
        frmMusicEditor.LoadMusicTracks()

        Application.DoEvents()
        SetupThreads()



        If Testmode = False Then
            EnttecOpenDMX.OpenDMX.start()
        End If



        Me.BackColor = Color.Black
        frmBanks.BackColor = Color.Black
        frmScenes.BackColor = Color.Black
        frmChannels.BackColor = Color.Black
        frmMusicEditor.BackColor = Color.Black
        frmQuickChanges.BackColor = Color.Black
        frmSettings.BackColor = Color.Black
        frmDimmerAutomation.BackColor = Color.Black

        ChannelFaderPageCurrentSceneDataIndex = 1
        frmBanks.Show()
        frmChannels.Show()
        frmScenes.Show()
        formopened = True
    End Sub
    Private Sub FormContainer_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ' Form is closing, so shutdown player
        Player.close()
        Player2.close()
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
        tCrashResist.Abort()
        File.Delete(Application.StartupPath & "\Crashresist\Dmrs.txt")
        Application.Exit()

    End Sub

#Region "Arduino Connections"
    Sub SetupSerialConnections()
        ' Show all available COM ports.
        'For Each sp As String In My.Computer.Ports.SerialPortNames
        'ListBox1.Items.Add(sp)
        'Next

        'When the form loads
        'Enumerate available Com ports and add to ComboBox1
        Dim comPorts = Ports.SerialPort.GetPortNames

        Dim ArduinoCount As Integer = 0
        For i = 0 To UBound(comPorts)
            Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE Caption like '%(" & comPorts(i) & "%'")
            For Each queryObj As ManagementObject In searcher.Get()
                If InStr((CStr(queryObj("Caption"))), "Arduino") > 0 Then
                    'is an arduino
                    Arduinos(ArduinoCount).DeviceName = (CStr(queryObj("Caption")))
                    Arduinos(ArduinoCount).PortNo = comPorts(i)
                    ArduinoCount += 1
                End If

            Next

            'Arduinos(i).Serial = My.Computer.Ports.OpenSerialPort(comPorts(i))
            'Arduinos(i).Serial.BaudRate = 115200
            'SerialPort1.BaudRate = 115200
            'SerialPort1.Parity = Ports.Parity.None
            'SerialPort1.StopBits = IO.Ports.StopBits.One
            'SerialPort1.DataBits = 8
        Next
        Dim J As Integer = 0
        Do Until J >= Arduinos.Length
            If Arduinos(J).DeviceName <> "" Then
                Try
                    Arduinos(J).Serial = New Ports.SerialPort
                    Arduinos(J).Serial.BaudRate = 115200
                    Arduinos(J).Serial.PortName = Arduinos(J).PortNo
                    Arduinos(J).Serial.DataBits = 8
                    Arduinos(J).Serial.StopBits = IO.Ports.StopBits.One
                    Arduinos(J).Serial.Handshake = IO.Ports.Handshake.None
                    Arduinos(J).Serial.Parity = IO.Ports.Parity.None
                    Arduinos(J).Serial.Open()
                    AddHandler Arduinos(J).Serial.DataReceived, AddressOf SerialPort_DataReceived
                    Arduinos(J).Serial.Write("UID," & Arduinos(J).PortNo & vbCrLf)
                Catch
                    Arduinos(J).Serial.Close()
                End Try

            End If


            J += 1
        Loop
        'Set ComboBox1 text to first available port

        'Set remaining port attributes

    End Sub
    Structure msg1
        Dim msg As String
        Dim portname As String
    End Structure

    Delegate Sub myMethodDelegate(ByVal [text] As msg1)
    Dim myD1 As New myMethodDelegate(AddressOf myShowStringMethod)

    Private Sub SerialPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) ' Handles SerialPort.DataReceived
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


        Else
            'txtSerialIn.AppendText(myString)
        End If


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
                frmSettings.lblArduino1.Text = "Arduino1: " & Arduinos(I).UID
            End If

        ElseIf Mid(mymsg.msg, 1, 3) = "AVU" Then
            'Serial.println("AVU," + incomingAudio);
            Dim a() As String = Split(mymsg.msg, ",")
            If a.Length = 2 Then ' not 2 = data garbled
                frmSettings.lblAudioActive.Text = a(1)

            End If
        Else
            'txtSerialIn.AppendText(myString)
        End If
        frmSettings.txtSerialIn.AppendText(mymsg.msg)
    End Sub

#End Region


#Region "Startup application"


    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub LoadFixtureInformation()
        FileOpen(1, Application.StartupPath & "\Fixtures.ini", OpenMode.Input)
        Dim I As Integer = 1
        Do Until EOF(1)
            Dim sline() As String = Split(LineInput(1), "|")
            Dim ParentChannelNo As Integer = Val(sline(0))
            FixtureControls(ParentChannelNo).BackColour = Color.FromName(sline(2))
            FixtureControls(ParentChannelNo).ForeColour = Color.FromName(sline(3))
            FixtureControls(ParentChannelNo).FixtureName = sline(1)
            FixtureControls(ParentChannelNo).IsFirst = True
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
                    frmSettings.numEndChannel.Value = a(1)
                Case "DimmerChannelRows"
                    ChannelControlSetsPerPage = a(1)
                Case "LoadonChange"
                    'chkLoadonChange.Checked = a(1)
                    frmSettings.chkLoadonChange.Checked = Convert.ToBoolean(a(1))
                Case "LastBank"
                    frmBanks.lstBanks.SetSelected(frmBanks.lstBanks.FindString(a(1)), True)
                Case "ChannelBulletColour"
                    frmSettings.lblChannelBulletColour.BackColor = Color.FromArgb(a(1))
                Case "ChannelBackColour"
                    frmSettings.lblChannelBackColour.BackColor = Color.FromArgb(a(1))
                Case "ChannelFillColour"
                    frmSettings.lblChannelFillColour.BackColor = Color.FromArgb(a(1))
                Case "ChannelNumberColour"
                    frmSettings.lblChannelNumberColour.BackColor = Color.FromArgb(a(1))
                Case "SceneBulletColour"
                    'lblSceneBulletColour.BackColor = Color.FromName(a(1))
                    frmSettings.lblSceneBlackoutColour.BackColor = Color.FromArgb(a(1))
                Case "SceneBackColour"
                    frmSettings.lblSceneUpColour.BackColor = Color.FromArgb(a(1))
                Case "SceneFillColour"
                    frmSettings.lblSceneFillColour.BackColor = Color.FromArgb(a(1))
                Case "SceneLabelColour"
                    frmSettings.lblSceneLabelColour.BackColor = Color.FromArgb(a(1))
                Case "MultipleThreadCount"
                    tChannelsMultipleThreads = Convert.ToBoolean(a(1))

            End Select
        Loop
        FileClose(1)

    End Sub


    Private Sub SetupThreads()

        If tChannelsMultipleThreads = False Then
            tChannels(1) = New Thread(AddressOf threadloop)
            tChannels(1).Name = "tChannel"
            tChannels(1).Start()
        Else
            Dim I As Integer = 0
            Do Until I >= frmSettings.numEndChannel.Value
                tChannels(I) = New Thread(Sub() Me.MultipleThreadLoops(I))
                tChannels(I).Name = "tChannel" & I
                tChannels(I).Start()
                I += 1
            Loop

        End If

        tCrashResist = New Thread(AddressOf CrashResistLoop)
        tCrashResist.Name = "tCrashResist"
        tCrashResist.Start()


    End Sub



#End Region

#Region "ThreadLoop Stuff"
    Private Sub threadloop()
        Do While closethreads = False

            For DMXChannelNumber = 1 To frmSettings.numEndChannel.Value ' Looping through channels


                If DMXChannelNumber = 1 Then
                    'Dim ts As String = ""

                End If
                Dim LargestNo As Integer = 0
                Dim I As Integer = 1
                Do Until I >= SceneData.Count ' Looping through Scenes
                    If BankChanged = True Then GoTo SkipLoops
                    If Not SceneData(I).ChannelValues Is Nothing Then
                        If (((SceneData(I).ChannelValues(DMXChannelNumber).Value / 100) * SceneData(I).MasterValue) / 100) * frmScenes.vsMaster.Value > LargestNo Then
                            LargestNo = (((SceneData(I).ChannelValues(DMXChannelNumber).Value / 100) * SceneData(I).MasterValue) / 100) * frmScenes.vsMaster.Value
                        End If
                    End If
                    I += 1
                Loop
                If Not SentChannelValues(DMXChannelNumber) = LargestNo Then

                    SetChannelData(DMXChannelNumber, LargestNo)
                    SentChannelValues(DMXChannelNumber) = LargestNo


                End If
            Next DMXChannelNumber
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
                    If (((SceneData(I).ChannelValues(DMXno).Value / 100) * SceneData(I).MasterValue) / 100) * frmScenes.vsMaster.Value > LargestNo Then
                        LargestNo = (((SceneData(I).ChannelValues(DMXno).Value / 100) * SceneData(I).MasterValue) / 100) * frmScenes.vsMaster.Value
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

    Private Sub CrashResistLoop()
        'Do
        '    FileOpen(100, Application.StartupPath & "\Crashresist\Dmrs.txt", OpenMode.Output)
        '    For I = 1 To SentChannelValues.Length - 1
        '        PrintLine(100, I & "=" & SentChannelValues(I))
        '    Next
        '    FileClose(100)
        '    Thread.Sleep(1000)
        'Loop
    End Sub
    Private Sub SetChannelData(ByVal Channel As Integer, ByVal Value As Integer)

        If Testmode = True Then Exit Sub
        EnttecOpenDMX.OpenDMX.setDmxValue(Channel, Value)
    End Sub

    Private Sub mnuBanks_Click(sender As Object, e As EventArgs) Handles mnuBanks.Click
        frmBanks.Show()
        frmBanks.WindowState = FormWindowState.Maximized
        For Each f As Form In frmContainer.MdiChildren
            If TypeOf f Is FormBanks Then
                f.Activate()
                Exit Sub
            End If
        Next
    End Sub

    Private Sub mnuScenes_Click(sender As Object, e As EventArgs) Handles mnuScenes.Click
        frmScenes.Show()
        For Each f As Form In frmContainer.MdiChildren
            If TypeOf f Is FormScenes Then
                f.Activate()
                Exit Sub
            End If
        Next
    End Sub

    Private Sub mnuChannels_Click(sender As Object, e As EventArgs) Handles mnuChannels.Click
        frmChannels.Show()
        For Each f As Form In frmContainer.MdiChildren
            If TypeOf f Is FormChannels Then
                f.Activate()
                Exit Sub
            End If
        Next
    End Sub

    Private Sub mnuMusicEditor_Click(sender As Object, e As EventArgs) Handles mnuMusicEditor.Click
        frmMusicEditor.Show()
        For Each f As Form In frmContainer.MdiChildren
            If TypeOf f Is FormMusicEditor Then
                f.Activate()
                Exit Sub
            End If
        Next
    End Sub

    Private Sub mnuQuickChanges_Click(sender As Object, e As EventArgs) Handles mnuQuickChanges.Click
        frmQuickChanges.Show()
        For Each f As Form In frmContainer.MdiChildren
            If TypeOf f Is FormQuickChanges Then
                f.Activate()
                Exit Sub
            End If
        Next
    End Sub

    Private Sub mnuSettings_Click(sender As Object, e As EventArgs) Handles mnuSettings.Click
        frmSettings.Show()
        For Each f As Form In frmContainer.MdiChildren
            If TypeOf f Is FormSettings Then
                f.Activate()
                Exit Sub
            End If
        Next
    End Sub
#End Region

End Class
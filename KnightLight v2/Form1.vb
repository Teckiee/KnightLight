Option Strict Off
Option Explicit On
Imports System.IO
Imports EnttecOpenDMX.OpenDMX
Imports Midi
Imports System.Threading
'Imports System.Collections.Generic

Public Class Form1

    Dim WithEvents Player As New WMPLib.WindowsMediaPlayer
    Dim WithEvents Player2 As New WMPLib.WindowsMediaPlayer

    'Dim MP3 As New MP3Class

    Dim opened As Boolean = False
    Dim Testmode As Boolean = False
    Dim controlcolour As Color

    Dim DimmerControls(1024) As DimmerControls1
    'Dim FixtureChannelLocations(512) As FixtureChannelLocations1          'Has Fixture data specific to the Dimmer Channels
    'Dim FixtureControls(512) As FixtureControls1  'Has Parent Fixture only data
    'Dim FixtureChannels(512) As FixtureChannels1  'Has Child one-to-many data on specific fixture channels
    Dim PresetControls(40) As PresetControls1

    'Dim MS As Integer = 0 'MP3.MP3PositionInMS
    Dim S As Integer = 0 'Math.Round(MS / 1000)
    Dim M As Integer = 0 'Math.Round(S / 60)

    Dim ctxmnuFixtureChild(500) As ToolStripMenuItem

    Dim currentview As String = "Channels"

    Dim MidiButtons(72) As MidiButtons1

    'Dim Mp3Changes(1000) As MP3changes1
    Dim NextMP3Change As Double
    Dim tmrchangedmp3 As Boolean = False
    Dim NextMP3Change2 As Double
    Dim tmrchangedmp32 As Boolean = False

    Dim tmrMasterUpto As Integer
    Dim tmrMasterWay As String
    Dim tmrMasterInterval As Integer


    Structure MidiButtons1
        Dim MidiNoteName As String
        Dim ChannelNum As String
        'Dim ToggleModeIsOn As Boolean
        Dim CurrentSituation As Boolean
    End Structure

    Structure MP3changes1
        Dim PresetName As String
        Dim Time As Integer
    End Structure

    Structure PresetControls1
        Dim vScroll As GScrollBar
        Dim vtxtBox As TextBox
        Dim clbl As Label
        Dim Automation As Automation1
        Dim Dmrs() As DimmerControls1
    End Structure

    Structure DimmerControls1
        Dim vScroll As GScrollBar 'VScrollBar
        Dim sButton As Button
        Dim vtxtBox As TextBox
        Dim clbl As Label
        'Dim tTimer As Timer
        Dim flbl As Label
        Dim vDimmable As Boolean
        Dim Fixtures As FixtureDetails1
        Dim Automation As Automation1
    End Structure

    Structure FixtureDetails1
        Dim StartDimmer As Integer 'Start of whole Fixture
        Dim FixtureName As String 'Name of Fixture
        Dim Backcolour As Color
        Dim Forecolour As Color
        Dim ChannelCount As Integer 'Number of channels in whole fixture
        Dim ChannelNum As Integer 'channel number within fixture
        Dim ChannelName As String 'Current name of the fixture channel (can change - depends on Fixturestring)
        Dim FixtureString As String 'String of name and channel number 1-many

    End Structure

    Structure Automation1
        Dim Nickname As String
        Dim tTimer As System.Windows.Forms.Timer
        Dim Max As Integer
        Dim Min As Integer
        Dim Interval As Double
        Dim curposDouble As Double
        Dim randomstart As Boolean
        Dim Timebetween As Integer
        Dim tmrUpto As Integer
        Dim tmrDirection As String
    End Structure


    Dim otherChanged As Boolean = False
    Dim selectedchanged As Boolean = False

    Dim LastS As Integer = 0
    Dim shiftdown As Boolean
    Dim ctrldown As Boolean

    Dim XStart As Integer = 28

    Dim bYr1Start As Integer = 226
    Dim vsYr1Start As Integer = 55
    Dim txtYr1Start As Integer = 255
    Dim lblYr1Start As Integer = 29
    Dim fixYr1Start As Integer = 278

    Dim bYr2Start As Integer = 515
    Dim vsYr2Start As Integer = 344
    Dim txtYr2Start As Integer = 544
    Dim lblYr2Start As Integer = 318
    Dim fixYr2Start As Integer = 567

    'Private Declare Sub StartDevice Lib "k8062d.dll" ()
    'Private Declare Sub SetData Lib "k8062d.dll" (ByVal Channel As Integer, ByVal Data As Integer)
    'Private Declare Sub SetChannelCount Lib "k8062d.dll" (ByVal Count As Integer)
    'Private Declare Sub StopDevice Lib "k8062d.dll" ()

    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        'StopDevice()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Form is closing, so shutdown player
        Player.close()

        EnttecOpenDMX.OpenDMX.done = True
        'Application.Exit()
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Shift = True Then
            shiftdown = True
            Label2.Text = "Shift Down"
        ElseIf e.Control = True Then
            ctrldown = True
            Label2.Text = "Ctrl Down"
        ElseIf e.KeyCode = Keys.Escape Then
            cmdUnselectAll_Click(sender, Nothing)
        End If
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If shiftdown = True Then
            shiftdown = False
            Label2.Text = "Shift Up"
        End If
        If ctrldown = True Then
            ctrldown = False
            Label2.Text = "Ctrl Up"
        End If
    End Sub

    Private Sub GenPresetBars()

        Dim I As Integer = 1

        Dim pclblTop As Point = New Point(3, 7)
        Dim pclblBottom As Point = New Point(3, 281)
        Dim pcscrTop As Point = New Point(6, 20)
        Dim pcscrBottom As Point = New Point(6, 294)
        Dim pctxtTop As Point = New Point(6, 259)
        Dim pctxtBottom As Point = New Point(6, 533)

        Do Until I >= PresetControls.Length


            PresetControls(I).vScroll = New GScrollBar
            With PresetControls(I).vScroll
                .Orientation = GControlOrientation.Vertical
                .BackColor = Color.White
                .FillColor = Color.Black
                .BulletColor = Color.Red
                .Maximum = 100
                .Value = 0 '255
                .Size = New System.Drawing.Size(42, 239)
                .Name = "pstvs" & I
                If I <= 20 Then .Location = pcscrTop
                If I > 20 Then .Location = pcscrBottom
                .Visible = False
            End With

            PresetControls(I).vtxtBox = New TextBox
            With PresetControls(I).vtxtBox
                .Size = New Point(42, 20)
                .Text = "0"
                .Name = "psttxtv" & I
                If I <= 20 Then .Location = pctxtTop
                If I > 20 Then .Location = pctxtBottom
                .Visible = False
            End With

            PresetControls(I).clbl = New Label
            With PresetControls(I).clbl
                .AutoSize = False
                .Size = New Point(66, 13)
                .Text = "Dunno"
                .Name = "pstlbl" & I
                .ForeColor = Color.Lime

                If I <= 20 Then .Location = pclblTop
                If I > 20 Then .Location = pclblBottom
                .Visible = False
            End With

            If I = 20 Then
                pclblTop.X = 3
                pclblBottom.X = 3
                pcscrTop.X = 6
                pcscrBottom.X = 6
                pctxtTop.X = 6
                pctxtBottom.X = 6
            Else
                pclblTop.X += 72
                pclblBottom.X += 72
                pcscrTop.X += 72
                pcscrBottom.X += 72
                pctxtTop.X += 72
                pctxtBottom.X += 72
            End If



            PresetControls(I).Automation.tTimer = New System.Windows.Forms.Timer
            With PresetControls(I).Automation.tTimer
                .Enabled = False
                .Interval = 10
                .Tag = "dmrtmr" & I

            End With

            DimmerControls(I).Automation.Max = 255
            DimmerControls(I).Automation.Min = 0
            DimmerControls(I).Automation.Timebetween = 1000


            AddHandler PresetControls(I).vScroll.ValueChanged, AddressOf vPresetScroll_Scroll
            AddHandler PresetControls(I).vtxtBox.TextChanged, AddressOf vPresettxtBox_TextChanged


            tbpPresets.Controls.Add(PresetControls(I).vScroll)
            tbpPresets.Controls.Add(PresetControls(I).clbl)
            tbpPresets.Controls.Add(PresetControls(I).vtxtBox)

            I += 1
        Loop






    End Sub

    Private Sub vPresetScroll_Scroll(ByVal Sender As System.Object)
        If otherChanged = True Then otherChanged = False : Exit Sub
        If selectedchanged = True Then Exit Sub

        Dim I As Integer = Mid(Sender.name, 6)

        PresetControls(I).vtxtBox.Text = Sender.value

    End Sub

    Private Sub vPresettxtBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If otherChanged = True Then otherChanged = False : Exit Sub
        If selectedchanged = True Then Exit Sub

        If sender.Text = "" Then Exit Sub
        Dim I As Integer = Mid(sender.name, 8)

        If Val(sender.Text) > 100 Then sender.Text = 100
        If Val(sender.Text) < 0 Then sender.Text = 0

        PresetControls(I).vScroll.Value = Val(sender.text)

        'DO CHANNEL DATA SEND HERE OK??!?

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Throw New InvalidOperationException("Invalid operation.")
        trkVolume.Value = Player.settings.volume
        trkVolume2.Value = Player2.settings.volume

        Player.settings.autoStart = False
        Player2.settings.autoStart = False
        'Player.URL = files(0)
        Player.enableContextMenu = False
        Player2.enableContextMenu = False
        
        With Me.tmrMP3
            .Interval = 50
            .Start()
            .Enabled = False
        End With
        Player.controls.stop()

        With Me.tmrMP32
            .Interval = 50
            .Start()
            .Enabled = False
        End With
        Player2.controls.stop()

        If Environment.GetCommandLineArgs.Length > 1 Then
            If Environment.GetCommandLineArgs(1) = "-Testmode" Then Testmode = True
        End If
        If File.Exists(Application.StartupPath & "\Testmode.txt") = True Then Testmode = True

        'Throw New InvalidOperationException("Invalid operation.")

        controlcolour = Me.BackColor
        Me.BackColor = Color.Black
        LoadSettings()
        'MsgBox("Generating app controls, may take time!")
        Application.DoEvents()

        XStart = 28

        bYr1Start = 226
        vsYr1Start = 55
        txtYr1Start = 255
        lblYr1Start = 29

        bYr2Start = 515
        vsYr2Start = 344
        txtYr2Start = 544
        lblYr2Start = 318

        GenPresetBars()
        Dim I As Integer = 0

        Do Until I >= DimmerControls.Length

            DimmerControls(I).sButton = New Button
            With DimmerControls(I).sButton
                .Size = New Point(23, 23)
                .Text = "S"
                .Name = "dmrbtn" & I
                .BackColor = controlcolour
                '.ContextMenuStrip = ctxCMDs
            End With

            'DimmerControls(I).vScroll = New VScrollBar
            DimmerControls(I).vScroll = New GScrollBar
            With DimmerControls(I).vScroll
                '.LargeChange = 1
                .Orientation = GControlOrientation.Vertical
                .BackColor = Color.White
                .FillColor = Color.Black
                .BulletColor = Color.Red
                .Maximum = 255
                .Value = 0 '255
                .Size = New System.Drawing.Size(23, 168)
                .Name = "dmrvs" & I
            End With

            DimmerControls(I).vtxtBox = New TextBox
            With DimmerControls(I).vtxtBox
                .Size = New Point(24, 20)
                .Text = "0"
                .Name = "dmrtxtv" & I
            End With

            DimmerControls(I).clbl = New Label
            With DimmerControls(I).clbl
                .AutoSize = False
                .Size = New Point(26, 13)
                .Text = I
                .Name = "dmrlbl" & I
                .ForeColor = Color.Lime
            End With

            DimmerControls(I).Automation.tTimer = New System.Windows.Forms.Timer
            With DimmerControls(I).Automation.tTimer
                .Enabled = False
                .Interval = 10
                .Tag = "dmrtmr" & I

            End With

            DimmerControls(I).flbl = New Label
            With DimmerControls(I).flbl
                .AutoSize = False
                .Size = New Point(34, 16)
                .Text = I
                .Name = "dmrFixture" & I
                .ForeColor = Color.Lime
                .BackColor = Color.Red
                .Visible = False
            End With

            DimmerControls(I).vDimmable = True
            DimmerControls(I).Automation.Max = 255
            DimmerControls(I).Automation.Min = 0
            DimmerControls(I).Automation.Timebetween = 1000

            AddHandler DimmerControls(I).vScroll.ValueChanged, AddressOf vScroll_Scroll 'AddHandler DimmerControls(I).vScroll.Scroll, AddressOf vScroll_Scroll
            AddHandler DimmerControls(I).vtxtBox.TextChanged, AddressOf vtxtBox_TextChanged
            AddHandler DimmerControls(I).sButton.Click, AddressOf sButton_Click
            AddHandler DimmerControls(I).flbl.DoubleClick, AddressOf sButton_DoubleClick
            AddHandler DimmerControls(I).Automation.tTimer.Tick, AddressOf tTimer_Tick

            AddHandler DimmerControls(I).vScroll.KeyDown, AddressOf Form1_KeyDown
            AddHandler DimmerControls(I).vtxtBox.KeyDown, AddressOf Form1_KeyDown
            AddHandler DimmerControls(I).sButton.KeyDown, AddressOf Form1_KeyDown

            AddHandler DimmerControls(I).vScroll.KeyUp, AddressOf Form1_KeyUp
            AddHandler DimmerControls(I).vtxtBox.KeyUp, AddressOf Form1_KeyUp
            AddHandler DimmerControls(I).sButton.KeyUp, AddressOf Form1_KeyUp

            I += 1
        Loop

        For Each c As System.Windows.Forms.Control In Me.Controls
            AddHandler c.KeyDown, AddressOf Form1_KeyDown
            AddHandler c.KeyUp, AddressOf Form1_KeyUp
        Next c

        'Throw New InvalidOperationException("Invalid operation.")

        LoadBanks()
        LoadControls()
        LoadMidiControls()
        LoadFixtures()

        If Testmode = False Then
            'StartDevice()
            EnttecOpenDMX.OpenDMX.start()
        End If



        tbpPresets.BackColor = Color.Black
        tbpSongEdit.BackColor = Color.Black

        cmdMode.Text = "Song Mode"
        cmdMode_Click(sender, e)
        'SetChannelCount(512)
        Run() 'MIDI

        opened = True
    End Sub

    Private Sub LoadMidiControls()
        Dim Iupto As Integer = 0
        FileOpen(1, Application.StartupPath & "\MidiControls.ini", OpenMode.Input)
        Do Until EOF(1)
            Dim a() As String = Split(LineInput(1), "|")


            Iupto += 1
        Loop




        FileClose(1)


    End Sub

    Private Sub ScrollingVolume(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trkVolume.Scroll
        ' Change the player's volume
        Player.settings.volume = trkVolume.Value
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ' Dispose of player
        Player = Nothing
    End Sub

    Private Sub Player_MediaError(ByVal pMediaObject As Object) Handles Player.MediaError
        'MessageBox.Show("Unrecoverable Problem. Shutting Down", "MyMusic Player")
        'Me.Close()
    End Sub

    Private Sub LoadSettings()
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
                    'SetChannelCount(a(1))
                    numEndChannel.Value = a(1)
                Case "LoadonChange"
                    'chkLoadonChange.Checked = a(1)
                    chkLoadonChange.Checked = True
                    chkLoadonChange_CheckedChanged(Nothing, Nothing)
            End Select
        Loop
        FileClose(1)

    End Sub

    Private Sub LoadFixtures()

        FileOpen(1, Application.StartupPath & "\Fixtures.ini", OpenMode.Input)
        Do Until EOF(1)
            Dim afixtureini() As String = Split(LineInput(1), "|") 'a(2)

            FileOpen(2, Application.StartupPath & "\Fixtures\" & afixtureini(1) & ".fix", OpenMode.Input)
            Dim chancount As Integer = Split(LineInput(2), "=")(1)
            DimmerControls(afixtureini(0)).clbl.Text = afixtureini(1)
            DimmerControls(afixtureini(0)).clbl.BringToFront()
            DimmerControls(afixtureini(0)).clbl.AutoSize = True
            Dim chan As Integer = 0
            Do Until EOF(2)
                DimmerControls(afixtureini(0) + chan).Fixtures.StartDimmer = afixtureini(0)
                DimmerControls(afixtureini(0) + chan).Fixtures.FixtureName = afixtureini(1)
                DimmerControls(afixtureini(0) + chan).Fixtures.Backcolour = Color.FromName(afixtureini(2))
                DimmerControls(afixtureini(0) + chan).flbl.BackColor = Color.FromName(afixtureini(2))
                DimmerControls(afixtureini(0) + chan).Fixtures.Forecolour = Color.FromName(afixtureini(3))
                DimmerControls(afixtureini(0) + chan).flbl.ForeColor = Color.FromName(afixtureini(3))
                DimmerControls(afixtureini(0) + chan).flbl.Visible = True
                DimmerControls(afixtureini(0) + chan).Fixtures.ChannelCount = chancount
                DimmerControls(afixtureini(0) + chan).Fixtures.ChannelNum = chan + 1
                DimmerControls(afixtureini(0) + chan).Fixtures.FixtureString = LineInput(2)
                Dim a() As String = Split(DimmerControls(afixtureini(0) + chan).Fixtures.FixtureString, "|")
                If a(0) = "D" Then
                    DimmerControls(afixtureini(0) + chan).vDimmable = True
                ElseIf a(0) = "X" Then
                    DimmerControls(afixtureini(0) + chan).vDimmable = False
                End If
                DimmerControls(afixtureini(0) + chan).Fixtures.FixtureString = a(1)
                DimmerControls(afixtureini(0) + chan).Fixtures.ChannelName = Split(DimmerControls(afixtureini(0) + chan).Fixtures.FixtureString, ",")(0)
                DimmerControls(afixtureini(0) + chan).flbl.Text = DimmerControls(afixtureini(0) + chan).Fixtures.ChannelName

                chan += 1
            Loop
            FileClose(2)


        Loop
        FileClose(1)


        ProcessFixtures()

    End Sub

    Private Sub ProcessSingleFixture(ByVal channum As Integer)
        'Dim I As Integer = channum


        If Not DimmerControls(channum).Fixtures.FixtureName = "" Then
            Dim a() As String = Split(DimmerControls(channum).Fixtures.FixtureString, ",")
            If a.Length > 2 Then
                Dim J As Integer = 1
                Do Until J >= a.Length
                    Dim b() As String = Split(a(J), "-")
                    If (DimmerControls(channum).vScroll.Value) >= Val(b(0)) Then
                        If (DimmerControls(channum).vScroll.Value) <= Val(b(1)) Then
                            DimmerControls(channum).Fixtures.ChannelName = a(J - 1)
                            DimmerControls(channum).flbl.Text = a(J - 1)
                        End If
                    End If
                    J += 2
                Loop

            End If

        End If



    End Sub

    Private Sub ProcessFixtures()

        Dim I As Integer = 0
        Do Until I >= numEndChannel.Value

            If Not DimmerControls(I).Fixtures.FixtureName = "" Then
                Dim a() As String = Split(DimmerControls(I).Fixtures.FixtureString, ",")
                If a.Length > 2 Then
                    Dim J As Integer = 1
                    Do Until J >= a.Length
                        Dim b() As String = Split(a(J), "-")
                        If (DimmerControls(I).vScroll.Value) >= Val(b(0)) Then
                            If (DimmerControls(I).vScroll.Value) <= Val(b(1)) Then
                                DimmerControls(I).Fixtures.ChannelName = a(J - 1)
                                DimmerControls(I).flbl.Text = a(J - 1)
                            End If
                        End If
                        J += 2
                    Loop

                End If

            End If
            I += 1
        Loop
       
    End Sub

    Private Sub LoadBanks()
        lstBank.Items.Clear()
        lstPresets.Items.Clear()

        For Each S As String In Directory.GetDirectories(Application.StartupPath & "\Save Files\")
            Dim a() As String = Split(S, "\")
            lstBank.Items.Add(a(a.Length - 1))
        Next S



    End Sub


    Sub RemoveControls()
        Dim I As Integer = 0
        Do Until I >= Me.Controls.Count - 1
            If Mid(Me.Controls(I).Name, 1, 3) = "dmr" Then
                Me.Controls.Remove(Me.Controls(I))
                I -= 1
            End If
            I += 1
        Loop
        'For Each c As Control In Me.Controls
        '    If Mid(c.Name, 1, 3) = "dmr" Then
        '        Me.Controls.Remove(c)
        '    End If
        'Next c

    End Sub

    Sub LoadControls()
        XStart = 28

        bYr1Start = 226
        vsYr1Start = 55
        txtYr1Start = 255
        lblYr1Start = 29
        fixYr1Start = 278

        bYr2Start = 515
        vsYr2Start = 344
        txtYr2Start = 544
        lblYr2Start = 318


        Dim I As Integer = numStartBank.Value
        Dim Iend As Integer = numStartBank.Value + 40

        Do Until I >= Iend
            If DimmerControls(I).vScroll Is Nothing Then Exit Sub
            DimmerControls(I).vScroll.Location = New System.Drawing.Point(XStart, vsYr1Start)
            DimmerControls(I).sButton.Location = New System.Drawing.Point(XStart, bYr1Start)
            DimmerControls(I).clbl.Location = New System.Drawing.Point(XStart, lblYr1Start)
            DimmerControls(I).vtxtBox.Location = New System.Drawing.Point(XStart, txtYr1Start)
            DimmerControls(I).flbl.Location = New System.Drawing.Point(XStart, fixYr1Start)
            Me.Controls.Add(DimmerControls(I).vScroll)
            Me.Controls.Add(DimmerControls(I).clbl)
            Me.Controls.Add(DimmerControls(I).sButton)
            Me.Controls.Add(DimmerControls(I).vtxtBox)
            Me.Controls.Add(DimmerControls(I).flbl)
            XStart += 35
            Application.DoEvents()
            I += 1
        Loop


        XStart = 28
        Iend += 40
        Do Until I >= Iend
            DimmerControls(I).vScroll.Location = New Point(XStart, vsYr2Start)
            DimmerControls(I).sButton.Location = New Point(XStart, bYr2Start)
            DimmerControls(I).clbl.Location = New Point(XStart, lblYr2Start)
            DimmerControls(I).vtxtBox.Location = New Point(XStart, txtYr2Start)
            DimmerControls(I).flbl.Location = New Point(XStart, fixYr2Start)
            Me.Controls.Add(DimmerControls(I).vScroll)
            Me.Controls.Add(DimmerControls(I).clbl)
            Me.Controls.Add(DimmerControls(I).sButton)
            Me.Controls.Add(DimmerControls(I).vtxtBox)
            Me.Controls.Add(DimmerControls(I).flbl)
            XStart += 35
            Application.DoEvents()
            I += 1
        Loop

        'If Me.Size.Height > 1318 Then

        '    bYr2Start = (bYr2Start - bYr1Start) + bYr2Start
        '    vsYr2Start = (vsYr2Start - vsYr1Start) + vsYr2Start
        '    txtYr2Start = (txtYr2Start - txtYr1Start) + txtYr2Start
        '    lblYr2Start = (lblYr2Start - lblYr1Start) + lblYr2Start
        '    fixYr2Start = (fixYr2Start - fixYr1Start) + fixYr2Start

        '    XStart = 28
        '    Iend += 40
        '    Do Until I >= Iend
        '        DimmerControls(I).vScroll.Location = New Point(XStart, vsYr2Start)
        '        DimmerControls(I).sButton.Location = New Point(XStart, bYr2Start)
        '        DimmerControls(I).clbl.Location = New Point(XStart, lblYr2Start)
        '        DimmerControls(I).vtxtBox.Location = New Point(XStart, txtYr2Start)
        '        DimmerControls(I).flbl.Location = New Point(XStart, fixYr2Start)
        '        Me.Controls.Add(DimmerControls(I).vScroll)
        '        Me.Controls.Add(DimmerControls(I).clbl)
        '        Me.Controls.Add(DimmerControls(I).sButton)
        '        Me.Controls.Add(DimmerControls(I).vtxtBox)
        '        Me.Controls.Add(DimmerControls(I).flbl)
        '        XStart += 35
        '        Application.DoEvents()
        '        I += 1
        '    Loop




        'End If





    End Sub


    Private Sub vScroll_Scroll(ByVal Sender As System.Object) 'ByVal sender As System.Object, ByVal e As System.EventArgs)
        If otherChanged = True Then otherChanged = False : Exit Sub
        If selectedchanged = True Then Exit Sub


        Dim I As Integer = Mid(Sender.name, 6)
        'cmdUnselectAll_Click(Sender, Nothing)
        'DimmerControls(I).sButton.BackColor = Color.Red



        ''otherChanged = True
        ''If DimmerControls(I).flbl.Visible = True Then ProcessSingleFixture(I) 'Is Fixture


        DimmerControls(I).vtxtBox.Text = Sender.value


        ''SetChannelData(I, sender.value)
    End Sub

    Private Sub vtxtBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If otherChanged = True Then otherChanged = False : Exit Sub
        If selectedchanged = True Then Exit Sub
        If sender.Text = "" Then Exit Sub
        Dim I As Integer = Mid(sender.name, 8)

        If Val(sender.Text) > 255 Then sender.Text = 255
        If Val(sender.Text) < 0 Then sender.Text = 0
        DimmerControls(I).vScroll.Value = Val(sender.text)

        'cmdUnselectAll_Click(sender, Nothing)
        'DimmerControls(I).sButton.BackColor = Color.Red

        SetChannelData(I, Val(sender.text))
        'otherChanged = True




    End Sub

    Private Sub sButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.backcolor = Color.Red Then
            sender.backcolor = controlcolour

            GoTo shiftDown
        End If

        If sender.backcolor = controlcolour Then
            sender.backcolor = Color.Red
            Dim num As Integer = Mid(sender.Name, 7)
            nudAutoMax.Value = DimmerControls(num).Automation.Max
            nudAutoMin.Value = DimmerControls(num).Automation.Min
            nudAutoTimebetween.Value = DimmerControls(num).Automation.Timebetween
            chkAutoRunning.Checked = DimmerControls(num).Automation.tTimer.Enabled

            GoTo shiftDown
        End If


        'If sender.backcolor = Color.Black Then sender.backcolor = Color.Red : Exit Sub


shiftDown:
        If shiftdown = True Then
            Dim I As Integer = LastS
            If Mid(sender.Name, 7) > LastS Then
                Do Until I > Mid(sender.Name, 7)
                    DimmerControls(I).sButton.BackColor = Color.Red
                    I += 1
                Loop
            End If
        End If

        If ctrldown = True Then
            Dim I As Integer = LastS
            If Mid(sender.Name, 7) > LastS Then
                Do Until I > Mid(sender.Name, 7)
                    DimmerControls(I).sButton.BackColor = controlcolour
                    I += 1
                Loop
            End If
        End If

        LastS = Mid(sender.Name, 7) 'dmrbtnI

    End Sub

    Private Sub sButton_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim I As Integer = Mid(sender.Name, 11)
        cmdUnselectAll_Click(sender, Nothing)
        Dim fixname As String = DimmerControls(I).Fixtures.FixtureName
        Dim fixchan As Integer = DimmerControls(I).Fixtures.ChannelNum

        For Each c In DimmerControls
            If c.Fixtures.FixtureName = fixname And c.Fixtures.ChannelNum = fixchan Then
                c.sButton.BackColor = Color.Red
            End If
        Next c

    End Sub

    Private Sub tTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim channum As Integer = Split(sender.tag, "tmr")(1) '.Tag = "dmrtmr" & I

        Dim curpos As Double = DimmerControls(channum).Automation.curposDouble

        If DimmerControls(channum).Automation.tmrDirection = "Up" Then

            If curpos + DimmerControls(channum).Automation.Interval > DimmerControls(channum).Automation.Max Then
                DimmerControls(channum).Automation.tmrDirection = "Down"
                curpos -= DimmerControls(channum).Automation.Interval
            Else
                curpos += DimmerControls(channum).Automation.Interval
            End If


        ElseIf DimmerControls(channum).Automation.tmrDirection = "Down" Then

            If curpos - DimmerControls(channum).Automation.Interval < DimmerControls(channum).Automation.Min Then
                DimmerControls(channum).Automation.tmrDirection = "Up"
                curpos += DimmerControls(channum).Automation.Interval
            Else
                curpos -= DimmerControls(channum).Automation.Interval
            End If


        Else
            DimmerControls(channum).Automation.tmrDirection = "Up"
            DimmerControls(channum).Automation.curposDouble = DimmerControls(channum).vScroll.Value
            tTimer_Tick(sender, e)
            Exit Sub
        End If
        DimmerControls(channum).Automation.curposDouble = curpos
        DimmerControls(channum).vScroll.Value = curpos
        'vScroll_Scroll(DimmerControls(channum).vScroll, Nothing)

    End Sub

    Private Sub cmdUpDown80_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDown80.Click, cmdUp80.Click
        If (numStartBank.Value + sender.text) > numStartBank.Maximum Then
            numStartBank.Value = numStartBank.Maximum
            Exit Sub
        End If
        If (numStartBank.Value + sender.text) < numStartBank.Minimum Then
            numStartBank.Value = numStartBank.Minimum
            Exit Sub
        End If
        numStartBank.Value += sender.text
    End Sub

    Private Sub NameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NameToolStripMenuItem.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)

        MessageBox.Show(cms.SourceControl.Name)

    End Sub

    Private Sub numStartBank_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numStartBank.ValueChanged
        'If Me.Size.Height > 1311 Then
        '    numStartBank.Maximum = 433 - 40
        '    cmdDown80.Text = "-120"
        '    cmdUp80.Text = "+120"
        'Else
        'numStartBank.Maximum = 433
        cmdDown80.Text = "-80"
        cmdUp80.Text = "+80"
        'End If
        RemoveControls()
        LoadControls()
    End Sub

    Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click
        For Each c As DimmerControls1 In DimmerControls
            c.sButton.BackColor = Color.Red
        Next c
    End Sub

    Private Sub cmdUnselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnselectAll.Click
        For Each c As DimmerControls1 In DimmerControls
            c.sButton.BackColor = controlcolour
        Next c
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSize.Click
        sender.text = Me.Size.ToString
    End Sub

    Private Sub vsSelected_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        'If otherChanged = True Then otherChanged = False : Exit Sub
        'otherChanged = True
        txtSelected.Text = vsSelected.Value
        'Application.DoEvents()
        'selectedchanged = True
        'Dim FixtureRun As Boolean = False
        'For Each c As DimmerControls1 In DimmerControls
        '    If c.sButton.BackColor = Color.Red Then
        '        c.vScroll.Value = vsSelected.Value
        '        c.vtxtBox.Text = txtSelected.Text
        '        If c.flbl.Visible = True Then FixtureRun = True

        '        If c.vDimmable = True Then
        '            Dim value As Integer = 255 - vsSelected.Value
        '            'value = value / 100
        '            'value = value * (100 - vsMaster.Value)
        '            SetChannelData(Mid(c.sButton.Name, 7), value)
        '        End If

        '    End If
        'Next c
        'If FixtureRun = True Then ProcessFixtures()
        'Application.DoEvents()
        'selectedchanged = False
    End Sub

    Private Sub txtSelected_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSelected.TextChanged
        If otherChanged = True Then otherChanged = False : Exit Sub
        If txtSelected.Text = "" Then Exit Sub
        If opened = False Then Exit Sub

        If Val(txtSelected.Text) > 255 Then txtSelected.Text = 255
        If Val(txtSelected.Text) < 0 Then txtSelected.Text = 0
        vsSelected.Value = Val(txtSelected.Text)
        Try
            Application.DoEvents()
            'selectedchanged = True
            Dim FixtureRun As Boolean = False
            For Each c As DimmerControls1 In DimmerControls
                If c.sButton.BackColor = Color.Red Then
                    c.vScroll.Value = vsSelected.Value
                    c.vtxtBox.Text = txtSelected.Text
                    If c.flbl.Visible = True Then FixtureRun = True

                    If c.vDimmable = True Then
                        Dim value As Integer = vsSelected.Value
                        'value = value / 100
                        'value = value * (100 - vsMaster.Value)

                        SetChannelData(Mid(c.sButton.Name, 7), value)
                    End If


                End If
            Next c
            If FixtureRun = True Then ProcessFixtures()
            Application.DoEvents()
        Catch ex As Exception

        End Try

        selectedchanged = False


    End Sub

    Private Sub cmdSelectedBlackout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectedBlackout.Click
        txtSelected.Text = 0
        vsSelected.Value = Val(txtSelected.Text)
        'vsSelected_Scroll(sender, Nothing)

    End Sub

    Private Sub cmdSelectedFull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectedFull.Click
        txtSelected.Text = 255
        vsSelected.Value = Val(txtSelected.Text)
        'vsSelected_Scroll(sender, Nothing)
    End Sub

    Private Sub vsMaster_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs)
        txtMaster.Text = 100 - vsMaster.Value
        'ProcessFixtures()
    End Sub

    Private Sub txtMaster_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaster.TextChanged
        If opened = False Then Exit Sub
        If txtMaster.Text = "" Then Exit Sub
        If Val(txtMaster.Text) < 0 Then txtMaster.Text = 0
        If Val(txtMaster.Text) > 100 Then txtMaster.Text = 100
        vsMaster.Value = Val(txtMaster.Text)
        Dim I As Integer = 1
        Do Until I >= DimmerControls.Length
            If I = numEndChannel.Value Then Exit Sub
            If DimmerControls(I).vDimmable = True Then
                Dim value As Integer = DimmerControls(I).vScroll.Value
                'value = value / 100
                'value = value * (100 - vsMaster.Value)
                SetChannelData(I, value)
            End If

            I += 1
        Loop
        'ProcessFixtures()
    End Sub

    Private Sub cmdMasterBlackout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMasterBlackout.Click
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

    Private Sub cmdMasterFull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMasterFull.Click
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

    Private Sub numEndChannel_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numEndChannel.ValueChanged
        'SetChannelCount(numEndChannel.Value)
    End Sub

    Private Sub SetChannelData(ByVal Channel As Integer, ByVal Value As Integer)
        Value = (Value / 100) * Val(txtMaster.Text)
        If Not Channel > 510 Then
            EnttecOpenDMX.OpenDMX.setDmxValue(Channel, Value)
        End If

        'SetData(Channel, Value)

    End Sub

    Private Sub lstBank_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstBank.SelectedIndexChanged
        lstPresets.Items.Clear()
        lstSongs.Items.Clear()
        lstSongs2.Items.Clear()
        For Each S As String In Directory.GetFiles(Application.StartupPath & "\Save Files\" & lstBank.SelectedItem)
            Dim a() As String = Split(S, "\")
            Dim b() As String = Split(a(a.Length - 1), ".")
            If b(1) = "dmr" Then
                lstPresets.Items.Add(b(0))
            ElseIf b(1) = "mp3" Then
                lstSongs.Items.Add(b(0))
                lstSongs2.Items.Add(b(0))
            ElseIf b(1) = "chg" Then
                'file with changes for MP3s
            End If
        Next S
        PresetCountChange(lstPresets.Items.Count)
        UpPresetSlider(0)
    End Sub

    Private Sub PresetCountChange(ByVal num As Integer)
        Dim I As Integer = 1
        Do Until I >= PresetControls.Length
            If I <= num Then
                PresetControls(I).clbl.Text = lstPresets.Items.Item(I - 1)
                PresetControls(I).clbl.Visible = True
                PresetControls(I).vScroll.Visible = True
                PresetControls(I).vtxtBox.Visible = True
            Else
                PresetControls(I).clbl.Visible = False
                PresetControls(I).vScroll.Visible = False
                PresetControls(I).vtxtBox.Visible = False
            End If
            I += 1
        Loop

    End Sub


    Private Sub chkLoadonChange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLoadonChange.CheckedChanged
        If chkLoadonChange.Checked = False Then cmdChangePreset.Visible = True
        If chkLoadonChange.Checked = True Then cmdChangePreset.Visible = False
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
        lblMP3Duration.Text = Player.currentMedia.durationString
        lblMP3Position.Text = Player.controls.currentPositionString



        ' Set Volume slide to match current volume
        trkVolume.Value = Player.settings.volume
        ' Is the CurrentPlaying Track No. is different to the Previous Track number.
        'If CurrentPlaying <> PreviouslyPlaying Then
        '    ' Yes, 
        '    ' Set the forecolor of the corrisponding track, assiociated with the previous playing track, with the control color
        '    TrackList.Items(PreviouslyPlaying).ForeColor = System.Drawing.SystemColors.ControlText
        'End If
        ' Set the forecolor of the corrisponding track, assiociated with the currently playing track, with the current track color
        'TrackList.Items(CurrentPlaying).ForeColor = CurrentTrackColor

        'lblMP3Position
        'lblMP3PositionMilli

        'MOVED FROM TIMER


        'MS = MP3.MP3PositionInMS
        lblMP3PositionMilli.Text = Math.Round(Player.controls.currentPosition, 2)
        lbleditPositionMilli.Text = Player.controls.currentPosition

        vSongEdit.Value = Player.controls.currentPosition

        'If Val(Player.currentMedia.durationString) <= 0 Then Exit Sub

        If lstSongChanges.Items.Count > 0 Then
            If NextMP3Change <= Player.controls.currentPosition And NextMP3Change > -1 Then 'MS
                'do change
                lstSongChanges.SelectedIndex += 1
                Dim d() As String = Split(lstSongChanges.SelectedItem, "|")
                lstPresets.SelectedItem = d(1)
                'lstPresets_SelectedIndexChanged(sender, e)

                'prep next change
                If lstSongChanges.Items.Count <= lstSongChanges.SelectedIndex + 1 Then
                    NextMP3Change = -1
                Else
                    Dim c1() As String = Split(lstSongChanges.Items.Item(lstSongChanges.SelectedIndex + 1), "|")
                    NextMP3Change = c1(0)
                End If


            End If

        End If

        tmrMP3.Interval = 50
        tmrchangedmp3 = False

    End Sub

    Private Sub updatePlayer2()
        tmrchangedmp32 = True
        ' Update TrackPostion
        
        ' Display Current Time Position and Duration
        'lblMP3PositionMilli.Text = Player.controls.currentPosition ## is lower down
        lblMP3Duration2.Text = Player2.currentMedia.durationString
        lblMP3Position2.Text = Player2.controls.currentPositionString



        ' Set Volume slide to match current volume
        trkVolume2.Value = Player2.settings.volume
        ' Is the CurrentPlaying Track No. is different to the Previous Track number.
        'If CurrentPlaying <> PreviouslyPlaying Then
        '    ' Yes, 
        '    ' Set the forecolor of the corrisponding track, assiociated with the previous playing track, with the control color
        '    TrackList.Items(PreviouslyPlaying).ForeColor = System.Drawing.SystemColors.ControlText
        'End If
        ' Set the forecolor of the corrisponding track, assiociated with the currently playing track, with the current track color
        'TrackList.Items(CurrentPlaying).ForeColor = CurrentTrackColor

        'lblMP3Position
        'lblMP3PositionMilli

        'MOVED FROM TIMER


        'MS = MP3.MP3PositionInMS
        lblMP3PositionMilli2.Text = Math.Round(Player2.controls.currentPosition, 2)


        'If Val(Player2.currentMedia.durationString) <= 0 Then Exit Sub

        If lstSongChanges2.Items.Count > 0 Then
            If NextMP3Change2 <= Player2.controls.currentPosition And NextMP3Change2 > -1 Then 'MS
                'do change
                lstSongChanges2.SelectedIndex += 1
                Dim d() As String = Split(lstSongChanges2.SelectedItem, "|")
                lstPresets.SelectedItem = d(1)
                'lstPresets_SelectedIndexChanged(sender, e)

                'prep next change
                If lstSongChanges2.Items.Count <= lstSongChanges2.SelectedIndex + 1 Then
                    NextMP3Change2 = -1
                Else
                    Dim c1() As String = Split(lstSongChanges2.Items.Item(lstSongChanges2.SelectedIndex + 1), "|")
                    NextMP3Change2 = c1(0)
                End If


            End If

        End If


        tmrMP32.Interval = 50
        tmrchangedmp32 = False

    End Sub

    Private Sub Player_PlayStateChange(ByVal NewState As Integer) Handles Player.PlayStateChange
        If opened = True Then Exit Sub
        Static Dim PlayAllowed As Boolean = False
        Select Case CType(NewState, WMPLib.WMPPlayState)
            Case WMPLib.WMPPlayState.wmppsReady
                If PlayAllowed Then
                    Player.controls.play()
                End If
            Case WMPLib.WMPPlayState.wmppsMediaEnded
                'cmdStop_Click(Nothing, Nothing)
                'Player.controls.stop()
                tmrMP3.Stop()
                cmdPlay.Text = "Play"
                cmdEditPlay.Text = "Play"
                lstSongs.Enabled = True

                ' Reach end of track move onto next, looping around
                'PreviouslyPlaying = CurrentPlaying
                'CurrentPlaying = (CurrentPlaying + 1) Mod files.Count
                ' Start protection (without it next wouldn't play
                PlayAllowed = False
                ' Play track
                'Player.URL = files(CurrentPlaying)
                Player.controls.stop()
                ' End Protection
                'PlayAllowed = True
                updatePlayer()
        End Select

    End Sub

    Private Sub Player2_PlayStateChange(ByVal NewState As Integer) Handles Player2.PlayStateChange
        If opened = True Then Exit Sub
        Static Dim PlayAllowed2 As Boolean = False
        Select Case CType(NewState, WMPLib.WMPPlayState)
            Case WMPLib.WMPPlayState.wmppsReady
                If PlayAllowed2 Then
                    Player2.controls.play()
                End If
            Case WMPLib.WMPPlayState.wmppsMediaEnded
                'cmdStop_Click(Nothing, Nothing)
                'Player.controls.stop()
                tmrMP32.Stop()
                cmdPlay2.Text = "Play"
                lstSongs2.Enabled = True

                ' Reach end of track move onto next, looping around
                'PreviouslyPlaying = CurrentPlaying
                'CurrentPlaying = (CurrentPlaying + 1) Mod files.Count
                ' Start protection (without it next wouldn't play
                PlayAllowed2 = False
                ' Play track
                'Player.URL = files(CurrentPlaying)
                Player2.controls.stop()
                ' End Protection
                'PlayAllowed = True
                updatePlayer2()
        End Select

    End Sub

    Private Sub cmdPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlay.Click, cmdEditPlay.Click
        If lstSongs.SelectedIndex = -1 Then Exit Sub
        If cmdPlay.Text = "Play" Then

            Player.controls.play()


            'Make sure no mp3 is playing
            'MP3.MP3Stop()
            'load mp3 and play

            'MP3.MP3File = Application.StartupPath & "\Save Files\" & lstBank.SelectedItem & "\" & lstSongs.SelectedItem & ".mp3"
            'MP3.MP3Play()
            'lblMP3Duration.Text = MP3.MP3Duration

            'Dim a2() As String = Split(MP3.MP3Duration, ":")
            'Dim mDur As Integer = 0
            'mDur = (Val(a2(0)) * 60) * 1000
            'mDur += Val(a2(1)) * 1000
            'vSongEdit.Maximum = mDur


            If lstSongChanges.Items.Count > 0 Then
                Dim a() As String = Split(lstSongChanges.Items.Item(0), "|")
                NextMP3Change = a(0)
                lstSongChanges.SelectedIndex = -1
            End If

            cmdPlay.Text = "Pause"
            cmdEditPlay.Text = "Pause"
            tmrMP3.Interval = 50
            tmrMP3.Start()
            tmrMP3_Tick(sender, e)
            lstSongs.Enabled = False
            Exit Sub
        ElseIf cmdPlay.Text = "Pause" Then
            'MP3.MP3Pause()
            Player.controls.pause()
            cmdPlay.Text = "Resume"
            cmdEditPlay.Text = "Resume"
            tmrMP3.Enabled = False
            Exit Sub
        ElseIf cmdPlay.Text = "Resume" Then
            Player.controls.play()
            cmdPlay.Text = "Pause"
            cmdEditPlay.Text = "Pause"
            'MP3.MP3Resume()
            tmrMP3.Start()
            Exit Sub
        End If

    End Sub

    Private Sub tmrMP3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMP3.Tick
        updatePlayer()
    End Sub

    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click, cmdEditStop.Click
        'MP3.MP3Stop()
        Player.controls.stop()
        tmrMP3.Stop()
        cmdPlay.Text = "Play"
        cmdEditPlay.Text = "Play"
        lstSongs.Enabled = True
    End Sub

    Private Sub cmdManualStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdManualStart.Click
        'StartDevice()
    End Sub

    Private Sub ctxFixtureRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdPresetUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPresetUp.Click
        If lstPresets.SelectedIndex = 0 Then Exit Sub
        lstPresets.SelectedIndex -= 1

    End Sub

    Private Sub cmdPresetDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPresetDown.Click
        If lstPresets.SelectedIndex >= lstPresets.Items.Count - 1 Then Exit Sub
        lstPresets.SelectedIndex += 1
    End Sub

    Private Sub cmdBankNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBankNew.Click
        Dim s As String = InputBox("Input name of the new bank.")
        If s = "" Then Exit Sub
        Directory.CreateDirectory(Application.StartupPath & "\Save Files\" & s)
        lstBank.Items.Add(s)
    End Sub

    Private Sub cmdBankRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBankRename.Click
        If lstBank.SelectedIndex = -1 Then Exit Sub
        Dim s As String = InputBox("Input name of the new bank.")
        If s = "" Then Exit Sub
        If s = lstBank.SelectedItem Then Exit Sub

    End Sub

    Private Sub cmdPresetNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPresetNew.Click
        If lstBank.SelectedIndex = -1 Then Exit Sub
        Dim filename As String = InputBox("Input name of new Preset")
        If filename = "" Then Exit Sub

        SavePreset(filename)
        lstPresets.Items.Add(filename)
        lstBank_SelectedIndexChanged(sender, e)
    End Sub

    Sub SavePreset(ByVal filename As String)

        FileOpen(1, Application.StartupPath & "\Save Files\" & lstBank.SelectedItem & "\" & filename & ".dmr", OpenMode.Output)
        PrintLine(1, "M|" & vsMaster.Value)
        Dim I As Integer = 1
        Do Until I > numEndChannel.Value '1|v,0|tmr,100|timerenabled,false
            Dim chanline As String = I & "|"
            With DimmerControls(I)
                chanline &= "v," & (.vScroll.Value) & "|"
                chanline &= "tmr," & .Automation.tTimer.Interval & "|"
                chanline &= "timerenabled," & .Automation.tTimer.Enabled & "|"
                chanline &= "AutoMax," & .Automation.Max & "|"
                chanline &= "AutoMin," & .Automation.Min & "|"
                chanline &= "AutoTimeBetween," & .Automation.Timebetween & "|"
                chanline &= "RandomStart," & .Automation.randomstart
            End With
            PrintLine(1, chanline)
            I += 1
        Loop
        FileClose(1)

    End Sub

    Private Sub UpPresetSlider(ByVal num As Integer)
        Dim I As Integer = 1
        Do Until I >= PresetControls.Count
            If I = num Then
                PresetControls(I).vScroll.Value = 100
            Else
                PresetControls(I).vScroll.Value = 0
            End If


            I += 1
        Loop

    End Sub

    Private Sub lstPresets_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstPresets.SelectedIndexChanged
        If lstPresets.SelectedIndex = -1 Then Exit Sub
        If chkLoadonChange.Checked = False Then Exit Sub
        UpPresetSlider(lstPresets.SelectedIndex + 1)
        FileOpen(1, Application.StartupPath & "\Save Files\" & lstBank.SelectedItem & "\" & lstPresets.SelectedItem & ".dmr", OpenMode.Input)
        Do Until EOF(1)
            Dim a() As String = Split(LineInput(1), "|")
            If a(0) = "M" Then
                vsMaster.Value = a(1)
            ElseIf a(0) = "P" Then
                vsMaster.Value = 255 - a(1)
            ElseIf a(0) = "ChangeMS" Then

            Else
                Dim I As Integer = 1
                'channelresets start
                DimmerControls(a(0)).vScroll.Value = 255
                DimmerControls(a(0)).Automation.tTimer.Interval = 10
                DimmerControls(a(0)).Automation.tTimer.Enabled = False
                DimmerControls(a(0)).Automation.Max = 255
                DimmerControls(a(0)).Automation.Min = 0
                DimmerControls(a(0)).Automation.Timebetween = 1000

                DimmerControls(a(0)).sButton.BackColor = controlcolour
                DimmerControls(a(0)).Automation.randomstart = False
                'channelresets end
                Do Until I >= a.Length
                    Dim b() As String = Split(a(I), ",")
                    Select Case b(0)
                        Case "v"
                            DimmerControls(a(0)).vScroll.Value = Val(b(1))
                            DimmerControls(a(0)).Automation.curposDouble = DimmerControls(a(0)).vScroll.Value
                        Case "tmr"
                            DimmerControls(a(0)).Automation.tTimer.Interval = Val(b(1))
                        Case "timerenabled" Or "TimerEnabled"
                            DimmerControls(a(0)).Automation.tTimer.Enabled = Convert.ToBoolean(b(1))
                        Case "AutoMax"
                            DimmerControls(a(0)).Automation.Max = Val(b(1))
                        Case "AutoMin"
                            DimmerControls(a(0)).Automation.Min = Val(b(1))
                        Case "AutoTimeBetween"
                            DimmerControls(a(0)).Automation.Timebetween = Val(b(1))
                        Case "RandomStart"
                            DimmerControls(a(0)).Automation.randomstart = Convert.ToBoolean(b(1))
                    End Select

                    'Dim J As Integer = 0
                    'J = DimmerControls(I).Automation.Max - DimmerControls(I).Automation.Min
                    'If DimmerControls(I).Automation.Timebetween = 0 Then DimmerControls(I).Automation.Timebetween = nudAutoTimebetween.Value
                    'DimmerControls(I).Automation.Interval = J / (DimmerControls(I).Automation.Timebetween / 10)

                    I += 1
                Loop
                Dim J As Integer = 0
                J = DimmerControls(a(0)).Automation.Max - DimmerControls(a(0)).Automation.Min

                DimmerControls(a(0)).Automation.Interval = J / (DimmerControls(a(0)).Automation.Timebetween / 10)
                If DimmerControls(a(0)).Automation.tTimer.Enabled = True Then
                    DimmerControls(a(0)).Automation.tTimer.Stop()
                    If DimmerControls(a(0)).Automation.randomstart = True Then
                        DimmerControls(a(0)).vScroll.Value = GetRandom(DimmerControls(a(0)).Automation.Min, DimmerControls(a(0)).Automation.Max)
                    End If

                    DimmerControls(a(0)).Automation.tTimer.Start()
                End If
                '
            End If


        Loop
        FileClose(1)

        ProcessFixtures()
        txtMaster_TextChanged(sender, e) 'update

    End Sub

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
        'Return CInt(Math.Ceiling(Rnd() * Max))



    End Function


    Private Sub lstSongs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSongs.SelectedIndexChanged
        'If Player.currentMedia. = True Then Exit Sub
        If lstSongs.SelectedIndex = -1 Then Exit Sub

        Dim I As Integer = 0
        'Array.Clear(Mp3Changes, 0, Mp3Changes.Length - 1)
        lstSongChanges.Items.Clear()
        If File.Exists(Application.StartupPath & "\Save Files\" & lstBank.SelectedItem & "\" & lstSongs.SelectedItem & ".chg") = False Then GoTo AfterChgFile

        FileOpen(1, Application.StartupPath & "\Save Files\" & lstBank.SelectedItem & "\" & lstSongs.SelectedItem & ".chg", OpenMode.Input)
        Do Until EOF(1)
            lstSongChanges.Items.Add(LineInput(1))
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


        Player.URL = Application.StartupPath & "\Save Files\" & lstBank.SelectedItem & "\" & lstSongs.SelectedItem & ".mp3"

        lblMP3Duration.Text = Player.currentMedia.durationString



    End Sub

    Private Sub cmdPresetOverwrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPresetOverwrite.Click
        If lstBank.SelectedIndex = -1 Then Exit Sub
        If lstPresets.SelectedIndex = -1 Then Exit Sub

        SavePreset(lstPresets.SelectedItem)
    End Sub

    Private Sub SecondEachWayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SecondEachWayToolStripMenuItem.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)

        MessageBox.Show(cms.SourceControl.Name)
    End Sub

    Private Sub cmdMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMode.Click
        If cmdMode.Text = "Automation Mode" Then
            lstSongs.Visible = False
            lstSongs2.Visible = False
            cmdEditSong.Visible = False
            lstSongChanges.Visible = False
            lstSongChanges2.Visible = False
            cmdPlay.Visible = False
            cmdStop.Visible = False
            cmdPlay2.Visible = False
            cmdStop2.Visible = False
            Label6.Visible = False
            lblMP3Duration.Visible = False
            lblMP3Duration2.Visible = False
            Label4.Visible = False
            lblMP3Position.Visible = False
            lblMP3PositionMilli.Visible = False
            lblMP3Position2.Visible = False
            lblMP3PositionMilli2.Visible = False
            Label3.Visible = False
            lblMP3Remaining.Visible = False
            trkVolume.Visible = False
            trkVolume2.Visible = False
            cmdSkip.Visible = False
            cmdSkip2.Visible = False
            Label9.Visible = False
            Label12.Visible = False

            cmdMode.Text = "Song Mode"
            lstAutomationPresets.Visible = True
            lblAutoMaxlbl.Visible = True
            nudAutoMax.Visible = True
            lblAutoMinlbl.Visible = True
            nudAutoMin.Visible = True
            chkAutoStartRandom.Visible = True
            chkAutoRunning.Visible = True
            lblAutoTimebetweenlbl.Visible = True
            nudAutoTimebetween.Visible = True
        Else
            lstSongs.Visible = True
            cmdEditSong.Visible = True
            lstSongChanges.Visible = True
            cmdPlay.Visible = True
            cmdStop.Visible = True
            Label6.Visible = True
            lblMP3Duration.Visible = True
            Label4.Visible = True
            lblMP3Position.Visible = True
            lblMP3PositionMilli.Visible = True
            Label3.Visible = True
            lblMP3Remaining.Visible = True
            trkVolume.Visible = True
            trkVolume2.Visible = True
            cmdSkip.Visible = True
            cmdSkip2.Visible = True
            Label9.Visible = True
            Label12.Visible = True
            lblMP3Position2.Visible = True
            lblMP3PositionMilli2.Visible = True
            lblMP3Duration2.Visible = True
            cmdPlay2.Visible = True
            cmdStop2.Visible = True
            lstSongChanges2.Visible = True
            lstSongs2.Visible = True

            cmdMode.Text = "Automation Mode"
            lstAutomationPresets.Visible = False
            lblAutoMaxlbl.Visible = False
            nudAutoMax.Visible = False
            lblAutoMinlbl.Visible = False
            nudAutoMin.Visible = False
            chkAutoStartRandom.Visible = False
            chkAutoRunning.Visible = False
            lblAutoTimebetweenlbl.Visible = False
            nudAutoTimebetween.Visible = False
        End If

    End Sub

    Private Sub chkAutoRunning_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoRunning.CheckedChanged
        If opened = False Then Exit Sub
        Dim I As Integer = 1
        Do Until I > numEndChannel.Value
            If DimmerControls(I).sButton.BackColor = Color.Red Then
                If chkAutoRunning.Checked = True Then
                    Dim J As Integer = 0
                    J = DimmerControls(I).Automation.Max - DimmerControls(I).Automation.Min
                    If DimmerControls(I).Automation.Timebetween = 0 Then DimmerControls(I).Automation.Timebetween = nudAutoTimebetween.Value
                    DimmerControls(I).Automation.Interval = J / (DimmerControls(I).Automation.Timebetween / 10)
                    If DimmerControls(I).Automation.randomstart = True Then
                        DimmerControls(I).vScroll.Value = GetRandom(DimmerControls(I).Automation.Min, DimmerControls(I).Automation.Max)
                    End If
                End If
                DimmerControls(I).Automation.tTimer.Enabled = chkAutoRunning.Checked
            End If
            I += 1
        Loop
    End Sub

    Private Sub nudAutoMax_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudAutoMax.ValueChanged
        If opened = False Then Exit Sub
        Dim I As Integer = 0
        Do Until I > numEndChannel.Value
            If DimmerControls(I).sButton.BackColor = Color.Red Then
                DimmerControls(I).Automation.Max = nudAutoMax.Value
            End If
            I += 1
        Loop
    End Sub

    Private Sub nudAutoMin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudAutoMin.ValueChanged
        If opened = False Then Exit Sub
        Dim I As Integer = 0
        Do Until I > numEndChannel.Value
            If DimmerControls(I).sButton.BackColor = Color.Red Then
                DimmerControls(I).Automation.Min = nudAutoMin.Value
            End If
            I += 1
        Loop
    End Sub

    Private Sub chkAutoStartRandom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoStartRandom.CheckedChanged
        If opened = False Then Exit Sub
        Dim I As Integer = 0
        Do Until I > numEndChannel.Value
            If DimmerControls(I).sButton.BackColor = Color.Red Then
                DimmerControls(I).Automation.randomstart = chkAutoStartRandom.Checked
            End If
            I += 1
        Loop
    End Sub

    Private Sub nudAutoTimebetween_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudAutoTimebetween.ValueChanged
        If opened = False Then Exit Sub
        Dim I As Integer = 0
        Do Until I > numEndChannel.Value
            If DimmerControls(I).sButton.BackColor = Color.Red Then
                DimmerControls(I).Automation.Timebetween = nudAutoTimebetween.Value
            End If
            I += 1
        Loop
    End Sub

    Private Sub cmdTimerStartstop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTimerRestart.Click

    End Sub

    Private Sub cmdSize_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSize.DoubleClick
        MsgBox("o hai!")
    End Sub

    Private Sub vsSelected_ValueChanged(ByVal sender As System.Object) Handles vsSelected.ValueChanged
        Try
            txtSelected.Text = vsSelected.Value
        Catch ex As Exception

        End Try

    End Sub

    Private Sub vsMaster_ValueChanged(ByVal sender As System.Object) Handles vsMaster.ValueChanged
        txtMaster.Text = vsMaster.Value
    End Sub

    Private Sub cmdPresetchange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPresetchange.Click
        If currentview = "Channels" Then
            tcDimmers.Visible = True
            currentview = "Presets"
            tcDimmers.BringToFront()
            cmdUnselectAll_Click(sender, Nothing)
            tcDimmers.SelectedTab = tbpPresets
        Else
            tcDimmers.Visible = False
            currentview = "Channels"
        End If

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditSong.Click
        If lstSongs.SelectedIndex = -1 Then Exit Sub

        If sender.Text = "Edit Song" Then
            Me.Controls.Remove(lstSongChanges)
            Me.Controls.Remove(lstPresets)
            lstSongChanges.Location = New Point(22, 22)
            lstPresets.Location = New Point(367, 22)
            tbpSongEdit.Controls.Add(lstSongChanges)
            tbpSongEdit.Controls.Add(lstPresets)
            cmdEditSongSave.Visible = True
            lstBank.Visible = False
            'Make sure no mp3 is playing
            'MP3.MP3Stop()
            'load mp3 and play

            'MP3.MP3File = Application.StartupPath & "\Save Files\" & lstBank.SelectedItem & "\" & lstSongs.SelectedItem & ".mp3"




            'Dim a() As String = Split(MP3.MP3Duration, ":")
            'Dim mDur As Integer = 0

            'mDur = (Val(a(0)) * 60) * 1000
            'mDur += Val(a(1)) * 1000



            'vSongEdit.Maximum = mDur

            tcDimmers.Visible = True
            tcDimmers.BringToFront()
            tcDimmers.SelectedTab = tbpSongEdit
            currentview = "Presets"
            cmdUnselectAll_Click(sender, Nothing)

            cmdEditSong.Text = "Close Edit"
            vSongEdit.Enabled = True

        Else
            cmdEditSongSave.Visible = False
            lstBank.Visible = True
            tbpSongEdit.Controls.Remove(lstSongChanges)
            tbpSongEdit.Controls.Remove(lstPresets)
            lstSongChanges.Location = New Point(1411, 633)
            lstPresets.Location = New Point(602, 594)
            Me.Controls.Add(lstSongChanges)
            Me.Controls.Add(lstPresets)

            cmdEditSong.Text = "Edit Song"
            cmdPresetchange_Click(sender, e)
            vSongEdit.Enabled = False
        End If



    End Sub

    Private Sub vSongEdit_ValueChanged(ByVal sender As System.Object) Handles vSongEdit.ValueChanged
        If opened = False Then Exit Sub
        If tmrchangedmp3 = True Then Exit Sub
        'If MP3.MP3Playing = False Then

        'Player.controls.pause()
        Player.controls.currentPosition = vSongEdit.Value
        'Player.controls.play()
        updatePlayer()
        ' Allow the app to do some processing
        Application.DoEvents()
        'End If

    End Sub

    Private Sub cmdCreatelink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreatelink.Click
        If lstPresets.SelectedIndex = -1 Then Exit Sub

        lstSongChanges.Items.Add(Player.controls.currentPosition & "|" & lstPresets.SelectedItem)

    End Sub


    Private Sub cmdEditSongSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditSongSave.Click
        FileOpen(1, Application.StartupPath & "\Save Files\" & lstBank.SelectedItem & "\" & lstSongs.SelectedItem & ".chg", OpenMode.Output)
        For Each S As String In lstSongChanges.Items
            PrintLine(1, S)

        Next S

        FileClose(1)
    End Sub

    Private Sub cmdEditSongOverwrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditSongOverwrite.Click
        If lstPresets.SelectedIndex = -1 Then Exit Sub
        If lstSongChanges.SelectedIndex = -1 Then Exit Sub

        'lstSongChanges.SelectedItem = MP3.MP3PositionInMS & "|" & lstPresets.SelectedItem
        lstSongChanges.Items.Item(lstSongChanges.SelectedIndex) = Player.controls.currentPosition & "|" & lstPresets.SelectedItem

    End Sub

    Sub Summarizer(ByVal inputDevice As InputDevice)
        'Me.inputDevice1 = inputDevice
        ''pitchesPressed = New Dictionary(Of Pitch, Boolean)()
        ''inputDevice.NoteOn += New InputDevice.NoteOnHandler(AddressOf Me.NoteOn)
        'AddHandler inputDevice.NoteOn, AddressOf Me.NoteOn
        ''inputDevice.NoteOff += New InputDevice.NoteOffHandler(AddressOf Me.NoteOff)
        'AddHandler inputDevice.NoteOff, AddressOf Me.NoteOff
        ''PrintStatus()
    End Sub

    Dim midipressed As Thread = Nothing
    Private pitchpressed1 As String

    Private Sub midipressedSafe()
        SetText(pitchpressed1)
    End Sub

    Dim chanupto As Integer = 1

    Private Sub SetText(ByVal [text] As String)
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If lstMidi.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {[text]})
        Else
            lstMidi.Items.Clear()
            lstMidi.Items.Add([text])
            FileOpen(7, Application.StartupPath & "\MidiControls.ini", OpenMode.Append)
            PrintLine(7, [text] & "|" & chanupto & "|False|False") 'Dim MidiNoteName As String
            chanupto += 1
            FileClose(7)
            MidControls([text])

            'CSharpNeg1|1|False|False
        End If

    End Sub

    Delegate Sub SetTextCallback(ByVal [text] As String)
    Dim lastmidinote As String = ""
    Sub MidControls(ByVal notetext As String)

        If notetext = lastmidinote Then
            lblMidiCount.Text = Val(lblMidiCount.Text) + 1
        Else
            lblMidiCount.Text = 1
            lastmidinote = notetext
        End If

        'MidiButtons
        Dim I As Integer = 0
        Do Until I >= MidiButtons.Length
            If MidiButtons(I).MidiNoteName = "" Then
                MidiButtons(I).MidiNoteName = notetext
                MidiButtons(I).CurrentSituation = True
                Exit Do
            ElseIf MidiButtons(I).MidiNoteName = notetext Then
                If MidiButtons(I).CurrentSituation = True Then
                    MidiButtons(I).CurrentSituation = False
                Else
                    MidiButtons(I).CurrentSituation = True
                End If
                'If MidiButtons(I).MidiNoteName = "CNeg1" Then lblCNeg1.Text = MidiButtons(I).CurrentSituation.ToString
                'If MidiButtons(I).MidiNoteName = "CSharpNeg1" Then lblCSharpNeg1.Text = MidiButtons(I).CurrentSituation.ToString
                'If MidiButtons(I).MidiNoteName = "DNeg1" Then lblDNeg1.Text = MidiButtons(I).CurrentSituation.ToString
                'If MidiButtons(I).MidiNoteName = "DSharpNeg1" Then lblDSharpNeg1.Text = MidiButtons(I).CurrentSituation.ToString
                Exit Do
            End If
            I += 1
        Loop
        'MidiButtons(

        Dim sender As Object = Nothing
        Dim e As EventArgs = Nothing
        Select Case notetext
            Case "CNeg1"
                'dostuff
                If chkRecordspace.Checked = True Then
                    If lstPresets.SelectedIndex = -1 Then Exit Sub
                    Dim KeyDir As String = "Down"
                    If MidiButtons(I).CurrentSituation = True Then KeyDir = "Down"
                    If MidiButtons(I).CurrentSituation = False Then KeyDir = "Up"

                    lstSongChanges.Items.Add(Player.controls.currentPosition & "|" & KeyDir)
                    If File.Exists(Application.StartupPath & "\Save Files\" & lstBank.Text & "\" & KeyDir & ".dmr") = False Then
                        File.Copy(Application.StartupPath & "\Save Files\" & lstBank.Text & "\" & lstPresets.SelectedItem & ".dmr", Application.StartupPath & "\Save Files\" & lstBank.Text & "\" & KeyDir & ".dmr")

                    End If
                End If
            Case "G6" 'Back 1
                If MidiButtons(I).CurrentSituation = True Then
                    If Not cmdPlay.Text = "Play" Then Exit Sub
                    If (lstSongs.SelectedIndex - 1) >= 0 Then
                        lstSongs.SelectedIndex -= 1
                    End If
                End If
            Case "ASharp6" 'Play 1
                If MidiButtons(I).CurrentSituation = True Then
                    cmdPlay_Click(sender, e)
                End If
            Case "GSharp6" 'Forward 1
                If MidiButtons(I).CurrentSituation = True Then
                    If Not cmdPlay.Text = "Play" Then Exit Sub
                    If (lstSongs.SelectedIndex + 1) < lstSongs.Items.Count Then
                        lstSongs.SelectedIndex += 1
                    End If
                End If
            Case "D6" 'Repeat 1

            Case "A6" 'Stop 1
                If MidiButtons(I).CurrentSituation = True Then
                    cmdStop_Click(sender, e)
                End If

            Case "B6" 'Record 1

            Case "ASharp7" 'Back 2
                If Not cmdPlay2.Text = "Play" Then Exit Sub
                If MidiButtons(I).CurrentSituation = True Then
                    If (lstSongs2.SelectedIndex - 1) >= 0 Then
                        lstSongs2.SelectedIndex -= 1
                    End If
                End If
            Case "B7" 'Play 2
                If MidiButtons(I).CurrentSituation = True Then
                    cmdPlay2_Click(sender, e)
                End If
            Case "C8" 'Forward 2
                If MidiButtons(I).CurrentSituation = True Then
                    If Not cmdPlay2.Text = "Play" Then Exit Sub
                    If (lstSongs2.SelectedIndex + 1) < lstSongs2.Items.Count Then
                        lstSongs2.SelectedIndex += 1
                    End If
                End If
            Case "CSharp8" 'Repeat 2

            Case "D8" 'Stop 2
                If MidiButtons(I).CurrentSituation = True Then
                    cmdStop2_Click(sender, e)
                End If

            Case "DSharp8" 'Record 2



        End Select
    End Sub

    Dim checkeddouble As Boolean = False

    Public Sub NoteOn(ByVal msg As NoteOnMessage)
                SyncLock Me
            'pitchesPressed(msg.Pitch) = True
            'lstMidi.Items.Add(msg.Pitch.ToString & " | " & "Down")

            pitchpressed1 = msg.Pitch.ToString

            midipressed = New Thread(New ThreadStart(AddressOf Me.midipressedSafe))
            midipressed.Start()



            'PrintStatus()
        End SyncLock
    End Sub

    Public Sub NoteOff(ByVal msg As NoteOffMessage)
        SyncLock Me
            'pitchesPressed.Remove(msg.Pitch)
            'PrintStatus()
        End SyncLock
    End Sub

    Private inputDevice1(8) As InputDevice
    'Private pitchesPressed As Dictionary(Of Pitch, Boolean)

    Public Shared Function ChooseInputDeviceFromConsole(ByVal id As Integer) As InputDevice

        If InputDevice.InstalledDevices.Count = 0 Then
            Return Nothing
        End If
        If InputDevice.InstalledDevices.Count = 1 Then
            Return InputDevice.InstalledDevices(0)
        End If
        Dim msg1 As String = ""
        msg1 &= vbCrLf & "Input Devices:"
        For i As Integer = 0 To InputDevice.InstalledDevices.Count - 1
            'Console.WriteLine("   {0}: {1}", i, inputDevice.InstalledDevices(i))
            msg1 &= vbCrLf & "   " & i & ": " & InputDevice.InstalledDevices(i).ToString
        Next
        msg1 &= vbCrLf & ("Choose the id of an input device...")
        'Dim res As Integer = InputBox(msg1)
        While True
            'Dim keyInfo As ConsoleKeyInfo = Console.ReadKey(True)
            Dim deviceId As Integer = id 'CInt(keyInfo.Key) - CInt(ConsoleKey.D0)
            If deviceId >= 0 AndAlso deviceId < InputDevice.InstalledDevices.Count Then
                Return InputDevice.InstalledDevices(deviceId)
            End If
        End While
    End Function

    Dim uptoInputI As Integer = 0
    Public Sub Run()
        ' Prompt user to choose an input device (or if there is only one, use that one).
        Do Until uptoInputI >= inputDevice1.Length Or uptoInputI >= (InputDevice.InstalledDevices.Count - 1)

            Dim inputDevice As InputDevice = ChooseInputDeviceFromConsole(uptoInputI)
            If inputDevice Is Nothing Then
                'Console.WriteLine("No input devices, so can't run this example.")
                'ExampleUtil.PressAnyKeyToContinue()
                Return
            End If
            inputDevice.Open()

            inputDevice.StartReceiving(Nothing)

            'Dim summarizer As New Summarizer(inputDevice)
            Me.inputDevice1(uptoInputI) = inputDevice
            AddHandler inputDevice.NoteOn, AddressOf Me.NoteOn
            AddHandler inputDevice.NoteOff, AddressOf Me.NoteOff

            uptoInputI += 1
        Loop
        'ExampleUtil.PressAnyKeyToContinue()
        'inputDevice.StopReceiving()
        'inputDevice.Close()
        'inputDevice.RemoveAllEventHandlers()
    End Sub

    Private Sub cmdPlay2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlay2.Click
        If lstSongs2.SelectedIndex = -1 Then Exit Sub
        If cmdPlay2.Text = "Play" Then

            Player2.controls.play()


            'Make sure no mp3 is playing
            'MP3.MP3Stop()
            'load mp3 and play

            'MP3.MP3File = Application.StartupPath & "\Save Files\" & lstBank.SelectedItem & "\" & lstSongs.SelectedItem & ".mp3"
            'MP3.MP3Play()
            'lblMP3Duration.Text = MP3.MP3Duration

            'Dim a2() As String = Split(MP3.MP3Duration, ":")
            'Dim mDur As Integer = 0
            'mDur = (Val(a2(0)) * 60) * 1000
            'mDur += Val(a2(1)) * 1000
            'vSongEdit.Maximum = mDur


            If lstSongChanges2.Items.Count > 0 Then
                Dim a() As String = Split(lstSongChanges2.Items.Item(0), "|")
                NextMP3Change2 = a(0)
                lstSongChanges2.SelectedIndex = -1
            End If

            cmdPlay2.Text = "Pause"
            tmrMP32.Interval = 50
            tmrMP32.Start()
            tmrMP32_Tick(sender, e)
            lstSongs2.Enabled = False
            Exit Sub
        ElseIf cmdPlay2.Text = "Pause" Then
            'MP3.MP3Pause()
            Player2.controls.pause()
            cmdPlay2.Text = "Resume"
            tmrMP32.Enabled = False
            Exit Sub
        ElseIf cmdPlay2.Text = "Resume" Then
            Player2.controls.play()
            cmdPlay2.Text = "Pause"

            tmrMP32.Start()
            Exit Sub
        End If
    End Sub

    Private Sub tmrMP32_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMP32.Tick
        updatePlayer2()
    End Sub

    Private Sub cmdSkip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSkip.Click
        If lstSongs.Items.Count >= (lstSongs.SelectedIndex + 1) Then
            Player.controls.stop()
            tmrMP3.Stop()
            cmdPlay.Text = "Play"
            cmdEditPlay.Text = "Play"
            lstSongs.Enabled = True

            lstSongs.SelectedIndex += 1

            cmdPlay_Click(sender, e)

        End If




    End Sub

    Private Sub cmdSkip2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSkip2.Click
        If lstSongs2.Items.Count >= (lstSongs2.SelectedIndex + 1) Then
            Player2.controls.stop()
            tmrMP32.Stop()
            cmdPlay2.Text = "Play"
            lstSongs2.Enabled = True

            lstSongs2.SelectedIndex += 1

            cmdPlay2_Click(sender, e)

        End If
    End Sub

    Private Sub lstSongs2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSongs2.SelectedIndexChanged
        'If Player.currentMedia. = True Then Exit Sub
        If lstSongs2.SelectedIndex = -1 Then Exit Sub

        Dim I As Integer = 0
        'Array.Clear(Mp3Changes, 0, Mp3Changes.Length - 1)
        lstSongChanges2.Items.Clear()
        If File.Exists(Application.StartupPath & "\Save Files\" & lstBank.SelectedItem & "\" & lstSongs2.SelectedItem & ".chg") = False Then GoTo AfterChgFile

        FileOpen(1, Application.StartupPath & "\Save Files\" & lstBank.SelectedItem & "\" & lstSongs2.SelectedItem & ".chg", OpenMode.Input)
        Do Until EOF(1)
            lstSongChanges2.Items.Add(LineInput(1))
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


        Player2.URL = Application.StartupPath & "\Save Files\" & lstBank.SelectedItem & "\" & lstSongs2.SelectedItem & ".mp3"

        lblMP3Duration2.Text = Player2.currentMedia.durationString
        Player2.controls.stop()
    End Sub

    Private Sub cmdStop2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop2.Click
        'MP3.MP3Stop()
        Player2.controls.stop()
        tmrMP32.Stop()
        cmdPlay2.Text = "Play"
        lstSongs2.Enabled = True
    End Sub

    Private Sub trkVolume2_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trkVolume2.Scroll
        ' Change the player's volume
        Player2.settings.volume = trkVolume2.Value
    End Sub

    Private Sub tmrMaster_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMaster.Tick
        If tmrMasterWay = "Down" Then
            Label8.Visible = False
            If (vsMaster.Value - tmrMasterInterval) <= 0 Then
                tmrMaster.Stop()
                tmrMasterWay = "lol"
                Label8.Visible = True
            End If
            vsMaster.Value -= tmrMasterInterval

        ElseIf tmrMasterWay = "Up" Then
            Label8.Visible = False
            If (vsMaster.Value + tmrMasterInterval) >= 100 Then
                tmrMaster.Stop()
                tmrMasterWay = "lol"
                Label8.Visible = True
            End If
            vsMaster.Value += tmrMasterInterval

        End If
    End Sub

End Class
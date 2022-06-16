Option Strict Off
Option Explicit On
Imports System.IO

Public Class Form1

    Dim MP3 As New MP3Class

    Dim opened As Boolean = False
    Dim Testmode As Boolean = False
    Dim controlcolour As Color

    'Dim DimmerControls(512) As DimmerControls1
    'Dim FixtureChannelLocations(512) As FixtureChannelLocations1          'Has Fixture data specific to the Dimmer Channels
    'Dim FixtureControls(512) As FixtureControls1  'Has Parent Fixture only data
    'Dim FixtureChannels(512) As FixtureChannels1  'Has Child one-to-many data on specific fixture channels
    Dim PresetControls(40) As PresetControls1
    Dim DmrControlslengthset(512) As DimmerControls1

    Dim runonce As Boolean = False

    Dim MS As Integer = 0 'MP3.MP3PositionInMS
    Dim S As Integer = 0 'Math.Round(MS / 1000)
    Dim M As Integer = 0 'Math.Round(S / 60)

    'Dim ctxmnuFixtureChild(500) As ToolStripMenuItem

    Dim currentview As String = "Channels"

    'Dim Mp3Changes(1000) As MP3changes1
    Dim NextMP3Change As Integer
    Dim tmrchangedmp3 As Boolean = False


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
        Dim tTimer As Timer
        Dim Max As Integer
        Dim Min As Integer
        Dim Interval As Integer
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

    Private Declare Sub StartDevice Lib "k8062d.dll" ()
    Private Declare Sub SetData Lib "k8062d.dll" (ByVal Channel As Integer, ByVal Data As Integer)
    Private Declare Sub SetChannelCount Lib "k8062d.dll" (ByVal Count As Integer)
    Private Declare Sub StopDevice Lib "k8062d.dll" ()

    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        StopDevice()
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
        'If opened = False Then Exit Sub
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



            PresetControls(I).Automation.tTimer = New Timer
            With PresetControls(I).Automation.tTimer
                .Enabled = False
                .Interval = 10
                .Tag = "dmrtmr" & I

            End With

            PresetControls(I).Automation.Max = 255
            PresetControls(I).Automation.Min = 0
            PresetControls(I).Automation.Timebetween = 1000


            AddHandler PresetControls(I).vScroll.ValueChanged, AddressOf vPresetScroll_Scroll
            AddHandler PresetControls(I).vtxtBox.TextChanged, AddressOf vPresettxtBox_TextChanged
            AddHandler PresetControls(I).Automation.tTimer.Tick, AddressOf tTimerPreset_Tick

            tbpPresets.Controls.Add(PresetControls(I).vScroll)
            tbpPresets.Controls.Add(PresetControls(I).clbl)
            tbpPresets.Controls.Add(PresetControls(I).vtxtBox)

            I += 1
        Loop






    End Sub

    Private Sub vPresetScroll_Scroll(ByVal Sender As System.Object)
        If opened = False Then Exit Sub
        If otherChanged = True Then otherChanged = False : Exit Sub
        If selectedchanged = True Then Exit Sub

        Dim I As Integer = Mid(Sender.name, 6)

        PresetControls(I).vtxtBox.Text = Sender.value

    End Sub

    Private Sub vPresettxtBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If opened = False Then Exit Sub
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
        If Environment.GetCommandLineArgs.Length > 1 Then
            If Environment.GetCommandLineArgs(1) = "-Testmode" Then Testmode = True
        End If
        If File.Exists(Application.StartupPath & "\Testmode.txt") = True Then Testmode = True


        controlcolour = Me.BackColor
        Me.BackColor = Color.Black
        LoadSettings()
        'MsgBox("Generating app controls, may take time!")
        Application.DoEvents()

        LoadBanks()
        'lstBank.SelectedIndex = 0
        'lstBank_SelectedIndexChanged(sender, e)
        'lstPresets.SelectedIndex = 0
        'lstPresets_SelectedIndexChanged(sender, e)

        'Dim openingindex As Integer = 0


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

        Do Until I >= DmrControlslengthset.Length

            DmrControlslengthset(I).sButton = New Button
            With DmrControlslengthset(I).sButton
                .Size = New Point(23, 23)
                .Text = "S"
                .Name = "dmrbtn" & I
                .BackColor = controlcolour
                '.ContextMenuStrip = ctxCMDs
            End With

            'DmrControlslengthset(I).vScroll = New VScrollBar
            DmrControlslengthset(I).vScroll = New GScrollBar
            With DmrControlslengthset(I).vScroll
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

            DmrControlslengthset(I).vtxtBox = New TextBox
            With DmrControlslengthset(I).vtxtBox
                .Size = New Point(24, 20)
                .Text = "0"
                .Name = "dmrtxtv" & I
            End With

            DmrControlslengthset(I).clbl = New Label
            With DmrControlslengthset(I).clbl
                .AutoSize = False
                .Size = New Point(26, 13)
                .Text = I
                .Name = "dmrlbl" & I
                .ForeColor = Color.Lime
            End With

            DmrControlslengthset(I).Automation.tTimer = New Timer
            With DmrControlslengthset(I).Automation.tTimer
                .Enabled = False
                .Interval = 10
                .Tag = "dmrtmr" & I

            End With

            DmrControlslengthset(I).flbl = New Label
            With DmrControlslengthset(I).flbl
                .AutoSize = False
                .Size = New Point(34, 16)
                .Text = I
                .Name = "dmrFixture" & I
                .ForeColor = Color.Lime
                .BackColor = Color.Red
                .Visible = False
            End With

            DmrControlslengthset(I).vDimmable = True
            DmrControlslengthset(I).Automation.Max = 255
            DmrControlslengthset(I).Automation.Min = 0
            DmrControlslengthset(I).Automation.Timebetween = 1000

            AddHandler DmrControlslengthset(I).vScroll.ValueChanged, AddressOf vScroll_Scroll 'AddHandler DmrControlslengthset(I).vScroll.Scroll, AddressOf vScroll_Scroll
            AddHandler DmrControlslengthset(I).vtxtBox.TextChanged, AddressOf vtxtBox_TextChanged
            AddHandler DmrControlslengthset(I).sButton.Click, AddressOf sButton_Click
            AddHandler DmrControlslengthset(I).flbl.DoubleClick, AddressOf sButton_DoubleClick
            AddHandler DmrControlslengthset(I).Automation.tTimer.Tick, AddressOf tTimer_Tick

            AddHandler DmrControlslengthset(I).vScroll.KeyDown, AddressOf Form1_KeyDown
            AddHandler DmrControlslengthset(I).vtxtBox.KeyDown, AddressOf Form1_KeyDown
            AddHandler DmrControlslengthset(I).sButton.KeyDown, AddressOf Form1_KeyDown

            AddHandler DmrControlslengthset(I).vScroll.KeyUp, AddressOf Form1_KeyUp
            AddHandler DmrControlslengthset(I).vtxtBox.KeyUp, AddressOf Form1_KeyUp
            AddHandler DmrControlslengthset(I).sButton.KeyUp, AddressOf Form1_KeyUp

            I += 1
        Loop

        For Each c As Control In Me.Controls
            AddHandler c.KeyDown, AddressOf Form1_KeyDown
            AddHandler c.KeyUp, AddressOf Form1_KeyUp
        Next c


        'LoadControls()
        opened = True


        If Testmode = False Then StartDevice()

        tbpPresets.BackColor = Color.Black
        tbpSongEdit.BackColor = Color.Black

        cmdMode.Text = "Song Mode"
        cmdMode_Click(sender, e)
        'SetChannelCount(512)
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
                    SetChannelCount(a(1))
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
        'If opened = False Then Exit Sub
        Dim prstI As Integer = 0
        Do Until prstI >= PresetControls.Length

            FileOpen(3, Application.StartupPath & "\Fixtures.ini", OpenMode.Input)
            Do Until EOF(3)
                Dim afixtureini() As String = Split(LineInput(3), "|") 'a(2)

                FileOpen(4, Application.StartupPath & "\Fixtures\" & afixtureini(1) & ".fix", OpenMode.Input)
                Dim chancount As Integer = Split(LineInput(4), "=")(1)
                If Not PresetControls(prstI).Dmrs Is Nothing Then
                    PresetControls(prstI).Dmrs(afixtureini(0)).clbl.Text = afixtureini(1)
                    PresetControls(prstI).Dmrs(afixtureini(0)).clbl.BringToFront()
                    PresetControls(prstI).Dmrs(afixtureini(0)).clbl.AutoSize = True
                    Dim chan As Integer = 0
                    Do Until EOF(4)
                        PresetControls(prstI).Dmrs(afixtureini(0) + chan).Fixtures.StartDimmer = afixtureini(0)
                        PresetControls(prstI).Dmrs(afixtureini(0) + chan).Fixtures.FixtureName = afixtureini(1)
                        PresetControls(prstI).Dmrs(afixtureini(0) + chan).Fixtures.Backcolour = Color.FromName(afixtureini(2))
                        PresetControls(prstI).Dmrs(afixtureini(0) + chan).flbl.BackColor = Color.FromName(afixtureini(2))
                        PresetControls(prstI).Dmrs(afixtureini(0) + chan).Fixtures.Forecolour = Color.FromName(afixtureini(3))
                        PresetControls(prstI).Dmrs(afixtureini(0) + chan).flbl.ForeColor = Color.FromName(afixtureini(3))
                        PresetControls(prstI).Dmrs(afixtureini(0) + chan).flbl.Visible = True
                        PresetControls(prstI).Dmrs(afixtureini(0) + chan).Fixtures.ChannelCount = chancount
                        PresetControls(prstI).Dmrs(afixtureini(0) + chan).Fixtures.ChannelNum = chan + 1
                        PresetControls(prstI).Dmrs(afixtureini(0) + chan).Fixtures.FixtureString = LineInput(4)
                        Dim a() As String = Split(PresetControls(prstI).Dmrs(afixtureini(0) + chan).Fixtures.FixtureString, "|")
                        If a(0) = "D" Then
                            PresetControls(prstI).Dmrs(afixtureini(0) + chan).vDimmable = True
                        ElseIf a(0) = "X" Then
                            PresetControls(prstI).Dmrs(afixtureini(0) + chan).vDimmable = False
                        End If
                        PresetControls(prstI).Dmrs(afixtureini(0) + chan).Fixtures.FixtureString = a(1)
                        PresetControls(prstI).Dmrs(afixtureini(0) + chan).Fixtures.ChannelName = Split(PresetControls(prstI).Dmrs(afixtureini(0) + chan).Fixtures.FixtureString, ",")(0)
                        PresetControls(prstI).Dmrs(afixtureini(0) + chan).flbl.Text = PresetControls(prstI).Dmrs(afixtureini(0) + chan).Fixtures.ChannelName

                        chan += 1
                    Loop
                End If
                FileClose(4)


            Loop
            FileClose(3)

            prstI += 1
        Loop



        ProcessFixtures()

    End Sub

    Private Sub ProcessSingleFixture(ByVal channum As Integer)
        'Dim I As Integer = channum
        If opened = False Then Exit Sub

        If Not PresetControls(lstPresets.SelectedIndex).Dmrs(channum).Fixtures.FixtureName = "" Then
            Dim a() As String = Split(PresetControls(lstPresets.SelectedIndex).Dmrs(channum).Fixtures.FixtureString, ",")
            If a.Length > 2 Then
                Dim J As Integer = 1
                Do Until J >= a.Length
                    Dim b() As String = Split(a(J), "-")
                    If (PresetControls(lstPresets.SelectedIndex).Dmrs(channum).vScroll.Value) >= Val(b(0)) Then
                        If (PresetControls(lstPresets.SelectedIndex).Dmrs(channum).vScroll.Value) <= Val(b(1)) Then
                            PresetControls(lstPresets.SelectedIndex).Dmrs(channum).Fixtures.ChannelName = a(J - 1)
                            PresetControls(lstPresets.SelectedIndex).Dmrs(channum).flbl.Text = a(J - 1)
                        End If
                    End If
                    J += 2
                Loop

            End If

        End If



    End Sub

    Private Sub ProcessFixtures()
        If opened = False Then Exit Sub

        'Dim I As Integer = 0
        'Do Until I >= numEndChannel.Value

        '    If Not PresetControls(lstPresets.SelectedIndex).Dmrs(I).Fixtures.FixtureName = "" Then
        '        Dim a() As String = Split(PresetControls(lstPresets.SelectedIndex).Dmrs(I).Fixtures.FixtureString, ",")
        '        If a.Length > 2 Then
        '            Dim J As Integer = 1
        '            Do Until J >= a.Length
        '                Dim b() As String = Split(a(J), "-")
        '                If (PresetControls(lstPresets.SelectedIndex).Dmrs(I).vScroll.Value) >= Val(b(0)) Then
        '                    If (PresetControls(lstPresets.SelectedIndex).Dmrs(I).vScroll.Value) <= Val(b(1)) Then
        '                        PresetControls(lstPresets.SelectedIndex).Dmrs(I).Fixtures.ChannelName = a(J - 1)
        '                        PresetControls(lstPresets.SelectedIndex).Dmrs(I).flbl.Text = a(J - 1)
        '                    End If
        '                End If
        '                J += 2
        '            Loop

        '        End If

        '    End If
        '    I += 1
        'Loop
       
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

        If opened = False Then Exit Sub

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
            If PresetControls(lstPresets.SelectedIndex).Dmrs(I).vScroll Is Nothing Then Exit Sub
            PresetControls(lstPresets.SelectedIndex).Dmrs(I).vScroll.Location = New System.Drawing.Point(XStart, vsYr1Start)
            PresetControls(lstPresets.SelectedIndex).Dmrs(I).sButton.Location = New System.Drawing.Point(XStart, bYr1Start)
            PresetControls(lstPresets.SelectedIndex).Dmrs(I).clbl.Location = New System.Drawing.Point(XStart, lblYr1Start)
            PresetControls(lstPresets.SelectedIndex).Dmrs(I).vtxtBox.Location = New System.Drawing.Point(XStart, txtYr1Start)
            PresetControls(lstPresets.SelectedIndex).Dmrs(I).flbl.Location = New System.Drawing.Point(XStart, fixYr1Start)
            Me.Controls.Add(PresetControls(lstPresets.SelectedIndex).Dmrs(I).vScroll)
            Me.Controls.Add(PresetControls(lstPresets.SelectedIndex).Dmrs(I).clbl)
            Me.Controls.Add(PresetControls(lstPresets.SelectedIndex).Dmrs(I).sButton)
            Me.Controls.Add(PresetControls(lstPresets.SelectedIndex).Dmrs(I).vtxtBox)
            Me.Controls.Add(PresetControls(lstPresets.SelectedIndex).Dmrs(I).flbl)
            XStart += 35
            Application.DoEvents()
            I += 1
        Loop


        XStart = 28
        Iend += 40
        Do Until I >= Iend
            PresetControls(lstPresets.SelectedIndex).Dmrs(I).vScroll.Location = New Point(XStart, vsYr2Start)
            PresetControls(lstPresets.SelectedIndex).Dmrs(I).sButton.Location = New Point(XStart, bYr2Start)
            PresetControls(lstPresets.SelectedIndex).Dmrs(I).clbl.Location = New Point(XStart, lblYr2Start)
            PresetControls(lstPresets.SelectedIndex).Dmrs(I).vtxtBox.Location = New Point(XStart, txtYr2Start)
            PresetControls(lstPresets.SelectedIndex).Dmrs(I).flbl.Location = New Point(XStart, fixYr2Start)
            Me.Controls.Add(PresetControls(lstPresets.SelectedIndex).Dmrs(I).vScroll)
            Me.Controls.Add(PresetControls(lstPresets.SelectedIndex).Dmrs(I).clbl)
            Me.Controls.Add(PresetControls(lstPresets.SelectedIndex).Dmrs(I).sButton)
            Me.Controls.Add(PresetControls(lstPresets.SelectedIndex).Dmrs(I).vtxtBox)
            Me.Controls.Add(PresetControls(lstPresets.SelectedIndex).Dmrs(I).flbl)
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
        '        PresetControls(lstPresets.selectedIndex).Dmrs(I).vScroll.Location = New Point(XStart, vsYr2Start)
        '        PresetControls(lstPresets.selectedIndex).Dmrs(I).sButton.Location = New Point(XStart, bYr2Start)
        '        PresetControls(lstPresets.selectedIndex).Dmrs(I).clbl.Location = New Point(XStart, lblYr2Start)
        '        PresetControls(lstPresets.selectedIndex).Dmrs(I).vtxtBox.Location = New Point(XStart, txtYr2Start)
        '        PresetControls(lstPresets.selectedIndex).Dmrs(I).flbl.Location = New Point(XStart, fixYr2Start)
        '        Me.Controls.Add(PresetControls(lstPresets.selectedIndex).Dmrs(I).vScroll)
        '        Me.Controls.Add(PresetControls(lstPresets.selectedIndex).Dmrs(I).clbl)
        '        Me.Controls.Add(PresetControls(lstPresets.selectedIndex).Dmrs(I).sButton)
        '        Me.Controls.Add(PresetControls(lstPresets.selectedIndex).Dmrs(I).vtxtBox)
        '        Me.Controls.Add(PresetControls(lstPresets.selectedIndex).Dmrs(I).flbl)
        '        XStart += 35
        '        Application.DoEvents()
        '        I += 1
        '    Loop




        'End If





    End Sub


    Private Sub vScroll_Scroll(ByVal Sender As System.Object) 'ByVal sender As System.Object, ByVal e As System.EventArgs)
        If opened = False Then Exit Sub
        If otherChanged = True Then otherChanged = False : Exit Sub
        If selectedchanged = True Then Exit Sub

        Dim a() As String = Split(Mid(Sender.name, 6), "|")
        If a.Length = 1 Then Exit Sub
        Dim channel As Integer = a(0)
        Dim preset As Integer = a(1)

        'cmdUnselectAll_Click(Sender, Nothing)
        'PresetControls(lstPresets.selectedIndex).Dmrs(I).sButton.BackColor = Color.Red



        ''otherChanged = True
        ''If PresetControls(lstPresets.selectedIndex).Dmrs(I).flbl.Visible = True Then ProcessSingleFixture(I) 'Is Fixture

        If lstPresets.SelectedIndex = -1 Then Exit Sub

        PresetControls(preset).Dmrs(channel).vtxtBox.Text = Sender.value


        ''SetChannelData(I, sender.value)
    End Sub

    Private Sub vtxtBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If opened = False Then Exit Sub
        If otherChanged = True Then otherChanged = False : Exit Sub
        If selectedchanged = True Then Exit Sub
        If sender.Text = "" Then Exit Sub

        Dim a() As String = Split(Mid(sender.name, 8), "|")
        If a.Length = 1 Then Exit Sub
        Dim channel As Integer = a(0)
        Dim preset As Integer = a(1)

        If Val(sender.Text) > 255 Then sender.Text = 255
        If Val(sender.Text) < 0 Then sender.Text = 0
        PresetControls(preset).Dmrs(channel).vScroll.Value = Val(sender.text)

        'cmdUnselectAll_Click(sender, Nothing)
        'PresetControls(lstPresets.selectedIndex).Dmrs(I).sButton.BackColor = Color.Red

        SetChannelData(channel, Val(sender.text), preset)
        'otherChanged = True




    End Sub

    Private Sub sButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.backcolor = Color.Red Then
            sender.backcolor = controlcolour

            GoTo shiftDown
        End If

        If sender.backcolor = controlcolour Then
            sender.backcolor = Color.Red

            Dim a() As String = Split(Mid(sender.Name, 7), "|")
            Dim num As Integer = a(0)
            Dim preset As Integer = a(1)

            nudAutoMax.Value = PresetControls(lstPresets.SelectedIndex).Dmrs(num).Automation.Max
            nudAutoMin.Value = PresetControls(lstPresets.SelectedIndex).Dmrs(num).Automation.Min
            nudAutoTimebetween.Value = PresetControls(lstPresets.SelectedIndex).Dmrs(num).Automation.Timebetween
            chkAutoRunning.Checked = PresetControls(lstPresets.SelectedIndex).Dmrs(num).Automation.tTimer.Enabled

            GoTo shiftDown
        End If


        'If sender.backcolor = Color.Black Then sender.backcolor = Color.Red : Exit Sub


shiftDown:
        Dim num1 As Integer = Split(Mid(sender.Name, 7), "|")(0)
        If shiftdown = True Then
            Dim I As Integer = LastS
            If num1 > LastS Then
                Do Until I > num1
                    PresetControls(lstPresets.SelectedIndex).Dmrs(I).sButton.BackColor = Color.Red
                    I += 1
                Loop
            End If
        End If

        If ctrldown = True Then
            Dim I As Integer = LastS
            If num1 > LastS Then
                Do Until I > num1
                    PresetControls(lstPresets.SelectedIndex).Dmrs(I).sButton.BackColor = controlcolour
                    I += 1
                Loop
            End If
        End If

        LastS = num1 'dmrbtnI

    End Sub

    Private Sub sButton_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim I As Integer = Mid(sender.Name, 11)
        cmdUnselectAll_Click(sender, Nothing)
        Dim fixname As String = PresetControls(lstPresets.SelectedIndex).Dmrs(I).Fixtures.FixtureName
        Dim fixchan As Integer = PresetControls(lstPresets.SelectedIndex).Dmrs(I).Fixtures.ChannelNum

        For Each c In PresetControls(lstPresets.SelectedIndex).Dmrs
            If c.Fixtures.FixtureName = fixname And c.Fixtures.ChannelNum = fixchan Then
                c.sButton.BackColor = Color.Red
            End If
        Next c

    End Sub

    Private Sub tTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Exit Sub
        '   "prstdmrtmr" & I & "|" & prstI
        'If Split(sender.tag, "dmr")(0) = "prst" Then 'called by preset
        ' prstdmrtmr1|2
        Dim a() As String = Split(sender.tag, "tmr")
        Dim Prstnum As Integer = Split(a(1), "|")(1)
        Dim channum As Integer = Split(a(1), "|")(0)

        Dim curpos As Integer = PresetControls(Prstnum).Dmrs(channum).vScroll.Value

        If PresetControls(Prstnum).Dmrs(channum).Automation.tmrDirection = "Up" Then

            If curpos + PresetControls(Prstnum).Dmrs(channum).Automation.Interval > PresetControls(Prstnum).Dmrs(channum).Automation.Max Then
                PresetControls(Prstnum).Dmrs(channum).Automation.tmrDirection = "Down"
                curpos -= PresetControls(Prstnum).Dmrs(channum).Automation.Interval
            Else
                curpos += PresetControls(Prstnum).Dmrs(channum).Automation.Interval
            End If


        ElseIf PresetControls(Prstnum).Dmrs(channum).Automation.tmrDirection = "Down" Then

            If curpos - PresetControls(Prstnum).Dmrs(channum).Automation.Interval < PresetControls(Prstnum).Dmrs(channum).Automation.Min Then
                PresetControls(Prstnum).Dmrs(channum).Automation.tmrDirection = "Up"
                curpos += PresetControls(Prstnum).Dmrs(channum).Automation.Interval
            Else
                curpos -= PresetControls(Prstnum).Dmrs(channum).Automation.Interval
            End If


        Else
            PresetControls(Prstnum).Dmrs(channum).Automation.tmrDirection = "Up"
            tTimer_Tick(sender, e)
            Exit Sub
        End If

        PresetControls(Prstnum).Dmrs(channum).vScroll.Value = curpos
        'vScroll_Scroll(PresetControls(Prstnum).Dmrs(channum).vScroll, Nothing)



        'Else 'called by dimmers
        '    Dim channum As Integer = Split(sender.tag, "tmr")(1) '.Tag = "dmrtmr" & I

        '    Dim curpos As Integer = DimmerControls(channum).vScroll.Value

        '    If DimmerControls(channum).Automation.tmrDirection = "Up" Then

        '        If curpos + DimmerControls(channum).Automation.Interval > DimmerControls(channum).Automation.Max Then
        '            DimmerControls(channum).Automation.tmrDirection = "Down"
        '            curpos -= DimmerControls(channum).Automation.Interval
        '        Else
        '            curpos += DimmerControls(channum).Automation.Interval
        '        End If


        '    ElseIf DimmerControls(channum).Automation.tmrDirection = "Down" Then

        '        If curpos - DimmerControls(channum).Automation.Interval < DimmerControls(channum).Automation.Min Then
        '            DimmerControls(channum).Automation.tmrDirection = "Up"
        '            curpos += DimmerControls(channum).Automation.Interval
        '        Else
        '            curpos -= DimmerControls(channum).Automation.Interval
        '        End If


        '    Else
        '        DimmerControls(channum).Automation.tmrDirection = "Up"
        '        tTimer_Tick(sender, e)
        '        Exit Sub
        '    End If

        '    DimmerControls(channum).vScroll.Value = curpos
        '    'vScroll_Scroll(DimmerControls(channum).vScroll, Nothing)

        'End If

    End Sub

    Private Sub tTimerPreset_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If opened = False Then Exit Sub
        MsgBox("hmm") : Exit Sub

        Dim channum As Integer = Split(sender.tag, "tmr")(1) '.Tag = "dmrtmr" & I

        Dim curpos As Integer = PresetControls(channum).vScroll.Value

        If PresetControls(channum).Automation.tmrDirection = "Up" Then

            If curpos + PresetControls(channum).Automation.Interval > PresetControls(channum).Automation.Max Then
                PresetControls(channum).Automation.tmrDirection = "Down"
                curpos -= PresetControls(channum).Automation.Interval
            Else
                curpos += PresetControls(channum).Automation.Interval
            End If


        ElseIf PresetControls(channum).Automation.tmrDirection = "Down" Then

            If curpos - PresetControls(channum).Automation.Interval < PresetControls(channum).Automation.Min Then
                PresetControls(channum).Automation.tmrDirection = "Up"
                curpos += PresetControls(channum).Automation.Interval
            Else
                curpos -= PresetControls(channum).Automation.Interval
            End If


        Else
            PresetControls(channum).Automation.tmrDirection = "Up"
            tTimerPreset_Tick(sender, e)
            Exit Sub
        End If

        PresetControls(channum).vScroll.Value = curpos
        'vScroll_Scroll(PresetControls(channum).vScroll, Nothing)

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
        For Each c As DimmerControls1 In PresetControls(lstPresets.SelectedIndex).Dmrs
            c.sButton.BackColor = Color.Red
        Next c
    End Sub

    Private Sub cmdUnselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnselectAll.Click
        For Each c As DimmerControls1 In PresetControls(lstPresets.SelectedIndex).Dmrs
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
            For Each c As DimmerControls1 In PresetControls(lstPresets.SelectedIndex).Dmrs
                If c.sButton.BackColor = Color.Red Then
                    c.vScroll.Value = vsSelected.Value
                    c.vtxtBox.Text = txtSelected.Text
                    If c.flbl.Visible = True Then FixtureRun = True

                    If c.vDimmable = True Then
                        Dim value As Integer = vsSelected.Value
                        'value = value / 100
                        'value = value * (100 - vsMaster.Value)

                        SetChannelData(Split(Mid(c.sButton.Name, 7), "|")(0), value, lstPresets.SelectedIndex)

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
        Do Until I >= PresetControls(lstPresets.SelectedIndex).Dmrs.Length
            If I = numEndChannel.Value Then Exit Sub
            If PresetControls(lstPresets.SelectedIndex).Dmrs(I).vDimmable = True Then
                Dim value As Integer = PresetControls(lstPresets.SelectedIndex).Dmrs(I).vScroll.Value
                'value = value / 100
                'value = value * (100 - vsMaster.Value)
                SetChannelData(I, value, lstPresets.SelectedIndex)
            End If

            I += 1
        Loop
        'ProcessFixtures()
    End Sub

    Private Sub cmdMasterBlackout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMasterBlackout.Click
        txtMaster.Text = 0
        vsMaster.Value = Val(txtMaster.Text)
    End Sub

    Private Sub cmdMasterFull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMasterFull.Click
        txtMaster.Text = 100
        vsMaster.Value = Val(txtMaster.Text)
    End Sub

    Private Sub numEndChannel_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numEndChannel.ValueChanged
        SetChannelCount(numEndChannel.Value)
    End Sub

    Private Sub SetChannelData(ByVal Channel As Integer, ByVal Value As Integer, ByVal Preset As Integer)
        Value = (Value / 100) * Val(txtMaster.Text)
        SetData(Channel, Value)
    End Sub

    Private Sub LoadPresetSliders()


        Dim prstI As Integer = 0
        Do Until prstI >= lstPresets.Items.Count
            PresetControls(prstI).Dmrs = DmrControlslengthset

            FileOpen(2, Application.StartupPath & "\Save Files\" & lstBank.SelectedItem & "\" & lstPresets.Items(prstI) & ".dmr", OpenMode.Input)

            Do Until EOF(2)
                Dim a() As String = Split(LineInput(2), "|")
                If a(0) = "M" Then
                    vsMaster.Value = a(1)
                Else
                    Dim I As Integer = 1
                    'channelresets start
                    PresetControls(prstI).Dmrs(a(0)).vScroll.Value = 255
                    PresetControls(prstI).Dmrs(a(0)).Automation.tTimer.Interval = 10
                    PresetControls(prstI).Dmrs(a(0)).Automation.tTimer.Enabled = False
                    PresetControls(prstI).Dmrs(a(0)).Automation.Max = 255
                    PresetControls(prstI).Dmrs(a(0)).Automation.Min = 0
                    PresetControls(prstI).Dmrs(a(0)).Automation.Timebetween = 1000
                    PresetControls(prstI).Dmrs(a(0)).sButton.BackColor = controlcolour
                    PresetControls(prstI).Dmrs(a(0)).Automation.randomstart = False
                    PresetControls(prstI).Dmrs(a(0)).Automation.tTimer.Tag = "dmrtmr" & a(0) & "|" & prstI
                    PresetControls(prstI).Dmrs(a(0)).clbl.Name = "dmrlbl" & a(0) & "|" & prstI
                    PresetControls(prstI).Dmrs(a(0)).flbl.Name = "dmrFixture" & a(0) & "|" & prstI
                    PresetControls(prstI).Dmrs(a(0)).sButton.Name = "dmrbtn" & a(0) & "|" & prstI
                    PresetControls(prstI).Dmrs(a(0)).vScroll.Name = "dmrvs" & a(0) & "|" & prstI
                    PresetControls(prstI).Dmrs(a(0)).vtxtBox.Name = "dmrtxtv" & a(0) & "|" & prstI

                    'channelresets end
                    Do Until I >= a.Length
                        Dim b() As String = Split(a(I), ",")
                        Select Case b(0)
                            Case "v"
                                PresetControls(prstI).Dmrs(a(0)).vScroll.Value = Val(b(1))
                            Case "tmr"
                                PresetControls(prstI).Dmrs(a(0)).Automation.tTimer.Interval = Val(b(1))
                            Case "timerenabled"
                                PresetControls(prstI).Dmrs(a(0)).Automation.tTimer.Enabled = Convert.ToBoolean(b(1))
                            Case "AutoMax"
                                PresetControls(prstI).Dmrs(a(0)).Automation.Max = Val(b(1))
                            Case "AutoMin"
                                PresetControls(prstI).Dmrs(a(0)).Automation.Min = Val(b(1))
                            Case "AutoTimeBetween"
                                PresetControls(prstI).Dmrs(a(0)).Automation.Timebetween = Val(b(1))
                            Case "RandomStart"
                                PresetControls(prstI).Dmrs(a(0)).Automation.randomstart = Convert.ToBoolean(b(1))
                        End Select

                        'Dim J As Integer = 0
                        'J = PresetControls(prstI).Dmrs(I).Automation.Max - PresetControls(prstI).Dmrs(I).Automation.Min
                        'If PresetControls(prstI).Dmrs(I).Automation.Timebetween = 0 Then PresetControls(prstI).Dmrs(I).Automation.Timebetween = nudAutoTimebetween.Value
                        'PresetControls(prstI).Dmrs(I).Automation.Interval = J / (PresetControls(prstI).Dmrs(I).Automation.Timebetween / 10)

                        I += 1
                    Loop
                    Dim J As Integer = 0
                    J = PresetControls(prstI).Dmrs(a(0)).Automation.Max - PresetControls(prstI).Dmrs(a(0)).Automation.Min

                    PresetControls(prstI).Dmrs(a(0)).Automation.Interval = J / (PresetControls(prstI).Dmrs(a(0)).Automation.Timebetween / 10)
                    If PresetControls(prstI).Dmrs(a(0)).Automation.tTimer.Enabled = True Then
                        PresetControls(prstI).Dmrs(a(0)).Automation.tTimer.Stop()
                        If PresetControls(prstI).Dmrs(a(0)).Automation.randomstart = True Then
                            PresetControls(prstI).Dmrs(a(0)).vScroll.Value = GetRandom(PresetControls(prstI).Dmrs(a(0)).Automation.Min, PresetControls(prstI).Dmrs(a(0)).Automation.Max)
                        End If

                        PresetControls(prstI).Dmrs(a(0)).Automation.tTimer.Start()
                    End If
                    '
                End If


            Loop
            FileClose(2)
            prstI += 1
        Loop

        If runonce = False Then
            LoadFixtures()
            runonce = True
        End If


        'ProcessFixtures()
        'txtMaster_TextChanged(sender, e) 'update
    End Sub

    Private Sub lstBank_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstBank.SelectedIndexChanged
        If lstBank.SelectedIndex = -1 Then Exit Sub
        lstPresets.Items.Clear()
        lstSongs.Items.Clear()
        'If opened = False Then Exit Sub

        For Each S As String In Directory.GetFiles(Application.StartupPath & "\Save Files\" & lstBank.SelectedItem)
            Dim a() As String = Split(S, "\")
            Dim b() As String = Split(a(a.Length - 1), ".")
            If b(1) = "dmr" Then
                lstPresets.Items.Add(b(0))
            ElseIf b(1) = "mp3" Then
                lstSongs.Items.Add(b(0))
            ElseIf b(1) = "chg" Then
                'file with changes for MP3s
            End If
        Next S
        LoadPresetSliders()

        lstPresets.SelectedIndex = 0

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

    Private Sub cmdPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlay.Click, cmdEditPlay.Click
        If lstSongs.SelectedIndex = -1 Then Exit Sub
        If cmdPlay.Text = "Play" Then
            'Make sure no mp3 is playing
            MP3.MP3Stop()
            'load mp3 and play

            MP3.MP3File = Application.StartupPath & "\Save Files\" & lstBank.SelectedItem & "\" & lstSongs.SelectedItem & ".mp3"
            MP3.MP3Play()
            lblMP3Duration.Text = MP3.MP3Duration

            Dim a2() As String = Split(MP3.MP3Duration, ":")
            Dim mDur As Integer = 0
            mDur = (Val(a2(0)) * 60) * 1000
            mDur += Val(a2(1)) * 1000
            vSongEdit.Maximum = mDur


            If lstSongChanges.Items.Count > 0 Then
                Dim a() As String = Split(lstSongChanges.Items.Item(0), "|")
                NextMP3Change = a(0)
                lstSongChanges.SelectedIndex = -1
            End If

            cmdPlay.Text = "Pause"
            cmdEditPlay.Text = "Pause"
            tmrMP3.Interval = 500
            tmrMP3.Start()
            lstSongs.Enabled = False
            Exit Sub
        ElseIf cmdPlay.Text = "Pause" Then
            MP3.MP3Pause()
            cmdPlay.Text = "Resume"
            cmdEditPlay.Text = "Resume"
            tmrMP3.Enabled = False
            Exit Sub
        ElseIf cmdPlay.Text = "Resume" Then
            cmdPlay.Text = "Pause"
            cmdEditPlay.Text = "Pause"
            MP3.MP3Resume()
            tmrMP3.Start()
            Exit Sub
        End If

    End Sub

    Private Sub tmrMP3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMP3.Tick

        MS = MP3.MP3PositionInMS
        lblMP3PositionMilli.Text = MS
        lbleditPositionMilli.Text = MS
        tmrchangedmp3 = True
        vSongEdit.Value = MS


        If lstSongChanges.Items.Count > 0 Then
            If NextMP3Change <= MS And NextMP3Change > -1 Then 'MS
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




        If MS < 1000 Then
            S = 0
        Else
            S = Mid(MS, 1, Len(CStr(MS)) - 3)
        End If

        If S < 60 Then
            M = 0
        Else
            M = S / 60
        End If

        S = S - (M * 60)
        If MS < 1000 Then
            MS = Mid(MS, 1, 2)
        Else
            MS = Mid(MS, Len(CStr(MS)) - 2, 2)
        End If

        lblMP3Position.Text = M & ":" & S & "." & MS
        Dim remS As Integer = 0
        Dim remM As Integer = 0
        Dim a() As String = Split(MP3.MP3Duration, ":")
        Dim b() As String = Split(MP3.MP3Position, ":")

        Try
            remS = a(1) - b(1)
            remM = a(0) - b(0)
        Catch ex As Exception

        End Try


        If remS < 0 Then
            remM -= 1
            remS += 60
        End If

        lblMP3Remaining.Text = remM & ":" & remS
        lbleditRemaining.Text = remM & ":" & remS

        tmrMP3.Interval = 50
    End Sub

    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click, cmdEditStop.Click
        MP3.MP3Stop()
        tmrMP3.Stop()
        cmdPlay.Text = "Play"
        cmdEditPlay.Text = "Play"
        lstSongs.Enabled = True
    End Sub

    Private Sub cmdManualStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdManualStart.Click
        StartDevice()
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
            With PresetControls(lstPresets.SelectedIndex).Dmrs(I)
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
        If opened = False Then Exit Sub
        If chkLoadonChange.Checked = False Then Exit Sub
        UpPresetSlider(lstPresets.SelectedIndex + 1)
        FileOpen(1, Application.StartupPath & "\Save Files\" & lstBank.SelectedItem & "\" & lstPresets.SelectedItem & ".dmr", OpenMode.Input)
        Do Until EOF(1)
            Dim a() As String = Split(LineInput(1), "|")
            If a(0) = "M" Then
                vsMaster.Value = a(1)
            Else
                Dim I As Integer = 1
                'channelresets start
                PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).vScroll.Value = 255
                PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.tTimer.Interval = 10
                PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.tTimer.Enabled = False
                PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.Max = 255
                PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.Min = 0
                PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.Timebetween = 1000
                PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).sButton.BackColor = controlcolour
                PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.randomstart = False
                'channelresets end
                Do Until I >= a.Length
                    Dim b() As String = Split(a(I), ",")
                    Select Case b(0)
                        Case "v"
                            PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).vScroll.Value = Val(b(1))
                        Case "tmr"
                            PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.tTimer.Interval = Val(b(1))
                        Case "timerenabled"
                            PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.tTimer.Enabled = Convert.ToBoolean(b(1))
                        Case "AutoMax"
                            PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.Max = Val(b(1))
                        Case "AutoMin"
                            PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.Min = Val(b(1))
                        Case "AutoTimeBetween"
                            PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.Timebetween = Val(b(1))
                        Case "RandomStart"
                            PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.randomstart = Convert.ToBoolean(b(1))
                    End Select

                    'Dim J As Integer = 0
                    'J = PresetControls(lstPresets.selectedIndex).Dmrs(I).Automation.Max - PresetControls(lstPresets.selectedIndex).Dmrs(I).Automation.Min
                    'If PresetControls(lstPresets.selectedIndex).Dmrs(I).Automation.Timebetween = 0 Then PresetControls(lstPresets.selectedIndex).Dmrs(I).Automation.Timebetween = nudAutoTimebetween.Value
                    'PresetControls(lstPresets.selectedIndex).Dmrs(I).Automation.Interval = J / (PresetControls(lstPresets.selectedIndex).Dmrs(I).Automation.Timebetween / 10)

                    I += 1
                Loop
                Dim J As Integer = 0
                J = PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.Max - PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.Min

                PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.Interval = J / (PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.Timebetween / 10)
                If PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.tTimer.Enabled = True Then
                    PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.tTimer.Stop()
                    If PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.randomstart = True Then
                        PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).vScroll.Value = GetRandom(PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.Min, PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.Max)
                    End If

                    PresetControls(lstPresets.SelectedIndex).Dmrs(a(0)).Automation.tTimer.Start()
                End If
                '
            End If


        Loop
        FileClose(1)

        LoadControls()
        'ProcessFixtures()
        txtMaster_TextChanged(sender, e) 'update

    End Sub

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
        'Return CInt(Math.Ceiling(Rnd() * Max))



    End Function


    Private Sub lstSongs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSongs.SelectedIndexChanged
        If MP3.MP3Playing = True Then Exit Sub
        If lstSongs.SelectedIndex = -1 Then Exit Sub

        Dim I As Integer = 0
        'Array.Clear(Mp3Changes, 0, Mp3Changes.Length - 1)
        lstSongChanges.Items.Clear()
        If File.Exists(Application.StartupPath & "\Save Files\" & lstBank.SelectedItem & "\" & lstSongs.SelectedItem & ".chg") = False Then Exit Sub

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
            cmdEditSong.Visible = False
            lstSongChanges.Visible = False
            cmdPlay.Visible = False
            cmdStop.Visible = False
            Label6.Visible = False
            lblMP3Duration.Visible = False
            Label4.Visible = False
            lblMP3Position.Visible = False
            lblMP3PositionMilli.Visible = False
            Label3.Visible = False
            lblMP3Remaining.Visible = False
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
            If PresetControls(lstPresets.SelectedIndex).Dmrs(I).sButton.BackColor = Color.Red Then
                If chkAutoRunning.Checked = True Then
                    Dim J As Integer = 0
                    J = PresetControls(lstPresets.SelectedIndex).Dmrs(I).Automation.Max - PresetControls(lstPresets.SelectedIndex).Dmrs(I).Automation.Min
                    If PresetControls(lstPresets.SelectedIndex).Dmrs(I).Automation.Timebetween = 0 Then PresetControls(lstPresets.SelectedIndex).Dmrs(I).Automation.Timebetween = nudAutoTimebetween.Value
                    PresetControls(lstPresets.SelectedIndex).Dmrs(I).Automation.Interval = J / (PresetControls(lstPresets.SelectedIndex).Dmrs(I).Automation.Timebetween / 10)
                    If PresetControls(lstPresets.SelectedIndex).Dmrs(I).Automation.randomstart = True Then
                        PresetControls(lstPresets.SelectedIndex).Dmrs(I).vScroll.Value = GetRandom(PresetControls(lstPresets.SelectedIndex).Dmrs(I).Automation.Min, PresetControls(lstPresets.SelectedIndex).Dmrs(I).Automation.Max)
                    End If
                End If
                PresetControls(lstPresets.SelectedIndex).Dmrs(I).Automation.tTimer.Enabled = chkAutoRunning.Checked
            End If
            I += 1
        Loop
    End Sub

    Private Sub nudAutoMax_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudAutoMax.ValueChanged
        If opened = False Then Exit Sub
        Dim I As Integer = 0
        Do Until I > numEndChannel.Value
            If PresetControls(lstPresets.SelectedIndex).Dmrs(I).sButton.BackColor = Color.Red Then
                PresetControls(lstPresets.SelectedIndex).Dmrs(I).Automation.Max = nudAutoMax.Value
            End If
            I += 1
        Loop
    End Sub

    Private Sub nudAutoMin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudAutoMin.ValueChanged
        If opened = False Then Exit Sub
        Dim I As Integer = 0
        Do Until I > numEndChannel.Value
            If PresetControls(lstPresets.SelectedIndex).Dmrs(I).sButton.BackColor = Color.Red Then
                PresetControls(lstPresets.SelectedIndex).Dmrs(I).Automation.Min = nudAutoMin.Value
            End If
            I += 1
        Loop
    End Sub

    Private Sub chkAutoStartRandom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoStartRandom.CheckedChanged
        If opened = False Then Exit Sub
        Dim I As Integer = 0
        Do Until I > numEndChannel.Value
            If PresetControls(lstPresets.SelectedIndex).Dmrs(I).sButton.BackColor = Color.Red Then
                PresetControls(lstPresets.SelectedIndex).Dmrs(I).Automation.randomstart = chkAutoStartRandom.Checked
            End If
            I += 1
        Loop
    End Sub

    Private Sub nudAutoTimebetween_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudAutoTimebetween.ValueChanged
        If opened = False Then Exit Sub
        Dim I As Integer = 0
        Do Until I > numEndChannel.Value
            If PresetControls(lstPresets.SelectedIndex).Dmrs(I).sButton.BackColor = Color.Red Then
                PresetControls(lstPresets.SelectedIndex).Dmrs(I).Automation.Timebetween = nudAutoTimebetween.Value
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
        txtSelected.Text = vsSelected.Value
        

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

            MP3.MP3File = Application.StartupPath & "\Save Files\" & lstBank.SelectedItem & "\" & lstSongs.SelectedItem & ".mp3"




            Dim a() As String = Split(MP3.MP3Duration, ":")
            Dim mDur As Integer = 0

            mDur = (Val(a(0)) * 60) * 1000
            mDur += Val(a(1)) * 1000



            vSongEdit.Maximum = mDur

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
        If MP3.MP3File = "" Then Exit Sub
        If tmrchangedmp3 = True Then tmrchangedmp3 = False : Exit Sub
        'If MP3.MP3Playing = False Then
        MP3.MP3ChangePositionTo(vSongEdit.Value / 1000)
        'End If

    End Sub

    Private Sub cmdCreatelink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreatelink.Click
        If lstPresets.SelectedIndex = -1 Then Exit Sub

        lstSongChanges.Items.Add(MP3.MP3PositionInMS & "|" & lstPresets.SelectedItem)

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
        lstSongChanges.Items.Item(lstSongChanges.SelectedIndex) = MP3.MP3PositionInMS & "|" & lstPresets.SelectedItem

    End Sub

End Class
Option Strict Off
Option Explicit On
Imports System.IO
Imports EnttecOpenDMX.OpenDMX
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports NAudio.Wave
Imports System.Management
Public Class FormChannels

    Public LastSelectedChannel As Integer = 1
    Public shiftdown As Boolean
    Public ctrldown As Boolean
    'Dim ColPicker As New ColorPickerLib.gColorPicker
    Public totalselected As Integer = 0

    Public SelectedChannels As New List(Of Integer)

    '<System.Runtime.InteropService.DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> 

    'Public Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Long, lParam As Long) As Long

    'Private Declare Function SendMessage Lib "user32.dll" (ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Long, lParam As Long) As Long

    'Public Const WM_SETREDRAW As Integer = &HB

    Private Sub FormChannels_Load(sender As Object, e As EventArgs) Handles MyBase.Load
#Disable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
        If File.Exists(Application.StartupPath & "\WindowLocations.ini") Then

            FileOpen(7, Application.StartupPath & "\WindowLocations.ini", OpenMode.Input)
            Dim loc As New Point

            loc.X = LineInput(7)
            loc.Y = LineInput(7)
            Me.Location = loc


            Dim winstate As String = LineInput(7)
            Select Case winstate
                Case "Maximized"
                    Me.WindowState = WindowState.Maximized
                Case Else
                    Me.WindowState = WindowState.Normal

            End Select
            FileClose(7)
        Else
            Me.WindowState = WindowState.Normal
            Me.StartPosition = StartPosition.CenterScreen
        End If



        'ColPicker.Size = New Point(355, 154)
        'ColPicker.Visible = False
        'frmChannels.Controls.Add(ColPicker)

#Enable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
    End Sub

    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        'frmChannels.Hide()
        frmChannels.SendToBack()
    End Sub

    Private Sub ctxFixtureLabels_Opening(sender As Object, e As CancelEventArgs) Handles ctxFixtureLabels.Opening

        Dim parentChan As String = sender.SourceControl.Parent.iChannel

        'Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        'Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)

        'MessageBox.Show(cms.SourceControl.Name)
        LoadFixtureFavourites(parentChan)
    End Sub
    Public Function GetIndexOfNumber(ByVal str As String) As Integer

        For n As Integer = 0 To str.Length - 1

            If IsNumeric(str.Substring(n, 1)) Then

                Return n

            End If

        Next

        Return -1

    End Function
    Sub LoadFixtureFavourites(ByVal channel As Integer)

        Dim firstchan As Integer = channel - FixtureControls(channel).ChannelOfFixture + 1

        ctxFixtureFavourites.DropDownItems.Clear()
        Dim I As Integer = 0
        If Not FixtureControls(firstchan).Favourites Is Nothing Then

            Do Until I >= FixtureControls(firstchan).Favourites.Count
                If FixtureControls(firstchan).Favourites(I) Is Nothing Then Exit Do
                Dim newTT As New ToolStripMenuItem
                newTT.Text = FixtureControls(firstchan).Favourites(I)
                newTT.Name = firstchan
                newTT.Tag = firstchan
                ctxFixtureFavourites.DropDownItems.Add(newTT)
                AddHandler newTT.Click, AddressOf ctxFixtureFavouriteItem_Click
                I += 1

            Loop
        End If

    End Sub
    Private Sub ctxFixtureFavouriteItem_Click(sender As Object, e As EventArgs)
        Dim chno As Integer = sender.tag
        Dim Favname As String = sender.Text

        Dim iCurrentScene As Integer = ChannelFaderPageCurrentSceneDataIndex
        Dim wasselected As Boolean = SceneData(iCurrentScene).ChannelValues(chno).Selected
        SceneData(iCurrentScene).ChannelValues(chno).Selected = True
        'MessageBox.Show(chno & vbCrLf & Favname)
        Dim iSelected As Integer = 1

        'Dim iChannelControlNo As Integer = 0
        'Do Until iChannelControlNo >= ChannelFaders.Count

        '    iChannelControlNo += 1
        '    If ChannelFaders(iChannelControlNo).iChannel = iSelected Then
        'Loop

        Do Until iSelected >= SceneData(iCurrentScene).ChannelValues.Count
            If SceneData(iCurrentScene).ChannelValues(iSelected).Selected = True Then
                Dim iSelectedParent As Integer = FixtureControls(iSelected).ParentChannelNo
                If File.Exists(Application.StartupPath & "\Fixtures\" & FixtureControls(iSelectedParent).FixtureName & "\" & Favname & ".dmr") Then
                    FileOpen(1, Application.StartupPath & "\Fixtures\" & FixtureControls(iSelectedParent).FixtureName & "\" & Favname & ".dmr", OpenMode.Input)
                    Do Until EOF(1)
                        Dim a() As String = Split(LineInput(1), "|")
                        Dim I As Integer = 0
                        Do Until I >= a.Length
                            Dim b() As String = Split(a(I), ",")
                            Select Case b(0)

                                Case "v"
                                    SceneData(iCurrentScene).ChannelValues(iSelectedParent - 1 + a(0)).Value = b(1)
                                    ChannelFaders(iSelectedParent - numChannelFadersStart.Value + a(0)).dmrvs.Value = b(1)

                                Case "TimerEnabled", "timerenabled"
                                    SceneData(iCurrentScene).ChannelValues(iSelectedParent - 1 + a(0)).Automation.tTimer.Enabled = Convert.ToBoolean(b(1))
                                Case "AutoTimeBetween"
                                    If b(1) = 0 Then
                                        SceneData(iCurrentScene).ChannelValues(iSelectedParent - 1 + a(0)).Automation.tTimer.Interval = 10
                                    Else
                                        SceneData(iCurrentScene).ChannelValues(iSelectedParent - 1 + a(0)).Automation.tTimer.Interval = b(1)
                                    End If

                                Case "RandomStart"
                                    SceneData(iCurrentScene).ChannelValues(iSelectedParent - 1 + a(0)).Automation.ProgressRandomTimed = Convert.ToBoolean(b(1))
                                Case "InOrder"
                                    SceneData(iCurrentScene).ChannelValues(iSelectedParent - 1 + a(0)).Automation.ProgressInOrder = Convert.ToBoolean(b(1))
                                Case "RandomSound"
                                    SceneData(iCurrentScene).ChannelValues(iSelectedParent - 1 + a(0)).Automation.ProgressSoundActivated = Convert.ToBoolean(b(1))
                                Case "IsLooped"
                                    SceneData(iCurrentScene).ChannelValues(iSelectedParent - 1 + a(0)).Automation.ProgressLoop = Convert.ToBoolean(b(1))
                                Case "ProgressList"
                                    If b.Length = 1 Then
                                        'nothing in progress list
                                    Else

                                        For Each iList As String In b
                                            If Not iList = "ProgressList" Then
                                                SceneData(iCurrentScene).ChannelValues(iSelectedParent - 1 + a(0)).Automation.ProgressList.Add(Val(iList))
                                            End If
                                        Next
                                    End If
                            End Select

                            I += 1
                        Loop

                    Loop
                    FileClose(1)
                End If
            End If
                iSelected += 1
        Loop
        SceneData(iCurrentScene).ChannelValues(chno).Selected = wasselected
    End Sub

    Private Sub ctxPickRGBColourTool_Click(sender As Object, e As EventArgs) Handles ctxPickRGBColourTool.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)
        Dim iCurrentScene As Integer = ChannelFaderPageCurrentSceneDataIndex
        'Do Until iCurrentScene >= SceneData.Length
        '    If cmbChannelPresetSelection.SelectedItem = SceneData(iCurrentScene).SceneName Then Exit Do
        '    iCurrentScene += 1
        'Loop

        Dim ChControl As ctrlDimmerChannel = cms.SourceControl.Parent 'Mid(cms.SourceControl.Tag, GetIndexOfNumber(cms.SourceControl.Tag) + 1) 'Val(cms.SourceControl.Tag)
        Dim ChNo As Integer = ChControl.iChannel
        Dim firstchan As Integer = ChNo - FixtureControls(ChNo).ChannelOfFixture + 1

        Dim iR As Integer = SceneData(iCurrentScene).ChannelValues(firstchan - 1 + IndexOfChannelInFixture(firstchan, "Red")).Value
        Dim iG As Integer = SceneData(iCurrentScene).ChannelValues(firstchan - 1 + IndexOfChannelInFixture(firstchan, "Grn")).Value
        Dim iB As Integer = SceneData(iCurrentScene).ChannelValues(firstchan - 1 + IndexOfChannelInFixture(firstchan, "Blue")).Value
        'ColPicker.Value = Color.FromArgb(iR, iG, iB)


        'ColPicker.Location = New Point(ChannelFaders(firstchan).cFixtureDescr.Location.X, ChannelFaders(firstchan).cFixtureDescr.Location.Y + ChannelFaders(firstchan).cFixtureDescr.Size.Height)
        'ColPicker.Visible = True

        'frmCustomColourPicker.iRChan = firstchan - 1 + IndexOfChannelInFixture(firstchan, "Red")
        'frmCustomColourPicker.iGChan = firstchan - 1 + IndexOfChannelInFixture(firstchan, "Grn")
        'frmCustomColourPicker.iBChan = firstchan - 1 + IndexOfChannelInFixture(firstchan, "Blue")
        FixtureControls(firstchan).fColPicker.ColorPicker2.Value = Color.FromArgb(iR, iG, iB)
        Dim p As Point = Cursor.Position
        'p.Offset(-Form2.Width \ 2, -Form2.Height \ 2)
        FixtureControls(firstchan).fColPicker.Location = p

        'SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(I).Selected = True
        Dim I As Integer = 1
        Do Until I >= SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues.Count
            If SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(I).Selected = True Then
                Dim parfirstchan As Integer = I - FixtureControls(I).ChannelOfFixture + 1
                FixtureControls(firstchan).fColPicker.iRChanSel.Add(parfirstchan - 1 + IndexOfChannelInFixture(parfirstchan, "Red"))
                FixtureControls(firstchan).fColPicker.iGChanSel.Add(parfirstchan - 1 + IndexOfChannelInFixture(parfirstchan, "Grn"))
                FixtureControls(firstchan).fColPicker.iBChanSel.Add(parfirstchan - 1 + IndexOfChannelInFixture(parfirstchan, "Blue"))
            End If
            I += 1
        Loop


        FixtureControls(firstchan).fColPicker.Show()
        'frmCustomColourPicker.ColorPicker2.Value.Name

    End Sub
    Function IndexOfChannelInFixture(ByVal FirstChan As Integer, ByVal descr As String) As Integer
        Dim I As Integer = FirstChan
        Do Until I >= FixtureControls.Length
            If Mid(FixtureControls(I).ActionAndValues, 1, InStr(FixtureControls(I).ActionAndValues, ",")) = descr & "," Then
                Exit Do
            End If
            I += 1
        Loop
        Return FixtureControls(I).ChannelOfFixture

    End Function

    Private Sub ctxFixtureLabelsControlName_Click(sender As Object, e As EventArgs) Handles ctxFixtureLabelsControlName.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)

        MessageBox.Show(cms.SourceControl.Name)
    End Sub
    'Public Sub SavePreset(ByVal filename As String)
    '    If PagingChanged = True Then Exit Sub
    '    If BankChanged = True Then Exit Sub

    '    Dim I1 As Integer = 1
    '    Dim SaveFileName As String = ""
    '    Do Until I1 >= SceneData.Length
    '        Dim a() As String = Split(filename, "| ")
    '        If a.Length > 1 Then
    '            If SceneData(I1).SceneName = a(1) Then
    '                SaveFileName = a(1)
    '                Exit Do
    '            End If
    '        ElseIf a.Length = 1 Then
    '            If SceneData(I1).SceneName = a(0) Then
    '                SaveFileName = a(0)
    '                Exit Do
    '            End If
    '        End If

    '        I1 += 1
    '    Loop
    '    If SceneData(I1).SceneName = "" Then Exit Sub

    '    FileOpen(1, Application.StartupPath & "\Save Files\" & frmMain.lstBanks.SelectedItem & "\" & SaveFileName & ".dmr", OpenMode.Output)
    '    PrintLine(1, "P|" & "0")
    '    PrintLine(1, "ChangeMS|" & SceneData(I1).Automation.TimeBetweenMinAndMax)  '(PresetIndex(cmbPresets.SelectedItem)).Automation.numChangeMS.Value)
    '    Dim I As Integer = 1
    '    Do Until I > frmMain.numEndChannel.Value '1|v,0|tmr,100|timerenabled,false
    '        Dim chanline As String = I & "|"
    '        With SceneData(I1).ChannelValues(I)
    '            chanline &= "v," & .Value & "|"
    '            'chanline &= "tmr," & .Automation.tTimer.Interval & "|"
    '            chanline &= "TimerEnabled," & .Automation.tTimer.Enabled & "|"
    '            chanline &= "AutoTimeBetween," & .Automation.tTimer.Interval & "|"
    '            chanline &= "RandomStart," & .Automation.ProgressRandomTimed & "|"

    '            chanline &= "InOrder," & .Automation.ProgressInOrder & "|"
    '            chanline &= "RandomSound," & .Automation.ProgressSoundActivated & "|"
    '            chanline &= "IsLooped," & .Automation.ProgressLoop & "|"
    '            chanline &= "ProgressList"

    '            Dim iList As Integer = 0
    '            If Not .Automation.ProgressList Is Nothing Then
    '                Do Until iList >= .Automation.ProgressList.Count
    '                    chanline &= "," & .Automation.ProgressList(iList)
    '                    iList += 1
    '                Loop
    '            End If
    '        End With
    '        PrintLine(1, chanline)
    '        I += 1
    '    Loop
    '    FileClose(1)

    'End Sub

    Private Sub ctxNameofbutton_Click(sender As Object, e As EventArgs) Handles ctxNameofbutton.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)

        MessageBox.Show(cms.SourceControl.Name)
    End Sub

    Private Sub ctxDimmerAutomation_Click(sender As Object, e As EventArgs) Handles ctxDimmerAutomation.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)
        'frmDimmerAutomation = New FormDimmerAutomation
        Dim NextAvail As Integer = 0
        Do Until frmDimmerAutomation(NextAvail).Visible = False
            NextAvail += 1
        Loop
        frmDimmerAutomation(NextAvail).InstanceNo = NextAvail
        frmDimmerAutomation(NextAvail).Location = Windows.Forms.Cursor.Position
        frmDimmerAutomation(NextAvail).isLoaded = False

        Dim I As Integer = 1
        Do Until I >= SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues.Count
            If SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(I).Selected = True Then
                frmDimmerAutomation(NextAvail).iChanSel.Add(I)
            End If
            I += 1
        Loop

        frmDimmerAutomation(NextAvail).Generate()
        frmDimmerAutomation(NextAvail).Show()
        frmDimmerAutomation(NextAvail).isLoaded = True







        Exit Sub


        'Dim ChNo As Integer = Mid(cms.SourceControl.Tag, GetIndexOfNumber(cms.SourceControl.Tag) + 1) 'Val(cms.SourceControl.Tag)
        'Dim firstchan As Integer = ChNo - FixtureControls(ChNo).ChannelOfFixture + 1

        'Dim iR As Integer = SceneData(iCurrentScene).ChannelValues(firstchan - 1 + IndexOfChannelInFixture(firstchan, "Red")).Value
        'Dim iG As Integer = SceneData(iCurrentScene).ChannelValues(firstchan - 1 + IndexOfChannelInFixture(firstchan, "Grn")).Value
        'Dim iB As Integer = SceneData(iCurrentScene).ChannelValues(firstchan - 1 + IndexOfChannelInFixture(firstchan, "Blue")).Value

        'FixtureControls(firstchan).fColPicker.ColorPicker2.Value = Color.FromArgb(iR, iG, iB)
        'Dim p As Point = Cursor.Position
        ''p.Offset(-Form2.Width \ 2, -Form2.Height \ 2)
        'FixtureControls(firstchan).fColPicker.Location = p

        ''SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(I).Selected = True
        'Dim I As Integer = 1
        'Do Until I >= SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues.Count
        '    If SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(I).Selected = True Then
        '        Dim parfirstchan As Integer = I - FixtureControls(I).ChannelOfFixture + 1
        '        FixtureControls(firstchan).fColPicker.iRChanSel.Add(parfirstchan - 1 + IndexOfChannelInFixture(parfirstchan, "Red"))
        '        FixtureControls(firstchan).fColPicker.iGChanSel.Add(parfirstchan - 1 + IndexOfChannelInFixture(parfirstchan, "Grn"))
        '        FixtureControls(firstchan).fColPicker.iBChanSel.Add(parfirstchan - 1 + IndexOfChannelInFixture(parfirstchan, "Blue"))
        '    End If
        '    I += 1
        'Loop


        'FixtureControls(firstchan).fColPicker.Show()

    End Sub


    Private Sub cmdChannelsSave_Click(sender As Object, e As EventArgs) Handles cmdChannelsSave.Click
        frmMain.SaveScene(cmbChannelPresetSelection.SelectedItem)
    End Sub

    Private Sub vsSelected_ValueChanged(sender As Object) Handles vsSelected.ValueChanged
        If otherChanged = True Then Exit Sub
        txtSelected.Text = vsSelected.Value
    End Sub

    Private Sub txtSelected_TextChanged(sender As Object, e As EventArgs) Handles txtSelected.TextChanged
        'If otherChanged = True Then otherChanged = False : Exit Sub
        If txtSelected.Text = "" Then Exit Sub
        If formopened = False Then Exit Sub
        'If BankChanged = True Then Exit Sub

        If Val(txtSelected.Text) > 255 Then txtSelected.Text = 255
        If Val(txtSelected.Text) < 0 Then txtSelected.Text = 0
        otherChanged = True
        vsSelected.Value = Val(txtSelected.Text)


        'Application.DoEvents()
        ' Dim SceneIndexI As Integer = GetSceneIndex(Split(cmbChannelPresetSelection.Text, "| ")(1))

        Dim I As Integer = 0
        'Do Until I >= SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues.Count

        Do Until I >= SelectedChannels.Count
            If SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(SelectedChannels(I)).Selected = True Then
                ' otherChanged = True
                SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(SelectedChannels(I)).Value = Val(txtSelected.Text)
                ' otherChanged = False
            End If


            If SelectedChannels(I) >= numChannelFadersStart.Value And SelectedChannels(I) < numChannelFadersStart.Value + ChannelControlSetsPerPage Then
                'ChannelFaders(I - (frmChannels.numChannelFadersStart.Value) + 1).dmrbtn.BackColor = Color.Red
                Dim chanI As Integer = SelectedChannels(I) Mod ChannelControlSetsPerPage
                If Not ChannelFaders(chanI) Is Nothing Then
                    If ChannelFaders(chanI).dmrbtn.BackColor = Color.Red Then
                        ' otherChanged = True
                        ChannelFaders(chanI).dmrvs.Value = Val(txtSelected.Text)
                        ChannelFaders(chanI).dmrtxtv.Text = Val(txtSelected.Text)
                        UpdateFixtureLabel(chanI)
                        ' otherChanged = False
                    End If
                End If

            End If

            I += 1
        Loop
        'I = 1
        'Do Until I >= ChannelFaders.Count
        '    If ChannelFaders(I).cSelected Is Nothing Then Exit Do
        '    If ChannelFaders(I).cSelected.BackColor = Color.Red Then
        '        ChannelFaders(I).cFader.Value = (255 / 100) * Val(txtSelected.Text)
        '    End If
        '    I += 1
        'Loop
        otherChanged = False

    End Sub
    Public Sub UpdateFixtureLabel(Optional ByVal channelno As Integer = 0)
        If Not channelno = 0 Then
            'Actionsandvalues= "Str1,0-79,Str2,80-160,Str3,161-255"
            Dim a() As String = Split(FixtureControls(channelno - 1 + numChannelFadersStart.Value).ActionAndValues, ",")
            If a.Length > 2 Then
                Dim ActionIndex As Integer = 1
                Do Until ActionIndex >= a.Length
                    Dim b() As String = Split(a(ActionIndex), "-")
                    If Val(ChannelFaders(channelno).dmrtxtv.Text) >= b(0) And Val(ChannelFaders(channelno).dmrtxtv.Text) <= b(1) Then
                        'found value
                        Exit Do
                    End If
                    ActionIndex += 2
                Loop

                'Val(ChannelFaders(channelno).cTxtVal.Text) >= ActionLow And Val(ChannelFaders(channelno).cTxtVal.Text) >= ActionHigh
                ChannelFaders(channelno).dmrlblFC.Text = a(ActionIndex - 1)

            End If
        Else

        End If
    End Sub
    Private Sub cmdReloadChannelLocations_Click(sender As Object, e As EventArgs) Handles cmdReloadChannelLocations.Click
        GenerateChannelFormControls()
    End Sub
    Public Sub GenerateChannelFormControls()
        FadersRenaming = True
        Dim StartX As Integer = 12
        Dim StartY As Integer = 24
        'Dim IntervalX As Integer = 35
        'Dim IntervalY As Integer = 289
        'Dim ChanXupto As Integer = StartX - IntervalX
        'Dim ChanYupto As Integer = StartY
        'Dim cFixtureDescrYDiff As Integer = 249
        'Dim vScrollXDiff As Integer = 0 '-3
        'Dim vScrollYDiff As Integer = 26
        'Dim sButtonXDiff As Integer = 0 '-3
        'Dim sButtonYDiff As Integer = 197
        'Dim vtxtBoxXDiff As Integer = 0 '-3
        'Dim vtxtBoxYDiff As Integer = 226

        Dim XUpTo As Integer = StartX
        Dim YUpTo As Integer = StartY


        Dim RunningRowNum As Integer = 1

        Dim I As Integer = 1
        frmChannels.SuspendLayout()
        'SendMessage(Parent.Handle, WM_SETREDRAW, False, 0)
        'SendMessage(Me.Handle, WM_SETREDRAW, CType(0, IntPtr), IntPtr.Zero)

        frmChannels.Enabled = False

        Do Until I >= ChannelFaders.Length
            If ChannelFaders(I) Is Nothing Then ChannelFaders(I) = New ctrlDimmerChannel
            ChannelFaders(I).iChannel = I

            If ToolTip1.GetToolTip(ChannelFaders(I).dmrlblFC).Count = 0 Then
                ToolTip1.SetToolTip(ChannelFaders(I).dmrlblFC, FixtureControls(I).LongDescr)
            End If
            With ChannelFaders(I).dmrlblFC 'Bottom Labels
                '.AutoSize = False
                '.Size = New Point(36, 16)
                .ContextMenuStrip = ctxFixtureLabels
                If Not FixtureControls(I).FixtureName = "" Then
                    .BackColor = FixtureControls(I).BackColour
                    .ForeColor = FixtureControls(I).ForeColour
                    Dim a() As String = Split(FixtureControls(I).ActionAndValues, ",")
                    .Text = a(0)
                    '.Tag = I
                    '.Name = "dmrlblFC" & I
                    .Visible = True
                Else
                    .ForeColor = Color.BlueViolet
                    .BackColor = Color.Black
                    .Text = I
                    '.Tag = I
                    '.Name = "dmrlblC" & I
                    .Visible = False
                End If
            End With

            With ChannelFaders(I).dmrlblTop ' Top Labels
                '.AutoSize = False
                '.Size = New Point(36, 16)
                If FixtureControls(I).IsFirst = True Then
                    .Text = FixtureControls(I).FixtureName
                    .AutoSize = True
                    .BringToFront()
                Else
                    .AutoSize = False
                    .Text = I
                End If
                .ForeColor = frmMain.lblChannelNumberColour.BackColor
            End With

            With ChannelFaders(I).dmrbtn
                '.Size = New Point(23, 23)
                '.Text = "S"
                .ContextMenuStrip = ctxCMDs
                '.Name = "dmrbtn" & I
                .BackColor = controlcolour
                '.Tag = I
            End With

            With ChannelFaders(I).dmrvs
                '.LargeChange = 1
                '.Orientation = GControlOrientation.Vertical
                .BackColor = frmMain.lblChannelBackColour.BackColor
                .FillColor = frmMain.lblChannelFillColour.BackColor
                .BulletColor = frmMain.lblChannelBulletColour.BackColor
                '.Maximum = 255
                '.Value = 0 '255
                '.Size = New System.Drawing.Size(23, 168)
                '.Name = "dmrvs" & I
                '.Tag = I
            End With

            With ChannelFaders(I).dmrtxtv
                '.Size = New Point(24, 20)
                '.BackColor = controlcolour
                .BackColor = Color.Black
                .ForeColor = frmMain.lblChannelNumberColour.BackColor
                .Text = "0"
                '.Name = "dmrtxtv" & I
                '.Tag = I
            End With

            'If ChannelFaders(I).cLongDescr Is Nothing Then ChannelFaders(I).cLongDescr = New ToolTip
            'With ChannelFaders(I).cLongDescr
            '    '.BackColor = controlcolour
            '    .BackColor = Color.Black
            '    .ForeColor = lblChannelNumberColour.BackColor
            '    .
            '    .Name = "dmrtxtv" & I
            '    .Tag = I
            'End With



            ChannelFaders(I).Location = New Point(StartX + XUpTo, StartY + YUpTo)
            If frmChannels.Controls.Contains(ChannelFaders(I)) = False Then frmChannels.Controls.Add(ChannelFaders(I))



            'If frmChannels.Controls.Contains(ChannelFaders(I).cSelected) = False Then frmChannels.Controls.Add(ChannelFaders(I).cSelected)
            'If frmChannels.Controls.Contains(ChannelFaders(I).cFixtureDescr) = False Then frmChannels.Controls.Add(ChannelFaders(I).cFixtureDescr)
            'If frmChannels.Controls.Contains(ChannelFaders(I).cTxtVal) = False Then frmChannels.Controls.Add(ChannelFaders(I).cTxtVal)
            'If frmChannels.Controls.Contains(ChannelFaders(I).cChannelLabel) = False Then frmChannels.Controls.Add(ChannelFaders(I).cChannelLabel)




            XUpTo += ChannelFaders(I).Size.Width

            If StartX + XUpTo + ChannelFaders(I).Size.Width + ChannelFaders(I).Size.Width > frmChannels.cmdSelectedFull.Location.X Then
                XUpTo = StartX
                YUpTo += ChannelFaders(I).Size.Height
                RunningRowNum += 1
            End If
            If StartY + YUpTo + ChannelFaders(I).Size.Height > frmChannels.Size.Height Then

                GoTo DoneGeneration
                Exit Do
            End If
            'If RunningRowNum > DimmerChannelRows Then
            '    GoTo DoneGeneration
            '    Exit Do
            'End If

            I += 1

        Loop

        numChannelFadersStart.Value = 1


DoneGeneration:

        cmdChannelFadersUp.Text = "+" & I
        cmdChannelFadersDown.Text = "-" & I
        ChannelControlSetsPerPage = I
        I += 1
        'Do Until I >= ChannelFaders.Length
        '    If frmChannels.Controls.Contains(ChannelFaders(I).cFader) = True Then frmChannels.Controls.Add(ChannelFaders(I).cFader)
        '    If frmChannels.Controls.Contains(ChannelFaders(I).cSelected) = True Then frmChannels.Controls.Remove(ChannelFaders(I).cSelected)
        '    If frmChannels.Controls.Contains(ChannelFaders(I).cFixtureDescr) = True Then frmChannels.Controls.Remove(ChannelFaders(I).cFixtureDescr)
        '    If frmChannels.Controls.Contains(ChannelFaders(I).cTxtVal) = True Then frmChannels.Controls.Remove(ChannelFaders(I).cTxtVal)
        '    If frmChannels.Controls.Contains(ChannelFaders(I).cChannelLabel) = True Then frmChannels.Controls.Remove(ChannelFaders(I).cChannelLabel)
        '    I += 1
        'Loop

        frmChannels.Enabled = True

        For Each c As System.Windows.Forms.Control In frmChannels.Controls
            AddHandler c.KeyDown, AddressOf Form1_KeyDown
            AddHandler c.KeyUp, AddressOf Form1_KeyUp


        Next c
        frmChannels.ResumeLayout()
        'SendMesssage(Me.hwnd, WM_SETREDRAW, True, 0)  ' re-enable drawing
        'SendMessage(Me.Handle, WM_SETREDRAW, True, 0)

        frmMain.StartupProcess("frmChannels.GenerateChannelFormControls")

        RebuildTextOnChannelLabels()

        frmMain.StartupProcess("frmChannels.RebuildTextOnChannelLabels")
        FadersRenaming = False

    End Sub


#Region "Start Channel Fader Controls"
    Public Sub cmdChannelFadersUp_Click(sender As Object, e As EventArgs) Handles cmdChannelFadersUp.Click
        If numChannelFadersStart.Value + Val(Mid(sender.text, 2)) > (frmMain.numEndChannel.Value + 8) Then
            ' numChannelFadersStart.Value = 254 - Val(Mid(sender.text, 2))
        Else
            numChannelFadersStart.Value += Val(Mid(sender.text, 2))
        End If

    End Sub
    Public Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If shiftdown = True Then
            shiftdown = False
            frmMain.lblUpDownTest.Text = "Shift Up"
        End If
        If ctrldown = True Then
            ctrldown = False
            frmMain.lblUpDownTest.Text = "Ctrl Up"
        End If

    End Sub
    Public Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Shift = True Then
            shiftdown = True
            'Label2.Text = "Shift Down"
        ElseIf e.Control = True Then
            ctrldown = True
            'Label2.Text = "Ctrl Down"
        ElseIf e.KeyCode = Keys.Escape Then
            totalselected = 0
            cmdUnselectAll_Click(sender, Nothing)
        End If
    End Sub


    Public Sub cmdUnselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ChannelFaders(I).cSelected
        Dim J As Integer = 1
        Do Until J >= ChannelFaders.Length
            If Not ChannelFaders(J) Is Nothing Then
                ChannelFaders(J).dmrbtn.BackColor = controlcolour
            End If
            J += 1
        Loop

        Dim SceneIndex As Integer = 1
        Do Until SceneData(SceneIndex).SceneName = cmbChannelPresetSelection.SelectedItem : SceneIndex += 1 : Loop
        Dim I As Integer = 1
        Do Until I >= SceneData(SceneIndex).ChannelValues.Length
            SceneData(SceneIndex).ChannelValues(I).Selected = False
            I += 1
        Loop
        SelectedChannels.Clear()
        totalselected = 0

    End Sub

    Private Sub cmdChannelFadersDown_Click(sender As Object, e As EventArgs) Handles cmdChannelFadersDown.Click
        If numChannelFadersStart.Value - Val(Mid(sender.text, 2)) < 1 Then
            numChannelFadersStart.Value = 1
        Else
            numChannelFadersStart.Value -= Val(Mid(sender.text, 2))
        End If

    End Sub
    Private Sub numChannelFadersStart_ValueChanged(sender As Object, e As EventArgs) Handles numChannelFadersStart.ValueChanged
        If formopened = False Then Exit Sub
        RebuildTextOnChannelLabels()
    End Sub

    Public Sub RebuildTextOnChannelLabels()
        'If formopened = False Then Exit Sub
        FadersRenaming = True
        Dim I As Integer = 1

        'Do Until I >= FixtureControls.Length
        '    If FixtureControls(I).IsFirst = True Then
        '        FixtureControls(I).fColPicker.Visible = False
        '        FixtureControls(I).fColPicker.iRChanSel.Clear()
        '        FixtureControls(I).fColPicker.iGChanSel.Clear()
        '        FixtureControls(I).fColPicker.iBChanSel.Clear()
        '        'FixtureControls(I).fColPicker.iRChan = -1
        '        'FixtureControls(I).fColPicker.iGChan = -1
        '        'FixtureControls(I).fColPicker.iBChan = -1
        '    End If

        '    I += 1
        'Loop
        I = 1


        Dim uptoChannel As Integer = numChannelFadersStart.Value
        Dim SceneIndex As Integer = ChannelFaderPageCurrentSceneDataIndex
        'Do Until SceneData(SceneIndex).SceneName = cmbChannelPresetSelection.SelectedItem : SceneIndex += 1 : Loop


        Do Until I > ChannelControlSetsPerPage
            '  If I > ChannelControlSetsPerPage Then Exit Sub
            ChannelFaders(I).iChannel = uptoChannel

            With ChannelFaders(I).dmrlblTop
                If FixtureControls(uptoChannel).IsFirst = True Then
                    .Text = FixtureControls(uptoChannel).FixtureName
                    .AutoSize = True
                    .BringToFront()
                Else
                    .Text = uptoChannel
                    .AutoSize = False
                End If

                '.Name = "dmrlblTop" & I
                '.Tag = uptoChannel
                .Visible = True
            End With

            With ChannelFaders(I).dmrbtn
                '.Name = "dmrlblbtn" & I
                '.Tag = uptoChannel
                .Visible = True
                If SceneData(SceneIndex).ChannelValues(uptoChannel).Selected = True Then
                    .BackColor = Color.Red
                Else
                    .BackColor = controlcolour
                End If
            End With

            With ChannelFaders(I).dmrvs
                '.Name = "dmrlblvs" & I
                '.Tag = uptoChannel
                .Visible = True
                .Value = SceneData(SceneIndex).ChannelValues(uptoChannel).Value
            End With

            With ChannelFaders(I).dmrtxtv
                '.Name = "dmrtxtv" & I
                '.Tag = uptoChannel
                .Visible = True
                .Text = SceneData(SceneIndex).ChannelValues(uptoChannel).Value
            End With

            With ChannelFaders(I).dmrlblFC

                If Not FixtureControls(uptoChannel).FixtureName = "" Then
                    .BackColor = FixtureControls(uptoChannel).BackColour
                    .ForeColor = FixtureControls(uptoChannel).ForeColour
                    Dim a() As String = Split(FixtureControls(uptoChannel).ActionAndValues, ",")
                    .Text = a(0)
                    '.Tag = uptoChannel
                    '.Name = "dmrlblFixtureChannel" & I
                    .Visible = True
                Else
                    .Text = uptoChannel
                    '.Tag = uptoChannel
                    '.Name = "dmrlblFixtureChannel" & I
                    .Visible = False
                End If



            End With

            UpdateFixtureLabel(I)
            ChannelFaders(I).internalChannelFaderNumber = uptoChannel

            If uptoChannel > frmMain.numEndChannel.Value Or uptoChannel >= ChannelFaders.Count Then
                ChannelFaders(I).Visible = False
                'ChannelFaders(I).cSelected.Visible = False
                'ChannelFaders(I).cFader.Visible = False
                'ChannelFaders(I).cTxtVal.Visible = False
                'ChannelFaders(I).cFixtureDescr.Visible = False
            End If

            uptoChannel += 1
            I += 1
        Loop
        FadersRenaming = False
    End Sub

    'Public Sub tmrTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If formopened = False Then Exit Sub
    '    Dim SceneIndex As Integer = Split(sender.tag, "|")(0)
    '    Dim ChannelIndex As Integer = Split(sender.tag, "|")(1)

    '    With SceneData(SceneIndex).ChannelValues(ChannelIndex)

    '        ' List In Order
    '        If .Automation.ProgressInOrder = True Then
    '            If .Automation.CurrentIofList >= .Automation.ProgressList.Count - 1 Then
    '                .Automation.CurrentIofList = 0
    '                If .Automation.ProgressLoop = False Then
    '                    .Automation.tTimer.Stop()
    '                End If
    '            Else
    '                .Automation.CurrentIofList += 1
    '                .Value = .Automation.ProgressList(.Automation.CurrentIofList)
    '            End If
    '        End If

    '        ' List Timed Random
    '        If .Automation.ProgressRandomTimed = True Then
    '            .Automation.CurrentIofList = GetRandom(0, .Automation.ProgressList.Count)
    '            .Value = .Automation.ProgressList(.Automation.CurrentIofList)
    '        End If

    '        ' List Sound Random
    '        If .Automation.ProgressSoundActivated = True Then
    '            .Automation.CurrentIofList = GetRandom(0, .Automation.ProgressList.Count)
    '            .Value = .Automation.ProgressList(.Automation.CurrentIofList)
    '        End If


    '        ' After .Value is changed update controls
    '        If frmChannels.cmbChannelPresetSelection.SelectedIndex = SceneIndex - 1 Then ' And tbcControls1.SelectedTab Is tbpChannels Then
    '            UpdateFixtureLabel(ChannelIndex)

    '            Dim I As Integer = 1
    '            Do Until I >= ChannelFaders.Count
    '                If Not ChannelFaders(I).cFader Is Nothing Then
    '                    If ChannelFaders(I).cFader.Tag = ChannelIndex Then
    '                        ChannelFaders(I).cFader.Value = .Value
    '                        Exit Do
    '                    End If
    '                    If ChannelIndex < Val(ChannelFaders(I).cFader.Tag) Then Exit Do
    '                End If

    '                I += 1
    '            Loop

    '        End If



    '        'If .Automation.tmrDirection = "Down" Then
    '        '    If (.Value - .Automation.IntervalSteps) <= .Automation.Min Then
    '        '        .Value = .Automation.Min
    '        '        .Automation.tmrDirection = "Up"
    '        '        'ElseIf (.Value - .Automation.IntervalSteps) = .Automation.Min Then
    '        '        '    .Automation.tmrDirection = "Up"
    '        '        '    .Value += .Automation.IntervalSteps
    '        '    Else
    '        '        .Value -= .Automation.IntervalSteps
    '        '    End If
    '        'ElseIf .Automation.tmrDirection = "Up" Then
    '        '    If (.Value + .Automation.IntervalSteps) >= .Automation.Max Then
    '        '        .Value = .Automation.Max
    '        '        .Automation.tmrDirection = "Down"
    '        '        'ElseIf (.Value + .Automation.IntervalSteps) = .Automation.Max Then
    '        '        '    .Automation.tmrDirection = "Down"
    '        '        '    .Value -= .Automation.IntervalSteps
    '        '    Else
    '        '        .Value += .Automation.IntervalSteps
    '        '    End If
    '        'Else ' Doesn't have a direction
    '        '    Dim I As Integer = GetRandom(1, 2)
    '        '    If I = 1 Then
    '        '        .Automation.tmrDirection = "Down"
    '        '    Else
    '        '        .Automation.tmrDirection = "Up"
    '        '    End If
    '        'End If


    '        'If I > PresetFaderControlModifier And I <= (PresetFaderControlModifier + PresetFadersTotal) Then
    '        '    PresetFaders(I - PresetFaderControlModifier).cTxtVal.Text = SceneData(I).MasterValue
    '        'End If

    '    End With


    'End Sub
#End Region
    Private Sub cmbChannelPresetSelection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbChannelPresetSelection.SelectedIndexChanged
        If formopened = False Then Exit Sub
        ChannelFaderPageCurrentSceneDataIndex = frmMain.GetSceneIndex(cmbChannelPresetSelection.Text)
        frmChannels.RebuildTextOnChannelLabels()
    End Sub

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
        'Return CInt(Math.Ceiling(Rnd() * Max))
    End Function

    Private Sub cmdBack_Click(sender As Object, e As EventArgs) Handles cmdBack.Click
        Me.SendToBack()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox(Me.Location.ToString)
    End Sub

    Private Sub cmdSelectedFull_Click(sender As Object, e As EventArgs) Handles cmdSelectedFull.Click
        txtSelected.Text = 255
        txtSelected_TextChanged(Nothing, Nothing)
    End Sub

    Private Sub cmdSelectedBlackout_Click(sender As Object, e As EventArgs) Handles cmdSelectedBlackout.Click
        txtSelected.Text = 0
        txtSelected_TextChanged(Nothing, Nothing)
    End Sub
End Class
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
Public Class FormScenes
    Private Sub FormScenes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        frmScenes.Hide()
    End Sub
#Region "Scene Fader Controls"
    Private Sub cPresetFader_Scroll(ByVal Sender As System.Object) ' Handles GScrollBar1.ValueChanged 'ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If PagingChanged = True Then Exit Sub
        'Dim chno As Integer = 1
        'Do Until PresetFaders(chno).cFader.Name = Sender.Name : chno += 1 : Loop

        'If Not PresetFaders(chno).cTxtVal.Text = Sender.value Then
        '    PresetFaders(chno).cTxtVal.Text = Sender.value
        '    SceneData(Val(Sender.tag)).MasterValue = Sender.value
        '    '  ListBox2.Items.Add(chno)
        'End If

    End Sub
    Private Sub cAutoTime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) ' Handles TextBox1.TextChanged
        If formopened = False Then Exit Sub
        Dim chno As Integer = 1
        Do Until PresetFaders(chno).cAutoTime.Name = sender.Name : chno += 1 : Loop

        'If Not PresetFaders(chno).cFader.Value = Val(sender.text) Then
        SceneData(Val(sender.tag)).Automation.TimeBetweenMinAndMax = Val(sender.value)
        frmChannels.SavePreset(SceneData(Val(sender.tag)).SceneName)
        'End If
    End Sub
    Private Sub cPresetTxtVal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) ' Handles TextBox1.TextChanged
        'If otherChanged = True Then otherChanged = False : Exit Sub
        Dim chno As Integer = 1
        Do Until PresetFaders(chno).cTxtVal.Name = sender.Name : chno += 1 : Loop
        If Val(sender.text) > 100 Then sender.text = 100

        'If Not PresetFaders(chno).cFader.Value = Val(sender.text) Then
        'PresetFaders(chno).cFader.Value = Val(sender.text)
        SceneData(Val(sender.tag)).MasterValue = Val(sender.text)
        'End If
    End Sub
    Public Sub cPresetFull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If formopened = False Then Exit Sub
        Dim I As Integer = Val(sender.tag)
        'SceneData(I).cmdTouchbutton.BackColor = Color.Red
        'SceneData(I).Automation.numChangeMS = PresetFaders(I - PresetModifier).cAutoTime.Value

        If SceneData(I).Automation.TimeBetweenMinAndMax = 0 Then 'numPresetChangeMS.Value = 0 Then
            SceneData(I).MasterValue = 100
            UpdatePresetControls(100, I)
        Else
            With SceneData(I)
                .Automation.tmrDirection = "Up"
                '.Automation.tmrUpto = 
                .Automation.IntervalSteps = SceneData(I).Automation.Max / (.Automation.TimeBetweenMinAndMax / .Automation.tTimer.Interval)

                .Automation.tTimer.Start()
            End With
        End If
    End Sub

    Public Sub cPresetBlackout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If formopened = False Then Exit Sub
        Dim I As Integer = Val(sender.tag)
        'SceneData(I).cmdTouchbutton.BackColor = controlcolour
        SceneData(I).Automation.TimeBetweenMinAndMax = PresetFaders(I).cAutoTime.Value
        If SceneData(I).Automation.TimeBetweenMinAndMax = 0 Then
            'PresetControls(I).vtxtBox.Text = "100"
            SceneData(I).MasterValue = 0
            UpdatePresetControls(0, I)
        Else
            With SceneData(I)
                .Automation.tmrDirection = "Down"
                '.Automation.tmrUpto = .vtxtBox.Text
                .Automation.IntervalSteps = SceneData(I).Automation.Max / (.Automation.TimeBetweenMinAndMax / .Automation.tTimer.Interval)
                .Automation.tTimer.Start()
            End With
        End If
    End Sub
    Public Sub tmrPreset_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If formopened = False Then Exit Sub
        Dim I As Integer = Val(sender.tag)
        If SceneData(I).Automation.tmrDirection = "Down" Then
            If (SceneData(I).MasterValue - SceneData(I).Automation.IntervalSteps) <= 0 Then
                SceneData(I).Automation.tTimer.Stop()
                SceneData(I).Automation.tmrDirection = "lol"
                SceneData(I).MasterValue = 0
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
        UpdatePresetControls(SceneData(I).MasterValue, I)
        'PresetFaders(I).cFader.Value = SceneData(I).MasterValue
        If I > PresetFaderControlModifier And I <= (PresetFaderControlModifier + PresetFadersTotal) Then
            PresetFaders(I - PresetFaderControlModifier).cTxtVal.Text = SceneData(I).MasterValue
        End If

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

        frmChannels.cmbChannelPresetSelection.SelectedItem = cms.SourceControl.Text
        ChannelFaderPageCurrentSceneDataIndex = GetSceneIndex(Split(frmChannels.cmbChannelPresetSelection.Text, "| ")(1))
        For Each f As Form In frmContainer.MdiChildren
            If TypeOf f Is FormChannels Then
                f.Activate()
                Exit Sub
            End If
        Next
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

    Private Sub ctxPresetLabelName_Click(sender As Object, e As EventArgs) Handles ctxPresetLabelName.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)

        MessageBox.Show("Name: " & cms.SourceControl.Name & vbCrLf & "Tag: " & cms.SourceControl.Tag)
    End Sub
    Private Sub ctxPresetRenameScene_Click(sender As Object, e As EventArgs) Handles ctxPresetRenameScene.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)
        Dim oldprefix As String = ""
        Dim oldname As String = ""
        Dim I As Integer = 1
        Do Until I >= PresetFaders.Count
            If PresetFaders(I).cPresetName.Text = cms.SourceControl.Text Then
                oldprefix = Split(cms.SourceControl.Text, " |")(0)
                oldname = Split(cms.SourceControl.Text, " |")(1)
                Exit Do
            End If
            I += 1
        Loop
        Dim newname As String = InputBox("Please Enter New Scene Name:", "Editing Scene #" & cms.SourceControl.Tag, SceneData(cms.SourceControl.Tag).SceneName)
        SceneData(cms.SourceControl.Tag).SceneName = newname
        PresetFaders(I).cPresetName.Text = oldprefix & " | " & newname
        frmChannels.cmbChannelPresetSelection.Items.Item(I - 1) = oldprefix & " | " & newname

    End Sub



    Public Sub cmdPresetsBlackoutAllTimer_Click(sender As Object, e As EventArgs) Handles cmdPresetsBlackoutAllTimer.Click
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
        frmQuickChanges.lstDramaPresets.ClearSelected()
    End Sub

    Public Sub cmdPresetsBlackoutAllInstant_Click(sender As Object, e As EventArgs) Handles cmdPresetsBlackoutAllInstant.Click
        If formopened = False Then Exit Sub
        Dim I As Integer = 1
        Do Until I >= SceneData.Length
            SceneData(I).MasterValue = 0
            SceneData(I).Automation.tmrDirection = "lol"
            If I < PresetFaders.Length Then
                If frmScenes.Controls.Contains(PresetFaders(I).cTxtVal) Then
                    PresetFaders(I).cTxtVal.Text = 0
                End If
            End If
            I += 1
        Loop
        frmQuickChanges.lstDramaPresets.ClearSelected()

    End Sub


#End Region

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

    Private Sub tmrMaster_Tick(sender As Object, e As EventArgs)
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

    Public Sub UpdatePresetControls(ByVal Value As Integer, ByVal SceneIndex As Integer)
        Dim I As Integer = 1
        Do Until I >= SceneData.Length
            If SceneData(SceneIndex).SceneName = "" Then
                I = SceneIndex
            End If
            If I < PresetFaders.Length Then
                If Not PresetFaders(I).cPresetName Is Nothing Then
                    If Split(PresetFaders(I).cPresetName.Text, "| ")(1) = SceneData(SceneIndex).SceneName Then

                        If frmContainer.ActiveMdiChild.Controls.Contains(PresetFaders(I).cTxtVal) Then
                            PresetFaders(I).cTxtVal.Text = Value
                            If Value = 0 Then
                                PresetFaders(I).cBlackout.BackColor = frmSettings.lblSceneBlackoutColour.BackColor
                                PresetFaders(I).cFull.BackColor = Color.Black
                            ElseIf Value = 100 Then
                                PresetFaders(I).cBlackout.BackColor = Color.Black
                                PresetFaders(I).cFull.BackColor = frmSettings.lblSceneUpColour.BackColor
                            Else

                                If SceneData(SceneIndex).Automation.tTimer.Enabled = True And SceneData(SceneIndex).Automation.tmrDirection = "Up" Then
                                    PresetFaders(I).cBlackout.BackColor = Color.Black
                                    PresetFaders(I).cFull.BackColor = ControlPaint.Light(frmSettings.lblSceneUpColour.BackColor)
                                ElseIf SceneData(SceneIndex).Automation.tTimer.Enabled = True And SceneData(SceneIndex).Automation.tmrDirection = "Down" Then
                                    PresetFaders(I).cBlackout.BackColor = ControlPaint.LightLight(frmSettings.lblSceneBlackoutColour.BackColor)
                                    PresetFaders(I).cFull.BackColor = frmSettings.lblSceneUpColour.BackColor

                                End If

                            End If
                            Exit Do
                        End If
                    End If
                Else
                    Exit Do
                End If
            End If
            I += 1
        Loop
    End Sub

    Private Sub cmdReloadPresetLocations_Click(sender As Object, e As EventArgs) Handles cmdReloadPresetLocations.Click
        GeneratePresetFormControls()
    End Sub
    Sub GeneratePresetFormControls()
        frmScenes.Controls.Clear()

        For Each c As Windows.Forms.Control In FormPresetsControls
            frmScenes.Controls.Add(c)
        Next

        ' lstDramaPresets.Items.Clear()
        'cmbChannelPresetSelection.Items.Clear()

        Dim StartX As Integer = 8
        Dim StartY As Integer = 8
        Dim IntervalX As Integer = 301 '546
        Dim IntervalY As Integer = 48
        'Dim vscrDiffX As Integer = 119
        'Dim vscrDiffY As Integer = 0
        Dim txtDiffX As Integer = 119 '364
        Dim txtDiffY As Integer = 0
        Dim numChangeMSDiffX As Integer = 119 '364
        Dim numChangeMSDiffY As Integer = 21
        Dim cmdBlackoutDiffX As Integer = 231 '170 '415
        Dim cmdBlackoutDiffY As Integer = 0 ' -1
        Dim cmdFullDiffX As Integer = 170 '415
        Dim cmdFullDiffY As Integer = 0 '21 - 1

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

            PresetFaders(I).cAutoTime = New Windows.Forms.NumericUpDown
            With PresetFaders(I).cAutoTime
                .Size = New Point(50, 23)
                .Name = "prsnumAutoTime" & (I + PresetModifier)
                .BackColor = Color.Black
                .ForeColor = frmSettings.lblSceneLabelColour.BackColor
                .Tag = I + PresetModifier
                .Maximum = 10000
                .Minimum = 0
                .Value = 2000
            End With

            PresetFaders(I).cBlackout = New Button
            With PresetFaders(I).cBlackout
                .Size = New Point(60, 42) '(60, 22)
                .Text = "Blackout"
                .Name = "prscmdBlackout" & (I + PresetModifier)
                '.BackColor = controlcolour
                .BackColor = frmSettings.lblSceneBlackoutColour.BackColor
                .ForeColor = frmSettings.lblSceneLabelColour.BackColor
                .FlatStyle = FlatStyle.Flat
                .Tag = I + PresetModifier
            End With

            PresetFaders(I).cFull = New Button
            With PresetFaders(I).cFull
                .Size = New Point(60, 42) '(60, 22)
                .Text = "Full"
                .Name = "prscmdFull" & (I + PresetModifier)
                '.BackColor = controlcolour
                .BackColor = Color.Black
                .ForeColor = frmSettings.lblSceneLabelColour.BackColor
                .FlatStyle = FlatStyle.Flat
                .Tag = I + PresetModifier
            End With

            PresetFaders(I).cPresetName = New Label
            With PresetFaders(I).cPresetName
                .Size = New Point(113, 42)
                .Text = I & " | " & SceneData(I).SceneName
                .Name = "prslbl" & (I + PresetModifier)
                .BackColor = Color.Black
                .ForeColor = frmSettings.lblSceneLabelColour.BackColor
                .BorderStyle = BorderStyle.FixedSingle
                .Tag = I + PresetModifier
                .ContextMenuStrip = ctxPresetLabelActions
            End With

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
            '    .Tag = I + PresetModifier
            'End With

            PresetFaders(I).cTxtVal = New TextBox
            With PresetFaders(I).cTxtVal
                .Size = New Point(50, 23)
                .BackColor = Color.Black
                .ForeColor = frmSettings.lblSceneLabelColour.BackColor
                .Text = "0"
                .Name = "prsvtxt" & (I + PresetModifier)
                .Tag = I + PresetModifier
            End With




            PresetFaders(I).cPresetName.Location = New Point(StartX + XUpTo, StartY + YUpTo)
            'PresetFaders(I).cFader.Location = New Point(StartX + XUpTo + vscrDiffX, StartY + YUpTo + vscrDiffY)
            PresetFaders(I).cTxtVal.Location = New Point(StartX + XUpTo + txtDiffX, StartY + YUpTo + txtDiffY)
            PresetFaders(I).cAutoTime.Location = New Point(StartX + XUpTo + numChangeMSDiffX, StartY + YUpTo + numChangeMSDiffY)
            PresetFaders(I).cBlackout.Location = New Point(StartX + XUpTo + cmdBlackoutDiffX, StartY + YUpTo + cmdBlackoutDiffY)
            PresetFaders(I).cFull.Location = New Point(StartX + XUpTo + cmdFullDiffX, StartY + YUpTo + cmdFullDiffY)



            'AddHandler PresetFaders(I).cFader.ValueChanged, AddressOf cPresetFader_Scroll
            AddHandler PresetFaders(I).cTxtVal.TextChanged, AddressOf cPresetTxtVal_TextChanged
            AddHandler PresetFaders(I).cAutoTime.ValueChanged, AddressOf cAutoTime_ValueChanged
            AddHandler PresetFaders(I).cBlackout.Click, AddressOf cPresetBlackout_Click
            AddHandler PresetFaders(I).cFull.Click, AddressOf cPresetFull_Click


            frmScenes.Controls.Add(PresetFaders(I).cPresetName)
            'tbpPresets.Controls.Add(PresetFaders(I).cFader)
            frmScenes.Controls.Add(PresetFaders(I).cTxtVal)
            frmScenes.Controls.Add(PresetFaders(I).cAutoTime)
            frmScenes.Controls.Add(PresetFaders(I).cBlackout)
            frmScenes.Controls.Add(PresetFaders(I).cFull)




            YUpTo += IntervalY

            If StartY + YUpTo + PresetFaders(I).cPresetName.Size.Height >= lstPresetsSongs.Location.Y Then
                YUpTo = 0
                XUpTo += IntervalX
                RunningColumnNum += 1
            End If
            If StartX + XUpTo + cmdBlackoutDiffX + PresetFaders(I).cBlackout.Size.Width >= cmdPresetP1.Location.X Then
                GoTo DoneGeneration
                Exit Do
            End If




            I += 1
        Loop




DoneGeneration:

        PresetFadersTotal = I

    End Sub
    Public Sub RenamePresetFaderControls()
        PagingChanged = True
        Dim I As Integer = 1

        If frmScenes.cmdPresetP1.BackColor = Color.Red Then PresetFaderControlModifier = 0
        If frmScenes.cmdPresetP2.BackColor = Color.Red Then PresetFaderControlModifier = PresetFadersTotal
        If frmScenes.cmdPresetP3.BackColor = Color.Red Then PresetFaderControlModifier = PresetFadersTotal * 2
        If frmScenes.cmdPresetP4.BackColor = Color.Red Then PresetFaderControlModifier = PresetFadersTotal * 3
        If cmdPresetP5.BackColor = Color.Red Then PresetFaderControlModifier = PresetFadersTotal * 4
        If cmdPresetP6.BackColor = Color.Red Then PresetFaderControlModifier = PresetFadersTotal * 5

        Do Until I > PresetFadersTotal
            If Not I + PresetFaderControlModifier >= PresetFaders.Length Then

                PresetFaders(I).cAutoTime.Tag = I + PresetFaderControlModifier
                PresetFaders(I).cAutoTime.Name = "prsnumAutoTime" & (I + PresetFaderControlModifier)
                PresetFaders(I).cAutoTime.Value = SceneData(I + PresetFaderControlModifier).Automation.TimeBetweenMinAndMax

                PresetFaders(I).cBlackout.Tag = I + PresetFaderControlModifier
                PresetFaders(I).cBlackout.Name = "prscmdBlackout" & (I + PresetFaderControlModifier)

                PresetFaders(I).cFull.Tag = I + PresetFaderControlModifier
                PresetFaders(I).cFull.Name = "prscmdFull" & (I + PresetFaderControlModifier)

                PresetFaders(I).cPresetName.Tag = I + PresetFaderControlModifier
                PresetFaders(I).cPresetName.Name = "prslbl" & (I + PresetFaderControlModifier)
                PresetFaders(I).cPresetName.Text = (I + PresetFaderControlModifier) & " | " & SceneData(I + PresetFaderControlModifier).SceneName

                'PresetFaders(I).cFader.Tag = I + PresetFaderControlModifier
                'PresetFaders(I).cFader.Name = "prsvScroll" & (I + PresetFaderControlModifier)
                'PresetFaders(I).cFader.Value = SceneData(I + PresetFaderControlModifier).MasterValue

                PresetFaders(I).cTxtVal.Tag = I + PresetFaderControlModifier
                PresetFaders(I).cTxtVal.Name = "prsvtxt" & (I + PresetFaderControlModifier)
                PresetFaders(I).cTxtVal.Text = SceneData(I + PresetFaderControlModifier).MasterValue

            Else
                PresetFaders(I).cPresetName.Text = ""

            End If


            I += 1
            If I > PresetFaders.Length Then
                I = PresetFadersTotal + 5
            End If
        Loop
        PagingChanged = False
    End Sub

    Public Sub LoadScenesFromFile()

        frmQuickChanges.lstDramaPresets.Items.Clear()
        frmMusicEditor.lstSongEditPresets.Items.Clear()
        frmChannels.cmbChannelPresetSelection.Items.Clear()
        Dim I As Integer = 1
        Dim PresetsInBank() As String = Directory.GetFiles(Application.StartupPath & "\Save Files\" & frmBanks.lstBanks.SelectedItem & "\", "*.dmr")
        Do Until I >= SceneData.Length
            ReDim SceneData(I).ChannelValues(2048)
            ' SET DEFAULTS
            SceneData(I).Automation.tTimer = New Windows.Forms.Timer
            SceneData(I).Automation.tTimer.Interval = 100
            SceneData(I).Automation.tTimer.Tag = I
            AddHandler SceneData(I).Automation.tTimer.Tick, AddressOf frmScenes.tmrPreset_Tick

            'lstDramaPresets.Items.Add(SceneData(I).SceneName)
            'cmbChannelPresetSelection.Items.Add(I & " | " & SceneData(I).SceneName)


            If I <= PresetsInBank.Length Then    '---------- IS A SAVE FILE ----------------
                Dim a1() As String = Split(PresetsInBank(I - 1), "\")
                SceneData(I).SceneName = Mid(a1(a1.Length - 1), 1, a1(a1.Length - 1).Length - 4)
                frmQuickChanges.lstDramaPresets.Items.Add(SceneData(I).SceneName)
                frmMusicEditor.lstSongEditPresets.Items.Add(SceneData(I).SceneName)

                frmChannels.cmbChannelPresetSelection.Items.Add(I & " | " & SceneData(I).SceneName)

                SceneData(I).Automation.Max = 100 ' Set Default
                SceneData(I).Automation.Min = 0 ' Set Default
                SceneData(I).Automation.TimeBetweenMinAndMax = 0 ' Set Default

                FileOpen(1, Application.StartupPath & "\Save Files\" & frmBanks.lstBanks.SelectedItem & "\" & SceneData(I).SceneName & ".dmr", OpenMode.Input)
                Do Until EOF(1)
                    Dim a() As String = Split(LineInput(1), "|")
                    Select Case a(0)
                        Case "M"
                            a(0) = "P"
                        Case "P"
                            a(1) = 0 'sets preset starting value to 0 because whats the point of something going up on bank change?
                            SceneData(I).MasterValue = a(1)
                        Case "ChangeMS"
                            SceneData(I).Automation.TimeBetweenMinAndMax = a(1)
                        Case Is > 0
                            With SceneData(I).ChannelValues(a(0))
                                .Automation.tTimer = New Windows.Forms.Timer
                                .Automation.tTimer.Interval = 100 ' Set Default
                                .Automation.tTimer.Tag = I & "|" & a(0)
                                .Automation.ProgressInOrder = True
                                .Automation.ProgressLoop = True
                                .Automation.ProgressRandomTimed = False
                                .Automation.ProgressSoundActivated = False
                                .Automation.ProgressList = New List(Of Integer)

                                Dim tempTimerEnabled As Boolean = False
                                For Each s As String In a
                                    Dim b() As String = Split(s, ",")
                                    Select Case b(0) 'SceneData(I).ChannelValues(a(0))
                                        Case "v"
                                            .Value = b(1)
                                        Case "TimerEnabled", "timerenabled"
                                            tempTimerEnabled = Convert.ToBoolean(b(1))
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
                                .Automation.tTimer.Enabled = tempTimerEnabled
                                AddHandler .Automation.tTimer.Tick, AddressOf frmChannels.tmrTimer_Tick
                                '.Automation.IntervalSteps = (.Automation.Max - .Automation.Min) / (.Automation.TimeBetweenMinAndMax / 10)
                            End With

                    End Select


                Loop
                Dim I2 As Integer = 1
                Do Until I2 >= SceneData(I).ChannelValues.Length
                    If SceneData(I).ChannelValues(I2).Automation.tTimer Is Nothing Then
                        SceneData(I).ChannelValues(I2).Automation.tTimer = New Windows.Forms.Timer
                        SceneData(I).ChannelValues(I2).Automation.tTimer.Tag = I & "|" & I2
                        AddHandler SceneData(I).ChannelValues(I2).Automation.tTimer.Tick, AddressOf frmChannels.tmrTimer_Tick
                    End If
                    I2 += 1
                Loop
                FileClose(1)

            Else '---------- IS NO SAVE FILE ----------------

                SceneData(I).SceneName = ""
                'lstDramaPresets.Items.Add(SceneData(I).SceneName)
                frmChannels.cmbChannelPresetSelection.Items.Add(I & " | " & SceneData(I).SceneName)

                Dim I1 As Integer = 1

                SceneData(I).MasterValue = 0
                SceneData(I).Automation.TimeBetweenMinAndMax = 1000
                SceneData(I).Automation.Max = 100
                SceneData(I).Automation.Min = 0

                Do Until I1 >= ChannelFaders.Count

                    With SceneData(I).ChannelValues(I1)
                        .Automation.tTimer = New Windows.Forms.Timer
                        .Value = 0
                        .Automation.tTimer.Interval = 100
                        .Automation.tTimer.Enabled = False
                        .Automation.tTimer.Tag = I & "|" & I1
                        .Automation.ProgressInOrder = False
                        .Automation.ProgressLoop = False
                        .Automation.ProgressRandomTimed = False
                        .Automation.ProgressSoundActivated = False
                    End With
                    AddHandler SceneData(I).ChannelValues(I1).Automation.tTimer.Tick, AddressOf frmChannels.tmrTimer_Tick
                    I1 += 1
                Loop

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

    Private Sub cmdPresetsPlay_Click(sender As Object, e As EventArgs) Handles cmdPresetsPlay.Click
        frmMusicEditor.cmdPlay_Click(sender, e)
    End Sub

    Private Sub trkPresetsVolume2_Scroll(sender As Object, e As EventArgs) Handles trkPresetsVolume2.Scroll
        frmMusicEditor.trkVolume2_Scroll(sender, e)
    End Sub

    Private Sub cmdPresetsSkip2_Click(sender As Object, e As EventArgs) Handles cmdPresetsSkip2.Click
        frmMusicEditor.cmdSkip2_Click(sender, e)
    End Sub

    Private Sub cmdPresetsStop_Click(sender As Object, e As EventArgs) Handles cmdPresetsStop.Click
        frmMusicEditor.cmdStop_Click(sender, e)
    End Sub

    Private Sub cmdPresetsSkip_Click(sender As Object, e As EventArgs) Handles cmdPresetsSkip.Click
        frmMusicEditor.cmdSkip_Click(sender, e)
    End Sub

    Private Sub trkPresetsVolume_Scroll(sender As Object, e As EventArgs) Handles trkPresetsVolume.Scroll
        frmMusicEditor.trkVolume_Scroll(sender, e)
    End Sub

    Private Sub cmdPresetsPlay2_Click(sender As Object, e As EventArgs) Handles cmdPresetsPlay2.Click
        frmMusicEditor.cmdPlay2_Click(sender, e)
    End Sub

    Private Sub cmdPresetsStop2_Click(sender As Object, e As EventArgs) Handles cmdPresetsStop2.Click
        frmMusicEditor.cmdStop2_Click(sender, e)
    End Sub

    Private Sub lstPresetsSongs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPresetsSongs.SelectedIndexChanged
        frmMusicEditor.lstSongs_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub lstPresetsSongs2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPresetsSongs2.SelectedIndexChanged
        frmMusicEditor.lstSongs2_SelectedIndexChanged(sender, e)
    End Sub
End Class
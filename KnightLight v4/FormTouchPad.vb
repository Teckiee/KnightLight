Imports System.Threading
Public Class FormTouchPad
    Dim ControlColour As Color
    'Public SceneButtons(42) As Button

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click
        If formopened = False Then Exit Sub
        Dim I As Integer = Val(sender.tag)

        If sender.backcolor = ControlPaint.Light(frmMain.lblSceneBlackoutColour.BackColor) Or sender.backcolor = frmMain.lblSceneBlackoutColour.BackColor Then
            If SceneData(I).Automation.TimeBetweenMinAndMax = 0 Then 'numPresetChangeMS.Value = 0 Then
                SceneData(I).MasterValue = 100
                frmMain.UpdatePresetControls(I)
            Else
                With SceneData(I)
                    .Automation.tmrDirection = "Up"
                    '.Automation.tmrUpto = 
                    .Automation.IntervalSteps = SceneData(I).Automation.Max / (.Automation.TimeBetweenMinAndMax / .Automation.tTimer.Interval)

                    .Automation.tTimer.Start()
                End With
            End If
        Else

            SceneData(I).Automation.TimeBetweenMinAndMax = PresetFaders(I).cSceneControl.cAutoTime.Value
            If SceneData(I).Automation.TimeBetweenMinAndMax = 0 Then
                'PresetControls(I).vtxtBox.Text = "100"
                SceneData(I).MasterValue = 0
                frmMain.UpdatePresetControls(I)
            Else
                With SceneData(I)
                    .Automation.tmrDirection = "Down"
                    '.Automation.tmrUpto = .vtxtBox.Text
                    .Automation.IntervalSteps = SceneData(I).Automation.Max / (.Automation.TimeBetweenMinAndMax / .Automation.tTimer.Interval)
                    .Automation.tTimer.Start()
                End With
            End If
        End If

        'If sender.backcolor = ControlColour Then
        '    sender.BackColor = Color.Red

        '    Dim I As Integer = Val(sender.tag)
        '    'SceneData(I).cmdTouchbutton.BackColor = Color.Red
        '    'SceneData(I).Automation.numChangeMS = PresetFaders(I - PresetModifier).cAutoTime.Value

        '    If SceneData(I).Automation.TimeBetweenMinAndMax = 0 Then 'numPresetChangeMS.Value = 0 Then
        '        SceneData(I).MasterValue = 100
        '        frmMain.UpdatePresetControls(100, I)
        '    Else
        '        With SceneData(I)
        '            .Automation.tmrDirection = "Up"
        '            '.Automation.tmrUpto = 
        '            .Automation.IntervalSteps = SceneData(I).Automation.Max / (.Automation.TimeBetweenMinAndMax / .Automation.tTimer.Interval)

        '            .Automation.tTimer.Start()
        '        End With
        '    End If


        'Else
        '    sender.BackColor = Color.Blue

        '    Dim I As Integer = Val(sender.tag)
        '    'SceneData(I).cmdTouchbutton.BackColor = controlcolour
        '    SceneData(I).Automation.TimeBetweenMinAndMax = PresetFaders(I).cAutoTime.Value
        '    If SceneData(I).Automation.TimeBetweenMinAndMax = 0 Then
        '        'PresetControls(I).vtxtBox.Text = "100"
        '        SceneData(I).MasterValue = 0
        '        frmMain.UpdatePresetControls(0, I)
        '    Else
        '        With SceneData(I)
        '            .Automation.tmrDirection = "Down"
        '            '.Automation.tmrUpto = .vtxtBox.Text
        '            .Automation.IntervalSteps = SceneData(I).Automation.Max / (.Automation.TimeBetweenMinAndMax / .Automation.tTimer.Interval)
        '            .Automation.tTimer.Start()
        '        End With
        '    End If
        'End If
    End Sub

    Private Sub FormTouchPad_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        frmTouchPad.Hide()
    End Sub

    Private Sub FormTouchPad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ControlColour = Me.BackColor
        Me.BackColor = Color.Black

        frmTouchPad.Controls.Clear()
        frmTouchPad.Controls.Add(cmdMasterUp)
        frmTouchPad.Controls.Add(cmdPresetsBlackoutAllTimer)
        frmTouchPad.Controls.Add(cmdPresetsBlackoutAllInstant)

        Dim percolumn As Integer = 10

        Dim I As Integer = 1
        Do Until I >= SceneData.Length

            TouchButtons(I) = New Button
            With TouchButtons(I)
                .Size = New Point(146, 62)
                .Text = SceneData(I).SceneName
                .Name = "prscmdTouchbutton" & I
                .BackColor = ControlColour
                .ContextMenuStrip = frmTouchPad.ctxColourChange
                .Tag = I ' Scene Index
                If SceneData(I).SceneName = "" Then
                    .Visible = False
                Else
                    .Visible = True
                End If
            End With

            Dim rownumber As Integer = I Mod percolumn
            Dim columnnumber As Integer = Math.Floor(I / percolumn)

            'If I <= percolumn Then
            '    TouchButtons(I).Location = New Point(12, (68 * rownumber) + 8)
            'ElseIf I > percolumn Then
            TouchButtons(I).Location = New Point(12 + (152 * columnnumber), (68 * rownumber) + 8)  '(68 * (rownumber - 8)) + 8)
            'End If



            'If I <= 8 Then
            '    TouchButtons(I).Location = New Point(12, (68 * rownumber) + 8)
            'ElseIf I >= 9 And I <= 16 Then
            '    TouchButtons(I).Location = New Point(164, (68 * (rownumber - 8)) + 8)
            'ElseIf I >= 17 And I <= 24 Then
            '    TouchButtons(I).Location = New Point(316, (68 * (rownumber - 16)) + 8)
            'ElseIf I >= 25 And I <= 32 Then
            '    TouchButtons(I).Location = New Point(468, (68 * (rownumber - 24)) + 8)
            'ElseIf I >= 33 And I <= 40 Then
            '    TouchButtons(I).Location = New Point(620, (68 * (rownumber - 32)) + 8)
            'ElseIf I >= 41 And I <= 48 Then
            '    TouchButtons(I).Location = New Point(772, (68 * (rownumber - 40)) + 8)
            'End If
            frmTouchPad.Controls.Add(TouchButtons(I))
            AddHandler TouchButtons(I).Click, AddressOf Button1_Click

            I += 1
        Loop


        tTouchPadLoad = New Thread(AddressOf threadloop)
        tTouchPadLoad.Name = "tChannel"
        tTouchPadLoad.Start()

    End Sub

    Private Sub threadloop()
        Do


            Dim I As Integer = 1
            Do Until I >= SceneData.Length
                If Not SceneData(I).SceneName = "" Then

                    'If Value = 0 Then
                    '    PresetFaders(I).cBlackout.BackColor = lblSceneBlackoutColour.BackColor
                    '    PresetFaders(I).cFull.BackColor = Color.Black
                    'ElseIf Value = 100 Then
                    '    PresetFaders(I).cBlackout.BackColor = Color.Black
                    '    PresetFaders(I).cFull.BackColor = lblSceneUpColour.BackColor
                    'Else

                    '    If SceneData(I).Automation.tTimer.Enabled = True And SceneData(I).Automation.tmrDirection = "Up" Then
                    '        TouchButtons(I).BackColor = Color.Black
                    '        'PresetFaders(I).cFull.BackColor = ControlPaint.Light(lblSceneUpColour.BackColor)
                    '    ElseIf SceneData(I).Automation.tTimer.Enabled = True And SceneData(I).Automation.tmrDirection = "Down" Then
                    '        TouchButtons(I).BackColor = ControlPaint.LightLight(frmMain.lblSceneBlackoutColour.BackColor)
                    '        'PresetFaders(I).cFull.BackColor = lblSceneUpColour.BackColor
                    '    Else

                    '    End If
                    'End If

                    If SceneData(I).MasterValue > 0 And SceneData(I).Automation.tmrDirection = "Up" And SceneData(I).Automation.tTimer.Enabled = True Then ' is going up or is above 0
                        TouchButtons(I).BackColor = ControlPaint.Light(frmMain.lblSceneUpColour.BackColor)

                    ElseIf SceneData(I).MasterValue > 0 And SceneData(I).Automation.tmrDirection = "Down" And SceneData(I).Automation.tTimer.Enabled = True Then 'is going down
                        TouchButtons(I).BackColor = ControlPaint.LightLight(frmMain.lblSceneBlackoutColour.BackColor)

                    ElseIf SceneData(I).MasterValue > 0 And SceneData(I).Automation.tTimer.Enabled = False Then 'is stopped above 0
                        TouchButtons(I).BackColor = frmMain.lblSceneUpColour.BackColor

                    Else 'is 0
                        TouchButtons(I).BackColor = frmMain.lblSceneBlackoutColour.BackColor
                    End If
                    'TouchButtons(I).Visible = True
                Else
                    'TouchButtons(I).Visible = False
                End If

                I += 1
            Loop

            Thread.Sleep(10)
        Loop
    End Sub

    Private Sub cmdMasterUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMasterUp.Click
        If sender.backcolor = ControlColour Then
            sender.BackColor = Color.Red
            frmMain.cmdMasterFull.PerformClick()
        Else
            sender.BackColor = ControlColour
            frmMain.cmdMasterBlackout.PerformClick()
        End If
    End Sub

    Private Sub cmdPresetsBlackoutAllTimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPresetsBlackoutAllTimer.Click
        frmMain.cmdPresetsBlackoutAllTimer.PerformClick()
    End Sub

    Private Sub cmdPresetsBlackoutAllInstant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPresetsBlackoutAllInstant.Click
        frmMain.cmdPresetsBlackoutAllInstant.PerformClick()
    End Sub

    Private Sub BlueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlueToolStripMenuItem.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)

        'MessageBox.Show(cms.SourceControl.Name)
        For Each c As Control In frmTouchPad.Controls
            If c.Name = cms.SourceControl.Name Then
                c.BackColor = Color.Blue
                Exit For
            End If
        Next
    End Sub

    Private Sub GreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GreenToolStripMenuItem.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)

        'MessageBox.Show(cms.SourceControl.Name)
        For Each c As Control In frmTouchPad.Controls
            If c.Name = cms.SourceControl.Name Then
                c.BackColor = Color.Green
                Exit For
            End If
        Next
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim cms As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)

        'MessageBox.Show(cms.SourceControl.Name)
        For Each c As Control In frmTouchPad.Controls
            If c.Name = cms.SourceControl.Name Then
                c.BackColor = ControlColour
                Exit For
            End If
        Next
    End Sub
End Class
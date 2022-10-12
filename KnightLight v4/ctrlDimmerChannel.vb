Public Class ctrlDimmerChannel


    Public internalChannelFaderNumber As Integer
    Public iChannel As Integer

    Private Sub dmrvs_ValueChanged(sender As Object) Handles dmrvs.ValueChanged
        If formopened = False Then Exit Sub
        If otherChanged = True Then Exit Sub
        If FadersRenaming = True Then Exit Sub
        Dim SceneIndex As Integer = 1
        Do Until SceneData(SceneIndex).SceneName = frmChannels.cmbChannelPresetSelection.SelectedItem : SceneIndex += 1 : Loop
        Dim FaderNo As Integer = Val(sender.tag) - frmChannels.numChannelFadersStart.Value + 1
        Dim SceneChannelNo As Integer = Val(sender.tag)
        ' UpdateFixtureLabel(FaderNo)
        If Not ChannelFaders(FaderNo).dmrtxtv.Text = sender.value Then
            ChannelFaders(FaderNo).dmrtxtv.Text = sender.value
            SceneData(SceneIndex).ChannelValues(SceneChannelNo).Value = sender.value
            frmChannels.UpdateFixtureLabel(SceneChannelNo)
        End If
    End Sub

    Private Sub dmrbtn_Click(sender As Object, e As EventArgs) Handles dmrbtn.Click
        Dim SceneIndex As Integer = 1
        Do Until SceneData(SceneIndex).SceneName = frmChannels.cmbChannelPresetSelection.SelectedItem : SceneIndex += 1 : Loop
        Dim SceneChannelNo As Integer = Val(sender.tag)


        If sender.backcolor = Color.Red Then
            sender.backcolor = controlcolour
            frmChannels.totalselected -= 1
            SceneData(SceneIndex).ChannelValues(SceneChannelNo).Selected = False
            'GoTo ModsDown
        ElseIf sender.backcolor = controlcolour Then
            sender.backcolor = Color.Red
            frmChannels.totalselected += 1
            SceneData(SceneIndex).ChannelValues(SceneChannelNo).Selected = True
        End If



        'ModsDown:
        If frmChannels.shiftdown = True Then
            Dim FaderControlNo As Integer = 1
            Do Until Val(ChannelFaders(FaderControlNo).iChannel) = frmChannels.LastSelectedChannel
                FaderControlNo += 1
            Loop
            Dim I As Integer = frmChannels.LastSelectedChannel '                                  10         
            If SceneChannelNo > frmChannels.LastSelectedChannel Then '                            20 > 10    
                Do Until I > SceneChannelNo '                                         10 > 20    
                    ChannelFaders(FaderControlNo).dmrbtn.BackColor = Color.Red   ' Red 10     
                    SceneData(SceneIndex).ChannelValues(I).Selected = True   '        True 10    
                    frmChannels.totalselected += 1
                    FaderControlNo += 1
                    I += 1
                Loop
            End If
        End If

        'If ctrldown = True Then

        '    Dim I As Integer = LastSelectedChannel
        '    If SceneChannelNo > LastSelectedChannel Then
        '        Do Until I > SceneChannelNo
        '            ChannelFaders(I).cSelected.BackColor = Color.Red
        '            I += 1
        '        Loop
        '    End If
        'End If

        'Dim d() As String = Split(sender.tag, "|")

        frmChannels.LastSelectedChannel = SceneChannelNo
    End Sub

    Private Sub dmrtxtv_TextChanged(sender As Object, e As EventArgs) Handles dmrtxtv.TextChanged
        If formopened = False Then Exit Sub
        If otherChanged = True Then Exit Sub
        If FadersRenaming = True Then Exit Sub
        Dim SceneIndex As Integer = 1
        Do Until SceneData(SceneIndex).SceneName = frmChannels.cmbChannelPresetSelection.SelectedItem : SceneIndex += 1 : Loop
        Dim FaderNo As Integer = Val(sender.tag) - frmChannels.numChannelFadersStart.Value + 1
        Dim SceneChannelNo As Integer = Val(sender.tag)
        ' UpdateFixtureLabel(FaderNo)
        If Not ChannelFaders(FaderNo).dmrvs.Value = Val(sender.text) Then
            ChannelFaders(FaderNo).dmrvs.Value = Val(sender.text)
            SceneData(SceneIndex).ChannelValues(SceneChannelNo).Value = Val(sender.text)
            frmChannels.UpdateFixtureLabel(SceneChannelNo)
        End If
    End Sub


    Private Sub dmrlblFC_DoubleClick(sender As Object, e As EventArgs) Handles dmrlblFC.DoubleClick
        If Not frmChannels.ctrldown = True Then frmChannels.cmdUnselectAll_Click(sender, Nothing)

        Dim fixname As String = FixtureControls(Val(sender.tag)).FixtureName
        Dim fixchan As Integer = FixtureControls(Val(sender.tag)).ChannelOfFixture
        Dim fixIndex As Integer = Val(sender.tag)

        'Dim FaderControlNo As Integer = 1
        'Do Until ChannelFaders(FaderControlNo).cFixtureDescr.Name = sender.name : FaderControlNo += 1 : Loop

        Dim I As Integer = 1

        Do Until I >= FixtureControls.Length - 1
            If FixtureControls(I).FixtureName = fixname Then
                If FixtureControls(I).ChannelOfFixture = fixchan Then
                    'FixtureControls(I).sButton.BackColor = Color.Red
                    SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(I).Selected = True
                    ChannelFaders(I + (frmChannels.numChannelFadersStart.Value - 1)).dmrbtn.BackColor = Color.Red
                    frmChannels.totalselected += 1
                End If
            End If
            I += 1
        Loop
        frmChannels.LastSelectedChannel = fixIndex
    End Sub

End Class

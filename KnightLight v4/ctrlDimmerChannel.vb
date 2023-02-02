Public Class ctrlDimmerChannel


    Public internalChannelFaderNumber As Integer
    Public iChannel As Integer

    Private Sub dmrvs_ValueChanged(sender As Object) Handles dmrvs.ValueChanged
        If formopened = False Then Exit Sub
        If otherChanged = True Then Exit Sub
        If FadersRenaming = True Then Exit Sub
        Dim SceneIndex As Integer = 1
        Do Until SceneData(SceneIndex).SceneName = frmChannels.cmbChannelPresetSelection.SelectedItem : SceneIndex += 1 : Loop
        Dim FaderNo As Integer = internalChannelFaderNumber - frmChannels.numChannelFadersStart.Value + 1
        Dim SceneChannelNo As Integer = internalChannelFaderNumber
        ' UpdateFixtureLabel(FaderNo)
        If Not ChannelFaders(FaderNo).dmrtxtv.Text = sender.value Then
            ChannelFaders(FaderNo).dmrtxtv.Text = sender.value
            SceneData(SceneIndex).ChannelValues(SceneChannelNo).Value = sender.value
            frmChannels.UpdateFixtureLabel(SceneChannelNo)
        End If
    End Sub

    Public Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown, dmrlblFC.KeyDown, dmrbtn.KeyDown, dmrlblTop.KeyDown, dmrtxtv.KeyDown, dmrvs.KeyDown
        If e.Shift = True Then
            frmChannels.shiftdown = True
            'Label2.Text = "Shift Down"
        ElseIf e.Control = True Then
            frmChannels.ctrldown = True
            'Label2.Text = "Ctrl Down"
        ElseIf e.KeyCode = Keys.Escape Then
            frmChannels.totalselected = 0
            frmChannels.cmdUnselectAll_Click(sender, Nothing)
        End If
    End Sub
    Public Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, dmrlblFC.KeyUp, dmrbtn.KeyUp, dmrlblTop.KeyUp, dmrtxtv.KeyUp, dmrvs.KeyUp
        If frmChannels.shiftdown = True Then
            frmChannels.shiftdown = False
            frmMain.lblUpDownTest.Text = "Shift Up"
        End If
        If frmChannels.ctrldown = True Then
            frmChannels.ctrldown = False
            frmMain.lblUpDownTest.Text = "Ctrl Up"
        End If

    End Sub

    Private Sub dmrbtn_Click(sender As Object, e As EventArgs) Handles dmrbtn.Click
        Dim SceneIndex As Integer = 1
        Do Until SceneData(SceneIndex).SceneName = frmChannels.cmbChannelPresetSelection.SelectedItem : SceneIndex += 1 : Loop
        'Dim SceneChannelNo As Integer = internalChannelFaderNumber 'Val(sender.tag)


        If sender.backcolor = Color.Red Then
            sender.backcolor = controlcolour
            frmChannels.totalselected -= 1
            SceneData(SceneIndex).ChannelValues(internalChannelFaderNumber).Selected = False
            frmChannels.SelectedChannels.Remove(internalChannelFaderNumber)
            'GoTo ModsDown
        ElseIf sender.backcolor = controlcolour Then
            sender.backcolor = Color.Red
            frmChannels.totalselected += 1
            SceneData(SceneIndex).ChannelValues(internalChannelFaderNumber).Selected = True
            frmChannels.SelectedChannels.Add(internalChannelFaderNumber)
        End If



        'ModsDown:
        If frmChannels.shiftdown = True Then
            Dim FaderControlNo As Integer = 1
            Do Until Val(ChannelFaders(FaderControlNo).iChannel) = frmChannels.LastSelectedChannel
                FaderControlNo += 1
            Loop
            Dim I As Integer = frmChannels.LastSelectedChannel '                                  10         
            If internalChannelFaderNumber > frmChannels.LastSelectedChannel Then '                            20 > 10    
                Do Until I > internalChannelFaderNumber '                                         10 > 20    
                    ChannelFaders(FaderControlNo).dmrbtn.BackColor = Color.Red   ' Red 10     
                    SceneData(SceneIndex).ChannelValues(I).Selected = True   '        True 10    
                    frmChannels.SelectedChannels.Add(I)
                    frmChannels.totalselected += 1
                    FaderControlNo += 1
                    I += 1
                Loop
            End If
        End If


        frmChannels.LastSelectedChannel = internalChannelFaderNumber
    End Sub

    Private Sub dmrtxtv_TextChanged(sender As Object, e As EventArgs) Handles dmrtxtv.TextChanged
        If formopened = False Then Exit Sub
        If otherChanged = True Then Exit Sub
        If FadersRenaming = True Then Exit Sub
        Dim SceneIndex As Integer = 1
        Do Until SceneData(SceneIndex).SceneName = frmChannels.cmbChannelPresetSelection.SelectedItem : SceneIndex += 1 : Loop
        Dim FaderNo As Integer = internalChannelFaderNumber - frmChannels.numChannelFadersStart.Value + 1
        Dim SceneChannelNo As Integer = internalChannelFaderNumber
        ' UpdateFixtureLabel(FaderNo)
        If Not ChannelFaders(FaderNo).dmrvs.Value = Val(sender.text) Then
            ChannelFaders(FaderNo).dmrvs.Value = Val(sender.text)
            SceneData(SceneIndex).ChannelValues(SceneChannelNo).Value = Val(sender.text)
            frmChannels.UpdateFixtureLabel(SceneChannelNo)
        End If
    End Sub


    Private Sub dmrlblFC_DoubleClick(sender As Object, e As EventArgs) Handles dmrlblFC.DoubleClick
        If Not frmChannels.ctrldown = True Then frmChannels.cmdUnselectAll_Click(sender, Nothing)

        Dim fixname As String = FixtureControls(internalChannelFaderNumber).FixtureName
        Dim fixchan As Integer = FixtureControls(internalChannelFaderNumber).ChannelOfFixture
        'Dim fixIndex As Integer = internalChannelFaderNumber

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
        frmChannels.LastSelectedChannel = internalChannelFaderNumber
    End Sub

    Private Sub ctrlDimmerChannel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'For Each c As System.Windows.Forms.Control In frmChannels.Controls
        '    AddHandler c.KeyDown, AddressOf Form1_KeyDown
        '    AddHandler c.KeyUp, AddressOf Form1_KeyUp

        'Next c
    End Sub
End Class

Imports System.ComponentModel

Public Class FormDimmerAutomation
    'Public SceneIndex As Integer 
    'ChannelFaderPageCurrentSceneDataIndex
    Public isLoaded As Boolean = False

    Public iChanSel As New List(Of Integer)
    Public InstanceNo As Integer = -1

    Private Sub FormDimmerAutomation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblAutoMaxlbl.ForeColor = frmMain.lblChannelNumberColour.BackColor
        lblAutoMinlbl.ForeColor = frmMain.lblChannelNumberColour.BackColor
        chkChaseStartRandom.ForeColor = frmMain.lblChannelNumberColour.BackColor
        cmdChaseRemove.ForeColor = frmMain.lblChannelNumberColour.BackColor
        lblEditingChannels.ForeColor = frmMain.lblChannelNumberColour.BackColor

        GroupBox1.ForeColor = frmMain.lblChannelNumberColour.BackColor
        GroupBox2.ForeColor = frmMain.lblChannelNumberColour.BackColor
        GroupBox3.ForeColor = frmMain.lblChannelNumberColour.BackColor
        GroupBox4.ForeColor = frmMain.lblChannelNumberColour.BackColor
        CustomGroupBox1.ForeColor = frmMain.lblChannelNumberColour.BackColor

        Label1.ForeColor = frmMain.lblChannelNumberColour.BackColor
        Label2.ForeColor = frmMain.lblChannelNumberColour.BackColor
        Label3.ForeColor = frmMain.lblChannelNumberColour.BackColor

        optInOrder.ForeColor = frmMain.lblChannelNumberColour.BackColor
        optRandomTimed.ForeColor = frmMain.lblChannelNumberColour.BackColor
        optRandomSound.ForeColor = frmMain.lblChannelNumberColour.BackColor
        chkFadeLtoH.ForeColor = frmMain.lblChannelNumberColour.BackColor
        chkFadeHtoL.ForeColor = frmMain.lblChannelNumberColour.BackColor
        chkLoop.ForeColor = frmMain.lblChannelNumberColour.BackColor
        grpSoundActivation.ForeColor = frmMain.lblChannelNumberColour.BackColor
        grpOscillator.ForeColor = frmMain.lblChannelNumberColour.BackColor

        'For Each c As Control In GroupBox1.Controls
        '    c.ForeColor = frmMain.lblChannelNumberColour.BackColor
        '    c.BackColor = Color.Black
        'Next
        'For Each c As Control In GroupBox2.Controls
        '    c.ForeColor = frmMain.lblChannelNumberColour.BackColor
        '    c.BackColor = Color.Black
        'Next
        'For Each c As Control In GroupBox3.Controls
        '    c.ForeColor = frmMain.lblChannelNumberColour.BackColor
        '    c.BackColor = Color.Black
        'Next
        'For Each c As Control In GroupBox4.Controls
        '    c.ForeColor = frmMain.lblChannelNumberColour.BackColor
        '    c.BackColor = Color.Black
        'Next
        'For Each c As Control In CustomGroupBox1.Controls
        '    c.ForeColor = frmMain.lblChannelNumberColour.BackColor
        '    c.BackColor = Color.Black
        'Next
        For Each c As Object In grpSoundActivation.Controls
            c.ForeColor = frmMain.lblChannelNumberColour.BackColor
            c.BackColor = Color.Black
            If c.GetType.FullName = "KnobControl.KnobControl" Then
                c.ScaleColor = frmMain.lblChannelNumberColour.BackColor
            End If
        Next
        For Each c As Object In grpOscillator.Controls
            c.ForeColor = frmMain.lblChannelNumberColour.BackColor
            c.BackColor = Color.Black
            If c.GetType.FullName = "KnobControl.KnobControl" Then
                c.ScaleColor = frmMain.lblChannelNumberColour.BackColor
            End If
        Next

        lstChase.ForeColor = frmMain.lblChannelNumberColour.BackColor
        lstChase.BackColor = Color.Black

        'Generate()
    End Sub
    Public Sub GenerateAutomation()
        numChaseMax.Value = 255
        numChaseMin.Value = 0
        numChaseManyMax.Value = 255
        numChaseManyMin.Value = 0
        numChaseSingleValue.Value = 255
        numChaseManyIterations.Value = 10
        lblEditingChannels.Text = ""
        Dim I As Integer = 0
        Do Until I >= iChanSel.Count
            lblEditingChannels.Text &= ", " & iChanSel(I)
            optRandomTimed.Checked = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.ProgressRandomTimed
            optRandomSound.Checked = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.ProgressSoundActivated
            optInOrder.Checked = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.ProgressInOrder
            'numChaseTimebetween.Value = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.tTimer.Interval
            'chkAutoRunning.Checked = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.RunTimer

            knbAmplitude.Value = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.oscAmplitude
            knbCenter.Value = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.oscCenter
            knbFrequency.Value = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.oscFrequency / 0.01
            knbPhase.Value = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.oscPhase * 10

            knbSoundLevel.Value = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.SoundLevel
            knbSoundAttack.Value = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.SoundAttack
            knbSoundRelease.Value = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.SoundRelease

            Select Case SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.Mode
                Case AutomationMode.Off
                    lstWave.SelectedItem = "Off"
                Case AutomationMode.Chase
                    lstWave.SelectedItem = "Chase"
                Case AutomationMode.Sine
                    lstWave.SelectedItem = "Sine"
                Case AutomationMode.Square
                    lstWave.SelectedItem = "Square"
                Case AutomationMode.Triangle
                    lstWave.SelectedItem = "Triangle"
                Case AutomationMode.Opposite
                    lstWave.SelectedItem = "Opposite"
            End Select

            chkLoop.Checked = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.ProgressLoop
            lstChase.Items.Clear()
            Dim ite() As Integer = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.ProgressList.ToArray
            For Each i1 As Integer In ite
                lstChase.Items.Add(i1)
            Next

            I += 1
        Loop
        lblEditingChannels.Text = lblEditingChannels.Text.TrimStart(", ")

        'numChaseMax.Value = 255
        'numChaseMin.Value = 0
        'numChaseManyMax.Value = 255
        'numChaseManyMin.Value = 0
        'numChaseSingleValue.Value = 255
        'numChaseManyIterations.Value = 10
        'lblEditingChannels.Text = ""
        'Dim I As Integer = 0
        'Do Until I >= SelectedChannels.Count
        '    lblEditingChannels.Text &= ", " & SelectedChannels(I)
        '    optRandomTimed.Checked = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(SelectedChannels(I)).Automation.ProgressRandomTimed
        '    optRandomSound.Checked = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(SelectedChannels(I)).Automation.ProgressSoundActivated
        '    optInOrder.Checked = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(SelectedChannels(I)).Automation.ProgressInOrder
        '    numChaseTimebetween.Value = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(SelectedChannels(I)).Automation.Interval
        '    'chkAutoRunning.Checked = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(SelectedChannels(I)).Automation.RunTimer
        '    lstWave.SelectedItem = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(SelectedChannels(I)).Automation.Mode
        '    chkLoop.Checked = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(SelectedChannels(I)).Automation.ProgressLoop
        '    lstChase.Items.Clear()
        '    Dim ite() As Integer = SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(SelectedChannels(I)).Automation.ProgressList.ToArray
        '    For Each i1 As Integer In ite
        '        lstChase.Items.Add(i1)
        '    Next

        '    I += 1
        'Loop
        'lblEditingChannels.Text = lblEditingChannels.Text.TrimStart(", ")
    End Sub
    Private Sub chkAutoRunning_CheckedChanged(sender As Object, e As EventArgs)
        If formopened = False Then Exit Sub
        SaveToMain()

    End Sub
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
        'Return CInt(Math.Ceiling(Rnd() * Max))
    End Function

    Private Sub FormDimmerAutomation_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True

        iChanSel.Clear()
        Me.Hide()
        InstanceNo = -1
    End Sub

    Private Sub cmdChaseRemove_Click(sender As Object, e As EventArgs) Handles cmdChaseRemove.Click
        If lstChase.SelectedItems.Count = 0 Then Exit Sub

        For i As Integer = lstChase.SelectedItems.Count - 1 To 0 Step -1
            lstChase.Items.Remove(lstChase.SelectedItems(i))
        Next
        SaveToMain()
    End Sub

    Private Sub cmdChaseFadeAdd_Click(sender As Object, e As EventArgs) Handles cmdChaseFadeAdd.Click
        Dim I As Integer = 0
        Dim iVal As Integer = numChaseMin.Value
        Dim ChannelCountEachTime As Integer = 4
        Dim iTotal As Integer = ((numChaseMax.Value - numChaseMin.Value) * 2) / ChannelCountEachTime
        Dim sDir As String = "Up"
        If chkFadeHtoL.Checked = True Then
            iTotal = (numChaseMax.Value - numChaseMin.Value) / ChannelCountEachTime
            sDir = "Down"
            iVal = numChaseMax.Value
        ElseIf chkFadeLtoH.Checked = True Then
            iTotal = (numChaseMax.Value - numChaseMin.Value) / ChannelCountEachTime
            sDir = "Up"
        ElseIf chkChaseStartRandom.Checked = True Then
            iVal = GetRandom(numChaseMin.Value / 4, numChaseMax.Value / 4) * 4
            Dim rDir As Integer = GetRandom(1, 2)
            If rDir = 1 Then sDir = "Up"
            If rDir = 1 Then sDir = "Down"
        ElseIf chkFadeBothWays.Checked = True Then

        End If


        Do Until I > iTotal
            If iVal > 255 Then
                lstChase.Items.Add(255)
            ElseIf iVal < 0 Then
                lstChase.Items.Add(0)
            Else
                lstChase.Items.Add(iVal)
            End If

            If sDir = "Up" Then
                iVal += ChannelCountEachTime
                If iVal >= numChaseMax.Value Then
                    sDir = "Down"
                End If
            Else
                iVal -= ChannelCountEachTime
                If iVal <= numChaseMin.Value Then
                    sDir = "Up"
                End If
            End If
            I += 1

        Loop
        SaveToMain()
    End Sub

    Private Sub cmdChaseManySingleAdd_Click(sender As Object, e As EventArgs) Handles cmdChaseManySingleAdd.Click
        Dim I As Integer = 0
        Do Until I >= numChaseManyIterations.Value
            lstChase.Items.Add(GetRandom(numChaseManyMin.Value, numChaseManyMax.Value))
            I += 1
        Loop
        SaveToMain()
    End Sub

    Private Sub cmdChaseSingleAdd_Click(sender As Object, e As EventArgs) Handles cmdChaseSingleAdd.Click
        lstChase.Items.Add(numChaseSingleValue.Value)
        SaveToMain()
    End Sub
    Private Sub optInOrder_CheckedChanged(sender As Object, e As EventArgs) Handles optInOrder.CheckedChanged, optRandomTimed.CheckedChanged, optRandomSound.CheckedChanged
        SaveToMain()
    End Sub

    Private Sub chkLoop_CheckedChanged(sender As Object, e As EventArgs) Handles chkLoop.CheckedChanged
        SaveToMain()
    End Sub

    Private Sub numChaseTimebetween_ValueChanged(sender As Object, e As EventArgs) Handles numChaseTimebetween.ValueChanged
        SaveToMain()
    End Sub
    Private Sub SaveToMain()
        If formopened = False Then Exit Sub
        If isLoaded = False Then Exit Sub
        'numChaseMax.Value = 255
        'numChaseMin.Value = 0
        'numChaseManyMax.Value = 255
        'numChaseManyMin.Value = 0
        'numChaseSingleValue.Value = 255
        'numChaseManyIterations.Value = 10
        Dim I As Integer = 0
        Do Until I >= iChanSel.Count

            SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.ProgressRandomTimed = optRandomTimed.Checked
            SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.ProgressSoundActivated = optRandomSound.Checked
            SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.ProgressInOrder = optInOrder.Checked
            'SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.tTimer.Interval = numChaseTimebetween.Value
            SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.Interval = numChaseTimebetween.Value
            'SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.tTimer.Enabled = chkAutoRunning.Checked
            'SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.RunTimer = chkAutoRunning.Checked
            SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.ProgressLoop = chkLoop.Checked
            SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.SoundActivationThreshold = numSoundThreshold.Value

            SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.oscAmplitude = knbAmplitude.Value
            SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.oscCenter = knbCenter.Value
            SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.oscFrequency = knbFrequency.Value * 0.01
            SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.oscPhase = knbPhase.Value / 10


            SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.SoundLevel = knbSoundLevel.Value
            SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.SoundAttack = knbSoundAttack.Value
            SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.SoundRelease = knbSoundRelease.Value

            SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.ProgressList.Clear()

            For Each i1 In lstChase.Items
                SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.ProgressList.Add(Val(i1))
            Next

            Select Case lstWave.SelectedItem
                Case "Off"
                    SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.Mode = AutomationMode.Off
                    SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.StopTimer()
                Case "Chase"
                    SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.Mode = AutomationMode.Chase
                    SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.StartTimer()
                Case "Sine"
                    SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.Mode = AutomationMode.Sine
                    SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.oscIndex = I
                    SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.StartTimer()
                Case "Square"
                    SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.Mode = AutomationMode.Square
                    SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.oscIndex = I
                    SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.StartTimer()
                Case "Triangle"
                    SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.Mode = AutomationMode.Triangle
                    SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.oscIndex = I
                    SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.StartTimer()
                Case "Opposite"
                    SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.Mode = AutomationMode.Opposite
                    SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.StartTimer()
            End Select


            I += 1
        Loop
    End Sub

    Private Sub numSoundThreshold_ValueChanged(sender As Object, e As EventArgs) Handles numSoundThreshold.ValueChanged

    End Sub

    Private Sub lstWave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstWave.SelectedIndexChanged
        If formopened = False Then Exit Sub
        Select Case lstWave.SelectedItem
            Case "Off"
                numChaseTimebetween.Minimum = 0
                numChaseTimebetween.Maximum = 30000
            Case "Chase"
                numChaseTimebetween.Minimum = 0
                numChaseTimebetween.Maximum = 30000
            Case "Sine"
                numChaseTimebetween.Minimum = 50
                numChaseTimebetween.Value = 50
                numChaseTimebetween.Maximum = 3000
            Case "Square"
                numChaseTimebetween.Minimum = 50
                numChaseTimebetween.Value = 50
                numChaseTimebetween.Maximum = 3000
            Case "Triangle"
                numChaseTimebetween.Minimum = 50
                numChaseTimebetween.Value = 50
                numChaseTimebetween.Maximum = 3000
            Case "Opposite"
                numChaseTimebetween.Minimum = 0
                numChaseTimebetween.Maximum = 30000
        End Select
        SaveToMain()
        'If lstWave.SelectedItem = "Off" Then
        '    Dim I As Integer = 0
        '    Do Until I >= iChanSel.Count
        '        SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.StopTimer()
        '        SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.Mode = AutomationMode.Off
        '        I += 1
        '    Loop
        'ElseIf lstWave.SelectedItem = "Chase" Then
        '    Dim I As Integer = 0
        '    Do Until I >= iChanSel.Count
        '        SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.Mode = AutomationMode.Chase
        '        SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.StartTimer()
        '        I += 1
        '    Loop
        'ElseIf lstWave.SelectedItem = "Sine" Then
        '    Dim I As Integer = 0
        '    Do Until I >= iChanSel.Count
        '        SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.Mode = AutomationMode.Sine
        '        SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.oscIndex = I
        '        SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.StartTimer()
        '        I += 1
        '    Loop
        'ElseIf lstWave.SelectedItem = "Square" Then
        '    Dim I As Integer = 0
        '    Do Until I >= iChanSel.Count
        '        SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.Mode = AutomationMode.Square
        '        SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.oscIndex = I
        '        SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.StartTimer()
        '        I += 1
        '    Loop
        'ElseIf lstWave.SelectedItem = "Triangle" Then
        '    Dim I As Integer = 0
        '    Do Until I >= iChanSel.Count
        '        SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.Mode = AutomationMode.Triangle
        '        SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.oscIndex = I
        '        SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iChanSel(I)).Automation.StartTimer()
        '        I += 1
        '    Loop
        'End If

    End Sub
    Private Sub knbAmplitude_ValueChanged(Sender As Object) Handles knbAmplitude.ValueChanged
        If formopened = False Then Exit Sub
        txtAmplitude.Text = knbAmplitude.Value
        SaveToMain()

    End Sub

    Private Sub knbCenter_Load(sender As Object) Handles knbCenter.ValueChanged
        'middleValue = knbCenter.Value
        If formopened = False Then Exit Sub
        SaveToMain()
        txtCenter.Text = knbCenter.Value

    End Sub

    Private Sub knbFrequency_Load(sender As Object) Handles knbFrequency.ValueChanged
        'frequency = knbFrequency.Value * 0.01
        If formopened = False Then Exit Sub
        SaveToMain()
        txtFrequency.Text = knbFrequency.Value * 0.01

    End Sub

    Private Sub knbPhase_Load(sender As Object) Handles knbPhase.ValueChanged
        'phase = knbPhase.Value / 10
        If formopened = False Then Exit Sub
        SaveToMain()
        txtPhase.Text = knbPhase.Value / 10

    End Sub
    Private Sub knbSoundLevel_ValueChanged(Sender As Object) Handles knbSoundLevel.ValueChanged
        If formopened = False Then Exit Sub
        SaveToMain()

    End Sub


    Private Sub knbSoundAttack_ValueChanged(Sender As Object) Handles knbSoundAttack.ValueChanged
        If formopened = False Then Exit Sub
        SaveToMain()

    End Sub

    Private Sub knbSoundRelease_ValueChanged(Sender As Object) Handles knbSoundRelease.ValueChanged
        If formopened = False Then Exit Sub
        SaveToMain()

    End Sub

End Class
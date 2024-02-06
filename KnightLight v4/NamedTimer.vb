Imports System.Threading
Imports Super_Awesome_Lighting_DMX_board_v4.AudioThread
Imports Super_Awesome_Lighting_DMX_board_v4.mdlGlobalVariables

Public Class NamedTimer
    Private timer As Timer
    Private aSceneI As Integer
    Private aInterval As Integer
    Private isRunning As Boolean

    Public Sub New(SceneI As Integer, interval As Integer)
        aSceneI = SceneI
        aInterval = interval
        timer = New Timer(AddressOf TimerCallback, Nothing, 0, 0)
    End Sub
    Public Sub StopTimer()
        ' Stop the timer
        timer.Change(Timeout.Infinite, Timeout.Infinite)
        isRunning = False
    End Sub
    Public Sub StartTimer()
        ' Stop the timer
        timer.Change(0, aInterval)
        isRunning = True

    End Sub
    Public ReadOnly Property Interval() As Integer
        Get
            Return aInterval
        End Get

    End Property
    Public Function IsTimerRunning() As Boolean
        Return isRunning
    End Function
    Public Property SceneIndex() As Integer
        Get
            Return aSceneI
        End Get
        Set(ByVal NewI As Integer)
            aSceneI = NewI
        End Set

    End Property

    Private Sub TimerCallback(state As Object)
        'Console.WriteLine($"Timer '{timerName}' ticked on thread: {Thread.CurrentThread.ManagedThreadId}")

        If formopened = False Then Exit Sub
        If SceneData(aSceneI).Automation.tTimer.SceneIndex <> aSceneI Then
            'MsgBox("What")
        End If
        Dim I As Integer = aSceneI
        If SceneData(I).Automation.tmrDirection = "Down" Then
            If (SceneData(I).MasterValue - SceneData(I).Automation.IntervalSteps) <= 0 Then
                SceneData(I).Automation.tTimer.timer.Change(Timeout.Infinite, Timeout.Infinite)
                SceneData(I).Automation.tmrDirection = "lol"
                SceneData(I).MasterValue = 0
                frmMain.Invoke(Sub()
                                   ' Update UI element using Me.Invoke to marshal the call back to the UI thread
                                   frmMain.StartChannelTimers(I, False)
                               End Sub)

                'PresetFaders(getpres
            Else
                SceneData(I).MasterValue -= SceneData(I).Automation.IntervalSteps
            End If
        ElseIf SceneData(I).Automation.tmrDirection = "Up" Then
            If (SceneData(I).MasterValue + SceneData(I).Automation.IntervalSteps) >= 100 Then
                SceneData(I).Automation.tTimer.timer.Change(Timeout.Infinite, Timeout.Infinite)
                SceneData(I).Automation.tmrDirection = "lol"
                SceneData(I).MasterValue = 100
            Else
                SceneData(I).MasterValue += SceneData(I).Automation.IntervalSteps
            End If
        ElseIf SceneData(I).Automation.tmrDirection = "lol" Then
            SceneData(I).Automation.tTimer.timer.Change(Timeout.Infinite, Timeout.Infinite)
        ElseIf SceneData(I).Automation.tmrDirection = "" Then
            SceneData(I).Automation.tTimer.timer.Change(Timeout.Infinite, Timeout.Infinite)
        End If
        If SceneData(I).MasterValue > 0 Then
            frmMain.Invoke(Sub()
                               frmMain.StartChannelTimers(I, True)
                           End Sub)
        End If

        'PresetVisualUpdate = True
        'If I > PresetFaderControlModifier And I <= (PresetFaderControlModifier + PresetFadersTotal) Then
        '    PresetFaders(I - PresetFaderControlModifier).cTxtVal.Text = SceneData(I).MasterValue
        'End If
        'PresetVisualUpdate = False
        frmMain.Invoke(Sub()
                           frmMain.UpdatePresetControls(I)
                       End Sub)
    End Sub
End Class

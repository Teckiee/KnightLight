Imports System.Threading
Public Class cChannelAutomation
    Implements ICloneable

    Private timer As Timer
    Private iScene As Integer
    Private iChannel As Integer
    Private iInterval As Integer
    Private isRunning As Boolean

    Dim aProgressInOrder As Boolean
    Dim aProgressRandomTimed As Boolean
    Dim aProgressSoundActivated As Boolean
    Dim aSoundActivationThreshold As Integer
    Dim aProgressLoop As Boolean
    Public ProgressList As List(Of Integer)
    Dim aCurrentIofList As Integer

    Dim aoscAmplitude As Integer
    Dim aoscCenter As Integer
    Dim aoscFrequency As Double
    Dim aoscPhase As Double
    Dim aoscIndex As Integer
    Dim aoscDirection As String

    Dim aSoundLevel As Integer
    Dim aSoundAttack As Integer
    Dim aSoundRelease As Integer

    Dim aMode As AutomationMode

    Public Sub New(NewSceneI As Integer, NewChannelI As Integer, interval As Integer)
        iScene = NewSceneI
        iChannel = NewChannelI
        interval = interval
        ProgressList = New List(Of Integer)
        timer = New Timer(AddressOf TimerCallback, Nothing, 0, 0)
        isRunning = False
        aProgressInOrder = True
        aProgressLoop = False
        aProgressRandomTimed = False
        aProgressSoundActivated = False
        aSoundActivationThreshold = 500
        aMode = AutomationMode.Off
        aCurrentIofList = 0

        aoscPhase = 0.1
        aoscFrequency = 0.5
        aoscCenter = 127
        aoscAmplitude = 255

        aSoundAttack = 0
        aSoundLevel = 0
        aSoundRelease = 0
    End Sub
    Public Function Clone() As Object Implements ICloneable.Clone
        ' Create a deep copy of the cChannelAutomation object
        Dim copy As New cChannelAutomation(Me.iScene, Me.iChannel, Me.iInterval)
        ' Copy all relevant properties here
        ' For example:
        ' copy.Property1 = Me.Property1
        ' copy.Property2 = Me.Property2
        copy.isRunning = Me.isRunning
        copy.timer = Me.timer
        copy.iScene = Me.iScene
        copy.iChannel = Me.iChannel
        copy.iInterval = Me.iInterval
        copy.aProgressInOrder = Me.aProgressInOrder
        copy.aProgressRandomTimed = Me.aProgressRandomTimed
        copy.aProgressSoundActivated = Me.aProgressSoundActivated
        copy.aSoundActivationThreshold = Me.aSoundActivationThreshold
        copy.aProgressLoop = Me.aProgressLoop
        copy.ProgressList = New List(Of Integer)(Me.ProgressList)
        copy.aCurrentIofList = Me.aCurrentIofList
        copy.aoscAmplitude = Me.aoscAmplitude
        copy.aoscCenter = Me.aoscCenter
        copy.aoscFrequency = Me.aoscFrequency
        copy.aoscPhase = Me.aoscPhase
        copy.aoscIndex = Me.aoscIndex
        copy.aoscDirection = Me.aoscDirection
        copy.aSoundLevel = Me.aSoundLevel
        copy.aSoundAttack = Me.aSoundAttack
        copy.aSoundRelease = Me.aSoundRelease
        copy.aMode = Me.aMode

        Return copy
    End Function
    Public Sub StopTimer()
        ' Stop the timer
        timer.Change(Timeout.Infinite, Timeout.Infinite)
        isRunning = False
    End Sub
    Public Sub StartTimer()
        ' Stop the timer
        timer.Change(0, iInterval)
        isRunning = True

    End Sub
    Public Property Interval() As Integer
        Get
            Return iInterval
        End Get
        Set(ByVal NewInterval As Integer)
            iInterval = NewInterval
        End Set
    End Property
    'Public Function ProgressList() As List(Of Integer)

    '    Return aProgressList

    'End Function
    Public Property SoundRelease() As Integer
        Get
            Return aSoundRelease
        End Get
        Set(ByVal NewI As Integer)
            aSoundRelease = NewI
        End Set
    End Property
    Public Property SoundAttack() As Integer
        Get
            Return aSoundAttack
        End Get
        Set(ByVal NewI As Integer)
            aSoundAttack = NewI
        End Set
    End Property
    Public Property SoundLevel() As Integer
        Get
            Return aSoundLevel
        End Get
        Set(ByVal NewI As Integer)
            aSoundLevel = NewI
        End Set
    End Property
    Public Property oscPhase() As Double
        Get
            Return aoscPhase
        End Get
        Set(ByVal NewI As Double)
            aoscPhase = NewI
        End Set
    End Property
    Public Property oscIndex() As Integer
        Get
            Return aoscIndex
        End Get
        Set(ByVal NewI As Integer)
            aoscIndex = NewI
        End Set
    End Property
    Public Property oscDirection() As Integer
        Get
            Return aoscDirection
        End Get
        Set(ByVal NewI As Integer)
            aoscDirection = NewI
        End Set
    End Property
    Public Property oscFrequency() As Double
        Get
            Return aoscFrequency
        End Get
        Set(ByVal NewI As Double)
            aoscFrequency = NewI
        End Set
    End Property
    Public Property oscCenter() As Integer
        Get
            Return aoscCenter
        End Get
        Set(ByVal NewI As Integer)
            aoscCenter = NewI
        End Set
    End Property
    Public Property oscAmplitude() As Integer
        Get
            Return aoscAmplitude
        End Get
        Set(ByVal NewI As Integer)
            aoscAmplitude = NewI
        End Set
    End Property
    Public Property CurrentIofList() As Integer
        Get
            Return aCurrentIofList
        End Get
        Set(ByVal NewI As Integer)
            aCurrentIofList = NewI
        End Set
    End Property
    Public Property SoundActivationThreshold() As Integer
        Get
            Return aSoundActivationThreshold
        End Get
        Set(ByVal NewI As Integer)
            aSoundActivationThreshold = NewI
        End Set
    End Property
    Public Property ProgressLoop() As Boolean
        Get
            Return aProgressLoop
        End Get
        Set(ByVal Newb As Boolean)
            aProgressLoop = Newb
        End Set

    End Property
    Public Property ProgressSoundActivated() As Boolean
        Get
            Return aProgressSoundActivated
        End Get
        Set(ByVal Newb As Boolean)
            aProgressSoundActivated = Newb
        End Set

    End Property
    Public Property ProgressRandomTimed() As Boolean
        Get
            Return aProgressRandomTimed
        End Get
        Set(ByVal Newb As Boolean)
            aProgressRandomTimed = Newb
        End Set

    End Property
    Public Property ProgressInOrder() As Boolean
        Get
            Return aProgressInOrder
        End Get
        Set(ByVal Newb As Boolean)
            aProgressInOrder = Newb
        End Set

    End Property
    Public Property Mode() As Integer
        Get
            Return aMode
        End Get
        Set(ByVal NewMode As Integer)
            aMode = NewMode
        End Set
    End Property
    Public Property IsEnabled() As Boolean
        Get
            Return isRunning
        End Get
        Set(ByVal Newb As Boolean)
            If Newb = True Then
                StartTimer()
            Else
                StopTimer()
            End If
        End Set
    End Property
    Public Property SceneIndex() As Integer
        Get
            Return iScene
        End Get
        Set(ByVal NewI As Integer)
            iScene = NewI
        End Set

    End Property
    Public Property ChannelIndex() As Integer
        Get
            Return iChannel
        End Get
        Set(ByVal NewI As Integer)
            iChannel = NewI
        End Set

    End Property
    Private Sub TimerCallback(state As Object)
        If formopened = False Then Exit Sub


        '
        Dim newchanval As Integer = SceneData(iScene).ChannelValues(iChannel).Value

        If aMode = AutomationMode.Chase Then

            ' List In Order
            If aProgressInOrder = True Then
                If aCurrentIofList >= ProgressList.Count - 1 Then
                    aCurrentIofList = 0
                    If aProgressLoop = False Then
                        StopTimer()
                    End If
                Else
                    aCurrentIofList += 1
                    newchanval = ProgressList(aCurrentIofList)
                End If
            End If

            ' List Timed Random
            If aProgressRandomTimed = True Then
                aCurrentIofList = GetRandom(0, ProgressList.Count)
                newchanval = ProgressList(aCurrentIofList)
            End If

            ' List Sound Random
            If aProgressSoundActivated = True And SoundActivationCurrentLevel >= aSoundActivationThreshold Then
                aCurrentIofList = GetRandom(0, ProgressList.Count)
                newchanval = ProgressList(aCurrentIofList)
            End If



        ElseIf aMode = AutomationMode.Sine Then

            Dim time As Double = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) / 1000.0 ' Convert ticks to seconds

            newchanval = CInt((aoscAmplitude / 2) * Math.Sin(2 * Math.PI * aoscFrequency * time + (aoscPhase * aoscIndex)) + aoscCenter)

            If newchanval < 0 Then newchanval = 0
            If newchanval > 255 Then newchanval = 255



        ElseIf aMode = AutomationMode.Square Then

        ElseIf aMode = AutomationMode.Triangle Then

            Dim variance As Integer = (aoscAmplitude / 2) + aoscCenter
            If newchanval >= variance Then
                aoscDirection = "Decreasing"
            ElseIf newchanval <= 255 - variance Then
                aoscDirection = "Increasing"
            End If

            ' Increment or decrement the channelValue accordingly
            If aoscDirection = "Increasing" Then
                newchanval += CInt(aoscAmplitude * aoscFrequency * iInterval / 1000)
            Else
                newchanval -= CInt(aoscAmplitude * aoscFrequency * iInterval / 1000)
            End If

        ElseIf aMode = AutomationMode.Opposite Then
            If ProgressList.Count >= 1 Then
                newchanval = 255 - SceneData(iScene).ChannelValues(ProgressList(0)).Value
            End If
        End If

        With SceneData(iScene).ChannelValues(iChannel)

            .Value = newchanval

            ' After .Value is changed update controls
            frmChannels.Invoke(Sub() UpdateChannelControls(iChannel, .Value))

            'frmChannels.Invoke(Sub()
            '                       If frmChannels.cmbChannelPresetSelection.SelectedIndex = SceneIndex - 1 Then ' And tbcControls1.SelectedTab Is frmChannels Then

            '                           If iChannel >= frmChannels.CurrentFirstChannel And iChannel <= frmChannels.CurrentLastChannel Then
            '                               Dim cLocationOnChannels As Integer = iChannel Mod ChannelControlSetsPerPage
            '                               frmChannels.UpdateFixtureLabel(iChannel)

            '                               ChannelFaders(cLocationOnChannels).dmrvs.Value = .Value


            '                           End If


            '                       End If
            '                   End Sub)
        End With
    End Sub
    Private Sub UpdateChannelControls(iChannel As Integer, newchanval As Integer)
        If frmChannels.cmbChannelPresetSelection.SelectedIndex = SceneIndex - 1 Then
            If iChannel >= frmChannels.CurrentFirstChannel And iChannel <= frmChannels.CurrentLastChannel Then
                'Dim cLocationOnChannels As Integer = iChannel Mod
                Dim cLocationOnChannels As Integer
                If iChannel Mod ChannelControlSetsPerPage = 0 And iChannel <> 0 Then
                    cLocationOnChannels = ChannelControlSetsPerPage
                Else
                    cLocationOnChannels = iChannel Mod 340
                End If
                frmChannels.UpdateFixtureLabel(iChannel)
                ChannelFaders(cLocationOnChannels).dmrvs.Value = newchanval
            End If
        End If
    End Sub

End Class

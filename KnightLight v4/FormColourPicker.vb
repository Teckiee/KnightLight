Imports System.ComponentModel
Imports ColorPickerLib
Public Class FormColourPicker
    Public iRChan As Integer = -1
    Public iGChan As Integer = -1
    Public iBChan As Integer = -1
    Public iRChanSel As New List(Of Integer)
    Public iGChanSel As New List(Of Integer)
    Public iBChanSel As New List(Of Integer)

    Private Sub FormColourPicker_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub FormColourPicker_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        iRChanSel.Clear()
        iGChanSel.Clear()
        iBChanSel.Clear()
        Me.Hide()
    End Sub

    Private Sub ColorPicker2_ColorChanging(sender As Object, CurrentARGBColor As Color, CurrentRGBColor As Color, ClosestColorName As String) Handles ColorPicker2.ColorChanging
        If iRChan = -1 Then Exit Sub
        If iGChan = -1 Then Exit Sub
        If iBChan = -1 Then Exit Sub
        If Me.Visible = False Then Exit Sub
        If iRChan >= frmChannels.numChannelFadersStart.Value And iRChan < frmChannels.numChannelFadersStart.Value + ChannelControlSetsPerPage - 1 Then
            ChannelFaders(iRChan).cFader.Value = CurrentARGBColor.R
        End If
        If iGChan >= frmChannels.numChannelFadersStart.Value And iGChan < frmChannels.numChannelFadersStart.Value + ChannelControlSetsPerPage - 1 Then
            ChannelFaders(iGChan).cFader.Value = CurrentARGBColor.G
        End If
        If iBChan >= frmChannels.numChannelFadersStart.Value And iBChan < frmChannels.numChannelFadersStart.Value + ChannelControlSetsPerPage - 1 Then
            ChannelFaders(iBChan).cFader.Value = CurrentARGBColor.B
        End If


        If Not iRChanSel Is Nothing Then
            'ChannelFaderPageCurrentSceneDataIndex
            Dim Ri As Integer = 0
            Do Until Ri >= iRChanSel.Count
                SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iRChanSel(Ri)).Value = CurrentARGBColor.R
                If iRChanSel(Ri) >= frmChannels.numChannelFadersStart.Value And iRChanSel(Ri) < frmChannels.numChannelFadersStart.Value + ChannelControlSetsPerPage - 1 Then
                    'is on screen
                    ChannelFaders(iRChanSel(Ri)).cFader.Value = CurrentARGBColor.R
                End If
                Ri += 1
            Loop

            Dim Gi As Integer = 0
            Do Until Gi >= iRChanSel.Count
                SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iGChanSel(Gi)).Value = CurrentARGBColor.G
                If iGChanSel(Gi) >= frmChannels.numChannelFadersStart.Value And iGChanSel(Gi) < frmChannels.numChannelFadersStart.Value + ChannelControlSetsPerPage - 1 Then
                    'is on screen
                    ChannelFaders(iGChanSel(Gi)).cFader.Value = CurrentARGBColor.G
                End If
                Gi += 1
            Loop

            Dim Bi As Integer = 0
            Do Until Bi >= iRChanSel.Count
                SceneData(ChannelFaderPageCurrentSceneDataIndex).ChannelValues(iBChanSel(Bi)).Value = CurrentARGBColor.B
                If iBChanSel(Bi) >= frmChannels.numChannelFadersStart.Value And iBChanSel(Bi) < frmChannels.numChannelFadersStart.Value + ChannelControlSetsPerPage - 1 Then
                    'is on screen
                    ChannelFaders(iBChanSel(Bi)).cFader.Value = CurrentARGBColor.B
                End If
                Bi += 1
            Loop


        End If
    End Sub
End Class
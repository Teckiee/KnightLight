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
Public Class FormQuickChanges
    Private Sub FormQuickChanges_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        frmQuickChanges.Hide()
    End Sub
    Private Sub lstDramaPresets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDramaPresets.SelectedIndexChanged
        'PresetControls(PresetIndex(lstPrsets.SelectedItem)).vtxtBox.Text = 100
        If lstDramaPresets.SelectedIndex = -1 Then Exit Sub

        Dim I As Integer = 1
        Do Until I >= SceneData.Length
            If SceneData(I).MasterValue > 0 Then 'preset is above blackout
                If isDramaPresetSelected(I) = False Then
                    With SceneData(I)
                        .Automation.tmrDirection = "Down"
                        .Automation.IntervalSteps = 255 / (.Automation.TimeBetweenMinAndMax / .Automation.tTimer.Interval)
                        .Automation.tTimer.Start()
                    End With
                End If
            ElseIf SceneData(I).MasterValue = 0 Then 'preset is at blackout
                If isDramaPresetSelected(I) = True Then
                    With SceneData(I)
                        .Automation.tmrDirection = "Up"
                        .Automation.IntervalSteps = 255 / (.Automation.TimeBetweenMinAndMax / .Automation.tTimer.Interval)
                        .Automation.tTimer.Start()
                    End With
                End If
            End If

            I += 1
        Loop

    End Sub
    Function isDramaPresetSelected(ByVal PresetControlsIndex As Integer) As Boolean
        Dim I As Integer = 0
        Do Until I >= lstDramaPresets.SelectedItems.Count
            If lstDramaPresets.SelectedItems(I) = SceneData(PresetControlsIndex).SceneName Then
                Return True
                Exit Function
            End If
            I += 1
        Loop
        Return False
    End Function

    Private Sub trkDramaViewVolume2_Scroll(sender As Object, e As EventArgs) Handles trkDramaViewVolume2.Scroll
        frmMusicEditor.trkVolume2_Scroll(sender, e)
    End Sub

    Private Sub cmdDramaViewSkip2_Click(sender As Object, e As EventArgs) Handles cmdDramaViewSkip2.Click
        frmMusicEditor.cmdSkip2_Click(sender, e)
    End Sub

    Private Sub cmdDramaViewPlay_Click(sender As Object, e As EventArgs) Handles cmdDramaViewPlay.Click
        frmMusicEditor.cmdPlay_Click(sender, e)
    End Sub

    Private Sub cmdDramaViewStop_Click(sender As Object, e As EventArgs) Handles cmdDramaViewStop.Click
        frmMusicEditor.cmdStop_Click(sender, e)
    End Sub

    Private Sub cmdDramaViewSkip_Click(sender As Object, e As EventArgs) Handles cmdDramaViewSkip.Click
        frmMusicEditor.cmdSkip_Click(sender, e)
    End Sub

    Private Sub trkDramaViewVolume_Scroll(sender As Object, e As EventArgs) Handles trkDramaViewVolume.Scroll
        frmMusicEditor.trkVolume_Scroll(sender, e)
    End Sub

    Private Sub cmdDramaViewPlay2_Click(sender As Object, e As EventArgs) Handles cmdDramaViewPlay2.Click
        frmMusicEditor.cmdPlay2_Click(sender, e)
    End Sub

    Private Sub cmdDramaViewStop2_Click(sender As Object, e As EventArgs) Handles cmdDramaViewStop2.Click
        frmMusicEditor.cmdStop2_Click(sender, e)
    End Sub

    Private Sub lstDramaViewSongs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDramaViewSongs.SelectedIndexChanged
        frmMusicEditor.lstSongs_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub lstDramaViewSongs2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDramaViewSongs2.SelectedIndexChanged
        frmMusicEditor.lstSongs2_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub cmdDramaBlackoutAllTimer_Click(sender As Object, e As EventArgs) Handles cmdDramaBlackoutAllTimer.Click
        frmScenes.cmdPresetsBlackoutAllTimer_Click(sender, e)
    End Sub

    Private Sub cmdDramaBlackoutAllInstant_Click(sender As Object, e As EventArgs) Handles cmdDramaBlackoutAllInstant.Click
        frmScenes.cmdPresetsBlackoutAllInstant_Click(sender, e)
    End Sub
End Class
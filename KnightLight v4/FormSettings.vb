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
Public Class FormSettings
    Private Sub FormSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblAudioActive.BackColor = Color.Black
        lblAudioActive.ForeColor = lblChannelNumberColour.BackColor
    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        frmSettings.Hide()
    End Sub
    Private Sub cmd4KSize_Click(sender As Object, e As EventArgs) Handles cmd4KSize.Click
        frmContainer.Size = New Point(3840, 2160)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Arduinos(0).Serial.Write("UID," & Arduinos(0).PortNo & vbCrLf)
    End Sub

    Private Sub cmdSerialClear_Click(sender As Object, e As EventArgs) Handles cmdSerialClear.Click
        txtSerialIn.Text = ""
    End Sub

    Private Sub cmdOpenTouchpad_Click(sender As Object, e As EventArgs) Handles cmdOpenTouchpad.Click
        frmTouchPad.Show()
    End Sub


#Region " Colour Pickers "
    Private Sub cmdChannelBulletColour_Click(sender As Object, e As EventArgs) Handles cmdChannelBulletColour.Click
        Dim coldialog As New ColorDialog
        coldialog.Color = lblChannelBulletColour.BackColor
        coldialog.ShowDialog()
        lblChannelBulletColour.BackColor = coldialog.Color

        Dim I As Integer = 1
        Do Until I >= ChannelFaders.Length
            If Not ChannelFaders(I).cFader Is Nothing Then
                ChannelFaders(I).cFader.BulletColor = coldialog.Color
            Else
                Exit Do
            End If
            I += 1
        Loop
    End Sub

    Private Sub cmdChannelBackColour_Click(sender As Object, e As EventArgs) Handles cmdChannelBackColour.Click
        Dim coldialog As New ColorDialog
        coldialog.Color = lblChannelBackColour.BackColor
        coldialog.ShowDialog()
        lblChannelBackColour.BackColor = coldialog.Color

        Dim I As Integer = 1
        Do Until I >= ChannelFaders.Length
            If Not ChannelFaders(I).cFader Is Nothing Then
                ChannelFaders(I).cFader.BackColor = coldialog.Color
            Else
                Exit Do
            End If
            I += 1
        Loop
    End Sub

    Private Sub cmdChannelFillColour_Click(sender As Object, e As EventArgs) Handles cmdChannelFillColour.Click
        Dim coldialog As New ColorDialog
        coldialog.Color = lblChannelFillColour.BackColor
        coldialog.ShowDialog()
        lblChannelFillColour.BackColor = coldialog.Color

        Dim I As Integer = 1
        Do Until I >= ChannelFaders.Length
            If Not ChannelFaders(I).cFader Is Nothing Then
                ChannelFaders(I).cFader.FillColor = coldialog.Color
            Else
                Exit Do
            End If

            I += 1
        Loop
    End Sub
    Private Sub cmdChannelNumberColour_Click(sender As Object, e As EventArgs) Handles cmdChannelNumberColour.Click
        Dim coldialog As New ColorDialog
        coldialog.Color = lblChannelNumberColour.BackColor
        coldialog.ShowDialog()
        lblChannelNumberColour.BackColor = coldialog.Color

        Dim I As Integer = 1
        Do Until I >= ChannelFaders.Length
            If Not ChannelFaders(I).cChannelLabel Is Nothing Then
                ChannelFaders(I).cChannelLabel.ForeColor = coldialog.Color
            Else
                Exit Do
            End If

            I += 1
        Loop
    End Sub

    Private Sub cmdSceneBlackoutColour_Click(sender As Object, e As EventArgs) Handles cmdSceneBlackoutColour.Click
        Dim coldialog As New ColorDialog
        coldialog.Color = lblSceneBlackoutColour.BackColor
        coldialog.ShowDialog()
        lblSceneBlackoutColour.BackColor = coldialog.Color

        Dim I As Integer = 1
        Do Until I >= PresetFaders.Length
            If Not PresetFaders(I).cBlackout Is Nothing Then
                If Val(PresetFaders(I).cTxtVal.Text) = 0 Then
                    PresetFaders(I).cBlackout.BackColor = coldialog.Color
                End If
            Else
                Exit Do
            End If
            I += 1
        Loop
    End Sub

    Private Sub cmdSceneUpColour_Click(sender As Object, e As EventArgs) Handles cmdSceneUpColour.Click
        Dim coldialog As New ColorDialog
        coldialog.Color = lblSceneUpColour.BackColor
        coldialog.ShowDialog()
        lblSceneUpColour.BackColor = coldialog.Color

        Dim I As Integer = 1
        Do Until I >= PresetFaders.Length
            If Not PresetFaders(I).cFull Is Nothing Then
                If Val(PresetFaders(I).cTxtVal.Text) > 0 Then
                    PresetFaders(I).cFull.BackColor = coldialog.Color
                End If
            Else
                Exit Do
            End If
            I += 1
        Loop
    End Sub

    Private Sub cmdSceneFillColour_Click(sender As Object, e As EventArgs) Handles cmdSceneFillColour.Click
        'Dim coldialog As New ColorDialog
        'coldialog.Color = lblSceneFillColour.BackColor
        'coldialog.ShowDialog()
        'lblSceneFillColour.BackColor = coldialog.Color

        'Dim I As Integer = 1
        'Do Until I >= PresetFaders.Length
        '    If Not PresetFaders(I).cFader Is Nothing Then
        '        PresetFaders(I).cFader.FillColor = coldialog.Color
        '    Else
        '        Exit Do
        '    End If
        '    I += 1
        'Loop
    End Sub

    Private Sub cmdSceneLabelColour_Click(sender As Object, e As EventArgs) Handles cmdSceneLabelColour.Click
        Dim coldialog As New ColorDialog
        coldialog.Color = lblSceneLabelColour.BackColor
        coldialog.ShowDialog()
        lblSceneLabelColour.BackColor = coldialog.Color

        Dim I As Integer = 1
        Do Until I >= PresetFaders.Length
            If Not PresetFaders(I).cPresetName Is Nothing Then
                PresetFaders(I).cPresetName.ForeColor = coldialog.Color
            Else
                Exit Do
            End If
            I += 1
        Loop
    End Sub
#End Region

    Private Sub cmdColourTest_Click(sender As Object, e As EventArgs) Handles cmdColourTest.Click
        frmGradientColour.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        frmCustomColourPicker.ColorPicker2.Value = Color.Fuchsia
        frmCustomColourPicker.ShowDialog()
        'frmCustomColourPicker.ColorPicker2.Value.Name
    End Sub
    Private Sub cmdSaveSettings_Click(sender As Object, e As EventArgs) Handles cmdSaveSettings.Click
        SaveSettingsToFile()
    End Sub
    Private Sub SaveSettingsToFile()

        File.Copy(Application.StartupPath & "\Settings.ini", Application.StartupPath & "\Settings.Backup.ini", True)
        FileOpen(1, Application.StartupPath & "\Settings.ini", OpenMode.Output)
        PrintLine(1, "ChannelCount=" & frmSettings.numEndChannel.Value)
        PrintLine(1, "DimmerChannelRows=" & ChannelControlSetsPerPage)
        PrintLine(1, "LoadonChange=" & frmSettings.chkLoadonChange.Checked)
        PrintLine(1, "LastBank=" & frmBanks.lstBanks.SelectedItem)
        PrintLine(1, "ChannelBulletColour=" & frmSettings.lblChannelBulletColour.BackColor.ToArgb)
        PrintLine(1, "ChannelBackColour=" & frmSettings.lblChannelBackColour.BackColor.ToArgb)
        PrintLine(1, "ChannelFillColour=" & frmSettings.lblChannelFillColour.BackColor.ToArgb)
        PrintLine(1, "ChannelNumberColour=" & frmSettings.lblChannelNumberColour.BackColor.ToArgb)
        PrintLine(1, "SceneBulletColour=" & frmSettings.lblSceneBlackoutColour.BackColor.ToArgb)
        PrintLine(1, "SceneBackColour=" & frmSettings.lblSceneUpColour.BackColor.ToArgb)
        PrintLine(1, "SceneFillColour=" & frmSettings.lblSceneFillColour.BackColor.ToArgb)
        PrintLine(1, "SceneLabelColour=" & frmSettings.lblSceneLabelColour.BackColor.ToArgb)
        PrintLine(1, "MultipleThreadCount=" & tChannelsMultipleThreads)

        FileClose(1)

    End Sub

End Class
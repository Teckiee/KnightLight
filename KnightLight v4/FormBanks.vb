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
Public Class FormBanks
    Private Sub FormBanks_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        frmBanks.Hide()
    End Sub
    Public Sub LoadBanksFromFile()
        lstBanks.Items.Clear()

        For Each S As String In Directory.GetDirectories(Application.StartupPath & "\Save Files\")
            Dim a() As String = Split(S, "\")
            lstBanks.Items.Add(a(a.Length - 1))
        Next S
        Application.DoEvents()
    End Sub
#Region "Banks"
    Private Sub cmdBankNew_Click(sender As Object, e As EventArgs)
        Dim s As String = InputBox("Name of new bank:")
        If s = "" Then Exit Sub
        Directory.CreateDirectory(Application.StartupPath & "\Save Files\" & s)
        LoadBanksFromFile()
    End Sub

    Private Sub cmdBankRename_Click(sender As Object, e As EventArgs)
        If lstBanks.SelectedIndex = -1 Then Exit Sub
        Dim s As String = InputBox("Name of new bank:")
        If s = "" Then Exit Sub
        Directory.Move(Application.StartupPath & "\Save Files\" & lstBanks.SelectedItem, Application.StartupPath & "\Save Files\" & s)
        LoadBanksFromFile()
    End Sub


    Private Sub lstBanks_SelectedIndexChanged(sender As Object, e As EventArgs)
        If formopened = False Then Exit Sub

        'Dim I As Integer = 1
        'Do Until I >= SceneData.Length
        '    Dim I1 As Integer = 1

        '    SceneData(I).SceneName = ""
        '    SceneData(I).MasterValue = 0
        '    SceneData(I).Automation.TimeBetweenMinAndMax = 1000
        '    SceneData(I).Automation.Max = 100
        '    SceneData(I).Automation.Min = 0

        '    'SceneData(I).ChannelValues = Nothing

        '    'Do Until I1 >= 512
        '    '    SceneData(I).ChannelValues = Nothing
        '    '    With SceneData(I).ChannelValues(I1)
        '    '        .Automation.tTimer = New Windows.Forms.Timer
        '    '        .Value = 0
        '    '        .Automation.tTimer.Interval = 10
        '    '        .Automation.tTimer.Enabled = False
        '    '        .Automation.Max = 255
        '    '        .Automation.Min = 0
        '    '        .Automation.TimeBetweenMinAndMax = 1000
        '    '        .Automation.randomstart = False
        '    '    End With
        '    '    I1 += 1
        '    'Loop
        '    I += 1
        'Loop
        BankChanged = True

        frmScenes.LoadScenesFromFile()
        frmMusicEditor.LoadMusicTracks()

        frmScenes.cmdPresetP1.BackColor = Color.Red
        frmScenes.cmdPresetP2.BackColor = controlcolour
        frmScenes.cmdPresetP3.BackColor = controlcolour
        frmScenes.cmdPresetP4.BackColor = controlcolour
        frmScenes.cmdPresetP5.BackColor = controlcolour
        frmScenes.cmdPresetP6.BackColor = controlcolour

        frmScenes.cmdPresetP1.ForeColor = Color.White
        frmScenes.cmdPresetP2.ForeColor = Color.Black
        frmScenes.cmdPresetP3.ForeColor = Color.Black
        frmScenes.cmdPresetP4.ForeColor = Color.Black
        frmScenes.cmdPresetP5.ForeColor = Color.Black
        frmScenes.cmdPresetP6.ForeColor = Color.Black

        frmScenes.RenamePresetFaderControls()

        BankChanged = False

    End Sub






#End Region
End Class
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.tbcControls1 = New System.Windows.Forms.TabControl()
        Me.tbpBanks = New System.Windows.Forms.TabPage()
        Me.lstBanks = New System.Windows.Forms.ListBox()
        Me.cmdBankDelete = New System.Windows.Forms.Button()
        Me.cmdBankRename = New System.Windows.Forms.Button()
        Me.cmdBankNew = New System.Windows.Forms.Button()
        Me.tbpPresets = New System.Windows.Forms.TabPage()
        Me.pnlMusicplayers = New System.Windows.Forms.Panel()
        Me.CtrlMusicPlayer1 = New Super_Awesome_Lighting_DMX_board_v4.ctrlMusicPlayer()
        Me.cmdReloadSongLists = New System.Windows.Forms.Button()
        Me.lstPresetsSongChanges2 = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstPresetsSongChanges1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdPresetsSkip2 = New System.Windows.Forms.Button()
        Me.cmdPresetsSkip = New System.Windows.Forms.Button()
        Me.lblPresetsMP3PositionMilli2 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.lblPresetsMP3Position2 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.lblPresetsMP3Duration2 = New System.Windows.Forms.Label()
        Me.cmdPresetsStop2 = New System.Windows.Forms.Button()
        Me.cmdPresetsPlay2 = New System.Windows.Forms.Button()
        Me.trkPresetsVolume2 = New System.Windows.Forms.TrackBar()
        Me.lstPresetsSongs2 = New System.Windows.Forms.ListBox()
        Me.lblPresetsMP3PositionMilli = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.lblPresetsMP3Position = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.lblPresetsMP3Duration = New System.Windows.Forms.Label()
        Me.cmdPresetsStop = New System.Windows.Forms.Button()
        Me.cmdPresetsPlay = New System.Windows.Forms.Button()
        Me.lstPresetsSongs = New System.Windows.Forms.ListBox()
        Me.trkPresetsVolume = New System.Windows.Forms.TrackBar()
        Me.cmdReloadPresetLocations = New System.Windows.Forms.Button()
        Me.cmdPresetP7 = New System.Windows.Forms.Button()
        Me.cmdPresetP8 = New System.Windows.Forms.Button()
        Me.cmdPresetP5 = New System.Windows.Forms.Button()
        Me.cmdPresetP6 = New System.Windows.Forms.Button()
        Me.cmdPresetP3 = New System.Windows.Forms.Button()
        Me.cmdPresetP4 = New System.Windows.Forms.Button()
        Me.cmdPresetsBlackoutAllInstant = New System.Windows.Forms.Button()
        Me.cmdPresetsBlackoutAllTimer = New System.Windows.Forms.Button()
        Me.cmdPresetP1 = New System.Windows.Forms.Button()
        Me.cmdPresetP2 = New System.Windows.Forms.Button()
        Me.tbpMusic = New System.Windows.Forms.TabPage()
        Me.lstMusicSongChanges2 = New System.Windows.Forms.ListView()
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstMusicSongChanges1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdEditUpdate = New System.Windows.Forms.Button()
        Me.txtEditTime = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.numFadeIn = New System.Windows.Forms.NumericUpDown()
        Me.lblFadeIn = New System.Windows.Forms.Label()
        Me.numFadeOut = New System.Windows.Forms.NumericUpDown()
        Me.lblFadeOut = New System.Windows.Forms.Label()
        Me.vSongEdit = New Super_Awesome_Lighting_DMX_board_v4.GScrollBar()
        Me.lstSongEditPresets = New System.Windows.Forms.ListBox()
        Me.ctxDramaChangesActions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxDramaEditChannels = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxDramaSaveScene = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxDramaDuplicateScene = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxDramaRenameScene = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdEditSongCopyNew = New System.Windows.Forms.Button()
        Me.cmdEditSongSave = New System.Windows.Forms.Button()
        Me.cmdCreatelink = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lbleditRemaining = New System.Windows.Forms.Label()
        Me.lbleditPositionMilli = New System.Windows.Forms.Label()
        Me.lbleditposition = New System.Windows.Forms.Label()
        Me.cmdEditStop = New System.Windows.Forms.Button()
        Me.cmdEditPlay = New System.Windows.Forms.Button()
        Me.chkEnableSongEdit = New System.Windows.Forms.CheckBox()
        Me.cmdMusicSkip2 = New System.Windows.Forms.Button()
        Me.cmdMusicSkip = New System.Windows.Forms.Button()
        Me.lblMusicMP3PositionMilli2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblMusicMP3Position2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblMusicMP3Duration2 = New System.Windows.Forms.Label()
        Me.cmdMusicStop2 = New System.Windows.Forms.Button()
        Me.cmdMusicPlay2 = New System.Windows.Forms.Button()
        Me.trkMusicVolume2 = New System.Windows.Forms.TrackBar()
        Me.lstMusicSongs2 = New System.Windows.Forms.ListBox()
        Me.lblMusicMP3PositionMilli = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblMusicMP3Position = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblMusicMP3Duration = New System.Windows.Forms.Label()
        Me.cmdMusicStop = New System.Windows.Forms.Button()
        Me.cmdMusicPlay = New System.Windows.Forms.Button()
        Me.lstMusicSongs = New System.Windows.Forms.ListBox()
        Me.trkMusicVolume = New System.Windows.Forms.TrackBar()
        Me.tbpScriptChanges = New System.Windows.Forms.TabPage()
        Me.lstDramaViewSongChanges2 = New System.Windows.Forms.ListView()
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstDramaViewSongChanges1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdDramaBlackoutAllInstant = New System.Windows.Forms.Button()
        Me.cmdDramaBlackoutAllTimer = New System.Windows.Forms.Button()
        Me.lstDramaPresets = New System.Windows.Forms.ListBox()
        Me.cmdDramaViewSkip2 = New System.Windows.Forms.Button()
        Me.cmdDramaViewSkip = New System.Windows.Forms.Button()
        Me.lblDramaViewMP3PositionMilli2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblDramaViewMP3Position2 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lblDramaViewMP3Duration2 = New System.Windows.Forms.Label()
        Me.cmdDramaViewStop2 = New System.Windows.Forms.Button()
        Me.cmdDramaViewPlay2 = New System.Windows.Forms.Button()
        Me.trkDramaViewVolume2 = New System.Windows.Forms.TrackBar()
        Me.lstDramaViewSongs2 = New System.Windows.Forms.ListBox()
        Me.lblDramaViewMP3PositionMilli = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.lblDramaViewMP3Position = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.lblDramaViewMP3Duration = New System.Windows.Forms.Label()
        Me.cmdDramaViewStop = New System.Windows.Forms.Button()
        Me.cmdDramaViewPlay = New System.Windows.Forms.Button()
        Me.lstDramaViewSongs = New System.Windows.Forms.ListBox()
        Me.trkDramaViewVolume = New System.Windows.Forms.TrackBar()
        Me.tbpSettings = New System.Windows.Forms.TabPage()
        Me.cmdCOMDisconnect = New System.Windows.Forms.Button()
        Me.cmdSetMarsConsole = New System.Windows.Forms.Button()
        Me.chkMusicNextFollows = New System.Windows.Forms.CheckBox()
        Me.lstStartup = New System.Windows.Forms.ListView()
        Me.ColumnHeader32 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader33 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader34 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblSceneBorderColour = New System.Windows.Forms.Label()
        Me.cmdSceneBorderColor = New System.Windows.Forms.Button()
        Me.cmdAsioDown = New System.Windows.Forms.Button()
        Me.cmdAsioUp = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lstASIOInterfaces = New System.Windows.Forms.ListView()
        Me.ColumnHeader30 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader29 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdRepeatAssignments = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSCSPort = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSCSIPaddress = New System.Windows.Forms.TextBox()
        Me.cmdReloadArduinoAssignments = New System.Windows.Forms.Button()
        Me.cmdSetSoundActivation = New System.Windows.Forms.Button()
        Me.cmdSetDMX1 = New System.Windows.Forms.Button()
        Me.cmdSetMusic2 = New System.Windows.Forms.Button()
        Me.cmdSetMusic1 = New System.Windows.Forms.Button()
        Me.cmdRestartSerial = New System.Windows.Forms.Button()
        Me.lstCOMdevices = New System.Windows.Forms.ListView()
        Me.ColumnHeader25 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader26 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader27 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader28 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader31 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblSongChangeColour = New System.Windows.Forms.Label()
        Me.cmdSongChangeColour = New System.Windows.Forms.Button()
        Me.cmdSaveSettings = New System.Windows.Forms.Button()
        Me.lblSceneLabelColour = New System.Windows.Forms.Label()
        Me.cmdSceneLabelColour = New System.Windows.Forms.Button()
        Me.cmdSerialClear = New System.Windows.Forms.Button()
        Me.lblUpDownTest = New System.Windows.Forms.Label()
        Me.txtSerialIn = New System.Windows.Forms.TextBox()
        Me.lblChannelNumberColour = New System.Windows.Forms.Label()
        Me.cmdChannelNumberColour = New System.Windows.Forms.Button()
        Me.lblSceneFillColour = New System.Windows.Forms.Label()
        Me.lblSceneUpColour = New System.Windows.Forms.Label()
        Me.lblSceneBlackoutColour = New System.Windows.Forms.Label()
        Me.cmdSceneFillColour = New System.Windows.Forms.Button()
        Me.cmdSceneUpColour = New System.Windows.Forms.Button()
        Me.cmdSceneBlackoutColour = New System.Windows.Forms.Button()
        Me.lblChannelFillColour = New System.Windows.Forms.Label()
        Me.lblChannelBackColour = New System.Windows.Forms.Label()
        Me.lblChannelBulletColour = New System.Windows.Forms.Label()
        Me.cmdChannelFillColour = New System.Windows.Forms.Button()
        Me.cmdChannelBackColour = New System.Windows.Forms.Button()
        Me.cmdChannelBulletColour = New System.Windows.Forms.Button()
        Me.chkLoadonChange = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numEndChannel = New System.Windows.Forms.NumericUpDown()
        Me.tbpMarsSettings = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdSendAll = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.numMarsLargeFaders = New System.Windows.Forms.NumericUpDown()
        Me.txtMarsDebug = New System.Windows.Forms.TextBox()
        Me.chkAsioMode = New System.Windows.Forms.CheckBox()
        Me.lblMaster = New System.Windows.Forms.Label()
        Me.numChangeMS = New System.Windows.Forms.NumericUpDown()
        Me.cmdMasterFull = New System.Windows.Forms.Button()
        Me.cmdMasterBlackout = New System.Windows.Forms.Button()
        Me.txtMaster = New System.Windows.Forms.TextBox()
        Me.cmdOpenTouchpad = New System.Windows.Forms.Button()
        Me.tmrMP3 = New System.Windows.Forms.Timer(Me.components)
        Me.tmrMP32 = New System.Windows.Forms.Timer(Me.components)
        Me.cmd4KSize = New System.Windows.Forms.Button()
        Me.tmrMaster = New System.Windows.Forms.Timer(Me.components)
        Me.cmdColourTest = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.lblAudioActive = New System.Windows.Forms.Label()
        Me.ctxPresetLabelEditChannels = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxPresetRenameScene = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ctxPresetLabelName = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxPresetLabelActions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SaveSceneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DuplicateSceneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxSendNext = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxSendPrevious = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrserial = New System.Windows.Forms.Timer(Me.components)
        Me.tmrAVUCheck = New System.Windows.Forms.Timer(Me.components)
        Me.lblAudio2 = New System.Windows.Forms.Label()
        Me.barVUmeter = New System.Windows.Forms.VScrollBar()
        Me.vsMaster = New Super_Awesome_Lighting_DMX_board_v4.GScrollBar()
        Me.lblMarsConnected = New System.Windows.Forms.Label()
        Me.txtGithubIssue = New System.Windows.Forms.TextBox()
        Me.cmdSubmitIssue = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbcControls1.SuspendLayout()
        Me.tbpBanks.SuspendLayout()
        Me.tbpPresets.SuspendLayout()
        Me.pnlMusicplayers.SuspendLayout()
        CType(Me.trkPresetsVolume2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkPresetsVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpMusic.SuspendLayout()
        CType(Me.numFadeIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFadeOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxDramaChangesActions.SuspendLayout()
        CType(Me.trkMusicVolume2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkMusicVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpScriptChanges.SuspendLayout()
        CType(Me.trkDramaViewVolume2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkDramaViewVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpSettings.SuspendLayout()
        CType(Me.numEndChannel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpMarsSettings.SuspendLayout()
        CType(Me.numMarsLargeFaders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numChangeMS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxPresetLabelActions.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbcControls1
        '
        Me.tbcControls1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcControls1.Controls.Add(Me.tbpBanks)
        Me.tbcControls1.Controls.Add(Me.tbpPresets)
        Me.tbcControls1.Controls.Add(Me.tbpMusic)
        Me.tbcControls1.Controls.Add(Me.tbpScriptChanges)
        Me.tbcControls1.Controls.Add(Me.tbpSettings)
        Me.tbcControls1.Controls.Add(Me.tbpMarsSettings)
        Me.tbcControls1.Location = New System.Drawing.Point(0, 22)
        Me.tbcControls1.Name = "tbcControls1"
        Me.tbcControls1.SelectedIndex = 0
        Me.tbcControls1.Size = New System.Drawing.Size(1834, 1087)
        Me.tbcControls1.TabIndex = 0
        '
        'tbpBanks
        '
        Me.tbpBanks.Controls.Add(Me.lstBanks)
        Me.tbpBanks.Controls.Add(Me.cmdBankDelete)
        Me.tbpBanks.Controls.Add(Me.cmdBankRename)
        Me.tbpBanks.Controls.Add(Me.cmdBankNew)
        Me.tbpBanks.Location = New System.Drawing.Point(4, 22)
        Me.tbpBanks.Name = "tbpBanks"
        Me.tbpBanks.Size = New System.Drawing.Size(1826, 1061)
        Me.tbpBanks.TabIndex = 5
        Me.tbpBanks.Text = "Banks"
        Me.tbpBanks.UseVisualStyleBackColor = True
        '
        'lstBanks
        '
        Me.lstBanks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstBanks.FormattingEnabled = True
        Me.lstBanks.Location = New System.Drawing.Point(8, 13)
        Me.lstBanks.Name = "lstBanks"
        Me.lstBanks.Size = New System.Drawing.Size(196, 706)
        Me.lstBanks.TabIndex = 253
        '
        'cmdBankDelete
        '
        Me.cmdBankDelete.Enabled = False
        Me.cmdBankDelete.ForeColor = System.Drawing.Color.White
        Me.cmdBankDelete.Location = New System.Drawing.Point(476, 13)
        Me.cmdBankDelete.Name = "cmdBankDelete"
        Me.cmdBankDelete.Size = New System.Drawing.Size(36, 23)
        Me.cmdBankDelete.TabIndex = 252
        Me.cmdBankDelete.Text = "Del"
        Me.cmdBankDelete.UseVisualStyleBackColor = True
        Me.cmdBankDelete.Visible = False
        '
        'cmdBankRename
        '
        Me.cmdBankRename.Location = New System.Drawing.Point(406, 13)
        Me.cmdBankRename.Name = "cmdBankRename"
        Me.cmdBankRename.Size = New System.Drawing.Size(64, 23)
        Me.cmdBankRename.TabIndex = 251
        Me.cmdBankRename.Text = "Rename"
        Me.cmdBankRename.UseVisualStyleBackColor = True
        Me.cmdBankRename.Visible = False
        '
        'cmdBankNew
        '
        Me.cmdBankNew.Location = New System.Drawing.Point(300, 13)
        Me.cmdBankNew.Name = "cmdBankNew"
        Me.cmdBankNew.Size = New System.Drawing.Size(100, 23)
        Me.cmdBankNew.TabIndex = 250
        Me.cmdBankNew.Text = "New Bank"
        Me.cmdBankNew.UseVisualStyleBackColor = True
        '
        'tbpPresets
        '
        Me.tbpPresets.Controls.Add(Me.pnlMusicplayers)
        Me.tbpPresets.Controls.Add(Me.cmdReloadSongLists)
        Me.tbpPresets.Controls.Add(Me.lstPresetsSongChanges2)
        Me.tbpPresets.Controls.Add(Me.lstPresetsSongChanges1)
        Me.tbpPresets.Controls.Add(Me.cmdPresetsSkip2)
        Me.tbpPresets.Controls.Add(Me.cmdPresetsSkip)
        Me.tbpPresets.Controls.Add(Me.lblPresetsMP3PositionMilli2)
        Me.tbpPresets.Controls.Add(Me.Label40)
        Me.tbpPresets.Controls.Add(Me.lblPresetsMP3Position2)
        Me.tbpPresets.Controls.Add(Me.Label42)
        Me.tbpPresets.Controls.Add(Me.lblPresetsMP3Duration2)
        Me.tbpPresets.Controls.Add(Me.cmdPresetsStop2)
        Me.tbpPresets.Controls.Add(Me.cmdPresetsPlay2)
        Me.tbpPresets.Controls.Add(Me.trkPresetsVolume2)
        Me.tbpPresets.Controls.Add(Me.lstPresetsSongs2)
        Me.tbpPresets.Controls.Add(Me.lblPresetsMP3PositionMilli)
        Me.tbpPresets.Controls.Add(Me.Label45)
        Me.tbpPresets.Controls.Add(Me.lblPresetsMP3Position)
        Me.tbpPresets.Controls.Add(Me.Label47)
        Me.tbpPresets.Controls.Add(Me.lblPresetsMP3Duration)
        Me.tbpPresets.Controls.Add(Me.cmdPresetsStop)
        Me.tbpPresets.Controls.Add(Me.cmdPresetsPlay)
        Me.tbpPresets.Controls.Add(Me.lstPresetsSongs)
        Me.tbpPresets.Controls.Add(Me.trkPresetsVolume)
        Me.tbpPresets.Controls.Add(Me.cmdReloadPresetLocations)
        Me.tbpPresets.Controls.Add(Me.cmdPresetP7)
        Me.tbpPresets.Controls.Add(Me.cmdPresetP8)
        Me.tbpPresets.Controls.Add(Me.cmdPresetP5)
        Me.tbpPresets.Controls.Add(Me.cmdPresetP6)
        Me.tbpPresets.Controls.Add(Me.cmdPresetP3)
        Me.tbpPresets.Controls.Add(Me.cmdPresetP4)
        Me.tbpPresets.Controls.Add(Me.cmdPresetsBlackoutAllInstant)
        Me.tbpPresets.Controls.Add(Me.cmdPresetsBlackoutAllTimer)
        Me.tbpPresets.Controls.Add(Me.cmdPresetP1)
        Me.tbpPresets.Controls.Add(Me.cmdPresetP2)
        Me.tbpPresets.Location = New System.Drawing.Point(4, 22)
        Me.tbpPresets.Name = "tbpPresets"
        Me.tbpPresets.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPresets.Size = New System.Drawing.Size(1826, 1061)
        Me.tbpPresets.TabIndex = 1
        Me.tbpPresets.Text = "Scenes"
        Me.tbpPresets.UseVisualStyleBackColor = True
        '
        'pnlMusicplayers
        '
        Me.pnlMusicplayers.Controls.Add(Me.CtrlMusicPlayer1)
        Me.pnlMusicplayers.Location = New System.Drawing.Point(8, 891)
        Me.pnlMusicplayers.Name = "pnlMusicplayers"
        Me.pnlMusicplayers.Size = New System.Drawing.Size(601, 163)
        Me.pnlMusicplayers.TabIndex = 629
        '
        'CtrlMusicPlayer1
        '
        Me.CtrlMusicPlayer1.BackColor = System.Drawing.Color.Black
        Me.CtrlMusicPlayer1.Location = New System.Drawing.Point(3, 3)
        Me.CtrlMusicPlayer1.Name = "CtrlMusicPlayer1"
        Me.CtrlMusicPlayer1.Size = New System.Drawing.Size(595, 23)
        Me.CtrlMusicPlayer1.TabIndex = 0
        '
        'cmdReloadSongLists
        '
        Me.cmdReloadSongLists.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdReloadSongLists.Location = New System.Drawing.Point(1455, 862)
        Me.cmdReloadSongLists.Name = "cmdReloadSongLists"
        Me.cmdReloadSongLists.Size = New System.Drawing.Size(116, 23)
        Me.cmdReloadSongLists.TabIndex = 628
        Me.cmdReloadSongLists.Text = "Reload Song Lists"
        Me.cmdReloadSongLists.UseVisualStyleBackColor = True
        '
        'lstPresetsSongChanges2
        '
        Me.lstPresetsSongChanges2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstPresetsSongChanges2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lstPresetsSongChanges2.FullRowSelect = True
        Me.lstPresetsSongChanges2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstPresetsSongChanges2.HideSelection = False
        Me.lstPresetsSongChanges2.Location = New System.Drawing.Point(1143, 686)
        Me.lstPresetsSongChanges2.MultiSelect = False
        Me.lstPresetsSongChanges2.Name = "lstPresetsSongChanges2"
        Me.lstPresetsSongChanges2.Size = New System.Drawing.Size(306, 199)
        Me.lstPresetsSongChanges2.TabIndex = 627
        Me.lstPresetsSongChanges2.UseCompatibleStateImageBehavior = False
        Me.lstPresetsSongChanges2.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Time"
        Me.ColumnHeader5.Width = 40
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Scene"
        Me.ColumnHeader6.Width = 180
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "In"
        Me.ColumnHeader7.Width = 40
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Out"
        Me.ColumnHeader8.Width = 40
        '
        'lstPresetsSongChanges1
        '
        Me.lstPresetsSongChanges1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstPresetsSongChanges1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lstPresetsSongChanges1.FullRowSelect = True
        Me.lstPresetsSongChanges1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstPresetsSongChanges1.HideSelection = False
        Me.lstPresetsSongChanges1.Location = New System.Drawing.Point(422, 686)
        Me.lstPresetsSongChanges1.MultiSelect = False
        Me.lstPresetsSongChanges1.Name = "lstPresetsSongChanges1"
        Me.lstPresetsSongChanges1.Size = New System.Drawing.Size(305, 199)
        Me.lstPresetsSongChanges1.TabIndex = 626
        Me.lstPresetsSongChanges1.UseCompatibleStateImageBehavior = False
        Me.lstPresetsSongChanges1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Time"
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Scene"
        Me.ColumnHeader2.Width = 180
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "In"
        Me.ColumnHeader3.Width = 40
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Out"
        Me.ColumnHeader4.Width = 40
        '
        'cmdPresetsSkip2
        '
        Me.cmdPresetsSkip2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetsSkip2.Location = New System.Drawing.Point(1022, 776)
        Me.cmdPresetsSkip2.Name = "cmdPresetsSkip2"
        Me.cmdPresetsSkip2.Size = New System.Drawing.Size(37, 23)
        Me.cmdPresetsSkip2.TabIndex = 624
        Me.cmdPresetsSkip2.Text = "Skip"
        Me.cmdPresetsSkip2.UseVisualStyleBackColor = True
        '
        'cmdPresetsSkip
        '
        Me.cmdPresetsSkip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetsSkip.Location = New System.Drawing.Point(297, 775)
        Me.cmdPresetsSkip.Name = "cmdPresetsSkip"
        Me.cmdPresetsSkip.Size = New System.Drawing.Size(37, 23)
        Me.cmdPresetsSkip.TabIndex = 623
        Me.cmdPresetsSkip.Text = "Skip"
        Me.cmdPresetsSkip.UseVisualStyleBackColor = True
        '
        'lblPresetsMP3PositionMilli2
        '
        Me.lblPresetsMP3PositionMilli2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPresetsMP3PositionMilli2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPresetsMP3PositionMilli2.ForeColor = System.Drawing.Color.Lime
        Me.lblPresetsMP3PositionMilli2.Location = New System.Drawing.Point(1018, 836)
        Me.lblPresetsMP3PositionMilli2.Name = "lblPresetsMP3PositionMilli2"
        Me.lblPresetsMP3PositionMilli2.Size = New System.Drawing.Size(71, 20)
        Me.lblPresetsMP3PositionMilli2.TabIndex = 621
        Me.lblPresetsMP3PositionMilli2.Text = "000000"
        '
        'Label40
        '
        Me.Label40.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.Lime
        Me.Label40.Location = New System.Drawing.Point(1019, 800)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(47, 13)
        Me.Label40.TabIndex = 620
        Me.Label40.Text = "Position:"
        '
        'lblPresetsMP3Position2
        '
        Me.lblPresetsMP3Position2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPresetsMP3Position2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPresetsMP3Position2.ForeColor = System.Drawing.Color.Lime
        Me.lblPresetsMP3Position2.Location = New System.Drawing.Point(1018, 816)
        Me.lblPresetsMP3Position2.Name = "lblPresetsMP3Position2"
        Me.lblPresetsMP3Position2.Size = New System.Drawing.Size(71, 20)
        Me.lblPresetsMP3Position2.TabIndex = 619
        Me.lblPresetsMP3Position2.Text = "00:00.00"
        '
        'Label42
        '
        Me.Label42.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.Lime
        Me.Label42.Location = New System.Drawing.Point(1019, 740)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(50, 13)
        Me.Label42.TabIndex = 618
        Me.Label42.Text = "Duration:"
        '
        'lblPresetsMP3Duration2
        '
        Me.lblPresetsMP3Duration2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPresetsMP3Duration2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPresetsMP3Duration2.ForeColor = System.Drawing.Color.Lime
        Me.lblPresetsMP3Duration2.Location = New System.Drawing.Point(1018, 756)
        Me.lblPresetsMP3Duration2.Name = "lblPresetsMP3Duration2"
        Me.lblPresetsMP3Duration2.Size = New System.Drawing.Size(71, 20)
        Me.lblPresetsMP3Duration2.TabIndex = 617
        Me.lblPresetsMP3Duration2.Text = "00:00:00"
        '
        'cmdPresetsStop2
        '
        Me.cmdPresetsStop2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetsStop2.Location = New System.Drawing.Point(1022, 716)
        Me.cmdPresetsStop2.Name = "cmdPresetsStop2"
        Me.cmdPresetsStop2.Size = New System.Drawing.Size(75, 23)
        Me.cmdPresetsStop2.TabIndex = 616
        Me.cmdPresetsStop2.Text = "Stop"
        Me.cmdPresetsStop2.UseVisualStyleBackColor = True
        '
        'cmdPresetsPlay2
        '
        Me.cmdPresetsPlay2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetsPlay2.Location = New System.Drawing.Point(1022, 687)
        Me.cmdPresetsPlay2.Name = "cmdPresetsPlay2"
        Me.cmdPresetsPlay2.Size = New System.Drawing.Size(75, 23)
        Me.cmdPresetsPlay2.TabIndex = 615
        Me.cmdPresetsPlay2.Text = "Play"
        Me.cmdPresetsPlay2.UseVisualStyleBackColor = True
        '
        'trkPresetsVolume2
        '
        Me.trkPresetsVolume2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.trkPresetsVolume2.Location = New System.Drawing.Point(1092, 756)
        Me.trkPresetsVolume2.Maximum = 100
        Me.trkPresetsVolume2.Name = "trkPresetsVolume2"
        Me.trkPresetsVolume2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trkPresetsVolume2.Size = New System.Drawing.Size(45, 71)
        Me.trkPresetsVolume2.TabIndex = 622
        Me.trkPresetsVolume2.TickFrequency = 0
        Me.trkPresetsVolume2.Value = 100
        '
        'lstPresetsSongs2
        '
        Me.lstPresetsSongs2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstPresetsSongs2.FormattingEnabled = True
        Me.lstPresetsSongs2.Location = New System.Drawing.Point(733, 687)
        Me.lstPresetsSongs2.Name = "lstPresetsSongs2"
        Me.lstPresetsSongs2.Size = New System.Drawing.Size(283, 199)
        Me.lstPresetsSongs2.Sorted = True
        Me.lstPresetsSongs2.TabIndex = 614
        '
        'lblPresetsMP3PositionMilli
        '
        Me.lblPresetsMP3PositionMilli.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPresetsMP3PositionMilli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPresetsMP3PositionMilli.ForeColor = System.Drawing.Color.Lime
        Me.lblPresetsMP3PositionMilli.Location = New System.Drawing.Point(293, 836)
        Me.lblPresetsMP3PositionMilli.Name = "lblPresetsMP3PositionMilli"
        Me.lblPresetsMP3PositionMilli.Size = New System.Drawing.Size(71, 20)
        Me.lblPresetsMP3PositionMilli.TabIndex = 611
        Me.lblPresetsMP3PositionMilli.Text = "000000"
        '
        'Label45
        '
        Me.Label45.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.Lime
        Me.Label45.Location = New System.Drawing.Point(294, 800)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(47, 13)
        Me.Label45.TabIndex = 610
        Me.Label45.Text = "Position:"
        '
        'lblPresetsMP3Position
        '
        Me.lblPresetsMP3Position.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPresetsMP3Position.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPresetsMP3Position.ForeColor = System.Drawing.Color.Lime
        Me.lblPresetsMP3Position.Location = New System.Drawing.Point(293, 816)
        Me.lblPresetsMP3Position.Name = "lblPresetsMP3Position"
        Me.lblPresetsMP3Position.Size = New System.Drawing.Size(71, 20)
        Me.lblPresetsMP3Position.TabIndex = 609
        Me.lblPresetsMP3Position.Text = "00:00.00"
        '
        'Label47
        '
        Me.Label47.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.Lime
        Me.Label47.Location = New System.Drawing.Point(294, 740)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(50, 13)
        Me.Label47.TabIndex = 608
        Me.Label47.Text = "Duration:"
        '
        'lblPresetsMP3Duration
        '
        Me.lblPresetsMP3Duration.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblPresetsMP3Duration.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPresetsMP3Duration.ForeColor = System.Drawing.Color.Lime
        Me.lblPresetsMP3Duration.Location = New System.Drawing.Point(293, 756)
        Me.lblPresetsMP3Duration.Name = "lblPresetsMP3Duration"
        Me.lblPresetsMP3Duration.Size = New System.Drawing.Size(71, 20)
        Me.lblPresetsMP3Duration.TabIndex = 607
        Me.lblPresetsMP3Duration.Text = "00:00:00"
        '
        'cmdPresetsStop
        '
        Me.cmdPresetsStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetsStop.Location = New System.Drawing.Point(297, 716)
        Me.cmdPresetsStop.Name = "cmdPresetsStop"
        Me.cmdPresetsStop.Size = New System.Drawing.Size(75, 23)
        Me.cmdPresetsStop.TabIndex = 606
        Me.cmdPresetsStop.Text = "Stop"
        Me.cmdPresetsStop.UseVisualStyleBackColor = True
        '
        'cmdPresetsPlay
        '
        Me.cmdPresetsPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetsPlay.Location = New System.Drawing.Point(297, 687)
        Me.cmdPresetsPlay.Name = "cmdPresetsPlay"
        Me.cmdPresetsPlay.Size = New System.Drawing.Size(75, 23)
        Me.cmdPresetsPlay.TabIndex = 605
        Me.cmdPresetsPlay.Text = "Play"
        Me.cmdPresetsPlay.UseVisualStyleBackColor = True
        '
        'lstPresetsSongs
        '
        Me.lstPresetsSongs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstPresetsSongs.FormattingEnabled = True
        Me.lstPresetsSongs.Location = New System.Drawing.Point(8, 687)
        Me.lstPresetsSongs.Name = "lstPresetsSongs"
        Me.lstPresetsSongs.Size = New System.Drawing.Size(283, 199)
        Me.lstPresetsSongs.Sorted = True
        Me.lstPresetsSongs.TabIndex = 604
        '
        'trkPresetsVolume
        '
        Me.trkPresetsVolume.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.trkPresetsVolume.Location = New System.Drawing.Point(367, 756)
        Me.trkPresetsVolume.Maximum = 100
        Me.trkPresetsVolume.Name = "trkPresetsVolume"
        Me.trkPresetsVolume.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trkPresetsVolume.Size = New System.Drawing.Size(45, 71)
        Me.trkPresetsVolume.TabIndex = 613
        Me.trkPresetsVolume.TickFrequency = 0
        Me.trkPresetsVolume.Value = 100
        '
        'cmdReloadPresetLocations
        '
        Me.cmdReloadPresetLocations.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReloadPresetLocations.Location = New System.Drawing.Point(1730, 687)
        Me.cmdReloadPresetLocations.Name = "cmdReloadPresetLocations"
        Me.cmdReloadPresetLocations.Size = New System.Drawing.Size(90, 35)
        Me.cmdReloadPresetLocations.TabIndex = 603
        Me.cmdReloadPresetLocations.Text = "Reload Locations"
        Me.cmdReloadPresetLocations.UseVisualStyleBackColor = True
        '
        'cmdPresetP7
        '
        Me.cmdPresetP7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetP7.Location = New System.Drawing.Point(1730, 95)
        Me.cmdPresetP7.Name = "cmdPresetP7"
        Me.cmdPresetP7.Size = New System.Drawing.Size(39, 23)
        Me.cmdPresetP7.TabIndex = 597
        Me.cmdPresetP7.Text = "P7"
        Me.cmdPresetP7.UseVisualStyleBackColor = True
        Me.cmdPresetP7.Visible = False
        '
        'cmdPresetP8
        '
        Me.cmdPresetP8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetP8.Location = New System.Drawing.Point(1781, 95)
        Me.cmdPresetP8.Name = "cmdPresetP8"
        Me.cmdPresetP8.Size = New System.Drawing.Size(39, 23)
        Me.cmdPresetP8.TabIndex = 596
        Me.cmdPresetP8.Text = "P8"
        Me.cmdPresetP8.UseVisualStyleBackColor = True
        Me.cmdPresetP8.Visible = False
        '
        'cmdPresetP5
        '
        Me.cmdPresetP5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetP5.Location = New System.Drawing.Point(1730, 66)
        Me.cmdPresetP5.Name = "cmdPresetP5"
        Me.cmdPresetP5.Size = New System.Drawing.Size(39, 23)
        Me.cmdPresetP5.TabIndex = 595
        Me.cmdPresetP5.Text = "P5"
        Me.cmdPresetP5.UseVisualStyleBackColor = True
        '
        'cmdPresetP6
        '
        Me.cmdPresetP6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetP6.Location = New System.Drawing.Point(1781, 66)
        Me.cmdPresetP6.Name = "cmdPresetP6"
        Me.cmdPresetP6.Size = New System.Drawing.Size(39, 23)
        Me.cmdPresetP6.TabIndex = 594
        Me.cmdPresetP6.Text = "P6"
        Me.cmdPresetP6.UseVisualStyleBackColor = True
        '
        'cmdPresetP3
        '
        Me.cmdPresetP3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetP3.Location = New System.Drawing.Point(1730, 37)
        Me.cmdPresetP3.Name = "cmdPresetP3"
        Me.cmdPresetP3.Size = New System.Drawing.Size(39, 23)
        Me.cmdPresetP3.TabIndex = 593
        Me.cmdPresetP3.Text = "P3"
        Me.cmdPresetP3.UseVisualStyleBackColor = True
        '
        'cmdPresetP4
        '
        Me.cmdPresetP4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetP4.Location = New System.Drawing.Point(1781, 37)
        Me.cmdPresetP4.Name = "cmdPresetP4"
        Me.cmdPresetP4.Size = New System.Drawing.Size(39, 23)
        Me.cmdPresetP4.TabIndex = 592
        Me.cmdPresetP4.Text = "P4"
        Me.cmdPresetP4.UseVisualStyleBackColor = True
        '
        'cmdPresetsBlackoutAllInstant
        '
        Me.cmdPresetsBlackoutAllInstant.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetsBlackoutAllInstant.Location = New System.Drawing.Point(1730, 189)
        Me.cmdPresetsBlackoutAllInstant.Name = "cmdPresetsBlackoutAllInstant"
        Me.cmdPresetsBlackoutAllInstant.Size = New System.Drawing.Size(90, 45)
        Me.cmdPresetsBlackoutAllInstant.TabIndex = 571
        Me.cmdPresetsBlackoutAllInstant.Text = "Blackout All Instant"
        Me.cmdPresetsBlackoutAllInstant.UseVisualStyleBackColor = True
        '
        'cmdPresetsBlackoutAllTimer
        '
        Me.cmdPresetsBlackoutAllTimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetsBlackoutAllTimer.Location = New System.Drawing.Point(1730, 138)
        Me.cmdPresetsBlackoutAllTimer.Name = "cmdPresetsBlackoutAllTimer"
        Me.cmdPresetsBlackoutAllTimer.Size = New System.Drawing.Size(90, 45)
        Me.cmdPresetsBlackoutAllTimer.TabIndex = 570
        Me.cmdPresetsBlackoutAllTimer.Text = "Blackout All Timer"
        Me.cmdPresetsBlackoutAllTimer.UseVisualStyleBackColor = True
        '
        'cmdPresetP1
        '
        Me.cmdPresetP1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetP1.BackColor = System.Drawing.Color.Red
        Me.cmdPresetP1.ForeColor = System.Drawing.Color.White
        Me.cmdPresetP1.Location = New System.Drawing.Point(1730, 8)
        Me.cmdPresetP1.Name = "cmdPresetP1"
        Me.cmdPresetP1.Size = New System.Drawing.Size(39, 23)
        Me.cmdPresetP1.TabIndex = 569
        Me.cmdPresetP1.Text = "P1"
        Me.cmdPresetP1.UseVisualStyleBackColor = False
        '
        'cmdPresetP2
        '
        Me.cmdPresetP2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetP2.Location = New System.Drawing.Point(1781, 8)
        Me.cmdPresetP2.Name = "cmdPresetP2"
        Me.cmdPresetP2.Size = New System.Drawing.Size(39, 23)
        Me.cmdPresetP2.TabIndex = 568
        Me.cmdPresetP2.Text = "P2"
        Me.cmdPresetP2.UseVisualStyleBackColor = True
        '
        'tbpMusic
        '
        Me.tbpMusic.Controls.Add(Me.lstMusicSongChanges2)
        Me.tbpMusic.Controls.Add(Me.lstMusicSongChanges1)
        Me.tbpMusic.Controls.Add(Me.cmdEditUpdate)
        Me.tbpMusic.Controls.Add(Me.txtEditTime)
        Me.tbpMusic.Controls.Add(Me.Label25)
        Me.tbpMusic.Controls.Add(Me.numFadeIn)
        Me.tbpMusic.Controls.Add(Me.lblFadeIn)
        Me.tbpMusic.Controls.Add(Me.numFadeOut)
        Me.tbpMusic.Controls.Add(Me.lblFadeOut)
        Me.tbpMusic.Controls.Add(Me.vSongEdit)
        Me.tbpMusic.Controls.Add(Me.lstSongEditPresets)
        Me.tbpMusic.Controls.Add(Me.cmdEditSongCopyNew)
        Me.tbpMusic.Controls.Add(Me.cmdEditSongSave)
        Me.tbpMusic.Controls.Add(Me.cmdCreatelink)
        Me.tbpMusic.Controls.Add(Me.Label20)
        Me.tbpMusic.Controls.Add(Me.lbleditRemaining)
        Me.tbpMusic.Controls.Add(Me.lbleditPositionMilli)
        Me.tbpMusic.Controls.Add(Me.lbleditposition)
        Me.tbpMusic.Controls.Add(Me.cmdEditStop)
        Me.tbpMusic.Controls.Add(Me.cmdEditPlay)
        Me.tbpMusic.Controls.Add(Me.chkEnableSongEdit)
        Me.tbpMusic.Controls.Add(Me.cmdMusicSkip2)
        Me.tbpMusic.Controls.Add(Me.cmdMusicSkip)
        Me.tbpMusic.Controls.Add(Me.lblMusicMP3PositionMilli2)
        Me.tbpMusic.Controls.Add(Me.Label9)
        Me.tbpMusic.Controls.Add(Me.lblMusicMP3Position2)
        Me.tbpMusic.Controls.Add(Me.Label12)
        Me.tbpMusic.Controls.Add(Me.lblMusicMP3Duration2)
        Me.tbpMusic.Controls.Add(Me.cmdMusicStop2)
        Me.tbpMusic.Controls.Add(Me.cmdMusicPlay2)
        Me.tbpMusic.Controls.Add(Me.trkMusicVolume2)
        Me.tbpMusic.Controls.Add(Me.lstMusicSongs2)
        Me.tbpMusic.Controls.Add(Me.lblMusicMP3PositionMilli)
        Me.tbpMusic.Controls.Add(Me.Label4)
        Me.tbpMusic.Controls.Add(Me.lblMusicMP3Position)
        Me.tbpMusic.Controls.Add(Me.Label6)
        Me.tbpMusic.Controls.Add(Me.lblMusicMP3Duration)
        Me.tbpMusic.Controls.Add(Me.cmdMusicStop)
        Me.tbpMusic.Controls.Add(Me.cmdMusicPlay)
        Me.tbpMusic.Controls.Add(Me.lstMusicSongs)
        Me.tbpMusic.Controls.Add(Me.trkMusicVolume)
        Me.tbpMusic.Location = New System.Drawing.Point(4, 22)
        Me.tbpMusic.Name = "tbpMusic"
        Me.tbpMusic.Size = New System.Drawing.Size(1826, 1061)
        Me.tbpMusic.TabIndex = 2
        Me.tbpMusic.Text = "Music Editor"
        Me.tbpMusic.UseVisualStyleBackColor = True
        '
        'lstMusicSongChanges2
        '
        Me.lstMusicSongChanges2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader24})
        Me.lstMusicSongChanges2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstMusicSongChanges2.HideSelection = False
        Me.lstMusicSongChanges2.Location = New System.Drawing.Point(1456, 8)
        Me.lstMusicSongChanges2.MultiSelect = False
        Me.lstMusicSongChanges2.Name = "lstMusicSongChanges2"
        Me.lstMusicSongChanges2.Size = New System.Drawing.Size(231, 201)
        Me.lstMusicSongChanges2.TabIndex = 628
        Me.lstMusicSongChanges2.UseCompatibleStateImageBehavior = False
        Me.lstMusicSongChanges2.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Time"
        Me.ColumnHeader21.Width = 40
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Scene"
        Me.ColumnHeader22.Width = 90
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "In"
        Me.ColumnHeader23.Width = 40
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "Out"
        Me.ColumnHeader24.Width = 40
        '
        'lstMusicSongChanges1
        '
        Me.lstMusicSongChanges1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstMusicSongChanges1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12})
        Me.lstMusicSongChanges1.FullRowSelect = True
        Me.lstMusicSongChanges1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstMusicSongChanges1.HideSelection = False
        Me.lstMusicSongChanges1.Location = New System.Drawing.Point(448, 330)
        Me.lstMusicSongChanges1.MultiSelect = False
        Me.lstMusicSongChanges1.Name = "lstMusicSongChanges1"
        Me.lstMusicSongChanges1.Size = New System.Drawing.Size(384, 540)
        Me.lstMusicSongChanges1.TabIndex = 627
        Me.lstMusicSongChanges1.UseCompatibleStateImageBehavior = False
        Me.lstMusicSongChanges1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Time"
        Me.ColumnHeader9.Width = 50
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Scene"
        Me.ColumnHeader10.Width = 240
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "In"
        Me.ColumnHeader11.Width = 40
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Out"
        Me.ColumnHeader12.Width = 40
        '
        'cmdEditUpdate
        '
        Me.cmdEditUpdate.Location = New System.Drawing.Point(367, 584)
        Me.cmdEditUpdate.Name = "cmdEditUpdate"
        Me.cmdEditUpdate.Size = New System.Drawing.Size(75, 23)
        Me.cmdEditUpdate.TabIndex = 334
        Me.cmdEditUpdate.Text = "Update"
        Me.cmdEditUpdate.UseVisualStyleBackColor = True
        '
        'txtEditTime
        '
        Me.txtEditTime.Location = New System.Drawing.Point(367, 551)
        Me.txtEditTime.Name = "txtEditTime"
        Me.txtEditTime.Size = New System.Drawing.Size(75, 20)
        Me.txtEditTime.TabIndex = 333
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.Lime
        Me.Label25.Location = New System.Drawing.Point(364, 532)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(33, 13)
        Me.Label25.TabIndex = 332
        Me.Label25.Text = "Time:"
        '
        'numFadeIn
        '
        Me.numFadeIn.Location = New System.Drawing.Point(367, 449)
        Me.numFadeIn.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numFadeIn.Name = "numFadeIn"
        Me.numFadeIn.Size = New System.Drawing.Size(75, 20)
        Me.numFadeIn.TabIndex = 330
        '
        'lblFadeIn
        '
        Me.lblFadeIn.AutoSize = True
        Me.lblFadeIn.ForeColor = System.Drawing.Color.Lime
        Me.lblFadeIn.Location = New System.Drawing.Point(364, 430)
        Me.lblFadeIn.Name = "lblFadeIn"
        Me.lblFadeIn.Size = New System.Drawing.Size(46, 13)
        Me.lblFadeIn.TabIndex = 329
        Me.lblFadeIn.Text = "Fade In:"
        '
        'numFadeOut
        '
        Me.numFadeOut.Location = New System.Drawing.Point(367, 499)
        Me.numFadeOut.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numFadeOut.Name = "numFadeOut"
        Me.numFadeOut.Size = New System.Drawing.Size(75, 20)
        Me.numFadeOut.TabIndex = 328
        '
        'lblFadeOut
        '
        Me.lblFadeOut.AutoSize = True
        Me.lblFadeOut.ForeColor = System.Drawing.Color.Lime
        Me.lblFadeOut.Location = New System.Drawing.Point(364, 480)
        Me.lblFadeOut.Name = "lblFadeOut"
        Me.lblFadeOut.Size = New System.Drawing.Size(54, 13)
        Me.lblFadeOut.TabIndex = 327
        Me.lblFadeOut.Text = "Fade Out:"
        '
        'vSongEdit
        '
        Me.vSongEdit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vSongEdit.BackColor = System.Drawing.Color.White
        Me.vSongEdit.BulletColor = System.Drawing.Color.Red
        Me.vSongEdit.FillColor = System.Drawing.Color.Black
        Me.vSongEdit.Location = New System.Drawing.Point(8, 233)
        Me.vSongEdit.Maximum = 5000000
        Me.vSongEdit.Name = "vSongEdit"
        Me.vSongEdit.Size = New System.Drawing.Size(1804, 42)
        Me.vSongEdit.TabIndex = 335
        '
        'lstSongEditPresets
        '
        Me.lstSongEditPresets.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstSongEditPresets.ContextMenuStrip = Me.ctxDramaChangesActions
        Me.lstSongEditPresets.FormattingEnabled = True
        Me.lstSongEditPresets.Location = New System.Drawing.Point(76, 330)
        Me.lstSongEditPresets.Name = "lstSongEditPresets"
        Me.lstSongEditPresets.Size = New System.Drawing.Size(268, 550)
        Me.lstSongEditPresets.TabIndex = 325
        '
        'ctxDramaChangesActions
        '
        Me.ctxDramaChangesActions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxDramaEditChannels, Me.ctxDramaSaveScene, Me.ctxDramaDuplicateScene, Me.ctxDramaRenameScene})
        Me.ctxDramaChangesActions.Name = "ctxPresetLabelActions"
        Me.ctxDramaChangesActions.Size = New System.Drawing.Size(227, 92)
        '
        'ctxDramaEditChannels
        '
        Me.ctxDramaEditChannels.Name = "ctxDramaEditChannels"
        Me.ctxDramaEditChannels.Size = New System.Drawing.Size(226, 22)
        Me.ctxDramaEditChannels.Text = "Edit Channels"
        '
        'ctxDramaSaveScene
        '
        Me.ctxDramaSaveScene.Name = "ctxDramaSaveScene"
        Me.ctxDramaSaveScene.Size = New System.Drawing.Size(226, 22)
        Me.ctxDramaSaveScene.Text = "Save Scene to File"
        '
        'ctxDramaDuplicateScene
        '
        Me.ctxDramaDuplicateScene.Name = "ctxDramaDuplicateScene"
        Me.ctxDramaDuplicateScene.Size = New System.Drawing.Size(226, 22)
        Me.ctxDramaDuplicateScene.Text = "Duplicate Scene"
        '
        'ctxDramaRenameScene
        '
        Me.ctxDramaRenameScene.Name = "ctxDramaRenameScene"
        Me.ctxDramaRenameScene.Size = New System.Drawing.Size(226, 22)
        Me.ctxDramaRenameScene.Text = "Rename Scene (not working)"
        '
        'cmdEditSongCopyNew
        '
        Me.cmdEditSongCopyNew.Location = New System.Drawing.Point(367, 360)
        Me.cmdEditSongCopyNew.Name = "cmdEditSongCopyNew"
        Me.cmdEditSongCopyNew.Size = New System.Drawing.Size(75, 52)
        Me.cmdEditSongCopyNew.TabIndex = 324
        Me.cmdEditSongCopyNew.Text = "Copy Scene"
        Me.cmdEditSongCopyNew.UseVisualStyleBackColor = True
        '
        'cmdEditSongSave
        '
        Me.cmdEditSongSave.Location = New System.Drawing.Point(367, 631)
        Me.cmdEditSongSave.Name = "cmdEditSongSave"
        Me.cmdEditSongSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdEditSongSave.TabIndex = 323
        Me.cmdEditSongSave.Text = "Save"
        Me.cmdEditSongSave.UseVisualStyleBackColor = True
        '
        'cmdCreatelink
        '
        Me.cmdCreatelink.Location = New System.Drawing.Point(367, 331)
        Me.cmdCreatelink.Name = "cmdCreatelink"
        Me.cmdCreatelink.Size = New System.Drawing.Size(75, 23)
        Me.cmdCreatelink.TabIndex = 322
        Me.cmdCreatelink.Text = "Create link"
        Me.cmdCreatelink.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Lime
        Me.Label20.Location = New System.Drawing.Point(5, 386)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(60, 13)
        Me.Label20.TabIndex = 321
        Me.Label20.Text = "Remaining:"
        Me.Label20.Visible = False
        '
        'lbleditRemaining
        '
        Me.lbleditRemaining.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbleditRemaining.ForeColor = System.Drawing.Color.Lime
        Me.lbleditRemaining.Location = New System.Drawing.Point(4, 402)
        Me.lbleditRemaining.Name = "lbleditRemaining"
        Me.lbleditRemaining.Size = New System.Drawing.Size(71, 20)
        Me.lbleditRemaining.TabIndex = 320
        Me.lbleditRemaining.Text = "00:00:00"
        Me.lbleditRemaining.Visible = False
        '
        'lbleditPositionMilli
        '
        Me.lbleditPositionMilli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbleditPositionMilli.ForeColor = System.Drawing.Color.Lime
        Me.lbleditPositionMilli.Location = New System.Drawing.Point(8, 353)
        Me.lbleditPositionMilli.Name = "lbleditPositionMilli"
        Me.lbleditPositionMilli.Size = New System.Drawing.Size(71, 20)
        Me.lbleditPositionMilli.TabIndex = 319
        Me.lbleditPositionMilli.Text = "000000"
        '
        'lbleditposition
        '
        Me.lbleditposition.AutoSize = True
        Me.lbleditposition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbleditposition.ForeColor = System.Drawing.Color.Lime
        Me.lbleditposition.Location = New System.Drawing.Point(9, 337)
        Me.lbleditposition.Name = "lbleditposition"
        Me.lbleditposition.Size = New System.Drawing.Size(47, 13)
        Me.lbleditposition.TabIndex = 318
        Me.lbleditposition.Text = "Position:"
        '
        'cmdEditStop
        '
        Me.cmdEditStop.Location = New System.Drawing.Point(838, 330)
        Me.cmdEditStop.Name = "cmdEditStop"
        Me.cmdEditStop.Size = New System.Drawing.Size(67, 43)
        Me.cmdEditStop.TabIndex = 317
        Me.cmdEditStop.Text = "Stop"
        Me.cmdEditStop.UseVisualStyleBackColor = True
        '
        'cmdEditPlay
        '
        Me.cmdEditPlay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdEditPlay.BackColor = System.Drawing.Color.Maroon
        Me.cmdEditPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdEditPlay.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEditPlay.Location = New System.Drawing.Point(8, 281)
        Me.cmdEditPlay.Name = "cmdEditPlay"
        Me.cmdEditPlay.Size = New System.Drawing.Size(1804, 43)
        Me.cmdEditPlay.TabIndex = 316
        Me.cmdEditPlay.Text = "Play"
        Me.cmdEditPlay.UseVisualStyleBackColor = False
        '
        'chkEnableSongEdit
        '
        Me.chkEnableSongEdit.AutoSize = True
        Me.chkEnableSongEdit.ForeColor = System.Drawing.Color.Lime
        Me.chkEnableSongEdit.Location = New System.Drawing.Point(672, 14)
        Me.chkEnableSongEdit.Name = "chkEnableSongEdit"
        Me.chkEnableSongEdit.Size = New System.Drawing.Size(94, 17)
        Me.chkEnableSongEdit.TabIndex = 311
        Me.chkEnableSongEdit.Text = "Enable Editing"
        Me.chkEnableSongEdit.UseVisualStyleBackColor = True
        Me.chkEnableSongEdit.Visible = False
        '
        'cmdMusicSkip2
        '
        Me.cmdMusicSkip2.Location = New System.Drawing.Point(1331, 112)
        Me.cmdMusicSkip2.Name = "cmdMusicSkip2"
        Me.cmdMusicSkip2.Size = New System.Drawing.Size(37, 23)
        Me.cmdMusicSkip2.TabIndex = 309
        Me.cmdMusicSkip2.Text = "Skip"
        Me.cmdMusicSkip2.UseVisualStyleBackColor = True
        '
        'cmdMusicSkip
        '
        Me.cmdMusicSkip.Location = New System.Drawing.Point(297, 109)
        Me.cmdMusicSkip.Name = "cmdMusicSkip"
        Me.cmdMusicSkip.Size = New System.Drawing.Size(37, 23)
        Me.cmdMusicSkip.TabIndex = 308
        Me.cmdMusicSkip.Text = "Skip"
        Me.cmdMusicSkip.UseVisualStyleBackColor = True
        '
        'lblMusicMP3PositionMilli2
        '
        Me.lblMusicMP3PositionMilli2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMusicMP3PositionMilli2.ForeColor = System.Drawing.Color.Lime
        Me.lblMusicMP3PositionMilli2.Location = New System.Drawing.Point(1327, 172)
        Me.lblMusicMP3PositionMilli2.Name = "lblMusicMP3PositionMilli2"
        Me.lblMusicMP3PositionMilli2.Size = New System.Drawing.Size(71, 20)
        Me.lblMusicMP3PositionMilli2.TabIndex = 306
        Me.lblMusicMP3PositionMilli2.Text = "000000"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Lime
        Me.Label9.Location = New System.Drawing.Point(1328, 136)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 305
        Me.Label9.Text = "Position:"
        '
        'lblMusicMP3Position2
        '
        Me.lblMusicMP3Position2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMusicMP3Position2.ForeColor = System.Drawing.Color.Lime
        Me.lblMusicMP3Position2.Location = New System.Drawing.Point(1327, 152)
        Me.lblMusicMP3Position2.Name = "lblMusicMP3Position2"
        Me.lblMusicMP3Position2.Size = New System.Drawing.Size(71, 20)
        Me.lblMusicMP3Position2.TabIndex = 304
        Me.lblMusicMP3Position2.Text = "00:00.00"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Lime
        Me.Label12.Location = New System.Drawing.Point(1328, 76)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 303
        Me.Label12.Text = "Duration:"
        '
        'lblMusicMP3Duration2
        '
        Me.lblMusicMP3Duration2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMusicMP3Duration2.ForeColor = System.Drawing.Color.Lime
        Me.lblMusicMP3Duration2.Location = New System.Drawing.Point(1327, 92)
        Me.lblMusicMP3Duration2.Name = "lblMusicMP3Duration2"
        Me.lblMusicMP3Duration2.Size = New System.Drawing.Size(71, 20)
        Me.lblMusicMP3Duration2.TabIndex = 302
        Me.lblMusicMP3Duration2.Text = "00:00:00"
        '
        'cmdMusicStop2
        '
        Me.cmdMusicStop2.Location = New System.Drawing.Point(1331, 39)
        Me.cmdMusicStop2.Name = "cmdMusicStop2"
        Me.cmdMusicStop2.Size = New System.Drawing.Size(75, 23)
        Me.cmdMusicStop2.TabIndex = 301
        Me.cmdMusicStop2.Text = "Stop"
        Me.cmdMusicStop2.UseVisualStyleBackColor = True
        '
        'cmdMusicPlay2
        '
        Me.cmdMusicPlay2.Location = New System.Drawing.Point(1331, 10)
        Me.cmdMusicPlay2.Name = "cmdMusicPlay2"
        Me.cmdMusicPlay2.Size = New System.Drawing.Size(75, 23)
        Me.cmdMusicPlay2.TabIndex = 300
        Me.cmdMusicPlay2.Text = "Play"
        Me.cmdMusicPlay2.UseVisualStyleBackColor = True
        '
        'trkMusicVolume2
        '
        Me.trkMusicVolume2.Location = New System.Drawing.Point(1401, 92)
        Me.trkMusicVolume2.Maximum = 100
        Me.trkMusicVolume2.Name = "trkMusicVolume2"
        Me.trkMusicVolume2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trkMusicVolume2.Size = New System.Drawing.Size(45, 71)
        Me.trkMusicVolume2.TabIndex = 307
        Me.trkMusicVolume2.TickFrequency = 0
        Me.trkMusicVolume2.Value = 100
        '
        'lstMusicSongs2
        '
        Me.lstMusicSongs2.FormattingEnabled = True
        Me.lstMusicSongs2.Location = New System.Drawing.Point(1042, 10)
        Me.lstMusicSongs2.Name = "lstMusicSongs2"
        Me.lstMusicSongs2.Size = New System.Drawing.Size(283, 199)
        Me.lstMusicSongs2.Sorted = True
        Me.lstMusicSongs2.TabIndex = 299
        '
        'lblMusicMP3PositionMilli
        '
        Me.lblMusicMP3PositionMilli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMusicMP3PositionMilli.ForeColor = System.Drawing.Color.Lime
        Me.lblMusicMP3PositionMilli.Location = New System.Drawing.Point(293, 170)
        Me.lblMusicMP3PositionMilli.Name = "lblMusicMP3PositionMilli"
        Me.lblMusicMP3PositionMilli.Size = New System.Drawing.Size(71, 20)
        Me.lblMusicMP3PositionMilli.TabIndex = 296
        Me.lblMusicMP3PositionMilli.Text = "000000"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Lime
        Me.Label4.Location = New System.Drawing.Point(294, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 295
        Me.Label4.Text = "Position:"
        '
        'lblMusicMP3Position
        '
        Me.lblMusicMP3Position.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMusicMP3Position.ForeColor = System.Drawing.Color.Lime
        Me.lblMusicMP3Position.Location = New System.Drawing.Point(293, 150)
        Me.lblMusicMP3Position.Name = "lblMusicMP3Position"
        Me.lblMusicMP3Position.Size = New System.Drawing.Size(71, 20)
        Me.lblMusicMP3Position.TabIndex = 294
        Me.lblMusicMP3Position.Text = "00:00.00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Lime
        Me.Label6.Location = New System.Drawing.Point(294, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 293
        Me.Label6.Text = "Duration:"
        '
        'lblMusicMP3Duration
        '
        Me.lblMusicMP3Duration.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMusicMP3Duration.ForeColor = System.Drawing.Color.Lime
        Me.lblMusicMP3Duration.Location = New System.Drawing.Point(293, 90)
        Me.lblMusicMP3Duration.Name = "lblMusicMP3Duration"
        Me.lblMusicMP3Duration.Size = New System.Drawing.Size(71, 20)
        Me.lblMusicMP3Duration.TabIndex = 292
        Me.lblMusicMP3Duration.Text = "00:00:00"
        '
        'cmdMusicStop
        '
        Me.cmdMusicStop.Location = New System.Drawing.Point(297, 37)
        Me.cmdMusicStop.Name = "cmdMusicStop"
        Me.cmdMusicStop.Size = New System.Drawing.Size(75, 23)
        Me.cmdMusicStop.TabIndex = 291
        Me.cmdMusicStop.Text = "Stop"
        Me.cmdMusicStop.UseVisualStyleBackColor = True
        '
        'cmdMusicPlay
        '
        Me.cmdMusicPlay.Location = New System.Drawing.Point(297, 8)
        Me.cmdMusicPlay.Name = "cmdMusicPlay"
        Me.cmdMusicPlay.Size = New System.Drawing.Size(75, 23)
        Me.cmdMusicPlay.TabIndex = 290
        Me.cmdMusicPlay.Text = "Play"
        Me.cmdMusicPlay.UseVisualStyleBackColor = True
        '
        'lstMusicSongs
        '
        Me.lstMusicSongs.FormattingEnabled = True
        Me.lstMusicSongs.Location = New System.Drawing.Point(8, 8)
        Me.lstMusicSongs.Name = "lstMusicSongs"
        Me.lstMusicSongs.Size = New System.Drawing.Size(283, 199)
        Me.lstMusicSongs.Sorted = True
        Me.lstMusicSongs.TabIndex = 289
        '
        'trkMusicVolume
        '
        Me.trkMusicVolume.Location = New System.Drawing.Point(367, 90)
        Me.trkMusicVolume.Maximum = 100
        Me.trkMusicVolume.Name = "trkMusicVolume"
        Me.trkMusicVolume.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trkMusicVolume.Size = New System.Drawing.Size(45, 71)
        Me.trkMusicVolume.TabIndex = 298
        Me.trkMusicVolume.TickFrequency = 0
        Me.trkMusicVolume.Value = 100
        '
        'tbpScriptChanges
        '
        Me.tbpScriptChanges.Controls.Add(Me.lstDramaViewSongChanges2)
        Me.tbpScriptChanges.Controls.Add(Me.lstDramaViewSongChanges1)
        Me.tbpScriptChanges.Controls.Add(Me.cmdDramaBlackoutAllInstant)
        Me.tbpScriptChanges.Controls.Add(Me.cmdDramaBlackoutAllTimer)
        Me.tbpScriptChanges.Controls.Add(Me.lstDramaPresets)
        Me.tbpScriptChanges.Controls.Add(Me.cmdDramaViewSkip2)
        Me.tbpScriptChanges.Controls.Add(Me.cmdDramaViewSkip)
        Me.tbpScriptChanges.Controls.Add(Me.lblDramaViewMP3PositionMilli2)
        Me.tbpScriptChanges.Controls.Add(Me.Label3)
        Me.tbpScriptChanges.Controls.Add(Me.lblDramaViewMP3Position2)
        Me.tbpScriptChanges.Controls.Add(Me.Label28)
        Me.tbpScriptChanges.Controls.Add(Me.lblDramaViewMP3Duration2)
        Me.tbpScriptChanges.Controls.Add(Me.cmdDramaViewStop2)
        Me.tbpScriptChanges.Controls.Add(Me.cmdDramaViewPlay2)
        Me.tbpScriptChanges.Controls.Add(Me.trkDramaViewVolume2)
        Me.tbpScriptChanges.Controls.Add(Me.lstDramaViewSongs2)
        Me.tbpScriptChanges.Controls.Add(Me.lblDramaViewMP3PositionMilli)
        Me.tbpScriptChanges.Controls.Add(Me.Label33)
        Me.tbpScriptChanges.Controls.Add(Me.lblDramaViewMP3Position)
        Me.tbpScriptChanges.Controls.Add(Me.Label37)
        Me.tbpScriptChanges.Controls.Add(Me.lblDramaViewMP3Duration)
        Me.tbpScriptChanges.Controls.Add(Me.cmdDramaViewStop)
        Me.tbpScriptChanges.Controls.Add(Me.cmdDramaViewPlay)
        Me.tbpScriptChanges.Controls.Add(Me.lstDramaViewSongs)
        Me.tbpScriptChanges.Controls.Add(Me.trkDramaViewVolume)
        Me.tbpScriptChanges.Location = New System.Drawing.Point(4, 22)
        Me.tbpScriptChanges.Name = "tbpScriptChanges"
        Me.tbpScriptChanges.Size = New System.Drawing.Size(1826, 1061)
        Me.tbpScriptChanges.TabIndex = 3
        Me.tbpScriptChanges.Text = "Script Changes"
        Me.tbpScriptChanges.UseVisualStyleBackColor = True
        '
        'lstDramaViewSongChanges2
        '
        Me.lstDramaViewSongChanges2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstDramaViewSongChanges2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16})
        Me.lstDramaViewSongChanges2.FullRowSelect = True
        Me.lstDramaViewSongChanges2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstDramaViewSongChanges2.HideSelection = False
        Me.lstDramaViewSongChanges2.Location = New System.Drawing.Point(1588, 399)
        Me.lstDramaViewSongChanges2.MultiSelect = False
        Me.lstDramaViewSongChanges2.Name = "lstDramaViewSongChanges2"
        Me.lstDramaViewSongChanges2.Size = New System.Drawing.Size(231, 383)
        Me.lstDramaViewSongChanges2.TabIndex = 629
        Me.lstDramaViewSongChanges2.UseCompatibleStateImageBehavior = False
        Me.lstDramaViewSongChanges2.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Time"
        Me.ColumnHeader13.Width = 40
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Scene"
        Me.ColumnHeader14.Width = 90
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "In"
        Me.ColumnHeader15.Width = 40
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Out"
        Me.ColumnHeader16.Width = 40
        '
        'lstDramaViewSongChanges1
        '
        Me.lstDramaViewSongChanges1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstDramaViewSongChanges1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20})
        Me.lstDramaViewSongChanges1.FullRowSelect = True
        Me.lstDramaViewSongChanges1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstDramaViewSongChanges1.HideSelection = False
        Me.lstDramaViewSongChanges1.Location = New System.Drawing.Point(1588, 7)
        Me.lstDramaViewSongChanges1.MultiSelect = False
        Me.lstDramaViewSongChanges1.Name = "lstDramaViewSongChanges1"
        Me.lstDramaViewSongChanges1.Size = New System.Drawing.Size(231, 381)
        Me.lstDramaViewSongChanges1.TabIndex = 628
        Me.lstDramaViewSongChanges1.UseCompatibleStateImageBehavior = False
        Me.lstDramaViewSongChanges1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Time"
        Me.ColumnHeader17.Width = 40
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Scene"
        Me.ColumnHeader18.Width = 90
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "In"
        Me.ColumnHeader19.Width = 40
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Out"
        Me.ColumnHeader20.Width = 40
        '
        'cmdDramaBlackoutAllInstant
        '
        Me.cmdDramaBlackoutAllInstant.Location = New System.Drawing.Point(282, 65)
        Me.cmdDramaBlackoutAllInstant.Name = "cmdDramaBlackoutAllInstant"
        Me.cmdDramaBlackoutAllInstant.Size = New System.Drawing.Size(90, 45)
        Me.cmdDramaBlackoutAllInstant.TabIndex = 573
        Me.cmdDramaBlackoutAllInstant.Text = "Blackout All Instant"
        Me.cmdDramaBlackoutAllInstant.UseVisualStyleBackColor = True
        '
        'cmdDramaBlackoutAllTimer
        '
        Me.cmdDramaBlackoutAllTimer.Location = New System.Drawing.Point(282, 14)
        Me.cmdDramaBlackoutAllTimer.Name = "cmdDramaBlackoutAllTimer"
        Me.cmdDramaBlackoutAllTimer.Size = New System.Drawing.Size(90, 45)
        Me.cmdDramaBlackoutAllTimer.TabIndex = 572
        Me.cmdDramaBlackoutAllTimer.Text = "Blackout All Timer"
        Me.cmdDramaBlackoutAllTimer.UseVisualStyleBackColor = True
        '
        'lstDramaPresets
        '
        Me.lstDramaPresets.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstDramaPresets.ContextMenuStrip = Me.ctxDramaChangesActions
        Me.lstDramaPresets.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstDramaPresets.FormattingEnabled = True
        Me.lstDramaPresets.ItemHeight = 16
        Me.lstDramaPresets.Location = New System.Drawing.Point(8, 7)
        Me.lstDramaPresets.Name = "lstDramaPresets"
        Me.lstDramaPresets.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstDramaPresets.Size = New System.Drawing.Size(268, 868)
        Me.lstDramaPresets.TabIndex = 333
        '
        'cmdDramaViewSkip2
        '
        Me.cmdDramaViewSkip2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDramaViewSkip2.Location = New System.Drawing.Point(1463, 503)
        Me.cmdDramaViewSkip2.Name = "cmdDramaViewSkip2"
        Me.cmdDramaViewSkip2.Size = New System.Drawing.Size(37, 23)
        Me.cmdDramaViewSkip2.TabIndex = 331
        Me.cmdDramaViewSkip2.Text = "Skip"
        Me.cmdDramaViewSkip2.UseVisualStyleBackColor = True
        '
        'cmdDramaViewSkip
        '
        Me.cmdDramaViewSkip.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDramaViewSkip.Location = New System.Drawing.Point(1463, 108)
        Me.cmdDramaViewSkip.Name = "cmdDramaViewSkip"
        Me.cmdDramaViewSkip.Size = New System.Drawing.Size(37, 23)
        Me.cmdDramaViewSkip.TabIndex = 330
        Me.cmdDramaViewSkip.Text = "Skip"
        Me.cmdDramaViewSkip.UseVisualStyleBackColor = True
        '
        'lblDramaViewMP3PositionMilli2
        '
        Me.lblDramaViewMP3PositionMilli2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDramaViewMP3PositionMilli2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDramaViewMP3PositionMilli2.ForeColor = System.Drawing.Color.Lime
        Me.lblDramaViewMP3PositionMilli2.Location = New System.Drawing.Point(1459, 563)
        Me.lblDramaViewMP3PositionMilli2.Name = "lblDramaViewMP3PositionMilli2"
        Me.lblDramaViewMP3PositionMilli2.Size = New System.Drawing.Size(71, 20)
        Me.lblDramaViewMP3PositionMilli2.TabIndex = 328
        Me.lblDramaViewMP3PositionMilli2.Text = "000000"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Lime
        Me.Label3.Location = New System.Drawing.Point(1460, 527)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 327
        Me.Label3.Text = "Position:"
        '
        'lblDramaViewMP3Position2
        '
        Me.lblDramaViewMP3Position2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDramaViewMP3Position2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDramaViewMP3Position2.ForeColor = System.Drawing.Color.Lime
        Me.lblDramaViewMP3Position2.Location = New System.Drawing.Point(1459, 543)
        Me.lblDramaViewMP3Position2.Name = "lblDramaViewMP3Position2"
        Me.lblDramaViewMP3Position2.Size = New System.Drawing.Size(71, 20)
        Me.lblDramaViewMP3Position2.TabIndex = 326
        Me.lblDramaViewMP3Position2.Text = "00:00.00"
        '
        'Label28
        '
        Me.Label28.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Lime
        Me.Label28.Location = New System.Drawing.Point(1460, 467)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(50, 13)
        Me.Label28.TabIndex = 325
        Me.Label28.Text = "Duration:"
        '
        'lblDramaViewMP3Duration2
        '
        Me.lblDramaViewMP3Duration2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDramaViewMP3Duration2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDramaViewMP3Duration2.ForeColor = System.Drawing.Color.Lime
        Me.lblDramaViewMP3Duration2.Location = New System.Drawing.Point(1459, 483)
        Me.lblDramaViewMP3Duration2.Name = "lblDramaViewMP3Duration2"
        Me.lblDramaViewMP3Duration2.Size = New System.Drawing.Size(71, 20)
        Me.lblDramaViewMP3Duration2.TabIndex = 324
        Me.lblDramaViewMP3Duration2.Text = "00:00:00"
        '
        'cmdDramaViewStop2
        '
        Me.cmdDramaViewStop2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDramaViewStop2.Location = New System.Drawing.Point(1463, 430)
        Me.cmdDramaViewStop2.Name = "cmdDramaViewStop2"
        Me.cmdDramaViewStop2.Size = New System.Drawing.Size(75, 23)
        Me.cmdDramaViewStop2.TabIndex = 323
        Me.cmdDramaViewStop2.Text = "Stop"
        Me.cmdDramaViewStop2.UseVisualStyleBackColor = True
        '
        'cmdDramaViewPlay2
        '
        Me.cmdDramaViewPlay2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDramaViewPlay2.Location = New System.Drawing.Point(1463, 401)
        Me.cmdDramaViewPlay2.Name = "cmdDramaViewPlay2"
        Me.cmdDramaViewPlay2.Size = New System.Drawing.Size(75, 23)
        Me.cmdDramaViewPlay2.TabIndex = 322
        Me.cmdDramaViewPlay2.Text = "Play"
        Me.cmdDramaViewPlay2.UseVisualStyleBackColor = True
        '
        'trkDramaViewVolume2
        '
        Me.trkDramaViewVolume2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trkDramaViewVolume2.Location = New System.Drawing.Point(1533, 483)
        Me.trkDramaViewVolume2.Maximum = 100
        Me.trkDramaViewVolume2.Name = "trkDramaViewVolume2"
        Me.trkDramaViewVolume2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trkDramaViewVolume2.Size = New System.Drawing.Size(45, 71)
        Me.trkDramaViewVolume2.TabIndex = 329
        Me.trkDramaViewVolume2.TickFrequency = 0
        Me.trkDramaViewVolume2.Value = 100
        '
        'lstDramaViewSongs2
        '
        Me.lstDramaViewSongs2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstDramaViewSongs2.FormattingEnabled = True
        Me.lstDramaViewSongs2.Location = New System.Drawing.Point(1174, 401)
        Me.lstDramaViewSongs2.Name = "lstDramaViewSongs2"
        Me.lstDramaViewSongs2.Size = New System.Drawing.Size(283, 381)
        Me.lstDramaViewSongs2.Sorted = True
        Me.lstDramaViewSongs2.TabIndex = 321
        '
        'lblDramaViewMP3PositionMilli
        '
        Me.lblDramaViewMP3PositionMilli.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDramaViewMP3PositionMilli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDramaViewMP3PositionMilli.ForeColor = System.Drawing.Color.Lime
        Me.lblDramaViewMP3PositionMilli.Location = New System.Drawing.Point(1459, 169)
        Me.lblDramaViewMP3PositionMilli.Name = "lblDramaViewMP3PositionMilli"
        Me.lblDramaViewMP3PositionMilli.Size = New System.Drawing.Size(71, 20)
        Me.lblDramaViewMP3PositionMilli.TabIndex = 318
        Me.lblDramaViewMP3PositionMilli.Text = "000000"
        '
        'Label33
        '
        Me.Label33.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Lime
        Me.Label33.Location = New System.Drawing.Point(1460, 133)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(47, 13)
        Me.Label33.TabIndex = 317
        Me.Label33.Text = "Position:"
        '
        'lblDramaViewMP3Position
        '
        Me.lblDramaViewMP3Position.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDramaViewMP3Position.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDramaViewMP3Position.ForeColor = System.Drawing.Color.Lime
        Me.lblDramaViewMP3Position.Location = New System.Drawing.Point(1459, 149)
        Me.lblDramaViewMP3Position.Name = "lblDramaViewMP3Position"
        Me.lblDramaViewMP3Position.Size = New System.Drawing.Size(71, 20)
        Me.lblDramaViewMP3Position.TabIndex = 316
        Me.lblDramaViewMP3Position.Text = "00:00.00"
        '
        'Label37
        '
        Me.Label37.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Lime
        Me.Label37.Location = New System.Drawing.Point(1460, 73)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(50, 13)
        Me.Label37.TabIndex = 315
        Me.Label37.Text = "Duration:"
        '
        'lblDramaViewMP3Duration
        '
        Me.lblDramaViewMP3Duration.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDramaViewMP3Duration.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDramaViewMP3Duration.ForeColor = System.Drawing.Color.Lime
        Me.lblDramaViewMP3Duration.Location = New System.Drawing.Point(1459, 89)
        Me.lblDramaViewMP3Duration.Name = "lblDramaViewMP3Duration"
        Me.lblDramaViewMP3Duration.Size = New System.Drawing.Size(71, 20)
        Me.lblDramaViewMP3Duration.TabIndex = 314
        Me.lblDramaViewMP3Duration.Text = "00:00:00"
        '
        'cmdDramaViewStop
        '
        Me.cmdDramaViewStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDramaViewStop.Location = New System.Drawing.Point(1463, 36)
        Me.cmdDramaViewStop.Name = "cmdDramaViewStop"
        Me.cmdDramaViewStop.Size = New System.Drawing.Size(75, 23)
        Me.cmdDramaViewStop.TabIndex = 313
        Me.cmdDramaViewStop.Text = "Stop"
        Me.cmdDramaViewStop.UseVisualStyleBackColor = True
        '
        'cmdDramaViewPlay
        '
        Me.cmdDramaViewPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDramaViewPlay.Location = New System.Drawing.Point(1463, 7)
        Me.cmdDramaViewPlay.Name = "cmdDramaViewPlay"
        Me.cmdDramaViewPlay.Size = New System.Drawing.Size(75, 23)
        Me.cmdDramaViewPlay.TabIndex = 312
        Me.cmdDramaViewPlay.Text = "Play"
        Me.cmdDramaViewPlay.UseVisualStyleBackColor = True
        '
        'lstDramaViewSongs
        '
        Me.lstDramaViewSongs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstDramaViewSongs.FormattingEnabled = True
        Me.lstDramaViewSongs.Location = New System.Drawing.Point(1174, 7)
        Me.lstDramaViewSongs.Name = "lstDramaViewSongs"
        Me.lstDramaViewSongs.Size = New System.Drawing.Size(283, 381)
        Me.lstDramaViewSongs.Sorted = True
        Me.lstDramaViewSongs.TabIndex = 311
        '
        'trkDramaViewVolume
        '
        Me.trkDramaViewVolume.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trkDramaViewVolume.Location = New System.Drawing.Point(1533, 89)
        Me.trkDramaViewVolume.Maximum = 100
        Me.trkDramaViewVolume.Name = "trkDramaViewVolume"
        Me.trkDramaViewVolume.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trkDramaViewVolume.Size = New System.Drawing.Size(45, 71)
        Me.trkDramaViewVolume.TabIndex = 320
        Me.trkDramaViewVolume.TickFrequency = 0
        Me.trkDramaViewVolume.Value = 100
        '
        'tbpSettings
        '
        Me.tbpSettings.Controls.Add(Me.Label10)
        Me.tbpSettings.Controls.Add(Me.cmdSubmitIssue)
        Me.tbpSettings.Controls.Add(Me.txtGithubIssue)
        Me.tbpSettings.Controls.Add(Me.cmdCOMDisconnect)
        Me.tbpSettings.Controls.Add(Me.cmdSetMarsConsole)
        Me.tbpSettings.Controls.Add(Me.chkMusicNextFollows)
        Me.tbpSettings.Controls.Add(Me.lstStartup)
        Me.tbpSettings.Controls.Add(Me.lblSceneBorderColour)
        Me.tbpSettings.Controls.Add(Me.cmdSceneBorderColor)
        Me.tbpSettings.Controls.Add(Me.cmdAsioDown)
        Me.tbpSettings.Controls.Add(Me.cmdAsioUp)
        Me.tbpSettings.Controls.Add(Me.Label7)
        Me.tbpSettings.Controls.Add(Me.lstASIOInterfaces)
        Me.tbpSettings.Controls.Add(Me.cmdRepeatAssignments)
        Me.tbpSettings.Controls.Add(Me.Label5)
        Me.tbpSettings.Controls.Add(Me.txtSCSPort)
        Me.tbpSettings.Controls.Add(Me.Label2)
        Me.tbpSettings.Controls.Add(Me.txtSCSIPaddress)
        Me.tbpSettings.Controls.Add(Me.cmdReloadArduinoAssignments)
        Me.tbpSettings.Controls.Add(Me.cmdSetSoundActivation)
        Me.tbpSettings.Controls.Add(Me.cmdSetDMX1)
        Me.tbpSettings.Controls.Add(Me.cmdSetMusic2)
        Me.tbpSettings.Controls.Add(Me.cmdSetMusic1)
        Me.tbpSettings.Controls.Add(Me.cmdRestartSerial)
        Me.tbpSettings.Controls.Add(Me.lstCOMdevices)
        Me.tbpSettings.Controls.Add(Me.lblSongChangeColour)
        Me.tbpSettings.Controls.Add(Me.cmdSongChangeColour)
        Me.tbpSettings.Controls.Add(Me.cmdSaveSettings)
        Me.tbpSettings.Controls.Add(Me.lblSceneLabelColour)
        Me.tbpSettings.Controls.Add(Me.cmdSceneLabelColour)
        Me.tbpSettings.Controls.Add(Me.cmdSerialClear)
        Me.tbpSettings.Controls.Add(Me.lblUpDownTest)
        Me.tbpSettings.Controls.Add(Me.txtSerialIn)
        Me.tbpSettings.Controls.Add(Me.lblChannelNumberColour)
        Me.tbpSettings.Controls.Add(Me.cmdChannelNumberColour)
        Me.tbpSettings.Controls.Add(Me.lblSceneFillColour)
        Me.tbpSettings.Controls.Add(Me.lblSceneUpColour)
        Me.tbpSettings.Controls.Add(Me.lblSceneBlackoutColour)
        Me.tbpSettings.Controls.Add(Me.cmdSceneFillColour)
        Me.tbpSettings.Controls.Add(Me.cmdSceneUpColour)
        Me.tbpSettings.Controls.Add(Me.cmdSceneBlackoutColour)
        Me.tbpSettings.Controls.Add(Me.lblChannelFillColour)
        Me.tbpSettings.Controls.Add(Me.lblChannelBackColour)
        Me.tbpSettings.Controls.Add(Me.lblChannelBulletColour)
        Me.tbpSettings.Controls.Add(Me.cmdChannelFillColour)
        Me.tbpSettings.Controls.Add(Me.cmdChannelBackColour)
        Me.tbpSettings.Controls.Add(Me.cmdChannelBulletColour)
        Me.tbpSettings.Controls.Add(Me.chkLoadonChange)
        Me.tbpSettings.Controls.Add(Me.Label1)
        Me.tbpSettings.Controls.Add(Me.numEndChannel)
        Me.tbpSettings.Location = New System.Drawing.Point(4, 22)
        Me.tbpSettings.Name = "tbpSettings"
        Me.tbpSettings.Size = New System.Drawing.Size(1826, 1061)
        Me.tbpSettings.TabIndex = 4
        Me.tbpSettings.Text = "Settings"
        Me.tbpSettings.UseVisualStyleBackColor = True
        '
        'cmdCOMDisconnect
        '
        Me.cmdCOMDisconnect.Location = New System.Drawing.Point(1632, 309)
        Me.cmdCOMDisconnect.Name = "cmdCOMDisconnect"
        Me.cmdCOMDisconnect.Size = New System.Drawing.Size(162, 23)
        Me.cmdCOMDisconnect.TabIndex = 353
        Me.cmdCOMDisconnect.Text = "Disconnect this COM device"
        Me.cmdCOMDisconnect.UseVisualStyleBackColor = True
        '
        'cmdSetMarsConsole
        '
        Me.cmdSetMarsConsole.Location = New System.Drawing.Point(1632, 202)
        Me.cmdSetMarsConsole.Name = "cmdSetMarsConsole"
        Me.cmdSetMarsConsole.Size = New System.Drawing.Size(126, 23)
        Me.cmdSetMarsConsole.TabIndex = 352
        Me.cmdSetMarsConsole.Text = "Set Mars Console"
        Me.cmdSetMarsConsole.UseVisualStyleBackColor = True
        '
        'chkMusicNextFollows
        '
        Me.chkMusicNextFollows.AutoSize = True
        Me.chkMusicNextFollows.Checked = True
        Me.chkMusicNextFollows.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMusicNextFollows.Location = New System.Drawing.Point(122, 313)
        Me.chkMusicNextFollows.Name = "chkMusicNextFollows"
        Me.chkMusicNextFollows.Size = New System.Drawing.Size(166, 17)
        Me.chkMusicNextFollows.TabIndex = 351
        Me.chkMusicNextFollows.Text = "Music 2 Follows Music 1 Next"
        Me.chkMusicNextFollows.UseVisualStyleBackColor = True
        '
        'lstStartup
        '
        Me.lstStartup.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader32, Me.ColumnHeader33, Me.ColumnHeader34})
        Me.lstStartup.FullRowSelect = True
        Me.lstStartup.HideSelection = False
        Me.lstStartup.Location = New System.Drawing.Point(780, 69)
        Me.lstStartup.MultiSelect = False
        Me.lstStartup.Name = "lstStartup"
        Me.lstStartup.Size = New System.Drawing.Size(350, 404)
        Me.lstStartup.TabIndex = 350
        Me.lstStartup.UseCompatibleStateImageBehavior = False
        Me.lstStartup.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader32
        '
        Me.ColumnHeader32.Text = "Item"
        Me.ColumnHeader32.Width = 180
        '
        'ColumnHeader33
        '
        Me.ColumnHeader33.Text = "Time"
        '
        'ColumnHeader34
        '
        Me.ColumnHeader34.Text = "Difference"
        Me.ColumnHeader34.Width = 72
        '
        'lblSceneBorderColour
        '
        Me.lblSceneBorderColour.BackColor = System.Drawing.Color.Gold
        Me.lblSceneBorderColour.Location = New System.Drawing.Point(160, 804)
        Me.lblSceneBorderColour.Name = "lblSceneBorderColour"
        Me.lblSceneBorderColour.Size = New System.Drawing.Size(100, 23)
        Me.lblSceneBorderColour.TabIndex = 349
        Me.lblSceneBorderColour.Text = "..."
        Me.lblSceneBorderColour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdSceneBorderColor
        '
        Me.cmdSceneBorderColor.Location = New System.Drawing.Point(8, 804)
        Me.cmdSceneBorderColor.Name = "cmdSceneBorderColor"
        Me.cmdSceneBorderColor.Size = New System.Drawing.Size(146, 23)
        Me.cmdSceneBorderColor.TabIndex = 348
        Me.cmdSceneBorderColor.Text = "Scene Border Colour"
        Me.cmdSceneBorderColor.UseVisualStyleBackColor = True
        '
        'cmdAsioDown
        '
        Me.cmdAsioDown.Location = New System.Drawing.Point(294, 173)
        Me.cmdAsioDown.Name = "cmdAsioDown"
        Me.cmdAsioDown.Size = New System.Drawing.Size(20, 23)
        Me.cmdAsioDown.TabIndex = 347
        Me.cmdAsioDown.Text = "v"
        Me.cmdAsioDown.UseVisualStyleBackColor = True
        '
        'cmdAsioUp
        '
        Me.cmdAsioUp.Location = New System.Drawing.Point(294, 144)
        Me.cmdAsioUp.Name = "cmdAsioUp"
        Me.cmdAsioUp.Size = New System.Drawing.Size(20, 23)
        Me.cmdAsioUp.TabIndex = 346
        Me.cmdAsioUp.Text = "^"
        Me.cmdAsioUp.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Lime
        Me.Label7.Location = New System.Drawing.Point(122, 256)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 13)
        Me.Label7.TabIndex = 345
        Me.Label7.Text = "Out #0 means not being used"
        '
        'lstASIOInterfaces
        '
        Me.lstASIOInterfaces.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader30, Me.ColumnHeader29})
        Me.lstASIOInterfaces.FullRowSelect = True
        Me.lstASIOInterfaces.HideSelection = False
        Me.lstASIOInterfaces.Location = New System.Drawing.Point(8, 115)
        Me.lstASIOInterfaces.MultiSelect = False
        Me.lstASIOInterfaces.Name = "lstASIOInterfaces"
        Me.lstASIOInterfaces.Size = New System.Drawing.Size(280, 131)
        Me.lstASIOInterfaces.Sorting = System.Windows.Forms.SortOrder.Descending
        Me.lstASIOInterfaces.TabIndex = 343
        Me.lstASIOInterfaces.UseCompatibleStateImageBehavior = False
        Me.lstASIOInterfaces.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader30
        '
        Me.ColumnHeader30.Text = "Out #"
        '
        'ColumnHeader29
        '
        Me.ColumnHeader29.Text = "Interface"
        Me.ColumnHeader29.Width = 180
        '
        'cmdRepeatAssignments
        '
        Me.cmdRepeatAssignments.Location = New System.Drawing.Point(1446, 479)
        Me.cmdRepeatAssignments.Name = "cmdRepeatAssignments"
        Me.cmdRepeatAssignments.Size = New System.Drawing.Size(180, 23)
        Me.cmdRepeatAssignments.TabIndex = 342
        Me.cmdRepeatAssignments.Text = "Run Assignment Checks"
        Me.cmdRepeatAssignments.UseVisualStyleBackColor = True
        Me.cmdRepeatAssignments.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Lime
        Me.Label5.Location = New System.Drawing.Point(123, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 340
        Me.Label5.Text = "SCS Port:"
        '
        'txtSCSPort
        '
        Me.txtSCSPort.Location = New System.Drawing.Point(214, 45)
        Me.txtSCSPort.Name = "txtSCSPort"
        Me.txtSCSPort.Size = New System.Drawing.Size(55, 20)
        Me.txtSCSPort.TabIndex = 339
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Lime
        Me.Label2.Location = New System.Drawing.Point(123, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 338
        Me.Label2.Text = "SCS IP Address:"
        '
        'txtSCSIPaddress
        '
        Me.txtSCSIPaddress.Location = New System.Drawing.Point(214, 19)
        Me.txtSCSIPaddress.Name = "txtSCSIPaddress"
        Me.txtSCSIPaddress.Size = New System.Drawing.Size(100, 20)
        Me.txtSCSIPaddress.TabIndex = 337
        '
        'cmdReloadArduinoAssignments
        '
        Me.cmdReloadArduinoAssignments.Location = New System.Drawing.Point(1446, 450)
        Me.cmdReloadArduinoAssignments.Name = "cmdReloadArduinoAssignments"
        Me.cmdReloadArduinoAssignments.Size = New System.Drawing.Size(130, 23)
        Me.cmdReloadArduinoAssignments.TabIndex = 328
        Me.cmdReloadArduinoAssignments.Text = "Reload Assignments"
        Me.cmdReloadArduinoAssignments.UseVisualStyleBackColor = True
        '
        'cmdSetSoundActivation
        '
        Me.cmdSetSoundActivation.Location = New System.Drawing.Point(1632, 173)
        Me.cmdSetSoundActivation.Name = "cmdSetSoundActivation"
        Me.cmdSetSoundActivation.Size = New System.Drawing.Size(126, 23)
        Me.cmdSetSoundActivation.TabIndex = 327
        Me.cmdSetSoundActivation.Text = "Set Sound Activation"
        Me.cmdSetSoundActivation.UseVisualStyleBackColor = True
        '
        'cmdSetDMX1
        '
        Me.cmdSetDMX1.Location = New System.Drawing.Point(1632, 144)
        Me.cmdSetDMX1.Name = "cmdSetDMX1"
        Me.cmdSetDMX1.Size = New System.Drawing.Size(126, 23)
        Me.cmdSetDMX1.TabIndex = 326
        Me.cmdSetDMX1.Text = "Set DMX Controller 1"
        Me.cmdSetDMX1.UseVisualStyleBackColor = True
        '
        'cmdSetMusic2
        '
        Me.cmdSetMusic2.Location = New System.Drawing.Point(1632, 115)
        Me.cmdSetMusic2.Name = "cmdSetMusic2"
        Me.cmdSetMusic2.Size = New System.Drawing.Size(126, 23)
        Me.cmdSetMusic2.TabIndex = 325
        Me.cmdSetMusic2.Text = "Set Music 2 Controller"
        Me.cmdSetMusic2.UseVisualStyleBackColor = True
        '
        'cmdSetMusic1
        '
        Me.cmdSetMusic1.Location = New System.Drawing.Point(1632, 86)
        Me.cmdSetMusic1.Name = "cmdSetMusic1"
        Me.cmdSetMusic1.Size = New System.Drawing.Size(126, 23)
        Me.cmdSetMusic1.TabIndex = 324
        Me.cmdSetMusic1.Text = "Set Music 1 Controller"
        Me.cmdSetMusic1.UseVisualStyleBackColor = True
        '
        'cmdRestartSerial
        '
        Me.cmdRestartSerial.Location = New System.Drawing.Point(1136, 450)
        Me.cmdRestartSerial.Name = "cmdRestartSerial"
        Me.cmdRestartSerial.Size = New System.Drawing.Size(130, 23)
        Me.cmdRestartSerial.TabIndex = 323
        Me.cmdRestartSerial.Text = "Reset Serial Connections"
        Me.cmdRestartSerial.UseVisualStyleBackColor = True
        '
        'lstCOMdevices
        '
        Me.lstCOMdevices.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader25, Me.ColumnHeader26, Me.ColumnHeader27, Me.ColumnHeader28, Me.ColumnHeader31})
        Me.lstCOMdevices.FullRowSelect = True
        Me.lstCOMdevices.HideSelection = False
        Me.lstCOMdevices.Location = New System.Drawing.Point(1136, 40)
        Me.lstCOMdevices.MultiSelect = False
        Me.lstCOMdevices.Name = "lstCOMdevices"
        Me.lstCOMdevices.Size = New System.Drawing.Size(490, 404)
        Me.lstCOMdevices.TabIndex = 322
        Me.lstCOMdevices.UseCompatibleStateImageBehavior = False
        Me.lstCOMdevices.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.Text = "COM#"
        '
        'ColumnHeader26
        '
        Me.ColumnHeader26.Text = "Name"
        Me.ColumnHeader26.Width = 180
        '
        'ColumnHeader27
        '
        Me.ColumnHeader27.Text = "In Use?"
        '
        'ColumnHeader28
        '
        Me.ColumnHeader28.Text = "Job"
        Me.ColumnHeader28.Width = 180
        '
        'ColumnHeader31
        '
        Me.ColumnHeader31.Text = "UID"
        '
        'lblSongChangeColour
        '
        Me.lblSongChangeColour.BackColor = System.Drawing.Color.Magenta
        Me.lblSongChangeColour.Location = New System.Drawing.Point(160, 832)
        Me.lblSongChangeColour.Name = "lblSongChangeColour"
        Me.lblSongChangeColour.Size = New System.Drawing.Size(100, 23)
        Me.lblSongChangeColour.TabIndex = 321
        Me.lblSongChangeColour.Text = "..."
        Me.lblSongChangeColour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdSongChangeColour
        '
        Me.cmdSongChangeColour.Location = New System.Drawing.Point(8, 832)
        Me.cmdSongChangeColour.Name = "cmdSongChangeColour"
        Me.cmdSongChangeColour.Size = New System.Drawing.Size(146, 23)
        Me.cmdSongChangeColour.TabIndex = 320
        Me.cmdSongChangeColour.Text = "Song Change Colour"
        Me.cmdSongChangeColour.UseVisualStyleBackColor = True
        '
        'cmdSaveSettings
        '
        Me.cmdSaveSettings.Location = New System.Drawing.Point(757, 8)
        Me.cmdSaveSettings.Name = "cmdSaveSettings"
        Me.cmdSaveSettings.Size = New System.Drawing.Size(112, 50)
        Me.cmdSaveSettings.TabIndex = 314
        Me.cmdSaveSettings.Text = "Save Settings"
        Me.cmdSaveSettings.UseVisualStyleBackColor = True
        '
        'lblSceneLabelColour
        '
        Me.lblSceneLabelColour.BackColor = System.Drawing.Color.Magenta
        Me.lblSceneLabelColour.Location = New System.Drawing.Point(160, 777)
        Me.lblSceneLabelColour.Name = "lblSceneLabelColour"
        Me.lblSceneLabelColour.Size = New System.Drawing.Size(100, 23)
        Me.lblSceneLabelColour.TabIndex = 269
        Me.lblSceneLabelColour.Text = "..."
        Me.lblSceneLabelColour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdSceneLabelColour
        '
        Me.cmdSceneLabelColour.Location = New System.Drawing.Point(8, 777)
        Me.cmdSceneLabelColour.Name = "cmdSceneLabelColour"
        Me.cmdSceneLabelColour.Size = New System.Drawing.Size(146, 23)
        Me.cmdSceneLabelColour.TabIndex = 268
        Me.cmdSceneLabelColour.Text = "Scene Label Colour"
        Me.cmdSceneLabelColour.UseVisualStyleBackColor = True
        '
        'cmdSerialClear
        '
        Me.cmdSerialClear.Location = New System.Drawing.Point(1045, 35)
        Me.cmdSerialClear.Name = "cmdSerialClear"
        Me.cmdSerialClear.Size = New System.Drawing.Size(75, 23)
        Me.cmdSerialClear.TabIndex = 318
        Me.cmdSerialClear.Text = "Serial Clear"
        Me.cmdSerialClear.UseVisualStyleBackColor = True
        '
        'lblUpDownTest
        '
        Me.lblUpDownTest.AutoSize = True
        Me.lblUpDownTest.ForeColor = System.Drawing.Color.Lime
        Me.lblUpDownTest.Location = New System.Drawing.Point(1768, 857)
        Me.lblUpDownTest.Name = "lblUpDownTest"
        Me.lblUpDownTest.Size = New System.Drawing.Size(49, 13)
        Me.lblUpDownTest.TabIndex = 313
        Me.lblUpDownTest.Text = "UpDown"
        '
        'txtSerialIn
        '
        Me.txtSerialIn.Location = New System.Drawing.Point(1632, 342)
        Me.txtSerialIn.Multiline = True
        Me.txtSerialIn.Name = "txtSerialIn"
        Me.txtSerialIn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSerialIn.Size = New System.Drawing.Size(185, 322)
        Me.txtSerialIn.TabIndex = 317
        '
        'lblChannelNumberColour
        '
        Me.lblChannelNumberColour.BackColor = System.Drawing.Color.Magenta
        Me.lblChannelNumberColour.Location = New System.Drawing.Point(160, 608)
        Me.lblChannelNumberColour.Name = "lblChannelNumberColour"
        Me.lblChannelNumberColour.Size = New System.Drawing.Size(100, 23)
        Me.lblChannelNumberColour.TabIndex = 267
        Me.lblChannelNumberColour.Text = "..."
        Me.lblChannelNumberColour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdChannelNumberColour
        '
        Me.cmdChannelNumberColour.Location = New System.Drawing.Point(8, 608)
        Me.cmdChannelNumberColour.Name = "cmdChannelNumberColour"
        Me.cmdChannelNumberColour.Size = New System.Drawing.Size(146, 23)
        Me.cmdChannelNumberColour.TabIndex = 266
        Me.cmdChannelNumberColour.Text = "Channel Number Colour"
        Me.cmdChannelNumberColour.UseVisualStyleBackColor = True
        '
        'lblSceneFillColour
        '
        Me.lblSceneFillColour.BackColor = System.Drawing.Color.Black
        Me.lblSceneFillColour.Location = New System.Drawing.Point(160, 748)
        Me.lblSceneFillColour.Name = "lblSceneFillColour"
        Me.lblSceneFillColour.Size = New System.Drawing.Size(100, 23)
        Me.lblSceneFillColour.TabIndex = 265
        Me.lblSceneFillColour.Text = "..."
        Me.lblSceneFillColour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSceneFillColour.Visible = False
        '
        'lblSceneUpColour
        '
        Me.lblSceneUpColour.BackColor = System.Drawing.Color.Green
        Me.lblSceneUpColour.Location = New System.Drawing.Point(160, 719)
        Me.lblSceneUpColour.Name = "lblSceneUpColour"
        Me.lblSceneUpColour.Size = New System.Drawing.Size(100, 23)
        Me.lblSceneUpColour.TabIndex = 264
        Me.lblSceneUpColour.Text = "..."
        Me.lblSceneUpColour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSceneBlackoutColour
        '
        Me.lblSceneBlackoutColour.BackColor = System.Drawing.Color.Blue
        Me.lblSceneBlackoutColour.Location = New System.Drawing.Point(160, 690)
        Me.lblSceneBlackoutColour.Name = "lblSceneBlackoutColour"
        Me.lblSceneBlackoutColour.Size = New System.Drawing.Size(100, 23)
        Me.lblSceneBlackoutColour.TabIndex = 263
        Me.lblSceneBlackoutColour.Text = "..."
        Me.lblSceneBlackoutColour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdSceneFillColour
        '
        Me.cmdSceneFillColour.Location = New System.Drawing.Point(8, 748)
        Me.cmdSceneFillColour.Name = "cmdSceneFillColour"
        Me.cmdSceneFillColour.Size = New System.Drawing.Size(146, 23)
        Me.cmdSceneFillColour.TabIndex = 262
        Me.cmdSceneFillColour.Text = "Scene Fill Colour"
        Me.cmdSceneFillColour.UseVisualStyleBackColor = True
        Me.cmdSceneFillColour.Visible = False
        '
        'cmdSceneUpColour
        '
        Me.cmdSceneUpColour.Location = New System.Drawing.Point(8, 719)
        Me.cmdSceneUpColour.Name = "cmdSceneUpColour"
        Me.cmdSceneUpColour.Size = New System.Drawing.Size(146, 23)
        Me.cmdSceneUpColour.TabIndex = 261
        Me.cmdSceneUpColour.Text = "Scene Up Colour"
        Me.cmdSceneUpColour.UseVisualStyleBackColor = True
        '
        'cmdSceneBlackoutColour
        '
        Me.cmdSceneBlackoutColour.Location = New System.Drawing.Point(8, 690)
        Me.cmdSceneBlackoutColour.Name = "cmdSceneBlackoutColour"
        Me.cmdSceneBlackoutColour.Size = New System.Drawing.Size(146, 23)
        Me.cmdSceneBlackoutColour.TabIndex = 260
        Me.cmdSceneBlackoutColour.Text = "Scene Blackout Colour"
        Me.cmdSceneBlackoutColour.UseVisualStyleBackColor = True
        '
        'lblChannelFillColour
        '
        Me.lblChannelFillColour.BackColor = System.Drawing.Color.Black
        Me.lblChannelFillColour.Location = New System.Drawing.Point(160, 578)
        Me.lblChannelFillColour.Name = "lblChannelFillColour"
        Me.lblChannelFillColour.Size = New System.Drawing.Size(100, 23)
        Me.lblChannelFillColour.TabIndex = 259
        Me.lblChannelFillColour.Text = "..."
        Me.lblChannelFillColour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblChannelBackColour
        '
        Me.lblChannelBackColour.BackColor = System.Drawing.Color.DimGray
        Me.lblChannelBackColour.Location = New System.Drawing.Point(160, 549)
        Me.lblChannelBackColour.Name = "lblChannelBackColour"
        Me.lblChannelBackColour.Size = New System.Drawing.Size(100, 23)
        Me.lblChannelBackColour.TabIndex = 258
        Me.lblChannelBackColour.Text = "..."
        Me.lblChannelBackColour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblChannelBulletColour
        '
        Me.lblChannelBulletColour.BackColor = System.Drawing.Color.Magenta
        Me.lblChannelBulletColour.Location = New System.Drawing.Point(160, 520)
        Me.lblChannelBulletColour.Name = "lblChannelBulletColour"
        Me.lblChannelBulletColour.Size = New System.Drawing.Size(100, 23)
        Me.lblChannelBulletColour.TabIndex = 257
        Me.lblChannelBulletColour.Text = "..."
        Me.lblChannelBulletColour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdChannelFillColour
        '
        Me.cmdChannelFillColour.Location = New System.Drawing.Point(8, 578)
        Me.cmdChannelFillColour.Name = "cmdChannelFillColour"
        Me.cmdChannelFillColour.Size = New System.Drawing.Size(146, 23)
        Me.cmdChannelFillColour.TabIndex = 256
        Me.cmdChannelFillColour.Text = "Channel Fill Colour"
        Me.cmdChannelFillColour.UseVisualStyleBackColor = True
        '
        'cmdChannelBackColour
        '
        Me.cmdChannelBackColour.Location = New System.Drawing.Point(8, 549)
        Me.cmdChannelBackColour.Name = "cmdChannelBackColour"
        Me.cmdChannelBackColour.Size = New System.Drawing.Size(146, 23)
        Me.cmdChannelBackColour.TabIndex = 255
        Me.cmdChannelBackColour.Text = "Channel Back Colour"
        Me.cmdChannelBackColour.UseVisualStyleBackColor = True
        '
        'cmdChannelBulletColour
        '
        Me.cmdChannelBulletColour.Location = New System.Drawing.Point(8, 520)
        Me.cmdChannelBulletColour.Name = "cmdChannelBulletColour"
        Me.cmdChannelBulletColour.Size = New System.Drawing.Size(146, 23)
        Me.cmdChannelBulletColour.TabIndex = 254
        Me.cmdChannelBulletColour.Text = "Channel Bullet Colour"
        Me.cmdChannelBulletColour.UseVisualStyleBackColor = True
        '
        'chkLoadonChange
        '
        Me.chkLoadonChange.AutoSize = True
        Me.chkLoadonChange.ForeColor = System.Drawing.Color.Lime
        Me.chkLoadonChange.Location = New System.Drawing.Point(8, 86)
        Me.chkLoadonChange.Name = "chkLoadonChange"
        Me.chkLoadonChange.Size = New System.Drawing.Size(105, 17)
        Me.chkLoadonChange.TabIndex = 250
        Me.chkLoadonChange.Text = "Load on Change"
        Me.chkLoadonChange.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Lime
        Me.Label1.Location = New System.Drawing.Point(5, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 246
        Me.Label1.Text = "Max Channels:"
        '
        'numEndChannel
        '
        Me.numEndChannel.Location = New System.Drawing.Point(8, 35)
        Me.numEndChannel.Maximum = New Decimal(New Integer() {2048, 0, 0, 0})
        Me.numEndChannel.Minimum = New Decimal(New Integer() {80, 0, 0, 0})
        Me.numEndChannel.Name = "numEndChannel"
        Me.numEndChannel.Size = New System.Drawing.Size(90, 20)
        Me.numEndChannel.TabIndex = 245
        Me.numEndChannel.Value = New Decimal(New Integer() {512, 0, 0, 0})
        '
        'tbpMarsSettings
        '
        Me.tbpMarsSettings.Controls.Add(Me.Button1)
        Me.tbpMarsSettings.Controls.Add(Me.cmdSendAll)
        Me.tbpMarsSettings.Controls.Add(Me.Label8)
        Me.tbpMarsSettings.Controls.Add(Me.numMarsLargeFaders)
        Me.tbpMarsSettings.Controls.Add(Me.txtMarsDebug)
        Me.tbpMarsSettings.Location = New System.Drawing.Point(4, 22)
        Me.tbpMarsSettings.Name = "tbpMarsSettings"
        Me.tbpMarsSettings.Size = New System.Drawing.Size(1826, 1061)
        Me.tbpMarsSettings.TabIndex = 6
        Me.tbpMarsSettings.Text = "Mars"
        Me.tbpMarsSettings.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1294, 336)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 45)
        Me.Button1.TabIndex = 574
        Me.Button1.Text = "Hello"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdSendAll
        '
        Me.cmdSendAll.Location = New System.Drawing.Point(1198, 336)
        Me.cmdSendAll.Name = "cmdSendAll"
        Me.cmdSendAll.Size = New System.Drawing.Size(90, 45)
        Me.cmdSendAll.TabIndex = 573
        Me.cmdSendAll.Text = "Send All"
        Me.cmdSendAll.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 320
        Me.Label8.Text = "Large Faders:"
        '
        'numMarsLargeFaders
        '
        Me.numMarsLargeFaders.Location = New System.Drawing.Point(86, 21)
        Me.numMarsLargeFaders.Name = "numMarsLargeFaders"
        Me.numMarsLargeFaders.Size = New System.Drawing.Size(50, 20)
        Me.numMarsLargeFaders.TabIndex = 319
        Me.numMarsLargeFaders.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'txtMarsDebug
        '
        Me.txtMarsDebug.Location = New System.Drawing.Point(1198, 8)
        Me.txtMarsDebug.Multiline = True
        Me.txtMarsDebug.Name = "txtMarsDebug"
        Me.txtMarsDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMarsDebug.Size = New System.Drawing.Size(607, 322)
        Me.txtMarsDebug.TabIndex = 318
        '
        'chkAsioMode
        '
        Me.chkAsioMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkAsioMode.AutoSize = True
        Me.chkAsioMode.Enabled = False
        Me.chkAsioMode.ForeColor = System.Drawing.Color.Lime
        Me.chkAsioMode.Location = New System.Drawing.Point(1403, 7)
        Me.chkAsioMode.Name = "chkAsioMode"
        Me.chkAsioMode.Size = New System.Drawing.Size(126, 17)
        Me.chkAsioMode.TabIndex = 344
        Me.chkAsioMode.Text = "Turn on ASIO Output"
        Me.chkAsioMode.UseVisualStyleBackColor = False
        Me.chkAsioMode.Visible = False
        '
        'lblMaster
        '
        Me.lblMaster.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMaster.AutoSize = True
        Me.lblMaster.ForeColor = System.Drawing.Color.Lime
        Me.lblMaster.Location = New System.Drawing.Point(1848, 9)
        Me.lblMaster.Name = "lblMaster"
        Me.lblMaster.Size = New System.Drawing.Size(42, 13)
        Me.lblMaster.TabIndex = 201
        Me.lblMaster.Text = "Master:"
        '
        'numChangeMS
        '
        Me.numChangeMS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numChangeMS.Location = New System.Drawing.Point(1841, 354)
        Me.numChangeMS.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numChangeMS.Name = "numChangeMS"
        Me.numChangeMS.Size = New System.Drawing.Size(57, 20)
        Me.numChangeMS.TabIndex = 278
        Me.numChangeMS.Value = New Decimal(New Integer() {2000, 0, 0, 0})
        '
        'cmdMasterFull
        '
        Me.cmdMasterFull.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdMasterFull.Location = New System.Drawing.Point(1840, 325)
        Me.cmdMasterFull.Name = "cmdMasterFull"
        Me.cmdMasterFull.Size = New System.Drawing.Size(60, 23)
        Me.cmdMasterFull.TabIndex = 277
        Me.cmdMasterFull.Text = "Full"
        Me.cmdMasterFull.UseVisualStyleBackColor = True
        '
        'cmdMasterBlackout
        '
        Me.cmdMasterBlackout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdMasterBlackout.Location = New System.Drawing.Point(1840, 296)
        Me.cmdMasterBlackout.Name = "cmdMasterBlackout"
        Me.cmdMasterBlackout.Size = New System.Drawing.Size(60, 23)
        Me.cmdMasterBlackout.TabIndex = 276
        Me.cmdMasterBlackout.Text = "Blackout"
        Me.cmdMasterBlackout.UseVisualStyleBackColor = True
        '
        'txtMaster
        '
        Me.txtMaster.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMaster.Location = New System.Drawing.Point(1850, 270)
        Me.txtMaster.Name = "txtMaster"
        Me.txtMaster.Size = New System.Drawing.Size(42, 20)
        Me.txtMaster.TabIndex = 275
        Me.txtMaster.Text = "100"
        '
        'cmdOpenTouchpad
        '
        Me.cmdOpenTouchpad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOpenTouchpad.Location = New System.Drawing.Point(1833, 801)
        Me.cmdOpenTouchpad.Name = "cmdOpenTouchpad"
        Me.cmdOpenTouchpad.Size = New System.Drawing.Size(67, 33)
        Me.cmdOpenTouchpad.TabIndex = 281
        Me.cmdOpenTouchpad.Text = "Touchpad"
        Me.cmdOpenTouchpad.UseVisualStyleBackColor = True
        Me.cmdOpenTouchpad.Visible = False
        '
        'tmrMP3
        '
        Me.tmrMP3.Interval = 50
        '
        'tmrMP32
        '
        Me.tmrMP32.Interval = 50
        '
        'cmd4KSize
        '
        Me.cmd4KSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmd4KSize.Location = New System.Drawing.Point(524, 3)
        Me.cmd4KSize.Name = "cmd4KSize"
        Me.cmd4KSize.Size = New System.Drawing.Size(67, 23)
        Me.cmd4KSize.TabIndex = 195
        Me.cmd4KSize.Text = "4k"
        Me.cmd4KSize.UseVisualStyleBackColor = True
        Me.cmd4KSize.Visible = False
        '
        'tmrMaster
        '
        '
        'cmdColourTest
        '
        Me.cmdColourTest.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdColourTest.Location = New System.Drawing.Point(1836, 840)
        Me.cmdColourTest.Name = "cmdColourTest"
        Me.cmdColourTest.Size = New System.Drawing.Size(60, 34)
        Me.cmdColourTest.TabIndex = 313
        Me.cmdColourTest.Text = "Colour Test"
        Me.cmdColourTest.UseVisualStyleBackColor = True
        Me.cmdColourTest.Visible = False
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.Location = New System.Drawing.Point(1838, 880)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(60, 34)
        Me.Button5.TabIndex = 315
        Me.Button5.Text = "Colour Test"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'lblAudioActive
        '
        Me.lblAudioActive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAudioActive.AutoSize = True
        Me.lblAudioActive.Location = New System.Drawing.Point(1686, 8)
        Me.lblAudioActive.Name = "lblAudioActive"
        Me.lblAudioActive.Size = New System.Drawing.Size(112, 13)
        Me.lblAudioActive.TabIndex = 317
        Me.lblAudioActive.Text = "Incoming Audio Signal"
        '
        'ctxPresetLabelEditChannels
        '
        Me.ctxPresetLabelEditChannels.Name = "ctxPresetLabelEditChannels"
        Me.ctxPresetLabelEditChannels.Size = New System.Drawing.Size(210, 22)
        Me.ctxPresetLabelEditChannels.Text = "Edit Channels"
        '
        'ctxPresetRenameScene
        '
        Me.ctxPresetRenameScene.Name = "ctxPresetRenameScene"
        Me.ctxPresetRenameScene.Size = New System.Drawing.Size(210, 22)
        Me.ctxPresetRenameScene.Text = "Rename Scene"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(207, 6)
        '
        'ctxPresetLabelName
        '
        Me.ctxPresetLabelName.Name = "ctxPresetLabelName"
        Me.ctxPresetLabelName.Size = New System.Drawing.Size(210, 22)
        Me.ctxPresetLabelName.Text = "Control Name"
        '
        'ctxPresetLabelActions
        '
        Me.ctxPresetLabelActions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxPresetLabelEditChannels, Me.SaveSceneToolStripMenuItem, Me.DuplicateSceneToolStripMenuItem, Me.ctxPresetRenameScene, Me.ctxSendNext, Me.ctxSendPrevious, Me.ToolStripSeparator2, Me.ctxPresetLabelName})
        Me.ctxPresetLabelActions.Name = "ctxPresetLabelActions"
        Me.ctxPresetLabelActions.Size = New System.Drawing.Size(211, 164)
        '
        'SaveSceneToolStripMenuItem
        '
        Me.SaveSceneToolStripMenuItem.Name = "SaveSceneToolStripMenuItem"
        Me.SaveSceneToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.SaveSceneToolStripMenuItem.Text = "Save Scene to File"
        '
        'DuplicateSceneToolStripMenuItem
        '
        Me.DuplicateSceneToolStripMenuItem.Name = "DuplicateSceneToolStripMenuItem"
        Me.DuplicateSceneToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.DuplicateSceneToolStripMenuItem.Text = "Duplicate Scene"
        '
        'ctxSendNext
        '
        Me.ctxSendNext.Name = "ctxSendNext"
        Me.ctxSendNext.Size = New System.Drawing.Size(210, 22)
        Me.ctxSendNext.Text = ">> Send To Next Page"
        '
        'ctxSendPrevious
        '
        Me.ctxSendPrevious.Name = "ctxSendPrevious"
        Me.ctxSendPrevious.Size = New System.Drawing.Size(210, 22)
        Me.ctxSendPrevious.Text = "<< Send to Previous Page"
        '
        'tmrserial
        '
        Me.tmrserial.Interval = 1000
        '
        'tmrAVUCheck
        '
        Me.tmrAVUCheck.Enabled = True
        Me.tmrAVUCheck.Interval = 4000
        '
        'lblAudio2
        '
        Me.lblAudio2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAudio2.AutoSize = True
        Me.lblAudio2.Location = New System.Drawing.Point(1568, 8)
        Me.lblAudio2.Name = "lblAudio2"
        Me.lblAudio2.Size = New System.Drawing.Size(115, 13)
        Me.lblAudio2.TabIndex = 345
        Me.lblAudio2.Text = "Incoming Audio Signal:"
        '
        'barVUmeter
        '
        Me.barVUmeter.Location = New System.Drawing.Point(1846, 413)
        Me.barVUmeter.Name = "barVUmeter"
        Me.barVUmeter.Size = New System.Drawing.Size(44, 295)
        Me.barVUmeter.TabIndex = 346
        Me.barVUmeter.Value = 100
        Me.barVUmeter.Visible = False
        '
        'vsMaster
        '
        Me.vsMaster.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vsMaster.BackColor = System.Drawing.Color.White
        Me.vsMaster.BulletColor = System.Drawing.Color.Red
        Me.vsMaster.FillColor = System.Drawing.Color.Black
        Me.vsMaster.Location = New System.Drawing.Point(1849, 25)
        Me.vsMaster.Name = "vsMaster"
        Me.vsMaster.Orientation = Super_Awesome_Lighting_DMX_board_v4.modGUI.GControlOrientation.Vertical
        Me.vsMaster.Size = New System.Drawing.Size(42, 239)
        Me.vsMaster.TabIndex = 202
        Me.vsMaster.Value = 100
        '
        'lblMarsConnected
        '
        Me.lblMarsConnected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMarsConnected.AutoSize = True
        Me.lblMarsConnected.BackColor = System.Drawing.Color.Lime
        Me.lblMarsConnected.Location = New System.Drawing.Point(1258, 11)
        Me.lblMarsConnected.Name = "lblMarsConnected"
        Me.lblMarsConnected.Size = New System.Drawing.Size(85, 13)
        Me.lblMarsConnected.TabIndex = 347
        Me.lblMarsConnected.Text = "Mars Connected"
        Me.lblMarsConnected.Visible = False
        '
        'txtGithubIssue
        '
        Me.txtGithubIssue.Location = New System.Drawing.Point(780, 565)
        Me.txtGithubIssue.Multiline = True
        Me.txtGithubIssue.Name = "txtGithubIssue"
        Me.txtGithubIssue.Size = New System.Drawing.Size(486, 206)
        Me.txtGithubIssue.TabIndex = 354
        '
        'cmdSubmitIssue
        '
        Me.cmdSubmitIssue.Location = New System.Drawing.Point(1136, 777)
        Me.cmdSubmitIssue.Name = "cmdSubmitIssue"
        Me.cmdSubmitIssue.Size = New System.Drawing.Size(130, 23)
        Me.cmdSubmitIssue.TabIndex = 355
        Me.cmdSubmitIssue.Text = "Submit Issue"
        Me.cmdSubmitIssue.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Lime
        Me.Label10.Location = New System.Drawing.Point(777, 549)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(113, 13)
        Me.Label10.TabIndex = 356
        Me.Label10.Text = "Submit Issue to Github"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1904, 1121)
        Me.Controls.Add(Me.lblMarsConnected)
        Me.Controls.Add(Me.barVUmeter)
        Me.Controls.Add(Me.lblAudio2)
        Me.Controls.Add(Me.lblAudioActive)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.cmdColourTest)
        Me.Controls.Add(Me.chkAsioMode)
        Me.Controls.Add(Me.cmd4KSize)
        Me.Controls.Add(Me.cmdOpenTouchpad)
        Me.Controls.Add(Me.numChangeMS)
        Me.Controls.Add(Me.cmdMasterFull)
        Me.Controls.Add(Me.cmdMasterBlackout)
        Me.Controls.Add(Me.txtMaster)
        Me.Controls.Add(Me.vsMaster)
        Me.Controls.Add(Me.lblMaster)
        Me.Controls.Add(Me.tbcControls1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KnightLight"
        Me.tbcControls1.ResumeLayout(False)
        Me.tbpBanks.ResumeLayout(False)
        Me.tbpPresets.ResumeLayout(False)
        Me.tbpPresets.PerformLayout()
        Me.pnlMusicplayers.ResumeLayout(False)
        CType(Me.trkPresetsVolume2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkPresetsVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpMusic.ResumeLayout(False)
        Me.tbpMusic.PerformLayout()
        CType(Me.numFadeIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFadeOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxDramaChangesActions.ResumeLayout(False)
        CType(Me.trkMusicVolume2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkMusicVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpScriptChanges.ResumeLayout(False)
        Me.tbpScriptChanges.PerformLayout()
        CType(Me.trkDramaViewVolume2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkDramaViewVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpSettings.ResumeLayout(False)
        Me.tbpSettings.PerformLayout()
        CType(Me.numEndChannel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpMarsSettings.ResumeLayout(False)
        Me.tbpMarsSettings.PerformLayout()
        CType(Me.numMarsLargeFaders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numChangeMS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxPresetLabelActions.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbcControls1 As TabControl
    Friend WithEvents tbpPresets As TabPage
    Friend WithEvents lblMaster As Label
    Friend WithEvents vsMaster As GScrollBar
    Friend WithEvents numChangeMS As NumericUpDown
    Friend WithEvents cmdMasterFull As Button
    Friend WithEvents cmdMasterBlackout As Button
    Friend WithEvents txtMaster As TextBox
    Friend WithEvents cmdOpenTouchpad As Button
    Public WithEvents tmrMP3 As Timer
    Public WithEvents tmrMP32 As Timer
    Friend WithEvents tbpMusic As TabPage
    Friend WithEvents tbpScriptChanges As TabPage
    Friend WithEvents tbpSettings As TabPage
    Friend WithEvents tbpBanks As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents numEndChannel As NumericUpDown
    Friend WithEvents cmdBankDelete As Button
    Friend WithEvents cmdBankRename As Button
    Friend WithEvents cmdBankNew As Button
    Friend WithEvents chkLoadonChange As CheckBox
    Friend WithEvents lstBanks As ListBox
    Friend WithEvents cmdEditUpdate As Button
    Friend WithEvents txtEditTime As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents numFadeIn As NumericUpDown
    Friend WithEvents lblFadeIn As Label
    Friend WithEvents numFadeOut As NumericUpDown
    Friend WithEvents lblFadeOut As Label
    Friend WithEvents lstSongEditPresets As ListBox
    Friend WithEvents cmdEditSongCopyNew As Button
    Friend WithEvents cmdEditSongSave As Button
    Friend WithEvents cmdCreatelink As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents lbleditRemaining As Label
    Friend WithEvents lbleditPositionMilli As Label
    Friend WithEvents lbleditposition As Label
    Friend WithEvents cmdEditStop As Button
    Friend WithEvents cmdEditPlay As Button
    Friend WithEvents chkEnableSongEdit As CheckBox
    Friend WithEvents cmdMusicSkip2 As Button
    Friend WithEvents cmdMusicSkip As Button
    Friend WithEvents lblMusicMP3PositionMilli2 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblMusicMP3Position2 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblMusicMP3Duration2 As Label
    Friend WithEvents cmdMusicStop2 As Button
    Friend WithEvents cmdMusicPlay2 As Button
    Friend WithEvents trkMusicVolume2 As TrackBar
    Friend WithEvents lstMusicSongs2 As ListBox
    Friend WithEvents lblMusicMP3PositionMilli As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblMusicMP3Position As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblMusicMP3Duration As Label
    Friend WithEvents cmdMusicStop As Button
    Friend WithEvents cmdMusicPlay As Button
    Friend WithEvents lstMusicSongs As ListBox
    Friend WithEvents trkMusicVolume As TrackBar
    Friend WithEvents vSongEdit As GScrollBar
    Friend WithEvents cmdPresetP7 As Button
    Friend WithEvents cmdPresetP8 As Button
    Friend WithEvents cmdPresetP5 As Button
    Friend WithEvents cmdPresetP6 As Button
    Friend WithEvents cmdPresetP3 As Button
    Friend WithEvents cmdPresetP4 As Button
    Friend WithEvents cmdPresetsBlackoutAllInstant As Button
    Friend WithEvents cmdPresetsBlackoutAllTimer As Button
    Friend WithEvents cmdPresetP1 As Button
    Friend WithEvents cmdPresetP2 As Button
    Friend WithEvents cmdReloadPresetLocations As Button
    Friend WithEvents cmd4KSize As Button
    Friend WithEvents cmdPresetsSkip2 As Button
    Friend WithEvents cmdPresetsSkip As Button
    Friend WithEvents lblPresetsMP3PositionMilli2 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents lblPresetsMP3Position2 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents lblPresetsMP3Duration2 As Label
    Friend WithEvents cmdPresetsStop2 As Button
    Friend WithEvents cmdPresetsPlay2 As Button
    Friend WithEvents trkPresetsVolume2 As TrackBar
    Friend WithEvents lstPresetsSongs2 As ListBox
    Friend WithEvents lblPresetsMP3PositionMilli As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents lblPresetsMP3Position As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents lblPresetsMP3Duration As Label
    Friend WithEvents cmdPresetsStop As Button
    Friend WithEvents cmdPresetsPlay As Button
    Friend WithEvents lstPresetsSongs As ListBox
    Friend WithEvents trkPresetsVolume As TrackBar
    Friend WithEvents cmdDramaViewSkip2 As Button
    Friend WithEvents cmdDramaViewSkip As Button
    Friend WithEvents lblDramaViewMP3PositionMilli2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblDramaViewMP3Position2 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents lblDramaViewMP3Duration2 As Label
    Friend WithEvents cmdDramaViewStop2 As Button
    Friend WithEvents cmdDramaViewPlay2 As Button
    Friend WithEvents trkDramaViewVolume2 As TrackBar
    Friend WithEvents lstDramaViewSongs2 As ListBox
    Friend WithEvents lblDramaViewMP3PositionMilli As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents lblDramaViewMP3Position As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents lblDramaViewMP3Duration As Label
    Friend WithEvents cmdDramaViewStop As Button
    Friend WithEvents cmdDramaViewPlay As Button
    Friend WithEvents lstDramaViewSongs As ListBox
    Friend WithEvents trkDramaViewVolume As TrackBar
    Friend WithEvents lstDramaPresets As ListBox
    Friend WithEvents lblChannelFillColour As Label
    Friend WithEvents lblChannelBackColour As Label
    Friend WithEvents lblChannelBulletColour As Label
    Friend WithEvents cmdChannelFillColour As Button
    Friend WithEvents cmdChannelBackColour As Button
    Friend WithEvents cmdChannelBulletColour As Button
    Friend WithEvents cmdDramaBlackoutAllInstant As Button
    Friend WithEvents cmdDramaBlackoutAllTimer As Button
    Friend WithEvents lblUpDownTest As Label
    Friend WithEvents cmdSceneFillColour As Button
    Friend WithEvents cmdSceneUpColour As Button
    Friend WithEvents cmdSceneBlackoutColour As Button
    Friend WithEvents lblChannelNumberColour As Label
    Friend WithEvents cmdChannelNumberColour As Button
    Friend WithEvents cmdSceneLabelColour As Button
    Friend WithEvents tmrMaster As Timer
    Friend WithEvents cmdSaveSettings As Button
    Public WithEvents lblSceneFillColour As Label
    Public WithEvents lblSceneUpColour As Label
    Public WithEvents lblSceneBlackoutColour As Label
    Public WithEvents lblSceneLabelColour As Label
    Friend WithEvents cmdColourTest As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents txtSerialIn As TextBox
    Friend WithEvents cmdSerialClear As Button
    Friend WithEvents lblAudioActive As Label
    Friend WithEvents ctxPresetLabelEditChannels As ToolStripMenuItem
    Friend WithEvents ctxPresetRenameScene As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ctxPresetLabelName As ToolStripMenuItem
    Friend WithEvents ctxPresetLabelActions As ContextMenuStrip
    Friend WithEvents lstPresetsSongChanges2 As ListView
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents lstPresetsSongChanges1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents lstMusicSongChanges1 As ListView
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents lstDramaViewSongChanges2 As ListView
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Friend WithEvents lstDramaViewSongChanges1 As ListView
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents ColumnHeader19 As ColumnHeader
    Friend WithEvents ColumnHeader20 As ColumnHeader
    Friend WithEvents lstMusicSongChanges2 As ListView
    Friend WithEvents ColumnHeader21 As ColumnHeader
    Friend WithEvents ColumnHeader22 As ColumnHeader
    Friend WithEvents ColumnHeader23 As ColumnHeader
    Friend WithEvents ColumnHeader24 As ColumnHeader
    Friend WithEvents cmdReloadSongLists As Button
    Public WithEvents lblSongChangeColour As Label
    Friend WithEvents cmdSongChangeColour As Button
    Friend WithEvents ctxSendNext As ToolStripMenuItem
    Friend WithEvents ctxSendPrevious As ToolStripMenuItem
    Friend WithEvents lstCOMdevices As ListView
    Friend WithEvents ColumnHeader25 As ColumnHeader
    Friend WithEvents ColumnHeader26 As ColumnHeader
    Friend WithEvents ColumnHeader27 As ColumnHeader
    Friend WithEvents cmdRestartSerial As Button
    Friend WithEvents ColumnHeader28 As ColumnHeader
    Friend WithEvents cmdSetSoundActivation As Button
    Friend WithEvents cmdSetDMX1 As Button
    Friend WithEvents cmdSetMusic2 As Button
    Friend WithEvents cmdSetMusic1 As Button
    Friend WithEvents cmdReloadArduinoAssignments As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSCSPort As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSCSIPaddress As TextBox
    Friend WithEvents tmrserial As Timer
    Friend WithEvents cmdRepeatAssignments As Button
    Friend WithEvents lstASIOInterfaces As ListView
    Friend WithEvents ColumnHeader29 As ColumnHeader
    Friend WithEvents ColumnHeader30 As ColumnHeader
    Friend WithEvents chkAsioMode As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmdAsioDown As Button
    Friend WithEvents cmdAsioUp As Button
    Public WithEvents lblSceneBorderColour As Label
    Friend WithEvents cmdSceneBorderColor As Button
    Friend WithEvents tmrAVUCheck As Timer
    Friend WithEvents lblAudio2 As Label
    Friend WithEvents ColumnHeader31 As ColumnHeader
    Friend WithEvents SaveSceneToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DuplicateSceneToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lstStartup As ListView
    Friend WithEvents ColumnHeader32 As ColumnHeader
    Friend WithEvents ColumnHeader33 As ColumnHeader
    Friend WithEvents ColumnHeader34 As ColumnHeader
    Friend WithEvents barVUmeter As VScrollBar
    Friend WithEvents chkMusicNextFollows As CheckBox
    Friend WithEvents ctxDramaChangesActions As ContextMenuStrip
    Friend WithEvents ctxDramaEditChannels As ToolStripMenuItem
    Friend WithEvents ctxDramaSaveScene As ToolStripMenuItem
    Friend WithEvents ctxDramaDuplicateScene As ToolStripMenuItem
    Friend WithEvents ctxDramaRenameScene As ToolStripMenuItem
    Friend WithEvents cmdSetMarsConsole As Button
    Friend WithEvents cmdCOMDisconnect As Button
    Friend WithEvents lblMarsConnected As Label
    Friend WithEvents tbpMarsSettings As TabPage
    Friend WithEvents txtMarsDebug As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents numMarsLargeFaders As NumericUpDown
    Friend WithEvents pnlMusicplayers As Panel
    Friend WithEvents CtrlMusicPlayer1 As ctrlMusicPlayer
    Friend WithEvents cmdSendAll As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents cmdSubmitIssue As Button
    Friend WithEvents txtGithubIssue As TextBox
End Class

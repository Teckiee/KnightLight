<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.cmdPlay = New System.Windows.Forms.Button()
        Me.lstSongs = New System.Windows.Forms.ListBox()
        Me.lstPresets = New System.Windows.Forms.ListBox()
        Me.lstBank = New System.Windows.Forms.ListBox()
        Me.cmdMasterFull = New System.Windows.Forms.Button()
        Me.cmdSelectedFull = New System.Windows.Forms.Button()
        Me.cmdMasterBlackout = New System.Windows.Forms.Button()
        Me.cmdSelectedBlackout = New System.Windows.Forms.Button()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.txtMaster = New System.Windows.Forms.TextBox()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.cmdUnselectAll = New System.Windows.Forms.Button()
        Me.cmdSelectAll = New System.Windows.Forms.Button()
        Me.txtSelected = New System.Windows.Forms.TextBox()
        Me.cmdDown80 = New System.Windows.Forms.Button()
        Me.cmdUp80 = New System.Windows.Forms.Button()
        Me.numStartBank = New System.Windows.Forms.NumericUpDown()
        Me.ctxCMDs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SecondEachWayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdSize = New System.Windows.Forms.Button()
        Me.cmdPresetOverwrite = New System.Windows.Forms.Button()
        Me.cmdPresetNew = New System.Windows.Forms.Button()
        Me.cmdPresetRename = New System.Windows.Forms.Button()
        Me.cmdPresetDelete = New System.Windows.Forms.Button()
        Me.cmdBankNew = New System.Windows.Forms.Button()
        Me.cmdBankRename = New System.Windows.Forms.Button()
        Me.cmdBankDelete = New System.Windows.Forms.Button()
        Me.numEndChannel = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkLoadonChange = New System.Windows.Forms.CheckBox()
        Me.cmdChangePreset = New System.Windows.Forms.Button()
        Me.lblMP3Duration = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblMP3Position = New System.Windows.Forms.Label()
        Me.tmrMP3 = New System.Windows.Forms.Timer(Me.components)
        Me.lblMP3PositionMilli = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblMP3Remaining = New System.Windows.Forms.Label()
        Me.cmdManualStart = New System.Windows.Forms.Button()
        Me.cmdPresetUp = New System.Windows.Forms.Button()
        Me.cmdPresetDown = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lstSongChanges = New System.Windows.Forms.ListBox()
        Me.cmdMode = New System.Windows.Forms.Button()
        Me.lstAutomationPresets = New System.Windows.Forms.ListBox()
        Me.nudAutoMax = New System.Windows.Forms.NumericUpDown()
        Me.lblAutoMaxlbl = New System.Windows.Forms.Label()
        Me.lblAutoMinlbl = New System.Windows.Forms.Label()
        Me.nudAutoMin = New System.Windows.Forms.NumericUpDown()
        Me.chkAutoStartRandom = New System.Windows.Forms.CheckBox()
        Me.chkAutoRunning = New System.Windows.Forms.CheckBox()
        Me.lblAutoTimebetweenlbl = New System.Windows.Forms.Label()
        Me.nudAutoTimebetween = New System.Windows.Forms.NumericUpDown()
        Me.cmdTimerRestart = New System.Windows.Forms.Button()
        Me.tcDimmers = New System.Windows.Forms.TabControl()
        Me.tbpPresets = New System.Windows.Forms.TabPage()
        Me.txtTest = New System.Windows.Forms.TextBox()
        Me.tbpSongEdit = New System.Windows.Forms.TabPage()
        Me.cmdEditSongOverwrite = New System.Windows.Forms.Button()
        Me.cmdEditSongSave = New System.Windows.Forms.Button()
        Me.cmdCreatelink = New System.Windows.Forms.Button()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.lbleditPositionMilli = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbleditRemaining = New System.Windows.Forms.Label()
        Me.cmdEditStop = New System.Windows.Forms.Button()
        Me.cmdEditPlay = New System.Windows.Forms.Button()
        Me.vSongEdit = New Super_Awesome_Lighting_DMX_board_v2.GScrollBar()
        Me.cmdPresetchange = New System.Windows.Forms.Button()
        Me.cmdEditSong = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.trkVolume = New System.Windows.Forms.TrackBar()
        Me.lstMidi = New System.Windows.Forms.ListBox()
        Me.lstSongs2 = New System.Windows.Forms.ListBox()
        Me.lblMP3PositionMilli2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblMP3Position2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblMP3Duration2 = New System.Windows.Forms.Label()
        Me.cmdStop2 = New System.Windows.Forms.Button()
        Me.cmdPlay2 = New System.Windows.Forms.Button()
        Me.trkVolume2 = New System.Windows.Forms.TrackBar()
        Me.cmdSkip = New System.Windows.Forms.Button()
        Me.cmdSkip2 = New System.Windows.Forms.Button()
        Me.lstSongChanges2 = New System.Windows.Forms.ListBox()
        Me.tmrMP32 = New System.Windows.Forms.Timer(Me.components)
        Me.numChangeMS = New System.Windows.Forms.NumericUpDown()
        Me.tmrMaster = New System.Windows.Forms.Timer(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.vsMaster = New Super_Awesome_Lighting_DMX_board_v2.GScrollBar()
        Me.vsSelected = New Super_Awesome_Lighting_DMX_board_v2.GScrollBar()
        Me.lblMidiCount = New System.Windows.Forms.Label()
        Me.chkRecordspace = New System.Windows.Forms.CheckBox()
        CType(Me.numStartBank, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxCMDs.SuspendLayout()
        CType(Me.numEndChannel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAutoMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAutoMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAutoTimebetween, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcDimmers.SuspendLayout()
        Me.tbpPresets.SuspendLayout()
        Me.tbpSongEdit.SuspendLayout()
        CType(Me.trkVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkVolume2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numChangeMS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdStop
        '
        Me.cmdStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdStop.Location = New System.Drawing.Point(1303, 623)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(75, 23)
        Me.cmdStop.TabIndex = 207
        Me.cmdStop.Text = "Stop"
        Me.cmdStop.UseVisualStyleBackColor = True
        '
        'cmdPlay
        '
        Me.cmdPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPlay.Location = New System.Drawing.Point(1303, 594)
        Me.cmdPlay.Name = "cmdPlay"
        Me.cmdPlay.Size = New System.Drawing.Size(75, 23)
        Me.cmdPlay.TabIndex = 206
        Me.cmdPlay.Text = "Play"
        Me.cmdPlay.UseVisualStyleBackColor = True
        '
        'lstSongs
        '
        Me.lstSongs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstSongs.FormattingEnabled = True
        Me.lstSongs.Location = New System.Drawing.Point(1014, 594)
        Me.lstSongs.Name = "lstSongs"
        Me.lstSongs.Size = New System.Drawing.Size(283, 199)
        Me.lstSongs.TabIndex = 205
        '
        'lstPresets
        '
        Me.lstPresets.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstPresets.FormattingEnabled = True
        Me.lstPresets.Location = New System.Drawing.Point(602, 594)
        Me.lstPresets.Name = "lstPresets"
        Me.lstPresets.Size = New System.Drawing.Size(283, 394)
        Me.lstPresets.TabIndex = 204
        '
        'lstBank
        '
        Me.lstBank.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstBank.FormattingEnabled = True
        Me.lstBank.Location = New System.Drawing.Point(421, 594)
        Me.lstBank.Name = "lstBank"
        Me.lstBank.Size = New System.Drawing.Size(166, 355)
        Me.lstBank.TabIndex = 203
        '
        'cmdMasterFull
        '
        Me.cmdMasterFull.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdMasterFull.Location = New System.Drawing.Point(272, 752)
        Me.cmdMasterFull.Name = "cmdMasterFull"
        Me.cmdMasterFull.Size = New System.Drawing.Size(115, 23)
        Me.cmdMasterFull.TabIndex = 202
        Me.cmdMasterFull.Text = "Full"
        Me.cmdMasterFull.UseVisualStyleBackColor = True
        '
        'cmdSelectedFull
        '
        Me.cmdSelectedFull.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectedFull.Location = New System.Drawing.Point(75, 752)
        Me.cmdSelectedFull.Name = "cmdSelectedFull"
        Me.cmdSelectedFull.Size = New System.Drawing.Size(115, 23)
        Me.cmdSelectedFull.TabIndex = 201
        Me.cmdSelectedFull.Text = "Selected Full"
        Me.cmdSelectedFull.UseVisualStyleBackColor = True
        '
        'cmdMasterBlackout
        '
        Me.cmdMasterBlackout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdMasterBlackout.Location = New System.Drawing.Point(272, 723)
        Me.cmdMasterBlackout.Name = "cmdMasterBlackout"
        Me.cmdMasterBlackout.Size = New System.Drawing.Size(115, 23)
        Me.cmdMasterBlackout.TabIndex = 200
        Me.cmdMasterBlackout.Text = "Blackout"
        Me.cmdMasterBlackout.UseVisualStyleBackColor = True
        '
        'cmdSelectedBlackout
        '
        Me.cmdSelectedBlackout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectedBlackout.Location = New System.Drawing.Point(75, 723)
        Me.cmdSelectedBlackout.Name = "cmdSelectedBlackout"
        Me.cmdSelectedBlackout.Size = New System.Drawing.Size(115, 23)
        Me.cmdSelectedBlackout.TabIndex = 199
        Me.cmdSelectedBlackout.Text = "Selected Blackout"
        Me.cmdSelectedBlackout.UseVisualStyleBackColor = True
        '
        'Label82
        '
        Me.Label82.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label82.AutoSize = True
        Me.Label82.ForeColor = System.Drawing.Color.Lime
        Me.Label82.Location = New System.Drawing.Point(224, 639)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(42, 13)
        Me.Label82.TabIndex = 198
        Me.Label82.Text = "Master:"
        '
        'txtMaster
        '
        Me.txtMaster.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMaster.Location = New System.Drawing.Point(227, 917)
        Me.txtMaster.Name = "txtMaster"
        Me.txtMaster.Size = New System.Drawing.Size(42, 20)
        Me.txtMaster.TabIndex = 197
        Me.txtMaster.Text = "100"
        '
        'Label81
        '
        Me.Label81.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label81.AutoSize = True
        Me.Label81.ForeColor = System.Drawing.Color.Lime
        Me.Label81.Location = New System.Drawing.Point(27, 639)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(52, 13)
        Me.Label81.TabIndex = 195
        Me.Label81.Text = "Selected:"
        '
        'cmdUnselectAll
        '
        Me.cmdUnselectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdUnselectAll.Location = New System.Drawing.Point(75, 694)
        Me.cmdUnselectAll.Name = "cmdUnselectAll"
        Me.cmdUnselectAll.Size = New System.Drawing.Size(115, 23)
        Me.cmdUnselectAll.TabIndex = 194
        Me.cmdUnselectAll.Text = "Unselect All"
        Me.cmdUnselectAll.UseVisualStyleBackColor = True
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectAll.Location = New System.Drawing.Point(75, 665)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(115, 23)
        Me.cmdSelectAll.TabIndex = 193
        Me.cmdSelectAll.Text = "Select All"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        Me.cmdSelectAll.Visible = False
        '
        'txtSelected
        '
        Me.txtSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSelected.Location = New System.Drawing.Point(30, 917)
        Me.txtSelected.Name = "txtSelected"
        Me.txtSelected.Size = New System.Drawing.Size(42, 20)
        Me.txtSelected.TabIndex = 192
        Me.txtSelected.Text = "0"
        '
        'cmdDown80
        '
        Me.cmdDown80.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDown80.Location = New System.Drawing.Point(1518, 48)
        Me.cmdDown80.Name = "cmdDown80"
        Me.cmdDown80.Size = New System.Drawing.Size(39, 23)
        Me.cmdDown80.TabIndex = 190
        Me.cmdDown80.Text = "-80"
        Me.cmdDown80.UseVisualStyleBackColor = True
        '
        'cmdUp80
        '
        Me.cmdUp80.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUp80.Location = New System.Drawing.Point(1569, 48)
        Me.cmdUp80.Name = "cmdUp80"
        Me.cmdUp80.Size = New System.Drawing.Size(39, 23)
        Me.cmdUp80.TabIndex = 189
        Me.cmdUp80.Text = "+80"
        Me.cmdUp80.UseVisualStyleBackColor = True
        '
        'numStartBank
        '
        Me.numStartBank.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numStartBank.Location = New System.Drawing.Point(1518, 22)
        Me.numStartBank.Maximum = New Decimal(New Integer() {433, 0, 0, 0})
        Me.numStartBank.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numStartBank.Name = "numStartBank"
        Me.numStartBank.Size = New System.Drawing.Size(90, 20)
        Me.numStartBank.TabIndex = 188
        Me.numStartBank.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ctxCMDs
        '
        Me.ctxCMDs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NameToolStripMenuItem, Me.ToolStripSeparator1, Me.SecondEachWayToolStripMenuItem})
        Me.ctxCMDs.Name = "ctxCMDs"
        Me.ctxCMDs.Size = New System.Drawing.Size(174, 54)
        '
        'NameToolStripMenuItem
        '
        Me.NameToolStripMenuItem.Name = "NameToolStripMenuItem"
        Me.NameToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.NameToolStripMenuItem.Text = "Name"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(170, 6)
        '
        'SecondEachWayToolStripMenuItem
        '
        Me.SecondEachWayToolStripMenuItem.Name = "SecondEachWayToolStripMenuItem"
        Me.SecondEachWayToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.SecondEachWayToolStripMenuItem.Text = "1 second each way"
        '
        'cmdSize
        '
        Me.cmdSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSize.Location = New System.Drawing.Point(1538, 441)
        Me.cmdSize.Name = "cmdSize"
        Me.cmdSize.Size = New System.Drawing.Size(94, 44)
        Me.cmdSize.TabIndex = 208
        Me.cmdSize.Text = "Size"
        Me.cmdSize.UseVisualStyleBackColor = True
        '
        'cmdPresetOverwrite
        '
        Me.cmdPresetOverwrite.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetOverwrite.Location = New System.Drawing.Point(891, 682)
        Me.cmdPresetOverwrite.Name = "cmdPresetOverwrite"
        Me.cmdPresetOverwrite.Size = New System.Drawing.Size(99, 23)
        Me.cmdPresetOverwrite.TabIndex = 210
        Me.cmdPresetOverwrite.Text = "Overwrite (Save)"
        Me.cmdPresetOverwrite.UseVisualStyleBackColor = True
        '
        'cmdPresetNew
        '
        Me.cmdPresetNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetNew.Location = New System.Drawing.Point(891, 643)
        Me.cmdPresetNew.Name = "cmdPresetNew"
        Me.cmdPresetNew.Size = New System.Drawing.Size(99, 23)
        Me.cmdPresetNew.TabIndex = 209
        Me.cmdPresetNew.Text = "New"
        Me.cmdPresetNew.UseVisualStyleBackColor = True
        '
        'cmdPresetRename
        '
        Me.cmdPresetRename.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetRename.Enabled = False
        Me.cmdPresetRename.ForeColor = System.Drawing.Color.White
        Me.cmdPresetRename.Location = New System.Drawing.Point(891, 719)
        Me.cmdPresetRename.Name = "cmdPresetRename"
        Me.cmdPresetRename.Size = New System.Drawing.Size(99, 23)
        Me.cmdPresetRename.TabIndex = 211
        Me.cmdPresetRename.Text = "Rename"
        Me.cmdPresetRename.UseVisualStyleBackColor = True
        Me.cmdPresetRename.Visible = False
        '
        'cmdPresetDelete
        '
        Me.cmdPresetDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetDelete.Enabled = False
        Me.cmdPresetDelete.ForeColor = System.Drawing.Color.White
        Me.cmdPresetDelete.Location = New System.Drawing.Point(891, 758)
        Me.cmdPresetDelete.Name = "cmdPresetDelete"
        Me.cmdPresetDelete.Size = New System.Drawing.Size(99, 23)
        Me.cmdPresetDelete.TabIndex = 212
        Me.cmdPresetDelete.Text = "Delete"
        Me.cmdPresetDelete.UseVisualStyleBackColor = True
        Me.cmdPresetDelete.Visible = False
        '
        'cmdBankNew
        '
        Me.cmdBankNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdBankNew.Location = New System.Drawing.Point(421, 955)
        Me.cmdBankNew.Name = "cmdBankNew"
        Me.cmdBankNew.Size = New System.Drawing.Size(54, 23)
        Me.cmdBankNew.TabIndex = 213
        Me.cmdBankNew.Text = "New"
        Me.cmdBankNew.UseVisualStyleBackColor = True
        '
        'cmdBankRename
        '
        Me.cmdBankRename.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdBankRename.Enabled = False
        Me.cmdBankRename.ForeColor = System.Drawing.Color.White
        Me.cmdBankRename.Location = New System.Drawing.Point(481, 955)
        Me.cmdBankRename.Name = "cmdBankRename"
        Me.cmdBankRename.Size = New System.Drawing.Size(64, 23)
        Me.cmdBankRename.TabIndex = 214
        Me.cmdBankRename.Text = "Rename"
        Me.cmdBankRename.UseVisualStyleBackColor = True
        Me.cmdBankRename.Visible = False
        '
        'cmdBankDelete
        '
        Me.cmdBankDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdBankDelete.Enabled = False
        Me.cmdBankDelete.ForeColor = System.Drawing.Color.White
        Me.cmdBankDelete.Location = New System.Drawing.Point(551, 955)
        Me.cmdBankDelete.Name = "cmdBankDelete"
        Me.cmdBankDelete.Size = New System.Drawing.Size(36, 23)
        Me.cmdBankDelete.TabIndex = 215
        Me.cmdBankDelete.Text = "Del"
        Me.cmdBankDelete.UseVisualStyleBackColor = True
        Me.cmdBankDelete.Visible = False
        '
        'numEndChannel
        '
        Me.numEndChannel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numEndChannel.Location = New System.Drawing.Point(1515, 103)
        Me.numEndChannel.Maximum = New Decimal(New Integer() {512, 0, 0, 0})
        Me.numEndChannel.Minimum = New Decimal(New Integer() {80, 0, 0, 0})
        Me.numEndChannel.Name = "numEndChannel"
        Me.numEndChannel.Size = New System.Drawing.Size(90, 20)
        Me.numEndChannel.TabIndex = 216
        Me.numEndChannel.Value = New Decimal(New Integer() {512, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Lime
        Me.Label1.Location = New System.Drawing.Point(1512, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 217
        Me.Label1.Text = "Max Channels:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Lime
        Me.Label2.Location = New System.Drawing.Point(1563, 425)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 218
        Me.Label2.Text = "UpDown"
        '
        'chkLoadonChange
        '
        Me.chkLoadonChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkLoadonChange.AutoSize = True
        Me.chkLoadonChange.Enabled = False
        Me.chkLoadonChange.ForeColor = System.Drawing.Color.Lime
        Me.chkLoadonChange.Location = New System.Drawing.Point(891, 802)
        Me.chkLoadonChange.Name = "chkLoadonChange"
        Me.chkLoadonChange.Size = New System.Drawing.Size(105, 17)
        Me.chkLoadonChange.TabIndex = 219
        Me.chkLoadonChange.Text = "Load on Change"
        Me.chkLoadonChange.UseVisualStyleBackColor = False
        Me.chkLoadonChange.Visible = False
        '
        'cmdChangePreset
        '
        Me.cmdChangePreset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdChangePreset.Location = New System.Drawing.Point(891, 825)
        Me.cmdChangePreset.Name = "cmdChangePreset"
        Me.cmdChangePreset.Size = New System.Drawing.Size(99, 23)
        Me.cmdChangePreset.TabIndex = 220
        Me.cmdChangePreset.Text = "Change"
        Me.cmdChangePreset.UseVisualStyleBackColor = True
        '
        'lblMP3Duration
        '
        Me.lblMP3Duration.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMP3Duration.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMP3Duration.ForeColor = System.Drawing.Color.Lime
        Me.lblMP3Duration.Location = New System.Drawing.Point(1299, 676)
        Me.lblMP3Duration.Name = "lblMP3Duration"
        Me.lblMP3Duration.Size = New System.Drawing.Size(71, 20)
        Me.lblMP3Duration.TabIndex = 221
        Me.lblMP3Duration.Text = "00:00:00"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Lime
        Me.Label6.Location = New System.Drawing.Point(1300, 660)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 224
        Me.Label6.Text = "Duration:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Lime
        Me.Label4.Location = New System.Drawing.Point(1300, 720)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 226
        Me.Label4.Text = "Position:"
        '
        'lblMP3Position
        '
        Me.lblMP3Position.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMP3Position.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMP3Position.ForeColor = System.Drawing.Color.Lime
        Me.lblMP3Position.Location = New System.Drawing.Point(1299, 736)
        Me.lblMP3Position.Name = "lblMP3Position"
        Me.lblMP3Position.Size = New System.Drawing.Size(71, 20)
        Me.lblMP3Position.TabIndex = 225
        Me.lblMP3Position.Text = "00:00.00"
        '
        'tmrMP3
        '
        Me.tmrMP3.Interval = 10
        '
        'lblMP3PositionMilli
        '
        Me.lblMP3PositionMilli.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMP3PositionMilli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMP3PositionMilli.ForeColor = System.Drawing.Color.Lime
        Me.lblMP3PositionMilli.Location = New System.Drawing.Point(1299, 756)
        Me.lblMP3PositionMilli.Name = "lblMP3PositionMilli"
        Me.lblMP3PositionMilli.Size = New System.Drawing.Size(71, 20)
        Me.lblMP3PositionMilli.TabIndex = 227
        Me.lblMP3PositionMilli.Text = "000000"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Lime
        Me.Label3.Location = New System.Drawing.Point(1512, 812)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 229
        Me.Label3.Text = "Remaining:"
        Me.Label3.Visible = False
        '
        'lblMP3Remaining
        '
        Me.lblMP3Remaining.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMP3Remaining.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMP3Remaining.ForeColor = System.Drawing.Color.Lime
        Me.lblMP3Remaining.Location = New System.Drawing.Point(1511, 828)
        Me.lblMP3Remaining.Name = "lblMP3Remaining"
        Me.lblMP3Remaining.Size = New System.Drawing.Size(71, 20)
        Me.lblMP3Remaining.TabIndex = 228
        Me.lblMP3Remaining.Text = "00:00:00"
        Me.lblMP3Remaining.Visible = False
        '
        'cmdManualStart
        '
        Me.cmdManualStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdManualStart.Location = New System.Drawing.Point(1514, 138)
        Me.cmdManualStart.Name = "cmdManualStart"
        Me.cmdManualStart.Size = New System.Drawing.Size(75, 23)
        Me.cmdManualStart.TabIndex = 230
        Me.cmdManualStart.Text = "Manual Start"
        Me.cmdManualStart.UseVisualStyleBackColor = True
        '
        'cmdPresetUp
        '
        Me.cmdPresetUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetUp.Location = New System.Drawing.Point(891, 872)
        Me.cmdPresetUp.Name = "cmdPresetUp"
        Me.cmdPresetUp.Size = New System.Drawing.Size(54, 48)
        Me.cmdPresetUp.TabIndex = 231
        Me.cmdPresetUp.Text = "Up"
        Me.cmdPresetUp.UseVisualStyleBackColor = True
        '
        'cmdPresetDown
        '
        Me.cmdPresetDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetDown.Location = New System.Drawing.Point(891, 926)
        Me.cmdPresetDown.Name = "cmdPresetDown"
        Me.cmdPresetDown.Size = New System.Drawing.Size(54, 48)
        Me.cmdPresetDown.TabIndex = 232
        Me.cmdPresetDown.Text = "Down"
        Me.cmdPresetDown.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.ForeColor = System.Drawing.Color.Cyan
        Me.Label5.Location = New System.Drawing.Point(1512, 164)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 87)
        Me.Label5.TabIndex = 233
        Me.Label5.Text = "Note: Above Controls are NOT saved to presets or banks. They MUST be increased ma" & _
            "nually to allow for max light channels"
        '
        'lstSongChanges
        '
        Me.lstSongChanges.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstSongChanges.FormattingEnabled = True
        Me.lstSongChanges.Location = New System.Drawing.Point(1411, 633)
        Me.lstSongChanges.Name = "lstSongChanges"
        Me.lstSongChanges.Size = New System.Drawing.Size(231, 160)
        Me.lstSongChanges.TabIndex = 234
        '
        'cmdMode
        '
        Me.cmdMode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdMode.Location = New System.Drawing.Point(891, 594)
        Me.cmdMode.Name = "cmdMode"
        Me.cmdMode.Size = New System.Drawing.Size(117, 23)
        Me.cmdMode.TabIndex = 235
        Me.cmdMode.Text = "Automation Mode"
        Me.cmdMode.UseVisualStyleBackColor = True
        '
        'lstAutomationPresets
        '
        Me.lstAutomationPresets.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstAutomationPresets.FormattingEnabled = True
        Me.lstAutomationPresets.Location = New System.Drawing.Point(1014, 594)
        Me.lstAutomationPresets.Name = "lstAutomationPresets"
        Me.lstAutomationPresets.Size = New System.Drawing.Size(223, 199)
        Me.lstAutomationPresets.TabIndex = 236
        '
        'nudAutoMax
        '
        Me.nudAutoMax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nudAutoMax.Location = New System.Drawing.Point(1478, 607)
        Me.nudAutoMax.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudAutoMax.Name = "nudAutoMax"
        Me.nudAutoMax.Size = New System.Drawing.Size(90, 20)
        Me.nudAutoMax.TabIndex = 237
        Me.nudAutoMax.Value = New Decimal(New Integer() {255, 0, 0, 0})
        '
        'lblAutoMaxlbl
        '
        Me.lblAutoMaxlbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAutoMaxlbl.ForeColor = System.Drawing.Color.Lime
        Me.lblAutoMaxlbl.Location = New System.Drawing.Point(1410, 604)
        Me.lblAutoMaxlbl.Name = "lblAutoMaxlbl"
        Me.lblAutoMaxlbl.Size = New System.Drawing.Size(62, 20)
        Me.lblAutoMaxlbl.TabIndex = 238
        Me.lblAutoMaxlbl.Text = "Max:"
        '
        'lblAutoMinlbl
        '
        Me.lblAutoMinlbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAutoMinlbl.ForeColor = System.Drawing.Color.Lime
        Me.lblAutoMinlbl.Location = New System.Drawing.Point(1410, 630)
        Me.lblAutoMinlbl.Name = "lblAutoMinlbl"
        Me.lblAutoMinlbl.Size = New System.Drawing.Size(62, 20)
        Me.lblAutoMinlbl.TabIndex = 240
        Me.lblAutoMinlbl.Text = "Min:"
        '
        'nudAutoMin
        '
        Me.nudAutoMin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nudAutoMin.Location = New System.Drawing.Point(1478, 633)
        Me.nudAutoMin.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudAutoMin.Name = "nudAutoMin"
        Me.nudAutoMin.Size = New System.Drawing.Size(90, 20)
        Me.nudAutoMin.TabIndex = 239
        '
        'chkAutoStartRandom
        '
        Me.chkAutoStartRandom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkAutoStartRandom.AutoSize = True
        Me.chkAutoStartRandom.ForeColor = System.Drawing.Color.Lime
        Me.chkAutoStartRandom.Location = New System.Drawing.Point(1414, 659)
        Me.chkAutoStartRandom.Name = "chkAutoStartRandom"
        Me.chkAutoStartRandom.Size = New System.Drawing.Size(98, 17)
        Me.chkAutoStartRandom.TabIndex = 241
        Me.chkAutoStartRandom.Text = "Start Randomly"
        Me.chkAutoStartRandom.UseVisualStyleBackColor = False
        '
        'chkAutoRunning
        '
        Me.chkAutoRunning.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkAutoRunning.AutoSize = True
        Me.chkAutoRunning.ForeColor = System.Drawing.Color.Lime
        Me.chkAutoRunning.Location = New System.Drawing.Point(1420, 768)
        Me.chkAutoRunning.Name = "chkAutoRunning"
        Me.chkAutoRunning.Size = New System.Drawing.Size(66, 17)
        Me.chkAutoRunning.TabIndex = 242
        Me.chkAutoRunning.Text = "Running"
        Me.chkAutoRunning.UseVisualStyleBackColor = False
        '
        'lblAutoTimebetweenlbl
        '
        Me.lblAutoTimebetweenlbl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAutoTimebetweenlbl.ForeColor = System.Drawing.Color.Lime
        Me.lblAutoTimebetweenlbl.Location = New System.Drawing.Point(1406, 716)
        Me.lblAutoTimebetweenlbl.Name = "lblAutoTimebetweenlbl"
        Me.lblAutoTimebetweenlbl.Size = New System.Drawing.Size(80, 20)
        Me.lblAutoTimebetweenlbl.TabIndex = 244
        Me.lblAutoTimebetweenlbl.Text = "Time between:"
        '
        'nudAutoTimebetween
        '
        Me.nudAutoTimebetween.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nudAutoTimebetween.Location = New System.Drawing.Point(1492, 719)
        Me.nudAutoTimebetween.Maximum = New Decimal(New Integer() {30000, 0, 0, 0})
        Me.nudAutoTimebetween.Name = "nudAutoTimebetween"
        Me.nudAutoTimebetween.Size = New System.Drawing.Size(90, 20)
        Me.nudAutoTimebetween.TabIndex = 243
        Me.nudAutoTimebetween.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'cmdTimerRestart
        '
        Me.cmdTimerRestart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdTimerRestart.Location = New System.Drawing.Point(1492, 768)
        Me.cmdTimerRestart.Name = "cmdTimerRestart"
        Me.cmdTimerRestart.Size = New System.Drawing.Size(75, 23)
        Me.cmdTimerRestart.TabIndex = 245
        Me.cmdTimerRestart.Text = "Restart"
        Me.cmdTimerRestart.UseVisualStyleBackColor = True
        Me.cmdTimerRestart.Visible = False
        '
        'tcDimmers
        '
        Me.tcDimmers.Controls.Add(Me.tbpPresets)
        Me.tcDimmers.Controls.Add(Me.tbpSongEdit)
        Me.tcDimmers.Location = New System.Drawing.Point(12, 4)
        Me.tcDimmers.Name = "tcDimmers"
        Me.tcDimmers.SelectedIndex = 0
        Me.tcDimmers.Size = New System.Drawing.Size(1460, 584)
        Me.tcDimmers.TabIndex = 248
        Me.tcDimmers.Visible = False
        '
        'tbpPresets
        '
        Me.tbpPresets.Controls.Add(Me.txtTest)
        Me.tbpPresets.Location = New System.Drawing.Point(4, 22)
        Me.tbpPresets.Name = "tbpPresets"
        Me.tbpPresets.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpPresets.Size = New System.Drawing.Size(1452, 558)
        Me.tbpPresets.TabIndex = 0
        Me.tbpPresets.Text = "Presets"
        Me.tbpPresets.UseVisualStyleBackColor = True
        '
        'txtTest
        '
        Me.txtTest.Location = New System.Drawing.Point(400, 103)
        Me.txtTest.Multiline = True
        Me.txtTest.Name = "txtTest"
        Me.txtTest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTest.Size = New System.Drawing.Size(512, 427)
        Me.txtTest.TabIndex = 0
        Me.txtTest.Visible = False
        '
        'tbpSongEdit
        '
        Me.tbpSongEdit.Controls.Add(Me.cmdEditSongOverwrite)
        Me.tbpSongEdit.Controls.Add(Me.cmdEditSongSave)
        Me.tbpSongEdit.Controls.Add(Me.cmdCreatelink)
        Me.tbpSongEdit.Controls.Add(Me.ListBox2)
        Me.tbpSongEdit.Controls.Add(Me.ListBox1)
        Me.tbpSongEdit.Controls.Add(Me.lbleditPositionMilli)
        Me.tbpSongEdit.Controls.Add(Me.Label10)
        Me.tbpSongEdit.Controls.Add(Me.Label7)
        Me.tbpSongEdit.Controls.Add(Me.lbleditRemaining)
        Me.tbpSongEdit.Controls.Add(Me.cmdEditStop)
        Me.tbpSongEdit.Controls.Add(Me.cmdEditPlay)
        Me.tbpSongEdit.Controls.Add(Me.vSongEdit)
        Me.tbpSongEdit.Location = New System.Drawing.Point(4, 22)
        Me.tbpSongEdit.Name = "tbpSongEdit"
        Me.tbpSongEdit.Size = New System.Drawing.Size(1452, 558)
        Me.tbpSongEdit.TabIndex = 1
        Me.tbpSongEdit.Text = "Song Edit"
        '
        'cmdEditSongOverwrite
        '
        Me.cmdEditSongOverwrite.Location = New System.Drawing.Point(273, 152)
        Me.cmdEditSongOverwrite.Name = "cmdEditSongOverwrite"
        Me.cmdEditSongOverwrite.Size = New System.Drawing.Size(75, 23)
        Me.cmdEditSongOverwrite.TabIndex = 259
        Me.cmdEditSongOverwrite.Text = "Overwrite"
        Me.cmdEditSongOverwrite.UseVisualStyleBackColor = True
        '
        'cmdEditSongSave
        '
        Me.cmdEditSongSave.Location = New System.Drawing.Point(273, 301)
        Me.cmdEditSongSave.Name = "cmdEditSongSave"
        Me.cmdEditSongSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdEditSongSave.TabIndex = 258
        Me.cmdEditSongSave.Text = "Save"
        Me.cmdEditSongSave.UseVisualStyleBackColor = True
        '
        'cmdCreatelink
        '
        Me.cmdCreatelink.Location = New System.Drawing.Point(273, 112)
        Me.cmdCreatelink.Name = "cmdCreatelink"
        Me.cmdCreatelink.Size = New System.Drawing.Size(75, 23)
        Me.cmdCreatelink.TabIndex = 257
        Me.cmdCreatelink.Text = "Create link"
        Me.cmdCreatelink.UseVisualStyleBackColor = True
        '
        'ListBox2
        '
        Me.ListBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(22, 22)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(231, 355)
        Me.ListBox2.TabIndex = 256
        Me.ListBox2.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(383, 22)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(283, 394)
        Me.ListBox1.TabIndex = 255
        Me.ListBox1.Visible = False
        '
        'lbleditPositionMilli
        '
        Me.lbleditPositionMilli.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbleditPositionMilli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbleditPositionMilli.ForeColor = System.Drawing.Color.Lime
        Me.lbleditPositionMilli.Location = New System.Drawing.Point(10, 458)
        Me.lbleditPositionMilli.Name = "lbleditPositionMilli"
        Me.lbleditPositionMilli.Size = New System.Drawing.Size(71, 20)
        Me.lbleditPositionMilli.TabIndex = 254
        Me.lbleditPositionMilli.Text = "000000"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Lime
        Me.Label10.Location = New System.Drawing.Point(11, 442)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 253
        Me.Label10.Text = "Position:"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Lime
        Me.Label7.Location = New System.Drawing.Point(812, 442)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 252
        Me.Label7.Text = "Remaining:"
        '
        'lbleditRemaining
        '
        Me.lbleditRemaining.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbleditRemaining.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbleditRemaining.ForeColor = System.Drawing.Color.Lime
        Me.lbleditRemaining.Location = New System.Drawing.Point(811, 458)
        Me.lbleditRemaining.Name = "lbleditRemaining"
        Me.lbleditRemaining.Size = New System.Drawing.Size(71, 20)
        Me.lbleditRemaining.TabIndex = 251
        Me.lbleditRemaining.Text = "00:00:00"
        '
        'cmdEditStop
        '
        Me.cmdEditStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdEditStop.Location = New System.Drawing.Point(1359, 434)
        Me.cmdEditStop.Name = "cmdEditStop"
        Me.cmdEditStop.Size = New System.Drawing.Size(75, 44)
        Me.cmdEditStop.TabIndex = 250
        Me.cmdEditStop.Text = "Stop"
        Me.cmdEditStop.UseVisualStyleBackColor = True
        '
        'cmdEditPlay
        '
        Me.cmdEditPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdEditPlay.Location = New System.Drawing.Point(1073, 434)
        Me.cmdEditPlay.Name = "cmdEditPlay"
        Me.cmdEditPlay.Size = New System.Drawing.Size(75, 44)
        Me.cmdEditPlay.TabIndex = 249
        Me.cmdEditPlay.Text = "Play"
        Me.cmdEditPlay.UseVisualStyleBackColor = True
        '
        'vSongEdit
        '
        Me.vSongEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.vSongEdit.BackColor = System.Drawing.Color.White
        Me.vSongEdit.BulletColor = System.Drawing.Color.Red
        Me.vSongEdit.Enabled = False
        Me.vSongEdit.FillColor = System.Drawing.Color.Black
        Me.vSongEdit.Location = New System.Drawing.Point(14, 501)
        Me.vSongEdit.Maximum = 5000000
        Me.vSongEdit.Name = "vSongEdit"
        Me.vSongEdit.Size = New System.Drawing.Size(1420, 42)
        Me.vSongEdit.TabIndex = 248
        Me.vSongEdit.Value = 20
        '
        'cmdPresetchange
        '
        Me.cmdPresetchange.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPresetchange.Location = New System.Drawing.Point(227, 594)
        Me.cmdPresetchange.Name = "cmdPresetchange"
        Me.cmdPresetchange.Size = New System.Drawing.Size(188, 23)
        Me.cmdPresetchange.TabIndex = 249
        Me.cmdPresetchange.Text = "Dimmer controls select"
        Me.cmdPresetchange.UseVisualStyleBackColor = True
        '
        'cmdEditSong
        '
        Me.cmdEditSong.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdEditSong.Location = New System.Drawing.Point(1525, 601)
        Me.cmdEditSong.Name = "cmdEditSong"
        Me.cmdEditSong.Size = New System.Drawing.Size(117, 23)
        Me.cmdEditSong.TabIndex = 250
        Me.cmdEditSong.Text = "Edit Song"
        Me.cmdEditSong.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(1515, 546)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(117, 23)
        Me.Button1.TabIndex = 251
        Me.Button1.Text = "sort"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'trkVolume
        '
        Me.trkVolume.Location = New System.Drawing.Point(1373, 676)
        Me.trkVolume.Maximum = 100
        Me.trkVolume.Name = "trkVolume"
        Me.trkVolume.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trkVolume.Size = New System.Drawing.Size(45, 71)
        Me.trkVolume.TabIndex = 252
        Me.trkVolume.TickFrequency = 0
        Me.trkVolume.Visible = False
        '
        'lstMidi
        '
        Me.lstMidi.FormattingEnabled = True
        Me.lstMidi.Location = New System.Drawing.Point(1478, 294)
        Me.lstMidi.Name = "lstMidi"
        Me.lstMidi.Size = New System.Drawing.Size(114, 56)
        Me.lstMidi.TabIndex = 253
        '
        'lstSongs2
        '
        Me.lstSongs2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstSongs2.FormattingEnabled = True
        Me.lstSongs2.Location = New System.Drawing.Point(1014, 799)
        Me.lstSongs2.Name = "lstSongs2"
        Me.lstSongs2.Size = New System.Drawing.Size(283, 199)
        Me.lstSongs2.TabIndex = 254
        '
        'lblMP3PositionMilli2
        '
        Me.lblMP3PositionMilli2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMP3PositionMilli2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMP3PositionMilli2.ForeColor = System.Drawing.Color.Lime
        Me.lblMP3PositionMilli2.Location = New System.Drawing.Point(1299, 961)
        Me.lblMP3PositionMilli2.Name = "lblMP3PositionMilli2"
        Me.lblMP3PositionMilli2.Size = New System.Drawing.Size(71, 20)
        Me.lblMP3PositionMilli2.TabIndex = 261
        Me.lblMP3PositionMilli2.Text = "000000"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Lime
        Me.Label9.Location = New System.Drawing.Point(1300, 925)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 260
        Me.Label9.Text = "Position:"
        '
        'lblMP3Position2
        '
        Me.lblMP3Position2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMP3Position2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMP3Position2.ForeColor = System.Drawing.Color.Lime
        Me.lblMP3Position2.Location = New System.Drawing.Point(1299, 941)
        Me.lblMP3Position2.Name = "lblMP3Position2"
        Me.lblMP3Position2.Size = New System.Drawing.Size(71, 20)
        Me.lblMP3Position2.TabIndex = 259
        Me.lblMP3Position2.Text = "00:00.00"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Lime
        Me.Label12.Location = New System.Drawing.Point(1300, 865)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 258
        Me.Label12.Text = "Duration:"
        '
        'lblMP3Duration2
        '
        Me.lblMP3Duration2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMP3Duration2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMP3Duration2.ForeColor = System.Drawing.Color.Lime
        Me.lblMP3Duration2.Location = New System.Drawing.Point(1299, 881)
        Me.lblMP3Duration2.Name = "lblMP3Duration2"
        Me.lblMP3Duration2.Size = New System.Drawing.Size(71, 20)
        Me.lblMP3Duration2.TabIndex = 257
        Me.lblMP3Duration2.Text = "00:00:00"
        '
        'cmdStop2
        '
        Me.cmdStop2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdStop2.Location = New System.Drawing.Point(1303, 828)
        Me.cmdStop2.Name = "cmdStop2"
        Me.cmdStop2.Size = New System.Drawing.Size(75, 23)
        Me.cmdStop2.TabIndex = 256
        Me.cmdStop2.Text = "Stop"
        Me.cmdStop2.UseVisualStyleBackColor = True
        '
        'cmdPlay2
        '
        Me.cmdPlay2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdPlay2.Location = New System.Drawing.Point(1303, 799)
        Me.cmdPlay2.Name = "cmdPlay2"
        Me.cmdPlay2.Size = New System.Drawing.Size(75, 23)
        Me.cmdPlay2.TabIndex = 255
        Me.cmdPlay2.Text = "Play"
        Me.cmdPlay2.UseVisualStyleBackColor = True
        '
        'trkVolume2
        '
        Me.trkVolume2.Location = New System.Drawing.Point(1373, 881)
        Me.trkVolume2.Maximum = 100
        Me.trkVolume2.Name = "trkVolume2"
        Me.trkVolume2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trkVolume2.Size = New System.Drawing.Size(45, 71)
        Me.trkVolume2.TabIndex = 262
        Me.trkVolume2.TickFrequency = 0
        Me.trkVolume2.Visible = False
        '
        'cmdSkip
        '
        Me.cmdSkip.Location = New System.Drawing.Point(1303, 695)
        Me.cmdSkip.Name = "cmdSkip"
        Me.cmdSkip.Size = New System.Drawing.Size(37, 23)
        Me.cmdSkip.TabIndex = 263
        Me.cmdSkip.Text = "Skip"
        Me.cmdSkip.UseVisualStyleBackColor = True
        '
        'cmdSkip2
        '
        Me.cmdSkip2.Location = New System.Drawing.Point(1303, 901)
        Me.cmdSkip2.Name = "cmdSkip2"
        Me.cmdSkip2.Size = New System.Drawing.Size(37, 23)
        Me.cmdSkip2.TabIndex = 264
        Me.cmdSkip2.Text = "Skip"
        Me.cmdSkip2.UseVisualStyleBackColor = True
        '
        'lstSongChanges2
        '
        Me.lstSongChanges2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstSongChanges2.FormattingEnabled = True
        Me.lstSongChanges2.Location = New System.Drawing.Point(1411, 797)
        Me.lstSongChanges2.Name = "lstSongChanges2"
        Me.lstSongChanges2.Size = New System.Drawing.Size(231, 160)
        Me.lstSongChanges2.TabIndex = 265
        '
        'tmrMP32
        '
        Me.tmrMP32.Interval = 10
        '
        'numChangeMS
        '
        Me.numChangeMS.Location = New System.Drawing.Point(275, 781)
        Me.numChangeMS.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numChangeMS.Name = "numChangeMS"
        Me.numChangeMS.Size = New System.Drawing.Size(90, 20)
        Me.numChangeMS.TabIndex = 266
        Me.numChangeMS.Value = New Decimal(New Integer() {2000, 0, 0, 0})
        '
        'tmrMaster
        '
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Yellow
        Me.Label8.Location = New System.Drawing.Point(361, 809)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 267
        Me.Label8.Text = "Stopped"
        Me.Label8.Visible = False
        '
        'vsMaster
        '
        Me.vsMaster.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.vsMaster.BackColor = System.Drawing.Color.White
        Me.vsMaster.BulletColor = System.Drawing.Color.Red
        Me.vsMaster.FillColor = System.Drawing.Color.Black
        Me.vsMaster.Location = New System.Drawing.Point(227, 665)
        Me.vsMaster.Name = "vsMaster"
        Me.vsMaster.Orientation = Super_Awesome_Lighting_DMX_board_v2.modGUI.GControlOrientation.Vertical
        Me.vsMaster.Size = New System.Drawing.Size(42, 239)
        Me.vsMaster.TabIndex = 247
        Me.vsMaster.Value = 100
        '
        'vsSelected
        '
        Me.vsSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.vsSelected.BackColor = System.Drawing.Color.White
        Me.vsSelected.BulletColor = System.Drawing.Color.Red
        Me.vsSelected.FillColor = System.Drawing.Color.Black
        Me.vsSelected.Location = New System.Drawing.Point(30, 665)
        Me.vsSelected.Maximum = 255
        Me.vsSelected.Name = "vsSelected"
        Me.vsSelected.Orientation = Super_Awesome_Lighting_DMX_board_v2.modGUI.GControlOrientation.Vertical
        Me.vsSelected.Size = New System.Drawing.Size(42, 239)
        Me.vsSelected.TabIndex = 246
        '
        'lblMidiCount
        '
        Me.lblMidiCount.AutoSize = True
        Me.lblMidiCount.ForeColor = System.Drawing.Color.Lime
        Me.lblMidiCount.Location = New System.Drawing.Point(1474, 278)
        Me.lblMidiCount.Name = "lblMidiCount"
        Me.lblMidiCount.Size = New System.Drawing.Size(63, 13)
        Me.lblMidiCount.TabIndex = 308
        Me.lblMidiCount.Text = "lblMidicount"
        '
        'chkRecordspace
        '
        Me.chkRecordspace.AutoSize = True
        Me.chkRecordspace.ForeColor = System.Drawing.Color.Lime
        Me.chkRecordspace.Location = New System.Drawing.Point(1478, 356)
        Me.chkRecordspace.Name = "chkRecordspace"
        Me.chkRecordspace.Size = New System.Drawing.Size(145, 17)
        Me.chkRecordspace.TabIndex = 309
        Me.chkRecordspace.Text = "Record Spacebar events"
        Me.chkRecordspace.UseVisualStyleBackColor = True
        Me.chkRecordspace.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1654, 1002)
        Me.Controls.Add(Me.chkRecordspace)
        Me.Controls.Add(Me.lblMidiCount)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.numChangeMS)
        Me.Controls.Add(Me.lstSongChanges2)
        Me.Controls.Add(Me.cmdSkip2)
        Me.Controls.Add(Me.cmdSkip)
        Me.Controls.Add(Me.lblMP3PositionMilli2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblMP3Position2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblMP3Duration2)
        Me.Controls.Add(Me.cmdStop2)
        Me.Controls.Add(Me.cmdPlay2)
        Me.Controls.Add(Me.trkVolume2)
        Me.Controls.Add(Me.lstSongs2)
        Me.Controls.Add(Me.lstMidi)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdEditSong)
        Me.Controls.Add(Me.cmdPresetchange)
        Me.Controls.Add(Me.tcDimmers)
        Me.Controls.Add(Me.vsMaster)
        Me.Controls.Add(Me.vsSelected)
        Me.Controls.Add(Me.cmdTimerRestart)
        Me.Controls.Add(Me.lblAutoTimebetweenlbl)
        Me.Controls.Add(Me.nudAutoTimebetween)
        Me.Controls.Add(Me.chkAutoStartRandom)
        Me.Controls.Add(Me.chkAutoRunning)
        Me.Controls.Add(Me.lblAutoMinlbl)
        Me.Controls.Add(Me.nudAutoMin)
        Me.Controls.Add(Me.lblAutoMaxlbl)
        Me.Controls.Add(Me.nudAutoMax)
        Me.Controls.Add(Me.lstAutomationPresets)
        Me.Controls.Add(Me.cmdMode)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdPresetDown)
        Me.Controls.Add(Me.cmdPresetUp)
        Me.Controls.Add(Me.cmdManualStart)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblMP3Remaining)
        Me.Controls.Add(Me.lblMP3PositionMilli)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblMP3Position)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdChangePreset)
        Me.Controls.Add(Me.lblMP3Duration)
        Me.Controls.Add(Me.chkLoadonChange)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.numEndChannel)
        Me.Controls.Add(Me.cmdBankDelete)
        Me.Controls.Add(Me.cmdBankRename)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdBankNew)
        Me.Controls.Add(Me.cmdPresetDelete)
        Me.Controls.Add(Me.cmdPresetRename)
        Me.Controls.Add(Me.cmdPresetOverwrite)
        Me.Controls.Add(Me.cmdPresetNew)
        Me.Controls.Add(Me.cmdStop)
        Me.Controls.Add(Me.cmdPlay)
        Me.Controls.Add(Me.lstSongs)
        Me.Controls.Add(Me.cmdSize)
        Me.Controls.Add(Me.lstPresets)
        Me.Controls.Add(Me.lstBank)
        Me.Controls.Add(Me.cmdDown80)
        Me.Controls.Add(Me.cmdMasterFull)
        Me.Controls.Add(Me.cmdSelectedFull)
        Me.Controls.Add(Me.cmdMasterBlackout)
        Me.Controls.Add(Me.cmdSelectedBlackout)
        Me.Controls.Add(Me.Label82)
        Me.Controls.Add(Me.txtMaster)
        Me.Controls.Add(Me.cmdUp80)
        Me.Controls.Add(Me.Label81)
        Me.Controls.Add(Me.cmdUnselectAll)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.txtSelected)
        Me.Controls.Add(Me.numStartBank)
        Me.Controls.Add(Me.lstSongChanges)
        Me.Controls.Add(Me.trkVolume)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(1670, 986)
        Me.Name = "Form1"
        Me.Text = "Super Awesome Lighting DMX board v2"
        CType(Me.numStartBank, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxCMDs.ResumeLayout(False)
        CType(Me.numEndChannel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAutoMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAutoMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAutoTimebetween, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcDimmers.ResumeLayout(False)
        Me.tbpPresets.ResumeLayout(False)
        Me.tbpPresets.PerformLayout()
        Me.tbpSongEdit.ResumeLayout(False)
        Me.tbpSongEdit.PerformLayout()
        CType(Me.trkVolume, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkVolume2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numChangeMS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents cmdPlay As System.Windows.Forms.Button
    Friend WithEvents lstSongs As System.Windows.Forms.ListBox
    Friend WithEvents lstPresets As System.Windows.Forms.ListBox
    Friend WithEvents lstBank As System.Windows.Forms.ListBox
    Friend WithEvents cmdMasterFull As System.Windows.Forms.Button
    Friend WithEvents cmdSelectedFull As System.Windows.Forms.Button
    Friend WithEvents cmdMasterBlackout As System.Windows.Forms.Button
    Friend WithEvents cmdSelectedBlackout As System.Windows.Forms.Button
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents txtMaster As System.Windows.Forms.TextBox
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents cmdUnselectAll As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents txtSelected As System.Windows.Forms.TextBox
    Friend WithEvents cmdDown80 As System.Windows.Forms.Button
    Friend WithEvents cmdUp80 As System.Windows.Forms.Button
    Friend WithEvents numStartBank As System.Windows.Forms.NumericUpDown
    Friend WithEvents ctxCMDs As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdSize As System.Windows.Forms.Button
    Friend WithEvents cmdPresetOverwrite As System.Windows.Forms.Button
    Friend WithEvents cmdPresetNew As System.Windows.Forms.Button
    Friend WithEvents cmdPresetRename As System.Windows.Forms.Button
    Friend WithEvents cmdPresetDelete As System.Windows.Forms.Button
    Friend WithEvents cmdBankNew As System.Windows.Forms.Button
    Friend WithEvents cmdBankRename As System.Windows.Forms.Button
    Friend WithEvents cmdBankDelete As System.Windows.Forms.Button
    Friend WithEvents numEndChannel As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkLoadonChange As System.Windows.Forms.CheckBox
    Friend WithEvents cmdChangePreset As System.Windows.Forms.Button
    Friend WithEvents lblMP3Duration As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblMP3Position As System.Windows.Forms.Label
    Public WithEvents tmrMP3 As System.Windows.Forms.Timer
    Friend WithEvents lblMP3PositionMilli As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblMP3Remaining As System.Windows.Forms.Label
    Friend WithEvents cmdManualStart As System.Windows.Forms.Button
    Friend WithEvents cmdPresetUp As System.Windows.Forms.Button
    Friend WithEvents cmdPresetDown As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lstSongChanges As System.Windows.Forms.ListBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SecondEachWayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdMode As System.Windows.Forms.Button
    Friend WithEvents lstAutomationPresets As System.Windows.Forms.ListBox
    Friend WithEvents nudAutoMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblAutoMaxlbl As System.Windows.Forms.Label
    Friend WithEvents lblAutoMinlbl As System.Windows.Forms.Label
    Friend WithEvents nudAutoMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkAutoStartRandom As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoRunning As System.Windows.Forms.CheckBox
    Friend WithEvents lblAutoTimebetweenlbl As System.Windows.Forms.Label
    Friend WithEvents nudAutoTimebetween As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmdTimerRestart As System.Windows.Forms.Button
    Friend WithEvents vsSelected As Super_Awesome_Lighting_DMX_board_v2.GScrollBar
    Friend WithEvents vsMaster As Super_Awesome_Lighting_DMX_board_v2.GScrollBar
    Friend WithEvents tcDimmers As System.Windows.Forms.TabControl
    Friend WithEvents tbpPresets As System.Windows.Forms.TabPage
    Friend WithEvents cmdPresetchange As System.Windows.Forms.Button
    Friend WithEvents cmdEditSong As System.Windows.Forms.Button
    Friend WithEvents tbpSongEdit As System.Windows.Forms.TabPage
    Friend WithEvents vSongEdit As Super_Awesome_Lighting_DMX_board_v2.GScrollBar
    Friend WithEvents cmdEditStop As System.Windows.Forms.Button
    Friend WithEvents cmdEditPlay As System.Windows.Forms.Button
    Friend WithEvents lbleditPositionMilli As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbleditRemaining As System.Windows.Forms.Label
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents cmdCreatelink As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdEditSongSave As System.Windows.Forms.Button
    Friend WithEvents cmdEditSongOverwrite As System.Windows.Forms.Button
    Friend WithEvents txtTest As System.Windows.Forms.TextBox
    Friend WithEvents trkVolume As System.Windows.Forms.TrackBar
    Friend WithEvents lstMidi As System.Windows.Forms.ListBox
    Friend WithEvents lstSongs2 As System.Windows.Forms.ListBox
    Friend WithEvents lblMP3PositionMilli2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblMP3Position2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblMP3Duration2 As System.Windows.Forms.Label
    Friend WithEvents cmdStop2 As System.Windows.Forms.Button
    Friend WithEvents cmdPlay2 As System.Windows.Forms.Button
    Friend WithEvents trkVolume2 As System.Windows.Forms.TrackBar
    Friend WithEvents cmdSkip As System.Windows.Forms.Button
    Friend WithEvents cmdSkip2 As System.Windows.Forms.Button
    Friend WithEvents lstSongChanges2 As System.Windows.Forms.ListBox
    Public WithEvents tmrMP32 As System.Windows.Forms.Timer
    Friend WithEvents numChangeMS As System.Windows.Forms.NumericUpDown
    Friend WithEvents tmrMaster As System.Windows.Forms.Timer
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblMidiCount As System.Windows.Forms.Label
    Friend WithEvents chkRecordspace As System.Windows.Forms.CheckBox

End Class

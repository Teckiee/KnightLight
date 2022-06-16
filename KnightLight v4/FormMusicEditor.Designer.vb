<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMusicEditor
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
        Me.CustomWaves1 = New Super_Awesome_Lighting_DMX_board_v4.CustomWaves()
        Me.cmdEditUpdate = New System.Windows.Forms.Button()
        Me.txtEditTime = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.chkRecordspace = New System.Windows.Forms.CheckBox()
        Me.numFadeIn = New System.Windows.Forms.NumericUpDown()
        Me.lblFadeIn = New System.Windows.Forms.Label()
        Me.numFadeOut = New System.Windows.Forms.NumericUpDown()
        Me.lblFadeOut = New System.Windows.Forms.Label()
        Me.vSongEdit = New Super_Awesome_Lighting_DMX_board_v4.GScrollBar()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.lstSongEditPresets = New System.Windows.Forms.ListBox()
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
        Me.lstMusicSongChanges2 = New System.Windows.Forms.ListBox()
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
        Me.lstMusicSongChanges = New System.Windows.Forms.ListBox()
        Me.trkMusicVolume = New System.Windows.Forms.TrackBar()
        Me.tmrMP3 = New System.Windows.Forms.Timer(Me.components)
        Me.tmrMP32 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.numFadeIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFadeOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkMusicVolume2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkMusicVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustomWaves1
        '
        Me.CustomWaves1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CustomWaves1.Location = New System.Drawing.Point(1687, 18)
        Me.CustomWaves1.Name = "CustomWaves1"
        Me.CustomWaves1.PenColor = System.Drawing.Color.Empty
        Me.CustomWaves1.PenWidth = 0!
        Me.CustomWaves1.SamplesPerPixel = 128
        Me.CustomWaves1.Size = New System.Drawing.Size(119, 95)
        Me.CustomWaves1.StartPosition = CType(0, Long)
        Me.CustomWaves1.TabIndex = 380
        Me.CustomWaves1.Visible = False
        Me.CustomWaves1.WaveStream = Nothing
        '
        'cmdEditUpdate
        '
        Me.cmdEditUpdate.Location = New System.Drawing.Point(371, 774)
        Me.cmdEditUpdate.Name = "cmdEditUpdate"
        Me.cmdEditUpdate.Size = New System.Drawing.Size(75, 23)
        Me.cmdEditUpdate.TabIndex = 378
        Me.cmdEditUpdate.Text = "Update"
        Me.cmdEditUpdate.UseVisualStyleBackColor = True
        '
        'txtEditTime
        '
        Me.txtEditTime.Location = New System.Drawing.Point(371, 741)
        Me.txtEditTime.Name = "txtEditTime"
        Me.txtEditTime.Size = New System.Drawing.Size(88, 20)
        Me.txtEditTime.TabIndex = 377
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.Lime
        Me.Label25.Location = New System.Drawing.Point(368, 722)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(33, 13)
        Me.Label25.TabIndex = 376
        Me.Label25.Text = "Time:"
        Me.Label25.Visible = False
        '
        'chkRecordspace
        '
        Me.chkRecordspace.AutoSize = True
        Me.chkRecordspace.ForeColor = System.Drawing.Color.Lime
        Me.chkRecordspace.Location = New System.Drawing.Point(953, 687)
        Me.chkRecordspace.Name = "chkRecordspace"
        Me.chkRecordspace.Size = New System.Drawing.Size(145, 17)
        Me.chkRecordspace.TabIndex = 375
        Me.chkRecordspace.Text = "Record Spacebar events"
        Me.chkRecordspace.UseVisualStyleBackColor = True
        Me.chkRecordspace.Visible = False
        '
        'numFadeIn
        '
        Me.numFadeIn.Location = New System.Drawing.Point(371, 639)
        Me.numFadeIn.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numFadeIn.Name = "numFadeIn"
        Me.numFadeIn.Size = New System.Drawing.Size(75, 20)
        Me.numFadeIn.TabIndex = 374
        Me.numFadeIn.Visible = False
        '
        'lblFadeIn
        '
        Me.lblFadeIn.AutoSize = True
        Me.lblFadeIn.ForeColor = System.Drawing.Color.Lime
        Me.lblFadeIn.Location = New System.Drawing.Point(368, 620)
        Me.lblFadeIn.Name = "lblFadeIn"
        Me.lblFadeIn.Size = New System.Drawing.Size(46, 13)
        Me.lblFadeIn.TabIndex = 373
        Me.lblFadeIn.Text = "Fade In:"
        Me.lblFadeIn.Visible = False
        '
        'numFadeOut
        '
        Me.numFadeOut.Location = New System.Drawing.Point(371, 689)
        Me.numFadeOut.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numFadeOut.Name = "numFadeOut"
        Me.numFadeOut.Size = New System.Drawing.Size(75, 20)
        Me.numFadeOut.TabIndex = 372
        Me.numFadeOut.Visible = False
        '
        'lblFadeOut
        '
        Me.lblFadeOut.AutoSize = True
        Me.lblFadeOut.ForeColor = System.Drawing.Color.Lime
        Me.lblFadeOut.Location = New System.Drawing.Point(368, 670)
        Me.lblFadeOut.Name = "lblFadeOut"
        Me.lblFadeOut.Size = New System.Drawing.Size(54, 13)
        Me.lblFadeOut.TabIndex = 371
        Me.lblFadeOut.Text = "Fade Out:"
        Me.lblFadeOut.Visible = False
        '
        'vSongEdit
        '
        Me.vSongEdit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vSongEdit.BackColor = System.Drawing.Color.White
        Me.vSongEdit.BulletColor = System.Drawing.Color.Red
        Me.vSongEdit.FillColor = System.Drawing.Color.Black
        Me.vSongEdit.Location = New System.Drawing.Point(12, 438)
        Me.vSongEdit.Maximum = 5000000
        Me.vSongEdit.Name = "vSongEdit"
        Me.vSongEdit.Size = New System.Drawing.Size(1794, 42)
        Me.vSongEdit.TabIndex = 379
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(465, 520)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(268, 225)
        Me.ListBox1.TabIndex = 370
        Me.ListBox1.Visible = False
        '
        'lstSongEditPresets
        '
        Me.lstSongEditPresets.FormattingEnabled = True
        Me.lstSongEditPresets.Location = New System.Drawing.Point(80, 520)
        Me.lstSongEditPresets.Name = "lstSongEditPresets"
        Me.lstSongEditPresets.Size = New System.Drawing.Size(268, 355)
        Me.lstSongEditPresets.TabIndex = 369
        Me.lstSongEditPresets.Visible = False
        '
        'cmdEditSongCopyNew
        '
        Me.cmdEditSongCopyNew.Location = New System.Drawing.Point(371, 550)
        Me.cmdEditSongCopyNew.Name = "cmdEditSongCopyNew"
        Me.cmdEditSongCopyNew.Size = New System.Drawing.Size(75, 52)
        Me.cmdEditSongCopyNew.TabIndex = 368
        Me.cmdEditSongCopyNew.Text = "Copy Scene to New and create link"
        Me.cmdEditSongCopyNew.UseVisualStyleBackColor = True
        Me.cmdEditSongCopyNew.Visible = False
        '
        'cmdEditSongSave
        '
        Me.cmdEditSongSave.Location = New System.Drawing.Point(371, 821)
        Me.cmdEditSongSave.Name = "cmdEditSongSave"
        Me.cmdEditSongSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdEditSongSave.TabIndex = 367
        Me.cmdEditSongSave.Text = "Save"
        Me.cmdEditSongSave.UseVisualStyleBackColor = True
        Me.cmdEditSongSave.Visible = False
        '
        'cmdCreatelink
        '
        Me.cmdCreatelink.Location = New System.Drawing.Point(371, 521)
        Me.cmdCreatelink.Name = "cmdCreatelink"
        Me.cmdCreatelink.Size = New System.Drawing.Size(75, 23)
        Me.cmdCreatelink.TabIndex = 366
        Me.cmdCreatelink.Text = "Create link"
        Me.cmdCreatelink.UseVisualStyleBackColor = True
        Me.cmdCreatelink.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Lime
        Me.Label20.Location = New System.Drawing.Point(950, 518)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(60, 13)
        Me.Label20.TabIndex = 365
        Me.Label20.Text = "Remaining:"
        Me.Label20.Visible = False
        '
        'lbleditRemaining
        '
        Me.lbleditRemaining.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbleditRemaining.ForeColor = System.Drawing.Color.Lime
        Me.lbleditRemaining.Location = New System.Drawing.Point(949, 534)
        Me.lbleditRemaining.Name = "lbleditRemaining"
        Me.lbleditRemaining.Size = New System.Drawing.Size(71, 20)
        Me.lbleditRemaining.TabIndex = 364
        Me.lbleditRemaining.Text = "00:00:00"
        Me.lbleditRemaining.Visible = False
        '
        'lbleditPositionMilli
        '
        Me.lbleditPositionMilli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbleditPositionMilli.ForeColor = System.Drawing.Color.Lime
        Me.lbleditPositionMilli.Location = New System.Drawing.Point(12, 543)
        Me.lbleditPositionMilli.Name = "lbleditPositionMilli"
        Me.lbleditPositionMilli.Size = New System.Drawing.Size(71, 20)
        Me.lbleditPositionMilli.TabIndex = 363
        Me.lbleditPositionMilli.Text = "000000"
        Me.lbleditPositionMilli.Visible = False
        '
        'lbleditposition
        '
        Me.lbleditposition.AutoSize = True
        Me.lbleditposition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbleditposition.ForeColor = System.Drawing.Color.Lime
        Me.lbleditposition.Location = New System.Drawing.Point(13, 527)
        Me.lbleditposition.Name = "lbleditposition"
        Me.lbleditposition.Size = New System.Drawing.Size(47, 13)
        Me.lbleditposition.TabIndex = 362
        Me.lbleditposition.Text = "Position:"
        Me.lbleditposition.Visible = False
        '
        'cmdEditStop
        '
        Me.cmdEditStop.Location = New System.Drawing.Point(953, 616)
        Me.cmdEditStop.Name = "cmdEditStop"
        Me.cmdEditStop.Size = New System.Drawing.Size(75, 43)
        Me.cmdEditStop.TabIndex = 361
        Me.cmdEditStop.Text = "Stop"
        Me.cmdEditStop.UseVisualStyleBackColor = True
        Me.cmdEditStop.Visible = False
        '
        'cmdEditPlay
        '
        Me.cmdEditPlay.Location = New System.Drawing.Point(953, 567)
        Me.cmdEditPlay.Name = "cmdEditPlay"
        Me.cmdEditPlay.Size = New System.Drawing.Size(75, 43)
        Me.cmdEditPlay.TabIndex = 360
        Me.cmdEditPlay.Text = "Play"
        Me.cmdEditPlay.UseVisualStyleBackColor = True
        Me.cmdEditPlay.Visible = False
        '
        'chkEnableSongEdit
        '
        Me.chkEnableSongEdit.AutoSize = True
        Me.chkEnableSongEdit.ForeColor = System.Drawing.Color.Lime
        Me.chkEnableSongEdit.Location = New System.Drawing.Point(676, 18)
        Me.chkEnableSongEdit.Name = "chkEnableSongEdit"
        Me.chkEnableSongEdit.Size = New System.Drawing.Size(94, 17)
        Me.chkEnableSongEdit.TabIndex = 359
        Me.chkEnableSongEdit.Text = "Enable Editing"
        Me.chkEnableSongEdit.UseVisualStyleBackColor = True
        '
        'lstMusicSongChanges2
        '
        Me.lstMusicSongChanges2.FormattingEnabled = True
        Me.lstMusicSongChanges2.Location = New System.Drawing.Point(426, 215)
        Me.lstMusicSongChanges2.Name = "lstMusicSongChanges2"
        Me.lstMusicSongChanges2.Size = New System.Drawing.Size(231, 199)
        Me.lstMusicSongChanges2.TabIndex = 358
        '
        'cmdMusicSkip2
        '
        Me.cmdMusicSkip2.Location = New System.Drawing.Point(301, 319)
        Me.cmdMusicSkip2.Name = "cmdMusicSkip2"
        Me.cmdMusicSkip2.Size = New System.Drawing.Size(37, 23)
        Me.cmdMusicSkip2.TabIndex = 357
        Me.cmdMusicSkip2.Text = "Skip"
        Me.cmdMusicSkip2.UseVisualStyleBackColor = True
        '
        'cmdMusicSkip
        '
        Me.cmdMusicSkip.Location = New System.Drawing.Point(301, 113)
        Me.cmdMusicSkip.Name = "cmdMusicSkip"
        Me.cmdMusicSkip.Size = New System.Drawing.Size(37, 23)
        Me.cmdMusicSkip.TabIndex = 356
        Me.cmdMusicSkip.Text = "Skip"
        Me.cmdMusicSkip.UseVisualStyleBackColor = True
        '
        'lblMusicMP3PositionMilli2
        '
        Me.lblMusicMP3PositionMilli2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMusicMP3PositionMilli2.ForeColor = System.Drawing.Color.Lime
        Me.lblMusicMP3PositionMilli2.Location = New System.Drawing.Point(297, 379)
        Me.lblMusicMP3PositionMilli2.Name = "lblMusicMP3PositionMilli2"
        Me.lblMusicMP3PositionMilli2.Size = New System.Drawing.Size(71, 20)
        Me.lblMusicMP3PositionMilli2.TabIndex = 354
        Me.lblMusicMP3PositionMilli2.Text = "000000"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Lime
        Me.Label9.Location = New System.Drawing.Point(298, 343)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 353
        Me.Label9.Text = "Position:"
        '
        'lblMusicMP3Position2
        '
        Me.lblMusicMP3Position2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMusicMP3Position2.ForeColor = System.Drawing.Color.Lime
        Me.lblMusicMP3Position2.Location = New System.Drawing.Point(297, 359)
        Me.lblMusicMP3Position2.Name = "lblMusicMP3Position2"
        Me.lblMusicMP3Position2.Size = New System.Drawing.Size(71, 20)
        Me.lblMusicMP3Position2.TabIndex = 352
        Me.lblMusicMP3Position2.Text = "00:00.00"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Lime
        Me.Label12.Location = New System.Drawing.Point(298, 283)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 351
        Me.Label12.Text = "Duration:"
        '
        'lblMusicMP3Duration2
        '
        Me.lblMusicMP3Duration2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMusicMP3Duration2.ForeColor = System.Drawing.Color.Lime
        Me.lblMusicMP3Duration2.Location = New System.Drawing.Point(297, 299)
        Me.lblMusicMP3Duration2.Name = "lblMusicMP3Duration2"
        Me.lblMusicMP3Duration2.Size = New System.Drawing.Size(71, 20)
        Me.lblMusicMP3Duration2.TabIndex = 350
        Me.lblMusicMP3Duration2.Text = "00:00:00"
        '
        'cmdMusicStop2
        '
        Me.cmdMusicStop2.Location = New System.Drawing.Point(301, 246)
        Me.cmdMusicStop2.Name = "cmdMusicStop2"
        Me.cmdMusicStop2.Size = New System.Drawing.Size(75, 23)
        Me.cmdMusicStop2.TabIndex = 349
        Me.cmdMusicStop2.Text = "Stop"
        Me.cmdMusicStop2.UseVisualStyleBackColor = True
        '
        'cmdMusicPlay2
        '
        Me.cmdMusicPlay2.Location = New System.Drawing.Point(301, 217)
        Me.cmdMusicPlay2.Name = "cmdMusicPlay2"
        Me.cmdMusicPlay2.Size = New System.Drawing.Size(75, 23)
        Me.cmdMusicPlay2.TabIndex = 348
        Me.cmdMusicPlay2.Text = "Play"
        Me.cmdMusicPlay2.UseVisualStyleBackColor = True
        '
        'trkMusicVolume2
        '
        Me.trkMusicVolume2.Location = New System.Drawing.Point(371, 299)
        Me.trkMusicVolume2.Maximum = 100
        Me.trkMusicVolume2.Name = "trkMusicVolume2"
        Me.trkMusicVolume2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trkMusicVolume2.Size = New System.Drawing.Size(45, 71)
        Me.trkMusicVolume2.TabIndex = 355
        Me.trkMusicVolume2.TickFrequency = 0
        Me.trkMusicVolume2.Value = 100
        '
        'lstMusicSongs2
        '
        Me.lstMusicSongs2.FormattingEnabled = True
        Me.lstMusicSongs2.Location = New System.Drawing.Point(12, 217)
        Me.lstMusicSongs2.Name = "lstMusicSongs2"
        Me.lstMusicSongs2.Size = New System.Drawing.Size(283, 199)
        Me.lstMusicSongs2.TabIndex = 347
        '
        'lblMusicMP3PositionMilli
        '
        Me.lblMusicMP3PositionMilli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMusicMP3PositionMilli.ForeColor = System.Drawing.Color.Lime
        Me.lblMusicMP3PositionMilli.Location = New System.Drawing.Point(297, 174)
        Me.lblMusicMP3PositionMilli.Name = "lblMusicMP3PositionMilli"
        Me.lblMusicMP3PositionMilli.Size = New System.Drawing.Size(71, 20)
        Me.lblMusicMP3PositionMilli.TabIndex = 344
        Me.lblMusicMP3PositionMilli.Text = "000000"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Lime
        Me.Label4.Location = New System.Drawing.Point(298, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 343
        Me.Label4.Text = "Position:"
        '
        'lblMusicMP3Position
        '
        Me.lblMusicMP3Position.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMusicMP3Position.ForeColor = System.Drawing.Color.Lime
        Me.lblMusicMP3Position.Location = New System.Drawing.Point(297, 154)
        Me.lblMusicMP3Position.Name = "lblMusicMP3Position"
        Me.lblMusicMP3Position.Size = New System.Drawing.Size(71, 20)
        Me.lblMusicMP3Position.TabIndex = 342
        Me.lblMusicMP3Position.Text = "00:00.00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Lime
        Me.Label6.Location = New System.Drawing.Point(298, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 341
        Me.Label6.Text = "Duration:"
        '
        'lblMusicMP3Duration
        '
        Me.lblMusicMP3Duration.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMusicMP3Duration.ForeColor = System.Drawing.Color.Lime
        Me.lblMusicMP3Duration.Location = New System.Drawing.Point(297, 94)
        Me.lblMusicMP3Duration.Name = "lblMusicMP3Duration"
        Me.lblMusicMP3Duration.Size = New System.Drawing.Size(71, 20)
        Me.lblMusicMP3Duration.TabIndex = 340
        Me.lblMusicMP3Duration.Text = "00:00:00"
        '
        'cmdMusicStop
        '
        Me.cmdMusicStop.Location = New System.Drawing.Point(301, 41)
        Me.cmdMusicStop.Name = "cmdMusicStop"
        Me.cmdMusicStop.Size = New System.Drawing.Size(75, 23)
        Me.cmdMusicStop.TabIndex = 339
        Me.cmdMusicStop.Text = "Stop"
        Me.cmdMusicStop.UseVisualStyleBackColor = True
        '
        'cmdMusicPlay
        '
        Me.cmdMusicPlay.Location = New System.Drawing.Point(301, 12)
        Me.cmdMusicPlay.Name = "cmdMusicPlay"
        Me.cmdMusicPlay.Size = New System.Drawing.Size(75, 23)
        Me.cmdMusicPlay.TabIndex = 338
        Me.cmdMusicPlay.Text = "Play"
        Me.cmdMusicPlay.UseVisualStyleBackColor = True
        '
        'lstMusicSongs
        '
        Me.lstMusicSongs.FormattingEnabled = True
        Me.lstMusicSongs.Location = New System.Drawing.Point(12, 12)
        Me.lstMusicSongs.Name = "lstMusicSongs"
        Me.lstMusicSongs.Size = New System.Drawing.Size(283, 199)
        Me.lstMusicSongs.TabIndex = 337
        '
        'lstMusicSongChanges
        '
        Me.lstMusicSongChanges.FormattingEnabled = True
        Me.lstMusicSongChanges.Location = New System.Drawing.Point(426, 12)
        Me.lstMusicSongChanges.Name = "lstMusicSongChanges"
        Me.lstMusicSongChanges.Size = New System.Drawing.Size(231, 199)
        Me.lstMusicSongChanges.TabIndex = 345
        '
        'trkMusicVolume
        '
        Me.trkMusicVolume.Location = New System.Drawing.Point(371, 94)
        Me.trkMusicVolume.Maximum = 100
        Me.trkMusicVolume.Name = "trkMusicVolume"
        Me.trkMusicVolume.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trkMusicVolume.Size = New System.Drawing.Size(45, 71)
        Me.trkMusicVolume.TabIndex = 346
        Me.trkMusicVolume.TickFrequency = 0
        Me.trkMusicVolume.Value = 100
        '
        'tmrMP3
        '
        Me.tmrMP3.Interval = 10
        '
        'tmrMP32
        '
        Me.tmrMP32.Interval = 10
        '
        'FormMusicEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1818, 900)
        Me.ControlBox = False
        Me.Controls.Add(Me.CustomWaves1)
        Me.Controls.Add(Me.cmdEditUpdate)
        Me.Controls.Add(Me.txtEditTime)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.chkRecordspace)
        Me.Controls.Add(Me.numFadeIn)
        Me.Controls.Add(Me.lblFadeIn)
        Me.Controls.Add(Me.numFadeOut)
        Me.Controls.Add(Me.lblFadeOut)
        Me.Controls.Add(Me.vSongEdit)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.lstSongEditPresets)
        Me.Controls.Add(Me.cmdEditSongCopyNew)
        Me.Controls.Add(Me.cmdEditSongSave)
        Me.Controls.Add(Me.cmdCreatelink)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.lbleditRemaining)
        Me.Controls.Add(Me.lbleditPositionMilli)
        Me.Controls.Add(Me.lbleditposition)
        Me.Controls.Add(Me.cmdEditStop)
        Me.Controls.Add(Me.cmdEditPlay)
        Me.Controls.Add(Me.chkEnableSongEdit)
        Me.Controls.Add(Me.lstMusicSongChanges2)
        Me.Controls.Add(Me.cmdMusicSkip2)
        Me.Controls.Add(Me.cmdMusicSkip)
        Me.Controls.Add(Me.lblMusicMP3PositionMilli2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblMusicMP3Position2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblMusicMP3Duration2)
        Me.Controls.Add(Me.cmdMusicStop2)
        Me.Controls.Add(Me.cmdMusicPlay2)
        Me.Controls.Add(Me.trkMusicVolume2)
        Me.Controls.Add(Me.lstMusicSongs2)
        Me.Controls.Add(Me.lblMusicMP3PositionMilli)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblMusicMP3Position)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblMusicMP3Duration)
        Me.Controls.Add(Me.cmdMusicStop)
        Me.Controls.Add(Me.cmdMusicPlay)
        Me.Controls.Add(Me.lstMusicSongs)
        Me.Controls.Add(Me.lstMusicSongChanges)
        Me.Controls.Add(Me.trkMusicVolume)
        Me.Name = "FormMusicEditor"
        Me.Text = "FormMusicEditor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.numFadeIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFadeOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkMusicVolume2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkMusicVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CustomWaves1 As CustomWaves
    Friend WithEvents cmdEditUpdate As Button
    Friend WithEvents txtEditTime As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents chkRecordspace As CheckBox
    Friend WithEvents numFadeIn As NumericUpDown
    Friend WithEvents lblFadeIn As Label
    Friend WithEvents numFadeOut As NumericUpDown
    Friend WithEvents lblFadeOut As Label
    Friend WithEvents vSongEdit As GScrollBar
    Friend WithEvents ListBox1 As ListBox
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
    Friend WithEvents lstMusicSongChanges2 As ListBox
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
    Friend WithEvents lstMusicSongChanges As ListBox
    Friend WithEvents trkMusicVolume As TrackBar
    Public WithEvents tmrMP3 As Timer
    Public WithEvents tmrMP32 As Timer
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormChannels
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormChannels))
        Me.cmdChannelsSave = New System.Windows.Forms.Button()
        Me.cmbChannelPresetSelection = New System.Windows.Forms.ComboBox()
        Me.cmdReloadChannelLocations = New System.Windows.Forms.Button()
        Me.cmdChannelFadersDown = New System.Windows.Forms.Button()
        Me.cmdChannelFadersUp = New System.Windows.Forms.Button()
        Me.numChannelFadersStart = New System.Windows.Forms.NumericUpDown()
        Me.ctxCMDs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxDimmerAutomation = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ctxNameofbutton = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ctxFixtureLabels = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxPickRGBColourTool = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxFixtureFavourites = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxFixtureOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ctxFixtureLabelsControlName = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdSelectedFull = New System.Windows.Forms.Button()
        Me.cmdSelectedBlackout = New System.Windows.Forms.Button()
        Me.txtSelected = New System.Windows.Forms.TextBox()
        Me.lblSelectedHeader = New System.Windows.Forms.Label()
        Me.cmdBack = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnlAutomation = New System.Windows.Forms.Panel()
        Me.lstWave = New System.Windows.Forms.ListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.numSoundThreshold = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.knbPhase = New KnobControl.KnobControl()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.knbFrequency = New KnobControl.KnobControl()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.knbCenter = New KnobControl.KnobControl()
        Me.knbAmplitude = New KnobControl.KnobControl()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.knbSoundLevel = New KnobControl.KnobControl()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.knbSoundAttack = New KnobControl.KnobControl()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.knbSoundRelease = New KnobControl.KnobControl()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lstChase = New System.Windows.Forms.ListBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numChaseManyMax = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numChaseManyMin = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdChaseManySingleAdd = New System.Windows.Forms.Button()
        Me.numChaseManyIterations = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdChaseSingleAdd = New System.Windows.Forms.Button()
        Me.numChaseSingleValue = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkFadeBothWays = New System.Windows.Forms.RadioButton()
        Me.chkFadeLtoH = New System.Windows.Forms.RadioButton()
        Me.chkFadeHtoL = New System.Windows.Forms.RadioButton()
        Me.chkChaseStartRandom = New System.Windows.Forms.RadioButton()
        Me.numChaseMax = New System.Windows.Forms.NumericUpDown()
        Me.lblAutoMaxlbl = New System.Windows.Forms.Label()
        Me.numChaseMin = New System.Windows.Forms.NumericUpDown()
        Me.lblAutoMinlbl = New System.Windows.Forms.Label()
        Me.cmdChaseFadeAdd = New System.Windows.Forms.Button()
        Me.cmdChaseRemove = New System.Windows.Forms.Button()
        Me.lblEditingChannels = New System.Windows.Forms.Label()
        Me.CustomGroupBox1 = New Super_Awesome_Lighting_DMX_board_v4.CustomGroupBox()
        Me.chkLoop = New System.Windows.Forms.CheckBox()
        Me.optInOrder = New System.Windows.Forms.RadioButton()
        Me.optRandomSound = New System.Windows.Forms.RadioButton()
        Me.optRandomTimed = New System.Windows.Forms.RadioButton()
        Me.numChaseTimebetween = New System.Windows.Forms.NumericUpDown()
        Me.vsSelected = New Super_Awesome_Lighting_DMX_board_v4.GScrollBar()
        Me.txtAmplitude = New System.Windows.Forms.TextBox()
        Me.txtCenter = New System.Windows.Forms.TextBox()
        Me.txtFrequency = New System.Windows.Forms.TextBox()
        Me.txtPhase = New System.Windows.Forms.TextBox()
        CType(Me.numChannelFadersStart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxCMDs.SuspendLayout()
        Me.ctxFixtureLabels.SuspendLayout()
        Me.pnlAutomation.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.numSoundThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.numChaseManyMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numChaseManyMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numChaseManyIterations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numChaseSingleValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numChaseMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numChaseMin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CustomGroupBox1.SuspendLayout()
        CType(Me.numChaseTimebetween, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdChannelsSave
        '
        Me.cmdChannelsSave.Location = New System.Drawing.Point(544, 12)
        Me.cmdChannelsSave.Name = "cmdChannelsSave"
        Me.cmdChannelsSave.Size = New System.Drawing.Size(102, 23)
        Me.cmdChannelsSave.TabIndex = 202
        Me.cmdChannelsSave.Text = "Save (Overwrite)"
        Me.cmdChannelsSave.UseVisualStyleBackColor = True
        '
        'cmbChannelPresetSelection
        '
        Me.cmbChannelPresetSelection.FormattingEnabled = True
        Me.cmbChannelPresetSelection.Location = New System.Drawing.Point(786, 14)
        Me.cmbChannelPresetSelection.MaxDropDownItems = 20
        Me.cmbChannelPresetSelection.Name = "cmbChannelPresetSelection"
        Me.cmbChannelPresetSelection.Size = New System.Drawing.Size(398, 21)
        Me.cmbChannelPresetSelection.TabIndex = 201
        '
        'cmdReloadChannelLocations
        '
        Me.cmdReloadChannelLocations.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReloadChannelLocations.Location = New System.Drawing.Point(1268, 12)
        Me.cmdReloadChannelLocations.Name = "cmdReloadChannelLocations"
        Me.cmdReloadChannelLocations.Size = New System.Drawing.Size(102, 23)
        Me.cmdReloadChannelLocations.TabIndex = 200
        Me.cmdReloadChannelLocations.Text = "Reload Locations"
        Me.cmdReloadChannelLocations.UseVisualStyleBackColor = True
        '
        'cmdChannelFadersDown
        '
        Me.cmdChannelFadersDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdChannelFadersDown.Location = New System.Drawing.Point(1536, 12)
        Me.cmdChannelFadersDown.Name = "cmdChannelFadersDown"
        Me.cmdChannelFadersDown.Size = New System.Drawing.Size(39, 23)
        Me.cmdChannelFadersDown.TabIndex = 199
        Me.cmdChannelFadersDown.Text = "-80"
        Me.cmdChannelFadersDown.UseVisualStyleBackColor = True
        '
        'cmdChannelFadersUp
        '
        Me.cmdChannelFadersUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdChannelFadersUp.Location = New System.Drawing.Point(1587, 12)
        Me.cmdChannelFadersUp.Name = "cmdChannelFadersUp"
        Me.cmdChannelFadersUp.Size = New System.Drawing.Size(39, 23)
        Me.cmdChannelFadersUp.TabIndex = 198
        Me.cmdChannelFadersUp.Text = "+80"
        Me.cmdChannelFadersUp.UseVisualStyleBackColor = True
        '
        'numChannelFadersStart
        '
        Me.numChannelFadersStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numChannelFadersStart.Location = New System.Drawing.Point(1440, 12)
        Me.numChannelFadersStart.Maximum = New Decimal(New Integer() {2046, 0, 0, 0})
        Me.numChannelFadersStart.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numChannelFadersStart.Name = "numChannelFadersStart"
        Me.numChannelFadersStart.Size = New System.Drawing.Size(90, 20)
        Me.numChannelFadersStart.TabIndex = 197
        Me.numChannelFadersStart.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ctxCMDs
        '
        Me.ctxCMDs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxDimmerAutomation, Me.ToolStripSeparator1, Me.ctxNameofbutton})
        Me.ctxCMDs.Name = "ctxCMDs"
        Me.ctxCMDs.Size = New System.Drawing.Size(150, 54)
        '
        'ctxDimmerAutomation
        '
        Me.ctxDimmerAutomation.Name = "ctxDimmerAutomation"
        Me.ctxDimmerAutomation.Size = New System.Drawing.Size(149, 22)
        Me.ctxDimmerAutomation.Text = "Automation"
        Me.ctxDimmerAutomation.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(146, 6)
        '
        'ctxNameofbutton
        '
        Me.ctxNameofbutton.Name = "ctxNameofbutton"
        Me.ctxNameofbutton.Size = New System.Drawing.Size(149, 22)
        Me.ctxNameofbutton.Text = "Control Name"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 30000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        Me.ToolTip1.ToolTipTitle = "Description"
        '
        'ctxFixtureLabels
        '
        Me.ctxFixtureLabels.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxPickRGBColourTool, Me.ctxFixtureFavourites, Me.ctxFixtureOptions, Me.ToolStripSeparator3, Me.ctxFixtureLabelsControlName})
        Me.ctxFixtureLabels.Name = "ctxFixtureLabels"
        Me.ctxFixtureLabels.Size = New System.Drawing.Size(167, 98)
        '
        'ctxPickRGBColourTool
        '
        Me.ctxPickRGBColourTool.Name = "ctxPickRGBColourTool"
        Me.ctxPickRGBColourTool.Size = New System.Drawing.Size(166, 22)
        Me.ctxPickRGBColourTool.Text = "Pick RGB Colour"
        '
        'ctxFixtureFavourites
        '
        Me.ctxFixtureFavourites.Name = "ctxFixtureFavourites"
        Me.ctxFixtureFavourites.Size = New System.Drawing.Size(166, 22)
        Me.ctxFixtureFavourites.Text = "Favourites >"
        '
        'ctxFixtureOptions
        '
        Me.ctxFixtureOptions.Name = "ctxFixtureOptions"
        Me.ctxFixtureOptions.Size = New System.Drawing.Size(166, 22)
        Me.ctxFixtureOptions.Text = "Fixture Options >"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(163, 6)
        '
        'ctxFixtureLabelsControlName
        '
        Me.ctxFixtureLabelsControlName.Name = "ctxFixtureLabelsControlName"
        Me.ctxFixtureLabelsControlName.Size = New System.Drawing.Size(166, 22)
        Me.ctxFixtureLabelsControlName.Text = "Control Name"
        '
        'cmdSelectedFull
        '
        Me.cmdSelectedFull.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectedFull.Location = New System.Drawing.Point(6, 294)
        Me.cmdSelectedFull.Name = "cmdSelectedFull"
        Me.cmdSelectedFull.Size = New System.Drawing.Size(60, 23)
        Me.cmdSelectedFull.TabIndex = 289
        Me.cmdSelectedFull.Text = "Full"
        Me.cmdSelectedFull.UseVisualStyleBackColor = True
        '
        'cmdSelectedBlackout
        '
        Me.cmdSelectedBlackout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSelectedBlackout.Location = New System.Drawing.Point(6, 323)
        Me.cmdSelectedBlackout.Name = "cmdSelectedBlackout"
        Me.cmdSelectedBlackout.Size = New System.Drawing.Size(60, 23)
        Me.cmdSelectedBlackout.TabIndex = 288
        Me.cmdSelectedBlackout.Text = "Blackout"
        Me.cmdSelectedBlackout.UseVisualStyleBackColor = True
        '
        'txtSelected
        '
        Me.txtSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSelected.Location = New System.Drawing.Point(14, 268)
        Me.txtSelected.Name = "txtSelected"
        Me.txtSelected.Size = New System.Drawing.Size(42, 20)
        Me.txtSelected.TabIndex = 287
        Me.txtSelected.Text = "0"
        '
        'lblSelectedHeader
        '
        Me.lblSelectedHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSelectedHeader.AutoSize = True
        Me.lblSelectedHeader.ForeColor = System.Drawing.Color.Lime
        Me.lblSelectedHeader.Location = New System.Drawing.Point(8, 7)
        Me.lblSelectedHeader.Name = "lblSelectedHeader"
        Me.lblSelectedHeader.Size = New System.Drawing.Size(52, 13)
        Me.lblSelectedHeader.TabIndex = 285
        Me.lblSelectedHeader.Text = "Selected:"
        '
        'cmdBack
        '
        Me.cmdBack.Location = New System.Drawing.Point(0, 0)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(330, 45)
        Me.cmdBack.TabIndex = 290
        Me.cmdBack.Text = "Back"
        Me.cmdBack.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(1643, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 23)
        Me.Button1.TabIndex = 291
        Me.Button1.Text = "Position"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pnlAutomation
        '
        Me.pnlAutomation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAutomation.Controls.Add(Me.lstWave)
        Me.pnlAutomation.Controls.Add(Me.GroupBox3)
        Me.pnlAutomation.Controls.Add(Me.GroupBox6)
        Me.pnlAutomation.Controls.Add(Me.GroupBox5)
        Me.pnlAutomation.Controls.Add(Me.lstChase)
        Me.pnlAutomation.Controls.Add(Me.CustomGroupBox1)
        Me.pnlAutomation.Controls.Add(Me.GroupBox4)
        Me.pnlAutomation.Controls.Add(Me.GroupBox2)
        Me.pnlAutomation.Controls.Add(Me.GroupBox1)
        Me.pnlAutomation.Controls.Add(Me.cmdChaseRemove)
        Me.pnlAutomation.Controls.Add(Me.lblSelectedHeader)
        Me.pnlAutomation.Controls.Add(Me.vsSelected)
        Me.pnlAutomation.Controls.Add(Me.txtSelected)
        Me.pnlAutomation.Controls.Add(Me.cmdSelectedBlackout)
        Me.pnlAutomation.Controls.Add(Me.cmdSelectedFull)
        Me.pnlAutomation.Controls.Add(Me.lblEditingChannels)
        Me.pnlAutomation.Location = New System.Drawing.Point(1276, 41)
        Me.pnlAutomation.Name = "pnlAutomation"
        Me.pnlAutomation.Size = New System.Drawing.Size(530, 861)
        Me.pnlAutomation.TabIndex = 292
        '
        'lstWave
        '
        Me.lstWave.FormattingEnabled = True
        Me.lstWave.Items.AddRange(New Object() {"Off", "Chase", "Sine", "Square", "Triangle"})
        Me.lstWave.Location = New System.Drawing.Point(75, 358)
        Me.lstWave.Name = "lstWave"
        Me.lstWave.Size = New System.Drawing.Size(71, 82)
        Me.lstWave.TabIndex = 314
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.numSoundThreshold)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Lime
        Me.GroupBox3.Location = New System.Drawing.Point(75, 292)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(107, 60)
        Me.GroupBox3.TabIndex = 293
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Sound Threshold"
        '
        'numSoundThreshold
        '
        Me.numSoundThreshold.Location = New System.Drawing.Point(6, 19)
        Me.numSoundThreshold.Maximum = New Decimal(New Integer() {1024, 0, 0, 0})
        Me.numSoundThreshold.Minimum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numSoundThreshold.Name = "numSoundThreshold"
        Me.numSoundThreshold.Size = New System.Drawing.Size(90, 20)
        Me.numSoundThreshold.TabIndex = 270
        Me.numSoundThreshold.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.txtPhase)
        Me.GroupBox6.Controls.Add(Me.txtFrequency)
        Me.GroupBox6.Controls.Add(Me.txtCenter)
        Me.GroupBox6.Controls.Add(Me.txtAmplitude)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.knbPhase)
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.knbFrequency)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.knbCenter)
        Me.GroupBox6.Controls.Add(Me.knbAmplitude)
        Me.GroupBox6.ForeColor = System.Drawing.Color.Lime
        Me.GroupBox6.Location = New System.Drawing.Point(196, 441)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(323, 156)
        Me.GroupBox6.TabIndex = 316
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Oscillator - Not Working"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Lime
        Me.Label7.Location = New System.Drawing.Point(262, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 313
        Me.Label7.Text = "Phase"
        '
        'knbPhase
        '
        Me.knbPhase.EndAngle = 405.0!
        Me.knbPhase.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.knbPhase.KnobBackColor = System.Drawing.Color.White
        Me.knbPhase.KnobPointerStyle = KnobControl.KnobControl.KnobPointerStyles.line
        Me.knbPhase.LargeChange = 5
        Me.knbPhase.Location = New System.Drawing.Point(245, 19)
        Me.knbPhase.Maximum = 80
        Me.knbPhase.Minimum = 0
        Me.knbPhase.MouseWheelBarPartitions = 1
        Me.knbPhase.Name = "knbPhase"
        Me.knbPhase.PointerColor = System.Drawing.Color.SlateBlue
        Me.knbPhase.ScaleColor = System.Drawing.Color.Lime
        Me.knbPhase.ScaleDivisions = 6
        Me.knbPhase.ScaleFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.knbPhase.ScaleSubDivisions = 2
        Me.knbPhase.ShowLargeScale = True
        Me.knbPhase.ShowSmallScale = False
        Me.knbPhase.Size = New System.Drawing.Size(72, 72)
        Me.knbPhase.SmallChange = 1
        Me.knbPhase.StartAngle = 135.0!
        Me.knbPhase.TabIndex = 312
        Me.knbPhase.Value = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Lime
        Me.Label6.Location = New System.Drawing.Point(175, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 311
        Me.Label6.Text = "Frequency"
        '
        'knbFrequency
        '
        Me.knbFrequency.EndAngle = 405.0!
        Me.knbFrequency.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.knbFrequency.KnobBackColor = System.Drawing.Color.White
        Me.knbFrequency.KnobPointerStyle = KnobControl.KnobControl.KnobPointerStyles.line
        Me.knbFrequency.LargeChange = 5
        Me.knbFrequency.Location = New System.Drawing.Point(167, 19)
        Me.knbFrequency.Maximum = 600
        Me.knbFrequency.Minimum = 0
        Me.knbFrequency.MouseWheelBarPartitions = 1
        Me.knbFrequency.Name = "knbFrequency"
        Me.knbFrequency.PointerColor = System.Drawing.Color.SlateBlue
        Me.knbFrequency.ScaleColor = System.Drawing.Color.Lime
        Me.knbFrequency.ScaleDivisions = 6
        Me.knbFrequency.ScaleFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.knbFrequency.ScaleSubDivisions = 2
        Me.knbFrequency.ShowLargeScale = True
        Me.knbFrequency.ShowSmallScale = False
        Me.knbFrequency.Size = New System.Drawing.Size(72, 72)
        Me.knbFrequency.SmallChange = 1
        Me.knbFrequency.StartAngle = 135.0!
        Me.knbFrequency.TabIndex = 310
        Me.knbFrequency.Value = 100
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Lime
        Me.Label5.Location = New System.Drawing.Point(106, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 309
        Me.Label5.Text = "Center"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Lime
        Me.Label4.Location = New System.Drawing.Point(16, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 308
        Me.Label4.Text = "Amplitude"
        '
        'knbCenter
        '
        Me.knbCenter.EndAngle = 405.0!
        Me.knbCenter.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.knbCenter.KnobBackColor = System.Drawing.Color.White
        Me.knbCenter.KnobPointerStyle = KnobControl.KnobControl.KnobPointerStyles.line
        Me.knbCenter.LargeChange = 5
        Me.knbCenter.Location = New System.Drawing.Point(89, 19)
        Me.knbCenter.Maximum = 255
        Me.knbCenter.Minimum = 0
        Me.knbCenter.MouseWheelBarPartitions = 1
        Me.knbCenter.Name = "knbCenter"
        Me.knbCenter.PointerColor = System.Drawing.Color.SlateBlue
        Me.knbCenter.ScaleColor = System.Drawing.Color.Lime
        Me.knbCenter.ScaleDivisions = 6
        Me.knbCenter.ScaleFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.knbCenter.ScaleSubDivisions = 2
        Me.knbCenter.ShowLargeScale = True
        Me.knbCenter.ShowSmallScale = False
        Me.knbCenter.Size = New System.Drawing.Size(72, 72)
        Me.knbCenter.SmallChange = 1
        Me.knbCenter.StartAngle = 135.0!
        Me.knbCenter.TabIndex = 307
        Me.knbCenter.Value = 127
        '
        'knbAmplitude
        '
        Me.knbAmplitude.EndAngle = 405.0!
        Me.knbAmplitude.ForeColor = System.Drawing.Color.Lime
        Me.knbAmplitude.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.knbAmplitude.KnobBackColor = System.Drawing.Color.White
        Me.knbAmplitude.KnobPointerStyle = KnobControl.KnobControl.KnobPointerStyles.line
        Me.knbAmplitude.LargeChange = 5
        Me.knbAmplitude.Location = New System.Drawing.Point(11, 19)
        Me.knbAmplitude.Maximum = 512
        Me.knbAmplitude.Minimum = 0
        Me.knbAmplitude.MouseWheelBarPartitions = 1
        Me.knbAmplitude.Name = "knbAmplitude"
        Me.knbAmplitude.PointerColor = System.Drawing.Color.SlateBlue
        Me.knbAmplitude.ScaleColor = System.Drawing.Color.Lime
        Me.knbAmplitude.ScaleDivisions = 6
        Me.knbAmplitude.ScaleFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.knbAmplitude.ScaleSubDivisions = 2
        Me.knbAmplitude.ShowLargeScale = True
        Me.knbAmplitude.ShowSmallScale = False
        Me.knbAmplitude.Size = New System.Drawing.Size(72, 72)
        Me.knbAmplitude.SmallChange = 1
        Me.knbAmplitude.StartAngle = 135.0!
        Me.knbAmplitude.TabIndex = 306
        Me.knbAmplitude.Value = 255
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.knbSoundLevel)
        Me.GroupBox5.Controls.Add(Me.RadioButton1)
        Me.GroupBox5.Controls.Add(Me.knbSoundAttack)
        Me.GroupBox5.Controls.Add(Me.RadioButton2)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.RadioButton3)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.RadioButton4)
        Me.GroupBox5.Controls.Add(Me.knbSoundRelease)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Lime
        Me.GroupBox5.Location = New System.Drawing.Point(207, 682)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(297, 124)
        Me.GroupBox5.TabIndex = 292
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Sound Activation - Not Working"
        '
        'knbSoundLevel
        '
        Me.knbSoundLevel.EndAngle = 405.0!
        Me.knbSoundLevel.ForeColor = System.Drawing.Color.Lime
        Me.knbSoundLevel.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.knbSoundLevel.KnobBackColor = System.Drawing.Color.White
        Me.knbSoundLevel.KnobPointerStyle = KnobControl.KnobControl.KnobPointerStyles.line
        Me.knbSoundLevel.LargeChange = 5
        Me.knbSoundLevel.Location = New System.Drawing.Point(11, 19)
        Me.knbSoundLevel.Maximum = 100
        Me.knbSoundLevel.Minimum = 0
        Me.knbSoundLevel.Name = "knbSoundLevel"
        Me.knbSoundLevel.PointerColor = System.Drawing.Color.SlateBlue
        Me.knbSoundLevel.ScaleColor = System.Drawing.Color.Lime
        Me.knbSoundLevel.ScaleDivisions = 6
        Me.knbSoundLevel.ScaleFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.knbSoundLevel.ScaleSubDivisions = 2
        Me.knbSoundLevel.ShowLargeScale = True
        Me.knbSoundLevel.ShowSmallScale = False
        Me.knbSoundLevel.Size = New System.Drawing.Size(72, 72)
        Me.knbSoundLevel.SmallChange = 1
        Me.knbSoundLevel.StartAngle = 135.0!
        Me.knbSoundLevel.TabIndex = 306
        Me.knbSoundLevel.Value = 0
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.ForeColor = System.Drawing.Color.Lime
        Me.RadioButton1.Location = New System.Drawing.Point(240, 70)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(44, 17)
        Me.RadioButton1.TabIndex = 315
        Me.RadioButton1.Text = "Sub"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'knbSoundAttack
        '
        Me.knbSoundAttack.EndAngle = 405.0!
        Me.knbSoundAttack.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.knbSoundAttack.KnobBackColor = System.Drawing.Color.White
        Me.knbSoundAttack.KnobPointerStyle = KnobControl.KnobControl.KnobPointerStyles.line
        Me.knbSoundAttack.LargeChange = 5
        Me.knbSoundAttack.Location = New System.Drawing.Point(89, 19)
        Me.knbSoundAttack.Maximum = 100
        Me.knbSoundAttack.Minimum = 0
        Me.knbSoundAttack.Name = "knbSoundAttack"
        Me.knbSoundAttack.PointerColor = System.Drawing.Color.SlateBlue
        Me.knbSoundAttack.ScaleColor = System.Drawing.Color.Lime
        Me.knbSoundAttack.ScaleDivisions = 6
        Me.knbSoundAttack.ScaleFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.knbSoundAttack.ScaleSubDivisions = 2
        Me.knbSoundAttack.ShowLargeScale = True
        Me.knbSoundAttack.ShowSmallScale = False
        Me.knbSoundAttack.Size = New System.Drawing.Size(72, 72)
        Me.knbSoundAttack.SmallChange = 1
        Me.knbSoundAttack.StartAngle = 135.0!
        Me.knbSoundAttack.TabIndex = 307
        Me.knbSoundAttack.Value = 0
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.ForeColor = System.Drawing.Color.Lime
        Me.RadioButton2.Location = New System.Drawing.Point(240, 21)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(47, 17)
        Me.RadioButton2.TabIndex = 314
        Me.RadioButton2.Text = "High"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Lime
        Me.Label10.Location = New System.Drawing.Point(29, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 13)
        Me.Label10.TabIndex = 308
        Me.Label10.Text = "Level"
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.ForeColor = System.Drawing.Color.Lime
        Me.RadioButton3.Location = New System.Drawing.Point(240, 47)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(42, 17)
        Me.RadioButton3.TabIndex = 313
        Me.RadioButton3.Text = "Mid"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Lime
        Me.Label9.Location = New System.Drawing.Point(106, 94)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 309
        Me.Label9.Text = "Attack"
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Checked = True
        Me.RadioButton4.ForeColor = System.Drawing.Color.Lime
        Me.RadioButton4.Location = New System.Drawing.Point(240, 93)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(39, 17)
        Me.RadioButton4.TabIndex = 312
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Off"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'knbSoundRelease
        '
        Me.knbSoundRelease.EndAngle = 405.0!
        Me.knbSoundRelease.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.knbSoundRelease.KnobBackColor = System.Drawing.Color.White
        Me.knbSoundRelease.KnobPointerStyle = KnobControl.KnobControl.KnobPointerStyles.line
        Me.knbSoundRelease.LargeChange = 5
        Me.knbSoundRelease.Location = New System.Drawing.Point(167, 19)
        Me.knbSoundRelease.Maximum = 100
        Me.knbSoundRelease.Minimum = 0
        Me.knbSoundRelease.Name = "knbSoundRelease"
        Me.knbSoundRelease.PointerColor = System.Drawing.Color.SlateBlue
        Me.knbSoundRelease.ScaleColor = System.Drawing.Color.Lime
        Me.knbSoundRelease.ScaleDivisions = 6
        Me.knbSoundRelease.ScaleFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.knbSoundRelease.ScaleSubDivisions = 2
        Me.knbSoundRelease.ShowLargeScale = True
        Me.knbSoundRelease.ShowSmallScale = False
        Me.knbSoundRelease.Size = New System.Drawing.Size(72, 72)
        Me.knbSoundRelease.SmallChange = 1
        Me.knbSoundRelease.StartAngle = 135.0!
        Me.knbSoundRelease.TabIndex = 310
        Me.knbSoundRelease.Value = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Lime
        Me.Label8.Location = New System.Drawing.Point(184, 94)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 311
        Me.Label8.Text = "Release"
        '
        'lstChase
        '
        Me.lstChase.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstChase.ColumnWidth = 60
        Me.lstChase.FormattingEnabled = True
        Me.lstChase.Location = New System.Drawing.Point(73, 9)
        Me.lstChase.MultiColumn = True
        Me.lstChase.Name = "lstChase"
        Me.lstChase.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstChase.Size = New System.Drawing.Size(348, 147)
        Me.lstChase.TabIndex = 296
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.numChaseManyMax)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.numChaseManyMin)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.cmdChaseManySingleAdd)
        Me.GroupBox4.Controls.Add(Me.numChaseManyIterations)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Lime
        Me.GroupBox4.Location = New System.Drawing.Point(301, 292)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(144, 143)
        Me.GroupBox4.TabIndex = 294
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Many single values:"
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Lime
        Me.Label1.Location = New System.Drawing.Point(6, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 20)
        Me.Label1.TabIndex = 279
        Me.Label1.Text = "Iterations:"
        '
        'numChaseManyMax
        '
        Me.numChaseManyMax.Location = New System.Drawing.Point(74, 19)
        Me.numChaseManyMax.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numChaseManyMax.Name = "numChaseManyMax"
        Me.numChaseManyMax.Size = New System.Drawing.Size(60, 20)
        Me.numChaseManyMax.TabIndex = 275
        Me.numChaseManyMax.Value = New Decimal(New Integer() {255, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.Lime
        Me.Label2.Location = New System.Drawing.Point(6, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 20)
        Me.Label2.TabIndex = 276
        Me.Label2.Text = "Max:"
        '
        'numChaseManyMin
        '
        Me.numChaseManyMin.Location = New System.Drawing.Point(74, 45)
        Me.numChaseManyMin.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numChaseManyMin.Name = "numChaseManyMin"
        Me.numChaseManyMin.Size = New System.Drawing.Size(60, 20)
        Me.numChaseManyMin.TabIndex = 277
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Lime
        Me.Label3.Location = New System.Drawing.Point(6, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 20)
        Me.Label3.TabIndex = 278
        Me.Label3.Text = "Min:"
        '
        'cmdChaseManySingleAdd
        '
        Me.cmdChaseManySingleAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdChaseManySingleAdd.Location = New System.Drawing.Point(6, 100)
        Me.cmdChaseManySingleAdd.Name = "cmdChaseManySingleAdd"
        Me.cmdChaseManySingleAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmdChaseManySingleAdd.TabIndex = 274
        Me.cmdChaseManySingleAdd.Text = "^ Add"
        Me.cmdChaseManySingleAdd.UseVisualStyleBackColor = True
        '
        'numChaseManyIterations
        '
        Me.numChaseManyIterations.Location = New System.Drawing.Point(74, 74)
        Me.numChaseManyIterations.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numChaseManyIterations.Name = "numChaseManyIterations"
        Me.numChaseManyIterations.Size = New System.Drawing.Size(60, 20)
        Me.numChaseManyIterations.TabIndex = 265
        Me.numChaseManyIterations.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmdChaseSingleAdd)
        Me.GroupBox2.Controls.Add(Me.numChaseSingleValue)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Lime
        Me.GroupBox2.Location = New System.Drawing.Point(188, 294)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(107, 77)
        Me.GroupBox2.TabIndex = 292
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Single Value:"
        '
        'cmdChaseSingleAdd
        '
        Me.cmdChaseSingleAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdChaseSingleAdd.Location = New System.Drawing.Point(6, 45)
        Me.cmdChaseSingleAdd.Name = "cmdChaseSingleAdd"
        Me.cmdChaseSingleAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmdChaseSingleAdd.TabIndex = 274
        Me.cmdChaseSingleAdd.Text = "^ Add"
        Me.cmdChaseSingleAdd.UseVisualStyleBackColor = True
        '
        'numChaseSingleValue
        '
        Me.numChaseSingleValue.Location = New System.Drawing.Point(6, 19)
        Me.numChaseSingleValue.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numChaseSingleValue.Name = "numChaseSingleValue"
        Me.numChaseSingleValue.Size = New System.Drawing.Size(90, 20)
        Me.numChaseSingleValue.TabIndex = 270
        Me.numChaseSingleValue.Value = New Decimal(New Integer() {255, 0, 0, 0})
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chkFadeBothWays)
        Me.GroupBox1.Controls.Add(Me.chkFadeLtoH)
        Me.GroupBox1.Controls.Add(Me.chkFadeHtoL)
        Me.GroupBox1.Controls.Add(Me.chkChaseStartRandom)
        Me.GroupBox1.Controls.Add(Me.numChaseMax)
        Me.GroupBox1.Controls.Add(Me.lblAutoMaxlbl)
        Me.GroupBox1.Controls.Add(Me.numChaseMin)
        Me.GroupBox1.Controls.Add(Me.lblAutoMinlbl)
        Me.GroupBox1.Controls.Add(Me.cmdChaseFadeAdd)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Lime
        Me.GroupBox1.Location = New System.Drawing.Point(254, 162)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(265, 124)
        Me.GroupBox1.TabIndex = 291
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fades:"
        '
        'chkFadeBothWays
        '
        Me.chkFadeBothWays.AutoSize = True
        Me.chkFadeBothWays.Checked = True
        Me.chkFadeBothWays.Location = New System.Drawing.Point(150, 68)
        Me.chkFadeBothWays.Name = "chkFadeBothWays"
        Me.chkFadeBothWays.Size = New System.Drawing.Size(77, 17)
        Me.chkFadeBothWays.TabIndex = 274
        Me.chkFadeBothWays.TabStop = True
        Me.chkFadeBothWays.Text = "Both Ways"
        Me.chkFadeBothWays.UseVisualStyleBackColor = True
        '
        'chkFadeLtoH
        '
        Me.chkFadeLtoH.AutoSize = True
        Me.chkFadeLtoH.Location = New System.Drawing.Point(150, 19)
        Me.chkFadeLtoH.Name = "chkFadeLtoH"
        Me.chkFadeLtoH.Size = New System.Drawing.Size(108, 17)
        Me.chkFadeLtoH.TabIndex = 273
        Me.chkFadeLtoH.Text = "One Way (L to H)"
        Me.chkFadeLtoH.UseVisualStyleBackColor = True
        '
        'chkFadeHtoL
        '
        Me.chkFadeHtoL.AutoSize = True
        Me.chkFadeHtoL.Location = New System.Drawing.Point(150, 45)
        Me.chkFadeHtoL.Name = "chkFadeHtoL"
        Me.chkFadeHtoL.Size = New System.Drawing.Size(108, 17)
        Me.chkFadeHtoL.TabIndex = 272
        Me.chkFadeHtoL.Text = "One Way (H to L)"
        Me.chkFadeHtoL.UseVisualStyleBackColor = True
        '
        'chkChaseStartRandom
        '
        Me.chkChaseStartRandom.AutoSize = True
        Me.chkChaseStartRandom.Location = New System.Drawing.Point(150, 91)
        Me.chkChaseStartRandom.Name = "chkChaseStartRandom"
        Me.chkChaseStartRandom.Size = New System.Drawing.Size(97, 17)
        Me.chkChaseStartRandom.TabIndex = 271
        Me.chkChaseStartRandom.Text = "Start Randomly"
        Me.chkChaseStartRandom.UseVisualStyleBackColor = True
        '
        'numChaseMax
        '
        Me.numChaseMax.Location = New System.Drawing.Point(91, 19)
        Me.numChaseMax.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numChaseMax.Name = "numChaseMax"
        Me.numChaseMax.Size = New System.Drawing.Size(53, 20)
        Me.numChaseMax.TabIndex = 253
        Me.numChaseMax.Value = New Decimal(New Integer() {255, 0, 0, 0})
        '
        'lblAutoMaxlbl
        '
        Me.lblAutoMaxlbl.ForeColor = System.Drawing.Color.Lime
        Me.lblAutoMaxlbl.Location = New System.Drawing.Point(23, 16)
        Me.lblAutoMaxlbl.Name = "lblAutoMaxlbl"
        Me.lblAutoMaxlbl.Size = New System.Drawing.Size(62, 20)
        Me.lblAutoMaxlbl.TabIndex = 254
        Me.lblAutoMaxlbl.Text = "Max:"
        '
        'numChaseMin
        '
        Me.numChaseMin.Location = New System.Drawing.Point(91, 45)
        Me.numChaseMin.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numChaseMin.Name = "numChaseMin"
        Me.numChaseMin.Size = New System.Drawing.Size(53, 20)
        Me.numChaseMin.TabIndex = 255
        '
        'lblAutoMinlbl
        '
        Me.lblAutoMinlbl.ForeColor = System.Drawing.Color.Lime
        Me.lblAutoMinlbl.Location = New System.Drawing.Point(23, 42)
        Me.lblAutoMinlbl.Name = "lblAutoMinlbl"
        Me.lblAutoMinlbl.Size = New System.Drawing.Size(62, 20)
        Me.lblAutoMinlbl.TabIndex = 256
        Me.lblAutoMinlbl.Text = "Min:"
        '
        'cmdChaseFadeAdd
        '
        Me.cmdChaseFadeAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdChaseFadeAdd.Location = New System.Drawing.Point(10, 94)
        Me.cmdChaseFadeAdd.Name = "cmdChaseFadeAdd"
        Me.cmdChaseFadeAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmdChaseFadeAdd.TabIndex = 268
        Me.cmdChaseFadeAdd.Text = "^ Add"
        Me.cmdChaseFadeAdd.UseVisualStyleBackColor = True
        '
        'cmdChaseRemove
        '
        Me.cmdChaseRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdChaseRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdChaseRemove.ForeColor = System.Drawing.Color.Lime
        Me.cmdChaseRemove.Location = New System.Drawing.Point(427, 9)
        Me.cmdChaseRemove.Name = "cmdChaseRemove"
        Me.cmdChaseRemove.Size = New System.Drawing.Size(91, 23)
        Me.cmdChaseRemove.TabIndex = 290
        Me.cmdChaseRemove.Text = "Remove Selected"
        Me.cmdChaseRemove.UseVisualStyleBackColor = True
        '
        'lblEditingChannels
        '
        Me.lblEditingChannels.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEditingChannels.ForeColor = System.Drawing.Color.Lime
        Me.lblEditingChannels.Location = New System.Drawing.Point(425, 37)
        Me.lblEditingChannels.Name = "lblEditingChannels"
        Me.lblEditingChannels.Size = New System.Drawing.Size(93, 121)
        Me.lblEditingChannels.TabIndex = 297
        Me.lblEditingChannels.Text = "Channel numbers"
        '
        'CustomGroupBox1
        '
        Me.CustomGroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CustomGroupBox1.BorderColour = System.Drawing.Color.Red
        Me.CustomGroupBox1.Controls.Add(Me.chkLoop)
        Me.CustomGroupBox1.Controls.Add(Me.optInOrder)
        Me.CustomGroupBox1.Controls.Add(Me.optRandomSound)
        Me.CustomGroupBox1.Controls.Add(Me.optRandomTimed)
        Me.CustomGroupBox1.Controls.Add(Me.numChaseTimebetween)
        Me.CustomGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomGroupBox1.ForeColor = System.Drawing.Color.Lime
        Me.CustomGroupBox1.Location = New System.Drawing.Point(75, 162)
        Me.CustomGroupBox1.Name = "CustomGroupBox1"
        Me.CustomGroupBox1.Size = New System.Drawing.Size(173, 124)
        Me.CustomGroupBox1.TabIndex = 295
        Me.CustomGroupBox1.TabStop = False
        Me.CustomGroupBox1.Text = "List Progression:"
        '
        'chkLoop
        '
        Me.chkLoop.AutoSize = True
        Me.chkLoop.Checked = True
        Me.chkLoop.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLoop.ForeColor = System.Drawing.Color.Lime
        Me.chkLoop.Location = New System.Drawing.Point(94, 18)
        Me.chkLoop.Name = "chkLoop"
        Me.chkLoop.Size = New System.Drawing.Size(50, 17)
        Me.chkLoop.TabIndex = 268
        Me.chkLoop.Text = "Loop"
        Me.chkLoop.UseVisualStyleBackColor = False
        '
        'optInOrder
        '
        Me.optInOrder.AutoSize = True
        Me.optInOrder.Location = New System.Drawing.Point(6, 17)
        Me.optInOrder.Name = "optInOrder"
        Me.optInOrder.Size = New System.Drawing.Size(63, 17)
        Me.optInOrder.TabIndex = 263
        Me.optInOrder.Text = "In Order"
        Me.optInOrder.UseVisualStyleBackColor = True
        '
        'optRandomSound
        '
        Me.optRandomSound.AutoSize = True
        Me.optRandomSound.Checked = True
        Me.optRandomSound.Location = New System.Drawing.Point(6, 63)
        Me.optRandomSound.Name = "optRandomSound"
        Me.optRandomSound.Size = New System.Drawing.Size(154, 17)
        Me.optRandomSound.TabIndex = 267
        Me.optRandomSound.TabStop = True
        Me.optRandomSound.Text = "Randomly Sound Activated"
        Me.optRandomSound.UseVisualStyleBackColor = True
        '
        'optRandomTimed
        '
        Me.optRandomTimed.AutoSize = True
        Me.optRandomTimed.Location = New System.Drawing.Point(6, 40)
        Me.optRandomTimed.Name = "optRandomTimed"
        Me.optRandomTimed.Size = New System.Drawing.Size(104, 17)
        Me.optRandomTimed.TabIndex = 264
        Me.optRandomTimed.Text = "Randomly Timed"
        Me.optRandomTimed.UseVisualStyleBackColor = True
        '
        'numChaseTimebetween
        '
        Me.numChaseTimebetween.Location = New System.Drawing.Point(14, 86)
        Me.numChaseTimebetween.Maximum = New Decimal(New Integer() {30000, 0, 0, 0})
        Me.numChaseTimebetween.Name = "numChaseTimebetween"
        Me.numChaseTimebetween.Size = New System.Drawing.Size(96, 20)
        Me.numChaseTimebetween.TabIndex = 259
        Me.numChaseTimebetween.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'vsSelected
        '
        Me.vsSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vsSelected.BackColor = System.Drawing.Color.White
        Me.vsSelected.BulletColor = System.Drawing.Color.Red
        Me.vsSelected.FillColor = System.Drawing.Color.Black
        Me.vsSelected.Location = New System.Drawing.Point(13, 23)
        Me.vsSelected.Maximum = 255
        Me.vsSelected.Name = "vsSelected"
        Me.vsSelected.Orientation = Super_Awesome_Lighting_DMX_board_v4.modGUI.GControlOrientation.Vertical
        Me.vsSelected.Size = New System.Drawing.Size(42, 239)
        Me.vsSelected.TabIndex = 286
        Me.vsSelected.Value = 255
        '
        'txtAmplitude
        '
        Me.txtAmplitude.Location = New System.Drawing.Point(19, 110)
        Me.txtAmplitude.Name = "txtAmplitude"
        Me.txtAmplitude.Size = New System.Drawing.Size(54, 20)
        Me.txtAmplitude.TabIndex = 314
        '
        'txtCenter
        '
        Me.txtCenter.Location = New System.Drawing.Point(100, 110)
        Me.txtCenter.Name = "txtCenter"
        Me.txtCenter.Size = New System.Drawing.Size(54, 20)
        Me.txtCenter.TabIndex = 315
        '
        'txtFrequency
        '
        Me.txtFrequency.Location = New System.Drawing.Point(178, 110)
        Me.txtFrequency.Name = "txtFrequency"
        Me.txtFrequency.Size = New System.Drawing.Size(54, 20)
        Me.txtFrequency.TabIndex = 316
        '
        'txtPhase
        '
        Me.txtPhase.Location = New System.Drawing.Point(251, 110)
        Me.txtPhase.Name = "txtPhase"
        Me.txtPhase.Size = New System.Drawing.Size(54, 20)
        Me.txtPhase.TabIndex = 317
        '
        'FormChannels
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1818, 914)
        Me.Controls.Add(Me.pnlAutomation)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdBack)
        Me.Controls.Add(Me.cmdChannelsSave)
        Me.Controls.Add(Me.cmbChannelPresetSelection)
        Me.Controls.Add(Me.cmdReloadChannelLocations)
        Me.Controls.Add(Me.cmdChannelFadersDown)
        Me.Controls.Add(Me.cmdChannelFadersUp)
        Me.Controls.Add(Me.numChannelFadersStart)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormChannels"
        Me.Text = "KnightLight Channels"
        CType(Me.numChannelFadersStart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxCMDs.ResumeLayout(False)
        Me.ctxFixtureLabels.ResumeLayout(False)
        Me.pnlAutomation.ResumeLayout(False)
        Me.pnlAutomation.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.numSoundThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.numChaseManyMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numChaseManyMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numChaseManyIterations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.numChaseSingleValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numChaseMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numChaseMin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CustomGroupBox1.ResumeLayout(False)
        Me.CustomGroupBox1.PerformLayout()
        CType(Me.numChaseTimebetween, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdChannelsSave As Button
    Friend WithEvents cmbChannelPresetSelection As ComboBox
    Friend WithEvents cmdReloadChannelLocations As Button
    Friend WithEvents cmdChannelFadersDown As Button
    Friend WithEvents cmdChannelFadersUp As Button
    Friend WithEvents numChannelFadersStart As NumericUpDown
    Friend WithEvents ctxCMDs As ContextMenuStrip
    Friend WithEvents ctxDimmerAutomation As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ctxNameofbutton As ToolStripMenuItem
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ctxFixtureLabels As ContextMenuStrip
    Friend WithEvents ctxPickRGBColourTool As ToolStripMenuItem
    Friend WithEvents ctxFixtureFavourites As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ctxFixtureLabelsControlName As ToolStripMenuItem
    Friend WithEvents cmdSelectedFull As Button
    Friend WithEvents cmdSelectedBlackout As Button
    Friend WithEvents txtSelected As TextBox
    Friend WithEvents vsSelected As GScrollBar
    Friend WithEvents lblSelectedHeader As Label
    Friend WithEvents cmdBack As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ctxFixtureOptions As ToolStripMenuItem
    Friend WithEvents pnlAutomation As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents numSoundThreshold As NumericUpDown
    Friend WithEvents lblEditingChannels As Label
    Friend WithEvents lstChase As ListBox
    Friend WithEvents CustomGroupBox1 As CustomGroupBox
    Friend WithEvents chkLoop As CheckBox
    Friend WithEvents optInOrder As RadioButton
    Friend WithEvents optRandomSound As RadioButton
    Friend WithEvents optRandomTimed As RadioButton
    Friend WithEvents numChaseTimebetween As NumericUpDown
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents numChaseManyMax As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents numChaseManyMin As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents cmdChaseManySingleAdd As Button
    Friend WithEvents numChaseManyIterations As NumericUpDown
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmdChaseSingleAdd As Button
    Friend WithEvents numChaseSingleValue As NumericUpDown
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chkFadeBothWays As RadioButton
    Friend WithEvents chkFadeLtoH As RadioButton
    Friend WithEvents chkFadeHtoL As RadioButton
    Friend WithEvents chkChaseStartRandom As RadioButton
    Friend WithEvents numChaseMax As NumericUpDown
    Friend WithEvents lblAutoMaxlbl As Label
    Friend WithEvents numChaseMin As NumericUpDown
    Friend WithEvents lblAutoMinlbl As Label
    Friend WithEvents cmdChaseFadeAdd As Button
    Friend WithEvents cmdChaseRemove As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents knbSoundRelease As KnobControl.KnobControl
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents knbSoundAttack As KnobControl.KnobControl
    Friend WithEvents knbSoundLevel As KnobControl.KnobControl
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents knbPhase As KnobControl.KnobControl
    Friend WithEvents Label6 As Label
    Friend WithEvents knbFrequency As KnobControl.KnobControl
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents knbCenter As KnobControl.KnobControl
    Friend WithEvents knbAmplitude As KnobControl.KnobControl
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents lstWave As ListBox
    Friend WithEvents txtPhase As TextBox
    Friend WithEvents txtFrequency As TextBox
    Friend WithEvents txtCenter As TextBox
    Friend WithEvents txtAmplitude As TextBox
End Class

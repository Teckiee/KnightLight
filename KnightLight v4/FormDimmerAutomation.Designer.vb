<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDimmerAutomation
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
        Me.lblAutoMinlbl = New System.Windows.Forms.Label()
        Me.numChaseMin = New System.Windows.Forms.NumericUpDown()
        Me.lblAutoMaxlbl = New System.Windows.Forms.Label()
        Me.numChaseMax = New System.Windows.Forms.NumericUpDown()
        Me.numChaseManyIterations = New System.Windows.Forms.NumericUpDown()
        Me.cmdChaseFadeAdd = New System.Windows.Forms.Button()
        Me.cmdChaseRemove = New System.Windows.Forms.Button()
        Me.numChaseSingleValue = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkFadeBothWays = New System.Windows.Forms.RadioButton()
        Me.chkFadeLtoH = New System.Windows.Forms.RadioButton()
        Me.chkFadeHtoL = New System.Windows.Forms.RadioButton()
        Me.chkChaseStartRandom = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdChaseSingleAdd = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numChaseManyMax = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numChaseManyMin = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdChaseManySingleAdd = New System.Windows.Forms.Button()
        Me.lstChase = New System.Windows.Forms.ListBox()
        Me.lblEditingChannels = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.numSoundThreshold = New System.Windows.Forms.NumericUpDown()
        Me.CustomGroupBox1 = New Super_Awesome_Lighting_DMX_board_v4.CustomGroupBox()
        Me.lstWave = New System.Windows.Forms.ListBox()
        Me.chkLoop = New System.Windows.Forms.CheckBox()
        Me.optInOrder = New System.Windows.Forms.RadioButton()
        Me.optRandomSound = New System.Windows.Forms.RadioButton()
        Me.optRandomTimed = New System.Windows.Forms.RadioButton()
        Me.numChaseTimebetween = New System.Windows.Forms.NumericUpDown()
        Me.grpOscillator = New System.Windows.Forms.GroupBox()
        Me.txtPhase = New System.Windows.Forms.TextBox()
        Me.txtFrequency = New System.Windows.Forms.TextBox()
        Me.txtCenter = New System.Windows.Forms.TextBox()
        Me.txtAmplitude = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.knbPhase = New KnobControl.KnobControl()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.knbFrequency = New KnobControl.KnobControl()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.knbCenter = New KnobControl.KnobControl()
        Me.knbAmplitude = New KnobControl.KnobControl()
        Me.grpSoundActivation = New System.Windows.Forms.GroupBox()
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
        CType(Me.numChaseMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numChaseMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numChaseManyIterations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numChaseSingleValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.numChaseManyMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numChaseManyMin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.numSoundThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CustomGroupBox1.SuspendLayout()
        CType(Me.numChaseTimebetween, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpOscillator.SuspendLayout()
        Me.grpSoundActivation.SuspendLayout()
        Me.SuspendLayout()
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
        'numChaseMin
        '
        Me.numChaseMin.Location = New System.Drawing.Point(91, 45)
        Me.numChaseMin.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numChaseMin.Name = "numChaseMin"
        Me.numChaseMin.Size = New System.Drawing.Size(53, 20)
        Me.numChaseMin.TabIndex = 255
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
        'numChaseMax
        '
        Me.numChaseMax.Location = New System.Drawing.Point(91, 19)
        Me.numChaseMax.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numChaseMax.Name = "numChaseMax"
        Me.numChaseMax.Size = New System.Drawing.Size(53, 20)
        Me.numChaseMax.TabIndex = 253
        Me.numChaseMax.Value = New Decimal(New Integer() {255, 0, 0, 0})
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
        'cmdChaseFadeAdd
        '
        Me.cmdChaseFadeAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdChaseFadeAdd.Location = New System.Drawing.Point(10, 94)
        Me.cmdChaseFadeAdd.Name = "cmdChaseFadeAdd"
        Me.cmdChaseFadeAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmdChaseFadeAdd.TabIndex = 268
        Me.cmdChaseFadeAdd.Text = "< Add"
        Me.cmdChaseFadeAdd.UseVisualStyleBackColor = True
        '
        'cmdChaseRemove
        '
        Me.cmdChaseRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdChaseRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdChaseRemove.Location = New System.Drawing.Point(362, 32)
        Me.cmdChaseRemove.Name = "cmdChaseRemove"
        Me.cmdChaseRemove.Size = New System.Drawing.Size(100, 23)
        Me.cmdChaseRemove.TabIndex = 269
        Me.cmdChaseRemove.Text = "Remove Selected"
        Me.cmdChaseRemove.UseVisualStyleBackColor = True
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
        Me.GroupBox1.Location = New System.Drawing.Point(359, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(265, 124)
        Me.GroupBox1.TabIndex = 272
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
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmdChaseSingleAdd)
        Me.GroupBox2.Controls.Add(Me.numChaseSingleValue)
        Me.GroupBox2.Location = New System.Drawing.Point(509, 195)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(107, 77)
        Me.GroupBox2.TabIndex = 273
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
        Me.cmdChaseSingleAdd.Text = "< Add"
        Me.cmdChaseSingleAdd.UseVisualStyleBackColor = True
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
        Me.GroupBox4.Location = New System.Drawing.Point(359, 195)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(144, 143)
        Me.GroupBox4.TabIndex = 275
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
        Me.cmdChaseManySingleAdd.Text = "< Add"
        Me.cmdChaseManySingleAdd.UseVisualStyleBackColor = True
        '
        'lstChase
        '
        Me.lstChase.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstChase.ColumnWidth = 60
        Me.lstChase.FormattingEnabled = True
        Me.lstChase.Location = New System.Drawing.Point(3, 32)
        Me.lstChase.MultiColumn = True
        Me.lstChase.Name = "lstChase"
        Me.lstChase.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstChase.Size = New System.Drawing.Size(353, 446)
        Me.lstChase.TabIndex = 278
        '
        'lblEditingChannels
        '
        Me.lblEditingChannels.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEditingChannels.ForeColor = System.Drawing.Color.Lime
        Me.lblEditingChannels.Location = New System.Drawing.Point(0, 9)
        Me.lblEditingChannels.Name = "lblEditingChannels"
        Me.lblEditingChannels.Size = New System.Drawing.Size(631, 20)
        Me.lblEditingChannels.TabIndex = 279
        Me.lblEditingChannels.Text = "Channel numbers"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.numSoundThreshold)
        Me.GroupBox3.Location = New System.Drawing.Point(510, 278)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(107, 60)
        Me.GroupBox3.TabIndex = 275
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
        'CustomGroupBox1
        '
        Me.CustomGroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CustomGroupBox1.BorderColour = System.Drawing.Color.Red
        Me.CustomGroupBox1.Controls.Add(Me.lstWave)
        Me.CustomGroupBox1.Controls.Add(Me.chkLoop)
        Me.CustomGroupBox1.Controls.Add(Me.optInOrder)
        Me.CustomGroupBox1.Controls.Add(Me.optRandomSound)
        Me.CustomGroupBox1.Controls.Add(Me.optRandomTimed)
        Me.CustomGroupBox1.Controls.Add(Me.numChaseTimebetween)
        Me.CustomGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomGroupBox1.Location = New System.Drawing.Point(359, 344)
        Me.CustomGroupBox1.Name = "CustomGroupBox1"
        Me.CustomGroupBox1.Size = New System.Drawing.Size(255, 134)
        Me.CustomGroupBox1.TabIndex = 277
        Me.CustomGroupBox1.TabStop = False
        Me.CustomGroupBox1.Text = "List Progression:"
        '
        'lstWave
        '
        Me.lstWave.FormattingEnabled = True
        Me.lstWave.Items.AddRange(New Object() {"Off", "Chase", "Sine", "Square", "Triangle"})
        Me.lstWave.Location = New System.Drawing.Point(9, 19)
        Me.lstWave.Name = "lstWave"
        Me.lstWave.Size = New System.Drawing.Size(71, 82)
        Me.lstWave.TabIndex = 319
        '
        'chkLoop
        '
        Me.chkLoop.AutoSize = True
        Me.chkLoop.Checked = True
        Me.chkLoop.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLoop.ForeColor = System.Drawing.Color.Lime
        Me.chkLoop.Location = New System.Drawing.Point(179, 20)
        Me.chkLoop.Name = "chkLoop"
        Me.chkLoop.Size = New System.Drawing.Size(50, 17)
        Me.chkLoop.TabIndex = 268
        Me.chkLoop.Text = "Loop"
        Me.chkLoop.UseVisualStyleBackColor = False
        '
        'optInOrder
        '
        Me.optInOrder.AutoSize = True
        Me.optInOrder.Checked = True
        Me.optInOrder.Location = New System.Drawing.Point(91, 19)
        Me.optInOrder.Name = "optInOrder"
        Me.optInOrder.Size = New System.Drawing.Size(63, 17)
        Me.optInOrder.TabIndex = 263
        Me.optInOrder.TabStop = True
        Me.optInOrder.Text = "In Order"
        Me.optInOrder.UseVisualStyleBackColor = True
        '
        'optRandomSound
        '
        Me.optRandomSound.AutoSize = True
        Me.optRandomSound.Location = New System.Drawing.Point(91, 65)
        Me.optRandomSound.Name = "optRandomSound"
        Me.optRandomSound.Size = New System.Drawing.Size(154, 17)
        Me.optRandomSound.TabIndex = 267
        Me.optRandomSound.Text = "Randomly Sound Activated"
        Me.optRandomSound.UseVisualStyleBackColor = True
        '
        'optRandomTimed
        '
        Me.optRandomTimed.AutoSize = True
        Me.optRandomTimed.Location = New System.Drawing.Point(91, 42)
        Me.optRandomTimed.Name = "optRandomTimed"
        Me.optRandomTimed.Size = New System.Drawing.Size(104, 17)
        Me.optRandomTimed.TabIndex = 264
        Me.optRandomTimed.Text = "Randomly Timed"
        Me.optRandomTimed.UseVisualStyleBackColor = True
        '
        'numChaseTimebetween
        '
        Me.numChaseTimebetween.Location = New System.Drawing.Point(173, 88)
        Me.numChaseTimebetween.Maximum = New Decimal(New Integer() {30000, 0, 0, 0})
        Me.numChaseTimebetween.Name = "numChaseTimebetween"
        Me.numChaseTimebetween.Size = New System.Drawing.Size(72, 20)
        Me.numChaseTimebetween.TabIndex = 259
        Me.numChaseTimebetween.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'grpOscillator
        '
        Me.grpOscillator.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpOscillator.Controls.Add(Me.txtPhase)
        Me.grpOscillator.Controls.Add(Me.txtFrequency)
        Me.grpOscillator.Controls.Add(Me.txtCenter)
        Me.grpOscillator.Controls.Add(Me.txtAmplitude)
        Me.grpOscillator.Controls.Add(Me.Label7)
        Me.grpOscillator.Controls.Add(Me.knbPhase)
        Me.grpOscillator.Controls.Add(Me.Label6)
        Me.grpOscillator.Controls.Add(Me.knbFrequency)
        Me.grpOscillator.Controls.Add(Me.Label5)
        Me.grpOscillator.Controls.Add(Me.Label4)
        Me.grpOscillator.Controls.Add(Me.knbCenter)
        Me.grpOscillator.Controls.Add(Me.knbAmplitude)
        Me.grpOscillator.ForeColor = System.Drawing.Color.Lime
        Me.grpOscillator.Location = New System.Drawing.Point(3, 494)
        Me.grpOscillator.Name = "grpOscillator"
        Me.grpOscillator.Size = New System.Drawing.Size(323, 156)
        Me.grpOscillator.TabIndex = 317
        Me.grpOscillator.TabStop = False
        Me.grpOscillator.Text = "Oscillator - Not Working"
        '
        'txtPhase
        '
        Me.txtPhase.Location = New System.Drawing.Point(251, 110)
        Me.txtPhase.Name = "txtPhase"
        Me.txtPhase.Size = New System.Drawing.Size(54, 20)
        Me.txtPhase.TabIndex = 317
        '
        'txtFrequency
        '
        Me.txtFrequency.Location = New System.Drawing.Point(178, 110)
        Me.txtFrequency.Name = "txtFrequency"
        Me.txtFrequency.Size = New System.Drawing.Size(54, 20)
        Me.txtFrequency.TabIndex = 316
        '
        'txtCenter
        '
        Me.txtCenter.Location = New System.Drawing.Point(100, 110)
        Me.txtCenter.Name = "txtCenter"
        Me.txtCenter.Size = New System.Drawing.Size(54, 20)
        Me.txtCenter.TabIndex = 315
        '
        'txtAmplitude
        '
        Me.txtAmplitude.Location = New System.Drawing.Point(19, 110)
        Me.txtAmplitude.Name = "txtAmplitude"
        Me.txtAmplitude.Size = New System.Drawing.Size(54, 20)
        Me.txtAmplitude.TabIndex = 314
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
        'grpSoundActivation
        '
        Me.grpSoundActivation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpSoundActivation.Controls.Add(Me.knbSoundLevel)
        Me.grpSoundActivation.Controls.Add(Me.RadioButton1)
        Me.grpSoundActivation.Controls.Add(Me.knbSoundAttack)
        Me.grpSoundActivation.Controls.Add(Me.RadioButton2)
        Me.grpSoundActivation.Controls.Add(Me.Label10)
        Me.grpSoundActivation.Controls.Add(Me.RadioButton3)
        Me.grpSoundActivation.Controls.Add(Me.Label9)
        Me.grpSoundActivation.Controls.Add(Me.RadioButton4)
        Me.grpSoundActivation.Controls.Add(Me.knbSoundRelease)
        Me.grpSoundActivation.Controls.Add(Me.Label8)
        Me.grpSoundActivation.ForeColor = System.Drawing.Color.Lime
        Me.grpSoundActivation.Location = New System.Drawing.Point(337, 494)
        Me.grpSoundActivation.Name = "grpSoundActivation"
        Me.grpSoundActivation.Size = New System.Drawing.Size(297, 124)
        Me.grpSoundActivation.TabIndex = 318
        Me.grpSoundActivation.TabStop = False
        Me.grpSoundActivation.Text = "Sound Activation - Not Working"
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
        'FormDimmerAutomation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 653)
        Me.Controls.Add(Me.grpSoundActivation)
        Me.Controls.Add(Me.grpOscillator)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lblEditingChannels)
        Me.Controls.Add(Me.lstChase)
        Me.Controls.Add(Me.CustomGroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdChaseRemove)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(656, 692)
        Me.Name = "FormDimmerAutomation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Channel Automation"
        Me.TopMost = True
        CType(Me.numChaseMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numChaseMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numChaseManyIterations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numChaseSingleValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.numChaseManyMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numChaseManyMin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.numSoundThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CustomGroupBox1.ResumeLayout(False)
        Me.CustomGroupBox1.PerformLayout()
        CType(Me.numChaseTimebetween, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpOscillator.ResumeLayout(False)
        Me.grpOscillator.PerformLayout()
        Me.grpSoundActivation.ResumeLayout(False)
        Me.grpSoundActivation.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents numChaseTimebetween As NumericUpDown
    Friend WithEvents lblAutoMinlbl As Label
    Friend WithEvents numChaseMin As NumericUpDown
    Friend WithEvents lblAutoMaxlbl As Label
    Friend WithEvents numChaseMax As NumericUpDown
    Friend WithEvents optInOrder As RadioButton
    Friend WithEvents optRandomTimed As RadioButton
    Friend WithEvents numChaseManyIterations As NumericUpDown
    Friend WithEvents optRandomSound As RadioButton
    Friend WithEvents cmdChaseFadeAdd As Button
    Friend WithEvents cmdChaseRemove As Button
    Friend WithEvents numChaseSingleValue As NumericUpDown
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmdChaseSingleAdd As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents numChaseManyMax As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents numChaseManyMin As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents cmdChaseManySingleAdd As Button
    Friend WithEvents CustomGroupBox1 As CustomGroupBox
    Friend WithEvents lstChase As ListBox
    Friend WithEvents chkLoop As CheckBox
    Friend WithEvents chkFadeLtoH As RadioButton
    Friend WithEvents chkFadeHtoL As RadioButton
    Friend WithEvents chkChaseStartRandom As RadioButton
    Friend WithEvents chkFadeBothWays As RadioButton
    Friend WithEvents lblEditingChannels As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents numSoundThreshold As NumericUpDown
    Friend WithEvents grpOscillator As GroupBox
    Friend WithEvents txtPhase As TextBox
    Friend WithEvents txtFrequency As TextBox
    Friend WithEvents txtCenter As TextBox
    Friend WithEvents txtAmplitude As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents knbPhase As KnobControl.KnobControl
    Friend WithEvents Label6 As Label
    Friend WithEvents knbFrequency As KnobControl.KnobControl
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents knbCenter As KnobControl.KnobControl
    Friend WithEvents knbAmplitude As KnobControl.KnobControl
    Friend WithEvents grpSoundActivation As GroupBox
    Friend WithEvents knbSoundLevel As KnobControl.KnobControl
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents knbSoundAttack As KnobControl.KnobControl
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents Label10 As Label
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents Label9 As Label
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents knbSoundRelease As KnobControl.KnobControl
    Friend WithEvents Label8 As Label
    Friend WithEvents lstWave As ListBox
End Class

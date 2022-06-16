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
        Me.chkLoop = New System.Windows.Forms.CheckBox()
        Me.optInOrder = New System.Windows.Forms.RadioButton()
        Me.optRandomSound = New System.Windows.Forms.RadioButton()
        Me.optRandomTimed = New System.Windows.Forms.RadioButton()
        Me.numChaseTimebetween = New System.Windows.Forms.NumericUpDown()
        Me.chkAutoRunning = New System.Windows.Forms.CheckBox()
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
        Me.cmdChaseRemove.Location = New System.Drawing.Point(196, 12)
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
        Me.GroupBox1.Location = New System.Drawing.Point(193, 41)
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
        Me.GroupBox2.Location = New System.Drawing.Point(343, 175)
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
        Me.GroupBox4.Location = New System.Drawing.Point(193, 175)
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
        Me.lstChase.Location = New System.Drawing.Point(3, 7)
        Me.lstChase.MultiColumn = True
        Me.lstChase.Name = "lstChase"
        Me.lstChase.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstChase.Size = New System.Drawing.Size(180, 446)
        Me.lstChase.TabIndex = 278
        '
        'lblEditingChannels
        '
        Me.lblEditingChannels.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEditingChannels.ForeColor = System.Drawing.Color.Lime
        Me.lblEditingChannels.Location = New System.Drawing.Point(0, 459)
        Me.lblEditingChannels.Name = "lblEditingChannels"
        Me.lblEditingChannels.Size = New System.Drawing.Size(458, 20)
        Me.lblEditingChannels.TabIndex = 279
        Me.lblEditingChannels.Text = "Channel numbers"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.numSoundThreshold)
        Me.GroupBox3.Location = New System.Drawing.Point(344, 258)
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
        Me.CustomGroupBox1.Controls.Add(Me.chkLoop)
        Me.CustomGroupBox1.Controls.Add(Me.optInOrder)
        Me.CustomGroupBox1.Controls.Add(Me.optRandomSound)
        Me.CustomGroupBox1.Controls.Add(Me.optRandomTimed)
        Me.CustomGroupBox1.Controls.Add(Me.numChaseTimebetween)
        Me.CustomGroupBox1.Controls.Add(Me.chkAutoRunning)
        Me.CustomGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomGroupBox1.Location = New System.Drawing.Point(193, 324)
        Me.CustomGroupBox1.Name = "CustomGroupBox1"
        Me.CustomGroupBox1.Size = New System.Drawing.Size(255, 127)
        Me.CustomGroupBox1.TabIndex = 277
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
        'chkAutoRunning
        '
        Me.chkAutoRunning.ForeColor = System.Drawing.Color.Lime
        Me.chkAutoRunning.Location = New System.Drawing.Point(156, 86)
        Me.chkAutoRunning.Name = "chkAutoRunning"
        Me.chkAutoRunning.Size = New System.Drawing.Size(78, 21)
        Me.chkAutoRunning.TabIndex = 258
        Me.chkAutoRunning.Text = "Running"
        Me.chkAutoRunning.UseVisualStyleBackColor = False
        '
        'FormDimmerAutomation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(467, 481)
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
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents numChaseTimebetween As NumericUpDown
    Friend WithEvents chkAutoRunning As CheckBox
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
End Class

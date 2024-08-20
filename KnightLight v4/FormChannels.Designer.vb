<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormChannels
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
        Me.SaveAsFavouriteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.vsSelected = New Super_Awesome_Lighting_DMX_board_v4.GScrollBar()
        CType(Me.numChannelFadersStart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxCMDs.SuspendLayout()
        Me.ctxFixtureLabels.SuspendLayout()
        Me.pnlAutomation.SuspendLayout()
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
        Me.ctxFixtureLabels.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxPickRGBColourTool, Me.ctxFixtureFavourites, Me.SaveAsFavouriteToolStripMenuItem, Me.ctxFixtureOptions, Me.ToolStripSeparator3, Me.ctxFixtureLabelsControlName})
        Me.ctxFixtureLabels.Name = "ctxFixtureLabels"
        Me.ctxFixtureLabels.Size = New System.Drawing.Size(167, 120)
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
        'SaveAsFavouriteToolStripMenuItem
        '
        Me.SaveAsFavouriteToolStripMenuItem.Name = "SaveAsFavouriteToolStripMenuItem"
        Me.SaveAsFavouriteToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.SaveAsFavouriteToolStripMenuItem.Text = "Save As Favourite"
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
        Me.cmdSelectedFull.Location = New System.Drawing.Point(6, 294)
        Me.cmdSelectedFull.Name = "cmdSelectedFull"
        Me.cmdSelectedFull.Size = New System.Drawing.Size(60, 23)
        Me.cmdSelectedFull.TabIndex = 289
        Me.cmdSelectedFull.Text = "Full"
        Me.cmdSelectedFull.UseVisualStyleBackColor = True
        '
        'cmdSelectedBlackout
        '
        Me.cmdSelectedBlackout.Location = New System.Drawing.Point(6, 323)
        Me.cmdSelectedBlackout.Name = "cmdSelectedBlackout"
        Me.cmdSelectedBlackout.Size = New System.Drawing.Size(60, 23)
        Me.cmdSelectedBlackout.TabIndex = 288
        Me.cmdSelectedBlackout.Text = "Blackout"
        Me.cmdSelectedBlackout.UseVisualStyleBackColor = True
        '
        'txtSelected
        '
        Me.txtSelected.Location = New System.Drawing.Point(14, 268)
        Me.txtSelected.Name = "txtSelected"
        Me.txtSelected.Size = New System.Drawing.Size(42, 20)
        Me.txtSelected.TabIndex = 287
        Me.txtSelected.Text = "0"
        '
        'lblSelectedHeader
        '
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
        Me.pnlAutomation.Controls.Add(Me.lblSelectedHeader)
        Me.pnlAutomation.Controls.Add(Me.vsSelected)
        Me.pnlAutomation.Controls.Add(Me.txtSelected)
        Me.pnlAutomation.Controls.Add(Me.cmdSelectedBlackout)
        Me.pnlAutomation.Controls.Add(Me.cmdSelectedFull)
        Me.pnlAutomation.Location = New System.Drawing.Point(1743, 41)
        Me.pnlAutomation.Name = "pnlAutomation"
        Me.pnlAutomation.Size = New System.Drawing.Size(72, 861)
        Me.pnlAutomation.TabIndex = 292
        '
        'vsSelected
        '
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
    Friend WithEvents SaveAsFavouriteToolStripMenuItem As ToolStripMenuItem
End Class

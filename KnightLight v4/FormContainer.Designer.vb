<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormContainer
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuBanks = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuScenes = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuChannels = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMusicEditor = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuQuickChanges = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBanks, Me.mnuScenes, Me.mnuChannels, Me.mnuMusicEditor, Me.mnuQuickChanges, Me.mnuSettings})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1904, 29)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuBanks
        '
        Me.mnuBanks.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.mnuBanks.Name = "mnuBanks"
        Me.mnuBanks.Size = New System.Drawing.Size(63, 25)
        Me.mnuBanks.Text = "Banks"
        '
        'mnuScenes
        '
        Me.mnuScenes.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.mnuScenes.Name = "mnuScenes"
        Me.mnuScenes.Size = New System.Drawing.Size(70, 25)
        Me.mnuScenes.Text = "Scenes"
        '
        'mnuChannels
        '
        Me.mnuChannels.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.mnuChannels.Name = "mnuChannels"
        Me.mnuChannels.Size = New System.Drawing.Size(86, 25)
        Me.mnuChannels.Text = "Channels"
        '
        'mnuMusicEditor
        '
        Me.mnuMusicEditor.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.mnuMusicEditor.Name = "mnuMusicEditor"
        Me.mnuMusicEditor.Size = New System.Drawing.Size(108, 25)
        Me.mnuMusicEditor.Text = "Music Editor"
        '
        'mnuQuickChanges
        '
        Me.mnuQuickChanges.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.mnuQuickChanges.Name = "mnuQuickChanges"
        Me.mnuQuickChanges.Size = New System.Drawing.Size(126, 25)
        Me.mnuQuickChanges.Text = "Quick Changes"
        '
        'mnuSettings
        '
        Me.mnuSettings.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.mnuSettings.Name = "mnuSettings"
        Me.mnuSettings.Size = New System.Drawing.Size(78, 25)
        Me.mnuSettings.Text = "Settings"
        '
        'FormContainer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1904, 953)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormContainer"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mnuBanks As ToolStripMenuItem
    Friend WithEvents mnuScenes As ToolStripMenuItem
    Friend WithEvents mnuChannels As ToolStripMenuItem
    Friend WithEvents mnuMusicEditor As ToolStripMenuItem
    Friend WithEvents mnuQuickChanges As ToolStripMenuItem
    Friend WithEvents mnuSettings As ToolStripMenuItem
End Class

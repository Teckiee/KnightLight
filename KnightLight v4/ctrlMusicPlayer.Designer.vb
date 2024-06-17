<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlMusicPlayer
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.cmdCue1 = New System.Windows.Forms.Button()
        Me.cmdCue2 = New System.Windows.Forms.Button()
        Me.cmdPlay = New System.Windows.Forms.Button()
        Me.lblDuration = New System.Windows.Forms.Label()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.lblSongName = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'cmdCue1
        '
        Me.cmdCue1.Location = New System.Drawing.Point(284, 0)
        Me.cmdCue1.Name = "cmdCue1"
        Me.cmdCue1.Size = New System.Drawing.Size(41, 23)
        Me.cmdCue1.TabIndex = 0
        Me.cmdCue1.Text = "Cue1"
        Me.cmdCue1.UseVisualStyleBackColor = True
        '
        'cmdCue2
        '
        Me.cmdCue2.Location = New System.Drawing.Point(322, 0)
        Me.cmdCue2.Name = "cmdCue2"
        Me.cmdCue2.Size = New System.Drawing.Size(41, 23)
        Me.cmdCue2.TabIndex = 1
        Me.cmdCue2.Text = "Cue2"
        Me.cmdCue2.UseVisualStyleBackColor = True
        '
        'cmdPlay
        '
        Me.cmdPlay.Location = New System.Drawing.Point(435, 0)
        Me.cmdPlay.Name = "cmdPlay"
        Me.cmdPlay.Size = New System.Drawing.Size(47, 23)
        Me.cmdPlay.TabIndex = 2
        Me.cmdPlay.Text = "Pause"
        Me.cmdPlay.UseVisualStyleBackColor = True
        '
        'lblDuration
        '
        Me.lblDuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDuration.ForeColor = System.Drawing.Color.Lime
        Me.lblDuration.Location = New System.Drawing.Point(363, 1)
        Me.lblDuration.Name = "lblDuration"
        Me.lblDuration.Size = New System.Drawing.Size(71, 20)
        Me.lblDuration.TabIndex = 608
        Me.lblDuration.Text = "00:00:00"
        '
        'cmdStop
        '
        Me.cmdStop.Location = New System.Drawing.Point(481, 0)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(42, 23)
        Me.cmdStop.TabIndex = 609
        Me.cmdStop.Text = "Stop"
        Me.cmdStop.UseVisualStyleBackColor = True
        '
        'lblPosition
        '
        Me.lblPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosition.ForeColor = System.Drawing.Color.Lime
        Me.lblPosition.Location = New System.Drawing.Point(523, 1)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(71, 20)
        Me.lblPosition.TabIndex = 610
        Me.lblPosition.Text = "00:00.00"
        '
        'lblSongName
        '
        Me.lblSongName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSongName.ForeColor = System.Drawing.Color.Lime
        Me.lblSongName.Location = New System.Drawing.Point(0, 1)
        Me.lblSongName.Name = "lblSongName"
        Me.lblSongName.Size = New System.Drawing.Size(283, 20)
        Me.lblSongName.TabIndex = 611
        Me.lblSongName.Text = "Song Name"
        Me.lblSongName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ctrlMusicPlayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.lblSongName)
        Me.Controls.Add(Me.lblPosition)
        Me.Controls.Add(Me.cmdStop)
        Me.Controls.Add(Me.lblDuration)
        Me.Controls.Add(Me.cmdPlay)
        Me.Controls.Add(Me.cmdCue2)
        Me.Controls.Add(Me.cmdCue1)
        Me.Name = "ctrlMusicPlayer"
        Me.Size = New System.Drawing.Size(595, 23)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdCue1 As Button
    Friend WithEvents cmdCue2 As Button
    Friend WithEvents cmdPlay As Button
    Friend WithEvents lblDuration As Label
    Friend WithEvents cmdStop As Button
    Friend WithEvents lblPosition As Label
    Friend WithEvents lblSongName As Label
    Friend WithEvents Timer1 As Timer
End Class

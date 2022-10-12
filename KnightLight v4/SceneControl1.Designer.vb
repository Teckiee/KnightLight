<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SceneControl1
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.cAutoTime = New System.Windows.Forms.NumericUpDown()
        Me.cFull = New System.Windows.Forms.Button()
        Me.cBlackout = New System.Windows.Forms.Button()
        Me.cPresetName = New System.Windows.Forms.Label()
        Me.cTxtVal = New System.Windows.Forms.TextBox()
        Me.vScroll = New Super_Awesome_Lighting_DMX_board_v4.GScrollBar()
        CType(Me.cAutoTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cAutoTime
        '
        Me.cAutoTime.BackColor = System.Drawing.Color.Black
        Me.cAutoTime.ForeColor = System.Drawing.Color.White
        Me.cAutoTime.Location = New System.Drawing.Point(119, 21)
        Me.cAutoTime.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.cAutoTime.Name = "cAutoTime"
        Me.cAutoTime.Size = New System.Drawing.Size(50, 20)
        Me.cAutoTime.TabIndex = 582
        Me.cAutoTime.Value = New Decimal(New Integer() {2000, 0, 0, 0})
        '
        'cFull
        '
        Me.cFull.BackColor = System.Drawing.Color.Black
        Me.cFull.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cFull.ForeColor = System.Drawing.Color.White
        Me.cFull.Location = New System.Drawing.Point(170, 0)
        Me.cFull.Name = "cFull"
        Me.cFull.Size = New System.Drawing.Size(60, 42)
        Me.cFull.TabIndex = 581
        Me.cFull.Text = "Full"
        Me.cFull.UseVisualStyleBackColor = False
        '
        'cBlackout
        '
        Me.cBlackout.BackColor = System.Drawing.Color.Black
        Me.cBlackout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cBlackout.ForeColor = System.Drawing.Color.White
        Me.cBlackout.Location = New System.Drawing.Point(231, 0)
        Me.cBlackout.Name = "cBlackout"
        Me.cBlackout.Size = New System.Drawing.Size(60, 42)
        Me.cBlackout.TabIndex = 580
        Me.cBlackout.Text = "Blackout"
        Me.cBlackout.UseVisualStyleBackColor = False
        '
        'cPresetName
        '
        Me.cPresetName.BackColor = System.Drawing.Color.Black
        Me.cPresetName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cPresetName.ForeColor = System.Drawing.Color.Lime
        Me.cPresetName.Location = New System.Drawing.Point(0, 0)
        Me.cPresetName.Name = "cPresetName"
        Me.cPresetName.Size = New System.Drawing.Size(113, 42)
        Me.cPresetName.TabIndex = 579
        Me.cPresetName.Text = "Scene Name"
        '
        'cTxtVal
        '
        Me.cTxtVal.BackColor = System.Drawing.Color.Black
        Me.cTxtVal.ForeColor = System.Drawing.Color.White
        Me.cTxtVal.Location = New System.Drawing.Point(119, 0)
        Me.cTxtVal.Name = "cTxtVal"
        Me.cTxtVal.Size = New System.Drawing.Size(42, 20)
        Me.cTxtVal.TabIndex = 578
        Me.cTxtVal.Text = "100"
        '
        'vScroll
        '
        Me.vScroll.Location = New System.Drawing.Point(0, 44)
        Me.vScroll.Name = "vScroll"
        Me.vScroll.Size = New System.Drawing.Size(292, 21)
        Me.vScroll.TabIndex = 583
        '
        'SceneControl1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.vScroll)
        Me.Controls.Add(Me.cAutoTime)
        Me.Controls.Add(Me.cFull)
        Me.Controls.Add(Me.cBlackout)
        Me.Controls.Add(Me.cPresetName)
        Me.Controls.Add(Me.cTxtVal)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "SceneControl1"
        Me.Size = New System.Drawing.Size(290, 40)
        CType(Me.cAutoTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents cAutoTime As NumericUpDown
    Public WithEvents cFull As Button
    Public WithEvents cBlackout As Button
    Public WithEvents cPresetName As Label
    Public WithEvents cTxtVal As TextBox
    Friend WithEvents vScroll As GScrollBar
End Class

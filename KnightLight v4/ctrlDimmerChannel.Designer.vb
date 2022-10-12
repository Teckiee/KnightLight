<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlDimmerChannel
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
        Me.dmrlblFC = New System.Windows.Forms.Label()
        Me.dmrlblTop = New System.Windows.Forms.Label()
        Me.dmrbtn = New System.Windows.Forms.Button()
        Me.dmrvs = New Super_Awesome_Lighting_DMX_board_v4.GScrollBar()
        Me.dmrtxtv = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'dmrlblFC
        '
        Me.dmrlblFC.Location = New System.Drawing.Point(0, 249)
        Me.dmrlblFC.Name = "dmrlblFC"
        Me.dmrlblFC.Size = New System.Drawing.Size(36, 16)
        Me.dmrlblFC.TabIndex = 0
        Me.dmrlblFC.Text = "Label1"
        '
        'dmrlblTop
        '
        Me.dmrlblTop.Location = New System.Drawing.Point(0, 0)
        Me.dmrlblTop.Name = "dmrlblTop"
        Me.dmrlblTop.Size = New System.Drawing.Size(36, 16)
        Me.dmrlblTop.TabIndex = 1
        Me.dmrlblTop.Text = "Label1"
        '
        'dmrbtn
        '
        Me.dmrbtn.Location = New System.Drawing.Point(0, 197)
        Me.dmrbtn.Name = "dmrbtn"
        Me.dmrbtn.Size = New System.Drawing.Size(23, 23)
        Me.dmrbtn.TabIndex = 2
        Me.dmrbtn.Text = "S"
        Me.dmrbtn.UseVisualStyleBackColor = True
        '
        'dmrvs
        '
        Me.dmrvs.Location = New System.Drawing.Point(0, 26)
        Me.dmrvs.Maximum = 255
        Me.dmrvs.Name = "dmrvs"
        Me.dmrvs.Orientation = Super_Awesome_Lighting_DMX_board_v4.modGUI.GControlOrientation.Vertical
        Me.dmrvs.Size = New System.Drawing.Size(23, 168)
        Me.dmrvs.TabIndex = 3
        '
        'dmrtxtv
        '
        Me.dmrtxtv.Location = New System.Drawing.Point(0, 226)
        Me.dmrtxtv.Name = "dmrtxtv"
        Me.dmrtxtv.Size = New System.Drawing.Size(24, 20)
        Me.dmrtxtv.TabIndex = 4
        Me.dmrtxtv.Text = "0"
        '
        'ctrlDimmerChannel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dmrtxtv)
        Me.Controls.Add(Me.dmrvs)
        Me.Controls.Add(Me.dmrbtn)
        Me.Controls.Add(Me.dmrlblTop)
        Me.Controls.Add(Me.dmrlblFC)
        Me.Name = "ctrlDimmerChannel"
        Me.Size = New System.Drawing.Size(36, 266)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dmrlblFC As Label
    Friend WithEvents dmrlblTop As Label
    Friend WithEvents dmrbtn As Button
    Friend WithEvents dmrvs As GScrollBar
    Friend WithEvents dmrtxtv As TextBox
End Class

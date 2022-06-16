<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBanks
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
        Me.lstBanks = New System.Windows.Forms.ListBox()
        Me.cmdBankDelete = New System.Windows.Forms.Button()
        Me.cmdBankRename = New System.Windows.Forms.Button()
        Me.cmdBankNew = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstBanks
        '
        Me.lstBanks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstBanks.FormattingEnabled = True
        Me.lstBanks.Location = New System.Drawing.Point(12, 25)
        Me.lstBanks.Name = "lstBanks"
        Me.lstBanks.Size = New System.Drawing.Size(196, 472)
        Me.lstBanks.TabIndex = 257
        '
        'cmdBankDelete
        '
        Me.cmdBankDelete.Enabled = False
        Me.cmdBankDelete.ForeColor = System.Drawing.Color.White
        Me.cmdBankDelete.Location = New System.Drawing.Point(480, 25)
        Me.cmdBankDelete.Name = "cmdBankDelete"
        Me.cmdBankDelete.Size = New System.Drawing.Size(36, 23)
        Me.cmdBankDelete.TabIndex = 256
        Me.cmdBankDelete.Text = "Del"
        Me.cmdBankDelete.UseVisualStyleBackColor = True
        Me.cmdBankDelete.Visible = False
        '
        'cmdBankRename
        '
        Me.cmdBankRename.Location = New System.Drawing.Point(410, 25)
        Me.cmdBankRename.Name = "cmdBankRename"
        Me.cmdBankRename.Size = New System.Drawing.Size(64, 23)
        Me.cmdBankRename.TabIndex = 255
        Me.cmdBankRename.Text = "Rename"
        Me.cmdBankRename.UseVisualStyleBackColor = True
        '
        'cmdBankNew
        '
        Me.cmdBankNew.Location = New System.Drawing.Point(304, 25)
        Me.cmdBankNew.Name = "cmdBankNew"
        Me.cmdBankNew.Size = New System.Drawing.Size(100, 23)
        Me.cmdBankNew.TabIndex = 254
        Me.cmdBankNew.Text = "New Bank"
        Me.cmdBankNew.UseVisualStyleBackColor = True
        '
        'FormBanks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1810, 888)
        Me.ControlBox = False
        Me.Controls.Add(Me.lstBanks)
        Me.Controls.Add(Me.cmdBankDelete)
        Me.Controls.Add(Me.cmdBankRename)
        Me.Controls.Add(Me.cmdBankNew)
        Me.Name = "FormBanks"
        Me.Text = "FormBanks"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstBanks As ListBox
    Friend WithEvents cmdBankDelete As Button
    Friend WithEvents cmdBankRename As Button
    Friend WithEvents cmdBankNew As Button
End Class

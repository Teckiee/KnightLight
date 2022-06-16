<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormColourGradient
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
        Me.pnlSelectedColour = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'pnlSelectedColour
        '
        Me.pnlSelectedColour.Location = New System.Drawing.Point(715, 2)
        Me.pnlSelectedColour.Name = "pnlSelectedColour"
        Me.pnlSelectedColour.Size = New System.Drawing.Size(72, 72)
        Me.pnlSelectedColour.TabIndex = 0
        '
        'FormColourGradient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 450)
        Me.Controls.Add(Me.pnlSelectedColour)
        Me.Name = "FormColourGradient"
        Me.Text = "ColourGradient"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlSelectedColour As Panel
End Class

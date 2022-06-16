<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormColourPicker
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
        Me.ColorPicker2 = New ColorPickerLib.gColorPicker()
        CType(Me.ColorPicker2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ColorPicker2
        '
        Me.ColorPicker2.BackColor = System.Drawing.Color.Transparent
        Me.ColorPicker2.FlyOut = ColorPickerLib.gColorPicker.eFlyOut.Click
        Me.ColorPicker2.HideRGB = False
        Me.ColorPicker2.Location = New System.Drawing.Point(0, 0)
        Me.ColorPicker2.Name = "ColorPicker2"
        Me.ColorPicker2.Size = New System.Drawing.Size(355, 154)
        Me.ColorPicker2.TabIndex = 11
        Me.ColorPicker2.Value = System.Drawing.Color.Fuchsia
        '
        'FormColourPicker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(357, 157)
        Me.Controls.Add(Me.ColorPicker2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormColourPicker"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Colour Picker"
        Me.TopMost = True
        CType(Me.ColorPicker2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ColorPicker2 As ColorPickerLib.gColorPicker
End Class

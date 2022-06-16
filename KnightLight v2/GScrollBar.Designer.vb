<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GScrollBar
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
    Me.components = New System.ComponentModel.Container
    Me.tmrScroll = New System.Windows.Forms.Timer(Me.components)
    Me.SuspendLayout()
    '
    'GScrollBar
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.Name = "GScrollBar"
    Me.Size = New System.Drawing.Size(255, 21)
    Me.ResumeLayout(False)

  End Sub

  Public Sub New()
    ' This call is required by the Windows Form Designer.
    InitializeComponent()
    ' Add any initialization after the InitializeComponent() call.
    Me.SetStyle(Windows.Forms.ControlStyles.AllPaintingInWmPaint Or _
                Windows.Forms.ControlStyles.UserPaint Or _
                Windows.Forms.ControlStyles.OptimizedDoubleBuffer, True)
    Me.UpdateStyles()
  End Sub
  Friend WithEvents tmrScroll As System.Windows.Forms.Timer
End Class

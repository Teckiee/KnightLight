Public Class CustomGroupBox
    Inherits GroupBox

    Private borderColor As Color

    Public Sub New()
        MyBase.New
        Me.borderColor = Color.Red      '-- In here code your VB.net colour name
    End Sub
    Public Property BorderColour() As Color
        Get
            Return Me.borderColor

        End Get

        Set(ByVal value As Color)
            Me.borderColor = value
        End Set

    End Property


    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim tSize As Size = TextRenderer.MeasureText(Me.Text, Me.Font)
        Dim borderRect As Rectangle = e.ClipRectangle
        borderRect.Y = (borderRect.Y _
                    + (tSize.Height / 2))
        borderRect.Height = (borderRect.Height _
                    - (tSize.Height / 2))
        ControlPaint.DrawBorder(e.Graphics, borderRect, Me.borderColor, ButtonBorderStyle.Solid)
        Dim textRect As Rectangle = e.ClipRectangle
        textRect.X = (textRect.X + 6)
        textRect.Width = tSize.Width
        textRect.Height = tSize.Height
        e.Graphics.FillRectangle(New SolidBrush(Me.BackColor), textRect)
        e.Graphics.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), textRect)
    End Sub

End Class

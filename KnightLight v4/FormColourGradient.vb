Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class FormColourGradient
    Dim gGradient As Graphics
    Dim b As Bitmap
    Private Sub ColourGradient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.Width = 1024
        'SurroundingSub()
        Dim Col1 = GetGradients(Color.Red, Color.Blue, 30)
        Dim Col2 = GetGradients(Color.Red, Color.Blue, 30)
    End Sub
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Exit Sub
        'Using l As New Drawing2D.LinearGradientBrush(New Rectangle(New Point(0, 0), Me.ClientSize), Color.Red, Color.Blue, 0)
        Using l As New LinearGradientBrush(New Rectangle(New Point(0, 72), Me.ClientSize), Color.Red, Color.Blue, 0)
            Dim cb As New ColorBlend
            cb.Positions = New Single() {0, 0.1F, 0.284F, 0.5F, 0.668F, 0.9F, 1}
            cb.Colors = New Color() {Color.Purple, Color.Red, Color.Yellow, Color.Lime, Color.Cyan, Color.Blue, Color.LightBlue}
            l.InterpolationColors = cb

            'b = e.Graphics.FillRectangle(l, New Rectangle(New Point(0, 72), Me.ClientSize))
            'gGradient = Graphics.FromImage(b)
            e.Graphics.FillRectangle(l, New Rectangle(New Point(0, 72), Me.ClientSize)) ' Me.ClientRectangle)
        End Using
        b = New Bitmap(1024, 489)
        DrawToBitmap(b, New Rectangle(New Point(0, 72), Me.ClientSize))

    End Sub
    Public Shared Iterator Function GetGradients(ByVal start As Color, ByVal [end] As Color, ByVal steps As Integer) As IEnumerable(Of Color)
        Dim stepA As Integer = (([end].A - start.A) / (steps - 1))
        Dim stepR As Integer = (([end].R - start.R) / (steps - 1))
        Dim stepG As Integer = (([end].G - start.G) / (steps - 1))
        Dim stepB As Integer = (([end].B - start.B) / (steps - 1))

        For i As Integer = 0 To steps - 1
            Yield Color.FromArgb(start.A + (stepA * i), start.R + (stepR * i), start.G + (stepG * i), start.B + (stepB * i))
        Next
    End Function

    Private Sub SurroundingSub()
        Dim rMax As Integer = 255 'Color.Chocolate.R
        Dim rMin As Integer = 0 'Color.Blue.R
        Dim gMax As Integer = 255
        Dim gMin As Integer = 0
        Dim bMax As Integer = 255
        Dim bMin As Integer = 0
        Dim colorList = New List(Of Color)()
        Dim iSize As Integer = 255

        For i As Integer = 0 To iSize - 1
            Dim rAverage As Integer = rMin + CInt(((rMax - rMin) * i / iSize))
            Dim gAverage As Integer = gMin + CInt(((gMax - gMin) * i / iSize))
            Dim bAverage As Integer = bMin + CInt(((bMax - bMin) * i / iSize))
            colorList.Add(Color.FromArgb(rAverage, gAverage, bAverage))
        Next
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Me.Invalidate()
    End Sub

    Private Sub FormColourGradient_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = True
        frmGradientColour.Hide()
    End Sub

    Private Sub FormColourGradient_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick

        pnlSelectedColour.BackColor = ValueToColor(e.X)
    End Sub
    Private Function ValueToColor(ByVal value As Double) As Color
        Return b.GetPixel(Convert.ToInt32(value), 100)
    End Function
End Class

'Bitmap b = New Bitmap(100, 1);

'//creates the gradient scale which the display Is based upon... 
'LinearGradientBrush br = New LinearGradientBrush(New RectangleF(0, 0, 100, 5), Color.Black, Color.Black, 0, False);
'ColorBlend cb = New ColorBlend();
'cb.Positions = New[] { 0, 1 / 6f, 2 / 6f, 3 / 6f, 4 / 6f, 5 / 6f, 1 };
'cb.Colors = New[] { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.FromArgb(153, 204, 255), Color.White };
'br.InterpolationColors = cb;
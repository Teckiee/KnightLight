Public Class SceneControl1
    Public SceneIndex As Integer = -1
    Public PresetFixture As Integer = -1
    Public WithFader As Boolean = False

    Public SizeHeight As Integer = 42
    'The color and the width of the border.
    Dim borderColor As Color = Color.White 'Border Color
    Dim borderWidth As Integer = 2

    Dim formRegion As Rectangle


    Private Sub SceneControl1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bWithFader = True Then
            SizeHeight = SceneControlHeightWithFader1
        Else
            SizeHeight = SceneControlHeightWithoutFader1
        End If
        'Sets the location of the form w.r.t the position
        'formRegion = New Rectangle(0, 0, 292 + 4, SizeHeight + 4) 'Here 653 and 408 is form's Size
    End Sub
    Private Sub Form1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) ' Handles MyBase.Paint

        'Draws the border.

        'ControlPaint.DrawBorder(e.Graphics, formRegion, borderColor,
        '    borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth,
        '    ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid,
        '    borderColor, borderWidth, ButtonBorderStyle.Solid)

    End Sub


    ' SceneData(I).LocIndex is X/Y index on Presets tab WHICH IS SceneControls1.PresetFixture
    ' SceneData(I).PageNo is Page 1/2/3/4/5/6/7/8
    ' SceneIndex is Index in Scene Array
    ' PresetFixture is Index in Presets Array


End Class

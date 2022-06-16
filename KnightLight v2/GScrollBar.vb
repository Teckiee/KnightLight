'A scrollbar with graphic effects
'================================
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel

<ToolboxBitmap(GetType(Windows.Forms.HScrollBar)), DefaultEvent("ValueChanged")> _
Public Class GScrollBar
#Region "Declarations"
  Dim _mGraphicStyle As GControlGraphicStyle = GControlGraphicStyle.Solid
  Dim _mGradientColor As Color = Color.FromName("ButtonHighlight")
  Dim _mOrientation As GControlOrientation = GControlOrientation.Horizontal
  '
  Dim _mBorderStyle As GControlBorderStyle = GControlBorderStyle.Flat
  Dim _mBorderColor As Color = Color.FromName("ButtonShadow")
  '
  Dim _mFillStyle As GControlGraphicStyle = GControlGraphicStyle.Solid
  Dim _mFillColor As Color = Color.FromName("ButtonShadow")
  Dim _mFillGradientColor As Color = Color.FromName("ButtonHighlight")
  '
  Dim _mBulletStyle As GControlGraphicStyle = GControlGraphicStyle.Solid
  Dim _mBulletColor As Color = Color.FromName("Control")
  Dim _mBulletGradientColor As Color = Color.FromName("ControlLightLight")
  '
  Dim _mMax As Integer = 100
  Dim _mMin As Integer = 0
  Dim _mValue As Integer = 0
  '
  Dim bPlus As Boolean = False  'Indicates that the left or top arrow is pressed
  Dim bMinus As Boolean = False 'Indicates that the right or bottom arrow is pressed
#End Region

#Region "Events"
    <Category("Property Changed"), Description("Occurs when the control's value changes")> _
    Public Event ValueChanged(ByVal sender As Object)
#End Region

#Region "Background Properties"
  <Category("Appearance"), Description("The control's graphic style"), _
  DefaultValue(GetType(GControlGraphicStyle), "Solid")> _
  Public Property GraphicStyle() As GControlGraphicStyle
    Get
      Return _mGraphicStyle
    End Get
    Set(ByVal value As GControlGraphicStyle)
      _mGraphicStyle = value
      Me.Invalidate()
    End Set
  End Property

  <Category("Appearance"), Description("The control's gradient color"), _
  DefaultValue(GetType(Color), "ButtonHighlight")> _
  Public Property GradientColor() As Color
    Get
      Return _mGradientColor
    End Get
    Set(ByVal value As Color)
      _mGradientColor = value
      Me.Invalidate()
    End Set
  End Property

  <Category("Appearance"), Description("The control's orientation"), _
  DefaultValue(GetType(GControlOrientation), "Horizontal")> _
  Public Property Orientation() As GControlOrientation
    Get
      Return _mOrientation
    End Get
    Set(ByVal value As GControlOrientation)
      _mOrientation = value
      'Reorients the control
      Dim w As Integer = Me.Width
      Dim h As Integer = Me.Height
      Me.Width = h
      Me.Height = w
      Me.Invalidate()
    End Set
  End Property
#End Region

#Region "Track Properties"
  <Category("Track"), Description("The track's style"), _
  DefaultValue(GetType(GControlGraphicStyle), "Solid")> _
  Public Property FillStyle() As GControlGraphicStyle
    Get
      Return _mFillStyle
    End Get
    Set(ByVal value As GControlGraphicStyle)
      _mFillStyle = value
      Me.Invalidate()
    End Set
  End Property

  <Category("Track"), Description("The track's color"), _
  DefaultValue(GetType(Color), "ButtonShadow")> _
  Public Property FillColor() As Color
    Get
      Return _mFillColor
    End Get
    Set(ByVal value As Color)
      _mFillColor = value
      Me.Invalidate()
    End Set
  End Property

  <Category("Track"), Description("The track's gradient color"), _
  DefaultValue(GetType(Color), "ButtonHighlight")> _
  Public Property FillGradientColor() As Color
    Get
      Return _mFillGradientColor
    End Get
    Set(ByVal value As Color)
      _mFillGradientColor = value
      Me.Invalidate()
    End Set
  End Property
#End Region

#Region "Border Properties"
  <Category("Appearance"), Description("The control's border style"), _
  DefaultValue(GetType(GControlBorderStyle), "Flat")> _
  Public Shadows Property BorderStyle() As GControlBorderStyle
    Get
      Return _mBorderStyle
    End Get
    Set(ByVal value As GControlBorderStyle)
      _mBorderStyle = value
      Me.Invalidate()
    End Set
  End Property

  <Category("Appearance"), Description("The control's border color"), _
  DefaultValue(GetType(Color), "ButtonShadow")> _
  Public Property BorderColor() As Color
    Get
      Return _mBorderColor
    End Get
    Set(ByVal value As Color)
      _mBorderColor = value
      Me.Invalidate()
    End Set
  End Property
#End Region

#Region "Value Properties"
  <Category("Values"), Description("The control's maximum value"), _
  DefaultValue(100)> _
  Public Property Maximum() As Integer
    Get
      Return _mMax
    End Get
    Set(ByVal xvalue As Integer)
      _mMax = xvalue
      If _mMax < Minimum Then Minimum = _mMax
      If _mMax < Value Then Value = _mMax
      Me.Invalidate()
    End Set
  End Property

  <Category("Values"), Description("The control's minimum value"), _
  DefaultValue(0)> _
  Public Property Minimum() As Integer
    Get
      Return _mMin
    End Get
    Set(ByVal xvalue As Integer)
      _mMin = xvalue
      If _mMin > Maximum Then Maximum = _mMin
      If _mMin > Value Then Value = _mMin
      Me.Invalidate()
    End Set
  End Property

  <Category("Values"), Description("The control's value"), _
  DefaultValue(0)> _
  Public Property Value() As Integer
    Get
      Return _mValue
    End Get
    Set(ByVal xvalue As Integer)
      _mValue = xvalue
      If _mValue < Minimum Then _mValue = Minimum
      If _mValue > Maximum Then _mValue = Maximum
            RaiseEvent ValueChanged(Me)
      Me.Invalidate()
    End Set
  End Property
#End Region

#Region "Bullet Properties"
  <Category("Bullet"), Description("The bullet's style"), _
  DefaultValue(GetType(GControlGraphicStyle), "Solid")> _
  Public Property BulletStyle() As GControlGraphicStyle
    Get
      Return _mBulletStyle
    End Get
    Set(ByVal value As GControlGraphicStyle)
      _mBulletStyle = value
      Me.Invalidate()
    End Set
  End Property

  <Category("Bullet"), Description("The bullet's color"), _
  DefaultValue(GetType(Color), "Control")> _
  Public Property BulletColor() As Color
    Get
      Return _mBulletColor
    End Get
    Set(ByVal value As Color)
      _mBulletColor = value
      Me.Invalidate()
    End Set
  End Property

  <Category("Bullet"), Description("The bullet's gradient color"), _
  DefaultValue(GetType(Color), "ControlLightLight")> _
  Public Property BulletGradientColor() As Color
    Get
      Return _mBulletGradientColor
    End Get
    Set(ByVal value As Color)
      _mBulletGradientColor = value
      Me.Invalidate()
    End Set
  End Property
#End Region

#Region "Painting"
  Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
    MyBase.OnPaint(e)
    'Painting...
    '
    'Paint background
    PaintBackground(e.Graphics)
    'Paint filled area
    PaintTrack(e.Graphics)
    'Paint bullet
    If Maximum <> Minimum Then PaintBullet(e.Graphics)
    'Paint plus/minus
    PaintArrows(e.Graphics)
    'Paint border
    PaintBorder(e.Graphics, ClientRectangle, BorderColor, BorderStyle)
  End Sub

  Private Sub PaintBackground(ByVal g As Graphics)
    'Painting the control's background
    Dim hbr As New LinearGradientBrush(ClientRectangle, GradientColor, BackColor, 90)
    Dim vbr As New LinearGradientBrush(ClientRectangle, GradientColor, BackColor, 0)
    'Painting...
    If GraphicStyle = GControlGraphicStyle.Gradient Then
      If Orientation = GControlOrientation.Horizontal Then
        g.FillRectangle(hbr, ClientRectangle)
      Else
        g.FillRectangle(vbr, ClientRectangle)
      End If
    End If
    'Dispose
    hbr.Dispose()
    vbr.Dispose()
  End Sub

  Private Sub PaintTrack(ByVal g As Graphics)
    'Painting the track...
    Dim gp As New GraphicsPath
    Dim sbr As New SolidBrush(FillColor)
    Dim rc As Rectangle
    Dim arcrc As Rectangle
    Dim arcrc2 As Rectangle
    Dim gbr As LinearGradientBrush

    g.SmoothingMode = SmoothingMode.AntiAlias

    If Orientation = GControlOrientation.Horizontal Then
      rc = New Rectangle(15, 1, ClientRectangle.Width - 15, ClientRectangle.Height - 2)
      gbr = New LinearGradientBrush(rc, FillGradientColor, FillColor, 90)

      arcrc = New Rectangle(15, 2, _
                            ClientRectangle.Height - 5, ClientRectangle.Height - 5)
      arcrc2 = New Rectangle(ClientRectangle.Width - ClientRectangle.Height - 10, 2, _
                             ClientRectangle.Height - 5, ClientRectangle.Height - 5)
      gp.AddArc(arcrc, 90, 180)
      gp.AddArc(arcrc2, -90, 180)
    Else
      rc = New Rectangle(1, 15, ClientRectangle.Width - 2, ClientRectangle.Height - 15)
      gbr = New LinearGradientBrush(rc, FillGradientColor, FillColor, 0)

      arcrc = New Rectangle(2, 15, _
                            ClientRectangle.Width - 5, ClientRectangle.Width - 5)
      arcrc2 = New Rectangle(2, ClientRectangle.Height - ClientRectangle.Width - 10, _
                             ClientRectangle.Width - 5, ClientRectangle.Width - 5)
      gp.AddArc(arcrc, 180, 180)
      gp.AddArc(arcrc2, 0, 180)
    End If
    gp.CloseFigure()
    If FillStyle = GControlGraphicStyle.Solid Then
      g.FillPath(sbr, gp)
    Else
      g.FillPath(gbr, gp)
    End If
    g.DrawPath(New Pen(BorderColor), gp)
    'Dispose
    gp.Dispose()
    sbr.Dispose()
    gbr.Dispose()
  End Sub

  Private Sub PaintBullet(ByVal g As Graphics)
    'Painting the bullet
    'Note: some mathematics are required to calculate the position of the bullet
    '      in both orientations.
    Dim a As Double = 0
    Dim b As Double = 0
    Dim w As Integer = ClientRectangle.Width
    Dim h As Integer = ClientRectangle.Height
    Dim k As Integer = 15
    Dim s As Integer = ClientRectangle.Height - 7
    Dim sv As Integer = ClientRectangle.Width - 7
    Dim rc As Rectangle
    Dim sbr As New SolidBrush(BulletColor)
    Dim gbr As LinearGradientBrush

    g.SmoothingMode = SmoothingMode.AntiAlias

    If Orientation = GControlOrientation.Horizontal Then
      a = (w - 2 * k - s) / (Maximum - Minimum)
      b = k - Minimum * a
      rc = New Rectangle(a * Value + b, 3, s, s)
      gbr = New LinearGradientBrush(rc, BulletGradientColor, BulletColor, 90)
    Else
      a = (2 * k + sv - h) / (Maximum - Minimum)
      b = k - Maximum * a
      rc = New Rectangle(3, a * Value + b, sv, sv)
      gbr = New LinearGradientBrush(rc, BulletGradientColor, BulletColor, 0)
    End If
    'The bullet is always drawn in gradient.
    g.DrawEllipse(New Pen(BorderColor), rc)
    If BulletStyle = GControlGraphicStyle.Solid Then
      g.FillEllipse(sbr, rc)
    Else
      g.FillEllipse(gbr, rc)
    End If


    'Dispose
    g.SmoothingMode = SmoothingMode.Default
    gbr.Dispose()
    sbr.Dispose()
  End Sub

  Private Sub PaintArrows(ByVal g As Graphics)
    'Draw the arrows
    'Arrow points
    Dim ptLeft() As Point = {New Point(10, ClientRectangle.Height / 2 + 3), _
                             New Point(4, ClientRectangle.Height / 2 - 1), _
                             New Point(10, ClientRectangle.Height / 2 - 4)}
    Dim ptRight() As Point = {New Point(ClientRectangle.Width - 10, ClientRectangle.Height / 2 + 3), _
                              New Point(ClientRectangle.Width - 4, ClientRectangle.Height / 2 - 1), _
                              New Point(ClientRectangle.Width - 10, ClientRectangle.Height / 2 - 4)}
    Dim ptTop() As Point = {New Point(ClientRectangle.Width / 2 + 3, 10), _
                            New Point(ClientRectangle.Width / 2 - 1, 4), _
                            New Point(ClientRectangle.Width / 2 - 4, 10)}
    Dim ptBottom() As Point = {New Point(ClientRectangle.Width / 2 + 3, ClientRectangle.Height - 10), _
                               New Point(ClientRectangle.Width / 2, ClientRectangle.Height - 4), _
                               New Point(ClientRectangle.Width / 2 - 4, ClientRectangle.Height - 10)}
    g.SmoothingMode = SmoothingMode.AntiAlias

    If Orientation = GControlOrientation.Horizontal Then
      g.FillPolygon(Brushes.Black, ptLeft)
      g.FillPolygon(Brushes.Black, ptRight)
    Else
      g.FillPolygon(Brushes.Black, ptTop)
      g.FillPolygon(Brushes.Black, ptBottom)
    End If

    g.SmoothingMode = SmoothingMode.Default
  End Sub
#End Region

#Region "Actions"
  Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
    MyBase.OnResize(e)
    'Resizing refreshes the graphics
    Me.Invalidate()
  End Sub

  Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
    MyBase.OnMouseDown(e)
    'Detect where the click is made
    If Orientation = GControlOrientation.Horizontal Then
      If e.X < 15 Then
        bMinus = True
        bPlus = False
        tmrScroll.Enabled = True
      ElseIf e.X > ClientRectangle.Width - 15 Then
        bMinus = False
        bPlus = True
        tmrScroll.Enabled = True
      End If
    Else
      If e.Y < 15 Then
        bMinus = False
        bPlus = True
        tmrScroll.Enabled = True
      ElseIf e.Y > ClientRectangle.Height - 15 Then
        bMinus = True
        bPlus = False
        tmrScroll.Enabled = True
      End If
    End If
  End Sub

  Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
    MyBase.OnMouseUp(e)
    'Deactivate the scroll timer
    tmrScroll.Enabled = False
    bMinus = False
    bPlus = False
  End Sub

  Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
    MyBase.OnMouseMove(e)
    'Change the value by dragging. Again, some mathematics...
    Dim a As Double = 0
    Dim b As Double = 0
    Dim w As Integer = ClientRectangle.Width
    Dim h As Integer = ClientRectangle.Height
    Dim k As Integer = 15
    Dim s As Integer = ClientRectangle.Height - 7
    Dim sv As Integer = ClientRectangle.Width - 7
    'When min=max then ignore dragging!
    If Minimum = Maximum Then Exit Sub
    'When the arrows are pressed, ignore dragging!
    If bMinus = True Or bPlus = True Then Exit Sub

    If e.Button = Windows.Forms.MouseButtons.Left Then
      If Orientation = GControlOrientation.Horizontal Then
        a = (w - 2 * k - s) / (Maximum - Minimum)
        b = k - Minimum * a
        Value = (e.X - s / 2 - b) / a
      Else
        a = (2 * k + sv - h) / (Maximum - Minimum)
        b = k - Maximum * a
        Value = (e.Y - sv / 2 - b) / a
      End If

    End If
  End Sub

  Protected Overrides Sub OnMouseWheel(ByVal e As System.Windows.Forms.MouseEventArgs)
    MyBase.OnMouseWheel(e)
    'Change the value by rolling the wheel
    If e.Delta < 0 Then
      Value -= 1
    Else
      Value += 1
    End If
  End Sub

  Private Sub tmrScroll_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrScroll.Tick
    'Scroll the bar
    If bMinus = True Then
      Value -= 1
    ElseIf bPlus = True Then
      Value += 1
    End If
  End Sub
#End Region
End Class

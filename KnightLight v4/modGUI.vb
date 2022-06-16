'GUI features to be shared between all controls
'==============================================
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Module modGUI
  'Enumeration for control appearance
  Public Enum GControlGraphicStyle As Integer
    Solid = 0
    Gradient = 1
  End Enum

  'Enumeration for control border style
  Public Enum GControlBorderStyle As Integer
    None = 0
    Flat = 1      'Only in flat mode the border style can accept different colors
    SunkenSoft = 2
    SunkenHard = 3
    RaisedSoft = 4
    RaisedHard = 5
    Etched = 6
    Border = 7
  End Enum

  'Enumeration for control orientation
  Public Enum GControlOrientation As Integer
    Horizontal = 0
    Vertical = 1
  End Enum

  Public Sub PaintBorder(ByVal g As Graphics, ByVal rc As Rectangle, _
                         ByVal clr As Color, ByVal st As GControlBorderStyle)
    'Sub to draw a border around a specific area
    '
    'Sides
    Dim ptLeft() As Point = {New Point(rc.Left, rc.Top + rc.Height - 1), New Point(rc.Left, rc.Top)}
    Dim ptLeftIn() As Point = {New Point(rc.Left + 1, rc.Top + rc.Height - 2), _
                               New Point(rc.Left + 1, rc.Top + 1)}
    Dim ptTop() As Point = {New Point(rc.Left, rc.Top), New Point(rc.Left + rc.Width, rc.Top)}
    Dim ptTopIn() As Point = {New Point(rc.Left + 1, rc.Top + 1), _
                              New Point(rc.Left + rc.Width - 2, rc.Top + 1)}
    Dim ptRight() As Point = {New Point(rc.Left + rc.Width - 1, rc.Top), _
                              New Point(rc.Left + rc.Width - 1, rc.Top + rc.Height)}
    Dim ptRightIn() As Point = {New Point(rc.Left + rc.Width - 2, rc.Top + 1), _
                                New Point(rc.Left + rc.Width - 2, rc.Top + rc.Height - 2)}
    Dim ptBottom() As Point = {New Point(rc.Left, rc.Top + rc.Height - 1), _
                               New Point(rc.Left + rc.Width - 1, rc.Top + rc.Height - 1)}
    Dim ptBottomIn() As Point = {New Point(rc.Left + 1, rc.Top + rc.Height - 2), _
                               New Point(rc.Left + rc.Width - 2, rc.Top + rc.Height - 2)}
    'Pens
    Dim pColor As New Pen(clr)
    Dim pControl As New Pen(Color.FromName("ButtonFace"))
    Dim pShadow As New Pen(Color.FromName("ButtonShadow"))
    Dim pLight As New Pen(Color.FromName("ButtonHighLight"))
    Dim pDark As New Pen(Color.FromName("ControlDarkDark"))
    'Painting
    Select Case st
      Case GControlBorderStyle.Flat 'Flat border
        g.DrawLines(pColor, ptLeft)
        g.DrawLines(pColor, ptTop)
        g.DrawLines(pColor, ptRight)
        g.DrawLines(pColor, ptBottom)
      Case GControlBorderStyle.RaisedSoft 'Softly raised border
        g.DrawLines(pLight, ptLeft)
        g.DrawLines(pLight, ptTop)
        g.DrawLines(pShadow, ptRight)
        g.DrawLines(pShadow, ptBottom)
      Case GControlBorderStyle.SunkenSoft 'Softly sunken border
        g.DrawLines(pShadow, ptLeft)
        g.DrawLines(pShadow, ptTop)
        g.DrawLines(pLight, ptRight)
        g.DrawLines(pLight, ptBottom)
      Case GControlBorderStyle.RaisedHard 'Hardly raised border
        g.DrawLines(pLight, ptLeft) : g.DrawLines(pControl, ptLeftIn)
        g.DrawLines(pLight, ptTop) : g.DrawLines(pControl, ptTopIn)
        g.DrawLines(pDark, ptRight) : g.DrawLines(pShadow, ptRightIn)
        g.DrawLines(pDark, ptBottom) : g.DrawLines(pShadow, ptBottomIn)
      Case GControlBorderStyle.SunkenHard 'Hardly sunken border
        g.DrawLines(pDark, ptLeft) : g.DrawLines(pShadow, ptLeftIn)
        g.DrawLines(pDark, ptTop) : g.DrawLines(pShadow, ptTopIn)
        g.DrawLines(pLight, ptRight) : g.DrawLines(pControl, ptRightIn)
        g.DrawLines(pLight, ptBottom) : g.DrawLines(pControl, ptBottomIn)
      Case GControlBorderStyle.Etched 'Etched border
        g.DrawLines(pShadow, ptLeft) : g.DrawLines(pLight, ptLeftIn)
        g.DrawLines(pShadow, ptTop) : g.DrawLines(pLight, ptTopIn)
        g.DrawLines(pLight, ptRight) : g.DrawLines(pShadow, ptRightIn)
        g.DrawLines(pLight, ptBottom) : g.DrawLines(pShadow, ptBottomIn)
      Case GControlBorderStyle.Border 'Bordered border
        g.DrawLines(pShadow, ptLeft) : g.DrawLines(pLight, ptLeftIn)
        g.DrawLines(pShadow, ptTop) : g.DrawLines(pLight, ptTopIn)
        g.DrawLines(pShadow, ptRight) : g.DrawLines(pLight, ptRightIn)
        g.DrawLines(pShadow, ptBottom) : g.DrawLines(pLight, ptBottomIn)
    End Select
    'Disposing
    pColor.Dispose()
    pControl.Dispose()
    pShadow.Dispose()
    pLight.Dispose()
    pDark.Dispose()
  End Sub
End Module

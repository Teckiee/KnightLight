Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports NAudio.Wave
Public Class CustomWaves
    Inherits System.Windows.Forms.UserControl

    Public Property PenColor As Color
    Public Property PenWidth As Single

    Public Sub FitToScreen()
        If WaveStream Is Nothing Then Return
        Dim samples As Integer = CInt((WaveStream.Length / _bytesPerSample))
        StartPosition = 0
        SamplesPerPixel = samples / Me.Width
    End Sub

    Public Sub Zoom(ByVal leftSample As Integer, ByVal rightSample As Integer)
        StartPosition = leftSample * _bytesPerSample
        SamplesPerPixel = (rightSample - leftSample) / Me.Width
    End Sub

    Private mousePos, startPos As Point
    Private mouseDrag As Boolean = False
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            startPos = e.Location
            mousePos = New Point(-1, -1)
            mouseDrag = True
            DrawVerticalLine(e.X)
        End If

        MyBase.OnMouseDown(e)
    End Sub
    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        If mouseDrag Then
            DrawVerticalLine(e.X)
            If mousePos.X <> -1 Then DrawVerticalLine(mousePos.X)
            mousePos = e.Location
        End If

        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        If mouseDrag AndAlso e.Button = System.Windows.Forms.MouseButtons.Left Then
            mouseDrag = False
            DrawVerticalLine(startPos.X)
            If mousePos.X = -1 Then Return
            DrawVerticalLine(mousePos.X)
            Dim leftSample As Integer = CInt((_startPosition / _bytesPerSample + _samplesPerPixel * Math.Min(startPos.X, mousePos.X)))
            Dim rightSample As Integer = CInt((_startPosition / _bytesPerSample + _samplesPerPixel * Math.Max(startPos.X, mousePos.X)))
            Zoom(leftSample, rightSample)
        ElseIf e.Button = System.Windows.Forms.MouseButtons.Middle Then
            FitToScreen()
        End If

        MyBase.OnMouseUp(e)
    End Sub

    Private Sub DrawVerticalLine(ByVal x As Integer)
        ControlPaint.DrawReversibleLine(PointToScreen(New Point(x, 0)), PointToScreen(New Point(x, Height)), Color.Black)
    End Sub
    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        FitToScreen()
    End Sub

    'Private _components As System.ComponentModel.Container = Nothing
    Private _waveStream As NAudio.Wave.WaveStream
    Private _samplesPerPixel As Integer = 128
    Private _startPosition As Long
    Private _bytesPerSample As Integer

    'Public Sub New()
    '    InitializeComponent()
    '    Me.DoubleBuffered = True
    '    Me.PenColor = Color.DodgerBlue
    '    Me.PenWidth = 1
    'End Sub
    Public Property WaveStream As NAudio.Wave.WaveStream
        Get
            Return _waveStream
        End Get
        Set(ByVal value As NAudio.Wave.WaveStream)
            _waveStream = value

            If _waveStream IsNot Nothing Then
                _bytesPerSample = (_waveStream.WaveFormat.BitsPerSample / 8) * _waveStream.WaveFormat.Channels
            End If

            Me.Invalidate()
        End Set
    End Property
    Public Property SamplesPerPixel As Integer
        Get
            Return _samplesPerPixel
        End Get
        Set(ByVal value As Integer)
            _samplesPerPixel = Math.Max(1, value)
            Me.Invalidate()
        End Set
    End Property

    Public Property StartPosition As Long
        Get
            Return _startPosition
        End Get
        Set(ByVal value As Long)
            _startPosition = value
        End Set
    End Property

    'Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    '    If disposing Then

    '        If _components IsNot Nothing Then
    '            _components.Dispose()
    '        End If
    '    End If

    '    MyBase.Dispose(disposing)
    'End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If _waveStream IsNot Nothing Then
            _waveStream.Position = 0
            Dim bytesRead As Integer
            Dim waveData As Byte() = New Byte(_samplesPerPixel * _bytesPerSample - 1) {}
            _waveStream.Position = _startPosition + (e.ClipRectangle.Left * _bytesPerSample * _samplesPerPixel)

            Using linePen As Pen = New Pen(PenColor, PenWidth)

                For x As Single = e.ClipRectangle.X To e.ClipRectangle.Right - 1
                    Dim low As Short = 0
                    Dim high As Short = 0
                    bytesRead = _waveStream.Read(waveData, 0, _samplesPerPixel * _bytesPerSample)
                    If bytesRead = 0 Then Exit For

                    For n As Integer = 0 To bytesRead - 1 Step 2
                        Dim sample As Short = BitConverter.ToInt16(waveData, n)
                        If sample < low Then low = sample
                        If sample > high Then high = sample
                    Next

                    Dim lowPercent As Single = (((CSng(low)) - Short.MinValue) / UShort.MaxValue)
                    Dim highPercent As Single = (((CSng(high)) - Short.MinValue) / UShort.MaxValue)
                    e.Graphics.DrawLine(linePen, x, Me.Height * lowPercent, x, Me.Height * highPercent)
                Next
            End Using
        End If

        MyBase.OnPaint(e)
    End Sub

    'Private Sub InitializeComponent()
    '    _components = New System.ComponentModel.Container()
    'End Sub

End Class

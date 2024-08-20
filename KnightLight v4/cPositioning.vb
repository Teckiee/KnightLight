Imports ScottPlot.Plottable

Public Class cPositioning

    Dim _tagX As Double
    Dim _tagY As Double
    Dim _tagZ As Double
    Dim _tagAddr As String

    Public Property tagX As Double
        Get
            Return _tagX
        End Get
        Set(value As Double)
            _tagX = value
        End Set
    End Property
    Public Property tagY As Double
        Get
            Return _tagY
        End Get
        Set(value As Double)
            _tagY = value
        End Set
    End Property
    Public Property tagZ As Double
        Get
            Return _tagZ
        End Get
        Set(value As Double)
            _tagZ = value
        End Set
    End Property
    Public Property tagAddr As String
        Get
            Return _tagAddr
        End Get
        Set(value As String)
            _tagAddr = value
        End Set
    End Property

    Public Function CalculatePanTilt(lightPosition As Vector3, tagPosition As Vector3, Optional panOffset As Double = 0, Optional tiltOffset As Double = 0, Optional invertPan As Boolean = False, Optional invertTilt As Boolean = False) As (Pan As Double, Tilt As Double)
        ' Calculate the difference in position
        Dim delta As Vector3 = tagPosition - lightPosition

        ' Calculate the pan angle (horizontal rotation)
        Dim pan As Double = Math.Atan2(delta.Y, delta.X)

        ' Calculate the tilt angle (vertical rotation)
        Dim tilt As Double = Math.Atan2(delta.Z, Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y))

        ' Convert from radians to degrees
        pan = pan * (180.0 / Math.PI)
        tilt = tilt * (180.0 / Math.PI)

        ' Invert the angles if necessary
        If invertPan Then
            pan = 360 - pan
        End If
        If invertTilt Then
            tilt = 180 - tilt
        End If

        ' Add the offsets
        pan = (pan + panOffset) Mod 360
        tilt = (tilt + tiltOffset) Mod 360

        ' Ensure the angles are positive
        If pan < 0 Then
            pan += 360
        End If
        If tilt < 0 Then
            tilt += 180
        End If
        If pan > 360 Then
            pan -= 360
        End If
        If tilt > 0 Then
            tilt -= 180
        End If




        Return (Pan:=pan, Tilt:=tilt)
    End Function

End Class

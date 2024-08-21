Namespace Knightlight_v5_GUI
    Public Module LinExpConvert
        Public Function Convert(value As Double, min As Double, max As Double, Optional normalizeIn As Boolean = True, Optional normalizeOut As Boolean = False) As Double
            'return (double)value;
            Dim x = value
            ' if (normalizeIn)
            x = (x - min) / (max - min)

            If min = -99 AndAlso max = 10 Then
                If normalizeIn Then x = (x - min) / (max - min)
                x = EmulatedLinExpConvert(x)
                If Not normalizeOut Then x = x * (max - min) + min
            Else
                If normalizeIn Then x = (x - Math.Max(min, 0)) / (max - Math.Max(min, 0))
                x = MathematicalLinExpConvert(x)
                If Not normalizeOut Then x = x * (max - Math.Max(min, 0)) + Math.Max(min, 0)
            End If

            ' if (!normalizeOut)
            x = x * (max - min) + min

            Return x
        End Function
        Public Function ConvertBack(value As Double, min As Double, max As Double, Optional normalizeIn As Boolean = True, Optional normalizeOut As Boolean = False) As Double
            'return (double)value;
            Dim x = value
            'if (normalizeIn)
            '    x = (x - min) / (max - min);

            If min = -99 AndAlso max = 10 Then
                If normalizeIn Then x = (x - min) / (max - min)
                x = EmulatedLinExpConvertBack(x)
                If Not normalizeOut Then x = x * (max - min) + min
            Else
                If normalizeIn Then x = (x - Math.Max(min, 0)) / (Math.Max(max, Math.Abs(min)) - Math.Max(min, 0))
                x = MathematicalLinExpConvertBack(x)
                If Not normalizeOut Then x = x * (Math.Max(max, Math.Abs(min)) - Math.Max(min, 0)) + Math.Max(min, 0)
            End If

            'if (!normalizeOut)
            '    x = x * (max - min) + min;

            Return x
        End Function
        Private Function MathematicalLinExpConvert(x As Double) As Double
            'return Math.Exp((x - 4.6293) / 19.661);
            'return Math.Exp((x-0.9468) / 0.1947);
            'Debug.WriteLine("LinExpConvert To: " + x + " => " + Math.Sign(x) * Math.Pow(Math.Abs(x), 3.7));
            'return x * Math.Pow(1.5, 10*(Math.Abs(x)-1)); I want to use this one but it's inverse requires a Lambert function
            Return Math.Sign(x) * Math.Pow(Math.Abs(x), 1 / 3.5)
        End Function

        Private Function MathematicalLinExpConvertBack(x As Double) As Double
            'return 19.661 * Math.Log(x) + 4.6293;
            'return 0.1947 * Math.Log(x) + 0.9468;
            'Debug.WriteLine("LinExpConvert Back: " + x + " => " + Math.Sign(x) * Math.Pow(Math.Abs(x), 1 / 3.7));
            'This is ugly and still not quite right
            'return (Math.Log(x + 0.01734152992) * 0.1 / Math.Log(1.5) + 1) * 0.995759713646;
            Return Math.Sign(x) * Math.Pow(Math.Abs(x), 3.5)
        End Function
        Private Function EmulatedLinExpConvertBack(x As Double) As Double
            'This works assuming that the LUT is in order.
            Dim minBound = _02rFaderLUT.LastOrDefault(Function(y) y.x <= x)
            Dim maxBound = _02rFaderLUT.FirstOrDefault(Function(y) y.x > x)

            'Edge case
            If x >= 1 Then Return minBound.y

            'Interpolate
            Dim xfrac = (x - minBound.x) / (maxBound.x - minBound.x)
            Dim interp = minBound.y * (1 - xfrac) + maxBound.y * xfrac

            Return interp
        End Function

        Private Function EmulatedLinExpConvert(x As Double) As Double
            'This works assuming that the LUT is in order.
            Dim minBound = _02rFaderLUT.LastOrDefault(Function(y) y.y <= x)
            Dim maxBound = _02rFaderLUT.FirstOrDefault(Function(y) y.y > x)

            'Edge case
            If x >= 1 Then Return minBound.x

            'Interpolate
            Dim xfrac = (x - minBound.y) / (maxBound.y - minBound.y)
            Dim interp = minBound.x * (1 - xfrac) + maxBound.x * xfrac

            Return interp
        End Function
        Private Structure LUTItem
            Public x As Double
            Public y As Double
        End Structure

        Private _02rFaderLUT As LUTItem() = {
            New LUTItem() With {.x = 0, .y = 0.000000},
            New LUTItem() With {.x = 0.00833333, .y = 0.009901},
            New LUTItem() With {.x = 0.04166667, .y = 0.405941},
            New LUTItem() With {.x = 0.16666667, .y = 0.60396},
            New LUTItem() With {.x = 0.30833333, .y = 0.70297},
            New LUTItem() With {.x = 0.7, .y = 0.851485},
            New LUTItem() With {.x = 0.80833333, .y = 0.90099},
            New LUTItem() With {.x = 0.9, .y = 0.950495},
            New LUTItem() With {.x = 1.0, .y = 1.0}
         }


    End Module
End Namespace
Imports System.Globalization

Namespace Knightlight_v5_GUI
    Public Class ValueConverter

    End Class
    Public Class DivideByTwoConverter
        Implements IValueConverter

        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
            Dim originalValue As Double = CDbl(value)
            Return originalValue / 2
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace
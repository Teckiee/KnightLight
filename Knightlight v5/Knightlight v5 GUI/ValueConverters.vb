Imports System
Imports System.Globalization
Imports System.Linq
Imports System.Windows.Data
Imports System.Windows.Markup
Imports System.Windows.Media

Namespace Knightlight_v5_GUI.ViewModel

    <ValueConversion(GetType(Object), GetType(Object))>
    Public Class DebugConverter
        Implements IValueConverter
        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
            'Debugger.Break();
            Console.WriteLine("Binding data (to binding): " & value.ToString() & " // Type: " & value.GetType().ToString() & " -> " & targetType.ToString() & " // Target: " & parameter.ToString())
            Return value
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            'Debugger.Break();
            Console.WriteLine("Binding data (from binding): " & value.ToString() & " Type: " & value.GetType().ToString() & " <- " & targetType.ToString() & " // Target: " & parameter.ToString())
            Return value
        End Function
    End Class

    <ValueConversion(GetType(Integer), GetType(Integer))>
    Public Class IndexToNumberConverter
        Implements IValueConverter
        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
            'Special conversions
            If CInt(value) = -1 Then Return "ST"
            'Generic conversion
            If parameter IsNot Nothing AndAlso CInt(value) < 0 Then
                Return CStr(parameter)
            ElseIf parameter IsNot Nothing Then
                Return CStr(parameter) & (CInt(value) + 1).ToString()
            Else
                Return CInt(value) + 1
            End If
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Return CInt(value) - 1
        End Function
    End Class

    <ValueConversion(GetType(Integer), GetType(Boolean))>
    Public Class IndexConverter
        Implements IValueConverter
        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
            Dim bInd As Integer = Nothing

            If Integer.TryParse(TryCast(parameter, String), bInd) AndAlso value IsNot Nothing Then
                Return CInt(value) = bInd
            End If
            Return False
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            If value Then
                Return Integer.Parse(TryCast(parameter, String))
            End If
            Return Nothing
        End Function
    End Class

    <ValueConversion(GetType(Boolean()), GetType(Boolean))>
    Public Class BoolArrayIndexConverter
        Implements IValueConverter
        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
            If value Is Nothing OrElse parameter Is Nothing Then Return False
            Return CType(value, Boolean())(Integer.Parse(CStr(parameter)))
        End Function

        'This conversion is not possible
        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function
    End Class

    ''' <summary>
    ''' Applies the slight exponential falloff to the faders
    ''' </summary>
    <ValueConversion(GetType(Double), GetType(Double))>
    Public Class LinExpConverter
        Implements IValueConverter
        Public Property Minimum As Double
        Public Property Maximum As Double
        Public Property Power As Double

        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
            'return (double)value;
            Dim x As Double = value

            x = LinExpConvert.Convert(x, Minimum, Maximum)

            Return x
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            'return (double)value;
            Dim x As Double = value

            x = LinExpConvert.ConvertBack(x, Minimum, Maximum)

            Return x
        End Function
    End Class

    <ValueConversion(GetType(Object()), GetType(Object))>
    Public Class MultiObjectPackerConverter
        Implements IMultiValueConverter
        Public Function Convert(values As Object(), targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
            Return values
        End Function

        Public Function ConvertBack(value As Object, targetTypes As Type(), parameter As Object, culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
            Return TryCast(value, Object())
        End Function
    End Class

    ''' <summary>
    ''' Converts a value into a knob rotation.
    ''' Parameters:
    '''  - double[0]: Minimum
    '''  - double[1]: Maximum
    '''  - bool[2]: LinToExp
    ''' </summary>
    <ValueConversion(GetType(Double), GetType(Double))>
    Public Class KnobValueToAngleConverter
        Implements IValueConverter
        Private arcEndAngle As Integer = 150
        Private arcStartAngle As Integer = -150

        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
            'return (double)value;
            Dim x As Double = value

            Dim paramsList As Object() = TryCast(parameter, Object())
            If If(paramsList?.Length, 0) < 3 Then Return 0
            Dim minimum As Double = paramsList(0)
            Dim maximum As Double = paramsList(1)
            Dim linToExp As Boolean = paramsList(2)

            If linToExp Then x = LinExpConvert.Convert(x, minimum, maximum)

            x = (arcEndAngle - arcStartAngle) / (maximum - minimum) * (x - minimum) + arcStartAngle

            Return x
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            'return (double)value;
            Dim x As Double = value

            Dim paramsList As Object() = TryCast(parameter, Object())
            If If(paramsList?.Length, 0) < 3 Then Return 0
            Dim minimum As Double = paramsList(0)
            Dim maximum As Double = paramsList(1)
            Dim linToExp As Boolean = paramsList(2)

            If linToExp Then x = LinExpConvert.ConvertBack(x, minimum, maximum)

            x = (x - arcStartAngle) / ((arcEndAngle - arcStartAngle) / (maximum - minimum)) + minimum

            Return x
        End Function
    End Class

    ''' <summary>
    ''' Converts a title, a unit and a value into a single display string
    ''' Arguments:
    ''' 0 - Title
    ''' 1 - Value (double)
    ''' 2 - Unit
    ''' 3 - Decimal Places (int)
    ''' 4 - Metric Truncation (bool)
    ''' </summary>
    <ValueConversion(GetType(Object()), GetType(String))>
    Public Class KnobTitleConverter
        Implements IMultiValueConverter
        Public Function Convert(values As Object(), targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
            Dim ret As String = TryCast(values(0), String)

            ' for Value Label
            ret += vbLf & Math.Round(CDbl(values(1)) / If(CBool(values(4)) AndAlso CDbl(values(1)) > 1000, 1000, 1), CInt(values(3))).ToString()

            If CStr(values(2)).Length > 0 Then
                ret += "[" & If(CBool(values(4)) AndAlso CDbl(values(1)) > 1000, "K", "") & CStr(values(2)) & "]"
            End If

            Return ret
        End Function

        'No way
        Public Function ConvertBack(value As Object, targetTypes As Type(), parameter As Object, culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function
    End Class

    ''' <summary>
    ''' Takes an input value and a unit and concatinates them
    ''' </summary>
    <ValueConversion(GetType(Integer), GetType(Integer))>
    Public Class ValueAndUnitConverter
        Implements IValueConverter
        Public Property DecimalPlaces As Integer

        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
            Dim o As String = Math.Round(CDbl(value), DecimalPlaces).ToString()

            If CStr(parameter).Length > 0 Then
                o += " [" & CStr(parameter) & "]"
            End If

            Return o
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Return Nothing
        End Function
    End Class

    ''' <summary>
    ''' Converts between a BackgroundColor and a SolidColorBrush
    ''' </summary>
    <ValueConversion(GetType(Color), GetType(SolidColorBrush))>
    Public Class ColorToBrushConverter
        Implements IValueConverter
        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
            Return New SolidColorBrush(value)
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Return CType(value, SolidColorBrush).Color
        End Function
    End Class

    ''' <summary>
    ''' Converts between a BackgroundColor and a SolidColorBrush
    ''' </summary>
    <ValueConversion(GetType(Boolean), GetType(String))>
    Public Class DarkModeToThemePathConverter
        Implements IValueConverter
        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
            Return If(value, "DarkTheme", "LightTheme")
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Return True
        End Function

        Public Shared Function StaticConvert(value As Boolean) As String
            Return If(value, "DarkTheme", "LightTheme")
        End Function

        Public Shared Function StaticConvertBack(value As String) As Boolean
            Return True
        End Function
    End Class

    ''' <summary>
    ''' Converts between a BackgroundColor and a SolidColorBrush
    ''' </summary>
    '<ValueConversion(GetType(Integer), GetType(String))>
    'Public Class IndexToMixerProfileConverter
    '    Implements IValueConverter
    '    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
    '        Dim profiles As String() = SettingsManager.GetMixerProfiles()
    '        Return Array.IndexOf(profiles, value)
    '    End Function

    '    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
    '        Dim profiles As String() = SettingsManager.GetMixerProfiles()
    '        Return profiles(value)
    '    End Function
    'End Class

    <ContentProperty(NameOf(ConverterBindableParameter.Binding))>
    Public Class ConverterBindableParameter
        Inherits MarkupExtension
#Region "Public Properties"

        Public Property Binding As Binding
        Public Property Mode As BindingMode
        Public Property Converter As IValueConverter
        Public Property ConverterParameter As MultiBinding

#End Region

        Public Sub New()

        End Sub

        Public Sub New(path As String)
            Binding = New Binding(path)
        End Sub

        Public Sub New(binding As Binding)
            Me.Binding = binding
        End Sub

#Region "Overridden Methods"

        Public Overrides Function ProvideValue(serviceProvider As IServiceProvider) As Object
            Dim multiBinding = New MultiBinding()
            Binding.Mode = Mode
            multiBinding.Bindings.Add(Binding)
            If ConverterParameter IsNot Nothing Then
                ConverterParameter.Mode = BindingMode.OneWay
                For Each b As Binding In ConverterParameter.Bindings
                    multiBinding.Bindings.Add(b)
                Next
            End If
            Dim adapter = New MultiValueConverterAdapter With {
.Converter = Converter
}
            multiBinding.Converter = adapter
            Return multiBinding.ProvideValue(serviceProvider)
        End Function

#End Region

        <ContentProperty(NameOf(MultiValueConverterAdapter.Converter))>
        Private Class MultiValueConverterAdapter
            Implements IMultiValueConverter
            Public Property Converter As IValueConverter

            Private lastParameter As Object

            Public Function Convert(values As Object(), targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
                If Converter Is Nothing Then Return values(0) ' Required for VS design-time
                If values.Length > 1 Then lastParameter = values.Skip(1).ToArray()
                Return Converter.Convert(values(0), targetType, lastParameter, culture)
            End Function

            Public Function ConvertBack(value As Object, targetTypes As Type(), parameter As Object, culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
                If Converter Is Nothing Then Return New Object() {value} ' Required for VS design-time

                Return New Object() {Converter.ConvertBack(value, targetTypes(0), lastParameter, culture)}
            End Function
        End Class
    End Class
End Namespace

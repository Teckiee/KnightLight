Imports System
Imports System.ComponentModel
Imports System.Globalization
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows.Media

Namespace Knightlight_v5_GUI
    ' <summary>
    ' Interaction logic for VerticalSlider.xaml
    ' </summary>
    <DefaultEvent("ValueChanged"), DefaultProperty("Value")>
    Partial Public Class VerticalSlider
        Inherits UserControl
        Public Sub New()
            InitializeComponent()
        End Sub

        'private double lastFaderHeight = 0;
        Private valueTypeInCloseHandler As MouseButtonEventHandler

        'Component Dependancy Properties
        Public Shared ReadOnly MinimumProperty As DependencyProperty = DependencyProperty.Register("Minimum", GetType(Double), GetType(VerticalSlider))
        Public Shared ReadOnly MaximumProperty As DependencyProperty = DependencyProperty.Register("Maximum", GetType(Double), GetType(VerticalSlider))
        Public Shared ReadOnly SmallIncrementProperty As DependencyProperty = DependencyProperty.Register("SmallIncrement", GetType(Double), GetType(VerticalSlider))
        Public Shared ReadOnly LargeIncrementProperty As DependencyProperty = DependencyProperty.Register("LargeIncrement", GetType(Double), GetType(VerticalSlider))
        Public Shared ReadOnly ValueProperty As DependencyProperty = DependencyProperty.Register("Value", GetType(Double), GetType(VerticalSlider), New PropertyMetadata(0R, New PropertyChangedCallback(AddressOf OnSliderValueChanged), New CoerceValueCallback(AddressOf CoerceSliderValue)))
        Public Shared ReadOnly TitleProperty As DependencyProperty = DependencyProperty.Register("Title", GetType(String), GetType(VerticalSlider))
        Public Shared ReadOnly UnitProperty As DependencyProperty = DependencyProperty.Register("Unit", GetType(String), GetType(VerticalSlider))
        Public Shared ReadOnly TickSpacingProperty As DependencyProperty = DependencyProperty.Register("TickSpacing", GetType(Double), GetType(VerticalSlider))
        Public Shared ReadOnly ValueSpacingProperty As DependencyProperty = DependencyProperty.Register("ValueSpacing", GetType(Double), GetType(VerticalSlider))
        Public Shared ReadOnly DecimalPlacesProperty As DependencyProperty = DependencyProperty.Register("DecimalPlaces", GetType(Integer), GetType(VerticalSlider))
        'public static readonly DependencyProperty ValueChangedProp =    DependencyProperty.Register("ValueChanged",     typeof(RoutedPropertyChangedEventHandler<double>), typeof(VerticalSlider));

        Private Shared ReadOnly ValueChangeEvent As RoutedEvent = EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Bubble, GetType(RoutedEventHandler), GetType(VerticalSlider))

        'Events
        Public Custom Event ValueChanged As RoutedEventHandler
            AddHandler(value As RoutedEventHandler)
                [AddHandler](ValueChangeEvent, value)
            End AddHandler
            RemoveHandler(value As RoutedEventHandler)
                [RemoveHandler](ValueChangeEvent, value)
            End RemoveHandler
            RaiseEvent(sender As Object, e As RoutedEventArgs)
            End RaiseEvent
        End Event

        'Properties
        <Description("Gets or sets title for the Vertical Slider."), Category("Vertical Slider")>
        Public Property Title As String
            Get
                Return CStr(GetValue(TitleProperty))
            End Get
            Set(value As String)
                SetValue(TitleProperty, value)
                Update()
            End Set
        End Property

        <Description("Gets or sets unit text for the Vertical Slider."), Category("Vertical Slider")>
        Public Property Unit As String
            Get
                Return CStr(GetValue(UnitProperty))
            End Get
            Set(value As String)
                SetValue(UnitProperty, value)
                Update()
            End Set
        End Property

        <Description("Gets or sets value for the Vertical Slider."), Category("Vertical Slider")>
        Public Property Value As Double
            Get
                Return GetValue(ValueProperty)
            End Get
            Set(value As Double)
                SetValue(ValueProperty, value)
                Update()

                [RaiseEvent](New RoutedEventArgs(ValueChangeEvent))
            End Set
        End Property

        <Description("Gets or sets the minimum value for the Vertical Slider. It can not be more than the maximum."), Category("Vertical Slider")>
        Public Property Minimum As Double
            Get
                Return GetValue(MinimumProperty)
            End Get
            Set(value As Double)
                SetValue(MinimumProperty, value)
                Me.VSlider.Minimum = value
                DrawValueLabels()
                Update()
            End Set
        End Property

        <Description("Gets or sets the maximum value for the Vertical Slider. It can not be less than the maximum."), Category("Vertical Slider")>
        Public Property Maximum As Double
            Get
                Return GetValue(MaximumProperty)
            End Get
            Set(value As Double)
                SetValue(MaximumProperty, value)
                Me.VSlider.Maximum = value
                DrawValueLabels()
                Update()
            End Set
        End Property

        <Description("Gets or sets the number of decimal places for the Vertical Slider."), Category("Vertical Slider")>
        Public Property DecimalPlaces As Integer
            Get
                Return GetValue(DecimalPlacesProperty)
            End Get
            Set(value As Integer)
                SetValue(DecimalPlacesProperty, value)
                Update()
            End Set
        End Property

        <Description("Gets or sets the smallest increment for the Vertical Slider."), Category("Vertical Slider")>
        Public Property SmallIncrement As Double
            Get
                Return GetValue(SmallIncrementProperty)
            End Get
            Set(value As Double)
                SetValue(SmallIncrementProperty, value)
                Update()
            End Set
        End Property

        <Description("Gets or sets the quick scrubbing increment for the Vertical Slider."), Category("Vertical Slider")>
        Public Property LargeIncrement As Double
            Get
                Return GetValue(LargeIncrementProperty)
            End Get
            Set(value As Double)
                SetValue(LargeIncrementProperty, value)
                Update()
            End Set
        End Property

        <Description("Gets or sets the the distance between ticks for the Vertical Slider."), Category("Vertical Slider")>
        Public Property TickSpacing As Double
            Get
                Return GetValue(TickSpacingProperty)
            End Get
            Set(value As Double)
                SetValue(TickSpacingProperty, value)
                Update()
            End Set
        End Property

        <Description("Gets or sets the the distance between values for the Vertical Slider."), Category("Vertical Slider")>
        Public Property ValueSpacing As Double
            Get
                Return GetValue(ValueSpacingProperty)
            End Get
            Set(value As Double)
                SetValue(ValueSpacingProperty, value)
                DrawValueLabels()
                Update()
            End Set
        End Property

        ''' <summary>
        ''' Clamp the input between min and max.
        ''' </summary>
        ''' <paramname="d"></param>
        ''' <paramname="baseValue"></param>
        ''' <returns></returns>
        Private Shared Function CoerceSliderValue(d As DependencyObject, baseValue As Object) As Object
            Dim v = CType(d, VerticalSlider)
            Dim x As Double = baseValue

            x = If(x < v.Minimum, v.Minimum, x)
            x = If(x > v.Maximum, v.Maximum, x)
            Return x
        End Function

        Private Shared Sub OnSliderValueChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
            Dim v = CType(d, VerticalSlider)
            d.CoerceValue(ValueProperty)
        End Sub

        Public Sub DrawValueLabel(value As Double)
            If Maximum - Minimum <= 0 Then Return

            Dim nLabel As Label = New Label()
            nLabel.Content = Math.Round(LinExpConvert.ConvertBack(value, Minimum, Maximum, CBool(True), CBool(False)), CInt(DecimalPlaces)).ToString()
            nLabel.FontSize = 8
            nLabel.HorizontalAlignment = HorizontalAlignment.Stretch
            nLabel.VerticalAlignment = VerticalAlignment.Bottom
            nLabel.Foreground = CType(Application.Current.Resources("Text"), SolidColorBrush)
            nLabel.Tag = "ValueLabel"
            nLabel.VerticalContentAlignment = VerticalAlignment.Center
            nLabel.Padding = New Thickness(0)

            Dim s = CType(FindName("VSlider"), Slider)
            Dim newY = value / (Maximum - Minimum) * (s.ActualHeight - 20) - (s.ActualHeight - 20) * (Minimum / (Maximum - Minimum)) + 10 '+5 to account for internal padding in the slider
            newY -= (nLabel.FontSize + nLabel.Padding.Bottom + nLabel.Padding.Top) / 2 'This should work to calculate the height of the element
            'Console.WriteLine("Creating value label @" + newY + " //Value=" + LinToExp(value).ToString());

            nLabel.Margin = New Thickness(0, 0, 0, newY)
            Dim g = CType(FindName("SliderGrid"), Grid)
            Grid.SetRow(nLabel, 0)
            Grid.SetColumn(nLabel, 2)

            g.Children.Add(nLabel)
        End Sub

        'TODO: Improve speed
        Public Sub DrawValueLabels()
            If ValueSpacing <= 0 Then Return

            'Delete old labels
            'Dim oldLabels As Label() = CType(FindName(CStr("SliderGrid")), Grid).Children.OfType(Of Label)().Where(Of Label)(Function(x) Equals(CStr(x.Tag), "ValueLabel")).ToArray()
            Dim oldLabels As Label() = CType(FindName("SliderGrid"), Grid).Children.OfType(Of Label)().Where(Function(x) CType(x.Tag, String) = "ValueLabel").ToArray()
            For Each l In oldLabels
                CType(FindName("SliderGrid"), Grid).Children.Remove(l)
            Next

            'Place new labels at regular linear interval
            Dim valuesToPlace As Integer = Math.Floor((Maximum - Minimum) / ValueSpacing)
            'Splitting into two ensures that 0 will always be marked
            Dim i = Math.Max(Minimum, 0)

            While i <= Maximum + 0.1
                DrawValueLabel(i)
                i += ValueSpacing
            End While
            Dim i2 = Minimum

            While i2 < 0
                DrawValueLabel(i2)
                i2 += ValueSpacing
            End While
        End Sub

        Public Sub Update()
            ' for Title Label
            If String.IsNullOrEmpty(Title) Then Exit Sub
            Try

                Me.VSliderLabel.Text = String.Empty
                If Title.Length > 0 Then
                    'Me.VSliderLabel.Text = Title
                End If

                ' for Value Label
                'Me.VSliderLabel.Text += vbLf & Math.Round(Value, DecimalPlaces).ToString()
                Me.VSliderLabel.Text += Math.Round(Value, DecimalPlaces).ToString()

                If Unit.Length > 0 Then
                    'Me.VSliderLabel.Text += "[" & Unit & "]"
                End If
            Catch __unusedException1__ As Exception
                Console.WriteLine("Slider Not Initialised Yet!")
            End Try
        End Sub

        'TODO: Not working
        Private Sub SliderGrid_MouseRightButtonDown(sender As Object, e As MouseButtonEventArgs)
            Dim valueEntry = CType(FindName("SliderValueEntry"), TextBox)
            valueEntry.Text = Math.Round(Value, DecimalPlaces).ToString()
            valueEntry.Visibility = Visibility.Visible
            valueTypeInCloseHandler = New MouseButtonEventHandler(AddressOf CloseValueTypeIn)
            [AddHandler](Mouse.MouseDownEvent, valueTypeInCloseHandler, True)
            Mouse.Capture(Me)
        End Sub

        Private Sub CloseValueTypeIn(sender As Object, e As MouseButtonEventArgs)
            CloseValueTypeIn(sender, e, True)
        End Sub

        Private Sub CloseValueTypeIn(sender As Object, e As MouseButtonEventArgs, setVal As Boolean)
            Dim valueEntry = CType(FindName("SliderValueEntry"), TextBox)
            If e IsNot Nothing Then
                If Mouse.DirectlyOver Is valueEntry Then Return
            End If
            Dim tmpVal As Double
            Double.TryParse(valueEntry.Text, tmpVal)
            tmpVal = Math.Max(Math.Min(tmpVal, Maximum), Minimum)
            Value = tmpVal
            valueEntry.Visibility = Visibility.Hidden

            ReleaseMouseCapture()
            [RemoveHandler](Mouse.MouseDownEvent, valueTypeInCloseHandler)
        End Sub

        Private Sub KnobValueEntry_KeyDown(sender As Object, e As KeyEventArgs)
            If e.Key = Key.Enter Then
                CloseValueTypeIn(Me, Nothing)
            ElseIf e.Key = Key.Escape Then
                CloseValueTypeIn(Me, Nothing, False)
            End If
        End Sub

        Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
            Update()
            'TODO: VS Designer still doesn't really like this
            If Not DesignerProperties.GetIsInDesignMode(Me) Then
                If Application.Current?.MainWindow IsNot Nothing Then AddHandler Application.Current.MainWindow.SizeChanged, AddressOf MainWindow_SizeChanged
            End If
        End Sub

        'Update labels if the window changes size
        Private Sub MainWindow_SizeChanged(sender As Object, e As SizeChangedEventArgs)
            DrawValueLabels()
        End Sub

        Private Sub VSlider_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double))
            Update()
        End Sub
    End Class

End Namespace

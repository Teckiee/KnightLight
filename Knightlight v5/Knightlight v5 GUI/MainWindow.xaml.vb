Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Globalization
Imports System.Net
Imports System.Threading
Imports System.Windows.Threading
Imports Haukcode.Osc
Imports Knightlight_v5_GUI.cSettings
Imports Knightlight_v5_Library

Class MainWindow
    Public IamWindow As Integer
    Dim buttonWidth As Double = 100

    Public Sub New()

        'LoadData("Settings.json")
        If vWindow(0) Is Nothing Then
            ' Initialization logic that was previously in MainWindow.New()
            LoadData("Settings.json")

            ' Create the MainWindow instance and assign it to vWindows(0)
            vWindow(0) = Me
            IamWindow = 0
            ApplyWindowSettings(0)

            OSC = New cOSCControls(Settings.ClientPorts)

            DataContext = Settings





            vPresets.Add(New cPresets With {.Name = "Preset 1"}) ' Testdata
            vPresets.Add(New cPresets With {.Name = "Preset 2"}) ' Testdata
            vPresets.Add(New cPresets With {.Name = "Preset 3"}) ' Testdata

            vFixtures.Add(New cFixtures With {.Name = "Fixture 1"}) ' Testdata
            vFixtures.Add(New cFixtures With {.Name = "Fixture 2"}) ' Testdata
            vFixtures.Add(New cFixtures With {.Name = "Fixture 3"}) ' Testdata


            'CreateAndShowWindow(1)
            Dim winI As Integer = 1
            Do Until winI >= Settings.Windows.Count
                CreateAndShowWindow(winI)
                winI += 1
            Loop

        End If


        'AddHandler Me.ContentRendered, AddressOf MainWindow_ContentRendered
        AddHandler Me.LocationChanged, AddressOf MainForm_LocationChanged
        AddHandler Me.SizeChanged, AddressOf MainForm_SizeChanged

        AddHandler OSC.Incoming, AddressOf OSC_IncomingCommand
        OSC.dispatcher(IamWindow) = Dispatcher

        InitializeComponent()


        Dim bindingFixtures As Binding = New Binding()
        bindingFixtures.Source = vFixtures
        icFixtures.SetBinding(ItemsControl.ItemsSourceProperty, bindingFixtures)

        Dim bindingPresets As Binding = New Binding()
        bindingPresets.Source = vPresets
        icPresets.SetBinding(ItemsControl.ItemsSourceProperty, bindingPresets)


        'GenerateFixturesControls()
        'GeneratePresetControls()
        CalculateAndAddPresets()
    End Sub
    Private Sub MainForm_LocationChanged(sender As Object, e As EventArgs)
        SaveData()
    End Sub

    Private Sub MainForm_SizeChanged(sender As Object, e As EventArgs)
        SaveData()
    End Sub
    Private Sub MainWindow_ContentRendered(sender As Object, e As EventArgs)
        ' Your code to run after the window is visible

    End Sub
    Private Sub CreateAndShowWindow(index As Integer)
        'Dim thread As New Thread(Sub()
        vWindow(index) = New MainWindow With {
            .IamWindow = index
        }
        ApplyWindowSettings(index)
        vWindow(index).Show()
        'System.Windows.Threading.Dispatcher.Run()
        'End Sub)
        'Thread.SetApartmentState(ApartmentState.STA)
        'Thread.Start()
    End Sub
    Private Sub CalculateAndAddPresets()
        ' Ensure the GroupBox and ItemsControl have been loaded
        AddHandler icPresets.SizeChanged, AddressOf OnGroupBoxSizeChanged
        AddHandler icFixtures.SizeChanged, AddressOf OnGroupBoxSizeChanged
    End Sub
    Private Sub OnGroupBoxSizeChanged(sender As Object, e As SizeChangedEventArgs)
        ' Remove the handler to avoid multiple calls
        RemoveHandler icPresets.SizeChanged, AddressOf OnGroupBoxSizeChanged

        ' Calculate the number of rows and columns
        Dim groupBoxWidth As Double = icPresets.ActualWidth
        Dim groupBoxHeight As Double = icPresets.ActualHeight
        Dim buttonHeight As Double = buttonWidth / 2
        Dim rows As Integer = Math.Floor(groupBoxHeight / (buttonHeight + 4))
        Dim cols As Integer = 15 ' As defined in the UniformGrid

        ' Calculate the total number of buttons needed
        Dim totalButtons As Integer = rows * cols

        ' Add items to vPresets
        For i As Integer = vPresets.Count + 1 To totalButtons
            vPresets.Add(New cPresets With {.Name = ""})
            vFixtures.Add(New cFixtures With {.Name = ""})
        Next

        AddHandler icPresets.SizeChanged, AddressOf OnGroupBoxSizeChanged
    End Sub
    Public Sub ApplyWindowSettings(i As Integer)
        'If vWindow(i).ActualHeight = 0 Then Exit Sub

        Dim J As Integer = 0
        Do Until J >= vWindow.Count
            If vWindow(i) IsNot Nothing Then
                If vWindow(i).IamWindow = Settings.Windows(J).WindowI Then
                    vWindow(i).Title = "Knightlight v5. Window " & IamWindow
                    vWindow(i).Top = Settings.Windows(J).Top
                    vWindow(i).Left = Settings.Windows(J).Left
                    vWindow(i).Width = Settings.Windows(J).Width
                    vWindow(i).Height = Settings.Windows(J).Height
                    vWindow(i).WindowState = Settings.Windows(J).WindowState
                    Exit Sub
                End If

            Else
                'No more windows
                Exit Sub
            End If
            J += 1
        Loop


    End Sub
    Private Sub cmdOSCTest(sender As Object, e As RoutedEventArgs)
        Dim address As IPAddress = IPAddress.Parse("127.0.0.1")
        Dim port As Integer = Settings.ServerPort

        Dim args As Object() = {"Mars", 1, 2, 3, 4}
        OSC.Transmit(address, port, "handshake", args)

    End Sub

    Private Sub OSC_IncomingCommand(sender As Object, packet As OscPacket)
        Dim message As OscMessage = CType(packet, OscMessage)

        Select Case message.Address
            Case "/handshake"
                Dim args As Object() = {"Mars", 1, 2, 3, 4}
                OSC.Transmit(packet.Origin.Address, Settings.ServerPort, "handshake-ack", args)
            Case Else
                Dispatcher.Invoke(Sub() UpdateTextBox(message))
        End Select


    End Sub
    Private Sub UpdateTextBox(oscMsg As OscMessage)
        txtIncomingtest.Text = oscMsg.ToString
    End Sub


    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Settings.SceneLabelColour = Brushes.Red
        '_foregroundColor = Brushes.Red
    End Sub
    Private Sub btnGridFixtures_SizeChanged(sender As Object, e As SizeChangedEventArgs)
        'GenerateFixturesControls()
        'GeneratePresetControls()
    End Sub

    Private Sub GenerateFixturesControls()
        'If btnGridFixtures.ActualHeight = 0 Then Exit Sub 'still opening

        'btnGridFixtures.RowDefinitions.Clear()
        'btnGridFixtures.ColumnDefinitions.Clear()
        'btnGridFixtures.Children.Clear()


        'Dim buttonHeight As Double = buttonWidth / 2
        'Dim rows As Integer = Math.Floor(grpFixtures.ActualHeight / buttonHeight)
        'Dim cols As Integer = Math.Floor(grpFixtures.ActualWidth / buttonWidth)

        '' Set up the grid with rows and columns
        'For i As Integer = 0 To rows - 1
        '    btnGridFixtures.RowDefinitions.Add(New RowDefinition())
        'Next
        'For j As Integer = 0 To cols - 1
        '    btnGridFixtures.ColumnDefinitions.Add(New ColumnDefinition())
        'Next

        '' Create and add buttons to the grid
        'For i As Integer = 0 To rows - 1
        '    For j As Integer = 0 To cols - 1
        '        Dim btn As New Button()
        '        btn.Content = $"Button {i * cols + j + 1}"
        '        btn.Width = buttonWidth
        '        btn.Height = buttonHeight
        '        btn.Margin = New Thickness(8)

        '        AddHandler btn.Click, AddressOf btnFixtureAll_Click
        '        btn.DataContext = vFixtures

        '        ' Set the button's position in the grid
        '        Grid.SetRow(btn, i)
        '        Grid.SetColumn(btn, j)

        '        ' Add the button to the grid
        '        btnGridFixtures.Children.Add(btn)
        '    Next
        'Next
    End Sub

    Private Sub GeneratePresetControls()
        'If btnGridPresets.ActualHeight = 0 Then Exit Sub 'still opening

        'btnGridPresets.RowDefinitions.Clear()
        'btnGridPresets.ColumnDefinitions.Clear()
        'btnGridPresets.Children.Clear()


        'Dim buttonHeight As Double = buttonWidth / 2
        'Dim rows As Integer = Math.Floor(grpPresets.ActualHeight / buttonHeight)
        'Dim cols As Integer = Math.Floor(grpPresets.ActualWidth / buttonWidth)

        '' Set up the grid with rows and columns
        'For i As Integer = 0 To rows - 1
        '    btnGridPresets.RowDefinitions.Add(New RowDefinition())
        'Next
        'For j As Integer = 0 To cols - 1
        '    btnGridPresets.ColumnDefinitions.Add(New ColumnDefinition())
        'Next

        '' Create and add buttons to the grid
        'For i As Integer = 0 To rows - 1
        '    For j As Integer = 0 To cols - 1
        '        Dim btn As New Button()
        '        btn.Content = $"Button {i * cols + j + 1}"
        '        btn.Width = buttonWidth
        '        btn.Height = buttonHeight
        '        btn.Margin = New Thickness(8)

        '        ' Set the button's position in the grid
        '        Grid.SetRow(btn, i)
        '        Grid.SetColumn(btn, j)

        '        AddHandler btn.Click, AddressOf btnPresetAll_Click
        '        btn.DataContext = vPresets

        '        ' Add the button to the grid
        '        btnGridPresets.Children.Add(btn)
        '    Next
        'Next
    End Sub
    Private Sub ButtonSizeSlider_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double))
        buttonWidth = e.NewValue
        'GenerateFixturesControls()
        'GeneratePresetControls()
    End Sub
    Private Sub btnPresetAll_Click(sender As Object, e As RoutedEventArgs)

    End Sub
    Private Sub btnFixtureAll_Click(sender As Object, e As RoutedEventArgs)
        MsgBox(grpFixtures.ActualWidth & " " & sender.ActualWidth)
    End Sub
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
Public Class DivideByColumnsConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
        Dim originalValue As Double = CDbl(value)
        Dim totalMargin As Double = 15 * 8
        Return (originalValue - totalMargin) / 15
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class
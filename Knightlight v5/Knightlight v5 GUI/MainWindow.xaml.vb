Imports System.ComponentModel
Imports System.Net
Imports System.Threading
Imports System.Windows.Threading
Imports Knightlight_v5_Library
Imports ScottPlot.Colormaps

Class MainWindow
    Private Shared instance As MainWindow


    Public Sub New()
        instance = Me
        OSC = New cOSCControls(Settings.ClientPorts)
        AddHandler OSC.Incoming, AddressOf OSC_IncomingCommand
        LoadData("Settings.json")
        InitializeComponent()
        DataContext = Settings
    End Sub

    Private Sub cmdOSCTest(sender As Object, e As RoutedEventArgs)
        Dim address As IPAddress = IPAddress.Parse("127.0.0.1")
        Dim port As Integer = Settings.ServerPort

        OSC.Transmit(address, port)

    End Sub

    Private Sub OSC_IncomingCommand(sender As Object, command As String)
        Dispatcher.Invoke(Sub() UpdateTextBox(command))
    End Sub
    Private Sub UpdateTextBox(text As String)
        txtIncomingtest.Text = text
    End Sub

    Private Sub cmdGDTFTest(sender As Object, e As RoutedEventArgs)
        Dim gdtf As New cGDTFLibrary
        txtIncomingtest.Text = gdtf.Main()
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Settings.SceneLabelColour = Brushes.Red
        '_foregroundColor = Brushes.Red
    End Sub


End Class

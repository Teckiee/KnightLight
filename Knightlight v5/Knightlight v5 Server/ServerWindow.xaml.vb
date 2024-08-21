Imports System.ComponentModel
Imports Haukcode.Osc
Imports System.Net
Imports Knightlight_v5_Library

Class ServerWindow
    Inherits Window


    Public Sub New()
        InitializeComponent()
        AddHandler Me.Closing, AddressOf ServerWindow_Closing
        OSC = New cOSCControls(Settings.ServerPort)
        AddHandler OSC.Incoming, AddressOf OSC_IncomingCommand
        LoadData("Settings.json")
        DMXdata = New cDMXdata(Settings.UniverseCount)

        If Settings.ArduinoDevices IsNot Nothing Then
            For Each vDevice In Settings.ArduinoDevices
                If vDevice.Job = "ArduinoDMX" Then
                    DMXdata.StartComPort = vDevice.PortName
                End If
            Next
        End If
    End Sub
    Private Sub ServerWindow_Closing(sender As Object, e As CancelEventArgs)
        ' Cancel the close operation
        e.Cancel = True
        ' Hide the window instead
        Me.Hide()
    End Sub

    Private Sub MenuItem_Open_Click(sender As Object, e As RoutedEventArgs)
        Me.Show()
        Me.WindowState = WindowState.Normal
        Me.Activate()
    End Sub

    Private Sub MenuItem_Exit_Click(sender As Object, e As RoutedEventArgs)
        tbi.Visibility = False
        Application.Current.Shutdown()
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        tbi.Visibility = False
        Application.Current.Shutdown()
    End Sub

    Private Sub cmdOSCTest(sender As Object, e As RoutedEventArgs)
        Dim address As IPAddress = IPAddress.Parse("127.0.0.1")
        Dim port As Integer = Settings.ClientPorts

        Using OSCsender As OscSender = New OscSender(address, port)
            OSCsender.Connect()
            OSCsender.Send(New OscMessage("/test", 1, 2, 3, 4))
        End Using
    End Sub

    Private Sub OSC_IncomingCommand(sender As Object, command As String)
        Dispatcher.Invoke(Sub() UpdateTextBox(command))
    End Sub
    Private Sub UpdateTextBox(text As String)
        ' Run on main window thread
        txtIncomingtest.Text = text
    End Sub
End Class

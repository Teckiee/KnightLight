Imports System.ComponentModel
Imports Haukcode.Osc
Imports System.Net
Imports Knightlight_v5_Library
Imports System.Collections.ObjectModel
Imports System.Data.SQLite


Class ServerWindow
    Inherits Window


    Public Sub New()
        InitializeComponent()
        AddHandler Me.Closing, AddressOf ServerWindow_Closing
        LoadData()

        OSC = New cOSCControls(Settings.ServerPort)
        AddHandler OSC.Incoming, AddressOf OSC_IncomingCommand
        OSC.dispatcher(0) = Dispatcher

        DMXdata = New cDMXdata(Settings.UniverseCount)

        If Settings.ArduinoDevices IsNot Nothing Then
            For Each vDevice In Settings.ArduinoDevices
                If vDevice.Job = "ArduinoDMX" Then
                    DMXdata.StartComPort = vDevice.PortName
                End If
            Next
        End If
        OSC.OSCconnections = New ObservableCollection(Of cOSCconnections)
        OSC.OSCconnections.Add(New cOSCconnections With {.IPaddress = "Test1", .Job = "A"})
        OSC.OSCconnections.Add(New cOSCconnections With {.IPaddress = "Test2", .Job = "B"})
        OSC.OSCconnections.Add(New cOSCconnections With {.IPaddress = "Test3", .Job = "C"})

        vDBConnections = New cDBconnections(Settings.LastOpenedShow)

        'DataContext = Bindings
        lstIPaddresses.DataContext = OSC
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

        Dim args As Object() = {"server", 1, 2, 3, 4}
        OSC.Transmit(address, port, "handshake", args)
    End Sub
    Private Sub cmdOSCTest2(sender As Object, e As RoutedEventArgs)
        Dim address As IPAddress = IPAddress.Parse("127.0.0.1")
        Dim port As Integer = Settings.ClientPorts

        Dim args As Object() = {"server", 1, 2, 3, 4}
        OSC.Transmit(address, port, "test", args)
    End Sub

    Private Sub OSC_IncomingCommand(sender As Object, packet As OscPacket)
        Dim message As OscMessage = CType(packet, OscMessage)

        Select Case message.Address
            Case "/handshake"
                Dim args As Object() = {"server", 1, 2, 3, 4}
                OSC.Transmit(packet.Origin.Address, Settings.ServerPort, "handshake-ack", args)
            Case Else
                Dispatcher.Invoke(Sub() UpdateTextBox(message))
        End Select
    End Sub
    Private Sub UpdateTextBox(oscMsg As OscMessage)
        ' Run on main window thread
        txtIncomingtest.Text = oscMsg.ToString
    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        'Dim vDB As New cDBconnections
        'vDB.CreateTestData()
        'vDB.SaveToDisk("database.db")

        Dim dbFilePath As String = System.IO.Path.Combine(knightlightFolderPath, "database.db")
        vDBConnections.MainTest()
        vDBConnections.SaveToDisk(dbFilePath)
    End Sub
End Class

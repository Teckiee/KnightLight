Imports System.IO.Ports
Imports Super_Awesome_Lighting_DMX_board_v4.FormMain
Imports System.Threading


Public Class cMarsConsole
    Private PortName As String
    Private SerialConn As System.IO.Ports.SerialPort
    Public Sub New(ByVal SerialConn1 As System.IO.Ports.SerialPort)
        SerialConn = SerialConn1
        PortName = SerialConn1.PortName
        'MainThread = New System.Threading.Thread(AddressOf AudioLoop)
        'MainThread.IsBackground = True
        'MainThread.Start()
        AddHandler SerialConn.DataReceived, AddressOf SerialPort_DataReceived
        If SerialConn.IsOpen Then
            ' Send a handshake request to the Python application
            SerialConn.WriteLine("HELLO")

        Else

        End If
    End Sub
    Public Property COMPortName() As String

        Get
            Return PortName
        End Get
        Set(ByVal new1 As String)
            PortName = new1
        End Set

    End Property
    Public Property ControlAssignment() As String

        Get
            Return PortName
        End Get
        Set(ByVal new1 As String)
            PortName = new1
        End Set

    End Property
    Private Sub SerialPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) ' Handles SerialPort.DataReceived

        Dim incmsg As IncomingMessages
        incmsg.msg = sender.ReadExisting
        incmsg.portname = sender.portname

        incmsg.msg = incmsg.msg.Trim(vbCrLf)
        Dim inccmd() As String = Split(incmsg.msg, ",")
        UpdateMain(incmsg.msg)
        Select Case inccmd(0)
            Case "UID"

                'UpdateMain(incmsg.msg)
            Case "ONLINE"
                MarsConnected = True
            Case "HELLO"
                MarsConnected = True
                SendOnline()

        End Select

        ' I think I'll need this to get things onto the form thread


    End Sub
    Private Sub UpdateMain(newText As String)
        'Public Shared
        ' Call the UpdateLabel method of the form to update the label text
        frmMain.UpdateFromMars(newText)
    End Sub
    Public Sub SendHello()
        Dim thread As New Thread(
            Sub()
                SerialConn.WriteLine("HELLO,0")
            End Sub
        )
        thread.Start()
    End Sub
    Public Sub SendOnline()
        Dim thread As New Thread(
            Sub()
                SerialConn.WriteLine("ONLINE,0")
            End Sub
        )
        thread.Start()
    End Sub

    Public Sub SendAll()
        Dim thread As New Thread(
            Sub()
                'SerialConn.WriteLine("ALL")
                Dim I As Integer = 0
                Do Until I >= 8 'MusicCues.Length
                    SerialConn.WriteLine("Song," & I & "," & MusicCues(I).SongFileName)
                    I += 1
                Loop
            End Sub
        )
        thread.Start()
    End Sub
    Public Sub Send(ByVal msg As String)
        Dim thread As New Thread(
            Sub()
                SerialConn.WriteLine("HELLO")
            End Sub
        )
        thread.Start()
    End Sub
End Class

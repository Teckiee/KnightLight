Imports Haukcode.Osc
Imports System.Net
Imports System.Threading


Public Class cOSCControls
    Shared receiver As OscReceiver
    Shared thread As Thread
    Public Event Incoming As EventHandler(Of String)

    Public Sub New(ByVal port As Integer) 'ByRef abData() As Byte, ByRef abKey() As Byte, ByVal n As Integer, ByRef abInitV() As Byte)

        receiver = New OscReceiver(port)
        thread = New Thread(New ThreadStart(AddressOf ListenLoop))
        thread.IsBackground = True
        receiver.Connect()
        thread.Start()
    End Sub
    Public Sub AddCommand(command As String)
        ' Raise the event
        RaiseEvent Incoming(Me, command)
    End Sub

    Private Sub ListenLoop()
        Try

            While receiver.State <> OscSocketState.Closed

                If receiver.State = OscSocketState.Connected Then
                    Dim packet As OscPacket = receiver.Receive()
                    AddCommand(packet.ToString())
                    'serverWindow1.Dispatcher.Invoke(Sub() serverWindow1.ProcessQueue())
                End If
            End While

        Catch ex As Exception

            If receiver.State = OscSocketState.Connected Then
                Console.WriteLine("Exception in listen loop")
                Console.WriteLine(ex.Message)
            End If
        End Try
    End Sub
    Public Sub Transmit(ByVal address As IPAddress, ByVal port As Integer)
        Using OSCsender As OscSender = New OscSender(address, port)
            OSCsender.Connect()
            OSCsender.Send(New OscMessage("/test", 1, 2, 3, 4))
        End Using
    End Sub
End Class

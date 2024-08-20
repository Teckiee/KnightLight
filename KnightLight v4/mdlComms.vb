Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports Microsoft.SqlServer

Module mdlComms

    Dim client As TcpClient
    Dim stream As NetworkStream
    Dim server As New TcpListener(IPAddress.Any, 5000)

    Sub StartTCPServer()
        'server = New TcpListener(IPAddress.Any, 5000)


        Dim receiveThread As New Thread(Sub() ReceiveData())
        'Dim sendThread As New Thread(Sub() SendData(stream))

        receiveThread.IsBackground = True
        'sendThread.IsBackground = True

        receiveThread.Start()
        'sendThread.Start()

        'receiveThread.Join()
        'sendThread.Join()


    End Sub
    Sub ReceiveData()
        server.Start()
        Console.WriteLine("Server started...")

        client = server.AcceptTcpClient()
        stream = client.GetStream()

        While True
            Dim buffer(1023) As Byte
            Dim bytesRead As Integer = stream.Read(buffer, 0, buffer.Length)
            If bytesRead = 0 Then Exit While ' Connection closed
            Dim message As String = Encoding.ASCII.GetString(buffer, 0, bytesRead)
            Console.WriteLine("Received: " & message)

            Dim incmsg() As String = Split(message, ",")
            Select Case incmsg(0)
                'Case "ONLINE"
                'Case "HELLO"
                Case "Addr"
                    mPositioning(0).tagAddr = incmsg(1)
                    mPositioning(0).tagX = incmsg(2)
                    mPositioning(0).tagY = incmsg(3)
                    mPositioning(0).tagZ = incmsg(4)


            End Select

        End While
    End Sub

    Sub SendData()

        Dim response As String = Console.ReadLine()
        'If String.IsNullOrEmpty(response) Then Exit While ' End input
        Dim responseBytes() As Byte = Encoding.ASCII.GetBytes(response)
        stream.Write(responseBytes, 0, responseBytes.Length)

    End Sub
    Sub StopTCPServer()
        client.Close()
        Server.Stop()
    End Sub
    Private Sub UpdateMain(newText As String)
        'Public Shared
        ' Call the UpdateLabel method of the form to update the label text
        frmMain.UpdateFromTCPServer(newText)
    End Sub
End Module

Public Class ArduinoDMX
    Dim Channels(4, 512) As Integer
    'Dim SerialConn As New System.IO.Ports.SerialPort
    Dim UID As String
    Dim inc As String
    Dim ArduinoIndexNo As Integer

    Public Property SendData(Universe As Integer, Channel As Integer) As Integer

        Get
            Return Channels(Universe, Channel)
        End Get
        Set(ByVal iSetVal As Integer)
            If Not Channels(Universe, Channel) = iSetVal Then
                Channels(Universe, Channel) = iSetVal

                ' Actually send data to arduino serially 
                If Arduinos(ArduinoIndexNo).Serial IsNot Nothing Then
                    If Arduinos(ArduinoIndexNo).Serial.IsOpen Then

                        ' DMX,1|300|200
                        Arduinos(ArduinoIndexNo).Serial.Write("DMX," & Universe & "|" & Channel & "|" & iSetVal & vbCrLf)
                    End If
                End If



            End If
        End Set

    End Property
    Public WriteOnly Property SetComPort As Integer

        Set(ByVal iSetVal As Integer)
            ArduinoIndexNo = iSetVal
        End Set

    End Property

    'Public Sub SetComPort(PortIndex As Integer)
    'If SerialConn.IsOpen = True Then
    '    SerialConn.Close()
    '    SerialConn = New System.IO.Ports.SerialPort
    'End If
    'SerialConn.BaudRate = 115200
    'SerialConn.PortName = portno
    'SerialConn.DataBits = 8
    'SerialConn.StopBits = IO.Ports.StopBits.One
    'SerialConn.Handshake = IO.Ports.Handshake.None
    'SerialConn.Parity = IO.Ports.Parity.None
    'SerialConn.Open()

    'AddHandler SerialConn.DataReceived, AddressOf SerialPort_DataReceived

    'End Sub

    Private Sub SerialPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) 'Handles SerialConn.DataReceived

        Dim incmsg As String = sender.ReadExisting

        ' Process Messages
        Select Case Mid(incmsg, 1, 3)
            Case "UID"
                Dim a() As String = Split(incmsg, ",")

                If a.Length >= 2 Then ' not 3 = data garbled

                    UID = a(1)

                End If

            Case Else
                inc &= vbCrLf & incmsg

        End Select

    End Sub
    Public ReadOnly Property SerialIncoming() As String

        Get
            Return inc
            inc = ""
        End Get


    End Property

End Class

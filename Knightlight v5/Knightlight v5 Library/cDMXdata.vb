Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports LXProtocols
Imports LXProtocols.Acn.Helpers

Public Class cDMXdata

    Private SentChannelValues(2048) As Integer

    Public socket As Socket
    Public toAddrLocalhost As IPEndPoint
    Public toAddrBroadcast As New List(Of IPEndPoint)

    Private _universe() As DmxUniverse = Nothing
    Private ArduinoDMX As System.IO.Ports.SerialPort

    Public Sub New(ByVal UniverseCount As Integer)

        ReDim _universe(UniverseCount - 1)
        For Iuniverse As Integer = 0 To UniverseCount - 1
            _universe(Iuniverse) = New DmxUniverse(UniverseCount - 1)
        Next




        Dim strHostName As String = System.Net.Dns.GetHostName()


        Dim subnetmask As IPAddress = IPAddress.Parse("255.255.255.0")

        For Each ip In System.Net.Dns.GetHostEntry(strHostName).AddressList
            If ip.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                'IPv4 Adress
                'Label2.Text = ip.ToString()

                For Each adapter As Net.NetworkInformation.NetworkInterface In Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                    For Each unicastIPAddressInformation As Net.NetworkInformation.UnicastIPAddressInformation In adapter.GetIPProperties().UnicastAddresses
                        If unicastIPAddressInformation.Address.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                            If ip.Equals(unicastIPAddressInformation.Address) Then
                                'Subnet Mask
                                subnetmask = unicastIPAddressInformation.IPv4Mask

                                'Dim ipAddress1 As IPAddress = IPAddress.Parse(ip)
                                'Dim subnetMask As IPAddress = IPAddress.Parse(subnetmask1)

                                Dim broadcastAddress As IPAddress = GetBroadcastAddress(ip, subnetmask)

                                socket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
                                'toAddrBroadcast = New IPEndPoint(IPAddress.Parse("192.168.5.201"), 6454)
                                toAddrBroadcast.Add(New IPEndPoint(broadcastAddress, 6454))


                            End If
                        End If
                    Next
                Next
            End If
        Next








        toAddrLocalhost = New IPEndPoint(IPAddress.Parse("127.0.0.1"), 6454)

    End Sub
    Function GetBroadcastAddress(ipAddress As IPAddress, subnetMask As IPAddress) As IPAddress
        Dim ipBytes As Byte() = ipAddress.GetAddressBytes()
        Dim maskBytes As Byte() = subnetMask.GetAddressBytes()

        If ipBytes.Length <> maskBytes.Length Then
            Throw New ArgumentException("IP address and subnet mask lengths do not match.")
        End If

        Dim broadcastBytes(ipBytes.Length - 1) As Byte

        For i As Integer = 0 To ipBytes.Length - 1
            broadcastBytes(i) = CByte(ipBytes(i) Or (Not maskBytes(i)))
        Next

        Return New IPAddress(broadcastBytes)
    End Function
    Public Property Universe(ByVal UniverseId As Integer) As DmxUniverse
        Get
            Return _universe(UniverseId)
        End Get
        Set(ByVal value As DmxUniverse)

            If _universe IsNot value Then

                If _universe IsNot Nothing Then
                    RemoveHandler _universe(UniverseId).DmxDataChanged, AddressOf universe_DmxDataChanged
                End If

                _universe(UniverseId) = value

                If _universe IsNot Nothing Then
                    AddHandler _universe(UniverseId).DmxDataChanged, AddressOf universe_DmxDataChanged
                End If
            End If
        End Set
    End Property

    Private Sub universe_DmxDataChanged(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent DmxDataChanged(Me, EventArgs.Empty)
    End Sub

    Public Event DmxDataChanged As EventHandler

    Public Property DmxData(ByVal UniverseId As Integer) As Byte()
        Get
            Return _universe(UniverseId).DmxData
        End Get
        Set(ByVal value As Byte())
            _universe(UniverseId).SetDmx(value)
        End Set
    End Property

    Public Sub SetLevel(ByVal UniverseId As Integer, ByVal channel As Integer, ByVal value As Byte)
        If _universe(UniverseId).DmxData(channel) <> value Then
            _universe(UniverseId).SetDmx(channel, value)
        End If
    End Sub
    Public WriteOnly Property StartComPort As String

        Set(ByVal NewPortName As String)
            ArduinoDMX = New Ports.SerialPort
            With ArduinoDMX
                .BaudRate = 115200
                .PortName = NewPortName
                .DataBits = 8
                .StopBits = IO.Ports.StopBits.One
                .Handshake = IO.Ports.Handshake.None
                .Parity = IO.Ports.Parity.None
                .ReadTimeout = -1
                .WriteTimeout = -1
                .Open()
            End With

        End Set

    End Property
    Sub SendUSBChannelData(ByVal Channel As Integer, ByVal Value As Integer)

        Dim Univ As Integer = 1
        Dim Dmxno As Integer = 1
        If Channel > 0 And Channel < 512 Then
            Univ = 1
            Dmxno = Channel
        ElseIf Channel >= 512 And Channel < 1024 Then
            Univ = 2
            Dmxno = Channel - 512
        ElseIf Channel >= 1024 And Channel < 1536 Then
            Univ = 3
            Dmxno = Channel - 1024
        ElseIf Channel >= 1536 And Channel < 2048 Then
            Univ = 4
            Dmxno = Channel - 1536
        End If

        If Dmxno < 511 And Univ = 1 Then
            EnttecOpenDMX.OpenDMX.setDmxValue(Dmxno, Value)
        End If
        'ArduDMX.SendData(Univ, Dmxno) = Value

        ' Actually send data to arduino serially 
        If ArduinoDMX IsNot Nothing Then
            If ArduinoDMX.IsOpen Then

                ' DMX,1|300|200
                ArduinoDMX.Write("DMX," & Univ & "|" & Dmxno & "|" & Value & vbCrLf)
            End If
        End If




    End Sub

End Class

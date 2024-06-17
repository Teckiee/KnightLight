Imports System.Net
Imports System.Net.Sockets
Imports System.Reflection.Emit
Imports System.Threading

Public Class cDMXdata
    Private SentChannelValues(2048) As Integer

    Public packet(10) As artnet.ArtnetDmx
    Public socket As Socket
    Public toAddrLocalhost As IPEndPoint
    Public toAddrBroadcast As New List(Of IPEndPoint)

    Structure ValueRegister1
        Dim ChannelValue As Integer
        Dim SceneIndex As Integer

    End Structure
    Public Sub New()
        ' -------------------------------------- ARTNET STUFF
        Dim Iuniverse As Integer = 0
        Do Until Iuniverse >= packet.Length
            packet(Iuniverse) = New artnet.ArtnetDmx(Iuniverse)
            Iuniverse += 1
        Loop


        Dim strHostName As String = System.Net.Dns.GetHostName()
        'Dim strIPAddress As String = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
        'Dim strIPAddress As String = System.Net.Dns.GetHostByName(strHostName).AddressList.ToString()


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
        TransmitArtnet()
    End Sub

    Sub SetChannelData(ByVal Channel As Integer, ByVal Value As Integer)

        If Testmode = True Then Exit Sub

        'Dim Univ As Integer = (Channel - 1) \ 512
        'Dim Dmxno As Integer = (Channel - 1) Mod 512 + 1

        'Dim Univ As Integer = (Channel - 1) \ 512 + 1
        'Dim Dmxno As Integer = (Channel - 1) Mod 512 + 1

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
        ArduDMX.SendData(Univ, Dmxno) = Value
        'sACNController.SendData(Univ, Dmxno) = Value
        If Not Dmxno = 0 Then
            packet(Univ).setChannel(Dmxno - 1, Value)
        End If



    End Sub
    Sub TransmitArtnet()

        'If formopened = True Then
        Dim thread1 As New Thread(
            Sub()

                Do While closethreads = False
                    Dim Iuniverse As Integer = 0
                    Do Until Iuniverse >= packet.Length
                        For Each ip As IPEndPoint In toAddrBroadcast
                            socket.SendTo(packet(Iuniverse).toBytes(), ip)
                        Next

                        socket.SendTo(packet(Iuniverse).toBytes(), toAddrLocalhost)
                        Iuniverse += 1
                    Loop
                    Thread.Sleep(100)
                Loop
            End Sub
            )
            thread1.IsBackground = True
            thread1.Start()

        'End If
    End Sub
    Public Property SendChannelData(ByVal Channel As Integer) As Integer

        Get
            Return SentChannelValues(Channel)
        End Get
        Set(ByVal newValue As Integer)
            If Not SentChannelValues(Channel) = newValue Then
                SentChannelValues(Channel) = newValue
                SetChannelData(Channel, newValue)
            End If
        End Set

    End Property
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
End Class

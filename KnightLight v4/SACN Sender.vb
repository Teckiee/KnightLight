Imports Haukcode.sACN
Imports System.Threading

Class SACN_Sender

    'Dim UniverseDiscoverThread As Thread
    'Dim SendDataThread(3) As Thread
    Dim HasLoaded As Boolean = False

    'Dim DMXvalues As Byte(,) = New Byte(4, 511) {}

    'Dim cid As Byte() = New Byte() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}

    'Dim sourceName As String = "Knightlightv4-main"
    'Dim sacnSender = New SacnSender()
    'Dim factory As SacnPacketFactory = New SacnPacketFactory(cid, sourceName)

    Public Sub New()

        'UniverseDiscoverThread = New Thread(AddressOf UniverseDiscoveryLoop)
        'UniverseDiscoverThread.IsBackground = True
        'UniverseDiscoverThread.Start()

        'Dim I As Integer = 0
        'Do Until I >= 4
        '    SendDataThread(I) = New Thread(Sub() Me.SendDataLoop(I))
        '    SendDataThread(I).IsBackground = True
        '    SendDataThread(I).Start()
        '    I += 1
        'Loop

    End Sub
    Private Sub UniverseDiscoveryLoop()
        Do
            If HasLoaded = False Then
                ' do first time only
                HasLoaded = True
            End If


            'Dim universe As Int16 = 1
            'Dim packets = factory.CreateUniverseDiscoveryPackets(New UInt16() {universe})
            'For Each packet In packets
            '    sacnSender.SendMulticast(packet)
            'Next


            'universe = 2
            'packets = factory.CreateUniverseDiscoveryPackets(New UInt16() {universe})
            'For Each packet In packets
            '    sacnSender.SendMulticast(packet)
            'Next


            'universe = 3
            'packets = factory.CreateUniverseDiscoveryPackets(New UInt16() {universe})
            'For Each packet In packets
            '    sacnSender.SendMulticast(packet)
            'Next


            'universe = 4
            'packets = factory.CreateUniverseDiscoveryPackets(New UInt16() {universe})
            'For Each packet In packets
            '    sacnSender.SendMulticast(packet)
            'Next


            Thread.Sleep(10000)
        Loop
    End Sub
    Public Property SendData(Universe As Integer, Channel As Integer) As Integer

        Get
            'Return DMXvalues(Universe, Channel)
        End Get
        Set(ByVal iSetVal As Integer)

            'If Not DMXvalues(Universe, Channel) = iSetVal Then
            '    DMXvalues(Universe, Channel) = iSetVal

            'End If
        End Set

    End Property
    Private Sub SendDataLoop(ByVal Universe As UInt16)
        'Universe = Universe + 1
        Do While closethreads = False
            'If HasLoaded = False Then
            '    ' do first time only

            '    HasLoaded = True
            'End If

            ''Dim DMXvalues As Byte(,) = New Byte(4, 511) {}

            'Dim UniverseValues As Byte() = New Byte(511) {}

            'For i As Integer = 0 To 511
            '    UniverseValues(i) = DMXvalues(Universe, i)
            'Next i

            'Dim packet = factory.CreateDataPacket(Universe, UniverseValues)
            'sacnSender.SendMulticast(packet)


            Thread.Sleep(25)
        Loop
    End Sub

End Class
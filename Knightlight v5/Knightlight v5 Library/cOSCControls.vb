Imports Haukcode
Imports Haukcode.Osc
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Net
Imports System.Net.Mime.MediaTypeNames
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Threading



Public Class cOSCControls
    Implements INotifyPropertyChanged

    Shared receiver As OscReceiver
    Shared thread As Thread
    Public Event Incoming As EventHandler(Of OscPacket)
    'Private _ipRegistry As HashSet(Of String)
    Private Property _OSCconnections As ObservableCollection(Of cOSCconnections)
    Public dispatcher(10) As Object

    Public Sub New(ByVal port As Integer) 'ByRef abData() As Byte, ByRef abKey() As Byte, ByVal n As Integer, ByRef abInitV() As Byte)

        receiver = New OscReceiver(port)
        thread = New Thread(New ThreadStart(AddressOf ListenLoop))
        thread.IsBackground = True



        _OSCconnections = New ObservableCollection(Of cOSCconnections)

        receiver.Connect()
        thread.Start()
    End Sub
    Public Sub IncomingCommand(ByVal command As OscPacket)
        ' Raise the event
        RaiseEvent Incoming(Me, command)
    End Sub

    Private Sub ListenLoop()

        Do 'receiver.State <> OscSocketState.Closed

            If receiver.State = OscSocketState.Connected Then
                Try
                    Dim packet As OscPacket = receiver.Receive()

                    Dim message As OscMessage = CType(packet, OscMessage)


                    'Dim delimiters() As Char = {"/"c, ","c}
                    'Dim a() As String = packet.ToString().Split(delimiters, StringSplitOptions.RemoveEmptyEntries)

                    Dim job As String = ""
                    Select Case message.Address
                        Case "/handshake", "/handshake-ack"
                            job = message(0)

                            ' Check if the IP address already exists in the _OSCconnections collection
                            Dim exists As Boolean = _OSCconnections.Any(Function(conn) conn.IPaddress = packet.Origin.Address.ToString())
                            If Not exists Then
                                For i As Integer = 0 To dispatcher.Length - 1
                                    ' Perform your logic here
                                    ' For example, you can check if the dispatcher is not Nothing
                                    If dispatcher(i) IsNot Nothing Then
                                        dispatcher(i).Invoke(Sub()
                                                                 _OSCconnections.Add(New cOSCconnections With {.IPaddress = packet.Origin.Address.ToString(), .Job = job})
                                                             End Sub)
                                    End If
                                Next

                            End If

                            IncomingCommand(packet)
                        Case Else
                            ' Trigger update Event
                            IncomingCommand(packet)
                    End Select


                    '_OSCconnections.Add(New cOSCconnections With {.IPaddress = packet.Origin.Address.ToString()})


                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try


                'serverWindow1.Dispatcher.Invoke(Sub() serverWindow1.ProcessQueue())
            End If
        Loop

        'Catch ex As Exception

        '    If receiver.State = OscSocketState.Connected Then
        '        'Console.WriteLine("Exception in listen loop")
        '        'Console.WriteLine(ex.Message)
        '    End If
        'End Try
    End Sub
    Public Sub Transmit(ByVal address As IPAddress, ByVal port As Integer, ByVal message As String, ByVal args As Object())
        Using OSCsender As OscSender = New OscSender(address, port)
            OSCsender.Connect()
            OSCsender.Send(New OscMessage("/" & message, args))
        End Using
    End Sub
    Public Property OSCconnections As ObservableCollection(Of cOSCconnections)
        Get
            Return _OSCconnections
        End Get
        Set(value As ObservableCollection(Of cOSCconnections))
            If _OSCconnections IsNot value Then
                _OSCconnections = value
                OnPropertyChanged()
            End If
        End Set
    End Property



    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Protected Sub OnPropertyChanged(<CallerMemberName> Optional propertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
Public Class cOSCconnections
    Public Property IPaddress As String
    Public Property Job As String
End Class
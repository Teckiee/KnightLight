Imports System.Reflection

Public Class cOSC
    Public Sub SendPlay(ByVal SCSindex As Integer)
        Try
            'Dim OSCmessage = New SharpOSC.OscMessage("/cue/go ,s Q" & SCSindex)
            'Dim sendOSC = New SharpOSC.UDPSender(SCSIPaddress, SCSPort)
            'sendOSC.Send(OSCmessage)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub SendStop(ByVal SCSindex As Integer)
        Try
            'Dim OSCmessage = New SharpOSC.OscMessage("/cue/stop ,s Q" & SCSindex)
            'Dim sendOSC = New SharpOSC.UDPSender(SCSIPaddress, SCSPort)
            'sendOSC.Send(OSCmessage)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub SendPause(ByVal SCSindex As Integer)
        Try
            'Dim OSCmessage = New SharpOSC.OscMessage("/cue/pauseresume ,s Q" & SCSindex)
            'Dim sendOSC = New SharpOSC.UDPSender(SCSIPaddress, SCSPort)
            'sendOSC.Send(OSCmessage)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub SendResume(ByVal SCSindex As Integer)
        Try
            'Dim OSCmessage = New SharpOSC.OscMessage("/cue/pauseresume ,s Q" & SCSindex)
            'Dim sendOSC = New SharpOSC.UDPSender(SCSIPaddress, SCSPort)
            'sendOSC.Send(OSCmessage)
        Catch ex As Exception

        End Try
    End Sub
End Class

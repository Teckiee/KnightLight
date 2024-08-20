Imports NAudio.Midi
Public Class cMidiController
    Private midiIn As MidiIn

    Public Sub New()
        ' Initialize MIDI input device.
        ' The argument (0 in this case) is the device number. 
        ' You might need to adjust this depending on how many MIDI devices you have connected.

        midiIn = New MidiIn(0)

        ' Add an event handler to process incoming MIDI messages.
        AddHandler midiIn.MessageReceived, AddressOf MidiIn_MessageReceived
        AddHandler midiIn.ErrorReceived, AddressOf MidiIn_ErrorReceived

        ' Start receiving MIDI messages.
        midiIn.Start()
    End Sub
    Private Sub MidiIn_MessageReceived(sender As Object, e As MidiInMessageEventArgs)
        ' This method is called whenever a MIDI message is received.
        ' You can process the MIDI message here.
        Console.WriteLine($"Timestamp: {e.Timestamp}, Message: {e.MidiEvent}")
    End Sub

    Private Sub MidiIn_ErrorReceived(sender As Object, e As MidiInMessageEventArgs)
        ' This method is called whenever there is an error with the MIDI input.
        Console.WriteLine($"Error: {e.MidiEvent}")
    End Sub

    Protected Overrides Sub Finalize()
        ' Stop receiving MIDI messages and clean up resources.
        If MidiEnabled = True Then
            midiIn.Stop()
            RemoveHandler midiIn.MessageReceived, AddressOf MidiIn_MessageReceived
            RemoveHandler midiIn.ErrorReceived, AddressOf MidiIn_ErrorReceived
            midiIn.Dispose()
        End If

    End Sub
End Class

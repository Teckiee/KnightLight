Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.Compatibility
Friend Class MP3Class
	'
	Private Declare Function mciSendString Lib "winmm.dll"  Alias "mciSendStringA"(ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer
	'Used to store the mp3 filename
	Public MP3File As String
	Dim TheFile As String
	'Used to find the last backslash of the file
	Public Function GetLastBackSlash(ByRef text As String) As String
		On Error GoTo TheError
		Dim i As Object
		Dim pos As Short
		Dim lastslash As Short
		
		
		For i = 1 To Len(text)
            pos = InStr(i, text, "\", CompareMethod.Text)
			If pos <> 0 Then lastslash = pos
		Next i
		GetLastBackSlash = Right(text, Len(text) - lastslash)
		Exit Function
TheError:  'MsgBox(Err.Description,  , " Error")
	End Function
	'Take the path and .mp3 off the file
    Public Sub ListNoChar(ByRef List1 As System.Windows.Forms.ListBox, ByRef List2 As System.Windows.Forms.ListBox)
        On Error GoTo TheError
        Dim X As Object
        Dim NoChar As String
        Dim NoEnd As String
        For X = 0 To List2.Items.Count - 1
            NoChar = GetLastBackSlash(List2.Items(X))
            NoEnd = RightLeft(NoChar, ".")
            'NoEnd = Mid(NoChar, 1, 1)
            List1.Items.Add(NoEnd)
        Next X
        Exit Sub
TheError:  'MsgBox(Err.Description, , " Error")
    End Sub
    Private Function RightLeft(ByRef source As String, ByRef token As String) As String
        On Error GoTo TheError
        Dim i As Short
        RightLeft = ""
        '
        For i = Len(source) To 1 Step -1
            '
            If Mid(source, i, 1) = token Then
                RightLeft = Left(source, i - 1)
                Exit Function
            End If
        Next i
        Exit Function
TheError:  'MsgBox(Err.Description, , " Error")

    End Function
    'Take the .mp3 off the end of file
    Private Function NoEndChar(ByRef List1 As System.Windows.Forms.ListBox, ByRef List2 As System.Windows.Forms.ListBox) As String
        On Error GoTo TheError
        Dim N As Object
        For N = 0 To List2.Items.Count - 1
            NoEndChar = Left(VB6.GetItemString(List2, N), 1)
        Next N
        Exit Function
TheError:  'MsgBox(Err.Description, , " Error")
    End Function
    'Convert seconds to minutes
    Private Function SecondsToMinutes(ByRef Secs As Integer) As String
        On Error GoTo TheError
        Dim mins As Short
        mins = Int(Secs / 60)
        Secs = Secs Mod 60
        SecondsToMinutes = mins & ":" & VB6.Format(Secs, "0#")

        Exit Function
TheError:  'MsgBox(Err.Description, , " Error")

    End Function
    'Check to see if the mp3 is playing or not
    Public Function MP3Playing() As Boolean
        On Error GoTo TheError
        Static s As New VB6.FixedLengthString(30)
        mciSendString("status " & TheFile & " mode", s.Value, Len(s.Value), 0)
        MP3Playing = (Mid(s.Value, 1, 7) = "playing")
        Exit Function
TheError:  'MsgBox(Err.Description, , " Error")
    End Function
    'Change the mp3 pistion to a certain position
    'UPGRADE_NOTE: Second was upgraded to Second_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
    Public Function MP3ChangePositionTo(ByRef Second_Renamed As Object) As Object
        On Error GoTo TheError
        TheFile = Chr(34) & Trim(MP3File) & Chr(34)
        'UPGRADE_WARNING: Couldn't resolve default property of object Second_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        Second_Renamed = Second_Renamed * 1000
        mciSendString("set MP3Play time format milliseconds", CStr(0), 0, 0)
        'UPGRADE_WARNING: Couldn't resolve default property of object Second_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        If MP3Playing() = True Then mciSendString("play " & TheFile & " from " & Second_Renamed, CStr(0), 0, 0)
        'UPGRADE_WARNING: Couldn't resolve default property of object Second_Renamed. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        If MP3Playing() = False Then mciSendString("seek " & TheFile & " to " & Second_Renamed, CStr(0), 0, 0)
        Exit Function
TheError:  'MsgBox(Err.Description, , " Error")
    End Function
    'Get the current mp3 position in seconds
    Public Function MP3PositionInSec() As Object
        On Error GoTo TheError
        TheFile = Chr(34) & Trim(MP3File) & Chr(34)
        Static s As New VB6.FixedLengthString(30)
        mciSendString("set " & TheFile & " time format milliseconds", CStr(0), 0, 0)
        mciSendString("status " & TheFile & " position", s.Value, Len(s.Value), 0)
        MP3PositionInSec = System.Math.Round(CDbl(Mid(s.Value, 1, Len(s.Value))) / 1000)
        'UPGRADE_WARNING: Couldn't resolve default property of object MP3PositionInSec. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        If MP3PositionInSec <= 9 Then
            'UPGRADE_WARNING: Couldn't resolve default property of object MP3PositionInSec. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            MP3PositionInSec = "0" & MP3PositionInSec
        End If
        Exit Function
TheError:  'MsgBox(Err.Description, , " Error")

    End Function
    'Get the current mp3 position in Milli-sec.
    Public Function MP3PositionInMS() As Object
        On Error GoTo TheError
        Static s As New VB6.FixedLengthString(30)
        TheFile = Chr(34) & Trim(MP3File) & Chr(34)
        mciSendString("set " & TheFile & " time format milliseconds", CStr(0), 0, 0)
        mciSendString("status " & TheFile & " position", s.Value, Len(s.Value), 0)
        MP3PositionInMS = Val(s.Value)
        Exit Function
TheError:  'MsgBox(Err.Description, , " Error")

    End Function
    'Get the formatted duration of the mp3
    Public Function MP3Duration() As Object
        On Error GoTo TheError
        Dim TotalTime As New VB6.FixedLengthString(128)
        Dim T As String
        Dim lTotalTime As Integer
        TheFile = Chr(34) & Trim(MP3File) & Chr(34)
        mciSendString("set " & TheFile & " time format ms", TotalTime.Value, 128, 0)
        mciSendString("status " & TheFile & " length", TotalTime.Value, 128, 0)

        mciSendString("set " & TheFile & " time format frames", CStr(0), 0, 0)

        lTotalTime = Val(TotalTime.Value)
        T = GetThisTime(lTotalTime)
        'UPGRADE_WARNING: Couldn't resolve default property of object MP3Duration. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        MP3Duration = T
        Exit Function
TheError:  'MsgBox(Err.Description, , " Error")

    End Function
    'Get the duration of the mp3 in seconds
    Public Function MP3DurationInSec() As Object
        On Error GoTo TheError
        Dim TotalTime As New VB6.FixedLengthString(128)
        Dim T As String
        TheFile = Chr(34) & Trim(MP3File) & Chr(34)
        mciSendString("set " & TheFile & " time format ms", TotalTime.Value, 128, 0)
        mciSendString("status " & TheFile & " length", TotalTime.Value, 128, 0)
        mciSendString("set " & TheFile & " time format frames", CStr(0), 0, 0)
        MP3DurationInSec = System.Math.Round(CDbl(Mid(TotalTime.Value, 1, Len(TotalTime.Value))) / 1000)
        Exit Function
TheError:  'MsgBox(Err.Description, , " Error")
    End Function
    'Get the mp3 duration in Milli-sec.
    Public Function MP3DurationInMs() As Object
        Dim DurationInMs As Object
        On Error GoTo TheError
        Dim TotalTime As New VB6.FixedLengthString(128)
        Dim T As String
        TheFile = Chr(34) & Trim(MP3File) & Chr(34)
        mciSendString("set " & TheFile & " time format ms", TotalTime.Value, 128, 0)
        mciSendString("status " & TheFile & " length", TotalTime.Value, 128, 0)
        mciSendString("set " & TheFile & " time format frames", CStr(0), 0, 0)
        'UPGRADE_WARNING: Couldn't resolve default property of object DurationInMs. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        DurationInMs = Val(TotalTime.Value)
        Exit Function
TheError:  'MsgBox(Err.Description, , " Error")

    End Function
    Private Function GetThisTime(ByVal timein As Integer) As String
        On Error GoTo TheError
        Dim conH As Short
        Dim conM As Short
        Dim conS As Short
        Dim remTime As Integer
        Dim strRetTime As String
        TheFile = Chr(34) & Trim(MP3File) & Chr(34)
        remTime = timein / 1000
        conH = Int(remTime / 3600)
        remTime = remTime Mod 3600
        conM = Int(remTime / 60)
        remTime = remTime Mod 60
        conS = remTime

        If conH > 0 Then
            strRetTime = Trim(Str(conH)) & ":"
        Else
            strRetTime = ""
        End If

        If conM >= 10 Then
            strRetTime = strRetTime & Trim(Str(conM))
        ElseIf conM > 0 Then
            strRetTime = strRetTime & "0" & Trim(Str(conM))
        Else
            strRetTime = strRetTime & "00"
        End If

        strRetTime = strRetTime & ":"

        If conS >= 10 Then
            strRetTime = strRetTime & Trim(Str(conS))
        ElseIf conS > 0 Then
            strRetTime = strRetTime & "0" & Trim(Str(conS))
        Else
            strRetTime = strRetTime & "00"
        End If

        GetThisTime = strRetTime
        Exit Function
TheError:  'MsgBox(Err.Description, , " Error")

    End Function
    'Get the formatted mp3 position
    Public Function MP3Position() As Object
        On Error GoTo TheError
        Dim Sec As Integer
        Dim mins As Integer
        Static s As New VB6.FixedLengthString(30)
        TheFile = Chr(34) & Trim(MP3File) & Chr(34)
        mciSendString("set " & TheFile & " time format milliseconds", CStr(0), 0, 0)
        mciSendString("status " & TheFile & " position", s.Value, Len(s.Value), 0)
        Sec = System.Math.Round(CDbl(Mid(s.Value, 1, Len(s.Value))) / 1000)
        'UPGRADE_WARNING: Couldn't resolve default property of object MP3Position. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        If Sec < 60 Then MP3Position = "0:" & VB6.Format(Sec, "00")
        If Sec > 59 Then
            mins = Int(Sec / 60)
            Sec = Sec - (mins * 60)
            'UPGRADE_WARNING: Couldn't resolve default property of object MP3Position. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            MP3Position = VB6.Format(mins, "00") & ":" & VB6.Format(Sec, "00")
        End If
        Exit Function
TheError:  'MsgBox(Err.Description, , " Error")
    End Function
    'Open and load a .m3u playlist
    Public Function MP3OpenPlayList(ByRef TheFile As String, ByRef TheListBox As Object) As Object
        On Error GoTo TheError
        Dim test As String
        If TheFile = "" Then Exit Function
        FileOpen(1, TheFile, OpenMode.Input)
        While Not EOF(1)
            test = LineInput(1)
            'UPGRADE_WARNING: Couldn't resolve default property of object TheListBox.AddItem. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            TheListBox.AddItem(RTrim(test))
        End While
        FileClose(1)
        Exit Function
TheError:  'MsgBox(Err.Description, , " Error")
    End Function
    'Save a playlist in .m3u format
    Public Function MP3SavePlayList(ByRef TheFile As String, ByRef TheListBox As Object) As Object
        On Error GoTo TheError
        Dim i As Short
        Dim a As String
        FileOpen(1, TheFile, OpenMode.Output)
        'UPGRADE_WARNING: Couldn't resolve default property of object TheListBox.ListCount. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        For i = 0 To TheListBox.ListCount - 1
            'UPGRADE_WARNING: Couldn't resolve default property of object TheListBox.List. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
            a = TheListBox.List(i)
            PrintLine(1, a)
        Next
        FileClose(1)
        Exit Function
TheError:  'MsgBox(Err.Description, , " Error")

    End Function
    'Start playing the mp3
    Sub MP3Play()
        On Error GoTo TheError
        mciSendString("close " & TheFile, CStr(0), 0, 0)
        TheFile = Chr(34) & Trim(MP3File) & Chr(34)
        mciSendString("open " & TheFile, CStr(0), 0, 0)
        mciSendString("play " & TheFile, "", 0, 0)
        Exit Sub
TheError:  'MsgBox(Err.Description, , " Error")

    End Sub
    'Stop the mp3 from playing
    Sub MP3Stop()
        On Error GoTo TheError
        TheFile = Chr(34) & Trim(MP3File) & Chr(34)
        mciSendString("close " & TheFile, CStr(0), 0, 0)
        Exit Sub
TheError:  'MsgBox(Err.Description, , " Error")

    End Sub
    'Resume the mp3 if paused
    Sub MP3Resume()
        On Error GoTo TheError
        TheFile = Chr(34) & Trim(MP3File) & Chr(34)
        mciSendString("play " & TheFile, "", 0, 0)
        Exit Sub
TheError:  'MsgBox(Err.Description, , " Error")
    End Sub
    'Pause the mp3 if playing
    Sub MP3Pause()
        On Error GoTo TheError
        TheFile = Chr(34) & Trim(MP3File) & Chr(34)
        Call mciSendString("Stop " & TheFile, CStr(0), 0, 0)
        Exit Sub
TheError:  'MsgBox(Err.Description, , " Error")
    End Sub
End Class
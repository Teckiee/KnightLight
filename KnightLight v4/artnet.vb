Imports System.Runtime.InteropServices
Imports System.Diagnostics ' for Debug.Assert

Namespace artnet
    <StructLayout(LayoutKind.Sequential, Pack:=1)>
    Public Structure ArtnetDmx
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)>
        Private ID As Byte() ' "Art-Net"
        Private OpCode As UShort ' See Doc. Table 1 - OpCodes eg. 0x5000 OpOutput / OpDmx
        Private version As UShort ' 0x0e00 (aka 14)
        Private seq As Byte ' monotonic counter
        Private physical As Byte ' 0x00
        Private subUni As Byte ' low universe (0-255)
        Private net As Byte ' high universe (not used)
        Private length As UShort ' data length (2 - 512)
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=512)>
        Private data As Byte() ' universe data

        Public Sub New(uni As Byte)
            ID = New Byte(7) {}
            ID(0) = CByte(Asc("A"))
            ID(1) = CByte(Asc("r"))
            ID(2) = CByte(Asc("t"))
            ID(3) = CByte(Asc("-"))
            ID(4) = CByte(Asc("N"))
            ID(5) = CByte(Asc("e"))
            ID(6) = CByte(Asc("t"))
            ID(7) = 0

            OpCode = &H5000
            version = CUShort(_bswap(14))
            seq = 0
            physical = 0
            subUni = uni
            net = 0
            length = CUShort(512)

            ReDim data(512)

        End Sub

        Private Shared Function _bswap(val As UInteger) As UInteger
            Return (val << 8) Or (val >> 8)
        End Function

        Public Sub setChannel(channel As UShort, val As Integer)

            Debug.Assert(channel < 512)
            data(channel) = CByte(val)
        End Sub

        Public Function getChannel(channel As UShort) As Byte
            Debug.Assert(channel < 512)
            Return data(channel)
        End Function

        Public Sub incrChannel(channel As UShort)
            Debug.Assert(channel < 512)
            If data(channel) < 255 Then
                data(channel) += 1
            End If
        End Sub

        Public Sub decrChannel(channel As UShort)
            Debug.Assert(channel < 512)
            If data(channel) > 0 Then
                data(channel) -= 1
            End If
        End Sub

        Public Sub setSequence(s As Byte)
            seq = s
        End Sub

        Public Function getSequence() As Byte
            Return seq
        End Function

        Public Function toBytes() As Byte()
            Dim instance As New ArtnetDmx(0) ' Create a new instance
            instance = Me ' Copy data to the new instance

            Dim bytes(Marshal.SizeOf(GetType(ArtnetDmx)) - 1) As Byte
            Dim ptr As IntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(instance))

            Try
                Marshal.StructureToPtr(instance, ptr, False)
                Marshal.Copy(ptr, bytes, 0, bytes.Length)
                Return bytes
            Finally
                Marshal.FreeHGlobal(ptr)
            End Try
        End Function


    End Structure
End Namespace

Imports System.Data.SQLite
Imports System.IO
Imports System.IO.Compression
Imports System.Xml.Serialization
Public Class cDBconnections

    Dim inMemoryConnectionString As String = "Data Source=:memory:;Version=3;New=True;"
    Dim inMemoryConnection As SQLiteConnection
    Dim result As GDTF
    Dim CurrentOpenedFilePath As String
    Public Sub New(ByVal filePath As String) 'ByRef abData() As Byte, ByRef abKey() As Byte, ByVal n As Integer, ByRef abInitV() As Byte)
        CurrentOpenedFilePath = filePath
        inMemoryConnection = New SQLiteConnection(inMemoryConnectionString)
        If File.Exists(filePath) Then
            LoadFromDisk(filePath)
        End If
    End Sub

    'Public Sub CreateTestData()

    '    ' Create an in-memory database and save it to disk

    '    Try
    '        inMemoryConnection.Open()

    '        ' Create a table and insert some data
    '        Dim command As New SQLiteCommand(inMemoryConnection)
    '        Try
    '            command.CommandText = "CREATE TABLE users (ID INTEGER PRIMARY KEY, Name TEXT, Age INTEGER)"
    '            command.ExecuteNonQuery()

    '            command.CommandText = "INSERT INTO users (Name, Age) VALUES ('Alice', 30)"
    '            command.ExecuteNonQuery()

    '            command.CommandText = "INSERT INTO users (Name, Age) VALUES ('Bob', 25)"
    '            command.ExecuteNonQuery()
    '        Finally
    '            command.Dispose()
    '        End Try

    '        SaveToDisk(filePath)
    '    Finally
    '        inMemoryConnection.Close()
    '        'inMemoryConnection.Dispose()
    '    End Try

    '    LoadFromDisk(filePath)
    'End Sub
    Private Sub CreateNewDB(ByVal filePath As String)

    End Sub

    Public Sub SaveToDisk(ByVal filePath As String)
        ' Save the in-memory database to disk
        Dim fileConnection As New SQLiteConnection($"Data Source={filePath};Version=3;")
        Try
            fileConnection.Open()
            If inMemoryConnection.State = System.Data.ConnectionState.Closed Then inMemoryConnection.Open()
            inMemoryConnection.BackupDatabase(fileConnection, "main", "main", -1, Nothing, 0)
        Finally
            fileConnection.Close()
            'fileConnection.Dispose()
        End Try
    End Sub
    Public Sub LoadFromDisk(ByVal filePath As String)
        ' Load the database from disk into memory
        Dim fileConnection2 As New SQLiteConnection($"Data Source={filePath};Version=3;")
        Try
            fileConnection2.Open()

            Dim inMemoryConnection2 As New SQLiteConnection(inMemoryConnectionString)
            Try
                inMemoryConnection2.Open()

                ' Load the database from disk into the in-memory database
                fileConnection2.BackupDatabase(inMemoryConnection2, "main", "main", -1, Nothing, 0)

                ' Query the in-memory database
                'Dim command2 As New SQLiteCommand("SELECT * FROM FixtureType", inMemoryConnection2)
                'Try
                '    Dim reader As SQLiteDataReader = command2.ExecuteReader()
                '    Try
                '        While reader.Read()
                '            Console.WriteLine($"ID: {reader("ID")}, Name: {reader("Name")}, Age: {reader("Age")}")
                '        End While
                '    Finally
                '        reader.Close()
                '        reader.Dispose()
                '    End Try
                'Finally
                '    command2.Dispose()
                'End Try
            Finally
                inMemoryConnection2.Close()
                'inMemoryConnection2.Dispose()
            End Try
        Finally
            fileConnection2.Close()
            fileConnection2.Dispose()
        End Try
    End Sub
    Public Function MainTest()
        Dim zipFilePath As String = "C:\Users\Markus\Documents\Knightlight\GDTF Library\Generic@Basic_LED_PAR@KAYA.gdtf"
        Dim fileNameInsideZip As String = "description.xml"

        Try
            Using zipToOpen As FileStream = New FileStream(zipFilePath, FileMode.Open)
                Using archive As ZipArchive = New ZipArchive(zipToOpen, ZipArchiveMode.Read)
                    Dim entry As ZipArchiveEntry = archive.GetEntry(fileNameInsideZip)
                    If entry IsNot Nothing Then
                        Using reader As StreamReader = New StreamReader(entry.Open())
                            Dim xmlContent As String = reader.ReadToEnd()
                            Dim serializer As New XmlSerializer(GetType(GDTF))
                            Using reader1 As New StringReader(xmlContent)
                                result = CType(serializer.Deserialize(reader1), GDTF)
                                ' Use the deserialized object
                                StoreToDB(result)
                            End Using



                        End Using
                        Return "done"
                    Else
                        Return ($"File '{fileNameInsideZip}' not found in the ZIP archive.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Return ($"An error occurred: {ex.Message}")
        End Try
    End Function
    Private Sub StoreToDB(gdtf As GDTF)


        If inMemoryConnection.State = System.Data.ConnectionState.Closed Then inMemoryConnection.Open()

        ' Create tables
        Dim createGDTFTable As String = "CREATE TABLE GDTF (DataVersion TEXT);"
            Dim createFixtureTypeTable As String = "CREATE TABLE FixtureType (CanHaveChildren TEXT, Description TEXT, FixtureTypeID TEXT, LongName TEXT, Manufacturer TEXT, Name TEXT, RefFT TEXT, ShortName TEXT, Thumbnail TEXT, ThumbnailOffsetX TEXT, ThumbnailOffsetY TEXT);"

        Using command As New SQLiteCommand(createGDTFTable, inMemoryConnection)
            command.ExecuteNonQuery()
        End Using

        Using command As New SQLiteCommand(createFixtureTypeTable, inMemoryConnection)
            command.ExecuteNonQuery()
        End Using

        ' Insert data into GDTF table
        Dim insertGDTF As String = "INSERT INTO GDTF (DataVersion) VALUES (@DataVersion);"
        Using command As New SQLiteCommand(insertGDTF, inMemoryConnection)
            command.Parameters.AddWithValue("@DataVersion", gdtf.DataVersion)
            command.ExecuteNonQuery()
        End Using

        ' Insert data into FixtureType table
        Dim insertFixtureType As String = "INSERT INTO FixtureType (CanHaveChildren, Description, FixtureTypeID, LongName, Manufacturer, Name, RefFT, ShortName, Thumbnail, ThumbnailOffsetX, ThumbnailOffsetY) VALUES (@CanHaveChildren, @Description, @FixtureTypeID, @LongName, @Manufacturer, @Name, @RefFT, @ShortName, @Thumbnail, @ThumbnailOffsetX, @ThumbnailOffsetY);"
        Using command As New SQLiteCommand(insertFixtureType, inMemoryConnection)
            command.Parameters.AddWithValue("@CanHaveChildren", gdtf.FixtureType.CanHaveChildren)
            command.Parameters.AddWithValue("@Description", gdtf.FixtureType.Description)
            command.Parameters.AddWithValue("@FixtureTypeID", gdtf.FixtureType.FixtureTypeID)
            command.Parameters.AddWithValue("@LongName", gdtf.FixtureType.LongName)
            command.Parameters.AddWithValue("@Manufacturer", gdtf.FixtureType.Manufacturer)
            command.Parameters.AddWithValue("@Name", gdtf.FixtureType.Name)
            command.Parameters.AddWithValue("@RefFT", gdtf.FixtureType.RefFT)
            command.Parameters.AddWithValue("@ShortName", gdtf.FixtureType.ShortName)
            command.Parameters.AddWithValue("@Thumbnail", gdtf.FixtureType.Thumbnail)
            command.Parameters.AddWithValue("@ThumbnailOffsetX", gdtf.FixtureType.ThumbnailOffsetX)
            command.Parameters.AddWithValue("@ThumbnailOffsetY", gdtf.FixtureType.ThumbnailOffsetY)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Class

<XmlRoot("GDTF")>
Public Class GDTF
    <XmlAttribute("DataVersion")>
    Public Property DataVersion As String

    <XmlElement("FixtureType")>
    Public Property FixtureType As FixtureType
End Class

Public Class FixtureType
    <XmlAttribute("CanHaveChildren")>
    Public Property CanHaveChildren As String

    <XmlAttribute("Description")>
    Public Property Description As String

    <XmlAttribute("FixtureTypeID")>
    Public Property FixtureTypeID As String

    <XmlAttribute("LongName")>
    Public Property LongName As String

    <XmlAttribute("Manufacturer")>
    Public Property Manufacturer As String

    <XmlAttribute("Name")>
    Public Property Name As String

    <XmlAttribute("RefFT")>
    Public Property RefFT As String

    <XmlAttribute("ShortName")>
    Public Property ShortName As String

    <XmlAttribute("Thumbnail")>
    Public Property Thumbnail As String

    <XmlAttribute("ThumbnailOffsetX")>
    Public Property ThumbnailOffsetX As String

    <XmlAttribute("ThumbnailOffsetY")>
    Public Property ThumbnailOffsetY As String

    <XmlElement("DMXModes")>
    Public Property DMXModes As DMXModes
    Public Property AttributeDefinitions As AttributeDefinitions
    Public Property Wheels As Wheels
    Public Property PhysicalDescriptions As PhysicalDescriptions
    Public Property Models As Models
    Public Property Geometries As Geometries
    'Public Property Revisions As Revisions
    'Public Property FTPresets As FTPresets
    'Public Property Protocols As Protocols
End Class

Public Class DMXModes
    <XmlElement("DMXMode")>
    Public Property DMXMode As List(Of DMXMode)
End Class

Public Class DMXMode
    <XmlAttribute("Description")>
    Public Property Description As String

    <XmlAttribute("Geometry")>
    Public Property Geometry As String

    <XmlAttribute("Name")>
    Public Property Name As String

    <XmlElement("DMXChannels")>
    Public Property DMXChannels As DMXChannels

    <XmlElement("Relations")>
    Public Property Relations As String

    <XmlElement("FTMacros")>
    Public Property FTMicros As FTMicros
End Class

Public Class DMXChannels
    <XmlElement("DMXChannel")>
    Public Property DMXChannel As List(Of DMXChannel)
End Class

Public Class DMXChannel
    <XmlAttribute("DMXBreak")>
    Public Property DMXBreak As String

    <XmlAttribute("Geometry")>
    Public Property Geometry As String

    <XmlAttribute("Highlight")>
    Public Property Highlight As String

    <XmlAttribute("InitialFunction")>
    Public Property InitialFunction As String

    <XmlAttribute("Offset")>
    Public Property Offset As String

    <XmlElement("LogicalChannel")>
    Public Property LogicalChannel As LogicalChannel
End Class

Public Class LogicalChannel
    <XmlAttribute("Attribute")>
    Public Property Attribute As String

    <XmlAttribute("DMXChangeTimeLimit")>
    Public Property DMXChangeTimeLimit As String

    <XmlAttribute("Master")>
    Public Property Master As String

    <XmlAttribute("MibFade")>
    Public Property MibFade As String

    <XmlAttribute("Snap")>
    Public Property Snap As String

    <XmlElement("ChannelFunction")>
    Public Property ChannelFunction As ChannelFunction
End Class

Public Class ChannelFunction
    <XmlAttribute("Attribute")>
    Public Property Attribute As String

    <XmlAttribute("CustomName")>
    Public Property CustomName As String

    <XmlAttribute("DMXFrom")>
    Public Property DMXFrom As String

    <XmlAttribute("Default")>
    Public Property [Default] As String

    <XmlAttribute("Max")>
    Public Property Max As String

    <XmlAttribute("Min")>
    Public Property Min As String

    <XmlAttribute("Name")>
    Public Property Name As String

    <XmlAttribute("OriginalAttribute")>
    Public Property OriginalAttribute As String

    <XmlAttribute("PhysicalFrom")>
    Public Property PhysicalFrom As String

    <XmlAttribute("PhysicalTo")>
    Public Property PhysicalTo As String

    <XmlAttribute("RealAcceleration")>
    Public Property RealAcceleration As String

    <XmlAttribute("RealFade")>
    Public Property RealFade As String

    <XmlElement("ChannelSet")>
    Public Property ChannelSet As List(Of ChannelSet)
End Class

Public Class ChannelSet
    <XmlAttribute("DMXFrom")>
    Public Property DMXFrom As String

    <XmlAttribute("Name")>
    Public Property Name As String

    <XmlAttribute("WheelSlotIndex")>
    Public Property WheelSlotIndex As String
End Class

Public Class FTMicros
    <XmlElement("FTMacro")>
    Public Property FTMacro As List(Of FTMacro)
End Class

Public Class FTMacro
    <XmlAttribute("Name")>
    Public Property Name As String

    <XmlElement("MacroDMX")>
    Public Property MacroDMX As MacroDMX
End Class

Public Class MacroDMX
    <XmlElement("MacroDMXStep")>
    Public Property MacroDMXStep As List(Of MacroDMXStep)
End Class

Public Class MacroDMXStep
    <XmlAttribute("Duration")>
    Public Property Duration As String
End Class
<XmlRoot("AttributeDefinitions")>
Public Class AttributeDefinitions
    Public Property ActivationGroups As ActivationGroups
    Public Property FeatureGroups As FeatureGroups
    Public Property Attributes As Attributes
End Class

Public Class ActivationGroups
    <XmlElement("ActivationGroup")>
    Public Property ActivationGroupList As List(Of ActivationGroup)
End Class

Public Class ActivationGroup
    <XmlAttribute("Name")>
    Public Property Name As String
End Class

Public Class FeatureGroups
    <XmlElement("FeatureGroup")>
    Public Property FeatureGroupList As List(Of FeatureGroup)
End Class

Public Class FeatureGroup
    <XmlAttribute("Name")>
    Public Property Name As String
    <XmlAttribute("Pretty")>
    Public Property Pretty As String
    <XmlElement("Feature")>
    Public Property FeatureList As List(Of Feature)
End Class

Public Class Feature
    <XmlAttribute("Name")>
    Public Property Name As String
End Class

Public Class Attributes
    <XmlElement("Attribute")>
    Public Property AttributeList As List(Of [Attribute])
End Class

Public Class [Attribute]
    <XmlAttribute("ActivationGroup")>
    Public Property ActivationGroup As String
    <XmlAttribute("Feature")>
    Public Property Feature As String
    <XmlAttribute("Name")>
    Public Property Name As String
    <XmlAttribute("PhysicalUnit")>
    Public Property PhysicalUnit As String
    <XmlAttribute("Pretty")>
    Public Property Pretty As String
End Class

<XmlRoot("Wheels")>
Public Class Wheels
    <XmlElement("Wheel")>
    Public Property WheelList As List(Of Wheel)
End Class

Public Class Wheel
    <XmlAttribute("Name")>
    Public Property Name As String
    <XmlElement("Slot")>
    Public Property SlotList As List(Of Slot)
End Class

Public Class Slot
    <XmlAttribute("Color")>
    Public Property Color As String
    <XmlAttribute("Name")>
    Public Property Name As String
    <XmlElement("Facet")>
    Public Property Facet As Facet
End Class

Public Class Facet
    <XmlAttribute("Color")>
    Public Property Color As String
    <XmlAttribute("Rotation")>
    Public Property Rotation As String
End Class
<XmlRoot("PhysicalDescriptions")>
Public Class PhysicalDescriptions
    Public Property ColorSpace As ColorSpace
    Public Property AdditionalColorSpaces As AdditionalColorSpaces
    Public Property Gamuts As Gamuts
    Public Property Filters As Filters
    Public Property Emitters As Emitters
    Public Property DMXProfiles As DMXProfiles
    Public Property CRIs As CRIs
    Public Property Connectors As Connectors
    Public Property Properties As Properties
End Class

Public Class ColorSpace
    <XmlAttribute("Mode")>
    Public Property Mode As String
    <XmlAttribute("Name")>
    Public Property Name As String
End Class

Public Class AdditionalColorSpaces
End Class

Public Class Gamuts
End Class

Public Class Filters
End Class

Public Class Emitters
    <XmlElement("Emitter")>
    Public Property EmitterList As List(Of Emitter)
End Class

Public Class Emitter
    <XmlAttribute("Color")>
    Public Property Color As String
    <XmlAttribute("DiodePart")>
    Public Property DiodePart As String
    <XmlAttribute("DominantWaveLength")>
    Public Property DominantWaveLength As String
    <XmlAttribute("Name")>
    Public Property Name As String
    <XmlElement("Measurement")>
    Public Property Measurement As Measurement
End Class

Public Class Measurement
    <XmlAttribute("InterpolationTo")>
    Public Property InterpolationTo As String
    <XmlAttribute("LuminousIntensity")>
    Public Property LuminousIntensity As String
    <XmlAttribute("Physical")>
    Public Property Physical As String
End Class

Public Class DMXProfiles
End Class

Public Class CRIs
End Class

Public Class Connectors
End Class

Public Class Properties
    Public Property OperatingTemperature As OperatingTemperature
    Public Property Weight As Weight
    Public Property LegHeight As LegHeight
End Class

Public Class OperatingTemperature
    <XmlAttribute("High")>
    Public Property High As String
    <XmlAttribute("Low")>
    Public Property Low As String
End Class

Public Class Weight
    <XmlAttribute("Value")>
    Public Property Value As String
End Class

Public Class LegHeight
    <XmlAttribute("Value")>
    Public Property Value As String
End Class

<XmlRoot("Models")>
Public Class Models
    <XmlElement("Model")>
    Public Property ModelList As List(Of Model)
End Class

Public Class Model
    <XmlAttribute("File")>
    Public Property File As String
    <XmlAttribute("Height")>
    Public Property Height As String
    <XmlAttribute("Length")>
    Public Property Length As String
    <XmlAttribute("Name")>
    Public Property Name As String
    <XmlAttribute("PrimitiveType")>
    Public Property PrimitiveType As String
    <XmlAttribute("SVGFrontOffsetX")>
    Public Property SVGFrontOffsetX As String
    <XmlAttribute("SVGFrontOffsetY")>
    Public Property SVGFrontOffsetY As String
    <XmlAttribute("SVGOffsetX")>
    Public Property SVGOffsetX As String
    <XmlAttribute("SVGOffsetY")>
    Public Property SVGOffsetY As String
    <XmlAttribute("SVGSideOffsetX")>
    Public Property SVGSideOffsetX As String
    <XmlAttribute("SVGSideOffsetY")>
    Public Property SVGSideOffsetY As String
    <XmlAttribute("Width")>
    Public Property Width As String
End Class

<XmlRoot("Geometries")>
Public Class Geometries
    <XmlElement("Geometry")>
    Public Property GeometryList As List(Of Geometry)
End Class

Public Class Geometry
    <XmlAttribute("Model")>
    Public Property Model As String
    <XmlAttribute("Name")>
    Public Property Name As String
    <XmlAttribute("Position")>
    Public Property Position As String
    <XmlElement("Magnet")>
    Public Property Magnet As Magnet
End Class

Public Class Magnet
    <XmlAttribute("Model")>
    Public Property Model As String
    <XmlAttribute("Name")>
    Public Property Name As String
    <XmlAttribute("Position")>
    Public Property Position As String
    <XmlElement("Beam")>
    Public Property Beam As Beam
    <XmlElement("Geometry")>
    Public Property Geometry As Geometry
End Class

Public Class Beam
    <XmlAttribute("BeamAngle")>
    Public Property BeamAngle As String
    <XmlAttribute("BeamRadius")>
    Public Property BeamRadius As String
    <XmlAttribute("BeamType")>
    Public Property BeamType As String
    <XmlAttribute("ColorRenderingIndex")>
    Public Property ColorRenderingIndex As String
    <XmlAttribute("ColorTemperature")>
    Public Property ColorTemperature As String
    <XmlAttribute("FieldAngle")>
    Public Property FieldAngle As String
    <XmlAttribute("LampType")>
    Public Property LampType As String
    <XmlAttribute("LuminousFlux")>
    Public Property LuminousFlux As String
    <XmlAttribute("Model")>
    Public Property Model As String
    <XmlAttribute("Name")>
    Public Property Name As String
    <XmlAttribute("Position")>
    Public Property Position As String
    <XmlAttribute("PowerConsumption")>
    Public Property PowerConsumption As String
    <XmlAttribute("RectangleRatio")>
    Public Property RectangleRatio As String
    <XmlAttribute("ThrowRatio")>
    Public Property ThrowRatio As String
End Class

Public Class WiringObject
    <XmlAttribute("ComponentType")>
    Public Property ComponentType As String
    <XmlAttribute("ConnectorType")>
    Public Property ConnectorType As String
    <XmlAttribute("CosPhi")>
    Public Property CosPhi As String
    <XmlAttribute("ElectricalPayLoad")>
    Public Property ElectricalPayLoad As String
    <XmlAttribute("FrequencyRangeMax")>
    Public Property FrequencyRangeMax As String
    <XmlAttribute("FrequencyRangeMin")>
    Public Property FrequencyRangeMin As String
    <XmlAttribute("FuseCurrent")>
    Public Property FuseCurrent As String
    <XmlAttribute("FuseRating")>
    Public Property FuseRating As String
    <XmlAttribute("MaxPayLoad")>
    Public Property MaxPayLoad As String
    <XmlAttribute("Name")>
    Public Property Name As String
    <XmlAttribute("Orientation")>
    Public Property Orientation As String
    <XmlAttribute("PinCount")>
    Public Property PinCount As String
    <XmlAttribute("Position")>
    Public Property Position As String
    <XmlAttribute("SignalLayer")>
    Public Property SignalLayer As String
    <XmlAttribute("SignalType")>
    Public Property SignalType As String
    <XmlAttribute("Voltage")>
    Public Property Voltage As String
    <XmlAttribute("VoltageRangeMax")>
    Public Property VoltageRangeMax As String
    <XmlAttribute("VoltageRangeMin")>
    Public Property VoltageRangeMin As String
    <XmlAttribute("WireGroup")>
    Public Property WireGroup As String
End Class
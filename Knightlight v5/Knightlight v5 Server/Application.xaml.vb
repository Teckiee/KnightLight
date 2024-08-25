Imports System.Drawing
Imports System.Windows
Imports Hardcodet.Wpf.TaskbarNotification
Class Application

    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.
    Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
        Dim args As String() = Environment.GetCommandLineArgs()

        serverWindow1 = New ServerWindow
        'InitializeTaskbarIcon(serverWindow1)

    End Sub
    Private Sub Application_Startup(sender As Object, e As StartupEventArgs)
        'Dim serverWindow1 As New ServerWindow()
        InitializeTaskbarIcon(serverWindow1)

        'serverWindow1.Show()
    End Sub
    Private Sub InitializeTaskbarIcon(mainWindow As ServerWindow)
        tbi = New TaskbarIcon()
        tbi.Icon = New Icon("favicon.ico")
        tbi.ToolTipText = "hello world"
        tbi.Visibility = Visibility.Visible

        ' Optionally, you can set the DataContext to the main window or another view model
        tbi.DataContext = mainWindow
        serverWindow1.Show()
    End Sub

End Class

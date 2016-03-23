Imports System.Net
Imports System.IO
Imports System.Data
Imports System.Windows.Threading



Class MainWindow

    Private rssTimer As DispatcherTimer
    Private nowTimer As DispatcherTimer
    Dim rssURL As String

    Private Sub button_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
        Me.WindowState = Windows.WindowState.Minimized
        Try
            phoneWindow.WindowState = Windows.WindowState.Minimized
            notesWindow.WindowState = Windows.WindowState.Minimized
            calendarWindow.WindowState = Windows.WindowState.Minimized
            drawingWindow.WindowState = Windows.WindowState.Minimized
            journalWindow.WindowState = Windows.WindowState.Minimized
            lockWindow.WindowState = Windows.WindowState.Minimized
        Catch ex As Exception

        End Try

    End Sub

    Private Sub button1_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles button1.Click
        Try
            nowTimer.Stop()
            rssTimer.Stop()
        Catch ex As Exception

        End Try

        phoneWindow.Close()
        notesWindow.Close()
        calendarWindow.Close()
        drawingWindow.Close()
        journalWindow.Close()
        lockWindow.Close()
        rssconfig.Close()

        Me.Close()

        Application.Current.Shutdown()
    End Sub

    Dim rssconfig As New RssConfigWindow
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click

        If rssconfig.IsVisible = True Then
            rssconfig.Hide()
        Else
            rssconfig.ShowDialog()
        End If

    End Sub

    Private Sub Window_Initialized(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Initialized
        TimeMe()
        timeChange()
        Try
            TextBlock1.Text = "Hello " + Environment.UserName + " !"
        Catch ex As Exception
            TextBlock1.Text = "Hello User ! "
        End Try


    End Sub
    Dim notesWindow As New NotesWindow
    Private Sub notesButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles notesButton.Click
        If notesWindow.IsVisible = True Then
            notesWindow.Hide()
        Else
            notesWindow.Show()
        End If
       
    End Sub
    Dim calendarWindow As New CalendarWindow
    Private Sub calendarButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles calendarButton.Click
        If calendarWindow.IsVisible = True Then
            calendarWindow.Hide()
        Else
            calendarWindow.Show()
        End If
    End Sub
    Dim drawingWindow As New DrawingWindow
    Private Sub scribbleButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles scribbleButton.Click
        If drawingWindow.IsVisible = True Then
            drawingWindow.Hide()
        Else
            drawingWindow.Show()
        End If
    End Sub

    Dim dsRss As New DataSet
    Dim rssCount As Integer = 0
    Dim i As Integer = 0
    Dim j As Integer = 0

    Private Sub readRSS()
        Dim rssrequest As HttpWebRequest
        Dim rssresponse As HttpWebResponse = Nothing

        dsRss.Clear()

        Try
            Me.Cursor = Cursors.Wait
            rssrequest = DirectCast(WebRequest.Create(rssURL), HttpWebRequest)

            rssresponse = DirectCast(rssrequest.GetResponse(), HttpWebResponse)

            dsRss.ReadXml(rssresponse.GetResponseStream())
            rssCount = dsRss.Tables("item").DefaultView.Count
        Catch ex As Exception
            MsgBox("Unable to load RSS feeds. Please check your RSS feed URL or internet connection.", MsgBoxStyle.Exclamation, "Connection Failed")

        Finally
            Me.Cursor = Cursors.Arrow
            If Not rssresponse Is Nothing Then rssresponse.Close()
        End Try

    End Sub
    Private Sub rssChange()
        rssTimer = New DispatcherTimer
        rssTimer.Interval = TimeSpan.FromMilliseconds(5000)
        AddHandler rssTimer.Tick, AddressOf TickMe
        rssTimer.Start()
        i = 0
    End Sub
    Private Sub TickMe()
        Try
            rssBlock.Text = dsRss.Tables("item").Rows(i)(0).ToString()
            j = i
            i = i + 1

            If i = rssCount Then
                i = 0
            End If
        Catch ex As Exception

        End Try
       
    End Sub

    Private Sub rssBlock_MouseLeftButtonDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles rssBlock.MouseLeftButtonDown
        Try
            Dim rssURL As String
            rssURL = dsRss.Tables("item").Rows(j)("link").ToString()

            System.Diagnostics.Process.Start(rssURL)
        Catch ex As Exception
            MsgBox("No RSS feeds loaded! Click the RSS button or check your internet connection.", MsgBoxStyle.Exclamation, "No Feeds")
        End Try



    End Sub

    Private Sub timeChange()
        nowTimer = New DispatcherTimer
        nowTimer.Interval = TimeSpan.FromMilliseconds(30000)
        AddHandler nowTimer.Tick, AddressOf TimeMe
        nowTimer.Start()

    End Sub
    Private Sub TimeMe()
        Dim nowtime As DateTime = DateTime.Now
        timeblock.Text = nowtime.ToString("t")
        
    End Sub

    Private Sub button3_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles button3.Click
        Try
            rssTimer.Stop()
        Catch ex As Exception

        End Try
        If File.Exists("PDeskRSS.txt") Then
            Try
                rssURL = IO.File.ReadAllText("PDeskRSS.txt")
                readRSS()
                TickMe()
                rssChange()
            Catch ex As Exception
                MsgBox("Unable to read RSS URL.", MsgBoxStyle.Exclamation, "Error")
            End Try
           
        Else
            rssconfig.ShowDialog()
        End If
        
    End Sub
    Dim phoneWindow As New PhoneWindow
    Private Sub callButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles callButton.Click
        If phoneWindow.IsVisible = True Then
            phoneWindow.Hide()
        Else
            phoneWindow.Show()
        End If

    End Sub

    Private Sub PDesk_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            phoneWindow.WindowState = Windows.WindowState.Normal
            notesWindow.WindowState = Windows.WindowState.Normal
            calendarWindow.WindowState = Windows.WindowState.Normal
            drawingWindow.WindowState = Windows.WindowState.Normal
            journalWindow.WindowState = Windows.WindowState.Normal
            lockWindow.WindowState = Windows.WindowState.Normal

        Catch ex As Exception

        End Try
    End Sub
    Dim journalWindow As New JournalWindow
    Private Sub journalButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles journalButton.Click
        If journalWindow.IsVisible = True Then
            journalWindow.Hide()
        Else
            journalWindow.Show()
        End If
    End Sub
    Dim lockWindow As New LockWindow
    Private Sub lockButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles lockButton.Click
        If lockWindow.IsVisible = True Then
            lockWindow.Hide()
        Else
            lockWindow.Show()
        End If
    End Sub
    Dim aboutBox As New aboutWindow
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button4.Click
        If aboutBox.IsVisible = True Then
            aboutBox.Hide()
        Else
            aboutBox.ShowDialog()
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button5.Click
        Try
            System.Diagnostics.Process.Start("PDeskHelp.pdf")
        Catch ex As Exception
            MsgBox("Error in loading User Manual. Check the Manual in the Installation Disc.", MsgBoxStyle.Exclamation, "Error")
        End Try

    End Sub
End Class
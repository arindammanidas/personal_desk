Imports System
Imports System.IO
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation

Partial Public Class RssConfigWindow
    Dim rssFile As String = "PDeskRSS.txt"
    Public Sub New()
        MyBase.New()

        Me.InitializeComponent()

        Try
            rssText.Clear()
            rssText.Text = IO.File.ReadAllText(rssFile)
        Catch ex As Exception

        End Try

        If rssText.Text.Length = 0 Then
            rssText.Text = "Enter feed URL here"
        End If

        ' Insert code required on object creation below this point.
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        Try
            IO.File.WriteAllText(rssFile, rssText.Text)
        Catch ex As Exception
            MsgBox("Error in Saving URL.", MsgBoxStyle.Critical, "Save Failure")
        Finally
            Me.Hide()
        End Try
    End Sub

    Private Sub rssRec1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles rssRec1.MouseDown
        Me.DragMove()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        rssText.Clear()
        rssText.Text = "http://news.google.com/news?pz=1&cf=all&ned=in&hl=en&output=rss"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button3.Click
        Me.Hide()
    End Sub
End Class

Imports System
Imports System.IO
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation

Partial Public Class DrawingWindow
	Public Sub New()
		MyBase.New()

		Me.InitializeComponent()

        OpenDrawing()

    End Sub
    Dim drawFile As String = "PDeskDraw.ink"
    Private Sub OpenDrawing()
        Try
            Dim drawStream As New FileStream(drawFile, FileMode.Open)
            drawCanvas.Strokes = New System.Windows.Ink.StrokeCollection(drawStream)
            drawStream.Close()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Image1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles Image1.MouseDown
        Me.DragMove()
    End Sub
    Private Sub SaveDrawing()
        Try
            Dim drawStream1 As New FileStream(drawFile, FileMode.Create)
            drawCanvas.Strokes.Save(drawStream1)
            drawStream1.Close()
        Catch ex As Exception
            MsgBox("Error in Saving Drawing.", MsgBoxStyle.Critical, "Save Failure")
        End Try

    End Sub
    Private Sub Window_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        SaveDrawing()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        drawCanvas.Strokes.Clear()
    End Sub
End Class

Imports System
Imports System.IO
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation

Partial Public Class NotesWindow
	Public Sub New()
		MyBase.New()

		Me.InitializeComponent()
        OpenNotes()
        If notesTextBox.Text.Length = 0 Then
            notesTextBox.Text = "Notes..."
        End If

	End Sub
    Dim notesFile As String = "PDeskNotes.txt"
    Private Sub OpenNotes()

        Try
            notesTextBox.Clear()
            notesTextBox.Text = IO.File.ReadAllText(notesFile)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub notesRec_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles notesRec.MouseDown
        Me.DragMove()
    End Sub
    Private Sub SaveNotes()
        Try
            IO.File.WriteAllText(notesFile, notesTextBox.Text)
        Catch ex As Exception
            MsgBox("Error in Saving Notes.", MsgBoxStyle.Critical, "Save Failure")
        End Try
    End Sub
    Private Sub Window_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        SaveNotes()
    End Sub
End Class

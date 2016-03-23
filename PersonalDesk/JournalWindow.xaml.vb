Imports System
Imports System.IO
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation


Partial Public Class JournalWindow
	Public Sub New()
		MyBase.New()

		Me.InitializeComponent()

        DatePicker1.Text = Date.Today
        OpenJournal()

	End Sub
    Private Sub OpenJournal()
        Try
            Dim journalRTF As String = DatePicker1.Text + ".rtf"
            richJournal.Document.Blocks.Clear()
            If File.Exists(journalRTF) Then
                Dim journalStream As New FileStream(journalRTF, FileMode.OpenOrCreate, FileAccess.Read)
                Using journalStream
                    Dim journalRTFText As New TextRange(richJournal.Document.ContentStart, richJournal.Document.ContentEnd)
                    journalRTFText.Load(journalStream, DataFormats.Rtf)
                End Using
            End If
        Catch ex As Exception
            MsgBox("Error in Loading Journal.", MsgBoxStyle.Critical, "Load Failure")
        End Try

    End Sub
    Private Sub journalRec_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles journalRec.MouseDown
        Me.DragMove()
    End Sub
    Private Sub SaveJournal()

        Try
            Dim journalRTF As String = DatePicker1.Text + ".rtf"
            Dim journalStream As New FileStream(journalRTF, FileMode.OpenOrCreate, FileAccess.Write)

            Using journalStream

                Dim journalRTFText As New TextRange(richJournal.Document.ContentStart, richJournal.Document.ContentEnd)

                journalRTFText.Save(journalStream, DataFormats.Rtf)

            End Using
        Catch ex As Exception
            MsgBox("Error in Saving Journal.", MsgBoxStyle.Critical, "Save Failure")
        End Try
       
    End Sub
    Private Sub Window_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        SaveJournal()
    End Sub

    Private Sub DatePicker1_SelectedDateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles DatePicker1.SelectedDateChanged
        If DatePicker1.Text.Length = 0 Then
            MsgBox("Please select a date.", MsgBoxStyle.Information, "No Date Selected")
        Else
            OpenJournal()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        SaveJournal()
        MsgBox("Journal Entry Saved.", MsgBoxStyle.Information, "Saved")

    End Sub

End Class

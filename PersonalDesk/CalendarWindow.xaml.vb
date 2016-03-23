Imports System
Imports System.IO
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation

Partial Public Class CalendarWindow
	Public Sub New()
		MyBase.New()

		Me.InitializeComponent()

		' Insert code required on object creation below this point.
	End Sub


    Private Sub Rectangle1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles Rectangle1.MouseDown
        Me.DragMove()
    End Sub

    Private Sub Label1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles Label1.MouseDown
        Me.DragMove()
    End Sub
End Class

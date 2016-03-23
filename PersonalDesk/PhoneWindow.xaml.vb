Imports System
Imports System.IO
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation
Imports System.Threading
Imports System.IO.Ports
Imports System.ComponentModel

Partial Public Class PhoneWindow
    Dim CallPort = New SerialPort
    Public Sub New()
        MyBase.New()

        Me.InitializeComponent()


    End Sub

    Private Sub phoneRec_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles phoneRec.MouseDown
        Me.DragMove()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        If phNumber.Text.Length = 0 Or phNumber.Text = "Enter Phone" Then
            MsgBox("Please enter a Phone Number", MsgBoxStyle.Information, "No Number")
        Else
            If phSMS.Text.Length > 160 Then
                MsgBox("Your SMS length is " + phSMS.Text.Length.ToString() + " . Please reduce it to 160 characters or less.", MsgBoxStyle.Information, "SMS Too Long")
            Else
                If phCentre.Text.Length = 0 Or phCentre.Text = "Centre No." Then
                    SendSMS()
                Else
                    SendSMSCentre()
                End If
            End If
        End If

    End Sub
    Private Sub SendSMSCentre()
        Try

           With CallPort
                .PortName = phPort.Text
                .BaudRate = "19200"
                .Parity = Parity.None
                .DataBits = 8
                .StopBits = StopBits.One
                .Handshake = Handshake.RequestToSend
                .DtrEnable = True
                .RtsEnable = True
                .ReadBufferSize = 10000
                .ReadTimeout = 10000
                .WriteBufferSize = 10000
                .WriteTimeout = 10000
                .NewLine = vbCrLf
                .Open()
                Thread.Sleep(1000)
            End With

            If CallPort.IsOpen = True Then
                CallPort.DiscardOutBuffer()
                CallPort.DiscardInBuffer()
                Me.Cursor = Cursors.Wait
                CallPort.WriteLine("AT" + vbCrLf)
                Thread.Sleep(1000)
                CallPort.WriteLine("AT+CMGF=1" + vbCrLf)
                Thread.Sleep(1000)
                CallPort.WriteLine("AT+CSCA=" + Char.ConvertFromUtf32(34) + phCentre.Text + Char.ConvertFromUtf32(34) + vbCrLf)
                Thread.Sleep(1000)
                CallPort.WriteLine("AT+CMGS=" + Char.ConvertFromUtf32(34) + phNumber.Text + Char.ConvertFromUtf32(34) + vbCrLf)
                Thread.Sleep(1000)
                CallPort.WriteLine(phSMS.Text + Char.ConvertFromUtf32(26))
                Thread.Sleep(3000)
                Me.Cursor = Cursors.Arrow
                MsgBox("SMS sent to " + phNumber.Text + ". Details: " + CallPort.ReadExisting(), MsgBoxStyle.Information, "SMS Sent")
                CallPort.Close()
            End If
        Catch ex As Exception
            MsgBox("Error in communicating with Modem : Check COM Port or Phone Number", MsgBoxStyle.Exclamation, "Modem Error")
            If CallPort.IsOpen = True Then
                CallPort.Close()
            End If
        End Try

    End Sub
    Private Sub SendSMS()
        Try
            With CallPort
                .PortName = phPort.Text
                .BaudRate = "19200"
                .Parity = Parity.None
                .DataBits = 8
                .StopBits = StopBits.One
                .Handshake = Handshake.RequestToSend
                .DtrEnable = True
                .RtsEnable = True
                .ReadBufferSize = 10000
                .ReadTimeout = 10000
                .WriteBufferSize = 10000
                .WriteTimeout = 10000
                .NewLine = vbCrLf
                .Open()
                Thread.Sleep(1000)
            End With

            If CallPort.IsOpen = True Then
                CallPort.DiscardOutBuffer()
                CallPort.DiscardInBuffer()
                Me.Cursor = Cursors.Wait
                CallPort.WriteLine("AT" + vbCrLf)
                Thread.Sleep(1000)
                CallPort.WriteLine("AT+CMGF=1" + vbCrLf)
                Thread.Sleep(1000)
                CallPort.WriteLine("AT+CMGS=" + Char.ConvertFromUtf32(34) + phNumber.Text + Char.ConvertFromUtf32(34) + vbCrLf)
                Thread.Sleep(1000)
                CallPort.WriteLine(phSMS.Text + Char.ConvertFromUtf32(26))
                Thread.Sleep(3000)
                Me.Cursor = Cursors.Arrow
                MsgBox("SMS sent to " + phNumber.Text + ". Details: " + CallPort.ReadExisting(), MsgBoxStyle.Information, "SMS Sent")
                CallPort.Close()
            End If
        Catch ex As Exception
            MsgBox("Error in communicating with Modem : Check COM Port or Phone Number", MsgBoxStyle.Exclamation, "Modem Error")
            If CallPort.IsOpen = True Then
                CallPort.Close()
            End If
        End Try

    End Sub
    Private Sub MakeCall()
        Try
            With CallPort
                .PortName = phPort.Text
                .BaudRate = "19200"
                .Parity = Parity.None
                .DataBits = 8
                .StopBits = StopBits.One
                .Handshake = Handshake.RequestToSend
                .DtrEnable = True
                .RtsEnable = True
                .ReadBufferSize = 10000
                .ReadTimeout = 10000
                .WriteBufferSize = 10000
                .WriteTimeout = 10000
                .NewLine = vbCrLf
                .Open()
                Thread.Sleep(1000)
            End With

            If CallPort.IsOpen = True Then
                CallPort.DiscardOutBuffer()
                CallPort.DiscardInBuffer()
                Me.Cursor = Cursors.Wait
                CallPort.WriteLine("AT" + vbCrLf)
                Thread.Sleep(2000)
                CallPort.WriteLine("ATD " + phNumber.Text + ";" + vbCrLf)
                Thread.Sleep(3000)
                Me.Cursor = Cursors.Arrow
                MsgBox("Call to " + phNumber.Text + " in progress. Details: " + CallPort.ReadExisting(), MsgBoxStyle.Information, "Call In Progress")
                CallPort.Close()
            End If
        Catch ex As Exception
            MsgBox("Error in communicating with Modem : Check COM Port or Phone Number", MsgBoxStyle.Exclamation, "Modem Error")
            If CallPort.IsOpen = True Then
                CallPort.Close()
            End If
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        If phNumber.Text.Length = 0 Or phNumber.Text = "Enter Phone" Then
            MsgBox("Please enter a Phone Number", MsgBoxStyle.Information, "No Number")
        Else
            MakeCall()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button3.Click
        HangUp()
    End Sub
    Private Sub HangUp()
        Try
            If CallPort.IsOpen = False Then
                With CallPort
                    .PortName = phPort.Text
                    .BaudRate = "19200"
                    .Parity = Parity.None
                    .DataBits = 8
                    .StopBits = StopBits.One
                    .Handshake = Handshake.RequestToSend
                    .DtrEnable = True
                    .RtsEnable = True
                    .ReadBufferSize = 10000
                    .ReadTimeout = 10000
                    .WriteBufferSize = 10000
                    .WriteTimeout = 10000
                    .NewLine = vbCrLf
                    .Open()
                    Thread.Sleep(1000)
                End With

                If CallPort.IsOpen = True Then
                    CallPort.DiscardOutBuffer()
                    CallPort.DiscardInBuffer()
                    Me.Cursor = Cursors.Wait
                    CallPort.WriteLine("ATH" + vbCrLf)
                    Thread.Sleep(2000)
                    Me.Cursor = Cursors.Arrow
                    MsgBox("Call Hung Up. Details: " + CallPort.ReadExisting(), MsgBoxStyle.Information, "Call In Progress")
                    CallPort.Close()
                End If
            Else
                MsgBox("No call in progress.", MsgBoxStyle.Information, "Error")
            End If
        Catch ex As Exception
            MsgBox("Error in communicating with Modem : Check COM Port or Phone Number", MsgBoxStyle.Exclamation, "Modem Error")
            If CallPort.IsOpen = True Then
                CallPort.Close()
            End If
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button4.Click
        If phNumber.Text = "Enter Phone" Then
            phNumber.Clear()
        End If
        phNumber.Text = phNumber.Text + "1"
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button5.Click
        If phNumber.Text = "Enter Phone" Then
            phNumber.Clear()
        End If
        phNumber.Text = phNumber.Text + "2"
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button6.Click
        If phNumber.Text = "Enter Phone" Then
            phNumber.Clear()
        End If
        phNumber.Text = phNumber.Text + "3"
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button7.Click
        If phNumber.Text = "Enter Phone" Then
            phNumber.Clear()
        End If
        phNumber.Text = phNumber.Text + "4"
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button8.Click
        If phNumber.Text = "Enter Phone" Then
            phNumber.Clear()
        End If
        phNumber.Text = phNumber.Text + "5"
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button9.Click
        If phNumber.Text = "Enter Phone" Then
            phNumber.Clear()
        End If
        phNumber.Text = phNumber.Text + "6"
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button10.Click
        If phNumber.Text = "Enter Phone" Then
            phNumber.Clear()
        End If
        phNumber.Text = phNumber.Text + "7"
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button11.Click
        If phNumber.Text = "Enter Phone" Then
            phNumber.Clear()
        End If
        phNumber.Text = phNumber.Text + "8"
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button12.Click
        If phNumber.Text = "Enter Phone" Then
            phNumber.Clear()
        End If
        phNumber.Text = phNumber.Text + "9"
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button13.Click
        If phNumber.Text = "Enter Phone" Then
            phNumber.Clear()
        End If
        phNumber.Text = phNumber.Text + "*"
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button14.Click
        If phNumber.Text = "Enter Phone" Then
            phNumber.Clear()
        End If
        phNumber.Text = phNumber.Text + "0"
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button15.Click
        If phNumber.Text = "Enter Phone" Then
            phNumber.Clear()
        End If
        phNumber.Text = phNumber.Text + "#"
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button16.Click
        phNumber.Clear()
        phSMS.Clear()
    End Sub
End Class




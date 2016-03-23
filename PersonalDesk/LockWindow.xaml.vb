Imports System
Imports System.IO
Imports System.IO.Ports
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation
Imports System.Threading
Imports System.Windows.Threading
Imports Microsoft.Win32

Partial Public Class LockWindow
    Dim lockPort As New SerialPort
    Dim imei As String
    Public Sub New()
        MyBase.New()

        Me.InitializeComponent()


    End Sub

    Private Sub lockRec_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles lockRec.MouseDown
        Me.DragMove()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        LockSystem()
    End Sub
    Dim countNum As Integer
    Private Sub LockSystem()
       
        Try

            With lockPort
                .PortName = lockText1.Text
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

            If lockPort.IsOpen = True Then
                lockPort.DiscardOutBuffer()
                lockPort.DiscardInBuffer()
                Me.Cursor = Cursors.Wait
                lockPort.WriteLine("AT" + vbCrLf)
                Thread.Sleep(1000)
                lockPort.WriteLine("AT+CGSN" + vbCrLf)
                Thread.Sleep(3000)
                Me.Cursor = Cursors.Arrow
                imei = lockPort.ReadExisting()
                lockPort.Close()

                countNum = 0
                For i As Integer = 0 To (imei.Length - 1)
                    If Char.IsNumber(imei(i)) = True Then
                        countNum = countNum + 1
                    End If
                Next

                If countNum < 12 Then

                    MsgBox("Error in connection. Probably not a GSM phone. Please try again.", MsgBoxStyle.Exclamation, "Try Again")
                Else
                    MsgBox("Cell Phone Identified. Lock Now? Please disconnect Phone from Computer before clicking Yes.", MsgBoxStyle.OkCancel, "SYSTEM LOCK")
                    If MsgBoxResult.Ok Then
                        resimei = ""
                        ActualLock()
                    End If

                End If

            End If
        Catch ex As Exception
            MsgBox("Error in communicating with Phone Modem : Check COM Port.", MsgBoxStyle.Exclamation, "Modem Error")
            If lockPort.IsOpen = True Then
                lockPort.Close()
            End If
        End Try
    End Sub
    Private lockTimer As DispatcherTimer
    Private portTimer As DispatcherTimer
    Dim lockWin As New LOCK
    Private Sub ActualLock()
        disableTaskMan()

        lockTimer = New DispatcherTimer
        lockTimer.Interval = TimeSpan.FromMilliseconds(1000)
        AddHandler lockTimer.Tick, AddressOf LockMe
        lockTimer.Start()

        portTimer = New DispatcherTimer
        portTimer.Interval = TimeSpan.FromMilliseconds(10000)
        AddHandler portTimer.Tick, AddressOf LockPortMe
        portTimer.Start()

        LockMe()
        LockPortMe()

    End Sub
    Dim resimei As String
    Private Sub LockMe()
        Try
            If lockWin.IsVisible = True Then
                lockWin.Topmost = True
                lockWin.WindowState = Windows.WindowState.Maximized
                lockWin.Focus()
            Else
                lockWin.Show()
                lockWin.Topmost = True
                lockWin.WindowState = Windows.WindowState.Maximized
                lockWin.Focus()
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub LockPortMe()
        Try

            With lockPort
                .PortName = lockText1.Text
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

            If lockPort.IsOpen = True Then
                lockPort.DiscardOutBuffer()
                lockPort.DiscardInBuffer()
                Me.Cursor = Cursors.Wait
                lockPort.WriteLine("AT" + vbCrLf)
                Thread.Sleep(1000)
                lockPort.WriteLine("AT+CGSN" + vbCrLf)
                Thread.Sleep(3000)
                Me.Cursor = Cursors.Arrow
                resimei = lockPort.ReadExisting()
                lockPort.Close()
                If resimei = imei Then
                    lockTimer.Stop()
                    portTimer.Stop()
                    lockWin.Hide()
                    'enableTaskMan()
                End If
            End If
        Catch ex As Exception

            If lockPort.IsOpen = True Then
                lockPort.Close()
            End If
        End Try
    End Sub
    Private Sub disableTaskMan()
        Try
            Dim systemRegistry As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Policies\System")
            systemRegistry.SetValue("DisableTaskMgr", 1)
            systemRegistry.Close()
        Catch ex As Exception

        End Try
        
    End Sub
    Private Sub enableTaskMan()
        Try
            Dim systemRegistry As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Microsoft\Windows\CurrentVersion\Policies\System")
            systemRegistry.SetValue("DisableTaskMgr", 0)
            systemRegistry.Close()
        Catch ex As Exception

        End Try
        
    End Sub
End Class

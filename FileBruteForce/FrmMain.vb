
''Supports .Zip .7z .Tar .Wim''
Imports SevenZip

''Supports .Rar''
Imports RARNET

Imports System.Text
Imports System.Threading

Public Class FrmMain

    Public File As String
    Public DestDir As String
    Public Characters As String = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz1234567890.-/()[]{}\ "
    Public StopW As New Stopwatch
    Public Count As Int32
    Public Lock As New Object
    Public Times
    Public PassWin = "no"
    Public FinalPass
    Public Ext
    Public IsDone As New AutoResetEvent(False)
    Delegate Sub Delegate1(PassString As String)
    Delegate Sub Delegate2(PassString As String)
    Delegate Sub Delegate3(PassString As String)
    Delegate Sub Delegate4(PassString As String)
    Delegate Sub Delegate5(PassString As String)
    Delegate Sub Delegate6(PassString As String)
    Delegate Sub Delegate7(PassString As String)
    Delegate Sub Delegate8(PassString As String)
    Delegate Sub Delegate9(PassString As String)
    Delegate Sub Delegate10(PassString As String)
    Delegate Sub Delegate11(PassString As String)
    Delegate Sub Delegate12(PassString As String)
    Delegate Sub Delegate13(PassString As String)
    Delegate Sub Delegate14(PassString As String)
    Delegate Sub Delegate15(PassString As String)
    Delegate Sub Delegate16(PassString As String)
    Delegate Sub Delegate17(PassString As String)
    Delegate Sub Delegate18(PassString As String)
    Delegate Sub Delegate19(PassString As String)
    Delegate Sub Delegate20(PassString As String)


    Public Sub BtnBrute_Click(sender As Object, e As EventArgs) Handles BtnBrute.Click

        File = TbFile.Text
        Ext = File.Substring(File.Length - 3)
        DestDir = TbDest.Text
        Count = 1
        StopW.Start()

        If Ext = "rar" Then

            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char1Rar), IsDone)
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char2Rar), IsDone)
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char3Rar), IsDone)
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char4Rar), IsDone)
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char5Rar), IsDone)
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char6Rar), IsDone)
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char7Rar), IsDone)
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char8Rar), IsDone)
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char9Rar), IsDone)
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char10Rar), IsDone)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char11Rar), IsDone)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char12Rar), IsDone)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char13Rar), IsDone)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char14Rar), IsDone)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char15Rar), IsDone)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char16Rar), IsDone)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char17Rar), IsDone)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char18Rar), IsDone)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char19Rar), IsDone)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char20Rar), IsDone)

        Else

            If Environment.Is64BitProcess Then
                SevenZip.SevenZipCompressor.SetLibraryPath("7zx64.dll")
            Else
                SevenZip.SevenZipCompressor.SetLibraryPath("7z.dll")
            End If

            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char1Zip), IsDone)
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char2Zip), IsDone)
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char3Zip), IsDone)
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char4Zip), IsDone)
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char5Zip), IsDone)
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char6Zip), IsDone)
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char7Zip), IsDone)
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char8Zip), IsDone)
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char9Zip), IsDone)
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char10Zip), IsDone)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char11Zip), IsDone)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char12Zip), IsDone)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char13Zip), IsDone)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char14Zip), IsDone)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char15Zip), IsDone)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char16Zip), IsDone)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char17Zip), IsDone)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char18Zip), IsDone)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char19Zip), IsDone)
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf Char20Zip), IsDone)

        End If

    End Sub

    Public Sub Char1Rar(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters

            If PassWin = "yes" Then Exit Sub

            PassString = (Ch1)

            Try

                Dim Rar As New Decompressor(File, PassString)
                Rar.UnPackAll(DestDir)
                PassWin = "yes" And FinalPass = Ch1

            Catch
            End Try

            'SyncLock (Lock)
            Count += 1
            TbCurAtt.Invoke(New Delegate1(AddressOf UpdateGui), New Object() {PassString})
            'End SyncLock

        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char2Rar(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters

                If PassWin = "yes" Then Exit Sub

                PassString = (Ch1 & Ch2)

                Try

                    Dim Rar As New Decompressor(File, PassString)
                    Rar.UnPackAll(DestDir)
                    PassWin = "yes" And FinalPass = PassString

                Catch
                End Try

                'SyncLock (Lock)
                Count += 1
                TbCurAtt.Invoke(New Delegate2(AddressOf UpdateGui), New Object() {PassString})
                'End SyncLock

            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char3Rar(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters

                    If PassWin = "yes" Then Exit Sub

                    PassString = (Ch1 & Ch2 & Ch3)

                    Try

                        Dim Rar As New Decompressor(File, PassString)
                        Rar.UnPackAll(DestDir)
                        PassWin = "yes" And FinalPass = PassString

                    Catch
                    End Try

                    'SyncLock (Lock)
                    Count += 1
                    TbCurAtt.Invoke(New Delegate3(AddressOf UpdateGui), New Object() {PassString})
                    'End SyncLock

                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char4Rar(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters

                        If PassWin = "yes" Then Exit Sub

                        PassString = (Ch1 & Ch2 & Ch3 & Ch4)

                        Try

                            Dim Rar As New Decompressor(File, PassString)
                            Rar.UnPackAll(DestDir)
                            PassWin = "yes" And FinalPass = PassString

                        Catch
                        End Try

                        'SyncLock (Lock)
                        Count += 1
                        TbCurAtt.Invoke(New Delegate4(AddressOf UpdateGui), New Object() {PassString})
                        'End SyncLock

                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char5Rar(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters

                            If PassWin = "yes" Then Exit Sub

                            PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5)

                            Try

                                Dim Rar As New Decompressor(File, PassString)
                                Rar.UnPackAll(DestDir)
                                PassWin = "yes" And FinalPass = PassString

                            Catch
                            End Try

                            'SyncLock (Lock)
                            Count += 1
                            TbCurAtt.Invoke(New Delegate5(AddressOf UpdateGui), New Object() {PassString})
                            'End SyncLock

                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char6Rar(ByVal State As Object)


        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters

                                If PassWin = "yes" Then Exit Sub

                                PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6)

                                Try

                                    Dim Rar As New Decompressor(File, PassString)
                                    Rar.UnPackAll(DestDir)
                                    PassWin = "yes" And FinalPass = PassString

                                Catch
                                End Try

                                'SyncLock (Lock)
                                Count += 1
                                TbCurAtt.Invoke(New Delegate6(AddressOf UpdateGui), New Object() {PassString})
                                'End SyncLock

                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char7Rar(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters

                                    If PassWin = "yes" Then Exit Sub

                                    PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7)

                                    Try

                                        Dim Rar As New Decompressor(File, PassString)
                                        Rar.UnPackAll(DestDir)
                                        PassWin = "yes" And FinalPass = PassString

                                    Catch
                                    End Try

                                    'SyncLock (Lock)
                                    Count += 1
                                    TbCurAtt.Invoke(New Delegate7(AddressOf UpdateGui), New Object() {PassString})
                                    'End SyncLock

                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char8Rar(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters

                                        If PassWin = "yes" Then Exit Sub

                                        PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8)

                                        Try

                                            Dim Rar As New Decompressor(File, PassString)
                                            Rar.UnPackAll(DestDir)
                                            PassWin = "yes" And FinalPass = PassString

                                        Catch
                                        End Try

                                        'SyncLock (Lock)
                                        Count += 1
                                        TbCurAtt.Invoke(New Delegate8(AddressOf UpdateGui), New Object() {PassString})
                                        'End SyncLock

                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

    End Sub

    Public Sub Char9Rar(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters

                                            If PassWin = "yes" Then Exit Sub

                                            PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9)

                                            Try

                                                Dim Rar As New Decompressor(File, PassString)
                                                Rar.UnPackAll(DestDir)
                                                PassWin = "yes" And FinalPass = PassString

                                            Catch
                                            End Try

                                            'SyncLock (Lock)
                                            Count += 1
                                            TbCurAtt.Invoke(New Delegate9(AddressOf UpdateGui), New Object() {PassString})
                                            'End SyncLock

                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char10Rar(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters

                                                If PassWin = "yes" Then Exit Sub

                                                PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10)
                                               
                                                Try

                                                    Dim Rar As New Decompressor(File, PassString)
                                                    Rar.UnPackAll(DestDir)
                                                    PassWin = "yes" And FinalPass = PassString

                                                Catch
                                                End Try

                                                'SyncLock (Lock)
                                                Count += 1
                                                TbCurAtt.Invoke(New Delegate10(AddressOf UpdateGui), New Object() {PassString})
                                                'End SyncLock

                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char11Rar(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters
                                                For Each Ch11 As Char In Characters

                                                    If PassWin = "yes" Then Exit Sub

                                                    PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11)
                                                   
                                                    Try

                                                        Dim Rar As New Decompressor(File, PassString)
                                                        Rar.UnPackAll(DestDir)
                                                        PassWin = "yes" And FinalPass = PassString

                                                    Catch
                                                    End Try

                                                    'SyncLock (Lock)
                                                    Count += 1
                                                    TbCurAtt.Invoke(New Delegate11(AddressOf UpdateGui), New Object() {PassString})
                                                    'End SyncLock

                                                Next
                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char12Rar(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters
                                                For Each Ch11 As Char In Characters
                                                    For Each Ch12 As Char In Characters

                                                        If PassWin = "yes" Then Exit Sub

                                                        PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11 & Ch12)

                                                        Try

                                                            Dim Rar As New Decompressor(File, PassString)
                                                            Rar.UnPackAll(DestDir)
                                                            PassWin = "yes" And FinalPass = PassString

                                                        Catch
                                                        End Try

                                                        'SyncLock (Lock)
                                                        Count += 1
                                                        TbCurAtt.Invoke(New Delegate12(AddressOf UpdateGui), New Object() {PassString})
                                                        'End SyncLock

                                                    Next
                                                Next
                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char13Rar(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters
                                                For Each Ch11 As Char In Characters
                                                    For Each Ch12 As Char In Characters
                                                        For Each Ch13 As Char In Characters

                                                            If PassWin = "yes" Then Exit Sub

                                                            PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11 & Ch12 & Ch13)

                                                            Try

                                                                Dim Rar As New Decompressor(File, PassString)
                                                                Rar.UnPackAll(DestDir)
                                                                PassWin = "yes" And FinalPass = PassString

                                                            Catch
                                                            End Try

                                                            'SyncLock (Lock)
                                                            Count += 1
                                                            TbCurAtt.Invoke(New Delegate13(AddressOf UpdateGui), New Object() {PassString})
                                                            'End SyncLock

                                                        Next
                                                    Next
                                                Next
                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char14Rar(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters
                                                For Each Ch11 As Char In Characters
                                                    For Each Ch12 As Char In Characters
                                                        For Each Ch13 As Char In Characters
                                                            For Each Ch14 As Char In Characters

                                                                If PassWin = "yes" Then Exit Sub

                                                                PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11 & Ch12 & Ch13 & Ch14)

                                                                Try

                                                                    Dim Rar As New Decompressor(File, PassString)
                                                                    Rar.UnPackAll(DestDir)
                                                                    PassWin = "yes" And FinalPass = PassString

                                                                Catch
                                                                End Try

                                                                SyncLock (Lock)
                                                                    Count += 1
                                                                    TbCurAtt.Invoke(New Delegate14(AddressOf UpdateGui), New Object() {PassString})
                                                                End SyncLock

                                                            Next
                                                        Next
                                                    Next
                                                Next
                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char15Rar(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters
                                                For Each Ch11 As Char In Characters
                                                    For Each Ch12 As Char In Characters
                                                        For Each Ch13 As Char In Characters
                                                            For Each Ch14 As Char In Characters
                                                                For Each Ch15 As Char In Characters

                                                                    If PassWin = "yes" Then Exit Sub

                                                                    PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11 & Ch12 & Ch13 & Ch14 & Ch15)
                                                                   
                                                                    Try

                                                                        Dim Rar As New Decompressor(File, PassString)
                                                                        Rar.UnPackAll(DestDir)
                                                                        PassWin = "yes" And FinalPass = PassString

                                                                    Catch
                                                                    End Try

                                                                    SyncLock (Lock)
                                                                        Count += 1
                                                                        TbCurAtt.Invoke(New Delegate15(AddressOf UpdateGui), New Object() {PassString})
                                                                    End SyncLock

                                                                Next
                                                            Next
                                                        Next
                                                    Next
                                                Next
                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char16Rar(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters
                                                For Each Ch11 As Char In Characters
                                                    For Each Ch12 As Char In Characters
                                                        For Each Ch13 As Char In Characters
                                                            For Each Ch14 As Char In Characters
                                                                For Each Ch15 As Char In Characters
                                                                    For Each Ch16 As Char In Characters

                                                                        If PassWin = "yes" Then Exit Sub

                                                                        PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11 & Ch12 & Ch13 & Ch14 & Ch15 & Ch16)
                                                                        PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11 & Ch12 & Ch13 & Ch14 & Ch15 & Ch16)

                                                                        Try

                                                                            Dim Rar As New Decompressor(File, PassString)
                                                                            Rar.UnPackAll(DestDir)
                                                                            PassWin = "yes" And FinalPass = PassString

                                                                        Catch
                                                                        End Try

                                                                        SyncLock (Lock)
                                                                            Count += 1
                                                                            TbCurAtt.Invoke(New Delegate16(AddressOf UpdateGui), New Object() {PassString})
                                                                        End SyncLock

                                                                    Next
                                                                Next
                                                            Next
                                                        Next
                                                    Next
                                                Next
                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char17Rar(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters
                                                For Each Ch11 As Char In Characters
                                                    For Each Ch12 As Char In Characters
                                                        For Each Ch13 As Char In Characters
                                                            For Each Ch14 As Char In Characters
                                                                For Each Ch15 As Char In Characters
                                                                    For Each Ch16 As Char In Characters
                                                                        For Each Ch17 As Char In Characters

                                                                            If PassWin = "yes" Then Exit Sub

                                                                            PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11 & Ch12 & Ch13 & Ch14 & Ch15 & Ch16 & Ch17)
                                                                           
                                                                            Try

                                                                                Dim Rar As New Decompressor(File, PassString)
                                                                                Rar.UnPackAll(DestDir)
                                                                                PassWin = "yes" And FinalPass = PassString

                                                                            Catch
                                                                            End Try

                                                                            SyncLock (Lock)
                                                                                Count += 1
                                                                                TbCurAtt.Invoke(New Delegate17(AddressOf UpdateGui), New Object() {PassString})
                                                                            End SyncLock

                                                                        Next
                                                                    Next
                                                                Next
                                                            Next
                                                        Next
                                                    Next
                                                Next
                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char18Rar(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters
                                                For Each Ch11 As Char In Characters
                                                    For Each Ch12 As Char In Characters
                                                        For Each Ch13 As Char In Characters
                                                            For Each Ch14 As Char In Characters
                                                                For Each Ch15 As Char In Characters
                                                                    For Each Ch16 As Char In Characters
                                                                        For Each Ch17 As Char In Characters
                                                                            For Each Ch18 As Char In Characters

                                                                                If PassWin = "yes" Then Exit Sub

                                                                                PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11 & Ch12 & Ch13 & Ch14 & Ch15 & Ch16 & Ch17 & Ch18)
                                                                                
                                                                                Try

                                                                                    Dim Rar As New Decompressor(File, PassString)
                                                                                    Rar.UnPackAll(DestDir)
                                                                                    PassWin = "yes" And FinalPass = PassString

                                                                                Catch
                                                                                End Try

                                                                                SyncLock (Lock)
                                                                                    Count += 1
                                                                                    TbCurAtt.Invoke(New Delegate18(AddressOf UpdateGui), New Object() {PassString})
                                                                                End SyncLock

                                                                            Next
                                                                        Next
                                                                    Next
                                                                Next
                                                            Next
                                                        Next
                                                    Next
                                                Next
                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char19Rar(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters
                                                For Each Ch11 As Char In Characters
                                                    For Each Ch12 As Char In Characters
                                                        For Each Ch13 As Char In Characters
                                                            For Each Ch14 As Char In Characters
                                                                For Each Ch15 As Char In Characters
                                                                    For Each Ch16 As Char In Characters
                                                                        For Each Ch17 As Char In Characters
                                                                            For Each Ch18 As Char In Characters
                                                                                For Each Ch19 As Char In Characters

                                                                                    If PassWin = "yes" Then Exit Sub

                                                                                    PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11 & Ch12 & Ch13 & Ch14 & Ch15 & Ch16 & Ch17 & Ch18 & Ch19)
                                                                                    
                                                                                    Try

                                                                                        Dim Rar As New Decompressor(File, PassString)
                                                                                        Rar.UnPackAll(DestDir)
                                                                                        PassWin = "yes" And FinalPass = PassString

                                                                                    Catch
                                                                                    End Try

                                                                                    SyncLock (Lock)
                                                                                        Count += 1
                                                                                        TbCurAtt.Invoke(New Delegate19(AddressOf UpdateGui), New Object() {PassString})
                                                                                    End SyncLock

                                                                                Next
                                                                            Next
                                                                        Next
                                                                    Next
                                                                Next
                                                            Next
                                                        Next
                                                    Next
                                                Next
                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char20Rar(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters
                                                For Each Ch11 As Char In Characters
                                                    For Each Ch12 As Char In Characters
                                                        For Each Ch13 As Char In Characters
                                                            For Each Ch14 As Char In Characters
                                                                For Each Ch15 As Char In Characters
                                                                    For Each Ch16 As Char In Characters
                                                                        For Each Ch17 As Char In Characters
                                                                            For Each Ch18 As Char In Characters
                                                                                For Each Ch19 As Char In Characters
                                                                                    For Each Ch20 As Char In Characters

                                                                                        If PassWin = "yes" Then Exit Sub

                                                                                        PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11 & Ch12 & Ch13 & Ch14 & Ch15 & Ch16 & Ch17 & Ch18 & Ch19 & Ch20)

                                                                                        Try

                                                                                            Dim Rar As New Decompressor(File, PassString)
                                                                                            Rar.UnPackAll(DestDir)
                                                                                            PassWin = "yes" And FinalPass = PassString

                                                                                        Catch
                                                                                        End Try

                                                                                        SyncLock (Lock)
                                                                                            Count += 1
                                                                                            TbCurAtt.Invoke(New Delegate20(AddressOf UpdateGui), New Object() {PassString})
                                                                                        End SyncLock

                                                                                    Next
                                                                                Next
                                                                            Next
                                                                        Next
                                                                    Next
                                                                Next
                                                            Next
                                                        Next
                                                    Next
                                                Next
                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char1Zip(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters

            If PassWin = "yes" Then Exit Sub

            Passstring = (Ch1)

            Try

                Dim Zip As New SevenZipExtractor(File, PassString)
                If Zip.Check() Then Zip.BeginExtractArchive(DestDir)
                PassWin = "yes" And FinalPass = Ch1

            Catch
            End Try

            SyncLock (Lock)
                Count += 1
                TbCurAtt.Invoke(New Delegate1(AddressOf UpdateGui), New Object() {PassString})
            End SyncLock

        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char2Zip(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters

                If PassWin = "yes" Then Exit Sub

                PassString = (Ch1 & Ch2)

                Try

                    Dim Zip As New SevenZipExtractor(File, PassString)
                    If Zip.Check() Then Zip.BeginExtractArchive(DestDir)
                    PassWin = "yes" And FinalPass = PassString

                Catch
                End Try

                SyncLock (Lock)
                    Count += 1
                    TbCurAtt.Invoke(New Delegate2(AddressOf UpdateGui), New Object() {PassString})
                End SyncLock

            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char3Zip(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters

                    If PassWin = "yes" Then Exit Sub

                    PassString = (Ch1 & Ch2 & Ch3)

                    Try

                        Dim Zip As New SevenZipExtractor(File, PassString)
                        If Zip.Check() Then Zip.BeginExtractArchive(DestDir)
                        PassWin = "yes" And FinalPass = PassString

                    Catch
                    End Try

                    SyncLock (Lock)
                        Count += 1
                        TbCurAtt.Invoke(New Delegate3(AddressOf UpdateGui), New Object() {PassString})
                    End SyncLock

                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char4Zip(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters

                        If PassWin = "yes" Then Exit Sub

                        PassString = (Ch1 & Ch2 & Ch3 & Ch4)

                        Try

                            Dim Zip As New SevenZipExtractor(File, PassString)
                            If Zip.Check() Then Zip.BeginExtractArchive(DestDir)
                            PassWin = "yes" And FinalPass = PassString

                        Catch
                        End Try

                        SyncLock (Lock)
                            Count += 1
                            TbCurAtt.Invoke(New Delegate4(AddressOf UpdateGui), New Object() {PassString})
                        End SyncLock

                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char5Zip(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters

                            If PassWin = "yes" Then Exit Sub

                            PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5)

                            Try

                                Dim Zip As New SevenZipExtractor(File, PassString)
                                If Zip.Check() Then Zip.BeginExtractArchive(DestDir)
                                PassWin = "yes" And FinalPass = PassString

                            Catch
                            End Try

                            SyncLock (Lock)
                                Count += 1
                                TbCurAtt.Invoke(New Delegate5(AddressOf UpdateGui), New Object() {PassString})
                            End SyncLock

                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char6Zip(ByVal State As Object)


        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters

                                If PassWin = "yes" Then Exit Sub

                                PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6)

                                Try

                                    Dim Zip As New SevenZipExtractor(File, PassString)
                                    If Zip.Check() Then Zip.BeginExtractArchive(DestDir)
                                    PassWin = "yes" And FinalPass = PassString

                                Catch
                                End Try

                                SyncLock (Lock)
                                    Count += 1
                                    TbCurAtt.Invoke(New Delegate6(AddressOf UpdateGui), New Object() {PassString})
                                End SyncLock

                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char7Zip(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters

                                    If PassWin = "yes" Then Exit Sub

                                    PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7)

                                    Try

                                        Dim Zip As New SevenZipExtractor(File, PassString)
                                        If Zip.Check() Then Zip.BeginExtractArchive(DestDir)
                                        PassWin = "yes" And FinalPass = PassString

                                    Catch
                                    End Try

                                    SyncLock (Lock)
                                        Count += 1
                                        TbCurAtt.Invoke(New Delegate7(AddressOf UpdateGui), New Object() {PassString})
                                    End SyncLock

                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char8Zip(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters

                                        If PassWin = "yes" Then Exit Sub

                                        PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8)

                                        Try

                                            Dim Zip As New SevenZipExtractor(File, PassString)
                                            If Zip.Check() Then Zip.BeginExtractArchive(DestDir)
                                            PassWin = "yes" And FinalPass = PassString

                                        Catch
                                        End Try

                                        SyncLock (Lock)
                                            Count += 1
                                            TbCurAtt.Invoke(New Delegate8(AddressOf UpdateGui), New Object() {PassString})
                                        End SyncLock

                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

    End Sub

    Public Sub Char9Zip(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters

                                            If PassWin = "yes" Then Exit Sub

                                            PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9)

                                            Try

                                                Dim Zip As New SevenZipExtractor(File, PassString)
                                                If Zip.Check() Then Zip.BeginExtractArchive(DestDir)
                                                PassWin = "yes" And FinalPass = PassString

                                            Catch
                                            End Try

                                            SyncLock (Lock)
                                                Count += 1
                                                TbCurAtt.Invoke(New Delegate9(AddressOf UpdateGui), New Object() {PassString})
                                            End SyncLock

                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char10Zip(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters

                                                If PassWin = "yes" Then Exit Sub

                                                PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10)

                                                Try

                                                    Dim Zip As New SevenZipExtractor(File, PassString)
                                                    If Zip.Check() Then Zip.BeginExtractArchive(DestDir)
                                                    PassWin = "yes" And FinalPass = PassString

                                                Catch
                                                End Try

                                                SyncLock (Lock)
                                                    Count += 1
                                                    TbCurAtt.Invoke(New Delegate10(AddressOf UpdateGui), New Object() {PassString})
                                                End SyncLock

                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char11Zip(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters
                                                For Each Ch11 As Char In Characters

                                                    If PassWin = "yes" Then Exit Sub

                                                    PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11)

                                                    Try

                                                        Dim Zip As New SevenZipExtractor(File, PassString)
                                                        If Zip.Check() Then Zip.BeginExtractArchive(DestDir)
                                                        PassWin = "yes" And FinalPass = PassString

                                                    Catch
                                                    End Try

                                                    SyncLock (Lock)
                                                        Count += 1
                                                        TbCurAtt.Invoke(New Delegate11(AddressOf UpdateGui), New Object() {PassString})
                                                    End SyncLock

                                                Next
                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char12Zip(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters
                                                For Each Ch11 As Char In Characters
                                                    For Each Ch12 As Char In Characters

                                                        If PassWin = "yes" Then Exit Sub

                                                        PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11 & Ch12)

                                                        Try

                                                            Dim Zip As New SevenZipExtractor(File, PassString)
                                                            If Zip.Check() Then Zip.BeginExtractArchive(DestDir)
                                                            PassWin = "yes" And FinalPass = PassString

                                                        Catch
                                                        End Try

                                                        SyncLock (Lock)
                                                            Count += 1
                                                            TbCurAtt.Invoke(New Delegate12(AddressOf UpdateGui), New Object() {PassString})
                                                        End SyncLock

                                                    Next
                                                Next
                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char13Zip(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters
                                                For Each Ch11 As Char In Characters
                                                    For Each Ch12 As Char In Characters
                                                        For Each Ch13 As Char In Characters

                                                            If PassWin = "yes" Then Exit Sub

                                                            PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11 & Ch12 & Ch13)

                                                            Try

                                                                Dim Zip As New SevenZipExtractor(File, PassString)
                                                                If Zip.Check() Then Zip.BeginExtractArchive(DestDir)
                                                                PassWin = "yes" And FinalPass = PassString

                                                            Catch
                                                            End Try

                                                            SyncLock (Lock)
                                                                Count += 1
                                                                TbCurAtt.Invoke(New Delegate13(AddressOf UpdateGui), New Object() {PassString})
                                                            End SyncLock

                                                        Next
                                                    Next
                                                Next
                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char14Zip(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters
                                                For Each Ch11 As Char In Characters
                                                    For Each Ch12 As Char In Characters
                                                        For Each Ch13 As Char In Characters
                                                            For Each Ch14 As Char In Characters

                                                                If PassWin = "yes" Then Exit Sub

                                                                PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11 & Ch12 & Ch13 & Ch14)

                                                                Try

                                                                    Dim Zip As New SevenZipExtractor(File, PassString)
                                                                    If Zip.Check() Then Zip.BeginExtractArchive(DestDir)
                                                                    PassWin = "yes"
                                                                    FinalPass = PassString

                                                                Catch
                                                                End Try

                                                                SyncLock (Lock)
                                                                    Count += 1
                                                                    TbCurAtt.Invoke(New Delegate14(AddressOf UpdateGui), New Object() {PassString})
                                                                End SyncLock

                                                            Next
                                                        Next
                                                    Next
                                                Next
                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char15Zip(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters
                                                For Each Ch11 As Char In Characters
                                                    For Each Ch12 As Char In Characters
                                                        For Each Ch13 As Char In Characters
                                                            For Each Ch14 As Char In Characters
                                                                For Each Ch15 As Char In Characters

                                                                    If PassWin = "yes" Then Exit Sub

                                                                    PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11 & Ch12 & Ch13 & Ch14 & Ch15)

                                                                    Try

                                                                        Dim Zip As New SevenZipExtractor(File, PassString)
                                                                        If Zip.Check() Then Zip.BeginExtractArchive(DestDir)
                                                                        PassWin = "yes"
                                                                        FinalPass = PassString

                                                                    Catch
                                                                    End Try

                                                                    SyncLock (Lock)
                                                                        Count += 1
                                                                        TbCurAtt.Invoke(New Delegate15(AddressOf UpdateGui), New Object() {PassString})
                                                                    End SyncLock

                                                                Next
                                                            Next
                                                        Next
                                                    Next
                                                Next
                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char16Zip(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters
                                                For Each Ch11 As Char In Characters
                                                    For Each Ch12 As Char In Characters
                                                        For Each Ch13 As Char In Characters
                                                            For Each Ch14 As Char In Characters
                                                                For Each Ch15 As Char In Characters
                                                                    For Each Ch16 As Char In Characters

                                                                        If PassWin = "yes" Then Exit Sub

                                                                        PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11 & Ch12 & Ch13 & Ch14 & Ch15 & Ch16)

                                                                        Try

                                                                            Dim Zip As New SevenZipExtractor(File, PassString)
                                                                            If Zip.Check() Then Zip.BeginExtractArchive(DestDir)
                                                                            PassWin = "yes" And FinalPass = PassString

                                                                        Catch
                                                                        End Try

                                                                        SyncLock (Lock)
                                                                            Count += 1
                                                                            TbCurAtt.Invoke(New Delegate16(AddressOf UpdateGui), New Object() {PassString})
                                                                        End SyncLock

                                                                    Next
                                                                Next
                                                            Next
                                                        Next
                                                    Next
                                                Next
                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char17Zip(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters
                                                For Each Ch11 As Char In Characters
                                                    For Each Ch12 As Char In Characters
                                                        For Each Ch13 As Char In Characters
                                                            For Each Ch14 As Char In Characters
                                                                For Each Ch15 As Char In Characters
                                                                    For Each Ch16 As Char In Characters
                                                                        For Each Ch17 As Char In Characters

                                                                            If PassWin = "yes" Then Exit Sub

                                                                            PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11 & Ch12 & Ch13 & Ch14 & Ch15 & Ch16 & Ch17)

                                                                            Try
                                                                                Dim Zip As New SevenZipExtractor(File, PassString)
                                                                                If Zip.Check() Then Zip.BeginExtractArchive(DestDir)
                                                                                PassWin = "yes" And FinalPass = PassString

                                                                            Catch
                                                                            End Try

                                                                            SyncLock (Lock)
                                                                                Count += 1
                                                                                TbCurAtt.Invoke(New Delegate17(AddressOf UpdateGui), New Object() {PassString})
                                                                            End SyncLock

                                                                        Next
                                                                    Next
                                                                Next
                                                            Next
                                                        Next
                                                    Next
                                                Next
                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char18Zip(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters
                                                For Each Ch11 As Char In Characters
                                                    For Each Ch12 As Char In Characters
                                                        For Each Ch13 As Char In Characters
                                                            For Each Ch14 As Char In Characters
                                                                For Each Ch15 As Char In Characters
                                                                    For Each Ch16 As Char In Characters
                                                                        For Each Ch17 As Char In Characters
                                                                            For Each Ch18 As Char In Characters

                                                                                If PassWin = "yes" Then Exit Sub

                                                                                PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11 & Ch12 & Ch13 & Ch14 & Ch15 & Ch16 & Ch17 & Ch18)

                                                                                Try

                                                                                    Dim Zip As New SevenZipExtractor(File, PassString)
                                                                                    If Zip.Check() Then Zip.BeginExtractArchive(DestDir)
                                                                                    PassWin = "yes" And FinalPass = PassString

                                                                                Catch
                                                                                End Try

                                                                                SyncLock (Lock)
                                                                                    Count += 1
                                                                                    TbCurAtt.Invoke(New Delegate18(AddressOf UpdateGui), New Object() {PassString})
                                                                                End SyncLock

                                                                            Next
                                                                        Next
                                                                    Next
                                                                Next
                                                            Next
                                                        Next
                                                    Next
                                                Next
                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char19Zip(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters
                                                For Each Ch11 As Char In Characters
                                                    For Each Ch12 As Char In Characters
                                                        For Each Ch13 As Char In Characters
                                                            For Each Ch14 As Char In Characters
                                                                For Each Ch15 As Char In Characters
                                                                    For Each Ch16 As Char In Characters
                                                                        For Each Ch17 As Char In Characters
                                                                            For Each Ch18 As Char In Characters
                                                                                For Each Ch19 As Char In Characters

                                                                                    If PassWin = "yes" Then Exit Sub

                                                                                    PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11 & Ch12 & Ch13 & Ch14 & Ch15 & Ch16 & Ch17 & Ch18 & Ch19)

                                                                                    Try

                                                                                        Dim Zip As New SevenZipExtractor(File, PassString)
                                                                                        If Zip.Check() Then Zip.BeginExtractArchive(DestDir)
                                                                                        PassWin = "yes" And FinalPass = PassString

                                                                                    Catch
                                                                                    End Try

                                                                                    SyncLock (Lock)
                                                                                        Count += 1
                                                                                        TbCurAtt.Invoke(New Delegate19(AddressOf UpdateGui), New Object() {PassString})
                                                                                    End SyncLock

                                                                                Next
                                                                            Next
                                                                        Next
                                                                    Next
                                                                Next
                                                            Next
                                                        Next
                                                    Next
                                                Next
                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub Char20Zip(ByVal State As Object)

        Dim PassString As String

        For Each Ch1 As Char In Characters
            For Each Ch2 As Char In Characters
                For Each Ch3 As Char In Characters
                    For Each Ch4 As Char In Characters
                        For Each Ch5 As Char In Characters
                            For Each Ch6 As Char In Characters
                                For Each Ch7 As Char In Characters
                                    For Each Ch8 As Char In Characters
                                        For Each Ch9 As Char In Characters
                                            For Each Ch10 As Char In Characters
                                                For Each Ch11 As Char In Characters
                                                    For Each Ch12 As Char In Characters
                                                        For Each Ch13 As Char In Characters
                                                            For Each Ch14 As Char In Characters
                                                                For Each Ch15 As Char In Characters
                                                                    For Each Ch16 As Char In Characters
                                                                        For Each Ch17 As Char In Characters
                                                                            For Each Ch18 As Char In Characters
                                                                                For Each Ch19 As Char In Characters
                                                                                    For Each Ch20 As Char In Characters

                                                                                        If PassWin = "yes" Then Exit Sub

                                                                                        PassString = (Ch1 & Ch2 & Ch3 & Ch4 & Ch5 & Ch6 & Ch7 & Ch8 & Ch9 & Ch10 & Ch11 & Ch12 & Ch13 & Ch14 & Ch15 & Ch16 & Ch17 & Ch18 & Ch19 & Ch20)

                                                                                        Try

                                                                                            Dim Zip As New SevenZipExtractor(File, PassString)
                                                                                            If Zip.Check() Then Zip.BeginExtractArchive(DestDir)
                                                                                            PassWin = "yes" And FinalPass = PassString

                                                                                        Catch
                                                                                        End Try

                                                                                        SyncLock (Lock)
                                                                                            Count += 1
                                                                                            TbCurAtt.Invoke(New Delegate20(AddressOf UpdateGui), New Object() {PassString})
                                                                                        End SyncLock

                                                                                    Next
                                                                                Next
                                                                            Next
                                                                        Next
                                                                    Next
                                                                Next
                                                            Next
                                                        Next
                                                    Next
                                                Next
                                            Next
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        CType(State, AutoResetEvent).Set()

    End Sub

    Public Sub UpdateGui(PassString As Object)

        Times = (StopW.Elapsed.TotalSeconds)

        TbCurAtt.Text = PassString

        TbToAtt.Text = Count

        TbAttPs.Text = Format((Count / Times), "###.0")

        TbTime.Text = (StopW.Elapsed.Hours & ":" & StopW.Elapsed.Minutes & ":" & StopW.Elapsed.Seconds)

        If PassWin = "yes" Then
            StopW.Stop()
            TbCurAtt.Text = FinalPass
            MessageBox.Show("Password is: " & FinalPass & "Time taken: " & TbTime.Text)
        End If

        Me.Refresh()

        Application.DoEvents()

    End Sub

End Class

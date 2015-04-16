Imports System.IO

Public Class Form1
    Public SETS As New Dictionary(Of String, String)

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadSets()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'choose file to convert
        'must be csv, and contain as first line : 
        'Total Qty,Reg Qty,Foil Qty,Card,Set,Mana Cost,Card Type,Color,Rarity,Mvid,Single Price,Single Foil Price,Total Price,Price Source,Notes
        '
        '
        Dim OFD As New OpenFileDialog
        TextBox1.Text = ""

        'Supposing you haven't already set these properties...
        With OFD
            .FileName = ""
            .Title = "Open a CSV file..."
            .InitialDirectory = "C:\"
            .Filter = "DeckedBuilder Collection|*.csv"
        End With

        If OFD.ShowDialog() = DialogResult.OK Then
            TextBox1.Text = "Converting : " & OFD.FileName

            If ConvertFile(OFD.FileName) = True Then
                TextBox1.Text = TextBox1.Text & vbCrLf & "Convertion : OK"
            Else
                TextBox1.Text = TextBox1.Text & vbCrLf & "Convertion : ended in error"
            End If
        End If
    End Sub

    Private Function ConvertFile(ByVal FilePathToConvert As String) As Boolean
        Dim ret As Boolean = True
        'must be csv, and contain as first line : 
        'Total Qty,Reg Qty,Foil Qty,Card,Set,Mana Cost,Card Type,Color,Rarity,Mvid,Single Price,Single Foil Price,Total Price,Price Source,Notes


        Using r As StreamReader = New StreamReader(FilePathToConvert)
            Dim line As String

            ' Read first line.
            line = r.ReadLine

            'Checking if file is valid
            If line = "Total Qty,Reg Qty,Foil Qty,Card,Set,Mana Cost,Card Type,Color,Rarity,Mvid,Single Price,Single Foil Price,Total Price,Price Source,Notes" Then
                TextBox1.Text = TextBox1.Text & vbCrLf & "File has been detected as a valid DeckedBuilder file"
            Else
                TextBox1.Text = TextBox1.Text & vbCrLf & "ABORD : File has been detected as an invalid DeckedBuilder file !"
                Return False
            End If

            Dim vFullPath As String = Path.GetFullPath(FilePathToConvert)
            Dim vCurrDir As String = Path.GetDirectoryName(FilePathToConvert)
            Dim vExt As String = Path.GetExtension(FilePathToConvert)
            Dim vName As String = Path.GetFileNameWithoutExtension(FilePathToConvert)

            Dim FileNameOUT As String = vCurrDir & vName & "_CONVERTED" & vExt
            If File.Exists(FileNameOUT) Then
                Kill(FileNameOUT)
                Application.DoEvents()
            End If
            TextBox1.Text = TextBox1.Text & vbCrLf & "Generated file is : " & FileNameOUT

            Dim fileOut As System.IO.StreamWriter

            fileOut = My.Computer.FileSystem.OpenTextFileWriter(FileNameOUT, True)
            fileOut.WriteLine("Name,Set,Qty,Foil,Price,Condition,Notes")

            ' Loop over each line in file, While list is Not Nothing.
            Dim FicLines As Integer = 0
            Dim NumCards As Integer = 0

            Do While (Not line Is Nothing)
                'Total Qty,Reg Qty,Foil Qty,Card,Set,Mana Cost,Card Type,Color,Rarity,Mvid,Single Price,Single Foil Price,Total Price,Price Source,Notes
                line = r.ReadLine
                If line = Nothing Then
                    Exit Do
                End If
                FicLines = FicLines + 1
                Dim vEntries As String()

                If line.Split(",")(3).Contains("""") Then
                    Dim vtmp As String() = line.Split("""")

                    Try
                        Dim vcCardName As String = vtmp(1)
                        Dim vcSET As String = vtmp(2).Split(",")(1)
                        Dim vcSETItem As String = ""
                        ' See if this key exists.
                        If SETS.ContainsKey(vcSET) Then
                            ' Write value of the key.
                            vcSETItem = Trim(SETS.Item(vcSET))
                        Else
                            vcSETItem = "TO_CONVERT=" & vcSET
                        End If
                        Dim vcQTY As String = vtmp(0).Split(",")(0)
                        NumCards = NumCards + CInt(vcQTY)

                        vcCardName = CardFiltering(vcCardName)

                        fileOut.WriteLine("""" & vcCardName & """," & vcSETItem & "," & vcQTY & ",n,,,")
                    Catch ex As Exception
                        ret = False
                        TextBox1.Text = TextBox1.Text & vbCrLf & "Error : " & ex.Message.ToString
                    End Try

                Else
                    vEntries = line.Split(",")
                    Try
                        Dim vcCardName As String = vEntries(3)
                        Dim vcSET As String = vEntries(4)
                        Dim vcSETItem As String = ""
                        Dim vcQTY As String = vEntries(0)

                        NumCards = NumCards + CInt(vcQTY)
                        ' See if this key exists.
                        If SETS.ContainsKey(vcSET) Then
                            ' Write value of the key.
                            vcSETItem = Trim(SETS.Item(vcSET))
                        Else
                            vcSETItem = "TO_CONVERT=" & vcSET
                        End If

                        vcCardName = CardFiltering(vcCardName)

                        fileOut.WriteLine(vcCardName & "," & vcSETItem & "," & vcQTY & ",n,,,")
                    Catch ex As Exception
                        ret = False
                        TextBox1.Text = TextBox1.Text & vbCrLf & "Error : " & ex.Message.ToString
                    End Try
                End If
            Loop
            fileOut.Close()
            TextBox1.Text = TextBox1.Text & vbCrLf & "Processed " & FicLines.ToString & " lines for a total of " & NumCards.ToString & " cards." & vbCrLf
        End Using

        Return ret
    End Function

    Private Sub LoadSets()
        If File.Exists(Environment.CurrentDirectory & "\SETS.txt") = False Then
            System.IO.File.WriteAllText(Environment.CurrentDirectory & "\SETS.txt", My.Resources.SETS)
        End If

        Using r As StreamReader = New StreamReader(Environment.CurrentDirectory & "\SETS.txt")
            'Using r As StreamReader = New StreamReader(My.Resources.SETS)
            Dim line As String

            ' Read first line.
            line = r.ReadLine
            Dim vEntries As String()
            vEntries = line.Split(",")

            SETS.Add(vEntries(0), vEntries(1))

            Do While (Not line Is Nothing)
                line = r.ReadLine
                If line = Nothing Then
                    Exit Do
                End If
                vEntries = line.Split(",")
                SETS.Add(vEntries(0), vEntries(1))
            Loop
        End Using
    End Sub

    Private Function CardFiltering(ByVal CardName As String) As String
        Dim vCReturn As String = CardName
        'basic filtering
        If CardName.Contains(" // ") Then
            vCReturn = CardName.Replace(" // ", "/")
        End If

        If CardName.Contains("Æ") Then
            vCReturn = CardName.Replace("Æ", "AE")
        End If

        If CardName.Contains("æ") Then
            vCReturn = CardName.Replace("æ", "ae")
        End If

        Return vCReturn
    End Function
End Class

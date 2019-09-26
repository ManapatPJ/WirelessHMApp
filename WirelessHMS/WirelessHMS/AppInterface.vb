Imports System.Globalization
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class AppInterface

    Dim settings_path As String = Application.StartupPath & "\settings.txt"

    Dim rec_table As New DataTable

    Public Shared temp As String
    Public Shared pulse As String
    Public Shared bp As String
    Public Shared interval As String


    Dim alarm As Boolean = False
    Sub initialize()
        alarm = False
        btn_alarm.BackColor = Color.Red
        StreamReader()

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initialize()
        rec_table.Columns.Add("Date")
        rec_table.Columns.Add("Temperature")
        rec_table.Columns.Add("Pulse")
        rec_table.Columns.Add("Blood Pressure")
        btn_check.PerformClick()

    End Sub

    Private Sub bgw_startup_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_startup.DoWork
        Try
            rec_table.Rows.Clear()
        Catch ex As Exception
        End Try

        Try
            dg_record.Rows.Clear()
        Catch ex As Exception
        End Try

        Try
            Dim request As HttpWebRequest
            Dim response As HttpWebResponse = Nothing
            Dim reader As StreamReader
            request = DirectCast(WebRequest.Create("https://api.thingspeak.com/channels/854022/feeds.json?api_key=C6NHZYKLM4KBEE9V&results=100"), HttpWebRequest)
            response = DirectCast(request.GetResponse(), HttpWebResponse)
            reader = New StreamReader(response.GetResponseStream())
            Dim rawresp As String
            rawresp = reader.ReadToEnd()

            Dim json As JObject
            json = JObject.Parse(rawresp)

            Dim txt As String()
            txt = Split(json("feeds").ToString, "{")

            Dim txt2 As String()
            For i As Integer = 1 To UBound(txt)
                txt2 = Split(txt(i), "}")




                Dim data As String
                data = txt2(0)

                Dim dateArray As String()

                Dim dateTimeMe As String = ""
                dateArray = Split(data, "created_at")
                dateTimeMe = dateArray(1).Substring(4, 20).Replace("T", " ").Replace("Z", " ")

                Dim final As String()
                'MsgBox(txt2(0).Replace("field", "").Replace("" & ControlChars.Quote & "", "").Replace(" ", ""))
                final = Split(txt2(0).Replace("field", "").Replace("" & ControlChars.Quote & "", "").Replace(" ", ""), vbNewLine)

                If final(5).Replace(",", "").Remove(0, 2) = "0" Then

                Else
                    Dim dateMe As String = ""
                    Dim timeMe As String = ""

                    Dim spl() As String
                    spl = Split(dateTimeMe, " ")
                    dateMe = spl(0)
                    timeMe = spl(1)

                    Dim iString As String = dateMe & " " & timeMe
                    Dim oDate As DateTime = DateTime.Parse(iString)
                    'MsgBox(oDate.ToString())

                    rec_table.Rows.Add(oDate.AddHours(8),
                                   final(3).Replace(",", "").Remove(0, 2),
                                   final(4).Replace(",", "").Remove(0, 2),
                                   final(5).Replace(",", "").Remove(0, 2))
                End If

            Next


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Public Function MatchCultures(ByVal str As String) As List(Of String)

        Dim ValidCultures As New List(Of String)

        Dim CultureNames As IEnumerable(Of String) =
        From cultureInfo In CultureInfo.GetCultures(CultureTypes.AllCultures)
        Select cultureInfo.Name

        For Each CultureName As String In CultureNames

            Try

                Convert.ToSingle(str, New CultureInfo(CultureName))
                ValidCultures.Add(CultureName)

            Catch ex As FormatException
                ' Do nothing

            End Try

        Next

        Return ValidCultures

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_check.Click
        bgw_startup.RunWorkerAsync()
        btn_check.Enabled = False
    End Sub

    Private Sub Bgw_startup_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_startup.RunWorkerCompleted
        dg_record.DataSource = rec_table
        dg_record.Update()
        btn_check.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btn_settings.Click
        Dim form As New settings
        form.ShowDialog()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btn_alarm.Click
        If alarm = False Then
            alarm = True
            btn_alarm.BackColor = Color.Green
        Else
            alarm = False
            btn_alarm.BackColor = Color.Red
        End If

        For i As Integer = 0 To dg_record.Rows.Count - 1
            For j As Integer = 0 To dg_record.Columns.Count - 1
                Select Case j
                    Case 1
                        If Double.Parse(dg_record.Rows(i).Cells(j).Value) > Double.Parse(temp) Then
                            dg_record.Rows(i).Cells(j).Style.BackColor = Color.Red
                        End If
                    Case 2
                        If Double.Parse(dg_record.Rows(i).Cells(j).Value) > Double.Parse(pulse) Then
                            dg_record.Rows(i).Cells(j).Style.BackColor = Color.Red
                        End If
                    Case 3
                        Dim spl() As String
                        spl = Split(dg_record.Rows(i).Cells(j).Value, "/")
                        Dim spl2() As String
                        spl2 = Split(bp, "/")
                        If Double.Parse(spl(1)) > Double.Parse(spl2(1)) Then
                            dg_record.Rows(i).Cells(j).Style.BackColor = Color.Red
                        End If
                End Select



            Next
        Next
    End Sub

    Private Sub Btn_about_Click(sender As Object, e As EventArgs) Handles btn_about.Click
        Dim abt As New About
        abt.ShowDialog()
    End Sub

    Sub StreamReader()
        RichTextBox1.Clear()
        ' We need to read into this List.
        Dim list As New List(Of String)

        ' Open file.txt with the Using statement.
        Using r As StreamReader = New StreamReader(settings_path)
            ' Store contents in this String.
            Dim line As String

            ' Read first line.
            line = r.ReadLine

            ' Loop over each line in file, While list is Not Nothing.
            Do While (Not line Is Nothing)
                Dim str() As String
                str = Split(line, ":")
                If str(0) = "temp" Then
                    temp = str(1)
                ElseIf str(0) = "pulse" Then
                    pulse = str(1)
                ElseIf str(0) = "bp" Then
                    bp = str(1)
                ElseIf str(0) = "interval" Then
                    interval = str(1)
                End If

                RichTextBox1.Text = RichTextBox1.Text & line & vbNewLine

                ' Add this line to list.
                list.Add(line)
                ' Display to console.
                Console.WriteLine(line)
                ' Read in the next line.
                line = r.ReadLine
            Loop
        End Using

    End Sub

End Class

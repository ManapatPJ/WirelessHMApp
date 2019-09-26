Public Class settings

    Dim settings_path As String = Application.StartupPath & "\settings.txt"

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbox_bp.Text = AppInterface.bp
        tbox_pulse.Text = AppInterface.pulse
        tbox_temp.Text = AppInterface.temp
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        System.IO.File.WriteAllText(settings_path, "")
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(settings_path, True)
        file.WriteLine("temp:" & tbox_temp.Text & vbLf)
        file.WriteLine("pulse:" & tbox_pulse.Text & vbLf)
        file.WriteLine("bp:" & tbox_bp.Text & vbLf)
        file.Close()
    End Sub
End Class
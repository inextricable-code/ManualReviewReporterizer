Public Class Form_Settings
    Private Sub Form_Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BringToFront()
        TextBox_Company_Name.Text = My.Settings.company_name
    End Sub

    Private Sub Button_Go_Click(sender As Object, e As EventArgs) Handles Button_Go.Click
        My.Settings.company_name = TextBox_Company_Name.Text
        My.Settings.Save()
        MsgBox("Settings saved ok")
        Me.Close()
    End Sub
End Class
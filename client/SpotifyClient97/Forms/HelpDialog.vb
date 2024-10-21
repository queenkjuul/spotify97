Imports System.Windows.Forms

Public Class HelpDialog
    Private Sub HelpDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TabPage1.Text = "General"
        Me.TextBox1.Text = UiStrings.helpText1
        Me.TabPage2.Text = "Devices"
        Me.TextBox2.Text = UiStrings.helpText2
        Me.TextBox3.Text = UiStrings.helpText3
        Me.TabPage3.Text = "Playback"
        Me.TextBox4.Text = UiStrings.helpText4
        Me.TextBox5.Text = UiStrings.helpText5
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class

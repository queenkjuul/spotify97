Public Class SettingsForm

    Private Sub SettingsCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsCancelButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub SettingsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ServerURLSettingsTextBox.Focus()
        Me.ServerURLSettingsTextBox.Select()
    End Sub
End Class
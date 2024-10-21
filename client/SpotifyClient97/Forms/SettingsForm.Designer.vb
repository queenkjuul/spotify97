<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsForm))
        Me.ServerURLTooltip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ServerURLSettingsLabel = New System.Windows.Forms.Label
        Me.ServerURLSettingsTextBox = New System.Windows.Forms.TextBox
        Me.SaveButton = New System.Windows.Forms.Button
        Me.SettingsCancelButton = New System.Windows.Forms.Button
        Me.SettingsInfoGroupBox = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.MySettingsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SettingsInfoGroupBox.SuspendLayout()
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ServerURLTooltip
        '
        Me.ServerURLTooltip.IsBalloon = True
        '
        'ServerURLSettingsLabel
        '
        Me.ServerURLSettingsLabel.AutoSize = True
        Me.ServerURLSettingsLabel.Location = New System.Drawing.Point(12, 9)
        Me.ServerURLSettingsLabel.Name = "ServerURLSettingsLabel"
        Me.ServerURLSettingsLabel.Size = New System.Drawing.Size(82, 17)
        Me.ServerURLSettingsLabel.TabIndex = 5
        Me.ServerURLSettingsLabel.Text = "Server URL"
        Me.ServerURLTooltip.SetToolTip(Me.ServerURLSettingsLabel, "URL of the Spotify Client Relay Server (including port, e.g. http://192.168.1.29:" & _
                "3000)")
        '
        'ServerURLSettingsTextBox
        '
        Me.ServerURLSettingsTextBox.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.ServerURLSettingsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.SpotifyClient97.My.MySettings.Default, "ServerURL", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ServerURLSettingsTextBox.Location = New System.Drawing.Point(100, 6)
        Me.ServerURLSettingsTextBox.Name = "ServerURLSettingsTextBox"
        Me.ServerURLSettingsTextBox.Size = New System.Drawing.Size(217, 22)
        Me.ServerURLSettingsTextBox.TabIndex = 6
        Me.ServerURLSettingsTextBox.Text = Global.SpotifyClient97.My.MySettings.Default.ServerURL
        Me.ServerURLTooltip.SetToolTip(Me.ServerURLSettingsTextBox, "URL of the Spotify Client Relay Server (including protocol and port e.g. http://1" & _
                "92.168.1.29:3000)")
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(514, 237)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(75, 31)
        Me.SaveButton.TabIndex = 3
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'SettingsCancelButton
        '
        Me.SettingsCancelButton.Location = New System.Drawing.Point(433, 237)
        Me.SettingsCancelButton.Name = "SettingsCancelButton"
        Me.SettingsCancelButton.Size = New System.Drawing.Size(75, 31)
        Me.SettingsCancelButton.TabIndex = 4
        Me.SettingsCancelButton.Text = "Cancel"
        Me.SettingsCancelButton.UseVisualStyleBackColor = True
        '
        'SettingsInfoGroupBox
        '
        Me.SettingsInfoGroupBox.Controls.Add(Me.Label1)
        Me.SettingsInfoGroupBox.Location = New System.Drawing.Point(15, 34)
        Me.SettingsInfoGroupBox.Name = "SettingsInfoGroupBox"
        Me.SettingsInfoGroupBox.Size = New System.Drawing.Size(574, 185)
        Me.SettingsInfoGroupBox.TabIndex = 7
        Me.SettingsInfoGroupBox.TabStop = False
        Me.SettingsInfoGroupBox.Text = "Information"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(552, 136)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'MySettingsBindingSource
        '
        Me.MySettingsBindingSource.DataMember = Global.SpotifyClient97.My.MySettings.Default.ServerURL
        '
        'SettingsForm
        '
        Me.AcceptButton = Me.SaveButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(608, 280)
        Me.Controls.Add(Me.SettingsInfoGroupBox)
        Me.Controls.Add(Me.ServerURLSettingsTextBox)
        Me.Controls.Add(Me.ServerURLSettingsLabel)
        Me.Controls.Add(Me.SettingsCancelButton)
        Me.Controls.Add(Me.SaveButton)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SettingsForm"
        Me.Text = "Settings"
        Me.SettingsInfoGroupBox.ResumeLayout(False)
        Me.SettingsInfoGroupBox.PerformLayout()
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ServerURLTooltip As System.Windows.Forms.ToolTip
    Friend WithEvents MySettingsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SaveButton As System.Windows.Forms.Button
    Friend WithEvents SettingsCancelButton As System.Windows.Forms.Button
    Friend WithEvents ServerURLSettingsLabel As System.Windows.Forms.Label
    Friend WithEvents ServerURLSettingsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SettingsInfoGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

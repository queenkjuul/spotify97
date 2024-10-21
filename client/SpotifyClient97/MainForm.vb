Public Class MainForm
    Private controller As SpotifyController = New SpotifyController()
    Private appState As ApplicationState = controller.appState
    Private playbackState As PlaybackState = controller.playbackState
    Private connStatusDict As Dictionary(Of ConnStatus, String) = UiStrings.getConnStatusDict()
    Private playStatusDict As Dictionary(Of Boolean, String) = UiStrings.getPlayStatusDict()
    Private ticksSinceLastSync As Int16 = 0

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Bind app state object to form for reactive UI
        Me.AppStateBindingSource.Add(appState)
        Me.PlaybackStateBindingSource.Add(playbackState)

        If My.Settings.PrevDeviceId.Equals("") Then
        Else
            Me.playbackState.currentDevice = New Device(My.Settings.PrevDeviceName, My.Settings.PrevDeviceId)
        End If

        Me.appState.connStatus = ConnStatus.connecting

        refreshState()

        Me.StatusSyncTimer.Enabled = True

    End Sub

    Private Sub refreshState(Optional ByVal getArt = True)
        If My.Settings.ServerURL.Equals("") Then
            Return
        End If

        Me.Cursor = Cursors.WaitCursor

        Dim queueIndex = Me.QueueDataGridView.FirstDisplayedScrollingRowIndex
        Try
            Me.controller.connect()
            Me.controller.getDeviceList()
            Me.controller.getPlaybackState()
            If Me.playbackState IsNot Nothing And Me.playbackState.nowPlaying IsNot Nothing Then
                If getArt Or Me.appState.albumArt Is Nothing Then
                    Me.controller.getAlbumArt()
                End If
            End If
            Me.controller.getQueue()
        Catch ex As Exception
            Me.appState.lastServerMessage = ex.Message
        End Try

        Me.Cursor = Cursors.Default

        If queueIndex > -1 AndAlso queueIndex IsNot Nothing AndAlso queueIndex < Me.QueueDataGridView.RowCount Then Me.QueueDataGridView.FirstDisplayedScrollingRowIndex = queueIndex
    End Sub


    Private Sub StatusUpdateTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusUpdateTimer.Tick
        'Annoyingly, StatusLabel can't be data-bound like a normal label, so we poll
        Me.ConnStatusLabel.Text = Me.connStatusDict.Item(appState.connStatus)
        Me.PlayStatusLabel.Text = Me.playStatusDict.Item(playbackState.playing)
        Me.LastServerMessageLabel.Text = UiStrings.lastServerResponse + appState.lastServerMessage
        If Me.playbackState.playing Then
            Me.PlayPauseButton.Image = My.Resources.pause
        Else
            Me.PlayPauseButton.Image = My.Resources.play
        End If
        If Me.playbackState.repeatState.Equals(RepeatState.context) Then
            Me.RepeatAllRadioButton.Checked = True
        ElseIf playbackState.repeatState.Equals(RepeatState.track) Then
            Me.RepeatOneRadioButton.Checked = True
        Else
            Me.RepeatOffRadioButton.Checked = True
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim about = New AboutBox1
        about.Show()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim settings = New SettingsForm
        settings.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub PrevButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrevButton.Click
        controller.prevTrack()
        wait()
        refreshState()
    End Sub

    Private Sub NextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextButton.Click
        controller.nextTrack()
        wait()
        refreshState()
    End Sub

    Private Sub PlayPauseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayPauseButton.Click
        If Not Me.playbackState.playing Then
            Me.PlayPauseButton.Image = My.Resources.pause
        Else
            Me.PlayPauseButton.Image = My.Resources.play
        End If
        controller.playPause()
        refreshState(False)
    End Sub

    Private Sub PlaybackProgressTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlaybackProgressTimer.Tick
        If Me.playbackState Is Nothing Or Me.playbackState.nowPlaying Is Nothing Then
            Return
        End If

        Dim duration = Me.playbackState.nowPlaying.Duration
        Dim durationMinutes As Int16 = Math.Floor(duration / 60)
        Dim durationSeconds As Int16 = duration Mod 60
        DurationLabel.Text = durationMinutes.ToString() + ":" + durationSeconds.ToString().PadLeft(2, "0")

        Dim progress = Me.playbackState.progress
        Dim progressMinutes As Int16 = Math.Floor(progress / 60)
        Dim progressSeconds As Int16 = progress Mod 60
        ProgressLabel.Text = progressMinutes.ToString() + ":" + progressSeconds.ToString().PadLeft(2, "0")

        Dim remainingTime As Int16 = Me.playbackState.nowPlaying.Duration - Me.playbackState.progress
        Dim remainingMinutes As Int16 = Math.Floor(remainingTime / 60)
        Dim remainingSeconds As Int16 = remainingTime Mod 60
        RemainingTimeLabel.Text = "-" + remainingMinutes.ToString() + ":" + remainingSeconds.ToString().PadLeft(2, "0")

        If progress > duration Then
            ProgressBar1.Value = 100
        ElseIf duration > 1 And progress > 1 Then
            ProgressBar1.Value = progress / duration * 100
        Else
            ProgressBar1.Value = 0
        End If

        If playbackState.playing Then
            playbackState.progress = playbackState.progress + 1
        End If

        If playbackState.progress > duration Then
            refreshState()
        End If
    End Sub


    Private Sub ProgressBar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgressBar1.Click
        Dim e2 As System.Windows.Forms.MouseEventArgs = e
        Dim x As Int16 = e2.X
        Dim width As Int16 = ProgressBar1.Width
        Dim percentage As Double = x / width
        Dim seekPosition As Int16 = Math.Floor(Me.playbackState.nowPlaying.Duration * percentage)
        controller.seek(seekPosition)
    End Sub

    Private Sub StatusSyncTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusSyncTimer.Tick
        'Every ten seconds, we double check that we're still connected and in sync, but only while playing
        'Check every 30 seconds otherwise
        Me.ticksSinceLastSync = Me.ticksSinceLastSync + 1
        If Me.playbackState.playing Or Me.ticksSinceLastSync > 2 Then
            refreshState()
            Me.ticksSinceLastSync = 0
        End If
    End Sub

    Private Sub QueueDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles QueueDataGridView.CellDoubleClick
        If e.RowIndex > -1 Then
            controller.playItem(Me.appState.queue.Item(e.RowIndex).uri, Me.playbackState.context)
            refreshState()
        End If
    End Sub

    Private Sub SearchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchButton.Click
        If Not Me.SearchTextBox.Text = "" Then
            controller.search(Me.SearchTextBox.Text)
        End If
    End Sub

    Private Sub TransferPlaybackButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferPlaybackButton.Click
        If Not Me.DeviceListBox.SelectedItem.id = "" Then
            If Me.playbackState.playing Then
                controller.playItem(Me.playbackState.nowPlaying.uri, Me.playbackState.context, Me.DeviceListBox.SelectedItem.id, Me.playbackState.progress)
            End If
            wait()
            refreshState()
        End If
    End Sub

    Private Sub TrackResultsDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles TrackResultsDataGridView.CellDoubleClick
        If e.RowIndex > -1 Then
            Me.playbackState.playing = True
            Dim track As Track = Me.appState.trackResults.Item(e.RowIndex)
            controller.playItem(track.uri, track.albumUri)
            wait()
            refreshState()
        End If
    End Sub

    Private Sub AlbumResultsDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles AlbumResultsDataGridView.CellDoubleClick
        If e.RowIndex > -1 Then
            Me.playbackState.playing = True
            Dim album As Album = Me.appState.albumResults.Item(e.RowIndex)
            controller.playItem("", album.uri)
            wait()
            refreshState()
        End If
    End Sub

    Private Sub ShuffleOnRadioButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShuffleOnRadioButton.Click
        Me.ShuffleOnRadioButton.Checked = True
        controller.setShuffle(True)
        refreshState()
    End Sub

    Private Sub ShuffleOffRadioButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShuffleOffRadioButton.Click
        Me.ShuffleOffRadioButton.Checked = True
        controller.setShuffle(False)
        refreshState()
    End Sub

    Private Sub RepeatAllRadioButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepeatAllRadioButton.Click
        Me.RepeatAllRadioButton.Checked = True
        controller.setRepeat(RepeatState.context)
        refreshState()
    End Sub

    Private Sub RepeatOneRadioButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepeatOneRadioButton.Click
        Me.RepeatOneRadioButton.Checked = True
        controller.setRepeat(RepeatState.track)
        refreshState()
    End Sub

    Private Sub RepeatOffRadioButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepeatOffRadioButton.Click
        Me.RepeatOffRadioButton.Checked = True
        controller.setRepeat(RepeatState.off)
        refreshState()
    End Sub

    Private Sub SearchTextBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SearchTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            controller.search(Me.SearchTextBox.Text)
        End If
    End Sub

    Private Sub HelpToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem1.Click
        My.Forms.HelpDialog.Show()
    End Sub

    Private Sub DeviceListBox_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeviceListBox.DoubleClick
        Me.playbackState.currentDevice = Me.DeviceListBox.SelectedItem
        If Me.playbackState.playing Then
            controller.playItem(Me.playbackState.nowPlaying.uri, Me.playbackState.context, Me.DeviceListBox.SelectedItem.id, Me.playbackState.progress)
        End If
        wait()
        refreshState()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Application.Exit()
    End Sub

    Private Sub NextTrackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextTrackToolStripMenuItem.Click
        controller.nextTrack()
        wait()
        refreshState()
    End Sub

    Private Sub PlayPauseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayPauseToolStripMenuItem.Click
        controller.playPause()
        wait()
        refreshState(False)
    End Sub

    Private Sub PreviousTrackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviousTrackToolStripMenuItem.Click
        controller.prevTrack()
        wait()
        refreshState()
    End Sub

    Private Sub ShowClientToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowClientToolStripMenuItem.Click
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub
End Class
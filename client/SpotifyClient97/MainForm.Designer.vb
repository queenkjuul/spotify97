<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim CurrentDeviceLabel As System.Windows.Forms.Label
        Dim AvailableDevicesLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ConnStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.LastServerMessageLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.Spacer = New System.Windows.Forms.ToolStripStatusLabel
        Me.PlayStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusUpdateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.NowPlayingGroupBox = New System.Windows.Forms.GroupBox
        Me.AlbumTextBox = New System.Windows.Forms.TextBox
        Me.PlaybackStateBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ArtistTextBox = New System.Windows.Forms.TextBox
        Me.TitleTextBox = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.AppStateBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AlbumLabel = New System.Windows.Forms.Label
        Me.TrackLabel = New System.Windows.Forms.Label
        Me.ArtistLabel = New System.Windows.Forms.Label
        Me.PrevButton = New System.Windows.Forms.Button
        Me.PlayPauseButton = New System.Windows.Forms.Button
        Me.NextButton = New System.Windows.Forms.Button
        Me.CurrentPlayerGroupBox = New System.Windows.Forms.GroupBox
        Me.TransferPlaybackButton = New System.Windows.Forms.Button
        Me.NamePropertyTextBox1 = New System.Windows.Forms.TextBox
        Me.DeviceListBox = New System.Windows.Forms.ListBox
        Me.DeviceListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.QueueGroupBox = New System.Windows.Forms.GroupBox
        Me.QueueDataGridView = New System.Windows.Forms.DataGridView
        Me.TitleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ArtistDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AlbumDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QueueBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.PlaybackProgressTimer = New System.Windows.Forms.Timer(Me.components)
        Me.RemainingTimeLabel = New System.Windows.Forms.Label
        Me.DurationLabel = New System.Windows.Forms.Label
        Me.ProgressLabel = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.StatusSyncTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SearchButton = New System.Windows.Forms.Button
        Me.SearchTextBox = New System.Windows.Forms.TextBox
        Me.ShuffleGroupBox = New System.Windows.Forms.GroupBox
        Me.ShuffleOffRadioButton = New System.Windows.Forms.RadioButton
        Me.ShuffleOnRadioButton = New System.Windows.Forms.RadioButton
        Me.RepeatGroupBox = New System.Windows.Forms.GroupBox
        Me.RepeatOffRadioButton = New System.Windows.Forms.RadioButton
        Me.RepeatAllRadioButton = New System.Windows.Forms.RadioButton
        Me.RepeatOneRadioButton = New System.Windows.Forms.RadioButton
        Me.TrackResultsTabControl = New System.Windows.Forms.TabControl
        Me.TrackResultsTabPage = New System.Windows.Forms.TabPage
        Me.TrackResultsDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TrackResultsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AlbumsResultsPage = New System.Windows.Forms.TabPage
        Me.AlbumResultsDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AlbumResultsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.NotifyIconContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowClientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PreviousTrackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PlayPauseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NextTrackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        CurrentDeviceLabel = New System.Windows.Forms.Label
        AvailableDevicesLabel = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.NowPlayingGroupBox.SuspendLayout()
        CType(Me.PlaybackStateBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppStateBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CurrentPlayerGroupBox.SuspendLayout()
        CType(Me.DeviceListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.QueueGroupBox.SuspendLayout()
        CType(Me.QueueDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QueueBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ShuffleGroupBox.SuspendLayout()
        Me.RepeatGroupBox.SuspendLayout()
        Me.TrackResultsTabControl.SuspendLayout()
        Me.TrackResultsTabPage.SuspendLayout()
        CType(Me.TrackResultsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackResultsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AlbumsResultsPage.SuspendLayout()
        CType(Me.AlbumResultsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AlbumResultsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NotifyIconContextMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'CurrentDeviceLabel
        '
        CurrentDeviceLabel.AutoSize = True
        CurrentDeviceLabel.Location = New System.Drawing.Point(6, 21)
        CurrentDeviceLabel.Name = "CurrentDeviceLabel"
        CurrentDeviceLabel.Size = New System.Drawing.Size(102, 17)
        CurrentDeviceLabel.TabIndex = 1
        CurrentDeviceLabel.Text = "Current Device"
        '
        'AvailableDevicesLabel
        '
        AvailableDevicesLabel.AutoSize = True
        AvailableDevicesLabel.Location = New System.Drawing.Point(6, 94)
        AvailableDevicesLabel.Name = "AvailableDevicesLabel"
        AvailableDevicesLabel.Size = New System.Drawing.Size(119, 17)
        AvailableDevicesLabel.TabIndex = 3
        AvailableDevicesLabel.Text = "Available Devices"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(948, 26)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(40, 22)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem1, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(48, 22)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(129, 22)
        Me.HelpToolStripMenuItem1.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConnStatusLabel, Me.LastServerMessageLabel, Me.Spacer, Me.PlayStatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 575)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(948, 23)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ConnStatusLabel
        '
        Me.ConnStatusLabel.Name = "ConnStatusLabel"
        Me.ConnStatusLabel.Size = New System.Drawing.Size(49, 18)
        Me.ConnStatusLabel.Text = "Ready"
        '
        'LastServerMessageLabel
        '
        Me.LastServerMessageLabel.Name = "LastServerMessageLabel"
        Me.LastServerMessageLabel.Size = New System.Drawing.Size(0, 18)
        '
        'Spacer
        '
        Me.Spacer.Name = "Spacer"
        Me.Spacer.Size = New System.Drawing.Size(823, 18)
        Me.Spacer.Spring = True
        '
        'PlayStatusLabel
        '
        Me.PlayStatusLabel.Name = "PlayStatusLabel"
        Me.PlayStatusLabel.Size = New System.Drawing.Size(61, 18)
        Me.PlayStatusLabel.Text = "Stopped"
        '
        'StatusUpdateTimer
        '
        Me.StatusUpdateTimer.Enabled = True
        '
        'NowPlayingGroupBox
        '
        Me.NowPlayingGroupBox.Controls.Add(Me.AlbumTextBox)
        Me.NowPlayingGroupBox.Controls.Add(Me.ArtistTextBox)
        Me.NowPlayingGroupBox.Controls.Add(Me.TitleTextBox)
        Me.NowPlayingGroupBox.Controls.Add(Me.PictureBox1)
        Me.NowPlayingGroupBox.Controls.Add(Me.AlbumLabel)
        Me.NowPlayingGroupBox.Controls.Add(Me.TrackLabel)
        Me.NowPlayingGroupBox.Controls.Add(Me.ArtistLabel)
        Me.NowPlayingGroupBox.Location = New System.Drawing.Point(723, 29)
        Me.NowPlayingGroupBox.Name = "NowPlayingGroupBox"
        Me.NowPlayingGroupBox.Size = New System.Drawing.Size(218, 437)
        Me.NowPlayingGroupBox.TabIndex = 7
        Me.NowPlayingGroupBox.TabStop = False
        Me.NowPlayingGroupBox.Text = "Now Playing"
        '
        'AlbumTextBox
        '
        Me.AlbumTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.AlbumTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PlaybackStateBindingSource, "nowPlaying.Album", True))
        Me.AlbumTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AlbumTextBox.Location = New System.Drawing.Point(8, 188)
        Me.AlbumTextBox.Name = "AlbumTextBox"
        Me.AlbumTextBox.ReadOnly = True
        Me.AlbumTextBox.Size = New System.Drawing.Size(200, 27)
        Me.AlbumTextBox.TabIndex = 17
        '
        'PlaybackStateBindingSource
        '
        Me.PlaybackStateBindingSource.DataSource = GetType(SpotifyClient97.PlaybackState)
        '
        'ArtistTextBox
        '
        Me.ArtistTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.ArtistTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PlaybackStateBindingSource, "nowPlaying.Artist", True))
        Me.ArtistTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArtistTextBox.Location = New System.Drawing.Point(9, 111)
        Me.ArtistTextBox.Name = "ArtistTextBox"
        Me.ArtistTextBox.ReadOnly = True
        Me.ArtistTextBox.Size = New System.Drawing.Size(200, 27)
        Me.ArtistTextBox.TabIndex = 16
        '
        'TitleTextBox
        '
        Me.TitleTextBox.BackColor = System.Drawing.SystemColors.Control
        Me.TitleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PlaybackStateBindingSource, "nowPlaying.Title", True))
        Me.TitleTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleTextBox.HideSelection = False
        Me.TitleTextBox.Location = New System.Drawing.Point(8, 41)
        Me.TitleTextBox.Name = "TitleTextBox"
        Me.TitleTextBox.ReadOnly = True
        Me.TitleTextBox.Size = New System.Drawing.Size(200, 27)
        Me.TitleTextBox.TabIndex = 15
        '
        'PictureBox1
        '
        Me.PictureBox1.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.AppStateBindingSource, "albumArt", True))
        Me.PictureBox1.Location = New System.Drawing.Point(9, 234)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 200)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'AppStateBindingSource
        '
        Me.AppStateBindingSource.DataSource = GetType(SpotifyClient97.ApplicationState)
        '
        'AlbumLabel
        '
        Me.AlbumLabel.AutoSize = True
        Me.AlbumLabel.Location = New System.Drawing.Point(5, 168)
        Me.AlbumLabel.Name = "AlbumLabel"
        Me.AlbumLabel.Size = New System.Drawing.Size(47, 17)
        Me.AlbumLabel.TabIndex = 10
        Me.AlbumLabel.Text = "Album"
        '
        'TrackLabel
        '
        Me.TrackLabel.AutoSize = True
        Me.TrackLabel.Location = New System.Drawing.Point(5, 21)
        Me.TrackLabel.Name = "TrackLabel"
        Me.TrackLabel.Size = New System.Drawing.Size(44, 17)
        Me.TrackLabel.TabIndex = 12
        Me.TrackLabel.Text = "Track"
        '
        'ArtistLabel
        '
        Me.ArtistLabel.AutoSize = True
        Me.ArtistLabel.Location = New System.Drawing.Point(5, 91)
        Me.ArtistLabel.Name = "ArtistLabel"
        Me.ArtistLabel.Size = New System.Drawing.Size(40, 17)
        Me.ArtistLabel.TabIndex = 8
        Me.ArtistLabel.Text = "Artist"
        '
        'PrevButton
        '
        Me.PrevButton.Image = Global.SpotifyClient97.My.Resources.Resources.prev
        Me.PrevButton.Location = New System.Drawing.Point(285, 502)
        Me.PrevButton.Name = "PrevButton"
        Me.PrevButton.Size = New System.Drawing.Size(72, 64)
        Me.PrevButton.TabIndex = 8
        Me.PrevButton.UseVisualStyleBackColor = True
        '
        'PlayPauseButton
        '
        Me.PlayPauseButton.Image = Global.SpotifyClient97.My.Resources.Resources.play
        Me.PlayPauseButton.Location = New System.Drawing.Point(363, 502)
        Me.PlayPauseButton.Name = "PlayPauseButton"
        Me.PlayPauseButton.Size = New System.Drawing.Size(222, 64)
        Me.PlayPauseButton.TabIndex = 9
        Me.PlayPauseButton.UseVisualStyleBackColor = True
        '
        'NextButton
        '
        Me.NextButton.Image = Global.SpotifyClient97.My.Resources.Resources._next
        Me.NextButton.Location = New System.Drawing.Point(591, 502)
        Me.NextButton.Name = "NextButton"
        Me.NextButton.Size = New System.Drawing.Size(72, 64)
        Me.NextButton.TabIndex = 11
        Me.NextButton.UseVisualStyleBackColor = True
        '
        'CurrentPlayerGroupBox
        '
        Me.CurrentPlayerGroupBox.Controls.Add(Me.TransferPlaybackButton)
        Me.CurrentPlayerGroupBox.Controls.Add(AvailableDevicesLabel)
        Me.CurrentPlayerGroupBox.Controls.Add(Me.NamePropertyTextBox1)
        Me.CurrentPlayerGroupBox.Controls.Add(CurrentDeviceLabel)
        Me.CurrentPlayerGroupBox.Controls.Add(Me.DeviceListBox)
        Me.CurrentPlayerGroupBox.Location = New System.Drawing.Point(7, 29)
        Me.CurrentPlayerGroupBox.Name = "CurrentPlayerGroupBox"
        Me.CurrentPlayerGroupBox.Size = New System.Drawing.Size(251, 220)
        Me.CurrentPlayerGroupBox.TabIndex = 12
        Me.CurrentPlayerGroupBox.TabStop = False
        Me.CurrentPlayerGroupBox.Text = "Playback Devices"
        '
        'TransferPlaybackButton
        '
        Me.TransferPlaybackButton.DataBindings.Add(New System.Windows.Forms.Binding("Enabled", Me.PlaybackStateBindingSource, "playing", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TransferPlaybackButton.Location = New System.Drawing.Point(145, 91)
        Me.TransferPlaybackButton.Name = "TransferPlaybackButton"
        Me.TransferPlaybackButton.Size = New System.Drawing.Size(96, 23)
        Me.TransferPlaybackButton.TabIndex = 27
        Me.TransferPlaybackButton.Text = "Switch"
        Me.TransferPlaybackButton.UseVisualStyleBackColor = True
        '
        'NamePropertyTextBox1
        '
        Me.NamePropertyTextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.NamePropertyTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PlaybackStateBindingSource, "currentDevice.nameProperty", True))
        Me.NamePropertyTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NamePropertyTextBox1.Location = New System.Drawing.Point(9, 41)
        Me.NamePropertyTextBox1.Name = "NamePropertyTextBox1"
        Me.NamePropertyTextBox1.Size = New System.Drawing.Size(232, 27)
        Me.NamePropertyTextBox1.TabIndex = 22
        '
        'DeviceListBox
        '
        Me.DeviceListBox.DataSource = Me.DeviceListBindingSource
        Me.DeviceListBox.DisplayMember = "nameProperty"
        Me.DeviceListBox.FormattingEnabled = True
        Me.DeviceListBox.ItemHeight = 16
        Me.DeviceListBox.Location = New System.Drawing.Point(9, 121)
        Me.DeviceListBox.Name = "DeviceListBox"
        Me.DeviceListBox.Size = New System.Drawing.Size(232, 84)
        Me.DeviceListBox.TabIndex = 0
        '
        'DeviceListBindingSource
        '
        Me.DeviceListBindingSource.DataMember = "deviceList"
        Me.DeviceListBindingSource.DataSource = Me.AppStateBindingSource
        '
        'QueueGroupBox
        '
        Me.QueueGroupBox.Controls.Add(Me.QueueDataGridView)
        Me.QueueGroupBox.Location = New System.Drawing.Point(7, 255)
        Me.QueueGroupBox.Name = "QueueGroupBox"
        Me.QueueGroupBox.Size = New System.Drawing.Size(710, 212)
        Me.QueueGroupBox.TabIndex = 13
        Me.QueueGroupBox.TabStop = False
        Me.QueueGroupBox.Text = "Queue"
        '
        'QueueDataGridView
        '
        Me.QueueDataGridView.AllowUserToAddRows = False
        Me.QueueDataGridView.AllowUserToDeleteRows = False
        Me.QueueDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        Me.QueueDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.QueueDataGridView.AutoGenerateColumns = False
        Me.QueueDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.QueueDataGridView.BackgroundColor = System.Drawing.SystemColors.Control
        Me.QueueDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.QueueDataGridView.CausesValidation = False
        Me.QueueDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.QueueDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TitleDataGridViewTextBoxColumn, Me.ArtistDataGridViewTextBoxColumn, Me.AlbumDataGridViewTextBoxColumn})
        Me.QueueDataGridView.DataSource = Me.QueueBindingSource
        Me.QueueDataGridView.Location = New System.Drawing.Point(6, 21)
        Me.QueueDataGridView.MultiSelect = False
        Me.QueueDataGridView.Name = "QueueDataGridView"
        Me.QueueDataGridView.ReadOnly = True
        Me.QueueDataGridView.RowHeadersVisible = False
        Me.QueueDataGridView.RowTemplate.Height = 24
        Me.QueueDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.QueueDataGridView.Size = New System.Drawing.Size(698, 185)
        Me.QueueDataGridView.TabIndex = 0
        '
        'TitleDataGridViewTextBoxColumn
        '
        Me.TitleDataGridViewTextBoxColumn.DataPropertyName = "Title"
        Me.TitleDataGridViewTextBoxColumn.HeaderText = "Title"
        Me.TitleDataGridViewTextBoxColumn.Name = "TitleDataGridViewTextBoxColumn"
        Me.TitleDataGridViewTextBoxColumn.ReadOnly = True
        Me.TitleDataGridViewTextBoxColumn.Width = 58
        '
        'ArtistDataGridViewTextBoxColumn
        '
        Me.ArtistDataGridViewTextBoxColumn.DataPropertyName = "Artist"
        Me.ArtistDataGridViewTextBoxColumn.HeaderText = "Artist"
        Me.ArtistDataGridViewTextBoxColumn.Name = "ArtistDataGridViewTextBoxColumn"
        Me.ArtistDataGridViewTextBoxColumn.ReadOnly = True
        Me.ArtistDataGridViewTextBoxColumn.Width = 63
        '
        'AlbumDataGridViewTextBoxColumn
        '
        Me.AlbumDataGridViewTextBoxColumn.DataPropertyName = "Album"
        Me.AlbumDataGridViewTextBoxColumn.HeaderText = "Album"
        Me.AlbumDataGridViewTextBoxColumn.Name = "AlbumDataGridViewTextBoxColumn"
        Me.AlbumDataGridViewTextBoxColumn.ReadOnly = True
        Me.AlbumDataGridViewTextBoxColumn.Width = 70
        '
        'QueueBindingSource
        '
        Me.QueueBindingSource.DataMember = "queue"
        Me.QueueBindingSource.DataSource = Me.AppStateBindingSource
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(7, 473)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(934, 23)
        Me.ProgressBar1.TabIndex = 14
        '
        'PlaybackProgressTimer
        '
        Me.PlaybackProgressTimer.Enabled = True
        Me.PlaybackProgressTimer.Interval = 1000
        '
        'RemainingTimeLabel
        '
        Me.RemainingTimeLabel.AutoSize = True
        Me.RemainingTimeLabel.Location = New System.Drawing.Point(10, 499)
        Me.RemainingTimeLabel.Name = "RemainingTimeLabel"
        Me.RemainingTimeLabel.Size = New System.Drawing.Size(49, 17)
        Me.RemainingTimeLabel.TabIndex = 17
        Me.RemainingTimeLabel.Text = "-00:00"
        '
        'DurationLabel
        '
        Me.DurationLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DurationLabel.AutoSize = True
        Me.DurationLabel.Location = New System.Drawing.Point(897, 499)
        Me.DurationLabel.Name = "DurationLabel"
        Me.DurationLabel.Size = New System.Drawing.Size(44, 17)
        Me.DurationLabel.TabIndex = 19
        Me.DurationLabel.Text = "00:00"
        '
        'ProgressLabel
        '
        Me.ProgressLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressLabel.AutoSize = True
        Me.ProgressLabel.Location = New System.Drawing.Point(829, 499)
        Me.ProgressLabel.Name = "ProgressLabel"
        Me.ProgressLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ProgressLabel.Size = New System.Drawing.Size(44, 17)
        Me.ProgressLabel.TabIndex = 20
        Me.ProgressLabel.Text = "00:00"
        Me.ProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(879, 499)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 17)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "/"
        '
        'StatusSyncTimer
        '
        Me.StatusSyncTimer.Interval = 10000
        '
        'SearchButton
        '
        Me.SearchButton.Location = New System.Drawing.Point(642, 29)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(75, 27)
        Me.SearchButton.TabIndex = 23
        Me.SearchButton.Text = "Search"
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'SearchTextBox
        '
        Me.SearchTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchTextBox.Location = New System.Drawing.Point(264, 29)
        Me.SearchTextBox.Name = "SearchTextBox"
        Me.SearchTextBox.Size = New System.Drawing.Size(372, 27)
        Me.SearchTextBox.TabIndex = 22
        '
        'ShuffleGroupBox
        '
        Me.ShuffleGroupBox.Controls.Add(Me.ShuffleOffRadioButton)
        Me.ShuffleGroupBox.Controls.Add(Me.ShuffleOnRadioButton)
        Me.ShuffleGroupBox.Location = New System.Drawing.Point(669, 515)
        Me.ShuffleGroupBox.Name = "ShuffleGroupBox"
        Me.ShuffleGroupBox.Size = New System.Drawing.Size(200, 51)
        Me.ShuffleGroupBox.TabIndex = 25
        Me.ShuffleGroupBox.TabStop = False
        Me.ShuffleGroupBox.Text = "Shuffle"
        '
        'ShuffleOffRadioButton
        '
        Me.ShuffleOffRadioButton.AutoSize = True
        Me.ShuffleOffRadioButton.Checked = True
        Me.ShuffleOffRadioButton.Location = New System.Drawing.Point(45, 19)
        Me.ShuffleOffRadioButton.Name = "ShuffleOffRadioButton"
        Me.ShuffleOffRadioButton.Size = New System.Drawing.Size(48, 21)
        Me.ShuffleOffRadioButton.TabIndex = 3
        Me.ShuffleOffRadioButton.TabStop = True
        Me.ShuffleOffRadioButton.Text = "Off"
        Me.ShuffleOffRadioButton.UseVisualStyleBackColor = True
        '
        'ShuffleOnRadioButton
        '
        Me.ShuffleOnRadioButton.AutoSize = True
        Me.ShuffleOnRadioButton.Location = New System.Drawing.Point(123, 19)
        Me.ShuffleOnRadioButton.Name = "ShuffleOnRadioButton"
        Me.ShuffleOnRadioButton.Size = New System.Drawing.Size(48, 21)
        Me.ShuffleOnRadioButton.TabIndex = 1
        Me.ShuffleOnRadioButton.Text = "On"
        Me.ShuffleOnRadioButton.UseVisualStyleBackColor = True
        '
        'RepeatGroupBox
        '
        Me.RepeatGroupBox.Controls.Add(Me.RepeatOffRadioButton)
        Me.RepeatGroupBox.Controls.Add(Me.RepeatAllRadioButton)
        Me.RepeatGroupBox.Controls.Add(Me.RepeatOneRadioButton)
        Me.RepeatGroupBox.Location = New System.Drawing.Point(79, 515)
        Me.RepeatGroupBox.Name = "RepeatGroupBox"
        Me.RepeatGroupBox.Size = New System.Drawing.Size(200, 51)
        Me.RepeatGroupBox.TabIndex = 26
        Me.RepeatGroupBox.TabStop = False
        Me.RepeatGroupBox.Text = "Repeat"
        '
        'RepeatOffRadioButton
        '
        Me.RepeatOffRadioButton.AutoSize = True
        Me.RepeatOffRadioButton.Checked = True
        Me.RepeatOffRadioButton.Location = New System.Drawing.Point(23, 19)
        Me.RepeatOffRadioButton.Name = "RepeatOffRadioButton"
        Me.RepeatOffRadioButton.Size = New System.Drawing.Size(48, 21)
        Me.RepeatOffRadioButton.TabIndex = 3
        Me.RepeatOffRadioButton.TabStop = True
        Me.RepeatOffRadioButton.Text = "Off"
        Me.RepeatOffRadioButton.UseVisualStyleBackColor = True
        '
        'RepeatAllRadioButton
        '
        Me.RepeatAllRadioButton.AutoSize = True
        Me.RepeatAllRadioButton.Location = New System.Drawing.Point(139, 19)
        Me.RepeatAllRadioButton.Name = "RepeatAllRadioButton"
        Me.RepeatAllRadioButton.Size = New System.Drawing.Size(44, 21)
        Me.RepeatAllRadioButton.TabIndex = 2
        Me.RepeatAllRadioButton.Text = "All"
        Me.RepeatAllRadioButton.UseVisualStyleBackColor = True
        '
        'RepeatOneRadioButton
        '
        Me.RepeatOneRadioButton.AutoSize = True
        Me.RepeatOneRadioButton.Location = New System.Drawing.Point(77, 19)
        Me.RepeatOneRadioButton.Name = "RepeatOneRadioButton"
        Me.RepeatOneRadioButton.Size = New System.Drawing.Size(56, 21)
        Me.RepeatOneRadioButton.TabIndex = 1
        Me.RepeatOneRadioButton.Text = "One"
        Me.RepeatOneRadioButton.UseVisualStyleBackColor = True
        '
        'TrackResultsTabControl
        '
        Me.TrackResultsTabControl.Controls.Add(Me.TrackResultsTabPage)
        Me.TrackResultsTabControl.Controls.Add(Me.AlbumsResultsPage)
        Me.TrackResultsTabControl.Location = New System.Drawing.Point(264, 62)
        Me.TrackResultsTabControl.Name = "TrackResultsTabControl"
        Me.TrackResultsTabControl.SelectedIndex = 0
        Me.TrackResultsTabControl.Size = New System.Drawing.Size(453, 187)
        Me.TrackResultsTabControl.TabIndex = 4
        '
        'TrackResultsTabPage
        '
        Me.TrackResultsTabPage.AutoScroll = True
        Me.TrackResultsTabPage.Controls.Add(Me.TrackResultsDataGridView)
        Me.TrackResultsTabPage.Location = New System.Drawing.Point(4, 25)
        Me.TrackResultsTabPage.Name = "TrackResultsTabPage"
        Me.TrackResultsTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.TrackResultsTabPage.Size = New System.Drawing.Size(445, 158)
        Me.TrackResultsTabPage.TabIndex = 0
        Me.TrackResultsTabPage.Text = "Tracks"
        Me.TrackResultsTabPage.UseVisualStyleBackColor = True
        '
        'TrackResultsDataGridView
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        Me.TrackResultsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.TrackResultsDataGridView.AutoGenerateColumns = False
        Me.TrackResultsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.TrackResultsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control
        Me.TrackResultsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TrackResultsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.TrackResultsDataGridView.DataSource = Me.TrackResultsBindingSource
        Me.TrackResultsDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.TrackResultsDataGridView.Name = "TrackResultsDataGridView"
        Me.TrackResultsDataGridView.RowHeadersVisible = False
        Me.TrackResultsDataGridView.RowTemplate.Height = 24
        Me.TrackResultsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TrackResultsDataGridView.Size = New System.Drawing.Size(445, 157)
        Me.TrackResultsDataGridView.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Title"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Title"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 58
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Artist"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Artist"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 63
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Album"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Album"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 70
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Duration"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Duration"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 85
        '
        'TrackResultsBindingSource
        '
        Me.TrackResultsBindingSource.DataMember = "trackResults"
        Me.TrackResultsBindingSource.DataSource = Me.AppStateBindingSource
        '
        'AlbumsResultsPage
        '
        Me.AlbumsResultsPage.AutoScroll = True
        Me.AlbumsResultsPage.Controls.Add(Me.AlbumResultsDataGridView)
        Me.AlbumsResultsPage.Location = New System.Drawing.Point(4, 25)
        Me.AlbumsResultsPage.Name = "AlbumsResultsPage"
        Me.AlbumsResultsPage.Padding = New System.Windows.Forms.Padding(3)
        Me.AlbumsResultsPage.Size = New System.Drawing.Size(445, 158)
        Me.AlbumsResultsPage.TabIndex = 1
        Me.AlbumsResultsPage.Text = "Albums"
        Me.AlbumsResultsPage.UseVisualStyleBackColor = True
        '
        'AlbumResultsDataGridView
        '
        Me.AlbumResultsDataGridView.AllowUserToAddRows = False
        Me.AlbumResultsDataGridView.AllowUserToDeleteRows = False
        Me.AlbumResultsDataGridView.AllowUserToOrderColumns = True
        Me.AlbumResultsDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        Me.AlbumResultsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.AlbumResultsDataGridView.AutoGenerateColumns = False
        Me.AlbumResultsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.AlbumResultsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control
        Me.AlbumResultsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AlbumResultsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.AlbumResultsDataGridView.DataSource = Me.AlbumResultsBindingSource
        Me.AlbumResultsDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.AlbumResultsDataGridView.Name = "AlbumResultsDataGridView"
        Me.AlbumResultsDataGridView.RowHeadersVisible = False
        Me.AlbumResultsDataGridView.RowTemplate.Height = 24
        Me.AlbumResultsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.AlbumResultsDataGridView.Size = New System.Drawing.Size(445, 158)
        Me.AlbumResultsDataGridView.TabIndex = 0
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "title"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Title"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 58
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "artist"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Artist"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 63
        '
        'AlbumResultsBindingSource
        '
        Me.AlbumResultsBindingSource.DataMember = "albumResults"
        Me.AlbumResultsBindingSource.DataSource = Me.AppStateBindingSource
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.NotifyIconContextMenuStrip
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Spotify Client 97"
        Me.NotifyIcon1.Visible = True
        '
        'NotifyIconContextMenuStrip
        '
        Me.NotifyIconContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowClientToolStripMenuItem, Me.PreviousTrackToolStripMenuItem, Me.PlayPauseToolStripMenuItem, Me.NextTrackToolStripMenuItem, Me.ExitToolStripMenuItem1})
        Me.NotifyIconContextMenuStrip.Name = "NotifyIconContextMenuStrip"
        Me.NotifyIconContextMenuStrip.Size = New System.Drawing.Size(188, 114)
        '
        'ShowClientToolStripMenuItem
        '
        Me.ShowClientToolStripMenuItem.Name = "ShowClientToolStripMenuItem"
        Me.ShowClientToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.ShowClientToolStripMenuItem.Text = "Show Client"
        '
        'PreviousTrackToolStripMenuItem
        '
        Me.PreviousTrackToolStripMenuItem.Name = "PreviousTrackToolStripMenuItem"
        Me.PreviousTrackToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.PreviousTrackToolStripMenuItem.Text = "Previous Track"
        '
        'PlayPauseToolStripMenuItem
        '
        Me.PlayPauseToolStripMenuItem.Name = "PlayPauseToolStripMenuItem"
        Me.PlayPauseToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.PlayPauseToolStripMenuItem.Text = "Play/Pause"
        '
        'NextTrackToolStripMenuItem
        '
        Me.NextTrackToolStripMenuItem.Name = "NextTrackToolStripMenuItem"
        Me.NextTrackToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.NextTrackToolStripMenuItem.Text = "Next Track"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(187, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(948, 598)
        Me.Controls.Add(Me.TrackResultsTabControl)
        Me.Controls.Add(Me.RepeatGroupBox)
        Me.Controls.Add(Me.ShuffleGroupBox)
        Me.Controls.Add(Me.SearchButton)
        Me.Controls.Add(Me.SearchTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ProgressLabel)
        Me.Controls.Add(Me.DurationLabel)
        Me.Controls.Add(Me.RemainingTimeLabel)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.QueueGroupBox)
        Me.Controls.Add(Me.CurrentPlayerGroupBox)
        Me.Controls.Add(Me.NextButton)
        Me.Controls.Add(Me.PlayPauseButton)
        Me.Controls.Add(Me.PrevButton)
        Me.Controls.Add(Me.NowPlayingGroupBox)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Spotify(R) Client 97"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.NowPlayingGroupBox.ResumeLayout(False)
        Me.NowPlayingGroupBox.PerformLayout()
        CType(Me.PlaybackStateBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppStateBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CurrentPlayerGroupBox.ResumeLayout(False)
        Me.CurrentPlayerGroupBox.PerformLayout()
        CType(Me.DeviceListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.QueueGroupBox.ResumeLayout(False)
        CType(Me.QueueDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QueueBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ShuffleGroupBox.ResumeLayout(False)
        Me.ShuffleGroupBox.PerformLayout()
        Me.RepeatGroupBox.ResumeLayout(False)
        Me.RepeatGroupBox.PerformLayout()
        Me.TrackResultsTabControl.ResumeLayout(False)
        Me.TrackResultsTabPage.ResumeLayout(False)
        CType(Me.TrackResultsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackResultsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AlbumsResultsPage.ResumeLayout(False)
        CType(Me.AlbumResultsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AlbumResultsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NotifyIconContextMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AppStateBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ConnStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PlayStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusUpdateTimer As System.Windows.Forms.Timer
    Friend WithEvents Spacer As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LastServerMessageLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents NowPlayingGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ArtistLabel As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TrackLabel As System.Windows.Forms.Label
    Friend WithEvents AlbumLabel As System.Windows.Forms.Label
    Friend WithEvents PrevButton As System.Windows.Forms.Button
    Friend WithEvents PlayPauseButton As System.Windows.Forms.Button
    Friend WithEvents NextButton As System.Windows.Forms.Button
    Friend WithEvents CurrentPlayerGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents DeviceListBox As System.Windows.Forms.ListBox
    Friend WithEvents QueueGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents DeviceListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents QueueDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents PlaybackStateBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TitleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AlbumTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ArtistTextBox As System.Windows.Forms.TextBox
    Friend WithEvents QueueBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TitleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ArtistDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AlbumDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlaybackProgressTimer As System.Windows.Forms.Timer
    Friend WithEvents RemainingTimeLabel As System.Windows.Forms.Label
    Friend WithEvents DurationLabel As System.Windows.Forms.Label
    Friend WithEvents ProgressLabel As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NamePropertyTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents StatusSyncTimer As System.Windows.Forms.Timer
    Friend WithEvents HelpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchButton As System.Windows.Forms.Button
    Friend WithEvents SearchTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ShuffleGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ShuffleOnRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents ShuffleOffRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents RepeatGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents RepeatOffRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents RepeatAllRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents RepeatOneRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents TrackResultsTabControl As System.Windows.Forms.TabControl
    Friend WithEvents TrackResultsTabPage As System.Windows.Forms.TabPage
    Friend WithEvents TrackResultsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TrackResultsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AlbumsResultsPage As System.Windows.Forms.TabPage
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AlbumResultsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AlbumResultsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TransferPlaybackButton As System.Windows.Forms.Button
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents NotifyIconContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowClientToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreviousTrackToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlayPauseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NextTrackToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem

End Class

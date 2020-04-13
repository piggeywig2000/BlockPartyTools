namespace BlockPartyTools
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelSubtitle = new System.Windows.Forms.Label();
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
            this.buttonSetUsername = new System.Windows.Forms.Button();
            this.labelRefreshRateValue = new System.Windows.Forms.Label();
            this.trackBarRefeshRate = new System.Windows.Forms.TrackBar();
            this.labelRefreshRate = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.timerLogger = new System.Windows.Forms.Timer(this.components);
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.buttonOpenColourDisplay = new System.Windows.Forms.Button();
            this.buttonDownloadPauseSound = new System.Windows.Forms.Button();
            this.buttonBrowsePauseSound = new System.Windows.Forms.Button();
            this.labelPauseSound = new System.Windows.Forms.Label();
            this.buttonBrowsePlaySound = new System.Windows.Forms.Button();
            this.buttonDownloadPlaySound = new System.Windows.Forms.Button();
            this.labelPlaySound = new System.Windows.Forms.Label();
            this.checkBoxInitialState = new System.Windows.Forms.CheckBox();
            this.checkBoxKeystrokes = new System.Windows.Forms.CheckBox();
            this.openFileDialogPlay = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogPause = new System.Windows.Forms.OpenFileDialog();
            this.labelPlayPauseInfo = new System.Windows.Forms.Label();
            this.checkBoxNarration = new System.Windows.Forms.CheckBox();
            this.groupBoxConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRefeshRate)).BeginInit();
            this.groupBoxLog.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(299, 42);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "BlockParty Tools";
            // 
            // labelSubtitle
            // 
            this.labelSubtitle.AutoSize = true;
            this.labelSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitle.Location = new System.Drawing.Point(15, 51);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(134, 20);
            this.labelSubtitle.TabIndex = 1;
            this.labelSubtitle.Text = "by piggeywig2000";
            // 
            // groupBoxConnection
            // 
            this.groupBoxConnection.Controls.Add(this.buttonSetUsername);
            this.groupBoxConnection.Controls.Add(this.labelRefreshRateValue);
            this.groupBoxConnection.Controls.Add(this.trackBarRefeshRate);
            this.groupBoxConnection.Controls.Add(this.labelRefreshRate);
            this.groupBoxConnection.Controls.Add(this.buttonStop);
            this.groupBoxConnection.Controls.Add(this.buttonStart);
            this.groupBoxConnection.Controls.Add(this.textBoxUsername);
            this.groupBoxConnection.Controls.Add(this.labelUsername);
            this.groupBoxConnection.Location = new System.Drawing.Point(12, 74);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new System.Drawing.Size(300, 116);
            this.groupBoxConnection.TabIndex = 2;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "Connection";
            // 
            // buttonSetUsername
            // 
            this.buttonSetUsername.Location = new System.Drawing.Point(251, 19);
            this.buttonSetUsername.Name = "buttonSetUsername";
            this.buttonSetUsername.Size = new System.Drawing.Size(43, 20);
            this.buttonSetUsername.TabIndex = 7;
            this.buttonSetUsername.Text = "Set";
            this.buttonSetUsername.UseVisualStyleBackColor = true;
            this.buttonSetUsername.Click += new System.EventHandler(this.buttonSetUsername_Click);
            // 
            // labelRefreshRateValue
            // 
            this.labelRefreshRateValue.Location = new System.Drawing.Point(261, 48);
            this.labelRefreshRateValue.Name = "labelRefreshRateValue";
            this.labelRefreshRateValue.Size = new System.Drawing.Size(33, 16);
            this.labelRefreshRateValue.TabIndex = 6;
            this.labelRefreshRateValue.Text = "1.0s";
            // 
            // trackBarRefeshRate
            // 
            this.trackBarRefeshRate.AutoSize = false;
            this.trackBarRefeshRate.LargeChange = 0;
            this.trackBarRefeshRate.Location = new System.Drawing.Point(85, 45);
            this.trackBarRefeshRate.Maximum = 100;
            this.trackBarRefeshRate.Minimum = 1;
            this.trackBarRefeshRate.Name = "trackBarRefeshRate";
            this.trackBarRefeshRate.Size = new System.Drawing.Size(170, 29);
            this.trackBarRefeshRate.SmallChange = 0;
            this.trackBarRefeshRate.TabIndex = 5;
            this.trackBarRefeshRate.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarRefeshRate.Value = 10;
            this.trackBarRefeshRate.Scroll += new System.EventHandler(this.trackBarRefeshRate_Scroll);
            this.trackBarRefeshRate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarRefeshRate_MouseUp);
            // 
            // labelRefreshRate
            // 
            this.labelRefreshRate.AutoSize = true;
            this.labelRefreshRate.Location = new System.Drawing.Point(6, 48);
            this.labelRefreshRate.Name = "labelRefreshRate";
            this.labelRefreshRate.Size = new System.Drawing.Size(73, 13);
            this.labelRefreshRate.TabIndex = 4;
            this.labelRefreshRate.Text = "Refresh Rate:";
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(153, 80);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(141, 30);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(6, 80);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(141, 30);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(70, 19);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(175, 20);
            this.textBoxUsername.TabIndex = 1;
            this.textBoxUsername.Leave += new System.EventHandler(this.textBoxUsername_Leave);
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(6, 22);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(58, 13);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username:";
            // 
            // groupBoxLog
            // 
            this.groupBoxLog.Controls.Add(this.richTextBoxLog);
            this.groupBoxLog.Location = new System.Drawing.Point(12, 250);
            this.groupBoxLog.Name = "groupBoxLog";
            this.groupBoxLog.Size = new System.Drawing.Size(760, 371);
            this.groupBoxLog.TabIndex = 3;
            this.groupBoxLog.TabStop = false;
            this.groupBoxLog.Text = "Log";
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxLog.BackColor = System.Drawing.Color.Black;
            this.richTextBoxLog.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxLog.ForeColor = System.Drawing.Color.White;
            this.richTextBoxLog.Location = new System.Drawing.Point(6, 19);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxLog.Size = new System.Drawing.Size(748, 346);
            this.richTextBoxLog.TabIndex = 0;
            this.richTextBoxLog.Text = "Application Started";
            // 
            // timerLogger
            // 
            this.timerLogger.Enabled = true;
            this.timerLogger.Interval = 50;
            this.timerLogger.Tick += new System.EventHandler(this.timerLogger_Tick);
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.checkBoxNarration);
            this.groupBoxOptions.Controls.Add(this.labelPlayPauseInfo);
            this.groupBoxOptions.Controls.Add(this.buttonOpenColourDisplay);
            this.groupBoxOptions.Controls.Add(this.buttonDownloadPauseSound);
            this.groupBoxOptions.Controls.Add(this.buttonBrowsePauseSound);
            this.groupBoxOptions.Controls.Add(this.labelPauseSound);
            this.groupBoxOptions.Controls.Add(this.buttonBrowsePlaySound);
            this.groupBoxOptions.Controls.Add(this.buttonDownloadPlaySound);
            this.groupBoxOptions.Controls.Add(this.labelPlaySound);
            this.groupBoxOptions.Controls.Add(this.checkBoxInitialState);
            this.groupBoxOptions.Controls.Add(this.checkBoxKeystrokes);
            this.groupBoxOptions.Location = new System.Drawing.Point(318, 9);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(454, 235);
            this.groupBoxOptions.TabIndex = 4;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // buttonOpenColourDisplay
            // 
            this.buttonOpenColourDisplay.Location = new System.Drawing.Point(6, 207);
            this.buttonOpenColourDisplay.Name = "buttonOpenColourDisplay";
            this.buttonOpenColourDisplay.Size = new System.Drawing.Size(114, 22);
            this.buttonOpenColourDisplay.TabIndex = 8;
            this.buttonOpenColourDisplay.Text = "Open colour display";
            this.buttonOpenColourDisplay.UseVisualStyleBackColor = true;
            this.buttonOpenColourDisplay.Click += new System.EventHandler(this.buttonOpenColourDisplay_Click);
            // 
            // buttonDownloadPauseSound
            // 
            this.buttonDownloadPauseSound.Location = new System.Drawing.Point(309, 142);
            this.buttonDownloadPauseSound.Name = "buttonDownloadPauseSound";
            this.buttonDownloadPauseSound.Size = new System.Drawing.Size(139, 23);
            this.buttonDownloadPauseSound.TabIndex = 7;
            this.buttonDownloadPauseSound.Text = "Download Vinyl Scratch\r\n";
            this.buttonDownloadPauseSound.UseVisualStyleBackColor = true;
            this.buttonDownloadPauseSound.Click += new System.EventHandler(this.buttonDownloadPauseSound_Click);
            // 
            // buttonBrowsePauseSound
            // 
            this.buttonBrowsePauseSound.Location = new System.Drawing.Point(228, 142);
            this.buttonBrowsePauseSound.Name = "buttonBrowsePauseSound";
            this.buttonBrowsePauseSound.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowsePauseSound.TabIndex = 6;
            this.buttonBrowsePauseSound.Text = "Browse";
            this.buttonBrowsePauseSound.UseVisualStyleBackColor = true;
            this.buttonBrowsePauseSound.Click += new System.EventHandler(this.buttonBrowsePauseSound_Click);
            // 
            // labelPauseSound
            // 
            this.labelPauseSound.AutoEllipsis = true;
            this.labelPauseSound.Location = new System.Drawing.Point(6, 142);
            this.labelPauseSound.Name = "labelPauseSound";
            this.labelPauseSound.Size = new System.Drawing.Size(216, 23);
            this.labelPauseSound.TabIndex = 5;
            this.labelPauseSound.Text = "Pause sound: None";
            this.labelPauseSound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonBrowsePlaySound
            // 
            this.buttonBrowsePlaySound.Location = new System.Drawing.Point(228, 113);
            this.buttonBrowsePlaySound.Name = "buttonBrowsePlaySound";
            this.buttonBrowsePlaySound.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowsePlaySound.TabIndex = 4;
            this.buttonBrowsePlaySound.Text = "Browse";
            this.buttonBrowsePlaySound.UseVisualStyleBackColor = true;
            this.buttonBrowsePlaySound.Click += new System.EventHandler(this.buttonBrowsePlaySound_Click);
            // 
            // buttonDownloadPlaySound
            // 
            this.buttonDownloadPlaySound.Location = new System.Drawing.Point(309, 113);
            this.buttonDownloadPlaySound.Name = "buttonDownloadPlaySound";
            this.buttonDownloadPlaySound.Size = new System.Drawing.Size(139, 23);
            this.buttonDownloadPlaySound.TabIndex = 3;
            this.buttonDownloadPlaySound.Text = "Download Cheer Sound";
            this.buttonDownloadPlaySound.UseVisualStyleBackColor = true;
            this.buttonDownloadPlaySound.Click += new System.EventHandler(this.buttonDownloadPlaySound_Click);
            // 
            // labelPlaySound
            // 
            this.labelPlaySound.AutoEllipsis = true;
            this.labelPlaySound.Location = new System.Drawing.Point(6, 113);
            this.labelPlaySound.Name = "labelPlaySound";
            this.labelPlaySound.Size = new System.Drawing.Size(216, 23);
            this.labelPlaySound.TabIndex = 2;
            this.labelPlaySound.Text = "Play sound: None";
            this.labelPlaySound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxInitialState
            // 
            this.checkBoxInitialState.Enabled = false;
            this.checkBoxInitialState.Location = new System.Drawing.Point(26, 58);
            this.checkBoxInitialState.Name = "checkBoxInitialState";
            this.checkBoxInitialState.Size = new System.Drawing.Size(291, 24);
            this.checkBoxInitialState.TabIndex = 1;
            this.checkBoxInitialState.Text = "Before the game starts, my music is already playing";
            this.checkBoxInitialState.UseVisualStyleBackColor = true;
            this.checkBoxInitialState.CheckedChanged += new System.EventHandler(this.checkBoxInitialState_CheckedChanged);
            // 
            // checkBoxKeystrokes
            // 
            this.checkBoxKeystrokes.Location = new System.Drawing.Point(6, 19);
            this.checkBoxKeystrokes.Name = "checkBoxKeystrokes";
            this.checkBoxKeystrokes.Size = new System.Drawing.Size(442, 33);
            this.checkBoxKeystrokes.TabIndex = 0;
            this.checkBoxKeystrokes.Text = "Send play/pause keystroke when the music starts or stops.\r\n(The play/pause keystr" +
    "oke will stop and start your music at the correct time.)";
            this.checkBoxKeystrokes.UseVisualStyleBackColor = true;
            this.checkBoxKeystrokes.CheckedChanged += new System.EventHandler(this.checkBoxKeystrokes_CheckedChanged);
            // 
            // labelPlayPauseInfo
            // 
            this.labelPlayPauseInfo.Location = new System.Drawing.Point(6, 98);
            this.labelPlayPauseInfo.Name = "labelPlayPauseInfo";
            this.labelPlayPauseInfo.Size = new System.Drawing.Size(442, 15);
            this.labelPlayPauseInfo.TabIndex = 9;
            this.labelPlayPauseInfo.Text = "The play and pause sound files must be stereo .ogg files";
            this.labelPlayPauseInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // checkBoxNarration
            // 
            this.checkBoxNarration.AutoSize = true;
            this.checkBoxNarration.Checked = true;
            this.checkBoxNarration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNarration.Location = new System.Drawing.Point(6, 176);
            this.checkBoxNarration.Name = "checkBoxNarration";
            this.checkBoxNarration.Size = new System.Drawing.Size(163, 17);
            this.checkBoxNarration.TabIndex = 10;
            this.checkBoxNarration.Text = "Play villager narration sounds";
            this.checkBoxNarration.UseVisualStyleBackColor = true;
            this.checkBoxNarration.CheckedChanged += new System.EventHandler(this.checkBoxNarration_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 633);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.groupBoxLog);
            this.Controls.Add(this.groupBoxConnection);
            this.Controls.Add(this.labelSubtitle);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "BlockParty Tools";
            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRefeshRate)).EndInit();
            this.groupBoxLog.ResumeLayout(false);
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelSubtitle;
        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label labelRefreshRate;
        private System.Windows.Forms.TrackBar trackBarRefeshRate;
        private System.Windows.Forms.Label labelRefreshRateValue;
        private System.Windows.Forms.GroupBox groupBoxLog;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Timer timerLogger;
        private System.Windows.Forms.Button buttonSetUsername;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.CheckBox checkBoxKeystrokes;
        private System.Windows.Forms.CheckBox checkBoxInitialState;
        private System.Windows.Forms.Label labelPlaySound;
        private System.Windows.Forms.Button buttonDownloadPlaySound;
        private System.Windows.Forms.Button buttonBrowsePlaySound;
        private System.Windows.Forms.OpenFileDialog openFileDialogPlay;
        private System.Windows.Forms.Label labelPauseSound;
        private System.Windows.Forms.Button buttonBrowsePauseSound;
        private System.Windows.Forms.Button buttonDownloadPauseSound;
        private System.Windows.Forms.OpenFileDialog openFileDialogPause;
        private System.Windows.Forms.Button buttonOpenColourDisplay;
        private System.Windows.Forms.Label labelPlayPauseInfo;
        private System.Windows.Forms.CheckBox checkBoxNarration;
    }
}


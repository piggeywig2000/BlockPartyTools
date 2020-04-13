using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockPartyTools
{
    public partial class FormMain : Form
    {
        Connection ServerConnection { get; set; } = null;
        MusicControl MusicController { get; set; } = null;
        AudioPlaybackEngine Mixer { get; } = new AudioPlaybackEngine(44100, 2);
        CachedVorbisSound PlaySound { get; set; } = null;
        CachedVorbisSound PauseSound { get; set; } = null;
        CachedVorbisSound NarrationSound { get; set; } = null;
        FormColourDisplay ColourDisplay { get; set; } = null;

        public FormMain()
        {
            InitializeComponent();
            if (!Directory.Exists("narration"))
                Directory.CreateDirectory("narration");
            if (!Directory.Exists("narration/GameStartEvents"))
                Directory.CreateDirectory("narration/GameStartEvents");
            if (!Directory.Exists("narration/RandomEvents"))
                Directory.CreateDirectory("narration/RandomEvents");
            if (!Directory.Exists("narration/WinEvents"))
                Directory.CreateDirectory("narration/WinEvents");
            if (!Directory.Exists("narration/DeathEvents"))
                Directory.CreateDirectory("narration/DeathEvents");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void StartServer()
        {
            LogMessage("Connecting...", Color.LightGreen);
            this.Refresh();

            ServerConnection = new Connection(currentSetUsername, trackBarRefeshRate.Value * 100);
            ServerConnection.OnDisposed += (sender, e) =>
            {
                StopServer();
            };
            ServerConnection.Connected += Connected;
            ServerConnection.LoadSongTriggered += LoadSongTriggered;
            ServerConnection.NarrationTriggered += NarrationTriggered;
            ServerConnection.ControlTriggered += ControlTriggered;
            ServerConnection.ColorTriggered += ColorTriggered;
            ServerConnection.EndGameTriggered += EndGameTriggered;
            ServerConnection.JoinedServer += OnJoinServer;
            ServerConnection.LeftServer += OnLeaveServer;
            ServerConnection.Start();

            buttonStart.Enabled = false;
            buttonStop.Enabled = true;

            checkBoxKeystrokes.Enabled = false;
            checkBoxInitialState.Enabled = false;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void StopServer()
        {
            if (ServerConnection == null) return;
            if (ServerConnection.IsDisposed) return;

            ServerConnection.Dispose();
            ServerConnection = null;

            buttonStart.Enabled = true;
            buttonStop.Enabled = false;

            checkBoxKeystrokes.Enabled = true;
            checkBoxInitialState.Enabled = checkBoxKeystrokes.Checked;

            LogMessage("Disconnected", Color.Red);
        }

        private string currentSetUsername = "";
        private void buttonSetUsername_Click(object sender, EventArgs e)
        {
            currentSetUsername = textBoxUsername.Text;

            //Disable start button if it's blank
            if (currentSetUsername == "")
            {
                buttonStart.Enabled = false;
                return;
            }
            else
            {
                buttonStart.Enabled = true;
            }

            //Set the username
            if (ServerConnection != null)
                ServerConnection.Username = currentSetUsername;

            LogMessage("Username set to " + currentSetUsername +
                "\nThe program will track information from the server that " + currentSetUsername + " is in.", Color.LightSkyBlue);
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            if (this.ActiveControl.Name != "buttonSetUsername")
            {
                textBoxUsername.Text = currentSetUsername;
            }
        }

        private void trackBarRefeshRate_Scroll(object sender, EventArgs e)
        {
            string secondsValue = (trackBarRefeshRate.Value / 10.0).ToString("F1");
            labelRefreshRateValue.Text = secondsValue + "s";
        }

        private int previousRefreshrateValue = 10;
        private void trackBarRefeshRate_MouseUp(object sender, MouseEventArgs e)
        {
            if (trackBarRefeshRate.Value == previousRefreshrateValue) return;
            previousRefreshrateValue = trackBarRefeshRate.Value;

            string secondsValue = (trackBarRefeshRate.Value / 10.0).ToString("F1");

            if (ServerConnection != null)
                ServerConnection.RefreshRate = trackBarRefeshRate.Value * 100;

            LogMessage("Refresh rate set to " + secondsValue +
                "\nThe program will check which server the target player is in every " + secondsValue + " seconds.", Color.LightSkyBlue);

            if (trackBarRefeshRate.Value < 10)
            {
                LogMessage(@"NOTE: This only affects how often the program checks which server you're in. It does NOT affect the responsiveness of the events that occur during the game, such as the music pausing or the colour changing.
The only reason to have this set really low is if you wanted to put unnecessary strain on The Hive's servers", Color.Red);
            }
        }

        private void checkBoxKeystrokes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxKeystrokes.Checked)
            {
                checkBoxInitialState.Enabled = true;
                LogMessage("Send play/pause keystroke enabled. The program will start and stop your music at the correct time during the game.", Color.LightSkyBlue);
            }
            else
            {
                checkBoxInitialState.Enabled = false;
                LogMessage("Send play/pause keystroke disabled. The program will leave your music alone.", Color.LightSkyBlue);
            }
        }

        private void checkBoxInitialState_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxInitialState.Checked)
            {
                checkBoxInitialState.Enabled = true;
                LogMessage("Initial playback state is set to playing. The program will assume this when sending the play/pause keystroke.", Color.LightSkyBlue);
            }
            else
            {
                checkBoxInitialState.Enabled = false;
                LogMessage("Initial playback state is set to paused. The program will assume this when sending the play/pause keystroke.", Color.LightSkyBlue);
            }
        }

        private void CreatePlayback()
        {
            if (checkBoxKeystrokes.Checked)
            {
                MusicController = new MusicControl(checkBoxInitialState.Checked);
            }
        }

        private void RemovePlayback()
        {
            if (checkBoxKeystrokes.Checked)
            {
                //Reset the existing one if it's there
                if (MusicController != null)
                {
                    if (checkBoxInitialState.Checked)
                    {
                        MusicController.Play();
                        LogMessage("Music resumed", Color.Orange);
                    }
                    else
                    {
                        MusicController.Pause();
                        LogMessage("Music paused", Color.Orange);
                    }
                }

                MusicController = null;
            }
        }

        private void ResetPlaySound()
        {
            if (PlaySound != null)
            {
                PlaySound = null;
                labelPlaySound.Text = "Play sound: None";
                LogMessage("Play sound is removed. Nothing will play when playback resumes.", Color.LightSkyBlue);
            }
        }

        private void buttonBrowsePlaySound_Click(object sender, EventArgs e)
        {
            if (openFileDialogPlay.ShowDialog() == DialogResult.OK)
            {
                //Try opening the file
                try
                {
                    string extension = Path.GetExtension(openFileDialogPlay.FileName);
                    switch (extension)
                    {
                        /*case ".wav":
                            PlaySound = new CachedVorbisSound(openFileDialogPlay.FileName);
                            break;
                        case ".aiff":
                            PlaySound = new CachedVorbisSound(openFileDialogPlay.FileName);
                            break;
                        case ".mp3":
                            PlaySound = new CachedVorbisSound(openFileDialogPlay.FileName);
                            break;*/
                        case ".ogg":
                            PlaySound = new CachedVorbisSound(openFileDialogPlay.FileName);
                            break;
                        /*case ".flac":
                            PlaySound = new CachedVorbisSound(openFileDialogPlay.FileName);
                            break;*/
                        default:
                            ResetPlaySound();
                            return;
                    }
                }
                catch (Exception)
                {
                    ResetPlaySound();
                    return;
                }

                labelPlaySound.Text = "Play sound: " + Path.GetFileName(openFileDialogPlay.FileName);
                LogMessage("Play sound is set to " + Path.GetFullPath(openFileDialogPlay.FileName) + ". This sound will play when playback resumes", Color.LightSkyBlue);

                Mixer.PlaySound(PlaySound);
            }
            else
            {
                ResetPlaySound();
                return;
            }
        }

        private void buttonDownloadPlaySound_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://static.hivemc.com/bp/sfx/cheer.ogg");
        }

        private void ResetPauseSound()
        {
            if (PauseSound != null)
            {
                PauseSound = null;
                labelPauseSound.Text = "Pause sound: None";
                LogMessage("Pause sound is removed. Nothing will play when playback pauses.", Color.LightSkyBlue);
            }
        }

        private void buttonBrowsePauseSound_Click(object sender, EventArgs e)
        {
            if (openFileDialogPause.ShowDialog() == DialogResult.OK)
            {
                //Try opening the file
                try
                {
                    string extension = Path.GetExtension(openFileDialogPause.FileName);
                    switch (extension)
                    {
                        /*case ".wav":
                            PauseSound = new CachedVorbisSound(openFileDialogPause.FileName);
                            break;
                        case ".aiff":
                            PauseSound = new CachedVorbisSound(openFileDialogPause.FileName);
                            break;
                        case ".mp3":
                            PauseSound = new CachedVorbisSound(openFileDialogPause.FileName);
                            break;*/
                        case ".ogg":
                            PauseSound = new CachedVorbisSound(openFileDialogPause.FileName);
                            break;
                        /*case ".flac":
                            PauseSound = new CachedVorbisSound(openFileDialogPause.FileName);
                            break;*/
                        default:
                            ResetPauseSound();
                            return;
                    }
                }
                catch (Exception)
                {
                    ResetPauseSound();
                    return;
                }

                //If we got to here, it opened successfully
                labelPauseSound.Text = "Pause sound: " + Path.GetFileName(openFileDialogPause.FileName);
                LogMessage("Pause sound is set to " + Path.GetFullPath(openFileDialogPause.FileName) + ". This sound will play when playback pauses", Color.LightSkyBlue);

                Mixer.PlaySound(PauseSound);
            }
            else
            {
                ResetPauseSound();
                return;
            }
        }

        private void buttonDownloadPauseSound_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://static.hivemc.com/bp/sfx/vinylstop.ogg");
        }

        private void checkBoxNarration_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNarration.Checked)
            {
                LogMessage("Villager narration enabled. You'll hear their wisdom during the game.", Color.SlateGray);
            }
            else
            {
                LogMessage("Villager narration enabled. You're missing out on their insightful commentary.", Color.SlateGray);
            }
        }

        private void buttonOpenColourDisplay_Click(object sender, EventArgs e)
        {
            if (ColourDisplay != null)
            {
                ColourDisplay.Close();
                ColourDisplay = null;
            }

            ColourDisplay = new FormColourDisplay();
            ColourDisplay.FormClosed += (formSender, closingArgs) =>
            {
                ColourDisplay = null;
            };
            ColourDisplay.Show();

            LogMessage("Colour display opened. This window stays in front of Minecraft (as long as fullscreen is off), so put it in a corner somewhere on your screen.", Color.SlateGray);
        }

        private void Connected(object sender, EventArgs e)
        {
            LogMessage("Connected", Color.Green);
        }

        private void LoadSongTriggered(object sender, LoadSongData data)
        {
            LogMessage("Received LoadSong:\nName: " + data.name + 
                "\nFilename: " + data.file +
                "\nSoundcloud ID: " + data.soundcloud, Color.SlateGray);

            //Create music controller (should be created already when we joined, but just to be on the safe side)
            CreatePlayback();

            HasGameEnded = false;
        }

        private void NarrationTriggered(object sender, NarrationData data)
        {
            LogMessage("Received Narration:\nType: " + data.type +
                "\nFile: " + data.file, Color.SlateGray);

            if (!checkBoxNarration.Checked) return;

            string path;
            switch (data.type)
            {
                case "gamestart":
                    path = "narration/GameStartEvents/" + data.file + ".ogg";
                    break;
                case "random":
                    path = "narration/RandomEvents/" + data.file + ".ogg";
                    break;
                case "win":
                    path = "narration/WinEvents/" + data.file + ".ogg";
                    break;
                case "death":
                    path = "narration/DeathEvents/" + data.file + ".ogg";
                    break;
                default:
                    return;
            }

            //Download file if it isn't already downloaded
            if (!File.Exists(path))
            {
                LogMessage("Downloading " + path, Color.Pink);

                using (WebClient client = new WebClient())
                {
                    client.DownloadFile("https://static.hivemc.com/bp/" + path, path);
                }
            }

            LogMessage("Playing " + path, Color.HotPink);

            //Play it
            Mixer.PlaySound(path);
        }

        private void ControlTriggered(object sender, ControlData data)
        {
            LogMessage("Received Control:\nPlay: " + data.play, Color.SlateGray);

            if (HasGameEnded) return;

            if (data.play == 0)
            {
                //Pause
                if (checkBoxKeystrokes.Checked) 
                {
                    MusicController.Pause();
                    LogMessage("Music paused", Color.Orange);
                }

                if (PauseSound != null)
                {
                    Mixer.PlaySound(PauseSound);
                }
            }
            else if (data.play == 1)
            {
                //Play
                if (checkBoxKeystrokes.Checked)
                {
                    MusicController.Play();
                    LogMessage("Music resumed", Color.Orange);
                }
                
                if (PlaySound != null)
                {
                    Mixer.PlaySound(PlaySound);
                }

                if (ColourDisplay != null)
                {
                    ColourDisplay.ClearColour();
                }
            }
        }

        private void ColorTriggered(object sender, ColorData data)
        {
            LogMessage("Received Color:\nColor ID: " + data.colorid, Color.SlateGray);

            if (ColourDisplay != null)
            {
                ColourDisplay.SetColour(data.colorid);
            }
        }

        private bool HasGameEnded = false;
        private void EndGameTriggered(object sender, EndGameData data)
        {
            LogMessage("Received EndGame:\nDo It: " + data.doit, Color.SlateGray);

            if (ColourDisplay != null)
            {
                ColourDisplay.ClearColour();
            }

            //Remove music controller
            RemovePlayback();

            HasGameEnded = true;
        }

        private void OnJoinServer(object sender, string sid)
        {
            LogMessage("Joined server " + sid, Color.Yellow);

            //Create music controller
            CreatePlayback();

            HasGameEnded = false;
        }

        private void OnLeaveServer(object sender, string sid)
        {
            LogMessage("Left server " + sid, Color.Yellow);

            //Remove music controller
            RemovePlayback();

            if (ColourDisplay != null)
            {
                ColourDisplay.ClearColour();
            }

            HasGameEnded = false;
        }

        private Queue<LoggedMessage> MessagesToLog = new Queue<LoggedMessage>();
        public void LogMessage(string message, Color color)
        {
            MessagesToLog.Enqueue(new LoggedMessage { Text = message, ForeColor = color });
        }

        private void timerLogger_Tick(object sender, EventArgs e)
        {
            if (MessagesToLog.Count == 0) return;

            LoggedMessage messageToLog = MessagesToLog.Dequeue();

            int startPos = richTextBoxLog.TextLength;
            richTextBoxLog.AppendText("\n\n" + messageToLog.Text);
            richTextBoxLog.Select(startPos, richTextBoxLog.TextLength - startPos);
            richTextBoxLog.SelectionColor = messageToLog.ForeColor;
            richTextBoxLog.DeselectAll();

            richTextBoxLog.SelectionStart = richTextBoxLog.TextLength;
            richTextBoxLog.ScrollToCaret();
            richTextBoxLog.DeselectAll();
        }
    }
}

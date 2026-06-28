using PeacockAutoUpdater.Models;
using PeacockAutoUpdater.Services;
using PeacockAutoUpdater.Forms;
using System.Windows.Forms;

namespace PeacockAutoUpdater
{
    public partial class MainForm : Form
    {
        private ConfigService _configService;
        private HTTPService _httpService;
        private UpdateService _updateService;
        private bool _noDownload;
        private (GithubResultType, string) _lastResult;

        public MainForm(bool noDownload, ConfigService configService, HTTPService httpService, (GithubResultType, string) initialResult)
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            _noDownload = noDownload;
            _configService = configService;
            _httpService = httpService;
            _updateService = new UpdateService(_configService);
            _lastResult = initialResult;

            ProcessReleaseResult(_lastResult);

            //do this last to make it apply to already appended text    
            richTextBox_version.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void ProcessReleaseResult((GithubResultType, string) releaseResult)
        {
            if (_configService._config == null) return;

            switch (releaseResult.Item1)
            {
                case GithubResultType.Error:
                    MessageBox.Show($"Error checking updates: {releaseResult.Item2}");
                    UpdateVersionRichTextBox(_configService._config.LastPeacockVersion, "Error");
                    break;
                case GithubResultType.SameVersion:
                    UpdateVersionRichTextBox(_configService._config.LastPeacockVersion, _configService._config.LastPeacockVersion);
                    break;
                case GithubResultType.NewerVersion:
                    UpdateVersionRichTextBox(_configService._config.LastPeacockVersion, releaseResult.Item2);
                    button_update.Enabled = true;
                    break;
            }
        }

        public async void CheckLatestRelease()
        {
            button_resync.Enabled = false;

            var releaseResult = await _httpService.GetLatestRelease(_configService, _noDownload);
            _lastResult = releaseResult;
            ProcessReleaseResult(_lastResult);

            button_resync.Enabled = true;
        }

        public void UpdateVersionRichTextBox(string currentVersion, string newestVersion)
        {
            richTextBox_version.Clear();

            richTextBox_version.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox_version.AppendText("\n\n");
            richTextBox_version.SelectionColor = Color.White;
            richTextBox_version.AppendText("Current Peacock Version: ");

            if (currentVersion == newestVersion)
            {
                richTextBox_version.SelectionColor = Color.DarkGreen;
            }
            else
            {
                richTextBox_version.SelectionColor = Color.Firebrick;
            }
            richTextBox_version.SelectionFont = new Font(richTextBox_version.Font, FontStyle.Bold);
            richTextBox_version.AppendText(currentVersion);
            richTextBox_version.AppendText("\n\n");

            richTextBox_version.SelectionFont = new Font(richTextBox_version.Font, FontStyle.Regular);
            richTextBox_version.SelectionColor = Color.White;
            richTextBox_version.AppendText("Newest Peacock Version: ");

            richTextBox_version.SelectionFont = new Font(richTextBox_version.Font, FontStyle.Bold);
            richTextBox_version.AppendText(newestVersion);
        }

        private void richTextBox_version_Enter(object sender, EventArgs e)
        {
            richTextBox_version.Cursor = Cursors.Arrow;
            this.ActiveControl = null;
        }

        private void button_settings_MouseHover(object sender, EventArgs e)
        {
            button_settings.BackgroundImage = Properties.Resources.gear_dark;
        }

        private void button_settings_MouseLeave(object sender, EventArgs e)
        {
            button_settings.BackgroundImage = Properties.Resources.gear;
        }

        private void button_settings_MouseMove(object sender, MouseEventArgs e)
        {
            if (button_settings.ClientRectangle.Contains(e.Location))
            {
                if (button_settings.BackgroundImage != Properties.Resources.gear_dark)
                {
                    button_settings.BackgroundImage = Properties.Resources.gear_dark;
                }
            }
        }

        private void button_resync_MouseHover(object sender, EventArgs e)
        {
            button_resync.BackgroundImage = Properties.Resources.rotate_ccw_grey;
        }

        private void button_resync_MouseLeave(object sender, EventArgs e)
        {
            button_resync.BackgroundImage = Properties.Resources.rotate_ccw;
        }

        private void button_resync_MouseMove(object sender, MouseEventArgs e)
        {
            if (button_resync.ClientRectangle.Contains(e.Location))
            {
                if (button_resync.BackgroundImage != Properties.Resources.rotate_ccw_grey)
                {
                    button_resync.BackgroundImage = Properties.Resources.rotate_ccw_grey;
                }
            }
        }

        //safetylayer, if mouse moves outside button too fast and isnt captured doing so, then movement on form is caught
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Point clientMousePos = button_settings.PointToClient(Cursor.Position);
            if (!button_settings.ClientRectangle.Contains(clientMousePos))
            {
                if (button_settings.BackgroundImage != Properties.Resources.gear)
                {
                    button_settings.BackgroundImage = Properties.Resources.gear;
                }
            }
        }

        private void button_settings_Click(object sender, EventArgs e)
        {
            if (_configService._config == null)
            {
                throw new Exception("Config could not be initialised.");
            }

            SettingsForm settingsForm = new SettingsForm(_configService._config.PeacockRootFolder, _configService);
            settingsForm.ShowDialog();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            bool preserveUserData = true;

            if (_configService._config == null)
            {
                throw new Exception("Config could not be initialised.");
            }

            if (!Directory.Exists(_configService._config.PeacockRootFolder))
            {
                throw new Exception("Peacock Root Folder doesnt exist or wasnt selected! Please go to Settings and set the path correctly.");
            }

            using (var dialog = new UpdateConfirmForm())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    preserveUserData = dialog.PreserveData;
                    _configService.SetPreserveData(dialog.PreserveData);
                }
                else
                {
                    return;
                }
            }

            _updateService.UpdatePeacock(preserveUserData);
            _configService.SetLastPeacockVersion(_lastResult.Item2);
            Resync();
        }

        private void button_resync_Click(object sender, EventArgs e)
        {
            Resync();
        }

        public void Resync()
        {
            UpdateVersionRichTextBox(_configService._config.LastPeacockVersion, _lastResult.Item2);

            if (_lastResult.Item1 != GithubResultType.NewerVersion)
            {
                CheckLatestRelease();
            }
        }
    }
}

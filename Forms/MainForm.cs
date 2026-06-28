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
        public bool _noDownload;

        public MainForm(bool noDownload)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _noDownload = noDownload;
            SetupComponents();
            richTextBox_version.SelectionAlignment = HorizontalAlignment.Center;
        }

        public async void SetupComponents()
        {
            _configService = new ConfigService();
            _httpService = new HTTPService();
            _updateService = new UpdateService();

            if (_configService._config == null)
            {
                throw new Exception("Config could not be initialised.");
            }

            (GithubResultType, string) releaseResult = await _httpService.GetLatestRelease(_configService._config.PeacockGithubURL, _configService._config.LastPeacockVersion, _configService._config.TempPath, _noDownload);

            switch (releaseResult.Item1)
            {
                case GithubResultType.Error:
                    MessageBox.Show($"Error: {releaseResult.Item2}");
                    break;
                case GithubResultType.SameVersion:
                    UpdateVersionRichTextBox(_configService._config.LastPeacockVersion, _configService._config.LastPeacockVersion);
                    break;
                case GithubResultType.NewerVersion:
                    UpdateVersionRichTextBox(_configService._config.LastPeacockVersion, releaseResult.Item2);
                    _configService.SetLastPeacockVersion(releaseResult.Item2);
                    button_update.Enabled = true;
                    break;
            }
        }

        public void UpdateVersionRichTextBox(string currentVersion, string newestVersion)
        {
            richTextBox_version.Clear();

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

        //Safetylayer, if mouse moves outside button too fast and isnt captured doing so, then movement on form is caught
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

        }
    }
}

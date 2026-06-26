using PeacockAutoUpdater.Models;
using PeacockAutoUpdater.Services;

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
            _noDownload = noDownload;
            SetupComponents();
        }

        public async void SetupComponents()
        {
            _configService = new ConfigService();
            _httpService = new HTTPService();
            _updateService = new UpdateService();

            if(_configService._config == null)
            {
                throw new Exception("Config could not be initialised.");
            }

            (bool, string) releaseResult = await _httpService.GetLatestRelease(_configService._config.PeacockGithubURL, _configService._config.LastPeacockVersion, _configService._config.TempPath, _noDownload);
            if (!releaseResult.Item1)
            {
                throw new Exception($"Error: {releaseResult.Item2}");
            }

            //load mainform completely, with button to do update (seperate window opens to confirm specifics (preservedata and stuff)) and then updateservice is called after results are returned here
            UpdateVersionRichTextBox(_configService._config.LastPeacockVersion, releaseResult.Item2);

            //do this last, cause otherwise the display is false, maybe we later put this into the update trigger method
            _configService.SetLastPeacockVersion(releaseResult.Item2);
        }

        public void UpdateVersionRichTextBox(string currentVersion, string newestVersion)
        {
            richTextBox_version.Clear();

            richTextBox_version.SelectionColor = Color.Black;
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
            richTextBox_version.SelectionColor = Color.Black;
            richTextBox_version.AppendText("Newest Peacock Version: ");

            richTextBox_version.SelectionFont = new Font(richTextBox_version.Font, FontStyle.Bold);
            richTextBox_version.SelectionColor = Color.Black;
            richTextBox_version.AppendText(newestVersion);
        }
    }
}

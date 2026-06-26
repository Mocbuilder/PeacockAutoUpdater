using PeacockAutoUpdater.Models;
using PeacockAutoUpdater.Services;

namespace PeacockAutoUpdater
{
    public partial class MainForm : Form
    {
        private ConfigService _configService;
        private HTTPService _httpService;
        private UpdateService _updateService;

        public MainForm()
        {
            InitializeComponent();
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

            (bool, string) releaseResult = await _httpService.GetLatestRelease(_configService._config.PeacockGithubURL, _configService._config.LastPeacockVersion, _configService._config.TempPath);
            if (!releaseResult.Item1)
            {
                throw new Exception($"Error: {releaseResult.Item2}");
            }

            _configService.SetLastPeacockVersion(releaseResult.Item2.Substring(1));

            //load mainform completely, with button to do update (seperate window opens to confirm specifics (preservedata and stuff)) and then updateservice is called after results are returned here
        }
    }
}

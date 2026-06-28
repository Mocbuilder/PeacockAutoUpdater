using PeacockAutoUpdater.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeacockAutoUpdater.Forms
{
    public partial class SettingsForm : Form
    {
        private string PeacockRootFolder { get; set; }
        private ConfigService _configService { get; set; }
        private bool settingsChanged = false;

        public SettingsForm(string peacockRootFolder, ConfigService configService)
        {
            InitializeComponent();
            PeacockRootFolder = peacockRootFolder;
            _configService = configService;
            textBox_peacockRootFolder.Text = PeacockRootFolder;
            fbd_main.SelectedPath = PeacockRootFolder;
        }

        private void UpdatePeacockRootFolder(string folder)
        {
            PeacockRootFolder = folder;
            textBox_peacockRootFolder.Text = folder;
            
        }

        private bool ValidateSelectedSettings()
        {
            if (!File.Exists(Path.Combine(PeacockRootFolder, "PeacockPatcher.exe")) || !File.Exists(Path.Combine(PeacockRootFolder, "Start Server.cmd")))
            {
                return false;
            }

            return true;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (!ValidateSelectedSettings())
            {
                MessageBox.Show("The selected Settings are not valid!", "Settings not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (settingsChanged)
            {
                _configService.SetPeacockRootFolder(PeacockRootFolder);
            }
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_openPeacockRootFolder_Click(object sender, EventArgs e)
        {
            settingsChanged = true;
            fbd_main.ShowDialog();
            UpdatePeacockRootFolder(fbd_main.SelectedPath);
        }
    }
}

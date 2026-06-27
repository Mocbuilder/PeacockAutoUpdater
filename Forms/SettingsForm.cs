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

        public SettingsForm(string peacockRootFolder)
        {
            InitializeComponent();
            PeacockRootFolder = peacockRootFolder;
            textBox_peacockRootFolder.Text = PeacockRootFolder;
        }
    }
}

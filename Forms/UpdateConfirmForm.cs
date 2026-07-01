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
    public partial class UpdateConfirmForm : Form
    {
        public bool PreserveData => checkBox_preserveData.Checked;
        public UpdateConfirmForm(bool preserveDataCashed)
        {
            InitializeComponent();
            checkBox_preserveData.Checked = preserveDataCashed;

            this.StartPosition = FormStartPosition.CenterScreen;

            ToolTip labelToolTip = new ToolTip();
            labelToolTip.ToolTipTitle = "Information";
            labelToolTip.UseFading = true;
            labelToolTip.IsBalloon = true;
            labelToolTip.SetToolTip(checkBox_preserveData, "Preserves contractSessinons, userdata and Plugins folder.");
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

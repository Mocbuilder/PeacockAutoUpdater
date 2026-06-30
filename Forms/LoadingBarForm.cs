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
    public partial class LoadingBarForm : Form
    {
        private int speed = 15;

        public LoadingBarForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        private void Timer1_Tick(object? sender, EventArgs e)
        {
            panel_LoadingBlock.Left += speed;

            // If it hits the right edge or left edge, loop it around
            if (panel_LoadingBlock.Left > panel_Track.Width)
            {
                panel_LoadingBlock.Left = -panel_LoadingBlock.Width;
            }
        }
    }
}

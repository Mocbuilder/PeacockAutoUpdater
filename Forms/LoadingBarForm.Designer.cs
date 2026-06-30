namespace PeacockAutoUpdater.Forms
{
    partial class LoadingBarForm
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
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            label_title = new Label();
            panel_Track = new Panel();
            panel_LoadingBlock = new Panel();
            timer1 = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            panel_Track.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label_title, 0, 0);
            tableLayoutPanel1.Controls.Add(panel_Track, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.Size = new Size(386, 165);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label_title
            // 
            label_title.Anchor = AnchorStyles.None;
            label_title.AutoSize = true;
            label_title.Font = new Font("Verdana", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_title.Location = new Point(132, 12);
            label_title.Name = "label_title";
            label_title.Size = new Size(122, 25);
            label_title.TabIndex = 1;
            label_title.Text = "Loading...";
            // 
            // panel_Track
            // 
            panel_Track.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel_Track.BorderStyle = BorderStyle.FixedSingle;
            panel_Track.Controls.Add(panel_LoadingBlock);
            panel_Track.Location = new Point(15, 89);
            panel_Track.Margin = new Padding(15, 3, 15, 3);
            panel_Track.Name = "panel_Track";
            panel_Track.Size = new Size(356, 35);
            panel_Track.TabIndex = 1;
            // 
            // panel_LoadingBlock
            // 
            panel_LoadingBlock.BackColor = SystemColors.Highlight;
            panel_LoadingBlock.Location = new Point(3, 0);
            panel_LoadingBlock.Name = "panel_LoadingBlock";
            panel_LoadingBlock.Size = new Size(53, 35);
            panel_LoadingBlock.TabIndex = 0;
            // 
            // LoadingBarForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(386, 165);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoadingBarForm";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "LoadingBarForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel_Track.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel_Track;
        private Panel panel_LoadingBlock;
        private Label label_title;
        private System.Windows.Forms.Timer timer1;
    }
}
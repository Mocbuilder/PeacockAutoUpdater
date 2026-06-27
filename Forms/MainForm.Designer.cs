namespace PeacockAutoUpdater
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_update = new Button();
            button_settings = new Button();
            tableLayoutPanel_main = new TableLayoutPanel();
            richTextBox_version = new RichTextBox();
            tableLayoutPanel_main.SuspendLayout();
            SuspendLayout();
            // 
            // button_update
            // 
            button_update.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button_update.BackColor = SystemColors.ControlDark;
            button_update.Enabled = false;
            button_update.FlatStyle = FlatStyle.Flat;
            button_update.Font = new Font("Verdana", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_update.Location = new Point(15, 333);
            button_update.Margin = new Padding(15, 3, 15, 3);
            button_update.Name = "button_update";
            button_update.Size = new Size(262, 34);
            button_update.TabIndex = 1;
            button_update.Text = "UPDATE";
            button_update.UseVisualStyleBackColor = false;
            // 
            // button_settings
            // 
            button_settings.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_settings.BackColor = Color.Transparent;
            button_settings.BackgroundImage = Properties.Resources.gear;
            button_settings.BackgroundImageLayout = ImageLayout.Zoom;
            button_settings.FlatAppearance.BorderSize = 0;
            button_settings.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button_settings.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button_settings.FlatStyle = FlatStyle.Flat;
            button_settings.Location = new Point(328, 15);
            button_settings.Margin = new Padding(3, 15, 15, 3);
            button_settings.Name = "button_settings";
            button_settings.Size = new Size(75, 75);
            button_settings.TabIndex = 2;
            button_settings.UseVisualStyleBackColor = false;
            button_settings.Click += button_settings_Click;
            button_settings.MouseLeave += button_settings_MouseLeave;
            button_settings.MouseHover += button_settings_MouseHover;
            button_settings.MouseMove += button_settings_MouseMove;
            // 
            // tableLayoutPanel_main
            // 
            tableLayoutPanel_main.ColumnCount = 2;
            tableLayoutPanel_main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel_main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel_main.Controls.Add(button_update, 0, 1);
            tableLayoutPanel_main.Controls.Add(richTextBox_version, 0, 0);
            tableLayoutPanel_main.Controls.Add(button_settings, 1, 0);
            tableLayoutPanel_main.Dock = DockStyle.Fill;
            tableLayoutPanel_main.Location = new Point(0, 0);
            tableLayoutPanel_main.Name = "tableLayoutPanel_main";
            tableLayoutPanel_main.RowCount = 2;
            tableLayoutPanel_main.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_main.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_main.Size = new Size(418, 467);
            tableLayoutPanel_main.TabIndex = 3;
            // 
            // richTextBox_version
            // 
            richTextBox_version.BackColor = SystemColors.ControlDarkDark;
            richTextBox_version.BorderStyle = BorderStyle.None;
            richTextBox_version.Dock = DockStyle.Fill;
            richTextBox_version.Font = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox_version.Location = new Point(3, 3);
            richTextBox_version.Name = "richTextBox_version";
            richTextBox_version.ReadOnly = true;
            richTextBox_version.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox_version.Size = new Size(286, 227);
            richTextBox_version.TabIndex = 3;
            richTextBox_version.Text = "";
            richTextBox_version.Enter += richTextBox_version_Enter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(418, 467);
            Controls.Add(tableLayoutPanel_main);
            Name = "MainForm";
            Text = "Peacock Auto Updater";
            tableLayoutPanel_main.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button button_update;
        private Button button_settings;
        private TableLayoutPanel tableLayoutPanel_main;
        private RichTextBox richTextBox_version;
    }
}

namespace PeacockAutoUpdater.Forms
{
    partial class SettingsForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            button_ok = new Button();
            button_cancel = new Button();
            label_peacockfolder_title = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            button_openPeacockRootFolder = new Button();
            textBox_peacockRootFolder = new TextBox();
            fbd_main = new FolderBrowserDialog();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(button_ok, 0, 2);
            tableLayoutPanel1.Controls.Add(button_cancel, 1, 2);
            tableLayoutPanel1.Controls.Add(label_peacockfolder_title, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // button_ok
            // 
            button_ok.Anchor = AnchorStyles.Bottom;
            button_ok.BackColor = SystemColors.ControlDark;
            button_ok.FlatStyle = FlatStyle.Flat;
            button_ok.Font = new Font("Verdana", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_ok.Location = new Point(144, 401);
            button_ok.Margin = new Padding(3, 3, 3, 15);
            button_ok.Name = "button_ok";
            button_ok.Size = new Size(112, 34);
            button_ok.TabIndex = 0;
            button_ok.Text = "OK";
            button_ok.UseVisualStyleBackColor = false;
            button_ok.Click += button_ok_Click;
            // 
            // button_cancel
            // 
            button_cancel.Anchor = AnchorStyles.Bottom;
            button_cancel.BackColor = SystemColors.ControlDark;
            button_cancel.FlatStyle = FlatStyle.Flat;
            button_cancel.Font = new Font("Verdana", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_cancel.Location = new Point(544, 401);
            button_cancel.Margin = new Padding(3, 3, 3, 15);
            button_cancel.Name = "button_cancel";
            button_cancel.Size = new Size(112, 34);
            button_cancel.TabIndex = 1;
            button_cancel.Text = "CANCEL";
            button_cancel.UseVisualStyleBackColor = false;
            button_cancel.Click += button_cancel_Click;
            // 
            // label_peacockfolder_title
            // 
            label_peacockfolder_title.Anchor = AnchorStyles.None;
            label_peacockfolder_title.AutoSize = true;
            label_peacockfolder_title.Font = new Font("Verdana", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_peacockfolder_title.Location = new Point(79, 211);
            label_peacockfolder_title.Name = "label_peacockfolder_title";
            label_peacockfolder_title.Size = new Size(242, 25);
            label_peacockfolder_title.TabIndex = 2;
            label_peacockfolder_title.Text = "Peacock Root Folder";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.Controls.Add(button_openPeacockRootFolder, 1, 0);
            tableLayoutPanel2.Controls.Add(textBox_peacockRootFolder, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(403, 152);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(394, 143);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // button_openPeacockRootFolder
            // 
            button_openPeacockRootFolder.Anchor = AnchorStyles.None;
            button_openPeacockRootFolder.BackColor = SystemColors.ControlDark;
            button_openPeacockRootFolder.FlatStyle = FlatStyle.Flat;
            button_openPeacockRootFolder.Font = new Font("Verdana", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_openPeacockRootFolder.Location = new Point(278, 54);
            button_openPeacockRootFolder.Name = "button_openPeacockRootFolder";
            button_openPeacockRootFolder.Size = new Size(112, 34);
            button_openPeacockRootFolder.TabIndex = 0;
            button_openPeacockRootFolder.Text = "...";
            button_openPeacockRootFolder.UseVisualStyleBackColor = false;
            button_openPeacockRootFolder.Click += button_openPeacockRootFolder_Click;
            // 
            // textBox_peacockRootFolder
            // 
            textBox_peacockRootFolder.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_peacockRootFolder.BackColor = SystemColors.ControlDark;
            textBox_peacockRootFolder.BorderStyle = BorderStyle.FixedSingle;
            textBox_peacockRootFolder.Font = new Font("Verdana", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            textBox_peacockRootFolder.Location = new Point(3, 57);
            textBox_peacockRootFolder.Margin = new Padding(3, 3, 15, 3);
            textBox_peacockRootFolder.Name = "textBox_peacockRootFolder";
            textBox_peacockRootFolder.ReadOnly = true;
            textBox_peacockRootFolder.Size = new Size(257, 29);
            textBox_peacockRootFolder.TabIndex = 1;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "SettingsForm";
            ShowIcon = false;
            Text = "PeacockAutoUpdater Settings";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button button_ok;
        private Button button_cancel;
        private Label label_peacockfolder_title;
        private TableLayoutPanel tableLayoutPanel2;
        private Button button_openPeacockRootFolder;
        private TextBox textBox_peacockRootFolder;
        private FolderBrowserDialog fbd_main;
    }
}
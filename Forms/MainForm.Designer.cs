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
            button1 = new Button();
            button2 = new Button();
            tableLayoutPanel_main = new TableLayoutPanel();
            richTextBox_version = new RichTextBox();
            tableLayoutPanel_main.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(241, 236);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(479, 3);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 2;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel_main
            // 
            tableLayoutPanel_main.ColumnCount = 3;
            tableLayoutPanel_main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_main.Controls.Add(button1, 1, 1);
            tableLayoutPanel_main.Controls.Add(button2, 2, 0);
            tableLayoutPanel_main.Controls.Add(richTextBox_version, 1, 0);
            tableLayoutPanel_main.Dock = DockStyle.Fill;
            tableLayoutPanel_main.Location = new Point(0, 0);
            tableLayoutPanel_main.Name = "tableLayoutPanel_main";
            tableLayoutPanel_main.RowCount = 2;
            tableLayoutPanel_main.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_main.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_main.Size = new Size(715, 467);
            tableLayoutPanel_main.TabIndex = 3;
            // 
            // richTextBox_version
            // 
            richTextBox_version.BackColor = SystemColors.Control;
            richTextBox_version.BorderStyle = BorderStyle.None;
            richTextBox_version.Dock = DockStyle.Fill;
            richTextBox_version.Font = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox_version.Location = new Point(241, 3);
            richTextBox_version.Name = "richTextBox_version";
            richTextBox_version.ReadOnly = true;
            richTextBox_version.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox_version.Size = new Size(232, 227);
            richTextBox_version.TabIndex = 3;
            richTextBox_version.Text = "";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(715, 467);
            Controls.Add(tableLayoutPanel_main);
            Name = "MainForm";
            Text = "Peacock Auto Updater";
            tableLayoutPanel_main.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Button button2;
        private TableLayoutPanel tableLayoutPanel_main;
        private RichTextBox richTextBox_version;
    }
}

namespace PeacockAutoUpdater.Forms
{
    partial class UpdateConfirmForm
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
            tableLayoutPanel_buttons = new TableLayoutPanel();
            button_cancel = new Button();
            button_ok = new Button();
            checkBox_preserveData = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel_buttons.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel_buttons, 0, 2);
            tableLayoutPanel1.Controls.Add(checkBox_preserveData, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(339, 170);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel_buttons
            // 
            tableLayoutPanel_buttons.ColumnCount = 2;
            tableLayoutPanel_buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_buttons.Controls.Add(button_cancel, 1, 0);
            tableLayoutPanel_buttons.Controls.Add(button_ok, 0, 0);
            tableLayoutPanel_buttons.Dock = DockStyle.Fill;
            tableLayoutPanel_buttons.Location = new Point(3, 115);
            tableLayoutPanel_buttons.Name = "tableLayoutPanel_buttons";
            tableLayoutPanel_buttons.RowCount = 1;
            tableLayoutPanel_buttons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_buttons.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_buttons.Size = new Size(333, 52);
            tableLayoutPanel_buttons.TabIndex = 4;
            // 
            // button_cancel
            // 
            button_cancel.Anchor = AnchorStyles.Bottom;
            button_cancel.BackColor = SystemColors.ControlDark;
            button_cancel.FlatStyle = FlatStyle.Flat;
            button_cancel.Font = new Font("Verdana", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_cancel.Location = new Point(193, 3);
            button_cancel.Margin = new Padding(3, 3, 3, 15);
            button_cancel.Name = "button_cancel";
            button_cancel.Size = new Size(112, 34);
            button_cancel.TabIndex = 1;
            button_cancel.Text = "CANCEL";
            button_cancel.UseVisualStyleBackColor = false;
            button_cancel.Click += button_cancel_Click;
            // 
            // button_ok
            // 
            button_ok.Anchor = AnchorStyles.Bottom;
            button_ok.BackColor = SystemColors.ControlDark;
            button_ok.FlatStyle = FlatStyle.Flat;
            button_ok.Font = new Font("Verdana", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button_ok.Location = new Point(27, 3);
            button_ok.Margin = new Padding(3, 3, 3, 15);
            button_ok.Name = "button_ok";
            button_ok.Size = new Size(112, 34);
            button_ok.TabIndex = 0;
            button_ok.Text = "OK";
            button_ok.UseVisualStyleBackColor = false;
            button_ok.Click += button_ok_Click;
            // 
            // checkBox_preserveData
            // 
            checkBox_preserveData.Anchor = AnchorStyles.None;
            checkBox_preserveData.AutoSize = true;
            checkBox_preserveData.Checked = true;
            checkBox_preserveData.CheckState = CheckState.Checked;
            checkBox_preserveData.Font = new Font("Verdana", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBox_preserveData.Location = new Point(62, 69);
            checkBox_preserveData.Name = "checkBox_preserveData";
            checkBox_preserveData.Size = new Size(215, 29);
            checkBox_preserveData.TabIndex = 3;
            checkBox_preserveData.Text = "Preserve Data ?";
            checkBox_preserveData.UseVisualStyleBackColor = true;
            // 
            // UpdateConfirmForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(339, 170);
            ControlBox = false;
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "UpdateConfirmForm";
            ShowInTaskbar = false;
            Text = "Confirm Update ?";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel_buttons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button button_ok;
        private Button button_cancel;
        private CheckBox checkBox_preserveData;
        private TableLayoutPanel tableLayoutPanel_buttons;
    }
}
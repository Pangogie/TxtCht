namespace Text_Client
{
    partial class OptionsForm
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.UserColorButton = new System.Windows.Forms.Button();
            this.ServerColorButton = new System.Windows.Forms.Button();
            this.TextFontButton = new System.Windows.Forms.Button();
            this.TimestampCheckbox = new System.Windows.Forms.CheckBox();
            this.TimestampLabel = new System.Windows.Forms.Label();
            this.UserFontLabel = new System.Windows.Forms.Label();
            this.ServerColorPanel = new System.Windows.Forms.Panel();
            this.UserColorPanel = new System.Windows.Forms.Panel();
            this.FormColorButton = new System.Windows.Forms.Button();
            this.FormColorPanel = new System.Windows.Forms.Panel();
            this.ServerTextLabel = new System.Windows.Forms.Label();
            this.UserTextLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.OptionsGroupbox = new System.Windows.Forms.GroupBox();
            this.NameColorButton = new System.Windows.Forms.Button();
            this.NameColorPanel = new System.Windows.Forms.Panel();
            this.NameColorLabel = new System.Windows.Forms.Label();
            this.ButtonsGroupbox = new System.Windows.Forms.GroupBox();
            this.OptionsGroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // fontDialog1
            // 
            this.fontDialog1.Color = System.Drawing.SystemColors.ControlText;
            // 
            // UserColorButton
            // 
            this.UserColorButton.Location = new System.Drawing.Point(112, 178);
            this.UserColorButton.Name = "UserColorButton";
            this.UserColorButton.Size = new System.Drawing.Size(75, 23);
            this.UserColorButton.TabIndex = 0;
            this.UserColorButton.Text = "Change";
            this.UserColorButton.UseVisualStyleBackColor = true;
            this.UserColorButton.Click += new System.EventHandler(this.UserColorButton_Click);
            // 
            // ServerColorButton
            // 
            this.ServerColorButton.Location = new System.Drawing.Point(112, 137);
            this.ServerColorButton.Name = "ServerColorButton";
            this.ServerColorButton.Size = new System.Drawing.Size(75, 23);
            this.ServerColorButton.TabIndex = 1;
            this.ServerColorButton.Text = "Change";
            this.ServerColorButton.UseVisualStyleBackColor = true;
            this.ServerColorButton.Click += new System.EventHandler(this.ServerColorButton_Click);
            // 
            // TextFontButton
            // 
            this.TextFontButton.Enabled = false;
            this.TextFontButton.Location = new System.Drawing.Point(112, 96);
            this.TextFontButton.Name = "TextFontButton";
            this.TextFontButton.Size = new System.Drawing.Size(75, 23);
            this.TextFontButton.TabIndex = 1;
            this.TextFontButton.Text = "Change";
            this.TextFontButton.UseVisualStyleBackColor = true;
            this.TextFontButton.Click += new System.EventHandler(this.TextFontButton_Click);
            // 
            // TimestampCheckbox
            // 
            this.TimestampCheckbox.AutoSize = true;
            this.TimestampCheckbox.Location = new System.Drawing.Point(112, 14);
            this.TimestampCheckbox.Name = "TimestampCheckbox";
            this.TimestampCheckbox.Size = new System.Drawing.Size(77, 17);
            this.TimestampCheckbox.TabIndex = 2;
            this.TimestampCheckbox.Text = "Timestamp";
            this.TimestampCheckbox.UseVisualStyleBackColor = true;
            this.TimestampCheckbox.CheckedChanged += new System.EventHandler(this.TimestampCheckbox_CheckedChanged);
            // 
            // TimestampLabel
            // 
            this.TimestampLabel.Location = new System.Drawing.Point(19, 10);
            this.TimestampLabel.Name = "TimestampLabel";
            this.TimestampLabel.Size = new System.Drawing.Size(87, 23);
            this.TimestampLabel.TabIndex = 3;
            this.TimestampLabel.Text = "Timestamp";
            this.TimestampLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserFontLabel
            // 
            this.UserFontLabel.Location = new System.Drawing.Point(19, 83);
            this.UserFontLabel.Name = "UserFontLabel";
            this.UserFontLabel.Size = new System.Drawing.Size(87, 48);
            this.UserFontLabel.TabIndex = 4;
            this.UserFontLabel.Text = "Text Font";
            this.UserFontLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServerColorPanel
            // 
            this.ServerColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServerColorPanel.Location = new System.Drawing.Point(77, 137);
            this.ServerColorPanel.Name = "ServerColorPanel";
            this.ServerColorPanel.Size = new System.Drawing.Size(29, 23);
            this.ServerColorPanel.TabIndex = 5;
            // 
            // UserColorPanel
            // 
            this.UserColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserColorPanel.Location = new System.Drawing.Point(77, 178);
            this.UserColorPanel.Name = "UserColorPanel";
            this.UserColorPanel.Size = new System.Drawing.Size(29, 23);
            this.UserColorPanel.TabIndex = 5;
            // 
            // FormColorButton
            // 
            this.FormColorButton.Location = new System.Drawing.Point(112, 220);
            this.FormColorButton.Name = "FormColorButton";
            this.FormColorButton.Size = new System.Drawing.Size(75, 23);
            this.FormColorButton.TabIndex = 0;
            this.FormColorButton.Text = "Change";
            this.FormColorButton.UseVisualStyleBackColor = true;
            this.FormColorButton.Click += new System.EventHandler(this.FormColorButton_Click);
            // 
            // FormColorPanel
            // 
            this.FormColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormColorPanel.Location = new System.Drawing.Point(77, 220);
            this.FormColorPanel.Name = "FormColorPanel";
            this.FormColorPanel.Size = new System.Drawing.Size(29, 23);
            this.FormColorPanel.TabIndex = 5;
            // 
            // ServerTextLabel
            // 
            this.ServerTextLabel.AutoSize = true;
            this.ServerTextLabel.Location = new System.Drawing.Point(11, 141);
            this.ServerTextLabel.Name = "ServerTextLabel";
            this.ServerTextLabel.Size = new System.Drawing.Size(65, 13);
            this.ServerTextLabel.TabIndex = 6;
            this.ServerTextLabel.Text = "Server Text:";
            // 
            // UserTextLabel
            // 
            this.UserTextLabel.AutoSize = true;
            this.UserTextLabel.Location = new System.Drawing.Point(19, 182);
            this.UserTextLabel.Name = "UserTextLabel";
            this.UserTextLabel.Size = new System.Drawing.Size(56, 13);
            this.UserTextLabel.TabIndex = 6;
            this.UserTextLabel.Text = "User Text:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Form Color:";
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(106, 266);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(25, 266);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 0;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // OptionsGroupbox
            // 
            this.OptionsGroupbox.Controls.Add(this.NameColorButton);
            this.OptionsGroupbox.Controls.Add(this.NameColorPanel);
            this.OptionsGroupbox.Controls.Add(this.NameColorLabel);
            this.OptionsGroupbox.Location = new System.Drawing.Point(7, 0);
            this.OptionsGroupbox.Name = "OptionsGroupbox";
            this.OptionsGroupbox.Size = new System.Drawing.Size(191, 253);
            this.OptionsGroupbox.TabIndex = 7;
            this.OptionsGroupbox.TabStop = false;
            // 
            // NameColorButton
            // 
            this.NameColorButton.Location = new System.Drawing.Point(105, 46);
            this.NameColorButton.Name = "NameColorButton";
            this.NameColorButton.Size = new System.Drawing.Size(75, 23);
            this.NameColorButton.TabIndex = 1;
            this.NameColorButton.Text = "Change";
            this.NameColorButton.UseVisualStyleBackColor = true;
            this.NameColorButton.Click += new System.EventHandler(this.NameColorButton_Click);
            // 
            // NameColorPanel
            // 
            this.NameColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameColorPanel.Location = new System.Drawing.Point(70, 46);
            this.NameColorPanel.Name = "NameColorPanel";
            this.NameColorPanel.Size = new System.Drawing.Size(29, 23);
            this.NameColorPanel.TabIndex = 5;
            // 
            // NameColorLabel
            // 
            this.NameColorLabel.AutoSize = true;
            this.NameColorLabel.Location = new System.Drawing.Point(4, 50);
            this.NameColorLabel.Name = "NameColorLabel";
            this.NameColorLabel.Size = new System.Drawing.Size(65, 13);
            this.NameColorLabel.TabIndex = 6;
            this.NameColorLabel.Text = "Name Color:";
            // 
            // ButtonsGroupbox
            // 
            this.ButtonsGroupbox.Location = new System.Drawing.Point(7, 254);
            this.ButtonsGroupbox.Name = "ButtonsGroupbox";
            this.ButtonsGroupbox.Size = new System.Drawing.Size(191, 41);
            this.ButtonsGroupbox.TabIndex = 8;
            this.ButtonsGroupbox.TabStop = false;
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 300);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserTextLabel);
            this.Controls.Add(this.ServerTextLabel);
            this.Controls.Add(this.FormColorPanel);
            this.Controls.Add(this.UserColorPanel);
            this.Controls.Add(this.ServerColorPanel);
            this.Controls.Add(this.UserFontLabel);
            this.Controls.Add(this.TimestampLabel);
            this.Controls.Add(this.TimestampCheckbox);
            this.Controls.Add(this.TextFontButton);
            this.Controls.Add(this.ServerColorButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.FormColorButton);
            this.Controls.Add(this.UserColorButton);
            this.Controls.Add(this.OptionsGroupbox);
            this.Controls.Add(this.ButtonsGroupbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.OptionsGroupbox.ResumeLayout(false);
            this.OptionsGroupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button UserColorButton;
        private System.Windows.Forms.Button ServerColorButton;
        private System.Windows.Forms.Button TextFontButton;
        private System.Windows.Forms.CheckBox TimestampCheckbox;
        private System.Windows.Forms.Label TimestampLabel;
        private System.Windows.Forms.Label UserFontLabel;
        private System.Windows.Forms.Panel ServerColorPanel;
        private System.Windows.Forms.Panel UserColorPanel;
        private System.Windows.Forms.Button FormColorButton;
        private System.Windows.Forms.Panel FormColorPanel;
        private System.Windows.Forms.Label ServerTextLabel;
        private System.Windows.Forms.Label UserTextLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.GroupBox OptionsGroupbox;
        private System.Windows.Forms.GroupBox ButtonsGroupbox;
        private System.Windows.Forms.Button NameColorButton;
        private System.Windows.Forms.Panel NameColorPanel;
        private System.Windows.Forms.Label NameColorLabel;
    }
}
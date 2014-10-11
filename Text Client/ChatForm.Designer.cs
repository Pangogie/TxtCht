namespace Text_Client
{
    partial class ChatForm
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
            this.components = new System.ComponentModel.Container();
            this.SendTextbox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.LogTextbox = new System.Windows.Forms.RichTextBox();
            this.LogGroupBox = new System.Windows.Forms.GroupBox();
            this.UserList = new System.Windows.Forms.ListView();
            this.AdminMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsButton = new System.Windows.Forms.Button();
            this.AdminMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SendTextbox
            // 
            this.SendTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SendTextbox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SendTextbox.Location = new System.Drawing.Point(7, 201);
            this.SendTextbox.MaxLength = 1000;
            this.SendTextbox.Multiline = true;
            this.SendTextbox.Name = "SendTextbox";
            this.SendTextbox.Size = new System.Drawing.Size(269, 53);
            this.SendTextbox.TabIndex = 0;
            this.SendTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SendTextbox_KeyDown);
            // 
            // SendButton
            // 
            this.SendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendButton.Location = new System.Drawing.Point(282, 201);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(71, 53);
            this.SendButton.TabIndex = 2;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // LogTextbox
            // 
            this.LogTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogTextbox.BackColor = System.Drawing.SystemColors.Window;
            this.LogTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogTextbox.Location = new System.Drawing.Point(7, 10);
            this.LogTextbox.Margin = new System.Windows.Forms.Padding(20);
            this.LogTextbox.MaxLength = 10000;
            this.LogTextbox.Name = "LogTextbox";
            this.LogTextbox.ReadOnly = true;
            this.LogTextbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.LogTextbox.Size = new System.Drawing.Size(269, 182);
            this.LogTextbox.TabIndex = 10;
            this.LogTextbox.TabStop = false;
            this.LogTextbox.Text = "";
            this.LogTextbox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.LogTextbox_LinkClicked);
            // 
            // LogGroupBox
            // 
            this.LogGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LogGroupBox.Location = new System.Drawing.Point(6, 2);
            this.LogGroupBox.Name = "LogGroupBox";
            this.LogGroupBox.Size = new System.Drawing.Size(271, 192);
            this.LogGroupBox.TabIndex = 11;
            this.LogGroupBox.TabStop = false;
            // 
            // UserList
            // 
            this.UserList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.UserList.Location = new System.Drawing.Point(282, 8);
            this.UserList.Margin = new System.Windows.Forms.Padding(0);
            this.UserList.MinimumSize = new System.Drawing.Size(71, 160);
            this.UserList.MultiSelect = false;
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(71, 160);
            this.UserList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.UserList.TabIndex = 12;
            this.UserList.TabStop = false;
            this.UserList.UseCompatibleStateImageBehavior = false;
            this.UserList.View = System.Windows.Forms.View.List;
            this.UserList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserList_MouseDown);
            // 
            // AdminMenuStrip
            // 
            this.AdminMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kickToolStripMenuItem});
            this.AdminMenuStrip.Name = "AdminMenuStrip";
            this.AdminMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.AdminMenuStrip.Size = new System.Drawing.Size(97, 26);
            // 
            // kickToolStripMenuItem
            // 
            this.kickToolStripMenuItem.Name = "kickToolStripMenuItem";
            this.kickToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.kickToolStripMenuItem.Text = "Kick";
            this.kickToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.kickToolStripMenuItem.Click += new System.EventHandler(this.kickToolStripMenuItem_Click);
            // 
            // OptionsButton
            // 
            this.OptionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsButton.Location = new System.Drawing.Point(282, 171);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(71, 23);
            this.OptionsButton.TabIndex = 13;
            this.OptionsButton.Text = "Options";
            this.OptionsButton.UseVisualStyleBackColor = true;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // ChatForm
            // 
            this.AcceptButton = this.SendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 262);
            this.Controls.Add(this.OptionsButton);
            this.Controls.Add(this.UserList);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.SendTextbox);
            this.Controls.Add(this.LogTextbox);
            this.Controls.Add(this.LogGroupBox);
            this.MinimumSize = new System.Drawing.Size(376, 300);
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat Client";
            this.Activated += new System.EventHandler(this.ChatForm_Activated);
            this.Deactivate += new System.EventHandler(this.ChatForm_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.ChatForm_ResizeEnd);
            this.AdminMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SendTextbox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.RichTextBox LogTextbox;
        private System.Windows.Forms.GroupBox LogGroupBox;
        private System.Windows.Forms.ListView UserList;
        private System.Windows.Forms.ContextMenuStrip AdminMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem kickToolStripMenuItem;
        private System.Windows.Forms.Button OptionsButton;
    }
}


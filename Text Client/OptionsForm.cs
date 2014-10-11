using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Client
{
    public partial class OptionsForm : Form
    {
        public bool timestamp = false;
        public Color nameColor = DefaultForeColor;
        public Color userColor = DefaultForeColor;
        public Color serverColor = Color.DarkGreen;
        public Font textFont = DefaultFont;
        public Color formColor = DefaultBackColor;

        public OptionsForm()
        {
            InitializeComponent();
        }

        private void TimestampCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            timestamp = TimestampCheckbox.Checked;
        }

        private void TextFontButton_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = textFont;
            fontDialog1.ShowDialog();
            textFont = fontDialog1.Font;
            UserFontLabel.Font = textFont;
        }

        private void ServerColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = serverColor;
            colorDialog1.ShowDialog();
            serverColor = colorDialog1.Color;
            ServerColorPanel.BackColor = serverColor;
        }

        private void UserColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = userColor;
            colorDialog1.ShowDialog();
            userColor = colorDialog1.Color;
            UserColorPanel.BackColor = userColor;
        }

        private void FormColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = formColor;
            colorDialog1.ShowDialog();
            formColor = colorDialog1.Color;
            FormColorPanel.BackColor = formColor;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            nameColor = DefaultForeColor;
            userColor = DefaultForeColor;
            serverColor = Color.DarkGreen;
            textFont = DefaultFont;
            TimestampCheckbox.Checked = false;
            timestamp = false;
            formColor = DefaultBackColor;

            NameColorPanel.BackColor = nameColor;
            UserFontLabel.Font = textFont;
            ServerColorPanel.BackColor = serverColor;
            UserColorPanel.BackColor = userColor;
            FormColorPanel.BackColor = formColor;
        }

        private void NameColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = nameColor;
            colorDialog1.ShowDialog();
            nameColor = colorDialog1.Color;
            NameColorPanel.BackColor = nameColor;
            if (nameColor.GetBrightness() * 255 > 180)
            {
                int brightAmount = (int)((nameColor.GetBrightness() * 255) - 180);
                nameColor = Color.FromArgb(nameColor.R - brightAmount, nameColor.G - brightAmount, nameColor.B - brightAmount);
            }
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            NameColorPanel.BackColor = nameColor;
            TimestampLabel.Text = string.Format("[{0:hh:mm:ss}] ", DateTime.Now);
            UserFontLabel.Font = textFont;
            ServerColorPanel.BackColor = serverColor;
            UserColorPanel.BackColor = userColor;
            FormColorPanel.BackColor = formColor;
        }
    }
}

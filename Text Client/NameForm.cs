using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Text_Client
{
    public partial class NameForm : Form
    {
        public string userName = "";
        public IPAddress serverAddr = null;

        public NameForm()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            int allGood = 0;

            string userNameCheck = NameTextbox.Text;
            int start = 0, end = 0;

            // Get locations of first and last letter in name.
            for (int i = 0; i < userNameCheck.Length; i++ )
            {
                if (userNameCheck[i] != 32)
                {
                    start = i;
                    break;
                }
            }
            for(int i = userNameCheck.Length - 1; i > 0; i--)
            {
                if(userNameCheck[i] != 32)
                {
                    end = i;
                    break;
                }
            }

            if(userNameCheck.Length > 3)
                userName = userNameCheck.Substring(start, end - start + 1);
            // Check to make sure everything is okey.
            if (userName.Length > 3)
            {
                allGood++;
            }
            else
            {
                MessageBox.Show("Name must be longer than 3 letters.", "Name Too Short", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                NameTextbox.SelectAll();
            }
            try
            {
                if(!IPAddress.TryParse(IPTextBox.Text, out serverAddr))
                    serverAddr = Dns.GetHostAddresses(IPTextBox.Text)[0];

                allGood++;
            }
            catch
            {
                MessageBox.Show("Invalid IP Address", "Invalid IP Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                IPTextBox.SelectAll();
            }

            if (allGood == 2)
            {
                DialogResult = DialogResult.OK;

                this.Close();
            }
        }

        private void NameForm_Load(object sender, EventArgs e)
        {
            // Get IP Address of server from ServerIP.txt in my DropBox.

            bool abort = false;
            string IPString = "";
            string txtLink = "http://dl.dropbox.com/u/17072899/ServerIP.txt";

            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(txtLink);

            httpRequest.Timeout = 10000;
            httpRequest.UserAgent = "Server IP Grabber";

            try
            {
                HttpWebResponse webResponse = (HttpWebResponse)httpRequest.GetResponse();
                System.IO.StreamReader responseStream = new System.IO.StreamReader(webResponse.GetResponseStream());
                IPString = responseStream.ReadToEnd();
                responseStream.Close();
            }
            catch
            {
                MessageBox.Show("Could not retrieve default server IP!", "Connection Timeout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                abort = true;
            }

            if (!abort)
            {
                IPTextBox.Text = IPString;
            }
        }
    }
}

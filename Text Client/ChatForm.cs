// Some of these can be removed.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Runtime.InteropServices;

namespace Text_Client
{
    public partial class ChatForm : Form
    {
        // Giant mess of globals because I'm bad at programming.
        public EndPoint server;
        private Socket cSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private OptionsForm options = new OptionsForm();

        public string userName = "";
        public string kickReason = "";
        private byte[] buffer = new byte[1024];
        private bool userIsAdmin = false;
        private bool isApplicationActive;

        private struct DataIn
        {
            public DataIn(byte[] buffer)
            {
                byte nameLength = buffer[0];

                this.senderColor = Color.FromArgb(buffer[1], buffer[2], buffer[3]);

                if (nameLength > 3)
                    this.senderName = Encoding.ASCII.GetString(buffer, 4, nameLength);
                else
                    this.senderName = "";

                this.senderMessage = Encoding.GetEncoding(437).GetString(buffer, nameLength + 4, buffer.Length - nameLength - 4);
            }

            public Color senderColor;
            public string senderName;
            public string senderMessage;
        }

        // Form initialization.
        public ChatForm()
        {
            InitializeComponent();
        }
        
        // These are an absolute mess.
        #region Form Controls/Functions
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            double h = new Random(Guid.NewGuid().GetHashCode()).NextDouble();
            h += 0.618033988749895;
            h %= 1;
            h *= 360;
            options.nameColor = ColorFromHSV(h, 0.5, 0.95);
            
            try
            {
                //sockClient.ReceiveTimeout = -1;
                IAsyncResult process =  cSock.BeginConnect(server, new AsyncCallback(OnConnect), null);
                process.AsyncWaitHandle.WaitOne();
                //sockClient.Connect(server);
            }
            catch (Exception explosion)
            {
                MessageBox.Show("Something exploded.\r\nPlease tell Pangogie.\r\n\r\n" + explosion.Message, "Uh Oh", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string command = "/logout";
            buffer = Encoding.ASCII.GetBytes(command);
            buffer = TrimArray(buffer);

            IAsyncResult process = cSock.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
            process.AsyncWaitHandle.WaitOne();
            cSock.Disconnect(false);
            cSock.Close();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (SendTextbox.Text != "")
            {
                string message = SendTextbox.Text;
                byte[] buffer = ToByte(message);

                SendTextbox.Clear();

                IAsyncResult process =  cSock.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                process.AsyncWaitHandle.WaitOne();
            }

            SendTextbox.Focus();
        }


        private void SendTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            // Allow Ctrl + A in the textbox.
            if (e.Control && e.KeyCode == Keys.A)
                SendTextbox.SelectAll();
        }

        private void ChatForm_Activated(object sender, EventArgs e)
        {
            isApplicationActive = true;
        }

        private void ChatForm_Deactivate(object sender, EventArgs e)
        {
            isApplicationActive = false;
        }

        [DllImport("user32.dll")]
        static extern bool FlashWindow(IntPtr hwnd, bool bInvert);

        string userItem;

        private void UserList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && userIsAdmin)
            {
                userItem = "";
                //Point p = new Point(e.X + UserList.Location.X, e.Y + UserList.Location.Y);
                Point p = new Point(e.X, e.Y);
                try
                {
                    userItem = UserList.GetItemAt(p.X, p.Y).Text;
                    p = new Point(e.X + UserList.Location.X, e.Y + UserList.Location.Y + 10);
                    AdminMenuStrip.Show(PointToScreen(p));
                }
                catch
                { }
            }
        }

        private void kickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendTextbox.Text = "/kick " + userItem;
            SendButton_Click(sender, e);
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            options.formColor = this.BackColor;
            options.ShowDialog();
            this.BackColor = options.formColor;
            LogTextbox.SelectionStart = 0;
            LogTextbox.SelectionLength = LogTextbox.Text.Length;

            //if (LogTextbox.SelectionFont != options.textFont)
            //{
            //    try
            //    {
            //        LogTextbox.SelectionFont = new Font(options.textFont.FontFamily, options.textFont.Size);
            //    }
            //    catch (Exception error)
            //    {
            //        MessageBox.Show(error.Message, "Font Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
        }

        private void ChatForm_ResizeEnd(object sender, EventArgs e)
        {
            LogTextbox.SelectionStart = LogTextbox.Text.Length;
            LogTextbox.ScrollToCaret();
            LogTextbox.Update();
        }
        #endregion

        // The Async functions that make everything work.
        // Receive is a mess and severely need refactoring.
        #region ASync Functions (Connect/Send/Receive)
        private void OnConnect(IAsyncResult ar)
        {
            try
            { cSock.EndConnect(ar); }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }


            string command = "/login " + userName;
            buffer = Encoding.ASCII.GetBytes(command);
            buffer = TrimArray(buffer);

            IAsyncResult process =  cSock.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
            process.AsyncWaitHandle.WaitOne();

            buffer = new byte[1024];
            cSock.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
            
        }


        private void OnSend(IAsyncResult ar)
        {
            try
            {
                cSock.EndSend(ar);
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            // Try/Catch needed so there is no error upon exit.
            cSock.EndReceive(ar);

            buffer = TrimArray(buffer);
            DataIn data = new DataIn(buffer);
            buffer = new byte[1024];
            cSock.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);

            if (data.senderMessage.Substring(0, 1) == "/")
            {
                // Handle Client commands.

                if (data.senderMessage.Substring(0, 6) == "/login")
                {
                    // Add new user to the UserList.
                    UserList.Items.Add(data.senderMessage.Substring(7, data.senderMessage.Length - 7));
                }
                else if (data.senderMessage.Substring(0, 6) == "/admin")
                {
                    userIsAdmin = true;
                }
                else if (data.senderMessage.Substring(0, 7) == "/logout")
                {
                    // Find and remove user from the UserList.
                    foreach (ListViewItem item in UserList.Items)
                    {
                        if (item.Text == data.senderMessage.Substring(8, data.senderMessage.Length - 8))
                        {
                            UserList.Items.Remove(item);
                            break;
                        }
                    }
                }
                else if (data.senderMessage.Substring(0, 5) == "/kick")
                {
                    // Set the kick reason and exit the program.
                    kickReason = data.senderMessage.Substring(6, data.senderMessage.Length - 6);
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
            }
            else
            {
                if (data.senderName.Length < 4)
                {
                    // Change text colour for server messages.
                    LogTextbox.SelectionStart = LogTextbox.TextLength;
                    LogTextbox.SelectionLength = 0;
                    LogTextbox.SelectionColor = options.serverColor;
                    LogTextbox.SelectionFont = options.textFont;
                    // Print server message.
                    LogTextbox.AppendText(data.senderMessage);
                }
                else
                {
                    if (!isApplicationActive)
                    {
                        // Flash the taskbar when a message comes in.
                        FlashWindow(this.Handle, true);
                    }

                    if (options.timestamp)
                        LogTextbox.AppendText(string.Format("[{0:hh:mm:ss}] ", DateTime.Now));

                    // Make the senderName BOLD.
                    LogTextbox.SelectionStart = LogTextbox.TextLength;
                    LogTextbox.SelectionLength = 0;
                    LogTextbox.SelectionColor = data.senderColor;
                    LogTextbox.SelectionFont = new Font(options.textFont.FontFamily, options.textFont.Size, FontStyle.Bold);
                    // Print sender name.
                    LogTextbox.AppendText(data.senderName);

                    // Reset font to regular.
                    LogTextbox.SelectionFont = options.textFont;
                    LogTextbox.SelectionColor = options.userColor;
                    // Print message.
                    LogTextbox.AppendText(": " + data.senderMessage);
                }

                LogTextbox.AppendText("\r\n");
                LogTextbox.SelectionStart = LogTextbox.Text.Length;
                LogTextbox.ScrollToCaret();
                LogTextbox.Update();
            }
        }
        #endregion

        // These are misc. functions that could probably be redone and shared with the server.
        #region Misc Functions
        private void LogTextbox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            // Open links in a new tab in the default browser.
            System.Diagnostics.Process.Start(e.LinkText);
        }

        public byte[] ToByte(string message)
        {
            List<byte> result = new List<byte>();

            // First byte is userName.Length.
            result.Insert(0, (byte)userName.Length);
            result.Insert(1, options.nameColor.R);
            result.Insert(2, options.nameColor.G);
            result.Insert(3, options.nameColor.B);
            // Second byte is null due to unknown causes.
            // Add userName to the byte[].
            result.AddRange(Encoding.ASCII.GetBytes(userName));
            // Add message to the byte[].
            result.AddRange(Encoding.ASCII.GetBytes(message));

            // Trim the array of nulls before returning.
            return TrimArray(result.ToArray());
        }

        private byte[] TrimArray(byte[] byteArray)
        {
            // Trim the nulls from a byte[].

            int byteCounter = byteArray.Length - 1;
            while (byteArray[byteCounter] == 0x00)
            {
                byteCounter--;
            }
            byte[] rv = new byte[(byteCounter + 1)];
            for (int byteCounter1 = 0; byteCounter1 < (byteCounter + 1); byteCounter1++)
            {
                rv[byteCounter1] = byteArray[byteCounter1];
            }

            return rv;
        }

        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }
        #endregion
    }
}

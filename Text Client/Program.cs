using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Text_Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize all components.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            NameForm nameForm = new NameForm();
            ChatForm chatForm = new ChatForm();

            Application.Run(nameForm);

            // Transfer information from NameForm to ChatForm.
            if (nameForm.DialogResult == DialogResult.OK)
            {
                chatForm.userName = nameForm.userName;
                chatForm.server = new System.Net.IPEndPoint(nameForm.serverAddr, 7200);
                Application.Run(chatForm);
            }

            // Display various messages when the program exits.
            if (chatForm.DialogResult == DialogResult.Abort)
            {
                MessageBox.Show("You have been kicked from the server.\r\nReason: " + chatForm.kickReason, "Kicked", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            Environment.Exit(0);
        }
    }
}

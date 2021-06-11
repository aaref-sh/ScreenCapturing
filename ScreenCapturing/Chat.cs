using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapturing
{
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
            Form1.connection.On<string, string>("newMessage", NewMessage);
        }
        public void NewMessage(string message,string sender)
        {
            rtbmessages.Text += "\n" + sender + "\n" + message + "\n";
        }
        private void pbsend_Click(object sender, EventArgs e)
        {
            if(tbmessage.Text.Trim() != "")
            {
                Form1.connection.InvokeAsync("newMessage", tbmessage.Text);
                tbmessage.Text = "";
            }
        }
    }
}

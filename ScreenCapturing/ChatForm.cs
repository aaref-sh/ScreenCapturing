using System;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;

namespace ScreenCapturing
{
    public partial class ChatForm : Form
    {
        public ChatForm()
        {
            InitializeComponent();
            wpfChatForm1.adds();
            Form1.connection.InvokeAsync("getMessages");
            bottom_side.MouseMove += (s, e) => { if (drag) Height = Math.Max(Cursor.Position.Y - Top, 300); };
            right_side.MouseMove += (s, e) => { if (drag) Width = Math.Max(Cursor.Position.X - Left, 200); };
            corner_resizer.MouseMove += (s, e) => { if (drag) { Height = Math.Max(Cursor.Position.Y - Top,150); Width = Math.Max(50, Cursor.Position.X - Left); } };
        }
        private void close_btn_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void d_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drag = true;
                posX = Cursor.Position.X - Left;
                posY = Cursor.Position.Y - Top;
            }
        }
        private void d_MouseUp(object sender, MouseEventArgs e) => drag = false;
        private void d_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Top = Cursor.Position.Y - posY;
                Left = Cursor.Position.X - posX;
            }
            Cursor = Cursors.Default;
        }
        int posX;
        int posY;
        bool drag;
    }
}

using Microsoft.AspNetCore.SignalR.Client;
using ScreenCapturing.classes;
using ScreenCapturing.Properties;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VoiceClient;

namespace ScreenCapturing
{
    public partial class Form1 : Form
    {
        public static PixelFormat quality { set; get; }
        public static int FPSRate { set; get; }
        public static bool encrypted { set; get; }
        public static int percent = 100;
        public static HubConnection connection;
        Bitmap[,] sa = new Bitmap[10, 10];
        Bitmap[,] prev = new Bitmap[10, 10];
        int x = 10, y = 10;
        ControlPanel c;
        ChatForm chat;
        StreamClient sc;
        int port;
        bool mic_muted = false;
        string group;
        bool speaker_muted = false;
        public Form1()
        {
            InitializeComponent();
            quality = PixelFormat.Format16bppRgb565;
            FPSRate = 10;
            encrypted = false;
            TopMost = true;
            ConfigSignalRConnection();
        }
        private async void ConfigSignalRConnection()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://192.168.1.111:5000/CastHub")
                .WithAutomaticReconnect()
                .Build();
            await connection.StartAsync();
            await connection.InvokeAsync("SetName", "Teacher");
            group = await connection.InvokeAsync<string>("GetGroupId",Logger.room_name);
            await connection.InvokeAsync("AddToGroup", group);
            port = await connection.InvokeAsync<int>("getport",group);
            sc = new StreamClient(port,"192.168.1.111");
            sc.Init();
            sc.ConnectToServer();
            c = new ControlPanel();
            chat = new ChatForm();
            Ext.pass = group;
        }
        private Bitmap CaptureImage()
        {
            Bitmap b = new Bitmap(Width, Height - 23, quality);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.CopyFromScreen(Left, Top, 0, 0, new Size(Width, Height - 23), CopyPixelOperation.SourceCopy);
                User32.CURSORINFO cursorInfo;
                cursorInfo.cbSize = Marshal.SizeOf(typeof(User32.CURSORINFO));

                if (User32.GetCursorInfo(out cursorInfo))
                {
                    // if the cursor is showing draw it on the screen shot
                    if (cursorInfo.flags == User32.CURSOR_SHOWING)
                    {
                        // we need to get hotspot so we can draw the cursor in the correct position
                        var iconPointer = User32.CopyIcon(cursorInfo.hCursor);
                        User32.ICONINFO iconInfo;
                        int iconX, iconY;

                        if (User32.GetIconInfo(iconPointer, out iconInfo))
                        {
                            // calculate the correct position of the cursor
                            iconX = cursorInfo.ptScreenPos.x - ((int)iconInfo.xHotspot) - this.Left;
                            iconY = cursorInfo.ptScreenPos.y - ((int)iconInfo.yHotspot) - this.Top;

                            // draw the cursor icon on top of the captured screen image
                            User32.DrawIcon(g.GetHdc(), iconX, iconY, cursorInfo.hCursor);

                            // release the handle created by call to g.GetHdc()
                            g.ReleaseHdc();
                        }
                    }
                }
            }
            return b;
        }

        public async Task SendUpdates()
        {
            Bitmap src = CaptureImage();
            int wdt = src.Width / x, hgt = src.Height / y;
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {

                    Rectangle r = new Rectangle(new Point(j * wdt, i * hgt), new Size(wdt, hgt));
                    sa[i, j] = src.Clone(r, src.PixelFormat);
                    if (!Ext.Compare(sa[i, j], prev[i, j]))
                    {
                        try
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                Ext.Resized(sa[i, j]).Save(ms, ImageFormat.Jpeg);
                                string base64 = Convert.ToBase64String(ms.ToArray());
                                if (encrypted) base64 = Ext.Encoded(base64.Substring(0, 200)) + base64.Substring(200);
                                await connection.InvokeAsync("UpdateScreen", base64, i, j, encrypted, sa[i, j].Height, sa[i, j].Width);
                                prev[i, j] = sa[i, j];
                            }
                        }
                        catch (Exception e) { MessageBox.Show(e.Message); }
                    }
                }
            }
        }
        DateTime last = DateTime.Now;
        public async Task Cap()
        {
            if (DateTime.Now - last >= TimeSpan.FromMilliseconds(1000 / FPSRate))
            {
                last = DateTime.Now;
                try
                {
                    await SendUpdates();
                }
                catch (Exception e) { Console.WriteLine(e); }
            }

        }
        Thread caster = null;
        private void Button1_Click(object sender, EventArgs e)
        {
            caster = new Thread(Cast);
            caster.Start();
        }
        async void Cast()
        {
            while (connection.State == HubConnectionState.Connected)
                await Cap();
        }
        
        
        #region resize and drag
        private void L1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drag = true;
                posX = Cursor.Position.X - Left;
                posY = Cursor.Position.Y - Top;
            }
        }
        private void L1_MouseUp(object sender, MouseEventArgs e) => drag = false;
        private void L1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Top = Cursor.Position.Y - posY;
                Top = Math.Max(Top, 0);
                Top = Math.Min(Bottom, Screen.PrimaryScreen.Bounds.Height) - Height;
                Left = Cursor.Position.X - posX;
                Left = Math.Max(Left, 0);
                Left = Math.Min(Right, Screen.PrimaryScreen.Bounds.Width) - Width;
                if(c!=null)
                {
                    c.Left = Right;
                    c.Top = Top;
                }
            }
            this.Cursor = Cursors.Default;
        }
        int posX;
        int posY;
        bool drag;

        private void Label3_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Width = Cursor.Position.X - Left > 0 ? Cursor.Position.X - Left : 0;
                if(c!=null) c.Left = Right;
            }
        }
        private void Label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag) Height = Cursor.Position.Y - Top > 0 ? Cursor.Position.Y - Top : 0;
        }
        private void Label5_Click(object sender, EventArgs e)
        {
            sc.ConnectToServer();
            if (caster != null) caster.Abort();
            Program.logger.Dispose();
            this.Close();
        }
        private void L2_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Width = Cursor.Position.X - Left;
                Height = Cursor.Position.Y - Top;
                if(c!=null)
                {
                    c.Left = Right;
                    c.Top = Top;
                }
                
            }
        }
        private void settingsbtn_Click(object sender, EventArgs e)
        {
            if (c == null) c = new ControlPanel();
            c.Show();
            c.Top = Top;
            c.Left = Right;
        }
        #endregion

        private void pbspeaker_Click(object sender, EventArgs e)
        {
            if (speaker_muted) pbspeaker.Image = Resources.su;
            else pbspeaker.Image = Resources.sm;
            speaker_muted = !speaker_muted;
            sc.speakertougle();
        }
        private void btnchat_Click(object sender, EventArgs e)
        {
            if (chat==null) chat = new ChatForm();
            chat.Show();
        }

        private void pbmic_Click(object sender, EventArgs e)
        {
            if (mic_muted) pbmic.Image = Resources.um;
            else pbmic.Image = Resources.m;
            mic_muted = !mic_muted;
            sc.mictougle();
        }
    }
}

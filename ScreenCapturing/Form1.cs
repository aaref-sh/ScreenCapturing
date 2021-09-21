using Microsoft.AspNetCore.SignalR.Client;
using ScreenCapturing.classes;
using ScreenCapturing.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
        BackgroundWorker bgw;
        string group;
        bool speaker_muted = false;
        List<Bitmap> srclist = new List<Bitmap>();
        DateTime last;
        Thread caster = null;
        bool painting = false;
        Bitmap todraw;
        Bitmap clean;
        bool Casting = false;
        Point lastPoint = Point.Empty;

        [Obsolete]
        public Form1()
        {
            InitializeComponent();
            quality = PixelFormat.Format16bppRgb565;
            FPSRate = 10;
            encrypted = false;
            TopMost = true;
            ConfigSignalRConnection();
        }

        [Obsolete]
        private async void ConfigSignalRConnection()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://" + Logger.URL + ":5000/CastHub")
                .WithAutomaticReconnect()
                .Build();
            await connection.StartAsync();
            await connection.InvokeAsync("SetName", "Teacher");
            group = await connection.InvokeAsync<string>("GetGroupId", Logger.room_name);
            await connection.InvokeAsync("AddToGroup", group);
            port = await connection.InvokeAsync<int>("getport", group);
            c = new ControlPanel();
            chat = new ChatForm();
            Ext.pass = group;
            WPFChatForm.key = ASCIIEncoding.ASCII.GetBytes(Ext.pass.Substring(0, 8));
            caster = new Thread(Cast);
            bgw = new BackgroundWorker();
            bgw.DoWork += SendUpdates;
            caster.Start();
            caster.Suspend();
            sc = new StreamClient(port, Logger.URL);
            sc.Init();
            sc.ConnectToServer();
        }
        Process pen = null;
        void drawingbtn_Click(Object sender, EventArgs e)
        {
            if (pen == null)
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\InkPen.exe";
                pen = new Process();
                pen.StartInfo.FileName = path;
                pen.Start();
            }
            else
            {
                pen.Kill();
                pen.Dispose();
                pen = null;
            }

            //if (!painting)
            //{
            //    painting = true;
            //    drawing.Show();
            //    drawing.Top = Bottom;
            //    drawing.Left = Right - 230;
            //    todraw = new Bitmap(pbpaintboard.Width, pbpaintboard.Height, PixelFormat.Format24bppRgb);
            //    using (Graphics g = Graphics.FromImage(todraw))
            //        g.CopyFromScreen(Left + 2, Top + 2, 0, 0, new Size(pbpaintboard.Width, pbpaintboard.Height), CopyPixelOperation.SourceCopy);
            //    pbpaintboard.Image = todraw;
            //    clean = (Bitmap)todraw.Clone();
            //}
            //else
            //{
            //    painting = false;
            //    pbpaintboard.Image = null;
            //    drawing.Hide();
            //}
        }
        private void CaptureImage()
        {
            using (Bitmap b = new Bitmap(Width, Height - 23, quality))
                try
                {
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
                    srclist.Add((Bitmap)Ext.Resized(b).Clone());
                }
                catch { }
        }

        [Obsolete]
        private void CastinTougle_Click(object sender, EventArgs e)
        {
            if (Casting) caster.Suspend();
            else
            {
                caster.Resume();
                bgw.RunWorkerAsync();
            }
            Casting = !Casting;
            CastingTouglebtn.Image = Casting ? Resources.pause : Resources.play;
        }
        private async void SendUpdates(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (!Casting) return;
                if (srclist.Count == 0) continue;
                LastSent = DateTime.Now;
                using (Bitmap src = srclist[srclist.Count - 1])
                {
                    srclist.Clear();
                    if (src != null)
                    {
                        int wdt = src.Width / x, hgt = src.Height / y;
                        for (int i = 0; i < y; i++)
                        {
                            for (int j = 0; j < x; j++)
                            {
                                Rectangle r = new Rectangle(new Point(j * wdt, i * hgt), new Size(wdt, hgt));
                                sa[i, j] = src.Clone(r, src.PixelFormat);
                                if (!Ext.CompareMemCmp(sa[i, j], prev[i, j]))
                                {
                                    prev[i, j] = sa[i, j];
                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        sa[i, j].Save(ms, ImageFormat.Jpeg);
                                        string base64 = Convert.ToBase64String(ms.ToArray());
                                        if (encrypted) base64 = Ext.Encoded(base64.Substring(0, 200)) + base64.Substring(200);
                                        _ = connection.SendAsync("UpdateScreen", base64, i, j, encrypted, sa[i, j].Height, sa[i, j].Width);
                                    }
                                }
                            }
                        }
                    }
                }
                var time = TimeSpan.FromMilliseconds(1000 / FPSRate) - (DateTime.Now - LastSent);
                if (time > TimeSpan.FromMilliseconds(0)) Thread.Sleep(time);
            }
        }
        DateTime LastSent;
        void Cast()
        {
            while (connection.State == HubConnectionState.Connected)
            {
                if (Casting)
                {
                    last = DateTime.Now;
                    CaptureImage();
                    var time = TimeSpan.FromMilliseconds(1000 / FPSRate) - (DateTime.Now - last);
                    if (time > TimeSpan.FromMilliseconds(0)) Thread.Sleep(time);
                }
            }
        }


        private void pbspeaker_Click(object sender, EventArgs e)
        {
            if (speaker_muted) pbspeaker.Image = Resources.su;
            else pbspeaker.Image = Resources.sm;
            speaker_muted = !speaker_muted;
            sc.speakertougle();
        }
        private void btnchat_Click(object sender, EventArgs e) => chat.Show();

        private void pbmic_Click(object sender, EventArgs e)
        {
            if (mic_muted) pbmic.Image = Resources.um;
            else pbmic.Image = Resources.m;
            mic_muted = !mic_muted;
            sc.mictougle();
        }
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
            isMouseDown = true;
        }
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                using (Graphics g = Graphics.FromImage(pbpaintboard.Image))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                }
                pbpaintboard.Invalidate();
                lastPoint = e.Location;
            }
        }
        public void Clean() => pbpaintboard.Image = (Image)clean.Clone();
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            lastPoint = Point.Empty;
        }

        [Obsolete]
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            sc.ConnectToServer();
            bgw.Dispose();
            if(pen!=null)
            {
                pen.Kill();
                pen.Dispose();
                pen = null;
            }
            if (caster != null)
            {
                caster.Suspend();
                caster.Resume();
                caster.Abort();
            }
            Program.logger.Dispose();
        }
        private void Closebtn_Click(object sender, EventArgs e) => Close();

        #region resize and drag
        private void L1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                posX = Cursor.Position.X - Left;
                posY = Cursor.Position.Y - Top;
            }
        }
        private void L1_MouseUp(object sender, MouseEventArgs e) => isMouseDown = false;
        private void L1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Top = Cursor.Position.Y - posY;
                Top = Math.Max(Top, 0);
                Top = Math.Min(Bottom, Screen.PrimaryScreen.Bounds.Height) - Height;
                Left = Cursor.Position.X - posX;
                Left = Math.Max(Left, 0);
                Left = Math.Min(Right, Screen.PrimaryScreen.Bounds.Width) - Width;
                if (c != null)
                {
                    c.Left = Right;
                    c.Top = Top;
                }
            }
            Cursor = Cursors.Default;
        }
        int posX;
        int posY;
        bool isMouseDown;

        private void Label3_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Width = Cursor.Position.X - Left > 0 ? Cursor.Position.X - Left : 0;
                if (c != null) { c.Left = Right;}
            }
        }
        private void Label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Height = Cursor.Position.Y - Top > 0 ? Cursor.Position.Y - Top : 0;
                
            }
        }
        private void L2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Width = Cursor.Position.X - Left;
                Height = Cursor.Position.Y - Top;
                if (c != null)
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

    }
}

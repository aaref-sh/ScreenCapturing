﻿using Microsoft.AspNetCore.SignalR.Client;
using ScreenCapturing.classes;
using ScreenCapturing.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
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
        Drawing drawing;
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
                .WithUrl("http://"+Logger.URL+":5000/CastHub")
                .WithAutomaticReconnect()
                .Build();
            await connection.StartAsync();
            await connection.InvokeAsync("SetName", "Teacher");
            group = await connection.InvokeAsync<string>("GetGroupId",Logger.room_name);
            await connection.InvokeAsync("AddToGroup", group);
            port = await connection.InvokeAsync<int>("getport",group);
            sc = new StreamClient(port,Logger.URL);
            sc.Init();
            sc.ConnectToServer();
            c = new ControlPanel();
            chat = new ChatForm();
            drawing = new Drawing();
            Ext.pass = group;
            caster = new Thread(Cast);
            bgw = new BackgroundWorker();
            bgw.DoWork += SendUpdates;
            caster.Start();
            caster.Suspend();
        }
        void drawingbtn_Click(Object sender,EventArgs e)
        {
            if (!painting)
            {
                painting = true;
                drawing.Show();
                drawing.Top = Bottom;
                drawing.Left = Right - 230;
                todraw = new Bitmap(Width, Height - 23, quality);
                using (Graphics g = Graphics.FromImage(todraw))
                    g.CopyFromScreen(Left, Top, 0, 0, new Size(Width, Height), CopyPixelOperation.SourceCopy);
                BackgroundImage = todraw;
                clean = todraw.Clone(new Rectangle(new Point(0,0),new Size(todraw.Width,todraw.Height)),PixelFormat.Format24bppRgb);
            }
            else
            {
                painting = false;
                BackgroundImage = null;
                drawing.Hide();
            }
        }
        private void CaptureImage()
        {
            Bitmap b = new Bitmap(Width, Height - 23, quality);
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
            }
            catch { }
            srclist.Add(Ext.Resized(b));
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
        private void SendUpdates(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (!Casting) return;
                if (srclist.Count == 0) continue;
                Bitmap src = srclist[srclist.Count - 1];
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
                                    connection.InvokeAsync("UpdateScreen", base64, i, j, encrypted, sa[i, j].Height, sa[i, j].Width);
                                }
                            }
                        }
                    }
                }
            }
        }

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
            lastPoint = e.Location;//we assign the lastPoint to the current mouse position: e.Location ('e' is from the MouseEventArgs passed into the MouseDown event)
            isMouseDown = true;//we set to true because our mouse button is down (clicked)
        }
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)//check to see if the mouse button is down
            {
                //pbpaintboard.Image = BackgroundImage;
                using (Graphics g = Graphics.FromImage(BackgroundImage))
                {//we need to create a Graphics object to draw on the picture box, its our main tool
                    //when making a Pen object, you can just give it color only or give it color and pen size
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.DrawLine(new Pen(drawing.colorDialog1.Color, Drawing.thickness), lastPoint, e.Location);
                    //this is to give the drawing a more smoother, less sharper look
                }
                Invalidate();
                lastPoint = e.Location;//keep assigning the lastPoint to the current mouse position
            }
        }
        public void Clean() => BackgroundImage = clean.Clone(new Rectangle(new Point(0,0),new Size(clean.Width,clean.Height)),PixelFormat.Format24bppRgb);
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            lastPoint = Point.Empty;
            //set the previous point back to null if the user lets go of the mouse button
        }

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
                if(c!=null)
                {
                    c.Left = Right;
                    c.Top = Top;
                    drawing.Top = Bottom;
                    drawing.Left = Right - 230;
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
                if (c != null) { c.Left = Right; drawing.Left = Right - 230; }
            }
        }
        private void Label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Height = Cursor.Position.Y - Top > 0 ? Cursor.Position.Y - Top : 0;
                drawing.Top = Bottom;
            }
        }
        private void Closebtn_Click(object sender, EventArgs e) => Close();
        private void L2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Width = Cursor.Position.X - Left;
                Height = Cursor.Position.Y - Top;
                if(c!=null)
                {
                    c.Left = Right;
                    c.Top = Top;
                    drawing.Top = Bottom;
                    drawing.Left = Right - 230;
                }
                
            }
        }

        [Obsolete]
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            sc.ConnectToServer();
            bgw.Dispose();
            if (caster != null) { 
                if (caster.ThreadState == ThreadState.Suspended) caster.Resume(); 
                caster.Abort(); 
            }
            Program.logger.Dispose();
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

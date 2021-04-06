using Microsoft.AspNetCore.SignalR.Client;
using ScreenCapturing.classes;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ScreenCapturing
{
    public partial class Form1 : Form
    {
        HubConnection connection;
        Bitmap[,] sa = new Bitmap[5, 6];
        Bitmap[,] prev = new Bitmap[5, 6];
        static PixelFormat[] formats = {PixelFormat.Format32bppArgb,PixelFormat.Format24bppRgb,PixelFormat.Format16bppRgb565 };
        PixelFormat quality = formats[0];
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            ConfigSignalRConnection();
            this.TopMost = true;
        }
        private async void ConfigSignalRConnection()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://192.168.1.111:5000/CastHub")
                .WithAutomaticReconnect()
                .Build();
            connection.On<string, int, int>("UpdateScreen", UpdateScreen);
            await connection.StartAsync();
            await connection.InvokeAsync("AddToGroup", "main");
            //MessageBox.Show( await connection.InvokeAsync<string>("ok"));
        }

        private void UpdateScreen(string base64, int r, int c)
        {
            Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)))
                .Save("D:\\sc\\sc" + r + " " + c + ".jpg");
        }
        private Bitmap CaptureImage()
        {
            Bitmap b = new Bitmap(this.Width, this.Height-23,quality);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.CopyFromScreen(this.Left, this.Top, 0, 0, b.Size, CopyPixelOperation.SourceCopy);
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

        string pass = "mainmain";
        string cyphered(string s)
        {
            //return s;
            var result = new StringBuilder();
            for (int c = 0; c < s.Length; c++)
                result.Append((char)((uint)s[c] ^ (uint)pass[c % pass.Length]));
            return result.ToString();
        }
        public void SendUpdates(Bitmap src)
        {
            int x=6, y=5;
            int wdt = src.Width / x, hgt = src.Height / y;
            for (int i = 0; i < y; i++)
                for (int j = 0; j < x; j++)
                {
                    Rectangle r = new Rectangle(new Point(j * wdt, i * hgt), new Size(wdt, hgt));
                    sa[i, j] = new Bitmap(wdt, hgt,quality);
                    using (Graphics g = Graphics.FromImage(sa[i, j]))
                        g.DrawImage(src, 0, 0, r, GraphicsUnit.Pixel);
                    if (!Compare(sa[i, j], prev[i, j]))
                    {
                        try
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                sa[i, j].Save(ms, ImageFormat.Jpeg);
                                string base64 = Convert.ToBase64String(ms.ToArray());
                                connection.InvokeAsync("UpdateScreen", cyphered(base64), i, j);
                            }
                        }
                        catch (Exception e) { MessageBox.Show(e.Message); }
                        prev[i, j] = sa[i, j];
                    }
                }
        }
        public void Cap()
        {
            try
            {
                SendUpdates(CaptureImage());
            }
            catch (Exception e) { Console.WriteLine(e); }
            Thread.Sleep(1000/trackBar1.Value);

        }
        Thread caster = null;
        private void button1_Click(object sender, EventArgs e)
        {
            try { caster.Abort(); }
            catch { caster = new Thread(cast); caster.Start(); }
        }
        void cast()
        {
            while (connection.State == HubConnectionState.Connected)
                Cap();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            caster.Abort();
        }
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            var codecs = ImageCodecInfo.GetImageDecoders();
            foreach (var codec in codecs)
                if (codec.FormatID == format.Guid)
                    return codec;
            return null;
        }
        public static bool Compare(Bitmap bmp1, Bitmap bmp2)
        {
            if (bmp1 == null || bmp2 == null)
                return false;
            if (object.Equals(bmp1, bmp2))
                return true;
            if (!bmp1.Size.Equals(bmp2.Size) || !bmp1.PixelFormat.Equals(bmp2.PixelFormat))
                return false;

            int bytes = bmp1.Width * bmp1.Height * (Image.GetPixelFormatSize(bmp1.PixelFormat) / 8);

            bool result = true;
            byte[] b1bytes = new byte[bytes];
            byte[] b2bytes = new byte[bytes];

            BitmapData bitmapData1 = bmp1.LockBits(new Rectangle(0, 0, bmp1.Width, bmp1.Height), ImageLockMode.ReadOnly, bmp1.PixelFormat);
            BitmapData bitmapData2 = bmp2.LockBits(new Rectangle(0, 0, bmp2.Width, bmp2.Height), ImageLockMode.ReadOnly, bmp2.PixelFormat);

            Marshal.Copy(bitmapData1.Scan0, b1bytes, 0, bytes);
            Marshal.Copy(bitmapData2.Scan0, b2bytes, 0, bytes);

            for (long n = 0; n <= bytes - 1; n++)
            {
                if (b1bytes[n] != b2bytes[n])
                {
                    result = false;
                    break;
                }
            }

            bmp1.UnlockBits(bitmapData1);
            bmp2.UnlockBits(bitmapData2);

            return result;
        }
        #region resize and drag
        private void l1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drag = true;
                posX = Cursor.Position.X - this.Left;
                posY = Cursor.Position.Y - this.Top;
            }
        }
        private void l1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        private void l1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - posY;
                this.Left = Cursor.Position.X - posX;
            }
            this.Cursor = Cursors.Default;
        }
        int posX;
        int posY;
        bool drag;
        private void l2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.SizeNWSE;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.SizeWE;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag) this.Width = Cursor.Position.X - this.Left;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.SizeNS;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag) this.Height = Cursor.Position.Y - this.Top;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            try{caster.Abort();}
            catch { }
            this.Close();
        }

        private void l2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lcastrate.Text = "معدل البث "+trackBar1.Value + "إطار\\ث";
            /*
             * r = 1000 / d
             * d / 1000 = 1 / r
             * d = 1000 / r
             */
        }

        private void l2_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Width = Cursor.Position.X - this.Left;
                Height = Cursor.Position.Y - this.Top;
            }
        }
        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            quality = formats[comboBox1.SelectedIndex];
        }
    }
}

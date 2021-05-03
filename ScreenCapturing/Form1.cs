using Microsoft.AspNetCore.SignalR.Client;
using ScreenCapturing.classes;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapturing
{
    public partial class Form1 : Form
    {
        public static PixelFormat quality { set; get; }
        public static int FPSRate { set; get; }
        public static bool encrypted { set; get; }
        public static int percent = 100 ;
        HubConnection connection;
        Bitmap[,] sa = new Bitmap[10, 10];
        Bitmap[,] prev = new Bitmap[10, 10];
        int x = 10, y = 10;
        ControlPanel c = new ControlPanel();

        public Form1()
        {
            InitializeComponent();
            quality = PixelFormat.Format16bppRgb565;
            FPSRate = 10;
            encrypted = false;
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
            await connection.InvokeAsync("teacherconnected");

            //MessageBox.Show( await connection.InvokeAsync<string>("ok"));
        }
        public Bitmap Resized(Bitmap bmp)
        {
            if(percent == 100)return bmp;
            double dd = 1.0*bmp.Width / bmp.Height;
            int width = bmp.Width*percent/100,height=(int)(width/dd);
            Bitmap result = new Bitmap(width,height,quality );
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(bmp, 0, 0, width, height);
            return result;
        }
        private void UpdateScreen(string base64, int r, int c)
        {
            Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)))
                .Save("D:\\sc\\sc" + r + " " + c + ".jpg");
        }
        private Bitmap CaptureImage()
        {
            Bitmap b = new Bitmap(Width, Height-23,quality);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.CopyFromScreen(Left,Top, 0, 0, new Size(Width,Height-23), CopyPixelOperation.SourceCopy);
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
            return Resized(b);
        }

        static string pass = "mainmain";
        public static string xorIt(string input)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
                sb.Append((char)(input[i] ^ pass[(i % pass.Length)]));
            return sb.ToString();
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
                    if (!Compare(sa[i, j], prev[i, j]))
                    {
                        try
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                sa[i, j].Save(ms, ImageFormat.Jpeg);
                                string base64 = Convert.ToBase64String(ms.ToArray());
                                if(encrypted) base64 = xorIt(base64.Substring(0, 200)) + base64.Substring(200);
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
        private void L1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drag = true;
                posX = Cursor.Position.X - Left;
                posY = Cursor.Position.Y - Top;
            }
        }
        private void L1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        private void L1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Top = Cursor.Position.Y - posY;
                Top = Math.Max(Top, 0);
                Top = Math.Min(Bottom, Screen.PrimaryScreen.Bounds.Height)-Height;
                Left = Cursor.Position.X - posX;
                Left = Math.Max(Left, 0);
                Left = Math.Min(Right, Screen.PrimaryScreen.Bounds.Width)-Width;
                c.Left = Right;
                c.Top = Top;
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
                Width = Cursor.Position.X - Left>0?Cursor.Position.X - Left:0;
                c.Left = Right;
            }
        }
        private void Label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag) Height = Cursor.Position.Y - Top>0?Cursor.Position.Y -Top:0;
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            try{caster.Abort();}
            catch { }
            this.Close();
        }
        private void L2_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Width = Cursor.Position.X - Left;
                Height = Cursor.Position.Y - Top;
                c.Left = Right;
                c.Top = Top;
            }
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            c.Show();
            c.Top = Top;
            c.Left = Right;
        }
        #endregion

    }
}

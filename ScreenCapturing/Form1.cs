using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Runtime.InteropServices;
using ScreenCapturing.classes;
using Microsoft.AspNetCore.SignalR.Client;

namespace ScreenCapturing
{
    public partial class Form1 : Form
    {
        HubConnection connection;
        Bitmap[,] sa = new Bitmap[2,3];
        Bitmap[,] prev = new Bitmap[2,3];
        int height, width;
        public Form1()
        {

            InitializeComponent();
            updatesize();
            ConfigSignalRConnection();
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
        }

        private async void ConfigSignalRConnection()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/CastHub")
                .WithAutomaticReconnect()
                .Build();
            connection.On<string,int,int>("UpdateScreen", UpdateScreen);
            await connection.StartAsync();
            //MessageBox.Show( await connection.InvokeAsync<string>("ok"));
        }

        private void UpdateScreen(string base64,int r,int c)
        {
            Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)))
                .Save("D:\\sc\\sc"+r+" "+c+".jpg");
        }
        private readonly Stopwatch sw = new Stopwatch();
        private Bitmap CaptureImage(int x, int y, int i, int j)
        {
            Bitmap b = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(b))
                g.CopyFromScreen(x + width * j, y + height * i, 0, 0, b.Size, CopyPixelOperation.SourceCopy);

            return b;
        }
        EncoderParameters encoderParameters = new EncoderParameters(1);

        public void Cap()
        {
            try
            {
                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        //   sa[i, j] = GetDesktopImage(i,j);
                        sa[i, j] = CaptureImage(this.Left, this.Top, i, j);
                        if (!Compare(prev[i, j], sa[i, j]))
                        {
                            try
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    sa[i, j].Save(ms, ImageFormat.Jpeg);
                                    string base64 = Convert.ToBase64String(ms.ToArray());
                                    connection.InvokeAsync("UpdateScreen", base64, i, j);
                                }
                            }
                            catch (Exception e) { MessageBox.Show(e.Message); }
                            prev[i, j] = sa[i, j];
                        }
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        Thread caster = null;
        private void button1_Click(object sender, EventArgs e)
        {
            var d = DateTime.Now;
            sw.Start();
            caster = new Thread(cast);
            caster.Start();
            sw.Stop();
            MessageBox.Show((DateTime.Now - d).ToString());
        }
        void cast()
        {
            while(connection.State == HubConnectionState.Connected)
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

            for (int n = 0; n <= bytes - 1; n++)
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
            updatesize();
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
        void updatesize()
        {
            height = this.Height / 2;
            width = this.Width / 3;
        }
        int posX;
        int posY;
        bool drag;
        private void l2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.SizeNWSE;
        }
        private void l2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
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
   
        public Bitmap GetDesktopImage(int i,int j) {
            IntPtr hDC = WIN32_API.GetDC(WIN32_API.GetDesktopWindow()); 
            IntPtr hMemDC = WIN32_API.CreateCompatibleDC(hDC); 
            m_HBitmap = WIN32_API.CreateCompatibleBitmap(hDC, width, height); 
            if (m_HBitmap != IntPtr.Zero) { 
                IntPtr hOld = (IntPtr)WIN32_API.SelectObject(hMemDC, m_HBitmap);
                WIN32_API.BitBlt(hMemDC, 0, 0, width, height, hDC, this.Left+width*j, this.Top+height*i, WIN32_API.SRCCOPY); 
                WIN32_API.SelectObject(hMemDC, hOld); WIN32_API.DeleteDC(hMemDC); 
                WIN32_API.ReleaseDC(WIN32_API.GetDesktopWindow(), hDC); 
                return Image.FromHbitmap(m_HBitmap); 
            } 
            return null; 
        } 
        protected IntPtr m_HBitmap; 
    }
}

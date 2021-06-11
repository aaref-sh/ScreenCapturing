using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapturing
{
    public partial class ControlPanel : Form
    {
        static PixelFormat[] qualities = { PixelFormat.Format32bppArgb, PixelFormat.Format24bppRgb, PixelFormat.Format16bppRgb565};
        public ControlPanel()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 2;
            TopMost = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) =>
            Form1.quality = qualities[comboBox1.SelectedIndex];
        

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Form1.FPSRate = trackBar1.Value;
            fpslable.Text = trackBar1.Value+ " FPS";
        }

        private void ControlPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drag = true;
                posX = Cursor.Position.X - this.Left;
                posY = Cursor.Position.Y - this.Top;
            }
        }

        private void ControlPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - posY;
                this.Left = Cursor.Position.X - posX;
            }
            this.Cursor = Cursors.Default;
        }

        private void ControlPanel_MouseUp(object sender, MouseEventArgs e) => drag = false;
        
        int posX;
        int posY;
        bool drag;

        private void label3_Click(object sender, EventArgs e) => this.Hide();

        private void checkBox1_CheckedChanged(object sender, EventArgs e) => 
            Form1.encrypted = checkBox1.CheckState == CheckState.Checked;
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Form1.percent = trackBar2.Value;
            percentLabel.Text = trackBar2.Value + " %";
        }
    }
}

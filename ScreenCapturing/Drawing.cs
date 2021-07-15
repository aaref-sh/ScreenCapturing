using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenCapturing
{
    public partial class Drawing : Form
    {
        public static float thickness = 2;
        public Drawing()
        {
            InitializeComponent();
            TopMost = true;
            labelcolor.BackColor = colorDialog1.Color = Color.Red;
        }
        private void btnpickcolor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            labelcolor.BackColor = colorDialog1.Color;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) => thickness = (int)numericUpDown1.Value;

        private void btnerase_Click(object sender, EventArgs e) => Logger.form1.Clean();

        private void cbcross_CheckedChanged(object sender, EventArgs e)
        {
            if(cbcross.Checked) Logger.form1.pbpaintboard.Cursor = Cursors.Cross;
            else Logger.form1.pbpaintboard.Cursor = Cursors.Default;
        }
    }
}

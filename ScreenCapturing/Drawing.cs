using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenCapturing
{
    public partial class Drawing : Form
    {
        public static Color PickedColor = Color.Black;
        public static float thickness = 2;

        public Drawing()
        {
            InitializeComponent();
            TopMost = true;
            labelcolor.BackColor = PickedColor;
        }
        private void btnpickcolor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            PickedColor = colorDialog1.Color;
            labelcolor.BackColor = PickedColor;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) => thickness = (int)numericUpDown1.Value;

        private void btnerase_Click(object sender, EventArgs e) => Logger.form1.Clean();
    }
}

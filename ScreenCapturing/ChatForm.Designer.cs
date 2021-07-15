
namespace ScreenCapturing
{
    partial class ChatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.right_side = new System.Windows.Forms.Label();
            this.bottom_side = new System.Windows.Forms.Panel();
            this.corner_resizer = new System.Windows.Forms.Label();
            this.top_bar = new System.Windows.Forms.Panel();
            this.close_btn = new System.Windows.Forms.PictureBox();
            this.top_side = new System.Windows.Forms.Label();
            this.left_side = new System.Windows.Forms.Label();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.wpfChatForm1 = new ScreenCapturing.WPFChatForm();
            this.bottom_side.SuspendLayout();
            this.top_bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.close_btn)).BeginInit();
            this.SuspendLayout();
            // 
            // right_side
            // 
            this.right_side.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.right_side.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.right_side.Dock = System.Windows.Forms.DockStyle.Right;
            this.right_side.Location = new System.Drawing.Point(329, 0);
            this.right_side.Name = "right_side";
            this.right_side.Size = new System.Drawing.Size(2, 538);
            this.right_side.TabIndex = 3;
            this.right_side.MouseDown += new System.Windows.Forms.MouseEventHandler(this.d_MouseDown);
            this.right_side.MouseUp += new System.Windows.Forms.MouseEventHandler(this.d_MouseUp);
            // 
            // bottom_side
            // 
            this.bottom_side.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bottom_side.Controls.Add(this.corner_resizer);
            this.bottom_side.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.bottom_side.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottom_side.Location = new System.Drawing.Point(0, 538);
            this.bottom_side.Name = "bottom_side";
            this.bottom_side.Size = new System.Drawing.Size(332, 2);
            this.bottom_side.TabIndex = 4;
            this.bottom_side.MouseDown += new System.Windows.Forms.MouseEventHandler(this.d_MouseDown);
            this.bottom_side.MouseUp += new System.Windows.Forms.MouseEventHandler(this.d_MouseUp);
            // 
            // corner_resizer
            // 
            this.corner_resizer.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.corner_resizer.Dock = System.Windows.Forms.DockStyle.Right;
            this.corner_resizer.Location = new System.Drawing.Point(329, 0);
            this.corner_resizer.Name = "corner_resizer";
            this.corner_resizer.Size = new System.Drawing.Size(3, 3);
            this.corner_resizer.TabIndex = 0;
            this.corner_resizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.d_MouseDown);
            this.corner_resizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.d_MouseUp);
            // 
            // top_bar
            // 
            this.top_bar.BackColor = System.Drawing.Color.White;
            this.top_bar.Controls.Add(this.close_btn);
            this.top_bar.Controls.Add(this.top_side);
            this.top_bar.Cursor = System.Windows.Forms.Cursors.Default;
            this.top_bar.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_bar.Location = new System.Drawing.Point(2, 0);
            this.top_bar.Name = "top_bar";
            this.top_bar.Size = new System.Drawing.Size(327, 33);
            this.top_bar.TabIndex = 5;
            this.top_bar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.d_MouseDown);
            this.top_bar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.d_MouseMove);
            this.top_bar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.d_MouseUp);
            // 
            // close_btn
            // 
            this.close_btn.Dock = System.Windows.Forms.DockStyle.Right;
            this.close_btn.Image = global::ScreenCapturing.Properties.Resources.close;
            this.close_btn.Location = new System.Drawing.Point(294, 2);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(33, 31);
            this.close_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.close_btn.TabIndex = 0;
            this.close_btn.TabStop = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // top_side
            // 
            this.top_side.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.top_side.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_side.Location = new System.Drawing.Point(0, 0);
            this.top_side.Name = "top_side";
            this.top_side.Size = new System.Drawing.Size(327, 2);
            this.top_side.TabIndex = 1;
            // 
            // left_side
            // 
            this.left_side.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.left_side.Dock = System.Windows.Forms.DockStyle.Left;
            this.left_side.Location = new System.Drawing.Point(0, 0);
            this.left_side.Name = "left_side";
            this.left_side.Size = new System.Drawing.Size(2, 538);
            this.left_side.TabIndex = 6;
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(2, 33);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(327, 505);
            this.elementHost1.TabIndex = 7;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.wpfChatForm1;
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(332, 541);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.top_bar);
            this.Controls.Add(this.right_side);
            this.Controls.Add(this.left_side);
            this.Controls.Add(this.bottom_side);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChatForm";
            this.Text = "ChatForm";
            this.bottom_side.ResumeLayout(false);
            this.top_bar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.close_btn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label right_side;
        private System.Windows.Forms.Panel bottom_side;
        private System.Windows.Forms.Label corner_resizer;
        private System.Windows.Forms.Panel top_bar;
        private System.Windows.Forms.PictureBox close_btn;
        private System.Windows.Forms.Label top_side;
        private System.Windows.Forms.Label left_side;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private WPFChatForm wpfChatForm1;
    }
}
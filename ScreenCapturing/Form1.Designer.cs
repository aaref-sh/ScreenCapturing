
namespace ScreenCapturing
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.l2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbspeaker = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pbmic = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbspeaker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbmic)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 422);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // l2
            // 
            this.l2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.l2.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.l2.Location = new System.Drawing.Point(177, 17);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(7, 7);
            this.l2.TabIndex = 3;
            this.l2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.L1_MouseDown);
            this.l2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.L2_MouseMove);
            this.l2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.L1_MouseUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label3.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(798, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 422);
            this.label3.TabIndex = 7;
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.L1_MouseDown);
            this.label3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Label3_MouseMove);
            this.label3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.L1_MouseUp);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(800, 2);
            this.label4.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Red;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(127, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "X";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.Label5_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 424);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 26);
            this.panel4.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(600, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 24);
            this.panel1.TabIndex = 9;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.L1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.L1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.L1_MouseUp);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.l2);
            this.panel2.Controls.Add(this.pbspeaker);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.pbmic);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(17, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(183, 24);
            this.panel2.TabIndex = 13;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ScreenCapturing.Properties.Resources.settings;
            this.pictureBox2.Location = new System.Drawing.Point(36, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.settingsbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ScreenCapturing.Properties.Resources.Race5b6ada15b7f741d0a45499d679626;
            this.pictureBox1.Location = new System.Drawing.Point(4, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btnchat_Click);
            // 
            // pbspeaker
            // 
            this.pbspeaker.Image = ((System.Drawing.Image)(resources.GetObject("pbspeaker.Image")));
            this.pbspeaker.Location = new System.Drawing.Point(66, -2);
            this.pbspeaker.Name = "pbspeaker";
            this.pbspeaker.Size = new System.Drawing.Size(34, 26);
            this.pbspeaker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbspeaker.TabIndex = 12;
            this.pbspeaker.TabStop = false;
            this.pbspeaker.Click += new System.EventHandler(this.pbspeaker_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(149, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "▶";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // pbmic
            // 
            this.pbmic.Image = ((System.Drawing.Image)(resources.GetObject("pbmic.Image")));
            this.pbmic.Location = new System.Drawing.Point(100, -4);
            this.pbmic.Name = "pbmic";
            this.pbmic.Size = new System.Drawing.Size(23, 30);
            this.pbmic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbmic.TabIndex = 11;
            this.pbmic.TabStop = false;
            this.pbmic.Click += new System.EventHandler(this.pbmic_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 2);
            this.label1.TabIndex = 5;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.L1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.L1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbspeaker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbmic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbmic;
        private System.Windows.Forms.PictureBox pbspeaker;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}


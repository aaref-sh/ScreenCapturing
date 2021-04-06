
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
            this.label2 = new System.Windows.Forms.Label();
            this.l2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lcastrate = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
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
            this.l2.BackColor = System.Drawing.Color.White;
            this.l2.Location = new System.Drawing.Point(539, 16);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(7, 7);
            this.l2.TabIndex = 3;
            this.l2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.l1_MouseDown);
            this.l2.MouseEnter += new System.EventHandler(this.l2_MouseEnter);
            this.l2.MouseLeave += new System.EventHandler(this.l2_MouseLeave);
            this.l2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.l2_MouseMove);
            this.l2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.l1_MouseUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(798, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 422);
            this.label3.TabIndex = 7;
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.l1_MouseDown);
            this.label3.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.label3.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            this.label3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label3_MouseMove);
            this.label3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.l1_MouseUp);
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
            this.label5.Location = new System.Drawing.Point(187, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "X";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(457, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.lcastrate);
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.l2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(254, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(546, 24);
            this.panel1.TabIndex = 9;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.l1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.l1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.l1_MouseUp);
            // 
            // lcastrate
            // 
            this.lcastrate.AutoSize = true;
            this.lcastrate.Location = new System.Drawing.Point(318, 6);
            this.lcastrate.Name = "lcastrate";
            this.lcastrate.Size = new System.Drawing.Size(103, 13);
            this.lcastrate.TabIndex = 10;
            this.lcastrate.Text = "معدل البث 25 إطار\\ث";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(210, -2);
            this.trackBar1.Maximum = 25;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(102, 45);
            this.trackBar1.TabIndex = 9;
            this.trackBar1.Value = 25;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 2);
            this.label1.TabIndex = 5;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.l1_MouseDown);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.l1_MouseUp);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "عالية",
            "متوسطة",
            "ضعيفة"});
            this.comboBox1.Location = new System.Drawing.Point(122, -1);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox1.Size = new System.Drawing.Size(59, 23);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
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
        private System.Windows.Forms.Label lcastrate;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}



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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.l1 = new System.Windows.Forms.Label();
            this.l2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.DarkGray;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.l1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.l1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.l1_MouseUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 446);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(688, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(110, 446);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.l1);
            this.panel3.Controls.Add(this.l2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 420);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(110, 26);
            this.panel3.TabIndex = 4;
            // 
            // l1
            // 
            this.l1.BackColor = System.Drawing.Color.White;
            this.l1.Location = new System.Drawing.Point(85, 16);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(15, 10);
            this.l1.TabIndex = 2;
            this.l1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.l1_MouseDown);
            this.l1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.l1_MouseMove);
            this.l1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.l1_MouseUp);
            // 
            // l2
            // 
            this.l2.BackColor = System.Drawing.Color.White;
            this.l2.Location = new System.Drawing.Point(103, 19);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(10, 10);
            this.l2.TabIndex = 3;
            this.l2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.l1_MouseDown);
            this.l2.MouseEnter += new System.EventHandler(this.l2_MouseEnter);
            this.l2.MouseLeave += new System.EventHandler(this.l2_MouseLeave);
            this.l2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.l2_MouseMove);
            this.l2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.l1_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 448);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(798, 2);
            this.label1.TabIndex = 5;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.l1_MouseDown);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.l1_MouseUp);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(798, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 448);
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
            this.label5.Font = new System.Drawing.Font("Yu Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(82, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 26);
            this.label5.TabIndex = 5;
            this.label5.Text = "X";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}


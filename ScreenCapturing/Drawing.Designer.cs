
namespace ScreenCapturing
{
    partial class Drawing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Drawing));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelcolor = new System.Windows.Forms.Label();
            this.btnerase = new System.Windows.Forms.Button();
            this.cbcross = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(41, 13);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // labelcolor
            // 
            this.labelcolor.Location = new System.Drawing.Point(9, 14);
            this.labelcolor.Name = "labelcolor";
            this.labelcolor.Size = new System.Drawing.Size(18, 18);
            this.labelcolor.TabIndex = 3;
            this.labelcolor.Click += new System.EventHandler(this.btnpickcolor_Click);
            // 
            // btnerase
            // 
            this.btnerase.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnerase.Location = new System.Drawing.Point(122, 12);
            this.btnerase.Name = "btnerase";
            this.btnerase.Size = new System.Drawing.Size(57, 23);
            this.btnerase.TabIndex = 4;
            this.btnerase.Text = "مسح";
            this.btnerase.UseVisualStyleBackColor = true;
            this.btnerase.Click += new System.EventHandler(this.btnerase_Click);
            // 
            // cbcross
            // 
            this.cbcross.AutoSize = true;
            this.cbcross.Checked = true;
            this.cbcross.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbcross.Location = new System.Drawing.Point(193, 15);
            this.cbcross.Name = "cbcross";
            this.cbcross.Size = new System.Drawing.Size(34, 17);
            this.cbcross.TabIndex = 5;
            this.cbcross.Text = "+";
            this.cbcross.UseVisualStyleBackColor = true;
            this.cbcross.CheckedChanged += new System.EventHandler(this.cbcross_CheckedChanged);
            // 
            // Drawing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 50);
            this.Controls.Add(this.cbcross);
            this.Controls.Add(this.btnerase);
            this.Controls.Add(this.labelcolor);
            this.Controls.Add(this.numericUpDown1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Drawing";
            this.Text = "Drawing";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        public System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label labelcolor;
        private System.Windows.Forms.Button btnerase;
        private System.Windows.Forms.CheckBox cbcross;
    }
}

namespace ScreenCapturing
{
    partial class Chat
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
            this.tbmessage = new System.Windows.Forms.TextBox();
            this.pbsend = new System.Windows.Forms.PictureBox();
            this.rtbmessages = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbsend)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbmessage);
            this.panel1.Controls.Add(this.pbsend);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 442);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 84);
            this.panel1.TabIndex = 1;
            // 
            // tbmessage
            // 
            this.tbmessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbmessage.Location = new System.Drawing.Point(0, 0);
            this.tbmessage.Multiline = true;
            this.tbmessage.Name = "tbmessage";
            this.tbmessage.Size = new System.Drawing.Size(267, 84);
            this.tbmessage.TabIndex = 0;
            // 
            // pbsend
            // 
            this.pbsend.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbsend.Image = global::ScreenCapturing.Properties.Resources.ic_menu_send;
            this.pbsend.Location = new System.Drawing.Point(267, 0);
            this.pbsend.Name = "pbsend";
            this.pbsend.Size = new System.Drawing.Size(49, 84);
            this.pbsend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbsend.TabIndex = 1;
            this.pbsend.TabStop = false;
            this.pbsend.Click += new System.EventHandler(this.pbsend_Click);
            // 
            // rtbmessages
            // 
            this.rtbmessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbmessages.Location = new System.Drawing.Point(0, 0);
            this.rtbmessages.Name = "rtbmessages";
            this.rtbmessages.Size = new System.Drawing.Size(316, 442);
            this.rtbmessages.TabIndex = 2;
            this.rtbmessages.Text = "";
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 526);
            this.Controls.Add(this.rtbmessages);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Chat";
            this.Text = "CHat";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbsend)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbmessage;
        private System.Windows.Forms.PictureBox pbsend;
        private System.Windows.Forms.RichTextBox rtbmessages;
    }
}
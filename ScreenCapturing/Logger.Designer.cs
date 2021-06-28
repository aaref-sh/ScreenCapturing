
namespace ScreenCapturing
{
    partial class Logger
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.creatroomname_tb = new System.Windows.Forms.TextBox();
            this.create_btn = new System.Windows.Forms.Button();
            this.login_btn = new System.Windows.Forms.Button();
            this.session_list = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.updatelistbtn = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(478, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "إنشاء محاضرة";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(478, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "اسم المحاضرة";
            // 
            // creatroomname_tb
            // 
            this.creatroomname_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.creatroomname_tb.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.creatroomname_tb.Location = new System.Drawing.Point(127, 36);
            this.creatroomname_tb.Margin = new System.Windows.Forms.Padding(4);
            this.creatroomname_tb.Name = "creatroomname_tb";
            this.creatroomname_tb.Size = new System.Drawing.Size(345, 22);
            this.creatroomname_tb.TabIndex = 1;
            // 
            // create_btn
            // 
            this.create_btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.create_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.create_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.create_btn.Location = new System.Drawing.Point(7, 33);
            this.create_btn.Margin = new System.Windows.Forms.Padding(4);
            this.create_btn.Name = "create_btn";
            this.create_btn.Size = new System.Drawing.Size(112, 27);
            this.create_btn.TabIndex = 2;
            this.create_btn.Text = "إنشاء";
            this.create_btn.UseVisualStyleBackColor = true;
            this.create_btn.Click += new System.EventHandler(this.Create_btn_Click);
            // 
            // login_btn
            // 
            this.login_btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.login_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.login_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_btn.Location = new System.Drawing.Point(478, 157);
            this.login_btn.Margin = new System.Windows.Forms.Padding(4);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(73, 34);
            this.login_btn.TabIndex = 2;
            this.login_btn.Text = "دخول";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.Login_btn_Click);
            // 
            // session_list
            // 
            this.session_list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.session_list.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.session_list.FormattingEnabled = true;
            this.session_list.ItemHeight = 23;
            this.session_list.Location = new System.Drawing.Point(7, 26);
            this.session_list.Margin = new System.Windows.Forms.Padding(4);
            this.session_list.Name = "session_list";
            this.session_list.Size = new System.Drawing.Size(463, 161);
            this.session_list.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.create_btn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.creatroomname_tb);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 74);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "إنشاء محاضرة";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.updatelistbtn);
            this.groupBox2.Controls.Add(this.btndelete);
            this.groupBox2.Controls.Add(this.session_list);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.login_btn);
            this.groupBox2.Location = new System.Drawing.Point(12, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 213);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "الدخول لمحاضرة";
            // 
            // updatelistbtn
            // 
            this.updatelistbtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.updatelistbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.updatelistbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updatelistbtn.Location = new System.Drawing.Point(478, 55);
            this.updatelistbtn.Name = "updatelistbtn";
            this.updatelistbtn.Size = new System.Drawing.Size(75, 33);
            this.updatelistbtn.TabIndex = 5;
            this.updatelistbtn.Text = "تحديث";
            this.updatelistbtn.UseVisualStyleBackColor = true;
            this.updatelistbtn.Click += new System.EventHandler(this.updatelistbtn_Click);
            // 
            // btndelete
            // 
            this.btndelete.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btndelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelete.Location = new System.Drawing.Point(478, 114);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(73, 36);
            this.btndelete.TabIndex = 4;
            this.btndelete.Text = "حذف";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.Btndelete_Click);
            // 
            // Logger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 313);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Logger";
            this.RightToLeftLayout = true;
            this.Text = "Logger";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox creatroomname_tb;
        private System.Windows.Forms.Button create_btn;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.ListBox session_list;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button updatelistbtn;
    }
}
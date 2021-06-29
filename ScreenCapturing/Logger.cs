using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using ScreenCapturing.classes;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Helpers;
using System.Windows.Forms;

namespace ScreenCapturing
{
    public partial class Logger : Form
    {
        public static string room_name;
        public static Form1 form1;
        public static string URL = "192.168.1.111";

        [Obsolete]
        public Logger()
        {
            InitializeComponent();
            session_list.MouseDoubleClick += Session_list_MouseDoubleClick;
            Get_sessions();
        }
        List<string> SessionList;
        void Get_sessions()
        {
            SessionList?.Clear();
            session_list.Items.Clear();
            try
            {
                var response = Http.Post("http://"+URL+":5000/api/Rooms/GetRooms", new NameValueCollection() {});
                string result = Encoding.UTF8.GetString(response);
                SessionList = Json.Decode<List<string>>(result);
                foreach (var session in SessionList) session_list.Items.Add(session);
            }
            catch { MessageBox.Show("فشل الوصول للخادم"); }
        }

        [Obsolete]
        private void Session_list_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (session_list.SelectedIndex != -1)
            {
                room_name = SessionList[session_list.SelectedIndex];
                form1 = new Form1();
                form1.Show();
                Hide();
            }
        }
        private void Create_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(creatroomname_tb.Text))
                {
                    Createroom();
                    creatroomname_tb.Text = "";
                }
            }
            catch { MessageBox.Show("فشل إنشاء المحاضرة"); }
        }
        async void post(string action,string room_name)
        {
            try
            {
                string myJson = "{\"room_name\": \"" + room_name + "\"}";
                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync("http://" + URL + ":5000/api/Rooms/" + action,
                        new StringContent(myJson, Encoding.UTF8, "application/json"));
                    if (action == "CreateRoom") if (!bool.Parse(response.Content.ReadAsStringAsync().Result)) MessageBox.Show("فشل إنشاء المحاضرة");
                    Get_sessions();
                }
            }
            catch { MessageBox.Show("فشل الوصول للخادم"); }
        }
        void Createroom() => post("CreateRoom", creatroomname_tb.Text);

        [Obsolete]
        private void Login_btn_Click(object sender, EventArgs e)
        {
            if (session_list.SelectedIndex != -1)
            {
                room_name = SessionList[session_list.SelectedIndex];
                form1 = new Form1();
                form1.Show();
                Hide();
            }
        }
        private void Btndelete_Click(object sender, EventArgs e)
        {
            if (session_list.SelectedIndex == -1)
            {
                MessageBox.Show("اختر محاضرة للحذف");
                return;
            }
            try
            {
                post("DeleteRoom", SessionList[session_list.SelectedIndex]);
            }
            catch { MessageBox.Show("فشل الحذف"); }
        }
        private void updatelistbtn_Click(object sender, EventArgs e) => Get_sessions();

        private void creatroomname_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) Create_btn_Click(sender, e);
        }
    }
}

using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Web.Helpers;
using System.Windows.Forms;

namespace ScreenCapturing
{
    public partial class Logger : Form
    {
        HubConnection connection;
        public static string room_name;
        public static Form1 form1;
        public Logger()
        {
            InitializeComponent();
            Configsignalr();
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
                using (WebClient client = new WebClient())
                {
                    byte[] response = client.UploadValues("http://192.168.1.111:5000/api/Rooms/get_rooms", new NameValueCollection() { });
                    string result = Encoding.UTF8.GetString(response);
                    SessionList = Json.Decode<List<string>>(result);
                }
                foreach (var session in SessionList) session_list.Items.Add(session);
            }
            catch { MessageBox.Show("فشل الوصول للخادم"); }
        }
        private void Session_list_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (session_list.SelectedIndex != -1)
            {
                room_name = SessionList[session_list.SelectedIndex];
                connection.DisposeAsync();
                form1 = new Form1();
                form1.Show();
                Hide();
            }
        }
        async void Configsignalr()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://192.168.1.111:5000/CastHub")
                .WithAutomaticReconnect()
                .Build();
            await connection.StartAsync();
        }
        private void Create_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(creatroomname_tb.Text.Trim()))
                {
                    Createroom();
                    creatroomname_tb.Text = "";
                }
            }
            catch { MessageBox.Show("فشل إنشاء المحاضرة"); }
        }
        async void Createroom()
        {

            if( await connection.InvokeAsync<bool>("CreateRoom", creatroomname_tb.Text.ToString().Trim()))
            {
                Get_sessions();
                MessageBox.Show("تم إنشاء المحاضرة");
            }
            else
            {
                MessageBox.Show("اختر اسم محاضرة آخر");
            }
        }
        private void Login_btn_Click(object sender, EventArgs e)
        {
            if (session_list.SelectedIndex != -1)
            {
                room_name = SessionList[session_list.SelectedIndex];
                connection.DisposeAsync();
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
                Deletesession();
                MessageBox.Show("تم الحذف");
            }
            catch { MessageBox.Show("فشل الحذف"); }
        }
        async void Deletesession()
        {

            await connection.InvokeAsync("DeleteRoom", SessionList[session_list.SelectedIndex]);
            Get_sessions();
        }

        private void updatelistbtn_Click(object sender, EventArgs e)
        {
            Get_sessions();
        }
    }
}

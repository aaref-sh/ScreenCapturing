using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.AspNetCore.SignalR.Client;
using ScreenCapturing.classes;
using TextBlock = Emoji.Wpf.TextBlock;

namespace ScreenCapturing
{
    /// <summary>
    /// Interaction logic for WPFChatForm.xaml
    /// </summary>
    public partial class WPFChatForm : UserControl
    {
        public WPFChatForm()
        {
            InitializeComponent();
            sendimg.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Resources/ic_menu_send.png"));
        }
        public void adds() => Form1.connection.On<string, string>("newMessage", NewMessage);
        void NewMessage(string sender,string message)
        {
            Border b = new Border();
            b.CornerRadius = new CornerRadius(8);
            b.BorderBrush = (sender == "Teacher")?Brushes.DarkGreen:Brushes.Gray;
            b.BorderThickness = new Thickness(2);

            Frame container = new Frame();
            container.MouseDoubleClick += (s, e) => { };
            //b.Margin = new Thickness (5,5,5,0);
            StackPanel msg = new StackPanel();
            Label sndr = new Label();
            sndr.FontSize = 11;
            sndr.Foreground = (sender == "Teacher")?Brushes.DarkGreen:Brushes.DarkGray;
            container.MouseDoubleClick += Container_MouseDoubleClick;
            TextBlock mesg = new TextBlock();
            mesg.Text = DESDecrypt(message);
            mesg.TextWrapping = TextWrapping.Wrap;
            mesg.FontSize = 16;
            mesg.FontFamily = new FontFamily("Times New Roman");
            mesg.Foreground = Brushes.Black;
            mesg.Margin = new Thickness (3,0,3,3);
            sndr.Content = sender;
            if (ia(message[0])) mesg.FlowDirection = FlowDirection.RightToLeft;
            msg.Children.Add(sndr);
            msg.Children.Add(mesg);
            container.Content = msg;

            b.Child = container;
            WrapPanel wp = new WrapPanel();
            wp.Margin = new Thickness(5, 5, 5, 0);
            wp.Children.Add(b);
            MessageList.Children.Add(wp);
            scrollViewer.ScrollToEnd();
        }

        private void Container_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var text = (((sender as Frame).Content as StackPanel).Children[1] as TextBlock).Text;
                Clipboard.SetText(text);
                (((sender as Frame).Content as StackPanel).Children[1] as TextBlock).Text = "تم النسخ ✔";
                reset(sender,text);
            }
            catch { }
        }
        async void reset(Object sender,string text)
        {
            await System.Threading.Tasks.Task.Delay(500).ContinueWith(_ =>{});
            (((sender as Frame).Content as StackPanel).Children[1] as TextBlock).Text = text;

        }
        public static bool ia(char glyph)
        {
            if (glyph >= 0x600 && glyph <= 0x6ff) return true;
            if (glyph >= 0x750 && glyph <= 0x77f) return true;
            if (glyph >= 0xfb50 && glyph <= 0xfc3f) return true;
            if (glyph >= 0xfe70 && glyph <= 0xfefc) return true;
            return false;
        }
        public void Image_MouseLeftButtonDown(object sender, EventArgs e)
        {
            if (MessageTextBox.Text.Trim() != string.Empty)
            {
                Form1.connection.SendAsync("newMessage", DESEncrypt(MessageTextBox.Text.Trim()));
                MessageTextBox.Text = "";
            }
        }
        private void picker_Picked(object sender, Emoji.Wpf.EmojiPickedEventArgs e) => MessageTextBox.Text += e.Emoji;
        public void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            picker.Focus();
            MessageTextBox.Focus();
            if (e.Key == Key.Enter && MessageTextBox.Text.Trim() != string.Empty)
            {
                Form1.connection.SendAsync("newMessage",DESEncrypt(MessageTextBox.Text.Trim()));
                MessageTextBox.Text = "";
            }
        }
        public static byte[] key;
        static string DESEncrypt(string original)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(key, key), CryptoStreamMode.Write);
                using (StreamWriter writer = new StreamWriter(cryptoStream))
                {
                    writer.Write(original);
                    writer.Flush();
                    cryptoStream.FlushFinalBlock();
                    writer.Flush();
                    cryptoProvider.Dispose();
                    return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
                }
            }
        }
        static string DESDecrypt(string crypted)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(crypted));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(key, key), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();

        }
        public void MessageTextBox_TextChanged(object sender, EventArgs e)
        {
            if (MessageTextBox.Text.Trim() != string.Empty)
                if (ia(MessageTextBox.Text[0]))
                    MessageTextBox.FlowDirection = FlowDirection.RightToLeft;
                else MessageTextBox.FlowDirection = FlowDirection.LeftToRight;
        }

        private void MessageList_MouseMove(object sender, MouseEventArgs e)
        {
            MessageBox.Show("shit");
        }
    }
}

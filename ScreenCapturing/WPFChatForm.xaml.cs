using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.AspNetCore.SignalR.Client;
using Emoji.Wpf;
using TextBlock = Emoji.Wpf.TextBlock;

namespace ScreenCapturing
{
    /// <summary>
    /// Interaction logic for WPFChatForm.xaml
    /// </summary>
    public partial class WPFChatForm : UserControl
    {
        string sendpic = "iVBORw0KGgoAAAANSUhEUgAAADAAAAAwCAQAAAD9CzEMAAAAAmJLR0QA/4ePzL8AAAAJcEhZcwAAAEgAAABIAEbJaz4AAAAJdnBBZwAAADAAAAAwAM7ujFcAAAQjSURBVFjD7Zbba9xFFMe/Z2Y32e79kottmkQNsWklKYpQCqEUraBYCRQxouBDEZ/Fv8AXX8TYJBZ8iUiDjSiFNiAUCfgqmpRkN9bdbaCkjdlLmuz+9pbrzhwfQmzc/W2ySSwo5Lz9fsx8P+c2ZwY4tEP7zxvt8I+fPJwOLiJNvPehG0frVpcLgJX0ASFmgO72V33PzbeQqy6fPzDEDPBsZ8dtf4MvcjzRKlyBQr4A1JLaJ6R0m4BGl+vtSMMxXhTXNq5mZ2Mi7LmbihGclN9H4ansm8Vx/e7tttegWFJKDG98WbgfE2FPKBUHu/YMEeW/zqSQDTGgScGnPpIT3oETz7yc7hWv+5pyYHbuqbtMlrKgS++fu2ZjJjA0BBMZ4roayM3EKeIOGjGwm3JVRlIGIGJG96meca9dMRHwNyQrRlR/LhqniCuUma8WUh6BgMbJI+8Ej7ZrTVsZ3ILkxYjqz4UTFHEFM/NgL2V2gZTXgAF7aiUzyaDHOwkSIAWH+pDGvV+3P38+2yvecDcbYPbuWBNTwOU0jGm9HbAdYleX6VfvN+1d53O94qKrJb4jpBL7zZ5XbtlZmzYBNCQTrYgb6kphMkFR+9TEXAf7KW2SLvNpyjjTfOmu31XcLLOZaRCIVsVN1Ze/k6SoPTg2d1Y3IVYFQECj3fLeWPNLWAZBoKZkGUPCCqGhBROtiVH1eWE8Ke7pSTyoMgJy8EVPm83KzLBQvaUUYCM7NTmG7DYuQjLRqvhRDRV+Tm6MIgraniiLCYCBC4Wx2Yw9YwGDYI2XuSGkRutT605bUZIiwbXqLVF0/baRbkD0nyvNAAQeO4ZzH7S2WdbYgoAQXOqBgxxwwqE0EVtoXY6qz3ITSRGlqdIqVwAg4PZ8YmtSLAjgSr3GTLQmb6m+7HiS7tVO9Tz8XjdigXcBEDNQ33EkwJqVqTZDw8qC1uRN1Ze9k6CoI/jT3EndRkSljWoCYF4UdY0v1tpYk9VUXDLRiryhrmQmkxR1TP0y18l+SpPZ0CgHEPisE75TFrAuOeibE0nSsvxB9WeCCYo6g/E5J/vIoEoTyawGmPHD+4IACxPxgvxODRi/JyjqmspujjvaadyZRgB/vbuDoLeO8ZZ4To6oASOcoIg7mJkHeyhLuw3scoAG0HC6JlDieVZeVwNGNE4RT8jYvA12Fa+Qoi+sHzd22YgVCSgIlmTIb9WgMROniGfrPqtK3AxA4E/d8HZK8KZ4Wg6rwfT9uAh7p9MxsIvyVYtXACz5rZ7TBF1DS3K4OGjMxkXEF0rFgL2KmwEYQKDZeUKkMVS8mn4YE+FAaHEB7KDlfT2HzQD+p61fbfQbf8bEH3XTiwtLsNHanj1/nJKyFKFLXtCrHKmffvQIqKH1J/CQr2vxAAzrv/KArxzb/1X80A5tr/YXN+HoEE9YlVAAAAAldEVYdGRhdGU6Y3JlYXRlADIwMTEtMDEtMjhUMjI6NDc6NTMtMDg6MDCkTnLJAAAAJXRFWHRkYXRlOm1vZGlmeQAyMDExLTAxLTI4VDIyOjQ3OjUzLTA4OjAw1RPKdQAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAAASUVORK5CYII=";
        public WPFChatForm()
        {
            InitializeComponent();
            byte[] binaryData = Convert.FromBase64String(sendpic);

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(binaryData);
            bi.EndInit();
            sendimg.Source = bi;
        }
        public void adds()
        {
            Form1.connection.On<string, string>("newMessage", NewMessage);
        }
        void NewMessage(string sender,string message)
        {
            Border b = new Border();
            b.CornerRadius = new CornerRadius(8);
            b.BorderBrush = (sender == "Teacher")?Brushes.DarkGreen:Brushes.Gray;
            b.BorderThickness = new Thickness(2);

            Frame container = new Frame();
            container.MouseDoubleClick += (s, e) => { };
            b.Margin = new Thickness { Left = 5, Right = 5, Top = 5 };
            StackPanel msg = new StackPanel();
            Label sndr = new Label();
            sndr.FontSize = 11;
            sndr.Foreground = (sender == "Teacher")?Brushes.DarkGreen:Brushes.DarkGray;

            TextBlock mesg = new TextBlock();
            mesg.Text = message;
            mesg.FontSize = 14;
            mesg.Foreground = Brushes.Black;
            mesg.Margin = new Thickness { Right = 3, Bottom = 3, Left = 3 };
            sndr.Content = sender;
            if (ia(message[0])) mesg.FlowDirection = FlowDirection.RightToLeft;
            msg.Children.Add(sndr);
            msg.Children.Add(mesg);
            container.Content = msg;

            b.Child = container;
            MessageList.Children.Add(b);
            scrollViewer.ScrollToEnd();
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
                Form1.connection.InvokeAsync("newMessage", MessageTextBox.Text.Trim());
                MessageTextBox.Text = "";
            }
        }
        private void picker_Picked(object sender, Emoji.Wpf.EmojiPickedEventArgs e)
        {
            MessageTextBox.Text += e.Emoji;
        }
        public void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            picker.Focus();
            MessageTextBox.Focus();
            if (e.Key == Key.Enter && MessageTextBox.Text.Trim() != string.Empty)
            {
                Form1.connection.InvokeAsync("newMessage", MessageTextBox.Text.Trim());
                MessageTextBox.Text = "";
            }
        }
        public void MessageTextBox_TextChanged(object sender, EventArgs e)
        {
            if (MessageTextBox.Text.Trim() != string.Empty)
            {
                if (ia(MessageTextBox.Text[0]))
                {
                    //MessageTextBox.FlowDirection = FlowDirection.RightToLeft;
                    MessageTextBox.TextAlignment = TextAlignment.Right;
                }
                else
                {
                    //MessageTextBox.FlowDirection = FlowDirection.LeftToRight;
                    MessageTextBox.TextAlignment = TextAlignment.Left;
                }
            }
        }
    }
}

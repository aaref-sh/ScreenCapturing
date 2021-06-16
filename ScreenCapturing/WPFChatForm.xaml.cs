using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.AspNetCore.SignalR.Client;
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
            //b.Margin = new Thickness (5,5,5,0);
            StackPanel msg = new StackPanel();
            Label sndr = new Label();
            sndr.FontSize = 11;
            sndr.Foreground = (sender == "Teacher")?Brushes.DarkGreen:Brushes.DarkGray;
            container.MouseDoubleClick += Container_MouseDoubleClick;
            TextBlock mesg = new TextBlock();
            mesg.Text = message;
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

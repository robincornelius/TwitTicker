using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using TweetSharp;
using System.Text.RegularExpressions;

namespace TwitScroll
{
    public partial class Tweetdisplay : UserControl
    {
        public event AtLinkedCLicked atlinkclicked;
        private TwitterStatus _status;

        protected void OnAtLinkedCLicked(string link)
        {
            AtLinkClickedEventArgs e = new AtLinkClickedEventArgs();
            e.handle = link;

            if (atlinkclicked != null)
            {
                atlinkclicked(this, e);
            }

        }

        public Tweetdisplay()
        {
            InitializeComponent();
            richTextBox1.LinkClicked += new LinkClickedEventHandler(richTextBox1_LinkClicked);
         
            richTextBox1.MouseDown += new MouseEventHandler(richTextBox1_MouseDown);
        }

        void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Determine whether the user clicks the left mouse button and whether it is a double click.
            if (e.Clicks == 1 && e.Button == MouseButtons.Left)
            {
                // Obtain the character index where the user clicks on the control.
                int positionToSearch = richTextBox1.GetCharIndexFromPosition(new Point(e.X, e.Y));

 
                char[] text = richTextBox1.Text.ToCharArray();

                int fwd,rev;
                for(fwd=positionToSearch;fwd<richTextBox1.Text.Length;fwd++)
                {
                    if(text[fwd]==' ')
                        break;
                }

                for (rev = positionToSearch; rev > 0; rev--)
                {
                    if (text[rev] == ' ')
                        break;
                }

                string click = richTextBox1.Text.Substring(rev, fwd - rev);

                click = click.Trim();
                click = click.TrimEnd(':');

                if (click.Substring(0, 1) == "@")
                {
                   OnAtLinkedCLicked(click);
                }
            }
        }


        void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        public void setdata(TwitterStatus status, System.Drawing.Bitmap img)
        {
            _status = status;

            this.richTextBox1.Clear();
            this.richTextBox1.Text = status.Text;

            int index = 0;
            while (index != -1)
            {
                index = richTextBox1.Text.IndexOf('@', index);
                if (index == -1)
                    break;

                int index2 = richTextBox1.Text.IndexOf(' ', index);

                if (index2 == -1)
                    break;

                richTextBox1.SelectionStart = index;
                richTextBox1.SelectionLength = index2 - index;
                richTextBox1.SelectionColor = Color.Blue;
                index++;
            }

            richTextBox1.SelectionLength = 0;

            string source;
            source = StripHTML(status.Source);

            this.textBox_name.Text = status.User.ScreenName;
            this.textBox1.Text = status.CreatedDate.ToShortTimeString() + " via " + source;
            this.pictureBox1.Image = img;

        }

        const string HTML_TAG_PATTERN = "<.*?>";

        static string StripHTML(string inputString)
        {
            return Regex.Replace
              (inputString, HTML_TAG_PATTERN, string.Empty);
        }

    }

    // A delegate type for hooking up change notifications.
    public delegate void AtLinkedCLicked(object sender, AtLinkClickedEventArgs e);

    public class AtLinkClickedEventArgs : EventArgs
    {
        public string handle;
    }

}

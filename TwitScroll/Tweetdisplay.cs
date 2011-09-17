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
using System.Web;

namespace TwitTicker
{
    public partial class Tweetdisplay : UserControl
    {
        private TwitterStatus _status;
        private string clickholder;

        protected void OnAtLinkedCLicked(string link,MouseButtons buttons)
        {
            if (buttons == MouseButtons.Left)
            {
                followlink(link);
            }

            if (buttons == MouseButtons.Right)
            {
                contextMenuStrip1.Items[0].Visible = true;
                contextMenuStrip1.Items[1].Visible = true;
                contextMenuStrip1.Items[2].Visible = true;

                contextMenuStrip1.Items[0].Text = "Follow "+link;
                contextMenuStrip1.Items[1].Text = "View tweets of " + link;

                clickholder = link;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        protected void OnHashLinkedCLicked(string link, MouseButtons buttons)
        {
           
            if (buttons == MouseButtons.Left)
            {
                followlink(link);
            }

            if (buttons == MouseButtons.Right)
            {
                contextMenuStrip1.Items[0].Visible = false;
                contextMenuStrip1.Items[1].Visible = true;
                contextMenuStrip1.Items[2].Visible = true;

                contextMenuStrip1.Items[1].Text = "View tweets on " + link;

                clickholder = link;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        protected void OnHttpLinkedCLicked(string link, MouseButtons buttons)
        {
            if (buttons == MouseButtons.Left)
            {
                followlink(link);
            }

            if (buttons == MouseButtons.Right)
            {
                contextMenuStrip1.Items[0].Visible = false;
                contextMenuStrip1.Items[1].Visible = true;
                contextMenuStrip1.Items[2].Visible = true;

                contextMenuStrip1.Items[1].Text = "Open " + link+ " in browser";

                clickholder = link;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        public Tweetdisplay()
        {
            //Activate double buffering
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            //Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            SetStyle(ControlStyles.EnableNotifyMessage, true);

            InitializeComponent();
            richTextBox1.LinkClicked += new LinkClickedEventHandler(richTextBox1_LinkClicked);
         
            richTextBox1.MouseDown += new MouseEventHandler(richTextBox1_MouseDown);
            MouseClick += new MouseEventHandler(Tweetdisplay_MouseClick);
            pictureBox1.MouseClick += new MouseEventHandler(Tweetdisplay_MouseClick);
            textBox_name.MouseClick += new MouseEventHandler(Tweetdisplay_MouseClick);
            textBox1.MouseClick += new MouseEventHandler(Tweetdisplay_MouseClick);
        }

        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }

        void Tweetdisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button ==  System.Windows.Forms.MouseButtons.Right)
                contextMenuStrip1.Show(Cursor.Position);
        }

        void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {

            if (_status == null)
                return;

            // Determine whether the user clicks the left mouse button and whether it is a double click.
            if (e.Clicks == 1 )
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

                if (click.Length> 1 && click.Substring(0, 1) == "@")
                {
                   OnAtLinkedCLicked(click,e.Button);
                   return;
                }
                else if (click.Length > 1 && click.Substring(0, 1) == "#")
                {
                    OnHashLinkedCLicked(click,e.Button);
                    return;
                }
                else if (click.Length>7 && click.Substring(0, 7) == "http://")
                {
                    OnHttpLinkedCLicked(click, e.Button);
                    return;
                }
            }


            if (e.Clicks == 1 && e.Button == MouseButtons.Right)
            {
                if (_status.RetweetedStatus != null)
                {
                    // treat this case the same as an @ link click
                    OnAtLinkedCLicked("@" + _status.RetweetedStatus.User.ScreenName, System.Windows.Forms.MouseButtons.Right);
                    return;
                }

                string link = "@"+_status.User.ScreenName;
                contextMenuStrip1.Items[1].Text = "View tweets from " + link;
                clickholder = link;

                Tweetdisplay_MouseClick(sender, e);
                return;
            }
        }


        void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        public void setdata(TwitterStatus status)
        {
            _status = status;
             System.Drawing.Bitmap img;
             richTextBox1.Clear();
             string source;

             if (status.RetweetedStatus == null)
             {
                 img = ImgMgr.getprofileimage(status.User);
                 richTextBox1.Text = status.Text;
                 source = StripHTML(status.Source);
                 textBox_name.Text = status.User.ScreenName;
             }

             else
             {
                 img = ImgMgr.getprofileimage(status.RetweetedStatus.User);
                 richTextBox1.Text = status.RetweetedStatus.Text;
                 //source = StripHTML(status.RetweetedStatus.Source);
                 source = StripHTML("RT by @"+status.User.ScreenName);
                 textBox_name.Text = status.RetweetedStatus.User.ScreenName;
             }

            //Fixme better parser needed

            int index = 0;
            while (index != -1)
            {
                index = richTextBox1.Text.IndexOf('@', index);
                if (index == -1)
                    break;

                int index2 = richTextBox1.Text.IndexOf(' ', index);

                if (index2 == -1)
                    index2 = richTextBox1.Text.Length;

                richTextBox1.SelectionStart = index;
                richTextBox1.SelectionLength = index2 - index;
                richTextBox1.SelectionColor = Color.Blue;
                index++;
            }

            index = 0;
            while (index != -1)
            {
                index = richTextBox1.Text.IndexOf('#', index);
                if (index == -1)
                    break;

                int index2 = richTextBox1.Text.IndexOf(' ', index);

                if (index2 == -1)
                    index2 = richTextBox1.Text.Length;

                richTextBox1.SelectionStart = index;
                richTextBox1.SelectionLength = index2 - index;
                richTextBox1.SelectionColor = Color.Green;
                index++;
            }

            richTextBox1.SelectionLength = 0;

            if (_status.RetweetedStatus != null)
            {
                  textBox1.Text = status.CreatedDate.ToShortTimeString()  +" RT by @"+_status.User.ScreenName;
            }
            else if (_status.InReplyToScreenName != null)
            {
                textBox1.Text = status.CreatedDate.ToShortTimeString() + " in reply to " + _status.InReplyToScreenName;
            }
            else
            {
                textBox1.Text = status.CreatedDate.ToShortTimeString() + " via " + source;
            }

            if(img!=null)
                pictureBox1.Image = img;

            // Vanity

            if (status.User.ScreenName == TweetBar.autheduser.ScreenName)
            {
                BackColor = Color.LightBlue;
                textBox_name.BackColor = Color.LightBlue;
                textBox1.BackColor = Color.LightBlue;
                richTextBox1.BackColor = Color.LightBlue;
            }
            else if (status.Text.Contains(TweetBar.autheduser.ScreenName))
            {
                BackColor = Color.LightGreen;
                textBox_name.BackColor = Color.LightGreen;
                textBox1.BackColor = Color.LightGreen;
                richTextBox1.BackColor = Color.LightGreen;
            }
            else 
            {
                BackColor = Color.White;
                textBox_name.BackColor = Color.White;
                textBox1.BackColor = Color.White;
                richTextBox1.BackColor = Color.White;
            }

        }

        const string HTML_TAG_PATTERN = "<.*?>";

        static string StripHTML(string inputString)
        {
            return Regex.Replace
              (inputString, HTML_TAG_PATTERN, string.Empty);
        }

        //new tweet
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
           NewTweet nt = new NewTweet();
           if (nt.ShowDialog() == DialogResult.OK)
           {
               TweetBar.service.SendTweet(nt.getText());
           }
        }

        //reply
        private void toolStripMenuItem_reply_Click(object sender, EventArgs e)
        {
            TweetReply tr = new TweetReply(_status);
            if(tr.ShowDialog() == DialogResult.OK)
            {
                TweetBar.service.SendTweet(tr.getText(),_status.Id);
            }
        }

        private void retweetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to retweet -\n" + _status.Text, "Retweet", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                TweetBar.service.Retweet(_status.Id);
            }
        }

        private void retweetWithCommentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to DELETE -\n" + _status.Text, "Retweet", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                TweetBar.service.DeleteTweet(_status.Id);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            if (s.ShowDialog() == DialogResult.OK)
            {
                TweetBar.me.applysettings();
            }

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to exit TweetTicker?", "Exit TweetTicker", MessageBoxButtons.YesNo) == DialogResult.Yes)
                TweetBar.closemainbar();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject("@"+textBox_name.Text+" "+richTextBox1.Text); 
        }

        private void followToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to follow "+clickholder, "Follow user", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                char[] trim = { '@' };
                clickholder = clickholder.TrimStart(trim);
                TweetBar.service.FollowUser(clickholder);
            }

        }

        private void viewTweetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            followlink(clickholder);
        }

        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            contextMenuStrip1.Items[0].Visible = false;
            contextMenuStrip1.Items[1].Visible = false;
            contextMenuStrip1.Items[2].Visible = false;
        }

        public void followlink(string link)
        {
            try
            {
                if (link.Substring(0, 1) == "@")
                {
                    char[] trim = { '@' };
                    link = link.TrimStart(trim);
                    Process.Start("http://twitter.com/#!/" + System.Web.HttpUtility.HtmlEncode(link));

                }
                else if (link.Substring(0, 1) == "#")
                {
                    char[] trim = { '#' };
                    link = link.TrimStart(trim);
                    Process.Start("http://search.twitter.com/search?q=%23" + System.Web.HttpUtility.HtmlEncode(link));
                }
                else if (link.Substring(0, 7) == "http://")
                {
                    Process.Start(link);
                }
            }
            catch
            {
                // Process.Start can exception in some cases, just trap it and ignore it if it does
            }

        }

    }

}

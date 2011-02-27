﻿using System;
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
            MouseClick += new MouseEventHandler(Tweetdisplay_MouseClick);
            pictureBox1.MouseClick += new MouseEventHandler(Tweetdisplay_MouseClick);
            textBox_name.MouseClick += new MouseEventHandler(Tweetdisplay_MouseClick);
            textBox1.MouseClick += new MouseEventHandler(Tweetdisplay_MouseClick);
        }

        void Tweetdisplay_MouseClick(object sender, MouseEventArgs e)
        {
            this.contextMenuStrip1.Show(Cursor.Position);
        }

        void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Clicks == 1 && e.Button == MouseButtons.Right)
            {
                Tweetdisplay_MouseClick(sender, e);
                return;
            }

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

                if (click.Length < 2)
                    return;

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

        public void setdata(TwitterStatus status)
        {
            _status = status;

            System.Drawing.Bitmap img = ImgMgr.getprofileimage(status.User);

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

            if (this._status.RetweetedStatus != null)
            {
                  this.textBox1.Text = status.CreatedDate.ToShortTimeString()  +" RT @"+_status.RetweetedStatus.User.ScreenName;
            }
            else if (_status.InReplyToScreenName != null)
            {
                this.textBox1.Text = status.CreatedDate.ToShortTimeString() + " in reply to " + _status.InReplyToScreenName;
            }
            else
            {
                this.textBox1.Text = status.CreatedDate.ToShortTimeString() + " via " + source;
            }

            if(img!=null)
                this.pictureBox1.Image = img;

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
                BackColor = Color.Green;
                textBox_name.BackColor = Color.Green;
                textBox1.BackColor = Color.Green;
                richTextBox1.BackColor = Color.Green;
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

    }

    // A delegate type for hooking up change notifications.
    public delegate void AtLinkedCLicked(object sender, AtLinkClickedEventArgs e);

    public class AtLinkClickedEventArgs : EventArgs
    {
        public string handle;
    }

}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TweetSharp;

namespace TwitScroll
{
    public partial class TweetReply : Form
    {
        public TweetReply(TwitterStatus status)
        {
            InitializeComponent();
            tweetdisplay1.setdata(status);
            writeTweet1.setText("@"+status.User.ScreenName+" ");
        }

        private void button_reply_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void buttoncancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        public string getText()
        {
            return writeTweet1.getText();
        }
    }
}

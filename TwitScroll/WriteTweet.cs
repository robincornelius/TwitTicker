using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwitScroll
{
    public partial class WriteTweet : UserControl
    {
        public WriteTweet()
        {
            InitializeComponent();
            this.tweet_textbox.TextChanged += new EventHandler(tweet_textbox_TextChanged);
        }

        void tweet_textbox_TextChanged(object sender, EventArgs e)
        {
            int length = 140 - tweet_textbox.TextLength;
            this.lable_remaining.Text = "Characters remaining " + length.ToString();
        }

        public string getText()
        {
            return tweet_textbox.Text;
        }

        public void setText(string text)
        {
            tweet_textbox.Text = text;
        }


    }
}

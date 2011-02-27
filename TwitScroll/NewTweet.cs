using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwitTicker
{
    public partial class NewTweet : Form
    {
        public NewTweet()
        {
            Point screenPoint = Cursor.Position;
            Rectangle sb = Screen.PrimaryScreen.Bounds;

            if (screenPoint.X + Width > sb.Right)
            {
                screenPoint.X = sb.Right - Width;
            }

            if (screenPoint.Y + Height > sb.Bottom)
            {
                screenPoint.Y = sb.Bottom  - Height;
            }

            InitializeComponent();

            Location = screenPoint;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void button_tweet_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        public string getText()
        {
            return writeTweet1.getText();
        }
    }
}

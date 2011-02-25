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
    public partial class Tweetdisplay : UserControl
    {
        public Tweetdisplay()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.ContainerControl |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.SupportsTransparentBackColor
                          , true);


        }

        public void setdata(string text, string name,string time,System.Drawing.Bitmap img)
        {
            this.textBox_tweet.Text = text;
            this.textBox_name.Text = name;
            this.textBox1.Text = time;
            this.pictureBox1.Image = img;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace TwitScroll
{
    public partial class Tweetdisplay : UserControl
    {
        public Tweetdisplay()
        {
            InitializeComponent();
            this.richTextBox1.LinkClicked += new LinkClickedEventHandler(richTextBox1_LinkClicked);
        }

        void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        public void setdata(string text, string name,string time,System.Drawing.Bitmap img)
        {
            this.richTextBox1.Clear();
            this.richTextBox1.Text = text;

            int index=0;
            while (index != -1)
            {
                index = richTextBox1.Text.IndexOf('@', index);
                if (index == -1)
                      break;

                int index2 = richTextBox1.Text.IndexOf(' ', index);
  
                if ( index2 == -1)
                    break;

                richTextBox1.SelectionStart = index;
                richTextBox1.SelectionLength = index2-index;
                richTextBox1.SelectionColor = Color.Blue;
                index++;
            }

            
            this.textBox_name.Text = name;
            this.textBox1.Text = time;
            this.pictureBox1.Image = img;
        }
    }
}

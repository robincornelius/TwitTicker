using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwitScroll
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            textBox_twitterupdate.Text = Properties.Settings.Default.twitterupdateinterval.ToString();
            textBox_scrollrefresh.Text = Properties.Settings.Default.scrollupdateinterval.ToString();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            try
            {
                int time;
                int.TryParse(textBox_scrollrefresh.Text, out time);

                if (time < 1)
                {
                    MessageBox.Show("Scroll interval must be at least 1s\n and cannot be negative");
                }
                else
                {
                    Properties.Settings.Default.scrollupdateinterval = time;
                }

                int.TryParse(textBox_twitterupdate.Text, out time);
                if (time < 60)
                {
                    MessageBox.Show("Twitter update interval minimum is 60s");
                }
                else
                {
                    Properties.Settings.Default.twitterupdateinterval = time;
                }
                Properties.Settings.Default.Save();
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry i do not understand what you have entered \n"+ex.Message);
            }

        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

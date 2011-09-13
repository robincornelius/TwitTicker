using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using ShellLib;

namespace TwitTicker
{
    public enum displaytype
    {
        banner_latest = 0,
        banner = 1,
        scroll = 2
    }

    public partial class Settings : Form
    {

        public Settings()
        {
            InitializeComponent();

            textBox_twitterupdate.Text = Properties.Settings.Default.twitterupdateinterval.ToString();
            textBox_bannerinterval.Text = Properties.Settings.Default.bannerinterval.ToString();

            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (rkApp.GetValue("TwitTicker") == null)
            {
                this.checkBox_autostart.CheckState = CheckState.Unchecked;
            }
            else
            {
                 this.checkBox_autostart.CheckState = CheckState.Checked;
            }


            if (Properties.Settings.Default.barposition == 1)
            {
                comboBox_barposition.SelectedItem = "Top";
            }
            else
            {
                comboBox_barposition.SelectedItem = "Bottom";
            }

            comboBox1.SelectedIndex = (int)Properties.Settings.Default.Displaytype;

            textBox_tickerrate.Text = Properties.Settings.Default.scrollrate.ToString();
            

        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            try
            {
                int time;
                int.TryParse(textBox_bannerinterval.Text, out time);

                if (time < 1)
                {
                    MessageBox.Show("Scroll interval must be at least 1s\n and cannot be negative");
                    return;
                }
                else
                {
                    Properties.Settings.Default.bannerinterval = time;
                }

                int.TryParse(textBox_tickerrate.Text, out time);
                Properties.Settings.Default.scrollrate = time;

                int.TryParse(textBox_twitterupdate.Text, out time);
                if (time < 60)
                {
                    MessageBox.Show("Twitter update interval minimum is 60s");
                    return;
                }
                else
                {
                    Properties.Settings.Default.twitterupdateinterval = time;
                }
               
                RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (checkBox_autostart.CheckState == CheckState.Checked)
                {
                    rkApp.SetValue("TwitTicker", Application.ExecutablePath.ToString());
                }
                else
                {
                    rkApp.DeleteValue("TwitTicker", false);
                }

                if (string.Compare(comboBox_barposition.SelectedItem.ToString(),"Top") == 0)
                {
                    Properties.Settings.Default.barposition = (int)ShellLib.ApplicationDesktopToolbar.AppBarEdges.Top;
                }
                else
                {
                    Properties.Settings.Default.barposition = (int)ShellLib.ApplicationDesktopToolbar.AppBarEdges.Bottom;
                }

                Properties.Settings.Default.Displaytype = (int)comboBox1.SelectedIndex;

                Properties.Settings.Default.Save();

                DialogResult = DialogResult.OK;

                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry i do not understand what you have entered \n"+ex.Message);
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void checkBox_autostart_CheckedChanged(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.oauth.Default.appkey = "";
            Properties.oauth.Default.appsecret = "";
            Properties.oauth.Default.Save();
        }
    }
}

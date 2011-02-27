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

namespace TwitScroll
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            textBox_twitterupdate.Text = Properties.Settings.Default.twitterupdateinterval.ToString();
            textBox_scrollrefresh.Text = Properties.Settings.Default.scrollupdateinterval.ToString();

            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (rkApp.GetValue("TwitScroll") == null)
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

            checkBox_timedscroll.Checked = Properties.Settings.Default.autoscroll;

            if (checkBox_timedscroll.Checked == true)
            {
                textBox_scrollrefresh.Enabled = true;
            }
            else
            {
                textBox_scrollrefresh.Enabled = false;
            }

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
                    return;
                }
                else
                {
                    Properties.Settings.Default.scrollupdateinterval = time;
                }

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
                    rkApp.SetValue("TwitScroll", Application.ExecutablePath.ToString());
                }
                else
                {
                    rkApp.DeleteValue("TwitScroll", false);
                }

                if (string.Compare(comboBox_barposition.SelectedItem.ToString(),"Top") == 0)
                {
                    Properties.Settings.Default.barposition = (int)ShellLib.ApplicationDesktopToolbar.AppBarEdges.Top;
                }
                else
                {
                    Properties.Settings.Default.barposition = (int)ShellLib.ApplicationDesktopToolbar.AppBarEdges.Bottom;
                }

                Properties.Settings.Default.autoscroll = checkBox_timedscroll.Checked; 

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

        private void checkBox_autostart_CheckedChanged(object sender, EventArgs e)
        {
           

        }

        private void checkBox_timedscroll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_timedscroll.Checked == true)
            {
                textBox_scrollrefresh.Enabled = true;
            }
            else
            {
                textBox_scrollrefresh.Enabled = false;
            }
        }
    }
}

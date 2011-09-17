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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            label_version.Text = "Version: "+TweetBar.version;
        }

        public static void setprogressmsg(string msg)
        {
            if (Properties.Settings.Default.showsplash == true && Program.sp != null)
            {
                Program.sp._setprogressmsg(msg);
                
                // Pump a bit to update the screen
                for(int x=0;x<5;x++)
                    Application.DoEvents();

            }
        }

        public void _setprogressmsg(string msg)
        {
            label_progress.Text = msg;
        }
    }
}

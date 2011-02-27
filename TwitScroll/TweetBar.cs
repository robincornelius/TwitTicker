using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TweetSharp;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Net;
using System.Drawing.Imaging;


namespace TwitTicker
{
     public partial class TweetBar : ShellLib.ApplicationDesktopToolbar
     //public partial class Form1 : Form
    {
        Splash sp;
        public TweetBar()
        {
            InitializeComponent();
            tweetqueue = new List<TwitterStatus>();
          
            elements = new List<Tweetdisplay>();
        }

        public static TwitterService service;
        public static TwitterUser autheduser;

        List<TwitterStatus> tweetqueue;
      
        List<Tweetdisplay> elements;

        int offset = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            sp = new Splash();
            sp.Shown += new EventHandler(sp_Shown);
            sp.Show();
            
        }

        void sp_Shown(object sender, EventArgs e)
        {
            string consumerKey = Properties.Settings.Default.consumerkey;
            string consumerSecret = Properties.Settings.Default.consumersecret;
            string appKey =  Properties.Settings.Default.appkey;
            string appSecret =  Properties.Settings.Default.consumersecret;
            autheduser = new TwitterUser();

            try
            {
                service = new TwitterService(consumerKey, consumerSecret);

                if (Properties.Settings.Default.appkey == "")
                {
                    OAuthRequestToken requestToken = service.GetRequestToken();

                    Uri uri = service.GetAuthorizationUri(requestToken);
                    Process.Start(uri.ToString());

                    AuthBrowser ab = new AuthBrowser();
                    ab.ShowDialog();

                    OAuthAccessToken access = service.GetAccessToken(requestToken, ab.idcode.ToString());

                    Properties.Settings.Default.appkey = access.Token;
                    Properties.Settings.Default.appsecret = access.TokenSecret;
                    Properties.Settings.Default.Save();

                    service.AuthenticateWith(access.Token, access.TokenSecret);

                    // Step 4 - User authenticates using the Access Token
                }
                else
                {
                    service.AuthenticateWith(Properties.Settings.Default.appkey, Properties.Settings.Default.appsecret);
                }

                autheduser = service.VerifyCredentials();
            }
            catch
            {
                autheduser.ScreenName = null;
            }

            if (autheduser.ScreenName == null)
            {
                MessageBox.Show("Failed to authenticate with Twitter, sorry");
            }
            else
            {
                update();
                applysettings();  
            }

            sp.Hide();
            sp.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tick(object sender, EventArgs e)
        {

            updateelements();
         
            offset = offset + 1;

            if (offset > 15)
                offset = 0;

        }

        private void updateelements()
        {

            int x = 0;
           
            foreach (Tweetdisplay tdf in elements)
            {
                if(offset+x >= tweetqueue.Count)
                    break;

                updateelement(tdf, tweetqueue[offset + x]);
                x++;
            }
        }

        void update()
        {
            IEnumerable<TwitterStatus> tweets = service.ListTweetsOnHomeTimeline();

            tweetqueue.Clear();

            foreach (var tweet in tweets)
            {
                if (tweet.User == null)
                    continue; // can happen if we get a bad read 
                tweetqueue.Add(tweet);
                ImgMgr.fetchprofileimage(tweet.User);
                
            }

            offset = 0;
          
            updateelements();
         
            offset = offset + 1;
        }

        void updateelement(Tweetdisplay entry,TwitterStatus status)
        {
            entry.setdata(status);
        }

        private void reloadtweets(object sender, EventArgs e)
        {
            update();
        }


        private void toolStripMenuItem_quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.ShowDialog();

            applysettings();
        }

        private void applysettings()
        {
            Visible = false;
            offset = 0;

            Application.DoEvents();
            System.Threading.Thread.Sleep(100);

            Scrolltimer.Interval = 1000 * Properties.Settings.Default.scrollupdateinterval;
            Synctimer.Interval = 1000 * Properties.Settings.Default.twitterupdateinterval;
           
            Synctimer.Enabled = true;


            if (Properties.Settings.Default.autoscroll == true)
            {
                Scrolltimer.Enabled = true;
            }
            else
            {
                Scrolltimer.Enabled = false;
            }

            Edge = (AppBarEdges)Properties.Settings.Default.barposition;
            Visible = true;
            //Location = new System.Drawing.Point(0,0);

            Tweetdisplay td = new Tweetdisplay();

            float amount = Width / td.Width;
            int nodisplays = (int)Math.Ceiling(amount);

            int xoff=0;
            for (int x = 0; x < nodisplays; x++)
            {
                td = new Tweetdisplay();
                Controls.Add(td);
                td.Visible = true;
                Point p = new Point(xoff, 0);
                xoff+= td.Width;
                td.Location = p;
                elements.Add(td);
            }

            Invalidate(true);

            updateelements();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.Show();
        }

        private void newtweetcontextmenu_Click(object sender, EventArgs e)
        {
            NewTweet nt = new NewTweet();
          
            if (nt.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                service.SendTweet(nt.getText());
            }
        }
    }
}

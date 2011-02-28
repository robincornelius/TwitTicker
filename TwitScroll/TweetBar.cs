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
using ShellLib;


namespace TwitTicker
{
     public partial class TweetBar : ApplicationDesktopToolbar
    //public partial class TweetBar : Form
    {
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

        bool auth = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Location = new Point(0, -100);
            startauthtimer.Tick += new EventHandler(startauthtimer_Tick);
            startauthtimer.Enabled = true;
        }

        void startauthtimer_Tick(object sender, EventArgs e)
        {
            startauthtimer.Enabled = false;
            attemptauth();
            Program.sp.Close();
        }

        private void attemptauth()
        {
            string consumerKey = Properties.Settings.Default.consumerkey;
            string consumerSecret = Properties.Settings.Default.consumersecret;
            string appKey = Properties.Settings.Default.appkey;
            string appSecret = Properties.Settings.Default.consumersecret;
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

                    service.AuthenticateWith(access.Token, access.TokenSecret);

                    autheduser = service.VerifyCredentials();

                    if (autheduser.ScreenName != null)
                    {
                        Properties.Settings.Default.appkey = access.Token;
                        Properties.Settings.Default.appsecret = access.TokenSecret;
                        Properties.Settings.Default.Save();
                    }

                    // Step 4 - User authenticates using the Access Token
                }
                else
                {
                    service.AuthenticateWith(Properties.Settings.Default.appkey, Properties.Settings.Default.appsecret);
                    autheduser = service.VerifyCredentials();
                }
            }
            catch
            {
                autheduser.ScreenName = null;
            }

            if (service.Response == null)
            {
                notifyIcon1.ShowBalloonTip(5000, "TweetTicker", "Error connecting to Twitter\nIs the consumer key set in settings?" , ToolTipIcon.Error);    
            }
            else
            {
                if (service.Response.StatusCode != HttpStatusCode.OK)
                {
                    TwitterError error = service.Deserialize<TwitterError>(service.Response.Response);
                    notifyIcon1.ShowBalloonTip(5000, "TweetTicker", "Error connecting to Twitter\n" + error.ErrorMessage, ToolTipIcon.Error);
                }
                else
                {
                    auth = true;
                    update();
                    applysettings();
                }
            }

            Synctimer.Interval = 1000 * Properties.Settings.Default.twitterupdateinterval;
            Synctimer.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tick(object sender, EventArgs e)
        {

            if(Properties.Settings.Default.Displaytype == (int)displaytype.scroll)
            {
                scroll();
                return;
            }
           
            updateelements();
            offset = offset + 1;

            if (offset > 15)
                offset = 0;
        }

        private void scroll()
        {
            foreach (Tweetdisplay tdf in elements)
            {
                Point p = tdf.Location;
                tdf.Location = new Point(p.X - 1, p.Y);

                if (tdf.Location.X < -tdf.Width)
                {
                   int highest = 0;
                   foreach (Tweetdisplay tdf2 in elements)
                   {
                       if (tdf2.Location.X > highest)
                           highest = tdf2.Location.X;
                   }
                   tdf.Location = new Point(highest + tdf.Width, p.Y);
                   tdf.setdata(tweetqueue[offset]);
                   offset++;
                   if (offset >= tweetqueue.Count)
                       offset = 0;
                }
            }
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

            // Strategy 1 - Look for bad requests by inspecting the response for important info
            if (service.Response.StatusCode == HttpStatusCode.OK) // <-- Should be 401 - Unauthorized
            {
                // Strategy 2 - If you get back an 200 - OK response, you might have received an error, not the objects you wanted
                if (tweets.Count() == 1) // <-- If you were trying to get a collection, any errors are added to it, so look for only one result
                {

                    TwitterStatus tweet = tweets.First();
                    if (tweet.Id == 0)
                    {
                        // This was not a successful deserialization...
                        notifyIcon1.ShowBalloonTip(5000, "TweetTicker", "Twitter API error\nDeseralisation failed", ToolTipIcon.Error);
                        return;
                    }

                    TwitterError error = service.Deserialize<TwitterError>(tweets.First());
                    if (!string.IsNullOrEmpty(error.ErrorMessage))
                    {
                        // You now know you have a real error from Twitter, and can handle it
                        notifyIcon1.ShowBalloonTip(5000, "TweetTicker", "Twitter API error\n" + error.ErrorMessage, ToolTipIcon.Error);
                        return;
                    }
                }

                // Its ok fall through
            }
            else
            {
                TwitterError error = service.Deserialize<TwitterError>(service.Response.Response);
                notifyIcon1.ShowBalloonTip(5000, "TweetTicker", "Twitter API error\n" + error.ErrorMessage, ToolTipIcon.Error);
                return;
            }


            tweetqueue.Clear();

            System.Threading.Thread.Sleep(5000);

            if (tweets == null)
            {
                notifyIcon1.ShowBalloonTip(5000, "TwitTicker error", "Error connecting to twitter service", ToolTipIcon.Error);
                System.Threading.Thread.Sleep(7000);
                return;
            }

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
            if (auth == true)
            {
                update();
            }
            else
            {
                attemptauth();
            }
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

            if (Properties.Settings.Default.Displaytype == (int)displaytype.banner)
            {
                Scrolltimer.Interval = 1000* Properties.Settings.Default.bannerinterval;
            }
            if (Properties.Settings.Default.Displaytype == (int)displaytype.scroll)
            {
                Scrolltimer.Interval = Properties.Settings.Default.scrollrate;
            }
        
            if (Properties.Settings.Default.Displaytype > (int)displaytype.banner_latest)
            {
                Scrolltimer.Enabled = true;
            }

            
            Edge = (AppBarEdges)Properties.Settings.Default.barposition;
            
            Visible = true;

            Tweetdisplay td = new Tweetdisplay();

            float amount = (float)Width / (float)td.Width;
            int nodisplays = (int)Math.Ceiling(amount)+1;
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

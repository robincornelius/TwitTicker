﻿using System;
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
    {
        public TweetBar()
        {
            InitializeComponent();
            tweetqueue = new List<TwitterStatus>();
            elements = new List<Tweetdisplay>();
            me = this;
        }

        public static string version = "v1.1.5";

        public static TwitterService service;
        public static TwitterUser autheduser;
        List<TwitterStatus> tweetqueue;
        List<Tweetdisplay> elements;
        public static TweetBar me; //sigh

        int offset = 0;

        bool authorised = false;

        DateTime mostrecenttweet = new DateTime();

        public static void closemainbar()
        {
            me.Edge = AppBarEdges.Float;
            me.Close();
        }

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
            if (Properties.Settings.Default.showsplash == true && Program.sp != null)
            {
                Program.sp.Close();
            }
        }

        private void attemptauth()
        {
            string consumerKey = Properties.oauth.Default.consumerkey;
            string consumerSecret = Properties.oauth.Default.consumersecret;
            string appKey = Properties.oauth.Default.appkey;
            string appSecret = Properties.oauth.Default.consumersecret;
            autheduser = new TwitterUser();

            try
            {

                Splash.setprogressmsg("Starting twitter service");
                service = new TwitterService(consumerKey, consumerSecret);

                if (Properties.oauth.Default.appkey == "")
                {
                    Splash.setprogressmsg("No auth key, starting OAUTH");
                    OAuthRequestToken requestToken = service.GetRequestToken();
                    Splash.setprogressmsg("Got token, getting AuthorizationUri");

                    Uri uri = service.GetAuthorizationUri(requestToken);

                    Splash.setprogressmsg("Requesting permissions from twitter");

                    Process.Start(uri.ToString());

                    AuthBrowser ab = new AuthBrowser();
                    ab.ShowDialog();

                    Splash.setprogressmsg("Getting access token");

                    OAuthAccessToken access = service.GetAccessToken(requestToken, ab.idcode.ToString());

                    Splash.setprogressmsg("Auth with access token");

                    service.AuthenticateWith(access.Token, access.TokenSecret);

                    Splash.setprogressmsg("Verify Credentials");

                    autheduser = service.VerifyCredentials();

                    if (autheduser.ScreenName != null)
                    {
                        Properties.oauth.Default.appkey = access.Token;
                        Properties.oauth.Default.appsecret = access.TokenSecret;
                        Properties.oauth.Default.Save();

                        Splash.setprogressmsg("Authorised!");
                    }

                    // Step 4 - User authenticates using the Access Token
                }
                else
                {
                    Splash.setprogressmsg("Authenticating with saved access token");
                    service.AuthenticateWith(Properties.oauth.Default.appkey, Properties.oauth.Default.appsecret);
                    Splash.setprogressmsg("Verifying credentials");
                    autheduser = service.VerifyCredentials();
                }
            }
            catch
            {
                Splash.setprogressmsg("Connection failed");
                autheduser.ScreenName = null;
            }

            if (service.Response == null)
            {
                notifyIcon1.ShowBalloonTip(5000, "TwitTicker", "Error connecting to Twitter\nIs the consumer key set in settings?" , ToolTipIcon.Error);    
            }
            else
            {
                if (service.Response.StatusCode != HttpStatusCode.OK)
                {
                    try
                    {
                        TwitterError error = service.Deserialize<TwitterError>(service.Response.Response);
                        notifyIcon1.ShowBalloonTip(5000, "TwitTicker", "Error connecting to Twitter\n" + error.ErrorMessage, ToolTipIcon.Error);

                    }
                    catch
                    {
                        notifyIcon1.ShowBalloonTip(5000, "TwitTicker", "Error connecting to Twitter", ToolTipIcon.Error);
                    }
                }
                else
                {
                    Splash.setprogressmsg("Getting latest tweets");
                    authorised = true;
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

            if (Cursor.Position.Y > this.Location.Y && Cursor.Position.Y < (this.Location.Y+this.Height))
            {
                return;
            }
           
            if(Properties.Settings.Default.Displaytype == (int)displaytype.scrollRL)
            {
                scroll(1);
                return;
            }

            if (Properties.Settings.Default.Displaytype == (int)displaytype.scrollLR)
            {
                scroll(-1);
                return;
            }

            if (Properties.Settings.Default.Displaytype == (int)displaytype.banner)
                scroll(-elements[0].Width);
            
        }

        private void scroll(int amount)
        {
            // increment each element by amount;
            // if it drops off the side of the screen add it to the recycle list
            // then take each element in recycle list and append/prepend it to the main set to restart
            lock (tweetqueue)
            {
                List<Tweetdisplay> recyclelist = new List<Tweetdisplay>();

                foreach (Tweetdisplay tdf in elements)
                {
                    
                    Point p = tdf.Location;
                    tdf.Location = new Point(p.X - amount, p.Y);

                    if (amount > 0)
                    {
                        if (tdf.Location.X <= -tdf.Width)
                        {
                            recyclelist.Add(tdf);
                        }
                    }
                    else
                    {
                        if (tdf.Location.X >= Width)
                        {
                            recyclelist.Add(tdf);
                        }
                    }
                }

                foreach (Tweetdisplay tdf in recyclelist)
                {
                    Point p = tdf.Location;
 
                    if (amount > 0)
                    {
                        int highest = tdf.Location.X;
                        foreach (Tweetdisplay tdf2 in elements)
                        {
                            if (tdf2 == tdf)
                                continue;

                            if (tdf2.Location.X > highest)
                                highest = tdf2.Location.X;
                        }
                        tdf.Location = new Point(highest + tdf.Width, p.Y);

                        if (offset < tweetqueue.Count)
                            tdf.setdata(tweetqueue[offset]);
                        
                        offset++;
                        if (offset >= tweetqueue.Count)
                            offset = 0;
                    }
                    else
                    {
                        int lowest = tdf.Location.X;
                        foreach (Tweetdisplay tdf2 in elements)
                        {
                            if (tdf2 == tdf)
                                continue;

                            if (tdf2.Location.X <= lowest)
                                lowest = tdf2.Location.X;
                        }
                        tdf.Location = new Point(lowest - tdf.Width, p.Y);

                        if (offset >= 0)
                            tdf.setdata(tweetqueue[offset]);

                        offset--;
                        if (offset < 0)
                            offset = tweetqueue.Count - 1;
                    }

                }              
            }
        }

        private void defaultelements(int offset)
        {

            int x = 0;
            int xoff = 0;
 
            lock (tweetqueue)
            {
                 this.Invoke(new MethodInvoker(delegate
                    {

                foreach (Tweetdisplay tdf in elements)
                {
                    if (offset + x >= tweetqueue.Count)
                        break;

                    tdf.Location = new Point(xoff, tdf.Location.Y);
                    xoff += tdf.Width;

                    updateelement(tdf, tweetqueue[offset + x]);
                    x++;        
                    }
                }));
            }
        }

        void update()
        {
            try
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

                        // I don't believe a word of it, can get a single ok tweet but ignore this as we should still have 20 
                        return;
                    }

                    // Its ok fall through
                }
                else
                {
                    TwitterError error = service.Deserialize<TwitterError>(service.Response.Response);
                    notifyIcon1.ShowBalloonTip(5000, "TweetTicker", "Twitter API error\n" + error.ErrorMessage, ToolTipIcon.Error);
                    return;
                }

                lock (tweetqueue)
                {
                    tweetqueue.Clear();

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

                        if (tweet.RetweetedStatus != null)
                        {
                            ImgMgr.fetchprofileimage(tweet.RetweetedStatus.User);
                        }

                        ImgMgr.fetchprofileimage(tweet.User);
                    }

                    int count = 0;
                   
                    foreach (TwitterStatus ts in tweetqueue)
                    {
                        if (ts.CreatedDate > mostrecenttweet)
                            count++;
                    }

                    if(tweetqueue.Count>0)
                        mostrecenttweet = tweetqueue[0].CreatedDate;

                    if (Properties.Settings.Default.Displaytype == (int)displaytype.banner_latest)
                    {
                        defaultelements(0);
                    }   
                }
            }
            catch
            {

            }

        }

        void updateelement(Tweetdisplay entry,TwitterStatus status)
        {
            entry.setdata(status);
        }

        private void reloadtweets(object sender, EventArgs e)
        {
            if (authorised == true)
            {
                ThreadStart threadDelegate = new ThreadStart(update);
                Thread newThread = new Thread(threadDelegate);
                newThread.Start();

            }
            else
            {
                attemptauth();
            }
        }


        private void toolStripMenuItem_quit_Click(object sender, EventArgs e)
        {
            TweetBar.closemainbar();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            if (s.ShowDialog() == DialogResult.OK)
            {
                applysettings();
            }
        }

        public void applysettings()
        {
            Visible = false;
            offset = 0;

            if (authorised == false)
                return;

            //Meh
            Edge = (AppBarEdges)Properties.Settings.Default.barposition;

            Application.DoEvents();
            System.Threading.Thread.Sleep(100);
           
            switch (Properties.Settings.Default.Displaytype)
            {
                case ((int)displaytype.banner):
                case ((int)displaytype.banner_latest):
                    Scrolltimer.Interval = 1000 * Properties.Settings.Default.bannerinterval;
                    break;
                
                case ((int)displaytype.scrollLR):
                case ((int)displaytype.scrollRL):
                    Scrolltimer.Interval = Properties.Settings.Default.scrollrate;
                    break;
            }

            Scrolltimer.Enabled = true;

            Edge = (AppBarEdges)Properties.Settings.Default.barposition;

            Visible = true;

            Tweetdisplay td = new Tweetdisplay();

            float amount = (float)Width / (float)td.Width;
            int nodisplays = (int)Math.Ceiling(amount);

            elements.Clear();
            panel1.Controls.Clear();

            for (int x = 0; x < nodisplays; x++)
            {
                td = new Tweetdisplay();
                panel1.Controls.Add(td);
                td.Visible = true;
                elements.Add(td);
            }
             
            Invalidate(true);

            defaultelements(0);

            Edge = (AppBarEdges)Properties.Settings.Default.barposition;
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


        public void pausetimer()
        {
            Scrolltimer.Enabled = false;
        }

        public void starttimer()
        {
            if (Properties.Settings.Default.Displaytype > (int)displaytype.banner_latest)
            {
                Scrolltimer.Enabled = true;
            }
        }

        private void button_left_Click(object sender, EventArgs e)
        {
            if (offset < tweetqueue.Count - (elements.Count-1))
                offset++;

            defaultelements(offset);
        }

        private void button_right_Click(object sender, EventArgs e)
        {
            if (offset > 0)
                offset--;

            defaultelements(offset);
        }

    }
}

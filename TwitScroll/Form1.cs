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


namespace TwitScroll
{
     public partial class Form1 : ShellLib.ApplicationDesktopToolbar
     //public partial class Form1 : Form
    {
 
        public Form1()
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


            tweetqueue = new List<TwitterStatus>();
            userpics = new Dictionary<string, Bitmap>();
        }

        TwitterService service;
        List<TwitterStatus> tweetqueue;
        Dictionary<string, System.Drawing.Bitmap> userpics;

        int offset = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            string consumerKey = Properties.Settings.Default.consumerkey;
            string consumerSecret = Properties.Settings.Default.consumersecret;
            string appKey =  Properties.Settings.Default.appkey;
            string appSecret =  Properties.Settings.Default.consumersecret;

            service = new TwitterService(consumerKey, consumerSecret);

            if (Properties.Settings.Default.accesstoken == 0)
            {
                OAuthRequestToken requestToken = service.GetRequestToken();

                Uri uri = service.GetAuthorizationUri(requestToken);
                Process.Start(uri.ToString());

                AuthBrowser ab = new AuthBrowser();
                ab.ShowDialog();

                OAuthAccessToken access = service.GetAccessToken(requestToken, ab.idcode.ToString());

                Properties.Settings.Default.appkey = access.Token;                
                Properties.Settings.Default.appsecret = access.TokenSecret;
                Properties.Settings.Default.accesstoken = ab.idcode;
                Properties.Settings.Default.Save();

                service.AuthenticateWith(access.Token, access.TokenSecret);

                // Step 4 - User authenticates using the Access Token
            }
            else
            {
                service.AuthenticateWith(Properties.Settings.Default.appkey, Properties.Settings.Default.appsecret);
            }

            update();

            this.Edge = AppBarEdges.Top;
            this.Visible = true;

            this.timer1.Enabled = true;
            this.timer2.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tick(object sender, EventArgs e)
        {

            tweetdisplay1.setdata(tweetqueue[offset + 0].Text, tweetqueue[offset + 0].User.ScreenName, tweetqueue[offset + 0].CreatedDate.ToShortTimeString() + " via " + tweetqueue[offset + 0].Source, userpics[tweetqueue[0].User.ScreenName]);
            tweetdisplay2.setdata(tweetqueue[offset + 1].Text, tweetqueue[offset + 1].User.ScreenName, tweetqueue[offset + 1].CreatedDate.ToShortTimeString() + " via " + tweetqueue[offset + 1].Source, userpics[tweetqueue[1].User.ScreenName]);
            tweetdisplay3.setdata(tweetqueue[offset + 2].Text, tweetqueue[offset + 2].User.ScreenName, tweetqueue[offset + 2].CreatedDate.ToShortTimeString() + " via " + tweetqueue[offset + 2].Source, userpics[tweetqueue[2].User.ScreenName]);
            tweetdisplay4.setdata(tweetqueue[offset + 3].Text, tweetqueue[offset + 3].User.ScreenName, tweetqueue[offset + 3].CreatedDate.ToShortTimeString() + " via " + tweetqueue[offset + 3].Source, userpics[tweetqueue[3].User.ScreenName]);
            offset = offset + 1;

            if (offset > 15)
                offset = 0;

        }

        void update()
        {
            IEnumerable<TwitterStatus> tweets = service.ListTweetsOnHomeTimeline();

            tweetqueue.Clear();

            foreach (var tweet in tweets)
            {
                tweetqueue.Add(tweet);
                getprofileimage(tweet.User);
            }
            offset = 0;

            tweetdisplay1.setdata(tweetqueue[offset + 0].Text, tweetqueue[offset + 0].User.ScreenName, tweetqueue[offset + 0].CreatedDate.ToShortTimeString()+ " via "+tweetqueue[offset + 0].Source, userpics[tweetqueue[0].User.ScreenName]);
            tweetdisplay2.setdata(tweetqueue[offset + 1].Text, tweetqueue[offset + 1].User.ScreenName, tweetqueue[offset + 1].CreatedDate.ToShortTimeString() + " via " + tweetqueue[offset + 1].Source, userpics[tweetqueue[1].User.ScreenName]);
            tweetdisplay3.setdata(tweetqueue[offset + 2].Text, tweetqueue[offset + 2].User.ScreenName, tweetqueue[offset + 2].CreatedDate.ToShortTimeString() + " via " + tweetqueue[offset + 2].Source, userpics[tweetqueue[2].User.ScreenName]);
            tweetdisplay4.setdata(tweetqueue[offset + 3].Text, tweetqueue[offset + 3].User.ScreenName, tweetqueue[offset + 3].CreatedDate.ToShortTimeString() + " via " + tweetqueue[offset + 3].Source, userpics[tweetqueue[3].User.ScreenName]);
            offset = offset + 1;
            }

        private void reloadtweets(object sender, EventArgs e)
        {
            update();

        }

        private void getprofileimage(TwitterUser user)
        {
            if(userpics.ContainsKey(user.ScreenName))
                return;

            HttpWebRequest request = (HttpWebRequest)
            WebRequest.Create(user.ProfileImageUrl);

            // execute the request
            HttpWebResponse response = (HttpWebResponse)
            request.GetResponse();

            // we will read data via the response stream
            Stream resStream = response.GetResponseStream();

            System.Drawing.Bitmap img = new System.Drawing.Bitmap(resStream, false);
            Bitmap finalImg = new Bitmap(img, 32, 32);

            userpics.Add(user.ScreenName, finalImg);

        }
    }
}

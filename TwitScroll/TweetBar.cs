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
using System.Text.RegularExpressions;

namespace TwitScroll
{
     public partial class TweetBar : ShellLib.ApplicationDesktopToolbar
     //public partial class Form1 : Form
    {
 
        public TweetBar()
        {
            InitializeComponent();
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
            TwitterUser autheduser = new TwitterUser();

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
                this.Edge = AppBarEdges.Top;
                this.Visible = true;
                applysettings();
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tick(object sender, EventArgs e)
        {

            updateelement(tweetdisplay1, tweetqueue[offset + 0]);
            updateelement(tweetdisplay2, tweetqueue[offset + 1]);
            updateelement(tweetdisplay3, tweetqueue[offset + 2]);
            updateelement(tweetdisplay4, tweetqueue[offset + 3]);
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
            updateelement( tweetdisplay1,tweetqueue[offset+0]);
            updateelement( tweetdisplay2,tweetqueue[offset+1]);
            updateelement( tweetdisplay3,tweetqueue[offset+2]);
            updateelement( tweetdisplay4,tweetqueue[offset+3]);
            offset = offset + 1;
        }

        void updateelement(Tweetdisplay entry,TwitterStatus status)
        {
            string source;
            source = StripHTML(status.Source);
            entry.setdata(status.Text, status.User.ScreenName, status.CreatedDate.ToShortTimeString()+" via "+source, userpics[status.User.ScreenName]);
        }

        const string HTML_TAG_PATTERN = "<.*?>";

        static string StripHTML(string inputString)
        {
            return Regex.Replace
              (inputString, HTML_TAG_PATTERN, string.Empty);
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

        private void toolStripMenuItem_quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.Show();

            applysettings();
        }

        private void applysettings()
        {
            Scrolltimer.Interval = 1000 * Properties.Settings.Default.scrollupdateinterval;
            Synctimer.Interval = 1000 * Properties.Settings.Default.twitterupdateinterval;
            Scrolltimer.Enabled = true;
            Synctimer.Enabled = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.Show();
        }
    }
}

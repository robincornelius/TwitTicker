using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TweetSharp;
using System.IO;
using System.Net;

namespace TwitScroll
{
    static public class ImgMgr
    {

       static Dictionary<string, System.Drawing.Bitmap> userpics;

        static ImgMgr()
        {
            userpics = new Dictionary<string, Bitmap>();
        }

        public static void fetchprofileimage(TwitterUser user)
        {
            if (userpics.ContainsKey(user.ScreenName))
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

        public static Bitmap getprofileimage(TwitterUser user)
        {

            if (userpics.ContainsKey(user.ScreenName))
            {
                return (userpics[user.ScreenName]);
            }

            return null;
        }
    }
}

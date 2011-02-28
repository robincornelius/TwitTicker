using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TwitTicker
{
    static class Program
    {
        public static Splash sp;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            sp = new Splash();
            sp.Show();
            Application.Run(new TweetBar());
        }
    }
}

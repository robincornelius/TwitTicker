namespace TwitTicker
{
    partial class NewTweet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewTweet));
            this.button_tweet = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.writeTweet1 = new TwitTicker.WriteTweet();
            this.SuspendLayout();
            // 
            // button_tweet
            // 
            this.button_tweet.Location = new System.Drawing.Point(177, 97);
            this.button_tweet.Name = "button_tweet";
            this.button_tweet.Size = new System.Drawing.Size(148, 35);
            this.button_tweet.TabIndex = 1;
            this.button_tweet.Text = "Tweet";
            this.button_tweet.UseVisualStyleBackColor = true;
            this.button_tweet.Click += new System.EventHandler(this.button_tweet_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(12, 97);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(148, 35);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // writeTweet1
            // 
            this.writeTweet1.Location = new System.Drawing.Point(-5, -2);
            this.writeTweet1.Name = "writeTweet1";
            this.writeTweet1.Size = new System.Drawing.Size(340, 93);
            this.writeTweet1.TabIndex = 0;
            // 
            // NewTweet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 142);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_tweet);
            this.Controls.Add(this.writeTweet1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewTweet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "New tweet";
            this.ResumeLayout(false);

        }

        #endregion

        private WriteTweet writeTweet1;
        private System.Windows.Forms.Button button_tweet;
        private System.Windows.Forms.Button button_cancel;
    }
}
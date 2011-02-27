namespace TwitTicker
{
    partial class TweetReply
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
            this.button_reply = new System.Windows.Forms.Button();
            this.buttoncancel = new System.Windows.Forms.Button();
            this.writeTweet1 = new TwitTicker.WriteTweet();
            this.tweetdisplay1 = new TwitTicker.Tweetdisplay();
            this.SuspendLayout();
            // 
            // button_reply
            // 
            this.button_reply.Location = new System.Drawing.Point(39, 134);
            this.button_reply.Name = "button_reply";
            this.button_reply.Size = new System.Drawing.Size(119, 23);
            this.button_reply.TabIndex = 2;
            this.button_reply.Text = "Reply";
            this.button_reply.UseVisualStyleBackColor = true;
            this.button_reply.Click += new System.EventHandler(this.button_reply_Click);
            // 
            // buttoncancel
            // 
            this.buttoncancel.Location = new System.Drawing.Point(256, 134);
            this.buttoncancel.Name = "buttoncancel";
            this.buttoncancel.Size = new System.Drawing.Size(119, 23);
            this.buttoncancel.TabIndex = 3;
            this.buttoncancel.Text = "Cancel";
            this.buttoncancel.UseVisualStyleBackColor = true;
            this.buttoncancel.Click += new System.EventHandler(this.buttoncancel_Click);
            // 
            // writeTweet1
            // 
            this.writeTweet1.Location = new System.Drawing.Point(35, 56);
            this.writeTweet1.Name = "writeTweet1";
            this.writeTweet1.Size = new System.Drawing.Size(340, 73);
            this.writeTweet1.TabIndex = 1;
            // 
            // tweetdisplay1
            // 
            this.tweetdisplay1.BackColor = System.Drawing.Color.White;
            this.tweetdisplay1.Location = new System.Drawing.Point(0, 3);
            this.tweetdisplay1.Name = "tweetdisplay1";
            this.tweetdisplay1.Size = new System.Drawing.Size(417, 47);
            this.tweetdisplay1.TabIndex = 0;
            // 
            // TweetReply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 167);
            this.Controls.Add(this.buttoncancel);
            this.Controls.Add(this.button_reply);
            this.Controls.Add(this.writeTweet1);
            this.Controls.Add(this.tweetdisplay1);
            this.Name = "TweetReply";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TweetReply";
            this.ResumeLayout(false);

        }

        #endregion

        private Tweetdisplay tweetdisplay1;
        private WriteTweet writeTweet1;
        private System.Windows.Forms.Button button_reply;
        private System.Windows.Forms.Button buttoncancel;
    }
}
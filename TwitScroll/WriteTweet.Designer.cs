namespace TwitTicker
{
    partial class WriteTweet
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tweet_textbox = new System.Windows.Forms.RichTextBox();
            this.lable_remaining = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tweet_textbox
            // 
            this.tweet_textbox.Location = new System.Drawing.Point(16, 15);
            this.tweet_textbox.MaxLength = 140;
            this.tweet_textbox.Name = "tweet_textbox";
            this.tweet_textbox.Size = new System.Drawing.Size(314, 36);
            this.tweet_textbox.TabIndex = 0;
            this.tweet_textbox.Text = "";
            // 
            // lable_remaining
            // 
            this.lable_remaining.AutoSize = true;
            this.lable_remaining.Location = new System.Drawing.Point(13, 54);
            this.lable_remaining.Name = "lable_remaining";
            this.lable_remaining.Size = new System.Drawing.Size(127, 13);
            this.lable_remaining.TabIndex = 1;
            this.lable_remaining.Text = "Characters remaining 140";
            // 
            // WriteTweet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lable_remaining);
            this.Controls.Add(this.tweet_textbox);
            this.Name = "WriteTweet";
            this.Size = new System.Drawing.Size(340, 73);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox tweet_textbox;
        private System.Windows.Forms.Label lable_remaining;
    }
}

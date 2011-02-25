namespace TwitScroll
{
    partial class Tweetdisplay
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox_tweet = new System.Windows.Forms.TextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkRed;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox_tweet
            // 
            this.textBox_tweet.BackColor = System.Drawing.Color.White;
            this.textBox_tweet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_tweet.CausesValidation = false;
            this.textBox_tweet.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_tweet.Location = new System.Drawing.Point(41, 11);
            this.textBox_tweet.MaxLength = 140;
            this.textBox_tweet.Multiline = true;
            this.textBox_tweet.Name = "textBox_tweet";
            this.textBox_tweet.ReadOnly = true;
            this.textBox_tweet.Size = new System.Drawing.Size(373, 32);
            this.textBox_tweet.TabIndex = 1;
            this.textBox_tweet.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis aliquet nisl at lac" +
                "us sollicitudin non mattis sapien facilisis. Class posuere. ";
            // 
            // textBox_name
            // 
            this.textBox_name.BackColor = System.Drawing.Color.White;
            this.textBox_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_name.Location = new System.Drawing.Point(41, -2);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.ReadOnly = true;
            this.textBox_name.Size = new System.Drawing.Size(164, 13);
            this.textBox_name.TabIndex = 2;
            this.textBox_name.Text = "Robin Cornelius";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(241, -2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(164, 13);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "12:34pm";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Tweetdisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.textBox_tweet);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Tweetdisplay";
            this.Size = new System.Drawing.Size(455, 39);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox_tweet;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox1;
    }
}

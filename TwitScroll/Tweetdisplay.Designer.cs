namespace TwitTicker
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
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.followToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTweetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_newtweet = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_reply = new System.Windows.Forms.ToolStripMenuItem();
            this.retweetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retweetWithCommentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_name
            // 
            this.textBox_name.BackColor = System.Drawing.Color.White;
            this.textBox_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_name.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox_name.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_name.Location = new System.Drawing.Point(41, 1);
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
            this.textBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(211, 1);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(203, 13);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "12:34pm";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(41, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(374, 31);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.followToolStripMenuItem,
            this.viewTweetsToolStripMenuItem,
            this.toolStripSeparator4,
            this.toolStripMenuItem_newtweet,
            this.toolStripSeparator1,
            this.copyToolStripMenuItem,
            this.toolStripMenuItem_reply,
            this.retweetToolStripMenuItem,
            this.retweetWithCommentsToolStripMenuItem,
            this.toolStripSeparator2,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator3,
            this.settingsToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(203, 270);
            this.contextMenuStrip1.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip1_Closed);
            // 
            // followToolStripMenuItem
            // 
            this.followToolStripMenuItem.Name = "followToolStripMenuItem";
            this.followToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.followToolStripMenuItem.Text = "Follow";
            this.followToolStripMenuItem.Visible = false;
            this.followToolStripMenuItem.Click += new System.EventHandler(this.followToolStripMenuItem_Click);
            // 
            // viewTweetsToolStripMenuItem
            // 
            this.viewTweetsToolStripMenuItem.Name = "viewTweetsToolStripMenuItem";
            this.viewTweetsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.viewTweetsToolStripMenuItem.Text = "View tweets ";
            this.viewTweetsToolStripMenuItem.Click += new System.EventHandler(this.viewTweetsToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(199, 6);
            this.toolStripSeparator4.Visible = false;
            // 
            // toolStripMenuItem_newtweet
            // 
            this.toolStripMenuItem_newtweet.Image = global::TwitTicker.Properties.Resources._48;
            this.toolStripMenuItem_newtweet.Name = "toolStripMenuItem_newtweet";
            this.toolStripMenuItem_newtweet.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem_newtweet.Text = "New tweet";
            this.toolStripMenuItem_newtweet.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_reply
            // 
            this.toolStripMenuItem_reply.Image = global::TwitTicker.Properties.Resources._49;
            this.toolStripMenuItem_reply.Name = "toolStripMenuItem_reply";
            this.toolStripMenuItem_reply.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem_reply.Text = "Reply";
            this.toolStripMenuItem_reply.Click += new System.EventHandler(this.toolStripMenuItem_reply_Click);
            // 
            // retweetToolStripMenuItem
            // 
            this.retweetToolStripMenuItem.Image = global::TwitTicker.Properties.Resources._75;
            this.retweetToolStripMenuItem.Name = "retweetToolStripMenuItem";
            this.retweetToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.retweetToolStripMenuItem.Text = "Retweet";
            this.retweetToolStripMenuItem.Click += new System.EventHandler(this.retweetToolStripMenuItem_Click);
            // 
            // retweetWithCommentsToolStripMenuItem
            // 
            this.retweetWithCommentsToolStripMenuItem.Enabled = false;
            this.retweetWithCommentsToolStripMenuItem.Name = "retweetWithCommentsToolStripMenuItem";
            this.retweetWithCommentsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.retweetWithCommentsToolStripMenuItem.Text = "Retweet with comments";
            this.retweetWithCommentsToolStripMenuItem.Click += new System.EventHandler(this.retweetWithCommentsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(199, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::TwitTicker.Properties.Resources._33;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(199, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::TwitTicker.Properties.Resources._73;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Image = global::TwitTicker.Properties.Resources._33;
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkRed;
            this.pictureBox1.Location = new System.Drawing.Point(5, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Tweetdisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Tweetdisplay";
            this.Size = new System.Drawing.Size(417, 47);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_newtweet;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_reply;
        private System.Windows.Forms.ToolStripMenuItem retweetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retweetWithCommentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem followToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem viewTweetsToolStripMenuItem;
    }
}

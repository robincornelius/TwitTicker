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
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_newtweet = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_reply = new System.Windows.Forms.ToolStripMenuItem();
            this.retweetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retweetWithCommentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            // textBox_name
            // 
            this.textBox_name.BackColor = System.Drawing.Color.White;
            this.textBox_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
            this.toolStripMenuItem_newtweet,
            this.toolStripSeparator1,
            this.toolStripMenuItem_reply,
            this.retweetToolStripMenuItem,
            this.retweetWithCommentsToolStripMenuItem,
            this.toolStripSeparator2,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(203, 148);
            // 
            // toolStripMenuItem_newtweet
            // 
            this.toolStripMenuItem_newtweet.Name = "toolStripMenuItem_newtweet";
            this.toolStripMenuItem_newtweet.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem_newtweet.Text = "New tweet";
            this.toolStripMenuItem_newtweet.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem_reply
            // 
            this.toolStripMenuItem_reply.Name = "toolStripMenuItem_reply";
            this.toolStripMenuItem_reply.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem_reply.Text = "Reply";
            this.toolStripMenuItem_reply.Click += new System.EventHandler(this.toolStripMenuItem_reply_Click);
            // 
            // retweetToolStripMenuItem
            // 
            this.retweetToolStripMenuItem.Name = "retweetToolStripMenuItem";
            this.retweetToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.retweetToolStripMenuItem.Text = "Retweet";
            this.retweetToolStripMenuItem.Click += new System.EventHandler(this.retweetToolStripMenuItem_Click);
            // 
            // retweetWithCommentsToolStripMenuItem
            // 
            this.retweetWithCommentsToolStripMenuItem.Name = "retweetWithCommentsToolStripMenuItem";
            this.retweetWithCommentsToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.retweetWithCommentsToolStripMenuItem.Text = "Retweet with comments";
            this.retweetWithCommentsToolStripMenuItem.Click += new System.EventHandler(this.retweetWithCommentsToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(199, 6);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
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
    }
}

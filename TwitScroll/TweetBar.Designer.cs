namespace TwitScroll
{
    partial class TweetBar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TweetBar));
            this.Scrolltimer = new System.Windows.Forms.Timer(this.components);
            this.Synctimer = new System.Windows.Forms.Timer(this.components);
            this.tweetdisplay1 = new TwitScroll.Tweetdisplay();
            this.tweetdisplay2 = new TwitScroll.Tweetdisplay();
            this.tweetdisplay3 = new TwitScroll.Tweetdisplay();
            this.tweetdisplay4 = new TwitScroll.Tweetdisplay();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_quit = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Scrolltimer
            // 
            this.Scrolltimer.Interval = 10000;
            this.Scrolltimer.Tick += new System.EventHandler(this.tick);
            // 
            // Synctimer
            // 
            this.Synctimer.Interval = 60000;
            this.Synctimer.Tick += new System.EventHandler(this.reloadtweets);
            // 
            // tweetdisplay1
            // 
            this.tweetdisplay1.BackColor = System.Drawing.Color.White;
            this.tweetdisplay1.Location = new System.Drawing.Point(3, 0);
            this.tweetdisplay1.Name = "tweetdisplay1";
            this.tweetdisplay1.Size = new System.Drawing.Size(419, 43);
            this.tweetdisplay1.TabIndex = 2;
            // 
            // tweetdisplay2
            // 
            this.tweetdisplay2.BackColor = System.Drawing.Color.White;
            this.tweetdisplay2.Location = new System.Drawing.Point(428, -1);
            this.tweetdisplay2.Name = "tweetdisplay2";
            this.tweetdisplay2.Size = new System.Drawing.Size(419, 43);
            this.tweetdisplay2.TabIndex = 3;
            // 
            // tweetdisplay3
            // 
            this.tweetdisplay3.BackColor = System.Drawing.Color.White;
            this.tweetdisplay3.Location = new System.Drawing.Point(853, -1);
            this.tweetdisplay3.Name = "tweetdisplay3";
            this.tweetdisplay3.Size = new System.Drawing.Size(416, 43);
            this.tweetdisplay3.TabIndex = 4;
            // 
            // tweetdisplay4
            // 
            this.tweetdisplay4.BackColor = System.Drawing.Color.White;
            this.tweetdisplay4.Location = new System.Drawing.Point(1274, 0);
            this.tweetdisplay4.Name = "tweetdisplay4";
            this.tweetdisplay4.Size = new System.Drawing.Size(416, 43);
            this.tweetdisplay4.TabIndex = 5;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "TwitScroll";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_quit,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            // 
            // toolStripMenuItem_quit
            // 
            this.toolStripMenuItem_quit.Name = "toolStripMenuItem_quit";
            this.toolStripMenuItem_quit.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_quit.Text = "Quit";
            this.toolStripMenuItem_quit.Click += new System.EventHandler(this.toolStripMenuItem_quit_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // TweetBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1300, 44);
            this.ControlBox = false;
            this.Controls.Add(this.tweetdisplay4);
            this.Controls.Add(this.tweetdisplay3);
            this.Controls.Add(this.tweetdisplay2);
            this.Controls.Add(this.tweetdisplay1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TweetBar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Scrolltimer;
        private System.Windows.Forms.Timer Synctimer;
        private Tweetdisplay tweetdisplay1;
        private Tweetdisplay tweetdisplay2;
        private Tweetdisplay tweetdisplay3;
        private Tweetdisplay tweetdisplay4;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_quit;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}


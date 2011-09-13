namespace TwitTicker
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
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newtweetcontextmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_quit = new System.Windows.Forms.ToolStripMenuItem();
            this.startauthtimer = new System.Windows.Forms.Timer(this.components);
            this.button_left = new System.Windows.Forms.Button();
            this.button_right = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
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
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "TwitTicker";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newtweetcontextmenu,
            this.toolStripSeparator1,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolStripMenuItem_quit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 98);
            // 
            // newtweetcontextmenu
            // 
            this.newtweetcontextmenu.Image = global::TwitTicker.Properties.Resources._48;
            this.newtweetcontextmenu.Name = "newtweetcontextmenu";
            this.newtweetcontextmenu.Size = new System.Drawing.Size(130, 22);
            this.newtweetcontextmenu.Text = "New tweet";
            this.newtweetcontextmenu.Click += new System.EventHandler(this.newtweetcontextmenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::TwitTicker.Properties.Resources._73;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::TwitTicker.Properties.Resources._3;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_quit
            // 
            this.toolStripMenuItem_quit.Image = global::TwitTicker.Properties.Resources._33;
            this.toolStripMenuItem_quit.Name = "toolStripMenuItem_quit";
            this.toolStripMenuItem_quit.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItem_quit.Text = "Quit";
            this.toolStripMenuItem_quit.Click += new System.EventHandler(this.toolStripMenuItem_quit_Click);
            // 
            // startauthtimer
            // 
            this.startauthtimer.Interval = 1000;
            // 
            // button_left
            // 
            this.button_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_left.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_left.Image = global::TwitTicker.Properties.Resources.left1;
            this.button_left.Location = new System.Drawing.Point(0, 0);
            this.button_left.Name = "button_left";
            this.button_left.Size = new System.Drawing.Size(14, 44);
            this.button_left.TabIndex = 1;
            this.button_left.UseVisualStyleBackColor = true;
            this.button_left.Click += new System.EventHandler(this.button_left_Click);
            // 
            // button_right
            // 
            this.button_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_right.Image = global::TwitTicker.Properties.Resources.right1;
            this.button_right.Location = new System.Drawing.Point(1286, 0);
            this.button_right.Name = "button_right";
            this.button_right.Size = new System.Drawing.Size(14, 44);
            this.button_right.TabIndex = 2;
            this.button_right.UseVisualStyleBackColor = true;
            this.button_right.Click += new System.EventHandler(this.button_right_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(14, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1272, 44);
            this.panel1.TabIndex = 3;
            // 
            // TweetBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1300, 44);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_right);
            this.Controls.Add(this.button_left);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Location = new System.Drawing.Point(0, -200);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TweetBar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TwitTicker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Scrolltimer;
        private System.Windows.Forms.Timer Synctimer;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_quit;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newtweetcontextmenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer startauthtimer;
        private System.Windows.Forms.Button button_left;
        private System.Windows.Forms.Button button_right;
        private System.Windows.Forms.Panel panel1;
    }
}


namespace TwitScroll
{
    partial class Form1
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tweetdisplay1 = new TwitScroll.Tweetdisplay();
            this.tweetdisplay2 = new TwitScroll.Tweetdisplay();
            this.tweetdisplay3 = new TwitScroll.Tweetdisplay();
            this.tweetdisplay4 = new TwitScroll.Tweetdisplay();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 60000;
            this.timer2.Tick += new System.EventHandler(this.reloadtweets);
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
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1710, 44);
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
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private Tweetdisplay tweetdisplay1;
        private Tweetdisplay tweetdisplay2;
        private Tweetdisplay tweetdisplay3;
        private Tweetdisplay tweetdisplay4;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}


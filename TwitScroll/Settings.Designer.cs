namespace TwitScroll
{
    partial class Settings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_twitterupdate = new System.Windows.Forms.TextBox();
            this.textBox_scrollrefresh = new System.Windows.Forms.TextBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.checkBox_autostart = new System.Windows.Forms.CheckBox();
            this.comboBox_barposition = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_timedscroll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Twitter update interval (s)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Scroll interval (s)";
            // 
            // textBox_twitterupdate
            // 
            this.textBox_twitterupdate.Location = new System.Drawing.Point(155, 16);
            this.textBox_twitterupdate.Name = "textBox_twitterupdate";
            this.textBox_twitterupdate.Size = new System.Drawing.Size(62, 20);
            this.textBox_twitterupdate.TabIndex = 2;
            // 
            // textBox_scrollrefresh
            // 
            this.textBox_scrollrefresh.Location = new System.Drawing.Point(155, 77);
            this.textBox_scrollrefresh.Name = "textBox_scrollrefresh";
            this.textBox_scrollrefresh.Size = new System.Drawing.Size(62, 20);
            this.textBox_scrollrefresh.TabIndex = 3;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(28, 250);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(98, 21);
            this.button_OK.TabIndex = 4;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(155, 250);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(98, 21);
            this.button_cancel.TabIndex = 5;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // checkBox_autostart
            // 
            this.checkBox_autostart.AutoSize = true;
            this.checkBox_autostart.Location = new System.Drawing.Point(28, 173);
            this.checkBox_autostart.Name = "checkBox_autostart";
            this.checkBox_autostart.Size = new System.Drawing.Size(139, 17);
            this.checkBox_autostart.TabIndex = 6;
            this.checkBox_autostart.Text = "Start at windows startup";
            this.checkBox_autostart.UseVisualStyleBackColor = true;
            this.checkBox_autostart.CheckedChanged += new System.EventHandler(this.checkBox_autostart_CheckedChanged);
            // 
            // comboBox_barposition
            // 
            this.comboBox_barposition.FormattingEnabled = true;
            this.comboBox_barposition.Items.AddRange(new object[] {
            "Top",
            "Bottom"});
            this.comboBox_barposition.Location = new System.Drawing.Point(118, 206);
            this.comboBox_barposition.Name = "comboBox_barposition";
            this.comboBox_barposition.Size = new System.Drawing.Size(118, 21);
            this.comboBox_barposition.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Bar position";
            // 
            // checkBox_timedscroll
            // 
            this.checkBox_timedscroll.AutoSize = true;
            this.checkBox_timedscroll.Checked = true;
            this.checkBox_timedscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_timedscroll.Location = new System.Drawing.Point(28, 50);
            this.checkBox_timedscroll.Name = "checkBox_timedscroll";
            this.checkBox_timedscroll.Size = new System.Drawing.Size(82, 17);
            this.checkBox_timedscroll.TabIndex = 9;
            this.checkBox_timedscroll.Text = "Timed scroll";
            this.checkBox_timedscroll.UseVisualStyleBackColor = true;
            this.checkBox_timedscroll.CheckedChanged += new System.EventHandler(this.checkBox_timedscroll_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 283);
            this.Controls.Add(this.checkBox_timedscroll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_barposition);
            this.Controls.Add(this.checkBox_autostart);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_scrollrefresh);
            this.Controls.Add(this.textBox_twitterupdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.Text = "TwitScroll Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_twitterupdate;
        private System.Windows.Forms.TextBox textBox_scrollrefresh;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.CheckBox checkBox_autostart;
        private System.Windows.Forms.ComboBox comboBox_barposition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox_timedscroll;
    }
}
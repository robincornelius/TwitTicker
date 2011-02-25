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
            this.label2.Location = new System.Drawing.Point(25, 50);
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
            this.textBox_scrollrefresh.Location = new System.Drawing.Point(155, 47);
            this.textBox_scrollrefresh.Name = "textBox_scrollrefresh";
            this.textBox_scrollrefresh.Size = new System.Drawing.Size(62, 20);
            this.textBox_scrollrefresh.TabIndex = 3;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(28, 123);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(98, 21);
            this.button_OK.TabIndex = 4;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(155, 123);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(98, 21);
            this.button_cancel.TabIndex = 5;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 162);
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
    }
}
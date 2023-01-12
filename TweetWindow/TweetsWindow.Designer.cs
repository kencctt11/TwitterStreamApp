namespace TweetWindow
{
    partial class TweetsWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxTweets = new System.Windows.Forms.TextBox();
            this.buttonStartStream = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxTweets
            // 
            this.textBoxTweets.Location = new System.Drawing.Point(130, 27);
            this.textBoxTweets.Multiline = true;
            this.textBoxTweets.Name = "textBoxTweets";
            this.textBoxTweets.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTweets.Size = new System.Drawing.Size(734, 478);
            this.textBoxTweets.TabIndex = 0;
            // 
            // buttonStartStream
            // 
            this.buttonStartStream.Location = new System.Drawing.Point(12, 27);
            this.buttonStartStream.Name = "buttonStartStream";
            this.buttonStartStream.Size = new System.Drawing.Size(75, 23);
            this.buttonStartStream.TabIndex = 1;
            this.buttonStartStream.Text = "Start";
            this.buttonStartStream.UseVisualStyleBackColor = true;
            this.buttonStartStream.Click += new System.EventHandler(this.buttonStartStream_Click);
            // 
            // TweetsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 543);
            this.Controls.Add(this.buttonStartStream);
            this.Controls.Add(this.textBoxTweets);
            this.Name = "TweetsWindow";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxTweets;
        private Button buttonStartStream;
    }
}
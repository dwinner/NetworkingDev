namespace WebDownloaderAsync
{
    partial class DownloadForm
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
         this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
         this.urlTextBox = new System.Windows.Forms.TextBox();
         this.urlLabel = new System.Windows.Forms.Label();
         this.downloadButton = new System.Windows.Forms.Button();
         this.statusLabel = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // downloadProgressBar
         // 
         this.downloadProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.downloadProgressBar.Location = new System.Drawing.Point(12, 70);
         this.downloadProgressBar.Name = "downloadProgressBar";
         this.downloadProgressBar.Size = new System.Drawing.Size(260, 23);
         this.downloadProgressBar.TabIndex = 0;
         // 
         // urlTextBox
         // 
         this.urlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.urlTextBox.Location = new System.Drawing.Point(54, 10);
         this.urlTextBox.Name = "urlTextBox";
         this.urlTextBox.Size = new System.Drawing.Size(218, 20);
         this.urlTextBox.TabIndex = 1;
         // 
         // urlLabel
         // 
         this.urlLabel.AutoSize = true;
         this.urlLabel.Location = new System.Drawing.Point(13, 13);
         this.urlLabel.Name = "urlLabel";
         this.urlLabel.Size = new System.Drawing.Size(32, 13);
         this.urlLabel.TabIndex = 2;
         this.urlLabel.Text = "URL:";
         // 
         // downloadButton
         // 
         this.downloadButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
         this.downloadButton.Location = new System.Drawing.Point(105, 38);
         this.downloadButton.Name = "downloadButton";
         this.downloadButton.Size = new System.Drawing.Size(75, 23);
         this.downloadButton.TabIndex = 3;
         this.downloadButton.Text = "Download";
         this.downloadButton.UseVisualStyleBackColor = true;
         this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
         // 
         // statusLabel
         // 
         this.statusLabel.AutoSize = true;
         this.statusLabel.Location = new System.Drawing.Point(13, 99);
         this.statusLabel.Name = "statusLabel";
         this.statusLabel.Size = new System.Drawing.Size(46, 13);
         this.statusLabel.TabIndex = 4;
         this.statusLabel.Text = "Status...";
         // 
         // DownloadForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 121);
         this.Controls.Add(this.statusLabel);
         this.Controls.Add(this.downloadButton);
         this.Controls.Add(this.urlLabel);
         this.Controls.Add(this.urlTextBox);
         this.Controls.Add(this.downloadProgressBar);
         this.Name = "DownloadForm";
         this.Text = "Async Downloader";
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar downloadProgressBar;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Label statusLabel;
    }
}


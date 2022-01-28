namespace WinForms.Hub.Client
{
   partial class HubClientForm
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
         this.CurrentBidButton = new System.Windows.Forms.Button();
         this.MakeBidButton = new System.Windows.Forms.Button();
         this.BidTextBox = new System.Windows.Forms.TextBox();
         this.WinsListBox = new System.Windows.Forms.ListBox();
         this.NameLabel = new System.Windows.Forms.Label();
         this.DescriptionLabel = new System.Windows.Forms.Label();
         this.BidLabel = new System.Windows.Forms.Label();
         this.TimeLabel = new System.Windows.Forms.Label();
         this.TimeValueLabel = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // CurrentBidButton
         // 
         this.CurrentBidButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.CurrentBidButton.Location = new System.Drawing.Point(12, 75);
         this.CurrentBidButton.Name = "CurrentBidButton";
         this.CurrentBidButton.Size = new System.Drawing.Size(75, 23);
         this.CurrentBidButton.TabIndex = 0;
         this.CurrentBidButton.Text = "Current Bid";
         this.CurrentBidButton.UseVisualStyleBackColor = true;
         this.CurrentBidButton.Click += new System.EventHandler(this.CurrentBidButton_Click);
         // 
         // MakeBidButton
         // 
         this.MakeBidButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.MakeBidButton.Location = new System.Drawing.Point(93, 75);
         this.MakeBidButton.Name = "MakeBidButton";
         this.MakeBidButton.Size = new System.Drawing.Size(75, 23);
         this.MakeBidButton.TabIndex = 1;
         this.MakeBidButton.Text = "Make Bid";
         this.MakeBidButton.UseVisualStyleBackColor = true;
         this.MakeBidButton.Click += new System.EventHandler(this.MakeBidButton_Click);
         // 
         // BidTextBox
         // 
         this.BidTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.BidTextBox.Location = new System.Drawing.Point(249, 77);
         this.BidTextBox.Name = "BidTextBox";
         this.BidTextBox.Size = new System.Drawing.Size(100, 20);
         this.BidTextBox.TabIndex = 2;
         // 
         // WinsListBox
         // 
         this.WinsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.WinsListBox.FormattingEnabled = true;
         this.WinsListBox.Location = new System.Drawing.Point(12, 104);
         this.WinsListBox.Name = "WinsListBox";
         this.WinsListBox.Size = new System.Drawing.Size(337, 147);
         this.WinsListBox.TabIndex = 3;
         // 
         // NameLabel
         // 
         this.NameLabel.AutoSize = true;
         this.NameLabel.Location = new System.Drawing.Point(9, 19);
         this.NameLabel.Name = "NameLabel";
         this.NameLabel.Size = new System.Drawing.Size(35, 13);
         this.NameLabel.TabIndex = 4;
         this.NameLabel.Text = "Name";
         // 
         // DescriptionLabel
         // 
         this.DescriptionLabel.AutoSize = true;
         this.DescriptionLabel.Location = new System.Drawing.Point(9, 42);
         this.DescriptionLabel.Name = "DescriptionLabel";
         this.DescriptionLabel.Size = new System.Drawing.Size(60, 13);
         this.DescriptionLabel.TabIndex = 5;
         this.DescriptionLabel.Text = "Description";
         // 
         // BidLabel
         // 
         this.BidLabel.AutoSize = true;
         this.BidLabel.Location = new System.Drawing.Point(65, 19);
         this.BidLabel.Name = "BidLabel";
         this.BidLabel.Size = new System.Drawing.Size(22, 13);
         this.BidLabel.TabIndex = 6;
         this.BidLabel.Text = "Bid";
         // 
         // TimeLabel
         // 
         this.TimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.TimeLabel.AutoSize = true;
         this.TimeLabel.Location = new System.Drawing.Point(282, 9);
         this.TimeLabel.Name = "TimeLabel";
         this.TimeLabel.Size = new System.Drawing.Size(47, 13);
         this.TimeLabel.TabIndex = 7;
         this.TimeLabel.Text = "Time left";
         // 
         // TimeValueLabel
         // 
         this.TimeValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.TimeValueLabel.AutoSize = true;
         this.TimeValueLabel.Location = new System.Drawing.Point(335, 9);
         this.TimeValueLabel.Name = "TimeValueLabel";
         this.TimeValueLabel.Size = new System.Drawing.Size(14, 13);
         this.TimeValueLabel.TabIndex = 8;
         this.TimeValueLabel.Text = "#";
         // 
         // HubClientForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(361, 261);
         this.Controls.Add(this.TimeValueLabel);
         this.Controls.Add(this.TimeLabel);
         this.Controls.Add(this.BidLabel);
         this.Controls.Add(this.DescriptionLabel);
         this.Controls.Add(this.NameLabel);
         this.Controls.Add(this.WinsListBox);
         this.Controls.Add(this.BidTextBox);
         this.Controls.Add(this.MakeBidButton);
         this.Controls.Add(this.CurrentBidButton);
         this.Name = "HubClientForm";
         this.Text = "Hub client";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button CurrentBidButton;
      private System.Windows.Forms.Button MakeBidButton;
      private System.Windows.Forms.TextBox BidTextBox;
      private System.Windows.Forms.ListBox WinsListBox;
      private System.Windows.Forms.Label NameLabel;
      private System.Windows.Forms.Label DescriptionLabel;
      private System.Windows.Forms.Label BidLabel;
      private System.Windows.Forms.Label TimeLabel;
      private System.Windows.Forms.Label TimeValueLabel;
   }
}


namespace RssReader
{
    partial class RssReaderForm
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
         this.feedLabel = new System.Windows.Forms.Label();
         this.feedTextBox = new System.Windows.Forms.TextBox();
         this.loadButton = new System.Windows.Forms.Button();
         this.entriesListView = new System.Windows.Forms.ListView();
         this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeaderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeaderLink = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
         this.SuspendLayout();
         // 
         // feedLabel
         // 
         this.feedLabel.AutoSize = true;
         this.feedLabel.Location = new System.Drawing.Point(13, 13);
         this.feedLabel.Name = "feedLabel";
         this.feedLabel.Size = new System.Drawing.Size(34, 13);
         this.feedLabel.TabIndex = 0;
         this.feedLabel.Text = "Feed:";
         // 
         // feedTextBox
         // 
         this.feedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.feedTextBox.Location = new System.Drawing.Point(54, 9);
         this.feedTextBox.Name = "feedTextBox";
         this.feedTextBox.Size = new System.Drawing.Size(496, 20);
         this.feedTextBox.TabIndex = 1;
         // 
         // loadButton
         // 
         this.loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.loadButton.Location = new System.Drawing.Point(556, 8);
         this.loadButton.Name = "loadButton";
         this.loadButton.Size = new System.Drawing.Size(21, 23);
         this.loadButton.TabIndex = 2;
         this.loadButton.Text = ">";
         this.loadButton.UseVisualStyleBackColor = true;
         this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
         // 
         // entriesListView
         // 
         this.entriesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.entriesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDate,
            this.columnHeaderTitle,
            this.columnHeaderLink});
         this.entriesListView.Location = new System.Drawing.Point(16, 48);
         this.entriesListView.Name = "entriesListView";
         this.entriesListView.Size = new System.Drawing.Size(561, 97);
         this.entriesListView.TabIndex = 3;
         this.entriesListView.UseCompatibleStateImageBehavior = false;
         this.entriesListView.View = System.Windows.Forms.View.Details;
         this.entriesListView.SelectedIndexChanged += new System.EventHandler(this.OnSelectListViewItem);
         // 
         // columnHeaderDate
         // 
         this.columnHeaderDate.Text = "Date";
         // 
         // columnHeaderTitle
         // 
         this.columnHeaderTitle.Text = "Title";
         this.columnHeaderTitle.Width = 310;
         // 
         // columnHeaderLink
         // 
         this.columnHeaderLink.Text = "Link";
         this.columnHeaderLink.Width = 164;
         // 
         // descriptionTextBox
         // 
         this.descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.descriptionTextBox.Location = new System.Drawing.Point(12, 151);
         this.descriptionTextBox.Name = "descriptionTextBox";
         this.descriptionTextBox.Size = new System.Drawing.Size(565, 234);
         this.descriptionTextBox.TabIndex = 4;
         this.descriptionTextBox.Text = "";
         // 
         // RssReaderForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(589, 397);
         this.Controls.Add(this.descriptionTextBox);
         this.Controls.Add(this.entriesListView);
         this.Controls.Add(this.loadButton);
         this.Controls.Add(this.feedTextBox);
         this.Controls.Add(this.feedLabel);
         this.Name = "RssReaderForm";
         this.Text = "RSS Reader";
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label feedLabel;
        private System.Windows.Forms.TextBox feedTextBox;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.ListView entriesListView;
        private System.Windows.Forms.ColumnHeader columnHeaderTitle;
        private System.Windows.Forms.RichTextBox descriptionTextBox;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderLink;
    }
}


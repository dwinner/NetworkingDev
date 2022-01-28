namespace WCFClient
{
    partial class WcfClientForm
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
            if (disposing)
            {
                if (_fileServiceClient != null)
                {
                    _fileServiceClient.Close();
                }
                if (components != null)
                {
                    components.Dispose();
                }
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
         this.getSubdirsLabel = new System.Windows.Forms.Label();
         this.getSubDirsTextBox = new System.Windows.Forms.TextBox();
         this.getSubDirsButton = new System.Windows.Forms.Button();
         this.getFilesLabel = new System.Windows.Forms.Label();
         this.getFilesTextBox = new System.Windows.Forms.TextBox();
         this.getFileContentsLabel = new System.Windows.Forms.Label();
         this.retrieveFileTextBox = new System.Windows.Forms.TextBox();
         this.bytesToReadNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.bytesLabel = new System.Windows.Forms.Label();
         this.getFilesButton = new System.Windows.Forms.Button();
         this.getFileContentsButton = new System.Windows.Forms.Button();
         this.textBoxOutput = new System.Windows.Forms.TextBox();
         this.resultsGroupBox = new System.Windows.Forms.GroupBox();
         ((System.ComponentModel.ISupportInitialize)(this.bytesToReadNumericUpDown)).BeginInit();
         this.resultsGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // getSubdirsLabel
         // 
         this.getSubdirsLabel.AutoSize = true;
         this.getSubdirsLabel.Location = new System.Drawing.Point(19, 13);
         this.getSubdirsLabel.Name = "getSubdirsLabel";
         this.getSubdirsLabel.Size = new System.Drawing.Size(95, 13);
         this.getSubdirsLabel.TabIndex = 0;
         this.getSubdirsLabel.Text = "Get subdirectories:";
         // 
         // getSubDirsTextBox
         // 
         this.getSubDirsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.getSubDirsTextBox.Location = new System.Drawing.Point(116, 9);
         this.getSubDirsTextBox.Name = "getSubDirsTextBox";
         this.getSubDirsTextBox.Size = new System.Drawing.Size(479, 20);
         this.getSubDirsTextBox.TabIndex = 1;
         this.getSubDirsTextBox.Text = "C:\\";
         // 
         // getSubDirsButton
         // 
         this.getSubDirsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.getSubDirsButton.Location = new System.Drawing.Point(601, 8);
         this.getSubDirsButton.Name = "getSubDirsButton";
         this.getSubDirsButton.Size = new System.Drawing.Size(47, 23);
         this.getSubDirsButton.TabIndex = 2;
         this.getSubDirsButton.Text = "Go";
         this.getSubDirsButton.UseVisualStyleBackColor = true;
         this.getSubDirsButton.Click += new System.EventHandler(this.buttonGetSubDirs_Click);
         // 
         // getFilesLabel
         // 
         this.getFilesLabel.AutoSize = true;
         this.getFilesLabel.Location = new System.Drawing.Point(19, 42);
         this.getFilesLabel.Name = "getFilesLabel";
         this.getFilesLabel.Size = new System.Drawing.Size(48, 13);
         this.getFilesLabel.TabIndex = 3;
         this.getFilesLabel.Text = "Get files:";
         // 
         // getFilesTextBox
         // 
         this.getFilesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.getFilesTextBox.Location = new System.Drawing.Point(116, 38);
         this.getFilesTextBox.Name = "getFilesTextBox";
         this.getFilesTextBox.Size = new System.Drawing.Size(479, 20);
         this.getFilesTextBox.TabIndex = 4;
         this.getFilesTextBox.Text = "C:\\Windows\\System32\\drivers\\etc\\";
         // 
         // getFileContentsLabel
         // 
         this.getFileContentsLabel.AutoSize = true;
         this.getFileContentsLabel.Location = new System.Drawing.Point(19, 71);
         this.getFileContentsLabel.Name = "getFileContentsLabel";
         this.getFileContentsLabel.Size = new System.Drawing.Size(87, 13);
         this.getFileContentsLabel.TabIndex = 5;
         this.getFileContentsLabel.Text = "Get file contents:";
         // 
         // retrieveFileTextBox
         // 
         this.retrieveFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.retrieveFileTextBox.Location = new System.Drawing.Point(116, 67);
         this.retrieveFileTextBox.Name = "retrieveFileTextBox";
         this.retrieveFileTextBox.Size = new System.Drawing.Size(382, 20);
         this.retrieveFileTextBox.TabIndex = 6;
         this.retrieveFileTextBox.Text = "C:\\Windows\\System32\\drivers\\etc\\hosts";
         // 
         // bytesToReadNumericUpDown
         // 
         this.bytesToReadNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.bytesToReadNumericUpDown.Location = new System.Drawing.Point(542, 67);
         this.bytesToReadNumericUpDown.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
         this.bytesToReadNumericUpDown.Name = "bytesToReadNumericUpDown";
         this.bytesToReadNumericUpDown.Size = new System.Drawing.Size(53, 20);
         this.bytesToReadNumericUpDown.TabIndex = 7;
         this.bytesToReadNumericUpDown.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
         // 
         // bytesLabel
         // 
         this.bytesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.bytesLabel.AutoSize = true;
         this.bytesLabel.Location = new System.Drawing.Point(505, 71);
         this.bytesLabel.Name = "bytesLabel";
         this.bytesLabel.Size = new System.Drawing.Size(35, 13);
         this.bytesLabel.TabIndex = 8;
         this.bytesLabel.Text = "bytes:";
         // 
         // getFilesButton
         // 
         this.getFilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.getFilesButton.Location = new System.Drawing.Point(601, 37);
         this.getFilesButton.Name = "getFilesButton";
         this.getFilesButton.Size = new System.Drawing.Size(47, 23);
         this.getFilesButton.TabIndex = 9;
         this.getFilesButton.Text = "Go";
         this.getFilesButton.UseVisualStyleBackColor = true;
         this.getFilesButton.Click += new System.EventHandler(this.buttonGetFiles_Click);
         // 
         // getFileContentsButton
         // 
         this.getFileContentsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.getFileContentsButton.Location = new System.Drawing.Point(601, 66);
         this.getFileContentsButton.Name = "getFileContentsButton";
         this.getFileContentsButton.Size = new System.Drawing.Size(47, 23);
         this.getFileContentsButton.TabIndex = 10;
         this.getFileContentsButton.Text = "Go";
         this.getFileContentsButton.UseVisualStyleBackColor = true;
         this.getFileContentsButton.Click += new System.EventHandler(this.buttonGetFileContents_Click);
         // 
         // textBoxOutput
         // 
         this.textBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
         this.textBoxOutput.Location = new System.Drawing.Point(3, 16);
         this.textBoxOutput.Multiline = true;
         this.textBoxOutput.Name = "textBoxOutput";
         this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         this.textBoxOutput.Size = new System.Drawing.Size(630, 102);
         this.textBoxOutput.TabIndex = 11;
         // 
         // resultsGroupBox
         // 
         this.resultsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.resultsGroupBox.Controls.Add(this.textBoxOutput);
         this.resultsGroupBox.Location = new System.Drawing.Point(12, 93);
         this.resultsGroupBox.Name = "resultsGroupBox";
         this.resultsGroupBox.Size = new System.Drawing.Size(636, 121);
         this.resultsGroupBox.TabIndex = 12;
         this.resultsGroupBox.TabStop = false;
         this.resultsGroupBox.Text = "Results";
         // 
         // WcfClientForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(660, 226);
         this.Controls.Add(this.resultsGroupBox);
         this.Controls.Add(this.getFileContentsButton);
         this.Controls.Add(this.getFilesButton);
         this.Controls.Add(this.bytesLabel);
         this.Controls.Add(this.bytesToReadNumericUpDown);
         this.Controls.Add(this.retrieveFileTextBox);
         this.Controls.Add(this.getFileContentsLabel);
         this.Controls.Add(this.getFilesTextBox);
         this.Controls.Add(this.getFilesLabel);
         this.Controls.Add(this.getSubDirsButton);
         this.Controls.Add(this.getSubDirsTextBox);
         this.Controls.Add(this.getSubdirsLabel);
         this.Name = "WcfClientForm";
         this.Text = "WCF Client";
         ((System.ComponentModel.ISupportInitialize)(this.bytesToReadNumericUpDown)).EndInit();
         this.resultsGroupBox.ResumeLayout(false);
         this.resultsGroupBox.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label getSubdirsLabel;
        private System.Windows.Forms.TextBox getSubDirsTextBox;
        private System.Windows.Forms.Button getSubDirsButton;
        private System.Windows.Forms.Label getFilesLabel;
        private System.Windows.Forms.TextBox getFilesTextBox;
        private System.Windows.Forms.Label getFileContentsLabel;
        private System.Windows.Forms.TextBox retrieveFileTextBox;
        private System.Windows.Forms.NumericUpDown bytesToReadNumericUpDown;
        private System.Windows.Forms.Label bytesLabel;
        private System.Windows.Forms.Button getFilesButton;
        private System.Windows.Forms.Button getFileContentsButton;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.GroupBox resultsGroupBox;
    }
}


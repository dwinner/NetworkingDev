namespace EmailClient
{
    partial class EmailClientForm
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
         this.hostLabel = new System.Windows.Forms.Label();
         this.hostnameTextBox = new System.Windows.Forms.TextBox();
         this.portLabel = new System.Windows.Forms.Label();
         this.portNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.fromLabel = new System.Windows.Forms.Label();
         this.toLabel = new System.Windows.Forms.Label();
         this.subjectLabel = new System.Windows.Forms.Label();
         this.fromTextBox = new System.Windows.Forms.TextBox();
         this.toTextBox = new System.Windows.Forms.TextBox();
         this.subjectTextBox = new System.Windows.Forms.TextBox();
         this.bodyTextBody = new System.Windows.Forms.TextBox();
         this.filesListView = new System.Windows.Forms.ListView();
         this.fileColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.sizeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.sendButton = new System.Windows.Forms.Button();
         this.usernameLabel = new System.Windows.Forms.Label();
         this.usernameTextBox = new System.Windows.Forms.TextBox();
         this.bodyLabel = new System.Windows.Forms.Label();
         this.passwordLabel = new System.Windows.Forms.Label();
         this.passwordTextBox = new System.Windows.Forms.TextBox();
         this.attachFileButton = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).BeginInit();
         this.SuspendLayout();
         // 
         // hostLabel
         // 
         this.hostLabel.AutoSize = true;
         this.hostLabel.Location = new System.Drawing.Point(13, 13);
         this.hostLabel.Name = "hostLabel";
         this.hostLabel.Size = new System.Drawing.Size(32, 13);
         this.hostLabel.TabIndex = 0;
         this.hostLabel.Text = "Host:";
         // 
         // hostnameTextBox
         // 
         this.hostnameTextBox.Location = new System.Drawing.Point(77, 9);
         this.hostnameTextBox.Name = "hostnameTextBox";
         this.hostnameTextBox.Size = new System.Drawing.Size(100, 20);
         this.hostnameTextBox.TabIndex = 1;
         // 
         // portLabel
         // 
         this.portLabel.AutoSize = true;
         this.portLabel.Location = new System.Drawing.Point(182, 13);
         this.portLabel.Name = "portLabel";
         this.portLabel.Size = new System.Drawing.Size(29, 13);
         this.portLabel.TabIndex = 2;
         this.portLabel.Text = "Port:";
         // 
         // portNumericUpDown
         // 
         this.portNumericUpDown.Location = new System.Drawing.Point(218, 9);
         this.portNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
         this.portNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.portNumericUpDown.Name = "portNumericUpDown";
         this.portNumericUpDown.Size = new System.Drawing.Size(77, 20);
         this.portNumericUpDown.TabIndex = 3;
         this.portNumericUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
         // 
         // fromLabel
         // 
         this.fromLabel.AutoSize = true;
         this.fromLabel.Location = new System.Drawing.Point(13, 89);
         this.fromLabel.Name = "fromLabel";
         this.fromLabel.Size = new System.Drawing.Size(33, 13);
         this.fromLabel.TabIndex = 8;
         this.fromLabel.Text = "From:";
         // 
         // toLabel
         // 
         this.toLabel.AutoSize = true;
         this.toLabel.Location = new System.Drawing.Point(13, 122);
         this.toLabel.Name = "toLabel";
         this.toLabel.Size = new System.Drawing.Size(23, 13);
         this.toLabel.TabIndex = 10;
         this.toLabel.Text = "To:";
         // 
         // subjectLabel
         // 
         this.subjectLabel.AutoSize = true;
         this.subjectLabel.Location = new System.Drawing.Point(13, 155);
         this.subjectLabel.Name = "subjectLabel";
         this.subjectLabel.Size = new System.Drawing.Size(46, 13);
         this.subjectLabel.TabIndex = 12;
         this.subjectLabel.Text = "Subject:";
         // 
         // fromTextBox
         // 
         this.fromTextBox.Location = new System.Drawing.Point(61, 85);
         this.fromTextBox.Name = "fromTextBox";
         this.fromTextBox.Size = new System.Drawing.Size(160, 20);
         this.fromTextBox.TabIndex = 9;
         // 
         // toTextBox
         // 
         this.toTextBox.Location = new System.Drawing.Point(61, 118);
         this.toTextBox.Name = "toTextBox";
         this.toTextBox.Size = new System.Drawing.Size(160, 20);
         this.toTextBox.TabIndex = 11;
         // 
         // subjectTextBox
         // 
         this.subjectTextBox.Location = new System.Drawing.Point(61, 151);
         this.subjectTextBox.Name = "subjectTextBox";
         this.subjectTextBox.Size = new System.Drawing.Size(160, 20);
         this.subjectTextBox.TabIndex = 13;
         // 
         // bodyTextBody
         // 
         this.bodyTextBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.bodyTextBody.Location = new System.Drawing.Point(16, 197);
         this.bodyTextBody.Multiline = true;
         this.bodyTextBody.Name = "bodyTextBody";
         this.bodyTextBody.Size = new System.Drawing.Size(517, 103);
         this.bodyTextBody.TabIndex = 15;
         // 
         // filesListView
         // 
         this.filesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.filesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileColumnHeader,
            this.sizeColumnHeader});
         this.filesListView.Location = new System.Drawing.Point(227, 76);
         this.filesListView.Name = "filesListView";
         this.filesListView.Size = new System.Drawing.Size(306, 97);
         this.filesListView.TabIndex = 17;
         this.filesListView.UseCompatibleStateImageBehavior = false;
         this.filesListView.View = System.Windows.Forms.View.Details;
         this.filesListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filesListView_OnKeyDown);
         // 
         // fileColumnHeader
         // 
         this.fileColumnHeader.Text = "File";
         this.fileColumnHeader.Width = 222;
         // 
         // sizeColumnHeader
         // 
         this.sizeColumnHeader.Text = "Size";
         // 
         // sendButton
         // 
         this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.sendButton.Location = new System.Drawing.Point(16, 308);
         this.sendButton.Name = "sendButton";
         this.sendButton.Size = new System.Drawing.Size(75, 23);
         this.sendButton.TabIndex = 18;
         this.sendButton.Text = "Send";
         this.sendButton.UseVisualStyleBackColor = true;
         this.sendButton.Click += new System.EventHandler(this.buttonSend_Click);
         // 
         // usernameLabel
         // 
         this.usernameLabel.AutoSize = true;
         this.usernameLabel.Location = new System.Drawing.Point(13, 46);
         this.usernameLabel.Name = "usernameLabel";
         this.usernameLabel.Size = new System.Drawing.Size(58, 13);
         this.usernameLabel.TabIndex = 4;
         this.usernameLabel.Text = "Username:";
         // 
         // usernameTextBox
         // 
         this.usernameTextBox.Location = new System.Drawing.Point(77, 42);
         this.usernameTextBox.Name = "usernameTextBox";
         this.usernameTextBox.Size = new System.Drawing.Size(100, 20);
         this.usernameTextBox.TabIndex = 5;
         // 
         // bodyLabel
         // 
         this.bodyLabel.AutoSize = true;
         this.bodyLabel.Location = new System.Drawing.Point(13, 178);
         this.bodyLabel.Name = "bodyLabel";
         this.bodyLabel.Size = new System.Drawing.Size(31, 13);
         this.bodyLabel.TabIndex = 14;
         this.bodyLabel.Text = "Body";
         // 
         // passwordLabel
         // 
         this.passwordLabel.AutoSize = true;
         this.passwordLabel.Location = new System.Drawing.Point(185, 46);
         this.passwordLabel.Name = "passwordLabel";
         this.passwordLabel.Size = new System.Drawing.Size(56, 13);
         this.passwordLabel.TabIndex = 6;
         this.passwordLabel.Text = "Password:";
         // 
         // passwordTextBox
         // 
         this.passwordTextBox.Location = new System.Drawing.Point(246, 42);
         this.passwordTextBox.Name = "passwordTextBox";
         this.passwordTextBox.PasswordChar = '*';
         this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
         this.passwordTextBox.TabIndex = 7;
         // 
         // attachFileButton
         // 
         this.attachFileButton.Location = new System.Drawing.Point(458, 41);
         this.attachFileButton.Name = "attachFileButton";
         this.attachFileButton.Size = new System.Drawing.Size(75, 23);
         this.attachFileButton.TabIndex = 16;
         this.attachFileButton.Text = "Attach File...";
         this.attachFileButton.UseVisualStyleBackColor = true;
         this.attachFileButton.Click += new System.EventHandler(this.buttonAttachFile_Click);
         // 
         // EmailClientForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(545, 343);
         this.Controls.Add(this.attachFileButton);
         this.Controls.Add(this.passwordTextBox);
         this.Controls.Add(this.passwordLabel);
         this.Controls.Add(this.bodyLabel);
         this.Controls.Add(this.usernameTextBox);
         this.Controls.Add(this.usernameLabel);
         this.Controls.Add(this.sendButton);
         this.Controls.Add(this.filesListView);
         this.Controls.Add(this.bodyTextBody);
         this.Controls.Add(this.subjectTextBox);
         this.Controls.Add(this.toTextBox);
         this.Controls.Add(this.fromTextBox);
         this.Controls.Add(this.subjectLabel);
         this.Controls.Add(this.toLabel);
         this.Controls.Add(this.fromLabel);
         this.Controls.Add(this.portNumericUpDown);
         this.Controls.Add(this.portLabel);
         this.Controls.Add(this.hostnameTextBox);
         this.Controls.Add(this.hostLabel);
         this.Name = "EmailClientForm";
         this.Text = "Email client";
         ((System.ComponentModel.ISupportInitialize)(this.portNumericUpDown)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.TextBox hostnameTextBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.NumericUpDown portNumericUpDown;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.TextBox fromTextBox;
        private System.Windows.Forms.TextBox toTextBox;
        private System.Windows.Forms.TextBox subjectTextBox;
        private System.Windows.Forms.TextBox bodyTextBody;
        private System.Windows.Forms.ListView filesListView;
        private System.Windows.Forms.ColumnHeader fileColumnHeader;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label bodyLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button attachFileButton;
        private System.Windows.Forms.ColumnHeader sizeColumnHeader;
    }
}


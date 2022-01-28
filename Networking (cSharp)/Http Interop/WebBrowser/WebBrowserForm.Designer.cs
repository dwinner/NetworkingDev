namespace WebBrowser
{
    partial class WebBrowserForm
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
         this.ieWebBrowser = new System.Windows.Forms.WebBrowser();
         this.urlTextBox = new System.Windows.Forms.TextBox();
         this.goButton = new System.Windows.Forms.Button();
         this.urlRadioButton = new System.Windows.Forms.RadioButton();
         this.htmlRadioButton = new System.Windows.Forms.RadioButton();
         this.htmlTextBox = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // ieWebBrowser
         // 
         this.ieWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.ieWebBrowser.Location = new System.Drawing.Point(12, 63);
         this.ieWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
         this.ieWebBrowser.Name = "ieWebBrowser";
         this.ieWebBrowser.Size = new System.Drawing.Size(659, 332);
         this.ieWebBrowser.TabIndex = 0;
         // 
         // urlTextBox
         // 
         this.urlTextBox.Location = new System.Drawing.Point(78, 9);
         this.urlTextBox.Name = "urlTextBox";
         this.urlTextBox.Size = new System.Drawing.Size(514, 20);
         this.urlTextBox.TabIndex = 2;
         this.urlTextBox.Text = "http://www.bing.com";
         // 
         // goButton
         // 
         this.goButton.Location = new System.Drawing.Point(598, 9);
         this.goButton.Name = "goButton";
         this.goButton.Size = new System.Drawing.Size(73, 45);
         this.goButton.TabIndex = 3;
         this.goButton.Text = "&Go";
         this.goButton.UseVisualStyleBackColor = true;
         this.goButton.Click += new System.EventHandler(this.goButton_Click);
         // 
         // urlRadioButton
         // 
         this.urlRadioButton.AutoSize = true;
         this.urlRadioButton.Checked = true;
         this.urlRadioButton.Location = new System.Drawing.Point(13, 13);
         this.urlRadioButton.Name = "urlRadioButton";
         this.urlRadioButton.Size = new System.Drawing.Size(47, 17);
         this.urlRadioButton.TabIndex = 4;
         this.urlRadioButton.TabStop = true;
         this.urlRadioButton.Text = "URL";
         this.urlRadioButton.UseVisualStyleBackColor = true;
         this.urlRadioButton.CheckedChanged += new System.EventHandler(this.OnRadioCheckedChanged);
         // 
         // htmlRadioButton
         // 
         this.htmlRadioButton.AutoSize = true;
         this.htmlRadioButton.Location = new System.Drawing.Point(13, 37);
         this.htmlRadioButton.Name = "htmlRadioButton";
         this.htmlRadioButton.Size = new System.Drawing.Size(55, 17);
         this.htmlRadioButton.TabIndex = 5;
         this.htmlRadioButton.TabStop = true;
         this.htmlRadioButton.Text = "HTML";
         this.htmlRadioButton.UseVisualStyleBackColor = true;
         this.htmlRadioButton.CheckedChanged += new System.EventHandler(this.OnRadioCheckedChanged);
         // 
         // htmlTextBox
         // 
         this.htmlTextBox.Enabled = false;
         this.htmlTextBox.Location = new System.Drawing.Point(78, 37);
         this.htmlTextBox.Name = "htmlTextBox";
         this.htmlTextBox.Size = new System.Drawing.Size(514, 20);
         this.htmlTextBox.TabIndex = 6;
         this.htmlTextBox.Text = "<b>An example</b>with<i>HTML</i>";
         // 
         // WebBrowserForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(683, 407);
         this.Controls.Add(this.htmlTextBox);
         this.Controls.Add(this.htmlRadioButton);
         this.Controls.Add(this.urlRadioButton);
         this.Controls.Add(this.goButton);
         this.Controls.Add(this.urlTextBox);
         this.Controls.Add(this.ieWebBrowser);
         this.Name = "WebBrowserForm";
         this.Text = "My Web Browser";
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser ieWebBrowser;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.RadioButton urlRadioButton;
        private System.Windows.Forms.RadioButton htmlRadioButton;
        private System.Windows.Forms.TextBox htmlTextBox;
    }
}


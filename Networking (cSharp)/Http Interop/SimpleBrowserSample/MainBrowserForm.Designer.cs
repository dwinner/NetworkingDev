namespace SimpleBrowserSample
{
   partial class BrowserForm
   {
      /// <summary>
      /// Требуется переменная конструктора.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Освободить все используемые ресурсы.
      /// </summary>
      /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Код, автоматически созданный конструктором форм Windows

      /// <summary>
      /// Обязательный метод для поддержки конструктора - не изменяйте
      /// содержимое данного метода при помощи редактора кода.
      /// </summary>
      private void InitializeComponent()
      {
         this.InputUriTextBox = new System.Windows.Forms.TextBox();
         this.WebBrowser = new System.Windows.Forms.WebBrowser();
         this.EnterUriLabel = new System.Windows.Forms.Label();
         this.ContactLinkLabel = new System.Windows.Forms.LinkLabel();
         this.BackButton = new System.Windows.Forms.Button();
         this.ForwardButton = new System.Windows.Forms.Button();
         this.StopButton = new System.Windows.Forms.Button();
         this.HomeButton = new System.Windows.Forms.Button();
         this.RefreshButton = new System.Windows.Forms.Button();
         this.GoButton = new System.Windows.Forms.Button();
         this.PrintButton = new System.Windows.Forms.Button();
         this.PageSourceTextBox = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // InputUriTextBox
         // 
         this.InputUriTextBox.Location = new System.Drawing.Point(84, 48);
         this.InputUriTextBox.Name = "InputUriTextBox";
         this.InputUriTextBox.Size = new System.Drawing.Size(516, 20);
         this.InputUriTextBox.TabIndex = 0;
         this.InputUriTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputUriTextBox_KeyPress);
         // 
         // WebBrowser
         // 
         this.WebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.WebBrowser.Location = new System.Drawing.Point(12, 74);
         this.WebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
         this.WebBrowser.Name = "WebBrowser";
         this.WebBrowser.Size = new System.Drawing.Size(798, 216);
         this.WebBrowser.TabIndex = 1;
         this.WebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser_DocumentCompleted);
         this.WebBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.WebBrowser_Navigated);
         this.WebBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.WebBrowser_Navigating);
         // 
         // EnterUriLabel
         // 
         this.EnterUriLabel.AutoSize = true;
         this.EnterUriLabel.Location = new System.Drawing.Point(21, 55);
         this.EnterUriLabel.Name = "EnterUriLabel";
         this.EnterUriLabel.Size = new System.Drawing.Size(57, 13);
         this.EnterUriLabel.TabIndex = 2;
         this.EnterUriLabel.Text = "Enter URI:";
         // 
         // ContactLinkLabel
         // 
         this.ContactLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.ContactLinkLabel.AutoSize = true;
         this.ContactLinkLabel.Location = new System.Drawing.Point(755, 2);
         this.ContactLinkLabel.Name = "ContactLinkLabel";
         this.ContactLinkLabel.Size = new System.Drawing.Size(62, 13);
         this.ContactLinkLabel.TabIndex = 3;
         this.ContactLinkLabel.TabStop = true;
         this.ContactLinkLabel.Text = "Contact Me";
         this.ContactLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ContactLinkLabel_LinkClicked);
         // 
         // BackButton
         // 
         this.BackButton.Location = new System.Drawing.Point(24, 12);
         this.BackButton.Name = "BackButton";
         this.BackButton.Size = new System.Drawing.Size(75, 23);
         this.BackButton.TabIndex = 4;
         this.BackButton.Text = "Back";
         this.BackButton.UseVisualStyleBackColor = true;
         this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
         // 
         // ForwardButton
         // 
         this.ForwardButton.Location = new System.Drawing.Point(122, 12);
         this.ForwardButton.Name = "ForwardButton";
         this.ForwardButton.Size = new System.Drawing.Size(75, 23);
         this.ForwardButton.TabIndex = 5;
         this.ForwardButton.Text = "Forward";
         this.ForwardButton.UseVisualStyleBackColor = true;
         this.ForwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
         // 
         // StopButton
         // 
         this.StopButton.Location = new System.Drawing.Point(222, 12);
         this.StopButton.Name = "StopButton";
         this.StopButton.Size = new System.Drawing.Size(75, 23);
         this.StopButton.TabIndex = 6;
         this.StopButton.Text = "Stop";
         this.StopButton.UseVisualStyleBackColor = true;
         this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
         // 
         // HomeButton
         // 
         this.HomeButton.Location = new System.Drawing.Point(322, 12);
         this.HomeButton.Name = "HomeButton";
         this.HomeButton.Size = new System.Drawing.Size(75, 23);
         this.HomeButton.TabIndex = 7;
         this.HomeButton.Text = "Home";
         this.HomeButton.UseVisualStyleBackColor = true;
         this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
         // 
         // RefreshButton
         // 
         this.RefreshButton.Location = new System.Drawing.Point(421, 12);
         this.RefreshButton.Name = "RefreshButton";
         this.RefreshButton.Size = new System.Drawing.Size(75, 23);
         this.RefreshButton.TabIndex = 8;
         this.RefreshButton.Text = "Refresh";
         this.RefreshButton.UseVisualStyleBackColor = true;
         this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
         // 
         // GoButton
         // 
         this.GoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
         this.GoButton.Location = new System.Drawing.Point(628, 12);
         this.GoButton.Name = "GoButton";
         this.GoButton.Size = new System.Drawing.Size(75, 56);
         this.GoButton.TabIndex = 9;
         this.GoButton.Text = "Go";
         this.GoButton.UseVisualStyleBackColor = true;
         this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
         // 
         // PrintButton
         // 
         this.PrintButton.Location = new System.Drawing.Point(525, 12);
         this.PrintButton.Name = "PrintButton";
         this.PrintButton.Size = new System.Drawing.Size(75, 23);
         this.PrintButton.TabIndex = 10;
         this.PrintButton.Text = "Print";
         this.PrintButton.UseVisualStyleBackColor = true;
         this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
         // 
         // PageSourceTextBox
         // 
         this.PageSourceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.PageSourceTextBox.Location = new System.Drawing.Point(12, 296);
         this.PageSourceTextBox.Multiline = true;
         this.PageSourceTextBox.Name = "PageSourceTextBox";
         this.PageSourceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.PageSourceTextBox.Size = new System.Drawing.Size(798, 107);
         this.PageSourceTextBox.TabIndex = 11;
         // 
         // BrowserForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(822, 415);
         this.Controls.Add(this.PageSourceTextBox);
         this.Controls.Add(this.PrintButton);
         this.Controls.Add(this.GoButton);
         this.Controls.Add(this.RefreshButton);
         this.Controls.Add(this.HomeButton);
         this.Controls.Add(this.StopButton);
         this.Controls.Add(this.ForwardButton);
         this.Controls.Add(this.BackButton);
         this.Controls.Add(this.ContactLinkLabel);
         this.Controls.Add(this.EnterUriLabel);
         this.Controls.Add(this.WebBrowser);
         this.Controls.Add(this.InputUriTextBox);
         this.Name = "BrowserForm";
         this.Text = "Simple browser";
         this.Load += new System.EventHandler(this.BrowserForm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox InputUriTextBox;
      private System.Windows.Forms.WebBrowser WebBrowser;
      private System.Windows.Forms.Label EnterUriLabel;
      private System.Windows.Forms.LinkLabel ContactLinkLabel;
      private System.Windows.Forms.Button BackButton;
      private System.Windows.Forms.Button ForwardButton;
      private System.Windows.Forms.Button StopButton;
      private System.Windows.Forms.Button HomeButton;
      private System.Windows.Forms.Button RefreshButton;
      private System.Windows.Forms.Button GoButton;
      private System.Windows.Forms.Button PrintButton;
      private System.Windows.Forms.TextBox PageSourceTextBox;
   }
}


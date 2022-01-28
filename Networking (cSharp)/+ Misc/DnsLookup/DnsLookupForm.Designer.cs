namespace DnsLookup
{
   partial class DnsLookupForm
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
         this.ResolveNameLabel = new System.Windows.Forms.Label();
         this.DnsInputTextBox = new System.Windows.Forms.TextBox();
         this.ResolveButton = new System.Windows.Forms.Button();
         this.HostNameLabel = new System.Windows.Forms.Label();
         this.HostNameTextBox = new System.Windows.Forms.TextBox();
         this.IpAddressesLabel = new System.Windows.Forms.Label();
         this.IpAddressesListBox = new System.Windows.Forms.ListBox();
         this.SuspendLayout();
         // 
         // ResolveNameLabel
         // 
         this.ResolveNameLabel.AutoSize = true;
         this.ResolveNameLabel.Location = new System.Drawing.Point(13, 13);
         this.ResolveNameLabel.Name = "ResolveNameLabel";
         this.ResolveNameLabel.Size = new System.Drawing.Size(88, 13);
         this.ResolveNameLabel.TabIndex = 0;
         this.ResolveNameLabel.Text = "DNS To Resolve";
         // 
         // DnsInputTextBox
         // 
         this.DnsInputTextBox.Location = new System.Drawing.Point(107, 10);
         this.DnsInputTextBox.Name = "DnsInputTextBox";
         this.DnsInputTextBox.Size = new System.Drawing.Size(152, 20);
         this.DnsInputTextBox.TabIndex = 1;
         // 
         // ResolveButton
         // 
         this.ResolveButton.Location = new System.Drawing.Point(265, 8);
         this.ResolveButton.Name = "ResolveButton";
         this.ResolveButton.Size = new System.Drawing.Size(101, 23);
         this.ResolveButton.TabIndex = 2;
         this.ResolveButton.Text = "Resolve";
         this.ResolveButton.UseVisualStyleBackColor = true;
         this.ResolveButton.Click += new System.EventHandler(this.ResolveButton_Click);
         // 
         // HostNameLabel
         // 
         this.HostNameLabel.AutoSize = true;
         this.HostNameLabel.Location = new System.Drawing.Point(16, 52);
         this.HostNameLabel.Name = "HostNameLabel";
         this.HostNameLabel.Size = new System.Drawing.Size(58, 13);
         this.HostNameLabel.TabIndex = 3;
         this.HostNameLabel.Text = "Host name";
         // 
         // HostNameTextBox
         // 
         this.HostNameTextBox.Location = new System.Drawing.Point(107, 49);
         this.HostNameTextBox.Name = "HostNameTextBox";
         this.HostNameTextBox.Size = new System.Drawing.Size(152, 20);
         this.HostNameTextBox.TabIndex = 4;
         // 
         // IpAddressesLabel
         // 
         this.IpAddressesLabel.AutoSize = true;
         this.IpAddressesLabel.Location = new System.Drawing.Point(16, 97);
         this.IpAddressesLabel.Name = "IpAddressesLabel";
         this.IpAddressesLabel.Size = new System.Drawing.Size(68, 13);
         this.IpAddressesLabel.TabIndex = 5;
         this.IpAddressesLabel.Text = "IP addresses";
         // 
         // IpAddressesListBox
         // 
         this.IpAddressesListBox.FormattingEnabled = true;
         this.IpAddressesListBox.Location = new System.Drawing.Point(107, 97);
         this.IpAddressesListBox.Name = "IpAddressesListBox";
         this.IpAddressesListBox.Size = new System.Drawing.Size(259, 160);
         this.IpAddressesListBox.TabIndex = 6;
         // 
         // DnsLookupForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(460, 261);
         this.Controls.Add(this.IpAddressesListBox);
         this.Controls.Add(this.IpAddressesLabel);
         this.Controls.Add(this.HostNameTextBox);
         this.Controls.Add(this.HostNameLabel);
         this.Controls.Add(this.ResolveButton);
         this.Controls.Add(this.DnsInputTextBox);
         this.Controls.Add(this.ResolveNameLabel);
         this.Name = "DnsLookupForm";
         this.Text = "Dns lookup";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label ResolveNameLabel;
      private System.Windows.Forms.TextBox DnsInputTextBox;
      private System.Windows.Forms.Button ResolveButton;
      private System.Windows.Forms.Label HostNameLabel;
      private System.Windows.Forms.TextBox HostNameTextBox;
      private System.Windows.Forms.Label IpAddressesLabel;
      private System.Windows.Forms.ListBox IpAddressesListBox;
   }
}


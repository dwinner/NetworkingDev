namespace TcpSend
{
   partial class TcpSendForm
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
         this.HostLabel = new System.Windows.Forms.Label();
         this.HostnameTextBox = new System.Windows.Forms.TextBox();
         this.PortLabel = new System.Windows.Forms.Label();
         this.PortTextBox = new System.Windows.Forms.TextBox();
         this.SendButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // HostLabel
         // 
         this.HostLabel.AutoSize = true;
         this.HostLabel.Location = new System.Drawing.Point(13, 13);
         this.HostLabel.Name = "HostLabel";
         this.HostLabel.Size = new System.Drawing.Size(55, 13);
         this.HostLabel.TabIndex = 0;
         this.HostLabel.Text = "Hostname";
         // 
         // HostnameTextBox
         // 
         this.HostnameTextBox.Location = new System.Drawing.Point(74, 13);
         this.HostnameTextBox.Name = "HostnameTextBox";
         this.HostnameTextBox.Size = new System.Drawing.Size(198, 20);
         this.HostnameTextBox.TabIndex = 1;
         // 
         // PortLabel
         // 
         this.PortLabel.AutoSize = true;
         this.PortLabel.Location = new System.Drawing.Point(16, 54);
         this.PortLabel.Name = "PortLabel";
         this.PortLabel.Size = new System.Drawing.Size(26, 13);
         this.PortLabel.TabIndex = 2;
         this.PortLabel.Text = "Port";
         // 
         // PortTextBox
         // 
         this.PortTextBox.Location = new System.Drawing.Point(74, 54);
         this.PortTextBox.Name = "PortTextBox";
         this.PortTextBox.Size = new System.Drawing.Size(198, 20);
         this.PortTextBox.TabIndex = 3;
         // 
         // SendButton
         // 
         this.SendButton.Location = new System.Drawing.Point(196, 81);
         this.SendButton.Name = "SendButton";
         this.SendButton.Size = new System.Drawing.Size(75, 23);
         this.SendButton.TabIndex = 4;
         this.SendButton.Text = "Send";
         this.SendButton.UseVisualStyleBackColor = true;
         this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
         // 
         // TcpSendForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 261);
         this.Controls.Add(this.SendButton);
         this.Controls.Add(this.PortTextBox);
         this.Controls.Add(this.PortLabel);
         this.Controls.Add(this.HostnameTextBox);
         this.Controls.Add(this.HostLabel);
         this.Name = "TcpSendForm";
         this.Text = "TCP Client";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label HostLabel;
      private System.Windows.Forms.TextBox HostnameTextBox;
      private System.Windows.Forms.Label PortLabel;
      private System.Windows.Forms.TextBox PortTextBox;
      private System.Windows.Forms.Button SendButton;
   }
}


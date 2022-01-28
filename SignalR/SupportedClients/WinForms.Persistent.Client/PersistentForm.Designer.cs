namespace WinForms.Persistent.Client
{
   partial class PersistentForm
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
         this.UserTextBox = new System.Windows.Forms.TextBox();
         this.MessageTextBox = new System.Windows.Forms.TextBox();
         this.SendButton = new System.Windows.Forms.Button();
         this.MessageListBox = new System.Windows.Forms.ListBox();
         this.SuspendLayout();
         // 
         // UserTextBox
         // 
         this.UserTextBox.Location = new System.Drawing.Point(12, 12);
         this.UserTextBox.Name = "UserTextBox";
         this.UserTextBox.Size = new System.Drawing.Size(100, 20);
         this.UserTextBox.TabIndex = 0;
         // 
         // MessageTextBox
         // 
         this.MessageTextBox.Location = new System.Drawing.Point(118, 12);
         this.MessageTextBox.Name = "MessageTextBox";
         this.MessageTextBox.Size = new System.Drawing.Size(100, 20);
         this.MessageTextBox.TabIndex = 1;
         // 
         // SendButton
         // 
         this.SendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.SendButton.Location = new System.Drawing.Point(296, 10);
         this.SendButton.Name = "SendButton";
         this.SendButton.Size = new System.Drawing.Size(75, 23);
         this.SendButton.TabIndex = 2;
         this.SendButton.Text = "Send";
         this.SendButton.UseVisualStyleBackColor = true;
         this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
         // 
         // MessageListBox
         // 
         this.MessageListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.MessageListBox.FormattingEnabled = true;
         this.MessageListBox.Location = new System.Drawing.Point(12, 50);
         this.MessageListBox.Name = "MessageListBox";
         this.MessageListBox.Size = new System.Drawing.Size(359, 199);
         this.MessageListBox.TabIndex = 3;
         // 
         // PersistentForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(383, 261);
         this.Controls.Add(this.MessageListBox);
         this.Controls.Add(this.SendButton);
         this.Controls.Add(this.MessageTextBox);
         this.Controls.Add(this.UserTextBox);
         this.Name = "PersistentForm";
         this.Text = "Persistent client";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox UserTextBox;
      private System.Windows.Forms.TextBox MessageTextBox;
      private System.Windows.Forms.Button SendButton;
      private System.Windows.Forms.ListBox MessageListBox;
   }
}


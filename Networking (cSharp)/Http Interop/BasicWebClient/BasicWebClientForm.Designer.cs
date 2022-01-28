namespace BasicWebClient
{
   partial class BasicWebClientForm
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
         this.WebContentListBox = new System.Windows.Forms.ListBox();
         this.SuspendLayout();
         // 
         // WebContentListBox
         // 
         this.WebContentListBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this.WebContentListBox.FormattingEnabled = true;
         this.WebContentListBox.Location = new System.Drawing.Point(0, 0);
         this.WebContentListBox.Name = "WebContentListBox";
         this.WebContentListBox.Size = new System.Drawing.Size(284, 261);
         this.WebContentListBox.TabIndex = 0;
         // 
         // BasicWebClientForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 261);
         this.Controls.Add(this.WebContentListBox);
         this.Name = "BasicWebClientForm";
         this.Text = "Web client form";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ListBox WebContentListBox;
   }
}


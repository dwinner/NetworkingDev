namespace ViewHeaders
{
   partial class ViewHeadersForm
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
         this.ViewHeadersListBox = new System.Windows.Forms.ListBox();
         this.SuspendLayout();
         // 
         // ViewHeadersListBox
         // 
         this.ViewHeadersListBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ViewHeadersListBox.FormattingEnabled = true;
         this.ViewHeadersListBox.Location = new System.Drawing.Point(0, 0);
         this.ViewHeadersListBox.Name = "ViewHeadersListBox";
         this.ViewHeadersListBox.Size = new System.Drawing.Size(284, 261);
         this.ViewHeadersListBox.TabIndex = 0;
         // 
         // ViewHeadersForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 261);
         this.Controls.Add(this.ViewHeadersListBox);
         this.Name = "ViewHeadersForm";
         this.Text = "View Headers";
         this.Load += new System.EventHandler(this.ViewHeadersFormOnLoad);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ListBox ViewHeadersListBox;
   }
}


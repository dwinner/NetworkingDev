namespace TcpReceive
{
   partial class TcpReceiveForm
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
         this.IncomingTextBox = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // IncomingTextBox
         // 
         this.IncomingTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this.IncomingTextBox.Location = new System.Drawing.Point(0, 0);
         this.IncomingTextBox.Multiline = true;
         this.IncomingTextBox.Name = "IncomingTextBox";
         this.IncomingTextBox.Size = new System.Drawing.Size(284, 261);
         this.IncomingTextBox.TabIndex = 0;
         // 
         // TcpReceiveForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 261);
         this.Controls.Add(this.IncomingTextBox);
         this.Name = "TcpReceiveForm";
         this.Text = "TCP Server";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox IncomingTextBox;
   }
}


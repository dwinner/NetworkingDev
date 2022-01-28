namespace FromEventPatternSample
{
   partial class RxForm
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
         this.BisectorLabel = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // BisectorLabel
         // 
         this.BisectorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.BisectorLabel.AutoSize = true;
         this.BisectorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.BisectorLabel.Location = new System.Drawing.Point(79, 98);
         this.BisectorLabel.Name = "BisectorLabel";
         this.BisectorLabel.Size = new System.Drawing.Size(82, 25);
         this.BisectorLabel.TabIndex = 0;
         this.BisectorLabel.Text = "Bisector";
         // 
         // RxForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 261);
         this.Controls.Add(this.BisectorLabel);
         this.Name = "RxForm";
         this.Text = "RxForm";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label BisectorLabel;
   }
}


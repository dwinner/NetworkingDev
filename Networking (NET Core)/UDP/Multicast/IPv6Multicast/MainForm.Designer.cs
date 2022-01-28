namespace IPv6Multicast {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.chb = new System.Windows.Forms.CheckBox();
            this.bwReceive = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // chb
            // 
            this.chb.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb.AutoCheck = false;
            this.chb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chb.Location = new System.Drawing.Point(0, 0);
            this.chb.Name = "chb";
            this.chb.Size = new System.Drawing.Size(282, 255);
            this.chb.TabIndex = 0;
            this.chb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb.UseVisualStyleBackColor = true;
            this.chb.CheckedChanged += new System.EventHandler(this.chb_CheckedChanged);
            this.chb.Click += new System.EventHandler(this.chb_Click);
            // 
            // bwReceive
            // 
            this.bwReceive.WorkerReportsProgress = true;
            this.bwReceive.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwReceive_DoWork);
            this.bwReceive.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwReceive_ProgressChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this.chb);
            this.Name = "MainForm";
            this.Text = "Multicast";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chb;
        private System.ComponentModel.BackgroundWorker bwReceive;

    }
}


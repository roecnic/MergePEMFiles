namespace MergePEMFiles {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
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
        private void InitializeComponent () {
            this.rtbxLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbxLog
            // 
            this.rtbxLog.Location = new System.Drawing.Point(13, 13);
            this.rtbxLog.Name = "rtbxLog";
            this.rtbxLog.Size = new System.Drawing.Size(259, 236);
            this.rtbxLog.TabIndex = 0;
            this.rtbxLog.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.rtbxLog);
            this.Name = "Form1";
            this.Text = "Merge PEM Files";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbxLog;
    }
}


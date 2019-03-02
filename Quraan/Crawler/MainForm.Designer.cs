namespace Crawler
{
    partial class MainForm
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
            this.btnDownloadQuraan = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progress = new System.Windows.Forms.ToolStripProgressBar();
            this.btnTafseer = new System.Windows.Forms.Button();
            this.btnMp3 = new System.Windows.Forms.Button();
            this.btnDownloadBooks = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDownloadQuraan
            // 
            this.btnDownloadQuraan.Location = new System.Drawing.Point(181, 51);
            this.btnDownloadQuraan.Name = "btnDownloadQuraan";
            this.btnDownloadQuraan.Size = new System.Drawing.Size(147, 23);
            this.btnDownloadQuraan.TabIndex = 0;
            this.btnDownloadQuraan.Text = "Download Quran";
            this.btnDownloadQuraan.UseVisualStyleBackColor = true;
            this.btnDownloadQuraan.Click += new System.EventHandler(this.btnDownloadQuraan_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.progress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(626, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Ready";
            // 
            // progress
            // 
            this.progress.Margin = new System.Windows.Forms.Padding(50, 3, 1, 3);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(100, 16);
            // 
            // btnTafseer
            // 
            this.btnTafseer.Location = new System.Drawing.Point(181, 111);
            this.btnTafseer.Name = "btnTafseer";
            this.btnTafseer.Size = new System.Drawing.Size(147, 23);
            this.btnTafseer.TabIndex = 2;
            this.btnTafseer.Text = "Download tafseer";
            this.btnTafseer.UseVisualStyleBackColor = true;
            this.btnTafseer.Click += new System.EventHandler(this.btnTafseer_Click);
            // 
            // btnMp3
            // 
            this.btnMp3.Location = new System.Drawing.Point(181, 174);
            this.btnMp3.Name = "btnMp3";
            this.btnMp3.Size = new System.Drawing.Size(147, 23);
            this.btnMp3.TabIndex = 3;
            this.btnMp3.Text = "Download mp3";
            this.btnMp3.UseVisualStyleBackColor = true;
            this.btnMp3.Click += new System.EventHandler(this.btnMp3_Click);
            // 
            // btnDownloadBooks
            // 
            this.btnDownloadBooks.Location = new System.Drawing.Point(181, 225);
            this.btnDownloadBooks.Name = "btnDownloadBooks";
            this.btnDownloadBooks.Size = new System.Drawing.Size(147, 23);
            this.btnDownloadBooks.TabIndex = 4;
            this.btnDownloadBooks.Text = "Download Quran Books";
            this.btnDownloadBooks.UseVisualStyleBackColor = true;
            this.btnDownloadBooks.Click += new System.EventHandler(this.btnDownloadBooks_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 450);
            this.Controls.Add(this.btnDownloadBooks);
            this.Controls.Add(this.btnMp3);
            this.Controls.Add(this.btnTafseer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnDownloadQuraan);
            this.Name = "MainForm";
            this.Text = "Quran Crawler";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDownloadQuraan;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar progress;
        private System.Windows.Forms.Button btnTafseer;
        private System.Windows.Forms.Button btnMp3;
        private System.Windows.Forms.Button btnDownloadBooks;
    }
}


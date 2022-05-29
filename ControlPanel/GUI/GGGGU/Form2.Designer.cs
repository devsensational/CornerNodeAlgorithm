using System.ComponentModel;

namespace GGGGU
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.Retry = new System.Windows.Forms.Button();
            this.FilePath = new System.Windows.Forms.Label();
            this.CreateMap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(43, 61);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(546, 383);
            this.pictureBox.TabIndex = 8;
            this.pictureBox.TabStop = false;
            // 
            // Retry
            // 
            this.Retry.Location = new System.Drawing.Point(43, 12);
            this.Retry.Name = "Retry";
            this.Retry.Size = new System.Drawing.Size(143, 32);
            this.Retry.TabIndex = 9;
            this.Retry.Text = "다시 선택";
            this.Retry.UseVisualStyleBackColor = true;
            this.Retry.Click += new System.EventHandler(this.Retry_Click);
            // 
            // FilePath
            // 
            this.FilePath.Location = new System.Drawing.Point(199, 12);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(389, 31);
            this.FilePath.TabIndex = 10;
            this.FilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CreateMap
            // 
            this.CreateMap.Location = new System.Drawing.Point(611, 218);
            this.CreateMap.Name = "CreateMap";
            this.CreateMap.Size = new System.Drawing.Size(137, 49);
            this.CreateMap.TabIndex = 11;
            this.CreateMap.Text = "맵 데이터 생성";
            this.CreateMap.UseVisualStyleBackColor = true;
            this.CreateMap.Click += new System.EventHandler(this.CreateMap_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 456);
            this.Controls.Add(this.CreateMap);
            this.Controls.Add(this.FilePath);
            this.Controls.Add(this.Retry);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button CreateMap;

        private System.Windows.Forms.Label FilePath;

        private System.Windows.Forms.Button Retry;

        private System.Windows.Forms.PictureBox pictureBox;

        #endregion
    }
}
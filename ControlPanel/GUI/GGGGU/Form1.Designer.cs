namespace GGGGU
{
	partial class Form1
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Setting = new System.Windows.Forms.Button();
			this.Exit = new System.Windows.Forms.Button();
			this.listBox = new System.Windows.Forms.ListBox();
			this.Upload = new System.Windows.Forms.Button();
			this.CreateMap = new System.Windows.Forms.Button();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// Setting
			// 
			this.Setting.Location = new System.Drawing.Point(617, 340);
			this.Setting.Name = "Setting";
			this.Setting.Size = new System.Drawing.Size(159, 34);
			this.Setting.TabIndex = 1;
			this.Setting.Text = "설정";
			this.Setting.UseVisualStyleBackColor = true;
			// 
			// Exit
			// 
			this.Exit.Location = new System.Drawing.Point(618, 380);
			this.Exit.Name = "Exit";
			this.Exit.Size = new System.Drawing.Size(159, 34);
			this.Exit.TabIndex = 2;
			this.Exit.Text = "나가기";
			this.Exit.UseVisualStyleBackColor = true;
			this.Exit.Click += new System.EventHandler(this.Exit_Click);
			// 
			// listBox
			// 
			this.listBox.FormattingEnabled = true;
			this.listBox.ItemHeight = 12;
			this.listBox.Location = new System.Drawing.Point(618, 30);
			this.listBox.Name = "listBox";
			this.listBox.Size = new System.Drawing.Size(158, 208);
			this.listBox.TabIndex = 4;
			this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// Upload
			// 
			this.Upload.Location = new System.Drawing.Point(618, 260);
			this.Upload.Name = "Upload";
			this.Upload.Size = new System.Drawing.Size(159, 34);
			this.Upload.TabIndex = 6;
			this.Upload.Text = "맵 데이터 생성";
			this.Upload.UseVisualStyleBackColor = true;
			this.Upload.Click += new System.EventHandler(this.CreateData_Click);
			// 
			// CreateMap
			// 
			this.CreateMap.Location = new System.Drawing.Point(618, 300);
			this.CreateMap.Name = "CreateMap";
			this.CreateMap.Size = new System.Drawing.Size(159, 34);
			this.CreateMap.TabIndex = 7;
			this.CreateMap.Text = "공유 파일 설정";
			this.CreateMap.UseVisualStyleBackColor = true;
			this.CreateMap.Click += new System.EventHandler(this.SetShared_Click);
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(43, 30);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(546, 383);
			this.pictureBox.TabIndex = 8;
			this.pictureBox.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.CreateMap);
			this.Controls.Add(this.Upload);
			this.Controls.Add(this.listBox);
			this.Controls.Add(this.Exit);
			this.Controls.Add(this.Setting);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
		}

		#endregion
		private System.Windows.Forms.Button Setting;
		private System.Windows.Forms.Button Exit;
		private System.Windows.Forms.ListBox listBox;
		private System.Windows.Forms.Button Upload;
		private System.Windows.Forms.Button CreateMap;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.PictureBox pictureBox;
	}
}


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
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.Setting = new System.Windows.Forms.Button();
			this.Exit = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
			this.Setting.Click += new System.EventHandler(this.button2_Click);
			// 
			// Exit
			// 
			this.Exit.Location = new System.Drawing.Point(618, 380);
			this.Exit.Name = "Exit";
			this.Exit.Size = new System.Drawing.Size(159, 34);
			this.Exit.TabIndex = 2;
			this.Exit.Text = "나가기";
			this.Exit.UseVisualStyleBackColor = true;
			this.Exit.Click += new System.EventHandler(this.button3_Click);
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 12;
			this.listBox1.Location = new System.Drawing.Point(618, 30);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(158, 208);
			this.listBox1.TabIndex = 4;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(618, 260);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(159, 34);
			this.button2.TabIndex = 6;
			this.button2.Text = "사진 업로드";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click_1);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(618, 300);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(159, 34);
			this.button1.TabIndex = 7;
			this.button1.Text = "맵 데이터 생성";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(43, 30);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(546, 383);
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.Exit);
			this.Controls.Add(this.Setting);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button Setting;
		private System.Windows.Forms.Button Exit;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}


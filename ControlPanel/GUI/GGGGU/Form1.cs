using System;
using System.Windows.Forms;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;
using test150x;
using OpenCvSharp;
using System.Drawing;
using System.Net;
using System.Net.Http;
using Image = System.Drawing.Image;

namespace GGGGU
{
	public partial class Form1 : Form
	{
		Bitmap bitmap;
		public Form1()
		{
			InitializeComponent();
			ResetListBox();
		}
        
        private void ResetListBox()
        {
	        var ml = ServerAPI.ShowMapList();
	        listBox.Items.Clear();
	        foreach (var index in ml)
	        {
		        listBox.Items.Add(index.Original);
	        }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
	        string someUrl = ServerAPI.hostIP + "/file/view/" + ServerAPI.getOneImg(listBox.SelectedIndex);
	        Image img = Image.FromStream(WebRequest.Create(someUrl).GetResponse().GetResponseStream());
	        Bitmap b = new Bitmap(WebRequest.Create(someUrl).GetResponse().GetResponseStream() );
	        pictureBox.Image = img;
	        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
	        // WebClient cl = new WebClient();
	        // Stream stream = cl.OpenRead(ServerAPI.hostIP + "/file/img/" + ServerAPI.getOneMap(listBox.SelectedIndex));
	        // MessageBox.Show(stream.ToString());
	        // bitmap = Bitmap.FromStream(stream) as Bitmap;

	        // stream.Close();
	        // cl.Dispose();





	        // WebClient Downloader = new WebClient();
	        // Stream ImageStream = Downloader.OpenRead(ServerAPI.hostIP + "/file/img/" + ServerAPI.getOneMap(listBox.SelectedIndex));
	        // Bitmap DownloadImage = Bitmap.FromStream(ImageStream) as Bitmap;
	        //bitmap = new Bitmap(ServerAPI.hostIP + "/file/img/" + ServerAPI.getOneMap(listBox.SelectedIndex));
	        // 이미지 출력
	        //pictureBox.ImageLocation = ServerAPI.hostIP + "/file/img/" + ServerAPI.getOneMap(listBox.SelectedIndex);
        }

		private void Exit_Click(object sender, EventArgs e) //나가기 버튼
		{
			Environment.Exit(0);
		}

		private void SetShared_Click(object sender, EventArgs e) //공유 설정 버튼
		{
			ServerAPI.SetDownloadFile(ServerAPI.getOneMap(listBox.SelectedIndex));
		}

		private void CreateData_Click(object sender, EventArgs e) //맵 데이터 생성 버튼
		{
			OpenFileDialog openFile = new OpenFileDialog();
			openFile.DefaultExt = "png";
			openFile.Filter = "Graphics interchange Format (*.png)|*.png|All files(*.*)|*.*";

			DialogResult dr = openFile.ShowDialog();
			if (dr == DialogResult.OK)
			{
				Form frm = new Form2(openFile.FileName);
				frm.ShowDialog();
				ResetListBox();
			}
		}
	}
}

using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Tekidoni
{
	public partial class HelpForm : Form
	{
		public HelpForm()
		{
			InitializeComponent();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			linkLabel1.LinkVisited = true;
			Process.Start("http://com.nicovideo.jp/community/co67422");
		}

		private void HelpForm_MouseDown(object sender, MouseEventArgs e)
		{
		}

		private void MyClose()
		{
			for (int i = 0; i < 200; i++)
			{
				Opacity -= 0.005f;
				Thread.Sleep(1);
			}
			Close();
		}

		private void HelpForm_Load(object sender, System.EventArgs e)
		{
		}

		private void HelpForm_Shown(object sender, System.EventArgs e)
		{
		}

		private void HelpForm_Click(object sender, System.EventArgs e)
		{
			MyClose();
		}

		private void label3_Click(object sender, System.EventArgs e)
		{
			MyClose();
		}

		private void label4_Click(object sender, System.EventArgs e)
		{
			MyClose();
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
			MyClose();
		}

		private void label2_Click(object sender, System.EventArgs e)
		{
			MyClose();
		}

		private void label6_Click(object sender, System.EventArgs e)
		{
			MyClose();
		}

		private void label5_Click(object sender, System.EventArgs e)
		{
			MyClose();
		}

		private void HelpForm_Activated(object sender, System.EventArgs e)
		{
		}
	}
}

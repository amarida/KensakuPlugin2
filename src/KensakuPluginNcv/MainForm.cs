using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Schema;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using Plugin;
using System.Reflection;
using System.Configuration;
using KensakuPluginNcv.Properties;
using System.Threading;

namespace Tekidoni
{
	public partial class MainForm : Form
	{
		private KensakuOperator kenOpe = null;
		private MessageForm messageForm = null;
		// マウスポイント
		Point mousePoint;

		internal KensakuOperator KensakuOperator
		{
			set { kenOpe = value; }
		}

		private KensakuPluginNcv kensakuPlugin = null;
		internal KensakuPluginNcv KensakuPlugin
		{
			set { kensakuPlugin = value; }
			private get { return kensakuPlugin; }
		}

        internal string WeatherPrefixMsg
        {
            get { return weatherPrefixTextBox.Text; }
        }

        internal string WeatherMiddleMsg
        {
            get { return weatherMiddleComboBox.Text; }
        }

        internal string WeatherSuffixMsg
        {
            get { return weatherSuffixTextBox.Text; }
        }

		internal string KeywordPrefixMsg
		{
			get { return keywordPrefixTextBox.Text; }
		}

		internal string KeywordSuffixMsg
		{
			get { return keywordSuffixTextBox.Text; }
		}

		internal int WaitTime
		{
			get { return Convert.ToInt32(timeLeftNumericUpDown.Text); }
		}

		internal string NotFoundMsg
		{
			get { return keywordNotFoundTextBox.Text; }
		}

		internal string WeatherNotCityMsg
		{
			get { return weatherNotCityTextBox.Text; }
		}

		internal string WeatherNotDayMsg
		{
			get { return weatherNotDayTextBox.Text; }
		}

		internal string SuccessSuffixMsg
		{
			get { return successSuffixTextBox.Text; }
		}

		public MainForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 既定値に戻すボタン押下
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void readButton_Click(object sender, EventArgs e)
		{
			try
			{
				// キーワード前
				Settings.Default.キーワード前 = "検索";
				// キーワード後
				Settings.Default.キーワード後 = "";
				// 検索失敗時
                Settings.Default.キーワード検索に失敗 = "データがありません";
				// お天気前
				Settings.Default.お天気前 = "天気";
				// お天気中
				Settings.Default.お天気中 = 1;
				// お天気後
				Settings.Default.お天気後 = "";
				// 同一IDでの検索間隔
				Settings.Default.同一IDでの検索間隔 = 30;
				// 地域名不正
				Settings.Default.地域名不正 = "地域名が不正です";
				// 予報日不正
				Settings.Default.予報日不正 = "予報日が不正です";
				// 成功時接尾語
				Settings.Default.成功時接尾語 = "です";

                // 外部ファイルから読み込み
				LoadData();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "error");
			}
		}

		private static void ValidationCallBack(object sender, ValidationEventArgs args)
		{
			Console.WriteLine("Invalid XSD schema: " + args.Exception.Message);
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			// 外部ファイルから読み込み
			LoadData();
			// 表示
			UpdateForm();
		}

        /// <summary>
        /// 画面表示
        /// </summary>
		private void UpdateForm()
		{
			// キーワードサンプル
			keywordSampleTextBox.Text = keywordPrefixTextBox.Text + "「hoge」" + keywordSuffixTextBox.Text;
			// お天気検索サンプル
			weatherSampleTextBox.Text = weatherPrefixTextBox.Text + "「東京」" + weatherMiddleComboBox.Text + "「明日」" + weatherSuffixTextBox.Text;
		}

        /// <summary>
        /// 外部ファイルから読み込み
        /// </summary>
		private void LoadData()
		{
			// キーワード前
			keywordPrefixTextBox.Text = Settings.Default.キーワード前;
			// キーワード後
			keywordSuffixTextBox.Text = Settings.Default.キーワード後;
			// 検索失敗時
			keywordNotFoundTextBox.Text = Settings.Default.キーワード検索に失敗;
			// お天気前
			weatherPrefixTextBox.Text = Settings.Default.お天気前;
			// お天気中
			weatherMiddleComboBox.SelectedIndex = Settings.Default.お天気中;
			// お天気後
			weatherSuffixTextBox.Text = Settings.Default.お天気後;
			// 同一IDでの検索間隔
			timeLeftNumericUpDown.Text = Settings.Default.同一IDでの検索間隔.ToString();
			// 地域名不正
			weatherNotCityTextBox.Text = Settings.Default.地域名不正;
			// 予報日不正
			weatherNotDayTextBox.Text = Settings.Default.予報日不正;
			// 成功時接尾語
			successSuffixTextBox.Text = Settings.Default.成功時接尾語;
		}

		/// <summary>
		/// 読み込みボタン押下
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void loadButton_Click(object sender, EventArgs e)
		{
            // 前回保存した状態に戻す
			Settings.Default.Reload();
            // 外部ファイルから読み込み
            LoadData();
		}

		/// <summary>
		/// 保存ボタン押下
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void saveButton_Click(object sender, EventArgs e)
		{
			Settings.Default.同一IDでの検索間隔 = Convert.ToInt32(timeLeftNumericUpDown.Text);
			Settings.Default.Save();
		}

		/// <summary>
		/// 起動／停止ボタン押下
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void startStopButton_Click(object sender, EventArgs e)
		{
			KensakuPlugin.IsAlive = !KensakuPlugin.IsAlive;
			startStopButton.Text = KensakuPlugin.IsAlive ? "停止" : "起動";
			aliveLabel.Text = kensakuPlugin.IsAlive ? "現在起動中です" : "現在停止中です";
			if (KensakuPlugin.IsAlive)
			{
				new PleaseConnect().ShowDialog();
			}
		}

		private void timer_Tick(object sender, EventArgs e)
		{
		}

		private void messageButton_Click(object sender, EventArgs e)
		{
			if (messageForm == null || messageForm.IsDisposed)
			{
				messageForm = new MessageForm(KensakuPlugin.Host);
				messageForm.Show();
			}
		}

		internal void SetStripText(string msg)
		{
			//toolStripStatusLabel.Text = msg;
		}

		private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			HelpForm form = new HelpForm();
			form.ShowDialog();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (messageForm != null)
			{
				messageForm.Close();
				messageForm = null;
			}
		}

		private void 左上付き運営コメントToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (messageForm == null || messageForm.IsDisposed)
			{
				messageForm = new MessageForm(KensakuPlugin.Host);
				messageForm.Show();
			}
		}

		/// <summary>
		/// お天気中変更イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void weatherMiddleComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Settings.Default.お天気中 = weatherMiddleComboBox.SelectedIndex;
			// 表示
			UpdateForm();
		}

		/// <summary>
		/// お天気前変更イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void weatherPrefixTextBox_TextChanged(object sender, EventArgs e)
		{
			Settings.Default.お天気前 = weatherPrefixTextBox.Text;
			// 表示
			UpdateForm();
		}

		/// <summary>
		/// お天気後変更イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void weatherSuffixTextBox_TextChanged(object sender, EventArgs e)
		{
			Settings.Default.お天気後 = weatherSuffixTextBox.Text;
			// 表示
			UpdateForm();
		}

		private void MainForm_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) { return; }
			mousePoint = new Point(e.X, e.Y);
		}

		private void MainForm_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) { return; }
			SetDesktopLocation(Left - mousePoint.X + e.X,
					Top - mousePoint.Y + e.Y);
		}

        private void keywordSuffixTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.キーワード後 = keywordSuffixTextBox.Text;
            // 表示
            UpdateForm();
        }

        private void keywordPrefixTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.キーワード前 = keywordPrefixTextBox.Text;
            // 表示
            UpdateForm();
        }

        private void keywordNotFoundTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.キーワード検索に失敗 = keywordNotFoundTextBox.Text;
        }

		private void weatherNotCityTextBox_TextChanged(object sender, EventArgs e)
		{
			Settings.Default.地域名不正 = weatherNotCityTextBox.Text;
		}

		private void weatherNotDayTextBox_TextChanged(object sender, EventArgs e)
		{
			Settings.Default.予報日不正 = weatherNotDayTextBox.Text;
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			Settings.Default.成功時接尾語 = successSuffixTextBox.Text;
		}

		private void timeLeftNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default.同一IDでの検索間隔 = Convert.ToInt32(timeLeftNumericUpDown.Text);
		}
	}
}

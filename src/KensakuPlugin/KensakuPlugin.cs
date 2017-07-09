using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using nwhois.plugin;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace Tekidoni
{
	public class KensakuPlugin : IPlugin
	{
		private KensakuOperator kenOpe = new KensakuOperator();
		private MainForm form = null;

		private IPluginHost host = null;
		private bool isAlive = false;

		/// <summary>
		/// フォームを閉じたとき
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void MyFormClosed(object sender, FormClosedEventArgs e)
		{
			form.SetStripText("MyFormClosed");
			isAlive = false;
			form = null;
		}

		#region IPlugin メンバ

		public string Description
		{
            get { return "けんさくさん"; }
		}

		public IPluginHost Host
		{
			get
			{
				return this.host;
			}
			set
			{
				this.host = value;
			}
		}

		public bool IsAlive
		{
			get { return isAlive; }
		}
		internal void SetAlive(bool alive)
		{
			isAlive = alive;
		}

		public string Name
		{
			get { return "けんさくさん for nwhois"; }
		}

		public void OnComment(NicoApi.Chat chat)
		{
			try
			{
				// キーワード検索
				string keywordPattern = string.Format("^{0}「(?<keyword>.*?)」{1}$",
					form.KeywordPrefixMsg, form.KeywordSuffixMsg);
				//Match kmatch = Regex.Match(chat.Message, @"みっくりさん「(?<keyword>.*?)」ってなに？");
				Match kmatch = Regex.Match(chat.Message, keywordPattern);
				if (kmatch.Success)
				{
					INamedChat nchat = chat as INamedChat;
					if (nchat != null && !string.IsNullOrEmpty(nchat.UserId))
					{
						long timeLeft = kenOpe.ConfirmWebAccess(nchat.UserId, form.WaitTime);
						if (timeLeft == 0)
						{
							string keyword = kmatch.Groups["keyword"].Value;
							Utility.PostMessage(host,
								string.Format(">>{0} {1}", chat.No,
								Utility.InsertBr(
								kenOpe.GetKeywordSearchMsg(keyword, form.NotFoundMsg, form.SuccessSuffixMsg))));
						}
						else
						{
							Utility.PostMessage(host,
								string.Format(">>{0}番さんが次に検索できるのは、あと{1}秒後です<br />(同一IDでの検索は{2}秒間空けてください)", chat.No, timeLeft, form.WaitTime));
						}
					}
					return;
				}

			}
			catch (Exception e)
			{
				Logger.write(e.Message);
				MessageBox.Show(e.Message);
			}
		}

		public void OnLiveStart(string liveId, DateTime baseTime, int commentCount)
		{
			try
			{
				// 初期化イベント
				kenOpe.Initialize();

				form.SetStripText(Utility.GetNowTime() + " 初期化完了");
			}
			catch (Exception e)
			{
				Logger.write(e.Message);
				MessageBox.Show(e.Message);
			}
		}

		public void OnLiveStop()
		{
			// 終了イベント
			form.SetStripText(Utility.GetNowTime() + " 終了イベント");
		}

		public void Run()
		{
			if (!isAlive)
			{
				form = new MainForm();
				form.Show();
				form.FormClosed += new FormClosedEventHandler(MyFormClosed);
				form.KensakuOperator = kenOpe;
				form.KensakuPlugin = this;
			}
		}

		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Plugin;
using NicoLibrary.NicoLiveAPI;
using NicoLibrary.NicoLiveData;
using System.Text.RegularExpressions;
using System.Threading;

namespace Tekidoni
{
	public class KensakuPluginNcv : IPlugin
	{
		private KensakuOperator kenOpe = new KensakuOperator();
		private MainForm form = null;

		private IPluginHost host = null;
		private bool isAlive = false;

		private bool isRun = false;

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
			isRun = false;
		}

		public void AutoRun()
		{
			throw new NotImplementedException();
		}

		public string Description
		{
			get { return "ユーザコメントからお天気検索とキーワード検索をするプラグインです。"; }
		}

		public IPluginHost Host
		{
			get
			{
				return host;
			}
			set
			{
				host = value;
			}
		}

		public bool IsAutoRun
		{
			get { return false; }
		}

		public string Name
		{
			get { return "けんさくさん for NCV"; }
		}

		public bool IsAlive
		{
			get { return isAlive; }
			set { isAlive = value; }
		}

		/// <summary>
		/// プラグイン起動時
		/// </summary>
		public void Run()
		{
			Logger.write("=== BEGIN ===");
			// 2重起動防止
			if (isRun)
			{
				return;
			}
			isRun = true;

			kenOpe.Initialize();

			form = new MainForm();
			form.Show();
			form.FormClosed += new FormClosedEventHandler(MyFormClosed);
			form.KensakuOperator = kenOpe;
			form.KensakuPlugin = this;

			host.BroadcastConnected += new BroadcastConnectedEventHandler(Connected);
			host.BroadcastDisConnected += new BroadcastDisConnectedEventHandler(DisConnected);
			host.SettingDirectoryChanged += new SettingDirectoryChangedEventHandler(ChangedSettingFilePath);
			Logger.write("=== END ===");
		}

		public string Version
		{
			get { return "0.1.0.4"; }
		}

		/// <summary>
		/// サーバ接続時の処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Connected( Object sender, EventArgs e)
		{
			Logger.write("=== BEGIN ===");
			// HeartBeat情報更新 & コメント受信 のイベントを有効にする
			host.HeartBeatUpdated += new HeartBeatUpdatedEventHandler(UpdatedHeartBeat);
			host.ReceivedComment += new ReceivedCommentEventHandler(ReceivedComment);
			Logger.write("=== END ===");
		}

		/// <summary>
		/// サーバ切断時の処理
		/// </summary>
		/// <param name="?"></param>
		void DisConnected( Object sender, EventArgs e)
		{
			Logger.write("=== BEGIN ===");
			// HeartBeat情報更新 & コメント受信 のイベントを無効にする
			host.HeartBeatUpdated -= new HeartBeatUpdatedEventHandler(UpdatedHeartBeat);
			host.ReceivedComment -= new ReceivedCommentEventHandler(ReceivedComment);
			Logger.write("=== END ===");
		}

		/// <summary>
		/// 設定ファイル保存パス変更時の処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ChangedSettingFilePath( Object sender, SettingDirectoryChangedEventArgs e)
		{
			Logger.write("=== BEGIN ===");
			String path = e.NewSettingDirectory;
			Logger.write("=== END ===");
		}

		/// <summary>
		/// HeartBeat情報更新時の処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void UpdatedHeartBeat(object sender, HeartBeatUpdatedEventArgs e)
		{
			Logger.write("=== BEGIN ===");
			NicoLiveHeartBeat hb = e.HeartBeat;
			Logger.write("=== END ===");
		}

		/// <summary>
		/// コメント受信時の処理
		/// </summary>
		/// <param name="?"></param>
		void ReceivedComment( object sender, ReceivedCommentEventArgs e)
		{
			Logger.write("=== BEGIN ===");
			try
			{
				if (!isAlive) { return; }

                if (e.CommentDataList.Count == 0)
                {
                    Logger.write(string.Format("sender:{0}, ReceivedCommentEventArgs{1}",
                        sender.ToString(), e.ToString()));

                    return;
                }

                Logger.write(string.Format("e.CommentDataList.Count: {0}",
					e.CommentDataList.Count));
				LiveCommentData data = e.CommentDataList[e.CommentDataList.Count - 1];

				Logger.write(string.Format("Comment:{0}, UserId:{1}",
					data.Comment, data.UserId));
				// 天気予報
				string weatherPattern = string.Format("^{0}「(?<city>.*?)」{1}「(?<day>.*?)」{2}$",
					form.WeatherPrefixMsg, form.WeatherMiddleMsg, form.WeatherSuffixMsg);
				//Match wmatch = Regex.Match(chat.Message, @"^みっくりさん「(?<city>.*?)」の「(?<day>.*?)」の天気(を?)教えて");
				Match wmatch = Regex.Match(data.Comment, weatherPattern);
				if (wmatch.Success)
				{
					Logger.write(string.Format("天気予報マッチ({0})", data.Comment));
					if (data != null && !string.IsNullOrEmpty(data.UserId))
					{
						long timeLeft = kenOpe.ConfirmWebAccess(data.UserId, form.WaitTime);
						if (timeLeft == 0)
						{
							string city = wmatch.Groups["city"].Value;
							string day = wmatch.Groups["day"].Value;
							Utility.PostMessage(host,
								string.Format(">>{0} {1}", data.No,
								kenOpe.GetWeatherMsg(city, day, form.WeatherNotCityMsg, form.WeatherNotDayMsg, form.SuccessSuffixMsg)));
						}
						else
						{
							Utility.PostMessage(host,
								string.Format(">>{0}番さんが次に検索できるのは、あと{1}秒後です<br />(同一IDでの検索は{2}秒間空けてください)", data.No, timeLeft, form.WaitTime));
						}
					}
					return;
				}
				// キーワード検索
				string keywordPattern = string.Format("^{0}「(?<keyword>.*?)」{1}$",
					form.KeywordPrefixMsg, form.KeywordSuffixMsg);
				//Match kmatch = Regex.Match(chat.Message, @"みっくりさん「(?<keyword>.*?)」ってなに？");
				Match kmatch = Regex.Match(data.Comment, keywordPattern);
				if (kmatch.Success)
				{
					if (data != null && !string.IsNullOrEmpty(data.UserId))
					{
						long timeLeft = kenOpe.ConfirmWebAccess(data.UserId, form.WaitTime);
						if (timeLeft == 0)
						{
							string keyword = kmatch.Groups["keyword"].Value;
							Utility.PostMessage(host,
								string.Format(">>{0} {1}", data.No,
								Utility.InsertBr(
								kenOpe.GetKeywordSearchMsg(keyword, form.NotFoundMsg, form.SuccessSuffixMsg))));
						}
						else
						{
							Utility.PostMessage(host,
								string.Format(">>{0}番さんが次に検索できるのは、あと{1}秒後です<br />(同一IDでの検索は{2}秒間空けてください)", data.No, timeLeft, form.WaitTime));
						}
					}
					return;
				}

			}
			catch (Exception ex)
			{
				Logger.write(ex.Message);
				MessageBox.Show(ex.Message);
			}
			finally
			{
				Logger.write("=== END ===");
			}
		}
	}
}

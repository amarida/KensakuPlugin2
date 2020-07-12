using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Tekidoni;
using anko2Sample;
using KensakuPluginAnko2.Properties;
using System.Text.RegularExpressions;

namespace Tekidoni
{
	internal sealed partial class SampleForm : Form {
		private ankoPlugin2.IPluginHost _host = null;
		private Form _hostForm = null;
		private Config _configData = new Config();

        #region private
        private bool isAlive = false;
        private TimeKeeper timeKeeper = new TimeKeeper();
        #endregion

        // プラグインが動作してるときtrueを返すようにすること
		public bool IsRun { get; private set; }

		public SampleForm(ankoPlugin2.IPluginHost host) {
			InitializeComponent();

			this._host = host;
			this._hostForm = (Form)host.Win32WindowOwner;
			ConfigLoad();

			// アンコちゃんからのイベント（他のイベントは随時追加してください）
			this._host.Initialized += new EventHandler(_host_Initialized);
			this._host.ConnectedServer += new EventHandler<ankoPlugin2.ReceiveContentStatusEventArgs>(_host_ConnectedServer);
			this._host.ReceiveContentStatus += new EventHandler<ankoPlugin2.ReceiveContentStatusEventArgs>(_host_ReceiveContentStatus);
			this._host.ReceiveChat += new EventHandler<ankoPlugin2.ReceiveChatEventArgs>(_host_ReceiveChat);
			this._host.DisconnectedServer += new EventHandler<ankoPlugin2.ConnectStreamEventArgs>(_host_DisconnectedServer);
			this._host.PluginDispose += new EventHandler(_host_PluginDispose);
		}

		private void SampleForm_Load(object sender, EventArgs e) {
			this.TopMost = _hostForm.TopMost;
            Size size = this.Size;

            // 外部ファイルから読み込み
            LoadData();
            // 表示
            UpdateForm();
        }

		private void SampleForm_FormClosing(object sender, FormClosingEventArgs e) {
			if(this.Visible) {
				ConfigSave();
			}

            isAlive = false;
            startStopButton.Text = isAlive ? "停止" : "起動";
            aliveLabel.Text = isAlive ? "現在起動中です" : "現在停止中です";

			if(e.CloseReason == CloseReason.UserClosing) {
				e.Cancel = true;
				this.Hide();
			}
		}



		#region アンコちゃんイベント処理（基本的にNon Thread Safeと思って実装したほうがいいよ）

		void _host_Initialized(object sender, EventArgs e) {
			this._host.Initialized -= new EventHandler(_host_Initialized);
			// アンコちゃんのフォームが表示されるときに起きるらしい

		}

		void _host_ConnectedServer(object sender, ankoPlugin2.ReceiveContentStatusEventArgs e) {
			// 放送に接続したときに起きる Non Thread Safeのとき有
			/*
			if(this.InvokeRequired) {
				Invoke(new Action<object, ankoPlugin2.ReceiveContentStatusEventArgs>(_host_ConnectedServer),sender, e);
				return;
			}
			//*/

		}

		void _host_ReceiveContentStatus(object sender, ankoPlugin2.ReceiveContentStatusEventArgs e) {
			// 放送の情報を取得したときに起きる 放送テスト時間のときは1秒毎にこのイベントが起きるので注意！
			// 2.0.35.5以降1秒毎に起きるのかは知りません Non Thread Safeのとき有かも
			/*
			if(this.InvokeRequired) {
				Invoke(new Action<object, ankoPlugin2.ReceiveContentStatusEventArgs>(_host_ReceiveContentStatus));
				return;
			}
			//*/

		}

		void _host_ReceiveChat(object sender, ankoPlugin2.ReceiveChatEventArgs e) {
			// コメントを受信したときに起きる Non Thread Safeのとき有
            if(this.InvokeRequired) {
                Action<object, ankoPlugin2.ReceiveChatEventArgs> myDelegate;
                myDelegate = new Action<object, ankoPlugin2.ReceiveChatEventArgs>(_host_ReceiveChat);
                Invoke(myDelegate, new Object[] { sender, e });
                return;
            }
            CommentOn(sender, e);
        }

		void _host_DisconnectedServer(object sender, ankoPlugin2.ConnectStreamEventArgs e) {
			// 生放送が終わったときに起きる /disconnect は2回くるので注意！
			// アンコちゃんフォームの放送切断・削除ボタンお押したときに起きる（2回目の削除したときに起きるみたい）
			// 2.0.35.5以降どうなってるのかは知りません Non Thread Safeのとき有かも
			/*
			if(this.InvokeRequired) {
				Invoke(new Action<object, ankoPlugin2.ConnectStreamEventArgs>(_host_DisconnectedServer));
				return;
			}
			//*/

		}

		void _host_PluginDispose(object sender, EventArgs e) {
			this._host.ConnectedServer -= new EventHandler<ankoPlugin2.ReceiveContentStatusEventArgs>(_host_ConnectedServer);
			this._host.ReceiveContentStatus -= new EventHandler<ankoPlugin2.ReceiveContentStatusEventArgs>(_host_ReceiveContentStatus);
			this._host.ReceiveChat -= new EventHandler<ankoPlugin2.ReceiveChatEventArgs>(_host_ReceiveChat);
			this._host.DisconnectedServer -= new EventHandler<ankoPlugin2.ConnectStreamEventArgs>(_host_DisconnectedServer);
			this._host.PluginDispose -= new EventHandler(_host_PluginDispose);
			// アンコちゃんが終了するときに起きる IDisposable実装みたいな処理をするといいのかも

		}

		#endregion



		#region 設定値の処理（今となっては古い形式、現在ならアプリケーション構成ファイルでしょうか）

		/// <summary>
		/// フォームのコントロールの状態を設定値として得る
		/// </summary>
		/// <returns></returns>
		private Config GetConfigData() {
			if(this.InvokeRequired) {
				return (Config)Invoke(new Func<Config>(GetConfigData));
			}

			// 以下追加した変数に代入
			//_configData.alwaysRun = checkBoxAlwaysRun.Checked;


			return _configData;
		}

		/// <summary>
		/// 設定値保存ファイルのパスを取得
		/// </summary>
		/// <returns></returns>
		private string GetConfigXmlPath() {
			return Path.Combine(_host.ApplicationDataFolder, this.GetType().Namespace + ".xml");
		}

		/// <summary>
		/// 設定値をファイルから読み込む
		/// </summary>
		/// <returns></returns>
		private bool ConfigLoad() {
            return true;
#if false
			bool result = false;
			Config configData = new Config();

			// 設定値の読込
			string configPath = GetConfigXmlPath();
			if(File.Exists(configPath)) {
				XmlSerializer serializer = new XmlSerializer(typeof(Config));
				try {
					using(FileStream fs = new FileStream(configPath, FileMode.Open)) {
						configData = (Config)serializer.Deserialize(fs);
						result = true;
						fs.Close();
					}
				}
				catch {
					result = false;
				}
			}
			else {
				result = false;
			}

			// 設定値の復元
			if(result) {
				this.Size = new Size(configData.windowWidth, configData.windowHeight);
			}

			if(configData.locationX < -this.Size.Width || Screen.GetBounds(this).Width < configData.locationX) {
				if(configData.locationY < 0 || Screen.GetBounds(this).Height < configData.locationY) {
					this.DesktopLocation = new Point(0, 0);
				}
				else {
					this.DesktopLocation = new Point(0, configData.locationY);
				}
			}
			else if(configData.locationY < 0 || Screen.GetBounds(this).Height < configData.locationY) {
				this.DesktopLocation = new Point(configData.locationX, 0);
			}
			else {
				this.DesktopLocation = new Point(configData.locationX, configData.locationY);
			}

			// 以下追加した変数の復元
			//checkBoxAlwaysRun.Checked = configData.alwaysRun;


			return result;
#endif
		}

		/// <summary>
		/// 設定値をファイルに保存する
		/// </summary>
		/// <returns></returns>
		private bool ConfigSave() {
            return true;
#if false

			// 設定値の取得
			Config configData = GetConfigData();

			// ウィンドウ状態
			System.Windows.Forms.FormWindowState state = this.WindowState;
			if(state == FormWindowState.Maximized) {
				this.WindowState = FormWindowState.Normal;
			}
			configData.locationX = this.DesktopLocation.X;
			configData.locationY = this.DesktopLocation.Y;
			configData.windowWidth = this.Size.Width;
			configData.windowHeight = this.Size.Height;
			if(state == FormWindowState.Maximized) {
				this.WindowState = FormWindowState.Maximized;
			}

			// 保存処理
			string configPath = GetConfigXmlPath();
			XmlSerializer serializer = new XmlSerializer(typeof(Config));
			try {
				using(FileStream fs = new FileStream(configPath, FileMode.Create)) {
					serializer.Serialize(fs, configData);
					fs.Close();
				}
			}
			catch {
				return false;
			}

			return true;
#endif
		}

		#endregion

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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void バージョン情報VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm form = new HelpForm();
            form.ShowDialog();
        }

        private void checkBoxAlwaysRun_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            bool isAvailable = _host.IsNetworkAvailable;


            isAlive = !isAlive;
            startStopButton.Text = isAlive ? "停止" : "起動";
            aliveLabel.Text = isAlive ? "現在起動中です" : "現在停止中です";
        }

        private void keywordPrefixTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.キーワード前 = keywordPrefixTextBox.Text;
            // 表示
            UpdateForm();
        }

        private void keywordSuffixTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.キーワード後 = keywordSuffixTextBox.Text;
            // 表示
            UpdateForm();
        }

        private void keywordNotFoundTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.キーワード検索に失敗 = keywordNotFoundTextBox.Text;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.成功時接尾語 = successSuffixTextBox.Text;
        }

        private void timeLeftNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.同一IDでの検索間隔 = Convert.ToInt32(timeLeftNumericUpDown.Text);
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
        /// 既定値に戻すボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void defaultButton_Click(object sender, EventArgs e)
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
                Settings.Default.同一IDでの検索間隔 = 10;
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

        internal string GetWeatherMsg(string city, string day, string notCityMsg, string notDayMsg, string successSuffixMsg)
        {
            Weather weathr = new Weather();
            string result;
            try
            {
                result = weathr.GetWeather(city, day);
                //return string.Format("「{0}」だよー", result);
                return string.Format("「{0}」{1}", result, successSuffixMsg);
            }
            catch (CityException)
            {
                //return string.Format("「{0}」っていう地域名が分からないよー＞＜", city);
                return string.Format(notCityMsg);
            }
            catch (DayException)
            {
                //return string.Format("予報日指定がおかしいよー＞＜");
                return string.Format(notDayMsg);
            }
            catch (Exception e)
            {
                return string.Format("予期しないエラーが発生しました（{0}）", e.Message);
            }
        }

        /// <summary>
        /// キーワード検索取得
        /// </summary>
        /// <param name="city"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        internal string GetKeywordSearchMsg(string keyword, string notFoundMsg, string successSuffixMsg)
        {
            var wikiApi = new WikipediaApi();
            string result;
            try
            {
                result = wikiApi.SearchKeyword(keyword);
                result = result.Substring(0, (result.IndexOf("。") == -1) ? result.Length : result.IndexOf("。"));
                //return string.Format("「{0}」のことだよー", result.TrimStart());
                return string.Format("「{0}」{1}", result.TrimStart(), successSuffixMsg);
            }
            catch (NotFoundException)
            {
                //return string.Format("それの意味は分かんないよー＞＜");
                return string.Format(notFoundMsg);
            }
            catch (Exception e)
            {
                return string.Format("予期しないエラーが発生しました（{0}）", e.Message);
            }
        }

        private void CommentOn(object sender, ankoPlugin2.ReceiveChatEventArgs e)
        {
            try
            {
                if (!isAlive) { return; }

                // 天気予報
                string weatherPattern = string.Format("^{0}「(?<city>.*?)」{1}「(?<day>.*?)」{2}$",
                    weatherPrefixTextBox.Text, weatherMiddleComboBox.Text, weatherSuffixTextBox.Text);

                Match wmatch = Regex.Match(e.Chat.Message, weatherPattern);
                if (wmatch.Success)
                {
                    if (e.Chat != null && !string.IsNullOrEmpty(e.Chat.UserId))
                    {
                        int waitTime = Convert.ToInt32(timeLeftNumericUpDown.Text);
                        long timeLeft = timeKeeper.Confirm(e.Chat.UserId, waitTime);
                        if (timeLeft == 0)
                        {
                            string city = wmatch.Groups["city"].Value;
                            string day = wmatch.Groups["day"].Value;
                            Utility.PostMessage(_host,
                                string.Format(">>{0} {1}", e.Chat.No,
                                GetWeatherMsg(city, day, weatherNotCityTextBox.Text, weatherNotDayTextBox.Text, successSuffixTextBox.Text)));
                        }
                        else
                        {
                            Utility.PostMessage(_host,
                                string.Format(">>{0}番さんが次に検索できるのは、あと{1}秒後です(同一IDでの検索は{2}秒間空けてください)", e.Chat.No, timeLeft, waitTime));
                        }
                    }
                    return;
                }
                // キーワード検索
                string keywordPattern = string.Format("^{0}「(?<keyword>.*?)」{1}$",
                    keywordPrefixTextBox.Text, keywordSuffixTextBox.Text);
                //Match kmatch = Regex.Match(chat.Message, @"みっくりさん「(?<keyword>.*?)」ってなに？");
                Match kmatch = Regex.Match(e.Chat.Message, keywordPattern);
                if (kmatch.Success)
                {
                    if (e.Chat != null && !string.IsNullOrEmpty(e.Chat.UserId))
                    {
                        int waitTime = Convert.ToInt32(timeLeftNumericUpDown.Text);
                        long timeLeft = timeKeeper.Confirm(e.Chat.UserId, waitTime);
                        if (timeLeft == 0)
                        {
                            string keyword = kmatch.Groups["keyword"].Value;
                            Utility.PostMessage(_host,
                                string.Format(">>{0} {1}", e.Chat.No,
                                Utility.InsertBr(
                                GetKeywordSearchMsg(keyword, keywordNotFoundTextBox.Text, successSuffixTextBox.Text))));
                        }
                        else
                        {
                            Utility.PostMessage(_host,
                                string.Format(">>{0}番さんが次に検索できるのは、あと{1}秒後です(同一IDでの検索は{2}秒間空けてください)", e.Chat.No, timeLeft, waitTime));
                        }
                    }
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }
	}
}

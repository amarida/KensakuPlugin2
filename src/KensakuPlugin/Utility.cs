using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using nwhois.plugin;

namespace Tekidoni
{
	class Utility
	{
		/// <summary>
		/// 文字列から計算
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		internal static string Calc(string str)
		{
			ProcessStartInfo psInfo = new ProcessStartInfo();

			psInfo.FileName = "powershell"; // 実行するファイル
			psInfo.Arguments = str;
			psInfo.CreateNoWindow = true; // コンソール・ウィンドウを開かない
			psInfo.UseShellExecute = false; // シェル機能を使用しない

			psInfo.RedirectStandardOutput = true; // 標準出力をリダイレクト

			Process p = Process.Start(psInfo); // アプリの実行開始

			string output = p.StandardOutput.ReadToEnd(); // 標準出力の読み取り
			output = output.Replace("\r\n", ""); // 改行コードの修正

			return output;
		}

		internal static string GetNowTime()
		{
			DateTime nowTime = DateTime.Now;
			StringBuilder sb = new StringBuilder();
			sb.Append(nowTime.ToString("yyyy/MM/dd HH:mm:ss"));
			sb.Append(".");
			sb.Append(nowTime.Millisecond.ToString("000"));
			return sb.ToString();
		}

		internal static void PostMessage(IPluginHost host, string message)
		{
			try
			{
				if (host != null && host.CanPostMessage)
				{
					//string outmsg = string.Format("<font color=\"#ffc0cb\">{0}</font>", message);
					bool result = host.PostOwnerMessage(message, "", "☆自動応答");
					if(!result)
					{
						Logger.write(result);
					}
				}
				else
				{
					string errmsg = (host == null) ? "host == null" : "host.CanPostMessage == false";
					Logger.write("PostMessage(" + message + ") - " + errmsg);
				}
			}
			catch (Exception e)
			{
				Logger.write("Exception PostMessage - " + e.Message);
				host.PostMessage(message, "184");
			}
		}

		internal static void PostMessageOwner(IPluginHost host, string message, string name, string command)
		{
			Logger.write("Begin");
			Logger.write(message);
			try
			{
				if (host != null && host.CanPostMessage)
				{
					host.PostOwnerMessage(message, command, name);
				}
				else
				{
					string errmsg = (host == null) ? "host == null" : "host.CanPostMessage == false";
					Logger.write("PostMessageOwner(" + message + ") - " + errmsg);
				}
			}
			catch (Exception e)
			{
				Logger.write("Exception PostMessageOwner - " + e.Message);
				host.PostMessage(message, "184");
			}
			Logger.write("End");
		}

		/// <summary>
		/// 運営ＮＧコメントかどうか
		/// </summary>
		/// <param name="chat"></param>
		/// <returns>true: 運営ＮＧコメント</returns>
		internal static bool IsNg(NicoApi.Chat chat)
		{
			// 運営ＮＧ
			IFilteredChat fchat = chat as IFilteredChat;
			if (fchat != null)
			{
				if ((fchat.FilteredReason & Filteringtype.Word) != 0)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// 改行タグ追加
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		internal static string InsertBr(string str)
		{
			if (str.Length > 69)
			{
				str = str.Substring(0, 69);
				str += "(ry";
			}
			//if (str.Length > 50)
			//{
			//	str = str.Insert(50, "<br />");
			//}
			//if (str.Length > 25)
			//{
			//	str = str.Insert(25, "<br />");
			//}
			return str;
		}

		internal static string GetMethodName()
		{
			StackTrace st = new StackTrace(true);
			StackFrame sf = st.GetFrame(2);
			return sf.GetMethod().Name;
		}
	}
}

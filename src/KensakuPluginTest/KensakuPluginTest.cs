using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using nwhois.plugin;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Threading;

using NicoApi;

namespace Tekidoni
{
	[TestFixture]
	public class ProgramTest
	{
		private Dictionary<string, string> convertList = new Dictionary<string, string>();

		[SetUp]
		public void Setup()
		{
			convertList.Add("[ｗＷ]", "わら");
			convertList.Add("ｍｍｑ|ＭＭＱ", "もえもえきゅうん");
		}

		[Test]
		public void OnComment()
		{
			string Message = "初音ミク";
			Process process = new Process();
			process.StartInfo.FileName = @"E:\Documents\初音\vocaloidtts014\miku_speak";
			process.StartInfo.Arguments = Message;

			process.Start();
		}

		[Test]
		public void OnComment2()
		{
			// マッチするかどうか確認する。 
			Regex regex = new Regex("ab[c|d]");
			if (regex.IsMatch("dddabdddd"))
			{
				Console.WriteLine("match");
			}
			else
			{
				Console.WriteLine("no match");
			}

			// マッチする文字列を切り出す。 
			MatchCollection matchCol = regex.Matches("aaaabcabdacd");
			foreach (Match match in matchCol)
			{
				Console.WriteLine(match.Value);
			}

			// マッチする文字列を置換する。 
			string ret = regex.Replace("aaabcabdacd", "bbb");
			Console.WriteLine(ret);

			string src = "ｱaMMQmmq@aあ-`アｵwｗ";
			Console.WriteLine(src);
			string ret2 = Strings.StrConv(src, VbStrConv.Wide, 0); // Regex.Replace("ｱaあａ@aあ-`アアｲｳｴｵwｗ", "[\uFF61-\uFF9Fa-zA-Z@]+", new MatchEvaluator(RegexMatchEvaluator));
			Console.WriteLine(ret2);
			string ret3 = ret2;
			foreach(var dic in convertList)
			{
				ret3 = Regex.Replace(ret3, dic.Key, dic.Value);
			}
			Console.WriteLine(ret3);
			string ret4 = Regex.Replace(ret3, "[ａ-ｚＡ-Ｚ]", new MatchEvaluator(RegexMatchEvaluator2));
			Console.WriteLine(ret4);
		}
		string RegexMatchEvaluator(Match m)
		{
			Console.WriteLine("1. " + m.Value);
			return Strings.StrConv(m.Value, VbStrConv.Wide, 0);
		}
		string RegexMatchEvaluator2(Match m)
		{
			Console.WriteLine("2. " + m.Value);
			return m.Value + " ";
		}
		string RegexMatchEvaluator3(Match m)
		{
			Console.WriteLine("3. " + m.Value);
			return "わら";
		}

		[Test]
		public void CutLongMsg()
		{
			string str = "１２３４５";
			int max = 3;
			Console.WriteLine(str.Length);
			Console.WriteLine(str.Remove(max, str.Length - max));
		}

		[Test]
		public void ToHiragana()
		{
			Console.WriteLine(ToHiragana(102));
		}
		public string ToHiragana(int src)
		{
			int sen = src / 1000;
			int hyaku = (src - sen * 1000) / 100;
			int juu = (src - sen * 1000 - hyaku * 100) / 10;
			int ichi = src - sen * 1000 - hyaku * 100 - juu * 10;
			Console.WriteLine("sen " + sen);
			Console.WriteLine("hyaku " + hyaku);
			Console.WriteLine("juu " + juu);
			Console.WriteLine("ichi " + ichi);

			StringBuilder sb = new StringBuilder();
			sb.Append((sen == 0) ? "" : (sen == 1) ? "せん" : Strings.StrConv(sen.ToString(), VbStrConv.Wide, 0) + "せん");
			sb.Append((hyaku == 0) ? "" : (hyaku == 1) ? "ひゃく" : Strings.StrConv(hyaku.ToString(), VbStrConv.Wide, 0) + "ひゃく");
			sb.Append((juu == 0) ? "" : (juu == 1) ? "じゅう" : Strings.StrConv(juu.ToString(), VbStrConv.Wide, 0) + "じゅう");
			sb.Append((src == 0) ? "ぜろ" : (ichi == 0) ? "" : Strings.StrConv(ichi.ToString(), VbStrConv.Wide, 0));

			return sb.ToString();
		}

		[Test]
		public void 文字列からToHiragana()
		{
			string str = "0-10-1000-12345";
			Console.WriteLine(str);
			string ret = Regex.Replace(str, @"\d+", new MatchEvaluator(RegexMatchEvaluatorHiraganga));
			Console.WriteLine(ret);
		}
		string RegexMatchEvaluatorHiraganga(Match m)
		{
			Console.WriteLine(m.Value);
			return ToHiragana(int.Parse(m.Value));
		}

		[Test]
		public void 正規表現()
		{
			string str = Strings.StrConv("/perm 先枠参加者は10分まで自重でおねがいします。", VbStrConv.Wide, 0);
			Console.WriteLine(str);
			string ret = Regex.Replace(str, "^／.*\\s", "", RegexOptions.IgnoreCase);
			Console.WriteLine(ret);
		}

		[Test]
		public void プロセス経過()
		{
			Process process = new Process();
			process.StartInfo.FileName = @"notepad";
			process.Start();

			do
			{
				Process[] prc = Process.GetProcessesByName("notepad");
				if (prc.Length != 0)
				{
					Console.WriteLine((DateTime.Now - prc[0].StartTime));
					Console.WriteLine((DateTime.Now - prc[0].StartTime).Seconds);
					Console.WriteLine((DateTime.Now - prc[0].StartTime).TotalSeconds);
					Console.WriteLine();
				}
				else
				{
					break;
				}
				Thread.Sleep(3000);
			} while (true);
		}

		[Test]
		public void タグ無視()
		{
			string str = "<font size=\"14\">★ミクさん　　　　　　　　　　　　　　　　　　　　　</font><br />　　　　　　　答えは2だよー";
			string ret = Regex.Replace(str, "<.+?>", "", RegexOptions.IgnoreCase);
			ret = Regex.Replace(ret, "★ミクさん", "");
			ret = Regex.Replace(ret, "　", "");
			Console.WriteLine(ret);
		}

		[Test]
		public void 初見さん()
		{
			string[] strs = {"初見", "初見ですよん", "初見さんいらしゃい"};
			foreach (string message in strs)
			{
				Console.WriteLine(message);
				if (Regex.Match(message, @"^初見$").Success ||
					Regex.Match(message, @"^初見です.*").Success)
				{
					Console.WriteLine("初見さん");
				}
			}
		}

		[Test]
		public void CalcRegex()
		{
			string str = "2 * (3.1 + 4) =";

			Match match = Regex.Match(str, @"(?<math>\(?\d+\.?\d*\s*\)?\s*([+\-*/]\s*\(?\s*\d+\.?\d*\s*\)?\s*)+)=");
			if (match.Success == true)
			{
				Console.WriteLine("match.Success == true");
				string output = CalcDeteil(match.Groups["math"].Value);
				Console.WriteLine("答えは" + output.ToString() + "だよー");
			}
			else
			{
				Console.WriteLine("match.Success == false");
			}
		}

		[Test]
		public void Calc()
		{
			Console.WriteLine(CalcDeteil("3 * (1 + 1) /2"));
		}

		[Test]
		public void 自動打ち返し()
		{
			List<string> strs = new List<string>();
			strs.Add("(｀・ω-)『+』▄︻┻┳═一　（´∀｀＠ゝ");
			strs.Add("(｀・ω-)『+』▄︻┻┳═一 （´∀｀＠ゝ");
			strs.Add("（◞≼●≽◟◞౪◟◞≼●≽◟）『+』▄︻┻┳═一　（´∀｀＠ゝ");
			strs.Add("の（●）H（●）『+』▄︻┻┳═一　（´∀｀＠ゝ");
			strs.Add("（水●´◉◞౪◟◉●)ノ『+』▄︻┻┳═一　（´∀｀＠ゝ");
			strs.Add("(´≖◞౪◟≖｀)『+』▄︻┻┳═一　（´∀｀＠ゝ");
			strs.Add("ああ(´≖◞౪◟≖｀)『+』▄︻┻┳═一　（´∀｀＠ゝああ");
			foreach (string str in strs)
			{
				Console.WriteLine(str);
				Match match = Regex.Match(str, @"(?<face>.?[(（].+?[)）].?『\+』▄︻┻┳═一)\s*（´∀｀＠ゝ");
				if (match.Success == true)
				{
					string output = "それは残像だ＞ι＠´∀｀）『+』▄︻┻┳═一　" + match.Groups["face"].Value + "　（´∀:;.:...";
					Console.WriteLine(output);
				}
				Console.WriteLine();
			}
		}

		[Test]
		public void 自動醤油()
		{
			List<string> strs = new List<string>();
			strs.Add("どういう事？");
			strs.Add("どうゆう事？");
			strs.Add("どういうこと？");
			strs.Add("どうゆうこと？");
			strs.Add("どういう事なの？");
			strs.Add("どうゆう事なの？");
			strs.Add("どういうことなの？");
			strs.Add("どうゆうことなの？");
			strs.Add("どーゆー事？");
			strs.Add("どーゆーこと？");
			strs.Add("どーゆー事なの？");
			strs.Add("どーゆーことなの？");
			foreach (string str in strs)
			{
				Console.WriteLine(str);
				Match match3 = Regex.Match(str, @"どう[いゆ]う(事|こと)(なの)?？|どーゆー(事|こと)(なの)?？");
				if (match3.Success == true)
				{
					string output = "しょーゆーこと";
					Console.WriteLine(output);
				}
				Console.WriteLine();
			}
		}

		[Test]
		public void 三桁文字列を平仮名に()
		{
		}

		[Test]
		public void Hpa()
		{
			List<string> strs = new List<string>();
			strs.Add("ＨＰＡって何の略？");
			strs.Add("ＨＰＡは何の略？");
			strs.Add("ＨＰＡって何人？");
			strs.Add("ＨＰＡは何人？");
			foreach (string str in strs)
			{
				Console.WriteLine(str);
				Match match = Regex.Match(str, @"ＨＰＡって何[^人]|ＨＰＡは何[^人]");
				if (match.Success == true)
				{
					Console.WriteLine("true");
				}
				else
				{
					Console.WriteLine("false");
				}
				Console.WriteLine();
			}
		}

		[Test]
		public void Pattern()
		{
			string pattern = string.Format("{0}「(?<city>.*?)」{1}「(?<day>.*?)」{2}",
				"あ", "い", "う");
			Console.WriteLine(pattern);
        }

		public string CalcDeteil(string str)
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
	}
}

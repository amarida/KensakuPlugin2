using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Plugin;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace Tekidoni
{
	public class KensakuOperator
	{
		/// <summary>
		/// タイムキーパー
		/// </summary>
		private TimeKeeper timeKeeper = new TimeKeeper();

		internal void Initialize()
		{
		}

		internal string ConvertComment(string message, int maxLength)
		{
			string result = "コンバート失敗";
			// 2桁の数値はひらがなに変換
			// タグを削除
			result = DeletedTag(message);
			// 半角カナ、半角英字、半角数字を全角に変換
			result = ToWide(result);
			// 長いものは省略
			result = CutLongMsg(result, maxLength);
			// 英字にはスペースを加える
			result = ToPlaceSpace(result);
			return result;
		}

		/// <summary>
		/// タグを削除
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		private string DeletedTag(string str)
		{
			string ret = Regex.Replace(str, "<.+?>", "", RegexOptions.IgnoreCase);
			ret = Regex.Replace(ret, "★ミクさん", "");
			ret = Regex.Replace(ret, "　", "");
			return ret;
		}

		/// <summary>
		/// 数字を平仮名に変換
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		private string ToHiragana(int no)
		{
			int hyaku = no / 100;
			int juu = (no - hyaku * 100) / 10;
			int ichi = no - hyaku * 100 - juu * 10;
			Console.WriteLine("hyaku " + hyaku);
			Console.WriteLine("juu " + juu);
			Console.WriteLine("ichi " + ichi);

			StringBuilder sb = new StringBuilder();
			sb.Append((hyaku == 0) ? "" : (hyaku == 1) ? "ひゃく" : Strings.StrConv(hyaku.ToString(), VbStrConv.Wide, 0) + "ひゃく");
			sb.Append((juu == 0) ? "" : (juu == 1) ? "じゅう" : Strings.StrConv(juu.ToString(), VbStrConv.Wide, 0) + "じゅう");
			sb.Append(Strings.StrConv(ichi.ToString(), VbStrConv.Wide, 0));

			return sb.ToString();
		}

		/// <summary>
		/// 半角カナ、半角英字、半角数字を全角に変換
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		private string ToWide(string str)
		{
			return Strings.StrConv(str, VbStrConv.Wide, 0);
			//return Regex.Replace(str, "[\uFF61-\uFF9Fa-zA-Z1-9]+", new MatchEvaluator(RegexMatchEvaluatorWide));
		}
		private string RegexMatchEvaluatorWide(Match m)
		{
			return Strings.StrConv(m.Value, VbStrConv.Wide, 0);
		}

		/// <summary>
		/// 英字にはスペースを加える
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		private string ToPlaceSpace(string str)
		{
			return Regex.Replace(str, "[ａ-ｚＡ-Ｚ]", new MatchEvaluator(RegexMatchEvaluatorPlaceSpace));
		}
		private string RegexMatchEvaluatorPlaceSpace(Match m)
		{
			return m.Value + " ";
		}

		/// <summary>
		/// 長い場合は切り取る
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		private string CutLongMsg(string str, int maxLength)
		{
			if (maxLength == 0) { return str; }
			if (maxLength >= str.Length) { return str; }

			string ret = str.Remove(maxLength, str.Length - maxLength);
			return ret + "、いかりゃく";
		}

		/// <summary>
		/// 天気予報取得
		/// </summary>
		/// <param name="city"></param>
		/// <param name="day"></param>
		/// <returns></returns>
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

		/// <summary>
		/// 確認
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		internal long ConfirmWebAccess(string id, int waitTime)
		{
			return timeKeeper.Confirm(id, waitTime);
		}
	}
}

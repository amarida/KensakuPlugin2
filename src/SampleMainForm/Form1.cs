using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Tekidoni;

namespace SampleMainForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
			//var ret = SearchKeyword(textBox1.Text);
			var ret = SearchKeyword2(textBox1.Text);
		}
		public string SearchKeyword2(string keyword)
		{
			string url = string.Format("http://api.excelapi.org/language/wikipedia_summary?word={0}", keyword);
			HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
			using (HttpWebResponse webRes = (HttpWebResponse)webReq.GetResponse())
			{
				Stream stream = webRes.GetResponseStream();
				using (StreamReader reader = new StreamReader(stream))
				{
					string str = reader.ReadToEnd();
					if (str == string.Empty)
					{
						throw new Exception();
					}
					MessageBox.Show(str);

					return "";
				}
			}
		}

		public string SearchKeyword(string keyword)
		{
#if false
			string url = string.Format("http://d.hatena.ne.jp/keyword?word={0}&mode=rss&ie=utf8", keyword);
			HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
			using (HttpWebResponse webRes = (HttpWebResponse)webReq.GetResponse())
			{
				Stream stream = webRes.GetResponseStream();
				using (StreamReader reader = new StreamReader(stream))
				{
					string str = reader.ReadToEnd();
					XmlDocument xdoc = new System.Xml.XmlDocument();
					xdoc.LoadXml(str);
					XmlNode root = xdoc["rdf:RDF"];
					System.Xml.XmlNode item = root["item"];
					if (item == null)
					{
						throw new Exception();
					}
					return item["description"].InnerText;
				}
			}
		}
#else
			// http://api.excelapi.org/language/wikipedia_summary?word=%E5%8E%9F%E5%B4%8E
			//string url = string.Format("http://wikipedia.simpleapi.net/api?keyword={0}&output=xml", keyword);
			string url = string.Format("https://ja.wikipedia.org/w/api.php?format=xml&action=query&prop=revisions&rvprop=content&titles={0}", keyword);
			//string url = string.Format("http://api.excelapi.org/language/wikipedia_summary?word={0}", keyword);
			HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
			using (HttpWebResponse webRes = (HttpWebResponse)webReq.GetResponse())
			{
				Stream stream = webRes.GetResponseStream();
				using (StreamReader reader = new StreamReader(stream))
				{
					string str = reader.ReadToEnd();
					XmlDocument xdoc = new System.Xml.XmlDocument();
					xdoc.LoadXml(str);
					//var results = xdoc["results"];
					//var result = results["result"];
					var result = xdoc["api"]["query"]["pages"]["page"]["revisions"]["rev"];
					//var result = results["rev"];
					if (result == null)
					{
						throw new Exception();
					}
					//var body = result["body"];

					var ret = result.InnerText;


					var test = ret.Substring(0, (ret.IndexOf("。") == -1) ? ret.Length : ret.IndexOf("。"));
					var test2 =  test.TrimStart();

					string test3 = Regex.Replace(test2, "'''", "", RegexOptions.IgnoreCase);
					test3 = Regex.Replace(test3, "（.*?）", "", RegexOptions.IgnoreCase);
					//Regex r = new Regex(@"\[\[.*?\|(?<msg>.*?)\]\]", RegexOptions.IgnoreCase);
					Regex r = new Regex(@"\[\[[^\[\[\]\]]*\]\]", RegexOptions.IgnoreCase);
					Match m = r.Match(test3);
					while (m.Success)
					{
						var re = m.Groups["msg"].Value;
						//test3 = Regex.Replace(test3, @"\[\[.*?\|.*?\]\]", re, RegexOptions.IgnoreCase);

						m.NextMatch();
					}

					return "";
				}
			}
		}
#endif

        private void button2_Click(object sender, EventArgs e)
        {
			string ret = SearchWeather(string.Empty, string.Empty);
		}

		public string SearchWeather(string cityName, string japaneseDay)
        {
			//city = "1859171";
			cityName = "東京";
			japaneseDay = "今日";
			int cityCode = WeatherUtility.ConvertCityNameToCode(cityName);
			int day = WeatherUtility.ConvertNihongoToDay(japaneseDay);

			string API_KEY = "955dd8ef2471eafbf608090d4b972f8a";
			string BASE_URL = "http://api.openweathermap.org/data/2.5/forecast";

			var date = DateTime.Now;
			var date_ = string.Format("{0}-{1:00}-{2:00} {3:00}:{4:00}:{5:00}", date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);

			int day_n = day; // 0:今日、1:明日、2:明後日

			bool isToday = false;
			switch (day_n)
			{
				case 0:
					// 今日
					isToday = true;
					break;
				case 1:
					// 明日の12時
					date = date.AddDays(1);
					date_ = string.Format("{0}-{1:00}-{2:00} 12:00:00", date.Year, date.Month, date.Day);
					break;
				case 2:
					// 明後日の12時
					date = date.AddDays(2);
					date_ = string.Format("{0}-{1:00}-{2:00} 12:00:00", date.Year, date.Month, date.Day);
					break;

			}

			//string url = string.Format("{0}?q=Akashi&lang=ja&APPID={1}", BASE_URL, API_KEY);
			//string url = string.Format("{0}?q=Akashi&APPID={1}", BASE_URL, API_KEY);
			string url = string.Format("{0}?id={1}&APPID={2}", BASE_URL, cityCode, API_KEY);
			HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
			string retValue = string.Empty;
			using (HttpWebResponse webRes = (HttpWebResponse)webReq.GetResponse())
			{
				Stream stream = webRes.GetResponseStream();
				using (StreamReader reader = new StreamReader(stream))
				{
					string str = reader.ReadToEnd();
					var obj = JObject.Parse(str);

					if (isToday)
					{
						retValue = obj["list"][3]["weather"][0]["description"].ToString();
					}
					else
					{
						foreach (var data in obj["list"])
						{
							//if (data["dt_txt"].ToString() == "2020-09-20 18:00:00")
							if (data["dt_txt"].ToString() == date_)
							{
								retValue = data["weather"][0]["description"].ToString();
								break;
							}
						}
					}
					//var ret = obj["list"][0]["weather"][0]["description"].ToString();
				}
			}
			retValue = WeatherUtility.ConvertEngToJpn(retValue);

			return retValue;
        }
		/*
		01d	clear sky			快晴	 
		02d	few clouds			晴れ	few clouds
		03d	scattered clouds	くもり	scattered clouds
		04d	broken clouds		くもり	broken clouds
		09d	shower rain			小雨	 
		10d	rain				雨	 
		11d	thunderstorm		雷雨	 
		13d	snow				雪	 
		50d	mist				霧	 
		 */

	}
}

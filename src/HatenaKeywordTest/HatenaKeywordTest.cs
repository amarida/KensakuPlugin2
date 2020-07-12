using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using NUnit.Framework;
using System.Net;
using System.IO;

namespace Tekidoni
{
#if false
	[TestFixture]
	public class HatenaKeywordTest
	{
		public static void Main()
		{
			new HatenaKeywordTest().GetKeyword();
		}

		[SetUp]
		public void Setup()
		{
		}

		/// <summary>
		/// 検索フィードの取得
		/// </summary>
		[Test]
		public void GetSearch()
		{
			string url = string.Format("http://search.hatena.ne.jp/keyword?word=兵庫県&mode=rss&ie=utf8&page=1");
			HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
			using (HttpWebResponse webRes = (HttpWebResponse)webReq.GetResponse())
			{
				Stream stream = webRes.GetResponseStream();
				using (StreamReader reader = new StreamReader(stream))
				{
					string str = reader.ReadToEnd();
					System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
					xdoc.LoadXml(str);
					Console.WriteLine(str);
					Console.WriteLine("===========================================");
					System.Xml.XmlNode root = xdoc["rdf:RDF"];
					System.Xml.XmlNode item = root["item"];
					Console.WriteLine(item["description"].InnerText);
				}
			}
		}

		/// <summary>
		/// キーワードのフィードの取得
		/// </summary>
		[Test]
		public void GetKeyword()
		{
			string url = string.Format("http://d.hatena.ne.jp/keyword?word=初音ミク&mode=rss&ie=utf8");
			HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
			using (HttpWebResponse webRes = (HttpWebResponse)webReq.GetResponse())
			{
				Stream stream = webRes.GetResponseStream();
				using (StreamReader reader = new StreamReader(stream))
				{
					string str = reader.ReadToEnd();
					System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
					xdoc.LoadXml(str);
					Console.WriteLine(str);
					Console.WriteLine("===========================================");
					System.Xml.XmlNode root = xdoc["rdf:RDF"];
					System.Xml.XmlNode item = root["item"];
					string result= item["description"].InnerText;
					Console.WriteLine(result);
					Console.WriteLine("===========================================");
					Console.WriteLine(result.Substring(0, (result.IndexOf("。") == -1) ? result.Length : result.IndexOf("。")));
				}
			}
		}

		/// <summary>
		/// キーワードのフィードの取得
		/// </summary>
		[Test]
		public void GetKeywordErrorTest()
		{
			string url = string.Format("http://d.hatena.ne.jp/keyword?word=俺&mode=rss&ie=utf8");
			HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
			using (HttpWebResponse webRes = (HttpWebResponse)webReq.GetResponse())
			{
				Stream stream = webRes.GetResponseStream();
				using (StreamReader reader = new StreamReader(stream))
				{
					string str = reader.ReadToEnd();
					System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
					xdoc.LoadXml(str);
					Console.WriteLine(str);
					Console.WriteLine("===========================================");
					System.Xml.XmlNode root = xdoc["rdf:RDF"];
					System.Xml.XmlNode item = root["item"];
					if (item == null)
					{
						Console.WriteLine("item == null");
					}
				}
			}
		}
	}
#endif
}

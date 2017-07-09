using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

namespace Tekidoni
{
	public class HatenaKeyword
	{
		public string SearchHatenaKeyword(string keyword)
		{
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
						throw new NotFoundException();
					}
					return item["description"].InnerText;
				}
			}
		}
	}
}

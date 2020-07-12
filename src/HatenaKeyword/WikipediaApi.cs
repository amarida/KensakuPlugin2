using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

namespace Tekidoni
{
	public class WikipediaApi
	{
		public string SearchKeyword(string keyword)
		{
			string url = string.Format("http://wikipedia.simpleapi.net/api?keyword={0}&output=xml", keyword);
			HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
			using (HttpWebResponse webRes = (HttpWebResponse)webReq.GetResponse())
			{
				Stream stream = webRes.GetResponseStream();
				using (StreamReader reader = new StreamReader(stream))
				{
					string str = reader.ReadToEnd();
					XmlDocument xdoc = new System.Xml.XmlDocument();
					xdoc.LoadXml(str);
					var results = xdoc["results"];
					var result = results["result"];
					if (result == null)
					{
						throw new NotFoundException();
					}
					var body = result["body"];

					return body.InnerText;
//					return "";
				}
			}
		}
	}
}

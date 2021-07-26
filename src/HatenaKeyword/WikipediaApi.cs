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
			string url = string.Format("http://api.excelapi.org/language/wikipedia_summary?word={0}", keyword);
			HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
			using (HttpWebResponse webRes = (HttpWebResponse)webReq.GetResponse())
			{
				Stream stream = webRes.GetResponseStream();
				using (StreamReader reader = new StreamReader(stream))
				{
					string str = reader.ReadToEnd();
					if(str == string.Empty)
                    {
						throw new NotFoundException();
                    }
					return str;
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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
			var ret = SearchKeyword(textBox1.Text);
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
						throw new Exception();
					}
					var body = result["body"];

					return "";
				}
			}
		}
#endif

	}
}

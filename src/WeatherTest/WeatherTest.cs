using System;
using System.Collections.Generic;
using System.Text;
//using NUnit.Framework;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Codeplex.Data;

namespace Tekidoni
{
#if false
    [DataContract]
    public class FriendInfo
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public int Age { get; set; }
    }
    
    [TestFixture]
	public class WeatherTest
	{
		Weather weather = new Weather();

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void GetWeatherData()
		{
            // HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(@"http://weather.livedoor.com/forecast/webservice/rest/v1?city=70&day=tomorrow");
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(@"http://weather.livedoor.com/forecast/webservice/json/v1?city=400040");
            using (HttpWebResponse webRes = (HttpWebResponse)webReq.GetResponse())
			{
				Stream stream = webRes.GetResponseStream();
				using (StreamReader reader = new StreamReader(stream))
				{
					string str = reader.ReadToEnd();
					Console.WriteLine(str);
				}
			}
		}

        [Test]
        public void GetWeatherDataEx()
        {
            // HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(@"http://weather.livedoor.com/forecast/webservice/rest/v1?city=70&day=tomorrow");
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(@"http://weather.livedoor.com/forecast/webservice/json/v1?city=400040");
            using (HttpWebResponse webRes = (HttpWebResponse)webReq.GetResponse())
            {
                Stream stream = webRes.GetResponseStream();
                using (StreamReader reader = new StreamReader(stream))
                {
					string str = reader.ReadToEnd();
                    Console.WriteLine(str);
                    Console.WriteLine();
                    var obj = DynamicJson.Parse(str);
                    Console.WriteLine(obj.forecasts[0].telop);
                }
            }
        }

		[Test]
		public void GetWeather()
		{
			try
			{
				string we = weather.GetWeather("神戸", "明日");
				Console.WriteLine(we);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}			
		}

		[Test]
		public void ConvertCityNameToCode()
		{
			int code1 = WeatherUtility.ConvertCityNameToCode("兵庫県");
			int code2 = WeatherUtility.ConvertCityNameToCode("神戸");
			Assert.AreEqual(code1, code2);
			code1 = WeatherUtility.ConvertCityNameToCode("兵庫");
			code2 = WeatherUtility.ConvertCityNameToCode("神戸市");
			Assert.AreEqual(code1, code2);
			code1 = WeatherUtility.ConvertCityNameToCode("京都府");
			code2 = WeatherUtility.ConvertCityNameToCode("京都");
			Assert.AreEqual(code1, code2);
			code1 = WeatherUtility.ConvertCityNameToCode("東京都");
			code2 = WeatherUtility.ConvertCityNameToCode("東京");
			Assert.AreEqual(code1, code2);
		}
	}
#endif
}

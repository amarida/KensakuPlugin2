using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Schema;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using Codeplex.Data;
using Newtonsoft.Json.Linq;

namespace Tekidoni
{
	public class Weather
	{
		private static void ValidationCallBack(object sender, ValidationEventArgs args)
		{
			Console.WriteLine("Invalid XSD schema: " + args.Exception.Message);
		}
		public string GetWeather(string cityName, string japaneseDay)
		{
			int cityCode = WeatherUtility.ConvertCityNameToCode(cityName);
			int day = WeatherUtility.ConvertNihongoToDay(japaneseDay);
			// 0:今日、1:明日、2:明後日
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

#if false
		/// <summary>
		/// 指定地域の天気を返す
		/// </summary>
		/// <param name="city">地域名</param>
		/// <param name="day">予報日</param>
		/// <returns></returns>
		public string GetWeather(string cityName, string japaneseDay)
		{
			int cityCode = WeatherUtility.ConvertCityNameToCode(cityName);
			int day = WeatherUtility.ConvertNihongoToDay(japaneseDay);

            string url = string.Format("http://weather.livedoor.com/forecast/webservice/json/v1?city={0:D6}", cityCode);
			HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
			using (HttpWebResponse webRes = (HttpWebResponse)webReq.GetResponse())
			{
				Stream stream = webRes.GetResponseStream();
				using (StreamReader reader = new StreamReader(stream))
				{
                    string str = reader.ReadToEnd();
                    Console.WriteLine(str);
                    Console.WriteLine();
                    var obj = DynamicJson.Parse(str);
                    return obj.forecasts[day].telop;
                }

				//Stream responseStream = webRes.GetResponseStream();

				//XmlSchemaSet sc = new XmlSchemaSet();
				//Assembly assembly = Assembly.GetExecutingAssembly();
				//Stream resourceStream = assembly.GetManifestResourceStream("Weather.WeatherData.xsd");

				//ValidationEventHandler validationEventHandler = new ValidationEventHandler(ValidationCallBack);
				//XmlSchema schema = XmlSchema.Read(resourceStream, new ValidationEventHandler(validationEventHandler));
				//sc.Add(schema);

				//XmlReaderSettings settings = new XmlReaderSettings();
				//settings.ValidationType = ValidationType.Schema;
				//settings.Schemas.Add(sc);
				//settings.ValidationFlags = XmlSchemaValidationFlags.ProcessSchemaLocation;
				//settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessIdentityConstraints;

				//Console.WriteLine("9");
				//XmlSerializer serializer = new XmlSerializer(typeof(NewDataSet));

				//Console.WriteLine("a");
				//using (XmlReader reader = XmlReader.Create(responseStream, settings))
				//{
				//    // XMLファイルの逆シリアル化を行う 
				//    lwws rootClass = (lwws)serializer.Deserialize(reader);

				//    return rootClass.telop;
				//}
			}
		}
#endif
	}
}

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

namespace Tekidoni
{
	public class Weather
	{
		private static void ValidationCallBack(object sender, ValidationEventArgs args)
		{
			Console.WriteLine("Invalid XSD schema: " + args.Exception.Message);
		}
		
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
	}
}

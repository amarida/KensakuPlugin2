using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Net;
using System.IO;

namespace Tekidoni
{
	// ÉçÉOÉNÉâÉX
	static class Logger
	{
		public static void write<T>(T param) {
			using (StreamWriter writer = new StreamWriter("KensakuPlugin.log", true))
			{
				string methodName = Utility.GetMethodName();
				if (methodName.Length > 15)
				{
					methodName = methodName.Remove(15);
				}
				writer.WriteLine(string.Format("{0} {1, -15} - {2}",
					Utility.GetNowTime(), methodName, param));
			}
		}
	};
}
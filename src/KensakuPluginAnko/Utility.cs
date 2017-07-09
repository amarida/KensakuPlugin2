using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Tekidoni
{
	class Utility
	{

		/// <summary>
		/// 改行タグ追加
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		internal static string InsertBr(string str)
		{
			if (str.Length > 75)
			{
				str = str.Substring(0, 75);
				str += "(ry";
			}
			if (str.Length > 50)
			{
				str = str.Insert(50, "<br />");
			}
			if (str.Length > 25)
			{
				str = str.Insert(25, "<br />");
			}
			return str;
		}

		internal static string GetMethodName()
		{
			StackTrace st = new StackTrace(true);
			StackFrame sf = st.GetFrame(2);
			return sf.GetMethod().Name;
		}

        internal static void PostMessage(ankoPlugin2.IPluginHost host, string message)
        {
            try
            {
                if (host != null && host.IsNetworkAvailable)
                {
                    host.PostOwnerComment(message, "", "☆自動応答");
                    //bool result = host.SendOwnerComment("", message, "☆自動応答");
                    //if (!result)
                    //{
                    //}
                }
                else
                {
                   // string errmsg = (host == null) ? "host == null" : "host.CanPostMessage == false";
                }
            }
            catch (Exception /*e*/)
            {
               // host.SendComment(message);
            }
        }
    }
}

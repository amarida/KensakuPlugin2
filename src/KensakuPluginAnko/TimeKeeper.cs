using System;
using System.Collections.Generic;
using System.Text;

namespace Tekidoni
{
	class TimeKeeper
	{
		/// <summary>
		/// 各人の最終時間
		/// </summary>
		private Dictionary<string, DateTime> lastTime = new Dictionary<string, DateTime>();

		/// <summary>
		/// 追加
		/// 既に居たら上書き
		/// </summary>
		/// <param name="id"></param>
		private void Add(string id)
		{
			if (lastTime.ContainsKey(id))
			{
				lastTime[id] = DateTime.Now;
				return;
			}
			lastTime.Add(id, DateTime.Now);
		}

		/// <summary>
		/// 残り時間
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		private long TimeLeft(string id, int waitTime)
		{
			if (lastTime.ContainsKey(id))
			{
				TimeSpan timeSpan = DateTime.Now - lastTime[id];
				return (waitTime * 1000) - (long)timeSpan.TotalMilliseconds;
			}
			return 0;
		}

		/// <summary>
		/// 確認
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		internal long Confirm(string id, int waitTime)
		{
			long timeLeft = TimeLeft(id, waitTime) / 1000;
			if (timeLeft <= 0)
			{
				Add(id);
				return 0;
			}
			return timeLeft;
		}
	}
}

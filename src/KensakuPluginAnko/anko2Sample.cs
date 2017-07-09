using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ankoPlugin2;

namespace Tekidoni {
	/// <summary>
	/// 
	/// </summary>
	public sealed class anko2Sample : ankoPlugin2.IPlugin {
		private ankoPlugin2.IPluginHost _host = null;
		private SampleForm _form = null;



		#region ankoPlugin2.IPluginの実装

		public ankoPlugin2.IPluginHost host {
			get {
				return _host;
			}
			set {
				_host = value;
				_form = new SampleForm(value);
			}
		}

		public string Name {
            get { return "けんさくさん" + (_form.IsRun ? "（動作中）" : ""); }
		}

		public string Description {
            get { return "ユーザコメントからお天気検索とキーワード検索をするプラグインです。"; }
		}

		public bool IsAlive {
			get { return _form.IsRun; }
		}

		public void Run() {
			if(!_form.Visible) {
				_form.Show((System.Windows.Forms.IWin32Window)host.Win32WindowOwner);
			}
			else if(_form.WindowState == System.Windows.Forms.FormWindowState.Minimized) {
				_form.WindowState = System.Windows.Forms.FormWindowState.Normal;
			}
		}

		#endregion

	}
}
